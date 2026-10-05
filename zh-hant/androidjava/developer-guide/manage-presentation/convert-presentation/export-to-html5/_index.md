---
title: 在 Android 上將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
type: docs
weight: 40
url: /zh-hant/androidjava/export-to-html5/
keywords:
- PowerPoint 轉 HTML5
- OpenDocument 轉 HTML5
- 簡報轉 HTML5
- 投影片轉 HTML5
- PPT 轉 HTML5
- PPTX 轉 HTML5
- ODP 轉 HTML5
- 將 PPT 儲存為 HTML5
- 将 PPTX 儲存為 HTML5
- 将 ODP 儲存為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 將 PowerPoint 與 OpenDocument 簡報匯出為響應式 HTML5。保留格式、動畫與互動性。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Android via Java 將 PowerPoint 簡報轉換為 HTML5。內容涵蓋基本匯出、形狀動畫與投影片過場的控制，以及註解版面配置。同時也比較了 HTML5 輸出與標準 HTML 匯出所使用的 SVG 基礎輸出的差異。

## **將 PowerPoint 匯出為 HTML5**

以下範例從工作目錄載入簡報，並以 HTML5 格式儲存。它使用預設的匯出設定；下一個範例說明如何明確控制動畫播放。請將輸入路徑替換為您的簡報路徑。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

除了 HTML 文件外，匯出還會寫入支援的 CSS 和 JavaScript 檔案，用於投影片樣式、動畫、效果與導覽。將這些檔案與 HTML 文件一起搬移或發佈。產生的頁面還會從公共 CDN 載入 jQuery 和 Anime.js；若缺少它們，投影片導覽和動畫將無法執行。

{{% /alert %}}

若要在匯出時不播放形狀動畫或投影片過場，請在 [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) 中將 `false` 傳遞給 [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 和 [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。這兩個設定是獨立的，您可以開啟其中一個而關閉另一個。以下範例在產生的頁面中同時停用兩種動畫。

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **將 PowerPoint 匯出為 HTML**

標準的 HTML 匯出使用不同的渲染方式：投影片內容以 SVG 形式嵌入 HTML 頁面。以下範例示範如何使用此渲染方式將簡報轉換為 HTML 文件。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

下面的簡化標記說明了產生頁面的結構。SVG 元素包含已渲染的投影片內容；佔位文字僅代表該內容，並非實際的匯出輸出。

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

基於 SVG 的匯出不會將 PowerPoint 形狀暴露為個別的 HTML 元素。若需要本文示範的形狀動畫與投影片過場選項，請使用 HTML5 匯出。

{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視**

HTML5 匯出會產生可在瀏覽器中檢視並導覽簡報投影片的頁面。此範例同時啟用 [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)，使匯出的投影片檢視能播放來源簡報的效果。

請使用已包含形狀動畫和投影片過場的簡報，以觀察這些設定的效果。啟用它們不會為沒有動畫的投影片新增效果。匯出後，於瀏覽器開啟產生的 HTML5 文件，並確保支援檔案可用。

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **將簡報轉換為含有註解的 HTML5 文件**

您可以在 HTML5 輸出中加入現有的投影片註解，讓讀者在投影片內容旁看到回饋。以下範例假設來源簡報已包含註解，如下圖所示。它會匯出這些註解，而不會創建新註解。

![Two comments on the presentation slide](two_comments_pptx.png)

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) 的 [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法。使用 [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) 並從 [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) 列舉中選擇 `Right`，即可將註解放置於每張投影片的右側。

以下範例將簡報匯出為具備此註解版面的 HTML5 文件。沒有註解的簡報將不會顯示任何註解文字。

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

下圖顯示了匯出的 HTML5 文件，註解顯示在投影片旁邊。

![The comments in the output HTML5 document](two_comments_html5.png)

## **匯出時排除 JavaScript 超連結**

假設 `hyperlinks.pptx` 包含目標為 `javascript:alert('Hello')` 的連結文字，以及普通的 `https://example.com/` 連結。若要在匯出時排除 JavaScript 超連結，請將 `true` 傳遞給 [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)。預設為 `false`，因此除非啟用此選項，否則不會過濾這類連結。

以下範例從工作目錄載入簡報，並使用 [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) 匯出：

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

匯出的檔案會省略 JavaScript 超連結，同時保留其文字以及普通的 HTTPS 連結。來源簡報保持不變。

此選項僅過濾 JavaScript 超連結；不會移除所有腳本或其他主動內容，也不保證符合 CSP。舉例而言，HTML5 輸出仍會包含用於投影片導覽與動畫的腳本。

## **常見問題**

**我可以控制 HTML5 中的物件動畫與投影片過場是否播放嗎？**

是的，HTML5 匯出提供獨立的選項，可啟用或停用 [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

**是否支援註解，且可以將它們放置在投影片的哪個位置？**

是的，現有的註解可包含在 HTML5 輸出中，並可透過 [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)（例如放在投影片右側）進行定位。

**我可以因安全或 CSP 考量而跳過執行 JavaScript 的連結嗎？**

是的，[setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 設定允許在儲存時跳過含有 JavaScript 呼叫的超連結。預設為 `false`。請參考[在匯出期間排除 JavaScript 超連結](/slides/zh-hant/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) 取得 HTML5 匯出範例與過濾範圍說明。此設定不會移除 HTML5 檢視器用於導覽與動畫的 JavaScript。