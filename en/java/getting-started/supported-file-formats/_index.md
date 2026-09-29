---
title: Supported File Formats
type: docs
weight: 106
url: /java/supported-file-formats/
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
- Java
- Aspose.Slides
description: "See which file formats Aspose.Slides for Java can load, import, save, and render, and which API reads or writes each one."
---

## **Overview**

Aspose.Slides for Java opens and saves PowerPoint and OpenDocument presentations. It also imports PDF and HTML content into slides, saves presentations to document, web, and image formats, and renders individual slides and shapes as images. This article lists each supported format and names the API that reads or writes it.

For an overview of editing features, see [Features Overview](/slides/java/features-overview/).

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

Presentations saved by PowerPoint 95 and earlier versions cannot be opened. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) recognizes a PowerPoint 95 file and reports `LoadFormat.Ppt95`, but the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) constructor throws [PptUnsupportedFormatException](https://reference.aspose.com/slides/java/com.aspose.slides/pptunsupportedformatexception/) for it.

{{% /alert %}}

## **Supported File Formats**

The table uses four operations:

- **Load**: the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) constructor opens the file as an editable presentation.
- **Import**: a [SlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/) method creates slides from the file's content and adds them to an existing presentation. The Presentation constructor does not convert these files into slides.
- **Save**: [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) writes the presentation to a file or stream. Every format except XAML is selected with a [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) value.
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
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Load and Import**

- **Load:** Pass a file path or a stream to the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) constructor. The format is detected from the content; [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) supplies settings such as a password. To check a file before opening it, call [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), which reports a [LoadFormat](https://reference.aspose.com/slides/java/com.aspose.slides/loadformat/) value. It reports `LoadFormat.Unknown` for PowerPoint XML, but the constructor opens such a file, and [Presentation.getSourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSourceFormat--) then returns `SourceFormat.Xml`. See [Open Presentations](/slides/java/open-presentation/) and [Determine the Original Presentation Format](/slides/java/detect-presentation-source-format/).
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) adds one slide per PDF page to the end of a presentation. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) adds slides created from HTML, and [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) inserts them at a given position. The Presentation constructor does not import: it throws [PptUnsupportedFormatException](https://reference.aspose.com/slides/java/com.aspose.slides/pptunsupportedformatexception/) for a PDF file and does not convert HTML markup into slide content. See [Import Presentations from PDF or HTML](/slides/java/import-presentation/).

## **Save and Render**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) writes the presentation in the format of a [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) value. Overloads that also take an options object control the output, for example [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/), and [GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/gifoptions/). Overloads that take an array of slide positions, starting from 1, write only those slides; they accept PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, and Markdown, but not the presentation formats or PowerPoint XML. XAML has its own overload, [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), which takes [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/). See [Save Presentations](/slides/java/save-presentation/), [Convert Presentations](/slides/java/convert-presentation/), and [Export Presentations to XAML](/slides/java/export-to-xaml/).
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) and [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) return an [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/), and [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) writes it as PNG, JPEG, BMP, GIF, or TIFF, selected with an [ImageFormat](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) value. [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) renders all slides or selected slides at once. [Slide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) and [Shape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) write SVG, and [Slide.writeAsEmf](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) writes EMF. See [Convert Presentation Slides to Images](/slides/java/convert-slide/) and [Render Presentation Slides as SVG Images](/slides/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat also has `Emf`, `Wmf`, `Icon`, `Exif`, and `MemoryBmp` values, but IImage.save does not produce those formats: the file it writes contains PNG data. To get an EMF image of a slide, use Slide.writeAsEmf.

{{% /alert %}}

## **FAQ**

**Can I convert a PPT presentation to PPTX or ODP?**

Yes. Open the PPT file with the Presentation constructor and save it with `SaveFormat.Pptx` or `SaveFormat.Odp`. See [Convert PPT to PPTX](/slides/java/convert-ppt-to-pptx/).

**Can I open a PDF or HTML file as a presentation?**

No. The Presentation constructor throws PptUnsupportedFormatException for a PDF file and does not convert HTML markup into slides. Create or open a presentation, import the PDF pages or HTML content into it with the slide collection methods described above, and then save it in any supported format.

**Can I load an exported PNG or SVG image as an editable presentation?**

No. Image output records how a slide looks, not its text, shapes, or charts. Keep the source presentation if you need to edit it later.

**Can I save PDF/A or PDF/UA documents?**

Yes. Pass a [PdfCompliance](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) value to [PdfOptions.setCompliance](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, or PDF/UA.

**Can I check whether a file is password-protected before opening it?**

Yes. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) inspects a file without creating a Presentation object, and [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) reports whether a password is needed. See [Password-Protect Presentations](/slides/java/password-protected-presentation/).
