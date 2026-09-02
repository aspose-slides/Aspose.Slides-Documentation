---
title: Εφαρμογή Κινητών Σχημάτων σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Κίνηση Σχημάτων
type: docs
weight: 60
url: /el/nodejs-java/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- κινητό σχήμα
- κινητό κείμενο
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να ελέγχετε και να προσαρμόζετε τα κινούμενα σχήματα, τον χρονισμό, τους ήχους, τη συμπεριφορά μετά το κίνημα και το κείμενο με κίνηση με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for Node.js μέσω Java αντιπροσωπεύει τις κινήσεις διαφανειών ως εφέ σε μια χρονογραμμή διαφάνειας. Ένα εφέ έχει ένα σχήμα‑στόχο, έναν τύπο και υποτύπο κίνησης, έναν ενεργοποιητή, ρυθμίσεις χρονισμού και προαιρετικές ιδιότητες όπως ήχο ή συμπεριφορά μετά το εφέ.

Η χρονογραμμή περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζεται καθώς η διαφάνεια προχωρά.
- Μια **διαδραστική ακολουθία** ξεκινά όταν το σχήμα‑ενεργοποιητής της γίνεται κλικ.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας είναι αντικείμενα [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) , χρησιμοποιείτε την ίδια μέθοδο [Sequence.addEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#addEffect) για τα περισσότερα περιεχόμενα διαφάνειας. Τα διαθέσιμα εφέ αναγράφονται στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effecttype/).

## **Προσθήκη Κινητών Σχημάτων**

Για να προσθέσετε ένα κίνημα, λάβετε την κύρια ακολουθία της διαφάνειας και καλέστε [Sequence.addEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#addEffect) με το σχήμα‑στόχο, τον τύπο εφέ, τον υποτύπο και τον ενεργοποιητή. Για εφέ που ξεκινά όταν κλικάρεται ένα άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία της οποίας ο ενεργοποιητής είναι το συγκεκριμένο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τα δύο είδη κινήματος και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ο ενεργοποιητής ελέγχει πότε ξεκινά ένα εφέ:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effecttriggertype/#OnClick) περιμένει ένα κλικ στην κύρια ακολουθία ή ένα κλικ στο σχήμα‑ενεργοποιητή σε μια διαδραστική ακολουθία.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) αρχίζει μαζί με το προηγούμενο εφέ.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) αρχίζει όταν ολοκληρωθεί το προηγούμενο εφέ.

Για να κινήσετε μια εικόνα, διάγραμμα ή άλλο τύπο σχήματος, περάστε το αντικείμενο στο [Sequence.addEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#addEffect) αντί για `targetShape`. Για επιλογές ομαδοποίησης ειδικές για διαγράμματα, δείτε [Animated Charts](/slides/el/nodejs-java/animated-charts/).

## **Ανάγνωση Κινητών Σχήματος**

Χρησιμοποιήστε [Sequence.getEffectsByShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#getEffectsByShape) όταν γνωρίζετε το σχήμα‑στόχο. Για να ελέγξετε κάθε εφέ, απαριθμήστε την κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η απαρίθμηση αποτρέπει την παρανόηση ότι μια ακολουθία περιέχει εφέ στη θέση `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας‑ακολουθίας και διαδραστικά εφέ, παίρνει τα εφέ που στοχεύουν το σχήμα, και στη συνέχεια απαριθμεί κάθε ακολουθία στη διαφάνεια.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

Εάν χρειάζεστε μόνο τα εφέ για ένα σχήμα, πρώτα προσδιορίστε το σχήμα με όνομα, τύπο placeholder ή άλλη σταθερή ιδιότητα· μετά καλέστε [Sequence.getEffectsByShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Μην υποθέτετε ότι [ShapeCollection.get_Item](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#get_Item) στη θέση `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Εργασία με Κληρονομημένα Εφέ Καθηλωτή**

Ένα placeholder σε κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο placeholder στη διάταξη και στο κύριο πρότυπο. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getBasePlaceholder) επιστρέφει το γονικό placeholder, ή `null` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στη κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στη διαφάνεια προτύπου.

![Εφέ κίνησης υποσέλιδου στη κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στη διαφάνεια διάταξης](layout-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στη κύρια διαφάνεια](master-shape-animation.png)

Το επόμενο παράδειγμα χρησιμοποιεί μια ιεραρχία placeholders από μια νέα παρουσίαση. Προσθέτει εφέ σε ένα placeholder προτύπου, ένα placeholder διάταξης και το αντίστοιχο placeholder σε μια κανονική διαφάνεια. Κάθε κλήση στο [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getBasePlaceholder) ελέγχεται πριν χρησιμοποιηθεί το shape που επιστρέφεται.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αλλαγή Χρονισμού Κίνησης**

Ο διάλογος **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες του [Timing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/).

![Διάλογος Χρονισμού PowerPoint για εφέ κίνησης](shape-animation.png)

- **Έναρξη** αντιστοιχεί σε [Timing.getTriggerType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Διάρκεια** αντιστοιχεί σε [Timing.getDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getDuration), σε δευτερόλεπτα.
- **Καθυστέρηση** αντιστοιχεί σε [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), σε δευτερόλεπτα.
- **Επανάληψη** αντιστοιχεί σε [Timing.getRepeatCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) ή [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Επαναφορά όταν ολοκληρωθεί η αναπαραγωγή** αντιστοιχεί σε [Timing.getRewind](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getRewind).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει τον χρονισμό του μέσω του αντικειμένου που επιστρέφεται από το [Sequence.addEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#addEffect) και αποθηκεύει το αποτέλεσμα. Η διατήρηση της αναφοράς στο [Effect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/) που επιστρέφεται αποτρέπει ανεπιθύμητη πρόσβαση σε δείκτη συλλογής.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός μετρητή επανάληψης με σημαία «μέχρι» μπορεί να δημιουργήσει συγχύσιμα αποτελέσματα σε διαφορετικούς προβολείς. Κατά την αλλαγή των τρόπων επανάληψης, ορίστε πρώτα [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) και [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) πριν το [Timing.setRepeatCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#setRepeatCount), επειδή το να θέσετε οποιαδήποτε από τις σημαίες αλλάζει επίσης την ενεργή λειτουργία επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφέρεται σε ενσωματωμένο ήχο μέσω του [Effect.getSound](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getSound). Το [Effect.setStopPreviousSound](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setStopPreviousSound) ζητά από ένα εφέ να σταματήσει ήχο που ξεκίνησε από προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Εφέ**

Το παρακάτω παράδειγμα απαιτεί ένα τοπικό αρχείο ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει το αρχείο ως ήχο για το πρώτο εφέ και ρυθμίζει το δεύτερο εφέ να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφει το [Sequence.addEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#addEffect), οπότε δεν απαιτείται δείκτης ακολουθίας.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Εξαγωγή Ενσωματωμένων Ήχων Εφέ**

Το παρακάτω παράδειγμα απαιτεί μια τοπική παρουσίαση με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο τις κύριες όσο και τις διαδραστικές ακολουθίες και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκτίθεται από το [Audio.getContentType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audio/#getContentType).

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [Audio.getStream](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audio/#getStream) και αντιγράψτε το ρεύμα σε αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε πίνακα byte.

## **Ορισμός Συμπεριφοράς Μετά το Κίνημα**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα αφού το εφέ του ολοκληρωθεί.

![Διάλογος Επιλογών Εφέ PowerPoint που δείχνει ρυθμίσεις Μετά το κίνημα](shape-after-animation.png)

Η απαρίθμηση [AfterAnimationType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/afteranimationtype/) υποστηρίζει να αφήνει το σχήμα αμετάβλητο, να αλλάζει το χρώμα του, να το κρύβει μετά το κίνημα ή να το κρύβει στο επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.Color](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/afteranimationtype/#Color), ορίστε επίσης το [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά το κίνημα μέσω του αντικειμένου εφέ που επιστρέφεται, και αποθηκεύει το αποτέλεσμα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αλλάζοντας τον τύπο από το [AfterAnimationType.Color](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/afteranimationtype/#Color) διαγράφει τη ρύθμιση χρώματος μετά το κίνημα.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο σχετικές ρυθμίσεις:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textanimation/#getBuildType) ελέγχει αν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getAnimateTextType) ελέγχει αν το κείμενο εμφανίζεται ολόκληρο, ανά λέξη ή ανά γράμμα. Το [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μια θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AsOneObject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/buildtype/#AsOneObject) απενεργοποιεί την κατασκευή παράγραφος‑από‑παράγραφο ώστε η ρύθμιση λέξης να ισχύει σε ολόκληρο το πλαίσιο κειμένου.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να κατασκευάσετε ένα πλαίσιο κειμένου ανά παράγραφο, ορίστε το [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (ή άλλο επίπεδο παραγράφου). Για να στοχεύσετε μια μόνο παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση του [Sequence.addEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#addEffect) που δέχεται ένα [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/). Δείτε το [Animated Text](/slides/el/nodejs-java/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από το πρόγραμμα προβολής παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν παίζουν κινήσεις. Χρησιμοποιήστε την εξαγωγή σε [HTML5](/slides/el/nodejs-java/export-to-html5/), animated GIF ή [μετατροπή σε βίντεο](/slides/el/nodejs-java/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/html5options/#setAnimateShapes) και, όταν χρειάζεται, το [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Η απόδοση βίντεο υποστηρίζει πολλά κοινά εφέ εισόδου, έντονης έμφασης, εξόδου και μονοπατιού κίνησης, αλλά δεν υποστηρίζει κάθε εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [υποστηριζόμενες κινήσεις και εφέ](/slides/el/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση του Aspose.Slides που χρησιμοποιείτε.
- Προηγμένα προσαρμοσμένα εφέ και εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά στο PowerPoint, HTML5 ή βίντεο. Επαληθεύστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **Συχνές Ερωτήσεις**

**Γιατί ένα κίνημα εμφανίζεται στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφανειών δεν παίζονται. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν η κίνηση πρέπει να διατηρηθεί.

**Γιατί ένα εφέ παίζει διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει την αρχική συμπεριφορά του PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Εξετάστε τον πίνακα των υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν την παραγωγική χρήση.

**Αλλάζει η μετακίνηση ενός σχήματος προς τα εμπρός ή πίσω τη σειρά των κινήσεων;**

Όχι. Η σειρά z‑order ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και οι ενεργοποιητές ελέγχουν την αναπαραγωγή των κινήσεων. Αλλάξτε τη χρονογραμμή αν χρειάζεται διαφορετική σειρά αναπαραγωγής.