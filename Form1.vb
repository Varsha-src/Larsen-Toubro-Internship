Public Class Form1
    Dim writeflag As Integer = 0
    Private Sub Cmbcom_Click(sender As Object, e As EventArgs) Handles Cmbcom.Click
        Cmbcom.Text = ""
        Cmbcom.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Cmbcom.Items.Add(sp)
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnportset.Click
        update_status()
        If Cmbcom.Text = "" Then
            MessageBox.Show("Enter the COM No.", "Message")
        ElseIf cmbprtprty.Text = "" Then
            MessageBox.Show("Enter the BaudRate", "Message")
        ElseIf cmbprtbdrt.Text = "" Then
            MessageBox.Show("Enter the Parity", "Message")
        End If

        Panel4.Visible = False
        Panel3.Visible = False
    End Sub

    'Public Function Set_Port()
    '    ' MsgBox("Setcommport() called")
    '    If SerialPort1.IsOpen = True Then
    '        Me.SerialPort1.Close()
    '    End If

    '    With Me.SerialPort1
    '        .PortName = "COM4"
    '        .BaudRate = "9600"
    '        .Parity = IO.Ports.Parity.Even
    '        .StopBits = IO.Ports.StopBits.One
    '        .DtrEnable = True
    '    End With
    '    Try
    '        If SerialPort1.IsOpen = False Then
    '            Me.SerialPort1.Open()
    '        End If
    '    Catch ex As Exception
    '        Return 1
    '    End Try
    '    Threading.Thread.Sleep(100)
    '    ' MsgBox("Setcommport() end reached")
    '    Return 0
    'End Function

    Public Function Set_Communication_Port(ByVal Com_Port_No As String, ByVal Baud_Rate As String, ByVal Par As String)

        If SerialPort1.IsOpen = True Then
            Me.SerialPort1.Close()
        End If

        With Me.SerialPort1
            .PortName = Com_Port_No
            .BaudRate = Baud_Rate

            If Par = "None" Then
                .Parity = IO.Ports.Parity.None
                .StopBits = IO.Ports.StopBits.Two
            ElseIf Par = "Even" Then
                .Parity = IO.Ports.Parity.Even
                .StopBits = IO.Ports.StopBits.One
            ElseIf Par = "Odd" Then
                .Parity = IO.Ports.Parity.Odd
                .StopBits = IO.Ports.StopBits.One
            End If

            .DtrEnable = True
        End With
        Try
            If SerialPort1.IsOpen = False Then
                Me.SerialPort1.Open()
            End If
        Catch ex As Exception
            Return 1
        End Try
        Threading.Thread.Sleep(100)
        Return 0
    End Function

    Public Function checksum(cmdSendByteArray As Byte(), Count As Integer) As Integer

        Dim Index As Integer, BitIndex As Integer, Crc As Integer = &HFFFF, ArrayIndex As Integer = 0
        Crc = &HFFFF Xor cmdSendByteArray(0)
        ArrayIndex = 1
        For Index = 1 To Count
            For BitIndex = 0 To 7
                If (Crc And &H1) = &H1 Then
                    Crc >>= 1
                    Crc = Crc Xor &HA001
                Else
                    Crc >>= 1
                End If
            Next
            If Index <> Count Then
                Crc = Crc Xor cmdSendByteArray(Index)
            End If
        Next
        Return Crc
    End Function

    Dim RTCByteRecvArray(13) As Byte
    Dim ByteRecvArray(15) As Byte
    Dim response As MsgBoxResult
    Dim loopcount As Integer
    Dim CRC As Integer
    Dim UpperCRC As Integer
    Dim LowerCRC As Integer
    Dim slavhex As Integer
    Dim baudrate As Integer
    Dim parity As Integer
    Dim slv As Integer
    Dim rdsts As String
    Public Sub ReceiveMeterRTCBytes(RTCByteRecvArray As Byte(), Count As Integer)

        Try
            rdsts = "False"
            Array.Clear(RTCByteRecvArray, 0, 13)
            ReceiveMeterRTCvalues(RTCByteRecvArray, 13)
            Dim RecvArrayIndex As Byte
            RecvArrayIndex = checksum(RTCByteRecvArray, 13)
            If RecvArrayIndex <> 0 Then
                response = MsgBox("Modbus communication failed,Please Check the Connection!", vbCritical)
                rdsts = "False"

            Else
                ToolStripStatusLabel2.Text = "       "
                response = MsgBox("Read Success", vbInformation)
                rdsts = "True"
            End If
        Catch ex As Exception
            MsgBox("Error While Communicating with meter : " & ex.Message & vbLf & " Please check COM setting!!!")
        End Try
    End Sub

    Public Sub ReceiveMeterRTCvalues(RTCByteRecvArray As Byte(), Count As Integer)
        Try
            Dim ByteRecv As Byte() = New Byte(12) {}
            Dim RecvArrayIndex As Byte

            RecvArrayIndex = 0
            loopcount = 0
            Do

                Threading.Thread.Sleep(50)

                If Me.SerialPort1.BytesToRead >= 1 Then
                    ByteRecv(0) = 0
                    Me.SerialPort1.Read(ByteRecv, 0, 1)
                    RTCByteRecvArray(RecvArrayIndex) = ByteRecv(0)
                    RecvArrayIndex = RecvArrayIndex + 1
                    loopcount = 0
                    '  Return
                End If
                loopcount = loopcount + 1
            Loop Until RecvArrayIndex > (Count + 1) Or loopcount > 10
            If loopcount >= 12 Then
                response = MsgBox("Meter Not Communicating", vbCritical)
                Return

            End If
        Catch ex As Exception
            MsgBox("Error While Communicating with meter : " & ex.Message & vbLf & " Please check COM setting!!!")
        End Try

    End Sub

    Public Sub ReceiveMeterBytes(ByteRecvArray As Byte(), Count As Integer)

        Try
            rdsts = "False"
            Array.Clear(ByteRecvArray, 0, 15)
            ReceiveMetervalues(ByteRecvArray, Count)
            Dim RecvArrayIndex As Byte
            RecvArrayIndex = checksum(ByteRecvArray, Count)
            If RecvArrayIndex <> 0 Then
                response = MsgBox("Modbus communication failed,Please Check the Connection!", vbCritical)
                rdsts = "False"
            Else
                response = MsgBox("Update Success", vbInformation)
                rdsts = "True"
            End If
        Catch ex As Exception
            MsgBox("Error While Communicating with meter : " & ex.Message & vbLf & " Please check COM setting!!!")
        End Try
    End Sub

    Public Sub ReceiveMetervalues(ByteRecvArray As Byte(), Count As Integer)
        Try
            Dim ByteRecv As Byte() = New Byte(Count) {}
            Dim RecvArrayIndex As Byte
            RecvArrayIndex = 0
            loopcount = 0
            Do
                Threading.Thread.Sleep(50)
                If Me.SerialPort1.BytesToRead >= 1 Then
                    ByteRecv(0) = 0
                    Me.SerialPort1.Read(ByteRecv, 0, 1)
                    ByteRecvArray(RecvArrayIndex) = ByteRecv(0)
                    RecvArrayIndex = RecvArrayIndex + 1
                    loopcount = 0
                    '  Return
                End If
                loopcount = loopcount + 1
            Loop Until RecvArrayIndex > (Count + 1) Or loopcount > 10
            If loopcount >= 12 Then
                response = MsgBox("Meter Not Communicating", vbCritical)
                Return
            End If
        Catch ex As Exception
            MsgBox("Error While Communicating with meter : " & ex.Message & vbLf & " Please check COM setting!!!")
        End Try
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnread.Click
        ToolStripStatusLabel2.Text = "       reading..."
        TabPage1.Enabled = False
        tbslvid.Enabled = False
        'Panel4.Visible = True
        update_status()
        btnread.Enabled = False
        'Cursor = Cursors.WaitCursor
        Try
            If tbslvid.Text = "" Then
                MsgBox("Please enter Slave ID")
                btnread.Enabled = True
            Else
                If Set_Communication_Port(Cmbcom.Text, cmbprtbdrt.Text, cmbprtprty.Text) Then
                    MessageBox.Show("Meter Port is used by some other application !!")
                    btnread.Enabled = True
                    TabPage1.Enabled = True
                    tbslvid.Enabled = True
                    'Cursor = Cursors.Default
                    Exit Sub
                End If




                Dim Baud_rate As Integer
                Dim Par_ity As String

                'tbsetslvid.Text = tbslvid.Text
                If ReadRTCMeter() = True Then
                    ReceiveMeterRTCBytes(RTCByteRecvArray, 13)
                    SerialPort1.Close()
                    btnread.Enabled = True
                    If rdsts = "True" Then
                        If Not RTCByteRecvArray(4) = 0 Then
                            tbsetslvid.Text = RTCByteRecvArray(4)
                        End If

                        If RTCByteRecvArray(6) = 3 Then
                            Baud_rate = 1200
                            cmbbdrt.Text = Baud_rate
                        ElseIf RTCByteRecvArray(6) = 4 Then
                            Baud_rate = 2400
                            cmbbdrt.Text = Baud_rate
                        ElseIf RTCByteRecvArray(6) = 5 Then
                            Baud_rate = 4800
                            cmbbdrt.Text = Baud_rate
                        ElseIf RTCByteRecvArray(6) = 6 Then
                            Baud_rate = 9600
                            cmbbdrt.Text = Baud_rate
                        End If

                        If RTCByteRecvArray(8) = 0 Then
                            Par_ity = "None"
                            cmbsetprty.Text = Par_ity
                        ElseIf RTCByteRecvArray(8) = 1 Then
                            Par_ity = "Odd"
                            cmbsetprty.Text = Par_ity
                        ElseIf RTCByteRecvArray(8) = 2 Then
                            Par_ity = "Even"
                            cmbsetprty.Text = Par_ity
                        End If

                        Panel4.Visible = True
                        tbsetslvid.Enabled = False
                        cmbbdrt.Enabled = False
                        cmbsetprty.Enabled = False
                    End If

                End If
            End If
            btnread.Enabled = True
            Threading.Thread.Sleep(dly)

        Catch ex As Exception
            MsgBox("Error While Communicating with meter : " & ex.Message)
            btnread.Enabled = True
            Cursor = Cursors.Default
        End Try

        Cursor = Cursors.Default
        TabPage1.Enabled = True
        tbslvid.Enabled = True
        cbslvid.Checked = False
        cbbdrt.Checked = False
        cbprty.Checked = False
    End Sub

    Friend Function ReadRTCMeter() As Boolean
        'dly = Convert.ToInt32(tbdly.Text)
        Dim CRC As Integer
        Dim UpperCRC As Integer
        Dim LowerCRC As Integer

        Try
            Dim slavhex As Integer
            slavhex = Hex(Int(tbslvid.Text.Trim))
            Dim cmdrdByteArray As Byte() = New Byte(7) {}
            cmdrdByteArray(0) = slavhex
            cmdrdByteArray(1) = 3
            cmdrdByteArray(2) = 9
            cmdrdByteArray(3) = &H50
            cmdrdByteArray(4) = 0
            cmdrdByteArray(5) = 3
            CRC = checksum(cmdrdByteArray, 6)
            UpperCRC = CRC And &HFF00
            UpperCRC >>= 8
            LowerCRC = CRC And &HFF
            cmdrdByteArray(6) = LowerCRC
            cmdrdByteArray(7) = UpperCRC
            Me.SerialPort1.Write(cmdrdByteArray, 0, 8)
            Threading.Thread.Sleep(500)
            Return True
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message & vbLf & " Please check COM setting!!!")
            Return False
        End Try
        Return True
    End Function

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        'Panel1.Visible = False
        End
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnset.Click
        update_status()
        TabPage1.Enabled = False
        tbslvid.Enabled = False
        'Panel3.Visible = True
        Dim cmdByteArray As Byte() = New Byte(14) {}

        If cbslvid.Checked = False And cbbdrt.Checked = False And cbprty.Checked = False Then
            MsgBox("Please select parameter to program")
            TabPage1.Enabled = True
            tbslvid.Enabled = True
            Exit Sub
        ElseIf cbslvid.Checked = True And tbsetslvid.Text = "" Or cbbdrt.Checked = True And cmbbdrt.Text = "" Or cbprty.Checked = True And cmbsetprty.Text = "" Then
            MsgBox("Please enter the parameters!!")
            TabPage1.Enabled = True
            tbslvid.Enabled = True
            Exit Sub

        End If
        If tbslvid.Text = "" Then
            MsgBox("Please enter Slave ID")
            TabPage1.Enabled = True
            tbslvid.Enabled = True
            Exit Sub
        End If
        If Set_Communication_Port(Cmbcom.Text, cmbprtbdrt.Text, cmbprtprty.Text) Then
            MsgBox("Meter Port is used by some other application !!")
            btnread.Enabled = True
            TabPage1.Enabled = True
            tbslvid.Enabled = True
            Cursor = Cursors.Default
            Exit Sub
        End If

        slavhex = Hex(Int(tbslvid.Text.Trim))
        If cmbbdrt.Text = 1200 Then
            baudrate = 3
        ElseIf cmbbdrt.Text = 2400 Then
            baudrate = 4
        ElseIf cmbbdrt.Text = 4800 Then
            baudrate = 5
        ElseIf cmbbdrt.Text = 9600 Then
            baudrate = 6
        End If

        If cmbsetprty.Text = "None" Then
            parity = 0
        ElseIf cmbsetprty.Text = "Odd" Then
            parity = 1
        ElseIf cmbsetprty.Text = "Even" Then
            parity = 2
        End If

        slv = tbsetslvid.Text.Trim
        cmdByteArray(0) = slavhex
        cmdByteArray(1) = 16
        cmdByteArray(2) = 9
        cmdByteArray(3) = &H50
        cmdByteArray(4) = 0
        cmdByteArray(5) = 3
        cmdByteArray(6) = 6
        cmdByteArray(7) = 0
        cmdByteArray(8) = slv
        cmdByteArray(9) = 0
        cmdByteArray(10) = baudrate
        cmdByteArray(11) = 0
        cmdByteArray(12) = parity
        CRC = checksum(cmdByteArray, 13)
        UpperCRC = CRC And &HFF00
        UpperCRC >>= 8
        LowerCRC = CRC And &HFF
        cmdByteArray(13) = LowerCRC
        cmdByteArray(14) = UpperCRC
        Me.SerialPort1.Write(cmdByteArray, 0, 15)
        Threading.Thread.Sleep(dly)
        ReceiveMeterBytes(ByteRecvArray, 15)
        SerialPort1.Close()
        SerialPort1.Dispose()
        TabPage1.Enabled = True
        tbslvid.Enabled = True
        cbslvid.Checked = False
        cbbdrt.Checked = False
        cbprty.Checked = False
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles cbbdrt.CheckedChanged

        If cbbdrt.Checked = True Then
            cmbbdrt.Enabled = True
            btnset.Enabled = True
        Else
            cmbbdrt.Enabled = False
            btnset.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbslvid.CheckedChanged

        If cbslvid.Checked = True Then
            tbsetslvid.Enabled = True
            btnset.Enabled = True
        Else
            tbsetslvid.Enabled = False
            btnset.Enabled = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles cbprty.CheckedChanged

        If cbprty.Checked = True Then
            cmbsetprty.Enabled = True
            btnset.Enabled = True
        Else
            cmbsetprty.Enabled = False
            btnset.Enabled = False
        End If
    End Sub

    ' Dim response As MsgBoxResult
    Dim Recarray(20) As Byte
    Dim pwdarray(15) As Byte
    ' Dim Rarray As Byte()
    Dim Sid As Integer

    Dim dly As Integer = 1000

    Public Function Pwdcheck() As Boolean
        Dim CRC As Integer
        Dim UpperCRC As Integer
        Dim LowerCRC As Integer
        Dim pwdstr As String
        pwdstr = InputBox("Enter the Password for Writing CT & PT:- ")
        If pwdstr = "" Then
            Return False
        End If
        Dim pwdchars() = pwdstr.ToCharArray()
        Dim i, n, l, j As Integer
        Dim respl, resph As Byte
        n = pwdchars.Length
        Sid = Hex(Int(tbslvid.Text.Trim))
        Dim cmdByteArray As Byte() = New Byte(9 + n) {}
        cmdByteArray(0) = Sid
        cmdByteArray(1) = 16
        cmdByteArray(2) = &H9
        cmdByteArray(3) = &H4B
        cmdByteArray(4) = 0
        cmdByteArray(5) = 1
        cmdByteArray(6) = 6
        l = n + 6
        j = 0
        For i = 7 To l
            cmdByteArray(i) = "&H" & Hex(Asc(pwdchars(j)))
            j += 1
        Next

        CRC = checksum(cmdByteArray, 7 + n)
        UpperCRC = CRC And &HFF00
        UpperCRC >>= 8
        LowerCRC = CRC And &HFF
        cmdByteArray(7 + n) = LowerCRC
        cmdByteArray(8 + n) = UpperCRC
        Try
            Me.SerialPort1.Write(cmdByteArray, 0, 15)
            Threading.Thread.Sleep(dly)
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message)
            Return False
        End Try

        RecBytes(pwdarray, 15)
        'MsgBox("response array obtained!")
        If rdsts = "True" Then


            'resph = pwdarray(6)
            'respl = pwdarray(7)

            'If respl = 177 AndAlso resph = 243 Then         '243 and 177 is F3and B1 which is an expected Response 
            'MsgBox("correct response obtained!.....returning true")
            Return True
        End If

        'End If
        Return False

    End Function

    Public Function convertCT(recvbyte As Byte(), i As Integer) As Integer

        Dim Str3 As String
        Dim FinInt, digit, Len As Integer
        Dim l, m As Integer
        Dim b1, b2 As Byte

        l = i
        m = i + 1
        b1 = recvbyte(l)
        b2 = recvbyte(m)
        Str3 = b1.ToString("X") & b2.ToString("X")
        Dim chararr As Char() = Str3.ToCharArray()
        ' TextBox5.Text = Str3
        Len = chararr.Length
        For j = 0 To chararr.Length - 1
            Len -= 1
            If Asc(chararr(j)) >= Asc(0) And Asc(chararr(j)) <= Asc(9) Then
                digit = Asc(chararr(j)) - 48
            ElseIf Asc(chararr(j)) >= Asc("A") And Asc(chararr(j)) <= Asc("F") Then
                digit = Asc(chararr(j)) - 55
            ElseIf Asc(chararr(j)) >= Asc("a") And Asc(chararr(j)) <= Asc("f") Then
                digit = Asc(chararr(j)) - 87
            Else MsgBox("Not a Hexadecimal number....!")
            End If
            FinInt += digit * (16 ^ Len)
        Next
        'myChar = Str3.Chars(3)
        Return FinInt
    End Function

    Public Function convertPT(recvbyte As Byte(), i As Integer) As Integer
        Dim Str3 As String
        Dim FinInt, digit, Len As Integer
        Dim l, m, n As Integer
        Dim b1, b2, b3 As Byte

        l = i
        m = i + 1
        n = i + 2
        b1 = recvbyte(l)
        b2 = recvbyte(m)
        b3 = recvbyte(n)
        Str3 = b1.ToString("X") & b2.ToString("X") & b3.ToString("X")
        Dim chararr As Char() = Str3.ToCharArray()
        'TextBox6.Text = Str3
        Len = chararr.Length
        For j = 0 To chararr.Length - 1
            Len -= 1
            If Asc(chararr(j)) >= Asc(0) And Asc(chararr(j)) <= Asc(9) Then
                digit = Asc(chararr(j)) - 48
            ElseIf Asc(chararr(j)) >= Asc("A") And Asc(chararr(j)) <= Asc("F") Then
                digit = Asc(chararr(j)) - 55
            ElseIf Asc(chararr(j)) >= Asc("a") And Asc(chararr(j)) <= Asc("f") Then
                digit = Asc(chararr(j)) - 87
            Else MsgBox("Not a Hexadecimal number....!")
            End If
            FinInt += digit * (16 ^ Len)
        Next
        'myChar = Str3.Chars(3)
        Return FinInt
    End Function

    Dim wrtsts As String
    '''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub writeCT()
        wrtsts = "False"
        If Pwdcheck() = True Then

            Dim CRC As Integer
            Dim UpperCRC As Integer
            Dim LowerCRC As Integer
            Dim CTpl, CTph, CTsl, CTsh As Integer
            Dim CTp, CTs As Integer
            CTp = Int(TextBox1.Text)
            CTs = Int(TextBox2.Text)
            CTph = CTp And &HFF00
            CTph >>= 8
            CTpl = CTp And &HFF

            CTsh = CTs And &HFF00
            CTsh >>= 8
            CTsl = CTs And &HFF


            Dim cmdByteArray As Byte() = New Byte(17) {}
            cmdByteArray(0) = Sid
            cmdByteArray(1) = 16
            cmdByteArray(2) = &H8
            cmdByteArray(3) = &H0
            cmdByteArray(4) = 0
            cmdByteArray(5) = 4
            cmdByteArray(6) = 8
            cmdByteArray(7) = &H0
            cmdByteArray(8) = &H0
            cmdByteArray(9) = "&H" & Hex(CTph)
            cmdByteArray(10) = "&H" & Hex(CTpl)
            cmdByteArray(11) = &H0
            cmdByteArray(12) = &H0
            cmdByteArray(13) = "&H" & Hex(CTsh)
            cmdByteArray(14) = "&H" & Hex(CTsl)
            CRC = checksum(cmdByteArray, 15)
            UpperCRC = CRC And &HFF00
            UpperCRC >>= 8
            LowerCRC = CRC And &HFF
            cmdByteArray(15) = LowerCRC
            cmdByteArray(16) = UpperCRC
            Try
                Me.SerialPort1.Write(cmdByteArray, 0, 17)
                Threading.Thread.Sleep(dly)
                'Me.SerialPort1.ReadExisting()
                wrtsts = "True"
            Catch ex As Exception
                MessageBox.Show("Error:" + ex.Message)
                wrtsts = "False"
            End Try

        Else
            MessageBox.Show("Error:Invalid password for CT programming ")
            wrtsts = "False"
        End If


    End Sub

    Private Sub writePT()
        wrtsts = "False"
        If Pwdcheck() = True Then
            Dim CRC As Integer
            Dim UpperCRC As Integer
            Dim LowerCRC As Integer
            Dim PTpl, PTph, PTsl, PTsh As Integer
            Dim PTp, PTs As Integer
            PTp = Int(TextBox3.Text)
            PTs = Int(TextBox4.Text)
            PTph = PTp And &HFF00
            PTph >>= 8
            PTpl = PTp And &HFF

            PTsh = PTs And &HFF00
            PTsh >>= 8
            PTsl = PTs And &HFF


            Dim cmdByteArray As Byte() = New Byte(17) {}
            cmdByteArray(0) = Sid
            cmdByteArray(1) = 16
            cmdByteArray(2) = &H8
            cmdByteArray(3) = &H4
            cmdByteArray(4) = 0
            cmdByteArray(5) = 4
            cmdByteArray(6) = 8
            cmdByteArray(7) = &H0
            cmdByteArray(8) = &H0
            cmdByteArray(9) = "&H" & Hex(PTph)
            cmdByteArray(10) = "&H" & Hex(PTpl)
            cmdByteArray(11) = &H0
            cmdByteArray(12) = &H0
            cmdByteArray(13) = "&H" & Hex(PTsh)
            cmdByteArray(14) = "&H" & Hex(PTsl)
            CRC = checksum(cmdByteArray, 15)
            UpperCRC = CRC And &HFF00
            UpperCRC >>= 8
            LowerCRC = CRC And &HFF
            cmdByteArray(15) = LowerCRC
            cmdByteArray(16) = UpperCRC
            Try
                Me.SerialPort1.Write(cmdByteArray, 0, 17)
                Threading.Thread.Sleep(dly)
                'Me.SerialPort1.ReadExisting()
                wrtsts = "True"
            Catch ex As Exception
                MessageBox.Show("Error:" + ex.Message)
                wrtsts = "False"
            End Try
        Else
            MessageBox.Show("Error:Invalid password for PT programming ")
            wrtsts = "False"
        End If

    End Sub

    Private Sub WriteCTPT()
        wrtsts = "False"
        If Pwdcheck() = True Then

            Dim CRC As Integer
            Dim UpperCRC As Integer
            Dim LowerCRC As Integer
            Dim CTpl, CTph, CTsl, CTsh As Integer
            Dim CTp, CTs As Integer
            CTp = Int(TextBox1.Text)
            CTs = Int(TextBox2.Text)
            CTph = CTp And &HFF00
            CTph >>= 8
            CTpl = CTp And &HFF

            CTsh = CTs And &HFF00
            CTsh >>= 8
            CTsl = CTs And &HFF

            Dim PTpl, PTph, PTsl, PTsh As Integer
            Dim PTp, PTs As Integer
            PTp = Int(TextBox3.Text)
            PTs = Int(TextBox4.Text)
            PTph = PTp And &HFF00
            PTph >>= 8
            PTpl = PTp And &HFF

            PTsh = PTs And &HFF00
            PTsh >>= 8
            PTsl = PTs And &HFF



            Dim cmdByteArray As Byte() = New Byte(25) {}
            cmdByteArray(0) = Sid
            cmdByteArray(1) = 16
            cmdByteArray(2) = &H8
            cmdByteArray(3) = &H0
            cmdByteArray(4) = 0
            cmdByteArray(5) = 8
            cmdByteArray(6) = 16
            cmdByteArray(7) = &H0
            cmdByteArray(8) = &H0
            cmdByteArray(9) = "&H" & Hex(CTph)
            cmdByteArray(10) = "&H" & Hex(CTpl)
            cmdByteArray(11) = &H0
            cmdByteArray(12) = &H0
            cmdByteArray(13) = "&H" & Hex(CTsh)
            cmdByteArray(14) = "&H" & Hex(CTsl)
            cmdByteArray(15) = &H0
            cmdByteArray(16) = &H0
            cmdByteArray(17) = "&H" & Hex(PTph)
            cmdByteArray(18) = "&H" & Hex(PTpl)
            cmdByteArray(19) = &H0
            cmdByteArray(20) = &H0
            cmdByteArray(21) = "&H" & Hex(PTsh)
            cmdByteArray(22) = "&H" & Hex(PTsl)
            CRC = checksum(cmdByteArray, 23)
            UpperCRC = CRC And &HFF00
            UpperCRC >>= 8
            LowerCRC = CRC And &HFF
            cmdByteArray(23) = LowerCRC
            cmdByteArray(24) = UpperCRC
            Try
                Me.SerialPort1.Write(cmdByteArray, 0, 25)
                Threading.Thread.Sleep(dly)
                'Me.SerialPort1.ReadExisting()
                wrtsts = "True"
            Catch ex As Exception
                MessageBox.Show("Error:" + ex.Message)
                wrtsts = "False"
            End Try
        Else
            MessageBox.Show("Error:Invalid password for CT & PT programming ")
            wrtsts = "False"
        End If


    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''

    Function Readmeter() As Boolean
        Dim CRC As Integer
        Dim UpperCRC As Integer
        Dim LowerCRC As Integer


        Sid = Hex(Int(tbslvid.Text.Trim))

        Try

            Dim cmdByteArray As Byte() = New Byte(7) {}
            cmdByteArray(0) = Sid
            cmdByteArray(1) = 3
            cmdByteArray(2) = &H8
            cmdByteArray(3) = &H0
            cmdByteArray(4) = 0
            cmdByteArray(5) = 8

            CRC = checksum(cmdByteArray, 6)
            UpperCRC = CRC And &HFF00
            UpperCRC >>= 8
            LowerCRC = CRC And &HFF
            cmdByteArray(6) = LowerCRC
            cmdByteArray(7) = UpperCRC
            Me.SerialPort1.Write(cmdByteArray, 0, 8)
            Threading.Thread.Sleep(dly)
            Return True
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message & vbLf & " Please check COM setting!!!")
            Return False
        End Try
        Return True

    End Function

    Public Sub RecBytes(Recarray As Byte(), count As Integer)
        Try
            rdsts = "False"
            Array.Clear(Recarray, 0, count)
            RecValues(Recarray, count)
            Dim RecvArrayIndex As Integer
            RecvArrayIndex = checksum(Recarray, count)
            If RecvArrayIndex <> 0 Then
                response = MsgBox("Modbus communication failed,Please Check the Connection!", vbCritical)
                rdsts = "False"
            Else
                'response = MsgBox("Update Success", vbInformation)
                rdsts = "True"
            End If
        Catch ex As Exception
            MsgBox("Error While Communicating with meter : " & ex.Message & vbLf & " Please check COM setting!!!")
        End Try

    End Sub

    Public Sub RecValues(Recarray As Byte(), Count As Integer)

        Try
            Dim ByteRecv As Byte() = New Byte(Count) {}
            Dim RecvArrayIndex As Byte
            Dim loopcount As Integer
            RecvArrayIndex = 0
            loopcount = 0
            Do

                Threading.Thread.Sleep(50)

                If Me.SerialPort1.BytesToRead >= 1 Then
                    ByteRecv(0) = 0
                    Me.SerialPort1.Read(ByteRecv, 0, 1)
                    Recarray(RecvArrayIndex) = ByteRecv(0)
                    RecvArrayIndex = RecvArrayIndex + 1
                    loopcount = 0
                    '  Return
                End If
                loopcount = loopcount + 1
            Loop Until RecvArrayIndex > (Count + 1) Or loopcount > 10
            If loopcount >= 21 Then
                'response = MsgBox("Meter Not Communicating", vbCritical)
                Return
                ' If response = vbCritical Then
                'End If
            End If
        Catch ex As Exception
            MsgBox("Error While Communicating with meter : " & ex.Message & vbLf & " Please check COM setting!!!")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ctp As Integer
        Dim cts As Integer
        Dim ptp As Integer
        Dim pts As Integer
        'Panel1.Visible = True
        'Panel5.Visible = True
        TabPage2.Enabled = False
        tbslvid.Enabled = False
        ToolStripStatusLabel2.Text = "       Reading..."
        'Call Set_Communication_Port(Cmbcom.Text, cmbprtbdrt.Text, cmbprtprty.Text)
        If tbslvid.Text = "" Then
            MsgBox("Please enter Slave ID")
            TabPage2.Enabled = True
            tbslvid.Enabled = True
            Exit Sub
        End If

        If Set_Communication_Port(Cmbcom.Text, cmbprtbdrt.Text, cmbprtprty.Text) Then
            MessageBox.Show("Meter Port is used by some other application !!")
            TabPage2.Enabled = True
            tbslvid.Enabled = True
            Exit Sub
        End If
        If Readmeter() = True Then

            RecBytes(Recarray, 21)

            If rdsts = "True" Then
                Panel1.Visible = True
                Panel5.Visible = True
                ' ct and pt functions to be written
                ctp = convertCT(Recarray, 5)
                cts = convertCT(Recarray, 9)
                ptp = convertPT(Recarray, 12)
                pts = convertPT(Recarray, 16)

                LBLctp.Text = ": " & (ctp)
                LBLcts.Text = ": " & (cts)
                LBLptp.Text = ": " & (ptp)
                LBLpts.Text = ": " & (pts)
                MsgBox("Read Success", vbInformation)
            End If
        End If
        ToolStripStatusLabel2.Text = "       "
        TabPage2.Enabled = True
        tbslvid.Enabled = True
        Me.SerialPort1.Close()
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs)
        If CheckBox1.Checked = True AndAlso CheckBox2.Checked = True Then
            writeflag = 3
        ElseIf CheckBox1.Checked = True Then
            writeflag = 1
        ElseIf CheckBox2.Checked = True Then
            writeflag = 2
        Else
            'CheckBox1.Checked = False
            'CheckBox2.Checked = False
            MsgBox("Please select the checkbox to Write", vbCritical)
        End If
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        'Panel1.Visible = False
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub PortSettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Panel3.Visible = True
        Panel4.Visible = False
    End Sub

    Private Sub SlaveIdToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Panel3.Visible = False
        Panel4.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        'TextBox1.Enabled = True
        'TextBox2.Enabled = True
        'TextBox3.Enabled = False
        'TextBox4.Enabled = FALSE 
        If CheckBox1.Checked = True Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            Button8.Enabled = True
        Else
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            Button8.Enabled = False
            TextBox1.Text = ""
            TextBox2.Text = ""

        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        'TextBox1.Enabled = True
        'TextBox2.Enabled = True
        If CheckBox2.Checked = True Then
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            Button8.Enabled = True
        Else
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            Button8.Enabled = False
            TextBox3.Text = ""
            TextBox4.Text = ""
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        Panel4.Visible = False
        btnset.Enabled = False
        Panel1.Visible = False
        Panel5.Visible = False
        Button8.Enabled = False
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        TabPage2.Enabled = False
        tbslvid.Enabled = False
        If tbslvid.Text = "" Then
            MsgBox("Please enter Slave ID")
            TabPage2.Enabled = True
            tbslvid.Enabled = True
            Exit Sub
        End If

        If Set_Communication_Port(Cmbcom.Text, cmbprtbdrt.Text, cmbprtprty.Text) Then
            MessageBox.Show("Meter Port is used by some other application !!")
            TabPage2.Enabled = True
            tbslvid.Enabled = True
            Exit Sub
        End If
        If CheckBox1.Checked = True And CheckBox2.Checked = True Then
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then
                writeflag = 3
            End If
        ElseIf CheckBox1.Checked = True Then
            If TextBox1.Text <> "" And TextBox2.Text <> "" Then
                writeflag = 1
            End If
        ElseIf CheckBox2.Checked = True Then
            If TextBox3.Text <> "" And TextBox4.Text <> "" Then
                writeflag = 2
            End If
        End If
        Sid = Hex(Int(tbslvid.Text.Trim))
        ToolStripStatusLabel2.Text = "       Writing..."
        If writeflag = 1 Then
            writeCT()
        ElseIf writeflag = 2 Then
            writePT()
        ElseIf writeflag = 3 Then
            WriteCTPT()
        Else MsgBox("Please check the Option or Textbox ", vbCritical)
        End If
        If wrtsts = "True" Then
            RecBytes(Recarray, 8)
            If rdsts = "True" Then
                'ToolStripStatusLabel2.Text = "       Update Success"
                ToolStripStatusLabel2.Text = ""
                TabPage2.Enabled = True
                tbslvid.Enabled = True
                MsgBox("Update Success", vbInformation)
            End If
        End If

        TabPage2.Enabled = True
        tbslvid.Enabled = True
        writeflag = 0
    End Sub
    Public Sub update_status()
        Dim str As String
        str = tbslvid.Text & "     " & Cmbcom.Text & "   " & cmbprtbdrt.Text & "     " & cmbprtprty.Text
        ToolStripStatusLabel1.Text = str
        'ToolStripStatusLabel2.Text = 
    End Sub

    Private Sub PortSettingToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PortSettingToolStripMenuItem.Click
        Panel3.Visible = True
    End Sub
End Class
