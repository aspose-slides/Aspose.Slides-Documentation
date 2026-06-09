---
title: Ομαδικό σχήμα
type: docs
weight: 170
url: /el/python-net/examples/elements/group-shape/
keywords:
- ομάδα
- προσθήκη ομαδικού σχήματος
- πρόσβαση σε ομαδικό σχήμα
- αφαίρεση ομαδικού σχήματος
- αποομαδοποίηση σχημάτων
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εργασία με ομαδικά σχήματα σε Python χρησιμοποιώντας Aspose.Slides: δημιουργία και αποομαδοποίηση, επαναδιάταξη παιδικών σχημάτων, ορισμός μετασχηματισμών και ορίων σε PowerPoint και OpenDocument."
---
Παραδείγματα δημιουργίας ομάδων σχημάτων, πρόσβασης σε αυτά, αποομαδοποίησης και αφαίρεσης χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη ομαδικού σχήματος**

Δημιουργήστε μια ομάδα που περιέχει δύο βασικά σχήματα.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Προσθήκη ομαδικού σχήματος.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε ομαδικό σχήμα**

Ανακτήστε το πρώτο ομαδικό σχήμα από μια διαφάνεια.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στο πρώτο ομαδικό σχήμα στη διαφάνεια.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Αφαίρεση ομαδικού σχήματος**

Διαγράψτε ένα ομαδικό σχήμα από τη διαφάνεια.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Θεωρώντας ότι το πρώτο σχήμα είναι ένα ομαδικό σχήμα.
        group = slide.shapes[0]

        # Αφαίρεση του ομαδικού σχήματος.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Αποομαδοποίηση σχημάτων**

Μετακινήστε τα σχήματα εκτός του ομαδικού περιέκτη.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Θεωρώντας ότι το πρώτο σχήμα είναι ένα ομαδικό σχήμα.
        group = slide.shapes[0]

        # Μετακίνηση των σχημάτων εκτός της ομάδας.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```