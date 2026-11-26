---
title: سفارشی‌سازی اشکال ارائه در جاوا
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
- عملیات ویرایشی
- گوشه منحنی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای Java: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **مرور کلی**

این مقاله نحوهٔ سفارشی‌سازی اشکال ارائه در Aspose.Slides را با ویرایش هندسهٔ شکل از طریق نقاط و مسیرهای هندسی توضیح می‌دهد. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) و [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) برای اصلاح شکل‌های موجود، انجام عملیات پایهٔ ویرایش مسیر، افزودن یا حذف نقاط، و اعمال هندسهٔ به‌روز‌شده به یک شکل کار کنید.

همچنین نحوهٔ ایجاد اشکال سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسهٔ یک شکل بسته است، بازرسی عناصر شکل، و تبدیل خطوط متن Java AWT به مسیرهای هندسی را نشان می‌دهد.

## **تغییر شکل با استفاده از نقاط ویرایش**

در PowerPoint می‌توانید با **نقاط ویرایش** یک مربع را تغییر دهید:

* یک گوشه را به داخل یا خارج حرکت دهید.
* منحنی‌گیری در یک نقطه را تنظیم کنید.
* نقاط جدیدی اضافه کنید.

ویرایش نقاط به شما امکان می‌دهد outlines یک شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایهٔ یک شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در ذهن داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل به‌وسیلهٔ بخش‌ها تشکیل شده است.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر می‌توانند به‌صورت نقطهٔ گوشه، نقطهٔ مستقیم یا نقطهٔ صاف باشند:
  * در یک نقطهٔ گوشه، بخش‌های مجاور می‌توانند با زاویه‌ای به هم برسند.
  * در یک نقطهٔ صاف، دو دستهٔ کنترل هم‌راستا و به‌صورت مساوی از نقطهٔ لنگر فاصله دارند.
  * در یک نقطهٔ مستقیم، دو دستهٔ کنترل هم‌راستا هستند اما می‌توانند فاصله‌های متفاوتی از نقطهٔ لنگر داشته باشند.
* حرکت نقاط لنگر یا تنظیم دسته‌های آن‌ها، outline شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) و اینترفیس [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) را ارائه می‌دهد.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) از یک نمونهٔ [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) می‌توانید از متد [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) برای یک شکل، می‌توانید این متدها را استفاده کنید: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) برای شکل‌های با مسیر واحد و [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) برای شکل‌های با مسیرهای متعدد.
* برای افزودن بخش‌ها، می‌توانید از متدهای زیر اینترفیس [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) استفاده کنید.
* با استفاده از متدهای [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) و [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.
* برای دسترسی به گزینه‌های سفارشی‌سازی اضافی هندسهٔ شکل، می‌توانید یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) را از طریق [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن بخوانید و بخش‌ها را روی یک [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) بازپخش کنید.

## **عملیات ویرایشی ساده**

از متدهای زیر برای ویرایش مسیر هندسی استفاده کنید. بارگذاری‌هایی که یک ایندکس می‌پذیرند، بخش را در همان موقعیت ایندکس صفر‑پایه در آرایهٔ بخش‌های مسیر وارد می‌کنند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج خط مستقیم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| افزودن یا درج منحنی کُبیک Bézier با دو نقطهٔ کنترل و نقطهٔ انتهایی. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| افزودن یا درج منحنی درجه‌دو Bézier با یک نقطهٔ کنترل و نقطهٔ انتهایی. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| افزودن قوس بیضوی با ابعاد و زاویهٔ مشخص به درجه. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| بستن شکل فعلی با اتصال نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| حذف یک بخش در ایندکس صفر‑پایه. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) وارد می‌کند و مسیر ویرایش‌شده را با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) اعمال می‌نماید. مختصات‌ها به‌صورت محلی نسبت به شکل هستند: هر دو نقطه جدید در مرکز شکل، ۱۰۰ پوینت از سمت چپ و ۵۰ پوینت از بالا قرار دارند. ایندکس‌های بخش ۱ و ۴ آن‌ها را روی لبهٔ بالا و پایین قرار می‌دهند و این لبه‌ها را به داخل می‌کشند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **حذف نقاط از یک شکل**

این مثال outline شکل قلبی را با حذف بخش در ایندکس صفر‑پایه ۲ با [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) تغییر می‌دهد. اعمال مسیر تغییر یافته با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) contour شکل را به‌روزرسانی می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

این مثال یک ستارهٔ پنج‌شیار با استفاده از [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی به‌صورت متناوب ۱۰۰ و ۵۰ پوینت تعریف می‌شوند؛ گام ۷۲ درجه نقاط پنج‌تایی را به‌صورت برابر فاصله می‌دهد. مسیر با [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) بسته می‌شود و با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) به یک شکل مستطیلی اعمال می‌گردد و outline آن را جایگزین می‌کند.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **ایجاد یک شکل ترکیبی سفارشی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) بسته برای یک‑سوم بالایی و یک‑سوم پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) یک شکل ترکیبی واحد با یک فاصله در یک‑سوم میانی ایجاد می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال بخش‌های مستقیم را با [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) ترکیب می‌کند تا شکلی با گوشه‌های داخل‌منحنی ایجاد شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را در پوینت‌ها تنظیم می‌کند و سوئپ ‑۹۰ درجه یک ربع بیضی خلاف ساعت‌گرد می‌کشد. مسیر کامل با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) اعمال می‌شود و ارائه در فرمت PPTX ذخیره می‌شود.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

این کمکی بررسی می‌کند که آیا هر مسیر هندسی غیر خالی با یک بخش بسته پایان می‌یابد یا نه. با خواندن [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) و مقایسهٔ فرمان نهایی بخش با [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) برابر با [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) این کار انجام می‌شود. در صورتی که مسیر غیر خالی وجود نداشته باشد، false بر می‌گرداند. این چک فقط فرمان نهایی هر مسیر را بررسی می‌کند؛ زیرشکل‌های داخل مسیر را بررسی نمی‌کند. مثال برای یک مستطیل مقدار `true` چاپ می‌کند.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **بررسی فرمان‌های مسیر هندسی**

فایل [contour.pptx](contour.pptx) را دانلود کنید و در پوشهٔ کاری برنامه قرار دهید. اولین شکل در اسلاید اول دارای لبهٔ بالایی مستقیم، یک منحنی کُبیک Bézier و لبهٔ بستهٔ مستقیم است. برای خواندن مسیرهای شکل از [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) و برای خواندن بخش‌های هر مسیر به ترتیب رسم از [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) استفاده کنید. برای هر بخش، [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) فرمان را شناسایی می‌کند و نحوهٔ تفسیر مقادیر برگشتی توسط [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) را تعیین می‌نماید.

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

موقعیت شکل (۲۰۰، ۱۰۰) پوینت بر روی اسلاید است. مختصات گزارش‌شده به‌صورت محلی نسبت به شکل هستند، به‌طوری که (۰، ۰) در گوشهٔ بالایی‑چپ آن قرار دارد، x به‌سمت راست و y به‌سمت پایین افزایشی است. بخش بسته بدون مختصات اضافه به نقطهٔ شروع بر می‌گردد.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **استخراج و بازرسی عناصر شکل**

از [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) برای بازرسی یک شکل موجود به‌عنوان عناصر حاوی نقاط مسیر و انواع نقاط استفاده کنید. هر [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) بازگردانده‌شده را به [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) تبدیل کنید تا آرایهٔ نقاط و انواع را از طریق متدهای [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) و [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) دریافت کنید. این نمایش برای تحلیل contour یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل input.pptx را باز می‌کند، اولین GeometryShape را مستقیماً در اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌نماید. برای دیدن خروجی‌های هر دو نوع (خطی و منحنی) از یک ارائه حاوی شکل با بخش‌های مستقیم و منحنی استفاده کنید. این روش داخل گروه‌ها جستجو نمی‌کند.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // نوع بخش را حفظ کنید، بدون پرچم‌ها.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

آرایه‌ها بر اساس ایندکس مرتبط هستند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` شروع یک شکل را نشان می‌دهد و نوع `1` خطی از نقطهٔ قبلی به نقطهٔ فعلی می‌کشد. یک بخش Bézier درجه‌سه از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌هم می‌چسباند و نقطهٔ انتهایی را برای بستن بررسی می‌کند.

انواع نقطه همچنین شامل پرچم‌ها هستند. برای شناسایی نوع بخش با ماسک `0x07` استفاده کنید و برای تشخیص زیرمسیر بسته پرچم `0x80` را جداگانه بررسی کنید. برای مثال `129` (`0x81`) به معنی نقطهٔ انتهایی خطی است که زیرمسیر را می‌بندد و `131` (`0x83`) به معنی نقطهٔ انتهایی Bézier است که یک زیرمسیر را می‌بندد. جاوا این پرچم‌ها را در بایت‌های علامت‌دار ذخیره می‌کند؛ ماسک‌گذاری مقدار بیتی اصلی را حفظ می‌کند. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را از دست می‌دهد. سایر پرچم‌ها مانند dash (`0x10`) و marker (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط برحسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای شکل بدون گروه، مختصات استخراج‌شده قبلاً موقعیت بازگردانده‌شده توسط [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) و [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) را شامل می‌شود و عرض و ارتفاع فعلی آن را منعکس می‌کند. برای مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` دارای مرزهای contour `(100, 200)`–`(220, 280)` است. موقعیت شکل را دوباره افزودن نکنید. برای به‌دست آوردن مختصات نسبت به چارچوب بدون چرخش، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل را که توسط [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) بازگردانده می‌شود، یا وارونگی افقی و عمودی اعمال نمی‌کنند. برای بازآفرینی contour نمایش داده‌شده، این تبدیل‌ها را حول مرکز شکل اعمال کنید. برای اشکال گروهی، همچنین نگاشت مختصات گروه و تبدیل‌ها را در نظر بگیرید؛ فرض نکنید نقاط استخراج‌شده نهایً مختصات اسلاید رندر شده هستند یا ترجمه/مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده باشد.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده فقط توصیف‌کنندهٔ contour هستند؛ تغییر آن‌ها شکل اصلی را به‌روزرسانی نمی‌کند. زمانی این روش را انتخاب کنید که تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد. برای دریافت دستورات هندسی در سیستم مختصات محلی شکل یا برای ویرایش هندسه، از [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) یا [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) اعمال کنید.

## **تبدیل یک Shape Java AWT به GeometryPath**

این مثال outline مستطیلی را با متنی ترکیب می‌کند که به هندسه تبدیل شده است. متد [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) outline را غیرفعال می‌کند. یک [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) متن را در یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ایجاد می‌کند. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن move، line، quadratic، cubic و بخش‌های بسته را فراهم می‌کند که مثال آن‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) بازپخش می‌کند.

متن از فونت Arial با اندازهٔ ۴۰ پوینت استفاده می‌کند. outline به‌صورت افقی ۲۰ پوینت جابجا شده و با بالای بصری‌اش ۱۰ پوینت زیر لبهٔ بالایی شکل موقعیت می‌یابد. مسیر متن پر می‌شود، در حالی که مستطیل اصلی به‌صورت outline می‌ماند. اعمال هر دو مسیر با [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) یک شکل واحد شامل مستطیل و متن تولید می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // ایجاد شکل جدید
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // دریافت مسیر هندسی شکل
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // ایجاد مسیر گرافیکی جدید با متن
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // تبدیل مسیر گرافیکی به مسیر هندسی
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // تنظیم ترکیب مسیر هندسی جدید و مسیر هندسی اصلی به شکل
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **پرسش‌های متداول**

**پس از جایگزینی هندسه، پر و outline چه اتفاقی می‌افتند؟**

سبک با شکل باقی می‌ماند؛ فقط contour تغییر می‌کند. پر و outline به‌صورت خودکار بر هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را به‌درستی همراه با هندسهٔ آن بچرخانم؟**

از متد [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد چون به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا نتیجه «قفل» شود؟**

بله. ناحیهٔ [اسلاید](/slides/fa/java/convert-powerpoint-to-png/) یا خود [شکل](/slides/fa/java/create-shape-thumbnails/) را به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌سازد.