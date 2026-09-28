---
title: System Requirements
type: docs
weight: 15
url: /reportingservices/system-requirements/
keywords:
- system requirements
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Check which report servers, editions and .NET Framework version Aspose.Slides for Reporting Services needs before you install it."
---

## **Overview**

Aspose.Slides for Reporting Services runs inside the report server as a rendering extension. This page lists what the report server machine needs before you [install](/slides/reportingservices/installing-aspose-slides-for-reporting-services/) it. Microsoft PowerPoint and Microsoft Office are not required.

## **Supported Report Servers**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, for paginated (RDL) reports

Both 32-bit and 64-bit report servers are supported. SQL Server 2005 uses its own build of the extension; all later versions and Power BI Report Server use the same build. [Install Manually](/slides/reportingservices/install-manually/) shows which file to copy.

If your report server version is not in this list, ask on the [free support forum](https://forum.aspose.com/c/slides/11) before you deploy.

## **Report Server Editions**

For SQL Server 2016 Reporting Services and later and for Power BI Report Server, Microsoft supports rendering extensions in the Enterprise, Standard, Developer and Evaluation editions; the Web and Express editions do not support them. See [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). The MSI installer skips Express edition instances of SQL Server 2016 and earlier.

## **.NET Framework**

.NET Framework 3.5 must be installed on the report server machine. The extension's assemblies are built for the .NET Framework 2.0 runtime, and the MSI installer stops with a message if .NET Framework 3.5 is missing. On Windows Server, add **.NET Framework 3.5 Features** in the Add Roles and Features Wizard; see [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Permissions**

Installing the extension changes files in the report server folder, so both installation routes need local administrator rights. If you start the MSI installer without them, it offers to restart itself with administrator privileges.

## **FAQ**

**Do I need Microsoft PowerPoint on the report server?**

No. The extension creates the presentations itself; neither PowerPoint nor Microsoft Office has to be installed.

**Can I install the extension on an Express edition?**

No. Express editions do not support rendering extensions. The MSI installer hides Express instances of SQL Server 2016 and earlier; on later versions, do not select an Express instance.

**Which formats does the extension add to the export list?**

PPT, PPS, PPTX, PPSX, ODP and XPS. See [Supported File Formats](/slides/reportingservices/supported-file-formats/).
