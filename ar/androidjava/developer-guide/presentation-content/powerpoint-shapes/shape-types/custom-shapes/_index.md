---
title: الشكل المخصص
type: docs
weight: 20
url: /ar/androidjava/custom-shape/
keywords: "شكل PowerPoint، شكل مخصص، عرض PowerPoint، Java، Aspose.Slides for Android via Java"
description: "إضافة شكل مخصص في عرض PowerPoint في Java"
---

# تغيير الشكل باستخدام نقاط التحرير
اعتبر مربعاً. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء لزاوية أو نقطة
* إضافة نقاط جديدة إلى المربع
* التلاعب بالنقاط على المربع، إلخ.

بشكل أساسي، يمكنك أداء المهام الموصوفة على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود.

## **نصائح لتعديل الأشكال**

![overview_image](custom_shape_0.png)

قبل أن تبدأ في تعديل أشكال PowerPoint من خلال نقاط التحرير، قد ترغب في أخذ هذه النقاط في الاعتبار حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، فإنه يفتقر إلى نقطة بداية أو نهاية. عندما يكون الشكل مفتوحًا، فإنه يحتوي على بداية ونهاية.
* تتكون جميع الأشكال من نقطتين ربط على الأقل مرتبطة ببعضها البعض بواسطة خطوط.
* يمكن أن تكون الخطوط إما مستقيمة أو منحنية. تحدد نقاط الربط طبيعة الخط.
* توجد نقاط الربط كنقاط زوايا، نقاط مستقيمة، أو نقاط ناعمة:
  * نقطة الزاوية هي نقطة حيث تنضم خطان مستقيمان بزاوية.
  * نقطة ناعمة هي نقطة حيث توجد نقطتان يدويتان في خط مستقيم وتنضم مقاطع الخط في منحنى ناعم. في هذه الحالة، تكون جميع المفاتيح مفصولة عن نقطة الربط بمسافة متساوية.
  * نقطة مستقيمة هي نقطة حيث توجد نقطتان يدويتان في خط مستقيم وتلك المقاطع في منحنى ناعم. في هذه الحالة، لا يجب أن تكون المفاتيح مفصولة عن نقطة الربط بمسافة متساوية.
* من خلال نقل أو تعديل نقاط الربط (التي تغير زاوية الخطوط)، يمكنك تغيير شكل مظهر الشكل.

لتعديل أشكال PowerPoint من خلال نقاط التحرير، تقدم **Aspose.Slides** فئة [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) وواجهة [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).

* يمثل مثيل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) مسار هندسي لكائن [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape).
* لاسترداد `GeometryPath` من مثيل `IGeometryShape`، يمكنك استخدام الطريقة [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--).
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) للأشكال *الصلبة* و [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) للأشكال *التركيبية*.
* لإضافة مقاطع، يمكنك استخدام الأساليب تحت [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).
* باستخدام الطرق [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) و [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-)، يمكنك تعيين مظهر لمسار هندسي.
* باستخدام الطريقة [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--)، يمكنك استرداد المسار الهندسي لشكل `GeometryShape` كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* استخدم الطرق [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) و [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (من فئة [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil)) لتحويل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) إلى [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) والعكس.

## **عمليات تحرير بسيطة**

هذا الكود في Java يوضح لك كيفية

**إضافة خط** إلى نهاية مسار

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**إضافة خط** إلى وضع محدد على مسار:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**إضافة منحنى بيزير مكعب** إلى نهاية مسار:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**إضافة منحنى بيزير مكعب** إلى الموضع المحدد على المسار:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**إضافة منحنى بيزير رباعي** إلى نهاية مسار:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**إضافة منحنى بيزير رباعي** إلى موضع محدد على مسار:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**إضافة قوس معين** إلى مسار:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**إغلاق الشكل الحالي** لمسار:

``` java
public void closeFigure();
```
**تعيين الموقع للنقطة التالية**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**إزالة مقطع المسار** عند فهرس معين:

``` java
public void removeAt(int index);
```

## **إضافة نقاط مخصصة إلى الشكل**
1. قم بإنشاء مثيل لفئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) وقم بتعيين النوع [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. احصل على مثيل لفئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) من الشكل.
3. أضف نقطة جديدة بين النقطتين العلوية على المسار.
4. أضف نقطة جديدة بين النقطتين السفلية على المسار.
5. قم بتطبيق المسار على الشكل.

هذا الكود في Java يوضح لك كيفية إضافة نقاط مخصصة إلى شكل:

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

##  إزالة النقاط من الشكل

1. قم بإنشاء مثيل لفئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) وقم بتعيين النوع [ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. احصل على مثيل لفئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) من الشكل.
3. قم بإزالة المقطع لمسار.
4. قم بتطبيق المسار على الشكل.

هذا الكود في Java يوضح لك كيفية إزالة النقاط من شكل:

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

##  **إنشاء شكل مخصص**

1. احسب النقاط للشكل.
2. قم بإنشاء مثيل لفئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. قم بملء المسار بالنقاط.
4. قم بإنشاء مثيل لفئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
5. قم بتطبيق المسار على الشكل.

هذا الكود في Java يوضح لك كيفية إنشاء شكل مخصص:

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

1. قم بإنشاء مثيل لفئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. قم بإنشاء مثيل أول لفئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. قم بإنشاء مثيل ثانٍ لفئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
4. قم بتطبيق المسارين على الشكل.

هذا الكود في Java يوضح لك كيفية إنشاء شكل مخصص مركب:

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

هذا الكود في Java يوضح لك كيفية إنشاء شكل مخصص بزوايا منحنية (إلى الداخل):

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

## **تحويل GeometryPath إلى java.awt.Shape** 

1. قم بإنشاء مثيل لفئة [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. قم بإنشاء مثيل لفئة [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. قم بتحويل مثيل [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) إلى مثيل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) باستخدام [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil).
4. قم بتطبيق المسارات على الشكل.

هذا الكود في Java—نموذج لتطبيق الخطوات أعلاه—يظهر عملية تحويل **GeometryPath** إلى **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // إنشاء شكل جديد
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // الحصول على المسار الهندسي للشكل
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // إنشاء مسار رسومي جديد مع نص
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "نص في الشكل";
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

    // تعيين مجموعة من المسار الهندسي الجديد والمسار الأصلي إلى الشكل
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)