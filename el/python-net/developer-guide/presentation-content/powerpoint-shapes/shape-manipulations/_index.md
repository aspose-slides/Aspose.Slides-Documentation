---
title: Διαχείριση Σχημάτων Παρουσίασης σε Python
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/python-net/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- Σχήμα παρουσίασης
- Σχήμα σε διαφάνεια
- Εύρεση σχήματος
- Κλωνοποίηση σχήματος
- Αφαίρεση σχήματος
- Απόκρυψη σχήματος
- Αλλαγή σειράς σχήματος
- Λήψη ID σχήματος interop
- Εναλλακτικό κείμενο σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Σχήμα σε SVG
- Στοίχιση σχήματος
- Αναστροφή σχήματος
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να εντοπίζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αλλάζετε σειρά, εξάγετε, ευθυγραμμίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Aspose.Slides for Python via .NET παρουσιάζει τα σχήματα σε μια διαφάνεια ως μια ταξινομημένη [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/). Η συλλογή είναι τόσο το μέρος όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς στοίβαξής τους: το ευρετήριο `0` είναι το πιο πίσω σχήμα, ενώ το τελευταίο ευρετήριο είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να ταυτοποιήσετε ένα σχήμα με αξιοπιστία, έπειτα δείχνει πώς να κλωνοποιήσετε, να αφαιρέσετε, να κρύψετε και να αλλάξετε τη σειρά σχήματος. Οι τελικές ενότητες καλύπτουν μορφοποίηση επιπέδου διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτούνται από τη ροή εργασίας σας.

## **Ταυτοποίηση και Εύρεση Σχημάτων**

Οι δείκτες της συλλογής είναι βολικοί κατά την επεξεργασία γνωστού αρχείου, αλλά δεν είναι σταθεροί ταυτοποιητές. Η προσθήκη, η αφαίρεση ή η αλλαγή σειράς ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε έναν ταυτοποιητή ανάλογα με το πώς δημιουργείται και διατηρείται η παρουσίαση:

- [Shape.name](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/name/) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να επιθεωρηθεί στον Πίνακα Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν είναι εγγυημένο ότι είναι μοναδικά, επομένως καθορίστε μια σύμβαση ονομασίας εάν ο κώδικας εξαρτάται από αυτά.
- [Shape.alternative_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/alternative_text/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα από τον συγγραφέα ήδη ταυτοποιεί το σχήμα. Είναι ορατό στους χρήστες, μπορεί να τοπικοποιηθεί ή να επανεγγραφεί για προσβασιμότητα, και δεν είναι εγγυημένο ότι είναι μοναδικό. Μην επαναχρησιμοποιείτε σιωπηρά το σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/office_interop_shape_id/) είναι ένας μόνο‑ανάγνωση ταυτοποιητής που είναι μοναδικός μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια ασαφή αναφορά κατά τη διάρκεια της ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Το σχετικό ιδιόκτητο [Shape.unique_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/unique_id/) έχει εμβέλεια παρουσίασης, αλλά προορίζεται για πρόσθετα και μπορεί να επαναχρισθεί. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Εάν η μακροπρόθεσμη ταυτότητα είναι ουσιώδης, διατηρήστε την αντιστοίχιση στα δεδομένα της εφαρμογής και επαληθεύστε ότι το αναμενόμενο σχήμα εξακολουθεί να υπάρχει.

Το παρακάτω παράδειγμα αναζητεί με `name` με ακριβή σύγκριση και αναφέρει το ID interop της διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

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

Όταν μια λειτουργία είναι συγκεκριμένη για τύπο σχήματος, ελέγξτε τον τύπο πριν χρησιμοποιήσετε μέλη ειδικά για τον τύπο. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).

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

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αλλαγής σειράς λειτουργούν άμεσα στη συλλογή. Εάν μια λειτουργία αλλάξει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που λήφθηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_clone/) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/insert_clone/) επίσης δημιουργεί ένα αντίγραφο αλλά το τοποθετεί σε καθορισμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς να αλλάζουν το μέγεθός του· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αλλάξουν.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα επισημασμένο ορθογώνιο μπροστά, και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε οποιονδήποτε κλώνο δεν τροποποιούν το πηγαίο σχήμα.

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

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένου του ονόματος και του εναλλακτικού κειμένου. Εκχωρήστε νέα λογικά αναγνωριστικά στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούν περίπλοκα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[ShapeCollection.remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Κατά την αφαίρεση πολλαπλών αντιστοιχίσεων κατά την επαναληπτική διαπέραση με δείκτες, διασχίστε από το τέλος ώστε κάθε υπόλοιπο δείκτη να παραμείνει έγκυρος.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με ορισμένο όνομα. Διαβάζει `slide.shapes[index]`, όχι ένα σταθερό στοιχείο της συλλογής, και δεν κάνει άσκοπη μετατροπή τύπου.

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

Μετά την αφαίρεση, η καταμέτρηση σχημάτων και οι δείκτες των επόμενων σχημάτων αλλάζουν. Αναφορές σε αμετάβλητα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Λάβετε επίσης υπόψη συνδέσμους, κινούμενα σχέδια και άλλα χαρακτηριστικά παρουσίασης που μπορεί να αναφέρονται στο αντικείμενο που αφαιρέθηκε· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερο από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ορίζοντας το [Shape.hidden](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/hidden/) σε `True` διατηρεί το σχήμα στη συλλογή αλλά αποτρέπει την εμφάνισή του στην κανονική προβολή διαφάνειας. Ο δείκτης, η μορφοποίηση και το περιεχόμενό του παραμένουν διαθέσιμα στον κώδικα, οπότε η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφέρεται αργότερα.

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

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμα να εντοπισθεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή Z‑Order**

Τα επικαλυπτόμενα σχήματα χρωματίζονται με τη σειρά της συλλογής. [ShapeCollection.reorder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `len(slide.shapes) - 1` είναι το μπροστινό.

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

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνηση του στον τελικό δείκτη το τοποθετεί μπροστά. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν την επιθυμητή στοίβαξη.

## **Επιθεώρηση Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε μια συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Εξετάστε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [Shape.fill_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/fill_format/) και το [Shape.line_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/line_format/) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι ένα `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/write_as_svg/) γράφει το αποδομένο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιλαμβάνει το σχήμα, όχι το πλήρες φόντο της διαφάνειας ή τα γειτονικά σχήματα.

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

Διατηρήστε την παρουσίαση ανοιχτή κατά τη απόδοση. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για ένα μεμονωμένο σχήμα. Ο καλούντο διαχειρίζεται τη ροή και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil.align_shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/align_shapes/) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη γραμμή κέντρου ή τον τρόπο διανομής. Ορίστε `align_to_slide` σε `True` για χρήση των άκρων της διαφάνειας· ορίστε το σε `False` για ευθυγράμμιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα ευθυγραμμίζει τρία σχήματα προς την επάνω άκρη της διαφάνειας. Οι τρέχουσες θέσεις τους επιλύονται αμέσως πριν από την ευθυγράμμιση.

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

Η ευθυγράμμιση αλλάζει θέσεις, όχι το z‑order. Η σχετική ευθυγράμμιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή χρειάζεται αρκετά σχήματα για να ορίσει το διάστιχο. Επανυπολογίστε τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντια και κάθετη ρύθμιση αναστροφής και περιστροφή. Οι τιμές `flip_h` και `flip_v` χρησιμοποιούν το [NullableBool](https://reference.aspose.com/slides/el/python-net/aspose.slides/nullablebool/): `TRUE` ενεργοποιεί την αναστροφή, `FALSE` την απενεργοποιεί, και `NOT_DEFINED` διατηρεί την ακαθόριστη ή προεπιλεγμένη κατάσταση.

Η εισαγόμενη παρουσίαση παρακάτω περιέχει ένα μη αναστραμμένο σχήμα.

![Το σχήμα πριν την αναστροφή](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί όλες τις άλλες τιμές του πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Shape.frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/frame/) αντικαθιστά ολόκληρο το πλαίσιο.

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

Το αποθηκευμένο σχήμα είναι καθρεφτισμένο οριζόντια και κάθετα, διατηρώντας τη θέση, το μέγεθος και την περιστροφή του.

![Το σχήμα μετά την αναστροφή](flipped_shape.png)

## **Συχνές ερωτήσεις**

**Θα πρέπει να χρησιμοποιήσω έναν δείκτη συλλογής ως ταυτοποιητή σχήματος;**

Μόνο για βραχυπρόθεσμη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε μια επικυρωμένη σύμβαση `name` ή `alternative_text` για πρότυπα που δημιουργήθηκαν, ή `office_interop_shape_id` για εργασίες interop εντός διαφάνειας.

**Αφαιρεί η απόκρυψη ενός σχήματος το z‑order του;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στον ίδιο δείκτη. Μπορεί να βρεθεί, να αλλάξει σειρά, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίζεται μπροστά από άλλο σχήμα;**

Η `add_clone` προσθέτει το κλώνο στο τέλος της συλλογής, το οποίο αντιστοιχεί στο μπροστινό μέρος του z‑order. Χρησιμοποιήστε `insert_clone` για να επιλέξετε τον αρχικό δείκτη ή `reorder` μετά την προσθήκη όλων των σχημάτων.