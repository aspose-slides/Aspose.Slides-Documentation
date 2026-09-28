---
title: Supported File Formats
type: docs
weight: 96
url: /net/supported-file-formats/
keywords:
- supported file formats
- load presentation
- import PDF
- import HTML
- save presentation
- render slides
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
description: "See which file formats Aspose.Slides for .NET can load, import, save, and render, and which API reads or writes each one."
---

## **Overview**

Aspose.Slides for .NET opens and saves PowerPoint and OpenDocument presentations. It also imports PDF and HTML content into slides, saves presentations to document, web, and image formats, and renders individual slides and shapes as images. This article lists each supported format and names the API that reads or writes it.

Both NuGet packages, Aspose.Slides.NET and Aspose.Slides.NET6.CrossPlatform, support the same formats; see [Installation](/slides/net/installation/) to choose between them. For an overview of editing features, see [Features Overview](/slides/net/features-overview/).

## **Supported Microsoft PowerPoint Versions**

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

Presentations saved by PowerPoint 95 and earlier versions cannot be opened. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) recognizes a PowerPoint 95 file and reports `LoadFormat.Ppt95`, but the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor throws [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) for it.

{{% /alert %}}

## **Supported File Formats**

The table uses four operations:

- **Load**: the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor opens the file as an editable presentation.
- **Import**: a [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) method creates slides from the file's content and adds them to an existing presentation. The Presentation constructor does not load these files as presentations.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) writes the presentation to a file or stream. Every format except XAML is selected with a [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) value.
- **Render**: a rendering method draws a slide or a shape as an image. Formats that are only rendered are not SaveFormat values.

|**Format**|**Description**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 Presentation|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 Template|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 Slide Show|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint Presentation|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint Template|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint Slide Show|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint Macro-Enabled Presentation|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint Macro-Enabled Template|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint Macro-Enabled Slide Show|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument Presentation|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument Presentation|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument Presentation Template|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML Presentation|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Load and Import**

- **Load:** Pass a file path or a stream to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor. The format is detected from the content; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) supplies settings such as a password. To check a file before opening it, call [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), which reports a [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/) value. It reports `LoadFormat.Unknown` for PowerPoint XML, but the constructor opens such a file, and [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) then returns `SourceFormat.Xml`. See [Open Presentations](/slides/net/open-presentation/) and [Determine the Original Presentation Format](/slides/net/detect-presentation-source-format/).
- **Import:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) adds one slide per PDF page to the end of a presentation. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) adds slides created from HTML, and [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) inserts them at a given position. The Presentation constructor does not import: it throws [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) for a PDF file and does not convert HTML markup into slide content. See [Import Presentations from PDF or HTML](/slides/net/import-presentation/).

## **Save and Render**

- **Save:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) writes the presentation in the format of a [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) value. Overloads that also take an options object control the output, for example [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), and [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Overloads that take an array of slide positions, starting from 1, write only those slides; they accept PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, and Markdown, but not the presentation formats or PowerPoint XML. XAML has its own overload that takes [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). See [Save Presentations](/slides/net/save-presentation/), [Convert Presentations](/slides/net/convert-presentation/), and [Export Presentations to XAML](/slides/net/export-to-xaml/).
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) and [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) return an [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), and [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) writes it as PNG, JPEG, BMP, GIF, or TIFF, selected with an [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) value. [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) renders all slides or selected slides at once. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) and [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) write SVG, and [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) writes EMF. See [Convert Presentation Slides to Images](/slides/net/convert-slide/) and [Render a Slide as an SVG Image](/slides/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat also has `Emf`, `Wmf`, `Icon`, `Exif`, and `MemoryBmp` values, but IImage.Save does not produce those formats: the file it writes contains PNG data. To get an EMF image of a slide, use Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**Can I convert a PPT presentation to PPTX or ODP?**

Yes. Open the PPT file with the Presentation constructor and save it with `SaveFormat.Pptx` or `SaveFormat.Odp`. See [Convert PPT to PPTX](/slides/net/convert-ppt-to-pptx/).

**Can I open a PDF or HTML file as a presentation?**

No. Create or open a presentation, import the PDF pages or HTML content into it with the slide collection methods described above, and then save it in any supported format.

**Can I load an exported PNG or SVG image as an editable presentation?**

No. Image output records how a slide looks, not its text, shapes, or charts. Keep the source presentation if you need to edit it later.

**Can I save PDF/A or PDF/UA documents?**

Yes. Set [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) to a [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) value: PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, or PDF/UA.

**Can I check whether a file is password-protected before opening it?**

Yes. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) inspects a file without creating a Presentation object, and its [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) property reports whether a password is needed. See [Password-Protect Presentations](/slides/net/password-protected-presentation/).

**Do the two NuGet packages support different formats?**

No. Aspose.Slides.NET and Aspose.Slides.NET6.CrossPlatform have the same LoadFormat and SaveFormat values and the same import and rendering methods. They differ in the platforms they run on and in what those platforms need; see [Installation](/slides/net/installation/).
