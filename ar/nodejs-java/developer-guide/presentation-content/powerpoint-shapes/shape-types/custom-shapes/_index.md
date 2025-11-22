---
title: شكل مخصص
type: docs
weight: 20
url: /ar/nodejs-java/custom-shape/
keywords:
- شكل
- شكل مخصص
- إنشاء شكل
- هندسة
- هندسة الشكل
- مسار الهندسة
- نقاط المسار
- نقاط التحرير
- PowerPoint
- عرض تقديمي
- جافا سكريبت
- Aspose.Slides لـ Node.js عبر Java
description: "إضافة شكل مخصص إلى عرض تقديمي PowerPoint باستخدام جافا سكريبت"
---

## **تغيير شكل باستخدام نقاط التحرير**

تخيل مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء لزاوية أو نقطة
* إضافة نقاط جديدة إلى المربع
* معالجة النقاط على المربع، إلخ.

بشكل عام، يمكنك تنفيذ المهام الموصوفة على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود.

## **نصائح تحرير الأشكال**

![overview_image](custom_shape_0.png)

قبل الشروع في تحرير أشكال PowerPoint عبر نقاط التحرير، قد ترغب في مراعاة هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، لا يوجد له نقطة بداية أو نهاية. عندما يكون الشكل مفتوحًا، يكون له بداية ونهاية.
* جميع الأشكال تتكون من نقطتي تثبيت على الأقل مرتبطة ببعضها عبر خطوط
* الخط إما مستقيم أو منحني. تحدد نقاط التثبيت طبيعة الخط.
* نقاط التثبيت وجودها كنقاط زاوية، أو نقاط مستقيمة، أو نقاط ناعمة:
  * نقطة الزاوية هي نقطة يلتقي فيها خطان مستقيران بزاوية.
  * نقطة ناعمة هي نقطة يوجد فيها مقبضان على خط مستقيم وتلتقي مقاطع الخط في انحناء سلس. في هذه الحالة، تكون جميع المقابض مفصولة عن نقطة التثبيت بمسافة متساوية.
  * نقطة مستقيمة هي نقطة يوجد فيها مقبضان على خط مستقيم وتلتقي مقاطع الخط في انحناء سلس. في هذه الحالة، لا يلزم أن تكون المقابض مفصولة عن نقطة التثبيت بمسافة متساوية.
* عن طريق تحريك أو تحرير نقاط التثبيت (التي تغير زاوية الخطوط)، يمكنك تعديل مظهر الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** فئة [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) وفئة [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).

* تمثل مثيلة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) مسار هندسي لكائن [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
* لاسترجاع `GeometryPath` من مثيلة `GeometryShape`، يمكنك استخدام طريقة [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) .
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) للأشكال *الصلبة* و[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) للأشكال *المركبة*.
* لإضافة مقاطع، يمكنك استخدام الطرق الموجودة تحت [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
* باستخدام طرق [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) و[GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) يمكنك تعيين مظهر المسار الهندسي.
* باستخدام طريقة [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#getPathData--) يمكنك استرجاع المسار الهندسي لـ `GeometryShape` كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* استخدم طرق [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) و[graphicsPathToGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (من فئة [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil)) لتحويل [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) والعكس.

## **عمليات تحرير بسيطة**

يظهر لك هذا الشيفرة JavaScript كيفية

**إضافة خط** إلى نهاية المسار
```javascript
lineTo(point);
lineTo(x, y);
```

**إضافة خط** إلى موضع محدد على المسار:
```javascript
lineTo(point, index);
lineTo(x, y, index);
```

**إضافة منحنى بيزيه مكعب** إلى نهاية المسار:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**إضافة منحنى بيزيه مكعب** إلى الموضع المحدد على المسار:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**إضافة منحنى بيزيه تربيعي** إلى نهاية المسار:
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```

**إضافة منحنى بيزيه تربيعي** إلى موضع محدد على المسارع:
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```

**إلحاق قوس معين** إلى مسار:
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```

**إغلاق الشكل الحالي** للمسار:
```javascript
closeFigure();
```

**تحديد الموقع للنقطة التالية**:
```javascript
moveTo(point);
moveTo(x, y);
```

**إزالة مقطع المسار** عند فهرس معين:
```javascript
removeAt(index);
```


## **إضافة نقاط مخصصة إلى الشكل**

1. إنشاء مثيلة من فئة [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) وضبط النوع إلى [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType).
2. الحصول على مثيلة من فئة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) من الشكل.
3. إضافة نقطة جديدة بين النقطتين العلويتين على المسار.
4. إضافة نقطة جديدة بين النقطتين السُفْلَيتين على المسار.
5. تطبيق المسار على الشكل.

تظهر لك هذه الشيفرة JavaScript كيفية إضافة نقاط مخصصة إلى شكل:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example1_image](custom_shape_1.png)

## **إزالة نقاط من الشكل**

1. إنشاء مثيلة من فئة [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) وضبط النوع إلى [ShapeType.Heart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType).
2. الحصول على مثيلة من فئة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) من الشكل.
3. إزالة المقطع من المسار.
4. تطبيق المسار على الشكل.

تُظهر لك هذه الشيفرة JavaScript كيفية إزالة النقاط من الشكل:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

1. حساب النقاط للشكل.
2. إنشاء مثيلة من فئة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
3. تعبئة المسار بالنقاط.
4. إنشاء مثيلة من فئة [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
5. تطبيق المسار على الشكل.

تُظهر لك هذه الشيفرة JavaScript كيفية إنشاء شكل مخصص:
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example3_image](custom_shape_3.png)

## **إنشاء شكل مكوّن مخصص**

1. إنشاء مثيلة من فئة [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
2. إنشاء المثيلة الأولى من فئة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
3. إنشاء المثيلة الثانية من فئة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
4. تطبيق المسارات على الشكل.

تُظهر لك هذه الشيفرة JavaScript كيفية إنشاء شكل مكوّن مخصص:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

تظهر لك هذه الشيفرة JavaScript كيفية إنشاء شكل مخصص بزوايا منحنية ( إلى الداخل);
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **اكتشاف ما إذا كانت هندسة الشكل مغلقة**

يُعرّف الشكل المغلق بأنه الشكل الذي تتصل جميع جوانبه، مكوّناً حدًا واحدًا دون فراغات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقدًا. يوضح المثال البرمجي التالي كيفية التحقق مما إذا كانت هندسة الشكل مغلقة:
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```


## **تحويل GeometryPath إلى java.awt.Shape**

1. إنشاء مثيلة من فئة [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
2. إنشاء مثيلة من فئة [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. تحويل مثيلة [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) إلى مثيلة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) باستخدام [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil).
4. تطبيق المسارات على الشكل.

تُظهر لك هذه الشيفرة JavaScript — تنفيذ للخطوات أعلاه — عملية تحويل **GeometryPath** إلى **GraphicsPath**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // إنشاء شكل جديد
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // الحصول على مسار الهندسة للشكل
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // إنشاء مسار رسومي جديد مع النص
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // تحويل المسار الرسومي إلى مسار هندسي
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // تعيين دمج مسار الهندسة الجديد مع مسار الهندسة الأصلي إلى الشكل
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example5_image](custom_shape_5.png)

## **الأسئلة المتكررة**

**ماذا سيحدث للملء والحدود بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ يتغير فقط الحدود. يتم تطبيق الملء والحدود تلقائيًا على الهندسة الجديدة.

**كيف أقوم بتدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم طريقة [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setrotation/) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر المنطقة المطلوبة من الـ[شريحة](/slides/ar/nodejs-java/convert-powerpoint-to-png/) أو الـ[شكل](/slides/ar/nodejs-java/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ هذا يبسط العمل اللاحق مع الهندسات الكبيرة.