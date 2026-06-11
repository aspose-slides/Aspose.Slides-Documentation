---
title: Hyperlänk
type: docs
weight: 130
url: /sv/net/examples/elements/hyperlink/
keywords:
- hyperlänk
- lägga till hyperlänk
- åtkomst till hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lägg till och hantera hyperlänkar i Aspose.Slides för .NET: länka text, former och bilder, ange mål och åtgärder för PPT, PPTX och ODP med C#-exempel."
---
Den här artikeln visar hur man lägger till, får åtkomst till, tar bort och uppdaterar hyperlänkar på former med hjälp av **Aspose.Slides for .NET**.

## **Lägg till en hyperlänk**

Skapa en rektangelform med en hyperlänk som pekar på en extern webbplats.

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

## **Få åtkomst till en hyperlänk**

Läs hyperlänkinformation från en forms textdel.

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

## **Ta bort en hyperlänk**

Rensa hyperlänken från en formes text.

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

## **Uppdatera en hyperlänk**

Ändra målet för en befintlig hyperlänk. Använd `HyperlinkManager` för att ändra text som redan innehåller en hyperlänk, vilket efterliknar hur PowerPoint uppdaterar hyperlänkar på ett säkert sätt.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Att ändra en hyperlänk i befintlig text bör göras via
    // HyperlinkManager snarare än att sätta egenskapen direkt.
    // Detta efterliknar hur PowerPoint på ett säkert sätt uppdaterar hyperlänkar.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```