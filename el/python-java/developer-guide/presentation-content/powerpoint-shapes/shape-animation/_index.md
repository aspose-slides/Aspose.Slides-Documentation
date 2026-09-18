---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις Χρησιμοποιώντας Python μέσω Java
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/python-java/shape-animation/
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
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να ελέγχετε και να προσαρμόζετε τις κινήσεις σχημάτων, τον χρονισμό, τους ήχους, τη συμπεριφορά μετά το εφέ και το κινούμενο κείμενο με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Για να εργάζεστε με τις μεμονωμένες συμπεριφορές μέσα σε ένα εφέ ή να επεξεργαστείτε τμήματα διαδρομής κίνησης, δείτε [Προσαρμοσμένη Κίνηση](/slides/el/python-java/custom-animation/).

Aspose.Slides for Python via Java αντιπροσωπεύει τις κινήσεις των διαφανειών ως εφέ σε χρονοδιάγραμμα διαφάνειας. Ένα εφέ έχει ένα σχήμα-στόχο, τύπο κίνησης και υποτύπο, ένα ενεργοποιητή, ρυθμίσεις χρονομέτρησης και προαιρετικές ιδιότητες όπως ήχο ή συμπεριφορά μετά το εφέ.

Το χρονοδιάγραμμα περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς η διαφάνεια προχωρά.
- Μια **διαδραστική ακολουθία** ξεκινά όταν το σχήμα-ενεργοποιητής κλικαριστεί.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας κληρονομούν από το [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/), χρησιμοποιείτε την ίδια μέθοδο [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) για το μεγαλύτερο μέρος του περιεχομένου της διαφάνειας. Τα διαθέσιμα εφέ αναγράφονται στην κλάση [EffectType](https://reference.aspose.com/slides/el/python-java/aspose.slides/effecttype/).

## **Προσθήκη Κινήσεων σε Σχήματα**

Για να προσθέσετε μια κίνηση, λάβετε την κύρια ακολουθία της διαφάνειας και καλέστε την [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) με το σχήμα-στόχο, τον τύπο εφέ, τον υποτύπο και τον ενεργοποιητή. Για ένα εφέ που ξεκινά όταν κλικαριστεί ένα άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία του οποίου ο ενεργοποιητής είναι αυτό το άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τα δύο τύπους κίνησης και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ο ενεργοποιητής ελέγχει πότε ξεκινά ένα εφέ:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/effecttriggertype/#OnClick) περιμένει κλικ στην κύρια ακολουθία ή κλικ στο σχήμα-ενεργοποιητή σε μια διαδραστική ακολουθία.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/el/python-java/aspose.slides/effecttriggertype/#WithPrevious) ξεκινά με το προηγούμενο εφέ.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/el/python-java/aspose.slides/effecttriggertype/#AfterPrevious) ξεκινά όταν το προηγούμενο εφέ ολοκληρωθεί.

Για να μετακινήσετε μια εικόνα, διάγραμμα ή άλλο τύπο σχήματος, περάστε εκείνο το αντικείμενο στην [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) αντί του `target_shape`. Για επιλογές ομαδοποίησης ειδικές για διαγράμματα, δείτε [Animated Charts](/slides/el/python-java/animated-charts/).

## **Ανάγνωση Κινήσεων Σχήματος**

Χρησιμοποιήστε την [Sequence.getEffectsByShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#getEffectsByShape) όταν γνωρίζετε το σχήμα-στόχο. Για να εξετάσετε κάθε εφέ, επαναλάβετε την κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η επανάληψη αποφεύγει την υπόθεση ότι μια ακολουθία περιέχει εφέ στο ευρετήριο `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με κύριες και διαδραστικές ενέργειες, λαμβάνει τα εφέ που στοχεύουν το σχήμα και, στη συνέχεια, επαναλαμβάνει κάθε ακολουθία στη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Αν χρειάζεστε μόνο τα εφέ για ένα σχήμα, πρώτα προσδιορίστε το σχήμα κατά όνομα, τύπο πλατφόρμας ή άλλη σταθερή ιδιότητα· στη συνέχεια καλέστε την [Sequence.getEffectsByShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#getEffectsByShape). Μην θεωρείτε ότι η [ShapeCollection.get_Item](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#get_Item) στο ευρετήριο `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Δουλειά με Κληρονομημένα Εφέ Πλατφόρμας**

Ένα placeholder σε μια κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο placeholder στη διαφάνεια διάταξης και στο master. Η μέθοδος [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getBasePlaceholder) επιστρέφει το γονικό placeholder, ή `None` όταν δεν υπάρχει γονέας.

Στο παρακάτω παράδειγμα παρουσίασης, το υποσέλιδο έχει **Random Bars** στη κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στη master διαφάνεια.

![Περιγραφή εφέ animation στο υποσέλιδο της κανονικής διαφάνειας](slide-shape-animation.png)

![Περιγραφή εφέ animation στο υποσέλιδο της διαφάνειας διάταξης](layout-shape-animation.png)

![Περιγραφή εφέ animation στο υποσέλιδο της master διαφάνειας](master-shape-animation.png)

Το επόμενο παράδειγμα χρησιμοποιεί μια ιεραρχία placeholder από μια νέα παρουσίαση. Προσθέτει εφέ σε ένα master placeholder, ένα layout placeholder και το αντίστοιχο placeholder σε μια κανονική διαφάνεια. Κάθε κλήση στη [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getBasePlaceholder) ελέγχεται πριν το επιστρεφόμενο σχήμα χρησιμοποιηθεί.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αλλαγή Χρονισμού Κίνησης**

Ο διάλογος **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες του [Timing](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/).

![Διάλογος Timing του PowerPoint για ένα εφέ κίνησης](shape-animation.png)

- **Start** αντιστοιχεί στη [Timing.getTriggerType](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** αντιστοιχεί στη [Timing.getDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getDuration), σε δευτερόλεπτα.
- **Delay** αντιστοιχεί στη [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getTriggerDelayTime), σε δευτερόλεπτα.
- **Repeat** αντιστοιχεί στη [Timing.getRepeatCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatUntilNextClick) ή [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** αντιστοιχεί στη [Timing.getRewind](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRewind).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει το χρονισμό του μέσω του αντικειμένου που επιστρέφει η [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) και αποθηκεύει το αποτέλεσμα. Η διατήρηση της αναφοράς του επιστρεφόμενου [Effect](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/) αποτρέπει την περιττή συλλογή ευρετηρίου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός αριθμού επανάληψης με μια σημαία «until» μπορεί να παράγει συγκεχυμένα αποτελέσματα σε διαφορετικούς προσαρμογείς. Καθώς αλλάζετε τους τρόπους επανάληψης, ορίστε πρώτα τη [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#setRepeatUntilNextClick) και τη [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) πριν τη [Timing.setRepeatCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#setRepeatCount), επειδή ο ορισμός οποιασδήποτε σημαίας αλλάζει επίσης τη δραστήρια λειτουργία επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφέρει ενσωματωμένο ήχο μέσω της [Effect.getSound](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getSound). Η [Effect.setStopPreviousSound](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#setStopPreviousSound) λέει σε ένα εφέ να σταματήσει ήχο που ξεκίνησε από προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Εφέ**

Το παρακάτω παράδειγμα υποθέτει ότι υπάρχει τοπικό αρχείο ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει το αρχείο ως ήχο για το πρώτο εφέ και ρυθμίζει το δεύτερο εφέ να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφει η [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect), επομένως δεν απαιτείται ευρετήριο ακολουθίας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Εξαγωγή Ενσωματωμένων Ήχων Εφέ**

Το παρακάτω παράδειγμα υποθέτει μια τοπική παρουσίαση με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο τις κύριες όσο και τις διαδραστικές ακολουθίες και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκτίθεται από την [Audio.getContentType](https://reference.aspose.com/slides/el/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε την [Audio.getStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/audio/#getStream) και αντιγράψτε τη ροή σε αρχείο αντί να φορτώνετε ολόκληρο το αντικείμενο σε byte array.

## **Ορισμός Συμπεριφοράς Μετά το Εφέ**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα μετά το τέλος του εφέ.

![Διάλογος Επιλογών Εφέ του PowerPoint που δείχνει τις ρυθμίσεις After animation](shape-after-animation.png)

Η κλάση [AfterAnimationType](https://reference.aspose.com/slides/el/python-java/aspose.slides/afteranimationtype/) υποστηρίζει την διατήρηση του σχήματος αμετάβλητου, την αλλαγή του χρώματός του, την απόκρυψή του μετά την κίνηση ή την απόκρυψή του με το επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.Color](https://reference.aspose.com/slides/el/python-java/aspose.slides/afteranimationtype/#Color), ορίστε επίσης την [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getAfterAnimationColor).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά την κίνηση μέσω του αντικειμένου εφέ που επιστρέφεται και αποθηκεύει το αποτέλεσμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αλλαγή του τύπου από [AfterAnimationType.Color](https://reference.aspose.com/slides/el/python-java/aspose.slides/afteranimationtype/#Color) αφαιρεί τη ρύθμιση χρώματος μετά το εφέ.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο συναφή ελέγχους:

- Η μέθοδος [TextAnimation.getBuildType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textanimation/#getBuildType) ελέγχει εάν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- Η μέθοδος [Effect.getAnimateTextType](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getAnimateTextType) ελέγχει εάν το κείμενο εμφανίζεται όλο μαζί, λέξη-λέξη ή γράμμα-γράμμα. Η [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getDelayBetweenTextParts) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μια θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κουνά τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AsOneObject](https://reference.aspose.com/slides/el/python-java/aspose.slides/buildtype/#AsOneObject) απενεργοποιεί τη δημιουργία παραγράφου-παράγραφος έτσι ώστε η ρύθμιση λέξης να ισχύει για ολόκληρο το πλαίσιο κειμένου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για να δημιουργήσετε ένα πλαίσιο κειμένου παράγραφο-παράγραφο, ορίστε το [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/el/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (ή κάποιο άλλο επίπεδο παραγράφου). Για να στοχεύσετε μια μοναδική παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση της [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) που δέχεται ένα [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/). Δείτε το [Animated Text](/slides/el/python-java/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Εξαγωγή και Σημειώσεις Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από τον προγυμναστή παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν παίζουν κίνησεις. Χρησιμοποιήστε την [HTML5 export](/slides/el/python-java/export-to-html5/), animated GIF ή [video conversion](/slides/el/python-java/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε την [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateShapes) και, όταν χρειάζεται, την [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Η απόδοση βίντεο υποστηρίζει πολλά κοινά εφέ εισόδου, έμφασης, εξόδου και διαδρομής κίνησης, αλλά δεν υποστηρίζονται όλα τα εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση Aspose.Slides που στοχεύετε.
- Προηγμένα προσαρμοσμένα εφέ και εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά σε PowerPoint, HTML5 ή βίντεο. Επικυρώστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **FAQ**

**Γιατί ένα animation εμφανίζεται στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, έτσι τα animation και οι μεταβάσεις διαφανειών δεν παίζονται. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν η κίνηση πρέπει να διατηρηθεί.

**Γιατί ένα εφέ παίζει διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τα animation αντί να αποθηκεύει τη συμπεριφορά του αρχικού PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται κατά προσέγγιση. Ελέγξτε τον πίνακα των υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν την παραγωγική χρήση.

**Αλλάζει η προώθηση ή η ανάθεση ενός σχήματος τη σειρά των animation;**

Όχι. Η σειρά z-order ενός σχήματος ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και οι ενεργοποιητές ελέγχουν την αναπαραγωγή των animation. Αλλάξτε το χρονοδιάγραμμα εάν χρειάζεστε διαφορετική σειρά αναπαραγωγής.