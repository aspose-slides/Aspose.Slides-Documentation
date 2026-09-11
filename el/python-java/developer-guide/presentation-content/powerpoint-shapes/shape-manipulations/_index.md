---
title: Διαχείριση Σχημάτων Παρουσίασης σε Python μέσω Java
linktitle: Χειρισμός Σχήματος
type: docs
weight: 40
url: /el/python-java/shape-manipulations/
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
- Σημείο προσαρμογής σχήματος
- Προρυθμισμένη προσαρμογή σχήματος
- Γεωμετρία σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Μετατροπή σχήματος σε SVG
- Στοίχιση σχήματος
- Αναστροφή σχήματος
- PowerPoint
- Παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να ταυτοποιείτε, να προσαρμόζετε, να κλωνοποιείτε, να αφαιρείτε, να κρύβετε, να αναδιατάξετε, να εξάγετε, να στοιχίζετε και να αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides for Python via Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via Java αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/). Η συλλογή είναι τόσο το μέρος όπου βρίσκετε και τροποποιείτε τα σχήματα όσο και η πηγή της σειράς στοίβας τους: το ευρετήριο `0` είναι το πιο πίσω σχήμα, ενώ το τελευταίο ευρετήριο είναι το πιο μπροστινό σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να προσδιορίσετε ένα σχήμα αξιόπιστα και να τροποποιήσετε τα προρυθμισμένα σημεία προσαρμογής σχήματος, μετά δείχνει πώς να κλωνοποιήσετε, να αφαιρέσετε, να κρύψετε και να αναδιατάξετε σχήματα. Οι τελευταίες ενότητες καλύπτουν τη διαμόρφωση σε επίπεδο διάταξης, την εξαγωγή σε SVG, την ευθυγράμμιση και τις ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτεί η ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Τα ευρετήρια της συλλογής είναι βολικά κατά την επεξεργασία ενός γνωστού αρχείου, αλλά δεν είναι σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η αναδιάταξη ενός σχήματος μπορεί να αλλάξει το ευρετήριό του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getName) είναι χρήσιμο για templates ελεγχόμενα από προγραμματιστές και είναι εύκολο να επιθεωρηθεί στο Πάνελ Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν είναι εγγυημένα μοναδικά, οπότε καθορίστε έναν κανόνα ονοματοδοσίας αν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getAlternativeText) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που παρέχει ο συγγραφέας ταυτοποιεί ήδη. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφτεί για προσβασιμότητα, και δεν είναι εγγυημένα μοναδικό. Μην επαναχρησιμοποιείτε σιωπηρά το νόημα του κειμένου προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getOfficeInteropShapeId) είναι ένα μόνο-ανάγνωση αναγνωριστικό που είναι μοναδικό μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια σαφή αναφορά κατά τη διάρκεια ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επανδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική μέθοδος [getUniqueId](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getUniqueId) επιστρέφει ένα αναγνωριστικό με εμβέλεια παρουσίασης, αλλά αυτό το αναγνωριστικό προορίζεται για πρόσθετα και μπορεί να επαναχρησιμοποιηθεί. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Εάν η μακροπρόθεσμη ταυτοποίηση είναι ουσιώδης, κρατήστε τη χαρτογράφηση στα δεδομένα της εφαρμογής και επικυρώστε ότι το αναμενόμενο σχήμα εξακολουθεί να υπάρχει.

Το ακόλουθο παράδειγμα αναζητά κατά όνομα με ακριβή σύγκριση και αναφέρει το ID interop περιορισμένο στη διαφάνεια. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Όταν μια λειτουργία είναι συγκεκριμένη για τύπο σχήματος, ελέγξτε τον τύπο πριν χρησιμοποιήσετε μέλη τύπου-συγκεκριμένα. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο αν το ονοματοθετημένο αντικείμενο είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Αναγνώριση και Τροποποίηση Προρυθμισμένων Προσαρμογών Σχήματος**

Τα σχήματα προρυθμισμένης γεωμετρίας μπορούν να εκθέτουν σημεία προσαρμογής που ελέγχουν χαρακτηριστικά όπως το μέγεθος γωνίας, οι αναλογίες βέλους ή οι γωνίες τόξου. Πρόσβαση σε αυτά γίνεται μέσω της μόνο-ανάγνωσης συλλογής [GeometryShape.getAdjustments](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/#getAdjustments). Η ίδια η συλλογή παρέχεται από το σχήμα, αλλά κάθε [AdjustValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε ένα σταθερό ευρετήριο συλλογής. Περιηγηθείτε στις προσαρμογές και ελέγξτε τη μόνο-ανάγνωσης μέθοδο [getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getType), της οποίας η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η προσαρμογή. Η μόνο-ανάγνωσης μέθοδος [getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getName) παρέχει πρόσθετες πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν ένα preset περιέχει περισσότερες από μία προσαρμογές με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε τη μέθοδο τιμής που ταιριάζει με το νόημα της προσαρμογής:

| Τύπος προσαρμογής | Σκοπός | Τιμή προς αλλαγή |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Μέγεθος στρογγυλοποιημένων γωνιών | [setRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Πάχος ουράς βέλους | [setRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Μήκος άκρου βέλους | [setRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Πλάτος άκρου βέλους | [setRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Αρχική γωνία πίτας ή τόξου | [setAngleValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Τελική γωνία πίτας ή τόξου | [setAngleValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setAngleValue) |

Οι μέθοδοι [getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getType) και [getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getName) επιστρέφουν μόνο-ανάγνωστη πληροφορία. Οι μέθοδοι [getRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getRawValue) και [setRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setRawValue) δουλεύουν με έναν ακέραιο στις εγγενείς μονάδες γεωμετρίας του preset, ενώ οι [getAngleValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getAngleValue) και [setAngleValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setAngleValue) δουλεύουν με γωνία σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των προσαρμογών εξαρτώνται από το preset [ShapeType](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/#getShapeType). Μία τιμή που είναι έγκυρη για ένα preset μπορεί να είναι μη έγκυρη ή να έχει διαφορετικό αποτέλεσμα για άλλο.

Όταν η μέθοδος [getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getType) επιστρέφει [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#Custom), η API δεν αναγνωρίζει τυπικό σημασιολογικό νόημα. Επιθεωρήστε το [getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getName), τον τύπο preset και την υπάρχουσα τιμή, και αφήστε την προσαρμογή αμετάβλητη εκτός αν το αναμενόμενο νόημα και το εύρος είναι γνωστά. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/python-java/connector/) δείχνει αυτήν τη κατάσταση με προσαρμογές κάμψης συνδέσμων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδόσεις τριών preset σχημάτων. Περιηγείται σε κάθε προσαρμογή, αναφέρει το όνομα και τον τύπο της, αλλάζει τιμές σχετικές με το μέγεθος μέσω [setRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setRawValue), αλλάζει γωνίες μέσω [setAngleValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setAngleValue) και αποθηκεύει το αποτέλεσμα. Η αριστερή στήλη διατηρεί τη προεπιλεγμένη γεωμετρία· η δεξιά στήλη δείχνει το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το βέλος τετραπλής κατεύθυνσης και την πίτα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθέτει κεφαλίδες για τις στήλες του προεπιλεγμένου και του προσαρμοσμένου σχήματος.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ο έλεγχος του σημασιολογικού τύπου πριν από την αλλαγή μιας τιμής κάνει τον κώδικα σαφές ως προς την πρόθεσή του και αποτρέπει την υπόθεση ότι ένα συγκεκριμένο ευρετήριο συλλογής έχει το ίδιο νόημα σε διαφορετικά preset σχήματος.

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αναδιάταξης λειτουργούν αμέσως στη συλλογή. Εάν μια λειτουργία αλλάξει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε ευρετήρια που λήφθηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

Η μέθοδος [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addClone) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. Η [insertClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#insertClone) επίσης δημιουργεί αντίγραφο αλλά το τοποθετεί σε καθορισμένο ευρετήριο z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς αλλαγή μεγέθους· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αλλάξουν σε μέγεθος.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα ετικετοποιημένο ορθογώνιο στο εμπρός μέρος και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε οποιοδήποτε κλώνο δεν τροποποιούν το αρχικό σχήμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένου του ονόματος και του εναλλακτικού κειμένου. Αναθέστε νέους λογικούς ταυτοποιητές στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούνται από σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά το κλώνο παραμένει ένα νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

Η μέθοδος [remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#remove) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν αφαιρείτε πολλαπλές αντιστοιχίες κατά τη διάρκεια επεξεργασίας με δείκτη, διασχίστε τη συλλογή από το τέλος ώστε κάθε εναπομείναν ευρετήριο να παραμείνει έγκυρο.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με ένα καθορισμένο όνομα. Διαβάζει το σχήμα στο τρέχον ευρετήριο, όχι ένα σταθερό στοιχείο συλλογής, και δεν κάνει άσκοπη μετατροπή τύπου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Μετά την αφαίρεση, ο αριθμός σχημάτων και τα ευρετήρια των επόμενων σχημάτων αλλάζουν. Οι αναφορές σε ανεπηρέαστα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένα ευρετήρια. Επίσης, λάβετε υπόψη συνδέσμους, κινούμενα σχέδια και άλλες λειτουργίες παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερο από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ο ορισμός του [Hidden](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setHidden) σε `True` διατηρεί το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική προβολή. Το ευρετήριό του, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, έτσι η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να εντοπιστεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή της Σειράς Z**

Τα επικαλυπτόμενα σχήματα ζωγραφίζονται με σειρά της συλλογής. Η μέθοδος [reorder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#reorder) μετακινεί ένα υπάρχον σχήμα σε ένα στόχο ευρετήριο χωρίς κλωνοποίηση. Το ευρετήριο `0` είναι το πίσω μέρος· το [size](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#size) της συλλογής μείον ένα είναι το εμπρός μέρος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το ορθογώνιο δημιουργείται πρώτο και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνηση του στο τελικό ευρετήριο το φέρνει εμπρός. Ορίστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες εισάγουν ή προσθέτουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν τη στοίβα.

## **Έλεγχος Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε μια συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Εξετάστε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχει μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getFillFormat) και το [LineFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getLineFormat) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

Η μέθοδος `writeAsSvg` του [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) γράφει το αποδομένο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιλαμβάνει το σχήμα, όχι το σύνολο του φόντου της διαφάνειας ή τα γειτονικά σχήματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Κρατήστε την παρουσίαση ανοιχτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί ενός μεμονωμένου σχήματος. Ο καλούντος διαχειρίζεται τη ροή και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil.alignShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/#alignShapes) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένα ευρετήρια συλλογής. Ο τύπος [ShapesAlignmentType](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη γραμμή κέντρου ή τη λειτουργία κατανομής. Ορίστε `align_to_slide` σε `True` για χρήση των άκρων της διαφάνειας· ορίστε το σε `False` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα στοιχίζει τρία σχήματα στην επάνω άκρη της διαφάνειας. Οι επιστρεφόμενες αναφορές σ_shape μετατρέπονται αμέσως στις τρέχουσες θέσεις τους πριν από τη στοίχιση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η στοίχιση αλλάζει θέσεις, όχι τη σειρά Z. Η σχετική στοίχιση απαιτεί συνήθως τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή απαιτεί αρκετά σχήματα για ορισμό απόστασης. Υπολογίστε ξανά τα ευρετήρια εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντιες και κάθετες ρυθμίσεις ανάστροφης και περιστροφή. Οι τιμές των [getFlipH](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeframe/#getFlipH) και [getFlipV](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeframe/#getFlipV) χρησιμοποιούν το [NullableBool](https://reference.aspose.com/slides/el/python-java/aspose.slides/nullablebool/): `True` ενεργοποιεί την ανάστροφη, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση περιέχει ένα σχήμα που δεν έχει αναστραφεί.

![Το σχήμα πριν την αναστροφή](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις ανάστροφης. Αυτό είναι σημαντικό επειδή η εκχώρηση ενός νέου [Frame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setFrame) αντικαθιστά ολόκληρο το πλαίσιο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποθηκευμένο σχήμα είναι καθρεπτισμένο οριζόντια και κάθετα, διατηρώντας θέση, μέγεθος και περιστροφή.

![Το σχήμα μετά την αναστροφή](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Πρέπει να χρησιμοποιώ ένα ευρετήριο συλλογής ως ταυτότητα σχήματος;**

Μόνο για βραχυπρόθεσμη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί το ευρετήριο. Προτιμήστε ένα επικυρωμένο [Name](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getName) ή [AlternativeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getAlternativeText) σύμφωνο για templates που δημιουργήθηκαν, ή [OfficeInteropShapeId](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getOfficeInteropShapeId) για εργασία interop περιορισμένης στη διαφάνεια.

**Αφαιρεί η απόκρυψη ενός σχήματος τη θέση του στη σειρά Z;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στο ίδιο ευρετήριο. Μπορεί να βρεθεί, να αναδιαταχθεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

Η μέθοδος [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addClone) προσθέτει το κλώνο στο τέλος της συλλογής, που είναι το εμπρός μέρος της σειράς Z. Χρησιμοποιήστε [insertClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#insertClone) για επιλογή αρχικού ευρετηρίου ή [reorder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#reorder) μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω σταθερό ευρετήριο για την ταυτοποίηση μιας προρυθμισμένης προσαρμογής σχήματος;**

Μόνο αφού επικυρώσετε το ακριβές preset και τη διάταξη της συλλογής. Προτιμήστε την περιήγηση μέσω του [GeometryShape.getAdjustments](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/#getAdjustments) και τον έλεγχο του [AdjustValue.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getType); χρησιμοποιήστε το [AdjustValue.getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getName) ως πρόσθετη πληροφορία όταν εμφανίζεται ο ίδιος σημασιολογικός τύπος περισσότερες από μία φορές.