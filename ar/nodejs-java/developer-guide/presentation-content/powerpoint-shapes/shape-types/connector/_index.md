---
title: موصل
type: docs
weight: 10
url: /ar/nodejs-java/connector/
keywords: "ربط الأشكال, الموصلات, أشكال PowerPoint, عرض PowerPoint التقديمي, Java, Aspose.Slides لـ Node.js عبر Java"
description: "ربط أشكال PowerPoint في JavaScript"
---

موصل PowerPoint هو خط خاص يربط شكلين معًا ويبقى ملتصقًا بالأشكال حتى عند تحريكها أو إعادة تموضعها على الشريحة المحددة. 

عادةً ما تكون الموصلات متصلة بـ *نقاط الاتصال* (النقاط الخضراء)، التي تتوفر على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

*نقاط التعديل* (النقاط البرتقالية)، التي تتوفر فقط على بعض الموصلات، تُستخدم لتعديل موضع وشكل الموصلات.

## **أنواع الموصلات**

في PowerPoint يمكنك استخدام موصلات مستقيمة، ومقوسة (زاوية)، ومنحنية. 

توفر Aspose.Slides هذه الموصلات:

| Connector                      | Image                                                        | Number of adjustment points |
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

## **ربط الأشكال باستخدام الموصلات**

1. أنشئ كائنًا من فئة [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) إلى الشريحة باستخدام طريقة `addAutoShape` التي توفرها الكائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `addConnector` التي توفرها الكائن `Shapes` مع تحديد نوع الموصل.
1. اربط الأشكال باستخدام الموصل. 
1. استدعِ طريقة `reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي. 

هذا الكود JavaScript يوضح كيفية إضافة موصل (موصل معوج) بين شكلين (بيضة ومستطيل):
```javascript
// ينشئ كلاس العرض التقديمي الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى مجموعة الأشكال لشريحة معينة
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // يضيف شكل أوتوشيب إهليلجي
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // يضيف شكل أوتوشيب مستطيل
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // يضيف شكل موصل إلى مجموعة أشكال الشريحة
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // يربط الأشكال باستخدام الموصل
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // ينادى على reroute الذي يضبط أقصر مسار تلقائي بين الأشكال
    connector.reroute();
    // يحفظ العرض التقديمي
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

طريقة `Connector.reroute` تعيد توجيه الموصل وتفرض عليه اتخاذ أقصر مسار ممكن بين الأشكال. لتحقيق ذلك قد تغير الطريقة نقاط `setStartShapeConnectionSiteIndex` و`setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **تحديد نقطة الاتصال**

إذا رغبت في أن يربط الموصل شكلين باستخدام نقاط معينة على الأشكال، عليك تحديد نقاط الاتصال المفضلة بهذه الطريقة:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) إلى الشريحة باستخدام طريقة `addAutoShape` التي توفرها الكائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `addConnector` التي توفرها الكائن `Shapes` مع تحديد نوع الموصل.
1. اربط الأشكال باستخدام الموصل. 
1. اضبط نقاط الاتصال المفضلة على الأشكال. 
1. احفظ العرض التقديمي.

هذا الكود JavaScript يوضح عملية تحديد نقطة اتصال مفضلة:
```javascript
    // ينشئ كلاس عرض تقديمي يمثل ملف PPTX
    var pres = new aspose.slides.Presentation();
    try {
        // يصل إلى مجموعة الأشكال لشريحة محددة
        var shapes = pres.getSlides().get_Item(0).getShapes();
        // يضيف شكل أوتوشيب إهليلجي
        var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
        // يضيف شكل أوتوشيب مستطيل
        var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
        // يضيف شكل موصل إلى مجموعة أشكال الشريحة
        var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
        // يربط الأشكال باستخدام الموصل
        connector.setStartShapeConnectedTo(ellipse);
        connector.setEndShapeConnectedTo(rectangle);
        // يحدد فهرس نقطة الاتصال المفضلة على شكل الإهليلج
        var wantedIndex = 6;
        // يتحقق ما إذا كان الفهرس المفضلة أقل من عدد المواقع القصوى
        if (ellipse.getConnectionSiteCount() > wantedIndex) {
            // يحدد نقطة الاتصال المفضلة على شكل الإهليلج أوتوشيب
            connector.setStartShapeConnectionSiteIndex(wantedIndex);
        }
        // يحفظ العرض التقديمي
        pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **ضبط نقطة الموصل**

يمكنك تعديل موصل موجود عبر نقاط التعديل الخاصة به. فقط الموصلات التي تحتوي على نقاط تعديل يمكن تغييرها بهذه الطريقة. راجع الجدول تحت **[Types of connectors.](/slides/ar/nodejs-java/connector/#types-of-connectors)**

### **حالة بسيطة**

تخيل حالة يكون فيها موصل بين شكلين (A و B) يمر عبر شكل ثالث (C):

![connector-obstruction](connector-obstruction.png)
```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


لتجنب أو تجاوز الشكل الثالث، يمكننا تعديل الموصل بنقل الخط العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، عليك مراعاة الأمور التالية:

* نقطة تعديل الموصل مرتبطة ارتباطًا وثيقًا بمعادلة تحسب وتحدد موضعها. لذلك قد يغير تعديل موقع النقطة شكل الموصل.
* تُعرّف نقاط تعديل الموصل بترتيب صارم داخل مصفوفة. تُرقم النقاط من نقطة بداية الموصل إلى نهايته.
* قيم نقاط التعديل تعكس النسبة المئوية لعرض/ارتفاع شكل الموصل. 
  * يُقيد الشكل بنقطة بداية الموصل ونهايته مضروبًا في 1000. 
  * النقطة الأولى، الثانية، والثالثة تُحدّد النسبة المئوية من العرض، النسبة المئوية من الارتفاع، والنسبة المئوية من العرض مرة أخرى على التوالي.
* لحساب إحداثيات نقاط تعديل الموصل، يجب أخذ دوران الموصل وانعكاسه في الاعتبار. **ملاحظة** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[Types of connectors](/slides/ar/nodejs-java/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

تخيل حالة تكون فيها كائنات إطارات نصية مرتبطة معًا عبر موصل:

![connector-shape-complex](connector-shape-complex.png)
```javascript
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    var sld = pres.getSlides().get_Item(0);
    // يضيف أشكالًا سيتم ربطها معًا عبر موصل
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // يضيف موصلاً
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // يحدد اتجاه الموصل
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // يحدد لون الموصل
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // يحدد سمك خط الموصل
    connector.getLineFormat().setWidth(3);
    // يربط الأشكال معًا باستخدام الموصل
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // يحصل على نقاط تعديل للموصل
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**التعديل**

يمكننا تغيير قيم نقاط تعديل الموصل بزيادة النسبة المئوية للعرض والارتفاع المقابلين بنسبة 20٪ و200٪ على الترتيب:
```javascript
// يغيّر قيم نقاط التعديل
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يتيح لنا تحديد إحداثيات وشكل الأجزاء الفردية للموصل، لننشئ شكلًا يتطابق مع المكوّن الأفقي للموصل عند نقطة `connector.getAdjustments().get_Item(0)`:
```javascript
// ارسم المكوّن الرأسي للموصل
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```


النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، استعرضنا عملية تعديل موصل بسيطة باستخدام مبادئ أساسية. في الظروف العادية، يجب أخذ دوران الموصل وعرضه (الذي يتم تحديده بواسطة `connector.getRotation()`, `connector.getFrame().getFlipH()`, و`connector.getFrame().getFlipV()`) في الاعتبار. سنُظهر الآن العملية.

أولاً، أضف كائن إطار نصي جديد (**To 1**) إلى الشريحة (لغرض الاتصال) وأنشئ موصلًا (أخضر) يربطه بالكائنات التي أنشأناها مسبقًا.
```javascript
// ينشئ كائن ربط جديد
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// ينشئ موصلاً جديداً
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// يربط الكائنات باستخدام الموصل الذي تم إنشاؤه حديثًا
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// يحصل على نقاط تعديل الموصل
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// يغيّر قيم نقاط التعديل
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، أنشئ شكلًا سيتطابق مع المكوّن الأفقي للموصل الذي يمر عبر نقطة تعديل الموصل `connector.getAdjustments().get_Item(0)`. سنستخدم القيم من بيانات الموصل للـ `connector.getRotation()`, `connector.getFrame().getFlipH()`, و`connector.getFrame().getFlipV()` ونطبق صيغة تحويل الإحداثيات الشهيرة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل معروض عموديًا، لذا يكون الكود المقابل كالتالي:
```javascript
// يحفظ إحداثيات الموصل
x = connector.getX();
y = connector.getY();
// يصحح إحداثيات الموصل في حال ظهوره
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// يأخذ قيمة نقطة التعديل كإحداثي
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// يحوّل الإحداثيات لأن Sin(90) = 1 و Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// يحدّد عرض المكوّن الأفقي باستخدام قيمة نقطة التعديل الثانية
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد استعرضنا حسابات تتعلق بتعديلات بسيطة ونقاط تعديل معقدة (نقاط تعديل مع زوايا دوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى ضبط قيم نقاط تعديل الموصل بناءً على إحداثيات شريحة معينة.

## **إيجاد زاوية خطوط الموصل**

1. أنشئ كائنًا من الفئة.
1. احصل على مرجع الشريحة عبر فهرسها.
1. وصول إلى شكل خط الموصل.
1. استخدم عرض وخط ارتفاع الخط، ارتفاع إطار الشكل، وعرض إطار الشكل لحساب الزاوية.

هذا الكود JavaScript يوضح عملية حساب زاوية شكل خط الموصل:
```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان يمكن “لصق” موصل إلى شكل معين؟**

تحقق مما إذا كان الشكل يوفّر [connection sites](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getconnectionsitecount/). إذا لم يكن هناك أي أو كان العدد صفرًا، فإن اللصق غير متاح؛ في هذه الحالة استخدم نقاط نهاية حرة وضعها يدويًا. من المنطقي فحص عدد المواقع قبل الإرفاق.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المتصلة؟**

ستنفصل نهاياته؛ يبقى الموصل على الشريحة كخط عادي بنقاط بداية/نهاية حرة. يمكنك إما حذفه أو إعادة تعيين الاتصالات وإذا لزم الأمر، استخدم [reroute](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/reroute/).

**هل تُحفظ ارتباطات الموصل عند نسخ شريحة إلى عرض تقديمي آخر؟**

عمومًا نعم، بشرط نسخ الأشكال المستهدفة أيضًا. إذا تم إدراج الشريحة في ملف آخر دون الأشكال المتصلة، تصبح النهايات حرة وستحتاج إلى إرفاقها مرة أخرى.