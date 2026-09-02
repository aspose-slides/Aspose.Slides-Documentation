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
- Strict Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Node.js
- JavaScript
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for Node.js 於 JavaScript 中儲存簡報——匯出至 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概述**

[在 JavaScript 中開啟簡報](/slides/zh-hant/nodejs-java/open-presentation/) 說明了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別來開啟簡報。本篇文章闡述如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改既有簡報，完成後都需要將其儲存。使用 Aspose.Slides for Node.js，您可以儲存為 **file** 或 **stream**。本文說明儲存簡報的各種方式。

## **將簡報儲存為檔案**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的 `save` 方法即可將簡報儲存為檔案。將檔名與儲存格式傳入該方法。以下範例示範如何使用 Aspose.Slides 儲存簡報。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 在此執行一些工作...

    // 將簡報儲存至檔案。
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將簡報儲存至串流**

您可以將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的 `save` 方法，以將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例建立新簡報並將其儲存至檔案串流。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
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

Aspose.Slides 允許您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/) 類別設定產生的簡報開啟時 PowerPoint 使用的初始檢視。使用 [setLastView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#setLastView) 方法並傳入 [ViewType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewtype/) 列舉中的值。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以嚴格的 Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以 Strict Office Open XML 格式儲存簡報。儲存時使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/) 類別並設定其 conformance 屬性。若設定 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)，輸出檔案即會以 Strict Office Open XML 格式儲存。

以下範例建立簡報並以 Strict Office Open XML 格式儲存。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 以 Strict Office Open XML 格式儲存簡報。
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

Office Open XML 檔案是 ZIP 壓縮檔，對未壓縮檔案大小、壓縮後檔案大小以及整個封存檔案大小皆限制於 4 GB（2^32 位元組），且封存內的檔案數量上限為 65 535（2^16‑1）。ZIP64 格式擴充可將這些限制提升至 2^64。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) 方法讓您在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。

此方法可搭配以下模式使用：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#IfNecessary) 只在簡報超過前述限制時使用 ZIP64 擴充。此為預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Never) 永不使用 ZIP64 擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Always) 總是使用 ZIP64 擴充。

以下程式碼示範如何在啟用 ZIP64 格式擴充的情況下將簡報儲存為 PPTX 檔案：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
當您使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Never) 儲存時，若簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式的簡報**

處理大型簡報時，您可以調整壓縮等級以在檔案大小與處理時間之間取得平衡。依需求可選擇較快的處理速度或較小的輸出檔案。

Aspose.Slides 提供 [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) 方法，允許您指定在 Office Open XML 格式儲存時使用的壓縮等級。

可用的壓縮等級如下：

- **None**：不進行壓縮，檔案以原始形式儲存。
- **Level1**：最快的壓縮速度，壓縮比例最低。
- **Level2**：較 **Level1** 稍佳的壓縮比例，壓縮速度仍然較快。
- **Level3**：比 **Level2** 提供更好的壓縮效果，對處理時間有中等影響。
- **Level4**：比 **Level3** 提供更好的壓縮效果。
- **Level5**：在 **Level4** 基礎上進一步提升壓縮，同時需要額外的處理時間。
- **Level6**：標準壓縮，於處理速度與檔案大小之間取得良好平衡。此為 *預設壓縮等級*。
- **Level7**：較 **Level6** 提供更好的壓縮，但處理速度較慢。
- **Level8**：較 **Level7** 提供更好的壓縮。
- **Level9**：最高壓縮等級，產生最小的檔案大小，但需最長的處理時間。

以下範例示範如何以 *不壓縮* 的方式將簡報儲存為 PPTX 檔案：

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

此範例示範如何以 *最高壓縮* 的方式將簡報儲存為 PPTX 檔案：

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **儲存簡報時不重新整理縮圖**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制將簡報儲存為 PPTX 時的縮圖產生行為：

- 若設定為 `true`，儲存過程中會重新整理縮圖（預設值）。
- 若設定為 `false`，保留現有縮圖。若簡報沒有縮圖，則不會產生任何縮圖。

以下程式碼示範如何在不重新整理縮圖的情況下將簡報儲存為 PPTX。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
此選項有助於縮短以 PPTX 格式儲存簡報所需的時間。
{{% /alert %}}

## **以百分比儲存進度更新**

儲存進度回報可透過 [setProgressCallback](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) 方法設定於 [SaveOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/) 及其子類別。提供實作了 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 介面的 Java 代理；在匯出過程中，回呼會定期收到百分比更新。

以下程式碼片段說明如何使用 `IProgressCallback`。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
Aspose 已開發一款使用其 API 的 [免費 PowerPoint Splitter 應用程式](https://products.aspose.app/slides/zh-hant/splitter)。該應用程式可將簡報依選取的投影片另存為新 PPTX 或 PPT 檔案，達成分割功能。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）僅寫入變更？**

不支援。每次儲存都會產生完整的目標檔案，未提供增量「快速儲存」功能。

**從多個執行緒同時儲存同一個 Presentation 實例是否安全？**

不安全。 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例 **非執行緒安全**，應僅在單一執行緒中進行儲存。

**儲存時超連結與外部連結檔案會發生什麼情況？**

[Hyperlinks](/slides/zh-hant/nodejs-java/manage-hyperlinks/) 會被保留。外部連結檔案（例如以相對路徑指向的影片）不會自動複製，請確保其路徑仍然可存取。

**是否可以設定/儲存文件的中繼資料（作者、標題、公司、日期）？**

可以。支援標準的 [document properties](/slides/zh-hant/nodejs-java/presentation-properties/)，這些屬性會在儲存時寫入檔案。