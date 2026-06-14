---
title: "在 Python 中將簡報轉換為 HTML5"
linktitle: "匯出為 HTML5"
type: docs
weight: 40
url: /zh-hant/python-net/export-to-html5/
keywords:
- "PowerPoint 轉 HTML5"
- "OpenDocument 轉 HTML5"
- "簡報 轉 HTML5"
- "投影片 轉 HTML5"
- "PPT 轉 HTML5"
- "PPTX 轉 HTML5"
- "ODP 轉 HTML5"
- "轉換 PowerPoint"
- "轉換 OpenDocument"
- "轉換簡報"
- "轉換投影片"
- "HTML5 匯出"
- "匯出簡報"
- "匯出投影片"
- "PowerPoint"
- "OpenDocument"
- "簡報"
- "Python"
- "Aspose.Slides"
description: "使用 Aspose.Slides for Python via .NET 將 PowerPoint 與 OpenDocument 簡報匯出為具回應式的 HTML5。保留格式、動畫與互動性。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋了不需要 Web 擴充功能或其他相依性的基本 HTML5 匯出，以及控制形狀動畫與投影片轉場的選項。本文還示範標準的 PowerPoint 轉 HTML 匯出流程、說明如何在投影片檢視模式下產生 HTML5 輸出，並演示透過設定版面配置將註解包含於匯出文件中。

## **將 PowerPoint 匯出為 HTML5**

以下 Python 程式碼示範如何在不使用 Web 擴充功能和相依性的情況下將簡報匯出為 HTML5：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
在此情況下，您將獲得乾淨的 HTML。 
{{% /alert %}}

您可以透過以下方式指定形狀動畫和投影片轉場的設定：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **將 PowerPoint 匯出為 HTML**

以下 Python 程式碼示範標準的 PowerPoint 轉 HTML 流程：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
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
當您使用此方法將 PowerPoint 匯出為 HTML 時，由於採用 SVG 呈現，將無法套用樣式或為特定元素加入動畫。 
{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視**

**Aspose.Slides** 可將 PowerPoint 簡報轉換為 HTML5 文件，並以投影片檢視模式呈現簡報。在此情況下，當您在瀏覽器中開啟產生的 HTML5 檔案時，會在網頁上以投影片檢視模式觀看簡報。

以下 Python 程式碼示範 PowerPoint 轉 HTML5 投影片檢視的匯出流程：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # 匯出包含投影片轉場、動畫與形狀動畫的簡報為 HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # 儲存簡報
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **將簡報轉換為含註解的 HTML5 文件**

PowerPoint 的註解是一種讓使用者在簡報投影片上留下備註或回饋的工具。在協同專案中，它特別有用，因為多位使用者可以對特定投影片元素添加建議或意見，而不會修改主內容。每則註解都會顯示作者姓名，方便追蹤是誰留下的意見。

假設我們有一個儲存在「sample.pptx」檔案中的 PowerPoint 簡報。

![簡報投影片上的兩則註解](two_comments_pptx.png)

當您將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否將簡報中的註解包含在輸出文件中。為此，您需要在 [Html5Options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/) 類別的 `notes_comments_layouting` 屬性中設定註解的顯示參數。

以下程式碼示例將簡報轉換為 HTML5 文件，並將註解顯示在投影片右側。
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

輸出的「output.html」文件如下圖所示。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **FAQ**

**我可以控制物件動畫與投影片轉場是否在 HTML5 中播放嗎？**

是的，HTML5 提供了分別啟用或停用 [shape animations](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/animate_shapes/) 與 [slide transitions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/animate_transitions/) 的選項。

**支援註解的輸出嗎？可將它們相對於投影片放置於何處？**

是的，HTML5 可以加入註解，並可透過 [layout settings](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/notes_comments_layouting/)（例如，放置於投影片右側）來設定註解與備註的版面配置。

**我可以為安全性或 CSP 考量而跳過呼叫 JavaScript 的連結嗎？**

是的，有一個 [setting](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/skip_java_script_links/) 可在儲存時跳過包含 JavaScript 呼叫的超連結，協助符合嚴格的安全政策。