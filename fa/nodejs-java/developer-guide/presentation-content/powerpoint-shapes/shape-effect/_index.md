---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از JavaScript
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/nodejs-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت درخشانی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از JavaScript و Aspose.Slides برای Node.js و افکت‌های پیشرفته شکل تبدیل کنید—در چند ثانیه اسلایدهای چشم‌نوازی و حرفه‌ای ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/nodejs-java/shape-formatting/#gradient-fill) یا خطوط خارجی متفاوت هستند. با استفاده از افکت‌های پاورپوینت می‌توانید انعکاس‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، تابش شکل را گسترش دهید و غیره.

![افکت شکل](shape-effect.png)

پاورپوینت شش افکت ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. شما می‌توانید یک یا چند افکت را روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که به‌نظر خوب می‌آیند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و روش‌هایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Node.js از طریق Java از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تار شدن آن‌ها را برای مطابقت با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته کردن یک کارت یا پنل در مقابل پس‌زمینه اسلاید استفاده کنید. سایه خارج از لبه‌های شکل گسترش می‌یابد و این impression را ایجاد می‌کند که شکل بالای اسلاید قرار دارد. رنگ، جهت، فاصله و شعاع تار شدن آن را برای مطابقت با نورپردازی و سبک قالب خود تنظیم کنید.

این کد JavaScript نشان می‌دهد چگونه [افکت سایه بیرونی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) را بر روی یک مستطیل اعمال کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![افکت سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازتولید سبک بصری یک قالب، از سایه داخلی برای ایجاد ظاهر فرو رفته یک کارت یا پنل استفاده کنید. سایه بیرونی خارج از شکل گسترش می‌یابد و آن را به‌نظر می‌آورد که برجسته است، در حالی که سایه داخلی داخل لبه‌های شکل را سایه می‌اندازد.

Call [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), then configure the shadow returned by [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Larger blur radius values produce softer edges.

این مثال JavaScript یک کارت رنگ آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌عنوان یک فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه است، فاصله آن ۷ نقطه و شعاع تار شدن ۶ نقطه می‌باشد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![مستطیل آبی روشن با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) را بر روی فرمت افکت شکل صدا بزنید.

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Node.js از طریق Java، می‌توانید انعکاس شبیه آینه‌ای را به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم نمایید. این افکت زیبایی ارائه‌های شما را با ارائه ظاهر صیقلی و پیشرفته به اشکال ارتقاء می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع در چندین عنصر برای طراحی یکدست را فراهم می‌کند.

این کد JavaScript نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) را به یک شکل اعمال کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![افکت انعکاس](reflection_effect.png)

## **اعمال افکت درخشانی**

برای اعمال افکت درخشانی بر روی یک شکل در Aspose.Slides برای Node.js از طریق Java، می‌توانید هاله‌ای نرم و روشن دور اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم نمایید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد JavaScript نشان می‌دهد چگونه [افکت درخشانی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) را به یک شکل اعمال کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![افکت درخشانی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Node.js از طریق Java، می‌توانید انتقالی نرم و مبهم در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری ظریف‌تر و صیقلی‌تر می‌بخشد که برای طرح‌هایی که نیاز به ظاهر ملایم و نرم دارند، ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت مطلوب را در اشکال مختلف ارائه خود به‌دست آورید.

این کد JavaScript نشان می‌دهد چگونه [افکت لبه‌های نرم](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) را به یک شکل اعمال کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![افکت لبه‌های نرم](soft_edges_effect.png)

## **سوالات متداول**

**آیا می‌توانم چندین افکت را به یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشانی را بر روی یک شکل ترکیب کنید تا ظاهری پویا‌تر ایجاد کنید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع اشکال اعمال کنید، از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر.

**آیا می‌توانم افکت‌ها را به شکل‌های گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را به شکل‌های گروهی اعمال کنید. افکت بر کل گروه اعمال خواهد شد.