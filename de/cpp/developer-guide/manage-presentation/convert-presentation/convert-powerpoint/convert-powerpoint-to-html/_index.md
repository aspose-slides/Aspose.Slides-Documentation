---
title: PowerPoint in HTML umwandeln in C++
linktitle: PowerPoint in HTML umwandeln
type: docs
weight: 30
url: /de/cpp/convert-powerpoint-to-html/
keywords: "C++ PowerPoint in HTML, PowerPoint-Präsentation umwandeln, PPTX, PPT, PPT in HTML, PPTX in HTML, PowerPoint in HTML, PowerPoint als HTML speichern, PPT als HTML speichern, PPTX als HTML speichern, C++, CPP, Aspose.Slides, HTML-Export"
description: "PowerPoint HTML in C++ umwandeln. PPTX oder PPT als HTML in C++ speichern. Folien als HTML in C++ speichern."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation in HTML-Format mit C++ umwandelt. Er behandelt die folgenden Themen.

- [PowerPoint in HTML umwandeln in C++](#convert-powerpoint-to-html)
- [PPT in HTML umwandeln in C++](#convert-powerpoint-to-html)
- [PPTX in HTML umwandeln in C++](#convert-powerpoint-to-html)
- [ODP in HTML umwandeln in C++](#convert-powerpoint-to-html)
- [PowerPoint-Folie in HTML umwandeln in C++](#convert-slide-to-html)

## **C++ PowerPoint in HTML**

Für Beispielcode in C++, um PowerPoint in HTML umzuwandeln, siehe den Abschnitt unten, d.h. [PowerPoint in HTML umwandeln](#convert-powerpoint-to-html). Der Code kann eine Vielzahl von Formaten wie PPT, PPTX und ODP im Presentation-Objekt laden und in HTML-Format speichern.

## **Über die Umwandlung von PowerPoint in HTML**
Mit [**Aspose.Slides für C++**](https://products.aspose.com/slides/cpp/) können Anwendungen und Entwickler eine PowerPoint-Präsentation in HTML umwandeln: **PPTX in HTML** oder **PPT in HTML**. 

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) Klasse), die den Umwandlungsprozess von PowerPoint in HTML definieren:

* Eine gesamte PowerPoint-Präsentation in HTML umwandeln.
* Eine spezifische Folie in einer PowerPoint-Präsentation in HTML umwandeln.
* Präsentationsmedien (Bilder, Videos usw.) in HTML umwandeln.
* Eine PowerPoint-Präsentation in responsives HTML umwandeln. 
* Eine PowerPoint-Präsentation in HTML mit enthaltenen oder ausgeschlossenen Sprechernotizen umwandeln. 
* Eine PowerPoint-Präsentation in HTML mit enthaltenen oder ausgeschlossenen Kommentaren umwandeln. 
* Eine PowerPoint-Präsentation in HTML mit originalen oder eingebetteten Schriftarten umwandeln. 
* Eine PowerPoint-Präsentation in HTML umwandeln, während der neue CSS-Stil verwendet wird. 

{{% alert color="primary" %}} 

Mit seiner eigenen API entwickelte Aspose kostenlose [Präsentation in HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) Konverter: [PPT in HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX in HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP in HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Sie möchten vielleicht auch andere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ausprobieren.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Umwandlungsprozessen unterstützt Aspose.Slides auch diese Umwandlungsoperationen, die das HTML-Format betreffen: 

* [HTML zu Bild](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint in HTML umwandeln**
Mit Aspose.Slides können Sie eine gesamte PowerPoint-Präsentation auf folgende Weise in HTML umwandeln:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
   * Laden Sie **.ppt** in die _Presentation_ Klasse, um **PPT in HTML umwandeln in C++**.
   * Laden Sie **.pptx** in die _Presentation_ Klasse, um **PPTX in HTML umwandeln in C++**.
   * Laden Sie **.odp** in die _Presentation_ Klasse, um **ODP in HTML umwandeln in C++**.
3. Verwenden Sie die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) Methode, um das Objekt als HTML-Datei zu speichern.

Dieser Code zeigt Ihnen, wie man eine PowerPoint in HTML in C++ umwandelt:

```cpp
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Speichern der Präsentation als HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```

## **PowerPoint in responsives HTML umwandeln**
Aspose.Slides bietet die [ResponsiveHtmlController ](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) Klasse, die es Ihnen ermöglicht, responsive HTML-Dateien zu generieren. Dieser Code zeigt Ihnen, wie man eine PowerPoint-Präsentation in responsives HTML in C++ umwandelt:

```cpp
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Speichern der Präsentation als HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```

## **PowerPoint in HTML mit Notizen umwandeln**
Dieser Code zeigt Ihnen, wie man eine PowerPoint in HTML mit Notizen in C++ umwandelt:

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Speichern der Notizen-Seiten
pres->Save(u"Output.html", SaveFormat::Html, opt);
```

## **PowerPoint in HTML mit originalen Schriftarten umwandeln**
Aspose.Slides bietet die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) Klasse, die es Ihnen ermöglicht, alle Schriftarten in einer Präsentation während der Umwandlung in HTML einzubetten.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie ein Array von Schriftartnamen an einen parameterisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) Klasse übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen nicht eingebettet werden, da die meisten Systeme diese Schriftarten bereits enthalten. Wenn diese Schriftarten eingebettet werden, wird das resultierende HTML-Dokument unnötig groß.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) Klasse unterstützt Vererbung und bietet die Methode [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77), die überschrieben werden soll. 

```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// Standard-Präsentationsschriftarten ausschließen
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```

## **PowerPoint in HTML mit hochwertigen Bildern umwandeln**
Standardmäßig gibt Aspose.Slides beim Umwandeln von PowerPoint in HTML kleine HTML-Dateien mit Bildern bei 72 DPI aus und entfernt beschnittene Bereiche. Um HTML-Dateien mit qualitativ hochwertigen Bildern zu erhalten, müssen Sie die `PicturesCompression`-Eigenschaft (aus der `HtmlOptions`-Klasse) auf 96 (d.h. `PicturesCompression::Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8) setzen.

Dieser C++-Code zeigt Ihnen, wie man eine PowerPoint-Präsentation in HTML umwandelt, während qualitativ hochwertige Bilder mit 150 DPI (d.h. `PicturesCompression::Dpi150`) erhalten bleiben:

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```

Dieser Code in C++ zeigt Ihnen, wie man HTML mit Bildern in voller Qualität ausgibt:

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```

## **Folie in HTML umwandeln**
Um eine spezifische Folie in PowerPoint in HTML umzuwandeln, müssen Sie die gleiche [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse instanziieren (die verwendet wird, um gesamte Präsentationen in HTML umzuwandeln) und dann die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) Methode verwenden, um die Datei als HTML zu speichern. Die [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) Klasse kann verwendet werden, um zusätzliche Umwandlungsoptionen anzugeben:

Dieser C++-Code zeigt Ihnen, wie man eine Folie in einer PowerPoint-Präsentation in HTML umwandelt:

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

    // Datei speichern              
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```

## **CSS und Bilder beim Exportieren nach HTML speichern**
Mit neuen CSS-Stildateien können Sie den Stil der HTML-Datei, die aus dem Umwandlungsprozess von PowerPoint in HTML resultiert, einfach ändern. 

Der C++-Code in diesem Beispiel zeigt Ihnen, wie man überschreibbare Methoden verwendet, um ein benutzerdefiniertes HTML-Dokument mit einem Link zu einer CSS-Datei zu erstellen:

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
        generator->AddHtml(u"<!-- Eingebettete Schriftarten -->");
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
    // Der Pfad zum Dokumentenverzeichnis.
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```

## **Alle Schriftarten beim Umwandeln der Präsentation in HTML verlinken**
Wenn Sie keine Schriftarten einbetten möchten (um die Größe des resultierenden HTML zu vermeiden), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version des `LinkAllFontsHtmlController` implementieren. 

Dieser C++-Code zeigt Ihnen, wie man eine PowerPoint in HTML umwandelt, während alle Schriftarten verlinkt und "Calibri" und "Arial" ausgeschlossen werden (da sie bereits im System vorhanden sind):

```cpp
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
        String path = String::Format(u"{0}.woff", fontName); // einige Pfadbereinigungen können erforderlich sein
        IO::File::WriteAllBytes(IO::Path::Combine(m_basePath, path), fontData);

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
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // Standard-Präsentationsschriftarten ausschließen
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```

## **PowerPoint in responsives HTML umwandeln**
Dieser C++-Code zeigt Ihnen, wie man eine PowerPoint-Präsentation in responsives HTML umwandelt:

```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **Medien-Dateien nach HTML exportieren**
Mit Aspose.Slides für C++ können Sie Medien-Dateien folgendermaßen exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich eine Referenz zur Folie.
1. Fügen Sie der Folie ein Video hinzu.
1. Schreiben Sie die Präsentation als HTML-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Video zur Präsentation hinzufügt und dann als HTML speichert: 

```cpp
 // Lädt eine Präsentation
auto pres = System::MakeObject<Presentation>();

const System::String path = u"C:/out/";
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto fileStream = System::MakeObject<IO::FileStream>(u"my_video.avi", IO::FileMode::Open, IO::FileAccess::Read);

auto video = pres->get_Videos()->AddVideo(fileStream, Aspose::Slides::LoadingStreamBehavior::ReadStreamAndRelease);

auto slide = pres->get_Slides()->idx_get(0);
slide->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// HTML-Optionen setzen
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// Datei speichern
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```