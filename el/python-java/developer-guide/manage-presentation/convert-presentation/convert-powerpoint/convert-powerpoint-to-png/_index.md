---
title: Μετατροπή διαφανειών PowerPoint σε PNG με Python
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/python-java/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- αποθήκευση PPT ως PNG
- αποθήκευση PPTX ως PNG
- εξαγωγή PPT σε PNG
- εξαγωγή PPTX σε PNG
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint σε εικόνες PNG με Python μέσω Java. Εξαγωγή παρουσιάσεων PPT, PPTX και ODP με προσαρμοσμένες κλίμακες ή ακριβείς διαστάσεις εικόνας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Μπορείτε να φορτώσετε αρχεία PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να την αποθηκεύσετε ως ξεχωριστή εικόνα PNG.

Τα παραδείγματα δείχνουν επίσης πώς να ελέγξετε τις διαστάσεις εξόδου με παράγοντες κλίμακας ή με ακριβές πλάτος και ύψος. Κάθε παράδειγμα ξεκινά τη μηχανή εικονικής Java εάν απαιτείται και απελευθερώνει τους πόρους της παρουσίασης και της εικόνας μετά τη χρήση.

## **Μετατροπή PowerPoint σε PNG**

1. Φορτώστε το αρχείο εισόδου με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Ανακτήστε τις διαφάνειες χρησιμοποιώντας το [Presentation.getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides).
3. Αποδώστε κάθε διαφάνεια χρησιμοποιώντας το [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage).
4. Αποθηκεύστε κάθε αποδομένη εικόνα με το [ImageFormat.Png](https://reference.aspose.com/slides/el/python-java/aspose.slides/imageformat/#Png), στη συνέχεια απελευθερώστε τους πόρους της.

Το παρακάτω παράδειγμα Python εξάγει όλες τις διαφάνειες στο προεπιλεγμένο μέγεθός τους:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Μετατροπή PowerPoint σε PNG με προσαρμοσμένη κλίμακα**

Περάστε οριζόντιους και κάθετους παράγοντες κλίμακας στο [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) για να αυξήσετε ή να μειώσετε τις διαστάσεις εξόδου. Για παράδειγμα, μια διαφάνεια 720 × 540 σημείων που αποδίδεται με παράγοντα κλίμακας 2 και στους δύο άξονες δημιουργεί μια εικόνα 1440 × 1080 pixel.

Χρησιμοποιήστε ίσους παράγοντες κλίμακας για να διατηρήσετε την αναλογία διαστάσεων της διαφάνειας. Διαφορετικοί παράγοντες τεντώνουν τη διαφάνεια οριζόντια ή κάθετα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Μετατροπή PowerPoint σε PNG με προσαρμοσμένο μέγεθος**

Για να ορίσετε ακριβείς διαστάσεις σε pixel, περάστε ένα αντικείμενο Java `Dimension` με το επιθυμητό πλάτος και ύψος στο [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage). Επιλέξτε διαστάσεις με την ίδια αναλογία όπως η αρχική διαφάνεια για να αποφύγετε την παραμόρφωση.

Το παρακάτω παράδειγμα αποθηκεύει κάθε διαφάνεια ως εικόνα PNG 960 × 720 pixel:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Μπορώ να εξάγω ένα μεμονωμένο σχήμα, όπως ένα γράφημα ή μια εικόνα, αντί για ολόκληρη τη διαφάνεια;**

Ναι. Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/python-java/create-shape-thumbnails/), τις οποίες μπορείτε να αποθηκεύσετε ως εικόνες PNG.

**Μπορώ να μετατρέψω παρουσιάσεις παράλληλα σε έναν διακομιστή;**

Χρησιμοποιήστε ξεχωριστή παρουσίαση για κάθε νήμα ή διεργασία και χρησιμοποιήστε μοναδικές διαδρομές εξόδου για να αποτρέψετε την αντικατάσταση αρχείων. Μην κοινοποιείτε μια παρουσίαση μεταξύ νημάτων. Δείτε το [Multithreading](/slides/el/python-java/multithreading/).

**Ποιους περιορισμούς έχει η δοκιμαστική έκδοση κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις εικόνες εξόδου και εφαρμόζει [άλλους περιορισμούς](/slides/el/python-java/licensing/). Εφαρμόστε άδεια για να αφαιρέσετε αυτούς τους περιορισμούς.