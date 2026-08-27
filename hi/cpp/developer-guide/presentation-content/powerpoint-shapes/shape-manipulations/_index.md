---
title: C++ में प्रस्तुति आकृतियों को प्रबंधित करें
linktitle: आकृति हेरफेर
type: docs
weight: 40
url: /hi/cpp/shape-manipulations/
keywords:
- PowerPoint आकृति
- प्रस्तुति आकृति
- स्लाइड पर आकृति
- आकृति खोजें
- आकृति क्लोन करें
- आकृति हटाएं
- आकृति छिपाएँ
- आकृति क्रम बदलें
- इंटरऑप आकृति ID प्राप्त करें
- आकृति वैकल्पिक पाठ
- आकृति समायोजन बिंदु
- प्रीसेट आकृति समायोजन
- आकृति ज्यामिति
- आकृति लेआउट स्वरुप
- आकृति SVG के रूप में
- आकृति को SVG में
- आकृति संरेखित करें
- आकृति फ़्लिप करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुति आकृतियों की पहचान, समायोजन, क्लोन, हटाना, छिपाना, क्रम बदलना, निर्यात, संरेखण और फ़्लिप कैसे करें, सीखें।"
---
## **अवलोकन**

Aspose.Slides for C++ स्लाइड पर आकृतियों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकृतियों को खोजते और संशोधित करते हैं और उनका स्टैक क्रम निर्धारित करता है: इंडेक्स `0` सबसे पीछे की आकृति है, जबकि अंतिम इंडेक्स सबसे आगे की आकृति है।

यह लेख उसी मॉडल का अनुसरण करता है। यह पहले यह बताता है कि किसी आकृति की पहचान कैसे विश्वसनीय रूप से की जाए और प्रीसेट आकृति समायोजन बिंदुओं को कैसे संशोधित किया जाए, फिर क्लोन, हटाना, छिपाना और क्रम बदलना दिखाता है। अंतिम भाग लेआउट‑स्तर फ़ॉर्मेटिंग, SVG निर्यात, संरेखन और फ्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही कार्यविधियाँ उपयोग कर सकते हैं जो आपके कार्य‑प्रवाह को आवश्यक हों।

## **आकृतियों की पहचान और खोज**

जब आप किसी ज्ञात फ़ाइल को प्रोसेस कर रहे होते हैं तो संग्रह इंडेक्स सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं होते। आकृति को जोड़ने, हटाने या क्रम बदलने से उसका इंडेक्स बदल सकता है। प्रस्तुति के निर्माण और रखरखाव के अनुसार पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_name/) डेवलपर‑नियंत्रित टेम्पलेट्स के लिए उपयोगी होता है और इसे PowerPoint के Selection Pane में आसानी से निरीक्षण किया जा सकता है। नाम संपादित किए जा सकते हैं और अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण मानक स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_alternativetext/) तब उपयोगी है जब कोई अभिगम्यता विवरण या लेखक‑द्वारा दिया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखता है, स्थानीयकृत या अभिगम्यता हेतु पुनर्लिखा जा सकता है, और अनिवार्य रूप से अद्वितीय नहीं होता। महत्वपूर्ण अभिगम्यता पाठ को चुपचाप डेटाबेस कुंजी के रूप में पुन: उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_officeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो एक स्लाइड के भीतर अद्वितीय होता है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले Shape ID के अनुरूप होता है। PowerPoint के साथ एकीकरण या आकृति के जीवन‑काल के दौरान स्पष्ट संदर्भ की आवश्यकता होने पर इसका उपयोग करें। क्लोन या पुनः निर्मित आकृति एक अलग आकृति होती है और उसका अपना ID मिलता है।

संबंधित [UniqueId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_uniqueid/) प्रॉपर्टी का प्रस्तुति‑स्कोप होता है, लेकिन यह ऐड‑इन्स के लिए अभिप्रेत है और पुनः असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो अनुप्रयोग डेटा में मैपिंग रखें और सत्यापित करें कि अपेक्षित आकृति अभी भी मौजूद है।

निम्न उदाहरण `Name` के द्वारा खोजता है और स्लाइड‑स्कोप्ड इंटरऑप ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकृति नहीं होती, तो कोड उस परिणाम को रिपोर्ट करता है बजाय गलत ऑब्जेक्ट के साथ आगे बढ़े।

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

जब कोई ऑपरेशन विशेष रूप से आकृति प्रकार के लिए हो, तो टाइप‑विशिष्ट सदस्य उपयोग करने से पहले इंटरफ़ेस की जाँच करें। यह उदाहरण टेक्स्ट और वैकल्पिक टेक्स्ट को केवल तभी अपडेट करता है जब नामित ऑब्जेक्ट एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) हो।

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

## **प्रि‑सेट आकृति समायोजन की पहचान और संशोधन**

प्रि‑सेट ज्योमेट्री आकृतियों में समायोजन बिंदु हो सकते हैं जो कोना आकार, तीर अनुपात या वक्र कोण जैसे गुणों को नियंत्रित करते हैं। इन्हें केवल‑पढ़ने योग्य [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igeometryshape/get_adjustments/) संग्रह के माध्यम से एक्सेस करें। संग्रह स्वयं आकृति द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/) में एक मान होता है जिसे बदला जा सकता है।

केवल स्थायी संग्रह इंडेक्स पर भरोसा न करें। समायोजनों के माध्यम से इटररेट करें और केवल‑पढ़ने योग्य [IAdjustValue::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/get_type/) प्रॉपर्टी देखें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन क्या नियंत्रित करता है। केवल‑पढ़ने योग्य [IAdjustValue::get_Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/get_name/) प्रॉपर्टी अतिरिक्त पहचान जानकारी प्रदान करती है और विशेष रूप से उपयोगी है जब प्रि‑सेट में समान सिमेंटिक टाइप वाले कई समायोजन हों।

समायोजन के अर्थ से मेल खाने वाले मान प्रॉपर्टी का उपयोग करें:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | गोल कोनों का आकार | [RawValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | तीर के पूंछ की मोटाई | `RawValue` |
| `ArrowheadLength` | तीर के सिरे की लंबाई | `RawValue` |
| `ArrowheadWidth` | तीर के सिरे की चौड़ाई | `RawValue` |
| `StartAngle` | पाई या वक्र का प्रारंभिक कोण | [AngleValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | पाई या वक्र का अंतिम कोण | `AngleValue` |

`Type` और `Name` को असाइन नहीं किया जा सकता। `RawValue` प्रि‑सेट की मूल ज्योमेट्री इकाइयों में एक पढ़ने‑/लिखने योग्य पूर्णांक है, जबकि `AngleValue` डिग्री में पढ़ने‑/लिखने योग्य कोण है। समायोजनों की संख्या, क्रम, अर्थ और मान्य सीमा प्रि‑सेट के [ShapeType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igeometryshape/get_shapetype/) पर निर्भर करती है। एक प्रि‑सेट में मान्य मान दूसरे प्रि‑सेट में अमान्य या अलग प्रभाव वाला हो सकता है।

जब `Type` `ShapeAdjustmentType::Custom` हो, तो API मानक सिमेंटिक अर्थ को पहचानती नहीं है। `Name`, प्रि‑सेट प्रकार और मौजूदा मान का निरीक्षण करें, और जब तक अपेक्षित अर्थ और सीमा ज्ञात न हो, समायोजन को अपरिवर्तित रखें। पहचाने गए प्रकारों के लिए भी जाँचें कि क्या वही प्रकार कई बार आता है, फिर मान चुनें। [Connector](/slides/hi/cpp/connector/) लेख इस स्थिति को कनेक्टर बेंड समायोजनों के साथ दर्शाता है।

निम्न पूर्ण उदाहरण तीन प्रि‑सेट आकृतियों की डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह प्रत्येक समायोजन के माध्यम से इटररेट करता है, उसका `Name` और `Type` रिपोर्ट करता है, आकार‑संबंधी मानों को `RawValue` से बदलता है, कोणों को `AngleValue` से बदलता है, और परिणाम को सहेजता है। बायें कॉलम में डिफ़ॉल्ट ज्योमेट्री बनी रहती है; दायें कॉलम में समायोजित गोलाकार आयत, चार‑तरफ़ा तीर, और पाई दिखाए गए हैं।

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

// डिफ़ॉल्ट और समायोजित आकृति कॉलमों के लिए हेडर जोड़ता है।
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

मान को बदलने से पहले सिमेंटिक टाइप की जाँच करने से कोड अपने इरादे को स्पष्ट बनाता है और यह मानने से बचाता है कि विभिन्न प्रि‑सेट आकृतियों में एक ही संग्रह इंडेक्स का अर्थ समान हो।

## **आकृति संग्रह का संशोधन**

जोड़ना, क्लोन करना, हटाना और क्रम बदलना तुरंत संग्रह पर कार्य करता है। यदि कोई ऑपरेशन आकृतियों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए इंडेक्स पर भरोसा जारी न रखें।

### **आकृति को क्लोन करें**

[AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addclone/) एक स्वतंत्र प्रतिलिपि बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/insertclone/) भी एक प्रतिलिपि बनाता है लेकिन उसे निर्दिष्ट z‑order इंडेक्स पर रखता है। जो ओवरलोड्स निर्देशांक स्वीकार करते हैं वे क्लोन को उसका आकार बदले बिना ले जाते हैं; चौड़ाई‑और‑ऊँचाई वाले ओवरलोड्स इसे री‑साइज़ भी कर सकते हैं।

उदाहरण एक गंतव्य स्लाइड बनाता है, लेबलयुक्त आयत को सामने क्लोन करता है, और दूसरे क्लोन को पीछे डालता है। दोनों क्लोन में किए गए परिवर्तन स्रोत आकृति को बदलते नहीं हैं।

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

क्लोनिंग आकृति की सामग्री और फ़ॉर्मेटिंग की नकल करता है, जिसमें उसका नाम और वैकल्पिक टेक्स्ट शामिल है। जब इन मानों को विशिष्ट होना आवश्यक हो तो क्लोन को नए तार्किक पहचानकर्ता सौंपें। जटिल आकृतियों द्वारा उपयोग किए गए संसाधनों को प्रस्तुति संभालती है, लेकिन क्लोन एक नया संग्रह आइटम होता है जिसके पास नई आकृति पहचान होती है।

### **आकृतियों को हटाएँ**

[Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/remove/) किसी विशिष्ट आकृति ऑब्जेक्ट को उसके संग्रह से हटा देता है। जब इंडेक्स्ड इटरेशन के दौरान कई मिलान हटाना हो, तो अंत से शुरू होकर ट्रैवर्स करें ताकि शेष प्रत्येक इंडेक्स वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाली हर आकृति को हटाता है। यह वर्तमान इंडेक्स्ड आकृति को पढ़ता है, न कि स्थायी संग्रह आइटम को, और अनावश्यक रूप से आकृति को कास्ट नहीं करता।

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

हटाने के बाद आकृति गणना और बाद की आकृतियों के इंडेक्स बदल जाते हैं। अप्रभावित आकृतियों के संदर्भ सहेजे गए इंडेक्स से अधिक विश्वसनीय रहते हैं। कनेक्टर, एनीमेशन और अन्य प्रस्तुति सुविधाओं पर भी विचार करें जो हटाए गए ऑब्जेक्ट का संदर्भ रख सकती हैं; दृश्य आकृति को हटाने से स्लाइड की उपस्थिति से अधिक प्रभावित हो सकता है।

### **आकृति को छिपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_hidden/) को `true` सेट करने से आकृति संग्रह में बनी रहती है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देती। इसका इंडेक्स, फ़ॉर्मेटिंग और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए वैकल्पिक तत्वों के लिये छुपाना उपयुक्त है जिन्हें बाद में पुनर्स्थापित किया जा सकता है।

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

छुपाना हटाना या सुरक्षा नहीं है। ऑब्जेक्ट को अभी भी उपयोगकर्ता या कोड द्वारा पाया और अनहिड़ किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑Order बदलें**

ओवरलेपिंग आकृतियों को संग्रह क्रम में पेंट किया जाता है। [Reorder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/reorder/) मौजूदा आकृति को लक्ष्य इंडेक्स पर ले जाता है बिना क्लोन किए। इंडेक्स `0` पीछे है; `Count - 1` आगे है।

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

आयत पहले बनाई जाती है और प्रारंभिक रूप से दीर्घवृत्त के पीछे बैठती है। इसे अंतिम इंडेक्स पर ले जाने से वह सामने आती है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद z‑order को फाइनलाइज़ करें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों का निरीक्षण**

सामान्य स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स के पास अलग‑अलग आकृति संग्रह होते हैं। लेआउट संग्रह में एक आकृति वही ऑब्जेक्ट नहीं होती जो सामान्य स्लाइड पर समान स्थान पर स्थित हो। जब आपको लेआउट द्वारा प्रदान किए गए फ़ॉर्मेटिंग को समझना या बदलना हो, तो लेआउट आकृतियों का निरीक्षण करें।

निम्न उदाहरण प्रत्येक लेआउट आकृति के [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_fillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_lineformat/) को पढ़ता है, बिना यह मानते हुए कि हर आकृति `AutoShape` है।

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

लेआउट को संपादित करने से उस पर निर्भर कई स्लाइड प्रभावित हो सकती हैं। लेआउट आकृति को बदलने से पहले निर्धारित करें कि क्या कोई सामान्य स्लाइड ऑब्जेक्ट को निरुपित करती है या स्थानीय रूप से ओवरराइड करती है, और उस लेआउट का उपयोग करने वाले प्रत्येक स्लाइड की जांच करें।

## **आकृति को SVG में निर्यात करें**

[WriteAsSvg](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/writeassvg/) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकृति होती है, न कि पूरी स्लाइड पृष्ठभूमि या आस‑पास की आकृतियाँ।

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

रेंडरिंग के दौरान प्रस्तुति को खुला रखें। आउटपुट आकृति के फ़ॉर्मेटिंग और फ़ॉन्ट व इमेज जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना चाहिए, तो व्यक्तिगत आकृति के बजाय पूरी स्लाइड निर्यात करें। कॉलर को स्ट्रीम का स्वामित्व होता है और उसे बंद या डिस्पोज़ करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/alignshapes/) ओवरलोड सभी आकृतियों या चयनित संग्रह इंडेसेस को संरेखित कर सकते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapesalignmenttype/) किनारे, केंद्र रेखा या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` सेट करने से स्लाइड किनारे उपयोग होते हैं; `false` सेट करने से चयनित आकृतियों को आपस में संरेखित किया जाता है।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। संरेखण से ठीक पहले लौटाए गए आकृति रेफ़रेंसेज़ को उनके वर्तमान इंडेक्स में परिवर्तित किया जाता है।

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

संरेखण स्थिति बदलता है, न कि z‑order। सापेक्ष संरेखण के लिये सामान्यतः कम से कम दो आकृतियों की आवश्यकता होती है, जबकि क्षैतिज या लंबवत वितरण के लिये पर्याप्त आकृतियों की आवश्यकता होती है ताकि अंतराल निर्धारित किया जा सके। मेथड को कॉल करने से पहले यदि आप संग्रह को संशोधित करते हैं तो इंडेसेस को पुनः‑गणना करें।

## **आकृति को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग्स और घूर्णन को संग्रहीत करता है। इसके `FlipH` और `FlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/cpp/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप सक्षम करता है, `False` निष्क्रिय करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बनाए रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकृति रखता है।

![The shape before flipping](shape_to_be_flipped.png)

उदाहरण सभी अन्य फ्रेम मानों को बरकरार रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_frame/) असाइन करने से पूरा फ्रेम प्रतिस्थापित हो जाता है।

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

सहेजी गई आकृति क्षैतिज और लंबवत दोनों ओर प्रतिबिंबित होती है, जबकि उसकी स्थिति, आकार और घूर्णन समान रहते हैं।

![The shape after flipping](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकृति पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिए जब संग्रह ऑपरेशन के दौरान नहीं बदलेगा। निर्मित टेम्पलेट्स के लिये वैध `Name` या `AlternativeText` मानदंड अपनाएँ, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिये `OfficeInteropShapeId` उपयोग करें।

**क्या आकृति को छिपाने से वह z‑order से हट जाती है?**

नहीं। छिपी हुई आकृति उसी इंडेक्स पर संग्रह में बनी रहती है। इसे पाया, पुनः‑क्रमित, संपादित या फिर से दिखाया जा सकता है।

**क्लोन की गई आकृति दूसरे आकृति के सामने क्यों दिखाई दी?**

`AddClone` क्लोन को संग्रह के अंत में (z‑order के आगे) जोड़ता है। प्रारंभिक इंडेक्स चुनने के लिये `InsertClone` उपयोग करें या सभी आकृतियों के जोड़ने के बाद `Reorder` करें।

**क्या मैं प्रीसेट आकृति समायोजन की पहचान हेतु स्थिर इंडेक्स उपयोग कर सकता हूँ?**

केवल तब जब आप सटीक प्रीसेट और संग्रह लेआउट की पुष्टि कर चुके हों। `IGeometryShape::get_Adjustments` के माध्यम से इटररेट करना और `IAdjustValue::get_Type` की जाँच करना पसंद करें; जब समान सिमेंटिक टाइप कई बार आता है तो अतिरिक्त जानकारी के लिये `IAdjustValue::get_Name` उपयोग करें।