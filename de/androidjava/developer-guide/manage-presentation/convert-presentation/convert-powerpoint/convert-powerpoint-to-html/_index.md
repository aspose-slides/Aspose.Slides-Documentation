---
title: "PowerPoint-Präsentationen auf Android in HTML konvertieren"
linktitle: "PowerPoint zu HTML"
type: docs
weight: 30
url: /de/androidjava/convert-powerpoint-to-html/
keywords:
- "PowerPoint konvertieren"
- "Präsentation konvertieren"
- "Folie konvertieren"
- "PPT konvertieren"
- "PPTX konvertieren"
- "PowerPoint zu HTML"
- "Präsentation zu HTML"
- "Folie zu HTML"
- "PPT zu HTML"
- "PPTX zu HTML"
- "PowerPoint als HTML speichern"
- "Präsentation als HTML speichern"
- "Folie als HTML speichern"
- "PPT als HTML speichern"
- "PPTX als HTML speichern"
- "PPT nach HTML exportieren"
- "PPTX nach HTML exportieren"
- "Android"
- "Java"
- "Aspose.Slides"
description: "PowerPoint-Präsentationen auf Android in HTML konvertieren. Verwenden Sie Aspose.Slides für Android über Java, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriftarten, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides für Android über Java kann PowerPoint‑Präsentationen als HTML speichern, ohne Microsoft PowerPoint zu benötigen. Die grundlegende Konvertierung besteht aus einem einzigen [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Laden und einem Aufruf von `save` mit [SaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmloptions/), wenn Sie das exportierte Layout, Schriftarten, Bilder, Notizen, Kommentare, SVG‑Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Exportieren einer gesamten Präsentation oder ausgewählter Folien.
- Erzeugen von festem Layout, responsivem oder SVG‑basiertem HTML.
- Einbinden von Rednernotizen und Kommentaren.
- Steuern der Bildqualität und beschnittener Bilddaten.
- Schriftarten einbetten oder Schriftdateien separat speichern.
- Auswählen, wie externe Ressourcen und Mediendateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch für die Freigabe einer einzigen Datei, kann jedoch die Ausgabengröße erhöhen. Für die Web‑Veröffentlichung sollten externe Ressourcen, ein niedrigeres Bild‑DPI und das Einbetten nur jener Schriftarten, die in der Zielumgebung nicht zuverlässig verfügbar sind, in Betracht gezogen werden.

## **Konvertieren einer Präsentation in HTML**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) und speichern sie mit [SaveFormat.Html](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Dieses Beispiel schreibt eine HTML‑Datei. Das Präsentationsobjekt wird im `finally`‑Block freigegeben, wodurch Dateihandles und Rendering‑Resourcen nach dem Export freigegeben werden.

## **Verwenden von HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmloptions/) ist die Hauptkonfigurationsklasse für den HTML‑Export. Häufige Einstellungen umfassen:

- `SlidesLayoutOptions`: fügt Notizen, Kommentare, Handouts oder andere Layout‑Informationen hinzu.
- `HtmlFormatter`: ändert die HTML‑Dokumentstruktur oder delegiert die Formatierung an einen Controller.
- `SlideImageFormat`: ändert, wie Folien dargestellt werden, zum Beispiel als SVG.
- `PicturesCompression`: steuert Bild‑DPI und Ausgabengröße.
- `DeletePicturesCroppedAreas`: behält beschnittene Bilddaten bei oder entfernt sie.
- `SvgResponsiveLayout`: lässt exportierten SVG‑Inhalt an seinen Container anpassen.
- `ShowHiddenSlides`: schließt versteckte Folien ein, wenn erforderlich.

Die folgenden Abschnitte zeigen die gebräuchlichsten Optionen einzeln, sodass Sie nur die für Ihren Arbeitsablauf benötigten kombinieren können.

## **Ausgewählte Folien zu HTML konvertieren**

Die Überladung `Presentation.save`, die Foliennummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die nachfolgende Schleife speichert jede Folie in einer separaten HTML‑Datei.

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

Verwenden Sie dieses Muster, wenn eine Website oder Anwendung für jede Folie eine HTML‑Seite benötigt. Wenn jede Folie dasselbe Layout haben soll, erstellen Sie eine [HtmlOptions]‑Instanz und übergeben Sie sie jedem `save`‑Aufruf.

## **Responsives HTML erstellen**

[ResponsiveHtmlController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/responsivehtmlcontroller/) liefert responsiven HTML‑Output über [HtmlFormatter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmlformatter/). Verwenden Sie ihn, wenn die exportierte Seite besser an die Browser‑Breite angepasst werden soll.

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

Für ein SVG‑basiertes responsives Layout setzen Sie `SvgResponsiveLayout` auf [HtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmloptions/). Dies ist nützlich, wenn der Folieninhalt als skalierbares SVG‑Markup exportiert wird.

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

## **Rednernotizen und Kommentare einbinden**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notescommentslayoutingoptions/) über `HtmlOptions.SlidesLayoutOptions`, um Rednernotizen oder Kommentare einzubinden. Notizen und Kommentare sind standardmäßig ausgeblendet, es sei denn, Sie wählen deren Positionen.

![Folie mit Rednernotizen in PowerPoint](slide_with_notes.png)

Der folgende Code exportiert den Folieninhalt mit Rednernotizen unterhalb der Folie.

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

![HTML‑Ausgabe mit der Folie und Rednernotizen](HTML_with_notes.png)

Um Kommentare zu exportieren, setzen Sie `CommentsPosition`, zum Beispiel auf `CommentsPositions.Right` oder `CommentsPositions.Bottom`. Wenn Sie nur Kommentare benötigen, lassen Sie `NotesPosition` weg. Wenn Sie sowohl Notizen als auch Kommentare benötigen, setzen Sie beide Eigenschaften.

## **Bildqualität und beschnittene Bereiche steuern**

Der HTML‑Export kann Folienbilder komprimieren, um die Ausgabengröße zu reduzieren. Setzen Sie `PicturesCompression` auf einen Wert aus [PicturesCompression](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/picturescompression/), wenn Sie höhere Bildqualität benötigen.

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

Standardmäßig können beschnittene Bildbereiche aus der exportierten Ausgabe entfernt werden. Bewahren Sie beschnittene Daten nur dann auf, wenn Benutzer in der Lage sein müssen, diese verborgenen Bildteile wiederherzustellen oder zu prüfen. Das Beibehalten kann die HTML‑Größe erhöhen.

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

Für einfache Formatierungen übergeben Sie einen CSS‑String an `HtmlFormatter.createDocumentFormatter`. Dadurch wird das umgebende HTML‑Dokument geändert, während Aspose.Slides weiterhin den Folieninhalt rendert.

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

Für einen benutzerdefinierten Dokumentkopf, eine verknüpfte CSS‑Datei oder benutzerdefiniertes Markup um Folien und Formen implementieren Sie [IHtmlFormattingController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihtmlformattingcontroller/) und übergeben es an [HtmlFormatter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmlformatter/) mit `createCustomFormatter`.

## **Schriftarten einbetten**

Falls die Zielumgebung die Präsentationsschriftarten nicht installiert hat, betten Sie die Schriftarten mit [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) in das HTML ein. Das Einbetten verbessert die visuelle Treue, erhöht jedoch die Ausgabengröße.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Schließen Sie Schriftarten nur aus, wenn Sie sicher sind, dass die Ziel‑Browser oder -Systeme sie bereits bereitstellen. Für Marken‑ oder weniger verbreitete Schriftarten ist das Einbetten in der Regel sicherer.

## **Schriftdateien verlinken anstatt sie einzubetten**

Um die HTML‑Dateigröße zu reduzieren, können Sie Schriftartdaten in separate WOFF‑Dateien schreiben und `@font-face`‑Regeln zum HTML hinzufügen. Der Hilfs‑Code unten erweitert [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) und überschreibt `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

In diesem Beispiel werden Schriftdateien nach `html-output/fonts` gespeichert und das HTML verweist mit URLs wie `fonts/BrandFont-normal-400.woff` darauf. Wenn die HTML‑Datei und die Schriftarten an einem anderen Ort bereitgestellt werden, wählen Sie `fontUrlPrefix` so, dass es zum bereitgestellten URL‑Pfad passt.

## **Ressourcen extern speichern**

Eigenständiges HTML lässt sich leicht verschieben, aber eingebettete Base64‑Resourcen können die Datei groß machen. Wenn Ihre Anwendung externe Bilddateien benötigt, implementieren Sie [ILinkEmbedController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) und übergeben ihn dem Konstruktor von [HtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmloptions/).

Wenn Sie Ressourcen auslagern, wählen Sie bewusst zwei Pfade:

- Den Ausgabepfad im Dateisystem, in dem Ihre Anwendung erzeugte Bilder, Schriftarten, Audio‑ oder Videodateien schreibt.
- Den URL‑Pfad, den der Browser aus dem HTML‑Dokument verwendet, um diese Dateien zu laden.

## **Mediadateien exportieren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) exportiert Video‑ und Audiodateien und schreibt HTML, das sie in einem Browser abspielen kann. Sein Konstruktor erwartet:

- `path`: das Verzeichnis, in das erzeugte Mediendateien geschrieben werden.
- `fileName`: der erzeugte HTML‑Dateiname.
- `baseUri`: das absolute URI‑Präfix, das in den HTML‑Links zu Mediendateien verwendet wird.

Wenn die HTML‑Datei `html-output/presentation.html` ist und Mediendateien in `html-output/media` gespeichert werden, sollte `path` auf das Medienverzeichnis auf dem Datenträger zeigen, während `baseUri` aus Sicht des Browsers auf dasselbe Verzeichnis zeigen sollte. Für eine lokale Vorschau können Sie eine `file:///`‑URI aus dem Medienverzeichnis erstellen. Für eine bereitgestellte Anwendung verwenden Sie die absolute URL des veröffentlichten Medienverzeichnisses.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Verwenden Sie Ausgabeverzeichnisse, die für jeden Exportauftrag eindeutig sind, besonders in Server‑Anwendungen. Gemeinsame Ausgabepfade können dazu führen, dass Dateien verschiedener Konvertierungen einander überschreiben.

## **Leistung und Ressourcenverwaltung**

Die HTML‑Konvertierung ist ein Rendering‑Vorgang, daher hängen Verarbeitungszeit und Speicherverbrauch von der Folienanzahl, Bildauflösung, Schriftarten, Effekten, Diagrammen und eingebetteten Medien ab. Höhere `PicturesCompression`‑DPI‑Werte, eingebettete Schriftarten, SVG‑Ausgabe und beibehaltene beschnittene Bildbereiche können die Treue erhöhen, führen jedoch meist zu einer größeren Ausgabedatei.

Für Batch‑Konvertierung:

- Jede [Presentation]‑Instanz sofort freigeben.
- Separate Ausgabeverzeichnisse für unterschiedliche Aufträge verwenden.
- Vermeiden Sie das Einbetten gängiger Schriftarten, es sei denn, die Treue erfordert es.
- Bild‑DPI reduzieren, wenn das HTML für Vorschau oder Thumbnails gedacht ist.
- Die Quellpräsentation, das erzeugte HTML und die externen Ressourcen zusammenhalten, bis die Bereitstellungspfade final sind.

## **FAQ**

**Werden Hyperlinks im HTML‑Ausgabe erhalten?**

Ja. Präsentations‑Hyperlinks werden nach HTML exportiert und bleiben anklickbar, wenn die Ziel‑URL gültig ist.

**Kann ich Präsentationen parallel zu HTML konvertieren?**

Ja, aber teilen Sie keine einzelne [Presentation]‑Instanz über Threads hinweg. Verarbeiten Sie verschiedene Dateien mit separaten Präsentations‑Instanzen, separaten Streams und separaten Ausgabeverzeichnissen. Siehe die [multithreading guidance](/slides/de/androidjava/multithreading/) für Details.

**Ist ein Presentation‑Objekt thread‑sicher?**

Nein. Eine einzelne [Presentation]‑Instanz sollte in einem Thread geladen, geändert, gespeichert und freigegeben werden. Für parallele Arbeit erstellen Sie pro Thread oder Prozess eine unabhängige Instanz.

**Warum ist die erzeugte HTML‑Datei groß?**

Der Standard‑Export kann Ressourcen direkt in das HTML einbetten. Eingebettete Schriftarten, hoch‑DPI‑Bilder, Medien, SVG‑Inhalt und beibehaltene beschnittene Bildbereiche erhöhen ebenfalls die Größe. Verwenden Sie externe Ressourcen, schließen Sie gängige Schriftarten vom Einbetten aus und reduzieren Sie `PicturesCompression`, wenn ein kleineres Ergebnis wichtiger ist als maximale Treue.

**Wie soll ich baseUri für den Medien‑Export wählen?**

Wählen Sie `baseUri` aus Sicht des Browsers und übergeben Sie es als absolute URI. Für eine lokale Vorschau können Sie es aus dem Ausgabeverzeichnis mit `mediaDirectory.toUri().toString()` ableiten. Für die Bereitstellung verwenden Sie die absolute URL des veröffentlichten Medienverzeichnisses. Der Dateisystem‑`path` und der Browser‑`baseUri` müssen nicht dieselbe Zeichenkette sein, sie müssen jedoch denselben Ressourcen‑Ort beschreiben.

**Kann ich versteckte Folien einbinden?**

Ja. Setzen Sie `ShowHiddenSlides` auf `true` bei [HtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmloptions/), wenn versteckte Folien exportiert werden müssen.