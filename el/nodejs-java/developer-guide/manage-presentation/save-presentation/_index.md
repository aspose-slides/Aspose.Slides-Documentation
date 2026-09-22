---
title: Αποθήκευση παρουσιάσεων σε JavaScript
linktitle: Αποθήκευση παρουσίασης
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
- Αυστηρή μορφή Office Open XML
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Node.js
- JavaScript
- Aspose.Slides
description: "Αποθήκευση παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές σε JavaScript με το Aspose.Slides, και διαμόρφωση εξόδου PPTX και αναφορά προόδου."
---
## **Επισκόπηση**

Αφού δημιουργήσετε μια παρουσίαση ή [ανοίξετε μια υπάρχουσα](/slides/el/nodejs-java/open-presentation/), χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα. Το Aspose.Slides for Node.js via Java μπορεί να αποθηκεύσει μια παρουσίαση σε αρχείο ή ροή σε μορφές PowerPoint, OpenDocument, PDF και άλλες. Οι παρακάτω ενότητες καλύπτουν τις τυπικές λειτουργίες αποθήκευσης και τις επιλογές που διατίθενται για έξοδο PPTX.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Για να αποθηκεύσετε μια παρουσίαση σε αρχείο, περάστε τη διαδρομή εξόδου και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save). Η τιμή μορφής καθορίζει τον τύπο αρχείου που δημιουργεί το Aspose.Slides.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και τη αποθηκεύει ως αρχείο PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Προσθέστε ή τροποποιήστε το περιεχόμενο της παρουσίασης εδώ.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων στην αρχική μορφή τους**

Για παραδείγματα ανίχνευσης αρχείου και ροής, τη συμπεριφορά των νέων παρουσιάσεων και τη διάκριση μεταξύ μορφής προέλευσης και εξόδου, δείτε το [Determine the Original Presentation Format](/slides/el/nodejs-java/detect-presentation-source-format/).

Σε εφαρμογή επεξεργασίας παρτίδας, η μορφή εισόδου μπορεί να μην είναι γνωστή εκ των προτέρων. Μετά τη φόρτωση ενός αρχείου, διαβάστε την αρχική μορφή του από τη μέθοδο [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSourceFormat). Περνάτε την προκύπτουσα τιμή [SourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sourceformat/) στη [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/#toSaveFormat) για να λάβετε την αντίστοιχη τιμή [SaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/), και στη συνέχεια χρησιμοποιείτε το [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) για να γράψετε την τροποποιημένη παρουσίαση.

Το παρακάτω πλήρες παράδειγμα επεξεργάζεται κάθε αρχείο σε έναν φάκελο εισόδου, ενημερώνει τον τίτλο του και το αποθηκεύει σε φάκελο εξόδου στη μορφή από την οποία φορτώθηκε:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/#toSaveFormat) αντιστοιχεί PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP και PowerPoint XML στις αντίστοιχες μορφές αποθήκευσης παρουσίασης. Αντιστοιχεί μόνο στις μορφές προέλευσης παρουσίασης· δεν προορίζεται για επιλογή μορφών εξαγωγής όπως PDF, HTML, TIFF ή εικόνες. Η περαιτέρω τιμή [SourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sourceformat/) που δεν υποστηρίζεται ή είναι μη έγκυρη προκαλεί σφάλμα.

Τα παλαιά αρχεία PPT, PPS και POT χρησιμοποιούν το ίδιο δυαδικό δοχείο. Όταν μια τέτοια παρουσίαση φορτώνεται από ροή χωρίς επέκταση αρχείου, ένα αρχείο PPS ή POT μπορεί επομένως να ταυτιστεί ως PPT. Εάν απαιτείται η διατήρηση αυτών των παλαιών υποτύπων, διατηρήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα μορφής ξεχωριστά και χρησιμοποιήστε τα κατά την επιλογή του ονόματος και της μορφής εξόδου.

## **Αποθήκευση παρουσιάσεων σε ροές**

Για να γράψετε μια παρουσίαση χωρίς να βασιστείτε σε τελική διαδρομή αρχείου, περάστε μια ροή εγγραφής και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save). Αυτή η προσέγγιση είναι χρήσιμη όταν η έξοδος πρέπει να επιστραφεί από υπηρεσία web, να αποθηκευτεί σε βάση δεδομένων ή να υποβληθεί σε επεξεργασία στη μνήμη.

Το παρακάτω παράδειγμα αποθηκεύει μια νέα παρουσίαση σε ροή αρχείου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων με προεπιλεγμένο τύπο προβολής**

Μπορείτε να καθορίσετε την προβολή στην οποία το PowerPoint ανοίγει αρχικά μια αποθηκευμένη παρουσίαση. Χρησιμοποιήστε τη μέθοδο [ViewProperties.setLastView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#setLastView) με μια τιμή [ViewType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewtype/) πριν την αποθήκευση.

Το παρακάτω παράδειγμα ρυθμίζει την προβολή Slide Master ως αρχική προβολή:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων σε αυστηρή μορφή Office Open XML**

Για να δημιουργήσετε ένα αρχείο PPTX που συμμορφώνεται με το αυστηρό προφίλ του Office Open XML, δημιουργήστε ένα αντικείμενο [PptxOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/) και χρησιμοποιήστε τη μέθοδο [setConformance](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#setConformance) με την τιμή [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Στη συνέχεια περάστε τις επιλογές στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML σε λειτουργία Zip64**

Ένα τυπικό αρχείο ZIP περιορίζει το συμπιεσμένο και ασυμπίεστο μέγεθος κάθε καταχώρησης, το συνολικό μέγεθος του αρχείου και τον αριθμό των καταχωρήσεων. Επειδή ένα αρχείο PPTX είναι αρχείο ZIP, μια πολύ μεγάλη παρουσίαση μπορεί να υπερβεί αυτά τα όρια. Οι επεκτάσεις ZIP64 αυξάνουν τα εφαρμόσιμα όρια μεγέθους και αριθμού καταχωρήσεων.

Χρησιμοποιήστε τη μέθοδο [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) για να ελέγξετε εάν το Aspose.Slides γράφει επεκτάσεις ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί ZIP64 μόνο όταν η παρουσίαση υπερβαίνει τα τυπικά όρια ZIP. Αυτό είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Never) απενεργοποιεί τις επεκτάσεις ZIP64.
- [Always](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Always) πάντα γράφει επεκτάσεις ZIP64.

Το παρακάτω παράδειγμα ενεργοποιεί πάντα τις επεκτάσεις ZIP64 για την παρουσίαση εξόδου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Αν χρησιμοποιηθεί το [Zip64Mode.Never](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zip64mode/#Never) και η παρουσίαση δεν μπορεί να χωρέσει στα τυπικά όρια ZIP, η λειτουργία αποθήκευσης ρίχνει ένα σφάλμα [PptxException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML με επίπεδα συμπίεσης**

Για έξοδο PPTX, μπορείτε να ισορροπήσετε την ταχύτητα αποθήκευσης έναντι του μεγέθους αρχείου χρησιμοποιώντας τη μέθοδο [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). Η κλάση [CompressionLevel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/) παρέχει τις ακόλουθες τιμές:

- [None](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#None) αποθηκεύει δεδομένα χωρίς συμπίεση.
- [Level1](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level1) παρέχει τη γρηγορότερη συμπίεση και το μεγαλύτερο συμπιεσμένο αποτέλεσμα.
- [Level2](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level2) έως [Level5](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level5) προτιμούν προοδευτικά μικρότερο αποτέλεσμα έναντι ταχύτητας αποθήκευσης.
- [Level6](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level6) ισορροπεί την ταχύτητα αποθήκευσης και το μέγεθος αρχείου. Αυτή είναι η προεπιλεγμένη τιμή.
- [Level7](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level7) και [Level8](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level8) προτιμούν ακόμη περισσότερο μικρότερο αποτέλεσμα έναντι ταχύτητας αποθήκευσης.
- [Level9](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compressionlevel/#Level9) παρέχει τη δυνατότερη συμπίεση και απαιτεί περισσότερο χρόνο επεξεργασίας.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς συμπίεση:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Το παράδειγμα παρακάτω χρησιμοποιεί το μέγιστο επίπεδο συμπίεσης:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση της μικρογραφίας**

Όταν μια παρουσίαση αποθηκεύεται ως PPTX, η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ελέγχει τη μικρογραφία του εγγράφου:

- `true` αναγεννεί τη μικρογραφία κατά τη λειτουργία αποθήκευσης. Αυτή είναι η προεπιλεγμένη τιμή.
- `false` διατηρεί την υπάρχουσα μικρογραφία. Εάν η παρουσίαση δεν έχει μικρογραφία, το Aspose.Slides δεν δημιουργεί καμία.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς να ανανεώσει τη μικρογραφία της:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Η απενεργοποίηση της ανανέωσης της μικρογραφίας μπορεί να μειώσει το χρόνο που απαιτείται για την αποθήκευση ενός αρχείου PPTX.
{{% /alert %}}

## **Αναφορές προόδου αποθήκευσης σε ποσοστό**

Για να παρακολουθείτε μια λειτουργία αποθήκευσης, υλοποιήστε τη διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/) με διαμεσολαβητή Java και περάστε την υλοποίηση στη μέθοδο [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Το Aspose.Slides τότε καλεί τη μέθοδο [IProgressCallback.reporting](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/#reporting-double-) με τιμές προόδου κατά την εξαγωγή.

Το παρακάτω παράδειγμα αναφέρει την πρόοδο εξαγωγής PDF στην κονσόλα:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Η Aspose παρέχει ένα δωρεάν [PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) που δημιουργήθηκε με το API Aspose.Slides. Αποθηκεύει επιλεγμένες διαφάνειες από μια παρουσίαση ως ξεχωριστά αρχεία PPT ή PPTX.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζει το Aspose.Slides αποθήκευση σε βήματα ή «γρήγορη αποθήκευση»;**

Όχι. Κάθε λειτουργία αποθήκευσης γράφει ένα πλήρες αρχείο εξόδου αντί να ενημερώνει μόνο τα τροποποιημένα μέρη.

**Μπορούν πολλαπλές διεργασίες να αποθηκεύσουν το ίδιο αντικείμενο Presentation;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) [δεν είναι thread-safe](/slides/el/nodejs-java/multithreading/). Πρόσβαση και αποθήκευση κάθε αντικειμένου πρέπει να γίνεται από μία μόνο διεργασία τη φορά.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία όταν αποθηκεύω μια παρουσίαση;**

Τα [Hyperlinks](/slides/el/nodejs-java/manage-hyperlinks/) παραμένουν στην παρουσίαση. Το Aspose.Slides δεν αντιγράφει εξωτερικά συνδεδεμένα αρχεία, επομένως η αποθηκευμένη παρουσίαση πρέπει ακόμη να μπορεί να προσπελάσει τις τοποθεσίες τους.

**Μπορώ να αποθηκεύσω μεταδεδομένα εγγράφου όπως συγγραφέας, τίτλος, εταιρεία και ημερομηνία δημιουργίας;**

Ναι. Ορίστε τις κατάλληλες [document properties](/slides/el/nodejs-java/presentation-properties/) πριν την αποθήκευση και το Aspose.Slides θα τις γράψει στο αρχείο εξόδου.