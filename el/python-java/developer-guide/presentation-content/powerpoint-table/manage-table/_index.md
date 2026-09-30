---
title: Διαχείριση Πίνακων Παρουσίασης σε Python
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
description: "Δημιουργήστε και επεξεργαστείτε πίνακες στις διαφάνειες PowerPoint με το Aspose.Slides για Python μέσω Java. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιώσετε τη ροή εργασίας με τους πίνακες."
---
## **Εισαγωγή**

Οι πίνακες στο PowerPoint οργανώνουν τις πληροφορίες σε σειρές και στήλες, καθιστώντας ευκολότερη την ανάγνωση και τη σύγκριση των τιμών.

Το Aspose.Slides παρέχει τις κλάσεις [Πίνακας](https://reference.aspose.com/slides/python-java/aspose.slides/table/) και [Κυψέλη](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) καθώς και άλλους τύπους, ώστε να μπορείτε να δημιουργείτε, να ενημερώνετε και να διαχειρίζεστε πίνακες σε παρουσιάσεις.

## **Δημιουργία Πίνακα από το Μηδέν**

Δημιουργήστε έναν πίνακα καθορίζοντας τη θέση του, τα πλάτη των στηλών και τα ύψη των σειρών. Αφού τον προσθέσετε σε μια διαφάνεια, μπορείτε να μορφοποιήσετε τα σύνορα των κυψέλων, να συγχωνεύσετε κυψέλες και να εισάγετε κείμενο.

1. Δημιουργήστε μια παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Ορίστε μια λίστα με τα πλάτη των στηλών σε σημεία.
4. Ορίστε μια λίστα με τα ύψη των σειρών σε σημεία.
5. Προσθέστε ένα αντικείμενο [Πίνακας](https://reference.aspose.com/slides/python-java/aspose.slides/table/) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Διατρέξτε κάθε [Κυψέλη](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) για να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τις δύο πρώτες κυψέλες της πρώτης σειράς του πίνακα.
8. Πρόσβαση στην ενωμένη κυψέλη μέσω της μεθόδου [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Ορίστε το κείμενο στην ενωμένη κυψέλη.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα με τρεις στήλες και πέντε σειρές στη θέση (100, 50) σημεία. Εφαρμόζει κόκκινα σύνορα πλάτους 5 σημείων, συγχωνεύει τις δύο πρώτες κυψέλες της πρώτης σειράς και αποθηκεύει το αποτέλεσμα ως `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αρίθμηση σε Τυπικό Πίνακα**

Σε έναν τυπικό πίνακα, οι δείκτες των κυψέλων είναι μηδενικά και ακολουθούν τη σειρά (στήλη, σειρά). Η πρώτη κυψέλη έχει δείκτη (0, 0).

Για παράδειγμα, οι κυψέλες σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Το παράδειγμα αυτό δημιουργεί τον 4 × 4 πίνακα που απεικονίζεται παραπάνω, με πλάτη στηλών και ύψη σειρών 70 σημείων και κόκκινα σύνορα κυψέλων πλάτους 5 σημείων. Οι συντεταγμένες απεικονίζουν τους δείκτες των κυψέλων· το παράδειγμα αφήνει τις κυψέλες κενές και αποθηκεύει τον πίνακα ως `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

Οι πίνακες αποθηκεύονται στη συλλογή σχημάτων μιας διαφάνειας. Διατρέξτε τα σχήματα για να εντοπίσετε έναν πίνακα, έπειτα χρησιμοποιήστε την κλάση [Πίνακας](https://reference.aspose.com/slides/python-java/aspose.slides/table/) για να διαβάσετε ή να ενημερώσετε τις κυψέλες του.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα με το δείκτη της.
3. Διατρέξτε τα αντικείμενα [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) και σταματήστε όταν βρεθεί ένας πίνακας. Εάν η διαφάνεια περιέχει πολλούς πίνακες, χρησιμοποιήστε το [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) για να τα προσδιορίσετε.
4. Ενημερώστε το κείμενο στην επιλεγμένη κυψέλη.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `UpdateExistingTable.pptx` και βρίσκει τον πρώτο πίνακα στην πρώτη διαφάνεια. Θέτει την κυψέλη στη στήλη 0, σειρά 1 σε `New` και αποθηκεύει το αποτέλεσμα ως `table1_out.pptx`. Η είσοδος πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ο πρώτος πίνακας σε αυτή πρέπει να έχει τουλάχιστον μία στήλη και δύο σειρές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για να αλλάξετε το μέγεθος μιας σειράς σε υπάρχοντα πίνακα και να καταλάβετε γιατί το πραγματικό του ύψος μπορεί να υπερβαίνει το ελάχιστο που ζητήθηκε, δείτε το [Έλεγχος Ύψους Γραμμής](/slides/el/python-java/manage-rows-and-columns/#control-row-height).

## **Βρείτε την Κυψέλη που Κατέχει Πλαίσιο Κειμένου**

Όταν γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) από έναν πίνακα, χρησιμοποιήστε τη μέθοδο [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) για να ανακτήσετε την ιδιοκτητική [Κυψέλη](https://reference.aspose.com/slides/python-java/aspose.slides/cell/). Για πλαίσιο κειμένου κυψέλης πίνακα, το [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) επιστρέφει τον ιδιοκτήτη και το [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) επιστρέφει `None`, παρόλο που ο ίδιος ο πίνακας είναι σχήμα.

Οι συντεταγμένες της κυψέλης είναι διαθέσιμες μέσω των μόνο-για-ανάγνωση μεθόδων [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) και [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). Το [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) παρέχει επίσης μόνο-για-ανάγνωση πλοήγηση: επιστρέφει τον ιδιοκτήτη χωρίς να αλλάζει την ιδιοκτησία. Πάντα ελέγχετε την επιστρεφόμενη κυψέλη για `None` πριν τη χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που αναγνωρίζει ιδιοκτήτες κυψέλης‑πίνακα και σχήματος, συμπεριλαμβανομένων σχημάτων που συνδέονται με κόμβους SmartArt, δείτε το [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/python-java/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

Μπορείτε να ελέγξετε την κάθετη αγκύρωση και την κατεύθυνση κειμένου των μεμονωμένων κυψέλων πίνακα. Το παράδειγμα σε αυτήν την ενότητα κεντράρει το κείμενο στην πρώτη κυψέλη και το περιστρέφει κατά 270 μοίρες.

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Προσθέστε ένα αντικείμενο [Πίνακας](https://reference.aspose.com/slides/python-java/aspose.slides/table/) στη διαφάνεια.
4. Πρόσβαση σε ένα αντικείμενο [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) από τον πίνακα.
5. Πρόσβαση στην πρώτη [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) και ορίστε το κείμενο και το χρώμα της.
6. Ορίστε την κάθετη αγκύρωση της κυψέλης και την κατεύθυνση κειμένου χρησιμοποιώντας τις μεθόδους [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) και [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα αυτό δημιουργεί έναν 4 × 4 πίνακα με πλάτη στηλών 120 σημείων και ύψη σειρών 100 σημείων. Μορφοποιεί το κείμενο στην κυψέλη (0, 0), προσθέτει τιμές στις υπόλοιπες κυψέλες της πρώτης σειράς και αποθηκεύει το αποτέλεσμα ως `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

Χρησιμοποιήστε το [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) για να εφαρμόσετε μορφοποίηση κειμένου σε όλες τις κυψέλες ενός πίνακα. Οι υπερφορτώσεις του δέχονται μορφοποίηση τμήματος, παραγράφου και πλαισίου κειμένου, ώστε να μπορείτε να ορίσετε αυτές τις ιδιότητες χωρίς να διατρέξετε μεμονωμένες κυψέλες.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Πρόσβαση σε ένα αντικείμενο [Πίνακας](https://reference.aspose.com/slides/python-java/aspose.slides/table/) από τη διαφάνεια.
4. Ορίστε το μέγεθος γραμματοσειράς με τη μέθοδο [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) για το κείμενο.
5. Ορίστε την στοίχιση παραγράφου και το δεξιό περιθώριο με τις μεθόδους [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) και [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Ορίστε την κατακόρυφη κατεύθυνση κειμένου με τη μέθοδο [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `table.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Ορίζει το μέγεθος γραμματοσειράς σε 25 σημεία, ευθυγραμμίζει τις παραγράφους δεξιά με δεξί περιθώριο 20 σημείων και κάνει το κείμενο κατακόρυφο. Η μορφοποιημένη παρουσίαση αποθηκεύεται ως `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε το [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) για να διαβάσετε το προεπιλεγμένο στυλ ενός πίνακα και το [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) για να το ορίσετε. Το παράδειγμα αυτό εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) σε έναν πίνακα, εκτυπώνει την τιμή του προεπιλεγμένου στυλ και ορίζει το ίδιο προεπιλεγμένο στυλ σε δεύτερο πίνακα. Και οι δύο πίνακες αποθηκεύονται στο `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κλείδωμα Αναλογιών Πίνακα**

Ο λόγος διαστάσεων ενός πίνακα είναι το πηλίκο του πλάτους προς το ύψος του. Χρησιμοποιήστε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) για να κλειδώσετε αυτό το λόγο σε έναν πίνακα.

Το παρακάτω παράδειγμα ανοίγει το `pres.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Εκτυπώνει την τρέχουσα κατάσταση κλειδώματος, ενεργοποιεί το κλείδωμα του λόγου διαστάσεων, εκτυπώνει την ενημερωμένη κατάσταση (`True`) και αποθηκεύει το αποτέλεσμα ως `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς τα αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στις κυψέλες του;**

Ναι. Ο πίνακας διαθέτει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) και οι παράγραφοι έχουν τη μέθοδο [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στις κυψέλες.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [shape locks](/slides/el/python-java/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, το μέγεθος, την επιλογή κ.λπ. Αυτά τα κλειδώματα εφαρμόζονται και στους πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας μέσα σε μια κυψέλη ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) για μια κυψέλη· η εικόνα θα καλύπτει την περιοχή της κυψέλης ανάλογα με τη ζητούμενη λειτουργία (τέντωμα ή επικάλυψη).