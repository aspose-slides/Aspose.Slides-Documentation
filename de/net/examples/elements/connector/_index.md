---
title: Verbinder
type: docs
weight: 190
url: /de/net/examples/elements/connector/
keywords:
- Connector-Beispiel
- Connector hinzufügen
- Connector abrufen
- Connector entfernen
- Formen neu verbinden
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Zeichnen und steuern Sie Verbinder in C# mit Aspose.Slides: Hinzufügen, Routen, Neu-Routen, Festlegen von Verbindungspunkten, Pfeilen und Stilen, um Formen in PPT, PPTX und ODP zu verknüpfen."
---

Zeigt, wie man Formen mit Verbindern verbindet und deren Zielpunkte mithilfe von **Aspose.Slides for .NET** ändert.

## **Connector hinzufügen**

Fügen Sie eine Connector-Form zwischen zwei Punkten auf der Folie ein.
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## **Zugriff auf einen Connector**

Rufen Sie die erste zur Folie hinzugefügte Connector-Form ab.
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## **Connector entfernen**

Löschen Sie einen Connector von der Folie.
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## **Formen neu verbinden**

Binden Sie einen Connector an zwei Formen, indem Sie Start- und Endziele zuweisen.
```csharp
static void Reconnect_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    conn.StartShapeConnectedTo = shape1;
    conn.EndShapeConnectedTo = shape2;
}
```
