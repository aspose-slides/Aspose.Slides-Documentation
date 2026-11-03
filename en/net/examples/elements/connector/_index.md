---
title: Connector
type: docs
weight: 190
url: /net/examples/elements/connector/
keywords:
- connector
- add connector
- access connector
- remove connector
- reconnect shapes
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to add, route, and style connectors between shapes using Aspose.Slides for .NET, with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to connect shapes with connectors and change their targets using **Aspose.Slides for .NET**.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Connector**

Insert a connector shape between two points on the slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

presentation.Save("connector-01.pptx", SaveFormat.Pptx);
```

## **Access a Connector**

Retrieve the first connector shape added to a slide.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

var connector = slide.Shapes.OfType<IConnector>().First();
Console.WriteLine(connector.ShapeType);

presentation.Save("connector-02.pptx", SaveFormat.Pptx);
```

## **Remove a Connector**

Delete a connector from the slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

slide.Shapes.Remove(connector);

presentation.Save("connector-03.pptx", SaveFormat.Pptx);
```

## **Reconnect Shapes**

Attach a connector to two shapes by assigning start and end targets.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

connector.StartShapeConnectedTo = shape1;
connector.EndShapeConnectedTo = shape2;

presentation.Save("connector-04.pptx", SaveFormat.Pptx);
```
