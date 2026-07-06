---
title: Ανάκτηση ορίων παραγράφου από παρουσιάσεις σε .NET
linktitle: Όρια παραγράφου
type: docs
weight: 43
url: /el/net/paragraph-bounds/
keywords:
- όρια παραγράφου
- συντεταγμένη παραγράφου
- μέγεθος παραγράφου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφου στο Aspose.Slides για .NET ώστε να βελτιστοποιήσετε τη θέση του κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες παραγράφων στο Aspose.Slides. Δείχνει πώς να ανακτήσετε ένα ορθογώνιο παραγράφου από ένα [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) χρησιμοποιώντας [IParagraph.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/getrect/), πώς να λάβετε τις συντεταγμένες μιας παραγράφου μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε εικονοστοιχεία και οι αποτελεσματικές τιμές μορφοποίησης παραγράφου.

## **Λήψη Ορθογώνιων Συντεταγμένων μιας Παραγράφου**

Χρησιμοποιήστε το [IParagraph.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/getrect/) για να λάβετε το ορθογώνιο περιορισμού μιας παραγράφου.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Λήψη του Μεγέθους μιας Παραγράφου μέσα σε Πλαίσιο Κειμένου Κελιού Πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες ενός [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) σε πλαίσιο κειμένου κελιού πίνακα, χρησιμοποιήστε το [IParagraph.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/getrect/). Το επιστρεφόμενο ορθογώνιο είναι σχετικό με το πλαίσιο κειμένου του κελιού πίνακα, επομένως προσθέστε τη θέση του πίνακα και την απόκλιση του κελιού όταν χρειάζεστε συντεταγμένες σε επίπεδο διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει τα όρια της παραγράφου μέσα σε κελί πίνακα και σχεδιάζει ορθογώνια στη διαφάνεια για να οπτικοποιήσει αυτά τα όρια:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Συχνές ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι συντεταγμένες της παραγράφου;**

Μετρώνται σε points, όπου 1 ίντσα ισούται με 72 points. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν το [TextFrameFormat.WrapText](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/wraptext/) είναι ενεργό για το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/), το κείμενο σπάει ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να αντιστοιχιστούν αξιόπιστα σε εικονοστοιχεία στην εξαγώμενη εικόνα;**

Ναι. Μετατρέψτε τα points σε εικονοστοιχεία με τον τύπο: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση ή την εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης της παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα στυλ;**

Χρησιμοποιήστε την [effective paragraph formatting data structure](/slides/el/net/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.