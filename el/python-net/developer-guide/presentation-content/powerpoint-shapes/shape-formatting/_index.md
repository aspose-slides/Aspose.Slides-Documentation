---
title: Διαμόρφωση Σχημάτων PowerPoint σε Python
linktitle: Μορφοποίηση Σχημάτων
type: docs
weight: 20
url: /el/python-net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσας
- γραμμή σχήματος σκίτσας
- μορφοποίηση στυλ σύνδεσης
- συμπλήρωση διαβάθμισης
- συμπλήρωση μοτίβου
- συμπλήρωση εικόνας
- συμπλήρωση υφής
- συμπλήρωση συμπαγούς χρώματος
- διαφάνεια σχήματος
- απόδοση σχήματος ασπρόμαυρου
- απόδοση σχήματος σε γκρι κλίμακες
- περιστροφή σχήματος
- εφέ 3Δ λεπίδας
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Python χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γέμισης, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Δεδομένου ότι τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![Μορφοποίηση σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for Python παρέχει κλάσεις και ιδιότητες που σάς επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/python-net/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/python-net/aspose.slides/linedashstyle/) του σχήματος.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να μορφοποιήσετε ένα τετράγωνο `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Αποκτά τη πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέτει ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Αφαιρεί το γέμισμα από το σχήμα Rectangle ώστε να είναι ορατές μόνο οι γραμμές του.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Εφαρμόζει μορφοποίηση στις γραμμές του Rectangle.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Ορίζει το χρώμα για τη γραμμή του Rectangle.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Αποθηκεύει το αρχείο PPTX στο δίσκο.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σχεδίου Σκίτσας σε Γραμμές Σχήματος**

Ένα εφέ σκίτσας κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [Shape.line_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/line_format/) για πρόσβαση στις ρυθμίσεις γραμμής, [LineFormat.sketch_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/lineformat/sketch_format/) για πρόσβαση στις ρυθμίσεις σκίτσας και [SketchFormat.sketch_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/sketchformat/sketch_type/) για επιλογή τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/python-net/aspose.slides/linesketchtype/) .

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε ένα εφέ [LineSketchType.CURVED](https://reference.aspose.com/slides/el/python-net/aspose.slides/linesketchtype/), να διαβάσετε την ρητά καθορισμένη τιμή και να αφαιρέσετε το εφέ με [LineSketchType.NONE](https://reference.aspose.com/slides/el/python-net/aspose.slides/linesketchtype/) :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Πρόσβαση στη μορφή γραμμής του σχήματος και στη μορφή σκίτσας.
    sketch_format = shape.line_format.sketch_format

    # Εφαρμογή εφέ σκίτσας.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Ανάγνωση του εφέ σκίτσας που έχει αντιστοιχιστεί άμεσα στο σχήμα.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Αφαίρεση του εφέ σκίτσας.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Η τιμή που επιστρέφει η `SketchFormat.sketch_type` αντιπροσωπεύει τη ρύθμιση που έχει οριστεί άμεσα στο σχήμα. Εάν η μορφοποίηση γραμμής μπορεί να κληθεί από θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε [LineFormat.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/lineformat/get_effective/), αποκτήστε την ιδιότητα `sketch_format` του επιστρεφόμενου αντικειμένου και διαβάστε την ιδιότητα `sketch_type`. Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονόμησης:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Μορφοποίηση Στυλ Συνδέσεων**

Ακολουθούν οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές υπό γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε σχήμα με αιχμηρές γωνίες, μπορεί να προτιμάτε την επιλογή **Miter**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας Python δείχνει πώς δημιουργήθηκαν τρία τετράγωνα (όπως φαίνεται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Miter, Bevel και Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

	# Λαμβάνει την πρώτη διαφάνεια.
	slide = presentation.slides[0]

	# Προσθέτει τρία αυτόματα σχήματα τύπου Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Ορίζει το χρώμα γεμίσματος για κάθε σχήμα Rectangle.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Ορίζει το πλάτος της γραμμής.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Ορίζει το χρώμα για τη γραμμή κάθε Rectangle.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Ορίζει το στυλ σύνδεσης.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Προσθέτει κείμενο σε κάθε Rectangle.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Αποθηκεύει το αρχείο PPTX στο δίσκο.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Γραμμική Σμίξη (Gradient Fill)**

Στο PowerPoint, η Γραμμική Σμίξη (Gradient Fill) είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μίγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα σταδιακά να εξασθανά σε άλλο.

Ακολουθεί η διαδικασία για την εφαρμογή γραμμικής σμίξης σε σχήμα με το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `GRADIENT`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής `gradient_stops` που εκτίθεται από την κλάση [GradientFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/gradientformat/) .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε εφέ γραμμικής σμίξης σε μια έλλειψη:

```python
import aspose.slides as slides

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λαμβάνει την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέτει ένα αυτόματο σχήμα τύπου Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Εφαρμόζει μορφοποίηση διαβάθμισης στην έλλειψη.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Ορίζει την κατεύθυνση της διαβάθμισης.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Προσθέτει δύο σημεία διαβάθμισης.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Αποθηκεύει το αρχείο PPTX στο δίσκο.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η έλλειψη με γραμμική σμίξη](gradient-fill.png)

## **Γέμιση με Μοτίβο (Pattern Fill)**

Στο PowerPoint, η Γέμιση με Μοτίβο (Pattern Fill) είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο με δύο χρώματα — όπως τελείες, λωρίδες, διαγώνιες γραμμές ή σκαλαριστά — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προ‑καθορισμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και μετά την επιλογή προ‑καθορισμένου μοτίβου, μπορείτε να καθορίσετε ακριβώς τα χρώματα που θα χρησιμοποιηθούν.

Ακολουθεί η διαδικασία για την εφαρμογή γέμισης με μοτίβο σε σχήμα με το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `PATTERN`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προ‑καθορισμένες επιλογές.
1. Ορίστε το [back_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternformat/back_color/) του μοτίβου.
1. Ορίστε το [fore_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternformat/fore_color/) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε γέμιση με μοτίβο σε ένα τετράγωνο:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λαμβάνει την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέτει ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ορίζει τον τύπο γεμίσματος σε Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Ορίζει το στυλ μοτίβου.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Ορίζει τα χρώματα φόντου και προσκηνίου του μοτίβου.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Αποθηκεύει το αρχείο PPTX στο δίσκο.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το τετράγωνο με γέμιση μοτίβου](pattern-fill.png)

## **Γέμιση με Εικόνα (Picture Fill)**

Στο PowerPoint, η Γέμιση με Εικόνα (Picture Fill) είναι μια επιλογή μορφοποίησης που σας επιτρέπει να ενσωματώσετε μια εικόνα μέσα σε ένα σχήμα — χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί η διαδικασία για τη χρήση του Aspose.Slides ώστε να εφαρμόσετε γέμιση με εικόνα σε σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `PICTURE`.
1. Ορίστε τη λειτουργία γέμισης εικόνας σε `TILE` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Αναθέστε αυτήν την εικόνα στην ιδιότητα `picture.image` του `picture_fill_format` του σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας πούμε ότι έχουμε ένα αρχείο «lotus.png» με την παρακάτω εικόνα:

![Η εικόνα λωτόπλα στύλου](lotus.png)

Ο παρακάτω κώδικας Python δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```python
import aspose.slides as slides

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λαμβάνει την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέτει ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Ορίζει τον τύπο γεμίσματος σε Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ορίζει τη λειτουργία γέμισης εικόνας.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Φορτώνει μια εικόνα και την προσθέτει στους πόρους της παρουσίασης.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Ορίζει την εικόνα.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Αποθηκεύει το αρχείο PPTX στο δίσκο.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το σχήμα με γέμιση εικόνας](picture-fill.png)

### **Τίτλος Εικόνας ως Υφή (Tile Picture As Texture)**

Εάν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά επανάληψης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες ιδιότητες της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ορίζει τη λειτουργία γέμισης εικόνας — είτε `TILE` είτε `STRETCH` .
- [tile_alignment](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_alignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [tile_flip](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_flip/): Ελέγχει εάν το πλακίδιο αναστρέφεται οριζόντια, κάθετα ή και τα δύο.
- [tile_offset_x](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε πόντους) από το αρχικό σημείο του σχήματος.
- [tile_offset_y](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε πόντους) από το αρχικό σημείο του σχήματος.
- [tile_scale_x](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_scale_x/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [tile_scale_y](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_scale_y/): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω δείγμα κώδικα δείχνει πώς να προσθέσετε ένα σχήμα τετραγώνου με επαναλαμβανόμενη γέμιση εικόνας και να διαμορφώσετε τις επιλογές πλακιδίων:

```py
import aspose.slides as slides

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λαμβάνει την πρώτη διαφάνεια.
    first_slide = presentation.slides[0]

    # Προσθέτει ένα αυτόματο σχήμα τύπου Rectangle.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Ορίζει τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Φορτώνει την εικόνα και την προσθέτει στους πόρους της παρουσίασης.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Αναθέτει την εικόνα στο σχήμα.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Ρυθμίζει τη λειτουργία γέμισης εικόνας και τις ιδιότητες επαναληπτικότητας.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Αποθηκεύει το αρχείο PPTX στο δίσκο.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Συμπλήρωση Συμπαγούς Χρώματος (Solid Color Fill)**

Στο PowerPoint, η Συμπλήρωση Συμπαγούς Χρώματος (Solid Color Fill) είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε συμπλήρωση συμπαγούς χρώματος σε σχήμα με το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `SOLID`.
1. Εκχωρήστε το προτιμώμενο χρώμα γέμισης στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε συμπλήρωση συμπαγούς χρώματος σε ένα τετράγωνο σε διαφάνεια PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λαμβάνει την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέτει ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ορίζει τον τύπο γεμίσματος σε Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Ορίζει το χρώμα γέμισης.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Αποθηκεύει το αρχείο PPTX στο δίσκο.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το σχήμα με συμπαγή γέμιση χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας (Set Transparency)**

Στο PowerPoint, όταν εφαρμόζετε συμπαγές χρώμα, γραμμική σμίξη, εικόνα ή υφή ως γέμιση σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια της γέμισης. Μεγαλύτερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο παρασκήνιο ή στα υποκείμενα αντικείμενα να είναι εν μέρει ορατά.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha του χρώματος που χρησιμοποιείται για τη γέμιση. Ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το τύπο γέμισης σε `SOLID`.
1. Χρησιμοποιήστε `Color.from_argb` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε χρώμα γέμισης με διαφάνεια σε ένα τετράγωνο:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λαμβάνει την πρώτη διαφάνεια.
    slide = presentation.slides[0]
    
    # Προσθέτει ένα συμπαγές αυτόματο σχήμα Rectangle.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Προσθέτει ένα διαφανές αυτόματο σχήμα Rectangle πάνω από το συμπαγές σχήμα.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το ημιδιαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων (Rotate Shapes)**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο κατά την τοποθέτηση οπτικών στοιχείων με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές ανάγκες.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα `rotation` του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```python
import aspose.slides as slides

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λαμβάνει την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέτει ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Περιστρέφει το σχήμα κατά 5 μοίρες.
    shape.rotation = 5

    # Αποθηκεύει το αρχείο PPTX στο δίσκο.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3D Εφέ Λεπίδας (Add 3D Bevel Effects)**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε 3D εφέ λεπίδας σε σχήματα ρυθμίζοντας τις ιδιότητες [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/) .

Για να προσθέσετε 3D εφέ λεπίδας σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λεπίδας.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε 3D εφέ λεπίδας σε ένα σχήμα:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργεί ένα αντικείμενο της κλάσης Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Προσθέτει ένα σχήμα στη διαφάνεια.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Ορίζει τις ιδιότητες ThreeDFormat του σχήματος.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Αποθηκεύει την παρουσίαση ως αρχείο PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το 3D εφέ λεπίδας](3D-bevel-effect.png)

## **Προσθήκη 3D Εφέ Περιστροφής (Add 3D Rotation Effects)**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε 3D εφέ περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/) .

Για να εφαρμόσετε 3D περιστροφή σε ένα σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε τις ιδιότητες [camera_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/camera/camera_type/) και [light_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/lightrig/light_type/) του σχήματος για να ορίσετε την 3D περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε 3D εφέ περιστροφής σε ένα σχήμα:

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο της κλάσης Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Αποθηκεύει την παρουσίαση ως αρχείο PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το 3D εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Εμφάνισης σε Μαυρό‑Άσπρο για Σχήματα (Control Black-and-White Rendering for Shapes)**

Η ιδιότητα [Shape.black_white_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/black_white_mode/) καθορίζει πώς ένα μεμονωμένο σχήμα αποδίδεται όταν μια παρουσίαση προβάλλεται ή επεξεργάζεται σε λειτουργία μαυρό‑ασπρου. Δεν ενεργοποιεί αυτή τη λειτουργία από μόνη της και δεν αλλάζει τη γέμιση, τη γραμμή ή άλλη μορφοποίηση του σχήματος σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/el/python-net/aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, το `AUTOMATIC` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `GRAY` και `LIGHT_GRAY` χρησιμοποιούν γκρι χρώματα, το `BLACK_WHITE` χρησιμοποιεί μόνο μαύρο και λευκό, τα `BLACK` και `WHITE` επιβάλλουν ένα ενιαίο χρώμα, το `COLOR` διατηρεί το κανονικό χρώμα, και το `HIDDEN` παραλείπει το σχήμα στη λειτουργία μαυρό‑ασπρου. Το `NOT_DEFINED` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας Python δημιουργεί ένα χρωματιστό σχήμα και το κάνει να εμφανίζεται γκρι σε λειτουργία μαυρό‑ασπρου:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Διατηρεί το πορτοκαλί γέμισμα σε χρωματική λειτουργία, αλλά αποδίδει το σχήμα με γκρίζο χρώμα σε λειτουργία ασπρόμαυρου.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Σε κανονική χρωματική λειτουργία, το τετράγωνο διατηρεί το πορτοκαλί γέμισμα του. Σε ροή εργασίας μαυρό‑ασπρου, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί στο `GRAY`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια ενώ ορίζετε ξεχωριστή εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις εμφάνισης μαυρό‑ασπρου της παρουσίασης.

## **Επαναφορά Μορφοποίησης (Reset Formatting)**

Ο παρακάτω κώδικας Python δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με σύμβολα στην [LayoutSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Επαναφορά κάθε σχήματος στη διαφάνεια που έχει σύμβολο θέσης στη διάταξη.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι των σχημάτων όπως τα χρώματα, τα εφέ και οι διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος — γέμιση, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι ταυτοί και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο σετ διαφανειών ή σε αρχείο .POTX. Κατά τη δημιουργία νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.