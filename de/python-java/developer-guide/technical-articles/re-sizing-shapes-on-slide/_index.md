---
title: Formen auf Präsentationsfolien in Python via Java skalieren
type: docs
weight: 110
url: /de/python-java/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Skalieren Sie Formen einfach auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python via Java – automatisieren Sie Folienlayout-Anpassungen und steigern Sie die Produktivität."
---
## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides für Python via Java‑Kunden ist, wie man Formen so skaliert, dass beim Ändern der Foliengröße die Daten nicht abgeschnitten werden. Dieser kurze technische Artikel zeigt, wie das funktioniert.

## **Formen skalieren**

Um zu verhindern, dass Formen beim Ändern der Foliengröße verschoben werden, aktualisieren Sie die Position und die Abmessungen jeder Form, sodass sie dem neuen Folienlayout entsprechen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Präsentationsdatei laden.
presentation = Presentation("sample.ppt")
try:
    # Ursprüngliche Foliengröße ermitteln.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Neue Foliengröße ermitteln.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Formen auf jeder Folie skalieren und neu positionieren.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Formgröße skalieren.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Formposition skalieren.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
Tabellen benötigen keine besondere Behandlung: Das Einstellen von Breite und Höhe einer Tabelle skaliert ihre Spalten und Zeilen proportional, sodass ein erneutes Skalieren der Zeilenhöhen und Spaltenbreiten das Verhältnis doppelt anwenden würde.
{{% /alert %}} 

Der obige Code ändert nur die Formen auf den Folien. Master‑Folien und Layout‑Folien behalten ihre eigenen Formen, daher sollten Sie diese ebenfalls skalieren, wenn die gesamte Präsentation der neuen Foliengröße folgen soll:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Ursprüngliche Foliengröße ermitteln.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Neue Foliengröße ermitteln.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Formgröße skalieren.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Formposition skalieren.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Formgröße skalieren.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Formposition skalieren.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Formgröße skalieren.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Formposition skalieren.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Warum werden Formen nach dem Ändern einer Folie verzerrt oder abgeschnitten?**

Beim Ändern der Größe einer Folie behalten Formen ihre ursprüngliche Position und Größe bei, sofern die Skalierung nicht explizit geändert wird. Dies kann dazu führen, dass Inhalte abgeschnitten werden oder Formen falsch ausgerichtet sind.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Ja. Das Festlegen von Höhe und Breite funktioniert sowohl für Textfelder, Bilder, Diagramme als auch für Tabellen.

**Wie skalieren Sie Tabellen beim Ändern der Foliengröße?**

Skalieren Sie die Tabellenform selbst, genau wie jede andere Form. Ihre Zeilen und Spalten passen sich proportional an, sodass Sie sie anschließend nicht erneut skalieren sollten.

**Funktioniert diese Skalierung für Master‑Folien und Layout‑Folien?**

Ja, aber Sie sollten auch über [Presentation.getMasters](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasters) und [Presentation.getLayoutSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getLayoutSlides) iterieren und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz in der gesamten Präsentation sicherzustellen.

**Kann ich die Ausrichtung einer Folie (Hochformat/Landscape) zusammen mit der Skalierung ändern?**

Ja. Sie können [SlideSize.setOrientation](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#setOrientation) verwenden, um die Ausrichtung zu ändern. Stellen Sie sicher, dass Sie die Skalierungslogik entsprechend anpassen, um das Layout beizubehalten.

**Gibt es eine Grenze für die Foliengröße, die ich festlegen kann?**

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Größen können die Leistung beeinträchtigen oder die Kompatibilität mit einigen Versionen von PowerPoint einschränken.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Sie können vor dem Skalieren die Methode [getAspectRatioLocked](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) des Formschutzes prüfen. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.