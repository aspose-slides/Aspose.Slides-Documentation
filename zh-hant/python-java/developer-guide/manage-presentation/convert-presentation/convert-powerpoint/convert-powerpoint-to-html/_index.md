---
title: 在 Python via Java 中將 PowerPoint 簡報轉換為 HTML
linktitle: PowerPoint 轉 HTML
type: docs
weight: 30
url: /zh-hant/python-java/convert-powerpoint-to-html/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 HTML
- 簡報轉 HTML
- 投影片轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- 將 PowerPoint 儲存為 HTML
- 將簡報儲存為 HTML
- 將投影片儲存為 HTML
- 將 PPT 儲存為 HTML
- 將 PPTX 儲存為 HTML
- 匯出 PPT 為 HTML
- 匯出 PPTX 為 HTML
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中將 PowerPoint 簡報轉換為 HTML。使用 Aspose.Slides 匯出 PPT 和 PPTX 檔案、選取的投影片、備註、字型、影像、SVG 以及媒體。"
---
## **概述**

Aspose.Slides for Python via Java 能在未安裝 Microsoft PowerPoint 的情況下將 PowerPoint 簡報保存為 HTML。基本的轉換只需載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 並呼叫 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)，使用 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/)。當需要控制匯出的版面配置、字型、影像、備註、評論、SVG 輸出或連結資源時，請使用 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/)。

本指南聚焦於實務的 HTML 匯出情境：

- 匯出整個簡報或選取的投影片。
- 產生固定版面、響應式或基於 SVG 的 HTML。
- 包含演講者備註與評論。
- 控制影像品質與裁切影像資料。
- 嵌入字型或將字型檔案分別儲存。
- 決定外部資源與媒體檔案的寫入與參照方式。

預設情況下，HTML 匯出會產生一個自包含的 HTML 文件，將大部分資源嵌入其中。這對於分享單一檔案很方便，但可能會導致輸出大小增加。對於 Web 發佈，建議使用外部資源、降低影像 DPI，僅嵌入目標環境中不一定可取得的字型。

## **將簡報轉換為 HTML**

要將簡報匯出為 HTML，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 載入，並使用 [SaveFormat.Html](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Html) 儲存。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

每個範例皆從目前工作目錄載入 `presentation.pptx`。在執行前請安裝 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。JVM 會在每個 Python 行程啟動一次。

此範例會寫入一個 HTML 檔案。`Presentation` 物件會在 `finally` 區塊中釋放，以解除檔案句柄與渲染資源。

## **設定 HTML 匯出**

[HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/) 是 HTML 匯出的主要設定類別。常用的設定包括：

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions)：加入備註、評論、講義或其他版面資訊。
- [setHtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setHtmlFormatter)：變更 HTML 文件結構或將格式化委派給控制器。
- [setSlideImageFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSlideImageFormat)：變更投影片的呈現方式，例如以 SVG。
- [setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setPicturesCompression)：控制影像 DPI 與輸出大小。
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas)：保留或移除裁切的影像資料。
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout)：使匯出的 SVG 內容自適應其容器。
- [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setShowHiddenSlides)：必要時包含隱藏投影片。

以下各節分別說明最常用的選項，您可依工作流程需求僅組合所需的選項。

## **將選取的投影片匯出為 HTML**

[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 重載接受投影片編號，使用 1 為基礎的投影片位置。以下迴圈會將每張投影片儲存為獨立的 HTML 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

當網站或應用程式需要每張投影片對應一個 HTML 頁面時，可使用此模式。若每張投影片應使用相同版面配置，請建立單一的 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/) 實例，並在每次呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 時傳入。

## **建立響應式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/responsivehtmlcontroller/) 透過 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmlformatter/) 提供響應式 HTML 輸出。當匯出的頁面需要更好地適應瀏覽器寬度時，請使用它。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

若要使用基於 SVG 的響應式版面，請以 `True` 呼叫 [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout)。當投影片內容以可縮放的 SVG 標記匯出時，這很有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **包含演講者備註與評論**

透過 [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 可加入演講者備註或評論。備註與評論預設為隱藏，除非您指定其位置。

假設來源簡報包含演講者備註：

![PowerPoint 中含演講者備註的投影片](slide_with_notes.png)

以下程式碼會將投影片內容與其下方的演講者備註一起匯出。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

匯出的 HTML 包含備註區域：

![HTML 輸出，包含投影片與演講者備註](HTML_with_notes.png)

若要匯出評論，請呼叫 [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)，例如搭配 [CommentsPositions.Right](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commentspositions/#Right) 或 [CommentsPositions.Bottom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commentspositions/#Bottom)。若只需評論，請省略 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)。若同時需要備註與評論，則兩個方法皆呼叫。

## **控制影像品質與裁切區域**

HTML 匯出可壓縮投影片影像以縮小輸出大小。當需要更高影像品質時，請傳入 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturescompression/) 中的值給 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setPicturesCompression)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

預設情況下，影像的裁切區域可能會從匯出結果中移除。僅在使用者必須能夠復原或檢視這些隱藏影像部份時才保留裁切資料。保留它會增加 HTML 大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **加入 CSS**

若需簡單樣式，可將 CSS 字串傳入 [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmlformatter/#createDocumentFormatter)。這會變更外圍的 HTML 文件，而 Aspose.Slides 繼續渲染投影片內容。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

若需自訂文件標頭、連結的 CSS 檔案，或在投影片與圖形周圍加入自訂標記，可透過 JPype 介面代理使用自訂格式化控制器，並將其傳給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmlformatter/) 的 [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmlformatter/#createCustomFormatter)。

## **嵌入字型**

如果目標環境可能未安裝簡報所使用的字型，可使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/embedallfontshtmlcontroller/) 將字型嵌入 HTML。嵌入可提升視覺相似度，但會增加輸出大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

僅在確信目標瀏覽器或系統已提供該字型時才排除嵌入。對於品牌字型或較不常見的字型，嵌入通常較為安全。

## **外部儲存資源**

自包含的 HTML 易於搬移，但嵌入的 Base64 資源會使檔案變大。若應用程式需要外部影像檔案，可透過 JPype 介面代理實作資源連結控制器，並將其傳入 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/) 建構函式。

外部化資源時，請明確選擇兩個路徑：

- 檔案系統輸出路徑，您的應用程式寫入產生的影像、字型、音訊或視訊。
- URL 路徑，瀏覽器從 HTML 文件載入這些檔案時使用的路徑。

## **匯出媒體檔案**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoplayerhtmlcontroller/) 會匯出影音檔案並產生可在瀏覽器播放的 HTML。其建構子接受以下參數：

- `path`：產生的媒體檔案寫入的目錄。
- `fileName`：正在產生的 HTML 檔案名稱。
- `baseUri`：HTML 內連結至媒體檔案所使用的絕對 URI 前綴。

以下範例會匯出已嵌入於 `presentation.pptx` 的媒體。產生的 HTML 僅以檔名（相對於 HTML 文件）參考媒體檔案，因此 `path` 必須是同時放置 HTML 檔案的目錄。`baseUri` 必須是絕對 URI：對於本機預覽，可從輸出目錄建立 `file:///` URI；對於已部署的應用程式，請使用已發佈目錄的絕對 URL。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

請為每次匯出作業使用唯一的輸出目錄，尤其在伺服器應用程式中。共用的輸出路徑可能導致不同轉換的檔案相互覆蓋。

## **效能與資源管理**

HTML 轉換是一項渲染操作，處理時間與記憶體使用量取決於投影片數量、影像解析度、字型、效果、圖表以及嵌入的媒體。傳入較高的 DPI 值給 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setPicturesCompression)、嵌入字型、輸出 SVG 及保留裁切影像區域可提升相似度，但通常會增加輸出大小。

針對批次轉換：

- 盡快處置每個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。
- 為不同作業使用獨立的輸出目錄。
- 除非相似度需求，否則避免嵌入常見字型。
- 若 HTML 用於預覽或縮圖，降低影像 DPI。
- 在部署路徑確定前，將來源簡報、產生的 HTML 以及外部資源保持在同一位置。

## **常見問題**

**HTML 輸出是否保留超連結？**

是。簡報中的超連結會匯出至 HTML，且當目標 URL 有效時仍可點擊。

**我可以平行將簡報轉換為 HTML 嗎？**

可以，但不要在多個執行緒間共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。請為不同檔案使用獨立的簡報實例、獨立的串流與獨立的輸出目錄。詳情請參閱 [multithreading guidance](/slides/zh-hant/python-java/multithreading/)。

**簡報物件是執行緒安全的嗎？**

不是。單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例應在同一執行緒上載入、修改、儲存與釋放。若要平行作業，請為每個執行緒或行程建立獨立的實例。

**為什麼產生的 HTML 檔案很大？**

預設匯出會直接將資源嵌入 HTML。嵌入的字型、高 DPI 影像、媒體、SVG 內容以及保留的裁切影像區域都會增加大小。若較重視較小輸出，可改用外部資源、排除常見字型，並在 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setPicturesCompression) 中傳入較低的 DPI 值。

**為什麼 HTML 中的字型大小值與 PowerPoint 中不同？**

匯出的頁面可能使用 SVG 座標系統與縮放變換。單純的 CSS 或 SVG font-size 值並未完整描述最終顯示大小。請比較在預期縮放層級下的投影片渲染結果，並檢查字型是否可用，以解釋外觀差異。

**應如何為媒體匯出選擇 baseUri？**

請從瀏覽器的角度選擇 `baseUri`，並以絕對 URI 形式傳入。對於本機預覽，可使用 `output_directory.as_uri() + "/"` 產生；部署時請使用已發佈目錄的絕對 URL。檔案系統的 `path` 與瀏覽器的 `baseUri` 不必相同字串，但必須指向相同位置，且該位置必須是放置產生的 HTML 檔案的目錄，因為媒體連結是相對於它寫入的。

**我可以包含隱藏投影片嗎？**

可以。當必須匯出隱藏投影片時，請以 `True` 呼叫 [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setShowHiddenSlides)。