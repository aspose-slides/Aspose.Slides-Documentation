---
title: Textruta
type: docs
weight: 40
url: /sv/net/examples/elements/text-box/
keywords:
- textruta
- lägga till textruta
- komma åt textruta
- ta bort textruta
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Arbeta med textrutor i Aspose.Slides för .NET: lägg till, formatera, justera, radbryt, autofit och formge text med C# för PPT-, PPTX- och ODP-presentationer."
---
I Aspose.Slides representeras en **textruta** av en `AutoShape`. Nästan vilken form som helst kan innehålla text, men en typisk textruta har ingen fyllning eller kant och visar bara text.

Den här guiden förklarar hur du lägger till, kommer åt och tar bort textrutor programmatiskt.

## **Lägg till en textruta**

En textruta är helt enkelt en `AutoShape` utan fyllning eller kant och med lite formaterad text. Så här skapar du en:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Skapa en rektangelform (standard är fylld med kant och utan text).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Ta bort fyllning och kant så att den ser ut som en vanlig textruta.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Ställ in textformatering.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Tilldela det faktiska textinnehållet.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Obs:** Any `AutoShape` that contains a non-empty `TextFrame` can function as en textruta.

## **Kom åt textrutor efter innehåll**

För att hitta alla textrutor som innehåller ett specifikt nyckelord (t.ex. "Slide"), iterera genom formerna och kontrollera deras text:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Endast AutoShapes kan innehålla redigerbar text.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Gör något med den matchande textrutan.
            }
        }
    }
}
```

## **Ta bort textrutor efter innehåll**

Detta exempel hittar och tar bort alla textrutor på den första bilden som innehåller ett specifikt nyckelord:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Tips:** Skapa alltid en kopia av formsamlingen innan du ändrar den under iteration för att undvika fel vid ändring av samlingen.