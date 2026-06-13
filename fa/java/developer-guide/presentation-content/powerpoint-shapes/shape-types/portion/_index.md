---
title: مدیریت بخش‌های متن در ارائه‌ها با استفاده از جاوا
linktitle: بخش متن
type: docs
weight: 70
url: /fa/java/portion/
keywords:
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه بخش‌های متن را در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای جاوا مدیریت کنید، عملکرد و سفارشی‌سازی را ارتقا دهید."
---
## **نمای کلی**

یک بخش متن نمایانگر یک تکه خاص از متن داخل یک پاراگراف است و به شما اجازه می‌دهد که با آن تکه به‌صورت مستقل از محتوای اطراف کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز به دریافت موقعیت یک تکه متن داشته باشید، فرمت‌دهی را فقط بر بخشی از پاراگراف اعمال کنید، یا رفتار متن را در سطحی دقیق‌تر کنترل کنید.

این مقاله نشان می‌دهد چگونه می‌توان مختصات آغاز یک بخش را با استفاده از متد `getCoordinates()` به دست آورد. همچنین سناریوهای رایج مرتبط با بخش را برجسته می‌کند، از جمله اعمال یک پیوند به یک تک تکه متن، درک نحوه‌حل‌وفام‌ فرمت‌گذاری از طریق بخش، پاراگراف، قاب متن و ارث‌بری تم، و مدیریت مواردی که فونت مشخص شده در دسترس نیست. علاوه بر این، اشاره می‌کند که پر کردن متن، رنگ و شفافیت می‌تواند برای هر بخش به‌طور جداگانه در همان پاراگراف تنظیم شود.

## **دریافت مختصات یک بخش متن**
[**getCoordinates()**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortion#getCoordinates--) متد به کلاس‌های [IPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/) و [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) اضافه شده است که امکان دریافت مختصات آغاز بخش را فراهم می‌کند.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر PPTX است
Presentation pres = new Presentation();
try {
    // بازآفرینی زمینه ارائه
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم یک پیوند را فقط بر بخشی از متن در یک پاراگراف واحد اعمال کنم؟**

بله، می‌توانید یک [پیوند اختصاص دهید](/slides/fa/java/manage-hyperlinks/) به یک بخش فردی؛ فقط آن تکه کلیک‌پذیر خواهد بود و نه کل پاراگراف.

**وراثت استایل چگونه کار می‌کند: یک Portion چه چیزی را بازنویسی می‌کند و چه چیزی از Paragraph/TextFrame گرفته می‌شود؟**

ویژگی‌های سطح Portion بالاترین اولویت را دارند. اگر ویژگی‌ای روی [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) تنظیم نشده باشد، موتور آن را از [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) می‌گیرد؛ اگر در آن‌جا نیز تنظیم نشده باشد، از سبک [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) یا [theme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/theme/) گرفته می‌شود.

**چه اتفاقی می‌افتد اگر فونت مشخص‌شده برای یک Portion در ماشین/سرور هدف موجود نباشد؟**

قوانین [جایگزینی فونت](/slides/fa/java/font-selection-sequence/) اعمال می‌شود. متن ممکن است دوباره جریان یابد: معیارها، هایفن‌گذاری و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت یا گرادیان پر کردن متن خاص یک Portion را به‌صورت مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر کردن و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) می‌تواند با تکه‌های همسایه متفاوت باشد.