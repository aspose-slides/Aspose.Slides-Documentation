---
title: Μετατροπή παρουσιάσεων PowerPoint σε βίντεο με Python
linktitle: PowerPoint σε βίντεο
type: docs
weight: 130
url: /el/python-java/convert-powerpoint-to-video/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε βίντεο
- παρουσίαση σε βίντεο
- PPT σε βίντεο
- PPTX σε βίντεο
- PowerPoint σε MP4
- παρουσίαση σε MP4
- PPT σε MP4
- PPTX σε MP4
- αποθήκευση PPT ως MP4
- αποθήκευση PPTX ως MP4
- εξαγωγή PPT σε MP4
- εξαγωγή PPTX σε MP4
- μετατροπή βίντεο
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε βίντεο MP4 με Python μέσω Java. Δημιουργήστε πλαίσια με Aspose.Slides και κωδικοποιήστε τα με FFmpeg, συμπεριλαμβανομένων κινήσεων και μεταβάσεων."
---
## **Επισκόπηση**

Η μετατροπή μιας παρουσίασης PowerPoint ή OpenDocument σε βίντεο επιτρέπει στους θεατές να παρακολουθούν το περιεχόμενό της σε πρόγραμμα αναπαραγωγής βίντεο χωρίς να ανοίγουν εφαρμογή παρουσίασης. Το Aspose.Slides for Python via Java αποδίδει τις κινήσεις και τις μεταβάσεις της παρουσίασης σε πλαίσια εικόνας. Ένας ξεχωριστός κωδικοποιητής, όπως το FFmpeg, συνδυάζει αυτά τα πλαίσια σε αρχείο βίντεο.

{{% alert color="info" title="Σημείωση" %}}
Δοκιμάστε τον online μετατροπέα PowerPoint σε Βίντεο για να δείτε τη μετατροπή παρουσίασης σε βίντεο σε δράση.
{{% /alert %}}

## **Μετατροπή PowerPoint σε Βίντεο**

Η μετατροπή αποτελείται από δύο στάδια: δημιουργία πλαισίων PNG με επιλεγμένο ρυθμό καρέ και, στη συνέχεια, κωδικοποίηση της ακολουθίας εικόνων ως MP4. Χρησιμοποιήστε τον ίδιο ρυθμό καρέ και στα δύο στάδια για να διατηρήσετε το χρονοδιάγραμμα των κινήσεων.

Πριν εκτελέσετε το παράδειγμα:

1. Εγκαταστήστε το [Aspose.Slides for Python via Java](/slides/el/python-java/installation/).
2. Κατεβάστε το [FFmpeg](https://ffmpeg.org/download.html) και κάντε το εκτελέσιμο του διαθέσιμο στο `PATH`. Το παράδειγμα χρησιμοποιεί μια έκδοση με τον κωδικοποιητή `libx264`.
3. Εκτελέστε τον παρακάτω κώδικα Python σε έναν φάκελο με δυνατότητα εγγραφής.

Το παράδειγμα δημιουργεί ένα σχήμα με χαμόγελο, προσθέτει κινήσεις εισόδου και εξόδου, αποδίδει πλαίσια στα 30 FPS και καλεί το FFmpeg για τη δημιουργία του `output.mp4`. Ένας φρέσκος φάκελος πλαισίων αποτρέπει την προσθήκη πλαισίων από προηγούμενες εκτελέσεις στο βίντεο.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Για να μετατρέψετε ένα υπάρχον αρχείο, αρχικοποιήστε το [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) με τη διαδρομή του και παραλείψτε τις δηλώσεις δημιουργίας σχήματος και κίνησης.

Η εντολή FFmpeg διαβάζει μια αριθμημένη [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2), συμπληρώνει τις μονές διαστάσεις σε ζυγές τιμές και γράφει βίντεο H.264 με μορφή pixel `yuv420p`. Η επιλογή `-n` αποτρέπει την αντικατάσταση υπάρχοντος αρχείου εξόδου. Τα παραγόμενα αρχεία PNG παραμένουν στο φάκελο πλαισίων· αφαιρέστε τα όταν δεν χρειάζονται πλέον.

{{% alert color="info" title="Σημείωση" %}}
Αυτό το παράδειγμα κωδικοποιεί μόνο τα πλαίσια εικόνας. Δεν προσθέτει αφήγηση ή ενσωματωμένο ήχο παρουσίασης στο τελικό βίντεο.
{{% /alert %}}

## **Εφέ Βίντεο**

Οι κινήσεις ελέγχουν πώς εμφανίζονται, μετακινούνται ή εξαφανίζονται τα αντικείμενα της διαφάνειας. Οι μεταβάσεις ελέγχουν την αλλαγή μεταξύ των διαφανειών. Προσθέστε αυτά τα εφέ πριν δημιουργήσετε τα πλαίσια βίντεο.

Δείτε το [PowerPoint Animation](/slides/el/python-java/powerpoint-animation/), το [Shape Animation](/slides/el/python-java/shape-animation/), το [Shape Effects](/slides/el/python-java/shape-effect/) και τις [Slide Transitions](/slides/el/python-java/slide-transition/).

### **Προσθήκη Μετάβασης Διαφάνειας**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση με δύο διαφάνειες. Η δεύτερη διαφάνεια έχει φόντο ματζέντα και μετάβαση τύπου push. Αποθηκεύστε την παρουσίαση και χρησιμοποιήστε την ως είσοδο για το παράδειγμα δημιουργίας πλαισίων παραπάνω.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Κίνηση Παραγράφων**

Το κείμενο μπορεί να εμφανίζεται παράγραφο προς παράγραφο. Αυτό το παράδειγμα δημιουργεί τρεις παραγράφους με διαδοχικά εφέ fade εισόδου, καθένα με καθυστέρηση ενός δευτερολέπτου μετά το προηγούμενο εφέ. Χρησιμοποιήστε το αποθηκευμένο αρχείο `paragraphs.pptx` ως είσοδο για το παράδειγμα μετατροπής βίντεο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κλάσεις Μετατροπής Βίντεο**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationanimationsgenerator/) δημιουργεί γεγονότα κίνησης για τις διαφάνειες. Η κατασκευή του από μια παρουσίαση χρησιμοποιεί το μέγεθος διαφάνειας της παρουσίασης για τα πλαίσια. Χρησιμοποιήστε το [setDefaultDelay](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) για να ορίσετε την προεπιλεγμένη καθυστέρηση σε χιλιοστά του δευτερολέπτου.

[PresentationPlayer](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationplayer/) προσαρμόζει τις παραγόμενες κινήσεις στον ρυθμό καρέ που δίνεται στον κατασκευαστή του. Καταχωρίστε μια κλήση Python μέσω JPype με το [setFrameTick](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationplayer/#setFrameTick), έπειτα καλέστε το [run](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationanimationsgenerator/#run) για να δημιουργήσετε τα πλαίσια. Το πρώτο παράδειγμα χρησιμοποιεί τον δικό του μετρητή μηδενικής βάσης ώστε τα ονόματα αρχείων να ταιριάζουν με τη σειρά εισόδου του FFmpeg.

Για μεμονωμένες καταστάσεις κίνησης, καταχωρίστε μια κλήση με το [setNewAnimation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Η κλήση λαμβάνει έναν παίκτη κίνησης που μπορεί να τοποθετηθεί σε επιλεγμένο χρόνο. Το παρακάτω παράδειγμα αποθηκεύει τα πρώτα και τελευταία πλαίσια κάθε παραγόμενης κίνησης με μοναδικά ονόματα αρχείων:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Υποστηριζόμενες Κινήσεις και Εφέ**

Οι παρακάτω πίνακες συνοψίζουν την υποστήριξη απόδοσης που περιγράφεται στο άρθρο μετατροπής Java. Προσδιορίστε τα παραγόμενα πλαίσια όταν μια παρουσίαση χρησιμοποιεί εφέ που δεν υποστηρίζονται.

**Είσοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | Όχι | Ναι |
| **Fade** | Ναι | Ναι |
| **Fly In** | Ναι | Ναι |
| **Float In** | Ναι | Ναι |
| **Split** | Ναι | Ναι |
| **Wipe** | Ναι | Ναι |
| **Shape** | Ναι | Ναι |
| **Wheel** | Ναι | Ναι |
| **Random Bars** | Ναι | Ναι |
| **Grow & Turn** | Όχι | Ναι |
| **Zoom** | Ναι | Ναι |
| **Swivel** | Ναι | Ναι |
| **Bounce** | Ναι | Ναι |

**Τός**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | Όχι | Ναι |
| **Color Pulse** | Όχι | Ναι |
| **Teeter** | Ναι | Ναι |
| **Spin** | Ναι | Ναι |
| **Grow/Shrink** | Όχι | Ναι |
| **Desaturate** | Όχι | Ναι |
| **Darken** | Όχι | Ναι |
| **Lighten** | Όχι | Ναι |
| **Transparency** | Όχι | Ναι |
| **Object Color** | Όχι | Ναι |
| **Complementary Color** | Όχι | Ναι |
| **Line Color** | Όχι | Ναι |
| **Fill Color** | Όχι | Ναι |

**Έξοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | Όχι | Ναι |
| **Fade** | Ναι | Ναι |
| **Fly Out** | Ναι | Ναι |
| **Float Out** | Ναι | Ναι |
| **Split** | Ναι | Ναι |
| **Wipe** | Ναι | Ναι |
| **Shape** | Ναι | Ναι |
| **Random Bars** | Ναι | Ναι |
| **Shrink & Turn** | Όχι | Ναι |
| **Zoom** | Ναι | Ναι |
| **Swivel** | Ναι | Ναι |
| **Bounce** | Ναι | Ναι |

**Διαδρομές Κίνησης**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Ναι | Ναι |
| **Arcs** | Ναι | Ναι |
| **Turns** | Ναι | Ναι |
| **Shapes** | Ναι | Ναι |
| **Loops** | Ναι | Ναι |
| **Custom Path** | Ναι | Ναι |

## **Συχνές Ερωτήσεις**

**Δημιουργεί το Aspose.Slides απευθείας αρχείο MP4;**

Όχι. Το Aspose.Slides παράγει πλαίσια παρουσίασης. Χρησιμοποιήστε κωδικοποιητή βίντεο όπως το FFmpeg για να τα συνδυάσετε σε αρχείο MP4.

**Γιατί το βίντεο παίζει πιο γρήγορα ή πιο αργά από το αναμενόμενο;**

Χρησιμοποιήστε τον ίδιο FPS για τη δημιουργία πλαισίων και για τον ρυθμό εισόδου του κωδικοποιητή. Μια αναντιστοιχία αλλάζει τη διάρκεια αναπαραγωγής της ακολουθίας εικόνων.

**Μπορώ να μετατρέψω μια παρουσίαση με προστασία κωδικού;**

Ναι. Παραχωρήστε τον σωστό κωδικό όταν [φορτώνετε την προστατευμένη παρουσίαση](/slides/el/python-java/password-protected-presentation/), έπειτα δημιουργήστε πλαίσια από το φορτωμένο περιεχόμενο.

**Διατηρεί αυτή η ροή εργασίας τον ήχο της παρουσίασης;**

Τα παραδείγματα εξάγουν μόνο πλαίσια εικόνας, οπότε το παραγόμενο βίντεο είναι σιωπηλό. Για να συμπεριλάβετε ήχο, προσθέστε ένα κομμάτι ήχου ξεχωριστά κατά την κωδικοποίηση του βίντεο.

**Πώς μπορώ να μειώσω τη χρήση προσωρινής μνήμης δίσκου;**

Χρησιμοποιήστε μικρότερο μέγεθος πλαισίου ή χαμηλότερο FPS και αφαιρέστε τα προσωρινά αρχεία PNG μετά την επιτυχή κωδικοποίηση. Ελέγξτε την ποιότητα του βίντεο όταν μειώνετε οποιαδήποτε από τις ρυθμίσεις.