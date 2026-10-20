---
title: Formen auf Präsentationsfolien in Python über Java skalieren
type: docs
weight: 110
url: /de/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /de/python-java/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python über Java einfach skalieren – die Anpassung von Folienlayouts automatisieren und die Produktivität steigern."
---
## **Übersicht**

Wenn Sie die Foliengröße einer Präsentation ändern, müssen Sie möglicherweise auch die Formen ihrer Größe anpassen und deren Position neu berechnen, um die neuen Abmessungen zu passen. Dieser Artikel zeigt, wie man Formen manuell skaliert und wie man Tabellen auf Folien, Master‑Folien und Layouts behandelt.

## **Formen skalieren**

Um die relative Position und Größe jeder Form beizubehalten, multiplizieren Sie ihre horizontalen Koordinaten und Breite mit dem Verhältnis der neuen Folienbreite zur ursprünglichen Breite. Wenden Sie das entsprechende Höhenverhältnis auf die vertikalen Koordinaten und die Höhe an.

Das erste Beispiel lädt eine Präsentation, deren Folien keine Tabellen enthalten, ändert die Foliengröße auf A4 und speichert das Ergebnis. Es verwendet [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) mit [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale), sodass die nachfolgende Schleife die Skalierung steuert. Die Verhältnisse sind ohne Einheit; Formpositionen und -abmessungen werden in Punkten gemessen. Unterschiedliche Breiten‑ und Höhenverhältnisse können Formen verzerren, und das Ändern der Formabmessungen skaliert die Schriftgrößen nicht.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Tabellen erfordern eine separate Behandlung: Skalieren Sie ihre Spaltenbreiten und Zeilenhöhen, anstatt die gesamte Breite und Höhe der Tabelle zuzuweisen. Zeilenhöhen können größer bleiben als angefordert, wenn der Zellinhalt mehr Platz benötigt.
{{% /alert %}}

Das zweite Beispiel unterstützt Tabellen und verarbeitet Formen auf Master‑Folien und Layouts sowie einzelnen Folien, bevor die skalierte Präsentation gespeichert wird. Sein Hilfsprogramm verarbeitet jede [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) indem es die Spaltenbreiten mit [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) und die minimalen Zeilenhöhen mit [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) skaliert. Anschließend wird die Position der Tabelle skaliert, ohne die Gesamtabmessungen separat zu skalieren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Tabellendimensionen werden durch Spaltenbreiten und Zeilenhöhen gesteuert.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Formen, die auf Master‑Folien und Layouts sowie einzelnen Folien definiert sind, skalieren.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Warum sind Formen nach dem Ändern der Foliengröße verzerrt oder abgeschnitten?**

Wenn Sie die Foliengröße ändern, ohne die Formen zu skalieren, behalten sie ihre ursprünglichen Positionen und Abmessungen bei und können über die Folie hinausgehen. Das Skalieren von Breite und Höhe mit unterschiedlichen Verhältnissen kann Formen ebenfalls verzerren.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das erste Beispiel ändert die Formgrenzen direkt und ist für Folien ohne Tabellen gedacht. Das zweite Beispiel behandelt Tabellen separat. Prüfen Sie das resultierende Layout, insbesondere Text und Tabellen, da diese Beispiele die Schriftgrößen nicht skalieren und Tabelleninhalte die Zeilenhöhen einschränken können.

**Wie kann ich Tabellen beim Ändern der Foliengröße skalieren?**

Skalieren Sie die Spaltenbreiten mit dem Breitenverhältnis und die minimalen Zeilenhöhen mit dem Höhenverhältnis, anschließend skalieren Sie die Position der Tabelle, wie im zweiten Beispiel gezeigt.

**Wird diese Skalierung für Master‑Folien und Layout‑Folien funktionieren?**

Ja. Das zweite Beispiel iteriert über [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) und über jede Master‑Folie [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides), und wendet dieselbe Skalierungslogik auf deren Formen an.

**Kann ich die Orientierung einer Folie (Hochformat/Landscape) zusammen mit der Größenänderung ändern?**

Ja. Rufen Sie [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) nach dem Ändern der Foliengröße und vor dem Auslesen der Zielabmessungen auf, sodass die Skalierungsfaktoren die endgültige Orientierung berücksichtigen.

**Gibt es ein Limit für die Foliengröße, die ich festlegen kann?**

Sie können benutzerdefinierte Folienabmessungen mit [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) festlegen. Die unterstützten Abmessungen hängen auch vom Präsentationsformat und der Anwendung ab, mit der die Datei geöffnet wird.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Verwenden Sie denselben Skalierungsfaktor für Breite und Höhe. Um das ursprüngliche Layout an die neuen Folienabmessungen anzupassen, nutzen Sie das kleinere der beiden Verhältnisse für beide Dimensionen und Positionen. Dadurch bleiben die Proportionen erhalten, es kann jedoch entlang einer Kante ungenutzter Raum entstehen.