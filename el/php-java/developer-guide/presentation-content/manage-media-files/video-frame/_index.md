---
title: Διαχείριση Καρέ Βίντεο σε Παρουσιάσεις με PHP
linktitle: Καρέ Βίντεο
type: docs
weight: 10
url: /el/php-java/video-frame/
keywords:
- προσθήκη βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- καρέ βίντεο
- διαδικτυακή πηγή
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά καρέ βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Γρήγορος οδηγός βήμα προς βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα εμπλοκής με το κοινό σας.  

Το PowerPoint σας επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια μιας παρουσίασης με δύο τρόπους:

* Προσθήκη ή ενσωμάτωση τοπικού βίντεο (αποθηκευμένου στον υπολογιστή σας)
* Προσθήκη διαδικτυακού βίντεο (από διαδικτυακή πηγή όπως το YouTube).

Για να μπορείτε να προσθέσετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει την κλάση [Video](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/) , την κλάση [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένων Καρέ Βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα καρέ βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.  

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) για να δημιουργήσετε ένα καρέ για το βίντεο. 
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε ένα βίντεο αποθηκευμένο τοπικά σε μια παρουσίαση:

```php
  # Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Φορτώνει το βίντεο
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Λαμβάνει την πρώτη διαφάνεια και προσθέτει ένα καρέ βίντεο
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

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας τη διαδρομή του αρχείου απευθείας στη μέθοδο [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addvideoframe/) :

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

## **Δημιουργία Καρέ Βίντεο με Βίντεο από Διαδικτυακές Πηγές**

Το Microsoft [PowerPoint 2013 και νεότερα](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο στο διαδίκτυο (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου.  

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). 
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/) και περάστε το σύνδεσμο προς το βίντεο. 
1. Ορίστε μια μικρογραφία για το καρέ του βίντεο. 
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε ένα βίντεο από το διαδίκτυο σε μια διαφάνεια σε παρουσίαση PowerPoint:

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

## **Κοπή Καρέ Βίντεο**

Το Aspose.Slides σας επιτρέπει να ελέγχετε ποιο τμήμα ενός βίντεο αναπαράγεται ορίζοντας τις τιμές trim‑from‑start και trim‑from‑end μέσω των μεθόδων [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#setTrimFromStart) και [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#setTrimFromEnd). Και οι δύο τιμές καθορίζονται σε χιλιοστά του δευτερολέπτου και ορίζουν πόσο χρόνο παραλείπεται από την αρχή και το τέλος του βίντεο, αντίστοιχα. Αυτές οι ρυθμίσεις αλλάζουν τις ρυθμίσεις αναπαραγωγής του βίντεο στην παρουσίαση· δεν κόβουν ή τροποποιούν το ενσωματωμένο δυαδικό δεδομένο του βίντεο.

**Ορισμός Ρυθμίσεων Κοπής**

Για να δημιουργήσετε ένα καρέ βίντεο και να ορίσετε τις ρυθμίσεις κοπής του:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/) στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) σε μια διαφάνεια.
1. Ορίστε τις τιμές trim‑from‑start και trim‑from‑end μέσω των [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#setTrimFromStart) και [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#setTrimFromEnd).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα κώδικα παραλείπει τις πρώτες 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο ενός ενσωματωμένου βίντεο κατά την αναπαραγωγή:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Ανάγνωση Ρυθμίσεων Κοπής**

Για να ελέγξετε τις υπάρχουσες ρυθμίσεις κοπής, φορτώστε μια παρουσίαση, βρείτε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) ανάμεσα στα σχήματα της πρώτης διαφάνειας και διαβάστε τις τιμές μέσω των [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getTrimFromStart) και [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getTrimFromEnd).

Το παρακάτω παράδειγμα κώδικα βρίσκει το πρώτο καρέ βίντεο στην πρώτη διαφάνεια και αναφέρει τις ρυθμίσεις κοπής του σε χιλιοστά του δευτερολέπτου:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για καρέ βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι εκθέσιμα μέσω της μεθόδου [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Προσθήκη Υπότιτλων σε Καρέ Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα καρέ βίντεο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Προσθέστε ένα βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) σε μια διαφάνεια.
1. Χρησιμοποιήστε τη συλλογή [CaptionsCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/) που επιστρέφεται από το [getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getCaptionTracks) για να προσθέσετε ένα στίχο υποτιτλισμού WebVTT.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω δείχνει πώς να προσθέσετε υπότιτλους σε ένα καρέ βίντεο:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Προσθέτει ένα νέο κομμάτι υποτίτλων από αρχείο WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από ένα ρεύμα.

**Εξαγωγή Υπότιτλων από Καρέ Βίντεο**

Για να εξάγετε υπότιτλους από ένα καρέ βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Βρείτε το επιθυμητό αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/).
1. Επανάληψη μέσω της συλλογής [getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Αποθηκεύστε κάθε στίχο υποτιτλισμού σε αρχείο `.vtt`.

Το παρακάτω δείχνει πώς να εξάγετε υπότιτλους από ένα καρέ βίντεο:

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
                // Αποθηκεύει το κομμάτι υποτίτλων σε αρχείο WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/el/php-java/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF‑8.

**Αφαίρεση Υπότιτλων από Καρέ Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα καρέ βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Αποκτήστε το επιθυμητό αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/).
1. Αφαιρέστε τους στίχους υποτιτλισμού από τη συλλογή [getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα καρέ βίντεο:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // τύπος: VideoFrame

    // Αφαιρεί όλους τους υπότιτλους από το καρέ βίντεο.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Εάν χρειάζεται να αφαιρέσετε μόνο έναν στίχο υποτιτλισμού, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#removeAt) αντί για την [clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#clear).

## **Εξαγωγή Βίντεο από Διαφάνειες**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο που είναι ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο.
2. Επανάληψη σε όλα τα αντικείμενα [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/).
3. Επανάληψη σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/).
4. Αποθηκεύστε το βίντεο στο δίσκο.

Αυτός ο κώδικας PHP δείχνει πώς να εξάγετε το βίντεο από μια διαφάνεια παρουσίασης:

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
          # Λαμβάνει την επέκταση του αρχείου
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

**Ποιοι παράμετροι αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [playback mode](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/setplaymode/) (αυτόματη ή με κλικ) και την [looping](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/setplayloopmode/). Αυτές οι επιλογές διατίθενται μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [video content](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/setembeddedvideo/) μέσα στο καρέ διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι ένα κοινό σενάριο για ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [content type](https://reference.aspose.com/slides/el/php-java/aspose.slides/video/getcontenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στο δίσκο.