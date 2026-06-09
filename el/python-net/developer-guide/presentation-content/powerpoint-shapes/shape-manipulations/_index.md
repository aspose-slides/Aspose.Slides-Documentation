---
title: Διαχείριση Σχημάτων σε Παρουσιάσεις Χρησιμοποιώντας Python
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
- Λήψη ID σχήματος Interop
- Εναλλακτικό κείμενο σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Σχήμα σε SVG
- Ευθυγράμμιση σχήματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε να δημιουργείτε, επεξεργάζεστε και βελτιστοποιείτε σχήματα στο Aspose.Slides για Python μέσω .NET και να παρέχετε υψηλής απόδοσης παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτός ο οδηγός παρουσιάζει τη διαχείριση σχημάτων στο Aspose.Slides για Python μέσω .NET. Μάθετε πρακτικά μοτίβα για την εύρεση σχημάτων (συμπεριλαμβανομένου του Εναλλακτικού Κειμένου), την αντιγραφή, τη διαγραφή ή την απόκρυψη, την αναδιάταξη, την ευθυγράμμιση και την αναστροφή, την ανάγνωση αναγνωριστικών και τη μορφοποίηση βάσει διάταξης, καθώς και την εξαγωγή μεμονωμένων σχημάτων σε SVG χρησιμοποιώντας τα API [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/).

## **Εύρεση Σχημάτων σε Διαφάνειες**

Το PowerPoint αναγνωρίζει τα σχήματα μόνο με εσωτερικά IDs. Αναθέστε ένα μοναδικό Εναλλακτικό Κείμενο στο επιθυμητό σχήμα στο PowerPoint, κατόπ

ιν ανοίξτε την παρουσίαση με Aspose.Slides για Python, επαναλάβετε τα σχήματα της διαφάνειας και επιλέξτε αυτό που το Εναλλακτικό Κείμενο ταιριάζει. Η μέθοδος `find_shape` υλοποιεί αυτή την προσέγγιση και επιστρέφει το αντίστοιχο σχήμα.

```py
import aspose.slides as slides

# Βρίσκει ένα σχήμα σε μια διαφάνεια με βάση το εναλλακτικό κείμενό του.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Δημιουργεί μια παρουσίαση της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Βρίσκει το σχήμα με Εναλλακτικό Κείμενο "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Κλωνοποίηση Σχημάτων**

Για να κλωνοποιήσετε σχήματα από μια πηγή διαφάνειας σε μια νέα διαφάνεια στο Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) από το αρχείο προέλευσης.
1. Λάβετε τη διαφάνεια προέλευσης με βάση το δείκτη και τη συλλογή σχημάτων της.
1. Ανακτήστε μια κενή διάταξη από τη διαφάνεια‑κύριο (master slide).
1. Προσθέστε μια κενή διαφάνεια χρησιμοποιώντας αυτή τη διάταξη και λάβετε τα σχήματά της.
1. Κλωνοποιήστε τα σχήματα στη διαφάνεια‑στόχο.
1. Αποθηκεύστε την παρουσίαση ως PPTX.

Το παρακάτω παράδειγμα κώδικα κλωνοποιεί σχήματα από μια διαφάνεια στην άλλη.

```py
import aspose.slides as slides

# Δημιουργεί την κλάση Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Αποθηκεύει την παρουσίαση στο δίσκο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Αφαίρεση Σχημάτων**

Το Aspose.Slides σας επιτρέπει να αφαιρέσετε οποιοδήποτε σχήμα από μια διαφάνεια. Για παράδειγμα, για να διαγράψετε ένα σχήμα από την πρώτη διαφάνεια με βάση το Εναλλακτικό του Κείμενο, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε μια [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε το αρχείο.
1. Πρόσβαση στην πρώτη διαφάνεια από τη συλλογή διαφανειών.
1. Εντοπίστε το σχήμα με την τιμή του Εναλλακτικού Κειμένου.
1. Αφαιρέστε το σχήμα από τη συλλογή σχημάτων της διαφάνειας.
1. Αποθηκεύστε την παρουσίαση στο δίσκο σε μορφή PPTX.

```py
import aspose.slides as slides

# Βρίσκει ένα σχήμα σε μια διαφάνεια με βάση το εναλλακτικό κείμενό του.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Βρίσκει το σχήμα με Εναλλακτικό Κείμενο "User Defined".
    shape = find_shape(slide, "User Defined")
    # Αφαιρεί το σχήμα.
    slide.shapes.remove(shape)
    # Αποθηκεύει την παρουσίαση στο δίσκο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Απόκρυψη Σχημάτων**

Το Aspose.Slides σας επιτρέπει να κρύψετε οποιοδήποτε σχήμα σε μια διαφάνεια. Για παράδειγμα, για να κρύψετε ένα σχήμα στην πρώτη διαφάνεια με βάση το Εναλλακτικό του Κείμενο, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε μια [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε το αρχείο.
1. Πρόσβαση στην πρώτη διαφάνεια από τη συλλογή διαφανειών.
1. Εντοπίστε το σχήμα με την τιμή του Εναλλακτικού Κειμένου.
1. Κρύψτε το σχήμα.
1. Αποθηκεύστε την παρουσίαση στο δίσκο σε μορφή PPTX.

```py
# Βρίσκει ένα σχήμα σε μια διαφάνεια με βάση το εναλλακτικό κείμενό του.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Βρίσκει το σχήμα με Εναλλακτικό Κείμενο "User Defined".
    shape = find_shape(slide, "User Defined")
    # Κρύβει το σχήμα.
    shape.hidden = True
    # Αποθηκεύει την παρουσίαση στο δίσκο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή Σειράς Σχημάτων**

Το Aspose.Slides επιτρέπει στους προγραμματιστές να αλλάζουν τη σειρά (z‑order) των σχημάτων. Η αναδιάταξη καθορίζει ποιο σχήμα εμφανίζεται μπροστά ή πίσω. Για παράδειγμα, για να αλλάξετε τη σειρά δύο σχημάτων στην πρώτη διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση του τύπου [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε το πρώτο σχήμα (π.χ. ένα ορθογώνιο).
1. Προσθέστε το δεύτερο σχήμα (π.χ. ένα τρίγωνο).
1. Αλλάξτε τη σειρά των σχημάτων μετακινώντας το δεύτερο σχήμα στην πρώτη θέση της συλλογής.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Προσθέτει δύο σχήματα στη διαφάνεια.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Μετακινεί το δεύτερο σχήμα στην πρώτη θέση.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Λήψη Αναγνωριστικού Interop Shape**

Το Aspose.Slides σάς δίνει τη δυνατότητα να λάβετε το μοναδικό αναγνωριστικό ενός σχήματος στο επίπεδο της διαφάνειας, σε αντίθεση με την ιδιότητα `unique_id`, η οποία είναι μοναδική σε ολόκληρη την παρουσίαση. Η ιδιότητα `office_interop_shape_id` είναι διαθέσιμη στην κλάση [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/). Η τιμή της αντιστοιχεί στο `Id` του αντικειμένου `Microsoft.Office.Interop.PowerPoint.Shape`. Ένα παράδειγμα κώδικα φαίνεται παρακάτω.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Λαμβάνει το μοναδικό αναγνωριστικό του σχήματος εντός της διαφάνειας.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Ορισμός Εναλλακτικού Κειμένου για Σχήματα**

Το Aspose.Slides επιτρέπει στους προγραμματιστές να ορίσουν εναλλακτικό κείμενο για οποιοδήποτε σχήμα. Μπορείτε να χρησιμοποιήσετε το εναλλακτικό κείμενο για να αναγνωρίσετε και να εντοπίσετε σχήματα σε μια παρουσίαση. Η ιδιότητα εναλλακτικού κειμένου μπορεί να διαβαστεί και να εγγραφεί τόσο από το Aspose.Slides όσο και από το Microsoft PowerPoint. Με την ετικετοποίηση των σχημάτων με αυτήν την ιδιότητα, μπορείτε αργότερα να τα διαγράψετε, να τα κρύψετε ή να τα αναδιατάξετε σε μια διαφάνεια.

Για να ορίσετε το εναλλακτικό κείμενο ενός σχήματος, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε μια παρουσίαση του τύπου [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε ένα σχήμα στη διαφάνεια.
1. Ορίστε το εναλλακτικό κείμενο.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

```py
import aspose.slides as slides

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Προσθέτει ένα σχήμα.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Ορίζει το εναλλακτικό κείμενο για το σχήμα.
    shape.alternative_text = "User Defined"
    # Αποθηκεύει την παρουσίαση στο δίσκο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Μορφές Διάταξης για Σχήματα**

Το Aspose.Slides παρέχει ένα απλό API για πρόσβαση σε μορφές διάταξης για σχήματα. Αυτή η ενότητα επιδεικνύει πώς να αποκτήσετε πρόσβαση σε αυτές τις μορφές.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Απόδοση Σχημάτων ως SVG**

Το Aspose.Slides υποστηρίζει την απόδοση σχημάτων ως SVG. Η μέθοδος `write_as_svg` (και οι υπερφορτώσεις της) στην κλάση [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) σας επιτρέπει να αποθηκεύσετε τα περιεχόμενα ενός σχήματος ως εικόνα SVG. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να εξάγετε ένα σχήμα σε αρχείο SVG.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Ευθυγράμμιση Σχήματος**

Χρησιμοποιώντας τη μέθοδο `align_shape` στην κλάση [SlidesUtil](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/), μπορείτε:

* Να ευθυγραμμίσετε σχήματα σχετικά με τα περιθώρια μιας διαφάνειας (βλ. Παράδειγμα 1).
* Να ευθυγραμμίσετε σχήματα μεταξύ τους (βλ. Παράδειγμα 2).

Η απαρίθμηση [ShapesAlignmentType](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapesalignmenttype/) ορίζει τις διαθέσιμες επιλογές ευθυγράμμισης.

**Παράδειγμα 1**

Αυτός ο κώδικας Python δείχνει πώς να ευθυγραμμήσετε τα σχήματα με δείκτες 1, 2 και 4 στο επάνω άκρο της διαφάνειας:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Παράδειγμα 2**

Αυτό το παράδειγμα Python δείχνει πώς να ευθυγραμμίσετε όλα τα σχήματα μιας συλλογής σχετικά με το σχήμα με τη χαμηλότερη θέση στη συλλογή:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Ιδιότητες Αναστροφής**

Στο Aspose.Slides, η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapeframe/) παρέχει έλεγχο της οριζόντιας και κάθετης καθρεπτοποίησης των σχημάτων μέσω των ιδιοτήτων `flip_h` και `flip_v`. Και οι δύο ιδιότητες είναι τύπου [NullableBool](https://reference.aspose.com/slides/el/python-net/aspose.slides/nullablebool/), επιτρέποντας τιμές `TRUE` για αναστροφή, `FALSE` για μη αναστροφή ή `NOT_DEFINED` για χρήση προεπιλεγμένης συμπεριφοράς. Οι τιμές αυτές είναι προσβάσιμες από το [Frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/frame/) ενός σχήματος.

Για την τροποποίηση των ρυθμίσεων αναστροφής, δημιουργείται μια νέα παρουσία της κλάσης [ShapeFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapeframe/) με την τρέχουσα θέση και μέγεθος του σχήματος, τις επιθυμητές τιμές για `flip_h` και `flip_v`, καθώς και τη γωνία περιστροφής. Ανάθεση αυτής της παρουσίας στο [Frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/frame/) του σχήματος και αποθήκευση της παρουσίασης εφαρμόζει τις μετασχηματιστικές καθρεπτικές και τις ενσωματώνει στο αρχείο εξόδου.

Έστω ότι έχουμε αρχείο sample.pptx στο οποίο η πρώτη διαφάνεια περιέχει ένα σχήμα με προεπιλεγμένες ρυθμίσεις αναστροφής, όπως φαίνεται παρακάτω.

![The shape to be flipped](shape_to_be_flipped.png)

Το παρακάτω παράδειγμα κώδικα ανακτά τις τρέχουσες ιδιότητες αναστροφής του σχήματος και το αναστρέφει οριζοντίως και κατακόρυφα.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Ανάκτηση της οριζόντιας ιδιότητας αναστροφής του σχήματος.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Ανάκτηση της κάθετης ιδιότητας αναστροφής του σχήματος.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Αναστροφή οριζόντια και κάθετα.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The flipped shape](flipped_shape.png)

## **ΣΥΝΗΘΕΙΣΜΟΙ (FAQ)**

**Μπορώ να συνδυάσω σχήματα (ένωση/αποκοπή/αφαίρεση) σε μια διαφάνεια όπως σε επεξεργαστή επιφάνειας εργασίας;**

Δεν υπάρχει ενσωματωμένη API λογικής Boolean. Μπορείτε να προσεγγίσετε το αποτέλεσμα δημιουργώντας το επιθυμητό περίγραμμα εσείς‑αυτοί—π.χ., υπολογίζοντας την τελική γεωμετρία (μέσω του [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/)) και δημιουργώντας ένα νέο σχήμα με αυτό το περίγραμμα, ενδεχομένως αφαιρώντας τα αρχικά.

**Πώς μπορώ να ελέγξω τη σειρά (z‑order) ώστε ένα σχήμα να παραμένει πάντα «επάνω»;**

Αλλάξτε τη σειρά εισαγωγής/μετακίνησης μέσα στη συλλογή [shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/shapes/) της διαφάνειας. Για προβλέψιμα αποτελέσματα, ολοκληρώστε το z‑order μετά από όλες τις άλλες τροποποιήσεις της διαφάνειας.

**Μπορώ να «κλειδώσω» ένα σχήμα ώστε οι χρήστες να μην μπορούν να το επεξεργαστούν στο PowerPoint;**

Ναι. Ορίστε τις σημαίες προστασίας σε επίπεδο σχήματος ([shape-level protection flags](/slides/el/python-net/applying-protection-to-presentation/)) (π.χ. κλείδωμα επιλογής, μετακίνησης, αλλαγής μεγέθους, επεξεργασίας κειμένου). Εάν είναι απαραίτητο, εφαρμόστε περιορισμούς και στο master ή τη διάταξη. Σημειώστε ότι αυτή είναι προστασία σε επίπεδο UI, όχι χαρακτηριστικό ασφαλείας· για ισχυρότερη προστασία συνδυάστε με περιορισμούς σε επίπεδο αρχείου όπως προτεινόμενες αναγνώσεις‑μόνο ή κωδικούς πρόσβασης ([read‑only recommendations or passwords](/slides/el/python-net/password-protected-presentation/)).