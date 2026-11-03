---
title: Section
type: docs
weight: 90
url: /net/examples/elements/section/
keywords:
- section
- slide section
- add section
- access section
- remove section
- rename section
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage slide sections in Aspose.Slides for .NET: create, rename, reorder, and group slides with C# examples for PPT, PPTX, and ODP."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for .NET**.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Section**

Create a section that starts at a specific slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Specify the slide that marks the beginning of the section.
presentation.Sections.AddSection("New Section", slide);

presentation.Save("section-01.pptx", SaveFormat.Pptx);
```

## **Access a Section**

Read section information from a presentation.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

presentation.Sections.AddSection("My Section", slide);

// Access a section by index.
var section = presentation.Sections[0];
var sectionName = section.Name;
Console.WriteLine(sectionName);

presentation.Save("section-02.pptx", SaveFormat.Pptx);
```

## **Remove a Section**

Delete a previously added section.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var section = presentation.Sections.AddSection("Temporary Section", slide);

// Remove the first section.
presentation.Sections.RemoveSection(section);

presentation.Save("section-03.pptx", SaveFormat.Pptx);
```

## **Rename a Section**

Change the name of an existing section.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

presentation.Sections.AddSection("Old Name", slide);

var section = presentation.Sections[0];
section.Name = "New Name";

presentation.Save("section-04.pptx", SaveFormat.Pptx);
```
