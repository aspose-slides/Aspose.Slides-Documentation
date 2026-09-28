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
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμών
- ιδιότητα αυτοπροσαρμογής
- άγκυρα πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μορφοποίηση και στυλ κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να διαμορφώσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Καλύπτει χρώματα φόντου, διαφάνεια, διάστημα χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, διάστημα παραγράφων, συμπεριφορά αυτόματης προσαρμογής, αγκύρωση κειμένου, σημεία στηλοθέτη και ρυθμίσεις γλώσσας.

Εκτός εάν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα πλαίσιο κειμένου, και η πρώτη παράγραφο του περιέχει το κείμενο που εμφανίζεται παρακάτω. Οι δείκτες των διαφανειών και των σχημάτων είναι μηδενική βάση. Παραδείγματα που επιλέγουν έντονες ενότητες χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δειγματικό κείμενο](sample_text.png)

Για να βρείτε και να τονίσετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικών εκφράσεων, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/python-net/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/default_portion_format/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/highlight_color/) για μεμονωμένες ενότητες κειμένου.

Το παρακάτω παράδειγμα ορίζει μια ανοιχτόγκρι επισήμανση ως προεπιλογή για την πρώτη παράγραφο. Οι ρητές χρωματικές επισήμανση σε μεμονωμένες ενότητες έχουν προτεραιότητα έναντι αυτής της προεπιλογής:

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

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **ενότητες κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε το χρώμα επισήμανσης για την ενότητα κειμένου.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι γκρι ενότητες κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε [ParagraphFormat.alignment](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/alignment/) για να ορίσετε την στοίχιση παραγράφων μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, πλήρης στοίχιση κλπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοιχίσετε την παράγραφο στο **κέντρο**:

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

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα‑συστατικού του χρώματος που έχει οριστεί στο [BasePortionFormat.fill_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/fill_format/). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή καναλιού αλφα ARGB σε κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη παράγραφο**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ορίστε ένα ημιδιάφανο μαύρο γέμισμα για το κείμενο.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **ενότητες κειμένου με έντονη γραμματοσειρά**:

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
            # Ορίστε τη διαφάνεια της ενότητας κειμένου.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι διαφανείς ενότητες κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστήματος Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε [BasePortionFormat.spacing](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/spacing/) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία διάστημα· οι αρνητικές τιμές συμπιέζουν το κείμενο.

Ο παρακάτω κώδικας Python δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων στην **ολόκληρη παράγραφο**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Αυξήστε το διάστημα χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **ενότητες κειμένου με έντονη γραμματοσειρά**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
            portion.portion_format.spacing = 3  # Αυξήστε το διάστημα χαρακτήρων.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στις ενότητες κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Καρνίνγκ για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβεί επειδή το PowerPoint μπορεί να αγνοήσει τα δεδομένα καρνίνγκ για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες καρνίνγκ και το καρνίνγκ είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να κάνετε το παραγόμενο αποτέλεσμα πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το καρνίνγκ για ενότητες κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε το [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Αυτό το παράδειγμα απαιτεί το "presentation.pptx" με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων γραμματοσειρών, και ορίζει ένα όριο 100 σημείων για ενότητες που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί το καρνίνγκ για τις ενότητες που ταιριάζουν με μέγεθος γραμματοσειράς κάτω από 100 σημεία:

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

Για κείμενο που ταιριάζει κάτω από το όριο, αυτή η ρύθμιση αποτρέπει το καρνίνγκ και μπορεί να βοηθήσει στην ευθυγράμμιση της απόδοσης του Aspose.Slides με την οπτική έξοδο του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτήν τη συμπεριφορά του PowerPoint.

## **Διαχείριση Ιδιότητων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν στο επίπεδο παραγράφου μέσω του [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/default_portion_format/) ή σε μεμονωμένες ενότητες μέσω του [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και υπογράμμιση με κουκίδες. Η ρητή μορφοποίηση σε μεμονωμένες ενότητες έχει προτεραιότητα έναντι αυτών των προεπιλογών:

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

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείων, πλάγια μορφοποίηση και υπογράμμιση με κουκίδες σε ενότητες των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ορίστε τις ιδιότητες γραμματοσειράς για την ενότητα κειμένου.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τις ενότητες κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/text_vertical_type/) για να ορίσετε μια προ‑ορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/el/python-net/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η περιστροφή του κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/rotation_angle/) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).

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

## **Ορισμός Διαστήματος Γραμμών για Παραγράφους**

Το Aspose.Slides παρέχει τα [ParagraphFormat.space_after](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/space_before/), και [ParagraphFormat.space_within](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/space_within/) για να ελέγχει το διάστημα της παραγράφου. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

· Χρησιμοποιήστε θετική τιμή για να καθορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.  
· Χρησιμοποιήστε αρνητική τιμή για να καθορίσετε το διάστημα γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει το διάστημα μέσα στην πρώτη παράγραφο σε 200 % του ύψους της γραμμής (διπλό διάστημα):

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

## **Έλεγχος Διαχωρισμού Γραμμής**

Οι κανόνες διαχωρισμού γραμμής της παραγράφου είναι χρήσιμοι σε στενά τμήματα κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και ανατολικοασιατικό κείμενο. Οι παρακάτω ιδιότητες ανήκουν στο [ParagraphFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/), οπότε ισχύουν για ολόκληρη παράγραφο:

· [latin_line_break](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/latin_line_break/) ελέγχει τους κανόνες διαχωρισμού γραμμής για τα λατινικά. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου το γειτονικό ανατολικοασιατικό κείμενο και η στίξη κάθονται.  
· [east_asian_line_break](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ελέγχει τους κανόνες διαχωρισμού γραμμής για τα ανατολικοασιατικά, περιλαμβάνοντας περιορισμούς σε χαρακτήρες στην αρχή και το τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/wrap_text/), που ενεργοποιεί την αυτόματη αναδίπλωση μέσα σε ένα πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν γίνεται αναδίπλωση· δεν εισάγουν χαρακτήρες διαχωρισμού γραμμής. Ένας ρητός διαχωρισμός γραμμής αναγκάζει μια νέα γραμμή μέσα στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό τμήμα κειμένου που περιέχει κινέζικο και λατινικό κείμενο. Ορίζει ρητά και τις δύο ιδιότητες διαχωρισμού γραμμής και αποθηκεύει το "line_breaking.pptx". Για να πειραματιστείτε με κάποιον από τους κανόνες, αλλάξτε την τιμή αυτής της ιδιότητας κρατώντας τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημείων και SimSun με πλάτος πλαισίου 160 σημείων και μηδενικά οριζόντια περιθώρια πλαίσιου κειμένου. Το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/autofit_type/) ορίζεται σε [TextAutofitType.NONE](https://reference.aspose.com/slides/el/python-net/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις του πλαισίου να παραμείνουν σταθερές.

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

## **Έλεγχος Κρεμαστών Στοίχων**

Το [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/hanging_punctuation/) επιτρέπει σε κατάλληλη στίξη να εκτείνει το πέρασμα πέρα από τη δεξιά άκρη της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από μια κρεμαστή εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί κρεμαστή στίξη σε ένα πλαίσιο κειμένου πλάτους 100 σημείων και αποθηκεύει το "hanging_punctuation.pptx". Με Arial 24 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, η τελεία στο τέλος παραμένει μετά τη λέξη "sentence" και εκτείνεται πέρα από τη δεξιά άκρη του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.FALSE](https://reference.aspose.com/slides/el/python-net/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργοποιημένη και η αυτόματη προσαρμογή είναι απενεργοποιημένη ώστε το διαθέσιμο πλάτος να παραμένει σταθερό.

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

Δεν μπορεί κάθε στίγμα να κρεμαστεί. Το οπτικό αποτέλεσμα εξαρτάται από τη γραμματοσειρά και τις συνθήκες διάταξης: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων αυτόματης προσαρμογής μπορεί να αφαιρέσει τη διαφορά.

## **Ορισμός Τύπου Αυτόματης Προσαρμογής για Πλαίσια Κειμένου**

Το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/autofit_type/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιεχομένου του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, ξεχειλίζει ή το σχήμα αλλάζει μέγεθος αυτόματα. Το παρακάτω παράδειγμα διαμορφώνει το σχήμα ώστε να αλλάζει μέγεθος ώστε να χωρά το κείμενό του και αποθηκεύει το αποτέλεσμα στο "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς το κείμενο ή το πλάτος του σχήματος αλλάζει το αποτέλεσμα, δείτε [Καταμέτρηση Σχεδιασμένων Γραμμών](/slides/el/python-net/manage-paragraph/). Η απλή καταμέτρηση γραμμών δεν υποδεικνύει αν το κείμενο υπερβαίνει το περιεχόμενό του.

## **Ορισμός Άγκυρας των Πλαισίων Κειμένου**

Το [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/anchoring_type/) ορίζει πώς το κείμενο τοποθετείται κατακόρυφα μέσα σε ένα σχήμα, π.χ. στην κορυφή, το μέσο ή το κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Στηλοθέτη Κειμένου**

Χρησιμοποιήστε τα [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/default_tab_size/) και [ParagraphFormat.tabs](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/tabs/) για να διαμορφώσετε σημεία στηλοθέτη σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα στηλοθέτη στα 100 σημεία και προσθέτει ένα αριστερά στολισμένο σημείο στηλοθέτη στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν το κείμενο που περιέχει χαρακτήρες στηλοθέτη.

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

![Τα στηλοθέτη της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου**

Το Aspose.Slides παρέχει το [BasePortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/language_id/), το οποίο σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου για μια ενότητα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το "presentation.pptx" με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά τα περιεχόμενα της πρώτης παραγράφου με "1。", ορίζει τη SimSun ως γραμματοσειρά της και αντιστοιχεί τη γλώσσα ελέγχου απλουστευμένα κινέζικα (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο "proofing_language.pptx":

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

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions.default_text_language](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/default_text_language/) για να ορίσετε την προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με αγγλικά ΗΠΑ ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για την πρώτη ενότητα κειμένου της.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Προσθέστε ένα νέο σχήμα ορθογωνίου με κείμενο.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ελέγξτε τη γλώσσα της πρώτης ενότητας.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [Presentation.default_text_style](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/default_text_style/).

Το παρακάτω παράδειγμα ορίζει μια γραμματοσειρά 14 σημείων έντονη ως προεπιλογή για παραγράφους κορυφαίου επιπέδου σε μια νέα παρουσίαση και την αποθηκεύει στο "default_text_style.pptx". Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένη μορφοποίηση τις παρακάμψει.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Αποκτήστε τη μορφοποίηση ανώτερης επιπέδου παραγράφου.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Εξαγωγή Κειμένου με το Εφέ Όλες Κεφαλαία**

Στο PowerPoint, η χρήση του εφέ γραμματοσειράς **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία στο διαφάνεια, ακόμη και αν αρχικά πληκτρολογήθηκε με πεζά. Όταν ανακτάτε μια τέτοια ενότητα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/python-net/aspose.slides/textcaptype/) και μετατρέψτε το επιστρεφόμενο string σε κεφαλαία όταν η τιμή είναι `ALL`.

Αυτό το παράδειγμα απαιτεί το "sample2.pptx" με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη ενότητα της πρώτης παραγράφου περιέχει το "Hello, Aspose!" με εφαρμοσμένο το εφέ All Caps, όπως φαίνεται παρακάτω.

![Το εφέ Όλες Κεφαλαία](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το εφαρμόσμένο εφέ **All Caps**:

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

## **Συχνές Ερωτήσεις**

**Πώς τροποποιώ κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/). Περιηγηθείτε στα κελιά και ενημερώστε κάθε κελί μέσω του [Cell.text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/text_frame/) και τη μορφοποίηση παραγράφων μέσω του [Paragraph.paragraph_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/paragraph_format/).

**Πώς εφαρμόζω ένα χρώμα διαβάθμισης σε κείμενο σε διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [BasePortionFormat.fill_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/fill_format/). Ορίστε το [FillFormat.fill_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/fill_type/) σε [FillType.GRADIENT](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.