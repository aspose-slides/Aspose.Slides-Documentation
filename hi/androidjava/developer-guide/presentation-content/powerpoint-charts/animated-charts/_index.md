---
title: Android पर PowerPoint चार्ट्स को एनीमेट करें
linktitle: एनीमेटेड चार्ट्स
type: docs
weight: 80
url: /hi/androidjava/animated-charts/
keywords:
- चार्ट
- एनीमेटेड चार्ट
- चार्ट एनीमेशन
- चार्ट सीरीज़
- चार्ट श्रेणी
- सीरीज़ तत्व
- श्रेणी तत्व
- इफ़ेक्ट जोड़ें
- इफ़ेक्ट प्रकार
- PowerPoint
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java में शानदार एनीमेटेड चार्ट बनाएं। PPT और PPTX फ़ाइलों में गतिशील दृश्यों के साथ प्रेज़ेंटेशन को बढ़ावा दें—अब शुरू करें।"
---
## **परिचय**

Aspose.Slides for Android via Java चार्ट तत्वों को एनिमेट करने का समर्थन करता है। **Series**, **Categories**, **Series Elements**, **Categories Elements** को [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) मेथड और दो एनम [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/EffectChartMajorGroupingType) तथा [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/EffectChartMinorGroupingType) के साथ एनिमेट किया जा सकता है।

## **चार्ट सीरीज़ एनिमेशन**
यदि आप चार्ट सीरीज़ को एनिमेट करना चाहते हैं, तो नीचे दिए गए चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. सीरीज़ को एनिमेट करें।
1. प्रेज़ेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट सीरीज़ को एनिमेट किया है।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // सीरीज़ को एनीमेट करें
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट श्रेणी एनिमेशन**
यदि आप चार्ट श्रेणी को एनिमेट करना चाहते हैं, तो नीचे दिए गए चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. श्रेणी को एनिमेट करें।
1. प्रेज़ेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट श्रेणी को एनिमेट किया है।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीरीज़ तत्व में एनिमेशन**
यदि आप सीरीज़ तत्वों को एनिमेट करना चाहते हैं, तो नीचे दिए गए चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. सीरीज़ तत्वों को एनिमेट करें।
1. प्रेज़ेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने सीरीज़ तत्वों को एनिमेट किया है।

```java
// प्रेज़ेंटेशन फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // सीरीज़ तत्वों को एनीमेट करें
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Write the presentation file to disk 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **श्रेणी तत्व में एनिमेशन**
यदि आप श्रेणी तत्वों को एनिमेट करना चाहते हैं, तो नीचे दिए गए चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
1. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
1. श्रेणी तत्वों को एनिमेट करें।
1. प्रेज़ेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने श्रेणी तत्वों को एनिमेट किया है।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // श्रेणियों के तत्वों को एनीमेट करें
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // प्रेज़ेंटेशन फ़ाइल को डिस्क पर लिखें
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या विभिन्न इफ़ेक्ट प्रकार (जैसे, प्रवेश, ज़ोर, बाहर निकलना) चार्ट्स के लिए सामान्य आकारों की तरह समर्थित हैं?**

हाँ। एक चार्ट को आकार के रूप में माना जाता है, इसलिए यह मानक एनीमेशन इफ़ेक्ट प्रकारों का समर्थन करता है, जिसमें प्रवेश, ज़ोर, और बाहर निकलना शामिल हैं, तथा स्लाइड की टाइमलाइन और एनीमेशन सीक्वेंस के माध्यम से पूर्ण नियंत्रण प्रदान करता है।

**क्या मैं चार्ट एनीमेशन को स्लाइड ट्रांज़िशन के साथ संयोजित कर सकता हूँ?**

हाँ। [Transitions](/slides/hi/androidjava/slide-transition/) स्लाइड पर लागू होते हैं, जबकि एनीमेशन इफ़ेक्ट स्लाइड पर मौजूद ऑब्जेक्ट्स पर लागू होते हैं। आप दोनों को एक ही प्रेज़ेंटेशन में एक साथ उपयोग कर सकते हैं और उन्हें स्वतंत्र रूप से नियंत्रित कर सकते हैं।

**क्या चार्ट एनीमेशन PPTX में सहेजते समय संरक्षित रहते हैं?**

हाँ। जब आप [save to PPTX](/slides/hi/androidjava/save-presentation/) करते हैं, तो सभी एनीमेशन इफ़ेक्ट और उनका क्रम संरक्षित रहता है क्योंकि वे प्रेज़ेंटेशन के मूल एनीमेशन मॉडल का हिस्सा होते हैं।

**क्या मैं किसी प्रेज़ेंटेशन से मौजूदा चार्ट एनीमेशन पढ़ सकता हूँ और उन्हें संशोधित कर सकता हूँ?**

हाँ। API स्लाइड की टाइमलाइन, सीक्वेंस और इफ़ेक्ट्स तक पहुँच प्रदान करता है, जिससे आप मौजूदा चार्ट एनीमेशन को निरीक्षण कर सकते हैं और उन्हें बुनियाद से पुनः बनाने की आवश्यकता के बिना समायोजित कर सकते हैं।

**क्या मैं Aspose.Slides का उपयोग करके चार्ट एनीमेशन सहित एक वीडियो बना सकता हूँ?**

हाँ। आप [export a presentation to video](/slides/hi/androidjava/convert-powerpoint-to-video/) का उपयोग करके एनीमेशन को संरक्षित रखते हुए, टाइमिंग और अन्य निर्यात सेटिंग्स को कॉन्फ़िगर करके, एक वीडियो बना सकते हैं जिससे परिणामी क्लिप एनीमेटेड प्लेबैक को दर्शाए।