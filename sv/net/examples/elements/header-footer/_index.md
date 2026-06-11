---
title: Sidhuvud och sidfot
type: docs
weight: 220
url: /sv/net/examples/elements/header-footer/
keywords:
- sidhuvud sidfot
- lägga till sidhuvud och sidfot
- uppdatera sidhuvud och sidfot
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Kontrollera bildhuvuden och sidfötter med Aspose.Slides för .NET: lägg till datum, bildnummer och anpassad text i PPT, PPTX och ODP med C#-exempel."
---
Den här artikeln visar hur man lägger till sidfötter och uppdaterar datum- och tidsplatshållare med hjälp av **Aspose.Slides for .NET**.

## **Lägg till en sidfot**

Lägg till text i sidfotområdet på en bild och gör den synlig.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Uppdatera datum och tid**

Ändra datum- och tidsplatshållaren på en bild.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```