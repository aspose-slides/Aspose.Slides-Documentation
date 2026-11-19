---
title: ایجاد افکت‌های 3D در ارائه‌ها با استفاده از PHP
linktitle: ارائه 3D
type: docs
weight: 232
url: /fa/php-java/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه 3D
- چرخش 3D
- عمق 3D
- برش 3D
- گرادیان 3D
- متن 3D
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "اعمال و رندر افکت‌های 3D برای اشکال و متن PowerPoint در PHP با Aspose.Slides. تنظیم دوربین، نورپردازی، مصالح، برش، پرکردن‌ها و متن 3D."
---
## **مرور کلی**

Aspose.Slides برای PHP از طریق Java می‌تواند قالب‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برش (extrusion)، bevels، lighting، material، پر کردن با گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی روی اشکال و متن PowerPoint است. در مورد درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. زمانی که یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات سه‌بعدی را در خروجی دو‑بعدی رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از متد [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. این متد یک شیء [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید. این متد قالب‌بندی سه‌بعدی را به فریم متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | آنچه کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | نقطهٔ دید، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | برای چرخش شیء در فضای سه‌بعدی یا تطبیق با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | پیش‌تنظیم نور، جهت و چرخش نور. | برای تغییر ظاهر نورهای برجسته و سایه‌ها روی سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | متریال سطح، مانند صاف، مات، پلاستیک یا فلز. | برای اینکه یک هندسه یکسان به شکل صاف‌تر، نرم‌تر، براق یا فلزی ظاهر شود. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | فاصلهٔ جلو بودن شکل از صورت جلوی آن. | تبدیل یک شکل صاف به یک شیء سه‌بعدی واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ طرف‌های برش شده. | برای نمایان کردن عمق یا هماهنگ‌سازی رنگ طرف‌ها با پر کردن جلو. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | عمق سه‌بعدی اضافی مورد استفاده توسط قالب‌بندی PowerPoint. | برای تنظیم دقیق عمق اشکال یا متن، به‌ویژه همراه با تنظیمات bevel و material. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های برجسته یا گرد شده روی وجوه جلو و پشت. | اضافه کردن لبهٔ نرم یا قالب‌دار به جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) و [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | خطوط مرزی اطراف شیء سه‌بعدی. | برجسته کردن مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌طور قابل‌قانع‌کننده‌ای سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، چون نمای پیش‌فرض ممکن است برش را پنهان کند.
- تنظیمات نور، چون نور باعث قابل‌خواندن شدن وجوه و طرف‌ها می‌شود.
- تنظیمات متریال، چون سطح بر نحوهٔ رندر نور تاثیر می‌گذارد.
- تنظیمات برش یا عمق، چون یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متنی به صورت جلویی آن اضافه می‌کند و قالب‌بندی سه‌بعدی اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه هستند و ارتفاع برش 100 نقطه است. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند.

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

تصویر رندر شدهٔ اسلاید، مستطیل را به‌صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z با چرخشی که از طریق API دوربین تنظیم می‌کنید مطابقت دارد.

![پنل 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z‌های مشخص شده](img_02_01.png)

در Aspose.Slides، از [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) برای دسترسی به دوربین استفاده کنید. این مثال یک مستطیل می‌سازد، نمای جلویی ارتوغرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z را به ترتیب 20، 30 و 40 درجه تنظیم می‌کند. شکل در حافظه پیکربندی می‌شود بدون ذخیرهٔ فایل:

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

از دوربین زمانی استفاده کنید که بخواهید دیدن شیء توسط کاربر تغییر کند. این کار هندسهٔ دو‑بعدی شکل روی اسلاید را تغییر نمی‌دهد؛ فقط نقطهٔ دید سه‌بعدی که PowerPoint و Aspose.Slides هنگام رندر استفاده می‌کنند را تغییر می‌دهد.

### **کپی کردن جهت دوربین از یک شکل قالب**

برای تطبیق جهت یک شکل قالب، پیش‌تنظیم دوربین آن را با [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) و زاویه‌های چرخش آن را با [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation) بخوانید. مثال فایل `template.pptx` را باز می‌کند و جهت دوربین را از اولین شکل اسلاید اول به شکل دوم می‌کپی می‌کند. هر دو شکل قبلاً نور سه‌بعدی دارند و شکل دوم چرخش دوربین صریحی ندارد.

زاویه‌ها بر حسب درجه‌اند. اندیس `0` نشانگر عرض جغرافیایی، اندیس `1` طول جغرافیایی و اندیس `2` دورانی است. این مقادیر را به ترتیب به [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) پاس می‌دهید. اگر منبع `null` برگرداند، چرخش صریحی ندارید و می‌توانید زاویه‌های شکل دوم را تنظیم نکنید. یک چرخش صریح `(0, 0, 0)` سه صفر برمی‌گرداند و باید کپی شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

هنگامی که `camera-copy.pptx` را در PowerPoint باز می‌کنید، پیکان سمت راست همان پیش‌تنظیم دوربین و چرخش را دارد که مستطیل سمت چپ دارد. هر دو شکل از همان نور و عمق برش استفاده می‌کنند.

![یک مستطیل سه‌بعدی آبی و یک پیکان راست با جهت دوربین هم‌خوان، دیده شده از بالا و سمت راست](camera-orientation.png)

## **افزودن برش و عمق**

برش باعث می‌شود یک شکل ضخیم به‌نظر برسد و از سطح جلویی به عقب امتداد یابد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ، رنگ طرف‌های جانبی را تنظیم می‌کند.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ برش و ارتفاع برش مرتبط هستند](img_02_02.png)

از [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) برای تنظیم ضخامت و از [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) برای دسترسی به رنگ طرف‌ها استفاده کنید. این مثال مستطیلی با برش 100 نقطه‌ای و طرف‌های بنفش می‌دهد و دوربین را می‌چرخاند تا ضخامت را نشان دهد. شکل در حافظه پیکربندی می‌شود بدون ذخیرهٔ فایل:

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

متد [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) عمق یک شکل سه‌بعدی را تعیین می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) ارتفاع اثر برش را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پر کردن گرادیان یا تصویر همراه با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پر کردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پر کردن تصویر را بر روی سطح جلوی شکل اعمال کنید و همچنان از همان تنظیمات دوربین، نور، متریال و برش استفاده کنید.

این مثال یک گرادیان آبی‑به‑نارنجی بر روی سطح جلویی اعمال می‌کند و به برش 150 نقطه‌ای رنگ نارنجی می‌دهد. نقاط توقف گرادیان در 0 و 100 آغاز و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

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

خروجی رندر شده گرادیان را روی سطح جلویی حفظ می‌کند و برش را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پر کردن گرادیان آبی‑به‑نارنجی و برش نارنجی](img_02_03.png)

برای استفاده از پر کردن تصویر، تصویر را به ارائه اضافه کنید و به پر کردن شکل اختصاص دهید. این مثال به فایلی به نام «image.jpg» در پوشهٔ کاری نیاز دارد. تصویر را کشیده تا مستطیل را پر کند، برش 150 نقطه‌ای اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل در حافظه پیکربندی می‌شود بدون ذخیره یا رندر فایل:

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

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که برش به‌عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پر کردن عکسی بر روی سطح جلویی و برش نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل اثر می‌گذارد. قالب‌بندی سه‌بعدی متن بر فریم متن اثر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به برش، متریال، نور و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی مشبک نارنجی‑و‑سفید ایجاد می‌کند، یک قوس بالا را اعمال می‌نماید و تنظیمات سه‌بعدی را از طریق [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) پیکربندی می‌کند. ارتفاع برش و عمق بر حسب نقطه هستند و چرخش نور بر حسب درجه است. پر کردن شکل و حاشیه مخفی هستند تا فقط متن قابل مشاهده باشد. مثال تصویر PNG با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند:

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

متن به صورت حروف منحنی، برش‌دار و سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل قوس‌دار WordArt، پر کردن الگوی نارنجی و برش تاریک](img_02_05.png)

## **حفظ متن به‌صورت صاف روی یک شکل سه‌بعدی**

برای اینکه متن قابل خواندن بماند در حالی که ظاهر سه‌بعدی شکل حفظ شود، از [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) از طریق [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) استفاده کنید. وقتی مقدار `true` باشد، متن از صحنهٔ سه‌بعدی دور می‌ماند. وقتی `false` باشد، متن در صحنه شرکت می‌کند و جهت سه‌بعدی آن را دنبال می‌کند.

این تنظیم قالب‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نور، متریال و برش آن همچنان از طریق [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) تنظیم می‌شوند. همچنین با چرخش معمولی متفاوت است. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) شکل را در صفحه اسلاید می‌چرخاند، در حالی که [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) چرخش سفارشی متن را داخل جعبهٔ محدود‌کنندهٔ خودش کنترل می‌کند. نگه‌داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را بازنشانی نمی‌کند.

مثال زیر یک مستطیل آبی با متن می‌سازد و آن را در کنار نسخهٔ اصلی کپی می‌کند. هر دو شکل همان قالب‌بندی سه‌بعدی را دارند؛ فقط تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه‌اند و ارتفاع برش 40 نقطه است. مثال ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

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

در سمت چپ، متن جهت سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آن آسان‌تر است. هر دو مستطیل همان برش قابل مشاهده و جهت سه‌بعدی را حفظ می‌کنند.

![مستطیل‌های سه‌بعدی کنار هم: متن در سمت چپ جهت سه‌بعدی را دنبال می‌کند و در سمت راست صاف می‌ماند](keep_text_flat.png)

## **رفتار خروجی و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت‑صفحه، صحنهٔ سه‌بعدی به‌صورت دو‑بعدی رستر یا نقاشی می‌شود. این برای رندر اسلایدها به [PNG](/slides/fa/php-java/convert-powerpoint-to-png/)، خروجی به [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)، خروجی به [HTML](/slides/fa/php-java/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل ویدیو](/slides/fa/php-java/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDFهای خروجی تعاملی نیستند. پس از خروجی، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نور، متریال، برش، پر کردن و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی به‌دست آمده از ارث‌بری یا تم دارید، ویژگی‌های مؤثر شکل را از [effective shape properties](/slides/fa/php-java/shape-effective-properties/) بخوانید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در آن فرمت‌ها، نتیجه بصری رندر می‌شود نه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش.

## **سؤالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های تعاملی سه‌بعدی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDF یا صفحات HTML خروجی را به صحنه‌های تعاملی سه‌بعدی تبدیل نمی‌کند که کاربر بتواند آن را بچرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint ویرایش‌پذیر می‌ماند، مشروط بر این‌که فرمت از آن پشتیبانی کند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر روی یک شکل یا متن PowerPoint عادی اعمال می‌شود، مانند چرخش، برش، bevel، نور و متریال. این مقاله به اثرهای سه‌بعدی می‌پردازد.

**کدام تنظیمات برای قابل مشاهده بودن یک شکل سه‌بعدی ضروری‌اند؟**

حداقل باید یک چرخش دوربین و یا برش یا عمق تنظیم شود. در عمل همچنین تنظیم نور و متریال توصیه می‌شود تا وجوه رندر شده واضح و دارای سایه و نور باشند.

**آیا می‌توانم اثرهای سه‌بعدی را هم به اشکال و هم به متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) و برای متن از [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید.

**آیا اثرهای سه‌بعدی هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**

بله. Aspose.Slides اثرهای سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدیو رندر می‌کند. خروجی حاوی ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر توضیح داده‌شده در [Shape Effective Properties](/slides/fa/php-java/shape-effective-properties/) برای خواندن دوربین نهایی، نور، bevel و مقادیر مرتبط با سه‌بعدی استفاده کنید.