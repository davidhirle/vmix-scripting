'      vMix Multiview Status
'       SEU EVENTO . LIVE
'    criado por David Hirle
'       (31) 9 9195-7275

Do     
' Cria variável do XML e carrega o arquivo XML da API do vMix
dim VmixXML as new system.xml.xmldocument
VmixXML.loadxml(API.XML)

' Cria variáveis isolando os Nodes XML
dim Live As XmlNode = VmixXML.selectSingleNode("/vmix/streaming")
dim Recording As XmlNode = VmixXML.selectSingleNode("/vmix/recording")
dim External As XmlNode = VmixXML.selectSingleNode("/vmix/external")
dim Fullscreen As XmlNode = VmixXML.selectSingleNode("/vmix/fullscreen")
dim Multicorder As XmlNode = VmixXML.selectSingleNode("/vmix/multiCorder")
dim Overlay1 As XmlNode = VmixXML.selectSingleNode("/vmix/overlays/overlay[@number=""1""]")
dim Overlay1Prv As XmlNode = VmixXML.selectSingleNode("/vmix/overlays/overlay[@number=""1""]/@preview")
dim Overlay2 As XmlNode = VmixXML.selectSingleNode("/vmix/overlays/overlay[@number=""2""]")
dim Overlay2Prv As XmlNode = VmixXML.selectSingleNode("/vmix/overlays/overlay[@number=""2""]/@preview")
dim Overlay3 As XmlNode = VmixXML.selectSingleNode("/vmix/overlays/overlay[@number=""3""]")
dim Overlay3Prv As XmlNode = VmixXML.selectSingleNode("/vmix/overlays/overlay[@number=""3""]/@preview")
dim Overlay4 As XmlNode = VmixXML.selectSingleNode("/vmix/overlays/overlay[@number=""4""]")
dim Overlay4Prv As XmlNode = VmixXML.selectSingleNode("/vmix/overlays/overlay[@number=""4""]/@preview")

' Muda a imagem do status Live
If Live.InnerText = "False" Then        'Se não estou transmitindo, então:
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\no-live.png", 100, "Live.Source")
else
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\live.png", 100, "Live.Source")
end If

' Muda a imagem do status Recording
If Recording.InnerText = "False" Then        'Se não estou gravando, então:
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\no-recording.png", 100, "Recording.Source")
else
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\recording.png", 100, "Recording.Source")
end If

' Muda a imagem do status External
If External.InnerText = "False" Then        'Se não estou com a saída externa ligada, então:
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\no-external.png", 100, "External.Source")
else
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\external.png", 100, "External.Source")
end If

' Muda a imagem do status Fullscreen
If Fullscreen.InnerText = "False" Then        'Se não estou com a saída externa ligada, então:
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\no-fullscreen.png", 100, "Fullscreen.Source")
else
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\fullscreen.png", 100, "Fullscreen.Source")
end If

' Muda a imagem do status Multicorder
If MultiCorder.InnerText = "False" Then        'Se não estou com com a gravação múltipla ligada, então:
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\no-multicorder.png", 100, "Multicorder.Source")
else
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\multicorder.png", 100, "Multicorder.Source")
end If

' Muda a imagem do status Overlay1
If Overlay1.InnerText = "" Then
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\1.png", 100, "Overlay1.Source")
else
    If Overlay1Prv Is Nothing Then
        API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\1-pgm.png", 100, "Overlay1.Source")
    else
        API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\1-prv.png", 100, "Overlay1.Source")
    end If
end If

' Muda a imagem do status Overlay2
If Overlay2.InnerText = "" Then
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\2.png", 100, "Overlay2.Source")
else
    If Overlay2Prv Is Nothing Then
        API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\2-pgm.png", 100, "Overlay2.Source")
    else
        API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\2-prv.png", 100, "Overlay2.Source")
    end If
end If

' Muda a imagem do status Overlay3
If Overlay3.InnerText = "" Then
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\3.png", 100, "Overlay3.Source")
else
    If Overlay3Prv Is Nothing Then
        API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\3-pgm.png", 100, "Overlay3.Source")
    else
        API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\3-prv.png", 100, "Overlay3.Source")
    end If
end If

' Muda a imagem do status Overlay4
If Overlay4.InnerText = "" Then
    API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\4.png", 100, "Overlay4.Source")
else
    If Overlay4Prv Is Nothing Then
        API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\4-pgm.png", 100, "Overlay4.Source")
    else
        API.Function("SetImage", "multiviewstatus.gtzip", "C:\vmix-assets\images\overlay\4-prv.png", 100, "Overlay4.Source")
    end If
end If

' Encerra repetição do script
Loop While True
