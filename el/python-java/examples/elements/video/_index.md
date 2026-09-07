---
title: Βίντεο
type: docs
weight: 80
url: /el/python-java/examples/elements/video/
keywords:
- παράδειγμα κώδικα
- βίντεο
- πλαίσιο βίντεο
- προσθήκη βίντεο
- πρόσβαση σε βίντεο
- αφαίρεση βίντεο
- αναπαραγωγή βίντεο
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για Python μέσω Java για να προσθέσετε, να έχετε πρόσβαση, να αφαιρέσετε και να διαμορφώσετε πλαίσια βίντεο σε παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε πλαίσια βίντεο και να ορίσετε επιλογές αναπαραγωγής χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, μετά εισάγει το API όταν η JVM εκτελείται.

## **Προσθήκη Πλαισίου Βίντεο**

Εισάγετε ένα πλαίσιο βίντεο που αναφέρεται σε εξωτερικό αρχείο βίντεο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθέστε ένα πλαίσιο βίντεο που συνδέεται με ένα αρχείο βίντεο.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Πλαίσιο Βίντεο**

Ανακτήστε το πρώτο πλαίσιο βίντεο που προστέθηκε σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Πρόσβαση στο πρώτο πλαίσιο βίντεο στη διαφάνεια.
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **Αφαίρεση Πλαισίου Βίντεο**

Διαγράψτε ένα πλαίσιο βίντεο από τη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Αφαιρέστε το πλαίσιο βίντεο.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Ορισμός Αναπαραγωγής Βίντεο**

Ρυθμίστε το βίντεο να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Διαμορφώστε το βίντεο ώστε να αναπαράγεται αυτόματα.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```