---
title: PHP में प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/php-java/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जांच
- भाषा आईडी
- पॉवरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- पीएचपी
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड स्थानीयकरण को व्यावहारिक कोड नमूने और तेज़ वैश्विक रोलआउट के लिए टिप्स के साथ स्वचालित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में पाठ के लिए `LanguageId` सेट करने की विधि बताता है। यह दिखाता है कि प्रस्तुति कैसे खोलें, पाठ के साथ एक आकार जोड़ें, पाठ भाग को भाषा पहचानकर्ता असाइन करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें।

## **प्रस्तुति और आकार के पाठ की भाषा बदलें**
- [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
- उसकी इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- स्लाइड पर [Rectangle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ShapeType#Rectangle) प्रकार का एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
- TextFrame में कुछ पाठ जोड़ें।
- पाठ के लिए [Set Language Id](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

उपरोक्त चरणों का कार्यान्वयन नीचे एक उदाहरण में दर्शाया गया है।

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा ID स्वचालित पाठ अनुवाद को ट्रिगर करती है?**

नहीं। Aspose.Slides में [Language ID](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) वर्तनी जांच और व्याकरण सिद्धिकरण के लिए भाषा संग्रहीत करता है, लेकिन यह पाठ की सामग्री का अनुवाद या परिवर्तन नहीं करता। यह मेटा डेटा है जिसे PowerPoint सिद्धिकरण के लिए समझता है।

**क्या भाषा ID रेंडरिंग के दौरान हाइफ़नेशन और लाइन ब्रेक को प्रभावित करती है?**

Aspose.Slides में, [language ID](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) सिद्धिकरण के लिए है। हाइफ़नेशन की गुणवत्ता और लाइन रैपिंग मुख्यतः [सही फ़ॉन्ट्स](/slides/hi/php-java/powerpoint-fonts/) की उपलब्धता और लेखन प्रणाली की लेआउट/लाइन‑ब्रेक सेटिंग्स पर निर्भर करती है। सही रेंडरिंग सुनिश्चित करने के लिए, आवश्यक फ़ॉन्ट्स उपलब्ध कराएँ, [फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/php-java/font-substitution/) कॉन्फ़िगर करें, और/या प्रस्तुति में [फ़ॉन्ट एंबेड](/slides/hi/php-java/embedded-font/) करें।

**क्या मैं एक ही पैराग्राफ में विभिन्न भाषाएँ सेट कर सकता हूँ?**

हाँ। [Language ID](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) पाठ भाग स्तर पर लागू होता है, इसलिए एक ही पैराग्राफ कई भाषाओं को अलग‑अलग सिद्धिकरण सेटिंग्स के साथ मिश्रित कर सकता है।