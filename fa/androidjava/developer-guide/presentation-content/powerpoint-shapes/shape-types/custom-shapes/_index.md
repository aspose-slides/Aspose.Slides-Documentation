---
title: سفارشی‌سازی اشکال ارائه در Android
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/androidjava/custom-shape/
keywords:
- شکل سفارشی
- افزودن شکل
- ساخت شکل
- تغییر شکل
- هندسهٔ شکل
- مسیر هندسی
- نقطه‌های مسیر
- نقاط ویرایش
- افزودن نقطه
- حذف نقطه
- عملیات ویرایش
- گوشهٔ منحنی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای Android از طریق Java: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان اشکال ارائه در Aspose.Slides را با ویرایش هندسهٔ شکل از طریق نقاط ویرایش و مسیرهای هندسی سفارشی کرد. این مقاله نشان می‌دهد که چگونه با [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) و [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) کار کنید تا اشکال موجود را تغییر دهید، عملیات پایهٔ ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسهٔ به‌روز شده را به شکل اعمال کنید.

همچنین نحوهٔ ساخت اشکال سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسهٔ شکل بسته است و بررسی عناصر شکل با استفاده از آرایه‌های نقطهٔ Android را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایش**

در PowerPoint می‌توانید از **نقاط ویرایش** برای تغییر یک مربع استفاده کنید:

* یک گوشه را به سمت داخل یا بیرون حرکت دهید.
* انحنا را در یک نقطه تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما امکان می‌دهد خطوط بیرونی یک شکل را تغییر دهید یا از یک شکل موجود به عنوان پایه‌ای برای یک شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![نکات ویرایش شکل](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در نظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل شامل نقاط لنگر است که توسط قطعات به هم وصل می‌شوند.
* یک قطعه می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر به صورت نقطهٔ گوشه، نقطهٔ مستقیم یا نقطهٔ صاف وجود دارند:
  * در یک نقطهٔ گوشه، قطعات مجاور می‌توانند تحت زاویه‌ای به هم ملحق شوند.
  * در یک نقطهٔ صاف، دو دستهٔ کنترل هم‌راستاو برابر از نقطهٔ لنگر فاصله دارند.
  * در یک نقطهٔ مستقیم، دو دستهٔ کنترل هم‌راستا هستند اما می‌توانند فاصله‌های متفاوتی از نقطهٔ لنگر داشته باشند.
* جابجایی نقاط لنگر یا تنظیم دسته‌های آن‌ها، خطوط بیرونی شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) و رابط [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) را نمایش می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) از نمونهٔ [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) می‌توانید از متد [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این متدها استفاده کنید: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) برای اشکالی که یک مسیر دارند و [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) برای اشکالی که چندین مسیر دارند.
* برای افزودن قطعه‌ها می‌توانید از متدهای موجود در [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) استفاده کنید.
* با استفاده از متدهای [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) و [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از قطعات مسیر دریافت کنید.

## **عملیات سادهٔ ویرایش**

از روش‌های زیر برای ویرایش یک مسیر هندسی استفاده کنید. نسخه‌های اضافه‌شونده که اندیس می‌پذیرند، یک قطعه را در موقعیت صفر‑پایهٔ آرایهٔ قطعات مسیر درج می‌کنند.

| عملیات | متد |
| --- | --- |
| اضافه یا درج یک خط مستقیم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| اضافه یا درج یک منحنی Bézier مکعب با دو نقطهٔ کنترل و یک نقطهٔ پایان. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| اضافه یا درج یک منحنی Bézier درجهٔ دوم با یک نقطهٔ کنترل و یک نقطهٔ پایان. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| اضافه کردن یک قوس بیضوی با ابعاد و زاویه‌های مشخص به درجه. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| بستن شکل جاری با اتصال نقطهٔ پایان به نقطهٔ شروع. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| حذف یک قطعه در اندیس صفر‑پایه. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) اضافه می‌کند و مسیر ویرایش‌شده را با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) اعمال می‌نماید. مختصات به‌صورت محلی نسبت به شکل هستند: هر دو نقطهٔ جدید در مرکز آن، ۱۰۰ پوینت از سمت چپ و ۵۰ پوینت از بالا قرار دارند. اندیس‌های قطعهٔ ۱ و ۴ آن‌ها را بر روی لبه‌های بالا و پایین قرار می‌دهند و این لبه‌ها را به سمت داخل می‌کشند.

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

![مثال ۱](custom_shape_1.png)

## **حذف نقاط از یک شکل**

این مثال خطوط بیرونی شکل قلبی را با حذف قطعه‌ای در اندیس صفر‑پایهٔ ۲ با استفاده از [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) تغییر می‌دهد. اعمال مسیر تغییر یافته با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) خطوط بیرونی شکل را به‌روزرسانی می‌کند.

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

![مثال ۲](custom_shape_2.png)

## **ساخت یک شکل سفارشی**

این مثال یک ستارهٔ پنج‌نقطه‌ای را با استفاده از [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی به ترتیب ۱۰۰ و ۵۰ پوینت به‌صورت متناوب تعریف می‌شوند؛ گام ۷۲ درجه پنج نوک را به‌صورت مساوی فاصله می‌دهد. مسیر با [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) بسته می‌شود و با استفاده از [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) به یک شکل مستطیلی اعمال می‌شود و خطوط بیرونی آن را جایگزین می‌کند.

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

![مثال ۳](custom_shape_3.png)

## **ایجاد یک شکل ترکیبی سفارشی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) بسته برای یک‑سوم‌هٔ بالا و یک‑سوم‌هٔ پایین یک شکل تعریف می‌کند. اعمال هر دو مسیر با [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) یک شکل ترکیبی واحد با یک فاصلهٔ عرضی در یک‑سوم‌هٔ وسط ایجاد می‌کند.

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

![مثال ۴](custom_shape_4.png)

## **ساخت یک شکل سفارشی با گوشه‌های منحنی**

این مثال قطعه‌های مستقیم را با [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) ترکیب می‌کند تا شکلی با گوشه‌های داخلی منحنی ایجاد شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را بر حسب پوینت تنظیم می‌کند و طی‌گیری ‑۹۰ درجه یک چهارم‌دایره‌الماس خلاف ساعت‌گرد می‌کشد. مسیر کامل با [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌شود.

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

## **تشخیص بسته بودن هندسهٔ یک شکل**

تابع کمکی زیر بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک قطعهٔ بسته پایان می‌یابد یا خیر. این تابع [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) را می‌خواند و فرمان نهایی قطعهٔ [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) را با [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) مقایسه می‌کند. اگر مسیرهای غیرخالی وجود نداشته باشد، مقدار false برمی‌گرداند. این بررسی فقط فرمان نهایی هر مسیر را مورد بررسی قرار می‌دهد؛ زیرشکل‌های داخلی را بررسی نمی‌کند. مثال مقدار `true` را برای یک مستطیل چاپ می‌کند.

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

## **بررسی دستورات مسیر هندسی**

[contour.pptx](contour.pptx) را دانلود کنید و نام فایل نمونه را با مسیر آن بر روی دستگاه جایگزین کنید. اولین شکل در اولین اسلاید دارای لبهٔ بالایی مستقیم، یک منحنی Bézier مکعب و لبهٔ بستهٔ مستقیم است. برای خواندن مسیرهای شکل از [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) و برای خواندن قطعات هر مسیر در ترتیب رسم از [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) استفاده کنید. برای هر قطعه، [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) فرمان را شناسایی می‌کند و نحوه تفسیر مقادیر برگردانده شده توسط [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) را تعیین می‌نماید.

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

شکل در مختصات (200, 100) پوینت بر روی اسلاید قرار دارد. مختصات گزارش‌شده به‌صورت محلی نسبت به شکل هستند؛ (0, 0) در گوشهٔ بالایی‑چپ آن قرار دارد، x به سمت راست و y به سمت پایین افزایش می‌یابد. قطعهٔ بسته بدون مختصات اضافه به نقطهٔ شروع باز می‌گردد.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![شکل PowerPoint با لبهٔ بالایی مستقیم، لبهٔ منحنی از بالا‑راست به پایین‑چپ، و لبهٔ چپ مستقیم](contour.png)

## **استخراج و بررسی عناصر شکل**

از [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) برای بررسی یک شکل موجود به‌عنوان عناصری شامل نقاط مسیر و انواع نقاط استفاده کنید. هر [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) بازگردانده شده را به [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) تبدیل کنید تا آرایه‌های نقاط و انواع را از طریق متدهای [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) و [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) دریافت کنید. این نمایش برای تحلیل خطوط بیرونی یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل input.pptx را باز می‌کند، اولین شکل هندسی موجود را مستقیماً در اولین اسلاید پیدا می‌کند و قطعات مسیر آن را چاپ می‌نماید. برای مشاهده هر دو نوع خروجی، از ارائه‌ای شامل شکلی با قطعات مستقیم و منحنی استفاده کنید. این روش داخل گروه‌ها جستجو نمی‌کند.

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
                int pointType = types[i] & 0x07; // نگهداری نوع قطعه، بدون پرچم‌ها.
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

آرایه‌ها بر اساس اندیس معادل هستند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را آغاز می‌کند و نوع `1` خطی را از نقطهٔ قبلی به نقطهٔ فعلی می‌کشد. یک قطعه Bézier مکعب از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را با هم مصرف می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌نماید.

انواع نقطه همچنین شامل پرچم‌ها می‌شوند. برای شناسایی نوع قطعه با ماسک `0x07` عمل کنید و برای تشخیص زیرمسیر بسته پرچم `0x80` را جداگانه آزمایش کنید. برای مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خطی است که یک زیرمسیر را می‌بندد و `131` (`0x83`) به معنای نقطهٔ انتهایی Bézier است که یک زیرمسیر را می‌بندد. جاوا این پرچم‌ها را در بایت‌های علامت‌دار ذخیره می‌کند؛ ماسک‌گذاری مقادیر بیتی اصلی را حفظ می‌کند. مقایسه مقدار خام تنها با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند خط‌دشی (*dash* `0x10`) و نشانگر (`0x20`) نوع پایهٔ قطعه را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل غیرگروه‌شده، مختصات استخراج‌شده پیشاپیش شامل موقعیتی است که توسط متدهای [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) و [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) برگردانده می‌شود و عرض و ارتفاع فعلی آن را منعکس می‌کند. به‌عنوان مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` حدود بیرونی `(100, 200)`–`(220, 280)` دارد. دوباره موقعیت شکل را اضافه نکنید؛ برای به دست آوردن مختصات نسبی به چارچوب بدون چرخش، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل را که توسط [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) بازگردانده می‌شود، یا وارونگی افقی و عمودی اعمال نمی‌کنند. برای بازسازی خطوط بیرونی نمایش داده‌شده، این تبدیل‌ها را حول مرکز شکل اعمال کنید. برای اشکال گروهی، همچنین نگاشت مختصات گروه و تبدیل‌ها را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده نهایی‌ترین مختصات اسلاید هستند یا ترجمه/مقیاس را دوبار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده‌اند.

**بررسی در مقابل ویرایش.** آرایه‌های استخراج‌شده فقط خطوط بیرونی را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را بروز نمی‌دهد. از این روش زمانی استفاده کنید که کد تحلیل یا رسم شما به آرایه‌های نقطه/نوع نیاز دارد. وقتی به دستورات هندسی در سیستم مختصات محلی شکل نیاز دارید یا می‌خواهید هندسه را ویرایش کنید، از [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) یا [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) اعمال کنید.

## **پرسش‌های متداول**

**بعد از جایگزینی هندسه، پرکردن و خطوط بیرونی چه اتفاقی می‌افتد؟**

سبک همراه شکل باقی می‌ماند؛ فقط خطوط بیرونی تغییر می‌کند. پر کردن و خطوط بیرونی به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه یک شکل سفارشی را به‌درستی همراه با هندسه‌اش چرخانده کنم؟**

از متد [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد زیرا به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا نتیجه "قفل" شود؟**

بله. ناحیهٔ مورد نیاز [اسلاید](/slides/fa/androidjava/convert-powerpoint-to-png/) یا خود [شکل](/slides/fa/androidjava/create-shape-thumbnails/) را به فرمت رستری صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده می‌کند.