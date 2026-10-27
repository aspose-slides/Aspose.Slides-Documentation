---
title: Connect shapes
description: Connect shapes with attached connector lines.
type: docs
url: /features/connectors/
weight: 570
feature_id: connectors
feature_group: shapes
translationKey: slides-feature-connectors
feature_catalogue_version: 3
feature_guides:
- /slides/net/connector/
---

## **Overview**

Add a connector and attach its ends to shapes to show relationships in a diagram. Connection sites tie the line to the objects rather than only to fixed coordinates. Reroute a connector after moving an attached shape when its geometry needs to be recalculated.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example attaches an elbow connector to two rectangles, moves the second rectangle and reroutes the line. The PPTX retains the endpoint attachments so the connection remains editable.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;
var start = shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 80);
start.Name = "Start";
var end = shapes.AddAutoShape(ShapeType.Rectangle, 360, 80, 120, 80);
end.Name = "End";
var connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 0, 0);
connector.StartShapeConnectedTo = start;
connector.EndShapeConnectedTo = end;
end.Y = 240;
connector.Reroute();
presentation.Save("connectors.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Will the connection survive saving the presentation?**

The saved presentation keeps the connector attachments. Your application can read them again and continue editing the diagram.

### **Can a connector stay attached when a shape moves?**

Yes. Attach the connector endpoints to the shapes instead of merely setting line coordinates. Reroute after moving a connected shape when you need the line geometry recalculated.

### **How do I choose a connector's connection site?**

Use an available connection-site index on the endpoint shape. Valid indexes depend on its geometry; inspect the available sites rather than assuming the same index works for every preset.

## **Guides**

- [Manage Connectors in Presentations in .NET](/slides/net/connector/)

Related feature: [Add preset shapes](/slides/features/autoshapes/).
