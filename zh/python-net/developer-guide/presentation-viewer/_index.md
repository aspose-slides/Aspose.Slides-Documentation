---
title: 演示文稿查看器
type: docs
weight: 50
url: /zh/python-net/presentation-viewer/
keywords: "查看 PowerPoint 演示文稿, 查看 ppt, 查看 PPTX, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中查看 PowerPoint 演示文稿"
---



Aspose.Slides for Python via .NET 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过 Microsoft PowerPoint 打开演示文稿进行查看。但是，有时开发人员可能还需要在他们喜欢的图像查看器中将幻灯片作为图像查看，或者创建他们自己的演示文稿查看器。在这种情况下，Aspose.Slides for Python via .NET 允许您将单个幻灯片导出为图像。本文描述了如何做到这一点。
## **实时示例**
您可以尝试 [**Aspose.Slides 查看器**](https://products.aspose.app/slides/viewer/) 免费应用程序，以查看您可以使用 Aspose.Slides API 实现的功能：

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **从幻灯片生成 SVG 图像**
要使用 Aspose.Slides for Python 从任何所需的幻灯片生成 SVG 图像，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 通过使用其 ID 或索引来获取所需幻灯片的引用。
- 在内存流中获取 SVG 图像。
- 将内存流保存到文件中。

```py
import aspose.slides as slides

# 实例化代表演示文稿文件的 Presentation 类
with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 创建内存流对象
    with open("Aspose_out-1.svg", "wb") as svg_stream:
        # 生成幻灯片的 SVG 图像并保存在内存流中
        sld.write_as_svg(svg_stream)
```


## **使用自定义形状 ID 生成 SVG**
Aspose.Slides for Python via .NET 可用于从具有自定义形状 ID 的幻灯片生成 [SVG ](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用代表生成的 SVG 中形状自定义 ID 的 [ISvgShape](https://reference.aspose.com/slides/python-net/aspose.slides.export/isvgshape/) 中的 ID 属性。CustomSvgShapeFormattingController 可用于设置形状 ID。

```py
import aspose.slides as slides

with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    with open("Aspose_out-2.svg", "wb") as svg_stream:
        svgOptions = slides.export.SVGOptions()
        pres.slides[0].write_as_svg(svg_stream, svgOptions)
```


## **创建幻灯片缩略图图像**
Aspose.Slides for Python via .NET 可帮助您生成幻灯片的缩略图图像。要使用 Aspose.Slides for Python via .NET 生成任何所需幻灯片的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过使用其 ID 或索引来获取所需幻灯片的引用。
1. 在指定比例下获取引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

```py
import aspose.slides as slides

# 实例化代表演示文稿文件的 Presentation 类
with slides.Presentation("pres.pptx") as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 创建全尺度图像
    with sld.get_image(1, 1) as bmp:
        # 以 JPEG 格式将图像保存到磁盘
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


## **使用用户定义的尺寸创建缩略图**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过使用其 ID 或索引来获取所需幻灯片的引用。
1. 在指定比例下获取引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

```py
import aspose.slides as slides

# 实例化代表演示文稿文件的 Presentation 类
with slides.Presentation("pres.pptx") as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 用户定义的尺寸
    desiredX = 1200
    desiredY = 800

    # 获取 X 和 Y 的缩放值
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY


    # 创建全尺度图像
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # 以 JPEG 格式将图像保存到磁盘
        bmp.save("Thumbnail2_out.jpg", slides.ImageFormat.JPEG)
```


## **从备注幻灯片视图中的幻灯片创建缩略图**
要使用 Aspose.Slides for Python via .NET 生成任何所需幻灯片在备注幻灯片视图中的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过使用其 ID 或索引来获取所需幻灯片的引用。
1. 在备注幻灯片视图中以指定比例获取引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

以下代码片段生成演示文稿第一张幻灯片在备注幻灯片视图中的缩略图。

```py
import aspose.slides as slides

# 实例化代表演示文稿文件的 Presentation 类
with slides.Presentation("pres.pptx") as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 用户定义的尺寸
    desiredX = 1200
    desiredY = 800

    # 获取 X 和 Y 的缩放值
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

   
    # 创建全尺度图像                
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # 以 JPEG 格式将图像保存到磁盘
        bmp.save("Notes_tnail_out.jpg", slides.ImageFormat.JPEG)
```