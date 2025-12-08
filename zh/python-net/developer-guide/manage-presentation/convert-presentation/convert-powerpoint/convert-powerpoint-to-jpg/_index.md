---
title: 在 Python 中将 PPT、PPTX 和 ODP 转换为 JPG
linktitle: 将幻灯片转换为 JPG 图像
type: docs
weight: 60
url: /zh/python-net/convert-powerpoint-to-jpg/
keywords:
- 将 PowerPoint 转换为 JPG
- 将演示文稿转换为 JPG
- 将幻灯片转换为 JPG
- 将 PPT 转换为 JPG
- 将 PPTX 转换为 JPG
- 将 ODP 转换为 JPG
- PowerPoint 转 JPG
- 演示文稿转 JPG
- 幻灯片转 JPG
- PPT 转 JPG
- PPTX 转 JPG
- ODP 转 JPG
- 将 PowerPoint 转换为 JPEG
- 将演示文稿转换为 JPEG
- 将幻灯片转换为 JPEG
- 将 PPT 转换为 JPEG
- 将 PPTX 转换为 JPEG
- 将 ODP 转换为 JPEG
- PowerPoint 转 JPEG
- 演示文稿转 JPEG
- 幻灯片转 JPEG
- PPT 转 JPEG
- PPTX 转 JPEG
- ODP 转 JPEG
- Python
- Aspose.Slides
description: "了解如何使用 Python 仅几行代码将 PowerPoint 和 OpenDocument 演示文稿转换为高质量的 JPEG 图像。优化演示文稿以用于网页、共享和归档。立即阅读完整指南！"
---

## **概述**

将 PowerPoint 和 OpenDocument 演示文稿转换为 JPG 图像有助于共享幻灯片、优化性能以及将内容嵌入网站或应用程序。Aspose.Slides for Python 允许您将 PPTX、PPT 和 ODP 文件转换为高质量的 JPEG 图像。本指南解释了不同的转换方法。

通过这些功能，您可以轻松实现自己的演示文稿查看器并为每张幻灯片创建缩略图。如果您想保护幻灯片不被复制或以只读模式演示演示文稿，这将非常有用。Aspose.Slides 允许您将整个演示文稿或特定幻灯片转换为图像格式。

## **将演示文稿幻灯片转换为 JPG 图像**

以下是将 PPT、PPTX 或 ODP 文件转换为 JPG 的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 从 [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合中获取 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 类型的幻灯片对象。  
3. 使用 [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float) 方法创建幻灯片的图像。  
4. 在图像对象上调用 [IImage.save(filename, format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) 方法。将输出文件名和图像格式作为参数传入。

{{% alert color="primary" %}}
**Note:** PPT、PPTX 或 ODP 转换为 JPG 与 Aspose.Slides Python API 中转换为其他格式的方式不同。对于其他格式，您通常使用 [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) 方法。然而，对于 JPG 转换，您需要使用 [IImage.save(filename, format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) 方法。
{{% /alert %}}
```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # 将图像保存到磁盘，使用 JPEG 格式。
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **使用自定义尺寸将幻灯片转换为 JPG**

要更改生成的 JPG 图像的尺寸，您可以通过将图片大小传递给 [Slide.get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) 方法来设置图像尺寸。这使您能够生成具有特定宽度和高度值的图像，确保输出满足分辨率和宽高比的要求。这种灵活性在为 Web 应用程序、报告或文档生成图像时特别有用，需要精确的图像尺寸。
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # 创建具有指定尺寸的幻灯片图像。
        with slide.get_image(image_size) as thumbnail:
            # 将图像保存到磁盘，使用 JPEG 格式。
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **在将幻灯片保存为图像时渲染批注**

Aspose.Slides for Python 提供了一项功能，允许在将演示文稿的幻灯片转换为 JPG 图像时渲染批注。此功能对于保留 PowerPoint 演示文稿中协作者添加的注释、反馈或讨论特别有用。启用此选项后，批注将在生成的图像中可见，使得在无需打开原始演示文稿文件的情况下更容易审阅和共享反馈。

假设我们有一个演示文稿文件 “sample.pptx”，其中的一张幻灯片包含批注：

![带有批注的幻灯片](slide_with_comments.png)

下面的 Python 代码将在保留批注的同时将幻灯片转换为 JPG 图像：

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # 设置幻灯片批注的选项。
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # 将第一张幻灯片转换为图像。
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```


结果：

![带有批注的 JPG 图像](image_with_comments.png)

## **另请参见**

查看将 PPT、PPTX 或 ODP 转换为图像的其他选项，例如：

- [将 PowerPoint 转换为 GIF](/slides/zh/python-net/convert-powerpoint-to-animated-gif/)
- [将 PowerPoint 转换为 PNG](/slides/zh/python-net/convert-powerpoint-to-png/)
- [将 PowerPoint 转换为 TIFF](/slides/zh/python-net/convert-powerpoint-to-tiff/)
- [将 PowerPoint 转换为 SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
要了解 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，请尝试以下免费在线转换器：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

![免费在线 PPTX 转 JPG 转换器](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid) 等。

使用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。欲了解更多信息，请参阅以下页面：将 [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/) 转换；将 [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/) 转换；将 [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/) 转换，将 [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/) 转换；将 [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/) 转换，将 [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/) 转换。

{{% /alert %}}

## **常见问题**

**此方法是否支持批量转换？**

是的，Aspose.Slides 允许在一次操作中将多个幻灯片批量转换为 JPG。

**转换是否支持 SmartArt、图表和其他复杂对象？**

是的，Aspose.Slides 能渲染所有内容，包括 SmartArt、图表、表格、形状等。不过，与 PowerPoint 相比，渲染的准确性可能会有轻微差异，尤其是在使用自定义或缺失的字体时。

**处理的幻灯片数量是否有限制？**

Aspose.Slides 本身对可处理的幻灯片数量没有严格限制。但在处理大型演示文稿或高分辨率图像时，可能会遇到内存不足错误。