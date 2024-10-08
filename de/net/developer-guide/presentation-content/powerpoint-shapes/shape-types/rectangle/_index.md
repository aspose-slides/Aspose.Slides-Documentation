---
title: Rechteck
type: docs
weight: 80
url: /de/net/rectangle/
keywords: "Rechteck erstellen, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Rechteck in einer PowerPoint-Präsentation in C# oder .NET erstellen"
---


## **Einfaches Rechteck erstellen**
Wie in den vorherigen Themen geht es auch hier darum, eine Form hinzuzufügen, und dieses Mal ist die Form, über die wir sprechen werden, das Rechteck. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für .NET hinzufügen können. Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse.
1. Erhalten Sie die Referenz zu einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie eine IAutoShape vom Typ Rechteck mit der Methode AddAutoShape, die vom IShapes-Objekt bereitgestellt wird, hinzu.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.

```c#
// Instanziieren Sie die Präsentationsklasse, die das PPTX darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie sich die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie ein Autoshape vom Typ Rechteck hinzu
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Formatiertes Rechteck erstellen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse.
1. Erhalten Sie die Referenz zu einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie eine IAutoShape vom Typ Rechteck mit der Methode AddAutoShape, die vom IShapes-Objekt bereitgestellt wird, hinzu.
1. Setzen Sie den Fülltyp des Rechtecks auf Fest.
1. Setzen Sie die Farbe des Rechtecks mit der SolidFillColor.Color-Eigenschaft, die vom FillFormat-Objekt bereitgestellt wird, das mit dem IShape-Objekt verbunden ist.
1. Setzen Sie die Farbe der Linien des Rechtecks.
1. Setzen Sie die Breite der Linien des Rechtecks.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.
   Die obigen Schritte sind im folgenden Beispiel implementiert.

```c#
// Instanziieren Sie die Präsentationsklasse, die das PPTX darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie sich die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie ein Autoshape vom Typ Rechteck hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Wenden Sie einige Formatierungen auf die Rechteckform an
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Wenden Sie einige Formatierungen auf die Linie des Rechtecks an
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```