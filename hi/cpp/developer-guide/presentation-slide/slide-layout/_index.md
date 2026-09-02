---
title: C++ में स्लाइड लेआउट लागू करें या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/cpp/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रस्तुति डिजाइन
- स्लाइड डिजाइन
- अनुपयोगी लेआउट
- फुटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- ब्लैंक लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और ऊर्ध्वाधर टेक्स्ट
- ऊर्ध्वाधर शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड लेआउट को लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अनउपयोगित लेआउट हटाएँ, और फुटर दृश्यता को नियंत्रित करें।"
---
## **अवलोकन**

एक स्लाइड लेआउट प्लेसहोल्डर जैसे शीर्षक, टेक्स्ट, चित्र, चार्ट और टेबल की स्थितियों और फ़ॉर्मेटिंग को परिभाषित करता है। लेआउट को लागू करने से स्लाइड्स में एक समान संरचना मिलती है जबकि प्रत्येक स्लाइड अपना स्वयं का कंटेंट रख सकता है।

सबसे सामान्य लेआउट शामिल हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर शामिल हैं।
- **Title and Content**: एक शीर्षक प्लेसहोल्डर और एक सामान्य प्रयोजन सामग्री प्लेसहोल्डर शामिल है।
- **Blank**: कोई सामग्री प्लेसहोल्डर नहीं होते और यह तब उपयोगी है जब प्रत्येक आकार को मैन्युअल रूप से स्थित किया जाएगा।

## **लेआउट विरासत को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [master slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) प्रस्तुतिकरण की थीम, साझा फ़ॉर्मेटिंग, पृष्ठभूमि, और सामान्य वस्तुओं को परिभाषित करता है।
1. एक [layout slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/) एक मास्टर से जुड़ा होता है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करता है।
1. एक [normal slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) एक लेआउट का उपयोग करता है और उस स्लाइड के लिए दर्ज किए गए कंटेंट को संग्रहीत करता है।

एक normal slide अपने लेआउट से थीम और फ़ॉर्मेटिंग को विरासत में प्राप्त करता है, और लेआउट अपने मास्टर से विरासत में लेता है। normal slide पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिले मान को ओवरराइड करता है। जब एक normal slide बनाई जाती है, तो उसके प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर में दर्ज किया गया कंटेंट normal slide से सम्बंधित होता है।

एक लेआउट बनाते समय आवश्यक प्लेसहोल्डर जोड़ें। बाद में लेआउट में दूसरा प्लेसहोल्डर जोड़ने से मौजूदा normal स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर आकार नहीं जुड़ता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में मिले फ़ॉर्मेटिंग या मौजूदा प्लेसहोल्डर ज्योमेट्री को बदलने से उस पर निर्भर सभी स्लाइड्स अपडेट हो सकती हैं। उपयोग में पहले से मौजूद लेआउट को संपादित करने से पहले, उसकी निर्भर स्लाइड्स की जाँच करें और परिणामस्वरूप प्रस्तुतिकरण की समीक्षा करें।
- वह लेआउट जिसे अभी भी कोई स्लाइड उपयोग कर रही है, उसे हटाया नहीं जा सकता। पहले उसकी निर्भर स्लाइड्स को किसी अन्य लेआउट पर पुनः असाइन करें, या केवल अनउपयोगित लेआउट्स को हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें [Slide Master](/slides/hi/cpp/slide-master/)।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का अनुसरण करती है, तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता द्वारा संपादित किए जा सकते हैं और स्थानीयकरण योग्य होते हैं, इसलिए नाम-आधारित चयन कम विश्वसनीय होता है जब तक आप स्रोत टेम्पलेट को नियंत्रित नहीं करते।

निम्न उदाहरण पहले मास्टर पर **Title and Content** खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो यह जानबूझकर **Blank** पर फ़ॉल बैक करता है। दूसरा null चेक आवश्यक है क्योंकि एक प्रस्तुतीकरण में केवल कस्टम लेआउट हो सकते हैं। चयनित लेआउट को फिर [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/set_layoutslide/) मेथड के माध्यम से पहले normal स्लाइड पर लागू किया जाता है।

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

स्लाइड का लेआउट बदलने से सीधे स्लाइड में जोड़े गए सामान्य आकार हटते नहीं हैं। हालांकि, प्लेसहोल्डर की स्थिति, विरासत में मिला फ़ॉर्मेटिंग, और मौजूदा प्लेसहोल्डर व नए लेआउट के बीच संबंध बदल सकते हैं, इसलिए बहुत अलग लेआउट्स के बीच स्विच करते समय आउटपुट की जाँच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग-अलग ऑपरेशन हैं। पिछले उदाहरण ने मौजूदा लेआउट का चयन किया; उसने कोई नया लेआउट नहीं बनाया। लेआउट बनाने के लिए लक्ष्य मास्टर के लेआउट संग्रह पर [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterlayoutslidecollection/add/) मेथड को कॉल करें।

निम्न उदाहरण हमेशा `Report Title and Content` नामक एक नया **Title and Content** लेआउट जोड़ता है, फिर उसके आधार पर एक normal स्लाइड जोड़ता है। लेआउट नाम संग्रह में अद्वितीय होने चाहिए।

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

टेम्पलेट को वास्तव में एक और पुन: प्रयोज्य संरचना की आवश्यकता होने पर ही लेआउट जोड़ें। यदि उपयुक्त लेआउट पहले से मौजूद है, तो डुप्लिकेट बनाने के बजाय उसे चुनें और पुन: उपयोग करें।

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) मेथड एक [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/) प्रदान करता है जो लेआउट में प्लेसहोल्डर आकार जोड़ने के लिए उपयोग होता है।

| PowerPoint प्लेसहोल्डर              | `ILayoutPlaceholderManager` मेथड |
| ----------------------------------- | -------------------------------- |
| ![सामग्री](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![सामग्री (ऊर्ध्वाधर)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![पाठ](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![पाठ (ऊर्ध्वाधर)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![चित्र](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![चार्ट](chart.png)                 | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![टेबल](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![मीडिया](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![ऑनलाइन इमेज](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

निम्न उदाहरण **Blank** लेआउट के मौजूद होने की जाँच करता है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर उस संशोधित लेआउट का उपयोग करने वाली एक normal स्लाइड बनाता है। क्रम जानबूझकर है: प्लेसहोल्डर पहले जोड़े जाते हैं, फिर normal स्लाइड बनाई जाती है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार उत्पन्न कर सके।

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
विरासत में मिले फ़ॉर्मेटिंग या मौजूदा लेआउट प्लेसहोल्डर की ज्योमेट्री को बदलने से निर्भर स्लाइड्स प्रभावित हो सकती हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा normal स्लाइड्स में बॅकफ़िल नहीं होता। लेआउट परिवर्तन को प्रस्तुति की एक कॉपी पर परीक्षण करें और प्रत्येक निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड हटाएँ**

लेआउट को हटाने के लिए जो कोई normal स्लाइड संदर्भित नहीं करती, [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) मेथड का उपयोग करें। यह मेथड उन लेआउट्स को ऐसे ही छोड़ देता है जो अभी भी उपयोग में हैं।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

एक विशिष्ट लेआउट हटाने के लिए, पहले उसकी [get_HasDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) मेथड या [GetDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/getdependingslides/) मेथड का उपयोग करें। किसी भी निर्भर स्लाइड को पुनः असाइन करें और फिर [ILayoutSlide::Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/remove/) को कॉल करें। उपयोग में रहे लेआउट को हटाने की कोशिश करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxeditexception/) उत्पन्न होती है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट का अपना फुटर, स्लाइड-नंबर, और डेट-टाइम प्लेसहोल्डर होता है। उन प्लेसहोल्डर को एक लेआउट के लिए नियंत्रित करने हेतु [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) मेथड का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के तौर पर कंटेंट लेआउट्स में फुटर दिखाना हो लेकिन शीर्षक लेआउट्स में न दिखे।

निम्न उदाहरण सुरक्षित रूप से एक लेआउट चुनता है और उसके फुटर तत्वों को दृश्यमान बनाता है:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **मास्टर और उसके चाइल्ड लेआउट्स पर फुटर दृश्यता नियंत्रित करें**

मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने हेतु [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/get_headerfootermanager/) मेथड का उपयोग करें। [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslideheaderfootermanager/) की प्रसार विधियाँ मास्टर और उसकी निर्भर लेआउट स्लाइड्स एवं normal स्लाइड्स पर लागू होती हैं; वे केवल एक normal स्लाइड को लक्षित नहीं करतीं।

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

एक master slide प्रस्तुति की थीम और साझा फ़ॉर्मेटिंग को परिभाषित करता है। एक layout slide एक master से जुड़ी होती है और प्लेसहोल्डर की एक पुन: उपयोग योग्य व्यवस्था को परिभाषित करती है। normal स्लाइड्स उन लेआउट्स का उपयोग करती हैं और स्लाइड-विशिष्ट कंटेंट संग्रहीत करती हैं।

**क्या मैं एक प्रस्तुति से दूसरी प्रस्तुति में लेआउट स्लाइड कॉपी कर सकता हूँ?**

हां। गंतव्य संग्रह में कॉपी जोड़ने के लिए [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igloballayoutslidecollection/addclone/) मेथड का उपयोग करें। प्रस्तुति के बीच कॉपी करते समय फ़ॉन्ट, थीम, चित्र और स्रोत लेआउट द्वारा उपयोग किए गए अन्य संसाधनों की भी जाँच करें।

**जब मैं एक लेआउट को संशोधित करता हूं जो पहले से उपयोग में है तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में प्राप्त करती हैं जब तक कि वे स्थानीय रूप से प्रभावित फ़ॉर्मेटिंग या वस्तुओं को ओवरराइड नहीं करतीं। इसलिए कई स्लाइड्स पर प्लेसहोल्डर ज्योमेट्री और विरासत में मिली शैली एक साथ बदल सकती है। बदलाव करने से पहले प्रभावित स्लाइड्स की पहचान करने हेतु [GetDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/getdependingslides/) का उपयोग करें।

**यदि मैं एक लेआउट हटाता हूं जो अभी भी उपयोग में है तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxeditexception/) उत्पन्न करती है। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अनरेफ़रेंस्ड लेआउट्स को हटाने के लिए [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) का उपयोग करें।