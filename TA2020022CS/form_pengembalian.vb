Public Class form_pengembalian

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cari_peminjaman.Show()
        Button3.Enabled = False

        Button5.Enabled = False

    End Sub

    Private Sub form_pengembalian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Enabled = False

    End Sub
    Sub bersih()
        txtId.Clear()
        txtNama.Clear()
        txtnohp.Clear()
        txtNofak.Clear()
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Sub setdgv()
        'mengatur judul kolom
        dgv.Columns(0).HeaderText = "ID Kendaraan"
        dgv.Columns(1).HeaderText = "Merk"
        dgv.Columns(2).HeaderText = "No Plat"

        dgv.Columns(0).Width = 70
        dgv.Columns(1).Width = 100
        dgv.Columns(2).Width = 100
    
    End Sub
    Private Sub txtNofak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNofak.TextChanged
       dgv.Columns.Clear()
        Call tampilData("SELECT mobil.id_mobil, mobil.merk,mobil.no_plat FROM detail_pinjam JOIN mobil ON detail_pinjam.id_mobil = mobil.id_mobil WHERE detail_pinjam.id_pinjam LIKE '%" & txtNofak.Text & "%'")
        Call setdgv()
    End Sub
    Sub tampilData(ByVal sql As String)
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = sql
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "data")
        dgv.DataSource = ds.Tables("data")
        kon.Close()

    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
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

  
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "insert into kembali (id_pinjam, tgl_dikembalikan,id_acak) values ('" & txtNofak.Text & "',now(),'" & idacak.Text & "')"
        perintah.ExecuteNonQuery()
        kon.Close()
        Call bersih()
        form_pengembalian_Load(e, CType(AcceptButton, EventArgs))

        MsgBox("Kendaraan berhasil dikembalikan", MsgBoxStyle.Information, "Pesan")

    End Sub
End Class