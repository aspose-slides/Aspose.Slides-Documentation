---
title: Ήχος
type: docs
weight: 70
url: /el/python-java/examples/elements/audio/
keywords:
- παράδειγμα κώδικα
- ήχος
- πλαίσιο ήχου
- προσθήκη ήχου
- πρόσβαση ήχου
- αφαίρεση ήχου
- αναπαραγωγή ήχου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για Python μέσω Java για να προσθέσετε, να αποκτήσετε πρόσβαση, να αφαιρέσετε και να διαμορφώσετε πλαίσια ήχου σε παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο επιδεικνύει πώς να ενσωματώσετε πλαίσια ήχου και να ελέγχετε την αναπαραγωγή χρησιμοποιώντας **Aspose.Slides for Python via Java**. Τα παρακάτω παραδείγματα δείχνουν βασικές λειτουργίες ήχου.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν εκκινήσει η JVM, και στη συνέχεια εισάγει το API αφού η JVM είναι σε λειτουργία.

## **Προσθήκη Πλαισίου Ήχου**

Εισάγετε ένα κενό πλαίσιο ήχου που μπορεί αργότερα να φιλοξενήσει ενσωματωμένα δεδομένα ήχου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # Δημιουργήστε ένα κενό πλαίσιο ήχου (ο ήχος θα ενσωματωθεί αργότερα).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Πλαίσιο Ήχου**

Αυτός ο κώδικας ανακτά το πρώτο πλαίσιο ήχου σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Πρόσβαση στο πρώτο πλαίσιο ήχου στη διαφάνεια.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **Αφαίρεση Πλαισίου Ήχου**

Διαγράψτε ένα πλαίσιο ήχου που είχε προστεθεί προηγουμένως.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Αφαιρέστε το πλαίσιο ήχου.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Ορισμός Αναπαραγωγής Ήχου**

Ρυθμίστε το πλαίσιο ήχου να αναπαράγεται αυτόματα όταν εμφανιστεί η διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Αναπαραγωγή αυτόματα όταν εμφανιστεί η διαφάνεια.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```