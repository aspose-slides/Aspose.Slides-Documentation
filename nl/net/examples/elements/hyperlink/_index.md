---
title: Hyperlink
type: docs
weight: 130
url: /nl/net/examples/elements/hyperlink/
keywords:
- hyperlink
- hyperlink toevoegen
- hyperlink benaderen
- hyperlink verwijderen
- hyperlink bijwerken
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Hyperlinks toevoegen en beheren in Aspose.Slides for .NET: koppeltekst, vormen en afbeeldingen, target- en actiebeschrijvingen instellen voor PPT, PPTX en ODP met C#-voorbeelden."
---
Dit artikel toont het toevoegen, benaderen, verwijderen en bijwerken van hyperlinks op vormen met **Aspose.Slides for .NET**.

## **Een hyperlink toevoegen**

Maak een rechthoekige vorm met een hyperlink die verwijst naar een externe website.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Hyperlink benaderen**

Lees hyperlink‑informatie uit het tekstgedeelte van een vorm.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Hyperlink verwijderen**

Verwijder de hyperlink uit de tekst van een vorm.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Hyperlink bijwerken**

Verander het doel van een bestaande hyperlink. Gebruik `HyperlinkManager` om tekst die al een hyperlink bevat te wijzigen, wat nabootst hoe PowerPoint hyperlinks veilig bijwerkt.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Een hyperlink in bestaande tekst wijzigen moet gebeuren via
    // HyperlinkManager in plaats van de eigenschap direct in te stellen.
    // Dit bootst na hoe PowerPoint hyperlinks veilig bijwerkt.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```