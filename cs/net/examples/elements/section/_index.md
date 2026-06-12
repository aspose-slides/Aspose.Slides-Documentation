---
title: Sekce
type: docs
weight: 90
url: /cs/net/examples/elements/section/
keywords:
- sekce
- sekce snímku
- přidat sekci
- přístup k sekci
- odstranit sekci
- přejmenovat sekci
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte sekce snímků v Aspose.Slides pro .NET: vytvářejte, přejmenovávejte, měňte pořadí a seskupujte snímky s příklady v C# pro PPT, PPTX a ODP."
---
Příklady správy sekcí prezentace—přidávat, přistupovat, odstraňovat a přejmenovávat je programově pomocí **Aspose.Slides for .NET**.

## **Přidat sekci**

Vytvořte sekci, která začíná na konkrétním snímku.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Specifikujte snímek, který označuje začátek sekce.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Přístup k sekci**

Přečtěte informace o sekci z prezentace.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Přístup k sekci podle indexu.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Odstranit sekci**

Odstraňte dříve přidanou sekci.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Odstraňte první sekci.
    presentation.Sections.RemoveSection(section);
}
```

## **Přejmenovat sekci**

Změňte název existující sekce.

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