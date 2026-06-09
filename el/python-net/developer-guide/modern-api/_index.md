---
title: Βελτιώστε την Επεξεργασία Εικόνας με το Σύγχρονο API
linktitle: Σύγχρονο API
type: docs
weight: 280
url: /el/python-net/modern-api/
keywords:
- σύγχρονο API
- σχεδίαση
- μικρογραφία διαφάνειας
- διαφάνεια σε εικόνα
- μικρογραφία σχήματος
- σχήμα σε εικόνα
- μικρογραφία παρουσίασης
- παρουσίαση σε εικόνες
- προσθήκη εικόνας
- προσθήκη εικόνας
- Python
- Aspose.Slides
description: "Ενσύγχρονιση της επεξεργασίας εικόνας διαφανειών αντικαθιστώντας τις αποσυρμένες API απεικόνισης με το Σύγχρονο API Python για αδιάλειπτη αυτοματοποίηση PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το δημόσιο API του Aspose.Slides για Python εξαρτάται προς το παρόν από τους ακόλουθους τύπους `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Από την έκδοση 24.4, αυτό το δημόσιο API είναι **αποσυρμένο** λόγω [αλλαγών](https://releases.aspose.com/slides/el/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) στο δημόσιο API του Aspose.Slides για Python.

Για να αφαιρεθεί το `aspose.pydrawing` από το δημόσιο API, εισαγάγαμε το **Σύγχρονο API**. Οι μέθοδοι που χρησιμοποιούν `aspose.pydrawing.Image` και `aspose.pydrawing.Bitmap` είναι αποσυρμένες και πρέπει να αντικατασταθούν από τις αντίστοιχες μεθόδους του Σύγχρονου API. Οι μέθοδοι που χρησιμοποιούν `aspose.pydrawing.Graphics` είναι αποσυρμένες και δεν έχουν άμεση αντικατάσταση στο Σύγχρονο API.

Σε τρέχουσες εκδόσεις, θεωρείστε το δημόσιο API που εξαρτάται από `aspose.pydrawing` ως παλαιό/αποσυρμένο. Χρησιμοποιήστε το Σύγχρονο API για νέο κώδικα και κατά τη μεταφορά υφιστάμενων ροών επεξεργασίας εικόνων.

## **Σύγχρονο API**

Οι παρακάτω κλάσεις και αριθμητικοί τύποι (enums) έχουν προστεθεί στο δημόσιο API:

- [aspose.slides.IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) - αντιπροσωπεύει μια εικόνα raster ή vector.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/imageformat/) - αντιπροσωπεύει μια μορφή αρχείου εικόνας.
- [aspose.slides.Images](https://reference.aspose.com/slides/el/python-net/aspose.slides/images/) - παρέχει μεθόδους για τη δημιουργία και εργασία με [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/).

Χρησιμοποιήστε `get_image` για απόδοση μιας μοναδικής διαφάνειας ή σχήματος. Χρησιμοποιήστε `get_images` για απόδοση πολλών διαφανειών παρουσίασης. Χρησιμοποιήστε μεθόδους του [Images](https://reference.aspose.com/slides/el/python-net/aspose.slides/images/) για φόρτωση εικόνων, `add_image` με [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) για προσθήκη τους σε παρουσίαση, και `replace_image` με [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) για ενημέρωση υπάρχουσας εικόνας παρουσίασης.

Ένα τυπικό σενάριο χρήσης του νέου API μοιάζει ως εξής:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Αντικατάσταση παλιάς κώδικα με το Σύγχρονο API**

Για πιο εύκολη μετάβαση, η νέα κλάση [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) αντικατοπτρίζει τα ξεχωριστά API των κλάσεων `aspose.pydrawing.Image` και `aspose.pydrawing.Bitmap`. Στις περισσότερες περιπτώσεις, χρειάζεται μόνο να αντικαταστήσετε τις κλήσεις σε μεθόδους που χρησιμοποιούν `aspose.pydrawing` με τις αντίστοιχες του Σύγχρονου API.

### **Λήψη μικρογραφίας διαφάνειας**

**Αποσυρμένο API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Σύγχρονο API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Λήψη μικρογραφίας σχήματος**

**Αποσυρμένο API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Σύγχρονο API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Λήψη μικρογραφίας παρουσίασης**

**Αποσυρμένο API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Σύγχρονο API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Προσθήκη εικόνας σε παρουσίαση**

**Αποσυρμένο API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Σύγχρονο API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Μέθοδοι και Ιδιότητες που θα αφαιρεθούν και οι Σύγχρονες Αντιστοιχίες τους**

### **Κλάση Presentation**

|Υπογραφή Μεθόδου|Υπογραφή Αντικαταστατικής Μεθόδου|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Κλάση Slide**

|Υπογραφή Μεθόδου|Υπογραφή Αντικαταστατικής Μεθόδου|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Κλάση Shape**

|Υπογραφή Μεθόδου|Υπογραφή Αντικαταστατικής Μεθόδου|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Κλάση ImageCollection**

|Υπογραφή Μεθόδου|Υπογραφή Αντικαταστατικής Μεθόδου|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Κλάση PPImage**

|Υπογραφή Μεθόδου/Ιδιότητας|Υπογραφή Αντικαταστατικής Μεθόδου/Ιδιότητας|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/image/)|

### **Κλάση ImageWrapperFactory**

|Υπογραφή Μεθόδου|Υπογραφή Αντικαταστατικής Μεθόδου|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Κλάση PatternFormat**

|Υπογραφή Μεθόδου|Υπογραφή Αντικαταστατικής Μεθόδου|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Κλάση IPatternFormatEffectiveData**

|Υπογραφή Μεθόδου|Υπογραφή Αντικαταστατικής Μεθόδου|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/el/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Κλάση Output**

|Υπογραφή Μεθόδου|Υπογραφή Αντικαταστατικής Μεθόδου|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Υποστήριξη API για aspose.pydrawing.Graphics**

Οι μέθοδοι που χρησιμοποιούν `aspose.pydrawing.Graphics` είναι αποσυρμένες και δεν έχουν άμεση αντικατάσταση στο Σύγχρονο API.

Χρησιμοποιήστε τις μεθόδους απόδοσης εικόνας του Σύγχρονου API αντί των μεθόδων που αποδίδουν σε `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί αποσύρθηκε το `aspose.pydrawing.Graphics`;**

Η υποστήριξη για `aspose.pydrawing.Graphics` είναι αποσυρμένη στο δημόσιο API για ενοποίηση της εργασίας με απόδοση και εικόνες, εξάλειψη εξαρτήσεων ειδικών πλατφορμών και μετάβαση σε μια πλατφόρμα-ανεξάρτητη προσέγγιση με [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/). Χρησιμοποιήστε `get_image` ή `get_images` αντί της απόδοσης σε `aspose.pydrawing.Graphics`.

**Ποιο είναι το πρακτικό όφελο του [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) σε σύγκριση με `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`;**

Το [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) ενοποιεί τη δουλειά με raster και vector εικόνες, απλοποιεί την αποθήκευση σε διάφορες μορφές μέσω του [ImageFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/imageformat/), μειώνει την εξάρτηση από το pydrawing και κάνει τον κώδικα πιο φορητό μεταξύ περιβαλλόντων.

**Θα επηρεάσει το Σύγχρονο API την απόδοση της δημιουργίας μικρογραφιών;**

Η μετάβαση από `get_thumbnail` σε `get_image` δεν επιδεινώνει τα σενάρια: οι νέες μέθοδοι παρέχουν τις ίδιες δυνατότητες δημιουργίας εικόνων με επιλογές και μεγέθη, ενώ διατηρούν την υποστήριξη για επιλογές απόδοσης. Το συγκεκριμένο κέρδος ή η μείωση εξαρτάται από το σενάριο, αλλά λειτουργικά οι αντικαταστάσεις είναι ισοδύναμες.