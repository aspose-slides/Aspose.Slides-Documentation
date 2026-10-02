---
title: Μορφοποίηση Κειμένου Παρουσίασης σε Python
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/python-net/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- απόσταση χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα autofit
- άγκυρο πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μορφοποιήστε και στιλιζάστε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχηση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Περιλαμβάνει χρώματα φόντου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, απόσταση παραγράφων, συμπεριφορά αυτόματης προσαρμογής, αγκώνωση κειμένου, σημεία στηλοθέτη και ρυθμίσεις γλώσσας.

Εκτός εάν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη του διαφάνεια είναι ένα πλαίσιο κειμένου και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Οι δείκτες διαφανειών και σχημάτων είναι μηδενικής βάσης. Τα παραδείγματα που επιλέγουν έντονες περιοχές χρησιμοποιούν την αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Sample text](sample_text.png)

Για εύρεση και επισήμανση κυριολεκτικού κειμένου ή αντιστοιχίας κανονικής έκφρασης, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/python-net/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο ή χρησιμοποιήστε το [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) για μεμονωμένες περιοχές κειμένου.

Το παρακάτω παράδειγμα ορίζει μια ανοιχτόγκρι επισήμανση ως προεπιλογή για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης σε μεμονωμένες περιοχές έχουν προτεραιότητα έναντι αυτής της προεπιλογής:

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

![The gray paragraph](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **περιοχές κειμένου με έντονη γραμματοσειρά**:

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

![The gray text portions](gray_text_portions.png)

## **Στοίχηση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) για να ορίσετε τη στοίχηση παραγράφων μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, στοιχισμένη (justified) κ.λπ.

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

![The aligned paragraph](aligned_paragraph.png)

## **Στοίχηση Γραμματοσειρών Μέσα σε Γραμμή**

Χρησιμοποιήστε το [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) για να ευθυγραμμίσετε κάθετα περιοχές κειμένου διαφορετικών μεγεθών γραμματοσειράς μέσα σε μια γραμμή. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παράγραφο και ελέγχει την στοίχηση σε κάθε γραμμή της.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τέσσερα πλαίσια κειμένου με ετικέτες σε μια διαφάνεια. Κάθε παράγραφος περιλαμβάνει το ίδιο κείμενο στα 18, 36 και 54 σημεία, με διαφορετική στοίχηση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί το autofit και το wrapping, και διατηρεί τα πλαίσια κειμένου αρκετά μεγάλα για μία μόνο γραμμή.

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

![Σύγκριση στοίχησης γραμματοσειράς βάσης, κορυφής, κέντρου και κάτω με μικτά μεγέθη γραμματοσειράς](font_alignment.png)

Η στοίχηση γραμματοσειράς χρησιμοποιεί μετρικές γραμματοσειράς, έτσι οι ορατές άκρες των ατομικών γραμμάτων δεν ευθυγραμμίζονται απαραίτητα ακριβώς. Το παράδειγμα περιλαμβάνει ένα κεφαλαίο γράμμα και έναν υποβραχίονα για να δείξει τη διαφορά μεταξύ στοίχησης βάσης και κάτω. Η διαθεσιμότητα και αντικατάσταση γραμματοσειρών, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στα μεγέθη γραμματοσειράς επηρεάζουν το αποτέλεσμα. Οι διαστάσεις πλαισίου, τα περιθώρια, η απόσταση γραμμών, το wrapping και το autofit επίσης επηρεάζουν τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και ρυθμίσεις διάταξης όταν συγκρίνετε τις λειτουργίες.

Αυτή η ρύθμιση διαφέρει από το [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), που ελέγχει την οριζόντια στοίχηση παραγράφων, και από το [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), που τοποθετεί το μπλοκ κειμένου κάθετα μέσα στο σχήμα του. Η μορφοποίηση εκθέτη και κάτω εκθέτη μέσω του [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) μετατοπίζει μεμονωμένες περιοχές σχετικά με τη βάση αντί να ορίζει στοίχηση γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα‑συστατικού του χρώματος που έχει αντιστοιχιστεί στο [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή καναλιού αλφα σε ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη παράγραφο**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε ημιδιαφανή μαύρη γέμιση για το κείμενο.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The transparent paragraph](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **περιοχές κειμένου με έντονη γραμματοσειρά**:

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

![The transparent text portions](transparent_text_portions.png)

## **Ορισμός Αποστάσεων Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία απόστασης· οι αρνητικές τιμές πιέζουν το κείμενο.

Ο παρακάτω κώδικας Python δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων στην **ολόκληρη παράγραφο**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Επεκτείνετε την απόσταση χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **περιοχές κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
            portion.portion_format.spacing = 3  # Επεκτείνετε την απόσταση χαρακτήρων.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδει το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο σφιχτό από το ίδιο κείμενο σε PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να προσεγγίσετε το αποτέλεσμα του PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για περιοχές κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε το [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Το παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και θέτει ένα όριο 100 σημείων για περιοχές που χρησιμοποιούν Roboto. Αυτό απενεργοποιεί το kerning για τις αντίστοιχες περιοχές με μέγεθος γραμματοσειράς μικρότερο από 100 σημεία:

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

Για κείμενο που πληροί το όριο, αυτή η ρύθμιση εμποδίζει το kerning και μπορεί να βοηθήσει το Aspose.Slides να ταιριάξει πιο κοντά στην οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ή σε μεμονωμένες περιοχές μέσω του [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και υπογραμμισμένη με κουκκίδες μορφοποίηση. Η ρητή μορφοποίηση σε μεμονωμένες περιοχές έχει προτεραιότητα έναντι αυτών των προεπιλογών:

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείων, πλάγια μορφοποίηση και υπογράμμιση με κουκκίδες σε περιοχές των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) για να ορίσετε μια προ‑ορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό του κειμένου στο σχήμα σε [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The text rotation](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

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

![The custom text rotation](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμής Παραγράφων**

Aspose.Slides παρέχει τα [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) και [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) για τον έλεγχο του διαστήματος παραγράφου. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

- Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.
- Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστημα γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει το διάστημα εντός της πρώτης παραγράφου στα 200 % του ύψους της γραμμής (διπλό διάστημα):

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

![The line spacing within the paragraph](line_spacing.png)

## **Έλεγχος Διαχωρισμού Γραμμής**

Οι κανόνες διαχωρισμού γραμμής παραγράφων είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και ασιατικό κείμενο. Οι ακόλουθες ιδιότητες ανήκουν στον [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), οπότε εφαρμόζονται σε ολόκληρη την παράγραφο:

- Το [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) ελέγχει τους κανόνες διαχωρισμού για λατινικό κείμενο. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου το πλάγιο ασιατικό κείμενο και η στίξη περνούν στην επόμενη γραμμή.
- Το [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ελέγχει τους κανόνες διαχωρισμού για ασιατικό κείμενο, συμπεριλαμβανομένων των περιορισμών στους χαρακτήρες στην αρχή και στο τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), το οποίο ενεργοποιεί αυτόματο αναδίπλωση μέσα σε ένα πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν η αναδίπλωση συμβαίνει· δεν προσθέτουν χαρακτήρες αλλαγής γραμμής. Μια ρητή αλλαγή γραμμής αναγκάζει μια νέα γραμμή μέσα στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει κινέζικο και λατινικό κείμενο. Ορίζει ρητά και τις δύο ιδιότητες διαχωρισμού και αποθηκεύει το «line_breaking.pptx». Για να πειραματιστείτε με κάθε κανόνα, αλλάξτε την τιμή της αντίστοιχης ιδιότητας διατηρώντας την άλλη αμετάβλητη. Το παράδειγμα χρησιμοποιεί Arial 24 σημείων και SimSun με πλάτος πλαισίου 160 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ορίζεται σε [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις του πλαισίου να παραμείνουν σταθερά.

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

## **Έλεγχος Κρεμαστής Στίξης**

Το [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) επιτρέπει σε επιλέξιμη στίξη να εκτείνεται πέρα από το δεξιό άκρο της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από την κρεμαστή εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί την κρεμαστή στίξη σε ένα πλαίσιο κειμένου 100 σημείων πλάτος και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, η τελική τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από το δεξιό άκρο του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργοποιημένη και το autofit απενεργοποιημένο για διατήρηση του διαθέσιμου πλάτους.

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

Δεν μπορεί να κρεμαστεί κάθε σημείο στίξης. Το οπτικό αποτέλεσμα εξαρτάται από τις [προϋποθέσεις γραμματοσειράς και διάταξης](#control-line-breaking): η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων autofit μπορεί να αφαιρέσει τη διαφορά.

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερχειλίζει ή αλλάζει το μέγεθος του σχήματος αυτόματα. Το παρακάτω παράδειγμα διαμορφώνει το σχήμα ώστε να προσαρμόζεται ώστε να χωρά το κείμενό του και αποθηκεύει το αποτέλεσμα στο «autofit_type.pptx».

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς η αλλαγή του πλάτους κειμένου ή του σχήματος επηρεάζει το αποτέλεσμα, δείτε [Καταμέτρηση Σχεδιασμένων Γραμμών](/slides/el/python-net/manage-paragraph/). Η απλή καταμέτρηση γραμμών δεν υποδεικνύει αν το κείμενο υπερχειλίζει τον περιέκτη του.

## **Ορισμός Άγκωσης Πλαισίων Κειμένου**

Το [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) ορίζει πώς το κείμενο τοποθετείται κάθετα μέσα σε ένα σχήμα, π.χ. στην κορυφή, στο κέντρο ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκαλιάζει το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο «text_anchor.pptx».

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Στηλοθετών Κειμένου**

Χρησιμοποιήστε τα [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) και [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) για να ρυθμίσετε τα σημεία τῆς στηλοθέτη σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα στηλοθέτη στα 100 σημεία και προσθέτει ένα αριστερά ευθυγραμμισμένο σημείο στηλοθέτη στα 30 σημεία. Οι ρυθμίσεις αυτές επηρεάζουν το κείμενο που περιέχει χαρακτήρες στηλοθέτη.

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

![Οι στηλοθέτες της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου**

Το Aspose.Slides παρέχει το [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), το οποίο επιτρέπει να ορίσετε τη γλώσσα ελέγχου για μια περιοχή κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικούς και γραμματικούς ελέγχους στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με «1。」», ορίζει το SimSun ως γραμματοσειρά του και ορίζει τη γλώσσα ελέγχου σε Απλοποιημένα Κινέζικα (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο «proofing_language.pptx»:

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

    # Ορίστε τη γλώσσα ελέγχου σε απλοποιημένα κινέζικα.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με αμερικανικά αγγλικά ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για την πρώτη του περιοχή κειμένου.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Προσθέστε ένα νέο σχήμα ορθογωνίου με κείμενο.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ελέγξτε τη γλώσσα του πρώτου τμήματος.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Το παρακάτω παράδειγμα ορίζει γραμματοσειρά 14 σημείων, έντονη, ως προεπιλογή για παραγράφους πρώτου επιπέδου σε μια νέα παρουσίαση και το αποθηκεύει στο «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός αν κάποια πιο συγκεκριμένη μορφοποίηση τις παρακάμπτει.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Λάβετε τη μορφή παραγράφου του υψηλότερου επιπέδου.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Ανάκτηση Κειμένου με την Επίδραση Όλων σε Κεφαλαία**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται σε κεφαλαία στην διαφάνεια ακόμη και αν αρχικά είχε πληκτρολογηθεί με πεζά. Όταν ανακτάτε μια τέτοια περιοχή κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως καταχωρήθηκε. Για να ταιριάζει το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) και μετατρέψτε το επιστρεφόμενο string σε κεφαλαία όταν η τιμή είναι `ALL`.

Το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη παράγραφος του πρώτου του τμήματος περιέχει το κείμενο «Hello, Aspose!» με ενεργό το εφέ All Caps, όπως φαίνεται παρακάτω.

![Η Επίδραση Όλων σε Κεφαλαία](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το εφέ **All Caps** εφαρμόσμένο:

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

## **FAQ**

**Πώς μπορώ να τροποποιήσω κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Περιηγηθείτε στα κελιά και ενημερώστε κάθε κελί μέσω του [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) και τη μορφοποίηση παραγράφου μέσω του [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Πώς μπορώ να εφαρμόσω χρώμα διαβάσματος σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάσματος σε κείμενο, χρησιμοποιήστε το [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Ορίστε το [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάσματος, την κατεύθυνση και τη διαφάνεια.