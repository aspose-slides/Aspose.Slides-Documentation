---
title: Διαχείριση Placeholder Παρουσίασης σε Python
linktitle: Διαχείριση Placeholder
type: docs
weight: 10
url: /el/python-java/manage-placeholder/
keywords:
- πλαίσιο κράτησης
- πλαίσιο κειμένου
- πλαίσιο εικόνας
- πλαίσιο διαγράμματος
- πλαίσιο περιεχομένου
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να ελέγχετε και να επεξεργάζεστε πλαίσια κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομικότητα των placeholders με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένας χώρος κράτησης είναι ένα σχήμα που διατηρεί μια θέση για ένα συγκεκριμένο τύπο περιεχομένου σε ένα πρότυπο παρουσίασης. Συνήθη παραδείγματα είναι οι χώροι κράτησης τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένας χώρος κράτησης μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή κύριας διαφάνειας.

Η Aspose.Slides εκθέτει πληροφορίες σχετικά με το placeholder μέσω της μεθόδου [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). Η μέθοδος επιστρέφει ένα αντικείμενο [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) ή `None` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) για να καθορίσετε τι προορίζεται να περιέχει το placeholder.

Ο τύπος του σχήματος εξακολουθεί να έχει σημασία μετά τη γνώση του τύπου του placeholder:

- Ένα κενό placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου συνήθως αντιπροσωπεύεται από ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Ένα γεμάτο placeholder εικόνας μπορεί να αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Ένα placeholder περιεχομένου μπορεί να περιέχει αρκετούς τύπους περιεχομένου. Ελέγξτε τόσο το [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) όσο και τον τύπο σχήματος κατά το χρόνο εκτέλεσης, αντί να υποθέτετε ότι κάθε placeholder είναι ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) περιγράφει το ρόλο του placeholder· δεν εγγυάται τον τύπο σχήματος κατά το χρόνο εκτέλεσης. Πάντα να κάνετε έλεγχο τύπου πριν προσπελάσετε τα μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή ειδικά για μέσον.
{{% /alert %}}

## **Κατανόηση Κληρονομικότητας Placeholder**

Τα placeholders σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders επιπέδου master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από το master.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για αυτή τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) για να μετακινηθείτε ένα επίπεδο επάνω σε αυτήν την ιεραρχία. Ένα placeholder διαφάνειας συνήθως επιστρέφει το placeholder της διάταξής του· ένα placeholder διάταξης μπορεί να επιστρέψει το placeholder του master. Η μέθοδος επιστρέφει `None` όταν το σχήμα δεν έχει βασικό placeholder.

Το παρακάτω παράδειγμα καταλογίζει τα placeholders στην πρώτη διαφάνεια και αναφέρει τα βασικά τους placeholders:

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

Η επεξεργασία ενός placeholder σε μια κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική παράκαμψη για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή του master μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό placeholder και δεν αρχίζει να κληρονομεί απλώς επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αφαίρεση Κατάστασης Placeholder**

Κατά την προσαρμογή ενός προτύπου, χρησιμοποιήστε το [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) για να διατηρήσετε ένα υπάρχον αντικείμενο ως ένα συνηθισμένο σχήμα. Η μέθοδος του [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) επιστρέφει `None`, αλλά το σχήμα παραμένει στη συλλογή της διαφάνειας. Αντίθετα, το [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) διαγράφει το σχήμα από εκείνη τη συλλογή.

Το παρακάτω παράδειγμα απαιτεί το `template.pptx` με τουλάχιστον μία διαφάνεια και ένα μη κενό placeholder κειμένου στην πρώτη διαφάνεια. Χρησιμοποιήστε ένα placeholder με μορφοποίηση που κληρονομείται από τη διάταξη ή το master για να δείτε το αποτέλεσμα της αφαίρεσης αυτής της σχέσης. Το παράδειγμα ελέγχει ότι το ίδιο σχήμα παραμένει, καλεί ξανά τη μέθοδο στο πλέον συνηθισμένο σχήμα, και αποθηκεύει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Η αφαίρεση της κατάστασης placeholder δεν διατηρεί αυτόματα τις κληρονομημένες ρυθμίσεις εμφάνισης. Το παρακάτω παράδειγμα αφήνει σκόπιμα αυτές τις ρυθμίσεις αμετάβλητες, έτσι η έξοδος μπορεί να φαίνεται διαφορετική. Ένα σχήμα του οποίου η θέση και το μέγεθος κληρονομούνται πλήρως μπορεί, μετά την κλήση, να έχει συντεταγμένες και διαστάσεις μηδενικές και να γίνει αόρατο παρόλο που παραμένει στη συλλογή.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Η κλήση της μεθόδου σε ένα κανονικό σχήμα δεν έχει καμία επίδραση.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Για ένα ταιριαστό placeholder, και οι τρεις έλεγχοι εμφανίζουν `True`. Το κείμενο παραμένει, αλλά η κληρονομημένη θέση, μέγεθος, περιστροφή, γραμματοσειρά, στοίχιση παραγράφου, περιθώρια πλαισίου κειμένου, κατακόρυφη αγκύρωση, γεμίσματα και ρυθμίσεις γραμμής μπορούν να αλλάξουν όταν η σχέση του placeholder αφαιρεθεί. Για παράδειγμα, η κληρονομημένη μορφοποίηση τίτλου μπορεί να επιστρέψει στην απλή μορφοποίηση κειμένου. Δείτε το [Slide Layout](/slides/el/python-java/slide-layout/) για περισσότερα σχετικά με τις διατάξεις.

Για να διατηρήσετε την επιθυμητή εμφάνιση, καταγράψτε τη λύση θέση, μέγεθος και περιστροφή πριν την κλήση και αντιγράψτε τις απαιτούμενες τιμές αποτελεσματικής μορφοποίησης σε ξεχωριστές μεταβλητές. Ανακτήστε αυτές τις τιμές μέσω των [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) και [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Μην βασίζεστε μόνο στα αντικείμενα αποτελεσματικής μορφοποίησης, επειδή οι τιμές μορφοποίησης κειμένου τους μπορούν να αλλάξουν μετά την αφαίρεση της σχέσης. Εφαρμόστε ρητά τις καταγεγραμμένες τιμές στο συνηθισμένο σχήμα μετά, συμπεριλαμβανομένου της οικογένειας γραμματοσειράς, μεγέθους, στυλ, χρώματος, ρυθμίσεων παραγράφου, ρυθμίσεων πλαισίου κειμένου, γεμίσματος και γραμμής που χρησιμοποιεί το πρότυπό σας.

Η κληρονομημένη γεωμετρία σχήματος μπορεί επίσης να χρειαστεί να οριστεί ρητά μέσω του [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Για ένα ορθογώνιο placeholder κειμένου, αυτό σημαίνει την ανάθεση του [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); η επαναφορά μόνο του γεμίσματος και της γραμμής ενδέχεται να μην αποκαταστήσει το ορατό ορθογώνιο. Πρότυπα με πρόσθετα εφέ ή πιο σύνθετη μορφοποίηση απαιτούν επίσης τη διαχείριση αυτών των ρυθμίσεων.

## **Αλλαγή Κειμένου σε Placeholder**

Τα placeholders τίτλου, κεντραρισμένου τίτλου, υποτίτλου, σώματος και κειμένου συνήθως υποστηρίζουν κείμενο. Ελέγξτε για ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) πριν χρησιμοποιήσετε τη μέθοδό του [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame).

Αυτό το παράδειγμα ενημερώνει το πρώτο placeholder τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

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

Αυτό το μοτίβο αποφεύγει την αντιμετώπιση των placeholders εικόνας, διαγράμματος, πίνακα ή μέσου ως [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Επίσης, προσδιορίζει το placeholder βάσει του σκοπού του αντί να στηρίζεται σε έναν ευάλωτο δείκτη σχήματος.

## **Ορισμός Κειμένου Prompt σε Διάταξη**

Το κείμενο prompt είναι η οδηγία στην ώρα του σχεδιασμού που εμφανίζεται σε ένα κενό placeholder, όπως *Κάντε κλικ για να προσθέσετε τίτλο*. Ορίστε προσαρμοσμένο κείμενο prompt στο placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ shapes μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) και επανάληψη στη συλλογή που επιστρέφεται από το [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

Το παρακάτω παράδειγμα αλλάζει τα prompts τίτλου και υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

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

Το κείμενο prompt δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παράσχει πραγματικό περιεχόμενο, το prompt δεν εμφανίζεται πλέον. Η αλλαγή ενός prompt επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις προς διαχείριση:

- Αν το placeholder εικόνας είναι ήδη γεμάτο και αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), αντικαταστήστε την εικόνα μέσω του [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) και του [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Αν είναι ακόμη κενό placeholder, προσθέστε ένα picture frame στις συντεταγμένες του placeholder με το [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) και αφαιρέστε το κενό placeholder.

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

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό picture frame, όχι ένα νέο placeholder, επειδή το [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συγκεκριμένη συμπεριφορά του placeholder. Εάν η διατήρηση της σχέσης placeholder είναι απαραίτητη, προετοιμάστε και γεμίστε το placeholder στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτον [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνα, δείτε το [Manage Picture Frames](/slides/el/python-java/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο picture frame ή στο picture fill, όχι στα μεταδεδομένα του placeholder.

## **Εργασία με Placeholders Διαγράμματος και Περιεχομένου**

Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Αυτό το παράδειγμα βρίσκει τέτοιο διάγραμμα και από τον τύπο placeholder και τον τύπο χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

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

Ένα γενικό placeholder περιεχομένου συνήθως έχει [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). Στο PowerPoint λειτουργεί ως εκκινητής για πολλούς τύπους περιεχομένου, συμπεριλαμβανομένων διαγραμμάτων, πινάκων, διαγραμμάτων ροής, εικόνων και μέσων. Αφού γεμίσει, εξετάστε τον πραγματικό τύπο σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

Η Aspose.Slides δεν μετατρέπει ένα κενό placeholder [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) σε ένα [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) απλώς αλλάζοντας το [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType); ο τύπος δεν μπορεί να αλλάξει μέσω του API. Για να γεμίσετε ένα κενό διάγραμμα ή περιοχή περιεχομένου προγραμματιστικά, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και στη συνέχεια αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

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

Το προστιθέμενο διάγραμμα είναι ένα συνηθισμένο τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα διαχείρισης διαγραμμάτων [chart management articles](/slides/el/python-java/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω παράδειγμα από άκρη σε άκρη ανοίγει ένα πρότυπο, αναζητά στην πρώτη διαφάνεια είτε ένα placeholder τίτλου είτε εικόνας, ελέγχει τους τύπους του placeholder και του σχήματος, ενημερώνει το κατάλληλο περιεχόμενο, και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα την υπόθεση ενός δείκτη σχήματος ή την αντιμετώπιση κάθε placeholder ως του ίδιου τύπου.

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

## **Συχνές Ερωτήσεις**

**Τι είναι ένα βασικό placeholder;**

Ένα βασικό placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στο master από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `None` επειδή δεν αποτελεί μέρος της ιεραρχίας των placeholders.

**Μπορώ να αλλάξω όλους τους τίτλους διαφάνειας επεξεργάζοντάς μου ένα placeholder διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομημένη μορφοποίηση ή το κείμενο prompt μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε το πραγματικό κείμενο τίτλου σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο κατάλληλο επίπεδο διαφάνειας, διάτασης, master, σημειώσεων ή χειροδίου. Δείτε το [Manage Presentation Header and Footer](/slides/el/python-java/presentation-header-and-footer/) για πλήρη παραδείγματα.