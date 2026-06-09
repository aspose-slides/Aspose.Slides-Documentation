---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε Python
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/python-net/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- σύμβολο κράτησης θέσης
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
- τίτλος και κατακόρυφο κείμενο
- κατακόρυφος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε και να προσαρμόζετε τις διατάξεις διαφάνειας στο Aspose.Slides για Python μέσω .NET. Εξερευνήστε τους τύπους διατάξεων, τον έλεγχο των συμβόλων κράτησης θέσης, την ορατότητα του υποσέλιδου και τη διαχείριση των διατάξεων μέσω παραδειγμάτων κώδικα σε Python."
---
## **Εισαγωγή**

Ένα διάγραμμα διαφάνειας ορίζει τη διάταξη των κουτιών σύμβολων κράτησης θέσης και τη μορφοποίηση του περιεχομένου σε μια διαφάνεια. Ελέγχει ποια σύμβολα κράτησης θέσης διατίθενται και πού εμφανίζονται. Τα διαγράμματα διαφάνειας σας βοηθούν να δημιουργείτε παρουσιάσεις γρήγορα και σταθερά—είτε δημιουργείτε κάτι απλό είτε πιο σύνθετο. Μερικά από τα πιο συνηθισμένα διαγράμματα διαφάνειας στο PowerPoint περιλαμβάνουν:

**Διάταξη Διαφάνειας Τίτλου** – Περιλαμβάνει δύο σύμβολα κειμένου: ένα για τον τίτλο και ένα για τον υπότιτλο.

**Διάταξη Τίτλου και Περιεχομένου** – Διαθέτει ένα μικρότερο σύμβολο τίτλου στην κορυφή και ένα μεγαλύτερο από κάτω για το κύριο περιεχόμενο (όπως κείμενο, σημεία λίστας, γραφήματα, εικόνες και άλλα).

**Κενή διάταξη** – Δεν περιέχει σύμβολα κράτησης θέσης, προσφέροντάς σας πλήρη έλεγχο για το σχεδιασμό της διαφάνειας από το μηδέν.

Οι διατάξεις διαφάνειας αποτελούν μέρος ενός κύριου διαφάνειας, η οποία είναι η διαφάνεια ανώτερου επιπέδου που ορίζει τα στυλ διάταξης για την παρουσίαση. Μπορείτε να έχετε πρόσβαση και να τροποποιήσετε διατάξεις διαφάνειας μέσω του κύριου διαφάνειας—είτε με βάση τον τύπο, το όνομα ή το μοναδικό ID. Εναλλακτικά, μπορείτε να επεξεργαστείτε μια συγκεκριμένη διάταξη διαφάνειας απευθείας μέσα στην παρουσίαση.

Για να εργάζεστε με διατάξεις διαφάνειας στο Aspose.Slides για Python, μπορείτε να χρησιμοποιήσετε:

- Ιδιότητες όπως τα [layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/layout_slides/) και [masters](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/masters/) στην κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) 
- Τύποι όπως το [LayoutSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/), το [MasterLayoutSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterlayoutslidecollection/), το [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutplaceholdermanager/) και το [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Για να μάθετε περισσότερα σχετικά με τη δουλειά με κύριες διαφάνειες, δείτε το άρθρο [Manage PowerPoint Slide Masters in Python](/slides/el/python-net/slide-master/) .
{{% /alert %}}

## **Προσθήκη Διατάξεων Διαφάνειας σε Παρουσιάσεις**

Για να προσαρμόσετε την εμφάνιση και τη δομή των διαφάνειών σας, ίσως χρειαστεί να προσθέσετε νέες διατάξεις διαφάνειας σε μια παρουσίαση. Το Aspose.Slides για Python σάς επιτρέπει να ελέγξετε εάν μια συγκεκριμένη διάταξη υπάρχει ήδη, να προσθέσετε μια νέα εάν χρειαστεί και να τη χρησιμοποιήσετε για την εισαγωγή διαφάνειων βάσει αυτής της διάταξης.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Προσπελάστε τη συλλογή [MasterLayoutSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterlayoutslidecollection/) .
1. Ελέγξτε εάν η επιθυμητή διάταξη διαφάνειας υπάρχει ήδη στη συλλογή. Εάν όχι, προσθέστε τη διάταξη που χρειάζεστε.
1. Προσθέστε μια κενή διαφάνεια βασισμένη στη νέα διάταξη.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να προσθέσετε μια διάταξη διαφάνειας σε παρουσίαση PowerPoint:

```python
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για να ανοίξετε το αρχείο παρουσίασης.
with slides.Presentation("sample.pptx") as presentation:
    # Περπατήστε μέσα από τους τύπους διατάξεων διαφάνειας για να επιλέξετε μια διάταξη διαφάνειας.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Μία περίπτωση όπου η παρουσίαση δεν περιλαμβάνει όλους τους τύπους διατάξεων.
        # Το αρχείο παρουσίασης περιέχει μόνο τύπους διατάξεων Blank και Custom.
        # Ωστόσο, οι διατάξεις διαφάνειας με προσαρμοσμένους τύπους μπορεί να έχουν αναγνωρίσιμα ονόματα,
        # όπως "Title", "Title and Content", κ.λπ., τα οποία μπορούν να χρησιμοποιηθούν για την επιλογή διάταξης διαφάνειας.
        # Μπορείτε επίσης να βασιστείτε σε ένα σύνολο τύπων σχήματος σύμβολου κράτησης θέσης.
        # Για παράδειγμα, μια διαφάνεια Τίτλου θα πρέπει να έχει μόνο τον τύπο σύμβολου κράτησης θέσης Title, κ.ο.κ.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Προσθέστε μια κενή διαφάνεια χρησιμοποιώντας τη προστιθέμενη διάταξη διαφάνειας.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Κατάργηση Αχρησιμοποίητων Διατάξεων Διαφάνειας**

Το Aspose.Slides παρέχει τη μέθοδο [remove_unused_layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) από την κλάση [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/) για να διαγράψετε ανεπιθύμητες και αχρησιμοποίητες διατάξεις διαφάνειας.

Ο παρακάτω κώδικας Python δείχνει πώς να αφαιρέσετε μια διάταξη διαφάνειας από μια παρουσίαση PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Συμβόλων Κράτησης Θέσης σε Διατάξεις Διαφάνειας**

Το Aspose.Slides παρέχει την ιδιότητα [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/placeholder_manager/) η οποία σας επιτρέπει να προσθέσετε νέα σύμβολα κράτησης θέσης σε μια διάταξη διαφάνειας.

Αυτός ο διαχειριστής περιέχει μεθόδους για τους ακόλουθους τύπους συμβόλων:

| Σύμβολο κράτησης θέσης PowerPoint | Μέθοδος LayoutPlaceholderManager |
| --------------------------------- | --------------------------------- |
| ![Περιεχόμενο](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Κείμενο](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Εικόνα](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Διάγραμμα](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Πίνακας](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Μέσα](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Διαδικτυακή Εικόνα](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Ο παρακάτω κώδικας Python δείχνει πώς να προσθέσετε νέες μορφές συμβόλων κράτησης θέσης στη κενή διάταξη διαφάνειας:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Αποκτήστε τη διάταξη διαφάνειας Blank.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Αποκτήστε τον διαχειριστή συμβόλων κράτησης θέσης της διάταξης διαφάνειας.
    placeholder_manager = layout.placeholder_manager

    # Προσθέστε διαφορετικά σύμβολα κράτησης θέσης στη διάταξη διαφάνειας Blank.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Προσθέστε μια νέα διαφάνεια με τη διάταξη Blank.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Τα σύμβολα στην διάταξη διαφάνειας](add_placeholders.png)

## **Ορισμός Ορατότητας Υποσέλιδου για μια Διάταξη Διαφάνειας**

Σε παρουσιάσεις PowerPoint, στοιχεία υποσέλιδου όπως ημερομηνία, αριθμός διαφάνειας και προσαρμοσμένο κείμενο μπορούν να εμφανίζονται ή να κρύβονται ανάλογα με τη διάταξη της διαφάνειας. Το Aspose.Slides για Python σας επιτρέπει να ελέγξετε την ορατότητα αυτών των συμβόλων υποσέλιδου. Αυτό είναι χρήσιμο όταν θέλετε ορισμένες διατάξεις να εμφανίζουν πληροφορίες υποσέλιδου ενώ άλλες παραμένουν καθαρές.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Πάρτε μια αναφορά σε διάταξη διαφάνειας με το δείκτη της.
1. Ορίστε το σύμβολο υποσέλιδου της διαφάνειας ως ορατό.
1. Ορίστε το σύμβολο αριθμού διαφάνειας ως ορατό.
1. Ορίστε το σύμβολο ημερομηνίας-ώρας ως ορατό.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε την ορατότητα του υποσέλιδου μιας διαφάνειας και να εκτελέσετε σχετικές εργασίες:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Ορισμός Ορατότητας Υποσέλιδου για τις Παιδικές Διαφάνειες**

Σε παρουσιάσεις PowerPoint, στοιχεία υποσέλιδου όπως ημερομηνία, αριθμός διαφάνειας και προσαρμοσμένο κείμενο μπορούν να ελεγχθούν στο επίπεδο της κύριας διαφάνειας για να εξασφαλιστεί συνέπεια σε όλες τις διατάξεις διαφάνειας. Το Aspose.Slides για Python επιτρέπει τον ορισμό της ορατότητας και του περιεχομένου αυτών των συμβόλων υποσέλιδου στη κύρια διαφάνεια και τη διάχυση αυτών των ρυθμίσεων σε όλες τις παιδικές διατάξεις διαφάνειας. Αυτή η προσέγγιση εξασφαλίζει εναρμονισμένες πληροφορίες υποσέλιδου σε όλη την παρουσίαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Πάρτε μια αναφορά στη κύρια διαφάνεια με το δείκτη της.
1. Ορίστε τα σύμβολα υποσέλιδου της κύριας και όλων των παιδικών διαφάνειων ως ορατά.
1. Ορίστε τα σύμβολα αριθμού διαφάνειας της κύριας και όλων των παιδικών διαφάνειων ως ορατά.
1. Ορίστε τα σύμβολα ημερομηνίας-ώρας της κύριας και όλων των παιδικών διαφάνειων ως ορατά.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει αυτή τη λειτουργία:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κύριας διαφάνειας και διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το γενικό θέμα και την προεπιλεγμένη μορφοποίηση, ενώ οι διατάξεις διαφάνειας ορίζουν συγκεκριμένες διατάξεις συμβόλων κράτησης θέσης για διαφορετικούς τύπους περιεχομένου.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μια παρουσίαση σε άλλη;**

Ναι, μπορείτε να κλωνοποιήσετε μια διάταξη διαφάνειας από τη συλλογή [layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/layout_slides/) μιας παρουσίασης και να την εισάγετε σε άλλη χρησιμοποιώντας τη μέθοδο `add_clone`.

**Τι συμβαίνει αν διαγράψω μια διάταξη διαφάνειας που χρησιμοποιείται ακόμα από κάποια διαφάνεια;**

Εάν προσπαθήσετε να διαγράψετε μια διάταξη διαφάνειας που εξακολουθεί να αναφέρεται τουλάχιστον από μία διαφάνεια στην παρουσίαση, το Aspose.Slides θα ρίξει ένα [PptxEditException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxeditexception/). Για να αποφύγετε αυτό, χρησιμοποιήστε τη [remove_unused_layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) που αφαιρεί με ασφάλεια μόνο τις διατάξεις που δεν χρησιμοποιούνται.