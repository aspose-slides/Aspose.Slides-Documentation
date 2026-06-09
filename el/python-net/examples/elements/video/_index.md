---
title: Βίντεο
type: docs
weight: 80
url: /el/python-net/examples/elements/video/
keywords:
- βίντεο
- πλαίσιο βίντεο
- προσθήκη βίντεο
- πρόσβαση βίντεο
- αφαίρεση βίντεο
- αναπαραγωγή βίντεο
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εργασία με βίντεο σε Python χρησιμοποιώντας Aspose.Slides: εισαγωγή, αντικατάσταση, περικοπή, ορισμός πλαισίων αφίσας και επιλογών αναπαραγωγής, καθώς και εξαγωγή παρουσιάσεων για PPT, PPTX και ODP."
---
Δείχνει πώς να ενσωματώσετε πλαίσια βίντεο και να ορίσετε επιλογές αναπαραγωγής χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη Πλαισίου Βίντεο**

Εισάγετε ένα κενό πλαίσιο βίντεο σε μια διαφάνεια.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Προσθήκη πλαισίου βίντεο.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Πλαίσιο Βίντεο**

Ανακτήστε το πρώτο πλαίσιο βίντεο που προστέθηκε σε μια διαφάνεια.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στο πρώτο πλαίσιο βίντεο στη διαφάνεια.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Αφαίρεση Πλαισίου Βίντεο**

Διαγράψτε ένα πλαίσιο βίντεο από τη διαφάνεια.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι πλαίσιο βίντεο.
        video_frame = slide.shapes[0]

        # Αφαίρεση του πλαισίου βίντεο.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Αναπαραγωγής Βίντεο**

Ρυθμίστε το βίντεο να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι πλαίσιο βίντεο.
        video_frame = slide.shapes[0]

        # Ρύθμιση του βίντεο ώστε να αναπαράγεται αυτόματα.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```