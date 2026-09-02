---
title: قالب‌بندی اشکال پاورپوینت در PHP
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/php-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکیچ
- خط اسکیچ شکل
- قالب‌بندی سبک اتصال
- پرشدن گرادیان
- پرشدن الگو
- پرشدن تصویر
- پرشدن بافت
- پرشدن رنگ ثابت
- شفافیت شکل
- چرخش شکل
- افکت برجستگی 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال پاورپوینت را در PHP با استفاده از Aspose.Slides قالب‌بندی کنید—پرشدن، خطوط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در پاورپوینت می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آنها را با تغییر یا اعمال افکت‌ها به خطوط مرزی‌شان قالب‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تعیین تنظیماتی که کنترل می‌کند داخلی آنها چگونه پر شود، قالب‌بندی کنید.

![قالب‌بندی شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای PHP از طریق Java کلاس‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در پاورپوینت قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر روند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. سبک [line style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. سبک [dash style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // تنظیم رنگ پرشده برای شکل مستطیل.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // اعمال قالب‌بندی بر خطوط مستطیل.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // تنظیم رنگ برای خط مستطیل.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های اسکیچ به خطوط شکل**

یک افکت اسکیچ باعث می‌شود خط شکل شبیه به دست‌کشیده به نظر برسد. برای دسترسی به تنظیمات خط از [Shape.getLineFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) استفاده کنید، برای دسترسی به تنظیمات اسکیچ از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/lineformat/) و برای انتخاب یک مقدار از شمارش [LineSketchType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linesketchtype/) از [SketchFormat.setSketchType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sketchformat/) استفاده کنید.

کد PHP زیر نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linesketchtype/) اعمال شود، مقدار اختصاص داده شده صریحاً خوانده شود و با [LineSketchType.None](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linesketchtype/) افکت حذف گردد:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // دسترسی به فرمت خط شکل و فرمت اسکچ آن.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // اعمال یک افکت اسکچ.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // خواندن افکت اسکچ اختصاص داده شده مستقیم به شکل.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // حذف افکت اسکچ.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sketchformat/) برگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برده شود، از [LineFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/lineformat/) استفاده کنید، متد `getSketchFormat` شیء برگردانده‌شده را فراخوانی کنید و مقدار `getSketchType` آن را بخوانید. مقدار مؤثر، قالب‌بندی‌ای را نشان می‌دهد که پس از حل ارث‌بری واقعاً اعمال می‌شود:

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
* بیول

به‌طور پیش‌فرض، وقتی پاورپوینت دو خط را در زاویه‌ای (مانند گوشهٔ یک شکل) به هم وصل می‌کند، از تنظیم **گرد** استفاده می‌کند. اما اگر شکل را با زوایای تیز رسم می‌کنید، ممکن است گزینه **میتر** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد PHP زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا دیده می‌شود) با استفاده از تنظیمات نوع اتصال میتر، بیول و گرد ساخته شدند:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن سه AutoShape از نوع Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // تنظیم رنگ پرشده برای هر شکل مستطیل.
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

    // تنظیم رنگ برای خط هر مستطیل.
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

    // افزودن متن به هر مستطیل.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پرشدن گرادیان**

در پاورپوینت، پرشدن گرادیان یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد ترکیبی پیوسته از رنگ‌ها را بر یک شکل اعمال کنید. به عنوان مثال می‌توانید دو یا چند رنگ را به گونه‌ای اعمال کنید که یکی به تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پرشدن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد نظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` از مجموعه توقف‌های گرادیان که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/gradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن یک AutoShape از نوع Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // اعمال قالب‌بندی گرادیان به بیضی.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // تنظیم جهت گرادیان.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // افزودن دو توقفگرادیان.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![بیضی با پرشدن گرادیان](gradient-fill.png)

## **پرشدن الگو**

در پاورپوینت، پرشدن الگو یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک طرح دو رنگه—مانند نقطه‌ها، خط‌ها، خط‌متقاطع یا خانه‌ها—را بر یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینه الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده ارائه می‌دهد که می‌توانید آنها را بر روی اشکال اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را نیز مشخص کنید.

در اینجا نحوهٔ اعمال پرشدن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده را انتخاب کنید.
1. رنگ [Background Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/patternformat/#getBackColor) الگو را تعیین کنید.
1. رنگ [Foreground Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/patternformat/#getForeColor) الگو را تنظیم کنید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پرشدن به Pattern.
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

![مستطیل با پرشدن الگو](pattern-fill.png)

## **پرشدن تصویر**

در پاورپوینت، پرشدن تصویر یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل وارد کنید—به‌طور مؤثری تصویر را به عنوان پس‌زمینهٔ شکل استفاده می‌کنید.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پرشدن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پرشدن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `SlidesPicture.setImage` پاس دهید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" داریم با تصویر زیر:

![تصویر لوتوس](lotus.png)

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // تنظیم نوع پرشدن به Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // تنظیم حالت پرشدن تصویر.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // بارگذاری یک تصویر و افزودن آن به منابع ارائه.
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

![شکل با پرشدن تصویر](picture-fill.png)

### **استفاده از تصویر کاشی به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از روش‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پرشدن تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileAlignment): تراز کاشی‌ها داخل شکل را تعیین می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileFlip): کنترل می‌کند که آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileOffsetX): مقدار افقی افست کاشی (به نقاط) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileOffsetY): مقدار عمودی افست کاشی (به نقاط) از مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی به‌صورت درصد تعریف می‌کند.

کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پرشدن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // تنظیم نوع پرشدن شکل به Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // بارگذاری تصویر و افزودن آن به منابع ارائه.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // اختصاص تصویر به شکل.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // پیکربندی حالت پرشدن تصویر و ویژگی‌های کاشی‌بندی.
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

![گزینه‌های کاشی](tile-options.png)

## **پرشدن رنگ ثابت**

در پاورپوینت، پرشدن رنگ ثابت یک گزینهٔ قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینهٔ ساده بدون هیچ‌گونه گرادیان، بافت یا الگوئی اعمال می‌شود.

برای اعمال پرشدن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پرشدن دلخواه خود را به شکل اختصاص دهید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پرشدن به Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // تنظیم رنگ پرشده.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![شکل با پرشدن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در پاورپوینت، وقتی یک رنگ ثابت، گرادیان، تصویر یا بافت را بر روی اشکال اعمال می‌کنید، می‌توانید همچنین سطح شفافیتی را تنظیم کنید تا میزان شفافیت پرشدن را کنترل کنید. یک مقدار شفافیت بالاتر، شکل را شفاف‌تر می‌کند و زمینه یا اشیای زیرین را جزئی قابل مشاهده می‌سازد.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پرشدن تنظیم کنید. در اینجا نحوه انجام آن آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت استفاده کنید (مؤلفه `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن یک AutoShape مستطیل صلب.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // افزودن یک AutoShape مستطیل شفاف بر روی شکل صلب.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های پاورپوینت بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص ترازبندی یا طراحی مفید باشد.

برای چرخاندن یک شکل بر روی اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ مورد نظر تنظیم کنید.
1. ارائه را ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به مقدار 5 درجه.
    $shape->setRotation(5);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![چرخش شکل](shape-rotation.png)

## **اضافه کردن افکت‌های برجستگی 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجستگی 3D را بر روی اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) اعمال کنید.

برای اضافه کردن افکت‌های برجستگی 3D به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) شکل را پیکربندی کنید تا تنظیمات برجستگی تعریف شود.
1. ارائه را ذخیره کنید.

```php
// ایجاد یک نمونه از کلاس Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // افزودن یک شکل به اسلاید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // تنظیم ویژگی‌های ThreeDFormat شکل.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // ذخیرهٔ ارائه به عنوان فایل PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![افکت برجستگی 3D](3D-bevel-effect.png)

## **اضافه کردن افکت‌های چرخش 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3D را بر روی اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) اعمال کنید.

برای اعمال چرخش 3D به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. از [setCameraType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/lightrig/#setLightType) برای تعریف چرخش 3D استفاده کنید.
1. ارائه را ذخیره کنید.

```php
// ایجاد یک نمونه از کلاس Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // ذخیرهٔ ارائه به عنوان فایل PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![افکت چرخش 3D](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد Java زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکالی که دارای جای‌گیرها در [LayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) هستند به تنظیمات پیش‌فرض برگردانید:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // بازنشانی هر شکل در اسلایدی که جای‌گیر در طرح‌بندی دارد.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت جزئی. تصاویر و رسانه‌های توکار بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌صورت متاداده ذخیره می‌شوند و تقریباً حجم اضافی ایجاد نمی‌کنند.

**چگونه می‌توانم اشکالی را که در یک اسلاید قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—تنظیمات پرشدن، خط و افکت—را مقایسه کنید. اگر همه مقادیر متناظر برابر باشند، سبک‌های آن‌ها را یکسان در نظر بگیرید و منطقی آن‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده‌تر می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد شود؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را در محل‌های مورد نیاز دوباره اعمال کنید.