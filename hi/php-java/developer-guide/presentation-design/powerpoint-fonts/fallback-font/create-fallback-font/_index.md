---
title: PHP में प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करें
linktitle: फ़ॉलबैक फ़ॉन्ट
type: docs
weight: 10
url: /hi/php-java/create-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट लागू करें
- फ़ॉन्ट बदलें
- Unicode रेंज
- गायब ग्लिफ़
- सही ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Java के माध्यम से PHP के लिए Aspose.Slides में निपुण बनें ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट सेट कर सकें, जिससे किसी भी डिवाइस या OS पर सुसंगत टेक्स्ट प्रदर्शन सुनिश्चित हो।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात कार्यों के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है। जब मुख्य फ़ॉन्ट में विशिष्ट अक्षरों के लिए ग्लिफ़ उपलब्ध नहीं होते हैं, तब फ़ॉलबैक फ़ॉन्ट का उपयोग किया जाता है।

फ़ॉलबैक व्यवहार को फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक Unicode रेंज को एक या अधिक फ़ॉन्ट्स से जोड़ता है जो आवश्यक ग्लिफ़ शामिल कर सकते हैं। आप विभिन्न अक्षर रेंजों के लिए नियम निर्धारित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट जोड़ या हटा सकते हैं, और फ़ॉलबैक फ़ॉन्ट नियम संग्रह में कई नियम व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स होते हैं। ये प्रस्तुति फ़ाइल को स्वयं संशोधित नहीं करते और PPTX फ़ाइल के भीतर संग्रहित नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट करने के लिए [FontFallBackRule](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRule) क्लास का समर्थन करता है। [FontFallBackRule](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRule) क्लास निर्दिष्ट Unicode रेंज (जो मिस्ड ग्लिफ़ खोजने के लिए उपयोग किया जाता है) और उन फ़ॉन्ट्स की सूची के बीच एक संबंध को दर्शाता है जो उचित ग्लिफ़ रख सकते हैं:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # कई तरीकों से आप फ़ॉन्ट सूची जोड़ सकते हैं:
  $fontNames = array("Segoe UI Emoji, Segue UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

यह भी संभव है कि आप मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRule) ऑब्जेक्ट में फ़ॉलबैक फ़ॉन्ट को [remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontfallbackrule/remove/) करें या [addFallBackFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) जोड़ें।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRulesCollection) का उपयोग [FontFallBackRule](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRule) ऑब्जेक्ट की सूची को व्यवस्थित करने के लिए किया जा सकता है, जब कई Unicode रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियम निर्दिष्ट करने की आवश्यकता हो।

{{% alert color="primary" title="और देखें" %}} 
- [फ़ॉलबैक फ़ॉन्ट संग्रह बनाएं](/slides/hi/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **पूछे जाने वाले प्रश्न**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन, और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?**

फ़ॉलबैक फ़ॉन्ट केवल मुख्य फ़ॉन्ट में न मौजूद अक्षरों के लिए उपयोग किया जाता है। [Font substitution](/slides/hi/php-java/font-substitution/) निर्दिष्ट फ़ॉन्ट को पूरे रूप में दूसरे फ़ॉन्ट से बदलता है। [Font embedding](/slides/hi/php-java/embedded-font/) फ़ॉन्ट्स को आउटपुट फ़ाइल में पैकेज करता है ताकि प्राप्तकर्ता पाठ को इच्छित रूप में देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट PDF, PNG, या SVG जैसे निर्यात के दौरान लागू होते हैं, या केवल स्क्रीन रेंडरिंग पर?**

हां। फ़ॉलबैक सभी [rendering and export operations](/slides/hi/php-java/convert-presentation/) पर प्रभाव डालता है जहाँ अक्षरों को रेंडर करना आवश्यक है लेकिन स्रोत फ़ॉन्ट में वे उपलब्ध नहीं हैं।

**क्या फ़ॉलबैक को कॉन्फ़िगर करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या यह सेटिंग भविष्य में खुलने पर बनी रहती है?**

नहीं। फ़ॉलबैक नियम आपके कोड में रनटाइम रेंडरिंग सेटिंग्स होते हैं; वे .pptx के भीतर संग्रहीत नहीं होते और पावरपॉइंट में दिखाई नहीं देंगे।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डायरेक्टरीज़ का सेट फ़ॉलबैक चयन को प्रभावित करता है?**

हां। इंजन उपलब्ध सिस्टम फ़ोल्डरों और आपके द्वारा प्रदान किए गए किसी भी [additional paths](/slides/hi/php-java/custom-font/) से फ़ॉन्ट्स को हल करता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकता।

**क्या फ़ॉलबैक WordArt, SmartArt, और चार्ट्स के लिए काम करता है?**

हां। जब इन ऑब्जेक्ट्स में पाठ होता है, तो समान ग्लिफ़-प्रतिस्थापन तंत्र अनुपलब्ध अक्षरों को रेंडर करने के लिए लागू होता है।