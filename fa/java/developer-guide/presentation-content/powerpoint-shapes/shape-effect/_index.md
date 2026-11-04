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
- افکت تاب
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای جاوا—در چند ثانیه اسلایدهای چشم‌نواز و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته‌سازی یک شکل استفاده شوند، آنها متفاوت از [پرکننده‌ها](/slides/fa/java/shape-formatting/#gradient-fill) یا خطوط حاشیه‌ای هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قانع‌کننده بر روی یک شکل ایجاد کنید، تابش شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** فراهم می‌کند. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که به‌طور واضح خوب به نظر می‌آیند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی نیست وقت خود را در تست یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب صرف کنید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Java از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو شدن آن‌ها را طوری تنظیم کنید که با طراحی ارائه شما سازگار باشد.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته‌کردن یک کارت یا پنل در برابر پس‌زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و حس اینکه شکل بالای اسلاید قرار دارد را ایجاد می‌کند. رنگ، جهت، فاصله و شعاع محو شدن آن را طوری تنظیم کنید که با نورپردازی و سبک قالب شما هماهنگ باشد.

این کد Java نشان می‌دهد چگونه [اثر سایه خارجی](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) را بر روی یک مستطیل اعمال کنید:
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

وقتی می‌خواهید استایل بصری یک قالب را بازآفرینی کنید، از سایه داخلی برای ایجاد ظاهر فرو رفته یک کارت یا پنل استفاده کنید. سایه خارجی بیرون شکل گسترش می‌یابد و آن را بالا نمایان می‌کند، در حالی که سایه داخلی داخل لبه‌های آن را سایه‌دار می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) را فراخوانی کنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) برگشت داده می‌شود را پیکربندی کنید. مقادیر بزرگتر شعاع محو شدن لبه‌های نرم‌تری تولید می‌کند.

این مثال Java یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به عنوان فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه است، فاصله آن ۷ پوینت و شعاع محو شدن ۶ پوینت می‌باشد:
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

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) را بر روی فرمت افکت شکل فراخوانی کنید.

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Java، می‌توانید یک انعکاس شبیه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به اشکال افزایش می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع بر روی عناصر متعدد برای یک طراحی یکپارچه را فراهم می‌کند.

این کد Java نشان می‌دهد چگونه [اثر انعکاس](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) را بر روی یک شکل اعمال کنید:
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

## **اعمال افکت تاب**

برای اعمال افکت تاب به یک شکل در Aspose.Slides برای Java، می‌توانید یک هاله نرم و درخشانی در دور اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته‌سازی اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Java نشان می‌دهد چگونه [اثر تاب](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) را بر روی یک شکل اعمال کنید:
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

![اثر تاب](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Java، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری لطیف‌تر و برازندتر می‌افزاید که برای طرح‌هایی که به ظاهر ملایم و نرم نیاز دارند ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را بر روی اشکال مختلف ارائه خود به‌دست آورید.

این کد Java نشان می‌دهد چگونه [اثر لبه‌های نرم](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) را بر روی یک شکل اعمال کنید:
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

## **اعمال افکت محو**

از محو شدن شکل برای نرم کردن پرکننده و حاشیه یک شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) را بر روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگتر محو شدن قوی‌تری تولید می‌کنند. شعاع صفر ظاهر را تغییری نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) مرزهای قابل مشاهده افکت را کنترل می‌کند. با مقدار `false`، محو شدن به مرزهای اولیه رنگ‌آمیزی، شامل حاشیه، محدود می‌شود. با مقدار `true`، محو می‌تواند خارج از آن مرزها گسترش یابد. هیچکدام از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از یک پرکننده، حاشیه و ابعاد شکل ثابت در تمام نمونه‌ها استفاده می‌کند. ردیف بالا از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true` استفاده می‌کند.

![مستطیل اصلی مقایسه‌شده با شعاع‌های محو 5 و 15 پوینت، با غیرفعال و فعال بودن grow](shape_blur_comparison.png)

این مثال Java یک مستطیل نارنجی با حاشیه آبی تیره ایجاد می‌کند، محو 5 پوینت اعمال می‌نماید و سپس با فراخوانی دوباره [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) به محو 15 پوینت به‌روزرسانی می‌کند. هر دو وضعیت محو را ذخیره می‌کند، سپس متد [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) را فراخوانی می‌کند و شکل را بدون محو ذخیره می‌کند.
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

محو شدن شکل هم‌زمان بر پرکننده و حاشیه تأثیر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که محو شدن سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر عمل می‌کنند؛ این مثال محو را مستقیماً بر فرمت افکت شکل بدون تبدیل شکل به تصویر اعمال می‌کند.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و تاب را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری به دست آورید.

**به کدام شکل‌ها می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع شکل‌ها اعمال کنید، از جمله Autoshapeها، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر.

**آیا می‌توانم افکت‌ها را بر روی شکل‌های گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی شکل‌های گروه‌بندی‌شده اعمال کنید. افکت بر کل گروه اعمال خواهد شد.