---
title: Διαχείριση Μεταβάσεων Διαφάνειας σε Παρουσιάσεις με Python μέσω Java
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 80
url: /el/python-java/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προχωρημένη μετάβαση διαφάνειας
- μετάβαση Morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφάνειας, διαμορφώστε την αυτόματη προώθηση διαφανειών, και προσαρμόστε τα εφέ Morph και άλλα εφέ μετάβασης με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφάνειας ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides για Python μέσω Java, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προώθηση με κλικ του ποντικιού ή χρονομετρητή, και να προσαρμόσετε επιλογές ειδικές για το εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα Python για την εφαρμογή μεταβάσεων, ορισμό ακριβών διάρκειας μετάβασης, διαχείριση χρονισμού διαφάνειας, και δημιουργία μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης της διαφάνειας μέσω του [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) με μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), στη συνέχεια αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει μετάβαση Circle στην πρώτη διαφάνεια και μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Τροχική Μετάβαση**

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Wheel από το [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Στη συνέχεια καλέστε το [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) για να αποκτήσετε πρόσβαση στις ρυθμίσεις του [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Η μέθοδος [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) ελέγχει πόσοι ακτινικοί τομείς αποκαλύπτουν τη διαφάνεια προορισμού.

Το παράδειγμα δημιουργεί δύο ταυτόσημα ζεύγη διαφανειών. Κάθε ζεύγος ξεκινά με μια μαύρη διαφάνεια και τελειώνει με ένα χρυσό ορθογώνιο πλήρους διαφάνειας. Και οι δύο διαφάνειες προορισμού χρησιμοποιούν την ίδια αργή ταχύτητα που ορίζεται με το [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) και την ίδια ρητή διάρκεια 8 000 χιλιοστών του δευτερολέπτου που ορίζεται με το [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Μόνο ο αριθμός των ακτίνων (spokes) αλλάζει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ανοίξτε το `wheel-transitions.pptx` στο PowerPoint και ξεκινήστε την παρουσίαση. Προχωρήστε από τη διαφάνεια 1 στη διαφάνεια 2 για να δείτε μια κυκλική σκέδαση που αποκαλύπτει το χρυσό ορθογώνιο. Στη συνέχεια προχωρήστε από τη διαφάνεια 3 στη διαφάνεια 4 για να δείτε οχτώ ακτινικούς τομείς που αποκαλύπτουν το ίδιο ορθογώνιο ταυτόχρονα.

## **Ξεθώριασμα Μέσω Μαύρου με τη Μετάβαση Αποκάλυψης**

Ορίστε τον τύπο μετάβασης της διαφάνειας προορισμού σε Reveal, στη συνέχεια καλέστε το [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) στις ρυθμίσεις του [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/). Το παράδειγμα δημιουργεί μια πηγαία διαφάνεια τυρκουάζ και μια διαφάνεια προορισμού κοραλί, και στη συνέχεια κλωνοποιεί και τις δύο. Κάθε ζεύγος χρησιμοποιεί την ίδια μετάβαση Reveal διάρκειας δύο δευτερολέπτων. Μόνο το δεύτερο ζεύγος ξεθωριάζει μέσω μαύρου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ανοίξτε το `reveal-transitions.pptx` στο PowerPoint και ξεκινήστε την παρουσίαση. Προχωρήστε από τη διαφάνεια 1 στη διαφάνεια 2 για να δείτε το τυρκουάζ να ξεθωριάσει άμεσα στο κοραλί. Στη συνέχεια προχωρήστε από τη διαφάνεια 3 στη διαφάνεια 4. Η οθόνη σκοτείνιαζε προσωρινά σχεδόν σε μαύρο πριν εμφανιστεί η διαφάνεια κοραλί. Και οι δύο διαφάνειες διατηρούν τα αρχικά χρώματα φόντου.

Οι γραμμές παρακάτω δείχνουν καρέ από το PowerPoint σε διαστήματα μισού δευτερολέπτου. Συγκρίνετε το κεντρικό καρέ σε κάθε γραμμή για να δείτε το εφέ.

![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](reveal-through-black.png)

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο χρόνο διατηρείται μια διαφάνεια στην οθόνη και εάν ένα κλικ του ποντικιού προχωρά την παρουσίαση. Οι ακόλουθες μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) επιτρέπει στον θεατή να προχωρήσει κάνοντας κλικ.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) ενεργοποιεί την αυτόματη προώθηση.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) καθορίζει την καθυστέρηση πριν την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε τόσο την προώθηση με κλικ όσο και την χρονομετρημένη προώθηση ώστε ο θεατής να μπορεί να προχωρήσει με κλικ ή να περιμένει το χρονομετρητή. Για να χρησιμοποιήσετε μόνο τον χρονομετρητή, περάστε `False` στο [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Η καθυστέρηση ελέγχει πότε η παρουσίαση προχωρά· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Το παράδειγμα αυτό αναθέτει διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί την αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προωθήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Για να ελέγξετε εάν η χρονομετρημένη προώθηση είναι ενεργή, καλέστε το [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Μία αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονομετρητής είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το αποθηκευμένο αρχείο, αναφέρει κάθε ενεργό χρονομετρητή, και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη από δύο δευτερόλεπτα. Ενεργοποιεί τα κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ακριβής Έλεγχος Χρόνου Μετάβασης**

Χρησιμοποιήστε το [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) για να ορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας αποκαλύπτει αυτές τις ρυθμίσεις μέσω του [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Ορίζει τη διάρκεια του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ορίζει την καθυστέρηση πριν τη διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Περάστε `True` στο [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) για να ενεργοποιήσετε αυτόν τον χρονομετρητή. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Επιλέγει μια προκαθορισμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν έχει οριστεί ρητή διάρκεια. |

Το [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) ελέγχει μόνο το εφέ μετάβασης· δεν καθορίζει πόσο χρόνο παραμένει η διαφάνεια ορατή. Ρυθμίστε την αυτόματη καθυστέρηση προώθησης ξεχωριστά. Όταν δεν οριστεί ρητή διάρκεια, το Aspose.Slides υπολογίζει τη διάρκεια του εφέ από τον τύπο μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Το κοινό παράδειγμα δίνει σε κάθε διαφάνεια μια μετάβαση Fade 750 ms και ενεργοποιεί ξεχωριστά την αυτόματη προώθηση στα 5 000 ms. Η διάρκεια της μετάβασης ελέγχει το εφέ· η προώθηση ελέγχει πότε θα φύγει η διαφάνεια. Αυτές οι γραμμές είναι σχήματα ρυθμίσεων, όχι μετρημένο συνδυασμένο χρονοδιάγραμμα.*
<!-- visual-explanation:slide-transition:end -->

### **Εφαρμογή της Ίδιας Διάρκειας σε Κάθε Διαφάνεια**

Για σταθερό ρυθμό, εφαρμόστε το ίδιο εφέ και την ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστά του δευτερολέπτου. Ενεργοποιεί ξεχωριστά την αυτόματη προώθηση μετά από 5 000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την προώθηση με κλικ, στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Διαμόρφωση αυτόματης προώθησης ανεξάρτητα από τη διάρκεια του εφέ.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Καθορισμός Διαφορετικών Διάρκειας για Ατομικές Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να έχουν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για μια διαφάνεια τίτλου και μια μεγαλύτερη για μια εισαγωγική ενότητα. Αυτό το παράδειγμα ορίζει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1 200 χιλιοστά του δευτερολέπτου για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Συντονισμός Μεταβάσεων με Ανιματισμένη Εξαγωγή**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/python-java/convert-powerpoint-to-animated-gif/), μιας [HTML5 presentation](/slides/el/python-java/export-to-html5/) ή ενός [video](/slides/el/python-java/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν την εξαγωγή ώστε να ταιριάζουν με το επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε ένα fade 600 ms μεταξύ σκηνών και προσαρμόστε ξεχωριστά την καθυστέρηση προώθησης κάθε διαφάνειας για να επιτρέψετε χρόνο για αφήγηση ή περιεχόμενο.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ εξόδου με τη διάρκεια του εφέ: 600 ms αντιστοιχούν σε 18 καρέ στα 30 fps. Στο HTML5, ενεργοποιήστε τις αναιματισμένες μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες επιπτώσεις και επιλογές χρόνου του επιλεγμένου μορφότυπου εξαγωγής και προεπισκοπήστε το αποτέλεσμα για να βεβαιωθείτε ότι είναι συγχρονισμένο.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Καλέστε το [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) πριν τροποποιήσετε τη μετάβαση για να καθορίσετε εάν υπάρχει αποθηκευμένη ρητή τιμή. Η τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή υποδεικνύει τη διατηρημένη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογισμένη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) για να καθορίσει αυτή τη διάρκεια. Η ρύθμιση ενός τύπου μετάβασης μπορεί να αρχικοποιήσει μια διάρκεια, γι' αυτό εξετάστε πρώτα τις αρχικές ρυθμίσεις.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Μετάβαση Morph**

Η μετάβαση Morph κινεί αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο αντίγραφο, και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό δίνει στα αντίστοιχα αντικείμενα την δυνατότητα να ανιματιστούν μεταξύ της αρχικής και της τροποποιημένης κατάστασής τους.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ορθογώνιο κειμένου, κλωνοποιεί τη διαφάνεια και αλλάζει τη θέση και το μέγεθος του ορθογωνίου στο αντίγραφο. Στη συνέχεια επιλέγει Morph από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε προβολέα παρουσίασης που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια μιας παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Τύποι Μετάβασης Morph**

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) ελέγχει πώς το Morph ταιριάζει και κινεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) αντιμετωπίζει κάθε σχήμα ως ολοκληρωμένο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) κινεί το κείμενο ταιριάζοντας λέξεις όπου είναι δυνατό.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) κινεί το κείμενο ταιριάζοντας χαρακτήρες όπου είναι δυνατό.

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Morph πριν αποκτήσετε πρόσβαση στο [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Η τιμή είναι στη συνέχεια μια παρουσία της κλάσης [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), της οποίας η μέθοδος [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) επιλέγει τη λειτουργία αντιστοίχισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και ρυθμίζει τη δεύτερη διαφάνεια να χρησιμοποιεί την κίνηση Morph με βάση τις λέξεις.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Ορισμός Εφέ Μετάβασης**

Ορισμένες μεταβάσεις εκθέτουν επιπλέον επιλογές, όπως κατεύθυνση ή αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τη μετάβαση που έχει επιλεγεί με το [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Καθορίστε πρώτα τον τύπο, στη συνέχεια χρησιμοποιήστε την κατάλληλη κλάση από το [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλεί το [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) μέσω του [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) όταν μια προκαθορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) — Slow, Medium ή Fast — είναι επαρκής και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από την αυτόματη καθυστέρηση προώθησης.

**Μπορώ να προσθέσω ήχο σε μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Ανάθεση εσώματου ήχου με το [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), περάστε το StartSound από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) στο [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode), και ενεργοποιήστε το [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) με `True`. Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσω την ίδια μετάβαση σε κάθε διαφάνεια;**

Κάντε βρόχο στη συλλογή [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) της παρουσίασης και καλέστε το [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν χρονικές και εφέ επιλογές στον ίδιο βρόχο για να διατηρήσετε τη συμπεριφορά συνεπή σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλείτε το [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) στο αποτέλεσμα του [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); το None_ σημαίνει ότι δεν έχει εφαρμοστεί κανένα εφέ μετάβασης.