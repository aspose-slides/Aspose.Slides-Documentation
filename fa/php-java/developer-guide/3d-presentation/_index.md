---
title: "ایجاد افکت‌های سه‌بعدی در ارائه‌ها با استفاده از PHP"
linktitle: "ارائه سه‌بعدی"
type: docs
weight: 232
url: /fa/php-java/3d-presentation/
keywords:
- "PowerPoint سه‌بعدی"
- "ارائه سه‌بعدی"
- "چرخش سه‌بعدی"
- "عمق سه‌بعدی"
- "برآمدگی سه‌بعدی"
- "گرادیان سه‌بعدی"
- "متن سه‌بعدی"
- "PowerPoint"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "اعمال و رندر افکت‌های سه‌بعدی برای اشکال و متون PowerPoint در PHP با Aspose.Slides. تنظیم دوربین، نورپردازی، ماده، برآمدگی، پرکننده‌ها و متن سه‌بعدی."
---
## **بررسی کلی**

Aspose.Slides برای PHP از طریق Java می‌تواند قالب‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متون ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی نظیر چرخش، برآمدگی، حاشیه‌زنی، نورپردازی، ماده، پرکننده‌های گرادیان یا تصویر و متن سه‌بعدی می‌پردازد.

{{% alert color="primary" %}}

این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی روی اشکال و متن‌های PowerPoint است. دربارهٔ افزودن یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگام صادرات یک اسلاید به تصویر، PDF یا HTML، Aspose.Slides این اثرات سه‌بعدی را در خروجی دو‌بعدی رندر می‌کند.

{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) و متد [Shape::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getThreeDFormat--) برای اعمال قالب‌بندی سه‌بعدی روی یک شکل استفاده کنید. این متد شیء [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/) و متد [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#getThreeDFormat--) استفاده کنید. این کار قالب‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین تنظیمات عبارتند از:

| Method or setting | What it controls | When to use it |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getCamera--) | نقطهٔ دید، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | برای چرخاندن شیء در فضا یا مطابقت با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint استفاده می‌شود. |
| [getLightRig](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getLightRig--) | نور پیش‌تنظیم، جهت و چرخش نور. | برای تغییر نحوهٔ ظاهر شدن هایلایت‌ها و سایه‌ها بر سطح سه‌بعدی به کار می‌رود. |
| [setMaterial](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setMaterial-byte-) | مادهٔ سطح، مانند صاف، مات، پلاستیکی یا فلزی. | برای دادن ظاهر صاف‌تر، نرم‌تر، براق یا فلزی به همان هندسه استفاده می‌شود. |
| [setExtrusionHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | میزان پیشروی شکل به سمت عقب از سطح جلویی آن. | تبدیل یک شکل صاف به یک شیء سه‌بعدی قابل‌مشاهده. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getExtrusionColor--) | رنگ طرف‌های برآمده. | برای نمایان کردن عمق یا هماهنگ کردن رنگ طرف‌ها با پرکنندهٔ جلویی استفاده می‌شود. |
| [setDepth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setDepth-double-) | عمق سه‌بعدی اضافی که توسط قالب‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات حاشیه‌زنی و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getBevelBottom--) | لبه‌های برجسته یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به‌جای یک سطح صاف تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getContourColor--) و [setContourWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setContourWidth-double-) | خط‌چین دور شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندرشده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً برای داشتن ظاهر واقعی سه‌بعدی به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، چون نمای پیش‌فرض ممکن است برآمدگی را مخفی کند.
- تنظیمات نور، چون نورپردازی باعث دیده شدن واضح سطوح و طرف‌ها می‌شود.
- تنظیمات ماده، چون سطح تأثیر می‌گذارد که نور چگونه بازتاب شود.
- تنظیمات برآمدگی یا عمق، چون یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متنی به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌نماید.

```php
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

در PowerPoint، چرخش سه‌بعدی از طریق پنجرهٔ 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی است که از طریق API دوربین تعیین می‌کنید.

![پنجرهٔ 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z هایلایت شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق [ThreeDFormat::getCamera](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getCamera--) تنظیم کنید:

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

از دوربین زمانی استفاده کنید که نیاز به تغییر نحوهٔ مشاهدهٔ شیء توسط بیننده داشته باشید. این کار شکل دو‌بعدی اسلاید را تغییر نمی‌دهد؛ فقط نقطهٔ دید سه‌بعدی مورد استفاده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **افزودن برآمدگی و عمق**

برآمدگی باعث می‌شود یک شکل به‌نظر خشکدار برسد با افزایش آن به‌پشت سطح جلویی. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ طرف‌ها را تعیین می‌نماید.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ برآمدگی و ارتفاع برآمدگی نگاشت می‌شود](img_02_02.png)

برای ضخامت، متد [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) را تنظیم کنید و برای رنگ طرف‌ها متد [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getExtrusionColor--) را به کار ببرید:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

از [ThreeDFormat::setDepth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#setDepth-double-) زمانی استفاده کنید که نیاز به کار مستقیم با مقدار عمق PowerPoint یا ترکیب عمق با حاشیه‌زنی، ماده و اثرات متنی داشته باشید. در بسیاری از سناریوهای شکل، `setExtrusionHeight` تنظیم واضح‌تری است چون مستقیماً برآمدگی قابل مشاهده را بیان می‌کند.

## **استفاده از پرکننده‌های گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکنندهٔ شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکنندهٔ تصویر را به سطح جلویی اعمال کنید و همچنان از همان دوربین، نور، ماده و تنظیمات برآمدگی استفاده کنید.

این مثال یک پرکنندهٔ گرادیان به شکل اعمال می‌کند و رنگ برآمدگی تاریک‌تری به طرف‌ها می‌دهد:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

خروجی رندر شده گرادیان را روی سطح جلویی حفظ می‌کند و برآمدگی را به‌صورت جداگانه رندر می‌نماید:

![مستطیل سه‌بعدی رندر شده با پرکنندهٔ گرادیان آبی‑به‑نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکنندهٔ تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکنندهٔ شکل اختصاص دهید:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

تصویر روی سطح جلویی رندر می‌شود، در حالی که برآمدگی به‌عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکنندهٔ تصویر روی سطح جلویی و برآمدگی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر قاب متن اثر می‌گذارد. این برای اثرات شبیه WordArt مفید است که در آن حروف خود نیاز به برآمدگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکنندهٔ الگو ایجاد می‌کند، تبدیل WordArt را اعمال می‌کند و تنظیمات سه‌بعدی را بر روی [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/) پیکربندی می‌نماید:

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

متن به‌صورت حروف منحنی و برآمدگی‌دار سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوس‌دار، پرکنندهٔ الگو نارنجی و برآمدگی تاریک](img_02_05.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های ثابت‑طرح، صحنهٔ سه‌بعدی به‌صورت رستر یا به‌صورت یک نتیجهٔ دو‌بعدی در خروجی رسم می‌شود. این موضوع هنگام رندر اسلایدها به [PNG](/slides/fa/php-java/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/php-java/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل به ویدئو](/slides/fa/php-java/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDFهای صادر شده تعاملی نیستند. شیء پس از صادرات توسط بیننده قابل چرخش نیست.
- ظاهر نهایی به ترکیب دوربین، نور، ماده، برآمدگی، پرکننده و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی وارث یا مبتنی بر تم دارید، API‌های ویژگی‌های مؤثر شکل را در [effective shape properties](/slides/fa/php-java/shape-effective-properties/) مطالعه کنید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در آن فرمت‌ها، نتیجهٔ بصری رندر می‌شود نه به‌صورت تنظیمات سه‌بعدی قابل ویرایش.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDF یا صفحات HTML صادرشده را به صحنه‌های سه‌بعدی تعاملی تبدیل نمی‌کند که بیننده بتواند آنها را بچرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint که از این ویژگی پشتیبانی می‌کند، قابل ویرایش می‌ماند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی مستقل است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، حاشیه‌زنی، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل مشاهده لازم است؟**

حداقل باید یک چرخش دوربین و یا برآمدگی یا عمق تنظیم شود. در عمل، تنظیم یک نورپردازی و ماده نیز ضروری است تا سطوح رندر شده هایلایت‌ها و سایه‌های واضحی داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم روی اشکال و هم روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getThreeDFormat--) و برای متن از [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#getThreeDFormat--) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل به ویدئو رندر می‌کند. خروجی صادرشده شامل ظاهر رندرشده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از API‌های قالب‌بندی مؤثر توضیح داده‌شده در [Shape Effective Properties](/slides/fa/php-java/shape-effective-properties/) برای خواندن دوربین نهایی، نورپردازی، حاشیه‌زنی و مقادیر سه‌بعدی مرتبط استفاده کنید.