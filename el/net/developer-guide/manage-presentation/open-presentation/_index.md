---
title: "Άνοιγμα Παρουσιών σε .NET"
linktitle: "Άνοιγμα Παρουσίασης"
type: docs
weight: 20
url: /el/net/open-presentation/
keywords:
- "άνοιγμα PowerPoint"
- "άνοιγμα παρουσίασης"
- "άνοιγμα PPTX"
- "άνοιγμα PPT"
- "άνοιγμα ODP"
- "φόρτωση παρουσίασης"
- "φόρτωση PPTX"
- "φόρτωση PPT"
- "φόρτωση ODP"
- "προστατευμένη παρουσίαση"
- "μεγάλη παρουσίαση"
- "εξωτερικός πόρος"
- "δυαδικό αντικείμενο"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε C#, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε τη χρήση μνήμης με το Aspose.Slides για .NET."
---
## **Εισαγωγή**

[Aspose.Slides for .NET](https://products.aspose.com/slides/el/net/) μπορεί να φορτώσει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Μετά τη φόρτωση μιας παρουσίασης, μπορείτε να εξετάσετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε τους πόρους και να την αποθηκεύσετε στην αρχική ή σε μια άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε κωδικό πρόσβασης ανοίγματος, να διατηρείτε μεγάλα δυαδικά αντικείμενα εκτός της διαχειριζόμενης μνήμης, να ελέγχετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιών**

Μετά τη φόρτωση ενός αρχείου ή ροής, μπορείτε να [καθορίσετε την αρχική μορφή της παρουσίασης](/slides/el/net/detect-presentation-source-format/) για να επιλέξετε πώς θα τη επεξεργαστεί η εφαρμογή σας.

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Καταργήστε την παρουσίαση μετά τη χρήση ώστε τα χειριστήρια αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερωθούν άμεσα.

Το ακόλουθο παράδειγμα C# δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Άνοιγμα Παρουσιών με Προστασία Κωδικού Πρόσβασης**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, εκχωρήστε τον σωστό κωδικό πρόσβασης στο [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/) και περάστε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Η φόρτωση αποτυγχάνει εάν λείπει ή είναι εσφαλμένος ο κωδικός πρόσβασης.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Για ανίχνευση κωδικού πρόσβασης, επικύρωση και διαδικασίες κρυπτογράφησης, δείτε το [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/net/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσια ιδιότητες εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό πρόσβασης· δείτε τη [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/net/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιών**

Το [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/blobmanagementoptions/) ελέγχει πώς το Aspose.Slides διαχειρίζεται μεγάλες δυαδικές αντικειμενικές (BLOB) όπως εικόνες, ήχο και βίντεο. Μπορείτε να διατηρήσετε το πηγαίο αρχείο κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα των δεδομένων BLOB που διατηρούνται στη μνήμη.

Το ακόλουθο κώδικα C# επιδεικνύει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

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
Με το `PresentationLockingBehavior.KeepLocked`, το πηγαίο αρχείο παραμένει κλειδωμένο μέχρι να καταργηθεί το αντικείμενο `Presentation`. Μην μετακινήσετε, αντικαταστήσετε ή διαγράψετε το πηγαίο αρχείο ενώ αυτό το αντικείμενο είναι ενεργό.

Το Aspose.Slides ενδέχεται να αντιγράψει τα περιεχόμενα μιας εισόδου ροής κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, η διαδρομή αρχείου είναι κατά συνέπεια γενικά πιο αποδοτική από μια ροή. Δείτε το [Διαχείριση BLOBs](/slides/el/net/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

Το [LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/resourceloadingcallback/) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iresourceloadingcallback/). Η κλήση-πίσω μπορεί να παρέχει δεδομένα αντικατάστασης, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει το προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να επιλυθούν σύμφωνα με κανόνες ασφαλείας ή αποθήκευσης ειδικούς για την εφαρμογή.

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

## **Φόρτωση Παρουσιών χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν θέλει να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- VBA projects, διαθέσιμα μέσω του [IPresentation.VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/vbaproject/);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω του [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/el/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω του [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/el/net/aspose.slides/icontrol/activexcontrolbinary/).

Ορίστε το [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα πακέτα, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόβουλου λογισμικού ή καθαρισμού περιεχομένου.

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

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να διαπιστώ ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Το Aspose.Slides ρίχνει μια εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Διαχειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης, ώστε η εφαρμογή να μπορεί να αναφέρει ακριβώς την αιτία.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμα να φορτωθεί, αλλά η απόδοση και η εξαγωγή ενδέχεται να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [ρυθμίσετε την αντικατάσταση γραμματοσειρών](/slides/el/net/font-substitution/) ή να [παρέχετε προσαρμοσμένες γραμματοσειρές](/slides/el/net/custom-font/) για να κάνετε το αποτέλεσμα πιο προβλέψιμο.

**Φορτώνει η φόρτωση μιας παρουσίασης και τα ενσωματωμένα μέσα της;**

Τα ενσωματωμένα ήχοι και βίντεο γίνονται διαθέσιμα μέσω του μοντέλου αντικειμένων της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη διαμορφωμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι διαθέσιμοι εάν οι θέσεις τους δεν είναι προσβάσιμες.