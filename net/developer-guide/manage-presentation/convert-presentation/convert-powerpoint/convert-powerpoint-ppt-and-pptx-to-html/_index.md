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

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // Saving the presentation to HTML
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **Convert Powerpoint to Responsive HTML**
Convert PPT(X) presentation to Responsive HTML, which will ensure the generated HTML will be displayed properly across all browsers and devices. [**ResponsiveHtmlController** ](https://apireference.aspose.com/net/slides/aspose.slides.export/responsivehtmlcontroller)class provides the possibility to generate responsive HTML files. This controller can be used in the same manner as other HTML controllers:

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // Saving the presentation to HTML
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```



## **Convert Powerpoint to HTML with Notes**
The following example shows how to convert PPT(X) presentation to HTML with the rendered speaker notes. Using the options of [**HtmlOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/htmloptions) class and [**INotesCommentsLayoutingOptions** ](https://apireference.aspose.com/net/slides/aspose.slides.export/inotescommentslayoutingoptions/properties/index)interface you can render speaker notes to HTML:

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // Saving notes pages
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```



## **Convert Powerpoint to HTML with Original Fonts**
Preserve original fonts that are used in presentation while converting PPT(X) to HTML. [**EmbedAllFontsHtmlController** ](https://apireference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)class preserves the original fonts in generated HTML:

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // exclude default presentation fonts
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```



## **Convert Slide to HTML**
Convert a separate presentation slide to HTML. Fo that use the same [**Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class that is used to convert the whole PPT(X) presentation into a HTML document. The [**HtmlOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/htmloptions) class can be also used to set the additional conversion options:



```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // Saving File              
        for (int i = 0; i < presentation.Slides.Count; i++)
            presentation.Save("Individual Slide" + (i + 1) + "_out.html", new[] { i + 1 }, SaveFormat.Html, htmlOptions);
    }
}

public class CustomFormattingController : IHtmlFormattingController
{
    void IHtmlFormattingController.WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteSlideStart(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(string.Format(SlideHeader, generator.SlideIndex + 1));
    }

    void IHtmlFormattingController.WriteSlideEnd(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(SlideFooter);
    }

    void IHtmlFormattingController.WriteShapeStart(IHtmlGenerator generator, IShape shape)
    {}

    void IHtmlFormattingController.WriteShapeEnd(IHtmlGenerator generator, IShape shape)
    {}

    private const string SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
    private const string SlideFooter = "</div>";
}
```


## **Save CSS and Images when Exporting To HTML**
Use new CSS styles file to change the resulting styles of the HTML file while PPT(X) to HTML conversion with Aspose.Slides. Please review the example below how to use overridable methods to create a custom HTML document with a link to CSS file:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	pres.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // Custom header template
    const string Header = "<!DOCTYPE html>\n" +
                            "<html>\n" +
                            "<head>\n" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
                            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" +
                            "</head>";


    private readonly string m_cssFileName;

    public CustomHeaderAndFontsController(string cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public override void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml(string.Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    public override void WriteAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml("<!-- Embedded fonts -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```

## **Embed All Fonts When Converting Presentation to HTML**
Convert PPT(X) presentation to HTML with all its embedded fonts. [**EmbedAllFontsHtmlController** ](https://apireference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)class is used to embed all presentation fonts into HTML document. EmbedAllFontsHtmlController has a parameterized constructor where an array of font names can be passed to prevent them from embedding. Some fonts, like Calibri or Arial, used in the presentation are not needed to be embedded (which leads the resulting HTML document to become larger) because almost every system already has them installed. The EmbedAllFontsHtmlController also supports inheritance and WriteFont method that is intended to be overridden:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    // exclude default presentation fonts
    string[] fontNameExcludeList = { "Calibri", "Arial" };


    Paragraph para = new Paragraph();
    ITextFrame txt;

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        //HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

```c#
public class LinkAllFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string m_basePath;

    public LinkAllFontsHtmlController(string[] fontNameExcludeList, string basePath) : base(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    public override void WriteFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            string fontStyle,
            string fontWeight,
            byte[] fontData)
    {
        try
        {
            string fontName = substitutedFont == null ? originalFont.FontName : substitutedFont.FontName;
            string path = fontName + ".woff"; // some path sanitaze may be needed

            File.WriteAllBytes(Path.Combine(m_basePath, path), fontData);
            
            generator.AddHtml("<style>");
            generator.AddHtml("@font-face { ");
            generator.AddHtml("font-family: '" + fontName + "'; ");
            generator.AddHtml("src: url('" + path + "')");

            generator.AddHtml(" }");
            generator.AddHtml("</style>");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```

## **Support of SVG Responsive Property**
The code sample below shows how to export a PPT(X) presentation to HTML with the responsive layout:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **Exporting Media Files to HTML file**
In order to export media files from PPT(X) presentation to HTML. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Get reference of the slide.
1. Setting the transition effect.
1. Write the presentation as a PPTX file.

In the example given below, we have exported the media files to HTML.

```c#
// Loading a presentation
using (Presentation pres = new Presentation("Media File.pptx"))
{
    string path = "C:/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Setting HTML options
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Saving the file
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


