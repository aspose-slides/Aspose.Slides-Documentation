---
title: مدیریت پس‌زمینه‌های ارائه در اندروید
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/androidjava/presentation-background/
keywords:
- پس‌زمینه ارائه
- پس‌زمینه اسلاید
- رنگ ثابت
- رنگ گرادیان
- پس‌زمینه تصویر
- شفافیت پس‌زمینه
- ویژگی‌های پس‌زمینه
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه پس‌زمینه‌های دینامیک را در فایل‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای اندروید از طریق Java تنظیم کنید، همراه با نکات کد برای ارتقاء ارائه‌های خود."
---
## **مقدمه**

رنگ‌های ثابت، گرادیانت‌ها و تصاویر به‌طور معمول برای پس‌زمینه اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه را برای یک **اسلاید عادی** (یک اسلاید تک) یا یک **اسلاید اصلی** (بر روی چندین اسلاید به‌صورت همزمان اعمال می‌شود) تنظیم کنید.

![PowerPoint background](powerpoint-background.png)

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید عادی**

Aspose.Slides به شما امکان می‌دهد رنگ ثابت را به‌عنوان پس‌زمینهٔ یک اسلاید خاص در ارائه تنظیم کنید — حتی اگر ارائه از یک اسلاید اصلی استفاده کند. این تغییر فقط بر روی اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. BackgroundType اسلاید را به `OwnBackground` تنظیم کنید.
3. FillType پس‌زمینه اسلاید را به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) در [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) برای مشخص کردن رنگ پس‌زمینهٔ ثابت استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال جاوا زیر نشان می‌دهد چگونه یک رنگ ثابت آبی را به‌عنوان پس‌زمینهٔ اسلاید عادی تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // رنگ پس‌زمینهٔ اسلاید را به آبی تنظیم کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // ارائه را در دیسک ذخیره کنید.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید اصلی**

Aspose.Slides به شما امکان می‌دهد رنگ ثابت را به‌عنوان پس‌زمینهٔ اسلاید اصلی در یک ارائه تنظیم کنید. اسلاید اصلی به‌عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین وقتی رنگ ثابت را برای پس‌زمینهٔ اسلاید اصلی انتخاب می‌کنید، بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. BackgroundType اسلاید اصلی (از طریق `getMasters`) را به `OwnBackground` تنظیم کنید.
3. FillType پس‌زمینهٔ اسلاید اصلی را به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) برای مشخص کردن رنگ پس‌زمینهٔ ثابت استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال جاوا زیر نشان می‌دهد چگونه یک رنگ ثابت (سبز) را به‌عنوان پس‌زمینهٔ اسلاید اصلی تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // رنگ پس‌زمینهٔ اسلاید اصلی را به سبز تنظیم کنید.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // ارائه را در دیسک ذخیره کنید.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینه گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. وقتی به‌عنوان پس‌زمینهٔ اسلاید استفاده شود، گرادیان‌ها می‌توانند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر نشان دهند. Aspose.Slides به شما امکان می‌دهد رنگ گرادیان را به‌عنوان پس‌زمینهٔ اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. BackgroundType اسلاید را به `OwnBackground` تنظیم کنید.
3. FillType پس‌زمینه اسلاید را به `Gradient` تنظیم کنید.
4. از متد [getGradientFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) در [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) برای پیکربندی تنظیمات دلخواه گرادیان استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال جاوا زیر نشان می‌دهد چگونه یک رنگ گرادیان را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // یک اثر گرادیان به پس‌زمینه اعمال کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // رنگ‌های گرادیان را اضافه کنید. بدون نقاط توقف گرادیان، پس‌زمینه به نرده پیش‌فرض سیاه به سفید بازمی‌گردد.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // ارائه را در دیسک ذخیره کنید.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تصویر به‌عنوان پس‌زمینهٔ اسلاید**

علاوه بر پر کردن‌های ثابت و گرادیان، Aspose.Slides به شما امکان می‌دهد از تصاویر به‌عنوان پس‌زمینهٔ اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. BackgroundType اسلاید را به `OwnBackground` تنظیم کنید.
3. FillType پس‌زمینهٔ اسلاید را به `Picture` تنظیم کنید.
4. تصویری که می‌خواهید به‌عنوان پس‌زمینهٔ اسلاید استفاده کنید را بارگذاری کنید.
5. تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
6. از متد [getPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) در [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) برای اختصاص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

مثال جاوا زیر نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

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
    
    // ارائه را در دیسک ذخیره کنید.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمونه کد زیر نشان می‌دهد چگونه نوع پر کردن پس‌زمینه را به تصویر کاشی‌شده تنظیم کنید و خصوصیات کاشی شدن را اصلاح کنید:

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

    // تصویر مورد استفاده برای پر کردن پس‌زمینه را تنظیم کنید.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // حالت پر کردن تصویر را روی کاشی تنظیم کنید و ویژگی‌های کاشی را تنظیم کنید.
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
بیشتر بخوانید: [**Tile Picture As Texture**](/slides/fa/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینهٔ اسلاید را تنظیم کنید تا محتوای اسلاید برجسته‌تر شود. کد جاوا زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینهٔ اسلاید را تغییر دهید:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // برای مثال.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دریافت مجموعهٔ عملیات تبدیل تصویر.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // یافتن یک اثر شفافیت ثابت بر حسب درصد موجود.
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

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت مقدار پس‌زمینهٔ اسلاید**

Aspose.Slides رابط [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibackgroundeffectivedata/) را برای بازیابی مقادیر مؤثر پس‌زمینهٔ اسلاید فراهم می‌کند. این رابط [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و [EffectFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) مؤثر را در دسترس قرار می‌دهد.

با استفاده از متد `getBackground` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslide/) می‌توانید پس‌زمینهٔ مؤثر یک اسلاید را به دست آورید.

مثال جاوا زیر نشان می‌دهد چگونه مقدار پس‌زمینهٔ مؤثر یک اسلاید را دریافت کنید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دریافت پس‌زمینهٔ مؤثر، با در نظر گرفتن اسلاید اصلی، چیدمان و تم.
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

### آیا می‌توانم یک پس‌زمینهٔ سفارشی را بازنشانی کرده و پس‌زمینهٔ تم/چیدمان را بازگردانم؟

بله. پر کردن سفارشی اسلاید را حذف کنید، و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/androidjava/slide-layout/)/[master](/slides/fa/androidjava/slide-master/) مربوطه به ارث می‌رسد (یعنی [پس‌زمینهٔ تم](/slides/fa/androidjava/presentation-theme/)).

### چه اتفاقی برای پس‌زمینه می‌افتد اگر بعداً تم ارائه را تغییر دهم؟

اگر یک اسلاید پر کردن خود را داشته باشد، بدون تغییر می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/androidjava/slide-layout/)/[master](/slides/fa/androidjava/slide-master/) به ارث برده باشد، برای مطابقت با [تم جدید](/slides/fa/androidjava/presentation-theme/) به‌روزرسانی می‌شود.