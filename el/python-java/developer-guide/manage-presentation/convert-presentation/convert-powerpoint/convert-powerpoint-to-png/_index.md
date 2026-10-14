---
title: Μετατροπή διαφανειών PowerPoint σε PNG σε Python
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
description: "Μετατροπή διαφανειών PowerPoint σε εικόνες PNG με Python μέσω Java. Εξαγωγή παρουσιάσεων PPT, PPTX και ODP με προσαρμοσμένες κλίμακες ή ακριβείς διαστάσεις εικόνας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε διαφάνειες παρουσίασης σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Μπορείτε να φορτώσετε παρουσιάσεις σε μορφές όπως PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να την αποθηκεύσετε ως ξεχωριστή εικόνα PNG.

Τα παραδείγματα παρακάτω δείχνουν απόδοση στην προεπιλεγμένη κλίμακα, αύξηση της κλίμακας, καθορισμό των διαστάσεων εξόδου σε εικονοστοιχεία και επιλογή ενός στυλ απόδοσης διαβάθμισης.

## **Μετατροπή PowerPoint σε PNG**

Φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) και προσπελάστε τις διαφάνειες της μέσω της συλλογής [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). Το παράδειγμα αποδίδει κάθε διαφάνεια με το [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) χωρίς παραμέτρους για τη δημιουργία μικρογραφίας. Στη συνέχεια καλεί το [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) με το [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) για να αποθηκεύσει κάθε αποδοθείσα διαφάνεια ως εικόνα PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Η υπερφόρτωση του [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) χωρίς παραμέτρους αποδίδει σε κλίμακα 0.2. Για παράδειγμα, μια διαφάνεια που μετρά 720 × 540 σημεία παράγει μικρογραφία 144 × 108 εικονοστοιχείων. Για να ελέγξετε τις διαστάσεις εξόδου, χρησιμοποιήστε τις υπερφορτώσεις με παράγοντες κλίμακας ή ένα ρητό μέγεθος εικόνας όπως φαίνεται παρακάτω.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Περάστε οριζόντιους και κάθετους παράγοντες κλίμακας στο [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) για να ελέγξετε τις αποδοθείσες διαστάσεις. Σε αυτό το παράδειγμα, και οι δύο παράγοντες είναι 2, έτσι μια διαφάνεια που μετρά 720 × 540 σημεία παράγει εικόνα 1440 × 1080 εικονοστοιχείων. Οι ίσοι παράγοντες κλίμακας διατηρούν την αναλογία διαστάσεων της διαφάνειας. Κάθε αποδοθείσα εικόνα αποθηκεύεται σε μορφή PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Για να καθορίσετε τις διαστάσεις εξόδου σε εικονοστοιχεία, περάστε ένα μέγεθος στο [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) αντί για παράγοντες κλίμακας. Αυτό το παράδειγμα αποδίδει κάθε διαφάνεια σε 960 × 720 εικονοστοιχεία και αποθηκεύει το αποτέλεσμα σε μορφή PNG. Επιλέξτε διαστάσεις που ταιριάζουν με την αναλογία της διαφάνειας ώστε να αποφύγετε την παραμόρφωση της εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Επιλογή Στυλ Απόδοσης Διαβάθμισης**

Υποθέστε ότι μια διαφάνεια περιέχει διαβαθμίσεις, αλλά οι μεταβάσεις στην εξαγόμενη PNG εμφανίζονται πιο ανοιχτές ή διαφορετικές από ό,τι βλέπετε στο PowerPoint. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) που κληρονομείται από το [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) για να επιλέξετε πώς θα αποδίδονται οι διαβαθμίσεις.

Κατεβάστε το αρχείο [gradient-styles.pptx](gradient-styles.pptx) και τοποθετήστε το στον κατάλογο εργασίας της εφαρμογής. Η πρώτη του διαφάνεια περιέχει δύο γραμμικές διαβαθμίσεις: κυανό σε πορτοκαλί στην κορυφή και μπλε σε κίτρινο στο κάτω μέρος. Κάθε διαβάθμιση έχει δύο στάσεις, στο 0 % και στο 100 %.

Το παρακάτω παράδειγμα φορτώνει αυτήν την παρουσίαση και αποδίδει την ίδια πρώτη διαφάνεια και στις δύο λειτουργίες με το [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Οι εικόνες παρακάτω δείχνουν το αποτέλεσμα από την ίδια διαφάνεια, με τις δύο διαβαθμίσεις σε κάθε εικόνα:

| Default | PowerPointUI |
| --- | --- |
| ![Διαβαθμίσεις κυανό-πορτοκαλί και μπλε-κίτρινο αποδομένες με Default](gradient-Default.png) | ![Οι ίδιες διαβαθμίσεις αποδομένες με PowerPointUI](gradient-PowerPointUI.png) |

Σε αυτό το παράδειγμα, το `Default` παράγει πιο ανοιχτά ενδιάμεσα χρώματα, ενώ το `PowerPointUI` παράγει πιο σκούρα ενδιάμεσα χρώματα. Η διαφορά εξαρτάται από τα χρώματα και τις στάσεις στη διαβάθμιση.

Επιλέξτε το `Default` όταν η τυπική έξοδος του Aspose.Slides ανταποκρίνεται στις ανάγκες σας. Δοκιμάστε το `PowerPointUI` όταν η προτεραιότητά σας είναι η αντιστοίχηση με την εμφάνιση στο PowerPoint. Συγκρίνετε και τις δύο εξόδους με το επιθυμητό αποτέλεσμα· κανένας τρόπος δεν είναι γενικά προτιμότερος.

## **Συχνές ερωτήσεις**

**Πώς μπορώ να εξάγω ένα συγκεκριμένο σχήμα, όπως ένα γράφημα ή εικόνα, αντί ολόκληρης της διαφάνειας;**

Το Aspose.Slides υποστηρίζει [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/python-java/create-shape-thumbnails/), επιτρέποντάς σας να αποδώσετε ένα σχήμα ως εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι. Χρησιμοποιήστε ξεχωριστό αντικείμενο παρουσίασης για κάθε νήμα ή διεργασία· [μην μοιράζεστε ένα μόνο αντικείμενο μεταξύ νημάτων](/slides/el/python-java/multithreading/).

**Ποιους περιορισμούς έχει η δοκιμαστική έκδοση κατά την εξαγωγή σε PNG;**

Η δοκιμαστική λειτουργία προσθέτει υδάτινο σήμα στις εικόνες εξόδου και εφαρμόζει [άλλους περιορισμούς](/slides/el/python-java/licensing/) μέχρι να εφαρμοστεί άδεια.