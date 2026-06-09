---
title: Μετατροπή παρουσιάσεων PowerPoint σε TIFF με JavaScript
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
description: "Μάθετε πώς να μετατρέπετε εύκολα παρουσιάσεις PowerPoint (PPT, PPTX) σε εικόνες υψηλής ποιότητας TIFF χρησιμοποιώντας το Aspose.Slides για Node.js, με παραδείγματα κώδικα JavaScript."
---
## **Εισαγωγή**

TIFF (**Tagged Image File Format**) είναι ένα ευρέως χρησιμοποιούμενο, χωρίς απώλειες μορφότυπο raster εικόνας γνωστό για την εξαιρετική του ποιότητα και τη λεπτομερή διατήρηση των γραφικών. Σχεδιαστές, φωτογράφοι και εκδότες επιφάνειας εργασίας συχνά επιλέγουν TIFF για να διατηρήσουν τις στρώσεις, την ακριβή χρωματική απόδοση και τις αρχικές ρυθμίσεις στις εικόνες τους.

Με το Aspose.Slides, μπορείτε εύκολα να μετατρέψετε τις διαφάνειες PowerPoint (PPT, PPTX) και τις διαφάνειες OpenDocument (ODP) άμεσα σε εικόνες υψηλής ποιότητας TIFF, εξασφαλίζοντας ότι οι παρουσιάσεις σας διατηρούν το μέγιστο οπτικό πιστότητα.

## **Μετατροπή μιας παρουσίασης σε TIFF**

Χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) που παρέχεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/), μπορείτε γρήγορα να μετατρέψετε ολόκληρη μια παρουσίαση PowerPoint σε TIFF. Οι παραγόμενες εικόνες TIFF αντιστοιχούν στο προεπιλεγμένο μέγεθος διαφάνειας.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε TIFF:

```js
// Δημιουργήστε το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κ.λπ.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Αποθηκεύστε την παρουσίαση ως TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή μιας παρουσίασης σε Ασπρόμαυρο TIFF**

Η μέθοδος [setBwConversionMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/) σας επιτρέπει να ορίσετε τον αλγόριθμο που χρησιμοποιείται όταν μετατρέπετε μια χρωματιστή διαφάνεια ή εικόνα σε ασπρόμαυρο TIFF. Σημειώστε ότι αυτή η ρύθμιση εφαρμόζεται μόνο όταν η μέθοδος [setCompressionType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) είναι ρυθμισμένη σε `CCITT4` ή `CCITT3`.

Ας πούμε ότι έχουμε ένα αρχείο "sample.pptx" με την ακόλουθη διαφάνεια:

![Διαφάνεια παρουσίασης](slide_black_and_white.png)

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε τη χρωματιστή διαφάνεια σε ασπρόμαυρο TIFF:

```js
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

## **Μετατροπή μιας παρουσίασης σε TIFF με προσαρμοσμένο μέγεθος**

Εάν χρειάζεστε μια εικόνα TIFF με συγκεκριμένες διαστάσεις, μπορείτε να ορίσετε τις επιθυμητές τιμές χρησιμοποιώντας τις μεθόδους που διατίθενται στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/). Για παράδειγμα, η μέθοδος [setImageSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setImageSize) σάς επιτρέπει να καθορίσετε το μέγεθος της παραγόμενης εικόνας.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνες TIFF με προσαρμοσμένο μέγεθος:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κ.λπ.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Ορίστε τον τύπο συμπίεσης.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Τύποι συμπίεσης:
        Default - Καθορίζει το προεπιλεγμένο σχήμα συμπίεσης (LZW).
        None - Καθορίζει ότι δεν υπάρχει συμπίεση.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Το βάθος εξαρτάται από τον τύπο συμπίεσης και δεν μπορεί να οριστεί χειροκίνητα.

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

## **Μετατροπή μιας παρουσίασης σε TIFF με προσαρμοσμένη μορφή εικονοστοιχείου**

Χρησιμοποιώντας τη μέθοδο [setPixelFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) από την κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/), μπορείτε να ορίσετε την προτιμώμενη μορφή εικονοστοιχείου για την παραγόμενη εικόνα TIFF.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνα TIFF με προσαρμοσμένη μορφή εικονοστοιχείου:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κ.λπ.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    Το ImagePixelFormat περιέχει τις ακόλουθες τιμές (όπως αναφέρεται στην τεκμηρίωση):
        Format1bppIndexed - 1 bit ανά εικονοστοιχείο, με ευρετήριο.
        Format4bppIndexed - 4 bits ανά εικονοστοιχείο, με ευρετήριο.
        Format8bppIndexed - 8 bits ανά εικονοστοιχείο, με ευρετήριο.
        Format24bppRgb    - 24 bits ανά εικονοστοιχείο, RGB.
        Format32bppArgb   - 32 bits ανά εικονοστοιχείο, ARGB.
    */

    /// Αποθηκεύστε την παρουσίαση ως TIFF με το καθορισμένο μέγεθος εικόνας.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Δείτε τον [ΔΩΡΕΑΝ μετατροπέα PowerPoint σε αφίσα](https://products.aspose.app/slides/el/conversion/convert-ppt-to-poster-online) της Aspose.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Μπορώ να μετατρέψω μια μεμονωμένη διαφάνεια αντί για ολόκληρη παρουσίαση PowerPoint σε TIFF;**

Ναι. Το Aspose.Slides σας επιτρέπει να μετατρέψετε μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument σε εικόνες TIFF ξεχωριστά.

**Υπάρχει κάποιο όριο στον αριθμό των διαφανειών όταν μετατρέπεται μια παρουσίαση σε TIFF;**

Όχι, το Aspose.Slides δεν επιβάλλει περιορισμούς στον αριθμό των διαφανειών. Μπορείτε να μετατρέψετε παρουσιάσεις οποιουδήποτε μεγέθους σε μορφή TIFF.

**Διατηρούνται οι κινήσεις και τα εφέ μετάβασης του PowerPoint όταν μετατρέπονται οι διαφάνειες σε TIFF;**

Όχι, το TIFF είναι μορφότυπο στατικής εικόνας. Συνεπώς, οι κινήσεις και τα εφέ μετάβασης δεν διατηρούνται· εξάγονται μόνο στατικές στιγμιότυπες των διαφανειών.