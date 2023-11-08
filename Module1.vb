Imports System.IO
Imports QRCoder
Imports System.Drawing
Imports System.Drawing.Imaging

Module Module1
    Sub Main()
        ' Specify file path
        Dim FilePath As String = "M:\Metal Codes\CSV POC\003926 2X7 In M W                  MA.csv"

        ' Check if File Exists
        If File.Exists(FilePath) Then
            ' Read file contents
            Dim Text As String = File.ReadAllText(FilePath)

            ' Extract the first 6 digits of the part number from the file name
            Dim fileName As String = Path.GetFileNameWithoutExtension(FilePath)
            Dim partNumber As String = fileName.Substring(0, 6)

            ' Generate QRCode From Text
            Dim qrGenerator As New QRCodeGenerator()
            Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(Text, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As New QRCode(qrCodeData)
            Dim qrCodeImage As Bitmap = qrCode.GetGraphic(8)

            ' Specify the directory where you want to save the QR code
            Dim saveDirectory As String = "M:\Metal Codes\Console QR"

            ' Check if the directory exists; if not, create it
            If Not Directory.Exists(saveDirectory) Then
                Directory.CreateDirectory(saveDirectory)
            End If

            ' Save the QR code with the part number as the filename
            Dim savePath As String = Path.Combine(saveDirectory, partNumber & ".png")
            qrCodeImage.Save(savePath, ImageFormat.Png)

            ' Display a message indicating the QR code was saved
            Console.WriteLine("QR code saved to: " & savePath)
        Else
            Console.WriteLine("File does not exist")
        End If

        ' Wait for user to close
        Console.ReadLine()
    End Sub
End Module