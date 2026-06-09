---
title: Διαχείριση γραφικών SmartArt σε παρουσιάσεις με χρήση PHP
linktitle: Γραφικά SmartArt
type: docs
weight: 20
url: /el/php-java/manage-smartart-shape/
keywords:
- Αντικείμενο SmartArt
- Γραφικό SmartArt
- Στυλ SmartArt
- Χρώμα SmartArt
- Δημιουργία SmartArt
- Προσθήκη SmartArt
- Επεξεργασία SmartArt
- Αλλαγή SmartArt
- Πρόσβαση SmartArt
- Τύπος διάταξης SmartArt
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Αυτοματοποιήστε τη δημιουργία, την επεξεργασία και το στυλ γραφικών SmartArt στο PowerPoint με PHP χρησιμοποιώντας το Aspose.Slides, παρέχοντας σύντομα παραδείγματα κώδικα και οδηγίες επικεντρωμένες στην απόδοση."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να δημιουργείτε και να διαχειρίζεστε γραφικά SmartArt σε παρουσιάσεις PowerPoint προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να προσθέσετε ένα σχήμα SmartArt σε μια διαφάνεια, να έχετε πρόσβαση σε υπάρχοντα σχήματα SmartArt, να εντοπίσετε SmartArt με συγκεκριμένο τύπο διάταξης και να ενημερώσετε την οπτική του εμφάνιση αλλάζοντας το στυλ SmartArt ή το χρωματικό στυλ.

Τα παραδείγματα δείχνουν πώς να εργάζεστε με σχήματα SmartArt μέσω της συλλογής σχημάτων της διαφάνειας της παρουσίασης, να ελέγξετε εάν ένα σχήμα είναι SmartArt και στη συνέχεια να τροποποιήσετε ή να ελέγξετε τις ιδιότητές του.

## **Δημιουργία σχήματος SmartArt**
Το Aspose.Slides for PHP via Java παρέχει ένα API για τη δημιουργία σχημάτων SmartArt. Για να δημιουργήσετε ένα σχήμα SmartArt σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) .
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. [Προσθέστε ένα σχήμα SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addSmartArt) ορίζοντας το [LayoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArtLayoutType) .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  # Δημιουργία κλάσης Presentation
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη σχήματος Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Αποθήκευση παρουσίασης
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt προστεθεί στη διαφάνεια**|

## **Πρόσβαση σε σχήμα SmartArt σε διαφάνεια**
Ο παρακάτω κώδικας θα χρησιμοποιηθεί για την πρόσβαση στα σχήματα SmartArt που προστέθηκαν στη διαφάνεια της παρουσίασης. Στον δείγμα κώδικα θα διατρέξουμε κάθε σχήμα μέσα στη διαφάνεια και θα ελέγξουμε εάν είναι σχήμα [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArt). Αν το σχήμα είναι τύπου SmartArt, θα το μετατρέψουμε τύπου [**SmartArt**](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArt) .

```php
  # Φόρτωση της επιθυμητής παρουσίασης
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατρέψτε το σχήμα σε SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Πρόσβαση σε σχήμα SmartArt με συγκεκριμένο τύπο διάταξης**
Ο παρακάτω δείγμα κώδικα θα βοηθήσει στην πρόσβαση στο σχήμα [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArt) με συγκεκριμένο LayoutType. Σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt, καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν προστίθεται το σχήμα [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArt).

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Ελέγξτε το σχήμα SmartArt με συγκεκριμένο LayoutType και εκτελέστε ό,τι απαιτείται μετά.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατρέψτε το σχήμα σε SmartArtEx
        $smart = $shape;
        # Έλεγχος διάταξης SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αλλαγή στυλ σχήματος SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αλλάξουμε το γρήγορο στυλ για οποιοδήποτε σχήμα SmartArt.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Βρείτε το σχήμα SmartArt με συγκεκριμένο Style.
1. Ορίστε το νέο Style για το σχήμα SmartArt.
1. Αποθηκεύστε την Παρουσίαση.

```php
  # Δημιουργία κλάσης Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Λήψη πρώτης διαφάνειας
    $slide = $pres->getSlides()->get_Item(0);
    # Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($slide->getShapes() as $shape) {
      # Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατρέψτε το σχήμα σε SmartArtEx
        $smart = $shape;
        # Έλεγχος στυλ SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Αλλαγή στυλ SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Αποθήκευση παρουσίασης
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt με τροποποιημένο Style**|

## **Αλλαγή χρωματικού στυλ σχήματος SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αλλάξουμε το χρωματικό στυλ για οποιοδήποτε σχήμα SmartArt. Στον παρακάτω δείγμα κώδικα θα αποκτήσουμε πρόσβαση στο σχήμα SmartArt με συγκεκριμένο χρωματικό στυλ και θα αλλάξουμε το στυλ του.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Βρείτε το σχήμα SmartArt με συγκεκριμένο Color Style.
1. Ορίστε το νέο Color Style για το σχήμα SmartArt.
1. Αποθηκεύστε την Παρουσίαση.

```php
  # Δημιουργία κλάσης Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Λήψη πρώτης διαφάνειας
    $slide = $pres->getSlides()->get_Item(0);
    # Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($slide->getShapes() as $shape) {
      # Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατρέψτε το σχήμα σε SmartArtEx
        $smart = $shape;
        # Έλεγχος τύπου χρώματος SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Αλλαγή τύπου χρώματος SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Αποθήκευση παρουσίασης
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt με τροποποιημένο Color Style**|

## **Συχνές ερωτήσεις**

**Μπορώ να προσθέσω κίνηση στο SmartArt ως ένα ενιαίο αντικείμενο;**

Ναι. Το SmartArt είναι σχήμα, οπότε μπορείτε να εφαρμόσετε [standard animations](/slides/el/php-java/powerpoint-animation/) μέσω του API κινήσεων (είσοδος, έξοδος, έμφαση, μονοπάτια κίνησης) όπως και για άλλα σχήματα.

**Πώς μπορώ να βρω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν δεν γνωρίζω το εσωτερικό του ID;**

Ορίστε και χρησιμοποιήστε το Εναλλακτικό Κείμενο (AltText) και αναζητήστε το σχήμα με αυτή την τιμή — αυτή είναι η προτεινόμενη μέθοδος για την εντόπιση του επιθυμητού σχήματος.

**Μπορώ να ομαδοποιήσω το SmartArt με άλλα σχήματα;**

Ναι. Μπορείτε να ομαδοποιήσετε το SmartArt με άλλα σχήματα (εικόνες, πίνακες κ.λπ.) και έπειτα να [διαχειριστείτε την ομάδα](/slides/el/php-java/group/).

**Πώς μπορώ να λάβω μια εικόνα από ένα συγκεκριμένο SmartArt (π.χ., για προεπισκόπηση ή αναφορά);**

Εξάγετε μια μικρογραφία/εικόνα του σχήματος· η βιβλιοθήκη μπορεί να [αποδώσετε μεμονωμένα σχήματα](/slides/el/php-java/create-shape-thumbnails/) σε αρχεία raster (PNG/JPG/TIFF).

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή ολόκληρης της παρουσίασης σε PDF;**

Ναι. Η μηχανή απόδοσης στοχεύει σε υψηλή ακρίβεια για [εξαγωγή PDF](/slides/el/php-java/convert-powerpoint-to-pdf/), με μια σειρά από επιλογές ποιότητας και συμβατότητας.