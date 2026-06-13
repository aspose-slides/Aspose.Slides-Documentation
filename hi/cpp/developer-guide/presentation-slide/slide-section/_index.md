---
title: "C++ का उपयोग करके प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें"
linktitle: "स्लाइड सेक्शन"
type: docs
weight: 100
url: /hi/cpp/slide-section/
keywords:
  - "सेक्शन बनाएं"
  - "सेक्शन जोड़ें"
  - "सेक्शन संपादित करें"
  - "सेक्शन बदलें"
  - "सेक्शन नाम"
  - "PowerPoint"
  - "OpenDocument"
  - "प्रस्तुति"
  - "C++"
  - "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument में स्लाइड सेक्शन को सुव्यवस्थित करें — विभाजित करें, नाम बदलें, और पुन: क्रमित करें ताकि PPTX और ODP कार्यप्रवाह को अनुकूलित किया जा सके।"
---
## **परिचय**

Aspose.Slides for C++ के साथ, आप PowerPoint Presentation को सेक्शनों में व्यवस्थित कर सकते हैं। आप विशिष्ट स्लाइड्स को शामिल करने वाले सेक्शन बना सकते हैं।

आप निम्न स्थितियों में सेक्शन बनाना और उनका उपयोग करके प्रेजेंटेशन में स्लाइड्स को व्यवस्थित या विभाजित करना चाह सकते हैं:

- जब आप बड़ी प्रेजेंटेशन पर अन्य लोगों या टीम के साथ काम कर रहे हों — और आपको कुछ स्लाइड्स को सहयोगी या टीम के सदस्यों को सौंपना हो।  
- जब आप ऐसी प्रेजेंटेशन से निपट रहे हों जिसमें कई स्लाइड्स हों — और आप एक साथ उसकी सामग्री को प्रबंधित या संपादित करने में कठिनाई महसूस कर रहे हों।

आदर्श रूप में, आपको ऐसा सेक्शन बनाना चाहिए जिसमें समान स्लाइड्स हों — स्लाइड्स में कोई सामान्य बात हो या वे किसी नियम के आधार पर समूहित हो सकें—और सेक्शन को ऐसा नाम दें जो उसके अंदर की स्लाइड्स का वर्णन करता हो।

## **प्रेजेंटेशन में सेक्शन बनाना**

प्रेजेंटेशन में स्लाइड्स को रखने वाले सेक्शन को जोड़ने के लिए, Aspose.Slides for C++ `AddSection` मेथड प्रदान करता है जो आपको बनाने वाले सेक्शन का नाम और वह स्लाइड निर्दिष्ट करने की अनुमति देता है जिससे सेक्शन शुरू होता है।

यह नमूना कोड C++ में प्रेजेंटेशन में एक सेक्शन बनाने का तरीका दिखाता है:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 को newSlide2 पर समाप्त किया जाएगा और उसके बाद section2 शुरू होगा   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **सेक्शनों के नाम बदलें**

PowerPoint प्रेजेंटेशन में एक सेक्शन बनाने के बाद, आप उसका नाम बदलने का निर्णय ले सकते हैं।

यह नमूना कोड Aspose.Slides का उपयोग करके C++ में प्रेजेंटेशन में एक सेक्शन का नाम बदलने का तरीका दिखाता है:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**क्या PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजने पर सेक्शन संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटा डेटा को सपोर्ट नहीं करता, इसलिए .ppt में सहेजने पर सेक्शन समूहण खो जाता है।

**क्या पूरी सेक्शन को "छिपाया" जा सकता है?**

नहीं। केवल व्यक्तिगत स्लाइड्स को ही छिपाया जा सकता है। एक इकाई के रूप में सेक्शन की कोई "छिपी हुई" स्थिति नहीं होती।

**क्या मैं जल्दी से किसी स्लाइड द्वारा सेक्शन खोज सकता हूँ और इसके विपरीत, सेक्शन की पहली स्लाइड जान सकता हूँ?**

हाँ। एक सेक्शन को उसकी शुरूआती स्लाइड द्वारा विशिष्ट रूप से परिभाषित किया जाता है; किसी स्लाइड से आप निर्धारित कर सकते हैं कि वह किस सेक्शन में है, और किसी सेक्शन के लिए आप उसकी पहली स्लाइड तक पहुंच सकते हैं।