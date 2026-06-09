---
title: Αποθήκευση Παρουσιάσεων σε Android
linktitle: Αποθήκευση Παρουσίασης
type: docs
weight: 80
url: /el/androidjava/save-presentation/
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
- λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε Java χρησιμοποιώντας το Aspose.Slides για Android—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας τις διατάξεις, τις γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Open Presentations on Android](/slides/el/androidjava/open-presentation/) περιέγραψε πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) περιλαμβάνει τα περιεχόμενα μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να τη αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides for Android, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τις διαφορετικές μεθόδους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο κλήση της μεθόδου `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Περάστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```java
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Εκτελέστε κάποιες εργασίες εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια έξοδο ροής στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλές τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και τη αποθηκεύουμε σε ροή αρχείου.

```java
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Αποθήκευση της παρουσίασης στη ροή.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργημένη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) με μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων στην Αυστηρή Μορφή Office Open XML**

Το Aspose.Slides σάς επιτρέπει να αποθηκεύσετε μια παρουσίαση στην αυστηρή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), το αρχείο εξόδου αποθηκεύεται στην αυστηρή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει στην αυστηρή μορφή Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Αποθήκευση της παρουσίασης στην αυστηρή μορφή Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML σε Λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει όρια 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, το συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και το συνολικό μέγεθος του αρχείου, καθώς και περιορίζει το αρχείο σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η μέθοδος [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιείτε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις ακόλουθες λειτουργίες:

- [IfNecessary](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο αν η παρουσίαση υπερβαίνει τα παραπάνω περιορισμούς. Αυτή είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Never) ποτέ δεν χρησιμοποιεί τις επεκτάσεις μορφής ZIP64.
- [Always](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Always) πάντα χρησιμοποιεί τις επεκτάσεις μορφής ZIP64.

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
Όταν αποθηκεύετε με [Zip64Mode.Never](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Never), μια [PptxException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxexception/) ρίχνεται εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση Μικρογραφίας**

Η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ελέγχει τη δημιουργία μικρογραφίας όταν αποθηκεύεται μια παρουσίαση σε PPTX:

- Αν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτή είναι η προεπιλογή.
- Αν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεώνει τη μικρογραφία της.

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

## **Αποθήκευση Ενημερώσεων Προόδου σε Ποσοστό**

Η διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της μεθόδου `setProgressCallback` που εκτίθεται από τη διεπαφή [ISaveOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveoptions/). Ανάθεση μιας υλοποίησης [IProgressCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprogresscallback/) με `setProgressCallback` για λήψη ενημερώσεων προόδου αποθήκευσης ως ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

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
        // Χρησιμοποιήστε εδώ την τιμή του ποσοστού προόδου.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σάς επιτρέπει να χωρίσετε μια παρουσίαση σε πολλαπλά αρχεία αποθηκεύοντας επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (διαδοχική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί ολόκληρο το αρχείο προορισμού κάθε φορά· η διαδοχική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές από νήματα (thread‑safe) να αποθηκεύσετε το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation] [δεν είναι thread‑safe](/slides/el/androidjava/multithreading/); αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

[Hyperlinks] διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα—βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Τα τυπικά [document properties] υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.