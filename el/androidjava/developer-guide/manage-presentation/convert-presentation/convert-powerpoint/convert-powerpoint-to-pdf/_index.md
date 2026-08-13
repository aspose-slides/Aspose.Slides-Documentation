---
title: Μετατροπή PPT και PPTX σε PDF στο Android [Συμπεριλαμβανομένων Προχωρημένων Χαρακτηριστικών]
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
description: "Μετατέψτε τα PowerPoint PPT/PPTX σε PDF υψηλής ποιότητας, με δυνατότητα αναζήτησης, στη Java χρησιμοποιώντας το Aspose.Slides για Android, με γρήγορα παραδείγματα κώδικα και προχωρημένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε Android προσφέρει αρκετά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας μεταξύ διαφορετικών συσκευών και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε τις παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε τα αρχεία PDF με κωδικό πρόσβασης, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα τελικά έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να μετατρέψετε τις παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο `save`. Η κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) εκθέτει τη μέθοδο `save` που χρησιμοποιείται συνήθως για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Το Aspose.Slides για Android μέσω Java εισάγει τις πληροφορίες API και τον αριθμό έκδοσης του στα έγγραφα εξόδου. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides συμπληρώνει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή της μορφής "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να παραγγείλετε στο Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει τις παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και οι ιδιότητες αποδίδονται ακριβώς στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσεις
* Κεφαλίδες και υποσέλιδα
* Κουκκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτή την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση (PPT, PPTX, ODP κ.λπ.) σε PDF:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PowerPoint ή OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Αποθήκευση της παρουσίασης ως PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 
Το Aspose προσφέρει έναν δωρεάν διαδικτυακό **μετατροπέα PowerPoint σε PDF**(https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το τελικό PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ριζικές εικόνες, να καθορίσετε πώς πρέπει να αντιμετωπίζονται τα μετααρχεία, να ορίσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες και άλλα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με πολλές προσαρμοσμένες επιλογές:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Ορισμός ποιότητας για εικόνες JPG.
pdfOptions.setJpegQuality((byte)90);

// Ορισμός DPI για εικόνες.
pdfOptions.setSufficientResolution(300);

/// Ορισμός συμπεριφοράς για μετααρχεία.
pdfOptions.setSaveMetafilesAsPng(true);

// Ορισμός επιπέδου συμπίεσης κειμένου για το κειμενικό περιεχόμενο.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Ορισμός λειτουργίας συμμόρφωσης PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PowerPoint ή OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Αποθήκευση της παρουσίασης ως έγγραφο PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να περιλαμβάνονται:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PowerPoint ή OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Δημιουργία της κλάσης PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Προσθήκη κρυφών διαφανειών.
    pdfOptions.setShowHiddenSlides(true);

    // Αποθήκευση της παρουσίασης ως PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF προστατευμένο με κωδικό πρόσβασης χρησιμοποιώντας τις παραμέτρους προστασίας από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PowerPoint ή OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Δημιουργία της κλάσης PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Ορισμός κωδικού πρόσβασης PDF και δικαιωμάτων πρόσβασης.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Αποθήκευση της παρουσίασης ως PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Εντοπισμός Αντικαταστάσεων Γραμματοσειράς**

Το Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/), επιτρέποντάς σας να εντοπίσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

Αυτός ο κώδικας δείχνει πώς να εντοπίσετε αντικαταστάσεις γραμματοσειρών:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PowerPoint ή OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Ορισμός της συνάρτησης προειδοποίησης στις επιλογές PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Αποθήκευση της παρουσίασης ως PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Υλοποίηση της συνάρτησης προειδοποίησης.
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

{{%  alert color="info"  %}} 
Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/androidjava/font-substitution/).
{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μόνο συγκεκριμένες διαφάνειες από μια παρουσίαση PowerPoint σε PDF:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PowerPoint ή OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Ορισμός πίνακα αριθμών διαφανειών.
    int[] slides = { 1, 3 };

    // Αποθήκευση της παρουσίασης ως PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με καθορισμένο μέγεθος διαφάνειας:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PowerPoint ή OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Δημιουργία νέας παρουσίασης με προσαρμοσμένο μέγεθος διαφάνειας.
Presentation resizedPresentation = new Presentation();

try {
    // Ορισμός προσαρμοσμένου μεγέθους διαφάνειας.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Κλωνοποίηση της πρώτης διαφάνειας από την αρχική παρουσίαση.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Αφαίρεση της κενής διαφάνειας με την οποία δημιουργήθηκε η νέα παρουσίαση.
    resizedPresentation.getSlides().removeAt(1);

    // Αποθήκευση της προσαρμοσμένης παρουσίασης ως PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων**

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF που περιλαμβάνει σημειώσεις:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PowerPoint ή OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Διαμόρφωση των επιλογών PDF με διάταξη Σημειώσεων.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Αποθήκευση της παρουσίασης σε PDF με σημειώσεις.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση και Πρότυπα Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας δείχνει μια διαδικασία μετατροπής PowerPoint σε PDF που παράγει πολλαπλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

```java
import com.aspose.slides.*;

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
Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/java/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/el/java/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/el/java/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/el/java/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF σε SVG](https://products.aspose.com/slides/el/java/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/java/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/el/java/conversion/pdf-to-xml/)—υποστηρίζονται επίσης.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως ένα ενιαίο σχήμα. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνικά εφέ· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρο το σχήμα.

## **FAQ**

### Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τη διαδικασία για τα αρχεία σας και να εφαρμόσετε τη μετατροπή προγραμματιστικά.

### Είναι δυνατόν να προστατεύσω με κωδικό πρόσβασης το PDF που μετατράπηκε;

Απόλυτα. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

### Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;

Χρησιμοποιήστε τη μέθοδο `setShowHiddenSlides` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

### Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;

Ναι, μπορείτε να ελέγξετε την ποιότητα των εικόνων χρησιμοποιώντας μεθόδους όπως `setJpegQuality` και `setSufficientResolution` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/) για να εξασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

### Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDFs που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων των PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για Android μέσω Java](/slides/el/androidjava/)
- [Αναφορά API Aspose.Slides για Android μέσω Java](https://reference.aspose.com/slides/el/androidjava/)
- [Δωρεάν διαδικτυακοί μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)