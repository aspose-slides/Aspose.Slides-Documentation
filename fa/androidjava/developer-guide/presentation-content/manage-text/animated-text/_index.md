---
title: انیمیشن متن PowerPoint در اندروید
linktitle: متن انیمیشن‌شده
type: docs
weight: 60
url: /fa/androidjava/animated-text/
keywords:
- متن انیمیشن‌شده
- انیمیشن متن
- پاراگراف انیمیشن‌شده
- انیمیشن پاراگراف
- اثر انیمیشن
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "متن‌های پویا و انیمیشن‌شده را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Android ایجاد کنید، به همراه مثال‌های کد جاوا بهینه و آسان برای دنبال کردن."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با متن‌های متحرک در Aspose.Slides کار کنید، با اعمال اثرهای انیمیشن بر روی پاراگراف‌های جداگانه و دریافت اثرهایی که قبلاً به پاراگراف‌های یک فریم متن اختصاص داده شده‌اند. تمرکز بر روش‌های API مورد استفاده برای افزودن انیمیشن در سطح پاراگراف و بررسی اثرهای انیمیشن موجود در یک ارائه است.

## **افزودن اثرهای انیمیشن به پاراگراف‌ها**

ما روش [**addEffect()**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) را به کلاس‌های [**Sequence**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Sequence) و [**ISequence**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISequence) افزودیم. این روش به شما امکان می‌دهد اثرهای انیمیشن را به یک پاراگراف اضافه کنید. این کد نمونه نشان می‌دهد چگونه یک اثر انیمیشن به یک پاراگراف اضافه شود:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // انتخاب پاراگراف برای افزودن اثر
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // افزودن اثر انیمیشن Fly به پاراگراف انتخاب‌شده
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **دریافت اثرهای انیمیشن پاراگراف‌ها**

ممکن است بخواهید اثرهای انیمیشن اضافه‌شده به یک پاراگراف را بیابید—به عنوان مثال، در یک سناریو ممکن است بخواهید اثرهای انیمیشن یک پاراگراف را دریافت کنید زیرا قصد دارید آنها را به پاراگراف یا شکل دیگری اعمال کنید.

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد تمام اثرهای انیمیشن اعمال‌شده به پاراگراف‌های موجود در یک فریم متن (شکل) را دریافت کنید. این کد نمونه نشان می‌دهد چگونه اثرهای انیمیشن یک پاراگراف را دریافت کنید:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**چگونه انیمیشن‌های متن با انتقال اسلاید متفاوت هستند و آیا می‌توان آنها را ترکیب کرد؟**

انیمیشن‌های متن رفتار اشیاء را در طول زمان روی اسلاید کنترل می‌کنند، در حالی که [transitions](/slides/fa/androidjava/slide-transition/) نحوه تغییر اسلایدها را تعیین می‌کنند. این دو مستقل هستند و می‌توانند هم‌زمان استفاده شوند؛ ترتیب پخش توسط جدول زمانی انیمیشن و تنظیمات انتقال مشخص می‌شود.

**آیا انیمیشن‌های متن هنگام خروجی به PDF یا تصاویر حفظ می‌شوند؟**

خیر. PDF و تصاویر رستر ثابت هستند، بنابراین تنها یک حالت از اسلاید بدون حرکت را می‌بینید. برای حفظ حرکت، از خروجی [video](/slides/fa/androidjava/convert-powerpoint-to-video/) یا [HTML](/slides/fa/androidjava/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متن در قالب‌ها و اسلاید مستر کار می‌کنند؟**

اثرهای اعمال‌شده به اشیاء قالب/مستر به اسلایدها ارث می‌رسند، اما زمان‌بندی و تعامل آنها با انیمیشن‌های سطح اسلاید بستگی به ترتیب نهایی روی اسلاید دارد.