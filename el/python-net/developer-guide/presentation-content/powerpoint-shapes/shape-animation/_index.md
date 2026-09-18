---
title: Εφαρμογή Κινούμενων Σχημάτων σε Παρουσιάσεις με Python
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/python-net/shape-animation/
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
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να εξετάζετε και να προσαρμόζετε τις κινήσεις σχημάτων, το χρονοδιάγραμμα, τους ήχους, τη συμπεριφορά μετά την κίνηση και το κινούμενο κείμενο με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Για να εργαστείτε με τις μεμονωμένες συμπεριφορές μέσα σε ένα εφέ ή να επεξεργαστείτε τμήματα διαδρομής κίνησης, δείτε [Προσαρμοσμένη Κίνηση](/slides/el/python-net/custom-animation/).

Aspose.Slides for Python μέσω .NET αντιπροσωπεύει τις κίνησεις στις διαφάνειες ως εφέ σε χρονοδιάγραμμα διαφάνειας. Ένα εφέ έχει σχήμα‑στόχο, τύπο και υποτύπο κίνησης, ενεργοποιητή, ρυθμίσεις χρόνου και προαιρετικές ιδιότητες όπως ήχος ή συμπεριφορά μετά την κίνηση.

Το χρονοδιάγραμμα περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς προχωρά η διαφάνεια.
- Μια **αλληλεπιδραστική ακολουθία** ξεκινά όταν το σχήμα‑ενεργοποιητής της πατηθεί.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας υλοποιούν το [IShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishape/), χρησιμοποιείτε την ίδια μέθοδο [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) για τα περισσότερα περιεχόμενα διαφάνειας. Τα διαθέσιμα εφέ παρατίθενται στην αρίθμηση [EffectType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttype/).

## **Προσθήκη Κινούμενων Σχημάτων**

Για να προσθέσετε μια κίνηση, λάβετε την κύρια ακολουθία της διαφάνειας και καλέστε [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) με το σχήμα‑στόχο, τον τύπο εφέ, τον υποτύπο και τον ενεργοποιητή. Για ένα εφέ που ξεκινά όταν πατηθεί άλλο σχήμα, δημιουργήστε μια αλληλεπιδραστική ακολουθία του οποίου ο ενεργοποιητής είναι το εν λόγω σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τους δύο τύπους κίνησης και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

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

Ο ενεργοποιητής ελέγχει πότε ξεκινά ένα εφέ:

- Το [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/) περιμένει για κλικ στην κύρια ακολουθία ή για κλικ στο σχήμα‑ενεργοποιητή σε αλληλεπιδραστική ακολουθία.
- Το [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/) ξεκινά με το προηγούμενο εφέ.
- Το [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/) ξεκινά όταν το προηγούμενο εφέ ολοκληρωθεί.

Για να δημιουργήσετε κίνηση σε εικόνα, διάγραμμα ή άλλο τύπο σχήματος, περάστε το αντικείμενο στο [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) αντί για `target_shape`. Για επιλογές ομαδοποίησης ειδικά για διαγράμματα, δείτε [Animated Charts](/slides/el/python-net/animated-charts/).

## **Ανάγνωση Κινούμενων Σχημάτων**

Χρησιμοποιήστε το [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) όταν γνωρίζετε το σχήμα‑στόχο. Για να επιθεωρήσετε κάθε εφέ, επαναλάβετε την κύρια ακολουθία και κάθε αλληλεπιδραστική ακολουθία. Η επανάληψη αποφεύγει την υπόθεση ότι μια ακολουθία περιέχει εφέ στην θέση `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας και αλληλεπιδραστικής ακολουθίας, παίρνει τα εφέ που στοχεύουν το σχήμα και, στη συνέχεια, διατρέχει κάθε ακολουθία στη διαφάνεια.

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

Αν χρειάζεστε τα εφέ μόνο για ένα σχήμα, πρώτα προσδιορίστε το σχήμα με όνομα, τύπο θέσης‑καρφίτσας ή άλλη σταθερή ιδιότητα·, στη συνέχεια καλέστε [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Μην υποθέτετε ότι το σχήμα στη θέση `0` είναι πάντα το ζητούμενο αντικείμενο.

## **Εργασία με Κληρονομούμενα Εφέ Θέσεων Καρφίτσας**

Μια θέση‑καρφίτσα σε μια κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από την αντίστοιχη θέση‑καρφίτσα στη διαφάνεια διάταξης και στην κύρια διαφάνεια. Το [Shape.get_base_placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_base_placeholder/) επιστρέφει εκείνη τη γονική θέση‑καρφίτσα, ή `None` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στην κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης, και **Fly In** στην κύρια διαφάνεια.

![Εφέ animation υποσέλιδου στην κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ animation υποσέλιδου στη διαφάνεια διάταξης](layout-shape-animation.png)

![Εφέ animation υποσέλιδου στην κύρια διαφάνεια](master-shape-animation.png)

Το επόμενο παράδειγμα δημιουργεί την ιεραρχία θέσεων‑καρφίτσας από την αρχή. Προσθέτει εφέ σε μια θέση‑καρφίτσα master, μια θέση‑καρφίτσα layout και στην αντίστοιχη θέση‑καρφίτσα μιας κανονικής διαφάνειας. Κάθε κλήση στο [Shape.get_base_placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_base_placeholder/) ελέγχεται πριν χρησιμοποιηθεί το επιστρεφόμενο σχήμα.

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

## **Αλλαγή Χρονισμού Κίνησης**

Ο διάλογος **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες του [Timing](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/).

![Διάλογος χρονομέτρησης PowerPoint για ένα εφέ κίνησης](shape-animation.png)

- **Έναρξη** αντιστοιχεί στο [Timing.trigger_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/trigger_type/).
- **Διάρκεια** αντιστοιχεί στο [Timing.duration](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/duration/), σε δευτερόλεπτα.
- **Καθυστέρηση** αντιστοιχεί στο [Timing.trigger_delay_time](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/trigger_delay_time/), σε δευτερόλεπτα.
- **Επανάληψη** αντιστοιχεί στο [Timing.repeat_count](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_count/), στο [Timing.repeat_until_next_click](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_next_click/) ή στο [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Επαναφόρτωση όταν ολοκληρωθεί η αναπαραγωγή** αντιστοιχεί στο [Timing.rewind](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/rewind/).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει τον χρόνο του μέσω του αντικειμένου που επιστρέφει το [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/), και αποθηκεύει το αποτέλεσμα. Η διατήρηση της αναφοράς του επιστρεφόμενου [Effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/) αποτρέπει την περιττή αναφορά σε δείκτη συλλογής.

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

Χρησιμοποιήστε μία λειτουργία επανάληψης σκόπιμα. Συνδυασμός μετρήματος επανάληψης με σημαία «μέχρι» μπορεί να δημιουργήσει συγκεχυμένα αποτελέσματα σε διαφορετικούς προβολείς. Όταν αλλάζετε τη λειτουργία επανάληψης, ορίστε πρώτα το [Timing.repeat_until_next_click](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_next_click/) και το [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) πριν το [Timing.repeat_count](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_count/), καθώς η ρύθμιση οποιασδήποτε σημαίας αλλάζει επίσης τη δραστική λειτουργία επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφερθεί σε ενσωματωμένο ήχο μέσω του [Effect.sound](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/sound/). Το [Effect.stop_previous_sound](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/stop_previous_sound/) λέει στο εφέ να σταματήσει ήχο που ξεκίνησε ένα προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Ένα Εφέ**

Το παρακάτω παράδειγμα απαιτεί ένα τοπικό αρχείο ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει αυτό το αρχείο ως ήχο για το πρώτο εφέ και ρυθμίζει το δεύτερο εφέ ώστε να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφει το [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/), επομένως δεν απαιτείται δείκτης ακολουθίας.

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

Το παρακάτω παράδειγμα απαιτεί μια τοπική παρουσίαση με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο την κύρια όσο και την αλληλεπιδραστική ακολουθία και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκτίθεται από το [Audio.content_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/audio/content_type/).

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

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [Audio.get_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides/audio/get_stream/) και αντιγράψτε τη ροή σε αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε πίνακα bytes.

## **Ορισμός Συμπεριφοράς Μετά την Κίνηση**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα μετά το πέρας του εφέ.

![Διάλογος επιλογών εφέ PowerPoint που δείχνει τις ρυθμίσεις After animation](shape-after-animation.png)

Η αρίθμηση [AfterAnimationType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/) υποστηρίζει το να αφήσετε το σχήμα αμετάβλητο, να αλλάξετε το χρώμα του, να το κρύψετε μετά την κίνηση ή να το κρύψετε στο επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.COLOR](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/), ορίστε επίσης το [Effect.after_animation_color](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/after_animation_color/).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά την κίνηση μέσω του επιστρεφόμενου αντικειμένου εφέ, και αποθηκεύει το αποτέλεσμα.

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

Αλλαγή του τύπου από το [AfterAnimationType.COLOR](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/) αδειάζει τη ρύθμιση χρώματος μετά την κίνηση.

## **Κινούμενο Κείμενο**

Η κίνηση κειμένου έχει δύο σχετικούς ελέγχους:

- Το [TextAnimation.build_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/textanimation/build_type/) ελέγχει αν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- Το [Effect.animate_text_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/animate_text_type/) ελέγχει αν το κείμενο εμφανίζεται όλο μονομιάς, λέξη ανά λέξη ή γράμμα ανά γράμμα. Το [Effect.delay_between_text_parts](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/delay_between_text_parts/) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μια θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/buildtype/) απενεργοποιεί το χτίσιμο παράγραφο‑ανά‑παράγραφο, έτσι ώστε η ρύθμιση λέξης να εφαρμόζεται σε ολόκληρο το πλαίσιο κειμένου.

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

Για να χτίσετε ένα πλαίσιο κειμένου παράγραφος‑από‑παράγραφο, ορίστε το [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/buildtype/) (ή κάποιο άλλο επίπεδο παραγράφου). Για να στοχεύσετε μια μόνο παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση του [Sequence.add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) που αποδέχεται ένα [IParagraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/iparagraph/). Δείτε το [Animated Text](/slides/el/python-net/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από τον προβολέα της παρουσίασης.
- Το PDF και οι στατικές εικόνες δεν παίζουν κίνησες. Χρησιμοποιήστε την [HTML5 export](/slides/el/python-net/export-to-html5/), animated GIF ή [video conversion](/slides/el/python-net/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.animate_shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/html5options/animate_shapes/) και, όταν χρειάζεται, το [Html5Options.animate_transitions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/html5options/animate_transitions/).
- Η απόδοση βίντεο υποστηρίζει πολλές κοινές εφέ εισόδου, έμφασης, εξόδου και διαδρομής κίνησης, αλλά δεν υποστηρίζονται όλα τα εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση Aspose.Slides που χρησιμοποιείτε.
- Προηγμένα προσαρμοσμένα εφέ και εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά στο PowerPoint, HTML5 ή βίντεο. Επικυρώστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **Συχνές Ερωτήσεις**

**Γιατί εμφανίζεται μια κίνηση στο PowerPoint αλλά δεν εμφανίζεται σε PDF;**

Το PDF είναι στατική μορφή, οπότε οι κίνηση και οι μεταβάσεις διαφανειών δεν παίζουν. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν η κίνηση πρέπει να διατηρηθεί.

**Γιατί ένα εφέ αναπαράγεται διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κίνηση αντί να αποθηκεύει τη συμπεριφορά του αρχικού PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Ελέγξτε τον πίνακα υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν από την παραγωγή.

**Αλλάζει η αλλαγή της σειράς ενός σχήματος (μπροστά ή πίσω) τη σειρά των κίνησών;**

Όχι. Η σειρά z‑order του σχήματος ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και οι ενεργοποιητές ελέγχουν την αναπαραγωγή των κίνησεων. Αλλάξτε το χρονοδιάγραμμα αν χρειάζεστε διαφορετική σειρά playback.