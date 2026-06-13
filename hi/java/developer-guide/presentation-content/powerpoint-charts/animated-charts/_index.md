---
title: जावा में PowerPoint चार्ट एनिमेट करें
linktitle: एनिमेटेड चार्ट
type: docs
weight: 80
url: /hi/java/animated-charts/
keywords:
- चार्ट
- एनिमेटेड चार्ट
- चार्ट एनीमेशन
- चार्ट सीरीज़
- चार्ट श्रेणी
- सीरीज़ तत्व
- श्रेणी तत्व
- प्रभाव जोड़ें
- प्रभाव प्रकार
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ जावा में शानदार एनिमेटेड चार्ट बनाएं। PPT और PPTX फ़ाइलों में गतिशील विज़ुअल्स के साथ प्रस्तुतियों को बढ़ाएँ—अभी शुरुआत करें।"
---
## **परिचय**

Aspose.Slides for Java चार्ट तत्वों को एनिमेट करने का समर्थन करता है। **Series**, **Categories**, **Series Elements**, **Categories Elements** को [ISequence.addEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) मेथड और दो एनम्स [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/EffectChartMajorGroupingType) और [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/EffectChartMinorGroupingType) के साथ एनिमेट किया जा सकता है।

## **चार्ट सीरीज़ एनीमेशन**
यदि आप एक चार्ट सीरीज़ को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
2. चार्ट ऑब्जेक्ट का संदर्भ प्राप्त करें।
3. सीरीज़ को एनिमेट करें।
4. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट सीरीज़ को एनिमेट किया।

```java
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का संदर्भ प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // सीरीज़ को एनिमेट करें
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

## **चार्ट श्रेणी एनीमेशन**
यदि आप एक चार्ट श्रेणी को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
2. चार्ट ऑब्जेक्ट का संदर्भ प्राप्त करें।
3. श्रेणी को एनिमेट करें।
4. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट श्रेणी को एनिमेट किया।

```java
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
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

## **सीरीज़ तत्व में एनीमेशन**
यदि आप सीरीज़ तत्वों को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
2. चार्ट ऑब्जेक्ट का संदर्भ प्राप्त करें।
3. सीरीज़ तत्वों को एनिमेट करें।
4. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने सीरीज़ के तत्वों को एनिमेट किया है।

```java
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का संदर्भ प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // सीरीज़ तत्वों को एनिमेट करें
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

    // प्रस्तुति फ़ाइल को डिस्क पर लिखें 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **श्रेणी तत्व में एनीमेशन**
यदि आप श्रेणी तत्वों को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
2. चार्ट ऑब्जेक्ट का संदर्भ प्राप्त करें।
3. श्रेणी तत्वों को एनिमेट करें।
4. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने श्रेणी तत्वों को एनिमेट किया है।

```java
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का संदर्भ प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // श्रेणियों के तत्वों को एनिमेट करें
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

    // प्रस्तुति फ़ाइल को डिस्क पर लिखें
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या चार्ट के लिए विभिन्न प्रभाव प्रकार (जैसे प्रवेश, ज़ोर, निकास) सामान्य आकृतियों की तरह समर्थित हैं?**  
हाँ। एक चार्ट को एक आकृति के रूप में माना जाता है, इसलिए यह मानक एनीमेशन प्रभाव प्रकारों, जैसे प्रवेश, ज़ोर, और निकास, को सपोर्ट करता है, और स्लाइड की टाइमलाइन और एनीमेशन क्रमों के माध्यम से पूर्ण नियंत्रण प्रदान करता है।

**क्या मैं चार्ट एनीमेशन को स्लाइड ट्रांज़िशन के साथ संयोजित कर सकता हूँ?**  
हाँ। [Transitions](/slides/hi/java/slide-transition/) स्लाइड पर लागू होते हैं, जबकि एनीमेशन प्रभाव स्लाइड पर मौजूद वस्तुओं पर लागू होते हैं। आप दोनों को एक ही प्रस्तुति में साथ में उपयोग कर सकते हैं और उन्हें स्वतंत्र रूप से नियंत्रित कर सकते हैं।

**क्या PPTX में सहेजते समय चार्ट एनीमेशन संरक्षित रहते हैं?**  
हाँ। जब आप [save to PPTX](/slides/hi/java/save-presentation/) करते हैं, तो सभी एनीमेशन प्रभाव और उनका क्रम संरक्षित रहता है क्योंकि वे प्रस्तुति के मूल एनीमेशन मॉडल का हिस्सा हैं।

**क्या मैं प्रस्तुति से मौजूदा चार्ट एनीमेशन पढ़ सकता हूँ और उन्हें संशोधित कर सकता हूँ?**  
हाँ। API स्लाइड टाइमलाइन, क्रम और प्रभावों तक पहुंच प्रदान करता है, जिससे आप मौजूदा चार्ट एनीमेशन का निरीक्षण कर सकते हैं और उन्हें पूरी तरह से पुनः निर्मित किए बिना समायोजित कर सकते हैं।

**क्या मैं Aspose.Slides का उपयोग करके चार्ट एनीमेशन सहित एक वीडियो बना सकता हूँ?**  
हाँ। आप [export a presentation to video](/slides/hi/java/convert-powerpoint-to-video/) कर सकते हैं, एनीमेशन को संरक्षित रखते हुए, टाइमिंग और अन्य निर्यात सेटिंग्स को कॉन्फ़िगर करके ताकि परिणामी क्लिप एनीमेटेड प्लेबैक को दर्शाए।