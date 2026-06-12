---
title: Casella di testo
type: docs
weight: 40
url: /it/net/examples/elements/text-box/
keywords:
- casella di testo
- aggiungi casella di testo
- accedi a casella di testo
- rimuovi casella di testo
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Lavora con le caselle di testo in Aspose.Slides per .NET: aggiungi, formatta, allinea, avvolgi, adatta automaticamente e stila il testo usando C# per presentazioni PPT, PPTX e ODP."
---
In Aspose.Slides, una **casella di testo** è rappresentata da un `AutoShape`. Quasi qualsiasi forma può contenere testo, ma una casella di testo tipica non ha riempimento né bordo e visualizza solo il testo.

Questa guida spiega come aggiungere, accedere e rimuovere le caselle di testo in modo programmatico.

## **Aggiungi una casella di testo**

Una casella di testo è semplicemente un `AutoShape` senza riempimento né bordo e con del testo formattato. Ecco come crearne una:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Crea una forma rettangolare (predefinita con riempimento, bordo e senza testo).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Rimuovi riempimento e bordo per farla apparire come una casella di testo tipica.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Imposta la formattazione del testo.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assegna il contenuto testuale effettivo.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Nota:** Qualsiasi `AutoShape` che contiene un `TextFrame` non vuoto può funzionare come una casella di testo.

## **Accedi alle caselle di testo per contenuto**

Per trovare tutte le caselle di testo che contengono una parola chiave specifica (ad es. "Slide"), itera attraverso le forme e controlla il loro testo:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Solo gli AutoShape possono contenere testo modificabile.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Fai qualcosa con la casella di testo corrispondente.
            }
        }
    }
}
```

## **Rimuovi le caselle di testo per contenuto**

Questo esempio trova ed elimina tutte le caselle di testo nella prima diapositiva che contengono una parola chiave specifica:

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

> 💡 **Suggerimento:** Crea sempre una copia della collezione di forme prima di modificarla durante l'iterazione per evitare errori di modifica della collezione.