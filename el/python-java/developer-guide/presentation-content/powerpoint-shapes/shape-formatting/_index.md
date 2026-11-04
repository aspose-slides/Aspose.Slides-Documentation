---
title: Μορφοποίηση Σχημάτων PowerPoint σε Python μέσω Java
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/python-java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσο
- γραμμή σχήματος σκίτσο
- μορφοποίηση στυλ ένωσης
- γεμισμα διαβάθμισης
- γεμισμα προτύπου
- γεμισμα εικόνας
- γεμισμα υφής
- γεμισμα συμπαγούς χρώματος
- διαφάνεια σχήματος
- ασπρόμαυρη απόδοση σχήματος
- απόδοση σχήματος σε αποχρώσεις του γκρι
- περιστροφή σχήματος
- εφέ 3Δ λεπίδας
- εφέ περιστροφής 3Δ
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Python μέσω Java χρησιμοποιώντας το Aspose.Slides—ρυθμίστε τις γεμίσεις, τις γραμμές και τα στυλ εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Μορφοποιήστε σχήματα στο PowerPoint ρυθμίζοντας τα περιγράμματα, τις γεμίσεις και τα εφέ. Το Aspose.Slides for Python via Java σάς επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένης της διαφάνειας, της περιστροφής και της 3Δ μορφοποίησης.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for Python via Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιήστε [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) για να ελέγξετε το περίγραμμα ενός σχήματος. Αυτό το παράδειγμα δημιουργεί ένα μη γεμάτο ορθογώνιο με μπλε, διακεκομμένο περίγραμμα. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) επιλέγει μια σύνθετη γραμμή παχιά‑λεπτή, ενώ [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ορίζει το πλάτος της σε 7 σημεία και [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) επιλέγει το μοτίβο παύλας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

### **Ορισμός Προσαρμοσμένων Μοτίβων Παύλας Γραμμής**

Χρησιμοποιήστε [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) όταν τα προεπιλεγμένα στυλ γραμμής δεν παρέχουν τα μήκη παύλας και κενών που χρειάζεστε, για παράδειγμα για επωνυμισμένα περιγράμματα ή τεχνικά διαγράμματα. Η ανάθεση ενός μοτίβου αλλάζει αυτόματα το στυλ παύλας σε [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Οι καταχωρίσεις του πίνακα εναλλάσσονται μεταξύ μηκών παύλας και κενών, ξεκινώντας με παύλα. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `[4, 2]` σε πλάτος 3 σημείων δημιουργεί παύλα 12 σημείων ακολουθούμενη από κενό 6 σημείων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε πλήρη τμήματα παύλας‑και‑κενών. Το παράδειγμα χρησιμοποιεί θετικές τιμές ώστε κάθε παύλα και κενό να είναι ορατά.

Αυτό το παράδειγμα δημιουργεί πέντε μπλε γραμμές με το ίδιο μήκος και επίπεδες άκρες. Οι πρώτες τρεις συγκρίνουν μοτίβα σε πλάτος 3 σημείων. Η τέταρτη επαναλαμβάνει το πρώτο μοτίβο σε διπλό πλάτος, διπλασιάζοντας τόσο το μήκος της παύλας όσο και του κενό. Η πέμπτη μεταβαίνει από προσαρμοσμένο μοτίβο σε στερεή γραμμή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Επιστρέψτε την τελευταία γραμμή σε στερεό στυλ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για να επιστρέψετε σε προεπιλεγμένο διακεκομμένο στυλ, περάστε [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) στη [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **{4, 2}, 3 pt**· **{1, 2}, 3 pt**· **{6, 2, 1, 2}, 3 pt**· **{4, 2}, 6 pt**· και **Solid, 3 pt**.

![Τρία προσαρμοσμένα μοτίβα παύλας, μια πιο πλατιά γραμμή χρησιμοποιώντας το πρώτο μοτίβο, και μια στερεή γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός Ακρων Γραμμής**

Χρησιμοποιήστε [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) για να ορίσετε τα άκρα μιας ανοιχτής γραμμής. Η κλάση [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) παρέχει τρία ρητά στυλ άκρων:

- `Flat`: Η γραμμή σταματά στο άκρο.
- `Round`: Μια ημικυκλική άκρη εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.
- `Square`: Μια τετράγωνη άκρη εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.

Η κλάση περιλαμβάνει επίσης το `NotDefined`, που σημαίνει ότι δεν έχει οριστεί ρητά στυλ άκρου.

Τα άκρα διαφέρουν από τα βέλη, που προσθέτουν σύμβολα στα άκρα της γραμμής, και από τις ενώσεις, που ελέγχουν τις γωνίες μεταξύ των τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τα βέλη μέσω των [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) και [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) ώστε να συγκριθούν μόνο τα σχήματα άκρων.

Το παρακάτω παράδειγμα δημιουργεί τρεις οριζόντιες γραμμές, διαφορετικά ίδιοι, 20 σημείων πλάτους. Από πάνω προς τα κάτω, χρησιμοποιούν επίπεδη, στρογγυλή και τετράγωνη άκρη. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· οι στρογγυλές και τετράγωνες άκρες εκτείνονται 10 σημεία πέρα από κάθε άκρο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **Flat**, **Round**, και **Square**.

![Επίπεδες, στρογγυλές και τετράγωνες άκρες σε πανομοιότυπες παχιές γραμμές στο PowerPoint](line-caps.png)

## **Εφαρμογή Σχεδίων Σκαρίφησης σε Γραμμές Σχήματος**

Ένα σκέτσο κάνει τη γραμμή ενός σχήματος να φαίνεται χειροποίητη. Χρησιμοποιήστε [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) για να έχετε πρόσβαση στις ρυθμίσεις της γραμμής, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) για τις ρυθμίσεις σκαρίφησης, και [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) για να επιλέξετε μια τιμή από την κλάση [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε ένα εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/), να διαβάσετε τη ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

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

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Η τιμή που επιστρέφει η [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) αντιπροσωπεύει τη ρύθμιση που έχει οριστεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής κληρονομείται από θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε τη [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) και διαβάστε τον τύπο σκαρίφησης από τη ληφθείσα αποτελεσματική μορφοποίηση γραμμής, όπως φαίνεται παρακάτω. Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομίας. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εκτυπώνει και τις δύο τιμές:

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

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Μορφοποίηση Στυλ Ενώσεων**

Αυτές είναι οι τρεις επιλογές τύπου ένωσης:

* Round
* Miter
* Bevel

Το στυλ ένωσης ελέγχει πώς δύο τμήματα περιγράμματος συναντώνται σε γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για οξείες γωνίες ή **Bevel** για επίπεδες γωνίες.

![Το στυλ ένωσης στην παρουσίαση](join-style-powerpoint.png)

Αυτό το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα 15 σημείων πλάτους. Χρησιμοποιεί τη [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) για να ορίσει τις τιμές miter, bevel και round της κλάσης [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/), αντίστοιχα, ώστε να συγκριθεί ο τρόπος σχεδίασης των γωνιών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Περιορισμός Ενώσεων Miter σε Οξείες Γωνίες**

Χρησιμοποιήστε [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) μαζί με τη [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) ορισμένη σε [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) για να περιορίσετε το πόσο μπορεί να εκταθεί μια οξέα γωνία.

Το όριο είναι ένας λόγος της απόστασης μεταξύ των εσωτερικών και εξωτερικών γωνιών της ένωσης προς το πλάτος της γραμμής. Για παράδειγμα, η τιμή `8` επιτρέπει μήκος miter έως και οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε σημεία. Εάν η γωνία θα υπερβεί το όριο, το PowerPoint χρησιμοποιεί μια κομμένη (beveled) ένωση στο σημείο αυτό. Ένα μεγαλύτερο όριο επιτρέπει πιο οξείες άκρες. Η ρύθμιση επηρεάζει μόνο τις ενώσεις miter και η αλλαγή της δεν έχει ορατό αποτέλεσμα όταν η γωνία παραμένει εντός των ορίων.

Αυτό το παράδειγμα δημιουργεί δύο πανομοιότυπα, μη γεμάτα τρίγωνα με περιγράμματα 20 σημείων πλάτους. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, το δεξιό `8`. Κάθε τρίγωνο έχει πλάτος 80 σημείων και ύψος 160 σημείων, δίνοντας στην κορυφαία γωνία λόγο μήκους‑miter προς πλάτος γραμμής περίπου `4.12`. Συνεπώς, το PowerPoint κοvrώνει την αριστερή κορυφή και διατηρεί την δεξιά.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα στο PowerPoint: **Miter limit 2** στα αριστερά και **miter limit 8** στα δεξιά.

![Μια κομμένη κορυφή με όριο miter 2 και μια αιχμηρή κορυφή με όριο miter 8 στο PowerPoint](miter-limits.png)

## **Γεμισμα Διαβάθμισης**

Μια γεμίσμα διαβάθμισης αναμειγνύει χρώματα σε όλο το σχήμα. Αυτό το παράδειγμα γεμίζει μια έλλειψη με γραμμική διαβάθμιση υπό γωνία 45 μοιρών από κόκκινο σε μοβ χρησιμοποιώντας τη [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). Η μέθοδος [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) τοποθετεί τα χρώματα διαβάθμισης στα 0 και 1, την αρχή και το τέλος της διαβάθμισης. Η εκκαθάριση των υπαρχουσών στάσεων εξασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η έλλειψη με γεμίσμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε εξαγόμενο εικόνα απ' ό,τι στο PowerPoint, δείτε το [Choose a Gradient Rendering Style](/slides/el/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη διαβάθμιση που είναι αποθηκευμένη στην παρουσίαση.

### **Ορισμός Γωνίας Γραμμικής Διαβάθμισης**

Χρησιμοποιήστε τη [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) για να ελέγξετε τον προσανατολισμό μιας γεμίσματος [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). Η γωνία μετράται σε μοίρες και αυξάνεται δεξιόστροφα: `0` τρέχει αριστερά‑δεξιά, `90` πάνω‑κάτω, `180` δεξιά‑αριστερά, και `270` κάτω‑πάνω. Υποστηρίζονται κλασματικές γωνίες. Οι πεπερασμένες γωνίες εκτός του εύρους `[0, 360)` κανονικοποιούνται σε μια πλήρη περιστροφή· π.χ., `-45` γίνεται `315` και `360` γίνεται `0`.

Αυτό το παράδειγμα δημιουργεί έξι ορθογώνια με τα ίδια κόκκινα, πράσινα και μπλε χρώματα σε θέσεις `0`, `0.5` και `1`. Η κλιμάκωση έχει απενεργοποιηθεί ώστε η γωνία να συγκριθεί ανεξάρτητα από τις αναλογίες των ορθογωνίων. Οι γωνίες, από αριστερά προς δεξιά, είναι `0`, `45` και `90` στην πρώτη σειρά, και `135`, `180` και `270` στη δεύτερη σειρά.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα στο PowerPoint:

![Γραμμικές διαβάθμιση στις γωνίες 0, 45 και 90 μοίρες στην άνω σειρά, και 135, 180 και 270 μοίρες στην κάτω σειρά](linear-gradient-angles.png)

### **Κλιμάκωση Γραμμικής Διαβάθμισης με το Σχήμα**

Η μέθοδος [GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) δέχεται τιμή [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Ορίστε την ρητά σε `False_` για να διατηρήσετε τη γεωμετρική γωνία της διαβάθμισης όταν αλλάζουν οι αναλογίες του σχήματος, ή σε `True_` για να κλιμακώσετε τη διαβάθμιση με το πλάτος και το ύψος του σχήματος. Με την κλιμάκωση ενεργοποιημένη, η ορατή γωνία μπορεί να διαφέρει από τη συγκεκριμένη γωνία σε σχήμα που δεν είναι τετράγωνο.

Το παρακάτω παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τα ίδια χρώματα διαβάθμισης όπως στην σύγκριση γωνιών. Η αριστερή στήλη χρησιμοποιεί `False_`; η δεξιά `True_`. Κάθε στήλη περιλαμβάνει ένα πλατύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και οι δύο ξεκινούν με τις ίδιες πλατιές διαστάσεις· η αλλαγή πλάτους και ύψους του δεύτερου ορθογωνίου δείχνει πώς η γεμιστική διαβάθμιση αντιδρά στην αλλαγή μεγέθους χωρίς να αλλάζει τις ρυθμίσεις διαβάθμισης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα στο PowerPoint, με κλιμάκωση απενεργοποιημένη στα αριστερά και ενεργοποιημένη στα δεξιά:

![Πλακά και ψηλά ορθογώνια με διαβάθμιση 45 μοιρών, συγκρίνοντας LinearGradientScaled False στα αριστερά με True στα δεξιά](linear-gradient-scaling.png)

Με κλιμάκωση απενεργοποιημένη, οι διαγώνιες λωρίδες χρώματος διατηρούν τον ίδιο προσανατολισμό και στα δύο ορθογώνια. Με κλιμάκωση ενεργοποιημένη, οι λωρίδες τεντώνονται με τις αναλογίες του σχήματος. Αυτό βοηθά στην αναπαραγωγή μιας διαβάθμισης προτύπου όταν προσαρμόζετε ένα σχήμα σε διαφορετικό μέγεθος. Σε τετράγωνο, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση της διαβάθμισης `45` μοιρών.

Τanto η γωνία όσο και η κλιμάκωση εφαρμόζονται μόνο σε γραμμικές διαβάθμιση. Δεν ελέγχουν τις γεμίσεις [GradientShape.Radial ή GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **Συνδυασμός Γωνίας με Κατεύθυνση Διαβάθμισης**

Η μέθοδος [GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) επιλέγει στυλ διαβάθμισης από την κλάση [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/); δεν υποκαθιστά αριθμητική γωνία. Για γραμμική διαβάθμιση, τα στυλ γωνιών μπορούν να αλλάξουν την περιοχή κατανομής των χρωμάτων χωρίς να αλλάζουν τη γωνία που έχει οριστεί μέσω [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). Κρατήστε την κατεύθυνση αμετάβλητη όταν συγκρίνετε γωνίες ή κλιμάκωση.

Το παρακάτω παράδειγμα εφαρμόζει τις ίδιες ρυθμίσεις με αντίστροφη σειρά. Τα δύο ορθογώνια έχουν την ίδια εμφάνιση: η ανάθεση της κατεύθυνσης πριν ή μετά τη γωνία δεν αλλάζει το αποτέλεσμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Γέμισμα Προτύπου**

Ένα γέμισμα προτύπου εφαρμόζει σχέδιο δύο χρωμάτων, όπως σημεία, λωρίδες ή καρό. Αυτό το παράδειγμα χρησιμοποιεί τη [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) για να επιλέξει μοτίβο πλέγματος. Η μέθοδος [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) παρέχει το ανοιχτόγκρι φόντο, και η [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) το κίτρινο χρώμα του μοτίβου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα προτύπου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Ένα γέμισμα εικόνας χρησιμοποιεί μια εικόνα μέσα σε σχήμα. Αυτό το παράδειγμα απαιτεί τοπική εικόνα και χρησιμοποιεί τη [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) για να την φορτώσει στη συλλογή εικόνων της παρουσίασης. Ορίζοντας τη [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) σε λειτουργία πλακίδωσης, η εικόνα επαναλαμβάνεται μέσα στο ορθογώνιο. Η πηγή εικόνας που χρησιμοποιείται εμφανίζεται παρακάτω:

![Η εικόνα λωτό](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Πλακίδωση Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια πλακίδωση ως υφή και να προσαρμόσετε τη συμπεριφορά της πλακίδωσης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει τη λειτουργία γέμισματος εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει αν το πλακίδιο θα αντιστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί τοπική εικόνα και ρυθμίζει τη [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) ώστε να την επαναλάβει στο 50 % του αρχικού μεγέθους. Οι μετατοπίσεις −32 σημείων μετατοπίζουν τα πλακίδια οριζόντια και κάθετα· η ευθυγράμμιση κάτω‑δεξιά και η αντιστροφή και στις δύο κατευθύνσεις καθορίζουν πώς διαμορφώνεται η επαναλαμβανόμενη υφή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι επιλογές πλακίδωσης](tile-options.png)

## **Συμπαγές Χρώμα Γέμισης**

Μια συμπαγής γέμιση δίνει σε ένα σχήμα ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το παράδειγμα χρησιμοποιεί τη [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) για να ορίσει τη λειτουργία συμπαγούς γέμισης και ορίζει κίτρινο χρώμα μέσω της [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), έπειτα αποθηκεύει το ορθογώνιο στην παρουσίαση.

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το σχήμα με συμπαγές χρώμα γέμισης](solid-color-fill.png)

## **Χρήση Φόντου Διαφάνειας ως Γέμισμα Σχήματος**

Χρήστε τη [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) όταν ένα σχήμα πρέπει να ταιριάζει με το φόντο της διαφάνειας, π.χ. σε πρότυπο παρουσίασης. Ορίστε πρώτα το [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) σε [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) για να αφαιρέσετε τυχόν ρητά καθορισμένο γέμισμα. Με αυτόν τον συνδυασμό, το σχήμα χρησιμοποιεί το φόντο της διαφάνειας αντί του δικού του στυλ γέμισης. Η ενεργοποίηση μόνο αυτής της σημαίας δεν αφαιρεί ένα υπάρχον ρητό γέμισμα.

Αυτό διαφοροποιείται από το [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): το γέμισμα φόντου καλύπτει αντικείμενα πίσω από το σχήμα με την αντίστοιχη περιοχή του φόντου της διαφάνειας, ενώ το NoFill αφήνει αυτά τα αντικείμενα ορατά. Μια διαβάθμιση παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να επανεκκινείται μέσα σε κάθε σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα κυρίως φόντο που κληρονομείται από τη διαφάνεια και τοποθετεί μια ματζέντα λωρίδα πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το φόντο, το μεσαίο δεν έχει γέμισμα, και το δεξιό εναλλάσσει από φόντο σε ρητό πορτοκαλί γέμισμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Κληρονομεί τη διαβάθμιση από το master.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Προσθέστε αυτό το αντικείμενο πρώτα ώστε να εμφανίζεται πίσω από τα ορθογώνια.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Απενεργοποίηση γεμίσματος φόντου πριν την εφαρμογή ρητού γεμίσματος.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα, από αριστερά προς δεξιά: **γέμισμα φόντου**, **χωρίς γέμισμα**, και **ρητό γέμισμα**. Η ματζέντα κρύβεται από τα αριστερά και δεξιά ορθογώνια αλλά παραμένει ορατή μέσω του μεσαίου.

![Γέμισμα φόντου, χωρίς γέμισμα, και ρητό πορτοκαλί γέμισμα πάνω από μια ματζέντα](background-fill.png)

Η ίδια συμπεριφορά ισχύει για φόντο ορισμένο απευθείας στη διαφάνεια ή κληρονομόμενο από διάταξη. Το σχήμα χρησιμοποιεί το επιλυμένο φόντο της διαφάνειας· το παράδειγμα αφήνει το φόντο τόσο της διαφάνειας όσο και της διάταξης ακαθόριστο ώστε το κύριο να το παρέχει.

## **Ορισμός Διαφάνειας**

Για μια συμπαγή γέμιση, το αλφα-συστατικό του χρώματος ελέγχει την αδιαφάνεια: 0 είναι πλήρως διαφανές και 255 πλήρως αδιαφανές. Αυτό το παράδειγμα χρησιμοποιεί τιμή alpha 128 για ένα κίτρινο ορθογώνιο, κάνοντάς το περίπου 50 % διαφανές ώστε το ορθογώνιο κάτωθεν να παραμένει ορατό. Το χρώμα ορίζεται μέσω της [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

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

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Χρησιμοποιήστε τη [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) για να περιστρέψετε ένα σχήμα στο επίπεδο της διαφάνειας. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα περιστρέφει ένα ορθογώνιο 5 μοίρες δεξιόστροφα και αποθηκεύει την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ 3Δ Λεπίδας**

Χρησιμοποιήστε τη [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) για να δώσετε βάθος και λεπίδες σε ένα σχήμα. Αυτό το παράδειγμα δημιουργεί μια πράσινη έλλειψη με πορτοκαλί περίγραμμα, ορίζει το βάθος σε 4 σημεία μέσω της [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) και εφαρμόζει μια κυκλική άνω λεπίδα με πλάτος και ύψος 6 σημείων μέσω της [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). Μια προσανατολισμένη ορθοπτική κάμερα και τριπλό φωτισμό καθιστούν τη λεπίδα ορατή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το εφέ 3Δ λεπίδας](3D-bevel-effect.png)

## **Προσθήκη Εφέ Περιστροφής 3Δ**

Η 3Δ προβολή ενός σχήματος ελέγχεται από τις ρυθμίσεις της κάμερας. Αυτό το παράδειγμα χρησιμοποιεί τη [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) με γωνίες πλάτους, μήκους και περιδέρου 40, 35 και 20 μοιρών, αντίστοιχα. Επιλέγει ισομετρική κάμερα μέσω της [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) και ισορροπημένο φωτισμό μέσω της [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), έπειτα αποθηκεύει το μορφοποιημένο ορθογώνιο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το εφέ 3Δ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η μέθοδος [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν η παρουσίαση προβάλλεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί την ασπρόμαυρη προβολή από μόνη της, ούτε αλλάζει τη γέμιση, τη γραμμή ή άλλη μορφοποίηση σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, `Automatic` αφήνει την εφαρμογή απόφασης μετατροπής, `Gray` και `LightGray` χρησιμοποιούν γκρι χρωματισμό, `BlackWhite` μόνο μαύρο‑λευκό, `Black` και `White` εξαναγκάζουν ένα μοναδικό χρώμα, `Color` διατηρεί το φυσικό χρώμα, και `Hidden` παραλείπει το σχήμα σε ασπρόμαυρη λειτουργία. `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία επιπέδου σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και χρησιμοποιεί τη [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) για να ορίσει τη λειτουργία σε γκρι. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γέμισμα για κανονική χρωματική προβολή και ζητά γκρι χρωματισμό από εφαρμογές που τηρούν τις ρυθμίσεις ασπρόμαυρης λειτουργίας:

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
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα. Σε ροή εργασίας με ασπρόμαυρη προβολή, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρη‑χρωματική διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις εμφάνισης ασπρόμαυρης παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Χρησιμοποιήστε την [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) για να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση των δεσμευτικών στοιχείων της διαφάνειας από τα αντίστοιχα στοιχεία της διάταξης. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με δεσμευμένα στοιχεία διάταξης και επαναφέρει κάθε διαφάνεια πριν την αποθήκευση. Σχήματα χωρίς αντίστοιχα δεσμευτικά στοιχεία διάταξης δεν επαναφέρονται.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ΣΥΝΕΧΑΤΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Τα χρώματα, τα στυλ γραμμής και οι ρυθμίσεις εφέ προσθέτουν συνήθως λίγα δεδομένα σε σύγκριση με ενσωματωμένες εικόνες και πολυμέσα. Τα γέμισμα εικόνας μπορούν να αυξήσουν το μέγεθος του αρχείου επειδή οι εικόνες τους αποθηκεύονται στην παρουσίαση.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος — γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι το στυλ είναι ταυτόσημο και λογικά ομαδοποιήστε αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο αρχείο παρουσίασης ή σε αρχείο .POTX. Κατά τη δημιουργία νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και επαναεφαρμόστε τη μορφοποίησή τους όπου απαιτείται.