---
title: प्रस्तुतियों में С++ का उपयोग करके चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/cpp/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- С++
- Aspose.Slides
description: "Aspose.Slides के साथ С++ में PPT और PPTX के लिए चार्ट डेटा टेबल को अनुकूलित करके प्रस्तुतियों में दक्षता और आकर्षण बढ़ाएँ।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट डेटा टेबल के साथ काम करने की विधि को समझाता है। यह दिखाता है कि चार्ट के लिए डेटा टेबल कैसे प्रदर्शित करें और बोल्ड शैली और फ़ॉन्ट ऊँचाई जैसे फ़ॉन्ट गुण सेट करके इसके टेक्स्ट फॉर्मेटिंग को कैसे अनुकूलित करें। उदाहरण में प्रस्तुतिकरण को लोड करना, चार्ट जोड़ना, चार्ट डेटा टेबल को सक्षम करना, फ़ॉन्ट सेटिंग्स लागू करना, और अपडेटेड प्रस्तुतिकरण को सहेजना दर्शाया गया है।

## **चार्ट डेटा टेबल के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for C++ चार्ट डेटा टेबल के फ़ॉन्ट गुण बदलने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास ऑब्जेक्ट बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट टेबल सेट करें।
1. फ़ॉन्ट ऊँचाई सेट करें।
1. परिवर्तित प्रस्तुतिकरण सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट के डेटा टेबल में मानों के बगल में छोटे लेजेंड कुंजी दिखा सकता हूँ?**

हाँ। डेटा टेबल [legend keys](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/datatable/set_showlegendkey/) को समर्थन देता है, और आप इन्हें चालू या बंद कर सकते हैं।

**क्या प्रस्तुतिकरण को PDF, HTML, या इमेजेज में निर्यात करने पर डेटा टेबल संरक्षित रहेगा?**

हाँ। Aspose.Slides चार्ट को स्लाइड का हिस्सा के रूप में रेंडर करता है, इसलिए निर्यातित [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/hi/cpp/convert-powerpoint-to-html/)/[image](/slides/hi/cpp/convert-powerpoint-to-png/) में चार्ट उसके डेटा टेबल के साथ शामिल होता है।

**क्या टेम्प्लेट फ़ाइल से आने वाले चार्ट के लिए डेटा टेबल समर्थित है?**

हाँ। किसी भी चार्ट के लिए जो मौजूदा प्रस्तुतिकरण या टेम्प्लेट से लोड किया गया हो, आप चार्ट की प्रॉपर्टीज़ का उपयोग करके जांच और बदल सकते हैं कि डेटा टेबल [दिखाया गया है](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/set_hasdatatable/)।

**मैं कैसे जल्दी पता लगा सकता हूँ कि फ़ाइल में कौन से चार्ट में डेटा टेबल सक्षम है?**

प्रत्येक चार्ट की प्रॉपर्टी को जांचें जो दर्शाती है कि डेटा टेबल [दिखाया गया है](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/get_hasdatatable/), और स्लाइड्स के माध्यम से इटररेट करके उन चार्टों की पहचान करें जहाँ यह सक्षम है।