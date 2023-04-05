Public Class form_lap_pengembalian

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tglAwal As String
        Dim tglAkhir As String
        tglAwal = Format(dtpTglAwal.Value, "yyyy-MM-dd")
        tglAkhir = Format(dtpTglAkhir.Value, "yyyy-MM-dd")
        Dim CrLapPenjualan As New cetak_laporan_pengembalian
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "SELECT dikembalikan.id_pinjam, tgl, penyewa.id_penyewa, penyewa.nama_penyewa, COUNT(dikembalikan.id_pinjam) AS jml_pinjam, total FROM dikembalikan JOIN detail_kembali ON dikembalikan.id_pinjam=detail_kembali.id_pinjam JOIN penyewa ON dikembalikan.id_penyewa=penyewa.id_penyewa WHERE tgl BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' GROUP BY detail_kembali.id_pinjam"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "lap_kembali")
        CrLapPenjualan.SetDataSource(ds.Tables("lap_kembali"))
        cetak_pengembalian.crv.ReportSource = CrLapPenjualan
        cetak_pengembalian.WindowState = FormWindowState.Maximized
        cetak_pengembalian.Show()
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