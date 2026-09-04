---
title: 使用现代 API 在 Python 中增强图像处理
linktitle: 现代 API
type: docs
weight: 237
url: /zh/python-java/modern-api/
keywords:
- 现代 API
- 绘图
- 幻灯片缩略图
- 幻灯片转图像
- 形状缩略图
- 形状转图像
- 演示文稿缩略图
- 演示文稿转图像
- 添加图像
- 添加图片
- Python
- Java
- Aspose.Slides
description: "通过 Java 在 Python 中实现图像处理现代化：渲染幻灯片和形状、添加图片，并将已弃用的成像调用迁移至 Aspose.Slides 现代 API。"
---
## **介绍**

Aspose.Slides for Python via Java 通过 JPype 访问 Java 库。其旧版图像处理 API 使用来自 `java.awt` 的 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 和 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)。

Java 库从 24.4 版起便弃用这些成像 API。现代 API 使用 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/) 来加载、渲染和保存图像。请在新的 Python 代码以及迁移现有图像处理工作流时使用它。

{{% alert color="info" title="Note" %}}

下面的旧方法名称仅作迁移参考。它们在当前版本中已不再可用。可执行示例使用现代 API。

此更改并未完全消除所有 `java.awt` 类型：图像大小和图案颜色的重载仍然接受 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 和 [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html)。

{{% /alert %}}

## **现代 API**

主要的图像处理类型包括：

- [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/) — 表示栅格或矢量图像。
- [ImageFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imageformat/) — 提供图像文件格式常量。
- [Images](https://reference.aspose.com/slides/zh/python-java/aspose.slides/images/) — 用于创建图像，例如通过 [Images.fromFile](https://reference.aspose.com/slides/zh/python-java/aspose.slides/images/#fromFile)。

使用 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 或 [Shape.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage) 渲染单个幻灯片或形状。使用带有渲染选项的 [Presentation.getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 渲染多个幻灯片。无参数的重载返回演示文稿的图像集合。

通过 [Images.fromFile](https://reference.aspose.com/slides/zh/python-java/aspose.slides/images/#fromFile) 加载图像，使用 [ImageCollection.addImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imagecollection/#addImage) 将其添加，或使用 [PPImage.replaceImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#replaceImage) 更新现有演示文稿图像。两种图像集合操作均接受 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/)。

在 `finally` 块中调用每个加载或渲染的图像的 `dispose` 方法以释放资源。使用 [Presentation.dispose](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#dispose) 释放演示文稿。

### **准备 Python 环境**

按照 [Installation](/slides/zh/python-java/installation/) 中的说明安装包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后导入 API。示例保持 JVM 运行，以便后续重用。有关笔记本和 JVM 生命周期的指导，请参阅 [Limitations and API Differences](/slides/zh/python-java/limitations-and-api-differences/#import-the-library)。

打开 `pres.pptx` 的示例需要工作目录中存在该演示文稿。加载 `image.png` 的示例需要已有的图像文件。

### **加载图片并渲染幻灯片**

此示例将图片添加到第一张幻灯片并将该幻灯片保存为 JPEG 图像。 [IImage.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/#save) 会以指定格式写入渲染后的图像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **用现代 API 替换旧代码**

将旧的缩略图调用替换为返回 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/) 的方法，然后使用 [IImage.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/#save) 保存结果。这消除了将渲染图像传递给 [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-) 的需求。

### **按指定尺寸渲染幻灯片**

将旧的 `slide.getThumbnail(image_size)` 调用替换为使用相同图像尺寸的 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **获取幻灯片缩略图**

将旧的 `slide.getThumbnail()` 调用替换为不带参数的 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **获取形状缩略图**

将旧的 `shape.getThumbnail()` 调用替换为 [Shape.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage)。在访问形状之前请先确认幻灯片中包含该形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **获取演示文稿缩略图**

将旧的 `presentation.getThumbnails(options, image_size)` 调用替换为 [Presentation.getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages)。使用 [RenderingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/) 配置渲染。

直接使用 Python 的 `enumerate` 对返回的数组进行遍历。在 `finally` 块中释放每个返回的图像，以防保存失败导致剩余图像未被释放。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **向演示文稿添加图片**

将通过 [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) 加载的方式替换为 [Images.fromFile](https://reference.aspose.com/slides/zh/python-java/aspose.slides/images/#fromFile)，然后将得到的图像传递给 [ImageCollection.addImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imagecollection/#addImage)。将图片添加到幻灯片并保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **已弃用的方法及其在现代 API 中的替代**

表格使用 Python 调用记法。旧列中的名称标识已移除的 API；请使用链接的替代方法。现代图像渲染方法返回 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/) 对象，而不是 Java 缓冲图像。

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 在提供渲染选项时返回渲染图像数组。

| 旧调用 | 现代替代 |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 与 `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 与 `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 与 `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 与 `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 与 `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 与 `options, image_size` |

其中，`slides` 是一个基于 1 的 Java `int[]`，可使用 `jpype.JArray(jpype.JInt)([1, 3])` 创建，以选择第 1 张和第 3 张幻灯片。`image_size` 为 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)。

### **Shape**

| 旧调用 | 现代替代 |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage)（无参数） |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage) 与 `bounds, scale_x, scale_y` |

### **Slide**

| 旧调用 | 现代替代 |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage)（无参数） |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 与 `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 与 `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 与 `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 与 `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 与 `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 与 `image_size` |
| `slide.renderToGraphics(options, graphics)` | 无直接替代；请渲染为图像后再处理 |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | 无直接替代；请渲染为图像后再处理 |
| `slide.renderToGraphics(options, graphics, image_size)` | 无直接替代；请渲染为图像后再处理 |

其中，`options` 为 [RenderingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/)，`tiff_options` 为 [TiffOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/)。

### **Output**

| 旧调用 | 现代替代 |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/output/#add) 与 `path, image`，其中 `image` 为 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| 旧调用 | 现代替代 |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imagecollection/#addImage) 与 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/) |

### **PPImage**

| 旧调用 | 现代替代 |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getImage) |

要替换现有演示文稿图像的内容，请使用 [PPImage.replaceImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#replaceImage) 并传入 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/)。

### **PatternFormat**

| 旧调用 | 现代替代 |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/zh/python-java/aspose.slides/patternformat/#getTile) 与 `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/zh/python-java/aspose.slides/patternformat/#getTile) 与 `background, foreground` |

颜色参数仍为 Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) 对象。

### **PatternFormatEffectiveData**

对于通过 JPype 从 Java API 返回的有效图案数据，替代方法仍保留名称 `getTileIImage`。

| 旧调用 | 现代替代 |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`，返回 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/) |

## **Graphics2D 的 API 支持**

旧的 `renderToGraphics` 重载会在调用者提供的 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 上下文中绘制。现代 API 没有直接替代能够绘制到该上下文。

请使用 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 渲染单个幻灯片，或使用 [Presentation.getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 渲染多页幻灯片，然后使用 [IImage.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/#save) 保存返回的图像。将幻灯片渲染与自定义 Java 绘图相结合的应用需要调整其合成步骤。

## **常见问题**

**为什么要替换旧的 Java 成像 API？**

现代 API 将图像加载、渲染和保存统一到 [IImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/iimage/)，为这些工作流提供统一的图像抽象，而不再直接暴露 Java 缓冲图像或 Java 绘图上下文。

**仍然需要 Java 和 JPype 吗？**

需要。Aspose.Slides for Python via Java 仍然运行在 JVM 上。现代 API 只改变图像处理调用，不影响运行时要求。参见 [System Requirements](/slides/zh/python-java/system-requirements/)。

**如何在 Python 中释放图像？**

在 `finally` 块中对每个加载或渲染的图像调用 `dispose`。如果渲染了多张幻灯片，请对返回数组中的每个图像都进行释放。使用 [Presentation.dispose](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#dispose) 单独释放演示文稿。

**切换到现代 API 能保证更快的缩略图生成吗？**

不能保证性能提升。替代方法支持渲染选项、缩放和图像尺寸；请根据实际演示文稿和输出设置进行性能测量。

**为什么图像获取有时会返回集合？**

不带参数的 [Presentation.getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages) 返回嵌入的演示文稿图像。带有渲染选项的重载则返回渲染的幻灯片图像。