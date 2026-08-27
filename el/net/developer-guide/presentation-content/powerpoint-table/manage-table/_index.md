---
title: Διαχείριση Πινάκων Παρουσίασης σε .NET
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/net/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργία και επεξεργασία πινάκων σε διαφάνειες PowerPoint με Aspose.Slides για .NET. Ανακαλύψτε απλά παραδείγματα κώδικα C# για να απλοποιήσετε τη ροή εργασιών με τους πίνακες."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποτελεσματικός τρόπος παρουσίασης και απεικόνισης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κελιών (διατεταγμένα σε σειρές και στήλες) είναι απλές και εύκολες στην κατανόηση.

Η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/net/aspose.slides/table/) , την διεπαφή [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) , την κλάση [Cell](https://reference.aspose.com/slides/el/net/aspose.slides/cell/) , την διεπαφή [ICell](https://reference.aspose.com/slides/el/net/aspose.slides/icell/) , και άλλους τύπους για να σας επιτρέψει να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε όλα τα είδη παρουσιάσεων. 

## **Δημιουργία Πίνακα από το Μηδέν**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα `columnWidth`.
4. Ορίστε έναν πίνακα `rowHeight`.
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addtable/) .
6. Επανάληψη σε κάθε [ICell](https://reference.aspose.com/slides/el/net/aspose.slides/icell/) για την εφαρμογή μορφοποίησης στα επάνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχώνευση των πρώτων δύο κελιών της πρώτης σειράς του πίνακα. 
8. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) ενός [ICell](https://reference.aspose.com/slides/el/net/aspose.slides/icell/) . 
9. Προσθέστε κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) .
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

This C# code shows you how to create a table in a presentation:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();

// Προσπελαύνει την πρώτη διαφάνεια
ISlide sld = pres.Slides[0];

// Ορίζει στήλες με πλάτη και σειρές με ύψη
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Ορίζει τη μορφοποίηση του περιγράμματος για κάθε κελί
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Συγχωνεύει τα κελιά 1 και 2 της πρώτης σειράς
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Προσθέτει κείμενο στο συγχωνευμένο κελί
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Αποθηκεύει την παρουσίαση στο δίσκο
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κελιών είναι απλή και με βάση το μηδέν. Το πρώτο κελί ενός πίνακα έχει δείκτη 0,0 (στήλη 0, σειρά 0). 

Για παράδειγμα, τα κελιά ενός πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας C# δημιουργεί τον τυπικό πίνακα 4 × 4 που αριθμήθηκε παραπάνω και ορίζει τη μορφοποίηση των συνόρων για κάθε ένα από τα κελιά του:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation())
{

    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφοποίηση του περιγράμματος για κάθε κελί
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) και ορίστε το σε null.
4. Επανάληψη σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) μέχρι να βρεθεί ο πίνακας.

   Εάν υποψιάζεστε ότι η διαφάνεια που επεξεργάζεστε περιέχει μόνο έναν πίνακα, μπορείτε απλώς να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα σχήμα αναγνωρίζεται ως πίνακας, μπορείτε να το μετατρέψετε τύπου ως αντικείμενο [Table](https://reference.aspose.com/slides/el/net/aspose.slides/table/) . Ωστόσο, εάν η διαφάνεια που επεξεργάζεστε περιέχει πολλούς πίνακες, τότε είναι προτιμότερο να αναζητήσετε τον πίνακα που χρειάζεστε μέσω του [AlternativeText](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/alternativetext/) του.
5. Χρησιμοποιήστε το αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) για να εργαστείτε με τον πίνακα. Στο παρακάτω παράδειγμα, προσθέσαμε μια νέα σειρά στον πίνακα.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
using Aspose.Slides;

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];

    // Αρχικοποιεί το TableEx ως null
    ITable tbl = null;

    // Διατρέχει τα σχήματα και ορίζει αναφορά στον ευρεθέντα πίνακα
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Ορίζει το κείμενο για την πρώτη στήλη της δεύτερης σειράς
    tbl[0, 1].TextFrame.Text = "New";

    // Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Εντοπισμός του Κελιού που Κατέχει Πλαίσιο Κειμένου**

Όταν ο γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) από έναν πίνακα, χρησιμοποιήστε την ιδιότητα [ITextFrame.ParentCell](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentcell/) για να ανακτήσετε το κάτοχο [ICell](https://reference.aspose.com/slides/el/net/aspose.slides/icell/) . Για ένα πλαίσιο κειμένου κελίου πίνακα, το [ITextFrame.ParentCell](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentcell/) είναι ορισμένο και το [ITextFrame.ParentShape](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentshape/) είναι `null`, παρόλο που ο πίνακας καθαυτός είναι σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο για ανάγνωση ιδιοτήτων [ICell.FirstColumnIndex](https://reference.aspose.com/slides/el/net/aspose.slides/icell/firstcolumnindex/) και [ICell.FirstRowIndex](https://reference.aspose.com/slides/el/net/aspose.slides/icell/firstrowindex/) . Το [ITextFrame.ParentCell](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentcell/) είναι επίσης μόνο για ανάγνωση: παρέχει πλοήγηση προς τον ιδιοκτήτη αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε το επιστρεφόμενο κελί για `null` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιών πίνακα και σχήματος, συμπεριλαμβανομένων των σχημάτων που συνδέονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/net/search-and-replace-text/) .

## **Στοίχιση Κειμένου σε Πίνακα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) στη διαφάνεια. 
4. Πρόσβαση σε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) από τον πίνακα. 
5. Πρόσβαση στο [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) του [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) .
6. Στοίχιση του κειμένου κατακόρυφα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation presentation = new Presentation();

// Λαμβάνει την πρώτη διαφάνεια 
ISlide slide = presentation.Slides[0];

// Ορίζει στήλες με πλάτη και σειρές με ύψη
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Προσθέτει το σχήμα πίνακα στη διαφάνεια
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Προσπελαύνει το πλαίσιο κειμένου
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
IParagraph paragraph = txtFrame.Paragraphs[0];

// Δημιουργεί το αντικείμενο Portion για την παράγραφο
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Στοίχει το κείμενο κατακόρυφα
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Αποθηκεύει την παρουσίαση στο δίσκο
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Πρόσβαση σε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) από τη Διαφάνεια.
4. Ορίστε το [FontHeight](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/fontheight/) για το κείμενο. 
5. Ορίστε το [Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/alignment/) και το [MarginRight](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginright/) . 
6. Ορίστε το [TextVerticalType](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/textverticaltype/) .
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

```c#
using Aspose.Slides;

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας

// Ορίζει το ύψος γραμματοσειράς των κελιών του πίνακα
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Ορίζει την στοίχιση κειμένου και το δεξιό περιθώριο των κελιών του πίνακα σε μία κλήση
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Ορίζει τον κατακόρυφο τύπο κειμένου των κελιών του πίνακα
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ ενός πίνακα ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλον πίνακα ή αλλού. Αυτός ο κώδικας C# δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προεπιλεγμένο στυλ πίνακα: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // αλλάζει το προεπιλεγμένο στυλ προεπιλογής

    // Παίρνουμε το προεπιλεγμένο στυλ του πίνακα.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Εφαρμόζουμε το ανακτημένο προεπιλεγμένο στυλ σε άλλο πίνακα.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός γεωμετρικού σχήματος είναι ο λόγος των μεγεθών του σε διαφορετικές διαστάσεις. Η Aspose.Slides παρέχει την ιδιότητα `AspectRatioLocked` για να μπορείτε να κλειδώσετε τη ρύθμιση της αναλογίας διαστάσεων για πίνακες και άλλα σχήματα. 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // αντιστροφή

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς τα αριστερά (RTL) για ολόκληρο πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει την ιδιότητα [RightToLeft](https://reference.aspose.com/slides/el/net/aspose.slides/table/righttoleft/) και οι παράγραφοι έχουν την ιδιότητα [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphformat/righttoleft/) . Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να εμποδίσω τους χρήστες να μετακινούν ή να αλλάζουν μέγεθος έναν πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [shape locks](/slides/el/net/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα ισχύουν και για τους πίνακες.

**Υποστηρίζεται η εισαγωγή μιας εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε ένα [picture fill](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού σύμφωνα με την επιλεγμένη λειτουργία (stretch ή tile).