---
title: Διαχείριση Μεταβάσεων Διαφάνειας σε Παρουσιάσεις με JavaScript
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 80
url: /el/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφάνειας, διαμορφώστε αυτόματη προώθηση διαφανειών και προσαρμόστε το Morph και άλλα εφέ μετάβασης με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφάνειας ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides για Node.js μέσω Java, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προώθηση με κλικ του ποντικιού ή χρονομετρητή, και να προσαρμόσετε επιλογές ειδικές για το εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα JavaScript για την εφαρμογή μεταβάσεων, τον καθορισμό ακριβούς διάρκειας μετάβασης, τη διαχείριση του χρονοδιαγράμματος των διαφανειών και τη δημιουργία μιας μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και προσπελάστε τις ρυθμίσεις μετάβασης της διαφάνειας μέσω του [getSlideShowTransition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setType) με μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitiontype/), στη συνέχεια αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει τη μετάβαση Circle στην πρώτη διαφάνεια και τη μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο χρονικό διάστημα μια διαφάνεια παραμένει στην οθόνη και αν ένα κλικ του ποντικιού προχωρά την παρουσίαση. Οι παρακάτω μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [setAdvanceOnClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) επιτρέπει στον θεατή να προχωρήσει κάνοντας κλικ του ποντικιού.
- [setAdvanceAfter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) ενεργοποιεί αυτόματη προώθηση.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) καθορίζει την καθυστέρηση πριν την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε τόσο το κλικ όσο και την χρονομετρημένη προώθηση για να μπορεί ο θεατής να προχωρήσει με κλικ ή να περιμένει τον χρονομετρητή. Για να χρησιμοποιήσετε μόνο τον χρονομετρητή, περάστε `false` στο [setAdvanceOnClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Η καθυστέρηση ελέγχει πότε προχωρά η παρουσίαση· δεν καθορίζει τη διάρκεια του οπτικού εφέ της μετάβασης.

Αυτό το παράδειγμα αναθέτει διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προχωρήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Για να ελέγξετε εάν είναι ενεργοποιημένη η χρονομετρημένη προώθηση, καλέστε το [getAdvanceAfter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Μία αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονομετρητής είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το παραπάνω αποθηκευμένο αρχείο, αναφέρει κάθε ενεργό χρονομετρητή και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη από δύο δευτερόλεπτα. Ενεργοποιεί τα κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Χρόνου Μετάβασης με Ακρίβεια**

Χρησιμοποιήστε το [setDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setDuration) για να καθορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [getSlideShowTransition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας αποκαλύπτει αυτές τις ρυθμίσεις μέσω του [SlideShowTransition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Ορίζει τη διάρκεια του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ορίζει την καθυστέρηση πριν η διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Περάστε `true` στο [setAdvanceAfter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) για να ενεργοποιήσετε αυτόν τον χρονομετρητή. |
| [setSpeed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Επιλέγει μια προεπιλεγμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν έχει καθοριστεί ακριβής διάρκεια. |

Το [setDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setDuration) ελέγχει μόνο το εφέ της μετάβασης· δεν καθορίζει πόσο χρόνο η διαφάνεια παραμένει ορατή. Ρυθμίστε την αυτόματη καθυστέρηση προώθησης ξεχωριστά. Όταν δεν έχει οριστεί ρητή διάρκεια, το Aspose.Slides καθορίζει τη διάρκεια του εφέ βασιζόμενο στον τύπο της μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **Εφαρμογή της Ίδιας Διάρκειας σε Κάθε Διαφάνεια**

Για συνεπή ρυθμό, εφαρμόστε το ίδιο εφέ και ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitiontype/), και θέτει τη διάρκεια κάθε μετάβασης στα 750 χιλιοστά του δευτερολέπτου. Επίσης ενεργοποιεί αυτόματη προώθηση μετά από 5 000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την προώθηση με κλικ του ποντικιού, στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Διαμορφώστε την αυτόματη προώθηση ανεξάρτητα από τη διάρκεια του εφέ.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ορισμός Διαφορετικών Διάρκειων για Ατομικές Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να χρησιμοποιούν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για μια διαφάνεια τίτλου και μια μεγαλύτερη για μια εισαγωγή ενότητας. Αυτό το παράδειγμα θέτει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1 200 χιλιοστά του δευτερολέπτου για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Συγχρονισμός Μεταβάσεων με Αναπαραγόμενη Έξοδο**

Όταν ετοιμάζετε ένα [animated GIF](/slides/el/nodejs-java/convert-powerpoint-to-animated-gif/), μια [HTML5 presentation](/slides/el/nodejs-java/export-to-html5/) ή ένα [video](/slides/el/nodejs-java/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν την εξαγωγή ώστε να ταιριάζουν με το επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε ένα fade 600 χιλιοστών μεταξύ σκηνών και προσαρμόστε ξεχωριστά την καθυστέρηση προώθησης κάθε διαφάνειας ώστε να υπάρχει χρόνος για την αφήγηση ή το περιεχόμενο της.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ της εξόδου με τη διάρκεια του εφέ: 600 χιλιοστά του δευτερολέπτου αντιστοιχούν σε 18 καρέ στα 30 καρέ ανά δευτερόλεπτο. Σε HTML5, ενεργοποιήστε τις animated μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες εφέ και επιλογές χρόνου του επιλεγμένου μορφότυπου εξόδου και προεπισκοπήστε το αποτέλεσμα για επιβεβαίωση του συγχρονισμού.

### **Ανάγνωση Υπάρχουσας Διάργειας Μετάβασης**

Καλέστε το [getDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#getDuration) πριν τροποποιήσετε τη μετάβαση για να διαπιστώσετε αν υπάρχει αποθηκευμένη ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή καθορίζει τη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογιζόμενη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο της μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) για να την καθορίσει. Ο ορισμός ενός τύπου μετάβασης μπορεί να αρχικοποιήσει μια διάρκεια, γι' αυτό εξετάστε πρώτα τις αρχικές ρυθμίσεις.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Μετάβαση Morph**

Η μετάβαση Morph κινεί τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο κλώνο και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό δίνει στα αντίστοιχα αντικείμενα τη δυνατότητα να κινούνται μεταξύ της αρχικής και της τροποποιημένης τους κατάστασης.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ένα πλαίσιο κειμένου, κλωνοποιεί τη διαφάνεια και αλλάζει τη θέση και το μέγεθος του πλαισίου στο κλώνο. Στη συνέχεια επιλέγει Morph από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε μια προβολή παρουσίασης που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια της παρουσίασης.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Τύποι Μετάβασης Morph**

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitionmorphtype/) ελέγχει πώς το Morph αντιστοιχεί και κινεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) αντιμετωπίζει κάθε σχήμα ως όλο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) κινεί το κείμενο αντιστοιχίζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) κινεί το κείμενο αντιστοιχίζοντας χαρακτήρες όπου είναι δυνατόν.

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Morph πριν προσπελάσετε το [getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#getValue). Η τιμή παρέχει ένα αντικείμενο [MorphTransition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/morphtransition/), του οποίου η μέθοδος [setMorphType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/morphtransition/#setMorphType) επιλέγει τη λειτουργία αντιστοίχισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και διαμορφώνει τη δεύτερη διαφάνεια ώστε να χρησιμοποιεί Morph με βάση τις λέξεις.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Ορισμός Εφέ Μετάβασης**

Μερικές μεταβάσεις αποκαλύπτουν πρόσθετες επιλογές, όπως κατεύθυνση ή εάν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τη μετάβαση που επιλέχθηκε με το [setType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setType). Ορίστε τον τύπο πρώτα, μετά χρησιμοποιήστε το αντίστοιχο αντικείμενο μετάβασης από το [getValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλεί το [setFromBlack](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) μέσω του [OptionalBlackTransition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/optionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [setDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setDuration) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [setSpeed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) όταν αρκεί μια προεπιλεγμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitionspeed/) – Slow, Medium ή Fast – και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ της μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προώθησης.

**Μπορώ να συνδέσω ήχο με μια μετάβαση και να τον επαναλαμβαίνω;**

Ναι. Ανάθετε ενσωματωμένο ήχο με το [setSound](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setSound), περάστε το `StartSound` από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitionsoundmode/) στο [setSoundMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) και ενεργοποιήστε το [setSoundLoop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) με `true`. Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο πιο γρήγορος τρόπος να εφαρμόσω την ίδια μετάβαση σε όλες τις διαφάνειες;**

Διέξτε τη συλλογή [getSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSlides) της παρουσίασης και καλέστε το [setType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#setType) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν χρόνους και επιλογές εφέ στον ίδιο βρόχο ώστε η συμπεριφορά να είναι σταθερή σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλέστε το [getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/#getType) στο αποτέλεσμα του [getSlideShowTransition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitiontype/); η τιμή None σημαίνει ότι δεν έχει εφαρμοστεί εφέ μετάβασης.