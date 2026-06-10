---
title: Jelentés exportálása PowerPointba az Aspose.Slides.ReportingService szerverre telepítése nélkül
type: docs
weight: 120
url: /hu/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}}
Aspose.Slides for Reporting Service használható telepítés nélkül egy szerveren. Ez a megközelítés akkor alkalmas, amikor az alkalmazásba be szeretnénk építeni a PowerPoint exportálást, de a szolgáltatás elérése korlátozott.
{{% /alert %}} {{% alert color="primary" %}}
A megközelítést bemutató Visual Studio megoldás megtalálható [itt](attachments/10289165/10453062.zip).
{{% /alert %}}

A renderelési folyamat két részből áll:

1. Jelentés renderelése RPL-be a Reporting Service Web Service használatával. További információk a Reporting Service Web Service-ről [itt](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. RPL renderelése PowerPointba az Aspose.Slides for Reporting service for ReportViewer használatával. Az assembly a {Aspose.Slides for Reporting Services home directory}\bin\RV2010 könyvtárban található
## **Hogyan valósítsuk meg a PowerPoint exportálást:**
1) Hozzon létre egy webszolgáltatás-proxy-t (a részletek [itt](http://technet.microsoft.com/en-us/library/ms155134.aspx)) és adja hozzá a megoldásához.
2) Adjon hozzá hivatkozást az Aspose.Slides.ReportingServices.dll-re a ReportViewer 2010-hez.
3) Használja ezt az osztályt a webszolgáltatás-proxy és az Aspose.Slides for Reporting Service integrálásához

``` xml
 class PowerpointRenderer
{
/// <summary>
/// Lekéri vagy beállítja a kliens által kért XML Web szolgáltatás alap URL-jét.
/// </summary>
/// <value>
/// Az XML Web szolgáltatás alap URL-je, amelyet a kliens kér. Alapértelmezett értéke a System.String.Empty.
/// </value>
public string ReportingServiceUrl { get; set; }

/// <summary>
/// Lekéri vagy beállítja a Reporting Service felhasználónevét.
/// </summary>
/// <value>
/// A felhasználónév.
/// </value>
public string Username { get; set; }

/// <summary>
/// Lekéri vagy beállítja a Reporting Service jelszavát.
/// </summary>
/// <value>
/// A jelszó.
/// </value>
public string Password { get; set; }

/// <summary>
/// Rendereli a megadott jelentést egy fájlba.
/// </summary>
/// <param name="outputFileName">A kimeneti fájl neve.</param>
/// <param name="reportPath">A jelentés útvonala.</param>
/// <param name="format">A kimeneti prezentáció formátuma.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)
{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
// kezdő renderelési folyamat
// itt PPT formátumban exportálunk, és megadjuk az outputStreamet
renderer.StartRendering(format, false);
int page = 1;
// ez a ciklus a jelentés összes oldalán végigiterál
while (true)
{
using (MemoryStream rplStream = CreateRplStream(page, reportPath))
{
 // ha az rplStream üres, akkor a jelentés vége lett
 if (rplStream.Length == 0)
 break;
 // a jelentés oldalát diaként adja hozzá a dokumentumhoz
 renderer.RenderPage(rplStream);
}
page++;
}
// befejező metódus hívása az újonnan létrehozott prezentáció kiírásához az output streambe
renderer.FinishRendering(pptSteam);
}
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

4) Most exportálhatja a jelentést ezzel a kóddal:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}}
Az exportálási folyamat itt puha oldal töréseket használ, hasonlóan a Word vagy Excel esetéhez, ezért az eredmény eltérhet a szokásos megközelítéssel exportált prezentációtól.
{{% /alert %}}