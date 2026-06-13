---
title: C++ में PowerPoint स्लाइड्स को PNG में परिवर्तित करें
linktitle: PowerPoint को PNG में बदलें
type: docs
weight: 30
url: /hi/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से PNG
- प्रेजेंटेशन से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों को उच्च-गुणवत्ता वाले PNG चित्रों में तेज़ी से परिवर्तित करें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को PNG छवियों में बदलने के तरीके को समझाता है। यह दिखाता है कि PPT, PPTX, और ODP जैसे स्वरूपों में प्रस्तुति फ़ाइलों को कैसे लोड करें, स्लाइड्स को छवियों के रूप में रेंडर करें, और परिणामों को PNG स्वरूप में सहेजें।

यह लेख यह भी दर्शाता है कि स्केल मान सेट करके या वांछित चौड़ाई और ऊँचाई निर्दिष्ट करके उत्पन्न PNG छवियों को कैसे अनुकूलित किया जाए।

## **PowerPoint को PNG में बदलें**

इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का उदाहरण बनाएं।
2. [Presentation::get_Slides()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) संग्रह से [ISlide](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide) इंटरफ़ेस के तहत स्लाइड ऑब्जेक्ट प्राप्त करें। 
3. प्रत्येक स्लाइड के थंबनेल के लिए [ISlide::GetImage()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage) मेथड का उपयोग करें। 
4. स्लाइड थंबनेल को PNG स्वरूप में सहेजने के लिए [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) मेथड का उपयोग करें। 

यह C++ कोड आपको दिखाता है कि PowerPoint प्रस्तुति को PNG में कैसे बदलें:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **कस्टम आयामों के साथ PowerPoint को PNG में बदलें**

यदि आप किसी निश्चित स्केल के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `desiredX` और `desiredY` मान सेट कर सकते हैं, जो परिणामी थंबनेल के आयाम निर्धारित करते हैं। 

यह C++ कोड वर्णित ऑपरेशन को दर्शाता है:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **कस्टम आकार के साथ PowerPoint को PNG में बदलें**

यदि आप किसी निश्चित आकार के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `ImageSize` के लिए अपने इच्छित `width` और `height` तर्क पास कर सकते हैं। 

यह कोड आपको दिखाता है कि छवियों के आकार को निर्दिष्ट करते हुए PowerPoint को PNG में कैसे बदलें: 

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरे स्लाइड के बजाय केवल किसी विशिष्ट आकार (जैसे चार्ट या चित्र) को कैसे निर्यात कर सकता हूँ?**

Aspose.Slides [व्यक्तिगत आकृतियों के लिए थंबनेल जनरेट करना](/slides/hi/cpp/create-shape-thumbnails/) का समर्थन करता है; आप एक आकृति को PNG छवि में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हाँ, लेकिन [एक ही प्रस्तुति इंस्टेंस को थ्रेड्स के बीच साझा न करें](/slides/hi/cpp/multithreading/); प्रत्येक थ्रेड या प्रक्रिया के लिए अलग इंस्टेंस उपयोग करें।

**PNG निर्यात करते समय ट्रायल‑वर्जन की सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों में वाटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/cpp/licensing/) लागू करता है।