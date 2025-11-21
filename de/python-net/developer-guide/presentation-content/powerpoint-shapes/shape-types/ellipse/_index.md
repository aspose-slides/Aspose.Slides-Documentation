---
title: Ellipsen zu Präsentationen in Python hinzufügen
linktitle: Ellipse
type: docs
weight: 30
url: /de/python-net/ellipse/
keywords:
- Ellipse
- Form
- Ellipse hinzufügen
- Ellipse erstellen
- Ellipse zeichnen
- formatierte Ellipse
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für Python via .NET in PPT-, PPTX- und ODP-Präsentationen erstellen, formatieren und manipulieren - inklusive Codebeispielen."
---

## **Ellipse erstellen**
In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für Python via .NET vor. Aspose.Slides für Python via .NET bietet einen einfacheren Satz von APIs, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen. Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Fügen Sie mit der Methode AddAutoShape des IShapes-Objekts eine AutoShape vom Typ Ellipse hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt.
```py
import aspose.slides as slides

# Instanziiere die Prseetation-Klasse, die die PPTX darstellt
with slides.Presentation() as pres:
    # Holen Sie die erste Folie
    sld = pres.slides[0]

    # Füge eine AutoShape vom Typ Ellipse hinzu
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Schreibe die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Formatierte Ellipse erstellen**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Fügen Sie mit der Methode AddAutoShape des IShapes-Objekts eine AutoShape vom Typ Ellipse hinzu.
4. Setzen Sie den Fülltyp der Ellipse auf Solid.
5. Setzen Sie die Farbe der Ellipse über die Eigenschaft SolidFillColor.Color, die vom FillFormat-Objekt bereitgestellt wird und dem IShape-Objekt zugeordnet ist.
6. Setzen Sie die Farbe der Linien der Ellipse.
7. Setzen Sie die Breite der Linien der Ellipse.
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine formatierte Ellipse zur ersten Folie der Präsentation hinzugefügt.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiere die Presentation-Klasse, die die PPTX darstellt
with slides.Presentation() as pres:
    # Hole die erste Folie
    sld = pres.slides[0]

    # Füge eine AutoShape vom Typ Ellipse hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Wende einige Formatierungen auf die Ellipsenform an
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Wende einige Formatierungen auf die Linie der Ellipse an
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Schreibe die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse relativ zu den Einheiten der Folie fest?**

Koordinaten und Größen werden typischerweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse sollten Sie Ihre Berechnungen auf der Foliengröße basieren und erforderliche Millimeter oder Zoll vor der Zuweisung in Punkte umrechnen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelanordnung steuern)?**

Passen Sie die Zeichenreihenfolge des Objekts an, indem Sie es nach vorne bringen oder nach hinten senden. Dadurch kann die Ellipse andere Objekte überlappen oder die darunter liegenden sichtbar machen.

**Wie animiere ich das Auftreten oder die Hervorhebung einer Ellipse?**

[Apply](/slides/de/python-net/shape-animation/) Eingangs‑, Hervorhebungs‑ oder Ausgangseffekte auf die Form und konfigurieren Sie Trigger und Timing, um zu steuern, wann und wie die Animation abgespielt wird.