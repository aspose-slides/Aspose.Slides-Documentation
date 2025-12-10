---
title: إدارة الموصلات في العروض التقديمية باستخدام Java
linktitle: موصل
type: docs
weight: 10
url: /ar/java/connector/
keywords:
- موصل
- نوع الموصل
- نقطة الموصل
- خط الموصل
- زاوية الموصل
- ربط الأشكال
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تمكين تطبيقات Java من رسم وربط وتوجيه الخطوط تلقائيًا في شرائح PowerPoint – الحصول على تحكم كامل في الموصلات المستقيمة والمربعة والمنحنية."
---

‏موصل PowerPoint هو خط خاص يربط شكلين معًا ويظل ملحقًا بالأشكال حتى عند نقلها أو إعادة وضعها على الشريحة المحددة.

عادةً ما يتم ربط الموصلات بـ *نقاط الاتصال* (النقاط الخضراء)، التي تتواجد على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

*نقاط الضبط* (النقاط البرتقالية)، التي تتواجد فقط في بعض الموصلات، تُستخدم لتعديل مواضع وشكل الموصلات.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام موصلات مستقيمة، ومرفقة (زاوية)، ومنحنية.

توفر Aspose.Slides هذه الموصلات:

| الموصل                     | الصورة                                                       | عدد نقاط الضبط |
| -------------------------- | ------------------------------------------------------------ | --------------- |
| `ShapeType.Line`           | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0               |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0               |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0               |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1               |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2               |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3               |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0               |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1               |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2               |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3               |

## **ربط الأشكال باستخدام الموصلات**

1. أنشئ كائنًا من الفئة [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال رقم الفهرس الخاص بها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) إلى الشريحة باستخدام الطريقة `addAutoShape` المتاحة عبر كائن `Shapes`.
1. أضف موصلًا باستخدام الطريقة `addConnector` المتاحة عبر كائن `Shapes` مع تحديد نوع الموصل.
1. اربط الأشكال باستخدام الموصل.
1. استدعِ الطريقة `reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي.

يعرض هذا الشيفرة Java كيفية إضافة موصل (موصل مقوَّس) بين شكلين (إهليلج ومستطيل):
```Java
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى مجموعة الأشكال لشريحة معينة
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // يضيف شكل أوتوشيب إهليلج
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // يضيف شكل أوتوشيب مستطيل
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // يربط الأشكال باستخدام الموصل
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // يستدعي reroute الذي يحدد أقصر مسار تلقائي بين الأشكال
    connector.reroute();
    
    // يحفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

تعيد طريقة `Connector.reroute` توجيه الموصل وتُجبره على اتخاذ أقصر مسار ممكن بين الأشكال. لتحقيق ذلك، قد تُغيّر الطريقة نقاط `setStartShapeConnectionSiteIndex` و `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **تحديد نقطة اتصال**

إذا أردت أن يُربط الموصل شكلين باستخدام نقاط محددة على الأشكال، عليك تحديد نقاط الاتصال المفضلة بهذه الطريقة:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال رقم الفهرس الخاص بها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) إلى الشريحة باستخدام الطريقة `addAutoShape` المتاحة عبر كائن `Shapes`.
1. أضف موصلًا باستخدام الطريقة `addConnector` المتاحة عبر كائن `Shapes` مع تحديد نوع الموصل.
1. اربط الأشكال باستخدام الموصل.
1. عيّن نقاط الاتصال المفضلة على الأشكال.
1. احفظ العرض التقديمي.

توضح هذه الشيفرة Java عملية تحديد نقطة اتصال مفضلة:
```java
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى مجموعة الأشكال لشريحة معينة
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // يضيف شكل أوتوشيب إهليلجي
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // يضيف شكل أوتوشيب مستطيل
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // يربط الأشكال باستخدام الموصل
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // يحدد فهرس نقطة الاتصال المفضلة على شكل الإهليلج
    int wantedIndex = 6;

    // يتحقق مما إذا كان الفهرس المفضل أصغر من عدد نقاط الاتصال القصوى
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // يحدد نقطة الاتصال المفضلة على شكل الإهليلج الأوتوشيب
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // يحفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ضبط نقطة موصل**

يمكنك ضبط موصل موجود عبر نقاط الضبط الخاصة به. يمكن تعديل الموصلات التي تحتوي على نقاط ضبط فقط بهذه الطريقة. راجع الجدول تحت **[أنواع الموصلات.](/slides/ar/java/connector/#types-of-connectors)** 

### **حالة بسيطة**

تخيل حالة يتقاطع فيها موصل بين شكلين (A و B) مع شكل ثالث (C):

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


لتجنب أو تجاوز الشكل الثالث، يمكننا ضبط الموصل بنقل خطه العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، عليك مراعاة ما يلي:

* نقطة ضبط الموصل ترتبط ارتباطًا وثيقًا بمعادلة تحسب وتحدد موقعها. لذا قد يؤدي تغيير موقع النقطة إلى تغيير شكل الموصل.
* تُعرَّف نقاط ضبط الموصل بترتيب صارم في مصفوفة. تُرقم نقاط الضبط من نقطة بداية الموصل إلى نقطته النهائية.
* تُعبر قيم نقاط الضبط عن النسبة المئوية لعرض/ارتفاع شكل الموصل.  
  * يُحدَّد الشكل بحدود نقطة البداية والنهاية للموصل مضروبًا في 1000.  
  * النقطة الأولى، الثانية، والثالثة تُحدد النسبة من العرض، النسبة من الارتفاع، والنسبة من العرض مرة أخرى على التوالي.
* عند حساب إحداثيات نقاط ضبط الموصل، يجب مراعاة دوران الموصل وانعكاسه. **ملاحظة** أن زاوية دوران جميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/ar/java/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

تخيل حالة يتم فيها ربط كائنين من إطارات النص عبر موصل:

![connector-shape-complex](connector-shape-complex.png)
```java
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);
    // يضيف أشكالًا سيتم ربطها معًا عبر موصل
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // يضيف موصلًا
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
    
    // يحصل على نقاط الضبط للموصل
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```


**الضبط**

يمكننا تغيير قيم نقاط ضبط الموصل بزيادة نسبة العرض والارتفاع المقابلة بنسبة 20% و200% على التوالي:
```java
// يغيّر قيم نقاط الضبط
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يتيح لنا تحديد إحداثيات وشكل الأجزاء الفردية للموصل، لننشئ شكلًا يطابق المكوّن الأفقي للموصل عند نقطة `connector.getAdjustments().get_Item(0)`:
```java
// ارسم المكوّن العمودي للموصل
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، عرضنا عملية ضبط موصل بسيطة باستخدام مبادئ أساسية. في الحالات العادية، عليك أخذ دوران الموصل وعرضه (المُحدد بـ `connector.getRotation()`, `connector.getFrame().getFlipH()`, و `connector.getFrame().getFlipV()`) في الاعتبار. الآن سنوضح العملية.

أولاً، أضف كائن إطار نص جديد (**To 1**) إلى الشريحة (لغرض الاتصال) وأنشئ موصلًا (أخضر) يربطه بالأجسام التي أنشأناها مسبقًا.
```java
// ينشئ كائن ربط جديد
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// ينشئ موصلًا جديدًا
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// يربط الكائنات باستخدام الموصل الذي تم إنشاؤه حديثًا
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// يحصل على نقاط ضبط الموصل
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// يغيّر قيم نقاط الضبط
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، أنشئ شكلًا سيطابق المكوّن الأفقي للموصل الذي يمر عبر نقطة ضبط الموصل الجديدة `connector.getAdjustments().get_Item(0)`. سنستخدم القيم من `connector.getRotation()`, `connector.getFrame().getFlipH()`, و `connector.getFrame().getFlipV()` ونطبق الصيغة الشائعة لتحويل الإحداثيات عندما يدور حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل معروض عموديًا، لذا يكون الشيفرة المقابلة:
```java
// يحفظ إحداثيات الموصل
x = connector.getX();
y = connector.getY();
// يصحح إحداثيات الموصل في حال ظهوره
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// يأخذ قيمة نقطة الضبط كإحداثي
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  يحول الإحداثيات لأن Sin(90) = 1 و Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// يحدد عرض المكوّن الأفقي باستخدام قيمة نقطة الضبط الثانية
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```


النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد عرضنا حسابات تشمل تعديلات بسيطة ونقاط ضبط معقدة (نقاط ضبط ذات زوايا دوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة شيفرة) للحصول على كائن `GraphicsPath` أو حتى تعيين قيم نقاط ضبط الموصل بناءً على إحداثيات شريحة محددة.

## **إيجاد زاوية خطوط الموصل**

1. أنشئ كائنًا من الفئة.
1. احصل على مرجع الشريحة من خلال رقم الفهرس الخاص بها.
1. وصول إلى شكل خط الموصل.
1. استخدم عرض الخط، ارتفاعه، ارتفاع إطار الشكل، وعرض إطار الشكل لحساب الزاوية.

تُظهر هذه الشيفرة Java عملية حساب زاوية شكل خط موصل:
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


## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان يمكن "لصق" موصل إلى شكل معين؟**

تحقق مما إذا كان الشكل يوفّر [نقاط الاتصال](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getConnectionSiteCount--). إذا لم توجد أو كان عددها صفرًا، فإن اللصق غير متاح؛ في هذه الحالة استخدم نقاط النهاية الحرّة وضعها يدويًا. من المنطقي التحقق من عدد المواقع قبل الإرفاق.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المتصلة؟**

ستنقطع نهاياته؛ سيظل الموصل على الشريحة كخط عادي بنقاط بدء/نهاية حرة. يمكنك إما حذف الموصل أو إعادة تعيين الاتصالات، وإذا لزم الأمر، استدعاء [reroute](https://reference.aspose.com/slides/java/com.aspose.slides/connector/#reroute--).

**هل تُحفظ ارتباطات الموصلات عند نسخ شريحة إلى عرض تقديمي آخر؟**

عمومًا نعم، بشرط نسخ الأشكال المستهدفة أيضًا. إذا تم إدراج الشريحة في ملف آخر دون الأشكال المتصلة، تصبح النهايات حرة وستحتاج إلى إرفاقها مرة أخرى.