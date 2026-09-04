---
title: Άνοιγμα Παρουσιάσεων σε .NET
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/net/open-presentation/
keywords:
- άνοιγμα PowerPoint
- άνοιγμα παρουσίασης
- άνοιγμα PPTX
- άνοιγμα PPT
- άνοιγμα ODP
- φόρτωση παρουσίασης
- φόρτωση PPTX
- φόρτωση PPT
- φόρτωση ODP
- προστατευμένη παρουσίαση
- μεγάλη παρουσίαση
- εξωτερικός πόρος
- δυαδικό αντικείμενο
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε C#, να παρέχετε κωδικούς ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε τη χρήση μνήμης με το Aspose.Slides για .NET."
---
## **Εισαγωγή**

[Aspose.Slides for .NET](https://products.aspose.com/slides/el/net/) μπορεί να φορτώσει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Μετά τη φόρτωση μιας παρουσίασης, μπορείτε να επιθεωρήσετε τη δομή της, να επεξεργαστείτε διαφάνειες, να διαχειριστείτε πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε κωδικό ανοίγματος, να διατηρείτε μεγάλα δυαδικά αντικείμενα εκτός διαχειριζόμενης μνήμης, να ελέγχετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στη συναρτήση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) . Κλείστε (Dispose) την παρουσίαση μετά τη χρήση ώστε να απελευθερωθούν άμεσα οι πόροι αρχείου, τα προσωρινά δεδομένα και άλλοι πόροι.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Άνοιγμα Παρουσιάσεων με Προστασία Κωδικού**

Ένας κωδικός ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, ορίστε τον σωστό κωδικό στο [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/) και περάστε τις επιλογές στη συναρτήση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) . Η φόρτωση αποτυγχάνει όταν λείπει ή είναι λανθασμένος ο κωδικός.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Για διαδικασίες ανίχνευσης, επικύρωσης και κρυπτογράφησης κωδικού, δείτε [Password-Protect Presentations](/slides/el/net/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσια ιδιότητα εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό· δείτε [Manage Presentation Properties](/slides/el/net/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/blobmanagementoptions/) ελέγχει πώς το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να κρατήσετε το αρχείο πηγής κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα δεδομένων BLOB που διατηρούνται στη μνήμη.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Με την επιλογή `PresentationLockingBehavior.KeepLocked`, το αρχείο πηγής παραμένει κλειδωμένο μέχρι να κλείσει (Dispose) το αντικείμενο `Presentation`. Μην μετακινείτε, αντικαθιστάτε ή διαγράφετε το αρχείο πηγής όσο το αντικείμενο αυτό είναι ενεργό.

Το Aspose.Slides ενδέχεται να αντιγράψει το περιεχόμενο μιας ροής εισόδου κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, μια διαδρομή αρχείου είναι συνήθως πιο αποδοτική από μια ροή. Δείτε [Manage BLOBs](/slides/el/net/manage-blob/) για επιπλέον επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/resourceloadingcallback/) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iresourceloadingcallback/). Η ανάκληση μπορεί να παρέχει αντικαταστάσια δεδομένα, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να επιλυθούν σύμφωνα με κανόνες ασφαλείας ή αποθήκευσης της εφαρμογής.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν θέλει να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- VBA projects, διαθέσιμα μέσω [IPresentation.VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/vbaproject/);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/el/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/el/net/aspose.slides/icontrol/activexcontrolbinary/).

Ορίστε [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα φορτία, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόβουλου λογισμικού ή απολύτως καθαρισμού περιεχομένου.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Το Aspose.Slides ρίχνει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Διαχειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού ώστε η εφαρμογή να μπορεί να αναφέρει ακριβώς την αιτία.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί να φορτωθεί, αλλά η απόδοση και η εξαγωγή μπορεί να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [configure font substitution](/slides/el/net/font-substitution/) ή να [provide custom fonts](/slides/el/net/custom-font/) για πιο προβλέψιμο αποτέλεσμα.

**Φορτώνει η φόρτωση μιας παρουσίασης επίσης και τα ενσωματωμένα μέσα;**

Τα ενσωματωμένα ήχου και βίντεο γίνονται διαθέσιμα μέσω του μοντέλου αντικειμένων της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι διαθέσιμοι εάν οι τοποθεσίες τους δεν είναι προσβάσιμες.