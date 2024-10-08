---
title: 重新安装 Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

本文描述了当 Aspose.Slides for Reporting Services 已经安装，但由于某种原因需要重新安装的情况的解决方案。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

**Aspose.Slides for Reporting Services** 需要在主机上安装 **.NET Framework 3.5**。

{{% /alert %}}

## **重新安装 Aspose.Slides for Reporting Services 的步骤**
最重要的是完全移除之前安装的 Aspose.Slides for Reporting Services。虽然 MSI 安装程序可以成功执行卸载和重新安装 Aspose.Slides for Reporting Services 所需的操作，但必须按照以下步骤进行：

1. 使用 MSI 安装程序卸载 Aspose.Slides for Reporting Services。

2. 找到 Aspose.Slides for Reporting Services 的安装目录，通常位于：

   **操作系统根驱动器\Program Files\Aspose\Aspose.Slides for Reporting Services**

3. 如果 MSI 安装程序在卸载 Aspose.Slides for Reporting Services 时没有移除 “Aspose.Slides for Reporting Services” 目录，请删除该文件夹。

4. 在每个 SQL Server Reporting Service 实例的 “bin” 目录中找到 **Aspose.Slides.ReportingServices.dll** 二进制文件。例如，如果存在 Microsoft SQL Server 2008 实例 “MSSQLSERVER”，则相应的 Reporting Service “bin” 目录很可能位于：

   **操作系统根驱动器\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin**

5. 如果 MSI 安装程序在卸载 Aspose.Slides for Reporting Services 时没有从上述目录移除 Aspose.Slides.ReportingServices.dll 二进制文件，请现在删除该文件。

6. 为每个 SSRS 实例找到 **rsreportserver.config** 文件。例如，如果存在 Reporting Service 实例 “ **MSRS10.MSSQLSERVER** ”，则 **rsreportserver.config** 文件将位于此目录：

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer**

7. 在任何编辑器中打开 **rsreportserver.config** 文件，找到在安装 Aspose.Slides for Reporting Services 时为添加 PowerPoint 格式扩展而创建的行。

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

```

**步骤 8：** 如果 MSI 安装程序在卸载 Aspose.Slides for Reporting Services 时没有移除这些行，请现在从 **rsreportserver.config** 文件中删除这些行。

**步骤 9：** 为每个 SSRS 实例找到 **rssrvpolicy.config** 文件。例如，如果存在 Reporting Service 实例 “ MSRS10.MSSQLSERVER ”，则 **rssrvpolicy.config** 文件将位于此目录：

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer**

**步骤 10：** 在任何编辑器中打开 **rssrvpolicy.config** 文件，找到在安装 Aspose.Slides for Reporting Services 时为授予 Aspose.Slides for Reporting Services 执行权限而创建的行。

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--从这里开始.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="此代码组授予 AS4SSRS 程序集完全信任。">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

           PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--到此结束.-->

  </CodeGroup>

</CodeGroup>

```

**步骤 11：** 如果 MSI 安装程序在卸载产品时没有移除上述行，请现在从 **rssrvpolicy.config** 文件中删除这些行。

**步骤 12：** 如果 Aspose.Slides for Reporting Services 也是与 Microsoft Visual Studio 一起安装的，用于 RDL 报告开发和在 Microsoft Visual Studio 环境中导出 PowerPoint 格式，则 Microsoft Visual Studio 2008 的二进制文件 Aspose.Slides.ReportingServices.dll 和配置文件 ( **rsreportserver.config** 和 **rssrvpolicy.config** ) 应位于：

**操作系统根驱动器\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**

**步骤 13：** 如果 MSI 安装程序没有移除 **Aspose.Slides.ReportingServices.dll** 二进制文件，请删除它。此外，如果它没有更新 **rsreportserver.config** 和 **rssrvpolicy.config** 文件以分别移除 PowerPoint 格式扩展和代码执行权限，则必须像处理前面步骤中的文件一样手动删除它们。

**步骤 14：** 现在是重新安装 Aspose.Slides for Reporting Services 的时候了。使用 MSI 安装程序进行自动安装或手动进行安装。