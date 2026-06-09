---
title: Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις με Python
linktitle: Ετικέτες και Προσαρμοσμένα Δεδομένα
type: docs
weight: 300
url: /el/python-net/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσθήκη ετικέτας
- ζεύγη τιμών
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, διαβάζετε, ενημερώνετε και αφαιρείτε ετικέτες και προσαρμοσμένα δεδομένα στο Aspose.Slides για Python μέσω .NET, με παραδείγματα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Περιγράφει εν συντομία πώς αποθηκεύονται τα δεδομένα στα αρχεία PPTX, σημειώνει ότι δεδομένα ειδικά για την παρουσίαση μπορούν να υπάρξουν ως ετικέτες και προσαρμοσμένα τμήματα XML, και περιγράφει τις ετικέτες ως ζεύγη κλειδί‑τιμή σε μορφή συμβολοσειράς.

Δείχνει επίσης πώς να διαβάσετε τις τιμές των ετικετών και πώς να προσθέσετε ετικέτες σε μια παρουσίαση, μια μεμονωμένη διαφάνεια ή ένα σχήμα. Επιπλέον, το άρθρο καλύπτει κοινές εργασίες διαχείρισης ετικετών όπως ο καθαρισμός όλων των ετικετών, η αφαίρεση ετικέτας με όνομα και η ανάκτηση της λίστας των ονομάτων ετικετών.

## **Αποθήκευση δεδομένων σε αρχεία παρουσίασης**

Τα αρχεία PPTX — αντικείμενα με την κατάληξη .pptx — αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος του προτύπου Office Open XML. Η μορφή Office Open XML ορίζει τη δομή για τα δεδομένα που περιέχονται στις παρουσιάσεις.

Με μια *διαφάνεια* να αποτελεί ένα από τα στοιχεία στις παρουσιάσεις, ένα *τμήμα διαφάνειας* περιέχει το περιεχόμενο μιας μοναδικής διαφάνειας. Ένα τμήμα διαφάνειας μπορεί να έχει ρητές σχέσεις με πολλά τμήματα — όπως οι Προσαρμοσμένες Ετικέτες Χρήστη — ορισμένες από το ISO/IEC 29500.

Προσαρμοσμένα δεδομένα (συγκεκριμένα για μια παρουσίαση) ή χρήστης μπορούν να υπάρχουν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/itagcollection/)) και CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 

Οι ετικέτες είναι ουσιαστικά ζεύγη κλειδί‑συμβολοσειράς. 

{{% /alert %}} 

## **Λήψη των τιμών των ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στην ιδιότητα IDocumentProperties.Keywords. Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides for Python via .NET για [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Προσθήκη ετικετών σε παρουσιάσεις**

Το Aspose.Slides σας επιτρέπει να προσθέτετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας – `MyTag` 
- η τιμή της προσαρμοσμένης ιδιότητας – `My Tag Value`

Εάν χρειάζεται να ταξινομήσετε κάποιες παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να επωφεληθείτε από την προσθήκη ετικετών σε αυτές τις παρουσιάσεις. Για παράδειγμα, αν θέλετε να κατηγοριοποιήσετε ή να ομαδοποιήσετε όλες τις παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και να ορίσετε τις σχετικές χώρες (Η.Π.Α., Μεξικό, Καναδά) ως τιμές.

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) χρησιμοποιώντας το Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Οι ετικέτες μπορούν επίσης να οριστούν για [Slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Ή για οποιοδήποτε μεμονωμένο [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής `custom_data.tags` αποθηκεύονται μόνο μέσα στο αρχείο PowerPoint. **Δεν** μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος ταυτοποιητής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Workaround**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο ταυτοποιητή στο **Alt Text** του αντικειμένου (π.χ., `shape.alternative_text = "MyId"`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών PDF.

## **FAQ**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία λειτουργία;**

Ναι. Η [συλλογή ετικετών](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/) υποστηρίζει λειτουργία [clear](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/clear/) που διαγράφει όλα τα ζεύγη κλειδί‑τιμή μονομιάς.

**Πώς διαγράφω μία μόνο ετικέτα με το όνομά της χωρίς να επαναλαμβάνομαι σε όλη τη συλλογή;**

Χρησιμοποιήστε τη λειτουργία [remove(name)](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/remove/) στη [TagCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα των ονομάτων ετικετών για αναλύσεις ή φιλτράρισμα;**

Χρησιμοποιήστε τη μέθοδο [get_names_of_tags](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/get_names_of_tags/) στην [συλλογή ετικετών](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.