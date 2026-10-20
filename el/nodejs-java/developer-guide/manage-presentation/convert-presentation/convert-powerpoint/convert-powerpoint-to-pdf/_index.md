---
title: Μετατροπή PPT και PPTX σε PDF με JavaScript [Συμπεριλαμβάνονται Προηγμένες Λειτουργίες]
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
description: "Μετατροπή PowerPoint PPT/PPTX σε υψηλής ποιότητας, αναζητήσιμα PDF χρησιμοποιώντας Aspose.Slides για Node.js, με γρήγορα παραδείγματα κώδικα και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint και OpenDocument (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF με JavaScript προσφέρει αρκετά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας σε διάφορες συσκευές και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) εκθέτει τη μέθοδο [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) που συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java inserts its API information and version number into output documents. For example, when converting a presentation to PDF, Aspose.Slides populates the Application field with "*Aspose.Slides*" and the PDF Producer field with a value in "*Aspose.Slides v XX.XX*" form. **Σημείωση** ότι δεν μπορείτε να υποδείξετε στην Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα παραγόμενα έγγραφα.
{{% /alert %}}

Aspose.Slides allows you to convert:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα παραγόμενα PDFs ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται με ακρίβεια στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσεις
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint‑σε‑PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, η Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

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

{{% alert color="info" title="Note" %}}
Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που δείχνει τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με επιλογές**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) class—that allow you to customize the resulting PDF, lock the PDF with a password, or specify how the conversion process should proceed.

### **Μετατροπή PowerPoint σε PDF με προσαρμοσμένες επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για raster images, να καθορίσετε πώς θα διαχειριστούν τα metafiles, να θέσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες και άλλα.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG 90, ανάλυση εικόνας 300 DPI, metafiles αποθηκευμένα ως PNG και συμπίεση κειμένου Flate.

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

### **Αυτόματη επιλογή συμπίεσης εικόνας**

Καλέστε τη μέθοδο [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) με `true` για να επιλέξετε αυτόματα τον πιο κατάλληλο αλγόριθμο συμπίεσης για κάθε εικόνα κατά την εξαγωγή PDF.

Το παρακάτω παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση, ενεργοποιεί την αυτόματη επιλογή συμπίεσης εικόνας και την αποθηκεύει ως έγγραφο PDF. Όλες οι άλλες ρυθμίσεις εξαγωγής PDF διατηρούν τις προεπιλογές τους.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Αυτή η επιλογή επιλέγει έναν αλγόριθμο συμπίεσης για κάθε εικόνα. Η μείωση της τιμής που περνιέται στη [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) μειώνει την ποιότητα εικόνας JPEG, ενώ η μείωση της τιμής που περνιέται στη [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) επιτρέπει την μειωμένη ανάλυση των εικόνων, γεγονός που μπορεί να μειώσει τις λεπτομέρειες. Η ενεργοποίηση της αυτόματης επιλογής συμπίεσης δεν μειώνει αυτόματα καμία από αυτές τις ρυθμίσεις.

Η επιλογή αλγόριθμων συμπίεσης απαιτεί επιπλέον χρόνο επεξεργασίας και μνήμη. Η μείωση του μεγέθους εξαρτάται από τις εικόνες της παρουσίασης και τις ρυθμίσεις εξαγωγής· δεν υπάρχει εγγυημένη σταθερή μείωση για κάθε παρουσίαση.

### **Διατήρηση ενσωματωμένων αρχείων OLE ως συνημμένα PDF**

Καλέστε τη μέθοδο [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) με `true` για να διατηρήσετε ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `false`: η εικόνα προεπισκόπησης ή το εικονίδιο του αντικειμένου OLE αποδίδεται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν συμπεριλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `true` συμπεριλαμβάνει επίσης τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο χωριστά. Το αντικείμενο OLE δεν γίνεται διαδραστικό φύλλο Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και το εξάγει σε PDF με το βιβλίο εργασίας συνημμένο.

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

1. Ανοίξτε το εξαγόμενο PDF σε πρόγραμμα προβολής που υποστηρίζει συνημμένα αρχεία, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το πάνελ **Attachments** του προγράμματος προβολής και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα του, ή ανοίξτε το απευθείας εάν το πρόγραμμα προβολής το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Οι προδιαγραφές PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A‑1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A‑2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A‑3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων βιβλίων εργασίας Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί ειδικά για την Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλογή συμμόρφωσης PDF και δεν δείχνει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με κρυφές διαφάνειες**

Καλέστε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβανομένων τυχόν κρυφών διαφανειών.

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

### **Μετατροπή PowerPoint σε PDF με προστασία κωδικού πρόσβασης**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Οι άδειες πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης της εκτύπωσης υψηλής ποιότητας.

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

### **Ανίχνευση αντικατάστασης γραμματοσειρών**

Η Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) που σας επιτρέπει να εντοπίσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF και εκτυπώνει προειδοποιήσεις αντικατάστασης γραμματοσειρών στην κονσόλα. Μια προειδοποίηση εκτυπώνεται μόνο όταν μια μη διαθέσιμη γραμματοσειρά αντικαθίσταται κατά την εξαγωγή.

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

{{% alert color="info" title="Note" %}}
Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [**Αντικατάσταση γραμματοσειράς**](/slides/el/nodejs-java/font-substitution/).
{{% /alert %}} 

### **Διαχείριση γραμματοσειρών χωρίς ξεχωριστό έντονο στυλ**

Μια παρουσίαση μπορεί να εφαρμόζει έντονη μορφοποίηση σε κείμενο ακόμη και όταν η γραμματοσειρά της δεν διαθέτει ξεχωριστό έντονο στυλ. Το κείμενο μπορεί να εμφανίζεται έντονο μέσω συνθετικού bolding, που πάχυνει τεχνητά τα κανονικά γλύφη. Όταν αυτό το κείμενο φαίνεται υπερβολικά βαρύ ή διαφέρει από την επιδιωκόμενη εμφάνιση στο PDF, δοκιμάστε να καλέσετε τη μέθοδο [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) με `true`. Αυτή η επιλογή αποδίδει το επηρεαζόμενο κείμενο ως bitmap κατά την εξαγωγή PDF και μπορεί να βελτιώσει την εμφάνισή του για ορισμένες γραμματοσειρές. Η προεπιλογή είναι `false`.

Η δείγμα παρουσίαση περιέχει δύο πλαίσια κειμένου: ένα με κανονικό κείμενο και ένα με έντονη μορφοποίηση στην ίδια γραμματοσειρά που δεν έχει ξεχωριστό έντονο στυλ. Το παρακάτω παράδειγμα φορτώνει την παρουσίαση, ενεργοποιεί την rasterization των μη υποστηριζόμενων στυλ γραμματοσειράς και την εξάγει σε PDF:

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

Οι παρακάτω προεμφανίσεις δείχνουν το αποτέλεσμα με την επιλογή απενεργοποιημένη και ενεργοποιημένη. Σε αυτό το παράδειγμα, το έντονο κείμενο έχει πιο παχιές γραμμές όταν η επιλογή είναι απενεργοποιημένη. Με την επιλογή ενεργοποιημένη, οι γραμμές είναι ελαφρύτερες· το κανονικό κείμενο παραμένει αμετάβλητο. Συγκρίνετε τα αποτελέσματα πριν επιλέξετε τη ρύθμιση για την παρουσίασή σας.

| Επιλογή απενεργοποιημένη (`false`, η προεπιλογή) | Επιλογή ενεργοποιημένη (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Σε αυτό το παράδειγμα, η ενεργοποίηση της επιλογής μετατρέπει μόνο το έντονο κείμενο σε bitmap: δεν μπορεί να επιλεγεί, αντιγραφεί ή αναζητηθεί ως κείμενο χωρίς OCR, και οι άκρες του εμφανίζονται πιο μαλακές σε ζουμ 800%. Το κανονικό κείμενο παραμένει αναζητήσιμο. Με την επιλογή απενεργοποιημένη, και τα δύο κείμενα παραμένουν κείμενο.

Αυτή η επιλογή rasterizes κείμενο μορφοποιημένο ως bold όταν η γραμματοσειρά του δεν έχει ξεχωριστό έντονο στυλ. Η [**Αντικατάσταση γραμματοσειράς**](/slides/el/nodejs-java/font-substitution/) επιλέγει εναλλακτική γραμματοσειρά όταν η αρχική δεν είναι διαθέσιμη.

## **Μετατροπή επιλεγμένων διαφανειών από PowerPoint σε PDF**

Το παρακάτω παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανειών σε αυτόν τον πίνακα είναι μονάδικοι, και η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

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

## **Μετατροπή PowerPoint σε PDF με προσαρμοσμένο μέγεθος διαφάνειας**

Το παρακάτω παράδειγμα αντιγράφει την πρώτη διαφάνεια από μια παρουσίαση σε νέα παρουσίαση με μέγεθος διαφάνειας 612 × 792 points (8.5 × 11 ίντσες). Κάνει κλίμακα του περιεχομένου της διαφάνειας ώστε να χωράει και εξάγει τη μοναδική διαφάνεια σε PDF.

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

    // Αφαιρέστε την κενή διαφάνεια που δημιουργήθηκε με τη νέα παρουσίαση.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PDF σε προβολή σημειώσεων διαφάνειας**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις ομιλητή κάτω από τη διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

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

## **Πρότυπα προσβασιμότητας και συμμόρφωσης για PDF**

Η Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b** και **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Η Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντας τη μετατροπή αρχείων PDF σε δημοφιλή μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), και [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Υποστηρίζονται επίσης άλλες μετατροπές PDF σε εξειδικευμένες μορφές — [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) —.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, η Aspose.Slides αντιμετωπίζει σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως ενιαίο σχήμα. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και ενδέχεται να χαρακτηριστούν ως τεχνητά στοιχεία· το εναλλακτικό κείμενο παρέχεται μόνο για το ολόκληρο σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλαπλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, η Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επεξεργαστείτε τα αρχεία σας με βρόχο και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Μπορώ να προστατεύσω με κωδικό πρόσβασης το μετατρεπόμενο PDF;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε άδειες πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Καλέστε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) με `true` στην κλάση [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί η Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) και [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) για να εξασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει η Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, η Aspose.Slides σας επιτρέπει να εξάγετε PDFs που συμμορφώνονται με [διαφορετικά πρότυπα](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), συμπεριλαμβανομένων PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για Node.js μέσω Java](/slides/el/nodejs-java/)
- [Αναφορά API Aspose.Slides για Node.js μέσω Java](https://reference.aspose.com/slides/nodejs-java/)
- [Δωρεάν διαδικτυακούς μετατροπείς Aspose](https://products.aspose.app/slides/conversion)