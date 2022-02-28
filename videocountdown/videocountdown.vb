'      vMix Video Countdown
'       SEU EVENTO . LIVE
'    criado por David Hirle
'       (31) 9 9195-7275

While True
    dim VmixXML as new system.xml.xmldocumentw
    VmixXML.loadxml(API.XML)

    dim ActiveNumber As XmlNode = VmixXML.selectSingleNode("/vmix/active")
    dim ActiveNumberString As String = ActiveNumber.InnerText
    dim ActiveInputType As String = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + ActiveNumberString + """]/@type").InnerText

    if ActiveInputType = "Video" Then
        dim VideoDuration As Integer = VmixXML.selectSingleNode("/vmix/inputs/input[@number="""+ActiveNumberString+"""]/@duration").InnerText
        dim VideoPosition As Integer = VmixXML.selectSingleNode("/vmix/inputs/input[@number="""+ActiveNumberString+"""]/@position").InnerText
        dim FormattedCountDown As String = ""
        
        While VideoPosition < VideoDuration
            VideoPosition = VmixXML.selectSingleNode("/vmix/inputs/input[@number="""+ActiveNumberString+"""]/@position").InnerText
            dim VideoPositionCountDown as TimeSpan = (TimeSpan.FromSeconds(VideoDuration / 1000) - TimeSpan.FromSeconds(VideoPosition / 1000))
            
            if VideoPositionCountDown.Hours > 0 then
                FormattedCountDown += VideoPositionCountDown.Hours.ToString().PadLeft(2, "0") + ":"
            end if
            FormattedCountDown += VideoPositionCountDown.Minutes.ToString().PadLeft(2, "0") + ":" 
            FormattedCountDown += VideoPositionCountDown.Seconds.ToString().PadLeft(2, "0")

            Input.Find("position.gtzip").Text("Position.Text") = FormattedCountDown

            ActiveNumber = VmixXML.selectSingleNode("/vmix/active")
            ActiveNumberString = ActiveNumber.InnerText
            ActiveInputType = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + ActiveNumberString + """]/@type").InnerText

            VideoDuration = VmixXML.selectSingleNode("/vmix/inputs/input[@number=""" + ActiveNumberString + """]/@duration").InnerText
            FormattedCountDown = ""
            
            sleep(300)
            VmixXML.loadxml(API.XML)
        End While
    end If
    
    Input.Find("position.gtzip").Text("Position.Text") = "00:00"
    Console.WriteLine("No Video Input... Waiting 1000ms")
    sleep(1000)
End While
