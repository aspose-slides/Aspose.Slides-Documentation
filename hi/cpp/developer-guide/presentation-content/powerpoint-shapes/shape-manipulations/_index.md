---
title: C++ में प्रस्तुति आकार प्रबंधित करें
linktitle: आकार हेरफेर
type: docs
weight: 40
url: /hi/cpp/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रस्तुति आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छिपाएँ
- आकार क्रम बदलें
- इंटरऑप आकार ID प्राप्त करें
- आकार वैकल्पिक पाठ
- आकार समायोजन बिंदु
- पूर्वनिर्धारित आकार समायोजन
- आकार ज्यामिति
- आकार लेआउट प्रारूप
- आकार SVG रूप में
- आकार को SVG में
- आकार संरेखित करें
- आकार उलटें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुति आकारों को पहचानना, समायोजित करना, क्लोन करना, हटाना, छिपाना, क्रम बदलना, निर्यात करना, संरेखित करना और उलटना सीखें।"
---
## **समीक्षा**

Aspose.Slides for C++ स्लाइड पर आकारों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकारों को खोजते और बदलते हैं और उनका स्टैकिंग क्रम निर्धारित करता है: सूचकांक `0` सबसे पीछे का आकार है, जबकि अंतिम सूचकांक सबसे आगे का आकार है।

यह लेख उसी मॉडल का अनुसरण करता है। यह पहले यह बताता है कि एक आकार को कैसे भरोसेमंद रूप से पहचानें और पूर्वनिर्धारित आकार समायोजन बिंदुओं को कैसे संशोधित करें, फिर क्लोन, हटाना, छिपाना और क्रम बदलना दिखाता है। अंतिम भाग लेआउट‑स्तर फॉर्मेटिंग, SVG निर्यात, संरेखण और फ्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही कार्यवाही उपयोग कर सकते हैं जो आपके कार्य‑प्रवाह की आवश्यकता है।

## **आकारों की पहचान और खोज**

कलेक्शन सूचकांक ज्ञात फ़ाइल के प्रसंस्करण के दौरान सुविधाजनक होते हैं, लेकिन वे स्थिर पहचानकर्ता नहीं होते। आकार जोड़ने, हटाने या क्रम बदलने से उनका सूचकांक बदल सकता है। प्रस्तुति के निर्माण और रख‑रखाव के आधार पर एक पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_name/) डेवलपर‑नियंत्रित टेम्पलेट्स के लिए उपयोगी है और PowerPoint की Selection Pane में देखना आसान है। नाम संपादित किए जा सकते हैं और अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड इन पर निर्भर करता है तो एक नामकरण अनुबंध स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_alternativetext/) उपयोगी है जब एक पहुँच‑वर्णन या लेखक‑द्वारा प्रदान किया गया टैग पहले से ही आकार की पहचान करता हो। यह उपयोगकर्ताओं को दिखाई देता है, स्थानीयकृत या पहुँच‑के लिए पुनर्लिखित हो सकता है, और अनिवार्य रूप से अद्वितीय नहीं होता। अर्थपूर्ण पहुँच‑पाठ को मौन रूप से डेटाबेस कुंजी के रूप में पुनः उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_officeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint इंटरोप द्वारा उपयोग किए जाने वाले आकार ID से मेल खाता है। PowerPoint के साथ एकीकृत करने या आकार के जीवन‑काल के दौरान अस्पष्ट नहीं रेफ़रेंस की आवश्यकता होने पर इसका उपयोग करें। क्लोन या पुनः‑निर्मित आकार एक अलग आकार होता है और अपना स्वयं का ID प्राप्त करता है।

संबंधित [UniqueId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_uniqueid/) प्रॉपर्टी का प्रस्तुति‑स्कोप है, लेकिन यह ऐड‑इन्स के लिए है और पुनः‑आबंटित किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो एप्लिकेशन डेटा में मैपिंग रखें और सत्यापित करें कि अपेक्षित आकार अभी भी मौजूद है।

वैकल्पिक पाठ शीर्षक और विवरण दोनों को पढ़ने और अपडेट करने के व्यावहारिक उदाहरण के लिए देखें [Manage Alternative Text Titles and Descriptions](/slides/hi/cpp/presentation-accessibility/)। वैकल्पिक पाठ का उपयोग दृश्य अर्थ को पाठकों को समझाने के लिए करें, और इसे कोड द्वारा आकार खोजने के लिए उपयोग किए जाने वाले आकार नामों से अलग रखें।

निम्न उदाहरण `Name` द्वारा खोज करता है और स्लाइड‑स्कोप्ड इंटरोप ID रिपोर्ट करता है। जब टेम्प्लेट में अपेक्षित आकार नहीं होता, तो कोड गलत ऑब्जेक्ट के साथ आगे बढ़ने के बजाय वह परिणाम रिपोर्ट करता है।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

जब कोई ऑपरेशन विशेष रूप से किसी आकार प्रकार के लिये है, तो प्रकार‑विशिष्ट सदस्यों का उपयोग करने से पहले इंटरफ़ेस की जाँच करें। यह उदाहरण तभी टेक्स्ट और वैकल्पिक टेक्स्ट को अपडेट करता है जब नामित ऑब्जेक्ट एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) हो।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **पूर्वनिर्धारित आकार समायोजन की पहचान और संशोधन**

पूर्वनिर्धारित ज्यामिति आकार समायोजन बिंदु प्रकट कर सकते हैं जो कोना आकार, तीर अनुपात या चाप कोण जैसे गुणों को नियंत्रित करते हैं। इन्हें पढ़‑सिर्फ [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igeometryshape/get_adjustments/) संग्रह के माध्यम से एक्सेस करें। स्वयं संग्रह आकार द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/) में एक मान होता है जिसे बदला जा सकता है।

केवल एक निश्चित संग्रह सूचकांक पर निर्भर न रहें। समायोजनों के माध्यम से पारित हों और पढ़‑सिर्फ [IAdjustValue::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/get_type/) प्रॉपर्टी को देखें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन क्या नियंत्रित करता है। पढ़‑सिर्फ [IAdjustValue::get_Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/get_name/) प्रॉपर्टी अतिरिक्त पहचान जानकारी देती है और विशेष रूप से तब उपयोगी होती है जब किसी पूर्वनिर्धारित में समान अर्थ वाले एक से अधिक समायोजन होते हैं।

समायोजन के अर्थ से मेल खाने वाले मान प्रॉपर्टी का उपयोग करें:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | गोल कोनों का आकार | [RawValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | तीर की पूंछ की मोटाई | `RawValue` |
| `ArrowheadLength` | तीर के सिर का लंबाई | `RawValue` |
| `ArrowheadWidth` | तीर के सिर की चौड़ाई | `RawValue` |
| `StartAngle` | पाई या चाप का प्रारंभिक कोण | [AngleValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | पाई या चाप का समाप्ति कोण | `AngleValue` |

`Type` और `Name` को असाइन नहीं किया जा सकता। `RawValue` पूर्वनिर्धारित की मूल ज्यामिति इकाइयों में पढ़‑/लिख‑सक्षम पूर्णांक है, जबकि `AngleValue` डिग्री में पढ़‑/लिख‑सक्षम कोण है। समायोजन की संख्या, क्रम, अर्थ और वैध सीमा पूर्वनिर्धारित [ShapeType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igeometryshape/get_shapetype/) पर निर्भर करती है। एक पूर्वनिर्धारित के लिये वैध मान दूसरे के लिये अमान्य या अलग प्रभाव वाला हो सकता है।

जब `Type` `ShapeAdjustmentType::Custom` हो, तो API एक मानक अर्थ पहचानती नहीं है। `Name`, पूर्वनिर्धारित प्रकार, और मौजूदा मान को देखें, और केवल तब समायोजन बदलें जब अपेक्षित अर्थ और सीमा ज्ञात हो। पहचाने हुए प्रकारों के लिये भी, यदि वही प्रकार कई बार प्रकट होता है तो मान चुनने से पहले जाँचें। कनेक्टर बेंड समायोजन के लिये यह स्थिति [Connector](/slides/hi/cpp/connector/) लेख में दर्शाई गई है।

निम्न पूर्ण उदाहरण तीन पूर्वनिर्धारित आकारों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह प्रत्येक समायोजन पर इटरेट करता है, उसके `Name` और `Type` को रिपोर्ट करता है, आकार‑संबंधी मानों को `RawValue` से बदलता है, कोणों को `AngleValue` से बदलता है, और परिणाम सहेजता है। बाएँ कॉलम में डिफ़ॉल्ट ज्यामिति बनी रहती है; दाएँ कॉलम में समायोजित गोल आयत, चार‑दिशा तीर और पाई दिखाया गया है।

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// डिफ़ॉल्ट और समायोजित आकार कॉलम के लिए हेडर जोड़ता है।
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

समय पर अर्थ‑प्रकार की जाँच करना कोड को उसके इरादे के बारे में स्पष्ट बनाता है और यह मानने से बचाता है कि विभिन्न पूर्वनिर्धारित आकारों में एक ही संग्रह सूचकांक का समान अर्थ है।

## **आकार संग्रह को संशोधित करें**

`Add`, `Clone`, `Remove` और `Reorder` मेथड्स संग्रह पर तुरंत कार्य करते हैं। यदि कोई ऑपरेशन आकारों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए सूचकांकों पर भरोसा जारी न रखें।

### **एक आकार को क्लोन करें**

[AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addclone/) एक स्वतंत्र प्रतिलिपि बनाता है और इसे लक्ष्य संग्रह के अंत में जोड़ता है। [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/insertclone/) भी एक प्रतिलिपि बनाता है लेकिन इसे निर्दिष्ट z‑order सूचकांक पर रखता है। जो ओवरलोड्स निर्देशांक स्वीकार करते हैं वे क्लोन को उसका आकार बदले बिना स्थानांतरित करते हैं; चौड़ाई‑और‑ऊँचाई वाले ओवरलोड्स इसे पुनः‑आकार भी दे सकते हैं।

निम्न उदाहरण एक गंतव्य स्लाइड बनाता है, लेबल वाले आयत को आगे की ओर क्लोन करता है और दूसरा क्लोन पीछे की ओर सम्मिलित करता है। किसी भी क्लोन में किए गए परिवर्तन स्रोत आकार को नहीं बदलते।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

क्लोनिंग आकार की सामग्री और फॉर्मेटिंग, जिसमें उसका नाम और वैकल्पिक पाठ शामिल है, को कॉपी करता है। जब इन मानों को अद्वितीय होना चाहिए तो क्लोन को नए तार्किक पहचानकर्ता सौंपें। जटिल आकारों द्वारा उपयोग किए गए संसाधनों को प्रस्तुति द्वारा प्रबंधित किया जाता है, लेकिन क्लोन एक नया संग्रह आइटम होता है जिसका अपना आकार पहचान होता है।

### **आकार हटाएँ**

[Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/remove/) किसी विशिष्ट आकार ऑब्जेक्ट को उसके संग्रह से हटाता है। जब आप अनुक्रमित इटरशन के दौरान कई मिलान हटाते हैं, तो अंत से प्रारंभ करें ताकि प्रत्येक शेष सूचकांक वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाले प्रत्येक आकार को हटाता है। यह वर्तमान अनुक्रमित आकार को पढ़ता है, न कि एक स्थिर संग्रह आइटम को, और आकार को अनावश्यक रूप से कास्ट नहीं करता।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

हटाने के बाद, आकार गिनती और बाद के आकारों के सूचकांक बदल जाते हैं। अप्रभावित आकारों के संदर्भ सेव्ड सूचकांकों की तुलना में अधिक भरोसेमंद रहते हैं। कनेक्टर, एनीमेशन और अन्य प्रस्तुति सुविधाओं को भी विचार करें जो हटाए गए ऑब्जेक्ट को संदर्भित कर सकते हैं; दृश्यमान आकार को हटाना केवल स्लाइड की उपस्थिति से अधिक बदल सकता है।

### **एक आकार को छिपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_hidden/) को `true` पर सेट करने से आकार संग्रह में बना रहता है लेकिन सामान्य स्लाइड‑शो में दिखाई नहीं देता। उसका सूचकांक, फॉर्मेटिंग, और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए छिपाना वैकल्पिक तत्वों के लिये उपयुक्त है जिन्हें बाद में पुनर्स्थापित किया जा सकता है।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

छिपाना हटाना या सुरक्षा नहीं है। ऑब्जेक्ट अभी भी उपयोगकर्ता या कोड द्वारा खोजा और अनहिड़ किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑Order बदलें**

ओवरलैपिंग आकार संग्रह क्रम में पेंट किए जाते हैं। [Reorder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/reorder/) एक मौजूदा आकार को लक्ष्य सूचकांक पर ले जाता है बिना उसे क्लोन किए। सूचकांक `0` पीछे है; `Count - 1` आगे है।

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

आयत पहले बनाया जाता है और प्रारम्भ में दीर्घवृत्त के पीछे रहता है। उसे अंतिम सूचकांक पर ले जाने से वह आगे आ जाता है। सभी संबंधित आकारों को जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड पर आकारों की जाँच करें**

सामान्य स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड के पास अलग‑अलग आकार संग्रह होते हैं। लेआउट संग्रह में एक आकार सामान्य स्लाइड पर समान स्थितियों वाले आकार के समान ऑब्जेक्ट नहीं होता। जब आपको लेआउट द्वारा प्रदान किए हुए फॉर्मेटिंग को समझना या बदलना हो, तो लेआउट आकारों की जाँच करें।

निम्न उदाहरण प्रत्येक लेआउट आकार की [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_fillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_lineformat/) पढ़ता है, यह मानते हुए कि हर आकार `AutoShape` नहीं है।

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

लेआउट को संपादित करने से कई स्लाइडों पर असर पड़ सकता है जो इसे उपयोग करती हैं। लेआउट आकार बदलने से पहले तय करें कि सामान्य स्लाइड ऑब्जेक्ट को विरासत में मिला है या स्थानीय ओवरराइड है, और उस लेआउट को उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकार को SVG में निर्यात करें**

[WriteAsSvg](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/writeassvg/) एक आकार की रेंडर्ड सामग्री को स्ट्रीम में लिखता है। परिणाम में वह आकार होता है, न कि पूरी स्लाइड पृष्ठभूमि या पड़ोसी आकार।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

रेंडरिंग के दौरान प्रस्तुति खुली रखें। आउटपुट आकार के फॉर्मेटिंग और फ़ॉन्ट व चित्र जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना चाहिए, तो व्यक्तिगत आकार के बजाय स्लाइड निर्यात करें। कॉलर स्ट्रीम का स्वामित्व रखता है और उसे बंद या डिस्पोज़ करना चाहिए।

## **आकार संरेखित करें**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/alignshapes/) ओवरलोड्स सभी आकार या चयनित संग्रह सूचकांकों को संरेखित कर सकते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapesalignmenttype/) किनारा, मध्य‑रेखा या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` करने पर स्लाइड किनारों का उपयोग होता है; `false` करने पर चयनित आकारों को एक‑दूसरे के सापेक्ष संरेखित किया जाता है।

निम्न उदाहरण तीन आकारों को स्लाइड के शीर्ष किनारे के साथ संरेखित करता है। संरेखण से ठीक पहले लौटाए गए आकार संदर्भों को उनके वर्तमान सूचकांकों में बदला जाता है।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

संरेखण स्थान बदलता है, न कि z‑order। सापेक्ष संरेखण को सामान्यतः कम से कम दो आकार चाहिए, जबकि क्षैतिज या लंबवत वितरण को अंतराल निर्धारित करने के लिये पर्याप्त आकार चाहिए। मेथड कॉल करने से पहले यदि आप संग्रह को संशोधित करते हैं तो सूचकांकों को पुनः‑गणना करें।

## **आकार को फ्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज व लंबवत फ्लिप सेटिंग और घूर्णन को संग्रहीत करता है। इसके `FlipH` और `FlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/cpp/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ्लिप सक्षम करता है, `False` निष्क्रिय करता है, और `NotDefined` अनिर्धारित/डिफ़ॉल्ट स्थिति को बनाए रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकार रखती है।

![The shape before flipping](shape_to_be_flipped.png)

उदाहरण सभी अन्य फ्रेम मानों को बरकरार रखता है और केवल दो फ्लिप सेटिंग को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_frame/) असाइन करने से पूरा फ्रेम बदल जाता है।

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

सहेजा गया आकार क्षैतिज व लंबवत दोनों दिशा में प्रतिबिंबित है जबकि उसकी स्थिति, आकार और घूर्णन वही रहता है।

![The shape after flipping](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह सूचकांक का उपयोग करना चाहिए?**

केवल लघु‑कालिक प्रसंस्करण के लिये जब संग्रह ऑपरेशन के दौरान नहीं बदलता। टेम्पलेट के लिये वैध `Name` या `AlternativeText` अनुबंध अपनाएँ, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिये `OfficeInteropShapeId`।

**क्या आकार को छिपाने से वह z‑order से हट जाता है?**

नहीं। छिपा आकार समान सूचकांक पर संग्रह में बना रहता है। उसे पाया, पुन:क्रमित, संपादित या पुनः‑दृश्यमान किया जा सकता है।

**क्लोन किया हुआ आकार दूसरे आकार के सामने क्यों दिखाई दिया?**

`AddClone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order का सामने वाला हिस्सा होता है। इच्छित सूचकांक चुनने के लिये `InsertClone` उपयोग करें या सभी आकार जोड़ने के बाद `Reorder` करें।

**क्या मैं पूर्वनिर्धारित आकार समायोजन की पहचान के लिये स्थिर सूचकांक उपयोग कर सकता हूँ?**

केवल तभी जब आप ठीक‑ठीक पूर्वनिर्धारित और संग्रह लेआउट की पुष्टि कर चुके हों। `IGeometryShape::get_Adjustments` के माध्यम से इटरेट कर `IAdjustValue::get_Type` की जाँच करें; जब समान अर्थ वाला प्रकार कई बार प्रकट हो तो अतिरिक्त जानकारी के लिये `IAdjustValue::get_Name` का उपयोग करें।