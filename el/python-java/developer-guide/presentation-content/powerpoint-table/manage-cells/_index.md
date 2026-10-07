---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις με Python
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
description: "Διαχειριστείτε τα κελιά πίνακα του PowerPoint σε Python: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, διαχωρίστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για Python μέσω Java."
---
## **Overview**

Το Aspose.Slides σας επιτρέπει να έχετε πρόσβαση και να τροποποιείτε κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πίνακα, να αφαιρείτε τα περιθώρια των κελιών, να εργάζεστε με την αρίθμηση κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση κελιών μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες με βάση το μηδέν για να προσπελάσει κελιά πινάκων με τη σειρά `(column, row)`.

## **Identify a Merged Table Cell**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια διατρέχει όλες τις γραμμές και στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε ταίριασμα, εκτυπώνει τις συντεταγμένες του κελιού με τη μορφή `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) και [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **Remove Table Cell Borders**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με το [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Τα πλάτα των στηλών, τα ύψη των γραμμών και η θέση του πίνακα καθορίζονται σε μονάδες point. Το παράδειγμα ορίζει όλα τα τέσσερα περιθώρια κελιών σε [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

## **Merge Table Cells**

Χρησιμοποιήστε [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) για να συνδυάσετε ένα ορθογώνιο εύρος κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην επάνω αριστερή και την κάτω δεξιά γωνία του εύρους. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός του καθορισμένου εύρους· `False` διατηρεί τη συγχώνευση εντός του εύρους.

Το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και γραμμές μεγέθους 70 point, μετά συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` έως το `(2, 2)`. Το αποτέλεσμα είναι κελί που εκτείνεται σε δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα παραμένει με τέσσερις στήλες και τέσσερις γραμμές. Για να προσπελάσετε το περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του πάνω αριστερού άκρου: `table.get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στο συγχωνευμένο εύρος παραμένουν μέρος του πλέγματος, οπότε οι δείκτες των κελιών εκτός του εύρους δεν αλλάζουν.

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

## **Split Table Cells**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Ο διαχωρισμός ενός κελιού μπορεί να εισαγάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες στηλών των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και γραμμές 70 point και καλεί το [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) στο κελί `(1, 1)`. Το ήμισυ του πλάτους 70 point του κελιού περνιέται για να δημιουργηθούν δύο κελιά ίσου πλάτους.

Μετά τον διαχωρισμό, τα δύο ημι-κελιά προσπελαύνονται ως `table.get_Item(1, 1)` και `table.get_Item(2, 1)`. Το πλέγμα του πίνακα έχει πλέον πέντε στήλες: τα κελιά που ήταν αρχικά στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στηλών όταν προσπελάζετε κελιά μετά το διαχωρισμό.

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

### **Split Merged Cells by Row or Column Span**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για τη σωλήνωση δεδομένων, χρησιμοποιήστε το [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) για διαχωρισμό κατά υπάρχουσα γραμμή, ή το [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) για διαχωρισμό κατά στήλη.

Το όρισμα `index` μετράει τις γραμμές στο άνω μέρος ή τις στήλες στο αριστερό μέρος του διαχωρισμού· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Διαχωρισμός γραμμής: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Διαχωρισμός στήλης: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Το παράδειγμα υποθέτει ότι η παρουσίαση έχει έναν πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κάθετα. Ξεκινώντας από τη θέση κάτω, χρησιμοποιεί το [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) και το [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) για να εντοπίσει την προέλευση και ελέγχει και τα δύο spans. Το `splitByRowSpan(1)` τότε χωρίζει τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε αντί για αυτό το `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

        # Ανακτήστε τα προκύπτοντα κελιά από τον πίνακα μετά το διαχωρισμό.
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

Το πλέγμα του πίνακα και οι γύρω δείκτες κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ και τα δύο έχουν span 1 και το [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) εκτυπώνει `False`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από έναν διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιθώρια και περιγράμματα. Συμπληρώστε τα κελιά μετά το διαχωρισμό και ορίστε ρητά τυχόν απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά «Product A» και «Product B» με τη μορφοποίηση του προτύπου διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) για λεπτομέρειες.

## **Change the Table Cell Background Color**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 point και γραμμές 50 point. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) για να επιλέξει συμπαγές γέμισμα και θέτει το χρώμα που επιστρέφεται από το [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και την τέταρτη γραμμή.

```python
import jpype
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

## **Add an Image Inside a Table Cell**

Τοποθετήστε την εικόνα εισόδου στον τρέχοντα φάκελο εργασίας πριν τρέξετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Στη συνέχεια αντιστοιχεί την εικόνα στο γέμισμα εικόνας του κελιού `(0, 0)`, του πρώτου κελιού στον πίνακα.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) τεντώει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία του. Τα πλάτη των στηλών και τα ύψη των γραμμών είναι σε μονάδες point. Η φορτωμένη εικόνα διαγράφεται σε μπλοκ `finally` αφού έχει προστεθεί στην παρουσίαση.

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

## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) borders have separate properties, so the thickness and style of each side can differ.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/el/python-java/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.