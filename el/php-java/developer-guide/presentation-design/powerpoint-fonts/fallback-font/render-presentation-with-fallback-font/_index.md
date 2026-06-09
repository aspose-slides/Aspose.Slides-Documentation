---
title: Απόδοση παρουσιάσεων με εναλλακτικές γραμματοσειρές σε PHP
linktitle: Απόδοση παρουσιάσεων
type: docs
weight: 30
url: /el/php-java/render-presentation-with-fallback-font/
keywords:
- εναλλακτική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εναλλακτικές γραμματοσειρές στο Aspose.Slides για PHP μέσω Java - διατήρηση του κειμένου συνεπούς σε PPT, PPTX και ODP με βήμα-βήμα παραδείγματα κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εναλλακτικών γραμματοσειρών. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εναλλακτικές γραμματοσειρές, και να εκχωρήσετε τη συλλογή στη μέθοδο `FontsManager::setFontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εναλλακτικών γραμματοσειρών εκχωρηθεί στο `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα PNG.

## **Απόδοση διαφάνειας χρησιμοποιώντας κανόνες εναλλακτικών γραμματοσειρών**

Οι ακόλουθες βήματα περιλαμβάνονται στο παράδειγμα:

1. Δημιουργούμε [συλλογή κανόνων εναλλακτικών γραμματοσειρών](/slides/el/php-java/create-fallback-fonts-collection/).
1. [Αφαιρέστε](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) έναν κανόνα εναλλακτικής γραμματοσειράς και [addFallBackFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) σε άλλο κανόνα.
1. Ορίστε τη συλλογή κανόνων στο [getFontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) μέθοδο.
1. Με τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation#save-java.lang.String-int-) μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή, ή να την αποθηκεύσουμε σε άλλη. Αφού η συλλογή κανόνων εναλλακτικών γραμματοσειρών έχει οριστεί στο [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontsManager), αυτοί οι κανόνες εφαρμόζονται σε οποιεσδήποτε λειτουργίες στην παρουσίαση: αποθήκευση, απόδοση, μετατροπή κ.ά.

```php
  # Δημιουργήστε νέο αντικείμενο συλλογής κανόνων
  $rulesList = new FontFallBackRulesCollection();
  # Δημιουργήστε έναν αριθμό κανόνων
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Προσπάθεια αφαίρεσης της εναλλακτικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
    $fallBackRule->remove("Tahoma");
    # Και ενημέρωση των κανόνων για το καθορισμένο εύρος
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Μπορούμε επίσης να αφαιρέσουμε τυχόν υπάρχοντες κανόνες από τη λίστα
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Ανάθεση προετοιμασμένης λίστας κανόνων για χρήση
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Απόδοση μικρογραφίας χρησιμοποιώντας τη δημιουργημένη συλλογή κανόνων και αποθήκευση σε JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Αποθήκευση της εικόνας στο δίσκο σε μορφή JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
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

{{% alert color="primary" %}} 
Διαβάστε περισσότερα σχετικά με το πώς να μετατρέψετε PPT και PPTX σε JPG σε PHP.
{{% /alert %}}