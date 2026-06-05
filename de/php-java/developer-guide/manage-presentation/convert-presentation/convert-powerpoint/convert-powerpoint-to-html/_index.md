---
title: PowerPoint-Präsentationen nach HTML konvertieren in PHP
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/php-java/convert-powerpoint-to-html/
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
- PHP
- Aspose.Slides
description: "PowerPoint-Präsentationen in HTML in PHP konvertieren. Verwenden Sie Aspose.Slides, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriften, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides für PHP via Java kann PowerPoint‑Präsentationen als HTML speichern, ohne Microsoft PowerPoint zu benötigen. Die grundlegende Konvertierung besteht aus einem einzelnen [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Ladevorgang und einem `save`‑Aufruf mit [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/), wenn Sie das exportierte Layout, Schriften, Bilder, Notizen, Kommentare, SVG‑Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Exportieren einer gesamten Präsentation oder ausgewählter Folien.
- Erzeugen von festem Layout, responsive oder SVG‑basiertem HTML.
- Einbinden von Rednernotizen und Kommentaren.
- Steuerung der Bildqualität und zugeschnittener Bilddaten.
- Einbetten von Schriften oder getrenntes Speichern von Schriftdateien.
- Auswahl, wie externe Ressourcen und Mediendateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch, um eine einzige Datei zu teilen, kann jedoch die Ausgabedatei vergrößern. Für die Web‑Veröffentlichung sollten Sie externe Ressourcen, eine geringere Bild‑DPI und das Einbetten nur jener Schriften in Betracht ziehen, die in der Zielumgebung nicht zuverlässig verfügbar sind.

## **Konvertieren einer Präsentation nach HTML**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) und speichern sie mit [SaveFormat.Html](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Dieses Beispiel schreibt eine HTML‑Datei. Das Präsentationsobjekt wird im `finally`‑Block freigegeben, wodurch Datei‑Handles und Rendering‑Ressourcen nach dem Export freigegeben werden.

## **HtmlOptions verwenden**

[HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/) ist die zentrale Konfigurationsklasse für den HTML‑Export. Häufige Einstellungen umfassen:

- `SlidesLayoutOptions`: fügt Notizen, Kommentare, Handzettel oder andere Layout‑Informationen hinzu.
- `HtmlFormatter`: ändert die Struktur des HTML‑Dokuments oder delegiert die Formatierung an einen Controller.
- `SlideImageFormat`: ändert, wie Folien dargestellt werden, z. B. als SVG.
- `PicturesCompression`: steuert die Bild‑DPI und die Ausgabengröße.
- `DeletePicturesCroppedAreas`: behält zugeschnittene Bilddaten bei oder entfernt sie.
- `SvgResponsiveLayout`: lässt exportierten SVG‑Inhalt an den Container anpassen.
- `ShowHiddenSlides`: schließt versteckte Folien ein, wenn erforderlich.

Die folgenden Abschnitte zeigen die gebräuchlichsten Optionen einzeln, sodass Sie nur die für Ihren Arbeitsablauf benötigten kombinieren können.

## **Ausgewählte Folien nach HTML konvertieren**

Die `save`‑Überladung, die Foliennummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die nachstehende Schleife speichert jede Folie in einer separaten HTML‑Datei.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Verwenden Sie dieses Muster, wenn eine Website oder Anwendung für jede Folie eine HTML‑Seite benötigt. Wenn jede Folie dasselbe Layout haben soll, erstellen Sie eine [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/)‑Instanz und übergeben sie bei jedem `save`‑Aufruf.

## **Responsive HTML erstellen**

[ResponsiveHtmlController](https://reference.aspose.com/slides/de/php-java/aspose.slides/responsivehtmlcontroller/) liefert responsive HTML‑Ausgabe über [HtmlFormatter](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmlformatter/). Verwenden Sie es, wenn die exportierte Seite besser an die Browser‑Breite angepasst werden soll.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Für ein SVG‑basiertes responsives Layout setzen Sie `SvgResponsiveLayout` auf [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/). Das ist nützlich, wenn der Folieninhalt als skalierbares SVG‑Markup exportiert wird.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Rednernotizen und Kommentare einbinden**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/notescommentslayoutingoptions/) über `HtmlOptions.SlidesLayoutOptions`, um Rednernotizen oder Kommentare einzubinden. Notizen und Kommentare sind standardmäßig ausgeblendet, sofern Sie ihre Positionen nicht festlegen.

Angenommen, die Quell‑Präsentation enthält Rednernotizen:

![Folie mit Rednernotizen in PowerPoint](slide_with_notes.png)

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Der folgende Code exportiert den Folieninhalt mit den Rednernotizen unterhalb der Folie.

Das exportierte HTML enthält den Notizbereich:

![HTML‑Ausgabe mit Folie und Rednernotizen](HTML_with_notes.png)

Um Kommentare zu exportieren, setzen Sie `CommentsPosition`, z. B. auf `CommentsPositions.Right` oder `CommentsPositions.Bottom`. Wenn Sie nur Kommentare benötigen, lassen Sie `NotesPosition` weg. Wenn Sie sowohl Notizen als auch Kommentare benötigen, setzen Sie beide Eigenschaften.

## **Bildqualität und zugeschnittene Bereiche steuern**

Der HTML‑Export kann Folienbilder komprimieren, um die Ausgabengröße zu reduzieren. Setzen Sie `PicturesCompression` auf einen Wert aus [PicturesCompression](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturescompression/), wenn Sie höhere Bildqualität benötigen.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Standardmäßig können zugeschnittene Bildbereiche aus dem Export entfernt werden. Behalten Sie zugeschnittene Daten nur bei, wenn Benutzer diese verborgenen Bildteile wiederherstellen oder inspizieren müssen. Das Behalten kann die HTML‑Größe erhöhen.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **CSS hinzufügen**

Für einfaches Styling übergeben Sie einen CSS‑String an [HtmlFormatter](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmlformatter/) über `createDocumentFormatter`. Dadurch wird das umgebende HTML‑Dokument geändert, während Aspose.Slides weiterhin den Folieninhalt rendert.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Für einen benutzerdefinierten Dokument‑Header, eine verknüpfte CSS‑Datei oder benutzerdefiniertes Markup rund um Folien und Formen verwenden Sie einen eigenen Formatierungs‑Controller und übergeben ihn an [HtmlFormatter](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmlformatter/) mit `createCustomFormatter`.

## **Schriften einbetten**

Wenn die Zielumgebung die Präsentationsschriften nicht installiert haben könnte, betten Sie die Schriften mit [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/php-java/aspose.slides/embedallfontshtmlcontroller/) in das HTML ein. Das Einbetten verbessert die visuelle Treue, erhöht jedoch die Ausgabengröße.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Schriften ausschließen Sie nur, wenn Sie sicher sind, dass die Ziel‑Browser oder -Systeme sie bereits bereitstellen. Für Marken‑Schriften oder weniger verbreitete Schriften ist das Einbetten in der Regel sicherer.

## **Schriftdateien verlinken statt sie einzubetten**

Um die HTML‑Dateigröße zu reduzieren, können Sie Schriftartdaten in separate WOFF‑Dateien schreiben und `@font-face`‑Regeln zum HTML hinzufügen. In PHP via Java wird dieses Szenario meist mit einer kleinen Java‑Hilfsklasse umgesetzt, die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/php-java/aspose.slides/embedallfontshtmlcontroller/) erweitert, Schriftbytes in ein Ausgabeverzeichnis schreibt und `@font-face`‑Regeln in das erzeugte HTML einfügt. Kompilieren Sie diese Hilfsklasse, fügen Sie sie dem Klassenpfad der PHP‑Java‑Bridge hinzu und instanziieren Sie sie anschließend aus PHP mit `new Java(...)`.

Beim Erstellen einer solchen Hilfsklasse wählen Sie bewusst zwei Pfade:

- Den Ausgabepfad im Dateisystem, in dem die erzeugten Schriftdateien geschrieben werden.
- Den URL‑Pfad, den der Browser aus dem HTML‑Dokument verwendet, um diese Schriftdateien zu laden.

## **Ressourcen extern speichern**

Eigenständiges HTML lässt sich leicht verschieben, aber eingebettete Base64‑Ressourcen können die Datei groß machen. Wenn Ihre Anwendung externe Bilddateien benötigt, stellen Sie einen benutzerdefinierten Link/Embed‑Controller dem [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/)‑Konstruktor zur Verfügung.

Wenn Sie Ressourcen auslagern, wählen Sie bewusst zwei Pfade:

- Den Ausgabepfad im Dateisystem, in dem Ihre Anwendung erzeugte Bilder, Schriften, Audio‑ oder Videodateien schreibt.
- Den URL‑Pfad, den der Browser aus dem HTML‑Dokument verwendet, um diese Dateien zu laden.

Halten Sie diese Pfade konsistent mit Ihrem Bereitstellungslayout, damit das erzeugte HTML seine externen Ressourcen laden kann, nachdem es auf einen Web‑Server oder ein anderes Verzeichnis verschoben wurde.

## **Mediendateien exportieren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoplayerhtmlcontroller/) exportiert Video‑ und Audiodateien und erzeugt HTML, das sie im Browser abspielen kann. Sein Konstruktor akzeptiert:

- `path`: das Ausgabeverzeichnis, das von dem erzeugten HTML und den Mediendateien verwendet wird.
- `fileName`: der zu erzeugende HTML‑Dateiname.
- `baseUri`: das absolute URI‑Präfix, das in den HTML‑Links zu Mediendateien verwendet wird.

Wenn die HTML‑Datei `html-output/presentation.html` lautet, sollte `path` auf `html-output` zeigen und `baseUri` aus Sicht des Browsers auf dasselbe Verzeichnis zeigen. Für die lokale Vorschau können Sie aus dem Ausgabeverzeichnis eine `file:///`‑URI erstellen. Für eine bereitgestellte Anwendung verwenden Sie die absolute URL des veröffentlichten Ausgabeverzeichnisses.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Verwenden Sie Ausgabeverzeichnisse, die pro Exportauftrag eindeutig sind, insbesondere in Server‑Anwendungen. Gemeinsame Ausgabepfade können dazu führen, dass Dateien verschiedener Konvertierungen einander überschreiben.

## **Leistung und Ressourcenverwaltung**

HTML‑Konvertierung ist ein Rendering‑Vorgang, sodass Verarbeitungszeit und Speicherverbrauch von der Folienzahl, Bildauflösung, Schriften, Effekten, Diagrammen und eingebetteten Medien abhängen. Höhere `PicturesCompression`‑DPI‑Werte, eingebettete Schriften, SVG‑Ausgabe und das Beibehalten zugeschnittener Bildbereiche können die Treue erhöhen, vergrößern jedoch in der Regel die Ausgabedatei.

Für Batch‑Konvertierung:

- Jede [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz sofort freigeben.
- Separate Ausgabeverzeichnisse für unterschiedliche Aufträge verwenden.
- Gemeinsame Schriften nicht einbetten, es sei denn, die Treue erfordert es.
- Bild‑DPI reduzieren, wenn das HTML für Vorschaubilder oder Thumbnails gedacht ist.
- Die Quell‑Präsentation, das erzeugte HTML und die externen Ressourcen bis zum finalen Bereitstellungspfad zusammenhalten.

## **FAQ**

**Werden Hyperlinks im HTML‑Ausgabe erhalten?**

Ja. Präsentations‑Hyperlinks werden nach HTML exportiert und bleiben anklickbar, solange die Ziel‑URL gültig ist.

**Kann ich Präsentationen parallel nach HTML konvertieren?**

Ja, aber teilen Sie keine einzelne [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz über Threads hinweg. Verarbeiten Sie verschiedene Dateien mit separaten Präsentations‑Instanzen, separaten Streams und separaten Ausgabeverzeichnissen.

**Ist ein Presentation‑Objekt thread‑sicher?**

Nein. Eine einzelne [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz sollte in einem Thread geladen, geändert, gespeichert und freigegeben werden. Für parallele Arbeiten erstellen Sie pro Thread oder Prozess eine unabhängige Instanz.

**Warum ist die erzeugte HTML‑Datei groß?**

Der Standard‑Export kann Ressourcen direkt in das HTML einbetten. Eingebettete Schriften, hoch‑DPI‑Bilder, Medien, SVG‑Inhalt und das Beibehalten zugeschnittener Bildbereiche vergrößern ebenfalls die Datei. Verwenden Sie externe Ressourcen, schließen Sie gemeine Schriften vom Einbetten aus und reduzieren Sie `PicturesCompression`, wenn eine kleinere Ausgabe wichtiger ist als maximale Treue.

**Wie soll ich baseUri für den Medien‑Export wählen?**

Wählen Sie `baseUri` aus der Sicht des Browsers und übergeben Sie es als absolute URI. Für die lokale Vorschau können Sie es aus dem Ausgabeverzeichnis mit einer Java‑Datei‑URI ableiten. Für die Bereitstellung verwenden Sie die absolute URL des veröffentlichten Medienverzeichnisses. Der Dateisystem‑`path` und der Browser‑`baseUri` müssen nicht identisch sein, sie müssen jedoch dieselbe Ressourcen‑Position beschreiben.

**Kann ich versteckte Folien einbinden?**

Ja. Setzen Sie `ShowHiddenSlides` auf `true` bei [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/), wenn versteckte Folien exportiert werden müssen.