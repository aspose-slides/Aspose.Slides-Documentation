---
title: 手動安裝
type: docs
weight: 30
url: /zh-hant/reportingservices/install-manually/
keywords:
- 手動安裝
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "從僅含 DLL 的 ZIP 套件手動安裝 Aspose.Slides for Reporting Services：要複製的組件，以及需要在 rsreportserver.config 和 rssrvpolicy.config 中加入的內容。"
---
## **概觀**

請依照以下步驟從 ZIP 套件 *Aspose.Slides for Reporting Services XX.XX (DLLs Only)*（於[下載頁面](https://releases.aspose.com/slides/reportingservices/)）安裝 Aspose.Slides for Reporting Services，無需 MSI 安裝程式。它們會註冊與[MSI 安裝程式](/slides/zh-hant/reportingservices/install-with-msi-installer/)相同的擴充功能。對每個報表伺服器實例重複這些步驟。

在開始之前，請檢查[系統需求](/slides/zh-hant/reportingservices/system-requirements/)。您需要在報表伺服器上具有本機管理員權限。

## **選擇組件**

ZIP 套件包含多個組建。請將其中一個 *Aspose.Slides.ReportingServices.dll* 複製到報表伺服器：

| ZIP 套件中的檔案 | 適用於 |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 及之後的 Reporting Services，以及 Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | 不適用於報表伺服器：從 ReportViewer 2010 或 2012 控制項匯出的應用程式，請參閱[使用 Aspose.Slides 搭配 ReportViewer 2010 和 2012](/slides/zh-hant/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | 可選：將報表儲存為 RPL 格式以供問題報告，請參閱[匯出報表為 RPL 格式](/slides/zh-hant/reportingservices/exporting-reports-to-rpl-format/) |

## **尋找報表伺服器資料夾**

以下步驟參考報表伺服器的 *ReportServer* 資料夾，其中包含 *rsreportserver.config* 與 *rssrvpolicy.config*。在預設安裝中，它位於：

| 報表伺服器 | 預設 *ReportServer* 資料夾 |
| :- | :- |
| SQL Server 2017 及之後的 Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 及以前的 Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`，其中 <instance folder> 為實例資料夾，例如 SQL Server 2016 為 `MSRS13.MSSQLSERVER`，或 SQL Server 2005 為 `MSSQL.x` |

欲取得更多位置，請參閱 Microsoft 的[RsReportServer.config 組態檔案](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file)文章。

## **安裝擴充功能**

1. 將您選擇的組件複製到 *ReportServer* 資料夾的 *bin* 子資料夾。

   複製的檔案不得帶有明確指派的 NTFS 權限，否則在載入組件時報表伺服器會被拒絕存取，新的匯出格式也不會出現。右鍵點選該檔案，選取**屬性**，在**安全性**索引標籤上移除所有明確指派的權限，只保留繼承的權限。如果**一般**索引標籤顯示**解除封鎖**選項，請選取它。

2. 儲存 *rsreportserver.config* 的副本，然後使用文字編輯器開啟該檔案。在 `<Render>` 元素內加入以下條目：

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```


   每個條目會註冊一種匯出格式；`Name` 必須在所有呈現擴充功能中唯一。MSI 安裝程式會註冊相同的六個名稱與類型。如果不想在匯出清單中出現某個格式，請省略相應條目。

3. 儲存 *rssrvpolicy.config* 的副本，然後使用文字編輯器開啟該檔案。找到 `Description` 為「This code group grants MyComputer code Execution permission.」的程式碼群組，並將以下程式碼群組加入為其最後一個子項：

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` 為 Aspose.Slides.ReportingServices 組件的公開金鑰。請保持在同一行。

4. 儲存兩個檔案。報表伺服器會在每次儲存後重新讀取其組態檔案。如果檔案包含格式錯誤的 XML，報表伺服器會忽略它或無法啟動，若發生問題請還原您的備份。

## **檢查安裝**

在 Web 入口網站（SQL Server 2014 及以前的 Report Manager）中開啟分頁報表，並開啟 **匯出** 清單。現在會包含以下格式：

- PPT - 透過 Aspose.Slides 的 PowerPoint 簡報
- PPS - 透過 Aspose.Slides 的 PowerPoint 投影片放映
- PPTX - 透過 Aspose.Slides 的 PowerPoint 2007 簡報
- PPSX - 透過 Aspose.Slides 的 PowerPoint 2007 投影片放映
- ODP - 透過 Aspose.Slides 的 OpenDocument 簡報
- XPS - 透過 Aspose.Slides

選取其中一個格式以匯出報表。檔案會以與其格式關聯的應用程式開啟。

![透過 Aspose.Slides for Reporting Services 匯出的報表為 PowerPoint](install-manually_2.png)

若未顯示這些格式，請檢查已複製組件的 NTFS 權限。若未取得授權，匯出的檔案會帶有評估版浮水印；請參閱[授權](/slides/zh-hant/reportingservices/license-aspose-slides-for-reporting-services/)。