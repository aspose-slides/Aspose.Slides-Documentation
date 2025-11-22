---
title: Ellipse
type: docs
weight: 30
url: /de/net/ellipse/
keywords: "Ellipse, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Ellipse in PowerPoint-Präsentation in C# oder .NET erstellen"
---

## **Ellipse erstellen**
In diesem Abschnitt stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für .NET vor. Aspose.Slides für .NET bietet einen einfacheren Satz von APIs, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen. Um einer ausgewählten Folie der Präsentation eine einfache Ellipse hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden
3. Fügen Sie mit der AddAutoShape‑Methode, die vom IShapes‑Objekt bereitgestellt wird, eine AutoShape vom Typ Ellipse hinzu
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei

Im nachstehenden Beispiel haben wir der ersten Folie eine Ellipse hinzugefügt.
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


## **Formatiertete Ellipse erstellen**
Um einer Folie eine besser formatierte Ellipse hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Fügen Sie mit der AddAutoShape‑Methode, die vom IShapes‑Objekt bereitgestellt wird, eine AutoShape vom Typ Ellipse hinzu.
4. Setzen Sie den Fill‑Typ der Ellipse auf Solid.
5. Setzen Sie die Farbe der Ellipse über die SolidFillColor.Color‑Eigenschaft, die vom FillFormat‑Objekt bereitgestellt wird, das dem IShape‑Objekt zugeordnet ist.
6. Setzen Sie die Farbe der Linien der Ellipse.
7. Setzen Sie die Breite der Linien der Ellipse.
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir der ersten Folie der Präsentation eine formatierte Ellipse hinzugefügt.
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

    //Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie lege ich die exakte Position und Größe einer Ellipse relativ zu den Einheiten der Folie fest?**

Koordinaten und Größen werden normalerweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse sollten Sie Ihre Berechnungen auf der Foliengröße basieren und erforderliche Millimeter oder Zoll in Punkte umrechnen, bevor Sie Werte zuweisen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stacking‑Reihenfolge steuern)?**

Passen Sie die Zeichenreihenfolge des Objekts an, indem Sie es nach vorne holen oder nach hinten senden. Dadurch kann die Ellipse andere Objekte überdecken oder solche darunter sichtbar machen.

**Wie animiere ich das Auftauchen oder die Betonung einer Ellipse?**

[Apply](/slides/de/net/shape-animation/) Eintritts‑, Betonungs‑ oder Ausgangseffekte auf die Form und konfigurieren Sie Trigger und Timing, um zu steuern, wann und wie die Animation abläuft.