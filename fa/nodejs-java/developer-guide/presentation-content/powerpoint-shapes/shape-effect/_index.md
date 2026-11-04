---
title: "اعمال افکت‌های شکل در ارائه‌ها با استفاده از جاوااسکریپت"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/nodejs-java/shape-effect/
keywords:
- "افکت شکل"
- "افکت سایه"
- "افکت انعکاس"
- "افکت درخشندگی"
- "افکت لبه‌های نرم"
- "قالب افکت"
- "PowerPoint"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با جاوااسکریپت و Aspose.Slides برای Node.js تبدیل کنید — اسلایدهای جذاب و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آنها متفاوت از [پرکننده‌ها](/slides/fa/nodejs-java/shape-formatting/#gradient-fill) یا خطوط مرزی هستند. با استفاده از افکت‌های PowerPoint، می‌توانید بازتاب‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، تابش شکل را گسترش دهید و غیره.

![افکت شکل](shape-effect.png)

PowerPoint شش افکت را ارائه می‌دهد که می‌توانند به شکل‌ها اعمال شوند. می‌توانید یک یا چند افکت را بر یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که خوب به نظر می‌آیند. به این ترتیب، با انتخاب یک پیش تنظیم، نیازی به هدر دادن زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و روش‌هایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر شکل‌های ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Node.js از طریق Java از سایه‌های خارجی و داخلی برای شکل‌ها پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را متناسب با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه خارجی**

از سایه خارجی استفاده کنید تا یک کارت یا پنل در برابر پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل گسترش می‌یابد و حس اینکه شکل بالای اسلاید بلند شده است را ایجاد می‌کند. رنگ، جهت، فاصله و شعاع تاری آن را متناسب با نوردهی و سبک قالب خود تنظیم کنید.

این کد JavaScript نشان می‌دهد چگونه [افکت سایه خارجی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) را بر یک مستطیل اعمال کنید:
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

هنگام بازسازی سبک بصری یک قالب، از سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهری فرو رفته بدهید. یک سایه خارجی خارج از شکل گسترش می‌یابد و آن را بالا می‌آورد، در حالی که یک سایه داخلی داخل لبه‌های شکل را سایه‌دار می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) را فراخوانی کنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) برگردانده می‌شود را پیکربندی کنید. مقادیر بزرگتر شعاع تاری لبه‌های نرم‌تری تولید می‌کنند.

این مثال JavaScript یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و به صورت فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه، فاصله آن ۷ پوینت و شعاع تاری آن ۶ پوینت است:
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

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) را بر قالب اثر شکل فراخوانی کنید.

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Node.js از طریق Java، می‌توانید یک انعکاس شبیه آینه به شکل‌ها اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت ظاهر زیباشناختی ارائه‌های شما را با ارائه شکل‌ها به شکلی صیقلی و پیشرفته بهبود می‌بخشد. با کد ساده به راحتی قابل پیاده‌سازی است و امکان اعمال سریع بر روی چندین عنصر برای یک طراحی یکنواخت را فراهم می‌کند.

این کد JavaScript نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) را بر یک شکل اعمال کنید:
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

## **اعمال افکت درخشش**

برای اعمال افکت درخشش به یک شکل در Aspose.Slides برای Node.js از طریق Java، می‌توانید هاله‌ای نرم و روشن دور شکل‌ها اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته کردن شکل‌ها کمک می‌کند و عنصر بصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. با کد کم قابل پیاده‌سازی است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد JavaScript نشان می‌دهد چگونه [افکت درخشش](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) را بر یک شکل اعمال کنید:
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

![افکت درخشش](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Node.js از طریق Java، می‌توانید یک انتقال صاف و محو در اطراف لبه‌های شکل ایجاد کنید. این افکت ظاهر نرم‌تر و براق‌تری می‌بخشد که برای طراحی‌هایی که به ظاهر ملایم و نرم نیاز دارند ایده‌آل است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را در شکل‌های مختلف ارائه خود به دست آورید.

این کد JavaScript نشان می‌دهد چگونه [افکت لبه‌های نرم](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) را بر یک شکل اعمال کنید:
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

## **اعمال افکت تاری**

از تاری شکل استفاده کنید تا پرکننده و خط‌مرز شکل را نرم کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) را بر قالب اثر شکل صدا بزنید. شعاع در پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید، مقادیر بزرگتر تاری قوی‌تری تولید می‌کنند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) محدوده دیده‌شدنی افکت را کنترل می‌کند. با مقدار `false`، تاری به مرزهای رنگ‌آمیزی اولیه، شامل خطوط مرزی، محدود می‌شود. با مقدار `true`، تاری می‌تواند فراتر از این مرزها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهد.

مقایسه زیر از همان پرکننده، خط‌مرز و ابعاد شکل در تمام موارد استفاده می‌کند. ردیف بالایی از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true` استفاده می‌کند.

![مستطیل اصلی مقایسه‌شده با شعاع‌های تاری ۵ و ۱۵ پوینت، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال JavaScript یک مستطیل نارنجی با خط‌مرز آبی تیره ایجاد می‌کند، تاری ۵ پوینتی اعمال می‌نماید و سپس با فراخوانی مجدد [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) آن را به تاری ۱۵ پوینتی به‌روز می‌کند. هر دو حالت تاری را ذخیره می‌کند، سپس متد [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) را صدا می‌زند و شکل را بدون تاری ذخیره می‌کند.
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

تاری شکل همزمان بر پرکننده و خط‌مرز تأثیر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه تنها سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر اعمال می‌شوند؛ این مثال تاری را مستقیماً بر قالب اثر شکل بدون تبدیل شکل به تصویر اعمال می‌کند.

## **FAQ**

**آیا می‌توانم چندین افکت را بر یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشش را بر یک شکل ترکیب کنید تا ظاهر دینامیک‌تری به دست آورید.

**کدام شکل‌ها را می‌توانم افکت‌ها به آن‌ها اعمال کنم؟**

می‌توانید افکت را بر شکل‌های مختلفی مانند اشکال خودکار، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و غیره اعمال کنید.

**آیا می‌توانم افکت‌ها را بر شکل‌های گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت را بر شکل‌های گروه‌بندی‌شده اعمال کنید. افکت بر کل گروه اعمال خواهد شد.