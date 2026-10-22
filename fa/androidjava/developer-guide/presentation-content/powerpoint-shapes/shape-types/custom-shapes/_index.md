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
- عملیات ویرایش
- گوشه منحنی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای Android از طریق Java: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه می‌توان اشکال ارائه در Aspose.Slides را با ویرایش هندسه شکل از طریق نقاط ویرایش و مسیرهای هندسی سفارشی کرد. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) و [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) کار کرد تا اشکال موجود را تغییر داد، عملیات پایه ویرایش مسیر را انجام داد، نقاط را اضافه یا حذف کرد و هندسه به‌روزرسانی‌شده را به شکل اعمال کرد.

همچنین نمایش می‌دهد چگونه اشکال سفارشی و مرکب ایجاد کرد، اشکالی با گوشه‌های منحنی ساخت، تعیین کرد آیا هندسه یک شکل بسته است یا خیر، و عناصر شکل را با استفاده از آرایه‌های نقطه‌ای Android بررسی کرد.

## **تغییر یک شکل با استفاده از نقاط ویرایش**

در PowerPoint می‌توانید از **نقاط ویرایش** برای تعديل یک مربع استفاده کنید:

* یک گوشه را به سمت داخل یا خارج حرکت دهید.
* انحنای یک نقطه را تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما امکان می‌دهد outlines یک شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایه‌ای برای شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در نظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل‌شده توسط بخش‌ها تشکیل شده است.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دستگیره‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر به صورت نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف وجود دارند:
  * در یک نقطه گوشه‌ای، بخش‌های مجاور می‌توانند زیر یک زاویه ملاقات کنند.
  * در یک نقطه صاف، دو دستگیره کنترل هم‌راستا هستند و فاصله مساوی از نقطه لنگر دارند.
  * در یک نقطه مستقیم، دو دستگیره کنترل هم‌راستا هستند اما می‌توانند فاصله‌های متفاوتی از نقطه لنگر داشته باشند.
* جابجایی نقاط لنگر یا تنظیم دستگیره‌های آن‌ها شکل outlines را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) و اینترفیس [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) را نمایش می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) از نمونهٔ [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) می‌توانید از متد [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این متدها استفاده کنید: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) برای اشکالی با مسیر واحد و [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) برای اشکالی با چند مسیر.
* برای افزودن بخش‌ها می‌توانید از متدهای موجود در [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) استفاده کنید.
* با استفاده از متدهای [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) و [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) را به شکل آرایه‌ای از بخش‌های مسیر دریافت کنید.

## **عملیات ساده ویرایش**

از متدهای زیر برای ویرایش یک مسیر هندسی استفاده کنید. نسخه‌های overload که یک ایندکس می‌پذیرند، یک بخش را در آن موقعیت صفر‑محور در آرایهٔ بخش‌های مسیر وارد می‌کند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| افزودن یا درج یک منحنی Bézier مکعبی با دو نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| افزودن یا درج یک منحنی Bézier درجه دو با یک نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| افزودن یک قوس بیضوی با ابعاد و زاویه‌های مشخص به درجه. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| بستن شکل فعلی با اتصال نقطهٔ انتهایی آن به نقطهٔ شروع. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| حذف یک بخش در یک ایندکس صفر‑محور. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) وارد می‌کند و مسیر ویرایش‌شده را با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) اعمال می‌نماید. مختصات‌ها به‌صورت محلی نسبت به شکل هستند: هر دو نقطهٔ جدید در مرکز آن، ۱۰۰ نقطه از سمت چپ و ۵۰ نقطه از سمت بالا قرار دارند. ایندکس‌های بخش ۱ و ۴ آن‌ها را بر روی لبه‌های بالایی و پایینی قرار می‌دهد و این لبه‌ها را به سمت داخل می‌کشند.

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

این مثال خطوط حاشیهٔ شکل قلبی را با حذف بخش در ایندکس صفر‑محور ۲ با استفاده از [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) مرزبندی شکل را به‌روز می‌کند.

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

این مثال یک ستارهٔ پنج‌پر با استفاده از [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی به ترتیب ۱۰۰ و ۵۰ نقطه، نوک‌ها و تو رفتگی‌ها را تعریف می‌کنند؛ یک گام ۷۲ درجه، پنج نوک را به‌صورت مساوی پراکنده می‌کند. مسیر با [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) بسته می‌شود و با استفاده از [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) به یک شکل مستطیلی اعمال می‌شود و حاشیهٔ آن را جایگزین می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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

## **ایجاد یک شکل سفارشی ترکیبی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) بسته برای یک‑سوم بالایی و یک‑سوم پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) یک شکل ترکیبی واحد با یک فاصله در یک‑سوم میانی ایجاد می‌کند.

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

این مثال بخش‌های مستقیم را با [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) ترکیب می‌کند تا شکلی با گوشه‌های منحنی به سمت داخل به‌دست آورد. هر اندازهٔ گوشه عرض و ارتفاع قوس را به نقاط تعیین می‌کند و زاویهٔ -90 درجه یک ربع بیضی مخالف جهت عقربه‌های ساعت می‌کشد. مسیر نهایی با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌شود.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

کمک‌کنندهٔ زیر بررسی می‌کند که آیا هر مسیر هندسی غیر خالی با یک بخش بسته پایان می‌یابد یا نه. این متد [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) را می‌خواند و فرمان نهایی بخش را با [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) مقایسه می‌کند و با [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیرهای غیر خالی وجود ندارند، مقدار false برمی‌گرداند. این متد فرمان نهایی هر مسیر را بررسی می‌کند؛ نه اینکه هر زیرشکل داخل مسیر را بررسی کند. مثال برای یک مستطیل مقدار `true` چاپ می‌کند.

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

از متد [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) برای بررسی یک شکل موجود به‌عنوان عناصر شامل نقاط مسیر و انواع نقاط استفاده کنید. هر شیء برگشتی از نوع [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) را به [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) تبدیل کنید تا آرایه‌های نقاط و انواع را از طریق متدهای [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) و [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) دریافت کنید. این نمایش برای تحلیل مرزبندی یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایلی به نام input.pptx باز می‌کند، اولین شکل هندسی را مستقیماً در اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌کند. برای مشاهدهٔ خروجی‌های هر دو نوع خط مستقیم و منحنی، از ارائه‌ای استفاده کنید که شامل شکل با بخش‌های مستقیم و منحنی باشد. این متد درون گروه‌ها را جستجو نمی‌کند.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // نوع بخش را نگه می‌دارد، پرچم‌ها را مستثنی می‌کند.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // هر دو نقطه کنترل و نقطه انتهایی را مصرف می‌کند.
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

آرایه‌ها براساس ایندکس مطابقت دارند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را شروع می‌کند و نوع `1` خطی را از نقطهٔ قبلی به نقطهٔ جاری می‌کشد. یک بخش Bézier مکعبی از نقطهٔ انتهای قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌صورت یکجا مصرف می‌کند و نقطهٔ انتهایی را برای بستن بررسی می‌کند.

انواع نقطه همچنین شامل پرچم‌ها هستند. با استفاده از ماسک `0x07` می‌توانید نوع بخش را شناسایی کنید و پرچم `0x80` را به‌صورت جداگانه برای تشخیص یک زیرمسیر بسته تست کنید. به‌عنوان مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خطی است که یک زیرمسیر را می‌بندد و `131` (`0x83`) به معنای نقطهٔ انتهایی Bézier است که یک زیرمسیر را می‌بندد. جاوا این پرچم‌ها را در بایت‌های علامت‌دار ذخیره می‌کند؛ ماسک کردن مقادیر بایت‌های علامت‌دار مقدارهای بیت اصلی را حفظ می‌کند. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند dash (`0x10`) و marker (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب نقطه (1/72 اینچ) اندازه‌گیری می‌شوند، با X به سمت راست افزایشی و Y به سمت پایین افزایشی. برای یک شکل بدون گروه، مختصات استخراج‌شده هم اکنون شامل موقعیت بازگشتی توسط [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) و [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) و عرض و ارتفاع فعلی آن است. به‌عنوان مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` دارای مرزهای مرزبندی `(100, 200)`–`(220, 280)` است. موقعیت شکل را دوبار اضافه نکنید. برای دریافت مختصات نسبی به چارچوب چرخش‌نشده، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل، که توسط [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) بازگردانده می‌شود، یا وارونگی افقی و عمودی را اعمال نمی‌کنند. برای بازتولید مرزبندی نمایش داده‌شده، این تبدیل‌ها را نسبت به مرکز شکل اعمال کنید. برای اشکال گروهی، همچنین باید نگاشت مختصات گروه و تبدیل‌ها را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده نهایی هستند یا ترجمه یا مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده است.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده مرزبندی را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روزرسانی نمی‌کند. این روش را زمانی انتخاب کنید که کد تحلیل یا رسم شما نیاز به آرایه‌های نقطه/نوع داشته باشد. از [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) زمانی استفاده کنید که به دستورات هندسی در سیستم مختصات محلی شکل نیاز دارید یا می‌خواهید هندسه‌اش را ویرایش کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) یا [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) اعمال کنید.

## **سوالات متداول**

**پس از جایگزین کردن هندسه، پر کردن و حاشیهٔ شکل چه اتفاقی می‌افتد؟**

سبک همراه با شکل باقی می‌ماند؛ فقط مرزبندی تغییر می‌کند. پر کردن و حاشیه به‌صورت خودکار بر روی هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توان یک شکل سفارشی را به‌درستی همراه با هندسه‌اش چرخاند؟**

از متد [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) شکل استفاده کنید؛ هندسه با شکل می‌چرخد زیرا به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ مورد نیاز را به‌عنوان [اسلاید](/slides/fa/androidjava/convert-powerpoint-to-png/) یا خود [شکل](/slides/fa/androidjava/create-shape-thumbnails/) به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌کند.