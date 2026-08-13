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
- افکت روشنایی
- تبدیل WordArt
- افکت 3D
- افکت سایه خارجی
- افکت سایه داخلی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Java. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در Java ارتقا دهند."
---
## **مروری کلی**

افکت‌های WordArt به شما امکان می‌دهند متنی بصری جذاب و سبک‌دار به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی‌سازی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله مروری بر کار با WordArt ارائه می‌دهد، از جمله چگونگی اعمال تبدیل‌های متنی، سبک‌های پرکردن، خطوط دور، سایه‌ها و سایر گزینه‌های قالب‌بندی برای ایجاد محتوای ارائه‌ای بیشتر بیان‌گر و جذاب. WordArt به شما اجازه می‌دهد متن را به‌عنوان یک شیء گرافیکی درنظر بگیرید. این ویژگی شامل افکت‌ها یا تغییرات ویژه‌ای است که بر متن اعمال می‌شود تا جذاب‌تر یا قابل توجه‌تر گردد.

## **ایجاد یک قالب WordArt ساده و اعمال آن به متن**

**استفاده از Aspose.Slides** 

ابتدا با این کد Java یک متن ساده می‌سازیم:

``` java
import com.aspose.slides.*;

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
اکنون با کد زیر ارتفاع فونت متن را به مقدار بزرگ‌تری تنظیم می‌کنیم تا افکت واضح‌تر باشد:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**استفاده از Microsoft PowerPoint**

به منوی افکت‌های WordArt در Microsoft PowerPoint بروید:

![todo:image_alt_text](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک افکت WordArt از پیش تعریف‌شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید.

این‌ها برخی از پارامترها یا گزینه‌های موجود هستند:

![todo:image_alt_text](image-20200930114015-3.png)

**استفاده از Aspose.Slides**

در اینجا رنگ الگوی [SmallGrid](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PatternStyle#SmallGrid) را به متن اعمال می‌کنیم و یک حاشیه متن مشکی با عرض 1 با این کد اضافه می‌کنیم:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

متن حاصل:

![todo:image_alt_text](image-20200930114108-4.png)

## **اعمال افکت‌های دیگر WordArt**

**استفاده از Microsoft PowerPoint**

از رابط برنامه می‌توانید این افکت‌ها را روی متن، بلوک متن، شکل یا عنصر مشابه اعمال کنید:

![todo:image_alt_text](image-20200930114129-5.png)

به‌عنوان مثال، افکت‌های Shadow، Reflection و Glow می‌توانند روی متن اعمال شوند؛ افکت‌های 3D Format و 3D Rotation می‌توانند روی بلوک متن اعمال شوند؛ ویژگی Soft Edges می‌تواند روی یک شیء Shape اعمال شود (هنوز وقتی خاصیت 3D Format تنظیم نشده باشد هم اثر دارد).

### **اعمال افکت‌های سایه**

در اینجا قصد داریم فقط خواص مربوط به متن را تنظیم کنیم. با این کد Java افکت سایه را روی متن اعمال می‌کنیم:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

API Aspose.Slides از سه نوع سایه پشتیبانی می‌کند: OuterShadow، InnerShadow و PresetShadow.

با PresetShadow می‌توانید یک سایه پیش‌تنظیم‌شده را بر متن اعمال کنید.

**استفاده از Microsoft PowerPoint**

در PowerPoint فقط یک نوع سایه موجود است. در اینجا یک مثال آورده شده است:

![todo:image_alt_text](image-20200930114225-6.png)

**استفاده از Aspose.Slides**

Aspose.Slides در واقع به شما اجازه می‌دهد همزمان دو نوع سایه InnerShadow و PresetShadow را اعمال کنید.

**نکات:**

- وقتی OuterShadow و PresetShadow همراه هم استفاده شوند، فقط افکت OuterShadow اعمال می‌شود. 
- اگر OuterShadow و InnerShadow همزمان استفاده شوند، اثر اعمال‌شده بسته به نسخه PowerPoint متفاوت است. به‌عنوان مثال، در PowerPoint 2013 اثر دوبرابر می‌شود، ولی در PowerPoint 2007 افکت OuterShadow اعمال می‌شود.

### **اعمال نمایش (Display) بر روی متن‌ها**

ما نمایش را به متن با این نمونه کد Java اضافه می‌کنیم:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **اعمال افکت Glow بر روی متن‌ها**

ما افکت Glow را بر متن اعمال می‌کنیم تا براق یا متمایز شود با این کد:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
می‌توانید پارامترهای سایه، نمایش و Glow را تغییر دهید. ویژگی‌های افکت‌ها به‌صورت جداگانه بر هر بخش از متن تنظیم می‌شوند. 
{{% /alert %}} 

### **استفاده از Transformations در WordArt**

ما از ویژگی Transform (که برای کل بلوک متن اعمال می‌شود) با این کد استفاده می‌کنیم:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

نتیجه:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
هر دو Microsoft PowerPoint و Aspose.Slides for Java تعداد معینی از انواع تبدیل (transformation) از پیش تعریف‌شده را ارائه می‌دهند. 
{{% /alert %}} 

**استفاده از PowerPoint**

برای دسترسی به انواع تبدیل از پیش تعریف‌شده به مسیر زیر بروید: **Format** → **TextEffect** → **Transform**

**استفاده از Aspose.Slides**

برای انتخاب نوع تبدیل، از enum  TextShapeType  استفاده کنید.

### **اعمال افکت‌های 3D بر متن‌ها و شکل‌ها**

ما یک افکت 3D به یک شکل متنی با این کد نمونه اعمال می‌کنیم:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

متن و شکل حاصل:

![todo:image_alt_text](image-20200930114816-9.png)

ما یک افکت 3D به متن با این کد Java اعمال می‌کنیم:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
اعمال افکت‌های 3D بر متن یا شکل‌های آن و تعامل بین افکت‌ها بر مبنای قوانین خاصی است. 

صحنه‌ای برای متن و شکل حاوی آن متن در نظر بگیرید. افکت 3D شامل نمایش شیء 3D و صحنه‌ای است که شیء بر روی آن قرار گرفته است. 

- وقتی صحنه برای هر دو، شکل و متن تنظیم شده باشد، اولویت بالاتری به صحنه شکل داده می‌شود—صحنه متن نادیده گرفته می‌شود. 
- وقتی شکل صحنه خود را نداشته باشد ولی نمایه 3D داشته باشد، صحنه متن استفاده می‌شود. 
- در غیر این صورت—وقتی شکل در ابتدا هیچ افکت 3D نداشته باشد—شکل تخت می‌ماند و افکت 3D فقط به متن اعمال می‌شود. 

این توضیحات به متدهای ThreeDFormat.getLightRig() و ThreeDFormat.getCamera() مربوط است. 
{{% /alert %}} 

## **اعمال افکت Outer Shadow بر متن‌ها**
Aspose.Slides for Java کلاس‌های [IOuterShadow](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioutershadow/) و [IInnerShadow](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iinnershadow/) را فراهم می‌کند که به شما اجازه می‌دهد افکت‌های سایه را به متنی که در [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) قرار دارد، اعمال کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.  
2. با استفاده از ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک AutoShape از نوع Rectangle را به اسلاید اضافه کنید.  
4. به TextFrame مرتبط با AutoShape دسترسی پیدا کنید.  
5. FillType AutoShape را روی NoFill تنظیم کنید.  
6. کلاس OuterShadow را نمونه‌سازی کنید.  
7. BlurRadius سایه را تنظیم کنید.  
8. Direction سایه را تنظیم کنید.  
9. Distance سایه را تنظیم کنید.  
10. RectanglelAlign را روی TopLeft تنظیم کنید.  
11. PresetColor سایه را به Black تنظیم کنید.  
12. ارائه را به عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) نوشته کنید.

این کد نمونه در Java—پیاده‌سازی مراحل بالا—نحوه اعمال افکت outer shadow به متن را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // دریافت مرجع اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // افزودن TextFrame به Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // در صورت نیاز به سایهٔ متن، پرکردن شکل را غیرفعال کنید
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // سایهٔ خارجی را اضافه کرده و تمام پارامترهای لازم را تنظیم کنید
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //نمایش را در دیسک ذخیره کنید
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال افکت Inner Shadow بر شکل‌ها**
مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.  
2. مرجع اسلاید را دریافت کنید.  
3. یک AutoShape از نوع Rectangle اضافه کنید.  
4. InnerShadowEffect را فعال کنید.  
5. تمام پارامترهای لازم را تنظیم کنید.  
6. ColorType را به Scheme تنظیم کنید.  
7. رنگ Scheme را تعیین کنید.  
8. ارائه را به عنوان [PPTX](https://docs.fileformat.com/presentation/pptx/) نوشته کنید.

این کد نمونه (بر پایه مراحل بالا) نشان می‌دهد چگونه افکت inner shadow را به متن داخل یک شکل در Java اعمال کنید:

```java
import com.aspose.slides.*;

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

    // تنظیم ColorType به Scheme
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

### آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟

بله، Aspose.Slides از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکردن و خطوط دور می‌توانند صرف‌نظر از زبان اعمال شوند، اگرچه در دسترس بودن فونت و رندر ممکن است به فونت‌های سیستم وابسته باشد.

### آیا می‌توانم افکت‌های WordArt را به عناصر مستر اسلاید اعمال کنم؟

بله، می‌توانید افکت‌های WordArt را به اشکال موجود در اسلایدهای مستر، از جمله جای‌نگهدارهای عنوان، فوتر یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده به طرح مستر در تمام اسلایدهای مرتبط بازتاب خواهد یافت.

### آیا افکت‌های WordArt بر حجم فایل ارائه تأثیر می‌گذارند؟

به‌طور جزئی. افکت‌های WordArt مانند سایه‌ها، نورها و پرکردن‌های گرادیان ممکن است به‌دلیل افزودن متادیتای قالب‌بندی، حجم فایل را کمی افزایش دهند، اما این تفاوت معمولاً ناچیز است.

### آیا می‌توانم پیش‌نمایش نتیجه افکت‌های WordArt را بدون ذخیره‌سازی ارائه ببینم؟

بله، می‌توانید اسلایدهای حاوی WordArt را به تصویر (مثلاً PNG یا JPEG) رندر کنید با استفاده از متد `getImage` از اینترفیس‌های [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) یا [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/). این امکان پیش‌نمایش نتیجه را به صورت در‑حافظه یا روی صفحه قبل از ذخیره یا استخراج کل ارائه فراهم می‌کند.