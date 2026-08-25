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
description: "C++ में स्लाइड क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, तथा संरक्षित या बड़ी फ़ाइलों को संभालकर PowerPoint और OpenDocument प्रस्तुतियों को कैसे मर्ज करें, यह जानें।"
---
## **अवलोकन**

Aspose.Slides for C++ प्रस्तुतियों को एक [प्रस्तुति](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) से दूसरी में स्लाइड क्लोन करके मिलाता है। मुख्य ऑपरेशन है [ISlideCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/), जो स्रोत स्लाइड की फॉर्मेटिंग को संरक्षित रख सकता है या क्लोन की गई स्लाइड को गंतव्य प्रस्तुति में मास्टर या लेआउट से संलग्न कर सकता है।

यह लेख सबसे सामान्य मर्जिंग वर्कफ़्लो को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फॉर्मेटिंग को संरक्षित रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- गंतव्य प्रस्तुति से एक मास्टर लागू करें;
- गंतव्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्य बनाएं;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- एक अंत‑तेज वर्कफ़्लो में कई प्रस्तुतियों को मर्ज करें;
- मास्टर, संसाधन, नोट्स, टिप्पणी, मीडिया, फ़ॉन्ट, पासवर्ड, बड़े फ़ाइलें, और मल्टीथ्रेडिंग संबंधी मामलों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश भाग अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जिस क्लोनिंग ओवरलोड का चयन करते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड गंतव्य प्रस्तुति में कैसे एकीकृत होगी।

इनमें से किसी एक तरीके से [ISlideCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) का उपयोग करें:

- `AddClone(sourceSlide)` — स्रोत स्लाइड के लेआउट और फॉर्मेटिंग को संरक्षित रखें। आवश्यकता पड़ने पर स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि वही मास्टर दोबारा क्लोन न हो।
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट गंतव्य [IMasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) से संलग्न करें। Aspose.Slides लेआउट प्रकार या नाम के आधार पर उस मास्टर के तहत मेल खाने वाला लेआउट खोजता है।
- `AddClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट गंतव्य [ILayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/) से संलग्न करें।

`AddClone` ओवरलोड को पास किया गया मास्टर या लेआउट **गंतव्य** प्रस्तुति से संबंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **पूरा प्रस्तुति मर्ज करें और स्रोत फॉर्मेटिंग को संरक्षित रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति से प्रत्येक स्लाइड को गंतव्य प्रस्तुति में कॉपी करता है। यह विकल्प तब उपयुक्त है जब इम्पोर्ट की गई स्लाइड्स को अपना मूल थीम, मास्टर और लेआउट संबंध बनाए रखना चाहिए।

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

जब स्रोत और गंतव्य विभिन्न डिज़ाइनों का उपयोग करते हैं तो परिणामी प्रस्तुति में कई मास्टर हो सकते हैं। यह अपेक्षित है जब स्रोत फॉर्मेटिंग जानबूझकर संरक्षित रखी जाती है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल चयनित स्लाइड अनुक्रमांक को स्रोत प्रस्तुति से इम्पोर्ट करता है।

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

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से प्राप्त होने पर क्लोन करने से पहले स्लाइड अनुक्रमांक को मान्य करें।

## **गंतव्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब इम्पोर्ट की गई स्लाइड्स को पहले से गंतव्य प्रस्तुति में मौजूद मास्टर का पालन करना चाहिए, तो [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) ओवरलोड का उपयोग करें।

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

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मेल खाने वाला उपयुक्त लेआउट चुनता है। यदि उपयुक्त लेआउट नहीं मिलता और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/details_pptxeditexception/) फेंका जाता है।

यदि आप मर्ज को विफल करना चाहते हैं बजाय गंतव्य मास्टर में अतिरिक्त लेआउट जोड़ने के, तो `false` का उपयोग करें।

## **विशिष्ट गंतव्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप ठीक-ठीक जानते हैं कि इम्पोर्ट की गई स्लाइड्स को किस गंतव्य लेआउट का उपयोग करना चाहिए, तो [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) ओवरलोड का उपयोग करें।

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

गंतव्य लेआउट लागू करने से विरासत में मिला लेआउट संबंध बदलता है; यह स्रोत स्लाइड की सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और गंतव्य लेआउट में प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम की जाँच करें कि विरासत में मिला फॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हैं या नहीं।

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयामों वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन एक स्लाइड को दूसरे आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री को नई कैनवास के लिए स्वचालित रूप से पुनः डिज़ाइन नहीं किया जाता। इसलिए आकार, स्केल या स्थान गलत हो सकता है या स्लाइड दृश्य क्षेत्र के बाहर जा सकता है।

एक व्यावहारिक दृष्टिकोण यह है कि क्लोनिंग से पहले स्रोत प्रस्तुति का आकार बदलें। [SlideSize::SetSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidesize/setsize/) मेथड मौजूदा सामग्री को स्केल कर सकता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

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

रिसाइज करने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदल जाता है। यदि आपको अन्य ऑपरेशनों के लिए मूल स्रोत प्रस्तुति अपरिवर्तित चाहिए, तो मर्जी के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः नहीं बनाता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो गंतव्य प्रस्तुति में सेक्शन बनाएँ या चुनें और स्लाइड्स को स्पष्ट रूप से [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) के साथ क्लोन करें।

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

क्लोन की गई स्लाइड्स निर्दिष्ट गंतव्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिए, [Presentation::get_Sections](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_sections/) को एन्न्यूमरेट करें, प्रत्येक स्रोत सेक्शन की वर्तमान स्लाइड्स को [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/getslideslistofsection/) से प्राप्त करें, गंतव्य में सेक्शन फिर से बनाएँ, और प्रत्येक लौटाई गई स्लाइड को उसके संबंधित गंतव्य सेक्शन में क्लोन करें। पूर्ण सेक्शन‑एन्न्यूमरेशन उदाहरण के लिए [Manage Slide Sections](/slides/hi/cpp/slide-section/) देखें, जिसमें खाली सेक्शन और संरचनात्मक बदलाव शामिल हैं।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न अंत‑से‑अंत उदाहरण पहली प्रस्तुति को गंतव्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्य करता है, प्रत्येक स्रोत को केवल तभी खोलता है जब वह कॉपी हो रहा हो, और अंत में फ़ाइल को एक बार सहेजता है।

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

यह इम्पोर्ट की गई स्लाइड्स की स्रोत फॉर्मेटिंग को संरक्षित रखने के लिए एक उपयोगी बेसलाइन है। यदि आपके आउटपुट को एकल गंतव्य थीम का उपयोग करना है, तो सरल `AddClone(slide)` कॉल को पहले दिखाए गए उपयुक्त गंतव्य‑मास्टर या गंतव्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट, और फॉर्मेटिंग की शुद्धता**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में ला सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को दोहराने से बचाने के लिए एक आंतरिक रेज़िस्ट्री बनाए रखता है। मैन्युअल रूप से क्लोन किए गए मास्टर उस रेज़िस्ट्री द्वारा ट्रैक नहीं होते, इसलिए जब तक आप मास्टर संरचना पर स्पष्ट नियंत्रण नहीं चाहते तब तक पूर्व‑क्लोनिंग से बचें।

दो मास्टर या लेआउट जिनका नाम समान है, यह न मानें कि वे दृश्य रूप से समान हैं। यदि कॉरपोरेट टेम्प्लेट को अंतिम रूप को नियंत्रित करना है, तो स्पष्ट रूप से गंतव्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम की पुष्टि करें।

### **नोट्स और टिप्पणी**

स्पीकर नोट्स और स्लाइड टिप्पणी स्लाइड सामग्री से जुड़ी होती हैं और स्लाइड क्लोन होने पर कॉपी हो जाती हैं। Aspose.Slides [presentation notes](/slides/hi/cpp/presentation-notes/) और [presentation comments](/slides/hi/cpp/presentation-comments/) के लिए समर्पित API भी प्रदान करता है।

यदि नोट‑पेज फॉर्मेटिंग महत्वपूर्ण है, तो मर्ज्ड प्रस्तुति की जाँच करें क्योंकि नोट मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों के बीच भिन्न हो सकते हैं। रिव्यू वर्कफ़्लो के लिये, विभिन्न लेखक या टेम्प्लेट से फ़ाइलें मिलाने के बाद टिप्पणी लेखकों और थ्रेडेड टिप्पणी की भी पुष्टि करें।

### **छवियाँ, ऑडियो, वीडियो, OLE ऑब्जेक्ट, और बाहरी लिंक**

स्लाइड्स प्रस्तुति‑स्तर के संसाधनों जैसे छवियां, एम्बेडेड ऑडियो, एम्बेडेड वीडियो, और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्य आकारों को कॉपी करने के बजाय पूरी स्लाइड को क्लोन करें ताकि Aspose.Slides उसके संसाधनों के संबंध को बनाए रख सके।

एम्बेडेड और लिंक्ड संसाधनों को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट, या हाइपरलिंक अपने बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड को क्लोन करने से बाहरी लिंक एम्बेडेड सामग्री नहीं बन जाता। मर्ज्ड प्रस्तुति के खुले जाने वाले वातावरण में लिंक्ड‑संसाधन पथ और URL की जाँच करें।

Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को स्पष्ट रूप से ट्रैक करता है, लेकिन इसे यह सामान्य गारंटी नहीं समझें कि असंबद्ध स्रोत प्रस्तुतियों से समान बाइनरी संसाधन हमेशा डेडुप्लिकेट हो जाएंगे। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज्ड पैकेज का निरीक्षण करें और परिणाम मापें, न कि निहित डेडुप्लिकेशन पर भरोसा करें।

### **एम्बेडेड फ़ॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को विभिन्न मशीनों में समान रखना आवश्यक है, तो यह न मानें कि केवल स्लाइड क्लोन करने से सभी आवश्यक फ़ॉन्ट गंतव्य वातावरण में उपलब्ध हो जाएंगे। आप एम्बेडेड फ़ॉन्ट को [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) से देख सकते हैं और [Embed Fonts in Presentations](/slides/hi/cpp/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

यह भी जाँचें कि आप स्रोत फ़ाइलों में प्रयुक्त फ़ॉन्ट को एम्बेड करने की अनुमति रखते हैं या नहीं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड-संरक्षित प्रस्तुतियाँ**

एक पासवर्ड‑सुरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) के माध्यम से प्रदान करें।

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

एक एन्क्रिप्टेड स्रोत को खोलना स्वचालित रूप से गंतव्य प्रस्तुति पर वही सुरक्षा नहीं लगाता। आवश्यक होने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियाँ और मेमोरी उपयोग**

उच्च‑रिज़ोल्यूशन छवियों, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट वाले बड़े प्रस्तुतियों को काफी मेमोरी की आवश्यकता हो सकती है। [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) BLOB हैंडलिंग और अस्थायी‑फ़ाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिये देखें [Manage Presentation BLOBs](/slides/hi/cpp/manage-blob/)।

बड़ी फ़ाइलों के लिये, संभव हो तो फ़ाइल‑पाथ से लोड करना पसंद करें, प्रत्येक स्रोत प्रस्तुति को मर्ज होने के बाद तुरंत डिस्पोज़ करें, और मध्यवर्ती परिणामों को बार‑बार सहेजने से बचें जब तक वर्कफ़्लो को चेकपॉइंट की आवश्यकता न हो।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ लोड, मॉडिफ़ाय, सेव या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को एक ही मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र कार्यों को समानांतर चलाते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें और [Aspose.Slides multithreading guidance](/slides/hi/cpp/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिज़ाइन कैसे रखूँ?**

इम्पोर्ट की गई स्लाइड्स को गंतव्य मास्टर या लेआउट प्रदान किए बिना [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) का उपयोग करें। आवश्यक होने पर Aspose.Slides स्वचालित रूप से स्रोत मास्टर को क्लोन कर सकता है।

**इम्पोर्ट की गई स्लाइड्स को गंतव्य थीम कैसे लागू करूँ?**

एक गंतव्य मास्टर स्वीकार करने वाले ओवरलोड का उपयोग करें। गंतव्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने की कोशिश करेगा।

**किस स्थिति में मैं गंतव्य मास्टर के बजाय विशिष्ट गंतव्य लेआउट का उपयोग करूँ?**

जब प्रत्येक इम्पोर्ट की गई स्लाइड को एक ज्ञात लेआउट का उपयोग करना हो, तो विशिष्ट लेआउट का उपयोग करें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के लेआउट में से चुन ले, तो मास्टर का उपयोग करें।

**क्या विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हां, लेकिन स्लाइड सामग्री नई आयामों के लिए स्वचालित रूप से पुनः डिज़ाइन नहीं होती। पूर्व‑रिसाइज़ करने के लिये [SlideSize::SetSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidesize/setsize/) और [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX, और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हां। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक गंतव्य में क्लोन करें, और गंतव्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूँकि फ़ाइल फ़ॉर्मेट समान फीचर सेट नहीं देते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की पुष्टि करें। समर्थित फ़ाइल फ़ॉर्मेट के लिये देखें [Supported File Formats](/slides/hi/cpp/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित रहते हैं?**

केवल स्लाइड क्लोन करने वाले बेसिक लूप से नहीं। गंतव्य में आवश्यक सेक्शन को पुनः बनाएं और सेक्शन संरचना को संरक्षित करने के लिये [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) के सेक्शन ओवरलोड का उपयोग करें।

**क्या स्पीकर नोट्स और कमेंट्स संरक्षित रहते हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी होते हैं। यदि नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखकों, या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो है, तो मर्ज्ड परिणाम की पुष्टि करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तर की संरचनाओं के साथ स्लाइड‑स्तर की सामग्री को भी शामिल करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट, और हाइपरलिंक्स के साथ क्या होता है?**

एम्बेडेड सामग्री क्लोन की गई स्लाइड के संसाधन संबंधों के भाग के रूप में ले जा जाती है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए उनके लक्षित फ़ाइलों या URL को मर्ज के बाद भी उपलब्ध रखना आवश्यक है।

**क्या प्रत्येक स्रोत से एम्बेडेड फ़ॉन्ट मर्ज्ड प्रस्तुति में उपलब्ध होंगे?**

स्लाइड क्लोनिंग से फ़ॉन्ट डिप्लॉयमेंट की गारंटी न लें। गंतव्य में एम्बेडेड फ़ॉन्ट की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑प्रोटेक्टेड फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) के साथ उसे खोलें, फिर सामान्य रूप से स्लाइड्स को क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बहुत बड़ी प्रस्तुतियों को कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट मेमोरी का प्रमुख भाग हों, तो BLOB प्रबंधन का उपयोग करें, बड़े फ़ाइलों के लिये फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को मर्ज होने के बाद तुरंत डिस्पोज़ करें, और वर्कफ़्लो को चेकपॉइंट की आवश्यकता न हो तो मध्यवर्ती सेविंग से बचें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से समवर्ती रूप से लोड, मॉडिफ़ाय, सेव या क्लोन न करें। प्रत्येक मर्ज ऑपरेशन को अपने अलग प्रस्तुति इंस्टेंस में रखें। यदि आप स्वतंत्र कार्यों को समानांतर चलाते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें और [Aspose.Slides multithreading guidance](/slides/hi/cpp/multithreading/) का पालन करें।