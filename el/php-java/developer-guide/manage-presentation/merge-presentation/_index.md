---
title: Αποδοτική Συγχώνευση Παρουσιάσεων με PHP
linktitle: Συγχώνευση Παρουσιάσεων
type: docs
weight: 40
url: /el/php-java/merge-presentation/
keywords:
- συγχώνευση PowerPoint
- συγχώνευση παρουσιάσεων
- συγχώνευση διαφανειών
- συγχώνευση PPT
- συγχώνευση PPTX
- συγχώνευση ODP
- συνένωση PowerPoint
- συνένωση παρουσιάσεων
- συνένωση διαφανειών
- συνένωση PPT
- συνένωση PPTX
- συνένωση ODP
- PHP
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε PHP κλαπώνοντας διαφάνειες, ελέγχοντας κυρίους και διατάξεις, αλλάζοντας το μέγεθος του περιεχομένου διαφάνειας, διατηρώντας ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Aspose.Slides for PHP via Java ενώνει παρουσιάσεις κλαπώνοντας διαφάνειες από μια [Παρουσίαση](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι [SlideCollection::addClone()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/), η οποία μπορεί να διατηρήσει τη διαμόρφωση της πηγής ή να προσδέσει τη κλαπιά διαφάνεια σε έναν κύριο ή διάταξη στην προορισμένη παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο συνηθισμένες ροές εργασίας συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη διαμόρφωση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή κύριου από την προορισμένη παρουσίαση·
- εφαρμογή συγκεκριμένης διάταξης από την προορισμένη παρουσίαση·
- εξομάλυνση διαφορετικών μεγεθών διαφάνειας πριν από τη συγχώνευση·
- προσθήκη κλαπιασμένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μια ολοκληρωμένη ροή εργασίας·
- διαχείριση κυρίων, πόρων, σημειώσεων, σχολίων, μέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και θεμάτων πολυνηματισμού.

## **Πώς η Κλαπή Διαφάνειας Επηρεάζει Κύριους και Διατάξεις**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από τη διάταξη και τον κύριο της. Για το λόγο αυτό, η υπερφόρτωση κλαπής που επιλέγετε καθορίζει τον τρόπο ενσωμάτωσης της συγχωνευμένης διαφάνειας στην προορισμένη παρουσίαση.

Χρησιμοποιήστε [SlideCollection::addClone()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) με έναν από τους ακόλουθους τρόπους:

- `addClone(sourceSlide)` — διατηρεί τη διάταξη και τη διαμόρφωση της πηγής. Όταν απαιτείται, ο κύριος της πηγής μπορεί να κλαπεί αυτόματα στην προορισμένη παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλαπιασμένους κυρίους ώστε οι διαφάνειες που χρησιμοποιούν τον ίδιο κύριο πηγής να μην προκαλούν επανειλημμένο κλαπινγκ του κυρίου.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — προσδέτει τη κλαπιά διαφάνεια σε έναν συγκεκριμένο προορισμό [MasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/). Το Aspose.Slides αναζητά μια ταιριαστή διάταξη κάτω από αυτόν τον κύριο με βάση τον τύπο ή το όνομα της διάταξης.
- `addClone(sourceSlide, destinationLayout)` — προσδέτει τη κλαπιά διαφάνεια απευθείας σε μια συγκεκριμένη προορισμού [LayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/).

Ο κύριος ή η διάταξη που περνιέται σε μια υπερφόρτωση `addClone` πρέπει να ανήκει στην **προορισμένη** παρουσίαση, όχι στην παρουσίαση πηγής.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Διαμόρφωσης Πηγής**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την παρουσίαση πηγής στην προορισμένη παρουσίαση. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαχθείσες διαφάνειες πρέπει να διατηρήσουν το αρχικό τους θέμα, κύριο και τις σχέσεις διάταξης.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Η προκύπτουσα παρουσίαση μπορεί να περιέχει πολλαπλούς κυρίους όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της πηγής διατηρείται σκόπιμα.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλαπείτε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο επιλεγμένα ευρετήρια διαφάνειας από την παρουσίαση πηγής.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Επικυρώστε τα ευρετήρια διαφάνειας πριν από την κλαπή όταν προέρχονται από είσοδο χρήστη ή εξωτερική διαμόρφωση.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Κύριο Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) όταν οι εισαχθείσες διαφάνειες πρέπει να ακολουθούν έναν κύριο που ήδη ανήκει στην προορισμένη παρουσίαση.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Το Aspose.Slides επιλέγει μια κατάλληλη διάταξη κάτω από τον καθορισμένο κύριο ταιριάζοντας τον τύπο ή το όνομα της διάταξης πηγής. Εάν δεν υπάρχει κατάλληλη διάταξη και το `allowCloneMissingLayout` είναι `true`, η διάταξη πηγής κλαπείται ώστε η διαφάνεια να προστεθεί. Εάν είναι `false`, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει πρόσθετη διάταξη στον προορισμό.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένη Διάταξη Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) όταν γνωρίζετε ακριβώς ποια διάταξη προορισμού πρέπει να χρησιμοποιούν οι εισαχθείσες διαφάνειες.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Η εφαρμογή μιας διάταξης προορισμού αλλάζει τη κληρονομική σχέση διάταξης· δεν επανασχεδιάζει το περιεχόμενο της πηγής. Εάν οι διατάξεις πηγής και προορισμού έχουν διαφορετικές δομές δεσμευτικών στοιχείων, εξετάστε το αποτέλεσμα για να επιβεβαιώσετε ότι η κληρονομική μορφοποίηση και η συμπεριφορά των δεσμευτικών στοιχείων είναι κατάλληλες.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφάνειας**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλαπία μιας διαφάνειας σε παρουσίαση με διαφορετικό μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Τα σχήματα ενδέχεται να εμφανιστούν μετατοπισμένα, κλιμακωμένα απρόσμενα ή εκτός του ορατού χώρου της διαφάνειας.

Μια πρακτική προσέγγιση είναι η αλλαγή μεγέθους της παρουσίασης πηγής πριν την κλαπή. Η μέθοδος [SlideSize::setSize()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/setsize/) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να ταιριάζει στο ζητούμενο μέγεθος.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο παρουσίασης πηγής στη μνήμη. Εάν χρειάζεστε την αρχική παρουσίαση αμετάβλητη για άλλες λειτουργίες, ανοίξτε ένα ξεχωριστό αντίγραφο για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλαπής διαφανειών δεν αναδημιουργεί την ιεραρχία ενοτήτων της παρουσίασης πηγής. Εάν οι ενότητες είναι σημαντικές στο αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προορισμένη παρουσίαση και κλαπείστε τις διαφάνειες μέσα σε αυτές ρητά με [addClone(Slide, Section)](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Οι κλαπία διαφάνειες προσαρτώνται στην καθορισμένη ενότητα προορισμού. Για να διατηρήσετε πολλαπλές ενότητες πηγής, επαναλάβετε το [Presentation::getSections](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSections), λάβετε τις τρέχουσες διαφάνειες κάθε ενότητας πηγής με [Section::getSlidesListOfSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getSlidesListOfSection), ξαναδημιουργήστε τις ενότητες στον προορισμό και κλαπείστε κάθε διαφάνεια στην αντίστοιχη ενότητα προορισμού. Δείτε το [Manage Slide Sections](/slides/el/php-java/slide-section/) για πλήρες παράδειγμα αρίθμησης ενοτήτων, συμπεριλαμβανομένων των κενών ενοτήτων και των δομικών αλλαγών.

## **Ασφαλής Συγχώνευση Πολλαπλών Παρουσιασέων**

Το παρακάτω ολοκληρωμένο παράδειγμα χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, εξομαλύνει το μέγεθος διαφάνειας κάθε πρόσθετης πηγής, κρατά κάθε πηγή ανοιχτή μόνο κατά τη διάρκεια της αντιγραφής και αποθηκεύει το τελικό αρχείο στο τέλος.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Αυτή αποτελεί μια χρήσιμη βάση για τη διατήρηση της μορφοποίησης της πηγής στις εισαχθείσες διαφάνειες. Εάν η έξοδός σας πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `addClone($slide)` με την κατάλληλη υπερφόρτωση προορισμού‑master ή προορισμού‑layout που δείχθηκε νωρίτερα.

## **Πρακτικές Σκέψεις**

### **Κύριοι, Διατάξεις και Πιστότητα Μορφοποίησης**

Η προεπιλεγμένη κλαπία διαφάνειας μπορεί αυτόματα να φέρει έναν απαιτούμενο κύριο πηγής στην προορισμένη παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλαπιασμένους κυρίους ώστε να αποφεύγεται η επανειλημμένη κλαπή του ίδιου κυρίου. Οι χειροκίνητα κλαπιασμένοι κύριοι δεν καταχωρούνται σε αυτό το μητρώο· γι’ αυτό αποφύγετε την προκαταρκτική κλαπή κυρίων εκτός εάν χρειάζεστε άμεσο έλεγχο της δομής του κυρίου.

Μην υποθέτετε ότι δύο κύριοι ή διατάξεις με το ίδιο όνομα είναι οπτικά ισοδύναμοι. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά έναν προορισμό‑master ή‑layout και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας συσχετίζονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλαπείται η διαφάνεια. Το Aspose.Slides παρέχει επίσης αφιερωμένα API για [presentation notes](/slides/el/php-java/presentation-notes/) και [presentation comments](/slides/el/php-java/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, επαληθεύστε τη συγχωνευμένη παρουσίαση επειδή οι κύριοι σημειώσεων είναι αντικείμενα σε επίπεδο παρουσίασης και μπορεί να διαφέρουν μεταξύ των αρχείων πηγής. Για ροές ελέγχου, επαληθεύστε επίσης τους συγγραφείς σχολίων και τα νήματα σχολίων μετά το συνδυασμό αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικοί Σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους σε επίπεδο παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλαπείστε τη διαφάνεια ολοκληρωτικά αντί να αντιγράφετε μόνο τα ορατά σχήματα, ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και οι συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του προορισμό· η κλαπία μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τα URL των συνδεδεμένων πόρων στο περιβάλλον όπου θα ανοιχτεί η συγχωνευμένη παρουσίαση.

Το Aspose.Slides εντοπίζει αυτόματα κλαπιασμένους κυρίους, αλλά αυτό δεν πρέπει να θεωρείται γενική εγγύηση ότι πανομοιότυποι δυαδικοί πόροι από ανεξάρτητες παρουσιάσεις πηγής θα αφαιρεθούν αυτόματα. Εάν το μέγεθος του αρχείου εξόδου είναι σημαντικό, εξετάστε το συγχωνευμένο πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε σε έμμεση αφαιρέση διπλοτύπων.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Εάν η τυπογραφία πρέπει να παραμείνει συνεπής μεταξύ μηχανών, μην υποθέτετε ότι η κλαπία διαφανειών εγγυάται ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να εξετάσετε τις ενσωματωμένες γραμματοσειρές με [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getembeddedfonts/) και να διαχειριστείτε την ενσωμάτωση όπως περιγράφεται στο [Embed Fonts in Presentations](/slides/el/php-java/embedded-font/).

Επιπλέον, βεβαιωθείτε ότι έχετε την άδεια να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούν τα αρχεία πηγής. Οι άδειες γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με Κωδικό Πρόσβασης**

Μια πηγή με κωδικό πρόσβασης πρέπει να ανοιχτεί επιτυχώς πριν κλαπεί η διαφάνειά της. Παρέχετε τον κωδικό μέσω του [LoadOptions::setPassword()](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
} finally {
    $source->dispose();
}
```

Το άνοιγμα μιας κρυπτογραφημένης πηγής δεν εφαρμόζει αυτόματα την ίδια προστασία στην προορισμένη παρουσίαση. Διαμορφώστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε το [Open Presentations](/slides/el/php-java/open-presentation/#open-large-presentations) για παράδειγμα μεγάλου αρχείου σε PHP via Java.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όποτε είναι δυνατόν, απελευθερώστε κάθε παρουσίαση πηγής μόλις ολοκληρωθεί η συγχώνευση και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Πολυνηματισμού**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλαπείτε στιγμιότυπα [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) σε πολλαπλά νήματα. Αυτές οι λειτουργίες δεν υποστηρίζονται για πολυνηματική χρήση σε PHP via Java. Εάν χρειάζεστε παράλληλες εργασίες συγχώνευσης, εκτελέστε τες σε ξεχωριστές διεργασίες μονού νήματος, με κάθε διεργασία να χρησιμοποιεί τα δικά της στιγμιότυπα παρουσίασης, και ακολουθήστε τις οδηγίες [Aspose.Slides multithreading guidance](/slides/el/php-java/multithreading/).

## **FAQ**

**Πώς μπορώ να διατηρήσω το αρχικό σχέδιο κάθε παρουσίασης πηγής;**

Χρησιμοποιήστε το [SlideCollection::addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) χωρίς να παρέχετε κύριο ή διάταξη προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλαπεί τον κύριο πηγής όταν χρειάζεται από την εισαχθείσα διαφάνεια.

**Πώς κάνω ώστε οι εισαχθείσες διαφάνειες να χρησιμοποιούν το θέμα προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται έναν προορισμό‑master. Παραχωρήστε έναν κύριο από την προορισμένη παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια πηγής σε μια κατάλληλη διάταξη κάτω από αυτόν τον κύριο.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένη διάταξη προορισμού αντί για κύριο προορισμού;**

Χρησιμοποιήστε μια συγκεκριμένη διάταξη όταν κάθε εισαχθείσα διαφάνεια πρέπει να χρησιμοποιεί μια γνωστή διάταξη. Χρησιμοποιήστε κύριο όταν θέλετε το Aspose.Slides να επιλέγει μεταξύ των διατάξεων του κυρίου βάσει του τύπου ή του ονόματος διάταξης πηγής.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφάνειας;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της παρουσίασης πηγής πρώτα όταν χρειάζεται προβλέψιμη τοποθέτηση, π.χ. με [SlideSize::setSize()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/setsize/) και [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω PPT, PPTX και ODP παρουσιάσεις σε ένα αρχείο;**

Ναι. Φορτώστε κάθε παρουσίαση πηγής, κλαπείστε τις απαιτούμενες διαφάνειες σε έναν προορισμό και αποθηκεύστε τον προορισμό σε υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, επαληθεύστε το σύνθετο περιεχόμενο μετά από συγχωνεύσεις διαφόρων μορφών. Δείτε τις [Supported File Formats](/slides/el/php-java/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες πηγής;**

Όχι από έναν βασικό βρόχο που κλαπεί μόνο διαφάνειες. Αναδημιουργήστε τις απαιτούμενες ενότητες στον προορισμό και χρησιμοποιήστε την υπερφόρτωση ενότητας του [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) όταν η δομή ενοτήτων πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται με τη κλαπείσα διαφάνεια. Για ροές εργασίας που εξαρτώνται από το στυλ του master σημειώσεων, τους συγγραφείς σχολίων ή τα νήματα ανασκόπησης, επαληθεύστε το συγχωνευμένο αποτέλεσμα επειδή αυτά τα σενάρια εμπλέκουν δομές σε επίπεδο παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι γίνεται με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλαπής διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, επομένως τα αρχεία ή οι διευθύνσεις URL τους πρέπει να είναι προσβάσιμα μετά τη συγχώνευση.

**Εγγυάνονται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή στο τελικό αρχείο;**

Μην βασίζεστε μόνο στην κλαπία διαφανειών για την ανάπτυξη γραμματοσειρών. Εξετάστε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς συγχωνεύω ένα αρχείο με κωδικό πρόσβασης;**

Ανοίξτε το με το σωστό [LoadOptions::setPassword()](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/setpassword/), στη συνέχεια κλαπείστε τις διαφάνειες όπως συνήθως. Η προστασία εξόδου διαμορφώνεται ξεχωριστά.

**Πώς πρέπει να διαχειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε τη διαχείριση BLOB όταν μεγάλα δυαδικά αντικείμενα κυριαρχούν στη μνήμη, προτιμήστε τη φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, απελευθερώστε τις παρουσιάσεις πηγής αμέσως μετά τη συγχώνευση και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν χρειάζεται.

**Μπορώ να κλαπείσω διαφάνειες από πολλαπλά νήματα;**

Η φόρτωση, η αποθήκευση ή η κλαπή παρουσιάσεων σε πολλαπλά νήματα δεν υποστηρίζεται σε PHP via Java. Για παράλληλη εργασία, χρησιμοποιήστε ξεχωριστές διεργασίες μονού νήματος και κρατήστε τα στιγμιότυπα παρουσίασης απομονωμένα σε κάθε διαδικασία.