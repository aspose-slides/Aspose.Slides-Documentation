---
title: Section
type: docs
weight: 90
url: /net/examples/elements/section/
keywords:
- code example
- section
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage slide sections in Aspose.Slides for .NET: create, rename, reorder, and group slides with C# examples for PPT, PPTX, and ODP."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for .NET**.

## **Add a Section**

Create a section that starts at a specific slide.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Specify the slide that marks the beginning of the section.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Access a Section**

Read section information from a presentation.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Access a section by index.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Remove a Section**

Delete a previously added section.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Remove the first section.
    presentation.Sections.RemoveSection(section);
}
```

## **Rename a Section**

Change the name of an existing section.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```
