---
title: Python का उपयोग करके प्रस्तुतियों में SmartArt ग्राफ़िक्स प्रबंधित करें
linktitle: SmartArt ग्राफ़िक्स
type: docs
weight: 20
url: /hi/python-java/manage-smartart-shape/
keywords:
- SmartArt ऑब्जेक्ट
- SmartArt ग्राफ़िक
- SmartArt शैली
- SmartArt रंग
- SmartArt बनाएं
- SmartArt जोड़ें
- SmartArt संपादित करें
- SmartArt बदलें
- SmartArt पहुँचें
- SmartArt लेआउट प्रकार
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में PowerPoint SmartArt निर्माण, संपादन और स्टाइलिंग को स्वचालित करें, संक्षिप्त कोड उदाहरण और प्रदर्शन-केंद्रित मार्गदर्शन सहित।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिकली PowerPoint प्रेजेंटेशन में SmartArt ग्राफ़िक्स बनाने और प्रबंधित करने की अनुमति देता है। यह लेख बताता है कि स्लाइड में SmartArt आकार कैसे जोड़ें, मौजूदा SmartArt आकारों तक कैसे पहुँचें, विशिष्ट लेआउट प्रकार द्वारा SmartArt को खोजें, और SmartArt शैली या रंग शैली बदलकर उसके दृश्य रूप को कैसे अपडेट करें।

उदाहरण दिखाते हैं कि प्रस्तुति स्लाइड के शेप कलेक्शन के माध्यम से SmartArt आकारों के साथ कैसे काम किया जाए, यह जांचें कि कोई आकार SmartArt है या नहीं, और फिर उसकी प्रॉपर्टीज़ को संशोधित या निरीक्षण करें।

## **SmartArt आकार बनाना**
Aspose.Slides for Python via Java SmartArt आकार बनाने के लिए API प्रदान करता है। स्लाइड में SmartArt आकार बनाने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड प्राप्त करें।
3. [SmartArtLayoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartlayouttype/) निर्दिष्ट करके [SmartArt आकार जोड़ें](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addSmartArt)।
4. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # SmartArt आकार जोड़ें।
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # प्रस्तुति सहेजें।
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**चित्र: स्लाइड में जोड़ा गया SmartArt आकार**|

## **स्लाइड पर SmartArt आकार तक पहुँचें**
निम्न उदाहरण प्रस्तुति स्लाइड पर SmartArt आकारों तक पहुँचता है। यह स्लाइड पर प्रत्येक आकार को इटररेट करता है और जांचता है कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # पहली स्लाइड पर प्रत्येक आकार को इटररेट करें।
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **विशिष्ट लेआउट प्रकार वाले SmartArt आकार तक पहुँचें**
निम्न उदाहरण एक विशेष लेआउट प्रकार वाले [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) आकार तक पहुँचता है, जिसे [SmartArt.getLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/#getLayout) द्वारा लौटाया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।
2. इंडेक्स द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर प्रत्येक आकार को इटररेट करें।
4. जाँचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. जाँचें कि SmartArt आकार में निर्दिष्ट लेआउट प्रकार है या नहीं और आवश्यक ऑपरेशन करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # पहली स्लाइड पर प्रत्येक आकार को इटररेट करें।
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt लेआउट जाँचें।
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **SmartArt आकार शैली बदलें**
यह उदाहरण दिखाता है कि कैसे SmartArt आकार की त्वरित शैली बदलें।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।
2. इंडेक्स द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर प्रत्येक आकार को इटररेट करें।
4. जाँचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. निर्दिष्ट शैली वाले SmartArt आकार को खोजें।
6. SmartArt आकार के लिए नई शैली सेट करें।
7. प्रेजेंटेशन सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # पहली स्लाइड पर प्रत्येक आकार को इटररेट करें।
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt शैली जाँचें और बदलें।
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**चित्र: बदली हुई शैली के साथ SmartArt आकार**|

## **SmartArt आकार रंग शैली बदलें**
यह उदाहरण एक विशेष रंग शैली वाले SmartArt आकार तक पहुँचता है और उस शैली को बदलता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।
2. इंडेक्स द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर प्रत्येक आकार को इटररेट करें।
4. जाँचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. निर्दिष्ट रंग शैली वाले SmartArt आकार को खोजें।
6. SmartArt आकार के लिए नई रंग शैली सेट करें।
7. प्रेजेंटेशन सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # पहली स्लाइड पर प्रत्येक आकार को इटररेट करें।
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt शैली जाँचें और बदलें।
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**चित्र: बदली हुई रंग शैली के साथ SmartArt आकार**|

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SmartArt को एकल वस्तु के रूप में एनीमेट कर सकता हूँ?**

हां। SmartArt एक आकार है, इसलिए आप एनिमेशन API के माध्यम से [मानक एनीमेशन](/slides/hi/python-java/powerpoint-animation/) लागू कर सकते हैं (प्रवेश, निकास, ज़ोर, गति पथ) जैसे अन्य आकारों के लिए।

**अगर मुझे SmartArt का आंतरिक ID नहीं पता है तो मैं स्लाइड पर विशिष्ट SmartArt कैसे खोज सकता हूँ?**

एक [वैकल्पिक टेक्स्ट](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setAlternativeText) सेट करें और उसका उपयोग करके आकार को उस मान से खोजें—यह लक्ष्य आकार को खोजने का अनुशंसित तरीका है।

**क्या मैं SmartArt को अन्य आकारों के साथ समूहित कर सकता हूँ?**

हां। आप SmartArt को अन्य आकारों (चित्र, तालिका, आदि) के साथ समूहित कर सकते हैं और फिर [समूह को नियंत्रित करें](/slides/hi/python-java/group/)।

**मैं विशिष्ट SmartArt की छवि (जैसे प्रीव्यू या रिपोर्ट के लिए) कैसे प्राप्त करूँ?**

आकार की थंबनेल/छवि निर्यात करें; लाइब्रेरी [व्यक्तिगत आकार रेंडर कर सकती है](/slides/hi/python-java/create-shape-thumbnails/) रास्टर फ़ाइलों (PNG/JPG/TIFF) में।

**क्या पूरी प्रेजेंटेशन को PDF में बदलते समय SmartArt का रूप बना रहेगा?**

हां। रेंडरिंग इंजन [PDF निर्यात](/slides/hi/python-java/convert-powerpoint-to-pdf/) के लिए उच्च फ़िडेलिटी लक्षित करता है, जिसमें गुणवत्ता और संगतता विकल्पों की विविधता शामिल है।