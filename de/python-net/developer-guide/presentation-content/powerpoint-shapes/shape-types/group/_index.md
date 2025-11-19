---
title: Gruppieren von Präsentationsformen mit Python
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
description: "Erfahren Sie, wie Sie Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python gruppieren und aufheben—schnelle, schrittweise Anleitung mit kostenlosem Code."
---

## **Übersicht**

Das Gruppieren von Formen ermöglicht es Ihnen, mehrere Zeichenobjekte als eine Einheit zu behandeln, sodass Sie sie gemeinsam verschieben, skalieren, formatieren und transformieren können. Mit Aspose.Slides für Python können Sie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), hinzufügen und Kindformen darin anordnen und das Ergebnis als PPTX speichern. Dieser Artikel zeigt, wie man einer Folie ein Gruppenobjekt hinzufügt und wie man auf Barrierefreiheits‑Metadaten wie Alt‑Text von Formen innerhalb der Gruppe zugreift, wodurch eine sauberere Struktur sowie reichhaltigere und wartbarere Präsentationen ermöglicht werden.

## **Gruppenformen hinzufügen**

Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf einer Folie. Diese Funktion ermöglicht es Ihnen, reichhaltigere Präsentationen zu erstellen, indem Sie mehrere Formen als ein einzelnes Objekt behandeln. Sie können neue Gruppenformen hinzufügen, bestehende abrufen, sie mit Kindformen füllen und beliebige ihrer Eigenschaften lesen oder ändern. So fügen Sie einer Folie eine Gruppenform hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz auf eine Folie anhand ihres Index.  
3. Fügen Sie der Folie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)‑Objekt hinzu.  
4. Fügen Sie dem neuen Gruppenobjekt Formen hinzu.  
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel zeigt, wie man einer Folie ein Gruppenobjekt hinzufügt.
```py
import aspose.slides as slides

# Instanzieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie der Folie ein Gruppenobjekt hinzu.
    group_shape = slide.shapes.add_group_shape()

    # Fügen Sie Formen innerhalb des Gruppenobjekts hinzu.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Schreiben Sie die PPTX-Datei auf die Festplatte.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **Auf die Alt‑Text‑Eigenschaft zugreifen**

Dieser Abschnitt erklärt, wie Sie den Alt‑Text von Formen, die innerhalb einer Gruppenform auf einer Folie enthalten sind, mit Aspose.Slides auslesen können. So greifen Sie auf den Alt‑Text der Formen zu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse, um eine PPTX‑Datei darzustellen.  
2. Holen Sie eine Referenz auf die Folie anhand ihres Index.  
3. Greifen Sie auf die Formensammlung der Folie zu.  
4. Greifen Sie auf die [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)‑Instanz zu.  
5. Lesen Sie die Alt‑Text‑Eigenschaft.

Das folgende Beispiel ruft den Alt‑Text von Formen ab, die innerhalb von Gruppenformen enthalten sind.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um die PPTX‑Datei zu öffnen.
with slides.Presentation("group_shape.pptx") as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Greifen Sie auf die Gruppenform zu.
            for child_shape in shape.shapes:
                # Greifen Sie auf die Alt‑Text‑Eigenschaft zu.
                print(child_shape.alternative_text)
```


## **FAQ**

**Wird verschachteltes Gruppieren (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) verfügt über eine [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/)‑Eigenschaft, die direkt die Unterstützung für Hierarchien anzeigt (eine Gruppe kann ein Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe relativ zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)'s [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/)‑Eigenschaft, um ihre Position im Anzeigestapels zu prüfen oder zu ändern.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrbereich der Gruppe wird über [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) bereitgestellt, wodurch Sie Vorgänge an dem Objekt einschränken können.