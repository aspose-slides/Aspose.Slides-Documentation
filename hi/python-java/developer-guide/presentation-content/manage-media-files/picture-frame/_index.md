---
title: Python का उपयोग करके प्रस्तुतियों में चित्र फ्रेम प्रबंधित करें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/python-java/picture-frame/
keywords:
- चित्र फ्रेम
- चित्र फ्रेम जोड़ें
- चित्र फ्रेम बनाएं
- एंबेडेड छवि
- लिंक्ड छवि
- छवि निकालें
- रास्टर छवि
- SVG छवि
- छवि क्रॉप करें
- क्रॉप किए गए क्षेत्रों को हटाएँ
- छवि संपीडित करें
- StretchOffset
- चित्र फ्रेम फ़ॉर्मेटिंग
- रिलेटिव स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुतियों में चित्र फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संपीड़ित करें।"
---
## **समीक्षा**

एक picture frame वह slide shape है जो एक image प्रदर्शित करता है। Aspose.Slides में, image resource और उसे प्रदर्शित करने वाला shape अलग‑अलग objects होते हैं: एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/) के माध्यम से एम्बेडेड image resources को धारण करता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) image की स्थिति, आकार, line formatting, rotation, cropping, picture effects और अन्य frame‑level सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब एक ही image को कई बार दिखाना हो। image को presentation में एक बार जोड़ें, लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) को रखें, और picture frames बनाते समय उसी image resource का उपयोग करें।

Picture frames raster images जैसे PNG या JPEG तथा vector SVG images को भी रख सकते हैं। वे लिंक्ड images की ओर भी इशारा कर सकते हैं, जिससे image बाइट्स को presentation में संग्रहीत करने की आवश्यकता नहीं रहती। यह चयन portability, फ़ाइल आकार, extraction और export व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या ऑप्टिमाइज़ेशन करने से पहले यह तय करना उपयोगी है कि image कैसे संग्रहीत की जानी चाहिए।

## **एक Embedded Image जोड़ें और फ़ॉर्मेट करें**

एक एम्बेडेड image के लिए, image डेटा को presentation में जोड़ें और [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addPictureFrame) के साथ एक picture frame बनाएँ। image presentation पैकेज का हिस्सा बन जाता है, इसलिए presentation को किसी अन्य कंप्यूटर पर ले जाने पर भी यह self‑contained रहता है।

निम्न उदाहरण एक JPEG image जोड़ता है, image के मूल आयामों पर एक फ्रेम बनाता है, और line formatting एवं rotation लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

picture frame प्रदर्शित geometry को नियंत्रित करता है; फ़्रेम का आकार बदलने से एम्बेडेड image resource में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में image को crop या compress करने पर महत्वपूर्ण हो जाता है।

## **Relative Scale का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) फ्रेम के लिए relative width और height scaling को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) तथा [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) के माध्यम से उजागर करता है। `1.0` का मान मूल picture आकार का 100 % दर्शाता है। Relative scale तब उपयोगी होता है जब workflow को source image के आकार के साथ एक संबंध बनाए रखना हो, न कि अंतिम आयामों की मैन्युअल गणना करनी पड़े।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Relative scale फ्रेम की scale सेटिंग्स बदलता है; यह एम्बेडेड image को resample या compress नहीं करता।

## **Embedded और Linked Images**

एक एम्बेडेड picture image डेटा को presentation के भीतर संग्रहीत करता है और इसलिए portability और पूर्वानुमानित रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक linked picture [Picture.setLinkPathLong](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#setLinkPathLong) मेथड के माध्यम से बाहरी स्थान को संदर्भित करता है, न कि image डेटा को उसी तरह embed करता है।

Linked images PPTX में संग्रहीत image डेटा की मात्रा को कम कर सकते हैं, लेकिन वे एक बाहरी निर्भरता पेश करते हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन के लिए सुलभ रहना चाहिए जो presentation खोलता या रेंडर करता है। यदि path बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन उपलब्ध नहीं रहता, तो linked picture उम्मीद के अनुसार नहीं दिखेगा। उन presentations के लिए जो ई‑मेल किए जाने, आर्काइव किए जाने या अलग‑थलग वातावरण में रेंडर किए जाने हैं, एम्बेडेड images आमतौर पर अधिक भरोसेमंद होते हैं।

### **एक Linked Image जोड़ें**

निम्न उदाहरण एक picture frame बनाता है और उसे स्थानीय image फ़ाइल की ओर इंगित करता है। यह केवल image लिंकिंग को दिखाता है; video लिंकिंग एक अलग media workflow है और जानबूझकर इस उदाहरण में मिश्रित नहीं किया गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

बाहरी फ़ाइल प्रबंधन इरादतन होने पर लिंक का उपयोग करें। उन्हें केवल compression के विकल्प के रूप में उपयोग न करें: एक छोटा PPTX जिसमें टूटे हुए image निर्भरताएँ हैं, आमतौर पर बड़े self‑contained presentation से कम उपयोगी होता है।

## **Picture Frames से Images निकालें**

किसी मौजूदा presentation से image निकालने से पहले, सत्यापित करें कि shape वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) है और उसमें एम्बेडेड image मौजूद है। Linked picture frames में वह image बाइट्स नहीं हो सकते जिन्हें समान तरीके से निकाला जा सके।

### **एक Raster Image निकालें**

आधुनिक image API सीधे raster images के साथ काम करता है और पुराने Java image wrapper की आवश्यकता नहीं होती। निम्न उदाहरण स्लाइड पर पहला एम्बेडेड raster picture खोजता है और उसे PNG के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

raster image को सहेजना निकाली गई image को अनुरोधित आउटपुट फ़ॉर्मेट में परिवर्तित करता है। यदि आपको presentation में संग्रहीत encoded बाइट्स चाहिए, न कि परिवर्तित raster फ़ाइल, तो image resource के binary data का उपयोग करें।

### **एक SVG Image निकालें**

एक SVG picture के लिए, [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) ऑब्जेक्ट को उजागर करता है। यह आपको SVG डेटा को सीधे प्राप्त करने की अनुमति देता है, बजाय पहले picture को rasterize किए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

SVG सामग्री को SVG के रूप में रखना presentation के भीतर vector source को संरक्षित करता है। PNG या JPEG जैसे raster एक्सपोर्ट्स इस vector सामग्री को पिक्सेल में रेंडर करते हैं। PDF या SVG slide export भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यात किए गए ग्राफिक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी न समझें; जब मूल vector संसाधन स्वयं आवश्यक हो तो एम्बेडेड [SvgImage.getSvgData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/#getSvgData) डेटा का उपयोग करें।

## **एक Image को Crop करें**

Cropping फ्रेम के भीतर image के कौन से हिस्से दिखेंगे, इसे बदलता है। [PictureFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/) पर crop मान source image के आयामों के प्रतिशत होते हैं। Cropping प्रारंभ में एम्बेडेड image से छिपे पिक्सेल को हटाता नहीं है; यह केवल दृश्यमान क्षेत्र को बदलता है।

निम्न उदाहरण सुरक्षित रूप से एक picture frame खोजता है और crop मान लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

क्योंकि छिपा हुआ image डेटा अभी भी मौजूद है, crop को बाद में बदला जा सकता है बिना मूल पिक्सेल खोए। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनः‑संपादन की आवश्यकता नहीं है, तो अगले अनुभाग में वर्णित अनुसार cropped क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **Cropped Image Data हटाएँ**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) वर्तमान crop rectangle के बाहर के image डेटा को हटाता है और परिणामी image resource को लौटाता है। यह फ़ाइल आकार को घटा सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: presentation सेव होने के बाद हटाए गए पिक्सेल बाद के uncrop ऑपरेशन के लिए उपलब्ध नहीं रहते।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह मेथड presentation में एक नया image resource जोड़ सकता है। यदि मूल image को अन्य picture frames भी उपयोग कर रहे हैं, तो उन फ्रेमों को अभी भी अपना मौजूदा resource चाहिए, इसलिए cropped क्षेत्रों को हटाने से कुल images की संख्या अनिवार्य रूप से नहीं घटती। इस मेथड के साथ WMF या EMF सामग्री को crop करने से परिणाम PNG में rasterized हो जाता है।

## **Raster Images को Compress करें**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#compressImage) raster image की रिज़ॉल्यूशन को उस आकार के सापेक्ष घटाता है जिस पर picture प्रदर्शित हो रहा है। यह एक ही ऑपरेशन में cropped क्षेत्रों को भी हटा सकता है। मेथड तब `True` लौटाता है जब image को resized या cropped किया गया हो और `False` जब कोई परिवर्तन आवश्यक न हो।

जब एक मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तो एक पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturescompression/) मान का उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यदि कोई विशिष्ट लक्ष्य आवश्यक हो, तो पूर्वनिर्धारित मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

Compression raster images के लिए अभिप्रेत है। SVG और metafile सामग्री इस raster compression workflow द्वारा नहीं घटाई जाती। साथ ही याद रखें कि कम रिज़ॉल्यूशन और हटाए गए cropped क्षेत्रों को अनऑप्टिमाइज़्ड प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर image वास्तव में देखी या निर्यात की जाएगी, न कि वैश्विक रूप से सबसे कम DPI लागू करके।

## **Image Transform Effects को Manage करें**

पूर्ण workflow जो brightness, contrast, color transformations, blur, alpha effects, ordered chains, inspection, removal, और round‑trip verification को कवर करता है, उसके लिए देखें [Image Transform Effects](/slides/hi/python-java/image-transform-effects/)।

## **Picture Frame Geometry को Lock करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframelock/) सेटिंग्स यह निर्धारित करती हैं कि picture frame के लिए कौन‑सी editing operations अक्षम हैं। उदाहरण के लिए, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) shape के आकार को बदलते समय उसके अनुपात को संरक्षित रखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

लॉक picture frame shape पर लागू होता है। यह स्रोत image को resample या स्थायी रूप से समान aspect ratio में बदलता नहीं है।

## **StretchOffset मानों को समायोजित करें**

जब picture fill mode stretch हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/) पर stretch‑offset मान picture frame के bounding box के सापेक्ष fill rectangle को परिभाषित करते हैं। सकारात्मक प्रतिशत एक किनारे से inset बनाते हैं, जबकि नकारात्मक प्रतिशत एक outset बनाते हैं।

यह cropping से अलग है। Crop मान निर्धारित करते हैं कि source image का कौन‑सा हिस्सा दृश्यमान है; stretch offsets वह rectangle बदलते हैं जिसमें visible picture fill को stretch किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

fill placement के लिए stretch offsets का उपयोग करें। जब लक्ष्य source‑image किनारों को छिपाना हो, तो crop properties का उपयोग करें।

## **Storage, फ़ाइल आकार, और Export पर विचार**

जब image storage और picture‑frame फ़ॉर्मेटिंग को अलग‑अलग माना जाता है, तो मुख्य trade‑offs अधिक स्पष्ट हो जाते हैं:

- **Embedded images** presentation को self‑contained बनाते हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिए सबसे भरोसेमंद होते हैं, लेकिन बड़े raster images PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन presentation को बाहरी फ़ाइलों पर निर्भर रहना पड़ता है जो निर्दिष्ट पाथ या स्थानों पर उपलब्ध रहें।
- **Cropping** प्रारंभ में non‑destructive होता है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक cropped क्षेत्रों को स्पष्ट रूप से हटाया न जाए या compression के दौरान हटा न दिया जाए।
- **Compression** बड़े raster images के फ़ाइल आकार को काफी घटा सकता है, लेकिन यह source resolution के बलिदान के साथ आता है। इसे स्लाइड पर अंतिम आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG images** को तब SVG के रूप में रखना चाहिए जब vector संरक्षण महत्वपूर्ण हो। जब आपको स्वयं vector संसाधन चाहिए, तो एम्बेडेड SVG को सीधे निकालें। Raster slide export हमेशा rendered slide को पिक्सेल में परिवर्तित करता है।
- **Repeated images** को संभव हो तो मौजूदा [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) resource को पुनः उपयोग करना चाहिए, न कि एक ही फ़ाइल को कई बार presentation workflow में लोड करना।

बड़ी presentations के लिए, image optimization आमतौर पर चयनात्मक रूप से सबसे प्रभावी होती है: लोगो और डायाग्राम को vector सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक प्रदर्शन आकार के अनुसार compress करें, केवल तब cropped पिक्सेल हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक तभी रखें जब निर्भरता प्रबंधन deployment डिजाइन का हिस्सा हो।

## **FAQ**

**एक picture frame और एक image resource में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) वह image resource है जो presentation से जुड़ा होता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) स्लाइड पर वह shape है जो image प्रदर्शित करता है और फ्रेम‑स्तर की geometry व फ़ॉर्मेटिंग जैसे आकार, rotation, crop मान, effects, और locks को संग्रहीत करता है।

**मुझे images को embed करना चाहिए या link?**

जब presentation को portable, archived, या बाहरी संसाधनों के बिना रेंडर करना हो, तो images को embed करें। केवल तब images को link करें जब image फ़ाइलों को PPTX के बाहर रखने का इरादा हो और बाहरी स्थितियों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या cropping PPTX फ़ाइल आकार को घटाता है?**

स्वतः नहीं। सामान्य crop सेटिंग्स source image के भागों को छिपाती हैं लेकिन अंतर्निहित पिक्सेल को बनाए रखती हैं। जब उन पिक्सेल को स्थायी रूप से हटाया जा सके, तो [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) या cropped‑area हटाने के साथ image compression का उपयोग करें।

**क्या compression के बाद image गुणवत्ता को बहाल किया जा सकता है?**

नहीं। Compression संग्रहीत raster रिज़ॉल्यूशन को घटा देता है, और cropped क्षेत्रों को हटाने से image डेटा समाप्त हो जाता है। यदि बाद में हाई‑resolution संपादन की संभावना हो, तो मूल स्रोत image को presentation के बाहर रखें।

**SVG images को कैसे संभालना चाहिए?**

जब vector fidelity महत्वपूर्ण हो, तो SVG सामग्री को SVG ही रखें। एम्बेडेड [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे raster फ़ॉर्मेट में रेंडर करने से SVG को पिक्सेल में बदल दिया जाता है।

**मौजूदा slides को पढ़ते समय unsafe casts से कैसे बचें?**

shape type की जाँच करें इससे पहले कि picture‑frame‑विशिष्ट सदस्य उपयोग किए जाएँ। [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) के विरुद्ध `isinstance` जाँच करना invalid casts से बचाता है और कोड को उन slides को हैंडल करने की अनुमति देता है जिसमें picture frames नहीं होते।