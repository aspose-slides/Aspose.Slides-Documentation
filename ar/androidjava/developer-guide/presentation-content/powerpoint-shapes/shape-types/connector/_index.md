---
title: الموصل
type: docs
weight: 10
url: /ar/androidjava/connector/
keywords: "توصيل الأشكال، الموصلات، أشكال PowerPoint، عرض PowerPoint، Java، Aspose.Slides لـ Android عبر Java"
description: "توصيل أشكال PowerPoint بلغة Java"
---

موصل PowerPoint هو خط خاص يربط أو يوصل بين شكلين معًا ويبقى مرتبطًا بالأشكال حتى عند تحريكها أو إعادة وضعها على شريحة معينة.

عادةً ما تكون الموصلات متصلة بـ *نقاط الاتصال* (نقاط خضراء)، التي توجد على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عند اقتراب المؤشر منها.

يتم استخدام *نقاط الضبط* (نقاط برتقالية) الموجودة فقط على موصلات معينة لتعديل مواضع وأشكال الموصلات.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام الموصلات المستقيمة، الزاوية، والمنحنية.

توفر Aspose.Slides هذه الموصلات:

| الموصل                         | الصورة                                                       | عدد نقاط الضبط              |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **توصيل الأشكال باستخدام الموصلات**

1. قم بإنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) إلى الشريحة باستخدام طريقة `addAutoShape` المتاحة عبر كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `addConnector` المتاحة عبر كائن `Shapes` عن طريق تحديد نوع الموصل.
1. قم بتوصيل الأشكال باستخدام الموصل.
1. استدعاء طريقة `reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي.

هذا الكود بلغة Java يوضح لك كيفية إضافة موصل (موصل منحني) بين شكلين (بيضاوي ومستطيل):

```Java
// ينشئ مثيلاً لفئة العرض التقديمي التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى مجموعة الأشكال لشريحة معينة
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // إضافة شكل بيضاوي
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // إضافة شكل مستطيل
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // إضافة شكل موصل إلى مجموعة الأشكال في الشريحة
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // توصيل الأشكال باستخدام الموصل
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // استدعاء reroute الذي يحدد المسار التلقائي الأقصر بين الأشكال
    connector.reroute();
    
    // حفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="ملاحظة"  color="warning"   %}} 

تقوم طريقة `Connector.reroute` بإعادة توجيه موصل وتجبره على اتخاذ أقصر مسار ممكن بين الأشكال. لتحقيق هدفها، قد تقوم الطريقة بتغيير نقاط `setStartShapeConnectionSiteIndex` و `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **تحديد نقطة الاتصال**

إذا كنت تريد لموصل أن يربط بين شكلين باستخدام نقاط معينة على الأشكال، فعليك تحديد نقاط الاتصال المفضلة لديك بهذه الطريقة:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) إلى الشريحة باستخدام طريقة `addAutoShape` المتاحة عبر كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `addConnector` المتاحة عبر كائن `Shapes` عن طريق تحديد نوع الموصل.
1. قم بتوصيل الأشكال باستخدام الموصل.
1. قم بتعيين نقاط الاتصال المفضلة لديك على الأشكال. 
1. احفظ العرض التقديمي.

هذا الكود بلغة Java يظهر عملية يتم فيها تحديد نقطة اتصال مفضلة:

```java
// ينشئ مثيلاً لفئة العرض التقديمي التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى مجموعة الأشكال لشريحة معينة
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // إضافة شكل بيضاوي
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // إضافة شكل مستطيل
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // إضافة شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // توصيل الأشكال باستخدام الموصل
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // تعيين فهرس نقطة الاتصال المفضلة على شكل البيضاوي
    int wantedIndex = 6;

    // التحقق مما إذا كان الفهرس المفضل أقل من الحد الأقصى لعدد مواقع الاتصال
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // تعيين نقطة الاتصال المفضلة على شكل البيضاوي
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // حفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعديل نقطة الموصل**

يمكنك تعديل موصل موجود من خلال نقاط الضبط الخاصة به. يمكن تعديل الموصلات فقط التي تحتوي على نقاط ضبط بهذه الطريقة. راجع الجدول تحت **[أنواع الموصلات.](/slides/ar/androidjava/connector/#types-of-connectors)**

#### **حالة بسيطة**

اعتبر حالة يتم فيها توصيل موصل بين شكلين (أ و ب) ويمر عبر شكل ثالث (ج):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

لتجنب أو تجاوز الشكل الثالث، يمكننا تعديل الموصل عن طريق تحريك خطه الرأسي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، عليك أخذ هذه الأشياء بعين الاعتبار:

* نقطة ضبط الموصل مرتبطة بشكل قوي بمعادلة تحسب وتحدد موضعها. لذا قد تغير التغييرات في موقع النقطة شكل الموصل.
* تم تعريف نقاط ضبط الموصل في ترتيب صارم في مصفوفة. يتم ترقيم نقاط الضبط من نقطة بداية الموصل إلى نقطة نهايته.
* تعكس قيم نقطة الضبط نسبة عرض/ارتفاع شكل الموصل. 
  * الشكل محدود بنقاط بداية ونهاية الموصل مضروبة في 1000. 
  * تشير النقطة الأولى، النقطة الثانية، والنقطة الثالثة إلى النسبة من العرض، النسبة من الارتفاع، والنسبة من العرض (مرة أخرى) على التوالي.
* لحسابات تحديد إحداثيات نقاط ضبط موصل، يجب أن تأخذ في الاعتبار دوران الموصل وانعكاسه. **ملاحظة** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/ar/androidjava/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

اعتبر حالة يتم فيها ربط جسمين من إطار النص معًا عبر موصل:

![connector-shape-complex](connector-shape-complex.png)

```java
// ينشئ مثيلاً لفئة العرض التقديمي التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);
    // إضافة أشكال سيتم ربطها معًا عبر موصل
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // إضافة موصل
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // تحديد اتجاه الموصل
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // تحديد لون الموصل
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // تحديد سمك خط الموصل
    connector.getLineFormat().setWidth(3);
    
    // ربط الأشكال معًا باستخدام الموصل
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // الحصول على نقاط الضبط للموصل
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**التعديل**

يمكننا تغيير قيم نقطة ضبط الموصل عن طريق زيادة نسبة العرض والارتفاع المقابلة بنسبة 20% و200% على التوالي:

```java
// تغيير قيم نقاط الضبط
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتحديد نموذج يتيح لنا تحديد إحداثيات وشكل الأجزاء الفردية من الموصل، دعنا نخلق شكلًا يتوافق مع المكون الأفقي من الموصل عند النقطة connector.getAdjustments().get_Item(0):

```java
// رسم المكون الرأسي للموصل
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، عرضنا عملية تعديل بسيطة للموصل باستخدام مبادئ أساسية. في الظروف العادية، عليك أخذ دوران الموصل وعرضه في الاعتبار (الذي يتم تعيينه بواسطة connector.getRotation()، وconnector.getFrame().getFlipH()، وconnector.getFrame().getFlipV()). سنعرض الآن هذه العملية.

أولاً، دعنا نضيف جسم إطار نص جديد (**إلى 1**) إلى الشريحة (لأغراض الاتصال) وننشئ موصلًا جديدًا (أخضر) يربطه بالأجسام التي أنشأناها بالفعل.

```java
// إنشاء جسم ربط جديد
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// إنشاء موصل جديد
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// ربط الأجسام باستخدام الموصل الجديد
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// الحصول على نقاط ضبط الموصل
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// تغيير قيم نقاط الضبط
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، دعونا ننشئ شكلًا سيتوافق مع المكون الأفقي للموصل الذي يمر عبر نقطة ضبط الموصل الجديدة connector.getAdjustments().get_Item(0). وسنستخدم القيم من بيانات الموصل للموصل.getRotation()، وموصل.getFrame().getFlipH()، وموصل.getFrame().getFlipV() ونطبق معادلة تحويل إحداثيات شائعة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الجسم هي 90 درجة والموصل معروض عموديًا، لذا سيكون هذا هو الكود المقابل:

```java
// حفظ إحداثيات الموصل
x = connector.getX();
y = connector.getY();
// تصحيح إحداثيات الموصل في حالة ظهوره
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// تأخذ قيمة نقطة الضبط كإحداثية
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  تحويل الإحداثيات لأن Sin(90) = 1 و Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// تحديد عرض المكون الأفقي باستخدام قيمة نقطة الضبط الثانية
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد عرضنا حسابات تتضمن تعديلات بسيطة ونقاط ضبط معقدة (نقاط ضبط مع زوايا دوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى تعيين قيم نقاط ضبط الموصل بناءً على إحداثيات الشريحة المحددة.

## **العثور على زاوية خطوط الموصل**

1. قم بإنشاء مثيل من الفئة.
1. احصل على مرجع الشريحة عبر فهرسها.
1. الوصول إلى شكل خط الموصل.
1. استخدم عرض الخط، الارتفاع، ارتفاع إطار الشكل، وعرض إطار الشكل لحساب الزاوية.

هذا الكود بلغة Java يظهر عملية تم فيها حساب الزاوية لشكل خط الموصل:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```