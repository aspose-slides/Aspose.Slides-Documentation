---
title: مدیریت اشکال ارائه در PHP
linktitle: دستکاری شکل
type: docs
weight: 40
url: /fa/php-java/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل در اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه Interop شکل
- متن جایگزین شکل
- قالب‌بندی‌های لایه شکل
- شکل به عنوان SVG
- شکل به SVG
- تراز کردن شکل
- چرخاندن شکل
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، کلون، حذف، مخفی، ترتیب‌دهی مجدد، صادر، تراز و چرخاندن کنید با Aspose.Slides برای PHP از طریق Java."
---
## **بررسی کلی**

Aspose.Slides for PHP via Java اشکال موجود در یک اسلاید را به‌عنوان یک [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) مرتب‌شده نمایش می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و اصلاح کنید و هم منبع ترتیب انباشته‌شدن آنها است: ایندکس `0` به پشت‌ترین شکل اشاره دارد، در حالی که آخرین ایندکس به جلو‌ترین شکل اشاره می‌کند.

این مقاله از همان مدل پیروی می‌کند. ابتدا نحوه شناسایی مطمئن یک شکل را شرح می‌دهد، سپس نشان می‌دهد چگونه اشکال را کلون، حذف، مخفی و ترتیب‌دهی مجدد کنید. بخش‌های نهایی به قالب‌بندی در سطح لایه، صادر کردن به SVG، تراز کردن و تنظیمات چرخاندن می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید فقط عملیاتی را که در جریان کاری شما لازم است استفاده کنید.

## **شناسایی و یافتن اشکال**

ایندکس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده مفید هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا تغییر ترتیب یک شکل می‌تواند ایندکس آن را تغییر دهد. یک شناسه را بر اساس نحوهٔ ایجاد و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getname/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب پاورپوینت به‌راحتی قابل مشاهده است. نام‌ها قابل ویرایش‌اند و تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آنها وابسته است یک کنوانسیون نامگذاری برقرار کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getalternativetext/) زمانی مفید است که یک توصیف دسترسی یا برچسب ارائه‌شده توسط نویسنده پیش از این شکل را شناسایی کرده باشد. این متن برای کاربران قابل مشاهده است، ممکن است بومی‌سازی یا برای دسترسی بازنویسی شود و تضمین یکتایی نمی‌کند. متن معنادار دسترسی را به‌صورت خاموش به عنوان کلید پایگاه‌داده استفاده نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getofficeinteropshapeid/) یک شناسهٔ فقط‌خواندنی است که در یک اسلاید یکتا بوده و به شناسهٔ شکل مورد استفاده توسط PowerPoint Interop مطابقت دارد. هنگام یکپارچه‌سازی با PowerPoint یا زمانی که به مرجع بدون ابهام در طول عمر شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‌شده یا بازساخته شکل متفاوتی است و شناسهٔ خود را دریافت می‌کند.

متد مرتبط [Shape::getUniqueId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getuniqueid/) شناسه‌ای با دامنهٔ ارائه باز می‌گرداند، اما این شناسه برای افزونه‌ها در نظر گرفته شده و می‌تواند بازتخصیص یابد. نباید به‌عنوان کلید خارجی دائمی رفتار شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه‌دارید و اطمینان حاصل کنید که شکل مورد انتظار همچنان وجود دارد.

مثال زیر با مقایسهٔ دقیق بر اساس نام جستجو می‌کند و شناسهٔ Interop scoped به اسلاید را گزارش می‌دهد. زمانی که قالب شامل شکل مورد انتظار نباشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامه دادن با شیء اشتباه.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

وقتی عملیاتی به نوع خاصی از شکل مربوط می‌شود، قبل از استفاده از اعضای مخصوص نوع، کلاس زمان اجرا را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روزرسانی می‌کند که شیء نام‌دار یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) باشد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و تغییر ترتیب بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، دیگر بر ایندکس‌های گرفته‌شده قبل از آن عملیات تکیه نکنید.

### **کلون کردن یک شکل**

[ShapeCollection::addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addclone/) یک کپی مستقل ایجاد کرده و به انتهای مجموعه هدف اضافه می‌کند. [ShapeCollection::insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/insertclone/) نیز یک کپی می‌سازد اما آن را در ایندکس z‑order مشخص می‌گذارد. نسخه‌های overload که مختصات می‌پذیرند، کلون را بدون تغییر اندازه جابه‌جا می‌کنند؛ overloadهای با عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد ایجاد می‌کند، یک مستطیل برچسب‌دار را به جلوی اسلاید کلون می‌کند و یک کلون دوم را در پشت وارد می‌کند. تغییرات روی هر دو کلون منبع شکل را تحت تأثیر قرار نمی‌دهد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

کلون کردن محتوا و قالب‌بندی شکل را کپی می‌کند، از جمله نام و متن جایگزین آن. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع مورد استفادهٔ اشکال پیچیده توسط ارائه مدیریت می‌شوند، اما یک کلون همچنان یک آیتم جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[ShapeCollection::remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/remove/) یک شیء شکل خاص را از مجموعهٔ خود حذف می‌کند. هنگام حذف چندین مورد مطابق در حین تکرار ایندکس‌دار، از انتها به شروع پیش بروید تا هر ایندکس باقی‌مانده معتبر بماند.

این مثال هر شکلی که نام تعیین‌شده داشته باشد را حذف می‌کند. شکل را در ایندکس جاری می‌خواند، نه یک آیتم ثابت مجموعه، و نیازی به تبدیل نوع ناخواسته ندارد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

پس از حذف، تعداد اشکال و ایندکس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکال غیرمffected معتبرتر از ایندکس‌های ذخیره‌شده است. همچنین به اتصال‌ها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی کردن یک شکل**

تنظیم [Shape::setHidden](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/sethidden/) به `true` شکل را در مجموعه نگه می‌دارد اما از نمایش در نمایش اسلاید عادی جلوگیری می‌کند. ایندکس، قالب‌بندی و محتوا برای کد قابل دسترسی باقی می‌مانند، بنابراین مخفی کردن برای عناصر اختیاری مناسب است که ممکن است بعداً بازگردانده شوند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مخفی کردن حذف یا امنیت نیست. شیء همچنان می‌تواند توسط کاربر یا کد کشف و دوباره نمایان شود و بخشی از فایل ارائه می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده بر اساس ترتیب مجموعه رنگ می‌شوند. [ShapeCollection::reorder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/reorder/) یک شکل موجود را به ایندکس هدف منتقل می‌کند بدون اینکه آن را کلون کند. ایندکس `0` پشت است؛ `size() - 1` جلوی است.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مستطیل ابتدا ایجاد می‌شود و در ابتدا پشت بیضی قرار دارد. جابه‌جایی آن به ایندکس نهایی، آن را به جلو می‌برد. پس از افزودن یا کلون کردن تمام اشکال مرتبط، ترتیب z‑order را نهایی کنید، زیرا این عملیات آیتم‌های جدیدی به مجموعه اضافه یا درج می‌کند و می‌تواند ساختار انبار موردنظر را تغییر دهد.

## **بازرسی اشکال در اسلایدهای لایه‌ای**

اسلایدهای عادی، اسلایدهای لایه‌ای و اسلایدهای مستر دارای مجموعهٔ اشکال جداگانه‌ای هستند. یک شکل در مجموعهٔ لایه‌ای همان شیء شکل موقعیت‌دار در اسلاید عادی نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک لایه، اشکال لایه را بررسی کنید.

مثال زیر [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getfillformat/) و [LineFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getlineformat/) هر شکل لایه را می‌خواند بدون این که فرض کند هر شکل یک `AutoShape` است.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

ویرایش یک لایه می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند تأثیر بگذارد. قبل از تغییر یک شکل لایه، تعیین کنید آیا اسلاید عادی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد، و هر اسلایدی که از آن لایه استفاده می‌کند را تست کنید.

## **صادرات یک شکل به SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/writeassvg/) محتوی رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل فقط همان شکل است، نه پس‌زمینهٔ کل اسلاید یا اشکال همجوار.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

در حین رندر، ارائه باید باز باشد. خروجی به قالب‌بندی شکل و منابعی مانند فونت‌ها و تصاویر وابسته است. اگر به کل ترکیب‌بندی نیاز دارید، اسلاید را به‌جای یک شکل منفرد صادر کنید. فراخواننده مالک جریان است و باید آن را ببندد.

## **تراز کردن اشکال**

متدهای overload شدهٔ [SlideUtil::alignShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/alignshapes/) می‌توانند یا تمام اشکال یا ایندکس‌های منتخب مجموعه را تراز کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapesalignmenttype/) لبه، خط مرکز یا حالت توزیع را مشخص می‌کند. مقدار `alignToSlide` را به `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ به `false` تنظیم کنید تا اشکال انتخاب‌شده نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید تراز می‌کند. ارجاع‌های شکل بازگشتی بلافاصله قبل از تراز به ایندکس‌های فعلیشان تبدیل می‌شوند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تراز کردن موقعیت‌ها را تغییر می‌دهد، نه z‑order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به اندازه کافی شکل برای تعریف فاصله‌ها نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر می‌دهید، ایندکس‌ها را دوباره محاسبه کنید.

## **چرخاندن یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و دوران را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از [NullableBool](https://reference.aspose.com/slides/fa/php-java/aspose.slides/nullablebool/) استفاده می‌کنند: `True` چرخش را فعال می‌کند، `False` آن را غیرفعال می‌کند و `NotDefined` حالت پیش‌فرض/نامشخص را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون چرخش است.

![شکل قبل از چرخاندن](shape_to_be_flipped.png)

مثال تمام مقادیر دیگر فریم را حفظ می‌کند و فقط دو تنظیم چرخش را جایگزین می‌کند. این مهم است زیرا اختصاص یک [Frame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/setframe/) جدید تمام فریم را بازنویسی می‌کند.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

شکل ذخیره‌شده به صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و دوران خود را حفظ می‌کند.

![شکل پس از چرخاندن](flipped_shape.png)

## **پرسش‌های متداول**

**آیا باید از ایندکس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که مجموعه قبل از استفاده از ایندکس تغییر نخواهد کرد. برای قالب‌های ساخته‌شده ترجیحاً از یک کنوانسیون معتبر `Name` یا `AlternativeText` استفاده کنید، یا برای کارهای Interop scoped به اسلاید `OfficeInteropShapeId` به‌کار ببرید.

**آیا مخفی کردن یک شکل آن را از z‑order حذف می‌کند؟**

نه. یک شکل مخفی در همان ایندکس در مجموعه باقی می‌ماند. می‌توان آن را یافت، ترتیب داد، ویرایش یا دوباره قابل مشاهده کرد.

**چرا یک شکل کلون‌شده جلوی شکل دیگری ظاهر شد؟**

`addClone` کلون را به انتهای مجموعه می‌افزاید که جلوی z‑order است. برای انتخاب ایندکس اولیه از `insertClone` استفاده کنید یا پس از افزودن تمام اشکال از `reorder` بهره بگیرید.