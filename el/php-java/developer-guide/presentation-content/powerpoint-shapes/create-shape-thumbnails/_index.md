---
title: Δημιουργία Μικρογραφιών Σχημάτων Παρουσίασης σε PHP
linktitle: Μικρογραφίες Σχημάτων
type: docs
weight: 70
url: /el/php-java/create-shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχήματος
- οπτικά όρια
- όρια σχήματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχήματος από διαφάνειες PowerPoint με Aspose.Slides for PHP via Java – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Το Aspose.Slides χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης όπου κάθε σελίδα είναι μια διαφάνεια. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Ωστόσο, κάποιες φορές οι προγραμματιστές μπορεί να χρειάζονται να δουν τις εικόνες των σχήματος ξεχωριστά σε προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες εικόνων των σχήματος της διαφάνειας. Η χρήση αυτής της δυνατότητας περιγράφεται σε αυτό το άρθρο.

Το άρθρο αυτό εξηγεί πώς να δημιουργήσετε μικρογραφίες διαφάνειας με διαφορετικούς τρόπους:

- Δημιουργία μικρογραφίας σχήματος μέσα σε μια διαφάνεια.  
- Δημιουργία μικρογραφίας σχήματος για ένα σχήμα διαφάνειας με διαστάσεις που ορίζονται από τον χρήστη.  
- Δημιουργία μικρογραφίας σχήματος εντός των ορίων της εμφάνισης του σχήματος.

## **Δημιουργία Μικρογραφίας Σχήματος από Διαφάνεια**
Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides for PHP via Java, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).  
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.  
1. [Αποκτήστε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage) της αναφερθείσας διαφάνειας στην προεπιλεγμένη κλίμακα.  
1. Αποθηκεύστε την εικόνα μικρογραφίας στη μορφή εικόνας που προτιμάτε.

Αυτός ο κώδικας δείγματος δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος από μια διαφάνεια:

```php
  # Δημιουργία κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Δημιουργία εικόνας σε πλήρη κλίμακα
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Δημιουργία Μικρογραφίας με Κλίμακα Καθορισμένη από το Χρήστη**
Για να δημιουργήσετε τη μικρογραφία σχήματος μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides for PHP via Java, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).  
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.  
1. [Αποκτήστε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage) της αναφερθείσας διαφάνειας με διαστάσεις που ορίζονται από τον χρήστη.  
1. Αποθηκεύστε την εικόνα μικρογραφίας στη μορφή εικόνας που προτιμάτε.

Αυτός ο κώδικας δείγματος δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος βάσει καθορισμένης κλίμακας:

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Δημιουργία εικόνας πλήρους κλίμακας
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Δημιουργία Μικρογραφίας Εμφάνισης Σχήματος βάσει Ορίων**
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχήματος επιτρέπει στους προγραμματιστές να δημιουργήσουν μια μικρογραφία εντός των ορίων της εμφάνισης του σχήματος. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η παραγόμενη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία σχήματος μέσα στα όρια της εμφάνισής του, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).  
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.  
1. Αποκτήστε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας με τα όρια του σχήματος ως εμφάνιση.  
1. Αποθηκεύστε την εικόνα μικρογραφίας στη μορφή εικόνας που προτιμάτε.

Αυτός ο κώδικας δείγματος βασίζεται στα παραπάνω βήματα:

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Δημιουργία εικόνας πλήρους κλίμακας
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Λήψη των Πραγματικών Οπτικών Ορίων ενός Σχήματος**

Οι ιδιότητες πλαισίου του [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()`, και `Shape::getHeight()`—περιγράφουν το ορθογώνιο που αποθηκεύεται στο μοντέλο παρουσίασης. Το περιεχόμενο που πραγματικά αποτυπώνεται μπορεί να επεκταθεί πέρα από αυτό το πλαίσιο ή να καταλαμβάνει διαφορετικό ορθογώνιο ευθυγραμμισμένο στον άξονα. Περιστροφή, περιγράμματα, κεφαλές βελών, διάταξη κειμένου και υπερχείλιση, η γεωμετρία του SmartArt που δημιουργείται και άλλα εφέ απόδοσης μπορούν όλα να αλλάξουν την καταληπτή περιοχή.

Χρησιμοποιήστε [Shape::getVisualBounds](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getVisualBounds) για να υπολογίσετε αυτήν την κατειλημμένη περιοχή χωρίς να δημιουργήσετε εικόνα. Η μέθοδος επιστρέφει ένα [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) σε συντεταγμένες διαφάνειας. Το επιστρεφόμενο ορθογώνιο δεν περικόπτεται στο όριο της διαφάνειας, έτσι οι συντεταγμένες του μπορούν να είναι αρνητικές όταν το περιεχόμενο ξεπέρασε την αρχή της διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει και συγκρίνει τα όρια πλαισίου και τα οπτικά όρια:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Το ίδιο [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) μπορεί να χρησιμοποιηθεί για να ευθυγραμμιστούν κοντινά σχήματα προς την αριστερή, δεξιά, άνω ή κάτω άκρη του· να διατηρηθεί επαρκής χώρος σε μια δημιουργούμενη διάταξη· ή για να εντοπιστεί περιεχόμενο εκτός της επιτρεπόμενης περιοχής. Τα οπτικά όρια είναι ιδιαίτερα χρήσιμα για SmartArt, πλαίσια κειμένου, βέλη, εικόνες, περιστρεφόμενα σχήματα και ομαδικά σχήματα, όπου το αποθηκευμένο πλαίσιο μπορεί να μην αντιπροσωπεύει το πλήρες αποτέλεσμα της απόδοσης.

Χρησιμοποιήστε [Shape::getVisualBounds](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getVisualBounds) όταν χρειάζεστε συντεταγμένες για διάταξη ή επαλήθευση και δεν χρειάζεστε bitmap. Χρησιμοποιήστε [Shape::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage) όταν χρειάζεται να αποδώσετε το σχήμα. Με το [ShapeThumbnailBounds](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` προσαρμόζει την εικόνα από τα όρια του σχήματος, συμπεριλαμβανομένων των ρυθμίσεων περιγράμματος, ενώ `ShapeThumbnailBounds::Appearance` την προσαρμόζει από την εμφάνιση του σχήματος και περιορίζει το αποτέλεσμα στα όρια της διαφάνειας. Σε αντίθεση με αυτό, το `Shape::getVisualBounds` επιστρέφει μόνο το υπολογισμένο ορθογώνιο και δεν το περικόπτει στο όριο της διαφάνειας.

## **Συχνές Ερωτήσεις**

**Ποιες μορφές εικόνας μπορούν να χρησιμοποιηθούν όταν αποθηκεύετε μικρογραφίες σχήματος;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/php-java/aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξαχθούν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/writeassvg/) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

** Ποια είναι η διαφορά μεταξύ των ορίων Shape και Appearance όταν αποδίδεται μια μικρογραφία;**

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη τα [οπτικά εφέ](/slides/el/php-java/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα είναι σημειωμένο ως κρυφό; Θα εξακολουθήσει να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφής εμφάνισης επηρεάζει μόνο την προβολή διαφανειών αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται ομαδικά σχήματα, γραφήματα, SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που εκπροσωπείται ως [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/), και [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι σύστημα‑εγκατεστημένες γραμματοσειρές την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/php-java/custom-font/) (ή να [ρυθμίσετε υποκατάστατα γραμματοσειρών](/slides/el/php-java/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναλλαγές και αναδιάταξη κειμένου.