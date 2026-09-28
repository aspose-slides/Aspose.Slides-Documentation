---
title: 受支持的文件格式
type: docs
weight: 96
url: /zh/net/supported-file-formats/
keywords:
- 受支持的文件格式
- 加载演示文稿
- 导入 PDF
- 导入 HTML
- 保存演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "查看 Aspose.Slides for .NET 能够加载、导入、保存和渲染哪些文件格式，以及哪个 API 读取或写入每种格式。"
---
## **概述**

Aspose.Slides for .NET 可以打开和保存 PowerPoint 和 OpenDocument 演示文稿。它还可以将 PDF 和 HTML 内容导入到幻灯片中，将演示文稿保存为文档、网页和图像格式，并将单个幻灯片和形状渲染为图像。本文列出了每种受支持的格式，并给出读取或写入该格式的 API 名称。

Aspose.Slides.NET 和 Aspose.Slides.NET6.CrossPlatform 两个 NuGet 包支持相同的格式；请参阅 [Installation](/slides/zh/net/installation/) 以选择使用哪个。有关编辑功能概览，请参阅 [Features Overview](/slides/zh/net/features-overview/)。

## **受支持的 Microsoft PowerPoint 版本**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}
由 PowerPoint 95 及更早版本保存的演示文稿无法打开。[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/) 能识别 PowerPoint 95 文件并报告 `LoadFormat.Ppt95`，但 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/presentation/) 构造函数会抛出 [PptUnsupportedFormatException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptunsupportedformatexception/)。
{{% /alert %}}

## **受支持的文件格式**

表格使用四种操作：

- **加载**：[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/presentation/) 构造函数将文件作为可编辑的演示文稿打开。可通过 [LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/) 提供密码等设置。要在打开前检查文件，可调用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/)，它会返回一个 [LoadFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/loadformat/) 值。对于 PowerPoint XML 会返回 `LoadFormat.Unknown`，但构造函数仍能打开，并且随后 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sourceformat/) 返回 `SourceFormat.Xml`。参见 [Open Presentations](/slides/zh/net/open-presentation/) 与 [Determine the Original Presentation Format](/slides/zh/net/detect-presentation-source-format/)。
- **导入**：通过 [SlideCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/slidecollection/) 方法从文件内容创建幻灯片并添加到现有演示文稿。Presentation 构造函数不会将这些文件作为演示文稿加载。
- **保存**：[Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 使用 [SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 的值写入演示文稿。带有选项对象的重载可控制输出，例如 [PdfOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/)、[Html5Options](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/)、[TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/)、[GifOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/gifoptions/)。接受幻灯片位置数组（从 1 开始）的重载仅写入指定幻灯片，支持 PDF、XPS、TIFF、HTML、HTML5、SWF、GIF 和 Markdown，但不支持演示文稿格式或 PowerPoint XML。XAML 有单独的重载，接受 [IXamlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/ixamloptions/)。参见 [Save Presentations](/slides/zh/net/save-presentation/)、[Convert Presentations](/slides/zh/net/convert-presentation/) 与 [Export Presentations to XAML](/slides/zh/net/export-to-xaml/)。
- **渲染**：[Slide.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage/) 与 [Shape.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getimage/) 返回一个 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)，[IImage.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/save/) 可将其保存为 PNG、JPEG、BMP、GIF 或 TIFF，使用 [ImageFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/) 的值。 [Presentation.GetImages](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages/) 可一次渲染所有或选定幻灯片。 [Slide.WriteAsSvg](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/writeassvg/) 与 [Shape.WriteAsSvg](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/writeassvg/) 写入 SVG， [Slide.WriteAsEmf](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/writeasemf/) 写入 EMF。参见 [Convert Presentation Slides to Images](/slides/zh/net/convert-slide/) 与 [Render a Slide as an SVG Image](/slides/zh/net/render-a-slide-as-an-svg-image/)。

|**格式**|**描述**|**加载 / 导入**|**保存 / 渲染**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 演示文稿|加载|保存|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 模板|加载|保存|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 幻灯片放映|加载|保存|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 演示文稿|加载|保存|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 模板|加载|保存|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 幻灯片放映|加载|保存|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 含宏演示文稿|加载|保存|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 含宏模板|加载|保存|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 含宏幻灯片放映|加载|保存|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 演示文稿|加载|保存|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument 演示文稿|加载|保存|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 演示文稿模板|加载|保存|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 演示文稿|加载|保存|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|可移植文档格式|导入|保存|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|超文本标记语言|导入|保存|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 纸张规范|—|保存|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|标签图像文件格式|—|保存, 渲染|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|图形交换格式|—|保存, 渲染|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型网络格式（Flash）|—|保存|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|保存|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|可扩展应用程序标记语言|—|保存|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|可移植网络图形|—|渲染|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG 图像|—|渲染|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|位图图像|—|渲染|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|增强型图元文件|—|渲染|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可缩放矢量图形|—|渲染|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **加载和导入**

- **加载**：将文件路径或流传递给 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/presentation/) 构造函数。格式根据内容自动检测；使用 [LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/) 可提供密码等设置。若要在打开前检查文件，请调用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/)，它会报告一个 [LoadFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/loadformat/) 值。对于 PowerPoint XML 会报告 `LoadFormat.Unknown`，但构造函数仍能打开，随后 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sourceformat/) 返回 `SourceFormat.Xml`。参见 [Open Presentations](/slides/zh/net/open-presentation/) 与 [Determine the Original Presentation Format](/slides/zh/net/detect-presentation-source-format/)。
- **导入**：`[SlideCollection.AddFromPdf](https://reference.aspose.com/slides/zh/net/aspose.slides/slidecollection/addfrompdf/)` 为每个 PDF 页添加一张幻灯片到演示文稿末尾。`[SlideCollection.AddFromHtml](https://reference.aspose.com/slides/zh/net/aspose.slides/slidecollection/addfromhtml/)` 添加由 HTML 创建的幻灯片，`[SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/zh/net/aspose.slides/slidecollection/insertfromhtml/)` 将其插入到指定位置。Presentation 构造函数不会导入：对 PDF 文件会抛出 [PptUnsupportedFormatException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptunsupportedformatexception/)，也不会将 HTML 标记转换为幻灯片内容。参见 [Import Presentations from PDF or HTML](/slides/zh/net/import-presentation/)。

## **保存和渲染**

- **保存**：`[Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/)` 使用 [SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 的值写入演示文稿。带有选项对象的重载可控制输出，例如 [PdfOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/)、[Html5Options](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/)、[TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/)、[GifOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/gifoptions/)。接受幻灯片位置数组（从 1 开始）的重载仅写入指定幻灯片，支持 PDF、XPS、TIFF、HTML、HTML5、SWF、GIF 和 Markdown，但不支持演示文稿格式或 PowerPoint XML。XAML 有单独的重载，接受 [IXamlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/ixamloptions/)。参见 [Save Presentations](/slides/zh/net/save-presentation/)、[Convert Presentations](/slides/zh/net/convert-presentation/) 与 [Export Presentations to XAML](/slides/zh/net/export-to-xaml/)。
- **渲染**：`[Slide.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage/)` 与 `[Shape.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getimage/)` 返回一个 `[IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)`，`[IImage.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/save/)` 可将其保存为 PNG、JPEG、BMP、GIF 或 TIFF，使用 `[ImageFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/)` 的值。`[Presentation.GetImages](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages/)` 可一次渲染所有或选定幻灯片。`[Slide.WriteAsSvg](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/writeassvg/)` 与 `[Shape.WriteAsSvg](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/writeassvg/)` 写入 SVG，`[Slide.WriteAsEmf](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/writeasemf/)` 写入 EMF。参见 [Convert Presentation Slides to Images](/slides/zh/net/convert-slide/) 与 [Render a Slide as an SVG Image](/slides/zh/net/render-a-slide-as-an-svg-image/)。

{{% alert color="warning" title="Warning" %}}
ImageFormat 还具有 `Emf`、`Wmf`、`Icon`、`Exif` 和 `MemoryBmp` 值，但 IImage.Save 并不会生成这些格式：它写入的文件包含 PNG 数据。要获取幻灯片的 EMF 图像，请使用 Slide.WriteAsEmf。
{{% /alert %}}

## **常见问题**

**我可以将 PPT 演示文稿转换为 PPTX 或 ODP 吗？**

可以。使用 Presentation 构造函数打开 PPT 文件，然后使用 `SaveFormat.Pptx` 或 `SaveFormat.Odp` 保存。参见 [Convert PPT to PPTX](/slides/zh/net/convert-ppt-to-pptx/)。

**我可以将 PDF 或 HTML 文件作为演示文稿打开吗？**

不能。请创建或打开一个演示文稿，使用上述幻灯片集合方法将 PDF 页面或 HTML 内容导入其中，然后再保存为任意受支持的格式。

**我可以将导出的 PNG 或 SVG 图像加载为可编辑的演示文稿吗？**

不能。图像输出仅记录幻灯片的外观，而不包含文本、形状或图表。如需以后编辑，请保留源演示文稿。

**我可以保存 PDF/A 或 PDF/UA 文档吗？**

可以。将 [PdfOptions.Compliance](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/compliance/) 设置为相应的 [PdfCompliance](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfcompliance/) 值：PDF/A-1a、PDF/A-1b、PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 或 PDF/UA。

**我可以在打开文件之前检查它是否受密码保护吗？**

可以。 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/) 在不创建 Presentation 对象的情况下检查文件，其 [IsPasswordProtected](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/ispasswordprotected/) 属性指示是否需要密码。参见 [Password-Protect Presentations](/slides/zh/net/password-protected-presentation/)。

**这两个 NuGet 包支持不同的格式吗？**

不支持。Aspose.Slides.NET 和 Aspose.Slides.NET6.CrossPlatform 具有相同的 LoadFormat 和 SaveFormat 值，以及相同的导入和渲染方法。它们的区别仅在于运行平台及平台需求；请参阅 [Installation](/slides/zh/net/installation/)。