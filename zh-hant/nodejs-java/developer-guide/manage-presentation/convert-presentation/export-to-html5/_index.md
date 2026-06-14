---
title: 在 JavaScript 中將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
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
description: "使用 Aspose.Slides for Node.js 將 PowerPoint 與 OpenDocument 簡報匯出為回應式 HTML5。保留格式、動畫與互動性。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋了不含 Web 擴充功能或其他相依性的基本 HTML5 匯出，以及控制形狀動畫與投影片過渡的選項。本文亦示範標準的 PowerPoint 到 HTML 匯出流程、說明如何在投影片檢視模式下產生 HTML5 輸出，並展示如何透過設定佈局將註解包含於匯出文件中。

## **將 PowerPoint 匯出為 HTML5**

此 JavaScript 程式碼示範如何在不使用 Web 擴充功能和相依性之情況下，將簡報匯出為 HTML5：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
在此情況下，您會取得乾淨的 HTML。 
{{% /alert %}}

您可以透過以下方式指定形狀動畫與投影片過渡的設定：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將 PowerPoint 匯出為 HTML**

此 JavaScript 示範標準的 PowerPoint 到 HTML 匯出流程：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

在此情況下，簡報內容會以 SVG 形式呈現，如下所示：

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
當您使用此方法將 PowerPoint 匯出為 HTML 時，由於使用 SVG 渲染，將無法套用樣式或對特定元素進行動畫。 
{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視**

**Aspose.Slides** 允許您將 PowerPoint 簡報轉換為 HTML5 文件，且投影片會以投影片檢視模式呈現。此時，若在瀏覽器中開啟產生的 HTML5 檔案，您會在網頁上看到投影片檢視模式的簡報。

此 JavaScript 程式碼示範 PowerPoint 到 HTML5 投影片檢視的匯出流程：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將簡報轉換為含註解的 HTML5 文件**

PowerPoint 的註解是一種讓使用者在簡報投影片上留下備註或回饋的工具。在協同專案中特別有用，因為多位使用者可以在特定投影片元素上添加建議或意見，而不會修改主要內容。每則註解都會顯示作者名稱，方便追蹤是誰留下的備註。

假設我們有一個儲存在「sample.pptx」檔案中的 PowerPoint 簡報。

![簡報投影片上的兩則註解](two_comments_pptx.png)

將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否在輸出文件中包含簡報的註解。為此，需要在 [Html5Options](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/) 類別的 `notes_comments_layouting` 屬性中設定註解的顯示參數。

以下程式碼範例將簡報轉換為 HTML5 文件，且註解會顯示在投影片右側：

```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

下圖顯示了「output.html」文件的樣子。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **常見問題**

**我可以控制物件動畫和投影片過渡效果是否在 HTML5 中播放嗎？**

是的，HTML5 提供了獨立的選項，可啟用或停用 [shape animations](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/setanimateshapes/) 與 [slide transitions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/setanimatetransitions/)。

**HTML5 是否支援輸出註解，且可以將它們相對於投影片放置於何處？**

是的，可以在 HTML5 中加入註解，並透過 [layout settings](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting)（例如放在投影片右側）進行位置設定。

**我可以為了安全性或 CSP 原因跳過呼叫 JavaScript 的連結嗎？**

是的，提供了 [setting](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 讓您在儲存時跳過包含 JavaScript 呼叫的超連結，這有助於遵守嚴格的安全政策。