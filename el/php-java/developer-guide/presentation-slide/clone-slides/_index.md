---
title: Κλωνοποίηση διαφανειών παρουσίασης σε PHP
linktitle: Κλωνοποίηση διαφανειών
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
description: "Δημιουργήστε γρήγορα αντίγραφα διαφανειών PowerPoint με το Aspose.Slides για PHP. Ακολουθήστε τα σαφή παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαφανίσετε την χειρωνακτική εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντιτύπου κάτι. Το Aspose.Slides for PHP via Java καθιστά επίσης δυνατόν να γίνει αντίγραφο ή κλώνος οποιασδήποτε διαφάνειας και στη συνέχεια να εισαχθεί αυτή η κλωνοποιημένη διαφάνεια στην τρέχουσα ή σε οποιαδήποτε άλλη ανοιγμένη παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν διάφοροι πιθανοί τρόποι κλωνοποίησης μιας διαφάνειας:

- Κλωνοποίηση στο τέλος εντός μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός της παρουσίασης.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for PHP via Java, (μια συλλογή αντικειμένων [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/Slide) ) που εκτίθενται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) και [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας

## **Κλωνοποίηση διαφάνειας στο τέλος μιας παρουσίασης**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης στο τέλος των υπάρχουσων διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Αποκτήστε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) αναφέροντας τη συλλογή διαφανειών που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```php
  # Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Κλωνοποιήστε την επιθυμητή διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Γράψτε την τροποποιημένη παρουσίαση στο δίσκο
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση εντός μιας παρουσίασης**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone):

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Αποκτήστε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection) αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με το δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στον δείκτη μηδέν – θέση 1 – της παρουσίασης) στον δείκτη 1 – Θέση 2 – της παρουσίασης.

```php
  # Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Κλωνοποίηση της επιθυμητής διαφάνειας στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    $slds = $pres->getSlides();
    # Κλωνοποίηση της επιθυμητής διαφάνειας στον καθορισμένο δείκτη στην ίδια παρουσίαση
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Αποθήκευση της τροποποιημένης παρουσίασης στο δίσκο
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Κλωνοποίηση διαφάνειας στο τέλος άλλης παρουσίασης**
Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλο αρχείο παρουσίασης, στο τέλος των υπάρχουσων διαφανειών:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την προορισμένη παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Αποκτήστε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection) αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) που εκτίθεται από το αντικείμενο Presentation της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια από την πηγή ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προορισμένης παρουσίασης.

```php
  # Δημιουργία κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Δημιουργία κλάσης Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    $destPres = new Presentation();
    try {
      # Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση σε άλλη παρουσίαση**
Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλο αρχείο παρουσίασης, σε συγκεκριμένη θέση:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Αποκτήστε την κλάση [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με τη ζητούμενη θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#insertClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον δείκτη μηδέν της πηγαίας παρουσίασης) στον δείκτη 1 (θέση 2) της προορισμένης παρουσίασης.

```php
  # Δημιουργία κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Δημιουργία κλάσης Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    $destPres = new Presentation();
    try {
      # Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Κλωνοποίηση διαφάνειας σε συγκεκριμένη θέση σε άλλη παρουσίαση**
Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια (master slide) από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε την επιθυμητή κύρια διαφάνεια από την πηγή στην προορισμένη παρουσίαση. Στη συνέχεια να χρησιμοποιήσετε αυτήν την κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας με κύρια διαφάνεια. Η μέθοδος [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) αναμένει μια κύρια διαφάνεια από την προορισμένη παρουσίαση και όχι από την πηγαία. Για να κλωνοποιήσετε τη διαφάνεια με κύρια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει την προορισμένη παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με την κύρια διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/MasterSlideCollection) αναφέροντας τη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από το αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/MasterSlideCollection) και περάστε την κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone).
1. Δημιουργήστε μια παρουσία της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) θέτοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSlides) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με την κύρια διαφάνεια ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια (που βρίσκεται στον δείκτη μηδέν της πηγαίας παρουσίασης) στο τέλος της προορισμένης παρουσίασης χρησιμοποιώντας κύρια διαφάνεια από τη πηγαία διαφάνεια.

```php
  # Δημιουργία κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Δημιουργία κλάσης Presentation για την προορισμένη παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    $destPres = new Presentation();
    try {
      # Δημιουργία αντικειμένου ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
      # Κύρια διαφάνεια
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Κλωνοποίηση της επιθυμητής κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κύριων διαφανειών στο
      # Προορισμένη παρουσίαση
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Κλωνοποίηση της επιθυμητής κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κύριων διαφανειών στο
      # Προορισμένη παρουσίαση
      $iSlide = $masters->addClone($SourceMaster);
      # Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση με την επιθυμητή κύρια διαφάνεια στο τέλος του
      # Συλλογής διαφανειών στην προορισμένη παρουσίαση
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Κλωνοποίηση διαφάνειας στο τέλος ενός συγκεκριμένου τμήματος**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετικό τμήμα, χρησιμοποιήστε τη [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection/#addClone) μέθοδο που εκτίθεται από την κλάση [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection). Το Aspose.Slides for PHP via Java κάνει δυνατό τον κλωνοποίηση μιας διαφάνειας από το πρώτο τμήμα και στη συνέχεια την εισαγωγή της κλωνοποιημένης διαφάνειας στο δεύτερο τμήμα της ίδιας παρουσίασης.

Ο παρακάτω κώδικας δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε τη κλωνοποιημένη διαφάνεια σε ένα συγκεκριμένο τμήμα.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και τα σχόλια αξιολογητή;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια αξιολόγησης περιλαμβάνονται στην κλωνοποίηση. Εάν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/php-java/presentation-notes/) μετά την εισαγωγή.

**Πώς αντιμετωπίζονται τα γραφήματα και οι πηγές δεδομένων τους;**

Το αντικείμενο γραφήματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ., ένα OLE‑ενσωματωμένο βιβλίο εργασίας), αυτή η σύνδεση διατηρείται ως ένα [OLE object](/slides/el/php-java/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για την κλωνοποίηση;**

Ναι. Μπορείτε να εισάγετε την κλωνοποίητη διαφάνεια σε συγκεκριμένο δείκτη διαφάνειας και να την τοποθετήσετε σε μια επιλεγμένη [section](/slides/el/php-java/slide-section/). Εάν το στόχο τμήμα δεν υπάρχει, δημιουργήστε το πρώτα και μετά μετακινήστε τη διαφάνεια σε αυτό.