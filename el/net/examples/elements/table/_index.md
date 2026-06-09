---
title: Πίνακας
type: docs
weight: 120
url: /el/net/examples/elements/table/
keywords:
- πίνακας
- προσθήκη πίνακα
- πρόσβαση σε πίνακα
- αφαίρεση πίνακα
- συγχώνευση κελιών
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εργαστείτε με πίνακες στο Aspose.Slides για .NET: δημιουργήστε, μορφοποιήστε, συγχωνεύστε κελιά, εφαρμόστε στυλ, εισάγετε δεδομένα και εξάγετε με παραδείγματα C# για PPT, PPTX και ODP."
---
Παραδείγματα προσθήκης πινάκων, πρόσβασης σε αυτούς, αφαίρεσης και συγχώνευσης κελιών χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Add a Table**
Δημιουργήστε έναν απλό πίνακα με δύο γραμμές και δύο στήλες.

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **Access a Table**
Ανάκτηση του πρώτου σχήματος πίνακα στη διαφάνεια.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Πρόσβαση στον πρώτο πίνακα στη διαφάνεια.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Remove a Table**
Διαγραφή πίνακα από μια διαφάνεια.

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **Merge Table Cells**
Συγχώνευση διπλανών κελιών ενός πίνακα σε ένα μόνο κελί.

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```