---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از PHP
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/php-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت بازتاب
- افکت درخشندگی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با افکت‌های پیشرفته شکل با استفاده از Aspose.Slides برای PHP از طریق Java تبدیل کنید—اسلایدهای حرفه‌ای و چشم‌نوازی را در چند ثانیه ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آن‌ها متفاوت از [پرکننده‌ها](/slides/fa/php-java/shape-formatting/#gradient-fill) یا خطوط مرزی هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، درخشندگی شکل را منتشر کنید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت را فراهم می‌کند که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که ظاهر خوبی دارند. بدین ترتیب، با انتخاب یک preset دیگر نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای PHP از طریق Java از سایه‌های بیرونی و درونی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو آنها را به‌گونه‌ای تنظیم کنید که با طراحی ارائه شما مطابقت داشته باشد.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته‌کردن یک کارت یا پنل در مقابل پس‌زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و حس این را می‌دهد که شکل بالای اسلاید بلند شده است. رنگ، جهت، فاصله و شعاع محو آن را تنظیم کنید تا با نورپردازی و سبک قالب شما هماهنگ شود.

این کد PHP نشان می‌دهد چگونه [اثر سایه بیرونی](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) را روی یک مستطیل اعمال کنید:

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

### **اعمال سایه درونی**

هنگامی که می‌خواهید سبک بصری یک قالب را بازتولید کنید، از سایه درونی برای دادن ظاهر فرو رفته به یک کارت یا پنل استفاده کنید. سایه بیرونی خارج از شکل گسترش می‌یابد و آن را بلند نشان می‌دهد، در حالی که سایه درونی داخل لبه‌های آن را سایه می‌زند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) را فراخوانی کنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) برگردانده می‌شود را پیکربندی کنید. مقادیر بزرگتر شعاع محو لبه‌های نرم‌تر تولید می‌کنند.

این مثال PHP یک کارت آبی روشن با سایه درونی خاکستری تیره ایجاد می‌کند و آن را به‌صورت فایل PPTX ذخیره می نماید. جهت سایه ۲۲۵ درجه است، فاصله آن ۷ پوینت و شعاع محو ۶ پوینت می‌باشد:

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

![مستطیل آبی روشن با سایه درونی](inner_shadow_effect.png)

برای حذف سایه درونی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) را بر روی قالب افکت شکل فراخوانی کنید.

## **اعمال افکت بازتاب**

برای اعمال افکت بازتاب در Aspose.Slides برای PHP از طریق Java، می‌توانید بازتابی شبیه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را ارتقا می‌دهد و به اشکال ظاهری صیقلی‌تر و متین‌تر می‌بخشد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع بر روی عناصر متعدد برای یک طراحی یکنواخت را فراهم می‌کند.

این کد PHP نشان می‌دهد چگونه [اثر بازتاب](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) را بر روی یک شکل اعمال کنید:

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

![اثر بازتاب](reflection_effect.png)

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی بر روی یک شکل در Aspose.Slides برای PHP از طریق Java، می‌توانید هالویی نرم و نورانی اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته‌کردن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کم آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد PHP نشان می‌دهد چگونه [اثر درخشندگی](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) را بر روی یک شکل اعمال کنید:

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

![اثر درخشندگی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای PHP از طریق Java، می‌توانید یک انتقال صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری لطیف‌تر و پالوده‌تر اضافه می‌کند که برای طرح‌هایی که به ظاهر ملایم و نرم نیاز دارند ایده‌آل است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت موردنظر را بر روی اشکال مختلف در ارائه خود به‌دست آورید.

این کد PHP نشان می‌دهد چگونه [اثر لبه‌های نرم](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) را بر روی یک شکل اعمال کنید:

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

![اثر لبه‌های نرم](soft_edges_effect.png)

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی همان شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد کنید.

**بر روی چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی اشکال مختلفی از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و غیره اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنید. افکت بر کل گروه اعمال خواهد شد.