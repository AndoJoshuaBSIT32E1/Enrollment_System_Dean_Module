Imports System.Data.OleDb

Public Class frmdeans
    'Changing Profile Image
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg;*.jpeg"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
    'Changing CCS Image logo
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg;*.jpeg"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            cboSection.Text = ListView1.SelectedItems(0).SubItems(0).Text
            cboGradeL.Text = ListView1.SelectedItems(0).SubItems(1).Text
            cboSY.Text = ListView1.SelectedItems(0).SubItems(2).Text
            cboSemester.Text = ListView1.SelectedItems(0).SubItems(3).Text
            cboTCourse.Text = ListView1.SelectedItems(0).SubItems(4).Text
            cboStrand.Text = ListView1.SelectedItems(0).SubItems(5).Text
            txtDesc.Text = ListView1.SelectedItems(0).SubItems(6).Text
            cboAdviser.Text = ListView1.SelectedItems(0).SubItems(7).Text
        End If


    End Sub
    Private Sub loadSections()
        sql = "select * from qrySections"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        Dim x As ListViewItem
        ListView1.Items.Clear()
        Do While dr.Read = True
            x = New ListViewItem(dr("SectionName").ToString)
            x.SubItems.Add(dr("GradeLevel").ToString)
            x.SubItems.Add(dr("SY").ToString)
            x.SubItems.Add(dr("Semester").ToString)
            x.SubItems.Add(dr("Track").ToString)
            x.SubItems.Add(dr("Strand").ToString)
            x.SubItems.Add(dr("Desc").ToString)
            x.SubItems.Add(dr("ClassAdviser").ToString)
            ListView1.Items.Add(x)
        Loop
    End Sub

    Private Sub frmdeans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection()
        loadSections()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        cboSection.Text = False
        cboGradeL.Text = ""
        cboSY.Text = ""
        cboSemester.Text = ""
        cboTCourse.Text = ""
        cboStrand.Text = ""
        txtDesc.Clear()
        cboAdviser.Text = ""

    End Sub

    Private Sub cboSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSection.SelectedIndexChanged
        If Len(cboSection.Text) < 5 Then
            cboSection.Text = True
        End If

        If cboSection.Text = "" Then
            btnSave.Enabled = False
            btnEdit.Enabled = False
        Else
            btnSave.Enabled = True
        End If

        sql = "select * from tblSections where SectionName='" & cboSection.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            btnSave.Enabled = False
            btnEdit.Enabled = True
        Else
            btnEdit.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        sql = "Select * from qrySections where SectionName='" & cboSection.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            MsgBox("Already Exits!")
        Else
            sql = "Insert into tblSections([SectionName],[GradeLevel],[SYID],[TrackID],[StrandID],[TeacherID],[SubjID]) values 
                   ([@SectionName],[@GradeLevel],[@SYID],[@TrackID],[@StrandID],[@TeacherID],[@SubjID])"
            cmd = New OleDbCommand(sql, cn)
            With cmd
                .Parameters.AddWithValue("[@SectionName]", cboSection.Text)
                .Parameters.AddWithValue("[@GradeLevel]", cboGradeL.Text)
                .Parameters.AddWithValue("[@SYID]", cboSY.Text)
                .Parameters.AddWithValue("[@TrackID]", cboTCourse.Text)
                .Parameters.AddWithValue("[@StrandID]", cboStrand.Text)
                .Parameters.AddWithValue("[@SubjID]", txtDesc.Text)
                .Parameters.AddWithValue("[@TeacherID]", cboAdviser.Text)
                .ExecuteNonQuery()
            End With
            MsgBox("Successfully Saved!")
            loadSections()
            Erased()
        End If
    End Sub
    Private Sub Erased()
        cboAdviser.Text = ""
        cboGradeL.Text = ""
        cboSection.Text = ""
        cboSemester.Text = ""
        cboStrand.Text = ""
        cboSY.Text = ""
        cboTCourse.Text = ""
        txtDesc.Clear()
    End Sub
End Class