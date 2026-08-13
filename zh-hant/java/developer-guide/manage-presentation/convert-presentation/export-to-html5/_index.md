---
title: 在 Java 中將簡報轉換為 HTML5
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
- 將 PPT 儲存為 HTML5
- 將 PPTX 儲存為 HTML5
- 將 ODP 儲存為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 PowerPoint 與 OpenDocument 簡報匯出為回應式 HTML5。保留格式、動畫與互動功能。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。內容涵蓋不使用 Web 擴充功能或其他相依性的基本 HTML5 匯出，以及控制形狀動畫與投影片過場效果的選項。文章亦展示標準的 PowerPoint 轉 HTML 匯出流程、說明如何在投影片檢視模式下產生 HTML5 輸出，並示範透過設定版面配置將註解包含在匯出文件中。

## **匯出 PowerPoint 為 HTML5**

此 Java 程式碼示範如何在不使用 Web 擴充功能與相依性的情況下將簡報匯出為 HTML5：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
在此情況下，您會取得乾淨的 HTML。
{{% /alert %}}

您也可以這樣指定形狀動畫與投影片過場效果的設定：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **匯出 PowerPoint 為 HTML**

此 Java 程式碼示範標準的 PowerPoint 轉 HTML 流程：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

在此情況下，簡報內容會透過 SVG 呈現，形式如下：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}} 
使用此方法匯出 PowerPoint 為 HTML 時，因為採用 SVG 渲染，您將無法對特定元素套用樣式或執行動畫。
{{% /alert %}}

## **匯出 PowerPoint 為 HTML5 投影片檢視模式**

**Aspose.Slides** 允許您將 PowerPoint 簡報轉換為 HTML5 文件，並以投影片檢視模式呈現投影片。此時，當您在瀏覽器中開啟產生的 HTML5 檔案，即會在網頁上以投影片檢視模式顯示簡報。

此 Java 程式碼示範 PowerPoint 轉 HTML5 投影片檢視模式的匯出流程：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **將簡報轉換為含註解的 HTML5 文件**

PowerPoint 中的註解是讓使用者在投影片上留下備註或回饋的工具。於協作專案中特別有用，因為多位使用者可以對特定投影片元素添加建議或意見，而不會改動主要內容。每則註解都會顯示作者名稱，方便追蹤是誰留下的意見。

假設我們有以下保存在「sample.pptx」檔案中的 PowerPoint 簡報。

![Two comments on the presentation slide](two_comments_pptx.png)

將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否在輸出文件中包含簡報的註解。為此，將註解的顯示參數傳遞給 [Html5Options](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/) 類別的 `setSlidesLayoutOptions` 方法。

以下程式碼範例示範如何將簡報轉換為在投影片右側顯示註解的 HTML5 文件。

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

下圖顯示了「output.html」文件的樣子。

![The comments in the output HTML5 document](two_comments_html5.png)

## **常見問題**

### 我可以控制物件動畫與投影片過場效果是否在 HTML5 中播放嗎？

可以，HTML5 提供了獨立的選項，可啟用或停用 [shape animations](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [slide transitions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

### 是否支援輸出註解，且可以將它們放置在投影片的哪個相對位置？

支援，您可以透過 [layout settings](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 為註解與備註設定位置（例如放在投影片右側）。

### 我可以因安全或 CSP 原因跳過包含 JavaScript 的連結嗎？

可以，您可以使用 [setting](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 在儲存時跳過帶有 JavaScript 呼叫的超連結，協助符合嚴格的安全政策。