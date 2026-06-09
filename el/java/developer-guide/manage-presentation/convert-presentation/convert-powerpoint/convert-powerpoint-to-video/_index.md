---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Βίντεο με Java
linktitle: PowerPoint σε Βίντεο
type: docs
weight: 130
url: /el/java/convert-powerpoint-to-video/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε βίντεο
- παρουσίαση σε βίντεο
- PPT σε βίντεο
- PPTX σε βίντεο
- PowerPoint σε MP4
- παρουσίαση σε MP4
- PPT σε MP4
- PPTX σε MP4
- αποθήκευση PPT ως MP4
- αποθήκευση PPTX ως MP4
- εξαγωγή PPT σε MP4
- εξαγωγή PPTX σε MP4
- μετατροπή βίντεο
- PowerPoint
- Java
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε βίντεο με Java. Ανακαλύψτε παραδείγματα κώδικα και τεχνικές αυτοματοποίησης για να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Με την μετατροπή της παρουσίασής σας PowerPoint ή OpenDocument σε βίντεο, κερδίζετε:

**Αυξημένη προσβασιμότητα:** Όλες οι συσκευές, ανεξαρτήτως πλατφόρμας, διαθέτουν από προεπιλογή προγράμματα αναπαραγωγής βίντεο, καθιστώντας ευκολότερο για τους χρήστες το άνοιγμα ή την αναπαραγωγή βίντεο σε σχέση με τις παραδοσιακές εφαρμογές παρουσίασης.

**Περισσότερο εύρος:** Τα βίντεο σας επιτρέπουν να προσεγγίσετε μεγαλύτερο κοινό και να παρουσιάσετε πληροφορίες με πιο ελκυστική μορφή. Έρευνες και στατιστικά δείχνουν ότι οι άνθρωποι προτιμούν να βλέπουν και να καταναλώνουν περιεχόμενο βίντεο έναντι άλλων μορφών, κάνοντας το μήνυμά σας πιο επιδραστικό.

{{% alert color="primary" %}} 

Μπορείτε να ελέγξετε τον [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/el/conversion/ppt-to-word) επειδή είναι μια ζωντανή και αποτελεσματική υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}} 

## **Μετατροπή PowerPoint σε Βίντεο στο Aspose.Slides**

Στο [Aspose.Slides 22.11](https://docs.aspose.com/slides/el/java/aspose-slides-for-java-22-11-release-notes/), υλοποιήσαμε υποστήριξη για μετατροπή παρουσίασης σε βίντεο. 

* Χρησιμοποιήστε **Aspose.Slides** για να δημιουργήσετε ένα σύνολο καρέ (από τις διαφάνειες της παρουσίασης) που αντιστοιχούν σε συγκεκριμένα FPS (καρέ ανά δευτερόλεπτο)
* Χρησιμοποιήστε ένα εξωτερικό εργαλείο όπως το **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) για να δημιουργήσετε ένα βίντεο βάσει των καρέ. 

### **Μετατρέψτε το PowerPoint σε Βίντεο**

1. Προσθέστε αυτό στο αρχείο POM σας:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Κατεβάστε το ffmpeg [here](https://ffmpeg.org/download.html).

4. Εκτελέστε τον κώδικα Java για μετατροπή PowerPoint σε βίντεο.

Αυτός ο κώδικας Java σας δείχνει πώς να μετατρέψετε μια παρουσίαση (που περιέχει ένα σχήμα και δύο εφέ κίνησης) σε βίντεο:
```java
Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελο και στη συνέχεια το ανιμαρίζει
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Διαμορφώστε το φάκελο των εκτελέσιμων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Εφέ Βίντεο**

Μπορείτε να εφαρμόσετε κινήσεις σε αντικείμενα στις διαφάνειες και να χρησιμοποιήσετε μεταβάσεις μεταξύ των διαφανειών. 

{{% alert color="primary" %}} 

Μπορείτε να δείτε αυτά τα άρθρα: [PowerPoint Animation](https://docs.aspose.com/slides/el/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/el/java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/el/java/shape-effect/).

{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες—και το ίδιο συμβαίνει με τα βίντεο. Ας προσθέσουμε μια ακόμη διαφάνεια και μετάβαση στον κώδικα για την προηγούμενη παρουσίαση:
```java
// Προσθέτει ένα σχήμα χαμόγελου και το ανιμαρίζει

// ...

// Προσθέτει μια νέα διαφάνεια και κινούμενη μετάβαση

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Το Aspose.Slides υποστηρίζει επίσης κίνηση για κείμενα. Έτσι κινούμε παραγράφους σε αντικείμενα, οι οποίες θα εμφανιστούν η μία μετά την άλλη (με καθυστέρηση ενός δευτερολέπτου):
```java
Presentation presentation = new Presentation();
try {
    // Προσθέτει κείμενο και κινήσεις
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Διαμορφώστε το φάκελο των εκτελέσιμων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Κλάσεις Μετατροπής Βίντεο**

Για να σας επιτρέψει να εκτελείτε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationanimationsgenerator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator] σας επιτρέπει να ορίσετε το μέγεθος του καρέ για το βίντεο (που θα δημιουργηθεί αργότερα) μέσω του κατασκευαστή του. Εάν περάσετε ένα στιγμιότυπο της παρουσίασης, θα χρησιμοποιηθεί `Presentation.SlideSize` και παράγει κινήσεις που χρησιμοποιεί το [PresentationPlayer].

Όταν δημιουργούνται κινήσεις, δημιουργείται ένα γεγονός `NewAnimation` για κάθε επόμενη κίνηση, που έχει την παράμετρο [IPresentationAnimationPlayer]. Το τελευταίο είναι μια κλάση που αντιπροσωπεύει έναν player για ξεχωριστή κίνηση.

Για να εργαστείτε με το [IPresentationAnimationPlayer], χρησιμοποιούνται η ιδιότητα [Duration] (η συνολική διάρκεια της κίνησης) και η μέθοδος [SetTimePosition]. Κάθε θέση κίνησης ορίζεται εντός του εύρους *0 έως διάρκεια*, και στη συνέχεια η μέθοδος `GetFrame` επιστρέφει ένα BufferedImage που αντιστοιχεί στην κατάσταση της κίνησης εκείνη τη στιγμή:
```java
Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και το ανιμαρίζει
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // αρχική κατάσταση κίνησης
            try {
                // αρχική bitmap κατάσταση κίνησης
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // τελική κατάσταση της κίνησης
            try {
                // τελευταίο πλαίσιο της κίνησης
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Για να κάνετε όλες τις κινήσεις σε μια παρουσίαση να παίζουν ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer]. Αυτή η κλάση λαμβάνει ένα στιγμιότυπο του [PresentationAnimationsGenerator] και FPS για τα εφέ στον κατασκευαστή της και στη συνέχεια καλεί το γεγονός `FrameTick` για όλες τις κινήσεις ώστε να τις παίξει:
```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Στη συνέχεια τα παραγόμενα καρέ μπορούν να συνταχθούν για την παραγωγή βίντεο. Δείτε την ενότητα [Convert PowerPoint to Video](https://docs.aspose.com/slides/el/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Υποστηριζόμενες Κινήσεις και Εφέ**

**Εισαγωγή**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εμφάνιση** | ![not supported](x.png) | ![supported](v.png) |
| **Σβήσιμο** | ![supported](v.png) | ![supported](v.png) |
| **Πτήση Εσωτερική** | ![supported](v.png) | ![supported](v.png) |
| **Αιώρηση Εσωτερική** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Σκούπισμα** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![supported](v.png) | ![supported](v.png) |
| **Τροχός** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίες Μπάρες** | ![supported](v.png) | ![supported](v.png) |
| **Ανάπτυξη & Περιστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αναπήδηση** | ![supported](v.png) | ![supported](v.png) |

**Έμφαση**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Παλμός** | ![not supported](x.png) | ![supported](v.png) |
| **Παλμός Χρώματος** | ![not supported](x.png) | ![supported](v.png) |
| **Κουνιστό** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Ανάπτυξη/Σμίκρυνση** | ![not supported](x.png) | ![supported](v.png) |
| **Αφυσωμάτωση** | ![not supported](x.png) | ![supported](v.png) |
| **Σκοτείνιασμα** | ![not supported](x.png) | ![supported](v.png) |
| **Φωτεινότητα** | ![not supported](x.png) | ![supported](v.png) |
| **Διαφάνεια** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Αντικειμένου** | ![not supported](x.png) | ![supported](v.png) |
| **Συμπληρωματικό Χρώμα** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Γραμμής** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Γέμισης** | ![not supported](x.png) | ![supported](v.png) |

**Εξοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εξαφάνιση** | ![not supported](x.png) | ![supported](v.png) |
| **Σβήσιμο** | ![supported](v.png) | ![supported](v.png) |
| **Πτήση Εξωτερική** | ![supported](v.png) | ![supported](v.png) |
| **Αιώρηση Εξωτερική** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Σκούπισμα** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίες Μπάρες** | ![supported](v.png) | ![supported](v.png) |
| **Σμίκρυνση & Περιστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αναπήδηση** | ![supported](v.png) | ![supported](v.png) |

**Διαδρομές Κίνησης**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Τόξα** | ![supported](v.png) | ![supported](v.png) |
| **Στροφές** | ![supported](v.png) | ![supported](v.png) |
| **Σχήματα** | ![supported](v.png) | ![supported](v.png) |
| **Βρόχοι** | ![supported](v.png) | ![supported](v.png) |
| **Προσαρμοσμένη Διαδρομή** | ![supported](v.png) | ![supported](v.png) |

## **Συχνές ερωτήσεις**

**Μπορεί να γίνει μετατροπή παρουσιάσεων που προστατεύονται με κωδικό;**

Ναι, το Aspose.Slides επιτρέπει την εργασία με [παρουσιάσεις με κωδικό πρόσβασης](/slides/el/java/password-protected-presentation/). Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε τον σωστό κωδικό πρόσβασης ώστε η βιβλιοθήκη να μπορεί να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

**Υποστηρίζει το Aspose.Slides τη χρήση σε λύσεις cloud;**

Ναι, το Aspose.Slides μπορεί να ενσωματωθεί σε εφαρμογές και υπηρεσίες cloud. Η βιβλιοθήκη έχει σχεδιαστεί για να λειτουργεί σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και κλιμάκωση για επεξεργασία μεγάλου αριθμού αρχείων.

**Υπάρχουν περιορισμοί μεγέθους για τις παρουσιάσεις κατά τη μετατροπή;**

Το Aspose.Slides μπορεί να διαχειριστεί παρουσιάσεις σχεδόν οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, μπορεί να απαιτηθούν επιπλέον πόροι συστήματος, και μερικές φορές συνιστάται η βελτιστοποίηση της παρουσίασης για βελτίωση της απόδοσης.