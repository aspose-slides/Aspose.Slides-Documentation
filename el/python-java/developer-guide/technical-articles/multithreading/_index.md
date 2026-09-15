---
title: Πολυνηματισμός στο Aspose.Slides για Python μέσω Java
linktitle: Πολυνηματισμός
type: docs
weight: 310
url: /el/python-java/multithreading/
keywords:
- πολυνηματισμός
- πολλαπλά νήματα
- παράλληλη εργασία
- μετατροπή διαφανειών
- διαφάνειες σε εικόνες
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides για Python μέσω Java πολυνηματισμός ενισχύει την επεξεργασία PowerPoint και OpenDocument. Ανακαλύψτε τις βέλτιστες πρακτικές για αποδοτικές ροές εργασίας παρουσίασης."
---
## **Εισαγωγή**

Αν και η παράλληλη εργασία με παρουσιάσεις είναι δυνατή (εκτός από την ανάλυση, τη φόρτωση και την κλωνοποίηση) και συνήθως λειτουργεί καλά, υπάρχει μια μικρή πιθανότητα λανθασμένων αποτελεσμάτων όταν χρησιμοποιείτε τη βιβλιοθήκη σε πολλαπλά νήματα.

Συνιστούμε ανεπιφύλακτα να **μην** χρησιμοποιείτε ένα μόνο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) αντικείμενο σε περιβάλλον πολλαπλών νημάτων, επειδή μπορεί να οδηγήσει σε απρόβλεπτα σφάλματα ή αποτυχίες που δεν εντοπίζονται εύκολα.

**δεν** είναι ασφαλές να φορτώνετε, αποθηκεύετε και/ή κλωνοποιείτε ένα [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) αντικείμενο σε πολλαπλά νήματα. Τέτοιες λειτουργίες **δεν** υποστηρίζονται. Εάν χρειάζεται να εκτελέσετε τέτοιες εργασίες, πρέπει να παραλληλοποιήσετε τις λειτουργίες χρησιμοποιώντας αρκετές διαδικασίες με μονό‑νήμα και το καθένα από αυτές τις διαδικασίες θα πρέπει να χρησιμοποιεί το δικό του αντικείμενο παρουσίασης.

## **Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες Παράλληλα**

Ας υποθέσουμε ότι θέλουμε να μετατρέψουμε όλες τις διαφάνειες από μια παρουσίαση PowerPoint σε εικόνες PNG παράλληλα. Καθώς είναι μη ασφαλές να χρησιμοποιούμε ένα μόνο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) αντικείμενο σε πολλαπλά νήματα, χωρίζουμε τις διαφάνειες της παρουσίασης σε ξεχωριστές παρουσιάσεις και μετατρέπουμε τις διαφάνειες σε εικόνες παράλληλα, χρησιμοποιώντας κάθε παρουσίαση σε ξεχωριστό νήμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να το κάνετε.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Εξάγετε τη διαφάνεια σε ξεχωριστή παρουσίαση.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Μετατρέψτε τη διαφάνεια σε εικόνα σε ξεχωριστό έργο.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Περιμένετε να ολοκληρωθούν όλες οι εργασίες.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Πρέπει να καλέσω τη ρύθμιση άδειας σε κάθε νήμα;**

Όχι. Αρκεί να το κάνετε μία φορά ανά διεργασία πριν ξεκινήσουν τα νήματα. Εάν η [license setup](/slides/el/python-java/licensing/) μπορεί να κληθεί ταυτόχρονα (π.χ., κατά την καθυστερημένη αρχικοποίηση), συγχρονίστε αυτήν την κλήση επειδή η μέθοδος ρύθμισης άδειας δεν είναι ασφαλής ως προς τα νήματα.

**Μπορώ να περάσω αντικείμενα [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) ή [Slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/) μεταξύ νημάτων;**

Η μετάδοση «ζωντανών» αντικειμένων παρουσίασης μεταξύ νημάτων δεν συνιστάται: χρησιμοποιήστε ανεξάρτητα αντικείμενα ανά νήμα ή δημιουργήστε ξεχωριστές παρουσιάσεις ή περιέκτες διαφανειών για κάθε νήμα εκ των προτέρων. Αυτή η προσέγγιση ακολουθεί τη γενική σύσταση να μην μοιράζεστε ένα μόνο αντικείμενο παρουσίασης μεταξύ νημάτων.

**Είναι ασφαλές να παραλληλοποιήσετε την εξαγωγή σε διαφορετικές μορφές (PDF, HTML, εικόνες) εφόσον κάθε νήμα έχει το δικό του αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/);**

Ναι. Με ανεξάρτητα αντικείμενα και ξεχωριστές διαδρομές εξόδου, αυτές οι εργασίες συνήθως παραλληλοποιούνται σωστά· αποφύγετε οποιαδήποτε κοινόχρηστα αντικείμενα παρουσίασης και κοινά ρεύματα I/O.

**Τι πρέπει να κάνω με τις καθολικές ρυθμίσεις γραμματοσειράς (φακέλους, υποκαταστάσεις) στον πολυνηματισμό;**

Αρχικοποιήστε όλες τις καθολικές [font settings](/slides/el/python-java/powerpoint-fonts/) πριν ξεκινήσουν τα νήματα και μην τις αλλάζετε κατά τη διάρκεια της παράλληλης εργασίας. Αυτό εξαλείφει τους αγώνες πρόσβασης σε κοινόχρηστους πόρους γραμματοσειρών.