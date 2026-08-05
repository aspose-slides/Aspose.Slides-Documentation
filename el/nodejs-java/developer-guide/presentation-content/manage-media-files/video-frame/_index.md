---
title: Διαχείριση Πλαισίων Βίντεο σε Παρουσιάσεις με JavaScript
linktitle: Πλαίσιο Βίντεο
type: docs
weight: 10
url: /el/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java. Γρήγορος οδηγός βήμα-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο συναρπαστικό και να αυξήσει τα επίπεδα εμπλοκής με το κοινό σας.  

Το PowerPoint σας επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια μιας παρουσίασης με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα διαδικτυακό βίντεο (από πηγή web όπως το YouTube).

Για να μπορείτε να προσθέσετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει την κλάση [Video](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/) , την κλάση [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνεια σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.  

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation)  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση.  
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσθέσετε ένα τοπικά αποθηκευμένο βίντεο σε μια παρουσίαση:

```javascript
// Δημιουργεί μια παρουσία της κλάσης Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Φορτώνει το βίντεο
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Παίρνει την πρώτη διαφάνεια και προσθέτει ένα πλαίσιο βίντεο
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας απευθείας τη διαδρομή του αρχείου στη μέθοδο [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Διαδικτυακή Πηγή**

Η Microsoft [PowerPoint 2013 και νεότερες εκδόσεις](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube στις παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο online (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίαση μέσω του διαδικτυακού του συνδέσμου.  

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation)  
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/) και περάστε τον σύνδεσμο προς το βίντεο.  
1. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο.  
1. Αποθηκεύστε την παρουσίαση.  

Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσθέσετε ένα βίντεο από το web σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```javascript
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Περικοπή Πλαισίου Βίντεο**

Το Aspose.Slides σας επιτρέπει να ελέγξετε ποιο τμήμα ενός βίντεο θα αναπαραχθεί ορίζοντας τις τιμές trim-from-start και trim-from-end μέσω των [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/settrimfromstart/) και [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/settrimfromend/). Και οι δύο τιμές καθορίζονται σε χιλιοστά του δευτερολέπτου και ορίζουν πόσο χρόνο θα παραληφθεί από την αρχή και το τέλος του βίντεο, αντίστοιχα. Αυτές οι ρυθμίσεις αλλάζουν τις ρυθμίσεις αναπαραγωγής του βίντεο στην παρουσίαση· δεν κόβουν ή τροποποιούν τα ενσωματωμένα δυαδικά δεδομένα του βίντεο.

**Ορισμός Ρυθμίσεων Περικοπής**

Για να δημιουργήσετε ένα πλαίσιο βίντεο και να ορίσετε τις ρυθμίσεις περικοπής του:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/)  
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/) στην παρουσίαση.  
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) σε μια διαφάνεια.  
1. Ορίστε τις τιμές trim-from-start και trim-from-end μέσω των [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/settrimfromstart/) και [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/settrimfromend/).  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Ο παρακάτω κώδικας παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο ενός ενσωματωμένου βίντεο κατά την αναπαραγωγή:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Ανάγνωση Ρυθμίσεων Περικοπής**

Για να εξετάσετε υφιστάμενες ρυθμίσεις περικοπής, φορτώστε μια παρουσίαση, βρείτε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) μεταξύ των σχημάτων στην πρώτη διαφάνεια και διαβάστε τις τιμές μέσω των [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) και [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/gettrimfromend/).  

Ο παρακάτω κώδικας εντοπίζει το πρώτο πλαίσιο βίντεο στην πρώτη διαφάνεια και αναφέρει τις ρυθμίσεις περικοπής του σε χιλιοστά του δευτερολέπτου:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειριστείτε κλειστά υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι προσβάσιμοι μέσω της μεθόδου [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/)  
1. Προσθέστε ένα βίντεο στην παρουσίαση.  
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) σε μια διαφάνεια.  
1. Χρησιμοποιήστε τη συλλογή [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/) για να προσθέσετε ένα κομμάτι υπότιτλου WebVTT.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Προσθέτει ένα νέο κομμάτι υπότιτλων από αρχείο WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/) παρέχει επίσης τη μέθοδο [addFromStream](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#addFromStream) που σας επιτρέπει να προσθέσετε υπότιτλους από ένα ρεύμα.

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Για να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.  
1. Εντοπίστε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/).  
1. Περάστε τη συλλογή [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/).  
1. Αποθηκεύστε κάθε κομμάτι υπότιτλου σε αρχείο `.vtt`.  

Ο παρακάτω κώδικας δείχνει πώς να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Αποθηκεύει το κομμάτι υποτίτλων σε αρχείο WebVTT.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο υπότιτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.  
1. Αποκτήστε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/).  
1. Αφαιρέστε τα κομμάτια υπότιτλων από τη συλλογή [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/).  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Ο παρακάτω κώδικας δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // τύπος: com.aspose.slides.VideoFrame

    // Αφαίρεει όλους τους υπότιτλους από το πλαίσιο βίντεο.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Εάν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#removeAt) αντί για τη [clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#clear).

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο.  
2. Περάστε όλα τα αντικείμενα [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/).  
3. Περάστε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) για να εντοπίσετε ένα [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/).  
4. Αποθηκεύστε το βίντεο στο δίσκο.  

Αυτός ο κώδικας JavaScript σας δείχνει πώς να εξάγετε το βίντεο από μια διαφάνεια παρουσίασης:

```javascript
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Λαμβάνει την επέκταση αρχείου
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Ποιοι παράμετροι αναπαραγωγής βίντεο μπορούν να τροποποιηθούν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/setplaymode/) (αυτόματα ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα συμπεριλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι κοινή πρακτική για την ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει ένα [τύπο περιεχομένου](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/getcontenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στο δίσκο.