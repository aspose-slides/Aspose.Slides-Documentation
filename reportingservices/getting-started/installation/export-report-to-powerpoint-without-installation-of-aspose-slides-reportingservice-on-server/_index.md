---
title: Export report to Powerpoint without installation of Aspose.Slides.ReportingService on server
type: docs
weight: 120
url: /reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---

{{% alert color="primary" %}} 

Aspose.Slides for Reporting Service can be used without installation on server. This approach is suitable when you need to integrate export to Powerpoint in your application but access to service is restricted.

{{% /alert %}} {{% alert color="primary" %}} 

Visual Studio solution that illustrates the approach can be found [here ](attachments/10289165/10453062.zip)

{{% /alert %}} 

The process of rendering consist of two parts: 

1. Render report to RPL using Reporting Service Web Service. More information regarding Reporting Service Web Service can be found [here](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Render RPL to Powerpoint using Aspose.Slides for Reporting service for ReportViewer. The assembly is located in ﻿﻿﻿﻿﻿{Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **Here is the steps to implement export to Powerpoint:**
 1) Create web service proxy as described [here](http://technet.microsoft.com/en-us/library/ms155134.aspx) and add it to your solution.

 2) Add reference to Aspose.Slides.ReportingServices.dll for ReportViewer 2010.

 3) Use this class to integrate web service proxy and Apose.Slides for Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>

/// Gets or sets the base URL of the XML Web service the client is requesting.

/// </summary>

/// <value>

/// The base URL of the XML Web service the client is requesting. The default is a System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// Gets or sets the username for Reporting Service.

/// </summary>

/// <value>

/// The username.

/// </value>

public string Username { get; set; }

/// <summary>

/// Gets or sets the password for Reporting Service.

/// </summary>

/// <value>

/// The password.

/// </value>

public string Password { get; set; }

/// <summary>

/// Renders the specified report to file.

/// </summary>

/// <param name="outputFileName">Name of the output file.</param>

/// <param name="reportPath">The report path.</param>

/// <param name="format">The output presentation format.</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//start rendering process

//here we are choosing to export in PPT format and providing outputStream

renderer.StartRendering(format, false);

int page = 1;

//this cycle iterates through all pages of report

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//if rplStream is empty then we reached end of report

if (rplStream.Length == 0)

break;

//add report page as slide to the document

renderer.RenderPage(rplStream);

}

page++;

}

//call finish method to flush our newly created presentation to output stream

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

 4) Now you can export report by using this code:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

This kind of export uses Soft page breaks like in Word or Excel, so the result can be different from Presentation that was exported using standard approach.

{{% /alert %}}
