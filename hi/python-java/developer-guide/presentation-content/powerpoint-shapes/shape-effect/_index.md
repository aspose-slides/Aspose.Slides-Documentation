---
title: प्रस्तुतियों में Python के माध्यम से Java का उपयोग करके आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/python-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- ग्लो प्रभाव
- सॉफ्ट एजेज़ प्रभाव
- इफेक्ट फॉर्मेट
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके अपने PPT और PPTX फ़ाइलों को उन्नत आकार प्रभावों के साथ बदलें—सेकंडों में आकर्षक, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, वे [भरण](/slides/hi/python-java/shape-formatting/#gradient-fill) या रूपरेखाओं से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

![Shape effect](shape-effect.png)

PowerPoint आकारों पर लागू किए जा सकने वाले छह प्रभाव प्रदान करता है। आप एक आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभावों के संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के ऐसे संयोजन हैं जो अच्छी तरह दिखते हैं। इस प्रकार, एक preset चुनकर आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) क्लास के अंतर्गत गुण और विधियाँ प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर वही प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Python via Java आकारों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी, और धुंधलापन त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके आप किसी कार्ड या पैनल को स्लाइड के पृष्ठभूमि के खिलाफ प्रमुख बना सकते हैं। छाया आकार की किनारों से परे तक विस्तार करती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड के ऊपर उठाया गया हो। इसके रंग, दिशा, दूरी, और धुंधलापन त्रिज्या को अपने टेम्पलेट की प्रकाश व्यवस्था और शैली के अनुसार समायोजित करें।

यह Python कोड दिखाता है कि [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) को आयत पर कैसे लागू किया जाए:

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

![Shadow effect](shadow_effect.png)

#### **जब आकार घुमता है तो छाया की दिशा नियंत्रित करें**

डिफ़ॉल्ट रूप से, बाहरी छाया आकार के साथ घूमती है। विभिन्न घूर्णन वाले आकारों को एक ही दिशा से प्रकाशित दिखाने के लिए, [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) को `False` के साथ कॉल करें और [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) का उपयोग करके उनकी छायाओं को समान दिशा दें।

उदाहरण दो नीले तीर बनाता है जिनकी ग्रे छाया 42 पॉइंट दाईं ओर (0°) स्थानांतरित है। फिर यह स्लाइड को डुप्लिकेट करता है और दोनों तीरों को 90° घड़ी की दिशा में घुमाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

दूसरी स्लाइड पर, बायां तीर अपनी छाया नीचे डालता है, जबकि दायां तीर अभी भी अपनी छाया दाईं ओर डालता है। दोनों छायाओं के लिए कॉन्फ़िगर की गई दिशा 0° बनी रहती है।

![90° घुमाव से पहले और बाद में PowerPoint रेंडरिंग। दोनों छायाएँ दाईं ओर शुरू होती हैं। घुमाव के बाद, छाया बाएं तीर के नीचे चली जाती है और दाएं तीर के दाईं ओर बनी रहती है।](arrow-shadow-rotation.png)

### **आंतरिक छाया लागू करें**

टेम्पलेट की दृश्य शैली को दोहराते समय, कार्ड या पैनल को एक अवसादित रूप देने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर तक फैली होती है और इसे उठी हुई दिखाती है, जबकि आंतरिक छाया इसके किनारों के अंदर को छाया देती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाई गई छाया को कॉन्फ़िगर करें। बड़ी धुंधलापन त्रिज्या मान से नरम किनारे बनते हैं।

यह Python उदाहरण हल्के नीले कार्ड को गहरा ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, दूरी 7 पॉइंट है, और धुंधलापन त्रिज्या 6 पॉइंट है:

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

![आंतरिक छाया वाला हल्का नीला आयत](inner_shadow_effect.png)

आंतरिक छाया को हटाने के लिए, आकार के effect format पर [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

### **Preset छाया लागू करें, बदलें, और हटाएँ**

[enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) को कॉल करें, फिर [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) का उपयोग करके एक [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) चुनें। शैली बदलने के लिए, समान आकार पर preset बदलें। छाया को हटाने के लिए, जबकि भरण और रूपरेखा को बनाए रखें, [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) को कॉल करें।

उदाहरण में आयत को प्रत्येक चरण में क्लोन किया जाता है ताकि आप एक स्लाइड पर सभी चार स्थितियों की साइड बाय साइड तुलना कर सकें। दोनों छायाओं की दूरी 10 पॉइंट है। 225° की दिशा पहली छाया को आयत के ऊपर और बाएं रखती है। 45° की दिशा दूसरी छाया को नीचे और दाएं रखती है।

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

| मूल | पहला preset | दूसरा preset | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for Python via Java में प्रतिबिंब प्रभाव लागू करने के लिए, आप आकारों पर दर्पण-समान प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता, और आकार जैसे पैरामीटर को समायोजित करके। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक चमकदार और परिष्कृत रूप देता है। इसे सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर तेज़ी से समान डिजाइन लागू हो सके।

यह Python कोड दिखाता है कि [reflection effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) को आकार पर कैसे लागू किया जाए:

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

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for Python via Java में आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकारों के चारों ओर एक नरम, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी गुणों को समायोजित करके। यह प्रभाव आकारों को प्रमुख बनाता है और आपके प्रस्तुति में एक आकर्षक, ध्यान खींचने वाला दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ आसानी से लागू किया जा सकता है, जिससे आपकी स्लाइड्स की समग्र उपस्थिति सुधरती है।

यह Python कोड दिखाता है कि [glow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) को आकार पर कैसे लागू किया जाए:

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

![ग्लो प्रभाव](glow_effect.png)

## **सॉफ्ट एजेज़ प्रभाव लागू करें**

Aspose.Slides for Python via Java में सॉफ्ट एजेज़ प्रभाव लागू करने के लिए, आप आकार के किनारों के चारों ओर एक स्मूद, धुंधला संक्रमण बना सकते हैं। यह प्रभाव एक अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, उन डिज़ाइनों के लिए आदर्श है जिन्हें नरम, सौम्य रूप चाहिए। आप आसानी से त्रिज्या जैसे पैरामीटर को समायोजित करके अपनी प्रस्तुति में विभिन्न आकारों में वांछित प्रभाव प्राप्त कर सकते हैं।

यह Python कोड दिखाता है कि [soft edges effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) को आकार पर कैसे लागू किया जाए:

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

![सॉफ्ट एजेज़ प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकार ब्लर का उपयोग करके आप आकार की भराव और रूपरेखा को नरम कर सकते हैं जबकि आकार को संपादित योग्य रखते हैं। आकार के effect format पर [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करें। त्रिज्या पॉइंट्स (1/72 इंच) में मापी जाती है: नॉन-निगेटिव मान उपयोग करें, बड़ी मान अधिक बल्बर उत्पन्न करते हैं। शून्य त्रिज्या से रूप unchanged रहता है।

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `False` पर, ब्लर मूल पेंटेड सीमा तक सीमित रहता है, जिसमें रूपरेखा शामिल है। `True` पर, ब्लर उन सीमाओं से बाहर तक फैल सकता है। इनमें से कोई भी सेटिंग आकार की स्थिति या आयामों को नहीं बदलती।

नीचे का तुलना समान भराव, रूपरेखा, और आकार आयामों का उपयोग करती है। शीर्ष पंक्ति `grow = False` उपयोग करती है; नीचे की पंक्ति `grow = True` उपयोग करती है।

![मूल आयत की 5 और 15 पॉइंट धुंधलापन त्रिज्या के साथ तुलना, जहाँ grow बंद और चालू है](shape_blur_comparison.png)

यह Python उदाहरण एक नारंगी आयत को गहरे नीले रूपरेखा के साथ बनाता है, 5-पॉइंट ब्लर लागू करता है, और फिर [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) को दोबारा कॉल करके इसे 15-पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर किए हुए स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) को कॉल करके ब्लर के बिना आकार को सहेजता है।

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

आकार ब्लर भराव और रूपरेखा दोनों को प्रभावित करता है। सॉफ्ट एजेज़ प्रभाव आकार के किनारों को फीका करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। छवि रूपांतरण प्रभाव छवि सामग्री पर काम करते हैं; यह उदाहरण आकार को छवि में परिवर्तित किए बिना सीधे आकार के effect format पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न प्रभावों, जैसे छाया, प्रतिबिंब, और ग्लो, को मिलाकर अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटॉशेप्स, चार्ट, तालिकाएँ, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।