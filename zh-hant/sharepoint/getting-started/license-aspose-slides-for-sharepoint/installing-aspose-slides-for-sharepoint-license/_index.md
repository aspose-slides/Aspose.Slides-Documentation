---
title: 安裝 Aspose.Slides for SharePoint 授權
type: docs
weight: 10
url: /zh-hant/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "在 SharePoint 農場上安裝 Aspose.Slides for SharePoint 授權：將授權方案新增至方案儲存區、部署它，並檢查轉換後的檔案是否已不再顯示評估版浮水印。"
---
{{% alert color="info" title="Note" %}}

一旦您對評估結果滿意，便可以[購買授權](https://purchase.aspose.com/pricing/slides/zh-hant/sharepoint/)。在購買之前，請確認您已了解並同意授權訂閱條款。訂單付款後，授權將以電子郵件形式發送給您。

授權是一個 ZIP 壓縮檔，內含一般的 SharePoint 解決方案套件。壓縮檔包含：

- Aspose.Slides.SharePoint.License.wsp – SharePoint 解決方案套件檔案。授權被打包為 SharePoint 解決方案，以便在伺服器農場中輕鬆部署與回收。
- readme.txt – 授權安裝說明。

{{% /alert %}}

## **部署授權**

授權安裝是透過 **stsadm.exe** 從伺服器主控台執行。

{{% alert color="info" title="Note" %}}

以下段落為了清晰起見，已省略路徑。

{{% /alert %}}

請執行以下步驟以部署 Aspose.Slides for SharePoint 授權：

1. 執行 stsadm 將解決方案新增至 SharePoint 解決方案存儲區：

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. 將解決方案部署至農場中的所有伺服器：

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. 執行管理計時器工作，以立即完成部署：

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

`addsolution` 作業在 `-filename` 中接受方案檔案的路徑；`deploysolution` 作業在 `-name` 中接受已存在於方案存儲區的方案名稱。

{{% alert color="info" title="Note" %}}

如果 SharePoint Administration 服務未執行，執行部署步驟時會收到警告。**stsadm.exe** 依賴此服務以及 SharePoint Timer 服務，將方案資料在農場中複寫。如果這些服務在您的伺服器農場中未執行，您可能需要在每台伺服器上部署授權。

{{% /alert %}}

{{% alert color="info" title="Note" %}}

在 SharePoint 2010 及之後的版本，SharePoint Management Shell Cmdlet `Add-SPSolution`、`Install-SPSolution` 與 `Start-SPAdminJob` 對應到 `addsolution`、`deploysolution` 與 `execadmsvcjobs` 作業。請參閱[Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping)。

{{% /alert %}}

## **測試授權**

要測試授權是否已正確安裝，請將任意簡報轉換為新格式。如果轉換後的檔案中沒有評估版水印，表示授權已生效。