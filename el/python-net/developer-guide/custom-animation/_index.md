---
title: Δημιουργία και Τροποποίηση Προσαρμοσμένων Συμπεριφορών Κίνησης σε Python
linktitle: Προσαρμοσμένη Κίνηση
type: docs
weight: 151
url: /el/python-net/custom-animation/
keywords:
- προσαρμοσμένη κίνηση
- συμπεριφορά κίνησης
- διαδρομή κίνησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε, εξετάστε και τροποποιήστε προσαρμοσμένες συμπεριφορές κίνησης και επεξεργάσιμες διαδρομές κίνησης σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Οι προσαρμοσμένες συμπεριφορές κίνησης σάς επιτρέπουν να ελέγχετε μεμονωμένες λειτουργίες μέσα σε ένα εφέ κίνησης, όπως η αλλαγή χρώματος, η περιστροφή ενός σχήματος ή η ακολουθία επεξεργάσιμης διαδρομής κίνησης. Αυτός ο οδηγός δείχνει πώς να δημιουργείτε και να συνδυάζετε συμπεριφορές, να ρυθμίζετε τον χρόνο τους, να εξετάζετε και να τροποποιείτε υπάρχουσες κινήσεις, και να επαληθεύετε ότι οι ιδιότητές τους παραμένουν μετά την αποθήκευση και το άνοιγμα ξανά μιας παρουσίασης.

Για προεπιλεγμένα εφέ και ενεργοποιήσεις με κλικ, δείτε [Κίνηση Σχήματος](/slides/el/python-net/shape-animation/).

## **Κατανόηση του Μοντέλου Κίνησης**

Μια κίνηση οργανώνεται ως **Timeline → Sequence → Effect → Behaviors**:

- Η [timeline] της διαφάνειας (https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/timeline/) περιέχει την κύρια ακολουθία της και τις αλληλεπιδραστικές ακολουθίες.
- Μια [Sequence] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/) περιλαμβάνει εφέ, ενδεχομένως σε διαφορετικά σχήματα.
- Ένα [Effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/) προσδιορίζει το σχήμα-στόχο, το preset, το subtype και το χρονισμό του εφέ.
- Τα [Effect.behaviors] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/behaviors/) περιέχουν τις λειτουργίες που υλοποιούν το εφέ: αλλαγή χρώματος, μετακίνηση, περιστροφή, ορισμός ιδιότητας κ.λπ.

## **Δημιουργία Μεμονωμένων Συμπεριφορών**

Καλέστε [Sequence.add_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) για να δημιουργήσετε ένα εφέ και να αποκτήσετε πρόσβαση στη συλλογή [behaviors] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/behaviors/). Ένα preset μπορεί να γεμίσει αυτόματα τη συλλογή. Διατηρήστε τις λειτουργίες του όταν επεκτείνετε το preset ή χρησιμοποιήστε [clear] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorcollection/clear/) όταν τις αντικαθιστάτε σκόπιμα.

[BehaviorFactory] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/) δημιουργεί τους οκτώ τύπους συμπεριφοράς που απεικονίζονται παρακάτω. Η κίνηση καλύπτεται στο [Δημιουργία Διαδρομής Κίνησης](#build-a-motion-path). Κάθε παράδειγμα δημιουργίας είναι πλήρες πρόγραμμα· τα παραδείγματα επεξεργασίας αναφέρουν το αρχείο εξόδου που χρησιμοποιούν.

### **Περιστροφή**

Χρησιμοποιήστε [create_rotation_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) για να δημιουργήσετε μια περιστροφή. Το [by] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/rotationeffect/by/) ορίζει μια σχετική γωνία σε μοίρες· τα [from_address] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/rotationeffect/from_address/) και [to] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/rotationeffect/to/) ορίζουν τα άκρα.

Το παράδειγμα ξεκινά με ένα εφέ Spin, αντικαθιστά τις προεπιλεγμένες λειτουργίες του με μία συμπεριφορά περιστροφής και δίνει στη λειτουργία αυτή διάρκεια δύο δευτερολέπτων. Μια σχετική γωνία 90 μοιρών εκφράζει τέταρτη περιστροφή από την αρχική κλίση του σχήματος, οπότε δεν απαιτείται ρητή αρχική γωνία.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` περιέχει ένα σχήμα και μία συμπεριφορά περιστροφής. Η συλλογή, ο χρονισμός και τα παραδείγματα επεξεργασίας περιστροφής παρακάτω χρησιμοποιούν αυτό το αρχείο.

### **Κλίμακα**

Χρησιμοποιήστε [create_scale_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) με ποσοστά X/Y: τα [from_address] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/scaleeffect/from_address/) και [to] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/scaleeffect/to/) περιγράφουν το αρχικό και το τελικό μέγεθος, ενώ το [by] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/scaleeffect/by/) περιγράφει μια σχετική μεταβολή. Εδώ, 100 σημαίνει το αρχικό μέγεθος.

Το παράδειγμα αυξάνει και τις δύο διαστάσεις από 100 % σε 125 % σε δύο δευτερόλεπτα. Η χρήση ίσων οριζόντιων και κάθετων ποσοστών διατηρεί τις αναλογίες του σχήματος· διαφορετικά ποσοστά θα τεντώσουν τη μία διάσταση περισσότερο από την άλλη.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Χρώμα**

Χρησιμοποιήστε [create_color_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) για να αλλάξετε τη γέμιση από το μπλε στο πορτοκαλί. Τα [from_address] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/coloreffect/from_address/) και [to] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/coloreffect/to/) είναι χρώματα· το [by] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/coloreffect/by/) είναι μετατόπιση χρώματος. Τα [Behavior.properties] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behavior/properties/) προσδιορίζουν το χαρακτηριστικό που αναπαράγεται.

Η συμπαγής γέμιση του σχήματος αρχικοποιείται σε μπλε, ταιριάζοντας με το αρχικό χρώμα του εφέ. Η επιλογή του χαρακτηριστικού γέμισης λέει στη συμπεριφορά ποιο τμήμα του σχήματος να αλλάξει· τα άκρα χρώματος μόνο δεν προσδιορίζουν το χαρακτηριστικό. Το αποθηκευμένο εφέ περιγράφει μια διώροφη μετάβαση στο πορτοκαλί.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Φίλτρο**

Χρησιμοποιήστε [create_filter_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) για να επιλέξετε ένα wipe. Τα [type] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/filtereffect/type/), [subtype] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/filtereffect/subtype/) και [reveal] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/filtereffect/reveal/) δηλώνουν το φίλτρο, την κατεύθυνση και αν θα αποκαλυφθεί ή θα κρυφτεί το σχήμα.

Το παράδειγμα ρυθμίζει ένα διώροφο wipe που αποκαλύπτει το σχήμα χρησιμοποιώντας το subtype διεύθυνσης δεξιά. Οι ρυθμίσεις του φίλτρου ανήκουν στη συμπεριφορά μέσα στο εφέ, επομένως ρυθμίζονται αφού αφαιρεθούν οι αρχικές λειτουργίες του preset.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Ιδιότητα**

Χρησιμοποιήστε [create_property_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) για να αναπαράγετε τη διαφάνεια. Τα [from_address] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/propertyeffect/from_address/), [to] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/propertyeffect/to/) και [by] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/propertyeffect/by/) είναι συμβολοσειρές που ερμηνεύονται μέσω του [value_type] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/propertyeffect/value_type/) και του [calc_mode] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Επιλέξτε άκρα ή σχετική μετατόπιση αντί να ορίσετε και τα τρία ανεξάρτητα.

Εδώ, το επιλεγμένο χαρακτηριστικό είναι η διαφάνεια, και οι αριθμητικές συμβολοσειρές αντιπροσωπεύουν αλλαγή από 25 % διαφάνειας σε πλήρη διαφάνεια. Η γραμμική παρεμβολή περιγράφει μια ομαλή μεταβολή μεταξύ των τιμών. Όταν προσαρμόζετε αυτό το παράδειγμα σε άλλη ιδιότητα, διαλέξτε τύπο τιμής και τιμές άκρων κατάλληλες για τη συγκεκριμένη ιδιότητα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Ορισμός**

Χρησιμοποιήστε [create_set_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) για να εκχωρήσετε ορατότητα μέσω του [to] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/seteffect/to/). Μια συμπεριφορά set δεν παρεμβάλλει μεταξύ των άκρων.

Το παράδειγμα επιλέγει το χαρακτηριστικό ορατότητας και εκχωρεί τη συμβολοσειρά `visible` όταν εκτελείται η συμπεριφορά. Το ορθογώνιο είναι ήδη ορατό σε αυτήν την ελάχιστη παρουσίαση, έτσι η εκχώρηση μπορεί να μην προκαλέσει εμφανή οπτική αλλαγή μόνη της. Μια τέτοια ενέργεια είναι χρήσιμη ως μέρος μεγαλύτερου εφέ που ελέγχει επίσης πότε το σχήμα γίνεται κρυφό ή ορατό.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Εντολή**

Χρησιμοποιήστε [create_command_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) και ρυθμίστε τα [type] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/commandeffect/type/), [command_string] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/commandeffect/command_string/) και [shape_target] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/commandeffect/shape_target/). Τοποθετήστε ένα αρχείο ήχου WAV με όνομα `sample.wav` στον τρέχοντα φάκελο. Αυτό το παράδειγμα το ενσωματώνει με το [add_audio_frame_embedded] (https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) και προσθέτει εντολή αναπαραγωγής στο πλαίσιο ήχου.

Το πλαίσιο ήχου είναι τόσο ο στόχος του εφέ όσο και ο στόχος της εντολής. Αυτό συνδέει το αίτημα αναπαραγωγής με την ενσωματωμένη ηχογράφηση· μια εντολή μόνη της δεν καθορίζει ποιο αντικείμενο πολυμέσων να ελέγξει. Το εφέ ρυθμίζεται να ξεκινά με κλικ κατά τη διάρκεια της παρουσίασης.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Η αποθήκευση αποθηκεύει την εντολή στο `command.pptx`; δεν αναπαράγει την ηχογράφηση. Η αναπαραγωγή απαιτεί πρόγραμμα προβολής που υποστηρίζει την εντολή και το μέσο‑στόχο της.

## **Διαχείριση της Συλλογής Συμπεριφορών**

Η [BehaviorCollection] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorcollection/) υποστηρίζει τα [add] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorcollection/add/), [insert] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorcollection/remove/) και [remove_at] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Το παράδειγμα αυτό ανοίγει το `rotation.pptx`, προσθέτει κλίμακα, τη μετακινεί πριν από την περιστροφή και αφαιρεί την περιστροφή. Η αφαίρεση και η επανεισαγωγή του ίδιου αντικειμένου αλλάζει τη θέση του χωρίς να κάνει αντίγραφο.

Η σειρά των επεξεργασιών αλλάζει τη συλλογή από περιστροφή–κλίμακα σε κλίμακα–περιστροφή, έπειτα μόνο σε κλίμακα. Οι δείκτες αναφέρονται στην τρέχουσα συλλογή, οπότε η αφαίρεση χρησιμοποιεί το νέο δείκτη της περιστροφής μετά την αναδιάταξη. Η τελική απαρίθμηση επιβεβαιώνει ποια συμπεριφορά θα αποθηκευτεί.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα είναι `ScaleEffect`: παραμένει μόνο η κλίμακα. Η σειρά στη συλλογή δεν προγραμματίζει αυτόματα τις συμπεριφορές η μία μετά την άλλη. Αδειάστε τη συλλογή μόνο όταν αντικαθιστάτε όλες τις λειτουργίες της.

## **Ρύθμιση Χρονισμού Συμπεριφοράς**

Το [Behavior.timing] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behavior/timing/) εκθέτει το [Timing] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/), ανεξάρτητα από το [Effect.timing] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/timing/). Ο χρονισμός του εφέ προγραμματίζει ολόκληρο το εφέ· ο χρονισμός της συμπεριφοράς περιγράφει μια λειτουργία εντός αυτού.

### **Ορισμός Διάρκειας, Καθυστέρησης, Επανάληψης και Επιτάχυνσης**

Ανοίξτε το `rotation.pptx` και ορίστε το [duration] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/duration/) και το [trigger_delay_time] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/trigger_delay_time/) (σε δευτερόλεπτα), έπειτα ρυθμίστε το [repeat_count] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_count/). Τα [accelerate] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/accelerate/) και [decelerate] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/decelerate/) είναι κλασματικά της διάρκειας· διατηρήστε το άθροισμά τους το πολύ 1.

Το αρχείο εισόδου είναι εκείνο που δημιουργήθηκε στο παράδειγμα περιστροφής, όπου η πρώτη συμπεριφορά είναι γνωστή ως περιστροφή. Αυτό το παράδειγμα αλλάζει μόνο το χρονισμό εκείνης της συμπεριφοράς· η γωνία των 90 μοιρών παραμένει αμετάβλητη. Η διατήρηση ξεχωριστών γωνίας και χρονισμού διευκολύνει την τροποποίηση του ρυθμού χωρίς επαναδημιουργία της κίνησης.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Η συμπεριφορά χρησιμοποιεί διάρκεια δυο δευτερολέπτων, καθυστέρηση μισού δευτερολέπτου και επανάληψη 3 φορές. Το πρώτο και το τελευταίο 20 % της διάρκειάς της χρησιμοποιείται για επιτάχυνση και επιβράδυνση.

Άλλες πολιτικές επανάληψης περιλαμβάνουν το [repeat_duration] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_duration/), το [repeat_until_end_slide] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) και το [repeat_until_next_click] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/repeat_until_next_click/); επιλέξτε μία πολιτική αντί να τις ενεργοποιήσετε όλες μαζί. Το [auto_reverse] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/timing/auto_reverse/) παίζει το εφέ προς τα πίσω μετά την προώθηση. Η επιτάχυνση και η επιβράδυνση εφαρμόζονται σε συνεχείς αλλαγές, όχι σε διακριτές εκχωρήσεις ή εντολές.

## **Δημιουργία Διαδρομής Κίνησης**

Χρησιμοποιήστε [create_motion_effect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) για να δημιουργήσετε κίνηση. Τα [from_address] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioneffect/from_address/), [to] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioneffect/to/) και [by] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioneffect/by/) περιγράφουν συντεταγμένες ή μετατοπίσεις με βάση το ποσοστό. Για επεξεργάσιμη διαδρομή, δημιουργήστε ένα [MotionPath] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motionpath/) και αναθέστε το στο [MotionEffect.path] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioneffect/path/). Τα [MotionPath] αποθηκεύουν τις εντολές διαδρομής.

Το [MotionCommandPathType] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioncommandpathtype/) επιλέγει τη λειτουργία:

| Εντολή | Σημεία | Σημασία |
| --- | --- | --- |
| MOVE_TO | Ένα | Ορίζει τη θέση εκκίνησης. |
| LINE_TO | Ένα | Μετακινεί κατά ευθεία γραμμή στο άκρο του τμήματος. |
| CURVE_TO | Τρία | Ακολουθεί κυρτή καμπύλη ορισμένη από δύο σημεία ελέγχου και ένα άκρο. |
| CLOSE_LOOP | Κανένα | Επιστρέφει στη θέση εκκίνησης. |
| END | Κανένα | Ολοκληρώνει τη διαδρομή. |

Το [MotionPathPointsType] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motionpathpointstype/) περιγράφει τα χαρακτηριστικά επεξεργασίας των σημείων, όπως γωνία ή λείο σημείο. Δεν αντικαθιστά τον τύπο εντολής. Χρησιμοποιήστε τύπο σημείου καμπύλης για το παράδειγμα καμπύλης παρακάτω και τύπο σημείου γωνίας για τα ευθύγραμμα τμήματα.

Οι συντεταγμένες της διαδρομής είναι κανονικοποιημένες ως ποσοστά διαστάσεων της διαφάνειας: μετατόπιση X = 0.25 σημαίνει ένα τέταρτο του πλάτους της διαφάνειας, όχι 0.25 points. Θετικό Y τρέχει προς τα κάτω. Οι απόλυτες εντολές ορίζουν θέσεις στο σύστημα συντεταγμένων της διαδρομής· οι σχετικές εντολές ορίζουν μετατοπίσεις από τη τρέχουσα θέση. Αυτό είναι ξεχωριστό από το [origin] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioneffect/origin/), που επιλέγει το πλαίσιο αναφοράς της διαδρομής, και το [path_edit_mode] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), που ελέγχει πώς κινείται η διαδρομή όταν το σχήμα μετακινείται.

### **Δημιουργία Ευθείας Διαδρομής**

Δημιουργήστε μια συμπεριφορά κίνησης με σημείο εκκίνησης, ένα ευθύγραμμο τμήμα και εντολή λήξης. Το [MotionPath.add] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motionpath/add/) δέχεται τον τύπο εντολής, τα σημεία της, τον τύπο σημείου και τη σημαία σχετικής συντεταγμένης.

Η εντολή εκκίνησης θέτει (0, 0) και η γραμμή λήγει στο (0.25, 0), δίνοντας στη διαδρομή οριζόντια μετατόπιση ενός τετάρτου του πλάτους της διαφάνειας. Η εντολή λήξης δεν έχει σημεία συντεταγμένων. Μόλις η διαδρομή ανατεθεί, η προσθήκη της συμπεριφοράς κίνησης στο εφέ συνδέει τη διαδρομή με το ορθογώνιο.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` περιέχει μία συμπεριφορά κίνησης με τρεις εντολές διαδρομής. Τα παραδείγματα επεξεργασίας αρχείων που ακολουθούν χρησιμοποιούν αυτή τη γνωστή δομή.

### **Σύγκριση Απόλυτων και Σχετικών Συντεταγμένων**

Αυτά τα δύο αντικείμενα διαδρομής περιγράφουν την ίδια διαδρομή. Η απόλυτη εντολή λήγει στο (0.3, 0.1); η σχετική προσθέτει (0.1, 0.1) στη τρέχουσα θέση, (0.2, 0).

Και οι δύο διαδρομές ξεκινούν από την ίδια θέση. Για τη σχετική γραμμή, προσθέστε τις μετατοπίσεις X και Y στη τρέχουσα θέση για να πάρετε το άκρο· για την απόλυτη, διαβάστε το άκρο άμεσα. Η αλλαγή της σημαίας χωρίς μετατροπή των συντεταγμένων θα περιέγραφε διαφορετική διαδρομή.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Αναθέστε οποιαδήποτε διαδρομή σε συμπεριφορά κίνησης για χρήση στην παρουσίαση. Το τελικό λογικό όρισμα επιλέγει σχετικές συντεταγμένες για εκείνη την εντολή.

### **Αντικατάσταση Γραμμής με Καμπύλη**

Ανοίξτε το `motion.pptx` και αντικαταστήστε την εντολή γραμμής με μία κυρτή καμπύλη. Δώστε πρώτα τα δύο σημεία ελέγχου, μετά το άκρο.

Η θέση εκκίνησης παρέχεται από την προηγούμενη εντολή. Τα πρώτα δύο σημεία διαμορφώνουν την καμπύλη, ενώ το τρίτο είναι ο προορισμός· δεν είναι τρία διαδοχικά σημεία προορισμού. Η ενημέρωση του τύπου εντολής, του τύπου σημείου και του πίνακα σημείων μαζί διατηρεί το τμήμα συνεπές με τη νέα γεωμετρία του.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Η διαδρομή στο `curve.pptx` έχει ακόμη τρεις εντολές· η μεσαία εντολή τώρα ορίζει μια καμπύλη.

## **Εξέταση και Επεξεργασία Αποθηκευμένης Διαδρομής**

Κάθε [MotionCmdPath] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioncmdpath/) εκθέτει τα [points] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioncmdpath/points_type/) και [is_relative] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Τα παρακάτω παραδείγματα χρησιμοποιούν τη γνωστή διαδρομή τριών εντολών στο `motion.pptx`. Για τυχαία είσοδο, εντοπίστε το επιθυμητό εφέ και ελέγξτε τους τύπους εντολών και το πλήθος σημείων πριν επεξεργαστείτε με δείκτη.

### **Ανάγνωση Εντολών και Συντεταγμένων**

Διαβάστε τη διαδρομή χωρίς αλλαγή. Οι εντολές End και Close‑Loop δεν χρειάζονται σημεία, έτσι επιτρέψτε έναν πίνακα σημείων `None`.

Η έξοδος ζεύγει κάθε εντολή με τη σημαία σχετικής‑συντεταγμένης πριν απαριθμήσει τα σημεία της. Αυτό σας επιτρέπει να διακρίνετε ένα άκρο από μια μετατόπιση πριν τροποποιήσετε τη διαδρομή. Η καμπύλη θα εμφανίσει τρία σημεία, ενώ η ευθεία γραμμή σε αυτό το αρχείο εμφανίζει μόνο ένα.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

Η λίστα περιλαμβάνει σημείο εκκίνησης, απόλυτη γραμμή που λήγει στο (0.25, 0) και εντολή λήξης.

### **Αλλαγή Άκρου**

Ανοίξτε το `motion.pptx` και αντικαταστήστε τον πίνακα σημείων της γραμμής για να μετακινήσετε το άκρο της.

Στο αρχείο εισόδου, ο δείκτης 0 είναι η εντολή εκκίνησης και ο δείκτης 1 η γραμμή. Η αντικατάσταση του μοναδικού σημείου της γραμμής αλλάζει τον προορισμό χωρίς να αλλάξει τον τύπο εντολής, το χρονισμό ή τη θέση του στη συλλογή. Επειδή η εντολή χρησιμοποιεί απόλυτές συντεταγμένες, το νέο ζεύγος ορίζει θέση και όχι πρόσθετη μετατόπιση.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

Η γραμμή στο `motion-endpoint.pptx` λήγει στο (0.4, 0.1); το αρχικό αρχείο παραμένει αμετάβλητο.

### **Αντικατάσταση Τμηματος**

Χρησιμοποιήστε [insert] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motionpath/insert/) και [remove_at] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motionpath/remove_at/) για να αντικαταστήσετε τη γραμμή στο `motion.pptx`. Η εισαγωγή μετακινεί την παλιά γραμμή στον δείκτη 2.

Αυτό δείχνει αντικατάσταση αντικειμένου εντολής αντί για επεξεργασία των υπάρχουσων συντεταγμένων. Μετά την εισαγωγή, η συλλογή περιέχει προσωρινά την εντολή εκκίνησης, τη νέα γραμμή, την παλιά γραμμή και την εντολή λήξης. Η αφαίρεση του δείκτη 2 διαγράφει την παλιά γραμμή και αφήνει τη νέα διαδρομή στη θέση της.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Η αποθηκευμένη διαδρομή εξακολουθεί να έχει τρεις εντολές, με τη νέα γραμμή να λήγει στο (0.2, 0.1) και την εντολή END στο τέλος.

## **Τροποποίηση και Επαλήθευση Υπάρχουσας Συμπεριφοράς**

Όταν δεν γνωρίζετε το δείκτη της συμπεριφοράς, επιλέξτε τη βάση τύπου. Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, εντοπίζει το [RotationEffect] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/rotationeffect/), αλλάζει τη γωνία, και ελέγχει την αποθηκευμένη τιμή μετά το άνοιγμα ξανά.

Ο έλεγχος τύπου επιτρέπει στην βρόχο να παραλείψει συμπεριφορές που δεν είναι περιστροφές. Η δεύτερη φόρτωση διαβάζει το αποθηκευμένο αρχείο σε ξεχωριστό αντικείμενο παρουσίασης, έτσι η σύγκριση ελέγχει τα δεδομένα που διατηρήθηκαν, όχι την τιμή που παραμένει στη μνήμη. Αυτό το παράδειγμα υποθέτει ότι το γνωστό εφέ είναι πρώτο στην κύρια ακολουθία· η επιλογή συμπεριφοράς βάσει τύπου δεν εντοπίζει σωστά το εφέ σε αυθαίρετη παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

Η έξοδος είναι `Rotation preserved: True`. Εφαρμόστε το ίδιο μοτίβο ελέγχου τύπου σε άλλες συμπεριφορές. Για ολοκληρωμένο έλεγχο διατήρησης, συγκρίνετε το σχήμα‑στόχο, το εφέ, τους τύπους και τη σειρά των συμπεριφορών, τον χρονισμό, και τις εντολές διαδρομής. Χρησιμοποιήστε αριθμητική ανοχή για τιμές κινητής υποδιαστολής. Για παρουσίαση με άγνωστη διάταξη κίνησης, δείτε [Read Shape Animations](/slides/el/python-net/shape-animation/#read-shape-animations) για περιήγηση των κύριων και αλληλεπιδραστικών ακολουθιών.

## **Σειρά Συμπεριφορών, Presets και Αναπαραγωγή**

Η σειρά στη [BehaviorCollection] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behaviorcollection/) είναι η αποθηκευμένη σειρά των λειτουργιών ενός εφέ. Δεν είναι λίστα αναπαραγωγής όπου κάθε συμπεριφορά περιμένει αυτόματα την προηγούμενη. Ο χρονισμός και το περιεχόμενο εφέ καθορίζουν τον προγραμματισμό. Οι συμπεριφορές μπορούν να επικαλύπτονται, και οι λειτουργίες στην ίδια ιδιότητα μπορεί να αλληλεπιδρούν μέσω των [additive] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behavior/additive/) και [accumulate] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behavior/accumulate/). Μην χρησιμοποιείτε μόνο την αναδιαρρύθμιση της συλλογής για να προγραμματίσετε «μετακίνηση, μετά περιστροφή»· χρησιμοποιήστε ρητό χρονισμό ή ξεχωριστά εφέ όπως περιγράφεται στην [Κίνηση Σχήματος](/slides/el/python-net/shape-animation/).

Ο [type] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/type/) και ο [subtype] (https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effect/subtype/) του εφέ περιγράφουν το preset. Δεν αποτελούν πλήρη περιγραφή ενός επεξεργασμένου δέντρου συμπεριφορών. Διαλέξτε το preset και το subtype πριν προσαρμόσετε τις συμπεριφορές: η αλλαγή του preset μπορεί να ξαναχτίσει τη συλλογή και να απορρίψει τις προσαρμοσμένες λειτουργίες σας. Για παράδειγμα, η αλλαγή ενός προσαρμοσμένου εφέ Spin σε Fade μπορεί να αντικαταστήσει τη συμπεριφορά περιστροφής με set και filter. Εξετάστε ξανά τη συλλογή μετά την αλλαγή preset ή subtype. Η εκκαθάριση των preset συμπεριφορών μπορεί επίσης να αφαιρέσει λειτουργίες ορατότητας ή αρχικοποίησης που χρειάζεται το preset. Τα παραδείγματα χρησιμοποιούν ορατά σχήματα και αντικαθιστούν τις συμπεριφορές· δεν ξαναχτίζουν την υλοποίηση κάθε preset.

## **Συμβατότητα Μορφής**

Ένα διατηρημένο δέντρο συμπεριφορών δεν εγγυάται ταυτόσημη αναπαραγωγή σε κάθε προβολέα ή εξαγωγέα. Ελέγξτε τα αποθηκευμένα δεδομένα και την αποδοθέν output χωριστά.

| Μορφή ή έξοδος | Τι να ελεγχθεί |
| --- | --- |
| PPTX | Χρησιμοποιήστε ως κύρια μορφή για αυτά τα παραδείγματα. Ανοίξτε ξανά για επαλήθευση του επεξεργάσιμου δέντρου συμπεριφοράς, έπειτα ελέγξτε την αναπαραγωγή στην επιθυμητή έκδοση του PowerPoint. |
| PPT | Η παλιά δυαδική μορφή μπορεί να διαφέρει από το PPTX. Δοκιμάστε κύκλο αποθήκευσης‑ανοίγματος και την αναπαραγωγή· μην υποθέτετε υποστήριξη για κάθε προσαρμοστικό συνδυασμό από την επιτυχία του PPTX. |
| PDF, PNG, JPEG και άλλες στατικές εικόνες διαφάνειας | Περιέχουν στατική αναπαράσταση διαφάνειας, όχι εκτελεστή χρονοδιάγραμμα ή εγγυημένο τελικό καρέ κίνησης. |
| [HTML5](/slides/el/python-net/export-to-html5/) | Μπορεί να αναπαράγει υποστηριζόμενες κινήσεις όταν η κίνηση σχήματος είναι ενεργοποιημένη στις επιλογές εξαγωγής. Δοκιμάστε προσαρμοσμένους συνδυασμούς στον πλοηγό. |
| [Animated GIF](/slides/el/python-net/convert-powerpoint-to-animated-gif/) | Αποθηκεύει αποδιδόμενα πλαίσια, όχι επεξεργάσιμες συμπεριφορές ή κλικ‑ενεργοποίηση. Ελέγξτε την πραγματική κίνηση που αποδίδεται. |
| [Video](/slides/el/python-net/convert-powerpoint-to-video/) | Εξάγει καρέ κίνησης και τα κωδικοποιεί ως βίντεο. Η υποστήριξη περιορίζεται στην λίστα [supported animations and effects](/slides/el/python-net/convert-powerpoint-to-video/#supported-animations-and-effects)· εντολές και διαδραστικά γεγονότα δεν γίνονται επεξεργάσιμο χρονοδιάγραμμα. |

## **Συχνές Ερωτήσεις**

**Γιατί το εφέ μου περιέχει συμπεριφορές πριν προσθέσω τίποτα;**

Η δημιουργία ενός προεπιλεγμένου εφέ μπορεί να δημιουργήσει τις υποκείμενες λειτουργίες του. Εξετάστε τες πριν αποφασίσετε αν θα επεκτείνετε το preset ή θα τις αντικαταστήσετε.

**Η μετακίνηση μιας συμπεριφοράς στην αρχή την κάνει να παίζει πρώτη;**

Δεν απαραίτητα. Η σειρά στη συλλογή δεν αντικαθιστά τον χρονισμό. Ελέγξτε καθυστερήσεις, διάρκειες και αλληλεπιδράσεις μεταξύ λειτουργιών στην ίδια ιδιότητα.

**Γιατί η εντολή END δεν έχει σημεία;**

Σηματοδοτεί το τέλος της διαδρομής και δεν χρειάζεται συντεταγμένες. Ελέγξτε για πίνακα σημείων `None` όταν εξετάζετε μια διαδρομή που διαβάζεται από αρχείο.

**Είναι η επιτυχημένη κυκλική αποθήκευση επαρκής για επιβεβαίωση της αναπαραγωγής;**

Όχι. Η ξαναφόρτωση επιβεβαιώνει τη διατήρηση των ιδιοτήτων που ελέγξατε. Δοκιμάστε τον προγράμματος προβολής ή την εξαγωγή animation ξεχωριστά για να επιβεβαιώσετε τη οπτική συμπεριφορά.