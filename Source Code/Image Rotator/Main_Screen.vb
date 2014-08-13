Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Threading
Imports System.ComponentModel

Public Class Main_Screen

    Private busyworking As Boolean = False

    Private lastinputline As String = ""
    Private inputlines As Long = 0
    Private highestPercentageReached As Integer = 0
    Private inputlinesprecount As Long = 0
    Private pretestdone As Boolean = False
    Private primary_PercentComplete As Integer = 0
    Private percentComplete As Integer

    Private SelectedIndex As Integer = 0

    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()
                Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.Message.ToString

                Display_Message1.Timer1.Interval = 1000
                Display_Message1.ShowDialog()
                Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                dir = Nothing
                Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ":" & ex.ToString)
                filewriter.Flush()
                filewriter.Close()
                filewriter = Nothing
            End If
            ex = Nothing
            identifier_msg = Nothing
        Catch exc As Exception
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As DialogResult
        result = FolderBrowserDialog1.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub


    Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo

        Dim j As Integer
        Dim encoders() As ImageCodecInfo


        encoders = ImageCodecInfo.GetImageEncoders()

        For j = 0 To encoders.Length - 1
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next
        Return Nothing

    End Function



    Private Sub cancelAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelAsyncButton.Click

        ' Cancel the asynchronous operation.
        Me.BackgroundWorker1.CancelAsync()

        ' Disable the Cancel button.
        cancelAsyncButton.Enabled = False
        sender = Nothing
        e = Nothing
    End Sub 'cancelAsyncButton_Click

    Private Sub PreCount_Function()
        Try
            inputlinesprecount = 0
            Dim dinfo As DirectoryInfo
            dinfo = New DirectoryInfo(TextBox1.Text)
            For Each finfo As FileInfo In dinfo.GetFiles()
                If finfo.Name.EndsWith("_gtransform.jpg") = False Then
                    inputlinesprecount = inputlinesprecount + 1
                Else
                    My.Computer.FileSystem.DeleteFile(finfo.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                End If

                finfo = Nothing
            Next

        Catch ex As Exception
            Error_Handler(ex, "PreCount_Function")
        End Try
    End Sub

    Private Sub startAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startAsyncButton.Click
        Try
            If busyworking = False Then
                busyworking = True


                inputlines = 0
                lastinputline = ""
                highestPercentageReached = 0
                inputlinesprecount = 0
                pretestdone = False

                TextBox1.Enabled = False
                Button1.Enabled = False
                startAsyncButton.Enabled = False
                cancelAsyncButton.Enabled = True
                ' Start the asynchronous operation.

                BackgroundWorker1.RunWorkerAsync(TextBox1.Text)
            End If
        Catch ex As Exception
            Error_Handler(ex, "StartWorker")
        End Try
    End Sub

    ' This event handler is where the actual work is done.
    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        ' Assign the result of the computation
        ' to the Result property of the DoWorkEventArgs
        ' object. This is will be available to the 
        ' RunWorkerCompleted eventhandler.
        e.Result = MainWorkerFunction(worker, e)
        sender = Nothing
        e = Nothing
        worker.Dispose()
        worker = Nothing
    End Sub 'backgroundWorker1_DoWork

    ' This event handler deals with the results of the
    ' background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        busyworking = False
        ' First, handle the case where an exception was thrown.
        If Not (e.Error Is Nothing) Then
            Error_Handler(e.Error, "backgroundWorker1_RunWorkerCompleted")
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            Me.ProgressBar1.Value = 0

        Else
            ' Finally, handle the case where the operation succeeded.

            Me.ProgressBar1.Value = 100
        End If

        TextBox1.Enabled = True
        Button1.Enabled = True
        startAsyncButton.Enabled = True
        cancelAsyncButton.Enabled = False

        sender = Nothing
        e = Nothing


    End Sub 'backgroundWorker1_RunWorkerCompleted

    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged


        Me.ProgressBar1.Value = e.ProgressPercentage
        Me.ToolStripStatusLabel1.Text = lastinputline & "   (" & inputlines & " of " & inputlinesprecount & ")"

        sender = Nothing
        e = Nothing
    End Sub

    Function MainWorkerFunction(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Boolean
        Dim result As Boolean = False
        Try
            If Me.pretestdone = False Then
                primary_PercentComplete = 0
                worker.ReportProgress(0)
                PreCount_Function()
                Me.pretestdone = True
            End If

            If worker.CancellationPending Then
                e.Cancel = True
                Return False
            End If

            primary_PercentComplete = 0
            worker.ReportProgress(0)



            Dim dinfo As DirectoryInfo
            dinfo = New DirectoryInfo(TextBox1.Text)

            If dinfo.Exists Then
                'If dinfo.Parent.Exists Then
                'If My.Computer.FileSystem.FileExists((dinfo.Parent.FullName & "\gallery.htm").Replace("\\", "\")) Then
                '    MsgBox("Warning: An existing file (" & (dinfo.Parent.FullName & "\gallery.htm").Replace("\\", "\") & ") is about to be overwritten. It is suggested you rename this file before continuing.", MsgBoxStyle.Information, "Gallery File Exists")
                'End If
                'Dim filewriter As StreamWriter = New StreamWriter((dinfo.Parent.FullName & "\gallery.htm").Replace("\\", "\"), False, System.Text.Encoding.ASCII)
                'filewriter.WriteLine("<HTML>" & vbCrLf)
                'filewriter.WriteLine("<TABLE border=""0"" cellspacing=""0"" cellpadding=""4"">" & vbCrLf)
                'Dim currentcolumn As Integer = 1

                For Each finfo As FileInfo In dinfo.GetFiles()
                    If worker.CancellationPending Then
                        e.Cancel = True
                        Return False
                    End If
                    Try

                        Dim acceptable As String() = {".jpg", ".bmp", ".gif", ".png", ".jpeg"}
                        If Array.IndexOf(acceptable, finfo.Extension.ToLower) <> -1 Then


                            Dim objImage As System.Drawing.Image
                            objImage = System.Drawing.Image.FromFile(finfo.FullName)
                            '  Dim objCallback As System.Drawing.Image.GetThumbnailImageAbort = New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

                            Try
                                'Dim newwidth, newheight As Integer
                                'newwidth = 100
                                'newheight = 100
                                'Select Case SelectedIndex
                                '    Case 0
                                '        newwidth = NumericUpDown2.Value
                                '        newheight = CInt(objImage.Height / (objImage.Width / NumericUpDown2.Value))
                                '    Case 1
                                '        newwidth = CInt(objImage.Width / (objImage.Height / NumericUpDown2.Value))
                                '        newheight = NumericUpDown2.Value
                                '    Case Else
                                '        newwidth = 100
                                '        newheight = 100
                                'End Select
                                If SelectedIndex = -1 Then
                                    SelectedIndex = 0
                                End If
                                Dim flipv As String = ""
                                Dim rotatev As Integer = 0

                                If Flip1.Checked = True Then
                                    flipv = flipv & "X"
                                End If
                                If Flip2.Checked = True Then
                                    flipv = flipv & "Y"
                                End If

                                If Rotate1.Checked = True Then
                                    rotatev = 90
                                End If
                                If Rotate2.Checked = True Then
                                    rotatev = 180
                                End If
                                If Rotate3.Checked = True Then
                                    rotatev = 270
                                End If
                                If Rotate4.Checked = True Then
                                    rotatev = 0
                                End If
                                If SelectedIndex = 1 Then
                                    rotatev = 360 - rotatev
                                End If

                                If rotatev = 0 And flipv = "" Then
                                    objImage.RotateFlip(RotateFlipType.RotateNoneFlipNone)
                                End If
                                If rotatev = 0 And flipv = "XY" Then
                                    objImage.RotateFlip(RotateFlipType.RotateNoneFlipXY)
                                End If
                                If rotatev = 0 And flipv = "X" Then
                                    objImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
                                End If
                                If rotatev = 0 And flipv = "Y" Then
                                    objImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
                                End If

                                If rotatev = 90 And flipv = "" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
                                End If
                                If rotatev = 90 And flipv = "XY" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate90FlipXY)
                                End If
                                If rotatev = 90 And flipv = "X" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate90FlipX)
                                End If
                                If rotatev = 90 And flipv = "Y" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate90FlipY)
                                End If

                                If rotatev = 180 And flipv = "" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate180FlipNone)
                                End If
                                If rotatev = 180 And flipv = "XY" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate180FlipXY)
                                End If
                                If rotatev = 180 And flipv = "X" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate180FlipX)
                                End If
                                If rotatev = 180 And flipv = "Y" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate180FlipY)
                                End If

                                If rotatev = 270 And flipv = "" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate270FlipNone)
                                End If
                                If rotatev = 270 And flipv = "XY" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate270FlipXY)
                                End If
                                If rotatev = 270 And flipv = "X" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate270FlipX)
                                End If
                                If rotatev = 270 And flipv = "Y" Then
                                    objImage.RotateFlip(RotateFlipType.Rotate270FlipY)
                                End If

                            Catch ex As Exception
                                Error_Handler(ex, "MainWorkerFunctionImageHandler")
                            End Try

                            'objCallback = Nothing
                            Dim qualityEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

                            Dim enc As System.Drawing.Imaging.EncoderParameter = New System.Drawing.Imaging.EncoderParameter(qualityEncoder, 100L)
                            Dim encs As System.Drawing.Imaging.EncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
                            encs.Param(0) = enc
                            Dim coder As System.Drawing.Imaging.ImageCodecInfo

                            coder = GetEncoderInfo("image/jpeg")
                            Dim savename As String = finfo.FullName.Remove(finfo.FullName.Length - finfo.Extension.Length) + "_gtransform.jpg"
                            Try
                                objImage.Save(savename, coder, encs)
                            Catch ex As Exception
                                Error_Handler(ex, "MainWorkerFunctionImageHandler")
                            End Try
                            enc.Dispose()
                            encs.Dispose()
                            coder = Nothing
                            objImage.Dispose()
                            lastinputline = "Processed: " & finfo.Name

                            'If currentcolumn = 1 Then
                            '    filewriter.WriteLine(vbTab & "<TR>" & vbCrLf)
                            'End If
                            'filewriter.WriteLine("<td align=""center"" valign=""top"">" & vbCrLf)
                            'filewriter.WriteLine("<a target=""_blank"" href=""" & dinfo.Name & "/" & finfo.Name & """>" & vbCrLf)
                            'filewriter.Write("<img border=""" & NumericUpDown3.Value & """ src=""" & dinfo.Name & "/" & finfo.Name.Remove(finfo.Name.Length - finfo.Extension.Length) + "_gthumb.jpg" & """")
                            'filewriter.WriteLine("></a><br>")
                            'filewriter.WriteLine(finfo.Name.Replace(finfo.Extension, "") & "</td>")


                            'filewriter.WriteLine("</td>")
                            'currentcolumn = currentcolumn + 1
                            'If currentcolumn > NumericUpDown1.Value Then
                            '    filewriter.WriteLine(vbTab & "</TR>" & vbCrLf)
                            '    currentcolumn = 1
                            'End If


                        Else
                            lastinputline = "Ignored: " & finfo.Name
                        End If


                        inputlines = inputlines + 1

                        ' Report progress as a percentage of the total task.
                        percentComplete = 0
                        If inputlinesprecount > 0 Then
                            percentComplete = CSng(inputlines) / CSng(inputlinesprecount) * 100
                        Else
                            percentComplete = 100
                        End If
                        primary_PercentComplete = percentComplete
                        If percentComplete > highestPercentageReached Then
                            highestPercentageReached = percentComplete
                            worker.ReportProgress(percentComplete)
                        End If
                    Catch ex As Exception
                        Error_Handler(ex, "MainWorkerFunctionImageHandler")
                    End Try
                    If worker.CancellationPending Then
                        e.Cancel = True
                        Return False
                    End If
                    finfo = Nothing
                Next

                'While currentcolumn <> 1

                '    filewriter.WriteLine("<td align=""center"" valign=""top"">")

                '    filewriter.WriteLine("&nbsp;</td>")
                '    currentcolumn = currentcolumn + 1
                '    If currentcolumn > NumericUpDown1.Value Then
                '        filewriter.WriteLine(vbTab & "</TR>" & vbCrLf)
                '        currentcolumn = 1
                '    End If

                'End While

                '    filewriter.WriteLine("</TABLE>" & vbCrLf)
                '    filewriter.WriteLine("</HTML>" & vbCrLf)
                '    filewriter.Flush()
                '    filewriter.Close()
                'End If
            End If
            dinfo = Nothing




        Catch ex As Exception
            Error_Handler(ex, "MainWorkerFunction")
        End Try
        worker.Dispose()
        worker = Nothing
        e = Nothing
        Return result

    End Function

    Private Sub Form1_Close(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            If TextBox1.Text.Length > 0 Then
                Dim dinfo As DirectoryInfo = New DirectoryInfo(TextBox1.Text)
                If dinfo.Exists Then
                    My.Settings.ImageFolder = TextBox1.Text
                    My.Settings.Save()
                End If
                dinfo = Nothing
            End If

        Catch ex As Exception
            Error_Handler(ex, "Application Close")
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RotateDirection.SelectedIndex = 0
            Me.Text = "Image Rotator " & My.Application.Info.Version.Major & My.Application.Info.Version.Minor & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
            If Not My.Settings.ImageFolder = Nothing Then
                If My.Settings.ImageFolder.Length > 0 Then
                    Dim dinfo As DirectoryInfo = New DirectoryInfo(My.Settings.ImageFolder)
                    If dinfo.Exists Then
                        FolderBrowserDialog1.SelectedPath = My.Settings.ImageFolder
                        TextBox1.Text = My.Settings.ImageFolder
                    End If
                    dinfo = Nothing
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex, "Application Load")
        End Try

    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectedIndex = RotateDirection.SelectedIndex
    End Sub

    Private Sub RotateDirection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateDirection.SelectedIndexChanged
        SelectedIndex = RotateDirection.SelectedIndex
    End Sub
End Class
