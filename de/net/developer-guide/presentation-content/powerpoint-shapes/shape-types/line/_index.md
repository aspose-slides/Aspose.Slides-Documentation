---
title: Linie
type: docs
weight: 50
url: /de/net/Line/
keywords: "Linie, PowerPoint Form, PowerPoint Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Linie in PowerPoint Präsentation in C# oder .NET hinzufügen"
---

Aspose.Slides für .NET unterstützt das Hinzufügen verschiedener Arten von Formen zu den Folien. In diesem Thema werden wir mit Formen arbeiten, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides für .NET können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.
## **Einfache Linie erstellen**
Um eine einfache Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Linientyp mit der [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```c#
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
using (Presentation pres = new Presentation())
{
    // Holen Sie sich die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Schreiben Sie die PPTX auf die Festplatte
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Pfeilförmige Linie erstellen**
Aspose.Slides für .NET ermöglicht es Entwicklern auch, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Lassen Sie uns versuchen, einige Eigenschaften einer Linie so zu konfigurieren, dass sie wie ein Pfeil aussieht. Bitte folgen Sie den folgenden Schritten dazu:

- Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Linientyp mit der AddAutoShape-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
- Setzen Sie den Linienstil auf einen der von Aspose.Slides für .NET angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Strichstil](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) der Linie auf einen der von Aspose.Slides für .NET angebotenen Stile.
- Setzen Sie den [Pfeilkopf-Stil](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) und die Länge des Anfangspunkts der Linie.
- Setzen Sie den Pfeilkopf-Stil und die Länge des Endpunkts der Linie.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```c#
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
using (Presentation pres = new Presentation())
{

    // Holen Sie sich die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Wenden Sie einige Formatierungen auf die Linie an
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // Schreiben Sie die PPTX auf die Festplatte
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```