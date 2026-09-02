---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις με Python
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/python-net/shape-animation/
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
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, ελέγχετε και προσαρμόζετε κινήσεις σχημάτων, χρονισμούς, ήχους, συμπεριφορά μετά την κίνηση και κείμενο με κίνηση, με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via .NET αντιπροσωπεύει τις κινήσεις των διαφανειών ως εφέ σε χρονική γραμμή διαφάνειας. Ένα εφέ έχει σχήμα‑στόχο, τύπο και υπό‑τύπο κίνησης, ένα σκανδάλη, ρυθμίσεις χρόνου και προαιρετικές ιδιότητες όπως ήχος ή συμπεριφορά μετά την κίνηση.

Η χρονική γραμμή περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς προχωρά η διαφάνεια.
- Μια **διαδραστική ακολουθία** ξεκινά όταν κλικάρεται το σχήμα‑σκανδάλη.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας υλοποιούν το [IShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishape/), χρησιμοποιείτε την ίδια μέθοδο [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) για το μεγαλύτερο μέρος του περιεχομένου της διαφάνειας. Τα διαθέσιμα εφέ καταγράφονται στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttype/).

## **Προσθήκη Κινήσεων Σχημάτων**

Για να προσθέσετε μια κίνηση, πάρτε την κύρια ακολουθία της διαφάνειας και καλέστε το [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) με το σχήμα‑στόχο, τον τύπο εφέ, τον υπό‑τύπο και το σκανδάλη. Για ένα εφέ που ξεκινά όταν κλικάρεται ένα άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία της οποίας το σκανδάλη είναι εκείνο το άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τους δύο τύπους κίνησης και αποθηκεύει το αποτέλεσμα σε `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

Το σκανδάλη ελέγχει πότε ξεκινά ένα εφέ:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/) περιμένει ένα κλικ στην κύρια ακολουθία, ή κλικ στο σχήμα‑σκανδάλη σε μια διαδραστική ακολουθία.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/) ξεκινά μαζί με το προηγούμενο εφέ.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/) ξεκινά όταν το προηγούμενο εφέ ολοκληρωθεί.

Για να κινηθεί μια εικόνα, ένα διάγραμμα ή οποιοσδήποτε άλλος τύπος σχήματος, περάστε αυτό το αντικείμενο στο [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) αντί για το `target_shape`. Για επιλογές ομαδοποίησης ειδικές σε διαγράμματα, δείτε το [Animated Charts](/slides/el/python-net/animated-charts/).

## **Ανάγνωση Κινήσεων Σχημάτων**

Χρησιμοποιήστε το [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) όταν γνωρίζετε το σχήμα‑στόχο. Για να εξετάσετε κάθε εφέ, επαναλάβετε τη βήμα‑βήμα τη κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η επανάληψη αποτρέπει την υπόθεση ότι μια ακολουθία περιέχει εφέ στο δείκτη `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας και διαδραστικής ακολουθίας, λαμβάνει τα εφέ που στοχεύουν το σχήμα, και μετά επαναλαμβάνει κάθε ακολουθία στη διαφάνεια.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Αν χρειάζεστε μόνο τα εφέ για ένα σχήμα, πρώτα προσδιορίστε το σχήμα κατά όνομα, τύπο σύμβουλου ή άλλη σταθερή ιδιότητα· έπειτα καλέστε το [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Μην υποθέτετε ότι το σχήμα στο δείκτη `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Δουλειά με Κληρονομημένα Εφέ Σύμβουλου**

Ένας σύμβουλος (placeholder) σε κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από τον αντίστοιχο σύμβουλο στη διάταξη και στη μητρική διαφάνειά του. Το [Shape.get_base_placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_base_placeholder/) επιστρέφει εκείνο τον γονικό σύμβουλο, ή `None` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στην κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στη μητρική διαφάνεια.

![Εφέ κίνησης υποσέλιδου στην κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ κίνησης συμβούλου υποσέλιδου στη διαφάνεια διάταξης](layout-shape-animation.png)

![Εφέ κίνησης συμβούλου υποσέλιδου στη μητρική διαφάνεια](master-shape-animation.png)

Το επόμενο παράδειγμα κατασκευάζει την ιεραρχία των συμβουλών από μόνο του. Προσθέτει εφέ σε έναν σύμβουλο μητρικής διαφάνειας, έναν σύμβουλο διάταξης και τον αντίστοιχο σύμβουλο σε κανονική διαφάνεια. Κάθε κλήση στο [Shape.get_base_placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_base_placeholder/) ελέγχεται πριν το επιστρεφόμενο σχήμα χρησιμοποιηθεί.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή Χρόνου Κίνησης**

Ο διάλογος **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες του [Timing](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/).

![Διάλογος Timing του PowerPoint για ένα εφέ κίνησης](shape-animation.png)

- **Start** αντιστοιχεί στο [Timing.trigger_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** αντιστοιχεί στο [Timing.duration](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/duration/), σε δευτερόλεπτα.
- **Delay** αντιστοιχεί στο [Timing.trigger_delay_time](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/trigger_delay_time/), σε δευτερόλεπτα.
- **Repeat** αντιστοιχεί στο [Timing.repeat_count](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_next_click/), ή [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rewind when done playing** αντιστοιχεί στο [Timing.rewind](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/rewind/).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει το χρόνο του μέσω του αντικειμένου που επιστρέφεται από το [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/), και αποθηκεύει το αποτέλεσμα. Διατηρώντας την επιστρεφόμενη αναφορά [Effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/) αποφεύγεται ένας περιττός δείκτης συλλογής.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός ενός αριθμού επαναλήψεων με μια σημαία «until» μπορεί να προκαλέσει συγκεχυμένα αποτελέσματα σε διαφορετικούς αναγνώστες. Όταν αλλάζετε τρόπους επανάληψης, ορίστε πρώτα τα [Timing.repeat_until_next_click](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_next_click/) και [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) πριν το [Timing.repeat_count](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_count/), επειδή ο ορισμός οποιασδήποτε σημαίας αλλάζει επίσης τον ενεργό τρόπο επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφερθεί σε ενσωματωμένο ήχο μέσω του [Effect.sound](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/sound/). Το [Effect.stop_previous_sound](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/stop_previous_sound/) λέει σε ένα εφέ να σταματήσει ήχο που ξεκίνησε από προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Ένα Εφέ**

Το παρακάτω παράδειγμα απαιτεί τοπικό αρχείο ήχου με το όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει αυτό το αρχείο ως ήχο για το πρώτο εφέ, και ρυθμίζει το δεύτερο εφέ να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφονται από το [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/), οπότε δεν απαιτείται δείκτης ακολουθίας.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Εξαγωγή Ενσωματωμένων Ήχων Εφέ**

Το παρακάτω παράδειγμα απαιτεί τοπική παρουσίαση με το όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει και τις κύριες και τις διαδραστικές ακολουθίες και γράφει κάθε ενσωματωμένο ήχο εφέ στον κατάλογο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME ήχου που εκτίθεται από το [Audio.content_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [Audio.get_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides/audio/get_stream/) και αντιγράψτε το ρεύμα σε αρχείο αντί να φορτώνετε ολόκληρο το αντικείμενο σε πίνακα byte.

## **Ορισμός Συμπεριφοράς Μετά την Κίνηση**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα μετά το τέλος του εφέ του.

![Διάλογος Επιλογών Εφέ του PowerPoint που εμφανίζει τις ρυθμίσεις After animation](shape-after-animation.png)

Η απαρίθμηση [AfterAnimationType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/) υποστηρίζει τη διατήρηση του σχήματος αμετάβλητου, την αλλαγή του χρώματός του, την απόκρυψή του μετά την κίνηση ή την απόκρυψή του στο επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.COLOR](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/), ορίστε επίσης το [Effect.after_animation_color](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/after_animation_color/).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά του μετά την κίνηση μέσω του επιστρεφόμενου αντικειμένου εφέ, και αποθηκεύει το αποτέλεσμα.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Αλλάζοντας τον τύπο από το [AfterAnimationType.COLOR](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/), η ρύθμιση χρώματος μετά την κίνηση διαγράφεται.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο σχετιζόμενους ελέγχους:

- [TextAnimation.build_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/textanimation/build_type/) ελέγχει αν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- [Effect.animate_text_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/animate_text_type/) ελέγχει αν το κείμενο εμφανίζεται ολόκληρο, λέξη‑με‑λέξη ή γράμμα‑με‑γράμμα. Το [Effect.delay_between_text_parts](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/delay_between_text_parts/) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μία θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/buildtype/) απενεργοποιεί τη δημιουργία παραγράφου‑με‑παράγραφο ώστε η ρύθμιση λέξης να ισχύει σε όλο το πλαίσιο κειμένου.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Για να δημιουργήσετε ένα πλαίσιο κειμένου παράγραφος‑με‑παράγραφο, ορίστε το [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/buildtype/) (ή κάποιο άλλο επίπεδο παραγράφου). Για να στοχεύσετε μία μόνο παράγραφο με το δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση του [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) που δέχεται ένα [IParagraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/iparagraph/). Δείτε το [Animated Text](/slides/el/python-net/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από το πρόγραμμα προβολής παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν παίζουν κίνηση. Χρησιμοποιήστε την [HTML5 export](/slides/el/python-net/export-to-html5/), animated GIF, ή τη [video conversion](/slides/el/python-net/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.animate_shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/html5options/animate_shapes/) και, εάν χρειάζεται, το [Html5Options.animate_transitions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/html5options/animate_transitions/).
- Η απόδοση βίντεο υποστηρίζει πολλές κοινές εισόδους, έμφαση, εξόδους και εφέ διαδρομής κίνησης, αλλά δεν υποστηρίζονται όλα τα εφέ PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση Aspose.Slides που στοχεύετε.
- Προσαρμοσμένα προχωρημένα εφέ και εφέ εισαγόμενα από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά σε PowerPoint, HTML5 ή βίντεο. Επικυρώστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **Συχνές Ερωτήσεις**

**Γιατί ένα εφέ εμφανίζεται στο PowerPoint αλλά δεν εμφανίζεται σε PDF;**

Το PDF είναι στατική μορφή, επομένως τα εφέ και οι μεταβάσεις διαφανειών δεν παίζουν. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν πρέπει να διατηρηθεί η κίνηση.

**Γιατί ένα εφέ παίζει διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει τη συμπεριφορά του αρχικού PowerPoint. Κάποια προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Εξετάστε τον πίνακα των υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν τη χρήση σε παραγωγή.

**Αλλάζει η μετακίνηση ενός σχήματος προς τα εμπρός ή προς τα πίσω τη σειρά των κινήσεων;**

Όχι. Η σειρά z του σχήματος ελέγχει την επικάλυψη, ενώ η σειρά της ακολουθίας και τα σκανδάλια ελέγχουν την αναπαραγωγή των κινήσεων. Αλλάξτε τη χρονική γραμμή αν χρειάζεστε διαφορετική σειρά αναπαραγωγής.