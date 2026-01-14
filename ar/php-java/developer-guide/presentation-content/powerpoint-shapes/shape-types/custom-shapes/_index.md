---
title: تخصيص أشكال العرض التقديمي في PHP
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/php-java/custom-shape/
keywords:
- شكل مخصص
- إضافة شكل
- إنشاء شكل
- تغيير شكل
- هندسة الشكل
- مسار الهندسة
- نقاط المسار
- نقاط التحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص أشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---

## **تغيير شكل باستخدام نقاط التحرير**
ضع في اعتبارك مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك 

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد انحناء الزاوية أو النقطة
* إضافة نقاط جديدة إلى المربع
* معالجة النقاط على المربع، إلخ. 

في الأساس، يمكنك تنفيذ هذه المهام على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود. 

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

قبل أن تبدأ في تحرير أشكال PowerPoint عبر نقاط التحرير، قد ترغب في مراعاة هذه النقاط حول الأشكال:

* قد يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، لا يحتوي على نقطة بداية أو نهاية. عندما يكون الشكل مفتوحًا، لديه بداية ونهاية. 
* تتكون جميع الأشكال من نقطتي ارتكاز على الأقل مرتبطتين ببعضهما عبر خطوط
* الخط قد يكون مستقيمًا أو منحنيًا. تحدد نقاط الارتكاز طبيعة الخط. 
* نقاط الارتكاز توجد كزوايا، أو نقاط مستقيمة، أو نقاط ناعمة:
  * نقطة الزاوية هي نقطة يلتقي فيها خطان مستقيران بزاوية. 
  * نقطة ناعمة هي نقطة حيث يوجد مقبضان على خط مستقيم وتتصل أجزاء الخط بمنحنى ناعم. في هذه الحالة، تكون جميع المقابض موزعة على مسافة متساوية من نقطة الارتكاز. 
  * نقطة مستقيمة هي نقطة حيث يوجد مقبضان على خط مستقيم ويتصل جزءا الخط بمنحنى ناعم. في هذه الحالة، لا يلزم أن تكون المقابض على مسافة متساوية من نقطة الارتكاز. 
* عن طريق تحريك أو تحرير نقاط الارتكاز (التي تغير زاوية الخطوط)، يمكنك تعديل مظهر الشكل. 

لتحرير أشكال PowerPoint عبر نقاط التحرير، **Aspose.Slides** يوفر الفئة [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).

* تمثل مثيل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) .
* لاسترداد `GeometryPath` من مثيل `GeometryShape`، يمكنك استخدام طريقة [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) .
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) للأشكال الصلبة و [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) للأشكال المركبة.
* لإضافة مقاطع، يمكنك استخدام الطرق تحت [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) .
* باستخدام طريقتي [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/setstroke/) و [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/setfillmode/) ، يمكنك تعيين مظهر مسار الهندسة.
* باستخدام طريقة [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/getpathdata/) ، يمكنك استرداد مسار الهندسة لكائن `GeometryShape` كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* استخدم طريقتي [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) و [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (من فئة [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) ) لتحويل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) والعكس.

## **عمليات تحرير بسيطة**

يبين لك هذا الكود PHP كيفية

**إضافة خط** إلى نهاية المسار
```php

```

**إضافة خط** إلى موضع محدد على المسار:
```php

```

**إضافة منحنى بيزيه مكعب** إلى نهاية المسار:
```php

```

**إضافة منحنى بيزيه مكعب** إلى الموضع المحدد على المسار:
```php

```

**إضافة منحنى بيزيه تربيعي** إلى نهاية المسار:
```php

```

**إضافة منحنى بيزيه تربيعي** إلى الموضع المحدد على المسار:
```php

```

**إلحاق قوس معين** إلى مسار:
```php

```

**إغلاق الشكل الحالي** لمسار:
```php

```

**تعيين الموضع للنقطة التالية**:
```php

```

**إزالة جزء من المسار** عند فهرس معين:
```php

```


## **إضافة نقاط مخصصة إلى شكل**
1. أنشئ مثيلًا لفئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) وحدد النوع [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) .
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) من الشكل.
3. أضف نقطة جديدة بين النقطتين العلويتين على المسار.
4. أضف نقطة جديدة بين النقطتين السفلية على المسار.
5. طبّق المسار على الشكل.

يبين لك هذا الكود PHP كيفية إضافة نقاط مخصصة إلى شكل:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example1_image](custom_shape_1.png)

## **إزالة نقاط من شكل**

1. أنشئ مثيلًا لفئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) وحدد النوع [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) .
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) من الشكل.
3. احذف المقطع للمسار.
4. طبّق المسار على الشكل.

يبين لك هذا الكود PHP كيفية إزالة نقاط من شكل:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

1. احسب النقاط للشكل.
2. أنشئ مثيلًا لفئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) .
3. املأ المسار بالنقاط.
4. أنشئ مثيلًا لفئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) .
5. طبّق المسار على الشكل.

هذا Java يوضح لك كيفية إنشاء شكل مخصص:
```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example3_image](custom_shape_3.png)


## **إنشاء شكل مخصص مركب**

  1. أنشئ مثيلًا لفئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) .
  2. أنشئ المثيل الأول من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) .
  3. أنشئ المثيل الثاني من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) .
  4. طبّق المسارات على الشكل.

هذا الكود PHP يوضح لك إنشاء شكل مخصص مركب:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

هذا الكود PHP يوضح لك كيفية إنشاء شكل مخصص بزوايا منحنية (للداخل);
```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **اكتشاف ما إذا كان شكل الهندسة مغلقًا**

يُعرَّف الشكل المغلق بأنه الشكل الذي تتصل جميع جوانبه، مكوّنًا حدًا واحدًا دون فجوات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقدًا. يوضح مثال الكود التالي كيفية التحقق مما إذا كان شكل الهندسة مغلقًا:
```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```


## **تحويل GeometryPath إلى java.awt.Shape** 

1. أنشئ مثيلًا لفئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) .
2. أنشئ مثيلًا لفئة [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) .
3. حوّل مثيل [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) إلى مثيل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) باستخدام [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) .
4. طبّق المسارات على الشكل.

هذا الكود PHP—تنفيذ الخطوات أعلاه—يظهر عملية تحويل **GeometryPath** إلى **GraphicsPath**:
```php
  $pres = new Presentation();
  try {
    # إنشاء شكل جديد
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # الحصول على مسار الهندسة للشكل
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # إنشاء مسار رسومي جديد بالنص
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # تحويل المسار الرسومي إلى مسار هندسي
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # تعيين مزيج من مسار الهندسة الجديد ومسار الهندسة الأصلي إلى الشكل
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example5_image](custom_shape_5.png)

## **الأسئلة المتكررة**

**ماذا سيحدث للملء والحد بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ فقط يبدو الشكل يتغير. يتم تطبيق الملء والحد تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص بشكل صحيح مع هندسته؟**

استخدم طريقة [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setrotation/) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدِّر المنطقة المطلوبة من [الشريحة](/slides/ar/php-java/convert-powerpoint-to-png/) أو [الشكل](/slides/ar/php-java/create-shape-thumbnails/) نفسه إلى صيغة نقطية؛ هذا يبسط العمل لاحقًا مع الهندسات الثقيلة.