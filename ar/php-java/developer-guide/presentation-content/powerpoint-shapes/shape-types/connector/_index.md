---
title: الموصل
type: docs
weight: 10
url: /php-java/connector/
keywords: "ربط الأشكال, الموصلات, أشكال PowerPoint, عرض PowerPoint, Java, Aspose.Slides لـ PHP عبر Java"
description: "ربط أشكال PowerPoint"
---

موصل PowerPoint هو خط خاص يربط أو يربط بين شكلين معًا ويبقى متصلًا بالأشكال حتى عند تحريكها أو إعادة توضعها على الشريحة المعينة.

عادةً ما تتصل الموصلات بـ *نقاط الاتصال* (نقاط خضراء) ، التي توجد على جميع الأشكال افتراضيًا. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

تستخدم *نقاط التعديل* (نقاط برتقالية) ، التي توجد فقط على موصلات معينة ، لتعديل مواضع وأشكال الموصلات.

## **أنواع الموصلات**

في PowerPoint ، يمكنك استخدام الموصلات المستقيمة ، الزاوية (المركبة) ، والمقوسة.

توفر Aspose.Slides هذه الموصلات:

| الموصل                          | الصورة                                                        | عدد نقاط التعديل |
| ------------------------------- | ------------------------------------------------------------ | ---------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                |

## **ربط الأشكال باستخدام الموصلات**

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة شكلين [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) إلى الشريحة باستخدام طريقة `addAutoShape` المعروفة بواسطة كائن `Shapes`.
1. إضافة موصل باستخدام طريقة `addConnector` المعروفة بواسطة كائن `Shapes` من خلال تحديد نوع الموصل.
1. ربط الأشكال باستخدام الموصل.
1. استدعاء طريقة `reroute` لتطبيق أقصر مسار اتصال.
1. حفظ العرض.

يظهر هذا الكود PHP كيفية إضافة موصل (موصل منحني) بين شكلين (بيضاوي ومستطيل):

```php
// ينشئ مثيل لفئة العرض تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى مجموعة الأشكال لشريحة معينة
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # إضافة شكل بيضاوي
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # إضافة شكل مستطيل
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # إضافة شكل موصل إلى مجموعة أشكال الشريحة
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # ربط الأشكال باستخدام الموصل
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # استدعاء reroute الذي يحدد أقصر مسار تلقائي بين الأشكال
    $connector->reroute();
    # حفظ العرض
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="ملحوظة"  color="warning"   %}} 

تقوم طريقة `Connector.reroute` بإعادة توجيه الموصل وتفرض عليه أن يأخذ أقصر مسار ممكن بين الأشكال. لتحقيق هدفه، قد تغيّر الطريقة نقاط `setStartShapeConnectionSiteIndex` و `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **تحديد نقطة الاتصال**

إذا كنت تريد موصل لربط شكلين باستخدام نقاط معينة على الأشكال، يجب عليك تحديد نقاط الاتصال المفضلة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة شكلين [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) إلى الشريحة باستخدام طريقة `addAutoShape` المعروفة بواسطة كائن `Shapes`.
1. إضافة موصل باستخدام طريقة `addConnector` المعروفة بواسطة كائن `Shapes` من خلال تحديد نوع الموصل.
1. ربط الأشكال باستخدام الموصل.
1. تعيين نقاط الاتصال المفضلة لديك على الأشكال.
1. حفظ العرض.

يوضح هذا الكود PHP عملية يتم فيها تحديد نقطة الاتصال المفضلة:

```php
  # ينشئ مثيل لفئة العرض تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى مجموعة الأشكال لشريحة معينة
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # إضافة شكل بيضاوي
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # إضافة شكل مستطيل
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # إضافة شكل موصل إلى مجموعة أشكال الشريحة
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # ربط الأشكال باستخدام الموصل
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # تعيين فهرس نقطة الاتصال المفضلة على الشكل البيضاوي
    $wantedIndex = 6;
    # التحقق مما إذا كان الفهرس المفضل أقل من الحد الأقصى لعدد فهارس الاتصال
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # تعيين نقطة الاتصال المفضلة على الشكل البيضاوي
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # حفظ العرض
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعديل نقطة الموصل**

يمكنك تعديل موصل موجود من خلال نقاط التعديل الخاصة به. يمكن تعديل الموصلات التي تحتوي فقط على نقاط تعديل بهذه الطريقة. راجع الجدول تحت **[أنواع الموصلات.](/slides/php-java/connector/#types-of-connectors)**

#### **حالة بسيطة**

افترض وجود حالة يمر فيها موصل بين شكلين (أ و ب) عبر شكل ثالث (ج):

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

لتجنب أو تخطي الشكل الثالث، يمكننا تعديل الموصل عن طريق تحريك خطه العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);
```

### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، يجب أن تأخذ في اعتبارك هذه الأمور:

* تتعلق نقطة تعديل الموصل ارتباطًا قويًا بالصيغ التي تحسب وتحدد موقعها. لذا فإن التغييرات على موقع النقطة قد تغير شكل الموصل.
* تُعرف نقاط تعديل الموصل بترتيب صارم في صفيف. تُرقم نقاط التعديل من نقطة بداية الموصل إلى النهاية.
* تعكس قيم نقطة التعديل نسبة عرض/ارتفاع شكل الموصل. 
  * الشكل محاط بنقاط بداية ونهاية الموصل مضروبة في 1000. 
  * تُعرف النقطة الأولى والنقطة الثانية والنقطة الثالثة النسبة من العرض، والنسبة من الارتفاع، والنسبة من العرض (مرة أخرى) على التوالي.
* للتقديرات التي تحدد إحداثيات نقاط تعديل الموصل، يجب أن تأخذ في اعتبارك دوران الموصل وانعكاسه. **ملحوظة** أن زاوية الدوران لجميع الموصلات الموضحة تحت **[أنواع الموصلات](/slides/php-java/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

افترض وجود حالة حيث يرتبط كائنين إطار نص مع موصل:

![connector-shape-complex](connector-shape-complex.png)

```php
  # ينشئ مثيل لفئة العرض تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى في العرض
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة أشكال سيتم ربطها معًا من خلال موصل
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("من");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("إلى");
    # إضافة موصل
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # تحدد الاتجاه الموصل
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # تحدد لون الموصل
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # تحدد سمك خط الموصل
    $connector->getLineFormat()->setWidth(3);
    # ربط الأشكال مع الموصل
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # الحصول على نقاط التعديل للموصل
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**تعديل**

يمكننا تغيير قيم نقاط تعديل الموصل عن طريق زيادة النسبة المقابلة للعروض والارتفاعات بنسبة 20٪ و 200٪ على التوالي:

```php
  # تغيير قيم نقاط التعديل
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يسمح لنا بتحديد إحداثيات وشكل أجزاء الموصل الفردية، دعنا ننشئ شكلًا يتوافق مع المكون الأفقي للموصل عند نقطة connector.getAdjustments().get_Item(0):

```php
  # رسم المكون العمودي للموصل
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، عرضنا عملية تعديل موصل بسيطة باستخدام مبادئ أساسية. في الحالات العادية، يجب أخذ دوران الموصل وعرضه (والتي يتم تعيينها بواسطة connector.getRotation()، وconnector.getFrame().getFlipH()، وconnector.getFrame().getFlipV()) في الاعتبار. سنظهر الآن العملية.

أولًا، دعنا نضيف كائن إطار نص جديد (**إلى 1**) إلى الشريحة (لغرض الاتصال) وننشئ موصلًا جديدًا (أخضر) يربطه بالأشياء التي أنشأناها بالفعل.

```php
  # إنشاء كائن ارتباط جديد
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("إلى 1");
  # إنشاء موصل جديد
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # ربط الأشياء باستخدام الموصل الجديد الذي تم إنشاؤه
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # الحصول على نقاط تعديل الموصل
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # تغيير قيم نقاط التعديل
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، دعنا ننشئ شكلًا سيتوافق مع المكون الأفقي للموصل الذي يمر عبر نقطة تعديل الموصل الجديدة connector.getAdjustments().get_Item(0). سنستخدم القيم من بيانات الموصل لـ connector.getRotation()، وconnector.getFrame().getFlipH()، وconnector.getFrame().getFlipV() وسنطبق معادلة تحويل الإحداثيات المعروفة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل معروض عموديًا، لذلك هذا هو الكود المقابل:

```php
  # حفظ إحداثيات الموصل
  $x = $connector->getX();
  $y = $connector->getY();
  # تصحيح إحداثيات الموصل في حالة ظهورها
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # أخذ قيمة نقطة التعديل كإحداثية
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # تحويل الإحداثيات نظرًا لأن Sin(90) = 1 و Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # تحديد عرض المكون الأفقي باستخدام قيمة نقطة التعديل الثانية
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

عرضنا حسابات تتعلق بالتعديلات البسيطة ونقاط التعديل المعقدة (نقاط التعديل مع زوايا الدوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى تعيين قيم نقاط تعديل الموصل بناءً على إحداثيات الشريحة المحددة.

## **البحث عن زاوية خطوط الموصل**

1. إنشاء مثيل من الفئة.
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. الوصول إلى شكل خط الموصل.
1. استخدام عرض الخط ، الارتفاع ، ارتفاع شكل الإطار ، وعرض شكل الإطار لحساب الزاوية.

يوضح هذا الكود PHP عملية تمكنا من خلالها من حساب الزاوية لشكل خط الموصل:

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