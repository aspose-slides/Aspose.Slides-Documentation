---
title: Αποθήκευση Παρουσιάσεων σε .NET
linktitle: Αποθήκευση Παρουσίασης
type: docs
weight: 80
url: /el/net/save-presentation/
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
- Strict μορφή Office Open XML
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- .NET
- C#
- Aspose.Slides
description: "Αποθηκεύστε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ροές με C# χρησιμοποιώντας το Aspose.Slides για .NET και διαμορφώστε την έξοδο PPTX και την αναφορά προόδου."
---
## **Επισκόπηση**

Αφού δημιουργήσετε μια παρουσίαση ή [ανοίξετε μια υπάρχουσα](/slides/el/net/open-presentation/), χρησιμοποιήστε τη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα. Το Aspose.Slides for .NET μπορεί να αποθηκεύσει μια παρουσίαση σε αρχείο ή ροή σε μορφές PowerPoint, OpenDocument, PDF και άλλες μορφές. Οι παρακάτω ενότητες καλύπτουν τις τυπικές λειτουργίες αποθήκευσης και τις διαθέσιμες επιλογές για έξοδο PPTX.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Για να αποθηκεύσετε μια παρουσίαση σε αρχείο, περάστε τη διαδρομή εξόδου και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/) στη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/). Η τιμή μορφής καθορίζει τον τύπο αρχείου που δημιουργεί το Aspose.Slides.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει ως αρχείο PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Προσθέστε ή τροποποιήστε το περιεχόμενο της παρουσίασης εδώ.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Αποθήκευση Παρουσιάσεων στην Πρωτότυπη Μορφή**

Για να δείτε παραδείγματα ανίχνευσης αρχείου και ροής, τη συμπεριφορά νέων παρουσιάσεων και τη διαφορά μεταξύ μορφών πηγής και εξόδου, δείτε [Καθορίστε την Πρωτότυπη Μορφή Παρουσίασης](/slides/el/net/detect-presentation-source-format/).

Σε μια εφαρμογή επεξεργασίας παρτίδας, η μορφή εισόδου μπορεί να μην είναι γνωστή εκ των προτέρων. Αφού φορτώσετε ένα αρχείο, διαβάστε την αρχική του μορφή από την ιδιότητα [IPresentation.SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/sourceformat/). Περάστε τη λήφθη τιμή [SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/sourceformat/) στη μέθοδο [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/tosaveformat/) για να λάβετε την αντίστοιχη τιμή [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/) και, στη συνέχεια, χρησιμοποιήστε την [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) για να γράψετε την τροποποιημένη παρουσίαση.

Το παρακάτω πλήρες παράδειγμα επεξεργάζεται κάθε αρχείο σε έναν φάκελο εισόδου, ενημερώνει τον τίτλο του και το αποθηκεύει σε φάκελο εξόδου στη μορφή από την οποία φορτώθηκε:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat] αντιστοιχίζει τα PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP και PowerPoint XML στις αντίστοιχες μορφές αποθήκευσης παρουσίασης. Αντιστοιχίζει μόνο τις μορφές προέλευσης παρουσίασης· δεν προορίζεται για την επιλογή μορφών εξαγωγής όπως PDF, HTML, TIFF ή εικόνες. Η παροχή μιας μη υποστηριζόμενης ή άκυρης τιμής [SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/sourceformat/) οδηγεί σε ένα [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Τα παλιά αρχεία PPT, PPS και POT χρησιμοποιούν το ίδιο δυαδικό κοντέινερ. Όταν μια τέτοια παρουσίαση φορτωθεί από ροή χωρίς επέκταση αρχείου, ένα αρχείο PPS ή POT μπορεί να προσδιοριστεί ως PPT. Εάν απαιτείται η διατήρηση αυτών των παλαιών υποτύπων, διατηρήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα μορφής ξεχωριστά και χρησιμοποιήστε τα κατά την επιλογή του ονόματος αρχείου και της μορφής εξόδου.

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Για να γράψετε μια παρουσίαση χωρίς να βασίζεστε σε τελική διαδρομή αρχείου, περάστε ένα εγγράψιμο [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/) στη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/). Αυτή η προσέγγιση είναι χρήσιμη όταν η έξοδος πρέπει να επιστραφεί από μια υπηρεσία web, να αποθηκευτεί σε βάση δεδομένων ή να υποβληθεί σε επεξεργασία στη μνήμη.

Το παρακάτω παράδειγμα αποθηκεύει μια νέα παρουσίαση σε ροή αρχείου:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Μπορείτε να καθορίσετε την προβολή στην οποία το PowerPoint ανοίγει αρχικά μια αποθηκευμένη παρουσίαση. Ορίστε την ιδιότητα [ViewProperties.LastView](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/lastview/) σε μια τιμή [ViewType](https://reference.aspose.com/slides/el/net/aspose.slides/viewtype/) πριν από την αποθήκευση.

Το παρακάτω παράδειγμα ρυθμίζει την προβολή Slide Master ως αρχική προβολή:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Αποθήκευση Παρουσιάσεων σε Strict Office Open XML Μορφή**

Για να δημιουργήσετε ένα αρχείο PPTX που συμμορφώνεται με το Strict προφίλ του Office Open XML, δημιουργήστε μια διεπαφή [PptxOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pptxoptions/) και ορίστε την ιδιότητά της [Conformance](https://reference.aspose.com/slides/el/net/aspose.slides.export/pptxoptions/conformance/) στην τιμή `Conformance.Iso29500_2008_Strict`. Στη συνέχεια περάστε τις επιλογές στη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Μορφή σε Κατάσταση Zip64**

Ένα τυπικό αρχείο ZIP περιορίζει το συμπιεσμένο και μη συμπιεσμένο μέγεθος κάθε καταχώρησης, το συνολικό μέγεθος της αρχειοθήκης και τον αριθμό των καταχωρήσεων. Επειδή ένα αρχείο PPTX είναι αρχείο ZIP, μια πολύ μεγάλη παρουσίαση μπορεί να ξεπεράσει αυτά τα όρια. Οι επεκτάσεις ZIP64 αυξάνουν τα σχετικά όρια μεγέθους και αριθμού καταχωρήσεων.

Χρησιμοποιήστε την ιδιότητα [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/el/net/aspose.slides.export/pptxoptions/zip64mode/) για να ελέγξετε αν το Aspose.Slides γράφει επεκτάσεις ZIP64:

- `IfNecessary` χρησιμοποιεί ZIP64 μόνο όταν η παρουσίαση υπερβαίνει τα τυπικά όρια ZIP. Αυτό είναι η προεπιλεγμένη λειτουργία.
- `Never` απενεργοποιεί τις επεκτάσεις ZIP64.
- `Always` γράφει πάντα επεκτάσεις ZIP64.

Το παρακάτω παράδειγμα ενεργοποιεί πάντα τις επεκτάσεις ZIP64 για την έξοδο παρουσίασης:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Εάν το `Zip64Mode` οριστεί σε `Never` και η παρουσίαση δεν μπορεί να χωρέσει στα τυπικά όρια ZIP, η λειτουργία αποθήκευσης εγείρει ένα [PptxException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Μορφή με Επίπεδα Συμπίεσης**

Για έξοδο PPTX, μπορείτε να ισορροπήσετε την ταχύτητα αποθήκευσης με το μέγεθος του αρχείου ορίζοντας την ιδιότητα [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/el/net/aspose.slides.export/pptxoptions/compressionlevel/). Η απαρίθμηση [CompressionLevel](https://reference.aspose.com/slides/el/net/aspose.slides.export/compressionlevel/) παρέχει τις εξής τιμές:

- `None` αποθηκεύει τα δεδομένα χωρίς συμπίεση.
- `Level1` παρέχει τη ταχύτερη συμπίεση και το μεγαλύτερο συμπιεσμένο αποτέλεσμα.
- `Level2` έως `Level5` προτιμούν σταδιακά μικρότερο αποτέλεσμα έναντι ταχύτητας αποθήκευσης.
- `Level6` ισορροπεί την ταχύτητα αποθήκευσης και το μέγεθος του αρχείου. Αυτό είναι το προεπιλεγμένο επίπεδο.
- `Level7` και `Level8` προτιμούν ακόμη περισσότερο μικρότερο αποτέλεσμα έναντι ταχύτητας αποθήκευσης.
- `Level9` παρέχει τη πιο ισχυρή συμπίεση και απαιτεί το περισσότερο χρόνο επεξεργασίας.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς συμπίεση:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Το παρακάτω παράδειγμα χρησιμοποιεί το μέγιστο επίπεδο συμπίεσης:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση της Μικρογραφίας**

Όταν μια παρουσίαση αποθηκεύεται ως PPTX, η ιδιότητα [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/el/net/aspose.slides.export/pptxoptions/refreshthumbnail/) ελέγχει τη μικρογραφία του εγγράφου:

- `true` δημιουργεί εκ νέου τη μικρογραφία κατά τη λειτουργία αποθήκευσης. Αυτή είναι η προεπιλεγμένη τιμή.
- `false` διατηρεί την υπάρχουσα μικρογραφία. Αν η παρουσίαση δεν έχει μικρογραφία, το Aspose.Slides δεν δημιουργεί καμία.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς να ανανεώσει τη μικρογραφία της:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Η απενεργοποίηση της ανανέωσης της μικρογραφίας μπορεί να μειώσει το χρόνο που απαιτείται για την αποθήκευση ενός αρχείου PPTX.
{{% /alert %}}

## **Αποθήκευση Ενημερώσεων Προόδου σε Ποσοστό**

Για να παρακολουθείτε μια λειτουργία αποθήκευσης, υλοποιήστε τη διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iprogresscallback/) και αναθέστε την υλοποίηση στην ιδιότητα [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/el/net/aspose.slides.export/isaveoptions/progresscallback/). Το Aspose.Slides, στη συνέχεια, καλεί τη μέθοδο [IProgressCallback.Reporting](https://reference.aspose.com/slides/el/net/aspose.slides/iprogresscallback/reporting/) με τιμές προόδου κατά την εξαγωγή.

Το παρακάτω παράδειγμα αναφέρει την πρόοδο μιας εξαγωγής PDF στην κονσόλα:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Το Aspose παρέχει ένα δωρεάν [PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) που είναι χτισμένο με το API του Aspose.Slides. Αποθηκεύει τις επιλεγμένες διαφάνειες από μια παρουσίαση ως ξεχωριστά αρχεία PPT ή PPTX.
{{% /alert %}}

## **FAQ**

**Υποστηρίζει το Aspose.Slides αποθήκευση επί τόπου ή «γρήγορη αποθήκευση»;**

Όχι. Κάθε λειτουργία αποθήκευσης γράφει ένα πλήρες αρχείο εξόδου αντί να ενημερώνει μόνο τα αλλαγμένα τμήματα.

**Μπορούν πολλαπλά νήματα να αποθηκεύσουν το ίδιο αντικείμενο Presentation;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) [δεν είναι thread-safe](/slides/el/net/multithreading/). Πρόσβαση και αποθήκευση κάθε αντικειμένου πρέπει να γίνεται από μόνο ένα νήμα τη φορά.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία όταν αποθηκεύω μια παρουσίαση;**

[Υπερσύνδεσμοι](/slides/el/net/manage-hyperlinks/) παραμένουν στην παρουσίαση. Το Aspose.Slides δεν αντιγράφει τα εξωτερικά συνδεδεμένα αρχεία, έτσι η αποθηκευμένη παρουσίαση πρέπει ακόμη να μπορεί να έχει πρόσβαση στις τοποθεσίες τους.

**Μπορώ να αποθηκεύσω μεταδεδομένα εγγράφου όπως ο συγγραφέας, ο τίτλος, η εταιρεία και η ημερομηνία δημιουργίας;**

Ναι. Ορίστε τις κατάλληλες [ιδιότητες εγγράφου](/slides/el/net/presentation-properties/) πριν από την αποθήκευση και το Aspose.Slides τις γράφει στο αρχείο εξόδου.