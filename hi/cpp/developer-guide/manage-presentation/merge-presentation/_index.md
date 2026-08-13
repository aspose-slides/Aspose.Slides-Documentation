---
title: C++ में प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/cpp/merge-presentation/
keywords:
- PowerPoint को मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT को मर्ज करें
- PPTX को मर्ज करें
- ODP को मर्ज करें
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को बिना प्रयास के मर्ज करें, जिससे आपका कार्यप्रवाह सुगम हो जाए।"
---
## **परिचय**

Aspose.Slides आपको एक प्रस्तुति से दूसरी प्रस्तुति में स्लाइड्स की क्लोनिंग करके प्रस्तुतियों को मर्ज करने की सुविधा देता है। यह लेख बताता है कि पूरी प्रस्तुतियों या चयनित स्लाइड्स को कैसे मर्ज करें, मर्ज के दौरान स्लाइड मास्टर या विशिष्ट लेआउट का उपयोग कैसे करें, विभिन्न स्लाइड आकार वाली प्रस्तुतियों को कैसे संभालें, और मर्ज की गई स्लाइड्स को प्रस्तुति सेक्शन में कैसे जोड़ें। इसमें मर्ज की गई सामग्री से संबंधित व्यावहारिक नोट्स भी शामिल हैं, जैसे स्पीकर नोट्स, टिप्पणियाँ, पासवर्ड‑सुरक्षित स्रोत फ़ाइलें, और थ्रेड उपयोग।

## **प्रस्तुति मर्जिंग**

जब आप एक प्रस्तुति को दूसरी के साथ मर्ज करते हैं, तो आप मूल रूप से उनके स्लाइड्स को एक एकल प्रस्तुति में संयोजित कर रहे होते हैं ताकि एक फ़ाइल प्राप्त हो सके।

{{% alert title="Info" color="info" %}}

अधिकांश प्रस्तुति कार्यक्रम (PowerPoint या OpenOffice) ऐसी फ़ंक्शनालिटी नहीं रखते जो उपयोगकर्ताओं को प्रस्तुतियों को इस प्रकार मिलाने की अनुमति दें।

[**Aspose.Slides for C++**](https://products.aspose.com/slides/hi/cpp/), हालांकि, आपको विभिन्न तरीकों से प्रस्तुतियों को मर्ज करने की सुविधा देता है। आप सभी आकार, शैली, पाठ, फ़ॉर्मेटिंग, टिप्पणी, एनीमेशन आदि के साथ प्रस्तुतियों को बिना गुणवत्ता या डेटा हानि की चिंता किए मर्ज कर सकते हैं।

**See also**

[Clone Slides](https://docs.aspose.com/slides/hi/cpp/clone-slides/)*.* 

{{% /alert %}}

### **क्या मर्ज किया जा सकता है**

Aspose.Slides के साथ आप मर्ज कर सकते हैं

* पूरी प्रस्तुतियाँ। प्रस्तुतियों की सभी स्लाइड्स एक ही प्रस्तुति में आ जाती हैं
* विशिष्ट स्लाइड्स। चयनित स्लाइड्स एक ही प्रस्तुति में आ जाती हैं
* एक ही फ़ॉर्मेट की प्रस्तुतियाँ (PPT से PPT, PPTX से PPTX, आदि) और विभिन्न फ़ॉर्मेट की प्रस्तुतियाँ (PPT से PPTX, PPTX से ODP, आदि) एक-दूसरे के साथ।

{{% alert title="Note" color="warning" %}} 

प्रस्तुतियों के अलावा, Aspose.Slides आपको अन्य फ़ाइलों को भी मर्ज करने की अनुमति देता है:

* [Images](https://products.aspose.com/slides/hi/cpp/merger/image-to-image/), जैसे कि [JPG to JPG](https://products.aspose.com/slides/hi/cpp/merger/jpg-to-jpg/) या [PNG to PNG](https://products.aspose.com/slides/hi/cpp/merger/png-to-png/)
* दस्तावेज़, जैसे कि [PDF to PDF](https://products.aspose.com/slides/hi/cpp/merger/pdf-to-pdf/) या [HTML to HTML](https://products.aspose.com/slides/hi/cpp/merger/html-to-html/)
* और दो अलग-अलग फ़ाइलें जैसे कि [image to PDF](https://products.aspose.com/slides/hi/cpp/merger/image-to-pdf/) या [JPG to PDF](https://products.aspose.com/slides/hi/cpp/merger/jpg-to-pdf/) या [TIFF to PDF](https://products.aspose.com/slides/hi/cpp/merger/tiff-to-pdf/)।

{{% /alert %}}

### **मर्जिंग विकल्प**

आप ऐसे विकल्प लागू कर सकते हैं जो यह निर्धारित करते हैं कि

* आउटपुट प्रस्तुति की प्रत्येक स्लाइड का अपना अनूठा शैली बना रहे
* सभी स्लाइड्स के लिए एक विशिष्ट शैली उपयोग में रहे।

प्रस्तुतियों को मर्ज करने के लिए, Aspose.Slides [AddClone](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) मेथड्स प्रदान करता है (जो [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection) इंटरफ़ेस का हिस्सा हैं)। `AddClone` मेथड्स की कई कार्यान्वयनें हैं जो प्रस्तुति मर्ज प्रक्रिया के पैरामीटर को परिभाषित करती हैं। प्रत्येक Presentation ऑब्जेक्ट के पास एक [Slides](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) संग्रह होता है, इसलिए आप उस प्रस्तुति से `AddClone` मेथड को कॉल कर सकते हैं जिसमें आप स्लाइड्स को मर्ज करना चाहते हैं।

`AddClone` मेथड एक `ISlide` ऑब्जेक्ट लौटाता है, जो स्रोत स्लाइड की क्लोन होती है। आउटपुट प्रस्तुति की स्लाइड्स केवल स्रोत की स्लाइड्स की कॉपी होती हैं। इसलिए आप परिणामस्वरूप स्लाइड्स में परिवर्तन कर सकते हैं (जैसे शैली या फ़ॉर्मेटिंग विकल्प या लेआउट लागू करना) बिना स्रोत प्रस्तुतियों को प्रभावित किए।

## **प्रेजेंटेशन मर्ज करें** 

Aspose.Slides वह [**AddClone (ISlide)**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) मेथड प्रदान करता है जो आपको स्लाइड्स को इस प्रकार संयोजित करने देता है कि स्लाइड्स अपने लेआउट और शैली को बनाए रखें (डिफ़ॉल्ट पैरामीटर)।

यह C++ कोड दिखाता है कि कैसे प्रस्तुतियों को मर्ज किया जाता है:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **स्लाइड मास्टर के साथ प्रेजेंटेशन मर्ज करें**

Aspose.Slides वह [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) मेथड प्रदान करता है जो आपको स्लाइड्स को संयोजित करने देता है जबकि एक स्लाइड मास्टर प्रस्तुति टेम्प्लेट लागू किया जाता है। इस प्रकार, यदि आवश्यक हो, तो आप आउटपुट प्रस्तुति की स्लाइड्स की शैली बदल सकते हैं।

यह C++ कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

स्लाइड मास्टर के लिए स्लाइड लेआउट स्वचालित रूप से निर्धारित किया जाता है। जब उपयुक्त लेआउट निर्धारित नहीं किया जा सकता, यदि `allowCloneMissingLayout` बूलियन पैरामीटर `AddClone` मेथड में true पर सेट है, तो स्रोत स्लाइड का लेआउट उपयोग किया जाता है। अन्यथा, [PptxEditException](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) फेंका जाएगा।

{{% /alert %}}

यदि आप चाहते हैं कि आउटपुट प्रस्तुति की स्लाइड्स का लेआउट अलग हो, तो मर्ज करते समय [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) मेथड का उपयोग करें।

## **प्रेजेंटेशन से विशिष्ट स्लाइड्स मर्ज करें**

एक से अधिक प्रस्तुतियों से विशिष्ट स्लाइड्स को मर्ज करना कस्टम स्लाइड डेक बनाने के लिए उपयोगी है। Aspose.Slides C++ आपको केवल आवश्यक स्लाइड्स को चुनने और आयात करने की अनुमति देता है। API मूल स्लाइड्स की फ़ॉर्मेटिंग, लेआउट और डिज़ाइन को बरकरार रखता है।

निम्नलिखित C++ कोड एक नई प्रस्तुति बनाता है, दो अन्य प्रस्तुतियों से टाइटल स्लाइड्स जोड़ता है, और परिणाम को फ़ाइल में सहेजता है:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ऊपर कोड में घोषित किया गया है.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **स्लाइड लेआउट के साथ प्रेजेंटेशन मर्ज करें**

यह C++ कोड दिखाता है कि कैसे प्रस्तुतियों से स्लाइड्स को संयोजित किया जाता है जबकि आपके पसंदीदा स्लाइड लेआउट को लागू किया जाता है ताकि एक आउटपुट प्रस्तुति प्राप्त हो:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

{{% alert title="Note" color="warning" %}} 

आप विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज नहीं कर सकते। 

{{% /alert %}}

दो विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करने के लिए, आपको एक प्रस्तुति का आकार बदलना होगा जिससे वह दूसरी प्रस्तुति के आकार से मेल खाए।

यह नमूना कोड वर्णित ऑपरेशन को दर्शाता है:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

यह C++ कोड दिखाता है कि कैसे एक विशिष्ट स्लाइड को प्रस्तुति के एक सेक्शन में मर्ज किया जाता है:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

स्लाइड को सेक्शन के अंत में जोड़ा जाता है।

{{% alert title="Tip" color="info" %}}

Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG इमेजेज़ मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि।

{{% /alert %}}

## **FAQ**

### क्या मर्ज के दौरान स्पीकर नोट्स संरक्षित रहते हैं?

हां। स्लाइड्स को क्लोन करते समय, Aspose.Slides सभी स्लाइड तत्वों को ले जाता है, जिसमें नोट्स, फ़ॉर्मेटिंग और एनीमेशन शामिल हैं।

### क्या टिप्पणियाँ और उनके लेखक ट्रांसफ़र होते हैं?

टिप्पणियाँ, स्लाइड सामग्री का हिस्सा होने के कारण, स्लाइड के साथ कॉपी की जाती हैं। टिप्पणी लेखक लेबल परिणामस्वरूप प्रस्तुति में टिप्पणी ऑब्जेक्ट के रूप में संरक्षित रहते हैं।

### यदि स्रोत प्रस्तुति पासवर्ड‑सुरक्षित है तो क्या करना चाहिए?

इसे [पासवर्ड के साथ खोलना](/slides/hi/cpp/password-protected-presentation/) चाहिए और [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) का उपयोग करना चाहिए; लोड करने के बाद, उन स्लाइड्स को सुरक्षित रूप से अन-protected लक्ष्य फ़ाइल (या सुरक्षित फ़ाइल) में क्लोन किया जा सकता है।

### मर्ज ऑपरेशन कितनी थ्रेड‑सेफ़ है?

एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को [कई थ्रेड्स](/slides/hi/cpp/multithreading/) से उपयोग न करें। अनुशंसित नियम है “एक दस्तावेज़ — एक थ्रेड”; अलग-अलग फ़ाइलों को अलग-अलग थ्रेड्स में समानांतर रूप से प्रोसेस किया जा सकता है।