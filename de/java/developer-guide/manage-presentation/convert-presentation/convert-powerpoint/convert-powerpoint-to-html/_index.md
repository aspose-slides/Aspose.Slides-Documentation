---
title: PowerPoint-Präsentationen in HTML konvertieren in Java
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen in HTML in Java konvertieren. Verwenden Sie Aspose.Slides, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriftarten, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides for Java kann PowerPoint-Präsentationen als HTML speichern, ohne Microsoft PowerPoint zu benötigen. Die Grundkonvertierung besteht aus einem einzelnen Laden einer [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) und einem Aufruf von `save` mit [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/), wenn Sie das exportierte Layout, Schriftarten, Bilder, Notizen, Kommentare, SVG-Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Exportieren einer gesamten Präsentation oder ausgewählter Folien.
- Erzeugen von festem Layout, responsivem oder SVG‑basiertem HTML.
- Einbinden von Rednernoten und Kommentaren.
- Steuerung der Bildqualität und zugeschnittener Bilddaten.
- Einbetten von Schriftarten oder getrenntes Speichern von Schriftdateien.
- Auswahl, wie externe Ressourcen und Mediendateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch, um eine einzige Datei zu teilen, kann jedoch die Ausgabengröße erhöhen. Für die Web‑veröffentlichung sollten Sie externe Ressourcen, geringere Bild‑DPI und das Einbetten von Schriftarten nur dann in Betracht ziehen, wenn diese im Zielumfeld nicht zuverlässig verfügbar sind.

## **Konvertieren einer Präsentation in HTML**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) und speichern sie mit [SaveFormat.Html](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Dieses Beispiel schreibt eine HTML‑Datei. Das Präsentationsobjekt wird im `finally`‑Block freigegeben, wodurch nach dem Export Datei‑Handles und Rendering‑Ressourcen freigegeben werden.

## **Verwenden von HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/) ist die Hauptkonfigurationsklasse für den HTML‑Export. Häufige Einstellungen umfassen:

- `SlidesLayoutOptions`: fügt Notizen, Kommentare, Handzettel oder andere Layout‑Informationen hinzu.
- `HtmlFormatter`: ändert die Struktur des HTML‑Dokuments oder delegiert die Formatierung an einen Controller.
- `SlideImageFormat`: ändert, wie Folien dargestellt werden, beispielsweise als SVG.
- `PicturesCompression`: steuert die Bild‑DPI und die Ausgabengröße.
- `DeletePicturesCroppedAreas`: behält oder entfernt zugeschnittene Bilddaten.
- `SvgResponsiveLayout`: lässt den exportierten SVG‑Inhalt an seinen Container anpassen.
- `ShowHiddenSlides`: schließt versteckte Folien ein, wenn erforderlich.

Die folgenden Abschnitte zeigen die am häufigsten verwendeten Optionen einzeln, sodass Sie nur die Kombination wählen können, die Ihr Arbeitsablauf benötigt.

## **Ausgewählte Folien in HTML konvertieren**

Die `Presentation.save`‑Überladung, die Foliennummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die nachstehende Schleife speichert jede Folie in einer separaten HTML‑Datei.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Verwenden Sie dieses Muster, wenn eine Website oder Anwendung für jede Folie eine HTML‑Seite benötigt. Wenn jede Folie dasselbe Layout haben soll, erstellen Sie eine [HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/)‑Instanz und übergeben Sie sie jedem `save`‑Aufruf.

## **Responsive HTML erstellen**

[ResponsiveHtmlController](https://reference.aspose.com/slides/de/java/com.aspose.slides/responsivehtmlcontroller/) liefert responsiven HTML‑Ausgabe über [HtmlFormatter](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmlformatter/). Verwenden Sie ihn, wenn die exportierte Seite sich besser an die Browser‑Breite anpassen soll.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Für ein SVG‑basiertes responsives Layout setzen Sie `SvgResponsiveLayout` auf [HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/). Dies ist nützlich, wenn der Folieninhalt als skalierbares SVG‑Markup exportiert wird.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Rednernoten und Kommentare einbinden**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/notescommentslayoutingoptions/) über `HtmlOptions.setSlidesLayoutOptions`, um Rednernoten oder Kommentare einzubinden. Notizen und Kommentare sind standardmäßig ausgeblendet, es sei denn, Sie wählen deren Positionen.

Angenommen, die Quellpräsentation enthält Rednernoten:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Der folgende Code exportiert den Folieninhalt mit Rednernoten unterhalb der Folie.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Um Kommentare zu exportieren, setzen Sie `CommentsPosition`, z. B. auf `CommentsPositions.Right` oder `CommentsPositions.Bottom`. Wenn Sie nur Kommentare benötigen, lassen Sie `NotesPosition` weg. Wenn Sie sowohl Notizen als auch Kommentare benötigen, setzen Sie beide Eigenschaften.

## **Bildqualität und zugeschnittene Bereiche steuern**

Der HTML‑Export kann Folienbilder komprimieren, um die Ausgabengröße zu reduzieren. Setzen Sie `PicturesCompression` auf einen Wert aus [PicturesCompression](https://reference.aspose.com/slides/de/java/com.aspose.slides/picturescompression/), wenn Sie höhere Bildqualität benötigen.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Standardmäßig können zugeschnittene Bildbereiche aus der exportierten Ausgabe entfernt werden. Bewahren Sie zugeschnittene Daten nur dann auf, wenn Nutzer diese versteckten Bildteile wiederherstellen oder untersuchen müssen. Das Beibehalten kann die HTML‑Größe erhöhen.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS hinzufügen**

Für einfache Gestaltung übergeben Sie einen CSS‑String an `HtmlFormatter.createDocumentFormatter`. Dies ändert das umgebende HTML‑Dokument, während Aspose.Slides weiterhin den Folieninhalt rendert.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Für einen benutzerdefinierten Dokumentenkopf, eine verknüpfte CSS‑Datei oder benutzerdefiniertes Markup um Folien und Formen herum implementieren Sie [IHtmlFormattingController](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihtmlformattingcontroller/) und übergeben es an [HtmlFormatter](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmlformatter/) mit `createCustomFormatter`.

## **Schriftarten einbetten**

Falls die Zielumgebung die in der Präsentation verwendeten Schriftarten nicht installiert hat, betten Sie Schriftarten mit [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/java/com.aspose.slides/embedallfontshtmlcontroller/) in das HTML ein. Das Einbetten verbessert die visuelle Wiedergabetreue, erhöht jedoch die Ausgabengröße.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Schließen Sie Schriftarten nur dann aus, wenn Sie sicher sind, dass die Ziel‑Browser oder -Systeme sie bereits bereitstellen. Für Marken‑Schriftarten oder weniger verbreitete Schriftarten ist das Einbetten in der Regel sicherer.

## **Schriftdateien verlinken anstatt sie einzubetten**

Um die HTML‑Dateigröße zu reduzieren, können Sie Schriftartdaten in separate WOFF‑Dateien schreiben und `@font-face`‑Regeln zum HTML hinzufügen. Der folgende Helfer erweitert [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/java/com.aspose.slides/embedallfontshtmlcontroller/) und überschreibt `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

In diesem Beispiel werden Schriftdateien in `html-output/fonts` gespeichert und das HTML verweist mit URLs wie `fonts/BrandFont-normal-400.woff` darauf. Wenn die HTML‑Datei und die Schriftdateien an einem anderen Ort bereitgestellt werden, wählen Sie `fontUrlPrefix` so, dass es dem bereitgestellten URL‑Pfad entspricht.

## **Ressourcen extern speichern**

Eigenständiges HTML lässt sich leicht verschieben, aber eingebettete Base64‑Ressourcen können die Datei groß machen. Wenn Ihre Anwendung externe Bilddateien benötigt, implementieren Sie [ILinkEmbedController](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) und übergeben ihn dem Konstruktor von [HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/).

Wenn Sie Ressourcen externalisieren, wählen Sie bewusst zwei Pfade:

- Den Dateisystem‑Ausgabepfad, in dem Ihre Anwendung erzeugte Bilder, Schriftarten, Audio‑ oder Videodateien schreibt.
- Den URL‑Pfad, den der Browser aus dem HTML‑Dokument verwendet, um diese Dateien zu laden.

## **Mediendateien exportieren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoplayerhtmlcontroller/) exportiert Video‑ und Audiodateien und schreibt HTML, das sie in einem Browser abspielen kann. Sein Konstruktor nimmt:

- `path`: Das Verzeichnis, in das erzeugte Mediendateien geschrieben werden.
- `fileName`: Der Name der erzeugten HTML‑Datei.
- `baseUri`: Das absolute URI‑Präfix, das in den HTML‑Links zu Mediendateien verwendet wird.

Wenn die HTML‑Datei `html-output/presentation.html` ist und Mediendateien in `html-output/media` gespeichert werden, sollte `path` auf das Medien‑Verzeichnis auf dem Datenträger zeigen, während `baseUri` aus Sicht des Browsers auf dasselbe Verzeichnis zeigen sollte. Für lokale Vorschau können Sie aus dem Medien‑Verzeichnis eine `file:///`‑URI erstellen. Für eine bereitgestellte Anwendung verwenden Sie die absolute URL des veröffentlichten Medien‑Verzeichnisses.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Verwenden Sie Ausgabeverzeichnisse, die pro Export‑Auftrag eindeutig sind, insbesondere in Server‑Anwendungen. Gemeinsame Ausgabepfade können dazu führen, dass Dateien verschiedener Konvertierungen einander überschreiben.

## **Leistung und Ressourcenverwaltung**

Die HTML‑Konvertierung ist ein Rendering‑Vorgang, sodass Verarbeitungszeit und Speicherverbrauch von der Folienanzahl, Bildauflösung, Schriftarten, Effekten, Diagrammen und eingebetteten Medien abhängen. Höhere `PicturesCompression`‑DPI‑Werte, eingebettete Schriftarten, SVG‑Ausgabe und das Beibehalten zugeschnittener Bildbereiche können die Treue erhöhen, vergrößern jedoch typischerweise die Ausgabengröße.

Für Batch‑Konvertierung:

- Geben Sie jede [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz unverzüglich frei.
- Verwenden Sie separate Ausgabeverzeichnisse für unterschiedliche Aufträge.
- Vermeiden Sie das Einbetten gängiger Schriftarten, es sei denn, die Treue erfordert es.
- Reduzieren Sie die Bild‑DPI, wenn das HTML für Vorschaubilder oder Thumbnails gedacht ist.
- Bewahren Sie die Quellpräsentation, das erzeugte HTML und externe Ressourcen gemeinsam auf, bis die Bereitstellungspfade final sind.

## **FAQ**

**Werden Hyperlinks im HTML‑Output beibehalten?**

Ja. Präsentations‑Hyperlinks werden nach HTML exportiert und bleiben anklickbar, wenn die Ziel‑URL gültig ist.

**Kann ich Präsentationen parallel nach HTML konvertieren?**

Ja, aber teilen Sie keine einzelne [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz über mehrere Threads hinweg. Verarbeiten Sie verschiedene Dateien mit separaten Präsentations‑Instanzen, separaten Streams und separaten Ausgabeverzeichnissen. Siehe die [multithreading guidance](/slides/de/java/multithreading/) für Details.

**Ist ein Presentation‑Objekt thread‑sicher?**

Nein. Eine einzelne [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz sollte in einem Thread geladen, geändert, gespeichert und freigegeben werden. Für parallele Arbeit erstellen Sie pro Thread oder Prozess eine unabhängige Instanz.

**Warum ist die erzeugte HTML‑Datei groß?**

Der Standard‑Export kann Ressourcen direkt in das HTML einbetten. Eingebettete Schriftarten, hoch‑DPI‑Bilder, Medien, SVG‑Inhalt und das Beibehalten zugeschnittener Bildbereiche erhöhen ebenfalls die Größe. Verwenden Sie externe Ressourcen, schließen Sie gängige Schriftarten vom Einbetten aus und reduzieren Sie `PicturesCompression`, wenn eine kleinere Ausgabe wichtiger ist als maximale Treue.

**Wie soll ich baseUri für den Medien‑Export wählen?**

Wählen Sie `baseUri` aus Sicht des Browsers und übergeben Sie ihn als absolute URI. Für lokale Vorschau können Sie ihn aus dem Ausgabeverzeichnis mit `mediaDirectory.toUri().toString()` ableiten. Für die Bereitstellung verwenden Sie die absolute URL des veröffentlichten Medienverzeichnisses. Der Dateisystem‑`path` und der Browser‑`baseUri` müssen nicht dieselbe Zeichenkette sein, sie müssen jedoch denselben Ressourcenort beschreiben.

**Kann ich versteckte Folien einbinden?**

Ja. Setzen Sie `ShowHiddenSlides` auf `true` bei [HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/), wenn versteckte Folien exportiert werden müssen.