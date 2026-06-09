---
title: Σχήματα Ομάδας Παρουσίασης σε PHP
linktitle: Ομάδα Σχημάτων
type: docs
weight: 40
url: /el/php-java/group/
keywords:
- ομάδα σχήματος
- ομάδα σχημάτων
- προσθήκη ομάδας
- εναλλακτικό κείμενο
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ομαδοποιείτε και να απομαδοποιείτε σχήματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java — γρήγορος, βήμα-βήμα οδηγός με δωρεάν κώδικα."
---
## **Επισκόπηση**

Το άρθρο αυτό εξηγεί πώς να εργάζεστε με ομάδες σχημάτων στο Aspose.Slides. Δείχνει πώς να προσθέσετε μια ομάδα σχήματος σε μια διαφάνεια, να τοποθετήσετε σχήματα μέσα σε αυτήν και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης, παρουσιάζει πώς να έχετε πρόσβαση στα σχήματα που αποθηκεύονται μέσα σε μια ομάδα και να διαβάσετε τις τιμές `AlternativeText` τους. Επιπλέον, το άρθρο αναφέρει εν συντομή σχετικές δυνατότητες ομάδας σχημάτων όπως ένθετες ομάδες, σειρά z και επιλογές κλειδώματος.

## **Προσθήκη ομάδας σχήματος**
Το Aspose.Slides υποστηρίζει τη χρήση ομάδων σχημάτων στις διαφάνειες. Αυτή η δυνατότητα βοηθά τους προγραμματιστές να δημιουργούν πιο πλούσιες παρουσιάσεις. Το Aspose.Slides for PHP via Java υποστηρίζει την προσθήκη ή την πρόσβαση σε ομάδες σχημάτων. Είναι δυνατόν να προσθέτετε σχήματα σε μια προστιθέμενη ομάδα σχήματος για να την γεμίσετε ή να προσπελάσετε οποιαδήποτε ιδιότητα της ομάδας σχήματος. Για να προσθέσετε μια ομάδα σχήματος σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for PHP via Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. Προσθέστε μια ομάδα σχήματος στη διαφάνεια.
1. Προσθέστε τα σχήματα στην προστιθέμενη ομάδα σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει μια ομάδα σχήματος σε μια διαφάνεια.

```php
  # Δημιουργία αντικειμένου Presentation
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Πρόσβαση στη συλλογή σχημάτων των διαφανειών
    $slideShapes = $sld->getShapes();
    # Προσθήκη ομάδας σχήματος στη διαφάνεια
    $groupShape = $slideShapes->addGroupShape();
    # Προσθήκη σχημάτων εντός της προστιθέμενης ομάδας σχήματος
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Προσθήκη πλαισίου ομάδας σχήματος
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Αποθήκευση του αρχείου PPTX στο δίσκο
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Πρόσβαση στην ιδιότητα AltText**
Αυτό το θέμα παρουσιάζει απλά βήματα, συνοδευόμενα από παραδείγματα κώδικα, για την προσθήκη μιας ομάδας σχήματος και την πρόσβαση στην ιδιότητα AltText των ομάδων σχημάτων σε διαφάνειες. Για να προσπελάσετε το AltText μιας ομάδας σχήματος σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for PHP via Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που αντιπροσωπεύει το αρχείο PPTX.
1. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. Πρόσβαση στη συλλογή σχημάτων των διαφανειών.
1. Πρόσβαση στην ομάδα σχήματος.
1. Πρόσβαση στην ιδιότητα [Alternative Text](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getAlternativeText).

Το παρακάτω παράδειγμα προσπελαύνει το εναλλακτικό κείμενο της ομάδας σχήματος.

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Πρόσβαση στη συλλογή σχημάτων των διαφανειών
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Πρόσβαση στην ομάδα σχήματος.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Πρόσβαση στην ιδιότητα AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Υποστηρίζεται η ένθετη ομαδοποίηση (μια ομάδα μέσα σε άλλη ομάδα);**

Ναι. Η κλάση [GroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/groupshape/) διαθέτει τη μέθοδο [getParentGroup](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getparentgroup/), η οποία υποδεικνύει άμεσα την υποστήριξη ιεραρχίας (μια ομάδα μπορεί να είναι θυγατρική άλλης ομάδας).

**Πώς ελέγχω τη σειρά z της ομάδας σχετικά με άλλα αντικείμενα στη διαφάνεια;**

Χρησιμοποιήστε τη μέθοδο [getZOrderPosition](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getzorderposition/) της κλάσης [GroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/groupshape/) για να ελέγξετε τη θέση της στην στοίβα εμφάνισης.

**Μπορώ να εμποδίσω τη μετακίνηση/επεξεργασία/αποομάδωση;**

Ναί. Η ενότητα κλειδώματος της ομάδας εκτίθεται μέσω της κλάσης [GroupShapeLock](https://reference.aspose.com/slides/el/php-java/aspose.slides/groupshape/getgroupshapelock/), η οποία σας επιτρέπει να περιορίσετε τις ενέργειες πάνω στο αντικείμενο.