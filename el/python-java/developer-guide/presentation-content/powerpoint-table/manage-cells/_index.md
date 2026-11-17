---
title: Διαχείριση κελιών πινάκων σε παρουσιάσεις με τη Python
linktitle: Διαχείριση κελιών
type: docs
weight: 30
url: /el/python-java/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαχωρισμός κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τα κελιά πινάκων PowerPoint με τη Python: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, διαχωρίστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να προσπελάζετε και να τροποποιείτε κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίσετε συγχωνευμένα κελιά πινάκων, να αφαιρέσετε τα πλαίσια των κελιών, να εργαστείτε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό των κελιών, να αλλάξετε το χρώμα φόντου ενός κελιού και να προσθέσετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες μηδενικής βάσης για την πρόσβαση στα κελιά πινάκων με τη σειρά `(column, row)`.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελάζει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια διασχίζει όλες τις γραμμές και τις στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με σειρά `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) και [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```
## **Κατάργηση Περιγραμμάτων Κελιού Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με το [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα καθορίζονται σε points. Το παράδειγμα θέτει όλα τα τέσσερα περιγράμματα του κελιού σε [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), καθιστώντας τα αόρατα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Προσθήκη Διαγώνιων Περιγραμμάτων Κελιού**

Χρησιμοποιήστε το [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) για να σχεδιάσετε μια γραμμή από την άνω αριστερή γωνία προς την κάτω δεξιά, και το [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) για να σχεδιάσετε μια γραμμή από την κάτω αριστερή γωνία προς την άνω δεξιά. Μια διαγώνιος μπορεί να σηματοδοτήσει μια κεφαλίδα γωνίας. Και οι δύο διαγώνιοι μπορούν να σχηματίσουν ένα X για να δηλώσουν ότι ένα κελί δεν είναι εφαρμόσιμο.

Κάθε διαγώνιος είναι ένα [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). Στο [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat), χρησιμοποιήστε το [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) για να επιλέξετε το [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) και επιλέξτε ένα χρώμα μέσω του [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Ορίστε το πλάτος της γραμμής σε points με το [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

Το παράδειγμα δημιουργεί τρία κελιά σε μία σειρά: μια κόκκινη διαγώνια προς τα κάτω, μια μπλε διαγώνια προς τα πάνω, και και τις δύο διαγώνιους. Διατηρεί τα άνω, κάτω, αριστερά και δεξιά περιγράμματα του κελιού αμετάβλητα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
Μια διαγώνιος είναι ιδιότητα μορφοποίησης, όχι διαχωρισμός κελιού. Κάθε κελί διατηρεί ένα μόνο πλαίσιο κειμένου, προσβάσιμο μέσω του [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). Οι περιοχές και από τις δύο πλευρές μιας διαγώνιας δεν μπορούν να επεξεργαστούν ανεξάρτητα.

Ο αποθηκευμένος πίνακας, αποδομένος σε Microsoft PowerPoint:
![Τρία κελιά πίνακα που δείχνουν μια κόκκινη διαγώνιο από άνω αριστερά προς κάτω δεξιά, μια μπλε διαγώνιο από κάτω αριστερά προς άνω δεξιά, και και τις δύο διαγώνιους σχηματίζοντας ένα X.](diagonal-cell-borders.png)

*Από αριστερά προς δεξιά: διαγώνιος προς τα κάτω (κόκκινη, 3 pt), διαγώνιος προς τα πάνω (μπλε, 5 pt), και και οι δύο διαγώνιοι.*

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε το [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) για να συνδυάσετε μια ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην άνω αριστερή και κάτω δεξιά γωνία της περιοχής. Το τελικό όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλάβει κελιά εκτός της καθορισμένης περιοχής· `False` διατηρεί τη συγχώνευση εντός αυτής της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 point, και στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από `(1, 1)` έως `(2, 2)`. Το προκύπτον κελί καλύπτει δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα διατηρεί τέσσερις στήλες και τέσσερις γραμμές. Για πρόσβαση στο περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του στην άνω αριστερή γωνία: `table.get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στην συγχωνευμένη περιοχή παραμένουν μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κελιών εκτός της περιοχής δεν αλλάζουν.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Διαχωρισμός Κελιών Πίνακα**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Ο διαχωρισμός ενός κελιού μπορεί να εισαγάγει μια νέα στήλη στο πλέγμα και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 point και καλεί το [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) στο κελί `(1, 1)`. Το μισό του πλάτους των 70 point του κελιού μεταβιβάζεται για τη δημιουργία δύο κελιών ίσου πλάτους.

Μετά αυτόν το διαχωρισμό, τα δύο μισά προσπελάζονται ως `table.get_Item(1, 1)` και `table.get_Item(2, 1)`. Το πλέγμα του πίνακα έχει τώρα πέντε στήλες: τα κελιά που ήταν αρχικά στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά το διαχωρισμό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![Ένα μη συγχωνευμένο κελί 70 point χωρίζεται σε δύο κελιά 35 point, προσθέτοντας μια πέμπτη στήλη πλέγματος και μετατοπίζοντας τους δείκτες στα δεξιά του.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Ο διαχωρισμός πλάτους επηρεάζει το κελί (1, 1), χρησιμοποιώντας δείκτες μηδενικής βάσης (στήλη, γραμμή). Οι άλλες γραμμές διατηρούν ένα κελί που εκτείνεται και στις δύο νέες θέσεις στήλης.*
<!-- visual-explanation:manage-cells:end -->

### **Διαχωρισμός Συγχωνευμένων Κελιών ανά Περιοχή Γραμμής ή Στήλης**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για την πληρότητα δεδομένων, χρησιμοποιήστε το [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) για να διαχωρίσετε κατά μήκος μιας υπάρχουσας ορίσματος γραμμής, ή το [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) για να διαχωρίσετε κατά μήκος ενός ορίου στήλης.

Το όρισμα `index` μετράει τις γραμμές στο άνω μέρος ή τις στήλες στο αριστερό μέρος του διαχωρισμού· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Διαχωρισμός γραμμής: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Διαχωρισμός στήλης: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Το παράδειγμα υποθέτει ότι μια παρουσίαση έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί τα [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) και [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) για να εντοπίσει το αρχικό σημείο και ελέγχει και τις δύο εκτάσεις. Το `splitByRowSpan(1)` διαχωρίζει τότε τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε αντί αυτού το `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpace.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Ανακτήστε τα προκύπτοντα κελιά από τον πίνακα μετά τον διαχωρισμό.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Το πλέγμα του πίνακα και οι γύρω δείκτες κελιών παραμένουν αμετάβλητα. Ανάκτηση των προκύπτοντων κελιών με τις συντεταγμένες τους· εδώ, και τα δύο έχουν έκταση 1 και το [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) εμφανίζει `False`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από έναν διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως εμφάνιση, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά το διαχωρισμό και ορίστε τυχόν απαιτούμενη μορφοποίηση κειμένου ρητά.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά "Product A" και "Product B" με τη διατηρημένη μορφοποίηση του κελιού του προτύπου. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) για λεπτομέρειες.

### **Διαχωρισμός Κελιού σε Συγκεκριμένο Ύψος**

Το [splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) παίρνει το ύψος του άνω μέρους σε points. Το [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) παίρνει τον αριθμό των υφιστάμενων γραμμών πλέγματος στο άνω μέρος. Για να κεντράρετε ένα κελί 40 point στη δεξιά στήλη, αφαιρέστε 40 από το πραγματικό ύψος του κελιού και μοιράστε το υπόλοιπο χώρο ισότιμα πάνω και κάτω από αυτό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
Ο πρώτος διαχωρισμός προσθέτει μια γραμμή πλέγματος και αφήνει 90 points στο κάτω μέρος του κελιού `(1, 1)`. Ο δεύτερος διαχωρισμός χωρίζει αυτό το κελί σε ένα μεσαίο κελί 40 point και ένα κάτω κελί 50 point. Η δεξιά στήλη έχει τώρα τρία κελιά με ύψη 50, 40 και 50 points από πάνω προς τα κάτω. Το αριστερό κελί εκτείνεται σε όλες τις τρεις γραμές και διατηρεί το αρχικό του ύψος 140 points.

![Το αριστερό κελί εκτείνεται σε όλο το ύψος του πίνακα δίπλα σε τρία κελιά με το "Middle" στο κέντρο.](split-by-height.png)

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 point και γραμμές 50 point. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) για να επιλέξει συμπαγή γέμιση και ορίζει το χρώμα που επιστρέφει το [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη γραμμή.

```python
import jpure
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

Τοποθετήστε την είσοδο εικόνας στον κατάλογο εργασίας πριν εκτελέσετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Στη συνέχεια αντιστοιχίζει την εικόνα στη γεμιστική εικόνα του κελιού `(0, 0)`, το πρώτο κελί του πίνακα.

Το [PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεων. Τα πλάτη των στηλών και τα ύψη των γραμμών είναι σε points. Η φορτωμένη εικόνα διαγράφεται σε ένα μπλοκ `finally` μετά την προσθήκη της στην παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη γραμμής και στυλ για τις διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) έχουν ξεχωριστές ιδιότητες, έτσι το πάχος και το στυλ κάθε πλευράς μπορούν να διαφέρουν.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από το [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη (tiling), τα πλακίδια επαναϋπολογίζονται.

**Μπορώ να αντιστοιχίσω έναν υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Τα [Hyperlinks](/slides/el/python-java/manage-hyperlinks/) ορίζονται στο επίπεδο του κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αντιστοιχίζετε τον σύνδεσμο σε μια περιοχή ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.