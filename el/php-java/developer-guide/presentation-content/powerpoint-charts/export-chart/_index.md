---
title: Εξαγωγή Διαγραμμάτων Παρουσίασης σε PHP
linktitle: Εξαγωγή Διαγράμματος
type: docs
weight: 90
url: /el/php-java/export-chart/
keywords:
- διάγραμμα
- διάγραμμα σε εικόνα
- διάγραμμα ως εικόνα
- εξαγωγή εικόνας διαγράμματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να εξάγετε διαγράμματα παρουσίασης με το Aspose.Slides για PHP μέσω Java, υποστηρίζοντας μορφές PPT και PPTX, και να βελτιστοποιήσετε την αναφορά σε οποιαδήποτε ροή εργασίας."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να εξάγετε ένα διάγραμμα από μια παρουσίαση ως εικόνα. Αυτό το άρθρο δείχνει πώς να λάβετε μια εικόνα από ένα διάγραμμα και να την αποθηκεύσετε, κάτι που είναι χρήσιμο όταν χρειάζεται να επαναχρησιμοποιήσετε τα οπτικά στοιχεία του διαγράμματος εκτός μιας παρουσίασης PowerPoint.

## **Λήψη εικόνας διαγράμματος**
Το Aspose.Slides for PHP μέσω Java παρέχει υποστήριξη για εξαγωγή εικόνας συγκεκριμένου διαγράμματος. Παρακάτω παρέχεται ένα δείγμα.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
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

## **Συχνές ερωτήσεις**

**Μπορώ να εξάγω ένα διάγραμμα ως διανυσματική (SVG) αντί για εικόνα raster;**

Ναι. Ένα διάγραμμα είναι σχήμα, και τα περιεχόμενά του μπορούν να αποθηκευτούν σε SVG χρησιμοποιώντας τη [μέθοδο αποθήκευσης shape-to-SVG](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/writeassvg/).

**Πώς μπορώ να ορίσω το ακριβές μέγεθος του εξαγόμενου διαγράμματος σε εικονοστοιχεία;**

Χρησιμοποιήστε τις υπερφορτώσεις image-rendering που επιτρέπουν τον καθορισμό μεγέθους ή κλίμακας – η βιβλιοθήκη υποστηρίζει τη σχεδίαση αντικειμένων με δεδομένες διαστάσεις/κλίμακα.

**Τι πρέπει να κάνω αν οι γραμματοσειρές σε ετικέτες και υπόμνημα εμφανίζονται λανθασμένα μετά την εξαγωγή;**

[Φορτώστε τις απαιτούμενες γραμματοσειρές](/slides/el/php-java/custom-font/) μέσω του [FontsLoader](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsloader/) ώστε η απόδοση του διαγράμματος να διατηρεί τις μετρικές και την εμφάνιση του κειμένου.

**Η εξαγωγή σέβεται το θέμα, τα στυλ και τα εφέ του PowerPoint;**

Ναί. Ο μηχανισμός απόδοσης του Aspose.Slides ακολουθεί τη μορφοποίηση της παρουσίασης (θέματα, στυλ, γεμίσματα, εφέ), έτσι η εμφάνιση του διαγράμματος διατηρείται.

**Πού μπορώ να βρω διαθέσιμες δυνατότητες απόδοσης/εξαγωγής πέρα από τις εικόνες διαγραμμάτων;**

Δείτε το [API](https://reference.aspose.com/slides/el/php-java/aspose.slides/)/[τεκμηρίωση](/slides/el/php-java/convert-powerpoint/) για τους προορισμούς εξόδου ([PDF](/slides/el/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/el/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/el/php-java/convert-powerpoint-to-xps/), [HTML](/slides/el/php-java/convert-powerpoint-to-html/), κλπ.) και τις σχετικές επιλογές απόδοσης.