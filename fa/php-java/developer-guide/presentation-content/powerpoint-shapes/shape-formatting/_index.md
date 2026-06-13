---
title: قالب‌بندی اشکال PowerPoint در PHP
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/php-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- چرخاندن شکل
- افکت برجستگی 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در PHP با استفاده از Aspose.Slides قالب‌بندی کنید—پرکن، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید شکل‌ها را به اسلایدها اضافه کنید. از آنجا که شکل‌ها از خطوط تشکیل شده‌اند، می‌توانید با تغییر یا اعمال افکت‌ها بر روی خطوط مرزی آن‌ها، آن‌ها را قالب‌بندی کنید. علاوه بر این، می‌توانید با مشخص کردن تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، شکل‌ها را قالب‌بندی کنید.

![قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای PHP از طریق Java کلاس‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش را توضیح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. سبک [line style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. سبک [dash style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

کد PHP زیر نشان می‌دهد که چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```php
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
$presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // رنگ پرکن را برای شکل مستطیل تنظیم کنید.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // قالب‌بندی را بر خطوط مستطیل اعمال کنید.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // رنگ خط مستطیل را تنظیم کنید.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // فایل PPTX را روی دیسک ذخیره کنید.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **قالب‌بندی سبک‌های اتصال**

این‌ها سه گزینه نوع اتصال هستند:

* گرد
* میتر
* برش

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در زاویه‌ای (مانند گوشهٔ یک شکل) به هم متصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شما شکلی با زوایای تیز می‌کشید، ممکن است گزینه **Miter** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد PHP زیر نشان می‌دهد که چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع اتصال Miter، Bevel و Round ایجاد شدند:

```php
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
$presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // سه شکل خودکار از نوع Rectangle اضافه کنید.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // رنگ پرکن را برای هر شکل مستطیل تنظیم کنید.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // عرض خط را تنظیم کنید.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // رنگ خط هر مستطیل را تنظیم کنید.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // سبک اتصال را تنظیم کنید.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // متن را به هر مستطیل اضافه کنید.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // فایل PPTX را روی دیسک ذخیره کنید.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پر کردن گرادیان**

در PowerPoint، پر کردن گرادیان یک گزینه قالب‌بندی است که به شما امکان می‌دهد ترکیبی مداوم از رنگ‌ها را بر روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‑طوری اعمال کنید که یکی به‑تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. FillType شکل را روی `Gradient` تنظیم کنید.
1. دو رنگ مورد علاقهٔ خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ توقف‌گرادیان که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/gradientformat/) فراهم شده، اضافه کنید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```php
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
$presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل خودکار از نوع Ellipse اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // قالب‌بندی گرادیان را بر روی بیضی اعمال کنید.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // جهت گرادیان را تنظیم کنید.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // دو نقطه توقف گرادیان اضافه کنید.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // فایل PPTX را روی دیسک ذخیره کنید.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینه قالب‌بندی است که به شما امکان می‌دهد طرحی دو‌رنگ—مانند نقطه‌ها، خطوط راه راه، شبکه‌ها یا شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی از پیش تعریف‌شده را فراهم می‌کند که می‌توانید آنها را بر روی شکل‌ها اعمال کنید تا جذابیت بصری ارائه‌های خود را ارتقا دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده آن را مشخص کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. FillType شکل را روی `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های از پیش تعریف‌شده انتخاب کنید.
1. رنگ پس‌زمینهٔ الگو را تنظیم کنید.
1. رنگ پیش‌زمینهٔ الگو را تنظیم کنید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```php
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
$presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // نوع پرکن را به Pattern تنظیم کنید.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // استایل الگو را تنظیم کنید.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // رنگ‌های پس‌زمینه و پیش‌زمینهٔ الگو را تنظیم کنید.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // فایل PPTX را روی دیسک ذخیره کنید.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل وارد کنید—در واقع از تصویر به‌عنوان پس‌زمینهٔ شکل استفاده می‌کنید.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. FillType شکل را روی `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را روی `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) از تصویر مورد نظر خود ایجاد کنید.
1. تصویر را به متد `SlidesPicture.setImage` پاس کنید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

بیایید بگوییم فایلی به نام "lotus.png" با تصویر زیر داریم:

![تصویر لوتوس](lotus.png)

کد PHP زیر نشان می‌دهد که چگونه یک شکل را با تصویر پر کنید:

```php
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
$presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // نوع پرکن را به Picture تنظیم کنید.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // حالت پر کردن تصویر را تنظیم کنید.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // یک تصویر بارگذاری کنید و به منابع ارائه اضافه کنید.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // تصویر را تنظیم کنید.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // فایل PPTX را روی دیسک ذخیره کنید.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **استفاده از تصویر تایل به‌عنوان بافت**

اگر می‌خواهید تصویر تایل‌شده را به‌عنوان بافت تنظیم کنید و رفتار تایلینگ را سفارشی کنید، می‌توانید از متدهای زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پر کردن تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileAlignment): ترازبندی تایل‌ها درون شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileFlip): تعیین می‌کند که تایل به‑صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی تایل (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی تایل (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی تایل را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی تایل را به‌صورت درصد تعریف می‌کند.

کد نمونه زیر نشان می‌دهد که چگونه یک شکل مستطیلی با پر کردن تصویر تایل‌شده اضافه کنید و گزینه‌های تایل را پیکربندی کنید:

```php
    // یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
    $presentation = new Presentation();
    try {
        // اسلاید اول را دریافت کنید.
        $firstSlide = $presentation->getSlides()->get_Item(0);

        // یک شکل خودکار مستطیل اضافه کنید.
        $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

        // نوع پرکن شکل را به Picture تنظیم کنید.
        $shape->getFillFormat()->setFillType(FillType::Picture);

        // تصویر را بارگذاری کنید و به منابع ارائه اضافه کنید.
        $sourceImage = Images::fromFile("lotus.png");
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
        $sourceImage->dispose();

        // تصویر را به شکل اختصاص دهید.
        $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
        $pictureFillFormat->getPicture()->setImage($presentationImage);

        // حالت پر کردن تصویر و ویژگی‌های تایل را پیکربندی کنید.
        $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
        $pictureFillFormat->setTileOffsetX(-32);
        $pictureFillFormat->setTileOffsetY(-32);
        $pictureFillFormat->setTileScaleX(50);
        $pictureFillFormat->setTileScaleY(50);
        $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
        $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

        // فایل PPTX را روی دیسک ذخیره کنید.
        $presentation->save("tile.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

نتیجه:

![گزینه‌های تایل](tile-options.png)

## **پر کردن رنگ ثابت**

در PowerPoint، پر کردن رنگ ثابت یک گزینه قالب‌بندی است که شکل را با یک رنگ یکدست پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگوئی اعمال می‌شود.

برای اعمال پر کردن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. FillType شکل را روی `Solid` تنظیم کنید.
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

کد PHP زیر نشان می‌دهد که چگونه پر کردن رنگ ثابت را بر روی یک مستطیل در اسلاید PowerPoint اعمال کنید:

```php
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
$presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // نوع پرکن را به Solid تنظیم کنید.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // رنگ پرکن را تنظیم کنید.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // فایل PPTX را روی دیسک ذخیره کنید.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، وقتی یک رنگ ثابت، گرادیان، تصویر یا بافت را به شکل‌ها اعمال می‌کنید، می‌توانید سطح شفافیتی را نیز تنظیم کنید تا میزان شفافیت پر کردن را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل بیشتر شفاف شود و پس‌زمینه یا اشیای زیرین به‌طور جزئی قابل مشاهده باشند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در اینجا نحوهٔ انجام این کار آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. FillType را روی `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت استفاده کنید (مقدار `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

کد PHP زیر نشان می‌دهد که چگونه رنگ پر کردن شفاف را بر روی یک مستطیل اعمال کنید:

```php
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
$presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل خودکار مستطیل صلب اضافه کنید.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // یک شکل خودکار مستطیل شفاف بر روی شکل ثابت اضافه کنید.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // فایل PPTX را روی دیسک ذخیره کنید.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن شکل‌ها**

Aspose.Slides به شما امکان می‌دهد شکل‌ها را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص چیدمان یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

کد PHP زیر نشان می‌دهد که چگونه یک شکل را به‌صورت ۵ درجه بچرخانید:

```php
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
$presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // شکل را به میزان 5 درجه بچرخانید.
    $shape->setRotation(5);

    // فایل PPTX را روی دیسک ذخیره کنید.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افکت‌های برجستگی 3D**

Aspose.Slides امکان اعمال افکت‌های برجستگی 3D به شکل‌ها را از طریق پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) فراهم می‌کند.

برای افزودن افکت‌های برجستگی 3D به یک شکل، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ThreeDFormat شکل را پیکربندی کنید تا تنظیمات برجستگی را تعریف کند.
1. ارائه را ذخیره کنید.

کد PHP زیر نشان می‌دهد که چگونه افکت‌های برجستگی 3D را بر روی یک شکل اعمال کنید:

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

![افکت برجستگی 3D](3D-bevel-effect.png)

## **افکت‌های چرخش 3D**

Aspose.Slides امکان اعمال افکت‌های چرخش 3D به شکل‌ها را از طریق پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) فراهم می‌کند.

برای اعمال چرخش 3D به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. از متدهای [setCameraType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/lightrig/#setLightType) برای تعریف چرخش 3D استفاده کنید.
1. ارائه را ذخیره کنید.

کد PHP زیر نشان می‌دهد که چگونه افکت‌های چرخش 3D را بر روی یک شکل اعمال کنید:

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

![افکت چرخش 3D](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد Java زیر نشان می‌دهد که چگونه قالب‌بندی یک اسلاید را بازنشانی کرده و موقعیت، اندازه و قالب‌بندی تمام شکل‌های دارای جای‌نگهدار در [LayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض برگردانید:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // هر شکل روی اسلایدی که در طرح‌بندی جای‌نگهدار دارد را بازنشانی کنید.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت جزئی. تصاویر و رسانه‌های تعبیه‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ حجم اضافی ایجاد نمی‌کنند.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی شکل‌ها—تنظیمات پر، خط و افکت—را مقایسه کنید. اگر تمام مقادیر متناظر یکسان باشند، سبک آن‌ها را یکسان درنظر بگیرید و منطقی آن شکل‌ها را گروه‌بندی کنید که مدیریت سبک‌ها را در مراحل بعدی ساده‌تر می‌کند.

**آیا می‌توانم یک مجموعه از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. شکل‌های نمونه با سبک‌های مورد نظر را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائه جدید، قالب را باز کنید، شکل‌های سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جای لازم مجدداً اعمال کنید.