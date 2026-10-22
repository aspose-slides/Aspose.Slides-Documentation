---
title: سفارشی‌سازی اشکال ارائه در جاوا اسکریپت
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/nodejs-java/custom-shape/
keywords:
- شکل سفارشی
- افزودن شکل
- ایجاد شکل
- تغییر شکل
- هندسهٔ شکل
- مسیر هندسی
- نقاط مسیر
- نقاط ویرایشی
- افزودن نقطه
- حذف نقطه
- عملیات ویرایش
- گوشهٔ منحنی
- PowerPoint
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با استفاده از جاوا اسکریپت و Aspose.Slides برای Node.js: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه اشکال ارائه در Aspose.Slides را با ویرایش هندسهٔ شکل از طریق نقاط ویرایشی و مسیرهای هندسی سفارشی کنید. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) کار کنید تا اشکال موجود را تغییر دهید، عملیات پایهٔ ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسهٔ به‌روز شده را به شکل بازگردانید.

همچنین نحوهٔ ایجاد اشکال سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسهٔ یک شکل بسته است، بازرسی عناصر شکل و تبدیل خطوط متن Java AWT به مسیرهای هندسی را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایشی**

در PowerPoint می‌توانید از **نقاط ویرایشی** برای تغییر یک مربع استفاده کنید:

* یک گوشه را به سمت داخل یا خارج حرکت دهید.
* انحنای یک نقطه را تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما امکان می‌دهد مرز یک شکل را تغییر دهید یا از یک شکل موجود به عنوان پایهٔ شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![تصویر_مرور_کلی](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در ذهن داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل شامل نقاط لنگر است که توسط بخش‌ها به هم وصل می‌شوند.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر به عنوان نقاط گوشه، نقاط مستقیم یا نقاط نرم وجود دارند:
  * در یک نقطهٔ گوشه، بخش‌های مجاور می‌توانند تحت زاویه‌ای به هم ملحق شوند.
  * در یک نقطهٔ نرم، دو دستهٔ کنترل هم‌راستا و به‌صورت مساوی از نقطهٔ لنگر فاصله دارند.
  * در یک نقطهٔ مستقیم، دو دستهٔ کنترل هم‌راستا هستند اما می‌توانند فاصله‌های متفاوتی از نقطهٔ لنگر داشته باشند.
* جابه‌جایی نقاط لنگر یا تنظیم دسته‌های آن‌ها مرز شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایشی، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) مسیر هندسی شیء [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) از نمونهٔ [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) می‌توانید از متد [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) برای یک shape، می‌توانید این متدها را استفاده کنید: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) برای اشکالی که یک مسیر دارند و [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) برای اشکالی که مسیرهای متعددی دارند.
* برای افزودن بخش‌ها، می‌توانید از متدهای موجود زیر [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) استفاده کنید.
* با استفاده از متدهای [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) و [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) را به‌عنوان آرایه‌ای از بخش‌های مسیر دریافت کنید.
* برای دسترسی به گزینه‌های سفارشی‌سازی بیشتر هندسهٔ شکل، می‌توانید یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) را از طریق [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن بخوانید و بخش‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) بازپخش کنید.

## **عملیات ویرایشی ساده**

از متدهای زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌های پذیرندهٔ اندیس، یک بخش را در آن موقعیت صفر‑مبنا در آرایهٔ بخش‌های مسیر درج می‌کنند.

| عملیات | متد |
| --- | --- |
| اضافه یا درج یک خط مستقیم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| اضافه یا درج یک منحنی Bézier مربعی با دو نقطهٔ کنترل و نقطهٔ انتهایی. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| اضافه یا درج یک منحنی Bézier درجه دو با یک نقطهٔ کنترل و نقطهٔ انتهایی. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| اضافه یک قوس بیضوی با ابعاد و زاویهٔ مشخص به درجه. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| بستن شکل جاری با اتصال نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| حذف یک بخش در اندیس صفر‑مبنا. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) وارد می‌کند و مسیر ویرایش‌شده را با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌نماید. مختصات‌ها به‌صورت محلی به شکل هستند: هر دو نقطهٔ جدید در مرکز آن قرار دارند، ۱۰۰ پوینت از چپ و ۵۰ پوینت از بالا. اندیس‌های بخش ۱ و ۴ آن‌ها را روی لبه‌های بالا و پایین قرار می‌دهند و این لبه‌ها را به سمت داخل می‌کشند.

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

![مثال۱_تصویر](custom_shape_1.png)

## **حذف نقاط از یک شکل**

این مثال خطوط بیرونی یک شکل قلبی را با حذف بخش در اندیس صفر‑مبنا ۲ با استفاده از [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) مرز شکل را به‌روز می‌کند.

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
![مثال۲_تصویر](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

این مثال یک ستارهٔ پنج‌پر با استفاده از [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی به ترتیب ۱۰۰ و ۵۰ پوینت، نکات و فرو رفتگی‌ها را تعریف می‌کنند؛ گام ۷۲ درجه پنج نکته را به‌صورت مساوی فاصله می‌دهد. مسیر با [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) بسته می‌شود و با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) به شکل مستطیلی اعمال می‌گردد و مرز آن را جایگزین می‌کند.

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
![مثال۳_تصویر](custom_shape_3.png)

## **ایجاد یک شکل ترکیبی سفارشی**

این مثال دو شیء بستهٔ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) برای یک‑سوم و دو‑سوم بالای یک شکل تعریف می‌کند. اعمال هر دو مسیر با [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل ترکیبی واحد با یک فضای خالی در یک‑سوم میانی ایجاد می‌کند.

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
![مثال۴_تصویر](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال بخش‌های مستقیم را با [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) ترکیب می‌کند تا شکلی با گوشه‌های منحنی به سمت داخل بسازد. هر اندازهٔ گوشه عرض و ارتفاع قوس را به پوینت تنظیم می‌کند و چرخش ‑۹۰ درجه یک چهارم‌بیضی را در جهت ساعت‌گرد مخالف می‌کشد. مسیر تکمیل‌شده با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌گردد.

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

## **پیدا کردن اینکه آیا هندسهٔ یک شکل بسته است**

این کمکی بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک بخش بسته پایان می‌یابد یا خیر. این تابع [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) را می‌خواند و دستور نهایی [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) را با [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیرهای غیرخالی وجود نداشته باشند، مقدار false بر می‌گرداند. این بررسی فقط دستور نهایی هر مسیر را می‌سنجد؛ زیرشکل‌های هر مسیر را بررسی نمی‌کند. مثال برای یک مستطیل مقدار `true` چاپ می‌کند.

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

## **استخراج و بازرسی عناصر شکل**

از [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) برای بازرسی یک شکل موجود به‌عنوان عناصری که نقاط مسیر و انواع نقطه را شامل می‌شوند، استفاده کنید. هر [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) بازگردانده‌شده را می‌توانید با متدهای [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) و [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) آرایهٔ نقاط و انواع دریافت کنید. این نمایش برای تحلیل مرز یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل input.pptx را باز می‌کند، اولین شکل هندسی را مستقیماً در اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌کند. از یک ارائه حاوی شکلی با بخش‌های مستقیم و منحنی استفاده کنید تا هر دو نوع خروجی را ببینید. این روش داخل گروه‌ها را جستجو نمی‌کند.

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
                const pointType = types[i] & 0x07; // نوع بخش را نگه داشته و پرچم‌ها را حذف کنید.
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

آرایه‌ها بر اساس اندیس مطابقت دارند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را شروع می‌کند و نوع `1` خطی از نقطهٔ قبلی به نقطهٔ فعلی می‌کشد. یک بخش Bézier مکعب از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع `3` استفاده می‌کند: دو نقطهٔ کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را همزمان مصرف می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌کند.

انواع نقطه همچنین پرچم‌هایی دارند. با ماسک `0x07` نوع بخش را شناسایی کنید و با `0x80` جداگانه برای تشخیص زیرمسیر بسته تست کنید. برای مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خط است که زیرمسیری را می‌بندد و `131` (`0x83`) به معنای نقطهٔ انتهایی Bézier است که یکی را می‌بندد. جاوا این پرچم‌ها را در بایت‌های امضا ذخیره می‌کند؛ ماسک کردن مقادیر بایت اصلی را حفظ می‌کند. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند خط‌چین (`0x10`) و نشانگر (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل بدون گروه، مختصات استخراج‌شده قبلاً موقعیتی را که توسط [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) و [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) بازگردانده شده، شامل می‌شود و عرض و ارتفاع فعلی را منعکس می‌کند. به‌عنوان مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` دارای مرزهای `(100, 200)`‑`(220, 280)` است. موقعیت شکل را دوباره اضافه نکنید. برای به‌دست آوردن مختصات نسبت به قاب بدون چرخش، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل، که توسط [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) بازگردانده می‌شود، یا وارونگی افقی و عمودی را اعمال نمی‌کنند. برای بازآفرینی مرز نمایشی، این تبدیلات را دور مرکز شکل اعمال کنید. برای اشکال گروهی، نقشهٔ مختصات گروه و تبدیلات آن را نیز در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده نهایی‌ترین مختصات اسلاید هستند یا ترجمه یا مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده باشد.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده مرز را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روزرسانی نمی‌کند. وقتی تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد، این روش را انتخاب کنید. وقتی به دستورات هندسه در سیستم مختصات محلی شکل نیاز دارید یا می‌خواهید هندسهٔ آن را ویرایش کنید، از [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) یا [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) اعمال کنید.

## **تبدیل یک Java AWT Shape به GeometryPath**

این مثال یک مرز مستطیلی را با متنی که به هندسه تبدیل شده ترکیب می‌کند. متد [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) مرز را خالی می‌کند. یک [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) خط متن را در یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ایجاد می‌کند. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن حرکت، خط، درجه‌دو، مکعب و بخش‌های بسته را تأمین می‌کند که مثال آن‌ها را روی یک [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) بازپخش می‌کند.

پل جاوا از مقادیر شناور (float) و بایت صریح برای پارامترهای متناظر جاوا استفاده می‌کند. تکرارگر مختصات‌ها را در یک آرایهٔ float جاوا می‌نویسد؛ بازتاب مقادیر به‌روز شده را به JavaScript می‌خواند. متن با قلم Arial با اندازهٔ ۴۰ پوینت رسم می‌شود. مرز ۲۰ پوینت به صورت افقی جابجا شده و بالای بصری آن ۱۰ پوینت زیر لبهٔ بالایی شکل قرار می‌گیرد. مسیر متن پر می‌شود، در حالی که مستطیل اصلی به‌صورت مرز باقی می‌ماند. اعمال هر دو مسیر با [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل واحد شامل مستطیل و متن تولید می‌کند.

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
            case 2: // منحنی Bézier درجه دو.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // منحنی Bézier مکعب.
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
![مثال۵_تصویر](custom_shape_5.png)

## **پرسش‌های متداول**

**پس از جایگزینی هندسه، پرکننده و مرز چه می‌شود؟**

استایل با شکل باقی می‌ماند؛ فقط مرز تغییر می‌کند. پرکننده و مرز به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه شکل سفارشی را به‌طور صحیح همراه با هندسه‌اش بچرخانم؟**

از متد shape’s [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) استفاده کنید؛ هندسه همراه با شکل می‌چرخد چون به سیستم مختصات خود شکل وصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ موردنیاز [slide](/slides/fa/nodejs-java/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/nodejs-java/create-shape-thumbnails/) را به فرمت رستری صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده می‌کند.