---
title: Διαχείριση Placeholder Παρουσίασης σε Python
linktitle: Διαχείριση Placeholder
type: docs
weight: 10
url: /el/python-java/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κράτησης κειμένου
- σύμβολο κράτησης εικόνας
- σύμβολο κράτησης διαγράμματος
- σύμβολο κράτησης περιεχομένου
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να ελέγχετε και να επεξεργάζεστε σύμβολα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοήσετε την κληρονομικότητα των συμβόλων κράτησης με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που κρατά θέση για ένα συγκεκριμένο είδος περιεχομένου σε ένα πρότυπο παρουσίασης. Συχνά παραδείγματα είναι placeholders τίτλου, κειμένου, εικόνας, διαγράμματος και γενικού‑σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένα placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη διαμόρφωση και άλλες ρυθμίσεις του από μια διαφάνεια διάταξης ή κύρια διαφάνεια.

Το Aspose.Slides αποκαλύπτει τις πληροφορίες του placeholder μέσω της μεθόδου [Shape.getPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getPlaceholder). Η μέθοδος επιστρέφει ένα αντικείμενο [Placeholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholder/) ή `None` για ένα κανονικό σχήμα. Χρησιμοποιήστε [Placeholder.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholder/#getType) για να προσδιορίσετε τι προβλέπεται να περιέχει το placeholder.

Ο τύπος του σχήματος εξακολουθεί να έχει σημασία μετά τη γνώση του τύπου του placeholder:

- Ένα κενό placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου συνήθως αντιπροσωπεύεται από ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).
- Ένα γεμάτο placeholder εικόνας μπορεί να αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/).
- Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/).
- Ένα placeholder περιεχομένου μπορεί να περιέχει διάφορους τύπους περιεχομένου. Ελέγξτε τόσο το [Placeholder.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholder/#getType) όσο και τον τύπο σχήματος κατά την εκτέλεση, αντί να υποθέτετε ότι κάθε placeholder είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
Το [Placeholder.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholder/#getType) περιγράφει τον ρόλο ενός placeholder· δεν εγγυάται τον τύπο σχήματος κατά την εκτέλεση. Πάντα πραγματοποιήστε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή ειδικών για πολυμέσα.
{{% /alert %}}

## **Κατανόηση της Κληρονομικότητας των Placeholder**

Τα placeholders σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders επιπέδου master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από το master.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για αυτή τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getBasePlaceholder) για να προχωρήσετε ένα επίπεδο προς τα πάνω στην ιεραρχία. Ένα placeholder διαφάνειας συνήθως επιστρέφει το placeholder της διάταξης· ένα placeholder διάταξης μπορεί να επιστρέψει το placeholder του master. Η μέθοδος επιστρέφει `None` όταν το σχήμα δεν έχει βασικό placeholder.

Το παρακάτω παράδειγμα παραθέτει τα placeholders στην πρώτη διαφάνεια και αναφέρει τα βασικά τους placeholders:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Η επεξεργασία ενός placeholder σε κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική παράκαμψη για αυτή τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή του master μπορεί να επηρεάσει όλες τις διαφάνειες που ακόμη κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό placeholder και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αλλαγή Κειμένου σε Placeholder**

Τα placeholders τίτλου, κεντρικού‑τίτλου, υποτίτλου, σώματος και κειμένου συνήθως υποστηρίζουν κείμενο. Ελέγξτε για [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) πριν χρησιμοποιήσετε τη μέθοδο [getTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#getTextFrame).

Το παράδειγμα αυτό ενημερώνει το πρώτο placeholder τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτή η προσέγγιση αποφεύγει την αντιμετώπιση των placeholders εικόνας, διαγράμματος, πίνακα ή πολυμέσων ως [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/). Επίσης, προσδιορίζει το placeholder με βάση τον σκοπό του αντί να βασίζεται σε ευαίσθητο ευρετήριο σχήματος.

## **Ορισμός Κειμένου Προτροπής σε Διάταξη**

Το κείμενο προτροπής είναι η οδηγία στο χρόνο σχεδίασης που εμφανίζεται σε ένα κενό placeholder, όπως *Κάντε κλικ για προσθήκη τίτλου*. Ορίστε προσαρμοσμένο κείμενο προτροπής στο placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ shapes μιας κανονικής διαφάνειας. Αποκτήστε πρόσβαση στη διάταξη μέσω του [Slide.getLayoutSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getLayoutSlide) και επαναλάβετε τη συλλογή που επιστρέφει το [BaseSlide.getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getShapes).

Το παρακάτω παράδειγμα αλλάζει τις προτροπές του τίτλου και του υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το κείμενο προτροπής δεν είναι κανονικό περιεχόμενο διαφάνειας. Απευθύνεται σε κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παράσχει πραγματικό περιεχόμενο, η προτροπή δεν εμφανίζεται πλέον. Η αλλαγή μιας προτροπής επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις για διαχείριση:

- Εάν το placeholder εικόνας είναι ήδη γεμάτο και αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/), αντικαταστήστε την εικόνα μέσω του [PictureFillFormat.getPicture](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#getPicture) και του [Picture.setImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#setImage).
- Εάν παραμένει κενό placeholder, προσθέστε ένα picture frame στις συντεταγμένες του placeholder με το [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addPictureFrame) και αφαιρέστε το κενό placeholder.

Το επόμενο παράδειγμα υποστηρίζει και τις δύο περιπτώσεις και αποθηκεύει την παρουσίαση:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό picture frame, όχι ένα νέο placeholder, επειδή το [Shape.getPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getPlaceholder) δεν διαθέτει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά του placeholder. Εάν η διατήρηση της σχέσης placeholder είναι ουσιώδης, ετοιμάστε και γεμίστε το placeholder στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτον [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλες εφέ ειδικές για εικόνες, δείτε το [Manage Picture Frames](/slides/el/python-java/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο picture frame ή στο picture fill, όχι στα μεταδεδομένα του placeholder.

## **Εργασία με Placeholder Διαγραμμάτων και Περιεχομένου**

Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπευθεί από ένα [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/). Το παράδειγμα αυτό εντοπίζει ένα τέτοιο διάγραμμα με βάση τόσο τον τύπο placeholder όσο και τον τύπο χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ένα γενικό placeholder περιεχομένου συνήθως έχει τον τύπο [PlaceholderType.Object](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholdertype/#Object). Στο PowerPoint λειτουργεί ως εκκινητής για πολλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και πολυμέσα. Αφού γεμίσει, εξετάστε τον πραγματικό τύπο σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType.Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholdertype/#Media), ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholdertype/#Diagram).

Το Aspose.Slides δεν μετατρέπει ένα κενό placeholder [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) σε [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/) απλώς αλλάζοντας το [Placeholder.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholder/#getType); ο τύπος δεν μπορεί να αλλάξει μέσω του API. Για να γεμίσετε ένα κενό διάγραμμα ή περιοχή περιεχομένου προγραμματιστικά, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και, στη συνέχεια, αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το προστιθέμενο διάγραμμα είναι ένα συνηθισμένο τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα διαχείρισης διαγραμμάτων [chart management articles](/slides/el/python-java/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του workbook.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, αναζητά στην πρώτη διαφάνεια είτε ένα placeholder τίτλου είτε εικόνας, ελέγχει τους τύπους του placeholder και του σχήματος, ενημερώνει το αντίστοιχο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα σκόπιμα αποφεύγει την υπόθεση για ευρετήριο σχήματος ή την αντιμετώπιση κάθε placeholder ως του ίδιου τύπου.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Τι είναι ένα base placeholder;**

Ένα base placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στο master από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [Shape.getBasePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getBasePlaceholder) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `None` επειδή δεν αποτελεί μέρος της ιεραρχίας των placeholders.

**Μπορώ να αλλάξω όλους τους τίτλους των διαφανειών επεξεργάζοντας ένα placeholder διάταξης;**

Μπορείτε να αλλάξετε την κληρονομημένη μορφοποίηση ή το κείμενο προτροπής μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε το πραγματικό κείμενο τίτλου σε ολόκληρη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο κατάλληλο επίπεδο διαφάνειας, διάταξης, master, σημειώσεων ή φυλλαδίου. Δείτε το [Manage Presentation Header and Footer](/slides/el/python-java/presentation-header-and-footer/) για πλήρη παραδείγματα.