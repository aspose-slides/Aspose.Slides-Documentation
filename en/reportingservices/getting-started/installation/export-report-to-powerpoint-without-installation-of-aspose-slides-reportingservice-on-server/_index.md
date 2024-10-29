---
title: Export report to Powerpoint without installation of Aspose.Slides.ReportingService on server
type: docs
weight: 120
url: /reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---

{{% alert color="primary" %}} 

Aspose.Slides for Reporting Service can be used without installation on a server. This approach is suitable when you need to integrate export to Powerpoint in your application but access to the service is restricted.

{{% /alert %}} {{% alert color="primary" %}} 

Visual Studio solution that illustrates the approach can be found [here](attachments/10289165/10453062.zip).

{{% /alert %}} 

The rendering process comprises two parts: 

1. Render report to RPL using Reporting Service Web Service. See more information on Reporting Service Web Service [here](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Render RPL to Powerpoint using Aspose.Slides for Reporting service for ReportViewer. The assembly is located in ﻿﻿﻿﻿﻿{Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **How to Implement Export to PowerPoint:**
 1) Create the web service proxy (see the details [here](http://technet.microsoft.com/en-us/library/ms155134.aspx)) and add it to your solution.

 2) Add a reference to Aspose.Slides.ReportingServices.dll for ReportViewer 2010.

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

 4) Now you can export the report through this code:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

The export process here uses soft page breaks similar to Word or Excel, so its result may differ from the Presentation that was exported using the standard approach.

{{% /alert %}}
