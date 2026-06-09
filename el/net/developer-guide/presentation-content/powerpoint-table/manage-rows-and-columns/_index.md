---
title: Διαχείριση γραμμών και στηλών σε πίνακες PowerPoint σε .NET
linktitle: Γραμμές και Στήλες
type: docs
weight: 20
url: /el/net/manage-rows-and-columns/
keywords:
- γραμμή πίνακα
- στήλη πίνακα
- πρώτη γραμμή
- κεφαλίδα πίνακα
- κλωνοποίηση γραμμής
- κλωνοποίηση στήλης
- αντιγραφή γραμμής
- αντιγραφή στήλης
- αφαίρεση γραμμής
- αφαίρεση στήλης
- μορφοποίηση κειμένου γραμμής
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τις γραμμές και τις στήλες των πινάκων σε PowerPoint με το Aspose.Slides για .NET και επιταχύνετε την επεξεργασία παρουσιάσεων και την ενημέρωση δεδομένων."
---
## **Εισαγωγή**

Για να μπορείτε να διαχειρίζεστε τις γραμμές και τις στήλες ενός πίνακα σε μια παρουσίαση PowerPoint, το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/net/aspose.slides/table/) , το interface [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) και πολλούς άλλους τύπους. 

## **Ορισμός της πρώτης γραμμής ως κεφαλίδα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την παρουσίαση. 
2. Αποκτήστε αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) και θέστε το σε null. 
4. Περιηγηθείτε σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) για να βρείτε τον σχετικό πίνακα. 
5. Ορίστε την πρώτη γραμμή του πίνακα ως κεφαλίδα του. 

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε την πρώτη γραμμή ενός πίνακα ως κεφαλίδα:

```c#
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation pres = new Presentation("table.pptx");

// Αποκτά την πρώτη διαφάνεια
ISlide sld = pres.Slides[0];

// Αρχικοποιεί το null TableEx
ITable tbl = null;

// Διέρχεται μέσα από τα σχήματα και ορίζει μια αναφορά στον πίνακα
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Ορίζει την πρώτη γραμμή του πίνακα ως κεφαλίδα
tbl.FirstRow = true;

// Αποθηκεύει την παρουσίαση στο δίσκο
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Κλωνοποίηση γραμμής ή στήλης πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την παρουσίαση, 
2. Αποκτήστε αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα των `columnWidth`. 
4. Ορίστε έναν πίνακα των `rowHeight`. 
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addtable/). 
6. Κλωνοποιήστε τη γραμμή του πίνακα. 
7. Κλωνοποιήστε τη στήλη του πίνακα. 
8. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C# δείχνει πώς να κλωνοποιήσετε τη γραμμή ή τη στήλη ενός πίνακα PowerPoint:

```c#
 // Δημιουργεί ένα αντικείμενο της κλάσης Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Αποκτά την πρώτη διαφάνεια
    ISlide sld = presentation.Slides[0];

    // Ορίζει στήλες με πλάτη και γραμμές με ύψη
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Προσθέτει κείμενο στο κελί 1 της γραμμής 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Προσθέτει κείμενο στο κελί 2 της γραμμής 1
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Κλωνοποιεί τη γραμμή 1 στο τέλος του πίνακα
    table.Rows.AddClone(table.Rows[0], false);

    // Προσθέτει κείμενο στο κελί 1 της γραμμής 2
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Προσθέτει κείμενο στο κελί 2 της γραμμής 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Κλωνοποιεί τη γραμμή 2 ως τέταρτη γραμμή του πίνακα
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Κλωνοποιεί την πρώτη στήλη στο τέλος
    table.Columns.AddClone(table.Columns[0], false);

    // Κλωνοποιεί τη δεύτερη στήλη στη θέση της τέταρτης στήλης
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Αποθηκεύει την παρουσίαση στο δίσκο 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Αφαίρεση γραμμής ή στήλης από πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την παρουσίαση, 
2. Αποκτήστε αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα των `columnWidth`. 
4. Ορίστε έναν πίνακα των `rowHeight`. 
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addtable/). 
6. Αφαιρέστε τη γραμμή του πίνακα. 
7. Αφαιρέστε τη στήλη του πίνακα. 
8. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C# δείχνει πώς να αφαιρέσετε μια γραμμή ή μια στήλη από έναν πίνακα:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ορισμός μορφοποίησης κειμένου σε επίπεδο γραμμής πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την παρουσίαση, 
2. Αποκτήστε αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Προσπελάστε το σχετικό αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) από τη διαφάνεια. 
4. Ορίστε το [FontHeight](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/fontheight/) των κυττάρων της πρώτης γραμμής. 
5. Ορίστε το [Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/alignment/) και το [MarginRight](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginright/) των κυττάρων της πρώτης γραμμής. 
6. Ορίστε το [TextVerticalType](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/textverticaltype/) των κυττάρων της δεύτερης γραμμής. 
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C# επιδεικνύει τη λειτουργία.

```c#
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας

// Ορίζει το ύψος γραμματοσειράς των κυττάρων της πρώτης γραμμής
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Ορίζει την στοίχιση κειμένου και το δεξιό περιθώριο των κυττάρων της πρώτης γραμμής
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Ορίζει τον κάθετο τύπο κειμένου των κυττάρων της δεύτερης γραμμής
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Αποθηκεύει την παρουσίαση στο δίσκο
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ορισμός μορφοποίησης κειμένου σε επίπεδο στήλης πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την παρουσίαση, 
2. Αποκτήστε αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Προσπελάστε το σχετικό αντικείμενο [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) από τη διαφάνεια. 
4. Ορίστε το [FontHeight](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/fontheight/) των κυττάρων της πρώτης στήλης. 
5. Ορίστε το [Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/alignment/) και το [MarginRight](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginright/) των κυττάρων της πρώτης στήλης. 
6. Ορίστε το [TextVerticalType](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/textverticaltype/) των κυττάρων της δεύτερης στήλης. 
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C# επιδεικνύει τη λειτουργία: 

```c#
 // Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας

// Ορίζει το ύψος γραμματοσειράς των κυττάρων της πρώτης στήλης
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Ορίζει την στοίχιση κειμένου και το δεξιό περιθώριο των κυττάρων της πρώτης στήλης σε μία κλήση
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Ορίζει τον κάθετο τύπο κειμένου των κυττάρων της δεύτερης στήλης
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Αποθηκεύει την παρουσίαση στο δίσκο
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Λήψη ιδιοτήτων στυλ πίνακα**

Το Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ για έναν πίνακα ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλο πίνακα ή κάπου αλλού. Αυτός ο κώδικας C# δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προρυθμισμένο στυλ πίνακα: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // αλλάζει το προεπιλεγμένο θέμα προεπιλογής στυλ
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/κύριας παρουσίασης, και μπορείτε ακόμα να αντικαταστήσετε τα γεμίσματα, τα περιθώρια και τα χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες του Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε πρώτα τα δεδομένα στη μνήμη και, στη συνέχεια, ξαναγεμίστε τις γραμμές του πίνακα με τη σειρά αυτή.

**Μπορώ να έχω ταινιασμένες (striped) στήλες διατηρώντας προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις ταινιασμένες στήλες, στη συνέχεια αντικαταστήστε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση επιπέδου κελιού έχει προτεραιότητα έναντι του στυλ πίνακα.