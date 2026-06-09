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
- μετάβαση morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσαρμόστε τις μεταβάσεις διαφανειών σε JavaScript με το Aspose.Slides για Node.js μέσω Java, με καθοδήγηση βήμα προς βήμα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τις μεταβάσεις διαφανειών σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να εφαρμόσετε τύπους μεταβάσεων σε διαφάνειες, να ρυθμίσετε τη συμπεριφορά της μετάβασης όπως η προώθηση με κλικ ή μετά από καθορισμένο χρόνο, να ελέγξετε και να απενεργοποιήσετε την αυτόματη προώθηση, να χρησιμοποιήσετε τη μετάβαση Morph και τους τύπους της, και να ορίσετε επιλογές εφέ μετάβασης. Τα παραδείγματα δείχνουν πώς να φορτώσετε ή να δημιουργήσετε μια παρουσίαση, να τροποποιήσετε τις ρυθμίσεις μετάβασης για επιλεγμένες διαφάνειες, και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Το άρθρο επίσης απαντά σε κοινές ερωτήσεις σχετικά με την ταχύτητα της μετάβασης, τους ήχους μετάβασης, την εφαρμογή της ίδιας μετάβασης σε πολλές διαφάνειες, και τον έλεγχο της τρέχουσας μετάβασης σε μια διαφάνεια.

## **Προσθήκη Μετάβασης Διαφάνειας**
Για να δημιουργήσετε ένα απλό εφέ μετάβασης διαφάνειας, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
2. Εφαρμόστε έναν τύπο Slide Transition Type στη διαφάνεια από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides για Node.js μέσω Java, χρησιμοποιώντας την enum TransitionType.
3. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

```javascript
// Δημιουργία αντικειμένου της κλάσης Presentation για τη φόρτωση του αρχικού αρχείου παρουσίασης
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Εφαρμογή μετάβασης τύπου comb στη διαφάνεια 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Αποθήκευση της παρουσίασης στο δίσκο
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**
Στο παραπάνω τμήμα, εφαρμόσαμε μόνο ένα απλό εφέ μετάβασης στη διαφάνεια. Τώρα, για να βελτιώσετε αυτό το απλό εφέ και να το ελέγχετε καλύτερα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
2. Εφαρμόστε έναν τύπο Slide Transition Type στη διαφάνεια από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides για Node.js μέσω Java.
3. Μπορείτε επίσης να ορίσετε τη μετάβαση σε Advance On Click, μετά από συγκεκριμένο χρονικό διάστημα ή και τα δύο.
4. Εάν η μετάβαση της διαφάνειας είναι ενεργοποιημένη για Advance On Click, η μετάβαση θα προχωρά μόνο όταν κάποιος κάνει κλικ με το ποντίκι. Επιπλέον, εάν έχει οριστεί η ιδιότητα Advance After Time, η μετάβαση θα προχωρήσει αυτόματα μετά το καθορισμένο χρόνο προώθησης.
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο παρουσίασης.

```javascript
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Ορισμός χρόνου μετάβασης στα 3 δευτερόλεπτα
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Εφαρμογή μετάβασης τύπου comb στη διαφάνεια 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Ορισμός χρόνου μετάβασης στα 5 δευτερόλεπτα
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Εφαρμογή μετάβασης τύπου ζουμ στη διαφάνεια 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Ορισμός χρόνου μετάβασης στα 7 δευτερόλεπτα
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Μετάβαση Morph**
{{% alert color="primary" %}} 

Το Aspose.Slides for Node.js via Java υποστηρίζει πλέον τη [Morph Transition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MorphTransition). Αντιπροσωπεύουν τη νέα μετάβαση morph που εισήχθη στο PowerPoint 2019.

{{% /alert %}} 

Η μετάβαση Morph σας επιτρέπει να δημιουργήσετε ομαλή κίνηση από τη μία διαφάνεια στην άλλη. Αυτό το άρθρο περιγράφει τη概念 και πώς να χρησιμοποιήσετε τη μετάβαση Morph. Για να χρησιμοποιήσετε αποτελεσματικά τη μετάβαση Morph, θα χρειαστεί να έχετε δύο διαφάνειες με τουλάχιστον ένα κοινό αντικείμενο. Ο πιο εύκολος τρόπος είναι να αντιγράψετε τη διαφάνεια και στη συνέχεια να μετακινήσετε το αντικείμενο στη δεύτερη διαφάνεια σε διαφορετική θέση.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να προσθέσετε ένα αντίγραφο της διαφάνειας με κάποιο κείμενο στην παρουσίαση και να ορίσετε μια μετάβαση [morph type](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TransitionType) στη δεύτερη διαφάνεια.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Τύποι Μετάβασης Morph**
Προστέθηκε νέο enumeration [TransitionMorphType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TransitionMorphType). Αντιπροσωπεύει διαφορετικούς τύπους μετάβασης διαφάνειας Morph.

Το enumeration TransitionMorphType έχει τρία μέλη:

- ByObject: Η μετάβαση Morph θα εκτελείται λαμβάνοντας υπόψη τα σχήματα ως αδιαίρετα αντικείμενα.
- ByWord: Η μετάβαση Morph θα εκτελείται με μεταφορά κειμένου λέξη προς λέξη όπου είναι δυνατόν.
- ByChar: Η μετάβαση Morph θα εκτελείται με μεταφορά κειμένου χαρακτήρα προς χαρακτήρα όπου είναι δυνατόν.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ορίσετε τη μετάβαση morph σε διαφάνεια και να αλλάξετε τον τύπο morph:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Εφέ Μετάβασης**
Το Aspose.Slides for Node.js via Java υποστηρίζει τον ορισμό εφέ μετάβασης όπως από το μαύρο, από αριστερά, από δεξιά κ.λπ. Για να ορίσετε το Εφέ Μετάβασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Λάβετε την αναφορά της διαφάνειας.
- Ορίστε το εφέ μετάβασης.
- Γράψτε την παρουσίαση ως αρχείο [PPTX ](https://docs.fileformat.com/presentation/pptx/).

Στο παρακάτω παράδειγμα, έχουμε ορίσει τα εφέ μετάβασης.

```javascript
// Δημιουργία ενός αντικειμένου της κλάσης Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Ορισμός εφέ
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Αποθήκευση της παρουσίασης στο δίσκο
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Ορίστε την [speed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/setspeed/) της μετάβασης χρησιμοποιώντας τη ρύθμιση [TransitionSpeed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/transitionspeed/) (π.χ., slow/medium/fast).

**Μπορώ να προσθέσω ήχο σε μια μετάβαση και να τον επαναλάβω;**

Ναι. Μπορείτε να ενσωματώσετε ήχο για τη μετάβαση και να ελέγξετε τη συμπεριφορά μέσω ρυθμίσεων όπως η λειτουργία ήχου και η επανάληψη (π.χ., [setSound](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), καθώς και μεταδεδομένα όπως [setSoundIsBuiltIn](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) και [setSoundName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσετε την ίδια μετάβαση σε κάθε διαφάνεια;**

Ρυθμίστε τον επιθυμητό τύπο μετάβασης στις ρυθμίσεις μετάβασης κάθε διαφάνειας· οι μεταβάσεις αποθηκεύονται ανά διαφάνεια, έτσι η εφαρμογή του ίδιου τύπου σε όλες τις διαφάνειες παρέχει συνεπές αποτέλεσμα.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Εξετάστε τις [transition settings](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας και διαβάστε το [transition type](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowtransition/gettype/); αυτή η τιμή σας δείχνει ακριβώς ποιο εφέ έχει εφαρμοσθεί.