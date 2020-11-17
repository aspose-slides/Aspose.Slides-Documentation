---
title: Convert Powerpoint PPT and PPTX to HTML
type: docs
weight: 30
url: /net/convert-powerpoint-ppt-and-pptx-to-html/
keywords: "convert pptx to html, ppt to html, powerpoint to html, save pptx as html"
description: "Convert PowerPoint to HTML of any format: PPTX to HTML, PPT to HTML. Save PPTX to HTML and use PowerPoint HTML export."
---

## **About PowerPoint to HTML Conversion**
[**Aspose.Slides for .NET** ](https://products.aspose.com/slides/net)provides support for converting a PowerPoint presentation to HTML. With Aspose.Slides API you may set up the conversion process to enhance the resulting HTML. Both PPT to HTML and PPTX to HTML conversions are available.

There are many ways to convert PPT(X) to HTML. You could use PowerPoint native tools or online web tools to do that, however, they will cover only the basic scenarios to convert PPT(X) to HTML. If you need to built-in an HTML result to your website or integrate it into an enterprise-level solution - you would rather need to have more flexibility in PPT(X) to HTML conversion.

With Aspose.Slides API you may set up the conversion process to enhance the resulting HTML. It is possible to create your own PPT to HTML or PPTX to HTML converter, and integrate it into any desktop or web software.

Here are just some possibilities to set up PPT(X) to HTML conversion with Aspose.Slides:

1. Convert the whole PowerPoint presentation to HTML.
1. Convert a separate presentation slide to HTML. Choose separate slides from different presentations, combine them on the fly and convert presentation slides to one HTML file.
1. Convert presentation media (images, video, etc) to HTML.
1. Convert PowerPoint presentation to a responsive HTML. It's a powerful feature to create a responsive HTML document from the presentation, when you need the resulting HTML to be properly shown on various devices and sizes. You do not need to define all the responsive styles, the API will do that instead of you.
1. Convert PPT(X) to HTML with included or excluded speaker notes. It's possible to set the position of the notes.
1. Convert PPT(X) to HTML with included or excluded comments. It's possible to set the position of the comments, area color and width.
1. Convert PPT(X) to HTML with its original or embedded fonts. You can upload the original or embedded fonts used in presentation to make it applied in the resulting HTML.
1. Use new CSS while converting PPT(X) to HTML. You can change the styles of the resulting HTML by applying new CSS styles while converting presentation.

In Aspose.Slides PowerPoint to HTML conversion is implemented with [**Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class. Conversion settings are not limited with the described above and are represented in [**HtmlOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/htmloptions) class.



{{% alert color="primary" %}} 

Aspose.Slides proposes **online demo apps** to see alive the [**PPT to HTML**](https://products.aspose.app/slides/conversion/ppt-to-html)**,** [**PPTX to HTML**](https://products.aspose.app/slides/conversion/pptx-to-html), [**ODP to HTML**](https://products.aspose.app/slides/conversion/odp-to-html) conversion features supported:

[](https://products.aspose.app/slides/conversion/ppt-to-html)

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Find other live [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) examples.

{{% /alert %}} 


## **Convert Powerpoint to HTML**
Convert PPT or PPTX presentation to HTML file using Aspose.Slides. For that, save a PowerPoint presentation to HTML in two-lines:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Call [**Save** ](https://apireference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method from it specifying the resulting file as an HTML file:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-ConvertWholePresentationToHTML-ConvertWholePresentationToHTML.cs" >}}
## **Convert Powerpoint to Responsive HTML**
Convert PPT(X) presentation to Responsive HTML, which will ensure the generated HTML will be displayed properly across all browsers and devices. [**ResponsiveHtmlController** ](https://apireference.aspose.com/net/slides/aspose.slides.export/responsivehtmlcontroller)class provides the possibility to generate responsive HTML files. This controller can be used in the same manner as other HTML controllers:



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-ConvertPresentationToResponsiveHTML-ConvertPresentationToResponsiveHTML.cs" >}}
## **Convert Powerpoint to HTML with Notes**
The following example shows how to convert PPT(X) presentation to HTML with the rendered speaker notes. Using the options of [**HtmlOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/htmloptions) class and [**INotesCommentsLayoutingOptions** ](https://apireference.aspose.com/net/slides/aspose.slides.export/inotescommentslayoutingoptions/properties/index)interface you can render speaker notes to HTML:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Conversion-RenderingNotesWhileConvertingToHTML-RenderingNotesWhileConvertingToHTML.cs" >}}
## **Convert Powerpoint to HTML with Original Fonts**
Preserve original fonts that are used in presentation while converting PPT(X) to HTML. [**EmbedAllFontsHtmlController** ](https://apireference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)class preserves the original fonts in generated HTML:



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-ConvertingPresentationToHTMLWithPreservingOriginalFonts-ConvertingPresentationToHTMLWithPreservingOriginalFonts.cs" >}}
## **Convert Slide to HTML**
Convert a separate presentation slide to HTML. Fo that use the same [**Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class that is used to convert the whole PPT(X) presentation into a HTML document. The [**HtmlOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/htmloptions) class can be also used to set the additional conversion options:



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-ConvertIndividualSlide-ConvertIndividualSlide.cs" >}}
## **Save CSS and Images when Exporting To HTML**
Use new CSS styles file to change the resulting styles of the HTML file while PPT(X) to HTML conversion with Aspose.Slides. Please review the example below how to use overridable methods to create a custom HTML document with a link to CSS file:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-SavingHTMLAndCSSFileWhenExportingIntoHTML-SavingHTMLAndCSSFileWhenExportingIntoHTML.cs" >}}
## **Embed All Fonts When Converting Presentation to HTML**
Convert PPT(X) presentation to HTML with all its embedded fonts. [**EmbedAllFontsHtmlController** ](https://apireference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)class is used to embed all presentation fonts into HTML document. EmbedAllFontsHtmlController has a parameterized constructor where an array of font names can be passed to prevent them from embedding. Some fonts, like Calibri or Arial, used in the presentation are not needed to be embedded (which leads the resulting HTML document to become larger) because almost every system already has them installed. The EmbedAllFontsHtmlController also supports inheritance and WriteFont method that is intended to be overridden:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-ConvertingPresentationToHtmlWithEmbedAllFontsHtmlController-ConvertingPresentationToHtmlWithEmbedAllFontsHtmlController.cs" >}}

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-CustomHeaderAndFontsController-CustomHeaderAndFontsController.cs" >}}
## **Support of SVG Responsive Property**
The code sample below shows how to export a PPT(X) presentation to HTML with the responsive layout:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Conversion-ExportToHTMLWithResponsiveLayout-ExportToHTMLWithResponsiveLayout.cs" >}}
## **Exporting Media Files to HTML file**
In order to export media files from PPT(X) presentation to HTML. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Get reference of the slide.
1. Setting the transition effect.
1. Write the presentation as a PPTX file.

In the example given below, we have exported the media files to HTML.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Conversion-ExportMediaFilestohtml-ExportMediaFilestohtml.cs" >}}






