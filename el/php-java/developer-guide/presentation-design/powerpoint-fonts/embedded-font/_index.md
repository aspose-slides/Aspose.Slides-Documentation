---
title: Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις με PHP
linktitle: Ενσωμάτωση Γραμματοσειράς
type: docs
weight: 40
url: /el/php-java/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειρών
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ενσωματώστε γραμματοσειρές TrueType σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java, εξασφαλίζοντας ακριβή απόδοση σε όλες τις πλατφόρμες."
---
## **Εισαγωγή**

**Ενσωματωμένες γραμματοσειρές στο PowerPoint** είναι χρήσιμες όταν θέλετε η παρουσίασή σας να εμφανίζεται σωστά σε οποιοδήποτε σύστημα ή συσκευή. Εάν χρησιμοποιήσατε μια γραμματοσειρά τρίτου μέρους ή μη τυπική επειδή ήσασταν δημιουργικοί με τη δουλειά σας, τότε έχετε ακόμη περισσότερους λόγους για να ενσωματώσετε τη γραμματοσειρά σας. Διαφορετικά (χωρίς ενσωματωμένες γραμματοσειρές), τα κείμενα ή οι αριθμοί στις διαφάνειές σας, η διάταξη, η μορφοποίηση κ.λπ. μπορεί να αλλάξουν ή να μετατραπούν σε συγκεχυμένα ορθογώνια.  

Η κλάση [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontsManager), η κλάση [FontData](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontdata/) και η κλάση [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/) περιέχουν τις περισσότερες μεθόδους που χρειάζεστε για να εργάζεστε με ενσωματωμένες γραμματοσειρές σε παρουσιάσεις PowerPoint.

## **Λήψη και Αφαίρεση Ενσωματωμένων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [getEmbeddedFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (εκτείνεται από την κλάση [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontsManager)) ώστε να μπορείτε να λάβετε (ή να διαπιστώσετε) τις γραμματοσειρές που έχουν ενσωματωθεί σε μια παρουσίαση. Για να αφαιρέσετε γραμματοσειρές, χρησιμοποιείται η μέθοδος [removeEmbeddedFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (εκτείνεται από την ίδια κλάση).

```php
  # Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Δημιουργεί μια διαφάνεια που περιέχει ένα πλαίσιο κειμένου που χρησιμοποιεί την ενσωματωμένη "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Λαμβάνει όλες τις ενσωματωμένες γραμματοσειρές
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Βρίσκει τη γραμματοσειρά "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Αφαιρεί τη γραμματοσειρά "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Δημιουργεί την παρουσίαση· η γραμματοσειρά "Calibri" αντικαθίσταται με μια υπάρχουσα
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Αποθηκεύει την παρουσίαση χωρίς την ενσωματωμένη γραμματοσειρά "Calibri" στο δίσκο
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιώντας την κλάση [EmbedFontCharacters](https://reference.aspose.com/slides/el/php-java/aspose.slides/embedfontcharacters/) καθώς και τις δύο υπερφορτώσεις της μεθόδου [addEmbeddedFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), μπορείτε να επιλέξετε τον προτιμώμενο (ενσωμάτωσης) κανόνα για την ενσωμάτωση των γραμματοσειρών σε μια παρουσίαση. Αυτός ο κώδικας PHP σας δείχνει πώς να ενσωματώσετε και να προσθέσετε γραμματοσειρές σε μια παρουσίαση:

```php
  # Φορτώνει την παρουσίαση
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

Για να μπορείτε να συμπιέσετε τις γραμματοσειρές που έχουν ενσωματωθεί σε μια παρουσίαση και να μειώσετε το μέγεθος του αρχείου, το Aspose.Slides παρέχει τη μέθοδο [compressEmbeddedFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#compressEmbeddedFonts) (εκτείνεται από την κλάση [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/)).

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν μια συγκεκριμένη γραμματοσειρά στην παρουσίαση θα εξακολουθήσει να υποκαθίσταται κατά τη διάρκεια της απόδοσης παρά την ενσωμάτωση;**

Ελέγξτε τις [πληροφορίες αντικατάστασης](/slides/el/php-java/font-substitution/) στον διαχειριστή γραμματοσειρών και τους [κανόνες εναλλακτικής/αντικατάστασης](/slides/el/php-java/fallback-font/): εάν η γραμματοσειρά δεν είναι διαθέσιμη ή είναι περιορισμένη, θα χρησιμοποιηθεί μια εναλλακτική.

**Αξίζει να ενσωματώσετε τις "συστημικές" γραμματοσειρές όπως Arial/Calibri;**

Συνήθως όχι—είναι σχεδ Nearly always available. Wait, need Greek: "Συνήθως όχι—είναι σχεδόν πάντα διαθέσιμες. Ωστόσο, για πλήρη φορητότητα σε «λεπτά» περιβάλλοντα (Docker, ένας διακομιστής Linux χωρίς προεγκατεστημένες γραμματοσειρές), η ενσωμάτωση συστημικών γραμματοσειρών μπορεί να εξαλείψει τον κίνδυνο ανεπιθύμητων αντικαταστάσεων."

(Ensuring no extra spaces.)