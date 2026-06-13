---
title: Python में प्रस्तुति आकारों से चित्र निकालें
linktitle: आकार से चित्र
type: docs
weight: 90
url: /hi/python-net/extracting-images-from-presentation-shapes/
keywords:
- चित्र निकालें
- चित्र पुनः प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python द्वारा .NET के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों में आकारों से चित्र निकालें - तेज, कोड-अनुकूल समाधान।"
---
## **अवलोकन**

प्रेजेंटेशन में चित्र कई प्रकार के आकारों में दिखाई दे सकते हैं: सामान्य चित्र फ़्रेम के रूप में, आकारों पर लागू चित्र फ़िल्स के रूप में, OLE ऑब्जेक्ट प्रीव्यू चित्रों के रूप में, वीडियो या ऑडियो फ्रेम थंबनेल के रूप में, ज़ूम चित्रों के रूप में, या तालिका, चार्ट और SmartArt आकारों के भीतर नेस्टेड चित्रों के रूप में। Aspose.Slides इन चित्रों को प्रेजेंटेशन इमेज कलेक्शन में संग्रहीत करता है, जिसे [ImageCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/) और [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट्स के माध्यम से एक्सपोज़ किया जाता है।

यदि आपको केवल प्रेजेंटेशन में एम्बेडेड सभी चित्र संसाधनों को निर्यात करना है, तो `presentation.images` पर इटेरेट करें। यह लेख एक अलग कार्य पर केंद्रित है: आकारों को ट्रैवर्स करना ताकि यह पता लगाया जा सके कि स्लाइड्स पर चित्र कहां उपयोग किए गए हैं, जिससे सहेजे गए फ़ाइलें स्लाइड नंबर, आकार की स्थिति, और स्रोत प्रकार (चित्र फ़्रेम, फ़िल इमेज, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम इमेज) जैसी उपयोगी संदर्भ को रख सकें।

{{% alert title="Tip" color="primary" %}}

Use the `binary_data` property of [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) to preserve the original encoded image data and file type. Use the `image` property with `save` when you want to normalize the output to a specific format such as PNG.

{{% /alert %}}

## **साझा सहायक विधियाँ**

नीचे दिए गए सहायक मेथड्स उदाहरणों को संक्षिप्त रखते हैं। `save_original_image` मूल एम्बेडेड बाइट्स लिखता है, MIME प्रकार से सुरक्षित एक्सटेन्शन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट इमेज बाइनरी को स्किप करता है।

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

## **चित्र फ़्रेम से चित्र निकालें**

इस दृष्टिकोण का उपयोग उन चित्रों के लिए करें जो स्वतंत्र ऑब्जेक्ट के रूप में डाले गए हों। एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) अपनी चित्र को `picture_format.picture.image` में संग्रहीत करता है, जो एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट लौटाता है।

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

## **चित्र‑भरे आकारों से चित्र निकालें**

आकार चित्र को अपनी फ़िल के रूप में उपयोग कर सकते हैं। पहले आकार के फ़िल प्रकार की जाँच करें: यदि वह [FillType.PICTURE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) नहीं है, तो उस फ़िल से निकाला जाने वाला कोई चित्र नहीं है। नीचे दिया गया उदाहरण [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) ऑब्जेक्ट्स को संभालता है और प्रत्येक चित्र को PNG के रूप में `image` प्रॉपर्टी के माध्यम से [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) से सहेजता है।

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

## **OLE ऑब्जेक्ट फ़्रेम से प्रीव्यू चित्र निकालें**

एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) में एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह चित्र `substitute_picture_format.picture.image` के माध्यम से उपलब्ध है। इस चित्र को निकालने पर आपको प्रीव्यू चित्र मिलेगा, न कि एम्बेडेड OLE पैकेज सामग्री।

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

## **वीडियो फ़्रेम से प्रीव्यू चित्र निकालें**

एक [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) भी `picture_format.picture.image` में प्रीव्यू चित्र संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, न कि वीडियो स्ट्रीम से डिकोड किया गया कोई फ्रेम।

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

## **ऑडियो फ़्रेम से प्रीव्यू चित्र निकालें**

एक [AudioFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/) `picture_format.picture.image` में थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाया गया चित्र है।

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

## **ज़ूम ऑब्जेक्ट्स से चित्र निकालें**

[ZoomFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/zoomframe/) और [SectionZoomFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectionzoomframe/) आकार कस्टम चित्रों का उपयोग कर सकते हैं। ज़ूम फ़्रेम से `zoom_image` पढ़ें।

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

## **समरी ज़ूम फ़्रेम्स से चित्र निकालें**

[SummaryZoomFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/summaryzoomframe/) भी एक आकार है। उसके सेक्शन आइटम कस्टम चित्रों का उपयोग कर सकते हैं, जो प्रत्येक समरी ज़ूम सेक्शन की `zoom_image` प्रॉपर्टी के माध्यम से एक्सपोज़ किए जाते हैं।

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

## **टेबल आकारों से चित्र निकालें**

[Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) एक आकार है। टेबल में चित्र आमतौर पर टेबल सेल्स में चित्र फ़िल के रूप में संग्रहीत होते हैं।

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

## **चार्ट आकारों से चित्र निकालें**

[Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/) एक आकार है। नीचे दिया गया उदाहरण चार्ट एरिया के चित्र फ़िल से एक चित्र निकालता है।

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

## **SmartArt आकारों से चित्र निकालें**

[SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट पर निर्भर करता है, चित्र नोड बुलेट फ़िल में या नोड आकारों के फ़िल फ़ॉर्मैट में संग्रहीत हो सकते हैं।

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

## **समूहित आकारों के भीतर चित्र शामिल करें**

समूहित आकार अपने स्वयं के आकार संग्रह रखते हैं। साझा `enumerate_shapes` सहायक में `include_grouped_shapes` विकल्प है। जब आप [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/) ऑब्जेक्ट्स के भीतर के आकारों की जाँच करना चाहते हैं, तो इसे `True` सेट करें। नीचे दिया गया उदाहरण चित्र फ्रेम, चित्र‑भरे आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल, और ऑडियो फ्रेम थंबनेल से चित्र निकालता है। तालिका, चार्ट, SmartArt, और समरी ज़ूम चित्रों को भी शामिल करने के लिए, पिछले अनुभागों की विशेषीकृत निष्कर्षण लॉजिक को पुनः उपयोग करें जबकि समान पुनरावर्ती आकार ट्रैवर्सल बनाए रखें।

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

## **एज केस और व्यावहारिक नोट्स**

- **डुप्लिकेट चित्र:** कई आकार एक ही चित्र या समान बाइट्स वाले अलग-अलग चित्रों का उल्लेख कर सकते हैं। यदि आप प्रत्येक अनन्य चित्र के लिए एक आउटपुट फ़ाइल चाहते हैं, तो फ़ाइल लिखने से पहले [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) की `binary_data` प्रॉपर्टी का हैश बनाएं।

- **मूल डेटा बनाम परिवर्तित आउटपुट:** `binary_data` प्रॉपर्टी को सहेजने से [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) में एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा संरक्षित रहता है। `save` के माध्यम से `image` प्रॉपर्टी को सहेजना तब उपयोगी है जब आप एक समान आउटपुट फ़ॉर्मेट चाहते हैं।

- **असमर्थित फ़िल प्रकार:** सॉलिड, ग्रेडिएंट, पैटर्न, और नो‑फ़िल आकारों में चित्र फ़िल नहीं होता। `picture_fill_format` पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) जांचें।

- **समूहित आकार:** टॉप‑लेवल स्लाइड आकार संग्रह समूहों को फ्लैट नहीं करता। जब समूहित सामग्री महत्वपूर्ण हो, तो [GroupShape.shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/shapes/) को पुनरावर्ती रूप से निरीक्षण करें।

- **OLE ऑब्जेक्ट प्रीव्यू:** [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) `substitute_picture_format` के माध्यम से प्रीव्यू चित्र दिखा सकता है, लेकिन वह चित्र केवल स्लाइड प्रीव्यू है। यह OLE ऑब्जेक्ट के अंदर एम्बेडेड फ़ाइल नहीं है।

- **वीडियो फ़्रेम थंबनेल:** [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) `picture_format` के माध्यम से प्रीव्यू चित्र दिखा सकता है, लेकिन वह चित्र केवल स्लाइड पर दिखाई देने वाला पोस्टर है। यह वीडियो स्ट्रीम से निकाला नहीं गया है।

- **ऑडियो फ़्रेम थंबनेल:** [AudioFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/) `picture_format` के माध्यम से एक आइकन या थंबनेल दिखा सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।

- **ज़ूम चित्र:** स्लाइड ज़ूम, सेक्शन ज़ूम, और समरी ज़ूम आकार कस्टम [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट्स को `image` के माध्यम से उपयोग कर सकते हैं।

- **नेस्टेड आकार मॉडल:** [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/), [Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides/charts/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/) ऑब्जेक्ट्स [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) को इम्प्लीमेंट करते हैं, लेकिन उनके चित्र अक्सर नेस्टेड टेबल सेल, चार्ट एलीमेंट, या SmartArt नोड फ़ॉर्मेटिंग ऑब्जेक्ट्स में संग्रहीत होते हैं।

- **कटे या परिवर्तित चित्र:** [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) तक पहुँचने से आपको संग्रहीत चित्र संसाधन मिलता है। यह आकार द्वारा लागू कटिंग, ट्रांसपैरेंसी, रीकलरिंग, रोटेशन, या अन्य दृश्य प्रभावों को रेंडर नहीं करता।

## **FAQ**

**क्या मैं मूल चित्र को बिना क्रॉपिंग, इफ़ेक्ट्स या आकार ट्रांसफ़ॉर्मेशन के निकाल सकता हूँ?**

हाँ। [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट को एक्सेस करें और उसकी `binary_data` प्रॉपर्टी को डिस्क पर लिखें। यह प्रेजेंटेशन में संग्रहीत मूल एन्कोडेड चित्र को संरक्षित रखता है, न कि स्लाइड पर चित्र के रेंडर किए जाने के तरीके को।

**क्या मैं प्रत्येक निकाले गए चित्र को PNG के रूप में निर्यात कर सकता हूँ?**

हाँ। [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) की `image` प्रॉपर्टी का उपयोग करके एक चित्र ऑब्जेक्ट प्राप्त करें, फिर [ImageFormat.PNG](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imageformat/) के साथ `save` कॉल करें। यह आउटपुट को बदलता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को संरक्षित नहीं रख सकता।

**मैं एक ही चित्र को एक से अधिक बार सहेजने से कैसे बचूँ?**

[PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) की `binary_data` प्रॉपर्टी का हैश उपयोग करें और हैश को एक सेट में रखें। यदि नया चित्र का हैश पहले से मौजूद है, तो उसे स्किप करें या मौजूदा आउटपुट फ़ाइल का एक और रेफ़रेंस दर्ज करें।

**क्यों कुछ आकार चित्र नहीं उत्पन्न करते?**

चित्र फ़्रेम, चित्र‑भरे आकार, OLE ऑब्जेक्ट फ़्रेम, मीडिया फ़्रेम, ज़ूम फ़्रेम, टेबल, चार्ट, और SmartArt ऑब्जेक्ट्स चित्रों का संदर्भ दे सकते हैं। कुछ आकार प्रकार चित्रों को नेस्टेड फ़ॉर्मैटिंग ऑब्जेक्ट्स के माध्यम से उजागर करते हैं, इसलिए एक साधारण `picture_format` या आकार `fill_format` जांच हमेशा पर्याप्त नहीं होती।

**क्या मैं वीडियो फ़्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूँ?**

हाँ। [VideoFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/videoframe/) का उपयोग करें और `picture_format.picture.image` पढ़ें। यह वीडियो फ़्रेम के साथ संग्रहीत पोस्टर चित्र निकालता है, न कि वीडियो फ़ाइल से उत्पन्न कोई फ्रेम।

**मैं कैसे निर्धारित करूँ कि प्रेजेंटेशन इमेज कलेक्शन में से कौन से आकार किसी विशेष चित्र का उपयोग करते हैं?**

Aspose.Slides [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) से आकारों तक रिवर्स लिंक नहीं संग्रहीत करता। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप एक चित्र संदर्भ पाते हैं, स्लाइड नंबर, आकार पाथ, और चित्र का हैश या कलेक्शन आइटम रिकॉर्ड करें।

**क्या मैं OLE ऑब्जेक्ट्स के भीतर एम्बेडेड चित्र, जैसे संलग्न दस्तावेज़, निकाल सकता हूँ?**

आप [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) की `substitute_picture_format` प्रॉपर्टी से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ नहीं है। एम्बेडेड फ़ाइल के भीतर से चित्र निकालने के लिए, OLE डेटा निकालें और उस फ़ाइल प्रकार के टूल्स से उसका निरीक्षण करें।