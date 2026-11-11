---
title: Απόδοση διαφανειών παρουσίασης ως εικόνες SVG στην Python
linktitle: Διαφάνεια σε SVG
type: docs
weight: 50
url: /el/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint σε SVG
- παρουσίαση σε SVG
- διαφάνεια σε SVG
- PPT σε SVG
- PPTX σε SVG
- επιλογές εξαγωγής SVG
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Εξάγετε τις διαφάνειες PowerPoint ως εικόνες SVG στην Python και ελέγξτε τις γραμματοσειρές, το κείμενο και τις εικόνες με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια επεκτάσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, ροές εργασίας προσβασιμότητας και αυτοματοποιημένη μετα-επεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) όταν το εξαχθέν SVG πρέπει να είναι συμπαγές, προβλέψιμο σε προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή Διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή. Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια μιας παρουσίασης ως ξεχωριστό αρχείο SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Το όνομα αρχείου χρησιμοποιεί το [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) αντί για το δείκτη βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση Εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) σε `True` όταν το κείμενο πρέπει να αποδοθεί χωρίς λιγαγές.

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

## **Έλεγχος Κειμένου και Γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε αν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, και πώς οι εξωτερικές γραμματοσειρές περιλαμβάνονται ή αναφέρονται. Οι παρακάτω επιλογές σας βοηθούν να ισορροπήσετε την οπτική συνέπεια, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειρών στο εξαχθέν SVG.

### **Διανυσματοποίηση Όλου του Κειμένου**

Ορίστε το [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) σε `True` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό αφαιρεί τις εξαρτήσεις γραμματοσειρών και κάνει το οπτικό αποτέλεσμα πιο συνεπές σε προγράμματα περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Επιλέξτε Πώς Χειρίζονται οι Εξωτερικές Γραμματοσειρές**

Το [SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) για τις γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `ADD_LINKS_TO_FONT_FILES` για να παραπέμπετε σε ξεχωριστά αρχεία γραμματοσειρών, `EMBED` για να συμπεριλάβετε τα δεδομένα γραμματοσειράς στο SVG, ή `VECTORIZE` για να αποδοθεί μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Ελέγξτε την άδεια χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

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

## **Μείωση Μεγέθους Ενσωματωμένων Εικόνων**

Χρησιμοποιήστε το [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) για να παραλείψετε τις περικομμένες περιοχές προέλευσης, και το [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου εις βάρος της πιστότητας της εικόνας ή των διατηρούμενων δεδομένων εικόνας.

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

## **Έλεγχος Ανάλυσης Υποαπεικόνισης Μετααρχείου**

Το [SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) ορίζει το κατώτερο όριο ανάλυσης για την υποαπεικόνιση των μετααρχείων κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να ισορροπήσετε τις λεπτομέρειες και το μέγεθος του αρχείου όταν μια εικόνα EMF ή WMF υποαπεικονίζεται. Δεν ορίζει ένα καθολικό DPI για το SVG ούτε εξαναγκάζει κάθε αντικείμενο στη διαφάνεια να γίνει ραστέρ εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), το οποίο περιέχει μια εικόνα EMF με στενά τοποθετημένες διαγώνιες γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη του διαφάνεια σε τρεις αναλύσεις υποαπεικόνισης μέσω του [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν τα ίδια ώστε τα αποτελέσματα να μπορούν να συγκριθούν.

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

Στο αποτέλεσμα, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν την παρεχόμενη παρουσίαση· δεν αποτελούν γενικό τύπο μετατροπής DPI σε διαστάσεις εικονοστοιχείου.

| DPI υποαπεικόνισης μετααρχείου | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω δείχνει την ίδια περιοχή του ενσωματωμένου ραστέρ στο ίδιο μεγεθυνόμενο μέγεθος εμφάνισης. Οι διαγώνιες γραμμές εμφανίζουν ορατό πικσιλαρισμό στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή αλλάζει κάθε εξαγόμενη εικόνα.

![Λεπτομέρειες μεγέθυνσης διαγώνιας γραμμής στα 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

Το [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) ελέγχει τη μείωση της ανάλυσης της εικόνας και μπορεί να καλύψει την επίδραση της αλλαγής της ανάλυσης υποαπεικόνισης του μετααρχείου. Το [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση υποαπεικόνισης του μετααρχείου.

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) αντί για το [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήτε το [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος για να μικρύνετε ένα SVG;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περιοχών κλαπμένων εικόνων και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το περιβάλλον στόχος μπορεί να τα παρέχει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και η διανυσματοποίηση του κειμένου έχουν διαφορετικές ανταλλαγές ποιότητας και μεγέθους.