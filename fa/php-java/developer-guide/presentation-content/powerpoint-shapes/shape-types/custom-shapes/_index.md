---
title: سفارشی‌سازی اشکال ارائه در PHP
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/php-java/custom-shape/
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
- PHP
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه می‌توان اشکال ارائه در Aspose.Slides را با ویرایش هندسه شکل از طریق نقاط ویرایش و مسیرهای هندسی سفارشی کرد. نشان می‌دهد چگونه می‌توان با [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) کار کرد تا اشکال موجود را تغییر دهد، عملیات پایه ویرایش مسیر را انجام دهد، نقاط را اضافه یا حذف کند، و هندسه بروز شده را به یک شکل اعمال کند. همچنین نشان می‌دهد چگونه می‌توان اشکال سفارشی و ترکیبی ایجاد کرد، اشکالی با گوشه‌های منحنی ساخت، تعیین کرد آیا هندسه یک شکل بسته است یا نه، عناصر شکل را بررسی کرد، و خطوط متن Java AWT را به مسیرهای هندسی تبدیل کرد.

## **تغییر یک شکل با استفاده از نقاط ویرایش**

در PowerPoint می‌توانید از **Edit Points** برای تغییر یک مربع استفاده کنید:

* یک گوشه را به سمت داخل یا خارج حرکت دهید.
* در یک نقطه انحنا را تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما اجازه می‌دهد خطوط بیرونی یک شکل را تغییر دهید یا از یک شکل موجود به عنوان پایه برای یک شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در نظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر که توسط بخش‌ها متصل می‌شوند، تشکیل شده است.
* یک بخش می‌تواند صاف یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر می‌توانند به صورت نقاط گوشه‌ای، نقاط صاف یا نقاط نرم وجود داشته باشند:
  * در یک نقطه گوشه‌ای، بخش‌های مجاور می‌توانند با زاویه‌ای به هم بپیوندند.
  * در یک نقطه نرم، دو دسته کنترل هم‌خط هستند و به طور مساوی از نقطه لنگر دور هستند.
  * در یک نقطه صاف، دو دسته کنترل هم‌خط هستند اما می‌توانند فاصله‌های متفاوتی از نقطه لنگر داشته باشند.
* جابه‌جایی نقاط لنگر یا تنظیم دسته‌های آنها، خطوط بیرونی شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) مسیر هندسی شیء [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) را نمایان می‌سازد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) از نمونهٔ [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) می‌توانید از متد [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این متدها استفاده کنید: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) برای شکل‌هایی با مسیر تک‌تکه و [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) برای شکل‌هایی با مسیرهای چندگانه.
* برای افزودن بخش‌ها، می‌توانید از متدهای موجود در [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) استفاده کنید.
* با استفاده از متدهای [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) و [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode)، می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData)، می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) را به صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.
* برای دسترسی به گزینه‌های سفارشی‌سازی بیشتر هندسه شکل، می‌توانید یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) را از طریق [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن بخوانید و بخش‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) بازپخش کنید.

## **عملیات ساده ویرایش**

برای ویرایش یک مسیر هندسی از متدهای زیر استفاده کنید. بارگذاری‌های اضافی که یک ایندکس می‌پذیرند، یک بخش را در موقعیت صفر‑پایهٔ آرایهٔ بخش‌های مسیر قرار می‌دهند.

| عملیات | متد |
| --- | --- |
| افزودن یا وارد کردن یک خط مستقیم. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| افزودن یا وارد کردن یک منحنی کُبیك Bézier با دو نقطهٔ کنترل و یک نقطهٔ انتهایی. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| افزودن یا وارد کردن یک منحنی درجه دو Bézier با یک نقطهٔ کنترل و یک نقطهٔ انتهایی. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| افزودن یک قوس بیضوی با ابعاد و زوایای مشخص به درجه. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| بستن شکل جاری با وصل کردن نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| حذف یک بخش در یک ایندکس صفر‑پایه. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **اضافه کردن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) وارد می‌کند و مسیر ویرایش شده را با [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌نماید. مختصات نسبت به شکل محلی هستند: هر دو نقطه جدید در مرکز آن قرار دارند، ۱۰۰ پوینت از سمت چپ و ۵۰ پوینت از بالا. ایندکس‌های بخش ۱ و ۴ آنها را بر روی لبه‌های بالا و پایین قرار می‌دهند و آن لبه‌ها را به سمت داخل می‌کشند.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **حذف نقاط از یک شکل**

این مثال خطوط بیرونی شکل قلبی را با حذف بخش در ایندکس صفر‑پایهٔ ۲ با استفاده از [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) محدودهٔ شکل را به‌روز می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

این مثال یک ستارهٔ پنج‌سواطیره را با استفاده از [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی به ترتیب ۱۰۰ و ۵۰ پوینت به‌صورت متناوب نقاط نوک و تو رفتگی‌ها را تعریف می‌کنند؛ گام ۷۲ درجه پنج نوک را به‌صورت مساوی از هم فاصله می‌دهد. مسیر با [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) بسته می‌شود و با استفاده از [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) به یک شکل مستطیلی اعمال می‌شود، به‌گونه‌ای که خطوط بیرونی آن جایگزین می‌شود.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **ایجاد یک شکل سفارشی ترکیبی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) بسته برای یک‑سوم‌های بالا و پایین یک شکل تعریف می‌کند. اعمال هر دو مسیر با [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل ترکیبی واحد را با یک فاصله در یک‑سوم میانی آن ایجاد می‌کند.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال بخش‌های صاف را با [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) ترکیب می‌کند تا شکلی با گوشه‌های منحنی به سمت داخل ایجاد شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را بر حسب پوینت تنظیم می‌کند و جابجایی -۹۰ درجه یک ربع‌قوس ساعت‌گرد مخالف ایجاد می‌کند. مسیر کامل با [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌شود.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تشخیص اینکه آیا هندسه یک شکل بسته است**

کمک‌کنندهٔ زیر بررسی می‌کند که آیا هر مسیر هندسی غیر خالی با یک بخش بسته‌سازی پایان می‌یابد یا نه. این تابع [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) را می‌خواند و فرمان نهایی بخش را با [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) مقایسه می‌کند؛ سپس آن را با [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیرهای غیر خالی وجود نداشته باشد، مقدار false برمی‌گرداند. این بررسی تنها فرمان نهایی هر مسیر را مورد بررسی قرار می‌دهد؛ زیرشکل‌های هر مسیر را بررسی نمی‌کند. مثال برای یک مستطیل مقدار `true` را چاپ می‌کند.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **بررسی فرمان‌های مسیر هندسی**

فایل [contour.pptx](contour.pptx) را دانلود کنید و در پوشهٔ کاری برنامه قرار دهید. اولین شکل در اولین اسلاید دارای لبهٔ بالا صاف، یک منحنی کُبیك Bézier و یک لبهٔ بستهٔ صاف است. از [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) برای خواندن مسیرهای شکل و از [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) برای خواندن بخش‌های هر مسیر به ترتیب رسم استفاده کنید. برای هر بخش، [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) فرمان را شناسایی می‌کند و تعیین می‌نماید که مقادیر بازگردانده‌شده توسط [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData) چگونه تفسیر شوند.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

این شکل در مختصات (200, 100) پوینت بر روی اسلاید قرار دارد. مختصات گزارش‌شده به صورت محلی نسبت به شکل هستند، به‌طوری‌که (0, 0) در گوشهٔ بالا‑چپ آن قرار دارد، x به سمت راست افزایش می‌یابد و y به سمت پایین. بخش بسته‌سازی بدون مختصات اضافی به نقطهٔ شروع باز می‌گردد.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```
![شکل PowerPoint با لبهٔ بالایی صاف، لبهٔ منحنی از بالا‑راست به پایین‑چپ، و لبهٔ چپ صاف](contour.png)

## **استخراج و بررسی عناصر شکل**

از [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) برای بررسی یک شکل موجود به عنوان عناصری که شامل نقاط مسیر و انواع نقاط هستند استفاده کنید. از هر [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) بازگردانده‌شده برای دریافت آرایه‌های نقطه و نوع از طریق متدهای [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) و [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) استفاده کنید. این نمایش برای تحلیل خطوط بیرونی یا ارسال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل input.pptx را باز می‌کند، اولین شکل هندسی را مستقیماً در اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌کند. برای مشاهدهٔ خروجی‌های هر دو نوع، از ارائه‌ای استفاده کنید که شامل شکلی با بخش‌های صاف و منحنی باشد. این تابع داخل گروه‌ها جستجو نمی‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // نگه‌دارندهٔ نوع بخش، بدون پرچم‌ها.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // هر دو نقطهٔ کنترل و نقطهٔ انتهایی را مصرف می‌کند.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

آرایه‌ها بر اساس ایندکس مطابقت دارند: `$points[$i]` یک نقطه است و `$types[$i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را آغاز می‌کند، و نوع `1` یک خط را از نقطهٔ قبلی به نقطهٔ جاری می‌کشد. یک بخش کُبیك Bézier از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل به دنبال نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌صورت یکجا مصرف می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌کند.

انواع نقطه همچنین شامل پرچم‌ها می‌شوند. با ماسک `0x07` می‌توانید نوع بخش را شناسایی کنید و `0x80` را جداگانه آزمون کنید تا یک زیرمسیر بسته را تشخیص دهید. برای مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خطی است که یک زیرمسیر را می‌بندد، و `131` (`0x83`) به معنای نقطهٔ انتهایی Bézier است که یک زیرمسیر را می‌بندد. PHP/Java Bridge آرایه بایت را به صورت رشتهٔ باینری برمی‌گرداند؛ آن را با `"C*"` بازگشایی کنید تا مقادیر بایت بدون علامت به دست آید. ماسک‌گذاری مقادیر بیت مورد نظر را حفظ می‌کند. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند dash (`0x10`) و marker (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیلات.** نقاط بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شوند، به طوری که X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل بدون گروه، مختصات استخراج‌شده قبلاً موقعیت برگشتی از [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) و [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) را شامل می‌شود و عرض و ارتفاع کنونی آن را بازتاب می‌دهد. برای مثال، یک مستطیل بدون چرخش در `(100, 200)` با سایز `120 × 80` محدودهٔ خطوط بیرونی `(100, 200)`–`(220, 280)` دارد. موقعیت شکل را دوباره اضافه نکنید. برای به‌دست آوردن مختصات نسبت به قاب بدون چرخش، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل که توسط [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) یا وارونگی افقی و عمودی اعمال می‌شود را در نظر نمی‌گیرند. برای بازتولید خطوط خورده‌شدهٔ نمایش داده‌شده، این تبدیلات را حول مرکز شکل اعمال کنید. برای شکل‌های گروهی، همچنین نگاشت مختصات گروه و تبدیلات آن را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده نهایی‌ترین مختصات اسلاید رندر شده هستند یا ترجمه یا مقیاس را دو بار اعمال نکنید اگر در چارچوب فرزند هم‌اکنون منعکس شده است.

**بازرسی در برابر ویرایش.** آرایه‌های استخراج‌شده فقط خطوط بیرونی را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روز نمی‌کند. هنگام نیاز به آرایه‌های نقطه/نوع برای تحلیل یا کد رسم، از این روش استفاده کنید. وقتی به دستورات هندسی در سیستم مختصات محلی شکل یا نیاز به ویرایش هندسه دارید، از [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) یا [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) اعمال کنید.

## **تبدیل یک Shape از Java AWT به GeometryPath**

این مثال یک خطوط بیرونی مستطیلی را با متنی که به هندسه تبدیل شده ترکیب می‌کند. متد [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) خطوط بیرونی را از پر شدن منع می‌کند. یک [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) خطوط بیرونی متن را در یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ایجاد می‌کند. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) حرکت، خط، درجه دو، کُبیك و بخش‌های بسته‌سازی را فراهم می‌کند که مثال آن‌ها را بر یک [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) بازپخش می‌کند.

مثال از یک آرایه‌ای از اعداد شناور Java استفاده می‌کند تا PHP/Java Bridge مختصات نوشته‌شده توسط iterator را حفظ کند. متن از قلم Arial با اندازهٔ ۴۰ پوینت استفاده می‌کند. خطوط بیرونی ۲۰ پوینت به صورت افقی جابه‌جا شده و بالای بصری آن ۱۰ پوینت زیر لبهٔ بالایی شکل قرار دارد. مسیر متن پر می‌شود، در حالی که مستطیل اصلی به‌عنوان خط بیرونی باقی می‌ماند. اعمال هر دو مسیر با [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل واحد حاوی مستطیل و متن تولید می‌کند.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**بعد از جایگزینی هندسه، پر شدگی و خطوط بیرونی چه می‌شود؟**  
استایل همراه شکل باقی می‌ماند؛ فقط خطوط بیرونی تغییر می‌کند. پر شدگی و خطوط بیرونی به‌صورت خودکار بر هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را به‌طور صحیح همراه با هندسهٔ آن بچرخانم؟**  
از متد [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد چون به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا نتیجه «قفل» شود؟**  
بله. ناحیهٔ مورد نیاز را از [اسلاید](/slides/fa/php-java/convert-powerpoint-to-png/) یا خود [شکل](/slides/fa/php-java/create-shape-thumbnails/) به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌کند.