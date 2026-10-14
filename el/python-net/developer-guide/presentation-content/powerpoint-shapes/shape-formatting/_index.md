---
title: Μορφοποίηση Σχημάτων PowerPoint σε Python
linktitle: Μορφοποίηση Σχημάτων
type: docs
weight: 20
url: /el/python-net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσου
- γραμμή σχήματος σκίτσου
- μορφοποίηση στυλ σύνδεσης
- συμπλήρωση διαβάθμισης
- συμπλήρωση μοτίβου
- συμπλήρωση εικόνας
- συμπλήρωση υφής
- συμπλήρωση μονής απόχρωσης
- διαφάνεια σχήματος
- μαυρό-λευκή απόδοση σχήματος
- απόδοση σχήματος σε γκρι αποχρώσεις
- περιστροφή σχήματος
- εφέ 3Δ καμπυλωτότητας
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Python χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περίγραμμα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν το πώς γεμίζει το εσωτερικό τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Η Aspose.Slides for Python παρέχει κλάσεις και ιδιότητες που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Με τη χρήση της Aspose.Slides, μπορείτε να καθορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πλάτος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) του σχήματος.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Αφαίρεση του γεμίσματος από το ορθογώνιο σχήμα ώστε να είναι ορατές μόνο οι γραμμές του.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Εφαρμογή μορφοποίησης στις γραμμές του ορθογώνιου.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Ορισμός χρώματος για τη γραμμή του ορθογώνιου.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σχέδια Εφέ στις Γραμμές Σχήματος**

Ένα εφέ σκίτσο κάνει τη γραμμή ενός σχήματος να φαίνεται χερουργογραφημένη. Χρησιμοποιήστε [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) για πρόσβαση στις ρυθμίσεις γραμμής, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) για πρόσβαση στις ρυθμίσεις σκίτσου και [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) .

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Πρόσβαση στη μορφοποίηση γραμμής του σχήματος και στη μορφοποίηση σκίτσου.
    # Εφαρμογή εφέ σκίτσου.
    # Ανάγνωση του εφέ σκίτσου που έχει εκχωρηθεί άμεσα στο σχήμα.
    # Αφαίρεση του εφέ σκίτσου.
    sketch_format = shape.line_format.sketch_format

    sketch_format.sketch_type = slides.LineSketchType.CURVED

    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Η τιμή που επιστρέφει το `SketchFormat.sketch_type` αντιπροσωπεύει τη ρύθμιση που έχει οριστεί απευθείας στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληθεί από ένα θέμα, τη κύρια διαφάνεια ή τη διαφάνεια διάταξης, χρησιμοποιήστε το [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) , προσπελάστε την ιδιότητα `sketch_format` του επιστρεφόμενου αντικειμένου και διαβάστε την ιδιότητα `sketch_type`. Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομικότητας:

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

## **Μορφοποίηση Στυλ Σύνδεσης**

Ακολουθούν οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές υπό γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με κοφτές γωνίες, μπορεί να προτιμάτε την επιλογή **Miter**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας Python δείχνει πώς τρία ορθογώνια (όπως φαίνονται στην εικόνα παραπάνω) δημιουργήθηκαν χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Miter, Bevel και Round :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

	# Λάβετε την πρώτη διαφάνεια.
	slide = presentation.slides[0]

	# Προσθήκη τριών αυτόματων σχημάτων τύπου Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Ορίστε το χρώμα γεμίσματος για κάθε ορθογώνιο σχήμα.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Ορίστε το πλάτος γραμμής.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Ορίστε το χρώμα της γραμμής για κάθε ορθογώνιο.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Ορίστε το στυλ σύνδεσης.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Προσθήκη κειμένου σε κάθε ορθογώνιο.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Αποθήκευση του αρχείου PPTX στον δίσκο.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Γραμμική Συμπλήρωση (Gradient Fill)**

Στο PowerPoint, η Gradient Fill είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μίγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα έτσι ώστε το ένα να εξασθενίζει σταδιακά στο άλλο.

Ακολουθεί η διαδικασία για την εφαρμογή γραμμικής συμπλήρωσης σε σχήμα με τη χρήση Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) του σχήματος σε `GRADIENT` .
1. Προσθέστε τα δύο προτιμώμενα χρώματα με ορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής `gradient_stops` που εκτίθεται από την κλάση [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) .
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε ένα εφέ gradient fill σε μια έλλειψη:

```python
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη αυτόματου σχήματος τύπου Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Εφαρμογή μορφοποίησης διαβάθμισης στην έλλειψη.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Ορίστε την κατεύθυνση του gradient.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Προσθήκη δύο σημείων gradient.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η έλλειψη με γραμμική συμπλήρωση](gradient-fill.png)

Εάν ένα gradient εμφανίζεται διαφορετικά σε μια εξαχθείσα εικόνα σε σχέση με το PowerPoint, δείτε [Choose a Gradient Rendering Style](/slides/el/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ εμφάνισης χωρίς να αλλάξετε τη gradient συμπλήρωση αποθηκευμένη στην παρουσίαση.

## **Συμπλήρωση με Σχέδια (Pattern Fill)**

Στο PowerPoint, το Pattern Fill είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχεδιαστικό μοτίβο δύο χρωμάτων — όπως κουκκίδες, ρίγες, διασταυρωτά ή σκαλοπάτια — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Η Aspose.Slides παρέχει πάνω από 45 προορισμένους στυλ μοτίβων που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική απήχηση των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προεπιλεγμένο μοτίβο, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιήσει.

Ακολουθεί η διαδικασία για την εφαρμογή pattern fill σε σχήμα με τη χρήση Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) του σχήματος σε `PATTERN` .
1. Επιλέξτε στυλ μοτίβου από τις προεπιλογές.
1. Ορίστε το [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) του μοτίβου.
1. Ορίστε το [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε pattern fill σε ένα ορθογώνιο:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Ορίστε το στυλ μοτίβου.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το ορθογώνιο με pattern fill](pattern-fill.png)

## **Συμπλήρωση με Εικόνα (Picture Fill)**

Στο PowerPoint, το Picture Fill είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα — χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί πώς να χρησιμοποιήσετε το Aspose.Slides για να εφαρμόσετε picture fill σε σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) του σχήματος σε `PICTURE` .
1. Ορίστε τη λειτουργία picture fill σε `TILE` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Εκχωρήστε αυτήν την εικόνα στην ιδιότητα `picture.image` του `picture_fill_format` του σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ας πούμε ότι έχουμε ένα αρχείο "lotus.png" με την παρακάτω εικόνα:

![Η εικόνα lotus](lotus.png)

Ο παρακάτω κώδικας Python δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```python
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ορίστε τη λειτουργία picture fill.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Ορίστε την εικόνα.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το σχήμα με picture fill](picture-fill.png)

### **Τίτλος Εικόνας ως Υφή (Tile Picture As Texture)**

Εάν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά επαναληπτικής εμφάνισης, μπορείτε να χρησιμοποιήσετε τις παρακάτω ιδιότητες της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) : Ορίζει τη λειτουργία picture fill — είτε `TILE` είτε `STRETCH` .
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/) : Καθορίζει την ευθυγράμμιση των μοτίβων εντός του σχήματος.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/) : Ελέγχει αν το μοτίβο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/) : Ορίζει την οριζόντια απόσταση του μοτίβου (σε points) από το αρχικό σημείο του σχήματος.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/) : Ορίζει την κατακόρυφη απόσταση του μοτίβου (σε points) από το αρχικό σημείο του σχήματος.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/) : Καθορίζει την οριζόντια κλίμακα του μοτίβου ως ποσοστό.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/) : Καθορίζει την κατακόρυφη κλίμακα του μοτίβου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με επαναλαμβανόμενη picture fill και να διαμορφώσετε τις επιλογές του μοτίβου:

```py
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    first_slide = presentation.slides[0]

    # Προσθήκη αυτόματου ορθογώνιου σχήματος.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Αντιστοιχίστε την εικόνα στο σχήμα.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Ρυθμίστε τη λειτουργία picture fill και τις ιδιότητες επαναλαμβανόμενης εμφάνισης.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι επιλογές του μοτίβου](tile-options.png)

## **Συμπλήρωση με Σταθερό Χρώμα (Solid Color Fill)**

Στο PowerPoint, η Solid Color Fill είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς gradient, υφές ή μοτίβα.

Για να εφαρμόσετε solid color fill σε σχήμα με τη χρήση Aspose.Slides, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) του σχήματος σε `SOLID` .
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε solid color fill σε ένα ορθογώνιο σε μια διαφάνεια PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ορίστε τον τύπο γεμίσματος σε Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Ορίστε το χρώμα γεμίσματος.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το σχήμα με solid color fill](solid-color-fill.png)

## **Ορισμός Διαφάνειας (Set Transparency)**

Στο PowerPoint, όταν εφαρμόζετε solid color, gradient, picture ή texture fill σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι εν μέρει ορατά.

Η Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθεί η διαδικασία:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το τύπο γεμίσματος σε `SOLID` .
1. Χρησιμοποιήστε `Color.from_argb` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε διαφανές χρώμα γεμίσματος σε ένα ορθογώνιο:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]
    
    # Προσθήκη αυτόματου στερεού ορθογωνίου σχήματος.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Προσθήκη διαφανούς αυτόματου ορθογωνίου σχήματος πάνω από το στερεό σχήμα.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων (Rotate Shapes)**

Η Aspose.Slides σας επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα `rotation` του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```python
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Στρέψτε το σχήμα κατά 5 μοίρες.
    shape.rotation = 5

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3D Εφέ Καμπυλωτότητας (Add 3D Bevel Effects)**

Η Aspose.Slides επιτρέπει την εφαρμογή 3D bevel effects σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) .

Για να προσθέσετε 3D bevel effects σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις bevel.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε 3D bevel effects σε σχήμα:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Προσθήκη σχήματος στη διαφάνεια.
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

![Το 3D bevel effect](3D-bevel-effect.png)

## **Προσθήκη 3D Εφέ Περιστροφής (Add 3D Rotation Effects)**

Η Aspose.Slides επιτρέπει την εφαρμογή 3D rotation effects σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) .

Για να εφαρμόσετε 3D rotation σε σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Λάβετε αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) και το [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) του σχήματος για να ορίσετε την 3D περιστροφή.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε 3D rotation effects σε σχήμα:

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

![Το 3D rotation effect](3D-rotation-effect.png)

## **Έλεγχος Μαυρό-Λευκής Απόδοσης για Σχήματα (Control Black-and-White Rendering for Shapes)**

Η ιδιότητα [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν η παρουσία παρουσιάζεται ή επεξεργάζεται σε κατάσταση μαυρό-λευκού. Δεν ενεργοποιεί αυτόματα την εμφάνιση μαυρό-λευκού, ούτε αλλάζει τη συμπλήρωση, τη γραμμή ή άλλη μορφοποίηση σε κανονική έγχρωμη λειτουργία.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, `AUTOMATIC` επιτρέπει στην εφαρμογή απόδοσης να επιλέξει τη μετατροπή, `GRAY` και `LIGHT_GRAY` χρησιμοποιούν γκρι αποχρώσεις, `BLACK_WHITE` χρησιμοποιεί μόνο μαύρο και λευκό, `BLACK` και `WHITE` αναγκάζουν ένα ενιαίο χρώμα, `COLOR` διατηρεί την κανονική χρωματική απόδοση, και `HIDDEN` παραλείπεται το σχήμα σε κατάσταση μαυρό-λευκού. `NOT_DEFINED` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας Python δημιουργεί ένα χρωματιστό σχήμα και το κάνει να εμφανίζεται γκρι σε λειτουργία μαυρό-λευκού:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Διατηρήστε το πορτοκαλί γέμισμα σε έγχρωμη λειτουργία, αλλά αποδώστε το σχήμα με γκρι χρώμα σε κατάσταση μαυρό-λευκού.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Σε κανονική έγχρωμη λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμά του. Σε μια ροή εργασίας μαυρό-λευκού, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί σε `GRAY`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρη χρωματική διαφάνεια ενώ ορίζετε μια ξεχωριστή εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις λήψης λευκού-μαύρου της παρουσίασης.

## **Επαναφορά Μορφοποίησης (Reset Formatting)**

Ο παρακάτω κώδικας Python δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στην [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) στην προεπιλεγμένη τους κατάσταση:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Επαναφορά κάθε σχήματος στη διαφάνεια που έχει placeholder στη διάταξη.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις (FAQ)**

**Επηρεάζει η μορφοποίηση του σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι του σχήματος όπως τα χρώματα, τα εφέ και τα gradient αποθηκεύονται ως μεταδεδομένα και προσθέτουν πρακτικά κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος — τις ρυθμίσεις γεμίσματος, γραμμής και εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι ίδια και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο σετ διαφανειών ή σε αρχείο προτύπου .POTX. Κατά τη δημιουργία μιας νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλιζαρισμένα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.