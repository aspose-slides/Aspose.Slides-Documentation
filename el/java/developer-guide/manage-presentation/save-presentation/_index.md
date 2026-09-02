---
title: Αποθήκευση Παρουσιάσεων σε Java
linktitle: Αποθήκευση Παρουσίασης
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
- Strict Office Open XML Format
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε Java χρησιμοποιώντας το Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument ενώ διατηρούνται οι διατάξεις, οι γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Open Presentations in Java](/slides/el/java/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) για το άνοιγμα μιας παρουσίασης. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) περιέχει το περιεχόμενο μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides for Java, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τις διαφορετικές μεθόδους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Περνοίστε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation η οποία αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Εκτελέστε κάποια εργασία εδώ...

    // Αποθήκευση της παρουσίασης σε αρχείο.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια ροή εξόδου στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ροή αρχείου.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Δημιουργία της κλάσης Presentation η οποία αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

Το Aspose.Slides σάς επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η παραγόμενη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#setLastView-int-) με μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Strict Office Open XML Format**

Το Aspose.Slides σάς επιτρέπει να αποθηκεύσετε μια παρουσίαση σε μορφή Strict Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε το [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), το αρχείο εξόδου αποθηκεύεται σε μορφή Strict Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει σε μορφή Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Δημιουργία της κλάσης Presentation η οποία αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Αποθήκευση της παρουσίασης σε μορφή Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Format σε Λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει όρια 4 GB (2^32 byte) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, καθώς και περιορίζει το αρχείο σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η μέθοδος [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιείτε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις ακόλουθες λειτουργίες:

- [IfNecessary](https://reference.aspose.com/slides/el/java/com.aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση ξεπερνά τα παραπάνω όρια. Αυτή είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/java/com.aspose.slides/zip64mode/#Never) δεν χρησιμοποιεί ποτέ τις επεκτάσεις μορφής ZIP64.
- [Always](https://reference.aspose.com/slides/el/java/com.aspose.slides/zip64mode/#Always) χρησιμοποιεί πάντα τις επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```java
import com.aspose.slides.*;

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
Όταν αποθηκεύετε με το [Zip64Mode.Never](https://reference.aspose.com/slides/el/java/com.aspose.slides/zip64mode/#Never), ρίχνεται μια [PptxException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxexception/) εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Format με Επίπεδα Συμπίεσης**

Κατά την εργασία με μεγάλες παρουσιάσεις, μπορείτε να προσαρμόσετε το επίπεδο συμπίεσης για να εξισορροπήσετε το μέγεθος του αρχείου και τον χρόνο επεξεργασίας. Ανάλογα με τις απαιτήσεις σας, μπορείτε να προτιμάτε ταχύτερη επεξεργασία ή μικρότερα αρχεία εξόδου.

Το Aspose.Slides παρέχει τη μέθοδο [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) που σας επιτρέπει να καθορίσετε το επίπεδο συμπίεσης που χρησιμοποιείται κατά την αποθήκευση μιας παρουσίασης σε μορφή Office Open XML.

Τα ακόλουθα επίπεδα συμπίεσης διατίθενται:

- **None**: Δεν εφαρμόζεται συμπίεση. Τα αρχεία αποθηκεύονται όπως είναι.
- **Level1**: Η πιο γρήγορη συμπίεση με το χαμηλότερο ποσοστό συμπίεσης.
- **Level2**: Ταχύτερη συμπίεση με ελαφρώς καλύτερο ποσοστό συμπίεσης από το **Level1**.
- **Level3**: Παρέχει καλύτερη συμπίεση από το **Level2** με μέτρια επίδραση στον χρόνο επεξεργασίας.
- **Level4**: Παρέχει καλύτερη συμπίεση από το **Level3**.
- **Level5**: Παρέχει βελτιωμένη συμπίεση σε σχέση με το **Level4** με επιπλέον χρόνο επεξεργασίας.
- **Level6**: Πρότυπη συμπίεση που προσφέρει καλή ισορροπία μεταξύ ταχύτητας επεξεργασίας και μεγέθους αρχείου. Αυτό είναι το *προεπιλεγμένο επίπεδο συμπίεσης*.
- **Level7**: Παρέχει καλύτερη συμπίεση από το **Level6** με πιο αργή επεξεργασία.
- **Level8**: Παρέχει καλύτερη συμπίεση από το **Level7**.
- **Level9**: Μέγιστη συμπίεση. Παράγει το μικρότερο μέγεθος αρχείου με την τιμή του μεγαλύτερου χρόνου επεξεργασίας.

Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX *χωρίς συμπίεση*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Αυτό το παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με *μέγιστη συμπίεση*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση της Μικρογραφίας**

Η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ελέγχει τη δημιουργία μικρογραφίας κατά την αποθήκευση μιας παρουσίασης σε PPTX:

- Εάν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτή είναι η προεπιλογή.
- Εάν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς την ανανέωση της μικρογραφίας της.

```java
import com.aspose.slides.*;

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

Το interface [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της μεθόδου `setProgressCallback` που εκτίθεται από το interface [ISaveOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveoptions/). Ανάθετε μια υλοποίηση του [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/) με τη `setProgressCallback` για να λαμβάνετε ενημερώσεις προόδου αποθήκευσης ως ποσοστό.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να χρησιμοποιήσετε το `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Χρησιμοποιήστε εδώ την τιμή του ποσοστού προόδου.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σας επιτρέπει να χωρίσετε μια παρουσίαση σε πολλαπλά αρχεία αποθηκεύοντας τις επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υπάρχει υποστήριξη για «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλής η αποθήκευση του ίδιου αντικειμένου Presentation από πολλαπλές νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) δεν είναι [thread-safe](/slides/el/java/multithreading/); αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

[Hyperlinks](/slides/el/java/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα — διασφαλίστε ότι οι παραπομπές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Τα τυπικά [document properties](/slides/el/java/presentation-properties/) υποστηρίζονται και θα εγγραφούν στο αρχείο κατά την αποθήκευση.