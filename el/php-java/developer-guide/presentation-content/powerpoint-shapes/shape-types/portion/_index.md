---
title: Διαχείριση Τεμαχίων Κειμένου σε Παρουσιάσεις με PHP
linktitle: Τμήμα Κειμένου
type: docs
weight: 70
url: /el/php-java/portion/
keywords:
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τμήματα κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java, βελτιώνοντας την απόδοση και την προσαρμοστικότητα."
---
## **Εισαγωγή**

Μια τελεία κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργάζεστε με αυτό το απόσπασμα ανεξάρτητα από το περιβάλλον περιεχόμενο. Στο Aspose.Slides, τα portions μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τη θέση ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερή επίπεδο.

## **Λήψη Συντεταγμένων μιας Τελείας Κειμένου**
[**getCoordinates()**](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/getcoordinates/) μέθοδος προστέθηκε στην κλάση [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) που επιτρέπει την ανάκτηση των συντεταγμένων της αρχής της τελείας.

```php
  # Δημιουργία κλάσης Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Αναδιαμόρφωση του πλαισίου της παρουσίασης
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω έναν υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία ενιαία παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/php-java/manage-hyperlinks/) σε μια μεμονωμένη τελεία· μόνο εκείνο το απόσπασμα θα είναι κλικαρίσιμο, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι παρακάμπτει μια τελεία και τι λαμβάνεται από την Παράγραφο/Πλαίσιο Κειμένου;**

Οι ιδιότητες σε επίπεδο τελείας έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν έχει οριστεί στην [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/), η μηχανή την λαμβάνει από την [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/); εάν δεν έχει οριστεί ούτε εκεί, από το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) ή το στυλ του [theme](https://reference.aspose.com/slides/el/php-java/aspose.slides/theme/).

**Τι συμβαίνει εάν η γραμματοσειρά που καθορίζεται για μια τελεία λείπει στο μηχάνημα/διακομιστή στόχο;**

[Οι κανόνες αντικατάστασης γραμματοσειρών](/slides/el/php-java/font-selection-sequence/) εφαρμόζονται. Το κείμενο μπορεί να ρέει ξανά: οι μετρήσεις, η μορφοποίηση και το πλάτος μπορεί να αλλάξουν, κάτι που μετράει για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδική για μια τελεία, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια στο επίπεδο της [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά αποσπάσματα.