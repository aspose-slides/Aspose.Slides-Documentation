---
title: Διαχείριση Κελιών Πίνακα σε Παρουσιάσεις με Python
linktitle: Διαχείριση Κελιών
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
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε με ευκολία τα κελιά πίνακα σε PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET. Κατακτήστε την πρόσβαση, την τροποποίηση και τη μορφοποίηση κελιών γρήγορα για αδιάκοπη αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να έχετε πρόσβαση και να τροποποιείτε τα κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίσετε συγχωνευμένα κελιά πινάκων, να αφαιρέσετε τα σύνορα των κελιών, να εργαστείτε με την αρίθμηση κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάξετε το χρώμα φόντου ενός κελιού και να προσθέσετε μια εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να πάρετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων των κελιών και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

## **Αναγνώριση Συγχωνευμένων Κελιών Πίνακα**

Οι πίνακες συχνά περιέχουν συγχωνευμένα κελιά για κεφαλίδες ή για ομαδοποίηση σχετικών δεδομένων. Σε αυτήν την ενότητα, θα δείτε πώς να προσδιορίσετε αν ένα συγκεκριμένο κελί ανήκει σε μια συγχωνευμένη περιοχή και πώς να αναφερθείτε στο κύριο (πάνω‑αριστερό) κελί ώστε να διαβάζετε ή να μορφοποιείτε ολόκληρο το μπλοκ με συνέπεια.

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.  
1. Αποκτήστε τον πίνακα από την πρώτη διαφάνεια.  
1. Περιηγηθείτε στις γραμμές και στήλες του πίνακα για να βρείτε συγχωνευμένα κελιά.  
1. Εμφανίστε ένα μήνυμα όταν εντοπιστούν συγχωνευμένα κελιά.

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Υποθέτοντας ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Αφαίρεση Συνορίων Κελιών Πίνακα**

Μερικές φορές τα σύνορα των πινάκων αποσπούν την προσοχή από το περιεχόμενο ή δημιουργούν οπτικό χάος. Αυτή η ενότητα δείχνει πώς να αφαιρέσετε τα σύνορα από επιλεγμένα κελιά—ή συγκεκριμένες πλευρές ενός κελιού—ώστε να πετύχετε μια πιο καθαρή διάταξη και καλύτερη εναρμόνιση με το σχεδιασμό της διαφάνειάς σας.

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.  
1. Αποκτήστε τη διαφάνεια με βάση το δείκτη της.  
1. Ορίστε έναν πίνακα με τα πλάτη των στηλών.  
1. Ορίστε έναν πίνακα με τα ύψη των γραμμών.  
1. Προσθέστε έναν πίνακα στη διαφάνεια χρησιμοποιώντας τη μέθοδο [add_table](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_table/).  
1. Περιηγηθείτε σε κάθε κελί για να αφαιρέσετε τα σύνορα πάνω, κάτω, αριστερά και δεξιά.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```python
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορίστε στήλες με πλάτη και γραμμές με ύψη.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Προσθέστε ένα σχήμα πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Απαλείψτε τη γέμιση του περιγράμματος για κάθε κελί.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Αρίθμηση σε Συγχωνευμένα Κελιά**

Εάν συγχωνεύσετε δύο ζεύγη κελιών—π.χ., (1, 1) x (2, 1) και (1, 2) x (2, 2)—ο προκύπτων πίνακας θα διατηρήσει την ίδια αρίθμηση κελιών όπως ο πίνακας χωρίς συγχώνευση. Ο παρακάτω κώδικας Python δείχνει αυτή τη συμπεριφορά:

```python
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορίστε στήλες με πλάτη και γραμμές με ύψη.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Προσθέστε ένα σχήμα πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Συγχωνεύστε τα κελιά (1,1) και (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Συγχωνεύστε τα κελιά (1, 2) και (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Εκτυπώστε τους δείκτες των κελιών.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Έξοδος:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Αρίθμηση σε Διαχωρισμένα Κελιά**

Στο προηγούμενο παράδειγμα, όταν τα κελιά του πίνακα συγχωνεύθηκαν, η αρίθμηση στα άλλα κελιά δεν άλλαξε. Αυτή τη φορά, δημιουργούμε έναν κανονικό πίνακα (χωρίς συγχωνευμένα κελιά) και στη συνέχεια διαχωρίζουμε το κελί (1, 1) για να παραχθεί ένας ειδικός πίνακας. Δώστε προσοχή στην αρίθμηση αυτού του πίνακα—μπορεί να φαίνεται ασυνήθιστη. Ωστόσο, έτσι αρίθμηση τα κελιά το Microsoft PowerPoint, και το Aspose.Slides ακολουθεί την ίδια συμπεριφορά.

```python
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορίστε πλάτη στηλών και ύψη γραμμών.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Προσθέστε ένα σχήμα πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Διαχωρισμός του κελιού (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Εκτυπώστε τους δείκτες των κελιών.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Έξοδος:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Αλλαγή Χρώματος Φόντου Κελιάς Πίνακα**

Το παρακάτω παράδειγμα Python δείχνει πώς να αλλάξετε το χρώμα φόντου ενός κελιού πίνακα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Δημιουργήστε ένα νέο πίνακα.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Ορίστε το χρώμα φόντου για ένα κελί.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Εισαγωγή Εικόνων σε Κελιά Πίνακα**

Αυτή η ενότητα δείχνει πώς να εισάγετε μια εικόνα σε ένα κελί πίνακα στο Aspose.Slides. Καλύπτει την εφαρμογή γεμίσματος εικόνας στο επιλεγμένο κελί και τη ρύθμιση επιλογών εμφάνισης όπως η τένωση ή η επανάληψη.

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.  
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση το δείκτη της.  
1. Ορίστε έναν πίνακα με τα πλάτη των στηλών.  
1. Ορίστε έναν πίνακα με τα ύψη των γραμμών.  
1. Προσθέστε έναν πίνακα στη διαφάνεια με τη μέθοδο [add_table](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_table/).  
1. Φορτώστε την εικόνα από αρχείο.  
1. Προσθέστε την εικόνα στις εικόνες της παρουσίασης για να λάβετε ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/).  
1. Ορίστε το [FillType] του κελιού πίνακα σε `PICTURE`.  
1. Εφαρμόστε την εικόνα στο κελί πίνακα και επιλέξτε λειτουργία γεμίσματος (π.χ., `STRETCH`).  
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

```python
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο Presentation.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορίστε πλάτη στηλών και ύψη γραμμών.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Προσθέστε ένα σχήμα πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Φορτώστε την εικόνα και προσθέστε την στην παρουσίαση για να αποκτήσετε ένα PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Εφαρμόστε την εικόνα στο πρώτο κελί του πίνακα.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Αποθηκεύστε την παρουσίαση στον δίσκο.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για διαφορετικές πλευρές ενός ενιαίου κελιού;**

Ναι. Τα σύνορα [πάνω](https://reference.aspose.com/slides/el/python-net/aspose.slides/cellformat/border_top/)/[κάτω](https://reference.aspose.com/slides/el/python-net/aspose.slides/cellformat/border_bottom/)/[αριστερά](https://reference.aspose.com/slides/el/python-net/aspose.slides/cellformat/border_left/)/[δεξιά](https://reference.aspose.com/slides/el/python-net/aspose.slides/cellformat/border_right/) έχουν ξεχωριστές ιδιότητες, έτσι το πάχος και το στυλ κάθε πλευράς μπορούν να διαφέρουν. Αυτό ακολουθεί λογικά τον έλεγχο των σύνορων ανά πλευρά για ένα κελί, όπως παρουσιάστηκε στο άρθρο.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο κελιού;**

Η συμπεριφορά εξαρτάται από τη [λειτουργία γεμίσματος](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillmode/) (stretch/tile). Με την τένωση, η εικόνα προσαρμόζεται στο νέο κελί· με την επανάληψη, τα πλακάκια επαναϋπολογίζονται. Το άρθρο αναφέρει τις λειτουργίες εμφάνισης εικόνας σε κελί.

**Μπορώ να εκχωρήσω έναν σύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Τα [Hyperlinks](/slides/el/python-net/manage-hyperlinks/) ορίζονται στο επίπεδο του κειμένου (τμήματος) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, εκχωρείτε το σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) (τμήματα) με ανεξάρτητη μορφοποίηση — οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.