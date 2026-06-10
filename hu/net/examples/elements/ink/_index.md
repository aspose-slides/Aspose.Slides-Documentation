---
title: Tinta
type: docs
weight: 180
url: /hu/net/examples/elements/ink/
keywords:
- tinta
- tinta elérése
- tinta eltávolítása
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET-ben a tinta használata: vonalak rajzolása, importálása és szerkesztése, szín és vastagság beállítása, valamint PPT, PPTX és ODP exportálása C# példákkal."
---
Ez a cikk példákat mutat be a meglévő tinta alakzatok elérésére és azok eltávolítására az **Aspose.Slides for .NET** használatával.

> ❗ **Megjegyzés:** A tinta alakzatok a specializált eszközök felhasználói bevitelét képviselik. Az Aspose.Slides nem képes programozottan új tinta vonalakat létrehozni, de a meglévő tintát olvashatja és módosíthatja.

## **Tinta elérése**

Olvassa el a címkéket az első tintaalakzatról a dián.

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
            // Használd a tagName-et szükség szerint.
        }
    }
}
```

## **Tinta eltávolítása**

Töröljön egy tintaalakzatot a diáról, ha létezik.

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