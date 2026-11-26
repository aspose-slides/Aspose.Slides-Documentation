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
- बिंदु संपादित करें
- बिंदु जोड़ें
- बिंदु हटाएं
- संपादन संचालन
- वक्र कोना
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पथ, वक्र कोने, सम्मिलित आकार।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पथों के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने का तरीका समझाता है। यह दिखाता है कि [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) और [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) के साथ कैसे काम किया जाए ताकि मौजूदा आकारों को संशोधित किया जा सके, मूल पथ संपादन संचालन किए जा सकें, बिंदुओं को जोड़ा या हटाया जा सके, और अद्यतन ज्यामिति को पुनः आकार पर लागू किया जा सके।

यह यह भी प्रदर्शित करता है कि कैसे कस्टम और सम्मिलित आकार बनाएँ, मोड़ वाले कोनों के साथ आकार बनाएँ, और यह निर्धारित करें कि क्या किसी आकार की ज्यामिति बंद है।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में, आप **Edit Points** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* एक कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

संपादन बिंदुओं से आप आकार की रूपरेखा बदल सकते हैं या किसी मौजूदा आकार को नई आकार की आधारशिला के रूप में उपयोग कर सकते हैं।

## **आकार संपादन सुझाव**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय इन अवधारणाओं को याद रखें:

* एक आकार (या उसका पथ) बंद या खुला हो सकता है।
* एक आकार का पथ एंकर बिंदुओं द्वारा जुड़े खंडों से मिलकर बनता है।
* एक खंड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसकी आकृति निर्धारित करते हैं।
* एंकर बिंदु कोने वाले बिंदु, सीधा बिंदु, या स्मूथ बिंदु के रूप में मौजूद होते हैं:
  * कोने वाले बिंदु पर, जुड़े खंड कोण पर मिल सकते हैं।
  * स्मूथ बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से विभिन्न दूरियाँ रख सकते हैं।
* एंकर बिंदुओं को перемिस या उनके हैंडल को समायोजित करने से आकार की रूपरेखा बदलती है।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए, **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) क्लास और [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) इंटरफ़ेस प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) उदाहरण [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) वस्तु का ज्यामिति पथ दर्शाता है।
* एक [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) को [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) उदाहरण से प्राप्त करने के लिए, आप [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) विधि का उपयोग कर सकते हैं।
* एक आकार के लिए [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) सेट करने हेतु, आप इन विधियों का उपयोग कर सकते हैं: एकल पथ वाले आकारों के लिए [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) और बहु‑पथ वाले आकारों के लिए [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/)।
* खंड जोड़ने के लिए, आप [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) के तहत उपलब्ध विधियों का उपयोग कर सकते हैं।
* [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) और [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) विधियों का उपयोग करके आप एक ज्यामिति पथ की उपस्थिति सेट कर सकते हैं।
* [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) विधि के द्वारा आप एक [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) की ज्यामिति पथ को पथ खंडों की श्रृंखला के रूप में प्राप्त कर सकते हैं।

## **सरल संपादन संचालन**

एक ज्यामिति पथ को संपादित करने के लिए निम्नलिखित विधियों का उपयोग करें। वे ओवरलोड जो इंडेक्स स्वीकार करते हैं, पथ के खंड सरणी में शून्य‑आधारित स्थिति पर एक खंड सम्मिलित करते हैं।

| ऑपरेशन | विधि |
| --- | --- |
| एक सीधी रेखा जोड़ें या सम्मिलित करें। | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु के साथ क्यूबिक Bézier वक्र जोड़ें या सम्मिलित करें। | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| एक नियंत्रण बिंदु और एक अंत बिंदु के साथ द्विघात Bézier वक्र जोड़ें या सम्मिलित करें। | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| निर्दिष्ट आयामों और डिग्री में कोणों के साथ एक दीर्घवृत्तीय चाप जोड़ें। | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| वर्तमान आकृति को उसके अंतिम बिंदु को प्रारम्भ बिंदु से जोड़कर बंद करें। | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| एक आकृति का प्रारम्भ बिंदु सेट करें। | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| शून्य‑आधारित इंडेक्स पर एक खंड हटाएँ। | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को आयताकार आकार में [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) के द्वारा सम्मिलित करता है और संपादित पथ को [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) के साथ लागू करता है। निर्देशांक आकार के स्थानीय होते हैं: दोनों नए बिंदु आकार के केंद्र में हैं, बाएँ से 100 पॉइंट और ऊपरी किनारे से 50 पॉइंट दूर। खंड सूचकांक 1 और 4 उन्हें क्रमशः शीर्ष और निचले किनारों पर रखता है, जिससे ये किनारे अंदर की ओर खिंचते हैं।

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

यह उदाहरण [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) का उपयोग करके शून्य‑आधारित सूचकांक 2 पर मौजूद खंड को हटाकर दिल के आकार की रूपरेखा बदलता है। संशोधित पथ को [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) के साथ लागू करने से आकार की रूपरेखा अद्यतन हो जाती है।

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

## **कस्टम आकार बनाएँ**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) का उपयोग करके पाँच‑कोने वाला सितारा बनाता है। बाहरी और अंतरिक त्रिज्याएँ क्रमशः 100 और 50 पॉइंट के वैकल्पिक मान शीर्षों और अंतरों को निर्धारित करते हैं; 72‑डिग्री कदम पाँच शीर्षों को समान रूप से विभाजित करता है। पथ को [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) द्वारा बंद किया जाता है और आयताकार आकार पर [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) द्वारा लागू किया जाता है, जिससे उसकी रूपरेखा प्रतिस्थापित हो जाती है।

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

## **संयोजित कस्टम आकार बनाएँ**

यह उदाहरण आकार के ऊपरी और निचले तिहाई हिस्सों के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) वस्तुओं को परिभाषित करता है। दोनों पथों को [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) के साथ लागू करने से मध्य तिहाई में एक अंतर के साथ एकल सम्मिलित आकार बनता है।

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
bottomPath->MoveTo(shape->get_Height() / 3 * 2, 0.0f);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **वक्र कोनों के साथ कस्टम आकार बनाएँ**

यह उदाहरण [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) के साथ सीधी खंडों को मिलाकर अंदर की ओर वक्र कोनों वाला आकार बनाता है। प्रत्येक कोने का आकार बिंदु में चाप की चौड़ाई और ऊँचाई को निर्धारित करता है, और -90‑डिग्री स्वेप उल्टी दिशा में एक चौथाई दीर्घवृत्त बनाता है। पूर्ण पथ को [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) के द्वारा लागू किया जाता है, और प्रस्तुति को PPTX फॉर्मेट में सहेजा जाता है।

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

## **जाँचें कि क्या आकार ज्यामिति बंद है**

निम्नलिखित सहायक जांचता है कि प्रत्येक गैर‑खाली ज्यामिति पथ एक समाप्ति खंड के साथ समाप्त होता है या नहीं। यह [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) को पढ़ता है और अंतिम खंड के [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) की तुलना [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) से करता है। जब कोई गैर‑खाली पथ नहीं होता तो यह false लौटाता है। यह प्रत्येक पथ के अंतिम कमांड को जांचता है; यह पथ के प्रत्येक उप‑आकृति की जाँच नहीं करता। उदाहरण में आयत के लिए `True` मुद्रित होता है।

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

## **ज्यामिति पथ कमांड देखें**

[contour.pptx](contour.pptx) डाउनलोड करें और इसे अनुप्रयोग के कार्य निर्देशिका में रखें। पहली स्लाइड पर पहला आकार एक सीधी शीर्ष किनारा, एक क्यूबिक Bézier वक्र और एक सीधा समापन किनारा रखता है। इसके पथ पढ़ने के लिए [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) का उपयोग करें। प्रत्येक पथ के लिए, [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) खंडों को ड्राइंग क्रम में लौटाता है। [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) द्वारा लौटाया गया कमांड यह निर्धारित करता है कि [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/) द्वारा लौटाए मानों को कैसे व्याख्या किया जाए।

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

आकार (200, 100) पॉइंट पर स्थित है। रिपोर्ट किए गये बिंदु आकार के स्थानीय होते हैं, जहाँ (0, 0) उसके ऊपरी‑बाएँ कोने पर है, X दाएँ बढ़ता है, और Y नीचे की ओर बढ़ता है। समापन खंड अतिरिक्त निर्देशांक के बिना प्रारम्भ बिंदु पर वापस आता है।

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **आकार तत्व निकालें और निरीक्षण करें**

[IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) का उपयोग करके आप किसी मौजूदा आकार को पथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण कर सकते हैं। प्रत्येक लौटाए गए [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) को [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) में कास्ट करके आप [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) और [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) द्वारा लौटाए गए सरणियों को पढ़ सकते हैं। यह प्रतिनिधित्व रूपरेखा विश्लेषण या कस्टम ड्राइंग टूल्स को ज्यामिति पास करने के लिए उपयोगी है।

उदाहरण एक प्रस्तुति खोलता है, पहले स्लाइड पर सीधे पहला ज्यामिति आकार खोजता है, और उसके पथ खंडों को प्रिंट करता है। दोनों प्रकार के आउटपुट देखने के लिए ऐसी प्रस्तुति का उपयोग करें जिसमें सीधी और वक्र दोनों खंड हों। यह समूहों के अंदर खोज नहीं करता।

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
        auto pointType = types[i] & 0x07; // सेगमेंट प्रकार रखें, फ़्लैग को बाहर रखते हुए।
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
                i += 2; // दोनों नियंत्रण बिंदुओं और अंतिम बिंदु को खपत करें।
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

सरणी इंडेक्स द्वारा संबंधित होती हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका वर्णित करता है। प्रकार `0` आकृति का प्रारम्भ दर्शाता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक रेखा बनाता है। क्यूबिक Bézier खंड पहले अंतिम बिंदु से शुरू होता है और क्रमिक तीन प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और फिर नया अंतिम बिंदु। लूप इन तीन प्रविष्टियों को एक साथ ग्रहण करता है और समापन की जाँच करता है।

बिंदु प्रकार भी फ़्लैग रखते हैं। सेगमेंट प्रकार पहचानने के लिये `0x07` के साथ मास्क करें, और बंद उप‑पथ पता करने के लिये `0x80` को अलग‑अलग परीक्षण करें। उदाहरण के लिये, `129` (`0x81`) एक लाइन अंत बिंदु दर्शाता है जो उप‑पथ को बंद करता है, और `131` (`0x83`) एक Bézier अंत बिंदु है जो बंद करता है। केवल `1` या `3` के साथ कच्चे मान की तुलना करने से ये स्थितियाँ छूट जाएँगी। डैश (`0x10`) और मार्कर (`0x20`) जैसे अन्य फ़्लैग मूल सेगमेंट प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु पॉइंट (1/72 इंच) में मापे जाते हैं, X दाएँ और Y नीचे की ओर बढ़ता है। अनग्रुप्ड आकार के लिये, निकाले गये निर्देशांक पहले से ही [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) और [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) द्वारा लौटायी गई स्थिति को सम्मिलित करते हैं और वर्तमान चौड़ाई‑ऊँचाई को प्रतिबिंबित करते हैं। उदाहरण के लिये, `(100, 200)` पर बिना घुमा हुआ आयत जिसका आकार `120 × 80` है, उसकी रूपरेखा सीमा `(100, 200)`‑`(220, 280)` होगी। आकार की स्थिति को दोबारा जोड़ें नहीं। वह बिंदु प्राप्त करने के लिये X और Y घटाएँ।

निकाले गये बिंदु [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) या क्षैतिज/ऊर्ध्वाधर फ़्लिप द्वारा लगाई गयी घूर्णन को लागू नहीं करते। प्रदर्शित रूपरेखा को पुनः प्राप्त करने हेतु इन रूपांतरणों को आकार के केंद्र के चारों ओर लागू करें। समूहित आकारों के लिये समूह निर्देशांक मानचित्रण और रूपांतरणों को भी ध्यान में रखें; यह मानकर न चलें कि निकाले गये बिंदु अंतिम स्लाइड निर्देशांक हैं या अनावश्यक रूप से अनुवाद/स्केल दो बार लागू हुआ है।

**निरीक्षण बनाम संपादन।** निकाले गये सरणियों से केवल रूपरेखा का वर्णन होता है; उन्हें बदलने से मूल आकार अद्यतन नहीं होता। जब आपका विश्लेषण या ड्राइंग कोड बिंदु/प्रकार सरणियों की आवश्यकता रखता है तो इस विधि का चयन करें। जब आपको आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए या उसका ज्यामिति संपादित करना है, तो [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) का उपयोग करें। संपादित पथ को [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) या [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) द्वारा लागू करें।

## **GeometryPath को GraphicsPath में बदलें**

वर्तमान Aspose.Slides for C++ सार्वजनिक API ज्यामिति पथ और ग्राफ़िक्स पथ के बीच रूपांतरण को उजागर नहीं करता। रूपरेखा का निरीक्षण करने के लिये ऊपर वर्णित आकार तत्वों का उपयोग करें। आकार को संपादित करने के लिये ज्यामिति पथों का उपयोग करें और अद्यतन पथों को आकार पर लागू करें।

## **FAQ**

**ज्यामिति को प्रतिस्थापित करने के बाद भराव और रूपरेखा का क्या होता है?**

शैली आकार के साथ बनी रहती है; केवल रूपरेखा बदलती है। भराव और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू हो जाते हैं।

**कस्टम आकार को उसकी ज्यामिति के साथ सही ढंग से कैसे घुमाया जाए?**

आकार की [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) विधि का उपयोग करें; जब आप आकार को घुमाते हैं तो उसकी ज्यामिति भी घुमती है क्योंकि वह आकार के अपने निर्देशांक प्रणाली से बंधी होती है।

**क्या मैं एक कस्टम आकार को छवि में परिवर्तित कर “लॉक” कर सकता हूँ?**

हाँ। आवश्यक [स्लाइड](/slides/hi/cpp/convert-powerpoint-to-png/) क्षेत्र या स्वयं [आकार](/slides/hi/cpp/shape-thumbnails/) को रैस्टर फ़ॉर्मेट में निर्यात करें; इससे जटिल ज्यामितियों के साथ आगे काम करना सरल हो जाता है।