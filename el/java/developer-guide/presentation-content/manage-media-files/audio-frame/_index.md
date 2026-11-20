---
title: Διαχείριση πλαισίων ήχου σε παρουσιάσεις χρησιμοποιώντας Java
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
description: "Ενσωματώστε ήχο στις διαφάνειες, αλλάξτε το εικονίδιο ήχου, διαμορφώστε την αναπαραγωγή, διαχειριστείτε υπότιτλους WebVTT και εξάγετε ήχους μετάβασης διαφάνειας με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Ένα πλαίσιο ήχου σάς επιτρέπει να αναπαράγετε έναν ήχο σε μια διαφάνεια. Με το Aspose.Slides for Java, μπορείτε να ενσωματώσετε ένα αποσπασματικό ήχο, να επιλέξετε την εικόνα που το αντιπροσωπεύει, να ρυθμίσετε την αναπαραγωγή και να προσθέσετε υπότιτλους. Μπορείτε επίσης να ανακτήσετε έναν ήχο που έχει οριστεί για μια μετάβαση διαφάνειας.

## **Δημιουργία Πλαισίων Ήχου**

Χρησιμοποιήστε [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) για να ενσωματώσετε ένα τοπικό αποσπάσμα ήχου στην πρώτη διαφάνεια. Οι δύο πρώτες συντεταγμένες τοποθετούν το πλαίσιο στη διαφάνεια, και οι επόμενες δύο τιμές ορίζουν το πλάτος και το ύψος του, όλα σε σημεία. Αυτό το παράδειγμα καλεί το [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) για να ξεκινήσει το αποσπάσμα αυτόματα και καλεί το [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) για να επιλέξει την υψηλή προεπιλογή έντασης.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Αλλαγή Μικρογραφίας Πλαισίου Ήχου**

Από προεπιλογή, ένα πλαίσιο ήχου εμφανίζει ένα εικονίδιο ηχείου. Για να εμφανίσετε μια προσαρμοσμένη μικρογραφία, προσθέστε μια εικόνα στην παρουσία με το [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) και ορίστε την στην εικόνα του πλαισίου με το [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). Το παράδειγμα χρησιμοποιεί ένα JPEG ως μικρογραφία για ένα ενσωματωμένο αποσπάσμα ήχου.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Αλλαγή Επιλογών Αναπαραγωγής Ήχου**

Ο ελεγκτής **Audio Options** του PowerPoint καθορίζει πότε ξεκινά ένα αποσπάσμα, πόσο δυνατά ακούγεται και πώς συμπεριφέρεται κατά τη διάρκεια μιας παρουσίασης.

![Έλεγχοι Audio Options του PowerPoint για ένα πλαίσιο ήχου](audio_frame_0.png)

| Έλεγχος PowerPoint | Μέθοδος Aspose.Slides for Java |
| --- | --- |
| Έναρξη | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Προεπιλογή έντασης | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Αναπαραγωγή σε όλες τις διαφάνειες | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Βρόχος μέχρι τη διακοπή | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Απόκρυψη κατά την παρουσίαση | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Επιστροφή μετά την αναπαραγωγή | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Ομαλή εισαγωγή | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Ομαλή εξαγωγή | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Περικοπή χρόνου έναρξης ήχου | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Περικοπή χρόνου λήξης ήχου | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Ρυθμιστής έντασης | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Το παράδειγμα εντοπίζει το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια, καλεί το [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) για να ξεκινήσει η αναπαραγωγή με κλικ, και επιλέγει τη χαμηλή προεπιλογή έντασης. Το αποσπάσμα συνεχίζει σε όλες τις διαφάνειες με απενεργοποιημένο το βρόχο. Το εικονίδιο παραμένει κρυφό κατά την παρουσίαση, και το αποσπάσμα επιστρέφει στην αρχή μετά την αναπαραγωγή.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Για ένα αποσπάσμα μεγαλύτερο από 3,5 δευτερόλεπτα, αυτό το παράδειγμα παραλείπει τα πρώτα 1,5 δευτερόλεπτα και τα τελευταία 2 δευτερόλεπτα. Το [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) δέχεται τη διάρκεια που πρέπει να παραλειφθεί από το τέλος του αποσπάσματος. Για να λάβετε το χρόνο λήξης που εμφανίζεται στο PowerPoint, αφαιρέστε αυτήν την απόσπαση από τη συνολική διάρκεια του αποσπάσματος. Το περικομμένο αποσπάσμα εισέρχεται ομαλά σε 200 χιλιοστά του δευτερολέπτου και εξέρχεται ομαλά σε 500 χιλιοστά του δευτερολέπτου. Όλες οι τέσσερις μέθοδοι δέχονται τιμές σε χιλιοστά του δευτερολέπτου.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να ορίσετε την ένταση αναπαραγωγής σε ένα συγκεκριμένο ποσοστό, χρησιμοποιήστε το [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Αυτό το παράδειγμα ορίζει το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια στο 85%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```
## **Διαχείριση Υπότιτλων Ήχου**

Κάθε πλαίσιο ήχου παρέχει πρόσβαση στις γραμμές υποτίτλων του μέσω του [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Χρησιμοποιήστε τη συλλογή για να συνδέσετε υπότιτλους WebVTT στο αποσπάσμα, να εξάγετε υπάρχουσες γραμμές ή να τις αφαιρέσετε.

### **Προσθήκη Υπότιτλων Ήχου**

Το παράδειγμα ενσωματώνει ένα αποσπάσμα ήχου στην πρώτη διαφάνεια και χρησιμοποιεί το [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) για να συνδέσει μια τοπική γραμμή WebVTT. Το πρώτο όρισμα παρέχει την ετικέτα της γραμμής, και το δεύτερο καθορίζει το αρχείο που περιέχει τους χρονοσχετικούς υπότιτλους.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Εξαγωγή Υπότιτλων Ήχου**

Αυτό το παράδειγμα εξάγει κάθε γραμμή υπότιτλων που είναι συνδεδεμένη με ένα πλαίσιο ήχου στην πρώτη διαφάνεια. Γράφει τα byte που επιστρέφει το [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) σε ένα αρχείο WebVTT και χρησιμοποιεί το αναγνωριστικό που επιστρέφει το [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) ως όνομα αρχείου ώστε κάθε γραμμή να έχει ξεχωριστό αποτέλεσμα.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```
### **Αφαίρεση Υπότιτλων Ήχου**

Χρησιμοποιήστε το [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ή το [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) για να διαγράψετε μια μεμονωμένη γραμμή. Το παράδειγμα χρησιμοποιεί το [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) για να αφαιρέσει όλους τους υπότιτλους από το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια διατηρώντας το αποσπάσμα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```
### **Εύρεση Γραμμής σε Υπότιτλους Ήχου**

Για να βρείτε μια γραμμή στους υπότιτλους ήχου στην πρώτη διαφάνεια, αναζητήστε το κείμενο που επιστρέφει το [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) στη μνήμη. Σε μια απλή κειμενική ένδειξη WebVTT, η γραμμή χρόνου περιέχει `-->`, οι γραμμές υποτίτλων ακολουθούν την, και μια κενή γραμμή τερματίζει την ένδειξη. Αυτό το παράδειγμα εκτυπώνει την ετικέτα της γραμμής και κάθε γραμμή υπότιτλου που περιέχει το “café”.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\R")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```
## **Εξαγωγή Ήχου**

Μια μετάβαση διαφάνειας μπορεί να έχει το δικό της ήχο. Για να το ανακτήσετε, καλέστε το [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) στη μετάβαση διαφάνειας. Το παράδειγμα προσπελαύνει τα byte που επιστρέφει το [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) και εκτυπώνει τον αριθμό των byte. Εάν η πρώτη διαφάνεια δεν έχει ήχο μετάβασης, εκτυπώνει ένα μήνυμα αντί αυτού.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```
## **Συχνές Ερωτήσεις**

**Μπορώ να επαναχρησιμοποιήσω το ίδιο αποσπάσμα ήχου σε πολλές διαφάνειες χωρίς να το αντιγράψω;**

Ναι. Προσθέστε το αποσπάσμα μία φορά στη [συλλογή ήχου](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) της παρουσίασης και περάστε το ίδιο αντικείμενο ήχου στο [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) για κάθε διαφάνεια.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου;**

Ναι. Για έναν συνδεδεμένο ήχο, χρησιμοποιήστε το [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) για να δείξετε στο αρχείο αντικατάστασης. Για έναν ενσωματωμένο ήχο, επιλέξτε ένα άλλο αποσπάσμα από τη [συλλογή ήχου] της παρουσίασης με το [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Και οι δύο προσεγγίσεις διατηρούν το υπάρχον πλαίσιο.

**Η περικοπή αλλάζει τα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Τα [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) και [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) ορίζουν τα όρια της αναπαραγωγής. Μπορείτε ακόμη να ανακτήσετε το πλήρες αποσπάσμα μέσω του [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).