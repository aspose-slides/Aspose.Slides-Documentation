---
title: Ellipse
type: docs
weight: 30
url: /de/python-net/ellipse/
keywords: "Ellipse, PowerPoint-Form, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Ellipse in PowerPoint-Präsentationen in Python erstellen"
---


## **Ellipse erstellen**
In diesem Thema werden wir Entwicklern zeigen, wie sie Ellipsenformen zu ihren Folien mit Aspose.Slides für Python über .NET hinzufügen können. Aspose.Slides für Python über .NET bietet eine einfachere API, um verschiedene Arten von Formen mit nur wenigen Zeilen Code zu zeichnen. Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden
1. Fügen Sie eine AutoShape vom Typ Ellipse mit der Methode AddAutoShape hinzu, die vom IShapes-Objekt bereitgestellt wird
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei

Im folgenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die das PPTX repräsentiert
with slides.Presentation() as pres:
    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Formatierte Ellipse erstellen**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ Ellipse mit der Methode AddAutoShape hinzu, die vom IShapes-Objekt bereitgestellt wird.
1. Setzen Sie den Fülltyp der Ellipse auf Solid.
1. Setzen Sie die Farbe der Ellipse mit der SolidFillColor.Color-Eigenschaft, die vom FillFormat-Objekt bereitgestellt wird, das mit dem IShape-Objekt verknüpft ist.
1. Setzen Sie die Farbe der Linien der Ellipse.
1. Setzen Sie die Breite der Linien der Ellipse.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine formatierte Ellipse zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die das PPTX repräsentiert
with slides.Presentation() as pres:
    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Wenden Sie einige Formatierungen auf die Ellipsenform an
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```