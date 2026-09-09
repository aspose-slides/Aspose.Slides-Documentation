---
title: 使用 Python via Java 轉換簡報為 HTML5
linktitle: 簡報轉 HTML5
type: docs
weight: 40
url: /zh-hant/python-java/export-to-html5/
keywords:
- PowerPoint 轉 HTML5
- OpenDocument 轉 HTML5
- 簡報轉 HTML5
- 投影片轉 HTML5
- PPT 轉 HTML5
- PPTX 轉 HTML5
- ODP 轉 HTML5
- 另存 PPT 為 HTML5
- 另存 PPTX 為 HTML5
- 另存 ODP 為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 將 PowerPoint 與 OpenDocument 簡報匯出為響應式 HTML5。保留格式、動畫與互動性。"
---
## **概觀**

本篇文章說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋不帶額外 Web 擴充功能的基本 HTML5 匯出，以及控制形狀動畫和投影片過渡的選項。文章還展示標準的 PowerPoint 轉 HTML 匯出流程，說明如何在投影片檢視模式下產生 HTML5 輸出，並示範如何透過設定佈局將註解包含在匯出的文件中。

示例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。請將 `pres.pptx`（或在註解示例中使用 `sample.pptx`）放置於目前工作目錄。每個示例僅在 JVM 尚未啟動時才啟動它。

## **將 PowerPoint 匯出為 HTML5**

使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 搭配 [SaveFormat.Html5](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Html5) 以在不包含額外 Web 擴充功能的情況下匯出簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}} 
HTML5 匯出器會產生可在瀏覽器中檢視的 HTML 內容。 
{{% /alert %}}

使用 [Html5Options](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/) 來設定匯出。呼叫 [setAnimateShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/#setAnimateShapes) 和 [setAnimateTransitions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/#setAnimateTransitions) 並傳入 `False` 以停用形狀動畫與投影片過渡：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **將 PowerPoint 匯出為 HTML**

使用 [SaveFormat.Html](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Html) 進行標準 HTML 匯出。欲了解更多選項，請參閱 [Convert PowerPoint to HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
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

{{% alert title="警告" color="warning" %}} 
標準 HTML 匯出會以 SVG 呈現投影片內容，且不提供 HTML5 形狀動畫與投影片過渡的選項。 
{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視**

**Aspose.Slides** 允許您將 PowerPoint 簡報轉換為 HTML5 文件，且投影片會以投影片檢視模式呈現。在此情況下，於瀏覽器開啟生成的 HTML5 檔案時，您會在網頁上看到投影片檢視模式的簡報。

以下 Python 程式碼示範 PowerPoint 轉 HTML5 投影片檢視的匯出流程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **將簡報轉換為含註解的 HTML5 文件**

PowerPoint 中的註解是一種工具，允許使用者在簡報投影片上留下備註或回饋。於協同專案中特別有用，因為多位使用者可在特定投影片元素上添加建議或評論，而不會更改主要內容。每則註解皆顯示作者名稱，方便追蹤是誰留下的備註。

假設我們有以下儲存在 "sample.pptx" 檔案中的 PowerPoint 簡報。

![簡報投影片上的兩則註解](two_comments_pptx.png)

將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否在輸出文件中包含簡報的註解。為此，請將註解的顯示參數傳遞給 [Html5Options](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/) 類別的 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) 方法。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 與 [setCommentsPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) 並搭配 [CommentsPositions.Right](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commentspositions/#Right)。以下程式碼範例將簡報轉換為在投影片右側顯示註解的 HTML5 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

以下圖示顯示了 "output.html" 文件的樣子。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **FAQ**

**我可以控制物件動畫與投影片過渡是否在 HTML5 中播放嗎？**

是的，HTML5 提供獨立的選項以啟用或停用 [shape animations](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/#setAnimateShapes) 與 [slide transitions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/#setAnimateTransitions)。

**可以匯出註解嗎？它們可以相對於投影片放置在何處？**

可以，註解可於 HTML5 中加入，並透過 [layout settings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) 針對註解與備忘錄設定位置（例如放在投影片右側）。

**我可以為安全或 CSP 原因跳過呼叫 JavaScript 的連結嗎？**

可以，存在一個 [setting](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 可在儲存時跳過包含 JavaScript 呼叫的超連結。此設定會移除這些超連結；但本身並不保證所有產生的 HTML5 程式碼皆符合網站的內容安全政策 (Content Security Policy)。