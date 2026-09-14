---
title: Διαχείριση Κύριων Διαφανειών Παρουσίασης σε Python μέσω Java
linktitle: Κύριος Διαφάνειας
type: docs
weight: 70
url: /el/python-java/slide-master/
keywords:
- κύριος διαφάνειας
- κύρια διαφάνεια
- κύρια διαφάνεια PPT
- πολλαπλές κύριες διαφάνειες
- σύγκριση κύριων διαφανειών
- παρασκήνιο
- θέση κράτησης
- κλωνοποίηση κύριας διαφάνειας
- αντιγραφή κύριας διαφάνειας
- διπλασιασμός κύριας διαφάνειας
- αχρησιμοποίητη κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε τους κύριους διαφάνειας στο Aspose.Slides για Python μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση των κύριων διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **κύριος διαφάνειας** (slide master) ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιλαμβάνει κοινά σχήματα, λογότυπα, παρασκήνια, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός κύριου διαφάνειας είναι ο συνηθισμένος τρόπος να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides for Python via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες κύριες διαφάνειες, και κάθε κύρια διαφάνεια μπορεί να περιέχει αρκετές διαφάνειες διάταξης. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται άμεσα σε μια κύρια διαφάνεια. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διάταξης, η οποία ανήκει σε μια κύρια διαφάνεια.

Η ιεραρχία είναι:

1. **Κύριος διαφάνειας** – ορίζει το κοινό σχέδιο και θέμα.
1. **Διαφάνεια διάταξης** – ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης και μορφοποίηση επιπέδου διάταξης.
1. **Κανονική διαφάνεια** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μια διαφάνεια διάταξης.

![Η ιεραρχία των κύριων διαφανειών, διαφανειών διάταξης και κανονικών διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, ένας κύριος διαφάνειας αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/). Όλοι οι κύριοι διαφάνειες σε μια παρουσίαση είναι διαθέσιμοι μέσω της συλλογής [Presentation.getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasters), η οποία αντιπροσωπεύεται από την κλάση [MasterSlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο κερδίζει. Για παράδειγμα, αν μια κύρια διαφάνειας και μια διαφάνεια διάταξης ορίζουν το ίδιο παρασκήνιο, οι διαφάνειες που βασίζονται σε αυτή τη διάταξη χρησιμοποιούν το παρασκήνιο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τις διαφάνειες διάταξης, δείτε το [Apply or Change Slide Layouts](/slides/el/python-java/slide-layout/).

{{% /alert %}}

## **Πρόσβαση σε Κύριους Διαφάνειες**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Κύριου Διαφάνειας από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasters) για πρόσβαση στους κύριους διαφάνειες:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Μπορείτε επίσης να λάβετε τη κύρια διαφάνεια που χρησιμοποιείται από μια κανονική διαφάνεια μέσω της διάταξης της:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Τι Περιέχει ένας Κύριος Διαφάνειας**

Ένας κύριος διαφάνειας είναι ένα αντικείμενο τύπου διαφάνειας. Κληρονομεί από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/), επομένως εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από κανονικές και διαφάνειες διάταξης. Τα μέλη που αφορούν ειδικά τον κύριο διαφάνειας καταχωρούνται στη σελίδα API του [MasterSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/).

Τα συχνά χρησιμοποιούμενα μέλη του κύριου διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getBackground) | Ορίζει το παρασκήνιο επιπέδου κύριου διαφάνειας. |
| [getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getShapes) | Αποθηκεύει σχήματα που τοποθετούνται στον κύριο, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| [getLayoutSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getLayoutSlides) | Αποθηκεύει τις διαφάνειες διάταξης που ανήκουν στον κύριο. |
| [getThemeManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getThemeManager) | Παρέχει πρόσβαση στα API θέματος του κύριου. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για τον κύριο και τα θυγατρικά του σχέδια. |
| [getDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getDependingSlides) | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από τον κύριο μέσω των διατάξεών τους. |

## **Προσθήκη Εικόνας σε Κύριο Διαφάνειας**

Όταν προσθέτετε μια εικόνα σε έναν κύριο διαφάνειας, αυτή εμφανίζεται στις διαφάνειες που χρησιμοποιούν διατάξεις από αυτόν τον κύριο. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη κύρια διαφάνειας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε το [Picture Frame](/slides/el/python-java/picture-frame/).

## **Εργασία με Θέσεις Κράτησης (Placeholders)**

Οι θέσεις κράτησης ορίζονται συνήθως στις διαφάνειες διάταξης. Ο κύριος διαφάνειας παρέχει το κοινό στυλ και θέμα που κληρονομούν αυτές οι διατάξεις, ενώ κάθε διάταξη αποφασίζει ποιες θέσεις κράτησης είναι διαθέσιμες και πού τοποθετούνται.

Στο PowerPoint, οι εντολές θέσεων κράτησης είναι διαθέσιμες στην προβολή Κύριου Διαφάνειας.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέες θέσεις κράτησης με το Aspose.Slides, δουλέψτε με τη διαφάνεια διάταξης που ανήκει στον κύριο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Μπορείτε επίσης να μορφοποιήσετε σχήματα θέσεων κράτησης που ήδη υπάρχουν σε έναν κύριο διαφάνειας. Το παρακάτω παράδειγμα εντοπίζει τη θέση κράτησης τίτλου και εφαρμόζει γραμμικό διαβάθμιση γεμίσματος:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Μορφοποιημένη θέση κράτησης τίτλου που κληρονομείται από τις κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης θέσεων κράτησης και κειμένου, δείτε το [Set Prompt Text in Placeholder](/slides/el/python-java/manage-placeholder/) και το [Text Formatting](/slides/el/python-java/text-formatting/).

## **Αλλαγή Παρασκηνίου Κύριου Διαφάνειας**

Ένα κύριο παρασκήνιο κληρονομείται από τις διατάξεις και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα συμπαγές χρώμα παρασκηνίου για την πρώτη κύρια διαφάνειας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για συναφή θέματα, δείτε το [Presentation Background](/slides/el/python-java/presentation-background/) και το [Presentation Theme](/slides/el/python-java/presentation-theme/).

## **Κλωνοποίηση Κύριου Διαφάνειας σε Άλλη Παρουσίαση**

Χρησιμοποιήστε την μέθοδο [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/#addClone) για να αντιγράψετε έναν κύριο διαφάνειας σε άλλη παρουσίαση. Ο αντιγραμμένος κύριος μπορεί στη συνέχεια να χρησιμοποιηθεί από διατάξεις και διαφάνειες στην προορισμένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Αν χρειάζεστε κλωνοποίηση των κανονικών διαφανειών μαζί με τον κύριό τους, δείτε το [Clone Slides](/slides/el/python-java/clone-slides/).

## **Προσθήκη Πολλαπλών Κύριων Διαφανειών**

Μια παρουσίαση μπορεί να περιέχει πολλαπλούς κύριους διαφάνειες. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετικό branding, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση κύριων διαφανειών](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί τον προεπιλεγμένο κύριο, του δίνει διαφορετικό παρασκήνιο, δημιουργεί μια διάταξη κάτω από αυτόν τον κλωνοποιημένο κύριο και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτή τη διάταξη:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Σύγκριση Κύριων Διαφανειών**

Οι κύριοι διαφάνειες μπορούν να συγκριθούν με τη μέθοδο [equals](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#equals) που κληρονομείται από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινήσεις και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως τα ID διαφανειών, ή δυναμικές τιμές θέσεων κράτησης, όπως η τρέχουσα ημερομηνία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Για περισσότερες πληροφορίες, δείτε το [Compare Presentation Slides](/slides/el/python-java/compare-slides/).

## **Ορισμός Προβολής Κύριου Διαφάνειας ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#setLastView) στην κλάση [ViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει το PowerPoint πρώτα. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Κύριου Διαφάνειας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για περισσότερες ρυθμίσεις προβολής, δείτε το [Save Presentation](/slides/el/python-java/save-presentation/).

## **Κατάργηση Αχρησιμοποίητων Κύριων Διαφανειών**

Μερικές φορές οι παρουσιάσεις περιέχουν κύριους διαφάνειες που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση των αχρησιμοποίητων κύριων μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση προτύπων.

Χρησιμοποιήστε τη μέθοδο [removeUnused](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/#removeUnused) για να αφαιρέσετε αχρησιμοποίητους κύριους από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο χαμηλού κώδικα [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις (FAQ)**

**Ποια είναι η διαφορά μεταξύ ενός κύριου διαφάνειας και μιας διαφάνειας διάταξης;**

Ένας κύριος διαφάνειας ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, παρασκήνιο, κοινά σχήματα και στυλ κειμένου. Μια διαφάνεια διάταξης ανήκει σε έναν κύριο διαφάνειας και ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης. Μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διάταξης, επομένως κληρονομεί τόσο από τη διάταξη όσο και από τον κύριο.

**Μπορεί μια παρουσίαση να περιέχει πολλούς κύριους διαφάνειες;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλούς κύριους διαφάνειες. Χρησιμοποιήστε πολλούς κύριους όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή branding.

**Πρέπει να προσθέτω θέσεις κράτησης σε κύριο διαφάνειας ή σε διαφάνεια διάταξης;**

Στις περισσότερες περιπτώσεις, προσθέτετε θέσεις κράτησης σε διαφάνειες διάταξης. Τοποθετήστε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στον κύριο διαφάνειας, ενώ τις θέσεις κράτησης περιεχομένου τις τοποθετείτε στις διατάξεις που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω έναν κύριο διαφάνειας που εξακολουθεί να χρησιμοποιείται;**

Όχι. Ένας κύριος διαφάνειας που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια απευθείας. Πρώτα μετακινήστε τις διαφάνειες αυτές σε διατάξεις κάτω από άλλον κύριο, ή χρησιμοποιήστε μια μέθοδο καθαρισμού αχρησιμοποίητων κύριων που αφαιρεί μόνο τους κύριους που δεν είναι σε χρήση.