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
## **概觀**

SVG 是一種可伸縮的基於 XML 的影像格式，適用於 Web 發佈、投影片檢視器、可存取性工作流程以及自動化後處理。Aspose.Slides 將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片和 SVG 元素的寫入方式。

使用 [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) 當匯出的 SVG 必須緊湊、在各瀏覽器間可預測，或準備好供互動使用。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，選取投影片，並將其寫入串流。以下範例將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

檔名使用 [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) 而非迴圈索引。您也可以使用 [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) 匯出單一圖形，當投影片檢視器或網頁僅需要該圖形時。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) 控制 SVG 呈現。對於文字框， [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) 會在呈現區域中包含文字框，而 [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) 決定是否套用框的旋轉。當文字必須在不使用連字的情況下呈現時，將 [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) 設為 `True`。

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

在將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參照方式。以下選項可協助您在匯出的 SVG 中取得視覺一致性、文字可選取性與字型依賴性的平衡。

### **向量化全部文字**

將 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) 設為 `True`，可將所有投影片文字寫為向量圖形。此方式消除字型依賴，使視覺結果在各瀏覽器間更為一致，但文字將不再可於 SVG 中選取或搜尋。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **選擇外部字型的處理方式**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) 會使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) 的值來處理外部載入的字型。選擇 `ADD_LINKS_TO_FONT_FILES` 以參照獨立的字型檔案、`EMBED` 以將字型資料嵌入 SVG，或 `VECTORIZE` 以僅將使用外部字型的文字渲染為圖形。在嵌入字型之前請確認字型授權。

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

使用 [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) 可降低嵌入圖片的解析度，使用 [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) 可省略被裁剪的來源區域，使用 [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 可控制 JPEG 編碼品質。這些設定會以影像保真度或保留的圖像資料為代價減少檔案大小。

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

## **控制 Metafile 光柵化解析度**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) 設定在 SVG 匯出期間對 Metafile 進行光柵化時的最低解析度上限。當 EMF 或 WMF 圖像被光柵化時，可利用此設定在細節與檔案大小之間取得平衡。它不會為整個 SVG 定義全局 DPI，也不會強制投影片上的每個物件皆成為光柵圖像。

Download [metafile-rasterization.pptx](metafile-rasterization.pptx)，其包含間距緊密的對角線 EMF 圖像。以下範例透過 [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) 以三種光柵化解析度匯出其第一張投影片。所有其他匯出設定保持相同，以便比較結果。

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

在輸出中，EMF 會在每個 SVG 中成為一個嵌入的 PNG。以下測量值僅針對提供的簡報；它們並非將 DPI 轉換為像素尺寸的一般公式。

| Metafile 光柵化 DPI | 嵌入 PNG 尺寸 | SVG 檔案大小（位元組） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下方的比較顯示在相同放大顯示尺寸下嵌入光柵的相同區域。對角線在 72 DPI 時會出現明顯的像素化，而在較高解析度下邊緣更平滑，且 SVG 檔案大小會增大。提升此值不一定能改善所有細節或改變每張匯出的圖像。

![在 72、150、300 DPI 放大的對角線細節](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) 控制圖像解析度降低，並可能掩蓋改變 Metafile 光柵化解析度的效果。[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 控制 JPEG 編碼品質，而非 Metafile 光柵化解析度。

## **常見問題**

**何時應使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) 而非 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

當所有文字必須不受字型限制時，請使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)。僅當需將使用外部字型的文字轉換為圖形時，請使用 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)。

**如何讓 SVG 檔案變小？**

首先壓縮嵌入的圖片，刪除被裁剪的影像區域，並在目標環境能提供字型檔時選擇連結字型檔。請測試結果，因為較低的影像解析度、較低的 JPEG 品質以及向量化文字各有不同的品質與大小取捨。