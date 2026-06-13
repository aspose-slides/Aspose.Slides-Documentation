---
title: C++ में XAML में प्रस्तुतियों का निर्यात
linktitle: प्रेजेंटेशन से XAML
type: docs
weight: 30
url: /hi/cpp/export-to-xaml/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- PowerPoint रूपांतरण
- OpenDocument रूपांतरण
- प्रस्तुति रूपांतरण
- PowerPoint से XAML
- OpenDocument से XAML
- प्रस्तुति से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात
- PPTX को XAML में निर्यात
- ODP को XAML में निर्यात
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint और OpenDocument स्लाइड्स को XAML में परिवर्तित करें - तेज, Office-मुक्त समाधान जो लेआउट को अपरिवर्तित रखता है।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में निर्यात करने का तरीका समझाता है। इसमें XAML का एक संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में सहेजने का तरीका, और [XamlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने का प्रदर्शन शामिल है, जिसमें छुपी स्लाइडों का निर्यात भी शामिल है। लेख कुछ सामान्य प्रश्नों के उत्तर भी देता है, जैसे फॉलबैक फ़ॉन्ट्स, XAML स्टैक संगतता, और छुपी स्लाइड निर्यात व्यवहार।

## **XAML के बारे में**

XAML एक वर्णनात्मक प्रोग्रामिंग भाषा है जो आपको ऐप्स के उपयोगकर्ता इंटरफ़ेस बनाने या लिखने की अनुमति देती है, विशेष रूप से उन ऐप्स के लिए जो WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin forms का उपयोग करते हैं।  
XAML, जो एक XML-आधारित भाषा है, Microsoft का GUI वर्णन करने वाला वैरिएंट है। आप अधिकांश समय XAML फ़ाइलों पर काम करने के लिए एक डिज़ाइनर का उपयोग करेंगे, लेकिन आप अभी भी अपना GUI लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुतियों को निर्यात करें**

यह C++ कोड आपको डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में निर्यात करने का तरीका दिखाता है:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **कस्टम विकल्पों के साथ XAML में प्रस्तुतियों को निर्यात करें**

आप [IXamlOptions](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.xaml.i_xaml_options) इंटरफ़ेस से विकल्प चुन सकते हैं जो निर्यात प्रक्रिया को नियंत्रित करते हैं और निर्धारित करते हैं कि Aspose.Slides आपकी प्रस्तुति को XAML में कैसे निर्यात करता है।  

उदाहरण के लिए, यदि आप चाहते हैं कि Aspose.Slides XAML में निर्यात करते समय आपकी प्रस्तुति से छुपी स्लाइडें जोड़ दे, तो आप [set_ExportHiddenSlides()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) मेथड को true पास कर सकते हैं। इस नमूना C++ कोड को देखें:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं पूर्वनिर्धारित फ़ॉन्ट कैसे सुनिश्चित कर सकता हूँ?**

सही फ़ॉन्ट सुनिश्चित करने के लिए [set_DefaultRegularFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) को [XamlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/) में उपयोग करें — यह मूल फ़ॉन्ट के अनुपलब्ध होने पर फॉलबैक फ़ॉन्ट के रूप में उपयोग होता है। यह अप्रत्याशित प्रतिस्थापन से बचाने में मदद करता है।

**क्या निर्यात किया गया XAML केवल WPF के लिए है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

XAML एक सामान्य UI मार्कअप भाषा है जो WPF, UWP, और Xamarin.Forms में उपयोग होती है। निर्यात Microsoft XAML स्टैक्स के साथ संगतता को लक्षित करता है; विशिष्ट निर्माणों के लिए सटीक व्यवहार और समर्थन लक्ष्य प्लेटफ़ॉर्म पर निर्भर करता है। अपने वातावरण में इस मार्कअप का परीक्षण करें।

**क्या छुपी स्लाइडें समर्थित हैं, और मैं उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोक सकता हूँ?**

डिफ़ॉल्ट रूप से, छुपी स्लाइडें शामिल नहीं की जातीं। आप इस व्यवहार को [set_ExportHiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) के माध्यम से [XamlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export.xaml/xamloptions/) में नियंत्रित कर सकते हैं — यदि आपको उन्हें निर्यात करने की आवश्यकता नहीं है तो इसे अक्षम रखें।