---
title: Inkoust
type: docs
weight: 180
url: /cs/net/examples/elements/ink/
keywords:
- inkoust
- přístup k inkoustu
- odstranění inkoustu
- příklad kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Práce s inkoustem v Aspose.Slides pro .NET: kreslení, import a úprava tahů, úprava barvy a šířky a export do PPT, PPTX a ODP pomocí příkladů v C#."
---
Tento článek poskytuje příklady přístupu k existujícím inkoustovým tvarům a jejich odstraňování pomocí **Aspose.Slides for .NET**.

> ❗ **Poznámka:** Inkoustové tvary představují vstup uživatele ze specializovaných zařízení. Aspose.Slides nemůže programově vytvářet nové tahy inkoustu, ale můžete číst a upravovat existující inkoust.

## **Přístup k inkoustu**

Přečtěte značky z prvního inkoustového tvaru na snímku.

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
            // Použijte tagName podle potřeby.
        }
    }
}
```

## **Odstranění inkoustu**

Odstraňte inkoustový tvar ze snímku, pokud existuje.

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