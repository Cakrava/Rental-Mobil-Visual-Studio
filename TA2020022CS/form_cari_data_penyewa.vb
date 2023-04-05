Public Class form_cari_data_penyewa
   
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dispose()
        End Sub


        Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
            Dim i As Integer
            If e.ColumnIndex = 3 Then
                i = dgv.CurrentRow.Index
                form_peminjaman.txtId.Text = CStr(dgv.Rows.Item(i).Cells(0).Value)
                form_peminjaman.txtNama.Text = CStr(dgv.Rows.Item(i).Cells(1).Value)
                form_peminjaman.txtnohp.Text = CStr(dgv.Rows.Item(i).Cells(2).Value)

                Me.Dispose()
            End If
        End Sub

        Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
            dgv.Columns.Clear()
            Call tampilData("select * from penyewa where id_penyewa like '%" & txtCari.Text & "%' or nama_penyewa like '%" & txtCari.Text & "%' ")
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
            dgv.Columns(0).HeaderText = "ID Penyewa"
            dgv.Columns(1).HeaderText = "Nama Penyewa"
            dgv.Columns(2).HeaderText = "Nomor HP"



            dgv.Columns(0).Width = 120
            dgv.Columns(1).Width = 145
            dgv.Columns(2).Width = 140
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
            Call tampilData("select * from penyewa")
            Call setdgv()
            Call buatTombol()
        End Sub
    End Class
