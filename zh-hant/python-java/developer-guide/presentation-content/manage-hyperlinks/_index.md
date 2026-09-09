---
title: 使用 Python 透過 Java 管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/python-java/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 影像超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 Java，輕鬆管理 PowerPoint 與 OpenDocument 簡報中的超連結——在數分鐘內提升互動性與工作流程。"
---
## **簡介**

超連結是對物件、資料或位置的參照。PowerPoint 簡報中常見的超連結包括：

* 文字、圖形或媒體中的網站連結
* 投影片連結

Aspose.Slides for Python via Java 讓您可以執行許多與簡報超連結相關的任務。 

{{% alert color="info" title="注意" %}} 
您可能想瞭解 Aspose 簡單的，[免費線上 PowerPoint 編輯器。](https://products.aspose.app/slides/zh-hant/editor)
{{% /alert %}} 

## **新增 URL 超連結**

### **將 URL 超連結新增至文字**

此 Python 程式碼示範如何將網站超連結新增至文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **將 URL 超連結新增至圖形或框架**

此 Python via Java 示例程式碼示範如何將網站超連結新增至圖形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **將 URL 超連結新增至媒體**

Aspose.Slides 允許您將超連結新增至圖像、音訊和影片檔案。 

此示例程式碼示範如何將超連結新增至 **圖像**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # 新增影像至簡報
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # 在第1張投影片上建立圖片框，基於先前新增的影像
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此示例程式碼示範如何將超連結新增至 **音訊檔案**：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此示例程式碼示範如何將超連結新增至 **影片**：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="提示" %}} 
您可能想查看 *[管理 OLE](/slides/zh-hant/python-java/manage-ole/)*。
{{% /alert %}}

## **使用超連結建立目錄**

由於超連結允許您加入對物件或位置的參照，您可以利用它們建立目錄。 

此示例程式碼示範如何使用超連結建立目錄：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **格式化超連結**

### **顏色**

使用 [Hyperlink.setColorSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlink/#setColorSource) 屬性於 [Hyperlink](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlink/) 類別，您可以設定超連結的顏色，也能從超連結取得顏色資訊。此功能於 PowerPoint 2019 首次推出，因此屬性相關的變更不適用於較舊的 PowerPoint 版本。

此示例程式碼示範在同一投影片中加入不同顏色的超連結的操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **從簡報中移除超連結**

### **從文字中移除超連結**

此 Python 程式碼示範如何從簡報投影片的文字中移除超連結：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **從圖形或框架中移除超連結**

此 Python 程式碼示範如何從簡報投影片的圖形中移除超連結：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **可變的超連結**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlink/) 類別是可變的。使用此類別，您可以變更以下屬性的值：

- [setTargetFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

此程式碼片段示範如何將超連結新增至投影片，並之後編輯其工具提示：

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # 更改已新增超連結的工具提示
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HyperlinkQueries 支援的屬性**

您可以從定義了超連結的簡報、投影片或文字中存取 [HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlinkqueries/)。 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#getHyperlinkQueries)

[HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlinkqueries/) 類別支援以下方法與屬性： 

- [getHyperlinkClicks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **常見問題**

**如何建立不僅指向投影片，而是指向「區段」或區段第一張投影片的內部導覽？**

PowerPoint 中的區段是投影片的分組；導覽在技術上仍指向特定投影片。若要「導覽至區段」，通常會連結到該區段的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上都有效嗎？**

可以。母片和版面配置元素支援超連結。這類連結會出現在子投影片上，並在投影片放映時可點選。

**匯出為 PDF、HTML、圖像或影片時，超連結會被保留嗎？**

在 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/) 和 [HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/) 中，會保留連結；通常會保持超連結。然而，匯出至 [images](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 和 [video](/slides/zh-hant/python-java/convert-powerpoint-to-video/) 時，因為這些格式（點陣框架/影片）不支援超連結，點擊功能將不會保留。