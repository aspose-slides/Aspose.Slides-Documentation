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
description: "Ανοίξτε παρουσιάσεις PowerPoint (.pptx, .ppt) και OpenDocument (.odp) με ευκολία χρησιμοποιώντας το Aspose.Slides για .NET—γρήγορο, αξιόπιστο, πλήρως εξοπλισμένο."
---
## **Εισαγωγή**

Πέρα από τη δημιουργία παρουσιάσεων PowerPoint από το μηδέν, το Aspose.Slides σας επιτρέπει επίσης να ανοίξετε υπάρχουσες παρουσιάσεις. Μετά τη φόρτωση μιας παρουσίασης, μπορείτε να ανακτήσετε πληροφορίες σχετικά με αυτήν, να επεξεργαστείτε το περιεχόμενο των διαφανειών, να προσθέσετε νέες διαφάνειες, να αφαιρέσετε υπάρχουσες και πολλά άλλα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και περάστε τη διαδρομή του αρχείου στον κατασκευαστή της.

Το παρακάτω παράδειγμα C# δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```cs
// Δημιουργήστε ένα αντίτυπο της κλάσης Presentation και περάστε μια διαδρομή αρχείου στον κατασκευαστή της.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Εκτυπώστε τον συνολικό αριθμό διαφανειών στην παρουσίαση.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Άνοιγμα Παρουσιάσεων με Προστασία Κωδικού**

Όταν χρειάζεται να ανοίξετε μια παρουσίαση με προστασία κωδικού, περάστε τον κωδικό μέσω της ιδιότητας [Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/) της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/) για να την αποκρυπτογραφήσετε και να τη φορτώσετε. Το παρακάτω κώδικας C# επιδεικνύει αυτή τη λειτουργία:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Πραγματοποιήστε λειτουργίες στην αποκρυπτογραφημένη παρουσίαση.
}
```

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

Το Aspose.Slides παρέχει επιλογές—ιδιαίτερα την ιδιότητα [BlobManagementOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/blobmanagementoptions/) στην κλάση [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/)—για να σας βοηθήσει να φορτώσετε μεγάλες παρουσιάσεις.

Το παρακάτω κώδικας C# δείχνει πώς να φορτώσετε μια μεγάλη παρουσίαση (για παράδειγμα, 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Επιλέξτε τη συμπεριφορά KeepLocked—το αρχείο παρουσίασης θα παραμείνει κλειδωμένο για τη διάρκεια του 
        // της παρουσίας Presentation, αλλά δεν χρειάζεται να φορτωθεί στη μνήμη ή να αντιγραφεί σε προσωρινό αρχείο.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Η μεγάλη παρουσίαση έχει φορτωθεί και μπορεί να χρησιμοποιηθεί, ενώ η κατανάλωση μνήμης παραμένει χαμηλή.

    // Κάντε αλλαγές στην παρουσίαση.
    presentation.Slides[0].Name = "Large presentation";

    // Αποθηκεύστε την παρουσίαση σε άλλο αρχείο. Η κατανάλωση μνήμης παραμένει χαμηλή κατά τη διάρκεια αυτής της ενέργειας.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Μην το κάνετε! Θα προκληθεί εξαίρεση I/O επειδή το αρχείο είναι κλειδωμένο μέχρι να καταργηθεί το αντικείμενο παρουσίασης.
    File.Delete(filePath);
}

// Είναι εντάξει να το κάνετε εδώ. Το αρχικό αρχείο δεν είναι πλέον κλειδωμένο από το αντικείμενο παρουσίασης.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Για να παρακάμψετε ορισμένους περιορισμούς κατά τη χρήση ροών, το Aspose.Slides ενδέχεται να αντιγράψει το περιεχόμενο μιας ροής. Η φόρτωση μιας μεγάλης παρουσίασης από ροή προκαλεί την αντιγραφή της παρουσίασης και μπορεί να επιβραδύνει τη φόρτωση. Συνεπώς, όταν πρέπει να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε ανεπιφύλακτα να χρησιμοποιείτε τη διαδρομή του αρχείου παρουσίασης αντί για ροή.

Κατά τη δημιουργία μιας παρουσίασης που περιέχει μεγάλα αντικείμενα (βίντεο, ήχο, εικόνες υψηλής ανάλυσης κ.λπ.), μπορείτε να χρησιμοποιήσετε τη [BLOB management](/slides/el/net/manage-blob/) για να μειώσετε την κατανάλωση μνήμης.
{{%/alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

Το Aspose.Slides παρέχει τη διασύνδεση [IResourceLoadingCallback](https://reference.aspose.com/slides/el/net/aspose.slides/iresourceloadingcallback/) που σας επιτρέπει να διαχειρίζεστε εξωτερικούς πόρους. Το παρακάτω κώδικας C# δείχνει πώς να χρησιμοποιήσετε τη διασύνδεση `IResourceLoadingCallback`:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Φορτώστε μια εναλλακτική εικόνα.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Ορίστε μια εναλλακτική διεύθυνση URL.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Παράλειψη όλων των άλλων εικόνων.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση PowerPoint μπορεί να περιέχει τους ακόλουθους τύπους ενσωματωμένων δυαδικών αντικειμένων:

- Έργο VBA (προσβάσιμο μέσω [IPresentation.VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/vbaproject/));
- Δεδομένα ενσωματωμένου αντικειμένου OLE (προσβάσιμα μέσω [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/el/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Δυαδικά δεδομένα ελέγχου ActiveX (προσβάσιμα μέσω [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/el/net/aspose.slides/icontrol/activexcontrolbinary/)).

Χρησιμοποιώντας την ιδιότητα [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) μπορείτε να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό αντικείμενο.

Αυτή η ιδιότητα είναι χρήσιμη για την αφαίρεση ενδεχομένως κακόβουλου δυαδικού περιεχομένου. Το παρακάτω κώδικας C# δείχνει πώς να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό περιεχόμενο:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Πραγματοποιήστε ενέργειες στην παρουσίαση.
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοίξει;**

Θα λάβετε μια εξαίρεση παρα parsing/validation μορφής κατά τη φόρτωση. Τέτοια σφάλματα συχνά αναφέρουν μια μη έγκυρη δομή ZIP ή κατεστραμμένες εγγραφές PowerPoint.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές κατά το άνοιγμα;**

Το αρχείο θα ανοίξει, αλλά αργότερα το [απόδοση/εξαγωγή](/slides/el/net/convert-presentation/) μπορεί να αντικαταστήσει τις γραμματοσειρές. [Configure font substitutions](/slides/el/net/font-substitution/) ή [add the required fonts](/slides/el/net/custom-font/) στο περιβάλλον εκτέλεσης.

**Τι γίνεται με τα ενσωματωμένα πολυμέσα (βίντεο/ήχος) κατά το άνοιγμα;**

Γίνονται διαθέσιμα ως πόροι της παρουσίασης. Εάν τα πολυμέσα αναφέρονται μέσω εξωτερικών διαδρομών, βεβαιωθείτε ότι αυτές οι διαδρομές είναι προσβάσιμες στο περιβάλλον σας· διαφορετικά το [απόδοση/εξαγωγή](/slides/el/net/convert-presentation/) μπορεί να παραλείψει τα πολυμέσα.