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
- क्रॉप्ड क्षेत्रों को हटाएँ
- छवि संपीड़ित करें
- StretchOffset
- चित्र फ्रेम स्वरूपण
- रिलेटिव स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके प्रस्तुतियों में चित्र फ्रेम बनाएं, स्वरूपित करें, लिंक करें, क्रॉप करें, निकालें और संपीड़ित करें।"
---
## **आवलोकन**

एक चित्र फ्रेम एक स्लाइड आकार है जो एक छवि प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और उसे प्रदर्शित करने वाला आकार अलग-अलग वस्तुएँ हैं: एक [प्रस्तुति](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) अपनी अंतर्निहित छवि संसाधनों का स्वामित्व अपनी [ImageCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/) के माध्यम से रखता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) छवि की स्थिति, आकार, रेखा स्वरूपण, घूर्णन, क्रॉपिंग, चित्र प्रभाव और अन्य फ्रेम‑स्तर सेटिंग्स को नियंत्रित करता है।

जब एक ही छवि को एक से अधिक बार दिखाया जाता है, तब यह विभाजन उपयोगी होता है। छवि को प्रस्तुति में एक बार जोड़ें, लौटाई गई [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) को रखें, और चित्र फ्रेम बनाते समय उसी छवि संसाधन का उपयोग करें।

चित्र फ्रेम रास्टर छवियों जैसे PNG या JPEG तथा वेक्टर SVG छवियों को समाहित कर सकते हैं। वे प्रस्तुति में छवि बाइट्स संग्रहीत करने के बजाय लिंक की गई छवियों के भी उल्लेख कर सकते हैं। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए स्वरूपण या अनुकूलन लागू करने से पहले यह तय करना उपयोगी है कि छवि कैसे संग्रहीत की जानी चाहिए।

## **एंबेडेड इमेज जोड़ें और स्वरूपित करें**

एक एंबेडेड छवि के लिए, छवि डेटा को प्रस्तुति में जोड़ें और [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addPictureFrame) के साथ एक चित्र फ्रेम बनाएं। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को दूसरे कंप्यूटर पर ले जाने पर भी वह स्व-समाहित रहती है।

निम्न उदाहरण JPEG छवि जोड़ता है, छवि के मूल आयामों पर एक फ्रेम बनाता है, और रेखा स्वरूपण एवं घूर्णन लागू करता है:

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

चित्र फ्रेम प्रदर्शित ज्यामिति को नियंत्रित करता है; फ्रेम आकार बदलने से एंबेडेड छवि संसाधन में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में छवि को क्रॉप या संकुचित करने पर महत्वपूर्ण होता है।

## **रिलेटिव स्केल का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) फ्रेम के लिए रिलेटिव चौड़ाई और ऊँचाई स्केलिंग को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) के माध्यम से उजागर करता है। मान `1.0` मूल चित्र आकार का 100 % दर्शाता है। रिलेटिव स्केल तब उपयोगी होता है जब वर्कफ़्लो को स्रोत छवि के आकार के साथ संबंध बनाए रखना हो बजाय अंतिम आयामों की मैन्युअल गणना के।

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

रिलेटिव स्केल फ्रेम के स्केल सेटिंग्स को बदलता है; यह एंबेडेड छवि को पुन:सैंपल या संकुचित नहीं करता।

## **एंबेडेड और लिंक्ड इमेजेज**

एंबेडेड चित्र छवि डेटा को प्रस्तुति के भीतर संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमेय रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। लिंक्ड चित्र [Picture.setLinkPathLong](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#setLinkPathLong) मेथड के माध्यम से बाहरी स्थान को संग्रहीत करता है, न कि उसी तरह छवि डेटा को एंबेड करके।

लिंक्ड छवियां PPTX में संग्रहीत छवि डेटा की मात्रा को कम कर सकती हैं, लेकिन वे एक बाहरी निर्भरता प्रस्तुत करती हैं। लिंक्ड फ़ाइल को उस अनुप्रयोग द्वारा सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पाथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन अनुपलब्ध हो जाता है, तो लिंक्ड चित्र अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जो ई‑मेल, अभिलेख, या अलग‑थलग वातावरण में रेंडर की जानी हों, एंबेडेड छवियां आमतौर पर अधिक भरोसेमंद होती हैं।

### **लिंक्ड इमेज जोड़ें**

निम्न उदाहरण एक चित्र फ्रेम बनाता है और उसे स्थानीय छवि फ़ाइल की ओर संकेत करता है। यह केवल छवि लिंकिंग से निपटता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और जानबूझकर इस उदाहरण में मिश्रित नहीं किया गया है।

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

जब बाहरी फ़ाइल प्रबंधन इरादतन हो तब लिंक का उपयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में उपयोग न करें: टूटा हुआ इमेज डिपेंडेंसी वाला छोटा PPTX आमतौर पर बड़े स्व‑समाहित प्रस्तुति से कम उपयोगी होता है।

## **चित्र फ्रेम से छवियों को निकालें**

किसी मौजूदा प्रस्तुति से छवि निकालने से पहले, जांचें कि आकार वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) है और उसमें एंबेडेड छवि मौजूद है। लिंक्ड चित्र फ्रेम में वह छवि बाइट्स नहीं हो सकते जिन्हें समान तरीके से निकाला जा सके।

### **रास्टर इमेज निकालें**

आधुनिक इमेज API रास्टर छवियों के साथ सीधे काम करता है और पुराने जावा इमेज रैपर की आवश्यकता नहीं होती। निम्न उदाहरण स्लाइड पर पहली एंबेडेड रास्टर चित्र को खोजता है और उसे PNG के रूप में सहेजता है:

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

रास्टर छवि को सहेजने से निकाली गई छवि अनुरोधित आउटपुट फ़ॉर्मेट में बदल जाती है। यदि आप प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहते हैं न कि परिवर्तित रास्टर फ़ाइल, तो छवि संसाधन के बाइनरी डेटा का उपयोग करें।

### **SVG इमेज निकालें**

SVG चित्र के लिए, [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) ऑब्जेक्ट उजागर करता है। इससे आप SVG डेटा को सीधे प्राप्त कर सकते हैं बजाय पहले चित्र को रास्टराइज़ किए।

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

SVG सामग्री को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसे रास्टर निर्यात स्वाभाविक रूप से उस वेक्टर सामग्री को पिक्सल में रेंडर करते हैं। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यातित ग्राफ़िक्स को मूल एंबेडेड SVG की बाइट‑दर‑बाइट प्रतिलिपि नहीं माना जाना चाहिए; जब मूल वेक्टर संसाधन की आवश्यकता हो तो एंबेडेड [SvgImage.getSvgData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/#getSvgData) डेटा का उपयोग करें।

## **छवि को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर दिखायी देने वाले छवि भाग को बदलती है। [PictureFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/) पर क्रॉप मान स्रोत छवि आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारम्भ में एंबेडेड छवि से छिपे पिक्सेल को मिटाती नहीं है; यह केवल दृश्य क्षेत्र को बदलती है।

निम्न उदाहरण सुरक्षित रूप से एक चित्र फ्रेम खोजता है और क्रॉप मान लागू करता है:

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

चूंकि छिपा हुआ छवि डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनरावृत्ति की आवश्यकता नहीं है, तो अगले सेक्शन में वर्णित अनुसार क्रॉप्ड क्षेत्र को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप्ड इमेज डेटा हटाएँ**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) वर्तमान क्रॉप आयत के बाहर के छवि डेटा को हटाता है और resulting इमेज रिसोर्स लौटाता है। इससे फ़ाइल आकार घट सकता है, लेकिन यह एक विनाशकारी अनुकूलन है: प्रस्तुति सहेजने के बाद हटाए गए पिक्सेल बाद में अनक्रॉप संचालन के लिए उपलब्ध नहीं रहेंगे।

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

यह मेथड प्रस्तुति में नया इमेज रिसोर्स जोड़ सकता है। यदि मूल छवि का उपयोग अन्य चित्र फ्रेम भी करते हैं, तो उन फ्रेम को अभी भी अपना मौजूदा रिसोर्स चाहिए, इसलिए क्रॉप्ड क्षेत्रों को हटाना आवश्यक रूप से कुल छवियों की संख्या कम नहीं करता। WMF या EMF सामग्री को इस मेथड के साथ क्रॉप करने से क्रॉप्ड परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर इमेजेज को संपीड़ित करें**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#compressImage) रास्टर छवि रिज़ॉल्यूशन को उस आकार के सापेक्ष कम करता है जिस पर चित्र प्रदर्शित होता है। यह एक ही ऑपरेशन में क्रॉप्ड क्षेत्रों को भी हटा सकता है। मेथड तब `True` लौटाता है जब छवि को आकार बदल दिया गया हो या क्रॉप किया गया हो, और `False` जब कोई परिवर्तन आवश्यक न हो।

जब एक मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तब एक पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturescompression/) मान का उपयोग करें:

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

जब विशिष्ट लक्ष्य आवश्यक हो, तो पूर्वनिर्धारित मान के बजाय कोई कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संकुचन रास्टर इमेजेज के लिए अभिप्रेत है। SVG और मैटाफाइल सामग्री इस रास्टर संपीड़न वर्कफ़्लो से नहीं घटती। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप्ड क्षेत्रों को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर छवि वास्तविक रूप से देखी या निर्यात की जाएगी, न कि वैश्विक रूप से सबसे कम DPI लागू करें।

## **इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स प्रबंधित करें**

पूर्ण कार्यप्रवाह जिसमें चमक, कंट्रास्ट, रंग परिवर्तन, ब्लर, अल्फा इफ़ेक्ट्स, क्रमबद्ध श्रृंखलाएँ, निरीक्षण, हटाना और राउंड‑ट्रिप सत्यापन शामिल हैं, के लिए देखें [Image Transform Effects](/slides/hi/python-java/image-transform-effects/)।

## **चित्र फ्रेम ज्यामिति को लॉक करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframelock/) सेटिंग्स निर्धारित करती हैं कि चित्र फ्रेम के लिए कौन से संपादन कार्य अक्षम हैं। उदाहरण के लिए, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) आकार बदलते समय आकार अनुपात को बनाए रखता है।

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

यह लॉक चित्र फ्रेम आकार पर लागू होती है। यह स्रोत छवि को पुनःसैंपल या स्थायी रूप से समान अनुपात में बदलने के लिए बाध्य नहीं करता।

## **StretchOffset मानों को समायोजित करें**

जब चित्र फ़िल मोड स्ट्रेच हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/) पर stretch‑offset मान चित्र फ्रेम के बाउंडिंग बॉक्स के सापेक्ष फ़िल आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक इनसेट बनाते हैं, जबकि नकारात्मक प्रतिशत एक आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत छवि के किस भाग को दिखाना है, इसे चुनते हैं; स्ट्रेच ऑफ़सेट दृश्यमान चित्र फ़िल को किनमें स्ट्रेच किया जाता है, उस आयत को बदलते हैं।

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

फ़िल प्लेसमेंट के लिए स्ट्रेच ऑफ़सेट का उपयोग करें। स्रोत‑छवि किनारों को छिपाने के लक्ष्य के लिए क्रॉप गुणों का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और निर्यात विचार**

छवि स्टोरेज और चित्र‑फ़्रेम स्वरूपण को अलग‑अलग संभालने पर मुख्य ट्रेड‑ऑफ़ अधिक आसान होते हैं:

- **एंबेडेड इमेजेज** प्रस्तुति को स्व‑समाहित बनाती हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिये सबसे भरोसेमंद होती हैं, लेकिन बड़े रास्टर इमेजेज PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **लिंक्ड इमेजेज** पैकेज को छोटा रख सकती हैं, लेकिन प्रस्तुति बाहरी फ़ाइलों पर निर्भर रहती है जो संग्रहीत पाथ या स्थानों पर उपलब्ध होनी चाहिए।
- **क्रॉपिंग** प्रारम्भ में गैर‑विनाशकारी होती है। छिपे पिक्सेल एंबेडेड रहते हैं जब तक कि क्रॉप्ड क्षेत्रों को स्पष्ट रूप से हटाया न जाए या संकुचन के दौरान हटाया न जाए।
- **कम्प्रेशन** अधिक बड़े रास्टर इमेजेज के लिये फ़ाइल आकार को उल्लेखनीय रूप से घटा सकता है, पर स्रोत रिज़ॉल्यूशन का बलिदान देता है। इसे स्लाइड पर इच्छित आकार ज्ञात होने के बाद लागू करना चाहिए।
- **SVG इमेजेज** को तब SVG के रूप में रखना चाहिए जब वेक्टर संरक्षण महत्वपूर्ण हो। जब आपको स्वयं वेक्टर संसाधन की आवश्यकता हो तो एंबेडेड SVG को सीधे निकालें। रास्टर स्लाइड निर्यात हमेशा रेंडर किए गए स्लाइड को पिक्सल में बदल देता है।
- **दोहराई गई इमेजेज** संभव हो तो मौजूदा [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) रिसोर्स को पुनः उपयोग करें, बजाय प्रत्येक बार वही फ़ाइल प्रस्तुति वर्कफ़्लो में लोड करने के।

बड़ी प्रस्तुतियों के लिये, छवि अनुकूलन आम तौर पर चयनात्मक रूप से सबसे प्रभावी होता है: लोगो और आरेख को वेक्टर सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक प्रदर्शित आकार के अनुसार संकुचित करें, क्रॉप्ड पिक्सेल तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक से बचें जब तक कि निर्भरता प्रबंधन परिनियोजन डिज़ाइन का हिस्सा न हो।

## **FAQ**

**एक चित्र फ्रेम और एक छवि संसाधन में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) प्रस्तुति से जुड़ा हुआ छवि संसाधन दर्शाता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) स्लाइड पर वह आकार है जो छवि प्रदर्शित करता है और आकार, घूर्णन, क्रॉप मान, इफ़ेक्ट्स और लॉक जैसी फ्रेम‑स्तर ज्यामिति एवं स्वरूपण को संग्रहीत करता है।

**मुझे एंबेड करना चाहिए या लिंक करना चाहिए?**

जब प्रस्तुति को पोर्टेबल, अभिलेखित या बाहरी संसाधनों की पहुँच के बिना रेंडर किया जाना हो, तो छवियों को एंबेड करें। केवल तब लिंक करें जब छवि फ़ाइलों को PPTX के बाहर रखना इरादा हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार कम करती है?**

स्वयं नहीं। सामान्य क्रॉप सेटिंग्स स्रोत छवि के भागों को छिपाती हैं लेकिन अंतर्निहित पिक्सेल को रखती हैं। फ़ाइल आकार घटाने के लिये [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) या क्रॉप्ड‑एरिया हटाने के साथ इमेज संपीड़न का उपयोग करें।

**क्या मैं संपीड़न के बाद इमेज क्वालिटी पुनर्स्थापित कर सकता हूँ?**

नहीं। संपीड़न संग्रहीत रास्टर रिज़ॉल्यूशन कम कर देता है, और क्रॉप्ड क्षेत्रों को हटाने से इमेज डेटा हट जाता है। यदि बाद में हाई‑रिज़ॉल्यूशन संपादन की संभावना हो, तो मूल स्रोत छवि को प्रस्तुति के बाहर रखें।

**SVG इमेजेज को कैसे संभालना चाहिए?**

जब वेक्टर फ़िडेलिटी महत्वपूर्ण हो, तो SVG सामग्री को SVG के रूप में रखें। एंबेडेड [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसी रास्टर फ़ॉर्मेट में निर्यात करने से SVG स्लाइड इमेज का भाग पिक्सल में रास्टराइज़ हो जाता है।

**मौजूदा स्लाइड्स को पढ़ते समय असुरक्षित कास्ट से कैसे बचें?**

चित्र‑फ़्रेम‑विशिष्ट सदस्यों का उपयोग करने से पहले आकार प्रकार की जांच करें। [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) के विरुद्ध `isinstance` जांच असुरक्षित कास्ट से बचाती है और कोड को उन स्लाइड्स को संभालने देती है जिनमें चित्र‑फ़्रेम नहीं होते।