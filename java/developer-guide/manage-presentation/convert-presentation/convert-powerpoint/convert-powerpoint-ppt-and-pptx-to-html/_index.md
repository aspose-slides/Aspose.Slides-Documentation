---
title: Convert Powerpoint PPT(X) to HTML
type: docs
weight: 30
url: /java/convert-powerpoint-ppt-and-pptx-to-html/
keywords: "convert pptx to html, ppt to html, powerpoint to html, save pptx as html"
description: "Convert PowerPoint to HTML of any format: PPTX to HTML, PPT to HTML. Save PPTX to HTML and use PowerPoint HTML export."
---

{{% alert color="primary" %}} 

HTML is one of several widely used format for exchanging data. Aspose.Slides for Java provides support for converting a presentation to [HTML ](https://wiki.fileformat.com/web/html/)which is an embedded [SVG](https://wiki.fileformat.com/page-description-language/svg/).

{{% /alert %}} 

The **Save** method exposed by the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class can be used to convert the whole presentation into a HTML document. The [HtmlOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions) class can be used to set the options.

## **Convert Presentation to HTML**
Saving a PowerPoint presentation to HTML is a two-line process with Aspose.Slides for Java. Simply open the presentation and save it out to HTML. You can also include comments in generated HTML by using [**HtmlOptions**  ](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions)class and [**INotesCommentsLayoutingOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToHTML1-ConvertingPresentationToHTML1.java" >}}

## **Convert Presentation to Responsive HTML**
Now you can export the presentation to Responsive HTML, which will ensure the generate an HTML that will be displayed properly across browsers in different devices. The new class ResponsiveHtmlController has been added to provide the possibility to generate responsive HTML files.

This controller can be used in the same manner as other HTML controllers:

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToResponsiveHTML-ConvertingPresentationToResponsiveHTML.java" >}}

getSvgResponsiveLayout and setSvgResponsiveLayout methods have been added to IHtmlOptions. Code sample below shows how to export presentation to HTML with responsive layout:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ExportToHTMLWithResponsiveLayout-ExportToHTMLWithResponsiveLayout.java" >}}

## **Export Presentation to HTML with Video**
In order to export media files like videos to HTML. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class.
1. Get reference of the slide.
1. Setting the transition effect.
1. Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToHTMLWithMediaFiles-ConvertingPresentationToHTMLWithMediaFiles.java" >}}

## **Preserve Original Fonts While Converting to HTML**
Now using this new feature you can preserve original fonts that are used in Presentation while converting to HTML. New Property EmbedAllFontsHtmlController has been added to preserve the original fonts in generated HTML.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToHTMLWithPreservingOriginalFonts-ConvertingPresentationToHTMLWithPreservingOriginalFonts.java" >}}

## **Embed All Fonts when Converting Presentation to HTML**
Now, you can export presentation to HTML by embedding all fonts used in presentation. A new HTML controller, EmbedAllFontsHtmlController has been added which is used to embed all presentation fonts in HTML document. Below is an example of using this new controller.  Please note that EmbedAllFontsHtmlController has parameterized constructor where an array of font names can be passed to prevent them from embedding. Some fonts, like Calibri or Arial, used in presentation are not needed to be embedded (which leads the resulting HTML document become larger) because almost every system already has them installed. The EmbedAllFontsHtmlController also supports inheritance and WriteFont method that is intended to be overridden:

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToHtmlWithEmbedAllFontsHtmlController-ConvertingPresentationToHtmlWithEmbedAllFontsHtmlController.java" >}}

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-LinkAllFontsHtmlController-LinkAllFontsHtmlController.java" >}}

## **Render Notes when Converting to HTML**
The following example shows how to render notes when converting presentation into HTML. Using [**HtmlOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions)** **class and [**INotesCommentsLayoutingOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/INotesCommentsLayoutingOptions) interface you can render notes to HTML. The following code snippet shows how to render notes while converting a presentation to HTML.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-RenderingNotesWhileConvertingToHTML-RenderingNotesWhileConvertingToHTML.java" >}}

## **Save CSS and Images when Exporting to HTML**
Now using this feature you can save CSS and images files separately into a folder. In addition, WriteAllFonts method has been added. It allows overriding the way how all fonts contained in the presentation are serialized into HTML.

Please review the example below how to use overridable methods to create a custom HTML document with a link to CSS file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-SavingHTMLAndCSSFileWhenExportingIntoHTML-SavingHTMLAndCSSFileWhenExportingIntoHTML.java" >}}

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-CustomHeaderAndFontsController-CustomHeaderAndFontsController.java" >}}
