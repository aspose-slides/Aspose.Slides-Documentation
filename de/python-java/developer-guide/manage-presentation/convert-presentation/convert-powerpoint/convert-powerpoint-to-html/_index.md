---
title: PowerPoint-Präsentationen in HTML in Python über Java konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/python-java/convert-powerpoint-to-html/
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
- Python
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen in HTML in Python über Java konvertieren. Verwenden Sie Aspose.Slides, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriften, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides für Python über Java kann PowerPoint‑Präsentationen als HTML speichern, ohne Microsoft PowerPoint zu benötigen. Die grundlegende Konvertierung besteht aus einem einzigen [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Laden und einem [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Aufruf mit [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/), wenn Sie das exportierte Layout, Schriftarten, Bilder, Notizen, Kommentare, SVG‑Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Exportieren einer gesamten Präsentation oder ausgewählter Folien.
- Erzeugen von festem Layout, responsive oder SVG‑basiertem HTML.
- Einbeziehen von Rednernotizen und Kommentaren.
- Steuern der Bildqualität und beschnittener Bilddaten.
- Einbetten von Schriften oder separate Speicherung von Schriftdateien.
- Auswählen, wie externe Ressourcen und Mediendateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch, um eine einzelne Datei zu teilen, kann jedoch die Ausgabengröße erhöhen. Für die Web‑Veröffentlichung sollten Sie externe Ressourcen, niedrigere Bild‑DPI und nur das Einbetten von Schriften in Betracht ziehen, die in der Zielumgebung nicht zuverlässig verfügbar sind.

## **Konvertieren einer Präsentation zu HTML**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und speichern Sie sie mit [SaveFormat.Html](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Jedes Beispiel lädt `presentation.pptx` aus dem aktuellen Arbeitsverzeichnis. Installieren Sie Aspose.Slides für Python über Java und eine kompatible Java‑Laufzeit, bevor Sie es ausführen. Die JVM wird einmal pro Python‑Prozess gestartet.

Dieses Beispiel schreibt eine HTML‑Datei. Das Präsentationsobjekt wird im `finally`‑Block freigegeben, wodurch Datei‑Handles und Rendering‑Ressourcen nach dem Export freigegeben werden.

## **HTML‑Export konfigurieren**

[HtmlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/) ist die Hauptkonfigurationsklasse für den HTML‑Export. Häufige Einstellungen umfassen:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): fügt Notizen, Kommentare, Handouts oder andere Layout‑Informationen hinzu.
- [setHtmlFormatter](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setHtmlFormatter): ändert die HTML‑Dokumentstruktur oder delegiert das Formatieren an einen Controller.
- [setSlideImageFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setSlideImageFormat): ändert, wie Folien dargestellt werden, zum Beispiel als SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setPicturesCompression): steuert Bild‑DPI und Ausgabengröße.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): behält oder entfernt beschnittene Bilddaten.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): lässt exportierten SVG‑Inhalt an seinen Container anpassen.
- [setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): schließt versteckte Folien ein, wenn erforderlich.

Die folgenden Abschnitte zeigen die am häufigsten verwendeten Optionen einzeln, damit Sie nur die für Ihren Workflow benötigten kombinieren können.

## **Ausgewählte Folien zu HTML konvertieren**

Der [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Überladung, die Folien‑Nummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die Schleife unten speichert jede Folie in einer separaten HTML‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Verwenden Sie dieses Muster, wenn eine Website oder Anwendung für jede Folie eine eigene HTML‑Seite benötigt. Wenn jede Folie dasselbe Layout haben soll, erstellen Sie eine [HtmlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/)-Instanz und übergeben Sie sie an jeden [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)-Aufruf.

## **Responsive HTML erstellen**

[ResponsiveHtmlController](https://reference.aspose.com/slides/de/python-java/aspose.slides/responsivehtmlcontroller/) liefert responsive HTML‑Ausgabe über [HtmlFormatter](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmlformatter/). Verwenden Sie es, wenn die exportierte Seite besser an die Browser‑Breite angepasst werden soll.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Für SVG‑basiertes responsives Layout rufen Sie [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) mit `True` auf. Dies ist nützlich, wenn der Folieninhalt als skalierbare SVG‑Markup exportiert wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Rednernotizen und Kommentare einbinden**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/) über [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions), um Rednernotizen oder Kommentare einzuschließen. Notizen und Kommentare sind standardmäßig ausgeblendet, sofern Sie nicht deren Positionen auswählen.

Angenommen, die Quellpräsentation enthält Rednernotizen:

![Folie mit Rednernotizen in PowerPoint](slide_with_notes.png)

Der folgende Code exportiert den Folieninhalt mit Rednernotizen unterhalb der Folie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Die exportierte HTML‑Datei enthält den Notizbereich:

![HTML‑Ausgabe mit Folie und Rednernotizen](HTML_with_notes.png)

Um Kommentare zu exportieren, rufen Sie [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) auf, z. B. mit [CommentsPositions.Right](https://reference.aspose.com/slides/de/python-java/aspose.slides/commentspositions/#Right) oder [CommentsPositions.Bottom](https://reference.aspose.com/slides/de/python-java/aspose.slides/commentspositions/#Bottom). Wenn Sie nur Kommentare benötigen, lassen Sie [NotesCommentsLayoutingOptions.setNotesPosition] weg. Wenn Sie sowohl Notizen als auch Kommentare benötigen, rufen Sie beide Methoden auf.

## **Bildqualität und beschnittene Bereiche steuern**

HTML‑Export kann Folien‑Bilder komprimieren, um die Ausgabengröße zu reduzieren. Übergeben Sie einen Wert an [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setPicturesCompression) aus [PicturesCompression](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturescompression/), wenn Sie höhere Bildqualität benötigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Standardmäßig können beschnittene Bildbereiche aus der exportierten Ausgabe entfernt werden. Bewahren Sie beschnittene Daten nur auf, wenn Benutzer diese verborgenen Bildteile wiederherstellen oder inspizieren müssen. Das Beibehalten kann die HTML‑Größe erhöhen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **CSS hinzufügen**

Für einfache Formatierungen übergeben Sie einen CSS‑String an [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Dies ändert das umgebende HTML‑Dokument, während Aspose.Slides weiterhin den Folieninhalt rendert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Für einen benutzerdefinierten Dokument‑Header, eine verknüpfte CSS‑Datei oder benutzerdefiniertes Markup rund um Folien und Formen verwenden Sie einen benutzerdefinierten Formatierungs‑Controller über einen JPype‑Interface‑Proxy und übergeben ihn an [HtmlFormatter](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmlformatter/) mit [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Schriften einbetten**

Wenn die Zielumgebung die Präsentations‑Schriften möglicherweise nicht installiert hat, betten Sie Schriften mit [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/python-java/aspose.slides/embedallfontshtmlcontroller/) in das HTML ein. Das Einbetten verbessert die visuelle Treue, erhöht jedoch die Dateigröße.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Schriften nur dann ausschließen, wenn Sie sicher sind, dass die Ziel‑Browser oder -Systeme sie bereits bereitstellen. Für Marken‑Schriften oder weniger verbreitete Schriften ist das Einbetten in der Regel sicherer.

## **Ressourcen extern speichern**

Eigenständiges HTML ist leicht zu transportieren, aber eingebettete Base64‑Ressourcen können die Datei groß machen. Wenn Ihre Anwendung externe Bilddateien benötigt, implementieren Sie einen Ressourcen‑Verknüpfungs‑Controller über einen JPype‑Interface‑Proxy und übergeben Sie ihn dem [HtmlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/)-Konstruktor.

Wenn Sie Ressourcen externalisieren, wählen Sie bewusst zwei Pfade:

- Der Dateisystem‑Ausgabepfad, in dem Ihre Anwendung erzeugte Bilder, Schriften, Audio‑ oder Videodateien schreibt.
- Der URL‑Pfad, den der Browser aus dem HTML‑Dokument verwendet, um diese Dateien zu laden.

## **Mediendateien exportieren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoplayerhtmlcontroller/) exportiert Video‑ und Audiodateien und erzeugt HTML, das sie im Browser abspielen kann. Sein Konstruktor nimmt:

- `path`: das Verzeichnis, in dem erzeugte Mediendateien geschrieben werden.
- `fileName`: der Name der zu erzeugenden HTML‑Datei.
- `baseUri`: das absolute URI‑Präfix, das in den HTML‑Links zu Mediendateien verwendet wird.

Das folgende Beispiel exportiert Medien, die bereits in `presentation.pptx` eingebettet sind. Das erzeugte HTML referenziert Mediendateien nur per Dateiname, relativ zum HTML‑Dokument, sodass `path` das Verzeichnis sein muss, das auch die HTML‑Datei erhält. `baseUri` muss ein absolutes URI sein: Für eine lokale Vorschau bauen Sie ein `file:///`‑URI aus dem Ausgabeverzeichnis; für eine bereitgestellte Anwendung verwenden Sie die absolute URL des veröffentlichten Verzeichnisses.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Verwenden Sie Ausgabeverzeichnisse, die pro Export‑Job eindeutig sind, insbesondere in Server‑Anwendungen. Gemeinsame Ausgabepfade können dazu führen, dass Dateien verschiedener Konvertierungen einander überschreiben.

## **Leistung und Ressourcenverwaltung**

HTML‑Konvertierung ist ein Rendering‑Vorgang, sodass Verarbeitungszeit und Speicherverbrauch von Folienzahl, Bildauflösung, Schriften, Effekten, Diagrammen und eingebetteten Medien abhängen. Höhere Bild‑DPI‑Werte, die an [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setPicturesCompression) übergeben werden, eingebettete Schriften, SVG‑Ausgabe und beibehaltene beschnittene Bildbereiche können die Treue erhöhen, erhöhen jedoch in der Regel die Dateigröße.

Für Batch‑Konvertierung:

- Verwerfen Sie jede [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz umgehend.
- Verwenden Sie separate Ausgabeverzeichnisse für einzelne Aufträge.
- Vermeiden Sie das Einbetten gängiger Schriften, sofern nicht die Bildqualität dies erfordert.
- Reduzieren Sie die Bild‑DPI, wenn das HTML zur Vorschau oder für Thumbnails dient.
- Bewahren Sie die Quellpräsentation, das erzeugte HTML und externe Ressourcen zusammen auf, bis die Bereitstellungspfade endgültig sind.

## **FAQ**

**Werden Hyperlinks im HTML‑Ausgabe erhalten?**

Ja. Präsentations‑Hyperlinks werden nach HTML exportiert und bleiben anklickbar, solange die Ziel‑URL gültig ist.

**Kann ich Präsentationen parallel zu HTML konvertieren?**

Ja, aber teilen Sie keine einzelne [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz über Threads hinweg. Verarbeiten Sie unterschiedliche Dateien mit separaten Präsentations‑Instanzen, separaten Streams und separaten Ausgabeverzeichnissen. Siehe die [multithreading guidance](/slides/de/python-java/multithreading/) für Details.

**Ist ein Präsentations‑Objekt thread‑sicher?**

Nein. Eine einzelne [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz sollte in einem Thread geladen, modifiziert, gespeichert und verworfen werden. Für parallele Arbeit erstellen Sie pro Thread oder Prozess eine unabhängige Instanz.

**Warum ist die erzeugte HTML‑Datei groß?**

Der Standard‑Export kann Ressourcen direkt in das HTML einbetten. Eingebettete Schriften, hoch‑DPI‑Bilder, Medien, SVG‑Inhalt und beibehaltene beschnittene Bildbereiche erhöhen ebenfalls die Größe. Verwenden Sie externe Ressourcen, schließen Sie gängige Schriften vom Einbetten aus und übergeben Sie einen niedrigeren DPI‑Wert an [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setPicturesCompression), wenn eine kleinere Ausgabe wichtiger ist als maximale Treue.

**Warum können Schrift‑Größen‑Werte im HTML von den PowerPoint‑Werten abweichen?**

Die exportierte Seite kann SVG‑Koordinatensysteme und Skalierungstransformationen verwenden. Ein reiner CSS‑ oder SVG‑font‑size‑Wert beschreibt nicht die endgültig angezeigte Größe. Vergleichen Sie die gerenderte Folie auf dem gewünschten Zoom‑Level und prüfen Sie die Schriftaus availability, wenn der Text anders wirkt.

**Wie sollte ich baseUri für den Medien‑Export wählen?**

Wählen Sie `baseUri` aus Sicht des Browsers und übergeben Sie es als absolutes URI. Für eine lokale Vorschau können Sie es aus dem Ausgabeverzeichnis mit `output_directory.as_uri() + "/"` ableiten. Für die Bereitstellung verwenden Sie die absolute URL des veröffentlichten Verzeichnisses. Der Dateisystem‑`path` und das Browser‑`baseUri` müssen nicht exakt derselbe String sein, sie müssen jedoch denselben Ort beschreiben, und dieser Ort muss das Verzeichnis sein, das die erzeugte HTML‑Datei enthält, da Medien‑Links relativ zu ihm geschrieben werden.

**Kann ich versteckte Folien einbeziehen?**

Ja. Rufen Sie [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) mit `True` auf, wenn versteckte Folien exportiert werden sollen.