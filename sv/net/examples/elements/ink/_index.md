---
title: Bläck
type: docs
weight: 180
url: /sv/net/examples/elements/ink/
keywords:
- bläck
- åtkomst till bläck
- ta bort bläck
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Arbeta med bläck i Aspose.Slides för .NET: rita, importera och redigera streck, justera färg och bredd samt exportera till PPT, PPTX och ODP med C#‑exempel."
---
Denna artikel ger exempel på hur man får åtkomst till befintliga bläckformer och tar bort dem med **Aspose.Slides for .NET**.

> ❗ **Obs:** Bläckformer representerar användarinmatning från specialiserade enheter. Aspose.Slides kan inte skapa nya bläckstreck programatiskt, men du kan läsa och modifiera befintligt bläck.

## **Åtkomst till bläck**

Läs taggarna från den första bläckformen på en bild.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Använd tagName efter behov.
        }
    }
}
```

## **Ta bort bläck**

Ta bort en bläckform från bilden om en sådan finns.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```