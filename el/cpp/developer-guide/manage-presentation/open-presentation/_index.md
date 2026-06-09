---
title: Άνοιγμα Παρουσιάσεων σε C++
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/cpp/open-presentation/
keywords:
- άνοιγμα PowerPoint
- άνοιγμα OpenDocument
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
- C++
- Aspose.Slides
description: "Ανοίξτε παρουσιάσεις PowerPoint (.pptx, .ppt) και OpenDocument (.odp) χωρίς κόπο με το Aspose.Slides για C++—γρήγορα, αξιόπιστα, πλήρως εξοπλισμένα."
---
## **Εισαγωγή**

Πέρα από τη δημιουργία παρουσιάσεων PowerPoint από το μηδέν, το Aspose.Slides σας επιτρέπει επίσης να ανοίξετε υπάρχουσες παρουσιάσεις. Αφού φορτώσετε μια παρουσίαση, μπορείτε να ανακτήσετε πληροφορίες σχετικά με αυτήν, να επεξεργαστείτε το περιεχόμενο των διαφανειών, να προσθέσετε νέες διαφάνειες, να αφαιρέσετε τις υπάρχουσες και πολλά άλλα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και περάστε τη διαδρομή του αρχείου στον κατασκευαστή της.

Το παρακάτω παράδειγμα C++ δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών:

```cpp
// Δημιουργήστε την κλάση Presentation και περάστε τη διαδρομή του αρχείου στον κατασκευαστή της.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Εκτυπώστε το συνολικό αριθμό διαφανειών στην παρουσίαση.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Άνοιγμα Παρουσιάσεων με Προστασία Κωδικού Πρόσβασης**

Όταν χρειάζεται να ανοίξετε μια παρουσίαση με προστασία κωδικού πρόσβασης, περάστε τον κωδικό μέσω της μεθόδου [set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/) της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/) για να την αποκρυπτογραφήσετε και να τη φορτώσετε. Το παρακάτω κώδικας C++ παρουσιάζει αυτή τη λειτουργία:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Εκτελέστε λειτουργίες στην αποκρυπτογραφημένη παρουσίαση.

presentation->Dispose();
```

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

Το Aspose.Slides παρέχει επιλογές — ειδικά τη μέθοδο [get_BlobManagementOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) στην κλάση [LoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/) — για να σας βοηθήσει να φορτώσετε μεγάλες παρουσιάσεις.

Το παρακάτω κώδικας C++ δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Επιλέξτε τη συμπεριφορά KeepLocked—το αρχείο παρουσίασης θα παραμείνει κλειδωμένο για τη διάρκεια του
// του αντικειμένου Presentation, αλλά δεν χρειάζεται να φορτωθεί στη μνήμη ή να αντιγραφεί σε προσωρινό αρχείο.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// Η μεγάλη παρουσίαση έχει φορτωθεί και μπορεί να χρησιμοποιηθεί, ενώ η κατανάλωση μνήμης παραμένει χαμηλή.

// Κάντε αλλαγές στην παρουσίαση.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Αποθηκεύστε την παρουσίαση σε άλλο αρχείο. Η κατανάλωση μνήμης παραμένει χαμηλή κατά τη διάρκεια αυτής της λειτουργίας.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Μην το κάνετε! Θα προκληθεί εξαίρεση I/O επειδή το αρχείο είναι κλειδωμένο μέχρι να διαγραφεί το αντικείμενο παρουσίασης.
File::Delete(filePath);

presentation->Dispose();

// Είναι εντάξει να το κάνετε εδώ. Το αρχικό αρχείο δεν είναι πλέον κλειδωμένο από το αντικείμενο παρουσίασης.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Για να αντιμετωπιστούν ορισμένοι περιορισμοί κατά την εργασία με ροές, το Aspose.Slides ενδέχεται να αντιγράψει τα περιεχόμενα μιας ροής. Η φόρτωση μιας μεγάλης παρουσίασης από ροή προκαλεί την αντιγραφή της παρουσίασης και μπορεί να επιβραδύνει τη φόρτωση. Επομένως, όταν χρειάζεται να φορτώσετε μια μεγάλη παρουσίαση, συνιστάται ανεπιφύλακτα η χρήση της διαδρομής του αρχείου παρουσίασης αντί της ροής.

Κατά τη δημιουργία μιας παρουσίασης που περιέχει μεγάλα αντικείμενα (βίντεο, ήχος, εικόνες υψηλής ανάλυσης κ.λπ.), μπορείτε να χρησιμοποιήσετε τη [BLOB management](/slides/el/cpp/manage-blob/) για να μειώσετε την κατανάλωση μνήμης.
{{%/alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

Το Aspose.Slides παρέχει τη διεπαφή [IResourceLoadingCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/iresourceloadingcallback/) που σας επιτρέπει να διαχειρίζεστε εξωτερικούς πόρους. Το παρακάτω κώδικας C++ δείχνει πώς να χρησιμοποιήσετε τη διεπαφή `IResourceLoadingCallback`:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Φορτώστε μια εναλλακτική εικόνα.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Ορίστε μια εναλλακτική διεύθυνση URL.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Παραλείψτε όλες τις άλλες εικόνες.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση PowerPoint μπορεί να περιέχει τους παρακάτω τύπους ενσωματωμένων δυαδικών αντικειμένων:

- VBA project (προσιτό μέσω [IPresentation::get_VbaProject](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_vbaproject/));
- OLE object embedded data (προσιτό μέσω [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- ActiveX control binary data (προσιτό μέσω [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/el/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Χρησιμοποιώντας τη μέθοδο [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/), μπορείτε να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό αντικείμενο.

Αυτή η μέθοδος είναι χρήσιμη για την αφαίρεση πιθανώς κακόβουλου δυαδικού περιεχομένου. Το παρακάτω κώδικας C++ δείχνει πώς να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό περιεχόμενο:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Εκτελέστε λειτουργίες στην παρουσίαση.

presentation->Dispose();
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Θα λάβετε εξαίρεση κατά την ανάλυση/επικύρωση μορφής κατά τη φόρτωση. Τέτοια σφάλματα συχνά αναφέρουν μη έγκυρη δομή ZIP ή κατεστραμμένες εγγραφές PowerPoint.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές κατά το άνοιγμα;**

Το αρχείο θα ανοίξει, αλλά αργότερα η [απόδοση/εξαγωγή](/slides/el/cpp/convert-presentation/) ενδέχεται να αντικαταστήσει τις γραμματοσειρές. [Ρυθμίστε τις υποκατάστατες γραμματοσειρές](/slides/el/cpp/font-substitution/) ή [προσθέστε τις απαιτούμενες γραμματοσειρές](/slides/el/cpp/custom-font/) στο περιβάλλον εκτέλεσης.

**Τι γίνεται με τα ενσωματωμένα μέσα (βίντεο/ήχο) κατά το άνοιγμα;**

Γίνονται διαθέσιμα ως πόροι της παρουσίασης. Εάν τα μέσα αναφέρονται μέσω εξωτερικών διαδρομών, βεβαιωθείτε ότι αυτές οι διαδρομές είναι προσβάσιμες στο περιβάλλον σας· διαφορετικά η [απόδοση/εξαγωγή](/slides/el/cpp/convert-presentation/) ενδέχεται να παραλείψει τα μέσα.