---
title: "प्रस्तुतियों से PHP में गणितीय समीकरण निर्यात करें"
linktitle: "समीकरण निर्यात"
type: docs
weight: 30
url: /hi/php-java/exporting-math-equations/
keywords:
- "गणितीय समीकरण निर्यात"
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint से MathML में गणितीय समीकरणों का सहज निर्यात सक्षम करें — फॉर्मेटिंग को संरक्षित रखें और संगतता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for PHP via Java आपको प्रस्तुतियों से गणितीय समीकरण निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको किसी विशिष्ट प्रस्तुति से स्लाइड्स पर मौजूद गणितीय समीकरण निकालने और उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}} 
आप समीकरणों को MathML में निर्यात कर सकते हैं, जो वेब पर और कई अनुप्रयोगों में देखे जाने वाले गणितीय समीकरणों और समान सामग्री के लिए एक लोकप्रिय फ़ॉर्मेट या मानक है। 
{{% /alert %}}

## **गणितीय समीकरणों को MathML के रूप में सहेजें**

जबकि मनुष्य LaTeX जैसी कुछ समीकरण फ़ॉर्मेट का कोड आसानी से लिखते हैं, वे MathML का कोड लिखने में कठिनाई महसूस करते हैं क्योंकि इसे स्वचालित रूप से अनुप्रयोगों द्वारा उत्पन्न किया जाना होता है। प्रोग्राम MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML को कई क्षेत्रों में आउटपुट और प्रिंटिंग फ़ॉर्मेट के रूप में व्यापक रूप से उपयोग किया जाता है। 

This sample code shows you how to export a math equation from a presentation to MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**MathML में ठीक क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत फ़ॉर्मूला ब्लॉक?**

आप पूरे गणितीय पैराग्राफ([MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक([MathBlock](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML लिखने के लिए एक विधि प्रदान करते हैं।

**मैं कैसे पता करूँ कि स्लाइड पर कोई ऑब्जेक्ट सामान्य टेक्स्ट या छवि के बजाय गणितीय फ़ॉर्मूला है?**

एक फ़ॉर्मूला [MathPortion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathportion/) में रहता है और इसका एक [MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/) होता है। उन छवियों और सामान्य टेक्स्ट हिस्सों जिनमें [MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/) नहीं होता, निर्यात योग्य फ़ॉर्मूले नहीं होते।

**प्रस्तुति में MathML कहां से आता है—क्या यह केवल PowerPoint के लिए विशिष्ट है या एक मानक है?**

निर्यात मानक MathML (XML) को लक्ष्य बनाता है। Aspose Presentation MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से उपयोग होता है।

**क्या तालिकाओं, SmartArt, समूहों आदि के भीतर फ़ॉर्मूलों का निर्यात समर्थित है?**

हां, यदि उन ऑब्जेक्ट्स में [MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/) वाले टेक्स्ट हिस्से हैं (यानी वास्तविक PowerPoint फ़ॉर्मूले), तो वे निर्यात होते हैं। यदि कोई फ़ॉर्मूला छवि के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं होता।

**क्या MathML में निर्यात करने से मूल प्रस्तुति में परिवर्तन होता है?**

नहीं। MathML लिखना फ़ॉर्मूले की सामग्री का क्रमांकन (सीरियलाइज़ेशन) है; यह प्रस्तुति फ़ाइल को बदलता नहीं है।