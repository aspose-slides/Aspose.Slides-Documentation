---
title: Εξαγωγή Εικόνων από Σχήματα Παρουσίασης σε Python μέσω Java
linktitle: Εικόνα από Σχήμα
type: docs
weight: 100
url: /el/python-java/extracting-images-from-presentation-shapes/
keywords:
- εξαγωγή εικόνας
- ανάκτηση εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εξαγωγή εικόνων από σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω Java – γρήγορη, φιλική προς τον κώδικα λύση."
---
## **Επισκόπηση**

Οι εικόνες σε μια παρουσίαση μπορούν να εμφανιστούν σε διάφορους τύπους σχημάτων: ως κανονικά πλαίσια εικόνας, ως γεμίσματα εικόνας που εφαρμόζονται στα σχήματα, ως εικόνες προεπισκόπησης αντικειμένων OLE, ως μικρογραφίες πλαισίων βίντεο ή ήχου, ως εικόνες ζουμ ή ως εικόνες ενσωματωμένες μέσα σε σχήματα πίνακα, διαγράμματος και SmartArt. Το Aspose.Slides αποθηκεύει αυτές τις εικόνες στη συλλογή εικόνων της παρουσίασης, προσβάσιμη μέσω των αντικειμένων [ImageCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/) και [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) .

Αν χρειάζεστε μόνο την εξαγωγή κάθε ενσωματωμένου πόρου εικόνας σε μια παρουσίαση, επαναλάβετε μέσω του [Presentation.getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages). Αυτό το άρθρο εστιάζει σε διαφορετικό έργο: την περιήγηση στα σχήματα για να εντοπιστεί πού χρησιμοποιούνται οι εικόνες στις διαφάνειες, ώστε τα αποθηκευμένα αρχεία να διατηρούν χρήσιμο πλαίσιο όπως ο αριθμός διαφάνειας, η θέση του σχήματος και ο τύπος προέλευσης (πλαίσιο εικόνας, εικόνα γεμίσματος, προεπισκόπηση πολυμέσων, προεπισκόπηση OLE ή εικόνα ζουμ).

{{% alert title="Tip" color="success" %}}
Χρησιμοποιήστε το [PPImage.getBinaryData](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getBinaryData) για να διατηρήσετε τα αρχικά κωδικοποιημένα δεδομένα εικόνας και τον τύπο αρχείου. Χρησιμοποιήστε το [PPImage.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getImage) με `save` όταν θέλετε να ομαλοποιήσετε την έξοδο σε συγκεκριμένη μορφή όπως PNG.
{{% /alert %}}

## **Κοινές Βοηθητικές Συναρτήσεις**

Αποθηκεύστε τις κοινές βοηθητικές συναρτήσεις παρακάτω στο αρχείο `image_helpers.py` μαζί με τα παραδείγματα script. Κρατούν τα παραδείγματα σύντομα. Η `save_original_image` γράφει τα αρχικά ενσωματωμένα bytes, επιλέγει ασφαλή επέκταση από τον τύπο MIME και παρακάμπτει διπλότυπα δυαδικά δεδομένα εικόνας με βάση το SHA-256 hash.

```python
from pathlib import Path
import hashlib
import re

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GroupShape, ImageFormat


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.getBinaryData())
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False
    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.getContentType())
    output_file = Path(output_directory) / f"{file_name_base}.{extension}"
    output_file.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    output_file = Path(output_directory) / f"{file_name_base}.png"
    output_image = image.getImage()
    try:
        output_image.save(str(output_file), ImageFormat.Png)
    finally:
        output_image.dispose()


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.getFillType() != FillType.Picture:
        return None
    return fill_format.getPictureFillFormat().getPicture().getImage()


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    shape_references = []
    for shape_index in range(shapes.size()):
        shape = shapes.get_Item(shape_index)
        shape_name_part = f"{prefix}_shape_{shape_index + 1}"
        shape_references.append((shape, shape_name_part))
        if include_grouped_shapes and isinstance(shape, GroupShape):
            child_shapes = shape.getShapes()
            child_references = enumerate_shapes(child_shapes, shape_name_part, include_grouped_shapes)
            shape_references.extend(child_references)
    return shape_references


def get_extension_from_content_type(content_type):
    if content_type is None or not str(content_type).strip():
        return "bin"
    media_type = str(content_type).split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }
    if media_type in extensions:
        return extensions[media_type]
    if media_type.startswith("image/"):
        return re.sub(r"[^A-Za-z0-9._-]", "_", media_type[len("image/"):])
    return "bin"
```

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνας**

Χρησιμοποιήστε αυτή τη μέθοδο για εικόνες που έχουν εισαχθεί ως ανεξάρτητα αντικείμενα. Ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) παρέχει πρόσβαση στην εικόνα του μέσω των [getPictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#getPicture) και [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#getImage), που επιστρέφει ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) .

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων από Σχήματα γεμισμένα με Εικόνα**

Τα σχήματα μπορούν να χρησιμοποιούν μια εικόνα ως γέμισμα. Ελέγξτε πρώτα τον τύπο γεμίσματος του σχήματος: αν δεν είναι [FillType.Picture](https://reference.aspose.com/slides/el/python-java/aspose.slides/filltype/), δεν υπάρχει εικόνα προς εξαγωγή από το γέμισμα. Το παρακάτω παράδειγμα διαχειρίζεται αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) και αποθηκεύει κάθε εικόνα ως PNG μέσω του [PPImage.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getImage) .

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Αντικειμένων OLE**

Ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) μπορεί να έχει μια εναλλακτική εικόνα που το PowerPoint χρησιμοποιεί ως προεπισκόπηση του αντικειμένου στη διαφάνεια. Αυτή η εικόνα είναι διαθέσιμη μέσω των [getSubstitutePictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#getPicture) και [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#getImage). Η εξαγωγή αυτής της εικόνας παρέχει την εικόνα προεπισκόπησης, όχι τα ενσωματωμένα περιεχόμενα του πακέτου OLE.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, OleObjectFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Βίντεο**

Ένα [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) μπορεί επίσης να αποθηκεύει μια εικόνα προεπισκόπησης μέσω των [getPictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#getPicture) και [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#getImage). Αυτή είναι η αφίσα ή μικρογραφία που εμφανίζεται στη διαφάνεια, όχι ένα καρέ που αποκωδικοποιείται από τη ροή βίντεο.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Ήχου**

Ένα [AudioFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/) μπορεί να αποθηκεύσει μια μικρογραφία μέσω των [getPictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#getPicture) και [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#getImage). Αυτή είναι η εικόνα που εμφανίζεται για το αντικείμενο ήχου στη διαφάνεια.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων από Αντικείμενα Zoom**

Τα σχήματα [ZoomFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomframe/) και [SectionZoomFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/sectionzoomframe/) μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες. Διαβάστε το [getZoomImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomobject/#getZoomImage) από το πλαίσιο ζουμ.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SectionZoomFrame, ZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, ZoomFrame):
                zoom_frame = shape
                image = zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
            if isinstance(shape, SectionZoomFrame):
                section_zoom_frame = shape
                image = section_zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_section_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων από Πλαίσια Περίληψης Zoom**

Ένα [SummaryZoomFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/summaryzoomframe/) είναι επίσης σχήμα. Τα στοιχεία των ενοτήτων του μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες, προσβάσιμες μέσω της μεθόδου [getZoomImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomobject/#getZoomImage) κάθε ενότητας σύνοψης ζουμ.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SummaryZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, SummaryZoomFrame):
                summary_zoom_frame = shape
                section_count = summary_zoom_frame.getSummaryZoomCollection().size()
                for section_index in range(section_count):
                    section = summary_zoom_frame.getSummaryZoomCollection().get_Item(section_index)
                    image = section.getZoomImage()
                    if image is not None:
                        display_index = section_index + 1
                        file_name_base = name_part + "_summary_zoom_" + str(display_index)
                        save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων από Σχήματα Πίνακα**

Ένας [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/) είναι σχήμα. Οι εικόνες σε έναν πίνακα συνήθως αποθηκεύονται ως γεμίσματα εικόνας στα κελιά του πίνακα.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Table):
                table = shape
                row_count = table.getRows().size()
                column_count = table.getColumns().size()
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = table.get_Item(column_index, row_index)
                        fill_format = cell.getCellFormat().getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_row = row_index + 1
                            display_column = column_index + 1
                            file_name_base = name_part + "_cell_" + str(display_row) + "_" + str(display_column)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων από Σχήματα Διαγράμματος**

Ένα [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/) είναι σχήμα. Το παρακάτω παράδειγμα εξάγει μια εικόνα από το γέμισμα εικόνας της περιοχής του διαγράμματος.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Chart):
                chart = shape
                fill_format = chart.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = name_part + "_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων από Σχήματα SmartArt**

Ένα αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/) είναι σχήμα. Ανάλογα με τη διάταξη του SmartArt, οι εικόνες μπορεί να αποθηκεύονται σε γεμίσματα του κεφαλαίου κόμβου ή στα γεμίσματα των σχημάτων των κόμβων.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, SmartArt):
                smart_art = shape
                node_count = smart_art.getAllNodes().size()
                for node_index in range(node_count):
                    node = smart_art.getAllNodes().get_Item(node_index)
                    bullet_fill_format = node.getBulletFillFormat()
                    bullet_image = get_picture_fill_image(bullet_fill_format)
                    if bullet_image is not None:
                        display_node = node_index + 1
                        file_name_base = name_part + "_smartart_node_" + str(display_node) + "_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)
                    node_shape_count = node.getShapes().size()
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.getShapes().get_Item(node_shape_index)
                        fill_format = node_shape.getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_node = node_index + 1
                            display_node_shape = node_shape_index + 1
                            file_name_base = name_part + "_smartart_node_" + str(display_node) + "_shape_" + str(display_node_shape)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Συμπερίληψη Εικόνων μέσα σε Ομαδοποιημένα Σχήματα**

Τα ομαδοποιημένα σχήματα περιέχουν τις δικές τους συλλογές σχημάτων. Η κοινή βοηθητική συνάρτηση `enumerate_shapes` έχει επιλογή `include_grouped_shapes`. Ορίστε την σε `True` όταν θέλετε να ελέγξετε τα σχήματα μέσα σε αντικείμενα [GroupShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/groupshape/) . Το παρακάτω παράδειγμα εξάγει εικόνες από πλαίσια εικόνας, σχήματα γεμισμένα με εικόνα, προεπισκοπήσεις αντικειμένων OLE, μικρογραφίες πλαισίων βίντεο και μικρογραφίες πλαισίων ήχου. Για να συμπεριλάβετε επίσης εικόνες πίνακα, διαγράμματος, SmartArt και σύνοψης ζουμ, επαναχρησιμοποιήστε τη εξειδικευμένη λογική εξαγωγής από τις προηγούμενες ενότητες διατηρώντας την ίδια αναδρομική περιήγηση των σχημάτων.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame, AutoShape, OleObjectFrame, PictureFrame, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Ακραίες Περιπτώσεις και Πρακτικές Σημειώσεις**

- **Διπλότυπες εικόνες:** Πολλά σχήματα μπορεί να αναφέρονται στην ίδια εικόνα ή σε ξεχωριστές εικόνες με πανομοιότυπα bytes. Υπολογίστε hash του [PPImage.getBinaryData](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getBinaryData) πριν γράψετε τα αρχεία εάν θέλετε ένα αρχείο εξόδου ανά μοναδική εικόνα.
- **Αρχικά δεδομένα vs. μετατραπείσα έξοδος:** Η αποθήκευση του [PPImage.getBinaryData](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getBinaryData) διατηρεί τα ενσωματωμένα δεδομένα JPEG, PNG, GIF, SVG, EMF ή WMF. Η αποθήκευση του [PPImage.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getImage) μέσω `save` είναι χρήσιμη όταν θέλετε μια ενοποιημένη μορφή εξόδου.
- **Μη υποστηριζόμενοι τύποι γεμίσματος:** Σχήματα στερεού, διαβαθμισμένου, μοτίβου ή χωρίς γέμισμα δεν περιέχουν γέμισμα εικόνας. Ελέγξτε το [FillType](https://reference.aspose.com/slides/el/python-java/aspose.slides/filltype/) πριν διαβάσετε το [getPictureFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Ομαδοποιημένα σχήματα:** Η συλλογή σχημάτων της διαφάνειας επιπέδου κορυφής δεν απο επίπεδώνει τις ομάδες. Εξετάστε αναδρομικά το [GroupShape.getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/groupshape/#getShapes) όταν το ομαδοποιημένο περιεχόμενο έχει σημασία.
- **Προεπισκοπήσεις αντικειμένων OLE:** Ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) μπορεί να εμφανίσει μια εικόνα προεπισκόπησης μέσω του [getSubstitutePictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), αλλά αυτή η εικόνα είναι μόνο η προεπισκόπηση της διαφάνειας. Δεν είναι το ενσωματωμένο αρχείο μέσα στο αντικείμενο OLE.
- **Μικρογραφίες πλαισίων βίντεο:** Ένα [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) μπορεί να εμφανίσει μια εικόνα προεπισκόπησης μέσω του [getPictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#getPictureFormat), αλλά αυτή η εικόνα είναι μόνο η αφίσα που εμφανίζεται στη διαφάνεια. Δεν εξάγεται από τη ροή του βίντεο.
- **Μικρογραφίες πλαισίων ήχου:** Ένα [AudioFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/audioframe/) μπορεί να εμφανίσει ένα εικονίδιο ή μικρογραφία μέσω του [getPictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#getPictureFormat); δεν είναι τα ενσωματωμένα δεδομένα ήχου.
- **Εικόνες ζουμ:** Τα σχήματα ζουμ διαφάνειας, τμήματος και σύνοψης ζουμ μπορεί να χρησιμοποιούν προσαρμοσμένα αντικείμενα [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) μέσω του [getZoomImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Φωλιασμένα μοντέλα σχημάτων:** Τα αντικείμενα πίνακα, διαγράμματος και SmartArt υλοποιούν το [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/), αλλά οι εικόνες τους συχνά αποθηκεύονται σε φωλιασμένα κελιά πίνακα, στοιχεία διαγράμματος ή αντικείμενα μορφοποίησης κόμβων SmartArt.
- **Κομμένες ή μετασχηματισμένες εικόνες:** Η πρόσβαση στο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) σας δίνει τον αποθηκευμένο πόρο εικόνας. Δεν εφαρμόζει κοπή, διαφάνεια, αλλαγή χρώματος, περιστροφή ή άλλα οπτικά εφέ που εφαρμόζει το σχήμα.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να εξάγω την αρχική εικόνα χωρίς κοπές, εφέ ή μετασχηματισμούς σχήματος;**

Ναι. Πρόσβαση στο αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) και εγγραφή του [PPImage.getBinaryData](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getBinaryData) στο δίσκο. Αυτό διατηρεί την αρχική κωδικοποιημένη εικόνα που είναι αποθηκευμένη στην παρουσίαση, όχι τον τρόπο που η εικόνα αποδίδεται στη διαφάνεια.

**Μπορώ να εξάγω κάθε εξαγόμενη εικόνα ως PNG;**

Ναι. Χρησιμοποιήστε το [PPImage.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getImage) για να αποκτήσετε ένα αντικείμενο εικόνας, και έπειτα καλέστε `save` με το [ImageFormat.Png](https://reference.aspose.com/slides/el/python-java/aspose.slides/imageformat/). Αυτό μετατρέπει την έξοδο και μπορεί να μην διατηρήσει τον αρχικό τύπο αρχείου ή τα διανυσματικά δεδομένα.

**Πώς μπορώ να αποφύγω την αποθήκευση της ίδιας εικόνας περισσότερες από μία φορές;**

Χρησιμοποιήστε ένα hash του [PPImage.getBinaryData](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getBinaryData) και κρατήστε τα hash σε ένα σύνολο. Αν μια νέα εικόνα έχει hash που υπάρχει ήδη, παραλείψτε την ή καταγράψτε άλλη αναφορά στο υπάρχον αρχείο εξόδου.

**Γιατί ορισμένα σχήματα δεν παράγουν εικόνα;**

Τα πλαίσια εικόνας, τα σχήματα γεμισμένα με εικόνα, τα πλαίσια αντικειμένων OLE, τα πλαίσια πολυμέσων, τα πλαίσια ζουμ, οι πίνακες, τα διαγράμματα και τα αντικείμενα SmartArt μπορούν να αναφέρουν εικόνες. Ορισμένοι τύποι σχημάτων εκθέτουν εικόνες μέσω φωλιασμένων αντικειμένων μορφοποίησης, έτσι ένας απλός έλεγχος του [getPictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#getPictureFormat) ή του [getFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getFillFormat) του σχήματος δεν αρκεί πάντα.

**Μπορώ να εξάγω τη μικρογραφία που εμφανίζεται για ένα πλαίσιο βίντεο;**

Ναι. Χρησιμοποιήστε το [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) και διαβάστε τα [getPictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#getPicture) και [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#getImage). Αυτό εξάγει την εικόνα αφίσας που είναι αποθηκευμένη με το πλαίσιο βίντεο, όχι ένα καρέ που δημιουργείται από το αρχείο βίντεο.

**Πώς μπορώ να προσδιορίσω ποια σχήματα χρησιμοποιούν μια συγκεκριμένη εικόνα από τη συλλογή εικόνων της παρουσίασης;**

Το Aspose.Slides δεν αποθηκεύει αντίστροφους συνδέσμους από το [PPImage] προς τα σχήματα. Δημιουργήστε μια αντιστοίχιση κατά την περιήγηση: κάθε φορά που βρείτε μια αναφορά εικόνας, καταγράψτε τον αριθμό διαφάνειας, τη διαδρομή του σχήματος και το hash ή το στοιχείο της συλλογής εικόνας.

**Μπορώ να εξάγω εικόνες ενσωματωμένες μέσα σε αντικείμενα OLE, όπως συνυπάρχοντα έγγραφα;**

Μπορείτε να εξάγετε την προεπισκόπηση διαφάνειας του αντικειμένου OLE μέσω του [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Ωστόσο, αυτή η προεπισκόπηση δεν είναι το ενσωματωμένο έγγραφο. Για να εξάγετε εικόνες από το εσωτερικό του ενσωματωμένου αρχείου, εξάγετε τα δεδομένα OLE και εξετάστε τα με εργαλεία για τον αντίστοιχο τύπο αρχείου.