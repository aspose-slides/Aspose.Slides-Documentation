---
title: 转换幻灯片
type: docs
weight: 41
url: /python-net/convert-slide/
keywords: 
- 转换幻灯片为图像
- 将幻灯片导出为图像
- 将幻灯片保存为图像
- 幻灯片转图像
- 幻灯片转PNG
- 幻灯片转JPEG
- 幻灯片转位图
- PHP
- Aspose.Slides for Python via .NET
description: "在Python中将PowerPoint幻灯片转换为图像（位图、PNG或JPG）"
---

Aspose.Slides for Python via .NET允许您将幻灯片（在演示文稿中）转换为图像。这些是支持的图像格式：BMP、PNG、JPG（JPEG）、GIF等。

要将幻灯片转换为图像，请执行以下操作：

1. 首先，使用以下接口设置转换参数和需要转换的幻灯片对象：
   * [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) 接口或
   * [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/) 接口。

2. 其次，通过使用 [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 方法将幻灯片转换为图像。

## **关于位图和其他图像格式**

在 .NET 中，[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) 是一个允许您使用像素数据定义的图像进行操作的对象。您可以使用该类的实例以广泛的格式（BMP、JPG、PNG 等）保存图像。

{{% alert title="信息" color="info" %}}

Aspose最近开发了一个在线 [文本到GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}

## **将幻灯片转换为位图并将图像保存为PNG**

以下Python代码向您展示如何将演示文稿的第一张幻灯片转换为位图对象，然后如何将图像保存为PNG格式：

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # 将演示文稿中的第一张幻灯片转换为位图对象
    with pres.slides[0].get_image() as bmp:
        # 将图像保存为PNG格式
        bmp.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert title="提示" color="primary" %}} 

您可以将幻灯片转换为位图对象，然后直接在某处使用该对象。或者您可以将幻灯片转换为位图，然后将图像保存为JPEG或您喜欢的任何其他格式。

{{% /alert %}}  

## **使用自定义大小将幻灯片转换为图像**

您可能需要获取特定大小的图像。使用[get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)的重载，您可以将幻灯片转换为具有特定尺寸（长度和宽度）的图像。

此示例代码演示了使用 [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 方法在Python中进行提议的转换：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # 将演示文稿中的第一张幻灯片转换为指定大小的位图
    with pres.slides[0].get_image(draw.Size(1820, 1040)) as bmp:
        # 将图像保存为JPEG格式
        bmp.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **将带注释和评论的幻灯片转换为图像**

某些幻灯片包含注释和评论。

Aspose.Slides提供了两个接口——[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) 和 [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/)——使您能够控制将演示文稿幻灯片呈现为图像的过程。这两个接口都包含 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) 接口，允许您在将幻灯片转换为图像时在幻灯片上添加注释和评论。

{{% alert title="信息" color="info" %}} 

使用 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) 接口，您可以指定在生成的图像中注释和评论的首选位置。

{{% /alert %}} 

以下Python代码演示了带有注释和评论的幻灯片的转换过程：

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # 创建渲染选项
    options = slides.export.RenderingOptions()
                
    # 设置页面上注释的位置
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
                
    # 设置页面上评论的位置 
    options.notes_comments_layouting.comments_position = slides.export.CommentsPositions.RIGHT

    # 设置评论输出区域的宽度
    options.notes_comments_layouting.comments_area_width = 500
                
    # 设置评论区域的颜色
    options.notes_comments_layouting.comments_area_color = draw.Color.antique_white
                
    # 将演示文稿的第一张幻灯片转换为位图对象
    with pres.slides[0].get_image(options, 2, 2) as bmp:
        # 将图像保存为GIF格式
        bmp.save("Slide_Notes_Comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="注意" color="warning" %}} 

在任何幻灯片到图像的转换过程中，[NotesPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) 属性不能设置为BottomFull（以指定注释的位置），因为注释的文本可能很大，这意味着它可能无法适应指定的图像大小。

{{% /alert %}} 

## **使用ITiffOptions将幻灯片转换为图像**

[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) 接口使您能够对生成的图像进行更详细的控制（在参数方面）。使用此接口，您可以为生成的图像指定大小、分辨率、调色板和其他参数。

以下Python代码演示了一个转换过程，其中使用ITiffOptions生成300dpi分辨率和2160 × 2800大小的黑白图像：

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "Comments1.pptx") as pres:
    # 通过索引获取幻灯片
    slide = pres.slides[0]

    # 创建一个TiffOptions对象
    options = slides.export.TiffOptions() 
    options.image_size = draw.Size(2160, 2880)

    # 如果找不到源字体，则设置所用字体
    options.default_regular_font = "Arial Black"

    # 设置页面上注释的位置 
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # 设置像素格式（黑白）
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED

    # 设置分辨率
    options.dpi_x = 300
    options.dpi_y = 300

    # 将幻灯片转换为位图对象
    with slide.get_image(options) as bmp:
        # 将图像保存为BMP格式
        bmp.save("PresentationNotesComments.tiff", slides.ImageFormat.TIFF)
```

## **将所有幻灯片转换为图像**

Aspose.Slides允许您将单个演示文稿中的所有幻灯片转换为图像。实际上，您可以将整个演示文稿转换为图像。

以下示例代码向您展示了如何在Python中将演示文稿中的所有幻灯片转换为图像：

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # 按幻灯片逐一渲染演示文稿为图像数组
    for i in range(len(pres.slides)):
        # 指定对隐藏幻灯片的设置（不渲染隐藏幻灯片）
        if pres.slides[i].hidden:
            continue

        # 将幻灯片转换为位图对象
        with pres.slides[i].get_image() as bmp:
            # 将图像保存为JPEG格式
            bmp.save("image_{0}.jpeg".format(i), slides.ImageFormat.JPEG)
```