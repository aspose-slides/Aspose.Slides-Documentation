---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις με Python μέσω Java
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
description: "Μάθετε πώς να προσθέτετε, να ελέγχετε και να προσαρμόζετε τις κινήσεις σχημάτων, το χρονισμό, τους ήχους, τη συμπεριφορά μετά την κίνηση και το κείμενο με κίνηση με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via Java αναπαριστά τις κινήσεις των διαφανειών ως εφέ σε χρονοδιάγραμμα διαφάνειας. Ένα εφέ διαθέτει ένα σχήμα‑στόχο, έναν τύπο κίνησης και υπό‑τύπο, ένα ερέθισμα, ρυθμίσεις χρονισμού και προαιρετικές ιδιότητες όπως ήχος ή συμπεριφορά μετά την κίνηση.

Το χρονοδιάγραμμα περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** εκτελείται καθώς προχωρά η διαφάνεια.
- Μια **διαδραστική ακολουθία** ξεκινά όταν κάνετε κλικ στο σχήμα‑ερέθισμα.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα της διαφάνειας κληρονομούν από το [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/), χρησιμοποιείτε τη ίδια μέθοδο [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) για το μεγαλύτερο μέρος του περιεχομένου της διαφάνειας. Τα διαθέσιμα εφέ εμφανίζονται στην κλάση [EffectType](https://reference.aspose.com/slides/el/python-java/aspose.slides/effecttype/).

## **Προσθήκη Κινήσεων Σχήματος**

Για να προσθέσετε μια κίνηση, αποκτήστε την κύρια ακολουθία της διαφάνειας και καλέστε τη μέθοδο [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) με το σχήμα‑στόχο, τον τύπο εφέ, το υπό‑τύπο και το ερέθισμα. Για ένα εφέ που ξεκινά όταν κλικάρεται ένα άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία της οποίας το ερέθισμα είναι το συγκεκριμένο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τους δύο τύπους κίνησης και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

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

Το ερέθισμα ελέγχει πότε ξεκινά ένα εφέ:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/effecttriggertype/#OnClick) περιμένει κλικ στην κύρια ακολουθία ή κλικ στο σχήμα‑ερέθισμα σε μια διαδραστική ακολουθία.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/el/python-java/aspose.slides/effecttriggertype/#WithPrevious) ξεκινά με το προηγούμενο εφέ.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/el/python-java/aspose.slides/effecttriggertype/#AfterPrevious) ξεκινά όταν ολοκληρωθεί το προηγούμενο εφέ.

Για να δημιουργήσετε κίνηση σε εικόνα, διάγραμμα ή άλλο τύπο σχήματος, περάστε αυτό το αντικείμενο στη μέθοδο [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) αντί για `target_shape`. Για επιλογές ομαδοποίησης ειδικές για διαγράμματα, δείτε το [Animated Charts](/slides/el/python-java/animated-charts/).

## **Ανάγνωση Κινήσεων Σχήματος**

Χρησιμοποιήστε τη μέθοδο [Sequence.getEffectsByShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#getEffectsByShape) όταν γνωρίζετε το σχήμα‑στόχο. Για να εξετάσετε κάθε εφέ, επαναλάβετε την κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η επανάληψη αποφεύγει την υπόθεση ότι μια ακολουθία περιέχει εφέ στη θέση `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κυρίως‑ακολουθίας και διαδραστικής ακολουθίας, λαμβάνει τα εφέ που στοχεύουν το σχήμα και, στη συνέχεια, επαναλαμβάνει κάθε ακολουθία στη διαφάνεια.

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

Εάν χρειάζεστε τα εφέ μόνο για ένα σχήμα, πρώτα προσδιορίστε το σχήμα με το όνομα, τον τύπο placeholder ή κάποια άλλη σταθερή ιδιότητα· στη συνέχεια καλέστε τη μέθοδο [Sequence.getEffectsByShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#getEffectsByShape). Μην υποθέτετε ότι το [ShapeCollection.get_Item](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#get_Item) στη θέση `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Δουλειά με Κληρονομημένα Εφέ Placeholder**

Ένα placeholder σε μια κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο placeholder στη διαφάνεια διάταξης και στη διαφάνεια μάστερ. Η μέθοδος [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getBasePlaceholder) επιστρέφει το γονικό placeholder, ή `None` εάν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στη κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στη διαφάνεια μάστερ.

![Εφέ κίνησης υποσέλιδου στη κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στη διαφάνεια διάταξης](layout-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στη διαφάνεια μάστερ](master-shape-animation.png)

Το επόμενο παράδειγμα χρησιμοποιεί μια ιεραρχία placeholders από μια νέα παρουσίαση. Προσθέτει εφέ σε ένα master placeholder, ένα layout placeholder και το αντίστοιχο placeholder σε μια κανονική διαφάνεια. Κάθε κλήση στη μέθοδο [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getBasePlaceholder) ελέγχεται πριν χρησιμοποιηθεί το επιστρεφόμενο σχήμα.

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

Το παράθυρο διαλόγου **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες του [Timing](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/).

![Διάλογος Timing του PowerPoint για ένα εφέ κίνησης](shape-animation.png)

- **Start** αντιστοιχεί στο [Timing.getTriggerType](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** αντιστοιχεί στο [Timing.getDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getDuration), σε δευτερόλεπτα.
- **Delay** αντιστοιχεί στο [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getTriggerDelayTime), σε δευτερόλεπτα.
- **Repeat** αντιστοιχεί στα [Timing.getRepeatCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatUntilNextClick) ή [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** αντιστοιχεί στο [Timing.getRewind](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRewind).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει τον χρονισμό του μέσω του αντικειμένου που επιστρέφει η [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) και αποθηκεύει το αποτέλεσμα. Η διατήρηση της επιστρεφόμενης αναφοράς [Effect](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/) αποτρέπει την ανάγκη μη απαραίτητου δείκτη συλλογής.

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

Χρησιμοποιήστε μια μόνο λειτουργία επανάληψης σκόπιμα. Ο συνδυασμός μετρητή επανάληψης με σημαία «until» μπορεί να οδηγήσει σε συγκεχυμένα αποτελέσματα σε διαφορετικούς προβολείς. Όταν αλλάζετε λειτουργίες επανάληψης, ορίστε πρώτα το [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#setRepeatUntilNextClick) και το [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) πριν το [Timing.setRepeatCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#setRepeatCount), επειδή ο ορισμός οποιασδήποτε σημαίας αλλάζει και τη ενεργή λειτουργία επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφέρει ενσωματωμένο ήχο μέσω της [Effect.getSound](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getSound). Η [Effect.setStopPreviousSound](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#setStopPreviousSound) λέει σε ένα εφέ να σταματήσει ήχο που έχει ξεκινήσει ένα προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Εφέ**

Το παρακάτω παράδειγμα απαιτεί ένα τοπικό αρχείο ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει το αρχείο ως ήχο για το πρώτο εφέ και ρυθμίζει το δεύτερο εφέ να σταματήσει τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφει η [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect), οπότε δεν απαιτείται δείκτης ακολουθίας.

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

Το παρακάτω παράδειγμα απαιτεί μια τοπική παρουσίαση με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο την κύρια όσο και τη διαδραστική ακολουθία και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκθέτει η [Audio.getContentType](https://reference.aspose.com/slides/el/python-java/aspose.slides/audio/#getContentType).

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

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε την [Audio.getStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/audio/#getStream) και αντιγράψτε το ρεύμα σε αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε έναν πίνακα byte.

## **Ορισμός Συμπεριφορας Μετά την Κίνηση**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα μετά το τέλος του εφέ.

![Διάλογος επιλογών εφέ του PowerPoint που εμφανίζει ρυθμίσεις After animation](shape-after-animation.png)

Η κλάση [AfterAnimationType](https://reference.aspose.com/slides/el/python-java/aspose.slides/afteranimationtype/) υποστηρίζει την παραμονή του σχήματος αμετάβλητο, την αλλαγή του χρώματος, την απόκρυψη του μετά την κίνηση ή την απόκρυψη του με το επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.Color](https://reference.aspose.com/slides/el/python-java/aspose.slides/afteranimationtype/#Color), ορίστε επίσης το [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getAfterAnimationColor).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά του μετά την κίνηση μέσω του επιστρεφόμενου αντικειμένου εφέ και αποθηκεύει το αποτέλεσμα.

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

Η αλλαγή του τύπου από το [AfterAnimationType.Color](https://reference.aspose.com/slides/el/python-java/aspose.slides/afteranimationtype/#Color) καθαρίζει τη ρύθμιση χρώματος μετά την κίνηση.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο σχετικούς ελέγχους:

- Η μέθοδος [TextAnimation.getBuildType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textanimation/#getBuildType) ελέγχει αν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- Η μέθοδος [Effect.getAnimateTextType](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getAnimateTextType) ελέγχει αν το κείμενο εμφανίζεται όλο μονομιάς, ανά λέξη ή ανά γράμμα. Η [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getDelayBetweenTextParts) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μία θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AsOneObject](https://reference.aspose.com/slides/el/python-java/aspose.slides/buildtype/#AsOneObject) απενεργοποιεί την κατασκευή παράγραφος‑κατά‑παράγραφο ώστε η ρύθμιση λέξης να ισχύει για ολόκληρο το πλαίσιο κειμένου.

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

Για να χτίσετε ένα πλαίσιο κειμένου ανά παράγραφο, ορίστε το [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/el/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (ή κάποιο άλλο επίπεδο παραγράφου). Για να στοχεύσετε μία συγκεκριμένη παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση της [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) που δέχεται ένα αντικείμενο [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/). Δείτε το [Animated Text](/slides/el/python-java/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από τον προβολέα παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν αναπαράγουν κίνησεις. Χρησιμοποιήστε την [HTML5 export](/slides/el/python-java/export-to-html5/), GIF animation ή τη [video conversion](/slides/el/python-java/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateShapes) και, εφόσον χρειαστεί, το [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Η απόδοση βίντεο υποστηρίζει πολλές κοινές εφέ εισαγωγής, έμφασης, εξόδου και διαδρομής κίνησης, αλλά δεν υποστηρίζει κάθε εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση του Aspose.Slides που χρησιμοποιείτε.
- Τα προσαρμοσμένα εφέ και τα εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο, αλλά να αποδοθούν διαφορετικά στο PowerPoint, HTML5 ή βίντεο. Επαληθεύστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **Συχνές Ερωτήσεις**

**Γιατί εμφανίζεται μια κίνηση στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφανειών δεν παίζονται. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν είναι απαραίτητη η κίνηση.

**Γιατί ένα εφέ παίζει διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει τη συμπεριφορά του αρχικού PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Ελέγξτε τον πίνακα των υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν τη χρήση σε παραγωγή.

**Αλλάζει η σειρά των κινήσεων όταν μετακινείται ένα σχήμα εμπρός ή πίσω;**

Όχι. Η σειρά z‑order ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και τα ερεθίσματα ελέγχουν την αναπαραγωγή της κίνησης. Αλλάξτε το χρονοδιάγραμμα εάν χρειάζεστε διαφορετική σειρά αναπαραγωγής.