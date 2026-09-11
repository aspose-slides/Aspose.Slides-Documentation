---
title: Python के माध्यम से Java का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/python-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- चमक प्रभाव
- नरम किनारा प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकण्डों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को उजागर करने के लिए किया जा सकता है, लेकिन ये [fills](/slides/hi/python-java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब, चमक (glow) आदि बना सकते हैं।

<img src="shape-effect.png" alt="आकार-प्रभाव" style="zoom:50%;" />

* PowerPoint छः प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक आकार पर एक या अधिक प्रभाव लगा सकते हैं।  

* कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर लगते हैं। इसी कारण PowerPoint **Preset** के अंतर्गत विकल्प प्रदान करता है। Preset विकल्प मूलतः दो या अधिक प्रभावों के ऐसे संयोजन हैं जो दिखने में अच्छे होते हैं। इस प्रकार, किसी preset को चुनकर आप विभिन्न प्रभावों को परीक्षण या संयोजित करने में समय बर्बाद नहीं करेंगे।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effectformat/) क्लास के तहत प्रॉपर्टीज़ और मेथड्स प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर वही प्रभाव लागू करने की अनुमति देते हैं।

## **शैडो प्रभाव लागू करें**

यह Python कोड आपको दिखाता है कि कैसे आयत पर बाहरी शैडो प्रभाव ([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effectformat/#getOuterShadowEffect)) लागू किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **रिफ्लेक्शन प्रभाव लागू करें**

यह Python कोड आपको दिखाता है कि कैसे किसी आकार पर रिफ्लेक्शन प्रभाव लागू किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ग्लो प्रभाव लागू करें**

यह Python कोड आपको दिखाता है कि कैसे किसी आकार पर ग्लो प्रभाव लागू किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **सॉफ्ट एजेज़ प्रभाव लागू करें**

यह Python कोड आपको दिखाता है कि कैसे किसी आकार पर सॉफ्ट एजेज़ प्रभाव लागू किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप शैडो, रिफ्लेक्शन और ग्लो जैसे विभिन्न प्रभावों को एक ही आकार पर मिलाकर अधिक गतिशील दिखावट बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोशेप, चार्ट, तालिका, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट आदि शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।