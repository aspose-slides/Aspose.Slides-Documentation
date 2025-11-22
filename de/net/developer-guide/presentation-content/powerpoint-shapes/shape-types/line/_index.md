---
title: Linie
type: docs
weight: 50
url: /de/net/Line/
keywords: "Linie, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Linie in PowerPoint-Präsentation in C# oder .NET hinzufügen"
---

Aspose.Slides for .NET unterstützt das Hinzufügen verschiedener Shape‑Typen zu den Folien. In diesem Thema beginnen wir damit, Linien zu den Folien hinzuzufügen. Mit Aspose.Slides for .NET können Entwickler nicht nur einfache Linien erstellen, sondern auch ausgefallene Linien auf den Folien zeichnen.
## **Einfache Linie erstellen**
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der vom Shapes‑Objekt bereitgestellten Methode [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) eine AutoShape vom Typ Line hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir der ersten Folie der Präsentation eine Linie hinzugefügt.
```c#
 // Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Holen Sie die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Schreiben Sie die PPTX auf die Festplatte
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```



## **Pfeilförmige Linie erstellen**
Aspose.Slides for .NET ermöglicht es Entwicklern außerdem, einige Eigenschaften der Linie zu konfigurieren, damit sie ansprechender wirkt. Versuchen wir, einige Eigenschaften einer Linie so zu konfigurieren, dass sie wie ein Pfeil aussieht. Befolgen Sie dazu die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der vom Shapes‑Objekt bereitgestellten AddAutoShape‑Methode eine AutoShape vom Typ Line hinzu.
- Setzen Sie den Linienstil auf einen der von Aspose.Slides for .NET angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) der Linie auf einen der von Aspose.Slides for .NET angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) und die Länge des Startpunkts der Linie.
- Setzen Sie den Arrow Head Style und die Länge des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```c#
 // Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie die erste Folie
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

    //Write die PPTX auf die Festplatte
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, damit sie „einrastet“?**

Nein. Eine normale Linie (eine [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/)-Typ und die [entsprechenden APIs](/slides/de/net/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Thema geerbt werden und die endgültigen Werte schwer zu ermitteln sind?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/net/shape-effective-properties/) über die Klassen [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) – diese berücksichtigen bereits Vererbung und Themenstile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Shapes bieten [Lock‑Objekte](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/), mit denen Sie [Bearbeitungsvorgänge verhindern](/slides/de/net/applying-protection-to-presentation/).