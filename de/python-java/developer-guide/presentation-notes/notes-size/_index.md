---
title: Notizenseitengröße und -orientierung in Python via Java ändern
linktitle: Notizenseitengröße
type: docs
weight: 10
url: /de/python-java/notes-size/
keywords:
- Notizenseitengröße
- Notizenorientierung
- Querformat-Notizen
- Hochformat-Notizen
- Handout-Größe
- PowerPoint
- Präsentation
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Lesen und Ändern der Notizenseitengrößen in Aspose.Slides für Python über Java, Orientierung umschalten, gespeicherte Größen verifizieren und Notizen oder Handouts als PDF und Bilder exportieren."
---
## **Übersicht**

Verwenden Sie [Presentation.getNotesSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getNotesSize), um auf die Notizenseiteneinstellungen der Präsentation zuzugreifen. Sie gibt ein [NotesSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/notessize/) Objekt zurück, dessen [setSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/notessize/#setSize) Methode die Seitendimensionen festlegt. Obwohl das Einstellungsobjekt selbst nicht ersetzt werden kann, können Sie über diese Methode neue Abmessungen zuweisen.

Breite und Höhe werden in **Punkten** angegeben, wobei 72 Punkte einem Zoll entsprechen. Zum Beispiel entsprechen 900 × 600 Punkte 12,5 × 8⅓ Zoll. Diese Einstellungen gelten für die gesamte Präsentation und nicht für die Notizen einer einzelnen Folie.

| Einstellung | Zweck |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getNotesSize) | Steuert die Notizenseitendimensionen und die für den Handout‑Export verwendeten Seitendimensionen. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlideSize) | Steuert die regulären Präsentationsfolien‑Dimensionen über [SlideSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/). |

Das Ändern einer der Einstellungen bewirkt nicht automatisch die Änderung der anderen. Das Ändern der Notizenseitenorientierung dreht auch nicht die regulären Folien. Siehe [Slide Size](/slides/de/python-java/slide-size/), um die regulären Folien zu skalieren.

Die nachstehenden Beispiele verwenden eine vorhandene Datei `sample.pptx`. Für die Exportbeispiele verwenden Sie eine Präsentation mit mindestens einer Folie, die Sprecher‑Notizen enthält. Jedes Beispiel kann unabhängig ausgeführt werden.

## **Lesen der Notizenseitengröße und -orientierung**

Lesen Sie Breite und Höhe und vergleichen Sie sie, um die Orientierung zu bestimmen: Eine breitere Seite ist im Querformat, eine höhere Seite im Hochformat, und gleiche Abmessungen beschreiben ein quadratisches Blatt. Dieses Beispiel gibt die tatsächlichen Abmessungen in Punkten aus, ohne eine Standardpapiergröße vorauszusetzen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **In Landschaftsmodus wechseln, ohne die Papiergröße zu ändern**

Um nur die Orientierung zu ändern, vertauschen Sie die vorhandene Breite und Höhe. Dadurch bleiben die Längen beider Seiten erhalten, einschließlich einer benutzerdefinierten Papiergröße. Die nachstehende Bedingung verhindert, dass eine bereits im Querformat befindliche Seite wieder ins Hochformat geändert wird, und lässt eine quadratische Seite unverändert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für das Hochformat verwenden Sie dieselbe Zuweisung, wenn `size.getWidth() > size.getHeight()`. Ersetzen Sie nicht die A4‑ oder Letter‑Abmessungen, es sei denn, Sie möchten ebenfalls die Papiergröße ändern.

## **Benutzerdefinierte Notizenseitengröße festlegen und überprüfen**

Weisen Sie beide Abmessungen gemeinsam zu und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), um die Präsentation zu speichern. Dieses Beispiel legt eine 900 × 600‑Punkt‑Querformatseite fest, speichert sie als PPTX und öffnet die gespeicherte Datei erneut, um die persistierten Werte zu prüfen. Der Vergleich erlaubt eine Toleranz von 0,01 Punkten für Gleitkommawerte; dies ist keine Garantie für Präzision bei jedem Dateiformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Das erwartete Ergebnis ist `900.0 x 600.0 points` und `Size preserved: True`. Das Überprüfen einer neu geöffneten Präsentation verifiziert die gespeicherte Datei und nicht nur die Einstellungen im Arbeitsspeicher.

## **Notizen und Handouts exportieren**

Die Seitengrößen definieren den verfügbaren Bereich für Notizen‑ oder Handout‑Layouts. Sie aktivieren diese Layouts nicht automatisch: die Exportoptionen müssen ebenfalls konfiguriert werden. Der Export regulärer Folien verwendet weiterhin die Folienabmessungen.

### **Notizen in PDF und PNG exportieren**

Weisen Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/) [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) zu, um Notizen im PDF einzuschließen. Dieses Beispiel rendert zudem die erste Folie mit Notizen als PNG mithilfe von [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) und [RenderingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/).

Der Modus [BottomTruncated](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/) hält die Notizen auf einer Seite; nicht passende Notizen können abgeschnitten werden. Das PDF verwendet Seiten von 900 × 600 Punkten. Bei dem unten verwendeten Bildmaßstab von 1 × 1 beträgt das PNG 900 × 600 Pixel. Punkte beschreiben die Seitengestaltung; Pixel beschreiben die Rasterausgabe, deren Abmessungen ebenfalls vom Rendermaßstab abhängen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Für den PDF‑Export bei langen Notizen ermöglicht [BottomFull](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/), bei Bedarf zusätzliche Seiten. Verwenden Sie diesen Modus nicht mit dem oben genannten Einzel‑Folien‑Bildaufruf, da dieser ihn nicht unterstützt. Nach dem Ändern der Größe prüfen Sie die Ausgabe auf abgeschnittene Notizen und die Position vorhandener notes‑master‑Objekte; das alleinige Ändern der Seitengröße sollte nicht als Garantie dafür gelten, dass sämtlicher Inhalt passt. Siehe [Convert PowerPoint to PDF with Notes](/slides/de/python-java/convert-powerpoint-to-pdf-with-notes/) für weitere Informationen zum Notizen‑Export.

### **Handouts in PDF exportieren**

Verwenden Sie [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/handoutlayoutingoptions/), um mehrere Folien‑Miniaturansichten auf einer Seite zu platzieren. Das folgende Beispiel legt eine 900 × 600‑Punkt‑Seite fest und nutzt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/de/python-java/aspose.slides/handouttype/), um bis zu vier Folien pro Seite anzuordnen. Die horizontale Voreinstellung steuert die Folienreihenfolge; die Seitenorientierung ergibt sich aus Breite und Höhe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Das Ändern der Seitengröße ändert den für das Handout‑Raster verfügbaren Bereich, ohne die Abmessungen der Quellfolien zu verändern. Für Handout‑Bilder verwenden Sie [Presentation.getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) mit dem Handout‑Layout, anstatt die Bildmethode einer einzelnen Folie zu nutzen. In Aspose.Slides verwendet das Handout‑Rendering auf Präsentationsebene die Notizenseitengrößen, während der Bildaufruf einer einzelnen Folie keine Handout‑Seite erzeugt. Siehe [Handout Mode](/slides/de/python-java/convert-powerpoint-in-handout-mode/) für Layout‑Optionen.

## **Seitengröße in Betrachtern, Export und Druck**

Bewahren Sie die gespeicherte Präsentationsgröße, die exportierte Seitengröße und die gedruckte Papiergröße getrennt voneinander:

- **Präsentationsbetrachter:** Ein Betrachter kann Notizen mit eigenen Layoutregeln anzeigen oder drucken. Wenn eine andere Anwendung die Datei speichert, öffnen Sie sie erneut und prüfen Sie die Abmessungen erneut; die Formatkonvertierung dieser Anwendung kann sie normalisieren.
- **Exportformate:** Die oben gezeigten PDF‑Beispiele für Notizen und Handouts verwenden die konfigurierten Seitengrößen. Rasterbilder nutzen ganzzahlige Pixelabmessungen und einen Rendermaßstab, sodass Bruchteil‑Punkt‑Werte im Bildausgang gerundet werden können. Der Export regulärer Folien berücksichtigt die Notizenseitengröße nicht.
- **Druckertreiber:** Die Auswahl des Papiers, automatische Drehungen und Fit‑to‑Page‑Einstellungen können die physische Ausgabe ändern, ohne die in der Präsentation oder im PDF gespeicherten Abmessungen zu ändern. Für eine bestimmte Papiergröße passen Sie die Druckereinstellungen an und prüfen die Druckvorschau.

## **FAQ**

**Kann ich die Notizengröße nur für eine Folie festlegen?**

Die Notizenseitengröße ist eine Einstellung auf Präsentationsebene. Einzelne Folien können unterschiedliche Notizinhalte haben, aber diese Eigenschaft liefert keine separate Seitengröße für jede Folie.

**Warum hat das Ändern der Notizen‑Orientierung meine Folien nicht beeinflusst?**

Notizenseiten und reguläre Folien besitzen unabhängige Abmessungen. Verwenden Sie die regulären Folien‑Größeneinstellungen, wenn Sie die Folien selbst skalieren möchten.

**Warum hat mein gespeichertes oder gedrucktes Ergebnis eine andere Größe?**

Öffnen Sie zunächst die gespeicherte Präsentation erneut und vergleichen Sie ihre Notizenseiten‑Abmessungen. Wenn diese geändert wurden, prüfen Sie, ob das Speichern oder Konvertieren der Datei in einer anderen Anwendung die Seiteneinstellungen geändert hat. Wenn nicht, überprüfen Sie das Export‑Layout, den Bildmaßstab, die Betrachter‑Einstellungen und die Papierauswahl des Druckers.