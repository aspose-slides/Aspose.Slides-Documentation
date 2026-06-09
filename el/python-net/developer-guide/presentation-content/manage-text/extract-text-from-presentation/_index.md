---
title: Προηγμένη εξαγωγή κειμένου από παρουσιάσεις σε Python
linktitle: Εξαγωγή κειμένου
type: docs
weight: 90
url: /el/python-net/extract-text-from-presentation/
keywords:
- εξαγωγή κειμένου
- εξαγωγή κειμένου από διαφάνεια
- εξαγωγή κειμένου από παρουσίαση
- εξαγωγή κειμένου από PowerPoint
- εξαγωγή κειμένου από OpenDocument
- εξαγωγή κειμένου από PPT
- εξαγωγή κειμένου από PPTX
- εξαγωγή κειμένου από ODP
- ανάκτηση κειμένου
- ανάκτηση κειμένου από διαφάνεια
- ανάκτηση κειμένου από παρουσίαση
- ανάκτηση κειμένου από PowerPoint
- ανάκτηση κειμένου από OpenDocument
- ανάκτηση κειμένου από PPT
- ανάκτηση κειμένου από PPTX
- ανάκτηση κειμένου από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εξαγάγετε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Ακολουθήστε τον απλό, βήμα-βήμα οδηγό μας για να εξοικονομήσετε χρόνο."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια κοινή αλλά απαραίτητη εργασία για προγραμματιστές που εργάζονται με περιεχόμενο διαφανειών. Είτε διαχειρίζεστε αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε παρουσιάσεις OpenDocument (ODP), η πρόσβαση και ανάκτηση των κειμενικών δεδομένων μπορεί να είναι κρίσιμη για ανάλυση, αυτοματοποίηση, ευρετηρίαση ή μεταφορά περιεχομένου.

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να εξάγετε αποδοτικά κείμενο από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for Python via .NET. Θα μάθετε πώς να διατρέχετε συστηματικά τα στοιχεία μιας παρουσίασης για να ανακτήσετε με ακρίβεια το κείμενο που χρειάζεστε.

## **Εξαγωγή κειμένου από μια διαφάνεια**

Το Aspose.Slides for Python via .NET παρέχει το χώρο ονομάτων [aspose.slides.util](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/), που περιλαμβάνει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/). Αυτή η κλάση εκθέτει αρκετές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για να εξάγετε κείμενο από μια διαφάνεια σε μια παρουσίαση, χρησιμοποιήστε τη μέθοδο [get_all_text_boxes](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Η μέθοδος αυτή δέχεται ένα αντικείμενο τύπου [BaseSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/) ως παράμετρο. Κατά την εκτέλεση, η μέθοδος σαρώσει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων τύπου [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/), διατηρώντας οποιαδήποτε μορφοποίηση κειμένου.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Εξαγωγή κειμένου από μια παρουσίαση**

Για να σαρώσετε το κείμενο σε ολόκληρη την παρουσίαση, χρησιμοποιήστε τη στατική μέθοδο [get_all_text_frames](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/get_all_text_frames/) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/). Δέχεται δύο παραμέτρους:

1. Πρώτον, ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.
1. Δεύτερον, μια τιμή `Boolean` που υποδεικνύει αν οι κύριες διαφάνειες (master slides) πρέπει να συμπεριληφθούν κατά τη σάρωση του κειμένου από την παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων τύπου [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/), περιλαμβάνοντας πληροφορίες μορφοποίησης κειμένου. Ο παρακάτω κώδικας σαρώει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των κύριων διαφανειών.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Κατηγοριοποιημένη και γρήγορη εξαγωγή κειμένου**

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

Το όρισμα enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/python-net/aspose.slides/textextractionarrangingmode/) υποδεικνύει τη λειτουργία οργάνωσης του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις ακόλουθες τιμές:
- `UNARRANGED` - Το ακατέργαστο κείμενο χωρίς να λαμβάνεται υπόψη η θέση του στη διαφάνεια.
- `ARRANGED` - Το κείμενο οργανώνεται με την ίδια σειρά όπως στη διαφάνεια.

`UNARRANGED` μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι ταχύτερη από τη λειτουργία `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationtext/) αντιπροσωπεύει το ακατέργαστο κείμενο που εξήχθη από την παρουσίαση. Η ιδιότητα `slides_text` επιστρέφει έναν πίνακα αντικειμένων κειμένου διαφάνειας. Κάθε αντικείμενο αντιπροσωπεύει το κείμενο στην αντίστοιχη διαφάνεια και έχει τις ακόλουθες ιδιότητες:

- `text` - Το κείμενο εντός των σχημάτων της διαφάνειας.
- `master_text` - Το κείμενο εντός των σχημάτων της κύριας διαφάνειας (master slide) που σχετίζεται με αυτή τη διαφάνεια.
- `layout_text` - Το κείμενο εντός των σχημάτων της διαφάνειας διάταξης (layout slide) που σχετίζεται με αυτή τη διαφάνεια.
- `notes_text` - Το κείμενο εντός των σχημάτων της διαφάνειας σημειώσεων (notes slide) που σχετίζεται με αυτή τη διαφάνεια.
- `comments_text` - Το κείμενο εντός των σχολίων που σχετίζονται με αυτή τη διαφάνεια.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **Συχνές ερωτήσεις**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides είναι βελτιστοποιημένο για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [μεγάλες παρουσιάσεις](/slides/el/python-net/open-presentation/), καθιστώντας το κατάλληλο για σενάρια επεξεργασίας σε πραγματικό χρόνο ή μαζικής επεξεργασίας.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και διαγράμματα μέσα σε παρουσιάσεις;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία διαφανειών, συμπεριλαμβανομένων πινάκων και αντικειμένων σχετικών με διαγράμματα, ώστε να μπορείτε να προσπελάσετε και να αναλύσετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσίασης.

**Χρειάζομαι ειδική άδεια Aspose.Slides για να εξάγω κείμενο από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν δοκιμαστική έκδοση του Aspose.Slides, αν και αυτή έχει [ορισμένους περιορισμούς](/slides/el/python-net/licensing/), όπως η επεξεργασία μόνο περιορισμένου αριθμού διαφανειών. Για απεριόριστη χρήση και για την επεξεργασία μεγαλύτερων παρουσιάσεων, συνιστάται η αγορά πλήρους άδειας.