---
title: जावास्क्रिप्ट में PowerPoint चार्ट्स को एनीमेट करें
linktitle: एनीमेटेड चार्ट्स
type: docs
weight: 80
url: /hi/nodejs-java/animated-charts/
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
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ जावास्क्रिप्ट में शानदार एनीमेटेड चार्ट बनाएँ। PPT और PPTX फ़ाइलों में गतिशील दृश्य के साथ प्रेजेंटेशन को बेहतर बनाएं — अभी शुरू करें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java चार्ट तत्वों को एनीमेट करने का समर्थन करता है। **Series**, **Categories**, **Series Elements**, **Categories Elements** को [Sequence.addEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#addEffect) मेथड और दो एनम्स [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) और [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effectchartminorgroupingtype/) के साथ एनीमेट किया जा सकता है।

## **चार्ट सीरीज़ एनीमेशन**
यदि आप चार्ट सीरीज़ को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रेजेंटेशन लोड करें।
2. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
3. सीरीज़ को एनीमेट करें।
4. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

निचे दिए गए उदाहरण में, हमने चार्ट सीरीज़ को एनीमेट किया।

```javascript
// एक Presentation क्लास का उदाहरण बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // सीरीज़ को एनीमेट करें
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // संशोधित प्रेजेंटेशन को डिस्क पर लिखें
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट श्रेणी एनीमेशन**
यदि आप चार्ट श्रेणी को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रेजेंटेशन लोड करें।
2. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
3. श्रेणी को एनीमेट करें।
4. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट श्रेणी को एनीमेट किया।

```javascript
// एक Presentation क्लास का उदाहरण बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सीरीज़ तत्व में एनीमेशन**
यदि आप सीरीज़ तत्वों को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रेजेंटेशन लोड करें।
2. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
3. सीरीज़ तत्वों को एनीमेट करें।
4. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने सीरीज़ के तत्वों को एनीमेट किया है।

```javascript
// एक Presentation क्लास का उदाहरण बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // सीरीज़ तत्वों को एनीमेट करें
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **श्रेणी तत्व में एनीमेशन**
यदि आप श्रेणी तत्वों को एनीमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रेजेंटेशन लोड करें।
2. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
3. श्रेणी तत्वों को एनीमेट करें।
4. प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने श्रेणी तत्वों को एनीमेट किया है।

```javascript
// एक Presentation क्लास का उदाहरण बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // श्रेणियों के तत्वों को एनीमेट करें
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या चार्ट के लिए विभिन्न प्रभाव प्रकार (जैसे एंट्रेंस, एम्फ़ेसिस, एग्ज़िट) साधारण आकारों की तरह समर्थित हैं?**

हाँ। एक चार्ट को आकार (शेप) के रूप में माना जाता है, इसलिए यह मानक एनीमेशन प्रभाव प्रकारों का समर्थन करता है, जिसमें एंट्रेंस, एम्फ़ेसिस और एग्ज़िट शामिल हैं, और स्लाइड की टाइमलाइन और एनीमेशन सीक्वेंस के माध्यम से पूर्ण नियंत्रण प्रदान करता है।

**क्या मैं चार्ट एनीमेशन को स्लाइड ट्रांज़िशन के साथ संयोजित कर सकता हूँ?**

हाँ। [ट्रांज़िशन](/slides/hi/nodejs-java/slide-transition/) स्लाइड पर लागू होते हैं, जबकि एनीमेशन प्रभाव स्लाइड पर मौजूद वस्तुओं पर लागू होते हैं। आप दोनों को एक ही प्रेजेंटेशन में साथ-साथ उपयोग कर सकते हैं और उन्हें स्वतंत्र रूप से नियंत्रित कर सकते हैं।

**क्या PPTX में सहेजते समय चार्ट एनीमेशन बरकरार रहते हैं?**

हाँ। जब आप [PPTX में सहेजें](/slides/hi/nodejs-java/save-presentation/) करते हैं, तो सभी एनीमेशन प्रभाव और उनका क्रम बरकरार रहता है क्योंकि वे प्रेजेंटेशन के मूल एनीमेशन मॉडल का हिस्सा होते हैं।

**क्या मैं प्रेजेंटेशन से मौजूदा चार्ट एनीमेशन पढ़ सकता हूँ और उन्हें संशोधित कर सकता हूँ?**

हाँ। API स्लाइड टाइमलाइन, सीक्वेंस और प्रभावों तक पहुँच प्रदान करता है, जिससे आप मौजूदा चार्ट एनीमेशन की जाँच कर सकते हैं और उन्हें बिना सब कुछ फिर से बनाए हुए समायोजित कर सकते हैं।

**क्या मैं Aspose.Slides का उपयोग करके चार्ट एनीमेशन सहित वीडियो बना सकता हूँ?**

हाँ। आप [प्रेजेंटेशन को वीडियो में निर्यात करें](/slides/hi/nodejs-java/convert-powerpoint-to-video/) कर सकते हैं, जो एनीमेशन को बरकरार रखते हुए टाइमिंग और अन्य एक्सपोर्ट सेटिंग्स को कॉन्फ़िगर करता है, ताकि प्राप्त क्लिप एनीमेटेड प्लेबैक को दर्शाए।