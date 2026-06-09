---
title: Υπερσύνδεσμος
type: docs
weight: 130
url: /el/python-net/examples/elements/hyperlink/
keywords:
- υπερσύνδεσμος
- προσθήκη υπερσυνδέσμου
- πρόσβαση σε υπερσύνδεσμο
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Προσθήκη, επεξεργασία και κατάργηση υπερσυνδέσμων σε Python με Aspose.Slides: κείμενο συνδέσμου, σχήματα, διαφάνειες, URLs και email; ορίζετε προορισμούς και ενέργειες για PPT, PPTX και ODP."
---
Εμφανίζει την προσθήκη, την πρόσβαση, την κατάργηση και την ενημέρωση υπερσυνδέσμων σε σχήματα χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη υπερσυνδέσμου**

Δημιουργήστε ένα σχήμα ορθογωνίου με έναν υπερσύνδεσμο που οδηγεί σε εξωτερικό ιστότοπο.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε υπερσύνδεσμο**

Διαβάστε τις πληροφορίες του υπερσυνδέσμου από το τμήμα κειμένου ενός σχήματος.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Αφαίρεση υπερσυνδέσμου**

Καθαρίστε τον υπερσύνδεσμο από το κείμενο του σχήματος.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενημέρωση υπερσυνδέσμου**

Αλλάξτε τον προορισμό ενός υπάρχοντος υπερσυνδέσμου. Χρησιμοποιήστε `HyperlinkManager` για να τροποποιήσετε κείμενο που περιέχει ήδη υπερσύνδεσμο, προσομοιώνοντας τον ασφαλή τρόπο που το PowerPoint ενημερώνει τους υπερσυνδέσμους.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Η αλλαγή ενός υπερσυνδέσμου μέσα σε υπάρχον κείμενο πρέπει να γίνεται μέσω
        # HyperlinkManager αντί για την άμεση ρύθμιση της ιδιότητας.
        # Αυτό μιμείται τον τρόπο με τον οποίο το PowerPoint ενημερώνει με ασφάλεια τους υπερσυνδέσμους.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```