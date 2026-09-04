---
title: Supported File Formats
type: docs
weight: 30
url: /python-java/supported-file-formats/
keywords:
- supported file formats
- presentation formats
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- slide images
- Python
- Aspose.Slides for Python via Java
description: "Explore the presentation, document, web, and image formats Aspose.Slides for Python via Java can load, import, save, and export."
---

## **Overview**

Aspose.Slides for Python via Java reads and writes PowerPoint and OpenDocument presentations. It also imports PDF and HTML content into slides and exports presentations or individual slides to document, web, and image formats.

The table below distinguishes presentation loading from content import and slide rendering. For an overview of editing and rendering capabilities, see [Features Overview](/slides/python-java/features-overview/).

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


## **Supported File Formats**

The following table lists supported input and output formats. **Load / Import** includes opening presentation files and importing PDF or HTML content. **Save / Export** includes saving presentations and rendering slides to images. A dash means that the corresponding operation is not supported as a presentation conversion operation.

|**Format**|**Description**|**Load / Import**|**Save / Export**|**Remarks**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint Macro-Enabled Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint Macro-Enabled Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint Macro-Enabled Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Packaged OpenDocument format.|
|FODP|Flat XML OpenDocument Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Stores the presentation as a single XML document.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument Presentation Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|{{< emoticons/tick >}}|Supports multipage output.|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|{{< emoticons/tick >}}|Exports individual slides as vector images.|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|{{< emoticons/tick >}}|Imports PDF pages as slides; exports presentations to PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|{{< emoticons/tick >}}|Fixed-layout document output.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|{{< emoticons/tick >}}|Renders individual slides as raster images.|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|{{< emoticons/tick >}}|Renders individual slides as raster images.|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|{{< emoticons/tick >}}|Image output.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|{{< emoticons/tick >}}|Renders individual slides as raster images.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|{{< emoticons/tick >}}|Exports individual slides as vector images.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format|—|{{< emoticons/tick >}}|Flash output.|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|{{< emoticons/tick >}}|Imports HTML content as slides; supports HTML and HTML5 export.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|{{< emoticons/tick >}}|Exports presentation content as XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Exports presentation content to Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML Presentation|—|{{< emoticons/tick >}}|PowerPoint-specific XML output, not arbitrary XML.|

## **Import and Export Notes**

- **PDF and HTML import:** Use [SlideCollection.addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addfrompdf) or [SlideCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addfromhtml) to create slides from source content and append them to a presentation.
- **Presentation output:** [SaveFormat](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/) lists the available presentation save formats, including separate HTML and HTML5 export options.
- **Image output:** Exporting a slide to an image produces a visual representation of that slide. The input column does not describe whether an image can be inserted into a presentation.

## **FAQ**

**Can I convert a PPT presentation to PPTX or ODP?**

Yes. PPT is supported as an input format, and both PPTX and ODP are supported as output formats. Conversion results depend on the features available in the destination format.

**Does PDF or HTML import open the source as a PowerPoint file?**

No. Import creates slides from PDF pages or HTML content. You can then save the resulting presentation in a supported presentation format.

**Can I load an exported PNG or SVG as an editable presentation?**

No. These exports represent slide appearance. Keep the source presentation when you need to edit its text, shapes, charts, and other objects later.
