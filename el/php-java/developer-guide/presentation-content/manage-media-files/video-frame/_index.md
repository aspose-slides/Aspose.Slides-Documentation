---
title: Διαχείριση πλαισίων βίντεο σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Πλαίσιο βίντεο
type: docs
weight: 10
url: /el/php-java/video-frame/
keywords:
- προσθήκη βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- πλαίσιο βίντεο
- διαδικτυακή πηγή
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για PHP μέσω Java. Γρήγορος οδηγός βήμα προς βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα δέσμευσης με το κοινό σας. 

PowerPoint σας επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα διαδικτυακό βίντεο (από πηγή web όπως το YouTube).

Για να μπορείτε να προσθέσετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει την κλάση [Video](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/) , την κλάση [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένων Πλαισίων Βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνεια αποθηκεύεται τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση.
4. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε ένα τοπικά αποθηκευμένο βίντεο σε μια παρουσίαση:

```php
  # Δημιουργεί μια παρουσία της κλάσης Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Φορτώνει το βίντεο
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Λαμβάνει την πρώτη διαφάνεια και προσθέτει ένα πλαίσιο βίντεο
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας άμεσα τη διαδρομή του αρχείου στη μέθοδο [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addvideoframe/) :

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Δημιουργία Πλαισίων Βίντεο με Βίντεο από Πηγές Ιστού**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube σε παρουσιάσεις. Αν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο online (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του συνδέσμου του.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/) και περάστε τον σύνδεσμο προς το βίντεο.
4. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο. 
5. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε ένα βίντεο από το web σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```php
  # Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Διαχείριση Υπότιτλων Βίντεο**

Aspose.Slides σας επιτρέπει να διαχειριστείτε κλειστά υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι προσβάσιμοι μέσω της μεθόδου [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Προσθέστε ένα βίντεο στην παρουσίαση.
3. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) σε μια διαφάνεια.
4. Χρησιμοποιήστε τη συλλογή [CaptionsCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/) που επιστρέφεται από [getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getCaptionTracks) για να προσθέσετε ένα WebVTT track υπότιτλου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Προσθέτει ένα νέο track υποτίτλων από αρχείο WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/) παρέχει επίσης υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από ροή.

**Ανάκτηση Υπότιτλων από Πλαίσιο Βίντεο**

Για να ανακτήσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Βρείτε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) .
3. Διέλθετε τη συλλογή [getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getCaptionTracks) .
4. Αποθηκεύστε κάθε track υπότιτλου σε αρχείο `.vtt` .

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Αποθηκεύει το track υποτίτλων σε αρχείο WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/el/php-java/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Λάβετε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) .
3. Αφαιρέστε τα tracks υπότιτλων από τη συλλογή [getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getCaptionTracks) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // τύπος: VideoFrame

    // Αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αν χρειάζεται να αφαιρέσετε μόνο ένα track υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#removeAt) αντί για [clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#clear).

## **Ανάκτηση Βίντεο από Διαφάνειες**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να ανακτήσετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο.
2. Διέλθετε όλα τα αντικείμενα [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/) .
3. Διέλθετε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) .
4. Αποθηκεύστε το βίντεο στο δίσκο.

```php
  # Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Παίρνει την επέκταση αρχείου
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/setplaymode/) (αυτόματη ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/setplayloopmode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη ενός βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να αντικαταστήσετε το [video content](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/setembeddedvideo/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτή είναι μια συνηθισμένη περίπτωση για ενημέρωση πολυμέσων σε υπάρχον σχήμα.

**Μπορεί να καθοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [content type](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/getcontenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στο δίσκο.