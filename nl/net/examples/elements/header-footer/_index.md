---
title: Koptekst en voettekst
type: docs
weight: 220
url: /nl/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- koptekst voettekst
- voeg koptekst en voettekst toe
- koptekst en voettekst bijwerken
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer dia-kopteksten en voetteksten met Aspose.Slides voor .NET: voeg datums, dia-nummers en aangepaste tekst toe in PPT, PPTX en ODP met C#-voorbeelden."
---
Dit artikel laat zien hoe je voetteksten kunt toevoegen en datum‑ en tijds‑plaatsaanduidingen kunt bijwerken met behulp van **Aspose.Slides for .NET**.

## **Voeg een voettekst toe**

Voeg tekst toe aan het voettekstgebied van een dia en maak deze zichtbaar.

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

Pas de datum‑ en tijds‑plaatsaanduiding op een dia aan.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```