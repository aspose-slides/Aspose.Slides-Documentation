---
title: ایجاد و اعمال افکت‌های WordArt در Android
linktitle: WordArt
type: docs
weight: 110
url: /fa/androidjava/wordart/
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
- Android
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Android. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در Java ارتقا دهند."
---
## **بررسی کلی**

افکت‌های WordArt به شما امکان می‌دهند متن‌های جذاب و استایل‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی‌سازی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله نگاهی کلی به کار با WordArt می‌اندازد، از جمله نحوه اعمال تبدیل‌های متنی، سبک‌های پر، خطوط حاشیه، سایه‌ها و سایر گزینه‌های قالب‌بندی برای جذاب‌تر و بیانگرتر کردن محتوای ارائه شما. WordArt به شما اجازه می‌دهد متن را به عنوان یک شی گرافیکی در نظر بگیرید. این شامل افکت‌ها یا تغییرات ویژه‌ای است که بر متن اعمال می‌شود تا جذاب‌تر یا قابل‌توجه‌تر باشد.

## **ایجاد یک قالب ساده WordArt و اعمال آن بر متن**

**استفاده از Aspose.Slides**  

ابتدا، یک متن ساده با این کد Java می‌سازیم:

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
حال، ارتفاع فونت متن را به مقدار بزرگ‌تری تنظیم می‌کنیم تا افکت واضح‌تر شود، با این کد:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**استفاده از Microsoft PowerPoint**

به منوی افکت‌های WordArt در Microsoft PowerPoint بروید:

![todo:image_alt_text](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک افکت WordArt پیش‌تعریف شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید.  

برخی از پارامترها یا گزینه‌های موجود عبارت‌اند از:

![todo:image_alt_text](image-20200930114015-3.png)

**استفاده از Aspose.Slides**

در اینجا، الگوی رنگی [SmallGrid](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PatternStyle#SmallGrid) را به متن اعمال می‌کنیم و با این کد یک حاشیه متن سیاه با عرض 1 اضافه می‌کنیم:

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

از رابط برنامه می‌توانید این افکت‌ها را بر متن، بلوک متن، شکل یا المان مشابه اعمال کنید:

![todo:image_alt_text](image-20200930114129-5.png)

به عنوان مثال، افکت‌های سایه، انعکاس و درخشندگی می‌توانند بر متن اعمال شوند؛ افکت‌های قالب‌بندی سه‌بعدی و چرخش سه‌بعدی می‌توانند بر بلوک متن اعمال شوند؛ خصوصیت لبه‌های نرم می‌تواند بر یک شی Shape اعمال شود (هنوز زمانی که خصوصیت قالب‌بندی سه‌بعدی تنظیم نشده باشد، اثر دارد).

### **اعمال افکت‌های سایه**

در اینجا قصد داریم ویژگی‌های مربوط به یک متن را تنظیم کنیم. افکت سایه را به متن با این کد Java اعمال می‌کنیم:

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

API Aspose.Slides سه نوع سایه پشتیبانی می‌کند: OuterShadow، InnerShadow و PresetShadow.  

با PresetShadow می‌توانید یک سایه پیش‌تنظیم‌شده بر متن اعمال کنید.

**استفاده از Microsoft PowerPoint**

در PowerPoint می‌توانید از یک نوع سایه استفاده کنید. مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**استفاده از Aspose.Slides**

Aspose.Slides در واقع اجازه می‌دهد دو نوع سایه را همزمان اعمال کنید: InnerShadow و PresetShadow.

**نکات:**

- وقتی OuterShadow و PresetShadow هم‌زمان استفاده شوند، تنها افکت OuterShadow اعمال می‌شود.  
- اگر OuterShadow و InnerShadow همزمان به کار برده شوند، اثر نهایی بستگی به نسخه PowerPoint دارد. برای مثال، در PowerPoint 2013 اثر دو برابر می‌شود؛ اما در PowerPoint 2007، افکت OuterShadow اعمال می‌شود.

### **اعمال افکت‌های انعکاس بر متن**

با این نمونه کد Java نمایش به متن اضافه می‌کنیم:

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

### **اعمال افکت‌های درخشندگی بر متن**

با این کد افکت درخشندگی را به متن اعمال می‌کنیم تا براق یا برجسته شود:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
می‌توانید پارامترهای سایه، انعکاس و درخشندگی را تغییر دهید. ویژگی‌های افکت بر هر بخش از متن به‌طور جداگانه تنظیم می‌شوند. 
{{% /alert %}} 

### **استفاده از تبدیل‌ها در WordArt**

با این کد، ویژگی Transform (که بر کل بلوک متن اعمال می‌شود) را استفاده می‌کنیم:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

نتیجه:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
هر دو Microsoft PowerPoint و Aspose.Slides برای Android از طریق Java تعداد معینی از انواع تبدیل‌های پیش‌تعریف‌شده را فراهم می‌کنند. 
{{% /alert %}} 

**استفاده از PowerPoint**

برای دسترسی به انواع تبدیل‌های پیش‌تعریف‌شده، مسیر زیر را دنبال کنید: **Format** -> **TextEffect** -> **Transform**

**استفاده از Aspose.Slides**

برای انتخاب یک نوع تبدیل، از enum ‎TextShapeType‎ استفاده کنید.

### **اعمال افکت‌های سه‌بعدی بر متن و اشکال**

با این نمونه کد یک افکت سه‌بعدی به شکل متن اعمال می‌کنیم:

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

متن و شکل حاصل:

![todo:image_alt_text](image-20200930114816-9.png)

با این کد Java یک افکت سه‌بعدی بر متن اعمال می‌کنیم:

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
اعمال افکت‌های سه‌بعدی بر متن یا شکل‌های آنها و تعامل بین افکت‌ها بر اساس قوانین خاصی انجام می‌شود. 

صحنه‌ای را برای متن و شکلی که متن را در بردارد در نظر بگیرید. افکت سه‌بعدی شامل نمایشی از شی سه‌بعدی و صحنه‌ای است که شی روی آن قرار گرفته است. 

- وقتی صحنه برای هر دو، شکل و متن تنظیم شده باشد، صحنه شکل اولویت بالاتری دارد—صحنه متن نادیده گرفته می‌شود.  
- وقتی شکل صحنهٔ خود را نداشته باشد اما نمای سه‌بعدی دارد، صحنهٔ متن استفاده می‌شود.  
- در غیر این صورت—وقتی شکل در ابتدا هیچ افکت سه‌بعدی ندارد—شکل مسطح است و افکت سه‌بعدی فقط بر متن اعمال می‌شود.  

این توضیحات به متدهای ‎ThreeDFormat.getLightRig()‎ و ‎ThreeDFormat.getCamera()‎ مرتبط هستند. 
{{% /alert %}} 

## **اعمال افکت سایه خارجی بر متن**
Aspose.Slides برای Android از طریق Java کلاس‌های [**IOuterShadow**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioutershadow/) و [**IInnerShadow**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinnershadow/) را ارائه می‌دهد که امکان اعمال افکت‌های سایه به متنی که درون ‎[TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/)‎ قرار دارد، می‌دهند. این مراحل را دنبال کنید:

1. یک نمونه از کلاس ‎[Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation)‎ ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک AutoShape از نوع Rectangle را به اسلاید اضافه کنید.  
4. به TextFrame مرتبط با AutoShape دسترسی پیدا کنید.  
5. FillType AutoShape را روی NoFill تنظیم کنید.  
6. کلاس OuterShadow را نمونه‌سازی کنید.  
7. BlurRadius سایه را تنظیم کنید.  
8. Direction سایه را تنظیم کنید.  
9. Distance سایه را تنظیم کنید.  
10. RectanglelAlign را روی TopLeft تنظیم کنید.  
11. PresetColor سایه را روی Black تنظیم کنید.  
12. ارائه را به عنوان فایل ‎[PPTX](https://docs.fileformat.com/presentation/pptx/)‎ ذخیره کنید.  

این کد نمونه در Java—پیاده‌سازی مراحل فوق—نحوه اعمال افکت سایه خارجی به متن را نشان می‌دهد:

```java
Presentation pres = new Presentation();
try {
    // دریافت مرجع اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // اضافه کردن TextFrame به Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // غیرفعال‌کردن پر کردن شکل در صورتی که بخواهیم سایه متن را دریافت کنیم
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // اضافه کردن سایه خارجی و تنظیم تمام پارامترهای لازم
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //نوشتن ارائه در دیسک
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال افکت سایه داخلی بر اشکال**
مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس ‎[Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation)‎ ایجاد کنید.  
2. مرجع اسلاید را دریافت کنید.  
3. یک AutoShape از نوع Rectangle اضافه کنید.  
4. InnerShadowEffect را فعال کنید.  
5. تمام پارامترهای لازم را تنظیم کنید.  
6. ColorType را به Scheme تنظیم کنید.  
7. رنگ Scheme را تنظیم کنید.  
8. ارائه را به عنوان فایل ‎[PPTX](https://docs.fileformat.com/presentation/pptx/)‎ ذخیره کنید.  

این کد نمونه (بر پایه مراحل فوق) نشان می‌دهد چگونه یک کانکتور بین دو shape در Java اضافه کنید:

```java
Presentation pres = new Presentation();
try {
    // دریافت مرجع اسلاید
    ISlide slide = pres.getSlides().get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // اضافه کردن TextFrame به Rectangle
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

    // تنظیم Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // ذخیره‌سازی ارائه
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های متفاوت (مانند عربی، چینی) استفاده کنم؟**  

بله، Aspose.Slides از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پر و خط مرزی می‌توانند صرف‌نظر از زبان اعمال شوند، هرچند در دسترس بودن فونت و رندر ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را بر عناصر مستر اسلاید اعمال کنم؟**  

بله، می‌توانید افکت‌های WordArt را به اشکال موجود در مستر اسلایدها، شامل نگهدارنده‌های عنوان، فوتر یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده بر طرح مستر در تمام اسلایدهای مرتبط بازتاب می‌یابد.

**آیا افکت‌های WordArt بر اندازه فایل ارائه تأثیر می‌گذارند؟**  

به‌صورت جزئی. افکت‌های WordArt مانند سایه‌ها، درخشندگی‌ها و پرهای گرادیان ممکن است کمی اندازه فایل را به‌دلیل افزودن متادیتای قالب‌بندی افزایش دهند، ولی معمولاً این تفاوت ناچیز است.

**آیا می‌توانم نتیجه افکت‌های WordArt را بدون ذخیرهٔ ارائه پیش‌نمایش کنم؟**  

بله، می‌توانید اسلایدهای حاوی WordArt را به تصویر (مثلاً PNG یا JPEG) رندر کنید با استفاده از متد ‎`getImage`‎ از اینترفیس‌های ‎[IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/)‎ یا ‎[ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/)‎. این امکان پیش‌نمایش نتیجه را در حافظه یا روی صفحه قبل از ذخیره یا استخراج کل ارائه فراهم می‌کند.