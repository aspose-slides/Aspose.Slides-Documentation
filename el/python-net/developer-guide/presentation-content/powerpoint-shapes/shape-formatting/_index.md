---
title: Διαμόρφωση Σχημάτων PowerPoint σε Python
linktitle: Διαμόρφωση Σχημάτων
type: docs
weight: 20
url: /el/python-net/shape-formatting/
keywords:
- διαμόρφωση σχήματος
- διαμόρφωση γραμμής
- εφέ σκίτσο
- γραμμή σχήματος σκίτσο
- διαμόρφωση στυλ συνένωσης
- γέμισμα διαβάθμισης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα συμπαγούς χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3D bevel
- εφέ 3D περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώνετε σχήματα PowerPoint σε Python χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε αυτές τις γραμμές τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζει το εσωτερικό τους.

![format-shape-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides για Python παρέχει κλάσεις και ιδιότητες που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Διαμόρφωση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/el/python-net/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/el/python-net/aspose.slides/linedashstyle/) του σχήματος.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Πάρτε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Ορίστε το χρώμα γεμίσματος για το σχήμα rectangle.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Εφαρμόστε μορφοποίηση στις γραμμές του rectangle.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Ορίστε το χρώμα για τη γραμμή του rectangle.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The formatted lines in the presentation](formatted-lines.png)

## **Εφαρμογή Sketch Εφέ στις Γραμμές του Σχήματος**

Ένα sketch εφέ κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε το [Shape.line_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/line_format/) για πρόσβαση στις ρυθμίσεις της γραμμής, το [LineFormat.sketch_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/lineformat/sketch_format/) για πρόσβαση στις ρυθμίσεις sketch, και το [SketchFormat.sketch_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/sketchformat/sketch_type/) για επιλογή τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/python-net/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.CURVED](https://reference.aspose.com/slides/el/python-net/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά ορισμένη τιμή, και να αφαιρέσετε το εφέ με το [LineSketchType.NONE](https://reference.aspose.com/slides/el/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Πρόσβαση στη μορφή γραμμής του σχήματος και στη μορφή sketch του.
    sketch_format = shape.line_format.sketch_format

    # Εφαρμογή εφέ σκίτσου.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Ανάγωση του εφέ σκίτσου που έχει οριστεί άμεσα στο σχήμα.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Αφαίρεση του εφέ σκίτσου.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Η τιμή που επιστρέφει το `SketchFormat.sketch_type` αντιπροσωπεύει τη ρύθμιση που έχει οριστεί άμεσα στο σχήμα. Εάν η διαμόρφωση της γραμμής μπορεί να κληρονομηθεί από ένα θέμα, κύρια διαφάνεια ή διάταξη διαφάνειας, χρησιμοποιήστε το [LineFormat.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/lineformat/get_effective/), προσπελάστε την ιδιότητα `sketch_format` του επιστρεφόμενου αντικειμένου και διαβάστε την ιδιότητα `sketch_type`. Η αποτελεσματική τιμή αντικατοπτρίζει τη διαμόρφωση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονόμησης:

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

## **Διαμόρφωση Στυλ Συνένωσης**

Αυτές είναι οι τρεις επιλογές τύπου συνένωσης:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές με γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με αιχμηρές γωνίες, μπορείτε να προτιμήσετε την επιλογή **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Ο παρακάτω κώδικας Python δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνονται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου συνένωσης Miter, Bevel και Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

	# Πάρτε την πρώτη διαφάνεια.
	slide = presentation.slides[0]

	# Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Ορίστε το χρώμα γεμίσματος για κάθε σχήμα rectangle.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Ορίστε το πάχος της γραμμής.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Ορίστε το χρώμα για τη γραμμή κάθε rectangle.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Ορίστε το στυλ συνένωσης.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Προσθέστε κείμενο σε κάθε rectangle.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Αποθηκεύστε το αρχείο PPTX στο δίσκο.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Γέμισμα Διαβάθμισης**

Στο PowerPoint, το Gradient Fill είναι μια επιλογή διαμόρφωσης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μίγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τέτοιο τρόπο ώστε το ένα να ξεθωριάζει σταδιακά στο άλλο.

Ακολουθεί ο τρόπος για να εφαρμόσετε γέμισμα διαβάθμισης σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `GRADIENT`.
1. Προσθέστε τα δύο προτιμούντα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής `gradient_stops` που εκτίθεται από την κλάση [GradientFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/gradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε εφέ γέμισμα διαβάθμισης σε μια έλλειψη:

```python
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Πάρτε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Εφαρμόστε διαβαθμισμένη μορφοποίηση στην έλλειψη.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Ορίστε την κατεύθυνση της διαβάθμισης.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Προσθέστε δύο σταθμούς διαβάθμισης.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The ellipse with gradient fill](gradient-fill.png)

## **Γέμισμα Σχεδίου**

Στο PowerPoint, το Pattern Fill είναι μια επιλογή διαμόρφωσης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο δύο χρωμάτων—όπως κουκίδες, λωρίδες, διασχίσεις ή σκακιές—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προκαθορισμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεων σας. Ακόμη και αφού επιλέξετε ένα προκαθορισμένο μοτίβο, μπορείτε να καθορίσετε ακριβώς τα χρώματα που θα χρησιμοποιήσει.

Ακολουθεί ο τρόπος να εφαρμόσετε γέμισμα μοτίβου σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `PATTERN`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [back_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternformat/back_color/) του μοτίβου.
1. Ορίστε το [fore_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternformat/fore_color/) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε γέμισμα μοτίβου σε ένα ορθογώνιο:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Πάρτε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Ορίστε το στυλ του μοτίβου.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The rectangle with pattern fill](pattern-fill.png)

## **Γέμισμα Εικόνας**

Στο PowerPoint, το Picture Fill είναι μια επιλογή διαμόρφωσης που σας επιτρέπει να ενσωματώσετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί ο τρόπος χρήσης του Aspose.Slides για να εφαρμόσετε γέμισμα εικόνας σε ένα σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `PICTURE`.
1. Ορίστε τη λειτουργία γέμισματος εικόνας σε `TILE` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Εκχωρήστε αυτήν την εικόνα στην ιδιότητα `picture.image` του `picture_fill_format` του σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε το αρχείο «lotus.png» με την ακόλουθη εικόνα:

![The lotus picture](lotus.png)

Ο παρακάτω κώδικας Python δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```python
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Πάρτε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ορίστε τη λειτουργία γεμίσματος εικόνας.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Ορίστε την εικόνα.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The shape with picture fill](picture-fill.png)

### **Τοποθέτηση Εικόνας σε Υφή**

Αν θέλετε να ορίσετε μια τοποθετημένη (tiled) εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της τοποθέτησης, μπορείτε να χρησιμοποιήσετε τις παρακάτω ιδιότητες της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ορίζει τη λειτουργία γεμίσματος εικόνας—είτε `TILE` είτε `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_alignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [tile_flip](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_flip/): Ελέγχει αν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [tile_offset_x](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [tile_offset_y](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ορίζει τη κάθετη μετατόπιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [tile_scale_x](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_scale_x/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [tile_scale_y](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_scale_y/): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με τοποθετημένο γέμισμα εικόνας και να ρυθμίσετε τις επιλογές πλακιδίων:

```py
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Πάρτε την πρώτη διαφάνεια.
    first_slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Αντιστοιχίστε την εικόνα στο σχήμα.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Διαμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες τοποθέτησης.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The tile options](tile-options.png)

## **Γέμισμα Συμπαγούς Χρώματος**

Στο PowerPoint, το Solid Color Fill είναι μια επιλογή διαμόρφωσης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό φόντο εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε γέμισμα συμπαγούς χρώματος σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `SOLID`.
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε γέμισμα συμπαγούς χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Πάρτε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ορίστε τον τύπο γεμίσματος σε Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Ορίστε το χρώμα γεμίσματος.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The shape with solid color fill](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γέμισμα συμπαγούς χρώματος, διαβάθμησης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθεί η διαδικασία:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέτε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το τύπο γέμισματος σε `SOLID`.
1. Χρησιμοποιήστε `Color.from_argb` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε χρώμα γεμίσματος με διαφάνεια σε ένα ορθογώνιο:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Πάρτε την πρώτη διαφάνεια.
    slide = presentation.slides[0]
    
    # Προσθέστε ένα συμπαγές αυτόματο σχήμα Rectangle.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Προσθέστε ένα διαφανές αυτόματο σχήμα Rectangle πάνω από το συμπαγές σχήμα.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The transparent shape](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν θέλετε να ευθυγραμμίσετε οπτικά στοιχεία με συγκεκριμένες απαιτήσεις σχεδίασης.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα `rotation` του σχήματος στη ζητούμενη γωνία.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```python
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Πάρτε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Περιστρέψτε το σχήμα κατά 5 μοίρες.
    shape.rotation = 5

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The shape rotation](shape-rotation.png)

## **Προσθήκη 3D Εφέ Bevel**

Το Aspose.Slides επιτρέπει την εφαρμογή 3D bevel εφέ σε σχήματα διαμορφώνοντας τις ιδιότητες της κλάσης [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/).

Για να προσθέσετε 3D bevel εφέ σε ένα σχήμα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις bevel.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python εμφανίζει πώς να εφαρμόσετε 3D bevel εφέ σε ένα σχήμα:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Προσθέστε ένα σχήμα στη διαφάνεια.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Ορίστε τις ιδιότητες ThreeDFormat του σχήματος.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The 3D bevel effect](3D-bevel-effect.png)

## **Προσθήκη 3D Εφέ Περιστροφής**

Το Aspose.Slides επιτρέπει την εφαρμογή 3D εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες της κλάσης [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/).

Για να εφαρμόσετε 3D περιστροφή σε ένα σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε τις ιδιότητες [camera_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/camera/camera_type/) και [light_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/lightrig/light_type/) του σχήματος για να ορίσετε την 3D περιστροφή.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε 3D εφέ περιστροφής σε ένα σχήμα:

```python
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The 3D rotation effect](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας Python δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στη [LayoutSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Επαναφορά κάθε σχήματος στη διαφάνεια που έχει placeholder στη διάταξη.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου, ενώ παράμετροι όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικό επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος—γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη διαχείριση στυλ στο μέλλον.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για χρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο αρχείο παρουσίασης ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλσχημάτων που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.