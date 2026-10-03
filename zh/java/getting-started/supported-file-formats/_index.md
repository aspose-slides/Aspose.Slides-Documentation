---
title: 受支持的文件格式
type: docs
weight: 106
url: /zh/java/supported-file-formats/
keywords:
- 受支持的文件格式
- 加载演示文稿
- 导入 PDF
- 导入 HTML
- 保存演示文稿
- 呈现幻灯片
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
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 能加载、导入、保存和呈现的文件格式，以及对应的 API 读取或写入每种格式。"
---
## **概述**

Aspose.Slides for Java 可打开并保存 PowerPoint 和 OpenDocument 演示文稿。它还可以将 PDF 和 HTML 内容导入到幻灯片中，将演示文稿保存为文档、网络和图像格式，并将单个幻灯片和形状渲染为图像。本文列出每种支持的格式并标明读取或写入该格式的 API。

有关编辑功能的概览，请参阅 [编辑功能概览](/slides/zh/java/features-overview/)。

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
- Microsoft 365 的 PowerPoint（原 Office 365）

{{% alert color="info" title="Note" %}}
PowerPoint 95 及更早版本保存的演示文稿无法打开。 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 能识别 PowerPoint 95 文件并报告 `LoadFormat.Ppt95`，但 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 构造函数会抛出 [PptUnsupportedFormatException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptunsupportedformatexception/)。
{{% /alert %}}

## **受支持的文件格式**

表格使用四种操作：

- **Load**： [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 构造函数将文件作为可编辑演示文稿打开。
- **Import**： [SlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slidecollection/) 方法从文件内容创建幻灯片并添加到现有演示文稿。Presentation 构造函数不会将这些文件转换为幻灯片。
- **Save**： [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 将演示文稿写入文件或流。除 XAML 外的每种格式均通过 [SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/) 值选择。
- **Render**： 渲染方法将幻灯片或形状绘制为图像。仅渲染的格式不是 SaveFormat 值。

|**格式**|**描述**|**加载 / 导入**|**保存 / 呈现**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 演示文稿|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 模板|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 幻灯片放映|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 演示文稿|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 模板|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 幻灯片放映|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 宏启用演示文稿|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 宏启用模板|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 宏启用幻灯片放映|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 演示文稿|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument 演示文稿|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 演示文稿模板|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 演示文稿|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|可移植文档格式|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|超文本标记语言|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 纸张规范|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|标记图像文件格式|—|Save, Render|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|图形交换格式|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型网页格式（Flash）|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|可扩展应用程序标记语言|—|Save|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|便携式网络图形|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG 图像|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|位图图像|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|增强型图元文件|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可缩放矢量图形|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **加载和导入**

- **Load:** 将文件路径或流传递给 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 构造函数。格式会从内容中检测；[LoadOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/) 提供密码等设置。要在打开文件前检查文件，请调用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)，它报告一个 [LoadFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadformat/) 值。对于 PowerPoint XML 会报告 `LoadFormat.Unknown`，但构造函数仍能打开该文件，随后 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSourceFormat--) 返回 `SourceFormat.Xml`。参见 [打开演示文稿](/slides/zh/java/open-presentation/) 和 [确定原始演示文稿格式](/slides/zh/java/detect-presentation-source-format/)。
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) 为每个 PDF 页面在演示文稿末尾添加一张幻灯片。[SlideCollection.addFromHtml](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) 添加由 HTML 创建的幻灯片，且 [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) 可在指定位置插入它们。Presentation 构造函数不会导入：对 PDF 文件会抛出 [PptUnsupportedFormatException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptunsupportedformatexception/)，对 HTML 标记也不会转换为幻灯片内容。参见 [从 PDF 或 HTML 导入演示文稿](/slides/zh/java/import-presentation/)。

## **保存和呈现**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 按照 [SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/) 值将演示文稿写入文件。接受选项对象的重载可控制输出，例如 [PdfOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/)、[Html5Options](https://reference.aspose.com/slides/zh/java/com.aspose.slides/html5options/)、[TiffOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tiffoptions/)、[GifOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/gifoptions/)。接受幻灯片位置数组（从 1 开始）的重载仅写入指定幻灯片；它们支持 PDF、XPS、TIFF、HTML、HTML5、SWF、GIF 和 Markdown，但不支持演示文稿格式或 PowerPoint XML。XAML 有其专用重载 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)，接受 [IXamlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloptions/)。参见 [保存演示文稿](/slides/zh/java/save-presentation/)、[转换演示文稿](/slides/zh/java/convert-presentation/) 和 [导出演示文稿为 XAML](/slides/zh/java/export-to-xaml/)。
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#getImage-float-float-) 和 [Shape.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getImage--) 返回一个 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/)，[IImage.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 可将其保存为 PNG、JPEG、BMP、GIF 或 TIFF，使用 [ImageFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imageformat/) 值选择。[Presentation.getImages](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) 一次渲染全部或选定的幻灯片。[Slide.writeAsSvg](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) 与 [Shape.writeAsSvg](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) 写入 SVG，[Slide.writeAsEmf](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) 写入 EMF。参见 [将演示文稿幻灯片转换为图像](/slides/zh/java/convert-slide/) 和 [将演示文稿幻灯片渲染为 SVG 图像](/slides/zh/java/render-a-slide-as-an-svg-image/)。

{{% alert color="warning" title="Warning" %}}
ImageFormat 还具有 `Emf`、`Wmf`、`Icon`、`Exif` 和 `MemoryBmp` 值，但 IImage.save 并不生成这些格式：它写入的文件包含 PNG 数据。若需获取幻灯片的 EMF 图像，请使用 Slide.writeAsEmf。
{{% /alert %}}

## **常见问题**

**我能将 PPT 演示文稿转换为 PPTX 或 ODP 吗？**

可以。使用 Presentation 构造函数打开 PPT 文件，然后使用 `SaveFormat.Pptx` 或 `SaveFormat.Odp` 保存。参见 [将 PPT 转换为 PPTX](/slides/zh/java/convert-ppt-to-pptx/)。

**我能将 PDF 或 HTML 文件作为演示文稿打开吗？**

不能。Presentation 构造函数对 PDF 文件会抛出 PptUnsupportedFormatException，且不会将 HTML 标记转换为幻灯片。请创建或打开一个演示文稿，使用上文描述的幻灯片集合方法将 PDF 页面或 HTML 内容导入，然后保存为任意受支持的格式。

**我能将导出的 PNG 或 SVG 图像加载为可编辑的演示文稿吗？**

不能。图像输出只记录幻灯片的外观，而不包含文本、形状或图表。如果需要以后编辑，请保留源演示文稿。

**我能保存 PDF/A 或 PDF/UA 文档吗？**

可以。将 [PdfCompliance](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pdfcompliance/) 值传递给 [PdfOptions.setCompliance](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pdfoptions/#setCompliance-int-)，支持 PDF/A-1a、PDF/A-1b、PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 或 PDF/UA。

**我能在打开文件前检查其是否受密码保护吗？**

可以。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 在不创建 Presentation 对象的情况下检查文件，而 [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) 报告是否需要密码。参见 [演示文稿密码保护](/slides/zh/java/password-protected-presentation/)。