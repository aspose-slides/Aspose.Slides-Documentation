---
title: Αναζήτηση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint σε Python μέσω Java
linktitle: Αναζήτηση και αντικατάσταση κειμένου
type: docs
weight: 55
url: /el/python-java/search-and-replace-text/
keywords:
- αναζήτηση κειμένου
- επισήμανση κειμένου
- αντικατάσταση κειμένου
- κανονική έκφραση
- callback αποτελέσματος
- πλαίσιο κειμένου
- αναφορά ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Αναζήτηση, επισήμανση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint ενώ συλλέγονται όλες οι αντιστοιχίες με το Aspose.Slides for Python via Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via Java μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιήσει μια εφαρμογή για κάθε αντιστοιχία μέσω μιας callback αποτελέσματος. Αυτό καθιστά δυνατό το να ενημερώνεται μια παρουσίαση και ταυτόχρονα να δημιουργείται ένα αρχείο ελέγχου που περιέχει το κείμενο που ταιριάζει, το περιεχόμενό του, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ανασκόπηση, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", που περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το παρακάτω κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλογή περιοχής αναζήτησης**

Χρησιμοποιήστε τις μεθόδους στο [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε τις μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) για να επεξεργαστείτε όλο το κείμενο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη η παρουσίαση |
|---|---|---|
| Highlight literal text | [TextFrame.highlightText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#highlightText) | [Presentation.highlightText](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#highlightText) |
| Highlight regular-expression matches | [TextFrame.highlightRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#highlightRegex) | [Presentation.highlightRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#highlightRegex) |
| Replace literal text | [TextFrame.replaceText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#replaceText) | [Presentation.replaceText](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#replaceText) |
| Replace regular-expression matches | [TextFrame.replaceRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#replaceRegex) | [Presentation.replaceRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#replaceRegex) |

## **Διαμόρφωση αντιστοίχισης κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/textsearchoptions/) για να ελέγξετε την αντιστοίχιση:

- [setWholeWordsOnly](https://reference.aspose.com/slides/el/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) περιορίζει τις αντιστοιχίες σε ολόκληρες λέξεις.
- [setCaseSensitive](https://reference.aspose.com/slides/el/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) ελέγχει αν η διάφορη των χαρακτήρων πρέπει να ταιριάζει.
- [setIncludeNotes](https://reference.aspose.com/slides/el/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) περιλαμβάνει σημειώσεις διαφάνειας στην αναζήτηση, αντικατάσταση και επισήμανση επιπέδου παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα Java `Pattern`, έτσι ότι οι κανόνες αντιστοίχισης όπως η διάφορη χαρακτήρων και τα όρια λέξεων ορίζονται από την έκφραση και τις σημαίες της.

## **Ταυτοποίηση ιδιοκτήτη πλαισίου κειμένου**

Γενικές ροές επεξεργασίας κειμένου συχνά λαμβάνουν ένα [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) ενώ αναζητούν, αντικαθιστούν, επικυρώνουν ή εξάγουν κείμενο. Χρησιμοποιήστε το [TextFrame.getParentShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentShape) και το [TextFrame.getParentCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentCell) για να καθορίσετε ποιο αντικείμενο παρουσίασης είναι ιδιοκτήτης του πλαισίου κειμένου.

Οι αναμενόμενες τιμές εξαρτώνται από τον ιδιοκτήτη:

| Ιδιοκτήτης πλαισίου κειμένου | `getParentShape` | `getParentCell` |
|---|---|---|
| Ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) ή άλλο σχήμα που περιέχει κείμενο | Το ιδιοκτησιακό [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) | `None` |
| Κελί πίνακα | `None` | Το ιδιοκτησιακό [Cell](https://reference.aspose.com/slides/el/python-java/aspose.slides/cell/) |

Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση. Η κλήση τους δεν μετακινεί το πλαίσιο κειμένου ή αλλάζει τον ιδιοκτήτη του. Ο γενικός κώδικας πρέπει να ελέγχει και τις δύο τιμές για `None` και να χειρίζεται την περίπτωση που κανένας ιδιοκτήτης δεν είναι διαθέσιμος.

Το παρακάτω παράδειγμα χρησιμοποιεί το [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/#getAllTextFrames) για να επαναλάβει τα πλαίσια κειμένου σε μια παρουσίαση. Για σχήματα, αναφέρει το όνομα του σχήματος, τον τύπο χρόνου εκτέλεσης Java, και τη διαφάνεια που το περιέχει. Για κελιά πίνακα, αναφέρει τις συντεταγμένες στήλης και γραμμής με μηδενική βάση και τη διαφάνεια που το περιέχει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

presentation = Presentation("presentation.pptx")
try:
    text_frames = SlideUtil.getAllTextFrames(presentation, False)
    for text_frame in text_frames:
        owner_shape = text_frame.getParentShape()
        owner_cell = text_frame.getParentCell()
        if owner_shape is not None:
            shape_name = str(owner_shape.getName()) or "(unnamed)"
            shape_type = owner_shape.getClass().getSimpleName()
            base_slide = owner_shape.getSlide()
        elif owner_cell is not None:
            base_slide = owner_cell.getSlide()
        else:
            print("The text frame owner is not available as a shape or table cell.")
            continue

        if isinstance(base_slide, Slide):
            slide_label = f"slide {base_slide.getSlideNumber()}"
        elif isinstance(base_slide, NotesSlide):
            slide_label = f"notes for slide {base_slide.getParentSlide().getSlideNumber()}"
        else:
            slide_label = str(base_slide.getClass().getSimpleName())

        if owner_shape is not None:
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
        else:
            print(f"Table cell: column {owner_cell.getFirstColumnIndex()}, row {owner_cell.getFirstRowIndex()}; {slide_label}")
finally:
    presentation.dispose()
```

Για περιεχόμενο SmartArt, επαναλάβετε τα σχήματα στο [SmartArtNode.getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#getShapes) και προσπελάστε κάθε [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartshape/#getTextFrame). Το πλαίσιο κειμένου μπορεί να εντοπισθεί στο σχετικό σχήμα μέσω του [TextFrame.getParentShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentShape), ενώ το [TextFrame.getParentCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentCell) επιστρέφει `None`. Επομένως, ο κλάδος σχήματος στο παράδειγμα χειρίζεται επίσης κείμενο από κόμβους SmartArt.

## **Συλλογή πληροφοριών αντιστοιχίσεων με callback**

Εφαρμόστε το `IFindResultCallback` μέσω του `jpype.JProxy` για να λαμβάνετε ειδοποίηση για κάθε αντιστοιχία. Η μέθοδος `foundResult` του παρέχει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το κείμενο που ταιριάζει, και τη θέση της αντιστοιχίας.

Το callback δεν λαμβάνει απευθείας τον αριθμό της διαφάνειας. Η υλοποίηση παρακάτω τον εξάγει από τη γονική διαφάνεια και επίσης χειρίζεται κείμενο που εντοπίζεται σε σημειώσεις διαφάνειας. Ένας προαιρετικός αριθμός διαφάνειας επιτρέπει στο ίδιο μοντέλο αποτελέσματος να αντιπροσωπεύει κείμενο που σχετίζεται με άλλους τύπους διαφάνειας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)
```

Για λειτουργίες αντικατάστασης, το `found_text` περιέχει το αρχικό κείμενο που ταιριάζει, έτσι το callback μπορεί να καταγράψει ακριβώς ποιες εκφράσεις αντικαταστάθηκαν.

## **Επισήμανση κειμένου**

Χρησιμοποιήστε τη μέθοδο [TextFrame.highlightText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#highlightText) για να επισήμανετε τις κυριολεκτικές αντιστοιχίες κειμένου σε ένα πλαίσιο κειμένου. Μεταβιβάστε το [TextSearchOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση και ένα callback για τη συλλογή λεπτομερειών αντιστοιχίας.

Το παρακάτω παράδειγμα κώδικα επισήμανει όλες τις εμφανίσεις των χαρακτήρων **"try"** και έπειτα επισήμανει μόνο την πλήρη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίες τους στο ίδιο callback.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)

    substring_search_options = TextSearchOptions()
    substring_search_options.setCaseSensitive(False)
    substring_highlight_color = Color(173, 216, 230)

    # Επισήμανση κάθε εμφάνισης του "try" στο πλαίσιο κειμένου.
    shape.getTextFrame().highlightText("try", substring_highlight_color, substring_search_options, callback)

    whole_word_search_options = TextSearchOptions()
    whole_word_search_options.setWholeWordsOnly(True)
    whole_word_search_options.setCaseSensitive(False)
    whole_word_highlight_color = Color(238, 130, 238)

    # Επισήμανση μόνο της πλήρους λέξης "to".
    shape.getTextFrame().highlightText("to", whole_word_highlight_color, whole_word_search_options, callback)

    for result in callback_handler.results:
        print(f"Found '{result.found_text}' at position {result.text_position} on slide {result.slide_number}.")

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση κειμένου με κανονικές εκφράσεις**

Η μέθοδος [TextFrame.highlightRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#highlightRegex) επισήμανει τις αντιστοιχίες κειμένου που βρέθηκαν από μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισήμανει όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες και συλλέγει κάθε αντιστοιχία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    regex = Pattern.compile("\\b[^\\s]{7,}\\b")

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback)

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο με τη χρήση κανονικής έκφρασης](highlighted_text_using_regex.png)

## **Επισήμανση κειμένου σε ολόκληρη την παρουσίαση**

Χρησιμοποιήστε τα [Presentation.highlightText](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#highlightText) και [Presentation.highlightRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#highlightRegex) για να αναζητήσετε όλα τα σχετικά πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισήμανει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email, διατηρώντας ξεχωριστές συλλογές αποτελεσμάτων για τις δύο αναζητήσεις.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    term_callback_handler = TextSearchCallback()
    term_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=term_callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    presentation.highlightText("confidential", Color.ORANGE, search_options, term_callback)

    email_callback_handler = TextSearchCallback()
    email_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=email_callback_handler)
    email_regex = Pattern.compile("\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", Pattern.CASE_INSENSITIVE)

    presentation.highlightRegex(email_regex, Color.YELLOW, email_callback)
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αντικατάσταση κειμένου σε πλαίσιο κειμένου**

Χρησιμοποιήστε το [TextFrame.replaceText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#replaceText) για κυριολεκτικό κείμενο και το [TextFrame.replaceRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#replaceRegex) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το ταιριασμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου, το οποίο διατηρεί τη μορφοποίηση του γύρω τμήματος αντί να αναδημιουργήσει το πλαίσιο κειμένου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες έκδοσης. Το ίδιο callback καταγράφει τους αρχικούς όρους που ταιριάζουν και στις δύο λειτουργίες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    shape.getTextFrame().replaceText("colour", "color", search_options, callback)

    version_regex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE)
    shape.getTextFrame().replaceRegex(version_regex, "current version", callback)

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση κειμένου σε ολόκληρη την παρουσίαση**

Χρησιμοποιήστε τα [Presentation.replaceText](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#replaceText) και [Presentation.replaceRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#replaceRegex) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ομαδοποίηση αντιστοιχίσεων για αναφορές**

Επειδή κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιούν τις αντιστοιχίες για ελέγχους, αναφορές ή ροές εργασίας επανεξέτασης. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα ανά διαφάνεια και μετά ανά πλαίσιο κειμένου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
    matches_by_slide = {}
    for result in callback_handler.results:
        matches_by_text_frame = matches_by_slide.setdefault(result.slide_number, {})
        text_frame_matches = matches_by_text_frame.setdefault(result.text_frame, [])
        text_frame_matches.append(result)

    for slide_number, matches_by_text_frame in matches_by_slide.items():
        slide_label = "Other" if slide_number is None else str(slide_number)
        print(f"Slide: {slide_label}")
        for text_frame, results in matches_by_text_frame.items():
            print(f"  Text frame: {text_frame.getText()}")
            for result in results:
                print(f"    '{result.found_text}' at position {result.text_position}; context: '{result.source_text}'")
finally:
    presentation.dispose()
```

## **FAQ**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε το [TextFrame.highlightText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#highlightText), [TextFrame.highlightRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#highlightRegex), [TextFrame.replaceText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#replaceText) ή [TextFrame.replaceRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#replaceRegex) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι επιπέδου παρουσίασης επεξεργάζονται όλα τα σχετικά πλαίσια κειμένου αντίστοιχα.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλοποίηση;**

Ορίστε το [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) και το [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) σε `True`, και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και τη διάφορη χαρακτήρων στην ίδια τη Java `Pattern`.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο σε σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) σε `True` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου επιπέδου παρουσίασης. Η υλοποίηση του callback που φαίνεται παραπάνω αντιστοιχίζει μια αντιστοίχηση σε μια σημείωση διαφάνειας στον γονικό αριθμό της διαφάνειας.

**Πώς μπορώ να δημιουργήσω αναφορά χωρίς να σαρώσω ξανά την παρουσίαση;**

Περάστε μια υλοποίηση του `IFindResultCallback` στην λειτουργία επισήμανσης ή αντικατάστασης. Το callback λαμβάνει κάθε αντιστοίχηση ενώ η λειτουργία εκτελείται, ώστε η εφαρμογή να αποθηκεύει το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον παράγωγο αριθμό διαφάνειας για μεταγενέστερη ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίηση του;**

Το [TextFrame.replaceText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#replaceText) και το [TextFrame.replaceRegex](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#replaceRegex) τροποποιούν το ταιριασμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου και διατηρούν τη μορφοποίηση του γύρω τμήματος. Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να βεβαιωθείτε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.