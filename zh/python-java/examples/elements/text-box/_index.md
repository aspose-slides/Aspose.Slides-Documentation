---
title: 文本框
type: docs
weight: 40
url: /zh/python-java/examples/elements/text-box/
keywords:
- 代码示例
- 文本框
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中处理文本框：在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、查找和删除文本。"
---
在 **Aspose.Slides for Python via Java** 中，文本框是一种包含文本的自动形状。几乎任何形状都可以包含文本，但典型的文本框没有填充或边框，仅显示文本。

本指南说明如何以编程方式添加、访问和删除文本框。

按照 [Installation](/slides/zh/python-java/installation/) 中的说明安装此包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行时导入 API。

## **添加文本框**

创建一个矩形，移除其填充和边框，并分配格式化文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 创建一个矩形形状。
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # 移除填充和边框，仅显示文本。
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # 设置默认文本格式。
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **按内容访问文本框**

添加一个示例文本框，然后查找文本中包含关键字 “Slide” 的形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # 使用匹配的文本框。
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **按内容删除文本框**

查找并删除第一张幻灯片上包含特定关键字的文本框。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
在删除匹配的形状之前，将它们收集到单独的列表中，以避免在迭代过程中修改形状集合。
{{% /alert %}}