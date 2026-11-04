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
- افکت تابش
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای PHP از طریق Java تبدیل کنید — اسلایدهای جذاب و حرفه‌ای را در ثانیه‌ها تولید کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، از [پرکننده‌ها](/slides/fa/php-java/shape-formatting/#gradient-fill) یا خطوط دور متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قانع‌کننده روی یک شکل ایجاد کنید، تابش شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت را ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که ظاهر خوبی دارند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نیست.

Aspose.Slides ویژگی‌ها و متدهایی را تحت کلاس [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for PHP via Java پشتیبانی از سایه‌های خارجی و داخلی برای اشکال را فراهم می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را طوری تنظیم کنید که با طراحی ارائه شما هماهنگ باشد.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته کردن یک کارت یا پنل در مقابل پس‌زمینه اسلاید استفاده کنید. این سایه فراتر از لبه‌های شکل گسترش می‌یابد و این حس را ایجاد می‌کند که شکل بالاتر از اسلاید قرار دارد. رنگ، جهت، فاصله و شعاع تاری آن را طوری تنظیم کنید که با نورپردازی و سبک قالب شما سازگار باشد.

این کد PHP نشان می‌دهد چگونه [افکت سایه بیرونی](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) را به یک مستطیل اعمال کنید:

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

### **اعمال سایه داخلی**

هنگام بازآفرینی سبک بصری یک قالب، از سایه داخلی برای ایجاد ظاهر فرو رفته یک کارت یا پنل استفاده کنید. سایه بیرونی خارج از شکل گسترش می‌یابد و آن را بالا می‌آورد، در حالی که سایه داخلی لبه‌های داخلی را تیره می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) را فراخوانی کنید، سپس سایه بازگردانده‌شده توسط [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) را پیکربندی کنید. مقادیر بزرگتر شعاع تاری، لبه‌های نرم‌تری تولید می‌کنند.

این مثال PHP یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌عنوان فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه، فاصله‌اش ۷ پوینت و شعاع تاری‌اش ۶ پوینت است:

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

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides for PHP via Java، می‌توانید انعکاس شبیه آینه را به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت ظاهر ارائه شما را با دادن ظاهری صیقلی و پیشرفته به اشکال بهبود می‌بخشد. پیاده‌سازی آن به‌راسطه کد ساده آسان است و امکان اعمال سریع بر روی عناصر متعدد برای یک طراحی یکدست را فراهم می‌کند.

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

برای اعمال افکت تابش به یک شکل در Aspose.Slides for PHP via Java، می‌توانید هاله‌ای نرم و درخشان دور اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن شکل‌ها کمک می‌کند و عنصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

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

برای اعمال افکت لبه‌های نرم در Aspose.Slides for PHP via Java، می‌توانید انتقالی صاف و مبهم در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ملایم‌تری می‌بخشد که برای طراحی‌هایی که نیاز به ظاهری ملایم و نرم دارند، ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را بر روی انواع شکل‌ها در ارائه خود اعمال کنید.

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

از تاری شکل برای نرم کردن پرکننده و خطوط دور شکل استفاده کنید و در عین حال شکل قابل ویرایش باقی بماند. متد [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) را بر روی فرمت افکت شکل صدا بزنید. شعاع به پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر تاری قوی‌تری ایجاد می‌کنند. شعاع صفر ظاهر را بدون تغییر می‌گذارد.

تنظیم [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) مرزهای قابل مشاهده افکت را کنترل می‌کند. با `false`، تاری به مرزهای رنگ‌شده اصلی، از جمله خط دور، محدود می‌شود. با `true`، تاری می‌تواند فراتر از آن مرزها گسترش یابد. هیچ‌کدام از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکننده، خط دور و ابعاد شکل در کل استفاده می‌کند. ردیف بالایی از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true`.

![مستطیل اصلی مقایسه شده با شعاع‌های تاری ۵ و ۱۵ پوینت، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال PHP یک مستطیل نارنجی با خط دور آبی تیره ایجاد می‌کند، تاری ۵ پوینتی اعمال می‌کند و سپس آن را به تاری ۱۵ پوینتی به‌روزرسانی می‌کند با فراخوانی مجدد [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). هر دو حالت تاری را ذخیره می‌کند، سپس متد [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) را صدا می‌زند و شکل را بدون تاری ذخیره می‌کند.

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

تاری شکل هم پرکننده و هم خط دور را به‌همین‌صورت تحت‌تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌سازد. افکت‌های تبدیل تصویر بر محتوای تصویر اعمال می‌شوند؛ این مثال تاری را مستقیماً بر فرمت افکت شکل بدون تبدیل به تصویر اعمال می‌کند.

## **سؤال‌های متداول**

**آیا می‌توانم چند افکت را بر روی همان شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و تابش را بر روی یک شکل ترکیب کنید تا ظاهر دینامیک‌تری ایجاد شود.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع اشکال، از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی‌شده اعمال کنید. افکت به کل گروه اعمال خواهد شد.