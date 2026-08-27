---
title: Διαχείριση Πινάκων Παρουσίασης με Python
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/python-net/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε & επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint και OpenDocument με Aspose.Slides για Python μέσω .NET. Ανακαλύψτε απλά παραδείγματα κώδικα για να απλοποιήσετε τις ροές εργασίας με πίνακες."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος παρουσίασης πληροφοριών. Πληροφορίες που είναι διαταγμένες σε ένα πλέγμα κελιών (γραμμές και στήλες) είναι απλές και εύκολες στην κατανόηση.

Το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) , την κλάση [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) και άλλους σχετικούς τύπους για να σας βοηθήσει να δημιουργήσετε, να ενημερώσετε και να διαχειριστείτε πίνακες σε οποιαδήποτε παρουσίαση.

## **Δημιουργία πινάκων από την αρχή**

Αυτή η ενότητα δείχνει πώς να δημιουργήσετε έναν πίνακα από την αρχή στο Aspose.Slides προσθέτοντας ένα σχήμα πίνακα σε μια διαφάνεια, ορίζοντας τις γραμμές και τις στήλες του και καθορίζοντας ακριβείς διαστάσεις. Θα δείτε επίσης πώς να γεμίσετε τα κελιά με κείμενο, να προσαρμόσετε την στοίχιση και τα περιγράμματα και να προσαρμόσετε την εμφάνιση του πίνακα.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά σε μια διαφάνεια κατά το δείκτη της.
3. Ορίστε έναν πίνακα με πλάτη στηλών.
4. Ορίστε έναν πίνακα με ύψη γραμμών.
5. Προσθέστε έναν [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια.
6. Περιηγηθείτε σε κάθε [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) και μορφοποιήστε τα άνω, κάτω, δεξιά και αριστερά περιγράμματα.
7. Συγχωνεύστε τα κελιά των δύο πρώτων γραμμών και των δύο πρώτων στηλών σε ένα ενιαίο κελί.
8. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) ενός [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) .
9. Προσθέστε κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) .
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Python δείχνει πώς να δημιουργήσετε έναν πίνακα σε μια παρουσίαση:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορισμός πλάτους στηλών και ύψους γραμμών.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Προσθήκη σχήματος πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Ορισμός μορφοποίησης περιγράμματος για κάθε κελί.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Συγχώνευση κελιών από (γραμμή 0, στήλη 0) έως (γραμμή 1, στήλη 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Προσθήκη κειμένου στο συγχωνευμένο κελί.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Αποθήκευση της παρουσίασης στον δίσκο.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Αρίθμηση σε τυπικούς πίνακες**

Σε έναν τυπικό πίνακα, η αρίθμηση των κελιών είναι απλή και βασίζεται στο μηδέν. Το πρώτο κελί σε έναν πίνακα έχει δείκτη (0, 0) (στήλη 0, γραμμή 0).

Για παράδειγμα, σε έναν πίνακα με 4 στήλες και 4 γραμμές, τα κελιά αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Το παρακάτω παράδειγμα Python δείχνει πώς να αναφέρετε κελιά χρησιμοποιώντας αυτήν την αρίθμηση που ξεκινά από το μηδέν:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη πίνακα με 4 στήλες και 4 γραμμές.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε υπάρχοντα πίνακα**

Αυτή η ενότητα εξηγεί πώς να εντοπίσετε και να εργαστείτε με έναν υπάρχοντα πίνακα σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να βρείτε τον πίνακα σε μια διαφάνεια, να έχετε πρόσβαση στις γραμμές, τις στήλες και τα κελιά του και να ενημερώσετε το περιεχόμενο ή τη μορφοποίηση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα κατά το δείκτη της.
3. Περιηγηθείτε σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) έως ότου βρείτε τον πίνακα.
4. Χρησιμοποιήστε το αντικείμενο [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) για να εργαστείτε με τον πίνακα.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

{{% alert color="info" title="Note" %}}

Αν η διαφάνεια περιέχει αρκετούς πίνακες, είναι καλύτερο να αναζητήσετε τον πίνακα που χρειάζεστε με βάση την ιδιότητα `alternative_text`.

{{% /alert %}}

Το παρακάτω παράδειγμα Python δείχνει πώς να έχετε πρόσβαση και να εργαστείτε με έναν υπάρχοντα πίνακα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation για φόρτωση αρχείου PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    table = None

    # Επανάληψη μέσω των σχημάτων και αναφορά στον πρώτο πίνακα που βρέθηκε.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Ορισμός του κειμένου του πρώτου κελιού της πρώτης γραμμής.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Αποθήκευση της τροποποιημένης παρουσίασης στον δίσκο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εύρεση του κελιού που κατέχει ένα πλαίσιο κειμένου**

Όταν ο γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) από έναν πίνακα, χρησιμοποιήστε την ιδιότητα [TextFrame.parent_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_cell/) για να ανακτήσετε το ιδιοκτήτη [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/). Για ένα πλαίσιο κειμένου κελιού πίνακα, το [TextFrame.parent_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_cell/) είναι ορισμένο και το [TextFrame.parent_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_shape/) είναι `None`, ακόμη κι όταν ο ίδιος ο πίνακας είναι σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο για ανάγνωση ιδιοτήτων [Cell.first_column_index](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/first_column_index/) και [Cell.first_row_index](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/first_row_index/). Η ιδιότητα [TextFrame.parent_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_cell/) είναι επίσης μόνο για ανάγνωση: παρέχει πλοήγηση στον ιδιοκτήτη αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγξτε το επιστρεφόμενο κελί για `None` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιού πίνακα και σχήματος, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Search and Replace Text](/slides/el/python-net/search-and-replace-text/) .

## **Στοίχιση κειμένου σε πίνακες**

Αυτή η ενότητα δείχνει πώς να ελέγχετε την τοποθέτηση του κειμένου μέσα σε κελιά πίνακα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε να αγκυροβολείτε το κείμενο κάθετα σε ένα κελί και να αλλάζετε την κατεύθυνση με την οποία τρέχει το κείμενο.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά στη διαφάνεια κατά το δείκτη της.
3. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια.
4. Αποκτήστε ένα αντικείμενο [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) από τον πίνακα.
5. Κεντράρετε το κείμενο κάθετα στο κελί και ορίστε την κατεύθυνση του κειμένου.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Python δείχνει πώς να ευθυγραμμίσετε το κείμενο σε έναν πίνακα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργία ενός στιγμιότυπου της κλάσης Presentation.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορισμός πλάτους στηλών και ύψους γραμμών.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Προσθήκη σχήματος πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Στοίχιση κειμένου στο κέντρο και ορισμός κάθετης προσανατολισμού.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Αποθήκευση της παρουσίασης στον δίσκο.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός μορφοποίησης κειμένου στο επίπεδο πίνακα**

Αυτή η ενότητα δείχνει πώς να εφαρμόζετε μορφοποίηση κειμένου στο επίπεδο του πίνακα στο Aspose.Slides ώστε κάθε κελί να κληρονομεί ένα συνεπές, ενοποιημένο στυλ. Θα μάθετε να ορίζετε μεγέθη γραμματοσειράς, στοίχιση και περιθώρια παγκοσμίως.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά στη διαφάνεια κατά το δείκτη της.
3. Προσθέστε ένα [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια.
4. Ορίστε το μέγεθος γραμματοσειράς (ύψος γραμματοσειράς) για το κείμενο.
5. Ορίστε την στοίχιση παραγράφου και τα περιθώρια.
6. Ορίστε την κάθετη προσανατολισμό κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Python δείχνει πώς να εφαρμόσετε τις προτιμώμενες επιλογές μορφοποίησης στο κείμενο ενός πίνακα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Ορισμός του μεγέθους γραμματοσειράς για όλα τα κελιά του πίνακα.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Ορισμός κειμένου με στοίχιση δεξιά και δεξιό περιθώριο για όλα τα κελιά του πίνακα.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Ορισμός κάθετης προσανατολισμού κειμένου για όλα τα κελιά του πίνακα.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εφαρμογή ενσωματωμένων στυλ πινάκων**

Το Aspose.Slides σάς επιτρέπει να μορφοποιείτε πίνακες χρησιμοποιώντας προκαθορισμένα στυλ απευθείας στον κώδικα. Το παράδειγμα παρουσιάζει τη δημιουργία ενός πίνακα, την εφαρμογή ενσωματωμένου στυλ και την αποθήκευση του αποτελέσματος — έναν αποδοτικό τρόπο για να διασφαλίσετε συνεπή, επαγγελματική μορφοποίηση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλείδωμα αναλογίας διαστάσεων πινάκων**

Η αναλογία διαστάσεων ενός σχήματος είναι η αναλογία των διαστάσεών του. Το Aspose.Slides παρέχει την ιδιότητα `aspect_ratio_locked`, η οποία σας επιτρέπει να κλειδώσετε την αναλογία διαστάσεων για πίνακες και άλλα σχήματα.

Το παρακάτω παράδειγμα Python δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων για έναν πίνακα:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς τα αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει την ιδιότητα [right_to_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/right_to_left/) , και οι παράγραφοι έχουν την ιδιότητα [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/right_to_left/). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να εμποδίσω τους χρήστες να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε [shape locks](/slides/el/python-net/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή μιας εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού ανάλογα με τη επιλεγμένη λειτουργία (τέντωμα ή επανάληψη).