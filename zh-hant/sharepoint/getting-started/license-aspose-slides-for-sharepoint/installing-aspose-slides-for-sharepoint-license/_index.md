---
title: 安裝 Aspose.Slides for SharePoint 授權
type: docs
weight: 10
url: /zh-hant/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

當您對評估結果滿意後，就可以[購買授權](https://purchase.aspose.com/buy)。購買之前，請確保您已了解並同意授權訂閱條款。付款完成後，授權將透過電子郵件發送給您。

授權是一個 ZIP 壓縮檔，內含一般的 SharePoint 解決方案套件。壓縮檔包括：

- Aspose.Slides.SharePoint.License.wsp – SharePoint 解決方案套件檔案。授權以 SharePoint 解決方案方式封裝，以便在伺服器農場中輕鬆部署與撤回。
- readme.txt – 授權安裝說明。

{{% /alert %}} 
## **部署授權**
授權安裝透過 **stsadm.exe** 在伺服器主控台執行。

{{% alert color="primary" %}} 

以下段落為了清晰起見，已省略路徑。

{{% /alert %}} 

執行下列步驟以部署 Aspose.Slides for SharePoint 授權：

1. 執行 stsadm 將解決方案加入 SharePoint 解決方案存儲區： 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. 將解決方案部署至農場中的所有伺服器： 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. 執行管理計時工作，以立即完成部署： 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

如果 Windows SharePoint Services Administration 服務未運行，執行部署步驟時會收到警告。**stsadm.exe** 依賴此服務以及 Windows SharePoint Timer Service 來在農場中複製解決方案資料。若這些服務在您的伺服器農場上未啟動，您可能需要在每台伺服器上分別部署授權。 

{{% /alert %}} 
## **測試授權**
要測試授權是否正確安裝，請將任意文件轉換為新格式。若文件中未出現評估水印，即表示授權已成功啟用。