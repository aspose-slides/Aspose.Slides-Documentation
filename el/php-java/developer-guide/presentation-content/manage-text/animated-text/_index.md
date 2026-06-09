---
title: Κινούμενο κείμενο PowerPoint σε PHP
linktitle: Κινούμενο κείμενο
type: docs
weight: 60
url: /el/php-java/animated-text/
keywords:
- κινούμενο κείμενο
- κίνηση κειμένου
- κινούμενη παράγραφος
- κίνηση παραγράφου
- εφέ κίνησης
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε δυναμικό κινούμενο κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for PHP via Java, με παραδείγματα κώδικα εύκολα στην κατανόηση και βελτιστοποιημένα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με κειμένο με κινούμενα σχέδια στο Aspose.Slides εφαρμόζοντας εφέ κίνησης σε μεμονωμένες παραγράφους και ανακτώντας τα εφέ που έχουν ήδη ανατεθεί σε παραγράφους σε ένα πλαίσιο κειμένου. Επικεντρώνεται στις μεθόδους API που χρησιμοποιούνται για την προσθήκη κίνησης σε επίπεδο παραγράφου και για την επιθεώρηση των υπαρχόντων εφέ κίνησης παραγράφων σε μια παρουσίαση.

## **Προσθήκη Εφέ Κίνησης σε Παραγράφους**

Προσθέσαμε τη μέθοδο [**addEffect()**](https://reference.aspose.com/slides/el/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) στην κλάση [**Sequence**](https://reference.aspose.com/slides/el/php-java/aspose.slides/Sequence). Αυτή η μέθοδος σας επιτρέπει να προσθέσετε εφέ κίνησης σε μια μεμονωμένη παράγραφο. Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε ένα εφέ κίνησης σε μια μόνο παράγραφο:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # επιλέξτε την παράγραφο για προσθήκη εφέ
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # προσθέστε εφέ κίνησης Fly στην επιλεγμένη παράγραφο
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ανάκτηση Εφέ Κίνησης Παραγράφων**

Μπορεί να θέλετε να μάθετε ποια εφέ κίνησης έχουν προστεθεί σε μια παράγραφο—για παράδειγμα, σε μια κατάσταση, ενδέχεται να θέλετε να λάβετε τα εφέ κίνησης σε μια παράγραφο επειδή σκοπεύετε να τα εφαρμόσετε σε άλλη παράγραφο ή σχήμα.

Το Aspose.Slides for PHP via Java σας επιτρέπει να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε παραγράφους που περιέχονται σε ένα πλαίσιο κειμένου (σχήμα). Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε τα εφέ κίνησης σε μια παράγραφο:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Συχνές Ερωτήσεις**

**Πώς διαφέρουν τα κινούμενα σχέδια κειμένου από τις μεταβάσεις διαφάνειας, και μπορούν να συνδυαστούν;**

Τα κινούμενα σχέδια κειμένου ελέγχουν τη συμπεριφορά του αντικειμένου με το πέρασμα του χρόνου σε μια διαφάνεια, ενώ οι [μεταβάσεις](/slides/el/php-java/slide-transition/) ελέγχουν τον τρόπο αλλαγής των διαφανειών. Είναι ανεξάρτητα και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από τη χρονοδιάγραμμα των κινήσεων και τις ρυθμίσεις των μεταβάσεων.

**Διατηρούνται τα κινούμενα σχέδια κειμένου κατά την εξαγωγή σε PDF ή εικόνες;**

Όχι. Τα PDF και οι raster εικόνες είναι στατικά, έτσι θα δείτε μια μόνο κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε εξαγωγή σε [βίντεο](/slides/el/php-java/convert-powerpoint-to-video/) ή [HTML](/slides/el/php-java/export-to-html5/).

**Λειτουργούν τα κινούμενα σχέδια κειμένου σε διατάξεις και στο κύριο πρότυπο διαφάνειας;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διατάξεων/προτύπων κληρονομούνται από τις διαφάνειες, αλλά ο χρόνος τους και η αλληλεπίδρασή τους με τα εφέ διαφάνειας εξαρτώνται από την τελική ακολουθία στη διαφάνεια.