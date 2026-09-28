---
title: Easy and Lightweight Deployment
type: docs
weight: 50
url: /reportingservices/easy-and-lightweight-deployment/
description: "Learn how Aspose.Slides for Reporting Services is deployed: one assembly in the report server's bin folder, registered in the report server configuration."
---

{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services is a [rendering extension](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) for Microsoft SQL Server Reporting Services and Power BI Report Server.
Aspose.Slides for Reporting Services is provided as a single MSI installer that can install on computers running a supported report server, 32-bit or 64-bit; see [System Requirements](/slides/reportingservices/system-requirements/).

It is also easy to deploy and manage Aspose.Slides for Reporting Services manually, as it is comprised of only one .NET assembly *Aspose.Slides* *.ReportingServices.dll* , written completely in C#, CLS compliant and containing only safe managed code.

{{% /alert %}}

The ZIP download includes two builds of Aspose.Slides.ReportingServices.dll for report servers:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – built for Microsoft SQL Server 2005 and .NET Framework 2.0 (use for x86 and x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – built for Microsoft SQL Server 2008 and later, Power BI Report Server and .NET Framework 2.0 (use for x86 and x64)

The MSI installer installs the same two builds and picks the right one for each report server instance. [Install Manually](/slides/reportingservices/install-manually/) lists every file in the ZIP download.

When installing, Aspose.Slides.ReportingServices.dll is copied to the ReportServer\bin directory and the configuration file is updated so Reporting Services is aware of the new rendering extension. These steps are performed by the Aspose.Slides for Reporting Services installer, but you could also perform them manually as described further in this documentation.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure**: Aspose.Slides.ReportingServices.dll is copied into the **ReportServer\bin** directory.
