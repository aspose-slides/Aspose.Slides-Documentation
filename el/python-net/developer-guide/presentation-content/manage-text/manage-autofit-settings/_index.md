---
title: Βελτιώστε τις παρουσιάσεις σας με το AutoFit στην Python
linktitle: Ρυθμίσεις AutoFit
type: docs
weight: 30
url: /el/python-net/manage-autofit-settings/
keywords:
- πλαίσιο κειμένου
- αυτόματη προσαρμογή
- μη αυτόματη προσαρμογή
- προσαρμογή κειμένου
- συρρίκνωση κειμένου
- αναδίπλωση κειμένου
- αλλαγή μεγέθους σχήματος
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις ρυθμίσεις AutoFit στο Aspose.Slides για Python μέσω .NET ώστε να βελτιστοποιήσετε την εμφάνιση του κειμένου στις παρουσιάσεις PowerPoint και OpenDocument και να βελτιώσετε την αναγνωσιμότητα του περιεχομένου."
---
## **Εισαγωγή**

Από προεπιλογή, όταν προσθέτετε ένα πλαίσιο κειμένου, το Microsoft PowerPoint χρησιμοποιεί τη ρύθμιση **Resize shape to fix text** για το πλαίσιο κειμένου — προσαρμόζει αυτόματα το μέγεθος του πλαισίου ώστε το κείμενό του να ταιριάζει πάντα.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Όταν το κείμενο στο πλαίσιο κειμένου γίνει μακρύτερο ή πιο μεγάλο, το PowerPoint αυτόματα μεγεθύνει το πλαίσιο — αυξάνει το ύψος του — για να χωρέσει περισσότερο κείμενο.  
* Όταν το κείμενο στο πλαίσιο κειμένου γίνει πιο σύντομο ή μικρότερο, το PowerPoint αυτόματα μειώνει το πλαίσιο — μειώνει το ύψος του — για να αφαιρέσει πλεονάζον χώρο.

Στο PowerPoint, αυτά είναι τα 4 σημαντικά παραμέτρων ή επιλογών που ελέγχουν τη συμπεριφορά autofit για ένα πλαίσιο κειμένου:

* **Μη αυτόματη προσαρμογή**
* **Σμίκρυνση κειμένου σε υπερχείλιση**
* **Resize shape to fix text**
* **Αναδίπλωση κειμένου στο σχήμα**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET παρέχει παρόμοιες επιλογές—ορισμένες ιδιότητες κάτω από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/)—που σας επιτρέπουν να ελέγξετε τη συμπεριφορά autofit για πλαίσια κειμένου σε παρουσιάσεις.

## **Αλλαγή Μεγέθους Σχημάτων ώστε να Ταιριάζει το Κείμενο**

Αν θέλετε το κείμενο σε ένα πλαίσιο να ταιριάζει πάντα σε αυτό μετά από αλλαγές στο κείμενο, πρέπει να χρησιμοποιήσετε την επιλογή **Resize shape to fix text**. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [autofit_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) σε `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Αν το κείμενο γίνει μακρύτερο ή πιο μεγάλο, το πλαίσιο κειμένου θα αλλάξει αυτόματα μέγεθος (αύξηση στο ύψος) ώστε όλο το κείμενο να χωράει. Αν το κείμενο γίνει πιο σύντομο, συμβαίνει το αντίστροφο.

## **Μη Αυτόματη Προσαρμογή**

Αν θέλετε ένα πλαίσιο κειμένου ή σχήμα να διατηρεί τις διαστάσεις του ανεξάρτητα από τις αλλαγές στο κείμενο που περιέχει, πρέπει να χρησιμοποιήσετε την επιλογή **Do not Autofit**. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [autofit_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) σε `NONE`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του, θα ξεχειλίσει.

## **Σμίκρυνση Κειμένου σε Υπερχείλιση**

Αν ένα κείμενο γίνει πολύ μακρύ για το πλαίσιο του, μέσω της επιλογής **Shrink text on overflow** μπορείτε να ορίσετε ότι το μέγεθος και το διάστημα του κειμένου πρέπει να μειωθούν ώστε να ταιριάζει στο πλαίσιο. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [autofit_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) σε `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείται η επιλογή **Shrink text on overflow**, η ρύθμιση εφαρμόζεται μόνο όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του.
{{% /alert %}}

## **Αναδίπλωση Κειμένου**

Αν θέλετε το κείμενο σε ένα σχήμα να αναδιπλώνεται μέσα σε αυτό όταν το κείμενο υπερβαίνει το πλάτος του σχήματος, πρέπει να χρησιμοποιήσετε την παράμετρο **Wrap text in shape**. Για να ορίσετε αυτή τη ρύθμιση, πρέπει να θέσετε την ιδιότητα [wrap_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/) σε `NullableBool.TRUE`.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Αν ορίσετε την ιδιότητα `wrap_text` σε `NullableBool.FALSE` για ένα σχήμα, όταν το κείμενο μέσα στο σχήμα γίνει μακρύτερο από το πλάτος του, το κείμενο θα επεκταθεί πέρα από τα όρια του σχήματος σε μία μόνο γραμμή. 
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Επηρεάζουν τα εσωτερικά περιθώρια του πλαισίου κειμένου το AutoFit;**

Ναι. Τα περιθώρια (padding) μειώνουν την διαθέσιμη περιοχή για κείμενο, οπότε το AutoFit ενεργοποιείται νωρίτερα — μειώνοντας τη γραμματοσειρά ή αλλάζοντας το μέγεθος του σχήματος. Ελέγξτε και προσαρμόστε τα περιθώρια πριν ρυθμίσετε το AutoFit.

**Πώς αλληλεπιδρά το AutoFit με χειροκίνητες και «soft» αλλαγές γραμμής;**

Οι υποχρεωτικές αλλαγές γραμμής παραμένουν, και το AutoFit προσαρμόζει το μέγεθος γραμματοσειράς και το διάστημα γύρω τους. Η αφαίρεση περιττών αλλαγών γραμμής συχνά μειώνει το πόσο έντονα χρειάζεται το AutoFit να μειώσει το κείμενο.

**Επηρεάζει η αλλαγή της γραμματοσειράς θέματος ή η αντικατάσταση γραμματοσειράς τα αποτελέσματα του AutoFit;**

Ναι. Η αντικατάσταση με γραμματοσειρά που έχει διαφορετικές διαστάσεις χαρακτήρων αλλάζει το πλάτος/ύψος του κειμένου, κάτι που μπορεί να αλλάξει το τελικό μέγεθος γραμματοσειράς και την αναδίπλωση. Μετά από κάθε αλλαγή ή αντικατάσταση γραμματοσειράς, ελέγξτε ξανά τις διαφάνειες.