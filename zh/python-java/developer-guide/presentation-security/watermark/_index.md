---
title: 在 Python 中向演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/python-java/watermark/
keywords:
- 水印
- 文本水印
- 图片水印
- 添加水印
- 更改水印
- 删除水印
- 删除水印
- 向 PPT 添加水印
- 向 PPTX 添加水印
- 向 ODP 添加水印
- 从 PPT 删除水印
- 从 PPTX 删除水印
- 从 ODP 删除水印
- 从 PPT 删除水印
- 从 PPTX 删除水印
- 从 ODP 删除水印
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中管理 PowerPoint 和 OpenDocument 演示文稿的文本和图片水印，以标示草稿、机密信息、版权等。"
---
## **介绍**

**水印** 在演示文稿中是用于幻灯片或整个演示文稿的文字或图像印记。通常，水印用于指示演示文稿是草稿（例如，“Draft”水印）、包含机密信息（例如，“Confidential”水印）、指定所属公司（例如，“Company Name”水印）、标识演示文稿作者等。水印通过表明演示文稿不应被复制来帮助防止版权侵权。水印在 PowerPoint 和 OpenOffice 演示文稿格式中均可使用。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh/python-java/)，您可以通过多种方式在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共通点是，要添加文字水印，应使用 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 类；要添加图片水印，则使用 [PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/) 类或用图片填充水印形状。[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/) 继承自 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 类，您可以使用形状对象的所有灵活设置。由于 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 不是形状且其设置受限，它被包装在一个 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 对象中。

水印有两种应用方式：应用于单个幻灯片或应用于所有演示文稿幻灯片。Slide Master 用于将水印应用于所有幻灯片——水印被添加到 Slide Master，上面完整设计后，自动应用到所有幻灯片，而不会影响对单个幻灯片上水印的修改权限。

水印通常被视为其他用户不可编辑的对象。为防止水印（或更准确地说其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。特定形状可以在普通幻灯片或在 Slide Master 上锁定。当在 Slide Master 上锁定水印形状时，它将在所有演示文稿幻灯片上保持锁定。

您可以为水印设置名称，以便将来需要删除时能够通过名称在幻灯片的形状集合中找到它。

您可以以任意方式设计水印；不过水印通常具备一些共同特性，例如居中对齐、旋转、前置等。下面的示例将演示如何使用这些特性。

## **文字水印**

### **在幻灯片上添加文字水印**

要在 PPT、PPTX 或 ODP 中添加文字水印，首先向幻灯片添加一个形状，然后在该形状上添加文本框。文本框由 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 类表示。该类型未继承自 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/)，后者拥有丰富的属性用于灵活定位水印。因此，[TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 对象被包装在一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 对象中。要向形状添加水印文字，请使用如下所示的 [addTextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/#addTextFrame) 方法。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}} 
- [如何使用 TextFrame 类](/slides/zh/python-java/text-formatting/)
{{% /alert %}}

### **在演示文稿中添加文字水印**

如果想一次性为整个演示文稿（即所有幻灯片）添加文字水印，请将其添加到 [MasterSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/) 中。其余逻辑与向单个幻灯片添加水印相同——创建一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 对象，然后使用 [addTextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/#addTextFrame) 方法将水印添加进去。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}} 
- [如何使用幻灯片母版](/slides/zh/python-java/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充和线条颜色。下面的代码行将形状设为透明。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **设置文字水印的字体**

您可以按下面的示例更改文字水印的字体。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **设置水印文字颜色**

要设置水印文字的颜色，请使用以下代码：

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
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **居中文本水印**

可以将水印居中显示在幻灯片上，代码如下：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

下面的图片展示了最终效果。

![文字水印](text_watermark.png)

## **图片水印**

### **在演示文稿中添加图片水印**

要向演示文稿的幻灯片添加图片水印，可以按下面的步骤进行：

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **锁定水印防止编辑**

如果需要防止水印被编辑，可对形状调用 [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/#getAutoShapeLock) 方法。使用该属性可以保护形状不被选中、调整大小、重新定位、与其他元素组合、锁定其文字编辑等：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # 将水印形状锁定，防止被修改。
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **将水印置于前面**

在 Aspose.Slides 中，可通过 [ShapeCollection.reorder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#reorder) 方法设置形状的 Z 顺序。调用该方法时，需要从幻灯片的形状集合中传入形状引用和目标顺序号，从而实现将形状置于前面或发送到后面。此功能在需要将水印放置在演示文稿最前面的场景下尤为有用：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **设置水印旋转**

以下代码示例演示了如何调整水印的旋转角度，使其斜斜地跨越幻灯片：

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **为水印设置名称**

Aspose.Slides 允许为形状设置名称。通过形状名称，您可以在以后访问它以进行修改或删除。要为水印形状设置名称，请将其传递给 [Shape.setName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#setName) 方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **移除水印**

要移除水印形状，首先使用 [Shape.getName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getName) 方法在幻灯片形状集合中找到它，然后将该形状传入 [ShapeCollection.remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#remove) 方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **常见问题**

**什么是水印，为什么要使用它？**

水印是覆盖在幻灯片上的文字或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未经授权使用。

**我可以为演示文稿的所有幻灯片添加水印吗？**

可以，Aspose.Slides 允许通过编程方式为演示文稿的每一张幻灯片添加水印。您可以遍历所有幻灯片并逐个应用水印设置。

**如何调整水印的透明度？**

您可以通过修改形状的填充设置（[getFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getFillFormat)）来调整水印的透明度，从而使水印保持低调且不干扰幻灯片内容。

**支持哪些图片格式作为水印？**

Aspose.Slides 支持多种图片格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文字水印的字体和样式吗？**

可以，您可以选择任意字体、字号和样式，以匹配演示文稿的设计并保持品牌一致性。

**如何更改水印的位置或方向？**

您可以通过编程方式修改形状的坐标、尺寸和旋转属性来调整水印的位置和方向。