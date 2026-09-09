---
title: 在 Python via Java 中管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/python-java/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 删除超链接
- 更新超链接
- 文本超链接
- 幻灯片超链接
- 形状超链接
- 图像超链接
- 视频超链接
- 可变超链接
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，轻松管理 PowerPoint 和 OpenDocument 演示文稿中的超链接——在几分钟内提升交互性和工作流程。"
---
## **简介**

超链接是对对象、数据或位置的引用。PowerPoint 演示文稿中常见的超链接包括：

* 文本、形状或多媒体中的网站链接
* 幻灯片链接

Aspose.Slides for Python via Java 允许您在演示文稿中执行许多涉及超链接的任务。

{{% alert color="info" title="Note" %}} 
您可能想尝试 Aspose 的免费在线 PowerPoint 编辑器。[免费在线 PowerPoint 编辑器.](https://products.aspose.app/slides/zh/editor)
{{% /alert %}} 

## **添加 URL 超链接**

### **向文本添加 URL 超链接**

以下 Python 代码演示了如何向文本添加网站超链接：

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

### **向形状或框架添加 URL 超链接**

以下 Python via Java 示例代码演示了如何向形状添加网站超链接：

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

### **向媒体添加 URL 超链接**

Aspose.Slides 允许您为图像、音频和视频文件添加超链接。

以下示例代码演示了如何为**图像**添加超链接：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # 将图像添加到演示文稿
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # 在第 1 张幻灯片上创建基于先前添加的图像的图片框
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下示例代码演示了如何为**音频文件**添加超链接：

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

以下示例代码演示了如何为**视频**添加超链接：

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

{{% alert color="success" title="Tip" %}} 
您可能想查看 *[管理 OLE](/slides/zh/python-java/manage-ole/)*。
{{% /alert %}}

## **使用超链接创建目录**

由于超链接可以添加对对象或位置的引用，您可以使用它们创建目录。

以下示例代码演示了如何使用超链接创建目录：

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

## **格式化超链接**

### **颜色**

使用 [Hyperlink.setColorSource](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlink/#setColorSource) 属性（位于 [Hyperlink](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlink/) 类），您可以设置超链接的颜色，也可以获取超链接的颜色信息。此功能首次在 PowerPoint 2019 中引入，因此对该属性的更改不适用于旧版 PowerPoint。

以下示例代码演示了在同一幻灯片上添加不同颜色超链接的操作：

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

## **从演示文稿中删除超链接**

### **从文本中删除超链接**

以下 Python 代码演示了如何从演示文稿幻灯片上的文本中删除超链接：

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

### **从形状或框架中删除超链接**

以下 Python 代码演示了如何从演示文稿幻灯片上的形状中删除超链接：

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

## **可变超链接**

[Hyperlink](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlink/) 类是可变的。使用此类，您可以更改以下属性的值：

- [setTargetFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

以下代码片段展示了如何向幻灯片添加超链接并随后编辑其工具提示：

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

    # 更改已添加的超链接的工具提示
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HyperlinkQueries 支持的属性**

您可以从演示文稿、幻灯片或定义了超链接的文本中访问 [HyperlinkQueries](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlinkqueries/)。

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getHyperlinkQueries)

[HyperlinkQueries](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlinkqueries/) 类支持以下方法和属性：

- [getHyperlinkClicks](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/zh/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **常见问题**

**如何创建不仅指向幻灯片而且指向“章节”或章节第一张幻灯片的内部导航？**

PowerPoint 中的章节是幻灯片的分组；导航在技术上仍然定位到具体的幻灯片。要“导航到章节”，通常链接到该章节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素，使其在所有幻灯片上生效吗？**

可以。母版幻灯片和布局元素支持超链接。这些链接会出现在子幻灯片上，并在放映时可点击。

**将超链接导出为 PDF、HTML、图像或视频时会保留吗？**

在 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/) 和 [HTML](/slides/zh/python-java/convert-powerpoint-to-html/) 中会保留——链接通常会被保留。导出为 [图像](/slides/zh/python-java/convert-powerpoint-to-png/) 和 [视频](/slides/zh/python-java/convert-powerpoint-to-video/) 时，由于这些格式本质上是光栅帧/视频，不支持超链接，点击功能将不会保留。