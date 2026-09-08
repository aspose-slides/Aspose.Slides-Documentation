---
title: "Python का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें"
linktitle: "छवियों का प्रबंधन"
type: docs
weight: 10
url: /hi/python-java/image/
keywords:
- "छवि जोड़ें"
- "चित्र जोड़ें"
- "छवि बदलें"
- "छवि संग्रह"
- "पिक्चर फ्रेम"
- "लिंक्ड छवि"
- "पृष्ठभूमि"
- "PNG जोड़ें"
- "JPG जोड़ें"
- "SVG जोड़ें"
- "SVG को आकारों में बदलें"
- "बाहरी SVG संसाधन"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में रास्टर और SVG छवियों को जोड़ने, पुनः उपयोग करने, लिंक करने, बदलने और प्रबंधित करने के तरीकों को जानें।"
---
## **परिचय**

Aspose.Slides for Python via Java कई तरीकों से छवियों के साथ काम करने के विकल्प प्रदान करता है, और प्रत्येक का अलग उद्देश्य है। आप प्रस्तुति में छवि संग्रहीत कर सकते हैं, उसे पिक्चर फ्रेम में प्रदर्शित कर सकते हैं, स्लाइड पृष्ठभूमि के रूप में उपयोग कर सकते हैं, बाहरी छवि का लिंक दे सकते हैं, साझा छवि संसाधन को बदल सकते हैं, या SVG सामग्री को संपादन योग्य आकारों में बदल सकते हैं।

यह लेख छवि संसाधनों और उनका संपूर्ण प्रस्तुति में उपयोग पर केंद्रित है। पिक्चर फ्रेम में क्रॉपिंग, पारदर्शिता, प्रभाव, स्ट्रेचिंग और अन्य स्वरूपण के लिए देखें [Picture Frame](/slides/hi/python-java/picture-frame/)।

## **छवि मॉडल को समझें**

निम्नलिखित API अवधारणाएँ निकटता से संबंधित हैं लेकिन परस्पर बदलने योग्य नहीं हैं:

- प्रस्तुति की [presentation image collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/) वह संग्रह है जहाँ प्रस्तुति द्वारा उपयोग किए जाने वाले छवि संसाधन संग्रहीत होते हैं। छवि डेटा जोड़ने और एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) संसाधन प्राप्त करने के लिए [ImageCollection.addImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/#addImage) का उपयोग करें।
- एक [picture frame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) वह आकार है जो स्लाइड, लेआउट या मास्टर पर छवि दिखाता है। स्लाइड पर एक छवि संसाधन रखने के लिए [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addPictureFrame) का प्रयोग करें।
- स्लाइड पृष्ठभूमि छवि को स्लाइड के फ़िल के भाग के रूप में उपयोग करती है, न कि आकार के रूप में। इसलिए यह पिक्चर फ्रेम की तरह व्यवहार नहीं करती।
- [PPImage.replaceImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#replaceImage) एक छवि संसाधन को प्रतिस्थापित करता है। यदि कई प्रस्तुति तत्व उस संसाधन का उपयोग करते हैं, तो वे सभी प्रतिस्थापन को उपयोग करेंगे।
- SVG को आकारों में बदलने से संपादन योग्य स्लाइड आकार बनते हैं। परिवर्तन के बाद, सामग्री अब एकल पिक्चर संसाधन के रूप में प्रबंधित नहीं रहती।

एक सामान्य कार्यप्रवाह इस प्रकार है: छवि डेटा को इमेज कलेक्शन में जोड़ें, एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) प्राप्त करें, और फिर उस संसाधन को एक या अधिक पिक्चर फ्रेम या फ़िल में उपयोग करें।

## **एक एंबेडेड छवि जोड़ें**

स्थानीय छवि सम्मिलित करने के लिए फ़ाइल लोड करें, उसे इमेज कलेक्शन में जोड़ें, और लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) का उपयोग करके एक पिक्चर फ्रेम बनाएं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

इस प्रकार जोड़ी गई छवि प्रस्तुति में एंबेडेड रहती है, इसलिए उत्पन्न फ़ाइल मूल छवि फ़ाइल की उपलब्धता पर निर्भर नहीं करती।

### **वेब से छवि जोड़ें**

जब कोई छवि HTTP या HTTPS के माध्यम से उपलब्ध हो, तो उसके बाइट्स डाउनलोड करें, उन्हें प्रस्तुति की इमेज कलेक्शन में जोड़ें, और लौटाए गए छवि संसाधन का उपयोग स्थानीय छवि की तरह ही करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

दीर्घकालिक अनुप्रयोगों में, अनावश्यक रूप से नेटवर्किंग इंफ़्रास्ट्रक्चर बार‑बार बनाने के बजाय उचित HTTP क्लाइंट या कनेक्शन‑प्रबंधन रणनीति को पुनः प्रयोग करें। साथ ही जब स्रोत विश्वसनीय न हो तो रिमोट URL, प्रतिक्रिया आकार और कंटेंट‑टाइप की वैधता जांचें।

## **स्लाइड्स में छवियों का पुनः उपयोग करें**

यदि एक ही छवि को कई बार चाहिए, तो उसे प्रस्तुति में एक बार जोड़ें और अतिरिक्त पिक्चर फ्रेम बनाते समय लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) को पुनः उपयोग करें। यह समान स्रोत डेटा को बार‑बार लोड करने से बचाता है और साझा छवि संसाधन तथा उसके उपयोगों के बीच संबंध को स्पष्ट करता है।

बहु‑स्लाइड्स पर स्वतः दिखाई देने वाले ग्राफ़िक्स (जैसे कंपनी का लोगो) के लिए, प्रत्येक स्लाइड में समान आकार जोड़ने के बजाय [slide master](/slides/hi/python-java/slide-master/) या लेआउट पर पिक्चर फ्रेम रखें।

## **छवि को स्लाइड पृष्ठभूमि के रूप में उपयोग करें**

पृष्ठभूमि छवि को स्लाइड फ़िल को सौंपा जाता है; इसे पिक्चर‑फ़्रेम आकार के रूप में नहीं जोड़ा जाता। यह तब उपयोगी है जब चित्र को स्लाइड पृष्ठभूमि पर पूरी तरह कवर करना हो और उसे सामान्य स्लाइड ऑब्जेक्ट की तरह संशोधित नहीं किया जाना चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

अतिरिक्त पृष्ठभूमि विकल्पों के लिए, जिसमें मास्टर और लेआउट पृष्ठभूमि शामिल हैं, देखें [Presentation Background](/slides/hi/python-java/presentation-background/)।

## **एंबेडेड छवियाँ और लिंक्ड छवियाँ**

एंबेडेड और लिंक्ड छवियों में पोर्टेबिलिटी और फ़ाइल‑आकार के अलग‑अलग समझौते होते हैं:

- **एंबेडेड छवि:** छवि डेटा प्रस्तुति के अंदर संग्रहीत रहता है। प्रस्तुति स्वयं‑सम्बद्ध होती है, पर फ़ाइल आकार में छवि डेटा शामिल रहता है।
- **लिंक्ड छवि:** प्रस्तुति बाहरी छवि का पाथ या URL संग्रहित करती है। यह प्रस्तुति का आकार कम कर सकता है, पर बाहरी संसाधन को तब तक सुलभ रहना चाहिए जब तक प्रस्तुति खोली या रेंडर की जाती है।

एक लिंक्ड चित्र को बनाने के लिए बाहरी पाथ या URL को [Picture.setLinkPathLong](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#setLinkPathLong) के माध्यम से असाइन करें, न कि छवि डेटा को एंबेड करके।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

केवल तभी लिंक्ड छवियों का उपयोग करें जब डिप्लॉयमेंट पर्यावरण बाहरी संसाधन को विश्वसनीय रूप से एक्सेस कर सके। ऑफ़लाइन काम करने या सिस्टम बदलने वाले प्रस्तुतियों के लिए एंबेडेड छवियाँ अधिक सुरक्षित होती हैं।

## **SVG छवियों के साथ काम करें**

SVG एक वेक्टर फ़ॉर्मेट है, इसलिए यह आइकन, डायग्राम और अन्य ग्राफ़िक्स के लिए उपयोगी है जिन्हें रास्टर छवियों की तरह विवरण खोए बिना स्केल किया जा सके। Aspose.Slides SVG को दोनों रूपों में सपोर्ट करता है: एक छवि संसाधन और संपादन योग्य स्लाइड आकारों का स्रोत।

### **SVG को छवि के रूप में जोड़ें**

एक [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) बनाएं, इसे इमेज कलेक्शन में जोड़ें, और परिणामस्वरूप छवि संसाधन को पिक्चर फ्रेम में रखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **बाहरी संसाधनों वाले SVG फ़ाइलें**

SVG बाहरी छवियों, स्टाइलशीटों या फ़ॉन्ट्स का संदर्भ दे सकता है। ऐसे मामलों के लिए, [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) ऐसे कन्स्ट्रक्टर प्रदान करता है जो एक [ExternalResourceResolver](https://reference.aspose.com/slides/hi/python-java/aspose.slides/externalresourceresolver/) और बेस URI को स्वीकार करता है। रिज़ॉल्वर सापेक्ष URI को अनुमत पूर्ण URI में बदल सकता है और अनुरोधित संसाधन की स्ट्रीम लौटाता है।

रिज़ॉल्वर बाहरी संसाधनों को उपलब्ध कराता है जबकि Aspose.Slides SVG को प्रोसेस करता है, पर यह SVG को स्वनिष्पादित दस्तावेज़ में पुनर्लेख नहीं करता। यदि SVG को पोर्टेबल रखना आवश्यक हो, तो आवश्यक संसाधनों को स्वयं SVG में एंबेड करें, उदाहरण के लिए लिंक्ड इमेज के लिए `data:` URI का उपयोग करके।

जब SVG फ़ाइलें अविश्वसनीय स्रोतों से आती हैं, तो रिज़ॉल्वर द्वारा एक्सेस किए जाने वाले स्कीम, फ़ाइल स्थान और होस्ट को सीमित करें। नेटवर्क रिज़ॉल्वर को टाइमआउट, प्रतिक्रिया‑आकार सीमाएँ और कंटेंट वैधता भी लागू करनी चाहिए।

### **SVG को संपादन योग्य आकारों में बदलें**

Aspose.Slides SVG को संपादन योग्य स्लाइड आकारों के समूह में बदल सकता है, यह PowerPoint के संबंधित कमांड के समान है।

![PowerPoint Popup Menu](img_01_01.png)

परिवर्तन करने के लिए वह [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addGroupShape) ओवरलोड उपयोग करें जो एक [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) स्वीकार करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

SVG‑से‑आकार परिवर्तन का उपयोग तब करें जब व्यक्तिगत वेक्टर तत्वों को PowerPoint आकारों के रूप में संपादित करने की आवश्यकता हो। यदि SVG केवल प्रदर्शित करनी है, तो उसे छवि के रूप में रखना आसान है और कई अलग‑अलग आकार बनाने से बचता है।

## **मौजूद छवि संसाधन को बदलें**

जब आप मौजूदा छवि संसाधन को बदलना चाहते हैं, तो [PPImage.replaceImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#replaceImage) का उपयोग करें। यह साझा ग्राफ़िक्स (जैसे लोगो) के लिए विशेष रूप से उपयोगी है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यदि कई पिक्चर फ्रेम, पृष्ठभूमि, मास्टर या लेआउट एक ही छवि संसाधन का उपयोग करते हैं, तो उस संसाधन को बदलने से सभी उपयोग अपडेट हो जाते हैं। यदि केवल एक पिक्चर फ्रेम को बदलना है, तो साझा संसाधन को बदलने के बजाय उस फ्रेम को अलग छवि असाइन करें।

[PPImage.replaceImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#replaceImage) बाइट एरे या अन्य [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) को स्वीकार करने वाले ओवरलोड भी प्रदान करता है।

## **व्यावहारिक छवि प्रबंधन दिशानिर्देश**

### **प्रस्तुति आकार को नियंत्रित करें**

बड़े रास्टर छवियां प्रस्तुति को अनावश्यक रूप से बड़ा बना सकती हैं। स्रोत छवियों को उनके लक्ष्य डिस्प्ले आकार के अनुसार चुनें, संभव होने पर साझा छवि संसाधनों को पुनः उपयोग करें, और समान पूर्ण‑रिज़ॉल्यूशन ग्राफ़िक की कई प्रतियों को एंबेड करने से बचें।

उन रास्टर चित्रों के लिए जो पहले से पिक्चर फ्रेम में रखे गए हैं, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#compressImage) चयनित रिज़ॉल्यूशन और क्रॉप सेटिंग्स के अनुसार छवि डेटा को कम कर सकता है। यह पिक्चर‑फ़्रेम प्रोसेसिंग है, इमेज‑कलेक्शन प्रबंधन नहीं, इसलिए सम्बंधित फ़ॉर्मेटिंग क्रियाओं के लिए देखें [Picture Frame](/slides/hi/python-java/picture-frame/)।

### **एंबेडेड और लिंक्ड कंटेंट के बीच चयन करें**

एंबेडिंग प्रस्तुति को पोर्टेबल बनाती है क्योंकि सभी आवश्यक छवि डेटा फ़ाइल के साथ रहता है। लिंकिंग फ़ाइल आकार को घटा सकती है, पर यह बाहरी निर्भरता पेश करती है। केवल तभी लिंक का उपयोग करें जब वह निर्भरता स्वीकार्य और स्थिर हो।

### **साझा ब्रांडिंग को पुनः उपयोग करें**

बार‑बार उपयोग होने वाले लोगो, वॉटरमार्क या सजावटी ग्राफ़िक्स के लिए एक ही छवि संसाधन बनाकर उसे पुनः उपयोग करें। यदि ग्राफ़िक प्रस्तुति डिजाइन से अधिक स्लाइड सामग्री से जुड़ा है, तो उसे मास्टर या लेआउट पर रखें ताकि संबंधित स्लाइडों में स्वचालित रूप से विरासत में मिले।

### **SVG संसाधनों को पोर्टेबल रखें**

स्वनिष्पादित SVG को स्थानांतरित और स्थिर रूप से रेंडर करना आसान होता है बनिस्बत उन SVG के जो बाहरी फ़ाइलों या नेटवर्क संसाधनों पर निर्भर हैं। सम्भव हो तो SVG आयात करने से पहले आवश्यक संसाधनों को एंबेड करें। केवल तब SVG को आकारों में बदलें जब व्यक्तिगत वेक्टर तत्वों को संपादित करने की ज़रूरत हो।

### **आधुनिक क्रॉस‑प्लेटफ़ॉर्म इमेज API का उपयोग करें**

नए Python via Java कोड के लिए, लेगेसी `java.awt.image.BufferedImage` पर आधारित सार्वजनिक API के बजाय Aspose.Slides के क्रॉस‑प्लेटफ़ॉर्म इमेज ऑब्जेक्ट और [Images](https://reference.aspose.com/slides/hi/python-java/aspose.slides/images/) API का उपयोग करें। माइग्रेशन गाइडेंस के लिए देखें [Modern API](/slides/hi/python-java/modern-api/)।

WMF और EMF को विशेष विचार की आवश्यकता होती है। जब इन फ़ॉर्मेट्स को क्रॉस‑प्लेटफ़ॉर्म इमेज ऑब्जेक्ट के माध्यम से पास किया जाता है, तो [ImageCollection.addImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/#addImage) मेटाफाइल को PNG रास्टर प्रतिनिधित्व में बदल देता है। यदि मेटाफाइल डेटा को संरक्षित रखना महत्वपूर्ण है, तो स्ट्रीम‑आधारित [ImageCollection.addImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/#addImage) ओवरलोड का उपयोग करें। स्प्रेडशीट या अन्य उत्पादों से EMF सामग्री उत्पन्न करना एक अलग एकीकरण कार्यप्रवाह है और इस लेख के दायरे से बाहर है।

## **FAQ**

**इमेज कलेक्शन और पिक्चर फ्रेम में क्या अंतर है?**

इमेज कलेक्शन पुन: प्रयोज्य छवि संसाधन संग्रहीत करता है। पिक्चर फ्रेम एक स्लाइड आकार है जो उन संसाधनों में से एक को प्रदर्शित करता है और क्रॉपिंग व प्रभाव जैसे चित्र‑विशिष्ट स्वरूपण प्रदान करता है।

**सभी जगह समान लोगो बदलने का सबसे अच्छा तरीका क्या है?**

यदि लोगो पहले से एक छवि संसाधन के रूप में साझा है, तो उसे [PPImage.replaceImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#replaceImage) से बदलें। पूरी प्रस्तुति में ब्रांडिंग के लिए, लोगो को मास्टर या लेआउट पर रखना भी डुप्लिकेट स्लाइड सामग्री को कम कर सकता है।

**किसी अन्य कंप्यूटर पर लिंक्ड इमेज क्यों गायब हो जाती है?**

लिंक्ड चित्र अपनी बाहरी फ़ाइल या URL पर निर्भर करता है। यदि वह संसाधन दूसरे कंप्यूटर से पहुँच योग्य नहीं है, तो लिंक्ड इमेज उपलब्ध नहीं होगी। जब प्रस्तुति को स्वयं‑सम्बद्ध होना आवश्यक हो, तो छवि को एंबेड करें।

**क्या डाली गई SVG को PowerPoint आकारों के रूप में संपादित किया जा सकता है?**

हाँ। SVG को [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addGroupShape) से बदलें; प्राप्त समूह में संपादन योग्य स्लाइड आकार होते हैं, न कि एकल SVG चित्र।

**बहुत सारी छवियों वाली प्रस्तुतियों को छोटा कैसे रखें?**

साझा छवि संसाधनों को पुनः उपयोग करें, अनावश्यक रूप से बड़े रास्टर स्रोतों से बचें, उपयुक्त समय पर रास्टर चित्रों को संकुचित करें, पुनः उपयोग होने वाले ब्रांडिंग को मास्टर या लेआउट पर रखें, और केवल तभी लिंक्ड छवियों का उपयोग करें जब बाहरी निर्भरता स्वीकार्य हो।