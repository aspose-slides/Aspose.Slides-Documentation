---
title: C++ में प्रस्तुतियों में ड्रॉइंग गाइड्स प्रबंधित करें
linktitle: ड्रॉइंग गाइड्स
type: docs
weight: 85
url: /hi/cpp/drawing-guides/
keywords:
- ड्रॉइंग गाइड
- क्षैतिज गाइड
- ऊर्ध्वाधर गाइड
- संरेखण गाइड
- स्लाइड दृश्य
- मास्टर स्लाइड
- लेआउट स्लाइड
- नोट्स मास्टर
- हैंडआउट मास्टर
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में क्षैतिज और ऊर्ध्वाधर ड्रॉइंग गाइड्स जोड़ें, पहुँचें और साफ़ करें।"
---
## **अवलोकन**

ड्रॉइंग गाइड्स समायोज्य क्षैतिज और लंबवत रेखाएँ हैं जो उपयोगकर्ताओं को PowerPoint में प्रस्तुति संपादित करते समय आकारों को लगातार संरेखित करने में मदद करती हैं। ये विशेष रूप से उपयोगी हैं जब कोई अनुप्रयोग ऐसी प्रस्तुति उत्पन्न करता है जिसे बाद में मैन्युअल रूप से परिष्कृत किया जाएगा: अनुप्रयोग वही संरेखण सहायता सहेज सकता है जिसे लेखकों को सामग्री जोड़ते या स्थानांतरित करते समय पालन करना चाहिए।

ड्रॉइंग गाइड्स संपादन सहायता हैं, स्लाइड सामग्री नहीं। ये स्लाइड शो या रेंडर किए गए आउटपुट में दिखाई नहीं देते। Aspose.Slides for C++ इन्हें [IDrawingGuidesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguidescollection/) इंटरफ़ेस के माध्यम से उजागर करता है। एक गाइड को [IDrawingGuide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguide/) द्वारा प्रतिनिधित्व किया जाता है और इसमें अभिविन्यास, स्थिति और रंग होते हैं।

स्थिति संबंधित स्लाइड या मास्टर के शीर्ष-बाएँ कोने से पॉइंट्स में मापी जाती है। एक लंबवत गाइड एक क्षैतिज निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की चौड़ाई के बीच। एक क्षैतिज गाइड एक लंबवत निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की ऊँचाई के बीच।

## **स्लाइड व्यू में गाइड्स जोड़ें**

सामान्य स्लाइड्स संपादित करते समय प्रदर्शित गाइड्स को प्रबंधित करने के लिए [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) का उपयोग करें। एक [Orientation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/orientation/) मान और पॉइंट्स में स्थिति के साथ [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguidescollection/add/) को कॉल करें।

निम्न उदाहरण स्लाइड केंद्र के दाएँ ओर एक लंबवत गाइड और उसके नीचे एक क्षैतिज गाइड जोड़ता है:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ड्रॉइंग गाइड्स तक पहुँच**

[IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguidescollection/get_count/) मेथड और [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguidescollection/idx_get/) मेथड मौजूदा गाइड्स तक पहुँच प्रदान करते हैं। [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguide/get_position/), और [IDrawingGuide::get_Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguide/get_color/) मेथड एक गाइड की वर्तमान गुणों को लौटाते हैं। उनके संबंधित सेट्टर मेथड उन गुणों को बदल सकते हैं।

निम्न उदाहरण ऊपर निर्मित प्रस्तुति से स्लाइड-व्यू गाइड्स को पढ़ता है:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **मास्टर और लेआउट स्लाइड्स में गाइड्स जोड़ें**

एक स्लाइड मास्टर और उसकी प्रत्येक लेआउट स्लाइड के अपने ड्रॉइंग‑गाइड संग्रह हो सकते हैं। मास्टर स्लाइड के लिए [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/get_drawingguides/) और लेआउट स्लाइड के लिए [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_drawingguides/) का उपयोग करें।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लंबवत गाइड और पहले लेआउट स्लाइड में एक क्षैतिज गाइड जोड़ता है:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **नोट्स और हैंडआउट मास्टर्स में गाइड्स जोड़ें**

नोट्स मास्टर्स और हैंडआउट मास्टर्स भी ड्रॉइंग गाइड्स का समर्थन करते हैं। उनके संग्रहों तक पहुँचने के लिए [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslide/get_drawingguides/) और [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) का उपयोग करें। यदि प्रस्तुति में इन मास्टर्स में से कोई नहीं है, तो [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) या [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) डिफ़ॉल्ट मास्टर बनाता है और उसे लौटाता है।

निम्न उदाहरण नोट्स मास्टर में एक क्षैतिज गाइड और हैंडआउट मास्टर में एक लंबवत गाइड जोड़ता है:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ड्रॉइंग गाइड्स साफ़ करें**

किसी विशेष संग्रह से प्रत्येक गाइड को हटाने के लिए [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idrawingguidescollection/clear/) को कॉल करें। एक संग्रह को साफ़ करने से दूसरे स्कोप में संग्रहीत गाइड्स प्रभावित नहीं होते।

निम्न उदाहरण स्लाइड‑व्यू गाइड्स और स्लाइड मास्टर्स, लेआउट स्लाइड्स, नोट्स मास्टर, और हैंडआउट मास्टर पर सभी गाइड्स को बिना लापता मास्टर्स बनाए साफ़ करता है:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ड्रॉइंग गाइड्स स्लाइड शो या निर्यातित छवियों में दिखाई देते हैं?**

नहीं। ड्रॉइंग गाइड्स संपादन के लिए संरेखण सहायता हैं और प्रस्तुति सामग्री के रूप में रेंडर नहीं होते।

**क्या ड्रॉइंग गाइड को सीधे व्यक्तिगत सामान्य स्लाइड में जोड़ा जा सकता है?**

सामान्य‑स्लाइड संपादन गाइड्स प्रस्तुति की स्लाइड‑व्यू प्रॉपर्टीज़ में संग्रहीत होते हैं। स्लाइड मास्टर्स, लेआउट स्लाइड्स, नोट्स मास्टर्स और हैंडआउट मास्टर्स के लिए अलग गाइड संग्रह उपलब्ध हैं।

**गाइड स्थितियों के लिए कौन-से इकाइयों का उपयोग किया जाता है?**

स्थिति पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। लंबवत स्थितियों को बाएँ किनारे से और क्षैतिज स्थितियों को शीर्ष किनारे से मापा जाता है।

**क्या ड्रॉइंग गाइड्स को साफ़ करने से शकलें हटती हैं या स्लाइड सामग्री बदलती है?**

नहीं। `Clear` मेथड केवल चयनित संग्रह में मौजूद गाइड्स को हटाता है। शकलें और अन्य स्लाइड सामग्री अपरिवर्तित रहती है।