---
title: Διαχειριστείτε Γραμμές και Στήλες σε Πίνακες PowerPoint χρησιμοποιώντας Python
linktitle: Γραμμές και Στήλες
type: docs
weight: 20
url: /el/python-net/manage-rows-and-columns/
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
description: "Διαχειριστείτε γραμμές και στήλες πίνακα στο PowerPoint με το Aspose.Slides για Python μέσω .NET και επιταχύνετε την επεξεργασία παρουσιάσεων και την ενημέρωση δεδομένων."
---
## **Εισαγωγή**

Το Aspose.Slides for Python μέσω .NET σας επιτρέπει να διαχειρίζεστε τη δομή και τη μορφοποίηση των πινάκων σε παρουσιάσεις PowerPoint μέσω της κλάσης [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Μπορείτε να ορίσετε μια γραμμή κεφαλίδας, να αντιγράψετε ή να αφαιρέσετε γραμμές και στήλες, και να εφαρμόσετε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή ή στήλη.

Αυτό το άρθρο εξηγεί αυτές τις λειτουργίες με παραδείγματα Python. Επίσης δείχνει πώς να ανακτήσετε το προκαθορισμένο στυλ ενός πίνακα ώστε να το ξαναχρησιμοποιήσετε. Τα ευρετήρια των γραμμών και των στηλών του πίνακα αρχίζουν από το μηδέν.

## **Έλεγχος Ύψους Γραμμής**

Χρησιμοποιήστε το [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) για να ορίσετε το ελάχιστο ύψος μιας γραμμής σε πόντους. Είναι ένα κατώτερο όριο, όχι σταθερό ύψος. Το [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) επιστρέφει το πραγματικό ύψος και είναι μόνο για ανάγνωση. Πρόσβαση στη γραμμή μέσω του [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

Το παράδειγμα φορτώνει το [row-height-input.pptx](row-height-input.pptx), το οποίο έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη του γραμμή ξεκινά στα 70 πόντους. Τα κελιά χρησιμοποιούν κείμενο Arial 18‑πόντων, με αναδίπλωση και περιθώρια 6 πόντους πάνω και κάτω· το μεγαλύτερο κείμενο στη δεύτερη στήλη αναδιπλώνεται σε πολλές γραμμές. Το παράδειγμα αυξάνει το ελάχιστο σε 100 πόντους, κατόπιν το μειώνει σε 20 πόντους, εκτυπώνει το πραγματικό ύψος μετά από κάθε αλλαγή και αποθηκεύει και τα δύο αποτελέσματα.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Με την παρεχόμενη παρουσίαση, η αύξηση του ελάχιστου προσθέτει χώρο στη γραμμή. Η μείωσή του αφαιρεί αυτόν τον επιπλέον χώρο, αλλά το πραγματικό ύψος παραμένει μεγαλύτερο από 20 πόντους επειδή το κείμενο και τα περιθώρια των κελιών απαιτούν περισσότερο χώρο. Η μείωση του ελάχιστου μόνη της δεν μπορεί να πιέσει τη γραμμή κάτω από το χώρο που απαιτεί το περιεχόμενό της.

Πολλοί παράγοντες επηρεάζουν το πραγματικό ύψος:

- **Κείμενο και μέγεθος γραμματοσειράς:** το μεγαλύτερο κείμενο, ρητές αλλαγές γραμμής ή μεγαλύτερη γραμματοσειρά μπορούν να απαιτήσουν περισσότερο κάθετο χώρο.
- **Αναδίπλωση και πλάτος στήλης:** με αναδίπλωση ενεργοποιημένη, μια πιο στενή [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) μπορεί να δημιουργήσει περισσότερες γραμμές. Μία πιο πλατιά στήλη μπορεί να μειώσει τον απαιτούμενο κάθετο χώρο.
- **Περιθώρια κελιού:** τα [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) και [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) προσθέτουν κάθετο χώρο. Τα [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) και [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) μειώνουν το πλάτος διαθέσιμο για κείμενο και μπορούν να προκαλέσουν επιπλέον αναδίπλωση.

Για αυτόν τον πίνακα χωρίς συγχωνευμένα κελιά, το κελί που χρειάζεται τον περισσότερο κάθετο χώρο καθορίζει το όριο κατώτερου μεγέθους της γραμμής. Για να γίνει η γραμμή πιο σύντομη, ίσως χρειαστεί επίσης να συντομεύσετε το κείμενο, να μειώσετε το μέγεθος γραμματοσειράς ή τα περιθώρια, ή να διευρύνετε μια στήλη.

Οι εικόνες παρακάτω δείχνουν τον ίδιο πίνακα στην ίδια κλίμακα. Σε αυτήν την εκτέλεση, τα πραγματικά ύψη ήταν 70, 100 και 55,2 πόντοι: η τελική γραμμή παρέμεινε ψηλότερη από το ελάχιστο των 20 πόντων. Οι ακριβείς μετρήσεις κειμένου μπορούν να διαφέρουν ανάλογα με τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον σας. Κατεβάστε τα αποθηκευμένα αποτελέσματα: [αυξημένο ελάχιστο](row-height-increased.pptx) και [μειωμένο ελάχιστο](row-height-decreased.pptx).

| Αρχικό: ελάχιστο 70 pt, πραγματικό 70 pt | Αυξημένο: ελάχιστο 100 pt, πραγματικό 100 pt | Μειωμένο: ελάχιστο 20 pt, πραγματικό 55,2 pt |
| --- | --- | --- |
| ![Αρχικό πίνακα με πρώτη γραμμή 70 πόντων.](row-height-before.png) | ![Πίνακας μετά την αύξηση του ελάχιστου της πρώτης γραμμής σε 100 πόντους.](row-height-increased.png) | ![Πίνακας μετά τη μείωση του ελάχιστου της πρώτης γραμμής σε 20 πόντους· το αναδιπλωμένο κείμενο κρατά τη γραμμή ψηλότερη από το ελάχιστο.](row-height-decreased.png) |

## **Ορισμός της Πρώτης Γραμμής ως Κεφαλίδας**

Χρησιμοποιήστε την ιδιότητα [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) για να σημειώσετε την πρώτη γραμμή για μορφοποίηση κεφαλίδας. Η εμφάνισή της εξαρτάται από το στυλ πίνακα που έχει εφαρμοστεί.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Πρόσβαση στον πίνακα που είναι αποθηκευμένος ως το πρώτο σχήμα στη διαφάνεια.
4. Ενεργοποιήστε τη μορφοποίηση κεφαλίδας για την πρώτη του γραμμή.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ενεργοποιεί τη μορφοποίηση κεφαλίδας για την πρώτη γραμμή και αποθηκεύει το `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

Κλωνοποιήστε γραμμές ή στήλες για επαναχρησιμοποίηση του περιεχομένου και της μορφοποίησής τους. Μπορείτε να προσθέσετε ένα αντίγραφο στο τέλος του πίνακα ή να το εισάγετε σε συγκεκριμένη θέση.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
4. Προσθέστε έναν πίνακα με τη μέθοδο [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Κλωνοποιήστε τις απαιτούμενες γραμμές.
6. Κλωνοποιήστε τις απαιτούμενες στήλες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `Test.pptx` με τουλάχιστον μία διαφάνεια. Δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές, με διαστάσεις καθορισμένες σε πόντους. Προσθέτει αντίγραφα της πρώτης γραμμής και στήλης, έπειτα εισάγει αντίγραφα της δεύτερης γραμμής και στήλης στη θέση 3 (τη θέση τέταρτης). Ο τελικός πίνακας έχει επτά γραμμές και πέντε στήλες. Το όρισμα `False` απενεργοποιεί την κλωνοποίηση σε γειτονικά συγχωνευμένα κελιά· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Αφαίρεση Γραμμής ή Στήλης από Πίνακα**

Αφαιρέστε γραμμές ή στήλες που δεν χρειάζονται πλέον σε έναν πίνακα. Η αφαίρεση ενός στοιχείου μετατοπίζει τα ευρετήρια των γραμμών ή στηλών που ακολουθούν.

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
4. Προσθέστε έναν πίνακα με τη μέθοδο [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Αφαιρέστε τη δεύτερη γραμμή και τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα αυτό δημιουργεί έναν πίνακα 3 × 3 και αφαιρεί τη γραμμή και τη στήλη στη θέση 1, αφήνοντας έναν πίνακα 2 × 2 στο `TestTable_out.pptx`. Οι διαστάσεις είναι σε πόντους. Το όρισμα `False` απενεργοποιεί την αφαίρεση γειτονικών συγχωνευμένων γραμμών ή στηλών· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Γραμμής Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή για να διατηρήσετε ομοιόμορφα τα κελιά της. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και προσανατολισμό κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Ορίστε το [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) για την πρώτη γραμμή.
4. Ορίστε το [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) και το [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) για την πρώτη γραμμή.
5. Ορίστε το [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) για τη δεύτερη γραμμή.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο γραμμές. Εφαρμόζει κείμενο 25‑πόντων, δεξιά στοίχιση και δεξί περιθώριο παραγράφου 20 πόντων στην πρώτη γραμμή, στη συνέχεια ορίζει κάθετο κείμενο στη δεύτερη γραμμή.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Στήλης Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη στήλη για να διατηρήσετε ομοιόμορφα τα κελιά της. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και προσανατολισμό κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Ορίστε το [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) για την πρώτη στήλη.
4. Ορίστε το [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) και το [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) για την πρώτη στήλη.
5. Ορίστε το [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) για τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο στήλες. Εφαρμόζει κείμενο 25‑πόντων, δεξιά στοίχιση και δεξί περιθώριο παραγράφου 20 πόντων στην πρώτη στήλη, στη συνέχεια ορίζει κάθετο κείμενο στη δεύτερη στήλη.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε την ιδιότητα [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) για να ανακτήσετε το προεπιλεγμένο στυλ που έχει εφαρμοστεί σε έναν πίνακα και να το ξαναχρησιμοποιήσετε σε άλλον πίνακα. Αυτό προσδιορίζει το προεπιλεγμένο στυλ αντί για μεμονωμένες παραβιάσεις μορφοποίησης κελιού.

Το παράδειγμα δημιουργεί έναν πίνακα, εφαρμόζει το [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) και διαβάζει ξανά το προεπιλεγμένο στυλ. Εκτυπώνει `True` όταν το ανακτημένο στυλ ταιριάζει με το εφαρμοσμένο και αποθηκεύει τον πίνακα στο `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/πρωτεύοντος θέματος και μπορείτε ακόμη να υπερισχύσετε τις γεμίσεις, τα πλαίσια και τα χρώματα κειμένου πάνω από εκείνο το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, κατόπιν επανασυμπληρώστε τις γραμμές του πίνακα με τη νέα σειρά.

**Μπορώ να έχω ζώνες (striped) στήλες διατηρώντας προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις ζώνες στη στήλη, έπειτα παρακάμψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση επιπέδου κελιού έχει προτεραιότητα έναντι του στυλ πίνακα.