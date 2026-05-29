---
title: PowerPoint-Präsentationen in .NET in HTML konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Präsentationen in .NET in HTML konvertieren. Verwenden Sie Aspose.Slides, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriftarten, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides für .NET kann PowerPoint-Präsentationen als HTML speichern, ohne Microsoft PowerPoint zu benötigen. Die Grundkonvertierung besteht aus einem einzigen [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Laden und einem [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) Aufruf mit [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/), wenn Sie das exportierte Layout, Schriften, Bilder, Notizen, Kommentare, SVG‑Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Export einer gesamten Präsentation oder ausgewählter Folien.
- Erzeugen von HTML mit festem Layout, responsive Layout oder SVG‑basiertem HTML.
- Einbinden von Rednernotizen und Kommentaren.
- Steuern der Bildqualität und zugeschnittener Bilddaten.
- Einbetten von Schriftarten oder getrenntes Speichern von Schriftartdateien.
- Festlegen, wie externe Ressourcen und Mediendateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch für das Teilen einer einzelnen Datei, kann jedoch die Ausgabengröße erhöhen. Für die Webveröffentlichung sollten externe Ressourcen, niedrigere Bild‑DPI und das Einbetten nur jener Schriftarten in Betracht gezogen werden, die in der Zielumgebung nicht zuverlässig verfügbar sind.

## **Präsentation in HTML konvertieren**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) und speichern sie mit [SaveFormat.Html](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Dieses Beispiel schreibt eine HTML‑Datei. Das Präsentations‑Objekt wird durch die `using`‑Deklaration freigegeben, wodurch Dateihandles und Rendering‑Ressourcen nach dem Export freigegeben werden.

## **HtmlOptions verwenden**

[HtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/) ist die Hauptkonfigurationsklasse für den HTML‑Export. Häufige Einstellungen umfassen:

- `SlidesLayoutOptions`: Fügt Notizen, Kommentare, Handouts oder andere Layoutinformationen hinzu.
- `HtmlFormatter`: Ändert die HTML‑Dokumentstruktur oder delegiert die Formatierung an einen Controller.
- `SlideImageFormat`: Ändert, wie Folien dargestellt werden, z. B. als SVG.
- `PicturesCompression`: Steuert die Bild‑DPI und die Ausgabengröße.
- `DeletePicturesCroppedAreas`: Behaltet oder entfernt zugeschnittene Bilddaten.
- `SvgResponsiveLayout`: Lässt den exportierten SVG‑Inhalt an seinen Container anpassen.
- `ShowHiddenSlides`: Schließt bei Bedarf versteckte Folien ein.

Die folgenden Abschnitte zeigen die gebräuchlichsten Optionen einzeln, sodass Sie nur die für Ihren Workflow benötigten kombinieren können.

## **Ausgewählte Folien in HTML konvertieren**

Die Überladung von [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/), die Foliennummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die Schleife unten speichert jede Folie in einer separaten HTML‑Datei.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Verwenden Sie dieses Muster, wenn eine Website oder Anwendung für jede Folie eine HTML‑Seite benötigt. Wenn jede Folie dasselbe Layout haben soll, erstellen Sie eine [HtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/)‑Instanz und übergeben sie jedem `Save`‑Aufruf.

## **Responsives HTML erstellen**

[ResponsiveHtmlController](https://reference.aspose.com/slides/de/net/aspose.slides.export/responsivehtmlcontroller/) liefert responsiven HTML‑Ausgabe über [HtmlFormatter](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmlformatter/). Verwenden Sie es, wenn die exportierte Seite besser an die Browser‑Breite angepasst werden soll.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Für ein SVG‑basiertes responsives Layout setzen Sie `SvgResponsiveLayout` auf [HtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/). Dies ist nützlich, wenn der Folieninhalt als skalierbares SVG‑Markup exportiert wird.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Rednernotizen und Kommentare einbinden**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/notescommentslayoutingoptions/) über `HtmlOptions.SlidesLayoutOptions`, um Rednernotizen oder Kommentare einzufügen. Notizen und Kommentare sind standardmäßig ausgeblendet, sofern Sie nicht deren Positionen festlegen.

Angenommen, die Quellpräsentation enthält Rednernotizen:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Der folgende Code exportiert den Folieninhalt mit Rednernotizen unterhalb der Folie.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Um Kommentare zu exportieren, setzen Sie `CommentsPosition`, zum Beispiel auf `CommentsPositions.Right` oder `CommentsPositions.Bottom`. Wenn Sie nur Kommentare benötigen, lassen Sie `NotesPosition` weg. Wenn Sie sowohl Notizen als auch Kommentare benötigen, setzen Sie beide Eigenschaften.

## **Bildqualität und zugeschnittene Bereiche steuern**

Der HTML‑Export kann Folienbilder komprimieren, um die Ausgabengröße zu reduzieren. Setzen Sie `PicturesCompression` auf einen Wert aus [PicturesCompression](https://reference.aspose.com/slides/de/net/aspose.slides.export/picturescompression/), wenn Sie höhere Bildqualität benötigen.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Standardmäßig können zugeschnittene Bildbereiche aus dem exportierten Ergebnis entfernt werden. Behalten Sie zugeschnittene Daten nur, wenn Benutzer diese versteckten Bildteile wiederherstellen oder untersuchen müssen. Das Beibehalten kann die HTML‑Größe erhöhen.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **CSS hinzufügen**

Für einfache Gestaltung übergeben Sie einen CSS‑String an [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Dadurch wird das umgebende HTML‑Dokument geändert, während Aspose.Slides weiterhin den Folieninhalt rendert.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Für einen benutzerdefinierten Dokumentkopf, eine verknüpfte CSS‑Datei oder benutzerdefiniertes Markup um Folien und Formen herum implementieren Sie [IHtmlFormattingController](https://reference.aspose.com/slides/de/net/aspose.slides.export/ihtmlformattingcontroller/) und übergeben es an [HtmlFormatter](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmlformatter/) mit `CreateCustomFormatter`.

## **Schriftarten einbetten**

Falls die Zielumgebung die Präsentationsschriftarten nicht installiert hat, betten Sie Schriftarten im HTML mit [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/net/aspose.slides.export/embedallfontshtmlcontroller/) ein. Das Einbetten verbessert die visuelle Treue, erhöht jedoch die Ausgabengröße.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Schließen Sie Schriftarten nur aus, wenn Sie sicher sind, dass die Ziel‑Browser oder -Systeme sie bereits bereitstellen. Für Marken‑ oder weniger verbreitete Schriftarten ist das Einbetten meist sicherer.

## **Schriftdateien verlinken anstatt sie einzubetten**

Um die HTML‑Dateigröße zu reduzieren, können Sie Schriftartdaten in separate WOFF‑Dateien schreiben und `@font-face`‑Regeln zum HTML hinzufügen. Der Hilfs‑Code unten erweitert [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/net/aspose.slides.export/embedallfontshtmlcontroller/) und überschreibt `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```
```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

In diesem Beispiel werden Schriftdateien in `html-output/fonts` gespeichert, und das HTML verweist mit URLs wie `fonts/BrandFont-normal-400.woff` darauf. Wenn die HTML‑Datei und die Schriftarten an einem anderen Ort bereitgestellt werden, wählen Sie `fontUrlPrefix` so, dass es zum bereitgestellten URL‑Pfad passt.

## **Ressourcen extern speichern**

Eigenständiges HTML ist leicht zu verschieben, aber eingebettete Base64‑Ressourcen können die Datei groß machen. Wenn Ihre Anwendung externe Bilddateien benötigt, implementieren Sie [ILinkEmbedController](https://reference.aspose.com/slides/de/net/aspose.slides.export/ilinkembedcontroller/) und übergeben ihn dem Konstruktor von [HtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/htmloptions/).

Wenn Sie Ressourcen externisieren, wählen Sie bewusst zwei Pfade:

- Den Ausgabepfad im Dateisystem, in dem Ihre Anwendung generierte Bilder, Schriftarten, Audio‑ oder Videodateien schreibt.
- Den URL‑Pfad, den der Browser aus dem HTML‑Dokument verwendet, um diese Dateien zu laden.

Für eine vollständige Bild‑Verlinkungs‑Implementierung siehe [Export Presentations to HTML with Externally Linked Images](/slides/de/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Mediendateien exportieren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/de/net/aspose.slides.export/videoplayerhtmlcontroller/) exportiert Video‑ und Audiodateien und erzeugt HTML, das sie im Browser abspielen kann. Der Konstruktor akzeptiert:

- `path`: Das Verzeichnis, in das generierte Mediendateien geschrieben werden.
- `fileName`: Der zu erzeugende HTML‑Dateiname.
- `baseUri`: Der absolute URI‑Präfix, der in den HTML‑Links zu Mediendateien verwendet wird.

Wenn die HTML‑Datei `html-output/presentation.html` lautet und Mediendateien in `html-output/media` gespeichert werden, sollte `path` auf das Medien‑Verzeichnis auf dem Datenträger zeigen, während `baseUri` aus der Sicht des Browsers auf dasselbe Verzeichnis verweisen sollte. Für eine lokale Vorschau können Sie aus dem Medien‑Verzeichnis eine `file:///`‑URI erstellen. Für eine bereitgestellte Anwendung verwenden Sie die absolute URL des veröffentlichten Medien‑Verzeichnisses.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Verwenden Sie Ausgabeverzeichnisse, die pro Export‑Job eindeutig sind, besonders in Server‑Anwendungen. Gemeinsame Ausgabepfade können dazu führen, dass Dateien verschiedener Konvertierungen einander überschreiben.

## **Leistung und Ressourcenverwaltung**

Die HTML‑Konvertierung ist ein Rendering‑Vorgang, daher hängen Verarbeitungszeit und Speicherverbrauch von der Folienzahl, Bildauflösung, Schriftarten, Effekten, Diagrammen und eingebetteten Medien ab. Höhere `PicturesCompression`‑DPI‑Werte, eingebettete Schriftarten, SVG‑Ausgabe und beibehaltene zugeschnittene Bildbereiche können die Treue erhöhen, vergrößern jedoch in der Regel die Ausgabengröße.

Für die Stapelkonvertierung:

- Verwerfen Sie jede [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Instanz unverzüglich.
- Verwenden Sie separate Ausgabeverzeichnisse für separate Aufträge.
- Vermeiden Sie das Einbetten gängiger Schriftarten, sofern die Treue es nicht erfordert.
- Niedrigere Bild‑DPI verwenden, wenn das HTML für Vorschau oder Miniaturansichten gedacht ist.
- Bewahren Sie die Quellpräsentation, das erzeugte HTML und externe Ressourcen zusammen, bis die Bereitstellungspfade endgültig sind.

## **FAQ**

**Werden Hyperlinks im HTML‑Ausgabe erhalten?**

Ja. Präsentations‑Hyperlinks werden nach HTML exportiert und bleiben anklickbar, sofern die Ziel‑URL gültig ist.

**Kann ich Präsentationen parallel in HTML konvertieren?**

Ja, jedoch sollten Sie nicht dieselbe [Presentation]‑Instanz über mehrere Threads hinweg teilen. Verarbeiten Sie verschiedene Dateien mit separaten Präsentations‑Instanzen, separaten Streams und separaten Ausgabeverzeichnissen. Siehe die [multithreading guidance](/slides/de/net/multithreading/) für Details.

**Ist ein Presentation‑Objekt Thread‑sicher?**

Nein. Eine einzelne [Presentation]‑Instanz sollte in einem Thread geladen, geändert, gespeichert und verworfen werden. Für parallele Arbeit erstellen Sie pro Thread oder Prozess eine eigene Instanz.

**Warum ist die erzeugte HTML‑Datei groß?**

Der Standard‑Export kann Ressourcen direkt in das HTML einbetten. Eingebettete Schriftarten, hoch‑DPI‑Bilder, Medien, SVG‑Inhalte und beibehaltene zugeschnittene Bildbereiche erhöhen ebenfalls die Größe. Verwenden Sie externe Ressourcen, schließen Sie gängige Schriftarten vom Einbetten aus und reduzieren Sie `PicturesCompression`, wenn eine kleinere Ausgabe wichtiger ist als maximale Treue.

**Wie sollte ich baseUri für den Medien‑Export wählen?**

Wählen Sie `baseUri` aus der Sicht des Browsers und übergeben Sie ihn als absolute URI. Für eine lokale Vorschau können Sie ihn aus dem Ausgabeverzeichnis mit `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` ableiten. Für die Bereitstellung verwenden Sie die absolute URL des veröffentlichten Medienverzeichnisses. Der Datei‑System‑`path` und der Browser‑`baseUri` müssen nicht dieselbe Zeichenkette sein, sie müssen jedoch denselben Ressourcenort beschreiben.

**Kann ich versteckte Folien einbinden?**

Ja. Setzen Sie `ShowHiddenSlides = true` auf [HtmlOptions]…, wenn versteckte Folien exportiert werden müssen.