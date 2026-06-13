---
title: ایجاد و اعمال افکت‌های WordArt در Java
linktitle: WordArt
type: docs
weight: 110
url: /fa/java/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- افکت WordArt
- افکت سایه
- افکت نمایش
- افکت درخشندگی
- تبدیل WordArt
- افکت 3D
- افکت سایه خارجی
- افکت سایه داخلی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Java. این راهنمای گام به گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در Java بهبود دهند."
---
## **بررسی کلی**

افکت‌های WordArt به شما امکان می‌دهند متن‌های جذاب و سبک‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی‌سازی و مدیریت کنند — بدون نیاز به نصب Office. این مقاله مرور کلی بر کار با WordArt را ارائه می‌دهد، از جمله نحوه اعمال تبدیل‌های متن، سبک‌های پر، خطوط پیرامونی، سایه‌ها و سایر گزینه‌های قالب‌بندی برای جذاب‌تر και بیان‌گرتر شدن محتوای ارائه شما. WordArt به شما اجازه می‌دهد متن را به‌عنوان یک شیء گرافیکی در نظر بگیرید. این شامل افکت‌ها یا تغییرات ویژه‌ای است که روی متن اعمال می‌شود تا جذاب‌تر یا قابل توجه‌تر شود.

## **ایجاد یک قالب ساده WordArt و اعمال آن بر روی متن**

**استفاده از Aspose.Slides** 

در ابتدا، یک متن ساده با استفاده از این کد Java ایجاد می‌کنیم: 

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
حال، ارتفاع قلم متن را به مقدار بزرگ‌تر تنظیم می‌کنیم تا اثر واضح‌تر شود، با این کد:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**استفاده از Microsoft PowerPoint**

به منو افکت‌های WordArt در Microsoft PowerPoint بروید:

![todo:image_alt_text](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک افکت WordArt از پیش‌تعریف‌شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید. 

این‌ها برخی از پارامترها یا گزینه‌های موجود هستند:

![todo:image_alt_text](image-20200930114015-3.png)

**استفاده از Aspose.Slides**

در اینجا، رنگ الگوی [SmallGrid](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PatternStyle#SmallGrid) را بر متن اعمال می‌کنیم و با استفاده از این کد یک حاشیه متن سیاه با ضخامت 1 اضافه می‌کنیم:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

متن حاصل:

![todo:image_alt_text](image-20200930114108-4.png)

## **اعمال سایر افکت‌های WordArt**

**استفاده از Microsoft PowerPoint**

از رابط برنامه می‌توانید این افکت‌ها را بر روی متن، بلوک متن، شکل یا عنصر مشابه اعمال کنید:

![todo:image_alt_text](image-20200930114129-5.png)

به عنوان مثال، افکت‌های سایه، بازتاب و درخشندگی می‌توانند بر روی متن اعمال شوند؛ افکت‌های قالب‌بندی 3D و چرخش 3D می‌توانند بر روی بلوک متن اعمال شوند؛ ویژگی لبه‌های نرم می‌تواند بر روی یک شیء شکل اعمال شود (در صورتی که هیچ ویژگی قالب‌بندی 3D تنظیم نشده باشد همچنان اثر دارد). 

### **اعمال افکت سایه**

در اینجا، قصد داریم فقط ویژگی‌های مرتبط با متن را تنظیم کنیم. با استفاده از این کد Java اثر سایه را بر متن اعمال می‌کنیم:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

API Aspose.Slides از سه نوع سایه پشتیبانی می‌کند: OuterShadow، InnerShadow و PresetShadow. 

با PresetShadow می‌توانید برای یک متن سایه اعمال کنید (با استفاده از مقادیر پیش‌فرض). 

**استفاده از Microsoft PowerPoint**

در PowerPoint، می‌توانید از یک نوع سایه استفاده کنید. در اینجا یک مثال آورده شده است:

![todo:image_alt_text](image-20200930114225-6.png)

**استفاده از Aspose.Slides**

Aspose.Slides در واقع امکان اعمال دو نوع سایه به‌صورت همزمان را می‌دهد: InnerShadow و PresetShadow.

**نکات:**  

- وقتی OuterShadow و PresetShadow همزمان استفاده شوند، فقط افکت OuterShadow اعمال می‌شود.  
- اگر OuterShadow و InnerShadow همزمان استفاده شوند، اثر نهایی یا اعمال‑شده بسته به نسخه PowerPoint متفاوت است. به عنوان مثال، در PowerPoint 2013 اثر دو برابر می‌شود. اما در PowerPoint 2007، افکت OuterShadow اعمال می‌شود.  

### **اعمال نمایش بر متن‌ها**

ما نمایش (display) را به متن اضافه می‌کنیم با استفاده از این نمونه کد Java:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **اعمال افکت درخشندگی به متن‌ها**

ما با استفاده از این کد افکت درخشندگی (Glow) را به متن اعمال می‌کنیم تا درخشان یا برجسته شود:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

می‌توانید پارامترهای سایه، نمایش و درخشندگی را تغییر دهید. ویژگی‌های افکت‌ها به‌صورت جداگانه بر هر بخش از متن تنظیم می‌شوند. 

{{% /alert %}} 

### **استفاده از تبدیل‌ها در WordArt**

ما ویژگی Transform (که در تمام بلوک متن وجود دارد) را با استفاده از این کد به کار می‌بریم:

``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

نتیجه:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

هر دو Microsoft PowerPoint و Aspose.Slides برای Java تعداد معینی از انواع تبدیل‌های از پیش تعریف‌شده را ارائه می‌دهند. 

{{% /alert %}} 

**استفاده از PowerPoint**

برای دسترسی به انواع تبدیل‌های از پیش تعریف‌شده، مسیر زیر را دنبال کنید: **Format** -> **TextEffect** -> **Transform**

**استفاده از Aspose.Slides**

برای انتخاب یک نوع تبدیل، از enum TextShapeType استفاده کنید. 

### **اعمال افکت‌های 3D بر متن‌ها و اشکال**

ما با استفاده از این نمونه کد یک افکت 3D به شکل متن اعمال می‌کنیم:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

متن حاصل و شکل آن:

![todo:image_alt_text](image-20200930114816-9.png)

ما با این کد Java یک افکت 3D به متن اعمال می‌کنیم:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

اعمال افکت‌های 3D بر متن‌ها یا شکل‌های آن‌ها و تعامل بین افکت‌ها براساس قوانین خاصی است. 

یک صحنه برای متن و شکلی که متن را دربردارد در نظر بگیرید. افکت 3D شامل نمایش شیء 3D و صحنه‌ای است که شیء در آن قرار گرفته است. 

- وقتی صحنه برای هر دو شکل و متن تنظیم شود، صحنه شکل اولویت بالاتری دارد — صحنه متن نادیده گرفته می‌شود.  
- وقتی شکل صحنه خود را ندارد اما نمایش 3D دارد، صحنه متن استفاده می‌شود.  
- در غیر این صورت — وقتی شکل اصلاً افکت 3D ندارد — شکل صاف می‌ماند و افکت 3D فقط بر متن اعمال می‌شود.  

این توضیحات به متدهای ThreeDFormat.getLightRig() و ThreeDFormat.getCamera() مرتبط هستند. 

{{% /alert %}} 

## **اعمال افکت Outer Shadow بر روی متن‌ها**
Aspose.Slides for Java کلاس‌های [**IOuterShadow**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioutershadow/) و [**IInnerShadow**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinnershadow/) را فراهم می‌کند که به شما امکان می‌دهند افکت‌های سایه را بر متنی که توسط [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) حمل می‌شود اعمال کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک AutoShape از نوع Rectangle را به اسلاید اضافه کنید.  
4. به TextFrame مرتبط با AutoShape دسترسی پیدا کنید.  
5. FillType AutoShape را روی NoFill تنظیم کنید.  
6. یک نمونه از کلاس OuterShadow ایجاد کنید.  
7. BlurRadius سایه را تنظیم کنید.  
8. Direction سایه را تنظیم کنید.  
9. Distance سایه را تنظیم کنید.  
10. RectanglelAlign را به TopLeft تنظیم کنید.  
11. PresetColor سایه را به Black تنظیم کنید.  
12. ارائه را به‌صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.  

```java
Presentation pres = new Presentation();
try {
    // دریافت مرجع اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // افزودن TextFrame به Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // غیرفعال کردن پرشدن شکل در صورتی که بخواهیم سایه متن را بگیریم
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // افزودن سایه خارجی و تنظیم تمام پارامترهای لازم
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // نوشتن ارائه در دیسک
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال افکت Inner Shadow بر روی اشکال**
مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.  
2. یک مرجع از اسلاید دریافت کنید.  
3. یک AutoShape از نوع Rectangle اضافه کنید.  
4. InnerShadowEffect را فعال کنید.  
5. تمام پارامترهای لازم را تنظیم کنید.  
6. ColorType را به Scheme تنظیم کنید.  
7. Scheme Color را تنظیم کنید.  
8. ارائه را به‌صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.  

```java
Presentation pres = new Presentation();
try {
    // دریافت مرجع اسلاید
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // افزودن TextFrame به Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // فعال‌سازی InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // تنظیم تمام پارامترهای لازم
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // تنظیم ColorType به عنوان Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // تنظیم رنگ Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // ذخیره ارائه
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکنندگی و خطوط پیرامونی می‌توانند صرف‌نظر از زبان اعمال شوند، هرچند در دسترس بودن فونت و رندرینگ ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را بر عناصر اسلاید مستر اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را بر اشکال موجود در اسلایدهای مستر، از جمله‌ جای‌دارهای عنوان، فوترها یا متن‌های پس‌زمینه اعمال کنید. تغییرات اعمال‌شده به طرح مستر در تمام اسلایدهای مرتبط اعمال خواهد شد.

**آیا افکت‌های WordArt بر حجم فایل ارائه تاثیر می‌گذارند؟**

تا حدودی. افکت‌های WordArt مانند سایه‌ها، درخشندگی‌ها و پرکنندگی‌های گرادیان می‌توانند به‌دلیل افزودن متادیتای قالب‌بندی، حجم فایل را اندک افزایش دهند، اما معمولاً این تفاوت ناچیز است.

**آیا می‌توانم نتیجه افکت‌های WordArt را بدون ذخیره‌سازی ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای حاوی WordArt را به تصویر (مثلاً PNG یا JPEG) رندر کنید با استفاده از متد `getImage` از اینترفیس‌های [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) یا [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) . این به شما اجازه می‌دهد نتیجه را در حافظه یا روی صفحه نمایش پیش‌نمایش کنید پیش از ذخیره یا خروجی‌گیری کامل ارائه.