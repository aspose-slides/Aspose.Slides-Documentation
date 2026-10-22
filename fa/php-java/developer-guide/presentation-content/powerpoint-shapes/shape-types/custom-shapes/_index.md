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
- PHP
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **مروری کلی**

این مقاله نحوهٔ سفارشی‌سازی اشکال ارائه در Aspose.Slides را با ویرایش هندسهٔ شکل از طریق نقاط ویرایشی و مسیرهای هندسی توضیح می‌دهد. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) کار کنید تا اشکال موجود را تغییر دهید، عملیات پایهٔ ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسهٔ به‌روزشده را به یک شکل اعمال کنید.

همچنین نحوهٔ ایجاد اشکال سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسهٔ شکل بسته است یا نه، بررسی عناصر شکل و تبدیل خطوط متن Java AWT به مسیرهای هندسی را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایشی**

در PowerPoint می‌توانید از **نقاط ویرایشی** برای تغییر یک مربع استفاده کنید:

* یک گوشه را به سمت داخل یا خارج حرکت دهید.
* انحنای یک نقطه را تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما امکان می‌دهد خطوط بیرونی یک شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایهٔ یک شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint این مفاهیم را در نظر بگیرید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل به‑دیگر توسط بخش‌ها تشکیل شده است.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترلی شکل آن را تعیین می‌کنند.
* نقاط لنگر به صورت نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف وجود دارند:
  * در یک نقطهٔ گوشه‌ای، بخش‌های مجاور می‌توانند با زاویه‌ای به یکدیگر ملحق شوند.
  * در یک نقطهٔ صاف، دو دستهٔ کنترل هم‌راستا هستند و فاصلهٔ مساوی از نقطهٔ لنگر دارند.
  * در یک نقطهٔ مستقیم، دو دستهٔ کنترل هم‌راستا هستند اما می‌توانند فاصلهٔ متفاوتی از نقطهٔ لنگر داشته باشند.
* جابجا کردن نقاط لنگر یا تنظیم دسته‌های آن‌ها، خطوط بیرونی شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایشی، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) مسیر هندسی شیء [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) از نمونهٔ [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)، می‌توانید از متد [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) برای یک شکل، می‌توانید این متدها را استفاده کنید: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) برای اشکالی که یک مسیر دارند و [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) برای اشکالی که چند مسیر دارند.
* برای افزودن بخش‌ها می‌توانید از متدهای زیر در [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) استفاده کنید.
* با استفاده از متدهای [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) و [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.
* برای دسترسی به گزینه‌های سفارشی‌سازی بیشتر هندسهٔ شکل، می‌توانید یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) را از طریق [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) بخوانید و بخش‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) بازپخش کنید.

## **عملیات ویرایش ساده**

از متدهای زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌های پذیرندهٔ یک شاخص، یک بخش را در آن موقعیت مبتنی بر صفر در آرایهٔ بخش‌های مسیر درج می‌کند.

| عملگر | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| افزودن یا درج یک منحنی Bézier مکعبی با دو نقطهٔ کنترل و یک نقطهٔ پایان. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| افزودن یا درج یک منحنی Bézier درجهٔ دوم با یک نقطهٔ کنترل و یک نقطهٔ پایان. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| افزودن یک قوس بیضوی با ابعاد و زوایای مشخص به درجه. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| بسته کردن شکل جاری با اتصال نقطهٔ پایان به نقطهٔ شروع آن. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| حذف یک بخش در یک شاخص مبتنی بر صفر. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) وارد می‌کند و مسیر ویرایش‌شده را با [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌نماید. مختصات‌ها به‌صورت محلی نسبت به شکل هستند: هر دو نقطهٔ جدید در مرکز آن، ۱۰۰ پوینت از سمت چپ و ۵۰ پوینت از بالا قرار دارند. شاخص‌های بخش ۱ و ۴ آن‌ها را بر روی لبه‌های بالایی و پایینی قرار می‌دهد و آن لبه‌ها را به سمت داخل می‌کشد.

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

این مثال طرح یک شکل دل‌نما را با حذف بخش در شاخص صفر‑پایهٔ ۲ با استفاده از [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) تغییر می‌دهد. اعمال مسیر تغییر یافته با [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) مرز شکل را به‌روز می‌کند.

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

این مثال یک ستارهٔ پنج‌پر را با استفاده از [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی به ترتیب ۱۰۰ و ۵۰ پوینت، سرفصل‌ها و تو رفتگی‌ها را تعریف می‌کنند؛ گام ۷۲ درجه، پنج شاخ را به‌صورت مساوی فاصله می‌دهد. مسیر با [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) بسته می‌شود و با [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) بر روی یک شکل مستطیلی اعمال می‌شود و طرح قبلی را جایگزین می‌کند.

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

## **ایجاد یک شکل ترکیبی سفارشی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) بسته برای یک‌سومهٔ بالایی و یک‌سومهٔ پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل ترکیبی واحد با یک فضای خالی در یک‑سومهٔ میانی ایجاد می‌کند.

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

این مثال بخش‌های مستقیم را با [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) ترکیب می‌کند تا شکلی با گوشه‌های داخلی منحنی ایجاد شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را بر حسب پوینت تعیین می‌کند و گردش ‑۹۰ درجه، یک ربع بیضی خلاف‌ساعت را رسم می‌نماید. مسیر کامل با [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌گردد.

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

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

این کمکی بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک بخش بسته به پایان می‌رسد یا نه. با خواندن [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) و مقایسهٔ دستورات نهایی بخش [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) با [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) کار می‌کند. وقتی مسیرهای غیرخالی وجود ندارند مقدار false باز می‌گرداند. این بررسی فقط دستور نهایی هر مسیر را مورد ارزیابی قرار می‌دهد؛ هر زیرشکل داخل مسیر را بررسی نمی‌کند. مثال برای یک مستطیل مقدار `true` را چاپ می‌کند.

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

## **استخراج و بررسی عناصر شکل**

از [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) برای بررسی یک شکل موجود به‌عنوان عناصر حاوی نقاط مسیر و انواع نقاط استفاده کنید. هر [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) بازگردانده‌شده می‌تواند آرایه‌های نقطه و نوع را از طریق متدهای [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) و [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) دریافت کند. این نمایش برای تجزیه و تحلیل مرز یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل input.pptx را باز می‌کند، اولین شکل هندسی را مستقیماً در اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌کند. برای مشاهدهٔ خروجی هر دو نوع خروجی، از یک ارائه شامل شکلی با بخش‌های مستقیم و منحنی استفاده کنید. این ابزار داخل گروه‌ها جستجو نمی‌کند.

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
                $pointType = $types[$i] & 0x07; // نوع بخش را حفظ می‌کند، پرچم‌ها را حذف می‌کند.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // هر دو نقطه کنترل و نقطه انتهایی را مصرف می‌کند.
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

آرایه‌ها به‌صورت ایندکس هم‌خوانی دارند: `$points[$i]` یک نقطه است و `$types[$i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را شروع می‌کند و نوع `1` خطی را از نقطهٔ قبلی به نقطهٔ جاری می‌کشد. یک بخش Bézier مکعبی از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را همزمان مصرف کرده و نقطهٔ انتهایی را برای بسته بودن بررسی می‌کند.

انواع نقاط همچنین پرچم‌هایی دارند. برای شناسایی نوع بخش از ماسک `0x07` استفاده کنید و پرچم `0x80` را جداگانه برای تشخیص زیرمسیر بسته تست کنید. برای مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خط است که زیرمسیر را می‌بندد و `131` (`0x83`) نقطهٔ انتهایی Bézier را نشان می‌دهد که بسته می‌شود. PHP/Java Bridge آرایهٔ بایتی را به عنوان رشتهٔ باینری برمی‌گردد؛ با استفاده از «C*» آن را به مقادیر بایت بدون علامت تبدیل می‌کند. ماسک کردن مقادیر اصلی را حفظ می‌کند. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند خط تیره (`0x10`) و نشانگر (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب پوینت (۱⁄۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل بدون گروه، مختصات استخراج‌شده شامل موقعیتی است که توسط متدهای [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) و [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) بازگردانده می‌شود و عرض و ارتفاع فعلی آن را نشان می‌دهد. برای مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` مرزهای `(100, 200)`–`(220, 280)` دارد. موقعیت شکل را دوباره اضافه نکنید؛ برای به‌دست آوردن مختصات نسبی به چارچوب بدون چرخش، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل که توسط [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) برگردانده می‌شود یا وارون‌های افقی و عمودی را اعمال نمی‌کنند. برای بازتولید مرز نمایش داده‌شده، این تبدیل‌ها را حول مرکز شکل اعمال کنید. برای اشکال گروهی، همچنین باید نگاشت مختصات گروه و تبدیل‌های آن را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید هستند یا ترجمه یا مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده‌اند.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده فقط مرز را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روز نمی‌کند. این روش را وقتی که تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد انتخاب کنید. برای دریافت دستورات هندسی در سیستم مختصات محلی شکل یا برای ویرایش هندسه، از [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) یا [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) اعمال کنید.

## **تبدیل یک Java AWT Shape به GeometryPath**

این مثال یک مرز مستطیلی را با متنی ترکیب می‌کند که به هندسه تبدیل شده است. متد [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) مرز را خالی می‌کند. یک [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) خطوط متن را در یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ایجاد می‌کند. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن حرکت، خط، درجه‌دوم، مکعبی و بخش‌های بسته را ارائه می‌دهد که مثال آن‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) بازپخش می‌کند.

مثال از یک آرایهٔ float جاوا استفاده می‌کند تا PHP/Java Bridge مختصات‌های تولیدشده توسط iterator را حفظ کند. متن با قلم Arial به اندازهٔ ۴۰ پوینت رندر می‌شود. مرز به اندازهٔ ۲۰ پوینت به‌صورت افقی جابجا شده و بالای بصری آن ۱۰ پوینت زیر لبهٔ بالایی شکل قرار دارد. مسیر متن پر می‌شود، در حالی که مستطیل اصلی فقط به‌صورت مرز باقی می‌ماند. اعمال هر دو مسیر با [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل واحد شامل مستطیل و متن تولید می‌کند.

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

## **سوالات متداول**

**بعد از جایگزینی هندسه، پرکردن و خط بیرونی چه می‌شود؟**

سبک با شکل می‌ماند؛ فقط مرز تغییر می‌کند. پرکردن و خط بیرونی به‌طور خودکار بر هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توان یک شکل سفارشی را همراه با هندسهٔ آن به‌درستی چرخاند؟**

از متد [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد زیرا به سیستم مختصات خود شکل وابسته است.

**آیا می‌توان یک شکل سفارشی را به تصویر تبدیل کرد تا «قفل» شود؟**

بله. ناحیهٔ [slide](/slides/fa/php-java/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/php-java/create-shape-thumbnails/) مورد نیاز را به قالب رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌کند.