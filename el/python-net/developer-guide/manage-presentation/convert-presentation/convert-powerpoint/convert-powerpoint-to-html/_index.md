---
title: Μετατροπή παρουσιάσεων PowerPoint σε HTML με Python
linktitle: PowerPoint σε HTML
type: docs
weight: 30
url: /el/python-net/convert-powerpoint-to-html/
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
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε HTML με Python. Χρησιμοποιήστε το Aspose.Slides για εξαγωγή αρχείων PPT και PPTX, επιλεγμένων διαφανειών, σημειώσεων, γραμματοσειρών, εικόνων, SVG και πολυμέσων."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω .NET μπορεί να αποθηκεύσει παρουσιάσεις PowerPoint ως HTML χωρίς το Microsoft PowerPoint. Η βασική μετατροπή αποτελείται από ένα μόνο άδειο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και κλήση `save` με [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/). Χρησιμοποιήστε [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/) όταν χρειάζεται να ελέγξετε τη διάταξη, τις γραμματοσειρές, τις εικόνες, τις σημειώσεις, τα σχόλια, την έξοδο SVG ή τους συνδεδεμένους πόρους.

Αυτός ο οδηγός εστιάζει σε πρακτικά σενάρια εξαγωγής HTML:

- Εξαγωγή ολόκληρης παρουσίασης ή επιλεγμένων διαφανειών.  
- Δημιουργία HTML σταθερής διάταξης, προσαρμόσιμης ή βασιζόμενης σε SVG.  
- Συμπερίληψη σημειώσεων ομιλητή και σχολίων.  
- Έλεγχος ποιότητας εικόνας και δεδομένων περικομμένων εικόνων.  
- Ενσωμάτωση γραμματοσειρών ή αποθήκευση αρχείων γραμματοσειρών ξεχωριστά.  
- Επιλογή τρόπου εγγραφής και αναφοράς εξωτερικών πόρων και αρχείων πολυμέσων.

Από προεπιλογή, η εξαγωγή HTML παράγει ένα αυτόνομο έγγραφο HTML όπου οι περισσότεροι πόροι είναι ενσωματωμένοι. Αυτό είναι βολικό για κοινή χρήση ενός αρχείου, αλλά μπορεί να αυξήσει το μέγεθος του αποτελέσματος. Για δημοσίευση στο διαδίκτυο, εξετάστε τη χρήση εξωτερικών πόρων, χαμηλότερο DPI εικόνας και ενσωμάτωση μόνο των γραμματοσειρών που δεν είναι αξιόπιστα διαθέσιμες στο περιβάλλον προορισμού.

## **Μετατροπή παρουσίασης σε HTML**

Για να εξάγετε μια παρουσίαση σε HTML, φορτώστε τη με [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και αποθηκεύστε τη με [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Αυτό το παράδειγμα γράφει ένα αρχείο HTML. Η δήλωση `with` απελευθερώνει το αντικείμενο παρουσίασης και κλείνει τα χειριστήρια αρχείων και τους πόρους απόδοσης μετά από την εξαγωγή.

## **Χρήση HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/) είναι η κύρια κλάση διαμόρφωσης για την εξαγωγή HTML. Συνήθεις ρυθμίσεις περιλαμβάνουν:

- `slides_layout_options`: προσθέτει σημειώσεις, σχόλια, φυλλάδια ή άλλες πληροφορίες διάταξης.  
- `html_formatter`: αλλάζει τη δομή του εγγράφου HTML ή μεταβιβάζει τη μορφοποίηση σε ένα ελεγκτή.  
- `slide_image_format`: αλλάζει τον τρόπο που αντιπροσωπεύονται οι διαφάνειες, π.χ. ως SVG.  
- `pictures_compression`: ελέγχει το DPI της εικόνας και το μέγεθος του αποτελέσματος.  
- `delete_pictures_cropped_areas`: διατηρεί ή αφαιρεί τα δεδομένα περικομμένων εικόνων.  
- `svg_responsive_layout`: κάνει το εξαγόμενο περιεχόμενο SVG να προσαρμόζεται στο περιέκτη του.  
- `show_hidden_slides`: περιλαμβάνει κρυφές διαφάνειες όταν απαιτείται.

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες επιλογές χωριστά, ώστε να μπορείτε να συνδυάσετε μόνο αυτές που απαιτούνται στη ροή εργασίας σας.

## **Μετατροπή επιλεγμένων διαφανειών σε HTML**

Η υπερφορτωμένη μέθοδος `save` που δέχεται αριθμούς διαφανειών χρησιμοποιεί θέσεις διαφανειών που ξεκινούν από 1. Ο βρόχος παρακάτω αποθηκεύει κάθε διαφάνεια σε ξεχωριστό αρχείο HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Χρησιμοποιήστε αυτό το πρότυπο όταν ένας ιστότοπος ή εφαρμογή χρειάζεται μια σελίδα HTML ανά διαφάνεια. Εάν όλες οι διαφάνειες πρέπει να έχουν την ίδια διάταξη, δημιουργήστε μία παρουσία του [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/) και περάστε την σε κάθε κλήση `save`.

## **Δημιουργία προσαρμοστικού (Responsive) HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/responsivehtmlcontroller/) παρέχει έξοδο HTML που προσαρμόζεται μέσω του [HtmlFormatter](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmlformatter/). Χρησιμοποιήστε το όταν η εξαγόμενη σελίδα πρέπει να προσαρμόζεται καλύτερα στο πλάτος του προγράμματος περιήγησης.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Για προσαρμοστική διάταξη βασισμένη σε SVG, ορίστε `svg_responsive_layout` στο [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/). Αυτό είναι χρήσιμο όταν το περιεχόμενο της διαφάνειας εξάγεται ως κλιμακώσιμη markup SVG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Συμπερίληψη σημειώσεων ομιλητή και σχολίων**

Χρησιμοποιήστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notescommentslayoutingoptions/) μέσω του `html_options.slides_layout_options` για να συμπεριλάβετε σημειώσεις ομιλητή ή σχόλια. Οι σημειώσεις και τα σχόλια είναι κρυμμένα από προεπιλογή, εκτός εάν ορίσετε τις θέσεις τους.

Υποθέτουμε ότι η πηγαία παρουσίαση περιέχει σημειώσεις ομιλητή:

![Διαφάνεια με σημειώσεις ομιλητή στο PowerPoint](slide_with_notes.png)

Ο παρακάτω κώδικας εξάγει το περιεχόμενο της διαφάνειας με τις σημειώσεις ομιλητή κάτω από τη διαφάνεια.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Το εξαγόμενο HTML περιλαμβάνει την περιοχή σημειώσεων:

![Έξοδος HTML με τη διαφάνεια και τις σημειώσεις ομιλητή](HTML_with_notes.png)

Για εξαγωγή σχολίων, ορίστε `comments_position`, π.χ. σε `CommentsPositions.RIGHT` ή `CommentsPositions.BOTTOM`. Εάν χρειάζεστε μόνο σχόλια, παραλείψτε το `notes_position`. Εάν χρειάζεστε και σημειώσεις και σχόλια, ορίστε και τις δύο ιδιότητες.

## **Έλεγχος ποιότητας εικόνας και περικομμένων περιοχών**

Η εξαγωγή HTML μπορεί να συμπιέσει τις εικόνες των διαφανειών για μείωση του μεγέθους του αποτελέσματος. Ορίστε `pictures_compression` σε τιμή από το [PicturesCompression](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/picturescompression/) όταν απαιτείται υψηλότερη ποιότητα εικόνας.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Από προεπιλογή, οι περικομμένες περιοχές εικόνων μπορεί να αφαιρεθούν από το εξαγόμενο αποτέλεσμα. Διατηρήστε τα περικομμένα δεδομένα μόνο όταν οι χρήστες πρέπει να μπορούν να τα επαναφέρουν ή να τα εξετάσουν. Η διατήρησή τους μπορεί να αυξήσει το μέγεθος του HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Προσθήκη CSS**

Για απλή μορφοποίηση, περάστε μια συμβολοσειρά CSS στο [HtmlFormatter](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmlformatter/). Αυτό αλλάζει το περιβάλλον HTML ενώ το Aspose.Slides συνεχίζει να αποδίδει το περιεχόμενο των διαφανειών.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Για προσαρμοσμένη κεφαλίδα εγγράφου, συνδεδεμένο αρχείο CSS ή προσαρμοσμένο markup γύρω από τις διαφάνειες και τα σχήματα, χρησιμοποιήστε έναν προσαρμοσμένο ελεγκτή διαμορφώσεων και περάστε τον στο [HtmlFormatter](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmlformatter/) με `create_custom_formatter`.

## **Ενσωμάτωση γραμματοσειρών**

Εάν το περιβάλλον προορισμού ενδέχεται να μην έχει τις γραμματοσειρές της παρουσίασης εγκατεστημένες, ενσωματώστε τις γραμματοσειρές στο HTML με το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Η ενσωμάτωση βελτιώνει την οπτική πιστότητα αλλά αυξάνει το μέγεθος του αποτελέσματος.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Απο exclusion μιας γραμματοσειράς μόνο όταν είστε βέβαιοι ότι οι στοχευόμενοι φυλλομετρητές ή συστήματα την παρέχουν ήδη. Για εταιρικές ή λιγότερο κοινές γραμματοσειρές, η ενσωμάτωση είναι συνήθως πιο ασφαλής.

## **Σύνδεση αρχείων γραμματοσειρών αντί της ενσωμάτωσής τους**

Για μείωση του μεγέθους του αρχείου HTML, μπορείτε να γράψετε τα δεδομένα γραμματοσειρών σε ξεχωριστά αρχεία WOFF και να προσθέσετε κανόνες `@font-face` στο HTML. Αυτό απαιτεί έναν ελεγκτή που προσαρμόζει τον τρόπο εγγραφής των δεδομένων γραμματοσειρών κατά την εξαγωγή. Στην Python μέσω .NET, υλοποιήστε αυτόν τον ελεγκτή σε μια μικρή βιβλιοθήκη .NET, φορτώστε την στην Python και περάστε το αντικείμενο βοηθού στο [HtmlFormatter](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmlformatter/) με `create_custom_formatter`.

Κατά την εξωτερικοποίηση των γραμματοσειρών, επιλέξτε σκόπιμα δύο διαδρομές:

- Ο φάκελος εξόδου του συστήματος αρχείων όπου θα γραφούν τα παραγόμενα αρχεία WOFF.  
- Η διαδρομή URL που θα εμφανίζεται στο έγγραφο HTML και η οποία θα χρησιμοποιηθεί από το πρόγραμμα περιήγησης για τη φόρτωση αυτών των αρχείων γραμματοσειρών.

Διατηρήστε το αρχείο HTML και τα παραγόμενα αρχεία γραμματοσειρών μαζί μέχρι να καθοριστούν οι τελικές διαδρομές ανάπτυξης. Εάν τα αρχεία αναπτυχθούν σε διαφορετική θέση, κάντε το πρόθεμα URL να ταιριάζει με τη διαδρομή URL που έχει αναπτυχθεί.

## **Αποθήκευση πόρων εξωτερικά**

Το αυτοσυμπεριλαμβανόμενο HTML είναι εύκολο στη μεταφορά, αλλά οι ενσωματωμένοι πόροι Base64 μπορούν να κάνουν το αρχείο μεγάλο. Εάν η εφαρμογή σας χρειάζεται εξωτερικές εικόνες, γραμματοσειρές, ήχο ή βίντεο, χρησιμοποιήστε έναν προσαρμοσμένο ελεγκτή σύνδεσης/ενσωμάτωσης και περάστε το στον κατασκευαστή του [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/).

Κατά την εξωτερικοποίηση πόρων, επιλέξτε σκόπιμα δύο διαδρομές:

- Η διαδρομή εξόδου του συστήματος αρχείων, όπου η εφαρμογή σας γράφει τις παραγόμενες εικόνες, γραμματοσειρές, ήχους ή βίντεο.  
- Η διαδρομή URL, η οποία χρησιμοποιείται από το πρόγραμμα περιήγησης μέσα στο έγγραφο HTML για τη φόρτωση αυτών των αρχείων.

Για πλήρη συζήτηση σχετικά με τη σύνδεση εικόνων, δείτε [Export Presentations to HTML with Externally Linked Images](/slides/el/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Εξαγωγή αρχείων πολυμέσων**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/videoplayerhtmlcontroller/) εξάγει αρχεία βίντεο και ήχου και δημιουργεί HTML που μπορεί να τα αναπαράγει σε έναν φυλλομετρητή. Ο κατασκευαστής του δέχεται:

- `path`: ο φάκελος όπου θα γραφούν τα παραγόμενα αρχεία πολυμέσων.  
- `file_name`: το όνομα του αρχείου HTML που δημιουργείται.  
- `base_uri`: το απόλυτο πρόθεμα URI που χρησιμοποιείται στους συνδέσμους HTML προς τα αρχεία πολυμέσων.

Εάν το αρχείο HTML είναι `html-output/presentation.html` και τα αρχεία πολυμέσων αποθηκεύονται στο `html-output/media`, το `path` πρέπει να δείχνει στον φάκελο πολυμέσων στο δίσκο, ενώ το `base_uri` πρέπει να δείχνει στον ίδιο φάκελο από την άποψη του προγράμματος περιήγησης. Για τοπική προεπισκόπηση, μπορείτε να δημιουργήσετε ένα URI `file:///` από τον φάκελο πολυμέσων. Για μια αναπτυγμένη εφαρμογή, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Χρησιμοποιήστε φακέλους εξόδου μοναδικούς ανά εργασία εξαγωγής, ειδικά σε διακομιστικές εφαρμογές. Κοινά μονοπάτια εξόδου μπορούν να προκαλέσουν αντικατάσταση αρχείων από διαφορετικές μετατροπές.

## **Απόδοση και διαχείριση πόρων**

Η μετατροπή HTML είναι μια λειτουργία απόδοσης, επομένως ο χρόνος επεξεργασίας και η χρήση μνήμης εξαρτώνται από τον αριθμό διαφανειών, την ανάλυση εικόνων, τις γραμματοσειρές, τα εφέ, τα γραφήματα και τα ενσωματωμένα πολυμέσα. Μεγαλύτερες τιμές DPI του `pictures_compression`, ενσωματωμένες γραμματοσειρές, έξοδο SVG και διατήρηση περικομμένων περιοχών εικόνων μπορούν να βελτιώσουν την πιστότητα αλλά συνήθως αυξάνουν το μέγεθος του αποτελέσματος.

Για μαζική μετατροπή:

- Αποδεσμεύετε άμεσα κάθε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).  
- Χρησιμοποιείτε ξεχωριστούς φακέλους εξόδου για διαφορετικές εργασίες.  
- Αποφεύγετε την ενσωμάτωση κοινών γραμματοσειρών εκτός εάν απαιτείται η πιστότητα.  
- Χαμηλώνετε το DPI της εικόνας όταν το HTML προορίζεται για προεπισκόπηση ή μικρογραφίες.  
- Διατηρείτε την πηγαία παρουσίαση, το παραγόμενο HTML και τους εξωτερικούς πόρους μαζί μέχρι να οριστούν οι τελικές διαδρομές ανάπτυξης.

## **Συχνές ερωτήσεις (FAQ)**

**Διατηρούνται οι υπερσυνδέσεις στο αποτέλεσμα HTML;**

Ναι. Οι υπερσυνδέσεις της παρουσίασης εξάγονται σε HTML και παραμένουν κλικ-μεταβιβάσιμες εφόσον η διεύθυνση URL προορισμού είναι έγκυρη.

**Μπορώ να μετατρέψω παρουσιάσεις σε HTML παράλληλα;**

Ναι, αλλά μην μοιράζεστε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) μεταξύ νημάτων. Επεξεργαστείτε διαφορετικά αρχεία με ξεχωριστά αντικείμενα παρουσίασης, ξεχωριστά ρεύματα και ξεχωριστούς φακέλους εξόδου. Δείτε την [οδηγία πολυνηματισμού](/slides/el/python-net/multithreading/) για λεπτομέρειες.

**Είναι το αντικείμενο Presentation ασφαλές για χρήση από πολλαπλά νήματα;**

Όχι. Ένα μόνο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) πρέπει να φορτώνεται, να τροποποιείται, να αποθηκεύεται και να αποδεσμεύεται σε ένα νήμα. Για παράλληλη εργασία, δημιουργήστε ανεξάρτητο αντίγραφο ανά νήμα ή διαδικασία.

**Γιατί το παραγόμενο αρχείο HTML είναι μεγάλο;**

Η προεπιλεγμένη εξαγωγή μπορεί να ενσωματώνει πόρους απευθείας στο HTML. Ενσωματωμένες γραμματοσειρές, εικόνες υψηλής ανάλυσης, πολυμέσα, περιεχόμενο SVG και διατηρημένα περικομμένα τμήματα εικόνας επίσης αυξάνουν το μέγεθος. Χρησιμοποιήστε εξωτερικούς πόρους, εξαιρέστε κοινές γραμματοσειρές από ενσωμάτωση και μειώστε το `pictures_compression` όταν το μικρότερο αρχείο είναι πιο σημαντικό από την μέγιστη πιστότητα.

**Γιατί ένα μέγεθος γραμματοσειράς PowerPoint όπως 24 pt εμφανίζεται ως 17.999819 pt σε HTML;**

Αυτό συμβαίνει επειδή το PowerPoint και το HTML χρησιμοποιούν διαφορετικά μοντέλα DPI. Το PowerPoint αποθηκεύει τα μεγέθη κειμένου σε τυπογραφικά σημεία βάσει 72 DPI, ενώ η διάταξη HTML βασίζεται σε εικονοστοιχεία CSS με μοντέλο 96 DPI. Κατά την εξαγωγή με το Aspose.Slides, το μέγεθος γραμματοσειράς μεταφράζεται μεταξύ των συστημάτων, και η μετατροπή μπορεί να εισάγει μικρές αποκλίσεις στρογγυλοποίησης.

Αυτές οι τιμές δεν υποδεικνύουν πραγματική οπτική αλλαγή του μεγέθους γραμματοσειράς· είναι μόνο ένα μαθηματικό παράπλευρο αποτέλεσμα της μετατροπής των μετρικών κειμένου μεταξύ PowerPoint και HTML.

**Πώς πρέπει να επιλέξω το base_uri για την εξαγωγή πολυμέσων;**

Επιλέξτε το `base_uri` από την άποψη του προγράμματος περιήγησης και περάστε το ως απόλυτο URI. Για τοπική προεπισκόπηση, μπορείτε να το προκύψετε από τον φάκελο εξόδου με `Path(media_directory).as_uri() + "/"`. Για ανάπτυξη, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων. Η διαδρομή του συστήματος αρχείων `path` και το `base_uri` του προγράμματος περιήγησης δεν χρειάζεται να είναι το ίδιο ακριβώς κείμενο, αλλά πρέπει να περιγράφουν την ίδια θέση πόρου.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες;**

Ναι. Ορίστε `show_hidden_slides = True` στο [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/) όταν πρέπει να εξαχθούν κρυφές διαφάνειες.