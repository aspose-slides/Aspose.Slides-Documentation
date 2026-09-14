---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε Python μέσω Java
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/python-java/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδιο
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζετε τις ετικέτες υποσέλιδου, ημερομηνίας‑ώρας, αριθμού διαφάνειας και κεφαλίδας σε διαφάνειες, σελίδες σημειώσεων και φυλλάδια με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Το PowerPoint χρησιμοποιεί διαφορετικά πεδία κράτησης κεφαλίδας και υποσέλιδου ανάλογα με τον τύπο της σελίδας. Το Aspose.Slides για Python μέσω Java σας επιτρέπει να ελέγχετε το κείμενο και την ορατότητα αυτών των πεδίων μέσω των κλάσεων διαχειριστών κεφαλίδας/υποσέλιδου.

Τα διαθέσιμα πεδία εξαρτώνται από το εύρος:

| Εύρος | Κεφαλίδα | Υποσέλιδο | Ημερομηνία/Ώρα | Αριθμός διαφάνειας/σελίδας |
|---|---|---|---|---|
| Regular slide | Όχι | Ναι | Ναι | Ναι |
| Notes master | Ναι | Ναι | Ναι | Ναι |
| Notes slide | Ναι | Ναι | Ναι | Ναι |
| Handout master | Ναι | Ναι | Ναι | Ναι |

Μια κανονική διαφάνεια παρουσίασης δεν έχει πεδίο κράτησης κεφαλίδας. Οι κεφαλίδες είναι διαθέσιμες σε σελίδες σημειώσεων και φυλλάδια. Για κανονικές διαφάνειες, χρησιμοποιήστε τα πεδία κράτησης υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας.

Το εύρος μιας αλλαγής εξαρτάται από το διαχειριστή που χρησιμοποιείτε. Η κλάση [SlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideheaderfootermanager/) ελέγχει μία κανονική διαφάνεια. Η κλάση [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/notesslideheaderfootermanager/) ελέγχει μία διαφάνεια σημειώσεων. Οι διαχειριστές master και layout μπορούν επίσης να διαδώσουν τις ρυθμίσεις σε εξαρτημένες διαφάνειες, ενώ η κλάση [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) ελέγχει το handout master.

## **Ορισμός Υποσέλιδου, Ημερομηνίας/Ώρας και Αριθμών Διαφανειών σε Κανονικές Διαφάνειες**

Για κανονικές διαφάνειες, η βασική ροή εργασίας είναι να αποκτήσετε πρόσβαση στον διαχειριστή κεφαλίδας/υποσέλιδου της κάθε διαφάνειας, να ορίσετε το κείμενο του υποσέλιδου και της ημερομηνίας/ώρας, να ενεργοποιήσετε τα απαιτούμενα πεδία και να αποθηκεύσετε την παρουσίαση. Οι αριθμοί διαφανειών δημιουργούνται αυτόματα από την παρουσίαση, επομένως χρειάζεται μόνο να ελέγξετε την ορατότητά τους.

Χρησιμοποιήστε [setFooterText](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) και [setDateTimeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) για να ορίσετε κείμενο, και χρησιμοποιήστε [setFooterVisibility](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) και [setSlideNumberVisibility](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) για να εμφανίσετε τα αντίστοιχα πεδία.

Το παρακάτω παράδειγμα εφαρμόζει το ίδιο υποσέλιδο, κείμενο ημερομηνίας/ώρας και ορατότητα αριθμού διαφάνειας σε όλες τις κανονικές διαφάνειες:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αν χρειάζεται να ενημερώσετε μόνο μία διαφάνεια, αποκτήστε πρόσβαση σε αυτήν απευθείας μέσω της μεθόδου [getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) αντί να διατρέξετε ολόκληρη τη συλλογή.

## **Ορισμός Κεφαλίδων και Υποσέλιδων στο Notes Master**

Ο notes master ορίζει κοινή μορφοποίηση και συμπεριφορά πεδίων για τις σελίδες σημειώσεων. Χρησιμοποιήστε την κλάση [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/) όταν θέλετε να αλλάξετε μόνο τον ίδιο τον notes master.

Το παρακάτω παράδειγμα ορίζει κεφαλίδα, υποσέλιδο και κείμενο ημερομηνίας/ώρας στο notes master και κάνει όλα τα υποστηριζόμενα πεδία ορατά σε αυτόν τον master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η μέθοδος `getMasterNotesSlide` επιστρέφει `None` όταν η παρουσίαση δεν περιέχει notes master.

## **Εφαρμογή Ρυθμίσεων Notes Master σε Παράγωγες Διαφάνειες Σημειώσεων**

Ένας notes master μπορεί να εφαρμόσει ρυθμίσεις κεφαλίδας και υποσέλιδου στον εαυτό του και σε όλες τις εξαρτημένες διαφάνειες σημειώσεων. Χρησιμοποιήστε τις ειδικές μεθόδους διάδοσης στην κλάση [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/) όταν οι ίδιες ρυθμίσεις πρέπει να εφαρμοστούν σε όλο το ιεραρχικό δέντρο των σημειώσεων.

Για παράδειγμα, οι μέθοδοι [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) και [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) ενημερώνουν την κεφαλίδα του notes master και όλες τις παιδικές κεφαλίδες. Παρόμοιες μέθοδοι είναι διαθέσιμες για υποσέλιδα, ημερομηνία/ώρα και αριθμούς διαφανειών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Οι μέθοδοι διάδοσης που χρησιμοποιήθηκαν παραπάνω είναι [setFooterAndChildFootersText](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) και [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Ορισμός Κεφαλίδων και Υποσέλιδων σε Ατομική Διαφάνεια Σημειώσεων**

Μια διαφάνεια σημειώσεων ανήκει σε συγκεκριμένη κανονική διαφάνεια. Χρησιμοποιήστε την κλάση [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/notesslideheaderfootermanager/) όταν θέλετε να προσαρμόσετε μόνο αυτή τη σελίδα σημειώσεων.

Η μέθοδος [addNotesSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/notesslidemanager/#addNotesSlide) επιστρέφει τη διαφάνεια σημειώσεων για την τρέχουσα διαφάνεια και τη δημιουργεί εάν δεν υπάρχει ήδη. Το παρακάτω παράδειγμα διαμορφώνει τη σελίδα σημειώσεων που συνδέεται με την πρώτη διαφάνεια παρουσίασης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αν πρώτα διαδώσετε ρυθμίσεις από τον notes master και, στη συνέχεια, αλλάξετε μια ατομική διαφάνεια σημειώσεων, οι μεταγενέστερες ρυθμίσεις ανά διαφάνεια σας επιτρέπουν να προσαρμόσετε αυτή τη σελίδα σημειώσεων ανεξάρτητα.

## **Ορισμός Κεφαλίδων και Υποσέλιδων στο Handout Master**

Οι σελίδες φυλλαδίου χρησιμοποιούν το handout master για τα πεδία κεφαλίδας, υποσέλιδου, ημερομηνίας/ώρας και αριθμού σελίδας. Σε αντίθεση με τις σελίδες σημειώσεων, οι ρυθμίσεις του φυλλαδίου διαχειρίζονται μέσω του handout master και όχι μέσω των μεμονωμένων σελίδων φυλλαδίου.

Χρησιμοποιήστε τη μέθοδο `getMasterHandoutSlide` για πρόσβαση στο handout master. Εάν δεν υπάρχει, καλέστε `setDefaultMasterHandoutSlide` για να δημιουργήσετε το προεπιλεγμένο handout master.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κατανόηση Εύρους και Κληρονομικότητας**

Επιλέξτε τον διαχειριστή κεφαλίδας/υποσέλιδου που ταιριάζει με το εύρος που θέλετε να αλλάξετε:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideheaderfootermanager/) αλλάζει ρυθμίσεις υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας για μία κανονική διαφάνεια.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslideheaderfootermanager/) ελέγχει μια διαφάνεια διάταξης και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslideheaderfootermanager/) ελέγχει έναν κανονικό master διαφάνειας και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslideheaderfootermanager/) ελέγχει το notes master και μπορεί να διαδώσει ρυθμίσεις σε όλες τις εξαρτημένες διαφάνειες σημειώσεων.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/notesslideheaderfootermanager/) αλλάζει μία διαφάνεια σημειώσεων και υποστηρίζει πεδίο κεφαλίδας επιπλέον του υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) αλλάζει το handout master και υποστηρίζει και τους τέσσερις τύπους πεδίων.

Χρησιμοποιήστε διάδοση από έναν master ή layout όταν η ίδια ρύθμιση πρέπει να ισχύει σε όλη τη ιεραρχία του. Χρησιμοποιήστε έναν ατομικό διαχειριστή διαφάνειας ή notes‑slide όταν χρειάζεστε τοπική ρύθμιση για μία σελίδα.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσθέσω κεφαλίδα σε κανονική διαφάνεια;**

Όχι. Το PowerPoint δεν ορίζει πεδίο κεφαλίδας για κανονικές διαφάνειες. Σε κανονικές διαφάνειες, χρησιμοποιήστε τα πεδία υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας. Τα πεδία κεφαλίδας είναι διαθέσιμα σε σελίδες σημειώσεων και φυλλάδια.

**Τι γίνεται αν το πεδίο υποσέλιδου, ημερομηνίας/ώρας ή αριθμού διαφάνειας δεν είναι ορατό;**

Χρησιμοποιήστε τον αντίστοιχο διαχειριστή κεφαλίδας/υποσέλιδου για να ελέγξετε την ορατότητά του και ενεργοποιήστε το όταν χρειάζεται. Για παράδειγμα, η μέθοδος [isFooterVisible](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) αναφέρει αν υπάρχει πεδίο υποσέλιδου, και η μέθοδος [setFooterVisibility](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) αλλάζει την ορατότητά του.

**Πώς ξεκινάω την αρίθμηση των διαφανειών από τιμή διαφορετική από το 1;**

Καλέστε τη μέθοδο [setFirstSlideNumber](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#setFirstSlideNumber) της παρουσίασης. Τα πεδία αριθμού διαφάνειας θα χρησιμοποιήσουν την ενημερωμένη ακολουθία αρίθμησης.

**Τι συμβαίνει με τις κεφαλίδες και τα υποσέλιδα κατά την εξαγωγή σε PDF, εικόνες ή HTML;**

Τα ορατά στοιχεία κεφαλίδας και υποσέλιδου αποδίδονται μαζί με το υπόλοιπο περιεχόμενο της παρουσίασης στην εξαγώμενη μορφή. Η εμφάνισή τους εξαρτάται από τον τύπο της σελίδας που εξάγεται και τις αντίστοιχες ρυθμίσεις ορατότητας πεδίων.