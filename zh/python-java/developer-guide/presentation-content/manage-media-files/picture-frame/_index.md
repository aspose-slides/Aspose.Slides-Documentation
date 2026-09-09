---
title: 使用 Python 在演示文稿中管理图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/python-java/picture-frame/
keywords:
- 图片框
- 添加图片框
- 创建图片框
- 嵌入图像
- 链接图像
- 提取图像
- 光栅图像
- SVG 图像
- 裁剪图像
- 删除裁剪区域
- 压缩图像
- StretchOffset
- 图片框格式化
- 相对比例
- 图像效果
- 宽高比
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是一种在幻灯片中显示图像的形状。在 Aspose.Slides 中，图像资源与显示它的形状是分离的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 通过其 [ImageCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imagecollection/) 拥有嵌入的图像资源，而 [PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

当同一图像显示多次时，这种分离很有用。将图像添加到演示文稿一次，保留返回的 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/)，并在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等光栅图像以及 SVG 矢量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。此选择会影响可移植性、文件大小、提取和导出行为，因此在应用格式化或优化之前决定图像的存储方式是有用的。

## **添加并格式化嵌入图像**

对于嵌入图像，向演示文稿添加图像数据并使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addPictureFrame) 创建图片框。图像成为演示文稿包的一部分，因此在移动到另一台计算机时演示文稿保持自包含。

下面的示例添加 JPEG 图像，按图像的原始尺寸创建框，并应用线条格式和旋转：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

图片框控制显示的几何形状；更改框的大小不会改变嵌入图像资源中存储的原始像素尺寸。当随后对图像进行裁剪或压缩时，这一区别变得重要。

## **使用相对比例**

[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/) 通过 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) 和 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) 对框提供相对宽度和高度的比例。值为 `1.0` 对应原始图片大小的 100%。当工作流需要保持与源图像尺寸的关系而不是手动计算最终尺寸时，相对比例非常有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

相对比例会更改框的比例设置；它不会对嵌入的图像进行重采样或压缩。

## **嵌入和链接图像**

嵌入图片将图像数据存储在演示文稿内部，因此是可移植性和可预测渲染的最安全选择。链接图片通过 [Picture.setLinkPathLong](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picture/#setLinkPathLong) 方法存储外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减少 PPTX 中存储的图像数据量，但会引入外部依赖。链接的文件必须仍然对打开或渲染演示文稿的应用程序可访问。如果路径更改、文件被移动或资源不可用，链接图片可能无法按预期显示。对于必须通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

下面的示例创建一个图片框并将其指向本地图像文件。它仅处理图像链接；视频链接是单独的媒体工作流，特意未在此示例中混入。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在外部文件管理是有意的情况下使用链接。不要仅仅将它们作为压缩的替代方案：一个带有损坏图像依赖的小 PPTX 通常不如一个更大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿提取图像之前，检查形状实际上是 [PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/) 并且包含嵌入图像。链接的图片框可能不包含可以相同方式提取的图像字节。

### **提取光栅图像**

现代图像 API 直接处理光栅图像，无需旧的 Java 图像包装器。下面的示例在幻灯片上查找第一个嵌入的光栅图片并将其保存为 PNG：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

保存光栅图像会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的编码字节而不是转换后的光栅文件，请改用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 公开一个 [SvgImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/) 对象。这使您能够直接检索 SVG 数据，而不是先对图片进行光栅化。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

将 SVG 内容保留为 SVG 可在演示文稿中保留矢量源。PNG 或 JPEG 等光栅导出必然将该矢量内容渲染为像素。PDF 或 SVG 幻灯片导出同样是渲染操作，因此导出的图形不应视为原始嵌入 SVG 的逐字节副本；当需要原始矢量资源本身时，请使用嵌入的 [SvgImage.getSvgData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/#getSvgData) 数据。

## **裁剪图像**

裁剪会改变帧内可见的图像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/) 上的裁剪值是源图像尺寸的百分比。裁剪最初不会删除嵌入图像中隐藏的像素；它仅更改可见区域。

下面的示例安全地查找图片框并应用裁剪值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

由于隐藏的图像数据仍然存在，之后可以更改裁剪而不会丢失原始像素。如果文件大小比可逆性更重要，可以按照下一节所述物理删除裁剪区域。

## **移除裁剪的图像数据**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但这是一次破坏性优化：演示文稿保存后，已删除的像素将不再可用于后续的取消裁剪操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此方法可能会向演示文稿添加新的图像资源。如果原始图像也被其他图片框使用，则这些框仍需要其现有资源，因此删除裁剪区域不一定会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果光栅化为 PNG。

## **压缩光栅图像**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#compressImage) 将光栅图像分辨率相对于图片显示尺寸进行降低。它也可以在同一操作中删除裁剪区域。当图像被重新缩放或裁剪时，方法返回 `True`；当无需更改时返回 `False`。

当标准目标分辨率足够时，使用预定义的 [PicturesCompression](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturescompression/) 值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在需要特定目标时，可以传入自定义的正 DPI 值，而不是预定义值。

压缩旨在用于光栅图像。SVG 和元文件内容不会通过此光栅压缩工作流被降低。同样请记住，降低的分辨率和已删除的裁剪区域无法从优化后的演示文稿中恢复。应根据图像实际观看或导出的最大尺寸选择目标分辨率，而不是全局使用最低 DPI。

## **管理图像转换效果**

有关涵盖亮度、对比度、颜色转换、模糊、透明度效果、有序链、检查、移除以及往返验证的完整工作流，请参阅 [Image Transform Effects](/slides/zh/python-java/image-transform-effects/)。

## **锁定图片框几何形状**

[PictureFrameLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframelock/) 设置控制对图片框禁用哪些编辑操作。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) 在调整大小时保持形状的比例。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

锁定适用于图片框形状。它并不会强制对源图像进行重新采样或永久更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[PictureFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/) 上的 stretch-offset 值相对于图片框的边界框定义填充矩形。正百分比会从边缘产生内缩，负百分比会产生外延。

这不同于裁剪。裁剪值选择源图像的可见部分；stretch 偏移则更改可见图片填充被拉伸的矩形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

使用 stretch 偏移进行填充定位。当目标是隐藏源图像边缘时，使用裁剪属性。

## **存储、文件大小和导出注意事项**

当图像存储和图片框格式分开处理时，主要权衡更易于管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的，但大型光栅图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以保持包体更小，但演示文稿依赖于存储路径或位置的外部文件保持可用。
- **裁剪** 最初是非破坏性的。隐藏的像素保持嵌入，直至显式删除裁剪区域或在压缩期间移除。
- **压缩** 可以大幅减小超大型光栅图像的文件大小，但会牺牲源分辨率。应在确定幻灯片上实际显示尺寸后再应用。
- **SVG 图像** 在需要保留矢量时应保持为 SVG。需要矢量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能重用现有的 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 资源，而不是在演示工作流中反复加载同一文件。

对于大型演示文稿，图像优化通常在有选择地执行时最有效：将标志和图表保留为矢量内容，根据实际显示尺寸压缩照片，仅在不需要后续编辑时删除裁剪像素，除非依赖管理是部署设计的一部分，否则避免使用外部链接。

## **常见问题**

**图片框和图像资源之间有什么区别？**

[PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 表示与演示文稿关联的图像资源。[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/) 是幻灯片上的一种形状，用于显示图像并存储框级几何和格式，如大小、旋转、裁剪值、效果和锁定。

**我应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源访问的情况下渲染时，请嵌入图像。仅当有意将图像文件保存在 PPTX 之外且外部位置能够可靠维护时，才链接图像。

**裁剪会降低 PPTX 文件大小吗？**

单独不会。普通裁剪设置会隐藏源图像的部分，但保留底层像素。当可以永久丢弃这些像素时，请使用 [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 或带有裁剪区域删除的图像压缩。

**压缩后我能恢复图像质量吗？**

不能。压缩会降低存储的光栅分辨率，删除裁剪区域会丢弃图像数据。如果以后可能需要高分辨率编辑，请在演示文稿外保留原始源图像。

**SVG 图像应如何处理？**

当矢量保真度重要时，将 SVG 内容保持为 SVG。可以直接提取嵌入的 [SvgImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/)。将幻灯片渲染为 PNG 或 JPEG 等光栅格式时，SVG 会作为幻灯片图像的一部分被光栅化。

**读取现有幻灯片时如何避免不安全的强制转换？**

在使用图片框特定成员之前检查形状类型。对 [PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/) 进行 `isinstance` 检查可避免无效的强制转换，并让代码处理不包含图片框的幻灯片。