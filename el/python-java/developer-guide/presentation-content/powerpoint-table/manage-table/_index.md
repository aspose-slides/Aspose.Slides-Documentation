---
title: Διαχείριση Πινάκων Παρουσίασης σε Python
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/python-java/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση σε πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με το Aspose.Slides για Python μέσω Java. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιώσετε τις ροές εργασίας με πίνακες."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος παρουσίασης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κελιών (διατεταγμένα σε σειρές και στήλες) είναι απλές και εύκολες στην κατανόηση.

Η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) , την κλάση [Cell](https://reference.aspose.com/slides/el/python-java/aspose.slides/cell/) και άλλους τύπους ώστε να μπορείτε να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε κάθε είδους παρουσίαση.

## **Δημιουργία Πίνακα από το Μηδέν**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Ορίστε μια λίστα με πλάτη στηλών.
4. Ορίστε μια λίστα με ύψη σειρών.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addTable) .
6. Επεξεργαστείτε κάθε [Cell](https://reference.aspose.com/slides/el/python-java/aspose.slides/cell/) για να εφαρμόσετε μορφοποίηση στα επάνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τα δύο πρώτα κελιά της πρώτης σειράς του πίνακα.
8. Αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) ενός [Cell](https://reference.aspose.com/slides/el/python-java/aspose.slides/cell/) .
9. Προσθέστε κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) .
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
presentation = Presentation()
try:

    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ορίζει τη μορφοποίηση του πλαισίου για κάθε κελί
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Συγχωνεύει τα κελιά 1 και 2 της σειράς 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Προσθέτει κείμενο στο συγχωνευμένο κελί
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Αποθηκεύει την παρουσίαση στον δίσκο
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κελιών είναι απλή και μηδενική βάση. Το πρώτο κελί σε έναν πίνακα έχει δείκτη 0,0 (στήλη 0, σειρά 0).

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε έναν πίνακα με τυπική αρίθμηση κελιών:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
presentation = Presentation()
try:

    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ορίζει τη μορφοποίηση του περιθωρίου για κάθε κελί
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

    # Αποθηκεύει την παρουσίαση στον δίσκο
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα με βάση τον δείκτη της.
3. Αρχικοποιήστε μια μεταβλητή για ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) και ορίστε την σε `None` .
4. Διερευνήστε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) μέχρι να βρεθεί ο πίνακας.

   Εάν υποψιάζεστε ότι η διαφάνεια που επεξεργάζεστε περιέχει έναν μόνο πίνακα, μπορείτε απλώς να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα σχήμα προσδιοριστεί ως πίνακας, μπορείτε να το χρησιμοποιήσετε ως αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) . Όμως, εάν η διαφάνεια περιέχει πολλούς πίνακες, είναι προτιμότερο να αναζητήσετε τον επιθυμητό πίνακα μέσω του [getAlternativeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getAlternativeText) .

5. Χρησιμοποιήστε το αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) για να εργαστείτε με τον πίνακα. Στο παρακάτω παράδειγμα, ενημερώνουμε το κείμενο στην πρώτη στήλη της δεύτερης σειράς.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Αρχικοποιεί την αναφορά στον πίνακα.
    table = None

    # Διασχίζει τα σχήματα και ορίζει μια αναφορά στον εντοπισθέντα πίνακα
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Ορίζει το κείμενο για την πρώτη στήλη της δεύτερης σειράς
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Αποθηκεύει την τροποποιημένη παρουσίαση στον δίσκο
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Εύρεση του Κελιού που Κατέχει ένα TextFrame**

Όταν γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) από έναν πίνακα, χρησιμοποιήστε τη μέθοδο [TextFrame.getParentCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentCell) για να ανακτήσετε το ιδιοκτησιακό [Cell](https://reference.aspose.com/slides/el/python-java/aspose.slides/cell/) . Για ένα πλαίσιο κειμένου κελιού πίνακα, η μέθοδος [TextFrame.getParentCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentCell) επιστρέφει τον ιδιοκτήτη και η [TextFrame.getParentShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentShape) επιστρέφει `None`, παρόλο που ο πίνακας είναι σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο-ανάγνωσης μεθόδων [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/el/python-java/aspose.slides/cell/#getFirstColumnIndex) και [Cell.getFirstRowIndex](https://reference.aspose.com/slides/el/python-java/aspose.slides/cell/#getFirstRowIndex) . Η [TextFrame.getParentCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentCell) παρέχει επίσης πλοήγηση μόνο για ανάγνωση: επιστρέφει τον ιδιοκτήτη αλλά δεν αλλάζει την κυριότητα. Πάντα ελέγχετε το επιστρεφόμενο κελί για `None` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιών πίνακα και σχήματα, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Search and Replace Text](/slides/el/python-java/search-and-replace-text/) .

## **Στοίχηση Κειμένου σε Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) στη διαφάνεια.
4. Αποκτήστε πρόσβαση σε ένα αντικείμενο [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) από τον πίνακα.
5. Αποκτήστε πρόσβαση στο [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/) του αντικειμένου [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) .
6. Στοίχισε το κείμενο κάθετα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Δημιουργεί ένα αντικείμενο της κλάσης Presentation
presentation = Presentation()
try:

    # Λαμβάνει την πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Προσθέτει το σχήμα πίνακα στη διαφάνεια
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Προσπελάζει το πλαίσιο κειμένου
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Προσπελάζει την πρώτη παράγραφο στο πλαίσιο κειμένου.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Προσπελάζει το πρώτο τμήμα στην παράγραφο.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Στοίχει το κείμενο κάθετα
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Αποθηκεύει την παρουσίαση στον δίσκο
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Αποκτήστε πρόσβαση σε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) από τη διαφάνεια.
4. Ορίστε το ύψος γραμματοσειράς του κειμένου με τη μέθοδο [setFontHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setFontHeight) .
5. Ορίστε την στοίχιση και το δεξιό περιθώριο με τις μεθόδους [setAlignment](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setAlignment) και [setMarginRight](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setMarginRight) .
6. Ορίστε τον κάθετο τύπο κειμένου με τη μέθοδο [setTextVerticalType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setTextVerticalType) .
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

    # Δημιουργεί ένα αντικείμενο της κλάσης Presentation
presentation = Presentation("simpletable.pptx")
try:

        # Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

            # Ορίζει το ύψος γραμματοσειράς των κελιών του πίνακα
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

            # Ορίζει την στοίχιση κειμένου και το δεξιό περιθώριο των κελιών του πίνακα σε μία κλήση
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

            # Ορίζει τον κάθετο τύπο κειμένου των κελιών του πίνακα
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Ανάκτηση Ιδιοτήτων Στυλ Πίνακα**

Η Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ ενός πίνακα, ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για κάποιον άλλο πίνακα ή αλλού. Αυτός ο κώδικας Python δείχνει πώς να πάρετε τις ιδιότητες στυλ από ένα προκαθορισμένο στυλ πίνακα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # αλλάζει το προεπιλεγμένο θέμα στυλ προεπιλογής

    # Λαμβάνει το προεπιλεγμένο στυλ του πίνακα
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Εφαρμόζει το ληφθέν προεπιλεγμένο στυλ σε άλλον πίνακα
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός γεωμετρικού σχήματος είναι το πηλίκο των μεγεθών του σε διαφορετικές διαστάσεις. Η Aspose.Slides παρέχει τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/el/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) ώστε να μπορείτε να κλειδώσετε τη ρύθμιση αναλογίας διαστάσεων για πίνακες και άλλα σχήματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # αντιστρέφει
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας διαθέτει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/#setRightToLeft) , ενώ οι παράγραφοι έχουν τη μέθοδο [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setRightToLeft) . Η χρήση και των δύο εγγυάται τη σωστή σειρά RTL και απόδοση εντός των κελιών.

**Πώς μπορώ να εμποδίσω τους χρήστες από το να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [shape locks](/slides/el/python-java/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, αλλαγή μεγέθους, επιλογή κ.λπ. Αυτά τα κλειδώματα εφαρμόζονται και στους πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε ένα [picture fill](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού σύμφωνα με την επιλεγμένη λειτουργία (επιμήκυνση ή επικάλυψη).