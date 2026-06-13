---
title: C++ का उपयोग करके PowerPoint प्रस्तुतियों में SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt टेक्स्ट
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "स्पष्ट कोड उदाहरणों का उपयोग करके C++ के लिए Aspose.Slides के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और स्वचालन को तेज़ करता है।"
---
## **अवलोकन**

SmartArt PowerPoint का एक आरेख है जिसे नोड, नोड शैप्स और लेआउट से बनाया जाता है। Aspose.Slides for C++ के साथ, आप SmartArt बना सकते हैं, इसके नोड्स से टेक्स्ट पढ़ सकते हैं, लेआउट बदल सकते हैं, छिपे नोड्स की जाँच कर सकते हैं, ऑर्गनाइज़ेशन चार्ट लेआउट कॉन्फ़िगर कर सकते हैं, और पिक्चर ऑर्गनाइज़ेशन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक शैप्स हो सकते हैं। दृश्यमान टेक्स्ट पढ़ने के लिए, [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartart/get_allnodes/) पर इटरेट करें, फिर [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartartshape/get_textframe/) द्वारा लौटाए गए [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) को पढ़ें।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **SmartArt ऑब्जेक्ट के लेआउट प्रकार को बदलें**

SmartArt लेआउट निर्धारित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। निम्न उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` मान है, उसे `BasicProcess` मान में बदलता है, और प्रस्तुति सहेजता है।

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) इंगित करता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। छिपे नोड्स संरचना में मौजूद रह सकते हैं भले ही चयनित लेआउट उन्हें दृश्यमान आरेख तत्वों के रूप में न दिखाए।

निम्न उदाहरण एक नोड को SmartArt ऑब्जेक्ट में जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` मान का उपयोग करता है और नोड की छिपी स्थिति की जाँच करता है।

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ऑर्गनाइज़ेशन चार्ट लेआउट प्राप्त करें या सेट करें**

ऑर्गनाइज़ेशन चार्ट लेआउट का उपयोग करने वाले SmartArt आरेखों के लिए, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) और [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) परिभाषित करते हैं कि चाइल्ड नोड्स को पैरेंट नोड के तहत कैसे व्यवस्थित किया जाए। उदाहरण के लिए, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/organizationchartlayouttype/) के आधार पर चाइल्ड नोड्स को बाएँ, दाएँ या दोनों ओर लटकाने के लिए सेट कर सकते हैं।

निम्न उदाहरण एक ऑर्गनाइज़ेशन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है।

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **पिक्चर ऑर्गनाइज़ेशन चार्ट बनाएं**

पिक्चर ऑर्गनाइज़ेशन चार्ट एक SmartArt लेआउट है जो छवि प्लेसहोल्डर वाले पदानुक्रम आरेखों के लिए डिज़ाइन किया गया है। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें।

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हां। [SmartArt::set_IsReversed](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartart/set_isreversed/) मेथड चयनित SmartArt लेआउट रिवर्सल को समर्थन देता हो तो आरेख की दिशाओं को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ या वापस बदल देता है।

**मैं SmartArt को उसी स्लाइड या किसी अन्य प्रस्तुति में फॉर्मेटिंग बरकरार रखते हुए कैसे कॉपी कर सकता हूँ?**

आप SmartArt शैप को [ShapeCollection::AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapecollection/addclone/) द्वारा [clone the SmartArt shape](/slides/hi/cpp/shape-manipulations/) कर सकते हैं या उस स्लाइड को पूरी तरह से [clone the whole slide](/slides/hi/cpp/clone-slides/) कर सकते हैं जिसमें SmartArt मौजूद है। दोनों विधियां आकार, स्थिति और फ़ॉर्मेटिंग को बरकरार रखती हैं।

**प्रिव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[Render the slide](/slides/hi/cpp/convert-powerpoint-to-png/) या पूरी प्रस्तुति को PNG या JPEG में बदलें। SmartArt स्लाइड का हिस्सा होने के कारण रेंडर हो जाता है।

**यदि कई SmartArt ऑब्जेक्ट हों तो स्लाइड पर विशिष्ट SmartArt ऑब्जेक्ट को कैसे खोजूँ?**

SmartArt शैप पर विशिष्ट [Shape::set_AlternativeText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/set_alternativetext/) या [Shape::set_Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/set_name/) मान सेट करें, फिर [BaseSlide::get_Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseslide/get_shapes/) में उस मान की खोज करें, और जांचें कि मिलते‑जुलते शैप [ISmartArt](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/ismartart/) हैं या नहीं।