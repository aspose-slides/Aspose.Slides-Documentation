---
title: 在 Node.js 中將 PowerPoint 簡報轉換為 HTML
linktitle: PowerPoint 轉 HTML
type: docs
weight: 30
url: /zh-hant/nodejs-java/convert-powerpoint-to-html/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 HTML
- 簡報轉 HTML
- 投影片轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- 將 PowerPoint 儲存為 HTML
- 將簡報儲存為 HTML
- 將投影片儲存為 HTML
- 將 PPT 儲存為 HTML
- 將 PPTX 儲存為 HTML
- 匯出 PPT 為 HTML
- 匯出 PPTX 為 HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中將 PowerPoint 簡報轉換為 HTML。使用 Aspose.Slides for Node.js via Java 匯出 PPT 與 PPTX 檔案、選取的投影片、備註、字型、影像、SVG 與媒體。"
---
## **概述**

Aspose.Slides for Node.js via Java 可以在不使用 Microsoft PowerPoint 的情況下，將 PowerPoint 簡報儲存為 HTML。基本的轉換只需要載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)，然後使用 [SaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 呼叫 `save`。當需要控制匯出佈局、字型、影像、備註、評論、SVG 輸出或連結資源時，請使用 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmloptions/)。

本指南聚焦於實用的 HTML 匯出情境：

- 匯出完整簡報或選取的投影片。
- 產生固定版面、響應式或基於 SVG 的 HTML。
- 包含講者備註與評論。
- 控制影像品質與裁切的影像資料。
- 嵌入字型或將字型檔案分別儲存。
- 選擇外部資源與媒體檔案的寫入與參照方式。

預設情況下，HTML 匯出會產生一個自包含的 HTML 文件，絕大多數資源皆會嵌入其中。這對於共享單一檔案很方便，但會增加輸出尺寸。若用於網站發布，請考慮使用外部資源、降低影像 DPI，並僅嵌入目標環境中不可靠取得的字型。

## **將簡報轉換為 HTML**

要將簡報匯出為 HTML，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 載入，然後使用 [SaveFormat.Html](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 進行 `save`。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

此範例會寫入一個 HTML 檔案。`finally` 區塊會釋放簡報物件，以關閉檔案句柄與渲染資源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmloptions/) 是 HTML 匯出的主要設定類別。常用設定包括：

- `SlidesLayoutOptions`：新增備註、評論、講義或其他版面資訊。
- `HtmlFormatter`：變更 HTML 文件結構，或將格式化委託給控制器。
- `SlideImageFormat`：變更投影片的表示方式，例如以 SVG。
- `PicturesCompression`：控制影像 DPI 與輸出大小。
- `DeletePicturesCroppedAreas`：保留或移除裁切的影像資料。
- `SvgResponsiveLayout`：使匯出的 SVG 內容適應其容器。
- `ShowHiddenSlides`：在需要時包含隱藏投影片。

以下章節分別說明最常用的選項，讓您只結合工作流程需要的設定。

## **將選取的投影片轉換為 HTML**

`Presentation.save` 的重載可接受投影片編號，採用 1 為起始的投影片位置。以下迴圈會將每張投影片儲存為獨立的 HTML 檔案。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

當網站或應用程式需要每張投影片對應一個 HTML 頁面時，請使用此模式。如果每張投影片應使用相同的版面，請建立一個 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmloptions/) 實例，並在每次 `save` 呼叫時傳入它。

## **建立響應式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/responsivehtmlcontroller/) 透過 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmlformatter/) 提供響應式 HTML 輸出。當匯出的頁面需要更好地適應瀏覽器寬度時，請使用它。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

若要使用基於 SVG 的響應式版面，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmloptions/) 上設定 `SvgResponsiveLayout`。當投影片內容以可縮放 SVG 標記匯出時，此功能很有用。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **包含講者備註與評論**

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 並透過 `HtmlOptions.setSlidesLayoutOptions` 來包含講者備註或評論。除非您指定其位置，否則備註與評論預設為隱藏。

假設來源簡報包含講者備註：

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

以下程式碼會將投影片內容與講者備註（位於投影片下方）匯出。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

匯出的 HTML 包含備註區域：

![HTML output with the slide and speaker notes](HTML_with_notes.png)

若要匯出評論，請設定 `CommentsPosition`，例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`。如果只需要評論，請省略 `NotesPosition`。若同時需要備註與評論，則兩個屬性皆需設定。

## **控制影像品質與裁切區域**

HTML 匯出可以壓縮投影片影像以縮小輸出大小。當需要更高影像品質時，請將 `PicturesCompression` 設定為 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturescompression/) 中的某個值。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

預設情況下，影像的裁切區域可能會從匯出結果中移除。僅在使用者必須能夠恢復或檢查那些隱藏影像部分時才保留裁切資料。保留裁切資料會增加 HTML 大小。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **加入 CSS**

若僅需簡易樣式，可將 CSS 字串傳遞給 `HtmlFormatter.createDocumentFormatter`。這會更改 HTML 文件的外觀，而 Aspose.Slides 仍會負責渲染投影片內容。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

若需要自訂文件標頭、連結的 CSS 檔案，或在投影片與圖形周圍加入自訂標記，請使用 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmlformatter/) 搭配格式化控制器。

## **嵌入字型**

如果目標環境可能未安裝簡報所使用的字型，請使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) 將字型嵌入 HTML。嵌入可提升視覺相似度，但會增加輸出大小。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

只有在確信目標瀏覽器或系統已提供該字型時才排除嵌入。對於品牌字型或不常見字型，嵌入通常較安全。

## **以連結字型檔案取代嵌入**

為了減少 HTML 檔案大小，您可以將字型資料寫入個別的 WOFF 檔案，並在 HTML 中加入 `@font-face` 規則。在 Node.js via Java 中，通常會以繼承自 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) 的小型 Java 輔助類別來實作此情境，將字型位元組寫入輸出目錄，並將 `@font-face` 規則注入產生的 HTML。編譯此輔助類別，加入至 Node.js 模組的 classpath，然後在 JavaScript 中以 `java.newInstanceSync` 建立實例。

在建構此類輔助工具時，需慎選兩條路徑：

- 檔案系統的輸出路徑，用於寫入產生的字型檔案。
- URL 路徑，瀏覽器會從 HTML 文件中使用此路徑載入字型檔案。

## **外部儲存資源**

自包含的 HTML 易於搬移，但內嵌的 Base64 資源會使檔案變大。如果您的應用程式需要外部的影像、字型、音訊或影片檔案，請使用可將資源寫入指定目錄並產生瀏覽器可見 URL 的匯出控制器。確保檔案系統路徑與 URL 路徑與您的部署版面保持一致。

## **匯出媒體檔案**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) 會匯出影片與音訊檔案，並產生可在瀏覽器播放它們的 HTML。其建構子接受以下參數：

- `path`：產生的媒體檔案寫入的目錄。
- `fileName`：正在產生的 HTML 檔名。
- `baseUri`：HTML 中連結至媒體檔案時使用的絕對 URI 前綴。

例如，HTML 檔案為 `html-output/presentation.html`，媒體檔案儲存在 `html-output/media`，`path` 應指向磁碟上的 media 目錄，而 `baseUri` 應指向瀏覽器觀點下同一目錄的路徑。若為本機預覽，可從媒體目錄建立 `file:///` URI；若為部署的應用程式，則使用已發布媒體目錄的絕對 URL。

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

請為每次匯出作業使用唯一的輸出目錄，特別是在伺服器應用程式中。共用的輸出路徑可能導致不同轉換的檔案相互覆寫。

## **效能與資源管理**

HTML 轉換是一項渲染操作，處理時間與記憶體使用量取決於投影片數量、影像解析度、字型、特效、圖表以及嵌入的媒體。較高的 `PicturesCompression` DPI 值、嵌入字型、SVG 輸出與保留裁切影像區域可提升相似度，但通常會增加輸出大小。

對於批次轉換：

- 盡快處置每個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例。
- 為不同作業使用獨立的輸出目錄。
- 除非相似度需求，否則避免嵌入常見字型。
- 當 HTML 用於預覽或縮圖時，降低影像 DPI。
- 在部署路徑確定前，保留來源簡報、產生的 HTML 與外部資源在同一位置。

## **常見問題**

**HTML 輸出中會保留超連結嗎？**

是。簡報中的超連結會匯出為 HTML，且在目標 URL 有效時仍可點擊。

**我可以平行地將簡報轉換為 HTML 嗎？**

是，但請勿在多個工作者之間共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例。請使用獨立的簡報實例、獨立的串流與獨立的輸出目錄來處理不同檔案。詳情請參閱 [多執行緒指引](/slides/zh-hant/nodejs-java/multithreading/)。

**Presentation 物件是執行緒安全的嗎？**

不是。單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例應於同一個工作者內載入、修改、儲存並釋放。若要平行作業，請為每個工作者或每個程序建立獨立的實例。

**為什麼產生的 HTML 檔案很大？**

預設的匯出會直接將資源嵌入 HTML。嵌入的字型、高 DPI 影像、媒體、SVG 內容以及保留的裁切影像區域都會增加檔案大小。若較小的輸出比最高相似度更重要，請使用外部資源、排除常見字型的嵌入，並降低 `PicturesCompression`。

**為什麼 PowerPoint 中的字型大小，例如 24 pt，在 HTML 中顯示為 17.999819 pt？**

這可能是因為 PowerPoint 與 HTML 使用不同的 DPI 模型。PowerPoint 以 72 DPI 為基礎的排版點 (typographic points) 儲存文字大小，而 HTML 版面則基於 96 DPI 的 CSS 像素。Aspose.Slides 在將簡報匯出為 HTML 時，會在這兩個系統之間轉換字型大小，轉換過程中可能產生微小的四捨五入差異。

這些數值並不代表實際的視覺字型大小變化；它們僅是 PowerPoint 與 HTML 之間文字度量轉換的數學副作用。

**應該如何選擇 media 匯出的 baseUri？**

請從瀏覽器的角度選擇 `baseUri`，並以絕對 URI 形式傳入。對於本機預覽，可從輸出目錄產生 `file:///` URI；對於部署，請使用已發布媒體目錄的絕對 URL。檔案系統的 `path` 與瀏覽器的 `baseUri` 不必是相同的字串，但必須指向同一資源位置。

**我可以包含隱藏投影片嗎？**

可以。當需要匯出隱藏投影片時，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmloptions/) 上將 `ShowHiddenSlides` 設為 `true`。