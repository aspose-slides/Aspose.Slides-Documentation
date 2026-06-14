---
title: 在 Android 上將簡報轉換為 HTML5
linktitle: 簡報轉換成 HTML5
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
- 將 PPTX 儲存為 HTML5
- 將 ODP 儲存為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 透過 Java，將 PowerPoint 與 OpenDocument 簡報匯出為具回應式的 HTML5。保留格式、動畫與互動性。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋不含 Web 擴充功能或額外依賴的基本 HTML5 匯出，以及控制形狀動畫和投影片過渡的選項。本文還展示標準的 PowerPoint 轉 HTML 匯出流程，說明如何在投影片檢視模式下產生 HTML5 輸出，並示範透過設定版面配置將註解納入匯出文件中。

## **匯出 PowerPoint 為 HTML5**

以下 Java 程式碼示範如何將簡報匯出為不含 Web 擴充功能與依賴的 HTML5：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
在此情況下，您會得到乾淨的 HTML。 
{{% /alert %}}

您可以這樣指定形狀動畫與投影片過渡的設定：

```java
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

以下 Java 程式碼示範標準的 PowerPoint 轉 HTML 流程：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

在此情況下，簡報內容會透過 SVG 以以下形式呈現：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
當您使用此方法將 PowerPoint 匯出為 HTML 時，由於採用 SVG 呈現，將無法套用樣式或對特定元素進行動畫。 
{{% /alert %}}

## **匯出 PowerPoint 為 HTML5 投影片檢視**

**Aspose.Slides** 可讓您將 PowerPoint 簡報轉換為 HTML5 文件，並以投影片檢視模式呈現投影片。這樣，當您在瀏覽器中開啟產生的 HTML5 檔案時，即可在網頁上以投影片檢視模式觀看簡報。

以下 Java 程式碼示範 PowerPoint 轉 HTML5 投影片檢視的匯出流程：

```java
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

PowerPoint 中的註解是一種讓使用者在簡報投影片上留下備註或回饋的工具。它在協同專案中特別有用，因為多位使用者可以對特定投影片元素提出建議或意見，而不會改動主要內容。每則註解都會顯示作者名稱，方便追蹤是誰留下的意見。

假設我們有以下儲存在「sample.pptx」檔案中的 PowerPoint 簡報。

![簡報投影片上的兩則註解](two_comments_pptx.png)

將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否在輸出文件中包含簡報的註解。為此，您需要在 [Html5Options](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/) 類別的 `getNotesCommentsLayouting` 方法中設定註解的顯示參數。

以下程式碼範例將簡報轉換為 HTML5 文件，並將註解顯示在投影片的右側。

```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

下圖顯示了 "output.html" 文件的樣子。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **常見問題**

**我能控制物件動畫與投影片過渡在 HTML5 中是否播放嗎？**

是的，HTML5 提供了獨立的選項，可啟用或停用 [shape animations](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 與 [slide transitions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

**是否支援註解的輸出，且可以相對於投影片放置於何處？**

是的，註解可以在 HTML5 中加入，並可透過針對註解與備註的 [layout settings](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)（例如放在投影片右側）進行位置設定。

**我可以為了安全性或 CSP 原因跳過呼叫 JavaScript 的連結嗎？**

可以，有一個 [setting](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 可在儲存時跳過包含 JavaScript 呼叫的超連結。這有助於遵守嚴格的安全政策。