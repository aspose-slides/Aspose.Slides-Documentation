---
title: Διαχειριστείτε τα κελιά πίνακα σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: Διαχείριση Κελιών
type: docs
weight: 30
url: /el/python-java/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διάσπαση κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Διαχειριστείτε άνετα τα κελιά πίνακα στο PowerPoint με το Aspose.Slides για Python μέσω Java. Κατακτήστε την πρόσβαση, τροποποίηση και στυλιζάρισμα των κελιών γρήγορα για απρόσκοπτη αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει την πρόσβαση και τροποποίηση των κελιών πίνακα σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίσετε συγχωνευμένα κελιά πίνακα, να αφαιρέσετε τα περιγράμματα των κελιών, να εργαστείτε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διάσπασμα, να αλλάξετε το χρώμα φόντου ενός κελιού και να προσθέσετε μια εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

## **Αναγνώριση Συγχωνευμένου Κελιού Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Λάβετε τον πίνακα από την πρώτη διαφάνεια.
3. Περιηγηθείτε στις σειρές και στήλες του πίνακα για να βρείτε συγχωνευμένα κελιά.
4. Εκτυπώστε ένα μήνυμα όταν βρεθούν συγχωνευμένα κελιά.

Αυτός ο κώδικας Python δείχνει πώς να εντοπίσετε συγχωνευμένα κελιά πίνακα σε μια παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Υποθέτουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Αφαίρεση Περιγραμμάτων Κελιών Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το ευρετήριο της.
3. Ορίστε μια λίστα με τα πλάτη των στηλών.
4. Ορίστε μια λίστα με τα ύψη των σειρών.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addTable).
6. Περιηγηθείτε σε κάθε κελί για να καθαρίσετε τα περιγράμματα επάνω, κάτω, δεξιά και αριστερά.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να αφαιρέσετε τα περιγράμματα από κελιά πίνακα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Ορισμός πλάτους στηλών και ύψους σειρών.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Προσθήκη πίνακα στη διαφάνεια.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ορισμός μορφής περιγράμματος για κάθε κελί.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αρίθμηση σε Συγχωνευμένα Κελιά**

Αν συγχωνεύσουμε δύο ζεύγη κελιών, (1, 1) και (2, 1), καθώς και (1, 2) και (2, 2), ο τελικός πίνακας διατηρεί την αρίθμηση των κελιών του. Αυτός ο κώδικας Python παρουσιάζει τη διαδικασία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Ορισμός πλάτους στηλών και ύψους σειρών.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Προσθήκη πίνακα στη διαφάνεια.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ορισμός μορφής περιγράμματος για κάθε κελί.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Συγχώνευση κελιών (1, 1) και (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Συγχώνευση κελιών (1, 2) και (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Στη συνέχεια συγχωνεύουμε περαιτέρω τα κελιά συγχωνεύοντας τα (1, 1) και (1, 2). Το αποτέλεσμα είναι ένας πίνακας που περιέχει ένα μεγάλο συγχωνευμένο κελί στο κέντρο του:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Ορισμός πλάτους στηλών και ύψους σειρών.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Προσθήκη πίνακα στη διαφάνεια.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ορισμός μορφής περιγράμματος για κάθε κελί.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Συγχώνευση κελιών (1, 1) και (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Συγχώνευση κελιών (1, 2) και (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Συγχώνευση κελιών (1, 1) και (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αρίθμηση σε Διαχωρισμένο Κελί**

Στα προηγούμενα παραδείγματα, η συγχώνευση κελιών πίνακα δεν άλλαζε την αρίθμηση των υπολοίπων κελιών.

Αυτή τη φορά, παίρνουμε έναν κανονικό πίνακα (χωρίς συγχωνευμένα κελιά) και προσπαθούμε να διασπάσουμε το κελί (1, 1) για να δημιουργήσουμε έναν ιδιαίτερο πίνακα. Ίσως θέλετε να προσέξετε την αρίθμηση αυτού του πίνακα, η οποία μπορεί να φαίνεται παράξενη. Ωστόσο, έτσι ακριβώς αριθμεί τα κελιά οι Microsoft PowerPoint και το Aspose.Slides κάνει το ίδιο.

Αυτός ο κώδικας Python παρουσιάζει τη διαδικασία που περιγράψαμε:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Ορισμός πλάτους στηλών και ύψους σειρών.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Προσθήκη πίνακα στη διαφάνεια.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ορισμός μορφής περιγράμματος για κάθε κελί.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Διάσπασμα κελιού (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε το χρώμα φόντου ενός κελιού πίνακα:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Ορισμός πλάτους στηλών και ύψους σειρών.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Προσθήκη πίνακα στη διαφάνεια.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Ορισμός χρώματος φόντου για ένα κελί.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη Εικόνας μέσα σε Κελί Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το ευρετήριο της.
3. Ορίστε μια λίστα με τα πλάτη των στηλών.
4. Ορίστε μια λίστα με τα ύψη των σειρών.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addTable).
6. Φορτώστε το αρχείο εικόνας χρησιμοποιώντας την μέθοδο [Images.fromFile](https://reference.aspose.com/slides/el/python-java/aspose.slides/images/#fromFile).
7. Προσθέστε την εικόνα στην παρουσίαση για να δημιουργήσετε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/).
8. Ορίστε τον τύπο γεμίσματος του κελιού μέσω του [FillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/) σε [FillType.Picture](https://reference.aspose.com/slides/el/python-java/aspose.slides/filltype/#Picture).
9. Προσθέστε την εικόνα στο πρώτο κελί του πίνακα.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να τοποθετήσετε μια εικόνα μέσα σε κελί πίνακα κατά τη δημιουργία πίνακα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Ορισμός πλάτους στηλών και ύψους σειρών.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Προσθήκη πίνακα στη διαφάνεια.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Δημιουργία εικόνας παρουσίασης από το αρχείο εικόνας.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Προσθήκη της εικόνας στο πρώτο κελί του πίνακα.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για διαφορετικές πλευρές ενός ενιαίου κελιού;**

Ναι. Τα περιγράμματα [επάνω](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellformat/#getBorderTop)/[κάτω](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellformat/#getBorderBottom)/[αριστερά](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellformat/#getBorderLeft)/[δεξιά](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellformat/#getBorderRight) έχουν ξεχωριστές ιδιότητες, ώστε η πάχος και το στυλ της κάθε πλευράς να μπορούν να διαφέρουν. Αυτό προκύπτει λογικά από τον έλεγχο περιγραμμάτων ανά πλευρά για ένα κελί, όπως δείχνεται στο άρθρο.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/γραμμής αφού έχω ορίσει μια εικόνα ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από τη [λειτουργία γεμίσματος](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillmode/) (stretch/tile). Με την επέκταση, η εικόνα προσαρμόζεται στο νέο κελί· με την πλακίτωση, τα πλακίδια επαναϋπολογίζονται. Το άρθρο αναφέρει τους τρόπους εμφάνισης εικόνας σε κελί.

**Μπορώ να προσθέσω υπερσύνδεση σε όλο το περιεχόμενο ενός κελιού;**

Οι [Hyperlinks](/slides/el/python-java/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (τμήματος) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, προσθέτετε το σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές εντός ενός ενιαίου κελιού;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) (τμήματα) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.