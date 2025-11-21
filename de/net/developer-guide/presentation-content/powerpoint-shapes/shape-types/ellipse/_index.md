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
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für .NET in PPT- und PPTX-Präsentationen erstellen, formatieren und bearbeiten – C#-Codebeispiele inklusive."
---

## **Ellipse erstellen**
In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für .NET vor. Aspose.Slides für .NET bietet eine einfachere API, um verschiedene Formen mit nur wenigen Codezeilen zu zeichnen. Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. Rufen Sie die Referenz einer Folie über deren Index ab
1. Fügen Sie mit der AddAutoShape‑Methode des IShapes‑Objekts eine AutoShape vom Typ Ellipse hinzu
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei

Im nachstehenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt.
```c#
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```




## **Formatierte Ellipse erstellen**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. Rufen Sie die Referenz einer Folie über deren Index ab.
1. Fügen Sie mit der AddAutoShape‑Methode des IShapes‑Objekts eine AutoShape vom Typ Ellipse hinzu.
1. Setzen Sie den Fülltyp der Ellipse auf Solid.
1. Setzen Sie die Farbe der Ellipse über die SolidFillColor.Color‑Eigenschaft, die vom FillFormat‑Objekt bereitgestellt wird, das dem IShape‑Objekt zugeordnet ist.
1. Setzen Sie die Farbe der Linien der Ellipse.
1. Setzen Sie die Breite der Linien der Ellipse.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine formatierte Ellipse zur ersten Folie der Präsentation hinzugefügt.
```c#
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
using (Presentation pres = new Presentation())
{

    // Holen Sie die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Wenden Sie einige Formatierungen auf die Ellipse-Form an
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


## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse relativ zu den Folieneinheiten fest?**

Koordinaten und Größen werden typischerweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse basieren Sie Ihre Berechnungen auf der Foliengröße und konvertieren Sie erforderliche Millimeter oder Inches in Punkte, bevor Sie Werte zuweisen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelhöhe steuern)?**

Passen Sie die Zeichenreihenfolge des Objekts an, indem Sie es nach vorne bringen oder nach hinten senden. Dadurch kann die Ellipse andere Objekte überlagern oder die darunter liegenden sichtbar machen.

**Wie animiere ich das Auftreten oder die Betonung einer Ellipse?**

[Apply](/slides/de/net/shape-animation/) Eintritts‑, Betonungs‑ oder Ausgangseffekte auf die Form und konfigurieren Sie Trigger und Timing, um zu steuern, wann und wie die Animation abgespielt wird.