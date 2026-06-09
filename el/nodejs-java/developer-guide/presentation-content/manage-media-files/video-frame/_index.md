---
title: ΔΙΑΧΕΙΡΙΣΗ ΠΛΑΙΣΙΩΝ ΒΙΝΤΕΟ ΣΕ ΠΑΡΟΥΣΙΑΣΕΙΣ ΜΕ JAVASCRIPT
linktitle: ΠΛΑΙΣΙΟ ΒΙΝΤΕΟ
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
- πηγή ιστού
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java. Γρήγορος οδηγός βήμα-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα αλληλεπίδρασης με το κοινό σας. 

Το PowerPoint σας επιτρέπει να προσθέσετε βίντεο σε μία διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθήκη ή ενσωμάτωση τοπικού βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθήκη διαδικτυακού βίντεο (από πηγή ιστού όπως το YouTube). 

Για να μπορείτε να προσθέσετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει τις κλάσεις [Video](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) , καθώς και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation ](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation)class.
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε ένα τοπικά αποθηκευμένο βίντεο σε μια παρουσίαση:

```javascript
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Φορτώνει το βίντεο
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Λαμβάνει τη πρώτη διαφάνεια και προσθέτει ένα πλαίσιο βίντεο
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

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας τη διαδρομή του αρχείου απευθείας στη μέθοδο [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

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

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Πηγή Ιστού**

Η Microsoft [PowerPoint 2013 και νεότερες](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube στις παρουσιάσεις. Αν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο διαδικτυακά (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation ](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation)class
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/) και περάστε τον σύνδεσμο στο βίντεο.
1. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο. 
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε ένα βίντεο από το web σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

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

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε υπότιτλους κλειστών λεζάρων για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι προσβάσιμοι μέσω της μεθόδου [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) .

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
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

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/) παρέχει επίσης τη μέθοδο [addFromStream](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#addFromStream) που σας επιτρέπει να προσθέσετε υπότιτλους από μια ροή.

**Ανάκτηση Υπότιτλων από Πλαίσιο Βίντεο**

Για να ανακτήσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Βρείτε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) στόχο.
1. Επανάληψη στη συλλογή [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/) .
1. Αποθηκεύστε κάθε κομμάτι υπότιτλου σε αρχείο `.vtt` .

Ο παρακάτω κώδικας δείχνει πώς να ανακτήσετε υπότιτλους από ένα πλαίσιο βίντεο:

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
                // Αποθηκεύει το κομμάτι υπότιτλων σε αρχείο WebVTT.
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

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Λάβετε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) στόχο.
1. Αφαιρέστε τα κομμάτια υπότιτλων από τη συλλογή [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/) .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο παρακάτω κώδικας δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // τύπος: com.aspose.slides.VideoFrame

    // Αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αν χρειάζεστε να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#removeAt) αντί για την [clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#clear).

## **Ανάκτηση Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να ανακτήσετε βίντεο που είναι ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο.
2. Περιηγηθείτε σε όλα τα αντικείμενα [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/) .
3. Περιηγηθείτε σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) .
4. Αποθηκεύστε το βίντεο στο δίσκο.

Αυτός ο κώδικας JavaScript δείχνει πώς να ανακτήσετε το βίντεο από μια διαφάνεια παρουσίασης:

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

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να τροποποιηθούν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/setplaymode/) (αυτόματη ή με κλικ) και την [επαναληπτικότητα](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, με αποτέλεσμα το μέγεθος της παρουσίασης να αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να αντικαταστήσετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι συνήθης περίπτωση για ενημέρωση μέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο διαθέτει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/video/getcontenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στον δίσκο.