---
title: Exportera rapport till PowerPoint utan att installera Aspose.Slides.ReportingService på servern
type: docs
weight: 120
url: /sv/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 
Aspose.Slides for Reporting Service kan användas utan installation på en server. Detta tillvägagångssätt är lämpligt när du behöver integrera export till PowerPoint i din applikation men åtkomsten till tjänsten är begränsad.
{{% /alert %}} {{% alert color="primary" %}} 
Visual Studio‑lösning som illustrerar tillvägagångssättet finns [here](attachments/10289165/10453062.zip).
{{% /alert %}} 
Renderingsprocessen består av två delar:
1. Rendera rapport till RPL med Reporting Service Web Service. Se mer information om Reporting Service Web Service [here](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Rendera RPL till PowerPoint med Aspose.Slides for Reporting service för ReportViewer. Assemblén finns i {Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **Hur man implementerar export till PowerPoint:**
 1) Skapa webbserviceproxyn (se detaljerna [here](http://technet.microsoft.com/en-us/library/ms155134.aspx)) och lägg till den i din lösning.
 2) Lägg till en referens till Aspose.Slides.ReportingServices.dll för ReportViewer 2010.
 3) Använd den här klassen för att integrera webbserviceproxyn och Apose.Slides for Reporting Service
``` xml

 class PowerpointRenderer

{

/// <summary>
/// Hämtar eller anger grund‑URL:en för XML‑webbtjänsten som klienten begär.
/// </summary>
/// <value>
/// Grund‑URL:en för XML‑webbtjänsten som klienten begär. Standard är en System.String.Empty.
/// </value>
public string ReportingServiceUrl { get; set; }


/// <summary>
—Correction: the line should be:
/// Hämtar eller anger grund‑URL:en för XML‑webbtjänsten som klienten begär.
/// </summary>
/// <value>
/// Grund‑URL:en för XML‑webbtjänsten som klienten begär. Standard är en System.String.Empty.
/// </value>
public string ReportingServiceUrl { get; set; }




/// <summary>
/// Hämtar eller anger användarnamnet för Reporting Service.
/// </summary>
/// <value>
/// Användarnamnet.
/// </value>
public string Username { get; set; }
/// <summary>
/// Hämtar eller anger lösenordet för Reporting Service.
/// </summary>
/// <value>
/// Lösenordet.
/// </value>
public string Password { get; set; }

/// <summary>
/// Renderar den angivna rapporten till fil.
/// </summary>
/// <param name="outputFileName">Namn på utdatafilen.</param>
/// <param name="reportPath">Rapportens sökväg.</param>
/// <param name="format">Utdataformat för presentationen.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
//starta renderingsprocessen
//här väljer vi att exportera i PPT‑format och tillhandahåller outputStream
renderer.StartRendering(format, false);
int page = 1;
//denna loop itererar igenom alla sidor i rapporten
while (true)
{
using (MemoryStream rplStream = CreateRplStream(page, reportPath))
{
 //om rplStream är tom har vi nått slutet av rapporten
 if (rplStream.Length == 0)
 break;
 //lägg till rapportsida som bild i dokumentet
 renderer.RenderPage(rplStream);
}
page++;
}
//anropa finish‑metoden för att spola vår nyss skapade presentation till utströmmen
renderer.FinishRendering(pptSteam);
}
}

private MemoryStream CreateRplStream(int page, string reportPath)

{
ReportExecutionService _executionService = new ReportExecutionService();
_executionService.Url = ReportingServiceUrl + "/ReportExecution2005.asmx";
_executionService.Credentials = new System.Net.NetworkCredential(Username, Password, string.Empty);
string extension;
Warning[] warnings;
string[] streamIds;
string mimeType;
string encoding;
var executionInfo = _executionService.LoadReport(reportPath, null);
string deviceInfo = String.Format(
@"<DeviceInfo>
<StartPage>{0}</StartPage>
<EndPage>{0}</EndPage>
<SecondaryStreams>Embedded</SecondaryStreams>
</DeviceInfo>", page);
byte[] result = _executionService.Render("RPL", deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamIds);
return new MemoryStream(result);
}

```
 4) Nu kan du exportera rapporten med den här koden:
``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```
{{% alert color="primary" %}} 
Exportprocessen här använder mjuka sidbrytningar liknande Word eller Excel, så resultatet kan skilja sig från presentationen som exporterades med det vanliga tillvägagångssättet.
{{% /alert %}}