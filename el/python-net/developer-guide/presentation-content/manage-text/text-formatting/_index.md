---
title: Μορφοποίηση κειμένου παρουσίασης σε Python
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/python-net/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- υπόβαθρο κειμένου
- διαφάνεια κειμένου
- απόσταση χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μορφοποιήστε και δώστε στυλ στο κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for Python μέσω .NET. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for Python μέσω .NET. Καλύπτει χρώματα φόντου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, απόσταση παραγράφων, συμπεριφορά αυτόματης προσαρμογής, αγκύρωση κειμένου, σημεία στηλοθέτη και ρυθμίσεις γλώσσας.

Εκτός αν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στη πρώτη διαφάνειά του είναι ένα πλαίσιο κειμένου και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Οι δείκτες διαφάνειας και σχήματος είναι μηδενικής βάσης. Τα παραδείγματα που επιλέγουν έντονες περιοχές χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή αποτελέσματα κανονικής έκφρασης, δείτε την [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/python-net/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο ή χρησιμοποιήστε το [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) για μεμονωμένες περιοχές κειμένου.

Το παρακάτω παράδειγμα ορίζει ένα ανοιχτό γκρι χρώμα επισήμανσης ως προεπιλογή για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης σε μεμονωμένες περιοχές έχουν προτεραιότητα πάνω από αυτήν την προεπιλογή:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **περιόδους κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε το χρώμα επισήμανσης για την περιοχή κειμένου.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι γκρι περιοχές κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) για να ορίσετε το στοίχιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, ομοιόμορφη κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ευθυγραμμίσετε την παράγραφο στο **κέντρο**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε τη στοίχιση της παραγράφου στο κέντρο.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Στοίχιση Γραμματοσειρών Μέσα σε Γραμμή**

Χρησιμοποιήστε το [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) για να ευθυγραμμίσετε κάθετα περιοχές κειμένου διαφορετικού μεγέθους γραμματοσειράς μέσα σε μια γραμμή. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παράγραφο και ελέγχει το στοίχιση σε κάθε μία από τις γραμμές της.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τέσσερα πλαίσια κειμένου με ετικέτες σε μία διαφάνεια. Κάθε παράγραφος περιέχει το ίδιο κείμενο σε 18, 36 και 54 σημεία, με διαφορετική στοίχιση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί το autofit και τη συσπατάλη, και κρατά τα πλαίσια κειμένου αρκετά μεγάλα για μία γραμμή.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Σύγκριση Στοίχισης Γραμματοσειρών Βάσης, Πάνω, Κέντρο και Κάτω με μεικτά μεγέθη γραμματοσειρών](font_alignment.png)

Η στοίχιση γραμματοσειρών χρησιμοποιεί μετρικές γραμματοσειράς, επομένως οι ορατές άκρες των ατομικών χαρακτήρων δεν ευθυγραμμίζονται απαραίτητα ακριβώς. Το παράδειγμα περιλαμβάνει και ένα κεφαλαίο γράμμα και μια κατώτερη (descender) για να δείξει τη διαφορά μεταξύ στοίχισης βάσης και κατώτερης. Η διαθεσιμότητα γραμματοσειρών και η αντικατάστασή τους, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στα μεγέθη των γραμματοσειρών επηρεάζουν το αποτέλεσμα. Οι διαστάσεις του πλαισίου, τα περιθώρια, το διάστημα γραμμών, η συσπατάλη και το autofit επηρεάζουν επίσης τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και ρυθμίσεις διάταξης όταν συγκρίνετε λειτουργίες.

Αυτή η ρύθμιση διαφέρει από το [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), το οποίο ελέγχει το οριζόντιο στοίχιση παραγράφου, και από το [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), το οποίο τοποθετεί το μπλοκ κειμένου κάθετα μέσα στο σχήμα. Η υπεργραφική (superscript) και υπογραφική (subscript) μορφοποίηση μέσω του [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) μετατοπίζει μεμονωμένες περιοχές σε σχέση με τη γραμμή βάσης αντί να ορίζει στοίχιση γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα-συστατικού του χρώματος που έχει ανατεθεί στο [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή αλφα-καναλιού ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε μια ημιδιαφανή μαύρη γέμιση για το κείμενο.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **περιόδους κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε τη διαφάνεια της περιοχής κειμένου.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι διαφανείς περιοχές κειμένου](transparent_text_portions.png)

## **Ορισμός Απόστασης Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία απόστασης· οι αρνητικές τιμές μειώνουν το κείμενο.

Ο παρακάτω κώδικας Python δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων στην **ολόκληρη την παράγραφο**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Αυξήστε την απόσταση χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **περιόδους κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
            portion.portion_format.spacing = 3  # Αυξήστε την απόσταση χαρακτήρων.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στις περιοχές κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Κάποια κείμενα που αποδίδονται από το Aspose.Slides μπορεί να φαίνονται ελαφρώς πιο στενά από το ίδιο κείμενο που προβάλλεται στο PowerPoint. Αυτό μπορεί να συμβεί επειδή το PowerPoint ενδέχεται να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε το αποτέλεσμα πιο κοντά στο PowerPoint, μπορείτε να απενεργοποιήσετε το kerning για περιοχές κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε το [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Το παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και θέτει ένα κατώφλι 100 σημείων για περιοχές που χρησιμοποιούν Roboto. Αυτό απενεργοποιεί το kerning για ταιριαστές περιοχές με μέγεθος γραμματοσειράς κάτω από 100 σημεία:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Για κείμενο που βρίσκεται κάτω από το κατώφλι, αυτή η ρύθμιση εμποδίζει το kerning και μπορεί να βοηθήσει την απόδοση του Aspose.Slides να ταιριάζει με την οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά του PowerPoint.

## **Διαχείριση Ιδιότητων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ή σε μεμονωμένες περιοχές μέσω του [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημεία με έντονο, πλάγιο και υπογράμμιση με κουκκίδες. Η ρητή μορφοποίηση σε μεμονωμένες περιοχές έχει προτεραιότητα έναντι αυτών των προεπιλογών.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημεία, πλάγια μορφοποίηση και υπογράμμιση με κουκκίδες σε περιοχές των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε τις ιδιότητες γραμματοσειράς για την περιοχή κειμένου.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για περιοχές κειμένου](font_properties_for_text_portions.png)

## **Έλεγχος Κανονικοποίησης Ύψους Κειμένου**

Χρησιμοποιήστε το [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) όταν επαναλαμβάνετε τυπογραφία προτύπου ή ερευνάτε διαφορές στο ύψος των χαρακτήρων. Στο PowerPoint, η ενεργοποίηση της κανονικοποίησης τεντώνει ή συμπιέζει κάθε χαρακτήρα κάθετα ώστε να έχει ομοιόμορφο ορατό ύψος μέσα στην περιοχή κειμένου. Δεν εγγυάται ίσου ύψους κείμενο μεταξύ διαφορετικών γραμματοσειρών.

Ορίστε την ιδιότητα σε [NullableBool.TRUE ή FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) για να ενεργοποιήσετε ή να απενεργοποιήσετε ρητά την κανονικοποίηση. `NullableBool.NOT_DEFINED` αφήνει την τοπική ρύθμιση ακαθόριστη ώστε η περιοχή να κληρονομήσει την τιμή της, π.χ. από το [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) της παραγράφου. Δεν σημαίνει `False`. Χρησιμοποιήστε το [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) και διαβάστε το [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) για να αποκτήσετε την τελική Boolean τιμή.

Το παρακάτω αυτόνομο παράδειγμα απαιτεί **Arial** εγκατεστημένη. Δημιουργεί δύο μπλοκ κειμένου που περιέχουν τα ίδια κεφαλαία γράμματα, πεζά, descenders και τονισμένους χαρακτήρες σε 54 σημεία. Και οι δύο παράγραφοι ενεργοποιούν την κανονικοποίηση εξ ορισμού. Η επάνω περιοχή την απενεργοποιεί ρητά· η κάτω κληρονομεί την ενεργή ρύθμιση. Τα μεγέθη πλαισίων, τα περιθώρια και το διάστημα παραγράφων είναι πανομοιότυπα, με συσπατάλη και autofit απενεργοποιημένα ώστε η σύγκριση να παραμείνει συνεπής. Το παράδειγμα εκτυπώνει `FALSE: False` και `NOT_DEFINED: True`, στη συνέχεια αποθηκεύει το «text_height_normalization.pptx».

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

Η σύγκριση παρακάτω εξήχθη από την αποθηκευμένη παρουσίαση. Η επάνω σειρά έχει την κανονικοποίηση απενεργοποιημένη (`FALSE`); η κάτω κληρονομεί την ενεργή ρύθμιση (`NOT_DEFINED` → `True`). Διατηρήστε το Arial εγκατεστημένο για την επαναδημιουργία αυτής της εμφάνισης.

![Arial 54‑σημείων κείμενο με κανονικοποίηση απενεργοποιημένη πάνω και κληρονομική ενεργή κάτω](text_height_normalization.png)

Η κανονικοποίηση αλλάζει το ύψος των χαρακτήρων χωρίς να αλλάζει την τιμή του [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) που καθορίζει το μέγεθος γραμματοσειράς σε σημεία. Το [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) της παραγράφου ελέγχει το διάστημα γραμμών, ενώ το [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) του πλαισίου κειμένου ελέγχει πώς το κείμενο ή το κοντέινερ του προσαρμόζεται. Αυτές οι ρυθμίσεις εξυπηρετούν διαφορετικούς σκοπούς και μπορούν να επηρεάσουν τη διάταξη ανεξάρτητα. Για περισσότερα σχετικά με τη μορφοποίηση παραγράφων και την κληρονόμηση, δείτε τη σελίδα [Διαχείριση Παραγράφου](/slides/el/python-net/manage-paragraph/).

## **Εφαρμογή και Αφαίρεση Διαγράμμισης (Strikethrough)**

Χρησιμοποιήστε το [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) σε μια περιοχή κειμένου για να εμφανίσετε διορθώσεις, ακυρωμένες εκφράσεις ή προηγούμενες τιμές χωρίς διαγραφή του αρχικού κειμένου. Ορίστε το σε [TextStrikethroughType.SINGLE ή DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) για μία ή δύο γραμμές διαγράμμισης.

Για να αφαιρέσετε τη διαγράμμιση, ορίστε `TextStrikethroughType.NONE`. Αυτό απενεργοποιεί ρητά το εφέ, ακόμη και αν η περιβάλλουσα μορφοποίηση καθορίζει διαγράμμιση. Αντίθετα, το `TextStrikethroughType.NOT_DEFINED` αφήνει την τοπική ρύθμιση ακαθόριστη, επιτρέποντας στην περιοχή να κληρονομήσει τη μορφοποίηση, π.χ. από την παράγραφο. Δεν εγγυάται την αφαίρεση της διαγράμμισης. Χρησιμοποιήστε το [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) για να διαβάσετε τη ληφθείσα μορφοποίηση, συμπεριλαμβανομένων των κληρονομημένων τιμών.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τρεις συγκρίσεις τιμών. Κάθε παράγραφος έχει ξεχωριστές περιοχές για την ετικέτα, την προηγούμενη τιμή και την τρέχουσα τιμή, ώστε μόνο η προηγούμενη τιμή να επηρεάζεται. Η πρώτη σειρά εφαρμόζει και στη συνέχεια αφαιρεί τη διαγράμμιση· οι υπόλοιπες σειρές διατηρούν τη μονή ή διπλή διαγράμμιση. Η αλλαγή αυτής της ιδιότητας διατηρεί το κείμενο και τις άλλες μορφοποιήσεις του, συμπεριλαμβανομένου του έντονου κειμένου.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Εφαρμόστε διαγράμμιση, στη συνέχεια αφαιρέστε την ρητά από την πρώτη προηγούμενη τιμή.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα, από πάνω προς τα κάτω: χωρίς διαγράμμιση, μονή διαγράμμιση και διπλή διαγράμμιση.

![Προηγούμενες τιμές χωρίς διαγράμμιση, με μονή διαγράμμιση και με διπλή διαγράμμιση](strikethrough.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) για να ορίσετε προεπιλεγμένο προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Προβολή Ψηφίων Πλευρά Πλευρά σε Κάθετο Κείμενο**

Για να διατηρήσετε δύο ψήφια αριθμό μαζί σε μια κάθετη ιαπωνική ετικέτα, τοποθετήστε και τα δύο ψηφία σε μια περιοχή κειμένου και ορίστε το [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) σε αυτήν την περιοχή. Το παράδειγμα δημιουργεί δύο ετικέτες σε μια νέα παρουσίαση χρησιμοποιώντας το [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) και MS Gothic 40 σημεία. Η τιμή του [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) που ανατίθεται στην αριθμητική περιοχή διαφέρει.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

Στο PowerPoint, η αριστερή ετικέτα (`TRUE`) εμφανίζει τα ψηφία όρθια και δίπλα-δίπλα μεταξύ των χαρακτήρων 和 και 年. Η δεξιά ετικέτα (`FALSE`) περιστρέφει το ζεύγος κατά 90 μοίρες δεξιόστροφα. Οι γύρω ιαπωνικοί χαρακτήρες παραμένουν όρθιοι και στις δύο ετικέτες.

![Σύγκριση ετικετών ημερομηνίας σε κάθετη διάταξη με ψηφία όρθια στα αριστερά και περιστρεφόμενα στα δεξιά](vertical_date.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαισίων Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστημάτων Γραμμής Παραγράφων**

Το Aspose.Slides παρέχει τα [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) και [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) για να ελέγξετε το διάστημα παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστημα γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει το εσωτερικό διάστημα της πρώτης παραγράφου σε 200 % του ύψους της γραμμής (διπλό διάστημα):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διάστημα γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Έλεγχος Σπάσιμος Γραμμής**

Οι κανόνες σπασίματος γραμμής της παραγράφου είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και πολυάστρα (East Asian) κείμενο. Οι ακόλουθες ιδιότητες ανήκουν στο [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), επομένως εφαρμόζονται σε ολόκληρη την παράγραφο:

* Το [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) ελέγχει τους κανόνες σπασίματος για λατινικά. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου το πολυάστρα κείμενο και η στίξη αναδιπλώνονται.
* Το [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ελέγχει τους κανόνες σπασίματος για πολυάστρα, συμπεριλαμβανομένων των περιορισμών για χαρακτήρες στην αρχή ή στο τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), το οποίο ενεργοποιεί αυτόματη αναδίπλωση μέσα σε ένα πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν η αναδίπλωση συμβαίνει· δεν προσθέτουν χαρακτήρες νέας γραμμής. Μια ρητή αλλαγή γραμμής δημιουργεί νέα γραμμή στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει Κινέζικο και Λατινικό κείμενο. Ορίζει και τις δύο ιδιότητες σπασίματος γραμμής ρητά και αποθηκεύει το «line_breaking.pptx». Για πειραματισμό με οποιονδήποτε κανόνα, αλλάξτε την τιμή της ιδιότητας κρατώντας την άλλη ρύθμιση αμετάβλητη. Το παράδειγμα χρησιμοποιεί Arial 24 σημεία και SimSun με πλάτος πλαισίου 160 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) του πλαισίου κειμένου ορίζεται σε [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις πλαισίου να παραμείνουν σταθερά.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Έλεγχος Κρεμαστών Στίξεων (Hanging Punctuation)**

Το [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) επιτρέπει σε επιλέξιμες στίξεις να εκτείνονται πέρα από τη δεξιά άκρη της γραμμής κειμένου αντί να καταλαμβάνουν την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από το κρεμαστό εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί κρεμαστές στίξεις σε πλαίσιο κειμένου 100 σημείων πλάτος και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημεία και μηδενικά οριζόντια περιθώρια, η τελική τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από τη δεξιά άκρη του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) για σύγκριση: με αυτή τη ρύθμιση η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργοποιημένη και το autofit απενεργοποιημένο ώστε το διαθέσιμο πλάτος να παραμείνει σταθερό.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Δεν μπορεί να κρεμαστεί κάθε στίξη. Το οπτικό αποτέλεσμα εξαρτάται από τις [συνθήκες γραμματοσειράς και διάταξης](#control-line-breaking): η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων autofit μπορεί να καταργήσει τη διαφορά.

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν ξεπερνά τα όρια του κοντέινερ του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο θα συρρικνωθεί, θα υπερχειλιστεί ή το σχήμα θα μεταβιβάσει αυτόματα το μέγεθός του. Το παρακάτω παράδειγμα ρυθμίζει το σχήμα ώστε να αλλάζει μέγεθος ώστε να χωρά το κείμενό του και αποθηκεύει το αποτέλεσμα στο «autofit_type.pptx».

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς αλλάζει το πλάτος του κειμένου ή του σχήματος, δείτε την [Count Rendered Lines](/slides/el/python-net/manage-paragraph/). Ο μόνος αριθμός γραμμών δεν υποδεικνύει αν το κείμενο υπερχειλίζει το κοντέινερ του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

Το [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) ορίζει πώς το κείμενο τοποθετείται κατακόρυφα μέσα σε ένα σχήμα, π.χ. στην κορυφή, στη μέση ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο «text_anchor.pptx».

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Στηλοθετησης Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) και το [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) για να ρυθμίσετε τα σημεία στήλης σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα στήλης στα 100 σημεία και προσθέτει μια αριστερή στήλη στο 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν κείμενο που περιέχει χαρακτήρες στήλης.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι στήλες της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου (Proofing Language)**

Το Aspose.Slides παρέχει το [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), το οποίο επιτρέπει τον ορισμό της γλώσσας ελέγχου για μια περιοχή κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά τα περιεχόμενα της πρώτης παραγράφου με το «1。», ορίζει το SimSun ως τη γραμματοσειρά της και ορίζει τη γλώσσα ελέγχου για Απλοποιημένα Κινέζικα (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο «proofing_language.pptx»:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Ορίστε τη γλώσσα ελέγχου σε Απλοποιημένα Κινέζικα.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Αντιγραφή Μεταδεδομένων Γλώσσας**

Κατά την αντιγραφή πολύγλωσου κειμένου από πρότυπο, διατηρήστε τόσο το [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) όσο και το [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια πηγή περιοχής με US English ως γλώσσα και Γαλλικά ως εναλλακτική γλώσσα και αντιγράφει το κείμενο και τα αναγνωριστικά σε μια περιοχή σε μια νέα παρουσίαση.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Αν η πηγή δεν έχει εναλλακτική γλώσσα, το None καθαρίζει την τιμή προορισμού.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Για να δοκιμάσετε μια πηγή χωρίς εναλλακτική γλώσσα, παραλείψτε την ανάθεση του `"fr-FR"`. Η εναλλακτική ταυτότητα τότε είναι `None` και η ίδια δήλωση αντιγραφής διατηρεί την απουσία της χωρίς εισαγωγή προεπιλογής, ακόμη και αν ο προορισμός είχε προηγουμένως ανατεθεί εναλλακτική γλώσσα.

Αυτά τα αναγνωριστικά αποθηκεύουν μεταδεδομένα γλώσσας. Η διατήρησή τους δεν καθορίζει ποιο λεξικό θα επιλέξει το PowerPoint για ορθογραφικό ή γραμματικό έλεγχο.

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) για να ορίσετε τη προεπιλεγμένη γλώσσα κειμένου κατά τη φόρτωση ή δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με US English ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για την πρώτη περιοχή κειμένου.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Προσθέστε ένα νέο σχήμα ορθογωνίου με κείμενο.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ελέγξτε τη γλώσσα της πρώτης περιοχής.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Το παρακάτω παράδειγμα ορίζει μια γραμματοσειρά 14 σημείων με έντονη γραφή ως προεπιλογή για τις κορυφαίες παραγράφους σε μια νέα παρουσίαση και την αποθηκεύει στο «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένη μορφοποίηση τις παρακάμπτει.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Λάβετε τη μορφοποίηση παραγράφου του ανώτερου επιπέδου.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Εξαγωγή Κειμένου με το Εφέ Όλων σε Κεφαλαία (All‑Caps)**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και αν είχε αρχικά πληκτρολογηθεί με πεζά. Όταν ανακτάτε μια περιοχή κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) και μετατρέψτε την επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `ALL`.

Αυτό το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη παράγραφος της πρώτης περιοχής της περιέχει το κείμενο «Hello, Aspose!» με το εφέ All Caps ενεργό, όπως φαίνεται παρακάτω.

![Το εφέ All Caps](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξαγάγετε το κείμενο με το **All Caps** εφέ ενεργό:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Πώς μπορώ να τροποποιήσω το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Διατρέξτε τα κελιά και ενημερώστε το κάθε κελί μέσω του [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) και τη μορφοποίηση παραγράφων μέσω του [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Πώς μπορώ να εφαρμόσω ένα διαβαθμισμένο χρώμα σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε ένα διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε το [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Ορίστε το [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.

Σχετική δυνατότητα: [Format text within slides](/slides/el/features/text-formatting/).