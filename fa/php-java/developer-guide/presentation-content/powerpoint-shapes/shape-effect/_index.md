---
title: "اعمال افکت‌های شکل در ارائه‌ها با استفاده از PHP"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/php-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت تابش
- افکت لبه‌های نرم
- قالب افکت
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای PHP از طریق Java تبدیل کنید—اسلایدهای برجسته و حرفه‌ای را در چند ثانیه ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته‌سازی یک شکل استفاده شوند، متفاوت از [پرکردن](/slides/fa/php-java/shape-formatting/#gradient-fill) یا خطوط حاشیه‌ای هستند. با استفاده از افکت‌های پاورپوینت، می‌توانید بازتاب‌های قانع‌کننده‌ای روی شکل ایجاد کنید، درخشندگی شکل را گسترش دهید، و غیره.

![اثر شکل](shape-effect.png)

پاورپوینت شش افکت ارائه می‌دهد که می‌توان به اشکال اعمال کرد. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که ظاهر خوبی داشته باشند. به این ترتیب، با انتخاب یک پیش تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را به اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای PHP از طریق Java از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را مطابق با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته‌کردن یک کارت یا پنل در برابر زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و حس اینکه شکل بالای اسلاید بلند شده است را ایجاد می‌کند. رنگ، جهت، فاصله و شعاع تاری آن را مطابق با نورپردازی و استایل قالب خود تنظیم کنید.

این کد PHP نشان می‌دهد چگونه [اثر سایه خارجی](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) را به یک مستطیل اعمال کنید:

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

![اثر سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازتولید استایل بصری یک قالب، از سایه داخلی برای ایجاد ظاهر فرو رفته یک کارت یا پنل استفاده کنید. سایه خارجی خارج از شکل گسترش می‌یابد و آن را بالا رفته نشان می‌دهد، در حالی که سایه داخلی درونی لبه‌های آن را سایه‌دار می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) را فراخوانی کنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) بازگردانده می‌شود را پیکربندی کنید. مقادیر بزرگ‌تر شعاع تاری لبه‌های نرم‌تری تولید می‌کنند.

این مثال PHP یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌عنوان فایل PPTX ذخیره می‌کند. جهت سایه ۲۲۵ درجه است، فاصله آن ۷ پوینت و شعاع تاری ۶ پوینت می‌باشد:

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

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) را بر روی فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف سایه پیش تنظیم**

برای فعال کردن یک سایه پیش تنظیم، متد [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) را فراخوانی کنید. برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) یا تغییر به سبک دیگر روی همان شکل، از [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) استفاده کنید. برای حذف سایه در حالی که پرکردن و خطوط حاشیه‌ای حفظ می‌شوند، متد [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) را فراخوانی کنید.

این مثال PHP مستطیل را پس از هر یک از سه مرحله اول تکثیر می‌کند تا بتوانید تمام چهار مرحله را به‌صورت کنار هم روی یک اسلاید مقایسه کنید. هر دو سایه با ۱۰ پوینت جابجا شده‌اند. جهت ۲۲۵° سایه اول را بالای مستطیل و به سمت چپ قرار می‌دهد، و ۴۵° سایه دوم را زیر مستطیل و به سمت راست قرار می‌دهد.

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
| ![بدون سایه](preset_shadow_original.png) | ![سایه بالا چپ](preset_shadow_top_left.png) | ![سایه پایین راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای PHP از طریق Java، می‌توانید بازتابی مشابه آینه را به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با ارائه ظاهر صیقلی‌تر و پیشرفته‌تر به اشکال ارتقا می‌دهد. با کد ساده می‌توان به‌راحتی آن را پیاده‌سازی کرد و اعمال سریع بر روی چندین عنصر برای یک طراحی یکپارچه را امکان‌پذیر می‌سازد.

این کد PHP نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) را به یک شکل اعمال کنید:

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

## **اعمال افکت تابش**

برای اعمال افکت تابش به یک شکل در Aspose.Slides برای PHP از طریق Java، می‌توانید هاله‌ای نرم و درخشان دور اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی را به ارائه شما اضافه می‌نماید. با کد کم می‌توان آن را به‌سادگی پیاده‌سازی کرد و ظاهر کلی اسلایدهایتان را بهبود می‌بخشد.

این کد PHP نشان می‌دهد چگونه [افکت تابش](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) را به یک شکل اعمال کنید:

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

![افکت تابش](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای PHP از طریق Java، می‌توانید انتقالی صاف و تاری در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری ظریف‌تر و برازنده‌تر می‌آورد که برای طرح‌هایی که به ظاهر ملایم و نرم نیاز دارند، ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را بر روی اشکال مختلف در ارائه خود به‌دست آورید.

این کد PHP نشان می‌دهد چگونه [افکت لبه‌های نرم](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) را به یک شکل اعمال کنید:

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

## **اعمال افکت تاری**

از تاری شکل برای نرم‌کردن پرکردن و خطوط حاشیه‌ای یک شکل استفاده کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) را بر روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شود: از مقداری غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر تاری قوی‌تری ایجاد می‌کنند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیمات [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) مرزهای قابل مشاهدهٔ افکت را کنترل می‌کند. با مقدار `false`، تاری به مرزهای اولیهٔ نقاشی شده، شامل خطوط حاشیه‌ای، محدود می‌شود. با مقدار `true`، تاری می‌تواند فراتر از این مرزها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکردن، خطوط حاشیه‌ای و ابعاد شکل در تمام مراحل استفاده می‌کند. ردیف بالا از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true` استفاده می‌کند.

![مستطیل اصلی مقایسه شده با شعاع‌های تاری 5 و 15 پوینت، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال PHP یک مستطیل نارنجی با خطوط حاشیه‌ای آبی تیره ایجاد می‌کند، تاری 5 پوینتی را اعمال می‌نماید و سپس با فراخوانی دوباره [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) آن را به تاری 15 پوینتی به‌روزرسانی می‌کند. هر دو حالت تاری ذخیره می‌شوند، سپس متد [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) فراخوانی می‌شود و شکل بدون تاری ذخیره می‌گردد.

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

تاری شکل بر روی پرکردن و خطوط حاشیه‌ای به‌صورت همزمان اثر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر روی محتوای تصویر عمل می‌کنند؛ این مثال تاری را به‌طور مستقیم بر فرمت افکت شکل اعمال می‌کند بدون آن‌که شکل به تصویر تبدیل شود.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را به یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلف مانند سایه، انعکاس و تابش را روی یک شکل ترکیب کنید تا ظاهری پویاتر به‌دست آورید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را به اشکال مختلفی از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را به اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را به اشکال گروهی اعمال کنید. افکت بر تمام گروه اعمال خواهد شد.