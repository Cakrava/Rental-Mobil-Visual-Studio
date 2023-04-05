Public Class form_cari_data_mobil

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dispose()
    End Sub


    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim i As Integer
        If e.ColumnIndex = 6 Then
            i = dgv.CurrentRow.Index
            form_peminjaman.idken.Text = CStr(dgv.Rows.Item(i).Cells(0).Value)
            form_peminjaman.merk.Text = CStr(dgv.Rows.Item(i).Cells(1).Value)
            form_peminjaman.harga.Text = CStr(dgv.Rows.Item(i).Cells(3).Value)
            form_peminjaman.txtStok.Text = CStr(dgv.Rows.Item(i).Cells(5).Value)

            Me.Dispose()
        End If
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        dgv.Columns.Clear()
        Call tampilData("select * from mobil where id_mobil like '%" & txtCari.Text & "%' or merk like '%" & txtCari.Text & "%' ")
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
        dgv.Columns(0).HeaderText = "ID Kendaraan"
        dgv.Columns(1).HeaderText = "Merk"
        dgv.Columns(2).HeaderText = "No Plat"
        dgv.Columns(3).HeaderText = "Harga/Hari"

        dgv.Columns(4).HeaderText = "Mesin"
        dgv.Columns(5).HeaderText = "Jumlah"



        dgv.Columns(0).Width = 90
        dgv.Columns(1).Width = 90
        dgv.Columns(2).Width = 90
        dgv.Columns(3).Width = 90
        dgv.Columns(4).Width = 90
        dgv.Columns(5).Width = 90
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
        Call tampilData("select * from mobil")
        Call setdgv()
        Call buatTombol()
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class