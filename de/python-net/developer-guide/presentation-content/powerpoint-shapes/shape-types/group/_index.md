---
title: Gruppe
type: docs
weight: 40
url: /python-net/group/
keywords: "Gruppenform, PowerPoint-Form, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie eine Gruppenform in einer PowerPoint-Präsentation in Python hinzu"
---

## **Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu unterstützen. Aspose.Slides für Python über .NET unterstützt das Hinzufügen oder Zugreifen auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu füllen, oder auf jede Eigenschaft der Gruppenform zuzugreifen. Um eine Gruppenform mit Aspose.Slides für Python über .NET zu einer Folie hinzuzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie die Formen zur hinzugefügten Gruppenform hinzu.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppenform hinzu.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse 
with slides.Presentation() as pres:
    # Holen Sie sich die erste Folie 
    sld = pres.slides[0]

    # Zugriff auf die Formensammlung der Folien 
    slideShapes = sld.shapes

    # Hinzufügen einer Gruppenform zur Folie 
    groupShape = slideShapes.add_group_shape()

    # Hinzufügen von Formen innerhalb der hinzugefügten Gruppenform 
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Hinzufügen eines Rahmen für die Gruppenform 
    groupShape.frame = slides.ShapeFrame(100, 300, 500, 40, -1, -1, 0)

    # Schreiben Sie die PPTX-Datei auf die Festplatte 
    pres.save("GroupShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Zugriff auf die AltText-Eigenschaft**
Dieses Thema zeigt einfache Schritte, einschließlich Codebeispielen, um eine Gruppenform hinzuzufügen und auf die AltText-Eigenschaft von Gruppenformen auf Folien zuzugreifen. Um auf den AltText einer Gruppenform auf einer Folie mit Aspose.Slides für Python über .NET zuzugreifen:

1. Instanziieren Sie die `Presentation`-Klasse, die die PPTX-Datei darstellt.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Zugriff auf die Formensammlung der Folien.
1. Zugriff auf die Gruppenform.
1. Zugriff auf die AltText-Eigenschaft.

Das folgende Beispiel greift auf den alternativen Text der Gruppenform zu.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei darstellt
with slides.Presentation(path + "AltText.pptx") as pres:

    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    for i in range(len(sld.shapes)):
        # Zugriff auf die Formensammlung der Folien
        shape = sld.shapes[i]

        if type(shape) is slides.GroupShape:
            # Zugriff auf die Gruppenform.
            for j in range(len(shape.shapes)):
                # Zugriff auf die AltText-Eigenschaft
                print(shape.shapes[j].alternative_text)
```