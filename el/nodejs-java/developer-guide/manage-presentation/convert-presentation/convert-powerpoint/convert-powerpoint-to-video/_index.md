---
title: Μετατροπή παρουσιάσεων PowerPoint σε βίντεο με JavaScript
linktitle: PowerPoint σε βίντεο
type: docs
weight: 130
url: /el/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε βίντεο με JavaScript. Ανακαλύψτε δείγμα κώδικα και τεχνικές αυτοματισμού για τη βελτιστοποίηση της ροής εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασης PowerPoint σε βίντεο, αποκτάτε 

* **Αύξηση της προσβασιμότητας:** Όλες οι συσκευές (ανεξαρτήτως πλατφόρμας) είναι εξοπλισμένες με προγράμματα αναπαραγωγής βίντεο από προεπιλογή, σε αντίθεση με τις εφαρμογές άνοιγμα παρουσίασης, έτσι οι χρήστες βρίσκουν πιο εύκολο το άνοιγμα ή την αναπαραγωγή βίντεο.
* **Μεγαλύτερη εμβέλεια:** Μέσω βίντεο, μπορείτε να προσεγγίσετε ένα μεγάλο κοινό και να το στοχεύσετε με πληροφορίες που διαφορετικά θα μπορούσαν να φαίνονται κουραστικές σε μια παρουσίαση. Η πλειονότητα των ερευνών και στατιστικών επισημαίνει ότι οι άνθρωποι παρακολουθούν και καταναλώνουν βίντεο περισσότερο από άλλες μορφές περιεχομένου και γενικά προτιμούν αυτό το είδος περιεχομένου.

{{% alert color="primary" %}} 

Ίσως θέλετε να ελέγξετε τον [**PowerPoint σε Online Μετατροπέα Βίντεο**](https://products.aspose.app/slides/el/conversion/ppt-to-word) επειδή είναι μια ζωντανή και αποτελεσματική υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}} 

## **Μετατροπή PowerPoint σε Βίντεο στο Aspose.Slides**

Το Aspose.Slides υποστηρίζει τη μετατροπή παρουσίασης‑προς‑βίντεο.

* Χρησιμοποιήστε το **Aspose.Slides** για να δημιουργήσετε ένα σύνολο καρέ (από τις διαφάνειες της παρουσίασης) που αντιστοιχούν σε συγκεκριμένο FPS (καρέ ανά δευτερόλεπτο)
* Χρησιμοποιήστε ένα εργαλείο τρίτου μέρους όπως το **ffmpeg** ([για java](https://github.com/bramp/ffmpeg-cli-wrapper)) για να δημιουργήσετε ένα βίντεο με βάση τα καρέ. 

### **Μετατροπή PowerPoint σε Βίντεο**

1. Κατεβάστε το ffmpeg [εδώ](https://ffmpeg.org/download.html).

2. Εκτελέστε τον κώδικα JavaScript μετατροπής PowerPoint σε βίντεο.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να μετατρέψετε μια παρουσίαση (που περιλαμβάνει ένα σχήμα και δύο εφέ κίνησης) σε βίντεο:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και μετά το ανιματίζει
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Διαμόρφωση φακέλου δυαδικών αρχείων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Εφέ Βίντεο**

Μπορείτε να εφαρμόζετε κινήσεις σε αντικείμενα στις διαφάνειες και να χρησιμοποιείτε μεταβάσεις μεταξύ των διαφανειών. 

{{% alert color="primary" %}} 

Ίσως θέλετε να δείτε αυτά τα άρθρα: [Κίνηση PowerPoint](https://docs.aspose.com/slides/el/nodejs-java/powerpoint-animation/), [Κίνηση Σχήματος](https://docs.aspose.com/slides/el/nodejs-java/shape-animation/), και [Εφέ Σχήματος](https://docs.aspose.com/slides/el/nodejs-java/shape-effect/).

{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες—και το ίδιο ισχύει για τα βίντεο. Ας προσθέσουμε μια ακόμη διαφάνεια και μετάβαση στον κώδικα της προηγούμενης παρουσίασης:

```javascript
// Προσθέτει ένα σχήμα χαμόγελου και το ανιματίζει
// ...
// Προσθέτει μια νέα διαφάνεια και κινούμενη μετάβαση
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Το Aspose.Slides υποστηρίζει επίσης κίνηση για κείμενα. Έτσι κάνουμε κίνηση σε παραγράφους σε αντικείμενα, που θα εμφανίζονται μία μετά την άλλη (με καθυστέρηση ενός δευτερολέπτου):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Προσθέτει κείμενο και κινήσεις
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Διαμόρφωση φακέλου δυαδικών αρχείων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Κλάσεις Μετατροπής Βίντεο**

Για να σας επιτρέψει να εκτελείτε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationanimationsgenerator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationanimationsgenerator/) σας επιτρέπει να ορίσετε το μέγεθος των καρέ για το βίντεο (που θα δημιουργηθεί αργότερα) μέσω του κατασκευαστή του. Εάν περάσετε μια παρουσίαση, θα χρησιμοποιηθεί `Presentation.getSlideSize` και δημιουργεί κινήσεις που χρησιμοποιεί το [PresentationPlayer](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationplayer/).

Κατά τη δημιουργία κινήσεων, παράγεται ένα συμβάν `NewAnimation` για κάθε επακόλουθη κίνηση, το οποίο έχει τη παράμετρο του παίκτη κίνησης παρουσίασης. Η τελευταία είναι μια κλάση που αντιπροσωπεύει έναν παίχτη για μια ξεχωριστή κίνηση.

Για να εργαστείτε με τον παίκτη κίνησης παρουσίασης, χρησιμοποιούνται οι μέθοδοι `getDuration` (η συνολική διάρκεια της κίνησης) και `setTimePosition`. Η θέση κάθε κίνησης ορίζεται μέσα στο εύρος *0 έως διάρκεια*, και έπειτα η μέθοδος `getFrame` επιστρέφει ένα BufferedImage που αντιστοιχεί στην κατάσταση της κίνησης εκείνη τη στιγμή:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Προσθέτει ένα σχήμα χαμόγελου και το ανιματίζει
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// αρχική κατάσταση κίνησης
            try {
                // bitmap αρχικής κατάστασης κίνησης
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// τελική κατάσταση της κίνησης
            try {
                // τελευταίο καρέ της κίνησης
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Για να κάνετε όλες τις κινήσεις σε μια παρουσίαση να παίζονται ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationplayer/). Αυτή η κλάση λαμβάνει μια παρουσίαση [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationanimationsgenerator/), καθώς και FPS για τα εφέ στον κατασκευαστή της και στη συνέχεια καλεί το συμβάν `FrameTick` για όλες τις κινήσεις ώστε να παιχτούν:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Στη συνέχεια τα δημιουργημένα καρέ μπορούν να συνδυαστούν για την παραγωγή βίντεο. Δείτε την ενότητα [Convert PowerPoint to Video](https://docs.aspose.com/slides/el/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Υποστηριζόμενες Κινήσεις και Εφέ**

**Entrance**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εμφάνιση** | ![not supported](x.png) | ![supported](v.png) |
| **Ξεθώριασμα** | ![supported](v.png) | ![supported](v.png) |
| **Πτήση Εισόδου** | ![supported](v.png) | ![supported](v.png) |
| **Αιώρηση Εισόδου** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Σκούπισμα** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![supported](v.png) | ![supported](v.png) |
| **Τροχός** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίες Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Ανάπτυξη & Στροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Στροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αναπήδηση** | ![supported](v.png) | ![supported](v.png) |

**Emphasis**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Παλμός** | ![not supported](x.png) | ![supported](v.png) |
| **Παλμός Χρώματος** | ![not supported](x.png) | ![supported](v.png) |
| **Ταλάντωση** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Ανάπτυξη/Σμίκρυνση** | ![not supported](x.png) | ![supported](v.png) |
| **Αποκορεσμός** | ![not supported](x.png) | ![supported](v.png) |
| **Σκοτείνιασμα** | ![not supported](x.png) | ![supported](v.png) |
| **Ασάφεια** | ![not supported](x.png) | ![supported](v.png) |
| **Διαφάνεια** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Αντικειμένου** | ![not supported](x.png) | ![supported](v.png) |
| **Συμπληρωματικό Χρώμα** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Γραμμής** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Γέμισμα** | ![not supported](x.png) | ![supported](v.png) |

**Exit**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εξαφάνιση** | ![not supported](x.png) | ![supported](v.png) |
| **Ξεθώριασμα** | ![supported](v.png) | ![supported](v.png) |
| **Πτήση Εξόδου** | ![supported](v.png) | ![supported](v.png) |
| **Αιώρηση Εξόδου** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Σκούπισμα** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίες Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Σύσπαση & Στροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Στροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αναπήδηση** | ![supported](v.png) | ![supported](v.png) |

**Motion Paths**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Τόξα** | ![supported](v.png) | ![supported](v.png) |
| **Στροφές** | ![supported](v.png) | ![supported](v.png) |
| **Σχήματα** | ![supported](v.png) | ![supported](v.png) |
| **Βρόχοι** | ![supported](v.png) | ![supported](v.png) |
| **Προσαρμοσμένη Διαδρομή** | ![supported](v.png) | ![supported](v.png) |

## **Συχνές Ερωτήσεις**

**Μπορεί να γίνει μετατροπή παρουσιάσεων που είναι προστατευμένες με κωδικό;**

Ναι, το Aspose.Slides επιτρέπει τη χρήση παρουσιάσεων προστατευμένων με κωδικό. Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε τον σωστό κωδικό ώστε η βιβλιοθήκη να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

**Υποστηρίζει το Aspose.Slides χρήση σε λύσεις cloud;**

Ναι, το Aspose.Slides μπορεί να ενσωματωθεί σε εφαρμογές και υπηρεσίες cloud. Η βιβλιοθήκη έχει σχεδιαστεί για να λειτουργεί σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και κλιμάκωση για μαζική επεξεργασία αρχείων.

**Υπάρχουν περιορισμοί μεγέθους για τις παρουσιάσεις κατά τη μετατροπή;**

Το Aspose.Slides μπορεί να διαχειριστεί παρουσιάσεις πρακτικά οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, μπορεί να απαιτηθούν πρόσθετοι πόροι συστήματος, και μερικές φορές συστήνεται η βελτιστοποίηση της παρουσίασης για βελτίωση της απόδοσης.