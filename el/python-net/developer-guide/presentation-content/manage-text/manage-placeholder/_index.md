---
title: Διαχείριση Προθέσεων σε Παρουσιάσεις με Python
linktitle: Διαχείριση Προθέσεων
type: docs
weight: 10
url: /el/python-net/manage-placeholder/
keywords:
- πρόθεση
- πρόθεση κειμένου
- πρόθεση εικόνας
- πρόθεση γραφήματος
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε εύκολα τις προθέσεις στο Aspose.Slides για Python μέσω .NET: αντικαταστήστε κείμενο, προσαρμόστε προτροπές και ορίστε τη διαφάνεια εικόνας στο PowerPoint και στο OpenDocument."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να διαχειρίζεστε προθέσεις παρουσίασης προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να βρίσκετε προθέσεις σε διαφάνειες και να αλλάζετε το κείμενό τους, να ορίζετε προσαρμοσμένο κείμενο προτροπής για διατάξεις προθέσεων, και να ρυθμίζετε τη διαφάνεια μιας εικόνας που χρησιμοποιείται ως φόντο πρόθεσης. Περιλαμβάνει επίσης μια σύντομη ενότητα ΣΥ.Γ. που διευκρινίζει τη διαφορά μεταξύ βασικών προθέσεων και τοπικών σχημάτων, εξηγεί πώς οι αλλαγές στις προθέσεις μπορούν να εφαρμοστούν μέσω διατάξεων ή master, και παραπέμπει στη διαχείριση προθέσεων κεφαλίδας και υποσέλιδου.

## **Αλλαγή Κειμένου σε Προθέσεις**

Χρησιμοποιώντας το Aspose.Slides για Python, μπορείτε να βρείτε και να τροποποιήσετε προθέσεις σε διαφάνειες μιας παρουσίασης. Το Aspose.Slides σας επιτρέπει να τροποποιείτε το κείμενο σε μια πρόθεση.

**Προαπαιτούμενο:** Χρειάζεστε μια παρουσίαση που περιλαμβάνει μια πρόθεση. Μπορείτε να δημιουργήσετε μια τέτοια παρουσίαση στο Microsoft PowerPoint.

Αυτός είναι ο τρόπος χρήσης του Aspose.Slides για την αντικατάσταση του κειμένου σε μια πρόθεση:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και περάστε την παρουσίαση ως όρισμα.
1. Λάβετε μια αναφορά στη διαφάνεια με το δείκτη της.
1. Διατρέξτε τα σχήματα για να βρείτε την πρόθεση.
1. Αλλάξτε το κείμενο χρησιμοποιώντας το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε το κείμενο σε μια πρόθεση:

```python
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Επανάληψη μέσω των σχημάτων για να βρείτε τις προθέσεις.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Αλλάξτε το κείμενο σε κάθε πρόθεση.
            shape.text_frame.text = "This is Placeholder"

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Κειμένου Προτροπής για Πρόθεση**

Οι τυπικές και προσυγκεκριμένες διατάξεις περιλαμβάνουν κείμενο προτροπής πρόθεσης όπως **Κάντε κλικ για προσθήκη τίτλου** ή **Κάντε κλικ για προσθήκη υπότιτλου**. Με το Aspose.Slides, μπορείτε να αντικαταστήσετε αυτές τις προτροπές με το δικό σας κείμενο στις διατάξεις προθέσεων.

Το παρακάτω παράδειγμα Python δείχνει πώς να ορίσετε το κείμενο προτροπής για μια πρόθεση:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Επανάληψη μέσω των σχημάτων για να βρείτε τις προθέσεις.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Διαφάνειας Εικόνας σε Πρόθεση**

Το Aspose.Slides σας επιτρέπει να ορίσετε τη διαφάνεια μιας εικόνας φόντου σε μια πρόθεση κειμένου. Ρυθμίζοντας τη διαφάνεια της εικόνας στο πλαίσιο αυτό, μπορείτε να κάνετε το κείμενο ή την εικόνα πιο αισθητή, ανάλογα με τα χρώματά τους.

Το παρακάτω παράδειγμα Python δείχνει πώς να ορίσετε τη διαφάνεια ενός φόντου εικόνας μέσα σε ένα σχήμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **ΣΥ.Γ.**

**Τι είναι μια βασική πρόθεση και πώς διαφέρει από ένα τοπικό σχήμα σε μια διαφάνεια;**

Μια βασική πρόθεση είναι το αρχικό σχήμα σε μια διάταξη ή master από το οποίο κληρονομεί το σχήμα της διαφάνειας—ο τύπος, η θέση και ορισμένη μορφοποίηση προέρχονται από αυτήν. Ένα τοπικό σχήμα είναι ανεξάρτητο· εάν δεν υπάρχει βασική πρόθεση, η κληρονομικότητα δεν ισχύει.

**Πώς μπορώ να ενημερώσω όλους τους τίτλους ή τις λεζάντες σε όλη την παρουσίαση χωρίς να επαναλαμβάνω κάθε διαφάνεια;**

Επεξεργαστείτε την αντίστοιχη πρόθεση στη διάταξη ή στο master. Οι διαφάνειες που βασίζονται σε αυτές τις διατάξεις/σε αυτό το master θα κληρονομούν αυτόματα την αλλαγή.

**Πώς ελέγχω τις τυπικές προθέσεις κεφαλίδας/υποσέλιδου—ημερομηνία & ώρα, αριθμός διαφάνειας και κείμενο υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές HeaderFooter στο κατάλληλο επίπεδο (κανονικές διαφάνειες, διατάξεις, master, σημειώσεις/φυλλάδια) για να ενεργοποιήσετε ή να απενεργοποιήσετε αυτές τις προθέσεις και να ορίσετε το περιεχόμενό τους.