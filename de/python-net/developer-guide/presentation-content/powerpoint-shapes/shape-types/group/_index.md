---
title: Gruppieren von Formen in Präsentationen mit Python
linktitle: Formgruppe
type: docs
weight: 40
url: /de/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/group/
keywords:
- Gruppenform
- Formgruppe
- Gruppe hinzufügen
- Alternativtext
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Lernen Sie, wie Sie Formen in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python gruppieren und aufheben – schnelle, schrittweise Anleitung mit kostenlosem Code."
---

## **Übersicht**

Das Gruppieren von Formen ermöglicht es, mehrere Zeichenobjekte als eine Einheit zu behandeln, sodass Sie sie gemeinsam verschieben, skalieren, formatieren und transformieren können. Mit Aspose.Slides für Python können Sie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) erstellen, darin untergeordnete Formen hinzufügen und anordnen und das Ergebnis als PPTX speichern. Dieser Artikel zeigt, wie man einer Folie eine Gruppenform hinzufügt und wie man auf Zugänglichkeits‑Metadaten wie den Alternativtext von Formen innerhalb der Gruppe zugreift, um eine sauberere Struktur und reichhaltigere, besser wartbare Präsentationen zu ermöglichen.

## **Gruppenformen hinzufügen**

Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf einer Folie. Mit dieser Funktion können Sie reichhaltigere Präsentationen erstellen, indem Sie mehrere Formen als ein einzelnes Objekt behandeln. Sie können neue Gruppenformen hinzufügen, vorhandene abrufen, sie mit untergeordneten Formen füllen und deren Eigenschaften lesen oder ändern. So fügen Sie einer Folie eine Gruppenform hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Erhalten Sie einen Verweis auf eine Folie nach Index.
3. Fügen Sie der Folie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) hinzu.
4. Fügen Sie der neuen Gruppenform Formen hinzu.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel zeigt, wie man einer Folie eine Gruppenform hinzufügt.

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

## **Zugriff auf die Alt-Text-Eigenschaft**

In diesem Abschnitt wird erklärt, wie Sie den Alt‑Text von Formen, die sich innerhalb einer Gruppenform auf einer Folie befinden, mit Aspose.Slides auslesen. So greifen Sie auf den Alt‑Text der Formen zu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, um eine PPTX‑Datei darzustellen.
2. Holen Sie sich einen Verweis auf die Folie nach Index.
3. Greifen Sie auf die Formen‑Sammlung der Folie zu.
4. Greifen Sie auf das [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) zu.
5. Lesen Sie die Alt‑Text‑Eigenschaft.

Das folgende Beispiel ruft den Alt‑Text von Formen ab, die in Gruppenformen enthalten sind.

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

**Wird verschachteltes Gruppieren (eine Gruppe in einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) verfügt über eine [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/)-Eigenschaft, die direkt die Unterstützung von Hierarchien anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe relativ zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/)-Eigenschaft des [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), um deren Position im Anzeigestapel zu prüfen oder zu ändern.

**Kann ich das Verschieben/Bearbeiten/Auflösen verhindern?**

Ja. Der Sperr‑Abschnitt der Gruppe wird über [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) bereitgestellt, mit dem Sie Vorgänge an dem Objekt einschränken können.