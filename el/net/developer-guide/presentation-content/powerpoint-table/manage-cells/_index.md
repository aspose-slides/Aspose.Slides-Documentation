---
title: Διαχείριση Κελιών Πίνακα σε Παρουσιάσεις σε .NET
linktitle: Διαχείριση Κελιών
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
description: "Διαχειριστείτε τα κελιά πίνακα PowerPoint σε C#: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε τα περιγράμματα, διαχωρίστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να έχετε πρόσβαση και να τροποποιείτε κελιά πίνακα σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πίνακα, να αφαιρείτε τα σύνορα των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό κελιών, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να αποκτήσετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη διαμόρφωση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες που ξεκινούν από το μηδέν για πρόσβαση στα κελιά του πίνακα με τη σειρά `(column, row)`.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια διασχίζει όλες τις γραμμές και στήλες και χρησιμοποιεί [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με τη σειρά `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), και τις αρχικές συντεταγμένες της περιοχής, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) και [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

## **Αφαίρεση Συνόρων Κελιών Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με το [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα ορίζονται σε πόντους. Το παράδειγμα ορίζει όλα τα τέσσερα σύνορα κελιών σε [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε το [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) για να συνδυάσετε ένα ορθογώνιο εύρος κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην πάνω‑αριστερή και στην κάτω‑δεξιά γωνία του εύρους. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός του καθορισμένου εύρους· το `false` διατηρεί τη συγχώνευση εντός αυτού του εύρους.

Το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και γραμμές 70 πόντων, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` έως το `(2, 2)`. Το αποτέλεσμα είναι κελί που καλύπτει δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα διατηρεί τέσσερις στήλες και τέσσερις γραμμές. Για πρόσβαση στο περιεχόμενο ή τη διαμόρφωση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του στην πάνω‑αριστερή γωνία: `table[1, 1]` σε αυτό το παράδειγμα. Οι άλλες θέσεις στο συγχωνευμένο εύρος παραμένουν μέρος του πλέγματος, επομένως οι δείκτες των κελιών εκτός του εύρους δεν αλλάζουν.

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

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και γραμμές 70 πόντων και καλεί το [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) στο κελί `(1, 1)`. Το μισό του πλάτους του κελιού (70 πόντοι) περνιέται για τη δημιουργία δύο κελιών ίσου πλάτους.

Μετά τη διαίρεση, οι δύο μισές προσπελάζονται ως `table[1, 1]` και `table[2, 1]`. Το πλέγμα του πίνακα τώρα έχει πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά τη διαίρεση.

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

### **Διαίρεση Συγχωνευμένων Κελιών κατά Σειρά ή Στήλη**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για πληροφόρηση δεδομένων, χρησιμοποιήστε το [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) για διαίρεση κατά υπάρχουσα γραμμή, ή το [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) για διαίρεση κατά στήλη.

Το όρισμα `index` μετράει τις γραμμές στο άνω τμήμα ή τις στήλες στο αριστερό τμήμα της διαίρεσης· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Διαίρεση γραμμής: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Διαίρεση στήλης: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Το παράδειγμα υποθέτει ότι η παρουσίαση έχει έναν πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κατακόρυφα. Ξεκινώντας από το κατώτερο σημείο, χρησιμοποιεί τα [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) και [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) για τον εντοπισμό του αρχικού σημείου και ελέγχει και τις δύο εκτάσεις. Το `SplitByRowSpan(1)` τότε διαχωρίζει τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε το `SplitByColSpan(1)`.

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

    // Ανακτήστε τα προκύπτοντα κελιά από τον πίνακα μετά το διαχωρισμό.
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

Το πλέγμα του πίνακα και οι περιβάλλουσες δείκτες κελιών παραμένουν αμετάβλητες. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ και τα δύο έχουν εκτάσεις 1 και το [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) εκτυπώνει `False`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από μια διαίρεση.

Το αρχικό κείμενο και η διαμόρφωσή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη διαμόρφωση του κελιού, όπως γέμισμα, σύνορα και περιθώρια. Συμπληρώστε τα κελιά μετά το διαχωρισμό και ορίστε ρητά τυχόν απαιτούμενη διαμόρφωση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά “Product A” και “Product B” με τη διαμόρφωση κελιού του προτύπου διατηρημένη. Δείτε το [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) για λεπτομέρειες.

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Το παράδειγμα αυτό δημιουργεί έναν πίνακα με στήλες 150 πόντων και γραμμές 50 πόντων. Ορίζει το [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) σε συμπαγές και το [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη γραμμή.

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

Τοποθετήστε την εικόνα εισόδου στον κατάλογο εργασίας πριν τρέξετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Στη συνέχεια αντιστοιχίζει την εικόνα στο γέμισμα εικόνας του κελιού `(0, 0)`, το πρώτο κελί του πίνακα.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεων. Τα πλάτη των στηλών και τα ύψη των γραμμών ορίζονται σε πόντους. Η φορτωμένη εικόνα απορρίπτεται αυτόματα με τη δήλωση `using`.

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

**Μπορώ να ορίσω διαφορετικά πάχη γραμμών και στυλ για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα [επάνω](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[κάτω](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[αριστερά](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[δεξιά](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) σύνορα έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορεί να διαφέρει.

**Τι συμβαίνει με την εικόνα εάν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο κελιού;**

Η συμπεριφορά εξαρτάται από τη [λειτουργία γεμίσματος](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επαναλάβο, τα κομμάτια επαναϋπολογίζονται.

**Μπορώ να προσθέσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/net/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (τμήματος) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, ορίζετε τον σύνδεσμο σε ένα τμήμα ή σε ολόκληρο το κείμενο στο κελί.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (τμήματα) με ανεξάρτητη διαμόρφωση—όνομα γραμματοσειράς, στυλ, μέγεθος και χρώμα.