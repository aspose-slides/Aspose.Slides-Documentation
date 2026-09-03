---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις με Python
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/python-net/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσυνδέσμου
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε, εντοπίστε, μορφοποιήστε και ενημερώστε πλαίσια κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET."
---
## **Εισαγωγή**

Στο Aspose.Slides for Python via .NET, το κείμενο της διαφάνειας αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η κλάση [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) αντιπροσωπεύει το πιο κοινό σχήμα που περιέχει κείμενο και εκθέτει το κείμενό του μέσω της ιδιότητας [AutoShape.text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Note" %}}

Κάθε αυτόματο σχήμα κληρονομεί από το [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/), αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Κατά την επεξεργασία μιας υπάρχουσας παρουσίασης, χρησιμοποιήστε `isinstance(shape, slides.AutoShape)` για να ελέγξετε τον τύπο του σχήματος πριν προσπελάσετε το κείμενό του.

{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου, προσθέστε ένα αυτόματο σχήμα σε μια διαφάνεια, προσθέστε κείμενο στο πλαίσιο κειμένου του και αποθηκεύστε την παρουσίαση. Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο πλαίσιο κειμένου:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Οι συντεταγμένες και οι διαστάσεις που περνιούνται στη μέθοδο [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_auto_shape/) μετρώνται σε σημεία. Η μέθοδος [AutoShape.add_text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/add_text_frame/) αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Χρησιμοποιήστε την ιδιότητα [AutoShape.is_text_box](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/is_text_box/) για να προσδιορίσετε αν ένα αυτόματο σχήμα αντιμετωπίζεται ως πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσίαση περιέχει τόσο σχήματα που φέρουν κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Το παρακάτω παράδειγμα ελέγχει κάθε αυτόματο σχήμα σε μια παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Ένα νεοπροστιθέμενο αυτόματο σχήμα δεν θεωρείται πλαίσιο κειμένου μέχρι να περιέχει μη κενό κείμενο. Μπορείτε να δώσετε αυτό το κείμενο μέσω της μεθόδου [AutoShape.add_text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/add_text_frame/) ή της ιδιότητας [TextFrame.text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/text/). Η προσθήκη ή ανάθεση μιας κενής συμβολοσειράς αφήνει την ιδιότητα [is_text_box](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/is_text_box/) σε `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Οι δύο πρώτες κλήσεις εκτυπώνουν `True`; οι δύο τελευταίες εκτυπώνουν `False`.

## **Εύρεση σχήματος που κατέχει πλαίσιο κειμένου**

Γενικός κώδικας επεξεργασίας κειμένου μπορεί να λάβει ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) χωρίς να γνωρίζει ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε την ιδιότητα μόνο για ανάγνωση [TextFrame.parent_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_shape/) για να επιστρέψετε στο ιδιοκτησιακό του [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα αυτόματο σχήμα ή σε άλλο σχήμα που φέρει κείμενο, η ιδιότητα [parent_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_shape/) περιέχει τον ιδιοκτήτη και η ιδιότητα [TextFrame.parent_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_cell/) είναι `None`. Ελέγξτε την επιστρεφόμενη τιμή πριν την προσπελάσετε. Για την ταυτοποίηση τόσο των ιδιοκτητών σχήματος όσο και των κελιών πίνακα, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε την ενότητα [Search and Replace Text](/slides/el/python-net/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Η ιδιότητα [TextFrameFormat.column_count](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/column_count/) διαιρεί το πλαίσιο κειμένου σε στήλες, ενώ η ιδιότητα [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/column_spacing/) ορίζει το κενό μεταξύ των στηλών σε σημεία. Και οι δύο ρυθμίσεις ανήκουν στο [TextFrameFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) και μπορούν να τροποποιηθούν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο ανακυκλώνεται μεταξύ των στηλών μέσα στο ίδιο σχήμα· δεν συνεχίζεται σε άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου με τρεις στήλες και 10 σημεία μεταξύ των στηλών, αποθηκεύει την παρουσίαση και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Εξαγωγή κειμένου από μεμονωμένες στήλες**

Χρησιμοποιήστε τη μέθοδο [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/split_text_by_columns/) για να ανακτήσετε το κείμενο που έχει εκχωρηθεί σε κάθε οπτική στήλη σε ένα υπάρχον πλαίσιο κειμένου. Η μέθοδος επιστρέφει μία συμβολοσειρά για κάθε στήλη, με στήλη‑βάση σειρά ανάγνωσης. Ένα πλαίσιο κειμένου μίας στήλης παράγει μια λίστα με ένα στοιχείο, και μια κενή στήλη αντιπροσωπεύεται από κενή συμβολοσειρά. Οι συμβολοσειρές περιέχουν μόνο απλό κείμενο· η μορφοποίηση σε επίπεδο τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται να:

- Εξαγωγή κειμένου διατηρώντας τη στήλη‑βάση σειρά ανάγνωσης.
- Καταγραφή ή σύγκριση του περιεχομένου διαφανειών με πολλαπλές στήλες.
- Εξαγωγή κάθε στήλης σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλο προορισμό.
- Επιθεώρηση του πώς το κείμενο αναμετατίθεται μετά την αλλαγή του [TextFrameFormat.column_count](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/column_count/), του [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/column_spacing/), της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που διανέμεται εντός του τρέχοντος [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/); δεν ρέει αυτόματα το κείμενο μεταξύ ξεχωριστών σχημάτων ή πλαισίων κειμένου. Η κατανομή των στηλών μπορεί να εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, γι’ αυτό βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες όταν η συνοχή των αποτελεσμάτων είναι σημαντική.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, βρίσκει το πρώτο αυτόματο σχήμα με πολλαπλές στήλες και πλαίσιο κειμένου, διαβάζει τον προρυθμισμένο αριθμό στηλών του και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Ενημέρωση κειμένου**

Για να ενημερώσετε το κείμενο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και τα σχήματα, επιλέξτε αυτόματα σχήματα και, στη συνέχεια, επεξεργαστείτε τα τμήματα κειμένου τους. Η εργασία σε επίπεδο τμήματος σας επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη μορφοποίηση χαρακτήρων.

Το παρακάτω παράδειγμα αντικαθιστά κάθε εμφάνιση του `years` με το `months` σε κείμενο αυτόματου σχήματος και κάνει το κάθε επηρεαζόμενο τμήμα έντονο:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Αυτή η διέλευση ενημερώνει το κείμενο μόνο σε αυτόματα σχήματα. Το κείμενο που είναι αποθηκευμένο σε πίνακες, διαγράμματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί διέλευση των συλλογών των αντίστοιχων αντικειμένων.

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο**

Ένας υπερσύνδεσμος μπορεί να εκχωρηθεί σε ένα συγκεκριμένο τμήμα κειμένου, ώστε μόνο αυτό το κείμενο να λειτουργεί ως κλικ-σύνδεσμος. Χρησιμοποιήστε τη μέθοδο [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) για να συσχετίσετε το τμήμα με ένα εξωτερικό URL.

Το παρακάτω παράδειγμα δημιουργεί συνδεδεμένο κείμενο και το αποθηκεύει σε μια παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια είναι η διαφορά μεταξύ πλαισίου κειμένου και κράτησης θέσης κειμένου σε κύρια ή διάταξη διαφάνειας;**

Ένα [placeholder](/slides/el/python-net/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη μορφοποίηση του από μια [master slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/) ή μια [layout slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στη διαφάνεια όπου δημιουργήθηκε και δεν υιοθετεί τη συμπεριφορά κράτησης θέσης όταν αλλάζει η διάταξη.

**Πώς μπορώ να αντικαταστήσω κείμενο χωρίς να αλλάξω το κείμενο σε διαγράμματα, πίνακες ή SmartArt;**

Περιορίστε τη διέλευση στα στιγμιότυπα του [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/), όπως φαίνεται στο παράδειγμα Ενημέρωση κειμένου. Οι πίνακες, τα διαγράμματα και το SmartArt αποθηκεύουν κείμενο στα δικά τους μοντέλα αντικειμένων, επομένως δεν τροποποιούνται από αυτόν τον βρόχο.