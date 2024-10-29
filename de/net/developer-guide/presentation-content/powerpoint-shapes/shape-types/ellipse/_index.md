---
title: Ellipse
type: docs
weight: 30
url: /de/net/ellipse/
keywords: "Ellipse, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Ellipse in PowerPoint-Präsentation in C# oder .NET erstellen"
---


## **Ellipse erstellen**
In diesem Thema werden wir Entwicklern vorstellen, wie man Ellipsenformen zu ihren Folien mit Aspose.Slides für .NET hinzufügt. Aspose.Slides für .NET bietet eine einfachere Reihe von APIs, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen. Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden
1. Fügen Sie eine AutoShape vom Typ Ellipse mit der AddAutoShape-Methode hinzu, die vom IShapes-Objekt bereitgestellt wird
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei

Im folgenden Beispiel haben wir einer Folie die erste Ellipse hinzugefügt.

```c#
// Instanziieren der Präsentation-Klasse, die die PPTX darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie sich die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Formatierte Ellipse erstellen**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ Ellipse mit der AddAutoShape-Methode hinzu, die vom IShapes-Objekt bereitgestellt wird.
1. Setzen Sie den Fülltyp der Ellipse auf Solid.
1. Setzen Sie die Farbe der Ellipse mit der Eigenschaft SolidFillColor.Color, wie sie vom FillFormat-Objekt, das mit dem IShape-Objekt verbunden ist, bereitgestellt wird.
1. Setzen Sie die Farbe der Linien der Ellipse.
1. Setzen Sie die Breite der Linien der Ellipse.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir einer Folie der Präsentation eine formatierte Ellipse hinzugefügt.

```c#
// Instanziieren der Präsentation-Klasse, die die PPTX darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie sich die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Wenden Sie einige Formatierungen auf die Ellipsenform an
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```