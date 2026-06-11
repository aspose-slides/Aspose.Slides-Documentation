---
title: Sektion
type: docs
weight: 90
url: /sv/net/examples/elements/section/
keywords:
- sektion
- bildsektion
- lägg till sektion
- åtkomst till sektion
- ta bort sektion
- byta namn på sektion
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera bildsektioner i Aspose.Slides för .NET: skapa, byta namn, omordna och gruppera bilder med C#-exempel för PPT, PPTX och ODP."
---
Exempel på hur du hanterar presentationssektioner—lägger till, får åtkomst till, tar bort och byter namn på dem programatiskt med **Aspose.Slides for .NET**.

## **Lägg till en sektion**

Skapa en sektion som börjar på en specifik bild.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ange bilden som markerar början av sektionen.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Få åtkomst till en sektion**

Läs sektioninformation från en presentation.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Få åtkomst till en sektion med index.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Ta bort en sektion**

Ta bort en tidigare tillagd sektion.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Ta bort den första sektionen.
    presentation.Sections.RemoveSection(section);
}
```

## **Byt namn på en sektion**

Ändra namnet på en befintlig sektion.

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