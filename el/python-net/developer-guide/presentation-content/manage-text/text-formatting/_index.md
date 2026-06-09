---
title: Μορφοποίηση Κειμένου Παρουσίασης σε Python
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/python-net/text-formatting/
keywords:
- επισήμανση κειμένου
- κανονική έκφραση
- στοίχηση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα autofit
- άγκυρα πλαισίου κειμένου
- ταμπάρισμα κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μορφοποίηση και στυλιζάρισμα κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχηση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for Python via .NET. Καλύπτει την επισήμανση, τα χρώματα φόντου, τη διαφάνεια, το διάστημα χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά autofit, την αγκύρωση κειμένου, τις στάσεις στηλοθετών και τις ρυθμίσεις γλώσσας.

Στα παραδείγματα παρακάτω, θα χρησιμοποιήσουμε ένα αρχείο με όνομα **"sample.pptx"**, το οποίο περιέχει ένα μοναδικό πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [TextFrame.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_text/) όταν χρειάζεται να επισημάνετε κείμενο που ταιριάζει με ένα συγκεκριμένο δείγμα εντός ενός πλαισίου κειμένου. Η μέθοδος εφαρμόζει χρώμα επισήμανσης στα τμήματα κειμένου που ταιριάζουν και μπορεί να χρησιμοποιηθεί με το [TextSearchOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/) για να ελέγξει πώς εκτελείται η αναζήτηση, π.χ. για να ταιριάζει μόνο ολόκληρες λέξεις.

Ο κώδικας παρακάτω επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη λέξη **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Λάβετε το πρώτο σχήμα από την πρώτη διαφάνεια.
    shape = presentation.slides[0].shapes[0]

    # Επισημάνετε τη λέξη "try" στο σχήμα.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # Επισημάνετε τη λέξη "to" στο σχήμα.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου με Κανονικές Εκφράσεις**

Η μέθοδος [TextFrame.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_regex/) επισημαίνει τα ταιριασμένα κείμενα που βρέθηκαν με κανονική έκφραση. Σε Python, αυτό το API εκτίθεται στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).

Ο κώδικας παρακάτω επισημαίνει όλες τις λέξεις που περιέχουν **επτά ή περισσότερους χαρακτήρες**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # Επισημάνετε όλες τις λέξεις με επτά ή περισσότερους χαρακτήρες.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο με χρήση κανονικής έκφρασης](highlighted_text_using_regex.png)

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/default_portion_format/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης μιας παραγράφου ή το [PortionFormat.highlight_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/highlight_color/) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **ολόκληρη την παράγραφο**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Τα γκρι τμήματα κειμένου](gray_text_portions.png)

## **Στοίχηση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.alignment](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/alignment/) για να ορίσετε τη στοίχηση της παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, ευθυγραμμισμένη και άλλα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοίχιση την παράγραφο **στο κέντρο**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε τη στοίχιση της παραγράφου στο κέντρο.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφανούς για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα‑συστατικού του χρώματος που έχει οριστεί στο [PortionFormat.fill_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/fill_format/). στα παραδείγματα παρακάτω, `alpha = 50` είναι τιμή αλφα‑καναλιού ARGB στην κλίμακα 0‑255, όχι ποσοστό διαφάνειας.

Ο κώδικας παρακάτω δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε τη διαφάνεια του τμήματος κειμένου.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστήματος Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [BasePortionFormat.spacing](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/spacing/) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας Python δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων στην **ολόκληρη την παράγραφο**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Αύξηση διαστήματος χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
            portion.portion_format.spacing = 3  # Αύξηση διαστήματος χαρακτήρων.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδει το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο στενά από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρα δεδομένα kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να κάνετε την απόδοση πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν τηffected γραμματοσειρά. Ορίστε το [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) σε τιμή σημαντικά μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Αυτή η ρύθμιση αποτρέπει την εφαρμογή του kerning σε τμήματα κειμένου που ταιριάζουν και μπορεί να βοηθήσει στην ευθυγράμμιση της απόδοσης του Aspose.Slides με το οπτικό αποτέλεσμα του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες της γραμματοσειράς μπορούν να οριστούν στο επίπεδο παραγράφου μέσω του [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/default_portion_format/) ή σε μεμονωμένα τμήματα μέσω του [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/).

Ο παρακάτω κώδικας ορίζει τη γραμματοσειρά και το στυλ κειμένου για ολόκληρη την παράγραφο: εφαρμόζει μέγεθος γραμματοσειράς, έντονη, πλάγια, διακεκομμένη υπογράμμιση και τη γραμματοσειρά Times New Roman σε όλα τα τμήματα της παραγράφου.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα κώδικα εφαρμόζει παρόμοιες ιδιότητες σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

![Οι ιδιότητες γραμματοσειράς για τα τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/text_vertical_type/) για να ορίσετε προεπιλεγμένη προσανατολισμό κειμένου μέσα σε σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε `VERTICAL270`, που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/rotation_angle/) για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).

Ο κώδικας παρακάτω περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμών Παραγράφων**

Το Aspose.Slides παρέχει τις μεθόδους [ParagraphFormat.space_after](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/space_before/), και [ParagraphFormat.space_within](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/space_within/) για τον έλεγχο του διαστήματος παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστημα γραμμής σε points.

Ο παρακάτω κώδικας δείχνει πώς να ορίσετε το διάστημα γραμμής μέσα στην παράγραφο:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διάστημα γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/autofit_type/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερχεί ή αναπροσαρμόζει το σχήμα αυτόματα.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

Το [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/anchoring_type/) ορίζει πώς τοποθετείται κατακόρυφα το κείμενο μέσα σε σχήμα, π.χ. στην κορυφή, το κέντρο ή το κάτω μέρος.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Ταμπώσεων Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/default_tab_size/) και το [ParagraphFormat.tabs](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/tabs/) για να ρυθμίσετε τις στάσεις ταμπ στην παράγραφο.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι ταμπές της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου**

Το Aspose.Slides παρέχει το [PortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/language_id/), το οποίο σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για τον ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Ο παρακάτω κώδικας δείχνει πώς να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Ορίστε το Id μιας γλώσσας ελέγχου.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.default_text_language](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/default_text_language/) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή δημιουργία μιας παρουσίασης.

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

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [Presentation.default_text_style](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/default_text_style/).

Ο παρακάτω κώδικας δείχνει πώς να ορίσετε προεπιλεγμένη έντονη γραμματοσειρά με μέγεθος 14 pt για όλο το κείμενο σε όλες τις διαφάνειες μιας νέας παρουσίασης.

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

## **Εξαγωγή Κειμένου με Επίδραση Όλων Πρακτικών (All‑Caps)**

Στο PowerPoint, η εφαρμογή της επίδρασης **All Caps** στη γραμματοσειρά κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και αν έχει πληκτρολογηθεί αρχικά με πεζά. Όταν ανακτάτε τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως είχε εισαχθεί. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/python-net/aspose.slides/textcaptype/) και μετατρέψτε το επιστρεφόμενο string σε κεφαλαία όταν η τιμή είναι `ALL`.

Ας πούμε ότι έχουμε το ακόλουθο πλαίσιο κειμένου στην πρώτη διαφάνεια του αρχείου sample2.pptx.

![Η επίδραση All Caps](all_caps_effect.png)

Ο κώδικας παρακάτω δείχνει πώς να εξάγετε το κείμενο με την εφαρμοσμένη επίδραση **All Caps**:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

## **Συχνές Ερωτήσεις**

**Πώς να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/). Κάντε επανάληψη στα κελιά και ενημερώστε κάθε κελί μέσω του [Cell.text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/text_frame/) και τη μορφοποίηση παραγράφων μέσω του [Paragraph.paragraph_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/paragraph_format/).

**Πώς να εφαρμόσετε διαβαθμισμένο χρώμα σε κείμενο σε διαφάνεια PowerPoint;**

Για να εφαρμόσετε ένα διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε το [PortionFormat.fill_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/fill_format/). Ορίστε το [FillFormat.fill_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/fill_type/) σε [FillType.GRADIENT](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.