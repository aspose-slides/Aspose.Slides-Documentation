---
title: Αλλαγή μεγέθους σχημάτων στις διαφάνειες παρουσίασης σε Python μέσω Java
type: docs
weight: 110
url: /el/python-java/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- αλλαγή διαστάσεων σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Απλά αλλάξτε το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω Java—αυτοματοποιήστε τις προσαρμογές διάταξης διαφάνειας και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Μία από τις πιο συχνές ερωτήσεις από πελάτες του Aspose.Slides for Python via Java είναι πώς να αλλάξουν το μέγεθος των σχημάτων έτσι ώστε, όταν αλλάζει το μέγεθος της διαφάνειας, τα δεδομένα να μην κόβονται. Αυτό το σύντομο τεχνικό άρθρο δείχνει πώς να το κάνετε.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να αποτραπεί η δυσευθυγράμμιση των σχημάτων όταν αλλάζει το μέγεθος της διαφάνειας, ενημερώστε τη θέση και τις διαστάσεις κάθε σχήματος ώστε να ταιριάζουν με τη νέα διάταξη της διαφάνειας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Φόρτωση αρχείου παρουσίασης.
presentation = Presentation("sample.ppt")
try:
    # Λήψη αρχικού μεγέθους διαφάνειας.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Αλλαγή μεγέθους διαφάνειας χωρίς κλιμάκωση των υπαρχόντων σχημάτων.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Λήψη νέου μεγέθους διαφάνειας.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Αλλαγή μεγέθους και επανατοποθέτηση σχημάτων σε κάθε διαφάνεια.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Κλιμάκωση μεγέθους σχήματος.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Κλιμάκωση θέσης σχήματος.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Οι πίνακες δεν χρειάζονται ειδική μεταχείριση: ο ορισμός του πλάτους και του ύψους ενός πίνακα αναπροσαρμόζει τις στήλες και τις γραμμές του ανάλογα, οπότε η επαναπλήρωση του ύψους των γραμμών και του πλάτους των στηλών ξανά θα εφαρμόσει τον λόγο δύο φορές.

{{% /alert %}} 

Ο παραπάνω κώδικας αλλάζει μόνο τα σχήματα στις διαφάνειες. Οι κύριες διαφάνειες (master slides) και οι διαφάνειες διάταξης (layout slides) διατηρούν τα δικά τους σχήματα, έτσι θα πρέπει να τα κλιμακώσετε επίσης όταν θέλετε ολόκληρη η παρουσίαση να ακολουθεί το νέο μέγεθος διαφάνειας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Λήψη αρχικού μεγέθους διαφάνειας.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Αλλαγή μεγέθους διαφάνειας χωρίς κλιμάκωση των υπαρχόντων σχημάτων.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Λήψη νέου μεγέθους διαφάνειας.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Κλιμάκωση μεγέθους σχήματος.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Κλιμάκωση θέσης σχήματος.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Κλιμάκωση μεγέθους σχήματος.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Κλιμάκωση θέσης σχήματος.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Κλιμάκωση μεγέθους σχήματος.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Κλιμάκωση θέσης σχήματος.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή κόβονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Κατά την αλλαγή μεγέθους μιας διαφάνειας, τα σχήματα διατηρούν την αρχική τους θέση και μέγεθος εκτός εάν η κλίμακα αλλάξει ρητά. Αυτό μπορεί να οδηγήσει σε αποκοπή του περιεχομένου ή σε δυσευθυγράμμιση των σχημάτων.

**Λειτουργεί ο δοθείς κώδικας για όλους τους τύπους σχημάτων;**

Ναι. Ο ορισμός του ύψους και του πλάτους λειτουργεί για πλαίσια κειμένου, εικόνες, διαγράμματα και πίνακες εξίσου.

**Πώς να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το σχήμα του πίνακα αυτό καθαυτό, ακριβώς όπως οποιοδήποτε άλλο σχήμα. Οι γραμμές και οι στήλες του ακολουθούν ανάλογα, οπότε μην τις κλιμακώσετε ξανά αργότερα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για τις κύριες διαφάνειες και τις διαφάνειες διάταξης;**

Ναι, αλλά πρέπει επίσης να διασχίσετε τις [Presentation.getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasters) και [Presentation.getLayoutSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getLayoutSlides) και να εφαρμόσετε την ίδια λογική κλιμάκωσης στα σχήματά τους, ώστε να διασφαλιστεί η συνέπεια σε όλη την παρουσίαση.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (πορτραίτο/τοπίο) μαζί με την αλλαγή μεγέθους;**

Ναι. Μπορείτε να χρησιμοποιήσετε το [SlideSize.setOrientation](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#setOrientation) για να αλλάξετε τον προσανατολισμό. Βεβαιωθείτε ότι έχετε ορίσει τη λογική κλιμάκωσης αναλόγως ώστε να διατηρηθεί η διάταξη.

**Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;**

Το Aspose.Slides υποστηρίζει προσαρμοσμένα μεγέθη, αλλά πολύ μεγάλα μεγέθη μπορεί να επηρεάσουν την απόδοση ή τη συμβατότητα με ορισμένες εκδόσεις του PowerPoint.

**Πώς μπορώ να αποτρέψω τα σχήματα με κλειδωμένο λόγο διαστάσεων από το να παραμορφώνονται;**

Μπορείτε να ελέγξετε τη μέθοδο [getAspectRatioLocked](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) του κλειδώματος του σχήματος πριν την κλιμάκωση. Εάν είναι κλειδωμένο, προσαρμόστε το πλάτος ή το ύψος αναλογικά αντί να τα κλιμακώσετε ξεχωριστά.