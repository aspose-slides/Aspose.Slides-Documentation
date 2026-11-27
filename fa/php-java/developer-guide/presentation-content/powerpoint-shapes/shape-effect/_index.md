---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از PHP
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/php-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت درخشندگی
- افکت لبه‌های نرم
- فرمت افکت
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با افکت‌های پیشرفته شکل با استفاده از Aspose.Slides برای PHP via Java تبدیل کنید—اسلایدهای برجسته و حرفه‌ای را در ثانیه‌ها ایجاد نمایید."
---
## **مقدمه**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکردن‌ها](/slides/fa/php-java/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های پاورپوینت می‌توانید انعکاس‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، درخشندگی شکل را منتشر کنید و غیره.

![افکت شکل](shape-effect.png)

پاورپوینت شش افکت فراهم می‌کند که می‌توانند بر روی شکل‌ها اعمال شوند. می‌توانید یک یا چند افکت را بر یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های پیش تنظیم ترکیبی از دو یا چند افکت هستند که به‌خوبی شناخته شده‌اند. به این ترتیب، با انتخاب یک پیش تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی شکل‌ها در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for PHP via Java از سایه‌های خارجی و داخلی برای شکل‌ها پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را مطابق با طرح ارائه خود سفارشی کنید.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته کردن یک کارت یا پنل نسبت به پس‌زمینه اسلاید استفاده کنید. سایه خارج از لبه‌های شکل گسترش می‌یابد و احساسی از برآمدگی شکل می‌آورد. رنگ، جهت، فاصله و شعاع تاری آن را مطابق با نورپردازی و استایل قالب خود تنظیم کنید.

این کد PHP نشان می‌دهد چگونه [افکت سایه خارجی](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) را بر روی یک مستطیل اعمال کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![افکت سایه](shadow_effect.png)

#### **کنترل جهت سایه هنگام چرخش یک شکل**

به‌طور پیش‌فرض، سایه خارجی همراه با شکل می‌چرخد. برای اینکه شکل‌هایی با چرخش‌های متفاوت از همان جهت نوردهی شوند، با `false` به [setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape) فراخوانی کنید و با [setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection) جهت یکسانی برای سایه‌ها تنظیم کنید.

مثال دو پیکان آبی با سایه‌های خاکستری به اندازه ۴۲ نقطه به سمت راست (۰°) ایجاد می‌کند. سپس اسلاید را تکثیر کرده و هر دو پیکان را ۹۰ درجه ساعتگرد می‌چرخاند.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![رندر PowerPoint قبل و بعد از چرخش 90°. هر دو سایه ابتدا در سمت راست شروع می‌شوند. پس از چرخش، سایه زیر پیکان چپ حرکت می‌کند و در سمت راست پیکان راست باقی می‌ماند.](arrow-shadow-rotation.png)

### **اعمال سایه داخلی**

برای بازتولید استایل بصری یک قالب، از سایه داخلی برای ایجاد ظاهر فرو رفته یک کارت یا پنل استفاده کنید. سایه خارجی خارج از شکل گسترش می‌یابد و آن را برآمده می‌کند، در حالی که سایه داخلی لبه‌های داخلی شکل را سایه‌دار می‌کند.

با فراخوانی [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) سپس با پیکربندی سایه بازگشتی از [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) ادامه دهید. مقادیر بزرگتر شعاع تاری لبه‌های نرم‌تری تولید می‌کنند.

این مثال PHP یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد کرده و به عنوان فایل PPTX ذخیره می‌کند. جهت سایه ۲۲۵ درجه، فاصله آن ۷ نقطه و شعاع تاری ۶ نقطه است:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![مستطیل آبی روشن با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، بر روی فرمت افکت شکل [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) را فراخوانی کنید.

### **اعمال، تغییر و حذف یک سایه پیش تنظیم**

برای فعال‌سازی یک سایه پیش تنظیم، از [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) استفاده کنید. با [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) می‌توانید یک [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) را انتخاب یا سبک دیگری را بر همان شکل اعمال کنید. برای حذف سایه در حالی که پر و خط مرزی حفظ می‌شوند، از [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) استفاده کنید.

این مثال PHP مستطیل را پس از هر یک از سه مرحلهٔ اول کلون می‌کند تا بتوانید چهار مرحله را به‌صورت کنارهم در یک اسلاید مقایسه کنید. هر دو سایه ۱۰ نقطه جابجا شده‌اند. جهت ۲۲۵° سایهٔ اول را بالای سمت چپ مستطیل قرار می‌دهد و ۴۵° سایهٔ دوم را پایین سمت راست.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| اصلی | پیش تنظیم اول | پیش تنظیم دوم | پس از حذف |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides for PHP via Java می‌توانید انعکاسی مشابه آینه بر روی شکل‌ها اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم نمایید. این افکت ظاهر ارائه‌های شما را با ایجاد شکل‌های صیقلی و شیک ارتقا می‌دهد. با کد ساده قابل پیاده‌سازی است و امکان اعمال سریع بر روی عناصر متعدد برای طراحی سازگار را فراهم می‌کند.

این کد PHP نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) را بر روی یک شکل اعمال کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![افکت انعکاس](reflection_effect.png)

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی بر روی یک شکل در Aspose.Slides for PHP via Java می‌توانید یک هالهٔ نرم و نورانی اطراف شکل‌ها اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم نمایید. این افکت به برجسته شدن شکل‌ها کمک می‌کند و عنصر بصری جذابی به ارائهٔ شما می‌افزاید. با کمترین کد قابل اجراست و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد PHP نشان می‌دهد چگونه [افکت درخشندگی](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) را بر روی یک شکل اعمال کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![افکت درخشندگی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides for PHP via Java می‌توانید یک انتقال صاف و محو در اطراف لبه‌های شکل ایجاد کنید. این افکت ظاهر ملایم‌تر و ظریف‌تری می‌دهد که برای طراحی‌هایی که به ظاهر نرم و لطیف نیاز دارند، مناسب است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر دلخواه را روی انواع شکل‌ها در ارائه‌تان به‌دست آورید.

این کد PHP نشان می‌دهد چگونه [افکت لبه‌های نرم](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) را بر روی یک شکل اعمال کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![افکت لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت محو**

از محو شکل برای نرم کردن پر و خط مرزی یک شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. با فراخوانی [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) بر روی فرمت افکت شکل، شعاع محو (بر حسب نقاط، ۱/۷۲ اینچ) را تنظیم کنید؛ مقدار بزرگتر محو قوی‌تری تولید می‌کند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) مرزهای قابل مشاهدهٔ اثر را کنترل می‌کند. با `false`، محو به مرزهای اصلی کشیده شده محدود می‌شود، شامل خط مرزی. با `true`، محو می‌تواند فراتر از این مرزها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسهٔ زیر با همان پر، خط مرزی و ابعاد شکل در سراسر مثال انجام شده است. ردیف بالایی `grow = false` و ردیف پایینی `grow = true` است.

![مستطیل اصلی مقایسه شده با شعاع‌های تاری 5 و 15 نقطه، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال PHP یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد کرده، محو ۵ نقطه‌ای اعمال می‌کند و سپس با فراخوانی دوباره [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) به محو ۱۵ نقطه تغییر می‌دهد. هر دو حالت محو ذخیره می‌شود، سپس با فراخوانی [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) شکل بدون محو ذخیره می‌شود.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

محو شکل هم پر و هم خط مرزی را به‌هم‌راه تحت تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که محو سایه تنها سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر عمل می‌کند؛ این مثال محو را مستقیماً بر فرمت افکت شکل اعمال می‌کند بدون تبدیل شکل به تصویر.

## **پرسش‌های متداول**

**آیا می‌توانم چند افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد شود.

**به چه شکل‌هایی می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع شکل‌ها اعمال کنید، از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنید. افکت بر روی کل گروه اعمال می‌شود.