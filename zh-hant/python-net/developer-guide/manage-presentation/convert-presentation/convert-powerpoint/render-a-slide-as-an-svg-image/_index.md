---
title: 在 Python 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報轉 SVG
- 投影片轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字與圖片。"
---
## **概覽**

SVG 是一種可伸縮的基於 XML 的圖像格式，適用於網站發布、投影片檢視器、可及性工作流程以及自動後處理。Aspose.Slides 會將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片與 SVG 元素的寫入方式。

使用 [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) 當匯出的 SVG 必須緊湊、在不同瀏覽器間保持一致，或已準備好供互動使用。

## **匯出投影片為 SVG**

建立一個 [簡報](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，選取投影片，並寫入至串流。下列範例會將投影片文件中的每張投影片匯出為單獨的 SVG 檔案。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

檔名使用 [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) 而非迴圈索引。當投影片檢視器或網頁只需要該圖形時，也可以使用 [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) 匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) 控制 SVG 呈現。對於文字框，[SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) 會將文字框納入渲染區域，而 [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) 決定是否套用框的旋轉。當文字必須在沒有連字的情況下渲染時，將 [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) 設為 `True`。

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

## **控制箭頭端點的線段裁切**

SVG 1.1 沒有標記內縮設定，可指定線條在箭頭下方的停止位置。預設情況下，Aspose.Slides 會縮短匯出的線條，使其筆畫不會伸出標記。將 [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) 設為 `True`，即可將筆畫畫至線條原始端點。此設定僅影響 SVG 輸出。線條在投影片上的位置與長度保持不變。

範例在 2 點與 10 點寬的線條上繪製三角形與菱形箭頭，並將相同投影片匯出兩次，僅更改裁切選項。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

比較顯示 10 點寬線條上的三角形箭頭。啟用裁切時，尖端銳利；停用裁切時，筆畫會從標記的斜邊伸出，形成平坦的末端。

![裁切啟用時呈現尖銳尖端、裁切停用時呈現平坦末端的放大 10 點三角形](line-end-cropping.png)

在範例的其他線條中，2 點三角形的突伸筆畫較不明顯。實心菱形在兩種寬度下皆覆蓋筆畫的末端。

## **控制文字與字型**

匯出投影片為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參考方式。以下選項可協助您在匯出的 SVG 中平衡視覺一致性、文字選取與字型相依性。

### **將所有文字向量化**

將 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) 設為 `True`，即可將所有投影片文字寫入為向量圖形。這會消除字型相依性，使視覺效果在不同瀏覽器間更一致，但文字將無法作為 SVG 文字被選取或搜尋。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **選擇外部字型的處理方式**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) 針對外部載入的字型使用一個 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) 值。選擇 `ADD_LINKS_TO_FONT_FILES` 以參照獨立的字型檔案、`EMBED` 以在 SVG 中嵌入字型資料，或 `VECTORIZE` 只將使用外部字型的文字渲染為圖形。嵌入字型前請先確認字型授權。

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

使用 [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) 降低嵌入圖片的解析度，使用 [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) 省略裁切的來源區域，並使用 [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 控制 JPEG 編碼品質。這些設定會以影像忠實度或保留圖像資料為代價減少檔案大小。

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

## **控制 Metafile 點陣化解析度**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) 設定在 SVG 匯出過程中點陣化中繪圖檔的最低解析度上限。當 EMF 或 WMF 圖像被點陣化時，可使用它在細節與檔案大小之間取得平衡。它不會為 SVG 定義全域 DPI，也不會強制投影片上的每個物件皆轉為點陣圖像。

下載 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含具有密集對角線的 EMF 圖像。下列範例透過 [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) 將其第一張投影片以三種點陣化解析度匯出。所有其他匯出設定保持相同，以便比較結果。

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

在輸出中，EMF 會在每個 SVG 中變為一個嵌入的 PNG。下列測量數據僅針對提供的簡報；它們並非將 DPI 轉換為像素尺寸的一般公式。

| 中繪圖檔點陣化 DPI | 嵌入 PNG 尺寸 | SVG 檔案大小（位元組） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下比較顯示相同區域的嵌入點陣圖在相同放大顯示尺寸下的差異。對角線在 72 DPI 時呈現明顯像素化，在較高解析度時邊緣較平滑，同時 SVG 檔案大小會增長。提高此值不一定能改善所有細節或改變每張匯出的圖像。

![72、150 與 300 DPI 放大之對角線細節](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) 控制圖像解析度的降低，且可能掩蓋變更中繪圖檔點陣化解析度的效果。[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 控制 JPEG 編碼品質，而非中繪圖檔點陣化解析度。

## **常見問題**

**何時應該使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) 而非 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

當所有文字必須脫離字型相依性時，請使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)。當僅需將使用外部字型的文字轉換為圖形時，請使用 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)。

**如何才能讓 SVG 檔案更小？**

首先可壓縮嵌入的圖片、刪除裁切的圖像區域，並在目標環境可提供字型檔時選擇以連結方式使用字型檔。請測試結果，因為降低圖像解析度、降低 JPEG 品質以及向量化文字各自具有不同的品質與大小取捨。