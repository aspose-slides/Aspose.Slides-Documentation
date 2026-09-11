---
title: Διαχείριση Γραμμών και Στηλών σε Πίνακες PowerPoint με χρήση Python
linktitle: Γραμμές και Στήλες
type: docs
weight: 20
url: /el/python-java/manage-rows-and-columns/
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
- Python
- Aspose.Slides
description: "Διαχειριστείτε τις γραμμές και τις στήλες του πίνακα σε PowerPoint με το Aspose.Slides για Python μέσω Java και επιταχύνετε την επεξεργασία παρουσιάσεων και την ενημέρωση δεδομένων."
---
## **Εισαγωγή**

Για να σας επιτρέψει να διαχειριστείτε τις γραμμές και τις στήλες ενός πίνακα σε μια παρουσίαση PowerPoint, το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) και πολλούς άλλους τύπους.

## **Ορίστε την Πρώτη Γραμμή ως Κεφαλίδα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Δημιουργήστε μια αναφορά σε [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) και ορίστε την σε `None`.
4. Επανάληψη σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) για να εντοπίσετε τον σχετικό πίνακα.
5. Ορίστε την πρώτη γραμμή του πίνακα ως κεφαλίδα.

Αυτός ο κώδικας Python σας δείχνει πώς να ορίσετε την πρώτη γραμμή ενός πίνακα ως κεφαλίδα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Ορίστε μια λίστα με το πλάτος των στηλών.
4. Ορίστε μια λίστα με το ύψος των γραμμών.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addTable).
6. Κλωνοποιήστε τη γραμμή του πίνακα.
7. Κλωνοποιήστε τη στήλη του πίνακα.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python σας δείχνει πώς να κλωνοποιήσετε τη γραμμή ή τη στήλη ενός πίνακα PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κατάργηση Γραμμής ή Στήλης από Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Ορίστε μια λίστα με το πλάτος των στηλών.
4. Ορίστε μια λίστα με το ύψος των γραμμών.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addTable).
6. Καταργήστε τη γραμμή του πίνακα.
7. Καταργήστε τη στήλη του πίνακα.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python σας δείχνει πώς να καταργήσετε μια γραμμή ή μια στήλη από έναν πίνακα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Γραμμής Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσπελάστε το σχετικό αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) από τη διαφάνεια.
4. Ορίστε το ύψος γραμματοσειράς των κελιών της πρώτης γραμμής χρησιμοποιώντας τη μέθοδο [setFontHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Ορίστε την στοίχιση κειμένου και το δεξιό περιθώριο των κελιών της πρώτης γραμμής χρησιμοποιώντας τις μεθόδους [setAlignment](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setAlignment) και [setMarginRight](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Ορίστε τον κατακόρυφο τύπο κειμένου των κελιών της δεύτερης γραμμής χρησιμοποιώντας τη μέθοδο [setTextVerticalType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python επιδεικνύει τη λειτουργία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Στήλης Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσπελάστε το σχετικό αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) από τη διαφάνεια.
4. Ορίστε το ύψος γραμματοσειράς των κελιών της πρώτης στήλης χρησιμοποιώντας τη μέθοδο [setFontHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Ορίστε την στοίχιση κειμένου και το δεξιό περιθώριο των κελιών της πρώτης στήλης χρησιμοποιώντας τις μεθόδους [setAlignment](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setAlignment) και [setMarginRight](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Ορίστε τον κατακόρυφο τύπο κειμένου των κελιών της δεύτερης στήλης χρησιμοποιώντας τη μέθοδο [setTextVerticalType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python επιδεικνύει τη λειτουργία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Το Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ για έναν πίνακα ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλο πίνακα ή σε άλλο μέρος. Αυτός ο κώδικας Python σας δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προκαθορισμένο στυλ πίνακα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν ήδη δημιουργημένο πίνακα;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/κύριου θέματος, και μπορείτε ακόμα να παρακάμπνετε γεμίσματα, περιγράμματα και χρώματα κειμένου πάνω από το εν λόγω θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες του Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, στη συνέχεια επαναγεμίστε τις γραμμές του πίνακα με αυτή τη σειρά.

**Μπορώ να έχω ζώνες (γραμμοσκίαση) στήλες ενώ διατηρώ προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τη ζώνη στήλες, στη συνέχεια παρακάμπτετε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση σε επίπεδο κελιού υπερισχύει του στυλ του πίνακα.