---
title: 图片
type: docs
weight: 10
url: /zh/python-net/image/
keywords: "添加图片, 添加图像, PowerPoint演示文稿, EMF, SVG, Python, Aspose.Slides for Python via .NET"
description: "在Python中向PowerPoint幻灯片或演示文稿添加图像"
---

## **演示文稿中的幻灯片图像**

图像使演示文稿更具吸引力和趣味性。在Microsoft PowerPoint中，您可以从文件、互联网或其他位置将图片插入幻灯片。同样，Aspose.Slides允许您通过不同的程序将图像添加到演示文稿中的幻灯片。

{{% alert title="提示" color="primary" %}} 

Aspose提供免费的转换器—[JPEG到PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)和[PNG到PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—可以让人们迅速从图像中创建演示文稿。

{{% /alert %}} 

{{% alert title="信息" color="info" %}}

如果您想将图像作为框架对象添加—特别是如果您计划使用标准格式选项来改变其大小、添加效果等—请参见[图片框](https://docs.aspose.com/slides/python-net/picture-frame/)。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

您可以处理包含图像和PowerPoint演示文稿的输入/输出操作，以将图像从一种格式转换为另一种格式。请参阅这些页面：转换[图像到JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)；转换[JPG到图像](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)；转换[JPG到PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)，转换[PNG到JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)；转换[PNG到SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)，转换[SVG到PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides支持对这些流行格式的图像操作：JPEG、PNG、BMP、GIF等。

## **将本地存储的图像添加到幻灯片**

您可以将计算机上的一张或多张图像添加到演示文稿中的幻灯片上。以下Python示例代码展示了如何将图像添加到幻灯片：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **从网络将图像添加到幻灯片**

如果您想要添加到幻灯片的图像在计算机上不可用，您可以直接从网络添加图像。

以下示例代码展示了如何将网络图像添加到Python中的幻灯片：

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as pres:
    slide = pres.slides[0]
    imageData = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = pres.images.add_image(imageData)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **将图像添加到幻灯片母版**

幻灯片母版是存储和控制关于其下所有幻灯片的信息（主题、布局等）的顶层幻灯片。因此，当您将图像添加到幻灯片母版时，该图像会出现在所有该幻灯片母版下的幻灯片上。

以下Python示例代码展示了如何将图像添加到幻灯片母版：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    masterSlide = slide.layout_slide.master_slide
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
        
    pres.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **将图像作为幻灯片背景添加**

您可以决定使用图像作为特定幻灯片或多个幻灯片的背景。在这种情况下，您需要查看 *[设置幻灯片的背景为图像](https://docs.aspose.com/slides/python-net/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿中添加SVG**

您可以通过使用属于[IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)接口的[add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)方法，将任何图像添加或插入到演示文稿中。

要基于SVG图像创建图像对象，可以这样做：

1. 创建SvgImage对象以将其插入到ImageShapeCollection中
2. 从ISvgImage创建PPImage对象
3. 使用IPPImage接口创建PictureFrame对象

以下示例代码展示了如何实现上述步骤以将SVG图像添加到演示文稿中：
```py 
import aspose.slides as slides

# 创建新的演示文稿
with slides.Presentation() as p:
    # 读取SVG文件内容
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # 创建SvgImage对象
        svgImage = slides.SvgImage(svgContent)

        # 创建PPImage对象
        ppImage = p.images.add_image(svgImage)

        # 创建新的PictureFrame 
        p.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, ppImage.width, ppImage.height, ppImage)

        # 以PPTX格式保存演示文稿
        p.save("presentation_with-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **将SVG转换为一组形状**

Aspose.Slides将SVG转换为一组形状的功能类似于PowerPoint处理SVG图像时使用的功能：

![PowerPoint弹出菜单](img_01_01.png)

该功能由[IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)接口的[add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/addgroupshape/)方法的一个重载提供，该方法的第一个参数是[ISvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/isvgimage/)对象。

以下示例代码展示了如何使用所述方法将SVG文件转换为一组形状：

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 读取SVG文件内容
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # 创建SvgImage对象
        svgImage = slides.SvgImage(svgContent)

        # 获取幻灯片大小
        slide_size = presentation.slide_size.size

        # 将SVG图像转换为形状组，并按幻灯片大小缩放
        presentation.slides[0].shapes.add_group_shape(svgImage, 0, 0, slide_size.width, slide_size.height)

        # 以PPTX格式保存演示文稿
        presentation.save("presentation_with_shape_svg.pptx", slides.export.SaveFormat.PPTX)
```

## **将图像作为EMF添加到幻灯片中**

Aspose.Slides for Python via .NET允许您添加EMF图像。

以下示例代码展示了如何执行所述任务：

```py 
with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("image.emf", "rb") as in_file:
        emfImage = pres.images.add_image(in_file)
        slide_size = pres.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emfImage)
    
    pres.save("pres_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="信息" color="info" %}}

使用Aspose免费的[文本转GIF](https://products.aspose.app/slides/text-to-gif)转换器，您可以轻松地为文本动画、制作GIF等。

{{% /alert %}}