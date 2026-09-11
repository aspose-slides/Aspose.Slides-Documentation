---
title: Gruppenformen in PowerPoint-Präsentationen mit Python via Java
linktitle: Formgruppe
type: docs
weight: 40
url: /de/python-java/group/
keywords:
- Gruppenform
- Formgruppe
- Gruppe hinzufügen
- Alternativtext
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PowerPoint-Präsentationen mit Aspose.Slides für Python via Java gruppieren und aufheben - ein Schritt-für-Schritt-Leitfaden mit kostenlosem Python-Code."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Gruppierungen von Formen in Aspose.Slides arbeitet. Er zeigt, wie man einer Folie eine Gruppenform hinzufügt, Formen darin platziert und die aktualisierte Präsentation speichert. Außerdem wird demonstriert, wie man auf in einer Gruppe gespeicherte Formen zugreift und deren Alternativtext mit [getAlternativeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getAlternativeText) ausliest. Zusätzlich behandelt der Artikel kurz verwandte Funktionen von Gruppenformen wie verschachtelte Gruppen, Z-Reihenfolge und Sperroptionen.

## **Gruppenform hinzufügen**

Aspose.Slides unterstützt das Arbeiten mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu erstellen. Aspose.Slides for Python via Java unterstützt das Hinzufügen und Zugreifen auf Gruppenformen. Sie können einer Gruppenform Formen hinzufügen oder deren Eigenschaften abrufen. So fügen Sie einer Folie mit Aspose.Slides for Python via Java eine Gruppenform hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Klasse.
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie der Gruppenform Formen hinzu.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppenform hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

    # Instanziieren der Presentation-Klasse.
    presentation = Presentation()
    try:
        # Erste Folie holen.
        slide = presentation.getSlides().get_Item(0)

        # Auf die Formsammlung der Folie zugreifen.
        slide_shapes = slide.getShapes()

        # Eine Gruppenform zur Folie hinzufügen.
        group_shape = slide_shapes.addGroupShape()

        # Formen innerhalb der Gruppenform hinzufügen.
        group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
        group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
        group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
        group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

        # Den Rahmen der Gruppenform festlegen.
        group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
        group_shape.setFrame(group_frame)

        # Die PPTX-Datei auf die Festplatte schreiben.
        presentation.save("GroupShape.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **Alternativtext abrufen**

Dieser Abschnitt zeigt, wie man den Alternativtext von Formen innerhalb einer Gruppe auf einer Folie abruft. So greifen Sie mit Aspose.Slides for Python via Java auf diesen Text zu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Klasse, die eine PPTX-Datei repräsentiert.
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.
1. Greifen Sie auf die Formsammlung der Folie zu.
1. Greifen Sie auf die Gruppenform zu.
1. Lesen Sie den Alternativtext ihrer Formen mit [getAlternativeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getAlternativeText) aus.

Das folgende Beispiel ruft den Alternativtext von Formen innerhalb einer Gruppe ab:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Instanziieren der Presentation-Klasse, die die PPTX-Datei repräsentiert.
presentation = Presentation("AltText.pptx")
try:
    # Erste Folie holen.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Auf eine Form in der Formsammlung der Folie zugreifen.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Auf die Formen innerhalb der Gruppe zugreifen.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Den Alternativtext auslesen.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Wird verschachteltes Gruppieren (eine Gruppe in einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/groupshape/) verfügt über eine [getParentGroup](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getParentGroup)-Methode, die Hierarchieunterstützung anzeigt: Eine Gruppe kann Kind einer anderen Gruppe sein.

**Wie kann ich die Z-Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die [GroupShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/groupshape/)-Objekt-Methode [getZOrderPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getZOrderPosition), um ihre Position im Anzeige-Stack zu prüfen.

**Kann ich das Bewegen, Bearbeiten oder Aufheben der Gruppierung verhindern?**

Ja. Die Sperren der Gruppe werden über [getGroupShapeLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/groupshape/#getGroupShapeLock) bereitgestellt, wodurch Sie Operationen an dem Objekt einschränken können.