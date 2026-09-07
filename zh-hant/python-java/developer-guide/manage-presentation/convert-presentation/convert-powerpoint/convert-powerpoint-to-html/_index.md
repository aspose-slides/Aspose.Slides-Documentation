---
title: 在 Python（使用 Java）中將 PowerPoint 簡報轉換為 HTML
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
description: "在 Python（使用 Java）中將 PowerPoint 簡報轉換為 HTML。使用 Aspose.Slides 匯出 PPT 與 PPTX 檔案、選取的投影片、備註、字型、影像、SVG 以及媒體。"
---
## **概覽**

Aspose.Slides for Python via Java 可以在不使用 Microsoft PowerPoint 的情況下，將 PowerPoint 簡報儲存為 HTML。基本的轉換是載入單一 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)，再呼叫 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 並指定 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/)。在需要控制匯出版面配置、字型、影像、備註、評論、SVG 輸出或連結資源時，使用 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/)。

本指南聚焦於實用的 HTML 匯出情境：

- 匯出整份簡報或選取的投影片。
- 產生固定版面、回應式或基於 SVG 的 HTML。
- 包含說明者備註與評論。
- 控制影像品質與裁切影像資料。
- 將字型嵌入或將字型檔分別儲存。
- 選擇外部資源與媒體檔案的寫入與參照方式。

預設情況下，HTML 匯出會產生自包含的 HTML 文件，將大部分資源內嵌。這對於共享單一檔案很方便，但會增加輸出大小。若為網站發佈，請考慮使用外部資源、降低影像 DPI，僅嵌入目標環境中不一定可取得的字型。

## **將簡報轉換為 HTML**

若要將簡報匯出為 HTML，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 載入，並以 [SaveFormat.Html](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Html) 進行儲存。

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

每個範例皆從目前工作目錄載入 `presentation.pptx`。執行前請先安裝 Aspose.Slides for Python via Java 以及相容的 Java 執行階段環境。JVM 會在每個 Python 行程啟動一次。

此範例會寫入單一 HTML 檔案。簡報物件於 `finally` 區塊中釋放，以在匯出後釋放檔案句柄與渲染資源。

## **設定 HTML 匯出**

[HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/) 是 HTML 匯出的主要設定類別。常用設定包括：

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions)：加入備註、評論、講義或其他版面資訊。
- [setHtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setHtmlFormatter)：變更 HTML 文件結構或委派格式化給控制器。
- [setSlideImageFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSlideImageFormat)：變更投影片的呈現方式，例如以 SVG。
- [setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setPicturesCompression)：控制影像 DPI 與輸出大小。
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas)：保留或移除裁切影像資料。
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout)：使匯出的 SVG 內容適應其容器。
- [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setShowHiddenSlides)：在需要時包含隱藏投影片。

以下章節分別說明最常用的選項，您可依需求自行組合。

## **將選取的投影片轉換為 HTML**

接受投影片編號的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 之重載以 1 為基礎的投影片位置計算。下面的迴圈會將每張投影片儲存為單獨的 HTML 檔案。

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

當網站或應用程式需要每張投影片對應一個 HTML 頁面時，請使用此模式。如果每張投影片的版面相同，請建立一個 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/) 實例，並在每次呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 時傳入。

## **建立回應式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/responsivehtmlcontroller/) 透過 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmlformatter/) 提供回應式 HTML 輸出。當匯出的頁面需更好地適應瀏覽器寬度時，請使用它。

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

若要使用基於 SVG 的回應式版面，請以 `True` 呼叫 [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout)。此方式在投影片內容以可縮放的 SVG 標記匯出時特別有用。

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

## **包含說明者備註與評論**

透過 [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 以加入說明者備註或評論。預設情況下備註與評論皆為隱藏，除非明確指定其位置。

假設來源簡報包含說明者備註：

![含說明者備註的投影片示例](slide_with_notes.png)

以下程式碼會將投影片內容及其下方的說明者備註一起匯出。

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

匯出的 HTML 會包含備註區域：

![HTML 輸出顯示投影片與說明者備註](HTML_with_notes.png)

若要匯出評論，請呼叫 [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)，例如使用 [CommentsPositions.Right](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commentspositions/#Right) 或 [CommentsPositions.Bottom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commentspositions/#Bottom)。若只需評論，請省略 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)。若同時需要備註與評論，則兩個方法皆呼叫。

## **控制影像品質與裁切區域**

HTML 匯出可以壓縮投影片影像以減少輸出大小。當需要較高影像品質時，請從 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturescompression/) 傳入值給 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setPicturesCompression)。

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

預設情況下，裁切過的影像區域可能會從匯出結果中移除。僅在使用者必須能夠復原或檢查這些隱藏影像部份時才保留裁切資料。保留會增加 HTML 大小。

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

若僅需簡單樣式，可將 CSS 字串傳遞給 [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmlformatter/#createDocumentFormatter)。這會變更外圍的 HTML 文件，同時 Aspose.Slides 仍負責渲染投影片內容。

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

若需自訂文件標頭、連結的 CSS 檔或自訂投影片與圖形的標記，請透過 JPype 介面代理實作自訂格式化控制器，並將其傳遞給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmlformatter/) 的 [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmlformatter/#createCustomFormatter)。

## **嵌入字型**

如果目標環境可能未安裝簡報所使用的字型，請使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/embedallfontshtmlcontroller/) 將字型嵌入 HTML。嵌入可提升視覺還原度，但會增加輸出大小。

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

僅在確信目標瀏覽器或系統已提供所需字型時才排除嵌入。對於品牌字型或較不常見的字型，嵌入通常較安全。

## **外部儲存資源**

自包含的 HTML 易於搬移，但內嵌的 Base64 資源會使檔案變大。如果應用程式需要外部影像檔，請透過 JPype 介面代理實作資源連結控制器，並將其傳遞給 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/) 建構子。

在外部化資源時，請有意識地選擇兩條路徑：

- 檔案系統輸出路徑：您的應用程式寫入產生的影像、字型、音訊或視訊檔案的目錄。
- URL 路徑：瀏覽器從 HTML 文件載入這些檔案時所使用的路徑。

## **匯出媒體檔案**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoplayerhtmlcontroller/) 會匯出影片與音訊檔案，並產生可在瀏覽器播放的 HTML。其建構子接受：

- `path`：產生的媒體檔案寫入的目錄。
- `fileName`：正在產生的 HTML 檔名。
- `baseUri`：HTML 內部指向媒體檔案的絕對 URI 前綴。

以下範例會匯出已內嵌於 `presentation.pptx` 的媒體。產生的 HTML 只以檔名引用媒體檔案，路徑相對於 HTML 文件，因此 `path` 必須同時是放置 HTML 檔案的目錄。`baseUri` 必須是絕對 URI：本機預覽時可從輸出目錄組合 `file:///` URI；部署時則使用已發佈目錄的絕對 URL。

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

請為每次匯出作業使用唯一的輸出目錄，特別是在伺服器應用程式中。共用輸出路徑可能導致不同轉換的檔案互相覆寫。

## **效能與資源管理**

HTML 轉換屬於渲染操作，處理時間與記憶體使用量取決於投影片數量、影像解析度、字型、特效、圖表與嵌入的媒體。傳遞較高 DPI 給 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setPicturesCompression)、嵌入字型、產生 SVG 輸出、保留裁切影像區域雖可提升還原度，卻通常會增加輸出大小。

批次轉換時的建議：

- 盡快釋放每個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。
- 為不同作業使用獨立的輸出目錄。
- 除非需要最高還原度，否則避免嵌入常見字型。
- 若 HTML 僅供預覽或縮圖使用，降低影像 DPI。
- 在部署路徑最終確定前，請保留來源簡報、產生的 HTML 及外部資源在同一位置。

## **FAQ**

**HTML 輸出會保留超連結嗎？**

會。簡報中的超連結會匯出至 HTML，且在目標 URL 有效時保持可點擊。

**可以平行轉換多個簡報為 HTML 嗎？**

可以，但請勿在多執行緒間共享同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。請以不同的簡報實例、不同的資料流與不同的輸出目錄處理不同檔案。相關說明請參考 [multithreading guidance](/slides/zh-hant/python-java/multithreading/)。

**簡報物件本身是執行緒安全的嗎？**

不是。單一 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 應於同一執行緒內載入、修改、儲存並釋放。若需平行工作，請為每個執行緒或處理程序建立獨立的實例。

**為什麼產生的 HTML 檔案很大？**

預設匯出會直接將資源內嵌於 HTML。嵌入的字型、高 DPI 影像、媒體、SVG 內容以及保留的裁切影像區域都會增加檔案大小。可改用外部資源、排除常見字型，或在 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setPicturesCompression) 中傳入較低的 DPI 值，以在大小與還原度之間取得平衡。

**為什麼 HTML 中的字型大小與 PowerPoint 中不同？**

匯出的頁面可能使用 SVG 座標系統與縮放變換。單純的 CSS 或 SVG `font-size` 值並未完整描述最終顯示尺寸。請以預期的縮放層級檢視渲染後的投影片，並確認字型是否可用。

**媒體匯出的 baseUri 應如何選擇？**

從瀏覽器的觀點選擇 `baseUri`，並以絕對 URI 形式傳入。本機預覽時可從輸出目錄組合 `output_directory.as_uri() + "/"`。部署時則使用已發佈目錄的絕對 URL。檔案系統的 `path` 與瀏覽器的 `baseUri` 不必完全相同字串，但必須指向同一位置，且該位置須是產生 HTML 檔案的目錄，因為媒體連結是相對於該目錄寫入的。

**可以包含隱藏投影片嗎？**

可以。當必須匯出隱藏投影片時，請以 `True` 呼叫 [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#setShowHiddenSlides)。