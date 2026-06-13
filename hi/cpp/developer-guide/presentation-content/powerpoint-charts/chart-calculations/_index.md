---
title: C++ में प्रस्तुतियों के लिए चार्ट गणनाओं का अनुकूलन
linktitle: चार्ट गणनाएँ
type: docs
weight: 50
url: /hi/cpp/chart-calculations/
keywords:
- चार्ट गणनाएँ
- चार्ट तत्व
- तत्व स्थिति
- वास्तविक स्थिति
- संतान तत्व
- मूल तत्व
- चार्ट मान
- वास्तविक मान
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में PPT और PPTX के लिए चार्ट गणनाओं, डेटा अपडेट्स और सटीकता नियंत्रण को समझें, साथ ही व्यावहारिक C++ कोड उदाहरणों के साथ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतीकरण में चार्ट गणनाओं और लेआउट डेटा के साथ काम करने के लिए API प्रदान करता है। यह लेख दिखाता है कि चार्ट तत्वों के वास्तविक मान कैसे प्राप्त करें, जिसमें `IActualLayout` को लागू करने वाले तत्वों की वास्तविक स्थिति और आकार, तथा चार्ट अक्षों के वास्तविक मान शामिल हैं। यह यह भी समझाता है कि ये मान चार्ट लेआउट सत्यापन के बाद भरे जाते हैं।

इसके अतिरिक्त, लेख दिखाता है कि मूल चार्ट तत्वों की वास्तविक स्थिति कैसे प्राप्त करें और चार्ट घटकों जैसे शीर्षक, अक्ष, लेजेंड और ग्रिड लाइनों को कैसे छुपाएँ। ये उदाहरण आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में चार्ट लेआउट जानकारी की जांच करने और चार्ट तत्वों की दृश्यता को नियंत्रित करने में सहायता करते हैं।

## **चार्ट तत्वों के वास्तविक मानों की गणना**
Aspose.Slides for C++ इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। यह आपको चार्ट तत्वों के वास्तविक मानों की गणना करने में मदद करेगा। वास्तविक मानों में IActualLayout इंटरफ़ेस को लागू करने वाले तत्वों की स्थिति (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) और वास्तविक अक्ष मान (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()) शामिल हैं।

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// प्रस्तुति सहेजना
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **मूल चार्ट तत्वों की वास्तविक स्थिति की गणना**
Aspose.Slides for C++ इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। IActualLayout की विधियां मूल चार्ट तत्व की वास्तविक स्थिति की जानकारी देती हैं। गुणों को वास्तविक मानों से भरने के लिए पहले IChart::ValidateChartLayout() मेथड को कॉल करना आवश्यक है।

``` cpp
// खाली प्रस्तुति बनाना
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **चार्ट तत्वों को छुपाएँ**
यह विषय आपको चार्ट से जानकारी को कैसे छुपाएँ समझने में मदद करता है। Aspose.Slides for C++ का उपयोग करके आप **शीर्षक, लंबवत अक्ष, क्षैतिज अक्ष** और **ग्रिड लाइन्स** को चार्ट से छुपा सकते हैं। नीचे का कोड उदाहरण दिखाता है कि इन गुणों का उपयोग कैसे करें।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **चार्ट के लिए डेटा रेंज सेट करना**
Aspose.Slides for C++ ने चार्ट के लिए डेटा रेंज सेट करने के लिए सबसे सरल API प्रदान किया है। चार्ट के लिए डेटा रेंज सेट करने के लिए:

- चार्ट युक्त Presentation क्लास का एक इंस्टेंस खोलें।
- उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- सभी शेप्स के माध्यम से घूमें ताकि वांछित चार्ट मिल सके।
- चार्ट डेटा तक पहुँचें और रेंज सेट करें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे के कोड उदाहरण दिखाते हैं कि चार्ट को कैसे अपडेट किया जाए।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी Excel वर्कबुक डेटा स्रोत के रूप में काम करते हैं, और इसका पुनर्गणना पर क्या प्रभाव पड़ता है?**

हां। एक चार्ट बाहरी वर्कबुक को संदर्भित कर सकता है: जब आप बाहरी स्रोत को कनेक्ट या रिफ्रेश करते हैं, तो फ़ॉर्मूले और मान उस वर्कबुक से लिए जाते हैं, और चार्ट खुले/संपादित करने के दौरान अपडेट को दर्शाता है। API आपको [बाहरी वर्कबुक निर्दिष्ट करने](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) पथ को निर्दिष्ट करने और लिंक्ड डेटा को प्रबंधित करने की अनुमति देता है।

**क्या मैं रिग्रेशन को स्वयं लागू किए बिना ट्रेंडलाइन की गणना और प्रदर्शन कर सकता हूँ?**

हां। [ट्रेंडलाइन](/slides/hi/cpp/trend-line/) (रेखीय, घातीय और अन्य) Aspose.Slides द्वारा जोड़े और अपडेट किए जाते हैं; उनके पैरामीटर श्रृंखला डेटा से स्वचालित रूप से पुनर्गणना होते हैं, इसलिए आपको अपना स्वयं का गणना लागू करने की आवश्यकता नहीं है।

**यदि प्रस्तुति में कई चार्ट बाहरी लिंक के साथ हैं, तो क्या मैं नियंत्रित कर सकता हूँ कि प्रत्येक चार्ट किस वर्कबुक का उपयोग गणना किए गए मानों के लिए करता है?**

हां। प्रत्येक चार्ट अपने स्वयं के [बाहरी वर्कबुक](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) को इंगित कर सकता है, या आप प्रत्येक चार्ट के लिए स्वतंत्र रूप से एक बाहरी वर्कबुक बना/बदल सकते हैं।