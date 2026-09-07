---
title: 在 Python 中將 PPT 與 PPTX 轉換為 JPG
linktitle: PowerPoint 轉 JPG
type: docs
weight: 60
url: /zh-hant/python-java/convert-powerpoint-to-jpg/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- PowerPoint 轉 JPG
- PPT 轉 JPG
- PPTX 轉 JPG
- 將投影片儲存為 JPG
- 匯出 PPT 為 JPG
- 匯出 PPTX 為 JPG
- Python
- Java
- Aspose.Slides
description: "在 Python（透過 Java）將 PowerPoint（PPT、PPTX）投影片轉換為 JPG 圖像。使用 Aspose.Slides 設定自訂影像尺寸並呈現備註與評論。"
---
## **簡介**

Aspose.Slides for Python via Java 讓您將 PowerPoint 與 OpenDocument 簡報（PPT、PPTX 與 ODP）轉換為 JPEG 圖像。您可以匯出每張投影片或選取的投影片，以產生縮圖、建構簡報檢視器，或在網站或應用程式中嵌入投影片預覽。

## **將 PowerPoint PPT/PPTX 轉換為 JPG**

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 載入簡報。
2. 使用 [getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 取得投影片。
3. 呼叫 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 並提供水平與垂直縮放比例，以呈現每張投影片。
4. 使用 [ImageFormat.Jpeg](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imageformat/#Jpeg) 將每個已呈現的影像儲存為 JPEG，然後釋放影像資源。

{{% alert color="info" title="Note" %}}匯出為 JPG 會為每張投影片產生一個獨立的圖像。請儲存已呈現的圖像，而不是直接將簡報另存為圖像格式。{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **將 PowerPoint PPT/PPTX 轉換為 JPG（自訂尺寸）**

根據所需的像素尺寸與原始投影片大小計算水平與垂直縮放比例，然後將它們傳遞給 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage)。以下範例針對每張投影片產生 1200 × 800 的圖像。

使用不同的縮放比例可能會拉伸投影片。若要保留其長寬比，請對兩個軸使用相同的縮放比例；如此產生的寬度與高度將遵循原始投影片的比例。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **儲存投影片為圖像時呈現註解**

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 來設定註解與備註，並透過 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 套用版面配置。此範例將備註放置於底部，超出區域的備註會被截斷，並在右側 200 像素寬的區域顯示註解。它會將每個已呈現的投影片儲存為 JPG 圖像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **常見問題**

**我可以同時將多張投影片或多個簡報轉換為 JPG 嗎？**  
可以。範例會遍歷所有投影片，並為每張投影片儲存一個 JPG。若要處理多個簡報，請對每個輸入檔案重複轉換，並使用不同的輸出資料夾或唯一的檔名，以免覆寫圖像。

**圖表、SmartArt、表格和形狀會包含在圖像中嗎？**  
這些物件會作為投影片的一部分被渲染。請確保轉換環境中提供簡報使用的字型，以減少因字型替換而產生的差異。

**在匯出大型簡報時，我該如何降低記憶體使用量？**  
一次處理一張影像，儲存後即釋放該影像，並避免使用不必要的大尺寸輸出。記憶體需求取決於投影片內容與圖像大小。

## **另見**

- [將 PowerPoint 轉換為 PNG](/slides/zh-hant/python-java/convert-powerpoint-to-png/).
- [將投影片呈現為 SVG 圖像](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/).