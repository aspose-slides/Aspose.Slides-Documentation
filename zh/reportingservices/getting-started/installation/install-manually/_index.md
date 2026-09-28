---
title: 手动安装
type: docs
weight: 30
url: /zh/reportingservices/install-manually/
keywords:
- 手动安装
- rsreportserver.config
- rssrvpolicy.config
- SQL Server 报表服务
- Power BI 报表服务器
- Aspose.Slides for Reporting Services
description: "从仅 DLL 的 ZIP 包手动安装 Aspose.Slides for Reporting Services：需要复制的程序集以及在 rsreportserver.config 和 rssrvpolicy.config 中添加的内容。"
---
## **概述**

按照以下步骤从 ZIP 包 *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* 在[下载页面](https://releases.aspose.com/slides/zh/reportingservices/)安装 Aspose.Slides for Reporting Services（无需 MSI 安装程序）。它们会注册与[MSI 安装程序](/slides/zh/reportingservices/install-with-msi-installer/)相同的扩展。对每个报告服务器实例重复此操作。

在开始之前，请检查[系统要求](/slides/zh/reportingservices/system-requirements/)。您需要在报告服务器上拥有本地管理员权限。

## **选择程序集**

ZIP 包包含多个版本。将其中恰好一个 *Aspose.Slides.ReportingServices.dll* 复制到报告服务器：

| ZIP 包中的文件 | 用作 |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 及更高版本的 Reporting Services，以及 Power BI 报告服务器 |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | 不用于报告服务器：用于从 ReportViewer 2010 或 2012 控件导出的应用程序，参见[使用 Aspose.Slides 与 ReportViewer 2010 和 2012](/slides/zh/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | 可选：将报告保存为 RPL 格式以便问题报告，参见[导出报告为 RPL 格式](/slides/zh/reportingservices/exporting-reports-to-rpl-format/) |

## **查找报告服务器文件夹**

以下步骤涉及报告服务器的 *ReportServer* 文件夹，该文件夹包含 *rsreportserver.config* 和 *rssrvpolicy.config*。默认安装情况下，它的位置如下：

| 报告服务器 | 默认 *ReportServer* 文件夹 |
| :- | :- |
| SQL Server 2017 及更高版本的 Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI 报告服务器 | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 及更早版本的 Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`，其中 `<instance folder>` 例如 `MSRS13.MSSQLSERVER`（SQL Server 2016）或 `MSSQL.x`（SQL Server 2005） |

有关更多位置，请参阅 Microsoft 的[RsReportServer.config 配置文件](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file)文章。

## **安装扩展**

1. 将选定的程序集复制到 *ReportServer* 文件夹的 *bin* 子文件夹。

   复制的文件不得具有显式分配的 NTFS 权限，否则报告服务器在加载程序集时会被拒绝访问，新导出格式将不会出现。右键单击文件，选择**属性**，在**安全**选项卡中删除所有显式分配的权限，仅保留继承的权限。如果**常规**选项卡显示**解除阻止**选项，请选中它。

2. 保存一份 *rsreportserver.config* 的副本，然后在文本编辑器中打开该文件。在 `<Render>` 元素内部添加以下条目：

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   每个条目注册一种导出格式；`Name` 必须在渲染扩展中唯一。MSI 安装程序注册了相同的六个名称和类型。如果不希望某种格式显示在导出列表中，请省略相应条目。

3. 保存一份 *rssrvpolicy.config* 的副本，然后在文本编辑器中打开该文件。找到 `Description` 为"This code group grants MyComputer code Execution permission."的代码组，并将以下代码组添加为其最后一个子项：

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` 是 Aspose.Slides.ReportingServices 程序集的公钥。请保持在同一行。

4. 保存两个文件。报告服务器在文件保存后会重新读取配置文件。如果文件包含格式错误的 XML，报告服务器将忽略该文件或无法启动，出现问题时请恢复您的副本。

## **检查安装**

在 Web 门户（SQL Server 2014 及更早版本的 Report Manager）中打开一个分页报告，并打开**导出**列表。现在列表中包含以下格式：

- PPT - 通过 Aspose.Slides 的 PowerPoint 演示文稿
- PPS - 通过 Aspose.Slides 的 PowerPoint 幻灯片放映
- PPTX - 通过 Aspose.Slides 的 PowerPoint 2007 演示文稿
- PPSX - 通过 Aspose.Slides 的 PowerPoint 2007 幻灯片放映
- ODP - 通过 Aspose.Slides 的 OpenDocument 演示文稿
- XPS - 通过 Aspose.Slides

选择其中一种即可导出报告。文件将在与其格式关联的应用程序中打开。

![由 Aspose.Slides for Reporting Services 导出的 PowerPoint 报表](install-manually_2.png)

如果没有出现这些格式，请检查复制的程序集的 NTFS 权限。没有许可证时，导出的文件会带有评估水印；请参阅[授权](/slides/zh/reportingservices/license-aspose-slides-for-reporting-services/)。