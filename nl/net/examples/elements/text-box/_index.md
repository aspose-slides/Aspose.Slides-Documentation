---
title: Tekstvak
type: docs
weight: 40
url: /nl/net/examples/elements/text-box/
keywords:
- tekstvak
- tekstvak toevoegen
- tekstvak benaderen
- tekstvak verwijderen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Werk met tekstvakken in Aspose.Slides voor .NET: voeg toe, formatteer, alinieer, omsluit, automatisch aanpassen en style tekst met C# voor PPT-, PPTX- en ODP-presentaties."
---
In Aspose.Slides wordt een **tekstvak** voorgesteld door een `AutoShape`. Vrijwel elke vorm kan tekst bevatten, maar een typisch tekstvak heeft geen opvulling of rand en toont alleen tekst.

Deze gids legt uit hoe je tekstvakken programmeermatig kunt toevoegen, benaderen en verwijderen.

## **Add a Text Box**

Een tekstvak is simpelweg een `AutoShape` zonder opvulling of rand en met enige opgemaakte tekst. Hier zie je hoe je er één maakt:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Maak een rechthoekige vorm (standaard gevuld met rand en zonder tekst).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Verwijder opvulling en rand zodat het eruitziet als een typisch tekstvak.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Stel tekstopmaak in.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Wijs de daadwerkelijke tekstinhoud toe.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Opmerking:** Elke `AutoShape` die een niet‑leeg `TextFrame` bevat, kan functioneren als een tekstvak.

## **Access Text Boxes by Content**

Om alle tekstvakken te vinden die een specifiek trefwoord bevatten (bijv. "Slide"), doorloop je de vormen en controleer je hun tekst:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Alleen AutoShapes kunnen bewerkbare tekst bevatten.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Doe iets met het overeenkomende tekstvak.
            }
        }
    }
}
```

## **Remove Text Boxes by Content**

Dit voorbeeld vindt en verwijdert alle tekstvakken op de eerste dia die een specifiek trefwoord bevatten:

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

> 💡 **Tip:** Maak altijd een kopie van de vormcollectie voordat je deze tijdens iteratie wijzigt, om fouten bij het aanpassen van de collectie te voorkomen.