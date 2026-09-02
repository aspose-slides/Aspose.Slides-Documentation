---
title: 在 .NET 中优化演示文稿的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/net/image/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中添加、复用、链接、替换和管理光栅图像以及 SVG 图像。"
---
## **简介**

Aspose.Slides for .NET 提供了多种处理图像的方式，每种方式都有不同的用途。您可以将图像存储在演示文稿中，在图片框中显示它，将其用作幻灯片背景，链接到外部图像，替换共享的图像资源，或将 SVG 内容转换为可编辑的形状。

本文聚焦于图像资源及其在整个演示文稿中的使用方式。有关对单个图片框进行裁剪、透明度、效果、拉伸以及其他格式设置，请参阅[Picture Frame](/slides/zh/net/picture-frame/)。

## **了解图像模型**

以下 API 概念密切相关，但不可互换：

- [演示文稿图像集合](https://reference.aspose.com/slides/zh/net/aspose.slides/iimagecollection/) 存储演示文稿使用的图像资源。使用[ImageCollection.AddImage](https://reference.aspose.com/slides/zh/net/aspose.slides/imagecollection/addimage/) 添加图像数据并获取[IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/)资源。
- [图片框](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 是在幻灯片、布局或母版上显示图像的形状。使用[IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addpictureframe/) 将图像资源放置到幻灯片上。
- 幻灯片背景将图像用作幻灯片填充的一部分，而不是作为形状。因此其行为不同于图片框。
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/replaceimage/) 替换图像资源。如果多个演示文稿元素使用该资源，全部都会使用替换后的图像。
- 将 SVG 转换为形状会创建可编辑的幻灯片形状。转换后，内容不再作为单个图片资源进行管理。

因此典型的工作流是：将图像数据添加到图像集合，获取一个[IPPImage]，然后在一个或多个图片框或填充中使用该资源。

## **添加嵌入式图像**

要插入本地图像，读取文件，将其数据添加到图像集合，并创建使用返回的`IPPImage`的图片框。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

以这种方式添加的图像会嵌入到演示文稿中，因此生成的文件不依赖于原始图像文件的可用性。

### **从网络添加图像**

当图像可通过 HTTP 或 HTTPS 获取时，使用`HttpClient`下载其字节，将它们添加到演示文稿图像集合，并以与本地图像相同的方式使用返回的图像资源。

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

在长期运行的应用程序中，应复用`HttpClient`而不是为每个请求创建新实例。当源不可信时，还应验证远程 URL、响应大小和内容类型。

## **在幻灯片之间复用图像**

如果同一图像需要使用多次，请仅在演示文稿中添加一次，并在创建其他图片框时复用返回的[IPPImage]。这样可避免反复加载相同的源数据，并明确共享图像资源与其使用之间的关系。

对于需要在许多幻灯片上自动出现的图形（例如公司徽标），建议将图片框放置在[slide master](/slides/zh/net/slide-master/)或布局上，而不是在每张幻灯片中单独添加相同的形状。

## **将图像用作幻灯片背景**

背景图像被分配给幻灯片填充；它不是作为图片框形状添加的。当图片需要覆盖幻灯片背景且不应像普通幻灯片对象那样被操作时，这种方式非常有用。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

有关更多背景选项（包括母版和布局背景），请参阅[Presentation Background](/slides/zh/net/presentation-background/)。

## **嵌入式图像与链接图像**

嵌入式和链接图像在可移植性和文件大小上各有利弊：

- **嵌入式图像：** 图像数据存储在演示文稿内部。演示文稿是自包含的，但文件大小会包含图像数据。
- **链接图像：** 演示文稿存储外部图像的路径或 URL。可以减小演示文稿大小，但在打开或渲染演示文稿时必须能够访问外部资源。

可以通过为[ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/zh/net/aspose.slides/islidespicture/linkpathlong/)分配外部路径或 URL 来创建链接图片，而不是嵌入图像数据。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

仅在部署环境能够可靠访问外部资源时才使用链接图像。对于必须离线使用或在系统间迁移的演示文稿，通常使用嵌入式图像更安全。

## **处理 SVG 图像**

SVG 是矢量格式，适用于图标、图表以及其他需要在不失细节的情况下缩放的图形。Aspose.Slides 同时支持将 SVG 作为图像资源和可编辑幻灯片形状的来源。

### **将 SVG 添加为图像**

创建一个[SvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/svgimage/)，将其添加到图像集合，并在图片框中放置得到的图像资源。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **带外部资源的 SVG 文件**

SVG 可以引用外部图像、样式表或字体。针对这些情况，[SvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/svgimage/)提供接受[IExternalResourceResolver](https://reference.aspose.com/slides/zh/net/aspose.slides.import/iexternalresourceresolver/)和基 URI 的构造函数。解析器可以将相对 URI 映射到允许的绝对 URI，并返回请求资源的流。

解析器在 Aspose.Slides 处理 SVG 时提供外部资源，但不会将 SVG 重写为自包含文档。如果需要保持 SVG 可移植，请将所需资源嵌入到 SVG 本身，例如使用`data:` URI 来链接图像。

当 SVG 文件来自不可信来源时，应限制解析器可以访问的方案、文件位置和主机。网络解析器还应应用超时、响应大小限制和内容验证。

### **将 SVG 转换为可编辑形状**

Aspose.Slides 可以将 SVG 转换为一组可编辑的幻灯片形状，类似于对应的 PowerPoint 命令。

![PowerPoint 弹出菜单](img_01_01.png)

使用接受[ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/)的[IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addgroupshape/)重载来执行转换。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

当需要将单个矢量元素编辑为 PowerPoint 形状时，请使用 SVG 转形状的转换。如果 SVG 仅用于显示，保持为图像更简单，也可以避免创建大量独立形状。

## **替换现有图像资源**

当需要替换现有图像资源时，请使用[IPPImage.ReplaceImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/replaceimage/)。这在替换共享图形（如徽标）时特别有用。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

如果多个图片框、背景、母版或布局使用同一图像资源，替换该资源会更新所有使用处。如果仅需更改单个图片框，请为该框分配不同的图像，而不是替换共享资源。

`ReplaceImage` 还提供接受[IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)或另一个[IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/)的重载。

## **实用图像管理指南**

### **控制演示文稿大小**

大尺寸光栅图像会导致演示文稿体积不必要地增大。使用尺寸适合实际展示需求的源图像，尽可能复用共享图像资源，并避免嵌入多份相同的全分辨率图形。

对于已经放入图片框的光栅图片，可使用[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/compressimage/)根据选定的分辨率和裁剪设置压缩图像数据。这属于图片框处理，而非图像集合管理，相关格式化操作请参见[Picture Frame](/slides/zh/net/picture-frame/)。

### **在嵌入和链接内容之间做选择**

嵌入使演示文稿可移植，因为所有必需的图像数据随文件一起携带。链接可以减小文件大小，但会引入外部依赖。仅在该依赖可接受且可靠时才使用链接。

### **复用共享品牌元素**

对于重复出现的徽标、水印或装饰图形，使用单一图像资源并复用它。如果该图形属于演示文稿设计而非幻灯片内容，请将其放置在母版或布局上，以便被相应幻灯片继承。

### **保持 SVG 资源可移植**

自包含的 SVG 比依赖外部文件或网络资源的 SVG 更易移动且渲染一致。尽可能在导入 SVG 前将所需资源嵌入其中。只有在必须编辑单个矢量元素时才将 SVG 转换为形状。

### **使用现代跨平台图像 API**

对于新的 .NET 代码，建议使用 Aspose.Slides 的[IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)和[Images](https://reference.aspose.com/slides/zh/net/aspose.slides/images/) API，而不是依赖`System.Drawing.Image`或`Bitmap`。迁移指南请参阅[Modern API](/slides/zh/net/modern-api/)。

WMF 和 EMF 需要特殊处理。当这些格式通过[IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)传递时，[ImageCollection.AddImage](https://reference.aspose.com/slides/zh/net/aspose.slides/imagecollection/addimage/) 会在插入前将元文件转换为光栅 PNG。如果必须保留元文件数据，请改用基于流的[ImageCollection.AddImage](https://reference.aspose.com/slides/zh/net/aspose.slides/imagecollection/addimage/)重载。通过电子表格或其他产品生成 EMF 内容属于单独的集成工作流，超出本文范围。

## **常见问题解答**

**图像集合和图片框之间有什么区别？**

图像集合存储可重用的图像资源。图片框是显示这些资源的幻灯片形状，并提供裁剪、效果等针对图片的格式设置。

**如何一次性替换所有相同的徽标？**

如果徽标已作为单一图像资源共享，使用[IPPImage.ReplaceImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/replaceimage/)替换该资源。对于全局品牌标识，也可以将徽标放在母版或布局上，从而减少重复的幻灯片内容。

**为什么链接图像在另一台电脑上消失？**

链接图片依赖其外部文件或 URL。如果在另一台电脑上无法访问该资源，链接图像就会不可用。需要自包含演示文稿时，请嵌入图像。

**插入的 SVG 能否编辑为 PowerPoint 形状？**

可以。使用[IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addgroupshape/)将 SVG 转换；转换后得到的组包含可编辑的幻灯片形状，而不是单一的 SVG 图片。

**怎样才能让包含大量图像的演示文稿保持更小？**

复用共享图像资源，避免使用不必要的大尺寸光栅源，在适当情况下压缩光栅图片，将重复的品牌元素放在母版或布局上，并仅在外部依赖可接受时使用链接图像。