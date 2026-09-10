---
title: Python के द्वारा Java में PowerPoint चार्ट्स को एनीमेट करें
linktitle: एनीमेटेड चार्ट्स
type: docs
weight: 80
url: /hi/python-java/animated-charts/
keywords:
- चार्ट
- एनीमेटेड चार्ट
- चार्ट एनीमेशन
- चार्ट सीरीज़
- चार्ट श्रेणी
- सीरीज़ एलिमेंट
- श्रेणी एलिमेंट
- इफ़ेक्ट जोड़ें
- इफ़ेक्ट प्रकार
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python के माध्यम से Java में शानदार एनीमेटेड चार्ट बनाएँ। PPT और PPTX फ़ाइलों में गतिशील दृश्यों से प्रस्तुतियों को बढ़ाएँ—अभी शुरू करें।"
---
## **परिचय**

Aspose.Slides for Python via Java चार्ट तत्वों के एनिमेशन को समर्थन देता है। **Series**, **Categories**, **Series Elements**, और **Category Elements** को [Sequence.addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) मेथड और दो एन्यूमरेशन्स: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effectchartmajorgroupingtype/) और [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effectchartminorgroupingtype/) का उपयोग करके एनीमेट किया जा सकता है।

## **चार्ट सीरीज़ एनीमेशन**

यदि आप एक चार्ट सीरीज़ को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. सीरीज़ को एनीमेट करें।
1. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

निम्न उदाहरण चार्ट सीरीज़ को एनीमेट करता है। उदाहरण फ़ाइल में चार्ट में तीन सीरीज़ हैं, इसलिए 0 से 2 तक के प्रत्येक इंडेक्स के लिए एक इफ़ेक्ट जोड़ा जाता है। Aspose.Slides इंडेक्स को चार्ट डेटा के विरुद्ध नहीं जांचता, और जो इफ़ेक्ट किसी गैर-मौजूद सीरीज़ के लिए जोड़ा जाता है, वह फ़ाइल में लिखा जाता है लेकिन कुछ भी एनीमेट नहीं करता—अपने स्वयं के चार्ट में सीरीज़ की संख्या से कम इंडेक्स रखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# प्रस्तुति लोड करें।
presentation = Presentation("ExistingChart.pptx")
try:
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # चार्ट तत्वों को एनीमेट करें।
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # संशोधित प्रस्तुति को डिस्क पर लिखें।
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट श्रेणी एनीमेशन**

यदि आप एक चार्ट श्रेणी को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. श्रेणी को एनीमेट करें।
1. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# प्रस्तुति लोड करें।
presentation = Presentation("ExistingChart.pptx")
try:
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # चार्ट तत्वों को एनीमेट करें।
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # संशोधित प्रस्तुति को डिस्क पर लिखें।
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **सीरीज़ एलिमेंट में एनीमेशन**

यदि आप सीरीज़ एलिमेंट को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. सीरीज़ एलिमेंट को एनीमेट करें।
1. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# प्रस्तुति लोड करें।
presentation = Presentation("ExistingChart.pptx")
try:
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # चार्ट तत्वों को एनीमेट करें.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # संशोधित प्रस्तुति को डिस्क पर लिखें.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **श्रेणी एलिमेंट में एनीमेशन**

यदि आप श्रेणी एलिमेंट को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. श्रेणी एलिमेंट को एनीमेट करें।
1. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# प्रस्तुति लोड करें।
presentation = Presentation("ExistingChart.pptx")
try:
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # चार्ट तत्वों को एनीमेट करें।
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # संशोधित प्रस्तुति को डिस्क पर लिखें।
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या चार्ट के लिए विभिन्न इफ़ेक्ट प्रकार (जैसे, प्रवेश, ज़ोर, निकास) सामान्य आकारों की तरह समर्थित हैं?**

हां। एक चार्ट को आकार (शेप) के रूप में माना जाता है, इसलिए यह मानक एनीमेशन इफ़ेक्ट प्रकारों का समर्थन करता है, जिसमें प्रवेश, ज़ोर, और निकास शामिल हैं, तथा स्लाइड की टाइमलाइन और एनीमेशन सीक्वेंस द्वारा पूर्ण नियंत्रण प्रदान करता है।

**क्या मैं चार्ट एनीमेशन को स्लाइड ट्रांज़िशन के साथ संयोजित कर सकता हूँ?**

हां। [Transitions](/slides/hi/python-java/slide-transition/) स्लाइड पर लागू होते हैं, जबकि एनीमेशन इफ़ेक्ट स्लाइड के ऑब्जेक्ट्स पर लागू होते हैं। आप दोनों को एक ही प्रस्तुति में साथ प्रयोग कर सकते हैं और उन्हें स्वतंत्र रूप से नियंत्रित कर सकते हैं।

**क्या PPTX में सहेजते समय चार्ट एनीमेशन संरक्षित रहते हैं?**

हां। जब आप [save to PPTX](/slides/hi/python-java/save-presentation/) करते हैं, तो सभी एनीमेशन इफ़ेक्ट और उनका क्रम संरक्षित रहता है क्योंकि वे प्रस्तुति के मूल एनीमेशन मॉडल का हिस्सा होते हैं।

**क्या मैं किसी प्रस्तुति से मौजूदा चार्ट एनीमेशन को पढ़ सकता हूँ और उन्हें संशोधित कर सकता हूँ?**

हां। API स्लाइड टाइमलाइन, सीक्वेंस और इफ़ेक्ट्स तक पहुँच प्रदान करता है, जिससे आप मौजूदा चार्ट एनीमेशन को निरीक्षण कर सकते हैं और उन्हें शून्य से पुनः निर्मित किए बिना समायोजित कर सकते हैं।

**क्या मैं Aspose.Slides का उपयोग करके चार्ट एनीमेशन सहित एक वीडियो बना सकता हूँ?**

हां। आप [export a presentation to video](/slides/hi/python-java/convert-powerpoint-to-video/) का उपयोग करके एनीमेशन को संरक्षित रखते हुए प्रस्तुति को वीडियो में निर्यात कर सकते हैं, टाइमिंग और अन्य निर्यात सेटिंग्स को कॉन्फ़िगर कर सकते हैं ताकि परिणामी क्लिप एनीमेटेड प्लेबैक को दर्शाए।