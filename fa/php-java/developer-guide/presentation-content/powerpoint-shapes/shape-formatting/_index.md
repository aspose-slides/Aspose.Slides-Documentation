---
title: قالب‌بندی اشکال PowerPoint در PHP
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/php-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکیچ
- خط شکل اسکیچ
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندر سیاه‌سفید شکل
- رندر خاکستری شکل
- چرخش شکل
- افکت لبه‌زدن 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌های PowerPoint را در PHP با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

در پاورپوینت، می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید با تغییر یا اعمال افکت‌ها به حاشیه‌های آن‌ها، قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که کنترل می‌کنند داخل اشکال چگونه پر شود، آن‌ها را قالب‌بندی کنید.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides برای PHP از طریق Java کلاس‌ها و متدهایی را ارائه می‌دهد که به شما امکان می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در پاورپوینت قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides، می‌توانید یک سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر شامل روش کار هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. قالب [line style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. قالب [dash style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد PHP زیر نحوه قالب‌بندی یک `AutoShape` مستطیل را نشان می‌دهد:

```php
// نمونه‌سازی کلاس Presentation که نشان‌دهنده‌ی یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // تنظیم رنگ پر کردن برای شکل Rectangle.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // اعمال قالب‌بندی بر خطوط Rectangle.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // تنظیم رنگ خط Rectangle.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // ذخیرهٔ فایل PPTX در دیسک.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The formatted lines in the presentation](formatted-lines.png)

## **اعمال افکت‌های اسکیچ به خطوط شکل**

یک افکت اسکیچ باعث می‌شود خط یک شکل شبیه به دست‌نویس شود. برای دسترسی به تنظیمات خط از [Shape.getLineFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) استفاده کنید، برای دسترسی به تنظیمات اسکیچ از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/lineformat/) و برای انتخاب مقدار از شمارندهٔ [LineSketchType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linesketchtype/) با استفاده از [SketchFormat.setSketchType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sketchformat/) استفاده کنید.

کد PHP زیر نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linesketchtype/) اعمال کنید، مقدار اختصاص داده شده صریحاً را بخوانید و با [LineSketchType.None](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linesketchtype/) افکت را حذف کنید:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // دسترسی به قالب خط شکل و قالب اسکیچ آن.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // اعمال افکت اسکیچ.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // خواندن افکت اسکیچ اختصاص داده شده مستقیم به شکل.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // حذف افکت اسکیچ.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sketchformat/) برگشت داده می‌شود، نمایانگر تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برده شود، از [LineFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/lineformat/) استفاده کنید، متد `getSketchFormat` شی برگردانده‌شده را فراخوانی کنید و مقدار `getSketchType` آن را بخوانید. مقدار مؤثر، قالب‌بندی واقعی اعمال‌شده پس از حل ارث‌بری را نشان می‌دهد:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینهٔ نوع اتصال وجود دارد:

* گرد
* میتر
* بویل

به‌صورت پیش‌فرض، وقتی پاورپوینت دو خط را به‌صورت زاویه‌ای (مانند گوشهٔ یک شکل) به هم وصل می‌کند، از تنظیم **گرد** استفاده می‌کند. اما اگر شکل با زوایای تیز رسم می‌کنید، ممکن است گزینهٔ **میتر** را ترجیح دهید.

![The join style in the presentation](join-style-powerpoint.png)

کد PHP زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع اتصال میتر، بویل و گرد ایجاد شدند:

```php
// ایجاد نمونه‌ای از کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن سه AutoShape از نوع Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // تنظیم رنگ پر کردن برای هر شکل Rectangle.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // تنظیم عرض خط.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // تنظیم رنگ خط برای هر Rectangle.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // تنظیم سبک اتصال.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // اضافه کردن متن به هر Rectangle.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // ذخیره فایل PPTX بر روی دیسک.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پر کردن تدریجی (Gradient Fill)**

در پاورپوینت، پر کردن تدریجی (Gradient Fill) یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. برای مثال، می‌توانید دو یا چند رنگ را به‌صورت تدریجی که یکی به آرامی به دیگری منتقل شود، اعمال کنید.

در اینجا نحوهٔ اعمال پر کردن تدریجی بر یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. خاصیت [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ موردنظرتان را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ توقف تدریجی که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/gradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // اعمال قالب‌بندی گرادیان به بیضی.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // تنظیم جهت گرادیان.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // اضافه کردن دو نقطهٔ توقف گرادیان.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The ellipse with gradient fill](gradient-fill.png)

## **پر کردن الگو (Pattern Fill)**

در پاورپوینت، پر کردن الگو (Pattern Fill) یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد طرحی دو رنگی—مانند نقطه‌ها، خطوط، خطوط متقاطع یا شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک پیش‌تعریف‌شدهٔ الگو را ارائه می‌دهد که می‌توانید بر روی اشکال اعمال کنید تا جذابیت بصری ارائه‌هایتان افزایش یابد. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق استفاده‌شده را نیز تعیین کنید.

در اینجا نحوهٔ اعمال پر کردن الگو بر یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. خاصیت [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. رنگ [Background Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/patternformat/#getBackColor) الگو را تنظیم کنید.
1. رنگ [Foreground Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/patternformat/#getForeColor) الگو را تنظیم کنید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // تنظیم سبک الگو.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // تنظیم رنگ پس‌زمینه و پیش‌زمینه الگو.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The rectangle with pattern fill](pattern-fill.png)

## **پر کردن تصویر (Picture Fill)**

در پاورپوینت، پر کردن تصویر (Picture Fill) یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل قرار دهید—به‌طوری که تصویر به‌عنوان پس‌زمینهٔ شکل عمل کند.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر بر یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. خاصیت [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگری) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) از تصویری که می‌خواهید استفاده کنید، بسازید.
1. تصویر را به متد `SlidesPicture.setImage` پاس بدهید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" داریم که تصویر زیر را دارد:

![The lotus picture](lotus.png)

کد PHP زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```php
// نمونه‌سازی کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // تنظیم نوع پر کردن به Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // تنظیم حالت پر کردن تصویر.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // بارگذاری تصویر و افزودن آن به منابع ارائه.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // تنظیم تصویر.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The shape with picture fill](picture-fill.png)

### **تصویر کاشی به‌عنوان بافت**

اگر می‌خواهید تصویر کاشی را به‌عنوان بافت تنظیم کنید و رفتار کاشی را سفارشی کنید، می‌توانید از روش‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileAlignment): ترازبندی کاشی‌ها درون شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileFlip): کنترل می‌کند که آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی کاشی (به نقطه) را نسبت به مبدای شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی کاشی (به نقطه) را نسبت به مبدای شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونهٔ کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کرده و گزینه‌های کاشی را پیکربندی کنید:

```php
// ایجاد نمونه‌ای از کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // تنظیم نوع پر کردن شکل به Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // بارگذاری تصویر و افزودن آن به منابع ارائه.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // اختصاص تصویر به شکل.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The tile options](tile-options.png)

## **پر کردن رنگ ثابت (Solid Color Fill)**

در پاورپوینت، پر کردن رنگ ثابت (Solid Color Fill) یک گزینهٔ قالب‌بندی است که شکل را با یک رنگ یکنواخت تک‌رنگ پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر کردن رنگ ثابت بر یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. خاصیت [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن موردنظر خود را به شکل اختصاص دهید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```php
// ایجاد نمونه‌ای از کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // تنظیم رنگ پر کردن.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The shape with solid color fill](solid-color-fill.png)

## **تنظیم شفافیت**

در پاورپوینت، وقتی پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را به اشکال اعمال می‌کنید، می‌توانید سطح شفافیتی را تنظیم کنید تا قابلیت ترازی پر کردن را کنترل کنید. مقدار شفافیت بالاتر، شکل را شفاف‌تر می‌کند و اجازه می‌دهد پس‌زمینه یا اشیای زیرین به‌صورت جزئی دیده شوند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در اینجا نحوهٔ انجام آن آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. خاصیت [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف یک رنگ با شفافیت (جزء `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

```php
// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape مستطیل صلب.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // اضافه کردن یک AutoShape مستطیل شفاف بر روی شکل صلب.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The transparent shape](shape-transparency.png)

## **چرخش اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های پاورپوینت بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل بر روی اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. خاصیت چرخش شکل را به زاویهٔ موردنظر تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

```php
// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به‌ میزان 5 درجه.
    $shape->setRotation(5);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The shape rotation](shape-rotation.png)

## **اضافه‌کردن افکت‌های لبه‌زدن 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های لبه‌زدن 3D را بر اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) آنها اعمال کنید.

برای افزودن افکت‌های لبه‌زدن 3D به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات لبه‌زدن پیکربندی کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

```php
// یک نمونه از کلاس Presentation ایجاد کنید.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل به اسلاید اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // ویژگی‌های ThreeDFormat شکل را تنظیم کنید.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The 3D bevel effect](3D-bevel-effect.png)

## **اضافه‌کردن افکت‌های چرخش 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3D را بر اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) آنها اعمال کنید.

برای اعمال چرخش 3D به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. از متدهای [setCameraType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/lightrig/#setLightType) برای تعریف چرخش 3D استفاده کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

```php
// یک نمونه از کلاس Presentation ایجاد کنید.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The 3D rotation effect](3D-rotation-effect.png)

## **کنترل رندر سیاه‌سفید برای اشکال**

متد [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#setBlackWhiteMode) تعیین می‌کند که یک شکل منفرد هنگام مشاهده یا پردازش ارائه در حالت سیاه‌سفید چگونه رندر شود. این متد به‌تنهایی نمایش سیاه‌سفید را فعال نمی‌کند و همچنین پر کردن، خط یا سایر قالب‌بندی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از مقدار موجود در کلاس [BlackWhiteMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. به عنوان مثال، `Automatic` به برنامه رندر اجازه می‌دهد تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به‌کار می‌برد، `Black` و `White` یک رنگ واحد را اعمال می‌کنند، `Color` رنگ عادی را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‌سفید نادیده می‌گیرد. `NotDefined` به این معنی است که هیچ حالت سطح‌شکلی تعیین نشده است.

کد PHP زیر یک شکل رنگی ایجاد می‌کند و آن را در حالت نمایش سیاه‌سفید به‌صورت خاکستری نشان می‌دهد:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // پر رنگ نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه‌سفید با رنگ خاکستری رندر کنید.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

در حالت رنگ عادی، مستطیل پر رنگ نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‌سفید، به‌دلیل تنظیم حالت به `Gray`، از رنگ خاکستری استفاده می‌کند. این امکان را به شما می‌دهد تا یک اسلاید تمام‌رنگ حفظ کنید در حالی که ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‌سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد Java زیر نحوهٔ بازنشانی قالب‌بندی یک اسلاید و بازگرداندن موقعیت، اندازه و قالب‌بندی تمام اشکالی که دارای نگهدارنده‌ها بر روی [LayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) هستند به تنظیمات پیش‌فرض را نشان می‌دهد:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // بازنشانی هر شکلی در اسلاید که دارای نگهدارنده‌ای در چینش است.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

تقریباً نه. تصاویر و رسانه‌های جاسازی‌شده بیشتر فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌صورت متادیتا ذخیره می‌شوند و به‌صورت تقریباً هیچ اندازهٔ اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را که در یک اسلاید قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—مانند تنظیمات پر، خط و افکت‌ها—را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، می‌توانید سبک‌های آن‌ها را یکسان در نظر بگیرید و به‌طور منطقی آن اشکال را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد شود؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید الگو یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، اشکال استایل‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که لازم است اعمال کنید.