---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε PHP
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/php-java/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- προσκόλληση κάθετου διαχωριστή
- μονή προβολή
- κατάσταση μπάρας
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για PHP μέσω Java για να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθαυτή, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση της προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties) και οι απογόνους τους, καθώς και η καταμέτρηση [SplitterBarStateType](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType) έχουν προστεθεί.

## **Σχετικά με το INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) καθορίζουν αν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει το περιεχόμενο περίγραμμα σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) καθορίζουν αν ο κάθετος διαχωριστής θα κολλήσει σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι επαρκώς μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) και [setPreferSingleView](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) καθορίζουν αν ο χρήστης προτιμά να δει μια περιοχή περιεχομένου πλήρους παραθύρου αντί της τυπικής κανονικής προβολής με τρεις περιοχές. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να εμφανίσει μία από τις περιοχές σε ολόκληρο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η οριζόντια ή κάθετη μπάρα διαχωριστή. Μία οριζόντια μπάρα διαχωριστή χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από αυτή, μία κάθετη μπάρα χωρίζει τη διαφάνεια από την πλευρική περιοχή. Πιθανές τιμές είναι: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Maximized) και [SplitterBarStateType::Restored](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) και [getRestoredTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties#getRestoredTop) καθορίζουν το μέγεθος της άνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType::Restored](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Restored) εφαρμόζεται στα [getVerticalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) αντίστοιχα.

## **Σχετικά με την αποκατάσταση του INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) στην κανονική προβολή, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγιστοποιημένο).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου θα προσαρμόζεται αυτόματα στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει τη προβολή στην εφαρμογή.

Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να έχετε πρόσβαση στις ιδιότητες [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) για μια παρουσίαση.

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

## **Ορισμός της προεπιλεγμένης τιμής ζουμ**
{{% alert color="primary" %}} 

Το Aspose.Slides για PHP μέσω Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίγει, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τα [ViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) μιας παρουσίασης. Οι [getSlideViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) καθώς και [getNotesViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) του [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) στο [Aspose.Slides](/slides/el/).

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντί instance της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) . Στο παρακάτω παράδειγμα, έχουμε ορίσει την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

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

## **Συχνές ερωτήσεις**

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getviewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/getslideviewproperties/)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να ορίσω εκ των προτέρων διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προ-ορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getviewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.