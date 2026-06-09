---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Βίντεο με Python
linktitle: PowerPoint σε Βίντεο
type: docs
weight: 130
url: /el/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint σε βίντεο
- μετατροπή PowerPoint σε βίντεο
- παρουσίαση σε βίντεο
- μετατροπή παρουσίασης σε βίντεο
- PPT σε βίντεο
- μετατροπή PPT σε βίντεο
- PPTX σε βίντεο
- μετατροπή PPTX σε βίντεο
- ODP σε βίντεο
- μετατροπή ODP σε βίντεο
- PowerPoint σε MP4
- μετατροπή PowerPoint σε MP4
- παρουσίαση σε MP4
- μετατροπή παρουσίασης σε MP4
- PPT σε MP4
- μετατροπή PPT σε MP4
- PPTX σε MP4
- μετατροπή PPTX σε MP4
- μετατροπή PowerPoint σε βίντεο
- μετατροπή παρουσίασης σε βίντεο
- μετατροπή PPT σε βίντεο
- μετατροπή PPTX σε βίντεο
- μετατροπή ODP σε βίντεο
- μετατροπή βίντεο με Python
- PowerPoint
- Python
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint και OpenDocument σε βίντεο χρησιμοποιώντας Python. Ανακαλύψτε δείγμα κώδικα και τεχνικές αυτοματοποίησης για τη βελτιστοποίηση της ροής εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασης PowerPoint ή OpenDocument σε βίντεο, κερδίζετε:

**Αυξημένη προσβασιμότητα:** Όλες οι συσκευές, ανεξαρτήτως πλατφόρμας, διαθέτουν προεγκατεστημένους αναπαραγωγείς βίντεο, καθιστώντας πιο εύκολο για τους χρήστες το άνοιγμα ή την αναπαραγωγή βίντεο σε σύγκριση με τις παραδοσιακές εφαρμογές παρουσιάσεων.

**Μεγαλύτερη εμβέλεια:** Τα βίντεο σας επιτρέπουν να φτάσετε σε μεγαλύτερο κοινό και να παρουσιάσετε πληροφορίες με πιο ελκυστική μορφή. Έρευνες και στατιστικές δείχνουν ότι οι άνθρωποι προτιμούν να παρακολουθούν και να καταναλώνουν βίντεο περιεχόμενο σε σχέση με άλλες μορφές, καθιστώντας το μήνυμά σας πιο ισχυρό.

{{% alert color="primary" %}} 
Δείτε τον [**Μετατροπέας PowerPoint σε Βίντεο Online**](https://products.aspose.app/slides/el/video) επειδή προσφέρει μια ζωντανή και αποτελεσματική υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}} 

Στο [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/el/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), υλοποιήσαμε την υποστήριξη μετατροπής παρουσιάσεων σε βίντεο.

* Χρησιμοποιήστε το Aspose.Slides for Python για να δημιουργήσετε καρέ από τις διαφάνειες παρουσίασης με καθορισμένο ρυθμό καρέ (FPS).
* Στη συνέχεια, χρησιμοποιήστε ένα εξωτερικό εργαλείο όπως το ffmpeg για να συναρμολογήσετε αυτά τα καρέ σε ένα βίντεο.

## **Μετατροπή Παρουσίασης PowerPoint σε Βίντεο**

1. Χρησιμοποιήστε την εντολή pip install για να προσθέσετε το Aspose.Slides for Python στο έργο σας: `pip install aspose-slides==24.4.0`
2. Κατεβάστε το ffmpeg από [εδώ](https://ffmpeg.org/download.html) ή εγκαταστήστε το μέσω του διαχειριστή πακέτων.
3. Βεβαιωθείτε ότι το ffmpeg βρίσκεται στο `PATH`. Διαφορετικά, εκκινήστε το ffmpeg χρησιμοποιώντας το πλήρες μονοπάτι προς το εκτελέσιμο (π.χ., `C:\ffmpeg\ffmpeg.exe` στα Windows ή `/opt/ffmpeg/ffmpeg` στο Linux).
4. Εκτελέστε τον κώδικα μετατροπής PowerPoint σε βίντεο.

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε μια παρουσίαση (που περιέχει ένα σχήμα και δύο εφέ κίνησης) σε βίντεο:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **Εφέ Βίντεο**

Κατά τη μετατροπή μιας παρουσίασης PowerPoint σε βίντεο χρησιμοποιώντας το Aspose.Slides for Python, μπορείτε να εφαρμόσετε διάφορα εφέ βίντεο για να ενισχύσετε την οπτική ποιότητα του αποτελέσματος. Τα εφέ αυτά σας επιτρέπουν να ελέγχετε την εμφάνιση των διαφανειών στο τελικό βίντεο προσθέτοντας ομαλές μεταβάσεις, κινήσεις και άλλα οπτικά στοιχεία. Αυτή η ενότητα εξηγεί τις διαθέσιμες επιλογές εφέ βίντεο και δείχνει πώς να τις εφαρμόζετε.

{{% alert color="primary" %}} 
Δείτε [Κίνηση PowerPoint](https://docs.aspose.com/slides/el/python-net/powerpoint-animation/), [Κίνηση Σχήματος](https://docs.aspose.com/slides/el/python-net/shape-animation/), και [Εφέ Σχήματος](https://docs.aspose.com/slides/el/python-net/shape-effect/).
{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες — και το ίδιο ισχύει για τα βίντεο. Ας προσθέσουμε μια επιπλέον διαφάνεια και μετάβαση στον κώδικα για την προηγούμενη παρουσίαση:

```python
import aspose.pydrawing as drawing

# Προσθήκη σχήματος χαμόγελου και κίνησή του.
# ...

# Προσθήκη νέας διαφάνειας και κινούμενης μετάβασης.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Το Aspose.Slides for Python υποστηρίζει επίσης κινήσεις κειμένου. Σε αυτό το παράδειγμα, κάνουμε κίνηση στις παραγράφους των αντικειμένων ώστε να εμφανίζονται μία μετά την άλλη, με καθυστέρηση ενός δευτερολέπτου μεταξύ τους:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθήκη κειμένου και κινήσεων.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Μετατροπή καρέ σε βίντεο.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Κλάσεις Μετατροπής Βίντεο**

Για την εκτέλεση εργασιών μετατροπής PowerPoint σε βίντεο, το Aspose.Slides for Python παρέχει το [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` σάς επιτρέπει να ορίσετε το μέγεθος του καρέ για το βίντεο (που θα δημιουργηθεί αργότερα) και την τιμή FPS (καρέ ανά δευτερόλεπτο) μέσω του κατασκευαστή του. Εάν περάσετε μια παρουσίαση, θα χρησιμοποιηθεί το `Presentation.SlideSize` της.

Για να κάνετε όλες τις κινήσεις σε μια παρουσίαση να εκτελούνται ταυτόχρονα, χρησιμοποιήστε τη μέθοδο `PresentationEnumerableFramesGenerator.enumerate_frames`. Αυτή η μέθοδος δέχεται μια συλλογή διαφανειών και επιστρέφει διαδοχικά [EnumerableFrameArgs](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/enumerableframeargs/). Στη συνέχεια, χρησιμοποιήστε `EnumerableFrameArgs.get_frame()` για να λάβετε κάθε καρέ του βίντεο.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Στη συνέχεια τα παραγόμενα καρέ μπορούν να συναρμολογηθούν σε βίντεο. Για περισσότερες λεπτομέρειες, δείτε την ενότητα [Μετατροπή PowerPoint σε Βίντεο](https://docs.aspose.com/slides/el/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Υποστηριζόμενες Κινήσεις και Εφέ**

Κατά τη μετατροπή μιας παρουσίασης PowerPoint σε βίντεο χρησιμοποιώντας το Aspose.Slides for Python, είναι σημαντικό να κατανοήσετε ποιες κινήσεις και ποια εφέ υποστηρίζονται στην έξοδο. Το Aspose.Slides υποστηρίζει μια ευρεία γκάμα κοινών εφέ εισόδου, εξόδου και έμφασης όπως fade, fly in, zoom και spin. Ωστόσο, ορισμένες προχωρημένες ή προσαρμοσμένες κινήσεις μπορεί να μην διατηρηθούν πλήρως ή να εμφανιστούν διαφορετικά στο τελικό βίντεο. Αυτή η ενότητα περιγράφει τις υποστηριζόμενες κινήσεις και εφέ.

**Είσοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εμφάνιση** | ![not supported](x.png) | ![supported](v.png) |
| **Ξεθώριασμα** | ![supported](v.png) | ![supported](v.png) |
| **Πτήση Εισόδου** | ![supported](v.png) | ![supported](v.png) |
| **Αιωρούμενη Εισαγωγή** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Σκούπισμα** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![supported](v.png) | ![supported](v.png) |
| **Τροχός** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίες Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Ανάπτυξη & Περιστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αναπήδηση** | ![supported](v.png) | ![supported](v.png) |

**Έμφαση**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Παλμός** | ![not supported](x.png) | ![supported](v.png) |
| **Χρωματικός Παλμός** | ![not supported](x.png) | ![supported](v.png) |
| **Ανατάραξη** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Ανάπτυξη/Σμίκρυνση** | ![not supported](x.png) | ![supported](v.png) |
| **Αποκορεσμός** | ![not supported](x.png) | ![supported](v.png) |
| **Σκοτείνιασμα** | ![not supported](x.png) | ![supported](v.png) |
| **Φωτεινότητα** | ![not supported](x.png) | ![supported](v.png) |
| **Διαφάνεια** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Αντικειμένου** | ![not supported](x.png) | ![supported](v.png) |
| **Συμπληρωματικό Χρώμα** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Γραμμής** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Γέμισης** | ![not supported](x.png) | ![supported](v.png) |

**Έξοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εξαφάνιση** | ![not supported](x.png) | ![supported](v.png) |
| **Ξεθώριασμα** | ![supported](v.png) | ![supported](v.png) |
| **Πτήση Εξόδου** | ![supported](v.png) | ![supported](v.png) |
| **Αιωρούμενη Έξοδος** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Σκούπισμα** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίες Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Σμίκρυνση & Περιστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αναπήδηση** | ![supported](v.png) | ![supported](v.png) |

**Διαδρομές Κίνησης**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Τόξα** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφές** | ![supported](v.png) | ![supported](v.png) |
| **Σχήματα** | ![supported](v.png) | ![supported](v.png) |
| **Βρόχοι** | ![supported](v.png) | ![supported](v.png) |
| **Προσαρμοσμένη Διαδρομή** | ![supported](v.png) | ![supported](v.png) |

## **Υποστηριζόμενα Εφέ Μετάβασης Διαφάνειας**

Τα εφέ μετάβασης διαφάνειας παίζουν σημαντικό ρόλο στη δημιουργία ομαλών και οπτικά ελκυστικών αλλαγών μεταξύ των διαφανειών σε ένα βίντεο. Το Aspose.Slides for Python υποστηρίζει μια ποικιλία συχνά χρησιμοποιούμενων εφέ μετάβασης για να βοηθήσει στη διατήρηση της ροής και του στυλ της αρχικής παρουσίασης. Αυτή η ενότητα υποδεικνύει ποια εφέ μετάβασης υποστηρίζονται κατά τη διαδικασία μετατροπής.

**Απαλή**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Μεταμόρφωση** | ![not supported](x.png) | ![supported](v.png) |
| **Ξεθώριασμα** | ![supported](v.png) | ![supported](v.png) |
| **Ωθηση** | ![supported](v.png) | ![supported](v.png) |
| **Τράβηγμα** | ![supported](v.png) | ![supported](v.png) |
| **Σκούπισμα** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Αποκάλυψη** | ![not supported](x.png) | ![supported](v.png) |
| **Τυχαίες Μπάρες** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![not supported](x.png) | ![supported](v.png) |
| **Αποκάλυψη** | ![not supported](x.png) | ![supported](v.png) |
| **Κάλυψη** | ![supported](v.png) | ![supported](v.png) |
| **Αναλαμπή** | ![supported](v.png) | ![supported](v.png) |
| **Ταινίες** | ![supported](v.png) | ![supported](v.png) |

**Δυναμική**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Πτώση** | ![not supported](x.png) | ![supported](v.png) |
| **Κάλυψη** | ![not supported](x.png) | ![supported](v.png) |
| **Κουρτίνες** | ![not supported](x.png) | ![supported](v.png) |
| **Άνεμος** | ![not supported](x.png) | ![supported](v.png) |
| **Κύρος** | ![not supported](x.png) | ![supported](v.png) |
| **Ρήγμα** | ![not supported](x.png) | ![supported](v.png) |
| **Σπρώξιμο** | ![not supported](x.png) | ![supported](v.png) |
| **Απογύρισμα** | ![not supported](x.png) | ![supported](v.png) |
| **Τύλιγμα Σελίδας** | ![not supported](x.png) | ![supported](v.png) |
| **Αεροπλάνο** | ![not supported](x.png) | ![supported](v.png) |
| **Οριγκάμι** | ![not supported](x.png) | ![supported](v.png) |
| **Διάλυση** | ![supported](v.png) | ![supported](v.png) |
| **Σκακιόδρομος** | ![not supported](x.png) | ![supported](v.png) |
| **Προβολοί** | ![not supported](x.png) | ![supported](v.png) |
| **Ρολόι** | ![supported](v.png) | ![supported](v.png) |
| **Κυματισμός** | ![not supported](x.png) | ![supported](v.png) |
| **Κέλυφος Κυψέλης** | ![not supported](x.png) | ![supported](v.png) |
| **Λάμψη** | ![not supported](x.png) | ![supported](v.png) |
| **Δίχτυ** | ![not supported](x.png) | ![supported](v.png) |
| **Τεμαχισμός** | ![not supported](x.png) | ![supported](v.png) |
| **Αλλαγή** | ![not supported](x.png) | ![supported](v.png) |
| **Αναστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Γκαλερί** | ![not supported](x.png) | ![supported](v.png) |
| **Κύβο** | ![not supported](x.png) | ![supported](v.png) |
| **Πόρτες** | ![not supported](x.png) | ![supported](v.png) |
| **Κουτί** | ![not supported](x.png) | ![supported](v.png) |
| **Χτένα** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίο** | ![not supported](x.png) | ![supported](v.png) |

**Δυναμικό Περιεχόμενο**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Πανόραμα** | ![not supported](x.png) | ![supported](v.png) |
| **Τροχός Ferris** | ![supported](v.png) | ![supported](v.png) |
| **Μεταφορέας** | ![not supported](x.png) | ![supported](v.png) |
| **Περιστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Τροχιά** | ![not supported](x.png) | ![supported](v.png) |
| **Πτήση Διαμέσου** | ![supported](v.png) | ![supported](v.png) |

## **Συχνές Ερωτήσεις**

**Μπορεί να μετατραπούν παρουσιάσεις που είναι προστατευμένες με κωδικό;**

Ναι, το Aspose.Slides for Python επιτρέπει την εργασία με παρουσιάσεις που είναι προστατευμένες με κωδικό. Όταν επεξεργάζεστε τέτοια αρχεία, πρέπει να παρέχετε τον σωστό κωδικό ώστε η βιβλιοθήκη να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

**Υποστηρίζει το Aspose.Slides for Python χρήση σε λύσεις cloud;**

Ναι, το Aspose.Slides for Python μπορεί να ενσωματωθεί σε εφαρμογές και υπηρεσίες cloud. Η βιβλιοθήκη έχει σχεδιαστεί ώστε να λειτουργεί σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και κλιμακωσιμότητα για μαζική επεξεργασία αρχείων.

**Υπάρχουν περιορισμοί μεγέθους για τις παρουσιάσεις κατά τη μετατροπή;**

Το Aspose.Slides for Python είναι ικανό να διαχειριστεί παρουσιάσεις σχεδόν οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, μπορεί να απαιτούνται πρόσθετοι πόροι συστήματος και συχνά συνιστάται η βελτιστοποίηση της παρουσίασης για βελτιωμένη απόδοση.