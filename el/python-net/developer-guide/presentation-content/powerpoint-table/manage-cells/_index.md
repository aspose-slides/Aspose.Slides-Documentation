---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις με Python
linktitle: Διαχείριση κελιών
type: docs
weight: 30
url: /el/python-net/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαχωρισμός κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχείριση κελιών πίνακα PowerPoint σε Python: αναγνώριση συγχωνευμένων κελιών, αφαίρεση περιγραμμάτων, διαχωρισμός κελιών και ορισμός χρωμάτων φόντου και εικόνων με Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να αποκτάτε πρόσβαση και να τροποποιείτε κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να αναγνωρίσετε συγχωνευμένα κελιά πινάκων, να αφαιρέσετε τα πλαίσια των κελιών, να εργαστείτε με την αρίθμηση κελιών μετά τη συγχώνευση ή το διαχωρισμό των κελιών, να αλλάξετε το χρώμα φόντου ενός κελιού και να προσθέσετε εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες αρχής 0. Οι συντεταγμένες σε αυτό το άρθρο γράφονται ως `(column, row)`.

## **Αναγνώριση Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια, διασχίζει όλες τις γραμμές και στήλες και χρησιμοποιεί [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με σειρά `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), και τις αρχικές συντεταγμένες της περιοχής, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) και [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Αφαίρεση Περιγραμμάτων Κελιού Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και προσθέστε ένα πίνακα στην πρώτη του διαφάνεια με [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Το πλάτος των στηλών, το ύψος των γραμμών και η θέση του πίνακα ορίζονται σε μονάδες point. Το παράδειγμα θέτει όλα τα τέσσερα περιγράμματα κελιού σε [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), κάνοντάς τα αόρατα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε το [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) για να συνδυάσετε μια ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην επάνω αριστερή και κάτω δεξιά γωνία της περιοχής. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός της δηλωμένης περιοχής· `False` διατηρεί τη συγχώνευση εντός της περιοχής.

Το παράδειγμα δημιουργεί ένα πίνακα 4×4 με στήλες και γραμμές 70 point, και στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από `(1, 1)` έως `(2, 2)`. Το αποτέλεσμα είναι ένα κελί που εκτείνεται σε δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα διατηρεί τέσσερις στήλες και τέσσερις γραμμές. Για να προσπελάσετε το περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του επάνω αριστερά: `table.rows[1][1]` σε αυτό το παράδειγμα. Οι άλλες θέσεις στην συγχωνευμένη περιοχή παραμένουν μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κελιών εκτός της περιοχής δεν αλλάζουν.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαίρεση Κελιών Πίνακα**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Ο διαχωρισμός ενός κελιού μπορεί να εισάγει μια νέα στήλη στο πλέγμα και να αλλάξει τους δείκτες των στηλών των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4×4 με στήλες και γραμμές 70 point και καλεί το [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) στο κελί `(1, 1)`. Το μισό του πλάτους 70 point του κελιού περνιέται για να δημιουργηθούν δύο κελιά ίσου πλάτους.

Μετά από αυτόν τον διαχωρισμό, τα δύο μισά προσπελάζονται ως `table.rows[1][1]` και `table.rows[1][2]`. Το πλέγμα του πίνακα έχει τώρα πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μετατοπίζονται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες των γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στηλών όταν προσπελάζετε κελιά μετά τον διαχωρισμό.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Διαίρεση Συγχωνευμένων Κελιών κατά Γραμμή ή Στήλη**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για πληθυσμό δεδομένων, χρησιμοποιήστε το [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) για διαχωρισμό κατά υπάρχουσα γραμμή, ή το [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) για διαχωρισμό κατά στήλη.

Το όρισμα `index` μετρά τις γραμμές στο ανώτερο μέρος ή τις στήλες στο αριστερό μέρος του διαχωρισμού· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Διαχωρισμός γραμμής: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Διαχωρισμός στήλης: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Το παράδειγμα υποθέτει ότι μια παρουσίαση έχει πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα κελιά `(1, 2)` και `(1, 3)` να είναι συγχωνευμένα κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί το [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) και το [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) για τον εντοπισμό της αρχής και ελέγχει και τις δύο εκτάσεις. Το `split_by_row_span` με δείκτη 1 διαχωρίζει τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε το `split_by_col_span` με δείκτη 1.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Ανάκτηση των προκύπτοντων κελιών από τον πίνακα μετά το διαχωρισμό.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Το πλέγμα του πίνακα και οι γύρω δείκτες κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν εκτάσεις 1 και το [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) επιστρέφει `False`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν μερικώς συγχωνευμένες μετά από ένα διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά τον διαχωρισμό και ορίστε ρητά τυχόν απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά "Product A" και "Product B" με τη μορφοποίηση του προτύπου στα κελιά διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) για λεπτομέρειες.

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 point και γραμμές 50 point. Ορίζει το [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε solid και το [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη γραμμή.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

Τοποθετήστε την είσοδο εικόνας στον τρέχοντα φάκελο πριν τρέξετε αυτό το παράδειγμα. Φορτώνει την εικόνα με [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Στη συνέχεια αντιστοιχίζει την εικόνα στη γεμίσματα εικόνας του κελιού `(0, 0)`, του πρώτου κελιού του πίνακα.

Το [PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεων. Το πλάτος των στηλών και το ύψος των γραμμών είναι σε μονάδες point. Η φορτωμένη εικόνα διακόπτεται αυτόματα όταν το μπλοκ `with` τερματίζει.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη γραμμής και στυλ για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορεί να διαφέρει.

**Τι συμβαίνει με την εικόνα εάν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντου κελιού;**

Η συμπεριφορά εξαρτάται από το [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη (tiling), τα πλακίδια υπολογίζονται εκ νέου.

**Μπορώ να αντιστοιχίσω έναν υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Τα [Hyperlinks](/slides/el/python-net/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αντιστοιχίζετε το σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.