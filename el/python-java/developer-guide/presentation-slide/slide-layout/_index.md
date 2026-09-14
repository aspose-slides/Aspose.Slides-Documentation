---
title: Εφαρμογή ή Αλλαγή διατάξεων διαφάνειας σε Python μέσω Java
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/python-java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- θέση κράτησης
- σχεδίαση παρουσίασης
- σχεδίαση διαφάνειας
- αχρησιμοποίητη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- κεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κάθετο κείμενο
- κάθετος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για Python μέσω Java, προσθέστε θέσεις κράτησης, αφαιρέστε αχρησιμοποίητες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Μια διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των θέσεων κράτησης όπως τίτλους, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες μια συνεκτική δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συνηθισμένες διατάξεις περιλαμβάνουν:

- **Title Slide**: Διαφάνεια Τίτλου: Περιέχει θέσεις κράτησης τίτλου και υπότιτλου.
- **Title and Content**: Τίτλος και Περιεχόμενο: Περιέχει μια θέση κράτησης τίτλου και μια γενικής χρήσης θέση κράτησης περιεχομένου.
- **Blank**: Κενή: Δεν περιέχει θέσεις κράτησης περιεχομένου και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διατάξεων**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Μια [master slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα παρασκήνια και τα κοινά αντικείμενα.
1. Μια [layout slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/) ανήκει σε ένα master και ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης.
1. Μια [normal slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που έχει εισαχθεί για αυτή τη διαφάνεια.

Μια normal slide κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, και η διάταξη κληρονομεί από το master της. Μια τιμή που ορίζεται άμεσα σε μια normal slide αντικαθιστά την κληρονομημένη τιμή σε αυτό το επίπεδο. Όταν δημιουργείται μια normal slide, τα σχήματα θέσεων κράτησης δημιουργούνται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις θέσεις κράτησης ανήκει στη normal slide.

Προσθέστε τις απαιτούμενες θέσεις κράτησης σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας ακόμη θέσης κράτησης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα θέσης κράτησης στις υπάρχουσες normal slides.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της υπάρχουσας γεωμετρίας θέσεων κράτησης σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που χρησιμοποιείται ήδη, ελέγξτε τις διαφάνειες που εξαρτώνται από αυτήν και ελέγξτε την προκύπτουσα παρουσίαση.
- Μια διάταξη που χρησιμοποιείται ακόμα από κάποια διαφάνεια δεν μπορεί να αφαιρεθεί. Επαναπροσαρμόστε πρώτα τις εξαρτημένες διαφάνειες της σε άλλη διάταξη, ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε το [Slide Master](/slides/el/python-java/slide-master/).

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα διατάξεων μπορούν να επεξεργαστούν από τον χρήστη και να μεταφραστούν, επομένως η επιλογή βάσει ονόματος είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πηγαίο πρότυπο.

Το παρακάτω παράδειγμα ψάχνει για **Title and Content** στο πρώτο master. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει εκ προθέσεως στην **Blank**. Ο δεύτερος έλεγχος για `None` είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη στη συνέχεια εφαρμόζεται στην πρώτη normal slide μέσω της μεθόδου [Slide.setLayoutSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα απλά σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των θέσεων κράτησης, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υφιστάμενων θέσεων κράτησης και της νέας διάταξης μπορεί να αλλάξει, γι' αυτό ελέγξτε το αποτέλεσμα όταν μεταβαίνετε μεταξύ ουσιαστικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές ενέργειες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί καμία. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterlayoutslidecollection/#add) στη συλλογή διατάξεων του στόχου master.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια normal slide βασισμένη σε αυτήν. Τα ονόματα των διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Προσθέστε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια ακόμη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη κατάλληλη διάταξη, επιλέξτε την και επαναχρησιμοποιήστε την αντί να δημιουργήσετε αντίγραφο.

## **Προσθήκη Θέσεων Κράτησης σε Διάταξη Διαφάνειας**

Η μέθοδος [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getPlaceholderManager) παρέχει ένα [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/) για την προσθήκη σχημάτων θέσεων κράτησης σε μια διάταξη.

| PowerPoint Placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/) Method |
| ---------------------- | ---------------------------------- |
| ![Περιεχόμενο](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Περιεχόμενο (Κάθετο)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Κείμενο](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Κείμενο (Κάθετο)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Εικόνα](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Διάγραμμα](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Πίνακας](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Μέσα](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Το παρακάτω παράδειγμα ελέγχει εάν η διάταξη **Blank** υπάρχει, προσθέτει τέσσερις θέσεις κράτησης σε αυτήν και στη συνέχεια δημιουργεί μια normal slide που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι θέσεις κράτησης προστίθενται πριν δημιουργηθεί η normal slide, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα θέσεων κράτησης σε αυτήν τη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι θέσεις κράτησης στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υφιστάμενων θέσεων κράτησης της διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια πρόσφατα προστιθέμενη θέση κράτησης διάταξης δεν προστίθεται αυτόματα στις υπάρχουσες normal slides. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Αχρησιμοποίητων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία normal slide. Η μέθοδος αφήνει αμετάβλητες τις διατάξεις που εξακολουθούν να χρησιμοποιούνται.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, πρώτα χρησιμοποιήστε τη μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#hasDependingSlides) ή [getDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getDependingSlides). Επαναπροσαρμόστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε τη [LayoutSlide.remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#remove). Η προσπάθεια αφαίρεσης μιας χρησιμοποιημένης διάταξης προκαλεί μια [PptxEditException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη διαθέτει τις δικές της θέσεις κράτησης υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας‑ώρας. Χρησιμοποιήστε τη μέθοδο [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) για να ελέγξετε αυτές τις θέσεις κράτησης για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

Το παρακάτω παράδειγμα επιλέγει μια διάταξη με ασφάλεια και καθιστά τα στοιχεία υποσέλιδου ορατά:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος Ορατότητας Υποσέλιδου σε Master και στα Παιδικά του Διατάξεις**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε ολόκληρη την ιεραρχία ενός master, χρησιμοποιήστε τη μέθοδο [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Οι μέθοδοι διάδοσης του [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslideheaderfootermanager/) λειτουργούν στο master και στις εξαρτημένες διατάξεις και normal slides· δεν στοχεύουν μόνο μία normal slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Ποια είναι η διαφορά μεταξύ Master Slide και Layout Slide;**

Ένα master slide ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Ένα layout slide ανήκει σε ένα master και ορίζει μία επαναχρησιμοποιήσιμη διάταξη θέσεων κράτησης. Οι normal slides χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν περιεχόμενο ειδικό για κάθε διαφάνεια.

**Μπορώ να αντιγράψω ένα Layout Slide από μία παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/globallayoutslidecollection/#addClone). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η πηγαία διάταξη.

**Τι συμβαίνει όταν τροποποιώ μια διάταξη που χρησιμοποιείται ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης εκτός αν παρακάμπτουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των θέσεων κράτησης και η κληρονομημένη μορφοποίηση μπορούν επομένως να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [getDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getDependingSlides) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει εάν αφαιρέσω μια διάταξη που χρησιμοποιείται ακόμα;**

Το Aspose.Slides εγείρει μια [PptxEditException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxeditexception/). Επαναπροσαρμόστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε το [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε μόνο τις αδιαυγείς διατάξεις.