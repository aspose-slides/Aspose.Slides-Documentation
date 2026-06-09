---
title: Διαχείριση Ήχου σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Πλαίσιο Ήχου
type: docs
weight: 10
url: /el/nodejs-java/audio-frame/
keywords:
- ήχος
- πλαίσιο ήχου
- μικρογραφία
- προσθήκη ήχου
- ιδιότητες ήχου
- επιλογές ήχου
- εξαγωγή ήχου
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και ελέγχετε πλαίσια ήχου στο Aspose.Slides για Node.js—παραδείγματα ενσωμάτωσης, περικοπής, βρόχου και ρύθμισης αναπαραγωγής σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με καρέ ήχου στο Aspose.Slides. Δείχνει πώς να προσθέτετε ενσωματωμένο ήχο στις διαφάνειες, να προσαρμόζετε τη μικρογραφία του καρέ ήχου, να διαμορφώνετε επιλογές αναπαραγωγής όπως ένταση, επανάληψη, απόκρυψη, περιορισμό και διάρκειες εξασθένισης, και να εξάγετε τον ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης.

## **Δημιουργία Καρέ Ήχου**

Το Aspose.Slides for Node.js μέσω Java σάς επιτρέπει να προσθέτετε αρχεία ήχου στις διαφάνειες. Τα αρχεία ήχου ενσωματώνονται στις διαφάνειες ως καρέ ήχου.

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε τη αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Φορτώστε τη ροή του αρχείου ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο καρέ ήχου (που περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Ορίστε το [PlayMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AudioPlayModePreset) και το `Volume` που εκθέτει το αντικείμενο [AudioFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AudioFrame).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε ένα ενσωματωμένο καρέ ήχου σε μια διαφάνεια:

```javascript
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
const pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια
    const sld = pres.getSlides().get_Item(0);
    // Φορτώνει το αρχείο ήχου wav σε ροή
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Προσθέτει το Καρέ Ήχου
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Ορίζει τη Λειτουργία Αναπαραγωγής και την Ένταση του Ήχου
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Γράφει το αρχείο PowerPoint στο δίσκο
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αλλαγή Μικρογραφίας Καρέ Ήχου**

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως ένα καρέ με μια τυπική προεπιλεγμένη εικόνα (δείτε την εικόνα στην παρακάτω ενότητα). Μπορείτε να αλλάξετε την εικόνα προεπισκόπησης του καρέ ήχου (ορίστε την προτιμώμενη εικόνα σας).

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε τη μικρογραφία ή την εικόνα προεπισκόπησης ενός καρέ ήχου:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Προσθέτει ένα πλαίσιο ήχου στη διαφάνεια με καθορισμένη θέση και μέγεθος.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Προσθέτει μια εικόνα στους πόρους της παρουσίασης.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ορίζει την εικόνα για το πλαίσιο ήχου.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Αλλαγή Επιλογών Αναπαραγωγής Ήχου**

Το Aspose.Slides for Node.js μέσω Java σάς επιτρέπει να αλλάξετε επιλογές που ελέγχουν την αναπαραγωγή ή τις ιδιότητες ενός ήχου. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση του ήχου, να ορίσετε την αναπαραγωγή σε βρόχο ή ακόμη και να αποκρύψετε το εικονίδιο ήχου.

Το πλαίσιο **Audio Options** στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/) :

- **Start** η αναπτυσσόμενη λίστα ταιριάζει με τη μέθοδο [AudioFrame.setPlayMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** ταιριάζει με τη μέθοδο [AudioFrame.setVolume](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** ταιριάζει με τη μέθοδο [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** ταιριάζει με τη μέθοδο [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** ταιριάζει με τη μέθοδο [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** ταιριάζει με τη μέθοδο [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setRewindAudio).

Οι επιλογές **Editing** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/) :

- **Fade In** ταιριάζει με τη μέθοδο [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** ταιριάζει με τη μέθοδο [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** ταιριάζει με τη μέθοδο [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setTrimFromStart).
- **Trim Audio End Time** η τιμή ισούται με τη διάρκεια του ήχου μείον την τιμή της μεθόδου [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd).

Ο έλεγχος **Volume** του PowerPoint στον πίνακα ελέγχου ήχου αντιστοιχεί στη μέθοδο [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Σας επιτρέπει να αλλάξετε την ένταση του ήχου ως ποσοστό.

Αυτή είναι η διαδικασία για να αλλάξετε τις επιλογές Audio Play:

1. [Δημιουργήστε](#create-audio-frame) ή αποκτήστε το Audio Frame.
2. Ορίστε νέες τιμές για τις ιδιότητες του Audio Frame που θέλετε να προσαρμόσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

Αυτός ο κώδικας JavaScript παρουσιάζει μια λειτουργία στην οποία προσαρμόζονται οι επιλογές ενός ήχου:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Αποκτά το σχήμα AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ορίζει τη λειτουργία αναπαραγωγής για αναπαραγωγή με κλικ
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Ορίζει την ένταση σε χαμηλή
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Ορίζει τον ήχο να αναπαράγεται σε όλες τις διαφάνειες
    audioFrame.setPlayAcrossSlides(true);
    // Απενεργοποιεί το βρόχο του ήχου
    audioFrame.setPlayLoopMode(false);
    // Αποκρύπτει το AudioFrame κατά τη διάρκεια της παρουσίασης
    audioFrame.setHideAtShowing(true);
    // Επαναφέρει τον ήχο στην αρχή μετά την αναπαραγωγή
    audioFrame.setRewindAudio(true);
    // Αποθηκεύει το αρχείο PowerPoint στο δίσκο
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αυτό το παράδειγμα JavaScript δείχνει πώς να προσθέσετε ένα νέο καρέ ήχου με ενσωματωμένο ήχο, να το κόψετε και να ορίσετε τις διάρκειες εξασθένισης:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ορίζει το offset έναρξης περικοπής στα 1,5 δευτερόλεπτα
    audioFrame.setTrimFromStart(1500);
    // Ορίζει το offset λήξης περικοπής στα 2 δευτερόλεπτα
    audioFrame.setTrimFromEnd(2000);

    // Ορίζει τη διάρκεια εξασθένισης εισόδου στα 200 ms
    audioFrame.setFadeInDuration(200);
    // Ορίζει τη διάρκεια εξασθένισης εξόδου στα 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ανακτήσετε ένα καρέ ήχου με ενσωματωμένο ήχο και να ορίσετε την ένταση του στο 85%:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Αποκτά ένα σχήμα καρέ ήχου
    const audioFrame = slide.getShapes().get_Item(0);

    // Ορίζει την ένταση του ήχου στο 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Διαχείριση Υπότιτλων Ήχου**

Το Aspose.Slides σάς επιτρέπει να προσθέσετε κλειστά υπότιτλους σε ένα καρέ ήχου μέσω της μεθόδου [getCaptionTracks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Αυτή η μέθοδος επιστρέφει ένα [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/), το οποίο σας επιτρέπει να προσθέσετε κομμάτια υποτίτλων WebVTT, να διατρέξετε τα υπάρχοντα κομμάτια και να τα αφαιρέσετε όταν είναι απαραίτητο.

**Προσθήκη Υπότιτλων Ήχου**

Χρησιμοποιήστε τη μέθοδο [getCaptionTracks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) για να συνδέσετε ένα ή περισσότερα κομμάτια υποτίτλων σε ένα καρέ ήχου. Στο παρακάτω παράδειγμα, προστίθεται ένα αρχείο ήχου σε μια διαφάνεια και στη συνέχεια φορτώνεται ένα νέο κομμάτι υποτίτλου από ένα αρχείο `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Προσθέτει ένα νέο κομμάτι υπότιτλου από αρχείο WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Εξαγωγή Υπότιτλων Ήχου**

Μπορείте να διατρέξετε τα κομμάτια υποτίτλων που συνδέονται με ένα καρέ ήχου και να τα αποθηκεύσετε ως αρχεία `.vtt`. Κάθε κομμάτι υπότιτλου εκθέτει τα δυαδικά του δεδομένα και ένα μοναδικό αναγνωριστικό, τα οποία μπορούν να χρησιμοποιηθούν κατά την εξαγωγή των υποτίτλων.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Αποθηκεύει το κομμάτι υπότιτλου ως αρχείο .vtt.
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

**Κατάργηση Υπότιτλων Ήχου**

Για να αφαιρέσετε υπότιτλους από ένα καρέ ήχου, χρησιμοποιήστε τις μεθόδους που παρέχει το [CaptionsCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/), όπως [clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/captionscollection/#removeAt). Το παρακάτω παράδειγμα αφαιρεί όλα τα κομμάτια υποτίτλων από ένα καρέ ήχου.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // τύπος: aspose.slides.AudioFrame

    // Αφαιρέστε όλα τα κομμάτια υπότιτλων από το πλαίσιο ήχου.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή Ήχου**

Το Aspose.Slides for Node.js μέσω Java σάς επιτρέπει να εξάγετε τον ήχο που χρησιμοποιείται στις μεταβάσεις παρουσίασης. Για παράδειγμα, μπορείτε να εξάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Αποκτήστε τη σχετική αναφορά διαφάνειας μέσω του δείκτη της.
3. Πρόσβαση στις [slideshow transitions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) για τη διαφάνεια.
4. Εξάγετε τον ήχο ως δεδομένα byte.

Αυτός ο κώδικας σε JavaScript δείχνει πώς να εξάγετε τον ήχο που χρησιμοποιείται σε μια διαφάνεια:

```javascript
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Πρόσβαση στη ζητούμενη διαφάνεια
    const slide = pres.getSlides().get_Item(0);
    // Λαμβάνει τα εφέ μετάβασης της παρουσίασης για τη διαφάνεια
    const transition = slide.getSlideShowTransition();
    // Εξάγει τον ήχο σε πίνακα bytes
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Μπορώ να επαναχρησιμοποιήσω το ίδιο αρχείο ήχου σε πολλαπλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη [audio collection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getaudios/) κοινόχρηστη της παρουσίασης και δημιουργήστε επιπλέον καρέ ήχου που αναφέρονται σε αυτό το υπάρχον στοιχείο. Αυτό αποφεύγει τον διπλασιασμό των δεδομένων πολυμέσων και διατηρεί το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον καρέ ήχου χωρίς να δημιουργήσω ξανά το σχήμα;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε τη [link path](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο [embedded audio](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) με ένα άλλο από τη [audio collection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getaudios/) της παρουσίασης. Η μορφοποίηση του πλαισίου και οι περισσότερες ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Αλλάζει η περικοπή τα υποκείμενα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Η περικοπή ρυθμίζει μόνο τα όρια αναπαραγωγής. Τα αρχικά bytes του ήχου παραμένουν άθικτα και προσβάσιμα μέσω του ενσωματωμένου ήχου ή της συλλογής ήχου της παρουσίασης.