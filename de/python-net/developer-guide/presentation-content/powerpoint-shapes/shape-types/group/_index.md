---
title: Gruppieren von Formen in Präsentationen mit Python
linktitle: Formgruppe
type: docs
weight: 40
url: /de/python-net/group/
keywords:
- Gruppenform
- Formgruppe
- Gruppe hinzufügen
- Alternativtext
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python gruppieren und wieder auflösen – schnelle Schritt‑für‑Schritt‑Anleitung mit kostenlosem Code."
---

## **Übersicht**

Das Gruppieren von Formen ermöglicht es, mehrere Zeichenobjekte als eine Einheit zu behandeln, sodass Sie sie gemeinsam verschieben, skalieren, formatieren und transformieren können. Mit Aspose.Slides für Python können Sie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) erstellen, darunter Kindformen hinzufügen und das Ergebnis als PPTX speichern. Dieser Artikel zeigt, wie Sie einer Folie ein Gruppen‑Shape hinzufügen und wie Sie auf Zugänglichkeits‑Metadaten wie Alt‑Text von Formen innerhalb der Gruppe zugreifen, um eine sauberere Struktur und reichhaltigere, besser wartbare Präsentationen zu erzielen.

## **Gruppenformen hinzufügen**

Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf einer Folie. Diese Funktion erlaubt es, reichhaltigere Präsentationen zu erstellen, indem mehrere Formen als ein einzelnes Objekt behandelt werden. Sie können neue Gruppenformen hinzufügen, vorhandene abrufen, sie mit Kindformen füllen und beliebige Eigenschaften lesen oder ändern. So fügen Sie einer Folie ein Gruppen‑Shape hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich eine Referenz zu einer Folie anhand des Index.
3. Fügen Sie der Folie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) hinzu.
4. Fügen Sie dem neuen Gruppen‑Shape Formen hinzu.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel zeigt, wie ein Gruppen‑Shape zu einer Folie hinzugefügt wird.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a group shape to the slide.
    group_shape = slide.shapes.add_group_shape()

    # Add shapes inside the group shape.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Write the PPTX file to disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf die Alt‑Text‑Eigenschaft**

In diesem Abschnitt wird erläutert, wie Sie den Alt‑Text von Formen, die sich innerhalb eines Gruppen‑Shapes auf einer Folie befinden, mit Aspose.Slides auslesen. So greifen Sie auf den Alt‑Text der Formen zu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, um eine PPTX‑Datei zu repräsentieren.
2. Holen Sie sich eine Referenz zur Folie anhand ihres Index.
3. Greifen Sie auf die Formen‑Sammlung der Folie zu.
4. Greifen Sie das [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) an.
5. Lesen Sie die Alt‑Text‑Eigenschaft.

Das folgende Beispiel ruft den Alt‑Text von Formen ab, die in Gruppen‑Shapes enthalten sind.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the PPTX file.
with slides.Presentation("group_shape.pptx") as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Access the group shape.
            for child_shape in shape.shapes:
                # Access the Alt Text property.
                print(child_shape.alternative_text)
```

## **FAQ**

**Wird verschachteltes Gruppieren (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) verfügt über die Eigenschaft [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/), die direkt die Unterstützung einer Hierarchie anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die Eigenschaft [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) des [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), um die Position im Anzeige‑Stack zu prüfen oder zu ändern.

**Kann ich das Verschieben/Bearbeiten/Aufheben der Gruppierung verhindern?**

Ja. Der Sperr‑Abschnitt der Gruppe wird über [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) bereitgestellt, mit dem Sie Vorgänge am Objekt einschränken können.