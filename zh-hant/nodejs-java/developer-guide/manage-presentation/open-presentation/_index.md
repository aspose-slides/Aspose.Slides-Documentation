---
title: 在 JavaScript 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/nodejs-java/open-presentation/
keywords:
- 開啟 PowerPoint
- 開啟 OpenDocument
- 開啟簡報
- 開啟 PPTX
- 開啟 PPT
- 開啟 ODP
- 載入簡報
- 載入 PPTX
- 載入 PPT
- 載入 ODP
- 受保護的簡報
- 大型簡報
- 外部資源
- 二進位物件
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 透過 Java，輕鬆開啟 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）簡報――快速、可靠、功能完整。"
---
## **簡介**

除了從零開始建立 PowerPoint 簡報之外，Aspose.Slides 還允許您開啟現有的簡報。載入簡報後，您可以取得其資訊、編輯投影片內容、加入新投影片、移除現有投影片，以及其他操作。

## **開啟簡報**

要開啟現有的簡報，請實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別，並將檔案路徑傳入其建構函式。

以下 JavaScript 範例示範如何開啟簡報並取得投影片數量：

```js
// 實例化 Presentation 類別並將檔案路徑傳入其建構函式。
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // 印出簡報中投影片的總數。
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **開啟受密碼保護的簡報**

當您需要開啟受密碼保護的簡報時，請透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/) 類別的 [setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword) 方法傳入密碼以解密並載入。以下 JavaScript 程式碼示範此操作：

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // 在已解密的簡報上執行操作。
} finally {
    presentation.dispose();
}
```

## **開啟大型簡報**

Aspose.Slides 提供選項——尤其是 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/) 類別中的 [getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) 方法——協助您載入大型簡報。

以下 JavaScript 程式碼示範載入大型簡報（例如 2 GB）：

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // 大型簡報已載入並可使用，且記憶體消耗保持低。
    
    // 對簡報進行變更。
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // 將簡報儲存至另一個檔案。此操作期間記憶體消耗保持低。
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // 不要這麼做！將拋出 I/O 例外，因為檔案在釋放簡報物件前會被鎖定。
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// 在此執行是可以的。來源檔案已不再被簡報物件鎖定。
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
為了解決使用串流時的某些限制，Aspose.Slides 可能會複製串流的內容。從串流載入大型簡報會導致簡報被複製，進而減慢載入速度。因此，當您需要載入大型簡報時，我們強烈建議使用簡報檔案路徑，而非串流。

建立包含大型物件（影片、音訊、高解析度影像等）的簡報時，您可以使用 [BLOB management](/slides/zh-hant/nodejs-java/manage-blob/) 以降低記憶體使用量。
{{%/alert %}}

## **控制外部資源**

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iresourceloadingcallback/) 介面，讓您管理外部資源。以下 JavaScript 程式碼示範如何使用 `IResourceLoadingCallback` 介面：

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // 載入替代圖像。
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 設定替代 URL。
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // 跳過所有其他圖像。
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **載入不含內嵌二進位物件的簡報**

PowerPoint 簡報可能包含以下類型的內嵌二進位物件：

- VBA 專案（可透過 [Presentation.getVbaProject](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getVbaProject) 取得）；
- OLE 物件內嵌資料（可透過 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 取得）；
- ActiveX 控制項二進位資料（可透過 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/control/#getActiveXControlBinary) 取得）。

透過 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 方法，您可以載入不含任何內嵌二進位物件的簡報。

此方法對於移除可能的惡意二進位內容很有用。以下 JavaScript 程式碼示範如何載入不含任何內嵌二進位內容的簡報：

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // 在簡報上執行操作。
} finally {
    presentation.dispose();
}
```

## **常見問題**

**如何判斷檔案已損毀且無法開啟？**

載入時會拋出解析/格式驗證例外。此類錯誤通常會提及 ZIP 結構無效或 PowerPoint 記錄損壞。

**開啟時如果缺少必要的字型會發生什麼情況？**

檔案仍會開啟，但之後的 [rendering/export](/slides/zh-hant/nodejs-java/convert-presentation/) 可能會替換字型。請於執行環境中 [Configure font substitutions](/slides/zh-hant/nodejs-java/font-substitution/) 或 [add the required fonts](/slides/zh-hant/nodejs-java/custom-font/)。

**開啟時內嵌的媒體（影片/音訊）會如何處理？**

它們會作為簡報資源可供使用。如果媒體是透過外部路徑引用，請確保這些路徑在您的環境中可存取；否則在 [rendering/export](/slides/zh-hant/nodejs-java/convert-presentation/) 時可能會省略該媒體。