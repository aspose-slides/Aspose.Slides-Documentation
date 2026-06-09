---
title: Διαχείριση ήχου σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Πλαίσιο ήχου
type: docs
weight: 10
url: /el/java/audio-frame/
keywords:
- ήχος
- πλαίσιο ήχου
- μικρογραφία
- προσθήκη ήχου
- ιδιότητες ήχου
- επιλογές ήχου
- εξαγωγή ήχου
- Java
- Aspose.Slides
description: "Δημιουργία και έλεγχος πλαισίων ήχου στο Aspose.Slides for Java—παραδείγματα κώδικα για ενσωμάτωση, περικοπή, βρόχο και ρύθμιση της αναπαραγωγής σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με πλαίσια ήχου στο Aspose.Slides. Δείχνει πώς να προσθέσετε ενσωματωμένο ήχο σε διαφάνειες, να προσαρμόσετε τη μικρογραφία του πλαισίου ήχου, να ρυθμίσετε επιλογές αναπαραγωγής όπως ένταση, βρόχο, απόκρυψη, περικοπή και διάρκειες εξασθένισης, και να εξάγετε ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης.

## **Δημιουργία Πλαισίων Ήχου**

Το Aspose.Slides for Java σας επιτρέπει να προσθέσετε αρχεία ήχου σε διαφάνειες. Τα αρχεία ήχου ενσωματώνονται σε διαφάνειες ως πλαίσια ήχου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Λάβετε αναφορά σε μια διαφάνεια μέσω του ευρετηρίου της.
3. Φορτώστε τη ροή του αρχείου ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο πλαίσιο ήχου (το οποίο περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Ορίστε το [PlayMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/AudioPlayModePreset) και το `Volume` που εκτίθενται από το αντικείμενο [IAudioFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAudioFrame).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε ένα ενσωματωμένο πλαίσιο ήχου σε μια διαφάνεια:

```java
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Φορτώνει το αρχείο ήχου wav σε ροή
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Προσθέτει το πλαίσιο ήχου
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Ορίζει τη λειτουργία αναπαραγωγής και την ένταση του ήχου
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Γράφει το αρχείο PowerPoint στον δίσκο
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αλλαγή Μικρογραφίας Πλαισίου Ήχου**

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως πλαίσιο με μια προεπιλεγμένη εικόνα (βλέπε την εικόνα στην παρακάτω ενότητα). Μπορείτε να αλλάξετε την εικόνα προεπισκόπησης του πλαισίου ήχου (ορίστε την προτιμώμενη εικόνα σας).

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε τη μικρογραφία ή την εικόνα προεπισκόπησης ενός πλαισίου ήχου:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέτει ένα πλαίσιο ήχου στη διαφάνεια με καθορισμένη θέση και μέγεθος.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Προσθέτει μια εικόνα στους πόρους της παρουσίασης.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ορίζει την εικόνα για το πλαίσιο ήχου.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Αποθηκεύει την τροποποιημένη παρουσίαση στον δίσκο
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Αλλαγή Επιλογών Αναπαραγωγής Ήχου**

Το Aspose.Slides for Java σας επιτρέπει να αλλάξετε τις επιλογές που ελέγχουν την αναπαραγωγή ήχου ή τις ιδιότητές του. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση ήχου, να ορίσετε την αναπαραγωγή σε βρόχο ή ακόμη και να κρύψετε το εικονίδιο ήχου.

Το τμήμα **Επιλογές ήχου** στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Επιλογές ήχου** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/AudioFrame):

- **Start** η λίστα επιλογών ταιριάζει με τη μέθοδο [AudioFrame.setPlayMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** ταιριάζει με τη μέθοδο [AudioFrame.setVolume](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** ταιριάζει με τη μέθοδο [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** ταιριάζει με τη μέθοδο [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** ταιριάζει με τη μέθοδο [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** ταιριάζει με τη μέθοδο [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

**Επιλογές Επεξεργασίας** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/AudioFrame):

- **Fade In** ταιριάζει με τη μέθοδο [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** ταιριάζει με τη μέθοδο [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Trim Audio Start Time** ταιριάζει με τη μέθοδο [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Trim Audio End Time** η τιμή ισούται με τη διάρκεια του ήχου μείον την τιμή της μεθόδου [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

Ο **Έλεγχος έντασης** του PowerPoint στην περιοχή ελέγχου ήχου αντιστοιχεί στη μέθοδο [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Σας επιτρέπει να αλλάξετε την ένταση ήχου ως ποσοστό.

Αυτή είναι η διαδικασία αλλαγής των επιλογών αναπαραγωγής ήχου:

1. **Δημιουργία** ή λήψη του πλαισίου ήχου.
2. Ορίστε νέες τιμές για τις ιδιότητες του πλαισίου ήχου που θέλετε να προσαρμόσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

Αυτός ο κώδικας Java δείχνει μια λειτουργία στην οποία προσαρμόζονται οι επιλογές ενός ήχου:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Λαμβάνει το σχήμα AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Ορίζει τη λειτουργία αναπαραγωγής να παίζει με κλικ
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Ορίζει την ένταση σε Χαμηλή
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Ορίζει τον ήχο να παίζει σε όλες τις διαφάνειες
    audioFrame.setPlayAcrossSlides(true);

    // Απενεργοποιεί τον βρόχο για τον ήχο
    audioFrame.setPlayLoopMode(false);

    // Κρύβει το AudioFrame κατά τη διάρκεια της παρουσίασης
    audioFrame.setHideAtShowing(true);

    // Επαναφέρει τον ήχο στην αρχή μετά την αναπαραγωγή
    audioFrame.setRewindAudio(true);

    // Αποθηκεύει το αρχείο PowerPoint στον δίσκο
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτό το παράδειγμα Java δείχνει πώς να προσθέσετε ένα νέο πλαίσιο ήχου με ενσωματωμένο ήχο, να το περικόψετε και να ορίσετε τις διάρκειες εξασθένισης:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ορίζει το offset εκκίνησης περικοπής σε 1,5 δευτερόλεπτα
    audioFrame.setTrimFromStart(1500f);
    // Ορίζει το offset λήξης περικοπής σε 2 δευτερόλεπτα
    audioFrame.setTrimFromEnd(2000f);

    // Ορίζει τη διάρκεια εξασθένισης εισόδου σε 200 ms
    audioFrame.setFadeInDuration(200f);
    // Ορίζει τη διάρκεια εξασθένισης εξόδου σε 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ανακτήσετε ένα πλαίσιο ήχου με ενσωματωμένο ήχο και να ορίσετε την ένταση του στο 85 %:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Λαμβάνει το σχήμα πλαισίου ήχου
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Ορίζει την ένταση ήχου στο 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Διαχείριση Υπότιτλων Ήχου**

Το Aspose.Slides σας επιτρέπει να προσθέσετε κλειστά υπότιτλους σε ένα πλαίσιο ήχου μέσω της μεθόδου [getCaptionTracks](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Αυτή η μέθοδος επιστρέφει ένα [ICaptionsCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/), το οποίο σας επιτρέπει να προσθέσετε κομμάτια υπότιτλων WebVTT, να διασχίσετε τα υπάρχοντα κομμάτια και να τα αφαιρέσετε όταν χρειάζεται.

**Προσθήκη Υπότιτλων Ήχου**

Χρησιμοποιήστε τη μέθοδο [getCaptionTracks](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) για να επισυνάψετε ένα ή περισσότερα κομμάτια υπότιτλων σε ένα πλαίσιο ήχου. Στο παρακάτω παράδειγμα, προστίθεται ένα αρχείο ήχου σε μια διαφάνεια και, στη συνέχεια, φορτώνεται ένα νέο κομμάτι υπότιτλου από αρχείο `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Προσθέτει ένα νέο κομμάτι υπότιτλου από αρχείο WebVTT.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Εξαγωγή Υπότιτλων Ήχου**

Μπορείτε να διασχίσετε τα κομμάτια υπότιτλων που συνδέονται με ένα πλαίσιο ήχου και να τα αποθηκεύσετε ως αρχεία `.vtt`. Κάθε κομμάτι υπότιτλου εκθέτει τα δυαδικά του δεδομένα και το μοναδικό του αναγνωριστικό, το οποίο μπορεί να χρησιμοποιηθεί κατά την εξαγωγή των υποτίτλων.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Αποθηκεύει το κομμάτι υπότιτλου ως αρχείο .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Αφαίρεση Υπότιτλων Ήχου**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο ήχου, χρησιμοποιήστε τις μεθόδους που παρέχει το [ICaptionsCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/), όπως [clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), ή [removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/icaptionscollection/#removeAt-int-). Το παρακάτω παράδειγμα αφαιρεί όλα τα κομμάτια υπότιτλων από ένα πλαίσιο ήχου.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Αφαιρεί όλα τα κομμάτια υπότιτλου από το πλαίσιο ήχου.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή Ήχου**

Το Aspose.Slides for Java σας επιτρέπει να εξάγετε τον ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης. Για παράδειγμα, μπορείτε να εξάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Λάβετε αναφορά στη σχετική διαφάνεια μέσω του ευρετηρίου της.
3. Πρόσβαση στις [slideshow transitions](https://reference.aspose.com/slides/el/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) για τη διαφάνεια.
4. Εξαγάγετε τον ήχο σε δεδομένα byte.

Αυτός ο κώδικας Java δείχνει πώς να εξάγετε το ήχο που χρησιμοποιείται σε μια διαφάνεια:

```java
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Προσπελαύνει τη ζητούμενη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Λαμβάνει τα εφέ μετάβασης παρουσίασης για τη διαφάνεια
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Εξάγει τον ήχο σε πίνακα byte
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να επαναχρησιμοποιήσω το ίδιο αρχείο ήχου σε πολλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη **κοινόχρηστη συλλογή ήχου** της παρουσίασης [[audio collection]](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getAudios--) και δημιουργήστε πρόσθετα πλαίσια ήχου που αναφέρονται σε αυτό το υπάρχον στοιχείο. Αυτό αποτρέπει τον διπλασιασμό των δεδομένων πολυμέσων και κρατά το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου χωρίς να δημιουργήσω εκ νέου το σχήμα;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε τη **διαδρομή συνδέσμου** [[link path]](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο **ενσωματωμένου ήχου** [[embedded audio]](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) με ένα άλλο από τη **συλλογή ήχου** της παρουσίασης [[audio collection]](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getAudios--). Η μορφοποίηση του πλαισίου και οι περισσότερες ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Αλλάζει η περικοπή τα υποκείμενα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Η περικοπή προσαρμόζει μόνο τα όρια αναπαραγωγής. Τα αρχικά bytes του ήχου παραμένουν άθικτα και προσβάσιμα μέσω του ενσωματωμένου ήχου ή της συλλογής ήχου της παρουσίασης.