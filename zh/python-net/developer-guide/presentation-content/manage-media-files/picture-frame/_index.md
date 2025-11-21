---
title: 使用 Python 向演示文稿添加图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/python-net/picture-frame/
keywords:
- 图片框
- 添加图片框
- 创建图片框
- 添加图像
- 创建图像
- 提取图像
- 光栅图像
- 矢量图像
- 裁剪图像
- 裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对缩放
- 图像效果
- 宽高比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 向 PowerPoint 和 OpenDocument 演示文稿添加图片框。简化工作流程并提升幻灯片设计。"
---

## **概述**

Aspose.Slides for Python 中的图片框允许您将光栅图像和矢量图像放置并管理为原生幻灯片形状。您可以从文件或流插入图片，使用精确坐标定位和调整大小，应用旋转，设置透明度，并在其他形状旁控制 Z 顺序。API 还支持裁剪、保持宽高比、设置边框和效果，以及在不重新构建布局的情况下替换底层图像。由于图片框的行为类似普通形状，您可以添加动画、超链接和替代文本，从而轻松构建视觉丰富且可访问的演示文稿。

## **创建图片框**

本节展示如何通过创建一个 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 将图像插入幻灯片。您将学习如何加载图像、将其精确放置在幻灯片上，以及如何控制其大小和格式。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 根据索引获取幻灯片。  
3. 通过将图像添加到演示文稿的 [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 来创建 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)。该图像将用于填充形状。  
4. 指定框的宽度和高度。  
5. 使用 [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法创建相同尺寸的 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。  
6. 将演示文稿另存为 PPTX 文件。

以下 Python 代码展示了如何创建图片框：
```py
import aspose.slides as slides

# 实例化 Presentation 类来表示 PPTX 文件。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 将图像添加到演示文稿。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 添加一个与图像大小相同的图片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 将演示文稿保存为 PPTX。
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" %}}

图片框让您可以快速从图像创建演示幻灯片。将图片框与 Aspose.Slides 保存选项结合使用时，您可以控制 I/O 操作，将图像从一种格式转换为另一种格式。您可能需要查看以下页面：转换 [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)；转换 [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)；转换 [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)；转换 [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)；转换 [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)；转换 [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

## **使用相对比例创建图片框**

本节演示如何先以固定尺寸放置图像，然后对宽度和高度分别以百分比方式进行缩放。由于百分比可能不同，宽高比会随之变化。缩放是相对于图像的原始尺寸进行的。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 根据索引获取幻灯片。  
3. 通过将图像添加到演示文稿的 [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 来创建 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)。  
4. 向幻灯片添加一个 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。  
5. 设置图片框的相对宽度和高度。  
6. 将演示文稿另存为 PPTX 文件。

以下 Python 代码展示了如何创建具有相对缩放的图片框：
```py
import aspose.slides as slides

# 实例化 Presentation 类以表示 PPTX 文件。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 将图像添加到演示文稿的图像集合。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 向幻灯片添加图片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 设置相对缩放宽度和高度。
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # 保存演示文稿。
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```


## **从图片框提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 对象中提取光栅图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示了如何从文档 “sample.pptx” 中提取图像并以 PNG 格式保存。
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```


## **从图片框提取 SVG 图像**

当演示文稿在 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 形状中包含 SVG 图形时，Aspose.Slides for Python via .NET 可以完整保留原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)，检查其底层的 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 是否包含 SVG 内容，然后将该图像以原生 SVG 格式保存到磁盘或流中。

以下代码示例演示了如何从图片框中提取 SVG 图像：
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```


## **获取图像透明度**

Aspose.Slides 允许您获取应用于图像的透明度效果。下面的 Python 代码演示了该操作：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```


{{% alert color="primary" %}}
所有应用于图像的效果均可在 [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/) 中找到。
{{% /alert %}}

## **图片框格式化**

Aspose.Slides 提供了多种格式化选项，您可以将其应用于图片框，以满足特定需求。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 根据索引获取幻灯片。  
3. 通过将图像添加到演示文稿的 [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 来创建 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)。该图像将用于填充形状。  
4. 指定框的宽度和高度。  
5. 使用幻灯片的 [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法创建相同尺寸的 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。  
6. 设置图片框的线条颜色。  
7. 设置图片框的线条宽度。  
8. 通过提供正值（顺时针）或负值（逆时针）来旋转图片框。  
9. 将修改后的演示文稿另存为 PPTX 文件。

以下 Python 代码演示了图片框格式化过程：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation 类以表示 PPTX 文件。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 将图像添加到演示文稿的图像集合。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 添加与图像大小相同的图片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 对图片框应用格式化。
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # 将演示文稿保存为 PPTX。
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Tip" color="primary" %}}

Aspose 开发了免费 [Collage Maker](https://products.aspose.app/slides/collage)。如果需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或 [创建照片网格](https://products.aspose.app/slides/collage/photo-grid)，您可以使用该服务。
{{% /alert %}}

## **将图像作为链接添加**

为保持演示文稿文件体积小，您可以通过链接的方式添加图像或视频，而不是将文件直接嵌入演示文稿。以下 Python 代码展示了如何在占位符中插入图像和视频：
```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **裁剪图像**

本节您将学习如何在图片框内裁剪图像的可见区域，而不修改源文件。您还将了解如何使用裁剪边距在幻灯片上创建干净、聚焦的构图。

以下 Python 代码展示了如何在幻灯片上裁剪图像：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 将图像添加到演示文稿的图像集合。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 将图片框添加到幻灯片。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # 裁剪图像（百分比值）。
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # 保存结果。
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```


## **删除图像的裁剪区域**

如果想删除框中图像的裁剪区域，请使用 [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法。该方法返回裁剪后的图像，若未进行裁剪则返回原始图像。

以下 Python 代码演示了该操作：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 从第一张幻灯片获取 PictureFrame。
    picture_frame = slides.shape[0]

    # 从第一张幻灯片获取 PictureFrame。
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 保存结果。
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}

[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理后的 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 中使用，这可以减小演示文稿体积；否则，生成的演示文稿中的图像数量可能会增加。

在裁剪过程中，该方法会将 WMF/EMF 元文件转换为光栅 PNG 图像。
{{% /alert %}}

## **锁定宽高比**

如果希望包含图像的形状在更改图像尺寸后仍保持宽高比，请将 [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 属性设为 `True`。

以下 Python 代码展示了如何锁定形状的宽高比：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # 在调整大小时锁定宽高比。
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}

此 *Lock Aspect Ratio* 设置仅保持形状本身的宽高比，而不影响内部图像的宽高比。
{{% /alert %}}

## **使用 Stretch Offset 属性**

通过 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 类的 `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right` 和 `stretch_offset_bottom` 属性，您可以定义填充矩形。

当为图像指定拉伸时，源矩形会按比例缩放以适应填充矩形。填充矩形的每一边由相对于形状边界框对应边的百分比偏移定义。正百分比表示内缩，负百分比表示外扩。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 根据索引获取幻灯片引用。  
3. 添加一个矩形 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 设置形状的填充类型。  
5. 设置形状的图片填充模式。  
6. 加载图像。  
7. 将图像分配为填充形状。  
8. 指定图像相对于形状边界框各边的偏移。  
9. 将演示文稿另存为 PPTX 文件。

以下 Python 代码演示了如何使用 Stretch Offset 属性：
```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加矩形 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # 设置形状的填充类型。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 设置形状的图片填充模式。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 加载图像并将其添加到演示文稿。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # 将图像分配给形状以填充。
    shape.fill_format.picture_fill_format.picture.image = image

    # 指定图像相对于形状边界框各边的偏移量。
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # 将 PPTX 文件保存到磁盘。
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert  title="Tip" color="primary" %}}

Aspose 提供免费转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——帮助您快速从图像创建演示文稿。
{{% /alert %}}

## **FAQ**

**如何查看 PictureFrame 支持的图像格式？**

Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 的图像对象，支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的能力相吻合。

**大量大型图像会对 PPTX 大小和性能产生什么影响？**

嵌入大型图像会增加文件大小和内存占用；链接图像可保持演示文稿体积较小，但需要外部文件保持可访问。Aspose.Slides 提供通过链接添加图像的功能，以减小文件大小。

**如何防止图像对象被意外移动/调整大小？**

对 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/)（例如禁用移动或调整大小）。锁定机制在单独的 [protection article](/slides/zh/python-net/applying-protection-to-presentation/) 中有说明，适用于包括 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 在内的多种形状类型。

**导出演示文稿为 PDF/图像时，SVG 矢量保真度是否得到保留？**

Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 中提取原始矢量 SVG。使用 [exporting to PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/) 或 [raster formats](/slides/zh/python-net/convert-powerpoint-to-png/) 时，结果可能会根据导出设置被光栅化；提取行为证明原始 SVG 仍以矢量形式存储。