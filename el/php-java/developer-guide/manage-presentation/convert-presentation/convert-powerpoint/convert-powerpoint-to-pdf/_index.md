---
title: Μετατροπή PPT και PPTX σε PDF σε PHP [Συμπεριλαμβανομένα Προηγμένα Χαρακτηριστικά]
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/php-java/convert-powerpoint-to-pdf/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- PowerPoint σε PDF
- παρουσίαση σε PDF
- PPT σε PDF
- μετατροπή PPT σε PDF
- PPTX σε PDF
- μετατροπή PPTX σε PDF
- αποθήκευση PowerPoint ως PDF
- αποθήκευση PPT ως PDF
- αποθήκευση PPTX ως PDF
- εξαγωγή PPT σε PDF
- εξαγωγή PPTX σε PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDF υψηλής ποιότητας, με δυνατότητα αναζήτησης, σε PHP χρησιμοποιώντας το Aspose.Slides, με γρήγορα παραδείγματα κώδικα και προχωρημένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF με PHP προσφέρει πολλά πλεονεκτήματα, όπως συμβατότητα σε διαφορετικές συσκευές και διατήρηση της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε τις παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατέψετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε υποκαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στα ακόλουθα μορφότυπα σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Παρουσίαση](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο `save`. Η κλάση [Παρουσίαση](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) εκθέτει τη μέθοδο `save` η οποία συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Το Aspose.Slides για PHP μέσω Java εισάγει τις πληροφορίες του API του και τον αριθμό έκδοσης στα παραγόμενα έγγραφα. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides συμπληρώνει το πεδίο Εφαρμογή με “*Aspose.Slides*” και το πεδίο PDF Producer με μια τιμή στη μορφή “*Aspose.Slides v XX.XX*”. **Σημείωση** ότι δεν μπορείτε να ζητήσετε από το Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα παραγόμενα έγγραφα.

{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, εξασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και οι ιδιότητες αποδίδονται με ακρίβεια κατά τη μετατροπή, συμπεριλαμβανομένου:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδα
* Κουκκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις με το μέγιστο επίπεδο ποιότητας.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση (PPT, PPTX, ODP κ.λπ.) σε PDF:

```php
# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Αποθηκεύστε την παρουσίαση ως PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Η Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές — ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/PdfOptions) — που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς θα συνεχίσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ρευστές εικόνες, να καθορίσετε πώς θα διαχειριστούν οι μετααρχεία, να ορίσετε επίπεδο συμπίεσης για κείμενο, να διαμορφώσετε την ανάλυση DPI για εικόνες, και πολλά άλλα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με αρκετές προσαρμοσμένες επιλογές.

```php
# Δημιουργήστε ένα αντικείμενο της κλάσης PdfOptions.
$pdfOptions = new PdfOptions();

# Ορίστε την ποιότητα για εικόνες JPG.
$pdfOptions->setJpegQuality(90);

# Ορίστε DPI για τις εικόνες.
$pdfOptions->setSufficientResolution(300);

# Ορίστε τη συμπεριφορά για τα μετααρχεία.
$pdfOptions->setSaveMetafilesAsPng(true);

# Ορίστε το επίπεδο συμπίεσης κειμένου για το κειμενικό περιεχόμενο.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Ορίστε τη λειτουργία συμμόρφωσης PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Αποθηκεύστε την παρουσίαση ως έγγραφο PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/PdfOptions) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να περιλαμβάνονται:

```php
# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Δημιουργήστε ένα αντικείμενο της κλάσης PdfOptions.
    $pdfOptions = new PdfOptions();

    # Προσθέστε κρυφές διαφάνειες.
    $pdfOptions->setShowHiddenSlides(true);

    # Αποθηκεύστε την παρουσίαση ως PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού Πρόσβασης**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με προστασία κωδικού πρόσβασης, χρησιμοποιώντας τις παραμέτρους προστασίας από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/):

```php
# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Δημιουργήйте ένα αντικείμενο της κλάσης PdfOptions.
    $pdfOptions = new PdfOptions();

    # Ορίστε κωδικό πρόσβασης PDF και δικαιώματα πρόσβασης.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Αποθηκεύστε την παρουσίαση ως PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Εντόπιση Υποκατάστασης Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/#setWarningCallback) στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/), επιτρέποντάς σας να εντοπίσετε υποκατάσταση γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

Αυτός ο κώδικας δείχνει πώς να εντοπίσετε υποκαταστάσεις γραμματοσειρών:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Ορίστε την κλήση προειδοποίησης στις επιλογές PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Αποθηκεύστε την παρουσίαση ως PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

Για περισσότερες πληροφορίες σχετικά με την υποκατάσταση γραμματοσειρών, δείτε το άρθρο [Υποκατάσταση Γραμματοσειρών](/slides/el/php-java/font-substitution/).

{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών σε PowerPoint σε PDF**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μόνο συγκεκριμένες διαφάνειες από μια παρουσίαση PowerPoint σε PDF:

```php
# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Ορίστε πίνακα με αριθμούς διαφανειών.
    $slides = array(1, 3);

    # Αποθηκεύστε την παρουσίαση ως PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με καθορισμένο μέγεθος διαφάνειας:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Δημιουργήστε μια νέα παρουσίαση με προσαρμοσμένο μέγεθος διαφάνειας.
$resizedPresentation = new Presentation();

try {
    # Ορίστε το προσαρμοσμένο μέγεθος διαφάνειας.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Κλωνοποιήστε την πρώτη διαφάνεια από την αρχική παρουσίαση.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Αποθηκεύστε την προσαρμοσμένη παρουσίαση σε PDF με σημειώσεις.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF που περιλαμβάνει σημειώσεις:

```php
# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Διαμορφώστε τις επιλογές PDF με διάταξη σημειώσεων.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Κατευθυντήριες Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας δείχνει μια διαδικασία μετατροπής PowerPoint σε PDF που παράγει πολλαπλά PDFs βάσει διαφορετικών προτύπων συμμόρφωσης:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/php-java/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/el/php-java/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/el/php-java/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/el/php-java/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές — [PDF σε SVG](https://products.aspose.com/slides/el/php-java/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/php-java/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/el/php-java/conversion/pdf-to-xml/) — υποστηρίζονται επίσης.

{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως ένα ενιαίο σχήμα. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνικά απομεινάρια· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρο το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Μπορεί να προστατευτεί με κωδικό πρόσβασης το μετατρεπόμενο PDF;**

Απολύτως. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Χρησιμοποιήστε τη μέθοδον `setShowHiddenSlides` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως `setJpegQuality` και `setSufficientResolution` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/) για να εξασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDFs που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων των PDF/A1a, PDF/A1b και PDF/UA, εξασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για PHP μέσω Java](/slides/el/php-java/)
- [Αναφορά API Aspose.Slides για PHP μέσω Java](https://reference.aspose.com/slides/el/php-java/)
- [Δωρεάν Διαδικτυακοί Μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)