---
title: Διαχείριση slide master παρουσίασης σε Python μέσω Java
linktitle: Κύρια διαφάνεια
type: docs
weight: 70
url: /el/python-java/slide-master/
keywords:
- master διαφάνειας
- master διαφάνεια
- master διαφάνεια PPT
- πολλαπλές master διαφάνειες
- σύγκριση master διαφανειών
- φόντο
- θέση κράτησης
- κλωνοποίηση master διαφάνειας
- αντιγραφή master διαφάνειας
- δημιουργία διπλότυπου master διαφάνειας
- αχρησιμοποίητη master διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχείριση master slides στο Aspose.Slides για Python μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιλαμβάνει κοινά σχήματα, λογότυπα, φόντο, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνηθισμένος τρόπος για να διατηρείται μια παρουσίαση συνεπής χωρίς την επανάληψη της ίδιας μορφοποίησης σε κάθε διαφάνεια.

Το Aspose.Slides for Python via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες master slides, και κάθε master slide μπορεί να περιέχει αρκετές layout slides. Οι κανονικές διαφάνειες δεν αναφέρονται συνήθως απευθείας σε μια master slide. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια layout slide, η οποία ανήκει σε μια master slide.

Η ιεραρχία είναι:

1. **Slide master** - ορίζει το κοινό σχεδιασμό και το θέμα.
1. **Layout slide** - ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης και μορφοποίησης επιπέδου διάταξης.
1. **Normal slide** - περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία layout slide.

![Η ιεραρχία των master slides, layout slides και normal slides](slide-master_2.jpg)

Στο Aspose.Slides, ένα slide master αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/). Όλες οι master slides σε μια παρουσίαση είναι διαθέσιμες μέσω της συλλογής [Presentation.getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasters), η οποία αντιπροσωπεύεται από την [MasterSlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερο από ένα επίπεδο, το πιο συγκεκριμένο επίπεδο έχει προτεραιότητα. Για παράδειγμα, εάν μια master slide και μια layout slide ορίζουν και οι δύο ένα φόντο, οι διαφάνειες που βασίζονται σε αυτή τη διάταξη χρησιμοποιούν το φόντο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τις layout slides, δείτε [Apply or Change Slide Layouts](/slides/el/python-java/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Slide Master από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasters) για να αποκτήσετε πρόσβαση στις master slides:

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

Μπορείτε επίσης να λάβετε τη master slide που χρησιμοποιείται από μια normal slide μέσω της διάταξής της:

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

## **Τι Περιέχει ένα Slide Master**

Ένα master slide είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Κληρονομεί από το [BaseSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/), έτσι εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από κανονικές και layout διαφάνειες. Τα ειδικά μέλη του master αναφέρονται στη σελίδα API [MasterSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/).

Τα πιο συχνά χρησιμοποιούμενα μέλη του master slide περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getBackground) | Ορίζει το φόντο της διαφάνειας σε επίπεδο master. |
| [getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getShapes) | Αποθηκεύει τα σχήματα που τοποθετούνται στο master, όπως λογότυπα, πλαίσια εικόνων και κοινό κείμενο. |
| [getLayoutSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getLayoutSlides) | Αποθηκεύει τις layout slides που ανήκουν στο master. |
| [getThemeManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getThemeManager) | Παρέχει πρόσβαση στα API του θέματος του master. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Διαχειρίζεται τα κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για το master και τις θυγατρικές του διατάξεις. |
| [getDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getDependingSlides) | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από το master μέσω των διατάξεών τους. |

## **Προσθήκη Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε μια master slide, εμφανίζεται στις διαφάνειες που χρησιμοποιούν διατάξεις από αυτό το master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφίες, διακοσμητικές ταινίες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη master slide:

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

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνων, δείτε [Picture Frame](/slides/el/python-java/picture-frame/).

## **Έλεγχος Ορατότητας Γραφικών Master**

Χρησιμοποιήστε το [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#setShowMasterShapes) για να κρύψετε κληρονομικά γραφικά master, όπως λογότυπα ή διακοσμητικά σχήματα, χωρίς να τα διαγράψετε από το master. Περάστε `False` στο [Slide.setShowMasterShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#setShowMasterShapes) στη διαφάνεια που πρέπει να παραλείψει αυτά τα γραφικά και κρατήστε το `True` στις διαφάνειες που πρέπει να τα εμφανίσει.

Το παρακάτω αυτόνομα παράδειγμα δημιουργεί μια μπλε διακοσμητική ταινία σε ένα master και δύο διαφάνειες που χρησιμοποιούν την ίδια κενή διάταξη. Η ταινία είναι ορατή στην πρώτη διαφάνεια και κρυφή στη δεύτερη. Δεν απαιτείται εισαγωγική παρουσίαση ή εικόνα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το παράδειγμα χρησιμοποιεί τη διάταξη **Blank** που παρέχεται με μια νέα παρουσίαση και αφαιρεί τις δικές της θέσεις κράτησης της αρχικής διαφάνειας.

### **Επιλογή Εύρους Ρύθμισης**

Μια normal slide χρησιμοποιεί το master της μέσω του [Slide.getLayoutSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getLayoutSlide) και του [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getMasterSlide). Ο ορισμός της ιδιότητας σε μια μεμονωμένη διαφάνεια επηρεάζει μόνο αυτή τη διαφάνεια. Περνώντας `False` στο [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#setShowMasterShapes) κρύβει τα γραφικά master για διαφάνειες που χρησιμοποιούν αυτή τη κοινή διάταξη, ακόμη κι αν η δική τους ρύθμιση είναι `True`. Για να κρύψετε γραφικά μόνο σε μία διαφάνεια, αλλάξτε την ιδιότητα της διαφάνειας και αφήστε τη κοινή διάταξη αμετάβλητη.

Η ρύθμιση δεν υποστηρίζεται ως έλεγχος ορατότητας στη ίδια τη master slide. Σε μια master, το [getShowMasterShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getShowMasterShapes) πάντα επιστρέφει `False` και περνώντας `True` στο [setShowMasterShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#setShowMasterShapes) προκαλεί εξαίρεση. Εφαρμόστε τη σε μια normal slide ή σε μια διάταξη αντί αυτού.

### **Διαχωρισμός Γραφικών από το Φόντο**

| Λειτουργία | Αποτέλεσμα |
| --- | --- |
| Απόκρυψη γραφικών master | Ελέγχει την ορατότητα των κληρονομικών σχήματων master χωρίς να τα διαγράψει ή να αλλάξει τα δικά σχήματα της διαφάνειας. |
| Αλλαγή γεμίσματος φόντου διαφάνειας | Αλλάζει το χρώμα, το gradient ή την εικόνα του φόντου. Τα γραφικά master είναι ξεχωριστά σχήματα και μπορούν να παραμείνουν ορατά πάνω από αυτό το φόντο. Δείτε το [Presentation Background](/slides/el/python-java/presentation-background/). |
| Διαγραφή σχήματος από το master | Αφαιρεί το κοινό σχήμα-προέλευση, έτσι δεν είναι πλέον διαθέσιμο σε καμία διαφάνεια που χρησιμοποιεί αυτό το master. |

## **Εργασία με Θέσεις Κράτησης**

Οι θέσεις κράτησης ορίζονται συνήθως σε layout slides. Η master slide παρέχει το κοινό στυλ και θέμα που κληρονομούν αυτές οι διατάξεις, ενώ κάθε διάταξη αποφασίζει ποιες θέσεις κράτησης είναι διαθέσιμες και πού τοποθετούνται.

Στο PowerPoint, οι εντολές θέσεων κράτησης είναι διαθέσιμες στην προβολή Slide Master.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέες θέσεις κράτησης με το Aspose.Slides, εργαστείτε με την layout slide που ανήκει στο master:

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

Μπορείτε επίσης να μορφοποιήσετε σχήματα θέσεων κράτησης που ήδη υπάρχουν σε μια master slide. Το παρακάτω παράδειγμα εντοπίζει τη θέση κράτησης τίτλου και εφαρμόζει ένα γραμμικό gradient fill:

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

![Τίτλος θέση κράτησης μορφοποιημένος που κληρονομείται από κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης θέσεων κράτησης και κειμένου, δείτε [Set Prompt Text in Placeholder](/slides/el/python-java/manage-placeholder/) και [Text Formatting](/slides/el/python-java/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Το φόντο ενός master κληρονομείται από τις διατάξεις και τις διαφάνειες που δεν το αντικαθιστούν. Το παρακάτω παράδειγμα ορίζει ένα σταθερό χρώμα φόντου για την πρώτη master slide:

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

Για συναφή θέματα, δείτε [Presentation Background](/slides/el/python-java/presentation-background/) και [Presentation Theme](/slides/el/python-java/presentation-theme/).

## **Κλωνοποίηση Slide Master σε Άλλη Παρουσίαση**

Χρησιμοποιήστε το [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/#addClone) για να αντιγράψετε μια master slide σε άλλη παρουσίαση. Η αντιγραμμένη master μπορεί στη συνέχεια να χρησιμοποιηθεί από διατάξεις και διαφάνειες στην προορισμένη παρουσίαση.

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

Αν χρειάζεστε κλωνοποίηση κανονικών διαφανειών μαζί με το master τους, δείτε [Clone Slides](/slides/el/python-java/clone-slides/).

## **Προσθήκη Πολλαπλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλαπλές master slides. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετική επωνυμία, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση master slides](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί το προεπιλεγμένο master, δίνει στο κλώνο διαφορετικό φόντο, δημιουργεί μια διάταξη κάτω από αυτό το κλωνοποιημένο master και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτή τη διάταξη:

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

## **Σύγκριση Slide Masters**

Οι master slides μπορούν να συγκριθούν με τη μέθοδο [equals](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#equals) που κληρονομείται από το [BaseSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινούμενα σχέδια και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως IDs διαφανειών, ή δυναμικές τιμές θέσεων κράτησης, όπως η τρέχουσα ημερομηνία.

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

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/slides/el/python-java/compare-slides/).

## **Ορισμός Προβολής Slide Master ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#setLastView) στο [ViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Slide Master:

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

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/slides/el/python-java/save-presentation/).

## **Αφαίρεση Μη Χρησιμοποιούμενων Master Slides**

Οι παρουσιάσεις μερικές φορές περιέχουν master slides που δεν χρησιμοποιούνται πλέον από καμία normal slide. Η αφαίρεση των μη χρησιμοποιούμενων masters μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε το [removeUnused](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/#removeUnused) για να αφαιρέσετε τους μη χρησιμοποιούμενους masters από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasters):

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

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

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

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ slide master και layout slide;**

Ένα slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια layout slide ανήκει σε μια master slide και ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης. Μια normal slide χρησιμοποιεί μια layout slide, έτσι κληρονομεί τόσο από τη διάταξη όσο και από το master.

**Μπορεί μια παρουσίαση να περιέχει πολλά slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλά slide masters. Χρησιμοποιήστε πολλαπλά masters όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή επωνυμία.

**Πρέπει να προσθέσω θέσεις κράτησης σε master slide ή σε layout slide;**

Στις περισσότερες περιπτώσεις, προσθέστε θέσεις κράτησης σε layout slides. Τοποθετήστε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στη master slide, και έπειτα τοποθετήστε τις θέσεις κειμένου στις διατάξεις που θα χρησιμοποιούν οι normal slides.

**Μπορώ να διαγράψω μια master slide που είναι ακόμη σε χρήση;**

Όχι. Μια master slide που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια απευθείας. Πρώτα μετακινήστε αυτές τις διαφάνειες σε διατάξεις κάτω από άλλο master, ή χρησιμοποιήστε μια μέθοδο καθαρισμού μη χρησιμοποιούμενων masters που αφαιρεί μόνο masters που δεν χρησιμοποιούνται.