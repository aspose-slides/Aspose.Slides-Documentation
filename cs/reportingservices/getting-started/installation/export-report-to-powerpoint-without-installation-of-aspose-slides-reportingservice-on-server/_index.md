---
title: Exportovat zprávu do PowerPointu bez instalace Aspose.Slides.ReportingService na serveru
type: docs
weight: 120
url: /cs/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Service lze použít bez instalace na serveru. Tento přístup je vhodný, když potřebujete integrovat export do PowerPoint ve své aplikaci, ale přístup ke službě je omezen.

{{% /alert %}} {{% alert color="primary" %}} 

Ukázkové řešení Visual Studio, které ilustruje tento přístup, najdete [zde](attachments/10289165/10453062.zip).

{{% /alert %}} 

Proces renderování se skládá ze dvou částí:

1. Vykreslete zprávu do RPL pomocí Reporting Service Web Service. Další informace o Reporting Service Web Service najdete [zde](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Vykreslete RPL do PowerPoint pomocí Aspose.Slides for Reporting Service pro ReportViewer. Assemblie se nachází v {Aspose.Slides for Reporting Services home directory}\bin\RV2010  

## **Jak implementovat export do PowerPointu:**
 1) Vytvořte proxy webové služby (více podrobností [zde](http://technet.microsoft.com/en-us/library/ms155134.aspx)) a přidejte ji do svého řešení.

 2) Přidejte referenci na Aspose.Slides.ReportingServices.dll pro ReportViewer 2010.

 3) Použijte tuto třídu k integraci proxy webové služby a Aspose.Slides for Reporting Service

``` xml
 class PowerpointRenderer
{
/// <summary>
/// Získá nebo nastaví základní URL XML webové služby, kterou klient požaduje.
/// </summary>
/// <value>
/// Základní URL XML webové služby, kterou klient požaduje. Výchozí hodnota je System.String.Empty.
/// </value>
public string ReportingServiceUrl { get; set; }

/// <summary>
/// Získá nebo nastaví uživatelské jméno pro Reporting Service.
/// </summary>
/// <value>
/// Uživatelské jméno.
/// </value>
public string Username { get; set; }

/// <summary>
/// Získá nebo nastaví heslo pro Reporting Service.
/// </summary>
/// <value>
/// Heslo.
/// </value>
public string Password { get; set; }

/// <summary>
/// Vykreslí zadaný report do souboru.
/// </summary>
/// <param name="outputFileName">Název výstupního souboru.</param>
/// <param name="reportPath">Cesta k reportu.</param>
/// <param name="format">Formát výstupní prezentace.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)
{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
//spustit proces renderování
//zde volíme export ve formátu PPT a poskytujeme výstupní proud
renderer.StartRendering(format, false);
int page = 1;
//tento cyklus prochází všechny stránky reportu
while (true)
{
using (MemoryStream rplStream = CreateRplStream(page, reportPath))
{
 //pokud je rplStream prázdný, pak jsme dosáhli konce reportu
if (rplStream.Length == 0)
break;
//přidat stránku reportu jako snímek do dokumentu
renderer.RenderPage(rplStream);
}
page++;
}
//volá metodu FinishRendering pro zapsání nově vytvořené prezentace do výstupního proudu
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

 4) Nyní můžete exportovat zprávu pomocí tohoto kódu:

``` xml
 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);
```

{{% alert color="primary" %}} 

Exportní proces zde používá měkké zalomení stránky podobně jako ve Wordu nebo Excelu, takže výsledek se může lišit od prezentace, která byla exportována standardním přístupem.

{{% /alert %}}