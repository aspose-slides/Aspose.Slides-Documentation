---
title: Κλωνοποίηση Διαφανειών Παρουσίασης σε PHP
linktitle: Κλωνοποίηση Διαφανειών
type: docs
weight: 35
url: /el/php-java/clone-slides/
keywords:
- κλωνοποίηση διαφάνειας
- αντιγραφή διαφάνειας
- αποθήκευση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε γρήγορα αντίγραφα διαφανειών PowerPoint με το Aspose.Slides για PHP. Ακολουθήστε τα σαφή παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγραφής ή αντιτύπου κάτι. Το Aspose.Slides for PHP via Java επίσης καθιστά δυνατό το να δημιουργήσετε ένα αντίγραφο ή κλώνο οποιασδήποτε διαφάνειας και στη συνέχεια να εισάγετε αυτή τη κλωνοποιημένη διαφάνεια στην τρέχουσα ή σε οποιαδήποτε άλλη ανοικτή παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν αρκετοί πιθανοί τρόποι κλωνοποίησης μιας διαφάνειας:

- Κλωνοποίηση στο Τέλος εντός μίας Παρουσίασης.
- Κλωνοποίηση σε Άλλη Θέση εντός Παρουσίασης.
- Κλωνοποίηση στο Τέλος σε άλλη Παρουσίαση.
- Κλωνοποίηση σε Άλλη Θέση σε άλλη Παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη Παρουσίαση.

Στο Aspose.Slides for PHP via Java, (μια συλλογή από αντικείμενα [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/Slide)) που εκτίθενται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) και [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας.

## **Κλωνοποίηση Διαφάνειας στο Τέλος μιας Παρουσίασης**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση στο τέλος των υπαρχουσών διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Λάβετε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) κάνοντας αναφορά στη συλλογή διαφανειών που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```php
  # Δημιουργήστε αντικείμενο Presentation που αντιπροσωπεύει αρχείο παρουσίασης
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Κλωνοποιήστε την επιθυμητή διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Αποθηκεύστε την τροποποιημένη παρουσίαση στον δίσκο
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Κλωνοποίηση Διαφάνειας σε Άλλη Θέση εντός Παρουσίασης**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone):

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Λάβετε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection) κάνοντας αναφορά στη συλλογή **[Slides](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides)** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τον δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (στην θέση μηδέν – θέση 1 – της παρουσίασης) στον δείκτη 1 – Θέση 2 – της παρουσίασης.

```php
  # Δημιουργήστε κλάση Presentation που αντιπροσωπεύει αρχείο παρουσίασης
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Κλωνοποιήστε την επιθυμητή διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    $slds = $pres->getSlides();
    # Κλωνοποιήστε την επιθυμητή διαφάνεια στη συγκεκριμένη θέση στην ίδια παρουσίαση
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Αποθηκεύστε την τροποποιημένη παρουσίαση στον δίσκο
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Κλωνοποίηση Διαφάνειας στο Τέλος μιας Άλλης Παρουσίασης**
Εάν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υπαρχουσών διαφανειών:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την προορισμένη παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Λάβετε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection) κάνοντας αναφορά στη συλλογή **[Slides](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides)** που εκτίθεται από το αντικείμενο Presentation της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια από την πηγή ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προορισμένης παρουσίασης.

```php
  # Δημιουργήστε αντικείμενο Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Δημιουργήστε αντικείμενο Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    $destPres = new Presentation();
    try {
      # Κλωνοποιήστε την επιθυμητή διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Αποθηκεύστε την προορισμένη παρουσίαση στον δίσκο
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Κλωνοποίηση Διαφάνειας σε Άλλη Θέση σε Άλλη Παρουσίαση**
Εάν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, σε συγκεκριμένη θέση:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Λάβετε την κλάση [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) κάνοντας αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια από την πηγή μαζί με την επιθυμητή θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον δείκτη μηδέν της πηγαίας παρουσίασης) στον δείκτη 1 (θέση 2) της προορισμένης παρουσίασης.

```php
  # Δημιουργήστε κλάση Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Δημιουργήστε κλάση Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    $destPres = new Presentation();
    try {
      # Κλωνοποιήστε την επιθυμητή διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Αποθηκεύστε την προορισμένη παρουσίαση στον δίσκο
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Κλωνοποίηση Διαφάνειας σε Συγκεκριμένη Θέση σε Άλλη Παρουσίαση**
Εάν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια (master slide) από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε τη ζητούμενη κύρια διαφάνεια από την πηγή στην προορισμένη παρουσίαση. Στη συνέχεια, χρησιμοποιήστε αυτή τη κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας μαζί με την κύρια διαφάνεια. Η μέθοδος [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) αναμένει μια κύρια διαφάνεια από την προορισμένη παρουσίαση και όχι από την πηγή. Για να κλωνοποιήσετε τη διαφάνεια με κύρια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την προορισμένη παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με την κύρια διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/MasterSlideCollection) κάνοντας αναφορά στη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από το αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/MasterSlideCollection) και περάστε τη κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone).
1. Δημιουργήστε ένα αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) θέτοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με την κύρια διαφάνεια ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια διαφάνεια (στην θέση μηδέν της πηγαίας παρουσίασης) στο τέλος της προορισμένης παρουσίασης χρησιμοποιώντας μια κύρια διαφάνεια από τη διαφάνεια πηγής.

```php
  # Δημιουργήστε κλάση Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Δημιουργήστε κλάση Presentation για την προορισμένη παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    $destPres = new Presentation();
    try {
      # Δημιουργήστε ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
      # την κύρια διαφάνεια
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Κλωνοποιήστε την επιθυμητή κύρια διαφάνεια από την πηγαία παρουσίαση στη συλλογή των κυρίων διαφανειών στην
      # προορισμένη παρουσίαση
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Κλωνοποιήστε την επιθυμητή κύρια διαφάνεια από την πηγαία παρουσίαση στη συλλογή των κυρίων διαφανειών στην
      # προορισμένη παρουσίαση
      $iSlide = $masters->addClone($SourceMaster);
      # Κλωνοποιήστε την επιθυμητή διαφάνεια από την πηγαία παρουσίαση με την επιθυμητή κύρια διαφάνεια στο τέλος της
      # συλλογής διαφανειών στην προορισμένη παρουσίαση
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Αποθηκεύστε την προορισμένη παρουσίαση στον δίσκο
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Κλωνοποίηση Διαφάνειας στο Τέλος μιας Συγκεκριμένης Ενότητας**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση αλλά σε διαφορετική ενότητα, τότε χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από την κλάση [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection). Το Aspose.Slides for PHP via Java επιτρέπει την κλωνοποίηση μιας διαφάνειας από την πρώτη ενότητα και την εισαγωγή της κλωνοποιημένης διαφάνειας στη δεύτερη ενότητα της ίδιας παρουσίασης.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να την εισάγετε στην συγκεκριμένη ενότητα.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Αποθηκεύστε την προορισμένη παρουσίαση στον δίσκο
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Διασφάλιση Συμβατού Μεγέθους Διαφάνειας**

Κατά την κλωνοποίηση διαφανειών σε άλλη παρουσίαση, βεβαιωθείτε ότι η προορισμένη παρουσίαση έχει το ίδιο μέγεθος διαφάνειας με την πηγή. Εάν τα μεγέθη διαφανειών διαφέρουν, το Aspose.Slides δεν κλιμακώνει αυτόματα τα κλωνοποιημένα σχήματα· οι αρχικές συντεταγμένες και διαστάσεις διατηρούνται, κάτι που μπορεί να προκαλέσει μη ευθυγράμμιση ή υπερβολική εμφάνιση του περιεχομένου εκτός των ορίων της διαφάνειας.

Μπορείτε να ορίσετε το μέγεθος διαφάνειας της προορισμένης παρουσίασης ώστε να ταιριάζει με το μέγεθος της πηγής πριν την κλωνοποίηση του master και της διαφάνειας:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Κάντε αυτό πριν την κλωνοποίηση του master και της διαφάνειας.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Κλωνοποιούνται οι σημειώσεις του ομιλητή και τα σχόλια ελεγκτών;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια ελέγχου περιλαμβάνονται στο κλώνο. Εάν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/php-java/presentation-notes/) μετά την εισαγωγή.

**Πώς αντιμετωπίζονται τα διαγράμματα και οι πηγές δεδομένων τους;**

Το αντικείμενο διαγράμματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το διάγραμμα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ., ένα ενσωματωμένο βιβλίο εργασίας OLE), η σύνδεση διατηρείται ως [OLE object](/slides/el/php-java/manage-ole/). Μετά τη μεταφορά μεταξύ αρχείων, επαληθεύστε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ενημέρωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τις ενότητες για το κλώνο;**

Ναι. Μπορείτε να εισάγετε το κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να το τοποθετήσετε σε επιλεγμένη [section](/slides/el/php-java/slide-section/). Εάν η ενότητα-στόχος δεν υπάρχει, δημιουργήστε την πρώτα και στη συνέχεια μετακινήστε τη διαφάνεια σε αυτήν.