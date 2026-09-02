---
title: Αναζήτηση και Αντικατάσταση Κειμένου σε Παρουσιάσεις PowerPoint σε Python
linktitle: Αναζήτηση και Αντικατάσταση Κειμένου
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

Το Aspose.Slides for Python μέσω .NET μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη μια παρουσίαση. Αυτές οι δυνατότητες είναι χρήσιμες για έλεγχο, σκανδάλη, έλεγχο ορολογίας, καθαρισμό προτύπων και άλλες αυτοματοποιημένες ροές εργασίας επεξεργασίας εγγράφων.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλογή Πεδίου Αναζήτησης**

Χρησιμοποιήστε τις μεθόδους στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) για να περιορίσετε μια ενέργεια σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε τις μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να επεξεργαστείτε όλο το κείμενο που είναι εφαρμόσιμο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [TextFrame.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/highlight_text/) |
| Επισήμανση αντιστοιχίσεων κανονικής έκφρασης | [TextFrame.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/highlight_regex/) |
| Αντικατάσταση κυριολεκτικού κειμένου | [TextFrame.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_text/) |
| Αντικατάσταση αντιστοιχίσεων κανονικής έκφρασης | [TextFrame.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_regex/) |

## **Διαμόρφωση Ταύτισης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/) για να ελέγξετε την ταύτιση:

- το [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/whole_words_only/) περιορίζει τις αντιστοιχίσεις σε πλήρεις λέξεις.
- το [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/case_sensitive/) ελέγχει αν πρέπει να ταιριάζει το μέγεθος των χαρακτήρων.
- το [TextSearchOptions.include_notes](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/include_notes/) περιλαμβάνει τις σημειώσεις διαφάνειας σε αναζητήσεις, αντικαταστάσεις και λειτουργίες επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες με κανονικές εκφράσεις χρησιμοποιούν μια συμβολοσειρά προτύπου, έτσι οι κανόνες ταύτισης όπως η ευαισθησία σε πεζά/κεφαλαία και τα όρια λέξεων ορίζονται από την έκφραση.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [TextFrame.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_text/) για να επισημάνετε τις κυριολεκτικές αντιστοιχίσεις σε ένα πλαίσιο κειμένου. Με περάστε το [TextSearchOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση.

Το παράδειγμα κώδικα παρακάτω επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη πλήρη λέξη **"to"**.

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

    # Επισήμανση μόνο της πλήρους λέξης "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου με Χρήση Κανονικών Εκφράσεων**

Η μέθοδος [TextFrame.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_regex/) επισημαίνει τις αντιστοιχίσεις κειμένου που βρέθηκαν από κανονική έκφραση σε ένα πλαίσιο κειμένου.

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

![Το επισημασμένο κείμενο με χρήση κανονικής έκφρασης](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Ολόκληρη την Παρουσίαση**

Χρησιμοποιήστε τις [Presentation.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/highlight_text/) και [Presentation.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/highlight_regex/) για να αναζητήσετε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email:

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

Χρησιμοποιήστε το [TextFrame.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_text/) για κυριολεκτικό κείμενο και το [TextFrame.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_regex/) για αντικατάσταση με βάση πρότυπο. Αυτές οι μέθοδοι ενημερώνουν το ταίριασμα κειμένου μέσα στο υπάρχον πλαίσιο κειμένου, διατηρώντας τη μορφοποίηση του περιβάλλοντος τμήματος αντί να ξαναχτίζουν το πλαίσιο κειμένου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μία παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες εκδόσεων:

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

Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμόζεται στο αντικατεστημένο κείμενο.

## **Αντικατάσταση Κειμένου σε Ολόκληρη την Παρουσίαση**

Χρησιμοποιήστε τα [Presentation.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_text/) και [Presentation.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_regex/) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για τον καθαρισμό προτύπων, ενημερώσεις ορολογίας και σκανδάλες.

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε τις [TextFrame.highlight_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_text/) ή [TextFrame.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_regex/) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι σε επίπεδο παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου αντίγ.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε το [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/whole_words_only/) και το [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/case_sensitive/) σε `True` και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και την ευαισθησία σε πεζά/κεφαλαία στο ίδιο το πρότυπο.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο στις σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.include_notes](https://reference.aspose.com/slides/el/python-net/aspose.slides/textsearchoptions/include_notes/) σε `True` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Τα [TextFrame.replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_text/) και [TextFrame.replace_regex](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/replace_regex/) τροποποιούν το ταίριασμα κειμένου μέσα στο υπάρχον πλαίσιο κειμένου και διατηρούν τη μορφοποίηση του περιβάλλοντος τμήματος. Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να διασφαλίσετε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.