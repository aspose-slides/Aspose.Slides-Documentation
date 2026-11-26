---
title: سفارشی‌سازی اشکال ارائه در جاوااسکریپت
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/nodejs-java/custom-shape/
keywords:
- شکل سفارشی
- افزودن شکل
- ایجاد شکل
- تغییر شکل
- هندسه شکل
- مسیر هندسی
- نقاط مسیر
- نقاط ویرایشی
- افزودن نقطه
- حذف نقطه
- عملیات ویرایشی
- گوشه منحنی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و شخصی‌سازی اشکال در ارائه‌های PowerPoint با استفاده از JavaScript و Aspose.Slides برای Node.js: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه می‌توان شکل‌های ارائه در Aspose.Slides را از طریق ویرایش هندسه شکل با استفاده از نقاط ویرایشی و مسیرهای هندسی سفارشی کرد. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) کار کنید تا شکل‌های موجود را تغییر دهید، عملیات پایه ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید، و هندسه به‌روز شده را به یک شکل اعمال کنید.

همچنین نحوه ایجاد شکل‌های سفارشی و ترکیبی، ساخت شکل‌ها با گوشه‌های منحنی، تعیین اینکه آیا هندسه یک شکل بسته است یا خیر، بررسی عناصر شکل، و تبدیل خطوط متن Java AWT به مسیرهای هندسی را نمایش می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایشی**

* حرکت دادن یک گوشه به سمت داخل یا خارج.  
* تنظیم منحنی‌بودن در یک نقطه.  
* افزودن نقاط جدید.

ویرایش نقاط به شما امکان می‌دهد حاشیه یک شکل را تغییر دهید یا از یک شکل موجود به عنوان پایه برای شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش شکل‌های PowerPoint، این مفاهیم را در ذهن داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.  
* مسیر یک شکل از نقاط لنگر متصل به یکدیگر توسط بخش‌ها تشکیل می‌شود.  
* یک بخش می‌تواند صاف یا منحنی باشد. نقاط لنگر و دستگیره‌های کنترل شکل آن را تعیین می‌کنند.  
* نقاط لنگر می‌توانند به صورت نقاط گوشه‌ای، نقاط صاف یا نقاط نرم وجود داشته باشند:  
  * در یک نقطه گوشه‌ای، بخش‌های مجاور می‌توانند با زاویه‌ای به هم برسند.  
  * در یک نقطه نرم، دو دستگیره کنترل هم‌راستا و با فاصله مساوی از نقطه لنگر قرار دارند.  
  * در یک نقطه صاف، دو دستگیره کنترل هم‌راستا هستند اما می‌توانند فاصله متفاوتی از نقطه لنگر داشته باشند.  
* جابه‌جایی نقاط لنگر یا تنظیم دستگیره‌های آن‌ها، حاشیه شکل را تغییر می‌دهد.

برای ویرایش شکل‌های PowerPoint از طریق نقاط ویرایشی، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونه [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) مسیر هندسی شیء [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) را نشان می‌دهد.  
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) از نمونه [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) می‌توانید از متد [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید.  
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این متدها استفاده کنید: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) برای شکل‌هایی با مسیر واحد و [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) برای شکل‌هایی با مسیرهای متعدد.  
* برای افزودن بخش‌ها، می‌توانید از متدهای موجود در [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) استفاده کنید.  
* با استفاده از متدهای [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) و [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) می‌توانید ظاهر یک مسیر هندسی را تعیین کنید.  
* با استفاده از متد [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) را به صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.  
* برای دسترسی به گزینه‌های سفارشی‌سازی اضافه هندسه شکل، می‌توانید یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) را از طریق [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن بخوانید و بخش‌ها را روی یک [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) بازپخش کنید.

## **عملیات ویرایشی ساده**

از متدهای زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌های (overloads) که یک شاخص می‌پذیرند، یک بخش را در موقعیت صفر‑پایه‌ای آن در آرایه بخش‌های مسیر درج می‌کنند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| افزودن یا درج یک منحنی بزیهٔ مکعبی با دو نقطه کنترل و نقطه انتهایی. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| افزودن یا درج یک منحنی بزیهٔ درجهٔ دوم با یک نقطه کنترل و نقطه انتهایی. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| افزودن یک قوس بیضوی با ابعاد و زوایای مشخص شده بر حسب درجه. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| بستن شکل فعلی با اتصال نقطه انتهایی آن به نقطه شروع. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| تنظیم نقطه شروع یک شکل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| حذف یک بخش در شاخص صفر‑پایه‌ای. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) وارد می‌کند و مسیر ویرایش‌شده را با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌نماید. مختصات‌ها محلی نسبت به شکل هستند: هر دو نقطه جدید در مرکز آن قرار دارند، 100 واحد از سمت چپ و 50 واحد از بالای شکل. شاخص‌های بخش 1 و 4 آن‌ها را بر روی لبه‌های بالا و پایین قرار می‌دهند و این لبه‌ها را به سمت داخل می‌کشند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **حذف نقاط از یک شکل**

این مثال طرح شکل قلبی را با حذف بخش با شاخص صفر‑پایه‌ای 2 با استفاده از [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) حاشیه شکل را به‌روز می‌کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

این مثال با استفاده از [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) یک ستاره پنج‌پرکی می‌سازد. شعاع‌های خارجی و داخلی به ترتیب 100 و 50 واحد تعریف می‌شود؛ گام 72 درجه لبه‌های پنج‌گانه را به‌صورت مساوی پخش می‌کند. مسیر با [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) بسته می‌شود و با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) به یک شکل مستطیلی اعمال می‌شود و طرح قبلی آن را جایگزین می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **ایجاد یک شکل ترکیبی سفارشی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) بسته برای یک‑سوم بالا و یک‑سوم پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل ترکیبی واحد با شکاف در یک‑سوم میانی ایجاد می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال بخش‌های صاف را با [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) ترکیب می‌کند تا شکلی با گوشه‌های درونی‑منحنی به دست آید. هر اندازه گوشه عرض و ارتفاع قوس را بر حسب نقاط تنظیم می‌کند و چرخش –90 درجه یک ربع بیضی را به‌صورت پادساعت جهت می‌کشد. مسیر کامل با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌شود و ارائه در فرمت PPTX ذخیره می‌گردد.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پیدا کردن اینکه آیا هندسه یک شکل بسته است**

این کمکی بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک بخش بسته پایان می‌یابد یا خیر. آن [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) را می‌خواند و دستور نهایی [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) را با [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) مقایسه می‌کند. اگر مسیرهای غیرخالی وجود نداشته باشد، مقدار false باز می‌گردد. این بررسی تنها فرمان نهایی هر مسیر را در نظر می‌گیرد؛ زیرشکل‌های داخل مسیر را بررسی نمی‌کند. مثال `true` را برای یک مستطیل چاپ می‌کند.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **بررسی دستورات مسیر هندسی**

فایل [contour.pptx](contour.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اولین شکل در اسلاید اول دارای لبهٔ بالایی صاف، یک منحنی بزیهٔ مکعبی و لبهٔ بستهٔ صاف است. از [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) برای خواندن مسیرهای شکل و [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) برای خواندن بخش‌های هر مسیر به ترتیب رسم استفاده کنید. برای هر بخش، [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) فرمان را شناسایی می‌کند و نحوه تفسیر مقادیر برگردانده‌شده توسط [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData) را تعیین می‌نماید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

شکل در نقطهٔ (200, 100) نقطه در اسلاید قرار دارد. مختصات گزارش‌شده محلی نسبت به شکل هستند و (0, 0) در گوشهٔ بالا‑چپ آن قرار دارد؛ x به سمت راست و y به سمت پایین افزایشی است. بخش بسته بدون مختصات اضافی به نقطهٔ شروع باز می‌گردد.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **استخراج و بررسی عناصر شکل**

از [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) برای بررسی یک شکل موجود به عنوان عناصر حاوی نقاط مسیر و انواع نقطه استفاده کنید. هر [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) بازگردانده‌شده می‌تواند آرایهٔ نقاط و انواع را از طریق متدهای [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) و [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) دریافت کند. این نمایش برای تجزیه و تحلیل حاشیه یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل input.pptx را باز می‌کند، اولین شکل هندسی را مستقیماً در اسلاید اول پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌کند. برای دیدن خروجی هر دو نوع بخش، از یک ارائه شامل شکلی با بخش‌های صاف و منحنی استفاده کنید. این روش داخل گروه‌ها جستجو نمی‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // نوع بخش را نگه‌دارید، بدون پرچم‌ها.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

آرایه‌ها بر اساس اندیس هم‌راستا هستند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` شروع یک شکل را نشان می‌دهد و نوع `1` خطی را از نقطهٔ قبلی به نقطهٔ جاری می‌کشد. یک بخش بزیهٔ مکعبی از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطه کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌هم پیوسته پردازش می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌کند.

انواع نقطه همچنین شامل پرچم‌ها هستند. برای شناسایی نوع بخش با ماسک `0x07` استفاده کنید و برای تشخیص زیرمسیر بسته پرچم `0x80` را جداگانه تست کنید. به عنوان مثال `129` (`0x81`) نشان‌دهندهٔ نقطهٔ انتهایی خط است که یک زیرمسیر را می‌بندد و `131` (`0x83`) نشان‌دهندهٔ نقطهٔ انتهای بزیه است که یک زیرمسیر را می‌بندد. جاوا این پرچم‌ها را در بایت‌های امضاء شده ذخیره می‌کند؛ استفاده از ماسک مقادیر بیتی اصلی را حفظ می‌کند. مقایسه مقدار خام تنها با `1` یا `3` این موارد را نادیده می‌گیرد. پرچم‌های دیگر مانند dash (`0x10`) و marker (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط به نقطه (1/72 اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایشی است. برای یک شکل بدون گروه، مختصات استخراج‌شده قبلاً موقعیت برگشتی توسط [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) و [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) را شامل می‌شود و عرض و ارتفاع فعلی آن را منعکس می‌کند. به عنوان مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` دارای مرزهای حاشیهٔ `(100, 200)`–`(220, 280)` است. موقعیت شکل را دوباره اضافه نکنید. برای به‌دست آوردن مختصات نسبی به قاب غیرچرخان آن، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل که توسط [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) برگردانده می‌شود یا وارون‌های افقی و عمودی را اعمال نمی‌کنند. برای بازسازی حاشیهٔ نمایش داده‌شده، این تبدیلات را حول مرکز شکل اعمال کنید. برای اشکال گروهی، همچنین نگاشت مختصات گروه و تبدیلات را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید هستند یا انتقال یا مقیاس را دو بار اعمال کنید اگر قبلاً در قاب فرزند منعکس شده‌اند.

**بررسی در مقابل ویرایش.** آرایه‌های استخراج‌شده حاشیه را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روزرسانی نمی‌کند. این روش را زمانی استفاده کنید که تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد. وقتی به دستورات هندسی در سیستم مختصات محلی شکل نیاز دارید یا می‌خواهید هندسهٔ آن را ویرایش کنید، از [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) یا [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) اعمال کنید.

## **تبدیل یک Java AWT Shape به GeometryPath**

این مثال یک حاشیهٔ مستطیلی را با متنی ترکیب می‌کند که به هندسه تبدیل شده است. متد [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) حاشیه را بدون پرش می‌کند. یک [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) شکل متن را در یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ایجاد می‌کند. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن حرکت، خط، درجهٔ دوم، درجهٔ سوم و بخش‌های بسته را فراهم می‌کند که مثال آن‌ها را روی یک [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) بازپخش می‌کند.

پل جاوا از مقادیر float و byte صریح برای پارامترهای متناظر جاوا استفاده می‌کند. تکرارگر مختصات‌ها را در یک آرایهٔ float جاوا می‌نویسد؛ انعکاس مقادیر به‌روزشده را به JavaScript برمی‌گرداند. متن از قلم Arial با اندازهٔ 40 نقطه استفاده می‌کند. حاشیه 20 نقطه به صورت افقی جابجا شده و بالای بصری آن 10 نقطه زیر لبهٔ بالای شکل قرار می‌گیرد. مسیر متن پر می‌شود در حالی که مستطیل اصلی به صورت حاشیه باقی می‌ماند. اعمال هر دو مسیر با [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل واحد شامل مستطیل و متن تولید می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // حرکت به.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // خط به.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // منحنی بزیهٔ درجهٔ دوم.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // منحنی بزیهٔ مکعبی.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // بستن شکل.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **سؤالات متداول**

**چه اتفاقی برای پر و حاشیه پس از جایگزینی هندسه می‌افتد؟**

سبک با شکل باقی می‌ماند؛ فقط حاشیه تغییر می‌کند. پر و حاشیه به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را همراه با هندسه‌اش به‌درستی بچرخانم؟**

از متد [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد زیرا به سیستم مختصات خود شکل بسته است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ [اسلاید](/slides/fa/nodejs-java/convert-powerpoint-to-png/) مورد نیاز یا خود [شکل](/slides/fa/nodejs-java/create-shape-thumbnails/) را به قالب رستر خروجی بگیرید؛ این کار کار با هندسه‌های پیچیده را ساده می‌کند.