---
title: C++ में PPT और PPTX को JPG में बदलें
linktitle: PowerPoint से JPG
type: docs
weight: 60
url: /hi/cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPoint को बदलें
- प्रेज़ेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से JPG
- प्रेज़ेंटेशन को JPG में बदलें
- स्लाइड को JPG में बदलें
- PPT को JPG में बदलें
- PPTX को JPG में बदलें
- PowerPoint को JPG के रूप में सहेजें
- प्रेज़ेंटेशन को JPG के रूप में सहेजें
- स्लाइड को JPG के रूप में सहेजें
- PPT को JPG के रूप में सहेजें
- PPTX को JPG के रूप में सहेजें
- PPT को JPG में निर्यात करें
- PPTX को JPG में निर्यात करें
- C++
- Aspose.Slides
description: "C++ में Aspose.Slides का उपयोग करके PowerPoint (PPT, PPTX) स्लाइड्स को तेज़ और विश्वसनीय कोड उदाहरणों के साथ उच्च‑गुणवत्ता वाले JPG चित्रों में बदलें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रेज़ेंटेशन को JPG छवियों में बदलने से स्लाइड साझा करना, प्रदर्शन को अनुकूलित करना और वेब साइट या एप्लिकेशन में सामग्री एम्बेड करना आसान हो जाता है। Aspose.Slides for C++ आपको PPTX, PPT और ODP फ़ाइलों को उच्च‑गुणवत्ता वाले JPEG छवियों में बदलने की सुविधा देता है। यह गाइड विभिन्न रूपांतरण विधियों को समझाता है।

इन सुविधाओं के साथ, अपना खुद का प्रेज़ेंटेशन व्यूअर लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान होता है। यह उपयोगी हो सकता है यदि आप प्रेज़ेंटेशन स्लाइड्स की कॉपी रोकना चाहते हैं या रीड‑ओनली मोड में प्रेज़ेंटेशन प्रदर्शित करना चाहते हैं। Aspose.Slides आपको पूरी प्रेज़ेंटेशन या किसी विशिष्ट स्लाइड को इमेज फ़ॉर्मेट में बदलने की अनुमति देता है।

## **प्रेज़ेंटेशन स्लाइड्स को JPG छवियों में बदलें**

PPT, PPTX या ODP फ़ाइल को JPG में बदलने के चरण नीचे दिए गए हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. प्रेज़ेंटेशन की स्लाइड कलेक्शन से [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) प्रकार की स्लाइड ऑब्जेक्ट प्राप्त करें।
1. [ISlide.GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) मेथड का उपयोग करके स्लाइड की छवि बनाएं।
1. इमेज ऑब्जेक्ट पर [IImage.Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/save/) मेथड को कॉल करें। आउटपुट फ़ाइल नाम और इमेज फ़ॉर्मेट को आर्ग्यूमेंट्स के रूप में पास करें।

{{% alert color="info" %}} 

**नोट:** PPT, PPTX या ODP को JPG में बदलना Aspose.Slides for C++ API में अन्य फ़ॉर्मेट्स के रूपांतरण से अलग होता है। अन्य फ़ॉर्मेट्स के लिए आप आमतौर पर [IPresentation.Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/save/) मेथड का उपयोग करते हैं। हालांकि, JPG रूपांतरण के लिए आपको [IImage.Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/save/) मेथड का उपयोग करना आवश्यक है।

{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // निर्धारित स्केल की स्लाइड इमेज बनाएं।
    auto image = slide->GetImage(scaleX, scaleY);

    // इमेज को JPEG फ़ॉर्मेट में डिस्क पर सहेजें।
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **कस्टमाइज़्ड डाइमेंशन के साथ स्लाइड्स को JPG में बदलें**

परिणामी JPG छवियों के आकार को बदलने के लिए आप [ISlide.GetImage(Size)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) मेथड में आकार पास करके इमेज साइज सेट कर सकते हैं। इससे आप विशिष्ट चौड़ाई और ऊँचाई मानों के साथ छवियां जनरेट कर सकते हैं, जिससे आउटपुट रिज़ोल्यूशन और एस्पेक्ट रेशियो आपकी आवश्यकताओं के अनुरूप हो जाता है। यह लचीलापन वेब एप्लिकेशन, रिपोर्ट या दस्तावेज़ों के लिए इमेज डाइमेंशन की सटीक आवश्यकता होने पर विशेष रूप से उपयोगी है।

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // निर्दिष्ट आकार की स्लाइड इमेज बनाएं।
    auto image = slide->GetImage(imageSize);

    // इमेज को JPEG फ़ॉर्मेट में डिस्क पर सहेजें।
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **स्लाइड को इमेज के रूप में सेव करते समय कमेंट्स को रेंडर करें**

Aspose.Slides for C++ एक ऐसी सुविधा प्रदान करता है जिससे आप प्रेज़ेंटेशन की स्लाइड्स को JPG छवियों में बदलते समय कमेंट्स को रेंडर कर सकते हैं। यह फ़ंक्शन वहन करने वाले एनोटेशन, फ़ीडबैक या सहयोगियों द्वारा PowerPoint प्रेज़ेंटेशन में जोड़े गए चर्चाओं को संरक्षित रखने में मददगार है। इस विकल्प को सक्षम करने से कमेंट्स उत्पन्न छवियों में दिखाई देंगे, जिससे मूल प्रेज़ेंटेशन फ़ाइल खोलने की आवश्यकता के बिना फ़ीडबैक की समीक्षा और साझा करना आसान हो जाता है।

मान लीजिए हमारे पास "sample.pptx" नाम की प्रेज़ेंटेशन फ़ाइल है, जिसमें एक स्लाइड पर कमेंट्स हैं:

![टिप्पणियों के साथ स्लाइड](slide_with_comments.png)

निम्नलिखित C++ कोड स्लाइड को कमेंट्स के साथ JPG इमेज में बदलता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // स्लाइड कमेंट्स के विकल्प सेट करें।
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // पहली स्लाइड को इमेज में बदलें।
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

परिणाम:

![टिप्पणियों के साथ JPG छवि](image_with_comments.png)

## **संबंधित देखें**

इन्हें देखें, PPT, PPTX या ODP को इमेज में बदलने के अन्य विकल्प:

- [Convert PowerPoint to GIF](/slides/hi/cpp/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/hi/cpp/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/hi/cpp/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/hi/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

यह देखने के लिए कि Aspose.Slides PowerPoint को JPG छवियों में कैसे बदलता है, इन मुफ्त ऑनलाइन कन्वर्टर्स को आज़माएँ: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/hi/conversion/pptx-to-jpg) और [PPT to JPG](https://products.aspose.app/slides/hi/conversion/ppt-to-jpg)।

{{% /alert %}}

![निःशुल्क ऑनलाइन PPTX to JPG कनवर्टर](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG छवियों को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि। 

इस लेख में वर्णित समान सिद्धांतों का उपयोग करके, आप छवियों को एक फ़ॉर्मेट से दूसरे में बदल सकते हैं। अधिक जानकारी के लिए इन पृष्ठों को देखें: convert [image to JPG](https://products.aspose.com/slides/hi/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/svg-to-png/)।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या यह विधि बैच कन्वर्ज़न का समर्थन करती है?

हाँ, Aspose.Slides एक ही ऑपरेशन में कई स्लाइड्स को JPG में बैच रूपांतरण की अनुमति देता है।

### क्या रूपांतरण SmartArt, चार्ट और अन्य जटिल ऑब्जेक्ट्स को सपोर्ट करता है?

हाँ, Aspose.Slides सभी सामग्री, जिसमें SmartArt, चार्ट, टेबल, शेप्स आदि शामिल हैं, को रेंडर करता है। हालांकि, रेंडरिंग की सटीकता PowerPoint की तुलना में थोड़ा भिन्न हो सकती है, विशेष रूप से कस्टम या गायब फ़ॉन्ट्स के उपयोग पर।

### प्रोसेस किए जा सकने वाली स्लाइड्स की संख्या पर कोई प्रतिबंध है क्या?

Aspose.Slides स्वयं स्लाइड्स की संख्या पर कोई कड़ा प्रतिबंध नहीं लगाता। हालाँकि, बड़ी प्रेज़ेंटेशन या उच्च‑रिज़ोल्यूशन इमेजेज के साथ काम करते समय मेमोरी समाप्त होने की त्रुटि मिल सकती है।