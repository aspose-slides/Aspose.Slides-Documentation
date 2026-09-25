---
title: ایجاد و اعمال افکت‌های WordArt در PHP
linktitle: WordArt
type: docs
weight: 110
url: /fa/php-java/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- افکت WordArt
- افکت سایه
- افکت انعکاس
- افکت درخشانی
- تبدیل WordArt
- افکت 3بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- PHP
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای PHP از طریق Java. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در PHP ارتقا دهند."
---
## **نمای کلی**

افکت‌های WordArt به شما امکان می‌دهند متن را با پرکردن، خطوط دور، سایه‌ها، انعکاس‌ها، درخشندگی، تبدیل‌ها و قالب‌بندی سه‌بعدی استایل دهید. این مقاله توضیح می‌دهد چگونه این افکت‌ها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java، بدون نصب Microsoft Office، ایجاد و سفارشی کنید.

## **ایجاد یک قالب ساده WordArt و اعمال آن روی متن**

مثال‌های زیر یک سبک ساده WordArt را با تنظیم متن، قلم، پر کردن الگو و خط دور می‌سازند.

هر مثال یک ارائه جدید می‌سازد و یک مستطیل به اسلاید اول آن اضافه می‌کند؛ نیازی به فایل ورودی نیست. مثال اول متن را به «Aspose.Slides» تنظیم می‌کند. موقعیت و ابعاد شکل بر حسب نقطه اندازه‌گیری می‌شود:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

قلم را به Arial Black با اندازه ۳۶ نقطه تنظیم کنید تا قالب‌بندی واضح‌تر باشد:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

یک الگوی [SmallGrid](https://reference.aspose.com/slides/fa/php-java/aspose.slides/patternstyle/#SmallGrid) با پیش‌زمینه نارنجی تیره و پس‌زمینه سفید اعمال کنید، سپس یک خط دور متنی سیاه با عرض ۱ نقطه اضافه کنید:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

متن حاصل:

![قالب ساده WordArt](WordArt_template.png)

## **اعمال افکت‌های دیگر WordArt**

مثال‌های زیر نشان می‌دهند چگونه سایه‌ها، انعکاس‌ها، درخشندگی، تبدیل‌ها و افکت‌های سه‌بعدی را به متن اعمال کنید.

### **اعمال افکت سایه خارجی**

سایهٔ خارجی عمق می‌دهد با قرار دادن سایه‌ای پشت متن. می‌توانید رنگ، جهت، فاصله، شعاع تاری، مقیاس و کج‌کردن آن را سفارشی کنید.

این مثال فراخوانی می‌کند [enableOuterShadowEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) و سایه‌ای سیاه با شعاع تاری ۴ نقطه، جهت ۲۳۰ درجه و فاصله ۳۰ نقطه تنظیم می‌کند. مقادیر مقیاس ۱۰۰ سایز سایه را حفظ می‌کند، در حالی که کجی افقی آن را ۲۰ درجه می‌چرخاند. تبدیل آلفا شفافیت آن را به ۳۲٪ تنظیم می‌کند:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

متن حاصل:

![افکت سایه خارجی](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- وقتی سایهٔ خارجی و پیش‌تنظیم شده همزمان استفاده شوند، تنها سایهٔ خارجی اعمال می‌شود.
- اگر سایهٔ خارجی و داخلی همزمان استفاده شوند، اثر نهایی بسته به نسخه PowerPoint متفاوت است. برای مثال، در PowerPoint 2013 اثر دو برابر می‌شود، در حالی که در PowerPoint 2007 تنها سایهٔ خارجی اعمال می‌شود.
{{% /alert %}}

### **اعمال افکت انعکاس**

انعکاس یک نسخهٔ آینه‌ای از متن ایجاد می‌کند. می‌توانید موقعیت، مقیاس، تاری و شفافیت آن را برای کنترل ظاهر تنظیم کنید.

این مثال فراخوانی می‌کند [enableReflectionEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effectformat/#enableReflectionEffect--) و انعکاس را عمودی با مقیاس -۱۰۰٪ وارونه می‌کند. از شعاع تاری ۰.۵ نقطه و فاصله ۴.۷۲ نقطه استفاده می‌کند. شفافیت از ۶۰٪ به ۰.۹٪ بین موقعیت‌های ۰٪ و ۶۰٪ در طول انعکاس کاهش می‌یابد:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

متن حاصل:

![افکت انعکاس](reflection_effect.png)

### **اعمال افکت درخشندگی**

درخشندگی یک خط دور رنگی نرم اطراف متن اضافه می‌کند. می‌توانید رنگ، شفافیت و شعاع آن را برای کنترل اثر تنظیم کنید.

این مثال فراخوانی می‌کند [enableGlowEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effectformat/#enableGlowEffect--) و درخشندگی قرمز با شفافیت ۵۴٪ و شعاع ۷ نقطه اعمال می‌کند:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

متن حاصل:

![افکت درخشانی](glow_effect.png)

### **اعمال تبدیل‌های WordArt**

تبدیل‌های WordArt متن را خم، کشیده یا خمیده می‌کند.

[setTransform](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setTransform-int-) را به [ArchUpPour](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textshapetype/#ArchUpPour) تنظیم کنید تا چارچوب متنی به سمت بالا منحنی شود:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

متن حاصل:

![تبدیل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides برای PHP از طریق Java مجموعه‌ای از [انواع تبدیل از پیش تعریف‌شده](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textshapetype/) را فراهم می‌کند.
{{% /alert %}}

### **اعمال افکت‌های سه‌بعدی به اشکال و متن**

می‌توانید افکت‌های سه‌بعدی را به یک شکل یا به متن آن اعمال کنید. برجستگی‌ها، برآوردن، نورپردازی و تنظیمات دوربین ظاهر نهایی را کنترل می‌کند.

مثال زیر از [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) برای افزودن برجستگی‌های دایره‌ای، برآوردن نارنجی و کنتور قرمز تیره به مستطیل استفاده می‌کند. ابعاد برجستگی، ارتفاع برآوردن، عرض کنتور و عمق بر حسب نقطه اندازه‌گیری می‌شود. یک ماده پلاستیکی، نور متعادل چرخیده ۴۰ درجه حول محور Z و دوربین پرسپکتیو ظاهر آن را تعریف می‌کند:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

شکل حاصل:

![افکت سه‌بعدی شکل](shape_3D_effect.png)

این مثال قالب‌بندی سه‌بعدی مشابهی را به متن از طریق [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#getThreeDFormat--) اعمال می‌کند. برجستگی‌های کوچکتر لبه‌های حروف را شکل می‌دهند، در حالی که برآوردن و نورپردازی به متن عمق می‌بخشد:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

متن حاصل:

![افکت سه‌بعدی متن](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
اعمال افکت‌های سه‌بعدی بر متن یا شکل‌های آن—و تعامل بین این افکت‌ها—بر اساس قوانین خاصی انجام می‌شود. صحنه‌ای را در نظر بگیرید که هم متن و هم شکل حاوی آن در آن حضور دارند. یک افکت سه‌بعدی شامل نمایش سه‌بعدی شیء و صحنه‌ای است که در آن قرار دارد.

- اگر صحنه‌ای برای هر دو شکل و متن تنظیم شده باشد، صحنهٔ شکل اولویت دارد و صحنهٔ متن نادیده گرفته می‌شود.
- اگر شکل صحنهٔ خود را نداشته باشد اما نمایش سه‌بعدی داشته باشد، صحنهٔ متن استفاده می‌شود.
- اگر شکل هیچ افکت سه‌بعدی نداشته باشد، به صورت صاف در نظر گرفته می‌شود و افکت سه‌بعدی فقط بر متن اعمال می‌شود.

این رفتارها به متدهای [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getLightRig--) و [ThreeDFormat::getCamera](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/#getCamera--) مرتبط هستند.
{{% /alert %}}

برای مثال‌های بیشتر درباره قالب‌بندی سه‌بعدی، به [Create 3D Effects in Presentations Using PHP](/slides/fa/php-java/3d-presentation/) مراجعه کنید.

## **سوالات متداول**

**آیا می‌توانم از افکت‌های WordArt با فونت‌ها یا اسکریپت‌های مختلف (مثلاً عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides برای PHP از طریق Java از یونی‌کد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکردن و خط دور بدون توجه به زبان قابل اعمال هستند، هرچند در دسترس بودن فونت و رندر ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را به عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را به اشکال موجود در اسلایدهای مستر، از جمله نگهدارنده‌های عنوان، فوتر یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده بر روی قالب مستر در تمام اسلایدهای وابسته منعکس می‌شود.

**آیا افکت‌های WordArt بر اندازه فایل ارائه تأثیر می‌گذارند؟**

تا حدودی. افکت‌های WordArt مانند سایه‌ها، درخشندگی و پرکردن گرادیان ممکن است به دلیل افزودن متادیتای قالب‌بندی، اندازه فایل را کمی افزایش دهند، اما معمولاً این تفاوت ناچیز است.

**آیا می‌توانم نتیجه افکت‌های WordArt را بدون ذخیرهٔ ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای حاوی WordArt را به تصاویر (مثلاً PNG, JPEG) با استفاده از [Slide::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage--) رندر کنید، یا اشکال منفرد را با [Shape::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage--) رندر کنید. این امکان پیش‌نمایش نتیجه را در حافظه یا روی صفحه نمایش قبل از ذخیره یا خروجی گرفتن از ارائه کامل فراهم می‌کند.