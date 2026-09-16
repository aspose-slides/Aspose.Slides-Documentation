---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε Python
linktitle: Διαχείριση Υπερσυνδέσμων
type: docs
weight: 20
url: /el/python-net/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσυνδέσμου
- δημιουργία υπερσυνδέσμου
- μορφοποίηση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Python μέσω .NET, χρησιμοποιώντας παραδείγματα Python."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο μιας παρουσίασης με έναν ιστότοπο ή μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Ανοίξτε έναν ιστότοπο από κείμενο, σχήμα ή πλαίσιο πολυμέσας.
* Πλοήγηση σε άλλη διαφάνεια, για παράδειγμα από περιεχόμενα.

Aspose.Slides for Python via .NET σας επιτρέπει να προσθέτετε αυτούς τους συνδέσμους, να ελέγχετε την εμφάνιση και τον ήχο τους, να ενημερώνετε τις ιδιότητές τους και να τους αφαιρείτε. Τα παραδείγματα παρακάτω δείχνουν πώς να εργαστείτε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση σε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με τον [δωρεάν διαδικτυακό επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/el/editor).
{{% /alert %}}

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να αντιστοιχίσετε μια διεύθυνση URL ιστότοπου σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο ανατίθεται ο υπερσύνδεσμος καθορίζει την περιοχή που μπορεί να κλικαριστεί: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με έναν ιστότοπο, αναθέστε ένα [Hyperlink](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/) στην ιδιότητα [hyperlink_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/hyperlink_click/) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικαρίσιμο.

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

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικαρίσιμο, ορίστε την ιδιότητα [hyperlink_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/hyperlink_click/) του. Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε τμήμα κειμένου μέσα σε αυτό.

Η ίδια προσέγγιση ισχύει για πλαίσια εικόνας, ήχου και βίντεο: αναθέστε τον υπερσύνδεσμο στο πλαίσιο και ορίστε το [tooltip](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/tooltip/) του συνδέσμου εάν χρειάζεται.

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικαρίσιμο:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταπηδούν από έναν πίνακα περιεχομένων σε μια συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί το [set_internal_hyperlink_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

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

## **Μορφοποίηση Υπερσυνδέσμων**

### **Χρώμα**

Η ιδιότητα [color_source](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/color_source/) του [Hyperlink](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/) καθορίζει εάν ο υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Η δυνατότητα αυτή εισήχθηκε στο PowerPoint 2019· οι παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο γέμισμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

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

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιηθεί ή να σταματήσει ήχο που ήδη παίζει. Χρησιμοποιήστε τις παρακάτω ιδιότητες για να ρυθμίσετε αυτές τις συμπεριφορές:

- [Hyperlink.sound](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/sound/) ορίζει το ήχο που συνδέεται με τον υπερσύνδεσμο.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/stop_sound_on_click/) ελέγχει εάν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου Υπερσυνδέσμου**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάνεια. Κάνοντας κλικ στο κουμπί παίζει ο ήχος και πηγαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα σε αυτή τη διαφάνεια σταματά τον προηγούμενο ήχο όταν κλικάρεται, χωρίς να εκτελεί ενέργεια πλοήγησης.

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

#### **Εξαγωγή Ήχου Υπερσυνδέσμου**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει το ήχο του υπερσυνδέσμου του πρώτου σχήματος στη μνήμη μέσω των ιδιοτήτων [sound](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/sound/) και [binary_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/audio/binary_data/).

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

### **Ρυθμίσεις Συμβουλλήματος (Tooltip) και Αλληλεπίδρασης**

Μπορείτε να ενημερώσετε τις ακόλουθες ιδιότητες του [Hyperlink](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/) μετά την ανάθεση ενός υπερσυνδέσμου σε κείμενο ή σχήμα:

- [tooltip](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/tooltip/) ορίζει το κείμενο που ένας θεατής μπορεί να εμφανίσει ως υπόδειξη για το σύνδεσμο.
- [target_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/target_frame/) καθορίζει το πλαίσιο προορισμού μέσα σε ένα γονικό σύνολο πλαισίων HTML, όταν ισχύει.
- [history](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/history/) ελέγχει εάν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβληθέντων υπερσυνδέσμων.
- [highlight_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/highlight_click/) ελέγχει εάν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [get_any_hyperlinks](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) για να συλλέξετε τα κοντέινερ υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα τροποποιήσετε. Το παρακάτω παράδειγμα αφαιρεί και τις δύο μορφές ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [remove_hyperlink_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) ή το [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί την αντίστοιχη ενέργεια ποντικιού.

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

Για αδιάσπαστη αφαίρεση, το [remove_all_hyperlinks](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) αφαιρεί και τις δύο μορφές ενεργοποίησης στο επιλεγμένο πεδίο με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Απογραφής Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, κάντε απόρτηση των διαδραστικών ενεργειών της καθώς και των συνδέσμων web. Το [get_any_hyperlinks](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/el/python-net/aspose.slides/ihyperlinkcontainer/), όχι μια επίπεδη λίστα συμβολοσειρών URL. Εξετάστε τόσο το [hyperlink_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) όσο και το [hyperlink_mouse_over](https://reference.aspose.com/slides/el/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) σε κάθε κοντέινερ. Είναι ανεξάρτητα· ο ίδιος κοντέινερ μπορεί να εκθέτει και τις δύο ενέργειες, έτσι μια πλήρης αναφορά χρειάζεται έως δύο γραμμές ανά κοντέινερ.

Η σάρωση μόνο των υπερσυνδέσμων επιπέδου σχήματος μπορεί να χάσει συνδέσμους που είναι επισυναπτόμενοι σε τμήματα κειμένου. Εκτελέστε ερώτηση στο κατάλληλο πεδίο και διατηρήστε τα επιστρεφόμενα κοντέινερ ώστε αργότερα να μπορείτε να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτηση Παρουσίασης, Διαφάνειας και Πεδίων Κειμένου**

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/) είναι διαθέσιμη μέσω των ιδιοτήτων [Presentation.hyperlink_queries](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/hyperlink_queries/) και [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/hyperlink_queries/). Κάθε πεδίο υποστηρίζει τις ίδιες ερωτήσεις:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) επιστρέφει κοντέινερ με ενέργεια κλικ.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) επιστρέφει κοντέινερ με ενέργεια ποντικιού.
- [get_any_hyperlinks](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) επιστρέφει κοντέινερ με μία ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με έναν εξωτερικό σύνδεσμο κλικ, έναν σύνδεσμο αρχείου ποντικιού, εσωτερική πλοήγηση διαφάνειας, έναν σύνδεσμο κειμένου ποντικιού και μια ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι τρεις ερωτήσεις λειτουργούν σε κάθε πεδίο· οι μετρήσεις περιγράφουν κοντέινερ, όχι σύνολα ενεργειών. Το πεδίο πλαισίου κειμένου εξαιρεί τους δικούς του συνδέσμους.

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

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας αναφέρουν τρία κοντέινερ κλικ, δύο κοντέινερ ποντικιού και τρία κοντέινερ με οποιαδήποτε ενέργεια. Η ερώτηση πλαισίου κειμένου αναφέρει ένα κοντέινερ σε κάθε κατηγορία.

### **Κατάταξη Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [Hyperlink.action_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/action_type/) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από την πλοήγηση στο web:

| Τιμές | Σημασία για έλεγχο |
| --- | --- |
| `HYPERLINK` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JUMP_SPECIFIC_SLIDE` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο της παρουσίασης. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Λήξη της τρέχουσας προβολής ή εκκίνηση προσαρμοσμένης προβολής. |
| `START_MACRO` | Εκτέλεση μακροεντολής. |
| `START_PROGRAM` | Εκκίνηση προγράμματος. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από URLs web. |
| `START_STOP_MEDIA` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NO_ACTION`, `UNKNOWN` | Καμία ενέργεια πλοήγησης ή ανεπτυγμένη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς από το [external_url](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/external_url/) και συγκεκριμένους εσωτερικούς προορισμούς από το [target_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/target_slide/). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές ενδέχεται να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι ο κοντέινερ δεν έχει ενέργεια. Διατηρήστε το [external_url_original](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/external_url_original/) όταν διαφέρει από το κανονικοποιημένο URL και συμπεριλάβετε το [tooltip](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/tooltip/) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Το παρακάτω παράδειγμα Python διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει ξανά και τις δύο μορφές ενεργοποίησης. Συλλέγει κοντέινερ πριν τα αλλάξει και ερωτά κάθε πεδίο διαφάνειας μία φορά για να αποφύγει διπλό επεξεργασία. Οι ερωτήσεις παρουσίασης καλύπτουν τις κανονικές διαφάνειες· για απογραφή σε όλο το πακέτο, το παράδειγμα ερωτά κανονικές διαφάνειες, master, layout, σημειώσεις και τους master σημειώσεων και υποδείγματος όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας με βάση το 1 και το [slide_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/slide_id/) όπου είναι διαθέσιμο. Ο συλλέκτης διατηρεί τη διαφάνεια-ιδιοκτήτη και το πεδίο μαζί με κάθε επιστρεφόμενο κοντέινερ. Οι master, layout και σημειώσεις δεν έχουν δείκτη κανονικής διαφάνειας και ταυτοποιούνται από το πεδίο τους. Τα κοντέινερ σχήματος και τα κοντέινερ μορφοποίησης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι κοντέινερ διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε κοντέινερ λαμβάνει ένα τοπικό ID αναφοράς ώστε οι δύο του ενέργειες να μπορούν να συσχετιστούν.

Αυτή η αυστηρή πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείου, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλες σχεδίες URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι απόφαση ασφαλείας του Aspose.Slides. Το HTTPS μόνο του δεν εγγυάται εμπιστοσύνη· προσθέστε λιστές επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, ο [hyperlink_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) του κοντέινερ υποστηρίζει τα [set_external_hyperlink_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) και [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· άλλες απαγορευμένες ενέργειες κλικ και ποντικιού αφαιρούνται ανεξάρτητα. Ορίστε το `replace_external_clicks` σε `False` για να αφαιρέσετε όλες τις παραβάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή πριν την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί συντηρητική πολιτική ελέγχου PDF: σημαδεύει ενέργειες ποντικού και οτιδήποτε άλλο εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένη πηδήμα διαφάνειας ως ενδεχομένως μη υποστηριζόμενο. Είναι υπόδειξη ελέγχου, όχι δοκιμή ικανοτήτων ή εγγύηση ότι οι μη σημειωμένες συνδέσεις θα παραμείνουν μετά την εξαγωγή. Τα υποστηριζόμενα εξαγωγικά μορφάτα [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/) και [HTML](/slides/el/python-net/convert-powerpoint-to-html/) μπορεί να διατηρήσουν τους υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προβολέα. Τα raster [images](/slides/el/python-net/convert-powerpoint-to-png/) και [video](/slides/el/python-net/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαδέψτε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

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
    # Εκτελέστε ερώτηση σε κάθε επίπεδο διαφάνειας μία φορά, διατηρώντας τον ιδιοκτήτη του με κάθε κοντέινερ.
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

Με το παραπάνω αρχείο εισόδου, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος αρχείου ποντικού και το κλικ μακροεντολής αφαιρούνται, ενώ οι HTTPS σύνδεσμοι και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εκτυπώνει μηδέν απαγορευμένες ενέργειες. Ένα αρχείο εισόδου που περιέχει απαγορευμένο εξωτερικό URL κλικ επίσης ενεργοποιεί το κλάδο αντικατάστασης. Ένα κοντέινερ με επιτρεπόμενο κλικ και απαγορευμένο ποντίκι διατηρεί τη δράση κλικ του.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [remove_all_hyperlinks](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), το οποίο αφαιρεί και τις δύο μορφές ενεργοποίησης σε όλο το επιλεγμένο πεδίο ανεξάρτητα από την πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες των υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, και δεν επαληθεύει ένα εξαγόμενο αρχείο PDF ή HTML.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να συνδέσω με μια ενότητα ή τη πρώτη διαφάνειά της;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μια μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση προς μια ενότητα, συνδέστε τη με την πρώτη διαφάνεια της ενότητας.

**Μπορώ να προσθέσω υπερσύνδεσμο σε στοιχεία κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία της κύριας διαφάνειας και των layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν τον αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Τα υποστηριζόμενα εξαγώγια PDF και HTML ενδέχεται να διατηρήσουν τους υπερσυνδέσμους· οι εικόνες raster και τα βίντεο δεν μπορούν. Δείτε τις παραμέτρους εξαγωγής στο [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).