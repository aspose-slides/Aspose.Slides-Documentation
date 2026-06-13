---
title: مدیریت گرافیک‌های SmartArt در ارائه‌ها بر روی Android
linktitle: گرافیک‌های SmartArt
type: docs
weight: 20
url: /fa/androidjava/manage-smartart-shape/
keywords:
- شیء SmartArt
- گرافیک SmartArt
- سبک SmartArt
- رنگ SmartArt
- ایجاد SmartArt
- افزودن SmartArt
- ویرایش SmartArt
- تغییر SmartArt
- دسترسی به SmartArt
- نوع طرح‌بندی SmartArt
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "ایجاد، ویرایش و استایل‌گذاری خودکار SmartArt در PowerPoint با استفاده از Aspose.Slides برای Android، شامل مثال‌های کوتاه کد Java و راهنمایی‌های متمرکز بر عملکرد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد گرافیک‌های SmartArt را در ارائه‌های PowerPoint به صورت برنامه‌نویسی ایجاد و مدیریت کنید. این مقاله توضیح می‌دهد چگونه یک شکل SmartArt را به یک اسلاید اضافه کنید، به اشکال SmartArt موجود دسترسی پیدا کنید، SmartArt را بر اساس نوع طرح خاصی پیدا کنید، و ظاهر بصری آن را با تغییر سبک SmartArt یا سبک رنگی به‌روز کنید.

نمونه‌ها نشان می‌دهند چگونه از طریق مجموعهٔ اشکال اسلاید ارائه با اشکال SmartArt کار کنید، بررسی کنید آیا یک شکل SmartArt است و سپس ویژگی‌های آن را تغییر یا بررسی کنید.

## **ایجاد یک شکل SmartArt**
Aspose.Slides for Android via Java یک API برای ایجاد اشکال SmartArt فراهم کرده است. برای ایجاد یک شکل SmartArt در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. با استفاده از Index، مرجع یک اسلاید را دریافت کنید.
1. با استفاده از روش [Add a SmartArt shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) و تنظیم آن با [LayoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType) یک شکل SmartArt اضافه کنید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

```java
// ایجاد نمونهٔ کلاس Presentation
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن شکل Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // ذخیره‌سازی ارائه
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شکل: شکل SmartArt اضافه شده به اسلاید**|

## **دسترسی به شکل SmartArt در یک اسلاید**
کد زیر برای دسترسی به اشکال SmartArt اضافه شده در اسلاید ارائه استفاده خواهد شد. در نمونهٔ کد، تمام اشکال داخل اسلاید را پیمایش می‌کنیم و بررسی می‌کنیم آیا شکل SmartArt است یا نه. اگر شکل از نوع SmartArt باشد، آن را به نمونهٔ **SmartArt** تبدیل می‌کنیم.

```java
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // پیمایش تمام اشکال داخل اولین اسلاید
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt)
        {
            // تبدیل نوع شکل به SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به شکل SmartArt با نوع Layout خاص**
کد نمونهٔ زیر به شما کمک می‌کند تا به شکل [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt) با LayoutType خاص دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توانید LayoutType را تغییر دهید، زیرا این ویژگی فقط هنگام افزودن شکل SmartArt تنظیم می‌شود و فقط قابل‌خواندن است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index، مرجع اولین اسلاید را دریافت کنید.
1. تمام اشکال داخل اولین اسلاید را پیمایش کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt) است و در صورت صحت، آن را به SmartArt تبدیل کنید.
1. شکل SmartArt با LayoutType خاص را بررسی کنید و پس از آن کاری که مورد نیاز است را انجام دهید.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // پیمایش تمام اشکال داخل اولین اسلاید
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt)
        {
            // تبدیل نوع شکل به SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // بررسی Layout SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر سبک شکل SmartArt**
در این مثال، نحوه تغییر سبک سریع برای هر شکل SmartArt یاد می‌گیریم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index، مرجع اولین اسلاید را دریافت کنید.
1. تمام اشکال داخل اولین اسلاید را پیمایش کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt) است و در صورت صحت، آن را به SmartArt تبدیل کنید.
1. شکل SmartArt با Style خاص را پیدا کنید.
1. Style جدید را برای شکل SmartArt تنظیم کنید.
1. ارائه را ذخیره کنید.

```java
// ایجاد نمونهٔ کلاس Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // پیمایش تمام اشکال داخل اولین اسلاید
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // بررسی سبک SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // تغییر سبک SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // ذخیره‌سازی ارائه
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شکل: شکل SmartArt با Style تغییر یافته**|

## **تغییر سبک رنگی شکل SmartArt**
در این مثال، نحوه تغییر سبک رنگی برای هر شکل SmartArt را یاد می‌گیریم. در کد نمونهٔ زیر به شکل SmartArt با سبک رنگی خاص دسترسی پیدا می‌کنیم و سبک آن را تغییر می‌دهیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index، مرجع اولین اسلاید را دریافت کنید.
1. تمام اشکال داخل اولین اسلاید را پیمایش کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt) است و در صورت صحت، آن را به SmartArt تبدیل کنید.
1. شکل SmartArt با Color Style خاص را پیدا کنید.
1. Color Style جدید را برای شکل SmartArt تنظیم کنید.
1. ارائه را ذخیره کنید.

```java
// ایجاد نمونهٔ کلاس Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // پیمایش تمام اشکال داخل اولین اسلاید
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // بررسی نوع رنگ SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // تغییر نوع رنگ SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // ذخیره‌سازی ارائه
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**شکل: شکل SmartArt با Color Style تغییر یافته**|

## **سوالات متداول**

**آیا می‌توانم SmartArt را به عنوان یک شیء واحد انیمیشن بدهم؟**

بله. SmartArt یک شکل است، بنابراین می‌توانید همانند سایر اشکال، از طریق API انیمیشن‌ها [standard animations](/slides/fa/androidjava/powerpoint-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) استفاده کنید.

**چگونه می‌توانم یک SmartArt خاص را در اسلاید پیدا کنم اگر ID داخلی آن را ندارم؟**

متن جایگزین (AltText) را تنظیم کنید و با جستجو بر اساس این مقدار به شکل مورد نظر دست یابید؛ این روش پیشنهادی برای پیدا کردن هدف است.

**آیا می‌توانم SmartArt را با اشکال دیگر گروه‌بندی کنم؟**

بله. می‌توانید SmartArt را با اشکال دیگر (تصاویر، جداول و غیره) گروه‌بندی کنید و سپس [manipulate the group](/slides/fa/androidjava/group/) کنید.

**چگونه می‌توانم تصویر یک SmartArt خاص (مثلاً برای پیش‌نمایش یا گزارش) به‌دست آورم؟**

یک تصویر بندانگشتی/عکس از شکل استخراج کنید؛ کتابخانه می‌تواند [render individual shapes](/slides/fa/androidjava/create-shape-thumbnails/) را به فایل‌های رستر (PNG/JPG/TIFF) رندر کند.

**آیا ظاهر SmartArt پس از تبدیل کل ارائه به PDF حفظ می‌شود؟**

بله. موتور رندرینگ برای [PDF export](/slides/fa/androidjava/convert-powerpoint-to-pdf/) با دقت بالا هدف‌گذاری شده و گزینه‌های متنوعی برای کیفیت و سازگاری ارائه می‌دهد.