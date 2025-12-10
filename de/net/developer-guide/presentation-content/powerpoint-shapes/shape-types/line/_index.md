---
title: Linienformen zu Präsentationen in .NET hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/net/Line/
keywords:
- "Linie"
- "Linie erstellen"
- "Linie hinzufügen"
- "einfache Linie"
- "Linie konfigurieren"
- "Linie anpassen"
- "Strichstil"
- "Pfeilspitze"
- "PowerPoint"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie das Linienformat in PowerPoint-Präsentationen mit Aspose.Slides für .NET manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

Aspose.Slides für .NET unterstützt das Hinzufügen verschiedener Formen zu den Folien. In diesem Thema beginnen wir mit Formen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides für .NET können Entwickler nicht nur einfache Linien erstellen, sondern auch ausgefallene Linien auf den Folien zeichnen.

## **Eine einfache Linie erstellen**
Um eine einfache Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie ein AutoShape vom Typ Line hinzu, indem Sie die Methode [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) des Shapes-Objekts verwenden.
- Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir einer Folie der Präsentation eine Linie hinzugefügt.
```c#
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Holen Sie die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie ein AutoShape vom Typ Linie hinzu
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Schreiben Sie die PPTX auf die Festplatte
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Eine Pfeilförmige Linie erstellen**
Aspose.Slides für .NET ermöglicht es Entwicklern auch, einige Eigenschaften der Linie zu konfigurieren, damit sie ansprechender wirkt. Versuchen wir, einige Eigenschaften einer Linie zu konfigurieren, damit sie wie ein Pfeil aussieht. Gehen Sie dazu wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie ein AutoShape vom Typ Line hinzu, indem Sie die AddAutoShape-Methode des Shapes-Objekts verwenden.
- Legen Sie den Linienstil auf einen der von Aspose.Slides für .NET angebotenen Stile fest.
- Setzen Sie die Breite der Linie.
- Legen Sie den [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) der Linie auf einen der von Aspose.Slides für .NET angebotenen Stile fest.
- Legen Sie den [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) und die Länge des Startpunkts der Linie fest.
- Legen Sie den Arrow Head Style und die Länge des Endpunkts der Linie fest.
- Speichern Sie die modifizierte Präsentation als PPTX-Datei.
```c#
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie ein AutoShape vom Typ Linie hinzu
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


## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, sodass sie an Formen „einrastet“?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen einrasten zu lassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/)-Typ und die entsprechenden APIs [/slides/net/connector/] für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwer ist, die endgültigen Werte zu bestimmen?**

Lesen Sie die effektiven Eigenschaften [/slides/net/shape-effective-properties/] über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) – diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie vor Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Shapes bieten [Lock‑Objekte](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/), mit denen Sie [Bearbeitungsoperationen verhindern](/slides/de/net/applying-protection-to-presentation/).