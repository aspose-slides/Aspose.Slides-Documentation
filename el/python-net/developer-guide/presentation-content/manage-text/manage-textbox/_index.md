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
description: "Το Aspose.Slides για Python μέσω .NET καθιστά εύκολη τη δημιουργία, επεξεργασία και κλωνοποίηση πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, βελτιώνοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως υπάρχουν σε πλαίσια κειμένου ή σχήματα. Επομένως, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να βάλετε κάποιο κείμενο μέσα στο πλαίσιο. Το Aspose.Slides for Python παρέχει την κλάση [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) που σας επιτρέπει να προσθέσετε ένα σχήμα που περιέχει κείμενο.

{{% alert title="Info" color="info" %}}
Το Aspose.Slides παρέχει επίσης την κλάση [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/). Ωστόσο, δεν μπορούν όλα τα σχήματα να περιέχουν κείμενο.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Επομένως, όταν χειρίζεστε ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι έχει μετατραπεί μέσω της κλάσης [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/). Μόνο τότε θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/), το οποίο είναι μια ιδιότητα της [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/). Δείτε την ενότητα [Update Text](/slides/el/python-net/manage-textbox/#update-text) σε αυτή τη σελίδα.
{{% /alert %}}

## **Δημιουργία πλαισίων κειμένου στις διαφάνειες**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στην πρώτη διαφάνεια.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) με `ShapeType.RECTANGLE` στην επιθυμητή θέση στη διαφάνεια.
4. Ορίστε το κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
5. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Το ακόλουθο παράδειγμα Python υλοποιεί αυτά τα βήματα:

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation.
with slides.Presentation() as presentation:

    # Αποκτήστε την πρώτη διαφάνεια στην παρουσίαση.
    slide = presentation.slides[0]

    # Προσθήκη AutoShape τύπου RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Αποθήκευση της παρουσίασης στο δίσκο.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Έλεγχος αν ένα σχήμα είναι πλαίσιο κειμένου**

Το Aspose.Slides παρέχει την ιδιότητα [is_text_box](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/is_text_box/) στην κλάση [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/), η οποία σας επιτρέπει να καθορίσετε αν ένα σχήμα είναι πλαίσιο κειμένου.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Αυτό το παράδειγμα Python δείχνει πώς να ελέγξετε αν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Σημειώστε ότι αν προσθέσετε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) χρησιμοποιώντας την κλάση [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/), η ιδιότητα `is_text_box` του σχήματος επιστρέφει `False`. Ωστόσο, αφού προσθέσετε κείμενο—είτε με τη μέθοδο `add_text_frame` είτε ορίζοντας την ιδιότητα `text`—η `is_text_box` επιστρέφει `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box είναι ψευδές
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box είναι αληθές

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box είναι ψευδές
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box είναι αληθές

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box είναι ψευδές
    shape3.add_text_frame("")
    # shape3.is_text_box είναι ψευδές

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box είναι ψευδές
    shape4.text_frame.text = ""
    # shape4.is_text_box είναι ψευδές
```

## **Εύρεση του σχήματος που κατέχει ένα TextFrame**

Σε γενικό κώδικα επεξεργασίας κειμένου, μπορεί να λάβετε ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) χωρίς να γνωρίζετε εκ των προτέρων ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε την ιδιότητα [TextFrame.parent_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_shape/) για να πλοηγηθείτε πίσω στο ιδιοκτησιακό [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/).

Για ένα TextFrame που ανήκει σε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) ή σε άλλο σχήμα που περιέχει κείμενο, το [TextFrame.parent_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_shape/) είναι ορισμένο και το [TextFrame.parent_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_cell/) είναι `None`. Και οι δύο ιδιότητες είναι μόνο για ανάγνωση και χρησιμεύουν στην πλοήγηση, επομένως η ανάγνωσή τους δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε την επιστρεφόμενη τιμή για `None` πριν προσπελάσετε το σχήμα.

Για ένα πλήρες παράδειγμα που εντοπίζει τους ιδιοκτήτες σχήματος και κελιού πίνακα, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/python-net/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσια κειμένου**

Το Aspose.Slides παρέχει τις ιδιότητες [column_count](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/column_count/) και [column_spacing](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/column_spacing/) στην κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) για να προσθέσετε στήλες σε πλαίσια κειμένου. Μπορείτε να ορίσετε τον αριθμό των στηλών και το διάστημα (σε points) μεταξύ των στηλών.

Ο ακόλουθος κώδικας Python επιδεικνύει αυτή τη λειτουργία:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Λάβετε την πρώτη διαφάνεια στην παρουσίαση.
	slide = presentation.slides[0]

	# Προσθέστε ένα AutoShape τύπου RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Προσθέστε ένα TextFrame στο ορθογώνιο.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Λάβετε τη μορφοποίηση κειμένου του TextFrame.
	format = shape.text_frame.text_frame_format

	# Ορίστε τον αριθμό των στηλών στο TextFrame.
	format.column_count = 3

	# Ορίστε το διάστημα μεταξύ των στηλών.
	format.column_spacing = 10

	# Αποθηκεύστε την παρουσίαση.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενημέρωση κειμένου**

Το Aspose.Slides σας επιτρέπει να ενημερώσετε το κείμενο σε ένα μόνο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. 

Το παρακάτω παράδειγμα Python δείχνει πώς να ενημερώσετε όλο το κείμενο σε μια παρουσίαση:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Αποθηκεύστε την τροποποιημένη παρουσίαση.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη πλαισίων κειμένου με συνδέσμους** 

Μπορείτε να εισάγετε έναν σύνδεσμο σε ένα πλαίσιο κειμένου. Όταν κάνετε κλικ στο πλαίσιο, ο σύνδεσμος ανοίγει.

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει υπερσύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στην πρώτη διαφάνεια.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) με `ShapeType.RECTANGLE` στην επιθυμητή θέση στη διαφάνεια.
4. Ορίστε το κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
5. Αποκτήστε μια αναφορά στο [HyperlinkManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkmanager/).
6. Χρησιμοποιήστε την ιδιότητα `hyperlink_manager` για να ορίσετε έναν εξωτερικό σύνδεσμο κλικ.
7. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Αυτό το παράδειγμα Python δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation.
with slides.Presentation() as presentation:

    # Λάβετε την πρώτη διαφάνεια στην παρουσίαση.
    slide = presentation.slides[0]

    # Προσθέστε ένα AutoShape τύπου RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Προσθέστε κείμενο στο πλαίσιο.
    text_portion.text = "Aspose.Slides"

    # Ορίστε έναν υπερσύνδεσμο για το κείμενο του τμήματος.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός κράτησης θέσης κειμένου όταν εργάζεστε με κύριες διαφάνειες;**

Ένα [placeholder](/slides/el/python-net/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/) και μπορεί να παραμετροποιηθεί σε [layouts](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/), ενώ ένα κανονικό πλαίσιο κειμένου είναι ανεξάρτητο αντικείμενο σε μια συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layout.

**Πώς μπορώ να εκτελέσω μαζική αντικατάσταση κειμένου σε όλη την παρουσίαση χωρίς να αγγίξω το κείμενο μέσα σε γραφήματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας σε auto-shapes που έχουν text frames και εξαιρέστε ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/)) διασχίζοντας τις συλλογές τους χωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.