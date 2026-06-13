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
- هندسهٔ شکل
- مسیر هندسی
- نقاط مسیر
- نقاط ویرایش
- افزودن نقطه
- حذف نقطه
- عملیات ویرایش
- گوشهٔ منحنی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ساخت و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با جاوااسکریپت و Aspose.Slides برای Node.js: مسیرهای هندسی، گوشه‌های منحنی، اشکال مرکب."
---
## **بررسی کلی**

این مقاله نحوهٔ شخصی‌سازی اشکال ارائه در Aspose.Slides را با ویرایش هندسهٔ شکل از طریق نقاط ویرایش و مسیرهای هندسی توضیح می‌دهد. همچنین نشان می‌دهد چگونه با `GeometryPath` می‌توان شکل‌های موجود را تغییر داد، عملیات پایهٔ ویرایش مسیر را انجام داد، نقاط را افزود یا حذف کرد و هندسهٔ به‌روز شده را به شکل اعمال کرد.

علاوه بر این، چگونگی ایجاد اشکال سفارشی و مرکب، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسهٔ یک شکل بسته است یا نه، و تبدیل بین `GeometryPath` و `java.awt.Shape` برای سناریوهای پیشرفتهٔ سفارشی‌سازی هندسه را نشان می‌دهد.

## **تغییر شکل با استفاده از نقاط ویرایش**

یک مربع را در نظر بگیرید. در PowerPoint، با استفاده از **نقاط ویرایش** می‌توانید

* گوشهٔ مربع را به داخل یا خارج حرکت دهید
* انحنای یک گوشه یا نقطه را مشخص کنید
* نقاط جدیدی به مربع اضافه کنید
* نقاط روی مربع را دستکاری کنید و غیره

در واقع می‌توانید این کارها را بر روی هر شکلی انجام دهید. با استفاده از نقاط ویرایش می‌توانید یک شکل را تغییر دهید یا شکل جدیدی از یک شکل موجود بسازید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

قبل از اینکه شروع به ویرایش اشکال PowerPoint از طریق نقاط ویرایش کنید، ممکن است این نکات را در مورد اشکال در نظر بگیرید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* وقتی یک شکل بسته است، نقطهٔ شروع یا پایان ندارد. وقتی یک شکل باز است، دارای شروع و پایان است.
* همهٔ اشکال حداقل از ۲ نقطهٔ لنگر تشکیل شده‌اند که توسط خطوط به یکدیگر متصل هستند.
* یک خط می‌تواند مستقیم یا منحنی باشد. نقاط لنگر ماهیت خط را تعیین می‌کنند.
* نقاط لنگر می‌توانند به صورت نقطهٔ گوشه، نقطهٔ مستقیم یا نقطهٔ صاف وجود داشته باشند:
  * نقطهٔ گوشه نقطه‌ای است که در آن دو خط مستقیم با یک زاویه به هم می‌پیوندند.
  * نقطهٔ صاف نقطه‌ای است که در آن دو دسته (handle) در یک خط مستقیم قرار دارند و قطعات خط به صورت یک منحنی نرم به هم می‌پیوندند. در این حالت همهٔ دسته‌ها با فاصلهٔ مساوی از نقطهٔ لنگر جدا شده‌اند.
  * نقطهٔ مستقیم نقطه‌ای است که در آن دو دسته در یک خط مستقیم قرار دارند و قطعات خط به صورت یک منحنی نرم به هم می‌پیوندند. در این حالت دسته‌ها نیازی به فاصلهٔ مساوی از نقطهٔ لنگر ندارند.
* با جابه‌جایی یا ویرایش نقاط لنگر (که زاویهٔ خطوط را تغییر می‌دهد) می‌توانید ظاهر یک شکل را تغییر دهید.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [**GeometryPath**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) و کلاس [**GeometryPath**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) مسیر هندسی شیٔ [GeometryShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape) را نشان می‌دهد.
* برای دریافت `GeometryPath` از نمونهٔ `GeometryShape` می‌توانید از متد [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) استفاده کنید.
* برای تنظیم `GeometryPath` برای یک شکل، می‌توانید از این متدها استفاده کنید: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) برای *اشکال جامد* و [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) برای *اشکال مرکب*.
* برای افزودن قطعات می‌توانید از متدهای موجود در [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) استفاده کنید.
* با استفاده از متدهای [GeometryPath.setStroke](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) و [GeometryPath.setFillMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [GeometryPath.getPathData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath#getPathData--) می‌توانید مسیر هندسی یک `GeometryShape` را به‌صورت آرایه‌ای از قطعات مسیر دریافت کنید.
* برای دسترسی به گزینه‌های پیشرفتهٔ سفارشی‌سازی هندسهٔ شکل، می‌توانید [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) را به [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) تبدیل کنید.
* از متدهای [geometryPathToGraphicsPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) و [graphicsPathToGeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (از کلاس [ShapeUtil](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeUtil)) برای تبدیل [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) به [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) و بالعکس استفاده کنید.

## **عملیات سادهٔ ویرایش**

این کد JavaScript نشان می‌دهد چگونه:

**اضافه کردن یک خط** به انتهای مسیر

```javascript
lineTo(point);
lineTo(x, y);
```
**اضافه کردن یک خط** به یک موقعیت مشخص در مسیر:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**اضافه کردن یک منحنی Bezier مکعبی** در انتهای مسیر:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**اضافه کردن یک منحنی Bezier مکعبی** به موقعیت مشخصی در مسیر:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**اضافه کردن یک منحنی Bezier درجهٔ دو** در انتهای مسیر:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**اضافه کردن یک منحنی Bezier درجهٔ دو** به موقعیت مشخصی در مسیر:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**حلقه‌ای (arc) معین** را به مسیر اضافه کنید:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**بستن شکل فعلی** مسیر:

```javascript
closeFigure();
```
**تنظیم موقعیت نقطهٔ بعدی**:

```javascript
moveTo(point);
moveTo(x, y);
```
**حذف قطعهٔ مسیر** در یک ایندکس داده شده:

```javascript
removeAt(index);
```

## **افزودن نقاط سفارشی به شکل**
1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape) ایجاد کنید و نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeType) را تنظیم کنید.
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) را از شکل دریافت کنید.
3. یک نقطهٔ جدید بین دو نقطهٔ بالای مسیر اضافه کنید.
4. یک نقطهٔ جدید بین دو نقطهٔ پایین مسیر اضافه کنید.
5. مسیر را به شکل اعمال کنید.

این کد JavaScript نشان می‌دهد چگونه نقاط سفارشی به یک شکل اضافه کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **حذف نقاط از شکل**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape) ایجاد کنید و نوع [ShapeType.Heart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeType) را تنظیم کنید.
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) را از شکل دریافت کنید.
3. قطعهٔ مسیر را حذف کنید.
4. مسیر را به شکل اعمال کنید.

این کد JavaScript نشان می‌دهد چگونه نقاط را از یک شکل حذف کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **ایجاد شکل سفارشی**

1. نقاط مورد نیاز برای شکل را محاسبه کنید.
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) ایجاد کنید.
3. مسیر را با نقاط پر کنید.
4. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape) ایجاد کنید.
5. مسیر را به شکل اعمال کنید.

این کد JavaScript نشان می‌دهد چگونه یک شکل سفارشی بسازید:

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)


## **ایجاد شکل سفارشی مرکب**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape) ایجاد کنید.
2. یک نمونهٔ اول از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) ایجاد کنید.
3. یک نمونهٔ دوم از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) ایجاد کنید.
4. مسیرها را به شکل اعمال کنید.

این کد JavaScript نشان می‌دهد چگونه یک شکل سفارشی مرکب ایجاد کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **ایجاد شکل سفارشی با گوشه‌های منحنی**

این کد JavaScript نشان می‌دهد چگونه یک شکل سفارشی با گوشه‌های منحنی (به سمت داخل) ایجاد کنید:

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
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
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

یک شکل بسته به‌عنوان شکلی تعریف می‌شود که تمام اضلاع آن به‌هم وصل شده‌اند و یک مرز پیوسته بدون شکاف تشکیل می‌دهند. چنین شکلی می‌تواند یک فرم هندسی ساده یا یک نقشهٔ سفارشی پیچیده باشد. مثال کد زیر نشان می‌دهد چگونه بررسی کنید آیا هندسهٔ یک شکل بسته است یا نه:

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **تبدیل GeometryPath به java.awt.Shape**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape) ایجاد کنید.
2. یک نمونه از کلاس [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ایجاد کنید.
3. نمونهٔ [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) را با استفاده از [ShapeUtil](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeUtil) به نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryPath) تبدیل کنید.
4. مسیرها را به شکل اعمال کنید.

این کد JavaScript—که پیاده‌سازی مراحل فوق است—فرآیند تبدیل **GeometryPath** به **GraphicsPath** را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // ایجاد شکل جدید
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // دریافت مسیر هندسی شکل
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // ایجاد مسیر گرافیکی جدید با متن
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // تبدیل مسیر گرافیکی به مسیر هندسی
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // تنظیم ترکیب مسیر هندسی جدید و مسیر هندسی اصلی برای شکل
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **سوالات متداول**

**پس از تعویض هندسه، پرکننده و قالب‌بندی خطی چه می‌شود؟**

سبک همانند شکل باقی می‌ماند؛ فقط کانتور تغییر می‌کند. پرکننده و خط به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توان یک شکل سفارشی را به‌طور صحیح همراه با هندسهٔ آن چرخاند؟**

از متد [setRotation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/setrotation/) شکل استفاده کنید؛ هندسه به‌دلیل ارتباط با سیستم مختصات خود شکل، به همراه آن می‌چرخد.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ [slide](/slides/fa/nodejs-java/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/nodejs-java/create-shape-thumbnails/) مورد نیاز را به قالب رستر خروجی بگیرید؛ این کار کار با هندسه‌های سنگین را ساده‌تر می‌کند.