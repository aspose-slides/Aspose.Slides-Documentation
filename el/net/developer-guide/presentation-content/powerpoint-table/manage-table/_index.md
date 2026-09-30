---
title: Διαχείριση Πινάκων Παρουσίασης σε .NET
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/net/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση σε πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε & επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με το Aspose.Slides για .NET. Ανακαλύψτε απλά παραδείγματα κώδικα C# για να βελτιώσετε τις εργασίες σας με πίνακες."
---
## **Εισαγωγή**

Οι πίνακες στο PowerPoint οργανώνουν τις πληροφορίες σε γραμμές και στήλες, καθιστώντας πιο εύκολη την ανάγνωση και τη σύγκριση των τιμών.

Το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), τη διεπαφή [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), την κλάση [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), τη διεπαφή [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) και άλλους τύπους ώστε να μπορείτε να δημιουργείτε, να ενημερώνετε και να διαχειρίζεστε πίνακες σε παρουσιάσεις.

## **Δημιουργία Πίνακα από το Μηδέν**

Δημιουργήστε έναν πίνακα καθορίζοντας τη θέση του, το πλάτος των στηλών και το ύψος των γραμμών. Αφού τον προσθέσετε σε μια διαφάνεια, μπορείτε να μορφοποιήσετε τα σύνορα των κελιών, να συγχωνεύσετε κελιά και να εισάγετε κείμενο.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Ορίστε έναν πίνακα με πλάτη στηλών σε μονάδες point.
4. Ορίστε έναν πίνακα με ύψη γραμμών σε μονάδες point.
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Περπατήστε κάθε [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) για να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τα πρώτα δύο κελιά της πρώτης γραμμής του πίνακα.
8. Πρόσβαση στο συγχωνευμένο κελί μέσω της ιδιότητας [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/).
9. Ορίστε το κείμενο στο συγχωνευμένο κελί.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές στο (100, 50) points. Εφαρμόζει κόκκινα σύνορα με πάχος 5 points, συγχωνεύει τα δύο πρώτα κελιά της πρώτης γραμμής και αποθηκεύει το αποτέλεσμα ως `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, οι δείκτες των κελιών ξεκινάνε από το μηδέν και ακολουθούν τη σειρά (στήλη, γραμμή). Το πρώτο κελί έχει δείκτη (0, 0).

Για παράδειγμα, τα κελιά ενός πίνακα με 4 στήλες και 4 γραμμές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτό το παράδειγμα δημιουργεί τον παραπάνω πίνακα 4 × 4, με πλάτη στηλών και ύψη γραμμών 70 points και κόκκινα σύνορα κελιών με πάχος 5 points. Οι συντεταγμένες απεικονίζουν τους δείκτες των κελιών· το παράδειγμα αφήνει τα κελιά κενά και αποθηκεύει τον πίνακα ως `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

Οι πίνακες αποθηκεύονται στη συλλογή σχημάτων (shapes) μιας διαφάνειας. Περιηγηθείτε στα σχήματα για να εντοπίσετε έναν πίνακα και, στη συνέχεια, χρησιμοποιήστε τη διεπαφή [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) για να διαβάσετε ή να ενημερώσετε τα κελιά του.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα με βάση το δείκτη της.
3. Περιηγηθείτε στα αντικείμενα [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) και σταματήστε όταν βρείτε έναν πίνακα. Αν η διαφάνεια περιέχει πολλούς πίνακες, χρησιμοποιήστε το [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) για να προσδιορίσετε αυτόν που χρειάζεστε.
4. Ενημερώστε το κείμενο στο επιθυμητό κελί.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `UpdateExistingTable.pptx` και βρει τον πρώτο πίνακα στην πρώτη διαφάνεια. Ορίζει το κελί στη στήλη 0, γραμμή 1 σε `New` και αποθηκεύει το αποτέλεσμα ως `table1_out.pptx`. Το αρχείο εισόδου πρέπει να περιέχει τουλάχιστον μία διαφάνεια, και ο πρώτος πίνακας σε αυτή τη διαφάνεια πρέπει να έχει τουλάχιστον μία στήλη και δύο γραμμές.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Για να αλλάξετε το μέγεθος μιας γραμμής σε υπάρχοντα πίνακα και να κατανοήσετε γιατί το πραγματικό του ύψος μπορεί να υπερβαίνει το ελάχιστο που ζητήθηκε, δείτε το [Control Row Height](/slides/el/net/manage-rows-and-columns/#control-row-height).

## **Εύρεση του Κελιού που Ανήκει σε Καρέ Κειμένου**

Όταν ο γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) από έναν πίνακα, χρησιμοποιήστε την ιδιότητα [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) για να ανακτήσετε το ανήκον [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Για ένα καρέ κειμένου κελιού πίνακα, το [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) είναι ορισμένο και το [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) είναι `null`, παρόλο που ο ίδιος ο πίνακας είναι σχήμα.

Οι συντεταγμένες του κελιού διατίθενται μέσω των ιδιοτήτων μόνο για ανάγνωση [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) και [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). Το [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) είναι επίσης μόνο για ανάγνωση: παρέχει την πλοήγηση στον κάτοχο αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε το επιστρεφόμενο κελί για `null` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που προσδιορίζει τους ιδιοκτήτες κελιού‑πίνακα και σχήματος, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/net/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

Μπορείτε να ελέγξετε την κατακόρυφη αγκύρωση και την κατεύθυνση κειμένου των μεμονωμένων κελιών πίνακα. Το παράδειγμα σε αυτήν την ενότητα κεντράρει το κείμενο μέσα στο πρώτο κελί και το περιστρέφει κατά 270 μοίρες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) στη διαφάνεια.
4. Πρόσβαση σε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) από τον πίνακα.
5. Πρόσβαση στο πρώτο [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) και ορίστε το κείμενο και το χρώμα του.
6. Ορίστε το [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) και το [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) του κελιού.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με πλάτη στηλών 120 points και ύψη γραμμών 100 points. Μορφοποιεί το κείμενο στο κελί (0, 0), προσθέτει τιμές στα υπόλοιπα κελιά της πρώτης γραμμής και αποθηκεύει το αποτέλεσμα ως `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

Χρησιμοποιήστε το [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) για να εφαρμόσετε μορφοποίηση κειμένου σε όλα τα κελιά ενός πίνακα. Οι υπερφορτώσεις του δέχονται μορφοποίηση μερίδας, παραγράφου και καρέ κειμένου, ώστε να μπορείτε να ορίσετε αυτές τις ιδιότητες χωρίς να διασχίζετε μεμονωμένα κελιά.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Πρόσβαση σε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) από τη διαφάνεια.
4. Ορίστε το [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) για το κείμενο.
5. Ορίστε την [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) και το [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Ορίστε το [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `table.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Ορίζει το μέγεθος της γραμματοσειράς σε 25 points, ευθυγραμμίζει τις παραγράφους δεξιά με δεξιό περιθώριο 20 points και κάνει το κείμενο κάθετο. Η μορφοποιημένη παρουσίαση αποθηκεύεται ως `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε το [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) για να διαβάσετε ή να ορίσετε το προεπιλεγμένο στυλ ενός πίνακα. Αυτό το παράδειγμα εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) σε έναν πίνακα, εκτυπώνει το όνομα του προεπιλεγμένου στυλ και ορίζει το ίδιο προεπιλεγμένο στυλ σε δεύτερο πίνακα. Και οι δύο πίνακες αποθηκεύονται στο `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός πίνακα είναι η σχέση του πλάτους του προς το ύψος του. Χρησιμοποιήστε το [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) για να κλειδώσετε αυτή τη σχέση για έναν πίνακα.

Το παράδειγμα παρακάτω ανοίγει το `pres.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Εκτυπώνει την τρέχουσα κατάσταση κλειδώματος, ενεργοποιεί το κλείδωμα της αναλογίας, εκτυπώνει την ενημερωμένη κατάσταση (`True`) και αποθηκεύει το αποτέλεσμα ως `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει την ιδιότητα [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/), και οι παράγραφοι διαθέτουν την ιδιότητα [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [shape locks](/slides/el/net/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα εφαρμόζονται και στους πίνακες.

**Υποστηρίζεται η προσθήκη εικόνας ως φόντο σε κελί;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού σύμφωνα με τη επιλεγμένη λειτουργία (stretch ή tile).