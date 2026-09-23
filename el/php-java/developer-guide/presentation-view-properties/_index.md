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
- σύρσιμο κατακόρυφου διαχωριστή
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για PHP μέσω Java για ιδιότητες προβολής, ώστε να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: την ίδια τη διαφάνεια, μια πλευρική περιοχή περιεχομένου και μια κατώτερη περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, ώστε όταν ξανανοίξει η προβολή να βρίσκεται στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες κανονικής προβολής της παρουσίασης. 

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties) και οι απογόνους τους, καθώς και η απαράμετρος [SplitterBarStateType](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) καθορίζουν εάν η εφαρμογή θα εμφανίζει εικονίδια όταν προβάλλεται περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) καθορίζουν εάν ο κατακόρυφος διαχωριστής πρέπει να «πιάσει» σε κατάσταση ελαχιστοποιημένου όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) και [setPreferSingleView](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) καθορίζει εάν ο χρήστης προτιμά να δει μια μονή περιοχή περιεχομένου σε πλήρες παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η οριζόντια ή κατακόρυφη γραμμή διαχωριστή. Μια οριζόντια γραμμή διαχωριστή χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνειά της, ενώ η κατακόρυφη χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Maximized) και [SplitterBarStateType::Restored](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) και [getRestoredTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties#getRestoredTop) καθορίζουν το μέγεθος της άνω ή πλευρικής περιοχής της διαφάνειας στην κανονική προβολή, όταν η τιμή [SplitterBarStateType::Restored](https://reference.aspose.com/slides/el/php-java/aspose.slides/SplitterBarStateType/#Restored) εφαρμόζεται στις [getVerticalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) αντίστοιχα.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι θυγατρική του [getRestoredTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), ύψος όταν είναι θυγατρική του [getRestoredLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) στην κανονική προβολή, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγιστοποιημένο). 

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι θυγατρική του restoredTop, ύψος όταν είναι θυγατρική του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμοστεί στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή εντός της εφαρμογής.

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

Aspose.Slides για PHP μέσω Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίξει, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας το [ViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) καθώς και τα [getNotesViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) στο Aspose.Slides.

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/php-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX ](https://docs.fileformat.com/presentation/pptx/)file. Στο παρακάτω παράδειγμα, έχουμε ορίσει την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```php
  $presentation = new Presentation();
  try {
    # Καθορισμός των ιδιοτήτων προβολής της παρουσίασης
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ορισμός της Απόστασης Πλέγματος**

Χρησιμοποιήστε το [Presentation::getViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getViewProperties) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Οι μέθοδοι [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/#getGridSpacing) και [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/#setGridSpacing) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση ισχύει για ολόκληρη την παρουσίαση, όχι για μεμονωμένη διαφάνεια. Η απόσταση πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισούνται με ένα ίντσα. Χρησιμοποιήστε μια θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει την τρέχουσα απόσταση πλέγματος, ορίζει ένα διάστημα τέταρτου ίντσας και αποθηκεύει το αποτέλεσμα.

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

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/php-java/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι μεμονωμένες οριζόντιες ή κατακόρυφες γραμμές ευθυγράμμισης. Η προσθήκη, η μετακίνηση ή η εκκαθάριση των οδηγιών σχεδίασης δεν αλλάζει την απόσταση πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητα του εξαρτάται επίσης από τις προτιμήσεις του προβολέα ή του επεξεργαστή.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Χρησιμοποιήστε το [Presentation::getViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getviewproperties/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Χρησιμοποιήστε τα [ViewProperties::getShowComments](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/getshowcomments/) και [ViewProperties::setShowComments](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/setshowcomments/) για να διαβάσετε ή να αλλάξετε την αποθηκευμένη προτίμηση για το αν τα σχόλια πρέπει να εμφανίζονται όταν η παρουσίαση ανοίξει στο PowerPoint ή σε άλλο συμβατό πρόγραμμα.

Αυτή η ρύθμιση ελέγχει μόνο την αποθηκευμένη προτίμηση προβολής. Δεν προσθέτει, αφαιρεί, επεξεργάζεται ή επιλύει σχόλια. Η απόκρυψη σχολίων διατηρεί το περιεχόμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Δείτε τα [Presentation Comments](/slides/el/php-java/presentation-comments/) για ενέργειες που αλλάζουν τα ίδια τα σχόλια.

Το παρακάτω παράδειγμα απαιτεί ένα υπάρχον `comments.pptx` που περιέχει σχόλια. Εκτυπώνει την τρέχουσα ρύθμιση ορατότητας, ζητά την απόκρυψη των σχολίων και αποθηκεύει ένα νέο PPTX χωρίς να αφαιρέσει κανένα σχόλιο. Χρησιμοποιεί επίσης το [ViewProperties::setLastView](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/setlastview/) μαζί με το [ViewType::SlideView](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewtype/#SlideView) για να διαμορφώσει την αρχική προβολή επεξεργασίας μαζί με την ορατότητα των σχολίων.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αυτή η ρύθμιση δεν προσδιορίζει εάν τα σχόλια θα περιλαμβάνονται στις εξαγωγές PDF, HTML, εικόνας, σημειώσεων ή φυλλαδίων. Διαμορφώστε τις σχετικές επιλογές εξαγωγής ξεχωριστά.

## **FAQ**

**Γιατί το πλέγμα δεν είναι ορατό μετά το ξανά άνοιγμα της παρουσίασης;**

Το αρχείο αποθηκεύει την απόσταση του πλέγματος, αλλά ο επεξεργαστής ελέγχει εάν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αν αφαιρέσω τις οδηγίες σχεδίασης, αλλάζει η απόσταση του πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η εκκαθάριση των οδηγών κρατά το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [View settings](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getviewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/getslideviewproperties/)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προ-ορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι προγράμματα προβολής μπορούν να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προ-ορισμένες ιδιότητες προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [view properties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getviewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.