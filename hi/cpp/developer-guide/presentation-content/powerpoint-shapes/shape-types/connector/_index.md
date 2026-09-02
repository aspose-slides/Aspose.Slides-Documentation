---
title: C++ का उपयोग करके प्रस्तुतियों में कनेक्टर प्रबंधित करें
linktitle: कनेक्टर
type: docs
weight: 10
url: /hi/cpp/connector/
keywords:
- कनेक्टर
- कनेक्टर प्रकार
- कनेक्टर बिंदु
- कनेक्टर रेखा
- कनेक्टर कोण
- कनेक्शन साइट
- समायोजन बिंदु
- आकृतियों को जोड़ें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ सीधे, मुड़े हुए और वक्र PowerPoint कनेक्टर्स को जोड़ना, संलग्न करना, पुनःमार्गित करना, समायोजित करना और निरीक्षण करना सीखें।"
---
## **परिचय**

एक कनेक्टर वह रेखा है जो दो आकृतियों से जुड़ी रह सकती है जब भी कोई भी आकृति गतिशील हो। इसके सिरे कनेक्शन साइट्स से जुड़ते हैं, जो PowerPoint में हरे बिंदुओं द्वारा दर्शाए जाते हैं। कुछ मुड़ी हुई और वक्र कनेक्टर्स में समायोजन बिंदु भी होते हैं, जो नारंगी बिंदुओं द्वारा दर्शाए जाते हैं, और व्यक्तिगत कनेक्टर खंडों की स्थिति को नियंत्रित करते हैं।

Aspose.Slides कनेक्टर्स को [IConnector](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iconnector/) इंटरफ़ेस के माध्यम से प्रदर्शित करता है। आप इन्हें बना सकते हैं, उनके सिरों को आकृतियों से जोड़ सकते हैं, कनेक्शन साइट चुन सकते हैं, उन्हें पुनःमार्गित कर सकते हैं, और उन कनेक्टर्स की ज्यामिति को बदल सकते हैं जिनमें समायोजन बिंदु होते हैं।

## **कनेक्टर प्रकार**

[ShapeType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapetype/) enumeration में सीधी, मुड़ी हुई और वक्र कनेक्टर प्रीसेट्स शामिल हैं। नीचे दी गई तालिका उपलब्ध कनेक्टर ज्यामिति और प्रत्येक प्रीसेट द्वारा परिभाषित समायोजन बिंदुओं की संख्या दिखाती है।

| कनेक्टर | छवि | समायोजन बिंदुओं की संख्या |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

समायोजन बिंदुओं की संख्या और उनका अर्थ चुने गए कनेक्टर प्रीसेट का हिस्सा होते हैं। यह न मानें कि दो अलग-अलग कनेक्टर प्रकार समान संग्रह लेआउट प्रदर्शित करते हैं।

## **दो आकृतियों को जोड़ें**

एक कनेक्टर जोड़ने के लिए [IShapeCollection::AddConnector](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addconnector/) का उपयोग करें, और इसके सिरों को जोड़ने के लिए क्रमशः [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) और [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) को कॉल करें। दोनों सिरों के जुड़ने के बाद, [IConnector::Reroute](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iconnector/reroute/) आकृतियों के बीच एक छोटा मार्ग चुनता है।

निम्न उदाहरण में एक वक्र कनेक्टर के साथ अंडाकार और आयताकार को जोड़ा गया है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);
connector->Reroute();

presentation->Save(u"connected-shapes.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
`IConnector::Reroute` कॉल करने से [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) और [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/) मान बदल सकते हैं। यदि उन साइटों को स्थिर रखना हो तो पुनःमार्गित करने के बाद विशिष्ट कनेक्शन साइट्स असाइन करें।
{{% /alert %}}

## **कनेक्शन साइट चुनें**

प्रत्येक कनेक्टेबल आकृति अपने साइटों की संख्या [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_connectionsitecount/) द्वारा रिपोर्ट करती है। साइट इंडेक्स को कनेक्टर के सिरे पर असाइन करने से पहले शून्य-आधारित साइट इंडेक्स को सत्यापित करें; साइट गिनती आकृति ज्यामिति के अनुसार भिन्न होती है।

यह उदाहरण अंडाकार पर विशेष साइट मौजूद होने पर कनेक्टर को उस साइट से जोड़ता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);

int32_t preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse->get_ConnectionSiteCount())
{
    connector->set_StartShapeConnectionSiteIndex(preferredSiteIndex);
}
else
{
    Console::WriteLine(u"The ellipse has only {0} connection sites.", ellipse->get_ConnectionSiteCount());
}

presentation->Save(u"specific-connection-site.pptx", SaveFormat::Pptx);
```

## **कनेक्टर बिंदु को समायोजित करें**

समायोजन बिंदुओं वाले कनेक्टर्स इन्हें [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igeometryshape/get_adjustments/) के माध्यम से उजागर करते हैं। प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/) की जाँच करें और उसके [IAdjustValue::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/get_type/) को समझें, फिर [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/set_rawvalue/) बदलें। प्रीसेट आकृति समायोजन की सामान्य नियम [Shape Manipulation](/slides/hi/cpp/shape-manipulations/) में वर्णित हैं।

समायोजन बिंदुओं की संख्या, क्रम, अर्थ और वैध मान सीमा कनेक्टर प्रीसेट पर निर्भर करती है। `IAdjustValue::get_Type` द्वारा लौटाए गए प्रकार केवल पढ़ने योग्य होते हैं, जबकि कच्चा समायोजन मान लिखने योग्य होता है। जब एक कनेक्टर में समान अर्थ वाले कई समायोजन होते हैं, तो पढ़ने‑योग्य [IAdjustValue::get_Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iadjustvalue/get_name/) अतिरिक्त पहचान प्रदान करता है।

### **एक बाधा के आसपास मार्ग बनाएं**

निम्न लेआउट में दो आकृतियों के बीच एक `ShapeType::BentConnector5` कनेक्टर तीसरी आकृति के माध्यम से गुजरता है:

![connector-obstruction](connector-obstruction.png)

यह कोड बाधित कनेक्टर बनाता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

presentation->Save(u"connector-obstruction.pptx", SaveFormat::Pptx);
```

ऊर्ध्वाधर मोड़ को बदलने से मार्ग बदल जाता है और कनेक्टर बाधा को पार करता है:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

संग्रह इंडेक्स `1` को हमेशा ऊर्ध्वाधर मोड़ मानने के बजाय, यह उदाहरण `ShapeAdjustmentType::ConnectorBendPositionY` खोजता है और केवल तब बदलता है जब अपेक्षित अर्थ वाला प्रकार मौजूद हो:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend->set_RawValue(60000);
    presentation->Save(u"connector-obstruction-fixed.pptx", SaveFormat::Pptx);
}
```

`ShapeType::BentConnector5` में दो `ShapeAdjustmentType::ConnectorBendPositionX` और एक `ShapeAdjustmentType::ConnectorBendPositionY` समायोजन होते हैं। यदि आवश्यक प्रकार कई बार आता है, तो चयन से पहले `IAdjustValue::get_Name` और उस प्रीसेट की ज्ञात ज्यामिति देखें। यदि कोई समायोजन `ShapeAdjustmentType::Custom` रिपोर्ट करता है, तो उसके अर्थ और सीमा को प्रीसेट‑विशिष्ट मानें और तभी बदलें जब वह अनुबंध ज्ञात हो।

## **समायोजन मानों को कनेक्टर ज्यामिति से जोड़ें**

मुड़े हुए कनेक्टर्स के लिए, समायोजन मान व्यक्तिगत खंडों की स्थितियों का अनुमान लगाने में उपयोग किए जा सकते हैं। ये गणनाएँ कनेक्टर प्रीसेट के विशिष्ट हैं:

- `ShapeType::BentConnector4` सामान्यतः एक `ShapeAdjustmentType::ConnectorBendPositionX` और एक `ShapeAdjustmentType::ConnectorBendPositionY` समायोजन उजागर करता है।
- इन मोड़ स्थितियों के लिए, `RawValue / 100000.0f` नीचे दिखाए गए उदाहरणों में उपयोग किए गए कनेक्टर फ्रेम की चौड़ाई या ऊँचाई का भाग देता है।
- एक कनेक्टर फ्रेम को घुमा या उलटा जा सकता है, इसलिए फ्रेम निर्देशांक को स्लाइड निर्देशांकों के साथ तुलना करने से पहले परिवर्तित करना आवश्यक है।

निम्न उदाहरण पहले `IAdjustValue::get_Type` द्वारा समायोजन प्रकार पहचानते हैं। वे संग्रह इंडेक्स को पोर्टेबल पहचानकर्ता के रूप में उपयोग नहीं करते।

### **अघूर्णित कनेक्टर**

प्रारंभिक लेआउट में दो टेक्स्ट आकृतियाँ एक `ShapeType::BentConnector4` द्वारा जुड़ी हैं:

![connector-shape-complex](connector-shape-complex.png)

यह उदाहरण कनेक्टर का निरीक्षण करता है और उसकी क्षैतिज एवं अनुलंब मोड़ समायोजन प्राप्त करता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Crimson());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
}
```

दोनों मोड़ों को बदलने के लिए, प्रत्येक अपेक्षित प्रकार को खोजें और दोनों मिलने के बाद ही मान बदलें:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);
    presentation->Save(u"connector-adjusted.pptx", SaveFormat::Pptx);
}
```

परिणामस्वरूप कनेक्टर के क्षैतिज और अनुलंब खंड स्थानांतरित हो जाते हैं:

![connector-adjusted-1](connector-adjusted-1.png)

अर्थपूर्ण प्रकार ज्ञात होने पर, उनके मानों को कनेक्टर‑फ्रेम निर्देशांक में परिवर्तित किया जा सकता है। यह उदाहरण दो मोड़ समायोजनों द्वारा नियंत्रित अनुलंब खंड पर एक पतली आयत खींचता है:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    float x = connector->get_X() + connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float y = connector->get_Y();
    float height = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    shapes->AddAutoShape(ShapeType::Rectangle, x, y, 1, height);
    presentation->Save(u"connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

गाइड आकृति गणना किए गए खंड को चिह्नित करती है:

![connector-adjusted-2](connector-adjusted-2.png)

### **घुमाया या उलटा कनेक्टर**

जब समान कनेक्टर ज्यामिति लंबवत रूप से उन्मुख होती है, तो उसके [IShape::get_Frame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapeframe/get_fliph/), और [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapeframe/get_flipv/) मान कनेक्टर‑फ्रेम निर्देशांक से स्लाइड निर्देशांक के परिवर्तन पर प्रभाव डालते हैं।

यह उदाहरण लंबवत उन्मुख कनेक्टर बनाता और समायोजित करता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To 1");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_MediumAquamarine());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 20000);
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 200000);
    }
}

presentation->Save(u"vertical-connector-adjusted.pptx", SaveFormat::Pptx);
```

समायोजित कनेक्टर आकृतियों के बीच लंबवत रूप से दिखता है:

![connector-adjusted-3](connector-adjusted-3.png)

किसी भी घूर्णन कोन `alpha` के लिए, कनेक्टर‑फ्रेम बिंदु `(x, y)` को फ्रेम केंद्र `(x0, y0)` के चारों ओर घुमाएँ:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

निम्न कोड इस उदाहरण में उपयोग किए गए 90‑डिग्री अभिविन्यास को संभालता है और संबंधित कनेक्टर खंड पर एक लाल गाइड खींचता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);

    float x = connector->get_X();
    float y = connector->get_Y();
    auto frame = connector->get_Frame();
    if (frame->get_FlipH() == NullableBool::True)
    {
        x += connector->get_Width();
    }
    if (frame->get_FlipV() == NullableBool::True)
    {
        y += connector->get_Height();
    }

    x += connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float rotatedX = frame->get_CenterX() - y + frame->get_CenterY();
    float rotatedY = x - frame->get_CenterX() + frame->get_CenterY();
    float segmentWidth = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    auto guide = shapes->AddAutoShape(ShapeType::Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    auto guideLineFillFormat = guide->get_LineFormat()->get_FillFormat();
    guideLineFillFormat->set_FillType(FillType::Solid);
    guideLineFillFormat->get_SolidFillColor()->set_Color(Color::get_Red());

    presentation->Save(u"rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

समन्वय परिवर्तन के बाद लाल गाइड गणना किए गए खंड को चिह्नित करता है:

![connector-adjusted-4](connector-adjusted-4.png)

ये सूत्र उदाहरणों में उपयोग किए गए प्रीसेट्स का वर्णन करते हैं, न कि सार्वभौमिक कनेक्टर मॉडल का। समान गणना को किसी अन्य प्रीसेट पर लागू करने से पहले समायोजन प्रकार, फ्रेम अभिविन्यास और मान श्रेणियों को सत्यापित करें।

## **कनेक्टर दिशा कोण खोजें**

एक सीधी कनेक्टर की दिशा उसकी चौड़ाई और ऊँचाई से निर्धारित की जा सकती है, जिसमें क्षैतिज और अनुलंब फ्लिप शामिल होते हैं। निम्न उदाहरण स्लाइड निर्देशांक में सकारात्मक क्षैतिज अक्ष से घड़ी की दिशा में कोण रिपोर्ट करता है:

```cpp
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/math.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);
auto frame = connector->get_Frame();

bool flipH = frame->get_FlipH() == NullableBool::True;
bool flipV = frame->get_FlipV() == NullableBool::True;
float deltaX = connector->get_Width() * (flipH ? -1 : 1);
float deltaY = connector->get_Height() * (flipV ? -1 : 1);
double angle = Math::Atan2(deltaY, deltaX) * 180.0 / Math::PI;

if (angle < 0)
{
    angle += 360;
}

Console::WriteLine(u"Connector direction: {0:F2} degrees", angle);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि कोई कनेक्टर आकृति से जुड़ सकता है या नहीं?**

आकृति के `IShape::get_ConnectionSiteCount` मान को जांचें। सकारात्मक गिनती दर्शाती है कि आकृति कनेक्शन साइट्स उजागर करती है। कनेक्टर के किसी भी सिरे को असाइन करने से पहले चयनित साइट इंडेक्स को सत्यापित करें।

**क्या मैं कनेक्टर समायोजन को उसके संग्रह इंडेक्स से पहचान सकता हूँ?**

इंडेक्स केवल ज्ञात कनेक्टर प्रीसेट और संग्रह लेआउट के लिए अर्थपूर्ण होता है। मान बदलने से पहले `IAdjustValue::get_Type` जांचें, और जब समान अर्थ वाला प्रकार एक से अधिक बार आता है तो अतिरिक्त जानकारी के लिए `IAdjustValue::get_Name` का उपयोग करें।

**जब जुड़ी हुई आकृति हटाई जाती है तो क्या होता है?**

संबंधित कनेक्टर का सिरा डिस्कनेक्ट हो जाता है। कनेक्टर स्लाइड पर बना रहता है और उसे हटाया, मुक्त रेखा के रूप में स्थित या किसी अन्य आकृति से जोड़ा जा सकता है।

**क्या स्लाइड कॉपी करने पर कनेक्टर बाइंडिंग्स बरकरार रहती हैं?**

आमतौर पर बाइंडिंग्स बरकरार रहती हैं जब जुड़ी हुई आकृतियों को स्लाइड के साथ कॉपी किया जाता है। यदि कनेक्टर को उसके लक्षित आकृतियों में से एक के बिना कॉपी किया जाता है, तो प्रभावित सिरे को फिर से जोड़ना होगा।