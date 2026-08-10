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
- Επιλογές εξαγωγής SVG
- διαδραστικό SVG
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εξάγετε διαφάνειες PowerPoint ως εικόνες SVG σε PHP και ελέγξτε τις γραμματοσειρές, το κείμενο, τις εικόνες, τα αναγνωριστικά και τα συμβάντα με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια επεκτάσιμη εικόνα βασισμένη σε XML που λειτουργεί καλά για δημοσιεύσεις στο web, προβολείς διαφανειών, ροές εργασίας προσβασιμότητας και αυτοματοποιημένη μετα‑επεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/) όταν το εξαχθέν SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή με τη μέθοδο [Slide.writeAsSvg](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#writeAsSvg). Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια μιας παρουσίασης σε ξεχωριστό αρχείο SVG.

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

Το όνομα αρχείου χρησιμοποιεί τη μέθοδο [Slide.getSlideNumber](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getSlideNumber) αντί για τον δείκτη του βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με τη μέθοδο [Shape.writeAsSvg](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#writeAsSvg) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

[SVGOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, η μέθοδος [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setUseFrameSize) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και η [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setUseFrameRotation) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) σε `true` όταν το κείμενο πρέπει να αποδίδεται χωρίς λιγᾶτες.

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

### **Διανυσματοποίηση όλου του κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setVectorizeText) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις από γραμματοσειρές και κάνει το οπτικό αποτέλεσμα πιο συνεπές σε διαφορετικά προγράμματα περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ήαναζητήσιμο ως κείμενο SVG.

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

Η μέθοδος [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να παραπέμπετε σε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να συμπεριλάβετε τα δεδομένα γραμματοσειράς στο SVG, ή `Vectorize` για να αποδοθούν μόνο τα κείμενα που χρησιμοποιούν εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε την άδεια χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

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

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setPicturesCompression) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) για να παραλείψετε τις περικομμένες περιοχές της πηγής, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setJpegQuality) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος στην πιστότητα της εικόνας ή στα διατηρημένα δεδομένα εικόνας.

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

## **Ανάθεση σταθερών αναγνωριστικών σε σχήματα και κείμενο**

Παρέχετε μια συνάρτηση κλήσης μορφοποίησης στο [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setShapeFormattingController) για να ορίσετε το [SvgShape.setId](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgshape/#setId) για κάθε σχήμα SVG. Η συνάρτηση κλήσης μπορεί επίσης να ορίσει τιμές [SvgTSpan.setId](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgtspan/#setId) στα στοιχεία κειμένου `tspan`.

Το PhpJavaBridge δεν μπορεί να καλέσει μια PHP συνάρτηση από το `writeAsSvg` όταν εκτελείται σε λειτουργία ροής. Τοποθετήστε τη λογική μορφοποίησης σε μια μικρή βοηθητική κλάση Java, μεταγλωττίστε την και προσθέστε το παραγόμενο αρχείο JAR στη διαδρομή κλάσεων της γέφυρας. Ο βοηθός μπορεί να χρησιμοποιήσει τη μέθοδο [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getOfficeInteropShapeId), η οποία είναι σταθερή για τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα τμήματα κειμένου του. Δείτε την [Java implementation of `StableSvgIdController`](/slides/el/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) για τον κώδικα του βοηθού.

Αφού προσθέσετε την μεταγλωττισμένη κλάση `com.example.slides.StableSvgIdController` στη διαδρομή κλάσεων της γέφυρας, δημιουργήστε μια παρουσία της από το PHP και αναθέστε τη στο `SVGOptions`:

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

Σε μια συνάρτηση κλήσης μορφοποίησης, καλέστε το [SvgShape.setEventHandler](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgshape/#setEventHandler) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgevent/) για να προσθέσετε έναν διαχειριστή συμβάντων JavaScript σε ένα εξαγόμενο σχήμα. Αναθέστε τη συνάρτηση κλήσης με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setShapeFormattingController) και ορίστε τη λειτουργία JavaScript στη σελίδα ή το έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

Όπως και με τα σταθερά αναγνωριστικά, υλοποιήστε τη συνάρτηση κλήσης σε έναν βοηθό Java όταν το PhpJavaBridge χρησιμοποιεί λειτουργία ροής. Η [Java implementation of `SvgEventController`](/slides/el/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) αναθέτει ένα ID και έναν διαχειριστή `OnClick` σε ένα σχήμα με όνομα `ActionButton`. Μεταγλωττίστε αυτόν τον βοηθό, προσθέστε τον στη διαδρομή κλάσεων της γέφυρας ως `com.example.slides.SvgEventController`, και χρησιμοποιήστε τον από το PHP ως εξής:

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

Η σελίδα-φιλοξενητής μπορεί να ορίσει τη λειτουργία JavaScript στην οποία αναφέρεται ο διαχειριστής. Η ανάθεση IDs και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **Συχνές ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setVectorizeText) αντί για το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#setVectorizeText) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές θα πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να μειώσετε το μέγεθος ενός SVG;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περικομμένων περιοχών εικόνας και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το στοχευόμενο περιβάλλον μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το διανυσματισμένο κείμενο έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε IDs μέσω μιας συνάρτησης κλήσης μορφοποίησης, στη συνέχεια επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετα‑επεξεργασίας ή στο σενάριο του φυλλομετρητή.