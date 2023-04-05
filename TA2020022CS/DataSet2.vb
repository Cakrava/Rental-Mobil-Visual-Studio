Partial Class DataSet2
    Partial Class lap_kembaliDataTable

    End Class

    Partial Class lap_pinjamDataTable

        Private Sub lap_pinjamDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.tglColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
