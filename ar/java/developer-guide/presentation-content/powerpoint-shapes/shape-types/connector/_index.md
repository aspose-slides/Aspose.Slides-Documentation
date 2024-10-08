---
title: الموصل
type: docs
weight: 10
url: /ar/java/connector/
keywords: "توصيل الأشكال, الموصلات, أشكال PowerPoint, عرض PowerPoint, Java, Aspose.Slides for Java"
description: "توصيل أشكال PowerPoint في Java"
---

الموصل في PowerPoint هو خط خاص يربط أو يصل بين شكلين معًا ويظل ملحقًا بالأشكال حتى عند نقلها أو إعادة وضعها على شريحة معينة.

عادة ما تكون الموصلات متصلة بـ *نقاط الاتصال* (نقاط خضراء)، التي توجد على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

تستخدم *نقاط التعديل* (نقاط برتقالية)، التي توجد فقط على موصلات معينة، لتعديل مواضع وأشكال الموصلات.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام الموصلات المستقيمة، الزاوية، والمقوسة.

يوفر Aspose.Slides هذه الموصلات:

| الموصل                          | الصورة                                                       | عدد نقاط التعديل          |
| ------------------------------- | ---------------------------------------------------------- | ------------------------- |
| `ShapeType.Line`                | ![shapetype-lineconnector](shapetype-lineconnector.png)    | 0                         |
| `ShapeType.StraightConnector1`  | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                         |
| `ShapeType.BentConnector2`      | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0                         |
| `ShapeType.BentConnector3`      | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1                         |
| `ShapeType.BentConnector4`      | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2                         |
| `ShapeType.BentConnector5`      | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3                         |
| `ShapeType.CurvedConnector2`    | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                         |
| `ShapeType.CurvedConnector3`    | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                         |
| `ShapeType.CurvedConnector4`    | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                         |
| `ShapeType.CurvedConnector5`    | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                         |

## **توصيل الأشكال باستخدام الموصلات**

1. أنشئ مثيلًا من فئة [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) إلى الشريحة باستخدام طريقة `addAutoShape` المعرّضة بواسطة كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `addConnector` المعرّضة بواسطة كائن `Shapes` من خلال تعريف نوع الموصل.
1. وصّل الأشكال باستخدام الموصل.
1. استدعِ طريقة `reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي.

يوضح هذا الرمز البرمجي بلغة Java كيفية إضافة موصل (موصل منحنٍ) بين شكلين (بيضاوي ومربع):

```Java
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى مجموعة الأشكال لشريحة محددة
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // يضيف شكل بيضاوي
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // يضيف شكل مربع
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // يربط الأشكال باستخدام الموصل
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // يستدعي reroute الذي يحدد المسار تلقائيًا الأقصر بين الأشكال
    connector.reroute();
    
    // يحفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="ملاحظة"  color="warning"   %}} 

تقوم طريقة `Connector.reroute` بإعادة توجيه الموصل وتفرضه ليأخذ أقصر مسار ممكن بين الأشكال. لتحقيق هدفها، قد تقوم الطريقة بتغيير نقاط `setStartShapeConnectionSiteIndex` و `setEndShapeConnectionSiteIndex`.

{{% /alert %}} 

## **تحديد نقطة الاتصال**

إذا كنت ترغب في أن يربط موصل بين شكلين باستخدام نقاط محددة على الأشكال، عليك تحديد نقاط الاتصال المفضلة لديك بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) إلى الشريحة باستخدام طريقة `addAutoShape` المعرّضة بواسطة كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `addConnector` المعرّضة بواسطة كائن `Shapes` من خلال تعريف نوع الموصل.
1. وصّل الأشكال باستخدام الموصل.
1. قم بتعيين نقاط الاتصال المفضلة لديك على الأشكال.
1. احفظ العرض التقديمي.

يوضح هذا الرمز البرمجي بلغة Java عملية حيث يتم تحديد نقطة اتصال مفضلة:

```java
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى مجموعة الأشكال لشريحة محددة
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // يضيف شكل بيضاوي
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // يضيف شكل مربع
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // يربط الأشكال باستخدام الموصل
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // يحدد فهرس نقطة الاتصال المفضلة على الشكل البيضاوي
    int wantedIndex = 6;

    // يتحقق مما إذا كان الفهرس المفضل أقل من عدد فهارس المواقع القصوى
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // يحدد نقطة الاتصال المفضلة على الشكل البيضاوي
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // يحفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعديل نقطة الموصل**

يمكنك تعديل موصل موجود من خلال نقاط التعديل الخاصة به. يمكن تعديل الموصلات فقط التي لديها نقاط تعديل بهذه الطريقة. انظر الجدول تحت **[أنواع الموصلات.](/slides/ar/java/connector/#types-of-connectors)** 

#### **حالة بسيطة**

اعتبر حالة حيث يمر موصل بين شكلين (A و B) عبر شكل ثالث (C):

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

لتجنب أو تجاوز الشكل الثالث، يمكننا تعديل الموصل عن طريق تحريك خطه العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، يجب أن تأخذ هذه الأمور بعين الاعتبار:

* ترتبط نقطة تعديل الموصل بقوة بمعادلة تحدد موقعها. لذلك، قد تؤدي التغييرات في موقع النقطة إلى تغيير شكل الموصل.
* يتم تعريف نقاط تعديل الموصل بترتيب صارم في مصفوفة. تُرقم نقاط التعديل من نقطة بداية الموصل إلى نقطة نهايته.
* تعكس قيم نقاط التعديل النسبة المئوية لعرض/ارتفاع شكل الموصل. 
  * الشكل مقيد بنقاط البداية والنهاية للموصل مضروبة في 1000. 
  * تحدد النقطة الأولى والثانية والثالثة النسبة المئوية من العرض، النسبة المئوية من الارتفاع، والنسبة المئوية من العرض (مرة أخرى) على التوالي.
* بالنسبة للحسابات التي تحدد إحداثيات نقاط تعديل الموصل، يجب أن تأخذ بعين الاعتبار دوران الموصل وانعكاسه. **ملاحظة** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/ar/java/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

اعتبر حالة حيث ترتبط كيانان نصيان معًا من خلال موصل:

![connector-shape-complex](connector-shape-complex.png)

```java
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);
    // يضيف أشكالًا سيتم ربطها معًا من خلال موصل
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("من");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("إلى");
    // يضيف موصل
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // يحدد اتجاه الموصل
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // يحدد لون الموصل
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // يحدد سمك خط الموصل
    connector.getLineFormat().setWidth(3);
    
    // يربط الأشكال معًا باستخدام الموصل
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // يحصل على نقاط التعديل للموصل
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**التعديل**

يمكننا تغيير قيم نقاط تعديل الموصل من خلال زيادة نسبة العرض والارتفاع المقابلة بمقدار 20% و200% على التوالي:

```java
// يغير قيم نقاط التعديل
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتحديد نموذج يسمح لنا بتحديد الإحداثيات وشكل الأجزاء الفردية من الموصل، دعنا ننشئ شكلًا يتوافق مع المكون الأفقي للموصل في نقطة connector.getAdjustments().get_Item(0):

```java
// يرسم المكون العمودي للموصل
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، أظهرنا عملية تعديل موصل بسيطة باستخدام مبادئ أساسية. في الحالات الطبيعية، يجب أن تأخذ في الاعتبار دوران الموصل وعرضه (الذي يتم تعيينه بواسطة connector.getRotation() و connector.getFrame().getFlipH() و connector.getFrame().getFlipV()). سنظهر الآن العملية.

أولاً، دعنا نضيف كائن إطار نص جديد (**إلى 1**) إلى الشريحة (لأغراض الربط) وننشئ موصلًا جديدًا (أخضر) يربطه بالأشياء التي أنشأناها بالفعل.

```java
// ينشئ كائن ربط جديد
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("إلى 1");
// ينشئ موصلًا جديدًا
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// يربط الأشياء باستخدام الموصل الجديد الذي تم إنشاؤه
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// يحصل على نقاط تعديل الموصل
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// يغير قيم نقاط التعديل
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، دعنا ننشئ شكلًا يتوافق مع المكون الأفقي للموصل الذي يمر عبر نقطة التعديل الجديدة للموصل connector.getAdjustments().get_Item(0). سنستخدم القيم من بيانات الموصل لـ connector.getRotation() و connector.getFrame().getFlipH() و connector.getFrame().getFlipV() ونطبق معادلة تحويل الإحداثيات الشائعة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، تكون زاوية دوران الكائن 90 درجة والموصل يظهر عموديًا، لذا هذا هو الرمز المقابل:

```java
// يحفظ إحداثيات الموصل
x = connector.getX();
y = connector.getY();
// يصحح إحداثيات الموصل في حالة ظهوره
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// يأخذ في الاعتبار قيمة نقطة التعديل كإحداثية
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  تحويل الإحداثيات نظرًا لأن Sin(90) = 1 و Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// يحدد عرض المكون الأفقي باستخدام قيمة نقطة التعديل الثانية
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد عرضنا الحسابات الم involving adjustments بسيطة ومعقدة (نقاط تعديل مع زوايا دوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى تعيين قيم نقطة تعديل موصل استنادًا إلى إحداثيات الشريحة المحددة.

## **البحث عن زاوية خطوط الموصلات**

1. أنشئ مثيلًا من الفئة.
1. احصل على مرجع الشريحة من خلال فهرسها.
1. الوصول إلى شكل خط الموصل.
1. استخدم عرض الخط وارتفاعه، وارتفاع إطار الشكل، وعرض إطار الشكل لحساب الزاوية.

يوضح هذا الرمز البرمجي بلغة Java عملية حيث قمنا بحساب الزاوية لشكل خط الموصل:

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