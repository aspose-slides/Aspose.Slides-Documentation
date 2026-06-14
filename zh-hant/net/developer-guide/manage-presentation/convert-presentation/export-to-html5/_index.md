---
title: 在 .NET 中將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
type: docs
weight: 40
url: /zh-hant/net/export-to-html5/
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
- 將 PPT 匯出為 HTML5
- 將 PPTX 匯出為 HTML5
- 將 ODP 匯出為 HTML5
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 PowerPoint 與 OpenDocument 簡報匯出為相容行動裝置的 HTML5。保留格式、動畫與互動性。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋不含 Web 擴充功能或其他相依性的基本 HTML5 匯出，以及控制圖形動畫與投影片轉場的選項。本文亦展示標準的 PowerPoint 至 HTML 匯出流程，說明如何在投影片檢視模式下產生 HTML5 輸出，並示範如何透過設定版面配置將註解包含在匯出文件中。

## **匯出 PowerPoint 為 HTML5**

此 C# 程式碼示範如何在不使用 Web 擴充功能和相依性的情況下將簡報匯出為 HTML5：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 

在此情況下，您會得到乾淨的 HTML。 

{{% /alert %}}

您也可以這樣指定圖形動畫與投影片轉場的設定：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **匯出 PowerPoint 為 HTML**

此 C# 程式碼示範標準的 PowerPoint 轉 HTML 流程：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
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

{{% alert title="Note" color="warning" %}} 

使用此方法匯出 PowerPoint 為 HTML 時，因為採用 SVG 渲染，您將無法套用樣式或對特定元素進行動畫。 

{{% /alert %}}

## **匯出 PowerPoint 為 HTML5 投影片檢視模式**

**Aspose.Slides** 允許您將 PowerPoint 簡報轉換為 HTML5 文件，並以投影片檢視模式顯示投影片。如此一來，當您在瀏覽器開啟產生的 HTML5 檔案時，會在網頁上以投影片檢視模式觀看簡報。

此 C# 程式碼示範 PowerPoint 轉 HTML5 投影片檢視模式的匯出流程：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **將簡報轉換為包含註解的 HTML5 文件**

PowerPoint 中的註解是讓使用者在投影片上留下備註或回饋的工具。它在協作專案中特別有用，因為多位使用者可以在不修改主要內容的前提下，對特定投影片元素添加建議或意見，每則註解都會顯示作者名稱，便於追蹤誰留下了該備註。

假設我們有以下儲存在「sample.pptx」檔案中的 PowerPoint 簡報。

![Two comments on the presentation slide](two_comments_pptx.png)

將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否在輸出文件中包含簡報的註解。為此，必須在 [Html5Options](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/) 類別的 `NotesCommentsLayouting` 屬性中設定註解的顯示參數。

以下程式碼範例將簡報轉換為在投影片右側顯示註解的 HTML5 文件。
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

下圖顯示了「output.html」文件的樣子。

![The comments in the output HTML5 document](two_comments_html5.png)

## **常見問題**

**我可以控制物件動畫與投影片轉場是否在 HTML5 中播放嗎？**

可以，HTML5 提供獨立的選項來啟用或停用 [shape animations](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animateshapes/) 與 [slide transitions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animatetransitions/)。

**是否支援輸出註解？註解可以相對於投影片放置在哪裡？**

支援，您可以透過 [layout settings](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/notescommentslayouting/) 在 HTML5 中加入註解，並將其定位（例如放在投影片右側）。

**我可以為安全性或 CSP 考量跳過呼叫 JavaScript 的連結嗎？**

可以，有一個 [setting](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) 讓您在儲存時跳過包含 JavaScript 呼叫的超連結，以符合嚴格的安全政策。