Public Class login

  
   

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dispose()
    End Sub
    ' Deklarasi objek gambar

    Sub baru()
        Dim image As New Bitmap("C:\Users\joyok\Downloads\png-transparent-computer-icons-google-account-user-email-miscellaneous-rim-area-removebg-preview.png")

        ' Loop melalui setiap piksel pada gambar
        For y As Integer = 0 To image.Height - 1
            For x As Integer = 0 To image.Width - 1
                ' Ubah warna piksel menjadi putih
                image.SetPixel(x, y, Color.White)
            Next
        Next
    End Sub


    Sub MySub()
        ' Deklarasi objek gambar
        Dim gambar As Image

        ' Membaca gambar dari file
        gambar = Image.FromFile("C:\Users\joyok\Downloads\png-transparent-computer-icons-google-account-user-email-miscellaneous-rim-area-removebg-preview.png")

        ' Menampilkan gambar di PictureBox
        PictureBox1.Image = gambar

        ' Menyesuaikan ukuran gambar dengan PictureBox
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Width = 100
        PictureBox1.Height = 100



    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call MySub()
        Call baru()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from user where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'"
        cek = perintah.ExecuteReader()
        cek.Read()
        If cek.HasRows Then
            userLogin = TextBox1.Text
            beranda.lbluser.Text = TextBox1.Text

            cek.Close()
            'update lastlogin pada tabel user berdasarkan user yang login
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            perintah.CommandText = "update user set lastlogin=now() where username='" & TextBox1.Text & "'"
            perintah.ExecuteNonQuery()
            beranda.Show()
            Me.Hide()
        Else
            MsgBox("Username atau Password salah", MsgBoxStyle.Critical, "Informasi")
        End If
        kon.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dispose()
    End Sub
End Class