---
title: C++ में प्रस्तुति आकारों को अनुकूलित करें
linktitle: कस्टम आकार
type: docs
weight: 20
url: /hi/cpp/custom-shape/
keywords:
- कस्टम आकार
- आकार जोड़ें
- आकार बनाएं
- आकार बदलें
- आकार ज्यामिति
- ज्यामिति पथ
- पथ बिंदु
- संपादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएं
- संपादन ऑपरेशन
- वक्र कोना
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पथ, वक्र कोने, सम्मिलित आकार।"
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पथों के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने के तरीके को समझाता है। यह दर्शाता है कि कैसे [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) और [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) का उपयोग करके मौजूदा आकारों को संशोधित किया जाए, बुनियादी पथ संपादन क्रियाओं को किया जाए, बिंदुओं को जोड़ा या हटाया जाए, और अद्यतन ज्यामिति को फिर से आकार पर लागू किया जाए।

यह यह भी दर्शाता है कि कैसे कस्टम और सम्मिलित आकार बनाएँ, वक्र कोनों वाले आकार बनाएं, और यह निर्धारित करें कि कोई आकार ज्यामिति बंद है या नहीं।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में, आप **संपादन बिंदु** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* एक कोना अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

बिंदुओं को संपादित करने से आप आकार की रूपरेखा संशोधित कर सकते हैं या मौजूदा आकार को नई आकार की आधार बना सकते हैं।

## **आकार संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय, इन अवधारणाओं को ध्यान में रखें:

* कोई आकार (या उसका पथ) बंद या खुला हो सकता है।
* एक आकार का पथ एंकर बिंदुओं से बना होता है जो खंडों द्वारा जुड़े होते हैं।
* एक खंड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसकी आकृति निर्धारित करते हैं।
* एंकर बिंदु कोने वाले बिंदु, सीधी रेखा वाले बिंदु, या स्मूद बिंदु के रूप में मौजूद होते हैं:
  * कोने वाले बिंदु पर, जुड़े खंड एक कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधे बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से अलग-अलग दूरी पर हो सकते हैं।
* एंकर बिंदुओं को स्थानांतरित करने या उनके हैंडल को समायोजित करने से आकार की रूपरेखा बदल जाती है।

संपादन बिंदुओं के माध्यम से PowerPoint आकारों को संपादित करने के लिए, **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) क्लास और [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) इंटरफ़ेस प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) उदाहरण [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) ऑब्जेक्ट का ज्यामिति पथ दर्शाता है।
* [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) उदाहरण से [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) प्राप्त करने के लिए, आप [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) मेथड का उपयोग कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) सेट करने के लिए, आप ये मेथड उपयोग कर सकते हैं: एकल पथ वाले आकारों के लिए [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) और कई पथ वाले आकारों के लिए [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/)।
* सेगमेंट जोड़ने के लिए, आप [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) के नीचे दिए गए मेथड का उपयोग कर सकते हैं।
* [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) और [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) मेथड का उपयोग करके, आप ज्यामिति पथ की उपस्थिति सेट कर सकते हैं।
* [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) मेथड का उपयोग करके, आप [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) की ज्यामिति पथ को पथ खंडों की एरे के रूप में प्राप्त कर सकते हैं।

## **सरल संपादन संचालन**

ज्यामिति पथ को संपादित करने के लिए निम्नलिखित मेथड का उपयोग करें। जो ओवरलोड इंडेक्स स्वीकार करते हैं, वह पथ की सेगमेंट एरे में शून्य-आधारित स्थिति पर एक सेगमेंट डालते हैं।

| ऑपरेशन | मेथड |
| --- | --- |
| एक सीधी रेखा जोड़ें या डालें। | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु वाले क्यूबिक बेज़र कर्व को जोड़ें या डालें। | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| एक नियंत्रण बिंदु और एक अंत बिंदु वाले क्वाड्रेटिक बेज़र कर्व को जोड़ें या डालें। | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| निर्दिष्ट आयामों और डिग्री में कोणों के साथ एक दीर्घवृत्तीय आर्क जोड़ें। | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| वर्तमान आकृति को उसके अंत बिंदु को प्रारंभ बिंदु से जोड़कर बंद करें। | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| आकृति का प्रारंभ बिंदु सेट करें। | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| शून्य-आधारित इंडेक्स पर एक सेगमेंट हटाएँ। | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) का उपयोग करके एक आयताकार आकार में दो बिंदु डालता है और संपादित पथ को [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) के साथ लागू करता है। निर्देशांक आकार के स्थानीय होते हैं: दोनों नए बिंदु उसके केंद्र में हैं, बाएँ से 100 पॉइंट और ऊपर से 50 पॉइंट पर। सेगमेंट इंडेक्स 1 और 4 उन्हें शीर्ष और नीचे किनारों पर रखते हैं, जिससे ये किनारे अंदर की ओर खींचे जाते हैं।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **आकार से बिंदु हटाएँ**

यह उदाहरण दिल-आकार की रूपरेखा को बदलता है, जिसमें [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) के साथ शून्य-आधारित इंडेक्स 2 पर सेगमेंट हटाया जाता है। संशोधित पथ को [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) के साथ लागू करने से आकार की रूपरेखा अद्यतन हो जाती है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **एक कस्टम आकार बनाएँ**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) का उपयोग करके पाँच-बिंदु वाला तारा बनाता है। 100 और 50 पॉइंट के बारी-बारी बाहरी और आंतरिक त्रिज्या टिप्स और अंतराल को परिभाषित करती हैं; 72-डिग्री का चरण पाँच टिप्स को समान रूप से वितरित करता है। पथ को [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) द्वारा बंद किया जाता है और [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) के साथ एक आयताकार आकार पर लागू किया जाता है, जो उसकी रूपरेखा को बदल देता है।

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **एक कॉम्पोजिट कस्टम आकार बनाएँ**

यह उदाहरण आकार के शीर्ष और नीचे के तिहाई हिस्सों के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ऑब्जेक्ट परिभाषित करता है। दोनों पथों को [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) के साथ लागू करने से मध्य तिहाई में फ़ासले के साथ एक एकल कॉम्पोजिट आकार बनता है।

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **वक्र कोनों वाला कस्टम आकार बनाएँ**

यह उदाहरण सीधे खंडों को [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) के साथ मिलाकर अंदर की ओर वक्र कोनों वाला आकार बनाता है। प्रत्येक कोने का आकार आर्क की चौड़ाई और ऊँचाई को पॉइंट में सेट करता है, और -90-डिग्री स्वीप एक विपरीत घड़ी दिशा में एक चौथाई दीर्घवृत्त बनाता है। पूर्ण पथ को [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) के साथ लागू किया जाता है, और प्रस्तुति को PPTX फ़ॉर्मेट में सहेजा जाता है।

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **जाँचें कि क्या आकार की ज्यामिति बंद है**

निम्नलिखित हेल्पर यह जांचता है कि प्रत्येक गैर-खाली ज्यामिति पथ एक बंद सेगमेंट के साथ समाप्त होता है या नहीं। यह [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) पढ़ता है और अंतिम सेगमेंट के [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) की तुलना [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) से करता है। जब कोई गैर-खाली पथ नहीं होता तो यह false लौटाता है। यह प्रत्येक पथ के अंतिम कमांड की जाँच करता है; यह पथ के प्रत्येक उप-चित्र का निरीक्षण नहीं करता। उदाहरण rectangle के लिए `True` प्रिंट करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **आकार तत्वों को निकालें और निरीक्षण करें**

[IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) का उपयोग करके किसी मौजूदा आकार को पथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण करें। प्रत्येक लौटाए गए [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) को [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) में कास्ट करके [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) और [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) द्वारा लौटाए गए एरे पढ़ें। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्राइंग टूल्स को ज्यामिति पास करने के लिए उपयोगी है।

यह उदाहरण एक प्रस्तुति खोलता है, पहले स्लाइड पर सीधे पहले ज्यामिति आकार को खोजता है, और उसके पथ खंडों को प्रिंट करता है। सीधी और वक्र खंडों वाले आकार वाली प्रस्तुति का उपयोग करके दोनों प्रकार का आउटपुट देखें। यह समूहों के भीतर खोज नहीं करता।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // सेगमेंट प्रकार को रखें, फ्लैग को छोड़ते हुए.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

एरे इंडेक्स द्वारा मेल खाते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका दर्शाता है। प्रकार `0` एक आकृति की शुरुआत करता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक रेखा बनाता है। एक क्यूबिक बेज़र सेगमेंट पिछले अंत बिंदु से शुरू होता है और लगातार तीन प्रकार-`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और फिर नया अंत बिंदु। लूप इन तीन प्रविष्टियों को साथ में उपभोग करता है और अंत बिंदु को बंद होने के लिए जाँचता है।

बिंदु प्रकारों में फ़्लैग भी शामिल होते हैं। सेगमेंट प्रकार पहचानने के लिए `0x07` से मास्क करें, और बंद उप-पथ पहचानने के लिए `0x80` को अलग से परीक्षण करें। उदाहरण के लिए, `129` (`0x81`) एक रेखा अंत बिंदु है जो उप-पथ को बंद करता है, और `131` (`0x83`) एक बेज़र अंत बिंदु है जो इसे बंद करता है। केवल `1` या `3` के साथ कच्चे मान की तुलना करने से ये मामलों छूटेंगे। अन्य फ़्लैग, जैसे डैश (`0x10`) और मार्कर (`0x20`), बेस सेगमेंट प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।**

बिंदु पॉइंट्स (1/72 इंच) में मापे जाते हैं, जहाँ X दाएँ और Y नीचे की ओर बढ़ता है। अनग्रुप्ड आकार के लिए, निकाले गए निर्देशांक पहले से ही [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) और [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) द्वारा लौटाए गये स्थान को शामिल करते हैं और उसकी वर्तमान चौड़ाई तथा ऊँचाई को दर्शाते हैं। उदाहरण के लिए, `(100, 200)` पर अनरोटेटेड आयत जिसका आकार `120 × 80` है, उसकी कंटूर सीमा `(100, 200)`–`(220, 280)` है। आकार की स्थिती को दोबार न जोड़ें। उसके X और Y को घटाकर अनरोटेटेड फ्रेम के सापेक्ष निर्देशांक प्राप्त करें।

निकाले गए बिंदुओं पर [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) या क्षैतिज और लंबवत फ़्लिप द्वारा सेट किए गए घुमाव लागू नहीं होते। प्रदर्शित कंटूर को पुनः बनाने के लिए, इन रूपांतरणों को आकार के केन्द्र के आसपास लागू करें। समूहित आकारों के लिए, समूह निर्देशांक मानचित्रण और रूपांतरणों को भी ध्यान में रखें; यह मत मानें कि निकाले गए बिंदु अंतिम रेंडर्ड स्लाइड निर्देशांक हैं या यदि वह पहले ही बच्चे के फ्रेम में प्रतिबिंबित है तो अनुवाद या स्केल को दो बार न लगाएँ।

**निरीक्षण बनाम संपादन।**

निकाले गए एरे कंटूर को वर्णित करते हैं; उन्हें बदलने से मूल आकार अपडेट नहीं होता। यह विधि तब चुनें जब आपके विश्लेषण या ड्रॉइंग कोड को बिंदु/प्रकार एरे की आवश्यकता हो। जब आपको आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए या उसकी ज्यामिति संपादित करनी हो तो [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) का उपयोग करें। संपादित पथों को [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) या [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) के माध्यम से लागू करें।

## **GeometryPath को GraphicsPath में बदलें**

वर्तमान Aspose.Slides for C++ सार्वजनिक API ज्यामिति पथों और ग्राफ़िक्स पथों के बीच रूपांतरण नहीं प्रदान करता। कंटूर का निरीक्षण करने के लिए, ऊपर वर्णित अनुसार आकार तत्वों का उपयोग करें। आकार को संपादित करने के लिए, ज्यामिति पथों का उपयोग करके अद्यतन पथों को आकार पर लागू करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**ज्यामिति को बदलने के बाद भराव और रूपरेखा क्या होगी?**

शैली आकार के साथ बनी रहती है; केवल कंटूर बदलता है। भराव और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू होते हैं।

**मैं कस्टम आकार को उसकी ज्यामिति के साथ सही तरीके से कैसे घुमा सकता हूँ?**

आकार के [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) मेथड का उपयोग करें; ज्यामिति आकार के साथ घुमा जाती है क्योंकि यह आकार की अपनी निर्देशांक प्रणाली से बंधी होती है।

**क्या मैं कस्टम आकार को एक छवि में बदल सकता हूँ ताकि परिणाम को 'लॉक' किया जा सके?**

हाँ। आवश्यक [स्लाइड](/slides/hi/cpp/convert-powerpoint-to-png/) क्षेत्र या स्वयं [आकार](/slides/hi/cpp/shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; इससे जटिल ज्यामितियों के साथ आगे का कार्य सरल हो जाता है।