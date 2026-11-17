---
title: Διαχείριση κελιών πινάκων σε παρουσιάσεις στο .NET
linktitle: Διαχείριση κελιών
type: docs
weight: 30
url: /el/net/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαίρεση κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε κελιά πινάκων PowerPoint σε C#: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, διαιρέστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Aspose.Slides σάς επιτρέπει να προσπελάζετε και να τροποποιείτε κελιά πίνακα σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πίνακα, να αφαιρείτε τα περιθώρια των κελιών, να εργάζεστε με την αρίθμηση κελιών μετά τη συγχώνευση ή το διαχωρισμό κελιών, να αλλάζετε το χρώμα φόντου ενός κελιού, και να προσθέτετε μια εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού, και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες μηδενικής βάσης για την πρόσβαση στα κελιά πίνακα με τη σειρά `(column, row)`.

## **Αναγνώριση Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια, επαναλαμβάνει όλες τις γραμμές και στήλες και χρησιμοποιεί [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με σειρά `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), και τις αρχικές συντεταγμένες της περιοχής, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) και [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Αφαίρεση Περιγραμμάτων Κελιών Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα ορίζονται σε πόντους. Το παράδειγμα θέτει όλα τα τέσσερα περιγράμματα κελιού σε [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), καθιστώντας τα αόρατα.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Διαγώνιων Περιγραμμάτων Κελιού**

Χρησιμοποιήστε [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) για να σχεδιάσετε μια γραμμή από την επάνω αριστερή γωνία στην κάτω δεξιά, και [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) για να σχεδιάσετε μια γραμμή από την κάτω αριστερή γωνία στην επάνω δεξιά. Μια διαγώνιος μπορεί να σημαδέψει μια κεφαλίδα γωνίας· και οι δύο διαγώνιοι μπορούν να σχηματίσουν ένα X για να σημειώσουν ότι το κελί δεν είναι εφαρμόσιμο.

Κάθε διαγώνιος είναι ένα [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). Στο [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) του, ορίστε το [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) σε [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) και επιλέξτε ένα [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Ορίστε το [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) της γραμμής σε πόντους.

Το παράδειγμα δημιουργεί τρία κελιά σε μία γραμμή: μια κόκκινη διαγώνια προς τα κάτω, μια μπλε διαγώνια προς τα πάνω, και και τις δύο διαγώνιους. Αφήνει αμετάβλητα τα περιγράμματα πάνω, κάτω, αριστερά και δεξιά του κελιού.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Μια διαγώνιος είναι ιδιότητα μορφοποίησης, όχι διαίρεση κελιού. Κάθε κελί διατηρεί ένα μοναδικό [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); οι περιοχές σε κάθε πλευρά μιας διαγωνίου δεν μπορούν να επεξεργαστούν ανεξάρτητα.

Το αποθηκευμένο πίνακας, αποδομένο στο Microsoft PowerPoint:

![Τρία κελιά πίνακα που δείχνουν μια κόκκινη διαγώνιο από πάνω-αριστερά προς κάτω-δεξιά, μια μπλε διαγώνιο από κάτω-αριστερά προς πάνω-δεξιά, και και τις δύο διαγώνιους που σχηματίζουν X.](diagonal-cell-borders.png)

*Από αριστερά προς δεξιά: διαγώνιος προς τα κάτω (κόκκινο, 3 pt), διαγώνιος προς τα πάνω (μπλε, 5 pt), και και οι δύο διαγώνιοι.*

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) για να συνδυάσετε μια ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην επάνω αριστερή και την κάτω δεξιά γωνία της περιοχής. Το τελικό όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλάβει κελιά εκτός της καθορισμένης περιοχής· το `false` διατηρεί τη συγχώνευση εντός αυτής της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 πόντων, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από `(1, 1)` έως `(2, 2)`. Το αποτέλεσμα είναι ένα κελί που καλύπτει δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα παραμένει τέσσερις στήλες και τέσσερις γραμμές. Για πρόσβαση στο περιεχόμενο ή στη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε την επάνω αριστερή θέση: `table[1, 1]` σε αυτό το παράδειγμα. Οι άλλες θέσεις στη συγχωνευμένη περιοχή παραμένουν μέρος του πλέγματος, έτσι οι δείκτες κελιών εκτός της περιοχής δεν αλλάζουν.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Διαίρεση Κελιών Πίνακα**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Η διαίρεση ενός κελιού μπορεί να εισαγάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πίνακα του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 πόντων και καλεί [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) στο κελί `(1, 1)`. Το μισό του πλάτους των 70 πόντων του κελιού περνιέται για να δημιουργηθούν δύο κελιά ίσου πλάτους.

Μετά από αυτή τη διαίρεση, τα δύο μισά προσπελαύνονται ως `table[1, 1]` και `table[2, 1]`. Το πλέγμα του πίνακα τώρα έχει πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μετατοπίζονται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά τη διαίρεση.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Διαίρεση Συγχωνευμένων Κελιών κατά Row ή Column Span**

Για να προετοιμάσετε τα συγχωνευμένα κελιά προτύπου για πληθυσμό δεδομένων, χρησιμοποιήστε [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) για διαίρεση κατά υπάρχον όριο γραμμής, ή [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) για διαίρεση κατά όριο στήλης.

Το όρισμα `index` μετρά γραμμές στο άνω μέρος ή στήλες στο αριστερό μέρος της διαίρεσης· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Διαίρεση γραμμής: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Διαίρεση στήλης: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Το παράδειγμα υποθέτει ότι η παρουσίαση έχει έναν πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με `(1, 2)` και `(1, 3)` συγχωνευμένα κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) και [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) για να εντοπίσει το αρχικό σημείο και ελέγχει και τα δύο spans. Το `SplitByRowSpan(1)` χωρίζει τότε τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε `SplitByColSpan(1)` αντίθετα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Ανακτήστε τα προκύπτοντα κελιά από τον πίνακα μετά τη διαίρεση.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Το πλέγμα του πίνακα και οι δείκτες των γύρω κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν span 1 και το [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) εκτυπώνει `False`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν μερικώς συγχωνευμένες μετά από μία διαίρεση.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά το splitting και ορίστε ρητά τυχόν απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά “Product A” και “Product B” με τη διατηρημένη μορφοποίηση του προτύπου. Δείτε την [Αναφορά API Κελού](https://reference.aspose.com/slides/net/aspose.slides/cell/) για λεπτομέρειες.

<!-- visual-explanation:manage-cells:start -->
[![Το συγχωνευμένο κελί στη στήλη 1, γραμμές 2 και 3 χωρίζεται σε Product A και Product B με τους ίδιους δείκτες πλέγματος.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Η διαίρεση row-span χρησιμοποιεί το υπάρχον όριο. Τα Product A και Product B καταλαμβάνουν (1, 2) και (1, 3), αντίστοιχα.*
<!-- visual-explanation:manage-cells:end -->

### **Διαίρεση Κελιού σε Συγκεκριμένο Ύψος**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) λαμβάνει το ύψος του άνω μέρους σε πόντους. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) λαμβάνει τον αριθμό των υπαρχουσών γραμμών πλέγματος στο άνω μέρος. Για να κεντράρετε ένα κελί 40 πόντων στη δεξιά στήλη, αφαιρέστε 40 από το πραγματικό ύψος του κελιού και διαιρέστε το υπόλοιπο χώρο ίσο πάνω και κάτω.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

Η πρώτη διαίρεση προσθέτει μια γραμμή πλέγματος, αφήνοντας τα κατώτερα 90 πόντους στο `[1, 1]`. Η δεύτερη διαίρεση στοχεύει αυτό το κελί και προσθέτει άλλη μια γραμμή κάτω από αυτό. Η δεξιά στήλη περιέχει τώρα `[1, 0]` στα 50 πόντους (`margin`), `[1, 1]` στα 40 πόντους, και `[1, 2]` στα 50 πόντους (`margin`). Το αριστερό κελί καλύπτει όλες τις τρεις γραμμές στο αρχικό του ύψος των 140 πόντων.

![Το αριστερό κελί εκτείνεται σε όλο το ύψος του πίνακα δίπλα σε τρία κελιά με το Middle στο κέντρο.](split-by-height.png)

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 πόντων και γραμμές 50 πόντων. Ορίζει το [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) σε συμπαγές και το [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη γραμμή.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

Τοποθετήστε την εικόνα εισόδου στον κατάλογο εργασίας πριν τρέξετε αυτό το παράδειγμα. Φορτώνει την εικόνα με [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Στη συνέχεια, αντιστοιχίζει την εικόνα στο γέμισμα εικόνας του κελιού `(0, 0)`, του πρώτου κελιού στον πίνακα.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) τεντώει την εικόνα ώστε να γεμίσει το κελί, γεγονός που μπορεί να αλλάξει την αναλογία διαστάσεών του. Τα πλάτη των στηλών και τα ύψη των γραμμών είναι σε πόντους. Η φορτωμένη εικόνα εξυπηρετείται αυτόματα από τη δήλωση using.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για τις διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [επάνω](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[κάτω](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[αριστερά](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[δεξιά](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) έχουν ξεχωριστές ιδιότητες, έτσι η πάχος και το στυλ κάθε πλευράς μπορούν να διαφέρουν.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντου κελιού;**

Η συμπεριφορά εξαρτάται από τη [mode γεμίσματος](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη, τα πλακίδια επανυπολογίζονται.

**Μπορώ να προσθέσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Οι [Υπερσυνδέσεις](/slides/el/net/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (μερίδας) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, ορίζετε το σύνδεσμο σε μια μερίδα ή σε όλο το κείμενο στο κελί.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [μερίδες](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.