---
title: Διαχείριση μεταβάσεων διαφάνειας σε παρουσιάσεις σε Android
linktitle: Μετάβαση διαφάνειας
type: docs
weight: 80
url: /el/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφάνειας, διαμορφώστε την αυτόματη προώθηση διαφανειών και προσαρμόστε τη μετάβαση Morph και άλλα εφέ μετάβασης με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφάνειας ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides για Android μέσω Java, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να διαμορφώσετε την πρόοδο με κλικ ποντικιού ή χρονομετρητή, και να προσαρμόσετε επιλογές που είναι ειδικές για ένα εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα Java για την εφαρμογή μεταβάσεων, τον καθορισμό ακριβών χρονιών μετάβασης, τη διαχείριση του χρόνου προβολής της διαφάνειας και τη δημιουργία μιας μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης της διαφάνειας μέσω του [getSlideShowTransition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) με μια τιμή από την απαριθμική [TransitionType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitiontype/), κατόπιν αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Circle στην πρώτη διαφάνεια και μια μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**

Μπορείτε να διαμορφώσετε πόσο χρονικά παραμένει μια διαφάνεια στην οθόνη και αν ένα κλικ ποντικιού προχωρά την παρουσίαση. Οι ακόλουθες μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [setAdvanceOnClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) επιτρέπει στον θεατή να προχωρήσει με κλικ του ποντικιού.
- [setAdvanceAfter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) ενεργοποιεί αυτόματη πρόοδο.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) καθορίζει την καθυστέρηση πριν την αυτόματη πρόοδο, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε και το κλικ και την χρονομετρημένη πρόοδο ώστε ο θεατής να προχωρήσει είτε με κλικ είτε περιμένοντας το χρονομετρητή. Για χρήση μόνο του χρονομετρητή, περάστε `false` στο [setAdvanceOnClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Η καθυστέρηση ελέγχει πότε προχωρά η παρουσίαση· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα αντιστοιχίζει διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη πρόοδο μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προχωρήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

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

Για να ελέγξετε αν η χρονομετρημένη πρόοδο είναι ενεργοποιημένη, καλέστε το [getAdvanceAfter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Μια αποθηκευμένη καθυστέρηση από μόνη της δεν υποδηλώνει ότι ο χρονομετρητής είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το αρχείο που αποθηκεύτηκε παραπάνω, αναφέρει κάθε ενεργό χρονομετρητή και απενεργοποιεί την αυτόματη πρόοδο για διαφάνειες με καθυστέρηση μεγαλύτερη από δύο δευτερόλεπτα. Ενεργοποιεί τα κλικ ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

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

## **Ακριβής Έλεγχος Χρόνου Μετάβασης**

Χρησιμοποιήστε το [setDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) για να καθορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [getSlideShowTransition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [ISlideShowTransition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Ορίζει τη διάρκεια του εφέ της μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Ορίζει την καθυστέρηση πριν η διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Περνίστε `true` στο [setAdvanceAfter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) για να ενεργοποιήσετε αυτόν τον χρονομετρητή. |
| [setSpeed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Επιλέγει μια προεπιλεγμένη κατηγορία ταχύτητας από την [TransitionSpeed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν καθορίζεται ακριβής διάρκεια. |

Το [setDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) ελέγχει μόνο το εφέ της μετάβασης· δεν καθορίζει πόσο χρονικά παραμένει η διαφάνεια ορατή. Ρυθμίστε την αυτόματη καθυστέρηση προόδου ξεχωριστά. Όταν δεν έχει οριστεί ρητή διάρκεια, το Aspose.Slides υπολογίζει τη διάρκεια του εφέ από τον τύπο μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Εφαρμογή της Ιδιαίας Διάρκειας σε Όλες τις Διαφάνειες**

Για ομοιόμορφη ρυθμιση, εφαρμόστε το ίδιο εφέ και ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από την [TransitionType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitiontype/) και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστά του δευτερολέπτου. Επίσης ενεργοποιεί αυτόματη πρόοδο μετά από 5 000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την πρόοδο με κλικ ποντικιού, κατόπιν αποθηκεύει το αποτέλεσμα ως PPTX.

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

### **Ορισμός Διαφορετικών Διάρκειων για Μεμονωμένες Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να χρησιμοποιούν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για τη διαφάνεια τίτλου και μια πιο μακρά μετάβαση για την εισαγωγή ενότητας. Αυτό το παράδειγμα ορίζει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1 200 χιλιοστά του δευτερολέπτου για τη δεύτερη. Χρησιμοποιείστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

### **Συντονισμός Μεταβάσεων με Αναφερόμενο Περιεχόμενο**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/androidjava/convert-powerpoint-to-animated-gif/), μιας [HTML5 παρουσίασης](/slides/el/androidjava/export-to-html5/) ή ενός [βίντεο](/slides/el/androidjava/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μετάβασης πριν από την εξαγωγή ώστε να ταιριάζουν με το επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε μια fade διάρκειας 600 χιλιοστών του δευτερολέπτου μεταξύ σκηνών και προσαρμόστε χωριστά την καθυστέρηση προόδου κάθε διαφάνειας για να επιτρέψετε χρόνο για την αφήγηση ή το περιεχόμενο της.

Για GIF και βίντεο, συντονίστε τον ρυθμό πλαισίων εξόδου με τη διάρκεια του εφέ: 600 χιλιοστά του δευτερολέπτου αντιστοιχούν σε 18 καρέ στα 30 καρέ ανά δευτερόλεπτο. Στο HTML5, ενεργοποιήστε τις κινουμένων μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες επιδράσεις και επιλογές χρονομέτρησης της επιλεγμένης μορφής εξαγωγής και προεξέχτε το αποτέλεσμα για να επιβεβαιώσετε το συγχρονισμό.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Καλέστε το [getDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) πριν τροποποιήσετε τη μετάβαση για να διαπιστώσετε αν υπάρχει αποθηκευμένη ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη‑αρνητική τιμή υποδεικνύει τη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη‑ορισμένη τιμή δεν είναι η υπολογιζόμενη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) για να την προσδιορίσει. Η ρύθμιση τύπου μετάβασης μπορεί να αρχικοποιήσει διάρκεια, γι’ αυτό εξετάστε πρώτα τις αρχικές ρυθμίσεις.

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

Η μετάβαση Morph κινεί αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο κλώνο, και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό δίνει στα αντίστοιχα αντικείμενα της μετάβασης την δυνατότητα να κινούνται μεταξύ της αρχικής και της τροποποιημένης κατάστασής τους.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ένα ορθογώνιο κειμένου, κλωνοποιεί τη διαφάνεια, και αλλάζει τη θέση και το μέγεθος του ορθογωνίου στο κλώνο. Στη συνέχεια επιλέγει Morph από την απαριθμητική [TransitionType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε έναν προβολέα παρουσίασης που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια της παρουσίασης.

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

Η απαριθμητική [TransitionMorphType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionmorphtype/) ελέγχει πώς το Morph ταιριάζει και κινεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) κινεί το κείμενο ταιριάζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) κινεί το κείμενο ταιριάζοντας χαρακτήρες όπου είναι δυνατόν.

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) για να επιλέξετε Morph προτού αποκτήσετε το [getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Η τιμή παρέχει στη συνέχεια τη διεπαφή [IMorphTransition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imorphtransition/), της οποίας η μέθοδος [setMorphType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) επιλέγει τη λειτουργία ταιριάσματος.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και διαμορφώνει τη δεύτερη διαφάνεια ώστε να χρησιμοποιεί κίνηση Morph βάσει λέξεων.

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

Ορισμένες μεταβάσεις εκθέτουν επιπλέον επιλογές, όπως κατεύθυνση ή αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τη μετάβαση που επιλέχθηκε με το [setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Ορίστε πρώτα τον τύπο, στη συνέχεια χρησιμοποιήστε τη σχετική διεπαφή από το [getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλεί το [setFromBlack](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) μέσω του [IOptionalBlackTransition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioptionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

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

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [setDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [setSpeed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) όταν μια προκαθορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionspeed/) — Slow, Medium ή Fast — αρκεί και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ της μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προόδου.

**Μπορώ να προσθέσω ήχο σε μια μετάβαση και να τον κάνω να επαναλαμβάνεται;**

Ναι. Αντιστοιχίστε ενσωματωμένο ήχο με το [setSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), περάστε το `StartSound` από την απαριθμητική [TransitionSoundMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionsoundmode/) στο [setSoundMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), και ενεργοποιήστε το [setSoundLoop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) με `true`. Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσω την ίδια μετάβαση σε κάθε διαφάνεια;**

Μεσώβετε τη συλλογή [getSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlides--) του αντικειμένου παρουσίασης και καλέστε το [setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν χρονοδιαγράμματα και επιλογές εφέ στον ίδιο βρόχο ώστε η συμπεριφορά να παραμένει συνεπής μεταξύ των διαφανειών.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτήν τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλέστε το [getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideshowtransition/#getType--) στο αποτέλεσμα του [getSlideShowTransition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) της διαφάνειας. Επιστρέφει μια τιμή από την απαριθμητική [TransitionType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitiontype/); η τιμή None σημαίνει ότι δεν έχει εφαρμοστεί κανένα εφέ μετάβασης.