---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از JavaScript
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/nodejs-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت بازتاب
- افکت تابش
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با JavaScript و Aspose.Slides برای Node.js—در چند ثانیه اسلایدهای جذاب و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آنها با [fills](/slides/fa/nodejs-java/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های PowerPoint، می‌توانید بازتاب‌های قانع‌کننده‌ای بر روی یک شکل ایجاد کنید، تابش شکل را پخش کنید و غیره.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint شش افکت مختلف را برای اعمال بر روی اشکال فراهم می‌کند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید. 

* برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، گزینه‌های PowerPoint تحت **Preset** قرار دارند. گزینه‌های Preset در واقع ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/EffectFormat) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

این کد JavaScript نشان می‌دهد چگونه افکت سایه خارجی ([getOuterShadowEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) را بر روی یک مستطیل اعمال کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اعمال افکت بازتاب**

این کد JavaScript نشان می‌دهد چگونه افکت بازتاب را بر روی یک شکل اعمال کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اعمال افکت تابش**

این کد JavaScript نشان می‌دهد چگونه افکت تابش را بر روی یک شکل اعمال کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اعمال افکت لبه‌های نرم**

این کد JavaScript نشان می‌دهد چگونه لبه‌های نرم را بر روی یک شکل اعمال کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤالات متداول**

**آیا می‌توانم چند افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و تابش را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد شود.

**به چه شکل‌هایی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی اشکال مختلفی مانند اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و غیره اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروهی اعمال کنید. افکت بر روی کل گروه اعمال خواهد شد.