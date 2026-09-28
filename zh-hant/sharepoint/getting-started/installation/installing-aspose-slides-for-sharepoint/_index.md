---
title: 安裝 Aspose.Slides for SharePoint
type: docs
weight: 10
url: /zh-hant/sharepoint/installing-aspose-slides-for-sharepoint/
description: "在 SharePoint 伺服器平台上安裝 Aspose.Slides for SharePoint：選取適用於您的 SharePoint 版本的安裝程式，執行系統檢查，並部署與啟用解決方案。"
---
## **套件內容**

Aspose.Slides for SharePoint 可從[下載頁面](https://releases.aspose.com/slides/sharepoint/) 下載為 ZIP 壓縮檔。該壓縮檔包含每個受支援的 SharePoint 版本的一個 SharePoint 解決方案套件 (WSP) 與一個安裝程式：

| SharePoint 版本 | 安裝程式 | 解決方案套件 |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

每個安裝程式旁邊都有一個組態檔 (例如 *Setup2019.exe.config*)，其指明它所安裝的解決方案套件。*License* 資料夾中包含最終使用者授權協議的連結以及第三方授權聲明。

Aspose.Slides for SharePoint 以 SharePoint 解決方案的形式封裝，SharePoint 會將其部署至整個伺服器平台。其功能隨後可依網站集合進行啟用或停用。

## **安裝程序**

安裝之前，安裝程式會執行系統檢查。它會驗證以下事項：

- 伺服器上已安裝 SharePoint。
- 目前使用者具有安裝與部署 SharePoint 解決方案的權限。
- SharePoint Administration 服務已啟動。
- SharePoint Timer 服務已啟動。
- 組態檔中指定的解決方案套件已存在。

需要 Administration 與 Timer 服務，因為某些安裝動作以計時工作方式執行，將解決方案傳播至平台內的所有伺服器。

### **執行安裝**

若要安裝 Aspose.Slides for SharePoint：

1. 將 ZIP 壓縮檔解壓縮至 SharePoint 平台中某台伺服器的本機磁碟機。
2. 執行與您的 SharePoint 版本相符的安裝程式（參見上表），並依照螢幕上的指示操作。該安裝程式會：
   1. 執行系統檢查。若任一檢查失敗，安裝程序將停止。

      **執行系統檢查**

      ![安裝程式的系統檢查畫面](installing-aspose-slides-for-sharepoint_1.png)

   2. 顯示最終使用者授權協議。必須接受才能繼續。

      **授權協議**

      ![安裝程式的授權協議畫面](installing-aspose-slides-for-sharepoint_2.png)

   3. 顯示部署目標。請選取要啟用功能的網路應用程式與網站集合。

      **選取部署目標**

      ![安裝程式的網站集合部署目標畫面](installing-aspose-slides-for-sharepoint_3.png)

   4. 將解決方案部署至平台。

      **安裝進度**

      ![安裝程式的安裝進度畫面](installing-aspose-slides-for-sharepoint_4.png)

   5. 在所選網站集合上啟用 Aspose.Slides for SharePoint。
   6. 列出已部署與啟用解決方案的網路應用程式與網站集合。

      **安裝成功**

      ![安裝程式的安裝完成畫面](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
此螢幕截圖是於 SharePoint 2007 上拍攝。較新版本的安裝程式會顯示相同的畫面。
{{% /alert %}}

如果已安裝相同版本的 Aspose.Slides for SharePoint，安裝程式會提供修復或移除的選項。若已安裝其他版本，則會提供升級或移除的選項。

安裝完成後，於所選網站集合的文件庫檔案功能表中會出現 **Convert via Aspose.Slides** 項目（於 SharePoint 2007 中為 **Convert with Aspose.Slides**）。若要轉換第一個簡報，請參考[將 Microsoft PowerPoint 文件轉換為其他格式](/slides/zh-hant/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/)。解決方案對平台的新增功能說明請參見[部署與啟用](/slides/zh-hant/sharepoint/deployment-and-activation/)。

## **常見問答**

**我要執行哪個安裝程式？**

執行與您的 SharePoint 版本相符的安裝程式。例如，在 SharePoint Server 2016 平台上執行 *Setup2016.exe*。每個安裝程式僅安裝其對應的解決方案套件。

**授權版本需要另外下載嗎？**

不需要。相同的套件在評估模式下即可使用，直至您安裝授權解決方案；請參閱[安裝 Aspose.Slides for SharePoint 授權](/slides/zh-hant/sharepoint/installing-aspose-slides-for-sharepoint-license/)。

**我要如何移除產品？**

再次執行相同的安裝程式並選取 **Remove**；請參閱[解除安裝 Aspose.Slides for SharePoint](/slides/zh-hant/sharepoint/uninstalling-aspose-slides-for-sharepoint/)。