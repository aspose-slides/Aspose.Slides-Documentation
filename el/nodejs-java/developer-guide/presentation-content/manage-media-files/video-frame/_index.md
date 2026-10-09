---
title: Διαχείριση πλαισίων βίντεο σε παρουσιάσεις χρησιμοποιώντας Node.js
linktitle: Πλαίσιο βίντεο
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
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματισμένα πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για Node.js μέσω Java. Γρήγορος οδηγός how‑to."
---
## **Εισαγωγή**

Τα βίντεο μπορούν να βοηθήσουν στην επεξήγηση ιδεών και στην προσέλκυση του κοινού. Το Aspose.Slides for Node.js μέσω Java σας επιτρέπει να προσθέτετε πλαίσια βίντεο στις διαφάνειες, να ρυθμίζετε τις επιλογές αναπαραγωγής, να διαχειρίζεστε υπότιτλους και να εξάγετε τα ενσωματωμένα δεδομένα βίντεο.

Το PowerPoint υποστηρίζει τοπικά βίντεο και συνδέσμους σε διαδικτυακά βίντεο, όπως βίντεο στο YouTube.

Για την αναπαράσταση δεδομένων βίντεο και πλαισίων βίντεο, το Aspose.Slides παρέχει την κλάση [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) , την κλάση [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία ενσωματωμένου πλαισίου βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης και αποθηκεύει το αποτέλεσμα. Οι συντεταγμένες και οι διαστάσεις του πλαισίου είναι σε μονάδες σημείου (points). Η ροή παραμένει ανοιχτή μέχρι να ολοκληρωθεί η αποθήκευση, επειδή η μέθοδος [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) τη διατηρεί κλειδωμένη ενώ η παρουσίαση τη χρησιμοποιεί.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να περάσετε μια τοπική διαδρομή βίντεο απευθείας στη μέθοδο [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Αυτό το παράδειγμα ενσωματώνει το βίντεο στην πρώτη διαφάνεια μιας νέας παρουσίασης. Το βίντεο πρέπει να παραμένει προσβάσιμο μέχρι να αποθηκευτεί η παρουσίαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Δημιουργία πλαισίου βίντεο με βίντεο από διαδικτυακή πηγή**

Το Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζει διαδικτυακά βίντεο στις παρουσιάσεις. Μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο που συνδέεται με ένα διαδικτυακό βίντεο, όπως ένα βίντεο στο YouTube.

Αυτό το παράδειγμα προσθέτει έναν σύνδεσμο βίντεο YouTube και μικρογραφία στην πρώτη διαφάνεια. Αντικαταστήστε το αναγνωριστικό βίντεο για να χρησιμοποιήσετε άλλο βίντεο. Η μέθοδος [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) ζητά αυτόματη αναπαραγωγή. Η λήψη της μικρογραφίας και η αναπαραγωγή του βίντεο απαιτούν πρόσβαση στο διαδίκτυο. Ο προγράμματος προβολής της παρουσίασης πρέπει επίσης να υποστηρίζει την αναπαραγωγή διαδικτυακού βίντεο.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αναπαραγωγή βίντεο σε λειτουργία πλήρους οθόνης**

Σε μια παρουσίαση εκπαίδευσης, μπορείτε να αναπαράγετε μια επίδειξη λογισμικού σε λειτουργία πλήρους οθόνης ώστε το κοινό να βλέπει τις λεπτομέρειες. Καλέστε τη μέθοδο [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) με `true` για να ενεργοποιήσετε αυτή τη συμπεριφορά κατά την αναπαραγωγή.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, εντοπίζει το πρώτο [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την αναπαραγωγή σε πλήρη οθόνη. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μια διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αναπαραγωγή σε πλήρη οθόνη ελέγχει πώς εμφανίζεται το βίντεο. Ξεχωριστά, η μέθοδος [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) ελέγχει αν η αναπαραγωγή ξεκινά αυτόματα ή με κλικ, και η [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ελέγχει αν επαναλαμβάνεται. Για να επιλέξετε τη συμπεριφορά εκκίνησης, ορίστε τη λειτουργία αναπαραγωγής σε [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Το παράδειγμα διατηρεί τις υπάρχουσες ρυθμίσεις εκκίνησης και βρόχου.

## **Επιστροφή του βίντεο στην αρχή μετά την αναπαραγωγή**

Σε μια παρουσίαση εκπαίδευσης, η επιστροφή ενός βίντεο επίδειξης στην αρχή το καθιστά έτοιμο για ξανά αναπαραγωγή από τον παρουσιαστή. Καλέστε τη μέθοδο [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) με `true` για να επιστρέψετε το βίντεο στην αρχή μετά το τέλος της αναπαραγωγής.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, εντοπίζει το πρώτο [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την επαναφορά. Απενεργοποιεί τον βρόχο ώστε η αναπαραγωγή να μπορεί να ολοκληρωθεί και ορίζει την αναπαραγωγή να ξεκινά με κλικ. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μια διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η επαναφορά επιστρέφει το βίντεο στην αρχή χωρίς να το ξεκινήσει ξανά. Αντίθετα, η κλήση της [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) με `true` επαναλαμβάνει την αναπαραγωγή αυτόματα. Κρατήστε τον βρόχο απενεργοποιημένο όταν θέλετε το βίντεο να ολοκληρωθεί και να παραμείνει έτοιμο για επανεκκίνηση. Η [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) ελέγχει ανεξάρτητα την αυτόματη ή την έναρξη με κλικ· αυτό το παράδειγμα χρησιμοποιεί το [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) ώστε ο παρουσιαστής να ελέγχει πότε ξεκινά η αναπαραγωγή. Ορίστε τη λειτουργία αναπαραγωγής μετά τη ρύθμιση του βρόχου, όπως φαίνεται στο παράδειγμα. Η επαναφορά λειτουργεί ανεξάρτητα από τη [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Περικοπή πλαισίου βίντεο**

Χρησιμοποιήστε τις μεθόδους [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) και [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) για να παραλείψετε μέρος της αρχής ή του τέλους ενός βίντεο κατά την αναπαραγωγή. Και οι δύο τιμές είναι σε χιλιοστά του δευτερολέπτου. Η περικοπή αλλάζει τις ρυθμίσεις αναπαραγωγής χωρίς να τροποποιεί τα ενσωματωμένα δεδομένα βίντεο.

**Ορισμός ρυθμίσεων περικοπής**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο κατά την αναπαραγωγή. Χρησιμοποιήστε ένα βίντεο μεγαλύτερο από 3,5 δευτερόλεπτα ώστε να παραμένει ένα αναπαραγώσιμο τμήμα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ανάγνωση ρυθμίσεων περικοπής**

Αυτό το παράδειγμα εκτυπώνει τις τιμές περικοπής του πρώτου πλαισίου βίντεο στην πρώτη διαφάνεια σε χιλιοστά του δευτερολέπτου. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μια διαφάνεια. Εάν αυτή η διαφάνεια δεν έχει πλαίσιο βίντεο, δεν εκτυπώνεται τίποτα. Το προηγούμενο παράδειγμα παράγει τιμές 2500 και 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Διαχείριση υποτίτλων βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστά υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της μεθόδου [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Προσθήκη υποτίτλων σε πλαίσιο βίντεο**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και προσθέτει ένα κομμάτι υπότιτλου WebVTT με ετικέτα English. Οι χρονικές σημάνσεις των υποτίτλων πρέπει να ταιριάζουν με το βίντεο. Η αποθηκευμένη παρουσίαση περιλαμβάνει τόσο το βίντεο όσο και τους υπότιτλούς του.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) παρέχει επίσης τη μέθοδο [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) για την προσθήκη υποτίτλων από μια ροή.

**Εξαγωγή υποτίτλων από πλαίσιο βίντεο**

Αυτό το παράδειγμα αποθηκεύει όλα τα κομμάτια υποτίτλων από τα πλαίσια βίντεο στην πρώτη διαφάνεια ως ξεχωριστά αρχεία WebVTT. Τα διαδοχικά νούμερα κρατούν τα αρχεία εξόδου διακεκριμένα. Η κονσόλα αναφέρει τον αριθμό των εξαγόμενων κομματιών. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μια διαφάνεια.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) εκθέτει το αναγνωριστικό υποτίτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο υποτίτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση υποτίτλων από πλαίσιο βίντεο**

Αυτό το παράδειγμα αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο στην πρώτη θέση σχήματος της πρώτης διαφάνειας και αποθηκεύει το αποτέλεσμα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πλαίσιο βίντεο.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Εάν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υποτίτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) αντί για [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Εξαγωγή βίντεο από διαφάνεια**

Πέρα από την προσθήκη βίντεο στις διαφάνειες, το Aspose.Slides επιτρέπει την εξαγωγή βίντεο ενσωματωμένων σε παρουσιάσεις.

Αυτό το παράδειγμα εξάγει τα ενσωματωμένα βίντεο από κάθε διαφάνεια σε ξεχωριστά αριθμημένα δυαδικά αρχεία. Τα συνδεδεμένα βίντεο παραλείπονται επειδή δεν έχουν ενσωματωμένα δεδομένα. Η κονσόλα εκτυπώνει το τύπο MIME κάθε βίντεο και το συνολικό πλήθος. Η έξοδος χρησιμοποιεί τη γενική επέκταση `.bin`; αλλάξτε την ώστε να ταιριάζει με τον αναφερόμενο τύπο μέσου όταν χρειάζεται.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα πλαίσιο βίντεο;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (αυτόματη ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Αυτές οι επιλογές διατίθενται μέσω των μεθόδων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, έτσι το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν συνδέεστε σε διαδικτυακό βίντεο και προσθέτετε μικρογραφία, η παρουσίαση αποθηκεύει τον σύνδεσμο και την εικόνα προεπισκόπησης αντί για τα δεδομένα του βίντεο, οπότε η αύξηση μεγέθους είναι συνήθως μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον πλαίσιο βίντεο χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι ένα συνηθισμένο σενάριο για την ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε σε δίσκο.