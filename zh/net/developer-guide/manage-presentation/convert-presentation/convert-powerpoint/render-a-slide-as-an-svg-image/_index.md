---
title: 在 .NET 中将演示文稿幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿转 SVG
- 幻灯片转 SVG
- PPT 转 SVG
- PPTX 转 SVG
- SVG 导出选项
- 交互式 SVG
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本、图像、ID 和事件。"
---
## **概述**

SVG 是一种可伸缩的基于 XML 的图像格式，适用于 Web 发布、幻灯片查看器、可访问性工作流以及自动化后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在各浏览器中保持可预测，或准备好进行交互使用时，请使用 [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，选择幻灯片并将其写入流。下面的示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

文件名使用 [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) 而不是循环索引。当幻灯片查看器或网页仅需要该形状时，您也可以使用 [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) 导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) 将文本框包含在渲染区域中，[SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) 决定是否应用框的旋转。当文本必须在不使用连字的情况下渲染时，将 [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) 设置为 `true`。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **控制箭头端点的线段裁剪**

SVG 1.1 没有标记插入设置来指定线条在箭头下方应停止的位置。默认情况下，Aspose.Slides 会缩短导出的线条，使其笔画不会突出标记。将 [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) 设置为 `true` 可将笔画绘制到线条的原始端点。此设置仅影响 SVG 输出。线条在幻灯片上的位置和长度保持不变。

示例在宽度为 2 点和 10 点的线条上绘制三角形和菱形箭头。它导出同一幻灯片两次，仅更改裁剪选项。

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

比较显示了 10 点线条上的三角形箭头。启用裁剪时，尖端锐利。禁用裁剪时，笔画会穿过标记的倾斜侧面，留下平坦的末端。

![裁剪启用时尖锐、裁剪禁用时平坦的放大 10 点三角形](line-end-cropping.png)

在示例的其他线条中，2 点三角形的突出笔画不太明显。实心菱形在两种宽度下都覆盖了笔画的末端。

## **控制文本和字体**

在将幻灯片导出为 SVG 时，您可以控制文本是保持为文本还是转换为矢量图形，以及外部字体的包含或引用方式。以下选项帮助您在导出 SVG 时平衡视觉一致性、文本选择和字体依赖性。

### **将所有文本矢量化**

将 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) 设置为 `true`，可将所有幻灯片文本写为矢量图形。这消除了字体依赖，使视觉结果在各浏览器之间更一致，但文本将不再可作为 SVG 文本进行选择或搜索。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **选择外部字体的处理方式**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) 对外部加载的字体使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) 值。选择 `AddLinksToFontFiles` 以引用单独的字体文件，`Embed` 以在 SVG 中嵌入字体数据，或 `Vectorize` 将仅使用外部字体的文本渲染为图形。嵌入字体前请确认字体许可。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **降低嵌入图像大小**

使用 [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) 降低嵌入图片的分辨率，使用 [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) 省略裁剪后的源区域，并使用 [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) 控制 JPEG 编码质量。这些设置会以图像保真度或保留图像数据为代价来减小文件大小。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **控制元文件光栅化分辨率**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) 设置在 SVG 导出期间对元文件进行光栅化的最低分辨率限制。使用它在对 EMF 或 WMF 图像进行光栅化时平衡细节和文件大小。它并未为 SVG 定义全局 DPI，也不会强制幻灯片上的每个对象都变为光栅图像。

下载 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含具有紧密间隔对角线的 EMF 图像。以下示例通过 [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) 将其第一张幻灯片以三种光栅化分辨率导出。所有其他导出设置保持相同，以便进行比较。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

在输出中，EMF 在每个 SVG 中都变成了一个嵌入的 PNG。以下度量针对提供的演示文稿；它们不是将 DPI 转换为像素尺寸的一般公式。

| 元文件光栅化 DPI | 嵌入 PNG 尺寸 | SVG 文件大小（字节） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下面的比较显示了在相同放大显示尺寸下嵌入光栅的相同区域。对角线在 72 DPI 时出现明显的像素化，而在更高分辨率下边缘更平滑，同时 SVG 文件体积增大。提升该值并不一定能改善每个细节或更改每个导出图像。

![放大 72、150、300 DPI 对角线细节](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) 控制图像分辨率降低，可能会掩盖更改元文件光栅化分辨率的效果。[SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) 控制 JPEG 编码质量，而非元文件光栅化分辨率。

## **为形状和文本分配稳定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) 为每个 SVG 形状设置 [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/)。若要在文本 `tspan` 元素上也设置 [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/)，请实现 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/)。通过 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) 分配任一控制器。

以下控制器使用 [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/)，该 ID 在形状的整个生命周期内保持稳定，并为其文本跨度使用可重复的计数器。这使生成的 ID 适用于对未更改的演示文稿进行后处理。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **添加 SVG 事件处理程序**

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) 中，使用 [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) 并传入 [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) 值，以向导出的形状添加 JavaScript 事件处理程序。通过 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) 分配该控制器，并在承载结果的页面或 SVG 文档中定义 JavaScript 函数。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

宿主页面可以定义处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可实现幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流。

## **常见问题**

**何时应使用 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

当所有文本必须独立于字体时，请使用 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/)。当仅需要将使用外部字体的文本转换为图形时，请使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)。

**怎样才能让 SVG 更小？**

首先压缩嵌入的图片，删除裁剪的图像区域，并在目标环境能够提供时选择链接的字体文件。对结果进行测试，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本各自都有不同的质量与大小权衡。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化控制器分配 ID，然后在后处理工具或浏览器脚本中选择相应的 SVG 元素。