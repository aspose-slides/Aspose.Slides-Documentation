---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης με Python
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/python-net/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορίστε κεφαλίδα
- ορίστε υποσέλιδο
- φυλλάδιο
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τα κρατήρια υποσέλιδου, ημερομηνίας-ώρας, αριθμού διαφάνειας και κεφαλίδας σε διαφάνειες, σελίδες σημειώσεων και φυλλάδια με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Το PowerPoint χρησιμοποιεί διαφορετικά κρατήρια κεφαλίδας και υποσημείωσης ανάλογα με τον τύπο της σελίδας. Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να ελέγχετε το κείμενο και την ορατότητα αυτών των κρατηρίων μέσω των κλάσεων διαχειριστή κεφαλίδας/υποσημείωσης.

Το πεδίο μιας αλλαγής εξαρτάται από τον διαχειριστή που χρησιμοποιείτε. Η κλάση [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/slideheaderfootermanager/) ελέγχει μία κανονική διαφάνεια. Η κλάση [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/notesslideheaderfootermanager/) ελέγχει μία διαφάνεια σημειώσεων. Οι διαχειριστές master και layout μπορούν επίσης να διαδώσουν τις ρυθμίσεις σε εξαρτημένες διαφάνειες, ενώ η κλάση [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) ελέγχει το μάστερ φυλλάδωσης.

| Πεδίο | Κεφαλίδα | Υποσημείωση | Ημερομηνία/Ώρα | Αριθμός διαφάνειας/σέλας |
|---|---|---|---|---|
| Κανονική διαφάνεια | Όχι | Ναι | Ναι | Ναι |
| Μάστερ σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Διαφάνεια σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Μάστερ φυλλάδωσης | Ναι | Ναι | Ναι | Ναι |

Μια κανονική διαφάνεια παρουσίασης δεν διαθέτει κρατήριο κεφαλίδας. Οι κεφαλίδες είναι διαθέσιμες στις σελίδες σημειώσεων και στα φυλλάδια. Για τις κανονικές διαφάνειες, χρησιμοποιήστε τα κρατήρια υποσημείωσης, ημερομηνίας/ώρας και αριθμού διαφάνειας ως εναλλακτική.

## **Ορισμός Υποσημείωσης, Ημερομηνίας/Ώρας και Αριθμών Διαφάνειας σε Κανονικές Διαφάνειες**

Για τις κανονικές διαφάνειες, η βασική ροή εργασίας είναι να έχετε πρόσβαση στον διαχειριστή κεφαλίδας/υποσημείωσης κάθε διαφάνειας, να ορίσετε το κείμενο της υποσημείωσης και της ημερομηνίας/ώρας, να ενεργοποιήσετε τα απαιτούμενα κρατήρια και να αποθηκεύσετε την παρουσίαση. Οι αριθμοί διαφάνειας παράγονται από την παρουσίαση, οπότε χρειάζεται μόνο να ελέγξετε την ορατότητά τους.

Χρησιμοποιήστε [`set_footer_text`](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) και [`set_date_time_text`](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) για να ορίσετε το κείμενο, και χρησιμοποιήστε [`set_footer_visibility`](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), και [`set_slide_number_visibility`](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) για να εμφανίσετε τα αντίστοιχα κρατήρια.

Το παρακάτω ολοκληρωμένο παράδειγμα εφαρμόζει την ίδια υποσημείωση, κείμενο ημερομηνίας/ώρας και ορατότητα αριθμού διαφάνειας σε όλες τις κανονικές διαφάνειες:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Αν χρειάζεται να ενημερώσετε μόνο μία διαφάνεια, αποκτήστε πρόσβαση σε αυτήν απευθείας μέσω της συλλογής [`slides`](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slides/el/) , αντί να επαναλαμβάνετε όλη τη συλλογή.

## **Ορισμός Κεφαλίδων και Υποσημειώσεων στο Μάστερ Σημειώσεων**

Το μάστερ σημειώσεων ορίζει κοινή μορφοποίηση και συμπεριφορά κρατηρίων για τις σελίδες σημειώσεων. Χρησιμοποιήστε την κλάση [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/) όταν θέλετε να αλλάξετε μόνο το ίδιο το μάστερ σημειώσεων.

Το παρακάτω παράδειγμα ορίζει κεφαλίδα, υποσημείωση και κείμενο ημερομηνίας/ώρας στο μάστερ σημειώσεων και καθιστά όλα τα υποστηριζόμενα κρατήρια ορατά σε αυτό το μάστερ:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Μια παρουσίαση ενδέχεται να μην περιέχει μάστερ σημειώσεων, γι' αυτό ελέγξτε την επιστρεφόμενη τιμή για `None` πριν το αλλάξετε.

## **Εφαρμογή Ρυθμίσεων Μάστερ Σημειώσεων σε Παράγωγες Διαφάνειες Σημειώσεων**

Ένα μάστερ σημειώσεων μπορεί να εφαρμόσει τις ρυθμίσεις κεφαλίδας και υποσημείωσης τόσο στον εαυτό του όσο και σε όλες τις εξαρτημένες διαφάνειες σημειώσεων. Χρησιμοποιήστε τις ειδικές μεθόδους διάδοσης στην κλάση [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/) όταν οι ίδιες ρυθμίσεις πρέπει να εφαρμοστούν σε όλη την ιεραρχία σημειώσεων.

Για παράδειγμα, οι μέθοδοι [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) και [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) ενημερώνουν την κεφαλίδα του μάστερ σημειώσεων και όλες τις παράγωγες κεφαλίδες. Ισοδύναμες μέθοδοι είναι διαθέσιμες για υποσημειώσεις, ημερομηνία/ώρα και αριθμούς διαφάνειας.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Οι μέθοδοι διάδοσης που χρησιμοποιήθηκαν παραπάνω είναι [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), και [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Ορισμός Κεφαλίδων και Υποσημειώσεων σε Μεμονωμένη Διαφάνεια Σημειώσεων**

Μια διαφάνεια σημειώσεων ανήκει σε μια συγκεκριμένη κανονική διαφάνεια. Χρησιμοποιήστε την κλάση [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/notesslideheaderfootermanager/) όταν θέλετε να προσαρμόσετε μόνο αυτήν τη σελίδα σημειώσεων.

Η μέθοδος [`add_notes_slide`](https://reference.aspose.com/slides/el/python-net/aspose.slides/notesslidemanager/add_notes_slide/) επιστρέφει τη διαφάνεια σημειώσεων για τη τρέχουσα διαφάνεια και δημιουργεί μία εάν δεν υπάρχει ήδη. Το παρακάτω παράδειγμα διαμορφώνει τη σελίδα σημειώσεων που συσχετίζεται με την πρώτη διαφάνεια της παρουσίασης:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Αν πρώτα διαδώσετε τις ρυθμίσεις από το μάστερ σημειώσεων και στη συνέχεια αλλάξετε μια μεμονωμένη διαφάνεια σημειώσεων, οι μεταγενέστερες ρυθμίσεις ανά διαφάνεια σας επιτρέπουν να προσαρμόσετε εκείνη τη σελίδα σημειώσεων αυτόνομα.

## **Ορισμός Κεφαλίδων και Υποσημειώσεων στο Μάστερ Φυλλάδωσης**

Οι σελίδες φυλλάδωσης χρησιμοποιούν το μάστερ φυλλάδωσης για τα κρατήρια κεφαλίδας, υποσημείωσης, ημερομηνίας/ώρας και αριθμού σελίδας. Αντίθετα με τις σελίδες σημειώσεων, οι ρυθμίσεις φυλλάδωσης διαχειρίζονται μέσω του μάστερ φυλλάδωσης αντί για μεμονωμένες διαφάνειες φυλάδωσης.

Χρησιμοποιήστε την ιδιότητα [`master_handout_slide`](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) για να αποκτήσετε πρόσβαση στο μάστερ φυλλάδωσης. Εάν δεν υπάρχει, καλέστε τη μέθοδο [`set_default_master_handout_slide`](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) για να δημιουργήσετε το προεπιλεγμένο μάστερ φυλλάδωσης.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Κατανόηση Πεδίου και Κληρονομικότητας**

Επιλέξτε τον διαχειριστή κεφαλίδας/υποσημείωσης που ταιριάζει με το πεδίο που θέλετε να αλλάξετε:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/slideheaderfootermanager/) αλλάζει τις ρυθμίσεις υποσημείωσης, ημερομηνίας/ώρας και αριθμού διαφάνειας για μία κανονική διαφάνεια.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslideheaderfootermanager/) ελέγχει μία διαφάνεια διάταξης και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslideheaderfootermanager/) ελέγχει ένα μάστερ κανονικών διαφανειών και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/) ελέγχει το μάστερ σημειώσεων και μπορεί να διαδώσει τις ρυθμίσεις σε όλες τις εξαρτημένες διαφάνειες σημειώσεων.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/notesslideheaderfootermanager/) αλλάζει μία διαφάνεια σημειώσεων και υποστηρίζει ένα κρατήριο κεφαλίδας εκτός από υποσημείωση, ημερομηνία/ώρα και αριθμό διαφάνειας.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) αλλάζει το μάστερ φυλλάδωσης και υποστηρίζει και τους τέσσερις τύπους κρατηρίων.

Χρησιμοποιήστε διαδοχή από ένα μάστερ ή διάταξη όταν η ίδια ρύθμιση πρέπει να ισχύει σε όλη τη ιεραρχία του. Χρησιμοποιήστε έναν μεμονωμένο διαχειριστή διαφάνειας ή σημειώσεων όταν χρειάζεστε τοπική ρύθμιση για μία σελίδα.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσθέσω κεφαλίδα σε κανονική διαφάνεια;**

Όχι. Το PowerPoint δεν ορίζει κρατήριο κεφαλίδας για τις κανονικές διαφάνειες. Στις κανονικές διαφάνειες, χρησιμοποιήστε τα κρατήρια υποσημείωσης, ημερομηνίας/ώρας και αριθμού διαφάνειας. Τα κρατήρια κεφαλίδας είναι διαθέσιμα στις σελίδες σημειώσεων και στα φυλλάδια.

**Τι γίνεται αν ένα κρατήριο υποσημείωσης, ημερομηνίας/ώρας ή αριθμού διαφάνειας δεν είναι ορατό;**

Χρησιμοποιήστε τον αντίστοιχο διαχειριστή κεφαλίδας/υποσημείωσης για να ελέγξετε την ορατότητά του και να τον ενεργοποιήσετε όταν χρειάζεται. Για παράδειγμα, το [`is_footer_visible`](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) αναφέρει εάν υπάρχει κρατήριο υποσημείωσης, και το [`set_footer_visibility`](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) αλλάζει την ορατότητά του.

**Πώς μπορώ να ξεκινήσω την αρίθμηση διαφανειών από τιμή διαφορετική από το 1;**

Ορίστε την ιδιότητα [`first_slide_number`](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/first_slide_number/) της παρουσίασης. Τα κρατήρια αριθμού διαφάνειας θα χρησιμοποιήσουν τότε την ενημερωμένη ακολουθία αρίθμησης.

**Τι συμβαίνει με τις κεφαλίδες και υποσημειώσεις κατά την εξαγωγή σε PDF, εικόνες ή HTML;**

Τα ορατά στοιχεία κεφαλίδας και υποσημείωσης αποδίδονται μαζί με το υπόλοιπο περιεχόμενο της παρουσίασης στην έξοδο. Η εμφάνισή τους εξαρτάται από τον τύπο της σελίδας που εξάγεται και τις αντίστοιχες ρυθμίσεις ορατότητας των κρατηρίων.