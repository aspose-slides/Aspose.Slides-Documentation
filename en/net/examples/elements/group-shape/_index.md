---
title: Group Shape
type: docs
weight: 170
url: /net/examples/elements/group-shape/
keywords:
- group
- add group shape
- access group shape
- remove group shape
- move a shape out of a group
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Create, access and remove shape groups, and move a shape out of its group with Aspose.Slides for .NET C# examples."
---

Create, access and remove shape groups with **Aspose.Slides for .NET**. Move an individual shape out of its group.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim. The download checks each case in `CaseVerification.cs` before saving and after reopening the result.

## **Add a Group Shape**

Create a group containing two basic shapes.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);

        VerifyCase01(presentation);
    }
}
```

## **Access a Group Shape**

Retrieve the first group shape from a slide.

```csharp
using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        var firstGroup = slide.Shapes.OfType<IGroupShape>().First();

        VerifyCase02(presentation);
    }
}
```

## **Remove a Group Shape**

Delete a group shape from the slide.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();

        slide.Shapes.Remove(group);

        VerifyCase03(presentation);
    }
}
```

<a id="ungroup-shapes"></a>

## **Move a Shape Out of a Group**

Clone a shape onto the slide and remove the original from its group. The group stays on the slide.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Move shape out of the group.
        slide.Shapes.AddClone(rect);
        group.Shapes.Remove(rect);

        VerifyCase04(presentation);
    }
}
```
