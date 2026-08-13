---
title: "Μετατροπή παρουσιάσεων PowerPoint σε βίντεο με Java"
linktitle: "PowerPoint σε βίντεο"
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
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε βίντεο με Java. Ανακαλύψτε δείγματα κώδικα και τεχνίκες αυτοματοποίησης για να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασής σας PowerPoint ή OpenDocument σε βίντεο, κερδίζετε:

**Αυξημένη προσβασιμότητα:** Όλες οι συσκευές, ανεξάρτητα από την πλατφόρμα, διαθέτουν προεγκατεστημένους αναπαραγωγείς βίντεο, καθιστώντας ευκολότερο για τους χρήστες το άνοιγμα ή την αναπαραγωγή βίντεο σε σχέση με τις παραδοσιακές εφαρμογές παρουσίασης.

**Μεγαλύτερο κοινό:** Τα βίντεο σας επιτρέπουν να φτάσετε σε μεγαλύτερο κοινό και να παρουσιάσετε πληροφορίες με πιο ελκυστικό τρόπο. Έρευνες και στατιστικά δείχνουν ότι οι άνθρωποι προτιμούν να παρακολουθούν και να καταναλώνουν περιεχόμενο βίντεο αντί για άλλες μορφές, καθιστώντας το μήνυμά σας πιο ισχυρό.

{{% alert color="info" %}} 
Μπορεί να θέλετε να ελέγξετε τον [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/el/video) επειδή αποτελεί μια ζωντανή και αποτελεσματική υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}} 

## **Μετατροπή PowerPoint σε Βίντεο με Aspose.Slides**

Στην [Aspose.Slides 22.11](https://docs.aspose.com/slides/el/java/aspose-slides-for-java-22-11-release-notes/), υλοποιήσαμε υποστήριξη για τη μετατροπή παρουσίασης σε βίντεο. 

* Χρησιμοποιήστε **Aspose.Slides** για τη δημιουργία ενός συνόλου καρέ (από τις διαφάνειες παρουσίασης) που αντιστοιχούν σε συγκεκριμένο FPS (καρέ ανά δευτερόλεπτο)
* Χρησιμοποιήστε ένα εργαλείο τρίτου μέρους όπως το **ffmpeg** ([για java](https://github.com/bramp/ffmpeg-cli-wrapper)) για τη δημιουργία βίντεο με βάση τα καρέ. 

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
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και στη συνέχεια το ανιματρίζει
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

    // Ρυθμίστε το φάκελο των δυαδικών του ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
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

Μπορείτε να εφαρμόσετε κινήσεις σε αντικείμενα στις διαφάνειες και να χρησιμοποιήσετε μεταβάσεις μεταξύ τους. 

{{% alert color="info" %}} 
Μπορεί να θέλετε να δείτε αυτά τα άρθρα: [PowerPoint Animation](https://docs.aspose.com/slides/el/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/el/java/shape-animation/), και [Shape Effect](https://docs.aspose.com/slides/el/java/shape-effect/).
{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες—και το ίδιο ισχύει για τα βίντεο. Ας προσθέσουμε μια ακόμη διαφάνεια και μεταβάση στον κώδικα της προηγούμενης παρουσίασης:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και το ανιματρίζει

    // ...

    // Προσθέτει μια νέα διαφάνεια και ανιματισμένη μετάβαση

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Το Aspose.Slides υποστηρίζει επίσης κίνηση κειμένου. Έτσι, κινουμε παραγράφους σε αντικείμενα, που θα εμφανίζονται η μία μετά την άλλη (με καθυστέρηση ενός δευτερολέπτο):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // Ρυθμίστε το φάκελο των δυαδικών του ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
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

Για να μπορείτε να εκτελείτε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationanimationsgenerator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationanimationsgenerator/) σας επιτρέπει να ορίσετε το μέγεθος καρέ για το βίντεο (που θα δημιουργηθεί αργότερα) μέσω του κατασκευαστή του. Αν περάσετε μια παρουσίαση, θα χρησιμοποιηθεί το `Presentation.SlideSize` και θα παραχθούν κινήσεις που χρησιμοποιεί το [PresentationPlayer](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationplayer/). 

Όταν δημιουργούνται κινήσεις, παράγεται ένα συμβάν `NewAnimation` για κάθε επόμενη κίνηση, το οποίο έχει την παράμετρο [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationanimationplayer/). Η τελευταία είναι μια κλάση που αντιπροσωπεύει έναν αναπαραγωγέα για μια ξεχωριστή κίνηση.

Για εργασία με το [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationanimationplayer/), χρησιμοποιούνται η ιδιότητα [Duration](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (η συνολική διάρκεια της κίνησης) και η μέθοδος [SetTimePosition](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Κάθε θέση κίνησης ορίζεται εντός του εύρους *0 έως duration*, και τότε η μέθοδος `getFrame` θα επιστρέψει ένα [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) που αντιστοιχεί στην κατάσταση της κίνησης εκείνη τη στιγμή:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και το ανιματρίζει
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
            // bitmap αρχικής κατάστασης κίνησης
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // τελική κατάσταση της κίνησης
            // τελευταίο καρέ της κίνησης
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // δημιουργεί τις κινήσεις - αυτό είναι που ενεργοποιεί τα παραπάνω γεγονότα
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Για να αναπαραχθούν όλες οι κινήσεις σε μια παρουσίαση ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationplayer/). Αυτή η κλάση δέχεται μια παρουσίαση [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationanimationsgenerator/) και FPS για τα εφέ στον κατασκευαστή της και, στη συνέχεια, καλεί το συμβάν `FrameTick` για όλες τις κινήσεις ώστε να παιχθούν:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

Στη συνέχεια τα παραγόμενα καρέ μπορούν να συντεθούν για τη δημιουργία βίντεο. Δείτε την ενότητα [Convert PowerPoint to Video](https://docs.aspose.com/slides/el/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

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

### Είναι δυνατόν να μετατρέψετε παρουσιάσεις που είναι προστατευμένες με κωδικό;

Ναι, το Aspose.Slides επιτρέπει εργασία με [παρουσιάσεις προστατευμένες με κωδικό](/slides/el/java/password-protected-presentation/). Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε τον σωστό κωδικό ώστε η βιβλιοθήκη να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

### Υποστηρίζει το Aspose.Slides χρήση σε λύσεις cloud;

Ναι, το Aspose.Slides μπορεί να ενσωματωθεί σε εφαρμογές και υπηρεσίες cloud. Η βιβλιοθήκη έχει σχεδιαστεί για λειτουργία σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και κλιμάκωση για μαζική επεξεργασία αρχείων.

### Υπάρχουν περιορισμοί μεγέθους για τις παρουσιάσεις κατά τη μετατροπή;

Το Aspose.Slides μπορεί να διαχειριστεί παρουσιάσεις πρακτικά οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, μπορεί να απαιτούνται επιπλέον πόροι συστήματος, και μερικές φορές συνιστάται η βελτιστοποίηση της παρουσίασης για βελτίωση της απόδοσης.