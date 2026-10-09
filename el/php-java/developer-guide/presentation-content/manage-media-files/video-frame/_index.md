---
title: Διαχείριση Πλαισίων Βίντεο σε Παρουσιάσεις με PHP
linktitle: Πλαίσιο Βίντεο
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
- πηγή ιστού
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για PHP μέσω Java. Γρήγορος οδηγός βήμα προς βήμα."
---
## **Εισαγωγή**

Τα βίντεο μπορούν να βοηθήσουν στην εξήγηση ιδεών και στην εμπλοκή του κοινού. Το Aspose.Slides για PHP μέσω Java σάς επιτρέπει να προσθέτετε πλαίσια βίντεο στις διαφάνειες, να ρυθμίζετε τις ρυθμίσεις αναπαραγωγής, να διαχειρίζεστε υπότιτλους και να εξάγετε ενσωματωμένα δεδομένα βίντεο.

Το PowerPoint υποστηρίζει τοπικά βίντεο και συνδέσμους σε βίντεο στο διαδίκτυο, όπως βίντεο του YouTube.

Για την αναπαράσταση δεδομένων βίντεο και πλαισίων βίντεο, το Aspose.Slides παρέχει την κλάση [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) την κλάση [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνεια είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης και αποθηκεύει το αποτέλεσμα. Οι συντεταγμένες και οι διαστάσεις του πλαισίου είναι σε μονάδες point. Η ροή παραμένει ανοιχτή μέχρι να ολοκληρωθεί η αποθήκευση επειδή η μέθοδος [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) την κρατά κλειδωμένη όσο η παρουσίαση τη χρησιμοποιεί.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Μπορείτε επίσης να περάσετε τη διαδρομή ενός τοπικού βίντεο απευθείας στη μέθοδο [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Αυτό το παράδειγμα ενσωματώνει το βίντεο στην πρώτη διαφάνεια μιας νέας παρουσίασης. Το βίντεο πρέπει να παραμένει προσβάσιμο μέχρι να αποθηκευτεί η παρουσίαση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Πηγή στο Διαδίκτυο**

Το Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζει βίντεο στο διαδίκτυο στις παρουσιάσεις. Μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο που συνδέεται με ένα βίντεο στο διαδίκτυο, όπως ένα βίντεο του YouTube.

Αυτό το παράδειγμα προσθέτει ένα σύνδεσμο βίντεο YouTube και μικρογραφία στην πρώτη διαφάνεια. Αντικαταστήστε το αναγνωριστικό του βίντεο για να χρησιμοποιήσετε άλλο βίντεο. Η μέθοδος [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) ζητά αυτόματη αναπαραγωγή. Η λήψη της μικρογραφίας και η αναπαραγωγή του βίντεο απαιτούν πρόσβαση στο διαδίκτυο. Ο προβολέας της παρουσίασης πρέπει επίσης να υποστηρίζει αναπαραγωγή βίντεο στο διαδίκτυο.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αναπαραγωγή Βίντεο σε Λειτουργία Πλήρους Οθόνης**

Σε παρουσίαση εκπαίδευσης, μπορείτε να αναπαράγετε μια επίδειξη λογισμικού σε λειτουργία πλήρους οθόνης ώστε το κοινό να βλέπει τις λεπτομέρειες. Καλέστε τη μέθοδο [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) με `true` για να ενεργοποιήσετε αυτή τη συμπεριφορά κατά την αναπαραγωγή.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την αναπαραγωγή σε πλήρη οθόνη. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η αναπαραγωγή σε πλήρη οθόνη ελέγχει τον τρόπο προβολής του βίντεο. Ανεξάρτητα, η μέθοδος [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) ελέγχει αν το βίντεο ξεκινά αυτόματα ή με κλικ, και η [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) ελέγχει αν επαναλαμβάνεται. Για να επιλέξετε τη συμπεριφορά εκκίνησης, ορίστε τη λειτουργία αναπαραγωγής σε [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Το παράδειγμα διατηρεί τις υπάρχουσες ρυθμίσεις εκκίνησης και λούπ.

## **Επαναφορά Βίντεο στην Αρχή Μετά την Αναπαραγωγή**

Σε παρουσίαση εκπαίδευσης, η επιστροφή ενός βίντεο επίδειξης στην αρχή το καθιστά έτοιμο για την εκ νέου αναπαραγωγή από τον παρουσιαστή. Καλέστε τη μέθοδο [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) με `true` για να επιστρέψετε το βίντεο στην αρχή μετά το τέλος της αναπαραγωγής.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, εντοπίζει το πρώτο [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την επαναφορά. Απενεργοποιεί την επανάληψη ώστε η αναπαραγωγή να μπορεί να ολοκληρωθεί και ορίζει την εκκίνηση της αναπαραγωγής με κλικ. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η επαναφορά φέρνει το βίντεο στην αρχή του χωρίς να το ξαναξεκινήσει. Αντίθετα, η κλήση της [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) με `true` επαναλαμβάνει την αναπαραγωγή αυτόματα. Κρατήστε την επανάληψη απενεργοποιημένη όταν θέλετε το βίντεο να ολοκληρωθεί και να παραμείνει έτοιμο για επανααναπαραγωγή. Η [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) ελέγχει ανεξάρτητα την αυτόματη ή την εκκίνηση με κλικ· αυτό το παράδειγμα χρησιμοποιεί το [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) ώστε ο παρουσιαστής να ελέγχει πότε ξεκινά η αναπαραγωγή. Ορίστε τη λειτουργία αναπαραγωγής μετά τη ρύθμιση της επανάληψης, όπως φαίνεται στο παράδειγμα. Η επαναφορά λειτουργεί ανεξάρτητα από τη [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Περικοπή Πλαισίου Βίντεο**

Χρησιμοποιήστε τις μεθόδους [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) και [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) για να παραλείψετε μέρος της αρχής ή του τέλους ενός βίντεο κατά την αναπαραγωγή. Και οι δύο τιμές δίνονται σε χιλιοστά του δευτερολέπτου. Η περικοπή αλλάζει τις ρυθμίσεις αναπαραγωγής χωρίς να τροποποιεί τα ενσωματωμένα δεδομένα βίντεο.

**Ορισμός Ρυθμίσεων Περικοπής**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο κατά την αναπαραγωγή. Χρησιμοποιήστε ένα βίντεο μεγαλύτερο από 3,5 δευτερόλεπτα ώστε να παραμείνει ένα αναγγιζόμενο τμήμα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Ανάγνωση Ρυθμίσεων Περικοπής**

Αυτό το παράδειγμα εκτυπώνει τις τιμές περικοπής του πρώτου πλαισίου βίντεο στην πρώτη διαφάνεια σε χιλιοστά του δευτερολέπτου. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια. Αν η διαφάνεια δεν έχει πλαίσιο βίντεο, δεν εκτυπώνεται τίποτα. Το προηγούμενο παράδειγμα παράγει τιμές 2500 και 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε κλειστά υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της μεθόδου [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και προσθέτει ένα WebVTT αρχείο υποτίτλων με ετικέτα English. Τα χρονικά σημεία των υποτίτλων πρέπει να ταιριάζουν με το βίντεο. Η αποθηκευμένη παρουσίαση περιλαμβάνει τόσο το βίντεο όσο και τους υπότιτλους του.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) παρέχει επίσης μια υπερφόρτωση που επιτρέπει την προσθήκη υποτίτλων από ροή.

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Αυτό το παράδειγμα αποθηκεύει όλα τα κομμάτια υποτίτλων από τα πλαίσια βίντεο στην πρώτη διαφάνεια ως ξεχωριστά αρχεία WebVTT. Αριθμοί σε σειρά κρατούν τα αρχεία εξόδου διακριτά. Η κονσόλα αναφέρει τον αριθμό των εξαγόμενων κομματιών. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF‑8.

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Αυτό το παράδειγμα αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο στην πρώτη θέση σχήματος στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι ένα πλαίσιο βίντεο.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) αντί για τη μέθοδο [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σάς επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

Αυτό το παράδειγμα εξάγει τα ενσωματωμένα βίντεο από κάθε διαφάνεια σε ξεχωριστά αριθμημένα δυαδικά αρχεία. Τα συνδεδεμένα βίντεο παραλείπονται επειδή δεν έχουν ενσωματωμένα δεδομένα. Η κονσόλα εκτυπώνει τον τύπο MIME του κάθε βίντεο και το συνολικό πλήθος. Η έξοδος χρησιμοποιεί τη γενική επέκταση `.bin`; αλλάξτε την ώστε να ταιριάζει με τον αναφερόμενο τύπο μέσου όταν χρειάζεται.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα πλαίσιο βίντεο;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (αυτόματη ή με κλικ) και την [επαναλήψιμότητα](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Αυτές οι επιλογές διατίθενται μέσω των μεθόδων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, έτσι το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν συνδέεστε σε ένα βίντεο στο διαδίκτυο και προσθέτετε μια μικρογραφία, η παρουσίαση αποθηκεύει τον σύνδεσμο και την εικόνα προεπισκόπησης αντί για τα δεδομένα του βίντεο, οπότε η αύξηση του μεγέθους είναι συνήθως μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον πλαίσιο βίντεο χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι μια κοινή περίπτωση ενημέρωσης πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) τον οποίο μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα κατά την αποθήκευσή του σε δίσκο.