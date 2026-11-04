---
title: اعمال افکت‌های شکل در ارائه‌ها بر روی اندروید
linktitle: اثر شکل
type: docs
weight: 30
url: /fa/androidjava/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت درخشندگی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای اندروید از طریق Java تغییر شکل دهید—در عرض چند ثانیه اسلایدهای چشم‌نوازی و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، این افکت‌ها با [پرکننده‌ها](/slides/fa/androidjava/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قانع‌کننده‌ای بر روی یک شکل ایجاد کنید، درخشانی شکل را گسترش دهید، و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت را ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت‌ها نسبت به سایرین زیباتر به‌نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **پیش تنظیم** ارائه می‌دهد. گزینه‌های پیش تنظیم ترکیبی از دو یا چند افکت هستند که به‌نظر می‌رسد خوب‌اند. به این ترتیب، با انتخاب یک پیش تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Android از طریق Java از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را به‌گونه‌ای تنظیم کنید که با طراحی ارائه شما مطابقت داشته باشد.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته کردن یک کارت یا پنل در برابر پس‌زمینه اسلاید استفاده کنید. این سایه از مرزهای شکل فراتر می‌رود و این تصور را ایجاد می‌کند که شکل بالای اسلاید قرار دارد. رنگ، جهت، فاصله و شعاع تاری آن را تنظیم کنید تا با نور و سبک قالب شما منطبق باشد.

این کد Java نشان می‌دهد چگونه [افکت سایه خارجی](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) را بر روی یک مستطیل اعمال کنید:

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

![افکت سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازتولید سبک بصری یک قالب، از سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهری نشسته بدهید. یک سایه خارجی خارج از شکل گسترش می‌یابد و باعث می‌شود شکل بالا آمده به نظر برسد، در حالی که یک سایه داخلی لبه‌های داخلی آن را سایه می‌زند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) را فراخوانی کنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) برگردانده می‌شود را پیکربندی کنید. مقادیر بزرگتر شعاع تاری لبه‌های نرم‌تری تولید می‌کنند.

این مثال Java یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌صورت یک فایل PPTX ذخیره می‌کند. جهت سایه ۲۲۵ درجه، فاصله آن ۷ پوینت و شعاع تاری ۶ پوینت است:

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

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) را بر روی قالب افکت شکل فراخوانی کنید.

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Android از طریق Java، می‌توانید بازتابی مشابه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به اشکال ارتقا می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع بر روی عناصر متعدد برای طراحی یکدست را فراهم می‌کند.

این کد Java نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) را بر روی یک شکل اعمال کنید:

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

![افکت انعکاس](reflection_effect.png)

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی بر روی یک شکل در Aspose.Slides برای Android از طریق Java، می‌توانید هاله‌ای نرم و نورانی دور اشکال اضافه کنید و خصوصیت‌هایی مانند رنگ و اندازه را تنظیم نمایید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با حداقل کد آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Java نشان می‌دهد چگونه [افکت درخشندگی](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) را بر روی یک شکل اعمال کنید:

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

![افکت درخشندگی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Android از طریق Java، می‌توانید یک انتقال صاف و تاری دور لبه‌های یک شکل ایجاد کنید. این افکت ظاهری ظریف‌تر و براق‌تر می‌افزاید که برای طرح‌هایی که به ظاهر ملایم و نرم نیاز دارند، ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر دلخواه را در اشکال مختلف ارائه خود به دست آورید.

این کد Java نشان می‌دهد چگونه [افکت لبه‌های نرم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) را بر روی یک شکل اعمال کنید:

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

![افکت لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت تاری**

از تاری شکل برای نرم کردن پرکننده و خط مرزی یک شکل استفاده کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) را بر روی قالب افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید، مقادیر بزرگتر تاری قوی‌تری ایجاد می‌کنند. شعاع صفر ظاهر را تغییری نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) مرزهای قابل مشاهده اثر را کنترل می‌کند. با `false`، تاری به مرزهای اولیه نقاشی شده محدود می‌شود، شامل خط مرزی. با `true`، تاری می‌تواند فراتر از آن مرزها گسترش یابد. هیچ‌کدام از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکننده، خط مرزی و ابعاد شکل در تمام موارد استفاده می‌کند. ردیف بالا از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true` استفاده می‌کند.

![مستطیل اصلی مقایسه‌شده با شعاع‌های تاری ۵ و ۱۵ پوینت، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال Java یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، تاری ۵ پوینتی اعمال می‌کند و سپس با فراخوانی مجدد [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) به تاری ۱۵ پوینت به‌روزرسانی می‌کند. هر دو حالت تاری را ذخیره می‌کند، سپس با فراخوانی [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) شکل را بدون تاری ذخیره می‌کند.

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

تاری شکل بر روی پرکننده و خط مرزی به‌صورت همزمان اثر می‌گذارد. یک افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوی تصویر عمل می‌کنند؛ این مثال تاری را مستقیماً بر قالب افکت شکل اعمال می‌کند بدون این‌که شکل به تصویر تبدیل شود.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری به‌دست آورید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع مختلفی از اشکال اعمال کنید، از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و غیره.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌دار اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌دار اعمال کنید. افکت بر کل گروه اعمال خواهد شد.