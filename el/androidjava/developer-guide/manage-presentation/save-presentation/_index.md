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
- Συνεπής Μορφή Office Open XML
- λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε Java χρησιμοποιώντας το Aspose.Slides για Android—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας διατάξεις, γραμματοσειρές και εφέ."
---
## **Επισκόπηση**

[Ανοίξτε Παρουσιάσεις σε Android](/slides/el/androidjava/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) για το άνοιγμα μιας παρουσίασης. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) περιέχει το περιεχόμενο μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides για Android, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τις διαφορετικές μεθόδους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Περνάτε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```java
import com.aspose.slides.*;

// Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Κάντε κάποια εργασία εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια έξοδο ροής στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ροή αρχείου.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η παραγόμενη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) με τιμή από την αξιολόγηση [ViewType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewtype/).

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

## **Αποθήκευση Παρουσιάσεων στη Συνεπή Μορφή Office Open XML**

Το Aspose.Slides σας επιτρέπει να αποθηκεύσετε μια παρουσίαση στη Συνεπή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε το [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), το αρχείο εξόδου αποθηκεύεται στη Συνεπή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει στη Συνεπή μορφή Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Αποθηκεύστε την παρουσίαση στη Συνεπή μορφή Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML σε Λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει όρια 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, ενώ επίσης περιορίζει το αρχείο σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η μέθοδος [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιήσετε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις ακόλουθες λειτουργίες:

- [IfNecessary](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τα παραπάνω όρια. Αυτή είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Never) δεν χρησιμοποιεί ποτέ επεκτάσεις μορφής ZIP64.
- [Always](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Always) χρησιμοποιεί πάντα επεκτάσεις μορφής ZIP64.

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
Όταν αποθηκεύετε με [Zip64Mode.Never](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Never), πετιέται μια [PptxException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxexception/) εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML με Επίπεδα Συμπίεσης**

Όταν εργάζεστε με μεγάλες παρουσιάσεις, μπορείτε να ρυθμίσετε το επίπεδο συμπίεσης ώστε να ισορροπήσετε το μέγεθος του αρχείου και το χρόνο επεξεργασίας. Ανάλογα με τις απαιτήσεις σας, μπορεί να προτιμάτε πιο γρήγορη επεξεργασία ή μικρότερα αρχεία εξόδου.

Το Aspose.Slides παρέχει τη μέθοδο [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-), η οποία επιτρέπει τον καθορισμό του επιπέδου συμπίεσης που χρησιμοποιείται κατά την αποθήκευση μιας παρουσίασης σε μορφή Office Open XML.

Τα εξής επίπεδα συμπίεσης είναι διαθέσιμα:

- [**None**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#None): Δεν εφαρμόζεται συμπίεση. Τα αρχεία αποθηκεύονται όπως είναι.
- [**Level1**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level1): Η πιο γρήγορη συμπίεση με το χαμηλότερο λόγο συμπίεσης.
- [**Level2**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level2): Ταχύτερη συμπίεση με ελαφρώς καλύτερο λόγο από το **Level1**.
- [**Level3**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level3): Παρέχει καλύτερη συμπίεση από το **Level2** με μέτρια επίδραση στον χρόνο επεξεργασίας.
- [**Level4**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level4): Παρέχει καλύτερη συμπίεση από το **Level3**.
- [**Level5**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level5): Βελτιωμένη συμπίεση σε σχέση με το **Level4** με επιπλέον χρόνο επεξεργασίας.
- [**Level6**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level6): Κανονική συμπίεση που προσφέρει καλή ισορροπία μεταξύ ταχύτητας επεξεργασίας και μεγέθους αρχείου. Αυτό είναι το *προεπιλεγμένο επίπεδο συμπίεσης*.
- [**Level7**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level7): Καλύτερη συμπίεση από το **Level6** με πιο αργή επεξεργασία.
- [**Level8**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level8): Καλύτερη συμπίεση από το **Level7**.
- [**Level9**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level9): Μέγιστη συμπίεση. Παράγει το μικρότερο μέγεθος αρχείου με το μεγαλύτερο κόστος χρόνου επεξεργασίας.

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

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση Μικρογραφίας**

Η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ελέγχει τη δημιουργία μικρογραφίας κατά την αποθήκευση μιας παρουσίασης σε PPTX:

- Εάν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι το προεπιλεγμένο.
- Εάν οριστεί σε `false`, διατηρείται η τρέχουσα μικρογραφία. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεωθεί η μικρογραφία της.

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
Αυτή η επιλογή βοηθά στη μείωση του χρόνου που απαιτείται για αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

## **Αποθήκευση Ενημερώσεων Προόδου σε Ποσοστό**

Η διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της μεθόδου `setProgressCallback` που εκτίθεται από τη διεπαφή [ISaveOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveoptions/). Αναθέστε μια υλοποίηση του [IProgressCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprogresscallback/) με `setProgressCallback` για να λαμβάνετε ενημερώσεις προόδου αποθήκευσης ως ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Χρησιμοποιήστε την τιμή ποσοστού προόδου εδώ.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σας επιτρέπει να χωρίσετε μια παρουσίαση σε πολλαπλά αρχεία αποθηκεύοντας τις επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές (thread‑safe) να αποθηκεύετε το ίδιο αντικείμενο Presentation από πολλές νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) δεν είναι thread‑safe· αποθηκεύστε το από ένα μόνο νήμα.

**Τι γίνεται με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

Τα [Hyperlinks](/slides/el/androidjava/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Οι τυπικές [ιδιότητες εγγράφου](/slides/el/androidjava/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.