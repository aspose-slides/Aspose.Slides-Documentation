---
title: 安裝 Aspose.Slides for SharePoint
type: docs
weight: 10
url: /zh-hant/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint 會以 Aspose.Slides.SharePoint.zip 壓縮檔下載。此壓縮檔包含：

- **Aspose.Slides.SharePoint.wsp**：SharePoint 解決方案檔案。Aspose.Slides for SharePoint 以 SharePoint 解決方案的形式封裝，以便在伺服器農場中進行啟用與停用。
- **Aspose_LicenseAgreement.rtf**：最終使用者授權協議。
- **Setup.exe**：安裝程式。
- **Setup.exe.config**：安裝設定檔。

{{% /alert %}} 
## **安裝程序**
在執行安裝之前，安裝程式會檢查以下條件：

- 已安裝 WSS 3.0 或 MOSS 2007。
- 使用者具有安裝 SharePoint 解決方案的權限。
- SharePoint 資料庫已上線。
- WSS 管理服務已啟動。
- WSS 計時服務已啟動。

需要 WSS 管理服務與計時服務，因為某些安裝動作依賴計時工作將變更傳播至伺服器農場的所有伺服器。 
### **執行安裝**
若要安裝 Aspose.Slides for SharePoint：

1. 將 Aspose.Slides.SharePoint zip 解壓縮到 MOSS 7.0 或 WSS 3.0 伺服器的本機磁碟。
2. 執行 setup.exe 並依照畫面指示操作。安裝程式會執行以下動作：
   1. 檢查安裝前提條件。如果任一檢查失敗，安裝程序將不會繼續。

      **Running a systems check**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)

3. 顯示最終使用者授權協議。必須接受該協議才可繼續。

   **授權協議**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)

4. 顯示部署目標的選擇畫面。選擇要為其啟用功能的 Web 應用程式和網站集合。

   **選擇部署目標**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)

5. 將功能部署至伺服器農場。

   **安裝進度條**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)

6. 為所選的網站集合啟用 Aspose.Slides，並設定其父層 Web 應用程式。
7. 顯示已部署並啟用功能的 Web 應用程式與網站集合清單。

   **安裝成功**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)