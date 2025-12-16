---
title: تخصيص أشكال العرض على Android
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/androidjava/custom-shape/
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
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لأندرويد عبر Java: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---

## **تغيير شكل باستخدام نقاط التحرير**
اعتبر مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك 

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء لزاوية أو نقطة
* إضافة نقاط جديدة إلى المربع
* التلاعب بالنقاط على المربع، إلخ. 

في الأساس، يمكنك تنفيذ المهام الموصوفة على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

قبل البدء في تحرير أشكال PowerPoint عبر نقاط التحرير، قد ترغب في مراعاة هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، لا توجد نقطة بدء أو انتهاء. عندما يكون الشكل مفتوحًا، يكون له بداية ونهاية. 
* تتكون جميع الأشكال من نقطتي ارتباط على الأقل مرتبطتين ببعضهما عبر خطوط
* الخط إما مستقيم أو منحني. تحدد نقاط الارتكاز طبيعة الخط. 
* نقاط الارتكاز توجد كزوايا، أو نقاط مستقيمة، أو نقاط ناعمة:
  * نقطة الزاوية هي نقطة يلتقي فيها خطان مستقيمان بزاوية. 
  * نقطة ناعمة هي نقطة يوجد فيها مقبضان في خط مستقيم وتلتقي أقسام الخط بمنحنى ناعم. في هذه الحالة، يتم فصل جميع المقابض عن نقطة الارتكاز بمسافة متساوية. 
  * نقطة مستقيمة هي نقطة يوجد فيها مقبضان في خط مستقيم وتلتقي أقسام الخط بمنحنى ناعم. في هذه الحالة، لا يلزم أن تكون المقابض منفصلة عن نقطة الارتكاز بمسافة متساوية. 
* عن طريق تحريك أو تحرير نقاط الارتكاز (التي تغير زاوية الخطوط)، يمكنك تعديل مظهر الشكل. 

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** فئة [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) والواجهة [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).

* مثيل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) يمثل مسارًا هندسيًا لكائن [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape).
* لاسترداد `GeometryPath` من مثيل `IGeometryShape`، يمكنك استخدام طريقة [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) .
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) للأشكال *الصلبة* و[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) للأشكال *المركبة*.
* لإضافة مقاطع، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).
* باستخدام طرق [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) و[IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-)، يمكنك تعيين مظهر مسار هندسي.
* باستخدام طريقة [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--) ، يمكنك استرجاع مسار الهندسة لـ `GeometryShape` كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* استخدم طرق [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) و[graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (من فئة [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil)) لتحويل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) والعكس.

## **عمليات تحرير بسيطة**

يعرض لك هذا الكود Java كيفية

**إضافة خط** إلى نهاية المسار
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```

**إضافة خط** إلى موضع محدد على المسار:
``` java
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```

**إضافة منحنى بيزييه مكعب** إلى نهاية المسار:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**إضافة منحنى بيزييه مكعب** إلى الموضع المحدد على المسار:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```

**إضافة منحنى بيزييه تربيعي** إلى نهاية المسار:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```

**إضافة منحنى بيزييه تربيعي** إلى موضع محدد على المسار:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```

**إلحاق قوس معين** إلى مسار:
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**إغلاق الشكل الحالي** للمسار:
``` java
public void closeFigure();
```

**تحديد الموقع للنقطة التالية**:
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```

**إزالة مقطع المسار** عند فهرس محدد:
``` java
public void removeAt(int index);
```


## **إضافة نقاط مخصصة إلى شكل**
1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) وضع نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) من الشكل.
3. أضف نقطة جديدة بين النقطتين العلويتين على المسار.
4. أضف نقطة جديدة بين النقطتين السفلية على المسار.
5. طبّق المسار على الشكل.

يعرض لك هذا الكود Java كيفية إضافة نقاط مخصصة إلى شكل:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example1_image](custom_shape_1.png)

## **إزالة نقاط من شكل**

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) وضع نوع [ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) من الشكل.
3. أزل المقطع للمسار.
4. طبّق المسار على الشكل.

يعرض لك هذا الكود Java كيفية إزالة النقاط من شكل:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```

![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

1. احسب النقاط للشكل.
2. أنشئ مثيلًا من فئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. عبئ المسار بالنقاط.
4. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
5. طبّق المسار على الشكل.

يعرض لك هذا الكود Java كيفية إنشاء شكل مخصص:
``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example3_image](custom_shape_3.png)


## **إنشاء شكل مخصص مركب**

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. أنشئ المثيل الأول من فئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. أنشئ المثيل الثاني من فئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
4. طبّق المسارات على الشكل.

يعرض لك هذا الكود Java كيفية إنشاء شكل مخصص مركب:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```

![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

يعرض لك هذا الكود Java كيفية إنشاء شكل مخصص بزوايا منحنية (متجهة إلى الداخل);
```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```


## **اكتشف ما إذا كانت هندسة الشكل مغلقة**

الشكل المغلق يُعرّف بأنه الشكل الذي تتصل جميع جوانبه، مكوّناً حدًا واحدًا دون فراغات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقدًا. يوضح مثال الشيفرة التالي كيفية التحقق مما إذا كانت هندسة الشكل مغلقة:
```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```


## **تحويل GeometryPath إلى java.awt.Shape** 

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. أنشئ مثيلًا من فئة [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. حوّل مثيل [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) إلى مثيل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) باستخدام [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil).
4. طبّق المسارات على الشكل.

يعرض لك هذا الكود Java—تنفيذ للخطوات أعلاه—عملية التحويل من **GeometryPath** إلى **GraphicsPath**:
``` java
Presentation pres = new Presentation();
try {
    // إنشاء شكل جديد
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // الحصول على مسار الهندسة للشكل
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // إنشاء مسار رسومي جديد بالنص
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // تحويل المسار الرسومي إلى مسار هندسي
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // تعيين دمج مسار الهندسة الجديد والمسار الأصلي إلى الشكل
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```

![example5_image](custom_shape_5.png)

## **الأسئلة الشائعة**

**ماذا سيحدث للملء والحدود بعد استبدال الهندسة؟**  
يبقى النمط مع الشكل؛ يتغير فقط المخطط. يتم تطبيق الملء والحدود تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع الهندسة الخاصة به بشكل صحيح؟**  
استخدم طريقة [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) للShape؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**  
نعم. قم بتصدير منطقة [الشريحة](/slides/ar/androidjava/convert-powerpoint-to-png/) المطلوبة أو الـ[شكل](/slides/ar/androidjava/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ هذا يبسط العمل الإضافي مع الهندسات المعقدة.