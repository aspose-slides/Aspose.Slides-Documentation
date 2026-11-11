---
title: Render Presentation Slides as SVG Images in Python
linktitle: Slide to SVG
type: docs
weight: 50
url: /el/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint to SVG
- presentation to SVG
- slide to SVG
- PPT to SVG
- PPTX to SVG
- SVG export options
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Export PowerPoint slides as SVG images in Python and control fonts, text, and images with Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια κλιμακώσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, διαδικασίες προσβασιμότητας και αυτοματοποιημένη μεταεπεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο μεταξύ browsers, ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή. Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Το όνομα αρχείου χρησιμοποιεί το [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) αντί του δείκτη βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζονται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) σε `True` όταν το κείμενο πρέπει να αποδοθεί χωρίς σύνδεσμο γραμμάτων.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Έλεγχος περικοπής άκρων γραμμής στα βελάκια**

Το SVG 1.1 δεν διαθέτει ρύθμιση εσοχής δείκτη για να καθορίσει πού πρέπει να σταματήσει μια γραμμή κάτω από ένα βελάκι. Από προεπιλογή, το Aspose.Slides συντομεύει τη εξαγόμενη γραμμή ώστε η γραμμή της πέννας να μην προεξέρχεται μέσω του δείκτη. Ορίστε το [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) σε `True` για να σχεδιάζετε τη γραμμή μέχρι το αρχικό άκρο της. Αυτή η ρύθμιση επηρεάζει μόνο την έξοδο SVG. Η γραμμή διατηρεί τη θέση και το μήκος της στη διαφάνεια.

Το παράδειγμα σχεδιάζει τριγωνικά και διαμαντοειδή άκρα βελών σε γραμμές 2 και 10 σημείων πλάτος. Εξάγει την ίδια διαφάνεια δύο φορές, αλλάζοντας μόνο την επιλογή περικοπής.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

Η σύγκριση δείχνει το τριγωνικό άκρο βελάκι στη γραμμή 10 σημείων. Με ενεργοποιημένη την περικοπή, η άκρη είναι αιχμηρή. Με απενεργοποιημένη την περικοπή, η γραμμή προεξέρχεται από τις κλίσιμες πλευρές του δείκτη και αφήνει αμπάλη άκρη.

![Μεγεθυμένο τρίγωνο 10 σημείων με αιχμηρή άκρη όταν η περικοπή είναι ενεργή και αμπάλη άκρη όταν η περικοπή είναι ανενεργή](line-end-cropping.png)

Στις άλλες γραμμές του παραδείγματος, η προεξέχουσα γραμμή είναι λιγότερο ορατή στο τρίγωνο 2 σημείων. Το γεμάτο διαμάντι καλύπτει το άκρο της γραμμής και στα δύο πλάτη.

## **Έλεγχος κειμένου και γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε εάν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, και πώς περιλαμβάνονται ή αναφέρονται οι εξωτερικές γραμματοσειρές. Οι παρακάτω επιλογές σας βοηθούν να εξισορροπήσετε τη οπτική συνέπεια, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειρών στο εξαγόμενο SVG.

### **Διανυσματοποίηση όλου του κειμένου**

Ορίστε το [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) σε `True` για να γράφετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις γραμματοσειρών και κάνει το οπτικό αποτέλεσμα πιο συνεπές μεταξύ browsers, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Επιλογή τρόπου διαχείρισης εξωτερικών γραμματοσειρών**

Το [SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) για τις γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `ADD_LINKS_TO_FONT_FILES` για να αναφέρετε ξεχωριστά αρχεία γραμματοσειρών, `EMBED` για να συμπεριλάβετε τα δεδομένα γραμματοσειράς στο SVG, ή `VECTORIZE` για να αποδίδετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Ελέγξτε τις άδειες χρήσης γραμματοσειρών πριν την ενσωμάτωση.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Μείωση μεγέθους ενσωματωμένων εικόνων**

Χρησιμοποιήστε το [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) για να παραλείψετε τις περικομμένες περιοχές προέλευσης, και το [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) για να ελέγχετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος στη πιστότητα της εικόνας ή στα δεδομένα της εικόνας που διατηρούνται.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Έλεγχος ανάλυσης rasterization μετααρχείου**

Το [SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) ορίζει το κατώτατο όριο ανάλυσης για rasterization μετααρχείων κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να ισορροπήσετε λεπτομέρειες και μέγεθος αρχείου όταν μια εικόνα EMF ή WMF rasterizes. Δεν ορίζει ένα παγκόσμιο DPI για το SVG ή αναγκάζει κάθε αντικείμενο στη διαφάνεια να γίνει ραστική εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), που περιέχει μια εικόνα EMF με στενά τοποθετημένες διαγώνιες γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη διαφάνεια του σε τρεις αναλύσεις rasterization μέσω του [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ταυτόσες ώστε τα αποτελέσματα να μπορούν να συγκριθούν.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Στην έξοδο, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν την παρεχόμενη παρουσίαση· δεν είναι γενικός τύπος μετατροπής DPI σε διαστάσεις pixel.

| Ανάλυση rasterization μετααρχείου DPI | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω δείχνει την ίδια περιοχή του ενσωματωμένου ραστικού σε ίδια μεγεθυμένη οθόνη. Οι διαγώνιες γραμμές δείχνουν ορατή εικονοστοιχία στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή δεν αλλάζει κάθε εξαγόμενη εικόνα.

![Μεγεθυμένη λεπτομέρεια διαγώνιας γραμμής στα 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

Το [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) ελέγχει τη μείωση ανάλυσης εικόνας και μπορεί να καλύψει την επίδραση αλλαγής της ανάλυσης rasterization μετααρχείου. Το [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization μετααρχείου.

## **Συχνές ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) αντί για το [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος για να κάνω ένα SVG μικρότερο;**

Ξεκινήστε συμπιέζοντας τις ενσωματωμένες εικόνες, διαγράφοντας τις περικομμένες περιοχές εικόνας και επιλέγοντας συνδεδεμένα αρχεία γραμματοσειρών όταν το περιβάλλον-στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το διανυσμάτων κείμενο έχουν διαφορετικές ανταλλαγές ποιότητας και μεγέθους.