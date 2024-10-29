---
title: Convert PowerPoint to HTML in Java
linktitle: Convert Powerpoint to HTML
type: docs
weight: 30
url: /nodejs-java/convert-powerpoint-to-html/
keywords: "Java PowerPoint to HTML, Convert PowerPoint Presentation, PPTX, PPT, PPT to HTML, PPTX to HTML, PowerPoint to HTML, Save PowerPoint as HTML, Save PPT as HTML, Save PPTX as HTML, Java, Aspose.Slides, HTML export"
description: "Convert PowerPoint HTML in Java: Save PPTX or PPT as HTML in Java. Save slides as HTML in Javascript"
---

## **Overview**

This article explains how to convert PowerPoint Presentation in HTML format using Java. It covers the following topics.

- Convert PowerPoint to HTML in Java
- Convert PPT to HTML in Java
- Convert PPTX to HTML in Java
- Convert ODP to HTML in Java
- Convert PowerPoint Slide to HTML in Java

## **Java PowerPoint to HTML**

For Javascript sample code to convert PowerPoint to HTML, please see the section below i.e. [Convert PowerPoint to HTML](#convert-powerpoint-to-html). The code can load number of formats like PPT, PPTX and ODP in Presentation object and save it to HTML format.

## **About PowerPoint to HTML Conversion**
Using [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), applications and developers can convert a PowerPoint presentation to HTML: **PPTX to HTML** or **PPT to HTML**.

**Aspose.Slides** provides many options (mostly from the [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) class) that define the PowerPoint to HTML conversion process:

* Convert an entire PowerPoint presentation to HTML.
* Convert a specific slide in a PowerPoint presentation to HTML.
* Convert presentation media (images, videos, etc.) to HTML.
* Convert a PowerPoint presentation to responsive HTML. 
* Convert a PowerPoint presentation to HTML with speaker notes included or excluded. 
* Convert a PowerPoint presentation to HTML with comments included or excluded. 
* Convert a PowerPoint presentation to HTML with original or embedded fonts. 
* Convert a PowerPoint presentation to HTML while using the new CSS style. 

{{% alert color="primary" %}} 

Using its own API, Aspose developed free [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) converters: [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

You may want to check out other [free converters from Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Besides the conversion processes described here, Aspose.Slides also supports these conversion operations involving the HTML format: 

* [HTML to image](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}


## **Convert PowerPoint to HTML**
Using Aspose.Slides, you can convert an entire PowerPoint presentation to HTML this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Use the [Save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) method to save the object as an HTML file.

This code shows you how to convert a PowerPoint to HTML in Java:

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // Saving the presentation to HTML
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convert PowerPoint to Responsive HTML**
Aspose.Slides provides the [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController) class that allows you to generate responsive HTML files. This code shows you how to convert a PowerPoint presentation to responsive HTML in Java:

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // Saving the presentation to HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convert PowerPoint to HTML with Notes**
This code shows you how to convert a PowerPoint to HTML with notes in Java:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Saving notes pages
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convert PowerPoint to HTML with Original Fonts**

Aspose.Slides provides the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) class that allows you to embed all the fonts in a presentation while converting the presentation to HTML.

To prevent certain fonts from being embedded, you can pass an array of font names to a parameterized constructor from the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) class. Popular fonts, such as Calibri or Arial, when used in a presentation, do not have to be embedded because most systems already contain such fonts. When those fonts are embedded, the resulting HTML document becomes unnecessarily large.

The [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) class supports inheritance and provides the [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) method, which is meant to be overwritten.

```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // exclude default presentation fonts
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var embedFontsController = new aspose.slides.EmbedAllFontsHtmlController(fontNameExcludeList);
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(embedFontsController));
    pres.save("input-PFDinDisplayPro-Regular-installed.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convert PowerPoint to HTML with High-quality Images**

By default, when you convert PowerPoint to HTML, Aspose.Slides outputs small HTML with images at 72 DPI and deleted cropped areas. To obtain HTML files with higher quality images, you have to set the `PicturesCompression` property (from the `HtmlOptions` class) to 96 (i.e., `PicturesCompression.Dpi96`) or higher [values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression).

This Javascript code shows you how to convert a PowerPoint presentation to HTML while obtaining high quality images at 150 DPI (i.e. `PicturesCompression.Dpi150`):

```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);
    pres.save("OutputDoc-dpi150.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

This code in Javascript shows you how to output HTML with full quality images:

```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);
    pres.save("Outputdoc-noCrop.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convert Slide to HTML**
To convert a specific slide in a PowerPoint to HTML, you have to instantiate the same [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class (used to convert entire presentations to HTML) and then use the [Save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) method to save the file as HTML. The [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) class can be used to specify additional conversion options:

This Javascript code shows you how to convert a slide in a PowerPoint presentation to HTML:

```javascript
var pres = new aspose.slides.Presentation("Individual-Slide.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    
    const CustomFormattingController = java.newProxy("com.aspose.slides.IHtmlFormattingController", {
        writeDocumentStart: function(generator, presentation) {

        },

        writeDocumentEnd: function(generator, presentation) {

        },

        writeSlideStart: function(generator, slide) {
            const slideIndex = generator.getSlideIndex() + 1;
            const slideHeaderHtml = `<div class="slide" name="slide" id="slide${slideIndex}">`;
            generator.addHtml(slideHeaderHtml);
        },

        writeSlideEnd: function(generator, slide) {
            const slideFooterHtml = "</div>";
            generator.addHtml(slideFooterHtml);
        },

        writeShapeStart: function(generator, shape) {
        },

        writeShapeEnd: function(generator, shape) {
        }
    });
    
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(CustomFormattingController));
    // Saving File
    for (var i = 0; i < pres.getSlides().size(); i++) {
        pres.save(("Individual Slide" + (i + 1)) + "_out.html", java.newArray("int", [i + 1]), aspose.slides.SaveFormat.Html, htmlOptions);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Save CSS and Images When Exporting To HTML**
Using new CSS style files, you can easily change the style of the HTML file resulting from the PowerPoint to HTML conversion process. 

The Javascript code in this example shows you how to use overridable methods to create a custom HTML document with a link to a CSS file:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var htmlController = java.newInstanceSync("CustomHeaderAndFontsController", "styles.css");
    var options = new aspose.slides.HtmlOptions();
    options.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(htmlController));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
You will need to implement CustomHeaderAndFontsController in Java, compile it, and add it to the module location \aspose.slides.via.java\lib\.
This Java code shows you how `CustomHeaderAndFontsController` is implemented:
```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // Custom header template
    final static String Header = "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" +
            "</head>";

    private final String m_cssFileName;

    public CustomHeaderAndFontsController(String cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.addHtml(String.format(Header, m_cssFileName));
        writeAllFonts(generator, presentation);
    }

    public void writeAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **Link All Fonts When Converting Presentation to HTML**

If you do not want to embed fonts (to avoid increasing the size of the resulting HTML), you can link all fonts by implementing your own  `LinkAllFontsHtmlController` version. 

This Javascript code shows you how to convert a PowerPoint to HTML while linking all fonts and excluding "Calibri" and "Arial" (since they already exist in the system):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Exclude default presentation fonts
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var linkcont = java.newInstanceSync("LinkAllFontsHtmlController", fontNameExcludeList, "C:/Windows/Fonts/");
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(linkcont));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

You will need to implement LinkAllFontsHtmlController in Java, compile it, and add it to the module location \aspose.slides.via.java\lib\.
This Java code shows you how `LinkAllFontsHtmlController` is implemented:
```java
public class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private final String m_basePath;

    public LinkAllFontsHtmlController(String[] fontNameExcludeList, String basePath)
    {
        super(fontNameExcludeList);
        m_basePath = basePath;
    }

    public void writeFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData)
    {
        try {
            String fontName = substitutedFont == null ? originalFont.getFontName() : substitutedFont.getFontName();
            String path = fontName + ".woff"; // some path sanitaze may be needed
            Files.write(new File(m_basePath + path).toPath(), fontData, StandardOpenOption.CREATE);

            generator.addHtml("<style>");
            generator.addHtml("@font-face { ");
            generator.addHtml("font-family: '" + fontName + "'; ");
            generator.addHtml("src: url('" + path + "')");

            generator.addHtml(" }");
            generator.addHtml("</style>");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}
```

## **Convert PowerPoint to Responsive HTML**
This Javascript code shows you how to convert a PowerPoint presentation to responsive HTML:

```javascript
var pres = new aspose.slides.Presentation("SomePresentation.pptx");
try {
    var saveOptions = new aspose.slides.HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", aspose.slides.SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Export Media Files to HTML**
Using Aspose.Slides for Node.js via Java, you can export media files this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Get a reference to the slide.
1. Add a video to the slide.
1. Write the presentation as a HTML file.

This Javascript code shows you how to add a video to the presentation and then save it as HTML:

```javascript
// Loading a presentation
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // Setting HTML options
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // Saving the file
    pres.save(fileName, aspose.slides.SaveFormat.Html, htmlOptions);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
