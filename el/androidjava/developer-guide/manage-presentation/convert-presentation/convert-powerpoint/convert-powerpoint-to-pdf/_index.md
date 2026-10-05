---
title: Μετατροπή PPT και PPTX σε PDF σε Android [Συμπερίληψη Προηγμένων Χαρακτηριστικών]
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
- συνημμένο
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε υψηλής ποιότητας, αναζητήσιμα PDF σε Java χρησιμοποιώντας το Aspose.Slides για Android, με γρήγορα παραδείγματα κώδικα και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή των παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε Android προσφέρει πολλά πλεονεκτήματα, όπως συμβατότητα μεταξύ διαφορετικών συσκευών και διατήρηση της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε τις παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυφές διαφάνειες, να προστατέψετε το αρχείο PDF με κωδικό πρόσβασης, να ανιχνεύσετε την υποκατάσταση γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα εξαγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και, στη συνέχεια, αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Η κλάση [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) εκθέτει τη μέθοδο [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) που χρησιμοποιείται συνήθως για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java εισάγει τις πληροφορίες API και τον αριθμό έκδοσης του στα εξαγόμενα έγγραφα. Για παράδειγμα, όταν μετατρέπεται μια παρουσίαση σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή στη μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να ζητήσετε από το Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα εξαγόμενα έγγραφα.
{{% /alert %}}

Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται με ακρίβεια στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδα
* Κουκκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint‑σε‑PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτή την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στο μέγιστο επίπεδο ποιότητας.

Το ακόλουθο παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

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
Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που δείχνει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να δοκιμάσετε αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το τελικό PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για raster εικόνες, να καθορίσετε πώς θα αντιμετωπίζονται τα metafiles, να θέσετε επίπεδο συμπίεσης για το κείμενο, να διαμορφώσετε DPI για τις εικόνες και άλλα.

Το ακόλουθο παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG 90, ανάλυση εικόνας 300 DPI, metafiles αποθηκευμένα ως PNG και συμπίεση κειμένου Flate.

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

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, μπορείτε να θέλετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου εργασίας καθώς και να βλέπουν τις διαφάνειες. Καλέστε τη μέθοδο [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) με `true` για να διατηρήσετε τα ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `false`: η προεπισκόπηση του αντικειμένου OLE ή το εικονίδιο του αποδίδεται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν συμπεριλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `true` προστίθενται επιπλέον τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν μετατρέπεται σε διαδραστικό φύλλο Excel στη σελίδα PDF.

Το ακόλουθο παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και το εξάγει σε PDF με το βιβλίο εργασίας συνημμένο.

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

1. Ανοίξτε το εξαχθέν PDF σε πρόγραμμα προβολής που υποστηρίζει συνημμένα αρχεία, όπως το Adobe Acrobat Reader.
2. Ανοίξτε τον πίνακα **Attachments** του προγράμματος και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να εξετάσετε τα δεδομένα του, ή ανοίξτε το απευθείας εφόσον το πρόγραμμα προβολής το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι χωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A‑1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A‑2 επιτρέπεται μόνο συνημμένα PDF/A, και το PDF/A‑3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων βιβλίων εργασίας Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί ειδικά για το Aspose.Slides. Το παράδειγμα αυτό χρησιμοποιεί τη προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν δείχνει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) από την κλάση [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Το ακόλουθο παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβάνοντας όλες τις κρυφές διαφάνειες.

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

### **Μετατροπή PowerPoint σε PDF με Κωδικό Πρόσβασης**

Το ακόλουθο παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Τα δικαιώματα πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης της εκτύπωσης υψηλής ποιότητας.

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

### **Ανίχνευση Υποκατάστασης Γραμματοσειρών**

Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) στην κλάση [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), η οποία σας επιτρέπει να ανιχνεύσετε υποκατάσταση γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF.

Το ακόλουθο παράδειγμα εξάγει μια παρουσίαση σε PDF και εκτυπώνει προειδοποιήσεις υποκατάστασης γραμματοσειρών στην κονσόλα. Μια προειδοποίηση εκτυπώνεται μόνο όταν μια μη διαθέσιμη γραμματοσειρά αντικαθίσταται κατά την εξαγωγή.

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
Για περισσότερες πληροφορίες σχετικά με την υποκατάσταση γραμματοσειρών, δείτε το άρθρο [**Υποκατάσταση Γραμματοσειρών**](/slides/el/androidjava/font-substitution/).
{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Το ακόλουθο παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανειών σε αυτόν τον πίνακα είναι 1‑βασισμένοι, και η εισερχόμενη παρουσίαση πρέπει να περιλαμβάνει τουλάχιστον τρεις διαφάνειες.

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

Το ακόλουθο παράδειγμα αντιγράφει την πρώτη διαφάνεια από μια παρουσίαση σε νέα παρουσίαση με μέγεθος διαφάνειας 612 × 792 points (8,5 × 11 ίντσες). Κλιμακώνει το περιεχόμενο της διαφάνειας ώστε να χωρά και εξάγει τη μοναδική διαφάνεια σε PDF.

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

    // Αφαιρέστε τη κενή διαφάνεια με την οποία δημιουργήθηκε η νέα παρουσίαση.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Το ακόλουνο παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις ομιλητή κάθε διαφάνειας κάτω από τη διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

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

Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Κατευθύνσεις Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b** και **PDF/UA**.

Αυτός ο κώδικας δείχνει μια διαδικασία μετατροπής PowerPoint‑σε‑PDF που παράγει πολλαπλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

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
Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF σε SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—υποστηρίζονται επίσης.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία μορφή. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τέλη· κείμενο εναλλακτικής περιγραφής παρέχεται μόνο για ολόκληρη τη μορφή.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει την μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματικά.

**Μπορεί να προστατευθεί με κωδικό πρόσβασης το εξαγόμενο PDF;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διάρκεια της μετατροπής.

**Πώς να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Καλέστε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) με `true` στην κλάση [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) για να συμπεριληφθούν οι κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) και [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) στην κλάση [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) για να διασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με [διάφορα πρότυπα](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), συμπεριλαμβανομένων PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Aspose.Slides for Android via Java Documentation](/slides/el/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)