Public Class user

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "insert into user (username, nama, password,email) values ('" & txtUser.Text & "','" & txtNama.Text & "','" & txtPassword.Text & "','" & txtEmail.Text & "')"
        perintah.ExecuteNonQuery()
        kon.Close()
        Call bersih()
        user_Load(e, CType(AcceptButton, EventArgs))

        MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "Informasi")

    End Sub

    
    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        dgv.Columns.Clear()

        Call tampilData("select username,nama, password,email from user where username like '%" & txtCari.Text & "%' or nama like '%" & txtCari.Text & "%' ")
        Call setdgv()
        Call buatTombol()
    End Sub
   
    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        btnSimpan.Enabled = True
        txtUser.Focus()
        Call bersih()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "update user set nama='" & txtNama.Text & "', email='" & txtEmail.Text & "', password='" & txtPassword.Text & "' where username='" & txtUser.Text & "'"
        perintah.ExecuteNonQuery()
        kon.Close()
        Call bersih()
        user_load(e, CType(AcceptButton, EventArgs))

        MsgBox("Data Berhasil Diupdate", MsgBoxStyle.Information, "Informasi")

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim i As Integer
        Dim id As String
        i = dgv.CurrentRow.Index
        id = CStr(dgv.Rows.Item(i).Cells(0).Value)
        'jika diklik tombol Update
        If e.ColumnIndex = 4 Then
            txtUser.Text = id
            txtNama.Text = CStr(dgv.Rows.Item(i).Cells(1).Value)
            txtPassword.Text = CStr(dgv.Rows.Item(i).Cells(2).Value)
            txtEmail.Text = CStr(dgv.Rows.Item(i).Cells(3).Value)

            btnUpdate.Enabled = True
            btnSimpan.Enabled = False

        End If
        'jika diklik tombol hapus
        If e.ColumnIndex = 5 Then
            Dim x As Byte
            x = CByte(MsgBox("Hapus data dengan ID " + id, CType(MsgBoxStyle.Critical + vbYesNo, MsgBoxStyle), "Konfirmasi"))
            If x = vbYes Then
                kon.Open()
                perintah.Connection = kon
                perintah.CommandType = CommandType.Text
                perintah.CommandText = "delete from user where username = '" & id & "'"
                perintah.ExecuteNonQuery()
                kon.Close()

                'panggil even form load
                user_Load(e, CType(AcceptButton, EventArgs))
            End If
        End If

    End Sub

    Private Sub user_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnUpdate.Enabled = False
        btnSimpan.Enabled = False
        dgv.Columns.Clear()
        Call tampilData("select username, nama, password,email from user")
        Call setdgv()
        Call buatTombol()
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
    Sub setdgv()
        'mengatur judul kolom
        dgv.Columns(0).HeaderText = "Username"
        dgv.Columns(1).HeaderText = "Nama"
        dgv.Columns(2).HeaderText = "Password"
        dgv.Columns(2).HeaderText = "Email"


        dgv.Columns(0).Width = 100
        dgv.Columns(1).Width = 100
        dgv.Columns(2).Width = 100
        dgv.Columns(3).Width = 100


    End Sub
    Sub bersih()
        txtUser.Clear()
        txtNama.Clear()
        txtPassword.Clear()
        txtEmail.Clear()
    End Sub
End Class