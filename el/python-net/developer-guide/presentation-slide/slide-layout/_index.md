---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε Python
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/python-net/slide-layout/
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
- επικεφαλίδα ενότητας
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
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για Python μέσω .NET, προσθέστε θέσεις κράτησης, αφαιρέστε αχρησιμοποίητες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Ένα πρότυπο διάταξης διαφάνειας καθορίζει τις θέσεις και τη μορφοποίηση των θέσεων κράτησης όπως τίτλοι, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή ενός προτύπου παρέχει στις διαφάνειες μια συνεπή δομή, ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συνηθισμένες διατάξεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει θέσεις κράτησης τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει μια θέση κράτησης τίτλου και μια γενικής χρήσης θέση κράτησης περιεχομένου.
- **Κενό**: Δεν περιέχει θέσεις κράτησης περιεχομένου και είναι χρήσιμο όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διάταξης**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Μια [master slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα φόντα και τα κοινά αντικείμενα.
2. Μια [layout slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/) ανήκει σε μια κύρια διαφάνεια και ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης.
3. Μια [normal slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, και η διάταξη κληρονομεί από την κύρια της. Μια τιμή που ορίζεται απευθείας σε μια κανονική διαφάνεια παρακάμπτει την κληρονομική τιμή σε αυτό το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα θέσεων κράτησης δημιουργούνται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις θέσεις ανήκει στην κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες θέσεις κράτησης σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας άλλης θέσης κράτησης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα ένα αντίστοιχο σχήμα θέσης κράτησης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομικής μορφοποίησης ή της γεωμετρίας των υπαρχουσών θέσεων κράτησης σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που χρησιμοποιείται ήδη, ελέγξτε τις εξαρτημένες διαφάνειες και ανασκοπήστε την προκύπτουσα παρουσίαση.
- Μια διάταξη που εξακολουθεί να χρησιμοποιείται από μια διαφάνεια δεν μπορεί να αφαιρεθεί. Ανανεώστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε [Slide Master](/slides/el/python-net/slide-master/).

Για απόκρυψη κληρονομικών λογοτύπων ή διακοσμητικών σχημάτων κύριας διαφάνειας σε μία διαφάνεια ή μέσω κοινής διάταξης, δείτε [Control the Visibility of Master Graphics](/slides/el/python-net/slide-master/). Το παράδειγμα συγκρίνει δύο διαφάνειες που χρησιμοποιούν την ίδια κύρια διαφάνεια.

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμοί διάταξης του PowerPoint. Τα ονόματα διατάξεων μπορούν να επεξεργαστούν από τον χρήστη και να εντοπιστούν, επομένως η επιλογή με βάση το όνομα είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο πηγής.

Το παρακάτω παράδειγμα αναζητά **Title and Content** στην πρώτη κύρια διαφάνεια. Αν αυτή η διάταξη δεν είναι διαθέσιμη, επανέρχεται σκόπιμα σε **Blank**. Ο δεύτερος έλεγχος για null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της ιδιότητας [Slide.layout_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα κανονικά σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των θέσεων κράτησης, η κληρονομική μορφοποίηση και η αντιστοίχηση μεταξύ των υπαρχουσών θέσεων κράτησης και της νέας διάταξης μπορεί να αλλάξει, γι' αυτό ελέγξτε το αποτέλεσμα όταν μεταβαίνετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί νέα. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterlayoutslidecollection/add/) στη συλλογή διατάξεων του στοχευόμενου master.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Προσθέστε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια επιπλέον επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε και χρησιμοποιήστε την ξανά αντί να δημιουργήσετε αντίγραφο.

## **Προσθήκη Θέσεων Κράτησης σε Διάταξη Διαφάνειας**

Η ιδιότητα [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/placeholder_manager/) παρέχει ένα [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/) για την προσθήκη σχημάτων θέσεων κράτησης σε μια διάταξη.

| PowerPoint Placeholder | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![Περιεχόμενο](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Περιεχόμενο (Κατακόρυφα)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Κείμενο](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Κείμενο (Κατακόρυφα)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Εικόνα](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Διάγραμμα](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Πίνακας](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Πολυμέσα](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Το παρακάτω παράδειγμα ελέγχει ότι η διάταξη **Blank** υπάρχει, προσθέτει τέσσερις θέσεις κράτησης σε αυτήν και μετά δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι θέσεις κράτησης προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορέσει να δημιουργήσει τα αντίστοιχα σχήματα θέσεων κράτησης σε αυτή τη διαφάνεια.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι θέσεις κράτησης στη διαφάνεια διάταξης](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή της κληρονομικής μορφοποίησης ή της γεωμετρίας των υπαρχουσών θέσεων κράτησης μιας διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια πρόσφατα προστιθέμενη θέση κράτησης διάταξης δεν προστίθεται αυτόματα σε υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Αχρησιμοποίητων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει ανέπαφες τις διατάξεις που εξακολουθούν να χρησιμοποιούνται.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, πρώτα χρησιμοποιήστε την ιδιότητα [has_depending_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/has_depending_slides/) ή τη μέθοδο [get_depending_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/get_depending_slides/). Αναθέστε εκ των προτέρων τυχόν εξαρτημένες διαφάνειες πριν καλέσετε το [LayoutSlide.remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/remove/). Η προσπάθεια αφαίρεσης μιας διατάξης που χρησιμοποιείται προκαλεί την εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη διαθέτει το δικό της υποσέλιδο, αριθμό διαφάνειας και θέσεις κράτησης ημερομηνίας‑ώρας. Χρησιμοποιήστε την ιδιότητα [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/header_footer_manager/) για να ελέγξετε αυτές τις θέσεις σε μία διάταξη. Αυτό είναι χρήσιμο, για παράδειγμα, όταν οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

Το παρακάτω παράδειγμα επιλέγει μια διάταξη με ασφάλεια και καθιστά ορατά τα στοιχεία υποσέλιδου:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Έλεγχος Ορατότητας Υποσέλιδου σε Master και στις Υπό-Διατάξεις του**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη την ιεραρχία ενός master, χρησιμοποιήστε την ιδιότητα [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/header_footer_manager/). Οι μέθοδοι διάδοσης του [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslideheaderfootermanager/) εφαρμόζονται στο master και στις εξαρτημένες διατάξεις και κανονικές διαφάνειες· δεν στοχεύουν μόνο σε μία κανονική διαφάνεια.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ μιας Master Slide και μιας Layout Slide;**

Μια master slide ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Μια layout slide ανήκει σε μια master slide και ορίζει μία επαναχρησιμοποιήσιμη διάταξη θέσεων κράτησης. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το περιεχόμενο της κάθε διαφάνειας.

**Μπορώ να αντιγράψω μια Layout Slide από μία Παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στην προοριστική συλλογή με τη μέθοδο [add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Κατά την αντιγραφή μεταξύ παρουσιάσεων, επαληθεύστε επίσης γραμματοσειρές, θέματα, εικόνες και άλλους πόρους που χρησιμοποιεί η πηγή διάταξης.

**Τι συμβαίνει όταν τροποποιώ μια Διάταξη που χρησιμοποιείται ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης εκτός εάν έχουν παρακάμψει το επηρεαζόμενο στυλ ή αντικείμενα τοπικά. Η γεωμετρία των θέσεων κράτησης και η κληρονομική μορφοποίηση μπορεί έτσι να αλλάξει σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [get_depending_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/get_depending_slides/) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει αν αφαιρέσω μια Διάταξη που είναι ακόμη σε χρήση;**

Το Aspose.Slides ρίχνει μια [PptxEditException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε το [remove_unused_layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) για να αφαιρέσετε μόνο τις αχρησιμοποίητες διατάξεις.