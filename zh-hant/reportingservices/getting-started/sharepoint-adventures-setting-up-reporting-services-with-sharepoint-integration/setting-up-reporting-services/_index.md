---
title: 設定 Reporting Services
type: docs
weight: 30
url: /zh-hant/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

我們在 RS 伺服器的第一站是 Reporting Services Configuration Manager。 

{{% /alert %}} 
## **Service Account**
請務必了解您在 Reporting Services 中使用的服務帳戶。若遇到問題，可能與您使用的服務帳戶有關。預設為 Network Service。每當我部署新建置時，都會使用網域帳戶，因為我最容易在此遇到問題。對於我伺服器上的此設定，我使用了一個名為 **RSService** 的網域帳戶。 
## **Web Service URL**
我們需要設定 Web Service URL。這是 hosting Reporting Services 使用的 Web Services 的 **ReportServer** 虛擬目錄 (vdir)，也是 SharePoint 會與之通訊的目標。除非您想自訂 vdir 的屬性（例如 SSL、連接埠、主機標頭等），否則只要在此點選 Apply 即可完成。 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**Figure 3**: 設定 Web Service URL 

完成後您應該會看到下圖。 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Figure 4**: 成功設定 Web Service URL 
## **Database**
我們需要建立 Reporting Services 目錄資料庫。此資料庫可放置於任何 SQL 2008 或 SQL 2008 R2 Database Engine 上。SQL11 也可以使用，但仍處於 BETA 階段。此動作預設會建立兩個資料庫 **ReportServer** 與 **ReportServerTempDB**。 
另一個重要步驟是確保您為資料庫類型選擇 SharePoint Integrated。做出此選擇後即無法更改。請參考圖 5、6 與 7。 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Figure 5**: 建立 Report Server 資料庫 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Figure 6**: 設定資料庫伺服器與驗證類型 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Figure 7**: 設定資料庫名稱與模式 

關於認證，這是 Report Server 與 SQL Server 之間的通訊方式。您選擇的任何帳戶，都會在目錄資料庫以及透過 RSExecRole 的幾個系統資料庫中獲得特定權限。MSDB 為其中一個用於訂閱的資料庫，因為我們會使用 SQL Agent。 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Figure 8**: 設定 Report Server 資料庫認證 

完成後，畫面應如下圖所示。 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**Figure 9**: 完成 Report Server 資料庫設定的進度 
## **Report Manager URL**
我們可以跳過 Report Manager URL，因為在 SharePoint Integrated 模式下不會使用它。SharePoint 是我們的前端。Report Manager 無法運作。 
## **Encryption Keys**
備份您的 Encryption Keys，並確保知道它們的保存位置。若需要遷移或還原資料庫時，必須使用這些金鑰。 

![todo:image_alt_text](setting-up-reporting-services_9.png)

以上即為 Reporting Services Configuration Manager 的所有步驟。若在 Web Service URL 分頁瀏覽該 URL，應會顯示類似下圖的畫面。 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Figure 12**: 安裝後的 Report Server 存取 

發生了什麼事？我的 WFE 上已安裝 SharePoint，且我已完成 Reporting Services 的設定。在此範例中，Reporting Services 與 SharePoint 位於不同機器上。若它們在同一機器上，則不會看到此錯誤。我們實際上需要在 RS 主機上安裝 SharePoint，這也意味著會啟用 IIS。