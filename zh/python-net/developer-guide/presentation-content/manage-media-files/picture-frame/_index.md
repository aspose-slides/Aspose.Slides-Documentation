---
title: 使用 Python 管理演示文稿中的图片框
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
- 栅格图像
- SVG 图像
- 裁剪图像
- 删除已裁剪区域
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是显示图像的幻灯片形状。在 Aspose.Slides 中，图像资源和显示图像的形状是分离的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 通过其 [ImageCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 拥有嵌入的图像资源，而一个 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

此分离在同一图像需要多次显示时非常有用。将图像一次添加到演示文稿中，保留返回的 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等栅格图像以及 SVG 矢量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。选择会影响可移植性、文件大小、提取和导出行为，因此在进行格式化或优化之前，确定图像的存储方式是有意义的。

## **添加和格式化嵌入图像**

对于嵌入图像，向演示文稿添加图像数据并使用 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_picture_frame/) 创建图片框。图像会成为演示文稿包的一部分，因此将演示文稿移动到另一台计算机时仍保持自包含。

以下示例添加 JPEG 图像，按图像的原始尺寸创建框，并应用线条格式和旋转：

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

图片框控制显示的几何形状；更改框的大小不会更改嵌入图像资源中存储的原始像素尺寸。当以后对图像进行裁剪或压缩时，这一点尤为重要。

## **使用相对缩放**

[PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 为框公开了 [relative_scale_width](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/relative_scale_width/) 和 [relative_scale_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/relative_scale_height/)。值为 `1.0` 对应原始图片尺寸的 100%。相对缩放在工作流需要保持与源图像尺寸的关系而不是手动计算最终尺寸时非常有用。

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

相对缩放更改框的缩放设置；它不会重新采样或压缩嵌入的图像。

## **嵌入图像和链接图像**

嵌入图片将图像数据存储在演示文稿内部，因此是可移植性和可预测渲染最安全的选择。链接图片则通过 [Picture](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picture/) 链接路径存储外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减少 PPTX 中存储的图像数据量，但会引入外部依赖。链接的文件必须保持可访问，以供打开或渲染演示文稿的应用程序使用。如果路径更改、文件移动或资源不可用，链接图片可能无法如预期显示。对于需要通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

以下示例创建图片框并指向本地图像文件。它仅处理图像链接；视频链接是单独的媒体工作流，故此示例未混入。

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

在有意进行外部文件管理时使用链接。不要仅将其作为压缩的替代方案：一个带有损坏图像依赖的“小” PPTX 通常不如一个较大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿中提取图像之前，检查形状是否实际上是 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 且是否包含嵌入图像。链接图片框可能不包含可通过相同方式提取的图像字节。

### **提取栅格图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/)。以下示例在幻灯片上找到第一个嵌入的栅格图片并将其保存为 PNG：

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

通过 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 保存会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的已编码字节而不是已转换的栅格文件，请改用 [PPImage.binary_data](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/binary_data/) 属性。

### **提取 SVG 图像**

对于 SVG 图片，[PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 暴露了一个 [SvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/) 对象。这使您可以直接检索 SVG 数据，而无需先对图片进行光栅化。

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

将 SVG 内容保持为 SVG 能在演示文稿中保留向量来源。PNG 或 JPEG 等栅格导出必然将该向量内容渲染为像素。PDF 或 SVG 幻灯片导出也是一次渲染操作，因此导出的图形不应视为原始嵌入 SVG 的逐字复制；在需要原始向量资源本身时，请使用嵌入的 [SvgImage.svg_data](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/svg_data/)。

## **裁剪图像**

裁剪会更改在框内部可见的图像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/) 上的裁剪值是源图像尺寸的百分比。裁剪最初不会删除嵌入图像中的隐藏像素；它只更改可见区域。

以下示例安全地找到图片框并应用裁剪值：

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

因为隐藏的图像数据仍然存在，随后可以更改裁剪而不会失去原始像素。如果文件大小比可逆性更重要，可以如下一节所述物理删除裁剪区域。

## **删除裁剪的图像数据**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：保存演示文稿后，被删除的像素将不再可用于后续的 “取消裁剪” 操作。

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

该方法可能会向演示文稿添加新的图像资源。如果原始图像也被其他图片框使用，这些框仍需其现有资源，因此删除裁剪区域未必会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果光栅化为 PNG。

## **压缩栅格图像**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/compress_image/) 根据图片显示的尺寸相对降低栅格图像分辨率。它还可以在同一操作中删除裁剪区域。当图像被重新尺寸化或裁剪时方法返回 `True`，未发生更改时返回 `False`。

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

需要特定目标时，也可以传入自定义的正 DPI 值而不是枚举值。

压缩仅针对栅格图像。SVG 和图元文件内容不会通过此栅格压缩工作流减少。同样需要记住，较低的分辨率和已删除的裁剪区域无法从优化后的演示文稿中恢复。应根据图像实际观看或导出的最大尺寸来选择目标分辨率，而不是全局使用最低 DPI。

## **管理图像变换效果**

有关覆盖亮度、对比度、颜色变换、模糊、透明度效果、有序链、检查、移除以及往返验证的完整工作流，请参阅 [Image Transform Effects](/slides/zh/python-net/image-transform-effects/)。

## **锁定图片框几何形状**

[PictureFrameLock](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframelock/) 设置控制对图片框禁用的编辑操作。例如，[aspect_ratio_locked](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 属性在调整大小时保持形状的比例。

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

锁定适用于图片框形状本身。它不会强制对源图像进行重新采样或永久更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[PictureFillFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定义相对于图片框边界框的填充矩形。正百分比在边缘形成内嵌，负百分比则形成外延。

这不同于裁剪。裁剪值选择源图像的可见部分；stretch offset 则改变可见图片填充被拉伸的矩形。

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

使用 stretch offset 来定位填充。需要隐藏源图像边缘时使用裁剪属性。

## **存储、文件大小和导出考虑因素**

在将图像存储和图片框格式分开处理时，主要权衡更易管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的选择，但大型栅格图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以保持包更小，但演示文稿依赖于外部文件在存储路径或位置上保持可用。
- **裁剪** 初始为非破坏性。隐藏的像素仍嵌入，直至显式删除裁剪区域或在压缩时移除。
- **压缩** 可以在图像实际显示尺寸已知后显著减小文件大小，但会牺牲源分辨率。应在确定幻灯片上的最终尺寸后再执行。
- **SVG 图像** 在需要保留向量时应保持为 SVG。需要向量资源本身时直接提取嵌入的 SVG。栅格幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能复用已有的 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 资源，而不是在演示文稿工作流中反复加载同一文件。

对于大型演示文稿，图像优化通常在选择性执行时最有效：将徽标和图表保留为向量内容，根据实际显示尺寸压缩照片，仅在不再需要后期编辑时删除裁剪像素，并且除非依赖管理是部署设计的一部分，否则避免使用外部链接。

## **常见问题**

**图片框和图像资源有什么区别？**

[PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 表示与演示文稿关联的图像资源。[PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 是幻灯片上的形状，用于显示图像并存储框级几何和格式，如大小、旋转、裁剪值、效果和锁定。

**应当嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源的情况下渲染时嵌入图像。仅在有意将图像文件置于 PPTX 外部且能够可靠维护外部位置时才链接图像。

**裁剪会减小 PPTX 文件大小吗？**

单独裁剪不会。普通裁剪设置隐藏源图像的部分，但仍保留底层像素。使用 [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 或在压缩时删除裁剪区域才能永久丢弃这些像素。

**压缩后能恢复图像质量吗？**

不能。压缩会降低存储的栅格分辨率，删除裁剪区域会丢弃图像数据。如果日后需要高分辨率编辑，请在演示文稿外保留原始源图像。

**应如何处理 SVG 图像？**

在向量保真度重要时保持 SVG 内容为 SVG。嵌入的 [SvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/) 可直接提取。当将幻灯片渲染为 PNG 或 JPEG 等栅格格式时，SVG 会被光栅化为幻灯片图像。

**读取现有幻灯片时如何避免不安全的强制转换？**

在使用图片框特定成员之前检查形状类型。使用 `isinstance(shape, slides.PictureFrame)` 可以避免无效的强制转换，并让代码能够处理不包含图片框的幻灯片。