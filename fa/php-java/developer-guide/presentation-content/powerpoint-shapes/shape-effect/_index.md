---
title: "اعمال افکت‌های شکل در ارائه‌ها با استفاده از PHP"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/php-java/shape-effect/
keywords:
- "افکت شکل"
- "افکت سایه"
- "افکت انعکاس"
- "افکت درخشندگی"
- "افکت لبه‌های نرم"
- "قالب افکت"
- "PowerPoint"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای PHP از طریق Java تغییر دهید — اسلایدهای چشم‌نوازی و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آنها با [پرکننده‌ها](/slides/fa/php-java/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوتند. با استفاده از افکت‌های PowerPoint، می‌توانید انعکاس‌های قانع‌کننده روی یک شکل ایجاد کنید، درخشندگی شکل را گسترش دهید و غیره.

<img src="shape-effect.png" alt="اثر-شکل" style="zoom:50%;" />

* PowerPoint شش افکت ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر یک شکل اعمال کنید. 
* ترکیب‌های مختلفی از افکت‌ها بهتر از سایرین به نظر می‌رسند. به همین دلیل، گزینه‌های PowerPoint تحت **پیش‌تنظیم**. گزینه‌های پیش‌تنظیم اساساً ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/EffectFormat) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

این کد PHP نشان می‌دهد چگونه افکت سایه خارجی ([OuterShadowEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) را بر روی یک مستطیل اعمال کنید:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اعمال افکت انعکاس**

این کد PHP نشان می‌دهد چگونه افکت انعکاس را بر روی یک شکل اعمال کنید:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اعمال افکت درخشندگی**

این کد PHP نشان می‌دهد چگونه افکت درخشندگی را بر روی یک شکل اعمال کنید:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اعمال افکت لبه‌های نرم**

این کد PHP نشان می‌دهد چگونه لبه‌های نرم را بر روی یک شکل اعمال کنید:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا می‌توانم چند افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد شود.

**چه اشکالی می‌توانم افکت‌ها را بر آنها اعمال کنم؟**

می‌توانید افکت‌ها را بر انواع اشکال شامل اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروهبندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروهبندی‌شده اعمال کنید. افکت بر کل گروه اعمال خواهد شد.