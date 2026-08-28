---
title: 在 Python 中將簡報投影片轉換為影像
linktitle: 投影片至影像
type: docs
weight: 41
url: /zh-hant/python-net/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉影像
- 將投影片儲存為影像
- 投影片轉 EMF
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉點陣圖
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides，將 PPT、PPTX 與 ODP 簡報的投影片轉換為 PNG、JPEG、GIF、TIFF、EMF 以及其他影像格式。"
---
## **簡介**

Aspose.Slides for Python via .NET 可以將 PowerPoint 與 OpenDocument 簡報的單一投影片渲染為 PNG、JPEG、GIF、TIFF 等影像格式。

將投影片轉換為影像的步驟如下：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入簡報。
2. 選取要渲染的投影片。
3. 如有需要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別設定渲染參數。
4. 呼叫 [Slide.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/) 方法，取得 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 物件。
5. 呼叫 [IImage.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/save/) 方法，並以 [ImageFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imageformat/) 指定輸出格式。

## **將投影片轉換為 PNG 影像**

最簡單的轉換方式使用預設渲染設定。產生的 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 物件可以在記憶體中處理或儲存為檔案。

以下 Python 範例將第一張投影片渲染並儲存為 PNG 影像：

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **使用自訂尺寸將投影片轉換為影像**

使用接受 [Size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.pydrawing/size/) 參數的 [Slide.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) 超載方法，可依精確的像素尺寸渲染投影片。

以下範例建立 1820 × 1040 的 JPEG 影像：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **將帶有備註與評論的投影片轉換為影像**

預設情況下，投影片影像不會包含備註或評論。將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/) 物件指派給 [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) 屬性，即可控制備註與評論的顯示位置。

以下範例將截斷的備註放在投影片下方，評論放在右側：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
在投影片轉影像的過程中，請勿將 [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) 屬性設為 [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notespositions/)。備註的文字可能超出固定影像大小。請改用 [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notespositions/)。
{{% /alert %}}

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別讓您控制渲染出的 TIFF 影像的大小、解析度與其他屬性。

以下範例將第一張投影片渲染為 2160 × 2880、300 DPI 的 TIFF 影像：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **將全部投影片轉換為影像**

遍歷投影片集合，可將整份簡報轉換為一系列影像。除非明確跳過，否則隱藏投影片也會被包含。

以下範例以水平與垂直縮放係數 2 渲染每張投影片為 JPEG 影像：

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **產生增強圖形檔 (EMF) 輸出**

增強圖形檔 (EMF) 在必須與 Microsoft Office 或其他支援 Windows 圖形檔的 Windows 應用程式交換向量圖形時非常有用。與像素圖不同，EMF 能保留向量繪圖操作，可在不失真的情況下縮放。然而，EMF 主要是針對具備 Windows 圖形檔支援的應用程式的相容格式，並非通用交換格式。另外，投影片中的複雜內容（如點陣圖影像與某些特效）可能會以點陣化元素存於向量圖形容器內。

### **將投影片匯出為 EMF**

[Slide.write_as_emf](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/write_as_emf/) 方法會將 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 以 EMF 格式寫入目標串流。以下範例載入簡報、選取第一張投影片，並寫入 EMF 檔案串流：

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

呼叫 [Slide.write_as_emf](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/write_as_emf/) 的程式碼擁有傳入的串流，必須自行關閉。Aspose.Slides 會在串流目前位置寫入資料，寫入完成後保持串流開啟。

### **將 SVG 影像轉換為 EMF 並加入簡報**

使用 [SvgImage.write_as_emf](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/write_as_emf/) 可將 SVG 內容轉為 EMF。產生的位元組可透過 [ImageCollection.add_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/add_image/) 加入簡報，並使用 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 放置於投影片上。

以下範例從 SVG 標記建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/)，轉換為記憶體中的 EMF，將該圖形插入第一張投影片，最後儲存簡報：

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/write_as_emf/) 不會取得目的串流的所有權。寫入後，串流位置位於產生資料的末端。請如上例呼叫 `getvalue` 取得完整緩衝區，無論目前串流位置為何。保持串流開啟直到資料讀取完畢，之後再關閉。

EMF 產生在 Aspose.Slides for Python via .NET 所支援的作業系統上皆可使用，但當字型或本機圖形相依性缺失時，各平台的渲染結果可能不同。請安裝來源內容使用的字型或設定適當的替代字型，並遵循 Aspose.Slides 的 [平台需求](/slides/zh-hant/python-net/system-requirements/)，在目標 EMF 使用應用程式中驗證結果。Linux 與 macOS 應用程式通常對 Windows 圖形檔的顯示與編輯支援有限或不一致。

## **彩色表情符號渲染**

{{% alert title="Note" color="info" %}}
在將簡報投影片轉換為影像時正確渲染彩色表情符號，必須在執行轉換的系統上安裝簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji** 而系統缺少此字型，表情符號可能會以單色方式顯示於輸出影像中。
{{% /alert %}}

## **常見問答**

**Aspose.Slides 是否支援渲染帶有動畫的投影片？**

不支援。[Slide.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/) 方法會渲染投影片的靜態影像，且不會匯出動畫。

**是否可以將隱藏的投影片匯出為影像？**

可以。隱藏投影片可如同一般投影片般渲染。只要在處理迴圈中包含它們，如前述範例所示。

**投影片影像會保留陰影與其他效果嗎？**

會。Aspose.Slides 會在投影片影像中渲染陰影、透明度與其他受支援的圖形效果。