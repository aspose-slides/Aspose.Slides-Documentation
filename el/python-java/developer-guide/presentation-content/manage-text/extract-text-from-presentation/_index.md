---
title: Προχωρημένη Εξαγωγή Κειμένου από Παρουσιάσεις σε Python μέσω Java
linktitle: Εξαγωγή Κειμένου
type: docs
weight: 90
url: /el/python-java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "Αποκτήστε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Ακολουθήστε τον απλό, βήμα-βήμα οδηγό μας για να εξοικονομήσετε χρόνο."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια συνηθισμένη αλλά ουσιώδης εργασία για προγραμματιστές που εργάζονται με περιεχόμενο διαφανειών. Είτε διαχειρίζεστε αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε παρουσιάσεις OpenDocument (ODP), η πρόσβαση και η ανάκτηση κειμενικών δεδομένων μπορεί να είναι κρίσιμη για ανάλυση, αυτοματοποίηση, ευρετηρίαση ή σκοπούς μετανάστευσης περιεχομένου.

Αυτό το άρθρο παρέχει έναν πλήρη οδηγό για το πώς να εξάγετε αποτελεσματικά κείμενο από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for Python via Java. Θα μάθετε πώς να διασχίζετε συστηματικά τα στοιχεία της παρουσίασης για να ανακτήσετε με ακρίβεια το κειμενικό περιεχόμενο που χρειάζεστε.

## **Εξαγωγή κειμένου από διαφάνεια**

Το Aspose.Slides for Python via Java παρέχει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/). Αυτή η κλάση εκθέτει πολλές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για να εξάγετε κείμενο από μια διαφάνεια σε μια παρουσίαση, χρησιμοποιήστε τη μέθοδο [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/#getAllTextBoxes). Αυτή η μέθοδος δέχεται ένα αντικείμενο τύπου [BaseSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/) ως παράμετρο. Κατά την εκτέλεση, η μέθοδος σαρώσει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων τύπου [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/), διατηρώντας τυχόν μορφοποίηση κειμένου.

Το παρακάτω αποσπάσμα κώδικα εξάγει όλο το κείμενο από την πρώτη διαφάνεια της παρουσίασης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Εξαγωγή κειμένου από παρουσίαση**

Για να σαρώσετε κείμενο από ολόκληρη την παρουσίαση, χρησιμοποιήστε τη στατική μέθοδο [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/#getAllTextFrames) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/). Δέχεται δύο παραμέτρους:

1. Πρώτα, ένα αντικείμενο τύπου [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.
1. Δεύτερα, μια τιμή τύπου `bool` που υποδεικνύει αν θα συμπεριληφθούν οι κύριες διαφάνειες κατά τη σάρωση του κειμένου από την παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων τύπου [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/), συμπεριλαμβανομένων πληροφοριών μορφοποίησης κειμένου. Ο παρακάτω κώδικας σαράρει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των κύριων διαφανειών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Κατηγοριοποιημένη και γρήγορη εξαγωγή κειμένου**

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Εξαγωγή κειμένου από αρχείο.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Εξαγωγή κειμένου από ροή.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Εξαγωγή κειμένου από ροή χρησιμοποιώντας επιλογές φόρτωσης.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

Το όρισμα enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/textextractionarrangingmode/) υποδεικνύει τη λειτουργία οργάνωσης του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις ακόλουθες τιμές:

- Unarranged - Το ακατέργαστο κείμενο χωρίς να λαμβάνεται υπόψη η θέση του στη διαφάνεια.
- Arranged - Το κείμενο οργανώνεται με την ίδια σειρά όπως στην διαφάνεια.

Η λειτουργία Unarranged μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι ταχύτερη από τη λειτουργία Arranged.

[PresentationText](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationtext/) αντιπροσωπεύει το ακατέργαστο κείμενο που εξήχθη από την παρουσίαση. Η μέθοδος [getSlidesText](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationtext/#getSlidesText) επιστρέφει έναν πίνακα αντικειμένων τύπου `SlideText`. Κάθε αντικείμενο αντιπροσωπεύει το κείμενο της αντίστοιχης διαφάνειας. Το αντικείμενο τύπου `SlideText` διαθέτει τις ακόλουθες μεθόδους:

- `getText` - Το κείμενο εντός των σχήματων της διαφάνειας.
- `getMasterText` - Το κείμενο εντός των σχήματων της κύριας διαφάνειας που συνδέεται με αυτή τη διαφάνεια.
- `getLayoutText` - Το κείμενο εντός των σχήματων της διαφάνειας διάταξης που συνδέεται με αυτή τη διαφάνεια.
- `getNotesText` - Το κείμενο εντός των σχήματων της διαφάνειας σημειώσεων που συνδέεται με αυτή τη διαφάνεια.
- `getCommentsText` - Το κείμενο εντός των σχολίων που σχετίζονται με αυτή τη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **Συχνές ερωτήσεις**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides είναι βελτιστοποιημένο για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [μεγάλες παρουσιάσεις](/slides/el/python-java/open-presentation/), καθιστώντας το κατάλληλο για σεναρια real‑time ή μαζικής επεξεργασίας.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και γραφήματα μέσα σε παρουσιάσεις;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία της διαφάνειας, συμπεριλαμβανομένων πινάκων και αντικειμένων σχετικών με γραφήματα, ώστε να μπορείτε να έχετε πρόσβαση και να αναλύσετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσίασης.

**Χρειάζεται ειδική άδεια Aspose.Slides για την εξαγωγή κειμένου από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν έκδοση δοκιμής του Aspose.Slides, αν και θα έχει [ορισμένους περιορισμούς](/slides/el/python-java/licensing/), όπως η επεξεργασία μόνο περιορισμένου αριθμού διαφανειών. Για απεριόριστη χρήση και για διαχείριση μεγαλύτερων παρουσιάσεων, συνιστάται η αγορά πλήρους άδειας.