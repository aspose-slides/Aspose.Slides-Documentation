---
title: ایجاد و اعمال افکت‌های WordArt در JavaScript
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
- افکت نمایش
- افکت درخشندگی
- تبدیل WordArt
- افکت ۳بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Node.js. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای بهبود دهند."
---
## **بررسی کلی**

افکت‌های WordArt به شما امکان می‌دهند متنی بصری جذاب و سبک‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به صورت برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی‌سازی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله یک نمای کلی از کار با WordArt ارائه می‌دهد، از جمله نحوه اعمال تبدیلات متن، سبک‌های پر، خطوط دور، سایه‌ها و سایر گزینه‌های قالب‌بندی برای اینکه محتوای ارائه شما بیان‌گرتر و جذاب‌تر شود. WordArt به شما اجازه می‌دهد متن را به عنوان یک شیء گرافیکی در نظر بگیرید. این شامل افکت‌ها یا تغییرات ویژه‌ای است که بر متن اعمال می‌شوند تا جذاب‌تر یا قابل‌توجه‌تر باشد.

## **ایجاد یک قالب ساده WordArt و اعمال آن بر روی متن**

**استفاده از Aspose.Slides** 

ابتدا، یک متن ساده با استفاده از این کد JavaScript ایجاد می‌کنیم:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
سپس، ارتفاع فونت متن را به مقدار بزرگتری تنظیم می‌کنیم تا افکت بیشتر دیده شود، با این کد:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**استفاده از Microsoft PowerPoint**

به منوی افکت‌های WordArt در Microsoft PowerPoint بروید:

![todo:image_alt_text](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک افکت WordArt پیش‌تعریف‌شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید.  

در ادامه برخی از پارامترها یا گزینه‌های موجود آورده شده است:

![todo:image_alt_text](image-20200930114015-3.png)

**استفاده از Aspose.Slides**

در اینجا، رنگ الگوی [SmallGrid](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PatternStyle#SmallGrid) را بر روی متن اعمال می‌کنیم و با این کد یک قاب متن سیاه با عرض ۱ اضافه می‌کنیم:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

متن حاصل:

![todo:image_alt_text](image-20200930114108-4.png)

## **اعمال سایر افکت‌های WordArt**

**استفاده از Microsoft PowerPoint**

از کلاس برنامه می‌توانید این افکت‌ها را بر روی متن، بلوک متن، شکل یا عنصر مشابهی اعمال کنید:

![todo:image_alt_text](image-20200930114129-5.png)

به‌عنوان مثال، افکت‌های سایه، انعکاس و درخشندگی می‌توانند بر روی متن اعمال شوند؛ افکت‌های قالب‌بندی ۳بعدی و چرخش ۳بعدی می‌توانند بر روی بلوک متن اعمال شوند؛ ویژگی لبه‌های نرم می‌تواند بر روی یک شیء Shape اعمال شود (در صورتی که هیچ ویژگی قالب‌بندی ۳بعدی تنظیم نشده باشد نیز اثر دارد).

### **اعمال افکت‌های سایه**

در اینجا قصد داریم فقط ویژگی‌های مربوط به متن را تنظیم کنیم. افکت سایه را بر روی متن با این کد JavaScript اعمال می‌کنیم:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

API Aspose.Slides از سه نوع سایه پشتیبانی می‌کند: OuterShadow، InnerShadow و PresetShadow.  
با PresetShadow می‌توانید سایه‌ای برای متن اعمال کنید (با استفاده از مقادیر پیش‌تنظیم).

**استفاده از Microsoft PowerPoint**

در PowerPoint می‌توانید از یک نوع سایه استفاده کنید. در اینجا مثال آن آورده شده است:

![todo:image_alt_text](image-20200930114225-6.png)

**استفاده از Aspose.Slides**

Aspose.Slides در واقع به شما امکان می‌دهد دو نوع سایه را به‌صورت همزمان اعمال کنید: InnerShadow و PresetShadow.

**Notes:**
- وقتی OuterShadow و PresetShadow همزمان استفاده شوند، فقط افکت OuterShadow اعمال می‌شود.
- اگر OuterShadow و InnerShadow هم‌زمان استفاده شوند، افکت نهایی یا اعمال‌شده بسته به نسخه PowerPoint متفاوت است. به‌عنوان مثال، در PowerPoint 2013 افکت دو برابر می‌شود، اما در PowerPoint 2007 افکت OuterShadow اعمال می‌شود.

### **اعمال نمایش به متون**

ما با این نمونه کد JavaScript به متن نمایش (Display) اضافه می‌کنیم:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **اعمال افکت درخشندگی (Glow) به متون**

ما با استفاده از این کد افکت درخشندگی (Glow) را بر متن اعمال می‌کنیم تا براق یا برجسته شود:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

نتیجهٔ عملیات:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
می‌توانید پارامترهای سایه، نمایش و درخشندگی را تغییر دهید. ویژگی‌های افکت‌ها به‌ طور جداگانه بر هر بخش از متن تنظیم می‌شود. 
{{% /alert %}} 

### **استفاده از تبدیلات در WordArt**

ما با استفاده از این کد، ویژگی Transform (که در کل بلوک متن اعمال می‌شود) را به کار می‌بریم:

```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

نتیجه:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
هر دو Microsoft PowerPoint و Aspose.Slides برای Node.js از طریق Java تعدادی از انواع تبدیلات پیش‌تعریف‌شده را ارائه می‌دهند. 
{{% /alert %}} 

**استفاده از PowerPoint**

برای دسترسی به انواع تبدیلات پیش‌تعریف‌شده، مسیر زیر را طی کنید: **Format** → **TextEffect** → **Transform**

**استفاده از Aspose.Slides**

برای انتخاب نوع تبدیلات، از enum TextShapeType استفاده کنید.

### **اعمال افکت‌های ۳بعدی به متون و شکل‌ها**

ما با استفاده از این نمونه کد، یک افکت ۳بعدی را بر شکل متن اعمال می‌کنیم:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

متن حاصل و شکل آن:

![todo:image_alt_text](image-20200930114816-9.png)

ما با این کد JavaScript یک افکت ۳بعدی را بر متن اعمال می‌کنیم:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

نتیجهٔ عملیات:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
اعمال افکت‌های ۳بعدی بر متن یا شکل‌های آن و تعامل بین افکت‌ها بر اساس قوانین خاصی است.  
صحنه‌ای برای متن و شکلی که متن را در بر می‌گیرد در نظر بگیرید. افکت ۳بعدی شامل نمایشی از شیء ۳بعدی و صحنه‌ای است که شیء در آن قرار گرفته است.  

- وقتی صحنه هم برای شکل و هم برای متن تنظیم شده باشد، صحنه شکل اولویت بیشتری دارد—صحنه متن نادیده گرفته می‌شود.  
- اگر شکل صحنهٔ خود را نداشته باشد اما نمای ۳بعدی دارد، صحنه متن استفاده می‌شود.  
- در غیر این صورت—اگر شکل در ابتدا افکت ۳بعدی نداشته باشد—شکل صاف است و افکت ۳بعدی فقط بر متن اعمال می‌شود.  

این توضیحات به متدهای ThreeDFormat.getLightRig() و ThreeDFormat.getCamera() مرتبط هستند. 
{{% /alert %}} 

## **اعمال افکت‌های Outer Shadow بر متون**

Aspose.Slides برای Node.js از طریق Java کلاس‌های [**OuterShadow**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/outershadow/) و [**InnerShadow**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/innershadow/) را ارائه می‌دهد که به شما اجازه می‌دهند افکت‌های سایه را بر متن موجود در [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) اعمال کنید. این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.  
2. با استفاده از اندیس آن، مرجع یک اسلاید را به دست آورید.  
3. یک AutoShape از نوع Rectangle به اسلاید اضافه کنید.  
4. به TextFrame مرتبط با AutoShape دسترسی پیدا کنید.  
5. FillType AutoShape را به NoFill تنظیم کنید.  
6. یک نمونه از کلاس OuterShadow ایجاد کنید.  
7. BlurRadius سایه را تنظیم کنید.  
8. Direction سایه را تنظیم کنید.  
9. Distance سایه را تنظیم کنید.  
10. RectanglelAlign را به TopLeft تنظیم کنید.  
11. PresetColor سایه را به Black تنظیم کنید.  
12. ارائه را به عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.  

این نمونه کد در Java—اجرای مراحل فوق—نشان می‌دهد چگونه افکت OuterShadow را بر متن اعمال کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // دریافت مرجع اسلاید
    var sld = pres.getSlides().get_Item(0);
    // افزودن یک AutoShape از نوع Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // افزودن TextFrame به Rectangle
    ashp.addTextFrame("Aspose TextBox");
    // غیرفعال‌سازی پر کردن شکل در صورتی که بخواهیم سایه متن را بگیریم
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // افزودن سایه خارجی و تنظیم تمام پارامترهای لازم
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // ذخیره ارائه در دیسک
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اعمال افکت Inner Shadow بر شکل‌ها**

این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.  
2. مرجع اسلاید را به دست آورید.  
3. یک AutoShape از نوع Rectangle اضافه کنید.  
4. InnerShadowEffect را فعال کنید.  
5. تمام پارامترهای لازم را تنظیم کنید.  
6. ColorType را به Scheme تنظیم کنید.  
7. Scheme Color را تنظیم کنید.  
8. ارائه را به عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.  

این نمونه کد (بر پایه مراحل فوق) نشان می‌دهد چگونه یک connector بین دو شکل در JavaScript اضافه کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // دریافت مرجع اسلاید
    var slide = pres.getSlides().get_Item(0);
    // افزودن AutoShape از نوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // افزودن TextFrame به Rectangle
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // فعال‌سازی InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // تنظیم تمام پارامترهای لازم
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // تنظیم ColorType به عنوان Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // تنظیم رنگ Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // ذخیره ارائه
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پر و خطوط دور می‌توانند صرف‌نظر از زبان اعمال شوند، اما در دسترس بودن فونت و رندرینگ ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را بر عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را بر شکل‌ها در اسلایدهای مستر اعمال کنید، از جمله placeholders عنوان، فوترها یا متن پس‌زمینه. تغییرات اعمال‌شده در طرح مستر در تمام اسلایدهای مرتبط بازتاب خواهد شد.

**آیا افکت‌های WordArt بر حجم فایل ارائه تأثیر می‌گذارند؟**

به‌صورت جزئی. افکت‌های WordArt مانند سایه‌ها، درخشندگی‌ها و پرهای گرادیان می‌توانند کمی حجم فایل را به دلیل اضافه شدن متادیتای قالب‌بندی افزایش دهند، اما معمولاً این اختلاف ناچیز است.

**آیا می‌توانم نتیجه افکت‌های WordArt را بدون ذخیرهٔ ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای حاوی WordArt را به تصاویر (مثلاً PNG، JPEG) رندر کنید با استفاده از متد `getImage` از کلاس‌های [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) یا [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/). این امکان را می‌دهد تا نتیجه را در حافظه یا روی صفحه نمایش پیش‌نمایش کنید قبل از ذخیره یا خروجی گرفتن از کل ارائه.