---
title: C++ में प्रस्तुतियों को कुशलतापूर्वक मर्ज करना
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
- PowerPoint मिलाएँ
- प्रस्तुतियों को मिलाएँ
- स्लाइड्स को मिलाएँ
- PPT मिलाएँ
- PPTX मिलाएँ
- ODP मिलाएँ
- C++
- Aspose.Slides
description: "C++ में स्लाइड क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, तथा संरक्षित या बड़े फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को मर्ज करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for C++ एक [प्रस्तुति](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) से स्लाइड को क्लोन करके दूसरी में मर्ज करता है। मुख्य ऑपरेशन है [ISlideCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/), जो स्रोत स्लाइड की फॉर्मेटिंग को बनाए रख सकता है या क्लोन किए गए स्लाइड को लक्ष्य प्रस्तुति के मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्जिंग वर्कफ़्लो को कवर करता है:

- सभी स्लाइड को स्रोत फॉर्मेटिंग को बनाए रखते हुए मर्ज करें;
- चयनित स्लाइड को मर्ज करें;
- लक्ष्य प्रस्तुति से एक मास्टर लागू करें;
- लक्ष्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन किए गए स्लाइड को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक अंत‑से‑अंत वर्कफ़्लो में मर्ज करें;
- मास्टर, संसाधन, नोट्स, टिप्पणियाँ, मीडिया, फ़ॉन्ट, पासवर्ड, बड़े फ़ाइल, और मल्टी‑थ्रेडिंग संबंधी चिंताओं को संभालें।

## **मास्टर और लेआउट पर स्लाइड क्लोनिंग का प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश हिस्सा अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जो क्लोनिंग ओवरलोड चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड लक्ष्य प्रस्तुति में कैसे एकीकृत होगी।

इन तरीकों में से किसी एक के साथ [ISlideCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) का उपयोग करें:

- `AddClone(sourceSlide)` — स्रोत स्लाइड के लेआउट और फॉर्मेटिंग को बनाए रखें। आवश्यकता पड़ने पर स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वचालित रूप से क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है जिससे समान स्रोत मास्टर वाले दोहराए गए स्लाइड्स को बार‑बार क्लोन नहीं किया जाता।
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन किए गए स्लाइड को एक विशिष्ट लक्ष्य [IMasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट टाइप या नाम के आधार पर मिलते‑जुलते लेआउट की तलाश करता है।
- `AddClone(sourceSlide, destinationLayout)` — क्लोन किए गए स्लाइड को सीधे एक विशिष्ट लक्ष्य [ILayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/) से जोड़ें।

`AddClone` ओवरलोड को पास किया गया मास्टर या लेआउट **लक्ष्य** प्रस्तुति से संबंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **पूरा प्रस्तुति मर्ज करें और स्रोत फॉर्मेटिंग बनाए रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति से प्रत्येक स्लाइड को लक्ष्य प्रस्तुति में कॉपी करता है। यह तब उपयुक्त चयन है जब आयातित स्लाइड को अपना मूल थिम, मास्टर, और लेआउट संबंध बनाए रखने चाहिए।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

परिणामी प्रस्तुति में कई मास्टर हो सकते हैं जब स्रोत और लक्ष्य विभिन्न डिज़ाइन उपयोग करते हैं। यह अपेक्षित है क्योंकि स्रोत फॉर्मेटिंग को जानबूझकर बनाए रखा गया है।

## **चयनित स्लाइड को मर्ज करें**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल चयनित स्लाइड अनुक्रमांक को स्रोत प्रस्तुति से आयात करता है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने वाले अनुक्रमांक को क्लोन करने से पहले वैधता जाँचें।

## **लक्ष्य मास्टर के साथ स्लाइड मर्ज करें**

जब आयातित स्लाइड को पहले से लक्ष्य प्रस्तुति में मौजूद मास्टर का पालन करना चाहिए, तब [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) ओवरलोड का उपयोग करें।

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के टाइप या नाम से मेल खाने वाला उपयुक्त लेआउट चुनता है। यदि कोई उपयुक्त लेआउट नहीं मिलता और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन करके स्लाइड जोड़ी जाती है। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/details_pptxeditexception/) उत्पन्न होता है।

यदि आप मर्ज विफल होना चाहते हैं बजाय लक्ष्य मास्टर में अतिरिक्त लेआउट जोड़ने के, तो `false` उपयोग करें।

## **विशिष्ट लक्ष्य लेआउट के साथ स्लाइड मर्ज करें**

जब आप ठीक-ठीक जानते हैं कि आयातित स्लाइड को कौन सा लक्ष्य लेआउट उपयोग करना चाहिए, तब [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) ओवरलोड का उपयोग करें।

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

लक्ष्य लेआउट लागू करने से विरासत में मिला लेआउट संबंध बदलता है; यह स्रोत स्लाइड सामग्री को पुन: डिज़ाइन नहीं करता। यदि स्रोत और लक्ष्य लेआउट में प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम की जाँच करें कि विरासत में मिली फॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हैं या नहीं।

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयाम वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी स्लाइड को दूसरे आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री नए कैनवास के लिए स्वचालित रूप से पुनः डिज़ाइन नहीं होती। इसलिए आकार, स्केलिंग या दृश्यता में अनपेक्षित बदलाव हो सकता है।

एक व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदलें। [SlideSize::SetSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidesize/setsize/) मेथड मौजूदा सामग्री को स्केल कर सकता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

आकार बदलने से मेमोरी में स्रोत प्रस्तुति वस्तु बदलती है। यदि आपको मूल स्रोत प्रस्तुति को अन्य ऑपरेशनों के लिए अपरिवर्तित रखना है, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः उत्पन्न नहीं करता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो लक्ष्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड को स्पष्ट रूप से [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) के साथ क्लोन करें।

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

क्लोन किए गए स्लाइड निर्दिष्ट लक्ष्य सेक्शन में जोड़े जाते हैं। कई स्रोत सेक्शन को बनाए रखने के लिए, लक्ष्य में वही सेक्शन पुनः बनाएं और प्रत्येक स्रोत स्लाइड को संबंधित लक्ष्य सेक्शन से मैप करें।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न अंत‑से‑अंत उदाहरण पहले प्रस्तुति को लक्ष्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तभी खोलता है जब वह कॉपी हो रहा हो, और अंत में फ़ाइल सहेजता है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

यह आयातित स्लाइड की स्रोत फॉर्मेटिंग को बनाए रखने के लिए एक उपयोगी बेसलाइन है। यदि आपके आउटपुट को एकल लक्ष्य थिम उपयोग करना है, तो सरल `AddClone(slide)` कॉल को पहले दिखाए गए उपयुक्त लक्ष्य‑मास्टर या लक्ष्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट, और फॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग स्वचालित रूप से आवश्यक स्रोत मास्टर को लक्ष्य प्रस्तुति में ला सकता है। Aspose.Slides स्वचालित क्लोन किए गए मास्टर को दोहराए हुए क्लोनिंग से बचने के लिए एक आंतरिक रजिस्ट्री में रखता है। मैन्युअल रूप से क्लोन किए गए मास्टर इस रजिस्ट्री में ट्रैक नहीं होते, इसलिए केवल तब पूर्व‑क्लोनिंग करें जब आपको मास्टर संरचना पर स्पष्ट नियंत्रण चाहिए।

भले ही दो मास्टर या लेआउट का नाम समान हो, यह मानना न करें कि उनका दृश्य समान है। यदि कॉरपोरेट टेम्पलेट अंतिम रूप को नियंत्रित करता है, तो स्पष्ट रूप से लक्ष्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम सत्यापित करें।

### **नोट्स और टिप्पणियाँ**

स्पीकर नोट्स और स्लाइड टिप्पणियाँ स्लाइड सामग्री से जुड़ी होती हैं और स्लाइड क्लोन होने पर कॉपी हो जाती हैं। Aspose.Slides [presentation notes](https://docs.aspose.com/slides/hi/cpp/presentation-notes/) और [presentation comments](https://docs.aspose.com/slides/hi/cpp/presentation-comments/) के लिए समर्पित API भी प्रदान करता है।

यदि नोट‑पेज फॉर्मेटिंग महत्वपूर्ण है, तो मर्ज्ड प्रस्तुति की जाँच करें क्योंकि नोट्स मास्टर प्रस्तुति‑स्तर की वस्तु होते हैं और स्रोत फ़ाइलों के बीच भिन्न हो सकते हैं। समीक्षा वर्कफ़्लो में विभिन्न लेखकों या टेम्पलेट्स से जुड़े फ़ाइलों को सम्मिलित करने के बाद टिप्पणी लेखकों और थ्रेडेड टिप्पणियों की भी जाँच करें।

### **इमेज, ऑडियो, वीडियो, OLE ऑब्जेक्ट, और एक्सटर्नल लिंक**

स्लाइड प्रस्तुति‑स्तर के संसाधन जैसे इमेज, एम्बेडेड ऑडियो, एम्बेडेड वीडियो, और OLE डेटा का संदर्भ दे सकती है। केवल दृश्य शैप्स को कॉपी करने के बजाय स्लाइड स्वयं को क्लोन करें ताकि Aspose.Slides स्लाइड के संसाधन संबंधों को बनाए रख सके।

एम्बेडेड और लिंक्ड संसाधनों को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक बाहरी टार्गेट पर निर्भर रहता है; स्लाइड क्लोन करने से बाहरी लिंक एम्बेडेड कंटेंट में नहीं बदलता। मर्ज्ड प्रस्तुति जहाँ खोलेगी, उस पर्यावरण में लिंक्ड‑रिसोर्स पाथ और URL की जाँच करें।

Aspose.Slides स्वचालित क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन यह सामान्य गारंटी नहीं है कि असंबंधित स्रोत प्रस्तुतियों के समान बाइनरी संसाधन हमेशा डेडुप्लिकेट होंगे। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज्ड पैकेज की जाँच करें और परिणाम मापें बजाय अंतर्निहित डेडुप्लिकेशन पर भरोसा करने के।

### **एम्बेडेड फ़ॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को विभिन्न मशीनों में सुसंगत रहना चाहिए, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि सभी आवश्यक फ़ॉन्ट लक्ष्य पर्यावरण में उपलब्ध हों। आप [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) से एम्बेडेड फ़ॉन्ट देख सकते हैं और [Embed Fonts in Presentations](https://docs.aspose.com/slides/hi/cpp/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

यह भी सत्यापित करें कि आप स्रोत फ़ाइलों द्वारा उपयोग किए गए फ़ॉन्ट को एम्बेड करने के अनुमत हैं या नहीं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑सुरक्षित प्रस्तुतियाँ**

पासवर्ड‑सुरक्षित स्रोत को स्लाइड क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) के माध्यम से प्रदान करें।

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

एनक्रिप्टेड स्रोत को खोलने से लक्ष्य प्रस्तुति पर वही सुरक्षा स्वचालित रूप से लागू नहीं होती। आवश्यकता पड़ने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियाँ और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन इमेज, ऑडियो, वीडियो, या अन्य बड़े बाइनरी ऑब्जेक्ट वाली बड़ी प्रस्तुतियाँ काफी मेमोरी खा सकती हैं। [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) BLOB हैंडलिंग और टेम्प‑फ़ाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए देखें [Manage Presentation BLOBs](https://docs.aspose.com/slides/hi/cpp/manage-blob/)।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल पाथ से लोड करना पसंद करें, प्रत्येक स्रोत प्रस्तुति को मर्ज होने के तुरंत बाद डिस्पोज़ करें, और मध्यवर्ती परिणाम को बार‑बार सहेजने से बचें जब तक वर्कफ़्लो में चेकपॉइंट की आवश्यकता न हो।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड से एक साथ लोड, मॉडिफ़ाई, सहेज या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र कार्यों को समानांतर चलाते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस उपयोग करें और [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/hi/cpp/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिज़ाइन कैसे बनाए रखूँ?**

`AddClone(sourceSlide)` का उपयोग करें बिना लक्ष्य मास्टर या लेआउट निर्दिष्ट किए। Aspose.Slides आवश्यक होने पर स्वचालित रूप से स्रोत मास्टर को क्लोन कर सकता है।

**आयातित स्लाइड को लक्ष्य थिम का उपयोग कैसे करायें?**

ऐसे ओवरलोड का उपयोग करें जो लक्ष्य मास्टर स्वीकार करता है। लक्ष्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने की कोशिश करेगा।

**किस स्थिति में लक्ष्य लेआउट का उपयोग लक्ष्य मास्टर की बजाय करना चाहिए?**

जब प्रत्येक आयातित स्लाइड को ज्ञात एक ही लेआउट उपयोग करना चाहिए, तो विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट टाइप या नाम के आधार पर उस मास्टर के लेआउट में से चयन करे, तो मास्टर उपयोग करें।

**विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हाँ, लेकिन स्लाइड सामग्री को लक्ष्य आयामों के लिए स्वचालित रूप से पुनः डिज़ाइन नहीं किया जाता। यदि भविष्यवाणी योग्य प्लेसमेंट चाहिए, तो स्रोत प्रस्तुति को पहले [SlideSize::SetSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidesize/setsize/) और [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidesizescaletype/) के साथ आकार बदलें।

**क्या मैं PPT, PPTX, और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हाँ। प्रत्येक स्रोत प्रस्तुति लोड करें, आवश्यक स्लाइड को एक लक्ष्य में क्लोन करें, और लक्ष्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूँकि प्रस्तुति फ़ॉर्मेट पूरी तरह समान सुविधाएँ नहीं देते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल कंटेंट की जाँच करें। देखें [Supported File Formats](https://docs.aspose.com/slides/hi/cpp/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

केवल स्लाइड क्लोन करने वाले बेसिक लूप से नहीं। लक्ष्य में आवश्यक सेक्शन पुनः बनाएँ और सेक्शन संरचना को बनाए रखने के लिए [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) के सेक्शन ओवरलोड का उपयोग करें।

**क्या स्पीकर नोट्स और टिप्पणियाँ संरक्षित रहती हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी हो जाती हैं। यदि वर्कफ़्लो नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखक, या थ्रेडेड समीक्षा डेटा पर निर्भर करता है, तो मर्ज्ड परिणाम की जाँच करें क्योंकि इन परिदृश्यों में प्रस्तुति‑स्तर संरचनाएँ और स्लाइड‑स्तर कंटेंट दोनों शामिल होते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट, और हाइपरलिंक का क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के संसाधन संबंधों के हिस्से के रूप में ले जाया जाता है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए मर्ज के बाद उनके टार्गेट फ़ाइल या URL उपलब्ध होने चाहिए।

**क्या प्रत्येक स्रोत से एम्बेडेड फ़ॉन्ट मर्ज्ड प्रस्तुति में उपलब्ध होते हैं?**

स्लाइड क्लोनिंग के आधार पर फ़ॉन्ट डिप्लॉयमेंट की गारंटी न रखें। लक्ष्य में एम्बेडेड फ़ॉन्ट देखने और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑सुरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) के साथ इसे खोलें, फिर सामान्य रूप से उसकी स्लाइड क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बड़ी प्रस्तुतियों को कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट मेमोरी पर भारी हों, तो BLOB प्रबंधन का उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को जल्द‑से‑जल्द डिस्पोज़ करें, और अंतिम परिणाम केवल आवश्यक हो तो ही सहेजें।

**क्या मैं कई थ्रेड से स्लाइड को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड से समवर्ती रूप से उपयोग न करें। प्रत्येक मर्ज ऑपरेशन को स्वतंत्र प्रस्तुति इंस्टेंस तक सीमित रखें।