---
title: Python के माध्यम से Java में प्रस्तुति आकारों से छवियाँ निकालें
linktitle: आकार से छवि
type: docs
weight: 100
url: /hi/python-java/extracting-images-from-presentation-shapes/
keywords:
- छवि निकालें
- छवि प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में आकारों से छवियों को निकालें - तेज, कोड‑मित्र समाधान."
---
## **समीक्षा**

प्रेजेंटेशन में छवियाँ कई आकार प्रकारों में दिखाई दे सकती हैं: सामान्य चित्र फ्रेम के रूप में, आकारों पर लागू चित्र भराव के रूप में, OLE ऑब्जेक्ट प्रीव्यू छवियों के रूप में, वीडियो या ऑडियो फ्रेम थंबनेल के रूप में, ज़ूम छवियों के रूप में, या तालिका, चार्ट और SmartArt आकारों के अंदर नेस्टेड छवियों के रूप में। Aspose.Slides इन छवियों को प्रेजेंटेशन इमेज कलेक्शन में संग्रहीत करता है, जिसे [ImageCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/) और [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट्स के माध्यम से एक्सपोज़ किया जाता है।

यदि आपको केवल प्रेजेंटेशन में एम्बेडेड प्रत्येक छवि संसाधन को निकास करने की आवश्यकता है, तो आप [Presentation.getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) को इटरेट कर सकते हैं। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड्स में छवियों के उपयोग को खोजने के लिए आकारों को ट्रैवर्स करना, ताकि सहेजी गई फ़ाइलें स्लाइड संख्या, आकार स्थिति और स्रोत प्रकार (चित्र फ्रेम, भराव छवि, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम छवि) जैसी उपयोगी संदर्भ को रख सकें।

{{% alert title="Tip" color="success" %}}
[PPImage.getBinaryData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getBinaryData) का उपयोग मूल एन्कोडेड छवि डेटा और फाइल प्रकार को संरक्षित करने के लिए करें। जब आप आउटपुट को PNG जैसे विशिष्ट फॉर्मेट में सामान्यीकृत करना चाहते हैं, तो `save` के साथ [PPImage.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getImage) का उपयोग करें।
{{% /alert %}}

## **साझा मददगार फ़ंक्शन**

नीचे दिए गए साझा मददगार फ़ंक्शन को `image_helpers.py` में उदाहरण स्क्रिप्ट के साथ सहेजें। ये उदाहरण को संक्षिप्त रखते हैं। `save_original_image` मूल एम्बेडेड बाइट्स को लिखता है, MIME प्रकार से एक सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट छवि बाइनरी को स्किप करता है।

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

## **चित्र फ्रेम से छवियों को निकालें**

यह दृष्टिकोण उन चित्रों के लिए उपयोग करें जो स्वतंत्र ऑब्जेक्ट के रूप में डाले गए हैं। एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) आपको अपनी चित्र तक पहुँच देता है via [getPictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#getPicture), और [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#getImage), जो एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट लौटाता है।

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

## **चित्र-भरे आकार से छवियों को निकालें**

आकार एक चित्र को अपने भराव के रूप में उपयोग कर सकते हैं। पहले आकार के भराव प्रकार को जांचें: यदि यह [FillType.Picture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) नहीं है, तो उस भराव से निकालने के लिए कोई चित्र नहीं है। नीचे का उदाहरण [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) ऑब्जेक्ट्स को संभालता है और प्रत्येक छवि को [PPImage.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getImage) के माध्यम से PNG के रूप में सहेजता है।

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

## **OLE ऑब्जेक्ट फ्रेम से प्रीव्यू छवियों को निकालें**

एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) के पास एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह छवि [getSubstitutePictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#getPicture), और [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#getImage) के माध्यम से उपलब्ध है। इस चित्र को निकालने से आपको प्रीव्यू छवि मिलती है, न कि एम्बेडेड OLE पैकेज की सामग्री।

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

## **वीडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) भी [getPictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#getPicture), और [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#getImage) के माध्यम से एक प्रीव्यू छवि संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पो스터 या थंबनेल है, न कि वीडियो स्ट्रीम से डिकोड किया गया फ्रेम।

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

## **ऑडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [AudioFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/) [getPictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#getPicture), और [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#getImage) के माध्यम से एक थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाया गया चित्र है।

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

## **ज़ूम ऑब्जेक्ट्स से छवियों को निकालें**

[ZoomFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomframe/) और [SectionZoomFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectionzoomframe/) आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से [getZoomImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomobject/#getZoomImage) पढ़ें।

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

## **समरी ज़ूम फ्रेम से छवियों को निकालें**

एक [SummaryZoomFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/summaryzoomframe/) भी एक आकार है। इसके सेक्शन आइटम कस्टम छवियों का उपयोग कर सकते हैं, जिसे प्रत्येक समरी ज़ूम सेक्शन की [getZoomImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomobject/#getZoomImage) मेथड के माध्यम से एक्सपोज़ किया जाता है।

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

## **टेबल आकारों से छवियों को निकालें**

एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) एक आकार है। तालिका में छवियाँ आमतौर पर तालिका कोशिकाओं में चित्र भराव के रूप में संग्रहीत रहती हैं।

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

## **चार्ट आकारों से छवियों को निकालें**

एक [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/) एक आकार है। नीचे का उदाहरण चार्ट एरिया के चित्र भराव से एक छवि निकालता है।

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

## **SmartArt आकारों से छवियों को निकालें**

एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट के आधार पर, छवियाँ नोड बुलेट भराव या नोड आकारों के भराव फॉर्मेट में संग्रहीत हो सकती हैं।

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

## **समूहित आकारों के अंदर छवियों को शामिल करें**

समूहित आकारों के अपने स्वयं के आकार संग्रह होते हैं। साझा `enumerate_shapes` हेल्पर में `include_grouped_shapes` विकल्प है। जब आप [GroupShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/groupshape/) ऑब्जेक्ट्स के अंदर आकार को निरीक्षण करना चाहते हैं, तो इसे `True` पर सेट करें। नीचे का उदाहरण चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल और ऑडियो फ्रेम थंबनेल से छवियों को निकालता है। तालिका, चार्ट, SmartArt और समरी ज़ूम छवियों को भी शामिल करने के लिए, पिछले अनुभागों की विशेषीकृत निष्कर्षण तर्क को पुन: उपयोग करें जबकि वही पुनरावर्ती आकार ट्रैवर्सल रखें।

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

## **एज केस और व्यावहारिक नोट्स**

- **डुप्लिकेट छवियाँ:** कई आकार एक ही छवि को संदर्भित कर सकते हैं या समान बाइट्स वाली अलग छवियाँ हो सकती हैं। यदि आप प्रत्येक अद्वितीय छवि के लिए एक आउटपुट फ़ाइल चाहते हैं तो फ़ाइल लिखने से पहले [PPImage.getBinaryData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getBinaryData) का हैश करें।
- **मूल डेटा बनाम परिवर्तित आउटपुट:** [PPImage.getBinaryData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getBinaryData) को सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा संरक्षित रहता है। `save` के साथ [PPImage.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getImage) को सहेजना उपयोगी है जब आप एक सुसंगत आउटपुट फ़ॉर्मेट चाहते हैं।
- **असमर्थित भराव प्रकार:** सॉलिड, ग्रेडिएंट, पैटर्न और नो-फ़िल आकार में चित्र भराव नहीं होता। पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) जांचें और फिर [getPictureFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getPictureFillFormat) को कॉल करें।
- **समूहित आकार:** शीर्ष-स्तर स्लाइड आकार संग्रह समूहों को फ्लैटन नहीं करता। जब समूहित कंटेंट मायने रखता है तो `[GroupShape.getShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/groupshape/#getShapes)` को पुनरावर्ती रूप से निरीक्षण करें।
- **OLE ऑब्जेक्ट प्रीव्यू:** एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) [getSubstitutePictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से एक प्रीव्यू छवि एक्सपोज़ कर सकता है, लेकिन वह केवल स्लाइड प्रीव्यू है। यह OLE ऑब्जेक्ट के भीतर एम्बेडेड फ़ाइल नहीं है।
- **वीडियो फ्रेम थंबनेल:** एक [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) [getPictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#getPictureFormat) के माध्यम से एक प्रीव्यू छवि एक्सपोज़ कर सकता है, लेकिन वह केवल स्लाइड पर दिखाया गया पोस्टर है। यह वीडियो स्ट्रीम से निकाली गई छवि नहीं है।
- **ऑडियो फ्रेम थंबनेल:** एक [AudioFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/) [getPictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#getPictureFormat) के माध्यम से एक आइकन या थंबनेल एक्सपोज़ कर सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **ज़ूम छवियाँ:** स्लाइड ज़ूम, सेक्शन ज़ूम और समरी ज़ूम आकार कस्टम [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट्स को [getZoomImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomobject/#getZoomImage) के माध्यम से उपयोग कर सकते हैं।
- **नेस्टेड आकार मॉडल:** तालिका, चार्ट और SmartArt ऑब्जेक्ट्स [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) को इम्प्लीमेंट करते हैं, लेकिन उनकी छवियाँ अक्सर नेस्टेड तालिका कोशिका, चार्ट एलिमेंट या SmartArt नोड फ़ॉर्मेटिंग ऑब्जेक्ट्स में संग्रहीत रहती हैं।
- **क्रॉप या ट्रांसफ़ॉर्म किए गए चित्र:** [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) तक पहुँचने से आपको संग्रहीत छवि संसाधन मिलता है। यह आकार द्वारा लागू क्रॉपिंग, ट्रांसपैरेंसी, री‑कलरिंग, रोटेशन या अन्य दृश्य प्रभावों को नहीं रेंडर करता।

## **FAQ**

**क्या मैं मूल छवि को बिना क्रॉपिंग, इफ़ेक्ट्स या आकार ट्रांसफ़ॉर्मेशन के निकाल सकता हूँ?**

हाँ। [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट तक पहुँचें और [PPImage.getBinaryData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getBinaryData) को डिस्क पर लिखें। इससे प्रेजेंटेशन में संग्रहीत मूल एन्कोडेड छवि संरक्षित रहती है, न कि स्लाइड पर रेंडर की गई छवि।

**क्या मैं निकाली गई प्रत्येक छवि को PNG के रूप में निर्यात कर सकता हूँ?**

हाँ। [PPImage.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getImage) का उपयोग करके एक इमेज ऑब्जेक्ट प्राप्त करें, और फिर `save` के साथ [ImageFormat.Png](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imageformat/) को कॉल करें। यह आउटपुट को कन्वर्ट करता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को संरक्षित नहीं रख सकता।

**मैं एक ही छवि को कई बार सहेजने से कैसे बचूँ?**

[PPImage.getBinaryData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getBinaryData) का हैश बनाएं और हैश को एक सेट में रखें। यदि नई छवि का हैश पहले से मौजूद है, तो उसे स्किप करें या मौजूदा आउटपुट फ़ाइल के लिए एक और रेफ़रेंस रिकॉर्ड करें।

**कुछ आकार छवि क्यों नहीं बनाते?**

चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, तालिका, चार्ट और SmartArt ऑब्जेक्ट छवियों को संदर्भित कर सकते हैं। कुछ आकार प्रकार नेस्टेड फ़ॉर्मेटिंग ऑब्जेक्ट्स के माध्यम से छवियों को एक्सपोज़ करते हैं, इसलिए केवल [getPictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#getPictureFormat) या आकार [getFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getFillFormat) को चेक करना हमेशा पर्याप्त नहीं होता।

**क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूँ?**

हाँ। [VideoFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoframe/) का उपयोग करें और [getPictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#getPicture) और [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#getImage) को पढ़ें। यह वीडियो फ्रेम के साथ संग्रहीत पोस्टर छवि को निकालता है, न कि वीडियो फ़ाइल से उत्पन्न फ्रेम।

**मैं कैसे निर्धारित करूँ कि कौन से आकार प्रेजेंटेशन इमेज कलेक्शन की विशिष्ट छवि का उपयोग करते हैं?**

Aspose.Slides के पास [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) से आकारों की रिवर्स लिंक नहीं होती। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप किसी छवि रेफ़रेंस को पाते हैं, स्लाइड संख्या, आकार पाथ और छवि हैश या कलेक्शन आइटम को रिकॉर्ड करें।

**क्या मैं OLE ऑब्जेक्ट के अंदर एम्बेडेड छवियों, जैसे संलग्न दस्तावेज़ों, को निकाल सकता हूँ?**

आप [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ स्वयं नहीं है। एम्बेडेड फ़ाइल से छवियों को निकालने के लिए, OLE डेटा को निकालें और उस फ़ाइल प्रकार के उपकरणों से उसका निरीक्षण करें।