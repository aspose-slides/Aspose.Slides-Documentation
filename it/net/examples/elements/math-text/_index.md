---
title: Testo matematico
type: docs
weight: 160
url: /it/net/examples/elements/math-text/
keywords:
- testo matematico
- aggiungi testo matematico
- accedi al testo matematico
- rimuovi testo matematico
- formatta testo matematico
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esplora gli esempi di MathematicalText di Aspose.Slides per .NET: crea e formatta equazioni, frazioni, matrici e simboli con C# in presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con forme di testo matematico e formattare equazioni usando **Aspose.Slides for .NET**.

## **Aggiungi testo matematico**

Crea una forma matematica contenente una frazione e la formula pitagorica.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Aggiungi una forma Math alla diapositiva.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Accedi al paragrafo matematico.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Aggiungi una frazione semplice: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Aggiungi equazione: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Accedi al testo matematico**

Trova una forma che contiene un paragrafo matematico nella diapositiva.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Trova la prima forma che contiene un paragrafo matematico.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Esempio: crea una frazione (non aggiunta qui).
        var fraction = new MathematicalText("x").Divide("y");

        // Usa mathParagraph o fraction secondo necessità...
    }
}
```

## **Rimuovi testo matematico**

Elimina una forma matematica dalla diapositiva.

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```

## **Formatta testo matematico**

Imposta le proprietà del carattere per una porzione matematica.

```csharp
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```