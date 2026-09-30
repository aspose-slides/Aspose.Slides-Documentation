---
title: "Διαχείριση γραμμών και στηλών σε πίνακες PowerPoint με Python"
linktitle: "Γραμμές και Στήλες"
type: docs
weight: 20
url: /el/python-java/manage-rows-and-columns/
keywords:
- "γραμμή πίνακα"
- "στήλη πίνακα"
- "πρώτη γραμμή"
- "κεφαλίδα πίνακα"
- "κλωνοποίηση γραμμής"
- "κλωνοποίηση στήλης"
- "αντιγραφή γραμμής"
- "αντιγραφή στήλης"
- "αφαίρεση γραμμής"
- "αφαίρεση στήλης"
- "μορφοποίηση κειμένου γραμμής"
- "μορφοποίηση κειμένου στήλης"
- "στυλ πίνακα"
- "PowerPoint"
- "παρουσίαση"
- "Python"
- "Aspose.Slides"
description: "Διαχειριστείτε τις γραμμές και τις στήλες πίνακα σε PowerPoint με Aspose.Slides για Python μέσω Java και επιταχύνετε την επεξεργασία παρουσιάσεων και την ενημέρωση δεδομένων."
---
## **Εισαγωγή**

Το Aspose.Slides for Python via Java σας επιτρέπει να διαχειρίζεστε τη δομή και τη μορφοποίηση του πίνακα σε παρουσιάσεις PowerPoint μέσω της κλάσης [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Μπορείτε να ορίσετε μια γραμμή κεφαλίδας, να κλωνοποιήσετε ή να αφαιρέσετε γραμμές και στήλες και να εφαρμόσετε μορφοποίηση κειμένου σε ολόκληρη γραμμή ή στήλη.

Αυτό το άρθρο εξηγεί αυτές τις λειτουργίες με παραδείγματα Python. Επίσης δείχνει πώς να ανακτήσετε το προεπιλεγμένο στυλ ενός πίνακα ώστε να το επαναχρησιμοποιήσετε. Οι δείκτες γραμμών και στηλών του πίνακα αρχίζουν από το μηδέν.

## **Έλεγχος Ύψους Γραμμής**

Χρησιμοποιήστε το [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) για να ορίσετε το ελάχιστο ύψος μιας γραμμής σε πόντους. Είναι ένα κατώτερο όριο, όχι σταθερό ύψος. Το [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) επιστρέφει το πραγματικό ύψος. Πρόσβαση στη γραμμή μέσω του [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

Το παράδειγμα φορτώνει το [row-height-input.pptx](row-height-input.pptx), το οποίο έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη γραμμή του ξεκινά στα 70 πόντους. Τα κελιά χρησιμοποιούν κείμενο Arial 18 πόντων, περιτύλιξη, και περιθώρια 6 πόντων από πάνω και από κάτω· το μεγαλύτερο κείμενο στη δεύτερη στήλη περιτυλίγεται σε πολλαπλές γραμμές. Το παράδειγμα αυξάνει το ελάχιστο σε 100 πόντους, στη συνέχεια το μειώνει σε 20 πόντους, εκτυπώνει το πραγματικό ύψος μετά από κάθε αλλαγή και αποθηκεύει και τα δύο αποτελέσματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Με την παρεχόμενη παρουσίαση, η αύξηση του ελάχιστου προσθέτει χώρο στη γραμμή. Η μείωσή του αφαιρεί αυτόν τον επιπλέον χώρο, αλλά το πραγματικό ύψος παραμένει μεγαλύτερο από 20 πόντους επειδή το κείμενο και τα περιθώρια των κελιών απαιτούν περισσότερο χώρο. Η μόνο μείωση του ελάχιστου δεν μπορεί να εξαναγκάσει τη γραμμή κάτω από το χώρο που απαιτεί το περιεχόμενό της.

Πολλοί παράγοντες επηρεάζουν το πραγματικό ύψος:

- **Text and font size:** περισσότερο κείμενο, ρητοί αλλαγές γραμμής ή μεγαλύτερη γραμματοσειρά μπορούν να απαιτήσουν περισσότερο κατακόρυφο χώρο.  
- **Wrapping and column width:** με ενεργοποιημένη την περιτύλιξη, η μείωση του πλάτους της στήλης με το [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) μπορεί να δημιουργήσει περισσότερες γραμμές. Μία πιο πλατιά στήλη μπορεί να μειώσει τον απαιτούμενο κατακόρυφο χώρο.  
- **Cell margins:** τα [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) και [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) προσθέτουν κατακόρυφο χώρο. Τα [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) και [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) μειώνουν το πλάτος που διατίθεται για το κείμενο και μπορούν να προκαλέσουν επιπλέον περιτύλιξη.

Για αυτόν τον πίνακα χωρίς συγχωνευμένα κελιά, το κελί που χρειάζεται τον πιο πολύ κατακόρυφο χώρο καθορίζει το όριο κάτω από το περιεχόμενο για ολόκληρη τη γραμμή. Για να μικρύνει η γραμμή, ίσως χρειαστεί επίσης να μειώσετε το κείμενο, το μέγεθος γραμματοσειράς ή τα περιθώρια, ή να αυξήσετε το πλάτος μιας στήλης.

Οι εικόνες παρακάτω δείχνουν τον ίδιο πίνακα στην ίδια κλίμακα. Στα απεικονιζόμενα αποτελέσματα, τα πραγματικά ύψη ήταν 70, 100 και 55,2 πόντους: η τελική γραμμή παρέμεινε ψηλότερη από το ελάχιστο των 20 πόντων. Οι ακριβείς μετρήσεις κειμένου μπορεί να διαφέρουν ανάλογα με τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον σας. Κάντε λήψη των αποθηκευμένων αποτελεσμάτων: [increased minimum](row-height-increased.pptx) και [decreased minimum](row-height-decreased.pptx).

| Αρχικό: ελάχιστο 70 pt, πραγματικό 70 pt | Αυξημένο: ελάχιστο 100 pt, πραγματικό 100 pt | Μειωμένο: ελάχιστο 20 pt, πραγματικό 55,2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Ορισμός της Πρώτης Γραμμής ως Κεφαλίδα**

Χρησιμοποιήστε τη μέθοδο [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) για να επισημάνετε την πρώτη γραμμή για μορφοποίηση κεφαλίδας. Η εμφάνισή της εξαρτάται από το στυλ πίνακα που έχει εφαρμοστεί.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Πρόσβαση στην πρώτη διαφάνεια.  
3. Πρόσβαση στον πίνακα που είναι αποθηκευμένος ως το πρώτο σχήμα στην διαφάνεια.  
4. Ενεργοποιήστε τη μορφοποίηση κεφαλίδας για την πρώτη του γραμμή.  
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ενεργοποιεί τη μορφοποίηση κεφαλίδας για την πρώτη γραμμή και αποθηκεύει το `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

Κλωνοποιήστε γραμμές ή στήλες για να επαναχρησιμοποιήσετε το περιεχόμενό τους και τη μορφοποίησή τους. Μπορείτε να προσθέσετε ένα αντίγραφο στο τέλος του πίνακα ή να το εισάγετε σε συγκεκριμένη θέση.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Πρόσβαση στην πρώτη διαφάνεια.  
3. Καθορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.  
4. Προσθέστε έναν πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).  
5. Κλωνοποιήστε τις απαιτούμενες γραμμές.  
6. Κλωνοποιήστε τις απαιτούμενες στήλες.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `Test.pptx` με τουλάχιστον μία διαφάνεια. Δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές, με διαστάσεις καθορισμένες σε πόντους. Προσθέτει αντίγραφα της πρώτης γραμμής και στήλης, μετά εισάγει αντίγραφα της δεύτερης γραμμής και στήλης στη θέση 3 (η τέταρτη θέση). Ο τελικός πίνακας έχει επτά γραμμές και πέντε στήλες. Το όρισμα `False` απενεργοποιεί την κλωνοποίηση σε γειτονικά συγχωνευμένα κελιά· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
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

## **Αφαίρεση Γραμμής ή Στήλης από Πίνακα**

Αφαιρέστε γραμμές ή στήλες που δεν χρειάζονται πλέον σε έναν πίνακα. Η διαγραφή ενός στοιχείου μετατοπίζει τους δείκτες των γραμμών ή στηλών που το ακολουθούν.

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Πρόσβαση στην πρώτη διαφάνεια.  
3. Καθορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.  
4. Προσθέστε έναν πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).  
5. Αφαιρέστε τη δεύτερη γραμμή και τη δεύτερη στήλη.  
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα τριών επί τριών και αφαιρεί τη γραμμή και τη στήλη στη θέση 1, αφήνοντας έναν πίνακα δύο επί δύο στο `TestTable_out.pptx`. Οι διαστάσεις είναι σε πόντους. Το όρισμα `False` απενεργοποιεί την αφαίρεση γειτονικών συγχωνευμένων γραμμών ή στηλών· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μορφοποίησης Κειμένου στο Επίπεδο Γραμμής Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή για να διατηρήσετε συνέπεια στα κελιά. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.  
3. Χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) για την πρώτη γραμμή.  
4. Χρησιμοποιήστε τα [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) και [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) για την πρώτη γραμμή.  
5. Χρησιμοποιήστε το [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) για τη δεύτερη γραμμή.  
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο γραμμές. Εφαρμόζει κείμενο 25 πόντων, στοίχιση δεξιά και περιθώριο παραγράφου δεξιά 20 πόντων στην πρώτη γραμμή, μετά ορίζει κατακόρυφο κείμενο στη δεύτερη γραμμή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μορφοποίησης Κειμένου στο Επίπεδο Στήλης Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη στήλη για να διατηρήσετε συνέπεια στα κελιά. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.  
3. Χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) για την πρώτη στήλη.  
4. Χρησιμοποιήστε τα [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) και [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) για την πρώτη στήλη.  
5. Χρησιμοποιήστε το [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) για τη δεύτερη στήλη.  
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο στήλες. Εφαρμόζει κείμενο 25 πόντων, στοίχιση δεξιά και περιθώριο παραγράφου δεξιά 20 πόντων στην πρώτη στήλη, μετά ορίζει κατακόρυφο κείμενο στη δεύτερη στήλη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ανάκτηση Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε τη μέθοδο [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) για να ανακτήσετε το προεπιλεγμένο στυλ που έχει εφαρμοστεί σε έναν πίνακα και να το επαναχρησιμοποιήσετε σε άλλο πίνακα. Αυτό προσδιορίζει το preset αντί για τις μεμονωμένες παρακάμψεις μορφοποίησης κελιών.

Το παράδειγμα δημιουργεί έναν πίνακα, εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) και διαβάζει το preset πίσω. Εκτυπώνει την ακέραια τιμή που αντιστοιχεί στο `DarkStyle1` και αποθηκεύει τον πίνακα στο `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/πρωτεύοντος, και μπορείτε ακόμα να παρακάμψετε γεμίσματα, περιθώρια και χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, κατόπιν επανασυμπληρώστε τις γραμμές του πίνακα με τη νέα σειρά.

**Μπορώ να έχω στήλες με ρίγες (striped) διατηρώντας προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις λωρίδες στις στήλες, μετά παρακάμψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση επιπέδου κελιού έχει προτεραιότητα έναντι του στυλ πίνακα.