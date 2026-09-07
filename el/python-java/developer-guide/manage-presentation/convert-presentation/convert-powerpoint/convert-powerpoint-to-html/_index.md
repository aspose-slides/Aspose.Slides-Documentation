---
title: Μετατροπή παρουσιάσεων PowerPoint σε HTML σε Python μέσω Java
linktitle: PowerPoint σε HTML
type: docs
weight: 30
url: /el/python-java/convert-powerpoint-to-html/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε HTML
- παρουσίαση σε HTML
- διαφάνεια σε HTML
- PPT σε HTML
- PPTX σε HTML
- αποθήκευση PowerPoint ως HTML
- αποθήκευση παρουσίασης ως HTML
- αποθήκευση διαφάνειας ως HTML
- αποθήκευση PPT ως HTML
- αποθήκευση PPTX ως HTML
- εξαγωγή PPT σε HTML
- εξαγωγή PPTX σε HTML
- Python
- Java
- Aspose.Slides
description: "Μετατρέπει παρουσιάσεις PowerPoint σε HTML σε Python μέσω Java. Χρησιμοποιήστε το Aspose.Slides για να εξάγετε αρχεία PPT και PPTX, επιλεγμένες διαφάνειες, σημειώσεις, γραμματοσειρές, εικόνες, SVG και πολυμέσα."
---
## **Επισκόπηση**

Aspose.Slides for Python via Java μπορεί να αποθηκεύει παρουσιάσεις PowerPoint ως HTML χωρίς το Microsoft PowerPoint. Η βασική μετατροπή είναι ένα μοναδικό φόρτωμα [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και μια κλήση [save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με το [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/). Χρησιμοποιήστε το [HtmlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/) όταν χρειάζεται να ελέγξετε τη διάταξη εξαγόμενων, τις γραμματοσειρές, τις εικόνες, τις σημειώσεις, τα σχόλια, την έξοδο SVG ή τους συνδεδεμένους πόρους.

Αυτός ο οδηγός εστιάζει σε πρακτικά σενάρια εξαγωγής HTML:

- Εξαγωγή ολόκληρης παρουσίασης ή επιλεγμένων διαφανειών.
- Δημιουργία HTML σταθερής διάταξης, προσαρμοστικής ή βασισμένης σε SVG.
- Συμπερίληψη σημειώσεων ομιλητή και σχολίων.
- Έλεγχος ποιότητας εικόνας και δεδομένων περικομμένων εικόνων.
- Ενσωμάτωση γραμματοσειρών ή αποθήκευση αρχείων γραμματοσειρών ξεχωριστά.
- Επιλογή τρόπου γραφής και αναφοράς εξωτερικών πόρων και αρχείων πολυμέσων.

Από προεπιλογή, η εξαγωγή HTML δημιουργεί ένα αυτόνομα έγγραφο HTML όπου οι περισσότεροι πόροι είναι ενσωματωμένοι. Αυτό είναι βολικό για κοινή χρήση ενός αρχείου, αλλά μπορεί να αυξήσει το μέγεθος της εξόδου. Για δημοσίευση στο web, σκεφτείτε εξωτερικούς πόρους, χαμηλότερο DPI εικόνας και ενσωμάτωση μόνο των γραμματοσειρών που δεν είναι αξιόπιστα διαθέσιμες στο περιβάλλον προορισμού.

## **Μετατροπή παρουσίασης σε HTML**

Για να εξάγετε μια παρουσίαση σε HTML, φορτώστε την με [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και αποθηκεύστε την με [SaveFormat.Html](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Κάθε παράδειγμα φορτώνει `presentation.pptx` από τον τρέχοντα φάκελο εργασίας. Εγκαταστήστε το Aspose.Slides for Python via Java και ένα συμβατό περιβάλλον εκτέλεσης Java πριν το τρέξετε. Η JVM ξεκινά μία φορά ανά διεργασία Python.

Αυτό το παράδειγμα γράφει ένα αρχείο HTML. Το αντικείμενο παρουσίασης διαγράφεται στο μπλοκ `finally`, το οποίο απελευθερώνει τα χειριστικά αρχείων και τους πόρους απόδοσης μετά την εξαγωγή.

## **Διαμόρφωση εξαγωγής HTML**

[HtmlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/) είναι η κύρια κλάση ρυθμίσεων για την εξαγωγή HTML. Κοινές ρυθμίσεις περιλαμβάνουν:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): προσθέτει σημειώσεις, σχόλια, φυλλάδια ή άλλες πληροφορίες διάταξης.
- [setHtmlFormatter](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setHtmlFormatter): αλλάζει τη δομή του εγγράφου HTML ή αναθέτει τη μορφοποίηση σε έναν ελεγκτή.
- [setSlideImageFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setSlideImageFormat): αλλάζει τον τρόπο αναπαράστασης των διαφανειών, π.χ. ως SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setPicturesCompression): ελέγχει το DPI των εικόνων και το μέγεθος εξόδου.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): διατηρεί ή αφαιρεί δεδομένα περικομμένων εικόνων.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): κάνει το εξαγόμενο περιεχόμενο SVG να προσαρμόζεται στο περιέκτη του.
- [setShowHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): περιλαμβάνει κρυφές διαφάνειες όταν απαιτείται.

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες επιλογές ξεχωριστά, ώστε να μπορείτε να συνδυάσετε μόνο αυτές που χρειάζεται η ροή εργασίας σας.

## **Μετατροπή επιλεγμένων διαφανειών σε HTML**

Η υπερφόρτωση [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) που δέχεται αριθμούς διαφανειών χρησιμοποιεί θέσεις διαφανειών με βάση το 1. Ο βρόχος παρακάτω αποθηκεύει κάθε διαφάνεια σε ξεχωριστό αρχείο HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Χρησιμοποιήστε αυτό το πρότυπο όταν ένας ιστότοπος ή εφαρμογή χρειάζεται μία σελίδα HTML ανά διαφάνεια. Εάν κάθε διαφάνεια πρέπει να έχει την ίδια διάταξη, δημιουργήστε ένα αντικείμενο [HtmlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/) και περάστε το σε κάθε κλήση [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save).

## **Δημιουργία προσαρμοστικού HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/el/python-java/aspose.slides/responsivehtmlcontroller/) παρέχει προσαρμοστική έξοδο HTML μέσω του [HtmlFormatter](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmlformatter/). Χρησιμοποιήστε το όταν η εξαγόμενη σελίδα πρέπει να προσαρμόζεται καλύτερα στο πλάτος του προγράμματος περιήγησης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Για προσαρμοστική διάταξη βάσει SVG, καλέστε το [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) με `True`. Αυτό είναι χρήσιμο όταν το περιεχόμενο της διαφάνειας εξάγεται ως κλιμακούμενο SVG markup.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Συμπερίληψη σημειώσεων ομιλητή και σχολίων**

Χρησιμοποιήστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) μέσω του [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) για να συμπεριλάβετε σημειώσεις ομιλητή ή σχόλια. Οι σημειώσεις και τα σχόλια είναι κρυμμένα από προεπιλογή, εκτός εάν επιλέξετε τις θέσεις τους.

Υποθέστε ότι η πηγαία παρουσίαση περιέχει σημειώσεις ομιλητή:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Ο παρακάτω κώδικας εξάγει το περιεχόμενο της διαφάνειας με τις σημειώσεις ομιλητή κάτω από τη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Το εξαγόμενο HTML περιλαμβάνει την περιοχή σημειώσεων:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Για εξαγωγή σχολίων, καλέστε το [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), π.χ. με [CommentsPositions.Right](https://reference.aspose.com/slides/el/python-java/aspose.slides/commentspositions/#Right) ή [CommentsPositions.Bottom](https://reference.aspose.com/slides/el/python-java/aspose.slides/commentspositions/#Bottom). Εάν χρειάζεστε μόνο σχόλια, παραλείψτε το [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Εάν χρειάζεστε και τις δύο, καλέστε και τις δύο μεθόδους.

## **Έλεγχος ποιότητας εικόνας και περικομμένων περιοχών**

Η εξαγωγή HTML μπορεί να συμπιέσει τις εικόνες των διαφανειών για να μειώσει το μέγεθος της εξόδου. Περάστε μια τιμή στο [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setPicturesCompression) από το [PicturesCompression](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturescompression/) όταν χρειάζεστε υψηλότερη ποιότητα εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Από προεπιλογή, οι περικομμένες περιοχές των εικόνων μπορεί να αφαιρεθούν από την εξαγόμενη έξοδο. Διατηρήστε τα περικομμένα δεδομένα μόνο όταν οι χρήστες πρέπει να μπορούν να ανακτήσουν ή να εξετάσουν αυτά τα κρυφά τμήματα εικόνας. Η διατήρηση αυτών μπορεί να αυξήσει το μέγεθος του HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Προσθήκη CSS**

Για απλή διακόσμηση, περάστε μια συμβολοσειρά CSS στο [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Αυτό αλλάζει το περιβάλλον του εγγράφου HTML ενώ το Aspose.Slides συνεχίζει να αποδίδει το περιεχόμενο της διαφάνειας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Για προσαρμοσμένη κεφαλίδα εγγράφου, συνδεδεμένο αρχείο CSS ή προσαρμοσμένο markup γύρω από διαφάνειες και σχήματα, χρησιμοποιήστε έναν προσαρμοσμένο ελεγκτή μορφοποίησης μέσω διαμεσολαβητή JPype και περάστε το στο [HtmlFormatter](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmlformatter/) με το [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Ενσωμάτωση γραμματοσειρών**

Εάν το περιβάλλον προορισμού ενδέχεται να μην έχει εγκατεστημένες τις γραμματοσειρές της παρουσίασης, ενσωματώστε τις στο HTML με το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/python-java/aspose.slides/embedallfontshtmlcontroller/). Η ενσωμάτωση βελτιώνει την οπτική πιστότητα αλλά αυξάνει το μέγεθος της εξόδου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Αποκλείστε τις γραμματοσειρές μόνο όταν είστε πεπεισμένοι ότι οι προοριστικοί περιηγητές ή συστήματα τις παρέχουν ήδη. Για εταιρικές ή λιγότερο κοινές γραμματοσειρές, η ενσωμάτωση είναι συνήθως πιο ασφαλής.

## **Αποθήκευση πόρων εξωτερικά**

Το αυτόνομο HTML είναι εύκολο στην μεταφορά, αλλά οι ενσωματωμένοι πόροι Base64 μπορούν να κάνουν το αρχείο μεγάλο. Εάν η εφαρμογή σας χρειάζεται εξωτερικά αρχεία εικόνας, υλοποιήστε έναν ελεγκτή σύνδεσης πόρων μέσω διαμεσολαβητή JPype και περάστε τον στον κατασκευαστή του [HtmlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/).

Όταν εξωτερικοποιείτε πόρους, επιλέξτε δύο διαδρομές σκόπιμα:

- Η διαδρομή εξόδου του συστήματος αρχείων, όπου η εφαρμογή σας γράφει τις παραγόμενες εικόνες, γραμματοσειρές, ήχο ή βίντεο.
- Η διαδρομή URL, η οποία χρησιμοποιεί το πρόγραμμα περιήγησης από το έγγραφο HTML για να φορτώσει τα αρχεία.

## **Εξαγωγή αρχείων πολυμέσων**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoplayerhtmlcontroller/) εξάγει αρχεία βίντεο και ήχου και γράφει HTML που μπορεί να τα αναπαράγει σε πρόγραμμα περιήγησης. Ο κατασκευαστής του δέχεται:

- `path`: ο φάκελος όπου θα γραφτούν τα παραγόμενα αρχεία πολυμέσων.
- `fileName`: το όνομα του παραγόμενου αρχείου HTML.
- `baseUri`: το απόλυτο πρόθεμα URI που χρησιμοποιείται στους συνδέσμους HTML προς τα αρχεία πολυμέσων.

Το παρακάτω παράδειγμα εξάγει πολυμέσα που είναι ήδη ενσωματωμένα στο `presentation.pptx`. Το παραγόμενο HTML αναφέρεται στα αρχεία πολυμέσων μόνο με το όνομα του αρχείου, σχετικό με το έγγραφο HTML, έτσι το `path` πρέπει να είναι ο φάκελος που επίσης λαμβάνει το αρχείο HTML. Το `baseUri` πρέπει να είναι απόλυτο URI: για τοπική προεπισκόπηση, δημιουργήστε ένα URI `file:///` από τον φάκελο εξόδου· για εφαρμογή σε παραγωγή, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου καταλόγου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Χρησιμοποιήστε φακέλους εξόδου που είναι μοναδικοί ανά εργασία εξαγωγής, ιδιαίτερα σε διακομιστικές εφαρμογές. Κοινές διαδρομές εξόδου μπορούν να προκαλέσουν αντικατάσταση αρχείων από διαφορετικές μετατροπές.

## **Απόδοση και διαχείριση πόρων**

Η μετατροπή HTML είναι μια λειτουργία απόδοσης, έτσι ο χρόνος επεξεργασίας και η χρήση μνήμης εξαρτώνται από τον αριθμό διαφανειών, την ανάλυση εικόνων, τις γραμματοσειρές, τα εφέ, τα διαγράμματα και τα ενσωματωμένα πολυμέσα. Υψηλότερες τιμές DPI εικόνας που περνιούνται στο [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setPicturesCompression), οι ενσωματωμένες γραμματοσειρές, η έξοδος SVG και η διατήρηση περικομμένων περιοχών εικόνων μπορούν να βελτιώσουν την πιστότητα αλλά συνήθως αυξάνουν το μέγεθος της εξόδου.

Για μαζική μετατροπή:

- Απελευθερώστε άμεσα κάθε παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Χρησιμοποιήστε ξεχωριστούς φακέλους εξόδου για ξεχωριστές εργασίες.
- Αποφύγετε την ενσωμάτωση κοινών γραμματοσειρών εκτός εάν απαιτείται η ακρίβεια.
- Μειώστε το DPI των εικόνων όταν το HTML προορίζεται για προεπισκόπηση ή μικρογραφίες.
- Διατηρήστε την πηγαία παρουσίαση, το παραγόμενο HTML και τους εξωτερικούς πόρους μαζί μέχρι να τελειώσουν οι διαδρομές ανάπτυξης.

## **Συχνές ερωτήσεις**

**Διατηρούνται οι υπερσυνδέσεις στην έξοδο HTML;**

Ναι. Οι υπερσυνδέσεις της παρουσίασης εξάγονται σε HTML και παραμένουν κλικαρίσιμες όταν η διεύθυνση URL προορισμού είναι έγκυρη.

**Μπορώ να μετατρέψω παρουσιάσεις σε HTML παράλληλα;**

Ναι, αλλά μην μοιράζεστε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) μεταξύ νημάτων. Επεξεργαστείτε διαφορετικά αρχεία με ξεχωριστά αντικείμενα παρουσίασης, ξεχωριστά ρεύματα και ξεχωριστούς φακέλους εξόδου. Δείτε τις οδηγίες [multithreading guidance](/slides/el/python-java/multithreading/) για λεπτομέρειες.

**Είναι το αντικείμενο παρουσίασης ασφαλές για χρήση από πολλές νήματα;**

Όχι. Ένα ενιαίο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) πρέπει να φορτώνεται, να τροποποιείται, να αποθηκεύεται και να διαγράφεται σε ένα μόνο νήμα. Για παράλληλη εργασία, δημιουργήστε ανεξάρτητο αντικείμενο ανά νήμα ή διεργασία.

**Γιατί το παραγόμενο αρχείο HTML είναι μεγάλο;**

Η προεπιλεγμένη εξαγωγή μπορεί να ενσωματώνει πόρους άμεσα στο HTML. Οι ενσωματωμένες γραμματοσειρές, οι εικόνες υψηλού DPI, τα πολυμέσα, το περιεχόμενο SVG και οι διατηρημένες περικομμένες περιοχές εικόνων αυξάνουν επίσης το μέγεθος. Χρησιμοποιήστε εξωτερικούς πόρους, αποκλείστε τις κοινές γραμματοσειρές από την ενσωμάτωση και περάστε χαμηλότερη τιμή DPI στο [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setPicturesCompression) όταν το μικρότερο μέγεθος είναι πιο σημαντικό από τη μέγιστη πιστότητα.

**Γιατί οι τιμές του font-size στο HTML μπορεί να διαφέρουν από τις τιμές στο PowerPoint;**

Η εξαγόμενη σελίδα μπορεί να χρησιμοποιεί συστήματα συντεταγμένων SVG και μετασχηματισμούς κλίμακας. Μία ακατέργαστη τιμή CSS ή SVG για το font-size από μόνη της δεν περιγράφει το τελικό εμφανιζόμενο μέγεθος. Συγκρίνετε τη διαφάνεια όπως εμφανίζεται στο επιθυμητό επίπεδο ζουμ και ελέγξτε τη διαθεσιμότητα γραμματοσειράς εάν το κείμενο φαίνεται διαφορετικό.

**Πώς πρέπει να επιλέξω το baseUri για εξαγωγή πολυμέσων;**

Επιλέξτε το `baseUri` από την οπτική του προγράμματος περιήγησης και περάστε το ως απόλυτο URI. Για τοπική προεπισκόπηση, μπορείτε να το κατασκευάσετε από τον φάκελο εξόδου με `output_directory.as_uri() + "/"`. Για παραγωγή, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου καταλόγου. Το σύστημα αρχείων `path` και το `baseUri` του προγράμματος περιήγησης δεν χρειάζεται να είναι η ίδια συμβολοσειρά, αλλά πρέπει να περιγράφουν την ίδια θέση, η οποία πρέπει να είναι ο φάκελος που φιλοξενεί το παραγόμενο αρχείο HTML, επειδή οι σύνδεσμοι πολυμέσων γράφονται σχετικοί με αυτόν.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες;**

Ναι. Καλέστε το [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) με `True` όταν πρέπει να εξάγονται κρυφές διαφάνειες.