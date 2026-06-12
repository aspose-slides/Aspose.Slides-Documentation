---
title: Sectie
type: docs
weight: 90
url: /nl/net/examples/elements/section/
keywords:
- sectie
- dia sectie
- sectie toevoegen
- sectie openen
- sectie verwijderen
- sectie hernoemen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer diasecties in Aspose.Slides for .NET: maak, hernoem, herschik en groepeer dia's met C#-voorbeelden voor PPT, PPTX en ODP."
---
Voorbeelden voor het beheren van presentatiesecties—toevoegen, openen, verwijderen en hernoemen via code met **Aspose.Slides for .NET**.

## **Sectie toevoegen**

Maak een sectie die begint op een specifieke dia.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Specificeer de dia die het begin van de sectie aangeeft.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Sectie openen**

Lees sectie‑informatie uit een presentatie.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Toegang tot een sectie via index.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Sectie verwijderen**

Verwijder een eerder toegevoegde sectie.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Verwijder de eerste sectie.
    presentation.Sections.RemoveSection(section);
}
```

## **Sectie hernoemen**

Wijzig de naam van een bestaande sectie.

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