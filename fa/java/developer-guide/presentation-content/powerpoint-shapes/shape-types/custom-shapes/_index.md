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
- جاوا
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای جاوا: مسیرهای هندسی، گوشه‌های منحنی، شکل‌های ترکیبی."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه با ویرایش هندسه شکل‌ها از طریق نقاط و مسیرهای هندسی، شکل‌های ارائه در Aspose.Slides را سفارشی کنید. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) و [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) به تغییر شکل‌های موجود می‌پردازید، عملیات پایه ویرایش مسیر را انجام می‌دهید، نقاط را اضافه یا حذف می‌کنید و هندسه به‌روزشده را به یک شکل اعمال می‌کنید.

همچنین نحوه ایجاد شکل‌های سفارشی و ترکیبی، ساخت شکل‌ها با گوشه‌های منحنی، تعیین اینکه آیا هندسه یک شکل بسته است، بازرسی عناصر شکل، و تبدیل خطوط متن Java AWT به مسیرهای هندسی را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایش**

در PowerPoint می‌توانید با **نقاط ویرایش** یک مربع را تغییر دهید:

* حرکت گوشه به داخل یا خارج.
* تنظیم انحنا در یک نقطه.
* افزودن نقاط جدید.

ویرایش نقاط به شما امکان می‌دهد پیرامون یک شکل را تغییر داده یا از یک شکل موجود به‌عنوان پایه برای شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![تصویر_نمای_کلی](custom_shape_0.png)

هنگام ویرایش شکل‌های PowerPoint، این مفاهیم را در نظر بگیرید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل‌شده توسط بخش‌ها تشکیل شده است.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دستگیره‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر به عنوان نقاط گوشه‌ای، مستقیم یا صاف وجود دارند:
  * در یک نقطه گوشه‌ای، بخش‌های پیوست می‌توانند با زاویه‌ای برخورد کنند.
  * در یک نقطه صاف، دو دستگیره کنترل هم‌راستا و به‌صورت مساوی از نقطه لنگر فاصله دارند.
  * در یک نقطه مستقیم، دو دستگیره کنترل هم‌راستا هستند اما ممکن است فاصله‌های متفاوتی از نقطه لنگر داشته باشند.
* حرکت نقاط لنگر یا تنظیم دستگیره‌های آن‌ها پیرامون شکل را تغییر می‌دهد.

برای ویرایش شکل‌های PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) و رابط [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) مسیر هندسی شیٔ [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) از نمونهٔ [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) می‌توانید از متد [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این متدها استفاده کنید: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) برای شکل‌های با مسیر واحد و [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) برای شکل‌های با مسیرهای متعدد.
* برای افزودن بخش‌ها، می‌توانید از متدهای موجود در [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) استفاده کنید.
* با استفاده از متدهای [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) و [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.
* برای دسترسی به گزینه‌های سفارشی‌سازی بیشتر هندسهٔ شکل، می‌توانید یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) را از طریق [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن بخوانید و بخش‌ها را روی یک [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) بازپخش کنید.

## **عملیات ویرایش ساده**

از متدهای زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌های پذیرنده یک اندیس، یک بخش را در موقعیت صفر‑پایهٔ آرایهٔ بخش‌های مسیر قرار می‌دهند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| افزودن یا درج یک منحنی Bézier مکعبی با دو نقطه کنترل و نقطهٔ انتهایی. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| افزودن یا درج یک منحنی Bézier درجه دوم با یک نقطه کنترل و نقطهٔ انتهایی. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| افزودن یک قوسی بیضوی با ابعاد و زاویه‌های مشخص به درجه. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| بستن شکل فعلی با اتصال نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| حذف یک بخش در یک اندیس صفر‑پایه. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) اضافه می‌کند و مسیر ویرایش‌شده را با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) اعمال می‌نماید. مختصات‌ها به‌صورت محلی به شکل هستند: هر دو نقطه جدید در مرکز آن، ۱۰۰ نقطه از سمت چپ و ۵۰ نقطه از بالای شکل قرار دارند. اندیس‌های بخش ۱ و ۴ آن‌ها را بر روی لبه‌های بالا و پایین قرار می‌دهند و آن لبه‌ها را به سمت داخل می‌کشند.

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

این مثال شکل هندی را با حذف بخش با اندیس صفر‑پایهٔ ۲ با استفاده از [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) تغییر می‌دهد. با اعمال مسیر اصلاح‌شده با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) حاشیهٔ شکل به‌روزرسانی می‌شود.

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

این مثال یک ستارهٔ پنج‌پرگی را با استفاده از [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی متناوب به ترتیب ۱۰۰ و ۵۰ نقطه، نوک‌ها و حفره‌ها را تعریف می‌کند؛ گام ۷۲ درجه، پنج نوک را به‌صورت مساوی فاصله می‌دهد. مسیر با [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) بسته می‌شود و با استفاده از [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) یک شکل مستطیلی اعمال می‌گردد و حاشیهٔ آن جایگزین می‌شود.

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

این مثال دو شیٔ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) بسته برای یک‌سوم بالایی و یک‌سوم پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) یک شکل ترکیبی واحد با فضای خالی در یک‌سوم میانی ایجاد می‌کند.

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

این مثال بخش‌های مستقیم را با [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) ترکیب می‌کند تا شکلی با گوشه‌های منحنی به‌درون ایجاد شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را به‌پیکسل (نقطه) تعیین می‌کند و چرخش ‎‑۹۰ درجه یک قوس‌نیم‌دایرهٔ جهت‌دار خلاف ساعت را می‌کشد. مسیر نهایی با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌گردد.

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

تابع کمکی زیر بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک بخش بسته پایان می‌یابد یا خیر. این تابع با خواندن [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) و مقایسهٔ فرمان نهایی بخش [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) با [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) عمل می‌کند. وقتی مسیرهای غیرخالی وجود نداشته باشد، مقدار false برمی‌گرداند. این بررسی فقط فرمان نهایی هر مسیر را می‌سنجد؛ تمام زیرشکل‌ها را بررسی نمی‌کند. مثال مقدار `true` را برای یک مستطیل چاپ می‌کند.

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

## **استخراج و بررسی عناصر شکل**

از [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) برای بررسی یک شکل موجود به‌صورت عناصری که شامل نقاط مسیر و انواع نقاط می‌شوند، استفاده کنید. هر [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) بازگردانده‌شده را به [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) تبدیل کنید تا آرایه‌های نقاط و انواع را از طریق متدهای [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) و [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) دریافت کنید. این نمایش برای تحلیل حاشیه یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل `input.pptx` را باز می‌کند، اولین شکل هندسی را مستقیماً روی اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌نماید. برای مشاهدهٔ خروجی‌های هر دو نوع بخش (مستقیم و منحنی) یک ارائهٔ شامل شکل با این دو نوع بخش داشته باشید. این روش داخل گروه‌ها جستجو نمی‌کند.

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
                int pointType = types[i] & 0x07; // نوع بخش را حفظ کنید، پرچم‌ها را مستثنی کنید.
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

آرایه‌ها بر اساس اندیس مطابقت دارند: `points[i]` یک نقطه و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را آغاز می‌کند و نوع `1` خطی از نقطهٔ قبلی به نقطهٔ جاری می‌کشد. یک بخش Bézier مکعبی از نقطهٔ انتهایی قبلی آغاز می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل به‌همراه نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌صورت گروهی مصرف می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌کند.

انواع نقطه همچنین شامل پرچم‌ها می‌شوند. برای تشخیص نوع بخش از ماسک `0x07` استفاده کنید و برای تشخیص زیرمسیر بسته پرچم `0x80` را جداگانه بررسی کنید. به عنوان مثال، `129` (`0x81`) یعنی نقطهٔ انتهایی خطی که زیرمسیر را می‌بندد و `131` (`0x83`) یعنی نقطهٔ انتهایی Bézier که زیرمسیر را می‌بندد. جاوا این پرچم‌ها را در بایت‌های علامت‌دار ذخیره می‌کند؛ ماسک کردن مقادیر اصلی را حفظ می‌کند. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند خط‌چین (`0x10`) و نشانگر (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیلات.** نقاط برحسب نقاط (۱/۷۲ اینچ) اندازه‌گیری می‌شوند و X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل غیرگروه‌بندی‌شده، مختصات استخراج‌شده قبلاً شامل موقعیت بازگردانده‌شده توسط [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) و [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) و عرض و ارتفاع فعلی آن است. به عنوان مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` مرزهای حاشیهٔ آن `(100, 200)`–`(220, 280)` دارد. موقعیت شکل را دوباره اضافه نکنید. برای به‌دست آوردن مختصات نسبت به قاب غیرچرخان، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل، که توسط [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) برگردانده می‌شود، یا وارونه‌سازی افقی و عمودی را اعمال نمی‌کنند. برای بازتولید حاشیهٔ نمایش‌داده‌شده، این تبدیلات را پیرامون مرکز شکل اعمال کنید. برای شکل‌های گروهی، همچنین نقشهٔ مختصات گروه و تبدیلات را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید رندر شده هستند یا ترجمه یا مقیاس را دو بار اعمال کنید اگر قبلاً در قاب فرزند منعکس شده باشد.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده حاشیه را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روزرسانی نمی‌کند. زمانی که تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد، این روش را برگزینید. وقتی به دستورات هندسی در سیستم مختصات محلی شکل یا ویرایش هندسهٔ آن نیاز دارید، از [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) یا [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) اعمال کنید.

## **تبدیل یک Shape از Java AWT به GeometryPath**

این مثال شکل مستطیلی را با متنی ترکیب می‌کند که به هندسه تبدیل شده است. متد [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) برای شکل، پر کردن آن را غیرفعال می‌کند. یک [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) خطوط متن را در یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ایجاد می‌کند. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن حرکت، خط، منحنی درجه دوم، منحنی مکعبی و بخش‌های بسته را فراهم می‌کند که مثال آن‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) بازپخش می‌کند.

متن با قلم Arial به اندازهٔ ۴۰ نقطه استفاده می‌شود. مسیر با ۲۰ نقطه به‌صورت افقی جابجا می‌شود و بالأ بصری آن ۱۰ نقطه زیر لبهٔ بالای شکل قرار می‌گیرد. مسیر متن پر می‌شود، در حالی که مستطیل اولیه فقط به‌صورت خط مرزی می‌ماند. اعمال هر دو مسیر با [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) یک شکل واحد شامل مستطیل و متن تولید می‌کند.

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

    // تخصیص ترکیب مسیر هندسی جدید و مسیر هندسی اصلی به شکل
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **سوالات متداول**

**چه اتفاقی برای پر و مرز پس از جایگزینی هندسه می‌افتد؟**

سبک با شکل باقی می‌ماند؛ فقط حاشیه تغییر می‌کند. پر و مرز به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم شکل سفارشی را به‌همراه هندسهٔ آن به‌درستی بچرخانم؟**

از متد [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) شکل استفاده کنید؛ هندسه همراه شکل می‌چرخد زیرا به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ مورد نیاز [slide](/slides/fa/java/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/java/create-shape-thumbnails/) را به قالب رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده می‌کند.