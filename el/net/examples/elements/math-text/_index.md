---
title: Μαθηματικό Κείμενο
type: docs
weight: 160
url: /el/net/examples/elements/math-text/
keywords:
- μαθηματικό κείμενο
- προσθήκη μαθηματικού κειμένου
- πρόσβαση στο μαθηματικό κείμενο
- αφαίρεση μαθηματικού κειμένου
- μορφοποίηση μαθηματικού κειμένου
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξερευνήστε τα παραδείγματα MathematicalText του Aspose.Slides for .NET: δημιουργήστε και μορφοποιήστε εξισώσεις, κλάσματα, μήτρες και σύμβολα με C# σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εργάζεστε με σχήματα μαθηματικού κειμένου και να μορφοποιείτε εξισώσεις χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη Μαθηματικού Κειμένου**

Δημιουργήστε ένα μαθηματικό σχήμα που περιέχει ένα κλάσμα και τον Πυθαγόρειο τύπο.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Προσθέστε ένα μαθηματικό σχήμα στη διαφάνεια.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Πρόσβαση στην μαθηματική παράγραφο.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Προσθήκη απλού κλάσματος: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Προσθήκη εξίσωσης: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Πρόσβαση στο Μαθηματικό Κείμενο**

Εντοπίστε ένα σχήμα που περιέχει μια μαθηματική παράγραφο στη διαφάνεια.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Βρείτε το πρώτο σχήμα που περιέχει μια μαθηματική παράγραφο.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Παράδειγμα: δημιουργία κλάσματος (δεν προστέθηκε εδώ).
        var fraction = new MathematicalText("x").Divide("y");

        // Χρησιμοποιήστε το mathParagraph ή το fraction όπως χρειάζεται...
    }
}
```

## **Αφαίρεση Μαθηματικού Κειμένου**

Διαγράψτε ένα μαθηματικό σχήμα από τη διαφάνεια.

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

## **Μορφοποίηση Μαθηματικού Κειμένου**

Ορίστε τις ιδιότητες γραμματοσειράς για ένα μαθηματικό τμήμα.

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