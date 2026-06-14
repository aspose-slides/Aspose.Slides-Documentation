---
title: 將 Aspose.Slides 與 Google Slides 整合
linktitle: Google Slides
type: docs
weight: 50
url: /zh-hant/net/integrating-aspose-slides-with-google-slides/
keywords:
- 雲端平台
- 雲端整合
- Google Slides
- Google Drive
- Google API
- Google 服務帳戶
- SaaS 整合
- OAuth 2.0
- PPT 轉 PDF
- PowerPoint 自動化
- 簡報處理
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "將 Aspose.Slides 與 Google Slides 連接，以匯入、同步與轉換簡報，自動化工作流程，並在同一管線中保留 PowerPoint 與 OpenDocument。"
---
## **簡介**

Aspose.Slides 現在透過其 [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) 提供與 Google Slides 與 Google Drive 的整合。此整合讓 .NET 應用程式能夠轉換、編輯、下載與上傳 Google Slides 簡報。

## **什麼是 Google Slides？**
[Google Slides](https://workspace.google.com/products/slides/zh-hant/) 是 Google 開發的免費線上簡報軟體。它讓使用者能夠在線上建立、編輯與分享簡報，類似 Microsoft PowerPoint。它支援即時協作、雲端儲存，且可在任何具網路連線的裝置上使用。

## **Google API**
在使用 Aspose.Slides 透過 Google Slides 簡報之前，您必須建立 Google API 專案並建立一個 [Google Cloud 專案](https://developers.google.com/workspace/guides/create-project)，然後啟用所需的 API。

接著您需要選擇存取 Google API 的方式——[Aspose.SlideS Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) 支援兩種存取方式：
- `Google Service Account`
- `OAuth 2.0` with user interaction via a browser.

### **Google 服務帳戶**
服務帳戶是一種特殊的 Google 帳戶，供應用程式或伺服器在沒有使用者互動的情況下以程式方式存取 Google API。它通常用於後端系統或自動化任務。服務帳戶透過 JSON 金鑰檔案進行驗證，並擁有自己的電子郵件地址。可透過 [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) 指派特定權限，且常與 Google Drive、Sheets 或 BigQuery 等 API 搭配使用，以實現安全、 automatised 的資源存取。

### **OAuth 2.0**
另一種常見的存取 Google API 方式是透過 OAuth 2.0 並在瀏覽器中與使用者互動。在此流程中，使用者會被導向 Google 登入頁面，授權應用程式。授權完成後，應用程式會收到授權碼，進而兌換取得存取令牌與重新整理令牌。

存取令牌允許暫時存取 Google API，而重新整理令牌則可儲存並重複使用，以在不需再次登入的情況下取得新的存取令牌。這表示瀏覽器互動僅在首次授權時需要，之後的 API 存取即可全自動化。此方式通常用於需要在使用者同意下存取其資料（如 Gmail、Calendar 或 Drive）的應用程式。

## **讓我們開始編寫程式**
首先，將 [Aspose.Slides SaaS Integration NuGet package](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) 加入您的專案：

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **範例 1**
以下範例示範如何從 Google Drive 下載 Google Slides 簡報，並將其保存為本機磁碟上的 PDF 檔案。我們將使用 Google 服務帳戶進行授權，前提是已經下載了服務帳戶的 JSON 憑證檔案。

```csharp
// 建立外部管理的 HttpClient
HttpClient httpClient = new HttpClient();

// 使用服務帳戶 JSON 檔案建立授權提供者
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// 使用授權提供者初始化 Google Slides 整合服務
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// 依檔案 ID 從 Google Drive 載入簡報至 Aspose.Slides IPresentation 實例
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// 如有需要修改簡報（例如，移除第二張投影片）
pres.Slides.RemoveAt(1);

// 將簡報本地保存為 PDF 檔案
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

為了方便起見，Aspose.Slides SaaS Integration 提供了一個方法，可列出使用者可存取的所有檔案。返回的資料包含檔案名稱、MIME 類型與檔案 ID。

```csharp
// 取得提供的服務帳戶可用的檔案清單
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

另一種取得檔案 ID 的方式是打開 Google Slides 網頁應用程式中的簡報，並在 URL 中找到它。

例如，以下 URL：

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

檔案 ID 為：

```
1A2B3C4D5E6F7G8H9I0J
```

## **範例 2**
接下來的範例示範如何從頭建立 PowerPoint 簡報，並以 Google Slides 格式上傳至 Google Drive。授權方面，我們將使用 OAuth 2.0。

```csharp
// 建立外部管理的 HttpClient
HttpClient httpClient = new HttpClient();

// 使用 OAuth 及 client ID、client secret 建立授權提供者
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// 使用授權提供者初始化 Google Slides 整合服務
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// 建立範例簡報
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // 將簡報儲存至 Google Drive 根資料夾，格式為 Google Slides
    // 您也可以選擇 Aspose.Slides 支援的其他匯出格式
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

如果在您的應用程式中使用此類授權，`interaction with the browser is required`。您需要選擇您的帳戶並確認允許應用程式存取您的 Google Drive API。就這樣——此操作僅在第一次執行時需要。

### **範例 3**
以下範例使用事先取得的存取令牌。`GoogleAccessTokenAuthProvider` 是 `IGoogleAuthorizationProvider` 介面的實作，它使用現有的 OAuth 2.0 存取令牌來授權對 Google API 的請求。與會自行啟動或管理 OAuth 流程的提供者不同，此類別依賴呼叫方提供有效的存取令牌。

此提供者適用於存取令牌由外部取得的系統──通常由前端應用程式或其他服務取得，然後傳遞給後端。特別適合分散式環境，因為在伺服器端管理重新整理令牌可能會因同時刷新而導致令牌失效的風險或複雜度。

此範例示範如何在 Google Drive 上取代檔案並更新檔名，同時保留其檔案 ID。

```csharp
// 為發送請求建立 HTTP 用戶端
using HttpClient httpClient = new HttpClient();

// 使用存取令牌設定 Google Drive 驗證
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// 使用驗證與 HTTP 用戶端初始化 Google Slides/Drive 整合
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// 建立使用 Aspose.Slides 的範例簡報
using (var presentation = new Presentation())
{
    // 在第一張投影片加入矩形形狀並設定其文字
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // 定義 PDF 儲存選項，包含特定品質與符合性設定
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // 以檔案 ID 在 Google Drive 上儲存（取代）現有檔案、更新名稱，並匯出為 PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // Google Drive 上現有檔案的 ID
        GoogleSaveFormatType.Pdf,         // 欲儲存的目標格式
        saveOptions,           
        "NewFileName.pdf"                 // 指定給檔案的新名稱
    );
}
```

## **摘要**
Aspose.Slides 現在支援額外的檔案格式管理，簡化了在雲端工作流程中建立、分享與編輯簡報的自動化。

本文說明了基本功能。您亦可將檔案儲存至子資料夾、取代現有檔案，並以各種格式（不僅限於 Google Slides 簡報）匯出至 Google Drive。

Aspose.Slides SaaS Integration 將持續擴充對簡報 SaaS 平台的支援，請持續關注未來更新。

## **常見問題**

**我需要 Google Workspace 帳戶才能使用此整合嗎？**  
不需要。您可以使用免費的 Google 帳戶或 Google Workspace 帳戶。所需的存取權限取決於您在 Google Drive 與 Slides 上的權限設定。

**應該選擇哪種驗證方式——服務帳戶或 OAuth 2.0？**  
對於無使用者互動的後端或自動化工作流程，請使用 **服務帳戶**。  
如果需要在使用者同意下存取特定使用者的 Google Slides 或 Drive 檔案，請使用 **OAuth 2.0**。

**我可以處理除 Google Slides 之外的格式嗎？**  
可以。Aspose.Slides 允許在上傳至 Google Drive 前，先將簡報另存為各種格式（例如 PDF、PPTX、HTML 等）。

**如何取得 Google Slides 簡報的檔案 ID？**  
您可以使用 `GetDriveFileInfosAsync()` 方法取得，或直接從 Google Slides 簡報的 URL 複製。

**整合是否支援在 Google Drive 上取代現有檔案？**  
是的。使用 `SavePresentationToExistingFileAsync` 方法即可在保留檔案 ID 的前提下更新檔案。

**使用 OAuth 2.0 時是否每次都需要瀏覽器互動？**  
不需要。瀏覽器互動僅在首次授權時需要。之後，儲存的重新整理令牌可用於自動化存取。