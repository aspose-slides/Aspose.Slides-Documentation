---
title: PowerPoint-Präsentationen in C++ in HTML konvertieren
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
- PPT zu HTML exportieren
- PPTX zu HTML exportieren
- C++
- Aspose.Slides
description: "PowerPoint-Präsentationen in C++ in HTML konvertieren. Verwenden Sie Aspose.Slides, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriften, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides for C++ kann PowerPoint‑Präsentationen als HTML speichern, ohne Microsoft PowerPoint zu benötigen. Die grundlegende Konvertierung besteht aus einem einzelnen [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)-Laden und einem `Save`‑Aufruf mit [SaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmloptions/), wenn Sie das exportierte Layout, Schriften, Bilder, Notizen, Kommentare, SVG‑Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Export einer gesamten Präsentation oder ausgewählter Folien.
- Erzeugen von festem Layout, responsivem oder SVG‑basiertem HTML.
- Einbinden von Sprecher-Notizen und Kommentaren.
- Steuerung der Bildqualität und beschnittener Bilddaten.
- Einbetten von Schriften oder getrennte Speicherung von Schriftdateien.
- Auswahl, wie externe Ressourcen und Mediendateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch für das Teilen einer einzigen Datei, kann jedoch die Ausgabengröße erhöhen. Für die Web‑Veröffentlichung sollten Sie externe Ressourcen, eine geringere Bild‑DPI und das Einbetten nur jener Schriften in Betracht ziehen, die in der Zielumgebung nicht zuverlässig verfügbar sind.

## **Eine Präsentation in HTML konvertieren**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und speichern sie mit `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Dieses Beispiel schreibt eine HTML‑Datei. Der Aufruf von `Dispose` gibt nach dem Export Dateihandles und Rendering‑Ressourcen frei.

## **HtmlOptions verwenden**

[HtmlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmloptions/) ist die zentrale Konfigurationsklasse für den HTML‑Export. Gängige Einstellungen umfassen:

- `SlidesLayoutOptions`: fügt Notizen, Kommentare, Handouts oder andere Layout‑Informationen hinzu.
- `HtmlFormatter`: ändert die HTML‑Dokumentstruktur oder delegiert die Formatierung an einen Controller.
- `SlideImageFormat`: ändert, wie Folien dargestellt werden, z. B. als SVG.
- `PicturesCompression`: steuert Bild‑DPI und Ausgabengröße.
- `DeletePicturesCroppedAreas`: behält oder entfernt beschnittene Bilddaten.
- `SvgResponsiveLayout`: lässt exportierten SVG‑Inhalt an seinen Container anpassen.
- `ShowHiddenSlides`: schließt versteckte Folien ein, wenn erforderlich.

Die folgenden Abschnitte zeigen die gängigsten Optionen einzeln, sodass Sie nur die Kombination auswählen können, die Ihr Workflow benötigt.

## **Ausgewählte Folien nach HTML konvertieren**

Der `Presentation::Save`‑Überladung, die Foliennummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die nachfolgende Schleife speichert jede Folie in einer separaten HTML‑Datei.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Verwenden Sie dieses Muster, wenn eine Website oder Anwendung für jede Folie eine eigene HTML‑Seite benötigt. Wenn jede Folie dasselbe Layout haben soll, erstellen Sie eine [HtmlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmloptions/)-Instanz und übergeben Sie sie bei jedem `Save`‑Aufruf.

## **Responsives HTML erzeugen**

[ResponsiveHtmlController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/responsivehtmlcontroller/) liefert responsiven HTML‑Output über [HtmlFormatter](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmlformatter/). Nutzen Sie ihn, wenn die exportierte Seite besser auf die Browser‑Breite reagieren soll.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Für ein SVG‑basiertes responsives Layout setzen Sie `SvgResponsiveLayout` auf [HtmlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmloptions/). Das ist nützlich, wenn der Folieninhalt als skalierbares SVG‑Markup exportiert wird.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Sprecher-Notizen und Kommentare einbinden**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notescommentslayoutingoptions/) über `HtmlOptions.SlidesLayoutOptions`, um Sprecher‑Notizen oder Kommentare einzubinden. Notizen und Kommentare sind standardmäßig ausgeblendet, sofern Sie nicht deren Position festlegen.

Angenommen, die Quell‑Präsentation enthält Sprecher‑Notizen:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Der folgende Code exportiert den Folieninhalt mit den Sprecher‑Notizen unterhalb der Folie.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Das exportierte HTML enthält den Notizen‑Bereich:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Um Kommentare zu exportieren, setzen Sie `CommentsPosition`, zum Beispiel auf `CommentsPositions::Right` oder `CommentsPositions::Bottom`. Wenn Sie nur Kommentare benötigen, lassen Sie `NotesPosition` weg. Wenn Sie sowohl Notizen als auch Kommentare benötigen, setzen Sie beide Eigenschaften.

## **Bildqualität und beschnittene Bereiche steuern**

Der HTML‑Export kann Folienbilder komprimieren, um die Ausgabengröße zu reduzieren. Setzen Sie `PicturesCompression` auf einen Wert aus [PicturesCompression](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/picturescompression/), wenn Sie höhere Bildqualität benötigen.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Standardmäßig können beschnittene Bildbereiche aus dem exportierten Output entfernt werden. Bewahren Sie beschnittene Daten nur dann auf, wenn Benutzer diese versteckten Bildteile wiederherstellen oder untersuchen müssen. Das Beibehalten kann die HTML‑Größe erhöhen.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **CSS hinzufügen**

Für einfache Gestaltung übergeben Sie einen CSS‑String an `HtmlFormatter::CreateDocumentFormatter`. Das ändert das umgebende HTML‑Dokument, während Aspose.Slides weiterhin den Folieninhalt rendert.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Für einen benutzerdefinierten Dokument‑Header, eine verknüpfte CSS‑Datei oder benutzerdefiniertes Markup um Folien und Formen herum, implementieren Sie [IHtmlFormattingController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ihtmlformattingcontroller/) und übergeben Sie ihn an [HtmlFormatter](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmlformatter/) mit `CreateCustomFormatter`.

## **Schriften einbetten**

Wenn die Zielumgebung die Präsentationsschriften nicht installiert hat, betten Sie Schriften in das HTML mit [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/embedallfontshtmlcontroller/) ein. Das Einbetten verbessert die visuelle Treue, erhöht jedoch die Ausgabengröße.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Schriften ausschließen Sie nur, wenn Sie sicher sind, dass die Ziel‑Browser oder -Systeme sie bereits bereitstellen. Für Marken‑Schriften oder weniger verbreitete Schriften ist das Einbetten in der Regel sicherer.

## **Schriftdateien verlinken statt einbetten**

Um die HTML‑Dateigröße zu reduzieren, können Sie Schrift‑Daten in separate WOFF‑Dateien schreiben und `@font-face`‑Regeln zum HTML hinzufügen. Der Hilfs‑Code unten erweitert [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/embedallfontshtmlcontroller/) und überschreibt `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

In diesem Beispiel werden Schriftdateien nach `html-output/fonts` gespeichert und das HTML referenziert sie mit URLs wie `fonts/BrandFont-normal-400.woff`. Wenn die HTML‑Datei und die Schriften an einem anderen Ort bereitgestellt werden, wählen Sie `fontUrlPrefix` so, dass es zum bereitgestellten URL‑Pfad passt.

## **Ressourcen extern speichern**

Eigenständiges HTML ist leicht zu verschieben, aber eingebettete Base64‑Ressourcen können die Datei groß werden lassen. Wenn Ihre Anwendung externe Bilddateien benötigt, implementieren Sie [ILinkEmbedController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/) und übergeben Sie ihn dem [HtmlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmloptions/)-Konstruktor.

Wenn Sie Ressourcen externalisieren, wählen Sie zwei Pfade bewusst:

- Den Dateisystem‑Ausgabepfad, in dem Ihre Anwendung erzeugte Bilder, Schriften, Audio‑ oder Videodateien schreibt.
- Den URL‑Pfad, den der Browser aus dem HTML‑Dokument verwendet, um diese Dateien zu laden.

## **Mediadateien exportieren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/videoplayerhtmlcontroller/) exportiert Video‑ und Audiodateien und schreibt HTML, das sie im Browser abspielen kann. Sein Konstruktor erwartet:

- `path`: das Verzeichnis, in das erzeugte Mediendateien geschrieben werden.
- `fileName`: der zu erzeugende HTML‑Dateiname.
- `baseUri`: das absolute URI‑Präfix, das in den HTML‑Links zu Mediendateien verwendet wird.

Wenn die HTML‑Datei `html-output/presentation.html` heißt und Mediendateien in `html-output/media` gespeichert werden, sollte `path` auf das Medien‑Verzeichnis im Dateisystem zeigen, während `baseUri` aus Browsersicht auf dasselbe Verzeichnis zeigen muss. Für lokale Vorschau können Sie aus dem Medien‑Verzeichnis eine `file:///`‑URI erzeugen. Für eine bereitgestellte Anwendung nutzen Sie die absolute URL des veröffentlichten Medien‑Verzeichnisses.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Verwenden Sie Ausgabeverzeichnisse, die pro Export‑Job eindeutig sind, insbesondere in Server‑Anwendungen. Gemeinsame Ausgabepfade können dazu führen, dass Dateien verschiedener Konvertierungen einander überschreiben.

## **Leistung und Ressourcenverwaltung**

HTML‑Konvertierung ist ein Rendering‑Vorgang, daher hängen Verarbeitungszeit und Speicherverbrauch von Folienzahl, Bildauflösung, Schriften, Effekten, Diagrammen und eingebetteten Medien ab. Höhere `PicturesCompression`‑DPI‑Werte, eingebettete Schriften, SVG‑Ausgabe und erhaltene beschnittene Bildbereiche können die Treue erhöhen, vergrößern jedoch in der Regel die Ausgabedatei.

Für Stapel‑Konvertierung:

- Dispose jede [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)-Instanz umgehend.
- Verwenden Sie separate Ausgabeverzeichnisse für einzelne Jobs.
- Betten Sie gängige Schriften nur ein, wenn die Treue es erfordert.
- Reduzieren Sie die Bild‑DPI, wenn das HTML nur für Vorschaubilder oder Thumbnails gedacht ist.
- Halten Sie Quell‑Präsentation, erzeugtes HTML und externe Ressourcen zusammen, bis die Bereitstellungspfade endgültig sind.

## **FAQ**

**Werden Hyperlinks im HTML‑Output erhalten?**

Ja. Präsentations‑Hyperlinks werden nach HTML exportiert und bleiben anklickbar, sofern die Ziel‑URL gültig ist.

**Kann ich Präsentationen parallel nach HTML konvertieren?**

Ja, aber teilen Sie keine einzelne [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)-Instanz über Threads hinweg. Verarbeiten Sie verschiedene Dateien mit separaten Präsentations‑Instanzen, separaten Streams und separaten Ausgabeverzeichnissen. Siehe die [multithreading guidance](/slides/de/cpp/multithreading/) für Details.

**Ist ein Presentation‑Objekt thread‑sicher?**

Nein. Eine einzelne [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)-Instanz sollte geladen, modifiziert, gespeichert und disposed auf einem einzigen Thread erfolgen. Für parallele Arbeit erstellen Sie pro Thread oder Prozess eine unabhängige Instanz.

**Warum ist die erzeugte HTML‑Datei groß?**

Der Standard‑Export kann Ressourcen direkt in das HTML einbetten. Eingebettete Schriften, hochauflösende Bilder, Medien, SVG‑Inhalt und beibehaltene beschnittene Bildbereiche erhöhen ebenfalls die Größe. Verwenden Sie externe Ressourcen, schließen Sie gängige Schriften vom Einbetten aus und reduzieren Sie `PicturesCompression`, wenn eine kleinere Datei wichtiger ist als maximale Treue.

**Wie wähle ich baseUri für den Media‑Export?**

Wählen Sie `baseUri` aus der Sicht des Browsers und übergeben Sie es als absolute URI. Für lokale Vorschau können Sie es aus dem Ausgabeverzeichnis mit `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()` ableiten. Für die Bereitstellung verwenden Sie die absolute URL des veröffentlichten Medien‑Verzeichnisses. Der Dateisystem‑`path` und der Browser‑`baseUri` müssen nicht dieselbe Zeichenfolge sein, sie müssen jedoch denselben Ressourcenort beschreiben.

**Kann ich versteckte Folien einbinden?**

Ja. Setzen Sie `ShowHiddenSlides` auf `true` bei [HtmlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmloptions/), wenn versteckte Folien exportiert werden müssen.