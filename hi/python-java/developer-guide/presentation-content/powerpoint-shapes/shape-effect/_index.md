---
title: Python via Java का उपयोग करके प्रस्तुतियों में आकृति प्रभाव लागू करें
linktitle: आकृति प्रभाव
type: docs
weight: 30
url: /hi/python-java/shape-effect/
keywords:
- आकृति प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- चमक प्रभाव
- मुलायम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके उन्नत आकृति प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग किसी आकृति को उभारने के लिए किया जा सकता है, वे [fills](/slides/hi/python-java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकृति पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकृति की चमक फैला सकते हैं, आदि।

![आकृति प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकृतियों पर लागू किया जा सकता है। आप एक या अधिक प्रभावों को किसी आकृति पर लागू कर सकते हैं।

कुछ प्रभावों के संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के ऐसे संयोजन होते हैं जो दिखने में अच्छे होते हैं। इस प्रकार, एक प्रीसेट चुनकर आपको विभिन्न प्रभावों का परीक्षण या संयोजन करने में समय नहीं बर्बाद करना पड़ेगा।

Aspose.Slides में [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) क्लास के तहत प्रॉपर्टी और मेथड्स उपलब्ध हैं जो आपको PowerPoint प्रस्तुतियों में आकृतियों पर वही प्रभाव लागू करने की अनुमति देते हैं।

## **एक छाया प्रभाव लागू करें**

Aspose.Slides for Python via Java आकृतियों के लिए बाहरी और भीतरी छायाएँ समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके आप किसी कार्ड या पैनल को स्लाइड पृष्ठभूमि के विरुद्ध उभरते हुए दिखा सकते हैं। छाया आकृति के किनारों से बाहर तक विस्तारित होती है, जिससे ऐसा प्रभाव पैदा होता है कि आकृति स्लाइड के ऊपर उठी हुई है। अपने टेम्पलेट की प्रकाश और शैली से मेल खाने के लिए रंग, दिशा, दूरी और ब्लर त्रिज्या को समायोजित करें।

यह Python कोड दिखाता है कि कैसे [outer shadow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) को एक आयत पर लागू किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![छाया प्रभाव](shadow_effect.png)

### **भीतरी छाया लागू करें**

जब आप किसी टेम्पलेट की दृश्य शैली को दोहराते हैं, तो भीतरी छाया का उपयोग करके कार्ड या पैनल को गहराई वाला स्वरूप दे सकते हैं। बाहरी छाया आकृति के बाहर विस्तारित होती है और उसे उठाया हुआ दिखाती है, जबकि भीतरी छाया उसके किनारों के अंदर छाया डालती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान अधिक मुलायम किनारे उत्पन्न करते हैं।

यह Python उदाहरण हल्के नीले कार्ड को गहरा ग्रे भीतरी छाया के साथ बनाता है और इसे PPTX फ़ाइल में सहेजता है। छाया की दिशा 225 डिग्री है, उसकी दूरी 7 पॉइंट्स है, और उसकी ब्लर त्रिज्या 6 पॉइंट्स है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![भीतरी छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

भीतरी छाया को हटाने के लिए, आकृति की इफ़ेक्ट फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

### **प्रीसेट छाया लागू करें, बदलें और हटाएँ**

[enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) को कॉल करें, फिर [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) का उपयोग करके एक [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) चुनें। शैली बदलने के लिए, एक ही आकृति पर प्रीसेट बदलें। छाया को हटाने के लिए, लेकिन भराव और रूपरेखा को बनाए रखते हुए, [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) को कॉल करें।

उदाहरण प्रत्येक चरण पर आयत को क्लोन करता है ताकि आप एक ही स्लाइड पर चारों स्थितियों की साइड बाय साइड तुलना कर सकें। दोनों छायाएँ 10 पॉइंट्स से ऑफसेट हैं। 225° दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है। 45° दिशा दूसरी छाया को नीचे और दाएँ रखती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| मूल | पहला प्रीसेट | दूसरा प्रीसेट | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई छाया नहीं](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **एक प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for Python via Java में प्रतिबिंब प्रभाव लागू करने के लिए, आप आकृतियों में एक दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, और दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बेहतर बनाता है, आकृतियों को अधिक परिष्कृत लुक देता है। यह सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर एकसमान डिज़ाइन लागू करना तेज़ हो जाता है।

यह Python कोड दिखाता है कि कैसे [reflection effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) को एक आकृति पर लागू किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![प्रतिबिंब प्रभाव](reflection_effect.png)

## **एक चमक प्रभाव लागू करें**

Aspose.Slides for Python via Java में आकृति पर चमक प्रभाव लागू करने के लिए, आप आकृतियों के चारों ओर एक नरम, उज्ज्वल आभा जोड़ सकते हैं, और रंग तथा आकार जैसी प्रॉपर्टीज़ को समायोजित कर सकते हैं। यह प्रभाव आकृतियों को उभारा करता है और आपके प्रस्तुतियों में एक आकर्षक, दृष्टिगोचर दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे आपकी स्लाइडों की समग्र उपस्थिति बेहतर होती है।

यह Python कोड दिखाता है कि कैसे [glow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) को एक आकृति पर लागू किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![चमक प्रभाव](glow_effect.png)

## **एक मुलायम किनारे प्रभाव लागू करें**

Aspose.Slides for Python via Java में मुलायम किनारे प्रभाव लागू करने के लिए, आप आकृति के किनारों के चारों ओर एक स्मूथ, ब्लर ट्रांज़िशन बना सकते हैं। यह प्रभाव एक अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, विशेष रूप से उन डिज़ाइनों के लिए जो नरम, कोमल उपस्थिति चाहते हैं। आप आसानी से त्रिज्या जैसे पैरामीटर समायोजित करके विभिन्न आकृतियों पर इच्छित प्रभाव प्राप्त कर सकते हैं।

यह Python कोड दिखाता है कि कैसे [soft edges effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) को एक आकृति पर लागू किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![मुलायम किनारे प्रभाव](soft_edges_effect.png)

## **एक ब्लर प्रभाव लागू करें**

आकृति ब्लर का उपयोग करके आप आकृति की भराव और रूपरेखा को नरम बना सकते हैं, जबकि आकृति संपादनीय रहती है। आकृति की इफ़ेक्ट फ़ॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करें। त्रिज्या पॉइंट्स में मापी जाती है (1/72 इंच): गैर-नकारात्मक मान उपयोग करें, बड़ी मान अधिक तीव्र ब्लर उत्पन्न करेंगे। शून्य त्रिज्या रखनी से दिखावट अपरिवर्तित रहती है।

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) सेटिंग प्रभाव की दिखाई देने वाली सीमाओं को नियंत्रित करती है। `False` होने पर, ब्लर मूल चित्रित सीमाओं तक सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `True` होने पर, ब्लर इन सीमाओं से बाहर भी बढ़ सकता है। कोई भी सेटिंग आकृति की स्थिति या आयामों को नहीं बदलती।

नीचे की तुलना में पूरे समय समान भराव, रूपरेखा और आकृति आयाम प्रयोग किए गए हैं। शीर्ष पंक्ति `grow = False` का उपयोग करती है; नीचे की पंक्ति `grow = True` का।

![विभिन्न ब्लर त्रिज्या (5 और 15 पॉइंट) और grow विकल्प के साथ मूल आयत तुलना](shape_blur_comparison.png)

यह Python उदाहरण नारंगी आयत को गहरा नीला रूपरेखा के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, फिर फिर से [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करके 15 पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) को कॉल करके बिना ब्लर के आकृति को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आकृति ब्लर भराव और रूपरेखा दोनों को साथ प्रभावित करता है। मुलायम किनारे प्रभाव आकृति के किनारों को फीका करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। छवि रूपांतरण प्रभाव छवि सामग्री पर काम करते हैं; यह उदाहरण आकृति को छवि में परिवर्तित किए बिना सीधे उसकी इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **आम प्रश्न (FAQ)**

**क्या मैं एक ही आकृति पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकृति पर विभिन्न प्रभावों, जैसे छाया, प्रतिबिंब और चमक, को मिलाकर अधिक गतिशील रूप दे सकते हैं।

**मैं किन आकृतियों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न प्रकार की आकृतियों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अन्य शामिल हैं।

**क्या मैं समूहित आकृतियों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकृतियों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।