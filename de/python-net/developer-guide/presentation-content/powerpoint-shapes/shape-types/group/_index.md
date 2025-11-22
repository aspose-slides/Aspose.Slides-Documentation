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
description: "Erfahren Sie, wie Sie Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python gruppieren und aufheben - schnelle, schrittweise Anleitung mit kostenfreiem Code."
---

## **Überblick**

Das Gruppieren von Formen ermöglicht es, mehrere Zeichenobjekte als eine Einheit zu behandeln, sodass Sie sie gemeinsam verschieben, skalieren, formatieren und transformieren können. Mit Aspose.Slides für Python können Sie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) erstellen, untergeordnete Formen darin anordnen und das Ergebnis als PPTX speichern. Dieser Artikel zeigt, wie Sie einer Folie ein Gruppierungsobjekt hinzufügen und wie Sie auf Barrierefreiheits‑Metadaten wie Alternativtext von Formen innerhalb der Gruppe zugreifen können, um eine klarere Struktur und reichhaltigere, leichter wartbare Präsentationen zu ermöglichen.

## **Gruppierungsformen hinzufügen**

Aspose.Slides unterstützt die Arbeit mit Gruppierungsformen auf einer Folie. Diese Funktion ermöglicht es, reichhaltigere Präsentationen zu erstellen, indem mehrere Formen als ein einzelnes Objekt behandelt werden. Sie können neue Gruppierungsformen hinzufügen, vorhandene abrufen, mit untergeordneten Formen füllen und deren Eigenschaften auslesen oder ändern. So fügen Sie einer Folie ein Gruppierungsobjekt hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie eine Referenz auf eine Folie anhand ihres Index.  
3. Fügen Sie der Folie ein [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)-Objekt hinzu.  
4. Fügen Sie dem neuen Gruppierungsobjekt Formen hinzu.  
5. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das nachstehende Beispiel zeigt, wie ein Gruppierungsobjekt zu einer Folie hinzugefügt wird.
```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse.
with slides.Presentation() as presentation:
    # Erste Folie erhalten.
    slide = presentation.slides[0]

    # Gruppierungsform zur Folie hinzufügen.
    group_shape = slide.shapes.add_group_shape()

    # Formen innerhalb der Gruppierungsform hinzufügen.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # PPTX-Datei auf die Festplatte schreiben.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **Zugriff auf die Alt‑Text‑Eigenschaft**

Dieser Abschnitt erklärt, wie Sie den Alt‑Text von Formen, die in einem Gruppierungsobjekt auf einer Folie enthalten sind, mit Aspose.Slides auslesen können. So greifen Sie auf den Alt‑Text der Formen zu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, um eine PPTX-Datei zu repräsentieren.  
2. Holen Sie eine Referenz auf die Folie anhand ihres Index.  
3. Greifen Sie auf die Formen‑Sammlung der Folie zu.  
4. Greifen Sie auf das [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)-Objekt zu.  
5. Lesen Sie die Alt‑Text‑Eigenschaft.

Das nachstehende Beispiel ruft den Alt‑Text von Formen ab, die in Gruppierungsobjekten enthalten sind.
```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um die PPTX-Datei zu öffnen.
with slides.Presentation("group_shape.pptx") as presentation:
    # Erste Folie erhalten.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Auf die Gruppierungsform zugreifen.
            for child_shape in shape.shapes:
                # Auf die Alt-Text-Eigenschaft zugreifen.
                print(child_shape.alternative_text)
```


## **FAQ**

**Wird verschachteltes Gruppieren (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) verfügt über die [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/)‑Eigenschaft, die die Hierarchieunterstützung direkt anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/)‑Eigenschaft des [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), um seine Position im Anzeigestapel zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Aufheben der Gruppierung verhindern?**

Ja. Der Sperrbereich der Gruppe wird über [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) bereitgestellt, mit dem Sie Vorgänge an dem Objekt einschränken können.
