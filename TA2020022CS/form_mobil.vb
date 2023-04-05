Public Class form_mobil

   

    Private Sub keluar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
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
    Sub bersih()
        txtId.Clear()
        txtNama.Clear()
        txtharga.Clear()
        txtjumlah.Clear()
        txtplat.Clear()
        txtmesin.Clear()
    End Sub

    Sub setdgv()
        'mengatur judul kolom
        dgv.Columns(0).HeaderText = "ID Mobil"
        dgv.Columns(1).HeaderText = "Merk"
        dgv.Columns(2).HeaderText = "Plat"
        dgv.Columns(3).HeaderText = "Harga"
        dgv.Columns(4).HeaderText = "Mesin"
        dgv.Columns(5).HeaderText = "Jumlah"


        dgv.Columns(0).Width = 60
        dgv.Columns(1).Width = 80
        dgv.Columns(2).Width = 85
        dgv.Columns(3).Width = 50
        dgv.Columns(4).Width = 50
        dgv.Columns(5).Width = 50
       
    End Sub
    Sub buatTombol()
        'buat tombol edit di dlm dgv
        Dim btnUpdate As New DataGridViewButtonColumn
        btnUpdate.Name = "btnUpdate"
        btnUpdate.HeaderText = ""
        btnUpdate.FlatStyle = FlatStyle.Popup
        btnUpdate.DefaultCellStyle.BackColor = Color.Aqua
        btnUpdate.Text = "Edit"
        btnUpdate.Width = 50
        btnUpdate.UseColumnTextForButtonValue = True
        dgv.Columns.Add(btnUpdate)

        'buat tombol hapus didalam dgv
        Dim btnHapus As New DataGridViewButtonColumn
        btnHapus.Name = "btnHapus"
        btnHapus.HeaderText = ""
        btnHapus.FlatStyle = FlatStyle.Popup
        btnHapus.DefaultCellStyle.BackColor = Color.Red
        btnHapus.Text = "Hapus"
        btnHapus.Width = 50
        btnHapus.UseColumnTextForButtonValue = True
        dgv.Columns.Add(btnHapus)
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button1.Enabled = True
        txtId.Focus()
        Call bersih()
    End Sub

    Private Sub form_mobil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button2.Enabled = False
        dgv.Columns.Clear()
        Call tampilData("select id_mobil, merk, no_plat, harga_perhari,mesin, jumlah from mobil")
        Call setdgv()
        Call buatTombol()
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "insert into mobil (id_mobil, merk, no_plat, harga_perhari, mesin, jumlah) values ('" & txtId.Text & "','" & txtNama.Text & "','" & txtplat.Text & "','" & txtharga.Text & "','" & txtmesin.Text & "','" & txtjumlah.Text & "')"
        perintah.ExecuteNonQuery()
        kon.Close()
        Call bersih()
        form_mobil_Load(e, CType(AcceptButton, EventArgs))

        MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "Informasi")


    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        dgv.Columns.Clear()
        Call tampilData("select id_mobil,merk, no_plat, harga_perhari,mesin,jumlah from mobil where id_mobil like '%" & txtCari.Text & "%' or merk like '%" & txtCari.Text & "%' ")
        Call setdgv()
        Call buatTombol()

    End Sub


    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim i As Integer
        Dim id As String
        i = dgv.CurrentRow.Index
        id = CStr(dgv.Rows.Item(i).Cells(0).Value)
        'jika diklik tombol Update
        If e.ColumnIndex = 6 Then
            txtId.Text = id
            txtNama.Text = CStr(dgv.Rows.Item(i).Cells(1).Value)
            txtplat.Text = CStr(dgv.Rows.Item(i).Cells(2).Value)
            txtharga.Text = CStr(dgv.Rows.Item(i).Cells(3).Value)
            txtmesin.Text = CStr(dgv.Rows.Item(i).Cells(4).Value)
            txtjumlah.Text = CStr(dgv.Rows.Item(i).Cells(5).Value)
            Button2.Enabled = True
            Button1.Enabled = False

        End If
        'jika diklik tombol hapus
        If e.ColumnIndex = 7 Then
            Dim x As Byte
            x = CByte(MsgBox("Hapus data dengan ID " + id, CType(MsgBoxStyle.Critical + vbYesNo, MsgBoxStyle), "Konfirmasi"))
            If x = vbYes Then
                kon.Open()
                perintah.Connection = kon
                perintah.CommandType = CommandType.Text
                perintah.CommandText = "delete from mobil where id_mobil = '" & id & "'"
                perintah.ExecuteNonQuery()
                kon.Close()

                'panggil even form load
                form_mobil_Load(e, CType(AcceptButton, EventArgs))
            End If
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "update mobil set merk='" & txtNama.Text & "', no_plat='" & txtplat.Text & "', harga_perhari='" & txtharga.Text & "', mesin='" & txtmesin.Text & "', jumlah='" & txtjumlah.Text & "' where id_mobil='" & txtId.Text & "'"
        perintah.ExecuteNonQuery()
        kon.Close()
        Call bersih()
        form_mobil_Load(e, CType(AcceptButton, EventArgs))

        MsgBox("Data Berhasil Diupdate", MsgBoxStyle.Information, "Informasi")
    End Sub

    Private Sub txtId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtId.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                kon.Open()
                perintah.Connection = kon
                perintah.CommandType = CommandType.Text
                perintah.CommandText = "select * from mobil where id_mobil = '" & txtId.Text & "'"
                cek = perintah.ExecuteReader
                cek.Read()
                If cek.HasRows Then
                    MsgBox("ID Kendaraan sudah ada ", MsgBoxStyle.Information, "Pesan")
                    txtId.Clear()
                    txtId.Focus()
                Else
                    txtNama.Focus()

                End If
                kon.Close()
        End Select


    End Sub
End Class