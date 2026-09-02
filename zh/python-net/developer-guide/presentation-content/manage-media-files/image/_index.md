---
title: 使用 Python 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/python-net/image/
keywords:
- 添加图像
- 添加图片
- 替换图像
- 图像集合
- 图片框
- 链接图像
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- SVG 转形状
- 外部 SVG 资源
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中添加、复用、链接、替换和管理光栅图像及 SVG 图像。"
---
## **介绍**

Aspose.Slides for Python via .NET 提供多种处理图像的方式，每种方式都有不同的用途。您可以将图像存储在演示文稿中，在图片框中显示，将其用作幻灯片背景，链接到外部图像，替换共享图像资源，或将 SVG 内容转换为可编辑形状。

本文重点介绍图像资源及其在演示文稿中的使用方式。有关对单个图片框进行裁剪、透明度、效果、拉伸等格式设置，请参阅[Picture Frame](/slides/zh/python-net/picture-frame/)。

## **了解图像模型**

以下 API 概念密切相关但不可互换：

- [presentation image collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 存储演示文稿使用的图像资源。使用[ImageCollection.add_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/add_image/)添加图像数据并获取[IPPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ippimage/)资源。
- [picture frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ipictureframe/) 是在幻灯片、布局或母版上显示图像的形状。使用[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_picture_frame/)将图像资源放置在幻灯片上。
- 幻灯片背景使用图像作为幻灯片填充的一部分，而不是作为形状，因此其行为不同于图片框。
- [IPPImage.replace_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ippimage/replace_image/) 替换图像资源。如果多个演示文稿元素使用该资源，它们都会使用替换后的图像。
- 将 SVG 转换为形状会创建可编辑的幻灯片形状。转换后，内容不再作为单个图片资源进行管理。

典型的工作流程是：将图像数据添加到图像集合，获取[IPPImage]，然后在一个或多个图片框或填充中使用该资源。

## **添加嵌入图像**

要插入本地图像，读取文件，将其数据添加到图像集合，并创建使用返回的`IPPImage`的图片框。

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

这种方式添加的图像会嵌入到演示文稿中，生成的文件无需原始图像文件仍然可用。

### **添加网络图片**

当图像通过 HTTP 或 HTTPS 可用时，下载其字节，将其添加到演示文稿图像集合，并以与本地图像相同的方式使用返回的图像资源。

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

在长时间运行的应用程序中，适当时复用 HTTP 客户端或连接池，而不是为每个请求创建新连接。同时在来源不可信时验证远程 URL、响应大小和内容类型。

## **跨幻灯片复用图像**

如果同一图像需要多次使用，只需在演示文稿中添加一次，并在创建其他图片框时复用返回的[IPPImage]。这样可避免重复加载相同的源数据，并明确共享图像资源与其使用之间的关系。

对于应自动出现在多张幻灯片上的图形（如公司徽标），建议将图片框放置在[slide master](/slides/zh/python-net/slide-master/)或布局上，而不是在每张幻灯片中添加等效形状。

## **将图像用作幻灯片背景**

背景图像被分配给幻灯片填充，而不是作为图片框形状添加。当图片需要覆盖整个幻灯片背景且不应像普通幻灯片对象那样被操作时，这种方式很有用。

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

有关更多背景选项（包括母版和布局背景），请参阅[Presentation Background](/slides/zh/python-net/presentation-background/)。

## **嵌入图像和链接图像**

嵌入图像和链接图像在可移植性和文件大小方面各有利弊：

- **嵌入图像**：图像数据存储在演示文稿内部。演示文稿是自包含的，但文件大小会包括图像数据。
- **链接图像**：演示文稿存储外部图像的路径或 URL。可以减小演示文稿大小，但在打开或渲染时必须能够访问外部资源。

可以通过为[ISlidesPicture.link_path_long](https://reference.aspose.com/slides/zh/python-net/aspose.slides/islidespicture/link_path_long/)分配外部路径或 URL 来创建链接图片，而不是嵌入图像数据。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

仅在部署环境能够可靠访问外部资源时使用链接图像。对于必须离线使用或在系统之间移动的演示文稿，嵌入图像通常更安全。

## **使用 SVG 图像**

SVG 是矢量格式，适合用于图标、图表和其他应在放大时保持细节的图形。Aspose.Slides 同时支持将 SVG 作为图像资源以及作为可编辑幻灯片形状的来源。

### **将 SVG 添加为图像**

创建[SvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/)，将其添加到图像集合，并在图片框中放置得到的图像资源。

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **将 SVG 转换为可编辑形状**

Aspose.Slides 可以将 SVG 转换为一组可编辑的幻灯片形状，类似于 PowerPoint 对应的命令。

![PowerPoint Popup Menu](img_01_01.png)

使用接受[ISvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/isvgimage/)的[ShapeCollection.add_group_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_group_shape/)重载来执行转换。

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

当需要对单个矢量元素进行编辑时使用 SVG 到形状的转换。如果仅需显示 SVG，保留为图像更简单，并可避免创建大量独立形状。

## **替换现有图像资源**

当需要替换已有图像资源时使用[IPPImage.replace_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ippimage/replace_image/)。这在共享图形（例如徽标）特别有用。

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

如果多个图片框、背景、母版或布局使用相同的图像资源，替换该资源会更新所有这些使用。如果仅需更改一个图片框，请为该框分配不同的图像，而不是替换共享资源。

`replace_image` 还提供接受[IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/)或其他[IPPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ippimage/)的重载。

## **实际图像管理指南**

### **控制演示文稿大小**

大型光栅图像会导致演示文稿体积过大。使用适合目标显示尺寸的源图像，尽可能复用共享图像资源，避免嵌入相同全分辨率图形的多个副本。

对于已经放置在图片框中的光栅图片，可使用[PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picturefillformat/compress_image/)根据所选分辨率和裁剪设置压缩图像数据。这属于图片框处理而非图像集合管理，请参阅[Picture Frame](/slides/zh/python-net/picture-frame/)了解相关格式操作。

### **在嵌入和链接内容之间做选择**

嵌入使演示文稿便携，因为所有必要的图像数据随文件一起移动。链接可以减小文件大小，但会引入外部依赖。仅在该依赖可接受且可靠时使用链接。

### **重用共享品牌标识**

对于重复出现的徽标、水印或装饰性图形，使用单一图像资源并复用它。如果图形属于演示文稿设计而非幻灯片内容，请将其放在母版或布局上，以便相应幻灯片继承。

### **保持 SVG 资源可移植性**

自包含的 SVG 更易于移动和一致渲染，胜于依赖外部文件或网络资源的 SVG。尽可能在导入 SVG 前嵌入所需资源。仅在需要编辑单个矢量元素时才将 SVG 转换为形状。

### **使用现代跨平台图像 API**

对于新的 Python via .NET 代码，请使用 Aspose.Slides 的[IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/)和[Images](https://reference.aspose.com/slides/zh/python-net/aspose.slides/images/) API，代替已弃用的`aspose.pydrawing.Image`或`aspose.pydrawing.Bitmap`图像 API。迁移指南请参阅[Modern API](/slides/zh/python-net/modern-api/)。

WMF 和 EMF 需要特殊处理。当这些格式通过[IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/)传递时，[ImageCollection.add_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/add_image/) 会先将元文件转换为光栅 PNG 再插入。如果需要保留元文件数据，请改用基于流的[ImageCollection.add_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/add_image/) 重载。通过电子表格或其他产品生成 EMF 内容属于独立的集成工作流，超出本文范围。

## **常见问题**

**图像集合和图片框有什么区别？**

图像集合存储可重用的图像资源。图片框是显示这些资源的幻灯片形状，并提供裁剪、效果等图片特定的格式设置。

**如何在所有位置统一替换同一个徽标？**

如果徽标已经作为单一图像资源共享，使用[IPPImage.replace_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ippimage/replace_image/) 替换该资源。要在演示文稿范围内统一品牌标识，也可以将徽标放在母版或布局上，从而减少重复的幻灯片内容。

**为什么链接图像在另一台电脑上消失？**

链接图片依赖外部文件或 URL。如果在另一台电脑上无法访问该资源，链接图像将不可用。需要自包含演示文稿时请嵌入图像。

**插入的 SVG 能否编辑为 PowerPoint 形状？**

可以。使用[ShapeCollection.add_group_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_group_shape/) 将 SVG 转换；生成的组包含可编辑的幻灯片形状，而不是单一的 SVG 图片。

**如何在大量图像的演示文稿中保持体积较小？**

复用共享图像资源，避免使用不必要的大尺寸光栅源，适时压缩合适的光栅图片，将重复的品牌标识放在母版或布局上，仅在外部依赖可接受时使用链接图像。