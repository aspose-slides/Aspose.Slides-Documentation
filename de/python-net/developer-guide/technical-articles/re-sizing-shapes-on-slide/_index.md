---
title: Formen auf Präsentationsfolien in Python skalieren
type: docs
weight: 130
url: /de/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /de/python-net/re-sizing-shapes-on-slide/
keywords:
  - Form skalieren
  - Formgröße ändern
  - PowerPoint
  - OpenDocument
  - Präsentation
  - Python
  - Aspose.Slides
description: "Formen auf PowerPoint- und OpenDocument-Folien ganz einfach mit Aspose.Slides für Python via .NET skalieren – die Folienlayout-Anpassungen automatisieren und die Produktivität steigern."
---
## **Übersicht**

Wenn Sie die Foliengröße einer Präsentation ändern, müssen Sie möglicherweise auch die Formen skalieren und neu positionieren, damit sie in die neuen Abmessungen passen. Dieser Artikel zeigt, wie man Formen manuell skaliert und wie man Tabellen auf Folien, Masterfolien und Layouts behandelt.

## **Formen skalieren**

Um die relative Position und Größe jeder Form beizubehalten, multiplizieren Sie ihre horizontalen Koordinaten und die Breite mit dem Verhältnis der neuen Folienbreite zur ursprünglichen Breite. Wenden Sie das entsprechende Höhenverhältnis auf die vertikalen Koordinaten und die Höhe an.

Das erste Beispiel lädt eine Präsentation, deren Folien keine Tabellen enthalten, ändert die Foliengröße auf A4 und speichert das Ergebnis. Es verwendet [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) mit [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/), damit die nachfolgende Schleife die Skalierung steuert. Die Verhältnisse sind ohne Einheit; die Positionen und Abmessungen der Formen werden in Punkt gemessen. Unterschiedliche Breiten‑ und Höhenverhältnisse können Formen verzerren, und das Ändern der Formabmessungen skaliert die Schriftgrößen nicht.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Tabellen erfordern eine separate Behandlung: Skalieren Sie ihre Spaltenbreiten und Zeilenhöhen, anstatt die Gesamtbreite und -höhe der Tabelle zuzuweisen. Zeilenhöhen können größer bleiben als angefordert, wenn der Zelleninhalt mehr Platz benötigt.
{{% /alert %}}

Das zweite Beispiel unterstützt Tabellen und verarbeitet Formen auf Masterfolien und Layouts sowie einzelne Folien, bevor die skalierte Präsentation gespeichert wird. Seine Hilfsfunktion verarbeitet jede [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) indem sie [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) und [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) skaliert. Anschließend skaliert sie die Position der Tabelle, ohne ihre Gesamtabmessungen separat zu skalieren.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Tabellendimensionen werden über Spaltenbreiten und Zeilenhöhen gesteuert.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Formen skalieren, die auf Master- und Layoutfolien sowie einzelnen Folien definiert sind.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Warum werden Formen nach dem Ändern der Foliengröße verzerrt oder abgeschnitten?**

Wenn Sie die Foliengröße ändern, ohne die Formen zu skalieren, behalten sie ihre ursprünglichen Positionen und Abmessungen bei und können über die Folie hinausgehen. Das Skalieren von Breite und Höhe mit unterschiedlichen Verhältnissen kann ebenfalls Formen verzerren.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das erste Beispiel ändert die Formbegrenzungen direkt und ist für Folien ohne Tabellen gedacht. Das zweite Beispiel behandelt Tabellen separat. Überprüfen Sie das resultierende Layout, insbesondere Text und Tabellen, da diese Beispiele die Schriftgrößen nicht skalieren und **Tabelleninhalt** die Zeilenhöhen einschränken können.

**Wie kann ich Tabellen beim Ändern der Foliengröße skalieren?**

Skalieren Sie die Spaltenbreiten mit dem Breitenverhältnis und die minimalen Zeilenhöhen mit dem Höhenverhältnis, dann skalieren Sie die Position der Tabelle, wie im zweiten Beispiel gezeigt.

**Funktioniert diese Skalierung für Masterfolien und Layoutfolien?**

Ja. Das zweite Beispiel iteriert über [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) und über die [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) jedes Masters und wendet dieselbe Skalierungslogik auf deren Formen an.

**Kann ich die Ausrichtung einer Folie (Hochformat/Landscape) zusammen mit der Größenänderung ändern?**

Ja. Setzen Sie [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) nach dem Ändern der Foliengröße und bevor Sie die Zielabmessungen auslesen, damit die Skalierungsfaktoren die endgültige Ausrichtung berücksichtigen.

**Gibt es eine Grenze für die Foliengröße, die ich festlegen kann?**

Sie können benutzerdefinierte Folienabmessungen mit [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) angeben. Die unterstützten Abmessungen hängen außerdem vom Präsentationsformat und von der Anwendung ab, mit der die Datei geöffnet wird.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Verwenden Sie denselben Skalierungsfaktor für Breite und Höhe. Um das ursprüngliche Layout in den neuen Folienabmessungen unterzubringen, verwenden Sie das kleinere der Breiten‑ und Höhenverhältnisse für beide Dimensionen und Positionen. Dadurch bleiben die Proportionen erhalten, es kann jedoch an einer Kante ungenutzter Raum verbleiben.