---
title: Διαχείριση μεταβάσεων διαφανειών σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Μετάβαση διαφάνειας
type: docs
weight: 80
url: /el/php-java/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προχωρημένη μετάβαση διαφάνειας
- μετάβαση Morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόζετε τις μεταβάσεις διαφανειών στο Aspose.Slides για PHP μέσω Java, με βήμα-βήμα οδηγίες για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τις μεταβάσεις διαφανειών σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να εφαρμόζετε τύπους μετάβασης σε διαφάνειες, να διαμορφώνετε τη συμπεριφορά της μετάβασης όπως η προώθηση με κλικ ή μετά από καθορισμένο χρόνο, να ελέγχετε και να απενεργοποιείτε αυτόματη προώθηση, να χρησιμοποιείτε τη μετάβαση Morph και τους τύπους της, καθώς και να ορίζετε επιλογές εφέ μετάβασης. Τα παραδείγματα δείχνουν πώς να φορτώσετε ή να δημιουργήσετε μια παρουσίαση, να τροποποιήσετε τις ρυθμίσεις μετάβασης για επιλεγμένες διαφάνειες και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Το άρθρο επίσης απαντά σε κοινές ερωτήσεις σχετικά με την ταχύτητα μετάβασης, τους ήχους μετάβασης, την εφαρμογή της ίδιας μετάβασης σε πολλές διαφάνειες και τον έλεγχο της τρέχουσας μετάβασης σε μια διαφάνεια.

## **Προσθήκη Μετάβασης Διαφάνειας**
Για να δημιουργήσετε ένα απλό εφέ μετάβασης διαφάνειας, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Εφαρμόστε έναν τύπο μετάβασης διαφάνειας στη διαφάνεια από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides for PHP via Java μέσω του enum TransitionType.
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

```php
  # Δημιουργία αντικειμένου της κλάσης Presentation για τη φόρτωση του αρχικού αρχείου παρουσίασης
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Εφαρμογή μετάβασης τύπου χτένι στη διαφάνεια 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Αποθήκευση της παρουσίασης στο δίσκο
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Προσθήκη Προχωρημένης Μετάβασης Διαφάνειας**
Στην παραπάνω ενότητα, εφαρμόσαμε μόνο ένα απλό εφέ μετάβασης στη διαφάνεια. Τώρα, για να βελτιώσετε αυτό το απλό εφέ και να το ελέγξετε καλύτερα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Εφαρμόστε έναν τύπο μετάβασης διαφάνειας στη διαφάνεια από ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides for PHP via Java.
1. Μπορείτε επίσης να ορίσετε τη μετάβαση ώστε να προχωρά με κλικ, μετά από συγκεκριμένο χρονικό διάστημα ή και τα δύο.
1. Εάν η μετάβαση της διαφάνειας είναι ενεργοποιημένη για προώθηση με κλικ, η μετάβαση θα προχωρά μόνο όταν κάποιος κάνει κλικ με το ποντίκι. Επιπλέον, εάν οριστεί η ιδιότητα Advance After Time, η μετάβαση θα προχωρά αυτόματα μετά το πέρας του καθορισμένου χρόνου προώθησης.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο παρουσίασης.

```php
  # Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Ορισμός χρόνου μετάβασης 3 δευτερολέπτων
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Εφαρμογή μετάβασης τύπου χτένι στη διαφάνεια 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Ορισμός χρόνου μετάβασης 5 δευτερολέπτων
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Εφαρμογή μετάβασης τύπου ζουμ στη διαφάνεια 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Ορισμός χρόνου μετάβασης 7 δευτερολέπτων
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Αποθήκευση της παρουσίασης στο δίσκο
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Μετάβαση Morph**
{{% alert color="primary" %}} 

Το Aspose.Slides for PHP via Java υποστηρίζει τώρα τη [Morph Transition](https://reference.aspose.com/slides/el/php-java/aspose.slides/morphtransition/). Αντιπροσωπεύει τη νέα μετάβαση morph που εισήχθη στο PowerPoint 2019.

{{% /alert %}} 

Η μετάβαση Morph σας επιτρέπει να δημιουργήσετε ομαλή κίνηση από τη μία διαφάνεια στην επόμενη. Αυτό το άρθρο περιγράφει την έννοια και πώς να χρησιμοποιήσετε τη μετάβαση Morph. Για να χρησιμοποιήσετε αποτελεσματικά τη μετάβαση Morph, χρειάζεστε δύο διαφάνειες με τουλάχιστον ένα κοινό αντικείμενο. Ο πιο εύκολος τρόπος είναι να αντιγράψετε τη διαφάνεια και στη συνέχεια να μετακινήσετε το αντικείμενο στη δεύτερη διαφάνεια σε διαφορετική θέση.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να προσθέσετε ένα κλώνο της διαφάνειας με κάποιο κείμενο στην παρουσίαση και να ορίσετε μια μετάβαση [morph type](https://reference.aspose.com/slides/el/php-java/aspose.slides/TransitionType) στη δεύτερη διαφάνεια.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Τύποι Μετάβασης Morph**
Έχει προστεθεί νέο enum [TransitionMorphType](https://reference.aspose.com/slides/el/php-java/aspose.slides/TransitionMorphType). Αντιπροσωπεύει διαφορετικούς τύπους μετάβασης Morph διαφάνειας.

Το enum TransitionMorphType έχει τρία μέλη:

- ByObject: Η μετάβαση Morph θα εκτελείται λαμβάνοντας υπόψη τα σχήματα ως αδιάσπαστα αντικείμενα.
- ByWord: Η μετάβαση Morph θα εκτελείται μεταφέροντας το κείμενο λέξη προς λέξη όπου είναι δυνατόν.
- ByChar: Η μετάβαση Morph θα εκτελείται μεταφέροντας το κείμενο χαρακτήρα προς χαρακτήρα όπου είναι δυνατόν.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ορίσετε τη μετάβαση morph σε μια διαφάνεια και να αλλάξετε τον τύπο morph:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ορισμός Εφέ Μετάβασης**
Το Aspose.Slides for PHP via Java υποστηρίζει τον ορισμό εφέ μετάβασης όπως από μαύρο, από αριστερά, από δεξιά κ.λπ. Για να ορίσετε το εφέ μετάβασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
- Λάβετε την αναφορά της διαφάνειας.
- Ορίστε το εφέ μετάβασης.
- Γράψτε την παρουσίαση ως αρχείο [PPTX ](https://docs.fileformat.com/presentation/pptx/).

Στο παρακάτω παράδειγμα, έχουμε ορίσει τα εφέ μετάβασης.

```php
  # Δημιουργία αντικειμένου κλάσης Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Ορισμός εφέ
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Αποθήκευση της παρουσίασης στο δίσκο
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Ορίστε την [ταχύτητα](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/setspeed/) της μετάβασης χρησιμοποιώντας τη ρύθμιση [TransitionSpeed](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitionspeed/) (π.χ., slow/medium/fast).

**Μπορώ να συνδέσω ήχο σε μια μετάβαση και να τον κάνω επαναλήψιμο;**

Ναι. Μπορείτε να ενσωματώσετε ήχο για τη μετάβαση και να ελέγχετε τη συμπεριφορά μέσω ρυθμίσεων όπως λειτουργία ήχου και επανάληψη (π.χ., [setSound](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/setsoundloop/), καθώς και μεταδεδομένα όπως [setSoundIsBuiltIn](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) και [setSoundName](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Ποιος είναι ο πιο γρήγορος τρόπος να εφαρμόσετε την ίδια μετάβαση σε κάθε διαφάνεια;**

Ρυθμίστε τον επιθυμητό τύπο μετάβασης στις ρυθμίσεις μετάβασης κάθε διαφάνειας· οι μεταβάσεις αποθηκεύονται ανά διαφάνεια, οπότε η εφαρμογή του ίδιου τύπου σε όλες τις διαφάνειες δίνει συνεπές αποτέλεσμα.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι τρέχουσα στη διαφάνεια;**

Εξετάστε τις [ρυθμίσεις μετάβασης](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας και διαβάστε τον [τύπο μετάβασης](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/settype/); αυτή η τιμή σας δείχνει ακριβώς ποιο εφέ έχει εφαρμοστεί.