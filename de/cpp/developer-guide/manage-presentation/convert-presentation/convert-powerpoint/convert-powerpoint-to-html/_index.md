---
title: PowerPoint-Präsentationen in HTML konvertieren in C++
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
- PowerPoint zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- PowerPoint als HTML speichern
- Präsentation als HTML speichern
- Folie als HTML speichern
- PPT als HTML speichern
- PPTX als HTML speichern
- PPT nach HTML exportieren
- PPTX nach HTML exportieren
- C++
- Aspose.Slides
description: "PowerPoint-Präsentationen in responsives HTML in C++ konvertieren. Layout, Links und Bilder mit der Aspose.Slides-Konvertierungsanleitung für schnelle, fehlerfreie Ergebnisse beibehalten."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im HTML‑Format mit C++ konvertiert. Er behandelt die folgenden Themen.

- [PowerPoint in HTML konvertieren in C++](#convert-powerpoint-to-html)
- [PPT in HTML konvertieren in C++](#convert-powerpoint-to-html)
- [PPTX in HTML konvertieren in C++](#convert-powerpoint-to-html)
- [ODP in HTML konvertieren in C++](#convert-powerpoint-to-html)
- [PowerPoint‑Folie in HTML konvertieren in C++](#convert-slide-to-html)

## **PowerPoint zu HTML in C++**

Für C++‑Beispielcode zum Konvertieren von PowerPoint zu HTML siehe den untenstehenden Abschnitt, d. h. [PowerPoint in HTML konvertieren](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und als HTML speichern.

## **Über die PowerPoint‑zu‑HTML‑Konvertierung**
Mit [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**. 

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)‑Klasse), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess definieren:

* Eine gesamte PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren. 
* Eine PowerPoint‑Präsentation in HTML mit oder ohne Redner‑Notizen konvertieren. 
* Eine PowerPoint‑Präsentation in HTML mit oder ohne Kommentare konvertieren. 
* Eine PowerPoint‑Präsentation in HTML mit originalen oder eingebetteten Schriftarten konvertieren. 
* Eine PowerPoint‑Präsentation in HTML unter Verwendung des neuen CSS‑Stils konvertieren. 

{{% alert color="primary" %}} 

Über die eigene API hat Aspose kostenlose [Presentation‑to‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) können Sie sich ansehen. 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Zusätzlich zu den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides folgende Vorgänge mit dem HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint in HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint‑Präsentation wie folgt in HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
   * Laden Sie **.ppt** in die _Presentation_-Klasse, um **PPT in HTML in C++** zu konvertieren.  
   * Laden Sie **.pptx** in die _Presentation_-Klasse, um **PPTX in HTML in C++** zu konvertieren.  
   * Laden Sie **.odp** in die _Presentation_-Klasse, um **ODP in HTML in C++** zu konvertieren.  
3. Verwenden Sie die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020)‑Methode, um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in C++ nach HTML konvertieren:
```cpp
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Präsentation in HTML speichern
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **PowerPoint in responsives HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in C++ in responsives HTML konvertieren:
```cpp
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Präsentation in HTML speichern
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **PowerPoint in HTML mit Notizen konvertieren**
Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in C++ mit Notizen nach HTML konvertieren:
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Saving notes pages
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **PowerPoint in HTML mit originalen Schriftarten konvertieren**
Aspose.Slides bietet die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) an, mit der Sie beim Konvertieren alle Schriftarten einbetten können.

Um bestimmte Schriftarten nicht einzubetten, können Sie dem parametrisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) ein Array von Schriftartnamen übergeben. Häufige Schriftarten wie Calibri oder Arial müssen nicht eingebettet werden, da die meisten Systeme sie bereits enthalten. Wenn diese Schriftarten dennoch eingebettet werden, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) unterstützt Vererbung und stellt die Methode [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77) bereit, die überschrieben werden kann. 
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// Standard‑Schriftarten der Präsentation ausschließen
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **PowerPoint in HTML mit hochqualitativen Bildern konvertieren**
Standardmäßig erzeugt Aspose.Slides beim Konvertieren von PowerPoint zu HTML kleine HTML‑Dateien mit Bildern bei 72 DPI und entfernt beschnittene Bildbereiche. Um HTML‑Dateien mit höherer Bildqualität zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der Klasse `HtmlOptions`) auf 96 (d. h. `PicturesCompression::Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8) setzen.

Dieser C++‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren und dabei hochwertige Bilder mit 150 DPI erhalten (d. h. `PicturesCompression::Dpi150`):
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


## **Eine Folie in HTML konvertieren**
Um eine bestimmte Folie einer PowerPoint‑Präsentation in HTML zu konvertieren, instanziieren Sie dieselbe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse (wie beim Konvertieren vollständiger Präsentationen) und verwenden anschließend die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020)‑Methode, um die Datei als HTML zu speichern. Mit der Klasse [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) können zusätzliche Konvertierungsoptionen angegeben werden:

Dieser C++‑Code zeigt, wie Sie eine Folie einer PowerPoint‑Präsentation in HTML konvertieren:
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
Mit neuen CSS‑Stildateien können Sie das Aussehen der HTML‑Datei, die aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess entsteht, leicht ändern. 

Der C++‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden nutzen, um ein benutzerdefiniertes HTML‑Dokument mit einem Verweis auf eine CSS‑Datei zu erstellen:
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


## **Alle Schriftarten verlinken, wenn eine Präsentation nach HTML konvertiert wird**
Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML zu reduzieren), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren. 

Dieser C++‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren, dabei alle Schriftarten verlinken und **Calibri** sowie **Arial** ausschließen (da sie bereits im System vorhanden sind):
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

```cpp
void Run()
{
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // Standard-Schriftarten der Präsentation ausschließen
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```


## **PowerPoint in responsives HTML konvertieren**
Dieser C++‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in responsives HTML konvertieren:
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```



## **Mediendateien nach HTML exportieren**
Mit Aspose.Slides for C++ können Sie Mediendateien wie folgt exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
2. Holen Sie sich eine Referenz zur Folie.  
3. Fügen Sie ein Video zur Folie hinzu.  
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

Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist sehr effizient und skalierbar für Batch‑Operationen. Für optimale Leistung beim Konvertieren vieler Präsentationen wird empfohlen, Multithreading oder Parallelverarbeitung zu nutzen, wann immer dies möglich ist.

**Unterstützt Aspose.Slides das Exportieren von Hyperlinks nach HTML?**

Ja, Aspose.Slides unterstützt das vollständige Exportieren eingebetteter Hyperlinks nach HTML. Beim Konvertieren von Präsentationen nach HTML werden Hyperlinks automatisch erhalten und bleiben anklickbar.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren von Präsentationen nach HTML?**

Es gibt keine Begrenzung der Folienzahl bei der Verwendung von Aspose.Slides. Sie können Präsentationen jeder Größe konvertieren. Bei sehr großen Präsentationen kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.