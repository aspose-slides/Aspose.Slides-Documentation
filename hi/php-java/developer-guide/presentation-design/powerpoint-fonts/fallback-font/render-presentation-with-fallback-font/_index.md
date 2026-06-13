---
title: PHP में फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/php-java/render-presentation-with-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- PowerPoint रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP में जावा के माध्यम से फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखें, चरण-दर-चरण कोड नमूनों के साथ।"
---
## **अवलोकन**

Aspose.Slides आपको फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि कैसे फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए, नियमों को हटाकर या फ़ॉलबैक फ़ॉन्ट जोड़कर संशोधित किया जाए, और संग्रह को `FontsManager::setFontFallBackRulesCollection` मेथड को असाइन किया जाए।

जब फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह प्रस्तुतिकरण के `FontsManager` को असाइन कर दिया जाता है, तो नियमों को सहेजने, रेंडर करने और प्रस्तुतिकरण को परिवर्तित करने जैसी कार्यों के दौरान लागू किया जाता है। उदाहरण दिखाता है कि स्लाइड थंबनेल को रेंडर करते समय और उसे PNG छवि के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का कैसे उपयोग किया जा सकता है।

## **फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

निम्नलिखित उदाहरण में ये चरण शामिल हैं:

1. हम [फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाते हैं](/slides/hi/php-java/create-fallback-fonts-collection/).
1. [हटाएँ](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) एक फ़ॉलबैक फ़ॉन्ट नियम और [addFallBackFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) को दूसरे नियम में जोड़ें।
1. नियमों के संग्रह को [getFontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) मेथड में सेट करें।
1. [Presentation.save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#save-java.lang.String-int-) मेथड के साथ हम प्रस्तुति को उसी प्रारूप में सहेज सकते हैं, या इसे किसी अन्य प्रारूप में सहेज सकते हैं। फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह [FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontsManager) को सेट करने के बाद, ये नियम प्रस्तुति पर किए जाने वाले किसी भी ऑपरेशन के दौरान लागू होते हैं: सहेजें, रेंडर करें, परिवर्तित करें, आदि।

```php
  # नियम संग्रह का नया उदाहरण बनाएं
  $rulesList = new FontFallBackRulesCollection();
  # कई नियम बनाएं
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # लोडेड नियमों से फ़ॉलबैक फ़ॉन्ट "Tahoma" को हटाने का प्रयास
    $fallBackRule->remove("Tahoma");
    # और निर्दिष्ट रेंज के लिए नियमों को अपडेट करना
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # हम सूची से किसी भी मौजूदा नियम को भी हटा सकते हैं
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # उपयोग के लिए तैयार नियम सूची असाइन करना
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # आरंभित नियम संग्रह का उपयोग करके थंबनेल रेंडर करना और JPEG में सहेजना
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # इमेज को डिस्क पर JPEG स्वरूप में सहेजें
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
[PHP में PPT और PPTX को JPG में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-jpg/) के बारे में अधिक पढ़ें।
{{% /alert %}}