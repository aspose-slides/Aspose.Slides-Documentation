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
- افکت درخشندگی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای جاوا تبدیل کنید — اسلایدهای چشم‌نواز و حرفه‌ای را در چند ثانیه بسازید."
---
## **مقدمه**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/java/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های پاورپوینت، می‌توانید انعکاس‌های قانع‌کننده‌ای بر روی یک شکل ایجاد کنید، درخشندگی شکل را گسترش دهید، و غیره.

![افکت شکل](shape-effect.png)

پاورپوینت شش افکت را ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که ظاهری خوب دارند. به این ترتیب، با انتخاب یک پیش تنظیم، نیازی به صرف زمان برای آزمون یا ترکیب افکت‌های مختلف برای پیدا کردن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و روش‌هایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) ارائه می‌دهد که به شما اجازه می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Java از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تار شدن آن‌ها را به گونه‌ای سفارشی کنید که با طراحی ارائه شما هماهنگ باشد.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته کردن یک کارت یا پنل نسبت به پس‌زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل امتداد می‌یابد و این حس را ایجاد می‌کند که شکل بالای اسلاید بالا آمده است. رنگ، جهت، فاصله و شعاع تار شدن آن را تنظیم کنید تا با نورگذاری و سبک قالب شما مطابقت داشته باشد.

این کد جاوا نشان می‌دهد که چگونه می‌توان [افکت سایه خارجی](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) را بر یک مستطیل اعمال کرد:

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

هنگام بازسازی سبک بصری یک قالب، از سایه داخلی برای ایجاد ظاهر فرورفته بر روی کارت یا پنل استفاده کنید. سایه خارجی بیرون از شکل گسترش می‌یابد و آن را بالا آمده نشان می‌دهد، در حالی که سایه داخلی داخل لبه‌های شکل را سایه‌دار می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) را فرا بخوانید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) بازگردانده می‌شود را پیکربندی کنید. مقادیر بزرگ‌تر شعاع تار شدن لبه‌های نرم‌تری تولید می‌کنند.

این مثال جاوا یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به عنوان فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه، فاصله آن ۷ پوینت و شعاع تار شدن ۶ پوینت است:

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

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) را بر روی قالب افکت شکل فراخوانی کنید.

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Java، می‌توانید یک انعکاس شبیه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به اشکال ارتقا می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع بر روی چندین عنصر برای یک طراحی یکنواخت را فراهم می‌کند.

این کد جاوا نشان می‌دهد که چگونه می‌توان [افکت انعکاس](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) را بر یک شکل اعمال کرد:

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

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی بر یک شکل در Aspose.Slides برای Java، می‌توانید یک هاله نرم و روشن در اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک می‌کند و یک عنصر بصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه آسان است و ظاهر کلی اسلایدهای شما را ارتقا می‌دهد.

این کد جاوا نشان می‌دهد که چگونه می‌توان [افکت درخشندگی](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) را بر یک شکل اعمال کرد:

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

![اثر درخشندگی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Java، می‌توانید یک انتقال صاف و تار در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری دقیق‌تر و نرم‌تر می‌بخشد که برای طرح‌هایی که به ظاهر ملایم و نرم نیاز دارند مناسب است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت موردنظر را بر روی اشکال مختلف در ارائه خود به دست آورید.

این کد جاوا نشان می‌دهد که چگونه می‌توان [افکت لبه‌های نرم](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) را بر یک شکل اعمال کرد:

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

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشندگی را بر یک شکل ترکیب کنید تا ظاهری پویا تر ایجاد کنید.

**به چه اشکالی می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر اشکال مختلفی از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر اشکال گروهی اعمال کنید. افکت بر کل گروه اعمال خواهد شد.