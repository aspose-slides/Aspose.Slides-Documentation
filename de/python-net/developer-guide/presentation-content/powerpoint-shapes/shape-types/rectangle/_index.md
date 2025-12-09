---
title: Rechtecke zu Präsentationen in Python hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/python-net/rectangle/
keywords:
- Rechteck hinzufügen
- Rechteck erstellen
- Rechteckform
- einfaches Rechteck
- formatiertes Rechteck
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Steigern Sie Ihre PowerPoint- und OpenDocument-Präsentationen, indem Sie mit Aspose.Slides für Python über .NET Rechtecke hinzufügen – gestalten und ändern Sie Formen ganz einfach programmgesteuert."
---

## **Einfaches Rechteck erstellen**
Wie bei vorherigen Themen geht es auch hier um das Hinzufügen einer Form, und dieses Mal diskutieren wir das Rechteck. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für Python über .NET hinzufügen können. Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie eine IAutoShape vom Typ Rectangle mithilfe der AddAutoShape‑Methode, die vom IShapes‑Objekt bereitgestellt wird, hinzu.
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die die PPTX darstellt
with slides.Presentation() as pres:
    # Holen Sie die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine AutoShape des Typs Rectangle hinzu
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Schreiben Sie die PPTX‑Datei auf die Festplatte
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Formatiertes Rechteck erstellen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie eine IAutoShape vom Typ Rectangle mithilfe der AddAutoShape‑Methode, die vom IShapes‑Objekt bereitgestellt wird, hinzu.
1. Setzen Sie den Fülltyp des Rechtecks auf Solid.
1. Setzen Sie die Farbe des Rechtecks über die Eigenschaft SolidFillColor.Color, die vom FillFormat‑Objekt des IShape‑Objekts bereitgestellt wird.
1. Setzen Sie die Farbe der Linien des Rechtecks.
1. Setzen Sie die Breite der Linien des Rechtecks.
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.
   Die oben genannten Schritte sind im nachstehenden Beispiel umgesetzt.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation‑Klasse, die die PPTX repräsentiert
with slides.Presentation() as pres:
    # Holen Sie die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine AutoShape vom Typ Rectangle hinzu
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Wenden Sie einige Formatierungen auf die Rechtecksform an
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Wenden Sie einige Formatierungen auf die Linie des Rechtecks an
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Schreiben Sie die PPTX‑Datei auf die Festplatte
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den abgerundeten [Formtyp](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; das Abrunden kann auch für jede Ecke einzeln über Geometrie‑Anpassungen erfolgen.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild‑[Fülltyp](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [Dehnungs‑/Kachel‑Modi](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchten haben?**

Ja. [Äußerer/innerer Schatten, Leuchten und weiche Kanten](/slides/de/python-net/shape-effect/) sind verfügbar und verfügen über anpassbare Parameter.

**Kann ich ein Rechteck in einen Button mit Hyperlink umwandeln?**

Ja. [Weisen Sie der Form einen Hyperlink zu](/slides/de/python-net/manage-hyperlinks/) (Sprung zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**

[Verwenden Sie Form‑Sperren](/slides/de/python-net/applying-protection-to-presentation/): Sie können das Verschieben, Ändern der Größe, Auswählen oder Bearbeiten von Text verbieten, um das Layout beizubehalten.

**Kann ich ein Rechteck in ein Rasterbild oder SVG konvertieren?**

Ja. Sie können die Form [rendern](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) zu einem Bild mit einer angegebenen Größe/Skala oder sie [als SVG exportieren](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) für die Verwendung als Vektor.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Theme und Vererbung?**

[Verwenden Sie die effektiven Eigenschaften der Form](/slides/de/python-net/shape-effective-properties/): Die API liefert berechnete Werte, die Theme‑Stile, Layout und lokale Einstellungen berücksichtigen und die Formatierungsanalyse vereinfachen.