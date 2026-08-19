---
title: Αποτελεσματική Συγχώνευση Παρουσιάσεων σε PHP
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
- συνδυασμός PowerPoint
- συνδυασμός παρουσιάσεων
- συνδυασμός διαφανειών
- συνδυασμός PPT
- συνδυασμός PPTX
- συνδυασμός ODP
- PHP
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε PHP κλωνοποιώντας διαφάνειες, ελέγχοντας master και διατάξεις, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP μέσω Java συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από μία [Παρουσίαση](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι [SlideCollection::addClone()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/), η οποία μπορεί να διατηρήσει τη μορφοποίηση της διαφάνειας προέλευσης ή να συνημάνει τη κλωνοποιημένη διαφάνεια σε ένα master ή layout στην παρουσίαση προορισμού.

Αυτό το άρθρο καλύπτει τις πιο συνηθισμένες ροές συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της προέλευσης·  
- συγχώνευση επιλεγμένων διαφανειών·  
- εφαρμογή master από την παρουσίαση προορισμού·  
- εφαρμογή συγκεκριμένης διάταξης από την παρουσίαση προορισμού·  
- κανονικοποίηση διαφορετικών μεγεθών διαφάνειας πριν τη συγχώνευση·  
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·  
- συγχώνευση πολλαπλών παρουσιάσεων σε μία ολοκληρωμένη ροή εργασίας·  
- διαχείριση master, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και θεμάτων πολυνηματικότητας.

## **Πώς η κλωνοποίηση διαφανειών επηρεάζει τα Master και τις Διατάξεις**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από τη διάταξη και το master της. Για αυτόν τον λόγο, η παραλλαγή κλωνοποίησης που επιλέγετε καθορίζει πώς η συγχωνευμένη διαφάνεια ενσωματώνεται στην παρουσίαση προορισμού.

Χρησιμοποιήστε το [SlideCollection::addClone()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) με έναν από τους παρακάτω τρόπους:

- `addClone(sourceSlide)` — διατηρεί τη διάταξη και τη μορφοποίηση της διαφάνειας προέλευσης. Εάν απαιτηθεί, το master της προέλευσης μπορεί να κλωνοποιηθεί αυτόματα στην παρουσίαση προορισμού. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα master ώστε οι επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο master προέλευσης να μην κλωνοποιούν το master επανειλημμένα.  
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — συνημάνει τη κλωνοποιημένη διαφάνεια σε ένα συγκεκριμένο [MasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/). Το Aspose.Slides ψάχνει για αντίστοιχη διάταξη υπό αυτό το master βάσει τύπου ή ονόματος διάταξης.  
- `addClone(sourceSlide, destinationLayout)` — συνημάνει τη κλωνοποιημένη διαφάνεια απευθείας σε μια συγκεκριμένη [LayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/).

Το master ή η διάταξη που περνιούνται σε μια υπερφόρτωση `addClone` πρέπει να ανήκει στην **προορισμού** παρουσίαση, όχι στην παρουσίαση προέλευσης.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Προέλευσης**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την παρουσίαση προέλευσης στην παρουσίαση προορισμού. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαχθείσες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, το master και τις σχέσεις διάταξης.

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

Η προκύπτουσα παρουσίαση μπορεί να περιέχει πολλαπλά master όταν η προέλευση και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της προέλευσης διατηρείται εσκεμμένα.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο τις επιλεγμένες θέσεις διαφάνειας από την παρουσίαση προέλευσης.

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

Επικυρώστε τις θέσεις διαφάνειας πριν την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική διαμόρφωση.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Master Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) όταν οι εισαχθείσες διαφάνειες πρέπει να ακολουθούν ένα master που ήδη ανήκει στην παρουσίαση προορισμού.

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

Το Aspose.Slides επιλέγει την κατάλληλη διάταξη κάτω από το καθορισμένο master ταιριάζοντας με τον τύπο ή το όνομα της διάταξης προέλευσης. Εάν δεν υπάρχει κατάλληλη διάταξη και το `allowCloneMissingLayout` είναι `true`, η διάταξη προέλευσης κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Εάν είναι `false`, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει πρόσθετη διάταξη στο master προορισμού.

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

Η εφαρμογή μιας διάταξης προορισμού αλλάζει τη σχέση κληρονομικής διάταξης· δεν επανασχεδιάζει το περιεχόμενο της διαφάνειας προέλευσης. Εάν οι διατάξεις προέλευσης και προορισμού έχουν διαφορετικές δομές placeholder, ελέγξτε το αποτέλεσμα για να βεβαιωθείτε ότι η κληρονομημένη μορφοποίηση και η συμπεριφορά placeholder είναι κατάλληλες.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφάνειας**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε μια παρουσίαση με διαφορετικό μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για τον νέο καμβά. Τα σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιμακωμένα απροσδόκητα ή εκτός του ορατού πεδίου διαφάνειας.

Μια πρακτική προσέγγιση είναι να αλλάξετε το μέγεθος της παρουσίασης προέλευσης πριν την κλωνοποίηση. Η μέθοδος [SlideSize::setSize()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/setsize/) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να ταιριάζει στο ζητούμενο μέγεθος.

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

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο της παρουσίασης προέλευσης στη μνήμη. Εάν χρειάζεστε την αρχική παρουσίαση προέλευσης αμετάβλητη για άλλες λειτουργίες, ανοίξτε ένα ξεχωριστό αντίγραφο για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν αναδημιουργεί την ιεραρχία ενοτήτων της παρουσίασης προέλευσης. Εάν οι ενότητες έχουν σημασία στο τελικό αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην παρουσίαση προορισμού και κλωνοποιήστε τις διαφάνειες σε αυτές ρητά με την [addClone(Slide, Section)](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/).

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

Οι κλωνοποιημένες διαφάνειες προσαρτώνται στην καθορισμένη ενότητα προορισμού. Για να διατηρήσετε πολλές ενότητες προέλευσης, δημιουργήστε ξανά αυτές τις ενότητες στον προορισμό και αντιστοιχίστε κάθε διαφάνεια προέλευσης στην αντίστοιχη ενότητα προορισμού.

## **Ασφαλής Συγχώνευση Πολλαπλών Παρουσιάσεων**

Το παρακάτω παράδειγμα end-to-end χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, κανονικοποιεί το μέγεθος διαφάνειας κάθε επιπλέον προέλευσης, κρατά κάθε προέλευση ανοιχτή μόνο όσο αντιγράφεται, και αποθηκεύει το τελικό αρχείο μία φορά.

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

Αυτό αποτελεί μία χρήσιμη βάση για τη διατήρηση της μορφοποίησης της προέλευσης των εισαχθέντων διαφανειών. Εάν η έξοδός σας πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `addClone($slide)` με την κατάλληλη υπερφόρτωση master ή layout προορισμού που εμφανίστηκε νωρίτερα.

## **Πρακτικές Παρατηρήσεις**

### **Master, Διατάξεις και Πιστότητα Μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφανειών μπορεί αυτόματα να φέρει ένα απαιτούμενο master προέλευσης στην παρουσίαση προορισμού. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλωνοποιημένα master ώστε να αποφεύγεται η επανειλημμένη κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα master δεν παρακολουθούνται από αυτό το μητρώο, γι’ αυτό αποφύγετε την προ-κλωνοποίηση master εκτός εάν χρειάζεστε ρητό έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο master ή διατάξεις με το ίδιο όνομα είναι οπτικά ισοδύναμα. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά ένα master ή διάταξη προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας είναι συσχετισμένα με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν η διαφάνεια κλωνοποιείται. Το Aspose.Slides παρέχει επίσης εξειδικευμένα APIs για [presentation notes](https://docs.aspose.com/slides/el/php-java/presentation-notes/) και [presentation comments](https://docs.aspose.com/slides/el/php-java/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, ελέγξτε τη συγχωνευμένη παρουσίαση επειδή τα notes master είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των αρχείων προέλευσης. Για ροές ελέγχου, επαληθεύστε επίσης τους συγγραφείς σχολίων και τα νήματα σχολίων μετά το συνδυασμό αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικοί Σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια ίδιαν αντί να αντιγράφετε μόνο τα ορατά σχήματα ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και οι συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από το εξωτερικό του στόχο· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές των συνδεδεμένων πόρων και τα URLs στο περιβάλλον όπου θα ανοιχθεί η συγχωνευμένη παρουσίαση.

Το Aspose.Slides παρακολουθεί ρητά αυτόματα κλωνοποιημένα master, αλλά αυτό δεν πρέπει να θεωρείται γενική εγγύηση ότι παρόμοιο δυαδικό περιεχόμενο από ανεξάρτητες παρουσιάσεις προέλευσης θα αφαιρεθεί πάντα. Εάν το μέγεθος του αρχείου εξόδου είναι σημαντικό, εξετάστε το συγχωνευμένο πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε στην εσωτερική αφαίρεση διπλοτύπων.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Εάν η τυπογραφία πρέπει να παραμείνει συνεπής σε διαφορετικούς υπολογιστές, μην υποθέτετε ότι η κλωνοποίηση διαφανειών από μόνη της εγγυάται ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με το [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getembeddedfonts/) και να διαχειριστείτε την ενσωμάτωση ρητά όπως περιγράφεται στο [Embed Fonts in Presentations](https://docs.aspose.com/slides/el/php-java/embedded-font/).

Επιβεβαιώστε επίσης ότι έχετε δικαίωμα ενσωμάτωσης των γραμματοσειρών που χρησιμοποιούνται στα αρχεία προέλευσης. Οι άδειες γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με Προστασία Κωδικού**

Μια πηγή προστατευμένη με κωδικό πρέπει να ανοίξει επιτυχώς πριν τις διαφάνειές της κλωνοποιήσετε. Παρέχετε τον κωδικό μέσω του [LoadOptions::setPassword()](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Δουλέψτε με την αποκρυπτογραφημένη παρουσίαση.
} finally {
    $source->dispose();
}
```

Το άνοιγμα μιας κρυπτογραφημένης πηγής δεν εφαρμόζει αυτόματα την ίδια προστασία στην παρουσίαση προορισμού. Ρυθμίστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε το [Open Presentations](https://docs.aspose.com/slides/el/php-java/open-presentation/#open-large-presentations) για ένα παράδειγμα μεγάλου αρχείου PHP μέσω Java.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όποτε είναι δυνατόν, απελευθερώστε κάθε παρουσίαση προέλευσης αμέσως μετά τη συγχώνευση και αποφύγετε την επανειλημμένη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Νημάτων**

Μη φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλωνοποιείτε αντικείμενα [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) σε πολλαπλά νήματα. Αυτές οι λειτουργίες δεν υποστηρίζονται για πολυνηματική χρήση σε PHP μέσω Java. Εάν χρειάζεστε παράλληλες εργασίες συγχώνευσης, τρέξτε τις σε ξεχωριστές διαδικασίες μονόνημα, με κάθε διαδικασία να χρησιμοποιεί τις δικές της παρουσίες παρουσίασης, και ακολουθήστε τις οδηγίες [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/el/php-java/multithreading/).

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διατηρήσω το αρχικό σχέδιο κάθε παρουσίασης προέλευσης;**

Χρησιμοποιήστε `addClone(sourceSlide)` χωρίς να παρέχετε master ή layout προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το master προέλευσης όταν χρειάζεται από την εισαχθείσα διαφάνεια.

**Πώς μπορώ να κάνω τις εισαχθείσες διαφάνειες να χρησιμοποιούν το θέμα του προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται ένα master προορισμού. Παρέχετε ένα master από την παρουσίαση προορισμού, όχι από την προέλευση. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια προέλευσης σε μια κατάλληλη διάταξη κάτω από αυτό το master.

**Πότε πρέπει να χρησιμοποιήσω μια συγκεκριμένη διάταξη προορισμού αντί για ένα master προορισμού;**

Χρησιμοποιήστε μια συγκεκριμένη διάταξη όταν κάθε εισαχθείσα διαφάνεια πρέπει να χρησιμοποιεί μια γνωστή διάταξη. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει μεταξύ των διατάξεων του master βάσει του τύπου ή του ονόματος διάταξης προέλευσης.

**Μπορούν οι παρουσιάσεις με διαφορετικά μεγέθη διαφάνειας να συγχωνευτούν;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις νέες διαστάσεις. Αλλάξτε το μέγεθος της παρουσίασης προέλευσης πρώτα όταν χρειάζεστε προβλέψιμη τοποθέτηση, π.χ. με το [SlideSize::setSize()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/setsize/) και το [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω παρουσιάσεις PPT, PPTX και ODP σε ένα αρχείο;**

Ναι. Φορτώστε κάθε παρουσίαση προέλευσης, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε έναν προορισμό και αποθηκεύστε τον προορισμό σε μια υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο δυνατοτήτων, ελέγξτε το σύνθετο περιεχόμενο μετά από διαμορφώσεις μεταξύ διαφορετικών τύπων αρχείων. Δείτε τις [Supported File Formats](https://docs.aspose.com/slides/el/php-java/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες προέλευσης;**

Όχι από έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Δημιουργήστε ξανά τις απαιτούμενες ενότητες στον προορισμό και χρησιμοποιήστε την υπερφόρτωση ενότητας του [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/addclone/) όταν η δομή των ενοτήτων πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται μαζί με την κλωνοποιημένη διαφάνεια. Για ροές εργασίας που εξαρτώνται από το στυλ του notes‑master, τους συγγραφείς σχολίων ή τα νήματα αξιολογήσεων, επαληθεύστε το συγχωνευμένο αποτέλεσμα, καθώς αυτά τα σενάρια περιλαμβάνουν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι συμβαίνει με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, οπότε τα αρχεία ή οι διευθύνσεις URL στόχου πρέπει να είναι διαθέσιμες μετά τη συγχώνευση.

**Εγγυάνονται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή να είναι διαθέσιμες στη συγχωνευμένη παρουσίαση;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την ανάπτυξη γραμματοσειρών. Ελέγξτε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς μπορώ να συγχωνεύσω ένα αρχείο με προστασία κωδικού;**

Ανοίξτε το με το σωστό [LoadOptions::setPassword()](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/setpassword/), κατόπιν κλωνοποιήστε τις διαφάνειές του κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς πρέπει να διαχειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε τη διαχείριση BLOB όταν μεγάλα δυαδικά αντικείμενα κυριαρχούν στη χρήση μνήμης, προτιμήστε τη φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, απελευθερώστε γρήγορα τις παρουσίες προέλευσης και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να συγχωνεύσω διαφάνειες από πολλαπλά νήματα;**

Η φόρτωση, η αποθήκευση ή η κλωνοποίηση παρουσιάσεων σε πολλά νήματα δεν υποστηρίζεται σε PHP μέσω Java. Για παράλληλη εργασία, χρησιμοποιήστε ξεχωριστές διαδικασίες μονόνημα και διατηρήστε τις παρουσίες παρουσίασης απομονωμένες σε κάθε διαδικασία.