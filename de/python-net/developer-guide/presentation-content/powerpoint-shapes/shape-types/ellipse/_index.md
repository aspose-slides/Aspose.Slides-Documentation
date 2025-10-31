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
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für Python via .NET in PPT-, PPTX- und ODP-Präsentationen erstellen, formatieren und manipulieren – mit Codebeispielen."
---

## **Ellipse erstellen**
In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für Python via .NET vor. Aspose.Slides für Python via .NET bietet eine einfachere API, um verschiedene Formen mit nur wenigen Codezeilen zu zeichnen. Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Rufen Sie die Referenz einer Folie über ihren Index ab
3. Fügen Sie über die AddAutoShape-Methode des IShapes-Objekts eine AutoShape vom Typ Ellipse hinzu
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei

```py
import aspose.slides as slides

# Instanziiere die Presentation-Klasse, die die PPTX repräsentiert
with slides.Presentation() as pres:
    # Hole die erste Folie
    sld = pres.slides[0]

    # Füge eine AutoShape vom Typ Ellipse hinzu
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Schreibe die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatierte Ellipse erstellen**
Um einer Folie eine besser formatierte Ellipse hinzuzufügen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Rufen Sie die Referenz einer Folie über ihren Index ab
3. Fügen Sie über die AddAutoShape-Methode des IShapes-Objekts eine AutoShape vom Typ Ellipse hinzu
4. Setzen Sie den Fülltyp der Ellipse auf Solid
5. Setzen Sie die Farbe der Ellipse über die Eigenschaft SolidFillColor.Color des FillFormat-Objekts, das dem IShape-Objekt zugeordnet ist
6. Setzen Sie die Farbe der Linien der Ellipse
7. Setzen Sie die Breite der Linien der Ellipse
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei

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

    # Schreibe die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse relativ zu den Folieneinheiten fest?**  
Koordinaten und Größen werden üblicherweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse basieren Sie Ihre Berechnungen auf der Foliengröße und konvertieren Sie erforderliche Millimeter oder Zoll in Punkte, bevor Sie Werte zuweisen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Staplereihenfolge steuern)?**  
Passen Sie die Zeichnungsreihenfolge des Objekts an, indem Sie es nach vorne bringen oder nach hinten senden. Dadurch kann die Ellipse andere Objekte überlappen oder jene darunter sichtbar machen.

**Wie animiere ich das Auftreten oder die Betonung einer Ellipse?**  
[Apply](/slides/de/python-net/shape-animation/) Eingangs-, Betonungs- oder Ausgangseffekte auf die Form anwenden und Trigger sowie Timing konfigurieren, um festzulegen, wann und wie die Animation abgespielt wird.