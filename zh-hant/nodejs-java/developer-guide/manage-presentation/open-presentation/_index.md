---
title: 在 JavaScript 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/nodejs-java/open-presentation/
keywords:
- 開啟 PowerPoint
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
description: "了解如何在 JavaScript 中開啟 PowerPoint 與 OpenDocument 簡報、提供開啟密碼、控制資源載入，並使用 Aspose.Slides for Node.js via Java 減少記憶體使用。"
---
## **簡介**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/zh-hant/nodejs-java/) 可以從檔案與串流載入 PowerPoint 與 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始或其他支援的格式儲存。

載入行為可透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/) 類別自訂。例如，您可以提供開啟密碼、將大型二進位物件保留在 Node.js 記憶體之外、控制外部資源，或省略嵌入的二進位資料。

## **開啟簡報**

若要開啟現有的簡報，將檔案路徑傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 建構式。使用完畢後請釋放簡報，以便及時釋放檔案句柄、暫存資料與其他資源。

以下 JavaScript 範例顯示如何開啟簡報並取得投影片數量：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **開啟受密碼保護的簡報**

開啟密碼會加密簡報內容。若要載入完整簡報，請將正確的密碼傳遞給 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword) 並將選項提供給 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 建構式。若密碼缺失或不正確，載入會失敗。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

關於密碼偵測、驗證與加密工作流程，請參閱 [Password-Protect Presentations](/slides/zh-hant/nodejs-java/password-protected-presentation/)。若已加密的簡報刻意以公開的文件屬性儲存，這些屬性可在未提供密碼的情況下讀取；請參閱 [Manage Presentation Properties](/slides/zh-hant/nodejs-java/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) 會回傳控制 Aspose.Slides 如何處理圖像、音訊與影片等大型二進位物件的選項。您可以保持來源檔案鎖定、允許暫存檔案，並限制保留於記憶體中的 BLOB 資料量。

以下 JavaScript 程式碼示範載入大型簡報（例如 2 GB）：

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
使用 [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) 時，來源檔案會保持鎖定，直到釋放簡報實例為止。請勿在該實例存活期間搬移、覆寫或刪除來源檔案。

Aspose.Slides 可能會在載入時複製輸入串流的內容。對於大型簡報，檔案路徑通常比串流更有效率。請參閱 [Manage BLOBs](/slides/zh-hant/nodejs-java/manage-blob/) 以瞭解其他儲存與記憶體管理選項。
{{% /alert %}}

## **控制外部資源**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) 接受一個 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iresourceloadingcallback/) 實作。回呼可提供替代資料、重新導向資源、使用預設載入器，或略過該資源。當簡報包含必須依照應用程式特定安全或儲存規則解析的外部圖像時，此功能相當有用。

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **載入不含嵌入二進位物件的簡報**

簡報可能包含應用程式不需要或不想保留的嵌入二進位資料。範例包括：

- 透過 [Presentation.getVbaProject](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getVbaProject) 取得的 VBA 專案；
- 透過 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 取得的嵌入 OLE 資料；
- 透過 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/control/#getActiveXControlBinary) 取得的 ActiveX 控制項資料。

將 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 設為 `true`，即可在載入時移除這些二進位資料。將載入後的簡報儲存，即可保留已清理的結果。

此選項可減少不必要的嵌入載荷暴露，但它並非完整的惡意程式偵測或內容清理系統。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**如何判斷檔案已損毀且無法開啟？**

Aspose.Slides 會在載入期間拋出解析或格式例外。請將此失敗與密碼錯誤分開處理，以便應用程式能正確回報原因。

**若缺少必要的字型會發生什麼情況？**

簡報仍可載入，但在渲染與匯出時可能會替換字型。您可以 [設定字型替換](/slides/zh-hant/nodejs-java/font-substitution/) 或 [提供自訂字型](/slides/zh-hant/nodejs-java/custom-font/) 以使輸出更可預測。

**載入簡報時是否也會載入其嵌入的媒體？**

嵌入的音訊與影片會透過簡報物件模型可用。外部資源的解析則依照已設定的資源載入行為進行，若無法存取其位置，則可能無法使用。