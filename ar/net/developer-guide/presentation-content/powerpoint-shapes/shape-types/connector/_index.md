---
title: الموصل
type: docs
weight: 10
url: /net/connector/
keywords: "ربط الأشكال، الموصلات، أشكال PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "ربط أشكال PowerPoint في C# أو .NET"
---

موصل PowerPoint هو خط خاص يربط شكلين معًا ويظل متصلًا بالأشكال حتى عند تحريكها أو إعادة وضعها على شريحة معينة.

عادةً ما تكون الموصلات متصلة بـ *نقاط الاتصال* (نقاط خضراء) التي توجد على جميع الأشكال افتراضيًا. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

تستخدم *نقاط التعديل* (نقاط برتقالية)، التي توجد فقط على موصلات معينة، لتعديل مواضع وأشكال الموصلات.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام موصلات مستقيمة، وزاوية (مائلة)، ومنحنية.

تقدم Aspose.Slides هذه الموصلات:

| الموصل                            | الصورة                                                       | عدد نقاط التعديل |
| ---------------------------------- | ---------------------------------------------------------- | ----------------- |
| `ShapeType.Line`                  | ![shapetype-lineconnector](shapetype-lineconnector.png)    | 0                 |
| `ShapeType.StraightConnector1`    | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                 |
| `ShapeType.BentConnector2`        | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0                 |
| `ShapeType.BentConnector3`        | ![shapetype-bentconnector3](shapetype-bentconnector3.png)  | 1                 |
| `ShapeType.BentConnector4`        | ![shapetype-bentconnector4](shapetype-bentconnector4.png)  | 2                 |
| `ShapeType.BentConnector5`        | ![shapetype-bentconnector5](shapetype-bentconnector5.png)  | 3                 |
| `ShapeType.CurvedConnector2`      | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                 |
| `ShapeType.CurvedConnector3`      | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                 |
| `ShapeType.CurvedConnector4`      | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                 |
| `ShapeType.CurvedConnector5`      | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                 |

## **ربط الأشكال باستخدام الموصلات**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `AddAutoShape` المعلنة بواسطة كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `AddConnector` المعلنة بواسطة كائن `Shapes` من خلال تحديد نوع الموصل.
1. ربط الأشكال باستخدام الموصل.
1. استدعِ طريقة `Reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي.

هذا الكود C# يوضح لك كيفية إضافة موصل (موصل معقوق) بين شكلين (بيضاوي ومستطيل):

```c#
// ينشئ مثيلًا من فئة العرض التقديمي التي تمثل ملف PPTX
using (Presentation input = new Presentation())
{                
    // يصل إلى مجموعة الأشكال لشريحة معينة
    IShapeCollection shapes = input.Slides[0].Shapes;

    // يضيف شكل بيضاوي
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // يضيف شكل مستطيل
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // يربط الأشكال باستخدام الموصل
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // يستدعي إعادة التوجيه التي تضبط المسار التلقائي الأقصر بين الأشكال
    connector.Reroute();

    // يحفظ العرض التقديمي
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="ملاحظة"  color="warning"   %}} 

تقوم طريقة `Connector.Reroute` بإعادة توجيه الموصل وتفرض عليه أن يأخذ أقصر مسار ممكن بين الأشكال. لتحقيق هدفها، قد تقوم الطريقة بتغيير نقاط `StartShapeConnectionSiteIndex` و`EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **تحديد نقطة الاتصال**
إذا كنت ترغب في ربط موصل بين شكلين باستخدام نقاط محددة على الأشكال، عليك تحديد نقاط الاتصال المفضلة لديك بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `AddAutoShape` المعلنة بواسطة كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `AddConnector` المعلنة بواسطة كائن `Shapes` عبر تحديد نوع الموصل.
1. ربط الأشكال باستخدام الموصل.
1. حدد نقاط الاتصال المفضلة لديك على الأشكال.
1. احفظ العرض التقديمي.

هذا الكود C# يوضح عملية حيث يتم تحديد نقطة الاتصال المفضلة:

```c#
// ينشئ مثيلًا من فئة العرض التقديمي التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يصل إلى مجموعة الأشكال لشريحة معينة
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // يضيف شكل بيضاوي
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // يضيف شكل مستطيل
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // يربط الأشكال باستخدام الموصل
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // يحدد مؤشر نقطة الاتصال المفضلة على الشكل البيضاوي
    uint wantedIndex = 6;

    // يتحقق مما إذا كان المؤشر المفضل أقل من الحد الأقصى لعدد مواقع الاتصال
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // يشترط النقطة المفضلة على الشكل البيضاوي
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // يحفظ العرض التقديمي
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **تعديل نقطة الموصل**

يمكنك تعديل موصل موجود من خلال نقاط التعديل الخاصة به. فقط الموصلات ذات نقاط التعديل يمكن تعديلها بهذه الطريقة. انظر الجدول تحت **[أنواع الموصلات.](/slides/net/connector/#types-of-connectors)** 

#### **حالة بسيطة**

افترض حالة حيث يمر موصل بين شكلين (A و B) عبر شكل ثالث (C):

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

لتجنب أو تجاوز الشكل الثالث، يمكننا تعديل الموصل عن طريق تحريك خطه العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، عليك أن تأخذ هذه الأمور في الاعتبار:

* نقطة تعديل الموصل مرتبطة ارتباطًا وثيقًا بصيغة تحسب وتحدد موضعها. لذا قد تؤدي التغييرات على موقع النقطة إلى تغيير شكل الموصل.
* يتم تعريف نقاط تعديل الموصل بترتيب صارم في مصفوفة. يتم ترقيم نقاط التعديل من نقطة بداية الموصل إلى نقطة نهايته.
* تعكس قيم نقطة التعديل نسبة عرض/ارتفاع شكل الموصل. 
  * الشكل مقيد بواسطة نقاط بداية ونهاية الموصل مضروبة في 1000. 
  * النقطة الأولى، النقطة الثانية، والنقطة الثالثة تحدد النسبة من العرض، النسبة من الارتفاع، والنسبة من العرض (مرة أخرى) على التوالي.
* لحسابات تحدد إحداثيات نقاط تعديل الموصل، يجب أن تأخذ في الاعتبار دوران الموصل وانعكاسه. **ملاحظات** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/net/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

افترض حالة حيث يتم ربط كائنين إطار نص معًا من خلال موصل:

![connector-shape-complex](connector-shape-complex.png)

الكود:

```c#
// ينشئ مثيلًا من فئة العرض التقديمي التي تمثل ملف PPTX
Presentation pres = new Presentation();
// يحصل على الشريحة الأولى في العرض التقديمي
ISlide sld = pres.Slides[0];
// يضيف أشكالًا سيتم ربطها معًا من خلال موصل
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "من";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "إلى";
// يضيف موصل
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

// يحصل على نقاط التعديل للموصل
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**التعديل**

يمكننا تغيير قيم نقاط تعديل الموصل عن طريق زيادة نسبة العرض والارتفاع المقابلة بنسبة 20% و200% على التوالي:

```c#
// يغير قيم نقاط التعديل
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتحديد نموذج يسمح لنا بتحديد إحداثيات وشكل أجزاء الموصل الفردية، دعنا ننشئ شكلًا يتوافق مع المكون الأفقي للموصل عند النقطة connector.Adjustments[0]:

```c#
// رسم المكون العمودي للموصل

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، أظهرنا عملية تعديل موصل بسيطة باستخدام مبادئ أساسية. في الظروف العادية، يتعين عليك أخذ دوران الموصل وعرضه (الذي يتم تعيينه بواسطة connector.Rotation وconnector.Frame.FlipH وconnector.Frame.FlipV) في الاعتبار. سنوضح الآن العملية.

أولاً، دعنا نضيف كائن إطار نص جديد (**إلى 1**) إلى الشريحة (لأغراض الاتصال) وننشئ موصلًا جديدًا (أخضر) يربطه بالأشياء التي أنشأناها بالفعل.

```c#
// ينشئ كائن ربط جديد
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "إلى 1";
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
// يحصل على نقاط تعديل الموصل
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// يغير قيم نقاط التعديل 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، دعنا ننشئ شكلًا يتوافق مع المكون الأفقي للموصل الذي يمر عبر نقطة تعديل الموصل الجديدة connector.Adjustments[0]. سنستخدم القيم من بيانات الموصل الخاصة بـ connector.Rotation وconnector.Frame.FlipH وconnector.Frame.FlipV ونطبق صيغة تحويل الإحداثيات الشهيرة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل معروض عموديًا، لذلك هذا هو الكود المقابل:

```c#
// يحفظ إحداثيات الموصل
x = connector.X;
y = connector.Y;
// يصحح إحداثيات الموصل في حال ظهوره
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// يأخذ في قيمة نقطة التعديل كإحداثيات
x += connector.Width * adjValue_0.RawValue / 100000;
//  يحول الإحداثيات نظرًا لأن Sin(90) = 1 وCos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// يحدد عرض المكون الأفقي باستخدام قيمة نقطة التعديل الثانية
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد أوضحنا الحسابات المتعلقة بالتعديلات البسيطة ونقاط التعديل المعقدة (نقاط التعديل مع زوايا الدوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى تعيين قيم نقاط تعديل الموصل استنادًا إلى إحداثيات شريحة محددة.

## **العثور على زاوية خطوط الموصل**
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. قم بالوصول إلى شكل خط الموصل. 
1. استخدم عرض الخط وارتفاعه وارتفاع إطار الشكل وعرض إطار الشكل لحساب الزاوية.

هذا الكود C# يظهر عملية حيث قمنا بحساب الزاوية لشكل خط موصل:

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