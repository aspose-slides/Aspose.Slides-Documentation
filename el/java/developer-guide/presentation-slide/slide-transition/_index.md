---
title: Διαχείριση Μεταβάσεων Διαφανειών σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 80
url: /el/java/slide-transition/
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
- presentation
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόσετε τις μεταβάσεις διαφανειών στο Aspose.Slides για Java, με οδηγίες βήμα-βήμα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τις μεταβάσεις διαφανειών σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να εφαρμόζετε τύπους μεταβάσεων σε διαφάνειες, να διαμορφώνετε τη συμπεριφορά της μετάβασης όπως η προώθηση με κλικ ή μετά από συγκεκριμένο χρόνο, να ελέγχετε και να απενεργοποιείτε την αυτόματη προώθηση, να χρησιμοποιείτε τη μεταβίβαση Morph και τους τύπους της, καθώς και να ορίζετε επιλογές εφέ μετάβασης. Τα παραδείγματα δείχνουν πώς να φορτώσετε ή να δημιουργήσετε μια παρουσίαση, να τροποποιήσετε τις ρυθμίσεις μετάβασης για επιλεγμένες διαφάνειες και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Το άρθρο επίσης απαντά σε συνήθεις ερωτήσεις σχετικά με την ταχύτητα μετάβασης, τους ήχους μετάβασης, την εφαρμογή της ίδιας μετάβασης σε πολλαπλές διαφάνειες και τον έλεγχο της τρέχουσας μετάβασης σε μια διαφάνεια.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να δημιουργήσετε ένα απλό εφέ μετάβασης διαφάνειας, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
2. Εφαρμόστε έναν τύπο Μετάβασης Διαφάνειας στη διαφάνεια από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides for Java μέσω του TransitionType enum.
3. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

```java
// Δημιουργία παραδείγματος της κλάσης Presentation για τη φόρτωση του αρχείου πηγαίας παρουσίασης
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

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
2. Εφαρμόστε έναν τύπο Μετάβασης Διαφάνειας στη διαφάνεια από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides for Java.
3. Μπορείτε επίσης να ορίσετε τη μετάβαση να προχωράει με κλικ, μετά από συγκεκριμένο χρονικό διάστημα ή και τα δύο.
4. Εάν η μετάβαση διαφάνειας είναι ενεργοποιημένη για προώθηση με κλικ, η μετάβαση θα προχωρά μόνο όταν κάποιος κάνει κλικ με το ποντίκι. Επιπλέον, εάν έχει οριστεί η ιδιότητα Advance After Time, η μετάβαση θα προχωρά αυτόματα μετά το καθορισμένο χρόνο προώθησης.
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο παρουσίασης.

```java
// Δημιουργία παραδείγματος της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Ορισμός χρόνου μετάβασης 3 δευτερολέπτων
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Εφαρμογή μετάβασης τύπου comb στη διαφάνεια 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Ορισμός χρόνου μετάβασης 5 δευτερολέπτων
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Εφαρμογή μετάβασης τύπου zoom στη διαφάνεια 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Ορισμός χρόνου μετάβασης 7 δευτερολέπτων
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Μετάβαση Morph**

{{% alert color="primary" %}} 
Το Aspose.Slides for Java υποστηρίζει πλέον τη [Morph Transition](https://reference.aspose.com/slides/el/java/com.aspose.slides/IMorphTransition). Είναι η νέα μετάβαση morph που εισήχθη στο PowerPoint 2019.
{{% /alert %}} 

Η μετάβαση Morph σας επιτρέπει να δημιουργήσετε ομαλή κίνηση μεταξύ διαφανειών. Αυτό το άρθρο περιγράφει τη έννοια και πώς να χρησιμοποιήσετε τη μετάβαση Morph. Για να χρησιμοποιήσετε αποτελεσματικά τη μετάβαση Morph, χρειάζεστε δύο διαφάνειες που έχουν τουλάχιστον ένα κοινό αντικείμενο. Ο πιο εύκολος τρόπος είναι να αντιγράψετε τη διαφάνεια και στη συνέχεια να μετακινήσετε το αντικείμενο στη δεύτερη διαφάνεια σε διαφορετική θέση.

Το παρακάτω απόσπασμα κώδικα σας δείχνει πώς να προσθέσετε ένα κλώνο της διαφάνειας με κάποιο κείμενο στην παρουσίαση και να ορίσετε μια μετάβαση [morph type](https://reference.aspose.com/slides/el/java/com.aspose.slides/TransitionType) στη δεύτερη διαφάνεια.

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

## **Τύποι Μετάβασης Morph**

Έχει προστέθει νέο enum [TransitionMorphType](https://reference.aspose.com/slides/el/java/com.aspose.slides/TransitionMorphType). Αντιπροσωπεύει διαφορετικούς τύπους μετάβασης Morph για διαφάνειες.

Το enum TransitionMorphType έχει τρία μέλη:

- ByObject: Η μετάβαση Morph θα εκτελεστεί θεωρώντας τα σχήματα ως αδιαίρετα αντικείμενα.
- ByWord: Η μετάβαση Morph θα εκτελεστεί μεταφέροντας το κείμενο ανά λέξη, όπου είναι δυνατόν.
- ByChar: Η μετάβαση Morph θα εκτελεστεί μεταφέροντας το κείμενο ανά χαρακτήρα, όπου είναι δυνατόν.

Το παρακάτω απόσπασμα κώδικα σας δείχνει πώς να ορίσετε τη μετάβαση morph σε μια διαφάνεια και να αλλάξετε τον τύπο morph:

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

## **Ορισμός Εφέ Μετάβασης**

Το Aspose.Slides for Java υποστηρίζει τον ορισμό εφέ μετάβασης όπως από μαύρο, από αριστερά, από δεξιά κλπ. Για να ορίσετε το Εφέ Μετάβασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
- Αποκτήστε την αναφορά της διαφάνειας.
- Ορίστε το εφέ μετάβασης.
- Γράψτε την παρουσίαση ως αρχείο [PPTX ](https://docs.fileformat.com/presentation/pptx/).

Στο παρακάτω παράδειγμα, έχουμε ορίσει τα εφέ μετάβασης.

```java
// Δημιουργία παραδείγματος της κλάσης Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Ορισμός εφέ
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Αποθήκευση της παρουσίασης στο δίσκο
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Ορίστε την [ταχύτητα](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) της μετάβασης χρησιμοποιώντας τη ρύθμιση [TransitionSpeed](https://reference.aspose.com/slides/el/java/com.aspose.slides/transitionspeed/) (π.χ. αργά/μεσαία/γρήγορη).

**Μπορώ να συνημψώ ήχο σε μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Μπορείτε να ενσωματώσετε ήχο για τη μετάβαση και να ελέγξετε τη συμπεριφορά μέσω ρυθμίσεων όπως η λειτουργία ήχου και η επανάληψη (π.χ. [setSound](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), επιπλέον μεταδεδομένα όπως [setSoundIsBuiltIn](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) και [setSoundName](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Ποιος είναι ο πιο γρήγορος τρόπος να εφαρμόσετε την ίδια μετάβαση σε κάθε διαφάνεια;**

Διαμορφώστε τον επιθυμητό τύπο μετάβασης στις ρυθμίσεις μετάβασης κάθε διαφάνειας· οι μεταβάσεις αποθηκεύονται ανά διαφάνεια, έτσι η εφαρμογή του ίδιου τύπου σε όλες τις διαφάνειες δίνει ένα συνεπές αποτέλεσμα.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτήν τη στιγμή ορισμένη σε μια διαφάνεια;**

Εξετάστε τις [ρυθμίσεις μετάβασης] της διαφάνειας και διαβάστε τον [τύπο μετάβασης] της· αυτή η τιμή σας λέει ακριβώς ποιο εφέ έχει εφαρμοστεί.