---
title: Διαχείριση καρέ βίντεο σε παρουσιάσεις με Java
linktitle: Καρέ βίντεο
type: docs
weight: 10
url: /el/java/video-frame/
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
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά καρέ βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για Java. Γρήγορος οδηγός βήμα-προς-βήμα."
---
## **Εισαγωγή**

Τα βίντεο μπορούν να βοηθήσουν στην επεξήγηση ιδεών και στην προσέλκυση του κοινού. Το Aspose.Slides for Java σάς επιτρέπει να προσθέτετε καρέ βίντεο στις διαφάνειες, να προσαρμόζετε τις ρυθμίσεις αναπαραγωγής, να διαχειρίζεστε υπότιτλους και να εξάγετε τα ενσωματωμένα δεδομένα βίντεο.

Το PowerPoint υποστηρίζει τοπικά βίντεο και συνδέσμους σε διαδικτυακά βίντεο, όπως βίντεο YouTube.

Για να αναπαραστήσει δεδομένα βίντεο και καρέ βίντεο, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία ενσωματωμένου καρέ βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα καρέ βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης και αποθηκεύει το αποτέλεσμα. Οι συντεταγμένες και οι διαστάσεις του καρέ είναι σε μονάδες point. Η ροή παραμένει ανοιχτή μέχρι το τέλος της αποθήκευσης επειδή η [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) το κρατά κλειδωμένο ενώ η παρουσίαση το χρησιμοποιεί.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να περάσετε τη διαδρομή τοπικού βίντεο απευθείας στη μέθοδο [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Αυτό το παράδειγμα ενσωματώνει το βίντεο στην πρώτη διαφάνεια μιας νέας παρουσίασης. Το βίντεο πρέπει να παραμένει προσβάσιμο μέχρι η παρουσίαση αποθηκευτεί.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Δημιουργία καρέ βίντεο με βίντεο από διαδικτυακή πηγή**

Το Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζει διαδικτυακά βίντεο στις παρουσιάσεις. Μπορείτε να δημιουργήσετε ένα καρέ βίντεο που συνδέεται με ένα διαδικτυακό βίντεο, όπως ένα βίντεο YouTube.

Αυτό το παράδειγμα προσθέτει έναν σύνδεσμο βίντεο YouTube και μικρογραφία στην πρώτη διαφάνεια. Αντικαταστήστε το αναγνωριστικό βίντεο για να χρησιμοποιήσετε άλλο βίντεο. Η μέθοδος [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) ζητά την αυτόματη αναπαραγωγή. Η λήψη της μικρογραφίας και η αναπαραγωγή του βίντεο απαιτούν πρόσβαση στο διαδίκτυο. Ο προβολέας παρουσίασης πρέπει επίσης να υποστηρίζει την αναπαραγωγή διαδικτυακών βίντεο.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αναπαραγωγή βίντεο σε λειτουργία πλήρους οθής**

Σε μια εκπαιδευτική παρουσίαση, μπορείτε να αναπαράγετε μια επίδειξη λογισμικού σε πλήρη οθήνη, ώστε το κοινό να βλέπει τις λεπτομέρειες. Καλέστε τη [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) με `true` για να ενεργοποιήσετε αυτή τη συμπεριφορά κατά τη διάρκεια της αναπαραγωγής.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, εντοπίζει το πρώτο [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την αναπαραγωγή σε πλήρη οθήνη. Η παρουσίαση εισόδου πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον καρέ βίντεο στην πρώτη διαφάνεια.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αναπαραγωγή σε πλήρη οθήνη ελέγχει πώς εμφανίζεται το βίντεο. Ξεχωριστά, η [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) ελέγχει αν ξεκινά αυτόματα ή με κλικ, και η [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ελέγχει αν επαναλαμβάνεται. Για να επιλέξετε τη συμπεριφορά εκκίνησης, ορίστε τη λειτουργία αναπαραγωγής στο [VideoPlayModePreset.Auto ή VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Το παράδειγμα διατηρεί τις υπάρχουσες ρυθμίσεις εκκίνησης και βρόχου.

## **Επιστροφή του βίντεο στην αρχή μετά την αναπαραγωγή**

Σε μια εκπαιδευτική παρουσίαση, η επιστροφή ενός βίντεο επίδειξης στην αρχή το καθιστά έτοιμο για το ξανααναπαραγωγή από τον παρουσιαστή. Καλέστε τη [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) με `true` για να επιστρέψετε το βίντεο στην αρχή μετά το τέλος της αναπαραγωγής.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, εντοπίζει το πρώτο [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την επιστροφή. Απενεργοποιεί την επανάληψη ώστε η αναπαραγωγή να ολοκληρωθεί και ορίζει την αναπαραγωγή να ξεκινά με κλικ. Η παρουσίαση εισόδου πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον καρέ βίντεο στην πρώτη διαφάνεια.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η επιστροφή φέρνει το βίντεο στην αρχή χωρίς να το ξεκινήσει ξανά. Αντίθετα, η κλήση της [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) με `true` επαναλαμβάνει την αναπαραγωγή αυτόματα. Κρατήστε την επανάληψη απενεργοποιημένη όταν θέλετε το βίντεο να ολοκληρωθεί και να παραμείνει έτοιμο για επανααναγνώριση. Η [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) ελέγχει ανεξάρτητα την αυτόματη ή με κλικ εκκίνηση· αυτό το παράδειγμα χρησιμοποιεί το [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) ώστε ο παρουσιαστής να ελέγχει πότε ξεκινά η αναπαραγωγή. Ορίστε τη λειτουργία αναπαραγωγής μετά την ρύθμιση του βρόχου, όπως φαίνεται στο παράδειγμα. Η επιστροφή λειτουργεί ανεξάρτητα από τη [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Περικοπή καρέ βίντεο**

Χρησιμοποιήστε τις μεθόδους [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) και [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) για να παραλείψετε μέρος της αρχής ή του τέλους ενός βίντεο κατά την αναπαραγωγή. Και οι δύο τιμές είναι σε χιλιοστά του δευτερολέπτου. Η περικοπή αλλάζει τις ρυθμίσεις αναπαραγωγής χωρίς να τροποποιεί τα ενσωματωμένα δεδομένα βίντεο.

**Ορισμός ρυθμίσεων περικοπής**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο κατά την αναπαραγωγή. Χρησιμοποιήστε ένα βίντεο μεγαλύτερο από 3,5 δευτερόλεπτα ώστε να παραμείνει ένα αναγώγιμο τμήμα.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ανάγνωση ρυθμίσεων περικοπής**

Αυτό το παράδειγμα εκτυπώνει τις τιμές περικοπής του πρώτου καρέ βίντεο στην πρώτη διαφάνεια σε χιλιοστά του δευτερολέπτου. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια. Εάν αυτή η διαφάνεια δεν έχει καρέ βίντεο, δεν εκτυπώνεται τίποτα. Το προηγούμενο παράδειγμα παράγει τιμές 2500 και 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Διαχείριση υπότιτλων βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστά υπότιτλους για καρέ βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι διαθέσιμοι μέσω της μεθόδου [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Προσθήκη υποτίτλων σε καρέ βίντεο**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και προσθέτει ένα WebVTT track υποτίτλων με ετικέτα English. Οι χρονικές στιγμές των υποτίτλων πρέπει να ταιριάζουν με το βίντεο. Η αποθηκευμένη παρουσίαση περιλαμβάνει τόσο το βίντεο όσο και τους υπότιτλους.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που σάς επιτρέπει να προσθέσετε υπότιτλους από μια ροή.

**Εξαγωγή υποτίτλων από καρέ βίντεο**

Αυτό το παράδειγμα αποθηκεύει όλα τα tracks υποτίτλων από τα καρέ βίντεο στην πρώτη διαφάνεια ως ξεχωριστά αρχεία WebVTT. Διαδοχικοί αριθμοί κρατούν τα εξαγόμενα αρχεία διακριτά. Η κονσόλα αναφέρει τον αριθμό των εξαγόμενων tracks. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) εκθέτει το αναγνωριστικό υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση υποτίτλων από καρέ βίντεο**

Αυτό το παράδειγμα αφαιρεί όλους τους υπότιτλους από το καρέ βίντεο στην πρώτη θέση σχήματος στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι καρέ βίντεο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Εάν χρειάζεται να αφαιρέσετε μόνο ένα track υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) ή [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) αντί για [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **Εξαγωγή βίντεο από διαφάνεια**

Εκτός από την προσθήκη βίντεων σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

Αυτό το παράδειγμα εξάγει τα ενσωματωμένα βίντεο από κάθε διαφάνεια σε ξεχωριστά, αριθμημένα δυαδικά αρχεία. Τα συνδεδεμένα βίντεο παραλείπονται επειδή δεν έχουν ενσωματωμένα δεδομένα. Η κονσόλα εκτυπώνει τον τύπο MIME κάθε βίντεο και το συνολικό πλήθος. Η έξοδος χρησιμοποιεί τη γενική επέκταση `.bin`; αλλάξτε την ώστε να ταιριάζει με τον αναφερόμενο τύπο μέσου όταν χρειάζεται.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Ποιοι παράμετροι αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα καρέ βίντεο;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (αυτόματα ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Αυτές οι επιλογές είναι διαθέσιμες μέσω των μεθόδων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, επομένως το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν συνδέεστε σε ένα διαδικτυακό βίντεο και προσθέτετε μια μικρογραφία, η παρουσίαση αποθηκεύει τον σύνδεσμο και την εικόνα προεπισκόπησης αντί για τα δεδομένα βίντεο, οπότε η αύξηση του μεγέθους είναι συνήθως μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον καρέ βίντεο χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) μέσα στο καρέ διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι ένα κοινό σενάριο για την ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στο δίσκο.