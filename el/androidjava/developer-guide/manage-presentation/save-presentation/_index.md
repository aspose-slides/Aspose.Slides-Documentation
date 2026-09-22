---
title: "Αποθήκευση παρουσιάσεων σε Android"
linktitle: "Αποθήκευση παρουσίασης"
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
- Αυστηρό φορμά Office Open XML
- λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Android
- Java
- Aspose.Slides
description: "Αποθήκευση παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές σε Android με Aspose.Slides, και διαμόρφωση εξόδου PPTX και αναφορά προόδου."
---
## **Επισκόπηση**

Αφού δημιουργήσετε μια παρουσίαση ή [ανοίξετε μια υπάρχουσα](/slides/el/androidjava/open-presentation/), χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) για να γράψετε το αποτέλεσμα. Το Aspose.Slides for Android μέσω Java μπορεί να αποθηκεύσει μια παρουσίαση σε αρχείο ή ροή σε μορφές PowerPoint, OpenDocument, PDF και άλλες μορφές. Οι επόμενες ενότητες καλύπτουν τις τυπικές λειτουργίες αποθήκευσης και τις επιλογές που διατίθενται για την έξοδο PPTX.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Για να αποθηκεύσετε μια παρουσίαση σε αρχείο, περάστε τη διαδρομή εξόδου και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Η τιμή μορφής καθορίζει τον τύπο αρχείου που δημιουργεί το Aspose.Slides.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει ως αρχείο PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Προσθήκη ή τροποποίηση του περιεχομένου της παρουσίασης εδώ.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων στην αρχική τους μορφή**

Για παραδείγματα ανίχνευσης αρχείου και ροής, τη συμπεριφορά των νεοδημιουργημένων παρουσιάσεων και τη διάκριση μεταξύ πηγής και μορφής εξόδου, δείτε [Determine the Original Presentation Format](/slides/el/androidjava/detect-presentation-source-format/).

Σε μια εφαρμογή δέσμης επεξεργασίας, η μορφή εισόδου μπορεί να μην είναι γνωστή εκ των προτέρων. Μετά τη φόρτωση ενός αρχείου, διαβάστε την αρχική του μορφή από τη μέθοδο [IPresentation.getSourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) . Περάστε την προκύπτουσα τιμή [SourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sourceformat/) στη μέθοδο [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) για να αποκτήσετε την αντίστοιχη τιμή [SaveFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/), και στη συνέχεια χρησιμοποιήστε το [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) για να γράψετε τη τροποποιημένη παρουσίαση.

Το παρακάτω πλήρες παράδειγμα επεξεργάζεται κάθε αρχείο σε έναν φάκελο εισόδου, ενημερώνει τον τίτλο του και το αποθηκεύει σε φάκελο εξόδου στη μορφή από την οποία φορτώθηκε:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) αντιστοιχίζει τα PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP και PowerPoint XML στις αντίστοιχες μορφές αποθήκευσης παρουσίασης. Αντιστοιχίζει μόνο μορφές πηγής παρουσίασης· δεν προορίζεται για επιλογή μορφών εξαγωγής όπως PDF, HTML, TIFF ή εικόνες. Η παροχή μη υποστηριζόμενης ή άκυρης τιμής [SourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sourceformat/) οδηγεί σε [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Οι παλαιές μορφές PPT, PPS και POT χρησιμοποιούν το ίδιο δυαδικό κοντέινερ. Όταν μια τέτοια παρουσίαση φορτώνεται από ροή χωρίς επέκταση αρχείου, ένα αρχείο PPS ή POT μπορεί επομένως να αναγνωριστεί ως PPT. Εάν απαιτείται διατήρηση αυτών των παλαιών υποτύπων, διατηρήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα μορφής ξεχωριστά και χρησιμοποιήστε τα κατά την επιλογή του ονόματος αρχείου και της μορφής εξόδου.

## **Αποθήκευση παρουσιάσεων σε ροές**

Για να γράψετε μια παρουσίαση χωρίς να βασίζεστε σε τελική διαδρομή αρχείου, περάστε μια εγγράψιμη ροή και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Αυτή η προσέγγιση είναι χρήσιμη όταν η έξοδος πρέπει να επιστραφεί από μια υπηρεσία web, να αποθηκευτεί σε βάση δεδομένων ή να υποβληθεί σε επεξεργασία στη μνήμη.

Το παρακάτω παράδειγμα αποθηκεύει μια νέα παρουσίαση σε ροή αρχείου:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων με προκαθορισμένο τύπο προβολής**

Μπορείτε να καθορίσετε την προβολή στην οποία το PowerPoint ανοίγει αρχικά μια αποθηκευμένη παρουσίαση. Χρησιμοποιήστε τη μέθοδο [ViewProperties.setLastView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) με μια τιμή [ViewType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewtype/) πριν την αποθήκευση.

Το παρακάτω παράδειγμα διαμορφώνει την προβολή Slide Master ως αρχική προβολή:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων στην αυστηρή μορφή Office Open XML**

Για να δημιουργήσετε ένα αρχείο PPTX που συμμορφώνεται με το αυστηρό προφίλ του Office Open XML, δημιουργήστε μια παρουσίαση [PptxOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/) και χρησιμοποιήστε τη μέθοδο [setConformance](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) με το [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Στη συνέχεια περάστε τις επιλογές στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML σε λειτουργία Zip64**

Ένα τυπικό αρχείο ZIP περιορίζει το συμπιεσμένο και ασυμπίεστο μέγεθος κάθε καταχώρησης, το συνολικό μέγεθος του αρχείου και τον αριθμό των καταχωρήσεων. Δεδομένου ότι ένα αρχείο PPTX είναι αρχείο ZIP, μια πολύ μεγάλη παρουσίαση μπορεί να υπερβεί αυτά τα όρια. Οι επεκτάσεις ZIP64 αυξάνουν τα όρια μεγέθους και αριθμού καταχωρήσεων.

Χρησιμοποιήστε τη μέθοδο [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) για να ελέγξετε αν το Aspose.Slides θα γράφει επεκτάσεις ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί ZIP64 μόνο όταν η παρουσίαση υπερβαίνει τα τυπικά όρια ZIP. Αυτό είναι το προεπιλεγμένο mode.
- [Never](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Never) απενεργοποιεί τις επεκτάσεις ZIP64.
- [Always](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Always) γράφει πάντα επεκτάσεις ZIP64.

Το παρακάτω παράδειγμα ενεργοποιεί πάντα τις επεκτάσεις ZIP64 για την έξοδο της παρουσίασης:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Εάν χρησιμοποιηθεί το [Zip64Mode.Never](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zip64mode/#Never) και η παρουσίαση δεν μπορεί να χωρέσει στα τυπικά όρια ZIP, η λειτουργία αποθήκευσης ρίχνει μια [PptxException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML με επίπεδα συμπίεσης**

Για έξοδο PPTX, μπορείτε να ισορροπήσετε την ταχύτητα αποθήκευσης με το μέγεθος του αρχείου χρησιμοποιώντας τη μέθοδο [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Η κλάση [CompressionLevel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/) παρέχει τις ακόλουθες τιμές:

- [None](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#None) αποθηκεύει δεδομένα χωρίς συμπίεση.
- [Level1](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level1) παρέχει τη γρηγορότερη συμπίεση και το μεγαλύτερο συμπιεσμένο αποτέλεσμα.
- [Level2](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level2) έως [Level5](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level5) προτιμούν σταδιακά μικρότερο αρχείο σε βάρος της ταχύτητας αποθήκευσης.
- [Level6](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level6) εξισορροπεί την ταχύτητα αποθήκευσης και το μέγεθος αρχείου. Αυτό είναι το προεπιλεγμένο επίπεδο.
- [Level7](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level7) και [Level8](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level8) προτιμούν ακόμη περισσότερο μικρότερο αρχείο σε βάρος της ταχύτητας αποθήκευσης.
- [Level9](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compressionlevel/#Level9) παρέχει τη δυνατότερη συμπίεση και απαιτεί τον μεγαλύτερο χρόνο επεξεργασίας.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς συμπίεση:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Το παρακάτω παράδειγμα χρησιμοποιεί το μέγιστο επίπεδο συμπίεσης:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση μικρογραφίας**

Όταν μια παρουσίαση αποθηκεύεται ως PPTX, η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) ελέγχει τη μικρογραφία του εγγράφου:

- `true` δημιουργεί εκ νέου τη μικρογραφία κατά τη διαδικασία αποθήκευσης. Αυτή είναι η προεπιλεγμένη τιμή.
- `false` διατηρεί την υπάρχουσα μικρογραφία. Εάν η παρουσίαση δεν έχει μικρογραφία, το Aspose.Slides δεν δημιουργεί καμία.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς ανανέωση της μικρογραφίας της:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Η απενεργοποίηση της ανανέωσης της μικρογραφίας μπορεί να μειώσει τον χρόνο που απαιτείται για την αποθήκευση ενός αρχείου PPTX.
{{% /alert %}}

## **Αποθήκευση ενημερώσεων προόδου σε ποσοστό**

Για να παρακολουθείτε μια λειτουργία αποθήκευσης, υλοποιήστε τη διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprogresscallback/) και περάστε την υλοποίηση στη μέθοδο [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Το Aspose.Slides στη συνέχεια καλεί τη μέθοδο [IProgressCallback.reporting](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) με τιμές προόδου κατά την εξαγωγή.

Το παρακάτω παράδειγμα αναφέρει την πρόοδο εξαγωγής PDF στην κονσόλα:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Το Aspose παρέχει ένα δωρεάν [PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χτισμένο με το API του Aspose.Slides. Αποθηκεύει τις επιλεγμένες διαφάνειες από μια παρουσίαση ως ξεχωριστά αρχεία PPT ή PPTX.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την επαναληπτική ή «γρήγορη αποθήκευση»;**

Όχι. Κάθε λειτουργία αποθήκευσης γράφει ένα πλήρες αρχείο εξόδου αντί να ενημερώνει μόνο τα τροποποιημένα μέρη.

**Μπορούν πολλαπλά νήματα να αποθηκεύσουν το ίδιο στιγμιότυπο Presentation;**

Όχι. Ένα στιγμιότυπο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) [δεν είναι ασφαλές για νήματα](/slides/el/androidjava/multithreading/). Πρόσβαση και αποθήκευση κάθε στιγμιότυπου πρέπει να γίνεται από ένα μόνο νήμα τη φορά.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία όταν αποθηκεύω μια παρουσίαση;**

[Hyperlinks](/slides/el/androidjava/manage-hyperlinks/) παραμένουν στην παρουσίαση. Το Aspose.Slides δεν αντιγράφει εξωτερικά συνδεδεμένα αρχεία, έτσι η αποθηκευμένη παρουσίαση πρέπει ακόμη να μπορεί να προσπελάσει τις θέσεις τους.

**Μπορώ να αποθηκεύσω μεταδεδομένα εγγράφου όπως το όνομα δημιουργού, τίτλο, εταιρεία και ημερομηνία δημιουργίας;**

Ναι. Ορίστε τις κατάλληλες [document properties](/slides/el/androidjava/presentation-properties/) πριν από την αποθήκευση και το Aspose.Slides θα τις γράψει στο αρχείο εξόδου.