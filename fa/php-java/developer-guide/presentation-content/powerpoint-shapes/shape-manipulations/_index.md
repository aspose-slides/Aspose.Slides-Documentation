---
title: مدیریت اشکال ارائه در PHP
linktitle: دستکاری شکل
type: docs
weight: 40
url: /fa/php-java/shape-manipulations/
keywords:
- شکل PowerPoint
- شکل ارائه
- شکل روی اسلاید
- یافتن شکل
- کلون شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه interop شکل
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌فرض شکل
- هندسه شکل
- قالب‌بندی‌های طرح‌بندی شکل
- شکل به صورت SVG
- شکل به SVG
- هم‌ترازی شکل
- چرخاندن شکل
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌های ارائه را شناسایی، تنظیم، کلون، حذف، مخفی، دوباره‌چین، خروجی، هم‌ترازی و چرخاندن کنید با Aspose.Slides برای PHP از طریق Java."
---
## **بررسی کلی**

Aspose.Slides for PHP via Java اشکال روی یک اسلاید را به‌صورت یک [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) مرتب‌شده نشان می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و تغییر دهید و هم منبع ترتیب چیدمان آن‌ها: شاخص `0` پشت‌ترین شکل است، در حالی که آخرین شاخص جلوترین شکل است.

این مقاله همین مدل را دنبال می‌کند. ابتدا چگونگی شناسایی مطمئن یک شکل و تغییر نقاط تنظیم پیش‌فرض را توضیح می‌دهد، سپس نشان می‌دهد چگونه اشکال را کپی، حذف، مخفی و دوباره ترتیب دهید. بخش‌های نهایی به قالب‌بندی در سطح لایه، خروجی SVG، هم‌ترازی و تنظیمات چرخش می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید فقط عملیاتی را که نیاز دارید استفاده کنید.

## **شناسایی و یافتن اشکال**

شاخص‌های مجموعه در حین پردازش یک فایل شناخته‌شده راحت هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا دوباره ترتیب دادن یک شکل می‌تواند شاخص آن را تغییر دهد. یک شناسه را بر اساس نحوه ایجاد و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getname/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در صفحهٔ انتخاب PowerPoint به‌راحتی قابل مشاهده است. نام‌ها قابل ویرایش‌اند ولی تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است، یک قرارداد نام‌گذاری برقرار کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getalternativetext/) زمانی مفید است که یک توضیح دسترس‌پذیری یا یک برچسب توسط نویسنده قبلاً شکل را شناسایی می‌کند. این متن برای کاربران قابل مشاهده است، می‌تواند بومی‌سازی یا برای دسترس‌پذیری بازنویسی شود و یکتایی تضمین نمی‌شود. متن دسترس‌پذیری معنادار را به‌صورت خاموش به‌عنوان کلید پایگاه‌داده استفاده نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getofficeinteropshapeid/) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا بوده و با شناسهٔ شکل استفاده‌شده توسط PowerPoint interop مطابقت دارد. وقتی با PowerPoint یکپارچه می‌شوید یا به یک مرجع بدون ابهام در طول عمر شکل نیاز دارید از آن استفاده کنید. یک شکل کپی‌شده یا بازسازی‌شده شکل دیگری است و شناسهٔ خود را دریافت می‌کند.

متد مرتبط [Shape::getUniqueId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getuniqueid/) یک شناسه با دامنهٔ ارائه برمی‌گرداند، اما این شناسه برای افزونه‌هاست و می‌تواند بازتخصیص یابد. نباید به‌عنوان کلید خارجی دائمی استفاده شود. اگر هویت درازمدت ضروری است، نگاشت را در داده‌های برنامه ذخیره کنید و صحت وجود شکل مورد انتظار را تأیید کنید.

مثال زیر با مقایسهٔ دقیق بر اساس نام جستجو می‌کند و شناسهٔ interop مخصوص اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نباشد، کد به‌جای ادامه با شیء اشتباه، همان نتیجه را گزارش می‌کند.

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

هنگامی که عملیاتی به یک نوع شکل خاص محدود می‌شود، قبل از استفاده از اعضای نوع‑خاص، کلاس زمان اجرا را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روز می‌کند که شیء نام‌گذاری‌شده یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) باشد.

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

## **شناسایی و تغییر تنظیمات پیش‌فرض شکل**

اشکال هندسهٔ پیش‌فرض می‌توانند نقاط تنظیمی داشته باشند که ویژگی‌هایی نظیر اندازهٔ گوشه، نسبت پیکان یا زاویهٔ قوس را کنترل می‌کنند. به آن‌ها از طریق مجموعهٔ فقط‑خواندنی [GeometryShape::getAdjustments](https://reference.aspose.com/slides/fa/php-java/aspose.slides/geometryshape/#getAdjustments) دسترسی پیدا کنید. خود مجموعه توسط شکل فراهم می‌شود، اما هر [AdjustValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/) شامل مقداری است که می‌توان آن را تغییر داد.

فقط به یک شاخص ثابت مجموعه تکیه نکنید. از طریق تنظیمات عبور کنید و متد فقط‑خواندنی [AdjustValue::getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/#getType) را بررسی کنید؛ مقدار [ShapeAdjustmentType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapeadjustmenttype/) توصیف می‌کند که تنظیم چه چیزی را کنترل می‌کند. متد فقط‑خواندنی [AdjustValue::getName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/getname/) اطلاعات شناسایی بیشتری می‌دهد و به‌ویژه وقتی یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی دارد، مفید است.

از متدی استفاده کنید که با معنای تنظیم مطابقت دارد:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [setRawValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | ضخامت دم پیکان | `setRawValue` |
| `ArrowheadLength` | طول سر پیکان | `setRawValue` |
| `ArrowheadWidth` | عرض سر پیکان | `setRawValue` |
| `StartAngle` | زاویهٔ شروع پای یا قوس | [setAngleValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | زاویهٔ پایان پای یا قوس | `setAngleValue` |

`getType` و `getName` اطلاعات فقط‑خواندنی برمی‌گردانند. `getRawValue` و `setRawValue` با یک عدد در واحدهای هندسی بومی پیش‌تنظیم کار می‌کنند، در حالی که `getAngleValue` و `setAngleValue` با یک زاویه به درجه کار می‌کنند. تعداد، ترتیب، معنا و بازهٔ معتبر تنظیمات وابسته به پیش‌تنظیم [GeometryShape::getShapeType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/geometryshape/#getShapeType) است. مقداری که برای یک پیش‌تنظیم معتبر است ممکن است برای پیش‌تنظیم دیگر نامعتبر یا اثر متفاوتی داشته باشد.

وقتی `getType` مقدار `ShapeAdjustmentType::Custom` را برمی‌گرداند، API معنای استانداردی برای آن نمی‌شناسد. `getName`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را تغییر ندهید مگر اینکه معنای مورد انتظار و بازهٔ آن شناخته شده باشد. حتی برای انواع شناخته‌شده، قبل از انتخاب مقدار بررسی کنید که آیا همان نوع بیش از یک‌بار رخ می‌دهد یا نه. مقالهٔ [Connector](/slides/fa/php-java/connector/) این وضعیت را با تنظیمات خم‌شدن وصل‌کننده نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و اصلاح‌شدهٔ سه شکل پیش‌تنظیم شده را می‌سازد. برای هر تنظیم، نام و نوع آن را گزارش می‌کند، مقادیر مرتبط با اندازه را از طریق `setRawValue`، زاویه‌ها را از طریق `setAngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسهٔ پیش‌فرض را نگه می‌دارد؛ ستون راست مستطیل گرد، پیکان چهار‌طرفه و پای تنظیم‌شده را نشان می‌دهد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // سرفصل‌های ستون‌های شکل پیش‌فرض و تنظیم‌شده را اضافه کنید.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

بررسی نوع معنایی قبل از تغییر مقدار، کد را شفاف می‌کند و از این‌که یک شاخص خاص در پیش‌تنظیم‌های مختلف همان معنا داشته باشد، جلوگیری می‌کند.

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کپی، حذف و دوباره‌چیدن مستقیماً بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن نیازی به ادامهٔ استفاده از شاخص‌های گرفته‌شده پیش از آن عمل ندارید.

### **کپی یک شکل**

[ShapeCollection::addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addclone/) یک کپی مستقل می‌سازد و به انتهای مجموعه هدف اضافه می‌کند. [ShapeCollection::insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/insertclone/) نیز یک کپی می‌سازد اما آن را در یک شاخص z‑order مشخص قرار می‌دهد. بارگذاری‌های پذیرش مختصات کپی را بدون تغییر اندازه جابه‌جا می‌کنند؛ بارگذاری‌های پذیرش عرض و ارتفاع می‌توانند آن را نیز تغییر اندازه دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلو کپی می‌کند و یک کپی دوم را در پشت وارد می‌کند. تغییر در هر یک از کپی‌ها شکل منبع را تحت تأثیر قرار نمی‌دهد.

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

کپی کردن محتوای شکل و قالب‌بندی آن را شامل می‌شود، از جمله نام و متن جایگزین. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کپی اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شوند، اما یک کپی آیتم جدیدی در مجموعه با شناسهٔ شکل جدید می‌شود.

### **حذف اشکال**

[ShapeCollection::remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/remove/) یک شیء شکل خاص را از مجموعهٔ خود حذف می‌کند. هنگام حذف چندین مورد مطابقت‌دار در یک حلقهٔ شاخصی، از انتها به ابتدا عبور کنید تا هر شاخص باقی‌مانده معتبر بماند.

این مثال هر شکلی را که نام تعیین‌شده دارد حذف می‌کند. شکل را در شاخص جاری می‌خواند، نه یک آیتم ثابت مجموعه، و نیازی به تبدیل غیرضروری شکل ندارد.

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

پس از حذف، تعداد اشکال و شاخص‌های اشکال بعدی تغییر می‌کند. ارجاع‌ها به اشکال غیرقابل‌حذف نسبت به شاخص‌های ذخیره‌شده قابل اعتمادتر هستند. همچنین اتصالات، انیمیشن‌ها و سایر ویژگی‌های ارائه‌ای که ممکن است به شیء حذف‌شده اشاره داشته باشند را در نظر بگیرید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی کردن یک شکل**

تنظیم [Shape::setHidden](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/sethidden/) روی `true` شکل را در مجموعه نگه می‌دارد اما مانع نمایش آن در نمایش عادی اسلاید می‌شود. شاخص، قالب‌بندی و محتوای آن برای کد در دسترس می‌مانند، بنابراین مخفی‌کردن برای عناصر اختیاری که ممکن است بعدها بازگردانده شوند مناسب است.

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

مخفی‌کردن حذف یا امنیت نیست. شیء هنوز می‌تواند توسط کاربر یا کد کشف و دوباره آشکار شود و همچنان بخشی از فایل ارائه باقی می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده بر اساس ترتیب مجموعه نقاشی می‌شوند. [ShapeCollection::reorder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/reorder/) یک شکل موجود را به یک شاخص هدف منتقل می‌کند بدون اینکه آن را کپی کند. شاخص `0` پشت است؛ `size() - 1` جلو.

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

مستطیل ابتدا ساخته می‌شود و ابتدا پشت بیضی قرار می‌گیرد. جابه‌جایی به شاخص نهایی آن را به جلو می‌برد. پس از افزودن یا کپی تمام اشکال مرتبط، Z‑order را نهایی کنید، زیرا این عملیات آیتم‌های جدیدی به مجموعه اضافه یا درج می‌کنند و می‌توانند چیدمان موردنظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای لایه‌ای**

اسلایدهای عادی، اسلایدهای لایه‌ای و اسلایدهای اصلی دارای مجموعهٔ اشکال جداگانه‌ای هستند. یک شکل در مجموعهٔ لایه‌ای همان شیء شکل در اسلاید عادی نیست. وقتی نیاز به فهم یا تغییر قالب‌بندی ارائه‌شده توسط یک لایه دارید، اشکال لایه را بررسی کنید.

مثال زیر برای هر شکل لایه، [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getfillformat/) و [LineFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getlineformat/) را می‌خواند بدون این‌که فرض کند هر شکل یک `AutoShape` است.

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

ویرایش یک لایه می‌تواند چندین اسلایدی که از آن استفاده می‌کنند را تحت تأثیر قرار دهد. پیش از تغییر یک شکل لایه، تعیین کنید آیا یک اسلاید عادی آن شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلایدی که از آن لایه استفاده می‌کند را آزمایش کنید.

## **صادر کردن یک شکل به SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/writeassvg/) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل خود شکل است، نه پس‌زمینهٔ کل اسلاید یا شکل‌های همسایه.

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

در حین رندر، ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل منفرد صادر کنید. فراخوانی کننده مالک جریان است و باید آن را بسته شود.

## **هم‌ترازی اشکال**

متدهای [SlideUtil::alignShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/alignshapes/) می‌توانند همهٔ اشکال یا شاخص‌های انتخاب‌شدهٔ مجموعه را هم‌تراز کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapesalignmenttype/) لبه، خط مرکزی یا حالت توزیع را مشخص می‌کند. `alignToSlide` را روی `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ روی `false` تنظیم کنید تا اشکال انتخاب‌شده نسبت به یکدیگر هم‌تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید هم‌تراز می‌کند. ارجاع‌های شکل بازگردانده‌شده بلافاصله قبل از هم‌ترازی به شاخص‌های فعلی خود تبدیل می‌شوند.

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

هم‌ترازی موقعیت‌ها را تغییر می‌دهد، نه Z‑order. هم‌ترازی نسبی معمولاً حداقل به دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی برای تعریف فواصل به اشکال کافی نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، شاخص‌ها را دوباره محاسبه کنید.

## **چرخاندن (Flip) یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از نوع [NullableBool](https://reference.aspose.com/slides/fa/php-java/aspose.slides/nullablebool/) استفاده می‌کنند: `True` چرخش را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت نامشخص/پیش‌فرض را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون چرخش است.

![The shape before flipping](shape_to_be_flipped.png)

مثال مقادیر دیگر فریم را حفظ می‌کند و فقط دو تنظیم چرخش را جایگزین می‌کند. این مهم است چون اختصاص یک [Frame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/setframe/) جدید، فریم کامل را جایگزین می‌کند.

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

شکل ذخیره‌شده به‌صورت افقی و عمودی آینه‌برداری می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**آیا باید از شاخص مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش کوتاه‌مدت که پیش از استفاده مجموعه تغییری نمی‌کند. برای قالب‌های نویسنده‌شده ترجیحاً از یک قرارداد معتبر `Name` یا `AlternativeText` استفاده کنید یا برای کارهای interop در محدوده اسلاید از `OfficeInteropShapeId` بهره ببرید.

**آیا مخفی‌کردن یک شکل آن را از Z‑order حذف می‌کند؟**

خیر. یک شکل مخفی در همان شاخص در مجموعه باقی می‌ماند. می‌توان آن را یافت، دوباره‌چین، ویرایش یا دوباره قابل مشاهده کرد.

**چرا یک شکل کپی‌شده در مقابل شکل دیگری ظاهر شد؟**

`addClone` کپی را به انتهای مجموعه (جلو Z‑order) اضافه می‌کند. برای انتخاب شاخص اولیه از `insertClone` استفاده کنید یا پس از افزودن تمام اشکال از `reorder` بهره بگیرید.

**آیا می‌توانم از یک شاخص ثابت برای شناسایی تنظیم پیش‌تنظیم شکل استفاده کنم؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و ساختار مجموعه. بهتر است از طریق `GeometryShape::getAdjustments` عبور کنید و `AdjustValue::getType` را بررسی کنید؛ وقتی همان نوع معنایی بیش از یک‌بار ظاهر می‌شود، از `AdjustValue::getName` به‌عنوان اطلاعات تکمیلی استفاده کنید.