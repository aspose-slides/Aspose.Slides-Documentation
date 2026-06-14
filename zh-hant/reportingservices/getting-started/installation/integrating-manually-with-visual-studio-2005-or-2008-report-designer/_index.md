---
title: 手動整合 Visual Studio 2005 或 2008 報表設計師
type: docs
weight: 50
url: /zh-hant/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

本文教導您如何在 Visual Studio 中手動整合 Aspose.Slides for Reporting Services。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** 需要在主機上安裝 **.NET Framework 3.5**。 

{{% /alert %}}

## **將 Aspose.Slides for Reporting Services 整合至 Visual Studio**
我們建議使用 MSI 安裝程式安裝 Aspose.Slides for Reporting Services，因為它會自動執行所有必要的安裝與設定程序。然而，若 MSI 安裝失敗，請依照本指南操作。

本文亦說明如何在安裝有 Business Intelligence Development Studio 的電腦上安裝 Aspose.Slides for Reporting Services。這將讓您能在 Microsoft Visual Studio 2005 或 2008 報表設計師中於設計時將報表匯出為 Microsoft PowerPoint 格式。

1. 將 Aspose.Slides.ReportingServices.dll 複製至 Visual Studio 目錄。

   - 若要與 Visual Studio 2005 報表設計師整合，請將 **Aspose.Slides.ReportingServices.dll** 複製到 **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies** 目錄。
   - 若要與 Visual Studio 2008 報表設計師整合，請將 **Aspose.Slides.ReportingServices.dll** 複製到 **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 目錄。
2. 註冊 Aspose.Slides for Reporting Services 為呈現擴充模組。

3. 開啟 **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config**（其中 <Version> 為 Visual Studio 2005 時的 “8”，或 Visual Studio 2008 時的 “9.0”），並在 <Render> 元素中加入以下行：

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. 為 Aspose.Slides for Reporting Services 授予執行權限。
   1. 開啟 **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config**（其中 <Version> 為 Visual Studio 2005 時的 “8”，或 Visual Studio 2008 時的 “9.0”）。
   1. 在第二層外層的 <CodeGroup> 元素的最後一項加入以下行（該元素應為 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">）

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--從此開始。-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--到此結束。-->

  </CodeGroup>

</CodeGroup>



```

5. 驗證 Aspose.Slides for Reporting Services 是否已成功安裝。
6. 執行或重新啟動 Microsoft Visual Studio 2005 或 2008 報表設計師。您應該會在匯出格式清單中看到新的格式。

**新的匯出格式會出現在報表設計師中。** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)