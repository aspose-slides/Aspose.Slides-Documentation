---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Βίντεο στο Android
linktitle: PowerPoint σε Βίντεο
type: docs
weight: 130
url: /el/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε βίντεο με Java. Ανακαλύψτε δείγμα κώδικα και τεχνικές αυτοματοποίησης για να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασης PowerPoint σας σε βίντεο, κερδίζετε 

* **Αύξηση προσβασιμότητας:** Όλες οι συσκευές (ανεξάρτητα από την πλατφόρμα) διαθέτουν προεγκατεστημένους αναπαραγωγείς βίντεο· έτσι οι χρήστες βρίσκουν πιο εύκολο το άνοιγμα ή την αναπαραγωγή βίντεο.
* **Μεγαλύτερη εμβέλεια:** Μέσω βίντεο, μπορείτε να φτάσετε σε ευρύ κοινό και να το στοχεύσετε με πληροφορίες που διαφορετικά μπορεί να φαίνονται βαρετές σε μια παρουσίαση. Οι περισσότερες έρευνες και στατιστικές δείχνουν ότι οι άνθρωποι παρακολουθούν και καταναλώνουν βίντεο περισσότερο από άλλες μορφές περιεχομένου και γενικά προτιμούν τέτοιο περιεχόμενο.

{{% alert color="primary" %}} 

Μπορεί να θέλετε να ελέγξετε τον [**Μετατροπέας PowerPoint σε Βίντεο Online**](https://products.aspose.app/slides/el/conversion/ppt-to-word) επειδή είναι μια ζωντανή και αποτελεσματική υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}} 

## **Μετατροπή PowerPoint σε Βίντεο στο Aspose.Slides**

Το Aspose.Slides υποστηρίζει μετατροπή παρουσίασης σε βίντεο.

* Χρησιμοποιήστε **Aspose.Slides** για να δημιουργήσετε ένα σύνολο καρέ (από τις διαφάνειες της παρουσίασης) που αντιστοιχούν σε συγκεκριμένο FPS (καρέ ανά δευτερόλεπτο)
* Χρησιμοποιήστε εξωτερικό εργαλείο όπως **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) για να δημιουργήσετε βίντεο βασισμένο στα καρέ. 

### **Μετατροπή PowerPoint σε Βίντεο**

1. Προσθέστε αυτό στο αρχείο POM σας:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Κατεβάστε το ffmpeg [εδώ](https://ffmpeg.org/download.html).

4. Εκτελέστε τον κώδικα Java για μετατροπή PowerPoint σε βίντεο.

Αυτός ο κώδικας Java σας δείχνει πώς να μετατρέψετε μια παρουσίαση (που περιέχει ένα σχήμα και δύο εφέ κίνησης) σε βίντεο:

```java
Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και στη συνέχεια το ανιματοποιεί
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

Μπορείτε να εφαρμόσετε κινήσεις σε αντικείμενα των διαφανειών και να χρησιμοποιήσετε μεταβάσεις μεταξύ διαφανειών. 

{{% alert color="primary" %}} 

Μπορεί να θέλετε να δείτε αυτά τα άρθρα: [PowerPoint Animation](https://docs.aspose.com/slides/el/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/el/androidjava/shape-animation/), και [Shape Effect](https://docs.aspose.com/slides/el/androidjava/shape-effect/).

{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες — και κάνουν το ίδιο και τα βίντεο. Ας προσθέσουμε μια ακόμη διαφάνεια και μετάβαση στον κώδικα για την προηγούμενη παρουσίαση:

```java
// Προσθέτει ένα σχήμα χαμόγελου και το ανιματοποιεί

// ...

// Προσθέτει μια νέα διαφάνεια και κινούμενη μετάβαση

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Το Aspose.Slides υποστηρίζει επίσης κίνηση κειμένου. Έτσι ανυψώνουμε παραγράφους σε αντικείμενα, που θα εμφανιστούν μία μετά την άλλη (με καθυστέρηση ενός δευτερολέπτου):

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

Για να εκτελέσετε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationanimationsgenerator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationanimationsgenerator/) σάς επιτρέπει να ορίσετε το μέγεθος καρέ για το βίντεο (που θα δημιουργηθεί αργότερα) μέσω του κατασκευαστή του. Εάν περάσετε μια παρουσίαση, η ιδιότητα `Presentation.SlideSize` θα χρησιμοποιηθεί και δημιουργεί κινήσεις που χρησιμοποιεί το [PresentationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationplayer/).

Όταν παράγονται κινήσεις, ένα γεγονός `NewAnimation` δημιουργείται για κάθε επόμενη κίνηση, το οποίο διαθέτει την παράμετρο [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationanimationplayer/). Η τελευταία είναι μια κλάση που αντιπροσωπεύει έναν παίκτη για μια ξεχωριστή κίνηση.

Για εργασία με το [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationanimationplayer/), χρησιμοποιείται η ιδιότητα [Duration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (η συνολική διάρκεια της κίνησης) και η μέθοδος [SetTimePosition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Κάθε θέση κίνησης ορίζεται εντός του εύρους *0 έως duration* και στη συνέχεια η μέθοδος `GetFrame` επιστρέφει ένα BufferedImage που αντιστοιχεί στην κατάσταση της κίνησης εκείνη τη στιγμή:

```java
Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και το ανιματοποιεί
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
                // bitmap αρχικής κατάστασης κίνησης
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

Για να αναπαραχθούν όλες οι κινήσεις μιας παρουσίασης ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationplayer/). Αυτή η κλάση λαμβάνει μια παρουσίαση [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationanimationsgenerator/) και FPS για τα εφέ στον κατασκευαστή της, και έπειτα καλεί το γεγονός `FrameTick` για όλες τις κινήσεις ώστε να παιχτούν:

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

Έπειτα τα παραγόμενα καρέ μπορούν να συναχθούν για να παραχθεί ένα βίντεο. Δείτε την ενότητα [Convert PowerPoint to Video](https://docs.aspose.com/slides/el/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Υποστηριζόμενες Κινήσεις και Εφέ**

**Είσοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Έμφαση**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Έξοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Διαδρομές Κίνησης**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Συχνές Ερωτήσεις**

**Μπορεί να γίνει μετατροπή παρουσιάσεων με προστασία κωδικού;**

Ναι, το Aspose.Slides επιτρέπει εργασία με [παρουσιάσεις με προστασία κωδικού](/slides/el/androidjava/password-protected-presentation/). Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε τον σωστό κωδικό ώστε η βιβλιοθήκη να μπορεί να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

**Υποστηρίζει το Aspose.Slides χρήση σε λύσεις cloud;**

Ναι, το Aspose.Slides μπορεί να ενσωματωθεί σε εφαρμογές και υπηρεσίες cloud. Η βιβλιοθήκη έχει σχεδιαστεί για να λειτουργεί σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και δυνατότητα κλιμάκωσης για μαζική επεξεργασία αρχείων.

**Υπάρχουν περιορισμοί μεγέθους για παρουσιάσεις κατά τη μετατροπή;**

Το Aspose.Slides μπορεί να χειριστεί παρουσιάσεις σχεδόν οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, ενδέχεται να απαιτούνται επιπλέον πόροι συστήματος και μερικές φορές συνιστάται η βελτιστοποίηση της παρουσίασης για βελτίωση της απόδοσης.