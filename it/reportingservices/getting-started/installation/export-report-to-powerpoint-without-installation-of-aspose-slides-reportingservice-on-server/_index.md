---
title: Esporta report in PowerPoint senza installazione di Aspose.Slides.ReportingService sul server
type: docs
weight: 120
url: /it/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}}

Aspose.Slides for Reporting Service può essere utilizzato senza installazione su un server. Questo approccio è adatto quando è necessario integrare l'esportazione in PowerPoint nella propria applicazione ma l'accesso al servizio è limitato.

{{% /alert %}} {{% alert color="primary" %}}

La soluzione Visual Studio che illustra l'approccio può essere trovata [qui](attachments/10289165/10453062.zip).

{{% /alert %}}

Il processo di rendering comprende due parti:

1. Eseguire il rendering del report in RPL utilizzando il Reporting Service Web Service. Per ulteriori informazioni sul Reporting Service Web Service [qui](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Eseguire il rendering di RPL in PowerPoint utilizzando Aspose.Slides for Reporting service per ReportViewer. L'assembly si trova in {Aspose.Slides for Reporting Services home directory}\bin\RV2010  

## **Come implementare l'esportazione in PowerPoint:**
 1) Creare il proxy del servizio web (vedi i dettagli [qui](http://technet.microsoft.com/en-us/library/ms155134.aspx)) e aggiungerlo alla propria soluzione.

 2) Aggiungere un riferimento a Aspose.Slides.ReportingServices.dll per ReportViewer 2010.

 3) Utilizzare questa classe per integrare il proxy del servizio web e Apose.Slides for Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>
/// Ottiene o imposta l'URL di base del servizio Web XML richiesto dal client.
/// </summary>
/// <value>
/// L'URL di base del servizio Web XML richiesto dal client. Il valore predefinito è System.String.Empty.
/// </value>
public string ReportingServiceUrl { get; set; }


/// <summary>
/// Ottiene o imposta il nome utente per Reporting Service.
/// </summary>
/// <value>
/// Il nome utente.
/// </value>
public string Username { get; set; }

/// <summary>
/// Ottiene o imposta la password per Reporting Service.
/// </summary>
/// <value>
/// La password.
/// </value>
public string Password { get; set; }

/// <summary>
/// Esegue il rendering del report specificato su file.
/// </summary>
/// <param name="outputFileName">Nome del file di output.</param>
/// <param name="reportPath">Il percorso del report.</param>
/// <param name="format">Il formato di presentazione di output.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
//avvia il processo di rendering
//qui scegliamo di esportare in formato PPT e forniamo l'outputStream
renderer.StartRendering(format, false);
int page = 1;
//questo ciclo itera attraverso tutte le pagine del report
while (true)
{
using (MemoryStream rplStream = CreateRplStream(page, reportPath))
{
//se rplStream è vuoto, abbiamo raggiunto la fine del report
if (rplStream.Length == 0)
break;
//aggiungi la pagina del report come diapositiva al documento
renderer.RenderPage(rplStream);
}
page++;
}
//chiama il metodo FinishRendering per scrivere la presentazione appena creata nello stream di output
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

 4) Ora è possibile esportare il report tramite questo codice:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}}

Il processo di esportazione utilizza qui interruzioni di pagina morbide simili a Word o Excel, quindi il risultato potrebbe differire dalla presentazione esportata con l'approccio standard.

{{% /alert %}}