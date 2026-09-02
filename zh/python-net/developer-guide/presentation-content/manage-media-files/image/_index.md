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
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 Aspose.Slides for Python（基于 .NET），简化 PowerPoint 和 OpenDocument 中的图像管理，优化性能并自动化工作流。"
---
## **简介**

图片使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他来源向幻灯片插入图片。同样，Aspose.Slides 也提供多种方式向幻灯片添加图片。

{{% alert  title="Tip" color="primary" %}}
Aspose 提供免费的转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——让您可以快速从图像创建演示文稿。
{{% /alert %}}

{{% alert title="Info" color="info" %}}
如果您想将图像作为框架对象添加——尤其是计划使用如调整大小或应用效果等标准格式选项——请参阅[Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/zh/python-net/picture-frame/)。
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
您可以使用图像和演示文稿的 I/O 操作在不同格式之间转换图像。请参阅以下页面：将 [image to JPG](https://products.aspose.com/slides/zh/python-net/conversion/image-to-jpg/) 转换为 JPG；将 [JPG to image](https://products.aspose.com/slides/zh/python-net/conversion/jpg-to-image/) 转换为图像；将 [JPG to PNG](https://products.aspose.com/slides/zh/python-net/conversion/jpg-to-png/) 转换为 PNG；将 [PNG to JPG](https://products.aspose.com/slides/zh/python-net/conversion/png-to-jpg/) 转换为 JPG；将 [PNG to SVG](https://products.aspose.com/slides/zh/python-net/conversion/png-to-svg/) 转换为 SVG；以及将 [SVG to PNG](https://products.aspose.com/slides/zh/python-net/conversion/svg-to-png/) 转换为 PNG。
{{% /alert %}}

Aspose.Slides 支持使用 JPEG、PNG、BMP、GIF 等常见格式的图像。

## **将本地存储的图像添加到幻灯片**

您可以将一张或多张计算机上的图像添加到演示文稿的幻灯片中。下面的 Python 示例演示了如何向幻灯片添加图像：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **从网络添加图像到幻灯片**

如果要添加到幻灯片的图像在计算机上不存在，您可以直接从网络插入它。

下面的 Python 示例演示了如何从 URL 向幻灯片添加图像：

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 下载原始图像字节。
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **将图像添加到幻灯片母版**

幻灯片母版是顶层幻灯片，存储并控制主题、布局等信息，供其下所有幻灯片使用。当您向幻灯片母版添加图像时，该图像会出现在使用该母版的每一张幻灯片上。

下面的 Python 示例演示了如何向幻灯片母版添加图像：

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

您可以将图片用作一张或多张幻灯片的背景。详情请参阅*[将图像设置为幻灯片背景](/slides/zh/python-net/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿添加 SVG**

可以使用 [SvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/) 类将 SVG 内容添加到演示文稿中。得到的 SVG 图像随后可以加入演示文稿的图像集合，并用于创建图片框架。

下面的 Python 示例导入一个自包含的 SVG 字符串。此 SVG 使用的所有图像、样式和其他资源均直接嵌入在 SVG 内容中。

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **将 SVG 转换为形状集合**

Aspose.Slides 将 SVG 转换为形状集合的方式类似于 PowerPoint 对 SVG 的处理。

![PowerPoint 弹出菜单](img_01_01.png)

该功能由 [ShapeCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/) 类中的 [add_group_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_group_shape/) 方法的重载实现，该重载接受一个 [SvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/) 作为第一个参数。

下面的示例代码展示了如何将 SVG 文件转换为形状集合。

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 读取 SVG 文件内容。
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # 创建 SvgImage 对象。
        svg_image = slides.SvgImage(svg_content)

        # 获取幻灯片大小。
        slide_size = presentation.slide_size.size

        # 将 SVG 图像转换为形状组并按幻灯片大小进行缩放。
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # 以 PPTX 格式保存演示文稿。
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **将图像作为 EMF 添加到幻灯片**

Aspose.Slides for Python 允许您将增强型图元文件（EMF）图像插入演示文稿。

下面的 Python 示例演示了此操作：

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **在图像集合中替换图像**

Aspose.Slides 允许您替换演示文稿图像集合中的图像，包括幻灯片形状使用的图像。本节概述了几种更新集合中图像的方法。API 提供直接的方法，可使用原始字节数据、[IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 实例或集合中已存在的另一图像来替换图像。

操作步骤：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类加载包含图像的演示文稿。  
2. 将新图像从文件加载到字节数组。  
3. 使用字节数组将目标图像替换为新图像。  
4. 或者，将图像加载到 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 对象中，并使用该对象替换目标图像。  
5. 或将目标图像替换为演示文稿图像集合中已存在的图像。  
6. 将修改后的演示文稿另存为 PPTX 文件。

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation("sample.pptx") as presentation:

    # 第一种方式。
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # 第二种方式。
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # 第三种方式。
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # 将演示文稿保存到文件。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
使用 Aspose 免费的[Text to GIF](https://products.aspose.app/slides/zh/text-to-gif) 转换器，您可以轻松为文本添加动画并将文本生成 GIF。
{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素会被保留，但最终的显示效果取决于在幻灯片上对[picture](/slides/zh/python-net/picture-frame/)的缩放方式以及保存时所使用的压缩。

**一次性替换数十张幻灯片上的相同徽标的最佳方法是什么？**

将徽标放置在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——所有使用该资源的元素都会同步更新。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，之后各个部分即可使用标准形状属性进行编辑。

**如何一次性将图片设为多张幻灯片的背景？**

在母版幻灯片或相应布局上[将图像设置为背景](/slides/zh/python-net/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿体积过大？**

重复使用同一图像资源而非复制，选择合适的分辨率，保存时进行压缩，并在适当情况下将重复的图形放在母版上。