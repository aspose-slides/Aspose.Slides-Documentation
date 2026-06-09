---
title: Διαχείριση BLOB Παρουσιάσεων σε PHP για Αποδοτική Χρήση Μνήμης
linktitle: Διαχείριση BLOB
type: docs
weight: 10
url: /el/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τα δεδομένα BLOB στο Aspose.Slides για PHP μέσω Java για να βελτιστοποιήσετε τις λειτουργίες αρχείων PowerPoint και OpenDocument για αποδοτικό χειρισμό παρουσιάσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει χειρισμό βάσει BLOB για μεγάλα δυαδικά δεδομένα στις παρουσιάσεις, ώστε να βοηθά στη μείωση της κατανάλωσης μνήμης κατά την εργασία με μεγάλες εικόνες, ήχο, βίντεο και αρχεία παρουσίασης.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε επεξεργασία βάσει BLOB για να προσθέσετε μεγάλα μέσα σε μια παρουσίαση, να εξαγάγετε μεγάλα μέσα από μια παρουσίαση και να φορτώσετε μεγάλες παρουσιάσεις πιο αποδοτικά. Επίσης εξηγεί πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά την επεξεργασία και πώς να αλλάξετε το φάκελο που χρησιμοποιείται για την αποθήκευσή τους.

## **Σχετικά με το BLOB**

**BLOB** (**Binary Large Object**) είναι συνήθως ένα μεγάλο αντικείμενο (φωτογραφία, παρουσίαση, έγγραφο ή μέσον) αποθηκευμένο σε δυαδικές μορφές.

Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να χρησιμοποιείτε BLOBs για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν εμπλέκονται μεγάλα αρχεία.

{{% alert title="Info" color="info" %}}
Για να παρακάμψετε ορισμένους περιορισμούς κατά την αλληλεπίδραση με ροές, το Aspose.Slides μπορεί να αντιγράψει το περιεχόμενο της ροής. Η φόρτωση μιας μεγάλης παρουσίασης μέσω της ροής της θα οδηγήσει σε αντιγραφή του περιεχομένου της παρουσίασης και θα προκαλέσει αργή φόρτωση. Συνεπώς, όταν προορίζεστε να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε έντονα να χρησιμοποιήσετε τη διαδρομή του αρχείου παρουσίασης και όχι τη ροή της.
{{% /alert %}}

## **Χρησιμοποιήστε BLOB για τη Μείωση της Κατανάλωσης Μνήμης**

### **Προσθήκη Μεγάλου Αρχείου μέσω BLOB σε Παρουσίαση**

[Aspose.Slides](/slides/el/php-java/) για Java σας επιτρέπει να προσθέσετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα μεγάλο αρχείο βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs για να μειώσετε την κατανάλωση μνήμης.

Αυτό το παράδειγμα Java δείχνει πώς να προσθέσετε ένα μεγάλο αρχείο βίντεο μέσω της διαδικασίας BLOB σε μια παρουσίαση:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί το βίντεο
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Ας προσθέσουμε το βίντεο στην παρουσίαση - επιλέξαμε τη συμπεριφορά KeepLocked επειδή
      # δεν σκοπεύουμε να προσπελάσουμε το αρχείο "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Αποθηκεύει την παρουσίαση. Καθώς παράγεται μια μεγάλη παρουσίαση, η κατανάλωση μνήμης
      # παραμένει χαμηλή καθ' όλη τη διάρκεια ζωής του αντικειμένου pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Εξαγωγή Μεγάλου Αρχείου μέσω BLOB από Παρουσίαση**

Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να εξάγετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα αρχείο ήχου ή βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξάγετε ένα μεγάλο αρχείο μέσου από μια παρουσίαση χωρίς το αρχείο να φορτώνεται στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BBlob, διατηρείτε τη χρήση μνήμης χαμηλή.

Αυτός ο κώδικας δείχνει τη περιγραφείσα λειτουργία:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Κλειδώνει το αρχείο πηγής και ΔΕΝ το φορτώνει στη μνήμη
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Δημιουργεί την παρουσίαση, κλειδώνει το αρχείο "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Ας αποθηκεύσουμε κάθε βίντεο σε αρχείο. Για να αποτρέψουμε τη μεγάλη χρήση μνήμης, χρειαζόμαστε έναν buffer που θα χρησιμοποιηθεί
    # για τη μεταφορά των δεδομένων από τη ροή βίντεο της παρουσίασης σε ροή για ένα νεοδημιουργημένο αρχείο βίντεο.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Διατρέχει τα βίντεο
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Ανοίγει τη ροή βίντεο της παρουσίασης. Παρακαλώ, σημειώστε ότι προορίστικα απέφυγαμε την πρόσβαση σε ιδιότητες
      # όπως video.BinaryData - επειδή αυτή η ιδιότητα επιστρέφει έναν πίνακα byte που περιέχει ολόκληρο το βίντεο, το οποίο
      # φορτώνει bytes στη μνήμη. Χρησιμοποιούμε το video.GetStream, το οποίο επιστρέφει Stream - και ΔΕΝ
      # απαιτεί να φορτώσουμε ολόκληρο το βίντεο στη μνήμη.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Η κατανάλωση μνήμης θα παραμείνει χαμηλή ανεξάρτητα από το μέγεθος του βίντεο ή της παρουσίασης.
    }
    # Αν χρειάζεται, μπορείτε να εφαρμόσετε τα ίδια βήματα για αρχεία ήχου.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Προσθήκη Εικόνας ως BLOB σε Παρουσίαση**

Με τις μεθόδους της κλάσης [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/), μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να αντιμετωπιστεί ως BLOB.

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε μια μεγάλη εικόνα μέσω της διαδικασίας BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί η εικόνα.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Ας προσθέσουμε την εικόνα στην παρουσίαση - επιλέγουμε τη συμπεριφορά KeepLocked επειδή
      # ΔΕΝ σκοπεύουμε να προσπελάσουμε το αρχείο "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Αποθηκεύει την παρουσίαση. Καθώς δημιουργείται μια μεγάλη παρουσίαση, η κατανάλωση μνήμης
      # παραμένει χαμηλή καθ' όλη τη διάρκεια ζωής του αντικειμένου pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Μνήμη και Μεγάλες Παρουσιάσεις**

Κανονικά, για να φορτώσετε μια μεγάλη παρουσίαση, οι υπολογιστές απαιτούν πολύ προσωρινή μνήμη. Όλο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) παύει να χρησιμοποιείται.

Σκεφτείτε μια μεγάλη παρουσίαση PowerPoint (large.pptx) που περιέχει ένα βίντεο 1,5 GB. Η τυπική μέθοδος φόρτωσης της παρουσίασης περιγράφεται σε αυτόν τον κώδικα PHP:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Αλλά αυτή η μέθοδος καταναλώνει περίπου 1,6 GB προσωρινής μνήμης.

### **Φόρτωση Μεγάλης Παρουσίασης ως BLOB**

Μέσω της διαδικασίας που περιλαμβάνει BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας ελάχιστη μνήμη. Αυτός ο κώδικας PHP περιγράφει την υλοποίηση όπου η διαδικασία BLOB χρησιμοποιείται για τη φόρτωση ενός μεγάλου αρχείου παρουσίασης (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Αλλαγή Φακέλου για Προσωρινά Αρχεία**

Όταν χρησιμοποιείται η διαδικασία BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στον προεπιλεγμένο φάκελο για προσωρινά αρχεία. Εάν θέλετε τα προσωρινά αρχεία να αποθηκεύονται σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείτε το `setTempFilesRootPath`, το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση των προσωρινών αρχείων. Πρέπει να δημιουργήσετε το φάκελο χειροκίνητα.
{{% /alert %}}

### **Αποδέσμευση Αντικειμένων Παρουσίασης για Απελευθέρωση Μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι η παρουσίαση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) έχει αποδεσμευτεί σωστά ώστε η μνήμη που κατείχε να ελευθερωθεί. Καλέστε `dispose()` μετά την ολοκλήρωση της χρήσης της παρουσίασης για να ελευθερώσετε τους μη διαχειριζόμενους πόρους.

```php
$presentation = new Presentation("large.pptx");

# ...επεξεργασία της παρουσίασης...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Απελευθερώστε ρητά τους πόρους.
$presentation->dispose();
```

## **Συχνές Ερωτήσεις**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides θεωρούνται BLOB και ελέγχονται από τις επιλογές BBlob;**

Μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχος και βίντεο θεωρούνται BLOB. Ολόκληρο το αρχείο παρουσίασης επίσης εμπλέκεται σε χειρισμό BLOB όταν φορτώνεται ή αποθηκεύεται. Αυτά τα αντικείμενα διέπονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και να μεταφέρετε σε προσωρινά αρχεία όταν είναι απαραίτητο.

**Πού μπορώ να διαμορφώσω τους κανόνες χειρισμού BLOB κατά τη φόρτωση της παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/) μαζί με το [BlobManagementOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/blobmanagementoptions/). Εκεί καθορίζετε το όριο μνήμης για BLOB, επιτρέπετε ή απαγορεύετε τα προσωρινά αρχεία, επιλέγετε τη ρίζα διαδρομή για τα προσωρινά αρχεία και ορίζετε τη συμπεριφορά κλειδώματος πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση και πώς εξισορροπώ την ταχύτητα με τη μνήμη;**

Ναι. Η διατήρηση του BLOB στη μνήμη μεγιστοποιεί την ταχύτητα, αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταφέρει περισσότερη εργασία σε προσωρινά αρχεία, μειώνοντας τη RAM με το κόστος πρόσθετου I/O. Χρησιμοποιήστε τη μέθοδο [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/el/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) για να πετύχετε τη σωστή ισορροπία για το φορτίο εργασίας και το περιβάλλον σας.

**Βοηθούν οι επιλογές BLOB κατά το άνοιγμα εξαιρετικά μεγάλων παρουσιάσεων (π.χ. σε γιγαμπάιτ);**

Ναι. Οι [BlobManagementOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/blobmanagementoptions/) έχουν σχεδιαστεί για τέτοιες περιπτώσεις: η ενεργοποίηση των προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά τη μέγιστη χρήση RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων παρουσιάσεων.

**Μπορώ να χρησιμοποιήσω πολιτικές BLOB όταν φορτώνω από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιες κανόνες ισχύουν για τις ροές: η παρουσίαση μπορεί να κατέχει και να κλειδώνει τη ροή εισόδου (ανάλογα με το επιλεγμένο mode κλειδώματος), και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπεται, διατηρώντας την κατανάλωση μνήμης προβλέψιμη κατά την επεξεργασία.