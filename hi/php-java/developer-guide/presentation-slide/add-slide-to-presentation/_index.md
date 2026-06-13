---
title: "PHP में प्रस्तुतियों में स्लाइड जोड़ें"
linktitle: "स्लाइड जोड़ें"
type: docs
weight: 10
url: /hi/php-java/add-slide-to-presentation/
keywords:
- "स्लाइड जोड़ें"
- "स्लाइड बनाएं"
- "खाली स्लाइड"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java का उपयोग करके अपने PowerPoint और OpenDocument प्रस्तुतियों में आसानी से स्लाइड जोड़ें — सेकंडों में सहज और कुशल स्लाइड सम्मिलन।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में स्लाइड जोड़ने की अनुमति देता है। एक प्रस्तुति में मास्टर/लेआउट स्लाइड और सामान्य स्लाइड होते हैं, और सामान्य स्लाइड शून्य-आधारित सूचकांक द्वारा व्यवस्थित होते हैं। प्रत्येक स्लाइड का एक अद्वितीय ID होता है, और स्लाइड वाले बिना प्रस्तुतियों को समर्थन नहीं दिया जाता है।

यह लेख बताता है कि कैसे एक `Presentation` ऑब्जेक्ट बनाया जाए, उसकी स्लाइड संग्रह तक पहुँच प्राप्त की जाए, एक खाली स्लाइड जोड़ी जाए, नई जोड़ी गई स्लाइड के साथ काम किया जाए, और अपडेटेड प्रस्तुति को सहेजा जाए। यह विशिष्ट स्थिति में स्लाइड डालना, लेआउट का उपयोग, और नई बनाई गई प्रस्तुति में मौजूद खाली स्लाइड को समझना जैसे संबंधित बिंदुओं को भी कवर करता है।

## **प्रस्तुति में स्लाइड जोड़ना**

प्रस्तुति फ़ाइलों में स्लाइड जोड़ने के बारे में बात करने से पहले, आइए स्लाइड के बारे में कुछ तथ्यों पर चर्चा करें। प्रत्येक PowerPoint प्रस्तुति फ़ाइल में **मास्टर / लेआउट** स्लाइड और अन्य **सामान्य** स्लाइडें होती हैं। इसका मतलब है कि एक प्रस्तुति फ़ाइल में कम से कम एक या अधिक स्लाइड होते हैं। यह जानना महत्वपूर्ण है कि Aspose.Slides for PHP via Java द्वारा स्लाइड रहित प्रस्तुति फ़ाइलों को समर्थन नहीं दिया जाता है। प्रत्येक स्लाइड का एक अद्वितीय Id होता है और सभी सामान्य स्लाइडें शून्य-आधारित सूचकांक द्वारा क्रमबद्ध होती हैं।

Aspose.Slides for PHP via Java डेवलपर्स को अपनी प्रस्तुति में खाली स्लाइड जोड़ने की अनुमति देता है। प्रस्तुति में खाली स्लाइड जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
- [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) ऑब्जेक्ट को [getSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#getSlides--) (सामग्री Slide ऑब्जेक्ट्स का संग्रह) मेथड का उपयोग करके प्राप्त करें, जो [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) ऑब्जेक्ट द्वारा उपलब्ध है।
- प्रस्तुति के सामग्री स्लाइड संग्रह के अंत में एक खाली स्लाइड जोड़ने के लिए, [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [**addEmptySlide**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/#addEmptySlide) मेथड को कॉल करें।
- नई जोड़ी गई खाली स्लाइड के साथ कुछ कार्य करें।
- अंत में, [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) ऑब्जेक्ट का उपयोग करके प्रस्तुति फ़ाइल को लिखें।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # SlideCollection क्लास का उदाहरण बनाएं
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Slides संग्रह में एक खाली स्लाइड जोड़ें
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # नई जोड़ी गई स्लाइड पर कुछ कार्य करें
    # PPTX फ़ाइल को डिस्क पर सहेजें
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नई स्लाइड को केवल अंत में नहीं, बल्कि एक विशिष्ट स्थिति पर भी सम्मिलित कर सकता हूँ?**

हां। लाइब्रेरी स्लाइड संग्रह और [insert](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/insertclone/) ऑपरेशनों का समर्थन करती है, इसलिए आप केवल अंत में नहीं, बल्कि आवश्यक इंडेक्स पर भी स्लाइड जोड़ सकते हैं।

**क्या लेआउट आधारित स्लाइड जोड़ते समय थीम/शैलियां संरक्षित रहती हैं?**

हां। एक लेआउट अपने मास्टर से फ़ॉर्मेटिंग विरासत में लेता है, और नई स्लाइड चयनित लेआउट और उसके संबंधित मास्टर से विरासत में लेती है।

**स्लाइड जोड़ने से पहले नई "खाली" प्रस्तुति में कौन सी स्लाइड मौजूद होती है?**

एक नई बनाई गई प्रस्तुति में पहले से ही इंडेक्स शून्य के साथ एक खाली स्लाइड होती है। यह सम्मिलन सूचकांकों की गणना करते समय ध्यान में रखने के लिए महत्वपूर्ण है।

**यदि मास्टर में कई विकल्प हैं, तो नई स्लाइड के लिए "सही" लेआउट कैसे चुनें?**

आम तौर पर वह [LayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) चुनें जो आवश्यक संरचना से मेल खाता हो ([Title and Content, Two Content, आदि](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidelayouttype/))। यदि ऐसा लेआउट मौजूद नहीं है, तो आप इसे [master में जोड़ सकते हैं](/slides/hi/php-java/slide-layout/) और फिर उपयोग कर सकते हैं।