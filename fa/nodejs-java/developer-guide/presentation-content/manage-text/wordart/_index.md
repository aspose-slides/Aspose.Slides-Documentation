---
title: ایجاد و اعمال افکت‌های WordArt در Node.js
linktitle: WordArt
type: docs
weight: 110
url: /fa/nodejs-java/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- افکت WordArt
- افکت سایه
- افکت بازتاب
- افکت نوردهی
- تبدیل WordArt
- افکت ۳بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Node.js از طریق Java. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در Node.js بهبود دهند."
---
## **بررسی کلی**

افکت‌های WordArt به شما امکان می‌دهند متن را با پرکننده‌ها، خطوط دور، سایه‌ها، بازتاب‌ها، نوردهی، تبدیل‌ها و قالب‌بندی‌های سه‌بعدی استایل بدهید. این مقاله توضیح می‌دهد چگونه می‌توان این افکت‌ها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Node.js via Java، بدون نصب Microsoft Office، ایجاد و سفارشی کرد.

## **ایجاد یک قالب WordArt ساده و اعمال آن روی متن**

مثال‌های زیر یک سبک WordArt ساده را با تنظیم متن، فونت، پرکننده الگو و خطوط دور می‌سازند.

هر مثال یک ارائه جدید ایجاد می‌کند و یک مستطیل به اسلاید اول آن اضافه می‌کند؛ نیازی به فایل ورودی نیست. مثال اول متن را روی «Aspose.Slides» تنظیم می‌کند. موقعیت و ابعاد شکل بر حسب نقطه اندازه‌گیری می‌شود:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

فونت را به Arial Black با اندازه ۳۶ نقطه تنظیم کنید تا قالب‌بندی واضح‌تر باشد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

یک الگوی [SmallGrid](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/patternstyle/#SmallGrid) با پیش‌زمینه نارنجی تیره و پس‌زمینه سفید اعمال کنید، سپس یک خط دور متن سیاه با عرض ۱ نقطه اضافه کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

متن حاصل:

![قالب ساده WordArt](WordArt_template.png)

## **اعمال دیگر افکت‌های WordArt**

مثال‌های زیر نشان می‌دهند چگونه می‌توان سایه‌ها، بازتاب‌ها، نوردهی، تبدیل‌ها و افکت‌های سه‌بعدی را روی متن اعمال کرد.

### **اعمال افکت‌های سایه خارجی**

یک سایه خارجی عمق بیشتری ایجاد می‌کند با قرار دادن سایه‌ای پشت متن. می‌توانید رنگ، جهت، فاصله، شعاع تاری، مقیاس و کشیدگی آن را سفارشی کنید.

این مثال متد [enableOuterShadowEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) را فراخوانی می‌کند و یک سایه سیاه با شعاع تاری ۴ نقطه، جهت ۲۳۰ درجه و فاصله ۳۰ نقطه تنظیم می‌کند. مقادیر مقیاس ۱۰۰ سایه را حفظ می‌کنند، در حالی که کشیدگی افقی آن را ۲۰ درجه می‌چرخاند. تبدیل آلفا شفافیت را به ۳۲٪ تنظیم می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

متن حاصل:

![افکت سایه خارجی](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- وقتی سایه‌های خارجی و پیش‌تنظیم‌شده همزمان استفاده شوند، فقط سایه خارجی اعمال می‌شود.
- اگر سایه‌های خارجی و داخلی همزمان استفاده شوند، نتیجه بستگی به نسخه PowerPoint دارد. به عنوان مثال، در PowerPoint 2013 اثر دو برابر می‌شود، در حالی که در PowerPoint 2007 فقط سایه خارجی اعمال می‌شود.
{{% /alert %}}

### **اعمال افکت‌های بازتاب**

یک بازتاب یک نسخهٔ آینه‌ای از متن ایجاد می‌کند. می‌توانید موقعیت، مقیاس، تاری و شفافیت آن را تنظیم کنید تا ظاهر دلخواه را به دست آورید.

این مثال متد [enableReflectionEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) را فراخوانی می‌کند و بازتاب را به صورت عمودی با مقیاس -۱۰۰٪ می‌چرخاند. از شعاع تاری ۰.۵ نقطه و فاصله ۴.۷۲ نقطه استفاده می‌کند. شفافیت از ۶۰٪ به ۰.۹٪ بین موقعیت‌های ۰٪ و ۶۰٪ در طول بازتاب کاهش می‌یابد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

متن حاصل:

![افکت بازتاب](reflection_effect.png)

### **اعمال افکت‌های نوردهی**

نوردهی یک خط دور نرم رنگی دور متن اضافه می‌کند. می‌توانید رنگ، شفافیت و شعاع آن را تنظیم کنید.

این مثال متد [enableGlowEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) را فراخوانی می‌کند و یک نوردهی قرمز با شفافیت ۵۴٪ و شعاع ۷ نقطه اعمال می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

متن حاصل:

![افکت نوردهی](glow_effect.png)

### **اعمال تبدیل‌های WordArt**

تبدیل‌های WordArt می‌توانند بلوک متنی را خم، کشیده یا خمیده کنند.

متد [setTransform](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setTransform) را به [ArchUpPour](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) تنظیم کنید تا فریم متنی کامل به سمت بالا منحنی شود:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

متن حاصل:

![تبدیل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides برای Node.js via Java مجموعه‌ای از [انواع تبدیل پیش‌تعریف‌شده](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textshapetype/) را فراهم می‌کند.
{{% /alert %}}

### **اعمال افکت‌های سه‌بعدی به اشکال و متن**

می‌توانید افکت‌های سه‌بعدی را به یک شکل یا متن آن اعمال کنید. برش‌دارها، برجستگی، نورپردازی و تنظیمات دوربین ظاهر نهایی را تعیین می‌کنند.

مثال زیر از [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) برای اضافه کردن برش‌دارهای دایره‌ای، برجستگی نارنجی و حاشیه قرمز تیره به مستطیل استفاده می‌کند. ابعاد برش‌دار، ارتفاع برجستگی، عرض حاشیه و عمق بر حسب نقطه اندازه‌گیری می‌شوند. یک مادهٔ پلاستیکی، نورپردازی متعادل که ۴۰ درجه حول محور Z چرخیده و یک دوربین پرسپکتیو ظاهر آن را تعیین می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

شکل حاصل:

![افکت سه‌بعدی شکل](shape_3D_effect.png)

این مثال قالب‌بندی سه‌بعدی مشابهی را به متن از طریق [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) اعمال می‌کند. برش‌دارهای کوچکتر لبهٔ حروف را شکل می‌دهند، در حالی که برجستگی و نورپردازی به متن عمق می‌بخشند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

متن حاصل:

![افکت سه‌بعدی متن](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
اعمال افکت‌های سه‌بعدی بر متن یا شکل‌های آن—و تعامل بین این افکت‌ها—توسط قوانین خاصی کنترل می‌شود. صحنه‌ای که هم متن و هم شکل را دربر می‌گیرد در نظر بگیرید. یک افکت سه‌بعدی شامل بازنمایی سه‌بعدی شیء و صحنه‌ای است که در آن قرار دارد.

- اگر صحنه‌ای هم برای شکل و هم برای متن تنظیم شود، صحنهٔ شکل اولویت دارد و صحنهٔ متن نادیده گرفته می‌شود.
- اگر شکل صحنهٔ خود را نداشته باشد اما بازنمایی سه‌بعدی داشته باشد، صحنهٔ متن استفاده می‌شود.
- اگر شکل اصلاً افکت سه‌بعدی نداشته باشد، به‌عنوان مسطح در نظر گرفته می‌شود و افکت سه‌بعدی فقط بر متن اعمال می‌شود.

این رفتارها به روش‌های [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getLightRig) و [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getCamera) مربوط می‌شود.
{{% /alert %}}

برای حفظ متن به‌صورت مسطح و قابل‌خواندن در حالی که قالب‌بندی سه‌بعدی شکل حفظ می‌شود، به [Keep Text Flat on a 3D Shape](/slides/fa/nodejs-java/3d-presentation/) مراجعه کنید تا مقایسهٔ هر دو تنظیم و یک مثال کامل JavaScript را ببینید.

## **سوالات متداول**

**آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides برای Node.js via Java پشتیبانی Unicode دارد و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکننده و خط دور می‌توانند صرف‌نظر از زبان اعمال شوند، هرچند در دسترس بودن فونت و رندر ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را به عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را به اشکال در اسلایدهای مستر، از جمله نگه‌دارندهٔ عنوان، فوترها یا متن پس‌زمینه اعمال کنید. تغییرات انجام‌شده در طرح مستر بر تمام اسلایدهای وابسته بازتاب می‌یابد.

**آیا افکت‌های WordArt بر حجم فایل ارائه تأثیر می‌گذارد؟**

به‌طور جزئی. افکت‌های WordArt مانند سایه‌ها، نوردهی‌ها و پرکننده‌های گرادیان ممکن است به دلیل افزایش متادیتای قالب‌بندی حجم فایل را کمی افزایش دهند، اما تفاوت معمولاً ناچیز است.

**آیا می‌توانم نتیجه افکت‌های WordArt را بدون ذخیرهٔ ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای شامل WordArt را به تصویر (مانند PNG یا JPEG) رندر کنید با استفاده از [Slide.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage)، یا اشکال فردی را با [Shape.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) رندر کنید. این امکان پیش‌نمایش نتیجه در حافظه یا روی صفحه نمایش را پیش از ذخیره یا خروجی کامل ارائه می‌دهد.