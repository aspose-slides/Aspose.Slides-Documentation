---
title: مدیریت بخش‌های متن در ارائه‌ها در اندروید
linktitle: بخش متن
type: docs
weight: 70
url: /fa/androidjava/portion/
keywords:
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه بخش‌های متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Android در Java مدیریت کنید، عملکرد و سفارشی‌سازی را بهبود دهید."
---
## **مقدمه**

بخش متن یک تکه متن خاص داخل یک پاراگراف را نشان می‌دهد و به شما امکان می‌دهد تا به طور مستقل با آن تکه کار کنید، بدون تأثیر بر محتوای اطراف. در Aspose.Slides، می‌توانید از بخش‌ها زمانی که نیاز به دریافت موقعیت یک تکه متن دارید، اعمال قالب‌بندی تنها بر بخشی از یک پاراگراف، یا کنترل رفتار متن در سطح جزئی‌تری دارید، استفاده کنید.

## **دریافت مختصات یک بخش متن**
[**getCoordinates()**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPortion#getCoordinates--) متدی است که به کلاس‌های [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) و [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) اضافه شده و امکان بازیابی مختصات ابتدای بخش را فراهم می‌کند.

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    // بازسازی زمینه ارائه
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

## **پرسش‌های متداول**

**آیا می‌توانم فقط بخشی از متن داخل یک پاراگراف را به پیوند، یا هیپرلینک، اختصاص دهم؟**

بله، می‌توانید [یک پیوند را اختصاص دهید](/slides/fa/androidjava/manage-hyperlinks/) به یک بخش خاص؛ تنها همان تکه قابل کلیک خواهد بود و کل پاراگراف کلیک‌پذیر نخواهد شد.

**وراثت سبک چگونه کار می‌کند: بخش (Portion) چه چیزی را بازنویسی می‌کند و چه چیزی از پاراگراف/قاب متن (Paragraph/TextFrame) گرفته می‌شود؟**

خصوصیات سطح بخش دارای اولویت بالاتری هستند. اگر یک خاصیت بر روی [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) تنظیم نشده باشد، موتور آن را از [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) می‌گیرد؛ اگر در آنجا هم تنظیم نشده باشد، از [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) یا سبک [theme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/theme/) استفاده می‌شود.

**اگر قلم (Font) مشخص‌شده برای یک بخش موجود در دستگاه/سرور هدف وجود نداشته باشد، چه اتفاقی می‌افتد؟**

قوانین جایگزینی قلم اعمال می‌شود. متن ممکن است بازچیدمان شود: مقیاس‌ها، تقسیم‌بندی واژگان و طول می‌تواند تغییر کند که برای موقعیت‌یابی دقیق اهمیت دارد.

**آیا می‌توانم شفافیت یا گرادیان پر متن ویژه یک بخش را به‌صورت مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) می‌تواند متفاوت از تکه‌های مجاور باشد.