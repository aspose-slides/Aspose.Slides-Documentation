---
title: Διαχείριση Μεταβάσεων Διαφανειών σε Παρουσιάσεις Χρησιμοποιώντας Python
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 90
url: /el/python-net/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προηγμένη μετάβαση διαφάνειας
- μετάβαση morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφανειών, διαμορφώστε αυτόματη προώθηση διαφανειών και προσαρμόστε το Morph και άλλα εφέ μετάβασης με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφανειών ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides for Python via .NET, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προώθηση με κλικ του ποντικιού ή χρονομετρητή, και να προσαρμόσετε επιλογές συγκεκριμένες για ένα εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα Python για την εφαρμογή μεταβάσεων, τον καθορισμό ακριβών διάρκειών μετάβασης, τη διαχείριση του χρόνου των διαφανειών και τη δημιουργία της μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και αποκτήστε πρόσβαση στην ιδιότητα [slide_show_transition](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/slide_show_transition/) της διαφάνειας. Ορίστε το [type](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/type/) σε μια τιμή από την αρίθμηση [TransitionType](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitiontype/) και, τέλος, αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει τη μετάβαση Circle στην πρώτη διαφάνεια και τη μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο χρόνο θα παραμένει μια διαφάνεια στην οθόνη και αν ένα κλικ ποντικιού θα προωθεί την παρουσίαση. Οι παρακάτω ιδιότητες ελέγχουν αυτή τη συμπεριφορά:

- [advance_on_click](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) επιτρέπει στον θεατή να προχωρήσει με κλικ του ποντικιού.
- [advance_after](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) ενεργοποιεί την αυτόματη προώθηση.
- [advance_after_time](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) καθορίζει την καθυστέρηση πριν από την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε τόσο το κλικ όσο και την χρονομετρημένη προώθηση ώστε ο θεατής να μπορεί να προχωρήσει με κλικ ή να περιμένει τον χρονομετρητή. Για χρήση μόνο του χρονομετρητή, ορίστε το [advance_on_click](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) σε `False`. Η καθυστέρηση ελέγχει πότε η παρουσίαση προχωρά· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα εκχωρεί διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προωθήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

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

Για να ελέγξετε αν η χρονομετρημένη προώθηση είναι ενεργή, διαβάστε το [advance_after](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Μια αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονομετρητής είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το αρχείο που αποθηκεύτηκε παραπάνω, αναφέρει κάθε ενεργό χρονομετρητή και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη των δύο δευτερολέπτων. Ενεργοποιεί τα κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

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

Χρησιμοποιήστε το [duration](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/duration/) για να ορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η ιδιότητα [slide_show_transition](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/slide_show_transition/) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [SlideShowTransition](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/):

| Ιδιότητα | Σκοπός |
| --- | --- |
| [duration](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Ορίζει τη διάρκεια του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [advance_after_time](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Ορίζει την καθυστέρηση πριν η διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Ενεργοποιήστε το [advance_after](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) για να ενεργοποιήσετε αυτόν τον χρονομετρητή. |
| [speed](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Επιλέγει μια προεπιλεγμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM ή FAST. Χρησιμοποιείται όταν δεν έχει καθοριστεί ακριβής διάρκεια. |

Το [duration](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ελέγχει μόνο το εφέ της μετάβασης· δεν καθορίζει πόσο καιρό παραμένει η διαφάνεια ορατή. Ρυθμίστε την αυτόματη καθυστέρηση προώθησης ξεχωριστά. Όταν δεν οριστεί ρητή διάρκεια, το Aspose.Slides υπολογίζει τη διάρκεια του εφέ με βάση τον τύπο της μετάβασης και την τιμή του [speed](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Εφαρμογή της Ίδιας Διάρκειας σε Όλες τις Διαφάνειες**

Για σταθερό ρυθμό, εφαρμόστε το ίδιο εφέ και ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitiontype/) και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστών του δευτερολέπτου. Ξεχωριστά ενεργοποιεί αυτόματη προώθηση μετά από 5 000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την προώθηση με κλικ, έπειτα αποθηκεύει το αποτέλεσμα ως PPTX.

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

### **Ορισμός Διαφορετικών Διάρκειών για Μεμονωμένες Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να χρησιμοποιούν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για μια διαφάνεια τίτλου και μια πιο μακριά για την εισαγωγή ενότητας. Αυτό το παράδειγμα ορίζει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1 200 χιλιοστά για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

### **Συντονισμός Μεταβάσεων με Αναπαράγονται Έξοδους**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/python-net/convert-powerpoint-to-animated-gif/), μιας [HTML5 presentation](/slides/el/python-net/export-to-html5/) ή ενός [video](/slides/el/python-net/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μετάβασης πριν την εξαγωγή ώστε να ταιριάζουν με το επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε μια εναλλαγή fade 600 ms μεταξύ σκηνών και προσαρμόστε ξεχωριστά την καθυστέρηση προώθησης κάθε διαφάνειας ώστε να υπάρχει χρόνος για αφήγηση ή περιεχόμενο.

Για GIF και βίντεο, συντονίστε το καρέ εξόδου με τη διάρκεια του εφέ: 600 ms αντιστοιχούν σε 18 καρέ στα 30 fps. Στο HTML5, ενεργοποιήστε τις animated transitions στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες εφέ και επιλογές χρονισμού της επιλεγμένης μορφής εξόδου και προεπισκοπήστε το αποτέλεσμα για επιβεβαίωση συγχρονισμού.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Διαβάστε το [duration](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/duration/) πριν τροποποιήσετε τη μετάβαση για να διαπιστώσετε εάν αποθηκεύεται ρητή τιμή. Η τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή υποδεικνύει την αποθηκευμένη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογισμένη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο της μετάβασης και το [speed](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/speed/) για να την υπολογίσει. Ο ορισμός τύπου μετάβασης μπορεί να αρχικοποιήσει μια διάρκεια, γι’ αυτό εξετάστε πρώτα τις αρχικές ρυθμίσεις.

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

Η μετάβαση Morph ανιματίζει τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλώνος μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στον κλώνο, και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό παρέχει στα αντίστοιχα αντικείμενα την δυνατότητα ανίμασης μεταξύ των αρχικών και των τροποποιημένων τους καταστάσεων.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ένα ορθογώνιο κείμενο, κλωνοποιεί τη διαφάνεια και αλλάζει τη θέση και το μέγεθος του ορθογωνίου στον κλώνο. Στη συνέχεια, επιλέγει Morph από την αρίθμηση [TransitionType](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε έναν προβολέα παρουσιάσεων που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια της παρουσίασης.

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

## **Τύποι Morph Μετάβασης**

Η αρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitionmorphtype/) ελέγχει πώς το Morph αντιστοιχίζει και ανιματίζει το περιεχόμενο:

- [BY_OBJECT](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitionmorphtype/) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [BY_WORD](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitionmorphtype/) ανιματίζει το κείμενο αντιστοιχίζοντας λέξεις όπου είναι δυνατόν.
- [BY_CHAR](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitionmorphtype/) ανιματίζει το κείμενο αντιστοιχίζοντας χαρακτήρες όπου είναι δυνατόν.

Ορίστε τη [type](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/type/) της μετάβασης σε Morph πριν αποκτήσετε πρόσβαση στην [value](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/value/). Η τιμή παρέχει το αντικείμενο [MorphTransition](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/morphtransition/), του οποίου η ιδιότητα [morph_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/morphtransition/morph_type/) επιλέγει τη λειτουργία αντιστοίχισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και ρυθμίζει τη δεύτερη διαφάνεια να χρησιμοποιεί ανίμαση με βάση τις λέξεις.

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

Κάποιες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως κατεύθυνση ή αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τον επιλεγμένο [type](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/type/). Ορίστε πρώτα τον τύπο, έπειτα χρησιμοποιήστε το κατάλληλο αντικείμενο μετάβασης από την [value](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Το παρακάτω παράδειγμα εφαρμόζει τη μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Ορίζει το [from_black](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) μέσω του [OptionalBlackTransition](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/optionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

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

Ναι. Χρησιμοποιήστε το [duration](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/duration/) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [speed](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/speed/) όταν αρκεί μια προκαθορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM ή FAST, και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ της μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προώθησης.

**Μπορώ να προσθέσω ήχο σε μια μετάβαση και να τον επαναλάβω;**

Ναι. Αναθέστε ενσωματωμένο ήχο στην ιδιότητα [sound](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/sound/), ορίστε το [sound_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) σε START_SOUND από την αρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitionsoundmode/), και ενεργοποιήστε το [sound_loop](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο γρηγορότερος τρόπος για να εφαρμόσω την ίδια μετάβαση σε όλες τις διαφάνειες;**

Διέλθετε τη συλλογή [slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slides/el/) της παρουσίασης και ορίστε την ιδιότητα [type](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/type/) της μετάβασης κάθε διαφάνειας στην ίδια τιμή. Ρυθμίστε τυχόν χρονικές και εφέ επιλογές στο ίδιο βρόχο ώστε η συμπεριφορά να παραμένει συνεπής σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Διαβάστε την ιδιότητα [type](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/slideshowtransition/type/) από την [slide_show_transition](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/slide_show_transition/) της διαφάνειας. Επιστρέφει μια τιμή από την αρίθμηση [TransitionType](https://reference.aspose.com/slides/el/python-net/aspose.slides.slideshow/transitiontype/); η τιμή NONE σημαίνει ότι δεν έχει εφαρμοστεί κανένα εφέ μετάβασης.