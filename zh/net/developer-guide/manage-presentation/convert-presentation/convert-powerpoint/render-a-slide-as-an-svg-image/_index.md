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
description: ".NET 中将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本、图像、ID 和事件。"
---
## **概述**

SVG 是一种可伸缩的基于 XML 的图像格式，适用于网页发布、幻灯片查看器、可访问性工作流以及自动化后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

使用 [SVGOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/) 当导出的 SVG 必须紧凑、在各浏览器之间表现一致，或准备好用于交互时。

## **导出幻灯片为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)，选择一张幻灯片，并将其写入流。下面的示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

文件名使用 [ISlide.SlideNumber](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/slidenumber/) 而不是循环索引。若幻灯片查看器或网页仅需要某个形状，也可以使用 [IShape.WriteAsSvg](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/writeassvg/) 导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.UseFrameSize](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/useframesize/) 将文本框包含在渲染区域内，而 [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/useframerotation/) 决定是否应用框的旋转。将 [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/disablefontligatures/) 设置为 `true` 可在需要时不使用连字渲染文本。

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

## **控制文本和字体**

### **矢量化全部文本**

将 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/vectorizetext/) 设置为 `true` 可将所有幻灯片文本写为矢量图形。这消除了对字体的依赖，使视觉效果在各浏览器之间更一致，但文本将不再可作为 SVG 文本选择或搜索。

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

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/externalfontshandling/) 使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgexternalfontshandling/) 的值来处理外部加载的字体。选择 `AddLinksToFontFiles` 以引用单独的字体文件，`Embed` 将字体数据嵌入 SVG，或 `Vectorize` 将仅使用外部字体的文本渲染为图形。嵌入字体前请确认字体许可。

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

使用 [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/picturescompression/) 降低嵌入图片的分辨率，使用 [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) 省略裁剪的源区域，并通过 [SVGOptions.JpegQuality](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/jpegquality/) 控制 JPEG 编码质量。这些设置会在降低文件大小的同时牺牲图像保真度或保留的图像数据。

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

## **为形状和文本分配稳定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/isvgshapeformattingcontroller/) 为每个 SVG 形状设置 [ISvgShape.Id](https://reference.aspose.com/slides/zh/net/aspose.slides.export/isvgshape/id/)。若还需为文本 `tspan` 元素设置 [ISvgTSpan.Id](https://reference.aspose.com/slides/zh/net/aspose.slides.export/isvgtspan/id/) 值，请实现 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/isvgshapeandtextformattingcontroller/)。通过 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) 分配任一控制器。

以下控制器使用 [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/officeinteropshapeid/)，该 ID 在形状生命周期内是稳定的，并为其文本跨度使用可重复的计数器。这使生成的 ID 适用于对未更改的演示文稿进行后处理。

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

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/isvgshapeformattingcontroller/) 中，调用 [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/zh/net/aspose.slides.export/isvgshape/seteventhandler/) 并传入 [SvgEvent](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgevent/) 值，可为导出的形状添加 JavaScript 事件处理程序。通过 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) 分配该控制器，并在承载结果的页面或 SVG 文档中定义相应的 JavaScript 函数。

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

宿主页面可以定义由处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可实现幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流。

## **常见问题**

**何时应使用 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/vectorizetext/) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgexternalfontshandling/)?**

当所有文本必须独立于字体时使用 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/vectorizetext/)。仅当需要将使用外部字体的文本转换为图形时，才使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgexternalfontshandling/)。

**使 SVG 更小的最佳方法是什么？**

首先压缩嵌入的图片、删除裁剪的图像区域，并在目标环境能够提供时选择链接的字体文件。需要测试结果，因为降低图片分辨率、降低 JPEG 质量以及矢量化文本各自对质量和体积有不同的权衡。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化控制器分配 ID，然后在后处理工具或浏览器脚本中选择相应的 SVG 元素进行修改。