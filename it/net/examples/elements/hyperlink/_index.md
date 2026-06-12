---
title: Collegamento ipertestuale
type: docs
weight: 130
url: /it/net/examples/elements/hyperlink/
keywords:
- collegamento ipertestuale
- aggiungere collegamento ipertestuale
- accedere collegamento ipertestuale
- rimuovere collegamento ipertestuale
- aggiornare collegamento ipertestuale
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aggiungi e gestisci i collegamenti ipertestuali in Aspose.Slides for .NET: testo, forme e immagini, imposta destinazioni e azioni per PPT, PPTX e ODP con esempi C#."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e aggiornare collegamenti ipertestuali su forme utilizzando **Aspose.Slides for .NET**.

## **Aggiungi un collegamento ipertestuale**

Crea una forma rettangolare con un collegamento ipertestuale che punta a un sito Web esterno.

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

## **Accedi a un collegamento ipertestuale**

Leggi le informazioni del collegamento ipertestuale dalla porzione di testo di una forma.

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

## **Rimuovi un collegamento ipertestuale**

Cancella il collegamento ipertestuale dal testo di una forma.

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

## **Aggiorna un collegamento ipertestuale**

Modifica la destinazione di un collegamento ipertestuale esistente. Utilizza `HyperlinkManager` per modificare il testo che contiene già un collegamento ipertestuale, simulando il modo in cui PowerPoint aggiorna i collegamenti ipertestuali in modo sicuro.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Modificare un collegamento ipertestuale all'interno del testo esistente dovrebbe essere fatto tramite
    // HyperlinkManager piuttosto che impostare direttamente la proprietà.
    // Questo simula il modo in cui PowerPoint aggiorna in modo sicuro i collegamenti ipertestuali.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```