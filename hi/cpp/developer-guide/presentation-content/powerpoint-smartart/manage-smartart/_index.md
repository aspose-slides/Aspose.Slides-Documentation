---
title: C++ का उपयोग करके PowerPoint प्रस्तुतियों में SmartArt प्रबंधन
linktitle: SmartArt प्रबंधन
type: docs
weight: 10
url: /hi/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt पाठ
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "स्पष्ट कोड उदाहरणों का उपयोग करके PowerPoint SmartArt को बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और स्वचालन को तेज़ करता है, Aspose.Slides for C++ के साथ।"
---
## **अवलोकन**

SmartArt एक PowerPoint आरेख है जो नोड, नोड आकार और लेआउट से निर्मित होता है। Aspose.Slides for C++ के साथ, आप SmartArt बना सकते हैं, इसके नोड से टेक्स्ट पढ़ सकते हैं, उसके लेआउट को बदल सकते हैं, छिपे हुए नोड की जाँच कर सकते हैं, संगठन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और चित्र संगठन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से पाठ प्राप्त करें**

एक SmartArt नोड में एक या अधिक आकार हो सकते हैं। नोड आकारों से टेक्स्ट पढ़ने के लिए, [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/) को क्रमबद्ध करें, फिर [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) द्वारा लौटाए गए [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) को पढ़ें।

उदाहरण के लिए एक प्रेज़ेंटेशन चाहिए जिसमें कम से कम एक स्लाइड और उस स्लाइड पर पहला आकार एक SmartArt ऑब्जेक्ट हो। यह प्रत्येक उपलब्ध टेक्स्ट फ्रेम को कंसोल पर प्रिंट करता है।

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **SmartArt ऑब्जेक्ट के लेआउट प्रकार को बदलें**

SmartArt लेआउट निर्धारित करता है कि नोड कैसे व्यवस्थित और जुड़े होते हैं। नीचे दिया गया उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` मान के साथ एक SmartArt ऑब्जेक्ट बनाता है, उसे `BasicProcess` मान में बदलता है, और प्रेज़ेंटेशन को सहेजता है। [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) को पास किया गया स्थिति और आकार पॉइंट में मापा जाता है। लेआउट बदलने के लिए [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) का उपयोग करें।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) यह दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चुने गए लेआउट में उन्हें दृश्यमान आरेख तत्वों के रूप में न दिखाने पर भी छिपे नोड संरचना में मौजूद हो सकते हैं।

नीचे दिया गया उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` मान वाले SmartArt ऑब्जेक्ट में एक नोड जोड़ता है और जोड़े गए नोड की छिपी स्थिति की जाँच करता है। यदि नोड छिपा है तो यह एक संदेश प्रिंट करता है और आरेख को सहेजता है।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **संगठन चार्ट लेआउट प्राप्त करें या सेट करें**

जिन SmartArt आरेखों में संगठन चार्ट लेआउट उपयोग किया जाता है, उनके लिए [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) और [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) यह निर्धारित करते हैं कि बच्चा नोड पैरेंट नोड के नीचे कैसे व्यवस्थित हो। उदाहरण के लिए, आप बच्चा नोड बाएँ, दाएँ या दोनों तरफ लटकने के लिए सेट कर सकते हैं, चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) के आधार पर।

नीचे दिया गया उदाहरण एक संगठन चार्ट बनाता है और पहले नोड के लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है। शून्य-आधारित सूचकांक `0` पहली शीर्ष-स्तर नोड को चुनता है; उसके बच्चा नोड चयनित व्यवस्था का उपयोग करेंगे। संशोधित प्रेज़ेंटेशन को फिर सहेजा जाता है।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **चित्र संगठन चार्ट बनाएं**

चित्र संगठन चार्ट एक SmartArt लेआउट है जो उन पदानुक्रम आरेखों के लिए बनाया गया है जिसमें छवि प्लेसहोल्डर शामिल होते हैं। स्लाइड पर SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें। यह उदाहरण छवि प्लेसहोल्डर वाले आरेख को सहेजता है; यह प्लेसहोल्डर को छवियों से नहीं भरता।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **पुराने आरेखों को आकार समूहों में बदलें**

जब मौजूदा प्रेज़ेंटेशन को आधुनिक बनाते हैं, तो आपको PowerPoint 97–2003 में बनाए गए संगठन चार्ट को अपडेट करना पड़ सकता है। Aspose.Slides इन पुराने आरेखों को [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) ऑब्जेक्ट्स के रूप में प्रस्तुत करता है। एक आरेख को आकार समूह में बदलने के लिए [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) का उपयोग करें ताकि आप व्यक्तिगत दृश्य तत्वों को संपादित कर सकें। विवरण के लिए देखें [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/)।

परिवर्तन आकार संग्रह में एक नया समूह जोड़ता है बिना मूल आरेख को हटाए। सफल परिवर्तन के बाद, डुप्लिकेट सामग्री से बचने के लिए मूल को [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) से हटाएँ। परिवर्तन करने से पहले पुराने आरेखों को एक वेक्टर में एकत्र करें ताकि आकार जोड़ने और हटाने से क्रमबद्धता बाधित न हो।

नीचे दिया गया उदाहरण एक प्रेज़ेंटेशन खोलता है, प्रत्येक स्लाइड खोजता है, आरेखों को आकार समूह में बदलता है, और अपडेट किया गया प्रेज़ेंटेशन PPTX के रूप में सहेजता है।

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

सहेजा गया प्रेज़ेंटेशन परिवर्तित पुराने आरेखों की जगह संपादन योग्य आकार समूह रखता है, और कोई मूल आरेख नहीं बचता। प्रत्येक समूह के भीतर व्यक्तिगत तत्वों, जैसे टेक्स्ट, भराव या स्थिति, को संपादित करने के लिए PPTX को PowerPoint में खोलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। जब चयनित SmartArt लेआउट रिवर्सल का समर्थन करता है, तो [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) मेथड आरेख की दिशा को बाएँ-से-दाएँ से दाएँ-से-बाएँ या वापस बदलता है।

**मैं फ़ॉर्मेटिंग को बनाए रखते हुए SmartArt को उसी स्लाइड पर या किसी अन्य प्रेज़ेंटेशन में कैसे कॉपी कर सकता हूँ?**

आप [SmartArt shape को क्लोन कर सकते हैं](/slides/hi/cpp/shape-manipulations/) [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) के साथ या उस स्लाइड को क्लोन कर सकते हैं जिसमें SmartArt है [clone the whole slide](/slides/hi/cpp/clone-slides/)। दोनों तरीके आकार, स्थिति और फ़ॉर्मेटिंग को बनाए रखते हैं।

**मैं पूर्वावलोकन या वेब निर्यात के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड को रेंडर करें](/slides/hi/cpp/convert-powerpoint-to-png/) या पूरी प्रेज़ेंटेशन को PNG या JPEG में। SmartArt स्लाइड का हिस्सा होने के कारण रेंडर किया जाता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट्स हों तो मैं एक विशिष्ट SmartArt ऑब्जेक्ट कैसे ढूंढूँ?**

SmartArt shape पर एक विशिष्ट [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) या [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) मान सेट करें, फिर वह मान [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) में खोजें, और जाँचें कि मिलते‑जुलते shape एक [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/) है।