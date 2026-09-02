---
title: Απόδοση διαφανειών παρουσίασης ως εικόνες SVG σε Python
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
description: "Εξάγετε τις διαφάνειες PowerPoint ως εικόνες SVG σε Python και ελέγξτε τις γραμματοσειρές, το κείμενο και τις εικόνες με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια επεκτάσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, ροές εργασίας προσβασιμότητας και αυτόματη μετα-επεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/) όταν το εξαχθέν SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή μιας Διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή. Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Το όνομα αρχείου χρησιμοποιεί το [Slide.slide_number](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/slide_number/) αντί για το δείκτη του βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [Shape.write_as_svg](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/write_as_svg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση Εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.use_frame_size](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/use_frame_size/) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης και το [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) καθορίζει εάν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) σε `True` όταν το κείμενο πρέπει να αποδοθεί χωρίς λογιότητες.

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

### **Διανυσματοποίηση Όλου του Κειμένου**

Ορίστε το [SVGOptions.vectorize_text](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/vectorize_text/) σε `True` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό αφαιρεί τις εξαρτήσεις από γραμματοσειρές και καθιστά το οπτικό αποτέλεσμα πιο συνεπές σε διαφορετικά προγράμματα περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Επιλέξτε Πώς Θα Χειριστούν οι Εξωτερικές Γραμματοσειρές**

Το [SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgexternalfontshandling/) για τις γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `ADD_LINKS_TO_FONT_FILES` για να αναφέρετε ξεχωριστά αρχεία γραμματοσειρών, `EMBED` για να ενσωματώσετε τα δεδομένα γραμματοσειράς στο SVG, ή `VECTORIZE` για να αποδείξετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Ελέγξτε τις άδειες χρήσης γραμματοσειρών πριν την ενσωμάτωση.

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

Χρησιμοποιήστε το [SVGOptions.pictures_compression](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/pictures_compression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) για να παραλείψετε περιοχές εικόνας που έχουν κοπεί, και το [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/jpeg_quality/) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με την τιμή της πιστότητας της εικόνας ή της διατηρημένης πληροφορίας εικόνας.

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

## **Συχνές Ερωτήσεις**

**When should I use [SVGOptions.vectorize_text](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/vectorize_text/) instead of [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Χρησιμοποιήστε το [SVGOptions.vectorize_text](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/vectorize_text/) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**What is the best way to make an SVG smaller?**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή περιοχών εικόνας που έχουν κοπεί και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το στοχευμένο περιβάλλον μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το διανυσματοποιημένο κείμενο έχουν διαφορετικές ανταλλαγές ποιότητας και μεγέθους.