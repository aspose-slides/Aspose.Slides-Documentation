---
title: Gruppierung von Formen mit Python
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
description: "Erfahren Sie, wie Sie Formen in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python gruppieren und gruppieren aufheben – schnelle, schrittweise Anleitung mit kostenfreiem Code."
---

## **Übersicht**

Das Gruppieren von Formen ermöglicht es, mehrere Zeichenobjekte als eine Einheit zu behandeln, sodass Sie sie gemeinsam verschieben, skalieren, formatieren und transformieren können. Mit Aspose.Slides für Python können Sie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) erstellen, Kindformen darin anordnen und das Ergebnis als PPTX speichern. Dieser Artikel zeigt, wie Sie ein GroupShape auf einer Folie hinzufügen und wie Sie Zugänglichkeits‑Metadaten wie Alt‑Text von Formen innerhalb der Gruppe auslesen, um eine sauberere Struktur und reichhaltigere, wartbare Präsentationen zu ermöglichen.

## **Gruppenformen hinzufügen**

Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf einer Folie. Diese Funktion lässt Sie reichhaltigere Präsentationen erstellen, indem Sie mehrere Formen als ein einzelnes Objekt behandeln. Sie können neue Gruppenformen hinzufügen, vorhandene öffnen, mit Kindformen füllen und deren Eigenschaften lesen oder ändern. So fügen Sie einer Folie ein GroupShape hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich einen Verweis auf eine Folie nach Index.
3. Fügen Sie der Folie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) hinzu.
4. Fügen Sie Formen zur neuen Gruppe hinzu.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel zeigt, wie ein GroupShape zu einer Folie hinzugefügt wird.

```py
import aspose.slides as slides

# Instanziiere die Presentation-Klasse.
with slides.Presentation() as presentation:
    # Hole die erste Folie.
    slide = presentation.slides[0]

    # Füge ein GroupShape zur Folie hinzu.
    group_shape = slide.shapes.add_group_shape()

    # Füge Formen innerhalb des GroupShape hinzu.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Schreibe die PPTX-Datei auf die Festplatte.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf die Alt‑Text‑Eigenschaft**

In diesem Abschnitt wird erklärt, wie der Alt‑Text von Formen, die in einem GroupShape auf einer Folie enthalten sind, mit Aspose.Slides ausgelesen wird. So greifen Sie auf den Alt‑Text zu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, um eine PPTX‑Datei zu repräsentieren.
2. Holen Sie sich einen Verweis auf die Folie nach Index.
3. Greifen Sie auf die Formen‑Sammlung der Folie zu.
4. Greifen Sie auf das [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) zu.
5. Lesen Sie die Alt‑Text‑Eigenschaft.

Das folgende Beispiel ruft den Alt‑Text von Formen innerhalb von Gruppenformen ab.

```py
import aspose.slides as slides

# Instanziiere die Presentation-Klasse, um die PPTX-Datei zu öffnen.
with slides.Presentation("group_shape.pptx") as presentation:
    # Hole die erste Folie.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Greife auf das GroupShape zu.
            for child_shape in shape.shapes:
                # Greife auf die Alt-Text-Eigenschaft zu.
                print(child_shape.alternative_text)
```

## **FAQ**

**Wird verschachtelte Gruppierung (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) verfügt über eine [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/)-Eigenschaft, die direkt die Hierarchieunterstützung anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie steuere ich die Z‑Reihenfolge der Gruppe relativ zu anderen Objekten auf der Folie?**

Verwenden Sie die [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/)-Eigenschaft des [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), um die Position im Anzeige‑Stack zu prüfen oder zu ändern.

**Kann ich das Verschieben/Bearbeiten/Aufheben der Gruppierung verhindern?**

Ja. Der Sperr‑Abschnitt der Gruppe wird über [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) bereitgestellt, wodurch Sie bestimmte Vorgänge auf dem Objekt einschränken können.