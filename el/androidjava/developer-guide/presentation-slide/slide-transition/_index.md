---
title: Διαχείριση Μεταβάσεων Διαφανειών σε Παρουσιάσεις σε Android
linktitle: Μετάβαση Διαφάνειας
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
description: "Ανακαλύψτε πώς να προσαρμόσετε τις μεταβάσεις διαφανειών στο Aspose.Slides για Android μέσω Java, με οδηγίες βήμα-βήμα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τις μεταβάσεις διαφανειών σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να εφαρμόσετε τύπους μεταβάσεων στις διαφάνειες, να ρυθμίσετε τη συμπεριφορά της μετάβασης όπως η προώθηση με κλικ ή μετά από ορισμένο χρονικό διάστημα, να χρησιμοποιήσετε τη μετάβαση Morph και τους τύπους της, και να ορίσετε επιλογές εφέ μετάβασης. Τα παραδείγματα επιδεικνύουν πώς να φορτώσετε ή να δημιουργήσετε μια παρουσίαση, να τροποποιήσετε τις ρυθμίσεις μετάβασης για επιλεγμένες διαφάνειες και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Το άρθρο επίσης απαντά συνήθεις ερωτήσεις σχετικά με την ταχύτητα μετάβασης, τους ήχους μετάβασης, την εφαρμογή της ίδιας μετάβασης σε πολλές διαφάνειες, και τον έλεγχο της μετάβασης που είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να δημιουργήσετε ένα απλό εφέ μετάβασης διαφάνειας, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) .
2. Εφαρμόστε έναν τύπο μετάβασης διαφάνειας στη διαφάνεια από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides για Android μέσω Java μέσω του enum TransitionType.
3. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου της κλάσης Presentation για φόρτωση του αρχικού αρχείου παρουσίασης
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Εφαρμογή μετάβασης τύπου comb στη διαφάνεια 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Αποθήκευση της παρουσίασης στο δίσκο
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**

Στην παραπάνω ενότητα, εφαρμόσαμε μόνο ένα απλό εφέ μετάβασης στη διαφάνεια. Τώρα, για να κάνετε αυτό το απλό εφέ μετάβασης ακόμα καλύτερο και ελεγχόμενο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) .
2. Εφαρμόστε έναν τύπο μετάβασης διαφάνειας στη διαφάνεια από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides για Android μέσω Java.
3. Μπορείτε επίσης να ορίσετε τη μετάβαση ώστε να προχωρά με κλικ, μετά από συγκεκριμένο χρονικό διάστημα ή και τα δύο.
4. Εάν η μετάβαση διαφάνειας είναι ενεργοποιημένη για προώθηση με κλικ, η μετάβαση θα προχωρά μόνο όταν κάποιος κάνει κλικ με το ποντίκι. Επιπλέον, αν ορίζεται η ιδιότητα Advance After Time, η μετάβαση θα προχωρά αυτόματα μετά το καθορισμένο χρονικό διάστημα.
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο παρουσίασης.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Προώθηση με κλικ ή αυτόματα μετά από 3 δευτερόλεπτα
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Εφαρμογή μετάβασης τύπου comb στη διαφάνεια 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Προώθηση με κλικ ή αυτόματα μετά από 5 δευτερόλεπτα
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Εφαρμογή μετάβασης τύπου ζουμ στη διαφάνεια 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Προώθηση με κλικ ή αυτόματα μετά από 7 δευτερόλεπτα
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Μετάβαση Morph**

{{% alert color="info" %}} 
Το Aspose.Slides for Android μέσω Java υποστηρίζει τώρα το [Morph Transition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMorphTransition). Αντιπροσωπεύει τη νέα μετάβαση morph που εισήχθη στο PowerPoint 2019.
{{% /alert %}} 

Η μετάβαση Morph σας επιτρέπει να δημιουργήσετε ομαλή κίνηση από τη μία διαφάνεια στην επόμενη. Αυτό το άρθρο περιγράφει την έννοια και πώς να χρησιμοποιήσετε τη μετάβαση Morph. Για να χρησιμοποιήσετε αποτελεσματικά τη μετάβαση Morph, χρειάζεστε δύο διαφάνειες που έχουν τουλάχιστον ένα κοινό αντικείμενο. Ο πιο εύκολος τρόπος είναι να αντιγράψετε τη διαφάνεια και στη συνέχεια να μετακινήσετε το αντικείμενο στη δεύτερη διαφάνεια σε διαφορετική θέση.

Το παρακάτω απόσπασμα κώδικα σας δείχνει πώς να προσθέσετε ένα κλώνο της διαφάνειας με κάποιο κείμενο στην παρουσίαση και να ορίσετε μια μετάβαση [morph type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TransitionType) στη δεύτερη διαφάνεια.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Τύποι Μετάβασης Morph**

Προστέθηκε νέο enum [TransitionMorphType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TransitionMorphType). Αντιπροσωπεύει διαφορετικούς τύπους μετάβασης διαφάνειας Morph.

Το enum TransitionMorphType έχει τρία μέλη:

- ByObject: Η μετάβαση Morph θα εκτελείται λαμβάνοντας υπόψη τα σχήματα ως αδιαίρετα αντικείμενα.
- ByWord: Η μετάβαση Morph θα εκτελείται με τη μεταφορά του κειμένου λέξη- λέξη όπου είναι δυνατόν.
- ByChar: Η μετάβαση Morph θα εκτελείται με τη μεταφορά του κειμένου χαρακτήρας-χαρακτήρα όπου είναι δυνατόν.

Το παρακάτω απόσπασμα κώδικα σας δείχνει πώς να ορίσετε τη μετάβαση morph στη διαφάνεια και να αλλάξετε τον τύπο morph:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορίστε Εφέ Μετάβασης**

Το Aspose.Slides for Android μέσω Java υποστηρίζει τον ορισμό των εφέ μετάβασης όπως από μαύρο, από αριστερά, από δεξιά κλπ. Για να ορίσετε το εφέ μετάβασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
- Αποκτήστε την αναφορά της διαφάνειας.
- Ορισμός του εφέ μετάβασης.
- Γράψτε την παρουσίαση ως αρχείο [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τα εφέ μετάβασης.

```java
import com.aspose.slides.*;

// Δημιουργία μιας παρουσίας της κλάσης Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Ορισμός εφέ
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Αποθήκευση της παρουσίασης στον δίσκο
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;

Ναι. Ορίστε την [speed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) της μετάβασης χρησιμοποιώντας τη ρύθμιση [TransitionSpeed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionspeed/) (π.χ., αργή/μεσαία/γρήγορη).

### Μπορώ να συνδέσω ήχο με μια μετάβαση και να τον επαναλάβω;

Ναι. Μπορείτε να ενσωματώσετε ήχο για τη μετάβαση και να ελέγξετε τη συμπεριφορά μέσω ρυθμίσεων όπως η λειτουργία ήχου και η επανάληψη (π.χ., [setSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), καθώς και μεταδεδομένα όπως [setSoundIsBuiltIn](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) και [setSoundName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Ποιος είναι ο πιο γρήγορος τρόπος να εφαρμόσετε την ίδια μετάβαση σε κάθε διαφάνεια;

Ρυθμίστε τον επιθυμητό τύπο μετάβασης στις ρυθμίσεις μετάβασης κάθε διαφάνειας· οι μεταβάσεις αποθηκεύονται ανά διαφάνεια, έτσι η εφαρμογή του ίδιου τύπου σε όλες τις διαφάνειες δίνει ένα συνεπές αποτέλεσμα.

### Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;

Εξετάστε τις [transition settings](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) της διαφάνειας και διαβάστε το [transition type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); αυτή η τιμή σας λέει ακριβώς ποιο εφέ έχει εφαρμοστεί.