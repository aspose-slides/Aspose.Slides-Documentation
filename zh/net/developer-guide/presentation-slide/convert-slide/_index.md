---
title: 在 .NET 中将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 41
url: /zh/net/convert-slide/
keywords:
- 转换幻灯片
- 导出幻灯片
- 幻灯片转图像
- 将幻灯片保存为图像
- 幻灯片转 EMF
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中将 PPT、PPTX 和 ODP 演示文稿的幻灯片转换为 PNG、JPEG、GIF、TIFF、EMF 等图像格式。"
---
## **简介**

Aspose.Slides for .NET 可以将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片渲染为 PNG、JPEG、GIF、TIFF 等图像格式。

将幻灯片转换为图像，请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类加载演示文稿。
2. 选择要渲染的幻灯片。
3. 如有必要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/) 类进行渲染配置。
4. 调用 [GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/) 方法。该方法返回一个 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 对象。
5. 调用 [IImage.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/save/) 方法，并使用 [ImageFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/) 值指定输出格式。

## **将幻灯片转换为 PNG 图像**

最简的转换使用默认渲染设置。生成的 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 对象可以在内存中处理或保存为文件。

下面的 C# 示例渲染第一张幻灯片并将其保存为 PNG 图像：

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **使用自定义尺寸将幻灯片转换为图像**

使用接受 [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) 参数的 [GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/) 重载，可按精确像素尺寸渲染幻灯片。

下面的示例创建一个 1820 × 1040 的 JPEG 图像：

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **将带有备注和批注的幻灯片转换为图像**

默认情况下，幻灯片图像不包含备注或批注。将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/notescommentslayoutingoptions/) 对象分配给 [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) 属性，可控制备注和批注的显示位置。

下面的示例将在幻灯片下方放置截断的备注，并在右侧放置批注：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
对于幻灯片转图像的转换，请勿将 [NotesPosition](https://reference.aspose.com/slides/zh/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) 属性设置为 [BottomFull](https://reference.aspose.com/slides/zh/net/aspose.slides.export/notespositions/)。备注的文字可能超出固定图像尺寸。请改用 [BottomTruncated](https://reference.aspose.com/slides/zh/net/aspose.slides.export/notespositions/)。
{{% /alert %}}

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/) 类允许您控制渲染的 TIFF 图像的尺寸、分辨率等属性。

下面的示例将第一张幻灯片渲染为 2160 × 2880、300 DPI 的 TIFF 图像：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **将所有幻灯片转换为图像**

遍历幻灯片集合，可将整个演示文稿转换为一系列图像。除非显式跳过，否则隐藏的幻灯片也会被包含。

下面的示例以水平和垂直缩放系数 2 将每张幻灯片渲染为 JPEG 图像：

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **创建增强型图元文件（EMF）输出**

增强型图元文件（EMF）在需要与 Microsoft Office 或其他支持 Windows 图元文件的 Windows 应用程序交换矢量图形时非常有用。与基于像素的图像不同，EMF 可以保留可在不损失清晰度的情况下缩放的矢量绘图操作。但 EMF 主要是面向具备 Windows 图元文件支持的应用程序的兼容格式，而非通用交换格式。此外，复杂的幻灯片内容（如位图图像和某些效果）可能会以光栅化元素的形式存储在矢量图元文件容器中。

### **将幻灯片导出为 EMF**

[ISlide.WriteAsEmf](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/writeasemf/) 方法将 [ISlide](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/) 写入目标流，以 EMF 格式保存。下面的示例加载演示文稿，选择第一张幻灯片，并将其写入 EMF 文件流：

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

调用方拥有传递给 [ISlide.WriteAsEmf](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/writeasemf/) 的流，并应在使用后关闭或释放它。Aspose.Slides 在流的当前位址写入数据并保持流打开状态。

### **将 SVG 图像转换为 EMF 并添加到演示文稿中**

使用 [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/writeasemf/) 将 SVG 内容转换为 EMF。生成的字节可以通过 [IImageCollection.AddImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimagecollection/addimage/) 添加到演示文稿，并使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addpictureframe/) 放置在幻灯片上。

下面的示例从 SVG 标记创建一个 [SvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/svgimage/)，将其转换为内存中的 EMF，将该图元文件插入第一张幻灯片，并保存演示文稿：

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/writeasemf/) 不会获取目标流的所有权。写入后，流位置位于生成数据的末尾。请在将同一可寻址流传递给读取器之前，将 `Position` 重置到起始位置，如上例所示。保持流打开直至消费者完成读取，然后再释放它。或者调用 `ToArray`，将返回的字节数组传递给 [IImageCollection.AddImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimagecollection/addimage/)；`ToArray` 会返回完整缓冲区，不受当前流位置影响。

EMF 生成可在所选 Aspose.Slides for .NET 构建支持的操作系统上使用，但在字体或本机图形依赖不可用的情况下，不同平台的渲染可能会有所差异。请安装源内容所使用的字体或配置合适的替代方案，遵循针对您的 Aspose.Slides 包的 [platform requirements](/slides/zh/net/system-requirements/)，并在目标 EMF 消费应用中验证结果。Linux 和 macOS 应用对 Windows 图元文件的显示和编辑支持通常有限或不一致。

## **彩色表情符号渲染**

{{% alert title="Note" color="info" %}}
要在将演示文稿幻灯片转换为图像时正确渲染彩色表情符号，必须在执行转换的系统上安装并可用演示文稿中使用的表情符号字体。例如，若演示文稿使用 **Segoe UI Emoji**，但系统缺少该字体，则输出图像中的表情符号可能会以单色方式显示。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持渲染带动画的幻灯片？**

不支持。[GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/) 方法渲染幻灯片的静态图像，不会导出动画。

**是否可以将隐藏的幻灯片导出为图像？**

可以。隐藏的幻灯片可以像普通幻灯片一样渲染。请在处理循环中包含它们，如上例所示。

**幻灯片图像是否保留阴影和其他效果？**

会保留。Aspose.Slides 在幻灯片图像中渲染阴影、透明度以及其他受支持的图形效果。