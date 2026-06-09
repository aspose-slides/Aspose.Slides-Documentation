---
title: Διαχείριση Πινάκων Παρουσιάσεων σε .NET
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/net/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση σε πίνακα
- λόγος αναλογίας
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργία & επεξεργασία πινάκων σε διαφάνειες PowerPoint με Aspose.Slides για .NET. Ανακαλύψτε απλά παραδείγματα κώδικα C# για να απλοποιήσετε τις ροές εργασίας σας με πίνακες."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος παρουσίασης και απεικόνισης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κελιών (διατεταγμένα σε σειρές και στήλες) είναι σαφείς και εύκολο να κατανοηθούν.

Το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/net/aspose.slides/table/) , τη διεπαφή [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) , την κλάση [Cell](https://reference.aspose.com/slides/el/net/aspose.slides/cell/) , τη διεπαφή [ICell](https://reference.aspose.com/slides/el/net/aspose.slides/icell/) και άλλους τύπους ώστε να μπορείτε να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε κάθε είδους παρουσίαση. 

## **Δημιουργία Πίνακα από το Μηδέν**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα με τιμές `columnWidth` .
4. Ορίστε έναν πίνακα με τιμές `rowHeight` .
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addtable/) .
6. Επαναλάβετε για κάθε [ICell](https://reference.aspose.com/slides/el/net/aspose.slides/icell/) ώστε να εφαρμόσετε μορφοποίηση στα πάνω, κάτω, δεξιά και αριστερά πλαίσια.
7. Συγχωνεύστε τα δύο πρώτα κελιά της πρώτης σειράς του πίνακα. 
8. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) ενός [ICell](https://reference.aspose.com/slides/el/net/aspose.slides/icell/) . 
9. Προσθέστε κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) .
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε έναν πίνακα σε μια παρουσίαση:

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();

// Προσπελαύνει την πρώτη διαφάνεια
ISlide sld = pres.Slides[0];

// Ορίζει στήλες με πλάτη και σειρές με ύψη
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Ορίζει τη μορφοποίηση των περιγραμμάτων για κάθε κελί
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
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Προσθέτει κάποιο κείμενο στο συγχωνευμένο κελί
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Αποθηκεύει την παρουσίαση στο δίσκο
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κελιών είναι απλή και μηδενική. Το πρώτο κελί σε έναν πίνακα έχει δείκτη 0,0 (στήλη 0, σειρά 0). 

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας C# δείχνει πώς να καθορίσετε την αρίθμηση για τα κελιά σε έναν πίνακα:

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation())
{

    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφοποίηση των περιγραμμάτων για κάθε κελί
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

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .

2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα μέσω του δείκτη της. 

3. Δημιουργήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) και ορίστε το σε null.

4. Επαναλάβετε σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) μέχρι να βρεθεί ο πίνακας.

   Αν υποψιάζεστε ότι η διαφάνεια που επεξεργάζεστε περιέχει έναν μόνο πίνακα, μπορείτε απλώς να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα σχήμα ταυτοποιηθεί ως πίνακας, μπορείτε να το μετατρέψετε σε αντικείμενο [Table](https://reference.aspose.com/slides/el/net/aspose.slides/table/) . Αλλά αν η διαφάνεια περιέχει πολλούς πίνακες, τότε είναι καλύτερο να αναζητήσετε τον επιθυμητό πίνακα μέσω του [AlternativeText](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/alternativetext/) .

5. Χρησιμοποιήστε το αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) για να δουλέψετε με τον πίνακα. Στο παρακάτω παράδειγμα, προσθέσαμε μια νέα σειρά στον πίνακα.

6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να προσπελάσετε και να εργαστείτε με έναν υπάρχοντα πίνακα:

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];

    // Αρχικοποιεί το TableEx ως null
    ITable tbl = null;

    // Διατρέχει τα σχήματα και θέτει μια αναφορά στον εντοπισμένο πίνακα
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Ορίζει το κείμενο για την πρώτη στήλη της δεύτερης σειράς
    tbl[0, 1].TextFrame.Text = "New";

    // Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Στοίχιση Κειμένου σε Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) στη διαφάνεια. 
4. Πρόσβαση σε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) από τον πίνακα. 
5. Πρόσβαση στο [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) .
6. Στοίχιση του κειμένου κατακόρυφα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να στοιχίσετε το κείμενο σε έναν πίνακα:

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της. 
3. Πρόσβαση σε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) από τη διαφάνεια.
4. Ορίστε το [FontHeight](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/fontheight/) για το κείμενο. 
5. Ορίστε το [Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/alignment/) και το [MarginRight](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginright/) .
6. Ορίστε το [TextVerticalType](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/textverticaltype/) .
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε τις προτιμώμενες επιλογές μορφοποίησης στο κείμενο ενός πίνακα:

```c#
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας

// Ορίζει το ύψος γραμματοσειράς των κελιών του πίνακα
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Ορίζει τη στοίχιση κειμένου και το δεξιό περιθώριο των κελιών του πίνακα με μια κλήση
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Ορίζει τον κάθετο τύπο κειμένου των κελιών του πίνακα
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Το Aspose.Slides σάς επιτρέπει να ανακτήσετε τις ιδιότητες στυλ ενός πίνακα ώστε να μπορείτε να τις χρησιμοποιήσετε για άλλον πίνακα ή σε άλλη θέση. Αυτός ο κώδικας C# δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προρυθμισμένο στυλ πίνακα: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // αλλάζει το προεπιλεγμένο στυλ προεπιλογής θέματος
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Κλείδωμα Αναλογιών Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός γεωμετρικού σχήματος είναι ο λόγος των μεγεθών του σε διαφορετικές διαστάσεις. Το Aspose.Slides παρέχει την ιδιότητα `AspectRatioLocked` ώστε να μπορείτε να κλειδώσετε τη ρύθμιση αναλογίας διαστάσεων για πίνακες και άλλα σχήματα. 

Αυτός ο κώδικας C# δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων για έναν πίνακα:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // αντιστρέφει

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει την ιδιότητα [RightToLeft](https://reference.aspose.com/slides/el/net/aspose.slides/table/righttoleft/) , και οι παράγραφοι έχουν την ιδιότητα [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphformat/righttoleft/) . Η χρήση και των δύο διασφαλίζει τη σωστή σειρά RTL και την ορθή απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινήσουν ή να αλλάξουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε [shape locks](/slides/el/net/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού ανάλογα με την επιλεγμένη λειτουργία (stretch ή tile).