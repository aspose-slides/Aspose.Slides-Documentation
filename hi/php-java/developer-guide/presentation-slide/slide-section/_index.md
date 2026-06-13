---
title: PHP का उपयोग करके प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 90
url: /hi/php-java/slide-section/
keywords:
- सेक्शन बनाएँ
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument में स्लाइड सेक्शन को सुसंगत बनाएँ — विभाजित करें, नाम बदलें, और पुनः क्रमित करें ताकि PPTX और ODP कार्यप्रवाह को अनुकूलित किया जा सके।"
---
## **परिचय**

Aspose.Slides for PHP via Java के साथ, आप PowerPoint प्रस्तुति को सेक्शन में व्यवस्थित कर सकते हैं। आप विशिष्ट स्लाइड्स वाले सेक्शन बना सकते हैं।

आप निम्न स्थितियों में सेक्शन बनाना और उनका उपयोग करके प्रस्तुति की स्लाइड्स को व्यवस्थित या विभाजित करना चाह सकते हैं:

- जब आप बड़ी प्रस्तुति को दूसरों या टीम के साथ काम कर रहे हों—और आपको कुछ स्लाइड्स को सहयोगी या टीम के कुछ सदस्यों को असाइन करना हो। 
- जब आप ऐसी प्रस्तुति से निपट रहे हों जिसमें कई स्लाइड्स हों—और आप उसकी सामग्री को एक साथ प्रबंधित या संपादित करने में कठिनाई महसूस कर रहे हों।

आदर्श रूप में, आपको ऐसा सेक्शन बनाना चाहिए जिसमें समान स्लाइड्स हों—स्लाइड्स में कोई सामान्य बात हो या वे नियम के आधार पर एक समूह में हो सकते हों—और सेक्शन को ऐसा नाम दें जो उसके भीतर की स्लाइड्स का वर्णन करता हो। 

## **प्रस्तुति में सेक्शन बनाना**

प्रस्तुति में स्लाइड्स को रखने वाला सेक्शन जोड़ने के लिए, Aspose.Slides for PHP via Java [addSection()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sectioncollection/#addSection) मेथड प्रदान करता है जो आपको बनाने वाले सेक्शन का नाम और वह स्लाइड निर्दिष्ट करने देता है जिससे सेक्शन शुरू होता है।

यह नमूना कोड आपको प्रस्तुति में एक सेक्शन बनाने को दिखाता है :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 को newSlide2 पर समाप्त किया जाएगा और उसके बाद section2 शुरू होगा

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सेक्शन के नाम बदलना**

PowerPoint प्रस्तुति में एक सेक्शन बनाने के बाद, आप उसका नाम बदलने का निर्णय ले सकते हैं। 

यह नमूना कोड Aspose.Slides का उपयोग करके प्रस्तुति में एक सेक्शन का नाम कैसे बदलें, दिखाता है :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजने पर सेक्शन संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटाडेटा को सपोर्ट नहीं करता, इसलिए सेक्शन समूहबद्धता .ppt में सहेजते समय खो जाती है।

**क्या पूरी सेक्शन को "छिपा" जा सकता है?**

नहीं। केवल व्यक्तिगत स्लाइड्स को छिपाया जा सकता है। एक सेक्शन के रूप में कोई "छिपा" स्थिति नहीं होती।

**क्या मैं किसी स्लाइड द्वारा जल्दी से सेक्शन ढूँढ़ सकता हूँ और इसके विपरीत, सेक्शन की पहली स्लाइड पा सकता हूँ?**

हां। एक सेक्शन को उसकी प्रारंभिक स्लाइड द्वारा विशिष्ट रूप से परिभाषित किया जाता है; किसी स्लाइड को देने पर आप निर्धारित कर सकते हैं कि वह किस सेक्शन से संबंधित है, और किसी सेक्शन के लिए आप उसकी पहली स्लाइड तक पहुँच सकते हैं।