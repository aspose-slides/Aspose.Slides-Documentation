---
title: Διαμόρφωση Σχημάτων PowerPoint σε Python μέσω Java
linktitle: Διαμόρφωση Σχημάτων
type: docs
weight: 20
url: /el/python-java/shape-formatting/
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
- συμπαγές γέμισμα χρώματος
- διαφάνεια σχήματος
- ασπρόμαυρη απόδοση σχήματος
- απόδοση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ 3Δ κβάλας
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώσετε σχήματα PowerPoint σε Python μέσω Java χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περίγραμμα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα ορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![format-shape-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides for Python μέσω Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Με το Aspose.Slides, μπορείτε να καθορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Ορισμός του χρώματος γεμίσματος για το σχήμα Rectangle.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Εφαρμογή μορφοποίησης στις γραμμές του Rectangle.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Ορισμός του χρώματος για τη γραμμή του Rectangle.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The formatted lines in the presentation](formatted-lines.png)

## **Εφαρμογή Σχεδίου Σκίτσωσης στις Γραμμές Σχήματος**

Ένα εφέ σκίτσωσης κάνει τη γραμμή του σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) για να αποκτήσετε πρόσβαση στις ρυθμίσεις γραμμής, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) για να αποκτήσετε πρόσβαση στις ρυθμίσεις σκίτσωσης, και [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved), να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Πρόσβαση στη μορφοποίηση γραμμής του σχήματος και στη μορφή σκίτσου.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Εφαρμογή εφέ σκίτσου.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Ανάγνωση του εφέ σκίτσου που έχει ανατεθεί άμεσα στο σχήμα.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Αφαίρεση του εφέ σκίτσου.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Η τιμή που επιστρέφεται από το [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληθεί από ένα θέμα, κύρια διαφάνεια ή διάταξη διαφάνειας, χρησιμοποιήστε το [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective), αποκτήστε πρόσβαση στο `LineFormatEffectiveData.getSketchFormat` και διαβάστε το `SketchFormatEffectiveData.getSketchType`. Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομίας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Μορφοποίηση Στυλ Συνένωσης**

Ακολουθούν οι τρεις επιλογές τύπου συνένωσης:

* Στρογγυλό
* Μονογώνιο
* Λεπτό

Εξ'ορισμού, όταν το PowerPoint συνδέει δύο γραμμές σε γωνία (όπως στην γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με οξείες γωνίες, μπορεί να προτιμήσετε την επιλογή **Μονογώνιο**.

![The join style in the presentation](join-style-powerpoint.png)

Ο παρακάτω κώδικας Python δείχνει πώς τρία ορθογώνια (όπως φαίνονται στην παραπάνω εικόνα) δημιουργήθηκαν χρησιμοποιώντας τις ρυθμίσεις στυλ συνένωσης Μονογώνιο, Λεπτό και Στρογγυλό:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη τριών αυτόματων σχημάτων τύπου Rectangle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Ορισμός του χρώματος γεμίσματος για κάθε σχήμα Rectangle.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Ορισμός του πλάτους της γραμμής.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Ορισμός του χρώματος για τη γραμμή κάθε Rectangle.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Ορισμός του στυλ συνένωσης.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Προσθήκη κειμένου σε κάθε Rectangle.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Γραμμικό Γέμισμα (Gradient Fill)**

Στο PowerPoint, το Gradient Fill είναι μια επιλογή μορφοποίησης που επιτρέπει την εφαρμογή συνεχούς μείξης χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα έτσι ώστε το ένα να διαχέεται αργά στο άλλο.

Ακολουθεί η διαδικασία για την εφαρμογή γραμμικού γεμίσματος σε σχήμα με χρήση του Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τη μέθοδο [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) της συλλογής διακοπτών γραμμικού χρώματος που εκτίθενται από την κλάση [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ γραμμικού γεμίσματος σε μια έλλειψη:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη αυτόματου σχήματος τύπου Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Εφαρμογή μορφοποίησης gradient στην έλλειψη.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Ορισμός της κατεύθυνσης του gradient.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Προσθήκη δύο σημείων gradient.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The ellipse with gradient fill](gradient-fill.png)

Εάν ένα gradient εμφανίζεται διαφορετικά σε εξαγόμενο εικόνα από ό,τι στο PowerPoint, δείτε το [Choose a Gradient Rendering Style](/slides/el/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε ένα στυλ απόδοσης χωρίς να αλλάξετε το gradient fill που αποθηκεύεται στην παρουσία.

## **Γέμισμα Μοτίβου (Pattern Fill)**

Στο PowerPoint, το Pattern Fill είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχεδιασμό δύο χρωμάτων — όπως κουκκίδες, λωρίδες, διαγράμματα ή σκαλισμένες τετράγωνες — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το μπροστινό και το φόντο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προεγκατεστημένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να βελτιώσετε την οπτική ελκυστικότητα των παρουσιάσεων σας. Ακόμη και μετά την επιλογή ενός προεγκατεστημένου μοτίβου, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιήσει.

Ακολουθεί η διαδικασία για την εφαρμογή γεμίσματος μοτίβου σε σχήμα με χρήση του Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεγκατεστημένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε γεμίσμα μοτίβου σε ένα ορθογώνιο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ορισμός του τύπου γεμίσματος σε Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Ορισμός του στυλ μοτίβου.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Ορισμός των χρωμάτων υποβάθρου και προσκηνίου του μοτίβου.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The rectangle with pattern fill](pattern-fill.png)

## **Γέμισμα Εικόνας (Picture Fill)**

Στο PowerPoint, το Picture Fill είναι μια επιλογή μορφοποίησης που επιτρέπει την εισαγωγή μιας εικόνας μέσα σε ένα σχήμα — χρησιμοποιώντας την εικόνα ως φόντο του σχήματος.

Ακολουθεί η διαδικασία για την εφαρμογή γεμίσματος εικόνας σε σχήμα με χρήση του Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γεμίσματος εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Μεταβιβάστε την εικόνα στη μέθοδο `SlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ας πούμε ότι έχουμε το αρχείο "lotus.png" με την ακόλουθη εικόνα:

![The lotus picture](lotus.png)

Ο παρακάτω κώδικας Python δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Ορισμός του τύπου γεμίσματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Ορισμός της λειτουργίας γεμίσματος εικόνας.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Φόρτωση μιας εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Ορισμός της εικόνας.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The shape with picture fill](picture-fill.png)

### **Τίλωση Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια τηνυλιζόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της εσοχής, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει τη λειτουργία γεμίσματος εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει τη στοίχιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει εάν το πλακίδιο θα αντιστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από την αρχή του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από την αρχή του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με γεμισμένο τηνυλιζόμενο πλακίδιο και να διαμορφώσετε τις επιλογές του πλακιδίου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    first_slide = presentation.getSlides().get_Item(0)

    # Προσθήκη αυτόματου σχήματος ορθογωνίου.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Ορισμός του τύπου γεμίσματος του σχήματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Φόρτωση της εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Ανάθεση της εικόνας στο σχήμα.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Διαμόρφωση της λειτουργίας γεμίσματος εικόνας και των ιδιοτήτων εναρμίσματος πλακιδίων.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The tile options](tile-options.png)

## **Συμπαγές Γέμισμα Χρώματος (Solid Color Fill)**

Στο PowerPoint, το Solid Color Fill είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς γραμμικές μεταβάσεις, υφές ή μοτίβα.

Για να εφαρμόσετε συμπαγές γέμισμα χρώματος σε σχήμα με χρήση του Aspose.Slides, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Εκχωρήστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε συμπαγές γέμισμα χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ορισμός του τύπου γεμίσματος σε Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Ορισμός του χρώματος γεμίσματος.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The shape with solid color fill](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε συμπαγές χρώμα, gradient, εικόνα ή γεμίσμα υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε τη διαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Το Aspose.Slides σάς επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alfa στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθεί η διαδικασία:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε το [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε ένα διαφανές χρώμα γεμίσματος σε ένα ορθογώνιο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήξη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη αυτόματου σχήματος ορθογωνίου με συμπαγές γέμισμα.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Προσθήκη διαφανούς αυτόματου σχήματος ορθογωνίου πάνω από το συμπαγές σχήμα.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The transparent shape](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένες ευθυγραμμίσεις ή σχεδιαστικές ανάγκες.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Περιστροφή του σχήματος κατά 5 μοίρες.
    shape.setRotation(5)

    # Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The shape rotation](shape-rotation.png)

## **Προσθήκη Εφέ 3Δ Κβάλας (3D Bevel Effects)**

Το Aspose.Slides επιτρέπει την εφαρμογή εφέ 3Δ κβάλας σε σχήματα διαμορφώνοντας τις ιδιότητες [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/).

Για να προσθέσετε εφέ 3Δ κβάλας σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις κβάλας.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε εφέ 3Δ κβάλας σε ένα σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία μιας στιγμιότυπης της κλάσης Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη σχήματος στη διαφάνεια.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Ορισμός των ιδιοτήτων ThreeDFormat του σχήματος.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The 3D bevel effect](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3Δ Περιστροφής (3D Rotation Effects)**

Το Aspose.Slides επιτρέπει την εφαρμογή εφέ 3Δ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) και [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε εφέ 3Δ περιστροφής σε ένα σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Δημιουργία μιας στιγμιότυπης της κλάσης Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![The 3D rotation effect](3D-rotation-effect.png)

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η μέθοδος [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) καθορίζει πώς ένα μεμονωμένο σχήμα αποδίδεται όταν μια παρουσία προβάλλεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί την ασπρόμαυρη προβολή από μόνη της και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις σε φυσική κατάσταση χρώματος.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι χρώματα, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` υποχρεώνουν ένα ενιαίο χρώμα, το `Color` διατηρεί φυσικά χρώματα και το `Hidden` παραλείπει το σχήμα σε ασπρόμαυρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει εκχωρηθεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας Python δημιουργεί ένα έγχρωμο σχήμα και το εμφανίζει γκρι σε ασπρόμαυρη λειτουργία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Διατηρήστε το πορτοκαλί γέμισμα σε λειτουργία χρώματος, αλλά αποδώστε το σχήμα με γκρι χρωματισμό σε ασπρόμαυρη λειτουργία.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Σε φυσική λειτουργία χρώματος, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα του. Σε ροή εργασίας ασπρόμαυρης προβολής, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις ασπρόμαυρης προβολής της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας Python δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στο [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Επαναφορά κάθε σχήματος στη διαφάνεια που έχει placeholder στη διάταξη.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις (FAQ)**

**Επηρεάζει η μορφοποίηση του σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και gradient αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν πρακτικά κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος — τις ρυθμίσεις γεμίσματος, γραμμής και εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μεταγενέστερη διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε μια πρότυπη διαφάνεια ή σε αρχείο .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.