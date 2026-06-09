---
title: SmartArt
type: docs
weight: 140
url: /el/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- προσθήκη SmartArt
- πρόσβαση SmartArt
- αφαίρεση SmartArt
- διάταξη SmartArt
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και επεξεργαστείτε SmartArt σε Python με Aspose.Slides: προσθέστε κόμβους, αλλάξτε διατάξεις και στυλ, μετατρέψτε σε σχήματα με ακρίβεια, και εξαγάγετε για PPT, PPTX και ODP."
---
Δείχνει πώς να προσθέσετε γραφικά SmartArt, να τα προσπελάσετε, να τα αφαιρέσετε και να αλλάξετε τις διατάξεις χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη SmartArt**

Εισάγετε ένα γραφικό SmartArt χρησιμοποιώντας μία από τις ενσωματωμένες διατάξεις.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση SmartArt**

Ανακτήστε το πρώτο αντικείμενο SmartArt σε μια διαφάνεια.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στο πρώτο σχήμα SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Αφαίρεση SmartArt**

Διαγράψτε ένα σχήμα SmartArt από τη διαφάνεια.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι αντικείμενο SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή Διάταξης SmartArt**

Ενημερώστε τον τύπο διάταξης ενός υπάρχοντος γραφικού SmartArt.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι αντικείμενο SmartArt.
        smart_art = slide.shapes[0]

        # Αλλαγή της διάταξης SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```