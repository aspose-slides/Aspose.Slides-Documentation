---
title: Ήχος
type: docs
weight: 70
url: /el/python-net/examples/elements/audio/
keywords:
- ήχος
- πλαίσιο ήχου
- προσθήκη ήχου
- πρόσβαση ήχου
- αφαίρεση ήχου
- αναπαραγωγή ήχου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εργαστείτε με ήχο στην Python χρησιμοποιώντας Aspose.Slides: προσθέστε, αντικαταστήστε, εξάγετε και περικόψτε ήχους, ορίστε την ένταση και την αναπαραγωγή για διαφάνειες και σχήματα σε PowerPoint και OpenDocument."
---
Απεικονίζει πώς να ενσωματώσετε πλαίσια ήχου και να ελέγξετε την αναπαραγωγή με **Aspose.Slides for Python via .NET**. Τα ακόλουθα παραδείγματα δείχνουν βασικές λειτουργίες ήχου.

## **Προσθήκη πλαισίου ήχου**

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε πλαίσιο ήχου**

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **Αφαίρεση πλαισίου ήχου**

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτουμε ότι το πρώτο σχήμα είναι ένα AudioFrame.
        audio_frame = slide.shapes[0]

        # Αφαιρέστε το πλαίσιο ήχου.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ρύθμιση αναπαραγωγής ήχου**

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτουμε ότι το πρώτο σχήμα είναι ένα AudioFrame.
        audio_frame = slide.shapes[0]

        # Αναπαραγωγή αυτόματα όταν εμφανίζεται η διαφάνεια.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```