---
title: Αποκτήστε τα όρια παραγράφων από παρουσιάσεις σε Python
linktitle: Όρια Παραγράφων
type: docs
weight: 43
url: /el/python-net/paragraph-bounds/
keywords:
- όρια παραγράφων
- συντεταγμένες παραγράφου
- μέγεθος παραγράφου
- πλαίσιο κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφων στο Aspose.Slides για Python μέσω .NET για να βελτιστοποιήσετε την τοποθέτηση κειμένου σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες των παραγράφων στο Aspose.Slides. Δείχνει πώς να ανακτήσετε το ορθογώνιο μιας παραγράφου από ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) χρησιμοποιώντας [Paragraph.get_rect](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/get_rect/), πώς να λάβετε τις συντεταγμένες της παραγράφου μέσα σε πλαίσιο κειμένου κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel και οι τιμές της «αποτελεσματικής» μορφοποίησης παραγράφου.

## **Λήψη ορθογώνιων συντεταγμένων μιας παραγράφου**

Χρησιμοποιήστε [Paragraph.get_rect](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/get_rect/) για να λάβετε το περικλειστήρθογώνιο μιας παραγράφου.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Λήψη του μεγέθους μιας παραγράφου μέσα σε TextFrame κελιού πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες ενός [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) σε πλαίσιο κειμένου κελιού πίνακα, χρησιμοποιήστε [Paragraph.get_rect](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/get_rect/). Το επιστρεφόμενο ορθογώνιο είναι σχετικό με το πλαίσιο κειμένου του κελιού πίνακα, επομένως προσθέστε τη θέση του πίνακα και την εκτροπή του κελιού όταν χρειάζεστε συντεταγμένες επίπεδου διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει τα όρια της παραγράφου μέσα σε κελί πίνακα και σχεδιάζει ορθογώνια στη διαφάνεια ώστε να οπτικοποιήσει αυτά τα όρια:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι συντεταγμένες της παραγράφου;**

Μετρώνται σε σημεία (points), όπου 1 ίντσα ισούται με 72 σημεία. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η ιδιότητα [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/wrap_text/) είναι ενεργοποιημένη για το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/), το κείμενο σπάει ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να αντιστοιχιστούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα σημεία σε pixel χρησιμοποιώντας τον τύπο: pixels = points x (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για τη απόδοση ή την εξαγωγή.

**Πώς μπορώ να λάβω τις “αποτελεσματικές” παραμέτρους μορφοποίησης της παραγράφου, λαμβάνοντας υπόψη την κληρονομιά στυλ;**

Χρησιμοποιήστε τη [effective paragraph formatting data structure](/slides/el/python-net/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για τις εσοχές, το διάστημα, την αναδίπλωση, RTL και άλλα.