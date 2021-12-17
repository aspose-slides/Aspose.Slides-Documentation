---
title: Convert Powerpoint to HTML
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-html/
keywords: "convert pptx to html, ppt to html, powerpoint to html, save pptx as html"
description: "Convert PowerPoint to HTML of any format: PPTX to HTML, PPT to HTML. Save PPTX to HTML and use PowerPoint HTML export."
---

## **About PowerPoint to HTML Conversion**
[**Aspose.Slides for C++** ](https://products.aspose.com/slides/cpp/)provides support for converting a PowerPoint presentation to HTML. With Aspose.Slides API you may set up the conversion process to enhance the resulting HTML. Both PPT to HTML and PPTX to HTML conversions are available.

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

In Aspose.Slides PowerPoint to HTML conversion is implemented with [**Save**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class. Conversion settings are not limited with the described above and are represented in [**HtmlOptions**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) class.



{{% alert color="primary" %}} 

Aspose.Slides proposes **online demo apps** to see alive the [**PPT to HTML**](https://products.aspose.app/slides/conversion/ppt-to-html)**,** [**PPTX to HTML**](https://products.aspose.app/slides/conversion/pptx-to-html), [**ODP to HTML**](https://products.aspose.app/slides/conversion/odp-to-html) conversion features supported:

[](https://products.aspose.app/slides/conversion/ppt-to-html)

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Find other live [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) examples.

{{% /alert %}} 


## **Convert Powerpoint to HTML**
Convert PPT or PPTX presentation to HTML file using Aspose.Slides. For that, save a PowerPoint presentation to HTML in two-lines:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Call [**Save** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)method from it specifying the resulting file as an HTML file:

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Instantiate a Presentation object that represents a presentation file
auto presentation = System::MakeObject<Presentation>(dataDir + u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Saving the presentation to HTML
presentation->Save(dataDir + u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **Convert Powerpoint to Responsive HTML**
Convert PPT(X) presentation to Responsive HTML, which will ensure the generated HTML will be displayed properly across all browsers and devices. [**ResponsiveHtmlController** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller)class provides the possibility to generate responsive HTML files. This controller can be used in the same manner as other HTML controllers:

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();
    
// Instantiate a Presentation object that represents a presentation file
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"Convert_HTML.pptx");

System::SharedPtr<ResponsiveHtmlController> controller = System::MakeObject<ResponsiveHtmlController>();
System::SharedPtr<HtmlOptions> htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Saving the presentation to HTML
presentation->Save(dataDir + u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```



## **Convert Powerpoint to HTML with Notes**
The following example shows how to convert PPT(X) presentation to HTML with the rendered speaker notes. Using the options of [**HtmlOptions**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) class and [**INotesCommentsLayoutingOptions** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)interface you can render speaker notes to HTML:

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>(dataDir + u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Saving notes pages
pres->Save(dataDir + u"Output.html", SaveFormat::Html, opt);
```



## **Convert Powerpoint to HTML with Original Fonts**
Preserve original fonts that are used in presentation while converting PPT(X) to HTML. [**EmbedAllFontsHtmlController** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller)class preserves the original fonts in generated HTML:

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>(u"input.pptx");

// exclude default presentation fonts
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```



## **Convert Slide to HTML**
Convert a separate presentation slide to HTML. Fo that use the same [**Save**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class that is used to convert the whole PPT(X) presentation into a HTML document. The [**HtmlOptions**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) class can be also used to set the additional conversion options:


``` cpp
class CustomFormattingController : public IHtmlFormattingController
{
public:
    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteDocumentEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteSlideStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(String::Format(SlideHeader, generator->get_SlideIndex() + 1));
    }
    void WriteSlideEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(SlideFooter);
    }
    void WriteShapeStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}
    void WriteShapeEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}

private:
    static const String SlideHeader;
    static const String SlideFooter;
};

const String CustomFormattingController::SlideHeader = u"<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
const String CustomFormattingController::SlideFooter = u"</div>";
```

``` cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>();
    auto htmlOptions = System::MakeObject<HtmlOptions>();
    htmlOptions->set_HtmlFormatter(formatter);

    // Saving File              
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```


## **Save CSS and Images when Exporting To HTML**
Use new CSS styles file to change the resulting styles of the HTML file while PPT(X) to HTML conversion with Aspose.Slides. Please review the example below how to use overridable methods to create a custom HTML document with a link to CSS file:

``` cpp
class CustomHeaderAndFontsController : public EmbedAllFontsHtmlController
{
public:
    CustomHeaderAndFontsController(String cssFileName)
        : m_cssFileName(cssFileName)
    {
    }

    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(System::String::Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    void WriteAllFonts(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(u"<!-- Embedded fonts -->");
        EmbedAllFontsHtmlController::WriteAllFonts(generator, presentation);
    }

private:
    static const String Header;
    String m_cssFileName;
};

const String CustomHeaderAndFontsController::Header = String(u"<!DOCTYPE html>\n") + 
u"<html>\n" + u"<head>\n" + 
u"<meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\">\n" + 
u"<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" + 
u"<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" + u"</head>";
```

``` cpp
void Run()
{
    // The path to the documents directory.
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```


## **Embed All Fonts When Converting Presentation to HTML**
Convert PPT(X) presentation to HTML with all its embedded fonts. [**EmbedAllFontsHtmlController** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller)class is used to embed all presentation fonts into HTML document. EmbedAllFontsHtmlController has a parameterized constructor where an array of font names can be passed to prevent them from embedding. Some fonts, like Calibri or Arial, used in the presentation are not needed to be embedded (which leads the resulting HTML document to become larger) because almost every system already has them installed. The EmbedAllFontsHtmlController also supports inheritance and WriteFont method that is intended to be overridden:

``` cpp
class LinkAllFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkAllFontsHtmlController(ArrayPtr<String> fontNameExcludeList, String basePath)
        :   EmbedAllFontsHtmlController(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    void WriteFont(SharedPtr<IHtmlGenerator> generator, SharedPtr<IFontData> originalFont, SharedPtr<IFontData> substitutedFont,
        String fontStyle, String fontWeight, ArrayPtr<uint8_t> fontData)
    {
        String fontName = substitutedFont == nullptr ? originalFont->get_FontName() : substitutedFont->get_FontName();
        String path = String::Format(u"{0}.woff", fontName);
        // some path sanitaze may be needed
        File::WriteAllBytes(Path::Combine(m_basePath, path), fontData);

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face { ");
        generator->AddHtml(String::Format(u"font-family: '{0}'; ", fontName));
        generator->AddHtml(String::Format(u"src: url('{0}')", path));

        generator->AddHtml(u" }");
        generator->AddHtml(u"</style>");
    }

private:
    String m_basePath;
};
```

``` cpp
void Run()
{
    System::String dataDir = GetDataPath();
    
    auto pres = System::MakeObject<Presentation>(dataDir + u"pres.pptx");

    // exclude default presentation fonts
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    //htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```


## **Support of SVG Responsive Property**
The code sample below shows how to export a PPT(X) presentation to HTML with the responsive layout:

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

auto presentation = System::MakeObject<Presentation>(dataDir + u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(dataDir + u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **Exporting Media Files to HTML file**
In order to export media files from PPT(X) presentation to HTML. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Get reference of the slide.
1. Setting the transition effect.
1. Write the presentation as a PPTX file.

In the example given below, we have exported the media files to HTML.

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

// Loading a presentation
auto pres = System::MakeObject<Presentation>(dataDir + u"Media File.pptx");

System::String path = dataDir;
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// Setting HTML options
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// Saving the file
pres->Save(Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```
