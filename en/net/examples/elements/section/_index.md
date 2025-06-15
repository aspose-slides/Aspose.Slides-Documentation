---
title: Section
type: docs
weight: 90
url: /net/examples/elements/section
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for .NET**.

## Add a Section

Create a section that starts at a specific slide.

```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // Specify the slide that marks the beginning of the section
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```

## Access a Section

Read section information from a presentation.

```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // Access section by index
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```

## Remove a Section

Delete a previously added section.

```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // Remove the first section
    pres.Sections.RemoveSection(section);
}
```

## Rename a Section

Change the name of an existing section.

```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
