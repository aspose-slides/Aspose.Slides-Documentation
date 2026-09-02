---
title: إدارة الموصلات في العروض التقديمية في .NET
linktitle: موصل
type: docs
weight: 10
url: /ar/net/connector/
keywords:
- موصل
- نوع الموصل
- نقطة الموصل
- خط الموصل
- زاوية الموصل
- موقع الاتصال
- نقطة الضبط
- ربط الأشكال
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة، ربط، إعادة توجيه، ضبط، وفحص الموصلات المستقيمة، المكسورة، والمنحنية في PowerPoint باستخدام Aspose.Slides ل .NET."
---
## **نظرة عامة**

الموصل هو خط يمكن أن يبقى مرتبطًا بشكليْن عندما يتحرك أي منهما. تتصل نهايته بمواقع الاتصال، التي تُمثَّل بنقاط خضراء في PowerPoint. بعض الموصلات المكسورة والمنحنية تكشف أيضًا عن نقاط ضبط، تُمثَّل بنقاط برتقالية، تتحكم في موضع أجزاء الموصل الفردية.

Aspose.Slides تمثِّل الموصلات عبر واجهة [IConnector](https://reference.aspose.com/slides/ar/net/aspose.slides/iconnector/) . يمكنك إنشاءها، ربط نهاياتها بالأشكال، اختيار مواقع الاتصال، إعادة توجيهها، وتعديل هندسة الموصلات التي تحتوي على نقاط ضبط.

## **أنواع الموصلات**

التعداد [ShapeType](https://reference.aspose.com/slides/ar/net/aspose.slides/shapetype/) يتضمن إعدادات مسبقة للموصلات المستقيمة، المكسورة، والمنحنية. يظهر الجدول التالي الهندسات المتاحة للموصلات وعدد نقاط الضبط التي يعرّفها كل إعداد مسبق.

| الموصل | صورة | عدد نقاط الضبط |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

عدد ومعنى نقاط الضبط جزء من الإعداد المسبق للموصل المحدد. لا تفترض أن نوعي موصل مختلفين يقدمان نفس تخطيط المجموعة.

## **ربط شكلين**

استخدم [IShapeCollection.AddConnector](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addconnector/) لإضافة موصل، ثم عيّن خصائص [StartShapeConnectedTo](https://reference.aspose.com/slides/ar/net/aspose.slides/connector/startshapeconnectedto/) و [EndShapeConnectedTo](https://reference.aspose.com/slides/ar/net/aspose.slides/connector/endshapeconnectedto/). بعد ربط الطرفين، يختار [IConnector.Reroute](https://reference.aspose.com/slides/ar/net/aspose.slides/iconnector/reroute/) مسارًا قصيرًا بين الشكلين.

المثال التالي يربط قطعًا بيضاويًا ومربعًا بموصل مكسور:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="تحذير" %}}
استدعاء `Reroute` قد يغيّر قيمتي [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/net/aspose.slides/connector/startshapeconnectionsiteindex/) و [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/net/aspose.slides/connector/endshapeconnectionsiteindex/). عيّن مواقع اتصال معينة بعد إعادة التوجيه إذا كان يجب أن تبقى هذه المواقع ثابتة.
{{% /alert %}}

## **اختيار موقع الاتصال**

كل شكل يمكن ربطه يُعيد عدد المواقع عبر الخاصية [ConnectionSiteCount](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/connectionsitecount/). تحقق من فهرس موقع صفر‑قاعدة مفضَّل قبل تعيينه إلى طرف الموصل؛ عدد المواقع يختلف حسب هندسة الشكل.

هذا المثال يربط الموصل بموقع محدد على القطع البيضاوي إذا كان ذلك الموقع موجودًا:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **ضبط نقطة الموصل**

الموصلات التي تحتوي على نقاط ضبط تُظهرها الخاصية [IGeometryShape.Adjustments](https://reference.aspose.com/slides/ar/net/aspose.slides/igeometryshape/adjustments/). افحص كل [IAdjustValue](https://reference.aspose.com/slides/ar/net/aspose.slides/iadjustvalue/) وتحقق من خاصية [Type](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/type/) قبل تغيير خاصية [RawValue](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/rawvalue/). القواعد العامة لتحديد الضبط المسبق للأشكال موصوفة في [Shape Manipulation](/slides/ar/net/shape-manipulations/).

عدد وترتيب ومعنى ونطاق القيم الصالحة لضبط الموصل يعتمد على الإعداد المسبق للموصل. خاصية `Type` للقراءة فقط، بينما قيمة الضبط قابلة للكتابة. خاصية [Name](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/name/) للقراءة فقط توفر تعريفًا إضافيًا عندما يحتوي الموصل على أكثر من ضبط من نفس النوع الدلالي.

### **التحرك حول عائق**

في المخطط التالي، موصل `BentConnector5` بين شكلين يمر عبر شكل ثالث:

![connector-obstruction](connector-obstruction.png)

هذا الشفر يُنشئ الموصل المتعرّض للعائق:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

تحريك الانحناء العمودي يغيّر المسار بحيث يتجاوز الموصل العائق:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

بدلاً من افتراض أن فهرس المجموعة `1` يمثل دائمًا الانحناء العمودي، يبحث هذا المثال عن `ConnectorBendPositionY` ويغيّره فقط عندما يكون النوع الدلالي المتوقع موجودًا:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

الموصل `BentConnector5` يحتوي على تعديلين `ConnectorBendPositionX` وتعديل واحد `ConnectorBendPositionY`. إذا تكرّر النوع الذي تحتاجه أكثر من مرة، افحص `Name` والهندسة المعروفة لذلك الإعداد قبل اختيار أحدهما. إذا أبلغ ضبط ما أن نوعه هو `ShapeAdjustmentType.Custom`، فاعتبر معناه ونطاقه خاصًا بالإعداد ولا تقم بتغييره حتى يصبح العقد معروفًا.

## **ربط قيم الضبط بهندسة الموصل**

بالنسبة للموصلات المكسورة، يمكن استخدام قيم الضبط لتقدير مواقع الأجزاء الفردية. هذه الحسابات خاصة بإعداد الموصل:

- `BentConnector4` عادةً يكشف عن تعديل واحد `ConnectorBendPositionX` وآخر `ConnectorBendPositionY`.
- لهذه المواضع، ينتج التعبير `RawValue / 100000f` الكسر من عرض أو ارتفاع إطار الموصل المستخدم في الأمثلة أدناه.
- يمكن أن يُدوَّر أو يُقلب إطار الموصل، لذا يجب تحويل إحداثيات الإطار قبل مقارنتها بإحداثيات الشريحة.

الأمثلة التالية تستخدم `Type` لتحديد الضبط أولًا. لا تُعامل فهارس المجموعة كمُعرِّفات محمولة.

#### **موصل غير دوار**

المخطط الأولي يحتوي على شكلين نصيين متصلين بموصل `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

هذا المثال يفحص الموصل ويحصل على ضبط الانحناء الأفقي والعمودي:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

لتغيير الانحنائين، حدد كل نوع متوقع وعدل القيم فقط بعد العثور على كلاهما:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

النتيجة موصل يتحرك فيه الجزءان الأفقي والعمودي:

![connector-adjusted-1](connector-adjusted-1.png)

بمجرد معرفة الأنواع الدلالية، يمكن تحويل قيمها إلى إحداثيات إطار الموصل. يرسم هذا المثال مستطيلًا رفيعًا فوق الجزء العمودي المتحكم بهما:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

الشكل الدليل يوضح الجزء المُحسب:

![connector-adjusted-2](connector-adjusted-2.png)

#### **موصل دوار أو مقلوب**

عندما تُ oriented هندسة الموصل نفسها عموديًا، تؤثر قيم [Frame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/frame/)، [FlipH](https://reference.aspose.com/slides/ar/net/aspose.slides/shapeframe/fliph/)، و[FlipV](https://reference.aspose.com/slides/ar/net/aspose.slides/shapeframe/flipv/) على تحويل إحداثيات إطار الموصل إلى إحداثيات الشريحة.

هذا المثال يُنشئ ويضبط الموصل المُorient عموديًا:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

الموصل المعدل يظهر عموديًا بين الشكلين:

![connector-adjusted-3](connector-adjusted-3.png)

لزاوية دوران عشوائية `alpha`، قم بتدوير نقطة إطار الموصل `(x, y)` حول مركز الإطار `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

الكود التالي يتعامل مع الاتجاه بزاوية 90 درجة كما هو مستخدم في هذا المثال ويرسم دليلًا أحمر فوق الجزء المقابل من الموصل:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

الدليل الأحمر يوضح الجزء المُحسب بعد تحويل الإحداثيات:

![connector-adjusted-4](connector-adjusted-4.png)

هذه الصيغ تصف الإعدادات المستخدمة في الأمثلة، ليست نموذجًا عالميًا للموصلات. تحقق من أنواع الضبط، توجيه الإطار، ونطاق القيم قبل تطبيق نفس الحساب على إعداد مختلف.

## **إيجاد زاوية اتجاه الموصل**

يمكن حساب اتجاه موصل مستقيم من عرضه وارتفاعه، مع مراعاة الانعكاسات الأفقية والعمودية. المثال التالي يُعيد الزاوية في الاتجاه clockwise من المحور الأفقي الموجب في إحداثيات الشريحة:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان الموصل يمكنه الارتباط بشكل؟**  
تحقق من الخاصية `ConnectionSiteCount` للشكل. العدد الإيجابي يعني أن الشكل يوفّر مواقع اتصال. تحقق من فهرس الموقع المختار قبل تعيينه إلى أي طرف من الموصل.

**هل يمكنني التعرف على ضبط الموصل عبر فهرس مجموعته؟**  
الفهرس ذو معنى فقط لإعداد مسبق معروف للموصل وتخطيط مجموعةه. تحقق من `IAdjustValue.Type` قبل تعديل قيمة، واستخدم `IAdjustValue.Name` كمعلومات إضافية عندما يتكرر نفس النوع الدلالي أكثر من مرة.

**ماذا يحدث عندما يتم حذف الشكل المرتبط؟**  
ينفصل الطرف المقابل من الموصل. يبقى الموصل على الشريحة ويمكن حذفه، أو تحويله إلى خط حر، أو ربطه بشكل آخر.

**هل تُحافظ ربطات الموصل عند نسخ الشريحة؟**  
تُحفظ عادةً عندما تُنسخ الأشكال المرتبطة مع الشريحة. إذا تم نسخ موصل دون أحد الأشكال الهدف، يجب ربط الطرف المتأثر مرة أخرى.