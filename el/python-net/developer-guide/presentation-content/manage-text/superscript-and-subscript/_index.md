---
title: Διαχείριση Επάνω και Κάτω Δείκτη σε Python
linktitle: Επάνω και Κάτω Δείκτης
type: docs
weight: 80
url: /el/python-net/superscript-and-subscript/
keywords:
- επάνω δείκτης
- κάτω δείκτης
- προσθήκη επάνω δείκτη
- προσθήκη κάτω δείκτη
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Αποκτήστε απόλυτο έλεγχο των επάνω και κάτω δείκτη στο Aspose.Slides για Python μέσω .NET και αναβαθμίστε τις παρουσιάσεις σας με επαγγελματική μορφοποίηση κειμένου για μέγιστο αντίκτυπο."
---
## **Επισκόπηση**

Η Aspose.Slides παρέχει δυνατότητες ενσωμάτωσης κειμένου με επάνω και κάτω δείκτη στις παρουσιάσεις PowerPoint (PPT, PPTX) και OpenDocument (ODP). Εάν χρειάζεστε να επισημάνετε χημικούς τύπους, μαθηματικές εξισώσεις ή να προσθέσετε υποσημειώσεις, αυτές οι εξειδικευμένες επιλογές μορφοποίησης βοηθούν στη διατήρηση της σαφήνειας και της ακρίβειας. Σε αυτό το άρθρο, θα μάθετε πώς να εφαρμόζετε ομαλά τα στυλ επάνω και κάτω δείκτη και να εξασφαλίζετε επαγγελματικά αποτελέσματα σε κάθε διαφάνεια.

## **Προσθήκη Κειμένου με Επάνω και Κάτω Δείκτη**

Μπορείτε να προσθέσετε κείμενο με επάνω ή κάτω δείκτη σε οποιοδήποτε τμήμα παραγράφου. Στην Aspose.Slides, χρησιμοποιήστε την ιδιότητα `escapement` της κλάσης [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/) για να το ελέγξετε.

`escapement` είναι ένα ποσοστό από **-100% έως 100%**:

- **> 0** → επάνω δείκτη (π.χ., 25% = ελαφρώς πιο ψηλό; 100% = πλήρης επάνω δείκτης)
- **0** → βασική γραμμή (χωρίς επάνω/κάτω δείκτη)
- **< 0** → κάτω δείκτη (π.χ., -25% = ελαφρώς πιο χαμηλό; -100% = πλήρης κάτω δείκτης)

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και πάρτε μια διαφάνεια.
1. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) και προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Καθαρίστε τις υπάρχουσες παραγράφους.
1. Για επάνω δείκτη: δημιουργήστε μια παράγραφο και ένα τμήμα, ορίστε `portion.portion_format.escapement` σε τιμή μεταξύ **0 και 100**, ορίστε το κείμενο και προσθέστε το τμήμα.
1. Για κάτω δείκτη: δημιουργήστε μια άλλη παράγραφο και τμήμα, ορίστε `escapement` σε τιμή μεταξύ **-100 και 0**, ορίστε το κείμενο και προσθέστε το τμήμα.
1. Αποθηκεύστε την παρουσίαση ως PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Λάβετε μια διαφάνεια.
    slide = presentation.slides[0]

    # Δημιουργήστε ένα πλαίσιο κειμένου.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Δημιουργήστε μια παράγραφο για κείμενο με επάνω δείκτη.
    superscript_paragraph = slides.Paragraph()

    # Δημιουργήστε ένα τμήμα κειμένου με κανονικό κείμενο.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Δημιουργήστε ένα τμήμα κειμένου με επάνω δείκτη.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Δημιουργήστε μια παράγραφο για κείμενο με κάτω δείκτη.
    subscript_paragraph = slides.Paragraph()

    # Δημιουργήστε ένα τμήμα κειμένου με κανονικό κείμενο.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Δημιουργήστε ένα τμήμα κειμένου με κάτω δείκτη.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω επάνω/κάτω δείκτη σε πίνακες και άλλα containers, όχι μόνο σε κανονικά πλαίσια κειμένου;**

Ναι. Μπορείτε να μορφοποιήσετε κείμενο ως επάνω ή κάτω δείκτη μέσα σε οποιοδήποτε αντικείμενο που εκθέτει ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) (συμπεριλαμβανομένων των κελιών πίνακα). Η μορφοποίηση εφαρμόζεται στα τμήματα κειμένου μέσα σε αυτό το πλαίσιο.

**Θα διατηρηθούν οι επάνω/κάτω δείκτες κατά την εξαγωγή σε PDF, HTML ή εικόνες;**

Ναι. Η Aspose.Slides διατηρεί τη μορφοποίηση επάνω/κάτω δείκτη κατά την εξαγωγή σε κοινές μορφές όπως [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/el/python-net/convert-powerpoint-to-html/), και [raster images](/slides/el/python-net/convert-powerpoint-to-png/) επειδή η διαδρομή απόδοσης σέβεται τη μορφοποίηση κειμένου επιπέδου τμήματος.

**Μπορώ να συνδυάσω επάνω/κάτω δείκτη με υπερσυνδέσμους στο ίδιο τμήμα κειμένου;**

Ναι. Τα [Hyperlinks](/slides/el/python-net/manage-hyperlinks/) εκχωρούνται σε επίπεδο τμήματος (fragment), έτσι ένα τμήμα μπορεί ταυτόχρονα να έχει υπερσύνδεσμο και να μορφοποιείται ως επάνω ή κάτω δείκτης.