---
title: 使用 Python 优化 PowerPoint 中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/python-net/image/
keywords:
- 添加图像
- 添加图片
- 添加位图
- 替换图像
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "通过 Aspose.Slides for Python（基于 .NET），简化 PowerPoint 和 OpenDocument 中的图像管理，优化性能并自动化工作流。"
---

## **概述**

图像使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他来源向幻灯片插入图片。同样，Aspose.Slides 也允许您以多种方式向幻灯片添加图像。

{{% alert  title="Tip" color="primary" %}}
Aspose 提供免费的转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——让您能够快速使用图像创建演示文稿。
{{% /alert %}}

{{% alert title="Info" color="info" %}}
如果您想将图像作为框架对象添加——尤其是计划使用诸如调整大小或应用效果等标准格式选项——请参阅 [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/python-net/picture-frame/)。
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
您可以使用图像和演示文稿的 I/O 操作在不同格式之间转换图像。请参阅以下页面：将 [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/) 转换；将 [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/) 转换；将 [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/) 转换；将 [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/) 转换；将 [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/) 转换；以及将 [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/) 转换。
{{% /alert %}}

Aspose.Slides 支持使用 JPEG、PNG、BMP、GIF 等流行格式的图像。

## **向幻灯片添加本地存储的图像**

您可以从计算机向演示文稿中的幻灯片添加一个或多个图像。以下 Python 示例展示了如何向幻灯片添加图像：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **从网络向幻灯片添加图像**

如果您要添加到幻灯片的图像在电脑上不可用，可以直接从网络插入。

以下 Python 示例展示了如何从 URL 向幻灯片添加图像：
```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **向幻灯片母版添加图像**

幻灯片母版是最高层的幻灯片，存储并控制主题、布局等信息，供其下所有幻灯片使用。当您向母版添加图像时，该图像会出现在使用该母版的每一张幻灯片上。

以下 Python 示例展示了如何向幻灯片母版添加图像：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **将图像设为幻灯片背景**

您可能希望将图像用作特定幻灯片或多个幻灯片的背景。详情请参阅 [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/python-net/presentation-background/#set-image-as-background-for-slide)。

## **向演示文稿添加 SVG**

您可以使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 类的 [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法将任意图像插入演示文稿。

要从 SVG 创建图像对象，请按以下步骤操作：

1. 创建一个 [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) 并将其添加到演示文稿的图像集合中。  
2. 从 [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) 创建 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 对象。  
3. 使用 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 创建 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 对象。

以下 Python 示例展示了如何使用这些步骤向演示文稿添加 SVG 图像：
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 读取 SVG 文件的内容。
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # 创建 SvgImage 对象。
        svg_image = slides.SvgImage(svg_content)

        # 创建 PPImage 对象。
        pp_image = presentation.images.add_image(svg_image)

        # 创建新的 PictureFrame。
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # 以 PPTX 格式保存演示文稿。
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **将 SVG 转换为形状集合**

Aspose.Slides 将 SVG 转换为一组形状，方式类似于 PowerPoint 对 SVG 的处理。

![PowerPoint 弹出菜单](img_01_01.png)

此功能由 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 类中重载的 [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_group_shape/) 方法提供，该方法的第一个参数接受 [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/)。

下面的示例代码展示了如何将 SVG 文件转换为形状集合。
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 读取 SVG 文件内容。
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # 创建 SvgImage 对象。
        svg_image = slides.SvgImage(svg_content)

        # 获取幻灯片尺寸。
        slide_size = presentation.slide_size.size

        # 将 SVG 图像转换为形状组并按幻灯片尺寸缩放。
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # 以 PPTX 格式保存演示文稿。
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **在幻灯片中以 EMF 形式添加图像**

Aspose.Slides for Python 让您能够在演示文稿中插入增强型图元文件（EMF）图像。

以下 Python 示例演示了此操作：
```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```


## **替换图像集合中的图像**

Aspose.Slides 允许您替换存储在演示文稿图像集合中的图像，包括幻灯片形状使用的图像。本文档概述了多种更新集合中图像的方法。API 提供了直接使用原始字节数据、[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) 实例或集合中已有的其他图像来替换图像的简便方法。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载包含图像的演示文稿。  
2. 从文件加载新图像到字节数组中。  
3. 使用字节数组将目标图像替换为新图像。  
4. 或者，将图像加载到 [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) 对象中，并使用该对象替换目标图像。  
5. 或者，用演示文稿图像集合中已存在的图像替换目标图像。  
6. 将修改后的演示文稿保存为 PPTX 文件。

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation("sample.pptx") as presentation:

    # 第一种方法。
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # 第二种方法。
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # 第三种方法。
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # 将演示文稿保存到文件。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松为文字添加动画并生成 GIF。
{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持完整？**

是的。源像素会被保留，但最终外观取决于 [picture](/slides/zh/python-net/picture-frame/) 在幻灯片上的缩放方式以及保存时是否应用了压缩。

**一次性替换数十张幻灯片上的相同徽标的最佳方法是什么？**

将徽标放在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——所有使用该资源的元素都会自动更新。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，之后各个部件即可通过标准形状属性编辑。

**如何一次性为多张幻灯片设置图片背景？**

在母版幻灯片或相关布局上[将图像设为背景](/slides/zh/python-net/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿体积“膨胀”？**

重复使用同一图像资源而不是创建副本，选择合理的分辨率，保存时进行压缩，并在适当情况下将重复图形放在母版上。