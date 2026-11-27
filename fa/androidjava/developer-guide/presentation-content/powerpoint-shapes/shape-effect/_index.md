---
title: اعمال افکت‌های شکل در ارائه‌ها بر روی Android
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/androidjava/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت بازتاب
- افکت درخشندگی
- افکت لبه‌های نرم
- فرمت افکت
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با افکت‌های پیشرفتهٔ شکل با استفاده از Aspose.Slides برای Android از طریق Java تحول دهید—در عرض چند ثانیه اسلایدهای چشم‌نواز و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند به برجسته‌شدن یک شکل کمک کنند، با [پرکننده‌ها](/slides/fa/androidjava/shape-formatting/#gradient-fill) یا حاشیه‌ها متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قابل‌اعتماد روی یک شکل ایجاد کنید، درخشش شکل را گسترش دهید و غیره.

![Shape effect](shape-effect.png)

PowerPoint شش افکت را که می‌توان به شکل‌ها اعمال کرد، فراهم می‌کند. می‌توانید یک یا چند افکت را روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیب‌های دو یا چند افکت هستند که به‌نظر می‌رسد خوب باشند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را به شکل‌ها در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for Android via Java از سایه‌های بیرونی و داخلی برای شکل‌ها پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را برای مطابقت با طراحی ارائه‌تان تنظیم کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته‌کردن یک کارت یا پنل نسبت به پس‌زمینه اسلاید استفاده کنید. سایه از خارج لبه‌های شکل گسترش می‌یابد و این تصور را ایجاد می‌کند که شکل بالای اسلاید قرار دارد. رنگ، جهت، فاصله و شعاع تاری آن را متناسب با نورپردازی و سبک قالب خود تنظیم کنید.

این کد Java نشان می‌دهد چگونه [out​er shadow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) را به یک مستطیل اعمال کنید:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

#### **کنترل جهت سایه هنگامی که شکل می‌چرخد**

به طور پیش‌فرض، سایه بیرونی همراه با شکل می‌چرخد. برای اینکه شکل‌هایی با چرخش‌های متفاوت از همان جهت روشن شوند، با `false` متد [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) را فراخوانی کنید و با [setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-) جهت یکسانی به سایه‌ها بدهید.

این مثال دو فلش آبی با سایه‌های خاکستری که ۴۲ نقطه به سمت راست (۰°) جابجا شده‌اند، ایجاد می‌کند. سپس اسلاید را تکثیر کرده و هر دو فلش را ۹۰° ساعتگرد می‌چرخاند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در اسلاید دوم، فلش چپ سایه‌اش را به سمت پایین می‌اندازد، در حالی که فلش راست همچنان سایه‌اش به سمت راست می‌افکند. جهت تنظیم‌شده برای هر دو سایه ۰° باقی می‌ماند.

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **اعمال سایه داخلی**

زمانی که می‌خواهید سبک بصری یک قالب را بازسازی کنید، از سایه داخلی برای دادن ظاهر فرو رفته به کارت یا پنل استفاده کنید. سایه بیرونی خارج شکل گسترش می‌یابد و آن را بلند نشان می‌دهد، در حالی که سایه داخلی لبه‌های داخلی را رنگ می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) را فراخوانی کنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) برگردانده می‌شود را پیکربندی کنید. مقادیر بزرگ‌تر شعاع تاری منجر به لبه‌های نرم‌تر می‌شود.

این مثال Java یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌صورت فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه، فاصله آن ۷ نقطه و شعاع تاری ۶ نقطه است:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) را بر فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف یک سایه پیش‌تنظیم شده**

متد [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) را فراخوانی کنید و با استفاده از [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) یک [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) را انتخاب کنید. برای تغییر سبک، پیش‌تنظیم را بر همان شکل تغییر دهید. برای حذف سایه در حالی که پرکننده و حاشیه حفظ می‌شوند، متد [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) را صدا بزنید.

این مثال چهار مرحله را در کنار هم روی یک اسلاید نشان می‌دهد. هر دو سایه ۱۰ نقطه جابجا شده‌اند. جهت ۲۲۵° سایهٔ اول را در بالا و سمت چپ مستطیل قرار می‌دهد و ۴۵° سایهٔ دوم را در پایین و سمت راست.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| اصلی | پیش‌تنظیم اول | پیش‌تنظیم دوم | پس از حذف |
| :---: | :---: | :---: | :---: |
| ![بدون سایه](preset_shadow_original.png) | ![سایهٔ قطره‌ای بالا‑چپ](preset_shadow_top_left.png) | ![سایهٔ قطره‌ای پایین‑راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت بازتاب**

برای اعمال افکت بازتاب در Aspose.Slides for Android via Java، می‌توانید بازتابی شبیه آینه به شکل‌ها اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهر صیقل‌دار و برازنده به شکل‌ها ارتقا می‌دهد. پیاده‌سازی آن ساده است و با کد کوتاهی می‌توانید به‌سرعت این افکت را روی عناصر متعدد برای یک طراحی یکنواخت اعمال کنید.

این کد Java نشان می‌دهد چگونه [reflection effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) را به یک شکل اعمال کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflection effect](reflection_effect.png)

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی به یک شکل در Aspose.Slides for Android via Java، می‌توانید هاله‌ای نرم و روشن اطراف شکل اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن شکل‌ها کمک می‌کند و عنصر بصری جذابی به ارائه شما می‌افزاید. پیاده‌سازی آن با کمترین کد امکان‌پذیر است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Java نشان می‌دهد چگونه [glow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) را به یک شکل اعمال کنید:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Glow effect](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides for Android via Java، می‌توانید انتقالی صاف و تاری در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری ظریف‌تر و صیقل‌یافته می‌دهد که برای طراحی‌هایی که نیاز به ظاهر ملایم‌تر دارند، مناسب است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر مطلوب را روی اشکال مختلف در ارائه خود به‌دست آورید.

این کد Java نشان می‌دهد چگونه [soft edges effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) را به یک شکل اعمال کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **اعمال افکت تاری**

از تاری شکل برای نرم کردن پرکننده و حاشیه یک شکل استفاده کنید و در عین حال شکل را قابل ویرایش نگه دارید. متد [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) را بر فرمت افکت شکل صدا بزنید. شعاع بر حسب نقطه (۱/۷۲ اینچ) محاسبه می‌شود: مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر تاری شدیدتری ایجاد می‌کنند. شعاع صفر ظاهر را تغییری نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) مرزهای قابل مشاهدهٔ اثر را کنترل می‌کند. با `false`، تاری به مرزهای رنگ‌شدهٔ اصلی، شامل حاشیه، محدود می‌شود. با `true`، تاری می‌تواند از این مرزها فراتر برود. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهد.

مقایسهٔ زیر از همان پرکننده، حاشیه و ابعاد شکل در تمام حالت‌ها استفاده می‌کند. ردیف بالایی `grow = false` و ردیف پایینی `grow = true` را نشان می‌دهد.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

این مثال Java یک مستطیل نارنجی با حاشیه آبی تیره ایجاد می‌کند، تاری ۵ نقطه‌ای اعمال می‌کند و سپس با فراخوانی دوباره [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) به تاری ۱۵ نقطه‌ای به‌روزرسانی می‌کند. هر دو حالت تاری را ذخیره می‌نماید، سپس با فراخوانی [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) شکل بدون تاری ذخیره می‌شود.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تاری شکل هم پرکننده و هم حاشیه را تحت تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر روی محتوای تصویر عمل می‌کنند؛ این مثال تاری را مستقیماً بر فرمت افکت شکل بدون تبدیل به تصویر اعمال می‌کند.

## **سؤال‌های متداول**

**آیا می‌توانم چندین افکت را به یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و درخشندگی را روی یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد کنید.

**کدام شکل‌ها می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را به انواع شکل‌ها از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را به اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را به اشکال گروهی اعمال کنید. افکت بر کل گروه اعمال خواهد شد.