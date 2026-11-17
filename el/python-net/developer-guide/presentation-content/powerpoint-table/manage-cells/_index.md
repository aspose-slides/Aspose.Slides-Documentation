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
- διάσπαση κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τα κελιά πίνακα του PowerPoint σε Python: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, χωρίστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να έχετε πρόσβαση και να τροποποιείτε κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πινάκων, να αφαιρείτε τα περιγράμματα των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή τον διαχωρισμό των κελιών, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να αποκτήσετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες μηδενικής βάσης. Οι συντεταγμένες σε αυτό το άρθρο γράφονται ως `(column, row)`.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και αποκτά πρόσβαση στο πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια διασχίζει όλες τις σειρές και στήλες και χρησιμοποιεί [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) για να εντοπίσει τα κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με σειρά `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), και τις αρχικές συντεταγμένες της περιοχής, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/), και [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

## **Αφαίρεση Περιγραμμάτων Κελιών Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με την [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Τα πλάτη των στηλών, τα ύψη των σειρών και η θέση του πίνακα καθορίζονται σε points. Το παράδειγμα θέτει όλα τα τέσσερα περιγράμματα του κελιού σε [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

## **Προσθήκη Διαγώνιων Περιγραμμάτων Κελιού**

Χρησιμοποιήστε [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) για να σχεδιάσετε μια γραμμή από την επάνω αριστερή γωνία προς την κάτω δεξιά, και [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) για να σχεδιάσετε μια γραμμή από την κάτω αριστερή γωνία προς την επάνω δεξιά. Μία διαγώνιος μπορεί να σηματοδοτήσει μια επικεφαλίδα γωνίας· και οι δύο διαγώνιοι μπορούν να σχηματίσουν ένα X για να σηματοδοτήσουν ότι το κελί δεν είναι εφαρμόσιμο.

Κάθε διαγώνιος είναι ένα [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). Στο [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) του, ορίστε το [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) και επιλέξτε ένα [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Ορίστε το [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) της γραμμής σε points.

Το παράδειγμα δημιουργεί τρία κελιά σε μία σειρά: μια κόκκινη διαγώνιο κάτω, μια μπλε διαγώνιο πάνω, και και τις δύο διαγώνιους. Διατηρεί αμετάβλητα τα περιγράμματα του κελιού πάνω, κάτω, αριστερά και δεξιά.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Μια διαγώνιος είναι ιδιότητα μορφοποίησης, όχι διαχωρισμός κελιού. Κάθε κελί διατηρεί ένα μόνο [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); οι περιοχές σε κάθε πλευρά μιας διαγώνιου δεν μπορούν να επεξεργαστούν ανεξάρτητα.

Ο αποθηκευμένος πίνακας, αποτυπωμένος στο Microsoft PowerPoint:

![Τρία κελιά πίνακα που δείχνουν μια κόκκινη διαγώνιο από την πάνω αριστερή προς την κάτω δεξιά, μια μπλε διαγώνιο από την κάτω αριστερή προς την πάνω δεξιά, και και τις δύο διαγώνιους σχηματίζοντας ένα X.](diagonal-cell-borders.png)

*Από αριστερά προς δεξιά: διαγώνιος προς τα κάτω (κόκκινο, 3 pt), διαγώνιος προς τα πάνω (μπλέ, 5 pt), και και οι δύο διαγώνιοι.*

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) για να συνδυάσετε μία ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην επάνω αριστερή και κάτω δεξιά γωνία της περιοχής. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός της καθορισμένης περιοχής· η τιμή `False` διατηρεί τη συγχώνευση εντός αυτής της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και σειρές 70 points, και στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` έως το `(2, 2)`. Το αποτέλεσμα είναι ένα κελί που εκτείνεται σε δύο στήλες και δύο σειρές, ενώ το υποκείμενο πλέγμα του πίνακα διατηρεί τέσσερις στήλες και τέσσερις σειρές. Για πρόσβαση στο περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του επάνω αριστερά: `table.rows[1][1]` σε αυτό το παράδειγμα. Οι άλλες θέσεις στην συγχωνευμένη περιοχή παραμένουν μέρος του πλέγματος πίνακα, έτσι οι δείκτες των κελιών εκτός της περιοχής δεν αλλάζουν.

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

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Ο διαχωρισμός ενός κελιού μπορεί να εισάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και σειρές 70 points και καλεί την [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) στο κελί `(1, 1)`. Το ήμισυ του πλάτους του κελιού 70 points περνιέται για να δημιουργηθούν δύο κελιά ίσου πλάτους.

Μετά αυτόν τον διαχωρισμό, οι δύο μισές προσεγγίνονται ως `table.rows[1][1]` και `table.rows[1][2]`. Το πλέγμα του πίνακα τώρα έχει πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες σειρών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσεγγίζετε κελιά μετά τον διαχωρισμό.

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

[![Ένα μη συγχωνευμένο κελί 70 points χωρίζεται σε δύο κελιά 35 points, προσθέτοντας μια πέμπτη στήλη πλέγματος και μετακινώντας τους δείκτες δεξιά του.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Η διάσπαση πλάτους επηρεάζει το κελί (1, 1), χρησιμοποιώντας δείκτες μηδενικής βάσης (στήλη, σειρά). Οι άλλες σειρές διατηρούν ένα κελί που εκτείνεται και στις δύο νέες θέσεις στήλης.*

### **Διαχωρισμός Συγχωνευμένων Κελιών κατά Υπόθεση Γραμμής ή Στήλης**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για την πληρότητα δεδομένων, χρησιμοποιήστε [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) για να χωρίσετε κατά μήκος υπάρχουσας ορίου γραμμής, ή [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) για να χωρίσετε κατά μήκος ορίου στήλης.

Το όρισμα `index` μετράει τις σειρές στο άνω μέρος ή τις στήλες στο αριστερό μέρος του διαχωρισμού· είναι σχετικό με την συγχωνευμένη περιοχή:

- Διαχωρισμός γραμμής: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Διαχωρισμός στήλης: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Το παράδειγμα υποθέτει ότι μια παρουσίαση έχει έναν πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί το [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) και το [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) για να εντοπίσει την αρχή και ελέγχει και τις δύο εκτάσεις. Το `split_by_row_span` με δείκτη 1 χωρίζει τότε τις σειρές 2 και 3 για ονόματα προϊόντων. Για οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε `split_by_col_span` με δείκτη 1 αντί.

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

            # Ανάκτηση των προκύπτων κελιών από τον πίνακα μετά τον διαχωρισμό.
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

Το πλέγμα του πίνακα και οι γύρω δείκτες κελιών παραμένουν αμετάβλητα. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν εκτάσεις 1 και το [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) εμφανίζει `False`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από έναν διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά τον διαχωρισμό και ορίστε ρητά οποιαδήποτε απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά "Product A" και "Product B" με τη μορφοποίηση κελιού του προτύπου διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) για λεπτομέρειες.

### **Διαχωρισμός Κελιού σε Συγκεκριμένο Ύψος**

Το [split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) λαμβάνει το ύψος του άνω μέρους σε points. Το [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) λαμβάνει τον αριθμό των υπαρχόντων πλέγματος σειρών στο άνω μέρος. Για να κεντράρετε ένα κελί 40 points κάθετα στη δεξιά στήλη, αφαιρέστε 40 από το πραγματικό ύψος του κελιού και διαιρέστε το υπόλοιπο χώρο εξίσου επάνω και κάτω.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

Ο πρώτος διαχωρισμός προσθέτει μια σειρά πλέγματος, αφήνοντας τα κάτω 90 points στο `table.rows[1][1]`. Ο δεύτερος διαχωρισμός διαιρεί αυτό το κελί σε ένα κεντρικό κελί 40 points και ένα κάτω κελί 50 points. Τα τρία κελιά στη δεξιά στήλη είναι τώρα 50, 40 και 50 points υψηλά από πάνω προς τα κάτω. Το αριστερό κελί εκτείνεται σε όλες τις τρεις σειρές με το αρχικό του ύψος των 140 points.

![Το αριστερό κελί εκτείνεται σε όλο το ύψος του πίνακα δίπλα σε τρία κελιά με το Middle στο κέντρο.](split-by-height.png)

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 points και σειρές 50 points. Θέτει το [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε στερεό και το [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη σειρά.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

Τοποθετήστε την εικόνα εισόδου στον φάκελο εργασίας πριν εκτελέσετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Στη συνέχεια αναθέτει την εικόνα στο picture fill του κελιού `(0, 0)`, το πρώτο κελί στον πίνακα.

Το [PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεών του. Τα πλάτη των στηλών και τα ύψη των σειρών είναι σε points. Η φορτωμένη εικόνα απελευθερώνεται αυτόματα όταν λήξει το μπλοκ `with`.

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

**Μπορώ να ορίσω διαφορετικά πάχη γραμμής και στυλ για τις διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορούν να διαφέρουν.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από το [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επαναλάβη, τα tiles υπολογίζονται ξανά.

**Μπορώ να αναθέσω έναν υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Τα [Hyperlinks](/slides/el/python-net/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αναθέτετε τον σύνδεσμο σε μια περιοχή ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναί. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση — οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.