---
title: Μετατροπή PPT και PPTX σε PDF με JavaScript [Συμπεριλαμβάνονται Προχωρημένα Χαρακτηριστικά]
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
- συνημμένο
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDFs υψηλής ποιότητας, αναζητήσιμα, χρησιμοποιώντας το Aspose.Slides για Node.js, με γρήγορα παραδείγματα κώδικα και προχωρημένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint και OpenDocument (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF με JavaScript προσφέρει πολλά πλεονεκτήματα, όπως συμβατότητα με διαφορετικές συσκευές και διατήρηση της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυφές διαφάνειες, να προστατέψετε το PDF με κωδικό πρόσβασης, να εντοπίσετε υποκαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα τελικά έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στα παρακάτω μορφότυπα σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) εκθέτει τη μέθοδο [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) που χρησιμοποιείται τυπικά για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Σημείωση" %}}

Το Aspose.Slides for Node.js via Java εισάγει τις πληροφορίες API και τον αριθμό έκδοσης στα παραγόμενα έγγραφα. Για παράδειγμα, όταν μετατρέπεται μια παρουσίαση σε PDF, το Aspose.Slides γεμίζει το πεδίο Εφαρμογή με "*Aspose.Slides*" και το πεδίο PDF Producer με τιμή της μορφής "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα παραγόμενα έγγραφα.

{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα προκύπτοντα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται με ακρίβεια στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνων
* Πλαισίων κειμένου και σχημάτων
* Μορφοποίησης κειμένου
* Μορφοποίησης παραγράφων
* Υπερσύνδεσμων
* Κεφαλίδων και υποσέλιδων
* Κουκίδων
* Πινάκων

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί τις προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στις μέγιστες βαθμίδες ποιότητας.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Σημείωση" %}}

Το Aspose προσφέρει ένα δωρεάν διαδικτυακό [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που παρουσιάζει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να δοκιμάσετε αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες της κλάσης [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το τελικό PDF, να το κλειδώσετε με κωδικό ή να ορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Με τις προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ραστερ εικόνων, να καθορίσετε πώς θα διαχειρίζονται τα μετααρχεία, να ορίσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες και πολλά άλλα.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG 90, ανάλυση εικόνας 300 DPI, τα μετααρχεία αποθηκευμένα ως PNG και συμπίεση κειμένου Flate.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Διατήρηση Ενσωματωμένων Αρχείων OLE ως Συνημμένα PDF**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, ενδέχεται να θέλετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου καθώς και στις διαφάνειες. Καλέστε τη μέθοδο [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) με `true` για να διατηρήσετε τα ενσωματωμένα αρχεία OLE ως συνημμένα στο τελικό PDF.

Η προεπιλεγμένη τιμή είναι `false`: η προεπισκόπηση ή το εικονίδιο του αντικειμένου OLE αποτυπώνονται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν περιλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `true` συμπεριλαμβάνει επιπλέον τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν μετατρέπεται σε διαδραστικό φύλλο Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και την εξάγει σε PDF με το βιβλίο εργασίας συνημμένο.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Για να ελέγξετε το αποτέλεσμα:

1. Ανοίξτε το εξαγόμενο PDF σε έναν προβολέα που υποστηρίζει συνημμένα αρχεία, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το πάνελ **Attachments** του προβολέα και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα, ή ανοίξτε το άμεσα εάν ο προβολέας το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Σημείωση" %}}

Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A-1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A-2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A-3 επιτρέπει άλλου τύπου αρχεία, όπως βιβλία εργασίας Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί ειδικά για το Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν παρουσιάζει εξαγωγή PDF/A.

{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) της κλάσης [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο τελικό PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβάνοντας τυχόν κρυφές διαφάνειες.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Μετατροπή PowerPoint σε PDF Προστατευμένο με Κωδικό**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Τα δικαιώματα πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης εκτύπωσης υψηλής ποιότητας.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ανίχνευση Υποκατάστασης Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) της κλάσης [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) που επιτρέπει τον εντοπισμό υποκατάστασης γραμματοσειρών κατά τη μετατροπή παρουσίασης σε PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF και εκτυπώνει προειδοποιήσεις υποκατάστασης γραμματοσειρών στην κονσόλα. Μία προειδοποίηση εμφανίζεται μόνο όταν μια μη διαθέσιμη γραμματοσειρά αντικαθίσταται κατά την εξαγωγή.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Σημείωση" %}}

Για περισσότερες πληροφορίες σχετικά με την υποκατάσταση γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/nodejs-java/font-substitution/).

{{% /alert %}} 

### **Διαχείριση Γραμματοσειρών Χωρίς Αφιερωμένο Παχύ Στυλ**

Μια παρουσίαση μπορεί να εφαρμόσει έντονη μορφοποίηση σε κείμενο ακόμα και όταν η γραμματοσειρά δεν διαθέτει αφιερωμένη παχιά γραμματοσειρά. Το κείμενο μπορεί να εμφανιστεί έντονο μέσω συνθετικού bold, που παχύνει τεχνητά τα κανονικά γλύφους. Όταν αυτό το κείμενο φαίνεται πολύ βαρύ ή διαφέρει από την προδιαγεγραμμένη εμφάνιση στο PDF, δοκιμάστε να καλέσετε τη μέθοδο [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) με `true`. Αυτή η επιλογή αποδίδει το επηρεαζόμενο κείμενο ως bitmap κατά την εξαγωγή PDF και μπορεί να βελτιώσει την εμφάνισή του για ορισμένες γραμματοσειρές. Η προεπιλεγμένη τιμή είναι `false`.

Η δείγμα παρουσίαση περιλαμβάνει δύο πλαίσια κειμένου: ένα με κανονικό κείμενο και ένα με έντονη μορφοποίηση στην ίδια γραμματοσειρά, η οποία δεν διαθέτει αφιερωμένο παχύ στυλ. Το παρακάτω παράδειγμα φορτώνει την παρουσίαση, ενεργοποιεί τη ρητορική των μη υποστηριζόμενων στυλ γραμματοσειράς και την εξάγει σε PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Οι παρακάτω προεπισκοπήσεις δείχνουν το αποτέλεσμα με την επιλογή απενεργοποιημένη και ενεργοποιημένη. Σε αυτό το παράδειγμα, το έντονο κείμενο έχει βαρύτερα στίγματα όταν η επιλογή είναι απενεργοποιημένη. Με την επιλογή ενεργοποιημένη, τα στίγματα είναι πιο ελαφριά· το κανονικό κείμενο παραμένει αμετάβλητο. Συγκρίνετε τα αποτελέσματα πριν αποφασίσετε την ρύθμιση για την παρουσίασή σας.

| Επιλογή απενεργοποιημένη (`false`, η προεπιλογή) | Επιλογή ενεργοποιημένη (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Σε αυτό το παράδειγμα, η ενεργοποίηση της επιλογής μετατρέπει μόνο το έντονο κείμενο σε bitmap: δεν μπορεί να επιλεχθεί, αντιγραφεί ή αναζητηθεί ως κείμενο χωρίς OCR, και οι άκρες του εμφανίζονται πιο απαλές σε ζουμ 800%. Το κανονικό κείμενο παραμένει αναζητήσιμο. Με την επιλογή απενεργοποιημένη, και τα δύο κείμενα παραμένουν σε μορφή κειμένου.

Αυτή η επιλογή ρητορικά μετατρέπει το κείμενο που μορφοποιείται έντονα όταν η γραμματοσειρά δεν διαθέτει αφιερωμένο παχύ στυλ. Η [Font substitution](/slides/el/nodejs-java/font-substitution/) επιλέγει εναλλακτική γραμματοσειρά όταν η αρχική δεν είναι διαθέσιμη.

## **Μετατροπή Επιλεγμένων Διαφανειών PowerPoint σε PDF**

Το παρακάτω παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανειών σε αυτόν τον πίνακα είναι μηδενική βάση, και η είσοδος παρουσίασης πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Το παρακάτω παράδειγμα αντιγράφει την πρώτη διαφάνεια από μια παρουσίαση σε νέα παρουσίαση με μέγεθος διαφάνειας 612 × 792 points (8,5 × 11 ίντσες). Κλιμακώνει το περιεχόμενο της διαφάνειας ώστε να χωράει και εξάγει τη μοναδική διαφάνεια σε PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Αφαιρέστε τη κενή διαφάνεια που δημιουργήθηκε με τη νέα παρουσίαση.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF στην Προβολή Σημειώσεων Διαφάνειας**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις ομιλητή κάθε διαφάνειας κάτω από τη διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας δείχνει μια διαδικασία μετατροπής PowerPoint σε PDF που παράγει πολλαπλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Σημείωση" %}}

Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφότυπους. Μπορείτε να εκτελέσετε μετατροπές [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), και [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Άλλες εξειδικευμένες μετατροπές PDF—[PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—υποστηρίζονται επίσης.

{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία φιγούρα. Τα επιμέρους στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνητά αντικείμενα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη φιγούρα.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλαπλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τη διαδικασία για κάθε αρχείο προγραμματιστικά.

**Είναι δυνατόν να προστατεύσω με κωδικό το παραγόμενο PDF;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) για να ορίσετε κωδικό και να καθορίσετε δικαιώματα πρόσβασης κατά τη μετατροπή.

**Πώς συμπεριλαμβάνω κρυφές διαφάνειες στο PDF;**

Καλέστε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) με `true` στην κλάση [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες στο τελικό PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) και [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) για να διασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με [διάφορα πρότυπα](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), συμπεριλαμβανομένων PDF/A1a, PDF/A1b, και PDF/UA, εξασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Aspose.Slides for Node.js via Java Documentation](/slides/el/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)