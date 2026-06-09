---
title: Μετάβαση Διαφάνειας
type: docs
weight: 110
url: /el/python-net/examples/elements/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- πρόσβαση στη μετάβαση διαφάνειας
- αφαίρεση μετάβασης διαφάνειας
- διάρκεια μετάβασης
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τις μεταβάσεις διαφάνειας σε Python με Aspose.Slides: επιλέξτε τύπους, ταχύτητα, ήχο και χρονοδιάγραμμα για να τελειοποιήσετε τις παρουσιάσεις σε PPT, PPTX και ODP."
---
Δείχνει πώς να εφαρμόζετε εφέ μετάβασης διαφάνειας και χρονικά διαστήματα με **Aspose.Slides for Python via .NET**.

## **Προσθήκη Μετάβασης Διαφάνειας**

Εφαρμόστε ένα εφέ μετάβασης εξασθένισης στην πρώτη διαφάνεια.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Εφαρμόστε μια μετάβαση εξασθένισης.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Μετάβαση Διαφάνειας**

Διαβάστε τον τύπο μετάβασης που έχει εκχωρηθεί αυτή τη στιγμή σε μια διαφάνεια.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Προσπελάστε τον τύπο μετάβασης.
        transition_type = slide.slide_show_transition.type
```

## **Αφαίρεση Μετάβασης Διαφάνειας**

Καθαρίστε τυχόν εφέ μετάβασης ορίζοντας τον τύπο σε `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Αφαιρέστε τη μετάβαση ορίζοντας none.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Διάρκειας Μετάβασης**

Καθορίστε πόσο καιρό εμφανίζεται η διαφάνεια πριν προχωρήσει αυτόματα.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # σε χιλιοστά του δευτερολέπτου.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```