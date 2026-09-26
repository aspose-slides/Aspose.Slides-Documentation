---
title: Αλλαγή Μεγέθους και Προσανατολισμού Σελίδας Σημειώσεων σε PHP
linktitle: Μέγεθος Σελίδας Σημειώσεων
type: docs
weight: 10
url: /el/php-java/notes-size/
keywords:
- μέγεθος σελίδας σημειώσεων
- προσανατολισμός σημειώσεων
- σημειώσεις οριζόντια
- σημειώσεις κάθετες
- μέγεθος χειροδείγματος
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Διαβάστε και αλλάξτε τις διαστάσεις της σελίδας σημειώσεων στο Aspose.Slides για PHP μέσω Java, αλλάξτε τον προσανατολισμό, επαληθεύστε τα αποθηκευμένα μεγέθη και εξάγετε σημειώσεις ή χειροδείγματα σε PDF και εικόνες."
---
## **Overview**

Χρησιμοποιήστε [Presentation::getNotesSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getnotessize/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις της σελίδας σημειώσεων της παρουσίασης. Επιστρέφει ένα αντικείμενο [NotesSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/notessize/) του οποίου η μέθοδος [setSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/notessize/setsize/) ορίζει τις διαστάσεις της σελίδας. Αν και το ίδιο το αντικείμενο ρυθμίσεων δεν μπορεί να αντικατασταθεί, μπορείτε να ορίσετε νέες διαστάσεις μέσω αυτής της μεθόδου.

Το πλάτος και το ύψος καθορίζονται σε **σημεία**, με 72 σημεία ανά ίντσα. Για παράδειγμα, 900 × 600 σημεία είναι 12,5 × 8⅓ ίντσες. Αυτές οι ρυθμίσεις εφαρμόζονται στην παρουσίαση, όχι σε μεμονωμένες σημειώσεις διαφάνειας.

| Setting | Purpose |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getnotessize/) | Ελέγχει τις διαστάσεις της σελίδας σημειώσεων και τις διαστάσεις σελίδας που χρησιμοποιούνται για εξαγωγή χειροδειγμάτων. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getslidesize/) | Ελέγχει κανονικές διαστάσεις διαφάνειας παρουσίασης μέσω του [SlideSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/). |

Η αλλαγή μιας από τις ρυθμίσεις δεν αλλάζει αυτόματα την άλλη. Η αλλαγή του προσανατολισμού της σελίδας σημειώσεων δεν περιστρέφει επίσης τις κανονικές διαφάνειες. Δείτε το [Slide Size](/slides/el/php-java/slide-size/) για να αλλάξετε το μέγεθος των κανονικών διαφανειών.

Τα παραδείγματα παρακάτω χρησιμοποιούν ένα υπάρχον `sample.pptx`. Για τα παραδείγματα εξαγωγής, χρησιμοποιήστε μια παρουσίαση με τουλάχιστον μία διαφάνεια που περιέχει σημειώσεις ομιλητή. Κάθε παράδειγμα μπορεί να εκτελεστεί ανεξάρτητα μετά τη φόρτωση του PHP/Java Bridge και του περιτύλιξης Aspose.Slides PHP. Οι αριθμητικές τιμές που επιστρέφονται από τη Java μετατρέπονται σε τιμές PHP με `java_values` πριν τη σύγκριση ή τον υπολογισμό.

## **Read the Notes Page Size and Orientation**

Διαβάστε το πλάτος και το ύψος και συγκρίνετε τα για να προσδιορίσετε τον προσανατολισμό: μια ευρύτερη σελίδα είναι οριζόντια, μια ψηλότερη σελίδα είναι κάθετη, και ίσες διαστάσεις περιγράφουν τετράγωνη σελίδα. Αυτό το παράδειγμα εκτυπώνει τις πραγματικές διαστάσεις σε σημεία, χωρίς να υποθέτει τυπικό μέγεθος χαρτιού.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Switch to Landscape Without Changing the Paper Size**

Για να αλλάξετε μόνο τον προσανατολισμό, ανταλλάξτε το υπάρχον πλάτος και το ύψος. Έτσι διατηρούνται τα μήκη και των δύο πλευρών, συμπεριλαμβανομένων εκείνων ενός προσαρμοσμένου μεγέθους χαρτιού. Η συνθήκη παρακάτω αποτρέπει το ήδη οριζόντιο φύλλο να επιστρέψει σε κάθετο και αφήνει μια τετράγωνη σελίδα αμετάβλητη.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για κατακόρυφο προσανατολισμό, χρησιμοποιήστε την ίδια ανάθεση όταν `java_values($size->getWidth()) > java_values($size->getHeight())`. Μην αντικαταστήσετε τις διαστάσεις A4 ή Letter εκτός αν θέλετε επίσης να αλλάξετε το μέγεθος χαρτιού.

## **Set and Verify a Custom Notes Page Size**

Ορίστε και τις δύο διαστάσεις μαζί, μετά χρησιμοποιήστε [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/save/) για να αποθηκεύσετε την παρουσίαση. Αυτό το παράδειγμα ορίζει μια οριζόντια σελίδα 900 × 600 σημείων, την αποθηκεύει ως PPTX και ανοίγει πάλι το αποθηκευμένο αρχείο για να ελέγξει τις αποθηκευμένες τιμές. Η σύγκριση επιτρέπει ανοχή 0,01 σημείου για τιμές κινητής υποδιαστολής· δεν αποτελεί εγγύηση ακρίβειας για κάθε μορφή αρχείου.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Το αναμενόμενο αποτέλεσμα είναι `900 x 600 points` και `Size preserved: true`. Ο έλεγχος μιας νεοανοιγμένης παρουσίασης επαληθεύει το αποθηκευμένο αρχείο, όχι μόνο τις ρυθμίσεις στη μνήμη.

## **Export Notes and Handouts**

Οι διαστάσεις της σελίδας ορίζουν την διαθέσιμη περιοχή για διατάξεις σημειώσεων ή χειροδειγμάτων. Δεν ενεργοποιούν αυτές τις διατάξεις μόνες τους: διαμορφώστε επίσης τις επιλογές εξαγωγής. Η εξαγωγή κανονικών διαφανειών συνεχίζει να χρησιμοποιεί τις διαστάσεις της διαφάνειας.

### **Export Notes to PDF and PNG**

Ορίστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/notescommentslayoutingoptions/) στο [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) για να συμπεριλάβετε σημειώσεις στο PDF. Αυτό το παράδειγμα επίσης αποδίδει την πρώτη διαφάνεια με σημειώσεις σε PNG χρησιμοποιώντας [Slide::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getImage) και [RenderingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/).

Η λειτουργία [BottomTruncated](https://reference.aspose.com/slides/el/php-java/aspose.slides/notespositions/) κρατά τις σημειώσεις σε μία σελίδα· οι σημειώσεις που δεν χωρούν μπορούν να περικοπούν. Το PDF χρησιμοποιεί σελίδες 900 × 600 σημείων. Στην κλίμακα εικόνας 1 × 1 που χρησιμοποιείται παρακάτω, το PNG είναι 900 × 600 pixel. Τα σημεία περιγράφουν τη γεωμετρία της σελίδας· τα pixel περιγράφουν την εξαγόμενη ραστερική απόδοση, των οποίων οι διαστάσεις εξαρτώνται επίσης από την κλίμακα αποτύπωσης.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Για εξαγωγή PDF με μακρές σημειώσεις, το [BottomFull](https://reference.aspose.com/slides/el/php-java/aspose.slides/notespositions/) επιτρέπει επιπλέον σελίδες όπως απαιτείται. Μην χρησιμοποιήσετε αυτή τη λειτουργία με την κλήση εικόνας μιας μόνο διαφάνειας παραπάνω, η οποία δεν την υποστηρίζει. Μετά την αλλαγή μεγέθους, ελέγξτε την έξοδο για περικομμένες σημειώσεις και τη θέση των υπαρχόντων αντικειμένων notes‑master· η αλλαγή μόνο των διαστάσεων της σελίδας δεν είναι εγγύηση ότι όλο το περιεχόμενο θα χωρέσει. Δείτε το [Convert PowerPoint to PDF with Notes](/slides/el/php-java/convert-powerpoint-to-pdf-with-notes/) για περισσότερα σχετικά με την εξαγωγή σημειώσεων.

### **Export Handouts to PDF**

Χρησιμοποιήστε το [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/handoutlayoutingoptions/) για πολλαπλά μικρογραφίες διαφανειών σε μία σελίδα. Το παρακάτω παράδειγμα ορίζει μια σελίδα 900 × 600 σημείων και χρησιμοποιεί το [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/el/php-java/aspose.slides/handouttype/) για να τοποθετήσει έως τέσσερις διαφάνειες ανά σελίδα. Η οριζόντια προεπιλογή ελέγχει τη σειρά των διαφανειών· ο προσανατολισμός της σελίδας προέρχεται από το πλάτος και το ύψος της.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Η αλλαγή του μεγέθους σελίδας αλλάζει την περιοχή που διατίθεται για το πλέγμα του χειροδείγματος χωρίς να αλλάξει τις διαστάσεις των πηγών διαφανειών. Για εικόνες χειροδειγμάτων, χρησιμοποιήστε το [Presentation::getImages](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getimages/) με τη διάταξη χειροδείγματος, αντί για τη μέθοδο εικόνας μιας μεμονωμένης διαφάνειας. Στο Aspose.Slides, η απόδοση χειροδειγμάτων επιπέδου παρουσίασης χρησιμοποιεί τις διαστάσεις της σελίδας σημειώσεων, ενώ η κλήση εικόνας μεμονωμένης διαφάνειας δεν παράγει τη σελίδα χειροδείγματος. Δείτε το [Handout Mode](/slides/el/php-java/convert-powerpoint-in-handout-mode/) για επιλογές διάταξης.

## **Page Size in Viewers, Export, and Printing**

Διατηρήστε ξεχωριστά το αποθηκευμένο μέγεθος παρουσίασης, το εξαγόμενο μέγεθος σελίδας και το εκτυπωμένο μέγεθος χαρτιού:

- **Presentation viewers:** Ένας προβολέας μπορεί να εμφανίσει ή να εκτυπώσει σημειώσεις χρησιμοποιώντας τους δικούς του κανόνες διάταξης. Αν μια άλλη εφαρμογή αποθηκεύσει το αρχείο, ανοίξτε το ξανά και ελέγξτε ξανά τις διαστάσεις· η μετατροπή μορφής αυτής της εφαρμογής μπορεί να τις ομαλοποιήσει.
- **Export formats:** Τα παραδείγματα PDF σημειώσεων και χειροδειγμάτων παραπάνω χρησιμοποιούν τις ρυθμισμένες διαστάσεις σελίδας. Οι ραστερικές εικόνες χρησιμοποιούν ακέραιες διαστάσεις pixel και κλίμακα αποτύπωσης, έτσι ότι δεκαδικές τιμές σημείων μπορούν να στρογγυλοποιηθούν στην έξοδο εικόνας. Η εξαγωγή κανονικών διαφανειών δεν εφαρμόζει το μέγεθος σελίδας σημειώσεων.
- **Printer drivers:** Η επιλογή χαρτιού, η αυτόματη περιστροφή και οι ρυθμίσεις προσαρμογής σελίδας μπορούν να αλλάξουν το φυσικό αποτέλεσμα χωρίς να αλλάξουν τις διαστάσεις που αποθηκεύονται στην παρουσίαση ή το PDF. Για συγκεκριμένο μέγεθος χαρτιού, εναρμονίστε τις ρυθμίσεις του εκτυπωτή και ελέγξτε την προεπισκόπηση εκτύπωσης.

## **FAQ**

**Can I set the notes size for just one slide?**

Το μέγεθος σελίδας σημειώσεων είναι ρύθμιση επιπέδου παρουσίασης. Οι μεμονωμένες διαφάνειες μπορούν να έχουν διαφορετικό περιεχόμενο σημειώσεων, αλλά αυτή η ιδιότητα δεν παρέχει ξεχωριστό μέγεθος σελίδας για κάθε διαφάνεια.

**Why did changing notes orientation not change my slides?**

Οι σελίδες σημειώσεων και οι κανονικές διαφάνειες έχουν ανεξάρτητες διαστάσεις. Χρησιμοποιήστε τις ρυθμίσεις μεγέθους κανονικής διαφάνειας όταν θέλετε να αλλάξετε το μέγεθος των διαφανειών.

**Why does my saved or printed result have a different size?**

Πρώτα ανοίξτε ξανά την αποθηκευμένη παρουσίαση και συγκρίνετε τις διαστάσεις σημειώσεων. Αν αυτές έχουν αλλάξει, ελέγξτε εάν η αποθήκευση ή η μετατροπή του αρχείου σε άλλη εφαρμογή άλλαξε τις ρυθμίσεις σελίδας. Αν δεν άλλαξαν, ελέγξτε τη διάταξη εξαγωγής, την κλίμακα εικόνας, τις ρυθμίσεις προβολέα και την επιλογή χαρτιού του εκτυπωτή.