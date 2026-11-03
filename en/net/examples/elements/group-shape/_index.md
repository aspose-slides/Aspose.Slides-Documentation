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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Group Shape**

Create a group containing two basic shapes.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var group = slide.Shapes.AddGroupShape();
group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);

presentation.Save("group-shape-01.pptx", SaveFormat.Pptx);
```

## **Access a Group Shape**

Retrieve the first group shape from a slide.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var group = slide.Shapes.AddGroupShape();
group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
Console.WriteLine(firstGroup.Shapes.Count);

presentation.Save("group-shape-02.pptx", SaveFormat.Pptx);
```

## **Remove a Group Shape**

Delete a group shape from the slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var group = slide.Shapes.AddGroupShape();
group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

slide.Shapes.Remove(group);

presentation.Save("group-shape-03.pptx", SaveFormat.Pptx);
```

<a id="ungroup-shapes"></a>

## **Move a Shape Out of a Group**

Clone a shape onto the slide and remove the original from its group. The group stays on the slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var group = slide.Shapes.AddGroupShape();
var rectangle = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

// Clone the rectangle onto the slide, then remove its original from the group.
slide.Shapes.AddClone(rectangle);
group.Shapes.Remove(rectangle);

presentation.Save("group-shape-04.pptx", SaveFormat.Pptx);
```
