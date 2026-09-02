---
title: Μετατροπή διαφανειών παρουσίασης σε εικόνες με Python
linktitle: Διαφάνεια σε εικόνα
type: docs
weight: 41
url: /el/python-net/convert-slide/
keywords:
- μετατροπή διαφάνειας
- εξαγωγή διαφάνειας
- διαφάνεια σε εικόνα
- αποθήκευση διαφάνειας ως εικόνα
- διαφάνεια σε EMF
- διαφάνεια σε PNG
- διαφάνεια σε JPEG
- διαφάνεια σε bitmap
- διαφάνεια σε TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες από παρουσιάσεις PPT, PPTX και ODP σε PNG, JPEG, GIF, TIFF, EMF και άλλες μορφές εικόνας με Python και Aspose.Slides."
---
## **Εισαγωγή**

Το Aspose.Slides for Python via .NET μπορεί να αποδώσει μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument ως PNG, JPEG, GIF, TIFF και άλλες μορφές εικόνας.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε αυτά τα βήματα:

1. Φορτώστε την παρουσίαση με την κλάση [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Επιλέξτε τη διαφάνεια που θέλετε να αποδώσετε.
3. Αν είναι απαραίτητο, διαμορφώστε την απόδοση με την κλάση [RenderingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/) ή την κλάση [TiffOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/).
4. Καλέστε τη μέθοδο [Slide.get_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/). Επιστρέφει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/).
5. Καλέστε τη μέθοδο [IImage.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/save/) και καθορίστε τη μορφή εξόδου με μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/imageformat/).

## **Μετατροπή μιας διαφάνειας σε εικόνα PNG**

Η πιο απλή μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις απόδοσης. Το προκύπτον αντικείμενο [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) μπορεί να υποστεί επεξεργασία στη μνήμη ή να αποθηκευτεί σε αρχείο.

Το παρακάτω παράδειγμα Python αποδίδει την πρώτη διαφάνεια και την αποθηκεύει ως εικόνα PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Μετατροπή διαφανειών σε εικόνες με προσαρμοσμένα μεγέθη**

Χρησιμοποιήστε την υπερφόρτωση της [Slide.get_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) που δέχεται μια τιμή [Size](https://reference.aspose.com/slides/el/python-net/aspose.pydrawing/size/) για να αποδώσετε μια διαφάνεια με ακριβείς διαστάσεις εικονοστοιχείων.

Το παρακάτω παράδειγμα δημιουργεί μια εικόνα JPEG 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Μετατροπή διαφανειών με σημειώσεις και σχόλια σε εικόνες**

Από προεπιλογή, οι εικόνες διαφανειών δεν περιλαμβάνουν σημειώσεις ή σχόλια. Αντιστοιχίστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notescommentslayoutingoptions/) στην ιδιότητα [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) για να ελέγξετε πού εμφανίζονται οι σημειώσεις και τα σχόλια.

Το παρακάτω παράδειγμα τοποθετεί περικομμένες σημειώσεις κάτω από τη διαφάνεια και σχόλια στη δεξιά της πλευρά:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Προειδοποίηση" color="warning" %}}
Για τη μεταφορά διαφάνειας-σε-εικόνα, μην ρυθμίζετε την ιδιότητα [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) σε [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notespositions/). Οι σημειώσεις μπορούν να περιέχουν περισσότερο κείμενο απ' ό,τι η σταθερή διάσταση της εικόνας μπορεί να χωρέσει. Χρησιμοποιήστε την [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notespositions/) αντ' αυτού.
{{% /alert %}}

## **Μετατροπή διαφανειών σε εικόνες χρησιμοποιώντας επιλογές TIFF**

Η κλάση [TiffOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/) σάς επιτρέπει να ελέγξετε το μέγεθος, την ανάλυση και άλλες ιδιότητες της αποδομένης εικόνας TIFF.

Το παρακάτω παράδειγμα αποδίδει την πρώτη διαφάνεια ως εικόνα TIFF 2160 × 2880 με 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Μετατροπή όλων των διαφανειών σε εικόνες**

Επαναλάβετε τη συλλογή των διαφανειών για να μετατρέψετε ολόκληρη την παρουσίαση σε σειρά εικόνων. Οι κρυμμένες διαφάνειες περιλαμβάνονται εκτός εάν τις παραλείψετε εσείς ρητά.

Το παρακάτω παράδειγμα αποδίδει κάθε διαφάνεια ως εικόνα JPEG με οριζόντιους και κατακόρυφους συντελεστές κλίμακας 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Δημιουργία εξόδου Enhanced Metafile**

Το Enhanced Metafile (EMF) είναι χρήσιμο όταν γραφικά βασισμένα σε διανύσματα πρέπει να ανταλλαγούν με το Microsoft Office ή άλλες εφαρμογές Windows που υποστηρίζουν Windows metafiles. Σε αντίθεση με μια εικόνα βασισμένη σε εικονοστοιχεία, ένα EMF μπορεί να διατηρήσει λειτουργίες σχεδίασης διανυσμάτων που κλιμακώνονται χωρίς την ίδια απώλεια ευκρίνειας. Ωστόσο, το EMF είναι κυρίως μια μορφή συμβατότητας για εφαρμογές με υποστήριξη Windows metafile, όχι μια καθολική μορφή ανταλλαγής. Επιπλέον, πολύπλοκο περιεχόμενο διαφάνειας, όπως εικόνες bitmap και ορισμένα εφέ, μπορεί να αποθηκευτεί ως rasterized στοιχεία μέσα στο κοντέινερ διανυσματικού metafile.

### **Εξαγωγή διαφάνειας σε EMF**

Η μέθοδος [Slide.write_as_emf](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/write_as_emf/) γράφει μια [Slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/) σε ροή-στόχο σε μορφή EMF. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, επιλέγει την πρώτη διαφάνεια και τη γράφει σε ροή αρχείου EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Ο καλών είναι ιδιοκτήτης της ροής που περνιέται στην [Slide.write_as_emf](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/write_as_emf/) και πρέπει να την κλείσει. Το Aspose.Slides γράφει στη τρέχουσα θέση της ροής και αφήνει τη ροή ανοιχτή.

### **Μετατροπή εικόνας SVG σε EMF και προσθήκη της σε παρουσίαση**

Χρησιμοποιήστε την [SvgImage.write_as_emf](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/write_as_emf/) για να μετατρέψετε περιεχόμενο SVG σε EMF. Τα προκύπτοντα bytes μπορούν να προστεθούν στην παρουσίαση μέσω της [ImageCollection.add_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/add_image/) και να τοποθετηθούν σε μια διαφάνεια με την [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/).

Το παρακάτω παράδειγμα δημιουργεί μια [SvgImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/) από SVG markup, τη μετατρέπει σε εν-μνήμη EMF, εισάγει το metafile στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

Η [SvgImage.write_as_emf](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/write_as_emf/) δεν αποκτά ιδιοκτησία της ροής-προορισμού. Μετά τη γραφή, η θέση της ροής είναι στο τέλος των παραγόμενων δεδομένων. Καλέστε `getvalue` για να λάβετε το πλήρες buffer ανεξάρτητα από την τρέχουσα θέση της ροής, όπως φαίνεται παραπάνω. Διατηρήστε τη ροή ανοιχτή μέχρι να διαβαστούν τα δεδομένα και κλείστε την μετά.

Η δημιουργία EMF είναι διαθέσιμη στα λειτουργικά συστήματα που υποστηρίζονται από το Aspose.Slides for Python via .NET, αλλά η απόδοση μπορεί να διαφέρει ανά πλατφόρμα όταν λείπουν γραμματοσειρές ή εξαρτήσεις εγγενούς γραφικής. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιεί το πηγαίο περιεχόμενο ή ρυθμίστε κατάλληλες αντικαταστάσεις, ακολουθήστε τις [απαιτήσεις πλατφόρμας](/slides/el/python-net/system-requirements/) για το Aspose.Slides και επαληθεύστε το αποτέλεσμα στην εφαρμογή-καταναλωτή EMF. Οι εφαρμογές Linux και macOS συχνά έχουν περιορισμένη ή ασυνεπή υποστήριξη για την εμφάνιση και επεξεργασία Windows metafiles.

## **Απόδοση χρωματικών Emoji**

{{% alert title="Σημείωση" color="info" %}}
Για να αποδώσετε σωστά χρωματικά emoji κατά τη μετατροπή διαφανειών παρουσίασης σε εικόνες, οι γραμματοσειρές emoji που χρησιμοποιούνται στην παρουσίαση πρέπει να είναι εγκατεστημένες και διαθέσιμες στο σύστημα που εκτελεί τη μετατροπή. Για παράδειγμα, εάν η παρουσίαση χρησιμοποιεί **Segoe UI Emoji** και αυτή η γραμματοσειρά λείπει, τα emoji μπορεί να εμφανιστούν σε μονόχρωμη μορφή στις εικόνες εξόδου.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την απόδοση διαφανειών με κινούμενα σχέδια;**

Όχι. Η μέθοδος [Slide.get_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/) αποδίδει μια στατική εικόνα της διαφάνειας και δεν εξάγει τις κινήσεις.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι. Οι κρυμμένες διαφάνειες μπορούν να αποδοθούν όπως οι κανονικές διαφάνειες. Συμπεριλάβετε τις στη βρόχο επεξεργασίας, όπως φαίνεται στο παραπάνω παράδειγμα.

**Διατηρούνται οι σκιές και άλλα εφέ στις εικόνες διαφανειών;**

Ναι. Το Aspose.Slides αποδίδει σκιές, διαφάνεια και άλλα υποστηριζόμενα γραφικά εφέ στις εικόνες διαφανειών.