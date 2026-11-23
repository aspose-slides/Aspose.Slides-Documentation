---
title: Διαχείριση Μεταβάσεων Διαφανειών σε Παρουσιάσεις με τη χρήση Python
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 90
url: /el/python-net/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προηγμένη μετάβαση διαφάνειας
- μετάβαση Morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφανειών, διαμορφώστε την αυτόματη προώθηση διαφάνειας και προσαρμόστε το Morph και άλλα εφέ μετάβασης με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφανειών ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης διαφανειών. Με το Aspose.Slides for Python via .NET, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να διαμορφώσετε την προώθηση με κλικ του ποντικιού ή χρονομετρητή και να προσαρμόσετε επιλογές ειδικές για ένα εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα Python για την εφαρμογή μεταβάσεων, τον καθορισμό ακριβών χρόνων μετάβασης, τη διαχείριση του χρονισμού των διαφανειών και τη δημιουργία μιας μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και αποκτήστε πρόσβαση στην ιδιότητα [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) της διαφάνειας. Ορίστε το [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) σε μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) και, στη συνέχεια, αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Circle στην πρώτη διαφάνεια και μια μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Μετάβαση Τροχού**

Η ιδιότητα [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) του [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) ελέγχει τον αριθμό των ακτινωτών τμημάτων που αποκαλύπτουν τη διαφάνεια προορισμού. Ορίστε το [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) της μετάβασης της διαφάνειας σε WHEEL από την [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) πριν αποκτήσετε πρόσβαση στο [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) ως [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Αυτό το παράδειγμα δημιουργεί δύο ταυτόσημα ζεύγη διαφανειών: μια μαύρη διαφάνεια ακολουθούμενη από μία με χρυσό ορθογώνιο. Οι διαφάνειες προορισμού χρησιμοποιούν αριθμούς spokes 1 και 8, με την ίδια [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) και μια ρητή [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) των 8 000 χιλιοστών του δευτερολέπτου για να είναι εύκολη η παρατήρηση της διαφοράς.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Ανοίξτε την έξοδο παρουσίασης στο PowerPoint και εκτελέστε την παρουσίαση. Προχωρήστε από τη διαφάνεια 1 στη 2, έπειτα από τη 3 στη 4. Στην αναπαραγωγή του PowerPoint, ο επαληθευμένος αριθμός spokes 1 αποκαλύπτει τη διαφάνεια με ένα δεξιόστροφο σκαλί, ενώ ο αριθμός 8 την αποκαλύπτει μέσω οκτώ ακτινωτών τμημάτων ταυτόχρονα. Το περιεχόμενο προορισμού και ο χρονισμός της μετάβασης είναι πανομοιότυπα· η διαφορά είναι ο αριθμός των τμημάτων αποκάλυψης.

## **Fade Through Black με τη Μετάβαση Reveal**

Ορίστε το [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) της διαφάνειας προορισμού σε Reveal, έπειτα ορίστε το [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) στο αντικείμενο [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/). Το παράδειγμα δημιουργεί μια γαλήνια (teal) διαφάνεια προέλευσης και μια κοραλί (coral) διαφάνεια προορισμού, στη συνέχεια κλωνοποιεί το ζεύγος. Και τα δύο ζεύγη χρησιμοποιούν την ίδια δύο‑δευτερόλεπτη μετάβαση Reveal. Μόνο το δεύτερο ζεύγος εμφανίζει fade μέσω μαύρου.

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Ανοίξτε το `reveal-transitions.pptx` στο PowerPoint και ξεκινήστε την παρουσίαση. Προχωρήστε από τη διαφάνεια 1 στη 2 για να δείτε το teal να ξεθωριάζει απευθείας στο coral. Έπειτα προχωρήστε από τη διαφάνεια 3 στη 4. Η οθόνη σκοτεινιάζει προσωρινά σχεδόν μέχρι το μαύρο πριν εμφανιστεί η διαφάνεια coral. Και οι δύο διαφάνειες διατηρούν τα αρχικά χρώματα φόντου.

Οι παρακάτω σειρές δείχνουν καρέ από το PowerPoint σε διαλείμματα μισού δευτερολέπτου. Συγκρίνετε το μεσαίο καρέ σε κάθε σειρά για να δείτε το αποτέλεσμα της ρύθμισης.

![Αναπαραγωγή PowerPoint με το through_black ανενεργό (πάνω) και ενεργό (κάτω). Μόνο η κάτω σειρά περνά από σχεδόν μαύρο.](reveal-through-black.png)

## **Πρόσθεση Προηγμένης Μετάβασης Διαφάνειας**

Μπορείτε να διαμορφώσετε πόσο καιρό παραμένει μια διαφάνεια στην οθόνη και αν ένα κλικ του ποντικιού προωθεί την παρουσίαση. Οι παρακάτω ιδιότητες ελέγχουν αυτή τη συμπεριφορά:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) επιτρέπει στον θεατή να προχωρήσει με κλικ του ποντικιού.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) ενεργοποιεί αυτόματη προώθηση.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) ορίζει την καθυστέρηση πριν από την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε και το κλικ και την χρονομετρημένη προώθηση ώστε ο θεατής να μπορεί να προχωρήσει με κλικ ή να περιμένει το χρονομετρητή. Για χρήση μόνο του χρονομετρητή, θέστε το [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) σε `False`. Η καθυστέρηση ελέγχει πότε προχωρά η παρουσίαση· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα εκχωρεί διαφορετικές μεταβάσεις στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προωθήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Για να ελέγξετε αν η χρονομετρημένη προώθηση είναι ενεργή, διαβάστε το [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Μία αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονομετρητής είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το αρχείο που αποθηκεύτηκε παραπάνω, αναφέρει κάθε ενεργό χρονομετρητή και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη από δύο δευτερόλεπτα. Ενεργοποιεί κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Ακριβής Έλεγχος Χρόνου Μετάβασης**

Χρησιμοποιήστε το [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) για να ορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η ιδιότητα [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Ιδιότητα | Σκοπός |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Ορίζει τη διάρκεια του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Ορίζει την καθυστέρηση πριν η διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Ενεργοποιήστε το [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) για να ενεργοποιήσετε αυτόν τον χρονομετρητή. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Επιλέγει μια προ‑ορισμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM ή FAST. Χρησιμοποιείται όταν δεν έχει οριστεί ακριβής διάρκεια. |

Το [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ελέγχει μόνο το εφέ μετάβασης· δεν καθορίζει πόσο καιρό παραμένει η διαφάνεια ορατή. Διαμορφώστε την αυτόματη καθυστέρηση προώθησης ξεχωριστά. Όταν δεν έχει οριστεί ρητή διάρκεια, το Aspose.Slides υπολογίζει τη διάρκεια του εφέ από τον τύπο μετάβασης και την τιμή [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Ξεχωριστές γραμμές δείχνουν τη διάρκεια μετάβασης 750 ms και τη ρύθμιση αυτόματης προώθησης 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Το κοινό παράδειγμα δίνει σε κάθε διαφάνεια μια μετάβαση Fade 750 ms και ενεργοποιεί ξεχωριστά την αυτόματη προώθηση στα 5 000 ms. Η διάρκεια της μετάβασης ελέγχει το εφέ· η προώθηση ελέγχει πότε θα φύγει η διαφάνεια. Αυτές οι γραμμές είναι σχηματικές ρυθμίσεις, όχι μετρημένο συνδυασμένο χρονοδιάγραμμα.*
<!-- visual-explanation:slide-transition:end -->

### **Εφαρμογή Ίδιας Διάρκειας σε Κάθε Διαφάνεια**

Για σταθερό ρυθμό, εφαρμόστε το ίδιο εφέ και την ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από την [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστών του δευτερολέπτου. Ενεργοποιεί ξεχωριστά την αυτόματη προώθηση μετά από 5 000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την προώθηση με κλικ, έπειτα αποθηκεύει το αποτέλεσμα ως PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Διαμορφώστε την αυτόματη προώθηση ανεξάρτητα από τη διάρκεια του εφέ.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Ορισμός Διαφορετικών Διάρκειών για Ατομικές Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να έχουν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για μια διαφάνεια τίτλου και μια πιο μακριά για μια εισαγωγή ενότητας. Αυτό το παράδειγμα ορίζει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1 200 χιλιοστά του δευτερολέπτου για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Συντονισμός Μεταβάσεων με Αναπαραγωγικό Έξοδο**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/python-net/convert-powerpoint-to-animated-gif/), μιας [HTML5 παρουσίασης](/slides/el/python-net/export-to-html5/) ή ενός [video](/slides/el/python-net/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν την εξαγωγή για να ταιριάζει με τον επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε ένα fade 600 ms μεταξύ σκηνών και ρυθμίστε ξεχωριστά την καθυστέρηση προώθησης κάθε διαφάνειας ώστε να υπάρχει χρόνος για αφήγηση ή περιεχόμενο.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ εξόδου με τη διάρκεια του εφέ: 600 ms αντιστοιχούν σε 18 καρέ στα 30 fps. Στο HTML5, ενεργοποιήστε τις animated μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες επιλογές εφέ και χρόνου της μορφής εξαγωγής και προεπισκοπήστε το αποτέλεσμα για να βεβαιωθείτε για το συγχρονισμό.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Διαβάστε το [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) πριν τροποποιήσετε τη μετάβαση για να προσδιορίσετε αν υπάρχει αποθηκευμένη ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή υποδεικνύει τη αποθηκευμένη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογισμένη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο μετάβασης και το [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) για να την προσδιορίσει. Ο ορισμός τύπου μετάβασης μπορεί να αρχικοποιήσει διάρκεια, γι' αυτό εξετάστε πρώτα τις αρχικές ρυθμίσεις.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Μετάβαση Morph**

Η μετάβαση Morph ανιματοποιεί τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο αντίγραφό της, και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό δίνει στα αντίστοιχα αντικείμενα τη δυνατότητα ανίμασης μεταξύ των αρχικών και των τροποποιημένων καταστάσεων.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ένα ορθογώνιο κείμενο, κλωνοποιεί τη διαφάνεια και αλλάζει τη θέση και το μέγεθος του ορθογωνίου στο αντίγραφο. Στη συνέχεια επιλέγει Morph από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε προβολέα παρουσίασης που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια της παρουσίασης.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Τύποι Μετάβασης Morph**

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) ελέγχει πώς το Morph ταιριάζει και ανιματοποιεί το περιεχόμενο:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) ανιματοποιεί το κείμενο ταιριάζοντας λέξεις όποτε είναι δυνατόν.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) ανιματοποιεί το κείμενο ταιριάζοντας χαρακτήρες όποτε είναι δυνατόν.

Ορίστε το [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) στη Morph πριν αποκτήσετε πρόσβαση στο [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Η τιμή παρέχει το αντικείμενο [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), του οποίου η ιδιότητα [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) επιλέγει τη λειτουργία αντιστοίχισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και ρυθμίζει τη δεύτερη διαφάνεια να χρησιμοποιεί ανιματισμό Morph βάσει λέξεων.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Ορισμός Εφέ Μετάβασης**

Κάποιες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως κατεύθυνση ή αν το εφέ αρχίζει από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τον επιλεγμένο [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Ορίστε πρώτα τον τύπο, μετά χρησιμοποιήστε το αντίστοιχο αντικείμενο μετάβασης από το [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Ορίζει το [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) μέσω του [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) όταν μια προ‑ορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM ή FAST — είναι αρκετή και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προώθησης.

**Μπορώ να συνδέσω ήχο με μια μετάβαση και να τον κάνω βρόχο;**

Ναι. Αναθέστε ενσωματωμένο ήχο στο [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), θέστε το [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) σε START_SOUND από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/), και ενεργοποιήστε το [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό συμβάν στην παρουσίαση.

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσω την ίδια μετάβαση σε όλες τις διαφάνειες;**

Διέλθετε τη συλλογή [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) της παρουσίασης και θέστε για κάθε διαφάνεια το [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) στην ίδια τιμή. Ορίστε τυχόν χρονικές ρυθμίσεις και επιλογές εφέ στον ίδιο βρόχο ώστε να διατηρείται η συμπεριφορά συνεπής σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτήν τη στιγμή ορισμένη σε μια διαφάνεια;**

Διαβάστε την ιδιότητα [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) από το [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE σημαίνει ότι δεν έχει εφαρμοστεί κανένα εφέ μετάβασης.