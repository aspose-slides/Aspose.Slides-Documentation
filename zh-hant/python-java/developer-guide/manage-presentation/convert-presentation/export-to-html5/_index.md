---
title: 在 Python via Java 中將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
type: docs
weight: 40
url: /zh-hant/python-java/export-to-html5/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 將 PowerPoint 與 OpenDocument 簡報匯出為響應式 HTML5。保留格式、動畫與互動性。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Python via Java 將 PowerPoint 簡報轉換為 HTML5。內容涵蓋基本匯出、形狀動畫與投影片過渡的控制，以及評論佈局，並比較 HTML5 輸出與標準 HTML 匯出之 SVG 基礎輸出的差異。

範例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。請將輸入簡報放置於目前工作目錄。每個範例會在 JVM 尚未執行時才啟動它。

## **導出 PowerPoint 為 HTML5**

以下範例從工作目錄載入簡報並以 HTML5 格式儲存。它使用預設匯出設定；下一個範例會說明如何明確控制動畫播放。請將輸入路徑替換為您的簡報路徑。

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

{{% alert color="info" title="Note" %}}
除了 HTML 文件外，匯出還會寫入支援 CSS 與 JavaScript 檔案，用於投影片樣式、動畫、效果與導覽。移動或發布輸出時，請將這些檔案與 HTML 文件一起保留。產生的頁面亦會從公共 CDN 載入 jQuery 與 Anime.js；若缺少它們，投影片導覽與動畫將無法執行。
{{% /alert %}}

若要在匯出時不播放形狀動畫或投影片過渡，請在 [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) 中分別將 `False` 傳給 [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) 和 [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions)。這兩個設定相互獨立，您可以啟用其中一項而停用另一項。以下範例於產生的頁面中同時停用兩種動畫。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **導出 PowerPoint 為 HTML**

標準 HTML 匯出使用不同的渲染方式：投影片內容以 SVG 形式嵌入於 HTML 頁面中。以下範例以此渲染方式將簡報轉換為 HTML 文件。

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

下方簡化的標記示範了產生頁面的結構。SVG 元素包含已渲染的投影片內容；佔位文字代表該內容，並非實際匯出結果。

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
基於 SVG 的匯出不會將 PowerPoint 形狀作為單獨的 HTML 元素公開。若需本文示範的形狀動畫與投影片過渡選項，請使用 HTML5 匯出。
{{% /alert %}}

## **導出 PowerPoint 為 HTML5 投影片檢視**

HTML5 匯出會產生一個可在瀏覽器中檢視與導覽簡報投影片的頁面。本範例同時啟用 [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) 與 [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions)，使匯出的投影片檢視能播放來源簡報中的效果。

請使用已包含形狀動畫與投影片過渡的簡報，以觀察這些設定的效果。啟用它們不會為沒有任何效果的投影片新增效果。匯出後，於瀏覽器開啟產生的 HTML5 文件，並確保其支援檔案可用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **將簡報轉換為包含評論的 HTML5 文件**

您可以在 HTML5 輸出中加入現有的投影片評論，讓讀者在投影片內容旁看到回饋。本節的範例假設來源簡報已包含評論，如下圖所示。它會匯出這些評論，並不會新增評論。

![簡報投影片上的兩條評論](two_comments_pptx.png)

將一個 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) 的 [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) 方法。使用 [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) 並從 [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) 列舉中選擇 `Right`，即可將評論放置於每張投影片的右側。

以下範例以此評論佈局將簡報匯出為 HTML5。沒有評論的簡報將不會顯示評論文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

下圖顯示了匯出的 HTML5 文件，評論顯示在投影片旁邊。

![輸出 HTML5 文件中顯示的評論](two_comments_html5.png)

## **匯出時排除 JavaScript 超連結**

假設 `hyperlinks.pptx` 包含文字連結，其目標為 `javascript:alert('Hello')`，以及一般的 `https://example.com/` 連結。若要在匯出時排除 JavaScript 超連結，請將 `True` 傳給 [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks)。預設值為 `False`，因此除非啟用此選項，否則不會過濾這類連結。

以下範例從工作目錄載入簡報，並使用 [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) 進行匯出：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

匯出檔案會省略 JavaScript 超連結，同時保留其文字與普通的 HTTPS 連結。來源簡報保持不變。

此選項僅過濾 JavaScript 超連結；它不會移除所有腳本或其他主動內容，也不保證符合 CSP。舉例而言，HTML5 輸出仍會包含用於投影片導覽與動畫的腳本。

## **常見問題**

**我可以控制物件動畫和投影片過渡是否在 HTML5 中播放嗎？**

是的，HTML5 匯出提供獨立的選項，可啟用或停用 [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) 與 [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions)。

**是否支援評論？它們可以相對於投影片放置在哪裡？**

是的，現有的評論可以包含於 HTML5 輸出，並可透過 [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions)（例如放在投影片右側）進行定位。

**我可以為安全或 CSP 考量而跳過呼叫 JavaScript 的連結嗎？**

是的，[setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 設定允許在儲存時跳過含有 JavaScript 呼叫的超連結。預設為 `False`。請參閱 [匯出時排除 JavaScript 超連結](/slides/zh-hant/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) 以取得 HTML5 匯出範例與過濾範圍的說明。此設定不會移除 HTML5 檢視器用於導覽與動畫的 JavaScript。