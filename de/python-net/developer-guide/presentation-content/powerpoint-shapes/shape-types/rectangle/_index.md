---
title: "Rechtecke zu Präsentationen in Python hinzufügen"
linktitle: "Rechteck"
type: docs
weight: 80
url: /de/python-net/rectangle/
keywords:
- "Rechteck hinzufügen"
- "Rechteck erstellen"
- "Rechteckform"
- "einfaches Rechteck"
- "formatiertes Rechteck"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Verbessern Sie Ihre PowerPoint‑ und OpenDocument‑Präsentationen, indem Sie mit Aspose.Slides für Python via .NET Rechtecke hinzufügen – Formen einfach programmgesteuert entwerfen und ändern."
---

## **Einfaches Rechteck erstellen**
Wie in den vorherigen Themen geht es auch hier um das Hinzufügen einer Form und diesmal diskutieren wir das Rechteck. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für Python via .NET hinzufügen können. Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.  
3. Fügen Sie eine IAutoShape vom Typ Rectangle mithilfe der Methode AddAutoShape hinzu, die vom IShapes‑Objekt bereitgestellt wird.  
4. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Im folgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Write the PPTX file to disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatiertes Rechteck erstellen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.  
3. Fügen Sie eine IAutoShape vom Typ Rectangle mithilfe der Methode AddAutoShape hinzu, die vom IShapes‑Objekt bereitgestellt wird.  
4. Setzen Sie den Fülltyp des Rechtecks auf Solid.  
5. Setzen Sie die Farbe des Rechtecks über die Eigenschaft `SolidFillColor.Color` des mit dem IShape‑Objekt verbundenen FillFormat‑Objekts.  
6. Setzen Sie die Farbe der Linien des Rechtecks.  
7. Setzen Sie die Breite der Linien des Rechtecks.  
8. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.  

Die oben genannten Schritte sind im nachstehenden Beispiel implementiert.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Apply some formatting to rectangle shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Apply some formatting to the line of rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write the PPTX file to disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**  
Verwenden Sie den abgerundeten [Shape‑Typ](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; das Abrunden kann ebenfalls pro Ecke über Geometrie‑Anpassungen erfolgen.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**  
Wählen Sie den Bild‑[Fill‑Typ](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [Stretch‑/Tiling‑Modi](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchten haben?**  
Ja. [Außen‑/Innenschatten, Leuchten und weiche Kanten](/slides/de/python-net/shape-effect/) stehen mit einstellbaren Parametern zur Verfügung.

**Kann ich ein Rechteck in einen Button mit Hyperlink umwandeln?**  
Ja. [Weisen Sie einen Hyperlink](/slides/de/python-net/manage-hyperlinks/) dem Klick auf die Form zu (Sprung zu Folie, Datei, Web‑Adresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**  
[Verwenden Sie Form‑Sperren](/slides/de/python-net/applying-protection-to-presentation/): Sie können das Verschieben, Größenändern, Auswählen oder Textbearbeiten verbieten, um das Layout zu bewahren.

**Kann ich ein Rechteck in ein Rasterbild oder SVG konvertieren?**  
Ja. Sie können die Form über die API [rendern] (http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) zu einem Bild mit gewünschter Größe/Skalierung oder [als SVG exportieren](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) für die Vektornutzung.

**Wie bekomme ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Design und Vererbung?**  
[Verwenden Sie die effektiven Eigenschaften der Form](/slides/de/python-net/shape-effective-properties/): Die API liefert berechnete Werte, die Design‑Stile, Layout und lokale Einstellungen berücksichtigen und die Formatierungsanalyse vereinfachen.