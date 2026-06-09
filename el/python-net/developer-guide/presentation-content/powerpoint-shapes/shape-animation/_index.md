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
description: "Ανακαλύψτε πώς να δημιουργήσετε και να προσαρμόσετε κινήσεις σχημάτων σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET. Ξεχωρίστε!"
---
## **Εισαγωγή**

Οι κινήσεις είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή [διαγράμματα](/slides/el/python-net/animated-charts/). Δίνουν ζωή στις παρουσιάσεις ή στα στοιχεία τους. 

## **Γιατί να χρησιμοποιείτε κινήσεις σε παρουσιάσεις;**

* ελέγξτε τη ροή της πληροφορίας
* τονίστε σημαντικά σημεία
* αυξήστε το ενδιαφέρον ή τη συμμετοχή του κοινού σας
* κάντε το περιεχόμενο πιο εύκολο στην ανάγνωση, την αφομοίωση ή την επεξεργασία
* προσελκύστε την προσοχή των αναγνωστών ή των θεατών σας σε σημαντικά μέρη μιας παρουσίασης

Το PowerPoint παρέχει πολλές επιλογές και εργαλεία για κινήσεις και εφέ κινήσεων σε κατηγορίες **εισόδου**, **εξόδου**, **τονισμού** και **διαδρομές κίνησης**. 

## **Κινήσεις στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τους τύπους που χρειάζεστε για εργασία με κινήσεις στο χώρο ονομάτων [Aspose.Slides.Animation](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/), 
* Το Aspose.Slides παρέχει πάνω από **150 εφέ κίνησης** στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttype/). Αυτά τα εφέ είναι ουσιαστικά τα ίδια (ή ισοδύναμα) εφέ που χρησιμοποιούνται στο PowerPoint.

## **Εφαρμογή κίνησης σε TextBox**

Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να εφαρμόσετε κίνηση στο κείμενο ενός σχήματος. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/iautoshape/). 
4. Προσθέστε κείμενο στο `IAutoShape.TextFrame`.
5. Λάβετε τη κύρια ακολουθία των εφέ.
6. Προσθέστε ένα εφέ κίνησης στο [IAutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/iautoshape/). 
7. Ορίστε την ιδιότητα `TextAnimation.BuildType` στην τιμή από την απαρίθμηση `BuildType`.
8. Γράψτε την παρουσίαση στον δίσκο ως αρχείο PPTX.

Αυτό το κώδικα Python δείχνει πώς να εφαρμόσετε το εφέ `Fade` στο AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Προσθέτει νέο AutoShape με κείμενο
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Λαμβάνει τη βασική ακολουθία της διαφάνειας.
    sequence = sld.timeline.main_sequence

    # Προσθέτει εφέ κίνησης Fade στο σχήμα
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Κινεί το κείμενο του σχήματος ανά πρώτου επιπέδου παραγράφους
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Εκτός από την εφαρμογή κινήσεων σε κείμενο, μπορείτε επίσης να εφαρμόσετε κινήσεις σε ένα μοναδικό [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/iparagraph/). Δείτε [**Animated Text**](/slides/el/python-net/animated-text/).

{{% /alert %}} 

## **Εφαρμογή κίνησης σε PictureFrame**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ή λάβετε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) στη διαφάνεια. 
4. Λάβετε τη κύρια ακολουθία των εφέ.
5. Προσθέστε ένα εφέ κίνησης στο [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/).
6. Γράψτε την παρουσίαση στον δίσκο ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ `Fly` σε ένα πλαίσιο εικόνας:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as pres:
    # Φορτώνει την εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Προσθέτει πλαίσιο εικόνας στη διαφάνεια
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Λαμβάνει τη βασική ακολουθία της διαφάνειας.
    sequence = pres.slides[0].timeline.main_sequence

    # Προσθέτει εφέ κίνησης Fly από τα αριστερά στο πλαίσιο εικόνας
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Εφαρμογή κίνησης σε Shape**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/iautoshape/). 
4. Προσθέστε ένα `Bevel` [IAutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/iautoshape/) (όταν αυτό το αντικείμενο κλικάρεται, η κίνηση εκτελείται).
5. Δημιουργήστε μια ακολουθία εφέ στο σχήμα bevel.
6. Δημιουργήστε ένα προσαρμοσμένο `UserPath`.
7. Προσθέστε εντολές για τη μετακίνηση στο `UserPath`.
8. Γράψτε την παρουσίαση στον δίσκο ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ `PathFootball` (path football) σε ένα σχήμα:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Δημιουργεί το εφέ PathFootball για υπάρχον σχήμα από το μηδέν.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Προσθέτει το εφέ κίνησης PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Δημιουργεί κάποιο είδος «κουμπιού».
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Δημιουργεί μια ακολουθία εφέ για το κουμπί.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Δημιουργεί προσαρμοσμένη διαδρομή χρήστη. Το αντικείμενό μας θα κινηθεί μόνο μετά το κλικ του κουμπιού.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Προσθέτει εντολές κίνησης επειδή η δημιουργημένη διαδρομή είναι κενή.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Γράφει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Λήψη των εφέ κίνησης που εφαρμόζονται σε Shape**

Τα παρακάτω παραδείγματα δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `get_effects_by_shape` από την κλάση [Sequence](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/) για να λάβετε όλα τα εφέ κίνησης που εφαρμόζονται σε ένα σχήμα.

**Παράδειγμα 1: Λήψη εφέ κίνησης που εφαρμόζονται σε σχήμα σε κανονική διαφάνεια**

Στο παρελθόν, μάθατε πώς να προσθέτετε εφέ κίνησης σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείχνει πώς να λάβετε τα εφέ που εφαρμόζονται στο πρώτο σχήμα της πρώτης κανονικής διαφάνειας στην παρουσίαση `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Λαμβάνει τη βασική ακολουθία κίνησης της διαφάνειας.
    sequence = first_slide.timeline.main_sequence

    # Λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια.
    shape = first_slide.shapes[0]

    # Λαμβάνει τα εφέ κίνησης που εφαρμόζονται στο σχήμα.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Παράδειγμα 2: Λήψη όλων των εφέ κίνησης, συμπεριλαμβανομένων αυτών που κληρονόμησαν από placeholders**

Εάν ένα σχήμα σε κανονική διαφάνεια έχει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στην κύρια διαφάνεια, και έχουν προστεθεί εφέ κίνησης σε αυτά τα placeholders, τότε όλα τα εφέ του σχήματος θα εκτελεστούν κατά τη διάρκεια της παρουσίασης, συμπεριλαμβανομένων αυτών που κληρονόμησαν από τα placeholders.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης PowerPoint `sample.pptx` με μία διαφάνεια που περιέχει μόνο ένα σχήμα υποσέλιδου με το κείμενο "Made with Aspose.Slides" και το εφέ **Random Bars** έχει εφαρμοστεί στο σχήμα.

![Slide shape animation effect](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **layout** διαφάνεια.

![Layout shape animation effect](layout-shape-animation.png)

Τέλος, το εφέ **Fly In** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **master** διαφάνεια.

![Master shape animation effect](master-shape-animation.png)

Ο παρακάτω κώδικας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `get_base_placeholder` από την κλάση [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) για να αποκτήσετε πρόσβαση στα placeholders του σχήματος και να λάβετε τα εφέ κίνησης που εφαρμόζονται στο σχήμα υποσέλιδου, συμπεριλαμβανομένων αυτών που κληρονόμησαν από placeholders που βρίσκονται στις διαφάνειες διάταξης και κύριας.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Λάβετε τα εφέ κίνησης του σχήματος στην κανονική διαφάνεια.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Λάβετε τα εφέ κίνησης του placeholder στην διαφάνεια διάταξης.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Λάβετε τα εφέ κίνησης του placeholder στην κύρια διαφάνεια.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Αλλαγή ιδιοτήτων χρονισμού εφέ κίνησης**

Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να αλλάξετε τις ιδιότητες Timing (χρονισμού) ενός εφέ κίνησης.

Αυτό είναι το παράθυρο Animation Timing στο Microsoft PowerPoint:

![example1_image](shape-animation.png)

Αυτές είναι οι αντιστοιχίες μεταξύ του PowerPoint Timing και των ιδιοτήτων `Effect.Timing`:

- Η λίστα επιλογής **Start** του PowerPoint Timing ταιριάζει με την ιδιότητα [Effect.Timing.TriggerType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/). 
- Το **Duration** του PowerPoint Timing ταιριάζει με την ιδιότητα `Effect.Timing.Duration`. Η διάρκεια μιας κίνησης (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που χρειάζεται η κίνηση για να ολοκληρώσει έναν κύκλο. 
- Το **Delay** του PowerPoint Timing ταιριάζει με την ιδιότητα `Effect.Timing.TriggerDelayTime`. 

Αυτή είναι η διαδικασία για την αλλαγή των ιδιοτήτων Effect Timing:

1. [Εφαρμόστε](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.
2. Ορίστε νέες τιμές για τις ιδιότητες `Effect.Timing` που χρειάζεστε. 
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει τη λειτουργία:

```python
import aspose.slides as slides

# Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Λαμβάνει τη βασική ακολουθία της διαφάνειας.
    sequence = pres.slides[0].timeline.main_sequence

    # Λαμβάνει το πρώτο εφέ της βασικής ακολουθίας.
    effect = sequence[0]

    # Αλλάζει το TriggerType του εφέ ώστε να ξεκινά με κλικ
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Αλλάζει τη διάρκεια του εφέ
    effect.timing.duration = 3

    # Αλλάζει το TriggerDelayTime του εφέ
    effect.timing.trigger_delay_time = 0.5

    # Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ήχος εφέ κίνησης**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες για να δουλέψετε με ήχους σε εφέ κίνησης: 

- `sound`
- `stop_previous_sound`

### **Προσθήκη ήχου εφέ κίνησης**

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε ήχο σε εφέ κίνησης και να τον σταματήσετε όταν ξεκινά το επόμενο εφέ:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Λαμβάνει τη βασική ακολουθία της διαφάνειας.
    sequence = first_slide.timeline.main_sequence

    # Λαμβάνει το πρώτο εφέ της βασικής ακολουθίας
    first_effect = sequence[0]

    # Ελέγχει το εφέ για «Χωρίς ήχο»
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Προσθέτει ήχο στο πρώτο εφέ
        first_effect.sound = effect_sound

    # Λαμβάνει την πρώτη διαδραστική ακολουθία της διαφάνειας.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Ορίζει τη σημαία «Σταμάτημα προηγούμενου ήχου»
    interactive_sequence[0].stop_previous_sound = True

    # Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Εξαγωγή ήχου εφέ κίνησης**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Λάβετε τη κύρια ακολουθία των εφέ. 
4. Εξαγάγετε το `sound` ενσωματωμένο σε κάθε εφέ κίνησης. 

Αυτός ο κώδικας Python δείχνει πώς να εξαγάγετε τον ήχο ενσωματωμένο σε ένα εφέ κίνησης:

```python
import aspose.slides as slides

# Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Λαμβάνει τη βασική ακολουθία της διαφάνειας.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Εξάγει τον ήχο του εφέ σε δυαδικό πίνακα
        audio = effect.sound.binary_data
```

## **Μετά την κίνηση**

Το Aspose.Slides για .NET σας επιτρέπει να αλλάξετε την ιδιότητα After animation (Μετά την κίνηση) ενός εφέ κίνησης.

Αυτό είναι το παράθυρο Animation Effect και το εκτεταμένο μενού στο Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Η λίστα επιλογής **After animation** του PowerPoint Effect ταιριάζει με τις παρακάτω ιδιότητες: 

- Η ιδιότητα `after_animation_type` που περιγράφει τον τύπο After animation:
  * Το **More Colors** του PowerPoint ταιριάζει με τον τύπο [COLOR](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/);
  * Το στοιχείο **Don't Dim** του PowerPoint ταιριάζει με τον τύπο [DO_NOT_DIM](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/) (προεπιλεγμένος τύπος after animation);
  * Το στοιχείο **Hide After Animation** του PowerPoint ταιριάζει με τον τύπο [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/);
  * Το στοιχείο **Hide on Next Mouse Click** του PowerPoint ταιριάζει με τον τύπο [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/);
- Η ιδιότητα `after_animation_color` που ορίζει τη μορφή χρώματος μετά την κίνηση. Αυτή η ιδιότητα λειτουργεί σε συνδυασμό με τον τύπο [COLOR](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/afteranimationtype/). Εάν αλλάξετε τον τύπο σε κάποιον άλλο, το χρώμα after animation θα διαγραφεί.

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε ένα after animation effect:

```python
import aspose.slides as slides

# Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Λαμβάνει το πρώτο εφέ της βασικής ακολουθίας
    first_effect = first_slide.timeline.main_sequence[0]

    # Αλλάζει τον τύπο after animation σε Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Ορίζει το χρώμα μετά την κίνηση
    first_effect.after_animation_color.color = Color.alice_blue

    # Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Κίνηση κειμένου**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες για να δουλέψετε με το τμήμα *Animate text* ενός εφέ κίνησης:

- `animate_text_type` που περιγράφει τον τύπο animate text του εφέ. Το κείμενο του σχήματος μπορεί να αναπαραχθεί:
  - Όλα μαζί ([ALL_AT_ONCE](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/animatetexttype/) τύπος)
  - Λέξη προς λέξη ([BY_WORD](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/animatetexttype/) τύπος)
  - Γράμμα προς γράμμα ([BY_LETTER](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/animatetexttype/) τύπος)
- `delay_between_text_parts` ορίζει καθυστέρηση μεταξύ των τμημάτων του ανακινούμενου κειμένου (λέξεων ή γραμμάτων). Μια θετική τιμή καθορίζει το ποσοστό της διάρκειας του εφέ. Μια αρνητική τιμή καθορίζει την καθυστέρηση σε δευτερόλεπτα.

Αυτή είναι η διαδικασία για την αλλαγή των ιδιοτήτων Effect Animate text:

1. [Εφαρμόστε](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.
2. Ορίστε την ιδιότητα `build_type` στην τιμή [AS_ONE_OBJECT](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/buildtype/) για να απενεργοποιήσετε τη λειτουργία κίνησης *By Paragraphs*.
3. Ορίστε νέες τιμές για τις ιδιότητες `animate_text_type` και `delay_between_text_parts`.
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει τη λειτουργία:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Λαμβάνει το πρώτο εφέ της βασικής ακολουθίας
    first_effect = first_slide.timeline.main_sequence[0]

    # Αλλάζει τον τύπο κειμενικής κίνησης του εφέ σε «Ως ένα αντικείμενο»
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε «Λέξη προς λέξη»
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Ορίζει την καθυστέρηση μεταξύ λέξεων στο 20% της διάρκειας του εφέ
    first_effect.delay_between_text_parts = 20

    # Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να διασφαλίσω ότι οι κινήσεις διατηρούνται όταν δημοσιεύω την παρουσίαση στο web;**

[Export to HTML5](/slides/el/python-net/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/html5options/) που είναι υπεύθυνες για τις κινήσεις [shape](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/html5options/animate_shapes/) και [transition](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/html5options/animate_transitions/) animations. Το απλό HTML δεν εκτελεί κινήσεις διαφάνειας, ενώ το HTML5 το κάνει.

**Πώς η αλλαγή του z-order (σειράς επιπέδων) των σχημάτων επηρεάζει την κίνηση;**

Οι κινήσεις και η σειρά σχεδίασης είναι ανεξάρτητες: ένα εφέ ελέγχει το χρονισμό και τον τύπο της εμφάνισης/απόκρυψης, ενώ το [z-order](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/z_order_position/) καθορίζει ποιο καλύπτει τι. Το ορατό αποτέλεσμα ορίζεται από το συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο effects-and-shapes του Aspose.Slides ακολουθεί την ίδια λογική.)

**Υπάρχουν περιορισμοί κατά τη μετατροπή των κινήσεων σε βίντεο για ορισμένα εφέ;**

Γενικά, τα [animations are supported](/slides/el/python-net/convert-powerpoint-to-video/), αλλά σπάνιες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνιστάται να δοκιμάζετε με τα εφέ που χρησιμοποιείτε και με την έκδοση της βιβλιοθήκης.