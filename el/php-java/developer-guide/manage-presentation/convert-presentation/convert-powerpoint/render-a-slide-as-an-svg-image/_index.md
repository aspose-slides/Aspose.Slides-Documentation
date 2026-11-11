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
description: "Εξάγετε διαφάνειες PowerPoint ως εικόνες SVG σε PHP και ελέγξτε τις γραμματοσειρές, το κείμενο, τις εικόνες, τα IDs και τα συμβάντα με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι ένα επεκτάσιμο φορμότ εικόνας βασισμένο σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, διαδικασίες προσβασιμότητας και αυτοματοποιημένη επεξεργασία μετά τη δημιουργία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγξετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή με τη μέθοδο [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια μιας παρουσίασης σε ξεχωριστό αρχείο SVG.

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

Το όνομα αρχείου χρησιμοποιεί το [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) αντί για τον δείκτη του βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με τη μέθodu [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο εκείνο το σχήμα.

## **Διαμόρφωση εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) σε `true` όταν το κείμενο πρέπει να αποδοθεί χωρίς λιγάρια.

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

## **Έλεγχος περικοπής άκρων γραμμής σε άκρα βελών**

Το SVG 1.1 δεν διαθέτει ρύθμιση εσωτερικού περιθωρίου σημαδιού για να καθορίσει πού πρέπει να σταματήσει μια γραμμή κάτω από την άκρη ενός βέλους. Από προεπιλογή, το Aspose.Slides συντομεύει τη εξαγόμενη γραμμή ώστε η γραμμή του stroke να μην ξεπροβάλλει το σημάδι. Κλήστε το [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) με `true` για να σχεδιάσετε τη γραμμή μέχρι το αρχικό άκρο της γραμμής. Αυτή η ρύθμιση επηρεάζει μόνο την έξοδο SVG. Η γραμμή διατηρεί τη θέση και το μήκος της στη διαφάνεια.

Το παράδειγμα σχεδιάζει άκρα βέλους σε σχήμα τριγώνου και διαμαντιού σε γραμμές πλάτους 2 και 10 σημείων. Εξάγει την ίδια διαφάνεια δυο φορές, αλλάζοντας μόνο την επιλογή περικοπής.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Η σύγκριση εμφανίζει το τριγωνικό άκρο βέλους στη γραμμή των 10 σημείων. Όταν η περικοπή είναι ενεργοποιημένη, η άκρη είναι αιχμηρή. Όταν η περικοπή είναι απενεργοποιημένη, η γραμμή (stroke) προεξέχει από τις κλίσιμες πλευρές του σημαδιού και αφήνει μια επίπεδη άκρη.

![Μεγεθυμένο τρίγωνο 10 σημείων με αιχμηρή άκρη όταν η περικοπή είναι ενεργοποιημένη και επίπεδη άκρη όταν η περικοπή είναι απενεργοποιημένη](line-end-cropping.png)

Στις άλλες γραμμές του παραδείγματος, η προεξέχουσα γραμμή είναι λιγότερο εμφανής στο τρίγωνο των 2 σημείων. Το γεμιστό διαμάντι καλύπτει το άκρο της γραμμής και στα δύο πλάτη.

## **Έλεγχος κειμένου και γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε αν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, καθώς και πώς οι εξωτερικές γραμματοσειρές περιλαμβάνονται ή παραπέμπονται. Οι παρακάτω επιλογές σας βοηθούν να εξισορροπήσετε τη οπτική συνέπεια, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειρών στο εξαγόμενο SVG.

### **Διανυσματισμός όλων του κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις από γραμματοσειρές και καθιστά το οπτικό αποτέλεσμα πιο συνεπές σε διαφορετικά προγράμματα περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

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

### **Επιλέξτε πώς διαχειρίζονται οι εξωτερικές γραμματοσειρές**

Το [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) για τις γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να παραπέμπετε σε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να ενσωματώσετε τα δεδομένα γραμματοσειράς στο SVG, ή `Vectorize` για να αποδώσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Ελέγξτε την άδεια χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

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

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) για να παραλείψετε τις περικομμένες περιοχές πηγής, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος την πιστότητα της εικόνας ή τα διατηρημένα δεδομένα εικόνας.

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

Το [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) ορίζει το κατώτερο όριο ανάλυσης για τη rasterization μετααρχείων κατά τη διάρκεια της εξαγωγής SVG. Χρησιμοποιήστε το για να εξισορροπήσετε τη λεπτομέρεια και το μέγεθος του αρχείου όταν μια εικόνα EMF ή WMF rasterizes. Δεν ορίζει παγκόσμια τιμή DPI για το SVG ούτε αναγκάζει κάθε αντικείμενο στη διαφάνεια να μετατραπεί σε raster εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), το οποίο περιέχει μια εικόνα EMF με κοντινά διαγώνια γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη διαφάνειά του σε τρεις αναλύσεις rasterization μέσω του [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ίδιες ώστε να μπορούν να συγκριθούν τα αποτελέσματα.

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

Στο αποτέλεσμα, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν την παρεχόμενη παρουσίαση· δεν αποτελούν γενική φόρμουλα μετατροπής DPI σε διαστάσεις pixel.

| DPI rasterization μετααρχείου | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω δείχνει την ίδια περιοχή του ενσωματωμένου raster στο ίδιο μεγεθυμένο μέγεθος προβολής. Οι διαγώνιες γραμμές παρουσιάζουν ορατή εικονοστοιχία στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή δεν αλλάζει κάθε εξαγόμενη εικόνα.

![Μεγεθυμένη λεπτομέρεια διαγώνιων γραμμών στα 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

Το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) ελέγχει τη μείωση ανάλυσης εικόνας και μπορεί να καλύψει την επίδραση της αλλαγής της ανάλυσης rasterization μετααρχείου. Το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization μετααρχείου.

## **Ανάθεση σταθερών IDs σε σχήματα και κείμενο**

Παρέχετε μια επανάκληση μορφοποίησης στο [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) για να ορίσετε το [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) για κάθε σχήμα SVG. Η επανάκληση μπορεί επίσης να ορίσει τιμές [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) σε στοιχεία `tspan` κειμένου.

Το PhpJavaBridge δεν μπορεί να καλέσει μια PHP επανάκληση από το `writeAsSvg` όταν εκτελείται σε λειτουργία ροής. Τοποθετήστε τη λογική μορφοποίησης σε μια μικρή βοηθητική κλάση Java, τη μεταγλωττίστε και προσθέστε το προκύπτον αρχείο JAR στο classpath της γέφυρας. Η βοηθήτρια κλάση μπορεί να χρησιμοποιήσει το [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), που είναι σταθερό για τη διάρκεια του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα κείμενα του. Δείτε την [Java implementation of `StableSvgIdController`](/slides/el/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) για τον κώδικα της βοηθού.

Αφού προσθέσετε τη μεταγλωττισμένη κλάση `com.example.slides.StableSvgIdController` στο classpath της γέφυρας, δημιουργήστε μια εμφάνιση από PHP και αναθέστε την στο `SVGOptions`:

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

Σε μια επανάκληση μορφοποίησης, καλέστε το [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή JavaScript συμβάντος σε ένα εξαγόμενο σχήμα. Αναθέστε την επανάκληση με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) και ορίστε τη λειτουργία JavaScript στη σελίδα ή στο έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

Όπως και με τα σταθερά IDs, υλοποιήστε την επανάκληση σε μια βοηθήτρια κλάση Java όταν το PhpJavaBridge χρησιμοποιεί λειτουργία ροής. Η [Java implementation of `SvgEventController`](/slides/el/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) αναθέτει ένα ID και έναν χειριστή `OnClick` σε ένα σχήμα με το όνομα `ActionButton`. Μεταγλωττίστε αυτήν την βοηθήτρια κλάση, προσθέστε την στο classpath της γέφυρας ως `com.example.slides.SvgEventController` και χρησιμοποιήστε την από PHP ως εξής:

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

Η σελίδα-φιλοξενητής μπορεί να ορίσει τη λειτουργία JavaScript που αναφέρεται από το χειριστή. Η ανάθεση IDs και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) αντί για το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να μειώσετε το μέγεθος ενός SVG;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περικομμένων περιοχών εικόνας και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το περιβάλλον προορισμού μπορεί να τα σερβίρει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και ο διανυσματισμός του κειμένου έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω στοιχεία του εξαγόμενου SVG μετά την εξαγωγή;**

Ναι. Αναθέστε IDs μέσω μιας επανάκλησης μορφοποίησης, μετά επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετα‑επεξεργασίας ή στο σενάριο του προγράμματος περιήγησης.