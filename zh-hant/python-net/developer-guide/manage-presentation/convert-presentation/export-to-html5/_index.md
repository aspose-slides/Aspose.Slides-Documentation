---
title: 在 Python 中將簡報轉換為 HTML5
linktitle: 簡報至 HTML5
type: docs
weight: 40
url: /zh-hant/python-net/export-to-html5/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 將 PowerPoint 與 OpenDocument 簡報匯出為回應式 HTML5。保留格式、動畫與互動性。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via .NET 將 PowerPoint 簡報轉換為 HTML5。內容包括基本匯出、形狀動畫與投影片轉場的控制，以及註解佈局。亦比較了 HTML5 輸出與標準 HTML 匯出之 SVG 為基礎的輸出差異。

## **將 PowerPoint 匯出為 HTML5**

下列範例從工作目錄載入簡報，並以 HTML5 格式儲存。它使用預設匯出設定；下一個範例說明如何明確控制動畫播放。請將輸入路徑改為您簡報的實際路徑。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="注意" %}}

除了 HTML 文件外，匯出同時會寫入支援的 CSS 與 JavaScript 檔案，用於投影片樣式、動畫、效果與導覽。將這些檔案與 HTML 文件一起保留，才能在移動或發佈輸出時正常運作。產生的頁面亦會從公共 CDN 載入 jQuery 與 Anime.js；若缺少它們，投影片導覽與動畫將無法執行。

{{% /alert %}}

若要匯出時不播放形狀動畫或投影片轉場，可在 [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) 中將 [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) 與 [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) 設為 `False`。這兩個設定是獨立的，您可以只啟用其中一項而停用另一項。以下範例在產生的頁面中同時停用兩種動畫。

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **將 PowerPoint 匯出為 HTML**

標準的 HTML 匯出使用不同的渲染方式：投影片內容以 SVG 形式嵌入 HTML 頁面中。下列範例示範如何使用此渲染方式將簡報轉換為 HTML 文件。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

以下簡化的標記說明產生頁面的結構。SVG 元素包含已渲染的投影片內容；佔位文字僅說明其含意，並非實際匯出結果。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="警告" color="warning" %}}

基於 SVG 的匯出不會將 PowerPoint 形狀以單獨的 HTML 元素呈現。若需要本文示範的形狀動畫與投影片轉場選項，請使用 HTML5 匯出。

{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視**

HTML5 匯出會產生可在瀏覽器中檢視與導覽簡報投影片的頁面。此範例同時啟用 [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) 與 [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)，讓匯出的投影片檢視可播放來源簡報中的效果。

請使用已包含形狀動畫與投影片轉場的簡報，以觀察這些設定的效果。啟用它們不會為沒有任何效果的投影片新增效果。匯出後，於支援檔案可用的瀏覽器中開啟產生的 HTML5 文件。

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **將簡報轉換為含註解的 HTML5 文件**

您可以在 HTML5 輸出中保留既有的投影片註解，讓讀者在投影片內容旁看到回饋意見。此段落的範例假設來源簡報已包含註解，如下圖所示。它會匯出這些註解，並不會新增註解。

![簡報投影片上的兩則註解](two_comments_pptx.png)

將一個 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) 物件指派給 [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) 的 [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) 屬性。再將 [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) 設為 `RIGHT`（自 [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) 列舉），即可將註解置於每張投影片的右側。

以下範例以此註解佈局將簡報匯出為 HTML5。若簡報沒有註解，則不會顯示任何註解文字。

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

下圖顯示匯出的 HTML5 文件，其中註解顯示在投影片旁邊。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **匯出時排除 JavaScript 超連結**

假設 `hyperlinks.pptx` 含有一段文字其目標為 `javascript:alert('Hello')`，以及一個普通的 `https://example.com/` 連結。若要在匯出時排除 JavaScript 超連結，請將 [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) 設為 `True`。預設為 `False`，因此必須啟用此選項才會過濾這類連結。

以下範例從工作目錄載入簡報，並使用 [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) 進行匯出：

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

匯出的檔案會省略 JavaScript 超連結，但保留其文字以及普通的 HTTPS 連結。來源簡報本身不會被修改。

此選項只會過濾 JavaScript 超連結；它不會移除所有腳本或其他主動內容，也不保證符合 CSP 標準。例如，HTML5 輸出仍會包含用於投影片導覽與動畫的腳本。

## **常見問題集**

**我可以控制在 HTML5 中是否播放物件動畫與投影片轉場嗎？**

可以，HTML5 匯出提供獨立的選項，可分別啟用或停用 [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) 與 [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)。

**是否支援註解，且可以將它們放置在投影片的哪個位置？**

支援將現有註解納入 HTML5 輸出，並可透過 [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/)（例如放在投影片右側）進行定位。

**我可以為安全或 CSP 需求跳過呼叫 JavaScript 的連結嗎？**

可以，設定 [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) 為 `True` 後，儲存時會跳過包含 JavaScript 呼叫的超連結。預設為 `False`。請參閱 [Exclude JavaScript Hyperlinks During Export](/slides/zh-hant/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) 中的 HTML5 匯出範例與過濾範圍。此設定不會移除 HTML5 觀閱器本身用於導覽與動畫的 JavaScript。