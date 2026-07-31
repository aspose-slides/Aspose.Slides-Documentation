---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- záhlaví a zápatí
- přidat záhlaví a zápatí
- aktualizovat záhlaví a zápatí
- příklad kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Ovládejte záhlaví a zápatí snímků pomocí Aspose.Slides pro .NET: přidejte data, čísla snímků a vlastní text v PPT, PPTX a ODP s příklady v C#."
---
Tento článek demonstruje, jak přidat zápatí a aktualizovat zástupce data a času pomocí **Aspose.Slides for .NET**.

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

Upravte zástupce data a času na snímku.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```