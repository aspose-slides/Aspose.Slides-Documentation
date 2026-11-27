---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از جاوا
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت تابش
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- جاوا
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفتهٔ شکل در Aspose.Slides برای جاوا تبدیل کنید—اسلایدهای چشم‌گیر و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آنها متفاوت از [پرکردن](/slides/fa/java/shape-formatting/#gradient-fill) یا خطوط حاشیه‌ای هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های متقاعدکننده‌ای بر روی یک شکل ایجاد کنید، نورِ تابشی (glow) یک شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت مختلف ارائه می‌دهد که می‌توان بر روی شکل‌ها اعمال کرد. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیبات افکت‌ها نسبت به دیگران بهتر به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** فراهم می‌کند. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که ظاهر خوبی دارند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمون یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهد بود.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهند همان افکت‌ها را بر روی شکل‌ها در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for Java از سایه‌های خارجی و داخلی برای شکل‌ها پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو شدن آنها را برای هماهنگ‌کردن با طراحی ارائه خود سفارشی کنید.

### **اعمال سایهٔ خارجی**

از سایهٔ خارجی برای برجسته کردن یک کارت یا پنل نسبت به پس‌زمینه اسلاید استفاده کنید. سایه از مرزهای شکل فراتر می‌رود و این حس را ایجاد می‌کند که شکل بالاتر از اسلاید قرار دارد. رنگ، جهت، فاصله و شعاع محو شدن آن را مطابق نوردهی و استایل قالب خود تنظیم کنید.

این کد Java نشان می‌دهد چگونه می‌توانید [اثر سایهٔ خارجی](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) را بر یک مستطیل اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![اثر سایه](shadow_effect.png)

#### **کنترل جهت سایه هنگام چرخش شکل**

به طور پیش‌فرض، سایهٔ خارجی همراه با شکل می‌چرخد. برای اینکه شکل‌های با چرخش‌های مختلف نور از همان جهت بی‌نوردهی شوند، متد [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) را با مقدار `false` فراخوانی کنید و از [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) برای تنظیم جهت یکسان سایه‌ها استفاده کنید.

مثال دو فلش آبی با سایهٔ خاکستری که 42 پوینت به سمت راست (0°) جابجا شده‌اند، ایجاد می‌کند. سپس اسلاید را تکثیر می‌کند و هر دو فلش را 90° ساعتگرد می‌چرخاند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
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

در اسلاید دوم، فلش سمت چپ سایهٔ خود را به سمت پایین می‌اندازد، در حالی که فلش سمت راست همچنان سایهٔ خود را به سمت راست می‌اندازد. جهت پیکربندی شده برای هر دو سایه 0° باقی می‌ماند.

![رندر PowerPoint قبل و بعد از چرخش 90°. هر دو سایه از سمت راست شروع می‌شوند. بعد از چرخش، سایه زیر فلش چپ می‌آید و در سمت راست فلش راست می‌ماند.](arrow-shadow-rotation.png)

### **اعمال سایهٔ داخلی**

هنگام بازآفرینی استایل بصری یک قالب، از سایهٔ داخلی برای ایجاد ظاهر مدفون یک کارت یا پنل استفاده کنید. سایهٔ خارجی خارج از شکل گسترش می‌یابد و آن را بالاتر نشان می‌دهد، در حالی که سایهٔ داخلی لبه‌های داخلی را رنگ می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) را فراخوانی کنید، سپس سایهٔ بازگردانده‌شده توسط [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) را پیکربندی کنید. مقادیر بزرگتر شعاع محو، لبه‌های نرم‌تری تولید می‌کند.

این مثال Java یک کارت آبی روشن با سایهٔ داخلی خاکستری تیره ایجاد می‌کند و آن را به عنوان یک فایل PPTX ذخیره می‌نماید. جهت سایه 225 درجه، فاصله 7 پوینت و شعاع محو 6 پوینت است:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![مستطیل آبی روشن با سایهٔ داخلی](inner_shadow_effect.png)

برای حذف سایهٔ داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) را بر فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف پیش‌تنظیم سایه**

متد [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) را فراخوانی کنید و از [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) استفاده نمایید. برای تعویض سبک‌ها، پیش‌تنظیم را بر همان شکل تغییر دهید. برای حذف سایه و حفظ پر و حاشیه، متد [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) را فراخوانی کنید.

این مثال چهار مرحله را به صورت کنار هم در یک اسلاید نشان می‌دهد. هر دو سایه 10 پوینت جابجا شده‌اند. جهت 225° نخستین سایه را بالای چپ مستطیل قرار می‌دهد و 45° دومین سایه را پایین‌راست.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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
| ![بدون سایه](preset_shadow_original.png) | ![سایه‌افتادگی بالاچپ](preset_shadow_top_left.png) | ![سایه‌افتادگی پایین‌راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides for Java، می‌توانید انعکاس آینه‌ای به شکل‌ها اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت ظاهر ارائه‌های شما را با دادن ظاهری صیقلی و شیک تقویت می‌کند. پیاده‌سازی آن با کد ساده آسان است و امکان استفاده سریع در عناصر متعدد برای داشتن طراحی یک‌دست را فراهم می‌کند.

این کد Java نشان می‌دهد چگونه می‌توانید [اثر انعکاس](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) را بر یک شکل اعمال کنید:

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

![اثر انعکاس](reflection_effect.png)

## **اعمال افکت تابش (Glow)**

برای اعمال افکت تابش به یک شکل در Aspose.Slides for Java، می‌توانید هالهٔ نرم و نورانی‌ای اطراف شکل اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته‌کردن شکل‌ها کمک می‌کند و عنصر بصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. پیاده‌سازی آن با کد حداقل آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Java نشان می‌دهد چگونه می‌توانید [اثر تابش](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) را بر یک شکل اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![اثر تابش](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides for Java، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ملایم‌تر و دقیق‌تری می‌دهد که برای طرح‌هایی که نیاز به ظاهر لطیف دارند مناسب است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را در انواع شکل‌ها در ارائه خود به دست آورید.

این کد Java نشان می‌دهد چگونه می‌توانید [اثر لبه‌های نرم](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) را بر یک شکل اعمال کنید:

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

![اثر لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت محو (Blur)**

از محو شدن شکل برای نرم کردن پر و حاشیهٔ یک شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) را بر فرمت افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگتر محو قوی‌تری تولید می‌کند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) مرزهای قابل مشاهدهٔ افکت را کنترل می‌کند. با `false`، محو شدن به حدود نقاشی اولیه، شامل حاشیه، محدود می‌شود. با `true`، محو می‌تواند فراتر از آن حدود گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهد.

مقایسهٔ زیر از همان پر، حاشیه و ابعاد شکل در تمام حالات استفاده می‌کند. ردیف بالا `grow = false` را به کار گرفته؛ ردیف پایین `grow = true`.

![مستطیل اصلی مقایسه‌شده با شعاع‌های محو 5 و 15 پوینت، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال Java یک مستطیل نارنجی با حاشیهٔ آبی تیره ایجاد می‌کند، محو 5 پوینتی اعمال می‌نماید و سپس با فراخوانی دوباره [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) به 15 پوینت تغییر می‌دهد. هر دو حالت محو را ذخیره می‌کند، سپس با فراخوانی [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) شکل بدون محو ذخیره می‌شود.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

محو شدن شکل هم پر و هم حاشیه را به‌صورت مشترک تحت تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که محو شدن سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتویات تصویر عمل می‌کنند؛ این مثال محو را مستقیماً بر فرمت افکت شکل اعمال می‌کند بدون تبدیل شکل به تصویر.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و تابش را بر یک شکل ترکیب کنید تا ظاهر دینامیک‌تری به دست آورید.

**کدام اشکال می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر اشکال مختلفی از جمله Autoshapes، نمودارها، جداول، تصاویر، اشیاء SmartArt، اشیاء OLE و غیره اعمال کنید.

**آیا می‌توانم افکت‌ها را بر اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر اشکال گروهی اعمال کنید. افکت بر کل گروه اعمال می‌شود.