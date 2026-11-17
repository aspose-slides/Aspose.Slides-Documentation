---
title: Διαχείριση μεταβάσεων διαφανειών σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 80
url: /el/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφανειών, ρυθμίστε την αυτόματη προώθηση διαφανειών και προσαρμόστε το Morph και άλλα εφέ μετάβασης με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφανειών ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides for Node.js via Java, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προώθηση με κλικ του ποντικιού ή χρονόμετρο, και να προσαρμόσετε επιλογές ειδικές για το εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα JavaScript για την εφαρμογή μεταβάσεων, ορισμό ακριβών διάρκειών μετάβασης, διαχείριση χρόνου διαφάνειας και δημιουργία μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης της διαφάνειας μέσω του [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) με τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), στη συνέχεια αποθηκεύστε την παρουσίαση.

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

## **Μετάβαση Τροχού**

Η μέθοδος [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) της [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) ελέγχει τον αριθμό των ακτινωτών τομέων που αποκαλύπτουν τη διαφάνεια προορισμού. Ορίστε τον τύπο μετάβασης της διαφάνειας σε Wheel από το [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) χρησιμοποιώντας το [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) πριν αποκτήσετε πρόσβαση στο [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) ως [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

Αυτό το παράδειγμα δημιουργεί δύο ζευγάρια διαφανειών ταυτόσημα: μια μαύρη διαφάνεια ακολουθείται από μια διαφάνεια με χρυσό ορθογώνιο. Οι διαφάνειες προορισμού χρησιμοποιούν αριθμούς ακτίνων 1 και 8, με την ίδια ταχύτητα που ορίστηκε μέσω του [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) και μια ρητή διάρκεια 8 000 χιλιοστών του δευτερολέπτου μέσω του [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) για να γίνει η διαφορά εύκολα παρατηρήσιμη.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ανοίξτε την έξοδο παρουσίασης στο PowerPoint και εκτελέστε την παρουσίαση. Προχωρήστε από τη διαφάνεια 1 στη διαφάνειας 2, μετά από τη διαφάνεια 3 στη διαφάνεια 4. Στην αναπαραγωγή του PowerPoint, ο επιβεβαιωμένος αριθμός ακτίνων 1 αποκαλύπτει τη διαφάνεια με μία κυκλική σάρωση· ο αριθμός 8 αποκαλύπτει τη διαφάνεια μέσω οχτώ ακτινωτών τομέων ταυτόχρονα. Το περιεχόμενο προορισμού και ο χρόνος μετάβασης είναι ταυτόσημα, επομένως η διαφορά είναι ο αριθμός των τομέων αποκάλυψης.

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο χρόνο παραμένει μια διαφάνεια στην οθόνη και αν ένα κλικ του ποντικιού προχωρά την παρουσίαση. Οι παρακάτω μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) επιτρέπει στον θεατή να προωθήσει με κλικ του ποντικιού.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) ενεργοποιεί την αυτόματη προώθηση.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) καθορίζει την καθυστέρηση πριν την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε τόσο το κλικ όσο και την χρονομετρημένη προώθηση ώστε ο θεατής να προχωρά με κλικ ή να περιμένει το χρονόμετρο. Για να χρησιμοποιήσετε μόνο το χρονόμετρο, περάστε `false` στη [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Η καθυστέρηση ελέγχει πότε προχωρά η παρουσίαση· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα αναθέτει διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προωθήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

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

Για να ελέγξετε αν η χρονομετρημένη προώθηση είναι ενεργοποιημένη, καλέστε το [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Μια αποθηκευμένη μόνο καθυστέρηση δεν υποδεικνύει ότι το χρονόμετρο είναι ενεργό.

Το επόμενο παράδειγμα ανοίγει το αρχείο που αποθηκεύτηκε παραπάνω, αναφέρει κάθε ενεργό χρονόμετρο και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη από δύο δευτερόλεπτα. Ενεργοποιεί τα κλικ του ποντικιού για εκείνες τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

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

## **Ακριβής Έλεγχος Χρόνου Μετάβασης**

Χρησιμοποιήστε το [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) για να καθορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας αποκαλύπτει αυτές τις ρυθμίσεις μέσω του [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Ορίζει τη διάρκεια του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ορίζει την καθυστέρηση πριν η διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Περάστε `true` στη [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) για να ενεργοποιήσετε αυτό το χρονόμετρο. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Επιλέγει μια προκαθορισμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν έχει οριστεί ρητή διάρκεια. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) ελέγχει μόνο το εφέ μετάβασης· δεν καθορίζει πόσο χρόνο παραμένει η διαφάνεια ορατή. Ρυθμίστε την καθυστέρηση αυτόματης προώθησης ξεχωριστά. Όταν δεν έχει οριστεί ρητή διάρκεια, το Aspose.Slides καθορίζει τη διάρκεια του εφέ από τον τύπο μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Τα διακριτά μπαρ αναδεικνύουν τη διάρκεια 750 ms της μετάβασης και τη ρυθμίση αυτόματης προώθησης 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Το κοινό παράδειγμα δίνει σε κάθε διαφάνεια μια μετάβαση Fade 750 ms και ενεργοποιεί ξεχωριστά την αυτόματη προώθηση στα 5 000 ms. Η διάρκεια της μετάβασης ελέγχει το εφέ· η προώθηση ελέγχει πότε να φύγει η διαφάνεια. Αυτά τα μπαρ είναι σχήματα ρυθμίσεων, όχι μετρημένο συνδυαστικό χρονοδιάγραμμα.*
<!-- visual-explanation:slide-transition:end -->

### **Εφαρμογή Ίδιας Διάρκειας σε Όλες τις Διαφάνειες**

Για συνεπή ρυθμό, εφαρμόστε το ίδιο εφέ και ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), και δίνει σε κάθε μετάβαση διάρκεια 750 ms. Ενεργοποιεί ξεχωριστά την αυτόματη προώθηση μετά από 5 000 ms και απενεργοποιεί την προώθηση με κλικ του ποντικιού, στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX.

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

### **Ορισμός Διαφορετικών Διαρκειών για Μεμονωμένες Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να χρησιμοποιούν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για τη διαφάνεια τίτλου και μια μεγαλύτερη για την εισαγωγή ενότητας. Αυτό το παράδειγμα ορίζει 500 ms για την πρώτη διαφάνεια και 1 200 ms για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

### **Συντονισμός Μεταβάσεων με Αναπαραγωγικό Έξοδο**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/nodejs-java/convert-powerpoint-to-animated-gif/), μιας [HTML5 presentation](/slides/el/nodejs-java/export-to-html5/) ή ενός [video](/slides/el/nodejs-java/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν την εξαγωγή για να ταιριάζουν με το προγραμματισμένο ρυθμό. Για παράδειγμα, χρησιμοποιήστε ένα fade 600 ms μεταξύ σκηνών και προσαρμόστε την καθυστέρηση προώθησης κάθε διαφάνειας ξεχωριστά ώστε να υπάρχει χρόνος για αφήγηση ή περιεχόμενο.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ της εξόδου με τη διάρκεια του εφέ: 600 ms ισοδυναμούν με 18 καρέ σε 30 fps. Στο HTML5, ενεργοποιήστε τις animated transitions στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες επιλογές εφέ και χρόνου της μορφής εξόδου και προεπισκόπηση του αποτελέσματος για επαλήθευση του συγχρονισμού.

### **Ανάγνωση Υπαρκτής Διάρκειας Μετάβασης**

Καλέστε το [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) πριν τροποποιήσετε τη μετάβαση για να προσδιορίσετε εάν υπάρχει αποθηκευμένη ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή υποδεικνύει τη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογιζόμενη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) για να καθορίσει αυτή τη διάρκεια. Ορίζοντας έναν τύπο μετάβασης μπορεί να αρχικοποιήσει διάρκεια, επομένως εξετάστε πρώτα τις αρχικές ρυθμίσεις.

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

Η μετάβαση Morph αναπαριστά τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο κλώνο, και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό παρέχει στα αντίστοιχα αντικείμενα το εφέ κίνησης μεταξύ των αρχικών και των τροποποιημένων τους καταστάσεων.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ένα κείμενο σε ορθογώνιο, κλωνοποιεί τη διαφάνεια, και αλλάζει τη θέση και το μέγεθος του ορθογώνιου στο κλώνο. Στη συνέχεια επιλέγει Morph από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε προβολέα παρουσίασης που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια της παρουσίασης.

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

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) ελέγχει πώς το Morph αντιστοιχεί και αναπαριστά το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) αναπαριστά το κείμενο αντιστοιχίζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) αναπαριστά το κείμενο αντιστοιχίζοντας χαρακτήρες όπου είναι δυνατόν.

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Morph πριν αποκτήσετε πρόσβαση στο [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue). Η τιμή στη συνέχεια παρέχει ένα αντικείμενο [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/), του οποίου η μέθοδος [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) επιλέγει τη λειτουργία αντιστοίχισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και ρυθμίζει τη δεύτερη διαφάνεια να χρησιμοποιεί την κίνηση Morph με βάση τις λέξεις.

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

Κάποιες μεταβάσεις εκθέτουν επιπλέον επιλογές, όπως κατεύθυνση ή αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τη μετάβαση που επιλέχθηκε με το [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType). Ορίστε πρώτα τον τύπο, έπειτα χρησιμοποιήστε το κατάλληλο αντικείμενο μετάβασης από το [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλεί τη μέθοδο [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) μέσω του [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

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

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) όταν μια προκαθορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/)—Slow, Medium ή Fast—είναι επαρκής και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προώθησης.

**Μπορώ να προσθέσω ήχο σε μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Αναθέστε ενσωματωμένο ήχο με το [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound), περάστε το StartSound από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) στη [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode), και ενεργοποιήστε το [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) με `true`. Ο ήχος επαναλαμβάνεται μέχρι το επόμενο γεγονός ήχου στην παρουσίαση.

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσω την ίδια μετάβαση σε όλες τις διαφάνειες;**

Διατρέξτε τη συλλογή [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) της παρουσίασης και καλέστε το [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) με την ίδια τιμή για κάθε μετάβαση διαφάνειας. Ορίστε τυχόν χρονικές και εφέ επιλογές στον ίδιο βρόχο για να διατηρήσετε τη συμπεριφορά συνεπή μεταξύ των διαφανειών.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι επίμονη σε μια διαφάνεια;**

Καλέστε το [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) στο αποτέλεσμα του [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/); Η τιμή None σημαίνει ότι δεν έχει εφαρμοστεί κανένα εφέ μετάβασης.