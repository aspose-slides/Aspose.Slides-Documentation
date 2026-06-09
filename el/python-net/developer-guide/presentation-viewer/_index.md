---
title: Δημιουργία προβολέα παρουσίασης με Python
linktitle: Προβολέας Παρουσίασης
type: docs
weight: 50
url: /el/python-net/presentation-viewer/
keywords: 
- προβολή παρουσίασης
- προβολέας παρουσίασης
- δημιουργία προβολέα παρουσίασης
- προβολή PPT
- προβολή PPTX
- προβολή ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργήσετε έναν προσαρμοσμένο προβολέα παρουσίασης σε Python χρησιμοποιώντας το Aspose.Slides. Εύκολα εμφανίστε αρχεία PowerPoint (PPTX, PPT) και OpenDocument (ODP) χωρίς το Microsoft PowerPoint ή άλλο λογισμικό γραφείου."
---
## **Εισαγωγή**

Το Aspose.Slides για Python χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης με διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τις παρουσιάσεις στο Microsoft PowerPoint, για παράδειγμα. Ωστόσο, οι προγραμματιστές ενδέχεται μερικές φορές να χρειάζονται να προβάλλουν τις διαφάνειες ως εικόνες στον προτιμώμενο προβολέα εικόνων ή να τις χρησιμοποιήσουν σε έναν προσαρμοσμένο προβολέα παρουσιάσεων. Σε τέτοιες περιπτώσεις, το Aspose.Slides σας επιτρέπει να εξάγετε μεμονωμένες διαφάνειες ως εικόνες. Αυτό το άρθρο εξηγεί πώς να το κάνετε.

## **Δημιουργία εικόνας SVG από μια διαφάνεια**

Για να δημιουργήσετε μια εικόνα SVG από μια διαφάνεια παρουσίασης με το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.
3. Ανοίξτε μια ροή αρχείου.
4. Αποθηκεύστε τη διαφάνεια ως εικόνα SVG στη ροή αρχείου.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Δημιουργία μικρογραφίας διαφάνειας**

Το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες εικόνων διαφανειών. Για να δημιουργήσετε μια μικρογραφία μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.
3. Δημιουργήστε μια εικόνα μικρογραφίας της αναφερόμενης διαφάνειας στην επιθυμητή κλίμακα.
4. Αποθηκεύστε την εικόνα μικρογραφίας στη μορφή εικόνας που προτιμάτε.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Δημιουργία μικρογραφίας διαφάνειας με διαστάσεις ορισμένες από το χρήστη**

Για να δημιουργήσετε μια εικόνα μικρογραφίας διαφάνειας με διαστάσεις που ορίζονται από το χρήστη, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.
3. Δημιουργήστε μια εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τις καθορισμένες διαστάσεις.
4. Αποθηκεύστε την εικόνα μικρογραφίας στη μορφή εικόνας που προτιμάτε.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Δημιουργία μικρογραφίας διαφάνειας με σημειώσεις ομιλητή**

Για να δημιουργήσετε μια μικρογραφία μιας διαφάνειας με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [RenderingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/) .
2. Χρησιμοποιήστε την ιδιότητα `RenderingOptions.slides_layout_options` για να ορίσετε τη θέση των σημειώσεων ομιλητή.
3. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
4. Αποκτήστε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.
5. Δημιουργήστε μια εικόνα μικρογραφίας της αναφερόμενης διαφάνειας χρησιμοποιώντας τις επιλογές απόδοσης.
6. Αποθηκεύστε την εικόνα μικρογραφίας στη μορφή εικόνας που προτιμάτε.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την δωρεάν εφαρμογή [**Aspose.Slides Viewer**](https://products.aspose.app/slides/el/viewer/) για να δείτε τι μπορείτε να υλοποιήσετε με το API του Aspose.Slides:

[![Online Προβολέας PowerPoint](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/el/viewer/)

## **Συχνές Ερωτήσεις**

**Μπορώ να ενσωματώσω έναν προβολέα παρουσιάσεων σε εφαρμογή web ASP.NET;**

Ναι. Μπορείτε να χρησιμοποιήσετε το Aspose.Slides στην πλευρά του διακομιστή για να αποδίδετε τις διαφάνειες ως [εικόνες](/slides/el/python-net/convert-powerpoint-to-png/) ή [HTML](/slides/el/python-net/convert-powerpoint-to-html/) και να τις εμφανίζετε στον περιηγητή. Οι λειτουργίες πλοήγησης και ζουμ μπορούν να υλοποιηθούν με JavaScript για μια διαδραστική εμπειρία.

**Ποιος είναι ο καλύτερος τρόπος για να εμφανίσετε διαφάνειες μέσα σε έναν προσαρμοσμένο προβολέα .NET;**

Η προτεινόμενη προσέγγιση είναι να αποδίδετε κάθε διαφάνεια ως [εικόνα](/slides/el/python-net/convert-powerpoint-to-png/) (π.χ., PNG ή SVG) ή να τη μετατρέψετε σε [HTML](/slides/el/python-net/convert-powerpoint-to-html/) χρησιμοποιώντας το Aspose.Slides, και κατόπιν να εμφανίσετε το αποτέλεσμα μέσα σε ένα picture box (για desktop) ή σε ένα HTML container (για web).

**Πώς να διαχειριστώ μεγάλες παρουσιάσεις με πολλές διαφάνειες;**

Για μεγάλες παρουσιάσεις, εξετάστε τη φορτωση «lazy-loading» ή την απόδοση κατά απαίτηση των διαφανειών. Αυτό σημαίνει τη δημιουργία του περιεχομένου μιας διαφάνειας μόνο όταν ο χρήστης πλοηγηθεί σε αυτήν, μειώνοντας τη μνήμη και τον χρόνο φόρτωσης.