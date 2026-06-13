---
title: مدیریت گرافیک‌های SmartArt در ارائه‌ها با استفاده از Java
linktitle: گرافیک‌های SmartArt
type: docs
weight: 20
url: /fa/java/manage-smartart-shape/
keywords:
- شیء SmartArt
- گرافیک SmartArt
- سبک SmartArt
- رنگ SmartArt
- ایجاد SmartArt
- اضافه کردن SmartArt
- ویرایش SmartArt
- تغییر SmartArt
- دسترسی به SmartArt
- نوع طرح‌بندی SmartArt
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد خودکار گرافیک‌های SmartArt در PowerPoint، ویرایش و استایل‌بندی آنها در Java با استفاده از Aspose.Slides، شامل مثال‌های کد مختصر و راهنمایی‌های متمرکز بر عملکرد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا گرافیک‌های SmartArt را به‌صورت برنامه‌نویسی در ارائه‌های PowerPoint ایجاد و مدیریت کنید. این مقاله توضیح می‌دهد که چگونه یک شکل SmartArt را به یک اسلاید اضافه کنید، به اشکال SmartArt موجود دسترسی پیدا کنید، SmartArt را بر اساس نوع طرح‌بندی خاصی پیدا کنید، و ظاهر بصری آن را با تغییر سبک SmartArt یا سبک رنگی به‌روز کنید.

نمونه‌ها نشان می‌دهند که چگونه با اشکال SmartArt از طریق مجموعهٔ اشکال اسلاید ارائه کار کنید، بررسی کنید آیا یک شکل SmartArt است و سپس ویژگی‌های آن را اصلاح یا بررسی کنید.

## **ایجاد یک شکل SmartArt**

Aspose.Slides for Java یک API برای ایجاد اشکال SmartArt فراهم کرده است. برای ایجاد یک شکل SmartArt در یک اسلاید، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را با استفاده از Index آن به دست آورید.
3. [Add a SmartArt shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) با تنظیم آن [LayoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType).
4. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن شکل Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // ذخیره ارائه
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شکل: شکل SmartArt اضافه‌شده به اسلاید**|

## **دسترسی به یک شکل SmartArt در اسلاید**

کد زیر برای دسترسی به اشکال SmartArt اضافه‌شده به اسلاید ارائه استفاده خواهد شد. در کد نمونه، ما از هر شکل داخل اسلاید عبور می‌کنیم و بررسی می‌کنیم که آیا یک شکل [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt) است یا خیر. اگر شکل از نوع SmartArt باشد، آن را به نمونهٔ [**SmartArt**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt) تبدیل (typecast) می‌کنیم.

```java
// ارائه مورد نظر را بارگذاری کنید
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // در تمام اشکال داخل اولین اسلاید پیمایش کنید
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt)
        {
            // شکل را به SmartArtEx تبدیل کنید
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به یک شکل SmartArt با نوع Layout خاص**

کد نمونهٔ زیر به شما کمک می‌کند تا شکل [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt) را با LayoutType خاص دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توانید LayoutType را برای SmartArt تغییر دهید زیرا این مقدار فقط در زمان اضافه شدن شکل [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt) تنظیم می‌شود و فقط قابل خواندن است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اولین اسلاید را با استفاده از Index آن به دست آورید.
3. از هر شکل داخل اولین اسلاید عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt) است و اگر SmartArt است، آن را به SmartArt تبدیل کنید.
5. شکل SmartArt را با LayoutType خاص بررسی کنید و کاری که بعد از آن لازم است را انجام دهید.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // در تمام اشکال داخل اولین اسلاید پیمایش کنید
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt)
        {
            // شکل را به SmartArtEx تبدیل کنید
            ISmartArt smart = (ISmartArt) shape;

            // بررسی طرح‌بندی SmartArt
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

## **تغییر سبک یک شکل SmartArt**

در این مثال، می‌آموزیم که چگونه سبک سریع یک شکل SmartArt را تغییر دهیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اولین اسلاید را با استفاده از Index آن به دست آورید.
3. از هر شکل داخل اولین اسلاید عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt) است و اگر SmartArt است، آن را به SmartArt تبدیل کنید.
5. شکل SmartArt را با Style خاص پیدا کنید.
6. Style جدید را برای شکل SmartArt تنظیم کنید.
7. ارائه را ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // در تمام اشکال داخل اولین اسلاید پیمایش کنید
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // شکل را به SmartArtEx تبدیل کنید
            ISmartArt smart = (ISmartArt) shape;
    
            // بررسی سبک SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // تغییر سبک SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // ذخیره ارائه
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شکل: شکل SmartArt با سبک تغییر یافته**|

## **تغییر سبک رنگی یک شکل SmartArt**

در این مثال، می‌آموزیم که چگونه سبک رنگی یک شکل SmartArt را تغییر دهیم. در کد نمونه زیر، شکل SmartArt با سبک رنگی خاص را دسترسی می‌کنیم و سبک آن را تغییر می‌دهیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اولین اسلاید را با استفاده از Index آن به دست آورید.
3. از هر شکل داخل اولین اسلاید عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt) است و اگر SmartArt است، آن را به SmartArt تبدیل کنید.
5. شکل SmartArt را با Style رنگی خاص پیدا کنید.
6. Style رنگی جدید را برای شکل SmartArt تنظیم کنید.
7. ارائه را ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // در تمام اشکال داخل اولین اسلاید پیمایش کنید
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // شکل را به SmartArtEx تبدیل کنید
            ISmartArt smart = (ISmartArt) shape;
    
            // بررسی نوع رنگ SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // تغییر نوع رنگ SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // ذخیره ارائه
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**شکل: شکل SmartArt با سبک رنگی تغییر یافته**|

## **پرسش‌های متداول**

**آیا می‌توانم SmartArt را به‌عنوان یک شیء واحد انیمیشن کنم؟**

بله. SmartArt یک شکل است، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/java/powerpoint-animation/) را از طریق API انیمیشن‌ها (ورودی، خروجی، تأکید، مسیرهای حرکتی) همانند اشکال دیگر اعمال کنید.

**چگونه می‌توانم یک SmartArt خاص را در اسلاید پیدا کنم اگر شناسه داخلی آن را ندانم؟**

متن جایگزین (AltText) را تنظیم کنید و با استفاده از آن به‌دنبال شکل بگردید — این روش پیشنهادی برای یافتن شکل هدف است.

**آیا می‌توانم SmartArt را با اشکال دیگر گروپ کنم؟**

بله. می‌توانید SmartArt را با اشکال دیگر (تصاویر، جداول و غیره) گروپ کنید و سپس [دستکاری گروه](/slides/fa/java/group/) را انجام دهید.

**چگونه می‌توانم تصویر یک SmartArt خاص را دریافت کنم (مثلاً برای پیش‌نمایش یا گزارش)؟**

یک تصویر بندانگشتی/تصویر از شکل را صادر کنید؛ کتابخانه می‌تواند [رندر اشکال تک‌تک](/slides/fa/java/create-shape-thumbnails/) را به فایل‌های رستر (PNG/JPG/TIFF) تبدیل کند.

**آیا ظاهر SmartArt هنگام تبدیل تمام ارائه به PDF حفظ می‌شود؟**

بله. موتور رندرینگ برای [خروجی PDF](/slides/fa/java/convert-powerpoint-to-pdf/) با دقت بالا هدف‌گذاری می‌کند و گزینه‌های متنوعی برای کیفیت و سازگاری فراهم می‌کند.