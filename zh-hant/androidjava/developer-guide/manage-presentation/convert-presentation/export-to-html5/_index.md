---
title: 在 Android 上將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
type: docs
weight: 40
url: /zh-hant/androidjava/export-to-html5/
keywords:
- PowerPoint 轉換為 HTML5
- OpenDocument 轉換為 HTML5
- 簡報 轉換為 HTML5
- 投影片 轉換為 HTML5
- PPT 轉換為 HTML5
- PPTX 轉換為 HTML5
- ODP 轉換為 HTML5
- 將 PPT 儲存為 HTML5
- 將 PPTX 儲存為 HTML5
- 將 ODP 儲存為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 透過 Java 將 PowerPoint 與 OpenDocument 簡報匯出為響應式 HTML5。保留格式、動畫與互動性。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋了不含網頁擴充功能或額外相依性的基本 HTML5 匯出，以及控制圖形動畫和投影片轉場的選項。本文還展示了標準的 PowerPoint 到 HTML 匯出流程，說明如何在投影片檢視模式下產生 HTML5 輸出，並示範如何透過配置佈局將評論包含於匯出文件中。

## **將 PowerPoint 匯出為 HTML5**

此 Java 程式碼示範如何在不使用網頁擴充功能和相依性的情況下將簡報匯出為 HTML5：

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
在此情況下，您會得到乾淨的 HTML。 
{{% /alert %}}

您可以這樣指定圖形動畫和投影片轉場的設定：

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

## **將 PowerPoint 匯出為 HTML**

此 Java 程式碼示範標準的 PowerPoint 到 HTML 匯出流程：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

在此情況下，簡報內容會透過 SVG 以如下形式呈現：

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
當您使用此方法將 PowerPoint 匯出為 HTML 時，由於採用 SVG 渲染，無法對特定元素套用樣式或進行動畫。 
{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視模式**

**Aspose.Slides** 允許您將 PowerPoint 簡報轉換為 HTML5 文件，並以投影片檢視模式顯示投影片。此時，當您在瀏覽器中開啟產生的 HTML5 檔案時，會在網頁上以投影片檢視模式看到簡報。

此 Java 程式碼示範 PowerPoint 到 HTML5 投影片檢視匯出流程：

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

## **將簡報轉換為包含評論的 HTML5 文件**

PowerPoint 中的評論是一種工具，可讓使用者在簡報投影片上留下備註或回饋。它在協同專案中特別有用，允許多位使用者對特定投影片元素提出建議或意見，而不會改變主內容。每則評論都會顯示作者姓名，方便追蹤是誰留下的意見。

假設我們有以下儲存在「sample.pptx」檔案中的 PowerPoint 簡報。

![簡報投影片上的兩則評論](two_comments_pptx.png)

將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否將簡報中的評論包含在輸出文件中。為此，需要將評論的顯示參數傳遞給 [Html5Options](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/) 類別的 `setSlidesLayoutOptions` 方法。

以下程式碼範例示範如何將簡報轉換為在投影片右側顯示評論的 HTML5 文件。
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

下面的圖示顯示了「output.html」文件的樣子。

![輸出 HTML5 文件中的評論](two_comments_html5.png)

## **常見問題**

### 我可以控制物件動畫和投影片轉場在 HTML5 中是否播放嗎？

是的，HTML5 提供了獨立的選項，可啟用或停用[shape animations](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-)和[slide transitions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

### 是否支援輸出評論，且它們可以相對於投影片放置在哪裡？

是的，評論可以在 HTML5 中加入，並透過[layout settings](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)（例如放在投影片右側）進行配置。

### 我可以為安全性或 CSP 原因跳過呼叫 JavaScript 的連結嗎？

是的，有一個[setting](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)可讓您在儲存時跳過包含 JavaScript 呼叫的超連結，協助符合嚴格的安全政策。