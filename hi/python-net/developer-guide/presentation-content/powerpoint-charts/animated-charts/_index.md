---
title: Python में PowerPoint चार्ट्स को एनीमेट करें
linktitle: एनिमेटेड चार्ट्स
type: docs
weight: 80
url: /hi/python-net/animated-charts/
keywords:
- चार्ट
- एनिमेटेड चार्ट
- चार्ट एनीमेशन
- चार्ट सीरीज़
- चार्ट श्रेणी
- सीरीज़ तत्व
- श्रेणी तत्व
- इफ़ेक्ट जोड़ें
- इफ़ेक्ट प्रकार
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में शानदार एनिमेटेड चार्ट बनाएं। PPT, PPTX और ODP फाइलों में गतिशील विज़ुअल्स के साथ प्रेजेंटेशन को बढ़ाएँ—अभी शुरू करें।"
---
## **परिचय**

Aspose.Slides for Python via .NET चार्ट तत्वों को एनिमेट करने का समर्थन करता है। **Series**, **Categories**, **Series Elements**, **Categories Elements** को [ISequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/isequence/) मेथड और दो एनम्स [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) और [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effectchartminorgroupingtype/) का उपयोग करके एनिमेट किया जा सकता है।

## **चार्ट सीरीज़ एनीमेशन**
यदि आप किसी चार्ट सीरीज़ को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. प्रेजेंटेशन लोड करें।
1. चार्ट ऑब्जेक्ट का रेफरेंस प्राप्त करें।
1. सीरीज़ को एनिमेट करें।
1. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट सीरीज़ को एनिमेट किया है।

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Presentation क्लास को इंस्टैंशिएट करें जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # सीरीज़ को एनीमेट करें
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # परिवर्तित प्रस्तुति को डिस्क पर लिखें
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट श्रेणी एनीमेशन**
यदि आप किसी चार्ट श्रेणी को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. प्रेजेंटेशन लोड करें।
1. चार्ट ऑब्जेक्ट का रेफरेंस प्राप्त करें।
1. श्रेणी को एनिमेट करें।
1. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट श्रेणी को एनिमेट किया है।

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # श्रेणियों के तत्वों को एनीमेट करें
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # प्रेज़ेंटेशन फ़ाइल को डिस्क पर लिखें
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **सीरीज़ तत्व में एनीमेशन**
यदि आप सीरीज़ तत्वों को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. प्रेजेंटेशन लोड करें।
1. चार्ट ऑब्जेक्ट का रेफरेंस प्राप्त करें।
1. सीरीज़ तत्वों को एनिमेट करें।
1. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने सीरीज़ के तत्वों को एनिमेट किया है।

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# एक प्रस्तुति लोड करें
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # सीरीज़ तत्वों को एनीमेट करें
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # प्रेज़ेंटेशन फ़ाइल को डिस्क पर लिखें 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **श्रेणी तत्व में एनीमेशन**
यदि आप श्रेणी तत्वों को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. प्रेजेंटेशन लोड करें।
1. चार्ट ऑब्जेक्ट का रेफरेंस प्राप्त करें।
1. श्रेणी तत्वों को एनिमेट करें।
1. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने श्रेणी तत्वों को एनिमेट किया है।

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # श्रेणियों के तत्वों को एनीमेट करें
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # प्रेज़ेंटेशन फ़ाइल को डिस्क पर लिखें
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या विभिन्न इफ़ेक्ट प्रकार (जैसे, एंट्रेंस, एम्फ़ेसिस, एग्ज़िट) सामान्य आकारों की तरह चार्ट के लिए समर्थित हैं?**

हां। एक चार्ट को एक आकार के रूप में माना जाता है, इसलिए यह मानक एनीमेशन इफ़ेक्ट प्रकारों का समर्थन करता है, जिसमें एंट्रेंस, एम्फ़ेसिस और एग्ज़िट शामिल हैं, और स्लाइड की टाइमलाइन और एनीमेशन सीक्वेंसेज़ के माध्यम से पूर्ण नियंत्रण प्रदान करता है।

**क्या मैं चार्ट एनीमेशन को स्लाइड ट्रांज़िशन्स के साथ जोड़ सकता हूँ?**

हां। [Transitions](/slides/hi/python-net/slide-transition/) स्लाइड पर लागू होते हैं, जबकि एनीमेशन इफ़ेक्ट स्लाइड पर वस्तुओं पर लागू होते हैं। आप दोनों को एक ही प्रेजेंटेशन में साथ में उपयोग कर सकते हैं और उनसे स्वतंत्र रूप से नियंत्रित कर सकते हैं।

**क्या PPTX में सहेजने पर चार्ट एनीमेशन संरक्षित रहते हैं?**

हां। जब आप [save to PPTX](/slides/hi/python-net/save-presentation/) करते हैं, सभी एनीमेशन इफ़ेक्ट और उनका क्रम संरक्षित रहता है क्योंकि वे प्रेजेंटेशन के मूल एनीमेशन मॉडल का हिस्सा होते हैं।

**क्या मैं प्रेजेंटेशन से मौजूदा चार्ट एनीमेशन पढ़ सकता हूँ और उन्हें संशोधित कर सकता हूँ?**

हां। [API](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/) स्लाइड टाइमलाइन, सीक्वेंसेज़, और इफ़ेक्ट्स तक पहुंच प्रदान करता है, जिससे आप मौजूदा चार्ट एनीमेशन को निरीक्षण कर सकते हैं और उन्हें सब कुछ फिर से बनाने की आवश्यकता के बिना समायोजित कर सकते हैं।

**क्या मैं Aspose.Slides for Python via .NET का उपयोग करके चार्ट एनीमेशन सहित वीडियो बना सकता हूँ?**

हां। आप [export a presentation to video](/slides/hi/python-net/convert-powerpoint-to-video/) कर सकते हैं जबकि एनीमेशन को संरक्षित रखते हैं, टाइमिंग्स और अन्य एक्सपोर्ट सेटिंग्स को कॉन्फ़िगर करते हुए ताकि परिणामी क्लिप एनीमेटेड प्लेबैक को दर्शाए।