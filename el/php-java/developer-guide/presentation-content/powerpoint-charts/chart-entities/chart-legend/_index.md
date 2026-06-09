---
title: Προσαρμογή υπομνημάτων διαγραμμάτων σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Υπόμνημα Διαγράμματος
type: docs
url: /el/php-java/chart-legend/
keywords:
- υπόμνημα διαγράμματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσαρμόστε τα υπόμνηματα διαγραμμάτων με το Aspose.Slides για PHP μέσω Java για βελτιστοποίηση των παρουσιάσεων PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει επιλογές για προσαρμογή των υπομνημάτων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ορίσετε το μέγεθος ενός υπομνήματος, να θέσετε το μέγεθος γραμματοσειράς για ολόκληρο το υπόμνημα και να εφαρμόσετε μορφοποίηση σε μια μεμονωμένη καταχώριση του υπομνήματος.

Επίσης καλύπτει διάφορες σχετικές συμπεριφορές στη Συχνές Ερωτήσεις, συμπεριλαμβανομένης της χρήσης μη‑επικάλυψης ώστε η περιοχή σχεδίασης να κάνει χώρο για το υπόμνημα, της δυνατότητας τα μακριά ετικέτες υπομνήματος να αναδιπλώνονται ή να χρησιμοποιούν αλλαγές γραμμής, και του να αφήνεται η μορφοποίηση του υπομνήματος να κληρονομείται από το θέμα της παρουσίασης όταν δεν έχουν οριστεί ρητά ρυθμίσεις κειμένου και γεμίσματος.

## **Τοποθέτηση Υπόμνηματος**
Για να ορίσετε τις ιδιότητες του υπόμνηματος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) .
- Λάβετε αναφορά στη διαφάνεια.
- Προσθήκη διαγράμματος στη διαφάνεια.
- Ορισμός των ιδιοτήτων του υπόμνηματος.
- Αποθήκευση της παρουσίασης ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τη θέση και το μέγεθος του υπομνήματος διαγράμματος.

```php
  # Δημιουργία μιας στιγμής της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Λήψη αναφοράς στη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη συγκροτημένου στηλοδιαγράμματος στη διαφάνεια
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Ορισμός ιδιοτήτων υπομνήματος
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Αποθήκευση παρουσίασης στο δίσκο
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπόμνηματος**
Το Aspose.Slides for PHP via Java επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς του υπομνήματος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) .
- Δημιουργία προεπιλεγμένου διαγράμματος.
- Ορισμός του μεγέθους γραμματοσειράς.
- Ορισμός ελάχιστης τιμής άξονα.
- Ορισμός μέγιστης τιμής άξονα.
- Αποθήκευση παρουσίασης στο δίσκο.

```php
  # Δημιουργία μιας στιγμής της κλάσης Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μεμονωμένου Υπόμνηματος**
Το Aspose.Slides for PHP via Java επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς μεμονωμένων καταχωρίσεων υπομνήματος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) .
- Δημιουργία προεπιλεγμένου διαγράμματος.
- Πρόσβαση στην καταχώριση του υπομνήματος.
- Ορισμός του μεγέθους γραμματοσειράς.
- Ορισμός ελάχιστης τιμής άξονα.
- Ορισμός μέγιστης τιμής άξονα.
- Αποθήκευση παρουσίασης στο δίσκο.

```php
  # Δημιουργία μιας στιγμής της κλάσης Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω το υπόμνημα ώστε το γράφημα να κατανείμει αυτόματα χώρο για αυτό αντί να το επικαλύπτει;**

Ναι. Χρησιμοποιήστε τη λειτουργία μη‑επικάλυψης ([setOverlay(false)](https://reference.aspose.com/slides/el/php-java/aspose.slides/legend/setoverlay/)); σε αυτήν την περίπτωση η περιοχή σχεδίασης θα μειωθεί για να φιλοξενήσει το υπόμνημα.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος με πολλές γραμμές;**

Ναι. Οι μακρές ετικέτες αναδιπλώνονται αυτόματα όταν δεν υπάρχει αρκετός χώρος· υποστηρίζονται υποχρεωτικές αλλαγές γραμμής μέσω χαρακτήρων νέας γραμμής στο όνομα σειράς.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Μην ορίζετε ρητά χρώματα/γεμίσματα/γραμματοσειρές για το υπόμνημα ή το κείμενό του. Θα κληρονομήσουν το χρώμα από το θέμα και θα ενημερώνονται σωστά όταν αλλάξει ο σχεδιασμός.