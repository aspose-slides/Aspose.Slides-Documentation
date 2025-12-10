---
title: PowerPoint-Präsentationen nach HTML in C++ konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/cpp/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint nach HTML
- Präsentation nach HTML
- Folie nach HTML
- PPT nach HTML
- PPTX nach HTML
- PowerPoint als HTML speichern
- Präsentation als HTML speichern
- Folie als HTML speichern
- PPT als HTML speichern
- PPTX als HTML speichern
- PPT nach HTML exportieren
- PPTX nach HTML exportieren
- C++
- Aspose.Slides
description: "PowerPoint-Präsentationen in responsives HTML in C++ konvertieren. Layout, Links und Bilder beibehalten mit dem Aspose.Slides-Konvertierungsleitfaden für schnelle, fehlerfreie Ergebnisse."
---

## **Überblick**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen in das HTML‑Format mit C++ konvertiert. Er behandelt die folgenden Themen.

- [PowerPoint nach HTML in C++ konvertieren](#convert-powerpoint-to-html)
- [PPT nach HTML in C++ konvertieren](#convert-powerpoint-to-html)
- [PPTX nach HTML in C++ konvertieren](#convert-powerpoint-to-html)
- [ODP nach HTML in C++ konvertieren](#convert-powerpoint-to-html)
- [PowerPoint‑Folie nach HTML in C++ konvertieren](#convert-slide-to-html)

## **PowerPoint nach HTML in C++**

Für C++‑Beispielcode zum Konvertieren von PowerPoint nach HTML siehe bitte den untenstehenden Abschnitt, d. h.[PowerPoint nach HTML konvertieren](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und in das HTML‑Format speichern.

## **Über die PowerPoint‑nach‑HTML‑Konvertierung**
Mit [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation nach HTML konvertieren: **PPTX nach HTML** oder **PPT nach HTML**.  

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)), die den PowerPoint‑nach‑HTML‑Konvertierungsprozess definieren:

* Gesamte PowerPoint‑Präsentation nach HTML konvertieren.  
* Eine bestimmte Folie einer PowerPoint‑Präsentation nach HTML konvertieren.  
* Präsentationsmedien (Bilder, Videos usw.) nach HTML konvertieren.  
* PowerPoint‑Präsentation in responsives HTML konvertieren.  
* PowerPoint‑Präsentation nach HTML konvertieren, wobei Rednernotizen ein‑ oder ausgeschlossen werden.  
* PowerPoint‑Präsentation nach HTML konvertieren, wobei Kommentare ein‑ oder ausgeschlossen werden.  
* PowerPoint‑Präsentation nach HTML konvertieren, mit originalen oder eingebetteten Schriftarten.  
* PowerPoint‑Präsentation nach HTML konvertieren und dabei den neuen CSS‑Stil verwenden.  

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT nach HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX nach HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP nach HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw.  

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie sich weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Zusätzlich zu den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides diese Konvertierungsoperationen mit dem HTML‑Format: 

* [HTML nach Bild](https://products.aspose.com/slides/cpp/conversion/html-to-image/)  
* [HTML nach JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)  
* [HTML nach XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)  
* [HTML nach TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)  

{{% /alert %}}

## **PowerPoint nach HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint‑Präsentation wie folgt nach HTML konvertieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
   * Laden Sie **.ppt** in die _Presentation_-Klasse, um **PPT nach HTML in C++ zu konvertieren**  
   * Laden Sie **.pptx** in die _Presentation_-Klasse, um **PPTX nach HTML in C++ zu konvertieren**  
   * Laden Sie **.odp** in die _Presentation_-Klasse, um **ODP nach HTML in C++ zu konvertieren**  
3. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020), um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie Sie ein PowerPoint in HTML in C++ konvertieren:
```cpp
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Speichern der Präsentation als HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **PowerPoint nach Responsive HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in C++ in responsives HTML konvertieren:
```cpp
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Speichern der Präsentation als HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **PowerPoint nach HTML mit Notizen konvertieren**
Dieser Code zeigt, wie Sie ein PowerPoint in HTML mit Notizen in C++ konvertieren:
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Notizseiten speichern
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **PowerPoint nach HTML mit Original‑Schriftarten konvertieren**
Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) zur Verfügung, mit der Sie beim Konvertieren einer Präsentation nach HTML alle Schriftarten einbetten können.  

Um das Einbetten bestimmter Schriftarten zu verhindern, können Sie dem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) ein Array von Schriftartnamen übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen in einer Präsentation nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Werden diese Schriftarten eingebettet, wird das resultierende HTML‑Dokument unnötig groß.  

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) unterstützt Vererbung und bietet die Methode [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77) an, die überschrieben werden soll. 
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// standardmäßige Präsentationsschriftarten ausschließen
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **PowerPoint nach HTML mit hochqualitativen Bildern konvertieren**
Standardmäßig gibt Aspose.Slides beim Konvertieren von PowerPoint nach HTML ein kleines HTML mit Bildern von 72 DPI und entfernten zugeschnittenen Bereichen aus. Um HTML‑Dateien mit höherwertigen Bildern zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der Klasse `HtmlOptions`) auf 96 (d.h. `PicturesCompression::Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8) setzen.  

Dieser C++‑Code zeigt, wie Sie eine PowerPoint‑Präsentation nach HTML konvertieren und dabei hochqualitative Bilder mit 150 DPI erhalten (d.h. `PicturesCompression::Dpi150`):
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


Dieser C++‑Code zeigt, wie Sie HTML mit Bildern in voller Qualität ausgeben:
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **Eine Folie nach HTML konvertieren**
Um eine bestimmte Folie einer PowerPoint‑Präsentation nach HTML zu konvertieren, müssen Sie dieselbe Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) instanziieren (die zum Konvertieren ganzer Präsentationen nach HTML verwendet wird) und dann die Methode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) nutzen, um die Datei als HTML zu speichern. Mit der Klasse [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) können zusätzliche Konvertierungsoptionen angegeben werden:  

Dieser C++‑Code zeigt, wie Sie eine Folie einer PowerPoint‑Präsentation nach HTML konvertieren:
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


## **CSS und Bilder beim Export nach HTML speichern**
Mit neuen CSS‑Stildateien können Sie das Layout der aus dem PowerPoint‑nach‑HTML‑Konvertierungsprozess resultierenden HTML‑Datei einfach ändern.  

Der C++‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML‑Dokument mit einem Link zu einer CSS‑Datei zu erstellen:
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
    // Der Pfad zum Dokumentenverzeichnis.
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```


## **Alle Schriftarten verlinken beim Konvertieren einer Präsentation nach HTML**
Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML nicht zu erhöhen), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren.  

Dieser C++‑Code zeigt, wie Sie ein PowerPoint nach HTML konvertieren, dabei alle Schriftarten verlinken und „Calibri“ sowie „Arial“ ausschließen (da sie bereits im System vorhanden sind):
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
        String path = String::Format(u"{0}.woff", fontName); // eventuell muss der Pfad bereinigt werden
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


## **PowerPoint nach Responsive HTML konvertieren**
Dieser C++‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in responsives HTML konvertieren:
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **Mediendateien nach HTML exportieren**
Mit Aspose.Slides for C++ können Sie Mediendateien folgendermaßen exportieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. Holen Sie eine Referenz auf die Folie.  
3. Fügen Sie der Folie ein Video hinzu.  
4. Schreiben Sie die Präsentation als HTML‑Datei.  

Dieser C++‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und anschließend als HTML speichern:
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

// Setzt HTML-Optionen
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// Speichert die Datei
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```


## **FAQ**

**Wie ist die Leistung von Aspose.Slides beim Konvertieren mehrerer Präsentationen nach HTML?**  
Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist für Batch‑Operationen hoch effizient und skalierbar. Für optimale Leistung beim Konvertieren vieler Präsentationen wird empfohlen, nach Möglichkeit Multithreading oder Parallelverarbeitung einzusetzen.

**Unterstützt Aspose.Slides den Export von Hyperlinks nach HTML?**  
Ja, Aspose.Slides unterstützt den Export eingebetteter Hyperlinks nach HTML vollständig. Beim Konvertieren von Präsentationen ins HTML‑Format werden Hyperlinks automatisch erhalten und bleiben anklickbar.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren von Präsentationen nach HTML?**  
Mit Aspose.Slides gibt es keine Begrenzung der Folienzahl. Sie können Präsentationen jeder Größe konvertieren. Bei Präsentationen mit einer sehr großen Folienanzahl kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.