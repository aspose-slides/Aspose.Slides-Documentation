---
title: "Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις με PHP"
linktitle: "Ετικέτες και Προσαρμοσμένα Δεδομένα"
type: docs
weight: 300
url: /el/php-java/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσθήκη ετικέτας
- τιμές ζεύγους
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να διαβάζετε, να ενημερώνετε και να αφαιρείτε ετικέτες & προσαρμοσμένα δεδομένα στο Aspose.Slides για PHP μέσω Java, με παραδείγματα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Περιγράφει εν συντομία πώς αποθηκεύονται τα δεδομένα σε αρχεία PPTX, σημειώνει ότι τα δεδομένα ειδικά για την παρουσίαση μπορούν να υπάρχουν ως ετικέτες και προσαρμοσμένα XML τμήματα, και ορίζει τις ετικέτες ως ζεύγη κλειδιού‑τιμής συμβολοσειράς.

Επίσης δείχνει πώς να διαβάσετε τις τιμές των ετικετών και πώς να προσθέσετε ετικέτες σε μια παρουσίαση, μία μεμονωμένη διαφάνεια ή ένα σχήμα. Επιπλέον, το άρθρο καλύπτει κοινές εργασίες διαχείρισης ετικετών όπως ο καθαρισμός όλων των ετικετών, η αφαίρεση ετικέτας κατά όνομα και η ανάκτηση της λίστας ονομάτων ετικετών.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX—αντικείμενα με την επέκταση .pptx—αποθηκεύονται στη μορφή PresentationML, η οποία αποτελεί μέρος του προτύπου Office Open XML. Η μορφή Office Open XML καθορίζει τη δομή των δεδομένων που περιέχονται σε παρουσιάσεις.

Με μια *διαφάνεια* να είναι ένα από τα στοιχεία στις παρουσιάσεις, ένα *τμήμα διαφάνειας* περιέχει το περιεχόμενο μιας μοναδικής διαφάνειας. Ένα τμήμα διαφάνειας επιτρέπεται να έχει ρητές σχέσεις με πολλά τμήματα—όπως οι Προσαρμοσμένες Ετικέτες—που ορίζονται από το ISO/IEC 29500.

Προσαρμοσμένα δεδομένα (συγκεκριμένα για μια παρουσίαση) ή ο χρήστης μπορούν να υπάρξουν ως ετικέτες ([TagCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/)) και CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 

Οι ετικέτες είναι ουσιαστικά ζεύγη κλειδιού‑τιμής τύπου συμβολοσειράς. 

{{% /alert %}} 

## **Λήψη Τιμών Ετικετών**

Στο Slides, μια ετικέτα αντιστοιχεί στις μεθόδους [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getKeywords) και [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#setKeywords). Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides for PHP via Java για την [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σας επιτρέπει να προσθέσετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας – `MyTag`
- η τιμή της προσαρμοσμένης ιδιότητας – `My Tag Value`

Αν χρειάζεται να ταξινομήσετε ορισμένες παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να επωφεληθείτε προσθέτοντας ετικέτες σε αυτές τις παρουσιάσεις. Για παράδειγμα, εάν θέλετε να ομαδοποιήσετε όλες τις παρουσιάσεις από τις χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και στη συνέχεια να ορίσετε τις σχετικές χώρες (ΗΠΑ, Μεξικό, Καναδά) ως τιμές.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) χρησιμοποιώντας το Aspose.Slides for PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Οι ετικέτες μπορούν επίσης να οριστούν για το [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ή για οποιοδήποτε μεμονωμένο [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής ετικετών προσαρμοσμένων δεδομένων με τη μέθοδο `getCustomData()->getTags()` αποθηκεύονται μόνο στο αρχείο PowerPoint. Δεν **μεταβιβάζονται** στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος ταυτοποιητής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Λύση**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο ταυτοποιητή στο **Alt Text** του αντικειμένου (π.χ., `$shape->setAlternativeText("MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών PDF.

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία ενέργεια;**

Ναι. Η [tag collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/) υποστηρίζει την ενέργεια [clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/clear/) που διαγράφει όλα τα ζεύγη κλειδιού‑τιμής ταυτόχρονα.

**Πώς μπορώ να διαγράψω μία ετικέτα με βάση το όνομα της χωρίς να επαναλαμβάνομαι σε ολόκληρη τη συλλογή;**

Χρησιμοποιήστε την ενέργεια [remove(name)](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/remove/) στη [tag collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα των ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε τη μέθοδο [getNamesOfTags](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/getnamesoftags/) στη [tag collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.