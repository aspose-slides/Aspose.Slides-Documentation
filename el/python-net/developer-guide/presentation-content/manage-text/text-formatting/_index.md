---
title: Μορφοποίηση κειμένου παρουσίασης σε Python
linktitle: Μορφοποίηση κειμένου
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
- προστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστιχο
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μορφοποίηση και διαμόρφωση κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχηση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for Python via .NET. Καλύπτει χρώματα φόντου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, απόσταση παραγράφων, συμπεριφορά αυτόματης προσαρμογής, αγκύρωση κειμένου, σημεία στήλης και ρυθμίσεις γλώσσας.

Εκτός αν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνεια του είναι ένα πλαίσιο κειμένου και η πρώτη του παράγραφος περιέχει το κείμενο που φαίνεται παρακάτω. Και οι δείκτες διαφάνειας και σχήματος είναι μηδενικής βάσης. Παραδείγματα που επιλέγουν έντονα τμήματα χρησιμοποιούν αποτελεσματική μορφοποίηση, περιλαμβάνοντας κληρονομημένη έντονη μορφοποίηση:

![Sample text](sample_text.png)

Για εύρεση και επισήμανση κυριολεκτικού κειμένου ή αντιστοιχίσεων με κανονικές εκφράσεις, δείτε το [Search and Replace Text](/slides/el/python-net/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο ή το [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα ορίζει ένα ανοιχτό γκρι χρώμα επισήμανσης ως προεπιλογή για την πρώτη παράγραφο. Οι ρητές χρωματικές επισήμανσεις σε μεμονωμένα τμήματα έχουν προτεραιότητα πάνω από αυτήν την προεπιλογή:

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

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The gray text portions](gray_text_portions.png)

## **Στοίχηση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) για να ορίσετε τη στοίχηση παραγράφων μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερά, δεξιά, πλήρως ευθυγραμμισμένη κλπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ευθυγραμμίσετε την παράγραφο **στο κέντρο**:

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

## **Στοίχηση Γραμματοσελίδων Μέσα σε Γραμμή**

Χρησιμοποιήστε το [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) για κάθετη στοίχηση τμημάτων κειμένου διαφορετικού μεγέθους γραμματοσειράς μέσα σε μια γραμμή. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παράγραφο και ελέγχει τη στοίχηση σε κάθε γραμμή της.

Το παρακάτω αυτόματο παράδειγμα δημιουργεί τέσσερα επισημασμένα πλαίσια κειμένου σε μία διαφάνεια. Κάθε παράγραφος περιέχει το ίδιο κείμενο στα 18, 36 και 54 σημεία, με διαφορετική στοίχηση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί την αυτόματη προσαρμογή και τη συσσώρευση, και κρατά τα πλαίσια κειμένου αρκετά μεγάλα για μία γραμμή.

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

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

Η στοίχηση γραμματοσειράς χρησιμοποιεί μετρική γραμματοσειράς, οπότε οι ορατές άκρες των μεμονωμένων γραμμάτων δεν ευθυγραμμίζονται απαραίτητα ακριβώς. Το παράδειγμα περιλαμβάνει ένα κεφαλαίο γράμμα και ένα κατάτμημα για να δείξει τη διαφορά μεταξύ στοίχισης στη βάση και στο κάτω μέρος. Η διαθεσιμότητα και η αντικατάσταση γραμματοσειρών, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στο μέγεθος γραμματοσειράς επηρεάζουν το αποτέλεσμα. Οι διαστάσεις πλαισίου, τα περιθώρια, η απόσταση γραμμών, η συσσώρευση και η αυτόματη προσαρμογή επηρεάζουν επίσης τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και ρυθμίσεις διάταξης όταν συγκρίνετε τις λειτουργίες.

Αυτή η ρύθμιση διαφέρει από το [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), που ελέγχει οριζόντια στοίχηση παραγράφου, και το [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), που τοποθετεί το μπλοκ κειμένου κάθετα μέσα στο σχήμα του. Η υπεργράμμιση και υπογράμμιση μέσω του [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) μετατοπίζει μεμονωμένα τμήματα σε σχέση με τη βάση αντί να ορίζει στοίχηση γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια κειμένου ελέγχεται μέσω του αλφα-συστατικού του χρώματος που έχει οριστεί στο [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή καναλιού ARGB αλφα στο εύρος 0–255, όχι ποσοστό διαφάνειας.

Το παράδειγμα κώδικα παρακάτω δείχνει πώς να εφαρμόσετε διαφάνεια σε **ολόκληρη την παράγραφο**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε μισοδιαφανή μαύρο γέμισμα για το κείμενο.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The transparent paragraph](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

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
            # Ορίστε τη διαφάνεια του τμήματος κειμένου.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The transparent text portions](transparent_text_portions.png)

## **Ορισμός Απόστασης Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία απόστασης· οι αρνητικές τιμές μειώνουν το κείμενο.

Το παρακάτω κώδικα Python δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **ολόκληρη την παράγραφο**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπτύξετε την απόσταση χαρακτήρων.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Αυξήστε την απόσταση χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπτύξετε την απόσταση χαρακτήρων.
            portion.portion_format.spacing = 3  # Αυξήστε την απόσταση χαρακτήρων.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο στενό από το ίδιο κείμενο στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint αγνοεί δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε την απόδοση πιο κοντά στο PowerPoint, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν την επηρεαζόμενη γραμματοσειρά. Ορίστε το [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Αυτό το παράδειγμα απαιτεί το "presentation.pptx" με πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και θέτει όριο 100 σημεία για τμήματα που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί το kerning για τμήματα που έχουν μέγεθος γραμματοσειράς κάτω από 100 σημεία:

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

Για κείμενο που ταιριάζει κάτω από το όριο, αυτή η ρύθμιση εμποδίζει το kerning και μπορεί να βοηθήσει στο να ευθυγραμμιστεί η απόδοση του Aspose.Slides με την οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά συγκεκριμένη του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ή σε μεμονωμένα τμήματα μέσω του [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και υπογράμμιση με τελεία. Η ρητή μορφοποίηση σε μεμονωμένα τμήματα έχει προτεραιότητα πάνω από αυτές τις προεπιλογές:

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

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείων, πλάγια μορφοποίηση και υπογράμμιση με τελεία σε τμήματα των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε τις ιδιότητες γραμματοσειράς για το τμήμα κειμένου.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Έλεγχος Κανονικοποίησης Ύψους Κειμένου**

Χρησιμοποιήστε το [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) όταν αναπαράγετε τυπογραφία προτύπου ή ερευνάτε διαφορές στο ύψος χαρακτήρων. Στο PowerPoint, η ενεργοποίηση της κανονικοποίησης τεντώνει ή συμπιέζει κάθε χαρακτήρα κατακόρυφα ώστε να έχει ομοιόμορφο ορατό ύψος μέσα στο τμήμα κειμένου. Δεν εγγυάται ίσο ύψος κειμένου μεταξύ διαφορετικών γραμματοσειρών.

Ορίστε την ιδιότητα σε [NullableBool.TRUE ή FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) για ρητή ενεργοποίηση ή απενεργοποίηση της κανονικοποίησης. `NullableBool.NOT_DEFINED` αφήνει την τοπική ρύθμιση ακαθορισμένη ώστε το τμήμα να κληρονομήσει την τιμή του, π.χ. από το [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) της παραγράφου. Δεν σημαίνει `False`. Χρησιμοποιήστε το [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) και διαβάστε το [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) για την επιλυμένη Boolean τιμή.

Το παρακάτω αυτόματο παράδειγμα απαιτεί **Arial** εγκατεστημένο. Δημιουργεί δύο μπλοκ κειμένου με τα ίδια κεφαλαία, πεζά, τόνους και γράμματα με τόνους σε 54 σημεία. Και οι δύο παράγραφοι ενεργοποιούν την κανονικοποίηση από προεπιλογή. Το πάνω τμήμα την απενεργοποιεί ρητά· το κάτω τμήμα την κληρονομεί. Τα μεγέθη πλαισίου, τα περιθώρια και η απόσταση παραγράφων είναι ίδια, με συσσώρευση και αυτόματη προσαρμογή απενεργοποιημένα για σταθερή σύγκριση. Το παράδειγμα εκτυπώνει `FALSE: False` και `NOT_DEFINED: True`, στη συνέχεια αποθηκεύει το "text_height_normalization.pptx".

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

Η σύγκριση παρακάτω εξήχθη από την αποθηκευμένη παρουσίαση. Η πάνω σειρά έχει απενεργοποιημένη κανονικοποίηση (`FALSE`); η κάτω σειρά κληρονομεί την ενεργοποιημένη ρύθμιση (`NOT_DEFINED` → `True`). Διατηρήστε το Arial εγκατεστημένο για να αναπαράγετε αυτήν την εμφάνιση.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Η κανονικοποίηση αλλάζει το ύψος των χαρακτήρων χωρίς να αλλάζει την τιμή [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) που καθορίζει το μέγεθος γραμματοσειράς σε σημεία. Η ιδιότητα [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) της παραγράφου ελέγχει την απόσταση γραμμών, ενώ η ιδιότητα [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) του πλαισίου κειμένου ελέγχει πώς το κείμενο ή το δοχείο του προσαρμόζεται για να χωρέσει. Αυτές οι ρυθμίσεις εξυπηρετούν διαφορετικούς σκοπούς και μπορούν ανεξάρτητα να επηρεάσουν τη συνολική διάταξη. Για περισσότερα σχετικά με τη μορφοποίηση παραγράφων και την κληρονομικότητα, δείτε το [Manage Paragraph](/slides/el/python-net/manage-paragraph/).

## **Εφαρμογή και Κατάργηση Διακοσμής Διαγράμμου**

Χρησιμοποιήστε το [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) σε τμήμα κειμένου για να εμφανίσετε διορθώσεις, ακυρωμένες εκφράσεις ή προηγούμενες τιμές χωρίς διαγραφή του αρχικού κειμένου. Ορίστε το σε [TextStrikethroughType.SINGLE ή DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) για μία ή δύο γραμμές διαγράμμου.

Για να καταργήσετε τη διακοσμή, ορίστε `TextStrikethroughType.NONE`. Αυτό απενεργοποιεί ρητά το εφέ, ακόμη και αν η γύρω μορφοποίηση καθορίζει διακοσμή. Αντίθετα, το `TextStrikethroughType.NOT_DEFINED` αφήνει την τοπική ρύθμιση ακαθόριστη, επιτρέποντας στο τμήμα να κληρονομήσει μορφοποίηση, π.χ. από την παράγραφο. Δεν εγγυάται ότι η διακοσμή έχει καταργηθεί. Χρησιμοποιήστε το [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) για να διαβάσετε τη μορφοποίηση που προκύπτει, συμπεριλαμβανομένων των κληρονομημένων τιμών.

Το παρακάτω αυτόματο παράδειγμα δημιουργεί τρεις συγκρίσεις τιμών. Κάθε παράγραφος έχει ξεχωριστά τμήματα για την ετικέτα, την προηγούμενη τιμή και την τρέχουσα τιμή, ώστε μόνο η προηγούμενη τιμή να επηρεάζεται. Η πρώτη σειρά εφαρμόζει και στη συνέχεια αφαιρεί τη διακοσμή· οι άλλες σειρές διατηρούν τη μοναδική και τη διπλή διακοσμή. Η αλλαγή αυτής της ιδιότητας διατηρεί το κείμενο και τις άλλες μορφοποιήσεις του, συμπεριλαμβανομένης της έντονης προηγούμενης τιμής.

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

    # Εφαρμόστε τη διαγράμμιση, μετά αφαιρέστε την ρητά από την πρώτη προηγούμενη τιμή.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα, από πάνω προς τα κάτω: χωρίς διακοσμή, με μονή διακοσμή και με διπλή διακοσμή.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) για να ορίσετε μια προεπιλεγμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

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

## **Ορισμός Απόστασης Γραμμής Παραγράφων**

Το Aspose.Slides παρέχει τα [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) και [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) για έλεγχο απόστασης παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε την απόσταση γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε την απόσταση γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει την απόσταση εντός της πρώτης παραγράφου στο 200 % του ύψους της γραμμής (διπλή απόσταση):

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

## **Έλεγχος Αλλαγής Γραμμής**

Οι κανόνες αλλαγής γραμμής παραγράφων είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και ασιατικό κείμενο. Οι παρακάτω ιδιότητες ανήκουν στο [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), οπότε εφαρμόζονται σε ολόκληρη την παράγραφο:

* Το [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) ελέγχει τους κανόνες αλλαγής γραμμής για λατινικό κείμενο. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου το γειτονικό ασιατικό κείμενο και η στίξη τυλίγονται.
* Το [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ελέγχει τους κανόνες αλλαγής γραμμής για ασιατικό κείμενο, συμπεριλαμβανομένων περιορισμών στους χαρακτήρες στην αρχή και στο τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), που ενεργοποιεί αυτόματη συσσώρευση μέσα σε πλαίσιο κειμένου. Επιρρεάζουν τη διάταξη όταν η συσσώρευση συμβαίνει· δεν εισάγουν χαρακτήρες αλλαγής γραμμής. Μια ρητή αλλαγή γραμμής προκαλεί νέα γραμμή στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόματο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει κινεζικά και λατινικά. Ορίζει ρητά και τις δύο ιδιότητες αλλαγής γραμμής και αποθηκεύει το "line_breaking.pptx". Για πειραματισμό με οποιονδήποτε κανόνα, αλλάξτε την τιμή της ιδιότητας διατηρώντας τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημεία και SimSun με πλάτος πλαισίου 160 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ορίζεται σε [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις πλαισίου να παραμείνουν σταθερά.

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

## **Έλεγχος Κρεμαστών Σημείων Στίξης**

Το [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) επιτρέπει στα επιλέξιμα σημεία στίξης να εκτείνονται έξω από το δεξιό άκρο της γραμμής κειμένου αντί να καταλαμβάνουν την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από την κρεμαστή εσοχή.

Το παρακάτω αυτόματο παράδειγμα ενεργοποιεί κρεμαστές στίξεις σε πλαίσιο κειμένου πλάτους 100 σημεία και αποθηκεύει το "hanging_punctuation.pptx". Με Arial 24 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου, η τελική τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από το δεξί άκρο του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η συσσώρευση είναι ενεργοποιημένη και η αυτόματη προσαρμογή απενεργοποιημένη για να παραμείνει το διαθέσιμο πλάτος σταθερό.

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

Δεν μπορεί να κρεμαστεί κάθε σημάδι στίξης. Το ορατό αποτέλεσμα εξαρτάται από [συνθήκες γραμματοσειράς και διάταξης](#control-line-breaking): η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων αυτόματης προσαρμογής μπορεί να αφαιρέσει τη διαφορά.

## **Ορισμός Τύπου Αυτόματης Προσαρμογής για Πλαίσια Κειμένου**

Το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του κοντέινερ του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερβαίνει ή το σχήμα προσαρμόζεται αυτόματα. Το παρακάτω παράδειγμα διαμορφώνει το σχήμα ώστε να αλλάζει μέγεθος ώστε να χωράει το κείμενό του και αποθηκεύει το αποτέλεσμα στο "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Για να μετρήσετε γραμμές μετά την αυτόματη συσσώρευση και να δείτε πώς η αλλαγή πλάτους κειμένου ή σχήματος επηρεάζει το αποτέλεσμα, δείτε το [Count Rendered Lines](/slides/el/python-net/manage-paragraph/). Η απλή καταμέτρηση γραμμών δεν υποδεικνύει αν το κείμενο υπερβαίνει το κοντέινερ του.

## **Ορισμός Άγκυρας Πλαισίου Κειμένου**

Το [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) ορίζει πώς το κείμενο τοποθετείται κάθετα μέσα σε ένα σχήμα, π.χ. στην κορυφή, στη μέση ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Στηλοθέτησης Κειμένου**

Χρησιμοποιήστε τα [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) και [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) για να διαμορφώσετε τα σημεία στήλης σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει την προεπιλεγμένη απόσταση στήλης στα 100 σημεία και προσθέτει ένα αριστερά ευθυγραμμισμένο σημείο στήλης στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν κείμενο που περιέχει χαρακτήρες στήλης.

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

![The paragraph tabs](paragraph_tabs.png)

## **Ορισμός Γλώσσας Δοκιμής Ορθογραφίας**

Το Aspose.Slides παρέχει το [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), που επιτρέπει να ορίσετε τη γλώσσα δοκιμής ορθογραφίας για ένα τμήμα κειμένου. Η γλώσσα δοκιμής ορθογραφίας καθορίζει την γλώσσα που χρησιμοποιείται για ελέγχους ορθογραφίας και γραμματικής στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το "presentation.pptx" με πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με «1。», ορίζει τη γραμματοσειρά SimSun και ορίζει τη γλώσσα δοκιμής ορθογραφίας για απλοποιημένα κινέζικα (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο "proofing_language.pptx":

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

    # Ορίστε τη γλώσσα ελέγχου ορθογραφίας σε απλοποιημένα κινέζικα.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Αντιγραφή Μεταδεδομένων Γλώσσας**

Κατά την αντιγραφή πολυγλωσσικού κειμένου από πρότυπο, διατηρήστε τόσο το [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) όσο και το [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Το παρακάτω αυτόματο παράδειγμα δημιουργεί ένα τμήμα προέλευσης με US English ως γλώσσα του και Γαλλική ως εναλλακτική γλώσσα και αντιγράφει το κείμενο και τα αναγνωριστικά σε τμήμα σε νέα παρουσίαση.

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

Για δοκιμή μιας προέλευσης χωρίς εναλλακτική γλώσσα, παραλείψτε την ανάθεση του `"fr-FR"`. Το εναλλακτικό αναγνωριστικό τότε είναι `None` και η ίδια δήλωση αντιγραφής διατηρεί την απουσία του χωρίς εισαγωγή προεπιλεγμένης τιμής, ακόμη και αν ο προορισμός είχε προηγουμένως εναλλακτική γλώσσα ορισμένη.

Αυτά τα αναγνωριστικά αποθηκεύουν μεταδεδομένα γλώσσας. Η διατήρησή τους δεν καθορίζει ποιο λεξικό θα επιλέξει το PowerPoint για έλεγχο ορθογραφίας ή γραμματικής.

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) για να ορίσετε τη προεπιλεγμένη γλώσσα κειμένου που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με US English ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και τυπώνει `en-US` για το πρώτο τμήμα κειμένου του.

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

Το παρακάτω παράδειγμα ορίζει γραμματοσειρά 14 σημείων με έντονη γραφή ως προεπιλογή για παραγράφους κορυφαίου επιπέδου σε νέα παρουσίαση και το αποθηκεύει ως "default_text_style.pptx". Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός αν πιο συγκεκριμένη μορφοποίηση τις αντικαταστήσει.

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

## **Εξαγωγή Κειμένου με Εφέ Όλων Τα Κεφαλαία**

Στο PowerPoint, η εφαρμογή του εφέ γραμματοσειράς **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία στην διαφάνεια, ακόμη και όταν είχε αρχικά πληκτρολογηθεί με πεζά. Όταν ανακτάτε τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) και μετατρέψτε τη επιστραφείσα συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `ALL`.

Αυτό το παράδειγμα απαιτεί το "sample2.pptx" με πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη παράγραφος του πρώτου τμήματος περιέχει το «Hello, Aspose!», με το εφέ All Caps εφαρμοσμένο, όπως φαίνεται παρακάτω.

![The All Caps effect](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξαγάγετε το κείμενο με το εφέ **All Caps** εφαρμόσμένο:

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

**Πώς μπορώ να τροποποιήσω το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε πίνακα σε διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Επανάληψη μέσω των κελιών και ενημέρωση κάθε κελιού μέσω του [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) και μορφοποίηση παραγράφων μέσω του [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Πώς μπορώ να εφαρμόσω χρώμα διαβάθμισης σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Ορίστε το [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.

Σχετικό χαρακτηριστικό: [Format text within slides](/slides/el/features/text-formatting/).