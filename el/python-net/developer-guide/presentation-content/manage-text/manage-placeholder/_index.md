---
title: Διαχείριση Συμπληρωματών Παρουσίασης σε Python
linktitle: Διαχείριση Συμπληρωματών
type: docs
weight: 10
url: /el/python-net/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κράτησης κειμένου
- σύμβολο κράτησης εικόνας
- σύμβολο κράτησης διαγράμματος
- σύμβολο κράτησης περιεχομένου
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να εξετάζετε και να επεξεργάζεστε τα σύμβολα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομικότητα των placeholder με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που κρατά μια θέση για ένα συγκεκριμένο είδος περιεχομένου σε ένα πρότυπο παρουσίασης. Συνηθισμένα παραδείγματα είναι οι placeholders τίτλου, κειμένου, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένα placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις του από μια διαφάνεια διάταξης ή κύρια διαφάνεια.

Το Aspose.Slides εκθέτει πληροφορίες placeholder μέσω της ιδιότητας [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). Η ιδιότητα επιστρέφει ένα αντικείμενο [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) ή `None` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) για να καθορίσετε τι προορίζεται να περιέχει το placeholder.

Η κλάση του σχήματος παραμένει σημαντική αφού γνωρίζετε τον τύπο του placeholder:

- Ένας κενός placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου συνήθως αντιπροσωπεύεται από ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- Ένας γεμάτος placeholder εικόνας μπορεί να αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- Ένας γεμάτος placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- Ένας placeholder περιεχομένου μπορεί να περιέχει διάφορα είδη περιεχομένου. Ελέγξτε τόσο το [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) όσο και την κλάση σχήματος χρόνου εκτέλεσης αντί να υποθέτετε ότι κάθε placeholder είναι ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) περιγράφει το ρόλο ενός placeholder· δεν εγγυάται την κλάση σχήματος χρόνου εκτέλεσης. Πάντα να κάνετε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε κείμενο, εικόνα, διάγραμμα, πίνακα ή ειδικά μέλη πολυμέσων.
{{% /alert %}}

## **Κατανόηση Κληρονόμησης Placeholder**

Τα placeholders δημιουργούν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders σε επίπεδο master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από την κύρια διαφάνεια.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για εκείνη τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) για να μετακινηθείτε ένα επίπεδο προς τα πάνω σε αυτή την ιεραρχία. Ένα placeholder διαφάνειας συνήθως επιστρέφει το placeholder της διάταξής του· ένα placeholder διάταξης μπορεί να επιστρέψει το placeholder του master. Η μέθοδος επιστρέφει `None` όταν το σχήμα δεν έχει βασικό placeholder.

Το παρακάτω παράδειγμα απαριθμεί τα placeholders στην πρώτη διαφάνεια και αναφέρει τα βασικά τους placeholders:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Η επεξεργασία ενός placeholder σε μια κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική αντικατάσταση για εκείνη τη διαφάνεια. Η επεξεργασία της σχετιζόμενης διάταξης ή master μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό κανονικό σχήμα δεν έχει βασικό placeholder και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Κατάργηση Κατάστασης Placeholder**

Κατά την προσαρμογή ενός προτύπου, χρησιμοποιήστε το [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) για να διατηρήσετε ένα υπάρχον αντικείμενο ως κανονικό σχήμα. Η ιδιότητα [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) του γίνεται `None`, αλλά το σχήμα παραμένει στη συλλογή της διαφάνειας. Αντίθετα, το [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) διαγράφει το σχήμα από αυτή τη συλλογή.

Το παρακάτω παράδειγμα απαιτεί το `template.pptx` με τουλάχιστον μία διαφάνεια και ένα μη κενό placeholder κειμένου στην πρώτη διαφάνεια. Χρησιμοποιήστε ένα placeholder με μορφοποίηση που κληρονομείται από τη διάταξη ή το master για να δείτε το αποτέλεσμα της κατάργησης της σχέσης. Το παράδειγμα ελέγχει ότι το ίδιο σχήμα παραμένει, καλεί ξανά τη μέθοδο στο πλέον κανονικό σχήμα και αποθηκεύει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Η κατάργηση της κατάστασης placeholder δεν διατηρεί αυτόματα τις κληρονομημένες ρυθμίσεις εμφάνισης. Το παρακάτω παράδειγμα αφήνει σκόπιμα αυτές τις ρυθμίσεις αμετάβλητες, οπότε η έξοδος μπορεί να φαίνεται διαφορετικά. Ένα σχήμα του οποίου η θέση και το μέγεθος κληρονομούνται πλήρως μπορεί να έχει μηδενικές συντεταγμένες και διαστάσεις μετά την κλήση και να γίνει αόρατο παρόλο που παραμένει στη συλλογή.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Καλώντας τη μέθοδο σε ένα κανονικό σχήμα δεν έχει καμία επίδραση.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Για ένα ταιριαστό placeholder, και οι τρεις έλεγχοι εκτυπώνουν `True`. Το κείμενο παραμένει, αλλά η κληρονομημένη θέση, μέγεθος, περιστροφή, γραμματοσειρά, στοίχιση παραγράφου, περιθώρια πλαισίου κειμένου, κατακόρυφη αγκύρωση, γεμίσματα και ρυθμίσεις γραμμής μπορεί να αλλάξουν όταν η σχέση του placeholder αφαιρεθεί. Για παράδειγμα, η κληρονομημένη μορφοποίηση τίτλου μπορεί να επανέλθει σε απλή μορφοποίηση κειμένου. Δείτε το [Slide Layout](/slides/el/python-net/slide-layout/) για περισσότερα σχετικά με τις διατάξεις.

Για να διατηρήσετε την προοριζόμενη εμφάνιση, καταγράψτε τη λύση θέση, μέγεθος και περιστροφή πριν την κλήση, και αντιγράψτε τις απαιτούμενες τιμές αποτελεσματικής μορφοποίησης σε ξεχωριστές μεταβλητές. Ανακτήστε αυτές τις τιμές μέσω των [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), και [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Μην βασίζεστε μόνο στα αντικείμενα αποτελεσματικής μορφοποίησης, καθώς οι τιμές μορφοποίησης κειμένου τους μπορούν να αλλάξουν μετά την αφαίρεση της σχέσης. Εφαρμόστε ρητά τις καταγεγραμμένες τιμές στο κανονικό σχήμα μετά, συμπεριλαμβανομένης της οικογένειας γραμματοσειράς, μεγέθους, στυλ, χρώματος, ρυθμίσεων παραγράφου, ρυθμίσεων πλαισίου κειμένου, γεμίσματος και γραμμής που χρησιμοποιεί το πρότυπό σας.

Η κληρονομημένη γεωμετρία σχήματος μπορεί επίσης να χρειάζεται να οριστεί ρητά μέσω του [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). Για ένα ορθογώνιο placeholder κειμένου, αυτό σημαίνει την ανάθεση του [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); η αποκατάσταση μόνο του γεμίσματος και της γραμμής ίσως να μην επαναφέρει το ορατό ορθογώνιο. Τα πρότυπα με επιπλέον εφέ ή πιο σύνθετη μορφοποίηση απαιτούν επίσης τη διαχείριση αυτών των ρυθμίσεων.

## **Αλλαγή Κειμένου σε Placeholder**

Τα placeholders τίτλου, κεντραρισμένου τίτλου, υποτίτλου, σώματος και κειμένου συνήθως υποστηρίζουν κείμενο. Ελέγξτε για [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) πριν χρησιμοποιήσετε την ιδιότητά του [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/).

Αυτό το παράδειγμα ενημερώνει το πρώτο placeholder τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Αυτό το μοτίβο αποτρέπει την αντιμετώπιση των placeholders εικόνας, διαγράμματος, πίνακα ή πολυμέσων ως αντικείμενα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Επιπλέον, προσδιορίζει το placeholder με βάση τον σκοπό του αντί να εξαρτάται από έναν ευαίσθητο δείκτη σχήματος.

## **Ορισμός Κειμένου Prompt σε Διάταξη**

Το κείμενο prompt είναι η οδηγία κατά το σχεδιασμό που εμφανίζεται σε ένα κενό placeholder, όπως *Click to add title*. Ορίστε προσαρμοσμένο κείμενο prompt στο placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σχήματος μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) και επαναλάβετε πάνω από τα [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

Το παρακάτω παράδειγμα αλλάζει τα prompts τίτλου και υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Το κείμενο prompt δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, το prompt δεν εμφανίζεται πλέον. Η αλλαγή ενός prompt επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις που πρέπει να αντιμετωπιστούν:

- Εάν το placeholder εικόνας είναι ήδη γεμάτο και αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), αντικαταστήστε την εικόνα μέσω του [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) και του [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Εάν παραμένει κενό placeholder, προσθέστε ένα picture frame στις συντεταγμένες του placeholder με το [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) και αφαιρέστε το κενό placeholder.

Το επόμενο παράδειγμα υποστηρίζει και τις δύο περιπτώσεις και αποθηκεύει την παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό picture frame, όχι ένα νέο placeholder, επειδή το [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) είναι μόνο για ανάγνωση. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά που σχετίζεται με το placeholder. Εάν η διατήρηση της σχέσης του placeholder είναι απαραίτητη, προετοιμάστε και γεμίστε το placeholder στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτον [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνες, δείτε το [Manage Picture Frames](/slides/el/python-net/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο picture frame ή στο picture fill, όχι στα μεταδεδομένα του placeholder.

## **Εργασία με Placeholder Διαγράμματος και Περιεχομένου**

Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). Αυτό το παράδειγμα εντοπίζει τέτοιο διάγραμμα και μέσω του τύπου placeholder και της κλάσης χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Ένα γενικό placeholder περιεχομένου συνήθως έχει [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινήτης για πολλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα, εικόνες και πολυμέσα. Αφού γεμίσει, εξετάστε την πραγματική κλάση σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εμφανίζουν [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), ή [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει ένα κενό placeholder [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) σε [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) απλώς αλλάζοντας το [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); ο τύπος είναι μόνο για ανάγνωση. Για να γεμίσετε ένα κενό διάγραμμα ή περιοχή περιεχομένου προγραμματιστικά, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και έπειτα αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Το προστιθέμενο διάγραμμα είναι ένα κανονικό τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα εξειδικευμένα [chart management articles](/slides/el/python-net/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του φύλλου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, αναζητεί στην πρώτη διαφάνεια είτε ένα placeholder τίτλου είτε εικόνας, ελέγχει τους τύπους του placeholder και του σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα σκόπιμα αποφεύγει την υπόθεση ενός δείκτη σχήματος ή την αντιμετώπιση κάθε placeholder ως της ίδιας κλάσης σχήματος:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Τι είναι ένα βασικό placeholder;**

Ένα βασικό placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στο master από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) για να το ανακτήσετε. Ένα κανονικό τοπικό σχήμα επιστρέφει `None` επειδή δεν αποτελεί μέρος της ιεραρχίας του placeholder.

**Μπορώ να αλλάξω όλους τους τίτλους των διαφανειών επεξεργάζομαι ένα placeholder διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομημένη μορφοποίηση ή το κείμενο prompt μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε το πραγματικό κείμενο τίτλου σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι τα placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο κατάλληλο επίπεδο διαφάνειας, διάταξης, master, σημειώσεων ή εγχειριδίου. Δείτε το [Manage Presentation Header and Footer](/slides/el/python-net/presentation-header-and-footer/) για πλήρη παραδείγματα.