---
title: إدارة الموصلات في العروض التقديمية باستخدام .NET
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
- ربط الأشكال
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تمكين تطبيقات .NET من رسم وربط وتوجيه الخطوط تلقائيًا في شرائح PowerPoint—احصل على تحكم كامل في الموصلات المستقيمة والمرفقة والمنحنية."
---

موصل PowerPoint هو خط خاص يربط أو يربط بين شكلين مع البقاء ملتصقًا بالشكلين حتى عند تحريكهما أو إعادة وضعهما على الشريحة المحددة.

عادةً ما يتم ربط الموصلات بنقاط **الاتصال** (النقاط الخضراء) التي توجد على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

نقاط **الضبط** (النقاط البرتقالية) التي توجد فقط على بعض الموصلات تُستخدم لتعديل موضع وشكل الموصلات.

## **أنواع الموصلات**

في PowerPoint يمكنك استخدام موصلات مستقيمة، زاوية (مرفقة)، ومنحنية.

توفر Aspose.Slides هذه الموصلات:

| موصل | صورة | عدد نقاط الضبط |
| ---- | ---- | --------------- |
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

## **ربط الأشكال باستخدام الموصلات**

1. أنشئ مثيلًا من فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة عبر الفهرس الخاص بها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `AddAutoShape` المتاحة عبر كائن `Shapes`.
1. أضف موصلاً باستخدام طريقة `AddConnector` المتاحة عبر كائن `Shapes` مع تحديد نوع الموصل.
1. اربط الأشكال باستخدام الموصل.
1. استدعِ طريقة `Reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي.

هذا الكود بلغة C# يوضح كيفية إضافة موصل (موصل منحني) بين شكلين (إهليلج ومستطيل):
```c#
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
using (Presentation input = new Presentation())
{                
    // الوصول إلى مجموعة الأشكال لشريحة محددة
    IShapeCollection shapes = input.Slides[0].Shapes;

    // إضافة شكل أوتوشيب إهليلج
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // إضافة شكل أوتوشيب مستطيل
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // إضافة شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // ربط الأشكال باستخدام الموصل
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // استدعاء Reroute الذي يحدد أقصر مسار تلقائي بين الأشكال
    connector.Reroute();

    // حفظ العرض التقديمي
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

طريقة `Connector.Reroute` تعيد توجيه الموصل وتُجبره على أخذ أقصر مسار ممكن بين الأشكال. لتحقيق ذلك، قد تقوم الطريقة بتغيير نقاط `StartShapeConnectionSiteIndex` و`EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **تحديد نقطة اتصال**

إذا أردت أن يربط الموصل شكلين باستخدام نقاط معينة على الأشكال، عليك تحديد نقاط الاتصال المفضلة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة عبر الفهرس الخاص بها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `AddAutoShape` المتاحة عبر كائن `Shapes`.
1. أضف موصلاً باستخدام طريقة `AddConnector` المتاحة عبر كائن `Shapes` مع تحديد نوع الموصل.
1. اربط الأشكال باستخدام الموصل.
1. عيّن نقاط الاتصال المفضلة على الأشكال.
1. احفظ العرض التقديمي.

هذا الكود بلغة C# يوضح عملية تحديد نقطة اتصال مفضلة:
```c#
// يَنشئ فئة عرض تقديمي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // الوصول إلى مجموعة الأشكال لشريحة محددة
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // إضافة شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // إضافة شكل أوتوشيب إهليلج
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // إضافة شكل أوتوشيب مستطيل
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // ربط الأشكال باستخدام الموصل
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // تحديد فهرس نقطة الاتصال المفضلة على شكل الإهليلج
    uint wantedIndex = 6;

    // التحقق مما إذا كان الفهرس المفضل أقل من عدد مواقع الاتصال الأقصى
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // ضبط نقطة الاتصال المفضلة على شكل الإهليلج
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // حفظ العرض التقديمي
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **ضبط نقطة الموصل**

يمكنك ضبط موصل موجود عبر نقاط الضبط الخاصة به. فقط الموصلات التي تحتوي على نقاط ضبط يمكن تعديلها بهذه الطريقة. انظر الجدول تحت **[أنواع الموصلات](/slides/ar/net/connector/#types-of-connectors)**.

### **حالة بسيطة**

تخيل حالة يمر فيها موصل بين شكلين (A و B) عبر شكل ثالث (C):

![connector-obstruction](connector-obstruction.png)

الكود:
```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```


لتجنب أو تجاوز الشكل الثالث، يمكننا ضبط الموصل بنقل خطه العمودي إلى اليسار هكذا:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، يجب مراعاة ما يلي:

* نقطة الضبط للموصل مرتبطة ارتباطًا وثيقًا بصيغة تحسب وتحدد موقعها. لذلك قد تغير تغيير موقع النقطة شكل الموصل.
* نقاط الضبط للموصل معرفة بترتيب صارم في مصفوفة. تُرقم نقاط الضبط من نقطة بدء الموصل إلى نهايته.
* قيم نقاط الضبط تعكس النسبة المئوية لعرض/ارتفاع شكل الموصل.  
  * الشكل محدود بنقطة بدء الموصل ونقطة نهايته مضروبة في 1000.  
  * النقطة الأولى، الثانية، والثالثة تمثل النسبة من العرض، النسبة من الارتفاع، والنسبة من العرض مرة أخرى على التوالي.
* عند حساب إحداثيات نقاط ضبط الموصل، يجب أخذ دوران الموصل وانعكاسه في الاعتبار. **ملاحظة** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/ar/net/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

تخيل حالة يتم فيها ربط كائنين من إطارات النص معًا عبر موصل:

![connector-shape-complex](connector-shape-complex.png)

الكود:
```c#
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
// يحصل على الشريحة الأولى في العرض التقديمي
ISlide sld = pres.Slides[0];
// يضيف أشكالًا سيتم ربطها معًا عبر موصل
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// يضيف موصلًا
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// يحدد اتجاه الموصل
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// يحدد لون الموصل
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// يحدد سماكة خط الموصل
connector.LineFormat.Width = 3;

// يرتبط الأشكال معًا باستخدام الموصل
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// يحصل على نقاط الضبط للموصل
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**الضبط**

يمكننا تغيير قيم نقاط ضبط الموصل بزيادة النسبة المئوية للعرض والارتفاع المقابلة بـ20% و200% على التوالي:
```c#
// يغيّر قيم نقاط الضبط
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يسمح لنا بتحديد إحداثيات وشكل الأجزاء الفردية للموصل، لننشئ شكلاً يتطابق مع المكوّن الأفقي للموصل عند النقطة `connector.Adjustments[0]`:
```c#
// ارسم المكوّن العمودي للموصل
float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، عرضنا عملية ضبط موصل بسيط باستخدام مبادئ أساسية. في الحالات العادية، يجب أخذ دوران الموصل وعرضه (المحدّدين بـ `connector.Rotation`، `connector.Frame.FlipH`، و`connector.Frame.FlipV`) في الاعتبار. سنوضح الآن العملية.

أولاً، أضف كائن إطار نص جديد (**To 1**) إلى الشريحة (لأغراض الاتصال) وأنشئ موصلاً (أخضر) يربطه بالكائنات التي أنشأناها مسبقًا.
```c#
// ينشئ كائن ربط جديد
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// ينشئ موصلًا جديدًا
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// يربط الكائنات باستخدام الموصل الذي تم إنشاؤه حديثًا
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// يحصل على نقاط الضبط للموصل
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// يغيّر قيم نقاط الضبط
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، أنشئ شكلاً سيتطابق مع المكوّن الأفقي للموصل الذي يمر عبر نقطة الضبط الجديدة `connector.Adjustments[0]`. سنستخدم القيم من بيانات الموصل لـ `connector.Rotation`، `connector.Frame.FlipH`، و`connector.Frame.FlipV` ونطبق صيغة تحويل الإحداثيات الشهيرة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل معروض عموديًا، لذا يكون الكود المقابل:
```c#
// يحفظ إحداثيات الموصل
x = connector.X;
y = connector.Y;
// يصحح إحداثيات الموصل إذا ظهر
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// يُدخل قيمة نقطة الضبط كإحداثي
x += connector.Width * adjValue_0.RawValue / 100000;
//  يحول الإحداثيات لأن Sin(90) = 1 و Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// يحدد عرض المكوّن الأفقي باستخدام قيمة نقطة الضبط الثانية
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```


النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد عرضنا حسابات تشمل ضبطًا بسيطًا ونقاط ضبط معقدة (نقاط ضبط مع زوايا دوران). باستخدام المعرفة التي اكتسبتها، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى ضبط قيم نقطة ضبط الموصل بناءً على إحداثيات شريحة محددة.

## **إيجاد زاوية خطوط الموصل**

1. أنشئ مثيلًا من فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة عبر الفهرس الخاص بها.
1. وصول إلى شكل خط الموصل.
1. استخدم عرض الخط، ارتفاعه، ارتفاع إطار الشكل، وعرض إطار الشكل لحساب الزاوية.

هذا الكود بلغة C# يوضح عملية حساب زاوية شكل خط الموصل:
```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان يمكن "لصق" موصل على شكل معين؟**

تأكد من أن الشكل يُظهر [مواقع الاتصال](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/). إذا لم يكن هناك أي موقع أو كان العدد صفرًا، فإن اللصق غير متاح؛ في هذه الحالة استخدم نقاط النهاية الحرة وضعها يدويًا. من المنطقي فحص عدد المواقع قبل الإرفاق.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المرتبطة؟**

ستنفصل نهاياته؛ يبقى الموصل على الشريحة كخط عادي بنقطة بداية/نهاية حرة. يمكنك إما حذفه أو إعادة تعيين الاتصالات، وإذا لزم الأمر، استخدم [Reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/).

**هل يتم الحفاظ على ارتباطات الموصل عند نسخ شريحة إلى عرض تقديمي آخر؟**

عادةً نعم، بشرط أن تُنسخ الأشكال المستهدفة أيضًا. إذا تم إدراج الشريحة في ملف آخر دون الأشكال المرتبطة، تصبح النهايات حرة وستحتاج إلى إرفاقها مرة أخرى.