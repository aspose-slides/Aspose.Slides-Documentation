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
- μη χρησιμοποιημένη διάταξη
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
- τίτλος και κατακόρυφο κείμενο
- κατακόρυφος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για Python μέσω .NET, προσθέστε θέσεις κράτησης, αφαιρέστε μη χρησιμοποιημένες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Η διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των θέσεων κράτησης, όπως τίτλους, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης δίνει στις διαφάνειες μια συνεπή δομή, ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συνηθισμένες διατάξεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει θέσεις κράτησης τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει μια θέση κράτησης τίτλου και μια γενικής χρήσης θέση κράτησης περιεχομένου.
- **Κενή**: Δεν περιέχει θέσεις κράτησης περιεχομένου και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διάταξης**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Μια [master slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα φόντα και τα κοινά αντικείμενα.
1. Μια [layout slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/) ανήκει σε ένα master και ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης.
1. Μια [normal slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για αυτή τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, και η διάταξη κληρονομεί από το master της. Μια τιμή που ορίζεται άμεσα σε μια κανονική διαφάνεια αντικαθιστά την κληρονομημένη τιμή σε εκείνο το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα των θέσεων κράτησης παράγονται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις θέσεις κράτησης ανήκει στη κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες θέσεις κράτησης σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας επιπλέον θέσης κράτησης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα θέσης κράτησης στις ήδη υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχουσών θέσεων κράτησης μιας διάταξης μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που ήδη χρησιμοποιείται, ελέγξτε τις εξαρτημένες διαφάνειες και εξετάστε την προκύπτουσα παρουσίαση.
- Μια διάταξη που εξακολουθεί να χρησιμοποιείται από μια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναπροσαρμόστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διάταξη ή αφαιρέστε μόνο τις διατάξεις που δεν χρησιμοποιούνται.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε [Slide Master](/slides/el/python-net/slide-master/).

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα διατάξεων είναι επεξεργάσιμα από το χρήστη και μπορούν να μεταφραστούν, έτσι η επιλογή βάσει ονόματος είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο προέλευσης.

Το παρακάτω παράδειγμα αναζητά το **Title and Content** στο πρώτο master. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στο **Blank**. Η δεύτερη έλεγχος για null είναι αναγκαία επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της ιδιότητας [Slide.layout_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/layout_slide/).

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

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα συνηθισμένα σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των θέσεων κράτησης, η κληρονομική μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχουσών θέσεων κράτησης και της νέας διάταξης μπορεί να αλλάξει, γι' αυτό εξετάστε το αποτέλεσμα όταν μεταβαίνετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν τη δημιουργεί. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterlayoutslidecollection/add/) στη συλλογή διατάξεων του στόχου master.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, ενώ στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Προσθέστε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια ακόμη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε την και χρησιμοποιήστε την ξανά αντί να δημιουργήσετε ένα αντίγραφο.

## **Προσθήκη Θέσεων Κράτησης σε Διάταξη Διαφάνειας**

Η ιδιότητα [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/placeholder_manager/) παρέχει ένα [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/) για την προσθήκη σχημάτων θέσεων κράτησης σε μια διάταξη.

| PowerPoint Placeholder | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![Περιεχόμενο](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Κείμενο](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Εικόνα](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Διάγραμμα](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Πίνακας](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Πολυμέσα](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Το παρακάτω παράδειγμα επαληθεύει ότι η διάταξη **Blank** υπάρχει, προσθέτει τέσσερις θέσεις κράτησης σε αυτήν και, στη συνέχεια, δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι θέσεις κράτησης προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα θέσεων κράτησης στη διαφάνεια.

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

![Οι θέσεις κράτησης στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Προειδοποίηση" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχουσών θέσεων κράτησης μιας διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νέες προστιθέμενη θέση κράτησης διάταξης δεν συμπληρώνεται αυτόματα στις υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε ένα αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Μη Χρησιμοποιημένων Διατάξεων Διαφάνειας**

Χρησιμοποιήτε τη μέθοδο [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) για την αφαίρεση διατάξεων που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητες τις διατάξεις που εξακολουθούν να χρησιμοποιούνται.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, πρώτα χρησιμοποιήστε την ιδιότητα [has_depending_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/has_depending_slides/) ή τη μέθοδο [get_depending_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/get_depending_slides/). Αντιστοιχίστε ξανά τυχόν εξαρτημένες διαφάνειες πριν καλέσετε τη [LayoutSlide.remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/remove/). Η προσπάθεια αφαίρεσης μιας σε χρήση διάταξης προκαλεί ένα [PptxEditException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη έχει το δικό της υποσέλιδο, θέση κράτησης αριθμού διαφάνειας και ημερομηνίας‑ώρας. Χρησιμοποιήστε την ιδιότητα [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/header_footer_manager/) για να ελέγξετε αυτές τις θέσεις κράτησης για μία διάταξη. Αυτό είναι χρήσιμο, για παράδειγμα, όταν οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου δεν πρέπει.

Το παρακάτω παράδειγμα επιλέγει μια διάταξη με ασφάλεια και καθιστά τα στοιχεία του υποσέλιδου ορατά:

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Master και τις Παράγωγες Διατάξεις**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη τη ιεραρχία ενός master, χρησιμοποιήστε την ιδιότητα [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/header_footer_manager/). Οι μέθοδοι διάδοσης του [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslideheaderfootermanager/) λειτουργούν στο master και στις εξαρτημένες από αυτό διατάξεις διαφάνειας και κανονικές διαφάνειες· δεν στοχεύουν μόνο σε μία κανονική διαφάνεια.

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

**Ποια είναι η Διαφορά μεταξύ ενός Master Slide και ενός Layout Slide;**

Ένα master slide ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Ένα layout slide ανήκει σε ένα master και ορίζει μια επαναχρησιμοποιήσιμη διάταξη θέσεων κράτησης. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το περιεχόμενο που είναι ειδικό για τη διαφάνειά τους.

**Μπορώ να Αντιγράψω ένα Layout Slide από Μία Παρουσίαση σε Άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η πηγή διάταξης.

**Τι Συμβαίνει Όταν Τροποποιήσω μια Διάταξη που Είναι Ήδη σε Χρήση;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης, εκτός εάν παρακάμψουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των θέσεων κράτησης και η κληρονομημένη μορφοποίηση μπορούν έτσι να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [get_depending_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/get_depending_slides/) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι Συμβαίνει Εάν Αφαιρέσω μια Διάταξη που Είναι Ακόμη σε Χρήση;**

Το Aspose.Slides εγείρει ένα [PptxEditException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxeditexception/). Αναπροσαρμόστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε το [remove_unused_layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) για να αφαιρέσετε μόνο τις μη αναφερθείσες διατάξεις.