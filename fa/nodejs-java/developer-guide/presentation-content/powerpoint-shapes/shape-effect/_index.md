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
- افکت درخشندگی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل، JavaScript و Aspose.Slides برای Node.js تبدیل کنید—در عرض چند ثانیه اسلایدهای چشم‌گیر و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/nodejs-java/shape-formatting/#gradient-fill) یا خطوط حاشیه متفاوت هستند. با استفاده از افکت‌های PowerPoint، می‌توانید بازتاب‌های واقعی بر روی یک شکل ایجاد کنید، درخشندگی شکل را گسترش دهید و غیره.

![Shape effect](shape-effect.png)

PowerPoint شش افکت را فراهم می‌کند که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که خوب به نظر می‌رسند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Node.js از طریق Java از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را برای هماهنگی با طراحی ارائه خود تنظیم کنید.

### **اعلام سایه خارجی**

از یک سایه خارجی استفاده کنید تا یک کارت یا پنل در مقابل پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل امتداد می‌یابد و حس این را می‌دهد که شکل از اسلاید بالا آمده است. رنگ، جهت، فاصله و شعاع تاری آن را طوری تنظیم کنید که با نورپردازی و سبک قالب شما مطابقت داشته باشد.

این کد JavaScript نشان می‌دهد که چگونه [افکت سایه خارجی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) را به یک مستطیل اعمال کنید:

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

![Shadow effect](shadow_effect.png)

### **اعمال سایه داخلی**

زمانی که می‌خواهید سبک بصری یک قالب را بازآفرینی کنید، از یک سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهر فرورفتگی بدهید. یک سایه خارجی بیرون از شکل گسترش می‌یابد و باعث می‌شود شکل بالا آمده به نظر برسد، در حالی که یک سایه داخلی لبه‌های داخلی را روشن می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) را فراخوانی کنید، سپس سایه برگردانده‌شده توسط [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) را تنظیم کنید. مقادیر بزرگتر شعاع تاری لبه‌های نرم‌تری تولید می‌کنند.

این مثال JavaScript یک کارت آبی روشن با یک سایه داخلی خاکستری تیره ایجاد می‌کند و به‌صورت فایل PPTX ذخیره می‌گردد. جهت سایه ۲۲۵ درجه، فاصله آن ۷ پوینت و شعاع تاری آن ۶ پوینت است:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) را روی فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف سایه پیش‌تنظیم‌شده**

متد [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) را فراخوانی کنید و از [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) استفاده کنید. برای تغییر سبک‌ها، پیش‌تنظیم را بر روی همان شکل تغییر دهید. برای حذف سایه در حالی که پرکننده و خط‌چین حفظ می‌شوند، متد [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) را فراخوانی کنید.

این مثال چهار مرحله را به‌صورت کنار هم در یک اسلاید نشان می‌دهد. هر دو سایه ۱۰ پوینت جابجا شده‌اند. جهت ۲۲۵° سایه اول را بالای سمت چپ مستطیل قرار می‌دهد و ۴۵° سایه دوم را زیر و سمت راست.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| اصلی | پیش‌تنظیم اول | پیش‌تنظیم دوم | پس از حذف |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **اعمال افکت بازتاب**

برای اعمال افکت بازتاب در Aspose.Slides برای Node.js از طریق Java، می‌توانید بازتابی شبیه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به اشکال ارتقاء می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان استفاده سریع در چندین عنصر برای یک طراحی یکدست را فراهم می‌کند.

این کد JavaScript نشان می‌دهد که چگونه [افکت بازتاب](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) را به یک شکل اعمال کنید:

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

![Reflection effect](reflection_effect.png)

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی به یک شکل در Aspose.Slides برای Node.js از طریق Java، می‌توانید هاله‌ای نرم و نورانی دور اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصر بصری جذابی به ارائه شما می‌افزاید. پیاده‌سازی آن با حداقل کد آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد JavaScript نشان می‌دهد که چگونه [افکت درخشندگی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) را به یک شکل اعمال کنید:

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

![Glow effect](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Node.js از طریق Java، می‌توانید یک انتقال صاف و مبهم اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ملایم‌تر و ظریف‌تری می‌دهد که برای طرح‌هایی که به ظاهری ملایم و نرم نیاز دارند مناسب است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را بر روی اشکال مختلف در ارائه خود به‌دست آورید.

این کد JavaScript نشان می‌دهد که چگونه [افکت لبه‌های نرم](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) را به یک شکل اعمال کنید:

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

![Soft edges effect](soft_edges_effect.png)

## **اعمال افکت تاری**

از تاری شکل استفاده کنید تا پرکننده و خط‌چین یک شکل را نرم کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) را روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگتر تاری قوی‌تری ایجاد می‌کنند. شعاع صفر ظاهر را تغییری نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) مرزهای قابل مشاهده افکت را کنترل می‌کند. با `false`، تاری به مرزهای نقاشی اصلی (از جمله خط‌چین) محدود می‌شود. با `true`، تاری می‌تواند فراتر از آن مرزها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکننده، خط‌چین و ابعاد شکل در تمام حالت‌ها استفاده می‌کند. ردیف بالایی `grow = false` است؛ ردیف پایین `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

این مثال JavaScript یک مستطیل نارنجی با خط‌چین آبی تیره ایجاد می‌کند، تاری ۵ پوینتی اعمال می‌کند و سپس با فراخوانی مجدد [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) به تاری ۱۵ پوینت تغییر می‌دهد. هر دو حالت تار شده را ذخیره می‌کند، سپس با فراخوانی [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) شکل را بدون تاری ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تاری شکل هم پرکننده و هم خط‌چین را تحت تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر روی محتوای تصویر اعمال می‌شوند؛ این مثال تاری را مستقیماً روی فرمت افکت شکل بدون تبدیل به تصویر اعمال می‌کند.

## **FAQ**

**آیا می‌توانم چندین افکت را بر روی همان شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد شود.

**کدام اشکال می‌توانم به آن‌ها افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع اشکال از جمله اشکال خودکاری، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی شکل‌های گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی شکل‌های گروهی اعمال کنید. افکت به کل گروه اعمال خواهد شد.