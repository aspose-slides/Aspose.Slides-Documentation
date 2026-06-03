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
description: "使用 Aspose.Slides for Python via .NET 将图片框添加到 PowerPoint 和 OpenDocument 演示文稿中。简化工作流程并提升幻灯片设计。"
---
## **简介**

Aspose.Slides for Python 中的图片框允许您将光栅图像和矢量图像放置为原生幻灯片形状并进行管理。您可以从文件或流中插入图片，使用精确坐标定位和调整大小，应用旋转、设置透明度，并在其他形状旁控制 Z 顺序。API 还支持裁剪、保持宽高比、设置边框和效果，以及在不重新构建布局的情况下更换底层图像。由于图片框的行为类似普通形状，您可以为其添加动画、超链接和替代文本，从而轻松构建视觉丰富且可访问的演示文稿。

## **创建图片框**

本节展示如何通过 Aspose.Slides for Python 创建一个 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 并将图像插入幻灯片。您将学习如何加载图像、精确放置以及控制其尺寸和格式。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片。  
3. 通过将图像添加到演示文稿的 [ImageCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 中创建一个 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)。该图像将用于填充形状。  
4. 指定框的宽度和高度。  
5. 使用 [add_picture_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法创建相应尺寸的 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)。  
6. 将演示文稿保存为 PPTX 文件。

以下 Python 代码演示了如何创建图片框：

```py
import aspose.slides as slides

# 实例化 Presentation 类以表示 PPTX 文件。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 将图像添加到演示文稿中。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 添加一个与图像大小相同的图片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 将演示文稿保存为 PPTX。
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
图片框可让您快速使用图像创建演示文稿幻灯片。将图片框与 Aspose.Slides 保存选项结合使用时，您可以控制 I/O 操作，将图像从一种格式转换为另一种格式。您可能需要查看以下页面：转换 [image to JPG](https://products.aspose.com/slides/zh/python-net/conversion/image-to-jpg/)；转换 [JPG to image](https://products.aspose.com/slides/zh/python-net/conversion/jpg-to-image/)；转换 [JPG to PNG](https://products.aspose.com/slides/zh/python-net/conversion/jpg-to-png/)；转换 [PNG to JPG](https://products.aspose.com/slides/zh/python-net/conversion/png-to-jpg/)；转换 [PNG to SVG](https://products.aspose.com/slides/zh/python-net/conversion/png-to-svg/)；转换 [SVG to PNG](https://products.aspose.com/slides/zh/python-net/conversion/svg-to-png/)。
{{% /alert %}}

## **使用相对比例创建图片框**

本节演示如何将图像以固定尺寸放置，然后分别对宽度和高度应用基于百分比的缩放。由于百分比可能不同，宽高比会发生变化。缩放是相对于图像的原始尺寸进行的。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片。  
3. 通过将图像添加到演示文稿的 [ImageCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 中创建一个 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)。  
4. 向幻灯片添加一个 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)。  
5. 设置图片框的相对宽度和高度。  
6. 将演示文稿保存为 PPTX 文件。

以下 Python 代码演示了如何使用相对缩放创建图片框：

```py
import aspose.slides as slides

# 实例化 Presentation 类以表示 PPTX 文件。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 将图像添加到演示文稿的图像集合中。
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

## **从图片框中提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 对象中提取光栅图像，并以 PNG、JPG 等格式保存。下面的代码示例演示如何从文档 “sample.pptx” 中提取图像并以 PNG 格式保存。

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

当演示文稿包含放置在 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 形状中的 SVG 图形时，Aspose.Slides for Python via .NET 可让您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)，检查其底层 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)