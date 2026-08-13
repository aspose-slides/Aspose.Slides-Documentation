---
title: مدیریت پس‌زمینه‌های ارائه در جاوا
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/java/presentation-background/
keywords:
- پس‌زمینه ارائه
- پس‌زمینه اسلاید
- رنگ جامد
- رنگ گرادیان
- پس‌زمینه تصویر
- شفافیت پس‌زمینه
- ویژگی‌های پس‌زمینه
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides برای جاوا، پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument تنظیم کنید و با نکات کد، ارائه‌های خود را ارتقا دهید."
---
## **معرفی**

رنگ‌های ساده، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینه اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه یک **اسلاید معمولی** (یک اسلاید تک) یا یک **اسلاید مادر** (که برای چندین اسلاید به‌صورت همزمان اعمال می‌شود) تنظیم کنید.

![PowerPoint background](powerpoint-background.png)

## **تنظیم پس‌زمینه رنگ جامد برای اسلاید معمولی**

Aspose.Slides به شما امکان می‌دهد رنگ جامد را به‌عنوان پس‌زمینه یک اسلاید خاص در ارائه تنظیم کنید — حتی اگر ارائه از اسلاید مادر استفاده کند. این تغییر فقط به اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/backgroundtype/) اسلاید را روی `OwnBackground` تنظیم کنید.
3. نوع پر کردن پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/#getSolidFillColor--) در [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید تا رنگ پس‌زمینه جامد را مشخص کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک رنگ آبی جامد را به‌عنوان پس‌زمینه برای اسلاید معمولی تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // رنگ پس‌زمینه اسلاید را به آبی تنظیم کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینه رنگ جامد برای اسلاید مادر**

Aspose.Slides به شما امکان می‌دهد رنگ جامد را به‌عنوان پس‌زمینه اسلاید مادر در یک ارائه تنظیم کنید. اسلاید مادر به‌عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌نماید، بنابراین هنگامی که یک رنگ جامد را برای پس‌زمینه اسلاید مادر انتخاب کنید، بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/backgroundtype/) اسلاید مادر (از طریق `getMasters`) را روی `OwnBackground` تنظیم کنید.
3. نوع پر کردن پس‌زمینه اسلاید مادر را با استفاده از [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/#getSolidFillColor--) در [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید تا رنگ پس‌زمینه جامد را مشخص کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک رنگ جامد (سبز) را به‌عنوان پس‌زمینه برای اسلاید مادر تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // رنگ پس‌زمینه اسلاید مادر را به سبز تنظیم کنید.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینه گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که توسط تغییر تدریجی رنگ ایجاد می‌شود. هنگامی که به‌عنوان پس‌زمینه اسلاید استفاده شود، گرادیان‌ها می‌توانند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر جلوه دهند. Aspose.Slides به شما امکان می‌دهد رنگ گرادیان را به‌عنوان پس‌زمینه اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/backgroundtype/) اسلاید را روی `OwnBackground` تنظیم کنید.
3. نوع پر کردن پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) به `Gradient` تنظیم کنید.
4. از متد [getGradientFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/#getGradientFormat--) در [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید تا تنظیمات دلخواه گرادیان را پیکربندی کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک رنگ گرادیان را به‌عنوان پس‌زمینه برای اسلاید تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // یک اثر گرادیان را بر روی پس‌زمینه اعمال کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // رنگ‌های گرادیان را اضافه کنید. بدون نقاط گرادیان، پس‌زمینه به یک شیب پیش‌فرض سیاه‑به‑سفید باز می‌گردد.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تصویر به‌عنوان پس‌زمینه اسلاید**

علاوه بر پر کردن‌های جامد و گرادیان، Aspose.Slides به شما امکان می‌دهد از تصاویر به‌عنوان پس‌زمینه اسلاید استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/backgroundtype/) اسلاید را روی `OwnBackground` تنظیم کنید.
3. نوع پر کردن پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) به `Picture` تنظیم کنید.
4. تصویری که می‌خواهید به‌عنوان پس‌زمینه اسلاید استفاده کنید، بارگذاری کنید.
5. تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
6. از متد [getPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/#getPictureFillFormat--) در [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید تا تصویر را به‌عنوان پس‌زمینه اختصاص دهید.
7. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینه برای اسلاید تنظیم کنید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // تنظیم ویژگی‌های تصویر پس‌زمینه.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // بارگذاری تصویر.
    IImage image = Images.fromFile("Tulips.jpg");
    // تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمونه کد زیر نشان می‌دهد چگونه نوع پر کردن پس‌زمینه را به تصویر کاشی‌شده تنظیم کنید و خصوصیات کاشی‌گذاری را تغییر دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // تصویر استفاده شده برای پر کردن پس‌زمینه را تنظیم کنید.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // حالت پر کردن تصویر را بر روی کاشی تنظیم کنید و ویژگی‌های کاشی را تنظیم کنید.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
بیشتر بخوانید: [**تصویر کاشی‌شده به‌عنوان بافت**](/slides/fa/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینهٔ اسلاید را تنظیم کنید تا محتوای اسلاید بیشتر برجسته شود. کد زیر به زبان Java نشان می‌دهد چگونه شفافیت تصویر پس‌زمینهٔ اسلاید را تغییر دهید:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // برای مثال.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دریافت مجموعه عملیات تبدیل تصویر.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // یافتن یک افکت شفافیت ثابت درصد موجود.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // تنظیم مقدار شفافیت جدید.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت مقدار پس‌زمینه اسلاید**

Aspose.Slides رابط [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibackgroundeffectivedata/) را برای بازیابی مقادیر مؤثر پس‌زمینهٔ اسلاید فراهم می‌کند. این رابط، [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و [EffectFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) مؤثر را در دسترس قرار می‌دهد.

با استفاده از متد `getBackground` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslide/)، می‌توانید پس‌زمینه مؤثر یک اسلاید را به‌دست آورید.

مثال زیر به زبان Java نشان می‌دهد چگونه مقدار پس‌زمینه مؤثر یک اسلاید را به‌دست آورید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دریافت پس‌زمینه مؤثر، با در نظر گرفتن اسلاید مادر، چیدمان و تم.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

### آیا می‌توانم پس‌زمینه سفارشی را بازنشانی کنم و پس‌زمینهٔ تم/چیدمان را بازیابی کنم؟

بله. پر کردن سفارشی اسلاید را حذف کنید، و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/java/slide-layout/)/[master](/slides/fa/java/slide-master/) مربوطه به ارث می‌رسد (یعنی [پس‌زمینهٔ تم](/slides/fa/java/presentation-theme/)).

### چه اتفاقی برای پس‌زمینه می‌افتد اگر بعداً تم ارائه را تغییر دهم؟

اگر اسلاید پر کردن خود را داشته باشد، بدون تغییر می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/java/slide-layout/)/[master](/slides/fa/java/slide-master/) ارث‌برداری شده باشد، با [تم جدید](/slides/fa/java/presentation-theme/) به‌روز می‌شود.