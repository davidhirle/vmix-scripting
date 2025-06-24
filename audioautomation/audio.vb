dim audioinput1Message As String = "DIGITE O NÚMERO DA INPUT DE ÁUDIO 1:"
dim audioinput2Message As String = "DIGITE O NÚMERO DA INPUT DE ÁUDIO 2:"
dim audioinput3Message As String = "DIGITE O NÚMERO DA INPUT DE ÁUDIO 3:"
dim audioinput4Message As String = "DIGITE O NÚMERO DA INPUT DE ÁUDIO 4:"

dim caminput1Message As String = "DIGITE O NÚMERO DA INPUT DA CAMERA 1:"
dim caminput2Message As String = "DIGITE O NÚMERO DA INPUT DA CAMERA 2:"
dim caminput3Message As String = "DIGITE O NÚMERO DA INPUT DA CAMERA 3:"
dim caminput4Message As String = "DIGITE O NÚMERO DA INPUT DA CAMERA 4:"

dim audio1Inputbox As Object
dim audio2Inputbox As Object
dim audio3Inputbox As Object
dim audio4Inputbox As Object
dim cam1Inputbox As Object
dim cam2Inputbox As Object
dim cam3Inputbox As Object
dim cam4Inputbox As Object

audio1Inputbox = Microsoft.VisualBasic.Interaction.InputBox(audioinput1Message)
audio2Inputbox = Microsoft.VisualBasic.Interaction.InputBox(audioinput2Message)
audio3Inputbox = Microsoft.VisualBasic.Interaction.InputBox(audioinput3Message)
audio4Inputbox = Microsoft.VisualBasic.Interaction.InputBox(audioinput4Message)
cam1Inputbox = Microsoft.VisualBasic.Interaction.InputBox(caminput1Message)
cam2Inputbox = Microsoft.VisualBasic.Interaction.InputBox(caminput2Message)
cam3Inputbox = Microsoft.VisualBasic.Interaction.InputBox(caminput3Message)
cam4Inputbox = Microsoft.VisualBasic.Interaction.InputBox(caminput4Message)

dim audio1MeterF1 as Decimal
dim audio1MeterF2 as Decimal
dim audio1Sum as Decimal
dim audio2MeterF1 as Decimal
dim audio2MeterF2 as Decimal
dim audio2Sum as Decimal
dim audio3MeterF1 as Decimal
dim audio3MeterF2 as Decimal
dim audio3Sum as Decimal
dim audio4MeterF1 as Decimal
dim audio4MeterF2 as Decimal
dim audio4Sum as Decimal

Dim vmixAPIRequest As New System.Net.WebClient

While True

    dim VmixXML as new system.xml.xmldocument
        VmixXML.loadxml(API.XML)
            audio1MeterF1 = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + audio1Inputbox + """]/@meterF1").InnerText
            audio1MeterF2 = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + audio1Inputbox + """]/@meterF2").InnerText
            audio2MeterF1 = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + audio2Inputbox + """]/@meterF1").InnerText
            audio2MeterF2 = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + audio2Inputbox + """]/@meterF2").InnerText
            audio3MeterF1 = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + audio3Inputbox + """]/@meterF1").InnerText
            audio3MeterF2 = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + audio3Inputbox + """]/@meterF2").InnerText
            audio4MeterF1 = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + audio4Inputbox + """]/@meterF1").InnerText
            audio4MeterF2 = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + audio4Inputbox + """]/@meterF2").InnerText

            audio1Sum = (audio1MeterF1 + audio1MeterF2)/2
            audio2Sum = (audio2MeterF1 + audio2MeterF2)/2
            audio3Sum = (audio3MeterF1 + audio3MeterF2)/2
            audio4Sum = (audio4MeterF1 + audio4MeterF2)/2
            
            if audio1Sum > audio2Sum Then
                if audio1Sum > audio3Sum Then
                    if audio1Sum > audio4Sum Then
                        dim request As String = vmixAPIRequest.DownloadString("http://127.0.0.1:8088/api/?Function=CutDirect&Input="+cam1Inputbox+"")
                    end if
                end if
            end if

            if audio2Sum > audio1Sum Then
                if audio2Sum > audio3Sum Then
                    if audio2Sum > audio4Sum Then
                        dim request As String = vmixAPIRequest.DownloadString("http://127.0.0.1:8088/api/?Function=CutDirect&Input="+cam2Inputbox+"")
                    end if
                end if
            end if

            if audio3Sum > audio1Sum Then
                if audio3Sum > audio2Sum Then
                    if audio3Sum > audio4Sum Then
                        dim request As String = vmixAPIRequest.DownloadString("http://127.0.0.1:8088/api/?Function=CutDirect&Input="+cam3Inputbox+"")
                    end if
                end if
            end if

            if audio4Sum > audio1Sum Then
                if audio4Sum > audio2Sum Then
                    if audio4Sum > audio3Sum Then
                        dim request As String = vmixAPIRequest.DownloadString("http://127.0.0.1:8088/api/?Function=CutDirect&Input="+cam4Inputbox+"")
                    end if
                end if
            end if

Sleep(2500)

End While
