Public Class form_lap_peminjaman

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tglAwal As String
        Dim tglAkhir As String
        tglAwal = Format(dtpTglAwal.Value, "yyyy-MM-dd")
        tglAkhir = Format(dtpTglAkhir.Value, "yyyy-MM-dd")
        Dim CrLapPenjualan As New cetak_laporan_peminjaman
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "SELECT pinjam.id_pinjam, tgl, penyewa.id_penyewa, penyewa.nama_penyewa, COUNT(pinjam.id_pinjam) AS jml_pinjam, total FROM pinjam JOIN detail_pinjam ON pinjam.id_pinjam=detail_pinjam.id_pinjam JOIN penyewa ON pinjam.id_penyewa=penyewa.id_penyewa WHERE tgl BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' GROUP BY detail_pinjam.id_pinjam"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "lap_pinjam")
        CrLapPenjualan.SetDataSource(ds.Tables("lap_pinjam"))
        cetak_peminjaman.crv.ReportSource = CrLapPenjualan
        cetak_peminjaman.WindowState = FormWindowState.Maximized
        cetak_peminjaman.Show()
        kon.Close()
    End Sub

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
End Class