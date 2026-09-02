---
title: Διαχείριση Σχημάτων Παρουσίασης σε Python
linktitle: Διαχείριση Σχήματος
type: docs
weight: 40
url: /el/python-net/shape-manipulations/
keywords:
- σχήμα PowerPoint
- σχήμα παρουσίασης
- σχήμα σε διαφάνεια
- εντοπισμός σχήματος
- κλωνοποίηση σχήματος
- αφαίρεση σχήματος
- απόκρυψη σχήματος
- αλλαγή σειράς σχήματος
- λήψη interop ID σχήματος
- εναλλακτικό κείμενο σχήματος
- σημείο ρύθμισης σχήματος
- προεπιλεγμένη ρύθμιση σχήματος
- γεωμετρία σχήματος
- μορφές διάταξης σχήματος
- σχήμα ως SVG
- σχήμα σε SVG
- στοίχιση σχήματος
- αναστροφή σχήματος
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να εντοπίζετε, προσαρμόζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αναδιατάσσετε, εξάγετε, στοιχίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Aspose.Slides for Python via .NET αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια τακτοποιημένη [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/). Η συλλογή είναι τόσο το σημείο όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς στοίβας: ο δείκτης `0` είναι το πιο πίσω σχήμα, ενώ ο τελευταίος δείκτης είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να αναγνωρίζετε ένα σχήμα αξιόπιστα και να τροποποιείτε προεπιλεγμένα σημεία ρύθμισης σχήματος, στη συνέχεια δείχνει πώς να κλωνοποιείτε, διαγράφετε, κρύβετε και αναδιατάσσετε σχήματα. Τα τελικά τμήματα καλύπτουν μορφοποίηση επιπέδου διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτεί η ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Οι δείκτες της συλλογής είναι βολικοί κατά την επεξεργασία ενός γνωστού αρχείου, αλλά δεν αποτελούν σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η αναδιάταξη ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς δημιουργείται και διατηρείται η παρουσίαση:

- [Shape.name](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/name/) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να το ελέγξετε στον Πίνακα Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυώνται μοναδικότητα, γι’ αυτό ορίστε έναν κανόνα ονοματοδοσίας εάν ο κώδικας εξαρτάται από αυτά.
- [Shape.alternative_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/alternative_text/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που έχει προσθέσει ο δημιουργός ήδη αναγνωρίζει το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφεί για προσβασιμότητα, και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιείτε σιωπηλά το νόημα του κειμένου προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/office_interop_shape_id/) είναι ένα μόνο‑ανάγνωση αναγνωριστικό που είναι μοναδικό μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια σαφή αναφορά κατά τη διάρκεια της ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική ιδιότητα [Shape.unique_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/unique_id/) έχει εμβέλεια παρουσίασης, αλλά προορίζεται για add‑ins και μπορεί να επαναδοθεί. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Εάν η μακροπρόθεσμη ταυτότητα είναι ζωτικής σημασίας, διατηρήστε την αντιστοίχηση σε δεδομένα εφαρμογής και επιβεβαιώστε ότι το αναμενόμενο σχήμα εξακολουθεί να υπάρχει.

Το παρακάτω παράδειγμα αναζητά με βάση το `name` με ακριβή σύγκριση και αναφέρει το ID interop της διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Όταν μια λειτουργία είναι συγκεκριμένη για έναν τύπο σχήματος, ελέγξτε τον τύπο πριν χρησιμοποιήσετε μέλη ειδικά για αυτόν τον τύπο. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Αναγνώριση και Τροποποίηση Προεπιλεγμένων Ρυθμίσεων Σχήματος**

Τα σχήματα γεωμετρίας προεπιλογής μπορούν να εκθέτουν σημεία ρύθμισης που ελέγχουν χαρακτηριστικά όπως το μέγεθος γωνιών, οι αναλογίες βελών ή οι γωνίες τόξου. Πρόσβαση σε αυτά γίνεται μέσω της μόνο‑ανάγνωσης συλλογής [GeometryShape.adjustments](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/adjustments/). Η συλλογή παρέχεται από το σχήμα, αλλά κάθε [AdjustValue](https://reference.aspose.com/slides/el/python-net/aspose.slides/adjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε σταθερό δείκτη συλλογής. Επανάληψη στις ρυθμίσεις και έλεγχος της μόνο‑ανάγνωσης ιδιότητας [AdjustValue.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/adjustvalue/type/), της οποίας η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η ρύθμιση. Η μόνο‑ανάγνωσης ιδιότητα [AdjustValue.name](https://reference.aspose.com/slides/el/python-net/aspose.slides/adjustvalue/name/) παρέχει πρόσθετες πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν μια προεπιλογή περιέχει περισσότερες από μία ρυθμίσεις με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε την ιδιότητα τιμής που ταιριάζει με τη σημασία της ρύθμισης:

| Τύπος ρύθμισης | Σκοπός | Τιμή προς αλλαγή |
|---|---|---|
| `CORNER_SIZE` | Μέγεθος στρογγυλεμένων γωνιών | [raw_value](https://reference.aspose.com/slides/el/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Πάχος ουράς βέλους | `raw_value` |
| `ARROWHEAD_LENGTH` | Μήκος άκρου βέλους | `raw_value` |
| `ARROWHEAD_WIDTH` | Πλάτος άκρου βέλους | `raw_value` |
| `START_ANGLE` | Αρχική γωνία πίτας ή τόξου | [angle_value](https://reference.aspose.com/slides/el/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Τελική γωνία πίτας ή τόξου | `angle_value` |

`type` και `name` δεν μπορούν να εκχωρηθούν. `raw_value` είναι ακέραιος ανάγνωσης/εγγραφής στη φυσική μονάδα γεωμετρίας της προεπιλογής, ενώ `angle_value` είναι γωνία ανάγνωσης/εγγραφής σε μοίρες. Ο αριθμός, η σειρά, η σημασία και το έγκυρο εύρος των ρυθμίσεων εξαρτώνται από το [GeometryShape.shape_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/shape_type/). Μια τιμή που είναι έγκυρη για μία προεπιλογή μπορεί να είναι άκυρη ή να έχει διαφορετικό αποτέλεσμα για άλλη.

Όταν `type` είναι `ShapeAdjustmentType.CUSTOM`, το API δεν αναγνωρίζει τυπική σημασιολογική σημασία. Εξετάστε το `name`, τον τύπο προεπιλογής και την υπάρχουσα τιμή, και αφήστε τη ρύθμιση αμετάβλητη εκτός εάν γνωρίζετε τη σημασία και το εύρος. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες από μία φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/python-net/connector/) δείχνει αυτή την κατάσταση με ρυθμίσεις κάμψης συνδέσμων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδόσεις τριών προεπιλογών σχήματος. Επαναλαμβάνει κάθε ρύθμιση, αναφέρει το `name` και το `type`, αλλάζει τιμές σχετικές με το μέγεθος μέσω `raw_value`, αλλάζει γωνίες μέσω `angle_value`, και αποθηκεύει το αποτέλεσμα. Η αριστερή στήλη διατηρεί τη προεπιλεγμένη γεωμετρία· η δεξιά στήλη δείχνει το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το τετραπλό βέλος και την πίτα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθέστε επικεφαλίδες για τις προεπιλεγμένες και προσαρμοσμένες στήλες σχήματος.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Ο έλεγχος του σημασιολογικού τύπου πριν την αλλαγή τιμής κάνει τον κώδικα σαφή ως προς την πρόθεσή του και αποτρέπει την υπόθεση ότι ένας συγκεκριμένος δείκτης συλλογής έχει την ίδια σημασία σε διαφορετικά προεπιλεγμένα σχήματα.

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, διαγραφής και αναδιάταξης λειτουργούν αμέσως στη συλλογή. Εάν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που ελήφθησαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_clone/) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/insert_clone/) επίσης δημιουργεί αντίγραφο αλλά το τοποθετεί σε συγκεκριμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μεταφέρνουν το αντίγραφο χωρίς αλλαγή μεγέθους· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αναπροσαρμόσουν.

Το παράδειγμα δημιουργεί μια διαφάνεια-προορισμό, κλωνοποιεί ένα ορθογώνιο με ετικέτα στο πρόσθιο και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε οποιονδήποτε κλώνο δεν τροποποιούν το αρχικό σχήμα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένων του ονόματος και του εναλλακτικού κειμένου. Αναθέστε νέα λογικά αναγνωριστικά στον κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούν πολύπλοκα σχήματα διαχειρίζεται η παρουσίαση, αλλά ένας κλώνος παραμένει νέο στοιχείο συλλογής με νέα ταυτότητα σχήματος.

### **Διαγραφή Σχημάτων**

[ShapeCollection.remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν διαγράφετε πολλαπλές αντιστοιχίες κατά τη διάρκεια επανάληψης με δείκτες, διασχίστε τη συλλογή από το τέλος ώστε κάθε εναπομείναν δεικτης να παραμένει έγκυρος.

Το παράδειγμα διαγράφει κάθε σχήμα με καθορισμένο όνομα. Διαβάζει `slide.shapes[index]`, όχι ένα σταθερό στοιχείο συλλογής, και δεν κάνει περιττή μετατροπή τύπου.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Μετά τη διαγραφή, ο αριθμός σχημάτων και οι δείκτες των επόμενων σχημάτων αλλάζουν. Αναφορές σε αμετάβλητα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Επίσης λάβετε υπόψη συνδέσμους, κινήσεις και άλλα χαρακτηριστικά παρουσίασης που μπορεί να αναφέρονται στο διαγραμμένο αντικείμενο· η διαγραφή ενός ορατού σχήματος μπορεί να αλλάξει περισσότερα από την εμφάνιση της διαφάνειας.

### **Κρυφή Σχήματος**

Ορίζοντας το [Shape.hidden](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/hidden/) σε `True` διατηρεί το σχήμα στη συλλογή αλλά αποτρέπει την εμφάνισή του στην κανονική προβολή διαφάνειας. Ο δείκτης, η μορφοποίηση και το περιεχόμενό του παραμένουν διαθέσιμα στον κώδικα, οπότε η κρυφή είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να αποκατασταθούν αργότερα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Η κρύψιμο δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να ανακαλυφθεί και να αποκρυφθεί από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή Z‑Order**

Τα επικαλυπτόμενα σχήματα σχεδιάζονται με σειρά της συλλογής. [ShapeCollection.reorder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `len(slide.shapes) - 1` είναι το μπροστινό.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από το έλλειπσο. Η μετακίνηση του στον τελικό δείκτη το τοποθετεί στο εμπρός. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν τη στοίβα.

## **Επιθεώρηση Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα στη συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Ελέγξτε τα σχήματα διάταξης όταν χρειάζεται να καταλάβετε ή να αλλάξετε τη μορφοποίηση που παρέχει μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [Shape.fill_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/fill_format/) και το [Shape.line_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/line_format/) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική υπερισχύ, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί εκείνη τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/write_as_svg/) γράφει το αποτυπωμένο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιλαμβάνει μόνο το σχήμα, όχι το παρασκήνιο ολόκληρης διαφάνειας ή τα γειτονικά σχήματα.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Διατηρήστε την παρουσίαση ανοιχτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για το μεμονωμένο σχήμα. Ο καλώντας είναι υπεύθυνος για τη ροή και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις [SlideUtil.align_shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/align_shapes/) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη γραμμή κέντρου ή τη λειτουργία κατανομής. Ορίστε `align_to_slide` σε `True` για χρήση των άκρων της διαφάνειας· ορίστε το σε `False` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Το παράδειγμα αυτό ευθυγραμμίζει τρία σχήματα στην άνω άκρη της διαφάνειας. Οι τρέχοντες δείκτες τους επιλύονται αμέσως πριν τη στοίχιση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Η στοίχιση αλλάζει τις θέσεις, όχι το z‑order. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή χρειάζεται αρκετά σχήματα για τον καθορισμό του διαστήματος. Επαναϋπολογίστε τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντια και κάθετη ρύθμιση αναστροφής και περιστροφή. Οι τιμές `flip_h` και `flip_v` χρησιμοποιούν [NullableBool](https://reference.aspose.com/slides/el/python-net/aspose.slides/nullablebool/): `TRUE` ενεργοποιεί την αναστροφή, `FALSE` την απενεργοποιεί, και `NOT_DEFINED` διατηρεί την ακαθόριστη ή προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση εισόδου περιέχει ένα σχήμα χωρίς αναστροφή.

![The shape before flipping](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή του πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η εκχώρηση ενός νέου [Shape.frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/frame/) αντικαθιστά ολόκληρο το πλαίσιο.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Το αποθηκευμένο σχήμα αντικατοπτρίζεται οριζόντια και κάθετα διατηρώντας τη θέση, το μέγεθος και την περιστροφή.

![The shape after flipping](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Πρέπει να χρησιμοποιήσω δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχυπρόθεσμη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε ένα επαληθευμένο σύστημα ονομάτων `name` ή `alternative_text` για πρότυπα που δημιουργήθηκαν, ή `office_interop_shape_id` για εργασίες interop σε επίπεδο διαφάνειας.

**Αφαιρεί η κρυφή σχήματος το z‑order;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στον ίδιο δείκτη. Μπορεί να βρεθεί, να αναδιαταχθεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

`add_clone` προσθέτει το κλώνο στο τέλος της συλλογής, που είναι το εμπρός μέρος του z‑order. Χρησιμοποιήστε `insert_clone` για να επιλέξετε αρχικό δείκτη ή `reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω σταθερό δείκτη για την ταυτοποίηση ρύθμισης προεπιλεγμένου σχήματος;**

Μόνο μετά από επαλήθευση της ακριβούς προεπιλογής και της διάταξης της συλλογής. Προτιμήστε την επανάληψη μέσω `GeometryShape.adjustments` και τον έλεγχο του `AdjustValue.type`; χρησιμοποιήστε `AdjustValue.name` ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερες από μία φορές.