---
title: Rechtecke zu Präsentationen in .NET hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/net/rectangle/
keywords:
- Rechteck hinzufügen
- Rechteck erstellen
- Rechteckform
- einfaches Rechteck
- formatiertes Rechteck
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verbessern Sie Ihre PowerPoint-Präsentationen, indem Sie mit Aspose.Slides für .NET Rechtecke hinzufügen – gestalten und ändern Sie Formen ganz einfach programmgesteuert."
---

## **Einfaches Rechteck erstellen**
Wie in vorherigen Themen geht es auch hier um das Hinzufügen einer Form und dieses Mal besprechen wir das Rechteck. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für .NET hinzufügen können. Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse.
1. Holen Sie die Referenz einer Folie anhand ihres Index.
1. Fügen Sie eine IAutoShape vom Typ Rectangle mithilfe der AddAutoShape‑Methode, die vom IShapes‑Objekt bereitgestellt wird, hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
```c#
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt

using (Presentation pres = new Presentation())
{
    // Holen Sie die erste Folie

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu

    //Write die PPTX-Datei auf dem Datenträger
}
```


## **Formatiertes Rechteck erstellen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse.
1. Holen Sie die Referenz einer Folie anhand ihres Index.
1. Fügen Sie eine IAutoShape vom Typ Rectangle mithilfe der AddAutoShape‑Methode, die vom IShapes‑Objekt bereitgestellt wird, hinzu.
1. Setzen Sie den Fülltyp des Rechtecks auf Solid.
1. Setzen Sie die Farbe des Rechtecks über die Eigenschaft SolidFillColor.Color, die vom FillFormat‑Objekt des zugehörigen IShape‑Objekts bereitgestellt wird.
1. Setzen Sie die Farbe der Linien des Rechtecks.
1. Setzen Sie die Breite der Linien des Rechtecks.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.
   Die obigen Schritte sind im nachstehenden Beispiel umgesetzt.
```c#
// Instanziieren Sie die Presentation‑Klasse, die die PPTX darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Wenden Sie einige Formatierungen auf die Rechteckform an
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Wenden Sie einige Formatierungen auf die Linien des Rechtecks an
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Schreiben Sie die PPTX‑Datei auf die Festplatte
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den abgerundeten [Shape‑Typ](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; das Abrunden kann auch für jede Ecke einzeln über Geometrie‑Anpassungen erfolgen.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild‑[Fill‑Typ](https://reference.aspose.com/slides/net/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [Stretch‑/Kachel‑Modi](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchten haben?**

Ja. [Außen‑/Innenschatten, Leuchten und weiche Kanten](/slides/de/net/shape-effect/) stehen mit einstellbaren Parametern zur Verfügung.

**Kann ich ein Rechteck in einen Button mit Hyperlink umwandeln?**

Ja. [Weisen Sie der Form einen Hyperlink](/slides/de/net/manage-hyperlinks/) zu (Springen zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**

[Verwenden Sie Form‑Sperren](/slides/de/net/applying-protection-to-presentation/): Sie können das Verschieben, Ändern der Größe, Auswählen oder Bearbeiten von Text verhindern, um das Layout zu erhalten.

**Kann ich ein Rechteck in ein Raster‑Bild oder SVG konvertieren?**

Ja. Sie können die Form [rendern](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) zu einem Bild mit festgelegter Größe/Skala oder [als SVG exportieren](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) für die Vektor‑Nutzung.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Theme und Vererbung?**

[Verwenden Sie die effektiven Eigenschaften der Form](/slides/de/net/shape-effective-properties/): Die API liefert berechnete Werte, die Theme‑Stile, Layout und lokale Einstellungen berücksichtigen, was die Formatierungsanalyse vereinfacht.