---
title: Eksport raportu do PowerPoint bez instalacji Aspose.Slides.ReportingService na serwerze
type: docs
weight: 120
url: /pl/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Service można używać bez instalacji na serwerze. To podejście jest odpowiednie, gdy trzeba zintegrować eksport do PowerPoint w aplikacji, ale dostęp do usługi jest ograniczony.

{{% /alert %}} {{% alert color="primary" %}} 

Rozwiązanie Visual Studio ilustrujące to podejście można znaleźć [tutaj](attachments/10289165/10453062.zip).

{{% /alert %}} 

Proces renderowania składa się z dwóch części:

1. Renderowanie raportu do RPL przy użyciu Reporting Service Web Service. Więcej informacji o Reporting Service Web Service znajdziesz [tutaj](http://technet.microsoft.com/en-us/library/ms152787.aspx).
2. Renderowanie RPL do PowerPoint przy użyciu Aspose.Slides for Reporting Service dla ReportViewer. Zgromadzenie znajduje się w {Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **Jak zaimplementować eksport do PowerPoint:**
 1) Utwórz proxy usługi sieciowej (szczegóły znajdziesz [tutaj](http://technet.microsoft.com/en-us/library/ms155134.aspx)) i dodaj je do swojego rozwiązania.

 2) Dodaj odwołanie do Aspose.Slides.ReportingServices.dll dla ReportViewer 2010.

 3) Użyj tej klasy, aby zintegrować proxy usługi sieciowej i Aspose.Slides for Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>
/// Pobiera lub ustawia podstawowy adres URL usługi sieciowej XML, którego żąda klient.
/// </summary>
/// <value>
/// Podstawowy adres URL usługi sieciowej XML, którego żąda klient. Domyślnie jest to System.String.Empty.
/// </value>
public string ReportingServiceUrl { get; set; }


/// <summary>
/// Pobiera lub ustawia nazwę użytkownika dla Reporting Service.
/// </summary>
/// <value>
/// Nazwa użytkownika.
/// </value>
public string Username { get; set; }

/// <summary>
/// Pobiera lub ustawia hasło dla Reporting Service.
/// </summary>
/// <value>
/// Hasło.
/// </value>
public string Password { get; set; }

/// <summary>
/// Renderuje określony raport do pliku.
/// </summary>
/// <param name="outputFileName">Nazwa pliku wyjściowego.</param>
/// <param name="reportPath">Ścieżka raportu.</param>
/// <param name="format">Format wyjściowej prezentacji.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
//rozpoczęcie procesu renderowania
//tutaj wybieramy eksport w formacie PPT i podajemy outputStream
renderer.StartRendering(format, false);
int page = 1;

//ta pętla iteruje przez wszystkie strony raportu
while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//jeśli rplStream jest pusty, oznacza to koniec raportu
if (rplStream.Length == 0)

break;

//dodaj stronę raportu jako slajd do dokumentu
renderer.RenderPage(rplStream);

}

page++;

}

//wywołaj metodę FinishRendering, aby wypisać nowo utworzoną prezentację do strumienia wyjściowego
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

 4) Teraz możesz wyeksportować raport przy użyciu tego kodu:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

Proces eksportu tutaj używa miękkich podziałów stron podobnych do Worda lub Excela, więc jego wynik może różnić się od prezentacji wyeksportowanej przy użyciu standardowego podejścia.

{{% /alert %}}