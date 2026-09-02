---
title: Αποθήκευση παρουσιάσεων σε .NET
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
- Αυστηρή μορφή Office Open XML
- λειτουργία Zip64
- ανανέωση μικρογραφίας
- αποθήκευση προόδου
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε .NET χρησιμοποιώντας το Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας διατάξεις, γραμματοσειρές και εφέ."
---
## **Επισκόπηση**

[Open Presentations in C#](/slides/el/net/open-presentation/) περιέγραψε πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) περιέχει το περιεχόμενο μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides for .NET, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τις διαφορετικές μεθόδους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Δώστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Κάντε κάποια εργασία εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Αποθήκευση παρουσιάσεων σε ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια ροή εξόδου στη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ροή αρχείου.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Αποθηκεύστε την παρουσίαση στην ροή.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Αποθήκευση παρουσιάσεων με προκαθορισμένο τύπο προβολής**

Το Aspose.Slides σάς επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η παραγόμενη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/). Ορίστε την ιδιότητα [LastView](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/lastview/) σε μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Αποθήκευση παρουσιάσεων σε αυστηρή μορφή Office Open XML**

Το Aspose.Slides επιτρέπει την αποθήκευση μιας παρουσίασης σε αυστηρή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε `Conformance.Iso29500_2008_Strict`, το αρχείο εξόδου αποθηκεύεται στην αυστηρή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και τη σώζει στην αυστηρή μορφή Office Open XML.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποθηκεύστε την παρουσίαση στην αυστηρή μορφή Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Αποθήκευση παρουσιάσεων σε Office Open XML μορφή σε λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που θέτει όρια 4 GB (2^32 bytes) στο ασυμπίεστο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, καθώς και όριο 65 535 (2^16‑1) αρχείων. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η ιδιότητα [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipptxoptions/zip64mode/) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιείτε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η ιδιότητα παρέχει τις ακόλουθες λειτουργίες:

- `IfNecessary` χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τα παραπάνω όρια. Αυτή είναι η προεπιλεγμένη λειτουργία.
- `Never` δεν χρησιμοποιεί ποτέ επεκτάσεις μορφής ZIP64.
- `Always` χρησιμοποιεί πάντα επεκτάσεις μορφής ZIP64.

Ο ακόλουθος κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
When you save with `Zip64Mode.Never`, a [PptxException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxexception/) is thrown if the presentation cannot be saved in ZIP32 format.
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων σε Office Open XML μορφή με επίπεδα συμπίεσης**

Κατά την εργασία με μεγάλες παρουσιάσεις, μπορείτε να προσαρμόσετε το επίπεδο συμπίεσης ώστε να εξισορροπήσετε το μέγεθος του αρχείου και το χρόνο επεξεργασίας. Ανάλογα με τις απαιτήσεις σας, μπορείτε να προτιμήσετε ταχύτερη επεξεργασία ή μικρότερα αρχεία εξόδου.

Το Aspose.Slides παρέχει την ιδιότητα [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipptxoptions/compressionlevel/), η οποία σας επιτρέπει να καθορίσετε το επίπεδο συμπίεσης που χρησιμοποιείται όταν αποθηκεύετε μια παρουσίαση σε μορφή Office Open XML.

Τα διαθέσιμα επίπεδα συμπίεσης είναι:

- **None**: Δεν εφαρμόζεται συμπίεση. Τα αρχεία αποθηκεύονται όπως είναι.
- **Level1**: Η ταχύτερη συμπίεση με το χαμηλότερο λόγο συμπίεσης.
- **Level2**: Ταχύτερη συμπίεση με ελαφρώς καλύτερο λόγο από το **Level1**.
- **Level3**: Παρέχει καλύτερη συμπίεση από το **Level2** με μέτρια επίπτωση στον χρόνο επεξεργασίας.
- **Level4**: Παρέχει καλύτερη συμπίεση από το **Level3**.
- **Level5**: Βελτιωμένη συμπίεση σε σχέση με το **Level4** με επιπλέον χρόνο επεξεργασίας.
- **Level6**: Τυπική συμπίεση που προσφέρει καλή ισορροπία μεταξύ ταχύτητας επεξεργασίας και μεγέθους αρχείου. Αυτό είναι το *προεπιλεγμένο επίπεδο συμπίεσης*.
- **Level7**: Καλύτερη συμπίεση από το **Level6** με πιο αργή επεξεργασία.
- **Level8**: Καλύτερη συμπίεση από το **Level7**.
- **Level9**: Μέγιστη συμπίεση. Παράγει το μικρότερο μέγεθος αρχείου με κόστος του μεγαλύτερου χρόνου επεξεργασίας.

Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX *χωρίς συμπίεση*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Αυτό το παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με *μέγιστη συμπίεση*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση της μικρογραφίας**

Η ιδιότητα [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) ελέγχει τη δημιουργία μικρογραφίας κατά την αποθήκευση μιας παρουσίασης σε PPTX:

- Εάν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι το προεπιλεγμένο.
- Εάν οριστεί σε `false`, διατηρείται η τρέχουσα μικρογραφία. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται νέα.

Στον κώδικα παρακάτω, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεώνεται η μικρογραφία της.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
This option helps reduce the time required to save a presentation in PPTX format.
{{% /alert %}}

## **Αποθήκευση προόδου σε ποσοστό**

Η διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της ιδιότητας `ProgressCallback` που εκτίθεται από τη διεπαφή [ISaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/). Αναθέστε μια υλοποίηση [IProgressCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iprogresscallback/) στη `ProgressCallback` για να λαμβάνετε ενημερώσεις προόδου αποθήκευσης ως ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Χρησιμοποιήστε την τιμή ποσοστού προόδου εδώ.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose has developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/el/splitter) using its own API. The app lets you split a presentation into multiple files by saving selected slides as new PPTX or PPT files.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές από νήμα (thread‑safe) το να αποθηκεύετε το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](/slides/el/net/multithreading/) δεν είναι thread‑safe· αποθηκεύστε το από ένα μόνο νήμα.

**Τι γίνεται με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

Οι [Hyperlinks](/slides/el/net/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μετα-δεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Τα τυπικά [document properties](/slides/el/net/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.