---
title: Διαχείριση slide masters παρουσίασης σε Python
linktitle: Διαχειριστής Διαφάνειας
type: docs
weight: 80
url: /el/python-net/slide-master/
keywords:
- κύριος master διαφάνειας
- master διαφάνειας
- PPT master διαφάνειας
- πολλαπλοί master διαφάνειες
- σύγκριση master διαφανειών
- φόντο
- σύμβολο κράτησης
- κλωνοποίηση master διαφάνειας
- αντιγραφή master διαφάνειας
- διπλασιασμός master διαφάνειας
- αχρησιμοποίητη master διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τα master slides στο Aspose.Slides για Python μέσω .NET: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιλαμβάνει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνηθισμένος τρόπος για να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Aspose.Slides for Python via .NET υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει ένα ή περισσότερα master slides, και κάθε master slide μπορεί να περιέχει αρκετά layout slides. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται απευθείας σε ένα master slide. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί ένα layout slide, και αυτό το layout slide ανήκει σε ένα master slide.

Η ιεραρχία είναι:

1. **Slide master** – ορίζει το κοινό σχέδιο και το θέμα.
1. **Layout slide** – ορίζει μια συγκεκριμένη διάταξη των placeholders και τη μορφοποίηση επιπέδου διάταξης.
1. **Normal slide** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί ένα layout slide.

![Η ιεραρχία των master διαφανειών, layout διαφανειών και κανονικών διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, ένας slide master αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/). Όλα τα master slides σε μια παρουσίαση είναι διαθέσιμα μέσω της συλλογής `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο υπερισχύει. Για παράδειγμα, εάν ένα master slide και ένα layout slide ορίζουν και τα δύο φόντο, οι διαφάνειες που βασίζονται σε αυτό το layout χρησιμοποιούν το φόντο του layout. Για περισσότερες πληροφορίες σχετικά με τα layout slides, δείτε [Apply or Change Slide Layouts](/slides/el/python-net/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Slide Master από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `masters` για πρόσβαση στα master slides:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Μπορείτε επίσης να λάβετε το master slide που χρησιμοποιείται από μια κανονική διαφάνεια μέσω της διάταξής της:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Τι Περιέχει ένα Slide Master**

Ένα master slide είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Κληρονομεί κοινή συμπεριφορά διαφάνειας από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/), έτσι εκθέτει πολλές από τις ίδιας διαφάνειας ιδιότητες που χρησιμοποιούνται από κανονικές και layout διαφάνειες. Τα μέλη που αφορούν μόνο το master αναφέρονται στην σελίδα API [MasterSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/).

Κοινά χρησιμοποιούμενα μέλη του master slide περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `background` | Ορίζει το φόντο σε επίπεδο master διαφάνειας. |
| `shapes` | Αποθηκεύει σχήματα που τοποθετούνται στο master, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `layout_slides` | Αποθηκεύει τα layout slides που ανήκουν στο master. |
| `theme_manager` | Παρέχει πρόσβαση στα API του θέματος του master. |
| `header_footer_manager` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για το master και τα παιδικά του layout. |
| `get_depending_slides` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από το master μέσω των layout τους. |

## **Πρόσθεση Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε ένα master slide, αυτή εμφανίζεται στις διαφάνειες που χρησιμοποιούν layout από αυτό το master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στο πρώτο master slide:

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

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε [Picture Frame](/slides/el/python-net/picture-frame/).

## **Έλεγχος Ορατότητας Γραφικών Master**

Χρησιμοποιήστε το [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/show_master_shapes/) για να κρύψετε κληρονομημένα γραφικά master, όπως λογότυπα ή διακοσμητικά σχήματα, χωρίς να τα διαγράψετε από το master. Ορίστε το [Slide.show_master_shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/show_master_shapes/) σε `False` στη διαφάνεια που πρέπει να παραλείψει αυτά τα γραφικά και κρατήστε το `True` στις διαφάνειες που πρέπει να τα εμφανίσουν.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια μπλε διακοσμητική λωρίδα σε ένα master και δύο διαφάνειες που χρησιμοποιούν το ίδιο κενό layout. Η λωρίδα είναι ορατή στην πρώτη διαφάνεια και κρυμμένη στη δεύτερη. Δεν απαιτείται εισαγωγική παρουσίαση ή εικόνα.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

Το παράδειγμα χρησιμοποιεί το layout **Blank** που παρέχεται με μια νέα παρουσίαση και αφαιρεί τα αρχικά placeholders της πρώτης διαφάνειας.

### **Επιλογή Πεδίου Εφαρμογής της Ρύθμισης**

Μια κανονική διαφάνεια χρησιμοποιεί το master της μέσω του [Slide.layout_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/layout_slide/) και του [LayoutSlide.master_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/master_slide/). Η ρύθμιση της ιδιότητας σε μια μεμονωμένη διαφάνεια επηρεάζει μόνο αυτή τη διαφάνεια. Ο ορισμός του [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/show_master_shapes/) σε `False` κρύβει τα γραφικά master για όλες τις διαφάνειες που χρησιμοποιούν αυτό το κοινό layout, ακόμη κι αν η δική τους ρύθμιση είναι `True`. Για να κρύψετε γραφικά μόνο σε μία διαφάνεια, αλλάξτε την ιδιότητα της διαφάνειας και αφήστε το κοινό layout αμετάβλητο.

Η ρύθμιση δεν υποστηρίζεται ως έλεγχος ορατότητας στο ίδιο το master slide. Σε ένα master επιστρέφει πάντα `False`, και η ανάθεση `True` προκαλεί εξαίρεση. Εφαρμόστε τη σε μια κανονική διαφάνεια ή σε ένα layout.

### **Διαχωρισμός Γραφικών από το Φόντο**

| Ενέργεια | Αποτέλεσμα |
| --- | --- |
| Απόκρυψη γραφικών master | Ελέγχει την ορατότητα των κληρονομημένων σ shapes master χωρίς να τα διαγράψει ή να αλλάξει τα δικά σ shapes της διαφάνειας. |
| Αλλαγή γεμίσματος φόντου διαφάνειας | Αλλάζει το χρώμα, τη διαβάθμιση ή την εικόνα του φόντου. Τα γραφικά master είναι ξεχωριστά σ shapes και μπορούν να παραμείνουν ορατά πάνω από το φόντο. Δείτε [Presentation Background](/slides/el/python-net/presentation-background/). |
| Διαγραφή σ shape από το master | Αφαιρεί το κοινό σ shape, ώστε να μην είναι πλέον διαθέσιμο σε καμία διαφάνεια που χρησιμοποιεί αυτό το master. |

## **Εργασία με Placeholders**

Τα placeholders ορίζονται συνήθως σε layout slides. Το master slide παρέχει το κοινό στυλ και το θέμα που κληρονομούν αυτά τα layout, ενώ κάθε layout αποφασίζει ποια placeholders είναι διαθέσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder είναι διαθέσιμες στην προβολή Slide Master.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέα placeholders με το Aspose.Slides, εργαστείτε με το layout slide που ανήκει στο master:

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

Μπορείτε επίσης να μορφοποιήσετε σ shape placeholders που ήδη υπάρχουν σε ένα master slide. Το παρακάτω παράδειγμα εντοπίζει το placeholder τίτλου και εφαρμόζει γραμμική διαβάθμιση:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Μορφοποιημένο placeholder τίτλου που κληρονόμησε από κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές placeholders και μορφοποίησης κειμένου, δείτε [Set Prompt Text in Placeholder](/slides/el/python-net/manage-placeholder/) και [Text Formatting](/slides/el/python-net/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Ένα φόντο master κληρονομείται από τα layout και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα γερό χρώμα φόντου για το πρώτο master slide:

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

Για συναφή θέματα, δείτε [Presentation Background](/slides/el/python-net/presentation-background/) και [Presentation Theme](/slides/el/python-net/presentation-theme/).

## **Κλωνοποίηση Slide Master σε Άλλη Παρουσίαση**

Χρησιμοποιήστε τη μέθοδο `add_clone` στην κλάση [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/) για να αντιγράψετε ένα master slide σε άλλη παρουσίαση. Το αντίγραφο του master μπορεί στη συνέχεια να χρησιμοποιηθεί από layout και διαφάνειες στην προοριστική παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Αν χρειάζεται να κλωνοποιήσετε κανονικές διαφάνειες μαζί με το master τους, δείτε [Clone Slides](/slides/el/python-net/clone-slides/).

## **Προσθήκη Πολλαπλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλαπλά master slides. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετική σήμανση, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση master slides](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί το προεπιλεγμένο master, δίνει στο αντίγραφο διαφορετικό φόντο, λαμβάνει ένα κενό layout κάτω από αυτό το κλωνοποιημένο master και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτό το layout:

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

Τα master slides μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σ shapes, κείμενο, μορφοποίηση, εφέ κίνησης και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως IDs διαφανειών, ή δυναμικές τιμές placeholders, όπως η τρέχουσα ημερομηνία.

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

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/slides/el/python-net/compare-slides/).

## **Ορισμός Slide Master View ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε την ιδιότητα `last_view` στην παρουσίαση [ViewProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει το PowerPoint πρώτα. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση στην προβολή Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/slides/el/python-net/save-presentation/).

## **Αφαίρεση Αχρησιμοποίητων Master Slides**

Οι παρουσιάσεις μερικές φορές περιέχουν master slides που δεν χρησιμοποιούνται πια από καμία κανονική διαφάνεια. Η αφαίρεση των αχρησιμοποίητων masters μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε το `remove_unused` για να αφαιρέσετε αχρησιμοποίητα masters από τη συλλογή `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Μπορείτε επίσης να χρησιμοποιήσετε τη low‑code μέθοδο `remove_unused_master_slides` από την κλάση [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Ποια είναι η διαφορά μεταξύ slide master και layout slide;**

Ένα slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σ shapes και στυλ κειμένου. Ένα layout slide ανήκει σε ένα master slide και ορίζει μια συγκεκριμένη διάταξη των placeholders. Μια κανονική διαφάνεια χρησιμοποιεί ένα layout slide, έτσι κληρονομεί τόσο από το layout όσο και από το master.

**Μπορεί μια παρουσίαση να περιέχει πολλά slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλαπλά slide masters. Χρησιμοποιήστε πολλαπλά masters όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή σήμανση.

**Πρέπει να προσθέσω placeholders σε ένα master slide ή σε ένα layout slide;**

Στις περισσότερες περιπτώσεις, προσθέτετε placeholders σε layout slides. Τοποθετήστε κοινά οπτικά στοιχεία και κοινές μορφοποιήσεις στο master slide, ενώ τα placeholders περιεχομένου τοποθετούνται στα layout που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω ένα master slide που χρησιμοποιείται ακόμα;**

Όχι. Ένα master slide που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια. Πρώτα μεταφέρετε τις εξαρτημένες διαφάνειες σε layout κάτω από άλλο master, ή χρησιμοποιήστε μια μέθοδο καθαρισμού αχρησιμοποίητων masters που αφαιρεί μόνο τα masters που δεν χρησιμοποιούνται.