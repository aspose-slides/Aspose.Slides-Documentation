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
- افکت نوردهی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای اندروید از طریق Java تبدیل کنید — در عرض چند ثانیه اسلایدهای گیرا و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آنها با [fills](/slides/fa/androidjava/shape-formatting/#gradient-fill) یا outlines متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قانع‌کننده روی یک شکل ایجاد کنید، تابش یک شکل را گسترش دهید، و غیره.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint شش افکت ارائه می‌دهد که می‌توان به اشکال اعمال کرد. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید. 

* برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، گزینه‌های PowerPoint در زیر **Preset** قرار دارند. گزینه‌های **Preset** اساساً ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نیست.

Aspose.Slides ویژگی‌ها و روش‌هایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/EffectFormat) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را به اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

این کد Java نشان می‌دهد چگونه افکت سایه بیرونی ([OuterShadowEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) را به یک مستطیل اعمال کنید:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال افکت بازتاب**

این کد Java نشان می‌دهد چگونه افکت بازتاب را به یک شکل اعمال کنید:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال افکت نوردهی**

این کد Java نشان می‌دهد چگونه افکت نوردهی را به یک شکل اعمال کنید:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال افکت لبه‌های نرم**

این کد Java نشان می‌دهد چگونه لبه‌های نرم را به یک شکل اعمال کنید:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**آیا می‌توانم چندین افکت را به یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و نوردهی را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد کنید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را به اشکال مختلفی از جمله خودشکل‌ها (autoshapes)، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را به شکل‌های گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را به شکل‌های گروه‌بندی‌شده اعمال کنید. افکت به تمام گروه اعمال خواهد شد.