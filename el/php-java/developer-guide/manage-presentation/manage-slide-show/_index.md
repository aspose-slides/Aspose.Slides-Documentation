---
title: Διαχείριση Παρουσίασης Διαφανειών σε PHP
linktitle: Παρουσίαση Διαφανειών
type: docs
weight: 90
url: /el/php-java/manage-slide-show/
keywords:
- τύπος παρουσίασης
- παρουσιάζεται από ομιλητή
- προβολή από άτομο
- προβολή σε περίπτερο
- επιλογές παρουσίασης
- συνεχής επανάληψη
- παρουσίαση χωρίς αφήγηση
- παρουσίαση χωρίς κίνηση
- χρώμα στυλό
- εμφάνιση διαφανειών
- προσαρμοσμένη παρουσίαση
- προώθηση διαφανειών
- χειροκίνητα
- χρήση χρονισμών
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις παρουσιάσεις διαφανειών στο Aspose.Slides για PHP μέσω Java. Ελέγξτε τις μεταβάσεις διαφανειών, τους χρονισμούς και άλλα σε μορφές PPT, PPTX και ODP με ευκολία."
---
## **Εισαγωγή**

Στο Microsoft PowerPoint, οι ρυθμίσεις **Slide Show** είναι ένα βασικό εργαλείο για την προετοιμασία και παρουσίαση επαγγελματικών παρουσιάσεων. Ένα από τα πιο σημαντικά χαρακτηριστικά σε αυτήν την ενότητα είναι το **Set Up Show**, το οποίο σας επιτρέπει να προσαρμόζετε την παρουσίασή σας σε συγκεκριμένες συνθήκες και κοινά, εξασφαλίζοντας ευελιξία και άνεση. Με αυτήν τη λειτουργία, μπορείτε να επιλέξετε τον τύπο της προβολής (π.χ., παρουσιάζεται από ομιλητή, προβολή από άτομο ή προβολή σε περίπτερο), να ενεργοποιήσετε ή να απενεργοποιήσετε την επανάληψη, να επιλέξετε συγκεκριμένες διαφάνειες για προβολή και να χρησιμοποιήσετε χρονισμούς. Αυτό το βήμα στην προετοιμασία είναι κρίσιμο για να κάνετε την παρουσίασή σας πιο αποτελεσματική και επαγγελματική.

`getSlideShowSettings` είναι μια μέθοδος της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που επιστρέφει ένα αντικείμενο τύπου [SlideShowSettings](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowsettings/), το οποίο σας επιτρέπει να διαχειρίζεστε τις ρυθμίσεις του slide show σε μια παρουσίαση PowerPoint. Σε αυτό το άρθρο, θα εξερευνήσουμε πώς να χρησιμοποιήσετε αυτή τη μέθοδο για να διαμορφώσετε και να ελέγξετε διάφορες πτυχές των ρυθμίσεων του slide show. 

## **Επιλογή Τύπου Προβολής**

`SlideShowSettings->setSlideShowType` ορίζει τον τύπο του slide show, ο οποίος μπορεί να είναι μια παρουσίαση των ακόλουθων κλάσεων: [PresentedBySpeaker](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/el/php-java/aspose.slides/browsedbyindividual/), ή [BrowsedAtKiosk](https://reference.aspose.com/slides/el/php-java/aspose.slides/browsedatkiosk/). Η χρήση αυτής της μεθόδου σας επιτρέπει να προσαρμόζετε την παρουσίαση για διαφορετικά σενάρια χρήσης, όπως αυτοματοποιημένα περίπτερα ή χειροκίνητες παρουσιάσεις.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει τον τύπο προβολής σε «Browsed by an individual» χωρίς να εμφανίζει τη γραμμή κύλισης.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ενεργοποίηση Επιλογών Προβολής**

`SlideShowSettings->setLoop` καθορίζει εάν το slide show πρέπει να επαναλαμβάνεται σε βρόχο μέχρι να διακοπεί χειροκίνητα. Αυτό είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που χρειάζεται να τρέχουν συνεχώς. `SlideShowSettings->setShowNarration` καθορίζει εάν θα παίξουν φωνητικά αφήγημα κατά τη διάρκεια του slide show. Είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που περιέχουν φωνητικές οδηγίες για το κοινό. `SlideShowSettings->setShowAnimation` καθορίζει εάν θα παιχτούν οι κινούμενες εικόνες που προστέθηκαν σε αντικείμενα διαφάνειας. Αυτό είναι χρήσιμο για την πλήρη οπτική επίδραση της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και κάνει το slide show να επαναλαμβάνεται σε βρόχο.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Επιλογή Διαφανειών για Εμφάνιση**

Η μέθοδος `SlideShowSettings->setSlides` σας επιτρέπει να επιλέξετε μια σειρά διαφανειών που θα προβάλλονται κατά τη διάρκεια της παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να εμφανίσετε μόνο μέρος της παρουσίασης αντί για όλες τις διαφάνειες. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει το εύρος διαφανειών που θα εμφανιστούν από τις διαφάνειες `2` έως `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Χρήση Προώθησης Διαφανειών**

Η μέθοδος `SlideShowSettings->setUseTimings` σας επιτρέπει να ενεργοποιήσετε ή να απενεργοποιήσετε τη χρήση προρυθμιζόμενων χρονισμών για κάθε διαφάνεια. Αυτό είναι χρήσιμο για αυτόματη προβολή διαφανειών με προκαθορισμένες διάρκειες προβολής. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και απενεργοποιεί τη χρήση χρονισμών.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Εμφάνιση Πλήκτρων Πολυμέσων**

Η μέθοδος `SlideShowSettings->setShowMediaControls` καθορίζει εάν τα στοιχεία ελέγχου πολυμέσων (όπως αναπαραγωγή, παύση και τερματισμός) θα εμφανίζονται κατά τη διάρκεια του slide show όταν αναπαράγεται πολυμεσικό περιεχόμενο (π.χ., βίντεο ή ήχος). Αυτό είναι χρήσιμο όταν θέλετε να δώσετε στον παρουσιάστη τον έλεγχο της αναπαραγωγής πολυμέσων κατά τη διάρκεια της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ενεργοποιεί την εμφάνιση των στοιχείων ελέγχου πολυμέσων.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αποθηκεύσω μια παρουσίαση ώστε να ανοίγει απευθείας σε λειτουργία slide show;**

Ναι. Αποθηκεύστε το αρχείο ως PPSX ή PPSM· αυτές οι μορφές εκτελούν άμεσα το slide show όταν ανοιχτούν στο PowerPoint. Στο Aspose.Slides, επιλέξτε τη σχετική μορφή αποθήκευσης [during export](/slides/el/php-java/save-presentation/).

**Μπορώ να εξαιρέσω μεμονωμένες διαφάνειες από το show χωρίς να τις διαγράψω από το αρχείο;**

Ναί. Σήμεινε μια διαφάνεια ως [hidden](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/sethidden/). Οι κρυμμένες διαφάνειες παραμένουν στην παρουσίαση αλλά δεν εμφανίζονται κατά τη διάρκεια του slide show.

**Μπορεί το Aspose.Slides να αναπαράγει ένα slide show ή να ελέγξει μια ζωντανή παρουσίαση στην οθόνη;**

Όχι. Το Aspose.Slides επεξεργάζεται, αναλύει και μετατρέπει αρχεία παρουσίασης· η πραγματική αναπαραγωγή γίνεται από μια εφαρμογή προβολής όπως το PowerPoint.