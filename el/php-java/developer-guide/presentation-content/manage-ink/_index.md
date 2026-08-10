---
title: Διαχείριση Αντικειμένων Μελάνης Παρουσίασης σε PHP
linktitle: Διαχείριση Μελάνης
type: docs
weight: 95
url: /el/php-java/manage-ink/
keywords:
- μελάνη
- αντικείμενο μελάνης
- ίχνος μελάνης
- διαχείριση μελάνης
- σχεδίαση μελάνης
- σχεδίαση
- εξαγωγή μελάνης
- απόδοση μελάνης
- απόκρυψη μελάνης
- InkOptions
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τα αντικείμενα μελάνης του PowerPoint, επεξεργαστείτε τα ίχνη και τις ιδιότητες του πινέλου, και ελέγξτε την εμφάνιση της μελάνης κατά την εξαγωγή σε PDF, HTML, SVG, TIFF και εικόνες με το Aspose.Slides για PHP μέσω Java."
---
## **Εισαγωγή**

Το PowerPoint παρέχει μια λειτουργία μελάνης που σας επιτρέπει να σχεδιάζετε ελεύθερες γραμμές. Η μελάνη μπορεί να χρησιμοποιηθεί για να επισημάνει άλλα αντικείμενα, να δείξει συνδέσεις και διαδικασίες, και να τραβήξει την προσοχή σε συγκεκριμένα στοιχεία σε μια διαφάνεια.

Η Aspose.Slides παρέχει τους τύπους που απαιτούνται για εργασία με αντικείμενα μελάνης. Για παράδειγμα, η κλάση [Ink](https://reference.aspose.com/slides/el/php-java/aspose.slides/ink/) αντιπροσωπεύει ένα αντικείμενο μελάνης σε μια διαφάνεια.

## **Διαφορές μεταξύ Κανονικών Αντικειμένων και Αντικειμένων Μελάνης**

Τα αντικείμενα σε μια διαφάνεια PowerPoint συνήθως αντιπροσωπεύονται από αντικείμενα [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) . Στην πιο απλή μορφή του, ένα σχήμα είναι ένα δοχείο που ορίζει την περιοχή του ίδιου του αντικειμένου (το πλαίσιο του) μαζί με ιδιότητες όπως το μέγεθος του δοχείου, το σχήμα και το φόντο. Για περισσότερες πληροφορίες, δείτε το [Shape Layout Format](https://docs.aspose.com/slides/el/php-java/shape-manipulations/#access-layout-formats-for-shape).

Ωστόσο, όταν το PowerPoint επεξεργάζεται ένα αντικείμενο μελάνης, αγνοεί όλες τις ιδιότητες του πλαισίου του αντικειμένου (δοχείου) εκτός από το μέγεθός του. Το μέγεθος της περιοχής του δοχείου καθορίζεται από τις τυπικές μεθόδους [Shape.getWidth](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getWidth) και [Shape.getHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ίχνη Μελάνης**

Ένα ίχνος μελάνης είναι ένα βασικό στοιχείο που χρησιμοποιείται για την καταγραφή της τροχιάς ενός στυλό καθώς ο χρήστης γράφει ψηφιακή μελάνη. Ένα ίχνος αποθηκεύει μια ακολουθία συνδεδεμένων σημείων.

Η πιο απλή μορφή κωδικοποίησης προσδιορίζει τις συντεταγμένες X και Y κάθε σημείου δείγματος. Όταν όλα τα συνδεδεμένα σημεία αποδοθούν, παράγουν μια εικόνα όπως αυτή:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ιδιότητες Πινέλου για Σχεδίαση**

Ένα πινέλο χρησιμοποιείται για τη σχεδίαση γραμμών που συνδέουν τα σημεία ενός ιχνός μελάνης. Το πινέλο έχει το δικό του χρώμα και μέγεθος, τα οποία αντιπροσωπεύονται από τις μεθόδους [InkBrush.getColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkbrush/#getColor) και [InkBrush.getSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkbrush/#getSize).

### **Ορισμός Χρώματος Πινέλου Μελάνης**

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε το χρώμα ενός πινέλου μελάνης:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Ορισμός Μεγέθους Πινέλου Μελάνης**

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε το μέγεθος ενός πινέλου μελάνης:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Γενικά, το πλάτος και το ύψος ενός πινέλου δεν ταιριάζουν, έτσι το PowerPoint δεν εμφανίζει το μέγεθος του πινέλου (η αντίστοιχη ενότητα δεδομένων είναι αμυδρή). Όταν το πλάτος και το ύψος του πινέλου ταιριάζουν, το PowerPoint εμφανίζει το μέγεθός του με αυτόν τον τρόπο:

![ink_powerpoint3](ink_powerpoint3.png)

Για σαφήνεια, ας αυξήσουμε το ύψος του αντικειμένου μελάνης και ας εξετάσουμε τις σημαντικές διαστάσεις:

![ink_powerpoint4](ink_powerpoint4.png)

Το δοχείο (πλαίσιο) δεν λαμβάνει υπόψη το μέγεθος των πινέλων — υποθέτει πάντα ότι το πάχος της γραμμής είναι μηδέν (δείτε την προηγούμενη εικόνα).

Συνεπώς, για να προσδιοριστεί η ορατή περιοχή ολόκληρου του αντικειμένου μελάνης, πρέπει να ληφθεί υπόψη το μέγεθος του πινέλου στα ίχνη του. Εδώ, το αντικείμενο-στόχος (το ίχνος του χειρόγραφου κειμένου) έχει κλιμακωθεί στο μέγεθος του δοχείου (πλαισίου). Όταν το μέγεθος του δοχείου αλλάζει, το μέγεθος του πινέλου παραμένει σταθερό και αντίστροφα.

![ink_powerpoint5](ink_powerpoint5.png)

Το PowerPoint χρησιμοποιεί παρόμοια συμπεριφορά για αντικείμενα κειμένου:

![ink_powerpoint6](ink_powerpoint6.png)

## **Έλεγχος Εμφάνισης Μελάνης Κατά την Εξαγωγή και Απόδοση**

Η Aspose.Slides παρέχει την κλάση [InkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/) για τον έλεγχο του πώς εμφανίζονται τα αντικείμενα μελάνης στην εξαγόμενη ή αποδοθείσα έξοδο. Μπορείτε να χρησιμοποιήσετε τις ιδιότητές της για να κρύψετε εντελώς τη μελάνη ή να αλλάξετε τον τρόπο που ερμηνεύονται οι λειτουργίες μάσκας πινέλου μελάνης.

Οι επιλογές μελάνης διατίθενται μέσω των επιλογών εξαγωγής ή απόδοσης για διάφορους τύπους εξόδου:

| Έξοδος | Ιδιότητα επιλογών μελάνης |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Οι ακόλουθες μέθοδοι της κλάσης [InkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/) εκθέτουν τις ίδιες δύο ρυθμίσεις:

- Η [InkOptions.getHideInk](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#getHideInk) καθορίζει αν τα αντικείμενα μελάνης περιλαμβάνονται στην έξοδο. Η προεπιλεγμένη τιμή της είναι `false`.
- Η [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) καθορίζει αν μια λειτουργία μάσκας ερμηνεύεται ως αδιαφάνεια κατά την απόδοση ενός πινέλου μελάνης. Η προεπιλεγμένη τιμή της είναι `true`. Καλέστε την [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) με `false` για να χρησιμοποιήσετε τη λειτουργία ROP αντί αυτού.

### **Απόκρυψη Αντικειμένων Μελάνης στην Έξοδο PDF**

Από προεπιλογή, τα αντικείμενα μελάνης παραμένουν ορατά κατά την εξαγωγή. Για να δημιουργήσετε μια καθαρή έξοδο χωρίς χειρόγραφες σημειώσεις ή άλλα περιεχόμενα μελάνης, καλέστε την [InkOptions.setHideInk](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#setHideInk) με `true`.

Το παρακάτω παράδειγμα PHP εξάγει μια παρουσίαση σε PDF ενώ κρύβει όλα τα αντικείμενα μελάνης:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Απόκρυψη Αντικειμένων Μελάνης Κατά την Απόδοση Διαφάνειας ως Εικόνα**

Για να κρύψετε τα αντικείμενα μελάνης κατά την απόδοση των διαφανειών ως bitmap εικόνες, ρυθμίστε την [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/#getInkOptions) και περάστε τις ρυθμίσεις απόδοσης στην [Slide.getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getImage).

Το παρακάτω παράδειγμα PHP αποδίδει την πρώτη διαφάνεια ως εικόνα PNG χωρίς αντικείμενα μελάνης:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Έλεγχος Απόδοσης Μάσκας Μελάνης**

Η ρύθμιση [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) ελέγχει τον τρόπο με τον οποίο ερμηνεύονται οι λειτουργίες μάσκας κατά την απόδοση πινέλων μελάνης. Η προεπιλεγμένη τιμή είναι `true`, που χρησιμοποιεί την αδιαφάνεια. Για να χρησιμοποιήσετε τη λειτουργία ROP αντί αυτού, καλέστε την [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) με `false`.

Το παρακάτω παράδειγμα PHP εξάγει μια διαφάνεια σε SVG και χρησιμοποιεί απόδοση βασισμένη σε ROP για λειτουργίες μάσκας μελάνης:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Η ίδια ρύθμιση μπορεί να εφαρμοστεί μέσω της [TiffOptions.getInkOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/#getInkOptions) όταν εξάγεται μια παρουσίαση ή αποδίδεται μια διαφάνεια σε TIFF.

### **Επιλογή Αν Θα Κρύψετε ή Θα Διατηρήσετε τη Μελάνη**

Όταν χρειάζεστε μια καθαρή έκδοση μιας σχολιασμένης παρουσίασης για διανομή χωρίς σημάδια ανασκόπησης, καλέστε την [InkOptions.setHideInk](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#setHideInk) με `true` κατά την εξαγωγή.

Διατηρήστε την [InkOptions.getHideInk](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#getHideInk) στην προεπιλεγμένη τιμή `false` όταν οι σημειώσεις μελάνης αποτελούν μέρος του προοριζόμενου περιεχομένου, όπως σχόλια ανασκόπησης, χειρόγραφες σημειώσεις, επισημάνσεις ή σχέδια που πρέπει να παραμείνουν ορατά στο εξαγόμενο αποτέλεσμα. Αυτό επιτρέπει στις εφαρμογές να παράγουν ξεχωριστές εξόδους ανασκόπησης και τελικές από την ίδια παρουσίαση χωρίς να τροποποιούν τα αρχικά αντικείμενα μελάνης.

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω το χρώμα ή το μέγεθος μιας υπάρχουσας γραμμής μελάνης;**

Ναι. Ανακτήστε το ίχνος από το [Ink.getTraces](https://reference.aspose.com/slides/el/php-java/aspose.slides/ink/#getTraces), στη συνέχεια αλλάξτε το [InkTrace.getBrush](https://reference.aspose.com/slides/el/php-java/aspose.slides/inktrace/#getBrush). Καλέστε το [InkBrush.setColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkbrush/#setColor) ή το [InkBrush.setSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkbrush/#setSize) για να αλλάξετε το πινέλο.

**Αλλάζει η απόκρυψη της μελάνης την πηγαία παρουσίαση;**

Όχι. Η κλήση της [InkOptions.setHideInk](https://reference.aspose.com/slides/el/php-java/aspose.slides/inkoptions/#setHideInk) επηρεάζει μόνο το αποδοθέν ή εξαγόμενο αποτέλεσμα· δεν αφαιρεί ή τροποποιεί τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

**Ποιοι τύποι εξαγωγής υποστηρίζουν επιλογές μελάνης;**

Μπορείτε να ρυθμίσετε τις επιλογές μελάνης για PDF, HTML, SVG, TIFF και bitmap εικόνες διαφανειών μέσω των αντίστοιχων επιλογών εξαγωγής ή απόδοσης που εμφανίζονται παραπάνω.

**Περαιτέρω ανάγνωση**

* Για γενικές πληροφορίες σχετικά με τα σχήματα, δείτε την ενότητα [PowerPoint Shapes](https://docs.aspose.com/slides/el/php-java/powerpoint-shapes/).
* Για περισσότερες πληροφορίες σχετικά με τις αποτελεσματικές τιμές, δείτε το [Shape Effective Properties](https://docs.aspose.com/slides/el/php-java/shape-effective-properties/#get-effective-font-height-value).
* Για λεπτομέρειες σχετικά με την εξαγωγή PDF, δείτε το [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/el/php-java/convert-powerpoint-to-pdf/).
* Για λεπτομέρειες σχετικά με την εξαγωγή HTML, δείτε το [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/el/php-java/convert-powerpoint-to-html/).
* Για λεπτομέρειες σχετικά με την εξαγωγή SVG, δείτε το [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/el/php-java/render-a-slide-as-an-svg-image/).
* Για λεπτομέρειες σχετικά με την εξαγωγή TIFF, δείτε το [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/el/php-java/convert-powerpoint-to-tiff/).
* Για λεπτομέρειες σχετικά με την απόδοση διαφάνειας σε εικόνα, δείτε το [Convert Presentation Slides to Images](https://docs.aspose.com/slides/el/php-java/convert-slide/).