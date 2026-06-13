---
title: PHP में PowerPoint चार्ट्स को एनिमेट करें
linktitle: एनिमेटेड चार्ट्स
type: docs
weight: 80
url: /hi/php-java/animated-charts/
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
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके शानदार एनिमेटेड चार्ट बनाएं। PPT और PPTX फ़ाइलों में डायनामिक विज़ुअल्स के साथ प्रस्तुतियों को बेहतर बनाएं — अभी शुरू करें।"
---
## **परिचय**

Aspose.Slides for PHP via Java चार्ट तत्वों को एनिमेट करने को समर्थन देता है। **Series**, **Categories**, **Series Elements**, **Categories Elements** को [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/#addEffect) मेथड के साथ और दो एनम्स [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/EffectChartMajorGroupingType) और [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/EffectChartMinorGroupingType) के द्वारा एनिमेट किया जा सकता है।

## **चार्ट सीरीज़ एनीमेशन**
यदि आप एक चार्ट श्रृंखला को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
2. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
3. श्रृंखला को एनिमेट करें।
4. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

नीचे दिए उदाहरण में, हमने चार्ट श्रृंखला को एनिमेट किया है।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # श्रृंखला को एनिमेट करें
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # संशोधित प्रस्तुति को डिस्क पर लिखें
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट श्रेणी एनीमेशन**
यदि आप एक चार्ट श्रेणी को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
2. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
3. श्रेणी को एनिमेट करें।
4. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

नीचे दिए उदाहरण में, हमने चार्ट श्रेणी को एनिमेट किया है।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सीरीज़ तत्व में एनिमेशन**
यदि आप सीरीज़ तत्वों को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
2. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
3. सीरीज़ तत्वों को एनिमेट करें।
4. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

नीचे दिए उदाहरण में, हमने सीरीज़ तत्वों को एनिमेट किया है।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # श्रृंखला तत्वों को एनिमेट करें
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # प्रस्तुति फ़ाइल को डिस्क पर लिखें
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **श्रेणी तत्व में एनिमेशन**
यदि आप श्रेणी तत्वों को एनिमेट करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार कोड लिखें:

1. एक प्रस्तुति लोड करें।
2. चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
3. श्रेणी तत्वों को एनिमेट करें।
4. प्रस्तुति फ़ाइल को डिस्क पर लिखें।

नीचे दिए उदाहरण में, हमने श्रेणी तत्वों को एनिमेट किया है।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # चार्ट ऑब्जेक्ट का रेफ़रेंस प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # श्रेणियों के तत्वों को एनिमेट करें
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # प्रस्तुति फ़ाइल को डिस्क पर लिखें
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या विभिन्न प्रभाव प्रकार (जैसे, प्रवेश, ज़ोर, निकास) नियमित आकारों की तरह चार्ट के लिए समर्थित हैं?**

हाँ। एक चार्ट को आकार के रूप में माना जाता है, इसलिए यह मानक एनीमेशन प्रभाव प्रकारों का समर्थन करता है, जिसमें प्रवेश, ज़ोर, और निकास शामिल हैं, और स्लाइड की टाइमलाइन और एनीमेशन अनुक्रमों के माध्यम से पूर्ण नियंत्रण प्रदान करता है।

**क्या मैं चार्ट एनीमेशन को स्लाइड ट्रांज़िशन के साथ मिलाकर उपयोग कर सकता हूँ?**

हाँ। [Transitions](/slides/hi/php-java/slide-transition/) स्लाइड पर लागू होते हैं, जबकि एनीमेशन प्रभाव स्लाइड पर मौजूद वस्तुओं पर लागू होते हैं। आप दोनों को एक ही प्रस्तुति में साथ में उपयोग कर सकते हैं और उन्हें स्वतंत्र रूप से नियंत्रित कर सकते हैं।

**क्या चार्ट एनीमेशन PPTX में सहेजते समय संरक्षित रहते हैं?**

हाँ। जब आप [save to PPTX](/slides/hi/php-java/save-presentation/) करते हैं, तो सभी एनीमेशन प्रभाव और उनका क्रम संरक्षित रहता है क्योंकि वे प्रस्तुति के मूल एनीमेशन मॉडल का हिस्सा हैं।

**क्या मैं किसी प्रस्तुति से मौजूदा चार्ट एनीमेशन पढ़ सकता हूँ और उन्हें बदल सकता हूँ?**

हाँ। API स्लाइड टाइमलाइन, अनुक्रमों और प्रभावों तक पहुँच प्रदान करता है, जिससे आप मौजूदा चार्ट एनीमेशन का निरीक्षण कर सकते हैं और उन्हें बिना सब कुछ फिर से बनाए बिना समायोजित कर सकते हैं।

**क्या मैं Aspose.Slides का उपयोग करके चार्ट एनीमेशन सहित एक वीडियो बना सकता हूँ?**

हाँ। आप [export a presentation to video](/slides/hi/php-java/convert-powerpoint-to-video/) कर सकते हैं और एनीमेशन को संरक्षित रखते हुए, टाइमिंग्स और अन्य एक्सपोर्ट सेटिंग्स को कॉन्फ़िगर करके resulting क्लिप में एनीमेटेड प्लेबैक को प्रतिबिंबित कर सकते हैं।