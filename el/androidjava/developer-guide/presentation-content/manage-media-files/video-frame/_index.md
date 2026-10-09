---
title: Διαχείριση πλαισίων βίντεο σε παρουσιάσεις στο Android
linktitle: Πλαίσιο βίντεο
type: docs
weight: 10
url: /el/androidjava/video-frame/
keywords:
- πρόσθεση βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- πλαίσιο βίντεο
- διαδικτυακή πηγή
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Γρήγορος οδηγός βήμα προς βήμα."
---
## **Εισαγωγή**

Τα βίντεο μπορούν να βοηθήσουν στην εξήγηση ιδεών και στην εμπλοκή του κοινού. Το Aspose.Slides για Android μέσω Java σάς επιτρέπει να προσθέτετε πλαίσια βίντεο στις διαφάνειες, να προσαρμόζετε τις ρυθμίσεις αναπαραγωγής, να διαχειρίζεστε υπότιτλους και να εξάγετε ενσωματωμένα δεδομένα βίντεο.

Το PowerPoint υποστηρίζει τοπικά βίντεο και συνδέσμους σε διαδικτυακά βίντεο, όπως βίντεο του YouTube.

Για την αναπαράσταση δεδομένων βίντεο και πλαισίων βίντεο, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία ενσωματωμένου πλαισίου βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης και αποθηκεύει το αποτέλεσμα. Οι συντεταγμένες και οι διαστάσεις του πλαισίου είναι σε μονάδες point. Η ροή παραμένει ανοιχτή μέχρι να ολοκληρωθεί η αποθήκευση, επειδή η μέθοδος [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) το κλειδώνει ενώ η παρουσίαση τη χρησιμοποιεί.

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

Μπορείτε επίσης να περάσετε άμεσα τη διαδρομή ενός τοπικού βίντεο στη μέθοδο [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Αυτό το παράδειγμα ενσωματώνει το βίντεο στην πρώτη διαφάνεια μιας νέας παρουσίασης. Το βίντεο πρέπει να είναι προσβάσιμο μέχρι η παρουσίαση αποθηκευτεί.

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

## **Δημιουργία πλαισίου βίντεο με βίντεο από διαδικτυακή πηγή**

Η Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζει διαδικτυακά βίντεο στις παρουσιάσεις. Μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο που συνδέεται σε ένα διαδικτυακό βίντεο, όπως βίντεο του YouTube.

Αυτό το παράδειγμα προσθέτει έναν σύνδεσμο βίντεο YouTube και μικρογραφία στην πρώτη διαφάνεια. Αντικαταστήστε το αναγνωριστικό βίντεο για να χρησιμοποιήσετε άλλο βίντεο. Η μέθοδος [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) ζητά αυτόματη αναπαραγωγή. Η λήψη της μικρογραφίας και η αναπαραγωγή του βίντεο απαιτούν πρόσβαση στο διαδίκτυο. Ο προβολέας της παρουσίασης πρέπει επίσης να υποστηρίζει την αναπαραγωγή διαδικτυακού βίντεο.

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

## **Αναπαραγωγή βίντεο σε λειτουργία πλήρους οθόνης**

Σε εκπαίδευτική παρουσίαση, μπορείτε να αναπαράγετε μια επίδειξη λογισμικού σε λειτουργία πλήρους οθόνης ώστε το κοινό να δει τις λεπτομέρειες. Καλέστε τη μέθοδο [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) με `true` για να ενεργοποιήσετε αυτή τη συμπεριφορά κατά την αναπαραγωγή.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την αναπαραγωγή πλήρους οθόνης. Η εισαγώμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μια διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

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

Η λειτουργία πλήρους οθόνης ελέγχει πώς εμφανίζεται το βίντεο. Ανεξάρτητα, η μέθοδος [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) ελέγχει αν ξεκινά αυτόματα ή με κλικ, ενώ η μέθοδος [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ελέγχει αν επαναλαμβάνεται. Για να επιλέξετε τη συμπεριφορά εκκίνησης, ορίστε τη λειτουργία αναπαραγωγής σε [VideoPlayModePreset.Auto ή VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Το παράδειγμα διατηρεί τις υπάρχουσες ρυθμίσεις εκκίνησης και βρόχου.

## **Επαναφορά βίντεο μετά την αναπαραγωγή**

Σε εκπαίδευτική παρουσίαση, η επαναφορά του βίντεο επίδειξης στην αρχή το κάνει έτοιμο για το δάσκαλο να το παίξει ξανά. Καλέστε τη μέθοδο [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) με `true` για να επιστρέψετε το βίντεο στην αρχή αφού τελειώσει η αναπαραγωγή.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την επαναφορά. Απενεργοποιεί την επανάληψη ώστε η αναπαραγωγή να μπορεί να τελειώσει και ορίζει την εκκίνηση με κλικ. Η εισαγώμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μια διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

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

Η επαναφορά επιστρέφει το βίντεο στην αρχή χωρίς να το ξεκινήσει ξανά. Αντίθετα, η κλήση της μεθόδου [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) με `true` επαναλαμβάνει την αναπαραγωγή αυτόματα. Διατηρήστε την επανάληψη απενεργοποιημένη όταν θέλετε το βίντεο να ολοκληρωθεί και να παραμείνει έτοιμο για επανάληψη. Η μέθοδος [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) ελέγχει ανεξάρτητα την αυτόματη ή με κλικ εκκίνηση· αυτό το παράδειγμα χρησιμοποιεί το [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) ώστε ο παρουσιαστής να ελέγχει πότε ξεκινά η αναπαραγωγή. Ορίστε τη λειτουργία αναπαραγωγής μετά τη ρύθμιση του βρόχου, όπως φαίνεται στο παράδειγμα. Η επαναφορά λειτουργεί ανεξάρτητα από τη μέθοδο [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Κοπή πλαισίου βίντεο**

Χρησιμοποιήστε τις μεθόδους [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) και [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) για να παραλείψετε μέρος της αρχής ή του τέλους ενός βίντεο κατά την αναπαραγωγή. Και οι δύο τιμές είναι σε χιλιοστά του δευτερολέπτου. Η κοπή αλλάζει τις ρυθμίσεις αναπαραγωγής χωρίς να τροποποιεί τα ενσωματωμένα δεδομένα βίντεο.

**Ορισμός ρυθμίσεων κοπής**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο κατά την αναπαραγωγή. Χρησιμοποιήστε βίντεο μεγαλύτερο από 3,5 δευτερόλεπτα ώστε να παραμείνει ένα αναπαραγώσιμο τμήμα.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ανάγνωση ρυθμίσεων κοπής**

Αυτό το παράδειγμα εκτυπώνει τις τιμές κοπής του πρώτου πλαισίου βίντεο στην πρώτη διαφάνεια σε χιλιοστά του δευτερολέπτου. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μια διαφάνεια. Εάν η διαφάνεια δεν έχει πλαίσιο βίντεο, δεν εκτυπώνεται τίποτα. Το προηγούμενο παράδειγμα παράγει τις τιμές 2500 και 1000.

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

## **Διαχείριση υποτίτλων βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστά υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι προσβάσιμοι μέσω της μεθόδου [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Προσθήκη υποτίτλων σε πλαίσιο βίντεο**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και προσθέτει ένα κομμάτι WebVTT υπότιτλων με ετικέτα English. Τα χρονικά σημεία των υποτίτλων πρέπει να ταιριάζουν με το βίντεο. Η αποθηκευμένη παρουσίαση περιλαμβάνει τόσο το βίντεο όσο και τους υπότιτλους του.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από ροή.

**Εξαγωγή υποτίτλων από πλαίσιο βίντεο**

Αυτό το παράδειγμα αποθηκεύει όλα τα κομμάτια υποτίτλων από τα πλαίσια βίντεο στην πρώτη διαφάνεια ως ξεχωριστά αρχεία WebVTT. Οι διαδοχικοί αριθμοί κρατούν τα αρχεία εξόδου διαφορετικά. Η κονσόλα αναφέρει τον αριθμό των εξαγόμενων κομματιών. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μια διαφάνεια.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) εκθέτει το αναγνωριστικό του υποτίτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υποτίτλου ως συμβολοσειρά UTF‑8.

**Αφαίρεση υποτίτλων από πλαίσιο βίντεο**

Αυτό το παράδειγμα αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο στην πρώτη θέση σχήματος στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πλαίσιο βίντεο.

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

Εάν χρειάζεστε να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) ή [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) αντί για τη [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) .

## **Εξαγωγή βίντεο από διαφάνεια**

Εκτός από την προσθήκη βίντεο στις διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο που είναι ενσωματωμένα σε παρουσιάσεις.

Αυτό το παράδειγμα εξάγει ενσωματωμένα βίντεο από κάθε διαφάνεια σε ξεχωριστά, αριθμημένα δυαδικά αρχεία. Τα συνδεδεμένα βίντεο παραλείπονται επειδή δεν έχουν ενσωματωμένα δεδομένα. Η κονσόλα εκτυπώνει τον τύπο MIME κάθε βίντεο και τον συνολικό αριθμό. Η έξοδος χρησιμοποιεί τη γενική επέκταση `.bin`; αλλάξτε την ώστε να ταιριάζει με τον τύπο μέσου που αναφέρεται όταν χρειάζεται.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

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
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Ποιοι παράμετροι αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα πλαίσιο βίντεο;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (αυτόματη ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Αυτές οι επιλογές είναι διαθέσιμες μέσω των μεθόδων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν συνδέετε ένα διαδικτυακό βίντεο και προσθέτετε μικρογραφία, η παρουσίαση αποθηκεύει μόνο το σύνδεσμο και την εικόνα προεπισκόπησης αντί για τα δεδομένα του βίντεο, οπότε η αύξηση του μεγέθους είναι συνήθως μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε υπάρχον πλαίσιο βίντεο χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) μέσα στο πλαίσιο ενώ διατηρείτε τη γεωμετρία του σχήματος· αυτό είναι συνηθισμένο σενάριο για την ενημέρωση μέσων σε υπάρχουσες διατάξεις.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο διαθέτει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε σε δίσκο.