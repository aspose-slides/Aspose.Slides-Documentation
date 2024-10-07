---
title: Linie
type: docs
weight: 50
url: /python-net/line/
keywords: "Linie, PowerPoint-Form, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Linie in PowerPoint-Präsentation in Python hinzufügen"
---

Aspose.Slides für Python über .NET unterstützt das Hinzufügen verschiedener Arten von Formen zu den Folien. In diesem Thema werden wir mit Formen arbeiten, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides für Python über .NET können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ansprechende Linien auf den Folien zeichnen.
## **Einfache Linie erstellen**
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Linie mit der Methode [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) hinzu, die vom Shapes-Objekt bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im untenstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides

# Erstellen Sie eine Instanz der PresentationEx-Klasse, die die PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine AutoShape vom Typ Linie hinzu
    sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Schreiben Sie die PPTX auf die Festplatte
    pres.save("LineShape1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Pfeilförmige Linie erstellen**
Aspose.Slides für Python über .NET ermöglicht es Entwicklern auch, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Lassen Sie uns versuchen, einige Eigenschaften einer Linie so zu konfigurieren, dass sie wie ein Pfeil aussieht. Bitte folgen Sie den folgenden Schritten, um dies zu tun:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Linie mit der Methode AddAutoShape hinzu, die vom Shapes-Objekt bereitgestellt wird.
- Setzen Sie den Linienstil auf einen der von Aspose.Slides für Python über .NET angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash-Stil](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) der Linie auf einen der von Aspose.Slides für Python über .NET angebotenen Stile.
- Setzen Sie den [Pfeilkopf-Stil](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) und die Länge des Anfangspunktes der Linie.
- Setzen Sie den Pfeilkopf-Stil und die Länge des Endpunktes der Linie.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen Sie eine Instanz der PresentationEx-Klasse, die die PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine AutoShape vom Typ Linie hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Wenden Sie einige Formatierungen auf die Linie an
    shp.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shp.line_format.width = 10

    shp.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shp.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shp.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shp.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shp.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Schreiben Sie die PPTX auf die Festplatte
    pres.save("LineShape2_out.pptx", slides.export.SaveFormat.PPTX)
```