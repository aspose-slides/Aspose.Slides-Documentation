---
title: Διαχειριστείτε τους Master Slides Παρουσίασης σε Python
linktitle: Master Slide
type: docs
weight: 80
url: /el/python-net/slide-master/
keywords:
- master διαφάνειας
- master διαφάνεια
- master διαφάνεια PPT
- πολλαπλές master διαφάνειες
- σύγκριση master διαφανειών
- φόντο
- placeholder
- κλωνοποίηση master διαφάνειας
- αντιγραφή master διαφάνειας
- δημιουργία διπλότυπης master διαφάνειας
- αχρησιμοποίητη master διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε master διαφάνειες στο Aspose.Slides for Python μέσω .NET: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνηθισμένος τρόπος να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides for Python μέσω .NET υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες master διαφάνειες, και κάθε master διαφάνεια μπορεί να περιέχει πολλές layout διαφάνειες. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται απευθείας σε μια master διαφάνεια. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια layout διαφάνεια, η οποία ανήκει σε μια master διαφάνεια.

Η ιεραρχία είναι:

1. **Slide master** – ορίζει το κοινό σχέδιο και το θέμα.
1. **Layout slide** – ορίζει μια συγκεκριμένη διάταξη placeholders και μορφοποίησης επιπέδου layout.
1. **Normal slide** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία layout διαφάνεια.

![Η ιεραρχία των master διαφανειών, layout διαφανειών και normal διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, ένας slide master αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/). Όλες οι master διαφάνειες σε μια παρουσίαση είναι διαθέσιμες μέσω της συλλογής `Presentation.masters`.

{{% alert color="info" title="Κληρονομικότητα" %}}

Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο κυριαρχεί. Για παράδειγμα, εάν μια master διαφάνεια και μια layout διαφάνεια ορίσουν και οι δύο φόντο, οι διαφάνειες που βασίζονται σε αυτή τη layout χρησιμοποιούν το φόντο της layout. Για περισσότερες πληροφορίες σχετικά με τις layout διαφάνειες, δείτε [Apply or Change Slide Layouts](/python-net/slide-layout/).

{{% /alert %}}

## **Πρόσβαση σε Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Slide Master από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `masters` για πρόσβαση στις master διαφάνειες:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Μπορείτε επίσης να λάβετε τη master διαφάνεια που χρησιμοποιείται από μια κανονική διαφάνεια μέσω του layout της:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Τι Περιέχει μια Slide Master**

Μια master διαφάνεια είναι ένα αντικείμενο τύπου διαφάνειας. Κληρονομεί τη συμπεριφορά κοινών διαφανειών από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/), επομένως εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από τις κανονικές και τις layout διαφάνειες. Τα μέλη ειδικά για τις master διαφάνειες είναι καταχωρημένα στη σελίδα API [MasterSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/).

Συχνά χρησιμοποιούμενα μέλη master διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `background` | Ορίζει το φόντο της διαφάνειας σε επίπεδο master. |
| `shapes` | Αποθηκεύει σχήματα που τοποθετούνται στη master, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `layout_slides` | Αποθηκεύει τις layout διαφάνειες που ανήκουν στη master. |
| `theme_manager` | Παρέχει πρόσβαση στα API θέματος της master. |
| `header_footer_manager` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για τη master και τις θυγατρικές της layout. |
| `get_depending_slides` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από τη master μέσω των layout τους. |

## **Προσθήκη Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε μια master διαφάνεια, εμφανίζεται στις διαφάνειες που χρησιμοποιούν layout από αυτή τη master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη master διαφάνεια:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε [Picture Frame](/python-net/picture-frame/).

## **Εργασία με Placeholders**

Τα placeholders ορίζονται συνήθως σε layout διαφάνειες. Η master διαφάνεια παρέχει το κοινό στυλ και το θέμα που κληρονομούν αυτές οι layout, ενώ κάθε layout决定 ποιες placeholders είναι διαθέσιμες και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder είναι διαθέσιμες στην προβολή Slide Master.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέα placeholders με το Aspose.Slides, εργαστείτε με τη layout διαφάνεια που ανήκει στη master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Μπορείτε επίσης να μορφοποιήσετε σχήματα placeholder που ήδη υπάρχουν σε μια master διαφάνεια. Το παρακάτω παράδειγμα εντοπίζει το placeholder τίτλου και εφαρμόζει γραμμική διαβάθμιση:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Τίτλος placeholder μορφοποιημένος και κληρονομείται από κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές placeholder και μορφοποίησης κειμένου, δείτε [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) και [Text Formatting](/python-net/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Ένα φόντο master κληρονομείται από τις layout και τις διαφάνειες που δεν το αντικαθιστούν. Το παρακάτω παράδειγμα ορίζει ένα συμπαγές χρώμα φόντου για την πρώτη master διαφάνεια:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Για συναφή θέματα, δείτε [Presentation Background](/python-net/presentation-background/) και [Presentation Theme](/python-net/presentation-theme/).

## **Κλωνοποίηση Slide Master σε Άλλη Παρουσίαση**

Χρησιμοποιήστε τη μέθοδο `add_clone` στην κλάση [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/) για να αντιγράψετε μια master διαφάνεια σε άλλη παρουσίαση. Η αντιγραμμένη master μπορεί στη συνέχεια να χρησιμοποιηθεί από layout και διαφάνειες στην προοριστική παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Εάν χρειάζεστε να κλωνοποιήσετε κανονικές διαφάνειες μαζί με τη master τους, δείτε [Clone Slides](/python-net/clone-slides/).

## **Προσθήκη Πολλαπλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλές master διαφάνειες. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετικό branding, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση master διαφανειών](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί τη προεπιλεγμένη master, δίνει στο κλώνο διαφορετικό φόντο, λαμβάνει ένα κενό layout κάτω από αυτή τη κλωνοποιημένη master και προσθέτει μια νέα διαφάνεια βάσει αυτού του layout:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Σύγκριση Slide Masters**

Οι master διαφάνειες μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινούμενα σχέδια και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως slide IDs, ή δυναμικές τιμές placeholder, όπως η τρέχουσα ημερομηνία.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/python-net/compare-slides/).

## **Ορισμός Slide Master View ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε την ιδιότητα `last_view` στην παρουσίαση [ViewProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει το PowerPoint πρώτα. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/python-net/save-presentation/).

## **Αφαίρεση Αχρησιμοποίητων Master Διαφανειών**

Οι παρουσιάσεις μερικές φορές περιέχουν master διαφάνειες που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση αχρησιμοποίητων master μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση προτύπων.

Χρησιμοποιήστε `remove_unused` για να αφαιρέσετε αχρησιμοποίητες master από τη συλλογή `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low-code `remove_unused_master_slides` από την κλάση [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ slide master και layout slide;**

Μια slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια layout slide ανήκει σε μια master slide και ορίζει μια συγκεκριμένη διάταξη placeholders. Μια κανονική διαφάνεια χρησιμοποιεί μια layout slide, έτσι κληρονομεί τόσο από τη layout όσο και από τη master.

**Μπορεί μια παρουσίαση να περιέχει πολλές slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλές slide masters. Χρησιμοποιήστε πολλαπλές master όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή branding.

**Θα πρέπει να προσθέσω placeholders σε master slide ή σε layout slide;**

Στις περισσότερες περιπτώσεις, προσθέτετε placeholders σε layout slides. Τοποθετήστε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στη master slide, και τοποθετήστε τα placeholders περιεχομένου στις layout που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω μια master slide που χρησιμοποιείται ακόμα;**

Όχι. Μια master slide που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια απευθείας. Πρώτα μετακινήστε αυτές τις διαφάνειες σε layout κάτω από άλλη master, ή χρησιμοποιήστε μια μέθοδο καθαρισμού αχρησιμοποίητων master που αφαιρεί μόνο τις master που δεν χρησιμοποιούνται.