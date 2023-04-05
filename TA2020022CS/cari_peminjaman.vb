Public Class cari_peminjaman

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dispose()
        form_pengembalian.Button5.Enabled = True
    End Sub


    

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        dgv.Columns.Clear()
        Call tampilData("SELECT pinjam.id_pinjam, penyewa.id_penyewa, penyewa.nama_penyewa, penyewa.nohp,pinjam.id_acak FROM pinjam JOIN penyewa ON pinjam.id_penyewa = penyewa.id_penyewa WHERE pinjam.id_pinjam LIKE '%" & txtCari.Text & "%' OR penyewa.nama_penyewa LIKE '%" & txtCari.Text & "%'")
        Call setdgv()
        Call buatTombol()
    End Sub
    Sub buatTombol()
        'buat tombol pilih di dlm dgv
        Dim btnPilih As New DataGridViewButtonColumn
        btnPilih.Name = "btnPilih"
        btnPilih.HeaderText = ""
        btnPilih.FlatStyle = FlatStyle.Popup
        btnPilih.DefaultCellStyle.ForeColor = Color.DarkViolet
        btnPilih.Text = "Pilih"
        btnPilih.Width = 50
        btnPilih.UseColumnTextForButtonValue = True
        dgv.Columns.Add(btnPilih)

    End Sub
    Sub setdgv()
        'mengatur judul kolom
        dgv.Columns(0).HeaderText = "No Penyewaan"
        dgv.Columns(1).HeaderText = "Id Penyewa"
        dgv.Columns(2).HeaderText = "Nama Penyewa"
        dgv.Columns(3).HeaderText = "No Penyewa"
        dgv.Columns(4).HeaderText = "ID acak"

        dgv.Columns(0).Width = 70
        dgv.Columns(1).Width = 90
        dgv.Columns(2).Width = 90
        dgv.Columns(3).Width = 90
        dgv.Columns(4).Width = 60
       
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

    Private Sub form_cari_data_mobil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv.Columns.Clear()
        Call tampilData("SELECT pinjam.id_pinjam, penyewa.id_penyewa, penyewa.nama_penyewa, penyewa.nohp,pinjam.id_acak FROM pinjam JOIN penyewa ON pinjam.id_penyewa = penyewa.id_penyewa")
        Call setdgv()
        Call buatTombol()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim i As Integer
        If e.ColumnIndex = 5 Then
            i = dgv.CurrentRow.Index
            form_pengembalian.txtNofak.Text = CStr(dgv.Rows.Item(i).Cells(0).Value)
            form_pengembalian.txtId.Text = CStr(dgv.Rows.Item(i).Cells(1).Value)
            form_pengembalian.txtNama.Text = CStr(dgv.Rows.Item(i).Cells(2).Value)
            form_pengembalian.txtnohp.Text = CStr(dgv.Rows.Item(i).Cells(3).Value)
            form_pengembalian.idacak.Text = CStr(dgv.Rows.Item(i).Cells(4).Value)
            form_pengembalian.Button3.Enabled = True
            form_pengembalian.Button5.Enabled = True
            Me.Dispose()

        End If
    End Sub
End Class