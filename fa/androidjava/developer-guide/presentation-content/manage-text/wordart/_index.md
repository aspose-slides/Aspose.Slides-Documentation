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
- افکت 3 بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Android. این راهنمای گام به گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در Java بهبود بخشند."
---
## **مرور کلی**

افکت‌های WordArt به شما امکان می‌دهند متن‌های بصری جذاب و استایل‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به صورت برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله مرور کلی کار با WordArt را ارائه می‌دهد، از جمله نحوه اعمال تبدیلات متن، سبک‌های پر، خطوط پیرامون، سایه‌ها و سایر گزینه‌های قالب‌بندی برای ایجاد محتوای ارائه‌ی غنی و جذاب. WordArt به شما اجازه می‌دهد متن را مانند یک شی گرافیکی درنظر بگیرید. این شامل افکت‌ها یا تغییرات ویژه‌ای است که بر متن اعمال می‌شود تا جذاب‌تر یا قابل توجه‌تر باشد.

## **ایجاد یک قالب WordArt ساده و اعمال آن بر روی متن**

**استفاده از Aspose.Slides** 

در ابتدا، به کمک کد Java زیر یک متن ساده می‌سازیم:

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
اکنون، ارتفاع فونت متن را به مقدار بزرگ‌تری تنظیم می‌کنیم تا افکت واضح‌تر شود، با کد زیر:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

از منوی سمت راست می‌توانید یک افکت WordArt پیش‌تعریف‌شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید. 

این‌ها برخی از پارامترها یا گزینه‌های موجود هستند:

![todo:image_alt_text](image-20200930114015-3.png)

**استفاده از Aspose.Slides**

در اینجا، رنگ الگوی [SmallGrid](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PatternStyle#SmallGrid) را به متن اعمال می‌کنیم و با استفاده از این کد یک حاشیه‌ی متن سیاه به‌عرض 1 اضافه می‌کنیم:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

## **اعمال سایر افکت‌های WordArt**

**استفاده از Microsoft PowerPoint**

از رابط برنامه می‌توانید این افکت‌ها را روی متن، بلوک متن، شکل یا عنصر مشابهی اعمال کنید:

![todo:image_alt_text](image-20200930114129-5.png)

به طور مثال، افکت‌های Shadow، Reflection و Glow می‌توانند بر روی متن اعمال شوند؛ افکت‌های 3D Format و 3D Rotation می‌توانند بر روی بلوک متن اعمال شوند؛ ویژگی Soft Edges می‌تواند بر روی یک شی Shape اعمال شود (حتی زمانی که هیچ ویژگی 3D Format تنظیم نشده باشد).

### **اعمال افکت سایه**

در اینجا قصد داریم فقط ویژگی‌های مربوط به متن را تنظیم کنیم. با استفاده از این کد در Java افکت سایه را روی متن اعمال می‌کنیم:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

با PresetShadow می‌توانید یک سایه برای متن اعمال کنید (با استفاده از مقادیر پیش‌تنظیمی). 

**استفاده از Microsoft PowerPoint**

در PowerPoint می‌توانید از یک نوع سایه استفاده کنید. در مثال زیر یک نمونه را می‌بینید:

![todo:image_alt_text](image-20200930114225-6.png)

**استفاده از Aspose.Slides**

Aspose.Slides در واقع اجازه می‌دهد دو نوع سایه را همزمان اعمال کنید: InnerShadow و PresetShadow.

**نکات:**

- وقتی OuterShadow و PresetShadow با هم استفاده شوند، تنها افکت OuterShadow اعمال می‌شود. 
- اگر OuterShadow و InnerShadow به‌طور همزمان استفاده شوند، اثر نهایی بستگی به نسخه PowerPoint دارد. برای مثال، در PowerPoint 2013 افکت دوبرابر می‌شود، اما در PowerPoint 2007 افکت OuterShadow اعمال می‌شود. 

### **اعمال افکت بازتاب بر روی متن**

ما با استفاده از این نمونه کد در Java نمایش را به متن اضافه می‌کنیم:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **اعمال افکت Glow بر روی متن**

با استفاده از این کد افکت Glow را به متن اضافه می‌کنیم تا بدرخشد یا جلب توجه کند:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

نتیجهٔ عملیات:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

می‌توانید پارامترهای سایه، نمایش و Glow را تغییر دهید. خصوصیات افکت‌ها به‌صورت جداگانه روی هر بخش از متن تنظیم می‌شوند. 

{{% /alert %}} 

### **استفاده از تبدیلات در WordArt**

ما از ویژگی Transform (که برای کل بلوک متن اعمال می‌شود) با این کد استفاده می‌کنیم:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

هر دو Microsoft PowerPoint و Aspose.Slides برای Android از طریق Java تعداد محدودی از انواع تبدیلات پیش‌تعریف‌شده را ارائه می‌دهند.

{{% /alert %}} 

**استفاده از PowerPoint**

برای دسترسی به انواع تبدیلات پیش‌تعریف‌شده، مسیر زیر را دنبال کنید: **Format** -> **TextEffect** -> **Transform**

**استفاده از Aspose.Slides**

برای انتخاب یک نوع تبدیلات، از enum `TextShapeType` استفاده کنید. 

### **اعمال افکت‌های 3D بر روی متن و اشکال**

با استفاده از این کد نمونه یک افکت 3D به شکل متن اعمال می‌کنیم:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

با این کد Java یک افکت 3D به متن اعمال می‌کنیم:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

نتیجهٔ عملیات:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

اعمال افکت‌های 3D روی متن یا شکل‌های آن و تعامل بین افکت‌ها بر پایهٔ قوانین خاصی است. 

دقت کنید صحنه‌ای برای متن و شکلی که متن را در بر می‌گیرد در نظر گرفته می‌شود. افکت 3D شامل نمایش شیء 3D و صحنه‌ای است که شیء روی آن قرار می‌گیرد. 

- زمانی که صحنه برای هر دو، شکل و متن تنظیم شود، صحنهٔ شکل اولویت بالاتری دارد و صحنهٔ متن نادیده گرفته می‌شود. 
- وقتی شکل صحنهٔ خودش را ندارد اما نمایش 3D دارد، صحنهٔ متن استفاده می‌شود. 
- در غیر این‌صورت—زمانی که شکل در ابتدا هیچ افکت 3D‌ای نداشته باشد—شكل صاف است و افکت 3D فقط روی متن اعمال می‌شود. 

این توضیحات به متدهای `ThreeDFormat.getLightRig()` و `ThreeDFormat.getCamera()` مرتبط هستند. 

{{% /alert %}} 

## **اعمال افکت Outer Shadow بر روی متن**
Aspose.Slides برای Android از طریق Java کلاس‌های [**IOuterShadow**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioutershadow/) و [**IInnerShadow**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iinnershadow/) را ارائه می‌دهد که امکان اعمال افکت سایه به متنی که در [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) قرار دارد، می‌دهد. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.  
2. با استفاده از ایندکس، مرجع اسلاید را به‌دست آورید.  
3. یک AutoShape از نوع Rectangle به اسلاید اضافه کنید.  
4. به TextFrame مرتبط با AutoShape دسترسی پیدا کنید.  
5. FillType AutoShape را روی NoFill تنظیم کنید.  
6. کلاس OuterShadow را نمونه‌سازی کنید.  
7. BlurRadius سایه را تنظیم کنید.  
8. Direction سایه را تنظیم کنید.  
9. Distance سایه را تنظیم کنید.  
10. RectangleAlign را روی TopLeft تنظیم کنید.  
11. PresetColor سایه را روی Black تنظیم کنید.  
12. ارائه را به عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) نویسید.  

این کد نمونه در Java—که پیاده‌سازی مراحل فوق است—نحوهٔ اعمال افکت Outer Shadow به متن را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // دریافت مرجع اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // افزودن TextFrame به Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // غیرفعال کردن پر شدن شکل در صورتی که بخواهیم سایه متن را دریافت کنیم
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // افزودن سایه خارجی و تنظیم تمام پارامترهای لازم
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // نوشتن ارائه به دیسک
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال افکت Inner Shadow به اشکال**
مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.  
2. مرجع اسلاید را به‌دست آورید.  
3. یک AutoShape از نوع Rectangle اضافه کنید.  
4. InnerShadowEffect را فعال کنید.  
5. تمام پارامترهای لازم را تنظیم کنید.  
6. ColorType را به Scheme تنظیم کنید.  
7. رنگ Scheme را تنظیم کنید.  
8. ارائه را به عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) نویسید.  

این کد نمونه (بر پایهٔ مراحل فوق) نشان می‌دهد چگونه افکت Inner Shadow را به متن در Java اعمال کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // دریافت مرجع اسلاید
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle
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

    // تنظیم ColorType به Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // تنظیم رنگ Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // ذخیرهٔ ارائه
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

### آیا می‌توانم از افکت‌های WordArt با فونت‌ها یا اسکریپت‌های مختلف (مثلاً عربی، چینی) استفاده کنم؟

بله، Aspose.Slides یونیکد را پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های عمده کار می‌کند. افکت‌های WordArt مانند سایه، پر، و خط‌کشی بدون توجه به زبان قابل اعمال هستند، هرچند در دسترس بودن فونت و رندر ممکن است به فونت‌های سیستم وابسته باشد.

### آیا می‌توانم افکت‌های WordArt را به عناصر ماسٹر اسلاید اعمال کنم؟

بله، می‌توانید افکت‌های WordArt را به اشکال در اسلایدهای ماسٹر، شامل جای‌گیرهای عنوان، فوترها یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده به طرح ماسٹر در تمام اسلایدهای مرتبط بازتاب می‌یابد.

### آیا افکت‌های WordArt بر اندازهٔ فایل ارائه تأثیر می‌گذارند؟

به‌طور جزئی. افکت‌های WordArt مانند سایه‌ها، Glow و پرهای گرادیان ممکن است به‌دلیل اضافه شدن متادیتای قالب‌بندی، کمی اندازهٔ فایل را افزایش دهند، اما این اختلاف معمولاً ناچیز است.

### آیا می‌توانم نتیجهٔ افکت‌های WordArt را بدون ذخیرهٔ ارائه پیش‌نمایش کنم؟

بله، می‌توانید اسلایدهای حاوی WordArt را به تصویر (مثلاً PNG، JPEG) رندر کنید با استفاده از متد `getImage` از اینترفیس‌های [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) یا [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/). این امکان پیش‌نمایش نتیجه را در‑حافظه یا روی صفحه قبل از ذخیره یا صادرات کل ارائه فراهم می‌کند.