---
title: .NET में PowerPoint चार्ट को एनीमेट करें
linktitle: एनीमेटेड चार्ट्स
type: docs
weight: 80
url: /hi/net/animated-charts/
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
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides के साथ .NET में शानदार एनीमेटेड चार्ट बनाएं। PPT और PPTX फ़ाइलों में गतिशील दृश्यों के साथ प्रेजेंटेशन को बढ़ाएं—अभी शुरू करें।"
---
## **परिचय**

Aspose.Slides for .NET चार्ट तत्वों को एनीमेट करने का समर्थन करता है। **Series**, **Categories**, **Series Elements**, **Categories Elements** को [ISequence.AddEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/methods/addeffect) मेथड और दो एनम्स [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effectchartmajorgroupingtype) और [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effectchartminorgroupingtype) के साथ एनीमेट किया जा सकता है।

## **चार्ट सीरीज़ एनीमेशन**
यदि आप एक चार्ट सीरीज़ को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध कदमों के अनुसार कोड लिखें:

1. प्रेजेंटेशन लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. सीरीज़ को एनीमेट करें।
1. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट सीरीज़ को एनीमेट किया है।

```c#
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // सीरीज़ को एनीमेट करें
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // संशोधित प्रस्तुति को डिस्क पर लिखें 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **चार्ट श्रेणी एनीमेशन**
यदि आप एक चार्ट श्रेणी को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध कदमों के अनुसार कोड लिखें:

1. प्रेजेंटेशन लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. श्रेणी को एनीमेट करें।
1. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट श्रेणी को एनीमेट किया है।

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // श्रेणियों के तत्वों को एनीमेट करें
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // प्रस्तुति फ़ाइल को डिस्क पर लिखें
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **सीरीज़ एलिमेंट में एनीमेशन**
यदि आप सीरीज़ एलिमेंट्स को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध कदमों के अनुसार कोड लिखें:

1. प्रेजेंटेशन लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. सीरीज़ एलिमेंट्स को एनीमेट करें।
1. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने सीरीज़ के एलिमेंट्स को एनीमेट किया है।

```c#
// एक प्रस्तुति लोड करें
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // सीरीज़ एलिमेंट्स को एनीमेट करें
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // प्रस्तुति फ़ाइल को डिस्क पर लिखें 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **श्रेणी एलिमेंट में एनीमेशन**
यदि आप श्रेणी एलिमेंट्स को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध कदमों के अनुसार कोड लिखें:

1. प्रेजेंटेशन लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. श्रेणी एलिमेंट्स को एनीमेट करें।
1. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने श्रेणी एलिमेंट्स को एनीमेट किया है।

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // श्रेणियों के तत्वों को एनीमेट करें
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // प्रस्तुति फ़ाइल को डिस्क पर लिखें
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या विभिन्न इफ़ेक्ट प्रकार (जैसे, एंट्रेंस, एम्फ़े़सिस, एग्ज़िट) चार्ट्स के लिए सामान्य आकृतियों की तरह समर्थित हैं?**

हाँ। एक चार्ट को एक आकार माना जाता है, इसलिए यह मानक एनीमेशन इफ़ेक्ट प्रकारों का समर्थन करता है, जिसमें एंट्रेंस, एम्फ़े़सिस, और एग्ज़िट शामिल हैं, और स्लाइड की टाइमलाइन तथा एनीमेशन सीक्वेंसेज़ के माध्यम से पूर्ण नियंत्रण प्रदान करता है।

**क्या मैं चार्ट एनीमेशन को स्लाइड ट्रांज़िशन के साथ संयोजित कर सकता हूँ?**

हाँ। [ट्रांज़िशन](/slides/hi/net/slide-transition/) स्लाइड पर लागू होते हैं, जबकि एनीमेशन इफ़ेक्ट्स स्लाइड पर वस्तुओं पर लागू होते हैं। आप दोनों को एक ही प्रस्तुति में साथ प्रयोग कर सकते हैं और उन्हें स्वतंत्र रूप से नियंत्रित कर सकते हैं।

**क्या PPTX में सहेजते समय चार्ट एनीमेशन संरक्षित रहते हैं?**

हाँ। जब आप [PPTX में सहेजें](/slides/hi/net/save-presentation/) करते हैं, सभी एनीमेशन इफ़ेक्ट्स और उनका क्रम संरक्षित रहता है क्योंकि वे प्रस्तुति के मूल एनीमेशन मॉडल का हिस्सा हैं।

**क्या मैं किसी प्रस्तुति से मौजूदा चार्ट एनीमेशन पढ़ सकता हूँ और उन्हें संशोधित कर सकता हूँ?**

हाँ। [API](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/) स्लाइड टाइमलाइन, सीक्वेंसेस और इफ़ेक्ट्स तक पहुँच प्रदान करता है, जिससे आप मौजूदा चार्ट एनीमेशन का निरीक्षण कर सकते हैं और उन्हें पुनः निर्मित किए बिना संशोधित कर सकते हैं।

**क्या मैं Aspose.Slides का उपयोग करके चार्ट एनीमेशन सहित एक वीडियो बना सकता हूँ?**

हाँ। आप [प्रेजेंटेशन को वीडियो में निर्यात करें](/slides/hi/net/convert-powerpoint-to-video/) कर सकते हैं जबकि एनीमेशन को संरक्षित रखते हैं, टाइमिंग और अन्य निर्यात सेटिंग्स को कॉन्फ़िगर करके ताकि परिणामी क्लिप एनीमेटेड प्लेबैक को दर्शाए।