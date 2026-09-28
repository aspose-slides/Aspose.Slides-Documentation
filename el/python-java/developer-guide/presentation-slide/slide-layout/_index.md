---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε Python μέσω Java
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/python-java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- θέση κράτησης
- σχεδιασμός παρουσίασης
- σχεδιασμός διαφάνειας
- μη χρησιμοποιημένη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- επικεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κατακόρυφο κείμενο
- κατακόρυφος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για Python μέσω Java, προσθέστε θέσεις κράτησης, αφαιρέστε μη χρησιμοποιημένες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Ένα διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των κράτησης θέσης όπως τίτλοι, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες μια συνεπή δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Τα πιο κοινά διατάγματα περιλαμβάνουν:

- **Title Slide**: Περιέχει κράτησης θέσης τίτλου και υπότιτλου.
- **Title and Content**: Περιέχει κράτηση θέσης τίτλου και μια γενικής χρήσης κράτηση θέσης περιεχομένου.
- **Blank**: Δεν περιέχει κράτησης θέσεων περιεχομένου και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διατάξεων**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Μια [κύρια διαφάνεια](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα φόντα και τα κοινά αντικείμενα.
1. Μια [διάταξη διαφάνειας](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/) ανήκει σε μια κύρια και ορίζει μια συγκεκριμένη διάταξη των κρατήσεων θέσης.
1. Μια [κανονική διαφάνεια](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/) χρησιμοποιεί μια διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, και η διάταξη κληρονομεί από την κύρια. Μια τιμή που ορίζεται άμεσα σε μια κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή σε αυτό το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα κράτησης θέσης δημιουργούνται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις κρατήσεις θέσης ανήκει στη κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες κρατήσεις θέσης σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας άλλης κράτησης θέσης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα αντίστοιχο σχήμα κράτησης θέσης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπάρχουσων κρατήσεων θέσης σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που χρησιμοποιείται ήδη, ελέγξτε τις εξαρτημένες διαφάνειες και ανασκοπήστε το αποτέλεσμα.
- Μια διάταξη που χρησιμοποιείται ακόμα από μια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε το [Κύρια Διαφάνεια](/slides/el/python-java/slide-master/).

Για να κρύψετε κληρονομημένα λογότυπα ή διακοσμητικά σχήματα κύριας σε μια διαφάνεια ή μέσω κοινής διάταξης, δείτε το [Έλεγχος Ορατότητας Γραφικών Κύριας Διαφάνειας](/slides/el/python-java/slide-master/). Το παράδειγμα συγκρίνει δύο διαφάνειες που χρησιμοποιούν την ίδια κύρια.

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα των διατάξεων είναι επεξεργάσιμα από τον χρήστη και μπορούν να μεταφραστούν, οπότε η επιλογή με βάση το όνομα είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο πηγής.

Το παρακάτω παράδειγμα αναζητά **Title and Content** στην πρώτη κύρια. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επαναφέρει σκόπιμα σε **Blank**. Ο δεύτερος έλεγχος για `None` είναι αναγκαίος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της μεθόδου [Slide.setLayoutSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#setLayoutSlide).

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

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα κανονικά σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των κρατήσεων θέσης, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχουσών κρατήσεων θέσης και της νέας διάταξης μπορεί να αλλάξει, επομένως ελέγξτε το αποτέλεσμα όταν εναλλάσσετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές ενέργειες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί μια. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterlayoutslidecollection/#add) στη συλλογή διατάξεων του στοχευόμενου master.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, έπειτα προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα των διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

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

Προσθέτετε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια ακόμη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε και επαναχρησιμοποιήστε την αντί να δημιουργήσετε αντίγραφο.

## **Προσθήκη Κρατήσεων Θέσης σε Διάταξη Διαφάνειας**

Η μέθοδος [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getPlaceholderManager) παρέχει έναν [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/) για την προσθήκη σ shapes κράτησης θέσης σε μια διάταξη.

| PowerPoint Placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/) Method |
| ---------------------- | ---------------------------------- |
| ![Content](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Το παρακάτω παράδειγμα επαληθεύει ότι η διάταξη **Blank** υπάρχει, προσθέτει τέσσερις κρατήσεις θέσης σε αυτήν, και έπειτα δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι κρατήσεις θέσης προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σ shapes κράτησης θέσης σε αυτή τη διαφάνεια.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Προειδοποίηση" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπάρχουσων κρατήσεων θέσης σε μια διάταξη μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νεοσχηματισμένη κράτηση θέσης διάταξης δεν προστίθεται αυτόματα σε υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Αχρησιμοποίητων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητες τις διατάξεις που εξακολουθούν να χρησιμοποιούνται.

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

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, χρησιμοποιήστε πρώτα τη μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#hasDependingSlides) ή [getDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getDependingSlides). Αναθέστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε τη [LayoutSlide.remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#remove). Η προσπάθεια αφαίρεσης μιας χρησιμοποιούμενης διάταξης προκαλεί μια [PptxEditException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη έχει το δικό της υποσέλιδο, αριθμό διαφάνειας και κρατήσεις θέσης ημερομηνίας-ώρας. Χρησιμοποιήστε τη μέθοδο [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) για να ελέγξετε αυτές τις κρατήσεις θέσης για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

Το παρακάτω παράδειγμα επιλέγει με ασφάλεια μια διάταξη και κάνει τα στοιχεία υποσέλιδου της ορατά:

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Κύρια και τις Παράγοντες Διατάξεις της**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη την ιεραρχία μιας κύριας, χρησιμοποιήστε τη μέθοδο [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Οι μέθοδοι διάδοσης του [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslideheaderfootermanager/) λειτουργούν στην κύρια και στις εξαρτημένες διατάξεις διαφάνειας και στις κανονικές διαφάνειες· δεν στοχεύουν μόνο μία κανονική διαφάνεια.

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

## **Συχνές Ερωτήσεις**

**Τι Διαφορά Υπάρχει Μεταξύ Κύριας Διαφάνειας και Διάταξης Διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το θέμα και τη κοινή μορφοποίηση της παρουσίασης. Μια διάταξη διαφάνειας ανήκει σε μια κύρια και ορίζει μία επαναχρησιμοποιήσιμη διάταξη κρατήσεων θέσης. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το περιεχόμενο της διαφάνειας.

**Μπορώ Να Αντιγράψω Μια Διάταξη Διαφάνειας Από Μια Παρουσίαση Σε Άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/globallayoutslidecollection/#addClone). Όταν αντιγράφετε μεταξύ παρουσιάσεων, επαληθεύστε επίσης γραμματοσειρές, θέματα, εικόνες και άλλους πόρους που χρησιμοποιεί η πηγή διάταξης.

**Τι Συμβαίνει Όταν Τροποποιήσω Μια Διάταξη Που Χρησιμοποιείται Ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές διάταξης εκτός εάν παρακάμψουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των κρατήσεων θέσης και η κληρονομημένη μορφή μπορούν έτσι να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε τη [getDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getDependingSlides) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι Συμβαίνει Αν Αφαιρέσω Μια Διάταξη Που Είναι Ακόμη Σε Χρήση;**

Το Aspose.Slides προκαλεί μια [PptxEditException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε τη [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε μόνο τις αχρησιμοποίητες διατάξεις.