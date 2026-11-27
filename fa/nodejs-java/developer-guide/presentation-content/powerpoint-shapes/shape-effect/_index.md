---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/nodejs-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت نوردهی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js و افکت‌های پیشرفته شکل تبدیل کنید - در عرض چند ثانیه اسلایدهای حرفه‌ای و چشم‌نوازی ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/nodejs-java/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قانع‌کننده‌ای بر روی یک شکل ایجاد کنید، نور درخشانی شکل را گسترش دهید، و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت را در اختیار می‌گذارد که می‌توانند بر روی شکل‌ها اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیبات افکت‌ها بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **پیش تنظیم** ارائه می‌دهد. گزینه‌های پیش تنظیم ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که خوش‌ظاهر باشند. به این ترتیب، با انتخاب یک پیش تنظیم، نیازی به صرف زمان برای تست یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر روی شکل‌ها در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Node.js از طریق Java از سایه‌های خارجی و داخلی برای شکل‌ها پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو شدن آنها را برای مطابقت با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه خارجی**

از سایه خارجی استفاده کنید تا یک کارت یا پنل نسبت به پس‌زمینه اسلاید برجسته شود. سایه خارج از لبه‌های شکل گسترش می یابد و حس اینکه شکل بر روی اسلاید بالا کشیده شده است را ایجاد می‌کند. رنگ، جهت، فاصله و شعاع محو آن را برای مطابقت با نورپردازی و سبک قالب خود تنظیم کنید.

این کد JavaScript نشان می‌دهد چگونه افکت [سایه خارجی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) را بر روی یک مستطیل اعمال کنید:

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

![اثر سایه](shadow_effect.png)

#### **کنترل جهت سایه هنگام چرخش شکل**

به طور پیش‌فرض، سایه خارجی همراه با شکل می‌چرخد. برای اینکه شکل‌های با چرخش‌های مختلف از همان جهت نورانی به نظر برسند، متد [setRotateShadowWithShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setRotateShadowWithShape) را با مقدار `false` صدا بزنید و از [setDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setDirection) برای دادن جهت یکسان به سایه‌های آنها استفاده کنید.

این مثال دو پیکان آبی با سایه‌های خاکستری که ۴۲ پوینت به سمت راست جابجا شده‌اند (0°) ایجاد می‌کند. سپس اسلاید را کپی می‌کند و هر دو پیکان را ۹۰° به صورت ساعت‌گرد می‌چرخاند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const before = presentation.getSlides().get_Item(0);
    
    const left = before.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    left.getFillFormat().getSolidFillColor().setColor(fillColor);
    left.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    left.getEffectFormat().enableOuterShadowEffect();
    const shadow = left.getEffectFormat().getOuterShadowEffect();
    const shadowColor = java.getStaticFieldValue("java.awt.Color", "GRAY");
    shadow.getShadowColor().setColor(shadowColor);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    const right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    const after = presentation.getSlides().addClone(before);
    const arrows = after.getShapes();
    for (let i = 0; i < arrows.size(); i++) {
        arrows.get_Item(i).setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در اسلاید دوم، پیکان سمت چپ سایه‌اش را به سمت پایین می‌اندازد، در حالی که پیکان سمت راست همچنان سایه‌اش را به سمت راست می‌اندازد. جهت تنظیم‌شده برای هر دو سایه ۰° باقی می‌ماند.

![رندر PowerPoint قبل و بعد از چرخش 90°. هر دو سایه از سمت راست شروع می‌شوند. پس از چرخش، سایه به زیر پیکان چپ منتقل می‌شود و در سمت راست پیکان راست می‌ماند.](arrow-shadow-rotation.png)

### **اعمال سایه داخلی**

هنگام بازتولید سبک بصری قالب، از سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهری فرورفته بدهید. سایه خارجی خارج از شکل گسترش می‌یابد و باعث می‌شود شکل بالا کشیده به نظر برسد، در حالی که سایه داخلی داخل لبه‌های آن را سایه می‌اندازد.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) را صدا بزنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) برگردانده می‌شود را پیکربندی کنید. مقادیر بزرگ‌تر شعاع محو، لبه‌های نرم‌تری تولید می‌کنند.

این مثال JavaScript یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و به صورت فایل PPTX ذخیره می‌شود. جهت سایه ۲۲۵ درجه است، فاصله آن ۷ پوینت و شعاع محو ۶ پوینت می‌باشد:

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

### **اعمال، تغییر و حذف سایه پیش تنظیم**

متد [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) را صدا بزنید و از [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) استفاده کنید. برای تغییر سبک، پیش تنظیم را بر روی همان شکل تغییر دهید. برای حذف سایه در حالی که پرکننده و خط مرزی حفظ می‌شود، متد [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) را صدا بزنید.

این مثال چهار مرحله را به صورت در کنار هم در یک اسلاید نشان می‌دهد. هر دو سایه ۱۰ پوینت جابجا شده‌اند. جهت ۲۲۵° سایه اول را بالای مستطیل و سمت چپ قرار می‌دهد، در حالی که ۴۵° سایه دوم را زیر و سمت راست قرار می‌دهد.

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

| اصل | پیش تنظیم اولین | پیش تنظیم دوم | پس از حذف |
| :---: | :---: | :---: | :---: |
| ![بدون سایه](preset_shadow_original.png) | ![سایه بالا چپ](preset_shadow_top_left.png) | ![سایه پایین راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Node.js از طریق Java، می‌توانید یک انعکاس شبیه آینه به شکل‌ها اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به شکل‌ها ارتقا می‌دهد. با کد ساده به راحتی قابل پیاده‌سازی است و امکان اعمال سریع بر روی عناصر متعدد برای طراحی یکسان را فراهم می‌کند.

این کد JavaScript نشان می‌دهد چگونه افکت [انعکاس](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) را بر روی یک شکل اعمال کنید:

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

![اثر انعکاس](reflection_effect.png)

## **اعمال افکت نوردهی**

برای اعمال افکت نوردهی به یک شکل در Aspose.Slides برای Node.js از طریق Java، می‌توانید هاله‌ای نرم و درخشان اطراف شکل‌ها اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن شکل‌ها کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. با کد کم به راحتی قابل پیاده‌سازی است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد JavaScript نشان می‌دهد چگونه افکت [نوردهی](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) را بر روی یک شکل اعمال کنید:

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

![اثر نوردهی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Node.js از طریق Java، می‌توانید یک انتقال صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری دقیق‌تر و ملایم‌تر اضافه می‌کند که برای طرح‌هایی که نیاز به ظاهر ملایم و نرم دارند، ایده‌آل است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت مورد نظر را بر روی شکل‌های مختلف در ارائه خود به دست آورید.

این کد JavaScript نشان می‌دهد چگونه افکت [لبه‌های نرم](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) را بر روی یک شکل اعمال کنید:

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

![اثر لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت به‌محو کردن**

از به‌محو کردن شکل استفاده کنید تا پرکننده و خط مرزی شکل را نرم کنید در حالی که شکل قابل ویرایش می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) را بر روی فرمت افکت شکل صدا بزنید. شعاع بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر محو قوی‌تری ایجاد می‌کنند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) مرزهای قابل مشاهده افکت را کنترل می‌کند. با مقدار `false`، محو شدن به مرزهای اولیه نقاشی شده، شامل خط مرزی، محدود می‌شود. با مقدار `true`، محو می‌تواند فراتر از آن مرزها گسترش یابد. هیچ‌کدام از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکننده، خط مرزی و ابعاد شکل در کل استفاده می‌کند. ردیف بالا `grow = false` را به کار می‌برد؛ ردیف پایین `grow = true` را به کار می‌برد.

![مستطیل اصلی مقایسه‌شده با شعاع‌های محو 5 و 15 پوینت، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال JavaScript یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، یک محو ۵ پوینت اعمال می‌کند و سپس با صدا زدن مجدد [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) آن را به محو ۱۵ پوینت به‌روز می‌کند. هر دو حالت محو را ذخیره می‌کند، سپس متد [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) را فراخوانی کرده و شکل را بدون محو ذخیره می‌کند.

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

به‌محو کردن شکل همزمان بر روی پرکننده و خط مرزی اثر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که محو سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر عمل می‌کنند؛ این مثال محو را به طور مستقیم بر روی فرمت افکت شکل اعمال می‌کند بدون اینکه شکل به تصویر تبدیل شود.

## **پرسش‌های متداول**

**آیا می‌توانم چندین افکت را بر روی همان شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و نوردهی را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد شود.

**به چه شکل‌هایی می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع شکل‌ها اعمال کنید، از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و غیره.

**آیا می‌توانم افکت‌ها را بر روی شکل‌های گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی شکل‌های گروهی اعمال کنید. افکت بر کل گروه اعمال خواهد شد.