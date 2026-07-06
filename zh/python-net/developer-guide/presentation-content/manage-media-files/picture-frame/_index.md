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
description: "使用 Aspose.Slides for Python via .NET 将图片框添加到 PowerPoint 和 OpenDocument 演示文稿。简化工作流并增强幻灯片设计。"
---
## **介绍**

在 Aspose.Slides for Python 中，图片框允许您将光栅图像和矢量图像放置并管理为本机幻灯片形状。您可以从文件或流插入图片，使用精确坐标定位和调整大小，应用旋转、设置透明度，并在其他形状旁控制 Z 顺序。API 还支持裁剪、保持宽高比、设置边框和效果，以及在不重新构建布局的情况下替换底层图像。由于图片框的行为类似普通形状，您可以添加动画、超链接和替代文本，从而轻松构建视觉丰富且可访问的演示文稿。

## **创建图片框**

本节展示如何通过创建一个 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 在 Aspose.Slides for Python 中向幻灯片插入图像。您将学习如何加载图像、精确放置在幻灯片上，以及控制其大小和格式。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片。  
3. 通过将图像添加到演示文稿的 [ImageCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 来创建 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)。该图像将用于填充形状。  
4. 指定框的宽度和高度。  
5. 使用 [add_picture_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法创建相同尺寸的 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)。  
6. 将演示文稿保存为 PPTX 文件。

以下 Python 代码展示如何创建图片框：

```py
import aspose.slides as slides

# 实例化 Presentation 类以表示 PPTX 文件。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 将图像添加到演示文稿。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 添加一个与图像尺寸相同的图片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 将演示文稿保存为 PPTX。
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
图片框允许您快速从图像创建演示文稿幻灯片。将图片框与 Aspose.Slides 保存选项结合使用时，您可以控制 I/O 操作，将图像从一种格式转换为另一种格式。您可能想查看以下页面：转换 [image to JPG](https://products.aspose.com/slides/zh/python-net/conversion/image-to-jpg/); 转换 [JPG to image](https://products.aspose.com/slides/zh/python-net/conversion/jpg-to-image/); 转换 [JPG to PNG](https://products.aspose.com/slides/zh/python-net/conversion/jpg-to-png/); 转换 [PNG to JPG](https://products.aspose.com/slides/zh/python-net/conversion/png-to-jpg/); 转换 [PNG to SVG](https://products.aspose.com/slides/zh/python-net/conversion/png-to-svg/); 转换 [SVG to PNG](https://products.aspose.com/slides/zh/python-net/conversion/svg-to-png/)。
{{% /alert %}}

## **按相对比例创建图片框**

本节演示先以固定尺寸放置图像，然后对其宽度和高度分别应用基于百分比的缩放。由于百分比可能不同，宽高比可能会改变。缩放相对于图像的原始尺寸进行。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片。  
3. 通过将图像添加到演示文稿的 [ImageCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 来创建 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)。  
4. 向幻灯片添加一个 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)。  
5. 设置图片框的相对宽度和高度。  
6. 将演示文稿保存为 PPTX 文件。

以下 Python 代码展示如何创建具有相对缩放的图片框：

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

        # 设置相对缩放的宽度和高度。
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # 保存演示文稿。
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **从图片框中提取栅格图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 对象中提取栅格图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示如何从文档 "sample.pptx" 中提取图像并以 PNG 格式保存。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **从图片框中提取 SVG 图像**

当演示文稿在 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 形状中包含 SVG 图形时，Aspose.Slides for Python via .NET 允许您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)，检查底层的 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 是否包含 SVG 内容，然后将该图像以其原生 SVG 格式保存到磁盘或流中。

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
所有应用于图像的效果可在 [aspose.slides.effects](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/) 中找到。
{{% /alert %}}

## **获取图像的亮度和对比度**

Aspose.Slides 允许您获取应用于图像的亮度和对比度效果。[Luminance](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/luminance/) 类表示此图像变换效果。

下面的 Python 代码演示如何从图片框获取亮度和对比度设置：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **图片框格式化**

Aspose.Slides 提供许多可应用于图片框的格式化选项。使用这些选项，您可以调整图片框以满足特定需求。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片。  
3. 通过将图像添加到演示文稿的 [ImageCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 来创建 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)。该图像将用于填充形状。  
4. 指定框的宽度和高度。  
5. 使用幻灯片的 [add_picture_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法创建相同尺寸的 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)。  
6. 设置图片框的线条颜色。  
7. 设置图片框的线条宽度。  
8. 通过提供正值（顺时针）或负值（逆时针）来旋转图片框。  
9. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示图片框格式化过程：

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

        # 添加一个与图像尺寸相同的图片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 对图片框应用格式化。
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # 将演示文稿保存为 PPTX。
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="提示" color="primary" %}}
Aspose 已开发了免费 [Collage Maker](https://products.aspose.app/slides/zh/collage)。如果您需要 [merge JPG/JPEG](https://products.aspose.app/slides/zh/collage/jpg) 或 PNG 图像，或 [create photo grids](https://products.aspose.app/slides/zh/collage/photo-grid)，可以使用此服务。
{{% /alert %}}

## **将图像添加为链接**

为了保持演示文稿文件体积小，您可以通过链接添加图像或视频，而不是将文件直接嵌入到演示文稿中。下面的 Python 代码演示如何将图像和视频插入占位符：

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

本节中，您将学习如何在不更改源文件的情况下裁剪图片框内图像的可见区域。您还将了解在幻灯片上直接应用裁剪边距以创建清晰、聚焦构图的基本方法。

以下 Python 代码展示如何在幻灯片上裁剪图像：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 将图像添加到演示文稿的图像集合。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 向幻灯片添加图片框。
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

如果您想删除框中图像的裁剪区域，请使用 [delete_picture_cropped_areas](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法。该方法返回裁剪后的图像，如果无需裁剪则返回原始图像。

以下 Python 代码演示该操作：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 获取第一张幻灯片中的 PictureFrame。
    picture_frame = slides.shape[0]

    # 获取第一张幻灯片中的 PictureFrame。
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 保存结果。
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}}
[delete_picture_cropped_areas](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理过的 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 中使用，这可以减小演示文稿大小；否则，生成的演示文稿中的图像数量可能会增加。

在裁剪过程中，此方法会将 WMF/EMF 元文件转换为栅格 PNG 图像。
{{% /alert %}}

## **压缩图像**

您可以使用 [PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/compress_image/) 方法压缩演示文稿中的图片。该方法通过根据形状尺寸和指定的分辨率降低图像大小来压缩图像，并可选择删除裁剪区域。

它以类似于 PowerPoint **图片格式 -> 压缩图片 -> 分辨率** 功能的方式调整图片的尺寸和分辨率。

以下 Python 示例演示如何通过指定目标分辨率并可选地删除裁剪区域来压缩演示文稿中的图像：

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 使用目标分辨率 150 DPI（Web 分辨率）压缩图像并删除裁剪区域。
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # 检查压缩的结果。
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

或者直接使用自定义 DPI 值：

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 将图像压缩至 150 DPI（网页分辨率），并删除裁剪区域。
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}}
该方法根据形状的尺寸和提供的 DPI 将图像转换为较低分辨率。也可以删除裁剪区域以优化文件大小。  
如果图像是元文件（WMF/EMF）或 SVG，则不会进行压缩。此外，JPEG 的质量会根据分辨率保持或略有降低，类似于 PowerPoint 对高清 JPEG 的处理方式。
{{% /alert %}}

## **锁定长宽比**

如果您希望包含图像的形状在更改图像尺寸后保持其宽高比，请将 [aspect_ratio_locked](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 属性设置为 `True`。

以下 Python 代码展示如何锁定形状的宽高比：

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

{{% alert title="注意" color="warning" %}}
此 *锁定宽高比* 设置仅保持形状的宽高比，而不保持内部图像的宽高比。
{{% /alert %}}

## **使用拉伸偏移属性**

使用 [PictureFillFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/) 类的 `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right` 和 `stretch_offset_bottom` 属性，您可以定义填充矩形。

当为图像指定拉伸时，源矩形会按比例缩放以适应填充矩形。填充矩形的每条边由相对于形状边界框对应边缘的百分比偏移定义。正百分比表示内缩，负百分比表示外扩。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。  
4. 设置形状的填充类型。  
5. 设置形状的图片填充模式。  
6. 加载图像。  
7. 将图像分配给形状进行填充。  
8. 指定图像相对于形状边界框对应边缘的偏移。  
9. 将演示文稿保存为 PPTX 文件。

以下 Python 代码演示如何使用拉伸偏移属性：

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个矩形自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # 设置形状的填充类型。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 设置形状的图片填充模式。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 加载图像并将其添加到演示文稿。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # 将图像分配给形状以进行填充。
    shape.fill_format.picture_fill_format.picture.image = image

    # 指定图像相对于形状边界框对应边缘的偏移。
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # 将 PPTX 文件保存到磁盘。
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="提示" color="primary" %}}
Aspose 提供免费转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可让您快速从图像创建演示文稿。
{{% /alert %}}

## **常见问题**

**如何了解 PictureFrame 支持哪些图像格式？**

Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 的图像对象同时支持栅格图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的功能相重叠。

**添加几十个大图像会怎样影响 PPTX 大小和性能？**

嵌入大图像会增加文件大小和内存占用；通过链接图像可以保持演示文稿体积较小，但需要外部文件保持可访问。Aspose.Slides 提供通过链接添加图像的功能以减小文件大小。

**如何锁定图像对象以防止意外移动/缩放？**

对 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/picture_frame_lock/)（例如，禁用移动或缩放）。锁定机制在专门的 [保护文章](/slides/zh/python-net/applying-protection-to-presentation/) 中描述，支持包括 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 在内的多种形状类型。

**导出演示文稿为 PDF/图像时，SVG 矢量的保真度是否得到保留？**

Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 中提取原始 SVG 矢量。当 [导出为 PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/) 或 [栅格格式](/slides/zh/python-net/convert-powerpoint-to-png/) 时，结果可能会根据导出设置被栅格化；通过提取行为可以确认原始 SVG 仍以矢量形式存储。