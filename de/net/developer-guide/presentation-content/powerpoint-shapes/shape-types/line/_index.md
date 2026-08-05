---
title: Linienformen zu Präsentationen in .NET hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/net/line/
keywords:
- Linie
- Linie erstellen
- Linie hinzufügen
- einfache Linie
- Linie konfigurieren
- Linie anpassen
- Strichstil
- Pfeilspitze
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint‑Präsentationen mit Aspose.Slides für .NET manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---
## **Übersicht**

Aspose.Slides ermöglicht das programmatische Hinzufügen von Linienformen zu PowerPoint‑Folien. Dieser Artikel zeigt, wie man eine einfache Linie erstellt und wie man eine Linie anpasst, sodass sie wie ein Pfeil aussieht.

Sie lernen, wie man einer Folie eine Linienform hinzufügt, ihr Aussehen anpasst und die aktualisierte Präsentation speichert. Die Beispiele konzentrieren sich auf praktische Einstellungen zur Linienformatierung wie Stil, Breite, Strichmuster, Pfeilspitzenoptionen und Füllfarbe.

## **Einfache Linie erstellen**
Um einer ausgewählten Folie der Präsentation eine einfache gerade Linie hinzuzufügen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)Klasse.
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der von dem Shapes‑Objekt bereitgestellten [AddAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/methods/addautoshape/index)-Methode ein AutoShape vom Typ Linie hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```c#
 // Instanziiere die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
using (Presentation pres = new Presentation())
{
    // Hole die erste Folie
    ISlide sld = pres.Slides[0];

    // Füge ein AutoShape vom Typ Linie hinzu
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Schreibe die PPTX-Datei auf die Festplatte
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Pfeilförmige Linie erstellen**
Aspose.Slides für .NET ermöglicht Entwicklern zudem, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Versuchen wir, einige Eigenschaften einer Linie so zu konfigurieren, dass sie wie ein Pfeil aussieht. Bitte folgen Sie den folgenden Schritten, um dies zu erreichen:

- Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)Klasse[](http://www.aspose.com/api/net/slides/de/aspose.slides/)[](http://www.aspose.com/api/net/slides/de/aspose.slides/).
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der von dem Shapes‑Objekt bereitgestellten AddAutoShape‑Methode ein AutoShape vom Typ Linie hinzu.
- Setzen Sie den Linienstil auf einen der von Aspose.Slides für .NET angebotenen Stile.
- Legen Sie die Breite der Linie fest.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/de/net/aspose.slides/linedashstyle) der Linie auf einen der von Aspose.Slides für .NET angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/de/net/aspose.slides/linearrowheadstyle) und die Länge des Startpunkts der Linie.
- Setzen Sie den Arrow Head Style und die Länge des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```c#
 // Instanziiere die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
using (Presentation pres = new Presentation())
{

    // Hole die erste Folie
    ISlide sld = pres.Slides[0];

    // Füge ein AutoShape vom Typ Linie hinzu
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Wende einige Formatierungen auf die Linie an
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // Schreibe die PPTX-Datei auf die Festplatte
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, sodass sie an Formen „einrastet“?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/de/net/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen einrasten zu lassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/de/net/aspose.slides/connector/)-Typ und die [corresponding APIs](/slides/de/net/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Design geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/net/shape-effective-properties/) über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ilinefillformateffectivedata/) — diese berücksichtigen bereits Vererbung und Designstile.

**Kann ich eine Linie vor Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen bieten [Sperrobjekte](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/autoshapellock/), mit denen Sie [Bearbeitungsvorgänge verbieten](/slides/de/net/applying-protection-to-presentation/) können.