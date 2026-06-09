---
title: Μετατροπή PPT και PPTX σε PDF με JavaScript [Συμπεριλαμβάνονται Προχωρημένες Λειτουργίες]
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/nodejs-java/convert-powerpoint-to-pdf/
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
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDFs υψηλής ποιότητας, αναζητήσιμα, χρησιμοποιώντας Aspose.Slides για Node.js, με γρήγορα παραδείγματα κώδικα και προχωρημένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint και OpenDocument (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF με JavaScript προσφέρει αρκετά πλεονεκτήματα, όπως η συμβατότητα σε διάφορες συσκευές και η διατήρηση της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε τα αρχεία PDF με κωδικό πρόσβασης, να εντοπίσετε αντικαταστάσεις γραμματοσειράς, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα έγγραφα εξόδου.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις παρακάτω μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και έπειτα αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο `save`. Η κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) εκθέτει τη μέθοδο `save`, η οποία συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Το Aspose.Slides για Node.js μέσω Java εισάγει τις πληροφορίες API και τον αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή σε μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να κατευθύνετε το Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.

{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα προκύπτοντα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά απεικονίζονται ακριβώς στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υποσυνδέσμους
* Κεφαλίδες και υποσέλίδες
* Κουκκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση (PPT, PPTX, ODP κ.λπ.) σε PDF:

```js
// Δημιουργήστε μια παρουσίαση της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Το Aspose προσφέρει έναν δωρεάν διαδικτυακό [**μετατροπέα PowerPoint σε PDF**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που παρουσιάζει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές — ιδιότητες της κλάσης [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/) — που σας επιτρέπουν να προσαρμόσετε το τελικό PDF, να το κλειδώσετε με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για εικόνες raster, να καθορίσετε τον τρόπο διαχείρισης των μετααρχείων, να ορίσετε επίπεδο συμπίεσης για το κείμενο, να ρυθμίσετε DPI για τις εικόνες και άλλα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με πολλές προσαρμοσμένες επιλογές.

```js
// Δημιουργήστε την κλάση PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Set the quality for JPG images.
pdfOptions.setJpegQuality(java.newByte(90));

// Set DPI for images.
pdfOptions.setSufficientResolution(300);

// Set the behavior for metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Define the PDF compliance mode.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Αποθηκεύστε την παρουσίαση ως έγγραφο PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Αν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PdfOptions) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο προκύπτον PDF.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να περιλαμβάνονται:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Δημιουργήστε την κλάση PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Προσθέστε κρυφές διαφάνειες.
    pdfOptions.setShowHiddenSlides(true);

    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Αυτός ο κώδικας JavaScript επιδεικνύει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF προστατευμένο με κωδικό πρόσβασης χρησιμοποιώντας τις παραμέτρους προστασίας από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PdfOptions):

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Δημιουργήστε την κλάση PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Ορίστε κωδικό πρόσβασης PDF και δικαιώματα πρόσβασης.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Εντοπισμός Αντικατάστασης Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PdfOptions), επιτρέποντάς σας να εντοπίσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

Αυτός ο κώδικας JavaScript δείχνει πώς να εντοπίσετε αντικαταστάσεις γραμματοσειρών:

```js
// Ορίστε το callback προειδοποίησης στις επιλογές PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Αποθηκεύστε την παρουσίαση ως PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
    warning: function (warning) {
        if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
            console.warn("Font substitution warning: " + warning.getDescription());
        }
        return aspose.slides.ReturnAction.Continue;
    }
});
```

{{%  alert color="primary"  %}} 

Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών PowerPoint σε PDF**

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μόνο συγκεκριμένες διαφάνειες από μια παρουσίαση PowerPoint σε PDF:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Ορίστε πίνακα αριθμών διαφανειών.
    let slides = java.newArray("int", [1, 3]);

    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με καθορισμένο μέγεθος διαφάνειας:

```js
const slideWidth = 612;
const slideHeight = 792;

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Δημιουργήστε μια νέα παρουσίαση με προσαρμοσμένο μέγεθος διαφάνειας.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Ορίστε το προσαρμοσμένο μέγεθος διαφάνειας.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Κλωνοποιήστε την πρώτη διαφάνεια από την αρχική παρουσίαση.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Αποθηκεύστε τη μετασχηματισμένη παρουσίαση σε PDF με σημειώσεις.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις Διαφάνειας**

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF που περιλαμβάνει σημειώσεις:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Διαμορφώστε τις επιλογές PDF με διάταξη σημειώσεων.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b** και **PDF/UA**.

Αυτός ο κώδικας JavaScript επιδεικνύει μια διαδικασία μετατροπής PowerPoint σε PDF που παράγει πολλαπλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντας τη μετατροπή αρχείων PDF σε δημοφιλή μορφότυπα. Μπορείτε να εκτελέσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/nodejs-java/conversion/pdf-to-html/), [PDF σε JPG](https://products.aspose.com/slides/el/nodejs-java/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/el/nodejs-java/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε ειδικές μορφές — [PDF σε SVG](https://products.aspose.com/slides/el/nodejs-java/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/nodejs-java/conversion/pdf-to-tiff/) — επίσης υποστηρίζονται.

{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλοκα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία μορφή. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και ενδέχεται να σημειώνονται ως τεχνουργήματα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη μορφή.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε μέσω των αρχείων σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Δυνατή είναι η προστασία του μετατρεπόμενου PDF με κωδικό;**

Απολύτως. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PdfOptions) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Χρησιμοποιήστε τη μέθοδο `setShowHiddenSlides` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PdfOptions) για να συμπεριλάβετε κρυφές διαφάνειες στο προκύπτον PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνων στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα των εικόνων χρησιμοποιώντας μεθόδους όπως `setJpegQuality` και `setSufficientResolution` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PdfOptions) για να εξασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με διάφορα πρότυπα, όπως PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για Node.js μέσω Java](/slides/el/nodejs-java/)
- [Αναφορά API Aspose.Slides για Node.js μέσω Java](https://reference.aspose.com/slides/el/nodejs-java/)
- [Δωρεάν Διαδικτυακοί Μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)