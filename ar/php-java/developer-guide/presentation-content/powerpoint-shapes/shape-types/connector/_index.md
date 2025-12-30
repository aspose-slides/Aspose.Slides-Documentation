---
title: "إدارة الموصلات في العروض التقديمية باستخدام PHP"
linktitle: "موصل"
type: docs
weight: 10
url: /ar/php-java/connector/
keywords:
- موصل
- نوع الموصل
- نقطة الموصل
- خط الموصل
- زاوية الموصل
- ربط الأشكال
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تمكين تطبيقات PHP من رسم وربط وتوجيه الخطوط تلقائيًا في شرائح PowerPoint — الحصول على تحكم كامل في الموصلات المستقيمة والمقربة والمنحنية."
---

موصل PowerPoint هو خط خاص يربط أو يوصّل شكلين معًا ويظل مرتبطًا بالأشكال حتى عندما يتم تحريكها أو إعادة وضعها على شريحة معينة. 

عادةً ما يتم ربط الموصلات بـ *نقاط الاتصال* (نقاط خضراء)، التي توجد على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

*نقاط الضبط* (نقاط برتقالية)، التي توجد فقط على بعض الموصلات، تُستخدم لتعديل مواقع الموصلات وأشكالها.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام موصلات مستقيمة، ومقربة (زاوية)، ومنحنية. 

توفر Aspose.Slides هذه الموصلات:

| الموصل | الصورة | عدد نقاط الضبط |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **ربط الأشكال باستخدام الموصلات**

1. أنشئ مثيلًا من فئة [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على مرجع شريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) إلى الشريحة باستخدام الطريقة `addAutoShape` التي يوفرها كائن `Shapes`.
1. أضف موصلًا باستخدام الطريقة `addConnector` التي يوفرها كائن `Shapes` مع تحديد نوع الموصل.
1. ربط الأشكال باستخدام الموصل.
1. استدعِ الطريقة `reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي. 

يظهر هذا الكود PHP كيفية إضافة موصل (موصل معقوف) بين شكلين (بيضة ومستطيل):
```php
// ينشئ فئة العرض التقديمي التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى مجموعة الأشكال لشريحة معينة
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # يضيف شكلاً إهليلجياً تلقائيًا
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # يضيف شكلاً مستطيلاً تلقائيًا
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # يضيف شكل موصل إلى مجموعة أشكال الشريحة
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # يربط الأشكال باستخدام الموصل
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # يستدعي reroute الذي يحدد أقصر مسار تلقائي بين الأشكال
    $connector->reroute();
    # يحفظ العرض التقديمي
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
طريقة `Connector.reroute` تعيد توجيه الموصل وتُجبره على اتخاذ أقصر مسار ممكن بين الأشكال. لتحقيق هدفها، قد تُغيّر الطريقة نقاط `setStartShapeConnectionSiteIndex` و `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **تحديد نقطة اتصال**

إذا أردت أن يربط الموصل شكلين باستخدام نقاط معينة على الأشكال، عليك تحديد نقاط الاتصال المفضلة لديك بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على مرجع شريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) إلى الشريحة باستخدام الطريقة `addAutoShape` التي يوفرها كائن `Shapes`.
1. أضف موصلًا باستخدام الطريقة `addConnector` التي يوفرها كائن `Shapes` مع تحديد نوع الموصل.
1. ربط الأشكال باستخدام الموصل.
1. عيّن نقاط الاتصال المفضلة لديك على الأشكال.
1. احفظ العرض التقديمي.

```php
  # ينشئ فئة العرض التقديمي التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى مجموعة الأشكال لشريحة معينة
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # إضافة شكل إهليلجي تلقائي
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # إضافة شكل مستطيل تلقائي
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # إضافة شكل موصل إلى مجموعة أشكال الشريحة
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # ربط الأشكال باستخدام الموصل
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # تحديد فهرس نقطة الاتصال المفضلة على شكل الإهليلج
    $wantedIndex = 6;
    # التحقق مما إذا كان الفهرس المفضل أقل من العدد الأقصى لنقاط الاتصال
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # تحديد نقطة الاتصال المفضلة على الشكل الإهليلجي التلقائي
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # حفظ العرض التقديمي
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ضبط نقطة موصل**

يمكنك ضبط موصل موجود من خلال نقاط الضبط الخاصة به. فقط الموصلات التي تحتوي على نقاط ضبط يمكن تعديلها بهذه الطريقة. راجع الجدول تحت **[أنواع الموصلات.](/slides/ar/php-java/connector/#types-of-connectors)**

### **حالة بسيطة**

اعتبر حالة يكون فيها موصل بين شكلين (A و B) يمر عبر شكل ثالث (C):

![connector-obstruction](connector-obstruction.png)
```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


لتجنب الشكل الثالث أو تجاوزه، يمكننا ضبط الموصل بتحريك خطه العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```


### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، عليك أخذ الأمور التالية في الاعتبار:

* نقطة الضبط للموصل مرتبطة ارتباطًا وثيقًا بصيغة تحسب وتحدد موقعها. لذلك قد تغيّر تغييرات موقع النقطة شكل الموصل.
* يتم تعريف نقاط ضبط الموصل بترتيب صارم في مصفوفة. تُرقم نقاط الضبط من نقطة بدء الموصل إلى نهايته.
* قيم نقاط الضبط تعكس النسبة المئوية لعرض/ارتفاع شكل الموصل.
  * يحد الشكل بنقطة بدء ونقطة نهاية الموصل مضروبة في 1000.
  * النقطة الأولى، والنقطة الثانية، والنقطة الثالثة تحدد النسبة من العرض، والنسبة من الارتفاع، والنسبة من العرض (مرة أخرى) على التوالي.
* لحسابات تحديد إحداثيات نقاط ضبط الموصل، عليك أخذ دوران الموصل وانعكاسه في الاعتبار. **ملاحظة** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/ar/php-java/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

اعتبر حالة يكون فيها كائنان نصيان مربوطان معًا عبر موصل:

![connector-shape-complex](connector-shape-complex.png)
```php
  # ينشئ فئة عرض تقديمي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $sld = $pres->getSlides()->get_Item(0);
    # يضيف أشكالًا سيتم ربطها معًا عبر موصل
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # يضيف موصلًا
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # يحدد اتجاه الموصل
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # يحدد لون الموصل
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # يحدد سُمك خط الموصل
    $connector->getLineFormat()->setWidth(3);
    # يربط الأشكال معًا باستخدام الموصل
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # يحصل على نقاط الضبط للموصل
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**الضبط**

يمكننا تغيير قيم نقاط ضبط الموصل بزيادة النسبة المئوية للعرض والارتفاع المقابلة بنسبة 20% و200% على التوالي:
```php
  # يغيّر قيم نقاط الضبط
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```


النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يتيح لنا تحديد إحداثيات وشكل الأجزاء الفردية للموصل، دعنا نُنشئ شكلًا يتوافق مع المكوّن الأفقي للموصل عند نقطة connector.getAdjustments().get_Item(0):
```php
  # ارسم المكوّن العمودي للموصل
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```


النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، أظهرنا عملية ضبط موصل بسيطة باستخدام المبادئ الأساسية. في الحالات العادية، عليك أخذ دوران الموصل وعرضه (الذي يتم تعيينه بواسطة connector.getRotation()، connector.getFrame().getFlipH()، و connector.getFrame().getFlipV()) في الاعتبار. سنعرض الآن العملية.

أولاً، دعنا نضيف كائن إطار نصي جديد (**To 1**) إلى الشريحة (لأغراض الاتصال) وننشئ موصلًا (أخضر) جديدًا يربطه بالكائنات التي أنشأناها بالفعل.
```php
  # ينشئ كائن ربط جديد
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # ينشئ موصلًا جديدًا
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # يربط الكائنات باستخدام الموصل الذي تم إنشاؤه حديثًا
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # يحصل على نقاط ضبط الموصل
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # يغيّر قيم نقاط الضبط
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، دعنا نُنشئ شكلًا سيتوافق مع المكوّن الأفقي للموصل الذي يمر عبر نقطة الضبط للموصل الجديد connector.getAdjustments().get_Item(0). سنستخدم القيم من بيانات الموصل لـ connector.getRotation()، connector.getFrame().getFlipH()، و connector.getFrame().getFlipV() ونطبق صيغة تحويل الإحداثيات الشهيرة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل معروض عموديًا، لذا هذا هو الكود المقابل:
```php
  # يحفظ إحداثيات الموصل
  $x = $connector->getX();
  $y = $connector->getY();
  # يصحح إحداثيات الموصل في حال ظهورها
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # يأخذ قيمة نقطة الضبط كإحداثي
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # يحوّل الإحداثيات لأن Sin(90) = 1 و Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # يحدد عرض المكوّن الأفقي باستخدام قيمة نقطة الضبط الثانية
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```


النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

أظهرنا حسابات تشمل تعديلات بسيطة ونقاط ضبط معقدة (نقاط ضبط ذات زوايا دوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى تعيين قيم نقاط ضبط الموصل بناءً على إحداثيات شريحة معينة.

## **العثور على زاوية خطوط الموصل**

1. إنشاء مثيل من الفئة.
1. احصل على مرجع شريحة من خلال فهرسها.
1. الوصول إلى شكل خط الموصل.
1. استخدم عرض الخط، الارتفاع، ارتفاع إطار الشكل، وعرض إطار الشكل لحساب الزاوية.

يظهر هذا الكود PHP عملية حساب الزاوية لشكل خط الموصل:
```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان يمكن "لصق" الموصل إلى شكل معين؟**

تحقق من أن الشكل يوفّر [مواقع الاتصال](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getconnectionsitecount/). إذا لم تكن موجودة أو كان العدد صفرًا، فإن اللصق غير متاح؛ في هذه الحالة، استخدم نقاط النهاية الحرة وضعها يدويًا. من المنطقي فحص عدد المواقع قبل الإرفاق.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المتصلة؟**

ستُنقَط أطرافه؛ سيبقى الموصل على الشريحة كخط عادي بنقطة بداية/نهاية حرة. يمكنك إما حذفه أو إعادة تعيين الاتصالات، وإذا لزم الأمر، [إعادة توجيه](https://reference.aspose.com/slides/php-java/aspose.slides/connector/reroute/).

**هل يتم الحفاظ على ارتباطات الموصل عند نسخ شريحة إلى عرض تقديمي آخر؟**

عادةً نعم، بشرط نسخ الأشكال المستهدفة أيضًا. إذا تم إدراج الشريحة في ملف آخر دون الأشكال المتصلة، تصبح الأطراف حرة وستحتاج إلى إعادة ربطها.