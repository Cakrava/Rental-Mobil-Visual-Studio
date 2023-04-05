Public Class form_peminjaman
    Dim subTotal As Double
    Dim totSel, jmlUang, Kembali As Double
    Dim i, nomor As Integer
    Dim idmobil, noFaktur As String
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
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

    Sub cetakFaktur()
     

        Dim CrLapBarang As New faktur
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from user,penyewa,mobil,pinjam,detail_pinjam where user.username=pinjam.username and mobil.id_mobil=detail_pinjam.id_mobil and penyewa.id_penyewa=pinjam.id_penyewa and pinjam.id_pinjam=detail_pinjam.id_pinjam and pinjam.id_pinjam='" & txtNofak.Text & "'"

        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "barang")
        CrLapBarang.SetDataSource(ds.Tables("barang"))
        inifakturyangbener.crv.ReportSource = CrLapBarang
        inifakturyangbener.WindowState = FormWindowState.Maximized
        inifakturyangbener.Show()
        kon.Close()

        ' 
    End Sub

    Sub tampilData()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select temp.id_mobil, merk, harga_perhari, lama, harga_perhari * lama as subtotal from temp join mobil on temp.id_mobil=mobil.id_mobil"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "data")
        dgv.DataSource = ds.Tables("data")
        kon.Close()

    End Sub
    Sub buatTombol()
        'Buat tombol hapus di dalam datagrid
        Dim btnHapus As New DataGridViewButtonColumn
        btnHapus.Name = "btnEdit"
        btnHapus.HeaderText = ""
        btnHapus.FlatStyle = FlatStyle.Popup
        btnHapus.DefaultCellStyle.ForeColor = Color.Red
        btnHapus.Text = "Hapus"
        btnHapus.Width = 50
        btnHapus.UseColumnTextForButtonValue = True
        dgv.Columns.Add(btnHapus)
    End Sub
    Sub setDgv()
        dgv.Columns(0).HeaderText = "ID Kendaraan"
        dgv.Columns(1).HeaderText = "Merk"
        dgv.Columns(2).HeaderText = "harga_perhari"
        dgv.Columns(3).HeaderText = "lama"
        dgv.Columns(4).HeaderText = "Sub Total"
        dgv.Columns(0).Width = 90
        dgv.Columns(1).Width = 90
        dgv.Columns(2).Width = 90
        dgv.Columns(3).Width = 90
        dgv.Columns(4).Width = 110
    End Sub
    Sub bersih()
        idken.Clear()
        merk.Clear()
        harga.Clear()
        qty.Clear()
        txtStok.Clear()
        txtSubTotal.Clear()
        txtId.Clear()
        txtNama.Clear()
        txtnohp.Clear()
    End Sub
    Sub hitungTotal()
        totSel = 0
        For x = 0 To dgv.Rows.Count - 1
            totSel = totSel + CDbl(dgv.Rows.Item(x).Cells(4).Value)
        Next x
        lblTotal.Text = Format(totSel, "Rp ###,###,##")
    End Sub

    Sub buatNoFaktur()
        Dim random As New Random()
        Dim usedNumbers As New List(Of Integer)()

        Dim kode As Integer = 0
        Dim faktur As Integer = kode + 1

        ' Membuat 100 angka acak
        For i As Integer = 1 To 100
            Dim angkaAcak As Integer
            Do
                ' Menghasilkan angka acak
                angkaAcak = random.Next(1000)
            Loop While usedNumbers.Contains(angkaAcak)

            ' Menyimpan angka acak yang telah digunakan
            usedNumbers.Add(angkaAcak)

            ' Menggunakan angka acak sebagai kode
            kode = angkaAcak
            faktur = kode + 1

            ' Lakukan sesuatu dengan kode dan cek di sini
        Next


        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select ifnull(max(right(id_pinjam,4)),0) as nourut from pinjam"
        cek = perintah.ExecuteReader
        cek.Read()
        If cek.HasRows Then
            nomor = CInt(cek.Item("nourut"))
            nomor = nomor + 1
            noFaktur = "MHV" + Format(faktur, "0000")
            txtNofak.Text = noFaktur
        End If
        kon.Close()

    End Sub

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        form_cari_data_penyewa.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        form_cari_data_mobil.Show()
    End Sub

    Private Sub btnbuatFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuatFaktur.Click
        txtNofak.Clear()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "delete from temp"
        perintah.ExecuteNonQuery()
        kon.Close()
        Call buatNoFaktur()
        dgv.Columns.Clear()
        Call tampilData()
        Call setDgv()
        Call buatTombol()
        Call hitungTotal()
        Button2.Enabled = True
        Button1.Enabled = True
        btnOk.Enabled = True
        Button3.Enabled = True


    End Sub

   
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'cek jika textbox qty kosong
        If String.IsNullOrEmpty(qty.Text) Then
            MessageBox.Show("Tambahkan data terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf txtStok.Text = "0" Then
            MessageBox.Show("Kendaraan tidak tersedia!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            'simpan data ke dalam tabel temp
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            perintah.CommandText = "insert into temp values('" & idken.Text & "','" & qty.Text & "','" & harga.Text & "')"
            perintah.ExecuteNonQuery()
            kon.Close()
            dgv.Columns.Clear()
            Call tampilData()
            Call setDgv()
            Call buatTombol()
            Call hitungTotal()
            Call bersih()
        End If
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If e.ColumnIndex = 5 Then
            i = dgv.CurrentRow.Index
            idmobil = CStr(dgv.Rows.Item(i).Cells(0).Value)
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            perintah.CommandText = "delete from temp where id_mobil='" & idmobil & "'"
            perintah.ExecuteNonQuery()
            kon.Close()

            dgv.Columns.Clear()
            Call tampilData()
            Call setDgv()
            Call buatTombol()
            Call hitungTotal()
        End If
    End Sub

   



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtId.Text = "" Then
            MessageBox.Show("Data Kurang Lengkap!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim random As New Random()
            Dim usedNumbers As New List(Of Integer)()

            Dim kode As Integer = 0
            Dim cek As Integer = kode + 1

            ' Membuat 100 angka acak
            For i As Integer = 1 To 100
                Dim angkaAcak As Integer
                Do
                    ' Menghasilkan angka acak
                    angkaAcak = random.Next(1000)
                Loop While usedNumbers.Contains(angkaAcak)

                ' Menyimpan angka acak yang telah digunakan
                usedNumbers.Add(angkaAcak)

                ' Menggunakan angka acak sebagai kode
                kode = angkaAcak
                cek = kode + 1

                ' Lakukan sesuatu dengan kode dan cek di sini
            Next


            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            perintah.CommandText = "insert into pinjam values('" & txtNofak.Text & "',now(),'" & userLogin & "','" & totSel & "','" & txtId.Text & "','" & cek & "')"
            perintah.ExecuteNonQuery()
            kon.Close()
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            perintah.CommandText = "insert into detail_pinjam (id_pinjam,id_mobil, lama, harga) select '" & txtNofak.Text & "', id_mobil, lama, harga from temp"
            perintah.ExecuteNonQuery()
            kon.Close()

            MsgBox("Data berhasil disimpan", MsgBoxStyle.Information, "informasi")

            Call bersih()
            Call cetakFaktur()

            txtNofak.Clear()

            lblTotal.Text = "0"
            btnbuatFaktur_Click(e, CType(AcceptButton, EventArgs))

        End If
    End Sub

    Private Sub txtStok_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStok.TextChanged


    End Sub
    Private Sub qty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles qty.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                btnOk_Click(e, CType(AcceptButton, EventArgs))
        End Select

    End Sub

    Private Sub form_peminjaman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Button1.Enabled = False
        btnOk.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub qty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qty.TextChanged
        subTotal = Val(harga.Text) * Val(qty.Text)
        txtSubTotal.Text = Format(subTotal, "Rp ###,###,##")
    End Sub
End Class