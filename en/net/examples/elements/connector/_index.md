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

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim. The download checks each case in `CaseVerification.cs` before saving and after reopening the result.

## **Add a Connector**

Insert a connector shape between two points on the slide.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        VerifyCase01(presentation);
    }
}
```

## **Access a Connector**

Retrieve the first connector shape added to a slide.

```csharp
using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        var connector = slide.Shapes.OfType<IConnector>().First();

        VerifyCase02(presentation);
    }
}
```

## **Remove a Connector**

Delete a connector from the slide.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.Shapes.Remove(connector);

        VerifyCase03(presentation);
    }
}
```

## **Reconnect Shapes**

Attach a connector to two shapes by assigning start and end targets.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.StartShapeConnectedTo = shape1;
        connector.EndShapeConnectedTo = shape2;

        VerifyCase04(presentation);
    }
}
```
