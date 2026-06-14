---
title: 在 Python 中將 PowerPoint 簡報轉換為 HTML
linktitle: PowerPoint 轉 HTML
type: docs
weight: 30
url: /zh-hant/python-net/convert-powerpoint-to-html/
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
- 將 PPT 匯出為 HTML
- 將 PPTX 匯出為 HTML
- Python
- Aspose.Slides
description: "在 Python 中將 PowerPoint 簡報轉換為 HTML。使用 Aspose.Slides 匯出 PPT 與 PPTX 檔案、選取的投影片、備註、字型、圖像、SVG 以及多媒體。"
---
## **概述**

Aspose.Slides for Python via .NET 可以在不安裝 Microsoft PowerPoint 的情況下將 PowerPoint 簡報儲存為 HTML。基本的轉換只需要載入一次 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)，然後使用 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/) 呼叫 `save`。當需要控制匯出版面、字型、圖像、備註、評論、SVG 輸出或連結資源時，請使用 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/)。

本指南聚焦於實務的 HTML 匯出情境：

- 匯出完整簡報或指定投影片。
- 產生固定版面、回應式或基於 SVG 的 HTML。
- 包含講者備註與評論。
- 控制圖像品質與裁切圖像資料。
- 內嵌字型或將字型檔另存。
- 選擇外部資源與多媒體檔案的寫入與參照方式。

預設情況下，HTML 匯出會產生一個自包含的 HTML 文件，絕大多數資源皆以內嵌方式呈現。這對於分享單一檔案很方便，但會增加輸出檔案大小。若要在網站上發佈，請考慮使用外部資源、降低圖像 DPI，並僅內嵌目標環境不一定可取得的字型。

## **將簡報轉換為 HTML**

要將簡報匯出為 HTML，只需使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 載入，然後以 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/) 進行 `save`。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

此範例會寫入一個 HTML 檔案。`with` 陳述式會在匯出完成後釋放簡報物件、檔案句柄與渲染資源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 是 HTML 匯出的主要設定類別。常用設定包括：

- `slides_layout_options`：加入備註、評論、講義或其他版面資訊。
- `html_formatter`：變更 HTML 文件結構或將格式化委派給控制器。
- `slide_image_format`：變更投影片的呈現方式，例如使用 SVG。
- `pictures_compression`：控制圖像 DPI 與輸出大小。
- `delete_pictures_cropped_areas`：保留或移除裁切圖像資料。
- `svg_responsive_layout`：讓匯出的 SVG 內容自動適應容器。
- `show_hidden_slides`：在需要時包含隱藏投影片。

以下章節會分別說明最常用的選項，讓您只結合工作流程需要的設定。

## **將指定投影片匯出為 HTML**

接受投影片編號的 `save` 重載使用 1 為起點的投影片位置。下方的迴圈會將每張投影片儲存為單獨的 HTML 檔案。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

當網站或應用程式需要每張投影片都有一個 HTML 頁面時，請使用此模式。若所有投影片使用相同版面，請建立一個 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 實例，並將其傳遞給每一次的 `save` 呼叫。

## **建立回應式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/responsivehtmlcontroller/) 透過 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmlformatter/) 提供回應式 HTML 輸出。當匯出頁面需要更好地適應瀏覽器寬度時，請使用它。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

若要使用基於 SVG 的回應式版面，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 上設定 `svg_responsive_layout`。當投影片內容以可縮放 SVG 標記匯出時，這非常有用。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **包含講者備註與評論**

透過 `html_options.slides_layout_options` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/) 以包含講者備註或評論。備註與評論預設為隱藏，除非您指定它們的位置。

假設來源簡報包含講者備註：

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

以下程式碼會將投影片內容與投影片下方的講者備註一起匯出。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

匯出的 HTML 包含備註區域：

![HTML output with the slide and speaker notes](HTML_with_notes.png)

若要匯出評論，請設定 `comments_position`，例如 `CommentsPositions.RIGHT` 或 `CommentsPositions.BOTTOM`。若只需要評論，請省略 `notes_position`。若同時需要備註與評論，則兩個屬性皆設定。

## **控制圖像品質與裁切區域**

HTML 匯出可以壓縮投影片圖像以減少輸出大小。當需要較高圖像品質時，請將 `pictures_compression` 設為 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/picturescompression/) 中的相應值。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

預設情況下，圖像的裁切區域可能會從匯出結果中移除。僅在使用者必須能夠復原或檢查這些隱藏圖像部分時才保留裁切資料。保留裁切區域會增加 HTML 大小。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **加入 CSS**

若只需簡易樣式，可將 CSS 字串傳遞給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmlformatter/)。這會改變外層的 HTML 文件，而 Aspose.Slides 仍負責渲染投影片內容。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

若需自訂文件標頭、連結的 CSS 檔案，或在投影片與圖形周圍加入自訂標記，請使用自訂格式化控制器，並以 `create_custom_formatter` 傳遞給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmlformatter/)。

## **內嵌字型**

如果目標環境未安裝簡報所使用的字型，請使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 於 HTML 中內嵌字型。內嵌可提升視覺一致性，但會增加輸出大小。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

僅在確定目標瀏覽器或系統已提供該字型時才排除它。對於品牌字型或較不常見的字型，內嵌通常較安全。

## **以連結方式提供字型檔案（不內嵌）**

為了減少 HTML 檔案大小，您可以將字型資料寫入獨立的 WOFF 檔案，並在 HTML 中加入 `@font-face` 規則。這需要一個自訂控制器，於匯出過程中自訂字型資料的寫入方式。於 Python via .NET 中，請在小型 .NET 輔助組件中實作該控制器，於 Python 中載入，並以 `create_custom_formatter` 傳遞給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmlformatter/)。

外部化字型時，請有意識地選擇兩條路徑：

- 檔案系統的輸出目錄，放置產生的 WOFF 檔案。
- 於 HTML 文件中出現的 URL 路徑，瀏覽器將依此下載字型檔。

在部署路徑最終確定前，請將 HTML 檔案與產生的字型檔案一起保留。若檔案最終會部署至其他位置，請確保 URL 前綴與實際部署的 URL 路徑相符。

## **外部儲存資源**

自包含的 HTML 方便搬移，但內嵌的 Base64 資源會讓檔案變大。如果您的應用程式需要外部圖像、字型、音訊或影片檔案，請使用自訂的連結/內嵌控制器，並將其傳遞給 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 建構子。

外部化資源時，同樣需有意識地選擇兩條路徑：

- 檔案系統的輸出路徑，您的應用程式會在此寫入產生的圖像、字型、音訊或影片。
- URL 路徑，瀏覽器會從 HTML 文件中使用此路徑載入這些檔案。

有關完整的圖像連結討論，請參閱 [Export Presentations to HTML with Externally Linked Images](/slides/zh-hant/python-net/exporting-presentations-to-html-with-externally-linked-images/)。

## **匯出多媒體檔案**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/videoplayerhtmlcontroller/) 會匯出影片與音訊檔案，並產生可在瀏覽器中播放的 HTML。其建構子接受：

- `path`：產生的多媒體檔案寫入的目錄。
- `file_name`：正在產生的 HTML 檔案名稱。
- `base_uri`：HTML 連結中指向多媒體檔案的絕對 URI 前綴。

若 HTML 檔案位於 `html-output/presentation.html`，而多媒體檔案儲存於 `html-output/media`，則 `path` 應指向磁碟上的 media 目錄，`base_uri` 則應指向瀏覽器觀點下同一目錄的 URL。對於本機預覽，可從 media 目錄產生 `file:///` URI；對於部署的應用程式，請使用已發布的 media 目錄的絕對 URL。

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

在伺服器應用程式中，請為每一次匯出作業使用唯一的輸出目錄。共用的輸出路徑會導致不同轉換產生的檔案相互覆寫。

## **效能與資源管理**

HTML 轉換屬於渲染操作，處理時間與記憶體使用量取決於投影片數量、圖像解析度、字型、特效、圖表與嵌入的多媒體。較高的 `pictures_compression` DPI、內嵌字型、SVG 輸出與保留裁切圖像區域會提升忠實度，但通常會增加輸出大小。

批次轉換時：

- 盡快釋放每個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。
- 為不同的作業使用獨立的輸出目錄。
- 除非忠實度必須，否則不要內嵌常見字型。
- 若 HTML 用於預覽或縮圖，請降低圖像 DPI。
- 在最終部署路徑確定之前，保持來源簡報、產生的 HTML 與外部資源在同一位置。

## **常見問題**

**HTML 輸出會保留超連結嗎？**

會。簡報中的超連結會匯出為 HTML 超連結，且在目標 URL 有效時仍可點擊。

**可以平行將簡報轉換為 HTML 嗎？**

可以，但不要在多個執行緒間共享同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。請使用不同的簡報實例、不同的串流與不同的輸出目錄處理不同檔案。相關說明請參閱 [multithreading guidance](/slides/zh-hant/python-net/multithreading/)。

**Presentation 物件是執行緒安全的嗎？**

不是。單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例應在同一個執行緒上完成載入、修改、儲存與釋放。若需平行作業，請為每個執行緒或行程建立獨立的實例。

**為什麼產生的 HTML 檔案很大？**

預設匯出會將資源直接內嵌於 HTML 中。內嵌字型、高 DPI 圖像、多媒體、SVG 內容以及保留的裁切圖像區域都會增加檔案大小。請改用外部資源、排除常見字型，並在較不需要最高忠實度時降低 `pictures_compression`。

**為何 PowerPoint 中的 24 pt 字型在 HTML 中顯示為 17.999819 pt？**

這是因為 PowerPoint 與 HTML 使用不同的 DPI 模型。PowerPoint 依據 72 DPI 的排版點儲存文字大小，而 HTML 版面則基於 96 DPI 的 CSS 像素。Aspose.Slides 在將簡報匯出為 HTML 時會在兩者之間轉換字型大小，過程中可能產生極小的四捨五入差異。

此差異不代表實際的視覺字型大小變化，僅是 PowerPoint 與 HTML 之間轉換數值的數學副作用。

**應該如何為多媒體匯出選擇 base_uri？**

從瀏覽器的觀點選擇 `base_uri`，並以絕對 URI 形式傳遞。對於本機預覽，可使用 `Path(media_directory).as_uri() + "/"` 產生；部署時請使用已發布的多媒體目錄的絕對 URL。檔案系統的 `path` 與瀏覽器的 `base_uri` 不必相同字串，但必須指向相同的資源位置。

**可以包含隱藏的投影片嗎？**

可以。當必須匯出隱藏投影片時，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 上設定 `show_hidden_slides = True`。