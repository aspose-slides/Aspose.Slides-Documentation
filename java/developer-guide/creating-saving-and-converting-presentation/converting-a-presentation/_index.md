---
title: Converting a Presentation
type: docs
weight: 10
url: /java/converting-a-presentation/
---




## **Converting PPT to PPTX**
Aspose.Slides for Java now facilitates the developers to access the PPT using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class instance and converting that to respective [PPTX](https://wiki.fileformat.com/presentation/pptx/) format. Presently, it supports partial conversion of [PPT ](https://wiki.fileformat.com/presentation/ppt/)to PPTX. For more details about what features are supported and unsupported in PPT to PPTX conversion, please proceed to this documentation [link](/slides/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java offers [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class that represents a **PPTX** presentation file. Presentation class can now also access **PPT** through Presentation when the object is instantiated. The following example shows how to convert a PPT presentation into PPTX Presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPPTToPPTX-ConvertingPPTToPPTX.java" >}}





|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figure : Source PPT Presentation**|
The above code snippet generated the following PPTX presentation after conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure: Generated PPTX presentation after conversion**|
## **Converting ODP to PPTX**
Aspose.Slides for Java offers Presentation class that represents a presentation file. [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class can now also access [**ODP** ](https://wiki.fileformat.com/presentation/odp/)through Presentation constructor when the object is instantiated. The following example shows how to convert a [ODP ](https://wiki.fileformat.com/presentation/odp/)file into [PPTX ](https://wiki.fileformat.com/presentation/pptx/)Presentation.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingODPToPPTX-ConvertingODPToPPTX.java" >}}


## **Converting Presentation to PDF**
{{% alert color="primary" %}} 

Aspose.Slides for Java directly writes the information about API and Version Number in output documents. For example, upon rendering Document to [PDF](https://wiki.fileformat.com/view/pdf/), Aspose.Slides for Java populates the Application field with value 'Aspose.Slides' and PDF Producer field with value, e.g 'Aspose.Slides v 17.10'.

Please note that you cannot instruct Aspose.Slides for Java to change or remove this information from output Documents.

{{% /alert %}} {{% alert color="primary" %}} 

[PDF ](https://wiki.fileformat.com/view/pdf/)documents are widely used as a standard format of exchanging documents between organizations, government sectors and individuals. It's a popular format so developers are often asked to convert Microsoft PowerPoint presentation files to PDF documents. Realizing this possible requirement, Aspose.Slides for Java supports converting presentations to PDF documents without using any other component. This topic illustrates how this conversion can be done.

{{% /alert %}} 

Aspose.Slides for Java offers the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class that represents a presentation file. The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class exposes the **Save** method that can be called to convert the whole presentation into a PDF document. The [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class provides options for creating the PDF such as **JpegQuality**, **TextCompression**, **Compliance** and others. These options can be used to get the desired standard of PDF.
### **Converting Presentation to PDF using the Default Options**
The following example shows how to convert a presentation into a PDF document using the default options. The default options create a PDF document of maximum quality.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFUsingDefaultOptions-ConvertingPresentationToPDFUsingDefaultOptions.java" >}}
### **Converting Presentation to PDF using Custom Options**
The following example shows how to convert a presentation into a PDF document with customized options as provided by the [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class. It sets the JPEG quality, saves metafiles to PNG, sets text compression level and PDF standard. You can also include comments in generated PDF by using [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions)** **class and [**INotesCommentsLayoutingOptions** ](https://apireference.aspose.com/java/slides/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFUsingCustomOptions-ConvertingPresentationToPDFUsingCustomOptions.java" >}}
### **Converting Presentation to PDF including Hidden Slides**
The following example shows how to convert a presentation into a PDF document with hidden slides included as provided by the [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class. It sets the [setShowHiddenSlides(boolean)](https://apireference.aspose.com/java/slides/com.aspose.slides/IPdfOptions#setShowHiddenSlides-boolean-) method to generate PDF with hidden slides.

Method [setShowHiddenSlides(boolean)](https://apireference.aspose.com/java/slides/com.aspose.slides/IPdfOptions#setShowHiddenSlides-boolean-) has been added to [IHtmlOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/ihtmloptions), [IPdfOption](https://apireference.aspose.com/java/slides/com.aspose.slides/ipdfoptions), [ISwfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/iswfoptions), [ITiffOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/itiffoptions), [IXpsOption](https://apireference.aspose.com/java/slides/com.aspose.slides/ixpsoptions) interfaces and [HtmlOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions), [PdfOption](https://apireference.aspose.com/java/slides/com.aspose.slides/pdfoptions), [SwfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/swfoptions), [TiffOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/tiffoptions), [XpsOption](https://apireference.aspose.com/java/slides/com.aspose.slides/xpsoptions) classes.

This method specifies whether the exported document should include hidden slides or not. Default value is **false**.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFIncludingHiddenSlides-ConvertingPresentationToPDFIncludingHiddenSlides.java" >}}
### **Converting Presentation to Password Protected PDF**
The following example shows how to convert a presentation to a password protected PDF document with customized options as provided by the [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPasswordProtectedPDF-ConvertingPresentationToPasswordProtectedPDF.java" >}}
### **Converting a Specific Slide to PDF**
The following example shows how to convert a specific slide in a presentation to a PDF document with custom options.


### **Save to PDF notes with custom slide size**
The following example shows how to convert a presentation to a PDF notes document with custom slide size. Where each inch equals 72 pixels.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-SaveToPDFNotesWithCustomSlideSize-SaveToPDFNotesWithCustomSlideSize.java" >}}
## **Converting Presentation to TIFF**
{{% alert color="primary" %}} 

TIFF format is known for its flexibility to accommodate multipage images and data. Keeping in view the importance and popularity of [TIFF ](https://wiki.fileformat.com/image/tiff/)format, Aspose.Slides for Java provides the support for converting presentations into TIFF document.

{{% /alert %}} 

The **Save** method exposed by [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class can be called by developers to convert the whole presentation into TIFF document. Further, [TiffOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/tiffoptions) class exposes [**ImageSize** ](https://apireference.aspose.com/java/slides/com.aspose.slides/TiffOptions#setImageSize-java.awt.Dimension-)property enabling the developer to define the size of the image if required.
### **Converting Presentation to TIFF with default size**
The following example shows how to convert a presentation into a [TIFF ](https://wiki.fileformat.com/image/tiff/)document with default options.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToTIFFWithDefaultSize-ConvertingPresentationToTIFFWithDefaultSize.java" >}}
### **Converting Presentation to TIFF with custom size**
The following example shows how to convert a presentation into TIFF document with customized image size using [TiffOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/TiffOptions) class.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToTIFFWithCustomSize-ConvertingPresentationToTIFFWithCustomSize.java" >}}
### **Converting Presentation to TIFF with custom Image Pixel Format**
The following example shows how to convert a presentation into a TIFF document with customized Image Pixel Format using [TiffOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/TiffOptions) class. You can also include comments in generated TIFF by using [TiffOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/TiffOptions)** **class.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToTIFFWithCustomImagePixelFormat-ConvertingPresentationToTIFFWithCustomImagePixelFormat.java" >}}
## **Converting Presentation to XPS**
{{% alert color="primary" %}} 

[XPS](https://wiki.fileformat.com/page-description-language/xps/) format is also widely used for the exchange of data. Aspose.Slides for Java takes care of its importance and provides the built-in support for converting a presentation into XPS document

{{% /alert %}} 

The **save** method exposed by [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class can be used to convert the whole presentation into XPS document. Further, [XpsOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/xpsoptions) class exposes [**SaveMetafileAsPng**](https://apireference.aspose.com/java/slides/com.aspose.slides/IXpsOptions#setSaveMetafilesAsPng-boolean-) property that can be set to true or false as per requirement.
### **Converting Presentation to XPS without XpsOptions**
The following example shows how to convert a presentation into XPS document without using options provided by [XpsOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/xpsoptions) class.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToXPSWithoutXpsOptions-ConvertingPresentationToXPSWithoutXpsOptions.java" >}}
### **Converting Presentation to XPS with XpsOptions**
The following example shows how to convert a presentation into XPS document using options provided by [XpsOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/xpsoptions) class.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToXPSWithXpsOptions-ConvertingPresentationToXPSWithXpsOptions.java" >}}
## **Converting Presentation to HTML**
{{% alert color="primary" %}} 

HTML is one of several widely used format for exchanging data. Aspose.Slides for Java provides support for converting a presentation to [HTML ](https://wiki.fileformat.com/web/html/)which is an embedded [SVG](https://wiki.fileformat.com/page-description-language/svg/).

{{% /alert %}} 

The **Save** method exposed by the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class can be used to convert the whole presentation into a HTML document. The [HtmlOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions) class can be used to set the options.
### **Converting Presentation to HTML**
Saving a PowerPoint presentation to HTML is a two-line process with Aspose.Slides for Java. Simply open the presentation and save it out to HTML. You can also include comments in generated HTML by using [**HtmlOptions**  ](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions)class and [**INotesCommentsLayoutingOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToHTML1-ConvertingPresentationToHTML1.java" >}}
### **Exporting Presentation to HTML file with Video**
In order to export media files like videos to HTML. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class.
1. Get reference of the slide.
1. Setting the transition effect.
1. Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToHTMLWithMediaFiles-ConvertingPresentationToHTMLWithMediaFiles.java" >}}
### **Converting an Individual Slide to HTML**
Saving an interdependent PowerPoint slide to individual HTML file per slide is now possible by using Aspose.Slides for Java. Simply open the presentation and save it to HTML. You can also include comments in generated HTML by using [ **HtmlOptions**  ](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions)class and [**INotesCommentsLayoutingOptions** ](https://apireference.aspose.com/java/slides/com.aspose.slides/INotesCommentsLayoutingOptions)interface.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingAnIndividualSlideToHTML-ConvertingAnIndividualSlideToHTML.java" >}}
### **Render notes when Converting To HTML**
The following example shows how to render notes when converting presentation into HTML. Using [**HtmlOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions)** **class and [**INotesCommentsLayoutingOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/INotesCommentsLayoutingOptions) interface you can render notes to HTML. The following code snippet shows how to render notes while converting a presentation to HTML.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-RenderingNotesWhileConvertingToHTML-RenderingNotesWhileConvertingToHTML.java" >}}
### **Save CSS and Images when Exporting To HTML**
Now using this feature you can save CSS and images files separately into a folder. In addition, WriteAllFonts method has been added. It allows overriding the way how all fonts contained in the presentation are serialized into HTML.

Please review the example below how to use overridable methods to create a custom HTML document with a link to CSS file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-SavingHTMLAndCSSFileWhenExportingIntoHTML-SavingHTMLAndCSSFileWhenExportingIntoHTML.java" >}}

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-CustomHeaderAndFontsController-CustomHeaderAndFontsController.java" >}}
### **Preserve Original Fonts While Converting To HTML**
Now using this new feature you can preserve original fonts that are used in Presentation while converting to HTML. New Property EmbedAllFontsHtmlController has been added to preserve the original fonts in generated HTML.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToHTMLWithPreservingOriginalFonts-ConvertingPresentationToHTMLWithPreservingOriginalFonts.java" >}}
### **Converting Presentation to Responsive HTML**
Now you can export the presentation to Responsive HTML, which will ensure the generate an HTML that will be displayed properly across browsers in different devices. The new class ResponsiveHtmlController has been added to provide the possibility to generate responsive HTML files.

This controller can be used in the same manner as other HTML controllers:

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToResponsiveHTML-ConvertingPresentationToResponsiveHTML.java" >}}
### **Embed All Fonts When Converting Presentation to HTML**
Now, you can export presentation to HTML by embedding all fonts used in presentation. A new HTML controller, EmbedAllFontsHtmlController has been added which is used to embed all presentation fonts in HTML document. Below is an example of using this new controller.  Please note that EmbedAllFontsHtmlController has parameterized constructor where an array of font names can be passed to prevent them from embedding. Some fonts, like Calibri or Arial, used in presentation are not needed to be embedded (which leads the resulting HTML document become larger) because almost every system already has them installed. The EmbedAllFontsHtmlController also supports inheritance and WriteFont method that is intended to be overridden:

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToHtmlWithEmbedAllFontsHtmlController-ConvertingPresentationToHtmlWithEmbedAllFontsHtmlController.java" >}}

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-LinkAllFontsHtmlController-LinkAllFontsHtmlController.java" >}}
### **Support of SVG Responsive Property**
getSvgResponsiveLayout and setSvgResponsiveLayout methods have been added to IHtmlOptions. Code sample below shows how to export presentation to HTML with responsive layout:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ExportToHTMLWithResponsiveLayout-ExportToHTMLWithResponsiveLayout.java" >}}
## **Converting Presentation with Notes**
{{% alert color="primary" %}} 

Aspose.Slides for Java provides **Conversion to TIFF** and **Conversion to PDF** in order to convert slides with notes.

{{% /alert %}} 
### **Converting Presentation in Notes Slide View to TIFF**
TIFF is one of several widely used image formats that Aspose.Slides for Java supports for converting a presentation with notes to images. The **save** method exposed by the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class can be used to convert the whole presentation in Notes Slide view to TIFF.You can also generate a slide thumbnail in Notes Slide view for individual slides.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationInNotesSlideViewToTIFF-ConvertingPresentationInNotesSlideViewToTIFF.java" >}}



The above code snippets update the sample presentation to TIFF images in Notes Slide view, as shown below:

|**The source presentation view with slide notes**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**The generated TIFF image in Notes Slide view**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |
### **Converting Presentation in Notes Slide View to PDF**
The Save method exposed by [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class can be used to convert the whole presentation in Notes Slide view to PDF. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for Java is a two-line process. You simply need to open the presentation and save it out to PDF notes.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationInNotesSlideViewToPDF-ConvertingPresentationInNotesSlideViewToPDF.java" >}}
## **Converting Presentation to SWF**
The Save method exposed by [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class can be used to convert the whole presentation into **SWF** document. The following example shows how to convert a presentation into **SWF** document by using options provided by **SWFOptions** class.You can also include comments in generated SWF ConvertingPresentationInNotesSlideViewToPDFby using **SWFOptions** class and **INotesCommentsLayoutingOptions** interface.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToSWF-ConvertingPresentationToSWF.java" >}}
