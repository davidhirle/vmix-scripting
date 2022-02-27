'      IFTTT REQUEST
'       SEU EVENTO . LIVE
'    criado por David Hirle
'       (31) 9 9195-7275

Dim iftttRequest As New System.Net.WebClient
Dim streaming As String = "True"
Dim notStreaming As String = "False"
Dim lastStreamingStatus As String = notStreaming

While True
    dim VmixXML as new system.xml.xmldocument
    VmixXML.loadxml(API.XML)

    dim streamingStatus As String = VmixXML.selectSingleNode("/vmix/streaming").InnerText
    
    if streamingStatus <> lastStreamingStatus then
        if streamingStatus = streaming then
            Console.WriteLine("ENVIANDO COMANDO PARA API")
            Dim resultfalse As String = iftttRequest.DownloadString("https://maker.ifttt.com/trigger/NOMEDOTRIGGERAQUI/with/key/APIKEYAQUI")
        else
            Console.WriteLine("ENVIANDO COMANDO PARA API")
            Dim resultfalse As String = iftttRequest.DownloadString("https://maker.ifttt.com/trigger/NOMEDOTRIGGERAQUI/with/key/APIKEYAQUI")
        end If
        
        lastStreamingStatus = streamingStatus
    end If
Sleep(1000)
end While
