---
title: Εξαγωγή εικόνων από σχήματα παρουσίασης σε Python
linktitle: Εικόνα από σχήμα
type: docs
weight: 90
url: /el/python-net/extracting-images-from-presentation-shapes/
keywords:
- εξαγωγή εικόνας
- ανάκτηση εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εξαγωγή εικόνων από σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET - γρήγορη, φιλική προς τον κώδικα λύση."
---
## **Επισκόπηση**

Οι εικόνες σε μια παρουσίαση μπορούν να εμφανιστούν σε διάφορους τύπους σχήματος: ως απλά πλαίσια εικόνας, ως γεμίσματα εικόνας που εφαρμόζονται σε σχήματα, ως προεπισκοπήσεις αντικειμένων OLE, ως μικρογραφίες πλαισίων βίντεο ή ήχου, ως εικόνες μεγέθυνσης ή ως εικόνες ενσωματωμένες μέσα σε σχήματα πίνακα, γραφήματος και SmartArt. Το Aspose.Slides αποθηκεύει αυτές τις εικόνες στη συλλογή εικόνων της παρουσίασης, προσβάσιμη μέσω των αντικειμένων [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/) και [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) .

Αν χρειάζεστε μόνο την εξαγωγή κάθε ενσωματωμένου πόρου εικόνας σε μια παρουσίαση, διατρέξτε το `presentation.images`. Αυτό το άρθρο εστιάζει σε διαφορετικό έργο: την περιήγηση στα σχήματα για να βρεθεί πού χρησιμοποιούνται οι εικόνες στις διαφάνειες, ώστε τα αποθηκευμένα αρχεία να διατηρούν χρήστικό συμφραζόμενο όπως ο αριθμός της διαφάνειας, η θέση του σχήματος και ο τύπος προέλευσης (πλαίσιο εικόνας, γεμιστική εικόνα, προεπισκόπηση πολυμέσων, προεπισκόπηση OLE ή εικόνα μεγέθυνσης).

{{% alert title="Tip" color="primary" %}}
Χρησιμοποιήστε την ιδιότητα `binary_data` του [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) για να διατηρήσετε τα αρχικά κωδικοποιημένα δεδομένα της εικόνας και τον τύπο αρχείου. Χρησιμοποιήστε την ιδιότητα `image` με `save` όταν θέλετε να ομαλοποιήσετε την έξοδο σε συγκεκριμένη μορφή όπως PNG.
{{% /alert %}}

## **Κοινές Βοηθητικές Μεθόδους**

Οι παρακάτω βοηθητικές μέθοδοι κρατούν τα παραδείγματα σύντομα. Η `save_original_image` γράφει τα αρχικά ενσωματωμένα bytes, επιλέγει ασφαλή επέκταση από τον τύπο MIME και παραλείπει διπλότυπα δυαδικά δεδομένα εικόνας με βάση το SHA‑256 hash.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
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
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνας**

Χρησιμοποιήστε αυτήν την προσέγγιση για εικόνες που εισάγονται ως αυτόνομα αντικείμενα. Ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) αποθηκεύει την εικόνα του στη `picture_format.picture.image`, η οποία επιστρέφει ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) .

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Εξαγωγή Εικόνων από Σχήματα Με Γέμιση Εικόνας**

Τα σχήματα μπορούν να χρησιμοποιούν μια εικόνα ως γέμισμα. Ελέγξτε πρώτα τον τύπο γεμίσματος του σχήματος: αν δεν είναι [FillType.PICTURE](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/), δεν υπάρχει εικόνα προς εξαγωγή από αυτό το γέμισμα. Το παρακάτω παράδειγμα διαχειρίζεται αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) και αποθηκεύει κάθε εικόνα ως PNG μέσω της ιδιότητας `image` του [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) .

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **Εξαγωγή Προεπισκοπήσεων Εικόνων από Πλαίσια Αντικειμένων OLE**

Ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/oleobjectframe/) μπορεί να έχει αντικαταστάτική εικόνα που το PowerPoint χρησιμοποιεί ως προεπισκόπηση του αντικειμένου στη διαφάνεια. Αυτή η εικόνα είναι διαθέσιμη μέσω της `substitute_picture_format.picture.image`. Η εξαγωγή αυτής της εικόνας σας δίνει την προεπισκόπηση, όχι τα ενσωματωμένα περιεχόμενα του πακέτου OLE.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Εξαγωγή Προεπισκοπήσεων Εικόνων από Πλαίσια Βίντεο**

Ένα [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) μπορεί επίσης να αποθηκεύσει μια προεπισκόπηση στην `picture_format.picture.image`. Αυτή είναι η αφίσα ή μικρογραφία που εμφανίζεται στη διαφάνεια, όχι ένα καρέ που αποκωδικοποιείται από τη ροή του βίντεο.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Εξαγωγή Προεπισκοπήσεων Εικόνων από Πλαίσια Ήχου**

Ένα [AudioFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/) μπορεί να αποθηκεύσει μια μικρογραφία στην `picture_format.picture.image`. Αυτή είναι η εικόνα που εμφανίζεται για το αντικείμενο ήχου στη διαφάνεια.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Εξαγωγή Εικόνων από Zoom Αντικείμενα**

Τα σχήματα [ZoomFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/zoomframe/) και [SectionZoomFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/sectionzoomframe/) μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες. Διαβάστε το `zoom_image` από το πλαίσιο ζουμ.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **Εξαγωγή Εικόνων από Πλαίσια Σύνοψης Zoom**

Ένα [SummaryZoomFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/summaryzoomframe/) είναι επίσης σχήμα. Τα στοιχεία της ενότητας μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες, εκτεθειμένες μέσω της ιδιότητας `zoom_image` κάθε ενότητας σύνοψης ζουμ.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **Εξαγωγή Εικόνων από Σχήματα Πίνακα**

Ένα [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) είναι σχήμα. Οι εικόνες σε έναν πίνακα αποθηκεύονται συνήθως ως γεμίσματα εικόνας στα κελιά του πίνακα.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Εξαγωγή Εικόνων από Σχήματα Γραφήματος**

Ένα [Chart](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/) είναι σχήμα. Το παρακάτω παράδειγμα εξάγει μια εικόνα από το γεμιστικό της περιοχής του γραφήματος.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Εξαγωγή Εικόνων από Σχήματα SmartArt**

Ένα αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/) είναι σχήμα. Ανάλογα με τη διάταξη του SmartArt, οι εικόνες μπορεί να αποθηκεύονται σε γεμίσματα σημάτων κόμβων ή στα μορφοποιημένα γεμίσματα των σχήματων των κόμβων.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Συμπερίληψη Εικόνων μέσα σε Ομαδοποιημένα Σχήματα**

Τα ομαδοποιημένα σχήματα περιέχουν τις δικές τους συλλογές σχήματος. Η κοινή βοηθητική μέθοδος `enumerate_shapes` διαθέτει την επιλογή `include_grouped_shapes`. Ορίστε την σε `True` όταν θέλετε να εξετάσετε σχήματα μέσα σε αντικείμενα [GroupShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/) . Το παρακάτω παράδειγμα εξάγει εικόνες από πλαίσια εικόνας, σχήματα με γεμιστική εικόνα, προεπισκοπήσεις αντικειμένων OLE, μικρογραφίες πλαισίων βίντεο και μικρογραφίες πλαισίων ήχου. Για να συμπεριλάβετε επίσης εικόνες πινάκων, γραφημάτων, SmartArt και σύνοψης ζουμ, επαναχρησιμοποιήστε την εξειδικευμένη λογική εξαγωγής από τις προηγούμενες ενότητες διατηρώντας την ίδια αναδρομική περιήγηση σχήματος.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Ακραίες Περιπτώσεις και Πρακτικές Σημειώσεις**

- **Διπλότυπες εικόνες:** Πολλά σχήματα μπορεί να αναφέρονται στην ίδια εικόνα ή σε ξεχωριστές εικόνες με ταυτόσια bytes. Κάντε hash της ιδιότητας `binary_data` του [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) πριν γράψετε αρχεία αν θέλετε ένα αρχείο εξόδου ανά μοναδική εικόνα.
- **Αρχικά δεδομένα vs. μετατρεπόμενη έξοδος:** Η αποθήκευση της ιδιότητας `binary_data` του [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) διατηρεί τα ενσωματωμένα δεδομένα JPEG, PNG, GIF, SVG, EMF ή WMF. Η αποθήκευση της ιδιότητας `image` μέσω `save` είναι χρήσιμη όταν θέλετε σταθερή μορφή εξόδου.
- **Μη υποστηριζόμενοι τύποι γεμίσματος:** Σχήματα στερεού, διαβάθμισης, μοτίβου ή χωρίς γέμισμα δεν περιέχουν γεμιστική εικόνα. Ελέγξτε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) πριν διαβάσετε το `picture_fill_format`.
- **Ομαδοποιημένα σχήματα:** Η συλλογή σχήματος της κορυφαίας διαφάνειας δεν ισοπεδώνει τις ομάδες. Εξετάστε αναδρομικά το [GroupShape.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/shapes/) όταν το ομαδοποιημένο περιεχόμενο είναι σημαντικό.
- **Προεπισκοπήσεις αντικειμένων OLE:** Ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/oleobjectframe/) μπορεί να εκθέτει μια προεπισκόπηση εικόνας μέσω του `substitute_picture_format`, αλλά αυτή η εικόνα είναι μόνο η προεπισκόπηση της διαφάνειας. Δεν είναι το ενσωματωμένο αρχείο μέσα στο αντικείμενο OLE.
- **Μικρογραφίες πλαισίων βίντεο:** Ένα [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) μπορεί να εκθέτει μια προεπισκόπηση εικόνας μέσω του `picture_format`, αλλά αυτή η εικόνα είναι μόνο η αφίσα που εμφανίζεται στη διαφάνεια. Δεν εξάγεται από τη ροή του βίντεο.
- **Μικρογραφίες πλαισίων ήχου:** Ένα [AudioFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/) μπορεί να εκθέτει ένα εικονίδιο ή μικρογραφία μέσω του `picture_format`; δεν είναι τα ενσωματωμένα δεδομένα ήχου.
- **Εικόνες ζουμ:** Τα σχήματα ζουμ διαφάνειας, τμήματος και σύνοψης μπορούν να χρησιμοποιούν προσαρμοσμένα αντικείμενα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) μέσω του `image`.
- **Ντετερμισμένα μοντέλα σχήματος:** Τα αντικείμενα πίνακα, γραφήματος και SmartArt υλοποιούν το [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/), αλλά οι εικόνες τους συχνά αποθηκεύονται σε ενσωματωμένα αντικείμενα μορφοποίησης κελιών πίνακα, στοιχείων γραφήματος ή κόμβων SmartArt.
- **Κομμένες ή μετασχηματισμένες εικόνες:** Η πρόσβαση στο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) σας παρέχει τον αποθηκευμένο πόρο εικόνας. Δεν αποδίδει περικοπές, διαφάνεια, επαναχρωματισμό, περιστροφή ή άλλες οπτικές επιδράσεις που εφαρμόζονται από το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξαγάγω την αρχική εικόνα χωρίς περικοπές, εφέ ή μετασχηματισμούς σχήματος;**

Ναι. Πρόσβαση στο αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) και γράψτε την ιδιότητα `binary_data` στο δίσκο. Αυτό διατηρεί την αρχική κωδικοποιημένη εικόνα που αποθηκεύεται στην παρουσίαση, όχι τον τρόπο με τον οποίο η εικόνα αποδίδεται στη διαφάνεια.

**Μπορώ να εξάγω κάθε εξαγόμενη εικόνα ως PNG;**

Ναι. Χρησιμοποιήστε την ιδιότητα `image` του [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) για να λάβετε ένα αντικείμενο εικόνας και, στη συνέχεια, καλέστε `save` με το [ImageFormat.PNG](https://reference.aspose.com/slides/el/python-net/aspose.slides/imageformat/). Αυτό μετατρέπει την έξοδο και μπορεί να μην διατηρήσει τον αρχικό τύπο αρχείου ή τα διανυσματικά δεδομένα.

**Πώς αποφεύγω να αποθηκεύσω την ίδια εικόνα περισσότερες από μία φορές;**

Χρησιμοποιήστε ένα hash της ιδιότητας `binary_data` του [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) και διατηρήστε τα hash σε ένα σύνολο. Αν μια νέα εικόνα έχει hash που υπάρχει ήδη, παραλείψτε την ή καταγράψτε άλλη αναφορά στο υπάρχον αρχείο εξόδου.

**Γιατί ορισμένα σχήματα δεν παράγουν εικόνα;**

Τα πλαίσια εικόνας, τα σχήματα με γεμιστική εικόνα, τα πλαίσια αντικειμένων OLE, τα πλαίσια πολυμέσων, τα πλαίσια ζουμ, οι πίνακες, τα γραφήματα και τα αντικείμενα SmartArt μπορούν να αναφέρονται σε εικόνες. Ορισμένοι τύποι σχήματος εκθέτουν εικόνες μέσω ενσωματωμένων αντικειμένων μορφοποίησης, οπότε ένας απλός έλεγχος `picture_format` ή `fill_format` του σχήματος δεν είναι πάντα επαρκής.

**Μπορώ να εξαγάγω τη μικρογραφία που εμφανίζεται για ένα πλαίσιο βίντεο;**

Ναι. Χρησιμοποιήστε το [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) και διαβάστε το `picture_format.picture.image`. Αυτό εξάγει την αφίσα που αποθηκεύεται με το πλαίσιο βίντεο, όχι ένα καρέ που παράγεται από το αρχείο βίντεο.

**Πώς μπορώ να καθορίσω ποια σχήματα χρησιμοποιούν μια συγκεκριμένη εικόνα από τη συλλογή εικόνων της παρουσίασης;**

Το Aspose.Slides δεν αποθηκεύει αντίστροφους συνδέσμους από το [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προς τα σχήματα. Κατασκευάστε έναν χάρτη κατά τη διαδρομή: κάθε φορά που βρίσκετε μια αναφορά εικόνας, καταγράψτε τον αριθμό της διαφάνειας, τη διαδρομή του σχήματος και το hash ή το στοιχείο της συλλογής.

**Μπορώ να εξαγάγω εικόνες ενσωματωμένες μέσα σε αντικείμενα OLE, όπως συνημμένα έγγραφα;**

Μπορείτε να εξαγάγετε την προεπισκόπηση της διαφάνειας του αντικειμένου OLE από την ιδιότητα `substitute_picture_format` του [OleObjectFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/oleobjectframe/). Ωστόσο, αυτή η προεπισκόπηση δεν είναι το ενσωματωμένο έγγραφο αυτό καθαυτό. Για να εξαγάγετε εικόνες από μέσα στο ενσωματωμένο αρχείο, εξαγάγετε τα δεδομένα OLE και εξετάστε τα με εργαλεία κατάλληλα για τον τύπο αρχείου.