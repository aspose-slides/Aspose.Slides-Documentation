---
title: Μετατροπή PPT και PPTX σε PDF στη Java [Συμπεριλαμβανομένα Προηγμένα Χαρακτηριστικά]
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/java/convert-powerpoint-to-pdf/
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
- συνημμένο
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDFs υψηλής ποιότητας και αναζητήσιμα στη Java χρησιμοποιώντας το Aspose.Slides, με γρήγορα παραδείγματα κώδικα και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF στη Java προσφέρει πολλά πλεονεκτήματα, όπως συμβατότητα μεταξύ διαφορετικών συσκευών και διατήρηση της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατέψετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Με το Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στη κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Η κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) εκθέτει τη μέθοδο [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) η οποία χρησιμοποιείται συνήθως για μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for Java εισάγει τις πληροφορίες του API του και τον αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή μορφής "*Aspose.Slides v XX.XX*". **Note** ότι δεν μπορείτε να ζητήσετε από το Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και οι ιδιότητες αποδίδονται ακριβώς στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφου
* Συνδέσμοι
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint‑σε‑PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Το Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που δείχνει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες της κλάσης [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το τελικό PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για raster εικόνες, να καθορίσετε πώς θα χειριστούν τα metafiles, να θέσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες και άλλα.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Διατήρηση Ενσωματωμένων Αρχείων OLE ως Συνημμένα PDF**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, ίσως θέλετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου εργασίας καθώς και να βλέπουν τις διαφάνειες. Καλέστε τη μέθοδο [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) με `true` για να διατηρήσετε τα ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `false`: η προεπισκόπηση ή το εικονίδιο του αντικειμένου OLE αποδίδεται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν περιλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `true` προστίθενται επιπλέον τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν μετατρέπεται σε διαδραστικό φύλλο εργασίας Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και το εξάγει σε PDF με το βιβλίο εργασίας συνημμένο.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Για να ελέγξετε το αποτέλεσμα:

1. Ανοίξτε το εξαχθέν PDF σε έναν προβολέα που υποστηρίζει συνημμένα αρχεία, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το πίνακα **Attachments** του προβολέα και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να εξετάσετε τα δεδομένα του, ή ανοίξτε το απευθείας αν ο προβολέας το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A‑1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A‑2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A‑3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων βιβλίων εργασίας Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί που σχετίζονται ειδικά με το Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν δείχνει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) της κλάσης [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Τα δικαιώματα πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης εκτύπωσης υψηλής ποιότητας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Εντοπισμός Αντικατάστασης Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) στην κλάση [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), επιτρέποντας να εντοπίσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/java/font-substitution/).
{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφάνειων από PowerPoint σε PDF**

Το παρακάτω παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφάνειας σε αυτόν τον πίνακα είναι 1‑βασισμένοι και η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Το παρακάτω παράδειγμα αντιγράφει την πρώτη διαφάνεια από μια παρουσίαση σε νέα παρουσίαση με μέγεθος διαφάνειας 612 × 792 points (8.5 × 11 ίντσες). Κλιμακώνει το περιεχόμενο της διαφάνειας ώστε να ταιριάζει και εξάγει τη μονή διαφάνεια σε PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Αφαιρέστε τη κενή διαφάνεια που δημιουργήθηκε με τη νέα παρουσίαση.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF στην Προβολή Σημειώσεων Διαφάνειας**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις του ομιλητή κάτω από κάθε διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε διαδικασία μετατροπής που συμμορφώνεται με τις [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b** και **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντας τη μετατροπή αρχείων PDF σε δημοφιλή μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF σε image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε ειδικές μορφές—[PDF σε SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—υποστηρίζονται επίσης.
{{% /alert %}}

> **Note:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως ένα ενιαίο σχήμα. Τα επιμέρους στοιχεία μονοπατιού δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως ατέλειες· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρο το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει τη μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να διατρέξετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Είναι δυνατόν να προστατέψω με κωδικό πρόσβασης το μετατρεπόμενο PDF;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς συμπεριλαμβάνω κρυφές διαφάνειες στο PDF;**

Καλέστε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) με `true` στην κλάση [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα της εικόνας χρησιμοποιώντας μεθόδους όπως [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) και [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) στην κλάση [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) ώστε να εξασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), συμπεριλαμβανομένων PDF/A1a, PDF/A1b και PDF/UA, εξασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για Java](/slides/el/java/)
- [Αναφορά API Aspose.Slides για Java](https://reference.aspose.com/slides/java/)
- [Δωρεάν Διαδικτυακοί Μετατροπείς Aspose](https://products.aspose.app/slides/conversion)