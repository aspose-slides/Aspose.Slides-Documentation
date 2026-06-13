---
title: سفارشی‌سازی اشکال ارائه در اندروید
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/androidjava/custom-shape/
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
- عملیات ویرایشی
- گوشه منحنی
- PowerPoint
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی شکل‌ها در ارائه‌های PowerPoint با Aspose.Slides برای اندروید از طریق جاوا: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه می‌توان شکل‌های ارائه در Aspose.Slides را از طریق ویرایش هندسه شکل با نقاط و مسیرهای هندسی سفارشی کرد. نشان می‌دهد چگونه با `GeometryPath` و `IGeometryPath` برای اصلاح شکل‌های موجود، انجام عملیات پایه ویرایش مسیر، افزودن یا حذف نقاط، و اعمال هندسه به‌روزشده به یک شکل کار کرد.

همچنین نحوه ایجاد شکل‌های سفارشی و مرکب، ساخت شکل‌ها با گوشه‌های منحنی، تعیین اینکه آیا هندسه یک شکل بسته است یا نه، و تبدیل بین `GeometryPath` و `java.awt.Shape` برای سناریوهای سفارشی‌سازی هندسه اضافی را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایش**
یک مربع را در نظر بگیرید. در PowerPoint، با استفاده از **نقاط ویرایش** می‌توانید  

* گوشه مربع را به داخل یا بیرون حرکت دهید  
* انحنا برای یک گوشه یا نقطه را مشخص کنید  
* نقاط جدیدی به مربع اضافه کنید  
* نقاط روی مربع را دستکاری کنید و غیره  

در اصل، می‌توانید این کارها را روی هر شکل انجام دهید. با استفاده از نقاط ویرایش می‌توانید یک شکل را تغییر دهید یا شکل جدیدی از شکل موجود بسازید. 

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

قبل از اینکه شروع به ویرایش شکل‌های PowerPoint از طریق نقاط ویرایش کنید، ممکن است بخواهید این نکات در مورد شکل‌ها را مدنظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.  
* وقتی یک شکل بسته است، نقطه شروع یا پایان ندارد. وقتی شکل باز است، نقطه آغاز و انتها دارد.  
* همه شکل‌ها از حداقل دو نقطه لنگر تشکیل شده‌اند که توسط خطوط به یکدیگر متصل هستند.  
* یک خط می‌تواند مستقیم یا منحنی باشد. نقاط لنگر ماهیت خط را تعیین می‌کنند.  
* نقاط لنگر به صورت نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف وجود دارند:  
  * یک نقطه گوشه‌ای نقطه‌ای است که در آن دو خط مستقیم با یک زاویه به هم می‌پیوندند.  
  * یک نقطه صاف نقطه‌ای است که در آن دو دستگیره در یک خط مستقیم وجود دارند و بخش‌های خط به صورت یک منحنی نرم به هم می‌پیوندند. در این حالت، تمامی دستگیره‌ها فاصله برابر از نقطه لنگر دارند.  
  * یک نقطه مستقیم نقطه‌ای است که در آن دو دستگیره در یک خط مستقیم وجود دارند و بخش‌های خط به صورت یک منحنی نرم به هم می‌پیوندند. در این حالت، دستگیره‌ها لازم نیست فاصله برابر از نقطه لنگر داشته باشند.  
* با جابه‌جایی یا ویرایش نقاط لنگر (که زاویه خطوط را تغییر می‌دهد)، می‌توانید ظاهر شکل را تغییر دهید.  

برای ویرایش شکل‌های PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [**GeometryPath**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) و رابط [**IGeometryPath**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryPath) را ارائه می‌دهد.

* یک [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) نمونه‌ای از مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryShape) را نشان می‌دهد.  
* برای دریافت `GeometryPath` از نمونه `IGeometryShape` می‌توانید از روش [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) استفاده کنید.  
* برای تنظیم `GeometryPath` برای یک شکل، می‌توانید از این روش‌ها استفاده کنید: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) برای *شکل‌های جامد* و [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) برای *شکل‌های مرکب*.  
* برای افزودن بخش‌ها می‌توانید از روش‌های زیر در [IGeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryPath) استفاده کنید.  
* با استفاده از روش‌های [IGeometryPath.setStroke](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) و [IGeometryPath.setFillMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) می‌توانید ظاهر مسیر هندسی را تنظیم کنید.  
* با استفاده از روش [IGeometryPath.getPathData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryPath#getPathData--) می‌توانید مسیر هندسی یک `GeometryShape` را به‌عنوان آرایه‌ای از بخش‌های مسیر دریافت کنید.  
* برای دسترسی به گزینه‌های سفارشی‌سازی هندسه شکل اضافی، می‌توانید [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) را به [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) تبدیل کنید.  
* از روش‌های [geometryPathToGraphicsPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) و [graphicsPathToGeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (از کلاس [ShapeUtil](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapeUtil)) برای تبدیل [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) به [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) و بالعکس استفاده کنید.

## **عملیات ویرایشی ساده**

این کد Java نشان می‌دهد چگونه  

**اضافه کردن خط** به انتهای مسیر  

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```  
**اضافه کردن خط** به موقعیت مشخصی روی مسیر:  

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```  
**اضافه کردن منحنی Bezier مکعبی** در انتهای مسیر:  

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```  
**اضافه کردن منحنی Bezier مکعبی** به موقعیت مشخصی روی مسیر:  

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```  
**اضافه کردن منحنی Bezier درجه دو** در انتهای مسیر:  

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```  
**اضافه کردن منحنی Bezier درجه دو** به موقعیت مشخصی روی مسیر:  

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```  
**پیوست یک قوس مشخص** به مسیر:  

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```  
**بستن شکل فعلی** مسیر:  

``` java
public void closeFigure();
```  
**تنظیم موقعیت نقطه بعدی**:  

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```  
**حذف بخش مسیر** در یک اندیس مشخص:  

``` java
public void removeAt(int index);
```

## **افزودن نقاط سفارشی به یک شکل**
1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryShape) ایجاد کنید و نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapeType) را تنظیم کنید.  
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) را از شکل دریافت کنید.  
3. یک نقطه جدید بین دو نقطه بالایی مسیر اضافه کنید.  
4. یک نقطه جدید بین دو نقطه پایینی مسیر اضافه کنید.  
5. مسیر را به شکل اعمال کنید.  

این کد Java نشان می‌دهد چگونه نقاط سفارشی به یک شکل اضافه شود:

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

## **حذف نقاط از یک شکل**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryShape) ایجاد کنید و نوع [ShapeType.Heart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapeType) را تنظیم کنید.  
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) را از شکل دریافت کنید.  
3. بخش مسیر را حذف کنید.  
4. مسیر را به شکل اعمال کنید.  

این کد Java نشان می‌دهد چگونه نقاط از یک شکل حذف شوند:

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

## **ایجاد یک شکل سفارشی**

1. نقاط شکل را محاسبه کنید.  
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) ایجاد کنید.  
3. مسیر را با نقاط پر کنید.  
4. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryShape) ایجاد کنید.  
5. مسیر را به شکل اعمال کنید.  

این کد Java نشان می‌دهد چگونه یک شکل سفارشی ایجاد شود:

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


## **ایجاد یک شکل سفارشی مرکب**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryShape) ایجاد کنید.  
2. یک نمونه اول از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) ایجاد کنید.  
3. یک نمونه دوم از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) ایجاد کنید.  
4. مسیرها را به شکل اعمال کنید.  

این کد Java نشان می‌دهد چگونه یک شکل سفارشی مرکب ایجاد شود:

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

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این کد Java نشان می‌دهد چگونه یک شکل سفارشی با گوشه‌های منحنی (به سمت داخل) ایجاد کنید؛

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

## **پیدا کردن اینکه آیا هندسه یک شکل بسته است یا نه**

یک شکل بسته به این معناست که تمام اضلاع آن به هم متصل هستند و یک مرز واحد بدون فاصله تشکیل می‌دهند. چنین شکلی می‌تواند یک فرم هندسی ساده یا یک طرح سفارشی پیچیده باشد. مثال کد زیر نشان می‌دهد چگونه بررسی شود آیا هندسه یک شکل بسته است:

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

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryShape) ایجاد کنید.  
2. یک نمونه از کلاس [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ایجاد کنید.  
3. با استفاده از [ShapeUtil](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapeUtil) نمونه‌ی [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) را به نمونه‌ی [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GeometryPath) تبدیل کنید.  
4. مسیرها را به شکل اعمال کنید.  

این کد Java—پیاده‌سازی گام‌های فوق—فرآیند تبدیل **GeometryPath** به **GraphicsPath** را نشان می‌دهد:

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
![example5_image](custom_shape_5.png)

## **سؤالات متداول**

**پس از جایگزینی هندسه، پرکننده و خط دور چه می‌شوند؟**  
استایل همراه شکل باقی می‌ماند؛ فقط contour تغییر می‌کند. پرکننده و خط دور به‌صورت خودکار بر هندسه جدید اعمال می‌شوند.

**چگونه می‌توان یک شکل سفارشی را به‌درستی همراه با هندسه‌اش چرخاند؟**  
از روش [setRotation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#setRotation-float-) شیء استفاده کنید؛ هندسه به‌دلیل اتصال به سیستم مختصات خود شکل، همراه آن می‌چرخد.

**آیا می‌توان یک شکل سفارشی را به تصویر تبدیل کرد تا نتیجه «قفل» شود؟**  
بله. ناحیهٔ مورد نیاز را از [slide](/slides/fa/androidjava/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/androidjava/create-shape-thumbnails/) به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های سنگین را ساده‌تر می‌کند.