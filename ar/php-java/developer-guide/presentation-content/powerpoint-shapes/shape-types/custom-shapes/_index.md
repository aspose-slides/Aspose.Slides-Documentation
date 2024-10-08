---
title: الشكل المخصص
type: docs
weight: 20
url: /ar/php-java/custom-shape/
keywords: "شكل PowerPoint، شكل مخصص، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "إضافة شكل مخصص في عرض PowerPoint"
---

# تغيير شكل باستخدام نقاط تحرير
اعتبر مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك 

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء لزاوية أو نقطة
* إضافة نقاط جديدة إلى المربع
* تعديل النقاط على المربع، إلخ.

بشكل أساسي، يمكنك أداء المهام الموضحة على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل ما أو إنشاء شكل جديد من شكل موجود.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

قبل أن تبدأ في تحرير أشكال PowerPoint من خلال نقاط التحرير، قد ترغب في مراعاة هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، فإنه يفتقر إلى نقطة بدء أو نهاية. عندما يكون الشكل مفتوحًا، فإنه يحتوي على بداية ونهاية.
* تتكون جميع الأشكال من نقطتين ربط على الأقل مرتبطتين ببعضها البعض بواسطة خطوط.
* الخط إما مستقيم أو منحنٍ. تحدد نقاط الربط طبيعة الخط.
* توجد نقاط الربط كنقاط زاوية، نقاط مستقيمة، أو نقاط سلسة:
  * نقطة الزاوية هي نقطة حيث تلتقي خطان مستقيمان بزاوية.
  * نقطة سلسة هي نقطة حيث توجد مقبضان في خط مستقيم وتنضم مقاطع الخط في منحنى سلس. في هذه الحالة، تكون جميع المقابض مفصولة عن نقطة الربط بمسافة متساوية.
  * نقطة مستقيمة هي نقطة حيث توجد مقبضان في خط مستقيم وأن مقاطع ذلك الخط تنضم في منحنى سلس. في هذه الحالة، لا يتعين أن تكون المقابض مفصولة عن نقطة الربط بمسافة متساوية.
* من خلال تحريك أو تحرير نقاط الربط (التي تغير زاوية الخطوط)، يمكنك تغيير الشكل الذي يبدو عليه.

لتحرير أشكال PowerPoint من خلال نقاط التحرير، تقدم **Aspose.Slides** فئة [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) وواجهة [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).

* تمثل مثيل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) مسارًا هندسيًا لكائن [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape).
* لاسترداد `GeometryPath` من مثيل `IGeometryShape`، يمكنك استخدام طريقة [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--).
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) للأشكال *المتصلبة* و[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) للأشكال *المركبة*.
* لإضافة مقاطع، يمكنك استخدام الطرق الموجودة تحت [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).
* باستخدام الطرق [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) و[IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-)، يمكنك تعيين مظهر لمسار هندسي.
* باستخدام طريقة [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--)، يمكنك استرداد المسار الهندسي لشكل `GeometryShape` كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص هندسية إضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
* استخدم طرق [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) و[graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (من فئة [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)) لتحويل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) والعكس.

## **عمليات التحرير البسيطة**

يظهر لك هذا الكود PHP كيفية 

**إضافة خط** إلى نهاية مسار

```php

```
**إضافة خط** إلى موقع محدد على مسار:

```php

```
**إضافة منحنى بيزير مكعب** في نهاية مسار:

```php

```
**إضافة منحنى بيزير مكعب** إلى موقع معين على مسار:

```php

```
**إضافة منحنى بيزير رباعي** في نهاية مسار:

```php

```
**إضافة منحنى بيزير رباعي** إلى موقع محدد على مسار:

```php

```
**إلحاق قوس معين** إلى مسار:

```php

```
**إغلاق الشكل الحالي** لمسار:

```php

```
**تعيين الموقع للنقطة التالية**:

```php

```
**إزالة مقطع المسار** عند فهرس معين:

```php

```

## **إضافة نقاط مخصصة إلى الشكل**
1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) وقم بتعيين نوع [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) من الشكل.
3. أضف نقطة جديدة بين نقطتين علويتين على المسار.
4. أضف نقطة جديدة بين نقطتين سفليتين على المسار.
5. قم بتطبيق المسار على الشكل.

يظهر لك هذا الكود PHP كيفية إضافة نقاط مخصصة إلى شكل:

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

##  إزالة النقاط من الشكل

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) وقم بتعيين نوع [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) من الشكل.
3. قم بإزالة المقطع من المسار.
4. قم بتطبيق المسار على الشكل.

يظهر لك هذا الكود PHP كيفية إزالة النقاط من شكل:

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

##  **إنشاء شكل مخصص**

1. احسب النقاط للشكل.
2. أنشئ مثيلًا من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. املأ المسار بالنقاط.
4. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
5. قم بتطبيق المسار على الشكل.

يظهر لك هذا الكود Java كيفية إنشاء شكل مخصص:

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


## **إنشاء شكل مركب مخصص**

  1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
  2. أنشئ أول مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
  3. أنشئ مثيلًا ثانيًا من فئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
  4. قم بتطبيق المسارات على الشكل.

يظهر لك هذا الكود PHP كيفية إنشاء شكل مركب مخصص:

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

## **إنشاء شكل مخصص مع زوايا منحنية**

يظهر لك هذا الكود PHP كيفية إنشاء شكل مخصص مع زوايا منحنية (للداخل):

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

## **تحويل GeometryPath إلى java.awt.Shape** 

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. أنشئ مثيلًا من فئة [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. قم بتحويل مثيل [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) إلى مثيل [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) باستخدام [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).
4. قم بتطبيق المسارات على الشكل.

يوضح هذا الكود PHP - والذي يمثل تنفيذ الخطوات أعلاه - عملية تحويل **GeometryPath** إلى **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # إنشاء شكل جديد
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # الحصول على المسار الهندسي للشكل
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # إنشاء مسار رسومي جديد مع نص
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "نص في الشكل";
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
    # تعيين مجموعة من المسار الهندسي الجديد والمسار الهندسي الأصلي إلى الشكل
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)