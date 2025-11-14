---
title: Rechteck
type: docs
weight: 80
url: /de/python-net/rectangle/
keywords: "Rechteck erstellen, PowerPoint-Form, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Rechteck in PowerPoint-Präsentation in Python erstellen"
---


## **Einfaches Rechteck erstellen**
Wie in den vorherigen Themen geht es auch hier um das Hinzufügen einer Form, und dieses Mal ist die Form, über die wir sprechen werden, das Rechteck. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für Python über .NET hinzufügen können. Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine IAutoShape vom Typ Rechteck mit der Methode AddAutoShape hinzu, die vom IShapes-Objekt zur Verfügung gestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides

# Instanziieren Sie die Präsentationsklasse, die die PPTX darstellt
with slides.Presentation() as pres:
    # Erhalten Sie die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine Autohshape vom Typ Rechteck hinzu
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Formatiertes Rechteck erstellen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine IAutoShape vom Typ Rechteck mit der Methode AddAutoShape hinzu, die vom IShapes-Objekt zur Verfügung gestellt wird.
1. Setzen Sie den Fülltyp des Rechtecks auf Fest.
1. Setzen Sie die Farbe des Rechtecks mit der Eigenschaft SolidFillColor.Color, wie sie vom FillFormat-Objekt bereitgestellt wird, das mit dem IShape-Objekt verknüpft ist.
1. Setzen Sie die Farbe der Linien des Rechtecks.
1. Setzen Sie die Breite der Linien des Rechtecks.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.
   Die obigen Schritte sind im folgenden Beispiel implementiert.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Präsentationsklasse, die die PPTX darstellt
with slides.Presentation() as pres:
    # Erhalten Sie die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine Autohshape vom Typ Rechteck hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Wenden Sie einige Formatierungen auf die Rechteckform an
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Wenden Sie einige Formatierungen auf die Linie des Rechtecks an
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```