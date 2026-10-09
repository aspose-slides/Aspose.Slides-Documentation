---
title: प्रस्तुतीकरण में Python via Java का उपयोग करके आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/python-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- ग्लो प्रभाव
- सॉफ्ट एजेस प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके अपने PPT और PPTX फ़ाइलों को उन्नत आकार प्रभावों के साथ बदलें—सेकंड में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, ये [भरण](/slides/hi/python-java/shape-formatting/#gradient-fill) या रूपरेखाओं से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर वास्तविक प्रतिबिंब बना सकते हैं, आकार की चमक फैलासकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint आकारों पर लागू किए जा सकने वाले छह प्रभाव प्रदान करता है। आप एक आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।

किसी प्रभाव के कुछ संयोजन अन्य की तुलना में बेहतर दिखते हैं। इसी कारण से, PowerPoint **पूर्वनिर्धारित** विकल्प प्रदान करता है। पूर्वनिर्धारित विकल्प दो या अधिक प्रभावों के ऐसे संयोजन होते हैं जो दिखने में अच्छे माने जाते हैं। इस प्रकार, किसी पूर्वनिर्धारित को चुनकर, आपको विभिन्न प्रभावों को परीक्षण या संयोजित करने में समय बर्बाद नहीं करना पड़ेगा ताकि एक अच्छा संयोजन मिले।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) क्लास के तहत गुण और विधियाँ प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर वही प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Python via Java आकृतियों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी और धुंधलापन त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुरूप अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड पृष्ठभूमि के विरुद्ध कार्ड या पैनल को प्रमुख बनाने के लिए बाहरी छाया का उपयोग करें। छाया आकार की किनारों से बाहर तक विस्तारित होती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड से ऊपर उठ गया है। इसके रंग, दिशा, दूरी और धुंधलापन त्रिज्या को अपने टेम्प्लेट की रोशनी और शैली के अनुरूप समायोजित करें।

यह Python कोड दिखाता है कि कैसे एक आयत पर [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) लागू किया जा सकता है:
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

### **आंतरिक छाया लागू करें**

जब टेम्प्लेट की दृश्य शैली को दोहराते हैं, तो कार्ड या पैनल को अंदरूनी धंसाव दिखाने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर तक फैली होती है और इसे उठे हुए जैसा दिखाती है, जबकि आंतरिक छाया इसकी किनारों के अंदर को छाया देती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाई गई छाया को कॉन्फ़िगर करें। बड़े धुंधलापन त्रिज्या मान मुलायम किनारे उत्पन्न करते हैं।

यह Python उदाहरण हल्के नीले कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, उसकी दूरी 7 पॉइंट्स है, और धुंधलापन त्रिज्या 6 पॉइंट्स है:
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

![आंतरिक छाया वाली हल्की नीली आयत](inner_shadow_effect.png)

आंतरिक छाया को हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

## **प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for Python via Java में प्रतिबिंब प्रभाव लागू करने के लिए, आप आकृतियों में दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर को समायोजित करके। यह प्रभाव आपकी प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकृतियों को अधिक परिष्कृत और उन्नत रूप देता है। इसे सरल कोड के साथ लागू करना आसान है, जिससे कई तत्वों पर तेज़ी से लागू करके एक समान डिजाइन प्राप्त किया जा सकता है।

यह Python कोड दिखाता है कि कैसे एक आकार पर [प्रतिबिंब प्रभाव](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) लागू किया जाए:
```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

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

Aspose.Slides for Python via Java में किसी आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकार के आसपास एक नरम, उज्ज्वल माहौल जोड़ सकते हैं, रंग और आकार जैसी गुणों को समायोजित करके। यह प्रभाव आकारों को प्रमुख बनाने में मदद करता है और आपकी प्रस्तुति में आकर्षक, दृष्टिगोचर दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ लागू करना आसान है, जो आपके स्लाइड्स की समग्र दिखावट को बढ़ाता है।

यह Python कोड दिखाता है कि कैसे एक आकार पर [ग्लो प्रभाव](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) को लागू किया जाए:
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

## **नरम किनारे प्रभाव लागू करें**

Aspose.Slides for Python via Java में सॉफ्ट एजेस प्रभाव लागू करने के लिए, आप आकार के किनारों के आसपास एक सुगमा, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, उन डिज़ाइनों के लिए उपयुक्त है जिन्हें हल्के, नरम रूप की आवश्यकता होती है। आप आसानी से त्रिज्या जैसे पैरामीटर को समायोजित करके अपनी प्रस्तुति में विभिन्न आकारों पर इच्छित प्रभाव प्राप्त कर सकते हैं।

यह Python कोड दिखाता है कि कैसे एक आकार पर [सॉफ्ट एजेस प्रभाव](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) लागू किया जाए:
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

![सॉफ्ट एजेस प्रभाव](soft_edges_effect.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न प्रभावों जैसे छाया, प्रतिबिंब और ग्लो को मिलाकर अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोशेप्स, चार्ट, तालिकाएँ, चित्र, स्मार्टआर्ट ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स और अन्य शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।