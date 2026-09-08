---
title: Python के माध्यम से Java में PowerPoint टेक्स्ट को एनीमेट करें
linktitle: एनिमेटेड टेक्स्ट
type: docs
weight: 60
url: /hi/python-java/animated-text/
keywords:
- एनिमेटेड टेक्स्ट
- टेक्स्ट एनीमेशन
- एनिमेटेड पैराग्राफ
- पैराग्राफ एनीमेशन
- एनीमेशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में गतिशील एनिमेटेड टेक्स्ट बनाएं, आसान-से-फॉलो, अनुकूलित Python कोड उदाहरणों के साथ।"
---
## **परिचय**

यह लेख Aspose.Slides में एनिमेटेड टेक्स्ट के साथ काम करने के तरीके को समझाता है, जहाँ आप व्यक्तिगत पैराग्राफ़ पर एनीमेशन इफ़ेक्ट लागू कर सकते हैं और टेक्स्ट फ़्रेम में पैराग्राफ़ को पहले से सौंपे गए इफ़ेक्ट को पुनः प्राप्त कर सकते हैं। यह प्रस्तुति में पैराग्राफ स्तर की एनीमेशन जोड़ने और मौजूदा पैराग्राफ एनीमेशन इफ़ेक्ट की जांच करने के लिए उपयोग किए जाने वाले API मेथड्स पर केंद्रित है।

## **पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ें**

क्लास [Sequence](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/) की [addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) मेथड आपको एकल पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ने की सुविधा देती है। यह नमूना कोड आपको दिखाता है कि कैसे एकल पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # प्रभाव जोड़ने के लिए पैराग्राफ़ चुनें।
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # चयनित पैराग्राफ़ पर Fly एनीमेशन इफ़ेक्ट जोड़ें।
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **पैराग्राफ़ के एनीमेशन इफ़ेक्ट प्राप्त करें**

आप यह जानने का निर्णय ले सकते हैं कि किसी पैराग्राफ़ में कौन से एनीमेशन इफ़ेक्ट जोड़े गये हैं—उदाहरण के लिए, एक स्थिति में आप किसी पैराग्राफ़ के एनीमेशन इफ़ेक्ट प्राप्त करना चाहते हैं क्योंकि आप उन इफ़ेक्ट को किसी अन्य पैराग्राफ़ या आकार पर लागू करने का इरादा रखते हैं।

Aspose.Slides for Python via Java आपको टेक्स्ट फ़्रेम (शेप) में मौजूद पैराग्राफ़ पर लागू सभी एनीमेशन इफ़ेक्ट प्राप्त करने की अनुमति देता है। यह नमूना कोड आपको दर्शाता है कि कैसे पैराग्राफ़ में एनीमेशन इफ़ेक्ट प्राप्त किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पाठ एनीमेशन स्लाइड ट्रांज़िशन से कैसे अलग होते हैं, और क्या उन्हें मिलाया जा सकता है?**  
टेक्स्ट एनीमेशन स्लाइड पर वस्तु के व्यवहार को समय के साथ नियंत्रित करते हैं, जबकि [transitions](/slides/hi/python-java/slide-transition/) स्लाइडों के बदलने के तरीके को नियंत्रित करता है। ये स्वतंत्र होते हैं और साथ में उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**क्या टेक्स्ट एनीमेशन पीडीएफ या इमेज में निर्यात करने पर संरक्षित रहते हैं?**  
नहीं। PDF और रास्टर इमेज स्थैतिक होते हैं, इसलिए आप स्लाइड की एक ही स्थिति बिना गति के देखेंगे। गति को बनाए रखने के लिए, [video](/slides/hi/python-java/convert-powerpoint-to-video/) या [HTML](/slides/hi/python-java/export-to-html5/) निर्यात का उपयोग करें।

**क्या टेक्स्ट एनीमेशन लेआउट और स्लाइड मास्टर में कार्य करते हैं?**  
लेआउट/मास्टर वस्तुओं पर लागू इफ़ेक्ट स्लाइड्स द्वारा विरासत में प्राप्त होते हैं, लेकिन उनका समय निर्धारण और स्लाइड-स्तर की एनीमेशन के साथ क्रिया स्लाइड पर अंतिम क्रम पर निर्भर करती है।