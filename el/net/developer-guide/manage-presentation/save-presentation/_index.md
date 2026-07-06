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
- παρουσίαση σε ρεύμα
- προκαθορισμένος τύπος προβολής
- Strict Office Open XML μορφή
- λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε .NET χρησιμοποιώντας το Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας διαμορφώσεις, γραμματοσειρές και εφέ."
---
## **Επισκόπηση**

[Άνοιγμα Παρουσιάσεων σε C#](/slides/el/net/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) περιέχει το περιεχόμενο μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν ολοκληρώσετε. Με το Aspose.Slides για .NET, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ρεύμα**. Αυτό το άρθρο εξηγεί τους διαφορετικούς τρόπους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Περάστε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```cs
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Κάντε κάποια εργασία εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Αποθήκευση Παρουσιάσεων σε Ρεύματα**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ρεύμα περνώντας ένα ρεύμα εξόδου στη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ρεύματος. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ρεύμα αρχείου.

```cs
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Αποθηκεύστε την παρουσίαση στο ρεύμα.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργημένη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/). Ορίστε την ιδιότητα [LastView](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/lastview/) σε μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Αποθήκευση Παρουσιάσεων σε Strict Office Open XML Μορφή**

Το Aspose.Slides σας επιτρέπει να αποθηκεύσετε μια παρουσίαση σε Strict Office Open XML μορφή. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε `Conformance.Iso29500_2008_Strict`, το αρχείο εξόδου αποθηκεύεται σε Strict Office Open XML μορφή.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει σε Strict Office Open XML μορφή.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποθηκεύστε την παρουσίαση σε Strict Office Open XML μορφή.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Μορφή σε Λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει όρια 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, καθώς και όριο 65 535 (2^16‑1) αρχείων. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η ιδιότητα [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipptxoptions/zip64mode/) σας επιτρέπει να επιλέξετε πότε θα χρησιμοποιούνται οι επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός Office Open XML αρχείου.

Αυτή η ιδιότητα παρέχει τις παρακάτω λειτουργίες:

- `IfNecessary` χρησιμοποιεί επεκτάσεις ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τα παραπάνω όρια. Αυτή είναι η προεπιλογή.
- `Never` δεν χρησιμοποιεί ποτέ επεκτάσεις ZIP64.
- `Always` χρησιμοποιεί πάντα επεκτάσεις ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Όταν αποθηκεύετε με `Zip64Mode.Never`, ρίχνεται μια [PptxException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxexception/) εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Μορφή με Επίπεδα Συμπίεσης**

Όταν εργάζεστε με μεγάλες παρουσιάσεις, μπορείτε να ρυθμίσετε το επίπεδο συμπίεσης για να εξισορροπήσετε το μέγεθος του αρχείου και το χρόνο επεξεργασίας. Ανάλογα με τις απαιτήσεις σας, μπορεί να προτιμάτε ταχύτερη επεξεργασία ή μικρότερα αρχεία εξόδου.

Το Aspose.Slides παρέχει την ιδιότητα [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipptxoptions/compressionlevel/), η οποία σας επιτρέπει να καθορίσετε το επίπεδο συμπίεσης που χρησιμοποιείται κατά την αποθήκευση μιας παρουσίασης σε Office Open XML μορφή.

Τα διαθέσιμα επίπεδα συμπίεσης είναι:

- **None**: Δεν εφαρμόζεται συμπίεση. Τα αρχεία αποθηκεύονται όπως είναι.
- **Level1**: Η πιο γρήγορη συμπίεση με το χαμηλότερο λόγο συμπίεσης.
- **Level2**: Ταχύτερη συμπίεση με ελαφρώς καλύτερο λόγο συμπίεσης από το **Level1**.
- **Level3**: Παρέχει καλύτερη συμπίεση από το **Level2** με μέτρια επίδραση στο χρόνο επεξεργασίας.
- **Level4**: Παρέχει καλύτερη συμπίεση από το **Level3**.
- **Level5**: Παρέχει βελτιωμένη συμπίεση σε σχέση με το **Level4** με επιπλέον χρόνο επεξεργασίας.
- **Level6**: Τυπική συμπίεση που προσφέρει καλή ισορροπία μεταξύ ταχύτητας επεξεργασίας και μεγέθους αρχείου. Αυτό είναι το *προεπιλεγμένο επίπεδο συμπίεσης*.
- **Level7**: Παρέχει καλύτερη συμπίεση από το **Level6** με πιο αργή επεξεργασία.
- **Level8**: Παρέχει καλύτερη συμπίεση από το **Level7**.
- **Level9**: Μέγιστη συμπίεση. Παράγει το μικρότερο μέγεθος αρχείου με κόστος του μεγαλύτερου χρόνου επεξεργασίας.

Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX *χωρίς συμπίεση*:

```cs
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
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση της Μικρογραφίας**

Η ιδιότητα [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) ελέγχει τη δημιουργία μικρογραφίας κατά την αποθήκευση μιας παρουσίασης σε PPTX:

- Εάν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτή είναι η προεπιλογή.
- Εάν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεωθεί η μικρογραφία της.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Αυτή η επιλογή βοηθά στη μείωση του χρόνου που απαιτείται για την αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

## **Αποθήκευση Ενημερώσεων Προόδου σε Ποσοστό**

Η διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της ιδιότητας `ProgressCallback` που εκτίθεται από τη διεπαφή [ISaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/). Εκχωρήστε μια υλοποίηση του [IProgressCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iprogresscallback/) στο `ProgressCallback` για να λαμβάνετε ενημερώσεις προόδου αποθήκευσης ως ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Χρησιμοποιήστε εδώ την τιμή ποσοστού προόδου.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σας επιτρέπει να χωρίσετε μια παρουσίαση σε πολλαπλά αρχεία αποθηκεύοντας επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) έτσι ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές ως προς τα νήματα (thread‑safe) να αποθηκεύσετε το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) [δεν είναι thread‑safe](/slides/el/net/multithreading/); αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

[Hyperlinks](/slides/el/net/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Τα τυπικά [document properties](/slides/el/net/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.