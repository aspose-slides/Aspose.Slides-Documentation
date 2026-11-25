---
title: اعمال افکت‌های شکل در ارائه‌ها بر روی اندروید
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
description: "با استفاده از Aspose.Slides برای اندروید از طریق جاوا، فایل‌های PPT و PPTX خود را با افکت‌های پیشرفته شکل تبدیل کنید—اسلایدهای برجسته و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها متفاوت از [پرکننده‌ها](/slides/fa/androidjava/shape-formatting/#gradient-fill) یا خطوط مرزی هستند. با استفاده از افکت‌های پاورپوینت می‌توانید انعکاس‌های قانع‌کننده روی یک شکل ایجاد کنید، درخشندگی شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

پاورپوینت شش افکت ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که ظاهر خوبی دارند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای اندروید از طریق جاوا از سایه‌های بیرونی و درونی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را برای تطبیق با طراحی ارائه‌تان سفارشی کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته کردن یک کارت یا پنل در برابر پس‌زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و احساس می‌کند که شکل از اسلاید برجسته شده است. رنگ، جهت، فاصله و شعاع تاری آن را مطابق با روشنایی و سبک قالب خود تنظیم کنید.

این کد جاوا نشان می‌دهد چگونه [افکت سایه بیرونی](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) را به یک مستطیل اعمال کنید:

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

![اثر سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازتولید سبک بصری یک قالب، از سایه داخلی برای دادن ظاهر فرو رفته به یک کارت یا پنل استفاده کنید. یک سایه بیرونی خارج از شکل گسترش می‌یابد و باعث می‌شود شکل برجسته به نظر برسد، در حالی که سایه داخلی داخل لبه‌های آن را سایه‌دار می‌کند.

Call [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), then configure the shadow returned by [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Larger blur radius values produce softer edges.

این مثال جاوا یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه، فاصله آن ۷ نقطه و شعاع تاری ۶ نقطه است:

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

![مستطیل آبی روشن با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) را روی فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف سایه پیش‌تنظیم‌شده**

Call [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) and use [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) to select a [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/). To switch styles, change the preset on the same shape. Call [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) to remove the shadow while preserving the fill and outline.

این مثال چهار مرحله را به‌صورت کنار هم بر روی یک اسلاید نشان می‌دهد. هر دو سایه با ۱۰ نقطه جابجا شده‌اند. جهت ۲۲۵° سایه اول را بالای چپ مستطیل قرار می‌دهد و ۴۵° دوم را پایین راست.

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
| ![بدون سایه](preset_shadow_original.png) | ![سایه پایین‑چپ](preset_shadow_top_left.png) | ![سایه بالا‑راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت بازتاب**

برای اعمال افکت بازتاب در Aspose.Slides برای اندروید از طریق جاوا، می‌توانید بازتابی مشابه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به اشکال ارتقا می‌بخشد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع بر روی چندین عنصر برای داشتن طراحی یکدست را فراهم می‌کند.

این کد جاوا نشان می‌دهد چگونه [افکت بازتاب](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) را به یک شکل اعمال کنید:

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

![اثر بازتاب](reflection_effect.png)

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی به یک شکل در Aspose.Slides برای اندروید از طریق جاوا، می‌توانید هاله‌ای نرم و روشن دور اشکال ایجاد کنید و خصوصاتی همچون رنگ و اندازه را تنظیم نمایید. این افکت به برجسته شدن اشکال کمک کرده و عنصر بصری جذابی به ارائه شما می‌افزاید. پیاده‌سازی آن با کمترین کد آسان است و ظاهر کلی اسلایدها را ارتقا می‌دهد.

این کد جاوا نشان می‌دهد چگونه [افکت درخشندگی](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) را به یک شکل اعمال کنید:

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

![اثر درخشندگی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای اندروید از طریق جاوا، می‌توانید انتقالی صاف و مات در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ظریف‌تری می‌بخشد که برای طرح‌هایی که نیاز به ظاهر ملایم و نرم دارند مناسب است. می‌توانید به سادگی پارامترهایی مانند شعاع را تنظیم کنید تا اثر دلخواه را بر روی اشکال مختلف در ارائه خود بدست آورید.

این کد جاوا نشان می‌دهد چگونه [افکت لبه‌های نرم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) را به یک شکل اعمال کنید:

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

## **اعمال افکت تاری**

از تاری شکل برای نرم کردن پرکننده و خط مرزی شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. با فراخوانی [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) روی فرمت افکت شکل، می‌توانید شعاع را که بر حسب نقطه (۱/۷۲ اینچ) اندازه‌گیری می‌شود تنظیم کنید: مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگتر باعث تاری قوی‌تر می‌شوند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) مرزهای قابل مشاهده اثر را کنترل می‌کند. با `false`، تاری به مرزهای کشیده شده اولیه، از جمله خط مرزی، محدود می‌شود. با `true`، تاری می‌تواند فراتر از آن مرزها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکننده، خط مرزی و ابعاد شکل برای تمام نمونه‌ها استفاده می‌کند. ردیف بالا `grow = false` دارد؛ ردیف پایین `grow = true` دارد.

![مستطیل اصلی مقایسه شده با شعاع‌های تاری 5 و 15 نقطه، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال جاوا یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، تاری 5 نقطه‌ای اعمال می‌کند و سپس با فراخوانی مجدد [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) آن را به 15 نقطه تغییر می‌دهد. هر دو حالت تاری را ذخیره می‌کند، سپس [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) را فراخوانی کرده و شکل بدون تاری ذخیره می‌شود.

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

تاری شکل هم پرکننده و هم خط مرزی را تحت تاثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را ملایم می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر اعمال می‌شوند؛ این مثال تاری را مستقیماً بر فرمت افکت شکل اعمال می‌کند بدون تبدیل شکل به تصویر.

## **پرسش‌های متداول**

**آیا می‌توانم چندین افکت را بر روی همان شکل اعمال کنم؟**  
بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری بدست آورید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**  
می‌توانید افکت‌ها را به انواع مختلفی از اشکال اعمال کنید، از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی‌شده اعمال کنم؟**  
بله، می‌توانید افکت‌ها را به اشکال گروه‌بندی‌شده اعمال کنید. افکت بر کل گروه اعمال خواهد شد.