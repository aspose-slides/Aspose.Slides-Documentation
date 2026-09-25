---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها با استفاده از PHP
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/php-java/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برون‌سپاری سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "اعمال و رندر اثرات سه‌بعدی برای اشکال و متن PowerPoint در PHP با Aspose.Slides. پیکربندی دوربین، نورپردازی، ماده، برون‌سپاری، پرکننده‌ها و متن سه‌بعدی."
---
## **مرور کلی**

Aspose.Slides برای PHP از طریق Java می‌تواند قالب‌سازی سه‌بعدی شبیه به PowerPoint برای اشکال و متن را ایجاد، ویرایش، نگهداری و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برون‌سپاری، لبه‌دار، نورپردازی، ماده، پرکننده‌های گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله در مورد اثرات قالب‌سازی سه‌بعدی بر اشکال و متن PowerPoint است. این مقاله درباره درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. وقتی یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‌بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌سازی سه‌بعدی**

از متد [Shape::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getThreeDFormat--) برای اعمال قالب‌سازی سه‌بعاد به یک شکل استفاده کنید. این متد یک شیء [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#getThreeDFormat--) استفاده کنید. این متد قالب‌سازی سه‌بعدی را به چارچوب متن به جای بدن شکل اعمال می‌کند.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چیزی که کنترل می‌کند | چه موقع استفاده شود |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getCamera--) | نقطه‌ی مشاهده، نوع دوربین پیش‌تنظیم، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا تطبیق با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getLightRig--) | پیش‌تنظیم نور، جهت، و چرخش نور. | تغییر نحوهٔ نمایش هایلایت‌ها و سایه‌ها بر سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setMaterial-byte-) | جنس سطح، مانند صاف، مات، پلاستیک یا فلز. | ظاهر ژئومتری یکسان را صاف‌تر، نرم‌تر، براق یا فلزی کنید. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | چقدر شکل از سطح جلو به سمت عقب کشیده می‌شود. | تبدیل یک شکل صاف به شیء سه‌بعدی واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getExtrusionColor--) | رنگ طرف‌های برون‌سپاری شده. | عمق را قابل مشاهده کنید یا رنگ طرف‌ها را با پرکننده جلویی هماهنگ کنید. |
| [getDepth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setDepth-double-) | عمق سه‌بعدی اضافی که توسط قالب‌سازی سه‌بعدی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌خصوص همراه با تنظیمات لبه و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getBevelBottom--) | لبه‌های بالا یا گرد شده در سطوح جلو و پشت. | افزودن لبه نرم یا قالب‌دار به جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setContourWidth-double-) | خط‌مرزبندی اطراف شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً برای اینکه به‌طور قانع‌کننده‌ای سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلویی ممکن است برون‌سپاری را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث می‌شود سطوح و طرف‌ها قابل خواندن باشند.
- تنظیمات ماده، زیرا سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات برون‌سپاری یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متنی را به سطح جلویی آن اضافه می‌کند و قالب‌سازی سه‌بعدی را اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه هستند و ارتفاع برون‌سپاری 100 پوینت است. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌نماید.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تصویر رندر شده اسلاید مستطیل را به‌عنوان یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید روی سطح جلو](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنل چرخش سه‌بعدی پیکربندی می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنل چرخش سه‌بعدی PowerPoint با مقادیر چرخش X ، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، به دوربین از طریق [ThreeDFormat::getCamera](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getCamera--) دسترسی پیدا می‌کنید. این مثال یک مستطیل ایجاد می‌کند، یک نمای ارتوگرافیک جلویی انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب 20، 30 و 40 درجه تنظیم می‌نماید. شکل در حافظه پیکربندی می‌شود بدون اینکه فایلی ذخیره شود:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

از دوربین زمانی استفاده کنید که نیاز داشته باشید نحوهٔ مشاهدهٔ شیء را تغییر دهید. این کار هندسهٔ دو‌بعدی شکل را روی اسلاید تغییر نمی‌دهد، بلکه نقطهٔ نظر سه‌بعدی استفاده‌شده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **افزودن برون‌سپاری و عمق**

برون‌سپاری یک شکل را ضخیم می‌کند با اینکه آن را از پشت سطح جلو گسترش می‌دهد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ طرف‌ها را تعیین می‌نماید.

![کنترل‌های عمق PowerPoint متصل به ویژگی‌های رنگ برون‌سپاری و ارتفاع برون‌سپاری](img_02_02.png)

از [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) برای تنظیم ضخامت و از [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getExtrusionColor--) برای دسترسی به رنگ طرف‌ها استفاده کنید. این مثال به مستطیل یک برون‌سپاری 100 پوینت با طرف‌های بنفش می‌دهد و دوربین را می‌چرخاند تا ضخامت آن آشکار شود. شکل در حافظه پیکربندی می‌شود بدون ذخیرهٔ فایل:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

متد [ThreeDFormat::setDepth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setDepth-double-) عمق یک شکل سه‌بعدی را تنظیم می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) ارتفاع اثر برون‌سپاری را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکننده‌های گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌سازی سه‌بعدی مستقل از پرکنندهٔ شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکنندهٔ تصویر را بر سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برون‌سپاری استفاده کنید.

این مثال یک گرادیان آبی‑به‑نارنجی را بر سطح جلویی اعمال می‌کند و رنگ نارنجی تیره‌ای به برون‌سپاری 150 پوینت می‌دهد. نقاط توقف گرادیان در 0 و 100 شروع و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

خروجی رندر شده گرادیان را بر روی سطح جلویی حفظ می‌کند و برون‌سپاری را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکننده گرادیان آبی تا نارنجی و برون‌سپاری نارنجی](img_02_03.png)

برای استفاده از پرکنندهٔ تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکنندهٔ شکل اختصاص دهید. این مثال به فایلی به نام «image.jpg» در پوشهٔ کاری نیاز دارد. تصویر را برای پر کردن مستطیل کشیده می‌کند، برون‌سپاری 150 پوینت را اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل در حافظه پیکربندی می‌شود بدون ذخیره یا رندر فایل:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

تصویر روی سطح جلویی رندر می‌شود، در حالی که برون‌سپاری به عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکنندهٔ عکس بر روی سطح جلویی و برون‌سپاری نارنجی](img_02_04.png)

## **اعمال قالب‌سازی سه‌بعدی بر متن**

قالب‌سازی سه‌بعدی شکل بر بدن شکل تأثیر می‌گذارد. قالب‌سازی سه‌بعدی متن بر چارچوب متن تأثیر می‌گذارد. این مورد برای اثرات شبیه WordArt مفید است که حروف خود نیاز به برون‌سپاری، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی مشبک نارنجی‑و‑سفید ایجاد می‌کند، یک قوس بالایی اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#getThreeDFormat--) پیکربندی می‌نماید. ارتفاع برون‌سپاری و عمق بر حسب پوینت هستند و چرخش نور بر حسب درجه. پرکننده و خط‌مرزبندی شکل مخفی هستند تا فقط متن قابل مشاهده باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

متن به‌صورت حروف منحنی، برون‌سپاری شدهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکننده الگوی نارنجی و برون‌سپاری تاریک](img_02_05.png)

## **حفظ متن صاف روی یک شکل سه‌بعدی**

برای اینکه متن قابل خواندن باشد در حالی که ظاهر سه‌بعدی شکل حفظ شود، از [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) از طریق [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getTextFrameFormat--) استفاده کنید. وقتی مقدار `true` باشد، متن از صحنهٔ سه‌بعدی خارج می‌ماند. وقتی `false` باشد، متن در صحنه شرکت می‌کند و جهت سه‌بعدی آن را دنبال می‌کند.

این تنظیم قالب‌سازی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نور، ماده و برون‌سپاری آن همچنان از طریق [Shape::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getThreeDFormat--) پیکربندی می‌شوند. این تنظیم متفاوت از چرخش معمولی است. [Shape::setRotation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#setRotation-float-) شکل را در صفحهٔ اسلاید می‌چرخاند، درحالی‌که [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) چرخش سفارشی متن را داخل کادر مرزی‌اش کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را ریست نمی‌کند.

مثال خودکفای زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصل کلون می‌کند. هر دو شکل همان قالب‌سازی سه‌بعدی را دارند؛ تنها تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زوایای دوربین بر حسب درجه هستند و ارتفاع برون‌سپاری 40 پوینت است. مثال ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌نماید.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

در سمت چپ، متن جهت‌گیری سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آن آسان‌تر است. هر دو مستطیل همان برون‌سپاری قابل مشاهده و جهت‌گیری سه‌بعدی را حفظ می‌کنند.

![مستطیل‌های سه‌بعدی کنار هم: متن در سمت چپ با جهت‌گیری سه‌بعدی و متن در سمت راست صاف](keep_text_flat.png)

## **رفتار استخراج و رندر**

Aspose.Slides قالب‌سازی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا استخراج به فرمت‌های ثابت‑طرح، صحنهٔ سه‌بعدی به‌صورت تصویر دو‌بعدی رستر یا رسم می‌شود. این رفتار هنگام رندر اسلایدها به [PNG](/slides/fa/php-java/convert-powerpoint-to-png/)، استخراج به [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)، استخراج به [HTML](/slides/fa/php-java/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل ویدئو](/slides/fa/php-java/convert-powerpoint-to-video/) اعمال می‌شود.

نکات مهم:

- تصاویر و PDFهای استخراج‌شده تعاملی نیستند. پس از استخراج، شیء نمی‌تواند توسط کاربر چرخانده شود.
- ظاهر نهایی بستگی به ترکیب دوربین، نور، ماده، برون‌سپاری، پرکننده و مقیاس اسلاید دارد.
- اگر نیاز به بررسی مقادیر قالب‌سازی به‌دست‌آمده یا مبتنی بر تم دارید، به [effective shape properties](/slides/fa/php-java/shape-effective-properties/) مراجعه کنید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌سازی سه‌بعدی PowerPoint قابل ویرایش را ذخیره کنند. در آن‌ها نتیجهٔ بصری رندر می‌شود نه اینکه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این کتابخانه تصاویر، PDFها یا صفحات HTML صادرشده را به صحنه‌های سه‌بعدی تعاملی تبدیل نمی‌کند که کاربر بتواند آنها را بچرخاند. در PPTX، قالب‌سازی سه‌بعدی در PowerPoint ویرایش‌پذیر می‌ماند به‌شرطی که فرمت از آن پشتیبانی کند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی شیء مستقل است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌سازی‌ای است که به یک شکل یا متن عادی PowerPoint اعمال می‌شود، مانند چرخش، برون‌سپاری، لبه‌دار، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل مشاهده لازم است؟**

حداقل باید یک چرخش دوربین و یا برون‌سپاری یا عمق تنظیم کنید. در عمل، همچنین تنظیم نور و ماده توصیه می‌شود تا سطوح رندر شده روشنایی و سایه‌های واضح داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم بر روی اشکال و هم بر روی متن اعمال کنم؟**

بله. برای بدن شکل از [Shape::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getThreeDFormat--) و برای متن از [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#getThreeDFormat--) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام استخراج به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل ویدئو رندر می‌کند. خروجی استخراج‌شده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌سازی مؤثر توصیف‌شده در [Shape Effective Properties](/slides/fa/php-java/shape-effective-properties/) برای خواندن دوربین نهایی، نورپردازی، لبه و مقادیر مرتبط با سه‌بعدی استفاده کنید.