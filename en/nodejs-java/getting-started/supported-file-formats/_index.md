---
title: Supported File Formats
type: docs
weight: 30
url: /nodejs-java/supported-file-formats/
---

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
- Microsoft PowerPoint for MAC
- Office 365

## **Supported File Formats**
This table contains the file formats that Aspose.Slides for Node.js via Java can load and save:

|**Format**|**Description**|**Load**|**Save**|**Remarks**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint Macro-Enabled Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint Macro-Enabled Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint Macro-Enabled Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument Presentation Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML Presentation| |{{< emoticons/tick >}}| |

## **FAQ**

**Can I save presentations to PDF that meet archival and accessibility standards (PDF/A and PDF/UA)?**

Yes. Aspose.Slides supports exporting to PDF with compliance levels such as PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, as well as PDF/UA through the [compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) setting in [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**Does the library support font embedding when exporting to PDF, with fine-grained control over what gets embedded?**

Yes. You can control whether fonts are fully embedded or subsetted (only used glyphs), specify how common system fonts are treated, and configure behavior for ASCII text through [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**Can I detect whether a file is password-protected before actually loading it?**

Yes. Using the [factory-based inspection API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/), you can query a presentation file to determine if it is password-protected without opening it fully.

**Are there font fallback mechanisms and support for custom fonts?**

Yes. The library supports [loading](/slides/nodejs-java/custom-font/) and [embedding](/slides/nodejs-java/embedded-font/) custom fonts and provides font [fallback rules](/slides/nodejs-java/fallback-font/) to prevent missing glyphs during rendering and conversion.

**Can I export slides to XPS, and are there options to tune the XPS output?**

Yes. [Export to XPS](/slides/nodejs-java/convert-powerpoint-to-xps/) is supported, and you can adjust relevant [save options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) to control the output quality and content of the XPS document.
