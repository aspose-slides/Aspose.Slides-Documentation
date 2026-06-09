---
title: "Διαμόρφωση Σχημάτων PowerPoint σε Python"
linktitle: "Διαμόρφωση Σχημάτων"
type: docs
weight: 20
url: /el/python-net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- μορφοποίηση στυλ ένωσης
- γέμισμα διαβάθμισης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα στερεού χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3D κοπής
- εφέ 3D περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώνετε σχήματα PowerPoint σε Python χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Δεδομένου ότι τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν τον τρόπο με τον οποίο γεμίζονται τα εσωτερικά τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides για Python παρέχει κλάσεις και ιδιότητες που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που είναι διαθέσιμες στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/python-net/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [στυλ διακεκομμένων](https://reference.aspose.com/slides/el/python-net/aspose.slides/linedashstyle/) του σχήματος.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Ορίστε το χρώμα γεμίσματος για το σχήμα Rectangle.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Εφαρμόστε μορφοποίηση στις γραμμές του Rectangle.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Ορίστε το χρώμα για τη γραμμή του Rectangle.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Μορφοποίηση Στυλ Συνένωσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Στρογγυλό
* Κωνικό
* Καμπυλωτό

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές υπό γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με οξυγώνιες γωνίες, μπορείτε να προτιμήσετε την επιλογή **Κωνικό**.

![Το στυλ συνένωσης στην παρουσίαση](join-style-powerpoint.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

	# Λάβετε την πρώτη διαφάνεια.
	slide = presentation.slides[0]

	# Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Ορίστε το χρώμα γεμίσματος για κάθε σχήμα Rectangle.
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

	# Ορίστε το χρώμα για τη γραμμή του κάθε Rectangle.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Ορίστε το στυλ ένωσης.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Προσθέστε κείμενο σε κάθε Rectangle.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Αποθηκεύστε το αρχείο PPTX στον δίσκο.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Γέμισμα Διαβάθμισης**

Στο PowerPoint, το Γέμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε μια συνεχόμενη ανάμειξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τέτοιο τρόπο ώστε το ένα να εξασθενεί σταδιακά στο άλλο.

Ακολουθήστε τα παρακάτω βήματα για να εφαρμόσετε γέμισμα διαβάθμισης σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `GRADIENT`.
1. Προσθέστε τα δύο προτιμώμενα χρώματα με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής `gradient_stops` που εκτίθεται από την κλάση [GradientFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/gradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```python
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Έλλειψη.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Εφαρμόστε μορφοποίηση διαβάθμισης στην Έλλειψη.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Ορίστε την κατεύθυνση της διαβάθμισης.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Προσθέστε δύο σημεία διαβάθμισης.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

## **Γέμισμα Μοτίβου**

Στο PowerPoint, το Γέμισμα Μοτίβου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο δύο χρωμάτων—όπως κουκκίδες, λωρίδες, τεττάγωνα ή σκαλιστά—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του μοτίβου.

Το Aspose.Slides προσφέρει πάνω από 45 προεγκατεστημένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να βελτιώσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προεγκατεστημένο μοτίβο, μπορείτε να καθορίσετε ακριβώς τα χρώματα που θα χρησιμοποιηθούν.

Ακολουθήστε τα παρακάτω βήματα για να εφαρμόσετε γέμισμα μοτίβου σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `PATTERN`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεγκατεστημένες επιλογές.
1. Ορίστε το [back_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternformat/back_color/) του μοτίβου.
1. Ορίστε το [fore_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternformat/fore_color/) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Ορίστε το στυλ μοτίβου.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα μοτίβου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Στο PowerPoint, το Γέμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθήστε τα παρακάτω βήματα για να χρησιμοποιήσετε το Aspose.Slides ώστε να εφαρμόσετε γέμισμα εικόνας σε σχήμα:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `PICTURE`.
1. Ορίστε τη λειτουργία γέμωσης εικόνας σε `TILE` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Αναθέστε αυτήν την εικόνα στην ιδιότητα `picture.image` του `picture_fill_format` του σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

![Η εικόνα λωτού](lotus.png)

```python
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ορίστε τη λειτουργία γέμωσης εικόνας.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Ορίστε την εικόνα.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Tile Picture As Texture**

Εάν θέλετε να ορίσετε μια πλακοποιημένη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά του πλακιδίου, μπορείτε να χρησιμοποιήσετε τις παρακάτω ιδιότητες της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ορίζει τη λειτουργία γέμωσης εικόνας—είτε `TILE` είτε `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_alignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [tile_flip](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_flip/): Ελέγχει εάν το πλακίδιο θα αντιστραφεί οριζόντια, κατακόρυφα ή και τα δύο.
- [tile_offset_x](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε points) από το σημείο έναρξης του σχήματος.
- [tile_offset_y](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ορίζει την κατακόρυφη μετατόπιση του πλακιδίου (σε points) από το σημείο έναρξης του σχήματος.
- [tile_scale_x](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_scale_x/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [tile_scale_y](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/tile_scale_y/): Ορίζει την κατακόρυφη κλίμακα του πλακιδίου ως ποσοστό.

```py
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    first_slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Αναθέστε την εικόνα στο σχήμα.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Ρυθμίστε τη λειτουργία γέμωσης εικόνας και τις ιδιότητες πλακιδίων.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Γέμισμα Σταθερού Χρώματος**

Στο PowerPoint, το Γέμισμα Σταθερού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα μοναδικό, ομοιόμορφο χρώμα. Αυτό το ενιαίο χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε γέμισμα σταθερού χρώματος σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του σχήματος σε `SOLID`.
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ορίστε τον τύπο γεμίσματος σε Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Ορίστε το χρώμα γεμίσματος.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα σταθερού χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γέμισμα στερεού χρώματος, διαβάθμισης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας καθιστά το σχήμα πιο διαυγή, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας προσαρμόζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Δείτε πώς:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το τύπο γεμίσματος σε `SOLID`.
1. Χρησιμοποιήστε `Color.from_argb` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

    # Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
    with slides.Presentation() as presentation:

        # Λάβετε την πρώτη διαφάνεια.
        slide = presentation.slides[0]
        
        # Προσθέστε ένα στερεό αυτόματο σχήμα Rectangle.
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

        # Προσθέστε ένα διαφανές αυτόματο σχήμα Rectangle πάνω από το στερεό σχήμα.
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
        
        presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διάφανο σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σάς επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν θέλετε να τοποθετήσετε οπτικά στοιχεία με συγκεκριμένη στοίχιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα `rotation` του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Περιστρέψτε το σχήμα κατά 5 μοίρες.
    shape.rotation = 5

    # Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ 3Δ Κοπής**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε εφέ 3Δ κοπής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/).

Για να προσθέσετε εφέ 3Δ κοπής σε σχήμα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις κοπής.
1. Αποθηκεύστε την παρουσίαση.

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

![Το εφέ 3Δ κοπής](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3Δ Περιστροφής**

Το Aspose.Slides σάς επιτρέπει να εφαρμόσετε εφέ 3Δ περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε σχήμα:

1. Δημιουργήστε μια παρουσία της [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάσης.
1. Λάβετε αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [camera_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/camera/camera_type/) και το [light_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/lightrig/light_type/) του σχήματος για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

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

![Το εφέ 3Δ περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης**

Το παρακάτω κώδικα Python δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με σύμβολα στο [LayoutSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Επαναφορά κάθε σχήματος στη διαφάνεια που έχει σύμβολο κράτησης στη διάταξη.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου, ενώ οι παράμετροι των σχημάτων όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν σχεδόν κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος—γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ ως ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχημάτων σε ξεχωριστό αρχείο για χρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο αρχείο παρουσίασης ή σε αρχείο .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλ σχήματος που χρειάζεστε και επαναεφαρμόστε τη μορφοποίησή τους όπου απαιτείται.