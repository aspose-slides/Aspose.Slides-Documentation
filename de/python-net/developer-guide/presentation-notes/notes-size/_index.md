---
title: Notizseitengröße und Orientierung in Python ändern
linktitle: Notizseitengröße
type: docs
weight: 10
url: /de/python-net/notes-size/
keywords:
- Notizseitengröße
- Notizorientierung
- Querformat-Notizen
- Hochformat-Notizen
- Handout-Größe
- PowerPoint
- Präsentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Lesen und ändern Sie die Notizseitendimensionen in Aspose.Slides für Python über .NET, wechseln Sie die Orientierung, überprüfen Sie gespeicherte Größen und exportieren Sie Notizen oder Handouts zu PDF und Bildern."
---
## **Übersicht**

Verwenden Sie [Presentation.notes_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/notes_size/), um auf die Notizseiteneinstellungen der Präsentation zuzugreifen. Sie gibt ein [NotesSize](https://reference.aspose.com/slides/de/python-net/aspose.slides/notessize/)‑Objekt zurück, dessen [size](https://reference.aspose.com/slides/de/python-net/aspose.slides/notessize/size/)‑Eigenschaft schreibbar ist. Obwohl das Einstellungsobjekt selbst schreibgeschützt ist, können Sie seiner size‑Eigenschaft neue Abmessungen zuweisen.

Breite und Höhe werden in **Punkten** angegeben, wobei 72 Punkte einem Zoll entsprechen. Zum Beispiel entsprechen 900 × 600 Punkte 12,5 × 8⅓ Zoll. Diese Einstellungen gelten für die gesamte Präsentation und nicht für die Notizen einer einzelnen Folie.

| Einstellung | Zweck |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/notes_size/) | Steuert die Abmessungen der Notizseite und die für den Handout‑Export verwendeten Seitengrößen. |
| [Presentation.slide_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slide_size/) | Steuert die regulären Folienabmessungen der Präsentation über [SlideSize](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesize/). |

Das Ändern einer der Einstellungen ändert nicht automatisch die andere. Das Ändern der Ausrichtung der Notizseite dreht die regulären Folien ebenfalls nicht. Siehe [Slide Size](/slides/de/python-net/slide-size/), um die regulären Folien zu ändern.

Die nachstehenden Beispiele verwenden ein vorhandenes `sample.pptx`. Für die Exportbeispiele verwenden Sie eine Präsentation mit mindestens einer Folie, die Sprecher‑Notizen enthält. Jedes Beispiel kann unabhängig ausgeführt werden.

## **Notizseitengröße und -orientierung lesen**

Lesen Sie Breite und Höhe und vergleichen Sie sie, um die Ausrichtung zu bestimmen: Eine breitere Seite ist im Querformat, eine höhere Seite im Hochformat, und gleiche Abmessungen beschreiben eine quadratische Seite. Dieses Beispiel gibt die tatsächlichen Abmessungen in Punkten aus, ohne eine Standardpapiergröße anzunehmen.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Wechsel zu Querformat ohne Änderung der Papiergröße**

Um nur die Ausrichtung zu ändern, vertauschen Sie die vorhandene Breite und Höhe. Dadurch bleiben die Längen beider Seiten erhalten, einschließlich einer benutzerdefinierten Papiergröße. Die nachstehende Bedingung verhindert, dass eine bereits im Querformat befindliche Seite wieder ins Hochformat geändert wird, und lässt eine quadratische Seite unverändert.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Für die Hochformat‑Ausrichtung verwenden Sie dieselbe Zuweisung, wenn `size.width > size.height`. Ersetzen Sie nicht die A4‑ oder Letter‑Abmessungen, es sei denn, Sie möchten ebenfalls die Papiergröße ändern.

## **Benutzerdefinierte Notizseitengröße festlegen und prüfen**

Weisen Sie beide Abmessungen gemeinsam zu und verwenden Sie dann [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/), um die Präsentation zu speichern. Dieses Beispiel legt eine 900 × 600‑Punkt‑Querformatseite fest, speichert sie als PPTX und öffnet die gespeicherte Datei erneut, um die gespeicherten Werte zu überprüfen. Der Vergleich erlaubt eine Toleranz von 0,01 Punkten für Gleitkommawerte; er garantiert nicht die Präzision für jedes Dateiformat.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Das erwartete Ergebnis ist `900 x 600 points` und `Size preserved: True`. Das Prüfen einer neu geöffneten Präsentation bestätigt die gespeicherte Datei und nicht nur die Einstellungen im Speicher.

## **Notizen und Handouts exportieren**

Die Seitenabmessungen definieren den verfügbaren Bereich für Notizen‑ oder Handout‑Layouts. Sie aktivieren diese Layouts nicht automatisch: Konfigurieren Sie auch die Exportoptionen. Der reguläre Folien‑Export verwendet weiterhin die Folienabmessungen.

### **Notizen in PDF und PNG exportieren**

Weisen Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notescommentslayoutingoptions/) [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) zu, um Notizen in das PDF aufzunehmen. Dieses Beispiel rendert zudem die erste Folie mit Notizen in PNG mithilfe von [Slide.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/) und [RenderingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/renderingoptions/).

Der Modus [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notespositions/) hält die Notizen auf einer Seite; nicht passende Notizen können abgeschnitten werden. Das PDF verwendet Seiten mit 900 × 600 Punkten. Bei dem unten verwendeten Bildmaßstab von 1 × 1 beträgt das PNG 900 × 600 Pixel. Punkte beschreiben die Seitengeometrie; Pixel beschreiben die Rasterausgabe, deren Abmessungen ebenfalls vom Rendermaßstab abhängen.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Für den PDF‑Export mit langen Notizen erlaubt [BOTTOM_FULL](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notespositions/) bei Bedarf zusätzliche Seiten. Verwenden Sie diesen Modus nicht mit dem oben genannten Einzel‑Folie‑Bildaufruf, da dieser ihn nicht unterstützt. Nach dem Ändern der Größe prüfen Sie die Ausgabe auf abgeschnittene Notizen und die Platzierung vorhandener notes‑master‑Objekte; das alleinige Ändern der Seitenabmessungen sollte nicht als Garantie dafür gelten, dass der gesamte Inhalt passt. Siehe [Convert PowerPoint to PDF with Notes](/slides/de/python-net/convert-powerpoint-to-pdf-with-notes/) für weitere Informationen zum Notizen‑Export.

### **Handouts in PDF exportieren**

Verwenden Sie [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/handoutlayoutingoptions/) , um mehrere Folienminiaturansichten auf einer Seite zu platzieren. Das folgende Beispiel legt eine 900 × 600‑Punkt‑Seite fest und nutzt [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/handouttype/) , um bis zu vier Folien pro Seite anzuordnen. Die horizontale Vorgabe steuert die Folienreihenfolge; die Seitenorientierung ergibt sich aus ihrer Breite und Höhe.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Das Ändern der Seitengröße ändert den für das Handout‑Raster verfügbaren Bereich, ohne die Abmessungen der Ausgangs‑Folien zu ändern. Für Handout‑Bilder verwenden Sie [Presentation.get_images](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/get_images/) mit dem Handout‑Layout, anstatt die Bild‑Methode einer einzelnen Folie zu nutzen. In Aspose.Slides verwendet die handout‑Renderung auf Präsentationsebene die Notizseitengrößen, während der Bildaufruf einer einzelnen Folie keine Handout‑Seite erzeugt. Siehe [Handout Mode](/slides/de/python-net/convert-powerpoint-in-handout-mode/) für Layout‑Optionen.

## **Seitengröße in Viewern, Export und Druck**

Bewahren Sie die in der Präsentation gespeicherte Größe, die exportierte Seitengröße und die gedruckte Papiergröße getrennt:

- **Presentation viewers:** Ein Viewer kann Notizen mit seinen eigenen Layoutregeln anzeigen oder drucken. Wenn eine andere Anwendung die Datei speichert, öffnen Sie sie erneut und prüfen Sie die Abmessungen erneut; die Formatkonvertierung dieser Anwendung kann sie normalisieren.
- **Export formats:** Die oben gezeigten PDF‑Beispiele für Notizen und Handouts verwenden die konfigurierten Seitengrößen. Rasterbilder verwenden ganzzahlige Pixelabmessungen und einen Rendermaßstab, sodass gebrochene Punktwerte im Bildausgabe gerundet werden können. Der Export regulärer Folien berücksichtigt nicht die Notizseitengröße.
- **Printer drivers:** Die Papierauswahl, automatische Drehung und Einstellungen zum Anpassen an die Seite können die physische Ausgabe verändern, ohne die in der Präsentation oder im PDF gespeicherten Abmessungen zu ändern. Für eine bestimmte Papiergröße passen Sie die Druckereinstellungen an und prüfen die Druckvorschau.

## **FAQ**

**Kann ich die Notizgröße nur für eine Folie festlegen?**

Die Notizseitengröße ist eine Einstellung auf Präsentationsebene. Einzelne Folien können unterschiedliche Notizinhalte haben, aber diese Eigenschaft bietet keine separate Seitengröße für jede Folie.

**Warum hat das Ändern der Notizseiten‑Ausrichtung meine Folien nicht verändert?**

Notizseiten und reguläre Folien haben unabhängige Abmessungen. Verwenden Sie die regulären Foliengrößeneinstellungen, wenn Sie die Folien selbst skalieren möchten.

**Warum hat mein gespeichert‑ oder gedrucktes Ergebnis eine andere Größe?**

Öffnen Sie zunächst die gespeicherte Präsentation erneut und vergleichen Sie deren Notizabmessungen. Wenn diese geändert wurden, prüfen Sie, ob das Speichern oder Konvertieren der Datei in einer anderen Anwendung die Seiteneinstellungen verändert hat. Wenn nicht, überprüfen Sie das Exportlayout, den Bildmaßstab, die Viewereinstellungen und die Drucker‑Papierauswahl.