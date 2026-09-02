---
title: إدارة الموصلات في العروض التقديمية باستخدام C++
linktitle: موصل
type: docs
weight: 10
url: /ar/cpp/connector/
keywords:
- موصل
- نوع الموصل
- نقطة الموصل
- خط الموصل
- زاوية الموصل
- موقع الاتصال
- نقطة تعديل
- ربط الأشكال
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إضافة وربط وإعادة توجيه وتعديل وفحص الموصلات المستقيمة، المنحنية والمنحرفة في PowerPoint باستخدام Aspose.Slides للـ C++."
---
## **نظرة عامة**

الموصل هو خط يمكن أن يبقى مرتبطًا بشكليّن عندما يتحرك أي من الشكلين. نهاياته ترتبط بمواقع الاتصال، التي تُظهر بنقاط خضراء في PowerPoint. بعض الموصلات المنحنية والمنحرفة تكشف أيضًا عن نقاط تعديل، تُظهر بنقاط برتقالية، تتحكم في موضع أجزاء الموصل الفردية.

تمثل Aspose.Slides الموصلات من خلال واجهة [IConnector](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iconnector/). يمكنك إنشاءها، ربط نهاياتها بالأشكال، اختيار مواقع الاتصال، إعادة توجيهها، وتعديل هندسة الموصلات التي تحتوي على نقاط تعديل.

## **أنواع الموصلات**

تتضمن تعداد [ShapeType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapetype/) إعدادات موصل مستقيم، منحني، ومنحنى مسبقة. تُظهر الجدول التالي هندسات الموصل المتاحة وعدد نقاط التعديل المحددة لكل إعداد مسبق.

| الموصل | الصورة | عدد نقاط التعديل |
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

عدد ومعنى نقاط التعديل جزء من الإعداد المسبق المختار للموصل. لا تفترض أن نوعي موصل مختلفين يقدمان نفس تخطيط المجموعة.

## **ربط شكلين**

استخدم [IShapeCollection::AddConnector](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addconnector/) لإضافة موصل، واستدعِ [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) و[IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) لربط نهاياته. بعد ربط النهايتين، يختار [IConnector::Reroute](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iconnector/reroute/) مسارًا قصيرًا بين الشكلين.

المثال التالي يربط إهليلجًا ومستطيلًا بموصل منحني:

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
استدعاء `IConnector::Reroute` قد يغيّر قيمتي [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) و[IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/). عيّن مواقع الاتصال المحددة بعد إعادة التوجيه إذا كان يجب أن تظل تلك المواقع ثابتة.
{{% /alert %}}

## **اختيار موقع الاتصال**

كل شكل قابل للربط يُبلغ عن عدد المواقع عبر [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_connectionsitecount/). تحقق من صحة فهرس موقعٍ صفر‑مبني قبل تعيينه لنهاية الموصل؛ عدد المواقع يختلف حسب هندسة الشكل.

هذا المثال يربط الموصل بموقع محدد على الإهليلج عندما يكون ذلك الموقع موجودًا:

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

## **تعديل نقطة الموصل**

الموصلات التي تحتوي على نقاط تعديل تكشف عنها عبر [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igeometryshape/get_adjustments/). افحص كل [IAdjustValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/) وتحقق من [IAdjustValue::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/get_type/) قبل تغيير [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/set_rawvalue/). القواعد العامة لتحديد تعديلات الشكل المسبقة موثقة في [Shape Manipulation](/slides/ar/cpp/shape-manipulations/).

عدد وترتيب ومعنى ونطاق القيم الصالحة لتعديلات الموصل تعتمد على الإعداد المسبق للموصل. النوع الذي تُرجعه `IAdjustValue::get_Type` هو للقراءة فقط، بينما قيمة التعديل الخام قابلة للكتابة. طريقة القراءة فقط [IAdjustValue::get_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/get_name/) توفر تعريفًا إضافيًا عندما يحتوي الموصل على أكثر من تعديل من نفس النوع الدلالي.

### **توجيه حول عائق**

في التخطيط التالي، موصل `ShapeType::BentConnector5` بين شكلين يمر عبر شكل ثالث:

![connector-obstruction](connector-obstruction.png)

هذا الكود يُنشئ الموصل المعترض:

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

تحريك الانحناء العمودي يغيّر المسار بحيث يتجاوز الموصل العائق:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

بدلاً من افتراض أن الفهرس 1 في المجموعة يمثل دائمًا الانحناء العمودي، يبحث هذا المثال عن `ShapeAdjustmentType::ConnectorBendPositionY` ويغيّره فقط عندما يكون النوع الدلالي المتوقع موجودًا:

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

الموصل `ShapeType::BentConnector5` يحتوي على تعديلين من النوع `ShapeAdjustmentType::ConnectorBendPositionX` وتعديل واحد من النوع `ShapeAdjustmentType::ConnectorBendPositionY`. إذا ظهر النوع الذي تحتاجه أكثر من مرة، افحص `IAdjustValue::get_Name` والهندسة المعروفة لذلك الإعداد قبل اختيار أحدهما. إذا أبلغ تعديل عن `ShapeAdjustmentType::Custom`، فاعتبر معناه ونطاقه خاصًا بالإعداد المسبق ولا تُغيّره إلا إذا كان العقد معروفًا.

## **ربط قيم التعديل بهندسة الموصل**

بالنسبة للموصلات المنحنية، يمكن استخدام قيم التعديل لتقدير مواضع القطاعات الفردية. هذه الحسابات خاصة بإعداد الموصل:

- `ShapeType::BentConnector4` عادةً يكشف عن تعديل واحد من النوع `ShapeAdjustmentType::ConnectorBendPositionX` وتعديل واحد من النوع `ShapeAdjustmentType::ConnectorBendPositionY`.
- لهذه المواقع المنحنية، ينتج `RawValue / 100000.0f` كسر عرض أو ارتفاع إطار الموصل المستخدمة في الأمثلة أدناه.
- يمكن تدوير إطار الموصل أو عكسه، لذا يجب تحويل إحداثيات الإطار قبل مقارنتها بإحداثيات الشريحة.

الأمثلة التالية تستخدم `IAdjustValue::get_Type` لتحديد التعديلات أولاً. لا تتعامل مع فهارس المجموعة كمعرّفات محمولة.

### **موصل غير مدور**

التخطيط الأولي يحتوي على شكلين نصيين متصلين بموصل `ShapeType::BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

هذا المثال يفحص الموصل ويحصل على تعديلات الانحناء الأفقي والعمودي:

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

لتغيير الانحنائين، ابحث عن كل نوع متوقع وعدّل القيم فقط بعد العثور على كلاهما:

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

النتيجة هي موصل تحركت قطعه الأفقية والعمودية:

![connector-adjusted-1](connector-adjusted-1.png)

بمجرد معرفة الأنواع الدلالية، يمكن تحويل قيمها إلى إحداثيات إطار الموصل. هذا المثال يرسم مستطيلًا رقيقًا فوق القطعة العمودية التي يتحكم فيها تعديليا الانحناء:

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

الشكل الدليل يوضح القطعة المحسوبة:

![connector-adjusted-2](connector-adjusted-2.png)

### **موصل مدور أو مقلوب**

عند توجيه نفس هندسة الموصل عموديًا، تؤثر قيم [IShape::get_Frame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_frame/)، [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapeframe/get_fliph/)، و[IShapeFrame::get_FlipV](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapeframe/get_flipv/) على التحويل من إحداثيات إطار الموصل إلى إحداثيات الشريحة.

هذا المثال يُنشئ ويُعدل الموصل الموجه عموديًا:

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

الموصل المعدل يظهر عموديًا بين الشكلين:

![connector-adjusted-3](connector-adjusted-3.png)

لزاوية دوران عشوائية `alpha`، دوّر نقطة إطار الموصل `(x, y)` حول مركز الإطار `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

الكود التالي يتعامل مع التوجيه بزاوية 90 درجة المستخدم في هذا المثال ويرسم دليلًا أحمر فوق القطعة المقابلة للموصل:

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

الدليل الأحمر يوضح القطعة المحسوبة بعد تحويل الإحداثيات:

![connector-adjusted-4](connector-adjusted-4.png)

هذه الصيغ تصف الإعدادات المستخدمة في الأمثلة، ليست نموذجًا عالميًا للموصل. تحقق من أنواع التعديل، توجيه الإطار، ونطاقات القيم قبل تطبيق نفس الحساب على إعداد مختلف.

## **إيجاد زاوية اتجاه الموصل**

يمكن حساب اتجاه موصل مستقيم من عرضه وارتفاعه، مع تطبيق الانعكاسات الأفقية والعمودية. المثال التالي يُظهر الزاوية في اتجاه عقارب الساعة من المحور الأفقي الموجب في إحداثيات الشريحة:

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

## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان الموصل يمكنه الارتباط بشكل؟**

تحقق من قيمة `IShape::get_ConnectionSiteCount` للشكل. عدد موجب يعني أن الشكل يُظهر مواقع اتصال. تحقق من صحة فهرس الموقع المختار قبل تعيينه لأي طرف من أطراف الموصل.

**هل يمكنني تحديد تعديل الموصل بواسطة فهرس المجموعة؟**

الفهرس ذو معنى فقط لإعداد موصل معروف وتخطيط مجموعة معروف. افحص `IAdjustValue::get_Type` قبل تعديل قيمة، واستخدم `IAdjustValue::get_Name` كمعلومات إضافية عندما يتكرر نفس النوع الدلالي أكثر من مرة.

**ماذا يحدث عندما يُحذف الشكل المتصل؟**

تنقسم النهاية المقابلة للموصل. يظل الموصل على الشريحة ويمكن حذفه أو وضعه كخط حر أو ربطه بشكل آخر.

**هل تُحافظ روابط الموصل عند نسخ الشريحة؟**

تُحافظ الروابط عادةً عند نسخ الأشكال المتصلة مع الشريحة. إذا نُسخ موصل دون أحد الأشكال المستهدفة، يجب ربط الطرف المتأثر مرة أخرى.