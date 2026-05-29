---
title: PowerPoint-Präsentationen in Python zu HTML konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-html/
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
- Aspose.Slides
description: "PowerPoint-Präsentationen in Python zu HTML konvertieren. Verwenden Sie Aspose.Slides, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriftarten, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides for Python via .NET kann PowerPoint‑Präsentationen als HTML speichern, ohne Microsoft PowerPoint zu benötigen. Die Grundkonvertierung besteht aus einem einzelnen [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Laden und einem Aufruf von `save` mit [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/), wenn Sie das exportierte Layout, Schriftarten, Bilder, Notizen, Kommentare, SVG‑Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Exportieren Sie eine gesamte Präsentation oder ausgewählte Folien.
- Erzeugen Sie festes Layout, responsives oder SVG‑basiertes HTML.
- Fügen Sie Rednernotizen und Kommentare hinzu.
- Steuern Sie die Bildqualität und die zugeschnittenen Bilddaten.
- Betten Sie Schriftarten ein oder speichern Sie Schriftdateien separat.
- Wählen Sie, wie externe Ressourcen und Mediendateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch, um eine einzige Datei zu teilen, kann aber die Ausgabedateigröße erhöhen. Für die Web‑Veröffentlichung sollten Sie externe Ressourcen, eine niedrigere Bild‑DPI und das Einbetten nur jener Schriftarten in Betracht ziehen, die in der Zielumgebung nicht zuverlässig verfügbar sind.

## **Eine Präsentation nach HTML konvertieren**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und speichern sie mit [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Dieses Beispiel schreibt eine HTML‑Datei. Die `with`‑Anweisung gibt das Präsentationsobjekt frei und schließt Datei‑Handles sowie Render‑Ressourcen nach dem Export.

## **Verwenden von HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/) ist die Hauptkonfigurationsklasse für den HTML‑Export. Häufige Einstellungen umfassen:

- `slides_layout_options`: fügt Notizen, Kommentare, Handouts oder andere Layout‑Informationen hinzu.
- `html_formatter`: ändert die Struktur des HTML‑Dokuments oder delegiert die Formatierung an einen Controller.
- `slide_image_format`: ändert, wie Folien dargestellt werden, z. B. als SVG.
- `pictures_compression`: steuert Bild‑DPI und Ausgabengröße.
- `delete_pictures_cropped_areas`: behält oder entfernt zugeschnittene Bilddaten.
- `svg_responsive_layout`: lässt exportierten SVG‑Inhalt an seinen Container anpassen.
- `show_hidden_slides`: bindet versteckte Folien ein, wenn nötig.

Die folgenden Abschnitte zeigen die gebräuchlichsten Optionen separat, sodass Sie nur die für Ihren Workflow benötigen, kombinieren können.

## **Ausgewählte Folien nach HTML konvertieren**

Der `save`‑Überladung, die Foliennummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die nachfolgende Schleife speichert jede Folie in einer separaten HTML‑Datei.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Verwenden Sie dieses Muster, wenn eine Website oder Anwendung für jede Folie eine HTML‑Seite benötigt. Wenn jede Folie das gleiche Layout haben soll, erstellen Sie ein [HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/)-Objekt und übergeben es jedem `save`‑Aufruf.

## **Responsives HTML erstellen**

[ResponsiveHtmlController](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/responsivehtmlcontroller/) bietet responsiven HTML‑Ausgabe über [HtmlFormatter](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmlformatter/). Nutzen Sie ihn, wenn die exportierte Seite besser an die Browser‑Breite angepasst werden soll.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Für ein SVG‑basiertes responsives Layout setzen Sie `svg_responsive_layout` auf [HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/). Dies ist nützlich, wenn der Folieninhalt als skalierbares SVG‑Markup exportiert wird.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Rednernotizen und Kommentare einbinden**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notescommentslayoutingoptions/) über `html_options.slides_layout_options`, um Rednernotizen oder Kommentare einzuschließen. Notizen und Kommentare sind standardmäßig ausgeblendet, sofern Sie nicht deren Positionen festlegen.

Angenommen, die Quell‑Präsentation enthält Rednernotizen:

![Folie mit Rednernotizen in PowerPoint](slide_with_notes.png)

Der folgende Code exportiert den Folieninhalt mit den Rednernotizen unterhalb der Folie.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Die exportierte HTML‑Datei enthält den Notizbereich:

![HTML‑Ausgabe mit der Folie und Rednernotizen](HTML_with_notes.png)

Um Kommentare zu exportieren, setzen Sie `comments_position`, zum Beispiel auf `CommentsPositions.RIGHT` oder `CommentsPositions.BOTTOM`. Wenn Sie nur Kommentare benötigen, lassen Sie `notes_position` weg. Wenn Sie sowohl Notizen als auch Kommentare benötigen, setzen Sie beide Eigenschaften.

## **Bildqualität und beschnittene Bereiche steuern**

HTML‑Export kann Folienbilder komprimieren, um die Ausgabengröße zu reduzieren. Setzen Sie `pictures_compression` auf einen Wert aus [PicturesCompression](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/picturescompression/), wenn Sie höhere Bildqualität benötigen.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Standardmäßig können beschnittene Bildbereiche aus der exportierten Ausgabe entfernt werden. Bewahren Sie zugeschnittene Daten nur dann auf, wenn Benutzer in der Lage sein müssen, diese verborgenen Bildteile wiederherzustellen oder zu prüfen. Das Beibehalten kann die HTML‑Größe erhöhen.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **CSS hinzufügen**

Für einfaches Styling übergeben Sie einen CSS‑String an [HtmlFormatter](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmlformatter/). Damit wird das umgebende HTML‑Dokument geändert, während Aspose.Slides weiterhin den Folieninhalt rendert.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Für einen benutzerdefinierten Dokument‑Header, eine verknüpfte CSS‑Datei oder benutzerdefiniertes Markup um Folien und Shapes herum verwenden Sie einen eigenen Formatierungs‑Controller und übergeben ihn an [HtmlFormatter](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmlformatter/) mit `create_custom_formatter`.

## **Schriftarten einbetten**

Falls die Zielumgebung die in der Präsentation verwendeten Schriftarten nicht installiert hat, betten Sie Schriftarten mit [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/embedallfontshtmlcontroller/) in das HTML ein. Das Einbetten verbessert die visuelle Treue, erhöht jedoch die Dateigröße.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Schließen Sie eine Schriftart nur dann aus, wenn Sie sicher sind, dass die Ziel‑Browser oder -Systeme sie bereits bereitstellen. Für Marken‑ oder weniger verbreitete Schriftarten ist das Einbetten in der Regel sicherer.

## **Schriftdateien verlinken anstatt sie einzubetten**

Um die HTML‑Dateigröße zu reduzieren, können Sie Schriftartdaten in separate WOFF‑Dateien schreiben und `@font-face`‑Regeln zum HTML hinzufügen. Das erfordert einen Controller, der während des Exports anpasst, wie Schriftartdaten geschrieben werden. In Python via .NET implementieren Sie diesen Controller in einer kleinen .NET‑Hilfs‑Assembly, laden ihn in Python und übergeben das Hilfs‑Objekt an [HtmlFormatter](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmlformatter/) mit `create_custom_formatter`.

Wenn Sie Schriftarten auslagern, wählen Sie bewusst zwei Pfade:

- Das Ausgabeverzeichnis im Dateisystem, in das die erzeugten WOFF‑Dateien geschrieben werden.
- Den URL‑Pfad, der im HTML‑Dokument erscheint und vom Browser zum Laden dieser Schriftdateien verwendet wird.

Bewahren Sie die HTML‑Datei und die erzeugten Schriftdateien gemeinsam auf, bis die Bereitstellungspfad final ist. Werden die Dateien an einen anderen Ort bereitgestellt, muss das URL‑Präfix dem bereitgestellten URL‑Pfad entsprechen.

## **Ressourcen extern speichern**

Eigenständiges HTML lässt sich leicht verschieben, aber eingebettete Base64‑Ressourcen können die Datei groß machen. Benötigt Ihre Anwendung externe Bild‑, Schrift‑, Audio‑ oder Videodateien, verwenden Sie einen benutzerdefinierten Link/Embed‑Controller und übergeben ihn dem [HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/)-Konstruktor.

Wenn Sie Ressourcen auslagern, wählen Sie bewusst zwei Pfade:

- Den Ausgabepfad im Dateisystem, in den Ihre Anwendung erzeugte Bilder, Schriftarten, Audio‑ oder Videodateien schreibt.
- Den URL‑Pfad, den der Browser aus dem HTML‑Dokument verwendet, um diese Dateien zu laden.

Für eine ausführliche Diskussion zum Verlinken von Bildern siehe [Export Presentations to HTML with Externally Linked Images](/slides/de/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Mediendateien exportieren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/videoplayerhtmlcontroller/) exportiert Video‑ und Audiodateien und erzeugt HTML, das sie im Browser abspielen kann. Sein Konstruktor erwartet:

- `path`: das Verzeichnis, in das erzeugte Mediendateien geschrieben werden.
- `file_name`: der Name der erzeugten HTML‑Datei.
- `base_uri`: das absolute URI‑Präfix, das in den HTML‑Links zu Mediendateien verwendet wird.

Ist die HTML‑Datei `html-output/presentation.html` und werden Mediendateien in `html-output/media` gespeichert, sollte `path` auf das Medienverzeichnis auf dem Datenträger zeigen, während `base_uri` aus Browsersicht auf dasselbe Verzeichnis zeigen muss. Für lokale Vorschau können Sie aus dem Medienverzeichnis einen `file:///`‑URI erzeugen. Für eine bereitgestellte Anwendung verwenden Sie die absolute URL des veröffentlichten Medienverzeichnisses.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Verwenden Sie Ausgabeverzeichnisse, die pro Export‑Job eindeutig sind, besonders in Server‑Anwendungen. Gemeinsame Ausgabepfade können dazu führen, dass Dateien verschiedener Konvertierungen einander überschreiben.

## **Leistung und Ressourcenverwaltung**

HTML‑Konvertierung ist ein Rendering‑Vorgang, sodass Verarbeitungszeit und Speicherverbrauch von Folienanzahl, Bildauflösung, Schriftarten, Effekten, Diagrammen und eingebetteten Medien abhängen. Höhere `pictures_compression`‑DPI‑Werte, eingebettete Schriftarten, SVG‑Ausgabe und beibehaltene zugeschnittene Bildbereiche können die Treue verbessern, erhöhen aber typischerweise die Dateigröße.

Für Batch‑Konvertierung:

- Geben Sie jedes [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Objekt umgehend frei.
- Nutzen Sie separate Ausgabeverzeichnisse für separate Aufträge.
- Betten Sie gängige Schriftarten nur ein, wenn die Treue es erfordert.
- Verringern Sie die Bild‑DPI, wenn das HTML nur zur Vorschau oder für Thumbnails dient.
- Bewahren Sie die Quell‑Präsentation, das erzeugte HTML und externe Ressourcen gemeinsam auf, bis die Bereitstellungspfade final sind.

## **FAQ**

**Werden Hyperlinks im HTML‑Ausgabe beibehalten?**

Ja. Hyperlinks der Präsentation werden nach HTML exportiert und bleiben anklickbar, solange die Ziel‑URL gültig ist.

**Kann ich Präsentationen parallel nach HTML konvertieren?**

Ja, aber teilen Sie keine einzelne [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Instanz über Threads hinweg. Verarbeiten Sie unterschiedliche Dateien mit separaten Präsentations‑Instanzen, separaten Streams und separaten Ausgabeverzeichnissen. Siehe die [multithreading guidance](/slides/de/python-net/multithreading/) für Details.

**Ist ein Presentation-Objekt threadsicher?**

Nein. Eine einzelne [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Instanz sollte auf einem Thread geladen, modifiziert, gespeichert und freigegeben werden. Für parallele Arbeit erstellen Sie eine unabhängige Instanz pro Thread oder Prozess.

**Warum ist die generierte HTML-Datei groß?**

Der Standard‑Export kann Ressourcen direkt in das HTML einbetten. Eingebettete Schriftarten, hochauflösende Bilder, Medien, SVG‑Inhalt und beibehaltene zugeschnittene Bildbereiche erhöhen ebenfalls die Größe. Verwenden Sie externe Ressourcen, schließen Sie gängige Schriftarten vom Einbetten aus und reduzieren Sie `pictures_compression`, wenn eine kleinere Ausgabe wichtiger ist als maximale Treue.

**Wie sollte ich base_uri für den Medienexport wählen?**

Wählen Sie `base_uri` aus Sicht des Browsers und übergeben Sie es als absolutes URI. Für lokale Vorschau können Sie es aus dem Ausgabeverzeichnis mit `Path(media_directory).as_uri() + "/"` ableiten. Für die Bereitstellung verwenden Sie die absolute URL des veröffentlichten Medienverzeichnisses. Der Dateisystem‑`path` und der Browser‑`base_uri` müssen nicht dieselbe Zeichenkette sein, sie müssen jedoch denselben Ressourcenort beschreiben.

**Kann ich versteckte Folien einbinden?**

Ja. Setzen Sie `show_hidden_slides = True` auf [HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/), wenn versteckte Folien exportiert werden sollen.