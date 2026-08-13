---
title: 在 .NET 中將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
type: docs
weight: 40
url: /zh-hant/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 PowerPoint 與 OpenDocument 簡報匯出為響應式 HTML5。保留格式、動畫與互動功能。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋基本的 HTML5 匯出，以及控制圖形動畫和投影片過渡的選項。本文還展示標準的 PowerPoint 到 HTML 匯出流程，說明如何在投影片檢視模式下產生 HTML5 輸出，並示範透過設定版面配置將註解包含於匯出文件中。

## **將 PowerPoint 匯出為 HTML5**

以下 C# 程式碼示範如何將簡報匯出為 HTML5：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
除此之外，匯出會寫入其參考的支援檔案：`pres.css`、`master.css`、`animation.js`、`effects.js` 與 `navigation.js`。產生的頁面亦會從公共 CDN 載入 jQuery 與 Anime.js；若未載入，投影片導覽與動畫將無法執行。 
{{% /alert %}}

您可以這樣指定圖形動畫與投影片過渡的設定：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **將 PowerPoint 匯出為 HTML**

以下 C# 程式碼示範標準的 PowerPoint 到 HTML 匯出流程：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
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
使用此方法將 PowerPoint 匯出為 HTML 時，因為採用 SVG 呈現，無法套用樣式或對特定元素進行動畫。 
{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視**

**Aspose.Slides** 允許您將 PowerPoint 簡報轉換為 HTML5 文件，且投影片會以投影片檢視模式呈現。在此情況下，於瀏覽器開啟產生的 HTML5 檔案時，即可在網頁上以投影片檢視模式觀看簡報。 

以下 C# 程式碼示範 PowerPoint 到 HTML5 投影片檢視的匯出流程：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **將簡報轉換為含註解的 HTML5 文件**

PowerPoint 中的註解是一種工具，讓使用者能在簡報投影片上留下備註或回饋。於協作專案中特別有用，多位使用者可以對特定投影片元素添加建議或意見，而不會改變主要內容。每則註解皆顯示作者名稱，方便追蹤是誰留下的意見。

假設我們有以下儲存在「sample.pptx」檔案中的 PowerPoint 簡報。

![簡報投影片上的兩則註解](two_comments_pptx.png)

將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否在輸出文件中包含簡報的註解。為此，必須在 [Html5Options](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/) 類別的 `NotesCommentsLayouting` 屬性中設定註解的顯示參數。

以下程式碼範例將簡報轉換為 HTML5 文件，並將註解顯示於投影片右側。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

下圖顯示了「output.html」文件的樣子。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **常見問題**

### 是否可以控制物件動畫與投影片過渡在 HTML5 中的播放？

是的，HTML5 提供獨立的選項，可啟用或停用 [形狀動畫](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animateshapes/) 與 [投影片過渡](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animatetransitions/)。

### 是否支援註解的輸出，且可以相對於投影片放置於哪裡？

是的，註解可以在 HTML5 中加入，並透過對於備註與註解的 [版面配置設定](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/notescommentslayouting/)（例如放置於投影片右側）來決定其位置。

### 是否可以跳過會呼叫 JavaScript 的連結以符合安全性或 CSP 需求？

是的，有一個 [設定](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) 可在儲存時略過包含 JavaScript 呼叫的超連結。這有助於遵循嚴格的安全政策。