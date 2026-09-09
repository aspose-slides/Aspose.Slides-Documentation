---
title: Python via Java में PowerPoint टेक्स्ट को एनीमेट करें
linktitle: एनीमेटेड टेक्स्ट
type: docs
weight: 60
url: /hi/python-java/animated-text/
keywords:
- एनीमेटेड टेक्स्ट
- टेक्स्ट एनीमेशन
- एनीमेटेड पैराग्राफ
- पैराग्राफ एनीमेशन
- एनीमेशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में गतिशील एनीमेटेड टेक्स्ट बनाएं, आसान-से-समझने योग्य, अनुकूलित Python कोड उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides में एनीमेटेड टेक्स्ट के साथ कैसे काम करें, व्यक्तिगत पैराग्राफ़ पर एनीमेशन इफ़ेक्ट लागू करके और टेक्स्ट फ़्रेम में पैराग्राफ़ को पहले से असाइन किए गए इफ़ेक्ट को प्राप्त करके। यह प्रस्तुति में पैराग्राफ‑स्तर की एनीमेशन जोड़ने और मौजूदा पैराग्राफ़ एनीमेशन इफ़ेक्ट का निरीक्षण करने के लिए उपयोग किए जाने वाले API मेथड पर केंद्रित है।

## **पैराग्राफ़ में एनीमेशन प्रभाव जोड़ें**

[addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) मेथड, जो [Sequence](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/) क्लास का हिस्सा है, आपको एक पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ने की अनुमति देता है। यह नमूना कोड दर्शाता है कि कैसे एक पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # पैराग्राफ़ चुनें जिस पर प्रभाव जोड़ना है।
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # चयनित पैराग्राफ़ पर Fly एनीमेशन प्रभाव जोड़ें।
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **पैराग्राफ़ के एनीमेशन इफ़ेक्ट प्राप्त करें**

आप किसी पैराग्राफ़ पर लागू किए गए एनीमेशन इफ़ेक्ट को प्राप्त करना चाह सकते हैं—उदाहरण के तौर पर, उन इफ़ेक्ट को किसी अन्य पैराग्राफ़ या शैप पर लागू करने के लिए।

Aspose.Slides for Python via Java आपको टेक्स्ट फ़्रेम (शैप) में मौजूद पैराग्राफ़ पर लागू सभी एनीमेशन इफ़ेक्ट प्राप्त करने की सुविधा देता है। यह नमूना कोड दर्शाता है कि कैसे एक पैराग्राफ़ पर लागू एनीमेशन इफ़ेक्ट प्राप्त किए जाएँ:

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

टेक्स्ट एनीमेशन स्लाइड पर वस्तु के व्यवहार को समय के साथ नियंत्रित करते हैं, जबकि [transitions](/slides/hi/python-java/slide-transition/) स्लाइडों के बदलने के तरीके को नियंत्रित करते हैं। वे स्वतंत्र हैं और साथ में उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**PDF या इमेज़ में एक्सपोर्ट करते समय क्या टेक्स्ट एनीमेशन संरक्षित रहते हैं?**

नहीं। PDF और रैस्टर इमेज़ स्थैतिक होते हैं, इसलिए आपको स्लाइड की एक ही स्थिति बिना गति के दिखेगी। गति को बनाए रखने के लिए, [video](/slides/hi/python-java/convert-powerpoint-to-video/) या [HTML](/slides/hi/python-java/export-to-html5/) एक्सपोर्ट का उपयोग करें।

**क्या टेक्स्ट एनीमेशन लेआउट और स्लाइड मास्टर में काम करते हैं?**

लेआउट/मास्टर ऑब्जेक्ट पर लागू किए गए इफ़ेक्ट स्लाइडों द्वारा वंशानुगत रूप से प्राप्त होते हैं, लेकिन उनका समय निर्धारण और स्लाइड‑स्तर की एनीमेशन के साथ इंटरैक्शन अंतिम स्लाइड अनुक्रम पर निर्भर करता है।