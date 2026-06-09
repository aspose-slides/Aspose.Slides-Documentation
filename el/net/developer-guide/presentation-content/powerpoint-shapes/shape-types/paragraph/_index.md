---
title: Λήψη ορίων παραγράφων από παρουσιάσεις σε .NET
linktitle: Παράγραφος
type: docs
weight: 60
url: /el/net/paragraph/
keywords:
- όρια παραγράφου
- όρια τμήματος κειμένου
- συντεταγμένη παραγράφου
- συντεταγμένη τμήματος
- μέγεθος παραγράφου
- μέγεθος τμήματος κειμένου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφων και τμημάτων κειμένου στο Aspose.Slides για .NET ώστε να βελτιστοποιήσετε τη θέση του κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λήψετε τα όρια, το μέγεθος και τις συντεταγμένες παραγράφων και τμημάτων κειμένου στην Aspose.Slides. Δείχνει πώς να ανακτήσετε το ορθογώνιο μιας Paragraph σε ένα `TextFrame` χρησιμοποιώντας τη `GetRect()`, πώς να λάβετε τις συντεταγμένες Paragraph και Portion μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, ο αντίκτυπος της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel και οι τιμές της αποτελεσματικής μορφοποίησης της Paragraph.

## **Λήψη Συντεταγμένων Paragraph και Portion σε TextFrame**
Χρησιμοποιώντας το Aspose.Slides για .NET, οι προγραμματιστές μπορούν τώρα να λάβουν τις ορθογώνιες συντεταγμένες για Paragraph μέσα στη συλλογή παραγράφων του TextFrame. Επιτρέπει επίσης να λάβετε τις συντεταγμένες του Portion μέσα στη συλλογή τμημάτων μιας Paragraph. Σε αυτό το θέμα, θα δείξουμε με τη βοήθεια ενός παραδείγματος πώς να λάβετε τις ορθογώνιες συντεταγμένες για την Paragraph μαζί με τη θέση του Portion μέσα στην Paragraph.

## **Λήψη Ορθογώνιων Συντεταγμένων μιας Paragraph**
Η νέα μέθοδος **GetRect()** προστέθηκε. Επιτρέπει τη λήψη του ορθογωνίου που ορίζει τα όρια της Paragraph.

```c#
 // Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει αρχείο παρουσίασης
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Λήψη του Μεγέθους μιας Paragraph και Portion μέσα σε Table Cell TextFrame**
Για να λάβετε το μέγεθος και τις συντεταγμένες του [Portion](https://reference.aspose.com/slides/el/net/aspose.slides/portion) ή του [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph) σε ένα πλαίσιο κειμένου κελιού πίνακα, μπορείτε να χρησιμοποιήσετε τις μεθόδους [IPortion.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/methods/getrect) και [IParagraph.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/methods/getrect).

Αυτός ο κώδικας δείγματος επιδεικνύει τη περιγραφόμενη λειτουργία:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες επιστρέφονται οι συντεταγμένες για μια paragraph και τα τμήματα κειμένου;**

Σε μονάδα σημείων (points), όπου 1 ίντσα = 72 σημεία. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας paragraph;**

Ναι. Εάν η [wrapping](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/wraptext/) είναι ενεργοποιημένη στο [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/), το κείμενο χωρίζεται ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της paragraph.

**Μπορούν οι συντεταγμένες της paragraph να αντιστοιχιστούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα σημεία σε pixel χρησιμοποιώντας: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση/εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης της paragraph, λαμβάνοντας υπόψη την κληρονομικότητα του στυλ;**

Χρησιμοποιήστε τη [effective paragraph formatting data structure](/slides/el/net/shape-effective-properties/); επιστρέφει τις τελικές συνενωμένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.