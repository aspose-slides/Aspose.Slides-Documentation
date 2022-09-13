---
title: Convert PowerPoint (PPT, PPTX) to HTML in C# .NET
linktitle: Convert PowerPoint to HTML
type: docs
weight: 30
url: /net/convert-powerpoint-to-html/
keywords: "C# PowerPoint to HTML, C# PPT to HTML, C# ODP to HTML, C# Slide to HTML, Convert PowerPoint Presentation, PPTX, PPT, PPT to HTML, PPTX to HTML, PowerPoint to HTML, Save PowerPoint as HTML, Save PPT as HTML, Save PPTX as HTML, C#, Csharp, .NET, Aspose.Slides, HTML export"
description: "Convert PowerPoint HTML: Save PPTX or PPT as HTML. Save slides as HTML"
---

## **Overview**

This article explains how to convert PowerPoint Presentation in HTML format using C#. It covers the following topics.

- Convert PowerPoint to HTML in C#
- Convert PPT to HTML in C#
- Convert PPTX to HTML in C#
- Convert ODF to HTML in C#
- Convert PowerPoint Slide to HTML in C#

## **C# PowerPoint to HTML**

For C# sample code to convert PowerPoint to HTML, please see the section below i.e. [Convert PowerPoint to HTML](#convert-powerpoint-to-html). The code can load number of formats like PPT, PPTX and ODP in Presentation object and save it to HTML format.

## **About PowerPoint to HTML Conversion**
Using [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), applications and developers can convert a PowerPoint presentation to HTML: **PPTX to HTML** or **PPT to HTML**. 

**Aspose.Slides** provides many options (mostly from the [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) class) that define the PowerPoint to HTML conversion process:

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


## **Convert PowerPoint to HTML**
Using Aspose.Slides, you can convert an entire PowerPoint presentation to HTML this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Use the [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method to save the object as an HTML file.

This code shows you how to convert a PowerPoint to HTML in C#:

```c#
// Instantiates a presentation object that represents a presentation file
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // Saves the presentation to HTML
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **Convert PowerPoint to Responsive HTML**
Aspose.Slides provides the [ResponsiveHtmlController ](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller)class that allows you to generate responsive HTML files. This code shows you how to convert a PowerPoint presentation to responsive HTML in C#:

```c#
// Instantiates a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // Saves the presentation to HTML
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```

## **Convert PowerPoint to HTML with Notes**
This code shows you how to convert a PowerPoint to HTML with notes in C#:

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // Saves notes pages
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```

## **Convert PowerPoint to HTML with Original Fonts**

Aspose.Slides provides the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) class that allows you to embed all the fonts in a presentation while converting the presentation to HTML.

To prevent certain fonts from being embedded, you can pass an array of font names to a parameterized constructor from the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) class. Popular fonts, such as Calibri or Arial, when used in a presentation, do not have to be embedded because most systems already contain such fonts. When those fonts are embedded, the resulting HTML document becomes unnecessarily large.

The [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) class supports inheritance and provides the [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) method, which is meant to be overwritten. 

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // Excludes default presentation fonts
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

## **Convert PowerPoint to HTML with High-quality Images**

By default, when you convert PowerPoint to HTML, Aspose.Slides outputs small HTML with images at 72 DPI and deleted cropped areas. To obtain HTML files with higher quality images, you have to set the `PicturesCompression` property (from the `HtmlOptions` class) to 96 (i.e., `PicturesCompression.Dpi96`) or higher [values](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

This C# code shows you how to convert a PowerPoint presentation to HTML while obtaining high quality images at 150 DPI (i.e. `PicturesCompression.Dpi150`):

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};
pres.Save("OutputDoc-dpi150.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts); 
```

This code in C# shows you how to output HTML with full quality images:

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};
pres.Save("Outputdoc-noCrop.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
```

## **Convert Slide to HTML**
To convert a specific slide in a PowerPoint to HTML, you have to instantiate the same [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class (used to convert entire presentations to HTML) and then use the [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method to save the file as HTML. The [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions**) class can be used to specify additional conversion options:

This C# code shows you how to convert a slide in a PowerPoint presentation to HTML:

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // Saves File              
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


## **Save CSS and Images When Exporting To HTML**
Using new CSS style files, you can easily change the style of the HTML file resulting from the PowerPoint to HTML conversion process. 

The C# code in this example shows you how to use overridable methods to create a custom HTML document with a link to a CSS file:

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

## **Link All Fonts When Converting Presentation to HTML**

If you do not want to embed fonts (to avoid increasing the size of the resulting HTML), you can link all fonts by implementing your own  `LinkAllFontsHtmlController` version. 

This C# code shows you how to convert a PowerPoint to HTML while linking all fonts and excluding "Calibri" and "Arial" (since they already exist in the system): 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    //Excludes default presentation fonts
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    Paragraph para = new Paragraph();
    ITextFrame txt;

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

This C# code shows you how `LinkAllFontsHtmlController` is implemented:

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
            string path = fontName + ".woff"; //Some path sanitaze may be needed

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

## **Convert PowerPoint to Responsive HTML**
This C# code shows you how to convert a PowerPoint presentation to responsive HTML:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **Export Media Files to HTML**
Using Aspose.Slides for .NET, you can export media files this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a reference to the slide.
1. Add a video to the slide.
1. Write the presentation as a HTML file.

This C# code shows you how to add a video to the presentation and then save it as HTML: 

```c#
// Loads a presentation
using (Presentation pres = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = pres.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Sets HTML options
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Saves the file
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```
