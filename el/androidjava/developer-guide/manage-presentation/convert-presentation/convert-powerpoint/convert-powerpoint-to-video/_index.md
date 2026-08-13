---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Βίντεο σε Android
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
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε βίντεο με Java. Ανακαλύψτε παραδείγματα κώδικα και τεχνικές αυτοματοποίησης για να βελτιστοποιήσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασής σας PowerPoint σε βίντεο, παίρνετε 

* **Αύξηση προσβασιμότητας:** Όλες οι συσκευές (ανεξαρτήτως πλατφόρμας) διαθέτουν προεγκατεστημένους αναπαραγωγείς βίντεο σε σύγκριση με τις εφαρμογές ανοίγματος παρουσιάσεων, έτσι οι χρήστες βρίσκουν πιο εύκολο το άνοιγμα ή την αναπαραγωγή βίντεο.
* **Μεγαλύτερο εύρος:** Μέσω βίντεο, μπορείτε να προσεγγίσετε ένα μεγάλο κοινό και να τους στοχεύσετε με πληροφορίες που διαφορετικά μπορεί να φαίνονται βαρετές σε μια παρουσίαση. Οι περισσότερες έρευνες και στατιστικές δείχνουν ότι οι άνθρωποι παρακολουθούν και καταναλώνουν βίντεο περισσότερο από άλλα είδη περιεχομένου, και γενικά προτιμούν τέτοιο περιεχόμενο.

## **Μετατροπή PowerPoint σε Βίντεο στο Aspose.Slides**

Το Aspose.Slides υποστηρίζει τη μετατροπή παρουσίασης σε βίντεο.

* Χρησιμοποιήστε **Aspose.Slides** για να δημιουργήσετε ένα σύνολο καρέ (από τις διαφάνειες της παρουσίασης) που αντιστοιχούν σε καθορισμένα FPS (καρέ ανά δευτερόλεπτο)
* Χρησιμοποιήστε ένα εξωτερικό εργαλείο όπως το **ffmpeg** ([για java](https://github.com/bramp/ffmpeg-cli-wrapper)) για να δημιουργήσετε ένα βίντεο βασισμένο στα καρέ. 

### **Μετατροπή PowerPoint σε Βίντεο**

1. Προσθέστε αυτό στο αρχείο POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Κατεβάστε το ffmpeg [εδώ](https://ffmpeg.org/download.html).

3. Εκτελέστε τον κώδικα Java για μετατροπή PowerPoint σε βίντεο.

Αυτός ο κώδικας Java δείχνει πώς να μετατρέψετε μια παρουσίαση (που περιέχει μια εικόνα και δύο εφέ κινούμενης εικόνας) σε βίντεο:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και στη συνέχεια το κινούει
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

    // Ρυθμίστε το φάκελο των εκτελέσιμων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/bramp/ffmpeg-cli-wrapper
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

Μπορείτε να εφαρμόσετε κινούμενα εφέ σε αντικείμενα στις διαφάνειες και να χρησιμοποιήσετε μεταβάσεις μεταξύ διαφανειών. 

{{% alert color="info" %}} 

Μπορείτε να δείτε αυτά τα άρθρα: [Κινούμενα Στοιχεία PowerPoint](https://docs.aspose.com/slides/el/androidjava/powerpoint-animation/), [Κινούμενα Σχήματα](https://docs.aspose.com/slides/el/androidjava/shape-animation/), και [Εφέ Σχήματος](https://docs.aspose.com/slides/el/androidjava/shape-effect/).

{{% /alert %}} 

Τα κινούμενα εφέ και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες—και κάνουν το ίδιο και τα βίντεο. Ας προσθέσουμε μια ακόμη διαφάνεια και μετάβαση στον κώδικα για την προηγούμενη παρουσίαση:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Η παρουσίαση με το κινούμενο σχήμα χαμόγελου που δημιουργήθηκε παραπάνω.
Presentation presentation = new Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια και κινούμενη μετάβαση

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Το Aspose.Slides υποστηρίζει επίσης κινούμενα εφέ για κείμενα. Έτσι κινούμε παραγράφους σε αντικείμενα, που εμφανίζονται η μία μετά την άλλη (με καθυστέρηση ενός δευτερολέπτου):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Προσθέτει κείμενο και κινούμενα εφέ
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

    // Ρυθμίστε το φάκελο των εκτελέσιμων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/bramp/ffmpeg-cli-wrapper
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

Για να μπορείτε να εκτελείτε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationanimationsgenerator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationanimationsgenerator/) σας επιτρέπει να ορίσετε το μέγεθος πλαισίου για το βίντεο (που θα δημιουργηθεί αργότερα) μέσω του κατασκευαστή της. Εάν περάσετε ένα αντικείμενο παρουσίασης, θα χρησιμοποιηθεί το `Presentation.SlideSize` και δημιουργεί κινούμενα εφέ που χρησιμοποιεί το [PresentationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationplayer/).

Όταν δημιουργούνται κινούμενα εφέ, δημιουργείται ένα συμβάν `NewAnimation` για κάθε επακόλουθο εφέ, το οποίο έχει την παράμετρο [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationanimationplayer/). Η τελευταία είναι μια κλάση που αντιπροσωπεύει έναν player για ξεχωριστό εφέ.

Για τη χρήση του [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationanimationplayer/), χρησιμοποιούνται η ιδιότητα [Duration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (η συνολική διάρκεια του εφέ) και η μέθοδος [SetTimePosition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Κάθε θέση εφέ ορίζεται εντός του εύρους *0 έως duration*, και στη συνέχεια η μέθοδος `getFrame` επιστρέφει ένα [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) που αντιστοιχεί στην κατάσταση του εφέ εκείνη τη στιγμή:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και το κινούει
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

            animationPlayer.setTimePosition(0); // αρχική κατάσταση του εφέ
            // bitmap αρχικής κατάστασης του εφέ
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // τελική κατάσταση του εφέ
            // τελευταίο καρέ του εφέ
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Δημιουργεί τα εφέ. Η παραπάνω κλήση επιστροφής εκτελείται για το καθένα.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Για να παίζουν όλα τα εφέ μιας παρουσίασης ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationplayer/). Αυτή η κλάση παίρνει ένα αντικείμενο [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationanimationsgenerator/) και FPS για τα εφέ στον κατασκευαστή της και έπειτα καλεί το συμβάν `FrameTick` για όλα τα εφέ ώστε να αναπαραχθούν:

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

Στη συνέχεια τα παραγόμενα καρέ μπορούν να συναχθούν για να παραχθεί ένα βίντεο. Δείτε την ενότητα [Convert PowerPoint to Video](https://docs.aspose.com/slides/el/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Υποστηριζόμενα Κινούμενα Εφέ και Εφέ**

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

## **FAQ**

### Είναι δυνατόν να μετατρέψετε παρουσιάσεις που είναι προστατευμένες με κωδικό;

Ναι, το Aspose.Slides επιτρέπει εργασία με [παρουσιάσεις με κωδικό πρόσβασης](/slides/el/androidjava/password-protected-presentation/). Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε το σωστό κωδικό ώστε η βιβλιοθήκη να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

### Υποστηρίζει το Aspose.Slides χρήση σε λύσεις cloud;

Ναι, το Aspose.Slides μπορεί να ενσωματωθεί σε εφαρμογές και υπηρεσίες cloud. Η βιβλιοθήκη έχει σχεδιαστεί για λειτουργία σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και επεκτασιμότητα για μαζική επεξεργασία αρχείων.

### Υπάρχουν περιορισμοί μεγέθους για τις παρουσιάσεις κατά τη μετατροπή;

Το Aspose.Slides μπορεί να χειριστεί παρουσιάσεις σχεδόν οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, μπορεί να απαιτηθούν πρόσθετοι πόροι συστήματος και μερικές φορές συνιστάται η βελτιστοποίηση της παρουσίασης για βελτίωση της απόδοσης.