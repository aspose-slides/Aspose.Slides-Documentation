---
title: Διαχείριση BLOB Παρουσιάσεων σε .NET για Αποδοτική Χρήση Μνήμης
linktitle: Διαχείριση BLOB
type: docs
weight: 10
url: /el/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τα δεδομένα BLOB στο Aspose.Slides για .NET ώστε να βελτιστοποιήσετε τις λειτουργίες αρχείων PowerPoint και OpenDocument για αποδοτικό χειρισμό παρουσιάσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει διαχείριση με βάση το BLOB για μεγάλα δυαδικά δεδομένα σε παρουσιάσεις, ώστε να βοηθά στη μείωση της κατανάλωσης μνήμης όταν εργάζεστε με μεγάλες εικόνες, ήχους, βίντεο και αρχεία παρουσίασης.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε την επεξεργασία με BLOB για να προσθέσετε μεγάλα μέσα σε μια παρουσίαση, να εξάγετε μεγάλα μέσα από μια παρουσίαση και να φορτώσετε μεγάλες παρουσιάσεις πιο αποδοτικά. Επίσης εξηγεί πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά τη διάρκεια της επεξεργασίας και πώς να αλλάξετε τον φάκελο που χρησιμοποιείται για την αποθήκευσή τους.

## **Σχετικά με το BLOB**

Το **BLOB** (**Binary Large Object**) είναι συνήθως ένα μεγάλο αντικείμενο (φωτογραφία, παρουσίαση, έγγραφο ή μέσο) αποθηκευμένο σε δυαδικές μορφές.

Το Aspose.Slides for .NET σας επιτρέπει να χρησιμοποιήσετε BLOBs για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν εμπλέκονται μεγάλα αρχεία.

## **Χρήση BLOB για Μείωση Κατανάλωσης Μνήμης**

### **Προσθήκη Μεγάλου Αρχείου μέσω BLOB σε Παρουσίαση**

[Aspose.Slides](/slides/el/net/) for .NET σας επιτρέπει να προσθέσετε μεγάλα αρχεία (σε αυτή την περίπτωση, ένα μεγάλο βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs για μείωση της κατανάλωσης μνήμης.

Αυτό το C# δείχνει πώς να προσθέσετε ένα μεγάλο βίντεο μέσω της διαδικασίας BLOB σε μια παρουσίαση:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί το βίντεο
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Ας προσθέσουμε το βίντεο στην παρουσίαση - επιλέξαμε τη συμπεριφορά KeepLocked επειδή
        //δεν προτίθεμαι να προσπελάσω το αρχείο "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Αποθηκεύει την παρουσίαση. Ενώ μια μεγάλη παρουσίαση εξάγεται, η κατανάλωση μνήμης
        // παραμένει χαμηλή καθ' όλη τη διάρκεια ζωής του αντικειμένου pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Εξαγωγή Μεγάλου Αρχείου μέσω BLOB από Παρουσίαση**
Aspose.Slides for .NET σας επιτρέπει να εξάγετε μεγάλα αρχεία (σε αυτή την περίπτωση, ένα αρχείο ήχου ή βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξάγετε ένα μεγάλο αρχείο μέσου από μια παρουσίαση χωρίς να το φορτώσετε στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BLOB, διατηρείτε τη χρήση μνήμης χαμηλή.

Αυτός ο κώδικας σε C# επιδεικνύει τη λειτουργία που περιγράφηκε:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Κλειδώνει το αρχείο πηγής και ΔΕΝ το φορτώνει στη μνήμη
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Δημιουργεί μια παρουσίαση, κλειδώνει το αρχείο "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Ας αποθηκεύσουμε κάθε βίντεο σε αρχείο. Για να αποτρέψουμε υψηλή χρήση μνήμης, χρειαζόμαστε μια ενδιάμεση μνήμη που θα χρησιμοποιηθεί
	// για τη μεταφορά των δεδομένων από τη ροή βίντεο της παρουσίασης σε ροή για ένα νεοδημιουργημένο αρχείο βίντεο.
	byte[] buffer = new byte[8 * 1024];

	// Διατρέχει τα βίντεο
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Ανοίγει τη ροή βίντεο της παρουσίασης. Παρακαλώ σημειώστε ότι αποφεύγουμε σκόπιμα την πρόσβαση σε ιδιότητες
		// όπως video.BinaryData - επειδή αυτή η ιδιότητα επιστρέφει έναν πίνακα byte που περιέχει ολόκληρο το βίντεο, κάτι που
		// προκαλεί τη φόρτωση των bytes στη μνήμη. Χρησιμοποιούμε το video.GetStream, το οποίο επιστρέφει Stream - και ΔΕΝ
		//  απαιτεί να φορτώσουμε ολόκληρο το βίντεο στη μνήμη.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// Η κατανάλωση μνήμης θα παραμείνει χαμηλή ανεξάρτητα από το μέγεθος του βίντεο ή της παρουσίασης,
	}

	// Αν χρειαστεί, μπορείτε να εφαρμόσετε τα ίδια βήματα για αρχεία ήχου. 
}
```

### **Προσθήκη Εικόνας ως BLOB σε Παρουσίαση**
Με τις μεθόδους από το [**IImageCollection**](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection) interface και την κλάση [**ImageCollection**](https://reference.aspose.com/slides/el/net/aspose.slides/imagecollection), μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να αντιμετωπίζεται ως BLOB.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε μια μεγάλη εικόνα μέσω της διαδικασίας BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί η εικόνα.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Ας προσθέσουμε την εικόνα στην παρουσίαση - επιλέγουμε τη συμπεριφορά KeepLocked επειδή
		//  ΔΕΝ προτίθεμαι να προσπελάσω το αρχείο "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Αποθηκεύει την παρουσίαση. Ενώ μια μεγάλη παρουσίαση εξάγεται, η κατανάλωση μνήμης 
		// παραμένει χαμηλή καθ' όλη τη διάρκεια ζωής του αντικειμένου pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Μνήμη και Μεγάλες Παρουσιάσεις**

Συνήθως, για τη φόρτωση μιας μεγάλης παρουσίασης, οι υπολογιστές απαιτούν πολύ προσωρινή μνήμη. Όλο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) σταματά να χρησιμοποιείται.

Σκεφτείτε μια μεγάλη παρουσίαση PowerPoint (large.pptx) που περιέχει ένα αρχείο βίντεο 1,5 GB. Η τυπική μέθοδος φόρτωσης της παρουσίασης περιγράφεται σε αυτόν τον κώδικα C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Αλλά αυτή η μέθοδος καταναλώνει περίπου 1,6 GB προσωρινής μνήμης.

### **Φόρτωση Μεγάλης Παρουσίασης ως BLOB**

Μέσω της διαδικασίας που περιλαμβάνει BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας ελάχιστη μνήμη. Αυτός ο κώδικας C# περιγράφει την υλοποίηση όπου η διαδικασία BLOB χρησιμοποιείται για τη φόρτωση ενός μεγάλου αρχείου παρουσίασης (large.pptx):

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Αλλαγή του Φακέλου για Προσωρινά Αρχεία**

Όταν χρησιμοποιείται η διαδικασία BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στον προεπιλεγμένο φάκελο για προσωρινά αρχεία. Εάν θέλετε τα προσωρινά αρχεία να διατηρούνται σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας `TempFilesRootPath`:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείτε το `TempFilesRootPath`, το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση των προσωρινών αρχείων. Πρέπει να δημιουργήσετε τον φάκελο χειροκίνητα. 
{{% /alert %}}

### **Αποδέσμευση Αντικειμένων Παρουσίασης για Απελευθέρωση Μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι το [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) instance αποδεσμεύεται σωστά ώστε η μνήμη που κατείχε να απελευθερωθεί. Ο συνιστώμενος τρόπος είναι η χρήση δήλωσης `using` όπως φαίνεται στα παραπάνω παραδείγματα· αυτόματα αποδεσμεύει την παρουσίαση και ελευθερώνει ανεξέλεγκτους πόρους όταν η ενότητα τελειώνει.

Αν δημιουργήσετε μια παρουσίαση χωρίς μπλοκ `using`, καλέστε ρητά το `Dispose()` μετά την ολοκλήρωση της χρήσης της.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...επεξεργασία της παρουσίασης...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Ρητή αποδέσμευση πόρων.
presentation.Dispose();
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides λαμβάνονται ως BLOB και ελέγχονται από τις επιλογές BLOB;**

Μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχοι και βίντεο αντιμετωπίζονται ως BLOB. Όλο το αρχείο παρουσίασης επίσης εμπλέκεται σε διαχείριση BLOB όταν φορτώνεται ή αποθηκεύεται. Αυτά τα αντικείμενα διέπονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και να εκμεταλλεύεστε προσωρινά αρχεία όταν χρειάζεται.

**Πού ρυθμίζω τους κανόνες διαχείρισης BLOB κατά τη φόρτωση μιας παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/) μαζί με το [BlobManagementOptions](https://reference.aspose.com/slides/el/net/aspose.slides/blobmanagementoptions/). Εκεί ορίζετε το όριο μνήμης για BLOB, επιτρέπετε ή απαγορεύετε τα προσωρινά αρχεία, επιλέγετε τη ρίζα του μονοπατιού για τα προσωρινά αρχεία και καθορίζετε τη συμπεριφορά κλειδώματος της πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση και πώς ισορροπώ την ταχύτητα με τη μνήμη;**

Ναι. Η διατήρηση του BLOB στη μνήμη μεγιστοποιεί την ταχύτητα αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταφέρει περισσότερο έργο στα προσωρινά αρχεία, μειώνοντας τη RAM με κόστος πρόσθετης I/O. Ρυθμίστε το όριο [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/el/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) για να βρείτε την κατάλληλη ισορροπία για το φορτίο εργασίας και το περιβάλλον σας.

**Βοηθούν οι επιλογές BLOB όταν ανοίγω εξαιρετικά μεγάλες παρουσιάσεις (π.χ. σε γιγαμπάιτς);**

Ναι. Τα [BlobManagementOptions](https://reference.aspose.com/slides/el/net/aspose.slides/blobmanagementoptions/) έχουν σχεδιαστεί για τέτοια σενάρια: η ενεργοποίηση των προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά το μέγιστο φορτίο RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων παρουσιάσεων.

**Μπορώ να χρησιμοποιήσω πολιτικές BLOB όταν φορτώνω από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιοι κανόνες εφαρμόζονται σε ροές: η παρουσίαση μπορεί να κατέχει και να κλειδώνει τη ροή εισόδου (ανάλογα με το επιλεγμένο mode κλειδώματος) και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπεται, διατηρώντας την κατανάλωση μνήμης προβλέψιμη κατά τη διάρκεια της επεξεργασίας.