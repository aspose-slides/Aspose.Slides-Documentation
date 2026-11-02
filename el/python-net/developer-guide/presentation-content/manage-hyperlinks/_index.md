---
title: Διαχείριση Υπερσυνδέσεων Παρουσίασης σε Python
linktitle: Διαχείριση Υπερσυνδέσεων
type: docs
weight: 20
url: /el/python-net/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσύνδεσης
- δημιουργία υπερσύνδεσης
- μορφοποίηση υπερσύνδεσης
- αφαίρεση υπερσύνδεσης
- ενημέρωση υπερσύνδεσης
- υπερσύνδεση κειμένου
- υπερσύνδεση διαφάνειας
- υπερσύνδεση σχήματος
- υπερσύνδεση εικόνας
- υπερσύνδεση βίντεο
- μεταβλητή υπερσύνδεση
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσεων σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Python μέσω .NET, χρησιμοποιώντας παραδείγματα Python."
---
## **Εισαγωγή**

Μια υπερσύνδεση συνδέει το περιεχόμενο μιας παρουσίασης με έναν ιστότοπο ή μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσυνδέσεις συνήθως εξυπηρετούν δύο σκοπούς:

* Άνοιγμα ιστότοπου από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Πλοήγηση σε άλλη διαφάνεια, για παράδειγμα, από πίνακα περιεχομένων.

Το Aspose.Slides for Python μέσω .NET σάς επιτρέπει να προσθέτετε αυτές τις συνδέσεις, να ελέγχετε την εμφάνιση και τον ήχο τους, να ενημερώνετε τις ιδιότητές τους και να τις αφαιρείτε. Τα παραδείγματα παρακάτω δείχνουν πώς να εργάζεστε με υπερσυνδέσεις σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση σε υπερσυνδέσεις σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με τον [δωρεάν διαδικτυακό επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Προσθήκη Υπερσυνδέσεων URL**

Μπορείτε να αντιστοιχίσετε ένα URL ιστότοπου σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αντιστοιχίζετε την υπερσύνδεση καθορίζει την περιοχή που μπορεί να γίνει κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

Για παρουσιάσεις που περιέχουν σχετικές υπερσυνδέσεις, δείτε [Διαχείριση βάσης υπερσύνδεσης](/slides/el/python-net/presentation-properties/#manage-the-hyperlink-base) για ανάγνωση, αλλαγή ή εκκαθάριση της βάσης σε επίπεδο εγγράφου.

### **Προσθήκη Υπερσυνδέσεων URL σε Κείμενο**

Για να συνδέσετε κείμενο με έναν ιστότοπο, αντιστοιχίστε ένα [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) στην ιδιότητα [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα του κειμένου γίνεται κλικ.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Προσθήκη Υπερσυνδέσεων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικ-δυνατό, ορίστε την ιδιότητα [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/). Η υπερσύνδεση ανήκει στο ίδιο το αντικείμενο αντί σε τμήμα κειμένου μέσα σε αυτό.

Η ίδια προσέγγιση ισχύει για πλαίσια εικόνας, ήχου και βίντεο: αντιστοιχίστε την υπερσύνδεση στο πλαίσιο και ορίστε το [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) αν χρειάζεται.

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικ-δυνατό:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Χρήση Υπερσυνδέσεων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικές υπερσυνδέσεις επιτρέπουν στους αναγνώστες να μεταβαίνουν από έναν πίνακα περιεχομένων σε μια συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί το [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) για να συνδέσει το κείμενο «Page 2» στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Μορφοποίηση Υπερσυνδέσεων**

### **Χρώμα**

Η ιδιότητα [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) του [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) καθορίζει αν μια υπερσύνδεση χρησιμοποιεί το χρώμα υπερσύνδεσης της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Η δυνατότητα αυτή εισήχθη στο PowerPoint 2019· παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσεις κειμένου στην ίδια διαφάνεια. Η πρώτη χρησιμοποιεί κόκκινο χρώμα κειμένου, ενώ η δεύτερη διατηρεί το προεπιλεγμένο χρώμα υπερσύνδεσης.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Ήχος**

Μια υπερσύνδεση μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει ήχο που ήδη παίζει. Χρησιμοποιήστε τις παρακάτω ιδιότητες για να ρυθμίσετε αυτές τις συμπεριφορές:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) καθορίζει το ήχο που συνδέεται με την υπερσύνδεση.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) ελέγχει αν η ενεργοποίηση της υπερσύνδεσης σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου Υπερσύνδεσης**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάνεια. Το κλικ στο κουμπί αναπαράγει τον ήχο και μεταβαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα σε αυτή τη διαφάνεια σταματά τον προηγούμενο ήχο όταν γίνεται κλικ, χωρίς να εκτελεί ενέργεια πλοήγησης.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Εξαγωγή Ήχου Υπερσύνδεσης**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο υπερσύνδεσης του πρώτου σχήματος στη μνήμη μέσω των [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) και [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Ρυθμίσεις Tooltip και Αλληλεπίδρασης**

Μπορείτε να ενημερώσετε τις παρακάτω ιδιότητες του [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) μετά την αντιστοίχιση μιας υπερσύνδεσης σε κείμενο ή σχήμα:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) ορίζει το κείμενο που μπορεί να εμφανίσει ο θεατής ως υπόδειξη για τη σύνδεση.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) καθορίζει το πλαίσιο-στόχο μέσα σε ένα γονικό σύνολο πλαισίων HTML, εφόσον ισχύει.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) ελέγχει αν η ενεργοποίηση της σύνδεσης προσθέτει τον προορισμό της στη λίστα των προβληθέντων υπερσυνδέσεων.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) ελέγχει αν η υπερσύνδεση επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσεων από Παρουσιάσεις**

Χρησιμοποιήστε το [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) για να συλλέξετε τις δεσμευτικές μονάδες υπερσυνδέσεων, συμπεριλαμβανομένων των συνδέσεων τμημάτων κειμένου, πριν τις τροποποιήσετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) ή το [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί την αντίστοιχη ενέργεια ποντικιού.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Για ανεξάρτητη αφαίρεση, το [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο εύρος με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσεων**

Πριν τη διανομή μιας παρουσίασης, καταγράψτε τις διαδραστικές ενέργειές της καθώς και τις διαδικτυακές της συνδέσεις. Το [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/), όχι μια απλή λίστα συμβολοσειρών URL. Εξετάστε τόσο το [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) όσο και το [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) σε κάθε κοντέινερ. Είναι ανεξάρτητα: το ίδιο κοντέινερ μπορεί να εκθέτει και τις δύο ενέργειες, επομένως μια πλήρης αναφορά χρειάζεται έως δύο γραμμές ανά κοντέινερ.

Η σάρωση μόνο των υπερσυνδέσεων σε επίπεδο σχήματος μπορεί να παραλείψει συνδέσεις που είναι προσαρτημένες σε τμήματα κειμένου. Αντί αυτού, ερωτήστε το κατάλληλο εύρος και διατηρήστε τα επιστρεφόμενα κοντέινερ ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτηση σε Εύρη Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) είναι διαθέσιμη μέσω των [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) και [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Κάθε εύρος υποστηρίζει τις ίδιες ερωτήσεις:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) επιστρέφει κοντέινερ με ενέργεια κλικ.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) επιστρέφει κοντέινερ με ενέργεια ποντικιού.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) επιστρέφει κοντέινερ με μία ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με μια εξωτερική σύνδεση κλικ, μια σύνδεση ποντικιού σε αρχείο, εσωτερική πλοήγηση διαφανειών, μια σύνδεση κειμένου ποντικιού και μια ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι ίδιες τρεις ερωτήσεις λειτουργούν σε κάθε εύρος· οι μετρήσεις περιγράφουν κοντέινερ, όχι το σύνολο των ενέργειας. Το εύρος πλαισίου κειμένου εξαιρεί τις δικές του συνδέσεις του περιβάλλοντος σχήματος.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας καταφέρνουν τρία κοντέινερ κλικ, δύο κοντέινερ ποντικιού και τρία κοντέινερ με μία ή και τις δύο ενέργειες. Η ερώτηση πλαισίου κειμένου αναφέρει ένα κοντέινερ σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από την πλοήγηση στο web:

| Τιμές | Σημασία για έλεγχο |
| --- | --- |
| `HYPERLINK` | Εξωτερική υπερσύνδεση· ελέγξτε το URL και το σχήμα του. |
| `JUMP_SPECIFIC_SLIDE` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο της παρουσίασης. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Τερματισμός τρέχουσας παρουσίασης ή έναρξη προσαρμοσμένης παρουσίασης. |
| `START_MACRO` | Εκτέλεση μακροεντολής. |
| `START_PROGRAM` | Εκκίνηση προγράμματος. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από τα URLs του web. |
| `START_STOP_MEDIA` | Έναρξη ή διακοπή αναπαραγωγής μέσου. |
| `NO_ACTION`, `UNKNOWN` | Καμία ενέργεια πλοήγησης ή μη αναγνωρίσιμη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε τους εξωτερικούς προορισμούς από το [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) και συγκεκριμένους εσωτερικούς προορισμούς από το [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Οι εσωτερικές ενέργειες και εντολές ενσωματωμένες μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το κοντέινερ δεν έχει ενέργεια. Διατηρήστε το [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσεων**

Το παρακάτω παράδειγμα Python διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει και τους δύο τύπους ενεργοποίησης. Συλλέγει τα κοντέινερ πριν τα αλλάξει και ερωτά κάθε εύρος διαφάνειας μία φορά για να αποφύγει διπλή επεξεργασία. Οι ερωτήσεις παρουσίασης καλύπτουν τις συνηθισμένες διαφάνειες· για έναν πλήρη κατάλογο πακέτου, το παράδειγμα ερευνά τις συνηθισμένες διαφάνειες, τα master, τα layout, τις σημειώσεις και τα master σημειώσεων και φυλλαδίου όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας που ξεκινά από το 1 και το [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) όπου είναι διαθέσιμο. Ο συλλέκτης διατηρεί τη διαφάνεια και το εύρος ιδιοκτήτη μαζί με κάθε επιστρεφόμενο κοντέινερ. Τα master, τα layout και οι σημειώσεις δεν έχουν κανονικό δείκτη διαφάνειας και ταυτοποιούνται από το εύρος τους. Τα κοντέινερ σχήματος και τα κοντέινερ μορφοποίησης τμημάτων κειμένου επισημαίνονται χωριστά· άλλοι τύποι κοντέινερ διατηρούν το όνομα τύπου εκτέλεσής τους. Κάθε κοντέινερ λαμβάνει ένα τοπικό αναγνωριστικό αναφοράς ώστε οι δύο του ενέργειες να μπορούν να συσχετιστούν.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα URLs HTTPS και έγκυρους εσωτερικούς προορισμούς διαφανειών. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι απόφαση ασφαλείας του Aspose.Slides. Το μόνο HTTPS δεν εγγυάται εμπιστοσύνη· προσθέστε λίστες επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους στην εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει τα μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για διόρθωση, ο [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) του κοντέινερ υποστηρίζει τα [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) και [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Εδώ, οι απαγορευμένες εξωτερικές συνδέσεις κλικ αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· άλλες απαγορευμένες συνδέσεις κλικ και απαγορευμένες ενέργειες ποντικιού αφαιρούνται ανεξάρτητα. Ορίστε το `replace_external_clicks` σε `False` για να αφαιρέσετε όλες τις παραβιάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης ιδιοκτησίας εφαρμογής πριν από την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια συγκρατημένη πολιτική ελέγχου PDF: σημαδεύει τις ενέργειες ποντικιού και ό,τι εκτός από μια εξωτερική σύνδεση ή συγκεκριμένο άλμα διαφάνειας ως ενδεχόμενα μη υποστηριζόμενα. Είναι μια υπόδειξη ελέγχου, όχι δοκιμή δυνατότητας ή εγγύηση ότι οι μη σημειωμένες συνδέσεις θα παραμείνουν στην εξαγωγή. Οι υποστηριζόμενες εξαγωγές σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/) και [HTML](/slides/el/python-net/convert-powerpoint-to-html/) μπορεί να διατηρούν υπερσυνδέσεις, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προβολέα. Τα raster [images](/slides/el/python-net/convert-powerpoint-to-png/) και [video](/slides/el/python-net/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικές υπερσυνδέσεις· σημειώστε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Query each slide scope once, retaining its owner with each container.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Με το εισαγόμενο αρχείο που δημιουργήθηκε παραπάνω, η αναφορά περιέχει πέντε γραμμές ενεργειών. Η σύνδεση ποντικιού σε αρχείο και η ενέργεια κλικ μακροεντολής αφαιρούνται, ενώ οι σύνδεσμοι HTTPS και η εσωτερική πλοήγηση διαφανειών παραμένουν. Η επαλήθευση εμφανίζει μηδέν απαγορευμένες ενέργειες. Ένα είσοδο με απαγορευμένο εξωτερικό κλικ URL επίσης εκτελεί το κλαδί αντικατάστασης. Ένα κοντέινερ με επιτρεπόμενο κλικ και απαγορευμένο ποντίκι διατηρεί την ενέργεια κλικ του.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλο το επιλεγμένο εύρος ανεξαρτήτως πολιτικής. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσύνδεσης· δεν αφαιρεί ενσωματωμένα έργα VBA, αντικείμενα OLE ή άλλου ενεργού περιεχομένου, και δεν επαληθεύει ένα εξαχθέν PDF ή HTML αρχείο.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να συνδέσω σε μια ενότητα ή στην πρώτη της διαφάνεια;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά μια εσωτερική υπερσύνδεση στοχεύει σε μια μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε μια ενότητα, συνδέστε στην πρώτη διαφάνεια της ενότητας.

**Μπορώ να επισυνάψω μια υπερσύνδεση σε στοιχεία master διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του master διαφάνειας και των layout υποστηρίζουν υπερσυνδέσεις. Οι συνδέσεις σε αυτά τα στοιχεία είναι διαθέσιμες κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσυνδέσεις κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές σε PDF και HTML μπορεί να διατηρήσουν τις υπερσυνδέσεις· τα raster εικόνα και βίντεο δεν μπορούν. Δείτε τις παραμέτρους εξαγωγής στο [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).