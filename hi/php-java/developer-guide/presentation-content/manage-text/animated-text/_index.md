---
title: PHP में PowerPoint टेक्स्ट को एनीमेट करें
linktitle: एनीमेटेड टेक्स्ट
type: docs
weight: 60
url: /hi/php-java/animated-text/
keywords:
- एनीमेटेड टेक्स्ट
- टेक्स्ट एनीमेशन
- एनीमेटेड पैराग्राफ
- पैराग्राफ एनीमेशन
- एनीमेशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रेजेंटेशन में गतिशील एनीमेटेड टेक्स्ट बनाएँ, आसान-से-फ़ॉलो, अनुकूलित कोड उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides में एनीमेटेड टेक्स्ट के साथ कैसे काम करें, व्यक्तिगत पैराग्राफ पर एनीमेशन इफ़ेक्ट लागू करके और टेक्स्ट फ़्रेम में पहले से असाइन किए गए इफ़ेक्ट को प्राप्त करके। यह प्रस्तुति में पैराग्राफ‑स्तर के एनीमेशन जोड़ने और मौजूदा पैराग्राफ एनीमेशन प्रभाव की जाँच के लिए प्रयुक्त API मेथड्स पर केंद्रित है।

## **पैराग्राफ में एनीमेशन प्रभाव जोड़ें**

हमने [**addEffect()**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) मेथड को [**Sequence**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Sequence) क्लास में जोड़ा है। यह मेथड आपको एकल पैराग्राफ में एनीमेशन प्रभाव जोड़ने की अनुमति देता है। यह स्निपेट दर्शाता है कि एक पैराग्राफ में एनीमेशन प्रभाव कैसे जोड़ें:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # प्रभाव जोड़ने के लिए पैराग्राफ चुनें
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # चयनित पैराग्राफ में Fly एनीमेशन इफ़ेक्ट जोड़ें
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **पैराग्राफ के एनीमेशन प्रभाव प्राप्त करें**

आप यह जानना चाह सकते हैं कि एक पैराग्राफ में कौन से एनीमेशन इफ़ेक्ट जोड़े गए हैं—उदाहरण के लिए, एक परिदृश्य में आपको किसी पैराग्राफ के इफ़ेक्ट को दूसरे पैराग्राफ या शेप पर लागू करने की ज़रूरत हो सकती है।

Aspose.Slides for PHP via Java आपको टेक्स्ट फ़्रेम (शेप) में मौजूद पैराग्राफ पर लागू सभी एनीमेशन इफ़ेक्ट प्राप्त करने की सुविधा देता है। यह स्निपेट दर्शाता है कि एक पैराग्राफ में एनीमेशन इफ़ेक्ट कैसे प्राप्त करें:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**टेक्स्ट एनीमेशन स्लाइड ट्रांज़िशन से कैसे अलग हैं, और क्या उन्हें मिलाया जा सकता है?**

टेक्स्ट एनीमेशन स्लाइड पर समय के साथ ऑब्जेक्ट के व्यवहार को नियंत्रित करता है, जबकि [ट्रांज़िशन](/slides/hi/php-java/slide-transition/) स्लाइड बदलने के तरीके को नियंत्रित करता है। ये स्वतंत्र हैं और साथ में उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**क्या टेक्स्ट एनीमेशन को PDF या इमेजेज में एक्सपोर्ट करने पर बरकरार रखा जाता है?**

नहीं। PDF और रास्टर इमेजेज स्थिर होते हैं, इसलिए आपको स्लाइड की एक ही स्थिति बिना गति के दिखाई देगी। गति को बनाए रखने के लिए, [video](/slides/hi/php-java/convert-powerpoint-to-video/) या [HTML](/slides/hi/php-java/export-to-html5/) एक्सपोर्ट का उपयोग करें।

**क्या टेक्स्ट एनीमेशन लेआउट्स और स्लाइड मास्टर में काम करते हैं?**

लेआउट/मास्टर ऑब्जेक्ट्स पर लागू प्रभाव स्लाइड्स में विरासत में मिलते हैं, लेकिन उनका टाइमिंग और स्लाइड‑लेवल एनीमेशन के साथ इंटरैक्शन स्लाइड पर अंतिम क्रम पर निर्भर करता है।