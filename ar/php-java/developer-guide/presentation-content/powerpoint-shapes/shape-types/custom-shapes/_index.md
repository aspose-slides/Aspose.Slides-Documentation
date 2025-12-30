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
- مسار هندسي
- نقاط المسار
- نقاط تعديل
- إضافة نقطة
- إزالة نقطة
- عملية تعديل
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java: مسارات هندسية، زوايا منحنية، أشكال مركبة."
---

## **تغيير شكل باستخدام نقاط التعديل**
تخيل مربعًا. في PowerPoint، باستخدام **نقاط التعديل**، يمكنك

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء لزاوية أو نقطة
* إضافة نقاط جديدة إلى المربع
* التلاعب بالنقاط على المربع، إلخ.

في الأساس، يمكنك أداء المهام الموصوفة على أي شكل. باستخدام نقاط التعديل، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود.

## **نصائح تعديل الشكل**

![صورة_نظرة_عامّة](custom_shape_0.png)

قبل أن تبدأ في تعديل أشكال PowerPoint عبر نقاط التعديل، قد ترغب في مراعاة النقاط التالية حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، لا يمتلك نقطة بدء أو نهاية. عندما يكون الشكل مفتوحًا، له بداية ونهاية.
* جميع الأشكال تتكون من نقطتي تثبيت على الأقل ترتبطان ببعضهما عبر خطوط.
* الخط إما مستقيم أو منحني. تحدد نقاط التثبيت طبيعة الخط.
* توجد نقاط التثبيت كالنقاط الزاوية أو النقاط المستقيمة أو النقاط السلسة:
  * النقطة الزاوية هي نقطة يلتقي فيها خطان مستقيماً بزاوية.
  * النقطة السلسة هي نقطة يكون فيها مقبضان في خط مستقيم وتلتحم أجزاء الخط في منحنى سلس. في هذه الحالة تكون جميع المقابض مفصولة عن نقطة التثبيت بمسافة متساوية.
  * النقطة المستقيمة هي نقطة يكون فيها مقبضان في خط مستقيم وتلتحم أجزاء الخط في منحنى سلس. في هذه الحالة لا يلزم أن تكون المقابض مفصولة عن نقطة التثبيت بمسافة متساوية.
* بتحريك أو تعديل نقاط التثبيت (مما يغيّر زاوية الخطوط)، يمكنك تغيير مظهر الشكل.

لتحرير أشكال PowerPoint عبر نقاط التعديل، **Aspose.Slides** توفر الفئة [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) والواجهة [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).

* مثيل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) يمثل مسار هندسي لكائن [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape).
* لاسترداد `GeometryPath` من مثيل `IGeometryShape`، يمكنك استخدام الطريقة [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--) .
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) للأشكال *الصلبة* و[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) للأشكال *المركبة*.
* لإضافة مقاطع، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).
* باستخدام الطريقتين [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) و[IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-)، يمكنك تعيين مظهر المسار الهندسي.
* باستخدام الطريقة [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--)، يمكنك استرجاع مسار هندسي لـ `GeometryShape` كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص هندسة إضافية للشكل، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* استخدم [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) و[graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (من الفئة [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)) لتحويل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) والعكس.

## **عمليات تعديل بسيطة**

يظهر هذا الكود PHP كيفية

**إضافة خط** إلى نهاية مسار
```php

```

**إضافة خط** إلى موضع محدد في مسار:
```php

```

**إضافة منحنى بيزيه مكعب** إلى نهاية مسار:
```php

```

**إضافة منحنى بيزيه مكعب** إلى موضع محدد في مسار:
```php

```

**إضافة منحنى بيزيه رباعي** إلى نهاية مسار:
```php

```

**إضافة منحنى بيزيه رباعي** إلى موضع محدد في مسار:
```php

```

**إلحاق قوس معين** إلى مسار:
```php

```

**إغلاق الشكل الحالي** في مسار:
```php

```

**تحديد موضع النقطة التالية**:
```php

```

**إزالة مقطع المسار** عند فهرس معين:
```php

```


## **إضافة نقاط مخصصة إلى شكل**
1. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) وتعيين النوع [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. الحصول على نسخة من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) من الشكل.
3. إضافة نقطة جديدة بين النقطتين العلويتين في المسار.
4. إضافة نقطة جديدة بين النقطتين السُفليتين في المسار.
5. تطبيق المسار على الشكل.

يظهر هذا الكود PHP كيفية إضافة نقاط مخصصة إلى شكل:
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

1. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) وتعيين النوع [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. الحصول على نسخة من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) من الشكل.
3. إزالة المقطع من المسار.
4. تطبيق المسار على الشكل.

يظهر هذا الكود PHP كيفية إزالة نقاط من شكل:
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

1. حساب النقاط اللازمة للشكل.
2. إنشاء نسخة من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. ملء المسار بالنقاط.
4. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
5. تطبيق المسار على الشكل.

يظهر هذا المثال Java كيفية إنشاء شكل مخصص:
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

1. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. إنشاء النسخة الأولى من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. إنشاء النسخة الثانية من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
4. تطبيق المسارات على الشكل.

يظهر هذا الكود PHP كيفية إنشاء شكل مخصص مركب:
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

يظهر هذا الكود PHP كيفية إنشاء شكل مخصص بزوايا منحنية (متجهة للداخل);
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


## **اكتشاف ما إذا كانت هندسة الشكل مغلقة**

يُعرّف الشكل المغلق بأنه الشكل الذي تتصل جميع جوانبه، مُكوِّنًا حدًا واحدًا دون فجوات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقّدًا. يوضح المثال البرمجي التالي كيفية التحقق مما إذا كانت هندسة الشكل مغلقة:
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

1. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. إنشاء نسخة من فئة [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. تحويل نسخة [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) إلى نسخة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) باستخدام [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).
4. تطبيق المسارات على الشكل.

يظهر هذا الكود PHP—تنفيذ للخطوات أعلاه—عملية تحويل **GeometryPath** إلى **GraphicsPath**:
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
    # تعيين مزيج من مسار هندسي جديد والمسار الهندسي الأصلي إلى الشكل
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example5_image](custom_shape_5.png)

## **الأسئلة المتكررة**

**ماذا يحدث للملء والحد بعد استبدال الهندسة؟**

يبقى النمط مرتبطًا بالشكل؛ فقط المخطط يتغير. يتم تطبيق الملء والحد تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم طريقة الشكل [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setrotation/)؛ حيث تدور الهندسة مع الشكل لأنها مربوطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. قم بتصدير المنطقة المطلوبة من [الشريحة](/slides/ar/php-java/convert-powerpoint-to-png/) أو [الشكل](/slides/ar/php-java/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ هذا يبسط العمل اللاحق مع الهندسات الثقيلة.