---
title: Διαχείριση ήχου σε παρουσιάσεις σε Android
linktitle: Πλαίσιο ήχου
type: docs
weight: 10
url: /el/androidjava/audio-frame/
keywords:
- ήχος
- πλαίσιο ήχου
- μικρογραφία
- προσθήκη ήχου
- ιδιότητες ήχου
- επιλογές ήχου
- εξαγωγή ήχου
- Android
- Java
- Aspose.Slides
description: "Δημιουργία και έλεγχος πλαισίων ήχου στο Aspose.Slides για Android—παραδείγματα Java για ενσωμάτωση, περικοπή, επανάληψη και διαμόρφωση της αναπαραγωγής σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με πλαίσια ήχου στο Aspose.Slides. Δείχνει πώς να προσθέσετε ενσωματωμένο ήχο σε διαφάνειες, να προσαρμόσετε τη μικρογραφία του πλαισίου ήχου, να διαμορφώσετε τις επιλογές αναπαραγωγής όπως η ένταση, η επανάληψη, η απόκρυψη, η περικοπή και οι διάρκειες εξασθένισης, καθώς και να εξάγετε τον ήχο που χρησιμοποιείται στις μεταβάσεις παρουσίασης.

## **Δημιουργία Πλαισίων Ήχου**
Aspose.Slides για Android μέσω Java επιτρέπει την προσθήκη αρχείων ήχου σε διαφάνειες. Τα αρχεία ήχου ενσωματώνονται σε διαφάνειες ως πλαίσια ήχου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Φορτώστε τη ροή αρχείου ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο πλαίσιο ήχου (που περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Ορίστε το [PlayMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AudioPlayModePreset) και το `Volume` που εκτίθενται από το αντικείμενο [IAudioFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAudioFrame).
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

    // Προσθέτει το Πλαίσιο Ήχου
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Ορίζει τη Λειτουργία Αναπαραγωγής και την Ένταση του Ήχου
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Γράφει το αρχείο PowerPoint στον δίσκο
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αλλαγή της Μικρογραφίας του Πλαισίου Ήχου**

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως πλαίσιο με μια τυπική προεπιλεγμένη εικόνα (δείτε την εικόνα στην ενότητα παρακάτω). Μπορείτε να αλλάξετε την εικόνα προεπισκόπησης του πλαισίου ήχου (ορίστε την προτιμώμενη εικόνα σας).

Αυτός ο κώδικας Java σας δείχνει πώς να αλλάξετε τη μικρογραφία ή την εικόνα προεπισκόπησης ενός πλαισίου ήχου:

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

Aspose.Slides για Android μέσω Java επιτρέπει την αλλαγή επιλογών που ελέγχουν την αναπαραγωγή ή τις ιδιότητες ενός ήχου. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση του ήχου, να ορίσετε τον ήχο να παίζει σε βρόχο, ή ακόμη και να κρύψετε το εικονίδιο ήχου.

Το παράθυρο **Audio Options** στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Οι **Audio Options** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AudioFrame) :

- **Start** η λίστα πτυσσόμενων επιλογών ταιριάζει με την ιδιότητα [AudioFrame.PlayMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** ταιριάζει με την ιδιότητα [AudioFrame.Volume](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** ταιριάζει με την ιδιότητα [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** ταιριάζει με την ιδιότητα [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** ταιριάζει με την ιδιότητα [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** ταιριάζει με την ιδιότητα [AudioFrame.RewindAudio](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

Οι επιλογές **Editing** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/audioframe/) :

- **Fade In** ταιριάζει με την ιδιότητα [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** ταιριάζει με την ιδιότητα [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** ταιριάζει με την ιδιότητα [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** η τιμή ισούται με τη διάρκεια του ήχου μειωμένη κατά την τιμή της ιδιότητας [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

Ο **ρυθμιστής Έντασης** στο πάνελ ελέγχου ήχου του PowerPoint αντιστοιχεί στην ιδιότητα [AudioFrame.VolumeValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . Σας επιτρέπει να αλλάξετε την ένταση του ήχου ως ποσοστό.

Αυτή είναι η διαδικασία αλλαγής των επιλογών Αναπαραγωγής Ήχου:

1. [Δημιουργία](#create-audio-frame) ή λήψη του Πλαισίου Ήχου.
2. Ορίστε νέες τιμές για τις ιδιότητες του Πλαισίου Ήχου που θέλετε να ρυθμίσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

Αυτός ο κώδικας Java δείχνει μια λειτουργία στην οποία προσαρμόζονται οι επιλογές ενός ήχου:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Λαμβάνει το σχήμα AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Ορίζει τη λειτουργία αναπαραγωγής για αναπαραγωγή στο κλικ
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Ορίζει την ένταση σε Χαμηλό
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Ορίζει τον ήχο να παίζει σε όλες τις διαφάνειες
    audioFrame.setPlayAcrossSlides(true);

    // Απενεργοποιεί την επανάληψη για τον ήχο
    audioFrame.setPlayLoopMode(false);

    // Κρύβει το AudioFrame κατά τη διάρκεια της παρουσίασης
    audioFrame.setHideAtShowing(true);

    // Επαναχέρνει τον ήχο στην αρχή μετά την αναπαραγωγή
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
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ορίζει την εκκίνηση της περικοπής στα 1,5 δευτερόλεπτα
    // Ορίζει το τέλος της περικοπής στα 2 δευτερόλεπτα
    // Ορίζει τη διάρκεια εξασθένισης εισόδου στα 200 ms
    // Ορίζει τη διάρκεια εξασθένισης εξόδου στα 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ανακτήσετε ένα πλαίσιο ήχου με ενσωματωμένο ήχο και να ορίσετε την ένταση του στο 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Λαμβάνει ένα σχήμα πλαισίου ήχου
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Ορίζει την ένταση του ήχου στο 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Διαχείριση Υπότιτλων Ήχου**

Το Aspose.Slides επιτρέπει την προσθήκη κλειστών υποτίτλων σε ένα πλαίσιο ήχου μέσω της μεθόδου [getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) . Αυτή η μέθοδος επιστρέφει ένα [ICaptionsCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/) , το οποίο σας επιτρέπει να προσθέσετε διαδρομές υποτίτλων WebVTT, να διατρέξετε τις υπάρχουσες διαδρομές και να τις αφαιρέσετε όταν χρειάζεται.

**Προσθήκη Υπότιτλων Ήχου**

Χρησιμοποιήστε τη μέθοδο [getCaptionTracks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) για να συνδέσετε μία ή περισσότερες διαδρομές υποτίτλων σε ένα πλαίσιο ήχου. Στο παρακάτω παράδειγμα, ένα αρχείο ήχου προστίθεται σε μια διαφάνεια και έπειτα φορτώνεται μια νέα διαδρομή υποτίτλων από ένα αρχείο `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Προσθήκη νέας διαδρομής υπότιτλου από αρχείο WebVTT.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Εξαγωγή Υπότιτλων Ήχου**

Μπορείτε να διατρέξετε τις διαδρομές υποτίτλων που συνδέονται με ένα πλαίσιο ήχου και να τις αποθηκεύσετε ως αρχεία `.vtt`. Κάθε διαδρομή υποτίτλων εκθέτει τα δυαδικά της δεδομένα και το μοναδικό της αναγνωριστικό, το οποίο μπορεί να χρησιμοποιηθεί κατά την εξαγωγή των υποτίτλων.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Αποθήκευση της διαδρομής υπότιτλου ως αρχείο .vtt.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**Αφαίρεση Υπότιτλων Ήχου**

Για να αφαιρέσετε υποτίτλους από ένα πλαίσιο ήχου, χρησιμοποιήστε τις μεθόδους που παρέχονται από το [ICaptionsCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/) , όπως [clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#clear--) , [remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) , ή [removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int--) . Το παρακάτω παράδειγμα αφαιρεί όλες τις διαδρομές υποτίτλων από ένα πλαίσιο ήχου.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Αφαίρεση όλων των διαδρομών υποτίτλων από το πλαίσιο ήχου.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή Ήχου**

Το Aspose.Slides για Android μέσω Java επιτρέπει την εξαγωγή του ήχου που χρησιμοποιείται στις μεταβάσεις παρουσίασης. Για παράδειγμα, μπορείτε να εξάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Αποκτήστε την αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Πρόσβαση στις [slideshow transitions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) για τη διαφάνεια.
4. Εξαγάγετε τον ήχο σε δεδομένα byte.

Αυτός ο κώδικας Java σας δείχνει πώς να εξάγετε τον ήχο που χρησιμοποιείται σε μια διαφάνεια:

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

## **FAQ**

**Μπορώ να χρησιμοποιήσω ξανά το ίδιο αρχείο ήχου σε πολλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη κοινόχρηστη [audio collection] της παρουσίασης και δημιουργήστε πρόσθετα πλαίσια ήχου που αναφέρονται σε αυτό το υπάρχον στοιχείο. Αυτό αποτρέπει την αντιγραφή των δεδομένων πολυμέσων και κρατά το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου χωρίς να ξαναδημιουργήσω το σχήμα;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε τη [link path] ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο [embedded audio] με κάποιο άλλο από τη [audio collection] της παρουσίασης. Η μορφοποίηση του πλαισίου και οι περισσότερες ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Η περικοπή αλλάζει τα υποκείμενα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Η περικοπή ρυθμίζει μόνο τα όρια αναπαραγωγής. Τα αρχικά bytes του ήχου παραμένουν αμετάβλητα και είναι προσβάσιμα μέσω του ενσωματωμένου ήχου ή της [audio collection] της παρουσίασης.