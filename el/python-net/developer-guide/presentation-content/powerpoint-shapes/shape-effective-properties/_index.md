---
title: Απόκτηση Αποτελεσματικών Ιδιοτήτων Σχήματος από Παρουσιάσεις σε Python
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/python-net/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα λοξοτομίας
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να χρησιμοποιείτε το Aspose.Slides για Python μέσω .NET για να διακρίνετε τη τοπική, κληρονομική και αποτελεσματική μορφοποίηση σχήματος σε παρουσιάσεις PowerPoint."
---
## **Κατανόηση Τοπικών, Κληρονομικών και Αποτελεσματικών Ιδιοτήτων**

Η μορφοποίηση του PowerPoint μπορεί να προέρχεται από πολλαπλές πηγές. Η τιμή που αποθηκεύεται απευθείας σε ένα αντικείμενο είναι η **τοπική τιμή**. Αν αυτή η τιμή δεν έχει οριστεί, το PowerPoint εξετάζει τις γονικές πηγές μορφοποίησης, όπως η προεπιλογή παραγράφου, ένα στυλ κειμένου, μια διάταξη ή ενδεικτική διαφάνεια, ένα θέμα ή προεπιλογές σε επίπεδο παρουσίασης. Αυτές οι τιμές είναι **κληρονομικές τιμές**. Η τιμή που απομένει αφού λυθεί ολόκληρη η ιεραρχία είναι η **αποτελεσματική τιμή**, η οποία χρησιμοποιείται για την απόδοση του αντικειμένου.

Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην καθορίζει το ύψος της γραμματοσειράς του. Η τοπική του [font_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/ibaseportionformat/font_height/) είναι τότε `float("nan")`, που σημαίνει «δεν ορίστηκε εδώ». Το τμήμα μπορεί να κληρονομήσει ένα ύψος από την παράγραφο, το προεπιλεγμένο στυλ κειμένου της παρουσίασης ή κάποια άλλη σχετική πηγή. Καλώντας [get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/iportionformat/get_effective/) στο μορφότυπο του τμήματος επιστρέφει το τελικό επιλυμένο ύψος.

Χρησιμοποιήστε τα δύο είδη δεδομένων μορφοποίησης για διαφορετικούς σκοπούς:

- Διαβάστε ή αλλάξτε ένα τοπικό αντικείμενο μορφοποίησης, όπως το [IPortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/iportionformat/), όταν χρειάζεται να ελέγξετε πού ορίζεται μια τιμή.
- Διαβάστε ένα αποτελεσματικό δεδομένο, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/iportionformateffectivedata/), όταν χρειάζεστε το τελικό, αποδιδόμενο αποτέλεσμα. Τα αποτελεσματικά δεδομένα είναι μόνο για ανάγνωση.

## **Σύγκριση Τοπικών, Κληρονομικών και Αποτελεσματικών Τιμών**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα σχήμα και εφαρμόζει τα ύψη γραμματοσειράς σε επίπεδο παρουσίασης, παραγράφου και τμήματος. Κάθε βήμα εκτυπώνει τις τιμές που ορίζονται σε εκείνα τα επίπεδα και την προκύπτουσα αποτελεσματική τιμή για το ίδιο τμήμα κειμένου. Επιπλέον δείχνει γιατί τα αποτελεσματικά δεδομένα πρέπει να αναγιγνώσκονται ξανά μετά από αλλαγές μορφοποίησης.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Διαβάστε τα αποτελεσματικά δεδομένα μετά τις προηγούμενες αλλαγές.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Ορίστε κληρονομικές τιμές σε δύο διαφορετικά επίπεδα.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Μια τοπική τιμή στο τμήμα αντικαθιστά και τις δύο κληρονομικές τιμές.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Η αλλαγή μιας κληρονομικής τιμής δεν αντικαθιστά μια υπάρχουσα τοπική τιμή.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Καθαρίστε τη τοπική τιμή. Το τμήμα τώρα κληρονομεί ξανά από την παράγραφο.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Καθαρίστε την τιμή της παραγράφου. Η προεπιλογή της παρουσίασης τώρα παρέχει το αποτέλεσμα.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Η προτεραιότητα σε αυτό το παράδειγμα είναι η τοπική μορφοποίηση του τμήματος, μετά η μορφοποίηση της παραγράφου και τέλος η προεπιλογή της παρουσίασης. Άλλα αντικείμενα μπορούν να έχουν διαφορετικές αλυσίδες κληρονόμησης, αλλά η αρχή παραμένει η ίδια: μια πιο συγκεκριμένη ρητή τιμή κερδίζει, και [get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/iportionformat/get_effective/) επιστρέφει το τελικό αποτέλεσμα.

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κειμένου**

Η μορφοποίηση κειμένου διαχωρίζεται σε πολλά αντικείμενα:

- Η [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/el/python-net/aspose.slides/itextframeformat/get_effective/) επιλύει ιδιότητες πλαισίου κειμένου όπως τα περιθώρια, η αγκύρωση, η αυτόματη προσαρμογή και η κατακόρυφη κατεύθυνση του κειμένου.
- Η [ITextStyle.get_effective()](https://reference.aspose.com/slides/el/python-net/aspose.slides/itextstyle/get_effective/) επιλύει μορφοποίηση παραγράφου για κάθε επίπεδο στυλ κειμένου.
- Η [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/el/python-net/aspose.slides/iparagraphformat/get_effective/) επιλύει ιδιότητες παραγράφου όπως ευθυγράμμιση, εσοχές και κουκίδες.
- Η [IPortionFormat.get_effective()](https://reference.aspose.com/slides/el/python-net/aspose.slides/iportionformat/get_effective/) επιλύει ιδιότητες χαρακτήρων όπως ύψος γραμματοσειράς, τύπο γραμματοσειράς, χρώμα, έντονη και πλάγια γραφή.

Για το επόμενο παράδειγμα, το `text-formatting.pptx` πρέπει να περιέχει τουλάχιστον μια διαφάνεια και ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) με μη κενό πλαίσιο κειμένου. Το AutoShape μπορεί να εμφανίζεται σε οποιαδήποτε θέση στη συλλογή σχημάτων· ο κώδικας αναζητά ένα κατάλληλο αντικείμενο και το επικυρώνει πριν το χρησιμοποιήσει.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Λήψη Αποτελεσματικών 3Δ Ιδιοτήτων**

Η [IThreeDFormat.get_effective()](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformat/get_effective/) επιστρέφει ένα αντικείμενο [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformateffectivedata/) που ομαδοποιεί όλες τις επιλυμένες 3Δ ρυθμίσεις. Οι ιδιότητες του, όπως το [camera](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformateffectivedata/camera/), το [light_rig](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), το [bevel_top](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) και το [bevel_bottom](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/), εκθέτουν τα αντίστοιχα αποτελεσματικά δεδομένα. Η ανάγνωση αυτών των σχετικών ρυθμίσεων μαζί καθιστά πιο εύκολο να κατανοήσετε την τελική 3Δ εμφάνιση ενός σχήματος.

Για αυτό το παράδειγμα, το `shape-3d.pptx` πρέπει να περιέχει τουλάχιστον ένα σχήμα στην πρώτη του διαφάνεια. Εφαρμόστε ρυθμίσεις κάμερας 3Δ, φωτισμού ή λοξοτομίας σε εκείνο το σχήμα αν θέλετε το αποτέλεσμα να περιέχει τιμές διαφορετικές από τις προεπιλογές.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Λήψη Αποτελεσματικής Μορφοποίησης Πίνακα**

Η μορφοποίηση πίνακα μπορεί να προέρχεται από το στυλ πίνακα και από μορφές που εφαρμόζονται σε όλο τον πίνακα, σε μια στήλη, σε μια σειρά ή σε ένα μεμονωμένο κελί. Σε περίπτωση συγκρούσεων μεταξύ ρητά ορισμένων γεμίσματος, η προτεραιότητα είναι κελί, σειρά, στήλη και, τέλος, ολόκληρος ο πίνακας. Η αποτελεσματική μορφή ενός κελιού είναι η τελική μορφή που χρησιμοποιείται για την απόδοση εκείνου του κελιού.

Για αυτό το παράδειγμα, το `table-formatting.pptx` πρέπει να περιέχει τουλάχιστον έναν πίνακα στην πρώτη του διαφάνεια. Ο πίνακας πρέπει να έχει τουλάχιστον μια σειρά και μια στήλη. Ο κώδικας αναζητά ένα [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) αντί να υποθέτει ότι το `shapes[0]` είναι πίνακας.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Αν χρειάζεστε το χρώμα αντί μόνο του τύπου γεμίσματος, ελέγξτε πρώτα την αποτελεσματική [fill_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/ifillformateffectivedata/fill_type/), και μετά διαβάστε την ιδιότητα που ισχύει για εκείνο τον τύπο, για παράδειγμα την [solid_fill_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) για ένα συμπαγές γέμισμα.

## **Επανα‑ανάγνωση Αποτελεσματικών Δεδομένων Μετά τις Αλλαγές**

Τα αποτελεσματικά δεδομένα περιγράφουν την ιεραρχία μορφοποίησης τη στιγμή που επιλύεται. Καλέστε ξανά το `get_effective` μετά από αλλαγή οτιδήποτε μπορεί να συμμετέχει σε αυτήν την ιεραρχία, συμπεριλαμβανομένων:

- της τοπικής μορφοποίησης του αντικειμένου·
- των προεπιλογών παραγράφου ή πλαισίου κειμένου·
- ενός στυλ πίνακα, πίνακα, στήλης, σειράς ή μορφής κελιού·
- της μορφοποίησης διάταξης ή ενδεικτικής διαφάνειας·
- των δεδομένων θέματος ή των προεπιλογών σε επίπεδο παρουσίασης·
- της διάταξης ή ενδεικτικής διαφάνειας που έχει εκχωρηθεί σε μια διαφάνεια·

Μην διατηρείτε ένα αντικείμενο αποτελεσματικών δεδομένων ως μόνιμη φωτογράφιση. Το Aspose.Slides μπορεί να αποθηκεύει προσωρινά κάποια αποτελεσματικά δεδομένα εσωτερικά, και μια μετέπειτα κλήση `get_effective` μπορεί να τα ανανεώσει. Εάν χρειάζεται να συγκρίνετε τιμές πριν και μετά από μια αλλαγή, αντιγράψτε τις απαραίτητες αριθμητικές τιμές, όπως ύψος γραμματοσειράς, χρώμα, ευθυγράμμιση ή πλάτος λοξότομης, σε δικές σας μεταβλητές πριν πραγματοποιήσετε την αλλαγή.

Για να αλλάξετε μια τιμή, ενημερώστε το κατάλληλο τοπικό αντικείμενο μορφοποίησης και, στη συνέχεια, καλέστε το `get_effective` για να επαληθεύσετε το αποτέλεσμα. Τα αντικείμενα αποτελεσματικών δεδομένων είναι μόνο για ανάγνωση.

## **FAQ**

**Πώς μπορώ να διακρίνω ποιο επίπεδο παρείχε μια αποτελεσματική τιμή;**

Τα αποτελεσματικά δεδομένα περιέχουν τη τελική τιμή, όχι την πηγή της. Εξετάστε τα σχετικά τοπικά αντικείμενα από το πιο συγκεκριμένο επίπεδο προς τα έξω. Για κείμενο, αυτό μπορεί να περιλαμβάνει το τμήμα, την παράγραφο, το πλαίσιο κειμένου, τη διάταξη, την ενδεικτική διαφάνεια, το θέμα και τις προεπιλογές της παρουσίασης. Απροσδιόριστες τιμές όπως `float("nan")` ή `None` υποδεικνύουν ότι η αναζήτηση συνεχίζεται σε άλλο επίπεδο.

**Τι συμβαίνει όταν κανένα επίπεδο δεν ορίζει μια ιδιότητα;**

Το Aspose.Slides επιλύει την κατάλληλη προεπιλογή του PowerPoint ή της βιβλιοθήκης. Η επιλυμένη τιμή εμφανίζεται στα αποτελεσματικά δεδομένα, ακόμη και αν κανένα τοπικό αντικείμενο δεν τη ορίζει ρητά.

**Γιατί μερικές φορές μια αποτελεσματική τιμή ισούται με την τοπική τιμή;**

Η τοπική τιμή κέρδισε τον υπολογισμό της κληρονόμησης. Αυτό είναι αναμενόμενο όταν η ιδιότητα έχει οριστεί ρητά στο αντικείμενο και κανένας πιο συγκεκριμένος κανόνας δεν την αντικαθιστά.

**Πότε πρέπει να χρησιμοποιήσω τοπικά δεδομένα αντί για αποτελεσματικά δεδομένα;**

Χρησιμοποιήστε τοπικά δεδομένα για να εξετάσετε ή να επεξεργαστείτε ένα συγκεκριμένο επίπεδο μορφοποίησης. Χρησιμοποιήστε αποτελεσματικά δεδομένα όταν χρειάζεστε την τελική εμφάνιση μετά από κληρονόμηση, κανόνες θέματος και εφαρμοσμένα στυλ. Το [complete comparison example](#compare-local-inherited-and-effective-values) δείχνει και τα δύο στην ίδια ροή εργασίας.