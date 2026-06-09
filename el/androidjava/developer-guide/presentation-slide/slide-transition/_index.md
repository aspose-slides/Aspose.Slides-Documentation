---
title: Διαχείριση μεταβάσεων διαφάνειας στις παρουσιάσεις στο Android
linktitle: Μετάβαση διαφάνειας
type: docs
weight: 80
url: /el/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόζετε τις μεταβάσεις διαφάνειας στο Aspose.Slides για Android μέσω Java, με καθοδήγηση βήμα προς βήμα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τις μεταβάσεις διαφάνειας στις παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να εφαρμόζετε τύπους μετάβασης σε διαφάνειες, να παραμετροποιείτε τη συμπεριφορά της μετάβασης όπως η προώθηση με κλικ ή μετά από καθορισμένο χρόνο, να ελέγχετε και να απενεργοποιείτε την αυτόματη προώθηση, να χρησιμοποιείτε τη μετάβαση Morph και τους τύπους της, καθώς και να ορίζετε επιλογές εφέ μετάβασης. Τα παραδείγματα επιδεικνύουν πώς να φορτώσετε ή να δημιουργήσετε μια παρουσίαση, να τροποποιήσετε τις ρυθμίσεις μετάβασης για επιλεγμένες διαφάνειες και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Το άρθρο απαντά επίσης σε κοινές ερωτήσεις σχετικά με την ταχύτητα μετάβασης, τους ήχους μετάβασης, την εφαρμογή της ίδιας μετάβασης σε πολλαπλές διαφάνειες και τον έλεγχο της τρέχουσας μετάβασης σε μια διαφάνεια.

## **Προσθήκη μετάβασης διαφάνειας**
Για να δημιουργήσετε ένα απλό εφέ μετάβασης διαφάνειας, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
2. Εφαρμόστε έναν τύπο ΣΔΙ (Slide Transition Type) στη διαφάνεια από μία από τις μεταβάσεις που προσφέρει το Aspose.Slides for Android via Java μέσω του enum TransitionType.
3. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

```java
// Δημιουργία αντικειμένου κλάσης Presentation για φόρτωση του αρχικού αρχείου παρουσίασης
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Εφαρμογή μετάβασης τύπου χτένας στη διαφάνεια 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Αποθήκευση της παρουσίασης στο δίσκο
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη προχωρημένης μετάβασης διαφάνειας**
Στην προηγούμενη ενότητα εφαρμόσαμε μια απλή μετάβαση στη διαφάνεια. Τώρα, για να κάνετε αυτήν τη μετάβαση πιο εκλεπτυσμένη και ελεγχόμενη, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
2. Εφαρμόστε έναν τύπο ΣΔΙ στη διαφάνεια από μία από τις μεταβάσεις που προσφέρει το Aspose.Slides for Android via Java.
3. Μπορείτε επίσης να ορίσετε τη μετάβαση ώστε να προχωράει με Κλικ, μετά από συγκεκριμένο χρόνο ή και τα δύο.
4. Εάν η μετάβαση διαφάνειας είναι ενεργοποιημένη για Προώθηση με Κλικ, η μετάβαση θα προχωρήσει μόνο όταν κάποιος κάνει κλικ. Επιπλέον, εάν ορίζεται η ιδιότητα Advance After Time, η μετάβαση θα προχωρήσει αυτόματα μετά το καθορισμένο χρόνο.
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο παρουσίασης.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Ορισμός χρόνου μετάβασης στα 3 δευτερόλεπτα
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Εφαρμογή μετάβασης τύπου χτένας στη διαφάνεια 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Ορισμός χρόνου μετάβασης στα 5 δευτερόλεπτα
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Εφαρμογή μετάβασης τύπου ζουμ στη διαφάνεια 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Ορισμός χρόνου μετάβασης στα 7 δευτερόλεπτα
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Αποθήκευση της παρουσίασης σε δίσκο
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Μετάβαση Morph**
{{% alert color="primary" %}} 

Το Aspose.Slides for Android via Java υποστηρίζει τώρα τη [Morph Transition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMorphTransition). Παρουσιάζει τη νέα μετάβαση morph που εισήχθη στο PowerPoint 2019.

{{% /alert %}} 

Η μετάβαση Morph σας επιτρέπει να δημιουργήσετε ομαλή κίνηση από τη μία διαφάνεια στην άλλη. Αυτό το άρθρο περιγράφει την έννοια και τον τρόπο χρήσης της μετάβασης Morph. Για να τη χρησιμοποιήσετε αποτελεσματικά, χρειάζονται δύο διαφάνειες με τουλάχιστον ένα κοινό αντικείμενο. Ο πιο εύκολος τρόπος είναι να διπλασιάσετε τη διαφάνεια και στη συνέχεια να μετακινήσετε το αντικείμενο στη δεύτερη διαφάνεια σε διαφορετική θέση.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα αντίγραφο της διαφάνειας με κάποιο κείμενο στην παρουσίαση και να ορίσετε μια μετάβαση [morph type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TransitionType) στη δεύτερη διαφάνεια.

```java
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

## **Τύποι μετάβασης Morph**
Έχει προστεθεί νέο enum [TransitionMorphType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TransitionMorphType). Αντιπροσωπεύει διαφορετικούς τύπους μετάβασης Morph.

Το enum TransitionMorphType έχει τρία μέλη:

- ByObject: Η μετάβαση Morph θα εκτελεστεί θεωρώντας τα σχήματα ως αδιάσπαστα αντικείμενα.
- ByWord: Η μετάβαση Morph θα εκτελεστεί μεταφέροντας το κείμενο λέξη-λέξη όπου είναι δυνατόν.
- ByChar: Η μετάβαση Morph θα εκτελεστεί μεταφέροντας το κείμενο χαρακτήρα-χαρακτήρα όπου είναι δυνατόν.

Ο παρακάτω κώδικας δείχνει πώς να ορίσετε τη μετάβαση Morph σε μια διαφάνεια και να αλλάξετε τον τύπο morph:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός εφέ μετάβασης**
Το Aspose.Slides for Android via Java υποστηρίζει τον ορισμό εφέ μετάβασης, όπως από το μαύρο, από αριστερά, από δεξιά κλπ. Για να ορίσετε το εφέ μετάβασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
- Λάβετε την αναφορά της διαφάνειας.
- Ορίστε το εφέ μετάβασης.
- Γράψτε την παρουσίαση ως [PPTX](https://docs.fileformat.com/presentation/pptx/) αρχείο.

Στο παρακάτω παράδειγμα έχουμε ορίσει τα εφέ μετάβασης.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Ορισμός εφέ
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Αποθήκευση της παρουσίασης σε δίσκο
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Ορίστε την [speed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) της μετάβασης χρησιμοποιώντας τη ρύθμιση [TransitionSpeed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/transitionspeed/) (π.χ., αργή/μεσαία/γρήγορη).

**Μπορώ να συνημψώ ήχο σε μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Μπορείτε να ενσωματώσετε ήχο για τη μετάβαση και να ελέγξετε τη συμπεριφορά μέσω ρυθμίσεων όπως mode ήχου και βρόχος (π.χ., [setSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), καθώς και μεταδεδομένα όπως [setSoundIsBuiltIn](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) και [setSoundName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσω την ίδια μετάβαση σε κάθε διαφάνεια;**

Ορίστε τον επιθυμητό τύπο μετάβασης στις ρυθμίσεις μετάβασης κάθε διαφάνειας· οι μεταβάσεις αποθηκεύονται ανά διαφάνεια, οπότε η εφαρμογή του ίδιου τύπου σε όλες τις διαφάνειες δίνει ένα συνεπές αποτέλεσμα.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι επί του παρόντος ορισμένη σε μια διαφάνεια;**

Εξετάστε τις [ρυθμίσεις μετάβασης](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) της διαφάνειας και διαβάστε τον [τύπο μετάβασης](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); αυτή η τιμή δείχνει ακριβώς ποιο εφέ έχει εφαρμοστεί.