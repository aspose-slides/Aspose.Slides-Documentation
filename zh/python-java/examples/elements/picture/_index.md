---
title: 图片
type: docs
weight: 50
url: /zh/python-java/examples/elements/picture/
keywords:
- 代码示例
- 图片
- 添加图片
- 访问图片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在内存中创建的图片进行插入和访问，提供 PowerPoint 和 OpenDocument 演示文稿的示例。"
---
本文演示如何使用 **Aspose.Slides for Python via Java** 从内存中的图像插入并访问图片。以下示例在内存中创建图像，将其放置在幻灯片上，然后检索图片框。

按照[安装](/slides/zh/python-java/installation/)中描述的方法安装软件包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后导入 API。

## **添加图片**

此代码生成一个小位图，将其转换为流，并将其作为图片框插入到第一张幻灯片中。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 创建一个简单的内存图像。
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # 将位图转换为字节数组。
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # 将图像添加到演示文稿。
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # 在第一页幻灯片上插入显示该图像的图片框。
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **访问图片**

此示例确保幻灯片包含图片框，然后访问找到的第一个图片框。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import PictureFrame, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bitmap = BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB)
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image)

    picture_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is None:
        print("The slide contains no picture frames.")
finally:
    presentation.dispose()
```