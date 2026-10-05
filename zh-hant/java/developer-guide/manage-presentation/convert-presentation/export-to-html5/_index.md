---
title: 將簡報轉換為 Java 中的 HTML5
linktitle: 簡報轉 HTML5
type: docs
weight: 40
url: /zh-hant/java/export-to-html5/
keywords:
- PowerPoint 轉 HTML5
- OpenDocument 轉 HTML5
- 簡報 轉 HTML5
- 投影片 轉 HTML5
- PPT 轉 HTML5
- PPTX 轉 HTML5
- ODP 轉 HTML5
- 儲存 PPT 為 HTML5
- 儲存 PPTX 為 HTML5
- 儲存 ODP 為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 PowerPoint 與 OpenDocument 簡報匯出為回應式 HTML5。保留版面配置、動畫與互動性。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Java 將 PowerPoint 簡報轉換為 HTML5。內容涵蓋基本匯出、形狀動畫與投影片過渡的控制以及註解版面配置，並比較 HTML5 輸出與標準 HTML 匯出之 SVG 為基礎的輸出差異。

## **匯出 PowerPoint 為 HTML5**

以下範例從工作目錄載入簡報，並將其儲存為 HTML5 格式。它使用預設匯出設定；下一個範例說明如何明確控制動畫播放。請將輸入路徑取代為您的簡報路徑。

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
除了 HTML 文件之外，匯出還會寫入支援的 CSS 與 JavaScript 檔案，用於投影片樣式、動畫、效果與導覽。搬移或發佈輸出時，請將這些檔案與 HTML 文件一起保留。產生的頁面也會從公共 CDN 載入 jQuery 與 Anime.js；若未載入這些檔案，投影片導覽與動畫將無法執行。
{{% /alert %}}

若要在匯出時不播放形狀動畫或投影片過渡，請在 [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) 中分別將 `false` 傳遞給 [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。這兩個設定相互獨立，您可以僅啟用其中一項而停用另一項。範例於產生的頁面中同時停用兩種動畫。

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

## **匯出 PowerPoint 為 HTML**

標準 HTML 匯出使用不同的呈現方式：投影片內容以 SVG 形式嵌入在 HTML 頁面中。以下範例使用此呈現方式將簡報轉換為 HTML 文件。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

以下簡化的標記說明產生頁面的結構。SVG 元素包含已渲染的投影片內容；佔位文字僅代表該內容，並非實際匯出輸出。

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
基於 SVG 的匯出不會將 PowerPoint 形狀暴露為個別的 HTML 元素。若需要本文示範的形狀動畫與投影片過渡選項，請使用 HTML5 匯出。
{{% /alert %}}

## **匯出 PowerPoint 為 HTML5 投影片檢視**

HTML5 匯出會產生一個可在瀏覽器中檢視與導覽簡報投影片的頁面。此範例同時啟用 [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)，讓匯出的投影片檢視能播放來源簡報中的效果。

請使用已包含形狀動畫與投影片過渡的簡報，以觀察這些設定的效果。啟用它們不會為沒有任何效果的投影片新增新效果。匯出後，於瀏覽器開啟產生的 HTML5 文件，並確保支援檔案可用。

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

## **將簡報轉換為包含註解的 HTML5 文件**

您可以在 HTML5 輸出中包含現有的投影片註解，讓讀者在投影片內容旁看到回饋。以下範例假設來源簡報中已有註解，如下圖所示。它會匯出這些註解；不會新增任何註解。

![簡報投影片上的兩則註解](two_comments_pptx.png)

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) 的 [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法。使用 [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) 從 [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) 列舉中選取 `Right`，即可將註解置於每張投影片的右側。

以下範例將簡報匯出為具有此註解版面的 HTML5。沒有註解的簡報將不會顯示註解文字。

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

下圖顯示輸出的 HTML5 文件，註解顯示在投影片旁邊。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **匯出時排除 JavaScript 超連結**

假設 `hyperlinks.pptx` 包含文字連結，其目標為 `javascript:alert('Hello')`，以及普通的 `https://example.com/` 連結。若要在匯出時排除 JavaScript 超連結，請將 `true` 傳遞給 [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)。預設為 `false`，因此除非啟用此選項，否則不會過濾這些連結。

以下範例從工作目錄載入簡報，並使用 [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) 匯出：

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

匯出檔案會省略 JavaScript 超連結，同時保留其文字與普通的 HTTPS 連結。來源簡報保持不變。

此選項會過濾 JavaScript 超連結；它不會移除所有腳本或其他主動內容，也不保證符合 CSP。舉例來說，HTML5 輸出仍會包含用於投影片導覽與動畫的腳本。

## **常見問題**

**我可以控制物件動畫和投影片過渡是否在 HTML5 中播放嗎？**

可以，HTML5 匯出提供獨立的選項來啟用或停用 [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

**是否支援註解？它們可以相對於投影片放置在哪裡？**

支援，現有的註解可以包含在 HTML5 輸出中，並透過 [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 為註解與備註設定位置（例如放置於投影片右側）。

**我可以為了安全性或 CSP 考量而跳過呼叫 JavaScript 的連結嗎？**

可以，使用 [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 設定即可在儲存時跳過包含 JavaScript 呼叫的超連結。預設為 `false`。參考 [匯出時排除 JavaScript 超連結](/slides/zh-hant/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) 取得 HTML5 匯出範例與過濾範圍說明。此設定不會移除 HTML5 檢視器用於導覽與動畫的 JavaScript。