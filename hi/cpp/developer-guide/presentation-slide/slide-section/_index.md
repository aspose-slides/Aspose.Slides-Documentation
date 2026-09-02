---
title: C++ के साथ प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 100
url: /hi/cpp/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- सेक्शन स्लाइड्स प्राप्त करें
- सेक्शन स्लाइड्स प्रोसेस करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ स्लाइड सेक्शन प्रबंधित करें: PPTX प्रस्तुतियों में सेक्शन स्लाइड्स बनाएं, पुनःनामकरण करें, पुनःक्रमित करें, प्राप्त करें और प्रोसेस करें।"
---
## **परिचय**

सेक्शन लगातार स्लाइड्स को नामित समूहों में व्यवस्थित करते हैं बिना स्लाइड सामग्री को बदले। Aspose.Slides for C++ के साथ, आप सेक्शन को बनाना, पुनः क्रमित करना, पुनः नामकरण करना, निरीक्षण करना और हटाना [Presentation::get_Sections](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_sections/) मेथड के माध्यम से कर सकते हैं।

सेक्शन विशेष रूप से उपयोगी होते हैं जब:

- एक बड़ी प्रस्तुति को तार्किक विषयों या अध्यायों में विभाजित करने की आवश्यकता हो;
- विभिन्न समूहों की स्लाइड्स विभिन्न सहयोगियों को सौंपे गये हों;
- स्लाइड्स को समूहों के रूप में संसाधित, स्थानांतरित या मिलाया जाना आवश्यक हो।

समूहित स्लाइड्स के उद्देश्य को दर्शाने वाले संक्षिप्त सेक्शन नाम चुनें। क्योंकि सेक्शन प्रस्तुति की संरचना का हिस्सा हैं, स्लाइड स्थितियों से निकालने के बजाय सदस्यता निर्धारित करने के लिए सेक्शन API का उपयोग करें।

## **सेक्शन बनाना और प्रबंधित करना**

सेक्शन बनाने के लिए उसका नाम और प्रारम्भिक स्लाइड निर्दिष्ट करके [ISectionCollection::AddSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectioncollection/addsection/) का उपयोग करें। Aspose.Slides वर्तमान प्रस्तुति की सेक्शन संरचना से निर्धारित करता है कि कौन सी स्लाइड्स सेक्शन में आती हैं।

यह वही [ISectionCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectioncollection/) आपको यह भी करने देता है:

- [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) का उपयोग करके एक सेक्शन को उसकी स्लाइड्स के साथ स्थानांतरित करें;
- केवल सेक्शन परिभाषा हटाएँ, जिससे उसकी स्लाइड्स बनी रहती हैं, इसके लिये [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectioncollection/removesection/) का उपयोग करें;
- एक सेक्शन और उसकी स्लाइड्स हटाएँ, इसके लिये [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectioncollection/removesectionwithslides/) का उपयोग करें;
- अंत में एक खाली सेक्शन जोड़ें, इसके लिये [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectioncollection/appendemptysection/) का उपयोग करें।

निम्न उदाहरण दो सेक्शन बनाता है, उनमें से एक को स्थानांतरित करता है, उसे उसकी स्लाइड्स के साथ हटाता है, और एक खाली सेक्शन जोड़ता है:
```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

इन संचालन के बाद, प्रस्तुति में `Introduction` सेक्शन उसकी स्लाइड्स के साथ और एक खाली `Appendix` सेक्शन मौजूद रहता है। `Results` सेक्शन और उसकी स्लाइड्स हटा दिए गए हैं।

## **सेक्शनों का पुनः नामकरण**

सेक्शन का पुनः नामकरण करने के लिए, [ISection::set_Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/set_name/) को कॉल करें। सेक्शन की स्लाइड्स और स्थिति अपरिवर्तित रहती है।

निम्न उदाहरण एक सेक्शन बनाता है और उसका नाम बदलता है:
```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **सेक्शनों से स्लाइड्स प्राप्त करना**

[Presentation::get_Sections](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_sections/) मेथड एक [ISectionCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectioncollection/) लौटाता है जिसे आप सूचीबद्ध कर सकते हैं। प्रत्येक [ISection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/) के लिए, वर्तमान में उसमें सम्मिलित स्लाइड्स प्राप्त करने हेतु [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/getslideslistofsection/) को कॉल करें। यह मेथड एक [ISectionSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectionslidecollection/) लौटाता है, जो गिनती, अनुक्रमित पहुँच और सूचीकरण प्रदान करता है।

निम्न उदाहरण दो भरे हुए सेक्शन और एक खाली सेक्शन बनाता है, फिर प्रत्येक सेक्शन का [नाम](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/get_name/), [पहचानकर्ता](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/get_sectionid/), [प्रारम्भिक स्लाइड](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/get_startedfromslide/), स्लाइड गिनती और स्लाइड क्रमांक प्रिंट करता है। यह पहला स्लाइड पढ़ने के लिए अनुक्रमित पहुँच का उपयोग करता है और प्रत्येक स्लाइड को संसाधित करने के लिये रेंज‑आधारित `for` लूप का प्रयोग करता है। खाली सेक्शन के लिये, लौटाई गई संग्रह की गिनती शून्य होती है, अनुक्रमित पहुँच उपयोग नहीं की जाती और सूचीकरण कोई आवृति नहीं करता।
```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

सेक्शन सदस्यता प्रस्तुति की सेक्शन संरचना द्वारा निर्धारित होती है। सेक्शन की सीमा को मैन्युअल रूप से [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/get_startedfromslide/) आदि से गणना न करें।

संरचनात्मक संपादन सेक्शन के लिए लौटाई गई स्लाइड्स और उनके क्रमांक दोनों को बदल सकते हैं। इसमें स्लाइड्स का पुनः क्रमण, एक स्लाइड को सेक्शन में क्लोन करना, स्लाइड्स के साथ सेक्शन को स्थानांतरित करना, स्लाइड्स हटाना, और सेक्शन हटाना शामिल है। अगला उदाहरण प्रत्येक ऐसे परिवर्तन के बाद [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/getslideslistofsection/) को कॉल करता है, बजाय सेक्शन की पूर्व सीमाओं के बारे में धारणाएँ बनाए रखने के।
```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

जब भी स्लाइड्स या सेक्शन को पुनः क्रमित, क्लोन, स्थानांतरित या हटाया जाता है, तब फिर से [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/getslideslistofsection/) को कॉल करें। यह बाद की प्रोसेसिंग को वर्तमान प्रस्तुति संरचना के साथ संगत रखता है।

PPT (PowerPoint 97–2003) फ़ॉर्मेट सेक्शन मेटाडेटा को संरक्षित नहीं करता। इस वर्कफ़्लो का प्रयोग ऐसे फ़ॉर्मेट के साथ करें जो सेक्शन का समर्थन करता हो, जैसे PPTX; PPT में रूपांतरण करने पर बाद में सूचीकरण के लिये आवश्यक सेक्शन संरचना हट जाती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजने पर सेक्शन संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटाडेटा का समर्थन नहीं करता, इसलिए .ppt में सहेजने पर सेक्शन समूह खो जाता है।

**क्या पूरे सेक्शन को "छिपाया" जा सकता है?**

नहीं। सेक्शन का कोई दृश्यता स्थिति नहीं होती। इसके सामग्री को छिपाने हेतु, सेक्शन की प्रत्येक स्लाइड के लिए [ISlide::set_Hidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/set_hidden/) को कॉल करें।

**मैं किसी स्लाइड को शामिल करने वाले सेक्शन को कैसे खोजूँ?**

पहले [Presentation::get_Sections](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_sections/) को सूचीबद्ध करें, प्रत्येक सेक्शन के लिये [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/getslideslistofsection/) को कॉल करें, और लौटाई गई स्लाइड्स की लक्ष्य स्लाइड से तुलना करें। गैर‑खाली सेक्शन के लिये, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isection/get_startedfromslide/) उसकी पहली स्लाइड लौटाता है; खाली सेक्शन के लिये, यह `nullptr` लौटाता है।