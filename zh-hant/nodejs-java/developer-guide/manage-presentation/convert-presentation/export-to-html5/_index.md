---
title: 在 JavaScript 中將簡報轉換為 HTML5
linktitle: 簡報到 HTML5
type: docs
weight: 40
url: /zh-hant/nodejs-java/export-to-html5/
keywords:
- PowerPoint 轉換為 HTML5
- OpenDocument 轉換為 HTML5
- 簡報轉換為 HTML5
- 投影片轉換為 HTML5
- PPT 轉換為 HTML5
- PPTX 轉換為 HTML5
- ODP 轉換為 HTML5
- 將 PPT 儲存為 HTML5
- 將 PPTX 儲存為 HTML5
- 將 ODP 儲存為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 將 PowerPoint 與 OpenDocument 簡報匯出為響應式 HTML5。保留格式、動畫與互動性。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Node.js via Java 將 PowerPoint 簡報轉換為 HTML5。它涵蓋基本匯出、形狀動畫和投影片過渡的控制以及註解佈局。它同時比較 HTML5 輸出與標準 HTML 匯出的 SVG 為基礎的輸出。

## **將 PowerPoint 匯出為 HTML5**

以下範例從工作目錄載入簡報，並以 HTML5 格式儲存。它使用預設的匯出設定；下一個範例示範如何明確控制動畫播放。請將輸入路徑取代為您的簡報路徑。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
除了 HTML 文件外，匯出還會寫入用於投影片樣式、動畫、效果與導覽的相關 CSS 和 JavaScript 檔案。移動或發佈輸出時，請將這些檔案與 HTML 文件一起保留。產生的頁面同時會從公共 CDN 載入 jQuery 與 Anime.js；若未載入這些檔案，投影片導覽與動畫將無法執行。
{{% /alert %}}

若要在匯出時不播放形狀動畫或投影片過渡，請在 [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) 中將 `false` 傳遞給 [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-)。這些設定彼此獨立，您可以啟用其中一項而停用另一項。範例在產生的頁面中將兩種動畫皆停用後匯出簡報。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **將 PowerPoint 匯出為 HTML**

標準的 HTML 匯出使用不同的呈現方式：投影片內容以 SVG 形式嵌入於 HTML 頁面中。以下範例使用此呈現方式將簡報轉換為 HTML 文件。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

以下簡化的標記說明產生頁面的結構。SVG 元素包含已呈現的投影片內容；佔位文字僅代表該內容，並非實際匯出輸出。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
基於 SVG 的匯出不會將 PowerPoint 形狀以單獨的 HTML 元素呈現。當您需要本文示範的形狀動畫與投影片過渡選項時，請使用 HTML5 匯出。
{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視**

HTML5 匯出會產生一個可於瀏覽器中檢視與導覽簡報投影片的頁面。此範例同時啟用 [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-)，讓匯出的投影片檢視能播放來源簡報的效果。

請使用已包含形狀動畫與投影片過渡的簡報來觀察這些設定的效果。啟用它們不會為沒有任何效果的投影片新增效果。匯出後，於瀏覽器開啟產生的 HTML5 文件，並確保其相關支援檔案可用。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **將簡報轉換為具備註解的 HTML5 文件**

您可以在 HTML5 輸出中包含現有的投影片註解，讓讀者在投影片內容旁看到回饋。本節的範例假設來源簡報已包含註解，如下圖所示。它會匯出這些註解；不會建立新註解。

![簡報投影片上的兩條註解](two_comments_pptx.png)

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) 的 [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) 方法。使用 [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) 從 [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) 列舉中選擇 `Right`，將註解放置於每張投影片的右側。

以下範例使用此註解佈局將簡報匯出為 HTML5。若簡報未包含註解，則不會有任何註解文字可顯示。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

下圖顯示匯出的 HTML5 文件，註解顯示在投影片旁邊。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **匯出期間排除 JavaScript 超連結**

假設 `hyperlinks.pptx` 包含目標為 `javascript:alert('Hello')` 的連結文字，以及普通的 `https://example.com/` 連結。若要在匯出時排除 JavaScript 超連結，請將 `true` 傳遞給 [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)。預設為 `false`，因此除非啟用此選項，否則不會過濾這些連結。

以下範例從工作目錄載入簡報，並使用 [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) 進行匯出：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

匯出的檔案會省略 JavaScript 超連結，但保留其文字以及普通的 HTTPS 連結。來源簡報保持不變。

此選項僅過濾 JavaScript 超連結；不會移除所有腳本或其他動態內容，也不保證符合 CSP 規範。例如，HTML5 輸出仍會包含用於投影片導覽與動畫的腳本。

## **常見問題**

**我可以控制物件動畫與投影片過渡在 HTML5 中是否播放嗎？**

是的，HTML5 匯出提供獨立的選項，讓您可啟用或停用 [形狀動畫](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [投影片過渡](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-)。

**是否支援註解？它們可以相對於投影片放置於何處？**

是的，既有的註解可以包含在 HTML5 輸出中，並可透過 [佈局設定](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-)（例如放置於投影片右側）設定其相對於投影片的位置。

**我可以為安全或 CSP 目的而跳過執行 JavaScript 的連結嗎？**

是的，[setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 設定允許您在儲存時跳過含有 JavaScript 呼叫的超連結。預設為 `false`。請參閱 [排除 JavaScript 超連結於匯出期間](/slides/zh-hant/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) 取得 HTML5 匯出範例與過濾範圍說明。此設定不會移除 HTML5 觀看器用於導覽與動畫的 JavaScript。