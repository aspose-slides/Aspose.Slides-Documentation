---
title: 重新安裝 Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /zh-hant/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 
本文說明了當 Aspose.Slides for Reporting Services 已安裝，但因某些原因必須重新安裝時的解決方法。
{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 
**Aspose.Slides for Reporting Services** 需要在主機上安裝 **.NET Framework 3.5**。 
{{% /alert %}}

## **重新安裝 Aspose.Slides for Reporting Services 的步驟**
最重要的是徹底移除先前的 Aspose.Slides for Reporting Services 安裝。雖然 MSI 安裝程式可以成功執行卸載並因此自動重新安裝 Aspose.Slides for Reporting Services 所需的所有動作，但仍必須遵循以下步驟：

1. 使用 MSI 安裝程式解除安裝 Aspose.Slides for Reporting Services。 

2. 找出 Aspose.Slides for Reporting Services 的安裝目錄，通常位於：

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. 如果 MSI 安裝程式在解除安裝 Aspose.Slides for Reporting Services 時未移除 “Aspose.Slides for Reporting Services” 目錄，請刪除該資料夾。 

4. 在每個 SQL Server Reporting Service 實例的 “bin” 目錄中定位 **Aspose.Slides.ReportingServices.dll** 二進位檔。舉例來說，如果有 Microsoft SQL Server 2008 實例 “MSSQLSERVER”，相應的 Reporting Service “bin” 目錄可能位於：

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. 如果 MSI 安裝程式在解除安裝 Aspose.Slides for Reporting Services 時未從上述目錄中移除 Aspose.Slides.ReportingServices.dll 二進位檔，請立即刪除該檔案。 

6. 為每個 SSRS 實例找出 **rsreportserver.config** 檔案。舉例來說，如果有 Reporting Service 實例 “**MSRS10.MSSQLSERVER**”，則 **rsreportserver.config** 檔案位於以下目錄：

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. 使用任意編輯器開啟 **rsreportserver.config** 檔案，並找出在安裝 Aspose.Slides for Reporting Services 時用於加入 PowerPoint 格式擴充功能的行。 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** 如果 MSI 安裝程式在解除安裝 Aspose.Slides for Reporting Services 時未移除這些行，請立即從 **rsreportserver.config** 檔案中刪除這些行。

**Step** **9:** 為每個 SSRS 實例找出 **rssrvpolicy.config** 檔案。舉例來說，如果有 Reporting Service 實例 “MSRS10.MSSQLSERVER”，則 **rssrvpolicy.config** 檔案位於以下目錄：

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** 使用任意編輯器開啟 **rssrvpolicy.config** 檔案，找出在安裝 Aspose.Slides for Reporting Services 時為其授予執行權限的行。 

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

**Step** **11:** 如果 MSI 安裝程式在解除安裝產品時未移除上述行，請立即從 **rssrvpolicy.config** 檔案中移除這些行。 

**Step** **12:** 如果 Aspose.Slides for Reporting Services 也透過 Microsoft Visual Studio 安裝，以便在 Visual Studio 環境中開發 RDL 報表並匯出為 PowerPoint 格式，則在 Microsoft Visual Studio 2008 中，二進位檔 Aspose.Slides.ReportingServices.dll 及設定檔（**rsreportserver.config** 與 **rssrvpolicy.config**）的路徑應為：

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** 如果 MSI 安裝程式未移除 **Aspose.Slides.ReportingServices.dll** 二進位檔，請將其刪除。此外，如果它未更新 **rsreportserver.config** 與 **rssrvpolicy.config** 檔案，以分別移除 PowerPoint 格式擴充功能與程式碼執行權限，則必須手動刪除這些設定，方式與先前步驟相同。 

**Step** **14:** 現在可以重新安裝 Aspose.Slides for Reporting Services。使用 MSI 安裝程式進行自動安裝，或自行手動安裝。