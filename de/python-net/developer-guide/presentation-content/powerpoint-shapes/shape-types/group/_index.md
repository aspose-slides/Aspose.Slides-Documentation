---
title: Gruppenformen in Präsentationen mit Python
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
description: "Erfahren Sie, wie Sie Formen in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python gruppieren und aufheben – ein schneller, schrittweiser Leitfaden mit kostenfreiem Code."
---

## **Übersicht**

Das Gruppieren von Formen ermöglicht es Ihnen, mehrere Zeichenobjekte als eine Einheit zu behandeln, sodass Sie sie gemeinsam verschieben, skalieren, formatieren und transformieren können. Mit Aspose.Slides für Python können Sie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) erstellen, Kindformen darin anordnen und das Ergebnis als PPTX speichern. Dieser Artikel zeigt, wie Sie einer Folie ein Gruppen‑Shape hinzufügen und wie Sie auf Barrierefreiheits‑Metadata wie Alt‑Text von Formen innerhalb der Gruppe zugreifen, um eine sauberere Struktur und reichhaltigere, besser wartbare Präsentationen zu ermöglichen.

## **Gruppenformen hinzufügen**

Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf einer Folie. Diese Funktion ermöglicht es Ihnen, reichhaltigere Präsentationen zu erstellen, indem Sie mehrere Formen als ein einzelnes Objekt behandeln. Sie können neue Gruppenformen hinzufügen, vorhandene zugreifen, sie mit Kindformen füllen und deren Eigenschaften lesen oder ändern. So fügen Sie einer Folie eine Gruppenform hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie eine Referenz auf eine Folie anhand des Index.
3. Fügen Sie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) zur Folie hinzu.
4. Fügen Sie dem neuen Gruppenobjekt Formen hinzu.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das Beispiel unten zeigt, wie Sie einer Folie ein Gruppen‑Shape hinzufügen.

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

## **Zugriff auf die Eigenschaft Alt‑Text**

In diesem Abschnitt wird erklärt, wie Sie den Alt‑Text von Formen, die in einem Gruppen‑Shape auf einer Folie enthalten sind, mit Aspose.Slides auslesen. So greifen Sie auf den Alt‑Text der Formen zu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), um eine PPTX‑Datei zu repräsentieren.
2. Holen Sie eine Referenz auf die Folie anhand ihres Index.
3. Greifen Sie auf die Formensammlung der Folie zu.
4. Greifen Sie auf das [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) zu.
5. Lesen Sie die Alt‑Text‑Eigenschaft.

Das nachfolgende Beispiel ruft den Alt‑Text von Formen ab, die in Gruppen‑Shapes enthalten sind.

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

Ja. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) verfügt über die Eigenschaft [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/), die die Hierarchieunterstützung direkt anzeigt (eine Gruppe kann ein Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die Eigenschaft [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) des [GroupShape], um seine Position im Anzeigestapel zu prüfen oder zu ändern.

**Kann ich das Verschieben/Bearbeiten/Aufheben der Gruppierung verhindern?**

Ja. Der Sperrabschnitt der Gruppe wird über [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) bereitgestellt, wodurch Sie Vorgänge an dem Objekt einschränken können.