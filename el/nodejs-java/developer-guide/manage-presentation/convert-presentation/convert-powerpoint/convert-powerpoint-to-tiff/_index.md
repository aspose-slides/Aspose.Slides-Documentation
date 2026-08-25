---
title: Μετατροπή Παρουσιάσεων PowerPoint σε TIFF με JavaScript
titlelink: PowerPoint σε TIFF
type: docs
weight: 90
url: /el/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- μετατροπή PowerPoint
- μετατροπή OpenDocument
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε TIFF
- παρουσίαση σε TIFF
- διαφάνεια σε TIFF
- PPT σε TIFF
- PPTX σε TIFF
- αποθήκευση PPT ως TIFF
- αποθήκευση PPTX ως TIFF
- εξαγωγή PPT σε TIFF
- εξαγωγή PPTX σε TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε εύκολα παρουσιάσεις PowerPoint (PPT, PPTX) σε εικόνες TIFF υψηλής ποιότητας χρησιμοποιώντας το Aspose.Slides για Node.js, με παραδείγματα κώδικα JavaScript."
---
## **Εισαγωγή**

TIFF (**Μορφή Αρχείου Εικόνας Με Ετικέτες**) είναι μια ευρέως χρησιμοποιούμενη, ασφαλής μορφή raster εικόνας γνωστή για την εξαιρετική ποιότητα και τη λεπτομερή διατήρηση των γραφικών. Σχεδιαστές, φωτογράφοι και εκδότες επιλέγουν συχνά TIFF για να διατηρήσουν τα στρώματα, την ακρίβεια χρωμάτων και τις αρχικές ρυθμίσεις στις εικόνες τους.

Με τη χρήση του Aspose.Slides, μπορείτε εύκολα να μετατρέψετε τις διαφάνειες PowerPoint (PPT, PPTX) και τις διαφάνειες OpenDocument (ODP) απευθείας σε εικόνες υψηλής ποιότητας TIFF, εξασφαλίζοντας ότι οι παρουσιάσεις σας διατηρούν τη μέγιστη οπτική πιστότητα.

## **Μετατροπή Παρουσίασης σε TIFF**

Χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) που παρέχεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/), μπορείτε γρήγορα να μετατρέψετε ολόκληρη μια παρουσίαση PowerPoint σε TIFF. Οι παραγόμενες εικόνες TIFF αντιστοιχούν στο προεπιλεγμένο μέγεθος διαφάνειας.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP κ.λπ.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Αποθηκεύστε την παρουσίαση ως TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή Παρουσίασης σε Ασπρόμαυρο TIFF**

Η μέθοδος [setBwConversionMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/) σας επιτρέπει να καθορίσετε τον αλγόριθμο που χρησιμοποιείται κατά τη μετατροπή μιας έγχρωμης διαφάνειας ή εικόνας σε ασπρόμαυρο TIFF. Σημειώστε ότι αυτή η ρύθμιση εφαρμόζεται μόνο όταν η μέθοδος [setCompressionType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) ορίζεται σε `CCITT4` ή `CCITT3`.

{{% alert color="info" title="Σημείωση" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) είναι ρύθμιση επιπέδου εξαγωγής που επιλέγει αλγόριθμο μετατροπής pixel για ολόκληρη την εικόνα TIFF. Για να ορίσετε πώς πρέπει να εμφανίζεται ένα μεμονωμένο σχήμα όταν είναι ενεργή η ασπρόμαυρη λειτουργία, χρησιμοποιήστε τη μέθοδο [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Δείτε το άρθρο [Control Black-and-White Rendering for Shapes](/slides/el/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) για παραδείγματα.
{{% /alert %}}

Ας υποθέσουμε ότι έχουμε ένα αρχείο «sample.pptx» με την ακόλουθη διαφάνεια:

![Διαφάνεια παρουσίασης](slide_black_and_white.png)

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε την έγχρωμη διαφάνεια σε ασπρόμαυρο TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Ασπρόμαυρο TIFF](TIFF_black_and_white.png)

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένο Μέγεθος**

Αν χρειάζεστε μια εικόνα TIFF με συγκεκριμένες διαστάσεις, μπορείτε να ορίσετε τις επιθυμητές τιμές χρησιμοποιώντας τις μεθόδους που διατίθενται στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/). Για παράδειγμα, η μέθοδος [setImageSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setImageSize) σας επιτρέπει να καθορίσετε το μέγεθος της παραγόμενης εικόνας.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνες TIFF με προσαρμοσμένο μέγεθος:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP κ.λπ.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Ορίστε τον τύπο συμπίεσης.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Τύποι συμπίεσης:
        Default - Ορίζει το προεπιλεγμένο σχήμα συμπίεσης (LZW).
        None - Δεν χρησιμοποιεί συμπίεση.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Το βάθος χρώματος ελέγχεται από τη μορφή pixel (δείτε το παρακάτω παράδειγμα); CCITT3 και CCITT4 πάντα δημιουργούν 1 bit ανά pixel.

    // Ορίστε το DPI της εικόνας.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Ορίστε το μέγεθος της εικόνας.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Αποθηκεύστε την παρουσίαση ως TIFF με το καθορισμένο μέγεθος.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένη Μορφή Pixel Εικόνας**

Χρησιμοποιώντας τη μέθοδο [setPixelFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) από την κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/), μπορείτε να καθορίσετε την προτιμώμενη μορφή pixel για την παραγόμενη εικόνα TIFF.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε μια εικόνα TIFF με προσαρμοσμένη μορφή pixel:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP κ.λπ.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat περιέχει τις ακόλουθες τιμές (όπως αναφέρεται στην τεκμηρίωση):
        Format1bppIndexed - 1 bit ανά pixel, με ευρετήριο.
        Format4bppIndexed - 4 bit ανά pixel, με ευρετήριο.
        Format8bppIndexed - 8 bit ανά pixel, με ευρετήριο.
        Format24bppRgb    - 24 bit ανά pixel, RGB.
        Format32bppArgb   - 32 bit ανά pixel, ARGB.
    */

    /// Αποθηκεύστε την παρουσίαση ως TIFF με το καθορισμένο μέγεθος εικόνας.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Συμβουλή" color="info" %}}
Δοκιμάστε το [ΔΩΡΕΑΝ εργαλείο μετατροπής PowerPoint σε αφίσα](https://products.aspose.app/slides/el/conversion/convert-ppt-to-poster-online) της Aspose.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια μεμονωμένη διαφάνεια αντί για ολόκληρη την παρουσίαση PowerPoint σε TIFF;**

Ναι. Το Aspose.Slides επιτρέπει τη μετατροπή μεμονωμένων διαφανειών από παρουσιάσεις PowerPoint και OpenDocument σε εικόνες TIFF ξεχωριστά.

**Υπάρχει κάποιο όριο στον αριθμό των διαφανειών κατά τη μετατροπή μιας παρουσίασης σε TIFF;**

Όχι, το Aspose.Slides δεν επιβάλλει περιορισμούς στον αριθμό των διαφανειών. Μπορείτε να μετατρέψετε παρουσιάσεις οποιουδήποτε μεγέθους σε μορφή TIFF.

**Διατηρούνται οι κινούμενες εικόνες και τα εφέ μετάβασης του PowerPoint όταν μετατρέπονται οι διαφάνειες σε TIFF;**

Όχι, το TIFF είναι μορφή στατικής εικόνας. Συνεπώς, τα κινούμενα εφέ και τα εφέ μετάβασης δεν διατηρούνται· εξάγονται μόνο στατικά στιγμιότυπα των διαφανειών.