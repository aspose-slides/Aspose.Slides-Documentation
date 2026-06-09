---
title: Εικόνα
type: docs
weight: 50
url: /el/python-net/examples/elements/picture/
keywords:
- εικόνα
- πλαίσιο εικόνας
- προσθήκη εικόνας
- πρόσβαση σε εικόνα
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εργασία με εικόνες σε Python χρησιμοποιώντας Aspose.Slides: εισαγωγή, αντικατάσταση, περικοπή, συμπίεση, προσαρμογή διαφάνειας και εφέ, γέμισμα σχημάτων, και εξαγωγή για PPT, PPTX και ODP."
---
Δείχνει πώς να εισάγετε και να προσπελάσετε εικόνες από εικόνες στη μνήμη χρησιμοποιώντας **Aspose.Slides for Python via .NET**. Τα παραδείγματα παρακάτω δημιουργούν μια εικόνα στη μνήμη, την τοποθετούν σε μια διαφάνεια και στη συνέχεια την ανακτούν.

## **Προσθήκη Εικόνας**

Αυτός ο κώδικας φορτώνει μια εικόνα από αρχείο και την εισάγει ως πλαίσιο εικόνας στην πρώτη διαφάνεια.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Φορτώνει μια εικόνα από αρχείο.
        with open("image.png", "rb") as image_stream:
            # Προσθέτει την εικόνα στους πόρους της παρουσίασης.
            image = presentation.images.add_image(image_stream)

        # Εισάγει ένα πλαίσιο εικόνας που εμφανίζει την εικόνα στην πρώτη διαφάνεια.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Εικόνα**

Αυτό το παράδειγμα εξασφαλίζει ότι μια διαφάνεια περιέχει ένα πλαίσιο εικόνας και στη συνέχεια προσπελαύνει το πρώτο που βρέθηκε.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στο πρώτο πλαίσιο εικόνας στη διαφάνεια.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```