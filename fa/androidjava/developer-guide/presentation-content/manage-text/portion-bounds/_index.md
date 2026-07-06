---
title: دریافت مرزهای بخش متن از ارائه‌ها در اندروید
linktitle: مرزهای بخش
type: docs
weight: 47
url: /fa/androidjava/portion-bounds/
keywords:
- مرزهای بخش متن
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "نحوه دریافت مرزهای بخش متن در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای اندروید از طریق جاوا را بیاموزید."
---
## **بررسی کلی**

یک بخش متن نشانگر یک قطعه خاص از متن درون یک پاراگراف است و به شما امکان می‌دهد که به صورت مستقل بر روی آن قطعه کار کنید، بدون در نظر گرفتن محتوای اطراف. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز به دریافت مرزهای یک قطعه متن داشته باشید، قالب‌بندی را فقط بر روی بخشی از پاراگراف اعمال کنید، یا رفتار متن را در سطح جزئی‌تری کنترل کنید.

این مقاله نشان می‌دهد چگونه با استفاده از [IPortion.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPortion#getRect--) مستطیل محاطی یک بخش را دریافت کنید. همچنین نحوه دریافت مختصات شروع یک بخش را با استفاده از [IPortion.getCoordinates](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPortion#getCoordinates--) نشان می‌دهد. علاوه بر این، سناریوهای رایج مرتبط با بخش‌ها را برجسته می‌کند، مانند اعمال یک پیوند به یک قطعه متن واحد، درک نحوه حل قالب‌بندی از طریق بخش، پاراگراف، فریم متن و ارث‌بری تم، و مدیریت مواردی که قلم مشخصی در دسترس نیست.

## **دریافت مرزهای یک بخش متن**

از [IPortion.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPortion#getRect--) برای دریافت مستطیل محاطی یک بخش متن استفاده کنید:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **دریافت مختصات یک بخش متن**

از [IPortion.getCoordinates](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPortion#getCoordinates--) برای دریافت مختصات شروع یک بخش متن استفاده کنید:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم یک پیوند را فقط به بخشی از متن درون یک پاراگراف واحد اعمال کنم؟**

بله، می‌توانید [اختصاص یک پیوند](/slides/fa/androidjava/manage-hyperlinks/) را به یک بخش جداگانه اعمال کنید؛ فقط آن قطعه کلیک‌پذیر خواهد بود، نه کل پاراگراف.

**چگونه ارث‌بری سبک کار می‌کند: بخش چه چیزی را بازنویسی می‌کند و چه چیزی از پاراگراف یا فریم متن گرفته می‌شود؟**

ویژگی‌های سطح بخش بالاترین الویت را دارند. اگر یک ویژگی در [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) تنظیم نشده باشد، Aspose.Slides آن را از [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) می‌گیرد. اگر در آنجا نیز تنظیم نشده باشد، Aspose.Slides از سبک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) یا [theme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/theme/) استفاده می‌کند.

**اگر قلم مشخص‌شده برای یک بخش در دستگاه یا سرور هدف موجود نباشد چه اتفاقی می‌افتد؟**

[قوانین جایگزینی قلم](/slides/fa/androidjava/font-selection-sequence/) اعمال می‌شوند. متن ممکن است بازچینش شود: مقیاس‌ها، هیفن‌گذاری و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت پر کردن متن یا گرادیان خاص بخش را به‌صورت مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر کردن و شفافیت در سطح [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) می‌تواند با قطعات همسایه متفاوت باشد.