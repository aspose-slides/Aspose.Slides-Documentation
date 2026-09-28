---
title: "C++ में स्लाइड लेआउट लागू करें या बदलें"
linktitle: "स्लाइड लेआउट"
type: docs
weight: 60
url: /hi/cpp/slide-layout/
keywords:
- स्लाइड लेआउट
- कंटेंट लेआउट
- प्लेसहोल्डर
- प्रस्तुति डिज़ाइन
- स्लाइड डिज़ाइन
- अप्रयुक्त लेआउट
- फ़ूटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- शीर्षक के साथ सामग्री
- चित्र के साथ शीर्षक
- शीर्षक और ऊर्ध्वाधर पाठ
- ऊर्ध्वाधर शीर्षक और पाठ
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड लेआउट लागू करें, बनाएँ और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फ़ूटर दृश्यता को नियंत्रित करें।"
---
## **अवलोकन**

स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं जैसे प्लेसहोल्डर्स की स्थिति और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स में एक समान संरचना मिलती है जबकि प्रत्येक स्लाइड अपना सामग्री रख सकती है।

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल करता है।
- **Title and Content**: शीर्षक प्लेसहोल्डर और एक सामान्य-उद्देश्य सामग्री प्लेसहोल्डर शामिल करता है।
- **Blank**: कोई सामग्री प्लेसहोल्डर नहीं होता और उपयोगी है जब हर आकार मैन्युअली स्थित किया जाएगा।

## **लेआउट विरासत को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [master slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
2. एक [layout slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/) एक master से जुड़ा होता है और प्लेसहोल्डर्स की एक विशिष्ट व्यवस्था परिभाषित करता है।
3. एक [normal slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) एक लेआउट का उपयोग करता है और उस स्लाइड के लिए दर्ज की गई सामग्री को संग्रहीत करता है।

एक normal slide अपने लेआउट से थीम और स्वरूपण विरासत में प्राप्त करता है, और लेआउट अपने master से विरासत में लेता है। normal slide पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिला मान को ओवरराइड करता है। जब एक normal slide बनाया जाता है, तो उसके प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर्स में दर्ज की गई सामग्री normal slide से संबंधित रहती है।

स्लाइड्स बनाने से पहले लेआउट में आवश्यक प्लेसहोल्डर्स जोड़ें। बाद में लेआउट में एक और प्लेसहोल्डर जोड़ने से मौजूदा normal स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर आकार नहीं जुड़ता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में मिला स्वरूपण या मौजूदा प्लेसहोल्डर ज्योमेट्री बदलने से उस पर निर्भर सभी स्लाइड्स अपडेट हो सकती हैं। उपयोग में मौजूद लेआउट को संपादित करने से पहले, उसके निर्भर स्लाइड्स की जाँच करें और परिणामी प्रस्तुति की समीक्षा करें।
- किसी स्लाइड द्वारा अभी भी उपयोग में रहे लेआउट को हटाया नहीं जा सकता। पहले उसके निर्भर स्लाइड्स को अन्य लेआउट में पुनः असाइन करें, या केवल अप्रयुक्त लेआउट्स को हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए, देखें [Slide Master](/slides/hi/cpp/slide-master/)।

एक स्लाइड पर विरासत में मिले लोगो या सजावटी master आकार को छिपाने के लिए या साझा लेआउट के माध्यम से, देखें [Control the Visibility of Master Graphics](/slides/hi/cpp/slide-master/)। यह उदाहरण समान master का उपयोग करने वाली दो स्लाइड्स की तुलना करता है।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का अनुसरण करती है, तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता-सम्पादित होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए नाम-आधारित चयन विश्वसनीय नहीं होता जब तक आप स्रोत टेम्पलेट को नियंत्रित न करें।

निम्न उदाहरण पहली master पर **Title and Content** लेआउट की खोज करता है। यदि वह लेआउट उपलब्ध नहीं है, तो यह जानबूझकर **Blank** पर वापस जाता है। दूसरा null जांच आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट हो सकते हैं। चयनित लेआउट फिर [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/set_layoutslide/) मेथड के माध्यम से पहली normal स्लाइड पर लागू किया जाता है।

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

स्लाइड का लेआउट बदलने से सीधे स्लाइड में जोड़े गए सामान्य आकार नहीं हटते। हालांकि, प्लेसहोल्डर स्थितियां, विरासत में मिला स्वरूपण, और मौजूदा प्लेसहोल्डर्स व नए लेआउट के बीच का मेल बदल सकता है, इसलिए महत्वपूर्ण रूप से अलग लेआउट्स के बीच स्विच करते समय आउटपुट की जाँच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग-अलग क्रियाएँ हैं। पिछले उदाहरण में एक मौजूदा लेआउट चुना गया; यह नया नहीं बनाता। लेआउट बनाने के लिए, लक्ष्य master के लेआउट संग्रह पर [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterlayoutslidecollection/add/) मेथड को कॉल करें।

निम्न उदाहरण हमेशा `Report Title and Content` नामक एक नया **Title and Content** लेआउट जोड़ता है, फिर उस पर आधारित एक normal स्लाइड जोड़ता है। लेआउट नाम संग्रह में अद्वितीय होने चाहिए।

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

केवल तब लेआउट जोड़ें जब टेम्पलेट को वास्तव में एक और पुन: प्रयोज्य संरचना की आवश्यकता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो डुप्लिकेट बनाने के बजाय उसे चुनें और पुन: उपयोग करें।

## **लेआउट स्लाइड में प्लेसहोल्डर्स जोड़ें**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) मेथड लेआउट में प्लेसहोल्डर आकार जोड़ने के लिए एक [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/) प्रदान करता है।

| PowerPoint प्लेसहोल्डर | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![सामग्री](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![सामग्री (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![पाठ](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![पाठ (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![चित्र](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![चार्ट](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![तालिका](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![मीडिया](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![ऑनलाइन इमेज](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

निम्न उदाहरण सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर एक normal स्लाइड बनाता है जो संशोधित लेआउट का उपयोग करती है। क्रम जानबूझकर है: प्लेसहोल्डर normal स्लाइड बनने से पहले जोड़े जाते हैं, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार उत्पन्न कर सके।

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

![लेआउट स्लाइड पर प्लेसहोल्डर्स](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
विरासत में मिले स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर्स की ज्योमेट्री बदलने से निर्भर स्लाइड्स प्रभावित हो सकते हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा normal स्लाइड्स में बैकफ़िल नहीं होता। लेआउट परिवर्तन को प्रस्तुति की एक कॉपी पर परीक्षण करें और हर निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

[Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) मेथड का प्रयोग उन लेआउट्स को हटाने के लिए करें जिनका कोई normal स्लाइड संदर्भ नहीं है। यह मेथड अभी भी उपयोग में रहने वाले लेआउट्स को अपरिवर्तित छोड़ देता है।

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

एक विशेष लेआउट हटाने के लिए, पहले उसकी [get_HasDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) मेथड या [GetDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/getdependingslides/) मेथड का उपयोग करें। [ILayoutSlide::Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/remove/) को कॉल करने से पहले किसी भी निर्भर स्लाइड को पुनः असाइन करें। उपयोग में लेआउट को हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फ़ूटर दृश्यता नियंत्रित करें**

एक लेआउट में अपना फ़ूटर, स्लाइड-नंबर, और तिथि-समय प्लेसहोल्डर होते हैं। एक लेआउट के लिए इन प्लेसहोल्डर्स को नियंत्रित करने हेतु [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) मेथड का उपयोग करें। यह उपयोगी है जब उदाहरण के तौर पर सामग्री लेआउट्स को फ़ूटर दिखाना चाहिए लेकिन शीर्षक लेआउट्स को नहीं।

निम्न उदाहरण एक लेआउट को सुरक्षित रूप से चुनता है और उसके फ़ूटर तत्वों को दृश्यमान बनाता है:

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

## **मास्टर और उसके चाइल्ड लेआउट्स पर फ़ूटर दृश्यता नियंत्रित करें**

मास्टर पदानुक्रम में समान फ़ूटर सेटिंग्स लागू करने के लिए, [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/get_headerfootermanager/) मेथड का उपयोग करें। [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslideheaderfootermanager/) के प्रसारण मेथड्स मास्टर, उसके निर्भर लेआउट स्लाइड्स और normal स्लाइड्स पर कार्य करते हैं; वे केवल एक normal स्लाइड को लक्षित नहीं करते।

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

एक master स्लाइड प्रस्तुति का थीम और साझा स्वरूपण निर्धारित करती है। एक layout स्लाइड master का हिस्सा होती है और प्लेसहोल्डर्स की एक पुन: प्रयोज्य व्यवस्था को परिभाषित करती है। normal स्लाइड्स इन लेआउट्स का उपयोग करती हैं और स्लाइड-विशिष्ट सामग्री संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरे में कॉपी कर सकता हूँ?**

हाँ। गंतव्य संग्रह में एक कॉपी जोड़ें [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igloballayoutslidecollection/addclone/) मेथड द्वारा। प्रस्तुति के बीच कॉपी करते समय, स्रोत लेआउट द्वारा उपयोग किए गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**जब मैं पहले से उपयोग में रहे लेआउट को संशोधित करता हूँ तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में लेती हैं जब तक वे स्थानीय स्तर पर प्रभावित स्वरूपण या वस्तुओं को ओवरराइड नहीं करतीं। इसलिए कई स्लाइड्स में एक साथ प्लेसहोल्डर ज्योमेट्री और विरासत में मिला स्टाइल बदल सकता है। लेआउट संपादित करने से पहले प्रभावित स्लाइड्स की पहचान के लिए [GetDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/getdependingslides/) का उपयोग करें।

**यदि मैं अभी भी उपयोग में रहे लेआउट को हटाता हूँ तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल बिना संदर्भ वाले लेआउट्स को हटाने के लिये [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) का उपयोग करें।