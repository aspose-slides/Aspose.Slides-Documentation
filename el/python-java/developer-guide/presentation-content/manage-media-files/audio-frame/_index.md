---
title: Διαχείριση ήχου σε παρουσιάσεις με χρήση Python
linktitle: Πλαίσιο ήχου
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
description: "Δημιουργήστε και ελέγξτε πλαίσια ήχου στο Aspose.Slides για Python μέσω Java—παραδείγματα κώδικα για ενσωμάτωση, κοπή, βρόχο και διαμόρφωση αναπαραγωγής σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με πλαίσια ήχου στο Aspose.Slides. Δείχνει πώς να προσθέτετε ενσωματωμένο ήχο στις διαφάνειες, να προσαρμόζετε τη μικρογραφία του πλαισίου ήχου, να διαμορφώνετε επιλογές αναπαραγωγής όπως η ένταση, η επανάληψη, η απόκρυψη, η κοπή και οι διάρκειες εξασθένισης, και να εξάγετε ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης.

## **Δημιουργία Πλαισίων Ήχου**

Aspose.Slides for Python via Java σάς επιτρέπει να προσθέτετε αρχεία ήχου στις διαφάνειες. Τα αρχεία ήχου ενσωματώνονται στις διαφάνειες ως πλαίσια ήχου. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Διαβάστε το αρχείο ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο πλαίσιο ήχου (που περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Ορίστε τις μεθόδους [setPlayMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setPlayMode) και [setVolume](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setVolume) που παρέχονται από το αντικείμενο [AudioFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε ένα ενσωματωμένο πλαίσιο ήχου σε μια διαφάνεια:

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

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως πλαίσιο με μια τυπική προεπιλεγμένη εικόνα (δείτε την εικόνα στην παρακάτω ενότητα). Μπορείτε να αλλάξετε την εικόνα προεπισκόπησης του πλαισίου ήχου (ορίστε την προτιμώμενη εικόνα).

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε τη μικρογραφία ή την εικόνα προεπισκόπησης ενός πλαισίου ήχου:

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

Aspose.Slides for Python via Java σάς επιτρέπει να αλλάξετε επιλογές που ελέγχουν την αναπαραγωγή ή τις ιδιότητες ενός ήχου. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση του ήχου, να ορίσετε αναπαραγωγή σε βρόχο ή ακόμα και να αποκρύψετε το εικονίδιο ήχου.

Το παράθυρο **Audio Options** στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Οι **Audio Options** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/) :

- **Start** η λίστα πτυσσόμενη αντιστοιχεί στη μέθοδο [setPlayMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** αντιστοιχεί στη μέθοδο [setVolume](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** αντιστοιχεί στη μέθοδο [setPlayAcrossSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** αντιστοιχεί στη μέθοδο [setPlayLoopMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** αντιστοιχεί στη μέθοδο [setHideAtShowing](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** αντιστοιχεί στη μέθοδο [setRewindAudio](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setRewindAudio)

Οι επιλογές **Editing** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/) :

- **Fade In** αντιστοιχεί στη μέθοδο [setFadeInDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** αντιστοιχεί στη μέθοδο [setFadeOutDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** αντιστοιχεί στη μέθοδο [setTrimFromStart](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** η τιμή ισούται με τη διάρκεια του ήχου μείον την τιμή της μεθόδου [setTrimFromEnd](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setTrimFromEnd)

Ο **Volume control** του PowerPoint στον πίνακα ελέγχου ήχου αντιστοιχεί στη μέθοδο [setVolumeValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setVolumeValue). Σας επιτρέπει να αλλάξετε την ένταση του ήχου ως ποσοστό.

Αυτή είναι η διαδικασία για την αλλαγή των επιλογών αναπαραγωγής ήχου:

1. [Δημιουργήστε](#create-audio-frames) ή αποκτήστε το Audio Frame.
2. Ορίστε νέες τιμές για τις ιδιότητες του Audio Frame που χρειάζεστε να προσαρμόσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

Αυτός ο κώδικας Python δείχνει μια λειτουργία στην οποία προσαρμόζονται οι επιλογές ενός ήχου:

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
        # Αναπαραγωγή με κλικ σε χαμηλή ένταση, σε όλες τις διαφάνειες, χωρίς βρόχο.
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

Αυτό το παράδειγμα Python δείχνει πώς να προσθέσετε ένα νέο πλαίσιο ήχου με ενσωματωμένο ήχο, να το κόψετε και να ορίσετε τις διάρκειες εξασθένισης:

```python
from pathlib import Path

import jpage
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

    # Κόψτε 1.5 δευτερόλεπτα από την αρχή και 2 δευτερόλεπτα από το τέλος.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Ορίστε το fade‑in στα 200 ms και το fade‑out στα 500 ms.
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

## **Διαχείριση Υπότιτλων Ήχου**

Το Aspose.Slides σάς επιτρέπει να προσθέσετε κλειστούς υπότιτλους σε ένα πλαίσιο ήχου μέσω της μεθόδου [getCaptionTracks](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#getCaptionTracks). Αυτή η μέθοδος επιστρέφει ένα [CaptionsCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/), που σας επιτρέπει να προσθέτετε διαδρομές υποτίτλων WebVTT, να επαναλαμβάνετε τις υπάρχουσες διαδρομές και να τις αφαιρείτε όταν χρειάζεται.

**Προσθήκη Υπότιτλων Ήχου**

Χρησιμοποιήστε τη μέθοδο [getCaptionTracks](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#getCaptionTracks) για να συνδέσετε μία ή περισσότερες διαδρομές υποτίτλων σε ένα πλαίσιο ήχου. Στο παρακάτω παράδειγμα, ένα αρχείο ήχου προστίθεται σε μια διαφάνεια, και έπειτα μια νέα διαδρομή υπότιτλου φορτώνεται από ένα αρχείο `.vtt`.

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

    # Προσθέστε ένα νέο κομμάτι υποτίτλων από αρχείο WebVTT.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Εξαγωγή Υπότιτλων Ήχου**

Μπορείτε να επαναλάβετε τις διαδρομές υποτίτλων που σχετίζονται με ένα πλαίσιο ήχου και να τις αποθηκεύσετε ως αρχεία `.vtt`. Κάθε διαδρομή υπότιτλου εκθέτει τα δυαδικά της δεδομένα και το μοναδικό της αναγνωριστικό, που μπορούν να χρησιμοποιηθούν κατά την εξαγωγή των υποτίτλων.

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
                # Αποθηκεύστε το κομμάτι υποτίτλου ως αρχείο .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Αφαίρεση Υπότιτλων Ήχου**

Για να αφαιρέσετε τους υπότιτλους από ένα πλαίσιο ήχου, χρησιμοποιήστε τις μεθόδους του [CaptionsCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/), όπως [clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#removeAt). Το παρακάτω παράδειγμα αφαιρεί όλες τις διαδρομές υποτίτλων από ένα πλαίσιο ήχου.

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

Το Aspose.Slides for Python via Java σάς επιτρέπει να εξάγετε τον ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης. Για παράδειγμα, μπορείτε να εξαγάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Αποκτήστε την αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσπελάστε τις [slideshow transitions](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας.
4. Εξάγετε τον ήχο ως δεδομένα byte.

Αυτός ο κώδικας Python δείχνει πώς να εξάγετε τον ήχο που χρησιμοποιείται σε μια διαφάνεια:

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

## **Συχνές ερωτήσεις**

**Μπορώ να επαναχρησιμοποιήσω το ίδιο αρχείο ήχου σε πολλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη κοινόχρηστη [audio collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAudios) της παρουσίασης και δημιουργήστε επιπλέον πλαίσια ήχου που αναφέρονται σε αυτό το υπάρχον στοιχείο. Αυτό αποτρέπει την αντιγραφή των δεδομένων πολυμέσων και διατηρεί το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου χωρίς να δημιουργήσω ξανά το σχήμα;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε τη [link path](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setLinkPathLong) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο [embedded audio](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/#setEmbeddedAudio) με ένα άλλο από τη [audio collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAudios) της παρουσίασης. Η μορφοποίηση του πλαισίου και οι περισσότερες ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Η κοπή αλλάζει τα υποκείμενα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Η κοπή ρυθμίζει μόνο τα όρια αναπαραγωγής. Τα αρχικά bytes του ήχου παραμένουν ανεπηρέαστα και μπορούν να προσπελαστούν μέσω του ενσωματωμένου ήχου ή της [audio collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAudios) της παρουσίασης.