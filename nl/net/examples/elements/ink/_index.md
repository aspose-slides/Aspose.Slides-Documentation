---
title: Inkt
type: docs
weight: 180
url: /nl/net/examples/elements/ink/
keywords:
- inkt
- ink benaderen
- inkt verwijderen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Werk met inkt in Aspose.Slides for .NET: teken, importeer en bewerk streken, pas kleur en breedte aan, en exporteer naar PPT, PPTX en ODP met C#-voorbeelden."
---
Dit artikel geeft voorbeelden van het benaderen van bestaande inktvormen en het verwijderen ervan met **Aspose.Slides for .NET**.

> ❗ **Opmerking:** Inktvormen vertegenwoordigen gebruikersinvoer van gespecialiseerde apparaten. Aspose.Slides kan geen nieuwe inktstreken programmeermatig aanmaken, maar u kunt bestaande inkt lezen en aanpassen.

## **Toegang tot inkt**

Lees de tags van de eerste inktvorm op een dia.

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
            // Gebruik tagName indien nodig.
        }
    }
}
```

## **Inkt verwijderen**

Verwijder een inktvorm van de dia als deze bestaat.

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