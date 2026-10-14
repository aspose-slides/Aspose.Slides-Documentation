---
title: قالب‌بندی اشکال PowerPoint در PHP
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/php-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ صلب
- شفافیت شکل
- رندرینگ شکل سیاه‑سفید
- رندرینگ شکل خاکستری
- چرخاندن شکل
- اثر برجسته‌سازی 3بعدی
- اثر چرخش 3بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "بیاموزید چگونه اشکال PowerPoint را در PHP با استفاده از Aspose.Slides—پر کردن، خط و سبک‌های اثر را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آن‌ها را با تغییر یا اعمال اثرات روی خطوط مرزی‌ خود قالب‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، قالب‌بندی کنید.

![قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای PHP از طریق Java کلاس‌ها و متدهایی ارائه می‌دهد که به شما امکان قالب‌بندی اشکال را با استفاده از همان گزینه‌های موجود در PowerPoint می‌دهد.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر روش کار را شرح می‌دهند:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. سبک [خط](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. سبک [خط‌چین](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط را برای شکل تنظیم کنید.
1. ارائه‌ی تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

کد PHP زیر نشان می‌دهد چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // تنظیم رنگ پر برای شکل مستطیل.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // اعمال قالب‌بندی بر خطوط مستطیل.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // تنظیم رنگ برای خط مستطیل.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![خط‌های قالب‌بندی شده در ارائه](formatted-lines.png)

## **اعمال اثرات اسکچ به خطوط شکل**

یک اثر اسکچ ظاهر خط شکل را شبیه‌سازی به صورت دست‌نویس می‌کند. برای دسترسی به تنظیمات خط از [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) استفاده کنید، برای دسترسی به تنظیمات اسکچ از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) استفاده کنید، و برای انتخاب مقدار از enumeration [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) از [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) استفاده کنید.

کد PHP زیر نشان می‌دهد چگونه یک اثر [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) را اعمال کنید، مقدار به‌طور صریح اختصاص داده‌شده را بخوانید، و اثر را با [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) حذف کنید:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // دسترسی به فرمت خط شکل و فرمت اسکچ آن.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // اعمال یک اثر اسکچ.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // خواندن اثر اسکچ که به‌صورت مستقیم به شکل اختصاص داده شده است.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // حذف اثر اسکچ.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) برگردانده می‌شود، تنظیمی است که به طور مستقیم به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید طرح به ارث برده شود، از [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) استفاده کنید، متد `getSketchFormat` شی بازگردانده‌شده را فراخوانی کنید و مقدار `getSketchType` آن را بخوانید. مقدار مؤثر، قالب‌بندی‌ای را نشان می‌دهد که پس از حل ارث‌بری واقعاً اعمال می‌شود:

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

## **قالب‌بندی انواع اتصال**

در اینجا سه گزینه نوع اتصال وجود دارد:

* گرد
* قاطع
* شیاردار

به طور پیش‌فرض، وقتی PowerPoint دو خط را در یک زاویه (مانند گوشه‌ی یک شکل) می‌پیوندد، از تنظیم **گرد** استفاده می‌کند. اما اگر شکلی با زوایای تیز ترسیم می‌کنید، ممکن است گزینه **قاطع** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد PHP زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع اتصال قاطع، شیاردار و گرد ایجاد شدند:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن سه AutoShape از نوع Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // تنظیم رنگ پر برای هر شکل مستطیل.
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

    // اضافه کردن متن به هر مستطیل.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پر کردن گرادیان**

در PowerPoint، پر کردن گرادیان یک گزینه قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. برای مثال می‌توانید دو یا چند رنگ را به‌طوری اعمال کنید که یکی به تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد نظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` از مجموعه‌گرادیان‌استاپ‌های ارائه‌شده توسط کلاس [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) اضافه کنید.
1. ارائه‌ی تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

کد PHP زیر نشان می‌دهد چگونه یک اثر پر کردن گرادیان به یک بیضی اعمال شود:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // اضافه کردن دو نقطه توقف گرادیان.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از آنچه در PowerPoint می‌بینید، به بخش [Choose a Gradient Rendering Style](/slides/fa/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید سبک رندرینگ را انتخاب کنید بدون اینکه پر کردن گرادیان ذخیره‌سازی‌شده در ارائه تغییر کند.

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینه قالب‌بندی است که به شما اجازه می‌دهد یک طرح دو رنگی—مانند نقطه‌ها، خط‌ها، خطوط متقاطع یا شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های پیش‌زمینه و پس‌زمینه الگو را به‌دلخواه تنظیم کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی از پیش تعریف‌شده فراهم می‌کند که می‌توانید برای ارتقاء ظاهر ارائه‌ها به اشکال اعمال کنید. حتی پس از انتخاب یک الگوی از پیش تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های از پیش تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) الگو را تنظیم کنید.
1. ارائه‌ی تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

کد PHP زیر نشان می‌دهد چگونه یک پر کردن الگو بر روی یک مستطیل اعمال شود:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینه قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل قرار دهید—به‌طور مؤثر تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده می‌کند.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آمده است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شی [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) از تصویر موردنظر خود ایجاد کنید.
1. تصویر را به متد `SlidesPicture.setImage` پاس دهید.
1. ارائه‌ی تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" با تصویر زیر داریم:

![تصویر لوتوس](lotus.png)

کد PHP زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // بارگذاری یک تصویر و افزودن آن به منابع ارائه.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // تنظیم تصویر.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): ترازبندی کاشی‌ها داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): کنترل می‌کند که آیا کاشی به صورت افقی، عمودی یا هر دو وارونه شود.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی کاشی (به‌واحد نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی کاشی (به‌واحد نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی را به صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی را به صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی‌گذاری.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ صلب**

در PowerPoint، پر کردن رنگ صلب یک گزینه قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این پس‌زمینهٔ ساده بدون هیچ گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر کردن رنگ صلب به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.
1. ارائه‌ی تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

کد PHP زیر نشان می‌دهد چگونه پر کردن رنگ صلب بر روی یک مستطیل در یک اسلاید PowerPoint اعمال شود:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل با پر کردن رنگ صلب](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، هنگام اعمال پر کردن رنگ صلب، گرادیان، تصویر یا بافت به اشکال، می‌توانید سطح شفافیت را تنظیم کنید تا میزان شفافیت پر شدن کنترل شود. مقدار شفافیت بالاتر باعث می‌شود شکل بیشتر شفاف شود و زمینه یا اشیای زیرین به‌صورت جزئی قابل رؤیت باشند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در اینجا نحوهٔ انجام آن آمده است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف یک رنگ با شفافیت استفاده کنید (مؤلفه `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

کد PHP زیر نشان می‌دهد چگونه یک رنگ پر کردن شفاف بر روی یک مستطیل اعمال شود:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل در یک اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. خاصیت چرخش شکل را به زاویهٔ مطلوب تنظیم کنید.
1. ارائه را ذخیره کنید.

کد PHP زیر نشان می‌دهد چگونه یک شکل را به اندازهٔ 5 درجه بچرخانید:

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    $slide = $presentation->getSlides()->get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به میزان 5 درجه.
    $shape->setRotation(5);

    // ذخیرهٔ فایل PPTX روی دیسک.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن اثرات برجسته‌سازی سه‌بعدی**

Aspose.Slides به شما اجازه می‌دهد اثرات برجسته‌سازی سه‌بعدی را به اشکال اعمال کنید با پیکربندی خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

برای افزودن اثرات برجسته‌سازی سه‌بعدی به یک شکل، مراحل زیر را دنبال کنید:

1. نمونه‌ای از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجسته‌سازی پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد PHP زیر نشان می‌دهد چگونه اثرات برجسته‌سازی سه‌بعدی به یک شکل اعمال شود:

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

![اثر برجسته‌سازی سه‌بعدی](3D-bevel-effect.png)

## **افزودن اثرات چرخش سه‌بعدی**

Aspose.Slides به شما اجازه می‌دهد اثرات چرخش سه‌بعدی را به اشکال اعمال کنید با پیکربندی خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

برای اعمال چرخش سه‌بعدی به یک شکل:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. از [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) برای تعریف چرخش سه‌بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

کد PHP زیر نشان می‌دهد چگونه اثرات چرخش سه‌بعدی به یک شکل اعمال شود:

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

![اثر چرخش سه‌بعدی](3D-rotation-effect.png)

## **کنترل رندرینگ سیاه‑سفید برای اشکال**

متد [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) مشخص می‌کند که یک شکل به‌صورت فردی چگونه در حالت سیاه‑سفید رندر شود وقتی ارائه مشاهده یا پردازش می‌شود. این متد به‌تنهایی نمایش سیاه‑سفید را فعال نمی‌کند و قالب‌بندی پر، خط یا سایر خصوصیات شکل را در حالت رنگ نارمال تغییر نمی‌دهد.

برای انتخاب رفتار دلخواه، از یک مقدار کلاس [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید استفاده می‌کند، `Black` و `White` یک رنگ ثابت اعمال می‌کنند، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معناست که هیچ حالت سطح‌شکل‌گذاری‌ شده‌ای اختصاص داده نشده است.

کد PHP زیر یک شکل رنگی ایجاد کرده و باعث می‌شود در حالت نمایش سیاه‑سفید خاکستری نمایش داده شود:

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

    // در حالت رنگ، پر کردن نارنجی را حفظ کنید، اما شکل را در حالت سیاه‑سفید با رنگ خاکستری رندر کنید.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

در حالت رنگی عادی، مستطیل پرشده با نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `Gray`، از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد اسلاید رنگی کامل را حفظ کنید و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد Java زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با نگهدارنده‌ها را در [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) به تنظیمات پیش‌فرض بازگردانید:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // بازنشانی هر شکل در اسلاید که دارای یک نگهدارنده در قالب‌بندی است.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت جزئی. تصاویر و رسانه‌های جاسازی‌شده بخش عمدهٔ فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، اثرات و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و به‌صورت چشم‌گیری حجم اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوان آن‌ها را گروه‌بندی کرد؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پر کردن، خط و تنظیمات اثر—را مقایسه کنید. اگر همهٔ مقدارهای مربوطه مطابقت داشتند، سبک‌های آن‌ها را یکسان در نظر بگیرید و به‌منظور مدیریت ساده‌تر، آن‌ها را منطقی گروه‌بندی کنید.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، اشکال سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که لازم است دوباره اعمال کنید.