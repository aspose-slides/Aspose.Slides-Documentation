---
title: Διαχείριση Συμβόλων Κράτησης Παρουσίασης σε Python
linktitle: Διαχείριση Συμβόλων Κράτησης
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
description: "Μάθετε πώς να επιθεωρείτε και να επεξεργάζεστε σύμβολα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοήσετε την κληρονομικότητα των συμβόλων κράτησης με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που διατηρεί θέση για ένα συγκεκριμένο είδος περιεχομένου σε ένα πρότυπο παρουσίασης. Κοινά παραδείγματα είναι placeholders τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα κανονικό σχήμα, ένα placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή από μια κύρια διαφάνεια.

Aspose.Slides εκθέτει τις πληροφορίες του placeholder μέσω της ιδιότητας [Shape.placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/placeholder/). Η ιδιότητα επιστρέφει ένα αντικείμενο [Placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholder/) ή `None` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [Placeholder.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholder/type/) για να προσδιορίσετε τι προορίζεται να περιέχει το placeholder.

Η κλάση του σχήματος εξακολουθεί να είναι σημαντική αφού γνωρίζετε τον τύπο του placeholder:

- Ένα κενό placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου αντιπροσωπεύεται συνήθως από ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
- Ένα γεμάτο placeholder εικόνας μπορεί να αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/).
- Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/).
- Ένα placeholder περιεχομένου μπορεί να περιέχει πολλαπλά είδη περιεχομένου. Ελέγξτε τόσο το [Placeholder.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholder/type/) όσο και την κλάση του σχήματος σε χρόνο εκτέλεσης, αντί να υποθέτετε ότι κάθε placeholder είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholder/type/) περιγράφει τον ρόλο του placeholder· δεν εγγυάται την κλάση του σχήματος σε χρόνο εκτέλεσης. Πάντα κάντε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή πολυμέσων.
{{% /alert %}}

## **Κατανόηση Κληρονομικότητας Συμβόλων Κράτησης**

Τα placeholders σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders επιπέδου master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από το master.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για εκείνη τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [Shape.get_base_placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_base_placeholder/) για να μεταβείτε ένα επίπεδο πάνω στην ιεραρχία. Ένα placeholder διαφάνειας συνήθως επιστρέφει το αντίστοιχο placeholder της διάταξης· ένα placeholder διάταξης μπορεί να επιστρέψει το αντίστοιχο placeholder του master. Η μέθοδος επιστρέφει `None` όταν το σχήμα δεν έχει βασικό placeholder.

Το παρακάτω παράδειγμα παραθέτει τα placeholders στην πρώτη διαφάνεια και αναφέρει τα βασικά τους placeholders:

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

Η επεξεργασία ενός placeholder σε μια κανονική διαφάνεια δημιουργεί ή τροποποιεί μια τοπική παρακάμψη για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή του master μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό κανονικό σχήμα δεν έχει βασικό placeholder και δεν αρχίζει να κληρονομεί απλώς επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αλλαγή Κειμένου σε Placeholder**

Τα placeholders τίτλου, κεντραρισμένου τίτλου, υπότιτλου, σώματος και κειμένου υποστηρίζουν κανονικά κείμενο. Ελέγξτε αν είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) πριν χρησιμοποιήσετε την ιδιότητα [text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/text_frame/).

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

Αυτό το μοτίβο αποφεύγει να αντιμετωπίζει placeholders εικόνας, διαγράμματος, πίνακα ή πολυμέσων ως αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/). Επιπλέον, προσδιορίζει το placeholder με βάση τον σκοπό του αντί να βασίζεται σε ευπαθή θέση σχήματος.

## **Ορισμός Κειμένου Prompt σε Διάταξη**

Το κείμενο prompt είναι η εντολή κατά το σχεδιασμό που εμφανίζεται σε ένα κενό placeholder, π.χ. *Click to add title*. Ορίστε προσαρμοσμένο κείμενο prompt στο placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ Shapes μιας κανονικής διαφάνειας. Προσπελάστε τη διάταξη μέσω του [Slide.layout_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/layout_slide/) και επαναλάβετε τα [LayoutSlide.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/shapes/).

Το παρακάτω παράδειγμα αλλάζει τα prompts τίτλου και υπότιτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

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

Το κείμενο prompt δεν αποτελεί κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, το prompt δεν εμφανίζεται πλέον. Η αλλαγή ενός prompt επίσης δεν αντικαθιστά υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις προς διαχείριση:

- Αν το placeholder εικόνας είναι ήδη γεμάτο και αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/), αντικαταστήστε την εικόνα μέσω του [PictureFillFormat.picture](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/picture/) και του [Picture.image](https://reference.aspose.com/slides/el/python-net/aspose.slides/picture/image/).
- Αν είναι ακόμη κενό placeholder, προσθέστε ένα picture frame στις συντεταγμένες του placeholder με το [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/) και αφαιρέστε το κενό placeholder.

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

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό picture frame, όχι ένα νέο placeholder, επειδή η ιδιότητα [Shape.placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/placeholder/) είναι μόνο για ανάγνωση. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά του placeholder. Εάν η διατήρηση της σχέσης του placeholder είναι κρίσιμη, προετοιμάστε και γεμίστε το placeholder στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτον [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνες, δείτε το άρθρο [Manage Picture Frames](/slides/el/python-net/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο picture frame ή στο picture fill, όχι στα μεταδεδομένα του placeholder.

## **Εργασία με Placeholders Διαγράμματος και Περιεχομένου**

Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [Chart](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/). Αυτό το παράδειγμα βρίσκει ένα τέτοιο διάγραμμα με βάση τόσο τον τύπο του placeholder όσο και την κλάση χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

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

Ένα γενικό placeholder περιεχομένου συνήθως έχει [PlaceholderType.OBJECT](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλαπλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και πολυμέσα. Αφού γεμίσει, εξετάστε την πραγματική κλάση σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType.CHART](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholdertype/), ή [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει ένα κενό placeholder [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) σε ένα [Chart](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/) απλώς αλλάζοντας το [Placeholder.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/placeholder/type/); ο τύπος είναι μόνο για ανάγνωση. Για να γεμίσετε προγραμματιστικά ένα κενό διάγραμμα ή περιοχή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και στη συνέχεια αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

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

Το προστιθέμενο διάγραμμα είναι ένα απλό τοπικό διάγραμμα. Καλύπτει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα διαχείρισης διαγραμμάτων [chart management articles](/slides/el/python-net/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, ψάχνει την πρώτη διαφάνεια για είτε placeholder τίτλου είτε εικόνας, ελέγχει τους τύπους του placeholder και του σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα να υποθέτει θέση σχήματος ή να αντιμετωπίζει κάθε placeholder ως την ίδια κλάση σχήματος.

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

Ένα βασικό placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στο master από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [Shape.get_base_placeholder](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_base_placeholder/) για να το ανακτήσετε. Ένα κανονικό τοπικό σχήμα επιστρέφει `None` επειδή δεν αποτελεί μέρος της ιεραρχίας των placeholders.

**Μπορώ να αλλάξω όλους τους τίτλους των διαφανειών επεξεργαζόμενος ένα placeholder της διάταξης;**

Μπορείτε να αλλάξετε την κληρονομημένη μορφοποίηση ή το κείμενο prompt μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε τον πραγματικό τίτλο σε ολόκληρη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο αντίστοιχο επίπεδο (διαφάνεια, διάταξη, master, σημειώσεις ή φυλλάδιο). Δείτε το άρθρο [Manage Presentation Header and Footer](/slides/el/python-net/presentation-header-and-footer/) για πλήρη παραδείγματα.