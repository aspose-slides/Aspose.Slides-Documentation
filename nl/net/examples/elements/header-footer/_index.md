---
title: Koptekst en voettekst
type: docs
weight: 220
url: /nl/net/examples/elements/header-footer/
keywords:
- koptekst en voettekst
- voeg koptekst en voettekst toe
- werk koptekst en voettekst bij
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer slide-kopteksten en -voetteksten met Aspose.Slides for .NET: voeg data, slidennummers en aangepaste tekst toe in PPT, PPTX en ODP met C#-voorbeelden."
---
Dit artikel laat zien hoe je voetteksten kunt toevoegen en datum- en tijd-plaatsaanduidingen kunt bijwerken met behulp van **Aspose.Slides for .NET**.

## **Voettekst toevoegen**

Voeg tekst toe aan het voettekstdomein van een dia en maak deze zichtbaar.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Datum en tijd bijwerken**

Wijzig de datum- en tijd-plaatsaanduiding op een dia.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```