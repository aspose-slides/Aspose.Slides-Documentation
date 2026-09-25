---
title: ایجاد و اعمال اثرات WordArt در اندروید
linktitle: WordArt
type: docs
weight: 110
url: /fa/androidjava/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- اثر WordArt
- اثر سایه
- اثر بازتاب
- اثر تابش
- تبدیل WordArt
- اثر 3D
- اثر سایه بیرونی
- اثر سایه داخلی
- Android
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اثرات WordArt در Aspose.Slides برای اندروید با جاوا. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در اندروید بهبود دهند."
---
## **نمای کلی**

تاثیرات WordArt به شما امکان می‌دهد متن را با پرکننده‌ها، خطوط حاشیه، سایه‌ها، بازتاب‌ها، تابش، تبدیل‌ها و قالب‌بندی سه‌بعدی سبک بدهید. این مقاله توضیح می‌دهد چگونه این تاثیرات را در ارائه‌های PowerPoint با استفاده از Aspose.Slides for Android via Java ایجاد و سفارشی کنید، بدون نیاز به نصب Microsoft Office.

## **ایجاد یک قالب WordArt ساده و اعمال آن بر متن**

مثال‌های زیر یک سبک ساده WordArt را با تنظیم متن، قلم، پرکننده الگو و خط حاشیه می‌سازند.

هر مثال یک ارائه جدید ایجاد می‌کند و یک مستطیل را به اسلاید اول آن اضافه می‌کند؛ نیازی به فایل ورودی نیست. مثال اول متن را به «Aspose.Slides» تنظیم می‌کند. موقعیت و ابعاد شکل بر حسب نقطه اندازه‌گیری می‌شوند:

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

قلم را به Arial Black با اندازه 36 نقطه تنظیم کنید تا قالب‌بندی بیشتر مشهود باشد:

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

یک الگوی [SmallGrid](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/patternstyle/#SmallGrid) با پیش‌زمینه نارنجی تیره و پس‌زمینه سفید اعمال کنید، سپس یک خط حاشیه متنی سیاه با ضخامت 1 نقطه اضافه کنید:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int darkOrange = Color.rgb(255, 140, 0);
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

## **اعمال سایر تاثیرات WordArt**

مثال‌های زیر نشان می‌دهد چگونه سایه‌ها، بازتاب‌ها، تابش، تبدیل‌ها و اثرات سه‌بعدی را بر متن اعمال کنید.

### **اعمال اثرات سایه بیرونی**

سایه بیرونی با قرار دادن سایه‌ای پشت متن، عمق ایجاد می‌کند. می‌توانید رنگ، جهت، فاصله، شعاع محو، مقیاس و انحراف آن را سفارشی کنید.

این مثال متد [enableOuterShadowEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) را فراخوانی می‌کند و یک سایه سیاه با شعاع محو 4 نقطه، جهت 230 درجه و فاصله 30 نقطه تنظیم می‌کند. مقادیر مقیاس 100 سایه را به همان اندازه حفظ می‌کند، در حالی که انحراف افقی آن را 20 درجه می‌انداخت. تبدیل آلفا شفافیت آن را به 32٪ تنظیم می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![اثر سایه بیرونی](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- زمانی که سایه‌های بیرونی و پیش‌تنظیم شده همزمان استفاده شوند، فقط سایه بیرونی اعمال می‌شود.
- اگر سایه‌های بیرونی و داخلی همزمان به کار روند، اثر نهایی به نسخه PowerPoint وابسته است. به عنوان مثال، در PowerPoint 2013 اثر دو برابر می‌شود، در حالی که در PowerPoint 2007 فقط سایه بیرونی اعمال می‌شود.
{{% /alert %}}

### **اعمال اثرات بازتاب**

بازتاب یک نسخه آینه‌ای از متن ایجاد می‌کند. می‌توانید موقعیت، مقیاس، محو و شفافیت آن را تنظیم کنید تا ظاهر مورد نظر را به دست آورید.

این مثال متد [enableReflectionEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) را فراخوانی می‌کند و بازتاب را به صورت عمودی معکوس با مقیاس -100٪ می‌کند. از شعاع محو 0.5 نقطه و فاصله 4.72 نقطه استفاده می‌کند. شفافیت از 60٪ به 0.9٪ بین موقعیت‌های 0٪ تا 60٪ در طول بازتاب کاهش می‌یابد:

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

![اثر بازتاب](reflection_effect.png)

### **اعمال اثرات تابش**

تابش یک خط حاشیه رنگی نرم دور متن ایجاد می‌کند. می‌توانید رنگ، شفافیت و شعاع آن را تنظیم کنید.

این مثال متد [enableGlowEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) را فراخوانی می‌کند و یک تابش قرمز با شفافیت 54٪ و شعاع 7 نقطه اعمال می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![اثر تابش](glow_effect.png)

### **اعمال تبدیل‌های WordArt**

تبدیل‌های WordArt متن را خم، کشیده یا پیچ می‌دهند.

متد [setTransform](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) را به [ArchUpPour](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textshapetype/#ArchUpPour) تنظیم کنید تا کل قاب متن به سمت بالا منحنی شود:

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

![تبدیل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java مجموعه‌ای از [انواع تبدیل پیش‌تعریف‌شده](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textshapetype/) را فراهم می‌کند.
{{% /alert %}}

### **اعمال اثرات سه‌بعدی بر اشکال و متن**

می‌توانید اثرات سه‌بعدی را بر یک شکل یا بر متن آن اعمال کنید. برجسته‌سازی‌ها، استخراج، نورپردازی و تنظیمات دوربین ظاهر نهایی را کنترل می‌کنند.

مثال زیر از [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) برای افزودن برجسته‌های دایره‌ای، استخراج نارنجی و خطوط دوری قرمز تیره به مستطیل استفاده می‌کند. ابعاد برجسته، ارتفاع استخراج، عرض دوری و عمق بر حسب نقطه اندازه‌گیری می‌شوند. مواد پلاستیکی، نورپردازی متوازن چرخانده شده به‌صورت 40 درجه دور محور Z، و دوربین پرسپکتیو ظاهر را تعریف می‌کنند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
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

این مثال قالب‌بندی سه‌بعدی مشابهی را بر متن از طریق [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--) اعمال می‌کند. برجسته‌های کوچکتر لبه‌های حروف را شکل می‌دهند، در حالی که استخراج و نورپردازی به متن عمق می‌بخشند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
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
اعمال اثرات سه‌بعدی بر متن یا شکل‌هایشان—و تعامل بین این اثرات—به‌صورت قوانین خاصی کنترل می‌شود. صحنه‌ای را در نظر بگیرید که هم متن و هم شکل شامل آن باشد. یک اثر سه‌بعدی شامل نمای سه‌بعدی شیء و صحنه‌ای است که در آن قرار دارد.

- اگر صحنه‌ای برای هر دو، شکل و متن، تنظیم شده باشد، صحنه شکل اولویت دارد و صحنه متن نادیده گرفته می‌شود.
- اگر شکل صحنه‌ای نداشته باشد اما نمای سه‌بعدی داشته باشد، صحنه متن استفاده می‌شود.
- اگر شکل هیچ اثر سه‌بعدی نداشته باشد، به‌عنوان صاف در نظر گرفته می‌شود و اثر سه‌بعدی فقط بر متن اعمال می‌شود.

این رفتارها به روش‌های [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/#getLightRig--) و [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/#getCamera--) مرتبط هستند.
{{% /alert %}}

برای حفظ متن به‌صورت صاف و قابل خواندن در حالی که قالب‌بندی سه‌بعدی شکل حفظ می‌شود، به صفحه [Keep Text Flat on a 3D Shape](/slides/fa/androidjava/3d-presentation/) مراجعه کنید تا مقایسه تنظیمات و مثال کامل Java را ببینید.

## **FAQ**

**آیا می‌توانم اثرات WordArt را با قلم‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides for Android via Java از یونیکد پشتیبانی می‌کند و با تمام قلم‌ها و اسکریپت‌های عمده کار می‌کند. اثرات WordArt مانند سایه، پرکننده و خط حاشیه بدون توجه به زبان قابل اعمال هستند، اگرچه در دسترس بودن قلم و رندرینگ ممکن است به قلم‌های سیستم وابسته باشد.

**آیا می‌توانم اثرات WordArt را بر عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید اثرات WordArt را بر اشکال موجود در اسلایدهای مستر، شامل نگه‌دارنده‌های عنوان، پاورقی‌ها یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده به‌صورت خودکار در تمام اسلایدهای مرتبط بازتاب می‌یابد.

**آیا اثرات WordArt بر حجم فایل ارائه تأثیر می‌گذارد؟**

به‌صورت جزئی. اثراتی مانند سایه‌ها، تابش‌ها و پرکننده‌های گرادیان ممکن است حجم فایل را به دلیل اضافه شدن متادیتای قالب‌بندی کمی افزایش دهند، اما این تفاوت معمولاً ناچیز است.

**آیا می‌توانم نتیجه اثرات WordArt را بدون ذخیره ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای حاوی WordArt را به تصاویر (مانند PNG یا JPEG) با استفاده از [ISlide.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage--) رندر کنید، یا اشکال فردی را با [IShape.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getImage--) رندر کنید. این امکان پیش‌نمایش نتیجه در حافظه یا روی صفحه نمایش را پیش از ذخیره یا استخراج کل ارائه فراهم می‌کند.