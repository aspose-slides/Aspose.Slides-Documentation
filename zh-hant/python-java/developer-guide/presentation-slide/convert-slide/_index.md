---
title: 在 Python 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 35
url: /zh-hant/python-java/convert-slide/
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
description: "使用 Aspose.Slides 在 Python 中將 PPT、PPTX 與 ODP 簡報的投影片轉換為 PNG、JPEG、GIF、TIFF、EMF 及其他影像格式。"
---
## **簡介**

Aspose.Slides for Python via Java 能夠將 PowerPoint 與 OpenDocument 簡報的單張投影片轉換為 PNG、JPEG、GIF、TIFF 等圖像格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入簡報。
2. 選取要渲染的投影片。
3. 如有需要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/) 類別設定渲染參數。
4. 呼叫 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 方法，該方法會回傳影像物件。
5. 儲存影像，並使用 [ImageFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imageformat/) 指定輸出格式。

## **將投影片轉換為 PNG 影像**

最簡單的轉換使用預設的渲染設定。產生的影像物件可以在記憶體中處理或儲存為檔案。

以下 Python 範例會渲染第一張投影片，並將其儲存為 PNG 影像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **使用自訂尺寸將投影片轉換為影像**

使用接受 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 參數的 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 重載，以精確的像素尺寸渲染投影片。

以下範例會建立一個 1820 × 1040 的 JPEG 影像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **將含備註與評論的投影片轉換為影像**

預設情況下，投影片影像不會包含備註或評論。可將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 方法，以控制備註與評論的顯示位置。

以下範例會將截斷的備註放在投影片下方，評論則放在右側：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="警告" color="warning" %}}
在投影片轉影像的過程中，請勿將 [BottomFull](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/#BottomFull) 傳遞給 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法。備註的文字可能超過固定影像尺寸的容納範圍，請改用 [BottomTruncated](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/#BottomTruncated)。
{{% /alert %}}

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/) 類別可讓您控制渲染出的 TIFF 影像的尺寸、解析度及其他屬性。

以下範例會以 300 DPI 渲染第一張投影片為 2160 × 2880 的 TIFF 影像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="警告" color="warning" %}}
在 JDK 9 之前的 Java 版本中，無法保證支援 TIFF。
{{% /alert %}}

## **將全部投影片轉換為影像**

遍歷投影片集合即可將整個簡報轉換為一系列影像。若未特別略過，隱藏的投影片也會被包含。

以下範例會以水平與垂直 2 倍的比例因子，將每張投影片渲染為 JPEG 影像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **建立增強型中繼檔 (EMF) 輸出**

增強型中繼檔 (EMF) 在必須將向量圖形與 Microsoft Office 或其他支援 Windows 中繼檔的 Windows 應用程式交換時非常有用。與像素圖像不同，EMF 能保留向量繪圖操作，縮放時不會出現相同的銳利度損失。然而，EMF 主要是針對支援 Windows 中繼檔的應用程式的相容性格式，而非通用的交換格式。另外，複雜的投影片內容（例如點陣圖影像和某些特效）可能會在向量中繼檔容器內以光柵化元素儲存。

### **將投影片匯出為 EMF**

[Slide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 方法會將 [Slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 以 EMF 格式寫入目標串流。以下範例會載入簡報、選取第一張投影片，並將其寫入 EMF 檔案串流：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

如上所示，呼叫端負責管理傳遞給 [Slide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 的串流，並在使用完畢後關閉它。

### **將 SVG 影像轉換為 EMF 並加入簡報**

使用 [SvgImage.writeAsEmf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/) 可將 SVG 內容轉換為 EMF。產生的位元組可透過 [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagecollection/#addImage) 加入簡報，並使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addPictureFrame) 置於投影片上。

以下範例會從 SVG 標記建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/)，將其轉換為記憶體中的 EMF，插入第一張投影片，最後儲存簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/) 不會取得目標串流的所有權。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 會將所有產生的資料儲存於記憶體中，因此在呼叫 [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) 前不需重設位置。即使串流已關閉，回傳的位元組陣列仍然有效。

EMF 產生取決於所選擇的 Aspose.Slides for Python via Java 及 JDK 配置所支援的作業系統，但若缺少字型或圖形相依性，跨平台的渲染結果可能會不同。請安裝來源內容使用的字型或設定適當的替代字型，遵循 Aspose.Slides for Python via Java 的[平台需求](/slides/zh-hant/python-java/system-requirements/)，並在目標 EMF 應用程式中驗證結果。Linux 與 macOS 應用程式對 Windows 中繼檔的顯示與編輯支援常常有限或不一致。

## **彩色 Emoji 渲染**

{{% alert title="注意" color="info" %}}
在將簡報投影片轉換為影像時，若要正確呈現彩色 emoji，必須在執行轉換的系統上安裝簡報中使用的 emoji 字型。例如，若簡報使用 **Segoe UI Emoji** 且該字型缺失，輸出影像中的 emoji 可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染包含動畫的投影片？**

否。[Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 方法僅會渲染投影片的靜態影像，並不會匯出動畫。

**隱藏的投影片可以匯出為影像嗎？**

可以。隱藏的投影片可像一般投影片一樣渲染。請在處理迴圈中包含它們，如上述範例所示。

**投影片影像會保留陰影與其他效果嗎？**

會。Aspose.Slides 會在投影片影像中呈現陰影、透明度以及其他支援的圖形效果。