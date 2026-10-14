---
title: Μετατροπή διαφανειών PowerPoint σε PNG με Python
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/python-net/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint σε PNG
- μετατροπή παρουσίασης σε PNG
- μετατροπή διαφάνειας σε PNG
- μετατροπή PPT σε PNG
- μετατροπή PPTX σε PNG
- μετατροπή ODP σε PNG
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- ODP σε PNG
- Python
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε εικόνες PNG υψηλής ποιότητας γρήγορα με το Aspose.Slides για Python μέσω .NET, εξασφαλίζοντας ακριβή, αυτόματα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε διαφάνειες παρουσίασης σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Μπορείτε να φορτώσετε παρουσιάσεις σε μορφές όπως PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να την αποθηκεύσετε ως ξεχωριστή εικόνα PNG.

Τα παρακάτω παραδείγματα δείχνουν απόδοση στην προεπιλεγμένη κλίμακα, αύξηση της κλίμακας, καθορισμό των διαστάσεων εξόδου σε εικονοστοιχεία και επιλογή στυλ απόδοσης gradient.

## **Μετατροπή PowerPoint σε PNG**

Φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις διαφάνειές της μέσω της συλλογής [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). Το παράδειγμα αποδίδει κάθε διαφάνεια με το [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) χωρίς παραμέτρους για να δημιουργήσει μια μικρογραφία. Στη συνέχεια καλεί το [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) με το [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) για να αποθηκεύσει κάθε αποδοθείσα διαφάνεια ως εικόνα PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Η υπερφόρτωση [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) χωρίς παραμέτρους αποδίδει σε κλίμακα 0.2. Για παράδειγμα, μια διαφάνεια διαστάσεων 720 × 540 σημεία παράγει μικρογραφία 144 × 108 εικονοστοιχεία. Για να ελέγχετε τις διαστάσεις εξόδου, χρησιμοποιήστε τις υπερφορτώσεις με παράγοντες κλίμακας ή ένα ρητό μέγεθος εικόνας όπως φαίνεται παρακάτω.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PNG με προσαρμοσμένες διαστάσεις**

Περάστε οριζόντιους και κατακόρυφους παράγοντες κλίμακας στο [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) για να ελέγξετε τις αποδοθείσες διαστάσεις. Σε αυτό το παράδειγμα, και οι δύο παράγοντες είναι 2, έτσι μια διαφάνεια διαστάσεων 720 × 540 σημεία παράγει εικόνα 1440 × 1080 εικονοστοιχεία. Ισόπαλοι παράγοντες κλίμακας διατηρούν την αναλογική αναλογία της διαφάνειας. Κάθε εικόνα αποθηκεύεται σε μορφή PNG με το [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Μετατροπή PowerPoint σε PNG με προσαρμοσμένο μέγεθος**

Για να καθορίσετε τις διαστάσεις εξόδου σε εικονοστοιχεία, περάστε ένα μέγεθος στο [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) αντί για παράγοντες κλίμακας. Αυτό το παράδειγμα αποδίδει κάθε διαφάνεια στα 960 × 720 εικονοστοιχεία και αποθηκεύει το αποτέλεσμα με το [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Επιλέξτε διαστάσεις που ταιριάζουν στην αναλογική αναλογία της διαφάνειας ώστε να αποφύγετε το τράβηγμα της εικόνας.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Επιλογή στυλ απόδοσης gradient**

Υποθέστε ότι μια διαφάνεια περιέχει γεμίσματα gradient, αλλά οι μεταβάσεις στην εξαχθείσα PNG φαίνονται πιο ανοιχτές ή διαφορετικές από ό,τι βλέπετε στο PowerPoint. Μπορείτε να χρησιμοποιήσετε την ιδιότητα [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) του [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) για να επιλέξετε πώς θα αποδίδονται τα gradients.

Κατεβάστε το [gradient-styles.pptx](gradient-styles.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη του διαφάνεια περιέχει δύο γραμμικά gradients: κυανό προς πορτοκαλί στην κορυφή και μπλε προς κίτρινο στο κάτω μέρος. Κάθε gradient έχει δύο στάσεις, στο 0% και στο 100%.

Το παρακάτω παράδειγμα φορτώνει αυτήν την παρουσίαση και αποδίδει την ίδια πρώτη διαφάνεια και στις δύο λειτουργίες με το [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Οι εικόνες παρακάτω δείχνουν το αποτέλεσμα από την ίδια διαφάνεια, με και τα δύο gradients σε κάθε εικόνα:

| Default | PowerPointUI |
| --- | --- |
| ![Gradient από κυανό σε πορτοκαλί και από μπλε σε κίτρινο αποτυπωμένο με Default](gradient-Default.png) | ![Τα ίδια gradients αποτυπωμένα με PowerPointUI](gradient-PowerPointUI.png) |

Σε αυτό το παράδειγμα, το `DEFAULT` παράγει πιο φωτεινά ενδιάμεσα χρώματα, ενώ το `POWER_POINT_UI` παράγει πιο σκούρα ενδιάμεσα χρώματα. Η διαφορά εξαρτάται από τα χρώματα και τις στάσεις στο gradient.

Επιλέξτε το `DEFAULT` όταν η προεπιλεγμένη έξοδος του Aspose.Slides καλύπτει τις ανάγκες σας. Δοκιμάστε το `POWER_POINT_UI` όταν η προτεραιότητά σας είναι η αντιστοίχιση της εμφάνισης στο PowerPoint. Συγκρίνετε και τα δύο αποτελέσματα με το επιθυμητό σας αποτέλεσμα· κανένας τρόπος δεν είναι καθολικά προτιμότερος.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να εξάγω ένα συγκεκριμένο σχήμα, όπως γράφημα ή εικόνα, αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/python-net/create-shape-thumbnails/), επιτρέποντάς σας να αποδώσετε ένα σχήμα ως εικόνα PNG.

**Υποστηρίζεται παράλληλη μετατροπή σε διακομιστή;**

Ναι. Χρησιμοποιήστε ένα ξεχωριστό αντικείμενο παρουσίασης για κάθε νήμα ή διεργασία· [μην μοιράζεστε ένα ενιαίο αντικείμενο μεταξύ νημάτων](/slides/el/python-net/multithreading/).

**Ποιες είναι οι περιορισμοί αξιολόγησης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις εικόνες εξόδου και εφαρμόζει [άλλους περιορισμούς](/slides/el/python-net/licensing/) μέχρι να εφαρμοστεί άδεια.