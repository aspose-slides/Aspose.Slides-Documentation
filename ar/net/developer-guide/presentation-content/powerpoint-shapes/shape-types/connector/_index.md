---
title: موصل
type: docs
weight: 10
url: /ar/net/connector/
keywords: "ربط الأشكال, الموصلات, أشكال PowerPoint, عرض PowerPoint التقديمي, C#, Csharp, Aspose.Slides لـ .NET"
description: "ربط أشكال PowerPoint في C# أو .NET"
---

موصل PowerPoint هو خط خاص يربط أو يوصِل شكلين معًا ويظل ملتصقًا بالأشكال حتى عند تحريكها أو إعادة وضعها على الشريحة المحددة. 

عادةً ما يتم ربط الموصلات بـ *نقاط الاتصال* (النقاط الخضراء)، والتي توجد على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

*نقاط التعديل* (النقاط البرتقالية)، التي توجد فقط على بعض الموصلات، تُستخدم لتعديل مواضع وأشكال الموصلات.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام الموصلات المستقيمة، والموصلات الزاوية (المرفقة)، والموصلات المنحنية. 

يوفر Aspose.Slides هذه الموصلات:

| الموصل | الصورة | عدد نقاط التعديل |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
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

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع شريحة عبر مؤشرها.
1. إضافة شكلين [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة باستخدام الطريقة `AddAutoShape` المتاحة في كائن `Shapes`.
1. إضافة موصل باستخدام الطريقة `AddConnector` المتاحة في كائن `Shapes` مع تحديد نوع الموصل.
1. ربط الأشكال باستخدام الموصل.
1. استدعاء الطريقة `Reroute` لتطبيق أقصر مسار اتصال.
1. حفظ العرض التقديمي. 

هذا الكود C# يوضح كيفية إضافة موصل (موصل معقوف) بين شكلين (دائرة ومستطيل):
```c#
// ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف PPTX
using (Presentation input = new Presentation())
{                
    // الوصول إلى مجموعة الأشكال لشريحة معينة
    IShapeCollection shapes = input.Slides[0].Shapes;

    // يضيف شكلًا آليًا على شكل إهليلج
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // يضيف شكلًا آليًا على شكل مستطيل
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // يربط الأشكال باستخدام الموصل
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // ينفذ الدالة Reroute التي تحدد أقصر مسار تلقائي بين الأشكال
    connector.Reroute();

    // يحفظ العرض التقديمي
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
طريقة `Connector.Reroute` تُعيد توجيه الموصل وتجعله يسلك أقصر مسار ممكن بين الأشكال. لتحقيق هدفها، قد تقوم الطريقة بتغيير نقاط `StartShapeConnectionSiteIndex` و `EndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **تحديد نقطة الاتصال**

إذا كنت تريد أن يربط موصل شكلين باستخدام نقاط محددة على الأشكال، عليك تحديد نقاط الاتصال المفضلة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع شريحة عبر مؤشرها.
1. إضافة شكلين [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة باستخدام الطريقة `AddAutoShape` المتاحة في كائن `Shapes`.
1. إضافة موصل باستخدام الطريقة `AddConnector` المتاحة في كائن `Shapes` مع تحديد نوع الموصل.
1. ربط الأشكال باستخدام الموصل. 
1. تحديد نقاط الاتصال المفضلة على الأشكال. 
1. حفظ العرض التقديمي.

هذا الكود C# يوضح عملية تحديد نقطة اتصال مفضلة:
```c#
// ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // الوصول إلى مجموعة الأشكال لشريحة معينة
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // يضيف شكلًا آليًا على شكل إهليلج
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // يضيف شكلًا آليًا على شكل مستطيل
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // يربط الأشكال باستخدام الموصل
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // يضبط مؤشر نقطة الاتصال المفضلة على شكل الإهليلج
    uint wantedIndex = 6;

    // يتحقق مما إذا كان المؤشر المفضل أصغر من عدد مواقع الاتصال الأقصى
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // يضبط نقطة الاتصال المفضلة على الشكل الآلي الإهليلجي
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // يحفظ العرض التقديمي
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **ضبط نقطة الموصل**

يمكنك ضبط موصل موجود عبر نقاط التعديل الخاصة به. فقط الموصلات التي تحتوي على نقاط تعديل يمكن تعديلها بهذه الطريقة. راجع الجدول تحت **[أنواع الموصلات](/slides/ar/net/connector/#types-of-connectors)**.

#### **حالة بسيطة**

اعتبر حالة يكون فيها موصل بين شكلين (A و B) يمر عبر شكل ثالث (C):

![connector-obstruction](connector-obstruction.png)

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


لتجنب أو تجاوز الشكل الثالث، يمكننا ضبط الموصل بنقل خطه العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **حالات معقدة**

لإجراء تعديلات أكثر تعقيدًا، عليك مراعاة الأمور التالية:

* نقطة تعديل الموصل مرتبطة ارتباطًا وثيقًا بمعادلة تحسب وتحدد موقعها. لذلك قد تؤدي تغييرات موقع النقطة إلى تغيير شكل الموصل.
* تُعرَّف نقاط تعديل الموصل بترتيب صارم في مصفوفة. تُرقم نقاط التعديل من نقطة بداية الموصل إلى نهايته.
* قيم نقاط التعديل تعكس النسبة المئوية لعرض/ارتفاع شكل الموصل. 
  * الشكل محدود بنقاط بداية ونهاية الموصل مضروبة في 1000. 
  * النقطة الأولى والثانية والثالثة تحدد النسبة من العرض، والنسبة من الارتفاع، والنسبة من العرض مرة أخرى على التوالي.
* لحساب إحداثيات نقاط تعديل الموصل، يجب أخذ دوران الموصل وانعكاسه في الاعتبار. **Note** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/ar/net/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

اعتبر حالة يتم فيها ربط كائنين لإطار نصي عبر موصل:

![connector-shape-complex](connector-shape-complex.png)

```c#
// ينشئ كائن من فئة العرض التقديمي التي تمثل ملف PPTX
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
// يحدد سمك خط الموصل
connector.LineFormat.Width = 3;

// يربط الأشكال معًا باستخدام الموصل
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// يحصل على نقاط الضبط للموصل
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**ضبط**

يمكننا تغيير قيم نقاط تعديل الموصل بزيادة النسبة المئوية للعرض والارتفاع المقابلين بنسبة 20٪ و200٪ على التوالي:
```c#
// يغير قيم نقاط الضبط
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يسمح لنا بتحديد إحداثيات وشكل الأجزاء الفردية للموصل، لنقم بإنشاء شكل يطابق المكوّن الأفقي للموصل عند نقطة `connector.Adjustments[0]`:
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

في **الحالة 1**، عرضنا عملية ضبط موصل بسيطة باستخدام مبادئ أساسية. في الحالات العادية، عليك مراعاة دوران الموصل وعرضه (المحددين عبر `connector.Rotation`، `connector.Frame.FlipH`، و `connector.Frame.FlipV`). سنعرض العملية الآن.

أولاً، لنضيف كائن إطار نصي جديد (**To 1**) إلى الشريحة (لغرض الاتصال) وننشئ موصلًا (أخضر) جديدًا يربطه بالكائنات التي أنشأناها مسبقًا.
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
// يربط الكائنات باستخدام الموصل المنشأ حديثًا
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// يحصل على نقاط ضبط الموصل
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// يغيّر قيم نقاط الضبط 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، لننشئ شكلًا يطابق المكوّن الأفقي للموصل الذي يمر عبر نقطة التعديل الجديدة `connector.Adjustments[0]`. سنستخدم القيم من بيانات الموصل لـ `connector.Rotation`، `connector.Frame.FlipH`، و `connector.Frame.FlipV` وسنطبق صيغة تحويل الإحداثيات الشهيرة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن 90 درجة والموصل معروض عموديًا، لذا الكود المقابل هو:
```c#
// يحفظ إحداثيات الموصل
x = connector.X;
y = connector.Y;
// يصَحح إحداثيات الموصل في حال ظهورها
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// يأخذ قيمة نقطة الضبط كإحداثي
x += connector.Width * adjValue_0.RawValue / 100000;
//  يحوّل الإحداثيات لأن Sin(90) = 1 و Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// يحدّد عرض المكوّن الأفقي باستخدام قيمة نقطة الضبط الثانية
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```


النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد عرضنا حسابات تتضمن تعديلات بسيطة ونقاط تعديل معقدة (نقاط تعديل مع زوايا دوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى ضبط قيم نقاط تعديل الموصل بناءً على إحداثيات شريحة محددة.

## **العثور على زاوية خطوط الموصل**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. الحصول على مرجع شريحة عبر مؤشرها.
1. الوصول إلى شكل خط الموصل. 
1. استخدام عرض الخط وارتفاعه وارتفاع إطار الشكل وعرضه لحساب الزاوية.

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


## **FAQ**

**كيف يمكنني معرفة ما إذا كان يمكن "لصق" موصل إلى شكل معين؟**

تحقق من أن الشكل يكشف عن [نقاط الاتصال](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/). إذا لم يكن هناك أي منها أو كان العدد صفرًا، فإن اللصق غير متاح؛ في هذه الحالة، استخدم نقاط نهاية حرة وضعها يدويًا. من الحكمة فحص عدد المواقع قبل الإرفاق.

**ماذا يحدث للموصل إذا قمت بحذف أحد الأشكال المتصلة؟**

ستنفصل نهاياته؛ يبقى الموصل على الشريحة كخط عادي بنقطة بداية/نهاية حرة. يمكنك إما حذفه أو إعادة تعيين الاتصالات، وإذا لزم الأمر، استخدام [reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/).

**هل يتم الحفاظ على ربط الموصلات عند نسخ شريحة إلى عرض تقديمي آخر؟**

عمومًا نعم، بشرط نسخ الأشكال المستهدفة أيضًا. إذا أُدرجت الشريحة في ملف آخر بدون الأشكال المتصلة، تصبح النهايات حرة وستحتاج إلى إعادة إرفاقها.