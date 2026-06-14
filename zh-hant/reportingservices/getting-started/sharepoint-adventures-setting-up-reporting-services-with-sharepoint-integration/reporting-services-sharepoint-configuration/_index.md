---
title: Reporting Services SharePoint 設定
type: docs
weight: 50
url: /zh-hant/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

現在 SharePoint 已在 RS 伺服器上安裝並設定，且 RS 也已透過 Reporting Services Configuration Manager 完成設定，我們即可繼續在 Central Admin 內進行設定。RS 2008 R2 已大幅簡化此流程。以前需要三個步驟才能完成，現在只需要一步。

我們要前往 Central Administrator 網站，然後進入 General Application Settings。往下捲動至底部即可看到 Reporting Services。

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Figure 17**：SharePoint 設定

{{% alert color="primary" %}} 

點選 **Reporting Services Integration** 。

{{% /alert %}} 
## **Web Service URL**
請填入在 Reporting Services Configuration Manager 中找到的 Report Server URL。 
## **Authentication Mode**
同時選取一個驗證模式。以下的 MSDN 連結會詳細說明這些模式的差異。 
[SharePoint 整合模式下 Reporting Services 的安全性概觀](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

簡而言之，如果您的站台使用 **Claims Authentication**，則不論此處選擇何種方式，都會使用 Trusted Authentication。如果要傳遞 Windows 認證，請選擇 Windows Authentication。對於 Trusted Authentication，我們會傳遞 SPUser 令牌，而不依賴 Windows 認證。

如果您的 Classic Mode 站台已設定 NTLM，且 RS 也設定為 NTLM，則應使用 Trusted Authentication。若要使用 Windows Authentication 並將其傳遞至資料來源，則需要 Kerberos。

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Figure 18**：設定 Reporting Services Integration 認證
## **Activate Feature**
此設定讓您可以選擇在所有網站集合上啟用 Reporting Services，或只在特定網站集合上啟用。這決定了哪些網站可以使用 Reporting Services。完成後，您應該會看到下圖所示的畫面。

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Figure 19**：Reporting Services 成功與 SharePoint 環境整合

回到圖 14 中顯示的 Report Server URL，我們應該會看到類似下圖的畫面。

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Figure 20**：Reporting Services 與 SharePoint 環境的驗證成功

{{% alert color="primary" %}} 

如果您的 SharePoint 站台已設定 SSL，則不會出現在此清單中。這是已知問題，並不表示有任何錯誤。您的報表仍然可以正常運作。

{{% /alert %}} 

現在，我們即可在 SharePoint 2010 中使用 Reporting Services。與先前的版本相同，當我們配置 Reporting Services Integration 時，會在「Site Collection Feature」中啟用一個功能。此外，安裝程式也會新增 3 個內容類型供我們使用。圖 21 顯示在文件庫中加入了其中兩個內容類型，以建立自訂報表。

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Figure 21**：Report Builder

「**Reporter Builder**」是一個需要在伺服器上下載的 ActiveX 元件，如圖 22 所示。

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Figure 22**：下載並安裝 Report Builder

下載完成後執行 **Report Builder**。現在，我們可以設計第一個報表，如圖 23 所示。

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Figure 23**：Report Builder 新報表產生精靈

建立報表後，我們可以將其儲存在先前建立的文件庫中，將報表放入 SharePoint 2010。

另一個內容類型則用於建立共用連線作為資料來源，並將其儲存在 SharePoint 的文件庫中。我們可以建立文件庫、加入此內容類型，之後就能使用這些連線來變更報表的資料來源。

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Figure 24**：報表成功匯出至 Report Server