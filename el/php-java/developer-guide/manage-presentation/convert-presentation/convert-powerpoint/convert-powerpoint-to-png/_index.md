---
title: Μετατροπή διαφανειών PowerPoint σε PNG με PHP
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/php-java/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- αποθήκευση PPT ως PNG
- αποθήκευση PPTX ως PNG
- εξαγωγή PPT σε PNG
- εξαγωγή PPTX σε PNG
- PHP
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με Aspose.Slides για PHP μέσω Java, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να φορτώσετε αρχεία παρουσίασης σε μορφές όπως PPT, PPTX και ODP, να αποδόσετε διαφάνειες ως εικόνες και να αποθηκεύσετε τα αποτελέσματα σε μορφή PNG.

Το άρθρο επίσης παρουσιάζει πώς να προσαρμόσετε τις παραγόμενες εικόνες PNG ορίζοντας τιμές κλίμακας ή καθορίζοντας το επιθυμητό πλάτος και ύψος.

## **Μετατροπή PowerPoint σε PNG**

Ακολουθήστε αυτά τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πάρτε το αντικείμενο διαφάνειας από τη συλλογή [Presentation.getSlides()](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlides) της κλάσης [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/).
3. Χρησιμοποιήστε τη μέθοδο [Slide.getImage()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getImage) για να λάβετε τη μικρογραφία για κάθε διαφάνεια.
4. Χρησιμοποιήστε τη μέθοδο [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/#save) για να αποθηκεύσετε τη μικρογραφία της διαφάνειας σε μορφή PNG.

Αυτός ο κώδικας PHP δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PNG:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Μετατροπή PowerPoint σε PNG με προσαρμοσμένες διαστάσεις**

Εάν θέλετε να λάβετε αρχεία PNG με συγκεκριμένη κλίμακα, μπορείτε να ορίσετε τις τιμές για `desiredX` και `desiredY`, οι οποίες καθορίζουν τις διαστάσεις της προκύπτουσας μικρογραφίας.

Αυτός ο κώδικας παρουσιάζει τη περιγραφόμενη λειτουργία:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Μετατροπή PowerPoint σε PNG με προσαρμοσμένο μέγεθος**

Εάν θέλετε να λάβετε αρχεία PNG με συγκεκριμένο μέγεθος, μπορείτε να περάσετε τα επιθυμητά ορίσματα `width` και `height` για το `ImageSize`.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PNG καθορίζοντας το μέγεθος των εικόνων:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξάγω μόνο ένα συγκεκριμένο σχήμα (π.χ., γράφημα ή εικόνα) αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει [τη δημιουργία μικρογραφιών για ξεχωριστά σχήματα](/slides/el/php-java/create-shape-thumbnails/); μπορείτε να αποδώσετε ένα σχήμα σε εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι, αλλά [μην μοιράζεστε](/slides/el/php-java/multithreading/) ένα μόνο αντικείμενο παρουσίασης μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστό αντικείμενο ανά νήμα ή διεργασία.

**Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις εικόνες εξόδου και επιβάλλει [άλλους περιορισμούς](/slides/el/php-java/licensing/) μέχρι να εφαρμοστεί άδεια.