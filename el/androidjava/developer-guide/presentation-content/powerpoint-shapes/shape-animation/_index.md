---
title: Εφαρμογή Κίνησης Σχημάτων σε Παρουσιάσεις σε Android
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/androidjava/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- σχήμα με κίνηση
- κείμενο με κίνηση
- προσθήκη κίνησης
- λήψη κίνησης
- εξαγωγή κίνησης
- προσθήκη εφέ
- λήψη εφέ
- εξαγωγή εφέ
- ήχος εφέ
- εφαρμογή κίνησης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να ελέγχετε και να προσαρμόζετε τις κινήσεις σχημάτων, τον χρονισμό, τους ήχους, τη συμπεριφορά μετά την κίνηση και το κείμενο με κίνηση, χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Android via Java αντιπροσωπεύει τις κινούμενες εφέ των διαφανειών ως εφέ σε μια χρονογραμμή διαφάνειας. Ένα εφέ έχει ένα σχήμα-στόχο, τύπο και υποτύπο κίνησης, ενεργοποίηση, ρυθμίσεις χρονισμού και προαιρετικές ιδιότητες όπως ήχος ή συμπεριφορά μετά την κίνηση.

Η χρονογραμμή περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς προχωρά η διαφάνεια.
- Μια **διαδραστική ακολουθία** ξεκινά όταν το σχήμα ενεργοποίησης κλικάρεται.

Δεδομένου ότι τα πλαίσια κειμένου, οι εικόνες, τα γραφήματα, οι πίνακες και άλλα αντικείμενα διαφάνειας υλοποιούν το [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/), χρησιμοποιείτε την ίδια μέθοδο [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) για το μεγαλύτερο μέρος του περιεχομένου της διαφάνειας. Τα διαθέσιμα εφέ αναφέρονται στην κλάση [EffectType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttype/).

## **Προσθήκη Κινούμενων Εφέ Σχημάτων**

Για να προσθέσετε μια κίνηση, αποκτήστε την κύρια ακολουθία της διαφάνειας και καλέστε το [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) με το σχήμα-στόχο, τον τύπο εφέ, τον υποτύπο και την ενεργοποίηση. Για ένα εφέ που ξεκινά όταν κλικάρεται ένα άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία της οποίας η ενεργοποίηση είναι αυτό το άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τα δύο είδη κίνησης και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Η ενεργοποίηση ελέγχει πότε ξεκινά ένα εφέ:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttriggertype/#OnClick) αναμένει κλικ στην κύρια ακολουθία ή κλικ στο σχήμα ενεργοποίησης σε μια διαδραστική ακολουθία.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) ξεκινά με το προηγούμενο εφέ.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) ξεκινά όταν ολοκληρωθεί το προηγούμενο εφέ.

Για να κίνηση μια εικόνα, ένα γράφημα ή άλλο τύπο σχήματος, περάστε αυτό το αντικείμενο στο [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) αντί για `targetShape`. Για επιλογές ομαδοποίησης συγκεκριμένες στα γραφήματα, δείτε [Animated Charts](/slides/el/androidjava/animated-charts/).

## **Ανάγνωση Κινούμενων Εφέ Σχημάτων**

Χρησιμοποιήστε το [ISequence.getEffectsByShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) όταν γνωρίζετε το σχήμα-στόχο. Για να εξετάσετε κάθε εφέ, απαριθμήστε την κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η απαρίθμηση αποτρέπει την υπόθεση ότι μια ακολουθία περιέχει εφέ στη θέση `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας και διαδραστικής ακολουθίας, λαμβάνει τα εφέ που στοχεύουν το σχήμα και στη συνέχεια απαριθμεί κάθε ακολουθία στη διαφάνεια.

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

Αν χρειάζεστε μόνο τα εφέ για ένα σχήμα, πρώτα προσδιορίστε το σχήμα με το όνομα, τον τύπο placeholder ή άλλη σταθερή ιδιότητα· μετά καλέστε το [ISequence.getEffectsByShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Μην υποθέτετε ότι το [IShapeCollection.get_Item](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) στη θέση `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Εργασία με Κληρονομημένα Εφέ Συμπληρωμάτων**

Ένα placeholder σε κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο placeholder στο πρότυπο διάταξης και στο master slide. Η μέθοδος [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) επιστρέφει αυτό το γονικό placeholder, ή `null` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση, το υποσέλιδο έχει **Random Bars** στην κανονική διαφάνεια, **Split** στο slide layout και **Fly In** στο master slide.

![Εφέ κίνησης υποσέλιδου στην κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ κίνησης υποσέλιδου στο πρότυπο διάταξης](layout-shape-animation.png)

![Εφέ κίνησης υποσέλιδου στην κύρια διαφάνεια (master)](master-shape-animation.png)

Το επόμενο παράδειγμα χρησιμοποιεί ιεραρχία placeholder από νέα παρουσίαση. Προσθέτει εφέ σε ένα master placeholder, ένα layout placeholder και το αντίστοιχο placeholder σε κανονική διαφάνεια. Κάθε κλήση στο [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) ελέγχεται πριν χρησιμοποιηθεί το επιστρεφόμενο σχήμα.

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **Αλλαγή Χρόνου Κίνησης**

Ο διάλογος **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες του [ITiming](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/).

![Διάλογος Timing του PowerPoint για εφέ κίνησης](shape-animation.png)

- **Start** αντιστοιχεί στο [ITiming.getTriggerType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** αντιστοιχεί στο [ITiming.getDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getDuration--), σε δευτερόλεπτα.
- **Delay** αντιστοιχεί στο [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), σε δευτερόλεπτα.
- **Repeat** αντιστοιχεί στα [ITiming.getRepeatCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), ή [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) .
- **Rewind when done playing** αντιστοιχεί στο [ITiming.getRewind](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRewind--) .

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει το χρονισμό του μέσω του αντικειμένου που επιστρέφει το [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), και αποθηκεύει το αποτέλεσμα. Η διατήρηση της αναφοράς στο επιστρεφόμενο [IEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/) αποτρέπει την ανάγκη για άσκοπο δείκτη συλλογής.

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός μετρητή επανάληψης με σημαία «until» μπορεί να δώσει παραπλανητικά αποτελέσματα σε διαφορετικούς προγράμματα προβολής. Όταν αλλάζετε τρόπους επανάληψης, ορίστε πρώτα [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) και [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) πριν το [ITiming.setRepeatCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), επειδή η ρύθμιση οποιασδήποτε σημαίας αλλάζει επίσης τον ενεργό τρόπο επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφέρει ενσωματωμένο ήχο μέσω του [IEffect.getSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getSound--). Το [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) ορίζει σε ένα εφέ να σταματήσει ήχο που άνοιξε ένα προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Ένα Εφέ**

Το παρακάτω παράδειγμα απαιτεί το τοπικό αρχείο ήχου `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει αυτό το αρχείο ως ήχο για το πρώτο εφέ και ρυθμίζει το δεύτερο εφέ να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφει το [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), επομένως δεν απαιτείται δείκτης ακολουθίας.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **Εξαγωγή Ενσωματωμένων Ήχων Εφέ**

Το παρακάτω παράδειγμα απαιτεί την τοπική παρουσίαση `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο τις κύριες όσο και τις διαδραστικές ακολουθίες και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκτίθεται από το [IAudio.getContentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iaudio/#getContentType--).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [IAudio.getStream](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iaudio/#getStream--) και αντιγράψτε το ρεύμα σε αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε πίνακα bytes.

## **Ορισμός Συμπεριφοράς Μετά το Κίνημα**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα αφού ολοκληρωθεί το εφέ του.

![Διάλογος Επιλογών Εφέ του PowerPoint που εμφανίζει τις ρυθμίσεις After animation](shape-after-animation.png)

Η κλάση [AfterAnimationType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/) υποστηρίζει διατήρηση του σχήματος αμετάβλητου, αλλαγή του χρώματός του, απόκρυψη του μετά την κίνηση ή απόκρυψη του στο επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.Color](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/#Color), ορίστε επίσης το [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά την κίνηση μέσω του επιστρεφόμενου αντικειμένου εφέ, και αποθηκεύει το αποτέλεσμα.

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Αλλάζοντας τον τύπο από το [AfterAnimationType.Color] αφαιρεί τη ρύθμιση χρώματος μετά την κίνηση.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο σχετικούς ελέγχους:

- Το [ITextAnimation.getBuildType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextanimation/#getBuildType--) ελέγχει αν οι παράγραφοι εμφανίζονται μαζί ή ανά παράγραφο.
- Το [IEffect.getAnimateTextType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) ελέγχει αν το κείμενο εμφανίζεται ολόκληρο, λέξη‑λεπτό ή γράμμα‑γράμμα. Το [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) θέτει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μια θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AsOneObject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/buildtype/#AsOneObject) απενεργοποιεί το κτίσιμο παράγραφο‑από‑παράγραφο ώστε η ρύθμιση λέξης να ισχύει για ολόκληρο το πλαίσιο κειμένου.

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Για κτίσιμο πλαισίου κειμένου ανά παράγραφο, ορίστε το [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (ή άλλο επίπεδο παραγράφου). Για στοχοθέτηση μιας μεμονωμένης παραγράφου με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση του [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) που δέχεται ένα [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/). Δείτε το [Animated Text](/slides/el/androidjava/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από το πρόγραμμα προβολής της παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν εκτελούν κίνηση. Χρησιμοποιήστε την [HTML5 export](/slides/el/androidjava/export-to-html5/), animated GIF ή τη [video conversion](/slides/el/androidjava/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και, όταν χρειάζεται, το [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Η απόδοση βίντεο υποστηρίζει πολλά κοινά εφέ εισόδου, έμφασης, εξόδου και διαδρομής κίνησης, αλλά δεν υποστηρίζονται όλα τα εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση Aspose.Slides που στοχεύετε.
- Προχωρημένα προσαρμοσμένα εφέ και εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά σε PowerPoint, HTML5 ή βίντεο. Επικυρώστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **Συχνές Ερωτήσεις (FAQ)**

**Γιατί εμφανίζεται μια κίνηση στο PowerPoint αλλά όχι σε PDF;**  
Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφανειών δεν παίζουν. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν πρέπει να διατηρηθεί η κίνηση.

**Γιατί ένα εφέ εκτελείται διαφορετικά σε βίντεο;**  
Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει την αρχική συμπεριφορά του PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Ελέγξτε τον πίνακα των υποστηριζόμενων εφέ και δοκιμάστε την παρουσίαση πριν την παραγωγική χρήση.

**Αλλάζει η μετακίνηση ενός σχήματος προς τα εμπρός ή προς τα πίσω τη σειρά των κινήσεων;**  
Όχι. Η σειρά z‑order του σχήματος ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και οι ενεργοποιήσεις ελέγχουν την αναπαραγωγή των κινήσεων. Αλλάξτε τη χρονογραμμή εάν χρειάζεται διαφορετική σειρά αναπαραγωγής.