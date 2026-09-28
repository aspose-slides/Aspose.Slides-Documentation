---
title: Install with MSI Installer
type: docs
weight: 20
url: /reportingservices/install-with-msi-installer/
keywords:
- MSI installer
- installation
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Install Aspose.Slides for Reporting Services with its MSI installer: what the installer needs, what it changes on each report server instance, and how to check the result."
---

## **Installation**

The MSI installer is the simplest way to install Aspose.Slides for Reporting Services. It needs .NET Framework 3.5 and administrator rights on the report server; see [System Requirements](/slides/reportingservices/system-requirements/).

1. Download the MSI installer, *Aspose.Slides for Reporting Services XX.XX*, from the [download page](https://releases.aspose.com/slides/reportingservices/) and copy it to the report server.
1. Run it as an administrator. If .NET Framework 3.5 is missing, the installer stops with a message; install the .NET Framework 3.5 features and run it again.
1. Accept the license agreement.
1. On the **Custom Setup** page, the feature tree lists each SQL Server Reporting Services and Power BI Report Server instance the installer detects on the machine. To leave an instance unchanged, click its icon and select **Entire feature will be unavailable**. Express editions do not support rendering extensions, so do not select an Express instance. The installer hides Express instances of SQL Server 2016 and earlier.
1. Select **Next**, and then **Install**.

The optional **Rpl Export** feature is not selected by default. It adds a hidden extension that saves reports in RPL format, which is useful when you send a problem report to Aspose; see [Exporting Reports to RPL Format](/slides/reportingservices/exporting-reports-to-rpl-format/).

## **What the Installer Changes**

The installer keeps its files in *Aspose\Aspose.Slides for Reporting Services* under the Program Files folder — *Program Files (x86)* on 64-bit Windows, because the installer is a 32-bit package. Then, for each selected instance, it:

- copies *Aspose.Slides.ReportingServices.dll* to the instance's *ReportServer\bin* folder — the build for SQL Server 2005, or the build for SQL Server 2008 and later and Power BI Report Server;
- adds six rendering extensions — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS and ASODP — to the `<Render>` element of *rsreportserver.config*;
- adds a code group that grants the assembly full trust to *rssrvpolicy.config*;
- saves a copy of each configuration file it changes, with *.bak* appended to the file name.

[Install Manually](/slides/reportingservices/install-manually/) shows these changes step by step.

If an instance cannot be configured, the installer names it in a message and writes the details to *rserrors&lt;date&gt;.log* in the installation folder. Install the extension on that instance manually.

## **Check the Installation**

Open a paginated report in the web portal (Report Manager on SQL Server 2014 and earlier) and open the **Export** list. It now includes these formats:

- PPT - PowerPoint Presentation via Aspose.Slides
- PPS - PowerPoint SlideShow via Aspose.Slides
- PPTX - PowerPoint 2007 Presentation via Aspose.Slides
- PPSX - PowerPoint 2007 SlideShow via Aspose.Slides
- ODP - OpenDocument Presentation via Aspose.Slides
- XPS - via Aspose.Slides

Without a license, the exported files carry an evaluation watermark; see [Licensing](/slides/reportingservices/license-aspose-slides-for-reporting-services/).

## **When to Install Manually**

Install the extension [manually](/slides/reportingservices/install-manually/) instead when:

- the installer cannot configure an instance, for example because of security settings on the server;
- after an upgrade, you want to replace only the assembly instead of uninstalling the old version and running the new installer.

Uninstalling the product removes the assembly and the configuration entries from each instance.
