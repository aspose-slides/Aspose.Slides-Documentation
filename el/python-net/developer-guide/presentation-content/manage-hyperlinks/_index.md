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
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET, χρησιμοποιώντας παραδείγματα Python."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο της παρουσίασης με μια ιστοσελίδα ή μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Ανοίγει μια ιστοσελίδα από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Μεταβαίνει σε άλλη διαφάνεια, για παράδειγμα, από έναν πίνακα περιεχομένων.

Aspose.Slides for Python via .NET σας επιτρέπει να προσθέσετε αυτούς τους συνδέσμους, να ελέγξετε την εμφάνιση και τον ήχο τους, να ενημερώσετε τις ιδιότητές τους και να τους αφαιρέσετε. Τα παρακάτω παραδείγματα δείχνουν πώς να εργαστείτε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση σε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με τον [ελεύθερο διαδικτυακό επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να αντιστοιχίσετε μια διεύθυνση URL ιστοσελίδας σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αντιστοιχίσετε τον υπερσύνδεσμο καθορίζει την περιοχή που είναι κλικάριστη: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

Για παρουσιάσεις που περιέχουν σχετικούς υπερσυνδέσμους, δείτε το [Manage the Hyperlink Base](/slides/el/python-net/presentation-properties/#manage-the-hyperlink-base) για ανάγνωση, αλλαγή ή εκκαθάριση της βάσης σε επίπεδο εγγράφου.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με μια ιστοσελίδα, αντιστοιχίστε ένα [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) στην ιδιότητα [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικάριστο.

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

Αντιστοιχίστε μια URL στην ιδιότητα [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) του ορθογωνίου ώστε να γίνεται ολόκληρη η περιοχή του κλικάριστη. Η [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) παρέχει στους αναγνώστες μια υπόδειξη σχετικά με τον προορισμό όταν περνούν το ποντίκι πάνω από το ορθογώνιο. Οι ίδιες ιδιότητες ισχύουν για πλαίσια εικόνας, ήχου και βίντεο.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί το [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

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

Μπορείτε να αλλάξετε το χρώμα του συνδεδεμένου κειμένου, να αναπαράγετε ή να διακόψετε ήχο όταν ένας αναγνώστης ενεργοποιεί έναν σύνδεσμο και να ορίσετε τη συμβουλή εργαλείου που εμφανίζεται όταν τοποθετείται το ποντίκι.

### **Χρώμα**

Η ιδιότητα [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) του [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) καθορίζει αν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσύνδεσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Αυτή η δυνατότητα εισήχθη στο PowerPoint 2019· οι παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Σε αυτό το παράδειγμα, ορίζοντας το [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) στον πρώτο σύνδεσμο κάνει το κείμενό του κόκκινο. Ο δεύτερος σύνδεσμος διατηρεί το χρώμα υπερσυνδέσμου της παρουσίασης.

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

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει έναν ήχο που ήδη αναπαράγεται. Χρησιμοποιήστε τις παρακάτω ιδιότητες για να διαμορφώσετε αυτές τις συμπεριφορές:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) καθορίζει το ήχο που συσχετίζεται με τον υπερσύνδεσμο.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) ελέγχει αν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου Υπερσυνδέσμου**

Το κουμπί στην πρώτη διαφάνεια χρησιμοποιεί το [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) για να αναπαράγει ήχο από αρχείο WAV όταν ο αναγνώστης κάνει κλικ για να προχωρήσει. Στη δεύτερη διαφάνεια, ένα ξεχωριστό κουμπί χρησιμοποιεί το [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) για να σταματήσει την αναπαραγωγή και να διατηρήσει τον αναγνώστη σε αυτή τη διαφάνεια.

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

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο υπερσυνδέσμου του πρώτου σχήματος στη μνήμη μέσω του [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) και του [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

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

### **Ρυθμίσεις Συμβουλής Εργαλείου και Αλληλεπίδρασης**

Μπορείτε να ενημερώσετε τις παρακάτω ιδιότητες του [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) μετά την αντιστοίχιση ενός υπερσυνδέσμου σε κείμενο ή σχήμα:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) ορίζει το κείμενο που ένας θεατής μπορεί να εμφανίσει ως υπόδειξη για τον σύνδεσμο.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) προσδιορίζει το πλαίσιο-στόχο μέσα σε ένα γονικό HTML frameset, εφόσον εφαρμόζεται.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) ελέγχει αν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβλεπόμενων υπερσυνδέσμων.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) για να συλλέξετε containers υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα αλλάξετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) ή το [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

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

Για ανεπιφύλακτη αφαίρεση, το [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο εύρος με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη masters, layouts και notes, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Καθαρισμός Υπερσυνδέσμων Πριν την Αντικατάσταση Κειμένου SmartArt**

Όταν αντικαθιστάτε ένα παράγραφο σε υπάρχον node SmartArt, ο καθαρισμός των τμημάτων κειμένου του μπορεί να αφήσει ενεργό έναν παλιό υπερσύνδεσμο. Ανακτήστε την παράγραφο μέσω του [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/). Πριν καθαρίσετε τα τμήματά της, καλέστε το [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) μέσω του [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) στο πλαίσιο κειμένου του σχήματος node που εμφανίζει την παράγραφο. Αυτό αφαιρεί κάθε υπερσύνδεσμο σε εκείνο το πλαίσιο, συμπεριλαμβανομένων των συνδέσμων στα άλλα παραγράφους.

Στο `SmartArtHyperlink.pptx`, το τρίτο σχήμα στην πρώτη διαφάνεια είναι ένα γραφικό SmartArt. Το παράδειγμα αντικαθιστά την πρώτη παράγραφο του τέταρτου node. Σε αυτήν την παρουσίαση, το πρώτο σχήμα του node εμφανίζει εκείνη την παράγραφο.

Μετά την προσθήκη και των δύο τμημάτων, το παράδειγμα διαβάζει τη αποτελεσματική μορφοποίηση τους με το [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). Η αποτελεσματική ιδιότητα [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) επιστρέφει το νέο υπερσύνδεσμο για το πρώτο τμήμα και `None` για το δεύτερο.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, ελέγξτε τις διαδραστικές ενέργειές της καθώς και τους διαδικτυακούς της συνδέσμους. Το [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/), όχι μια επίπεδη λίστα συμβολοσειρών URL. Εξετάστε τόσο το [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) όσο και το [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) σε κάθε container. Είναι ανεξάρτητα: ο ίδιος container μπορεί να εκθέτει και τις δύο ενέργειες, έτσι μια πλήρης αναφορά χρειάζεται έως δύο σειρές ανά container.

Η σάρωση μόνο των υπερσυνδέσμων επιπέδου σχήματος μπορεί να παραλείψει συνδέσμους που είναι προσαρτημένοι σε τμήματα κειμένου. Ερωτήστε αντίθετα το κατάλληλο εύρος και διατηρήστε τα containers που επιστρέφονται ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτημα Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) διατίθεται μέσω των [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) και [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Κάθε εύρος υποστηρίζει τις ίδιες ερωτήσεις:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) επιστρέφει containers με ενέργεια κλικ.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) επιστρέφει containers με ενέργεια mouse‑over.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) επιστρέφει containers με μία ή και τις δύο ενέργειες.

Αυτό το παράδειγμα αντιστοιχεί ενέργειες κλικ και mouse‑over σε ένα σχήμα και το κείμενό του, και μια ενέργεια μακροεντολής σε ένα ξεχωριστό κουμπί. Συγκρίνει τα containers που επιστρέφονται από το [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) με τις μετρήσεις για κάθε τύπο ενεργοποίησης. Ένα ερώτημα πλαισίου κειμένου μετρά μόνο συνδέσμους στο κείμενο. Οι δικές του ενέργειες του σχήματος εμφανίζονται στα ερωτήματα διαφάνειας και παρουσίασης.

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

Για αυτό το παράδειγμα, τα ερωτήματα παρουσίασης και διαφάνειας αναφέρουν τρία containers κλικ, δύο containers mouse‑over και τρία containers με οποιαδήποτε ενέργεια. Το ερώτημα πλαισίου κειμένου αναφέρει ένα container σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από την πλοήγηση στο web:

| Τιμές | Σημασία για έλεγχο |
| --- | --- |
| `HYPERLINK` | Εξωτερικός υπερσύνδεσμος· εξετάστε το URL και το σχήμα του. |
| `JUMP_SPECIFIC_SLIDE` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο της προβολής. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Τερματισμός τρέχουσας παρουσίασης ή εκκίνηση προσαρμοσμένης παρουσίασης. |
| `START_MACRO` | Εκτέλεση μακροεντολής. |
| `START_PROGRAM` | Εκκίνηση προγράμματος. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από web URLs. |
| `START_STOP_MEDIA` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NO_ACTION`, `UNKNOWN` | Καμία ενέργεια πλοήγησης ή άγνωστη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς από το [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) και συγκεκριμένους εσωτερικούς προορισμούς από το [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές ενδέχεται να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι ο container δεν έχει ενέργεια. Διατηρήστε το [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) όταν διαφέρει από το κανονικοποιημένο URL και συμπεριλάβετε το [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Αυτό το παράδειγμα ανοίγει την παρουσίαση από το προηγούμενο παράδειγμα και γράφει μια εγγραφή JSON ανά ενέργεια. Χρησιμοποιεί το [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) για να συλλέξει containers σε κανονικές διαφάνειες, masters, layouts και notes, συμπεριλαμβανομένων των notes και handout masters όταν υπάρχουν. Ερωτά κάθε εύρος μία φορά ώστε να αποφευχθεί διπλή επεξεργασία, εφαρμόζει την πολιτική που περιγράφεται παρακάτω και ξανα ανοίγει την αποθηκευμένη παρουσίαση για να ελέγξει τόσο τις ενέργειες κλικ όσο και mouse‑over.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας με βάση το 1 και το [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) όπου είναι διαθέσιμο. Ο συλλέκτης διατηρεί τη διαφάνεια‑ιδιοκτήτη και το εύρος μαζί με κάθε επιστρεφόμενο container. Τα masters, τα layouts και τα notes δεν έχουν κανονικό δείκτη διαφάνειας και τα προσδιορίζουν με το εύρος τους. Τα containers σχήματος και τα containers μορφοποίησης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι containers διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε container λαμβάνει ένα τοπικό αναγνωριστικό αναφοράς ώστε οι δύο του δράσεις να μπορούν να συσχετιστούν.

Αυτή η αυστηρά περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς στόχους διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείου, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι απόφαση ασφαλείας του Aspose.Slides. Το μόνο HTTPS δεν εγγυάται εμπιστοσύνη: προσθέστε λιστες επιτρεπόμενων hosts και άλλους ελέγχους για την εφαρμογή σας. Και τα αρχικά και τα κανονικοποιημένα εξωτερικά URLs ελέγχονται. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, ο [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) του container υποστηρίζει τα [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) και [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Εδώ, οι μην επιτρεπόμενοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· οι άλλοι μη επιτρεπόμενοι κλικ και οι μη επιτρεπόμενες ενέργειες mouse‑over αφαιρούνται ανεξάρτητα. Ορίστε `replace_external_clicks` σε `False` για να αφαιρεθούν όλες οι παραβάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή πριν από την εκμετάλλευση.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια συντηρητική πολιτική ελέγχου PDF: σημαδεύει ενέργειες mouse‑over και οτιδήποτε άλλο εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως δυνητικά μη υποστηριζόμενα. Είναι μια υπόδειξη ελέγχου, όχι δοκιμή δυνατότητας ή εγγύηση ότι τα μη χαρακτηρισμένα links θα παραμείνουν στην εξαγωγή. Τα υποστηριζόμενα [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/) και [HTML](/slides/el/python-net/convert-powerpoint-to-html/) μπορεί να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προβολέα. Οι raster [images](/slides/el/python-net/convert-powerpoint-to-png/) και [video](/slides/el/python-net/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαδεύστε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

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
    # Ερώτηση κάθε εύρους διαφάνειας μία φορά, διατηρώντας τον ιδιοκτήτη του μαζί με κάθε container.
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

Με το παραπάνω εισερχόμενο δεδομένο, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος mouse‑over αρχείου και ο μακροεντολή κλικ αφαιρούνται, ενώ τα HTTPS links και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εμφανίζει μηδενικές απαγορευμένες ενέργειες. Ένα εισερχόμενο με απαγορευμένο εξωτερικό κλικ URL επίσης δοκιμάζει το κλαδί αντικατάστασης. Ένα container με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί την ενέργεια κλικ.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), που αφαιρεί και τις δύο ενεργοποιήσεις σε όλο το επιλεγμένο εύρος ανεξάρτητα από την πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, και δεν επαληθεύει εξαγόμενο αρχείο PDF ή HTML.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να συνδέσω σε μια ενότητα ή στην πρώτη διαφάνειά της;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μια μοναδική διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε την πρώτη διαφάνεια της ενότητας.

**Μπορώ να προσθέσω υπερσύνδεσμο σε στοιχεία master διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του master slide και των layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Τα υποστηριζόμενα εξαγώμενα PDF και HTML ενδέχεται να διατηρήσουν τους υπερσυνδέσμους· οι raster εικόνες και το βίντεο δεν μπορούν. Δείτε τις παραμέτρους εξαγωγής στο [Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων](#report-sanitize-and-verify-hyperlinks).