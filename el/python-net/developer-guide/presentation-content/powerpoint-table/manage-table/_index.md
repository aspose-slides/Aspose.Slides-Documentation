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
- ευθυγράμμιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργία & επεξεργασία πινάκων σε διαφάνειες PowerPoint και OpenDocument με Aspose.Slides για Python μέσω .NET. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιώσετε τις ροές εργασίας των πινάκων σας."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος παρουσίασης πληροφοριών. Πληροφορίες που είναι διατεταγμένες σε πλέγμα κελιών (γραμμές και στήλες) είναι απλές και εύκολα κατανοητές.

Η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) , την κλάση [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) , και άλλους σχετικούς τύπους για να σας βοηθήσει να δημιουργήσετε, να ενημερώσετε και να διαχειριστείτε πίνακες σε οποιαδήποτε παρουσίαση.

## **Δημιουργία Πινάκων από την Αρχή**

Αυτή η ενότητα δείχνει πώς να δημιουργήσετε έναν πίνακα από την αρχή στην Aspose.Slides προσθέτοντας ένα σχήμα πίνακα σε μια διαφάνεια, ορίζοντας τις γραμμές και τις στήλες του και ορίζοντας ακριβείς διαστάσεις. Θα δείτε επίσης πώς να γεμίσετε κελιά με κείμενο, να προσαρμόσετε την ευθυγράμμιση και τα περιθώρια, και να προσαρμόσετε την εμφάνιση του πίνακα.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Ορίστε έναν πίνακα με το πλάτος των στηλών.
4. Ορίστε έναν πίνακα με το ύψος των γραμμών.
5. Προσθέστε έναν [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια.
6. Επεξεργαστείτε κάθε [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) και μορφοποιήστε τα άνω, κάτω, δεξιά και αριστερά όρια.
7. Συνένωστε τα πρώτα δύο κελιά στην πρώτη γραμμή του πίνακα.
8. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) ενός [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) .
9. Προσθήκη κειμένου στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) .
10. Αποθήκευση της τροποποιημένης παρουσίασης.

Το παρακάτω παράδειγμα Python δείχνει πώς να δημιουργήσετε έναν πίνακα σε μια παρουσίαση:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Προσθέστε ένα σχήμα πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Ορίστε τη μορφή περιγράμματος για κάθε κελί.
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

    # Προσθέστε κείμενο στο συγχωνευμένο κελί.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Αρίθμηση σε Τυπικούς Πίνακες**

Σε έναν τυπικό πίνακα, η αρίθμηση των κελιών είναι απλή και αρχίζει από το μηδέν. Το πρώτο κελί σε έναν πίνακα έχει δείκτη (0, 0) (στήλη 0, γραμμή 0).

Για παράδειγμα, σε έναν πίνακα με 4 στήλες και 4 γραμμές, τα κελιά αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Το παρακάτω παράδειγμα Python δείχνει πώς να αναφέρεστε σε κελιά χρησιμοποιώντας αυτήν την αρίθμηση που ξεκινά από το μηδέν:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

Αυτή η ενότητα εξηγεί πώς να εντοπίσετε και να εργαστείτε με έναν υπάρχοντα πίνακα σε μια παρουσίαση χρησιμοποιώντας την Aspose.Slides. Θα μάθετε πώς να βρείτε τον πίνακα σε μια διαφάνεια, να έχετε πρόσβαση στις γραμμές, στήλες και κελιά του, και να ενημερώσετε το περιεχόμενο ή τη μορφοποίηση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Αποκτήστε αναφορά στη διαφάνεια που περιέχει τον πίνακα με βάση το δείκτη της.
3. Διατρέξτε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) μέχρι να βρείτε τον πίνακα.
4. Χρησιμοποιήστε το αντικείμενο [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) για να εργαστείτε με τον πίνακα.
5. Αποθήκευση της τροποποιημένης παρουσίασης.

{{% alert color="info" %}}
Εάν η διαφάνεια περιέχει πολλούς πίνακες, είναι καλύτερο να αναζητήσετε τον πίνακα που χρειάζεστε με βάση την ιδιότητα `alternative_text` .
{{% /alert %}}

Το παρακάτω παράδειγμα Python δείχνει πώς να προσπελάσετε και να εργαστείτε με έναν υπάρχοντα πίνακα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για τη φόρτωση αρχείου PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    table = None

    # Διατρέξτε τα σχήματα και αναφερθείτε στον πρώτο πίνακα που βρέθηκε.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Ορίστε το κείμενο του πρώτου κελιού στην πρώτη γραμμή.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Στοίχιση Κειμένου σε Πίνακες**

Αυτή η ενότητα δείχνει πώς να ελέγξετε την ευθυγράμμιση του κειμένου μέσα στα κελιά του πίνακα χρησιμοποιώντας την Aspose.Slides. Θα μάθετε να ορίσετε οριζόντια και κάθετη ευθυγράμμιση για τα κελιά ώστε το περιεχόμενό σας να είναι σαφές και συνεπές.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Αποκτήστε αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια.
4. Πρόσβαση σε ένα αντικείμενο [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) από τον πίνακα.
5. Ευθυγράμμιση του κειμένου κάθετα.
6. Αποθήκευση της τροποποιημένης παρουσίασης.

Το παρακάτω παράδειγμα Python δείχνει πώς να ευθυγραμμίσετε το κείμενο σε έναν πίνακα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργία ενός αντικειμένου της κλάσης Presentation.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορισμός πλάτων των στηλών και υψών των γραμμών.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Προσθήκη σχήματος πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Στοίχιση του κειμένου στο κέντρο και ορισμός κάθετης προσανατολισμού.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Αποθήκευση της παρουσίασης στο δίσκο.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

Αυτή η ενότητα δείχνει πώς να εφαρμόσετε μορφοποίηση κειμένου σε επίπεδο πίνακα στην Aspose.Slides ώστε κάθε κελί να κληρονομεί ένα συνεπές, ενιαίο στυλ. Θα μάθετε να ορίσετε μεγέθη γραμματοσειράς, ευθυγραμμίσεις και περιθώρια παγκοσμίως.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Αποκτήστε αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια.
4. Ορίστε το μέγεθος γραμματοσειράς (υψος γραμματοσειράς) για το κείμενο.
5. Ορίστε την ευθυγράμμιση παραγράφου και τα περιθώρια.
6. Ορίστε την κάθετη προσανατολισμό κειμένου.
7. Αποθήκευση της τροποποιημένης παρουσίασης.

Το παρακάτω παράδειγμα Python δείχνει πώς να εφαρμόσετε τις προτιμώμενες επιλογές μορφοποίησης στο κείμενο ενός πίνακα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο της κλάσης Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Ορίστε το μέγεθος γραμματοσειράς για όλα τα κελιά του πίνακα.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Ορίστε κείμενο δεξιά-στηιχισμένο και δεξιό περιθώριο για όλα τα κελιά του πίνακα.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Ορίστε την κάθετη προσανατολισμό κειμένου για όλα τα κελιά του πίνακα.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εφαρμογή Προκαθορισμένων Στυλ Πίνακα**

Η Aspose.Slides σας επιτρέπει να μορφοποιήσετε πίνακες χρησιμοποιώντας προορισμένα στυλ απευθείας στον κώδικα. Το παράδειγμα δείχνει τη δημιουργία ενός πίνακα, την εφαρμογή ενός ενσωματωμένου στυλ και την αποθήκευση του αποτελέσματος — έναν αποδοτικό τρόπο να διασφαλίσετε συνεπή, επαγγελματική μορφοποίηση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πινάκων**

Η αναλογία διαστάσεων ενός σχήματος είναι ο λόγος των διαστάσεών του. Η Aspose.Slides παρέχει την ιδιότητα `aspect_ratio_locked`, η οποία σας επιτρέπει να κλειδώσετε την αναλογία διαστάσεων για πίνακες και άλλα σχήματα.

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

## **FAQ**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει την ιδιότητα [right_to_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/right_to_left/) και οι παράγραφοι έχουν την ιδιότητα [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/right_to_left/). Χρησιμοποιώντας και τις δύο εξασφαλίζετε τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από τη μετακίνηση ή την αλλαγή μεγέθους ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [shape locks](/slides/el/python-net/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε ένα [picture fill](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού ανάλογα με την επιλεγμένη λειτουργία (τραντάρισμα ή επικάλυψη).