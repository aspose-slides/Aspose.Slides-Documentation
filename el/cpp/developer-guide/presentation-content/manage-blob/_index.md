---
title: Διαχείριση BLOB Παρουσιάσεων σε C++ για Αποτελεσματική Χρήση Μνήμης
linktitle: Διαχείριση BLOB
type: docs
weight: 10
url: /el/cpp/manage-blob/
keywords:
- μεγάλο αντικείμενο
- μεγάλο στοιχείο
- μεγάλο αρχείο
- προσθήκη BLOB
- εξαγωγή BLOB
- προσθήκη εικόνας ως BLOB
- μείωση μνήμης
- κατανάλωση μνήμης
- μεγάλη παρουσίαση
- προσωρινό αρχείο
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τα δεδομένα BLOB στο Aspose.Slides για C++ ώστε να βελτιστοποιήσετε τις λειτουργίες αρχείων PowerPoint και OpenDocument για αποτελεσματικό χειρισμό παρουσιάσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει διαχείριση βασισμένη σε BLOB για μεγάλα δυαδικά δεδομένα σε παρουσιάσεις, ώστε να βοηθά στη μείωση της κατανάλωσης μνήμης όταν εργάζεστε με μεγάλες εικόνες, ήχους, βίντεο και αρχεία παρουσίασης.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε την επεξεργασία βασισμένη σε BLOB για την προσθήκη μεγάλων μέσων σε μια παρουσίαση, την εξαγωγή μεγάλων μέσων από μια παρουσίαση και τη φόρτωση μεγάλων παρουσιάσεων πιο αποδοτικά. Επίσης εξηγεί πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά τη διάρκεια της επεξεργασίας και πώς να αλλάξετε το φάκελο που χρησιμοποιείται για την αποθήκευσή τους.

## **Σχετικά με το BLOB**

**BLOB** (**Binary Large Object**) είναι συνήθως ένα μεγάλο αντικείμενο (φωτογραφία, παρουσίαση, έγγραφο ή μέσο) αποθηκευμένο σε δυαδικές μορφές.

Το Aspose.Slides for C++ σας επιτρέπει να χρησιμοποιείτε BLOBs για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν εμπλέκονται μεγάλα αρχεία.

## **Χρήση BLOB για Μείωση Κατανάλωσης Μνήμης**

### **Προσθήκη Μεγάλου Αρχείου μέσω BLOB σε Παρουσίαση**

[Aspose.Slides](/slides/el/cpp/) for C++ σας επιτρέπει να προσθέσετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα μεγάλο αρχείο βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs για τη μείωση της κατανάλωσης μνήμης.

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί το βίντεο
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Ας προσθέσουμε το βίντεο στην παρουσίαση - επιλέξαμε τη συμπεριφορά KeepLocked επειδή
//δεν προτίθενται να προσπελάσουν το αρχείο "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Αποθηκεύει την παρουσίαση. Καθώς μια μεγάλη παρουσίαση εξάγεται, η κατανάλωση μνήμης
// παραμένει χαμηλή κατά τη διάρκεια του κύκλου ζωής του αντικειμένου pres
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Εξαγωγή Μεγάλου Αρχείου μέσω BLOB από Παρουσίαση**
Το Aspose.Slides for C++ σας επιτρέπει να εξάγετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα αρχείο ήχου ή βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξαγάγετε ένα μεγάλο αρχείο μέσου από μια παρουσίαση αλλά να μην θέλετε το αρχείο να φορτωθεί στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BLOB, διατηρείτε τη χρήση μνήμης χαμηλή.

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Δημιουργεί μια παρουσίαση, κλειδώνει το αρχείο "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Ας αποθηκεύσουμε κάθε βίντεο σε αρχείο. Για να αποτρέψουμε την υψηλή κατανάλωση μνήμης, χρειαζόμαστε ένα buffer που θα χρησιμοποιηθεί
// για τη μεταφορά των δεδομένων από τη ροή βίντεο της παρουσίασης σε ροή για ένα νέο αρχείο βίντεο.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Επανάληψη μέσω των βίντεο
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Ανοίγει τη ροή βίντεο της παρουσίασης. Παρακαλώ, σημειώστε ότι αποφεύγουμε εκ προθέσεως την πρόσβαση σε μεθόδους
	// όπως video->get_BinaryData - επειδή αυτή η μέθοδος επιστρέφει έναν πίνακα byte που περιέχει ολόκληρο το βίντεο, το οποίο μετά
	// προκαλεί τη φόρτωση των byte στη μνήμη. Χρησιμοποιούμε video->GetStream, το οποίο επιστρέφει Stream - και ΔΕΝ
	// απαιτεί να φορτώσουμε ολόκληρο το βίντεο στη μνήμη.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Η κατανάλωση μνήμης θα παραμείνει χαμηλή ανεξαρτήτως του μεγέθους του βίντεο ή της παρουσίασης,
}

// Αν χρειαστεί, μπορείτε να εφαρμόσετε τα ίδια βήματα για αρχεία ήχου.
```

### **Προσθήκη Εικόνας ως BLOB σε Παρουσίαση**
Με τις μεθόδους από τη διεπαφή [**IImageCollection**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_image_collection) και την κλάση [**ImageCollection** ](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.image_collection) μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να αντιμετωπιστεί ως BLOB.

```cpp
const String pathToLargeImage = u"large_image.jpg";

// δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί η εικόνα.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Ας προσθέσουμε την εικόνα στην παρουσίαση - επιλέγουμε τη συμπεριφορά KeepLocked επειδή
// ΔΕΝ προτίθεσθαι να προσπελάσουμε το αρχείο "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Αποθηκεύει την παρουσίαση. Καθώς μια μεγάλη παρουσίαση εξάγεται, η κατανάλωση μνήμης 
// παραμένει χαμηλή κατά τη διάρκεια του κύκλου ζωής του αντικειμένου pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Μνήμη και Μεγάλες Παρουσιάσεις**

Κανονικά, για τη φόρτωση μιας μεγάλης παρουσίασης, οι υπολογιστές απαιτούν πολύ προσωρινή μνήμη. Όλο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) δεν χρησιμοποιείται πλέον.

Σκεφτείτε μια μεγάλη παρουσίαση PowerPoint (large.pptx) που περιέχει ένα βίντεο αρχείου 1,5 GB. Η τυπική μέθοδος για τη φόρτωση της παρουσίασης περιγράφεται σε αυτόν τον κώδικα C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Αλλά αυτή η μέθοδος καταναλώνει περίπου 1,6 GB προσωρινής μνήμης.

### **Φόρτωση Μεγάλης Παρουσίασης ως BLOB**

Μέσω της διαδικασίας που περιλαμβάνει BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας λίγη μνήμη. Αυτός ο κώδικας C++ περιγράφει την υλοποίηση όπου η διαδικασία BLOB χρησιμοποιείται για τη φόρτωση ενός μεγάλου αρχείου παρουσίασης (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Αλλαγή Φακέλου για Προσωρινά Αρχεία**

Όταν χρησιμοποιείται η διαδικασία BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στον προεπιλεγμένο φάκελο προσωρινών αρχείων. Εάν θέλετε τα προσωρινά αρχεία να διατηρηθούν σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας το `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείτε το `TempFilesRootPath`, το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση προσωρινών αρχείων. Πρέπει να δημιουργήσετε το φάκελο χειροκίνητα. 
{{% /alert %}}

### **Καταστροφή Αντικειμένων Παρουσίασης για Απελευθέρωση Μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι η παρουσίαση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) έχει διαγραφεί σωστά ώστε η μνήμη που κατείχε να απελευθερωθεί. Καλέστε το `Dispose()` αφού τελειώσετε τη χρήση της παρουσίασης για να ελευθερώσετε τους μη διαχειριζόμενους πόρους.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...επεξεργασία της παρουσίασης...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Απελευθερώνει ρητά τους πόρους.
presentation->Dispose();
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides θεωρούνται ως BLOB και ελέγχονται από τις επιλογές BLOB;**

Μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχοι και βίντεο θεωρούνται ως BLOB. Ολόκληρο το αρχείο παρουσίασης επίσης εμπλέκεται στη διαχείριση BLOB όταν φορτώνεται ή αποθηκεύεται. Αυτά τα αντικείμενα διέπονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και να μεταφέρετε δεδομένα σε προσωρινά αρχεία όταν χρειάζεται.

**Πού μπορώ να διαμορφώσω τους κανόνες διαχείρισης BLOB κατά τη φόρτωση της παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/) μαζί με το [BlobManagementOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/blobmanagementoptions/). Εκεί ορίζετε το όριο μνήμης για BLOB, επιτρέπετε ή αποτρέπετε τη χρήση προσωρινών αρχείων, επιλέγετε τη ρίζα διαδρομή για τα προσωρινά αρχεία και ορίζετε τη συμπεριφορά κλειδώματος της πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση, και πώς μπορώ να ισορροπήσω την ταχύτητα με τη μνήμη;**

Ναι. Η διατήρηση του BLOB στη μνήμη μεγιστοποιεί την ταχύτητα αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταθέτει περισσότερη εργασία σε προσωρινά αρχεία, μειώνοντας τη RAM με κόστος επιπλέον I/O. Χρησιμοποιήστε τη μέθοδο [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/el/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) για να πετύχετε τη σωστή ισορροπία για το φορτίο εργασίας και το περιβάλλον σας.

**Βοηθούν οι επιλογές BLOB όταν ανοίγετε εξαιρετικά μεγάλες παρουσιάσεις (π.χ., σε γιγαμπάιτ);**

Ναι. Τα [BlobManagementOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/blobmanagementoptions/) έχουν σχεδιαστεί για τέτοια σενάρια: η ενεργοποίηση των προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά τη μέγιστη χρήση RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων παρουσιάσεων.

**Μπορώ να χρησιμοποιήσω τις πολιτικές BLOB όταν φορτώνω από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιοι κανόνες ισχύουν για τις ροές: το αντικείμενο παρουσίασης μπορεί να κατέχει και να κλειδώσει τη ροή εισόδου (ανάλογα με τη δοθείσα λειτουργία κλειδώματος), και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπεται, διατηρώντας τη χρήση μνήμης προβλέψιμη κατά την επεξεργασία.