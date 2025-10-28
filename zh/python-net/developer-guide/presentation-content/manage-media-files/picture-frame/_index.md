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
- 栅格图像
- 矢量图像
- 裁剪图像
- 已裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对比例
- 图像效果
- 长宽比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 为 PowerPoint 和 OpenDocument 演示文稿添加图片框。简化工作流并提升幻灯片设计。"
---

## **概述**

Aspose.Slides for Python 中的图片框允许您将栅格和矢量图像放置为原生幻灯片形状并进行管理。您可以从文件或流插入图片，使用精确坐标定位和调整大小，应用旋转、设置透明度，并在其他形状旁控制 Z 顺序。API 还支持裁剪、保持长宽比、设置边框和效果，以及在不重新构建布局的情况下替换底层图像。由于图片框的行为与普通形状相同，您可以添加动画、超链接和替代文本，从而轻松构建视觉丰富且可访问的演示文稿。

## **创建图片框**

本节展示如何通过 Aspose.Slides for Python 创建一个 [图片框](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 并将图像插入幻灯片。您将学习如何加载图像、在幻灯片上精确放置以及控制其大小和格式。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片。  
3. 通过向演示文稿的 [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 添加图像来创建一个 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)。该图像将用于填充形状。  
4. 指定框架的宽度和高度。  
5. 使用 [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法创建相应大小的 [图片框](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。  
6. 将演示文稿保存为 PPTX 文件。

下面的 Python 代码演示如何创建图片框：

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Save the presentation as PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

图片框让您能够快速从图像创建演示文稿幻灯片。将图片框与 Aspose.Slides 保存选项结合使用时，您可以控制 I/O 操作，以实现图像格式之间的转换。您可能需要查看以下页面：将 [图像转换为 JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)；将 [JPG 转换为图像](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)；将 [JPG 转换为 PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)；将 [PNG 转换为 JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)；将 [PNG 转换为 SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)；将 [SVG 转换为 PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。  

{{% /alert %}}

## **使用相对比例创建图片框**

本节演示如何以固定尺寸放置图像，然后对宽度和高度分别应用基于百分比的缩放。由于两个百分比可能不同，长宽比会随之变化。缩放是相对于图像原始尺寸进行的。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片。  
3. 通过向演示文稿的 [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 添加图像来创建一个 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)。  
4. 向幻灯片添加一个 [图片框](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。  
5. 设置图片框的相对宽度和高度。  
6. 将演示文稿保存为 PPTX 文件。

下面的 Python 代码演示如何使用相对比例创建图片框：

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame to the slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Set the relative scale width and height.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Save the presentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **从图片框提取栅格图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 对象中提取栅格图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示如何从文档 “sample.pptx” 中提取图像并保存为 PNG 格式。

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

当演示文稿包含放置在 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 形状中的 SVG 图形时，Aspose.Slides for Python via .NET 允许您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)，检查其底层的 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 是否包含 SVG 内容，然后将该图像以原始 SVG 格式保存到磁盘或流中。

以下代码示例演示如何从图片框中提取 SVG 图像：

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

Aspose.Slides 允许您检索应用于图像的透明度效果。下面的 Python 代码演示此操作：

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

Aspose.Slides 提供了多种格式化选项，您可以将其应用于图片框。通过这些选项，您可以调整图片框以满足特定需求。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片。  
3. 通过向演示文稿的 [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 添加图像来创建一个 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)。该图像将用于填充形状。  
4. 指定框架的宽度和高度。  
5. 使用幻灯片的 [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法创建相同大小的 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。  
6. 设置图片框的线条颜色。  
7. 设置图片框的线宽。  
8. 通过提供正（顺时针）或负（逆时针）值来旋转图片框。  
9. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码演示图片框的格式化过程：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Apply formatting to the picture frame.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Save the presentation as PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="提示" color="primary" %}}
Aspose 已推出免费 [Collage Maker](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或 [创建照片网格](https://products.aspose.app/slides/collage/photo-grid)，可以使用此服务。  
{{% /alert %}}

## **将图像添加为链接**

为了保持演示文稿文件体积小，您可以通过链接而非嵌入的方式添加图像或视频。下面的 Python 代码展示如何在占位符中插入图像和视频：

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

本节中，您将学习如何在不更改源文件的情况下裁剪图片框中图像的可见区域。还将了解如何使用裁剪边距在幻灯片上创建整洁、聚焦的构图。

下面的 Python 代码展示如何在幻灯片上裁剪图像：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Add a picture frame to the slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Crop the image (percentage values).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Save the result.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **删除已裁剪的图像区域**

如果您想删除框架中图像已裁剪的区域，请使用 [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法。该方法返回裁剪后的图像，如果不需要裁剪则返回原始图像。

下面的 Python 代码演示此操作：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get the PictureFrame from the first slide.
    picture_frame = slides.shape[0]

    # Get the PictureFrame from the first slide.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Save the result.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}}
[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理的 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 中使用，这可以减小演示文稿体积；否则，生成的演示文稿中图像数量可能会增加。

在裁剪过程中，此方法会将 WMF/EMF 元文件转换为栅格 PNG 图像。  
{{% /alert %}}

## **锁定长宽比**

如果您希望包含图像的形状在更改图像尺寸后仍保持长宽比，请将 [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 属性设为 `True`。

下面的 Python 代码演示如何锁定形状的长宽比：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Lock the aspect ratio when resizing.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}}
此 *锁定长宽比* 设置仅保留形状的长宽比，而不影响其中图像的长宽比。  
{{% /alert %}}

## **使用 Stretch Offset 属性**

使用 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 类的 `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right` 和 `stretch_offset_bottom` 属性，您可以定义填充矩形。

当为图像指定拉伸时，源矩形会被缩放以适应填充矩形。填充矩形的每条边由相对于形状边界框相应边的百分比偏移量定义。正百分比表示内缩，负百分比表示外伸。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片引用。  
3. 添加一个矩形 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 设置形状的填充类型。  
5. 设置形状的图片填充模式。  
6. 加载图像。  
7. 将图像分配给形状填充。  
8. 指定图像相对于形状边界框相应边的偏移量。  
9. 将演示文稿保存为 PPTX 文件。

下面的 Python 代码演示如何使用 Stretch Offset 属性：

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a rectangle AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Set the shape's fill type.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Set the shape's picture fill mode.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image and add it to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assign the image to fill the shape.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specify image offsets from the corresponding edges of the shape's bounding box.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Save the PPTX file to disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="提示" color="primary" %}}
Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——可帮助您快速从图像创建演示文稿。  
{{% /alert %}}

## **常见问题**

**如何查询图片框支持的图像格式？**  
Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 的图像对象，支持栅格图像（PNG、JPEG、BMP、GIF 等）和矢量图像（如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的能力重叠。

**在 PPTX 中添加大量大图像会对文件大小和性能产生怎样的影响？**  
嵌入大图像会增加文件大小和内存使用；通过链接图像可以保持演示文稿体积较小，但需要保证外部文件仍可访问。Aspose.Slides 提供通过链接方式添加图像的功能，以减小文件大小。

**如何防止图像对象被意外移动或缩放？**  
对 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/)（例如禁用移动或缩放）。锁定机制在单独的 [保护文章](/slides/zh/python-net/applying-protection-to-presentation/) 中有介绍，支持包括 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 在内的多种形状类型。

**在导出演示文稿为 PDF/图像时，SVG 矢量保真度是否得到保留？**  
Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 中提取原始 SVG 矢量。当 [导出为 PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/) 或 [栅格格式](/slides/zh/python-net/convert-powerpoint-to-png/) 时，结果可能会根据导出设置被栅格化；但原始 SVG 仍然以矢量形式存在，可通过提取行为进行验证。