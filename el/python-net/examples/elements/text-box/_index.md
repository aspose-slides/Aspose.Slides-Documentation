---
title: Πλαίσιο Κειμένου
type: docs
weight: 40
url: /el/python-net/examples/elements/text-box/
keywords:
- πλαίσιο κειμένου
- προσθήκη πλαισίου κειμένου
- πρόσβαση σε πλαίσιο κειμένου
- αφαίρεση πλαισίου κειμένου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε πλαίσια κειμένου σε Python με Aspose.Slides: ορίστε γραμματοσειρές, στοίχιση, αναδίπλωση, αυτόματη προσαρμογή και συνδέσμους για βελτιωμένες διαφάνειες σε PowerPoint και OpenDocument."
---
Στο Aspose.Slides, ένα **πλαίσιο κειμένου** αντιπροσωπεύεται από ένα `AutoShape`. Σχεδόν οποιοδήποτε σχήμα μπορεί να περιέχει κείμενο, αλλά ένα τυπικό πλαίσιο κειμένου δεν έχει γέμισμα ή περίγραμμα και εμφανίζει μόνο το κείμενο.

Αυτός ο οδηγός εξηγεί πώς να προσθέτετε, να αποκτάτε πρόσβαση και να αφαιρείτε πλαίσια κειμένου προγραμματιστικά.

## **Προσθήκη Πλαισίου Κειμένου**

Ένα πλαίσιο κειμένου είναι απλώς ένα `AutoShape` χωρίς γέμισμα ή περίγραμμα και με μορφοποιημένο κείμενο. Δείτε πώς να δημιουργήσετε ένα:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Δημιουργήστε ένα σχήμα ορθογωνίου (προεπιλογή: γεμάτο με περίγραμμα και χωρίς κείμενο).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Αφαιρέστε το γέμισμα και το περίγραμμα ώστε να μοιάζει με τυπικό πλαίσιο κειμένου.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Ορίστε τη μορφοποίηση του κειμένου.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Αναθέστε το πραγματικό περιεχόμενο κειμένου.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Σημείωση:** Οποιοδήποτε `AutoShape` που περιέχει ένα μη κενό `TextFrame` μπορεί να λειτουργήσει ως πλαίσιο κειμένου.

## **Πρόσβαση σε Πλαίσια Κειμένου ανά Περιεχόμενο**

Για να βρείτε όλα τα πλαίσια κειμένου που περιέχουν μια συγκεκριμένη λέξη-κλειδί (π.χ. "Slide"), επαναλάβετε τα σχήματα και ελέγξτε το κείμενό τους:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Μόνο τα AutoShapes μπορούν να περιέχουν επεξεργάσιμο κείμενο.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Κάντε κάτι με το αντίστοιχο πλαίσιο κειμένου.
                    pass
```

## **Αφαίρεση Πλαισίων Κειμένου ανά Περιεχόμενο**

Αυτό το παράδειγμα εντοπίζει και διαγράφει όλα τα πλαίσια κειμένου στη πρώτη διαφάνεια που περιέχουν μια συγκεκριμένη λέξη-κλειδί:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Βρείτε τα σχήματα προς αφαίρεση που είναι AutoShapes και περιέχουν τη λέξη "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Αφαιρέστε κάθε ταιριαστό σχήμα από τη διαφάνεια.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Συμβουλή:** Πάντα δημιουργείτε ένα αντίγραφο της συλλογής σχημάτων πριν το τροποποιήσετε κατά τη διάρκεια της επανάληψης για να αποφύγετε σφάλματα τροποποίησης της συλλογής.