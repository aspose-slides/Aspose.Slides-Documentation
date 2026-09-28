---
title: Install Manually
type: docs
weight: 30
url: /reportingservices/install-manually/
keywords:
- manual installation
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Install Aspose.Slides for Reporting Services by hand from the DLLs-only ZIP package: which assembly to copy, and what to add to rsreportserver.config and rssrvpolicy.config."
---

## **Overview**

Follow these steps to install Aspose.Slides for Reporting Services without the MSI installer, from the ZIP package *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* on the [download page](https://releases.aspose.com/slides/reportingservices/). They register the same extensions as the [MSI installer](/slides/reportingservices/install-with-msi-installer/). Repeat them for each report server instance.

Before you start, check the [system requirements](/slides/reportingservices/system-requirements/). You need local administrator rights on the report server.

## **Choose the Assembly**

The ZIP package contains several builds. Copy exactly one *Aspose.Slides.ReportingServices.dll* to the report server:

| File in the ZIP package | Use it for |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 and later Reporting Services, and Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Not for a report server: applications that export from the ReportViewer 2010 or 2012 control, see [Using Aspose.Slides with ReportViewer 2010 and 2012](/slides/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Optional: saves reports in RPL format for problem reports, see [Exporting Reports to RPL Format](/slides/reportingservices/exporting-reports-to-rpl-format/) |

## **Find the Report Server Folder**

The steps below refer to the report server's *ReportServer* folder, which holds *rsreportserver.config* and *rssrvpolicy.config*. In a default installation, it is:

| Report server | Default *ReportServer* folder |
| :- | :- |
| SQL Server 2017 and later Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 and earlier Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, where the instance folder is, for example, `MSRS13.MSSQLSERVER` for SQL Server 2016 or `MSSQL.x` for SQL Server 2005 |

For more locations, see Microsoft's [RsReportServer.config configuration file](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file) article.

## **Install the Extension**

1. Copy the assembly you chose to the *bin* subfolder of the *ReportServer* folder.

   The copied file must not carry explicitly assigned NTFS permissions, or the report server is denied access when it loads the assembly and the new export formats do not appear. Right-click the file, select **Properties**, and on the **Security** tab remove any explicitly assigned permissions, leaving only inherited ones. If the **General** tab shows an **Unblock** option, select it.

1. Save a copy of *rsreportserver.config*, and then open the file in a text editor. Add these entries inside the `<Render>` element:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Each entry registers one export format; `Name` must be unique among the rendering extensions. The MSI installer registers the same six names and types. Omit an entry if you do not want its format in the export list.

1. Save a copy of *rssrvpolicy.config*, and then open the file in a text editor. Find the code group whose `Description` is "This code group grants MyComputer code Execution permission." and add this code group as its last child:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` is the public key of the Aspose.Slides.ReportingServices assembly. Keep it on one line.

1. Save both files. The report server reads its configuration files again whenever they are saved. If a file contains malformed XML, the report server ignores it or does not start, so restore your copy if something goes wrong.

## **Check the Installation**

Open a paginated report in the web portal (Report Manager on SQL Server 2014 and earlier) and open the **Export** list. It now includes these formats:

- PPT - PowerPoint Presentation via Aspose.Slides
- PPS - PowerPoint SlideShow via Aspose.Slides
- PPTX - PowerPoint 2007 Presentation via Aspose.Slides
- PPSX - PowerPoint 2007 SlideShow via Aspose.Slides
- ODP - OpenDocument Presentation via Aspose.Slides
- XPS - via Aspose.Slides

Select one of them to export the report. The file opens in the application associated with its format.

![A report exported to PowerPoint by Aspose.Slides for Reporting Services](install-manually_2.png)

If the formats do not appear, check the NTFS permissions of the copied assembly. Without a license, exported files carry an evaluation watermark; see [Licensing](/slides/reportingservices/license-aspose-slides-for-reporting-services/).
