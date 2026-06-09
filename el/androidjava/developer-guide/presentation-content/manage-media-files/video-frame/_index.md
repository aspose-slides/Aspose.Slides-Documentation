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
description: "Μάθετε πώς να προσθέσετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android με Java. Γρήγορος οδηγός βήμα-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο συναρπαστικό και να αυξήσει τα επίπεδα εμπλοκής με το κοινό σας. 

PowerPoint σας επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθήκη ή ενσωμάτωση τοπικού βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθήκη online βίντεο (από διαδικτυακή πηγή όπως το YouTube).

Για να μπορείτε να προσθέσετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνεια σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας. 

1. Δημιουργήστε μια περίπτωση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideo/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο. 
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε ένα τοπικά αποθηκευμένο βίντεο σε μια παρουσίαση:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
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

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας τη διαδρομή του αρχείου του απευθείας στη μέθοδο [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

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

Το Microsoft [PowerPoint 2013 και νεότερες εκδόσεις](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο online (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου. 

1. Δημιουργήστε μια περίπτωση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideo/) και περάστε το σύνδεσμο στο βίντεο. 
1. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο. 
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε ένα βίντεο από το web σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

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

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστά υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι προσβάσιμοι μέσω της μεθόδου [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε μια περίπτωση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
1. Προσθέστε ένα βίντεο στην παρουσίαση. 
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/) σε μια διαφάνεια. 
1. Χρησιμοποιήστε τη [ICaptionsCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/) που επιστρέφεται από το [getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) για να προσθέσετε ένα κομμάτι υπότιτλου WebVTT. 
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Ο παρακάτω κώδικας σας δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από ροή.

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Για την εξαγωγή υπότιτλων από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο. 
1. Βρείτε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/) στόχο. 
1. Διασχίστε τα κομμάτια υποτίτλων που επιστρέφονται από το [getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--). 
1. Αποθηκεύστε κάθε κομμάτι υποτίτλου σε αρχείο `.vtt`. 

Ο παρακάτω κώδικας σας δείχνει πώς να εξαγάγετε υπότιτλους από ένα πλαίσιο βίντεο:

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

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και τα δεδομένα του υπότιτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο. 
1. Αποκτήστε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/) στόχο. 
1. Αφαιρέστε τα κομμάτια υποτίτλων από τη συλλογή που επιστρέφεται από το [getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--). 
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

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

Εάν χρειάζεστε να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ή [removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) αντί για την [clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **Εξαγωγή Βίντεο από Διαφάνεια**

Πέρα από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε μια περίπτωση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο. 
2. Διασχίστε όλα τα αντικείμενα [ISlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/) . 
3. Διασχίστε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/) . 
4. Αποθηκεύστε το βίντεο στο δίσκο. 

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

                //Αποκτά την επέκταση του αρχείου
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

## **FAQ**

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να τροποποιηθούν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [playback mode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (αυτόματη ή με κλικ) και την [looping](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) . Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα συμπεριλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα online βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [video content](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι κοινό σενάριο για ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [content type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/video/#getContentType--) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στον δίσκο.