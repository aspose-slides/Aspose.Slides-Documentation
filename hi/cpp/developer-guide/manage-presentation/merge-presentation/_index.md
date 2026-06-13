---
title: C++ में प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/cpp/merge-presentation/
keywords:
- PowerPoint मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT मर्ज करें
- PPTX मर्ज करें
- ODP मर्ज करें
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT संयोजित करें
- PPTX संयोजित करें
- ODP संयोजित करें
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को सहजता से मर्ज करें, जिससे आपका कार्यप्रवाह सरल हो जाता है।"
---
## **परिचय**

Aspose.Slides आपको एक प्रस्तुतीकरण से दूसरी में स्लाइड को क्लोन करके प्रस्तुतियों को मर्ज करने की सुविधा देता है। यह लेख पूरी प्रस्तुतियों या चयनित स्लाइडों को मर्ज करने, मर्ज के दौरान स्लाइड मास्टर या विशिष्ट लेआउट का उपयोग करने, विभिन्न स्लाइड आकार वाली प्रस्तुतियों को संभालने, और मर्ज की गई स्लाइडों को प्रस्तुतीकरण सेक्शन में जोड़ने के तरीकों को समझाता है। यह मर्ज किए गए कंटेंट से संबंधित व्यावहारिक नोट्स को भी कवर करता है, जिसमें स्पीकर नोट्स, टिप्पणियाँ, पासवर्ड-प्रोटेक्टेड स्रोत फ़ाइलें, और थ्रेड उपयोग शामिल हैं।

## **Presentation Merging**

जब आप एक प्रस्तुतीकरण को दूसरे में मर्ज करते हैं, तो आप प्रभावी रूप से उनकी स्लाइडों को एक ही प्रस्तुतीकरण में संयोजित करके एक फ़ाइल बनाते हैं। 

{{% alert title="Info" color="info" %}}
बहुत से प्रस्तुतीकरण प्रोग्राम (PowerPoint या OpenOffice) में ऐसी सुविधाएँ नहीं होतीं जो उपयोगकर्ताओं को प्रस्तुतियों को इस तरह मिलाने की अनुमति देती हों। 
[**Aspose.Slides for C++**](https://products.aspose.com/slides/hi/cpp/), हालांकि, आपको विभिन्न तरीकों से प्रस्तुतियों को मर्ज करने की सुविधा देता है। आप सभी आकार, शैली, टेक्स्ट, फ़ॉर्मेटिंग, टिप्पणियों, एनीमेशन आदि के साथ प्रस्तुतियों को बिना गुणवत्ता या डेटा की हानि के मर्ज कर सकते हैं। 
**संबंधित लेख**
[Clone Slides](https://docs.aspose.com/slides/hi/cpp/clone-slides/)*.* 
{{% /alert %}}

### **What Can Be Merged**

Aspose.Slides के साथ आप मर्ज कर सकते हैं 

* पूरी प्रस्तुतियाँ। सभी स्लाइडें एक ही प्रस्तुतीकरण में आती हैं
* विशिष्ट स्लाइडें। चयनित स्लाइडें एक ही प्रस्तुतीकरण में आती हैं
* एक ही फ़ॉर्मेट (PPT से PPT, PPTX से PPTX, आदि) या विभिन्न फ़ॉर्मेट (PPT से PPTX, PPTX से ODP, आदि) में प्रस्तुतियों को एक-दूसरे में मर्ज कर सकते हैं। 

{{% alert title="Note" color="warning" %}} 
प्रस्तुतियों के अलावा, Aspose.Slides आपको अन्य फ़ाइलों को भी मर्ज करने की अनुमति देता है:

* [Images](https://products.aspose.com/slides/hi/cpp/merger/image-to-image/), जैसे कि [JPG to JPG](https://products.aspose.com/slides/hi/cpp/merger/jpg-to-jpg/) या [PNG to PNG](https://products.aspose.com/slides/hi/cpp/merger/png-to-png/)
* Documents, जैसे कि [PDF to PDF](https://products.aspose.com/slides/hi/cpp/merger/pdf-to-pdf/) या [HTML to HTML](https://products.aspose.com/slides/hi/cpp/merger/html-to-html/)
* और दो विभिन्न फ़ाइलें जैसे कि [image to PDF](https://products.aspose.com/slides/hi/cpp/merger/image-to-pdf/) या [JPG to PDF](https://products.aspose.com/slides/hi/cpp/merger/jpg-to-pdf/) या [TIFF to PDF](https://products.aspose.com/slides/hi/cpp/merger/tiff-to-pdf/)। 
{{% /alert %}}

### **Merging Options**

आप ऐसे विकल्प लागू कर सकते हैं जो निर्धारित करते हैं कि

* आउटपुट प्रस्तुतीकरण की प्रत्येक स्लाइड एक अलग शैली रखे
* सभी स्लाइडों के लिए एक विशिष्ट शैली उपयोग की जाए। 

प्रस्तुतीकरण मर्ज करने के लिए, Aspose.Slides [AddClone](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) मेथड्स प्रदान करता है (जो [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection) इंटरफ़ेस का हिस्सा हैं)। `AddClone` मेथड्स की कई इम्प्लीमेंटेशन हैं जो प्रस्तुतीकरण मर्ज प्रक्रिया के पैरामीटर निर्धारित करती हैं। प्रत्येक Presentation ऑब्जेक्ट के पास एक [Slides](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) कलेक्शन होता है, इसलिए आप उस प्रस्तुतीकरण से `AddClone` मेथड को कॉल कर सकते हैं जिसमें आप स्लाइडें जोड़ना चाहते हैं। 

`AddClone` मेथड एक `ISlide` ऑब्जेक्ट लौटाता है, जो स्रोत स्लाइड की क्लोन होती है। आउटपुट प्रस्तुतीकरण की स्लाइडें केवल स्रोत की स्लाइडों की प्रतिलिपि होती हैं। इसलिए, आप परिणामी स्लाइडों में परिवर्तन (जैसे शैली या फ़ॉर्मेटिंग विकल्प या लेआउट लागू करना) कर सकते हैं बिना स्रोत प्रस्तुतियों पर प्रभाव डाले। 

## **Merge Presentations** 

Aspose.Slides [**AddClone (ISlide)**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) मेथड प्रदान करता है जो आपको स्लाइडें संयोजित करने की अनुमति देता है जबकि स्लाइडें अपने लेआउट और शैली को बनाए रखती हैं (डिफ़ॉल्ट पैरामीटर)। 

यह C++ कोड दिखाता है कि कैसे प्रस्तुतियों को मर्ज किया जाता है:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Presentations with a Slide Master**

Aspose.Slides [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) मेथड प्रदान करता है जो आपको स्लाइड मास्टर प्रस्तुतीकरण टेम्पलेट लागू करते हुए स्लाइडें संयोजित करने की अनुमति देता है। इस तरीके से, यदि आवश्यक हो, आप आउटपुट प्रस्तुतीकरण की स्लाइडों की शैली बदल सकते हैं। 

यह C++ कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
स्लाइड मास्टर के लिए स्लाइड लेआउट स्वतः निर्धारित किया जाता है। यदि उपयुक्त लेआउट निर्धारित नहीं किया जा सकता, और `AddClone` मेथड के `allowCloneMissingLayout` बूलियन पैरामीटर को true सेट किया गया है, तो स्रोत स्लाइड का लेआउट उपयोग किया जाता है। अन्यथा, [PptxEditException](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) फ़ेंका जाएगा। 
{{% /alert %}}

यदि आप चाहते हैं कि आउटपुट प्रस्तुतीकरण की स्लाइडें अलग लेआउट रखें, तो मर्ज करते समय [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) मेथड का उपयोग करें। 

## **Merge Specific Slides from Presentations**

कई प्रस्तुतियों से विशिष्ट स्लाइडें मर्ज करना कस्टम स्लाइड डेक बनाने में उपयोगी है। Aspose.Slides C++ आपको केवल आवश्यक स्लाइडें चयनित और इम्पोर्ट करने की अनुमति देता है। API मूल स्लाइडों की फ़ॉर्मेटिंग, लेआउट और डिज़ाइन को सुरक्षित रखता है।

निम्नलिखित C++ कोड एक नई प्रस्तुतीकरण बनाता है, दो अन्य प्रस्तुतियों से शीर्षक स्लाइडें जोड़ता है, और परिणाम को फ़ाइल में सहेजता है:

```cpp
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

## **Merge Presentations with a Slide Layout**

यह C++ कोड दिखाता है कि कैसे आप प्रस्तुतियों से स्लाइडें संयोजित करके उन्हें अपने इच्छित स्लाइड लेआउट पर लागू कर सकते हैं और एक ही आउटपुट प्रस्तुतीकरण प्राप्त कर सकते हैं:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 
आप अलग-अलग स्लाइड आकार वाली प्रस्तुतियों को मर्ज नहीं कर सकते। 
{{% /alert %}}

दो अलग स्लाइड आकार वाली प्रस्तुतियों को मर्ज करने के लिए, आपको एक प्रस्तुतीकरण का आकार दूसरे के आकार से मेल खाने के लिए बदलना होगा। 

यह उदाहरण कोड वर्णित ऑपरेशन को दर्शाता है:

```cpp
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

## **Merge Slides to a Presentation Section**

यह C++ कोड दिखाता है कि कैसे आप एक विशिष्ट स्लाइड को प्रस्तुतीकरण के एक सेक्शन में मर्ज कर सकते हैं:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

यह स्लाइड सेक्शन के अंत में जोड़ी जाती है। 

{{% alert title="Tip" color="primary" %}}
Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG छवियों को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि। 
{{% /alert %}}

## **FAQ**

**क्या मर्ज के दौरान स्पीकर नोट्स संरक्षित रहते हैं?**

हाँ। स्लाइडें क्लोन करने पर Aspose.Slides सभी स्लाइड तत्वों को, जिनमें नोट्स, फ़ॉर्मेटिंग और एनीमेशन शामिल हैं, साथ ले जाता है।

**क्या टिप्पणियों और उनके लेखकों को स्थानांतरित किया जाता है?**

टिप्पणियाँ, जो स्लाइड कंटेंट का हिस्सा हैं, स्लाइड के साथ कॉपी हो जाती हैं। टिप्पणी लेखक लेबल परिणामस्वरूप प्रस्तुतीकरण में टिप्पणी ऑब्जेक्ट के रूप में संरक्षित रहते हैं।

**यदि स्रोत प्रस्तुतीकरण पासवर्ड-प्रोटेक्टेड है तो क्या होगा?**

इसे [पासवर्ड के साथ खोलना](/slides/hi/cpp/password-protected-presentation/) आवश्यक है, जिसे आप [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) द्वारा कर सकते हैं; लोड करने के बाद, उन स्लाइडों को सुरक्षित रूप से अनप्रोटेक्टेड लक्ष्य फ़ाइल (या प्रोटेक्टेड फ़ाइल) में क्लोन किया जा सकता है।

**मर्ज ऑपरेशन कितनी थ्रेड-सेफ़ है?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को [multiple threads](/slides/hi/cpp/multithreading/) से उपयोग न करें। अनुशंसित नियम है "एक दस्तावेज़ — एक थ्रेड"; विभिन्न फ़ाइलों को अलग-अलग थ्रेडों में समानांतर रूप से प्रोसेस किया जा सकता है।