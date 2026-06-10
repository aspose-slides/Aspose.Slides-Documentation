---
title: Szakasz
type: docs
weight: 90
url: /hu/net/examples/elements/section/
keywords:
- szakasz
- dia szakasz
- szakasz hozzáadása
- szakasz elérése
- szakasz eltávolítása
- szakasz átnevezése
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Dia szakaszok kezelése az Aspose.Slides for .NET-ben: létrehozás, átnevezés, átrendezés és diák csoportosítása C# példákkal PPT, PPTX és ODP formátumokhoz."
---
Példák a prezentációszakaszok kezelésére – hozzáadás, elérés, eltávolítás és átnevezés programozott módon a **Aspose.Slides for .NET** használatával.

## **Szakasz hozzáadása**

Hozzon létre egy szakaszt, amely egy adott dián kezdődik.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Specifikálja azt a diát, amely a szakasz kezdetét jelöli.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Szakasz elérése**

Olvassa el a szakaszinformációkat egy prezentációból.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Hozzáférés egy szakaszhoz index alapján.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Szakasz eltávolítása**

Töröljön egy korábban hozzáadott szakaszt.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Az első szakasz eltávolítása.
    presentation.Sections.RemoveSection(section);
}
```

## **Szakasz átnevezése**

Változtassa meg egy meglévő szakasz nevét.

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