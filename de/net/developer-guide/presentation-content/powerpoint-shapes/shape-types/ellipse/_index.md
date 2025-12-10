---
title: Ellipsen zu Präsentationen in .NET hinzufügen
linktitle: Ellipse
type: docs
weight: 30
url: /de/net/ellipse/
keywords:
- Ellipse
- Form
- Ellipse hinzufügen
- Ellipse erstellen
- Ellipse zeichnen
- formatierte Ellipse
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für .NET in PPT- und PPTX-Präsentationen erstellen, formatieren und bearbeiten – Beispielcode in C# ist enthalten."
---

## **Ellipse erstellen**
In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für .NET vor. Aspose.Slides für .NET bietet einen einfacheren Satz von APIs, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen. Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden
3. Fügen Sie mit der AddAutoShape‑Methode, die vom IShapes‑Objekt bereitgestellt wird, ein AutoShape vom Typ Ellipse hinzu
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei

Im nachstehenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt.
```c#
// Instanziieren Sie die Presentation-Klasse, die die PPTX repräsentiert
using (Presentation pres = new Presentation())
{
    // Holen Sie die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie ein AutoShape vom Typ Ellipse hinzu
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Formatiertes Ellipse erstellen**
Um ein besser formatiertes Ellipse zu einer Folie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie mit der AddAutoShape‑Methode, die vom IShapes‑Objekt bereitgestellt wird, ein AutoShape vom Typ Ellipse hinzu.
4. Setzen Sie den Fülltyp der Ellipse auf Solid.
5. Legen Sie die Farbe der Ellipse über die SolidFillColor.Color‑Eigenschaft fest, die vom FillFormat‑Objekt bereitgestellt wird, das dem IShape‑Objekt zugeordnet ist.
6. Setzen Sie die Farbe der Linien der Ellipse.
7. Legen Sie die Breite der Linien der Ellipse fest.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein formatiertes Ellipse zur ersten Folie der Präsentation hinzugefügt.
```c#
//Instanziieren Sie die Presentation-Klasse, die die PPTX repräsentiert
using (Presentation pres = new Presentation())
{

    //Holen Sie die erste Folie
    ISlide sld = pres.Slides[0];

    //Fügen Sie ein AutoShape vom Typ Ellipse hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Wenden Sie einige Formatierungen auf die Ellipsenform an
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    //Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie setze ich die genaue Position und Größe einer Ellipse in Bezug auf die Folieneinheiten?**

Koordinaten und Größen werden in der Regel **in Punkten** angegeben. Für vorhersehbare Ergebnisse basieren Sie Ihre Berechnungen auf der Foliengröße und konvertieren Sie erforderliche Millimeter oder Zoll in Punkte, bevor Sie Werte zuweisen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelhöhe steuern)?**

Passen Sie die Zeichenreihenfolge des Objekts an, indem Sie es nach vorne bringen oder nach hinten senden. Dadurch kann die Ellipse andere Objekte überlagern oder solche darunter sichtbar machen.

**Wie animiere ich das Auftreten oder die Hervorhebung einer Ellipse?**

[Apply](/slides/de/net/shape-animation/) Eingangs-, Betonungs- oder Ausgangseffekte auf die Form anwenden und Trigger sowie Timing konfigurieren, um zu steuern, wann und wie die Animation abgespielt wird.