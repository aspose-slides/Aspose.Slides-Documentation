---
title: Διαχείριση Πλαισίων Βίντεο σε Παρουσιάσεις στο Android
linktitle: Πλαίσιο Βίντεο
type: docs
weight: 10
url: /el/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Γρήγορος οδηγός βήμα-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα δέσμευσης με το κοινό σας. 

Το PowerPoint σάς επιτρέπει να προσθέτετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα διαδικτυακό βίντεο (από πηγή web όπως το YouTube).

Για να σας επιτρέψει να προσθέσετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας. 

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation)
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [IVideo] και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [IVideoFrame] για να δημιουργήσετε ένα πλαίσιο για το βίντεο.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ένα τοπικό βίντεο σε μια παρουσίαση:

```java
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Φορτώνει το βίντεο
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Παίρνει την πρώτη διαφάνεια και προσθέτει ένα πλαίσιο βίντεο
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας απευθείας τη διαδρομή του αρχείου στη μέθοδο [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Διαδικτυακή Πηγή**

Οι νεότερες εκδόσεις του Microsoft PowerPoint υποστηρίζουν βίντεο στο διαδίκτυο σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο στο διαδίκτυο (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation)
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [IVideo] και περάστε τον σύνδεσμο στο βίντεο.
1. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο. 
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ένα βίντεο από το διαδίκτυο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Προσθέτει ένα πλαίσιο βίντεο
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Φορτώνει μικρογραφία
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Περικοπή Πλαισίου Βίντεο**

Το Aspose.Slides σας επιτρέπει να ελέγχετε ποιο μέρος ενός βίντεο θα αναπαραχθεί ορίζοντας τις τιμές trim-from-start και trim-from-end μέσω των μεθόδων [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) και [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Και οι δύο τιμές καθορίζονται σε χιλιοστά του δευτερολέπτου και ορίζουν πόσο χρόνο παραλείπεται από την αρχή και το τέλος του βίντεο, αντίστοιχα. Αυτές οι ρυθμίσεις αλλάζουν τις ρυθμίσεις αναπαραγωγής βίντεο στην παρουσίαση· δεν κόβουν ή τροποποιούν τα ενσωματωμένα δυαδικά δεδομένα του βίντεο.

**Ορισμός Ρυθμίσεων Κοπής**

Για να δημιουργήσετε ένα πλαίσιο βίντεο και να ορίσετε τις ρυθμίσεις κοπής του:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/)
1. Προσθέστε ένα αντικείμενο [IVideo] στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [IVideoFrame] σε μια διαφάνεια.
1. Ορίστε τις τιμές trim-from-start και trim-from-end μέσω των [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) και [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα κώδικα παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο ενός ενσωματωμένου βίντεο κατά την αναπαραγωγή:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Ανάγνωση Ρυθμίσεων Κοπής**

Για να ελέγξετε τις υπάρχουσες ρυθμίσεις κοπής, φορτώστε μια παρουσίαση, βρείτε ένα αντικείμενο [IVideoFrame] μεταξύ των σχημάτων στην πρώτη διαφάνεια και διαβάστε τις τιμές μέσω των [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) και [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

Το παρακάτω παράδειγμα κώδικα βρίσκει το πρώτο πλαίσιο βίντεο στην πρώτη διαφάνεια και αναφέρει τις ρυθμίσεις κοπής του σε χιλιοστά του δευτερολέπτου:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι προσβάσιμοι μέσω της μεθόδου [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/)
1. Προσθέστε ένα βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [IVideoFrame] σε μια διαφάνεια.
1. Χρησιμοποιήστε τη [ICaptionsCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/) που επιστρέφεται από το [getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) για να προσθέσετε ένα WebVTT κομμάτι υποτίτλου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο κώδικας που ακολουθεί δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Προσθέτει ένα νέο κομμάτι υπότιτλων από αρχείο WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτιση που σας επιτρέπει να προσθέσετε υπότιτλους από μια ροή.

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Για να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Βρείτε το στόχο αντικείμενο [IVideoFrame].
1. Περάστε από τα κομμάτια υποτίτλων που επιστρέφει το [getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Αποθηκεύστε κάθε κομμάτι υποτίτλου σε αρχείο `.vtt`.

Ο κώδικας που ακολουθεί δείχνει πώς να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Αποθηκεύει το κομμάτι υποτίτλων σε αρχείο WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptions/) εκθέτει το αναγνωριστικό του υποτίτλου, την ετικέτα, τα δυαδικά δεδομένα και τα δεδομένα υποτίτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Αποκτήστε το στόχο αντικείμενο [IVideoFrame].
1. Αφαιρέστε τα κομμάτια υποτίτλων από τη συλλογή που επιστρέφεται από το [getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο κώδικας που ακολουθεί δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αν χρειάζεστε να αφαιρέσετε μόνο ένα κομμάτι υποτίτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ή [removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) αντί για το [clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο.
2. Περάστε από όλα τα αντικείμενα [ISlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/).
3. Περάστε από όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/).
4. Αποθηκεύστε το βίντεο στον δίσκο.

Αυτός ο κώδικας Java δείχνει πώς να εξάγετε το βίντεο από μια διαφάνεια σε παρουσίαση:

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Αποκτά την επέκταση αρχείου
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Ποια παραμέτρους αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (αυτόματα ή με κλικ) και την [ανακύκλωση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη ενός βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα συμπεριλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ένας σύνδεσμος και μια μικρογραφία ενσωματώνονται, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να αντικαταστήσετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι συνηθισμένο σενάριο για ενημέρωση πολυμέσου σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/video/#getContentType--) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στον δίσκο.