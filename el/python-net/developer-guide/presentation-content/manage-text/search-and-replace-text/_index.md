---
title: Αναζήτηση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint με Python
linktitle: Αναζήτηση και αντικατάσταση κειμένου
type: docs
weight: 55
url: /el/python-net/search-and-replace-text/
keywords:
- αναζήτηση κειμένου
- επισήμανση κειμένου
- αντικατάσταση κειμένου
- κανονική έκφραση
- πλαίσιο κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Αναζήτηση, επισήμανση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint με Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω .NET μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη παρουσίαση. Αυτές οι δυνατότητες είναι χρήσιμες για έλεγχο, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και άλλες αυτοματοποιημένες ροές εργασίας επεξεργασίας εγγράφων.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλογή Περιοχής Αναζήτησης**

Χρησιμοποιήστε τις μεθόδους στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε τις μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να επεξεργαστείτε όλο το εφαρμόσιμο κείμενο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [TextFrame.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/highlight_text/) |
| Επισήμανση αντιστοιχίσεων κανονικών εκφράσεων | [TextFrame.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/highlight_regex/) |
| Αντικατάσταση κυριολεκτικού κειμένου | [TextFrame.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_text/) |
| Αντικατάσταση αντιστοιχίσεων κανονικών εκφράσεων | [TextFrame.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_regex/) |

## **Διαμόρφωση Αντιστοίχισης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/) για να ελέγξετε την αντιστοίχιση:

- `whole_words_only` περιορίζει τις αντιστοιχίες σε πλήρεις λέξεις.
- `case_sensitive` ελέγχει εάν η περίπτωση των χαρακτήρων πρέπει να ταιριάζει.
- `include_notes` συμπεριλαμβάνει τις σημειώσεις διαφάνειας στην αναζήτηση, αντικατάσταση και επισήμανση σε επίπεδο παρουσίασης.

Οι λειτουργίες με κανονικές εκφράσεις χρησιμοποιούν μια συμβολοσειρά προτύπου, έτσι οι κανόνες αντιστοίχισης όπως η ευαισθησία πεζών‑κεφαλαίων και τα όρια λέξεων ορίζονται από την έκφραση.

## **Αναγνώριση Ιδιοκτήτη Πλαισίου Κειμένου**

Οι γενικές ροές επεξεργασίας κειμένου συχνά λαμβάνουν ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) κατά την αναζήτηση, αντικατάσταση, επικύρωση ή εξαγωγή κειμένου. Χρησιμοποιήστε τα [TextFrame.parent_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_shape/) και [TextFrame.parent_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_cell/) για να προσδιορίσετε ποιο αντικείμενο παρουσίασης κατέχει το πλαίσιο κειμένου.

Οι αναμενόμενες τιμές εξαρτώνται από τον ιδιοκτήτη:

| Ιδιοκτήτης πλαισίου κειμένου | `parent_shape` | `parent_cell` |
|---|---|---|
| Ένα AutoShape ή άλλο σχήμα που περιέχει κείμενο | Το ιδιοκτησιακό [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) | `None` |
| Ένα κελί πίνακα | `None` | Το ιδιοκτησιακό [Cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/cell/) |

Και οι δύο ιδιότητες είναι μόνο για ανάγνωση. Η ανάγνωσή τους δεν μετακινεί το πλαίσιο κειμένου ούτε αλλάζει τον ιδιοκτήτη του. Ο γενικός κώδικας πρέπει να ελέγχει και τις δύο τιμές για `None` και να διαχειρίζεται την πιθανότητα να μην είναι διαθέσιμος κανένας ιδιοκτήτης.

Το παρακάτω παράδειγμα χρησιμοποιεί το [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/get_all_text_frames/) για να επαναλάβει τα πλαίσια κειμένου σε μια παρουσίαση. Για σχήματα, αναφέρει το όνομα του σχήματος, τον τύπο χρόνου εκτέλεσης Python και τη διαφάνεια που το περιέχει. Για κελιά πίνακα, αναφέρει τις συντεταγμένες στήλης και σειράς με βάση το μηδέν και τη διαφάνεια που το περιέχει.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Για περιεχόμενο SmartArt, επαναλάβετε τα σχήματα στο [SmartArtNode.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartartnode/shapes/) και αποκτήστε πρόσβαση σε κάθε [ISmartArtShape.text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Το πλαίσιο κειμένου μπορεί να ανιχνευθεί στο σχετικό του σχήμα μέσω του [TextFrame.parent_shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_shape/), ενώ το [TextFrame.parent_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/parent_cell/) είναι `None`. Επομένως, ο κλάδος σχήματος στο παράδειγμα διαχειρίζεται επίσης κείμενο από κόμβους SmartArt.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [TextFrame.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_text/) για να επισημάνετε κυριολεκτικές αντιστοιχίες κειμένου σε ένα πλαίσιο κειμένου. Περάστε το [TextSearchOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη πλήρη λέξη **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Επισήμανση κάθε εμφάνισης του "try" στο πλαίσιο κειμένου.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Επισήμανση μόνο της ολόκληρης λέξης "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου Χρησιμοποιώντας Κανονικές Εκφράσεις**

Η μέθοδος [TextFrame.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_regex/) επισημαίνει τις αντιστοιχίες κειμένου που βρέθηκαν με μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισημαίνει όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο χρησιμοποιώντας την κανονική έκφραση](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Ολόκληρη Παρουσίαση**

Χρησιμοποιήστε τα [Presentation.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/highlight_text/) και [Presentation.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/highlight_regex/) για να αναζητήσετε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Αντικατάσταση Κειμένου σε Πλαίσιο Κειμένου**

Χρησιμοποιήστε το [TextFrame.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_text/) για κυριολεκτικό κείμενο και το [TextFrame.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_regex/) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το ταιριασμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου, διατηρώντας τη μορφοποίηση του περιβάλλοντος τμήματος αντί να δημιουργούν εκ νέου το πλαίσιο κειμένου από απλό κείμενο.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες έκδοσης:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Ολόκληρη Παρουσίαση**

Χρησιμοποιήστε τα [Presentation.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_text/) και [Presentation.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_regex/) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφή.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Πάρτε το πλαίσιο κειμένου του σχήματος και καλέστε [TextFrame.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_text/) ή [TextFrame.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_regex/) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι σε επίπεδο παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου αντίθετα.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε το [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/whole_words_only/) και το [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/case_sensitive/) σε `True` και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και την ευαισθησία πεζών‑κεφαλαίων μέσα στο ίδιο το πρότυπο.

**Μπορούν η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο στις σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.include_notes](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/include_notes/) σε `True` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης.

**Διατηρεί η αντικατάσταση κειμένου τη διαμόρφωσή του;**

Το [TextFrame.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_text/) και το [TextFrame.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_regex/) τροποποιούν το ταιριασμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου και διατηρούν τη μορφοποίηση του περιβάλλοντος τμήματος. Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, εξετάστε το αποτέλεσμα για να βεβαιωθείτε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.