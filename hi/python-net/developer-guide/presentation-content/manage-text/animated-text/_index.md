---
title: Python में PowerPoint टेक्स्ट एनीमेट करें
linktitle: एनिमेटेड टेक्स्ट
type: docs
weight: 60
url: /hi/python-net/animated-text/
keywords:
- एनिमेटेड टेक्स्ट
- टेक्स्ट एनीमेशन
- एनिमेटेड पैराग्राफ
- पैराग्राफ एनीमेशन
- एनीमेशन इफ़ेक्ट
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python को .NET के माध्यम से उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में गतिशील एनिमेटेड टेक्स्ट बनाएं, आसान-से-समझने योग्य, अनुकूलित कोड उदाहरणों के साथ।"
---
## **Overview**

यह लेख Aspose.Slides for Python का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट को एनीमेट करने का तरीका दिखाता है। आप व्यक्तिगत पैराग्राफ पर इफ़ेक्ट जोड़ना, ट्रिगर समायोजित करना, और मौजूदा एनीमेशन सीक्वेंस को पढ़ना सीखेंगे। अंत में, आप पुन: उपयोग योग्य टेक्स्ट‑एनीमेशन वर्कफ़्लो बनाएंगे जो मानक PPTX में निर्यात हो सकते हैं और PowerPoint में सही ढंग से चलते हैं।

## **Add Paragraph Animation Effects**

[add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) मेथड [Sequence](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/) क्लास का उपयोग करके आप एक एकल पैराग्राफ पर एनीमेशन इफ़ेक्ट लागू कर सकते हैं। नीचे दिया गया नमूना कोड दिखाता है कि यह कैसे किया जाता है:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # इफ़ेक्ट जोड़ने के लिए पैराग्राफ चुनें।
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # चयनित पैराग्राफ में Fly एनीमेशन इफ़ेक्ट जोड़ें।
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Paragraph Animation Effects**

आप यह जानना चाहते हो सकते हैं कि किसी पैराग्राफ पर कौन से एनीमेशन इफ़ेक्ट लागू हुए हैं—उदाहरण के लिए, यदि आप उन इफ़ेक्ट को किसी अन्य पैराग्राफ या शैप में कॉपी करना चाहते हैं।

Aspose.Slides for Python आपको टेक्स्ट फ्रेम (शैप) के पैराग्राफ पर लागू सभी एनीमेशन इफ़ेक्ट को प्राप्त करने की सुविधा देता है। नीचे दिया गया नमूना कोड दिखाता है कि पैराग्राफ के एनीमेशन इफ़ेक्ट कैसे प्राप्त किए जाते हैं:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**टेक्स्ट एनीमेशन स्लाइड ट्रांज़िशन से कैसे अलग हैं, और क्या उन्हें साथ में उपयोग किया जा सकता है?**

टेक्स्ट एनीमेशन स्लाइड पर किसी ऑब्जेक्ट के व्यवहार को समय के साथ नियंत्रित करते हैं, जबकि [transitions](/slides/hi/python-net/slide-transition/) स्लाइड बदलने के तरीके को नियंत्रित करते हैं। वे स्वतंत्र होते हैं और साथ में उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**क्या टेक्स्ट एनीमेशन को PDF या इमेज में निर्यात करने पर संरक्षित रखा जाता है?**

नहीं। PDF और रास्टर इमेज स्थिर होते हैं, इसलिए आपको स्लाइड की एक ही स्थिति बिना गति के दिखाई देगी। गति को बनाए रखने के लिए आप [video](/slides/hi/python-net/convert-powerpoint-to-video/) या [HTML](/slides/hi/python-net/export-to-html5/) निर्यात का उपयोग कर सकते हैं।

**क्या टेक्स्ट एनीमेशन लेआउट और स्लाइड मास्टर में काम करते हैं?**

लेआउट/मास्टर ऑब्जेक्ट्स पर लागू इफ़ेक्ट स्लाइड्स में विरासत में मिलते हैं, लेकिन उनका टाइमिंग और स्लाइड‑लेवल एनीमेशन के साथ इंटरैक्शन अंतिम स्लाइड पर सीक्वेंस पर निर्भर करता है।