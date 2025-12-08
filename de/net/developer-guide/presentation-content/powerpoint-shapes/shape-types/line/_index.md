---
title: Linie
type: docs
weight: 50
url: /de/net/Line/
keywords: "Linie, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Linie in PowerPoint-Präsentation in C# oder .NET hinzufügen"
---

Aspose.Slides für .NET unterstützt das Hinzufügen verschiedener Formen zu den Folien. In diesem Thema beginnen wir damit, Linien zu den Folien hinzuzufügen. Mit Aspose.Slides für .NET können Entwickler nicht nur einfache Linien erstellen, sondern auch ausgefallene Linien auf den Folien zeichnen.

## **Einfache Linie erstellen**
Um eine einfache Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der Methode [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index), die vom Shapes‑Objekt bereitgestellt wird, eine AutoShape vom Typ Linie hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```c#
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Erste Folie holen
    ISlide sld = pres.Slides[0];

    // AutoShape vom Typ Linie hinzufügen
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //PPTX auf Festplatte schreiben
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```



## **Pfeilförmige Linie erstellen**
Aspose.Slides für .NET ermöglicht es Entwicklern außerdem, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Versuchen wir, einige Eigenschaften einer Linie so einzustellen, dass sie wie ein Pfeil aussieht. Befolgen Sie dazu die folgenden Schritte:

- Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der Methode AddAutoShape, die vom Shapes‑Objekt bereitgestellt wird, eine AutoShape vom Typ Linie hinzu.
- Setzen Sie den Linienstil auf einen der von Aspose.Slides für .NET angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) der Linie auf einen der von Aspose.Slides für .NET angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) und die Länge des Startpunkts der Linie.
- Setzen Sie den Arrow Head Style und die Länge des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```c#
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Erste Folie holen
    ISlide sld = pres.Slides[0];

    // AutoShape vom Typ Linie hinzufügen
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Einige Formatierungen auf die Linie anwenden
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //PPTX auf Festplatte schreiben
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich eine normale Linie in einen Verbinder umwandeln, sodass sie „einrastet“?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) wird nicht automatisch zu einem Verbinder. Verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/)-Typ und die [corresponding APIs](/slides/de/net/connector/) für Verbindungen.

**Wie gehe ich vor, wenn die Eigenschaften einer Linie vom Design geerbt werden und die endgültigen Werte schwer zu bestimmen sind?**

Lesen Sie die [effective properties](/slides/de/net/shape-effective-properties/) über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) – diese berücksichtigen bereits Vererbung und Designstile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Shapes bieten [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/), mit denen Sie [disallow editing operations](/slides/de/net/applying-protection-to-presentation/) unterbinden können.
