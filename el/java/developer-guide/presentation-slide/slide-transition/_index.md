---
title: Διαχείριση Μεταβάσεων Διαφάνειας σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 80
url: /el/java/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προχωρημένη μετάβαση διαφάνειας
- μετάβαση morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφάνειας, διαμορφώστε την αυτόματη προώθηση διαφανειών και προσαρμόστε το Morph και άλλα εφέ μετάβασης με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφάνειας ελέγχουν πώς οι διαφάνειες εμφανίζονται κατά τη διάρκεια μιας παρουσίασης διαφανειών. Με το Aspose.Slides for Java, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να διαμορφώσετε την προώθηση με κλικ ποντικιού ή χρονοδιακόπτη και να προσαρμόσετε επιλογές συγκεκριμένες για ένα εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα Java για να εφαρμόσει μεταβάσεις, να ορίσει ακριβείς διάρκειες μετάβασης, να διαχειριστεί το χρονοδιάγραμμα των διαφανειών και να δημιουργήσει μια μετάβαση Morph μεταξύ δύο διαφανειών. Τα παραδείγματα επίσης δείχνουν πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης της διαφάνειας μέσω του [getSlideShowTransition](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setType-int-) με μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitiontype/), μετά αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Circle στην πρώτη διαφάνεια και μια μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` που περιέχει τουλάχιστον δύο διαφάνειες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Προχωρημένης Μετάβασης Διαφάνειας**

Μπορείτε να διαμορφώσετε πόσο χρόνο μια διαφάνεια παραμένει στην οθόνη και εάν ένα κλικ ποντικιού προωθεί την παρουσίαση. Οι παρακάτω μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [setAdvanceOnClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) επιτρέπει στον προβάλλοντα να προχωρήσει κάνοντας κλικ με το ποντίκι.
- [setAdvanceAfter](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) ενεργοποιεί την αυτόματη προώθηση.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) καθορίζει την καθυστέρηση πριν από την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε τόσο το κλικ όσο και την χρονομετρημένη προώθηση ώστε ο προβάλλον να προχωράει με κλικ ή να περιμένει το χρονοδιακόπτη. Για να χρησιμοποιήσετε μόνο τον χρονοδιακόπτη, περάστε `false` στο [setAdvanceOnClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Η καθυστέρηση ελέγχει πότε η παρουσίαση προχωρά, αλλά δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα αναθέτει διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί την αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ ποντικιού μπορούν επίσης να προωθήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Για να ελέγξετε αν η χρονομετρημένη προώθηση είναι ενεργοποιημένη, καλέστε το [getAdvanceAfter](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter-boolean-). Μία αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονοδιακόπτης είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το αποθηκευμένο παραπάνω αρχείο, αναφέρει κάθε ενεργό χρονοδιακόπτη και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη των δύο δευτερολέπτων. Ενεργοποιεί τα κλικ ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Χρόνου Μετάβασης Ακριβώς**

Χρησιμοποιήστε το [setDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setDuration-int-) για να καθορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [getSlideShowTransition](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [ISlideShowTransition](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Ορίζει τη διάρκεια του ίδιου εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Ορίζει την καθυστέρηση πριν από την αυτόματη προώθηση της διαφάνειας, σε χιλιοστά του δευτερολέπτου. Περάστε `true` στο [setAdvanceAfter](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) για να ενεργοποιήσετε αυτό το χρονοδιακόπτη. |
| [setSpeed](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Επιλέγει μια προκαθορισμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν ορίζεται ακριβής διάρκεια. |

Το [setDuration] ελέγχει μόνο το εφέ μετάβασης· δεν καθορίζει πόσο χρόνο η διαφάνεια παραμένει ορατή. Ρυθμίστε χωριστά την καθυστέρηση της αυτόματης προώθησης. Όταν δεν ορίζεται ρητή διάρκεια, το Aspose.Slides καθορίζει τη διάρκεια του εφέ από τον τύπο μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Εφαρμογή Ίδιας Διάρκειας σε Κάθε Διαφάνεια**

Για συνεπές ρυθμό, εφαρμόστε το ίδιο εφέ και ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitiontype/), και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστών του δευτερολέπτου. Ενεργοποιεί χωριστά την αυτόματη προώθηση μετά από 5.000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την προώθηση με κλικ ποντικιού, στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Διαμορφώστε την αυτόματη προώθηση ανεξάρτητα από τη διάρκεια του εφέ.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ορισμός Διαφορετικών Διάρκειων για Ατομικές Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να χρησιμοποιούν διαφορετικές διάρκειες εφέ. Αυτό το παράδειγμα ορίζει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1.200 χιλιοστά του δευτερολέπτου για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Συντονισμός Μεταβάσεων με Κινούμενη Έξοδο**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/java/convert-powerpoint-to-animated-gif/), μιας [HTML5 presentation](/slides/el/java/export-to-html5/), ή ενός [video](/slides/el/java/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν από την εξαγωγή για να ταιριάζουν με τον επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε ένα fade 600 χιλιοστών του δευτερολέπτου μεταξύ σκηνών και προσαρμόστε χωριστά την καθυστέρηση προώθησης κάθε διαφάνειας ώστε να υπάρχει χρόνος για την αφήγηση ή το περιεχόμενό της.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ της εξόδου με τη διάρκεια του εφέ: 600 χιλιοστά του δευτερολέπτου αντιστοιχούν σε 18 καρέ σε 30 καρέ ανά δευτερόλεπτο. Στο HTML5, ενεργοποιήστε τις κινούμενες μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τα υποστηριζόμενα εφέ και τις επιλογές χρόνου του επιλεγμένου μορφής εξαγωγής και προεπισκοπήστε το αποτέλεσμα για να επιβεβαιώσετε τον συγχρονισμό.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Καλέστε το [getDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#getDuration--) πριν τροποποιήσετε τη μετάβαση για να προσδιορίσετε αν υπάρχει αποθηκευμένη ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή καθορίζει τη αποθηκευμένη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογισμένη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#getSpeed--) για να καθορίσει αυτή τη διάρκεια. Ο ορισμός ενός τύπου μετάβασης μπορεί να αρχικοποιήσει μια διάρκεια, οπότε εξετάστε πρώτα τις αρχικές ρυθμίσεις.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Μετάβαση Morph**

Η μετάβαση Morph ανιματοποιεί τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο κλώνο και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό παρέχει στη μετάβαση τα αντίστοιχα αντικείμενα για να ανιματοποιηθούν μεταξύ των αρχικών και τροποποιημένων καταστάσεών τους.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Τύποι Μετάβασης Morph**

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitionmorphtype/) ελέγχει πώς το Morph αντιστοιχεί και ανιματοποιεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitionmorphtype/#ByObject) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitionmorphtype/#ByWord) ανιματοποιεί το κείμενο αντιστοιχίζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitionmorphtype/#ByChar) ανιματοποιεί το κείμενο αντιστοιχίζοντας χαρακτήρες όπου είναι δυνατόν.

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setType-int-) για να επιλέξετε Morph πριν αποκτήσετε πρόσβαση στο [getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#getValue--). Η τιμή παρέχει στη συνέχεια το περιβάλλον [IMorphTransition](https://reference.aspose.com/slides/el/java/com.aspose.slides/imorphtransition/), του οποίου η μέθοδος [setMorphType](https://reference.aspose.com/slides/el/java/com.aspose.slides/imorphtransition/#setMorphType-int-) επιλέγει τη λειτουργία αντιστοίχισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και διαμορφώνει τη δεύτερη διαφάνεια ώστε να χρησιμοποιεί τη λέξη‑βάση ανιματοποίηση Morph.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Ορισμός Εφέ Μετάβασης**

Κάποιες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως η κατεύθυνση ή το αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τη μετάβαση που επιλέγεται με το [setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setType-int-). Ορίστε πρώτα τον τύπο, στη συνέχεια χρησιμοποιήστε το κατάλληλο περιβάλλον από το [getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#getValue--).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλεί το [setFromBlack](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) μέσω του [IOptionalBlackTransition](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioptionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθνη.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [setDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setDuration-int-) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [setSpeed](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) όταν αρκεί μια προκαθορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitionspeed/): Slow, Medium ή Fast — και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από την καθυστέρηση της αυτόματης προώθησης.

**Μπορώ να προσθέσω ήχο σε μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Αναθέστε ενσωματωμένο ήχο με το [setSound](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), περάστε το StartSound από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitionsoundmode/) στο [setSoundMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), και ενεργοποιήστε το [setSoundLoop](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) με `true`. Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσετε την ίδια μετάβαση σε κάθε διαφάνεια;**

Περάστε με βρόχο τη συλλογή [getSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlides--) της παρουσίασης και καλέστε το [setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#setType-int-) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν επιλογές χρόνου και εφέ στον ίδιο βρόχο ώστε να διατηρείται η συμπεριφορά συνεπής σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλέστε το [getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideshowtransition/#getType--) στο αποτέλεσμα του [getSlideShowTransition](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitiontype/); Το None σημαίνει ότι δεν έχει εφαρμοστεί κανένα εφέ μετάβασης.