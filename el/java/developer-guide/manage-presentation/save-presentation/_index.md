---
title: Αποθήκευση παρουσιάσεων σε Java
linktitle: Αποθήκευση παρουσίασης
type: docs
weight: 80
url: /el/java/save-presentation/
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
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε Java χρησιμοποιώντας το Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument ενώ διατηρείτε διατάξεις, γραμματοσειρές και εφέ."
---
## **Επισκόπηση**

[Άνοιγμα παρουσιάσεων σε Java](/slides/el/java/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) περιέχει το περιεχόμενο μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από την αρχή είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να τη αποθηκεύσετε όταν ολοκληρώσετε. Με το Aspose.Slides for Java, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τις διαφορετικές τρόπους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο, καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Περνάτε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Κάντε κάποια εργασία εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων σε ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή, περνώντας μια έξοδο ροής στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροής. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και τη αποθηκεύουμε σε ροή αρχείου.

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Αποθηκεύστε την παρουσίαση στη ροή.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων με προκαθορισμένο τύπο προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργημένη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#setLastView-int-) με μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων σε αυστηρή μορφή Office Open XML**

Το Aspose.Slides σας επιτρέπει να αποθηκεύσετε μια παρουσίαση σε αυστηρή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), το αρχείο εξόδου αποθηκεύεται σε αυστηρή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και τη αποθηκεύει σε αυστηρή μορφή Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Αποθηκεύστε την παρουσίαση σε αυστηρή μορφή Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML σε λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει όρια 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, καθώς και περιορίζει το αρχείο σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η μέθοδος [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) σάς επιτρέπει να επιλέξετε πότε να χρησιμοποιείτε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις ακόλουθες λειτουργίες:

- [IfNecessary](https://reference.aspose.com/slides/el/java/com.aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τις παραπάνω περιορισμούς. Αυτό είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/java/com.aspose.slides/zip64mode/#Never) δεν χρησιμοποιεί ποτέ τις επεκτάσεις μορφής ZIP64.
- [Always](https://reference.aspose.com/slides/el/java/com.aspose.slides/zip64mode/#Always) χρησιμοποιεί πάντα τις επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Όταν αποθηκεύετε με [Zip64Mode.Never](https://reference.aspose.com/slides/el/java/com.aspose.slides/zip64mode/#Never), ρίχνεται μια [PptxException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxexception/) εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση μικρογραφίας**

Η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ελέγχει τη δημιουργία μικρογραφίας κατά την αποθήκευση μιας παρουσίασης σε PPTX:

- Εάν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι η προεπιλογή.
- Εάν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς ανανέωση της μικρογραφίας της.

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Αυτή η επιλογή βοηθά στη μείωση του χρόνου που απαιτείται για την αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

## **Αποθήκευση ενημερώσεων προόδου σε ποσοστό**

Η διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της μεθόδου `setProgressCallback` που εκτίθεται από τη διεπαφή [ISaveOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveoptions/). Αναθέστε μια υλοποίηση του [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/) με `setProgressCallback` για να λαμβάνετε ενημερώσεις προόδου αποθήκευσης ως ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε `IProgressCallback`.

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Χρησιμοποιήστε την τιμή του ποσοστού προόδου εδώ.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Η Aspose έχει αναπτύξει μια [free PowerPoint Splitter app](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σάς επιτρέπει να χωρίσετε μια παρουσίαση σε πολλαπλά αρχεία αποθηκεύοντας επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αυξήτικη «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλής η αποθήκευση του ίδιου αντικειμένου [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) [δεν είναι ασφαλές ως προς τα νήματα](/slides/el/java/multithreading/); αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

Τα [Hyperlinks](/slides/el/java/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα—βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Τα τυπικά [document properties](/slides/el/java/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.