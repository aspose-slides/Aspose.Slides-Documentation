---
title: Διαχείριση Σειρών και Στηλών σε Πίνακες PowerPoint στο .NET
linktitle: Σειρές και Στήλες
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
description: "Διαχειριστείτε τις γραμμές και στήλες πίνακα σε PowerPoint με το Aspose.Slides για .NET και επιταχύνετε την επεξεργασία παρουσιάσεων και την ενημέρωση δεδομένων."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET σάς επιτρέπει να διαχειρίζεστε τη δομή και τη μορφοποίηση πινάκων σε παρουσιάσεις PowerPoint μέσω της κλάσης [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) και της διεπαφής [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Μπορείτε να ορίσετε μια γραμμή κεφαλίδας, να κλωνοποιήσετε ή να αφαιρέσετε γραμμές και στήλες και να εφαρμόσετε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή ή τη στήλη.

Αυτό το άρθρο εξηγεί αυτές τις λειτουργίες με παραδείγματα C#. Επίσης δείχνει πώς να ανακτήσετε το προεπιλεγμένο στυλ ενός πίνακα ώστε να το επαναχρησιμοποιήσετε. Οι δείκτες γραμμών και στηλών του πίνακα είναι μηδενικής βάσης.

## **Έλεγχος Ύψους Γραμμής**

Χρησιμοποιήστε το [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) για να ορίσετε το ελάχιστο ύψος μιας γραμμής σε πόντους. Είναι ένα κατώτερο όριο, όχι σταθερό ύψος. Το [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) επιστρέφει το πραγματικό ύψος και είναι μόνο για ανάγνωση. Πρόσβαση στη γραμμή μέσω του [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

Το παράδειγμα φορτώνει το αρχείο [row-height-input.pptx](row-height-input.pptx), το οποίο έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη της γραμμή ξεκινά στα 70 πόντους. Τα κελιά χρησιμοποιούν κείμενο Arial 18‑πόντων, περιτύλιξη και περιθώρια 6 πόντων επάνω και κάτω· το πιο μακρύ κείμενο στη δεύτερη στήλη τυλίγεται σε πολλαπλές γραμμές. Το παράδειγμα αυξάνει το ελάχιστο σε 100 πόντους, στη συνέχεια το μειώνει σε 20 πόντους, εκτυπώνει το πραγματικό ύψος μετά από κάθε αλλαγή και αποθηκεύει και τα δύο αποτελέσματα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Με την παρεχόμενη παρουσίαση, η αύξηση του ελάχιστου προσθέτει χώρο στη γραμμή. Η μείωση του αφαιρεί αυτό το επιπλέον χώρο, αλλά το πραγματικό ύψος παραμένει μεγαλύτερο από 20 πόντους επειδή το κείμενο και τα περιθώρια των κελιών χρειάζονται περισσότερο χώρο. Η μείωση του ελάχιστου μόνη της δεν μπορεί να αναγκάσει τη γραμμή να είναι κάτω από τον χώρο που απαιτεί το περιεχόμενό της.

Several factors affect the actual height:

- **Κείμενο και μέγεθος γραμματοσειράς:** το μεγαλύτερο κείμενο, ρητοί αλλαγές γραμμής ή μεγαλύτερη γραμματοσειρά μπορεί να απαιτούν περισσότερο κάθετο χώρο.
- **Τυλίξιμο και πλάτος στήλης:** με ενεργό τυλίξιμο, μια πιο στενή [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) μπορεί να δημιουργήσει περισσότερες γραμμές. Μια πιο πλατιά στήλη μπορεί να μειώσει τον κάθετο χώρο που απαιτείται.
- **Περιθώρια κελιού:** τα [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) και [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) προσθέτουν κάθετο χώρο. Τα [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) και [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) μειώνουν το πλάτος διαθέσιμο για κείμενο και μπορούν να προκαλέσουν επιπλέον τυλίξιμο.

Για αυτόν τον πίνακα χωρίς συγχωνευμένα κελιά, το κελί που χρειάζεται τον περισσότερο κάθετο χώρο καθορίζει το όριο κλειδώματος του περιεχομένου για ολόκληρη τη γραμμή. Για να μικρύνετε τη γραμμή, ίσως χρειαστεί επίσης να συντομεύσετε το κείμενο, να μειώσετε το μέγεθος της γραμματοσειράς ή τα περιθώρια, ή να διευρύνετε μια στήλη.

Οι εικόνες παρακάτω δείχνουν τον ίδιο πίνακα στην ίδια κλίμακα. Σε αυτήν την εκτέλεση, τα πραγματικά ύψη ήταν 70, 100 και 55,2 πόντοι: η τελική γραμμή παρέμεινε ψηλότερη από το ελάχιστο των 20 πόντων. Οι ακριβείς μετρήσεις κειμένου μπορούν να διαφέρουν ανάλογα με τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον σας. Κατεβάστε τα αποθηκευμένα αποτελέσματα: [increased minimum](row-height-increased.pptx) και [decreased minimum](row-height-decreased.pptx).

| Αρχικό: ελάχιστο 70 pt, πραγματικό 70 pt | Αυξημένο: ελάχιστο 100 pt, πραγματικό 100 pt | Μειωμένο: ελάχιστο 20 pt, πραγματικό 55.2 pt |
| --- | --- | --- |
| ![Αρχικός πίνακας με πρώτη γραμμή 70 πόντων.](row-height-before.png) | ![Πίνακας μετά την αύξηση του ελάχιστου της πρώτης γραμμής σε 100 πόντους.](row-height-increased.png) | ![Πίνακας μετά τη μείωση του ελάχιστου της πρώτης γραμμής σε 20 πόντους· το τυλιγμένο κείμενο κρατά τη γραμμή ψηλότερη από το ελάχιστο.](row-height-decreased.png) |

## **Ορισμός της Πρώτης Γραμμής ως Κεφαλίδα**

Χρησιμοποιήστε την ιδιότητα [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) για να χαρακτηριστεί η πρώτη γραμμή ως κεφαλίδα. Η εμφάνισή της εξαρτάται από το στυλ πίνακα που εφαρμόζεται.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Πρόσβαση στον πίνακα που αποθηκεύεται ως το πρώτο σχήμα στη διαφάνεια.
4. Ενεργοποιήστε τη μορφοποίηση κεφαλίδας για την πρώτη της γραμμή.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ενεργοποιεί τη μορφοποίηση κεφαλίδας για την πρώτη γραμμή και αποθηκεύει το `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

Κλωνοποιήστε γραμμές ή στήλες για να επαναχρησιμοποιήσετε το περιεχόμενο και τη μορφοποίησή τους. Μπορείτε να προσθέσετε ένα αντίγραφο στο τέλος του πίνακα ή να το εισάγετε σε συγκεκριμένη θέση.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη στήλης και τα ύψη γραμμής.
4. Προσθέστε έναν πίνακα με τη μέθοδο [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Κλωνοποιήστε τις απαιτούμενες γραμμές.
6. Κλωνοποιήστε τις απαιτούμενες στήλες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `Test.pptx` με τουλάχιστον μία διαφάνεια. Δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές, με διαστάσεις καθορισμένες σε πόντους. Προσθέτει αντίγραφα της πρώτης γραμμής και στήλης, στη συνέχεια εισάγει αντίγραφα της δεύτερης γραμμής και στήλης στη θέση 3 (την τέταρτη θέση). Ο τελικός πίνακας έχει επτά γραμμές και πέντε στήλες. Το όρισμα `false` απενεργοποιεί την κλωνοποίηση σε γειτονικά συγχωνευμένα κελιά· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Αφαίρεση Γραμμής ή Στήλης από Πίνακα**

Αφαιρέστε γραμμές ή στήλες που δεν χρειάζονται πλέον σε ένα πίνακα. Η αφαίρεση ενός στοιχείου μετατοπίζει τους δείκτες των γραμμών ή στηλών που το ακολουθούν.

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη στήλης και τα ύψη γραμμής.
4. Προσθέστε έναν πίνακα με τη μέθοδο [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Αφαιρέστε τη δεύτερη γραμμή και τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 3x3 και αφαιρεί τη γραμμή και τη στήλη στη θέση 1, αφήνοντας έναν πίνακα 2x2 στο `TestTable_out.pptx`. Οι διαστάσεις είναι σε πόντους. Το όρισμα `false` απενεργοποιεί την αφαίρεση γειτονικών συγχωνευμένων γραμμών ή στηλών· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Γραμμής Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή ώστε να διατηρηθούν τα κελιά της συνεπή. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Ορίστε το [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) για την πρώτη γραμμή.
4. Ορίστε το [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) και το [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) για την πρώτη γραμμή.
5. Ορίστε το [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) για τη δεύτερη γραμμή.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο γραμμές. Εφαρμόζει κείμενο 25‑πόντων, ευθυγράμμιση δεξιά και περιθώριο δεξιάς παραγράφου 20‑πόντων στην πρώτη γραμμή, στη συνέχεια ορίζει κάθετο κείμενο στη δεύτερη γραμμή.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Στήλης Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη στήλη ώστε να διατηρηθούν τα κελιά της συνεπή. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Ορίστε το [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) για την πρώτη στήλη.
4. Ορίστε το [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) και το [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) για την πρώτη στήλη.
5. Ορίστε το [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) για τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο στήλες. Εφαρμόζει κείμενο 25‑πόντων, ευθυγράμμιση δεξιά και περιθώριο δεξιάς παραγράφου 20‑πόντων στην πρώτη στήλη, στη συνέχεια ορίζει κάθετο κείμενο στη δεύτερη στήλη.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Ανάκτηση Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε την ιδιότητα [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) για να ανακτήσετε το προεπιλεγμένο στυλ που εφαρμόζεται σε έναν πίνακα και να το επαναχρησιμοποιήσετε σε άλλο πίνακα. Αυτό προσδιορίζει το προεπιλεγμένο στυλ αντί για τις ατομικές παρακάμψεις μορφοποίησης κελιού.

Το παράδειγμα δημιουργεί έναν πίνακα, εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), και διαβάζει το προεπιλεγμένο στυλ. Εκτυπώνει το `DarkStyle1` και αποθηκεύει τον πίνακα στο `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν ήδη δημιουργημένο πίνακα;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/πρωτεύοντος, και μπορείτε ακόμη να παρακάμψετε τα γέμιστρα, τα περιγράμματα και τα χρώματα κειμένου πάνω από το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, έπειτα επανασυμπληρώστε τις γραμμές του πίνακα με αυτή τη σειρά.

**Μπορώ να έχω λωρίδες (striped) στήλες ενώ διατηρώ προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις λωρίδες στις στήλες, έπειτα παρακάμψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση επιπέδου κελιού έχει προτεραιότητα πάνω από το στυλ πίνακα.