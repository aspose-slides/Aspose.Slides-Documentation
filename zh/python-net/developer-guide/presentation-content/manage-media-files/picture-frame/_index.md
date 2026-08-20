---
title: 在演示文稿中使用 Python 管理图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/python-net/picture-frame/
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
- Aspose.Slides
description: "通过 Aspose.Slides for Python via .NET 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是一种在幻灯片中显示图像的形状。在 Aspose.Slides 中，图像资源与显示它的形状是分开的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 通过其 [ImageCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 拥有嵌入的图像资源，而一个 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

当同一图像需要多次显示时，这种分离非常有用。将图像添加到演示文稿一次，保留返回的 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等光栅图像以及 SVG 等矢量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。选择会影响可移植性、文件大小、提取和导出行为，因此在应用格式或优化之前决定图像应如何存储是很有用的。

## **添加和格式化嵌入图像**

对于嵌入图像，向演示文稿添加图像数据并使用 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_picture_frame/) 创建图片框。图像成为演示文稿包的一部分，因此在移动到另一台计算机时演示文稿保持自包含。

以下示例添加 JPEG 图像，以图像的原始尺寸创建框，并应用线条格式和旋转：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

图片框控制显示的几何形状；更改框的大小不会改变嵌入图像资源中存储的原始像素尺寸。此区别在以后裁剪或压缩图像时变得重要。

## **使用相对比例**

[PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 为框公开 [relative_scale_width](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/relative_scale_width/) 和 [relative_scale_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/relative_scale_height/)。值 `1.0` 对应原始图片大小的 100%。相对比例在工作流需要保留与源图像尺寸的关系而不是手动计算最终尺寸时非常有用。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

相对比例更改框的比例设置；它不会重新采样或压缩嵌入的图像。

## **嵌入和链接图像**

嵌入图片将图像数据存储在演示文稿内部，因此是可移植性和可预测渲染的最安全选择。链接图片通过 [Picture](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picture/) 链接路径存储外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减少 PPTX 中存储的图像数据量，但会引入外部依赖。打开或渲染演示文稿的应用程序必须能够访问链接文件。如果路径更改、文件移动或资源不可用，链接图片可能无法按预期显示。对于必须通过电子邮件发送、存档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

以下示例创建图片框并指向本地图像文件。它仅处理图像链接；视频链接是单独的媒体工作流，特意未混入此示例。

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

在外部文件管理是有意为之时使用链接。不要仅将其用作压缩的替代方案：一个带有损坏图像依赖的轻量 PPTX 通常不如一个较大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿提取图像之前，检查形状实际上是否为 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)，并且它包含嵌入图像。链接图片框可能不包含可以以相同方式提取的图像字节。

### **提取光栅图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/)。以下示例在幻灯片上查找第一个嵌入的光栅图片并将其保存为 PNG：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

通过 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 保存会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的编码字节而不是转换后的光栅文件，请改用 [PPImage.binary_data](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/binary_data/) 属性。

### **提取 SVG 图像**

对于 SVG 图片，[PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 暴露 [SvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/) 对象。这使您能够直接检索 SVG 数据，而不是先将图片光栅化。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

将 SVG 内容保持为 SVG 可在演示文稿中保留矢量源。PNG 或 JPEG 等光栅导出必然将该矢量内容渲染为像素。PDF 或 SVG 幻灯片导出也是渲染操作，因此导出的图形不应被视为原始嵌入 SVG 的逐字复制；当需要原始矢量资源本身时，请使用嵌入的 [SvgImage.svg_data](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/svg_data/)。

## **裁剪图像**

裁剪更改在框内可见的图像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/) 上的裁剪值是源图像尺寸的百分比。裁剪最初并不会删除嵌入图像中的隐藏像素；它只改变可见区域。

以下示例安全地查找图片框并应用裁剪值：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

因为隐藏的图像数据仍然存在，裁剪可以在以后更改而不会丢失原始像素。如果文件大小比可逆性更重要，可以按照下一节所述物理删除裁剪区域。

## **移除裁剪的图像数据**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 移除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：演示文稿保存后，已删除的像素将不再可用于以后取消裁剪的操作。

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

此方法可能向演示文稿添加新的图像资源。如果原始图像也被其他图片框使用，则这些框仍需其现有资源，因此删除裁剪区域不一定会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果光栅化为 PNG。

## **压缩光栅图像**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/compress_image/) 根据图片显示的尺寸相对降低光栅图像分辨率。它也可以在同一次操作中移除裁剪区域。当图像被调整大小或裁剪时方法返回 `True`，当无需更改时返回 `False`。

当标准目标分辨率足够时，可使用预定义的 [PicturesCompression](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/picturescompression/) 值：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

如果需要特定目标，也可以传入自定义正 DPI 值，而不是枚举值。

压缩旨在针对光栅图像。SVG 和元文件内容不会通过此光栅压缩工作流减少。还要记住，较低分辨率和已删除的裁剪区域无法从优化后的演示文稿中恢复。应根据图像实际观看或导出的最大尺寸选择目标分辨率，而不是全局使用最低 DPI。

## **检查图像效果**

图片效果存储在框使用的图片上。图像变换集合可能包含固定 alpha 调制（用于透明度）和亮度（用于亮度和对比度）等效果。下面的示例安全地读取幻灯片上第一个图片框的这两种效果：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/alphamodulatefixed/) 和 [Luminance](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/luminance/) 改变图像在框内的渲染方式；它们不会重新写入原始嵌入的图像字节。

## **锁定图片框几何形状**

[PictureFrameLock](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframelock/) 设置控制哪些编辑操作对图片框被禁用。例如，[aspect_ratio_locked](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 属性在调整大小时保持形状的比例。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

锁定适用于图片框形状本身。它不会强制源图像重新采样或永久更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[PictureFillFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定义相对于图片框边界框的填充矩形。正的百分比从边缘向内收缩，负的百分比则向外伸展。

这不同于裁剪。裁剪值选择源图像的可见部分；stretch offset 改变可见图片填充被拉伸进入的矩形。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

使用 stretch offset 来放置填充。想要隐藏源图像边缘时使用裁剪属性。

## **存储、文件大小和导出考虑因素**

当图像存储和图片框格式分开处理时，主要权衡更易管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的方式，但大型光栅图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以让包更小，但演示文稿依赖于外部文件在存储路径或位置保持可用。
- **裁剪** 最初是非破坏性的。隐藏的像素会一直嵌入，直到显式删除裁剪区域或在压缩期间移除。
- **压缩** 可以显著减小过大的光栅图像文件大小，但会牺牲源分辨率。应在确定幻灯片实际显示尺寸后再应用。
- **SVG 图像** 在需要保留矢量时应保持为 SVG。当需要矢量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能复用已有的 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 资源，而不是在工作流中重复加载相同文件。

对于大型演示文稿，图像优化通常在有选择地执行时最有效：将标志和图表保留为矢量内容，根据实际显示尺寸压缩照片，仅在不需要后期编辑时删除裁剪像素，除非部署设计中包含依赖管理，否则避免使用外部链接。

## **常见问题**

**图片框和图像资源有什么区别？**

[PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 表示与演示文稿关联的图像资源。[PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 是幻灯片上的一个形状，用于显示图像并存储框级几何和格式信息，如大小、旋转、裁剪值、效果和锁定。

**我应该嵌入还是链接图像？**

当演示文稿必须可移植、存档或在没有外部资源的情况下渲染时，请嵌入图像。只有在有意将图像文件保留在 PPTX 之外且能够可靠维护外部位置时才链接图像。

**裁剪会减小 PPTX 文件大小吗？**

单独的裁剪不会。普通裁剪设置会隐藏源图像的部分，但仍保留底层像素。使用 [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 或带有裁剪区域删除的图像压缩时，才能永久去除这些像素。

**压缩后能恢复图像质量吗？**

不能。压缩会降低存储的光栅分辨率，删除裁剪区域会丢弃图像数据。如果以后可能需要高分辨率编辑，请在演示文稿外保留原始源图像。

**应该如何处理 SVG 图像？**

当矢量保真度重要时保持 SVG 内容为 SVG。嵌入的 [SvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/) 可以直接提取。将幻灯片渲染为 PNG 或 JPEG 等光栅格式会将 SVG 光栅化为幻灯片图像的一部分。

**读取已有幻灯片时如何避免不安全的类型转换？**

在使用图片框特定成员之前检查形状类型。使用 `isinstance(shape, slides.PictureFrame)` 可以避免无效的类型转换，并让代码能够处理不包含图片框的幻灯片。