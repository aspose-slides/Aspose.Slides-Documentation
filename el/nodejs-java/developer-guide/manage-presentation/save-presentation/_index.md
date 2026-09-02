---
title: Αποθήκευση Παρουσιάσεων σε JavaScript
linktitle: Αποθήκευση Παρουσίασης
type: docs
weight: 80
url: /el/nodejs-java/save-presentation/
keywords:
- αποθήκευση PowerPoint
- αποθήκευση OpenDocument
- αποθήκευση παρουσίασης
- αποθήκευση διαφάνειας
- αποθήκευση PPT
- αποθήκευση PPTX
- αποθήκευση ODP
- παρουσίαση σε αρχείο
- παρουσίαση σε ροή
- προκαθορισμένος τύπος προβολής
- Strict Office Open XML Format
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας τη διάταξη, τις γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Open Presentations in JavaScript](/slides/el/nodejs-java/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) περιέχει το περιεχόμενο μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μία υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides for Node.js, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **stream**. Αυτό το άρθρο εξηγεί τους διαφορετικούς τρόπους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Περάστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Κάντε κάποια εργασία εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια ροή εξόδου στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ροή αρχείου.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Αποθηκεύστε την παρουσίαση στην ροή.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργηθείσα παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#setLastView) με μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Strict Office Open XML Format**

Το Aspose.Slides σας επιτρέπει να αποθηκεύσετε μια παρουσίαση σε Strict Office Open XML format. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Αν ορίσετε [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), το αρχείο εξόδου αποθηκεύεται σε Strict Office Open XML format.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει σε Strict Office Open XML format.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποθηκεύστε την παρουσίαση σε αυστηρή μορφή Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Format σε Λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα ZIP αρχείο που επιβάλλει όρια 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του архιβιού, και περιορίζει το αρχείο σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η μέθοδος [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) σας επιτρέπει να επιλέξετε πότε θα χρησιμοποιηθούν οι επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός Office Open XML αρχείου.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις παρακάτω λειτουργίες:

- [IfNecessary](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τους περιορισμούς παραπάνω. Αυτή είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Never) δεν χρησιμοποιεί ποτέ τις επεκτάσεις μορφής ZIP64.
- [Always](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Always) χρησιμοποιεί πάντα τις επεκτάσεις μορφής ZIP64.

Το παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}}
Όταν αποθηκεύετε με [Zip64Mode.Never](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Never), εξαίρεση [PptxException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxexception/) ρίχνεται εάν η παρουσίαση δεν μπορεί να αποθηκευθεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Format με Επίπεδα Συμπίεσης**

Κατά την εργασία με μεγάλες παρουσιάσεις, μπορείτε να προσαρμόσετε το επίπεδο συμπίεσης για να βρείτε ισορροπία μεταξύ του μεγέθους του αρχείου και του χρόνου επεξεργασίας. Ανάλογα με τις απαιτήσεις σας, μπορεί να προτιμάτε ταχύτερη επεξεργασία ή μικρότερα αρχεία εξόδου.

Το Aspose.Slides παρέχει τη μέθοδο [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), η οποία επιτρέπει τον ορισμό του επιπέδου συμπίεσης που χρησιμοποιείται κατά την αποθήκευση μιας παρουσίασης σε Office Open XML format.

Τα εξής επίπεδα συμπίεσης είναι διαθέσιμα:

- [**None**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#None): Δεν εφαρμόζεται καμία συμπίεση. Τα αρχεία αποθηκεύονται όπως είναι.
- [**Level1**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level1): Η ταχύτερη συμπίεση με τον χαμηλότερο λόγο συμπίεσης.
- [**Level2**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level2): Ταχύτερη συμπίεση με ελαφρώς καλύτερο λόγο συμπίεσης σε σχέση με το **Level1**.
- [**Level3**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level3): Παρέχει καλύτερη συμπίεση από το **Level2** με μέτρια επίπτωση στην ταχύτητα επεξεργασίας.
- [**Level4**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level4): Παρέχει καλύτερη συμπίεση από το **Level3**.
- [**Level5**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level5): Παρέχει βελτιωμένη συμπίεση σε σχέση με το **Level4** με επιπλέον χρόνο επεξεργασίας.
- [**Level6**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level6): Κανονική συμπίεση που προσφέρει καλή ισορροπία μεταξύ ταχύτητας επεξεργασίας και μεγέθους αρχείου. Αυτό είναι το *προεπιλεγμένο επίπεδο συμπίεσης*.
- [**Level7**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level7): Παρέχει καλύτερη συμπίεση από το **Level6** με πιο αργή επεξεργασία.
- [**Level8**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level8): Παρέχει καλύτερη συμπίεση από το **Level7**.
- [**Level9**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level9): Μέγιστη συμπίεση. Παράγει το μικρότερο μέγεθος αρχείου με κόστος του μεγαλύτερου χρόνου επεξεργασίας.

Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX *χωρίς συμπίεση*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Αυτό το παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με *μέγιστη συμπίεση*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση της Μικρογραφίας**

Η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ελέγχει τη δημιουργία μικρογραφίας όταν αποθηκεύεται μια παρουσίαση σε PPTX:

- Αν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι το προεπιλεγμένο.
- Αν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Αν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεωθεί η μικρογραφία της.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Αυτή η επιλογή βοηθά στη μείωση του χρόνου που απαιτείται για την αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

## **Αναφορά Προόδου Αποθήκευσης σε Ποσοστό**

Η αναφορά προόδου αποθήκευσης ρυθμίζεται μέσω της μεθόδου [setProgressCallback](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) στην κλάση [SaveOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/) και στις υποκλάσεις της. Παρέχετε έναν διακομιστή Java που υλοποιεί τη διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/); κατά την εξαγωγή, η κλήση επιστροφής λαμβάνει περιοδικές ενημερώσεις σε ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Χρησιμοποιήστε την τιμή προόδου σε ποσοστό εδώ.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Το Aspose έχει αναπτύξει μια δωρεάν εφαρμογή PowerPoint Splitter ([https://products.aspose.app/slides/el/splitter](https://products.aspose.app/slides/el/splitter)) χρησιμοποιώντας το δικό του API. Η εφαρμογή σας επιτρέπει να χωρίσετε μια παρουσίαση σε πολλά αρχεία αποθηκεύοντας επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές από νήματα (thread‑safe) το να αποθηκεύσετε το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) **δεν είναι thread‑safe**· αποθηκεύστε το από ένα μόνο νήμα.

**Τι γίνεται με τους υπερσυνδέσμους (hyperlinks) και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

Τα [Hyperlinks](/slides/el/nodejs-java/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μετα-δεδομένα εγγράφου (Συγγραφέας, Τίτλο, Εταιρεία, Ημερομηνία);**

Ναι. Οι τυπικές [document properties](/slides/el/nodejs-java/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.