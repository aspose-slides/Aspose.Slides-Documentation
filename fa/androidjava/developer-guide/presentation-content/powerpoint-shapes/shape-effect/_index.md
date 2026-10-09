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
- افکت تابش
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای Android از طریق Java—اسلایدهای برجسته و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکردن‌ها](/slides/fa/androidjava/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قابل باور روی یک شکل ایجاد کنید، تابش شکل را گسترده کنید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت را فراهم می‌کند که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **پیش‌تنظیم** فراهم می‌کند. گزینه‌های پیش‌تنظیم ترکیبی از دو یا چند افکت هستند که به خوبی شناخته شده‌اند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نیست.

Aspose.Slides ویژگی‌ها و متدهایی را تحت کلاس [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for Android via Java از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو را برای مطابقت با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته کردن یک کارت یا پنل نسبت به پس‌زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و احساس می‌کند که شکل بالا آمده از اسلاید است. رنگ، جهت، فاصله و شعاع محو آن را برای مطابقت با نورپردازی و سبک قالب خود تنظیم کنید.

این کد Java نشان می‌دهد چگونه [اثر سایه بیرونی](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) را بر روی یک مستطیل اعمال کنید:

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

هنگام بازتولید استایل بصری قالب، از سایه داخلی برای ایجاد ظاهر فرو رفته کارت یا پنل استفاده کنید. سایه بیرونی بیرون شکل گسترش می‌یابد و آن را بالا آورده نشان می‌دهد، در حالی که سایه داخلی داخل لبه‌های آن را سایه‌دار می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) را فراخوانی کنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) بازگشت داده می‌شود را پیکربندی کنید. مقادیر بزرگتر شعاع محو، لبه‌های نرم‌تری تولید می‌کنند.

این مثال Java یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه است، فاصله آن ۷ پوینت و شعاع محو آن ۶ پوینت می‌باشد:

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

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) را بر روی فرمت افکت شکل فراخوانی کنید.

## **اعمال افکت بازتاب**

برای اعمال افکت بازتاب در Aspose.Slides برای Android از طریق Java، می‌توانید بازتابی شبیه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با ارائه ظاهر صیقلی‌تر و پیشرفته‌تر به اشکال ارتقا می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع در چندین عنصر برای یک طراحی یکپارچه را فراهم می‌کند.

این کد Java نشان می‌دهد چگونه [اثر بازتاب](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) را بر روی یک شکل اعمال کنید:

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

## **اعمال افکت تابش**

برای اعمال افکت تابش به یک شکل در Aspose.Slides برای Android از طریق Java، می‌توانید هاله‌ای نرم و درخشان اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کم‌حجم آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Java نشان می‌دهد چگونه [اثر تابش](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) را بر روی یک شکل اعمال کنید:

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

![اثرتابش](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Android از طریق Java، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ظریف‌تر و باارزش‌تری اضافه می‌کند که برای طرح‌هایی که به ظاهر ملایم و نرم نیاز دارند مناسب است. می‌توانید به سادگی پارامترهایی مانند شعاع را تنظیم کنید تا افکت مطلوب را بر روی اشکال مختلف در ارائه خود به دست آورید.

این کد Java نشان می‌دهد چگونه [اثر لبه‌های نرم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) را بر روی یک شکل اعمال کنید:

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

## **پرسش‌های متداول**

**آیا می‌توانم چندین افکت را به یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلف مانند سایه، بازتاب و تابش را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد شود.

**به چه شکل‌هایی می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع شکل‌ها، از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی‌شده اعمال کنید. افکت بر تمام گروه اعمال می‌شود.