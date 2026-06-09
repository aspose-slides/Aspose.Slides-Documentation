---
title: Μετατροπή διαφανειών PowerPoint σε PNG με Python
linktitle: Διαφάνεια σε PNG
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
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε εικόνες PNG υψηλής ποιότητας γρήγορα με Aspose.Slides για Python μέσω .NET, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω .NET κάνει εύκολη τη μετατροπή παρουσιάσεων PowerPoint σε PNG. Φορτώνετε μια παρουσίαση, διατρέχετε τις διαφάνειές της, αποδίδετε καθεμία σε εικόνα raster και αποθηκεύετε το αποτέλεσμα ως αρχεία PNG. Αυτό είναι ιδανικό για τη δημιουργία προεπισκοπήσεων διαφανειών, την ενσωμάτωση διαφανειών σε ιστοσελίδες ή την παραγωγή στατικών πόρων για επακόλουθη επεξεργασία.

## **Μετατροπή Διαφανειών σε PNG**

Αυτή η ενότητα δείχνει το πιο απλό δυνατό παράδειγμα μετατροπής μιας παρουσίασης PowerPoint σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides for Python μέσω .NET.

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε μια διαφάνεια από τη συλλογή `Presentation.slides` (δείτε την κλάση [Slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/)).
1. Χρησιμοποιήστε τη μέθοδο `Slide.get_image` για να δημιουργήσετε μια μικρογραφία της διαφάνειας.
1. Χρησιμοποιήστε τη μέθοδο `Presentation.save` για να αποθηκεύσετε τη μικρογραφία της διαφάνειας σε μορφή PNG.

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Μετατροπή Διαφανειών σε PNG με Προσαρμοσμένες Διαστάσεις**

Για να εξαγάγετε διαφάνειες σε PNG με προσαρμοσμένη κλίμακα, καλέστε τη `Slide.get_image` με οριζόντιους και κάθετους παράγοντες κλίμακας. Αυτοί οι πολλαπλασιαστές αλλάζουν το μέγεθος της εξόδου σε σχέση με τις αρχικές διαστάσεις της διαφάνειας — για παράδειγμα, το `2.0` διπλασιάζει τόσο το πλάτος όσο και το ύψος. Χρησιμοποιήστε ίσες τιμές για `scale_x` και `scale_y` ώστε να διατηρήσετε την αναλογία διαστάσεων.

Αυτός ο κώδικας Python επιδεικνύει τη περιγραφείσα λειτουργία:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Μετατροπή Διαφανειών σε PNG με Προσαρμοσμένο Μέγεθος**

Αν θέλετε να δημιουργήσετε αρχεία PNG σε συγκεκριμένο μέγεθος, περάστε τις επιθυμητές τιμές `width` και `height`. Ο παρακάτω κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PNG καθορίζοντας το μέγεθος της εικόνας:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Μπορεί να θέλετε να δοκιμάσετε τους δωρεάν **μετατροπείς PowerPoint‑σε‑PNG** του Aspose—[PPTX σε PNG](https://products.aspose.app/slides/el/conversion/pptx-to-png) και [PPT σε PNG](https://products.aspose.app/slides/el/conversion/ppt-to-png). Παρέχουν μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται σε αυτή τη σελίδα.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Πώς μπορώ να εξάγω μόνο ένα συγκεκριμένο σχήμα (π.χ. γράφημα ή εικόνα) αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/python-net/create-shape-thumbnails/); μπορείτε να αποδώσετε ένα σχήμα σε εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι, αλλά [μην μοιράζεστε](/slides/el/python-net/multithreading/) ένα μοναδικό αντικείμενο παρουσίασης μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστό αντικείμενο ανά νήμα ή διαδικασία.

**Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις εικόνες εξόδου και επιβάλλει [άλλους περιορισμούς](/slides/el/python-net/licensing/) μέχρι να εφαρμοστεί άδεια.