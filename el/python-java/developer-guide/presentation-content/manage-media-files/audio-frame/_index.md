---
title: Διαχείριση Ήχου σε Παρουσιάσεις με Python
linktitle: Πλαίσιο Ήχου
type: docs
weight: 10
url: /el/python-java/audio-frame/
keywords:
- ήχος
- πλαίσιο ήχου
- μικρογραφία
- προσθήκη ήχου
- ιδιότητες ήχου
- επιλογές ήχου
- εξαγωγή ήχου
- Python
- Aspose.Slides
description: "Δημιουργήστε και ελέγξτε πλαίσια ήχου στο Aspose.Slides για Python μέσω Java—παραδείγματα κώδικα για ενσωμάτωση, περικοπή, επανάληψη και διαμόρφωση αναπαραγωγής σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με πλαίσια ήχου στο Aspose.Slides. Δείχνει πώς να προσθέσετε ενσωματωμένο ήχο στις διαφάνειες, να προσαρμόσετε τη μικρογραφία του πλαισίου ήχου, να διαμορφώσετε επιλογές αναπαραγωγής όπως ένταση, επανάληψη, απόκρυψη, περικοπή και διάρκειες εξασθένισης, και να εξάγετε ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης.

## **Δημιουργία Πλαισίων Ήχου**

Το Aspose.Slides for Python μέσω Java σάς επιτρέπει να προσθέσετε αρχεία ήχου στις διαφάνειες. Τα αρχεία ήχου ενσωματώνονται στις διαφάνειες ως πλαίσια ήχου. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Διαβάστε το αρχείο ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο πλαίσιο ήχου (που περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Χρησιμοποιήστε τις μεθόδους [setPlayMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setPlayMode) και [setVolume](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setVolume) που παρέχει το αντικείμενο [AudioFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/) .
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα ενσωματωμένο πλαίσιο ήχου σε μια διαφάνεια:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αλλαγή Μικρογραφίας Πλαισίου Ήχου**

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως πλαίσιο με μια προεπιλεγμένη τυπική εικόνα (δείτε την εικόνα στην παρακάτω ενότητα). Μπορείτε να αλλάξετε την προεπισκόπηση του πλαισίου ήχου σε μια εικόνα της επιλογής σας.

Αυτός ο κώδικας Python σας δείχνει πώς να αλλάξετε τη μικρογραφία ή την προεπισκόπηση ενός πλαισίου ήχου:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αλλαγή Επιλογών Αναπαραγωγής Ήχου**

Το Aspose.Slides for Python μέσω Java σάς επιτρέπει να αλλάξετε τις επιλογές που ελέγχουν την αναπαραγωγή ήχου ή τις ιδιότητές του. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση του ήχου, να ορίσετε τον ήχο σε επανάληψη, ή ακόμη και να κρύψετε το εικονίδιο ήχου.

Το πλέγμα **Audio Options** στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Οι **Audio Options** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/) :

- **Start** η λίστα επιλογών αντιστοιχεί στη μέθοδο [setPlayMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setPlayMode) .
- **Volume** αντιστοιχεί στη μέθοδο [setVolume](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setVolume) .
- **Play Across Slides** αντιστοιχεί στη μέθοδο [setPlayAcrossSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) .
- **Loop until Stopped** αντιστοιχεί στη μέθοδο [setPlayLoopMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setPlayLoopMode) .
- **Hide During Show** αντιστοιχεί στη μέθοδο [setHideAtShowing](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setHideAtShowing) .
- **Rewind after Playing** αντιστοιχεί στη μέθοδο [setRewindAudio](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setRewindAudio) .

Οι επιλογές **Editing** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/) :

- **Fade In** αντιστοιχεί στη μέθοδο [setFadeInDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setFadeInDuration) .
- **Fade Out** αντιστοιχεί στη μέθοδο [setFadeOutDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setFadeOutDuration) .
- **Trim Audio Start Time** αντιστοιχεί στη μέθοδο [setTrimFromStart](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setTrimFromStart) .
- **Trim Audio End Time** η τιμή είναι η διάρκεια του ήχου μείον την τιμή που ορίζεται από τη μέθοδο [setTrimFromEnd](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setTrimFromEnd) .

Ο **Volume control** του PowerPoint στον πίνακα ελέγχου ήχου αντιστοιχεί στη μέθοδο [setVolumeValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setVolumeValue) . Σας επιτρέπει να αλλάξετε την ένταση του ήχου ως ποσοστό.

Αυτό είναι πώς αλλάζετε τις επιλογές αναπαραγωγής ήχου:

1. [Create](#create-audio-frames) ή λάβετε το πλαίσιο ήχου.
2. Ορίστε νέες τιμές για τις ιδιότητες του πλαισίου ήχου που θέλετε να ρυθμίσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

Αυτός ο κώδικας Python επιδεικνύει μια λειτουργία όπου οι επιλογές ήχου ρυθμίζονται:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Αναπαραγωγή με κλικ σε χαμηλή ένταση, σε όλες τις διαφάνειες, χωρίς επανάληψη.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Απόκρυψη του πλαισίου κατά τη διάρκεια της παρουσίασης και επαναφορά μετά την αναπαραγωγή.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Αυτό το παράδειγμα Python δείχνει πώς να προσθέσετε ένα νέο πλαίσιο ήχου με ενσωματωμένο ήχο, να το περικόψετε και να ορίσετε τις διάρκειες εξασθένισης:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Περικοπή 1,5 δευτερολέπτων από την αρχή και 2 δευτερολέπτων από το τέλος.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Ορίστε το fade-in σε 200 ms και το fade-out σε 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ανακτήσετε ένα πλαίσιο ήχου με ενσωματωμένο ήχο και να ορίσετε την ένταση του στο 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Διαχείριση Υποτίτλων Ήχου**

Το Aspose.Slides σάς επιτρέπει να προσθέσετε κλειστούς υπότιτλους σε ένα πλαίσιο ήχου μέσω της μεθόδου [getCaptionTracks](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#getCaptionTracks) . Αυτή η μέθοδος επιστρέφει ένα [CaptionsCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/) , το οποίο σας επιτρέπει να προσθέσετε κομμάτια υποτίτλων WebVTT, να περιηγηθείτε στα υπάρχοντα κομμάτια και να τα αφαιρέσετε όταν χρειάζεται.

**Προσθήκη Υποτίτλων Ήχου**

Χρησιμοποιήστε τη μέθοδο [getCaptionTracks](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#getCaptionTracks) για να συνδέσετε ένα ή περισσότερα κομμάτια υποτίτλων σε ένα πλαίσιο ήχου. Στο παρακάτω παράδειγμα, προστίθεται ένα αρχείο ήχου σε μια διαφάνεια και, στη συνέχεια, ένα νέο κομμάτι υπότιτλου φορτώνεται από ένα αρχείο `.vtt` .

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Προσθήκη νέου κομματιού υποτίτλου από αρχείο WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Εξαγωγή Υποτίτλων Ήχου**

Μπορείτε να περιηγηθείτε στα κομμάτια υποτίτλων που σχετίζονται με ένα πλαίσιο ήχου και να τα αποθηκεύσετε ως αρχεία `.vtt`. Κάθε κομμάτι υπότιτλου εκθέτει τα δυαδικά δεδομένα και το μοναδικό του αναγνωριστικό, τα οποία μπορούν να χρησιμοποιηθούν κατά την εξαγωγή των υποτίτλων.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Αποθήκευση του κομματιού υποτίτλου ως αρχείο .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Αφαίρεση Υποτίτλων Ήχου**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο ήχου, χρησιμοποιήστε τις μεθόδους που παρέχονται από το [CaptionsCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/) , όπως [clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#clear) , [remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#removeAt) . Το παρακάτω παράδειγμα αφαιρεί όλα τα κομμάτια υποτίτλων από ένα πλαίσιο ήχου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Εξαγωγή Ήχου**

Το Aspose.Slides for Python μέσω Java σάς επιτρέπει να εξάγετε τον ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης. Για παράδειγμα, μπορείτε να εξάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Αποκτήστε μια αναφορά στη σχετική διαφάνεια με βάση το δείκτη της.
3. Προσεγγίστε τις [slideshow transitions](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getSlideShowTransition) για τη διαφάνεια.
4. Εξάγετε τον ήχο ως δεδομένα byte.

Αυτός ο κώδικας Python σας δείχνει πώς να εξάγετε τον ήχο που χρησιμοποιείται σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να επαναχρησιμοποιήσω το ίδιο αρχείο ήχου σε πολλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη κοινόχρηστη [audio collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAudios) της παρουσίασης και δημιουργήστε επιπλέον πλαίσια ήχου που αναφέρονται σε αυτό το υπάρχον αρχείο. Αυτό αποφεύγει τη διπλή αποθήκευση των δεδομένων πολυμέσων και διατηρεί το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου χωρίς να ξαναδημιουργήσω το σχήμα;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε το [link path](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setLinkPathLong) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο [embedded audio](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setEmbeddedAudio) με κάποιο άλλο από τη [audio collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAudios) της παρουσίασης. Η μορφοποίηση του πλαισίου και οι περισσότερες ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Αλλάζει η περικοπή τα υποκείμενα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Η περικοπή ρυθμίζει μόνο τα όρια αναπαραγωγής. Τα αρχικά bytes του ήχου παραμένουν αμετάβλητα και προσβάσιμα μέσω του ενσωματωμένου ήχου ή της [audio collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAudios) της παρουσίασης.