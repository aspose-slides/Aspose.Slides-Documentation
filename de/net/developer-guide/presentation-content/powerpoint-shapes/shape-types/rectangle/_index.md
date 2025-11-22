---
title: Rechteck
type: docs
weight: 80
url: /de/net/rectangle/
keywords: "Rechteck erstellen, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Rechteck in PowerPoint-Präsentation in C# oder .NET erstellen"
---

## **Einfaches Rechteck erstellen**
Wie in vorherigen Themen geht es hier ebenfalls um das Hinzufügen einer Form und diesmal wird die Form, die wir besprechen, Rechteck sein. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für .NET hinzufügen können. Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie mit der Methode AddAutoShape, die vom IShapes‑Objekt bereitgestellt wird, ein IAutoShape vom Typ Rectangle hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
```c#
// Instanziiere die Presentation-Klasse, die die PPTX repräsentiert
using (Presentation pres = new Presentation())
{

    // Hole die erste Folie
    ISlide sld = pres.Slides[0];

    // Füge eine Autoshape vom Typ Rectangle hinzu
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Schreibe die PPTX-Datei auf die Festplatte
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Formatiertes Rechteck erstellen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, befolgen Sie bitte die untenstehenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie mit der Methode AddAutoShape, die vom IShapes‑Objekt bereitgestellt wird, ein IAutoShape vom Typ Rectangle hinzu.
4. Setzen Sie den Fülltyp des Rechtecks auf Solid.
5. Setzen Sie die Farbe des Rechtecks über die Eigenschaft SolidFillColor.Color, die vom FillFormat‑Objekt bereitgestellt wird, das mit dem IShape‑Objekt verknüpft ist.
6. Setzen Sie die Farbe der Linien des Rechtecks.
7. Setzen Sie die Breite der Linien des Rechtecks.
8. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die obigen Schritte sind im nachstehenden Beispiel umgesetzt.
```c#
 // Instanziiere die Presentation-Klasse, die die PPTX darstellt
using (Presentation pres = new Presentation())
{

    // Hole die erste Folie
    ISlide sld = pres.Slides[0];

    // Füge eine AutoShape vom Typ Rectangle hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Wende einige Formatierungen auf die Rechtecksform an
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Wende einige Formatierungen auf die Linie des Rechtecks an
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Schreibe die PPTX-Datei auf die Festplatte
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**  
Verwenden Sie den abgerundeten [Shape‑Typ](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; die Rundung kann zudem pro Ecke über Geometrie‑Anpassungen angewendet werden.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**  
Wählen Sie den Bild‑[Fill‑Typ](https://reference.aspose.com/slides/net/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [Stretch‑/Tile‑Modi](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchten haben?**  
Ja. [Außer‑/Innenschatten, Leuchten und weiche Kanten](/slides/de/net/shape-effect/) stehen mit anpassbaren Parametern zur Verfügung.

**Kann ich ein Rechteck in einen Button mit Hyperlink verwandeln?**  
Ja. [Weisen Sie der Form beim Klicken einen Hyperlink](/slides/de/net/manage-hyperlinks/) zu (Sprung zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**  
[Verwenden Sie Form‑Sperren](/slides/de/net/applying-protection-to-presentation/): Sie können das Verschieben, die Größenänderung, die Auswahl oder die Textbearbeitung verbieten, um das Layout zu erhalten.

**Kann ich ein Rechteck in ein Rasterbild oder SVG konvertieren?**  
Ja. Sie können die Form mit [rendern](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) zu einem Bild mit bestimmter Größe/Skalierung oder sie [als SVG exportieren](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) für die Vektornutzung.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Theme und Vererbung?**  
[Verwenden Sie die effektiven Eigenschaften der Form](/slides/de/net/shape-effective-properties/): Die API liefert berechnete Werte, die Theme‑Stile, Layout und lokale Einstellungen berücksichtigen, wodurch die Formatierungsanalyse vereinfacht wird.