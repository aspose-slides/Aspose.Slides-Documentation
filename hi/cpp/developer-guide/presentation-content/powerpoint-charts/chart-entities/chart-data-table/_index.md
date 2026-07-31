---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/cpp/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PPT और PPTX के लिए चार्ट डेटा टेबल को अनुकूलित करके प्रस्तुतियों में दक्षता और आकर्षण बढ़ाएँ।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट डेटा तालिकाओं के साथ काम करने का तरीका समझाता है। यह दिखाता है कि चार्ट के लिए डेटा तालिका कैसे प्रदर्शित की जाए और फ़ॉन्ट गुण जैसे बोल्ड शैली और फ़ॉन्ट ऊँचाई सेट करके उसके पाठ स्वरूपण को कैसे अनुकूलित किया जाए। उदाहरण में एक प्रस्तुति लोड करना, चार्ट जोड़ना, चार्ट डेटा तालिका को सक्रिय करना, फ़ॉन्ट सेटिंग्स लागू करना, और अद्यतन प्रस्तुति को सहेजना दर्शाया गया है।

## **चार्ट डेटा तालिका के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for C++ आपको चार्ट डेटा तालिका के फ़ॉन्ट गुण बदलने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास ऑब्जेक्ट का उदाहरण बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट तालिका सेट करें।
1. फ़ॉन्ट ऊँचाई सेट करें।
1. संशोधित प्रस्तुति सहेजें।

नीचे दिया गया नमूना उदाहरण है।

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**क्या मैं चार्ट की डेटा तालिका में मानों के बगल में छोटे लीजेंड कुंजी दिखा सकता हूँ?**

हाँ। डेटा तालिका [legend keys](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/datatable/set_showlegendkey/) को समर्थन देती है, और आप इन्हें चालू या बंद कर सकते हैं।

**क्या प्रस्तुति को PDF, HTML, या इमेजेज़ में एक्सपोर्ट करने पर डेटा तालिका बनी रहेगी?**

हाँ। Aspose.Slides चार्ट को स्लाइड के हिस्से के रूप में रेंडर करता है, इसलिए एक्सपोर्ट किया गया [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/hi/cpp/convert-powerpoint-to-html/)/[image](/slides/hi/cpp/convert-powerpoint-to-png/) में चार्ट उसके डेटा तालिका के साथ शामिल होता है।

**क्या टेम्पलेट फ़ाइल से आए चार्ट के लिए डेटा तालिकाओं का समर्थन है?**

हाँ। किसी भी चार्ट के लिए जो मौजूदा प्रस्तुति या टेम्पलेट से लोड किया गया हो, आप चार्ट की प्रॉपर्टी का उपयोग करके डेटा तालिका [दिखाया जाता है](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/set_hasdatatable/) को जांच और बदल सकते हैं।

**मैं फ़ाइल में कौन से चार्ट डेटा तालिका के साथ सक्षम हैं, इसे जल्दी से कैसे ढूँढ सकता हूँ?**

फ़ाइल में प्रत्येक चार्ट की वह प्रॉपर्टी देखें जो संकेत देती है कि डेटा तालिका [दिखाया जाता है](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/get_hasdatatable/) है, और स्लाइड्स के माध्यम से इटरेट करके उन चार्टों की पहचान करें जहाँ यह सक्षम है।