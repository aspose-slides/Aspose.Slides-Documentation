---
title: Αποκτήστε τις Αποτελεσματικές Ιδιότητες Σχήματος από Παρουσιάσεις σε Python μέσω Java
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/python-java/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα λοξότμησης
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να χρησιμοποιείτε το Aspose.Slides για Python μέσω Java για να διακρίνετε την τοπική, κληρονομική και αποτελεσματική μορφοποίηση σχήματος σε παρουσιάσεις PowerPoint."
---
## **Κατανόηση Τοπικών, Κληρονομικών και Αποτελεσματικών Ιδιοτήτων**

Η μορφοποίηση του PowerPoint μπορεί να προέρχεται από διάφορες πηγές. Η τιμή που αποθηκεύεται απευθείας σε ένα αντικείμενο είναι η **τοπική τιμή**. Εάν αυτή η τιμή δεν είναι ορισμένη, το PowerPoint εξετάζει τις γονικές πηγές μορφοποίησης, όπως η προεπιλογή παραγράφου, ένα στυλ κειμένου, μια διάταξη ή η κύρια διαφάνεια, ένα θέμα ή οι προεπιλογές σε επίπεδο παρουσίασης. Αυτές οι τιμές είναι **κληρονομικές τιμές**. Η τιμή που παραμένει αφού επιλυθεί ολόκληρη η ιεραρχία είναι η **αποτελεσματική τιμή** — η τιμή που χρησιμοποιείται για την απόδοση του αντικειμένου.

Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην ορίζει το δικό του ύψος γραμματοσειράς. Η τοπική του τιμή [getFontHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#getFontHeight) είναι τότε `float("nan")`, που σημαίνει «δεν ορίστηκε εδώ». Το τμήμα μπορεί να κληρονομήσει ένα ύψος από την παράγραφο του, το προεπιλεγμένο στυλ κειμένου της παρουσίασης ή άλλη σχετική πηγή. Καλώντας [getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#getEffective) στη μορφή του τμήματος επιστρέφει το τελικό επιλυμένο ύψος.

Χρησιμοποιήστε τα δύο είδη δεδομένων μορφοποίησης για διαφορετικούς σκοπούς:

- Διαβάστε ή τροποποιήστε ένα τοπικό αντικείμενο μορφής, όπως το [PortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/), όταν χρειάζεται να ελέγξετε πού ορίζεται μια τιμή.
- Διαβάστε ένα αντικείμενο αποτελεσματικών δεδομένων, όπως `PortionFormatEffectiveData`, όταν χρειάζεται το τελικό, αποδιδόμενο αποτέλεσμα. Τα αποτελεσματικά δεδομένα είναι μόνο για ανάγνωση.

## **Σύγκριση Τοπικών, Κληρονομικών και Αποτελεσματικών Τιμών**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα σχήμα και εφαρμόζει ύψη γραμματοσειράς στο επίπεδο παρουσίασης, παραγράφου και τμήματος. Κάθε βήμα εκτυπώνει τις τιμές που ορίζονται σε αυτά τα επίπεδα και την προκύπτουσα αποτελεσματική τιμή για το ίδιο τμήμα κειμένου. Επίσης δείχνει γιατί τα αποτελεσματικά δεδομένα πρέπει να διαβαστούν ξανά μετά από αλλαγές μορφοποίησης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Διαβάστε τα αποτελεσματικά δεδομένα μετά τις προηγούμενες αλλαγές.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Ορίστε κληρονομικές τιμές σε δύο διαφορετικά επίπεδα.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Μια τοπική τιμή στο τμήμα υπερισχύει και των δύο κληρονομικών τιμών.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Η αλλαγή μιας κληρονομικής τιμής δεν υπερισχύει μιας υπάρχουσας τοπικής τιμής.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Καθαρίστε την τοπική τιμή. Το τμήμα τώρα κληρονομεί ξανά από την παράγραφο.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Καθαρίστε την τιμή της παραγράφου. Η προεπιλογή της παρουσίασης τώρα παρέχει το αποτέλεσμα.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η προτεραιότητα σε αυτό το παράδειγμα είναι η τοπική μορφοποίηση του τμήματος, ακολουθούμενη από τη μορφοποίηση της παραγράφου και τέλος την προεπιλογή της παρουσίασης. Άλλα αντικείμενα μπορεί να έχουν διαφορετικές αλυσίδες κληρονόμησης, αλλά η αρχή είναι η ίδια: μια πιο συγκεκριμένη ρητή τιμή κερδίζει, και [getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#getEffective) επιστρέφει το τελικό αποτέλεσμα.

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κειμένου**

Η μορφοποίηση του κειμένου χωρίζεται σε πολλά αντικείμενα:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getEffective) επιλύει τις ιδιότητες πλαισίου κειμένου όπως περιθώρια, άγκυρωση, αυτόματη προσαρμογή και κατακόρυφη κατεύθυνση κειμένου.
- [TextStyle.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/textstyle/#getEffective) επιλύει τη μορφοποίηση παραγράφου για κάθε επίπεδο στυλ κειμένου.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#getEffective) επιλύει τις ιδιότητες παραγράφου όπως στοίχιση, εσοχή και κουκκίδες.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#getEffective) επιλύει τις ιδιότητες χαρακτήρων όπως ύψος γραμματοσειράς, γραμματοσειρά, χρώμα, έντονο και πλάγιο.

Για το επόμενο παράδειγμα, το `text-formatting.pptx` πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) με μη κενό πλαίσιο κειμένου. Το AutoShape μπορεί να εμφανίζεται σε οποιαδήποτε θέση στη συλλογή σχημάτων· ο κώδικας ψάχνει για ένα κατάλληλο αντικείμενο και το επικυρώνει πριν τη χρήση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Λήψη Αποτελεσματικών 3Δ Ιδιοτήτων**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getEffective) επιστρέφει ένα αντικείμενο `ThreeDFormatEffectiveData` που ομαδοποιεί όλες τις επιλυμένες ρυθμίσεις 3Δ. Οι μέθοδοι του `getCamera`, `getLightRig`, `getBevelTop` και `getBevelBottom` εκθέτουν τα αντίστοιχα αποτελεσματικά δεδομένα. Η ανάγνωση αυτών των σχετικών ρυθμίσεων μαζί καθιστά πιο εύκολο να κατανοήσουμε την τελική 3Δ εμφάνιση ενός σχήματος.

Για αυτό το παράδειγμα, το `shape-3d.pptx` πρέπει να περιέχει τουλάχιστον ένα σχήμα στην πρώτη του διαφάνεια. Εφαρμόστε 3Δ κάμερα, φωτισμό ή ρύθμιση γωνίας στο σχήμα αυτό εάν θέλετε το αποτέλεσμα να περιέχει τιμές άλλες από τις προεπιλογές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Λήψη Αποτελεσματικής Μορφοποίησης Πίνακα**

Η μορφοποίηση πίνακα μπορεί να προέρχεται από το στυλ πίνακα και από μορφές που εφαρμόζονται σε ολόκληρο τον πίνακα, στήλη, γραμμή ή μεμονωμένο κελί. Σε συγκρούσεις μεταξύ ρητά ορισμένων γεμισμάτων, η προτεραιότητα είναι κελί, γραμμή, στήλη και στη συνέχεια ολόκληρος ο πίνακας. Η αποτελεσματική μορφή ενός κελιού είναι η τελική μορφή που χρησιμοποιείται για τη σχεδίαση του κελιού.

Για αυτό το παράδειγμα, το `table-formatting.pptx` πρέπει να περιέχει τουλάχιστον έναν πίνακα στην πρώτη του διαφάνεια. Ο πίνακας πρέπει να έχει τουλάχιστον μία γραμμή και μία στήλη. Ο κώδικας ψάχνει για ένα [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) αντί να υποθέτει ότι το `getShapes().get_Item(0)` είναι πίνακας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Εάν χρειάζεστε το χρώμα αντί μόνο του τύπου γεμίσματος, πρώτα ελέγξτε το αποτελεσματικό `getFillType` και στη συνέχεια διαβάστε τη μέθοδο που εφαρμόζεται σε αυτόν τον τύπο — για παράδειγμα, `getSolidFillColor` για στερεό γεμίσμα.

## **Επανάγνωση Αποτελεσματικών Δεδομένων Μετά από Αλλαγές**

Τα αποτελεσματικά δεδομένα περιγράφουν την ιεραρχία μορφοποίησης τη στιγμή που επιλύεται. Καλέστε ξανά το [getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#getEffective) μετά από την αλλαγή οτιδήποτε μπορεί να συμμετάσχει σε αυτήν την ιεραρχία, συμπεριλαμβανομένων των:

- της τοπικής μορφοποίησης του αντικειμένου·
- των προεπιλογών παραγράφου ή πλαισίου κειμένου·
- ενός στυλ πίνακα, πίνακα, στήλης, γραμμής ή μορφής κελιού·
- της μορφοποίησης διάταξης ή κύριας διαφάνειας·
- των δεδομένων θέματος ή των προεπιλογών σε επίπεδο παρουσίασης·
- της διάταξης ή του κύριου που έχει ανατεθεί σε μια διαφάνεια.

Μην διατηρείτε ένα αντικείμενο αποτελεσματικών δεδομένων ως μόνιμη λήψη στιγμιότυπου. Το Aspose.Slides μπορεί να αποθηκεύει προσωρινά κάποια αποτελεσματικά δεδομένα εσωτερικά, και ένα μεταγενέστερο κλήση του [getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#getEffective) μπορεί να ανανεώσει αυτά τα δεδομένα. Εάν χρειάζεστε να συγκρίνετε τις τιμές πριν και μετά από μια αλλαγή, αντιγράψτε τις ατομικές τιμές που χρειάζεστε — όπως ύψος γραμματοσειράς, χρώμα, στοίχιση ή πλάτος γωνίας — σε δικές σας μεταβλητές πριν κάνετε την αλλαγή.

Για να αλλάξετε μια τιμή, ενημερώστε το κατάλληλο τοπικό αντικείμενο μορφής και, στη συνέχεια, καλέστε το [getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#getEffective) για να επαληθεύσετε το αποτέλεσμα. Τα αντικείμενα αποτελεσματικών δεδομένων είναι μόνο για ανάγνωση.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να προσδιορίσω ποιο επίπεδο παρείχε μια αποτελεσματική τιμή;**

Τα αποτελεσματικά δεδομένα περιέχουν τη τελική τιμή, όχι την πηγή της. Εξετάστε τα σχετιζόμενα τοπικά αντικείμενα από το πιο συγκεκριμένο επίπεδο προς τα έξω. Για το κείμενο, αυτό μπορεί να περιλαμβάνει το τμήμα, την παράγραφο, το πλαίσιο κειμένου, τη διάταξη, το κύριο, το θέμα και τις προεπιλογές παρουσίασης. Οι ακαθόριστες τιμές όπως `float("nan")` ή `None` υποδεικνύουν ότι η αναζήτηση συνεχίζεται σε άλλο επίπεδο.

**Τι συμβαίνει όταν κανένα επίπεδο δεν ορίζει μια ιδιότητα;**

Το Aspose.Slides επιλύει την κατάλληλη προεπιλογή του PowerPoint ή της βιβλιοθήκης. Η επιλυμένη τιμή εμφανίζεται στα αποτελεσματικά δεδομένα παρόλο που κανένα τοπικό αντικείμενο δεν την ορίζει ρητά.

**Γιατί κάποιες φορές μια αποτελεσματική τιμή ισούται με την τοπική τιμή;**

Η τοπική τιμή κέρδισε τον υπολογισμό κληρονομικότητας. Αυτό είναι αναμενόμενο όταν η ιδιότητα ορίζεται ρητά στο αντικείμενο και καμία πιο συγκεκριμένη règle δεν την υπερισχύει.

**Πότε πρέπει να χρησιμοποιήσω τοπικά δεδομένα αντί για αποτελεσματικά δεδομένα;**

Χρησιμοποιήστε τοπικά δεδομένα για να ελέγξετε ή να επεξεργαστείτε ένα συγκεκριμένο επίπεδο μορφοποίησης. Χρησιμοποιήστε αποτελεσματικά δεδομένα όταν χρειάζεστε την τελική εμφάνιση μετά την κληρονομικότητα, τους κανόνες θέματος και τα εφαρμοστέα στυλ που έχουν επιλυθεί. Το [complete comparison example](#compare-local-inherited-and-effective-values) δείχνει και τα δύο στην ίδια ροή εργασίας.