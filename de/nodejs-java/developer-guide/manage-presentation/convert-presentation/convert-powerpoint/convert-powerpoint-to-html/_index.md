---
title: PowerPoint-Präsentationen in Node.js in HTML konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-Präsentationen in Node.js nach HTML konvertieren. Verwenden Sie Aspose.Slides für Node.js über Java, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriftarten, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides for Node.js via Java kann PowerPoint‑Präsentationen ohne Microsoft PowerPoint als HTML speichern. Die Grundkonvertierung besteht aus einem einzelnen [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Ladevorgang und einem Aufruf von `save` mit [SaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/), wenn Sie das exportierte Layout, Schriftarten, Bilder, Notizen, Kommentare, SVG‑Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Exportieren einer gesamten Präsentation oder ausgewählter Folien.
- Erzeugen von festem Layout, responsive oder SVG‑basiertem HTML.
- Einbinden von Referenten‑Notizen und Kommentaren.
- Steuerung der Bildqualität und zugeschnittener Bilddaten.
- Einbetten von Schriftarten oder getrenntes Speichern von Schriftartdateien.
- Auswahl, wie externe Ressourcen und Mediendateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch zum Teilen einer einzigen Datei, kann jedoch die Ausgabengröße erhöhen. Für die Veröffentlichung im Web sollten Sie externe Ressourcen, niedrigere Bild‑DPI und das Einbetten nur jener Schriftarten in Betracht ziehen, die in der Zielumgebung nicht zuverlässig verfügbar sind.

## **Konvertieren einer Präsentation nach HTML**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) und speichern sie mit [SaveFormat.Html](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Dieses Beispiel schreibt eine HTML‑Datei. Das Präsentationsobjekt wird im `finally`‑Block verworfen, wodurch Datei‑Handles und Rendering‑Ressourcen nach dem Export freigegeben werden.

## **Verwenden von HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/) ist die Hauptkonfigurationsklasse für den HTML‑Export. Häufig genutzte Einstellungen umfassen:

- `SlidesLayoutOptions`: fügt Notizen, Kommentare, Handouts oder andere Layout‑Informationen hinzu.
- `HtmlFormatter`: ändert die HTML‑Dokumentstruktur oder delegiert die Formatierung an einen Controller.
- `SlideImageFormat`: legt fest, wie Folien dargestellt werden, z. B. als SVG.
- `PicturesCompression`: steuert Bild‑DPI und Ausgabengröße.
- `DeletePicturesCroppedAreas`: behält zugeschnittene Bilddaten bei oder entfernt sie.
- `SvgResponsiveLayout`: lässt exportierten SVG‑Inhalt an seinen Container anpassen.
- `ShowHiddenSlides`: schließt versteckte Folien bei Bedarf ein.

Die folgenden Abschnitte zeigen die gebräuchlichsten Optionen einzeln, sodass Sie nur die Kombinationen auswählen können, die Ihr Workflow benötigt.

## **Ausgewählte Folien nach HTML konvertieren**

Die `Presentation.save`‑Überladung, die Foliennummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die nachfolgende Schleife speichert jede Folie in einer separaten HTML‑Datei.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Verwenden Sie dieses Muster, wenn eine Website oder Anwendung für jede Folie eine eigene HTML‑Seite benötigt. Wenn jede Folie das gleiche Layout haben soll, erstellen Sie eine einzige [HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/)-Instanz und übergeben sie jedem `save`‑Aufruf.

## **Responsive HTML erzeugen**

[ResponsiveHtmlController](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/responsivehtmlcontroller/) liefert responsive HTML‑Ausgabe über [HtmlFormatter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmlformatter/). Verwenden Sie ihn, wenn die exportierte Seite besser an die Browser‑Breite angepasst werden soll.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Für ein SVG‑basiertes responsives Layout setzen Sie `SvgResponsiveLayout` auf [HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/). Dies ist nützlich, wenn der Folieninhalt als skalierbare SVG‑Markup exportiert wird.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Referenten‑Notizen und Kommentare einbinden**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notescommentslayoutingoptions/) über `HtmlOptions.setSlidesLayoutOptions`, um Referenten‑Notizen oder Kommentare einzubeziehen. Notizen und Kommentare sind standardmäßig ausgeblendet, es sei denn, Sie bestimmen deren Position.

Angenommen, die Quellpräsentation enthält Referenten‑Notizen:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Der folgende Code exportiert den Folieninhalt mit den Notizen unterhalb der Folie.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Das exportierte HTML enthält den Notizbereich:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Um Kommentare zu exportieren, setzen Sie `CommentsPosition`, z. B. auf `CommentsPositions.Right` oder `CommentsPositions.Bottom`. Wenn Sie nur Kommentare benötigen, lassen Sie `NotesPosition` weg. Wenn Sie sowohl Notizen als auch Kommentare benötigen, setzen Sie beide Eigenschaften.

## **Bildqualität und zugeschnittene Bereiche steuern**

Der HTML‑Export kann Folienbilder komprimieren, um die Ausgabengröße zu verringern. Setzen Sie `PicturesCompression` auf einen Wert aus [PicturesCompression](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturescompression/), wenn Sie höhere Bildqualität benötigen.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Standardmäßig können zugeschnittene Bildbereiche aus dem exportierten Ergebnis entfernt werden. Behalten Sie zugeschnittene Daten nur dann bei, wenn Benutzer diese verborgenen Bildteile wiederherstellen oder untersuchen müssen. Das Beibehalten kann die HTML‑Größe erhöhen.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS hinzufügen**

Für einfaches Styling übergeben Sie einen CSS‑String an `HtmlFormatter.createDocumentFormatter`. Dadurch wird das umgebende HTML‑Dokument geändert, während Aspose.Slides weiterhin den Folieninhalt rendert.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Für einen benutzerdefinierten Dokument‑Header, eine verknüpfte CSS‑Datei oder benutzerdefiniertes Markup um Folien und Formen herum verwenden Sie [HtmlFormatter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmlformatter/) mit einem Formatierungs‑Controller.

## **Schriftarten einbetten**

Falls die Zielumgebung die in der Präsentation verwendeten Schriftarten nicht installiert hat, betten Sie die Schriftarten mit [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) in das HTML ein. Das Einbetten verbessert die visuelle Treue, erhöht jedoch die Dateigröße.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Schließen Sie Schriftarten nur aus, wenn Sie sicher sind, dass die Ziel‑Browser oder -Systeme sie bereits bereitstellen. Für Marken‑ oder weniger verbreitete Schriftarten ist das Einbetten in der Regel sicherer.

## **Statt Einbetten Schriftartdateien verlinken**

Um die HTML‑Dateigröße zu reduzieren, können Sie Schriftartdaten in separate WOFF‑Dateien schreiben und `@font-face`‑Regeln zum HTML hinzufügen. In Node.js via Java wird dieses Szenario typischerweise mit einer kleinen Java‑Hilfsklasse implementiert, die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) erweitert, Schriftbytes in ein Ausgabeverzeichnis schreibt und `@font-face`‑Regeln in das erzeugte HTML injiziert. Kompilieren Sie diese Hilfsklasse, fügen Sie sie dem Klassenpfad des Node.js‑Moduls hinzu und instanziieren Sie sie dann aus JavaScript mit `java.newInstanceSync`.

Beim Erstellen einer solchen Hilfsklasse wählen Sie bewusst zwei Pfade:

- Den Dateisystem‑Ausgabepfad, in dem die generierten Schriftdateien abgelegt werden.
- Den URL‑Pfad, den der Browser aus dem HTML‑Dokument zum Laden dieser Schriftdateien verwendet.

## **Ressourcen extern speichern**

Ein eigenständiges HTML ist leicht zu verschieben, aber eingebettete Base64‑Ressourcen können die Datei groß machen. Wenn Ihre Anwendung externe Bild‑, Schrift‑, Audio‑ oder Videodateien benötigt, verwenden Sie einen Export‑Controller, der Ressourcen in ein gewähltes Verzeichnis schreibt und für den Browser sichtbare URLs erzeugt. Halten Sie den Dateisystem‑Pfad und den URL‑Pfad im Einklang mit Ihrem Bereitstellungs‑Layout.

## **Mediendateien exportieren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) exportiert Video‑ und Audiodateien und erzeugt HTML, das sie im Browser abspielen kann. Sein Konstruktor erwartet:

- `path`: das Verzeichnis, in das die generierten Mediendateien geschrieben werden.
- `fileName`: der zu erzeugende HTML‑Dateiname.
- `baseUri`: das absolute URI‑Präfix, das in den HTML‑Links zu den Mediendateien verwendet wird.

Wenn die HTML‑Datei `html-output/presentation.html` heißt und Mediendateien in `html-output/media` gespeichert werden, sollte `path` auf das Medien‑Verzeichnis im Dateisystem zeigen, während `baseUri` aus Sicht des Browsers auf dasselbe Verzeichnis verweisen muss. Für eine lokale Vorschau können Sie aus dem Medien‑Verzeichnis eine `file:///`‑URI erstellen. Für eine bereitgestellte Anwendung verwenden Sie die absolute URL des veröffentlichten Medien‑Verzeichnisses.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Verwenden Sie Ausgabeverzeichnisse, die pro Export‑Job eindeutig sind, insbesondere in Server‑Anwendungen. Gemeinsame Ausgabe‑Pfade können dazu führen, dass Dateien verschiedener Konvertierungen überschrieben werden.

## **Leistung und Ressourcenverwaltung**

HTML‑Konvertierung ist ein Rendering‑Vorgang, sodass Verarbeitungszeit und Speicherverbrauch von Folienzahl, Bildauflösung, Schriftarten, Effekten, Diagrammen und eingebetteten Medien abhängen. Höhere `PicturesCompression`‑DPI‑Werte, eingebettete Schriftarten, SVG‑Ausgabe und beibehaltene zugeschnittene Bildbereiche können die Treue verbessern, erhöhen jedoch in der Regel die Ausgabengröße.

Für Batch‑Konvertierung:

- Verwerfen Sie jede [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Instanz zügig.
- Nutzen Sie separate Ausgabeverzeichnisse für verschiedene Jobs.
- Betten Sie gängige Schriftarten nur ein, wenn die Treue dies erfordert.
- Reduzieren Sie die Bild‑DPI, wenn das HTML nur zur Vorschau oder für Thumbnails bestimmt ist.
- Halten Sie Quellpräsentation, erzeugtes HTML und externe Ressourcen zusammen, bis die Bereitstellungspfade final sind.

## **FAQ**

**Werden Hyperlinks im HTML‑Export erhalten?**

Ja. Präsentations‑Hyperlinks werden nach HTML exportiert und bleiben anklickbar, solange die Ziel‑URL gültig ist.

**Kann ich Präsentationen parallel nach HTML konvertieren?**

Ja, teilen Sie jedoch niemals eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Instanz zwischen Workern. Verarbeiten Sie verschiedene Dateien mit separaten Präsentations‑Instanzen, separaten Streams und separaten Ausgabeverzeichnissen. Siehe die [multithreading guidance](/slides/de/nodejs-java/multithreading/) für Details.

**Ist ein Presentation‑Objekt thread‑sicher?**

Nein. Eine einzelne [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Instanz sollte in einem Worker geladen, verändert, gespeichert und verworfen werden. Für parallele Verarbeitung erstellen Sie pro Worker eine unabhängige Instanz.

**Warum ist die erzeugte HTML‑Datei groß?**

Der Standard‑Export kann Ressourcen direkt in das HTML einbetten. Eingebettete Schriftarten, hochauflösende Bilder, Medien, SVG‑Inhalt und beibehaltene zugeschnittene Bildbereiche erhöhen die Größe ebenfalls. Verwenden Sie externe Ressourcen, schließen Sie gängige Schriftarten vom Einbetten aus und reduzieren Sie `PicturesCompression`, wenn eine kleinere Ausgabe wichtiger ist als maximale Treue.

**Wie soll ich baseUri für den Medien‑Export wählen?**

Wählen Sie `baseUri` aus Sicht des Browsers und übergeben Sie ihn als absolute URI. Für lokale Vorschau können Sie ihn aus dem Ausgabeverzeichnis mit einer `file:///`‑URI ableiten. Für die Bereitstellung verwenden Sie die absolute URL des veröffentlichten Medien‑Verzeichnisses. Der Dateisystem‑`path` und der Browser‑`baseUri` müssen nicht dieselbe Zeichenkette sein, sie müssen jedoch denselben Ressourcenort beschreiben.

**Kann ich versteckte Folien einbeziehen?**

Ja. Setzen Sie `ShowHiddenSlides` auf `true` bei [HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/), wenn versteckte Folien exportiert werden müssen.