---
title: Λήψη ορίων παραγράφων από παρουσιάσεις σε Python
linktitle: Παράγραφος
type: docs
weight: 60
url: /el/python-net/paragraph/
keywords:
- όρια παραγράφου
- όρια τμήματος κειμένου
- συντεταγμένη παραγράφου
- συντεταγμένη τμήματος
- μέγεθος παραγράφου
- μέγεθος τμήματος κειμένου
- πλαίσιο κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφου και τμήματος κειμένου στο Aspose.Slides για Python μέσω .NET ώστε να βελτιστοποιήσετε την τοποθέτηση του κειμένου σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να γίνει λήψη των ορίων, του μεγέθους και των συντεταγμένων των παραγράφων και των τμημάτων κειμένου στο Aspose.Slides. Δείχνει πώς να ανακτήσετε το ορθογώνιο μιας παραγράφου σε ένα `TextFrame` χρησιμοποιώντας τη μέθοδο `get_rect()`, πώς να λάβετε τις συντεταγμένες παραγράφου και τμήματος μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση του αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel, και οι τιμές αποτελεσματικής μορφοποίησης παραγράφου.

## **Λήψη Συντεταγμένων Παραγράφου και Τμήματος σε TextFrame**
Χρησιμοποιώντας το Aspose.Slides for Python μέσω .NET, οι προγραμματιστές μπορούν τώρα να λάβουν τις ορθογώνιες συντεταγμένες για την Paragraph μέσα στη συλλογή παραγράφων του TextFrame. Επιτρέπει επίσης τη λήψη των συντεταγμένων ενός τμήματος μέσα στη συλλογή τμημάτων μιας παραγράφου. Σε αυτό το θέμα, θα δείξουμε με τη βοήθεια ενός παραδείγματος πώς να λάβετε τις ορθογώνιες συντεταγμένες για μια παράγραφο μαζί με τη θέση του τμήματος μέσα στην παράγραφο.

## **Λήψη Ορθογώνιων Συντεταγμένων της Παραγράφου**
Η νέα μέθοδος **GetRect()** προστέθηκε. Επιτρέπει την λήψη του ορθογωνίου ορίων της παραγράφου.

```py
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Λήψη μεγέθους παραγράφου και τμήματος μέσα σε πλαίσιο κειμένου κελιού πίνακα** ##

Για να λάβετε το μέγεθος και τις συντεταγμένες του [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) ή του [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) σε πλαίσιο κειμένου κελιού πίνακα, μπορείτε να χρησιμοποιήσετε τις μεθόδους [IPortion.GetRect](https://reference.aspose.com/slides/el/python-net/aspose.slides/iportion/) και [IParagraph.GetRect](https://reference.aspose.com/slides/el/python-net/aspose.slides/iparagraph/).

Αυτός ο κώδικας δείγματος επιδεικνύει τη περιγραφόμενη λειτουργία:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Σε ποιες μονάδες επιστρέφονται οι συντεταγμένες για μια παράγραφο και τμήματα κειμένου;**

Σε μονάδες σημείου (points), όπου 1 ίντσα = 72 points. Αυτό ισχύει για όλες τις συντεταγμένες και τις διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η [αναδίπλωση](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/wrap_text/) είναι ενεργοποιημένη στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/), το κείμενο χωρίζεται ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να αντιστοιχιστούν αξιόπιστα σε pixel στην εικόνα που εξάγεται;**

Ναι. Μετατρέψτε τα points σε pixel χρησιμοποιώντας: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση/εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης της παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα στυλ;**

Χρησιμοποιήστε τη [δομή δεδομένων αποτελεσματικής μορφοποίησης παραγράφου](/slides/el/python-net/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.