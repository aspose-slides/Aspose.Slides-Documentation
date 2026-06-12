---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/net/examples/elements/header-footer/
keywords:
- záhlaví a zápatí
- přidat záhlaví a zápatí
- aktualizovat záhlaví a zápatí
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Řiďte záhlaví a zápatí snímků pomocí Aspose.Slides pro .NET: přidávejte data, čísla snímků a vlastní text do souborů PPT, PPTX a ODP s ukázkami v C#."
---
Tento článek ukazuje, jak přidat zápatí a aktualizovat zástupné znaky data a času pomocí **Aspose.Slides for .NET**.

## **Přidat zápatí**

Přidejte text do oblasti zápatí snímku a zobrazte jej.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Aktualizovat datum a čas**

Upravte zástupný znak data a času na snímku.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```