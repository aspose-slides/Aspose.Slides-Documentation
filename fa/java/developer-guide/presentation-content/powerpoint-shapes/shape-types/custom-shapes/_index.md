---
title: سفارشی‌سازی شکل‌های ارائه در جاوا
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/java/custom-shape/
keywords:
- شکل سفارشی
- افزودن شکل
- ایجاد شکل
- تغییر شکل
- هندسه شکل
- مسیر هندسی
- نقاط مسیر
- نقاط ویرایش
- افزودن نقطه
- حذف نقطه
- عملیات ویرایش
- گوشه منحنی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای جاوا: مسیرهای هندسی، گوشه‌های منحنی، شکل‌های ترکیبی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان شکل‌های ارائه در Aspose.Slides را با ویرایش هندسه شکل از طریق نقاط ویرایش و مسیرهای هندسی سفارشی کرد. نشان می‌دهد چگونه با `GeometryPath` و `IGeometryPath` کار کنید تا شکل‌های موجود را تغییر دهید، عملیات پایه‌ای ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسه به‌روزشده را به شکل اعمال کنید.

همچنین نشان می‌دهد چگونه شکل‌های سفارشی و ترکیبی ایجاد کنید، شکل‌ها را با گوشه‌های منحنی بسازید، تعیین کنید آیا هندسه شکل بسته است یا نه، و بین `GeometryPath` و `java.awt.Shape` برای سناریوهای سفارشی‌سازی هندسه بیشتر تبدیل کنید.

## **تغییر شکل با استفاده از نقاط ویرایش**

یک مربع را در نظر بگیرید. در PowerPoint، با استفاده از **نقاط ویرایش** می‌توانید  

* گوشهٔ مربع را به داخل یا بیرون جابه‌جا کنید  
* انحنای یک گوشه یا نقطه را مشخص کنید  
* نقاط جدیدی به مربع اضافه کنید  
* نقاط مربع را دست‌کاری کنید و غیره  

به‌طور کلی می‌توانید این کارها را روی هر شکلی انجام دهید. با استفاده از نقاط ویرایش، می‌توانید یک شکل را تغییر دهید یا از یک شکل موجود یک شکل جدید بسازید.

## **نکات ویرایش شکل**

![تصویر_overview](custom_shape_0.png)

قبل از اینکه شروع به ویرایش شکل‌های PowerPoint از طریق نقاط ویرایش کنید، ممکن است بخواهید این نکات را دربارهٔ شکل‌ها در نظر بگیرید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.  
* وقتی شکل بسته است، نقطهٔ شروع یا انتهایی ندارد. وقتی شکل باز است، نقطهٔ شروع و پایان دارد.  
* تمام شکل‌ها حداقل شامل ۲ نقطهٔ لنگر هستند که توسط خطوط به یکدیگر متصل می‌شوند.  
* یک خط می‌تواند مستقیم یا منحنی باشد. نقاط لنگر طبیعت خط را تعیین می‌کنند.  
* نقاط لنگر به‌صورت نقاط گوشه‌ای، مستقیم یا صاف وجود دارند:  
  * نقطهٔ گوشه‌ای نقطه‌ای است که در آن ۲ خط مستقیم با زاویه‌ای به‌هم می‌پیوندند.  
  * نقطهٔ صاف نقطه‌ای است که در آن ۲ دستگیره در یک خط مستقیم قرار دارند و بخش‌های خط به‌صورت یک منحنی نرم به هم می‌رسند. در این حالت تمام دستگیره‌ها با فاصلهٔ مساوی از نقطهٔ لنگر جدا هستند.  
  * نقطهٔ مستقیم نقطه‌ای است که در آن ۲ دستگیره در یک خط مستقیم قرار دارند و بخش‌های خط به‌صورت یک منحنی نرم به هم می‌رسند. در این حالت دستگیره‌ها نیازی به داشتن فاصلهٔ مساوی از نقطهٔ لنگر ندارند.  
* با جابجا یا ویرایش نقاط لنگر (که زاویهٔ خطوط را تغییر می‌دهد)، می‌توانید ظاهر یک شکل را تغییر دهید.

برای ویرایش شکل‌های PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [**GeometryPath**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) و رابط [**IGeometryPath**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryPath) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) نمایانگر مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryShape) است.  
* برای دریافت `GeometryPath` از نمونهٔ `IGeometryShape` می‌توانید از متد [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) استفاده کنید.  
* برای تنظیم `GeometryPath` یک شکل، می‌توانید این متدها را به کار ببرید: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) برای *شکل‌های ثابت* و [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) برای *شکل‌های ترکیبی*.  
* برای افزودن قطعات می‌توانید از متدهای زیر [IGeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryPath) استفاده کنید.  
* با استفاده از متدهای [IGeometryPath.setStroke](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) و [IGeometryPath.setFillMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.  
* با استفاده از متد [IGeometryPath.getPathData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryPath#getPathData--) می‌توانید مسیر هندسی یک `GeometryShape` را به‌صورت آرایه‌ای از قطعات مسیر بازیابی کنید.  
* برای دسترسی به گزینه‌های سفارشی‌سازی اضافی هندسه شکل، می‌توانید [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) را به [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) تبدیل کنید.  
* از متدهای [geometryPathToGraphicsPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) و [graphicsPathToGeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (از کلاس [ShapeUtil](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapeUtil)) برای تبدیل [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) به [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) و برعکس استفاده کنید.

## **عملیات سادهٔ ویرایش**

این کد Java نشان می‌دهد چگونه  

**یک خط** به انتهای مسیر اضافه شود

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**یک خط** در موقعیت مشخصی از مسیر اضافه شود:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**یک منحنی Bezier درجهٔ سه** در انتهای مسیر اضافه شود:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**یک منحنی Bezier درجهٔ سه** به موقعیت مشخصی از مسیر اضافه شود:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**یک منحنی Bezier درجهٔ دو** در انتهای مسیر اضافه شود:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**یک منحنی Bezier درجهٔ دو** به موقعیت مشخصی از مسیر اضافه شود:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**یک قوس داده‌شده** به مسیر اضافه شود:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**بستن شکل فعلی** مسیر:

``` java
public void closeFigure();
```
**تنظیم موقعیت برای نقطهٔ بعدی**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**حذف قطعه مسیر** در ایندکس داده‌شده:

``` java
public void removeAt(int index);
```

## **اضافه کردن نقاط سفارشی به یک شکل**
1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryShape) ایجاد کنید و نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapeType) را تنظیم کنید.  
2. یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) از شکل دریافت کنید.  
3. یک نقطهٔ جدید بین دو نقطهٔ بالایی مسیر اضافه کنید.  
4. یک نقطهٔ جدید بین دو نقطهٔ پایینی مسیر اضافه کنید.  
5. مسیر را بر شکل اعمال کنید.

این کد Java نشان می‌دهد چگونه نقاط سفارشی به یک شکل اضافه کنید:

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
![مثال1_تصویر](custom_shape_1.png)

## **حذف نقاط از یک شکل**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryShape) ایجاد کنید و نوع [ShapeType.Heart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapeType) را تنظیم کنید.  
2. یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) از شکل دریافت کنید.  
3. قطعه مسیر را حذف کنید.  
4. مسیر را بر شکل اعمال کنید.

این کد Java نشان می‌دهد چگونه نقاط را از یک شکل حذف کنید:

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
![مثال2_تصویر](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

1. نقاط شکل را محاسبه کنید.  
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) ایجاد کنید.  
3. مسیر را با نقاط پر کنید.  
4. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryShape) ایجاد کنید.  
5. مسیر را بر شکل اعمال کنید.

این کد Java نشان می‌دهد چگونه یک شکل سفارشی ایجاد کنید:

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
![مثال3_تصویر](custom_shape_3.png)


## **ایجاد یک شکل ترکیبی سفارشی**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryShape) ایجاد کنید.  
2. یک نمونه اول از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) ایجاد کنید.  
3. یک نمونه دوم از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) ایجاد کنید.  
4. مسیرها را بر شکل اعمال کنید.

این کد Java نشان می‌دهد چگونه یک شکل ترکیبی سفارشی ایجاد کنید:

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
![مثال4_تصویر](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این کد Java نشان می‌دهد چگونه یک شکل سفارشی با گوشه‌های منحنی (به سمت داخل) ایجاد کنید:

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

## **تشخیص اینکه آیا هندسهٔ شکل بسته است**

یک شکل بسته به این معنا تعریف می‌شود که تمام طرف‌های آن به‌هم متصل هستند و مرزی یکپارچه بدون فاصله تشکیل می‌دهند. چنین شکلی می‌تواند یک فرم هندسی ساده یا یک قالب سفارشی پیچیده باشد. مثال کد زیر نشان می‌دهد چطور بررسی کنید که آیا هندسهٔ یک شکل بسته است یا نه:

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

## **تبدیل GeometryPath به java.awt.Shape**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryShape) ایجاد کنید.  
2. یک نمونه از کلاس [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ایجاد کنید.  
3. نمونهٔ [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) را با استفاده از [ShapeUtil](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapeUtil) به نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GeometryPath) تبدیل کنید.  
4. مسیرها را بر شکل اعمال کنید.

این کد Java—یک پیاده‌سازی از مراحل فوق—فرآیند تبدیل **GeometryPath** به **GraphicsPath** را نشان می‌دهد:

``` java
Presentation pres = new Presentation();
try {
    // ایجاد شکل جدید
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // دریافت مسیر هندسی شکل
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // ایجاد مسیر گرافیکی جدید با متن
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

    // تبدیل مسیر گرافیکی به مسیر هندسی
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // تنظیم ترکیب مسیر هندسی جدید و مسیر هندسی اصلی برای شکل
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![مثال5_تصویر](custom_shape_5.png)

## **سوالات متداول**

**پس از جایگزینی هندسه، پر کردن و خط بیرونی چه اتفاقی می‌افتد؟**  
استایل همراه شکل باقی می‌ماند؛ فقط محدوده تغییر می‌کند. پر کردن و خط بیرونی به‌صورت خودکار بر هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را به‌درستی همراه با هندسه‌اش بچرخانم؟**  
از متد [setRotation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#setRotation-float-) شکل استفاده کنید؛ چون هندسه به سیستم مختصات شکل متصل است، با شکل می‌چرخد.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**  
بله. بخش مورد نیاز [slide](/slides/fa/java/convert-powerpoint-to-png/) یا خود [شکل](/slides/fa/java/create-shape-thumbnails/) را به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های سنگین را ساده‌تر می‌کند.