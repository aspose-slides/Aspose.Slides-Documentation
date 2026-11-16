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
- κατακόρυφο διαχωριστικό snap
- μονοπρόβολη
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένη μεγέθυνση
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για PHP μέσω Java για να διαμορφώσετε τη διάταξη της κανονικής προβολής, τη μεγέθυνση διαφάνειας και σημειώσεων, το διάστημα του πλέγματος και την ορατότητα σχολίων σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Στην κανονική προβολή του PowerPoint, η διαφάνεια εμφανίζεται μεταξύ ενός πλευρικού πλαισίου για μικρογραφίες ή περίγραμμα και ενός πάνελ σημειώσεων από κάτω. Το Aspose.Slides για PHP μέσω Java εκθέτει τις αποθηκευμένες προτιμήσεις επεξεργασίας της παρουσίασης μέσω [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Αυτά περιλαμβάνουν τη διάταξη των πλαισίων, τα επίπεδα μεγέθυνσης, το διάστημα του πλέγματος και την ορατότητα σχολίων.

## **Σχετικά με NormalViewProperties**

Χρησιμοποιήστε το [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) για πρόσβαση στην κλάση [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). Το [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) ελέγχει αν εμφανίζονται εικονίδια δίπλα στους τίτλους των διαφανειών στο περίγραμμα. Το [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) επιτρέπει στο πλευρικό πλαίσιο να «κολλήσει» στην ελαχιστοποιημένη του κατάσταση όταν ο χρήστης το συρρικνώνει. Το [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) υποδεικνύει προτίμηση για εμφάνιση ενός μόνο πλαισίου σε όλο το παράθυρο.

Το [setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) ελέγχει το διαχωριστικό μεταξύ του πλευρικού πλαισίου και της διαφάνειας. Το [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) ελέγχει το διαχωριστικό πάνω από το πάνελ σημειώσεων. Και τα δύο δέχονται μία τιμή τύπου [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) – `Minimized`, `Maximized` ή `Restored`.

## **Σχετικά με την Επαναφορά NormalViewProperties**

Όταν ένα διαχωριστικό επανέλθει στην αρχική του θέση, το [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) παρέχει το αποθηκευμένο μέγεθος του πλευρικού πλαισίου και το [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) παρέχει το αποθηκευμένο μέγεθος της άνω περιοχής της διαφάνειας. Και τα δύο εκθέτουν το [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Η μέθοδος [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) δέχεται ποσοστό από 0 μέχρι 100, και το [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) ελέγχει αν ο επεξεργαστής προσαρμόζει το μέγεθος όταν το παράθυρο αλλάζει διαστάσεις.

Αυτό το παράδειγμα ενημερώνει μια υπάρχουσα παρουσίαση. Επαναφέρει το οριζόντιο διαχωριστικό, ορίζει το μέγεθος που επιστρέφεται από το [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) στο 80 % με ενεργοποιημένη την αυτόματη προσαρμογή και μεγιστοποιεί το κάθετο διαχωριστικό. Καλεί επίσης το [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) για να εμφανίσει εικονίδια στην προβολή περιγράμματος.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός της προεπιλεγμένης τιμής μεγέθυνσης**

Τα [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) και [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) αποθηκεύουν ανεξάρτητες ρυθμίσεις μεγέθυνσης για τον επεξεργαστή. Αυτές οι ρυθμίσεις δεν επηρεάζουν τις διαστάσεις της διαφάνειας, την αναπαραγωγή παρουσίασης ή την ανάλυση εξαγόμενων εικόνων.

Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί το [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) για να ταιριάξει η διαφάνεια με το παράθυρο επεξεργασίας. Για τη σελίδα σημειώσεων, απενεργοποιεί την αυτόματη κλίμακα και καλεί το [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) για να θέσει σταθερό ζουμ 80 %.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός του διαστήματος πλέγματος**

Η μέθοδος `setGridSpacing` της κλάσης [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) ορίζει την απόσταση μεταξύ των γραμμών του πλέγματος επεξεργασίας σε όλη την παρουσίαση. Δέχεται θετική τιμή σε σημεία, με 72 σημεία ανά ίντσα. Αυτό το παράδειγμα εκτυπώνει το τρέχον διάστημα σε μια υπάρχουσα παρουσίαση και αποθηκεύει ένα πλέγμα τέταρτου ίντσας ορίζοντας το διάστημα στα 18 σημεία.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το πλέγμα επαναλαμβάνεται σε σταθερό διάστημα. Οι [Οδηγοί σχεδίασης](/slides/el/php-java/drawing-guides/) σημειώνουν μεμονωμένες οριζόντιες ή κάθετες θέσεις. Και οι δύο χρησιμεύουν ως βοήθημα επεξεργασίας και εμφανίζονται μόνο σε επεξεργαστές που τα εμφανίζουν. Οι παρουσιάσεις και οι εξαγωγές σε PDF, εικόνες ή SVG τα παραλείπουν.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Η μέθοδος [setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) αποθηκεύει μια προτίμηση που χρησιμοποιούν οι συμβατοί επεξεργαστές κατά το άνοιγμα της παρουσίασης. Για μια υπάρχουσα παρουσίαση με σχόλια, αυτό το παράδειγμα εκτυπώνει τη τρέχουσα ρύθμιση και αποθηκεύει ένα αντίγραφο με κρυμμένα σχόλια. Καλεί επίσης το [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) με το [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) ώστε το αντίγραφο να ανοίξει στην προβολή διαφάνειας.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η απόκρυψη σχολίων διατηρεί το κείμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Για αλλαγή των σχολίων καθαυτών, δείτε το [Σχόλια Παρουσίασης](/slides/el/php-java/presentation-comments/). Οι ρυθμίσεις εξαγωγής ελέγχουν αν τα σχόλια εμφανίζονται σε PDF, HTML, εικόνες, σημειώσεις ή φυλλάδια.

## **Συχνές Ερωτήσεις**

**Γιατί το πλέγμα είναι κρυφό όταν ανοίγω ξανά την παρουσίαση;**

Η παρουσίαση αποθηκεύει το διάστημα του πλέγματος. Για να δείτε το πλέγμα, ενεργοποιήστε την ορατότητά του στον επεξεργαστή.

**Αλλάζει το καθάρισμα των οδηγών σχεδίασης το διάστημα του πλέγματος;**

Όχι. Η προσθήκη, η μετακίνηση ή η διαγραφή ενός οδηγού δεν αλλάζει το διάστημα του πλέγματος.

**Μπορούν διαφορετικές ενότητες μιας παρουσίασης να έχουν διαφορετικές ρυθμίσεις προβολής;**

Όχι. Το [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) ισχύει για ολόκληρη την παρουσίαση.

**Μπορώ να αποθηκεύσω διαφορετικές ρυθμίσεις προβολής για διαφορετικούς χρήστες;**

Το αρχείο αποθηκεύει ένα σύνολο ιδιοτήτων προβολής για όλους. Ένας επεξεργαστής μπορεί επίσης να εφαρμόσει τις τοπικές προτιμήσεις του χρήστη.

**Μπορώ να αποθηκεύσω ρυθμίσεις προβολής σε πρότυπο;**

Ναι. Οι παρουσιάσεις που δημιουργούνται από το πρότυπο κληρονομούν τις αποθηκευμένες ρυθμίσεις προβολής του.