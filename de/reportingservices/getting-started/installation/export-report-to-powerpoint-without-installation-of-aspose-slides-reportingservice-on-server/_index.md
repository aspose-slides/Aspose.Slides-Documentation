---
title: Exportbericht nach Powerpoint ohne Installation von Aspose.Slides.ReportingService auf dem Server
type: docs
weight: 120
url: /de/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---

{{% alert color="primary" %}} 

Aspose.Slides für Reporting Service kann ohne Installation auf einem Server verwendet werden. Dieser Ansatz eignet sich, wenn Sie den Export nach Powerpoint in Ihre Anwendung integrieren müssen, der Zugriff auf den Service jedoch eingeschränkt ist.

{{% /alert %}} {{% alert color="primary" %}} 

Die Visual Studio-Lösung, die den Ansatz veranschaulicht, finden Sie [hier](attachments/10289165/10453062.zip).

{{% /alert %}} 

Der Rendering-Prozess umfasst zwei Teile:

1. Bericht in RPL unter Verwendung des Reporting Service Web Service rendern. Weitere Informationen zum Reporting Service Web Service finden Sie [hier](http://technet.microsoft.com/en-us/library/ms152787.aspx).
2. RPL in Powerpoint unter Verwendung von Aspose.Slides für den Reporting-Service für ReportViewer rendern. Die Assembly befindet sich im ﻿﻿﻿﻿﻿{Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **So implementieren Sie den Export nach PowerPoint:**
 1) Erstellen Sie den Web Service Proxy (siehe die Einzelheiten [hier](http://technet.microsoft.com/en-us/library/ms155134.aspx)) und fügen Sie ihn Ihrer Lösung hinzu.

 2) Fügen Sie einen Verweis auf Aspose.Slides.ReportingServices.dll für ReportViewer 2010 hinzu.

 3) Verwenden Sie diese Klasse, um den Web Service Proxy und Aspose.Slides für den Reporting Service zu integrieren

``` xml

 class PowerpointRenderer

{

/// <summary>

/// Ruft die Basis-URL des XML-Webdiensts ab oder legt sie fest, die der Client anfordert.

/// </summary>

/// <value>

/// Die Basis-URL des XML-Webdiensts, die der Client anfordert. Der Standardwert ist System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// Ruft den Benutzernamen für den Reporting Service ab oder legt ihn fest.

/// </summary>

/// <value>

/// Der Benutzername.

/// </value>

public string Username { get; set; }

/// <summary>

/// Ruft das Passwort für den Reporting Service ab oder legt es fest.

/// </summary>

/// <value>

/// Das Passwort.

/// </value>

public string Password { get; set; }

/// <summary>

/// Rendert den angegebenen Bericht in eine Datei.

/// </summary>

/// <param name="outputFileName">Name der Ausgabedatei.</param>

/// <param name="reportPath">Der Berichts-Pfad.</param>

/// <param name="format">Das Ausgabepräsentationsformat.</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//Start des Rendering-Prozesses

//hier wählen wir den Export im PPT-Format und stellen den outputStream bereit

renderer.StartRendering(format, false);

int page = 1;

//Dieser Zyklus durchläuft alle Seiten des Berichts

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//wenn rplStream leer ist, haben wir das Ende des Berichts erreicht

if (rplStream.Length == 0)

break;

//Fügen Sie die Berichtseite als Folie zum Dokument hinzu

renderer.RenderPage(rplStream);

}

page++;

}

//rufen Sie die Finish-Methode auf, um unsere neu erstellte Präsentation im Output-Stream zu speichern

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

 4) Jetzt können Sie den Bericht durch diesen Code exportieren:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt", "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

Der Exportprozess verwendet hier weiche Seitenumbrüche, ähnlich wie in Word oder Excel, sodass das Ergebnis von der Präsentation abweichen kann, die mit dem Standardansatz exportiert wurde.

{{% /alert %}}