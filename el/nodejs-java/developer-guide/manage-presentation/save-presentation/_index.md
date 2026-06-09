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
- Ακριβή Μορφή Office Open XML
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας τις διατάξεις, τις γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Άνοιγμα Παρουσιάσεων σε JavaScript](/slides/el/nodejs-java/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) περιέχει τα περιεχόμενα μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides για Node.js, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τους διαφορετικούς τρόπους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Περάστε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```js
// Δημιουργήστε το αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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
// Δημιουργήστε το αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Αποθηκεύστε την παρουσίαση στη ροή.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργημένη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#setLastView) με τιμή από την ένωση [ViewType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewtype/).

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Ακριβή Μορφή Office Open XML**

Το Aspose.Slides σας επιτρέπει να αποθηκεύσετε μια παρουσίαση σε ακριβή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Αν ορίσετε το [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), το αρχείο εξόδου αποθηκεύεται στην ακριβή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και τη αποθηκεύει στην ακριβή μορφή Office Open XML.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Δημιουργήστε το αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποθηκεύστε την παρουσίαση σε ακριβή μορφή Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML σε Λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που περιορίζει το μέγεθος σε 4 GB (2^32 bytes) για το σπασμένο μέγεθος, το συμπιεσμένο μέγεθος και το συνολικό μέγεθος του αρχειοθηκοποιήματος, καθώς και σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια στα 2^64.

Η μέθοδος [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιήσετε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις παρακάτω λειτουργίες:

- [IfNecessary](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο αν η παρουσίαση υπερβαίνει τους περιορισμούς παραπάνω. Αυτή είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Never) δεν χρησιμοποιεί ποτέ τις επεκτάσεις μορφής ZIP64.
- [Always](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Always) χρησιμοποιεί πάντα τις επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Όταν αποθηκεύετε με [Zip64Mode.Never](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Never), προκύπτει μια [PptxException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxexception/) εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση της Μικρογραφίας**

Η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ελέγχει τη δημιουργία μικρογραφίας όταν αποθηκεύεται μια παρουσίαση ως PPTX:

- Αν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι η προεπιλογή.
- Αν οριστεί σε `false`, διατηρείται η τρέχουσα μικρογραφία. Αν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται ως PPTX χωρίς ανανέωση της μικρογραφίας.

```js
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

## **Αποθήκευση Ενημερώσεων Προόδου σε Ποσοστό**

Η αναφορά προόδου αποθήκευσης ρυθμίζεται μέσω της μεθόδου [setProgressCallback](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) στην κλάση [SaveOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/) και στις υποκλάσεις της. Παρέχετε έναν διακομιστή Java που υλοποιεί τη διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/); κατά την εξαγωγή, η κλήση επιστροφής λαμβάνει περιοδικές ενημερώσεις ποσοστού.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Χρησιμοποιήστε εδώ την τιμή ποσοστού προόδου.
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
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σας επιτρέπει να χωρίσετε μια παρουσίαση σε πολλαπλά αρχεία αποθηκεύοντας τις επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **FAQ**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξομολόγητη αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αυξομολόγητη «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές ως προς τα νήματα να αποθηκευτεί το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) δεν είναι thread‑safe· αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

Τα [Hyperlinks](/slides/el/nodejs-java/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερθείσες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναί. Οι τυπικές [document properties](/slides/el/nodejs-java/presentation-properties/) υποστηρίζονται και θα εγγραφούν στο αρχείο κατά την αποθήκευση.