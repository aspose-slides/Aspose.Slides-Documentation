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
- افکت انعکاس
- افکت درخشندگی
- تغییر شکل WordArt
- افکت سه‌بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Java. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن‌های حرفه‌ای در Java بهبود بخشند."
---
## **بررسی کلی**

تأثیرات WordArt به شما امکان می‌دهند متن را با پرکردن‌ها، خطوط حاشیه‌ای، سایه‌ها، انعکاس‌ها، درخشندگی، تغییر شکل‌ها و قالب‌بندی سه‌بعدی استایل کنید. این مقاله توضیح می‌دهد که چگونه این تأثیرات را در ارائه‌های PowerPoint با استفاده از Aspose.Slides for Java ایجاد و سفارشی کنید، بدون نیاز به نصب Microsoft Office.

## **ایجاد یک قالب WordArt ساده و اعمال آن بر متن**

مثال‌های زیر یک سبک WordArt ساده را با تنظیم متن، قلم، پرکردن الگو و حاشیه ایجاد می‌کنند.

هر مثال یک ارائه جدید ایجاد می‌کند و یک مستطیل را به اولین اسلاید آن اضافه می‌نماید؛ نیازی به فایل ورودی نیست. مثال اول متن را به «Aspose.Slides» تنظیم می‌کند. موقعیت و ابعاد شکل بر حسب نقاط اندازه‌گیری می‌شوند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

قلم را به Arial Black با اندازه ۳۶ نقطه تنظیم کنید تا قالب‌بندی بیشتر به چشم بیاید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

یک الگوی [SmallGrid](https://reference.aspose.com/slides/fa/java/com.aspose.slides/patternstyle/#SmallGrid) با پیش‌زمینه نارنجی تیره و پس‌زمینه سفید اعمال کنید، سپس یک حاشیه متن سیاه با عرض ۱ نقطه اضافه کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

متن حاصل:

![قالب ساده WordArt](WordArt_template.png)

## **اعمال سایر تأثیرات WordArt**

مثال‌های زیر نشان می‌دهند که چگونه سایه‌ها، انعکاس‌ها، درخشندگی، تغییر شکل‌ها و تأثیرات سه‌بعدی را بر متن اعمال کنید.

### **اعمال تأثیرات سایه خارجی**

یک سایه خارجی عمق بیشتری می‌بخشد با قرار دادن سایه پشت متن. می‌توانید رنگ، جهت، فاصله، شعاع محو، مقیاس و کج‌نمایی آن را سفارشی کنید.

این مثال [enableOuterShadowEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) را فراخوانی می‌کند و سایه‌ای سیاه با شعاع محو ۴‑نقطه، جهت ۲۳۰ درجه و فاصله ۳۰‑نقطه تنظیم می‌نماید. مقادیر مقیاس ۱۰۰ سایز سایه را حفظ می‌کند، در حالی که کج‌نمایی افقی آن را ۲۰ درجه می‌چرخاند. تبدیل آلفا شفافیت آن را به ۳۲٪ تنظیم می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

متن حاصل:

![اثر سایه خارجی](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- وقتی سایه‌های خارجی و پیش‌تنظیم‌شده همزمان استفاده شوند، تنها سایه خارجی اعمال می‌شود.
- اگر سایه‌های خارجی و داخلی همزمان به کار بروند، اثر نهایی به نسخه PowerPoint وابسته است؛ برای مثال در PowerPoint 2013 اثر دو برابر می‌شود، در حالی که در PowerPoint 2007 تنها سایه خارجی اعمال می‌شود.
{{% /alert %}}

### **اعمال تأثیرات انعکاس**

یک انعکاس یک نسخهٔ آینه‌ای از متن ایجاد می‌کند. می‌توانید موقعیت، مقیاس، محو و شفافیت آن را تنظیم کنید تا ظاهر موردنظر را به دست آورید.

این مثال [enableReflectionEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effectformat/#enableReflectionEffect--) را فراخوانی می‌کند و انعکاس را به صورت عمودی با مقیاس ‑۱۰۰٪ می‌چرخاند. از شعاع محو ۰٫۵ نقطه و فاصله ۴٫۷۲ نقطه استفاده می‌کند. شفافیت از ۶۰٪ به ۰٫۹٪ بین موقعیت‌های ۰٪ تا ۶۰٪ در طول انعکاس کاهش می‌یابد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

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
    presentation.dispose();
}
```

متن حاصل:

![اثر انعکاس](reflection_effect.png)

### **اعمال تأثیرات درخشندگی**

درخشندگی یک حاشیهٔ رنگی نرم اطراف متن اضافه می‌کند. می‌توانید رنگ، شفافیت و شعاع را برای کنترل اثر تنظیم کنید.

این مثال [enableGlowEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effectformat/#enableGlowEffect--) را فراخوانی می‌کند و یک درخشندگی قرمز با شفافیت ۵۴٪ و شعاع ۷ نقطه اعمال می‌نماید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

متن حاصل:

![اثر درخشندگی](glow_effect.png)

### **اعمال تغییرات WordArt**

تغییرات WordArt متن را خم، کشیده یا منحنی می‌کند.

[setTransform](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframeformat/#setTransform-int-) را به [ArchUpPour](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textshapetype/#ArchUpPour) تنظیم کنید تا کل قاب متن به سمت بالا منحنی شود:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

متن حاصل:

![تغییر شکل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java مجموعه‌ای از انواع پیش‌تعریف‌شدهٔ [transformation types](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textshapetype/) را فراهم می‌کند.
{{% /alert %}}

### **اعمال تأثیرات سه‌بعدی بر شکل‌ها و متن**

می‌توانید تأثیرات سه‌بعدی را بر یک شکل یا متن آن اعمال کنید. برجسته‌سازی‌ها، استخراج، نورپردازی و تنظیمات دوربین ظاهر نهایی را کنترل می‌کنند.

مثال زیر از [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) برای افزودن برجسته‌سازی‌های دایره‌ای، استخراج نارنجی و کانتور قرمز تیره به مستطیل استفاده می‌کند. ابعاد برجسته، ارتفاع استخراج، عرض کانتور و عمق بر حسب نقاط اندازه‌گیری می‌شوند. یک مادهٔ پلاستیکی، نورپردازی متعادل که ۴۰ درجه حول محور Z چرخیده و یک دوربین پرسپکتیو ظاهر آن را تعریف می‌کنند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

شکل حاصل:

![اثر سه‌بعدی شکل](shape_3D_effect.png)

این مثال قالب‌بندی سه‌بعدی مشابهی را بر متن از طریق [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframeformat/#getThreeDFormat--) اعمال می‌کند. برجسته‌سازی‌های کوچکتر لبه‌های حروف را شکل می‌دهند، در حالی که استخراج و نورپردازی به متن عمق می‌بخشند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

متن حاصل:

![اثر سه‌بعدی متن](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
اعمال تأثیرات سه‌بعدی بر متن یا شکل‌های آن—و تعامل بین این اثرات—بر اساس قوانین خاصی انجام می‌شود. صحنه‌ای را در نظر بگیرید که هم متن و هم شکل حاوی آن را شامل می‌شود. یک اثر سه‌بعدی شامل نمایش سه‌بعدی شیء و صحنه‌ای است که در آن قرار دارد.

- اگر صحنه‌ای برای هر دو، شکل و متن تعیین شود، صحنهٔ شکل اولویت دارد و صحنهٔ متن نادیده گرفته می‌شود.
- اگر شکل صحنهٔ خود را نداشته باشد اما نمایش سه‌بعدی داشته باشد، صحنهٔ متن استفاده می‌شود.
- اگر شکل اصلاً هیچ اثر سه‌بعدی نداشته باشد، به عنوان مسطح در نظر گرفته می‌شود و اثر سه‌بعدی فقط بر متن اعمال می‌شود.

این رفتارها مربوط به متدهای [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/#getLightRig--) و [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/#getCamera--) هستند.
{{% /alert %}}

برای نگه داشتن متن به صورت صاف و قابل خواندن در حالی که قالب‌بندی سه‌بعدی شکل حفظ می‌شود، به [Keep Text Flat on a 3D Shape](/slides/fa/java/3d-presentation/) برای مقایسهٔ هر دو تنظیم و مثال کامل Java مراجعه کنید.

## **سؤالات متداول**

**آیا می‌توانم از تأثیرات WordArt با قلم‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides for Java از یونیکد پشتیبانی می‌کند و با تمام قلم‌ها و اسکریپت‌های اصلی کار می‌کند. تأثیرات WordArt نظیر سایه، پرکردن و حاشیه بدون توجه به زبان قابل اعمال هستند، اگرچه در دسترس بودن قلم و رندر ممکن است به قلم‌های سیستم وابسته باشد.

**آیا می‌توانم تأثیرات WordArt را بر عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید تأثیرات WordArt را بر اشکال موجود در اسلایدهای مستر، شامل فضاهای نگهدارندهٔ عنوان، پاورقی یا متن پس‌زمینه، اعمال کنید. تغییرات ایجاد شده در طرح مستر در تمام اسلایدهای وابسته بازتاب خواهد یافت.

**آیا تأثیرات WordArt بر حجم فایل ارائه تأثیر می‌گذارد؟**

کمی. تأثیرات WordArt مانند سایه‌ها، درخشندگی و پرکردن‌های گرادیان ممکن است به دلیل افزودن متادیتاهای قالب‌بندی حجم فایل را کمی افزایش دهند، اما این تفاوت معمولاً قابل‌توجه نیست.

**آیا می‌توانم نتیجهٔ تأثیرات WordArt را بدون ذخیرهٔ ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای حاوی WordArt را به تصاویر (مانند PNG، JPEG) با استفاده از [ISlide.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage--) رندر کنید، یا اشکال منفرد را با [IShape.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getImage--) رندر کنید. این امکان پیش‌نمایش نتیجه در حافظه یا روی صفحه نمایش را پیش از ذخیره یا خروجی گرفتن از ارائه کامل می‌دهد.