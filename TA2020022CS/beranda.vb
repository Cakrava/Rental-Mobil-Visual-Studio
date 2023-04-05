Public Class beranda

    

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Dispose()

    End Sub


    Private Sub mobil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobil.Click
        form_mobil.Show()
        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

    


    

    Private Sub penyewa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles penyewa.Click
        form_penyewa.Show()
        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

   





    Private Sub penyewaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles penyewaan.Click
        form_peminjaman.Show()
        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

   
    Private Sub btn_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_user.Click
        user.Show()
        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

    Private Sub kembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kembali.Click
        form_pengembalian.Show()
        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

    Private Sub lap_mobil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lap_mobil.Click
        form_lap_mobil.Show()
        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

    Private Sub lap_penyewa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lap_penyewa.Click
        form_lap_penyewa.Show()
        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

    Private Sub lap_sewa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lap_sewa.Click
        form_lap_peminjaman.Show()

        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

    Private Sub lap_kembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lap_kembali.Click
        form_lap_pengembalian.Show()
        mobil.Enabled = False
        penyewa.Enabled = False
        penyewaan.Enabled = False
        kembali.Enabled = False
        lap_sewa.Enabled = False
        lap_mobil.Enabled = False
        lap_kembali.Enabled = False
        lap_penyewa.Enabled = False
        btn_user.Enabled = False
        keluar.Enabled = False
    End Sub

    Private Sub beranda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call MySub()
    End Sub
    Sub MySub()
        ' Deklarasi objek gambar
        Dim gambar As Image

        ' Membaca gambar dari file
        gambar = Image.FromFile("C:\Users\joyok\Downloads\mobil.png")

        ' Menampilkan gambar di PictureBox
        PictureBox1.Image = gambar

        ' Menyesuaikan ukuran gambar dengan PictureBox
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Width = 300
        PictureBox1.Height = 100



    End Sub
End Class