---
title: Μετατροπή PPT και PPTX σε PDF στο Android [Συμπεριλαμβανομένων Προηγμένων Χαρακτηριστικών]
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDFs υψηλής ποιότητας, αναζητήσιμα, σε Java χρησιμοποιώντας το Aspose.Slides για Android, με γρήγορα παραδείγματα κώδικα και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε Android προσφέρει πολλά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας σε διαφορετικές συσκευές και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Το Aspose.Slides για Android μέσω Java σας επιτρέπει να μετατρέψετε παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και, στη συνέχεια, αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο `save`. Η κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) εκθέτει τη μέθοδο `save` που συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Το Aspose.Slides για Android μέσω Java εισάγει τις πληροφορίες API και τον αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με «*Aspose.Slides*» και το πεδίο PDF Producer με μια τιμή σε μορφή «*Aspose.Slides v XX.XX*». **Σημείωση** ότι δεν μπορείτε να ζητήσετε από το Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Στοιχεία και ιδιότητες αποδίδονται με ακρίβεια στη μετατροπή, συμπεριλαμβανομένου:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσεις
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστη ρύθμιση στα μέγιστα επίπεδα ποιότητας.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση (PPT, PPTX, ODP κ.λπ.) σε PDF:

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Το Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που δείχνει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές — ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) — που σάς επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να το κλειδώσετε με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ραστερ εικόνες, να καθορίσετε πώς θα χειρίζονται τα μετααρχεία, να ορίσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες και περισσότερα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με πολλές προσαρμοσμένες επιλογές.

```java
// Δημιουργήστε την κλάση PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Ορίστε την ποιότητα για εικόνες JPG.
pdfOptions.setJpegQuality((byte)90);

// Ορίστε το DPI για εικόνες.
pdfOptions.setSufficientResolution(300);

/// Ορίστε τη συμπεριφορά για μετααρχεία.
pdfOptions.setSaveMetafilesAsPng(true);

// Ορίστε το επίπεδο συμπίεσης κειμένου για το κειμενικό περιεχόμενο.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Ορίστε τη λειτουργία συμμόρφωσης PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Αποθηκεύστε την παρουσίαση ως έγγραφο PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Αν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να συμπεριλαμβάνονται:

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Δημιουργήστε την κλάση PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Προσθέστε κρυφές διαφάνειες.
    pdfOptions.setShowHiddenSlides(true);

    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF προστατευμένο με κωδικό, χρησιμοποιώντας τις παραμέτρους προστασίας από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/):

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Δημιουργήστε την κλάση PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Ορίστε κωδικό πρόσβασης PDF και δικαιώματα πρόσβασης.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ανίχνευση Αντικαταστάσεων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/), επιτρέποντάς σας να εντοπίσετε αντικαταστάσεις γραμματοσειρών κατά τη διάρκεια της διαδικασίας μετατροπής παρουσίασης σε PDF.

Αυτός ο κώδικας δείχνει πώς να εντοπίσετε αντικατάσταση γραμματοσειρών:

```java
public static void main(String[] args) {
    // Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
    Presentation presentation = new Presentation("sample.pptx");

    // Ορίστε την κλήση προειδοποίησης στις επιλογές PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Υλοποίηση της κλήσης προειδοποίησης.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 
Για περισσότερες πληροφορίες σχετικά με τις αντικαταστάσεις γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/androidjava/font-substitution/).
{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μόνο συγκεκριμένες διαφάνειες από μια παρουσίαση PowerPoint σε PDF:

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Ορίστε πίνακα αριθμών διαφανειών.
    int[] slides = { 1, 3 };

    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με καθορισμένο μέγεθος διαφάνειας:

```java
float slideWidth = 612;
float slideHeight = 792;

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Δημιουργήστε μια νέα παρουσίαση με προσαρμοσμένο μέγεθος διαφάνειας.
Presentation resizedPresentation = new Presentation();

try {
    // Ορίστε προσαρμοσμένο μέγεθος διαφάνειας.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Κλωνοποιήστε την πρώτη διαφάνεια από την αρχική παρουσίαση.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Αποθηκεύστε την αλλαγμένη παρουσίαση σε PDF με σημειώσεις.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Μετροπή PowerPoint σε PDF με Προβολή Σημειώσεων Διαφάνειας**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF που περιλαμβάνει σημειώσεις:

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Διαμορφώστε τις επιλογές PDF με διάταξη σημειώσεων.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση και Πρότυπα Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b** και **PDF/UA**.

Αυτός ο κώδικας δείχνει μια διαδικασία μετατροπής PowerPoint σε PDF που παράγει πολλαπλά PDF με βάση διαφορετικά πρότυπα συμμόρφωσης:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF to HTML](https://products.aspose.com/slides/el/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/el/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/el/java/conversion/pdf-to-jpg/), και [PDF to PNG](https://products.aspose.com/slides/el/java/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές — [PDF to SVG](https://products.aspose.com/slides/el/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/el/java/conversion/pdf-to-tiff/), και [PDF to XML](https://products.aspose.com/slides/el/java/conversion/pdf-to-xml/) — υποστηρίζονται επίσης.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει τα σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία εικόνα. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνουργήματα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη σκηνή.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλαπλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματισμένα.

**Μπορεί να προστατευτεί με κωδικό πρόσβασης το μετατρεπόμενο PDF;**

Απόλυτα. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε τα δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Χρησιμοποιήστε τη μέθοδο `setShowHiddenSlides` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) για να συμπεριλάβετε κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως `setJpegQuality` και `setSufficientResolution` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) για να διασφαλίσετε εικόνες υψηλής ποιότητας στο PDF.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων των PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για Android μέσω Java](/slides/el/androidjava/)
- [Αναφορά API Aspose.Slides για Android μέσω Java](https://reference.aspose.com/slides/el/androidjava/)
- [Δωρεάν Διαδικτυακοί Μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)