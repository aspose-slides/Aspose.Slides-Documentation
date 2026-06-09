---
title: Πρόσβαση στις Διαφάνειες Παρουσίασης σε PHP
linktitle: Πρόσβαση στη Διαφάνεια
type: docs
weight: 20
url: /el/php-java/access-slide-in-presentation/
keywords:
- πρόσβαση σε διαφάνεια
- δείκτης διαφάνειας
- ID διαφάνειας
- θέση διαφάνειας
- αλλαγή θέσης
- ιδιότητες διαφάνειας
- αριθμός διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσπελάζετε και να διαχειρίζεστε διαφάνειες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java. Αυξήστε την παραγωγικότητα με παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσπελάζετε και να διαχειρίζεστε διαφάνειες σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανακτήσετε διαφάνειες με βάση τον μηδενικό δείκτη τους από τη συλλογή διαφανειών και πώς να προσπελάσετε μια διαφάνεια με το μοναδικό της αναγνωριστικό χρησιμοποιώντας τη μέθοδο `getSlideById`.

Θα μάθετε επίσης πώς να αλλάζετε τη θέση μιας διαφάνειας χρησιμοποιώντας τη μέθοδο `setSlideNumber` και πώς να ορίζετε τον αριθμό εκκίνησης της πρώτης διαφάνειας για μια παρουσίαση με τη μέθοδο `setFirstSlideNumber`. Τα παραδείγματα δείχνουν τη φόρτωση μιας παρουσίασης, την απόκτηση αναφορών σε διαφάνειες, την ενημέρωση της σειράς ή της αρίθμησης των διαφανειών και την αποθήκευση της τροποποιημένης παρουσίασης.

## **Πρόσβαση σε διαφάνεια με δείκτη**

Όλες οι διαφάνειες σε μια παρουσίαση είναι αριθμημένες βάσει της θέσης της διαφάνειας, ξεκινώντας από το 0. Η πρώτη διαφάνεια είναι προσβάσιμη μέσω του δείκτη 0· η δεύτερη διαφάνεια μέσω του δείκτη 1· κ.ο.κ.

Η κλάση Presentation, η οποία αντιπροσωπεύει ένα αρχείο παρουσίασης, εκθέτει όλες τις διαφάνειες ως μια συλλογή [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/) (συλλογή αντικειμένων [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/)). Αυτός ο κώδικας PHP δείχνει πώς να προσπελάσετε μια διαφάνεια μέσω του δείκτη της:

```php
  # Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("demo.pptx");
  try {
    # Προσπελαύνει μια διαφάνεια χρησιμοποιώντας το δείκτη της διαφάνειας
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Πρόσβαση σε διαφάνεια με ID**

Κάθε διαφάνεια σε μια παρουσίαση έχει ένα μοναδικό ID. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [getSlideById](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlideById-long-) (που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)) για να προσδιορίσετε αυτό το ID. Αυτός ο κώδικας PHP δείχνει πώς να παρέχετε ένα έγκυρο ID διαφάνειας και να προσπελάσετε τη διαφάνεια μέσω της μεθόδου [getSlideById](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlideById-long-):

```php
  # Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("demo.pptx");
  try {
    # Λαμβάνει το ID μιας διαφάνειας
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Προσπελαύνει τη διαφάνεια μέσω του ID της
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Αλλαγή θέσης διαφάνειας**

Το Aspose.Slides σας επιτρέπει να αλλάζετε τη θέση μιας διαφάνειας. Για παράδειγμα, μπορείτε να ορίσετε ότι η πρώτη διαφάνεια πρέπει να γίνει η δεύτερη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας (της οποίας τη θέση θέλετε να αλλάξετε) μέσω του δείκτη της.
1. Ορίστε μια νέα θέση για τη διαφάνεια μέσω της μεθόδου [setSlideNumber](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#setSlideNumber).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας PHP επιδεικνύει μια λειτουργία όπου η διαφάνεια στη θέση 1 μετακινείται στη θέση 2:

```php
  # Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("Presentation.pptx");
  try {
    # Λαμβάνει τη διαφάνεια της οποίας η θέση θα αλλάξει
    $sld = $pres->getSlides()->get_Item(0);
    # Ορίζει τη νέα θέση για τη διαφάνεια
    $sld->setSlideNumber(2);
    # Αποθηκεύει την τροποποιημένη παρουσίαση
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Η πρώτη διαφάνεια έγινε δεύτερη· η δεύτερη διαφάνεια έγινε πρώτη. Όταν αλλάζετε τη θέση μιας διαφάνειας, οι άλλες διαφάνειες ρυθμίζονται αυτόματα.

## **Ορισμός αριθμού διαφάνειας**

Χρησιμοποιώντας τη μέθοδο [setFirstSlideNumber](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)), μπορείτε να ορίσετε έναν νέο αριθμό για την πρώτη διαφάνεια σε μια παρουσίαση. Η λειτουργία αυτή προκαλεί τον επαναϋπολογισμό των αριθμών των υπόλοιπων διαφανειών.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε τον αριθμό της διαφάνειας.
1. Ορίστε τον αριθμό της διαφάνειας.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας PHP δείχνει μια λειτουργία όπου ο αριθμός της πρώτης διαφάνειας ορίζεται σε 10:

```php
  # Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Λαμβάνει τον αριθμό της διαφάνειας
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Ορίζει τον αριθμό της διαφάνειας
    $pres->setFirstSlideNumber(10);
    # Αποθηκεύει την τροποποιημένη παρουσίαση
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Εάν προτιμάτε να παραλείψετε την πρώτη διαφάνεια, μπορείτε να ξεκινήσετε την αρίθμηση από τη δεύτερη διαφάνεια (και να κρύψετε την αρίθμηση για την πρώτη) ως εξής:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Ορίζει τον αριθμό για την πρώτη διαφάνεια της παρουσίασης
    $presentation->setFirstSlideNumber(0);
    # Εμφανίζει τους αριθμούς διαφανειών για όλες τις διαφάνειες
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Αποκρύπτει τον αριθμό διαφάνειας για την πρώτη διαφάνεια
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Αποθηκεύει την τροποποιημένη παρουσίαση
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Ταιριάζει ο αριθμός της διαφάνειας που βλέπει ο χρήστης με τον μηδενικό δείκτη της συλλογής;**

Ο αριθμός που εμφανίζεται σε μια διαφάνεια μπορεί να ξεκινά από μια αυθαίρετη τιμή (π.χ., 10) και δεν χρειάζεται να ταιριάζει με τον δείκτη· η σχέση ελέγχεται από τη ρύθμιση [πρώτου αριθμού διαφάνειας](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/setfirstslidenumber/) της παρουσίασης.

**Επηρεάζουν οι κρυμμένες διαφάνειες την αρίθμηση;**

Ναι. Μια κρυμμένη διαφάνεια παραμένει στη συλλογή και μετράται στην αρίθμηση· το «κρυμμένο» αφορά την εμφάνιση, όχι τη θέση στη συλλογή.

**Αλλάζει ο δείκτης μιας διαφάνειας όταν προστίθενται ή αφαιρούνται άλλες διαφάνειες;**

Ναι. Οι δείκτες πάντα αντανακλούν την τρέχουσα σειρά στις διαφάνειες και επανυπολογίζονται κατά τις λειτουργίες εισαγωγής, διαγραφής και μετακίνησης.