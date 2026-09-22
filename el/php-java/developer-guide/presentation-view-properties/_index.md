---
title: Retrieve and Update Presentation View Properties in PHP
linktitle: View Properties
type: docs
weight: 80
url: /el/php-java/presentation-view-properties/
keywords:
- view properties
- normal view
- outline content
- outline icons
- snap vertical splitter
- single view
- bar state
- dimension size
- auto adjust
- default zoom
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για PHP μέσω Java τις ιδιότητες προβολής για να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — ρυθμίστε τις διατάξεις, τα επίπεδα ζουμ και τις ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια την ίδια, μια πλαϊνή περιοχή περιεχομένου και μια κατώτερη περιοχή περιεχομένου. Ιδιότητες που αφορούν τη τοποθέτηση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης. 

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties) και οι απογόνους τους, η αρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με το INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) καθορίζουν εάν η εφαρμογή θα πρέπει να εμφανίζει εικονίδια όταν εμφανίζει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) καθορίζουν εάν ο κάθετος διαχωριστής θα πρέπει να κλειδώνει σε κατάσταση ελαχιστοποίησης όταν η πλαϊνή περιοχή είναι επαρκώς μικρή.

Οι ιδιότητες [getPreferSingleView](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) και [setPreferSingleView](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) καθορίζουν εάν ο χρήστης προτιμά να βλέπει μια πλήρη περιοχή περιεχομένου σε ολόκληρο το παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν είναι ενεργοποιημένη, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) καθορίζουν την κατάσταση στην οποία θα πρέπει να εμφανίζεται η οριζόντια ή κάθετη μπάρα διαχωρισμού. Μία οριζόντια μπάρα διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη μπάρα διαχωρισμού χωρίζει τη διαφάνεια από την πλαϊνή περιοχή περιεχομένου. Οι δυνατές τιμές είναι: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Maximized), και [SplitterBarStateType::Restored](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) και [getRestoredTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties#getRestoredTop) καθορίζουν το μέγεθος της επάνω ή πλαϊνής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType::Restored](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Restored) εφαρμόζεται για [getVerticalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) αντίστοιχα.

## **Σχετικά με την Επαναφορά του INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του [getRestoredTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), ύψος όταν είναι θυγατρική του [getRestoredLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγιστοποιημένο). 

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του restoredTop, ύψος όταν είναι θυγατρική του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) καθορίζει εάν το μέγεθος της πλαϊνής περιοχής περιεχομένου θα πρέπει να προσαρμόζεται στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) για μια παρουσίαση.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Ορισμός της Προεπιλεγμένης Τιμής Ζουμ**
{{% alert color="info" %}} 

Το Aspose.Slides για PHP μέσω Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, έτσι ώστε όταν η παρουσίαση ανοίγει, το ζουμ να είναι ήδη ρυθμισμένο. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) καθώς και [getNotesViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) στο Aspose.Slides.

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.   Στο παρακάτω παράδειγμα, έχουμε ορίσει την τιμή ζουμ για την προβολή διαφάνειας καθώς και την προβολή σημειώσεων.

```php
  $presentation = new Presentation();
  try {
    # Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ορισμός της Απόστασης Πλέγματος**

Χρησιμοποιήστε το [Presentation::getViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getViewProperties) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Οι μέθοδοι [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/#getGridSpacing) και [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/#setGridSpacing) διαβάζουν ή τροποποιούν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση ισχύει για ολόκληρη την παρουσίαση, όχι για μεμονωμένη διαφάνεια. Η απόσταση πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με μία ίντσα. Χρησιμοποιήστε μια θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει την τρέχουσα απόσταση πλέγματος, ορίζει ένα διάστημα τέταρτης ίντσας και αποθηκεύει το αποτέλεσμα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/php-java/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα κανονικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι ατομικά τοποθετημένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, η μετακίνηση ή η διαγραφή των οδηγιών σχεδίασης δεν αλλάζει την απόσταση πλέγματος.

Το πλέγμα και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προγράμματος προβολής ή επεξεργαστή.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Γιατί δεν είναι ορατό το πλέγμα μετά το άνοιγμα ξανά της παρουσίασης;**

Το αρχείο αποθηκεύει την απόσταση πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η διαγραφή των οδηγών σχεδίασης την απόσταση πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η διαγραφή των οδηγιών αφήνει το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getviewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/getslideviewproperties/)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων ισχύει για ολόκληρο το έγγραφο κατά το άνοιγμά του.

**Μπορώ να προορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προ‑ορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getviewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.