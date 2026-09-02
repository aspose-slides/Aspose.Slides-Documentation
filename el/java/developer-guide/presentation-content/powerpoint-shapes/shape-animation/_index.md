---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις με Java
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/java/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- κινούμενο σχήμα
- κινούμενο κείμενο
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
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, ελέγχετε και προσαρμόζετε τις κινήσεις σχημάτων, το χρονισμό, τους ήχους, τη συμπεριφορά μετά την κίνηση και το κείμενο με κίνηση με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Java αντιπροσωπεύει τις κινήσεις των διαφανειών ως εφέ σε μια χρονογραμμή διαφάνειας. Ένα εφέ έχει ένα σχήμα‑στόχο, έναν τύπο και υποτύπο κίνησης, έναν ενεργοποιητή, ρυθμίσεις χρονισμού και προαιρετικές ιδιότητες όπως ήχο ή συμπεριφορά μετά την κίνηση.

Η χρονογραμμή περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς η διαφάνεια προχωρά.
- Μια **διαδραστική ακολουθία** ξεκινά όταν το σχήμα‑ενεργοποιητής της γίνεται κλικ.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας υλοποιούν το [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/), χρησιμοποιείτε την ίδια μέθοδο [ISequence.addEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) για το μεγαλύτερο μέρος του περιεχομένου της διαφάνειας. Τα διαθέσιμα εφέ αναφέρονται στην κλάση [EffectType](https://reference.aspose.com/slides/el/java/com.aspose.slides/effecttype/).

## **Προσθήκη Κινήσεων Σχημάτων**

Για να προσθέσετε μια κίνηση, λάβετε την κύρια ακολουθία της διαφάνειας και καλέστε τη μέθοδο [ISequence.addEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) με το σχήμα‑στόχο, τον τύπο εφέ, τον υποτύπο και τον ενεργοποιητή. Για ένα εφέ που ξεκινά όταν γίνεται κλικ σε άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία της οποίας ο ενεργοποιητής είναι αυτό το άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τους δύο τύπους κίνησης και αποθηκεύει το αποτέλεσμα στο αρχείο `shape-animations.pptx`.

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

Ο ενεργοποιητής ελέγχει πότε ξεκινά ένα εφέ:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/effecttriggertype/#OnClick) περιμένει ένα κλικ στην κύρια ακολουθία ή ένα κλικ στο σχήμα‑ενεργοποιητή σε μια διαδραστική ακολουθία.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/el/java/com.aspose.slides/effecttriggertype/#WithPrevious) ξεκινά με το προηγούμενο εφέ.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/el/java/com.aspose.slides/effecttriggertype/#AfterPrevious) ξεκινά όταν ολοκληρωθεί το προηγούμενο εφέ.

Για να κινήσετε μια εικόνα, διάγραμμα ή άλλο τύπο σχήματος, περάστε αυτό το αντικείμενο στη μέθοδο [ISequence.addEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) αντί για `targetShape`. Για επιλογές ομαδοποίησης που αφορούν τα διαγράμματα, δείτε το [Animated Charts](/slides/el/java/animated-charts/).

## **Ανάγνωση Κινήσεων Σχημάτων**

Χρησιμοποιήστε τη μέθοδο [ISequence.getEffectsByShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) όταν γνωρίζετε το σχήμα‑στόχο. Για να εξετάσετε κάθε εφέ, κάντε επανάληψη στην κύρια ακολουθία και σε κάθε διαδραστική ακολουθία. Η επανάληψη αποτρέπει την παραδοχή ότι μια ακολουθία περιέχει εφέ στο δείκτη `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ στην κύρια ακολουθία και σε διαδραστική ακολουθία, λαμβάνει τα εφέ που στοχεύουν το σχήμα και στη συνέχεια επαναλαμβάνει κάθε ακολουθία στην διαφάνεια.

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

Αν χρειάζεστε μόνο τα εφέ για ένα σχήμα, πρώτα προσδιορίστε το σχήμα με όνομα, τύπο placeholder ή άλλη σταθερή ιδιότητα· στη συνέχεια καλέστε τη μέθοδο [ISequence.getEffectsByShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Μην υποθέτετε ότι το [IShapeCollection.get_Item](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#get_Item-int-) στο δείκτη `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Διαχείριση Κληρονομισμένων Εφέ Placeholder**

Ένα placeholder σε κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο placeholder στη διαφάνεια διάταξης και στον κύριο πρότυπο. Η μέθοδος [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getBasePlaceholder--) επιστρέφει αυτό το γονικό placeholder ή `null` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στη κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στον κύριο πρότυπο.

![Εφέ κίνησης υποσέλιδου στη κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στη διαφάνεια διάταξης](layout-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στη κύρια διαφάνεια](master-shape-animation.png)

Το επόμενο παράδειγμα χρησιμοποιεί μια ιεραρχία placeholder από μια νέα παρουσίαση. Προσθέτει εφέ σε ένα master placeholder, ένα layout placeholder και το αντίστοιχο placeholder σε μια κανονική διαφάνεια. Κάθε κλήση στη μέθοδο [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getBasePlaceholder--) ελέγχεται πριν χρησιμοποιηθεί το επιστραφέν σχήμα.

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

## **Αλλαγή Χρονισμού Κίνησης**

Το παράθυρο διαλόγου **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες του [ITiming](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/).

![Διάλογος Timing του PowerPoint για ένα εφέ κίνησης](shape-animation.png)

- **Start** αντιστοιχεί στο [ITiming.getTriggerType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** αντιστοιχεί στο [ITiming.getDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getDuration--), σε δευτερόλεπτα.
- **Delay** αντιστοιχεί στο [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getTriggerDelayTime--), σε δευτερόλεπτα.
- **Repeat** αντιστοιχεί στο [ITiming.getRepeatCount](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), ή [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** αντιστοιχεί στο [ITiming.getRewind](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getRewind--).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει το χρονισμό του μέσω του αντικειμένου που επιστρέφει η μέθοδος [ISequence.addEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), και αποθηκεύει το αποτέλεσμα. Η διατήρηση της επιστρεφόμενης αναφοράς [IEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/) αποτρέπει την ανάγκη για περιττό δείκτη συλλογής.

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

Χρησιμοποιήστε μόνο έναν τρόπο επανάληψης επίτηδες. Ο συνδυασμός αριθμού επαναλήψεων με σημαία «until» μπορεί να δημιουργήσει συγκεχυμένα αποτελέσματα σε διαφορετικούς προβολείς. Κατά την αλλαγή των τρόπων επανάληψης, ορίστε πρώτα τις μεθόδους [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) και [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) πριν την [ITiming.setRepeatCount](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#setRepeatCount-float-), επειδή ο ορισμός οποιασδήποτε από τις σημαίες αλλάζει επίσης τον ενεργό τρόπο επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφερθεί σε ενσωματωμένο ήχο μέσω του [IEffect.getSound](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getSound--). Η μέθοδος [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) λέει σε ένα εφέ να σταματήσει ήχο που ξεκίνησε από προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Εφέ**

Το παρακάτω παράδειγμα απαιτεί ένα τοπικό αρχείο ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει αυτό το αρχείο ως ήχο για το πρώτο εφέ και διαμορφώνει το δεύτερο εφέ ώστε να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφει η μέθοδος [ISequence.addEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), έτσι δεν απαιτείται δείκτης ακολουθίας.

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

Το παρακάτω παράδειγμα απαιτεί μια τοπική παρουσίαση με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο την κύρια όσο και τις διαδραστικές ακολουθίες και γράφει κάθε ενσωματωμένο ήχο εφέ στον κατάλογο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκτίθεται από το [IAudio.getContentType](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudio/#getContentType--).

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

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [IAudio.getStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudio/#getStream--) και αντιγράψτε τη ροή σε αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε έναν πίνακα byte.

## **Ορισμός Συμπεριφοράς Μετά την Κίνηση**

Η επιλογή **After animation** ελέγχει τι συμβαίνει σε ένα σχήμα μετά το τέλος του εφέ.

![Διάλογος Επιλογών Εφέ του PowerPoint που εμφανίζει τις ρυθμίσεις After animation](shape-after-animation.png)

Η κλάση [AfterAnimationType](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/) υποστηρίζει τη διατήρηση του σχήματος αμετάβλητο, την αλλαγή του χρώματος του, την απόκρυψή του μετά την κίνηση, ή την απόκρυψή του στο επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#Color), ορίστε επίσης το [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) .

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά την κίνηση μέσω του επιστρεφόμενου αντικειμένου εφέ, και αποθηκεύει το αποτέλεσμα.

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Η αλλαγή του τύπου από το [AfterAnimationType.Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#Color) αφαιρεί τη ρύθμιση χρώματος μετά την κίνηση.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο σχετικούς ελέγχους:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextanimation/#getBuildType--) ελέγχει αν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getAnimateTextType--) ελέγχει αν το κείμενο εμφανίζεται ολόκληρο, ανά λέξη ή ανά γράμμα. Το [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μια θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Η επιλογή [BuildType.AsOneObject](https://reference.aspose.com/slides/el/java/com.aspose.slides/buildtype/#AsOneObject) απενεργοποιεί την κατασκευή παράγραφος‑κατά‑παράγραφο ώστε η ρύθμιση λέξης να ισχύει για ολόκληρο το πλαίσιο κειμένου.

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

Για να δημιουργήσετε ένα πλαίσιο κειμένου ανά παράγραφο, ορίστε το [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/el/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (ή άλλο επίπεδο παραγράφου). Για να στοχεύσετε μια μόνο παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση της [ISequence.addEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) που δέχεται ένα [IParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/). Δείτε το [Animated Text](/slides/el/java/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώματα Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από το πρόγραμμα προβολής παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν παίζουν κινήσεις. Χρησιμοποιήστε την [HTML5 export](/slides/el/java/export-to-html5/), animated GIF, ή [video conversion](/slides/el/java/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και, όταν χρειάζεται, το [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Η απόδοση βίντεο υποστηρίζει πολλές κοινές εφέ εισόδου, έμφασης, εξόδου και διαδρομής κίνησης, αλλά δεν υποστηρίζονται όλα τα εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/java/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση Aspose.Slides που χρησιμοποιείτε.
- Οι προχωρημένες προσαρμοσμένες εφέ και εφέ που εισάγονται από άλλες μορφές παρουσίασης ενδέχεται να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά στο PowerPoint, HTML5 ή βίντεο. Επικυρώστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί εμφανίζεται μια κίνηση στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφανειών δεν παίζουν. Εξαγάγετε σε HTML5, animated GIF ή βίντεο όταν πρέπει να διατηρηθεί η κίνηση.

**Γιατί ένα εφέ αποδίδεται διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει τη συμπεριφορά του αρχικού PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται προσεγγιστικά. Εξετάστε τον πίνακα των υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν από τη χρήση στην παραγωγή.

**Αλλάζει η μετακίνηση ενός σχήματος προς τα εμπρός ή πίσω τη σειρά κίνησης του;**

Όχι. Η σειρά z‑order του σχήματος ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και οι ενεργοποιητές ελέγχουν την αναπαραγωγή της κίνησης. Αλλάξτε τη χρονογραμμή αν χρειάζεστε διαφορετική σειρά αναπαραγωγής.