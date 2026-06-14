---
title: 手動安裝
type: docs
weight: 30
url: /zh-hant/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

僅在您計劃手動安裝 Aspose.Slides for Reporting Services 時才遵循以下步驟。此時，您已下載包含組件檔案的 ZIP 套件。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** 需要在主機上安裝 **.NET Framework 3.5**。 

{{% /alert %}}

### **手動安裝**
以下說明將示範如何在 Microsoft SQL Server Reporting Services 安裝目錄中複製與修改檔案：

1. 找到報表伺服器的安裝目錄。  
   Microsoft SQL Server 的根目錄通常位於：***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 和 2008**：機器上可能配置了多個 Microsoft SQL Server 實例，且它們可能位於不同的 MSSQL.x 子目錄，例如 MSSQL.1、MSSQL.2 等。您必須在繼續下一步之前找到正確的 ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** 目錄。   
   
   {{% /alert %}} 所有以下使用的路徑皆以此目錄表示為 <Instance>。 

2. 將 Aspose.Slides.ReportingServices.dll 複製到 **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin** 資料夾。  
   下載的 **Aspose.Slides.ReportingServices.zip** 包含 **Aspose.Slides.ReportingServices.dll**。 {{% alert color="primary" %}} 

在某些情況下，當您將 DLL 複製到 **ReportServer\bin** 目錄時，可能會同時複製到已指派的明確 NTFS 檔案權限。這些 NTFS 權限會導致 Microsoft SQL Server Reporting Services 在載入 **Aspose.Slides.ReportingServices.dll** 時被拒絕存取。如果發生此情況，新的匯出格式將無法使用。請檢查並確認正確的 NTFS 權限已設定：

   1. 右鍵點擊 **Aspose.Slides.ReportingServices.dll**。  
   1. 點擊 **Properties** 並選取 **Security** 分頁。  
   1. 移除任何明確指派的 NTFS 權限，僅保留繼承的權限。  

{{% /alert %}}

3. 將 Aspose.Slides for Reporting Services 註冊為呈現擴充功能：  
   1. 開啟 *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*。  
   1. 將以下程式碼加入 <Render> 元素中：  

**<Render>**

``` xml

   ...

  <!--開始此處。-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--結束此處。-->

</Render>



```

4. 授予 Aspose.Slides for Reporting Services 執行權限：  
   1. 開啟 **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**。  
   1. 將以下內容作為第二層外層 <CodeGroup> 元素的最後一項加入（該元素應為 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">）。  

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--開始此處。-->

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

    <!--結束此處。-->

  </CodeGroup>

</CodeGroup>



```

5. 驗證 Aspose.Slides for Reporting Services 是否已成功安裝：  
   1. 開啟 Report Manager，檢查報表可用的匯出類型清單。  
   
      {{% alert color="primary" %}} 您可以透過開啟瀏覽器（Microsoft Internet Explorer 6.0 以上）並在網址列輸入 Report Manager URL（預設為 http://< ComputerName >/Reports）來啟動 Report Manager。  
   
      {{% /alert %}}

1. 在伺服器上選取一個報表。  
1. 開啟 **Select Format** 清單。  
   您應該會看到 Aspose.Slides for Reporting Services 提供的匯出格式清單。  
1. 選取 **PPT – PowerPoint Presentation via Aspose.Slides**。  

   **Aspose.Slides for Reporting Services 已成功安裝，且新匯出格式已可使用。**  

![todo:image_alt_text](install-manually_1.png)




6. 點擊 **Export** 連結。  
   報表會以所選格式產生，傳送至客戶端，然後在相應的應用程式中開啟。在本例中，報表會在 Microsoft PowerPoint 中開啟。  

   **由 Aspose.Slides for Reporting Services 產生的 PPT 報表。**  

![todo:image_alt_text](install-manually_2.png)

您已成功安裝 Aspose.Slides for Reporting Services，並將報表產生成 Microsoft PowerPoint 簡報！