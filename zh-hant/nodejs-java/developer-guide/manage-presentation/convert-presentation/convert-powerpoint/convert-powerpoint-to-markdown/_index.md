---
title: 在 JavaScript 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 MD
- 簡報轉 MD
- 投影片轉 MD
- PPT 轉 MD
- PPTX 轉 MD
- 將 PowerPoint 儲存為 Markdown
- 將簡報儲存為 Markdown
- 將投影片儲存為 Markdown
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- Markdown 影像匯出
- CDN 影像連結
- PowerPoint
- 簡報
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中將 PPT 和 PPTX 簡報轉換為 Markdown，並控制匯出之點陣圖、圖形檔與 SVG 影像的保存位置與引用方式。"
---
## **概述**

Aspose.Slides for Node.js via Java 可將 PPT 與 PPTX 簡報轉換為 Markdown，用於文件編寫、靜態網站、內容遷移與版本控制工作流程。您可以選擇 Markdown 的語法變體、控制投影片內容的呈現方式，並決定匯出影像的儲存位置以及產生的 Markdown 如何引用它們。

預設情況下，Markdown 匯出僅使用文字輸出。若要匯出視覺內容，請使用 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 方法將匯出類型設定為 [MarkdownExportType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownexporttype/) 列舉中的 `Sequential` 或 `Visual` 值。`Sequential` 會分別且依序呈現投影片項目，而 `Visual` 則將分組項目保留在一起，以維持其視覺關係。`TextOnly` 值不會產生影像資源，因而在此模式下不會呼叫影像儲存回呼。

## **將簡報轉換為 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 方法，並使用 [SaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 列舉中的 `Md` 值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **選擇 Markdown 變體**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 方法控制輸出使用的 Markdown 規範。[Flavor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/flavor/) 列舉包含 CommonMark、GitHub Flavored Markdown 以及其他受支援的變體。

以下範例將簡報匯出為 CommonMark：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **使用預設本機儲存行為匯出影像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 類別提供兩個方法來設定本機儲存的影像：

- [setBasePath](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 指定 Markdown 文件及其資源的基礎目錄。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 指定影像子目錄。其預設值為 `Images`。

以下範例會呈現視覺內容、將影像寫入 `output/assets`，並在 Markdown 文件中建立相對影像參照：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

此行為亦在自訂影像儲存回呼傳回 `false` 時作為備援。

## **自訂影像儲存與 Markdown 連結**

使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 方法註冊回呼，以處理 Markdown 匯出期間產生的非 SVG 點陣圖與圖形檔資源。其 `MarkdownImageSavingHandler` 回呼會接收 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 物件、其 [ImageFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imageformat/) 值，以及以單一字串陣列形式提供的產生的 Markdown 連結。請以提供的格式儲存或上傳影像，並以有效的參照取代 `link[0]`，以出現在 Markdown 輸出中。

以 SVG 格式產生的資源另行處理。使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 方法註冊回呼。其 `MarkdownSvgImageSavingHandler` 回呼會接收一個 `ISvgImage` 物件與單一元素的 `link` 陣列。SVG 不會有 `ImageFormat` 參數；請改以 `ISvgImage.getSvgData` 方法取得 XML 資料，然後寫入或上傳。根據匯出模式與視覺分組，來源簡報中的 SVG 可能在匯出時被點陣化或與其他內容合併；此時產生的非 SVG 資源會傳遞給影像儲存回呼。若每個匯出的視覺資源都需要自訂處理，請同時註冊兩個回呼。

在 Node.js 中，可使用 `java.newProxy` 建立這些回呼介面的實作。

回呼的返回值決定由誰處理影像：

- 返回 `true` 表示回呼已儲存、上傳、轉換或以其他方式處理影像，並已為 `link[0]` 指派有效值。Aspose.Slides 會將該值寫入 Markdown 文件，且不會執行預設的本機儲存。
- 返回 `false` 讓 Aspose.Slides 依照由 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 與 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 設定的值，將影像本機儲存並產生對應連結。

{{% alert color="warning" title="Important" %}}
回呼若傳回 `true`，即表示該回呼負責處理影像。如果回呼傳回 `true` 卻未指派有效且非空的連結，匯出將因 `InvalidOperationException` 而失敗。
{{% /alert %}}

### **將影像儲存至 CDN 原始目錄並使用外部 URL**

以下範例把 `cdn-origin/presentations/quarterly-report` 視為已掛載或同步的 CDN 原始目錄。每個回呼會提取產生的檔名，將影像儲存到該自訂目錄，並以公開的 CDN URL 取代產生的本機參照。此範例本身不會進行網路上傳：只有在目錄已掛載為 CDN 原始或其檔案已發布至 CDN 後，URL 才會有效。若使用物件儲存，請將寫入檔案系統的步驟改為使用儲存 SDK 的上傳操作，並在上傳成功後才指派 `link[0]`。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

點陣圖回呼會故意對小於 128 × 128 像素的影像傳回 `false`，因此 Aspose.Slides 會使用預設行為將這些影像儲存至 `output/fallback-images`。較大的點陣圖、圖形檔以及 SVG 資源則由自訂程式碼處理。例如，產生的本機參照 `fallback-images/image1.png` 會變為 `https://cdn.example.com/presentations/quarterly-report/image1.png`。回呼在寫入檔案時僅使用作業系統路徑；寫入 Markdown 的連結則使用正斜線與 URL 編碼的檔名。建立相對連結時亦請遵循此規則：使用 `/`，而非平台特定的目錄分隔符號。

## **常見問題**

**一個回呼能同時處理點陣圖與 SVG 影像嗎？**

不行。請使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 來處理匯出時產生的點陣圖與圖形檔資源，並使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 來處理以 SVG 產生的資源。前者會提供一個 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 物件與一個 [ImageFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imageformat/) 值；後者會提供一個 `ISvgImage` 物件，您可以透過 `ISvgImage.getSvgData` 讀取 SVG 資料。若來源 SVG 在匯出過程中被點陣化，則會由影像儲存回呼處理。

**當影像儲存回呼傳回 `false` 時會發生什麼事？**

Aspose.Slides 會採用預設的本機儲存行為。影像的存放位置與產生的參照由使用 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 以及 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 所設定的值控制。

**回呼能在不本機儲存影像的情況下提供 URL 嗎？**

可以。回呼可以將影像上傳至物件儲存或傳遞給其他服務，然後將取得的 URL 指派給 `link[0]`，並返回 `true`。回呼必須自行完成所有處理；返回 `true` 會阻止預設的本機儲存。

**為什麼 Markdown 匯出會因回呼拋出 `InvalidOperationException`？**

當回呼返回 `true` 卻未提供有效的連結時，就會拋出此例外。請在返回 `true` 之前，先將應寫入 Markdown 的相對路徑或外部 URL 指派給 `link[0]`。

**影像連結應使用哪種路徑分隔符號？**

在 Markdown 連結與 URL 中請使用正斜線。`path.join` 僅用於檔案系統路徑，Markdown 參照須另行組合或正規化。

**Markdown 匯出時會保留超連結嗎？**

是的。文字[超連結](/slides/zh-hant/nodejs-java/manage-hyperlinks/)會保留為標準的 Markdown 連結。投影片[過渡效果](/slides/zh-hant/nodejs-java/slide-transition/)與[動畫](/slides/zh-hant/nodejs-java/powerpoint-animation/)則不會被轉換。

**可以平行地將多個簡報轉換為 Markdown 嗎？**

可以平行處理不同的簡報檔案，但請勿在執行緒之間共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例。請遵循[多執行緒指引](/slides/zh-hant/nodejs-java/multithreading/)，並為每個檔案使用獨立的實例。