---
title: Converting Presentation to HTML
type: docs
weight: 20
url: /cpp/converting-presentation-to-html/
---

## **Converting Presentation to HTML**
HTML is one of several widely used format for exchanging data. Aspose.Slides for C++ provides support for converting a presentation to HTML which is an embedded SVG. The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a18df81989014383671668617295f4297) method exposed by the [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class can be used to convert the whole presentation into a HTML document. The [HtmlOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.html_options/) class can be used to set the options.
### **Converting Whole Presentation to HTML**
This article shows how to create a HTML file from [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class using Aspose.Slides. Saving a PowerPoint presentation to HTML is a two-line process with Aspose.Slides for C++ and you simply open the presentation and save it out to HTML.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertWholePresentationToHTML-ConvertWholePresentationToHTML.cpp" >}}
### **Converting Specific Slide to HTML**
The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a18df81989014383671668617295f4297) method exposed by the [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class can be used to convert the whole presentation into a HTML document. The [HtmlOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.html_options/) class can be used to set the options. Saving an interdependent PowerPoint slide to individual HTML file per slide is a now possible using Aspose.Slides for C++ and you simply open the presentation and save it out to HTML.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertIndividualSlideToHTML-ConvertIndividualSlideToHTML.cpp" >}}
### **Converting Presentation to Responsive HTML**
Now you can export presentation to Responsive HTML, which will ensure the generate an HTML that will be displayed properly across browsers in different devises.The new class [ResponsiveHtmlController](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.responsive_html_controller/) has been added to provide the possibility to generate responsive HTML files. This controller can be used in the same manner as other HTML controllers:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertPresentationToResponsiveHTML-ConvertPresentationToResponsiveHTML.cpp" >}}
### **Exporting Media Files to HTML File**
In order to export media files to HTML. Please follow the steps below:

1. Create an instance of Presentation class.
1. Get reference of the slide.
1. Setting the transition effect.
1. Write the presentation as a PPTX file.

In the example given below, we have exported the media files to HTML.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ExportMediaFilestoHTML-ExportMediaFilestoHTML.cpp" >}}
### **Render notes when Converting To HTML**
The following example shows how to render notes when converting presentation into HTML. Using **HtmlOptions** class and **INotesCommentsLayoutingOptions** interface you can render notes to HTML. 

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-RenderingNotesWhileConvertingToHTML-RenderingNotesWhileConvertingToHTML.cpp" >}}
### **Preserve Original Fonts While Converting To HTML**
Now using this new feature you can preserve original fonts that are used in Presentation while converting to HTML. New Property [EmbedAllFontsHtmlController](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.embed_all_fonts_html_controller/) has been added to preserve the original fonts in generated HTML.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ConvertingPresentationToHTMLWithPreservingOriginalFonts-ConvertingPresentationToHTMLWithPreservingOriginalFonts.cpp" >}}
### **Save CSS and Images when Exporting To HTML**
Now using this feature you can save css and images files separately into folder. In addition, WriteAllFonts method has been added. It allows overriding the way how all fonts contained in the presentation are serialized into HTML. Please review the example below how to use overridable methods to create a custom HTML document with a link to CSS file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertingPresentationToHTMLWithPreservingOriginalFonts-ConvertingPresentationToHTMLWithPreservingOriginalFonts.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Loading-and-Saving-ConvertToHTML-ConvertToHTML.cs" >}}
### **Embed All Fonts When Converting Presentation to HTML**
Now, you can export presentation to HTML by embedding all fonts used in presentation. A new HTML controller, [EmbedAllFontsHtmlController](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.embed_all_fonts_html_controller/) has been added which is used to embed all presentation fonts in HTML document. Below is an example of using this new controller.  Please note that [EmbedAllFontsHtmlController](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.embed_all_fonts_html_controller/) has parameterized constructor where an array of font names can be passed to prevent them from embedding. Some fonts, like Calibri or Arial, used in presentation are not needed to be embedded (which leads the resulting HTML document become larger) because almost every system already has them installed. The [EmbedAllFontsHtmlController](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.embed_all_fonts_html_controller/) also supports inheritance and WriteFont method that is intended to be overridden:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertingPresentationToHtmlWithEmbedAllFontsHtmlController-ConvertingPresentationToHtmlWithEmbedAllFontsHtmlController.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Conversion-CustomHeaderAndFontsController-CustomHeaderAndFontsController.cs" >}}
