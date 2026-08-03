---
title: Διαχείριση Πλαισίων Βίντεο σε Παρουσιάσεις με Java
linktitle: Πλαίσιο Βίντεο
type: docs
weight: 10
url: /el/java/video-frame/
keywords:
- προσθήκη βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- πλαίσιο βίντεο
- πηγή web
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java. Γρήγορος οδηγός βήμα-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει το επίπεδο αλληλεπίδρασης με το κοινό σας. 

Το PowerPoint σας επιτρέπει να προσθέτετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθήκη ή ενσωμάτωση τοπικού βίντεο (αποθηκευμένου στον υπολογιστή σας)
* Προσθήκη διαδικτυακού βίντεο (από πηγή στο web όπως το YouTube).

Για να προσθέσετε βίντεο (αντικείμενα video) σε μια παρουσίαση, το Aspose.Slides παρέχει τις διεπαφές [IVideo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους. 

## **Δημιουργία Ενσωματωμένων Πλαισίων Βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας. 

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation ](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation)class.
1. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideo/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

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

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περάζοντας άμεσα τη διαδρομή του αρχείου στην μέθοδο [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Δημιουργία Πλαισίων Βίντεο από Πηγές στο Διαδίκτυο**

Η Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube σε παρουσιάσεις. Αν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο online (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου. 

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation ](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation)class.
1. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideo/) και περάστε τον σύνδεσμο στο βίντεο.
1. Ορίστε ένα μικρογραφικό για το πλαίσιο βίντεο. 
1. Αποθηκεύστε την παρουσίαση. 

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

Το Aspose.Slides σας επιτρέπει να ελέγχετε ποιο τμήμα ενός βίντεο θα παίξει ορίζοντας τις τιμές trim‑from‑start και trim‑from‑end μέσω των μεθόδων [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) και [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Και οι δύο τιμές δίνεται σε χιλιοστά του δευτερολέπτου και ορίζουν πόσο χρόνο παραλείπεται από την αρχή και το τέλος του βίντεο, αντίστοιχα. Αυτές οι ρυθμίσεις αλλάζουν τις ρυθμίσεις αναπαραγωγής του βίντεο στην παρουσίαση· δεν κόβουν ή τροποποιούν τα ενσωματωμένα δυαδικά δεδομένα του βίντεο.

**Ορισμός Ρυθμίσεων Περικοπής**

Για να δημιουργήσετε ένα πλαίσιο βίντεο και να ορίσετε τις ρυθμίσεις περικοπής:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideo/) στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/) σε μια διαφάνεια.
1. Ορίστε τις τιμές trim‑from‑start και trim‑from‑end μέσω των μεθόδων [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) και [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

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

**Ανάγνωση Ρυθμίσεων Περικοπής**

Για να ελέγξετε τις υπάρχουσες ρυθμίσεις περικοπής, φορτώστε μια παρουσίαση, βρείτε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/) μεταξύ των σχήματων στην πρώτη διαφάνεια και διαβάστε τις τιμές μέσω των μεθόδων [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) και [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

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

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και προσβάλλονται μέσω της μεθόδου [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
1. Προσθέστε ένα βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/) σε μια διαφάνεια.
1. Χρησιμοποιήστε το [ICaptionsCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/) που επιστρέφεται από το [getCaptionTracks](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) για να προσθέσετε ένα κομμάτι υποτίτλου WebVTT.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Προσθέτει ένα νέο κομμάτι υποτίτλων από αρχείο WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από ροή δεδομένων.

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Για να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Βρείτε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/)‑στόχο.
1. Επανάληψη στα κομμάτια υποτίτλων του [ICaptionsCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/) .
1. Αποθηκεύστε κάθε κομμάτι υποτίτλου σε αρχείο `.vtt`.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Αποθηκεύει το κομμάτι υποτίτλων σε αρχείο WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF‑8.

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Λάβετε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/)‑στόχο.
1. Αφαιρέστε τα κομμάτια υποτίτλων από το [ICaptionsCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/) .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υποτίτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ή [removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/#removeAt-int-) αντί για την [clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/#clear--) .

## **Εξαγωγή Βίντεο από Διαφάνειες**

Εκτός από την προσθήκη βίντεο στις διαφάνειες, το Aspose.Slides επιτρέπει την εξαγωγή βίντεο που είναι ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο. 
2. Επανάληψη σε όλα τα αντικείμενα [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/) .
3. Επανάληψη σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/videoframe/) . 
4. Αποθηκεύστε το βίντεο στον δίσκο.

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

                //Λαμβάνει την επέκταση αρχείου
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

**Ποια παραμέτρων αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/el/java/com.aspose.slides/videoframe/#setPlayMode-int-) (αυτόματα ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/el/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/videoframe/) .

**Αυξάνει το μέγεθος του αρχείου PPTX η προσθήκη βίντεο;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα συμπεριλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται αναλογικά με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και ένα μικρογραφικό, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να αντικαταστήσετε το [πρόσθετο βίντεο](https://reference.aspose.com/slides/el/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτή είναι μια συχνή περίπτωση για ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/el/java/com.aspose.slides/video/#getContentType--) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στον δίσκο.