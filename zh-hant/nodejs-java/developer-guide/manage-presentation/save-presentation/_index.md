---
title: 在 JavaScript 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/nodejs-java/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預先定義的檢視類型
- 嚴格的 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js 於 JavaScript 中儲存簡報——匯出至 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概述**

[使用 JavaScript 開啟簡報](/slides/zh-hant/nodejs-java/open-presentation/) 描述了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別來開啟簡報。本文章說明如何建立和儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要儲存。使用 Aspose.Slides for Node.js，您可以儲存至 **檔案** 或 **串流**。本文章說明儲存簡報的不同方式。

## **將簡報儲存為檔案**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的 `save` 方法即可將簡報儲存為檔案。將檔案名稱和儲存格式傳遞給此方法。以下範例示範如何使用 Aspose.Slides 儲存簡報。

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 在此執行一些作業...

    // 將簡報儲存至檔案。
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將簡報儲存為串流**

您可以將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的 `save` 方法，將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例中，我們建立新的簡報並將其儲存至檔案串流。

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // 將簡報儲存至串流。
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **使用預先定義的檢視類型儲存簡報**

Aspose.Slides 允許您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/) 類別設定產生的簡報開啟時 PowerPoint 使用的預設檢視。使用 [setLastView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#setLastView) 方法，並傳入 [ViewType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewtype/) 列舉中的值。

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以嚴格的 Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以嚴格的 Office Open XML 格式儲存簡報。儲存時使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/) 類別並設定其 conformance 屬性。如果設定 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)，輸出檔案將以嚴格的 Office Open XML 格式儲存。

以下範例建立簡報並以嚴格的 Office Open XML 格式儲存。

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 以嚴格的 Office Open XML 格式儲存簡報。
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

Office Open XML 檔案是一個 ZIP 壓縮檔，對任意檔案的非壓縮大小、壓縮大小以及整個壓縮檔的總大小皆限制在 4 GB（2^32 位元組），且檔案數量上限為 65,535（2^16‑1）個。ZIP64 格式擴充可將這些限制提升至 2^64。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) 方法允許您在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。

此方法可與以下模式一起使用：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#IfNecessary) 僅在簡報超過上述限制時使用 ZIP64 格式擴充。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Never) 永不使用 ZIP64 格式擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Always) 總是使用 ZIP64 格式擴充。

以下程式碼示範如何在啟用 ZIP64 格式擴充的情況下將簡報儲存為 PPTX：

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
當您使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Never) 進行儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **儲存簡報時不重新整理縮圖**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制將簡報儲存為 PPTX 時的縮圖產生：

- 設為 `true` 時，儲存過程中會重新整理縮圖。這是預設值。
- 設為 `false` 時，保留現有縮圖。如果簡報沒有縮圖，則不會產生任何縮圖。

以下程式碼將簡報儲存為 PPTX，且不重新整理其縮圖。

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
此選項有助於減少儲存 PPTX 格式簡報所需的時間。
{{% /alert %}}

## **以百分比方式儲存進度更新**

儲存進度的回報是透過 [SaveOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/) 及其子類別的 [setProgressCallback](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) 方法設定。提供一個實作 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 介面的 Java 代理；在匯出過程中，回呼會定期接收百分比更新。

以下程式碼片段示範如何使用 `IProgressCallback`。

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // 在此使用進度百分比值。
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose 使用其自有 API 開發了一個免費的 PowerPoint 切割工具應用程式。此應用程式允許您藉由將選取的投影片另存為新的 PPTX 或 PPT 檔案，將簡報切分成多個檔案。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）僅寫入變更？**

否。每次儲存都會產生完整的目標檔案，並不支援增量的「快速儲存」。

**從多個執行緒同時儲存相同的 Presentation 實例是否為執行緒安全？**

否。[Presentation] 實例 [不是執行緒安全](/slides/zh-hant/nodejs-java/multithreading/)；請在單一執行緒中進行儲存。

**儲存時，超連結和外部連結檔案會發生什麼情況？**

[超連結](/slides/zh-hant/nodejs-java/manage-hyperlinks/) 會被保留。外部連結的檔案（例如使用相對路徑的影片）不會自動複製——請確保參考的路徑仍可存取。

**我可以設定/儲存文件的中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的 [文件屬性](/slides/zh-hant/nodejs-java/presentation-properties/)，並會於儲存時寫入檔案。