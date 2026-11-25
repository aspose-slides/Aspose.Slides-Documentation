---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از جاوا
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت بازتاب
- افکت نورانی
- افکت لبه‌های نرم
- فرمت افکت
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با افکت‌های پیشرفته شکل با استفاده از Aspose.Slides برای جاوا تبدیل کنید—در عرض ثانیه‌ها اسلایدهای حرفه‌ای و چشم‌گیر ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها متفاوت از [پرکننده‌ها](/slides/fa/java/shape-formatting/#gradient-fill) یا خطوط حاشیه هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قانع‌کننده‌ای بر روی یک شکل ایجاد کنید، نورانی‌سازی شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت ارائه می‌دهد که می‌توانند به اشکال اعمال شوند. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیبات افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **پیش‌تنظیم** ارائه می‌دهد. گزینه‌های پیش‌تنظیم ترکیبی از دو یا چند افکت هستند که شناخته شده است که ظاهر خوبی دارند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) فراهم می‌کند که به شما اجازه می‌دهد همان افکت‌ها را به اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for Java از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو شدن آن‌ها را برای هماهنگی با طرح ارائه‌تان سفارشی کنید.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته کردن یک کارت یا پنل در مقابل پس‌زمینه اسلاید استفاده کنید. سایه خارج از لبه‌های شکل گسترش می‌یابد و این حس را می‌دهد که شکل بر روی اسلاید بالا آمده است. رنگ، جهت، فاصله و شعاع محو شدن آن را برای مطابقت با نورپردازی و سبک الگوی خود تنظیم کنید.

این کد Java نشان می‌دهد چگونه می‌توان [اثر سایه خارجی](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) را به یک مستطیل اعمال کرد:

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

### **اعمال سایه داخلی**

هنگام بازآفرینی سبک بصری یک الگو، از سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهر فرو رفته بدهید. یک سایه خارجی خارج از شکل گسترش می‌یابد و آن را بلند نشان می‌دهد، در حالی که یک سایه داخلی داخل لبه‌هایش را سایه‌دار می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) را فراخوانی کنید، سپس سایه برگردانده شده توسط [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) را پیکربندی کنید. مقادیر بزرگتر شعاع محو شدن لبه‌های نرم‌تری تولید می‌کند.

این مثال Java یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌سازد. جهت سایه ۲۲۵ درجه است، فاصله آن ۷ نقطه و شعاع محو شدن ۶ نقطه است:

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

![مستطیل آبی روشن با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) را بر روی فرمت افکت شکل صدا بزنید.

### **اعمال، تغییر و حذف سایه پیش‌تنظیم شده**

متد [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) را فراخوانی کنید و از [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) استفاده کنید. برای تغییر سبک، پیش‌تنظیم را بر همان شکل تغییر دهید. برای حذف سایه در حالی که پرکننده و خطوط حاشیه حفظ می‌شوند، متد [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) را صدا بزنید.

این مثال چهار مرحله را به‌صورت کنار هم در یک اسلاید نشان می‌دهد. هر دو سایه ۱۰ نقطه جابجا شده‌اند. جهت ۲۲۵° سایه اول را در بالا‑چپ مستطیل قرار می‌دهد و ۴۵° سایه دوم را در پایین‑راست.

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
| ![بدون سایه](preset_shadow_original.png) | ![سایه‌سقوط بالا‑چپ](preset_shadow_top_left.png) | ![سایه‌سقوط پایین‑راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال اثر بازتاب**

برای اعمال یک اثر بازتاب در Aspose.Slides for Java، می‌توانید بازتابی مشابه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این اثر زیبایی ارائه‌های شما را افزایش می‌دهد و ظاهر شکل‌ها را صیقلی و براق می‌کند. پیاده‌سازی آن با کد ساده‌ای آسان است و امکان اعمال سریع در عناصر متعدد برای یک طراحی یکپارچه را فراهم می‌کند.

این کد Java نشان می‌دهد چگونه می‌توان [اثر بازتاب](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) را به یک شکل اعمال کرد:

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

## **اعمال اثر نورانی**

برای اعمال یک اثر نورانی به یک شکل در Aspose.Slides for Java، می‌توانید یک هاله نرم و درخشان اطراف شکل‌ها اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این اثر به برجسته شدن شکل‌ها کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه‌ای آسان است و ظاهر کلی اسلایدهای شما را ارتقا می‌بخشد.

این کد Java نشان می‌دهد چگونه می‌توان [اثر نورانی](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) را به یک شکل اعمال کرد:

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

![اثر نورانی](glow_effect.png)

## **اعمال اثر لبه‌های نرم**

برای اعمال یک اثر لبه‌های نرم در Aspose.Slides for Java، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این اثر ظاهر ملایم‌تری می‌دهد که برای طرح‌هایی که به ظاهر نرم و ظریف نیاز دارند، ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا به اثر مطلوب بر روی اشکال مختلف در ارائه‌تان برسید.

این کد Java نشان می‌دهد چگونه می‌توان [اثر لبه‌های نرم](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) را به یک شکل اعمال کرد:

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

## **اعمال افکت تار شدن**

از تار شدن شکل برای ملایم کردن پرکننده و خط حاشیه شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) را بر روی فرمت افکت شکل صدا بزنید. شعاع بر حسب نقطه (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگتر تاری قوی‌تری تولید می‌کنند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) حاکم بر مرزهای دیداری اثر است. با `false`، تاری به مرزهای اصلی نقاشی‌شده، شامل خط حاشیه، محدود می‌شود. با `true`، تاری می‌تواند فراتر از آن مرزها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکننده، خط حاشیه و ابعاد شکل در تمام حالت‌ها استفاده می‌کند. ردیف بالا `grow = false` و ردیف پایین `grow = true` است.

![مستطیل اصلی مقایسه‌شده با شعاع‌های تاری ۵ و ۱۵ نقطه، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال Java یک مستطیل نارنجی با خط حاشیه آبی تیره ایجاد می‌کند، تاری ۵ نقطه‌ای اعمال می‌کند و سپس با فراخوانی دوباره [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) آن را به ۱۵ نقطه ارتقا می‌دهد. هر دو وضعیت تار شده را ذخیره می‌کند، سپس متد [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) را صدا می‌زند و شکل بدون تاری ذخیره می‌شود.

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

تار شدن شکل همزمان بر پرکننده و خط حاشیه تأثیر می‌گذارد. اثر لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تار شدن سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر کار می‌کنند؛ این مثال تار شدن را مستقیماً بر فرمت افکت شکل بدون تبدیل به تصویر اعمال می‌کند.

## **سؤالات متداول**

**آیا می‌توانم چندین اثر را به یک شکل اعمال کنم؟**

بله، می‌توانید ترکیبی از افکت‌های مختلف مانند سایه، بازتاب و نورانی را بر روی یک شکل اعمال کنید تا ظاهر پویا‌تری به دست آورید.

**به چه شکل‌هایی می‌توانم اثر اعمال کنم؟**

می‌توانید افکت‌ها را به انواع شکل‌ها شامل اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم اثرها را به اشکال گروهی اعمال کنم؟**

بله، می‌توانید اثرها را به اشکال گروهی اعمال کنید. اثر بر کل گروه اعمال خواهد شد.