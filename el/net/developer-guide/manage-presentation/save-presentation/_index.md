---
title: "Αποθήκευση παρουσιάσεων σε .NET"
linktitle: "Αποθήκευση παρουσίασης"
type: docs
weight: 80
url: /el/net/save-presentation/
keywords:
- "αποθήκευση PowerPoint"
- "αποθήκευση OpenDocument"
- "αποθήκευση παρουσίασης"
- "αποθήκευση διαφάνειας"
- "αποθήκευση PPT"
- "αποθήκευση PPTX"
- "αποθήκευση ODP"
- "παρουσίαση σε αρχείο"
- "παρουσίαση σε ροή"
- "προκαθορισμένος τύπος προβολής"
- "Αυστηρή μορφή Office Open XML"
- "Λειτουργία Zip64"
- "ανανέωση μικρογραφίας"
- "πρόοδος αποθήκευσης"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε .NET χρησιμοποιώντας το Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας τις διατάξεις, τις γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Open Presentations in C#](/slides/el/net/open-presentation/) περιέγραψε πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) περιέχει τα περιεχόμενα μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε μόλις τελειώσετε. Με το Aspose.Slides για .NET, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τις διαφορετικές μεθόδους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Περνέστε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```cs
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Κάντε κάποια εργασία εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Αποθήκευση παρουσιάσεων σε ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια έξοδο ροής στη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ροή αρχείου.

```cs
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Αποθηκεύστε την παρουσίαση στη ροή.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Αποθήκευση παρουσιάσεων με προκαθορισμένο τύπο προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργημένη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/). Ορίστε την ιδιότητα [LastView](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/lastview/) σε μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Αποθήκευση παρουσιάσεων στη αυστηρή μορφή Office Open XML**

Το Aspose.Slides σας επιτρέπει να αποθηκεύσετε μια παρουσίαση στη σκληρή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pptxoptions/) και ρυθμίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε `Conformance.Iso29500_2008_Strict`, το αρχείο εξόδου αποθηκεύεται στη σκληρή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει στη σκληρή μορφή Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποθήκευση της παρουσίασης σε σκληρή μορφή Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML σε λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει περιορισμούς 4 GB (2^32 byte) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του συμπλέγματος, καθώς επίσης περιορίζει το συμπλέγμα σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτούς τους περιορισμούς σε 2^64.

Η ιδιότητα [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipptxoptions/zip64mode/) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιείτε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η ιδιότητα παρέχει τις ακόλουθες λειτουργίες:

- `IfNecessary` χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο αν η παρουσίαση υπερβαίνει τους παραπάνω περιορισμούς. Αυτή είναι η προεπιλεγμένη λειτουργία.
- `Never` δεν χρησιμοποιεί ποτέ τις επεκτάσεις μορφής ZIP64.
- `Always` χρησιμοποιεί πάντα τις επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

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
Όταν αποθηκεύετε με `Zip64Mode.Never`, εξαίρεση [PptxException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxexception/) ρίχνεται εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση της μικρογραφίας**

Η ιδιότητα [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) ελέγχει τη δημιουργία μικρογραφίας κατά την αποθήκευση μιας παρουσίασης σε PPTX:

- Αν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτή είναι η προεπιλογή.
- Αν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν θα δημιουργηθεί καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεώσει τη μικρογραφία της.

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

## **Αποθήκευση ενημερώσεων προόδου σε ποσοστό**

Η διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της ιδιότητας `ProgressCallback` που εκτίθεται από τη διεπαφή [ISaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/). Αναθέστε μια υλοποίηση [IProgressCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iprogresscallback/) στην `ProgressCallback` για να λαμβάνετε ενημερώσεις προόδου αποθήκευσης ως ποσοστό.

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
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter app](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σάς επιτρέπει να χωρίσετε μια παρουσίαση σε πολλαπλά αρχεία αποθηκεύοντας τις επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Κάθε αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές ως προς το multithreading να αποθηκεύσετε το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) δεν είναι thread‑safe· αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

[Hyperlinks](/slides/el/net/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ., βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Οι τυπικές [document properties](/slides/el/net/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.