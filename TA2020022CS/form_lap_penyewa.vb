Public Class form_lap_penyewa






    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dispose()
        beranda.mobil.Enabled = True
        beranda.penyewa.Enabled = True
        beranda.penyewaan.Enabled = True
        beranda.kembali.Enabled = True
        beranda.lap_sewa.Enabled = True
        beranda.lap_mobil.Enabled = True
        beranda.lap_kembali.Enabled = True
        beranda.lap_penyewa.Enabled = True
        beranda.btn_user.Enabled = True
        beranda.keluar.Enabled = True
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CrLapBarang As New cetak_lap_penyewa
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from penyewa where id_penyewa between '" & cmbAwal.Text & "' and '" & cmbAkhir.Text & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "penyewa")
        CrLapBarang.SetDataSource(ds.Tables("penyewa"))
        cetak_penyewa.crv.ReportSource = CrLapBarang
        cetak_penyewa.WindowState = FormWindowState.Maximized
        cetak_penyewa.Show()
        kon.Close()
    End Sub

    Private Sub form_lap_penyewa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select *from penyewa order by id_penyewa"
        cek = perintah.ExecuteReader
        While cek.Read
            cmbAwal.Items.Add(cek.Item("id_penyewa"))
            cmbAkhir.Items.Add(cek.Item("id_penyewa"))
        End While


        kon.Close()
    End Sub
End Class