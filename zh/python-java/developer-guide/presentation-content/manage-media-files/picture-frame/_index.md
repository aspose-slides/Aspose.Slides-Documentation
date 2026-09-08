---
title: 使用 Python 管理演示文稿中的图片框
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
- 相对缩放
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

图片框是用于显示图像的幻灯片形状。在 Aspose.Slides 中，图像资源与显示图像的形状是分离的对象：一个[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)通过其[ImageCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imagecollection/)拥有嵌入的图像资源，而[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/)则控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

这种分离在同一图像需要显示多次时非常有用。将图像一次添加到演示文稿中，保留返回的[PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等光栅图像以及 SVG 向量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。存储方式会影响可移植性、文件大小、提取和导出行为，因此在进行格式化或优化之前，最好先决定图像应如何存储。

## **添加并格式化嵌入图像**

对于嵌入图像，先将图像数据添加到演示文稿，然后使用[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addPictureFrame)创建图片框。图像会成为演示文稿包的一部分，因此在将演示文稿移动到另一台计算机时仍然是自包含的。

下面的示例添加了一张 JPEG 图像，在图像的原始尺寸下创建框，并应用线条格式和旋转：

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

图片框控制显示的几何形状；更改框的尺寸不会改变嵌入图像资源中存储的原始像素尺寸。当以后进行裁剪或压缩时，这一区别非常重要。

## **使用相对缩放**

[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/)通过[setRelativeScaleWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth)和[setRelativeScaleHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight)公开框的相对宽高缩放。值为 `1.0` 表示原始图片大小的 100%。当工作流需要保留与源图像大小的比例关系而不是手动计算最终尺寸时，相对缩放非常有用。

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

相对缩放仅更改框的缩放设置；它不会重新采样或压缩嵌入的图像。

## **嵌入和链接图像**

嵌入图片将图像数据存储在演示文稿内部，是可移植性和可预测渲染最安全的选择。链接图片则通过[Picture.setLinkPathLong](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picture/#setLinkPathLong)方法存储外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减少 PPTX 中存储的图像数据量，但会引入外部依赖。链接文件必须对打开或渲染演示文稿的应用程序保持可访问。如果路径更改、文件移动或资源不可用，链接图片可能无法按预期显示。对于需要通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

下面的示例创建一个图片框并指向本地图像文件。它仅演示图像链接；视频链接是另一个媒体工作流，故在此示例中未混入。

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

当外部文件管理是有意为之时使用链接。不要仅将其作为压缩的替代方案：一个带有破损图像依赖的“小” PPTX 往往不如一个较大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿中提取图像之前，需检查形状是否真的为[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/)，且是否包含嵌入图像。链接图片框可能不包含可直接提取的图像字节。

### **提取光栅图像**

现代图像 API 直接处理光栅图像，无需使用旧的 Java 图像包装器。下面的示例在幻灯片上查找第一个嵌入的光栅图片并将其保存为 PNG：

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

保存光栅图像会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的编码字节而不是已转换的光栅文件，请使用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/)暴露了一个[SvgImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/)对象。这样可以直接检索 SVG 数据，而无需先光栅化图片。

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

将 SVG 内容保持为 SVG 能够在演示文稿中保留向量源。PNG 或 JPEG 等光栅导出必然将该向量内容渲染为像素。PDF 或 SVG 幻灯片导出也是渲染操作，因此导出的图形不应被视为原始嵌入 SVG 的逐字拷贝；在需要原始向量资源时请使用嵌入的[SvgImage.getSvgData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/#getSvgData)数据。

## **裁剪图像**

裁剪更改在框内可见的图像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/)上的裁剪值是相对于源图像尺寸的百分比。裁剪最初并不会删除嵌入图像中被隐藏的像素；它只改变可见区域。

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

由于隐藏的图像数据仍然存在，之后可以更改裁剪而不会丢失原始像素。如果文件大小比可逆性更重要，可以按下一节所述物理删除裁剪区域。

## **删除裁剪的图像数据**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas)会删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：演示文稿保存后，被删除的像素将不再可用于以后取消裁剪的操作。

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

此方法可能会向演示文稿添加新的图像资源。如果原始图像还被其他图片框使用，这些框仍需要其现有资源，因此删除裁剪区域不一定会减少图像总数。使用此方法对 WMF 或 EMF 内容进行裁剪会将裁剪结果栅格化为 PNG。

## **压缩光栅图像**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#compressImage)会根据图片实际显示的尺寸降低光栅图像分辨率。它也可以在同一操作中删除裁剪区域。当图像被重新调整大小或裁剪时方法返回 `True`，如果无需更改则返回 `False`。

当标准目标分辨率足够时，可使用预定义的[PicturesCompression](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturescompression/)值：

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

如果需要特定目标，也可以传入自定义的正 DPI 值。

压缩仅面向光栅图像。SVG 和元文件内容不会通过此光栅压缩工作流被减小。同样要记住，分辨率降低和已删除的裁剪区域无法从已优化的演示文稿中恢复。应根据图像实际观看或导出的最大尺寸来选择目标分辨率，而不是全局使用最低 DPI。

## **管理图像变换效果**

有关亮度、对比度、颜色变换、模糊、透明度效果、有序链、检查、移除以及往返验证的完整工作流，请参阅[Image Transform Effects](/slides/zh/python-java/image-transform-effects/)。

## **锁定图片框几何形状**

[PictureFrameLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframelock/)设置控制哪些编辑操作对图片框被禁用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked)在调整大小时保持形状比例。

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

锁定作用于图片框形状本身。它不会强制源图像重新采样或永久更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[PictureFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/)上的 stretch‑offset 值定义相对于图片框边界框的填充矩形。正百分比会从边缘向内缩进，负百分比会向外延伸。

这与裁剪不同。裁剪值决定源图像的哪一部分可见；stretch offset 改变可见图片填充被拉伸的矩形区域。

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

使用 stretch offset 来放置填充。需要隐藏源图像边缘时使用裁剪属性。

## **存储、文件大小和导出考虑因素**

当图像存储和图片框格式分开处理时，主要权衡更易管理：

- **嵌入图像**使演示文稿自包含，是共享和服务器端渲染最可靠的方式，但大的光栅图像会增加 PPTX 大小和内存消耗。
- **链接图像**可以保持包体更小，但演示文稿依赖外部文件在存储路径或位置保持可用。
- **裁剪**最初是非破坏性的。隐藏的像素会一直嵌入，直到显式删除裁剪区域或在压缩时移除。
- **压缩**可以在图像实际显示尺寸已知后显著减小文件大小，但会牺牲源分辨率。应在确定幻灯片上最终尺寸后再进行。
- **SVG 图像**在需要保留向量时应保持为 SVG。需要向量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像**应在可能的情况下复用已存在的[PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/)资源，而不是在工作流中重复加载同一文件。

对于大型演示文稿，图像优化通常在有选择地进行时最有效：将标志和图表保持为向量内容，根据实际显示尺寸压缩照片，仅在不需要后期编辑时删除裁剪像素，除非部署设计中包含依赖管理，否则避免使用外部链接。

## **常见问题解答**

**图片框和图像资源之间有什么区别？**

[PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/)代表与演示文稿关联的图像资源。[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/)是幻灯片上的一种形状，用于显示图像并存储框级几何和格式信息，如大小、旋转、裁剪值、效果和锁定。

**应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源的情况下渲染时，嵌入图像。仅在有意将图像文件置于 PPTX 之外且能够可靠维护外部位置时才使用链接图像。

**裁剪会减小 PPTX 文件大小吗？**

不会。普通裁剪仅隐藏源图像的部分，但保留底层像素。需使用[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas)或在压缩时删除裁剪区域来永久去除这些像素。

**压缩后可以恢复图像质量吗？**

不能。压缩会降低存储的光栅分辨率，删除裁剪区域会丢弃图像数据。如果以后可能需要高分辨率编辑，请在演示文稿外保留原始源图像。

**SVG 图像应如何处理？**

在向量保真度重要时保持 SVG 为 SVG。嵌入的[SvgImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/)可以直接提取。将幻灯片渲染为 PNG 或 JPEG 等光栅格式会将 SVG 栅格化为幻灯片图像。

**读取现有幻灯片时如何避免不安全的强制转换？**

在使用图片框特定成员之前，先检查形状类型。对[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/)进行`isinstance`检查可避免无效强制转换，并让代码能够处理不包含图片框的幻灯片。