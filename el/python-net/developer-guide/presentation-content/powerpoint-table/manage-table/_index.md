---
title: Διαχείριση Πινάκων Παρουσίασης με Python
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/python-net/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση σε πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε & επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint και OpenDocument με Aspose.Slides για Python μέσω .NET. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιστοποιήσετε τις εργασίες σας με πίνακες."
---
## **Εισαγωγή**

Οι πίνακες στο PowerPoint οργανώνουν τις πληροφορίες σε σειρές και στήλες, διευκολύνοντας την ανάγνωση και τη σύγκριση των τιμών.

Το Aspose.Slides παρέχει τις κλάσεις [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) και [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) καθώς και άλλους τύπους ώστε να μπορείτε να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε παρουσιάσεις.

## **Δημιουργία Πίνακα από το Μηδέν**

Δημιουργήστε έναν πίνακα ορίζοντας τη θέση του, το πλάτος των στηλών και το ύψος των σειρών. Μετά την προσθήκη του σε μια διαφάνεια, μπορείτε να μορφοποιήσετε τα σύνορα των κελιών, να συγχωνεύσετε κελιά και να εισάγετε κείμενο.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Ορίστε μια λίστα με τα πλάτη των στηλών σε πόντους.
4. Ορίστε μια λίστα με τα ύψη των σειρών σε πόντους.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) στη διαφάνεια μέσω της μεθόδου [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Επανάληψη σε κάθε [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) για την εφαρμογή μορφοποίησης στα πάνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τα πρώτα δύο κελιά της πρώτης σειράς του πίνακα.
8. Προσπελάστε το συγχωνευμένο κελί μέσω της ιδιότητας [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Ορίστε το κείμενο στο συγχωνευμένο κελί.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα με τρεις στήλες και πέντε σειρές στο (100, 50) πόντους. Εφαρμόζει κόκκινα σύνορα με πάχος 5 πόντους, συγχωνεύει τα πρώτα δύο κελιά στην πρώτη σειρά και αποθηκεύει το αποτέλεσμα ως `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, οι δείκτες των κελιών είναι μηδενικοί και ακολουθούν τη σειρά (στήλη, σειρά). Το πρώτο κελί έχει δείκτη (0, 0). Σε Python, προσπελάζετε ένα κελί με `table.rows[row_index][column_index]`; ο δείκτης σειράς εμφανίζεται πρώτος σε αυτήν την έκφραση.

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτό το παράδειγμα δημιουργεί τον πίνακα 4 × 4 που απεικονίζεται παραπάνω, με πλάτη στηλών και ύψη σειρών 70 πόντων και κόκκινα σύνορα κελιών πλάτους 5 πόντων. Οι συντεταγμένες απεικονίζουν τους δείκτες των κελιών· το παράδειγμα αφήνει τα κελιά κενά και αποθηκεύει τον πίνακα ως `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

Οι πίνακες αποθηκεύονται στη συλλογή σχήματος μιας διαφάνειας. Επαναλάβετε μέσω των σχημάτων για να εντοπίσετε έναν πίνακα, στη συνέχεια χρησιμοποιήστε την κλάση [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) για να διαβάσετε ή να ενημερώσετε τα κελιά του.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα με βάση το δείκτη της.
3. Επαναλάβετε μέσω των αντικειμένων [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) και σταματήστε όταν βρεθεί ένας πίνακας. Εάν η διαφάνεια περιέχει πολλούς πίνακες, χρησιμοποιήστε το [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) για να εντοπίσετε αυτόν που χρειάζεστε.
4. Ενημερώστε το κείμενο στο στοχευόμενο κελί.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `UpdateExistingTable.pptx` και βρίσκει τον πρώτο πίνακα στην πρώτη διαφάνεια. Ορίζει το κελί στη στήλη 0, σειρά 1 σε `New` και αποθηκεύει το αποτέλεσμα ως `table1_out.pptx`. Η είσοδος πρέπει να περιέχει τουλάχιστον μία διαφάνεια, και ο πρώτος πίνακας σε αυτήν πρέπει να έχει τουλάχιστον μία στήλη και δύο σειρές.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Για να αλλάξετε το μέγεθος μιας σειράς σε υπάρχοντα πίνακα και να καταλάβετε γιατί το πραγματικό του ύψος μπορεί να υπερβαίνει το ελάχιστο που ζητήθηκε, δείτε [Έλεγχος Ύψους Σειράς](/slides/el/python-net/manage-rows-and-columns/#control-row-height).

## **Βρείτε το Κελί που Κατέχει ένα Text Frame**

Όταν ο γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) από έναν πίνακα, χρησιμοποιήστε την ιδιότητα [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) για να ανακτήσετε το ιδιοκτήτη [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Για ένα πλαίσιο κειμένου κελιού-πίνακα, το [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) είναι ορισμένο και το [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) είναι `None`, παρόλο που ο ίδιος ο πίνακας είναι σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο-ανάγνωσης ιδιοτήτων [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) και [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). Το [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) είναι επίσης μόνο-ανάγνωσης: παρέχει πλοήγηση στον ιδιοκτήτη αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε το επιστρεφόμενο κελί για `None` πριν το χρησιμοποιήσετε.

Για μια πλήρη παράδειγμα που εντοπίζει ιδιοκτήτες κελιών-πίνακα και σχήματος, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/python-net/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

Μπορείτε να ελέγξετε την κατακόρυφη αγκύρωση και την κατεύθυνση του κειμένου των μεμονωμένων κελιών πίνακα. Το παράδειγμα σε αυτήν την ενότητα κεντράρει το κείμενο στο πρώτο κελί και το περιστρέφει κατά 270 μοίρες.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) στη διαφάνεια.
4. Προσπελάστε ένα αντικείμενο [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) από τον πίνακα.
5. Προσπελάστε το πρώτο [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) και ορίστε το κείμενο και το χρώμα του.
6. Ορίστε τις ιδιότητες [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) και [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) του κελιού.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με πλάτη στηλών 120 πόντων και ύψη σειρών 100 πόντων. Μορφοποιεί το κείμενο στο κελί (0, 0), προσθέτει τιμές στα υπόλοιπα κελιά της πρώτης σειράς και αποθηκεύει το αποτέλεσμα ως `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

Χρησιμοποιήστε τη μέθοδο [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) για να εφαρμόσετε μορφοποίηση κειμένου σε όλα τα κελιά ενός πίνακα. Οι υπερφορτώσεις της δέχονται μορφοποίηση τμήματος, παραγράφου και πλαισίου κειμένου, ώστε να μπορείτε να ορίσετε αυτές τις ιδιότητες χωρίς να επαναλάβετε κάθε κελί.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Προσπελάστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) από τη διαφάνεια.
4. Ορίστε το [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) για το κείμενο.
5. Ορίστε τα [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) και [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Ορίστε το [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `table.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με έναν πίνακα ως πρώτο σχήμα. Ορίζει το μέγεθος γραμματοσειράς σε 25 πόντους, ευθυγραμμίζει τις παραγράφους δεξιά με δεξιό περιθώριο 20 πόντων και κάνει το κείμενο κατακόρυφο. Η μορφοποιημένη παρουσίαση αποθηκεύεται ως `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε το [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) για να διαβάσετε ή να ορίσετε το προεπιλεγμένο στυλ ενός πίνακα. Αυτό το παράδειγμα εφαρμόζει το [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) σε έναν πίνακα, εκτυπώνει το όνομα του προεπιλεγμένου στυλ και το αναθέτει σε δεύτερο πίνακα. Και οι δύο πίνακες αποθηκεύονται στο `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός πίνακα είναι ο λόγος του πλάτους προς το ύψος του. Χρησιμοποιήστε το [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) για να κλειδώσετε αυτήν την αναλογία για έναν πίνακα.

Το παρακάτω παράδειγμα ανοίγει το `pres.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με έναν πίνακα ως πρώτο σχήμα. Εκτυπώνει την τρέχουσα κατάσταση κλειδώματος, ενεργοποιεί το κλείδωμα της αναλογίας διαστάσεων, εκτυπώνει την ενημερωμένη κατάσταση (`True`) και αποθηκεύει το αποτέλεσμα ως `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς τα αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει την ιδιότητα [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), και οι παράγραφοι έχουν την ιδιότητα [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από τη μετακίνηση ή την αλλαγή μεγέθους ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [shape locks](/slides/el/python-net/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κλπ. Αυτά τα κλειδώματα ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή μιας εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού ανάλογα με την επιλεγμένη λειτουργία (εκτατική ή επικάλυψη).