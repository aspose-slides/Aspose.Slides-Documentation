---
title: Απόδοση διαφανειών παρουσίασης ως εικόνες SVG σε PHP
linktitle: Διαφάνεια σε SVG
type: docs
weight: 50
url: /el/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint σε SVG
- παρουσίαση σε SVG
- διαφάνεια σε SVG
- PPT σε SVG
- PPTX σε SVG
- επιλογές εξαγωγής SVG
- διαδραστικό SVG
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εξάγετε διαφάνειες PowerPoint ως εικόνες SVG σε PHP και ελέγξτε γραμματοσειρές, κείμενο, εικόνες, IDs και συμβάντα με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι ένα κλιμακώσιμο μορφότυπο εικόνας βασισμένο σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, ροές προσβασιμότητας και αυτοματοποιημένη μετα-επεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή με [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Το ακόλουθο παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Το όνομα αρχείου χρησιμοποιεί [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) αντί του δείκτη βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο εκείνο το σχήμα.

## **Διαμόρφωση εξόδου SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) ελέγχει την απόδοση SVG. Για πλαίσια κειμένου, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) σε `true` όταν το κείμενο πρέπει να αποδοθεί χωρίς συνδετικά.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Έλεγχος κειμένου και γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε εάν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, και πώς οι εξωτερικές γραμματοσειρές συμπεριλαμβάνονται ή αναφέρονται. Οι παρακάτω επιλογές σας βοηθούν να εξισορροπήσετε τη οπτική συνέπεια, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειρών στο εξαγόμενο SVG.

### **Διανυσματισμός όλου του κειμένου**

Ορίστε [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό αφαιρεί τις εξαρτήσεις γραμματοσειρών και κάνει το οπτικό αποτέλεσμα πιο συνεπές σε όλα τα προγράμματα περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Επιλέξτε πώς θα διαχειριστούν οι εξωτερικές γραμματοσειρές**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να αναφέρετε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να συμπεριλάβετε δεδομένα γραμματοσειράς στο SVG, ή `Vectorize` για να αποδδώσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε την άδεια χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Μείωση μεγέθους ενσωματωμένων εικόνων**

Χρησιμοποιήστε [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) για να παραλείψετε τα περικομμένα τμήματα της πηγής, και [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου εις βάρος της πιστότητας της εικόνας ή των διατηρημένων δεδομένων εικόνας.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Έλεγχος ανάλυσης rasterization μετααρχείου**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) ορίζει το κατώτερο όριο ανάλυσης για rasterization μετααρχείων κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να εξισορροπήσετε τις λεπτομέρειες και το μέγεθος του αρχείου όταν μια εικόνα EMF ή WMF rasterize. Δεν ορίζει καθολικό DPI για το SVG ούτε αναγκάζει κάθε αντικείμενο στη διαφάνεια να γίνει raster εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), το οποίο περιέχει μια εικόνα EMF με κοντά διαγώνιες γραμμές. Το ακόλουθο παράδειγμα εξάγει την πρώτη διαφάνειά του σε τρεις αναλύσεις rasterization μέσω [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ίδιες ώστε τα αποτελέσματα να συγκρίνονται.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

Στο αποτέλεσμα, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν τη δοθείσα παρουσίαση· δεν αποτελούν γενικό τύπο μετατροπής DPI σε διαστάσεις pixel.

| Rasterization DPI μετααρχείου | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η παρακάτω σύγκριση δείχνει την ίδια περιοχή του ενσωματωμένου raster στην ίδια μεγεθυμένη προβολή. Οι διαγώνιες γραμμές εμφανίζουν ορατή εικονοστοιχία στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή αλλάζει κάθε εξαγόμενη εικόνα.

![Μεγεθυμένη λεπτομέρεια διαγώνιας γραμμής στα 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) ελέγχει τη μείωση της ανάλυσης εικόνας και μπορεί να καλύψει την επίδραση της αλλαγής της ανάλυσης rasterization μετααρχείου. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization μετααρχείου.

## **Ανάθεση σταθερών ταυτοτήτων σε σχήματα και κείμενο**

Παρέχετε μια callback μορφοποίησης στο [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) για να ορίσετε το [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) για κάθε σχήμα SVG. Η callback μπορεί επίσης να ορίσει τιμές [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) στα στοιχεία κειμένου `tspan`.

PhpJavaBridge δεν μπορεί να καλέσει μια PHP callback από `writeAsSvg` όταν εκτελείται σε λειτουργία ροής. Τοποθετήστε τη λογική μορφοποίησης σε μια μικρή βοηθητική κλάση Java, μεταγλωττίστε τη και προσθέστε το παραγόμενο αρχείο JAR στην κλάση διαδρομής της γέφυρας. Η βοηθητική κλάση μπορεί να χρησιμοποιήσει [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), η οποία είναι σταθερή για τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα τμήματα κειμένου του. Δείτε την [Java implementation of `StableSvgIdController`](/slides/el/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) για τον κώδικα βοήθειας.

After adding the compiled `com.example.slides.StableSvgIdController` class to the bridge classpath, instantiate it from PHP and assign it to `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Προσθήκη χειριστών συμβάντων SVG**

Σε μια callback μορφοποίησης, καλέστε [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) για να προσθέσετε έναν JavaScript χειριστή συμβάντος σε ένα εξαγόμενο σχήμα. Αναθέστε την callback με [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) και ορίστε τη λειτουργία JavaScript στη σελίδα ή στο έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

Όπως και με τις σταθερές ταυτοτήτες, υλοποιήστε την callback σε μια βοηθητική κλάση Java όταν το PhpJavaBridge χρησιμοποιεί λειτουργία ροής. Η [Java implementation of `SvgEventController`](/slides/el/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) εκχωρεί έναν ID και έναν χειριστή `OnClick` σε ένα σχήμα με όνομα `ActionButton`. Μεταγλωττίστε αυτήν τη βοηθητική κλάση, προσθέστε την στην κλάση διαδρομής της γέφυρας ως `com.example.slides.SvgEventController`, και χρησιμοποιήστε τη από PHP ως εξής:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Η σελίδα-ξενιστής μπορεί να ορίσει τη λειτουργία JavaScript που αναφέρεται από τον χειριστή. Η ανάθεση IDs και χειριστών συμβάντων επιτρέπει σε προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **FAQ**

**Πότε πρέπει να χρησιμοποιήσω [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) αντί για [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήστε [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να μειώσετε το μέγεθος ενός SVG;**

Ξεκινήστε συμπιέζοντας τις ενσωματωμένες εικόνες, διαγράφοντας τα περικομμένα τμήματα εικόνας και επιλέγοντας συνδεδεμένα αρχεία γραμματοσειρών όταν το περιβάλλον στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και ο διανυσματισμός κειμένου έχουν διαφορετικές ανταλλαγές ποιότητας-μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε IDs μέσω μιας callback μορφοποίησης, έπειτα επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετά-επεξεργασίας ή στο σενάριο του προγράμματος περιήγησης.