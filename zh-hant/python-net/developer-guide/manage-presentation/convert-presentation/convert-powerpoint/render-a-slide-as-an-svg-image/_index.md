---
title: 在 Python 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報 轉 SVG
- 投影片 轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字與圖像。"
---
## **概覽**

SVG 是一種可伸縮的基於 XML 的圖像格式，適用於 Web 發佈、投影片檢視器、無障礙工作流程以及自動後處理。Aspose.Slides 會將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片以及 SVG 元素的寫入方式。

當匯出的 SVG 必須緊湊、在不同瀏覽器間具有可預測性，或可供互動使用時，請使用 [SVGOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)，選取投影片，並將其寫入串流。以下範例會將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

檔案名稱使用 [Slide.slide_number](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/slide_number/) 而非迴圈索引。當投影片檢視器或網頁僅需要特定圖形時，亦可使用 [Shape.write_as_svg](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/write_as_svg/) 匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/) 控制 SVG 呈現方式。對於文字框，[SVGOptions.use_frame_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/use_frame_size/) 會將文字框納入呈現區域，而 [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) 決定是否套用文字框的旋轉。當文字必須在不使用連字的情況下呈現時，將 [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) 設為 `True`。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **控制文字與字型**

### **向量化所有文字**

將 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/vectorize_text/) 設為 `True`，可將所有投影片文字寫為向量圖形。這樣可消除字型相依性，並使視覺結果在不同瀏覽器間更一致，但文字將不再可作為 SVG 文字被選取或搜尋。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **選擇外部字型的處理方式**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) 會對外部載入的字型使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgexternalfontshandling/) 值。選擇 `ADD_LINKS_TO_FONT_FILES` 以參照個別字型檔案，`EMBED` 以在 SVG 中嵌入字型資料，或 `VECTORIZE` 只將使用外部字型的文字渲染為圖形。嵌入字型前請驗證字型授權。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **減少嵌入圖像大小**

使用 [SVGOptions.pictures_compression](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/pictures_compression/) 可降低嵌入圖片的解析度，使用 [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) 可省略裁切的來源區域，並使用 [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 來控制 JPEG 編碼品質。這些設定會以影像忠實度或保留的圖像資料為代價減少檔案大小。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **常見問題**

**何時應該使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/vectorize_text/) 而非 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgexternalfontshandling/)?**

當所有文字必須脫離字型相依時，請使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/vectorize_text/)。當僅需將使用外部字型的文字轉換為圖形時，請使用 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgexternalfontshandling/)。

**如何將 SVG 檔案縮小？**

首先壓縮嵌入的圖片、刪除裁切的圖像區域，並在目標環境能提供時選擇連結的字型檔案。請測試結果，因為較低的影像解析度、較低的 JPEG 品質以及向量化文字皆會產生不同的品質與大小權衡。