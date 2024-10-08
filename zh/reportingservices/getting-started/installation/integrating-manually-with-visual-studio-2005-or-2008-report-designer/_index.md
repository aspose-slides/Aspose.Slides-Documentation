---
title: 手动与 Visual Studio 2005 或 2008 报告设计器集成
type: docs
weight: 50
url: /reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---

{{% alert color="primary" %}} 

本文教你如何手动将 Aspose.Slides for Reporting Services 与 Visual Studio 集成。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

**Aspose.Slides for Reporting Services** 需要在主机上安装 **.NET Framework 3.5**。 

{{% /alert %}}

## **将 Aspose.Slides for Reporting Services 与 Visual Studio 集成**
我们建议你使用 MSI 安装程序来安装 Aspose.Slides for Reporting Services，因为它会自动执行所有必要的安装任务和配置过程。但是，如果 MSI 安装程序安装失败，请使用此处的指南。 

本文还向你展示如何在具有业务智能开发工作室的计算机上安装 Aspose.Slides for Reporting Services。这将使你能够在 Microsoft Visual Studio 2005 或 2008 报告设计器的设计时将报告导出为 Microsoft PowerPoint 格式。 

1. 将 Aspose.Slides.ReportingServices.dll 复制到 Visual Studio 目录。

   - 要与 Visual Studio 2005 报告设计器集成，请将 **Aspose.Slides.ReportingServices.dll** 复制到 **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies** 目录。
   - 要与 Visual Studio 2008 报告设计器集成，请将 **Aspose.Slides.ReportingServices.dll** 复制到 **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 目录。
2. 将 Aspose.Slides for Reporting Services 注册为渲染扩展。 

3. 打开 **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config**（其中 <Version> 对于 Visual Studio 2005 是 “8”，对于 Visual Studio 2008 是 “9.0”），并将这些行添加到 <Render> 元素中： 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. 给 Aspose.Slides for Reporting Services 执行权限。 
   1. 打开 **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config**（其中 <Version> 对于 Visual Studio 2005 是 “8”，对于 Visual Studio 2008 是 “9.0”）。
   1. 将这一行添加为第二个外部 <CodeGroup> 元素中的最后一项（应该是 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="此代码组授予 MyComputer 代码执行权限。">） 

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

    <!--到这里结束.-->

  </CodeGroup>

</CodeGroup>


```

5. 验证 Aspose.Slides for Reporting Services 是否已成功安装。 
6. 运行或重启 Microsoft Visual Studio 2005 或 2008 报告设计器。你应该注意到导出格式列表中出现了新格式。

**在报告设计器中出现新导出格式。** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)