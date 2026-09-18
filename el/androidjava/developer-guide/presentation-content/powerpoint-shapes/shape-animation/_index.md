---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις στο Android
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/androidjava/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- κινούμενο σχήμα
- κινούμενο κείμενο
- προσθήκη κίνησης
- ανάκτηση κίνησης
- εξαγωγή κίνησης
- προσθήκη εφέ
- ανάκτηση εφέ
- εξαγωγή εφέ
- ήχος εφέ
- εφαρμογή κίνησης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, ελέγχετε και προσαρμόζετε κινήσεις σχημάτων, χρόνο, ήχους, συμπεριφορά μετά την κίνηση και κείμενο με κίνηση με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Για να εργαστείτε με τις μεμονωμένες συμπεριφορές μέσα σε ένα εφέ ή να επεξεργαστείτε τμήματα μονοπατιού κίνησης, δείτε [Προσαρμοσμένη Κίνηση για Java](/slides/el/java/custom-animation/).

Το Aspose.Slides for Android μέσω Java αντιπροσωπεύει τις κινήσεις των διαφανειών ως εφέ σε μια χρονοδιάγραμμα διαφάνειας. Ένα εφέ έχει σχήμα-στόχο, τύπο και υπότυπο κίνησης, ένα σκανάρι, ρυθμίσεις χρόνου και προαιρετικές ιδιότητες όπως ήχος ή συμπεριφορά μετά το εφέ.

Το χρονοδιάγραμμα περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς προχωρά η διαφάνεια.
- Μία **διαδραστική ακολουθία** ξεκινά όταν το σχήμα‑σκανάρι κλικάρεται.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας υλοποιούν το [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/), χρησιμοποιείτε την ίδια μέθοδο [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) για τα περισσότερα περιεχόμενα διαφάνειας. Τα διαθέσιμα εφέ παρατίθενται στην κλάση [EffectType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttype/).

## **Προσθήκη Κινήσεων σε Σχήματα**

Για να προσθέσετε μια κίνηση, αποκτήστε την κύρια ακολουθία της διαφάνειας και καλέστε το [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) με το σχήμα‑στόχο, τον τύπο εφέ, τον υπότυπο και το σκανάρι. Για ένα εφέ που ξεκινά όταν κλικάρεται ένα άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία του οποίου το σκανάρι είναι εκείνο το άλλο σχήμα.

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

Το σκανάρι ελέγχει πότε ξεκινά ένα εφέ:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttriggertype/#OnClick) περιμένει κλικ στην κύρια ακολουθία ή κλικ στο σχήμα‑σκανάρι σε μια διαδραστική ακολουθία.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) ξεκινά μαζί με το προηγούμενο εφέ.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) ξεκινά όταν ολοκληρωθεί το προηγούμενο εφέ.

Για να κινήσετε μια εικόνα, γράφημα ή άλλο τύπο σχήματος, περάστε αυτό το αντικείμενο στο [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) αντί για το `targetShape`. Για επιλογές ομαδοποίησης ειδικά για διαγράμματα, δείτε [Animated Charts](/slides/el/androidjava/animated-charts/).

## **Ανάγνωση Κινήσεων Σχήματος**

Χρησιμοποιήστε το [ISequence.getEffectsByShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) όταν γνωρίζετε το σχήμα‑στόχο. Για να εξετάσετε κάθε εφέ, απαριθμήστε την κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η απαρίθμηση αποφεύγει την υπόθεση ότι μια ακολουθία περιέχει εφέ στη θέση `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας και διαδραστικής ακολουθίας, λαμβάνει τα εφέ που στοχεύουν το σχήμα και, στη συνέχεια, απαριθμεί κάθε ακολουθία στη διαφάνεια.

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

Αν χρειάζεστε μόνο τα εφέ για ένα σχήμα, πρώτα ταυτοποιήστε το σχήμα με όνομα, τύπο placeholder ή άλλη σταθερή ιδιότητα· έπειτα καλέστε το [ISequence.getEffectsByShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Μην υποθέτετε ότι το [IShapeCollection.get_Item](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) στη θέση `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Εργασία με Κληρονομημένα Εφέ Συμπληρωματικού Στοιχείου**

Ένα placeholder σε μια κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο placeholder στη διαφάνεια διάταξης και στον κύριο πρότυπο. Το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) επιστρέφει εκείνο το γονικό placeholder ή `null` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στην κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στον κύριο πρότυπο.

![Εφέ κίνησης υποσέλιδου στην κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στη διαφάνεια διάταξης](layout-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στον κύριο πρότυπο](master-shape-animation.png)

Το επόμενο παράδειγμα χρησιμοποιεί ιεραρχία placeholder από νέα παρουσίαση. Προσθέτει εφέ σε placeholder κύριου προτύπου, placeholder διάταξης και στο αντίστοιχο placeholder στην κανονική διαφάνεια. Κάθε κλήση στο [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) ελέγχεται πριν το επιστρεφόμενο σχήμα χρησιμοποιηθεί.

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
- **Repeat** αντιστοιχεί στο [ITiming.getRepeatCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatCount--), στο [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), ή στο [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** αντιστοιχεί στο [ITiming.getRewind](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRewind--).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει τον χρόνο του μέσω του αντικειμένου που επιστρέφεται από το [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), και αποθηκεύει το αποτέλεσμα. Η διατήρηση της επιστρεφόμενης αναφοράς σε [IEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/) αποφεύγει έναν περιττό δείκτη συλλογής.

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

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός αριθμού επανάληψης με σημαία «until» μπορεί να δημιουργήσει συγκεχυμένα αποτελέσματα σε διάφορους προγυρόπτες. Όταν αλλάζετε τρόπους επανάληψης, θέστε πρώτα το [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) και το [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) πριν το [ITiming.setRepeatCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), επειδή η ρύθμιση κάποιας σημαίας αλλάζει και τη λειτουργική λειτουργία επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφέρεται σε ενσωματωμένο ήχο μέσω του [IEffect.getSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getSound--). Το [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) υποδεικνύει σε ένα εφέ να σταματήσει ήχο που είχε ξεκινήσει ένα προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Εφέ**

Το παρακάτω παράδειγμα αναμένει ένα τοπικό αρχείο ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει το αρχείο ως ήχο του πρώτου εφέ και ρυθμίζει το δεύτερο εφέ να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφονται από το [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), επομένως δεν απαιτείται δείκτης ακολουθίας.

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

Το παρακάτω παράδειγμα αναμένει μια τοπική παρουσίαση με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει και τις κύρεις και τις διαδραστικές ακολουθίες και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκθέτει το [IAudio.getContentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iaudio/#getContentType--).

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

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [IAudio.getStream](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iaudio/#getStream--) και αντιγράψτε το ρεύμα σε αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε πίνακα byte.

## **Ορισμός Συμπεριφοράς Μετά την Κίνηση**

Η επιλογή **After animation** ελέγχει τι συμβαίνει σε ένα σχήμα μετά το τέλος του εφέ του.

![Διάλογος επιλογών εφέ του PowerPoint που εμφανίζει ρυθμίσεις After animation](shape-after-animation.png)

Η κλάση [AfterAnimationType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/) υποστηρίζει την διατήρηση του σχήματος αμετάβλητο, την αλλαγή του χρώματος, απόκρυψη μετά το εφέ ή απόκρυψη στην επόμενη κίνηση. Όταν ο τύπος είναι [AfterAnimationType.Color](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/#Color), ορίστε επίσης το [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά την κίνηση μέσω του επιστρεφόμενου αντικειμένου εφέ και αποθηκεύει το αποτέλεσμα.

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

Η αλλαγή του τύπου από το [AfterAnimationType.Color](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/#Color) αφαιρεί τη ρύθμιση χρώματος μετά το εφέ.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο σχετιζόμενους ελέγχους:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextanimation/#getBuildType--) ελέγχει εάν οι παράγραφοι εμφανίζονται μαζί ή κατά επίπεδο παραγράφου.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) ελέγχει εάν το κείμενο εμφανίζεται ολόκληρο, λέξη προς λέξη ή γράμμα προς γράμμα. Το [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Θετική τιμή είναι ποσοστό της διάρκειας του εφέ· αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AsOneObject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/buildtype/#AsOneObject) απενεργοποιεί την κατασκευή παράγραφος‑για‑παράγραφο ώστε η ρύθμιση λέξεων να ισχύει σε ολόκληρο το πλαίσιο κειμένου.

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

Για κατασκευή πλαισίου κειμένου παράγραφο‑πρώτα, ορίστε το [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (ή άλλο επίπεδο παραγράφου). Για να στοχεύσετε μια μοναδική παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση του [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) που δέχεται ένα [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/). Δείτε το [Animated Text](/slides/el/androidjava/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από το πρόγραμμα προβολής παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν εκτελούν κινήσεις. Χρησιμοποιήστε την [HTML5 export](/slides/el/androidjava/export-to-html5/), animated GIF ή τη [μετατροπή βίντεο](/slides/el/androidjava/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να παρουσιάζει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και, όταν χρειάζεται, το [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Η απόδοση βίντεο υποστηρίζει πολλές κοινές εφέ εισόδου, έμφασης, εξόδου και μονοπατιού κίνησης, αλλά δεν υποστηρίζεται κάθε εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση Aspose.Slides που στοχεύετε.
- Προηγμένα προσαρμοσμένα εφέ και εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορούν να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά σε PowerPoint, HTML5 ή βίντεο. Επικυρώστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Γιατί εμφανίζεται μια κίνηση στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφάνειας δεν εκτελούνται. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν η κίνηση πρέπει να διατηρηθεί.

**Γιατί ένα εφέ εκτελείται διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει την αρχική συμπεριφορά του PowerPoint. Ορισμένα προηγμένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Ελέγξτε τον πίνακα υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν τη χρήση σε παραγωγή.

**Αλλάζει η σειρά των κινήσεων αν μετακινήσω ένα σχήμα προς τα εμπρός ή προς τα πίσω;**

Όχι. Η σειρά z‑order του σχήματος ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και τα σκανάρια ελέγχουν την αναπαραγωγή των κινήσεων. Αλλάξτε το χρονοδιάγραμμα αν χρειάζεστε διαφορετική σειρά αναπαραγωγής.