---
title: Αυτοματοποιήστε την Τοπικοποίηση Παρουσίασης με Python
linktitle: Τοπικοποίηση Παρουσίασης
type: docs
weight: 100
url: /el/python-net/presentation-localization/
keywords:
- αλλαγή γλώσσας
- έλεγχος ορθογραφίας
- κατάσβεση ελέγχου ορθογραφίας
- γλώσσα ελέγχου
- αναγνωριστικό γλώσσας
- πολύγλωσσο κείμενο
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ορίστε γλώσσες ελέγχου για το κείμενο παρουσίασης PowerPoint και OpenDocument σε Python με Aspose.Slides, συμπεριλαμβανομένων των προεπιλογών και των πολύγλωσσων παραγράφων."
---
## **Επισκόπηση**

Aspose.Slides for Python via .NET σας επιτρέπει να διαμορφώσετε μεταδεδομένα ελέγχου διόρθωσης για μεμονωμένα τμήματα κειμένου. Χρησιμοποιήστε [BasePortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/language_id/) για να προσδιορίσετε τη γλώσσα ελέγχου, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/spell_check/) για να επιτρέψετε ή να καταστείλετε τους ελέγχους ορθογραφίας, και [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/proof_disabled/) για να ελέγξετε την ευρύτερη κατάσταση «μη έλεγχος». Επειδή αυτές οι ρυθμίσεις εφαρμόζονται σε επίπεδο τμήματος, μια παράγραφος μπορεί να περιέχει πολλαπλές γλώσσες και διαφορετικούς κανόνες ελέγχου.

Αυτό το άρθρο εξηγεί πώς να αντιστοιχίσετε μια γλώσσα σε συγκεκριμένο κείμενο, να θέσετε τη γλώσσα προεπιλογής για νέο κείμενο με [LoadOptions.default_text_language](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/default_text_language/), να δημιουργήσετε πολύγλωσσα παραγράφους, να επιλέξετε μεταξύ `spell_check` και `proof_disabled`, και να διατηρήσετε τις προοριζόμενες ρυθμίσεις όταν χρησιμοποιείτε [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Αυτές οι ιδιότητες αποθηκεύουν μεταδεδομένα για εφαρμογές παρουσίασης· δεν μεταφράζουν το κείμενο, δεν εκτελούν έλεγχο ορθογραφίας με λεξικό, ούτε επιστρέφουν λανθασμένες λέξεις.

## **Ορισμός της Γλώσσας Ελέγχου για Κείμενο**

Δημιουργήστε ή φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/), προσπελάστε το απαιτούμενο τμήμα κειμένου μέσω [Portion.portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/portion_format/), και ορίστε το αναγνωριστικό γλώσσας του. Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα, ορίζει τη βρετανική αγγλική ως γλώσσα ελέγχου, και αποθηκεύει το αποτέλεσμα με [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός της Προεπιλεγμένης Γλώσσας για Νέο Κείμενο**

Χρησιμοποιήστε [LoadOptions.default_text_language](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/default_text_language/) για να καθορίσετε τη γλώσσα ελέγχου που το Aspose.Slides εκχωρεί στο νέο κείμενο. Αυτή η ρύθμιση είναι χρήσιμη όταν τα περισσότερα ή όλα τα νέα κείμενα σε μια παρουσίαση χρησιμοποιούν την ίδια γλώσσα. Δεν αλλάζει τα μεταδεδομένα γλώσσας του κειμένου που ήδη έχει ρητή γλώσσα.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση της οποίας το νέο κείμενο χρησιμοποιεί γερμανικούς κανόνες ελέγχου:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Χρήση Πολλαπλών Γλωσσών σε Μία Παράγραφο**

Ένα [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) περιέχει μια συλλογή τμημάτων κειμένου. Δημιουργήστε ξεχωριστό [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) για κάθε γλώσσα και ορίστε ανεξάρτητα το `language_id`.

Αυτό το παράδειγμα δημιουργεί μία παράγραφο με αγγλικά και γαλλικά τμήματα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενεργοποίηση ή Καταστολή Ελέγχου Ορθογραφίας για Μεμονωμένα Τμήματα**

[PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/) κληρονομεί τις κοινές ιδιότητες κειμένου που ορίζονται από [BasePortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/). Προσπελάστε τη μορφοποίηση ενός τμήματος μέσω [Portion.portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/portion_format/) και ορίστε [BasePortionFormat.spell_check](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/spell_check/) για να ελέγξετε εάν μια εφαρμογή παρουσίασης μπορεί να ελέγξει την ορθογραφία για εκείνο το τμήμα. Η προεπιλεγμένη τιμή είναι `False`: `True` επιτρέπει τον έλεγχο, ενώ `False` τον καταστέλλει.

Η ρύθμιση ισχύει για μεμονωμένα τμήματα κειμένου. Διαφορετικά τμήματα στην ίδια παράγραφο μπορούν επομένως να έχουν διαφορετικές τιμές. [BasePortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/language_id/) και `spell_check` εξυπηρετούν συμπληρωματικούς σκοπούς: το `language_id` προσδιορίζει τη γλώσσα ελέγχου, ενώ το `spell_check` καθορίζει αν επιτρέπεται ο έλεγχος ορθογραφίας για το τμήμα.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/proof_disabled/) ελέγχει επίσης τον έλεγχο, αλλά αντιπροσωπεύει την πιο ευρεία κατάσταση «μη έλεγχος» ως [NullableBool](https://reference.aspose.com/slides/el/python-net/aspose.slides/nullablebool/). Χρησιμοποιήστε `spell_check` όταν χρειάζεστε άμεσο διακόπτη Boolean για ελέγχους ορθογραφίας. Χρησιμοποιήστε `proof_disabled` όταν πρέπει να διατηρήσετε ή να ελέγξετε ρητά τα μεταδεδομένα «μη έλεγχος» της παρουσίασης, συμπεριλαμβανομένης της κατάστασης `NOT_DEFINED`. Εάν ορίσετε και τις δύο ιδιότητες, διατηρήστε τις τιμές τους συνεπείς· μην συνδυάζετε `spell_check = True` με `proof_disabled = slides.NullableBool.TRUE`.

Αυτές οι ιδιότητες διαμορφώνουν μεταδεδομένα ελέγχου που χρησιμοποιούν το PowerPoint και άλλες εφαρμογές παρουσίασης. Το Aspose.Slides δεν τις χρησιμοποιεί για εκτέλεση λεξικού ελέγχου ή επιστροφή λίστας λανθασμένων λέξεων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια παρουσίαση εισόδου, τη φορτώνει, αναθέτει διαφορετικές ρυθμίσεις ελέγχου και γλώσσες ελέγχου σε δύο τμήματα της ίδιας παραγράφου, αποθηκεύει το αποτέλεσμα, το ανοίγει ξανά, και επαληθεύει τις αποθηκευμένες τιμές:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) συνδυάζει γειτονικά τμήματα που έχουν την ίδια μορφοποίηση. Μια διαφορά μόνο στο `spell_check` δεν κρατά τα τμήματα χωριστά· μετά τη συνένωση, το προκύπτον τμήμα διατηρεί την τιμή `spell_check` του πρώτου τμήματος. Εάν τα τμήματα χρειάζονται διαφορετικές ρυθμίσεις ελέγχου, καλέστε `join_portions_with_same_formatting` πριν ορίσετε αυτές τις ρυθμίσεις, ή εξετάστε τα όρια του προκύπτον τμήματος και επαναεφαρμόστε τις ρυθμίσεις αργότερα. Τα τμήματα με διαφορετικές τιμές `language_id` παραμένουν χωριστά επειδή η μορφοποίηση της γλώσσας ελέγχου διαφέρει.

## **Συχνές Ερωτήσεις**

**Μεταφράζει ένας αναγνωριστικός κωδικός γλώσσας το κείμενο;**

Όχι. Το [BasePortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/language_id/) αποθηκεύει μεταδεδομένα ελέγχου για ορθογραφία και γραμματική· δεν τροποποιεί το περιεχόμενο του κειμένου. Μεταφράστε το κείμενο ξεχωριστά και, στη συνέχεια, ορίστε το κατάλληλο αναγνωριστικό γλώσσας για κάθε μεταφρασμένο τμήμα.

**Ορίζει η γλώσσα ελέγχου γραμματοσειρές, συλλαβισμό ή περιτύλιξη γραμμής;**

Όχι. Το αναγνωριστικό γλώσσας είναι για έλεγχο. Η απόδοση κειμένου και η διάταξη εξαρτώνται κυρίως από τις διαθέσιμες [fonts](/slides/el/python-net/powerpoint-fonts/), το σύστημα γραφής, και τις ρυθμίσεις του πλαισίου κειμένου. Για αξιόπιστη απόδοση, παρέχετε τις απαιτούμενες γραμματοσειρές, διαμορφώστε την [font substitution](/slides/el/python-net/font-substitution/), ή [embed fonts](/slides/el/python-net/embedded-font/) στην παρουσίαση.

**Μπορεί μία παράγραφος να χρησιμοποιήσει πολλές γλώσσες ελέγχου;**

Ναι. Αναθέστε κάθε γλώσσα σε ξεχωριστό τμήμα, όπως δείχνει το παράδειγμα πολύγλωσσης παραγράφου.

**Πρέπει να χρησιμοποιήσω `default_text_language` ή `language_id`;**

Χρησιμοποιήστε [LoadOptions.default_text_language](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/default_text_language/) όταν θέλετε μια προεπιλογή για νέο κείμενο. Χρησιμοποιήστε [BasePortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/language_id/) όταν ένα συγκεκριμένο τμήμα χρειάζεται ρητή γλώσσα ελέγχου ή όταν μια παράγραφος περιέχει πολλαπλές γλώσσες.