---
title: Export rapport naar PowerPoint zonder installatie van Aspose.Slides.ReportingService op de server
type: docs
weight: 120
url: /nl/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 
Aspose.Slides for Reporting Service kan gebruikt worden zonder installatie op een server. Deze aanpak is geschikt wanneer u export naar PowerPoint in uw toepassing wilt integreren, maar de toegang tot de service is beperkt.
{{% /alert %}} {{% alert color="primary" %}} 
Visual Studio‑oplossing die de aanpak illustreert, is te vinden [hier](attachments/10289165/10453062.zip).
{{% /alert %}} 
Het renderproces bestaat uit twee delen:

1. Render het rapport naar RPL met behulp van de Reporting Service Web Service. Zie meer informatie over Reporting Service Web Service [hier](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Render RPL naar PowerPoint met behulp van Aspose.Slides for Reporting service voor ReportViewer. De assembly bevindt zich in {Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **Hoe export naar PowerPoint te implementeren:** 
1) Maak de webservice‑proxy (zie de details [hier](http://technet.microsoft.com/en-us/library/ms155134.aspx)) en voeg deze toe aan uw oplossing.

2) Voeg een referentie toe naar Aspose.Slides.ReportingServices.dll voor ReportViewer 2010.

3) Gebruik deze klasse om de webservice‑proxy en Apose.Slides for Reporting Service te integreren

``` xml
 class PowerpointRenderer
{
/// <summary>
/// Haal de basis-URL van de XML-webservice op of stel deze in die de client opvraagt.
/// </summary>
/// <value>
/// De basis-URL van de XML-webservice die de client opvraagt. Standaard is dit System.String.Empty.
/// </value>
public string ReportingServiceUrl { get; set; }

/// <summary>
/// Haal de gebruikersnaam voor Reporting Service op of stel deze in.
/// </summary>
/// <value>
/// De gebruikersnaam.
/// </value>
public string Username { get; set; }

/// <summary>
/// Haal het wachtwoord voor Reporting Service op of stel dit in.
/// </summary>
/// <value>
/// Het wachtwoord.
/// </value>
public string Password { get; set; }

/// <summary>
/// Rendert het opgegeven rapport naar bestand.
/// </summary>
/// <param name="outputFileName">Naam van het uitvoerbestand.</param>
/// <param name="reportPath">Het rapportpad.</param>
/// <param name="format">Het uitvoerpresentatieformaat.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)
{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
// start renderproces
// hier kiezen we om te exporteren in PPT-formaat en geven de outputStream door
renderer.StartRendering(format, false);
int page = 1;
// deze lus doorloopt alle pagina's van het rapport
while (true)
{
using (MemoryStream rplStream = CreateRplStream(page, reportPath))
{
 // als rplStream leeg is, dan is het einde van het rapport bereikt
 if (rplStream.Length == 0)
 break;
 // voeg rapportpagina toe als dia aan het document
 renderer.RenderPage(rplStream);
}
page++;
}
// roep de finish-methode aan om onze nieuw gemaakte presentatie naar de outputstream te flushen
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
}
```

4) Nu kunt u het rapport exporteren via deze code:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 
Het exportproces hier gebruikt zachte pagina‑breuken, vergelijkbaar met Word of Excel, waardoor het resultaat kan afwijken van de presentatie die geëxporteerd werd met de standaardaanpak.
{{% /alert %}}